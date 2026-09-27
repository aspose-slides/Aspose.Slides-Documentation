---
title: 安装
type: docs
weight: 70
url: /zh/python-net/installation/
keywords:
- 下载 Aspose.Slides
- 安装 Aspose.Slides
- 使用 Aspose.Slides
- Aspose.Slides 安装
- pip
- PyPI
- Windows
- Linux
- macOS
- Python
description: "在 Windows、Linux 和 macOS 上通过 pip 从 PyPI 安装 Aspose.Slides for Python via .NET，并安装 Linux 和 macOS 所需的本机库。"
---
## **概述**

本文说明如何在 Windows、Linux 和 macOS 上通过 .NET 安装 Aspose.Slides for Python。该软件包发布在[PyPI](https://pypi.org/project/aspose.slides/)并通过 pip 安装。它已包含所使用的 .NET 运行时，因此无需单独安装 .NET。在 Linux 和 macOS 上，该运行时需要操作系统可能未提供的本机库；下面的章节列出了这些库。

Aspose.Slides for Python via .NET 支持 Python 3.5 到 3.14。PyPI 提供 Windows（32 位和 64 位）、Linux（x86_64 和 ARM64）以及 macOS（Intel 和 Apple silicon）对应的包。

## **Windows**

在 Windows 上，使用 pip 安装软件包。无需其他库。

```bash
pip install aspose.slides
```

## **Linux**

在 Linux 上，软件包中包含的 .NET 运行时需要两个库：

- **libgdiplus**，Windows GDI+ 图形 API 的实现。若缺少该库，保存演示文稿时会出现错误 `The type initializer for 'Gdip' threw an exception`。
- **ICU**（International Components for Unicode）。若缺少该库，Python 进程在第一次调用 Aspose.Slides 时会终止，提示 `Couldn't find a valid ICU package installed on the system`。

在 Debian 和 Ubuntu 上，可使用 apt 安装这两项：

```bash
sudo apt-get update && sudo apt-get install -y libgdiplus libicu76
```

ICU 包的名称包含版本号：`libicu76` 适用于 Debian 13；Debian 12 使用 `libicu72`，Ubuntu 24.04 使用 `libicu74`。要查看系统中的包名，可运行：

```bash
apt-cache search --names-only '^libicu[0-9]+$'
```

然后在虚拟环境中安装软件包。当前的 Debian 和 Ubuntu 发行版中，系统 Python 不允许在虚拟环境外使用 `pip install`，会报错 `externally-managed-environment`。

```bash
sudo apt-get install -y python3-venv
python3 -m venv .venv
. .venv/bin/activate
pip install aspose.slides
```

在激活相同虚拟环境后运行脚本。如果使用发行版未管理的 Python（例如官方 `python` Docker 镜像中的 Python），也可以在没有虚拟环境的情况下运行 `pip install aspose.slides`。

演示文稿中使用的字体或合适的替代字体必须安装在系统中，才能在将幻灯片转换为 PDF 或图像时正确渲染文本。

## **macOS**

我们尚未验证在 macOS 上的安装。在 macOS 上，Aspose.Slides 需要以下前置条件：

- **Python with shared libraries**，即使用 `--enable-shared` 配置选项构建的 Python。如果通过[pyenv](https://github.com/pyenv/pyenv#homebrew-in-macos)安装 Python，请在安装某个 Python 版本时将环境变量 `PYTHON_CONFIGURE_OPTS` 设置为 `--enable-shared`。
- **The libpython library in a system library directory**。使用 pyenv 安装的 Python 会将其 libpython 库（例如 *libpython3.9.dylib*）放在 *~/.pyenv/versions* 下；请在 */usr/local/lib* 中为其创建符号链接。
- **libgdiplus**，Windows GDI+ 图形 API 的实现。Homebrew 提供 `mono-libgdiplus` 包。

随后使用 pip 安装软件包。

## **检查安装**

要检查安装是否成功，请将 [Create Presentations](/slides/zh/python-net/create-presentation/) 中的第一个示例保存为 *hello.py* 并运行 `python hello.py`。它会在当前文件夹中生成 *new_presentation.pptx*。

## **升级**

要将已安装的版本升级到最新版本，请在安装软件包的环境中运行以下命令：

```bash
pip install --upgrade aspose.slides
```

## **常见问题**

**我可以在虚拟环境中安装 Aspose.Slides 吗？**

可以。您可以在任何使用 pip 的 Python 虚拟环境中安装它。Linux 和 macOS 所需的本机库需要在系统层面安装，而不是在虚拟环境中。

**我可以在 Docker 容器中使用 Aspose.Slides 吗？**

可以。镜像必须包含与 Linux 系统相同的本机库——libgdiplus 和 ICU——以及演示文稿使用的字体。

**是否有免费版或试用限制？**

有。未提供许可证时，Aspose.Slides 以评估模式运行：会在每个保存的幻灯片上添加评估水印，并截断从演示文稿读取的文本。要移除这些限制，请使用有效的[license](/slides/zh/python-net/licensing/)。