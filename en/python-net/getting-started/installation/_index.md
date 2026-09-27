---
title: Installation
type: docs
weight: 70
url: /python-net/installation/
keywords:
- download Aspose.Slides
- install Aspose.Slides
- use Aspose.Slides
- Aspose.Slides installation
- pip
- PyPI
- Windows
- Linux
- macOS
- Python
description: "Install Aspose.Slides for Python via .NET from PyPI with pip on Windows, Linux, and macOS, and install the native libraries that Linux and macOS need."
---

## **Overview**

This article explains how to install Aspose.Slides for Python via .NET on Windows, Linux, and macOS. The package is published on [PyPI](https://pypi.org/project/aspose.slides/) and installed with pip. It includes the .NET runtime it uses, so you do not need to install .NET. On Linux and macOS, that runtime needs native libraries that the operating system may not include; the sections below name them.

Aspose.Slides for Python via .NET supports Python 3.5 to 3.14. PyPI provides packages for Windows (32-bit and 64-bit), Linux (x86_64 and ARM64), and macOS (Intel and Apple silicon).

## **Windows**

On Windows, install the package with pip. No other libraries are required.

```bash
pip install aspose.slides
```

## **Linux**

On Linux, the .NET runtime included in the package needs two libraries:

- **libgdiplus**, an implementation of the Windows GDI+ graphics API. Without it, saving a presentation fails with the error `The type initializer for 'Gdip' threw an exception`.
- **ICU** (International Components for Unicode). Without it, the Python process terminates at the first Aspose.Slides call with the message `Couldn't find a valid ICU package installed on the system`.

On Debian and Ubuntu, install both with apt:

```bash
sudo apt-get update && sudo apt-get install -y libgdiplus libicu76
```

The name of the ICU package contains its version: `libicu76` is the package for Debian 13. On Debian 12, install `libicu72` instead, and on Ubuntu 24.04, `libicu74`. To find the name on your system, run:

```bash
apt-cache search --names-only '^libicu[0-9]+$'
```

Then install the package into a virtual environment. On current Debian and Ubuntu releases, the system Python does not allow `pip install` outside a virtual environment and stops with the error `externally-managed-environment`.

```bash
sudo apt-get install -y python3-venv
python3 -m venv .venv
. .venv/bin/activate
pip install aspose.slides
```

Run your scripts with the same virtual environment activated. If you use a Python that your distribution does not manage, such as the one in the official `python` Docker images, you can also run `pip install aspose.slides` without a virtual environment.

The fonts used in your presentations, or suitable substitutes, must be installed on the system for text to render correctly when you convert slides to PDF or images.

## **macOS**

We have not verified the installation on macOS. On macOS, Aspose.Slides needs the following prerequisites:

- **Python with shared libraries**, that is, Python built with the `--enable-shared` configure option. If you install Python with [pyenv](https://github.com/pyenv/pyenv#homebrew-in-macos), set the `PYTHON_CONFIGURE_OPTS` environment variable to `--enable-shared` when you install a Python version.
- **The libpython library in a system library directory.** A Python installed with pyenv keeps its libpython library, such as *libpython3.9.dylib*, under *~/.pyenv/versions*; create a symbolic link to it in */usr/local/lib*.
- **libgdiplus**, an implementation of the Windows GDI+ graphics API. Homebrew provides it as the `mono-libgdiplus` package.

Then install the package with pip.

## **Check the Installation**

To check the installation, save the first example in [Create Presentations](/slides/python-net/create-presentation/) as *hello.py* and run `python hello.py`. It saves *new_presentation.pptx* in the current folder.

## **Upgrade**

To upgrade an existing installation to the latest version, run this command in the environment where you installed the package:

```bash
pip install --upgrade aspose.slides
```

## **FAQ**

**Can I install Aspose.Slides in a virtual environment?**

Yes. You can install it in any Python virtual environment with pip. The native libraries that Linux and macOS need are installed on the system, not in the virtual environment.

**Can I use Aspose.Slides in Docker containers?**

Yes. The image must include the same native libraries as a Linux system — libgdiplus and ICU — and the fonts your presentations use.

**Is there a free version or trial limitation?**

Yes. Without a license, Aspose.Slides runs in evaluation mode: it adds an evaluation watermark to every slide it saves and truncates text read from presentations. To remove these limitations, apply a valid [license](/slides/python-net/licensing/).
