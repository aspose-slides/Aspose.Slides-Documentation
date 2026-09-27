---
title: 安装
type: docs
weight: 70
url: /zh/python-java/installation/
keywords:
- 下载 Aspose.Slides
- 安装 Aspose.Slides
- Aspose.Slides 安装
- Python
- Java
- JPype
- Windows
- macOS
- Linux
description: "在 Windows、Linux 或 macOS 上为 Python via Java 安装 Aspose.Slides，配置 Java 和 JPype，并使用可运行的示例验证设置。"
---
Aspose.Slides for Python via Java 可以在 Windows、Linux 和 macOS 上运行。它使用 JPype 从 Python 访问 Java 库。无需 Microsoft PowerPoint。

## **先决条件**

在安装 Python 包之前，请安装符合[系统要求](/slides/zh/python-java/system-requirements/)的 Python 和 JDK。该页面列出了兼容的版本、架构要求以及构建 JPype 所需的任何依赖项。

将 `JAVA_HOME` 设置为 JDK 的安装目录，而不是其 `bin` 子目录，并将 JDK 的 `bin` 目录添加到 `PATH`。更改环境变量后打开一个新终端。

## **从 PyPI 安装**

在终端中运行以下命令，而不是在 Python 交互提示符下运行。创建项目目录并使用虚拟环境，以使包与其他项目隔离。

### **Windows**

在 `PATH` 中可以通过 `python` 调用您选择的 Python 解释器时，在命令提示符下运行以下命令：

```bat
mkdir slides-example
cd slides-example
python -m venv .venv
.venv\Scripts\activate.bat
```

### **Linux 和 macOS**

在 `PATH` 中可以通过 `python3` 调用您选择的 Python 版本时，在 Bash 或 zsh 中运行以下命令：

```bash
mkdir slides-example
cd slides-example
python3 -m venv .venv
source .venv/bin/activate
```

在 Debian 或 Ubuntu 上，如果由于缺少 `ensurepip` 导致创建环境失败，请使用 `sudo apt-get install python3-venv` 安装 `python3-venv` 包，然后重新运行环境创建命令。单独安装的 Python 版本可能需要对应的特定版本 `venv` 包。

### **安装包**

在虚拟环境激活的情况下，安装 JPype 和 Aspose.Slides：

```sh
python -m pip install --upgrade pip
python -m pip install JPype1 aspose-slides-java
```

使用 `python -m pip` 可以确保针对运行您应用程序的解释器安装包。

要更新已有的 Aspose.Slides 安装，请在相同环境中运行 `python -m pip install --upgrade aspose-slides-java`。

## **从 ZIP 存档安装**

您也可以从[Aspose.Slides 下载页面](https://releases.aspose.com/slides/zh/python-java/)使用该库：

1. 如[先决条件](#prerequisites)所述，安装 Python 和 Java。
2. 按照上述说明创建并激活虚拟环境。
3. 使用 `python -m pip install JPype1` 安装 JPype。
4. 下载并解压 Aspose.Slides for Python via Java 的 ZIP 存档。
5. 找到解压后的 `asposeslides` 包目录。保留其内容，包括 `lib` 目录和 JAR 文件在一起。
6. 将下一节的 `example.py` 放置在 `asposeslides` 目录旁边，以便 Python 能导入该包。存档中已包含一个位于 `asposeslides` 旁的 `example.py`；用下面的文件替换它。

## **验证安装**

将以下代码保存为 `example.py`。它会创建一个带文本框的演示文稿，并将其保存为当前工作目录下的 `out.pptx`。

```python
import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import Presentation, SaveFormat, ShapeType

    presentation = Presentation()
    try:
        slide = presentation.getSlides().get_Item(0)
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 500, 80)
        shape.getTextFrame().setText("Aspose.Slides is ready!")
        presentation.save("out.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    jpype.shutdownJVM()
```

在激活的虚拟环境中，从包含 `example.py` 的目录运行示例：

```sh
python example.py
```

`asposeslides` 的导入会在 JVM 启动前注册捆绑的 Java 库。启动 JVM 后再导入 `asposeslides.api`，并在关闭 JVM 前释放演示文稿资源。

{{% alert color="info" title="Note" %}}
如果没有许可证，输出中会包含评估水印。请参阅[评估 Aspose.Slides](/slides/zh/python-java/evaluate-aspose-slides/)了解评估限制和临时许可证信息。
{{% /alert %}}

## **常见问题**

**为什么 Python 报告找不到或加载不了 JVM？**

检查 `JAVA_HOME` 是否指向与您的 Python 和 JPype 安装兼容的 JDK，参见[系统要求](/slides/zh/python-java/system-requirements/)。有关其他检查，请查看[JPype 安装故障排查指南](https://jpype.readthedocs.io/en/latest/install.html)。

**为什么 Python 在安装后报告缺少 `asposeslides`？**

该包可能已为不同的 Python 解释器安装。激活用于安装的虚拟环境并运行 `python -m pip show aspose-slides-java`。对于 ZIP 安装，请确保 `asposeslides` 目录与您的脚本并列，或在 Python 的模块搜索路径中可用。

**我可以在笔记本中重复运行示例吗？**

该示例旨在用于独立的 Python 进程。在将其改为在笔记本中重复执行之前，请参阅[限制和 API 差异](/slides/zh/python-java/limitations-and-api-differences/#import-the-library)了解 JVM 生命周期和笔记本使用指南。

**为什么 pip 因 `CERTIFICATE_VERIFY_FAILED` 失败？**

如果您的网络使用 HTTPS 检查代理，pip 必须信任其证书颁发机构。使用 pip 的 `--cert` 选项或 `PIP_CERT` 环境变量配置受信任的 CA 包，具体请参阅[pip HTTPS 证书说明](https://pip.pypa.io/en/stable/topics/https-certificates/)。所需配置取决于您的网络和 pip 版本。