# sdrsharp-plutosdr

Analog Devices ADALM-PlutoSDR driver for SDR#

## Installation

### Windows

**Make sure you're using the x86 / 32-bit version of SDR#! It'll not work with the 64bit version.**
**Make sure you're using the [latest firmware](https://wiki.analog.com/university/tools/pluto/users/firmware) for the PlutoSDR!**

1. Install the [USB drivers for the PlutoSDR](https://github.com/analogdevicesinc/plutosdr-m2k-drivers-win/releases). 

2. Copy the the contents of the [current release .zip](https://github.com/Manawyrm/sdrsharp-plutosdr/releases) into SDR# installation directory
3. Add the following line in the frontendPlugins sections of FrontEnds.xml file:

	&lt;add key="PlutoSDR" value="SDRSharp.PlutoSDR.PlutoSDRIO,SDRSharp.PlutoSDR" /&gt;

4. Launch SDR# and cross fingers :)

**Be aware that any update of SDR# will require you to follow again steps 2 to 4!**

[Mod for 70-6000 MHz operation](https://wiki.analog.com/university/tools/pluto/users/customizing#updating_to_the_ad9364) currently required for this plugin! 

## Thanks to 

Jean-Michel Picod for the bladeRF driver, which was used as a base for this driver
https://github.com/jmichelp/sdrsharp-bladerf

dos_fan] and prog for very helpful support while debugging

## Bugs? Ideas?

Please report them using the bugtracker on the Github project!
