---
title: How to Run Aspose.Slides in Docker
linktitle: Aspose.Slides in Docker
type: docs
weight: 150
url: /python-net/how-to-run-aspose-slides-in-docker/
keywords:
- Aspose.Slides in Docker
- Docker container
- Dockerfile
- Linux
- libgdiplus
- ICU
- OpenSSL
- fonts
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Run Aspose.Slides for Python via .NET in Docker: a working Dockerfile, the native libraries the package needs, font setup, and licensing inside a container."
---

## **Overview**

Aspose.Slides for Python via .NET runs in Linux containers, but the package is a Python wrapper
around a bundled .NET Core 3.1 runtime. That runtime needs three native libraries that slim Python
images do not ship, and it is particular about their versions. This article gives a Dockerfile that
works, explains why each dependency is there, and shows how to add fonts and a license.

## **A working Dockerfile**

```dockerfile
FROM python:3.11-slim-bullseye

RUN apt-get update && apt-get install -y --no-install-recommends \
        libgdiplus \
        libicu67 \
        libfontconfig1 \
        fonts-dejavu-core \
    && rm -rf /var/lib/apt/lists/*

RUN pip install --no-cache-dir aspose.slides

WORKDIR /app
COPY app.py .
CMD ["python", "app.py"]
```

`app.py`:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    shape.text_frame.text = "Created inside a Docker container"
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("output.pdf", slides.export.SaveFormat.PDF)
```

Build and run:

```bash
docker build -t aspose-slides-python .
docker run --rm aspose-slides-python
```

## **Why the base image is Debian 11**

The `aspose.slides` wheel bundles a **.NET Core 3.1** runtime, and that runtime predates the library
versions shipped by current Debian releases. On Debian 12 and 13 the container builds successfully
and then fails at the first `Presentation()` call:

```
Process terminated. Couldn't find a valid ICU package installed on the system.
```

The message is misleading — ICU *is* installed on those images, but it is ICU 72 or 76, and .NET
Core 3.1 only recognises older major versions. Debian 12 additionally ships OpenSSL 3, which
produces a second failure:

```
No usable version of libssl was found
```

`python:3.11-slim-bullseye` is Debian 11, which provides both versions the bundled runtime expects:

| Package | Version on Debian 11 | Why it is needed |
|---|---|---|
| `libgdiplus` | 6.0.4 | GDI+ implementation used for rendering shapes, text, and images |
| `libicu67` | 67.1 | Globalization data. Newer majors are not recognised by .NET Core 3.1 |
| `libssl1.1` | 1.1.1w | Cryptography. Preinstalled on Debian 11; absent from Debian 12+ |
| `libfontconfig1` | — | Font discovery |

`libssl1.1` is already present in the base image, so it does not need to be listed in `apt-get
install`.

If you must use a newer base image, set `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=1` to bypass the ICU
requirement. This disables culture-specific formatting and does **not** solve the OpenSSL problem, so
Debian 11 remains the simpler choice.

## **Fonts**

Slim images contain no fonts at all. Without at least one font installed, text renders as blank boxes
in PDF, image, and HTML output. `fonts-dejavu-core` is a small general-purpose starting point.

To match a presentation's intended appearance, copy the fonts it uses into the image and point
Aspose.Slides at them:

```dockerfile
COPY fonts/ /usr/share/fonts/truetype/custom/
RUN fc-cache -f
```

```py
import aspose.slides as slides

slides.FontsLoader.load_external_fonts(["/usr/share/fonts/truetype/custom/"])
```

## **Licensing inside a container**

Do not build the license file into the image — anyone who pulls the image gets the license. Mount it
at run time instead:

```bash
docker run --rm -v /path/on/host:/license aspose-slides-python
```

```py
import aspose.slides as slides

license = slides.License()
license.set_license("/license/Aspose.Slides.Python.NET.lic")
```

Without a license the library runs in evaluation mode, which adds a watermark and limits the number
of slides processed. See [Licensing](/slides/python-net/licensing/) for details.

## **Memory**

Rendering to PDF or images is more memory-hungry than reading a file. Containers with tight memory
limits can be terminated by the OOM killer partway through a conversion, which usually surfaces as
the process disappearing without a Python traceback. If that happens, raise the container's memory
limit before investigating the code.
