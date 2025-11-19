---
title: System Requirements
type: docs
weight: 60
url: /python-net/system-requirements/
keywords:
- system requirements
- operating system
- installation
- dependencies
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Discover Aspose.Slides for Python via .NET system requirements. Ensure seamless PowerPoint and OpenDocument support on Windows, Linux, and macOS."
---

## **Introduction**

Aspose.Slides for Python via .NET does not require any third-party products, such as Microsoft PowerPoint, to be installed. Aspose.Slides is an engine for creating, modifying, converting, and rendering documents in various formats, including Microsoft PowerPoint presentation formats.

## **Supported Operating Systems**

Aspose.Slides for Python supports Windows (32-bit and 64-bit), macOS, and 64-bit Linux on systems with Python 3.5 or later installed.

<table>  
    <tr>
        <td style="font-weight: bold; width:400px">Operating System</td>
        <td style="font-weight: bold; width:400px">Versions</td>
    </tr>
    <tr>
        <td>Microsoft Windows</td>
        <td>
            <ul>
                <li>Windows 2003 Server</li>
                <li>Windows 2008 Server</li>
                <li>Windows 2012 Server</li>
                <li>Windows 2012 R2 Server</li>
                <li>Windows 2016 Server</li>
                <li>Windows 2019 Server</li>
                <li>Windows XP</li>
                <li>Windows Vista</li>
                <li>Windows 7</li>
                <li>Windows 8, 8.1</li>
                <li>Windows 10</li>
                <li>Windows 11</li>
            </ul>
        </td>
    </tr>
    <tr>
        <td>Linux</td>
        <td>
            <ul>
                <li>Ubuntu</li>
                <li>OpenSUSE</li>
                <li>CentOS</li>
                <li>and others</li>
            </ul>
        </td>
    </tr>
    <tr>
        <td>macOS</td>
        <td>
            <ul>
                <li>12 "Monterey"</li>
            </ul>
        </td>
    </tr>
</table>

## **System Requirements for Target Linux and macOS Platforms**

- GCC 6 runtime libraries (or later).
- [libgdiplus](https://github.com/mono/libgdiplus), an open-source implementation of the GDI+ API.
- Dependencies of the .NET Core Runtime. Installing the .NET Core Runtime itself is NOT required.
- For Python 3.5–3.7: the `pymalloc` build of Python is required. The `--with-pymalloc` build option is enabled by default. Typically, the `pymalloc` build of Python is marked with an `m` suffix in the filename.
- The `libpython` shared library. The `--enable-shared` Python build option is disabled by default, and some Python distributions do not include the `libpython` shared library. On some Linux platforms, you can install the `libpython` shared library using the package manager (for example, `sudo apt-get install libpython3.7`). A common issue is that the `libpython` library is installed in a nonstandard location for shared libraries. You can resolve this by using Python build options to set alternate library paths when compiling Python, or by creating a symbolic link to the `libpython` library file in the system’s standard shared library location. Typically, the `libpython` shared library filename is `libpythonX.Ym.so.1.0` for Python 3.5–3.7 or `libpythonX.Y.so.1.0` for Python 3.8 or later (for example, `libpython3.7m.so.1.0`, `libpython3.9.so.1.0`).

## **FAQ**

**Do I need Microsoft PowerPoint installed for conversions and rendering?**

No, PowerPoint is not required; Aspose.Slides is a standalone engine for [creating](/slides/python-net/create-presentation/), modifying, [converting](/slides/python-net/convert-presentation/), and [rendering](/slides/python-net/convert-powerpoint-to-png/) presentations.

**Is a specific .NET version (Core/5+/6+) required on the machine?**

Installing the .NET Runtime itself is not required, but its dependencies must be present on Linux/macOS. This means the system should contain the packages that are usually installed as .NET dependencies, without installing the runtime in full.

**Which fonts are needed for correct rendering?**

In practice, the fonts used in the presentation or proper [substitutes](/slides/python-net/font-substitution/) must be available. To ensure consistent rendering on Linux/macOS, it is advisable to install common font packages.
