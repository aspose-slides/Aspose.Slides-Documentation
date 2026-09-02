---
title: 如何在 Docker 中运行 Aspose.Slides
linktitle: Docker 中的 Aspose.Slides
type: docs
weight: 150
url: /zh/python-net/how-to-run-aspose-slides-in-docker/
keywords:
- Docker 中的 Aspose.Slides
- Docker 容器
- Dockerfile
- Linux
- libgdiplus
- ICU
- OpenSSL
- 字体
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "在 Docker 中运行 Aspose.Slides for Python via .NET：一个可用的 Dockerfile、包所需的本机库、字体设置以及容器内的许可证。"
---
## **概述**

Aspose.Slides for Python via .NET 在 Linux 容器中运行，但该软件包是围绕打包的 .NET Core 3.1 运行时的 Python 包装器。该运行时需要三个原生库，而精简的 Python 镜像并未包含这些库，并且对它们的版本有特定要求。本文提供了可工作的 Dockerfile，解释每个依赖项的来源，并展示如何添加字体和许可证。

## **可工作的 Dockerfile**

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

`app.py`：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    shape.text_frame.text = "Created inside a Docker container"
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("output.pdf", slides.export.SaveFormat.PDF)
```

构建并运行：

```bash
docker build -t aspose-slides-python .
docker run --rm aspose-slides-python
```

## **为什么基础镜像是 Debian 11**

`aspose.slides` wheel 打包了 **.NET Core 3.1** 运行时，而该运行时早于当前 Debian 发行版所提供的库版本。 在 Debian 12 和 13 上容器能够成功构建，但在第一次调用 `Presentation()` 时会失败：

```
Process terminated. Couldn't find a valid ICU package installed on the system.
```

该信息具有误导性——这些镜像中确实已安装 ICU，只是版本是 72 或 76，而 .NET Core 3.1 只能识别较旧的主版本。Debian 12 另外还提供 OpenSSL 3，导致第二个错误：

```
No usable version of libssl was found
```

`python:3.11-slim-bullseye` 是基于 Debian 11 的镜像，提供了捆绑运行时所期待的两个版本：

| 包 | Debian 11 上的版本 | 需要原因 |
|---|---|---|
| `libgdiplus` | 6.0.4 | 用于渲染形状、文本和图像的 GDI+ 实现 |
| `libicu67` | 67.1 | 区域化数据。更新的主版本 .NET Core 3.1 不识别 |
| `libssl1.1` | 1.1.1w | 加密库。已预装在 Debian 11 上，Debian 12 及以上缺失 |
| `libfontconfig1` | — | 字体发现 |

`libssl1.1` 已在基础镜像中存在，因此不需要在 `apt-get install` 中列出。

如果必须使用更新的基础镜像，可设置 `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=1` 以绕过 ICU 要求。此设置会禁用特定文化的格式化，但 **不能** 解决 OpenSSL 问题，所以 Debian 11 仍是更简单的选择。

## **字体**

精简镜像根本不包含任何字体。若未安装至少一种字体，文本在 PDF、图像和 HTML 输出中会显示为空白框。`fonts-dejavu-core` 是一个小巧且通用的起点。

为了匹配演示文稿的预期外观，可将演示文稿使用的字体复制到镜像中，并让 Aspose.Slides 使用这些字体：

```dockerfile
COPY fonts/ /usr/share/fonts/truetype/custom/
RUN fc-cache -f
```

```py
import aspose.slides as slides

slides.FontsLoader.load_external_fonts(["/usr/share/fonts/truetype/custom/"])
```

## **容器内的许可证**

不要将许可证文件构建进镜像——任何拉取镜像的人都能获得许可证。应在运行时挂载：

```bash
docker run --rm -v /path/on/host:/license aspose-slides-python
```

```py
import aspose.slides as slides

license = slides.License()
license.set_license("/license/Aspose.Slides.Python.NET.lic")
```

未提供许可证时，库会以评估模式运行，在输出中添加水印并限制可处理的幻灯片数量。详情请参阅[许可证](/slides/zh/python-net/licensing/)。

## **内存**

渲染为 PDF 或图像比读取文件更消耗内存。内存限制严格的容器可能在转换过程中被 OOM killer 终止，表现为进程消失且没有 Python 堆栈信息。如果出现这种情况，请先提升容器的内存限制，再调查代码。