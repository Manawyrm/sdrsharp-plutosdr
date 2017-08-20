# sdrsharp-plutosdr

Analog Devices ADALM-PlutoSDR driver for SDR#

## Installation

### Windows

**Make sure you're using the x86 / 32-bit version of SDR#! It'll not work with the 64bit version.**

1. Copy the the contents of the [current release .zip](https://github.com/Manawyrm/sdrsharp-plutosdr/releases) into SDR# installation directory
2. Add the following line in the frontendPlugins sections of FrontEnds.xml file:

	&lt;add key="PlutoSDR" value="SDRSharp.PlutoSDR.PlutoSDRIO,SDRSharp.PlutoSDR" /&gt;

3. Launch SDR# and cross fingers :)

**Be aware that any update of SDR# will require you to follow again steps 2 to 4!**

## Thanks to 

Jean-Michel Picod for the bladeRF driver, which was used as a base for this driver
https://github.com/jmichelp/sdrsharp-bladerf

dos_fan] and prog for very helpful support while debugging

## Bugs? Ideas?

Please report them using the bugtracker on the Github project!
