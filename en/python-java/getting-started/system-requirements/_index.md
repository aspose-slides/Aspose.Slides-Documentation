---
title: System Requirements
type: docs
weight: 60
url: /python-java/system-requirements/
keywords:
- system requirements
- Python
- Java
- JPype
- Windows
- Linux
- macOS
- Aspose.Slides
description: "Check the operating system, Python, Java, and JPype requirements for running Aspose.Slides for Python via Java on Windows, Linux, and macOS."
---

## **Overview**

Aspose.Slides for Python via Java creates, modifies, converts, and renders presentations without Microsoft PowerPoint installed. It uses JPype to access the Java library from Python, so the environment must support Python, Java, and JPype together.

## **Supported Operating Systems**

The [Aspose.Slides package](https://pypi.org/project/aspose-slides-java/) supports the following operating system families:

- Windows
- Linux
- macOS

Choose an operating system version supported by your selected Python, Java, and JPype releases. Java availability alone does not establish compatibility with the Python package and its bridge.

## **Python, Java, and JPype Requirements**

| Component | Requirement |
| --- | --- |
| Python | The Aspose.Slides package declares Python 3.7 through 3.14. The selected JPype release must support the same Python version; for example, [JPype1 1.7.1](https://pypi.org/project/jpype1/1.7.1/) requires Python 3.8 or later. |
| Java | Install a Java runtime or JDK compatible with the selected JPype release. The current [JPype prerequisites](https://jpype.readthedocs.io/en/latest/userguide.html#prerequisites) specify Java 11 or later. Java 8 cannot run JPype1 1.7.1. |
| JPype | Install the JPype1 package for your Python interpreter, operating system, and CPU architecture. |
| CPU architecture | Python and the Java Virtual Machine (JVM) must use matching architectures. For example, a 64-bit Python interpreter requires a compatible 64-bit JVM. |

On Apple Silicon, Python and Java must both use ARM64 or both use x64. A JVM that runs independently can still fail to load through JPype if its architecture differs from Python's.

For a new environment, Python 3.12, JDK 17, and JPype1 1.7.1 are a suitable starting point. This combination was verified with Aspose.Slides for Python via Java 26.6.0 on Windows. Other combinations must satisfy the requirements of all three components.

For environment setup and a working verification example, see [Installation](/slides/python-java/installation/).

## **Additional Dependencies**

A compatible prebuilt JPype wheel does not require a C++ compiler. If JPype must be built from source, install a compatible C++ compiler and the Python development files required by your platform. See the [JPype installation instructions](https://jpype.readthedocs.io/en/latest/install.html) for build requirements and troubleshooting.

## **FAQ**

**Do I need Microsoft PowerPoint installed?**

No. Aspose.Slides processes presentations independently of PowerPoint. Python, Java, and JPype are still required.

**Can I use Python 3.7 with any JPype release?**

No. Although the Aspose.Slides package declares Python 3.7 support, JPype1 1.7.1 requires Python 3.8 or later. Choose versions whose requirements overlap.

**Can I mix 32-bit Python with 64-bit Java?**

No. JPype loads the JVM into the Python process, so Python and Java must have matching architectures. The same requirement applies to ARM64 and x64 on macOS.
