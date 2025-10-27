---
title: 系统要求
type: docs
weight: 60
url: /zh/python-net/system-requirements/
keywords:
- 系统要求
- 操作系统
- 安装
- 依赖项
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "了解 Aspose.Slides for Python via .NET 的系统要求。确保在 Windows、Linux 和 macOS 上无缝支持 PowerPoint 和 OpenDocument。"
---

## **简介**

Aspose.Slides for Python via .NET 不需要安装任何第三方产品，例如 Microsoft PowerPoint。Aspose.Slides 是一个用于创建、修改、转换和呈现各种格式文档（包括 Microsoft PowerPoint 演示文稿格式）的引擎。

## **支持的操作系统**

Aspose.Slides for Python 支持在安装了 Python 3.5 或更高版本的 Windows（32 位和 64 位）、macOS 和 64 位 Linux 系统上运行。

<table>  
    <tr>
        <td style="font-weight: bold; width:400px">操作系统</td>
        <td style="font-weight: bold; width:400px">版本</td>
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
                <li>和其他</li>
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

## **针对 Linux 和 macOS 平台的系统要求**

- GCC 6 运行时库（或更高）。
- [libgdiplus](https://github.com/mono/libgdiplus)，一个 GDI+ API 的开源实现。
- .NET Core Runtime 的依赖项。**不需要**安装 .NET Core Runtime 本身。
- 对于 Python 3.5–3.7：需要使用 `pymalloc` 构建的 Python。默认已启用 `--with-pymalloc` 构建选项。通常，`pymalloc` 构建的 Python 在文件名中带有 `m` 后缀。
- `libpython` 共享库。默认情况下，`--enable-shared` Python 构建选项是关闭的，某些 Python 发行版不包含 `libpython` 共享库。在某些 Linux 平台上，可以使用包管理器安装 `libpython` 共享库（例如 `sudo apt-get install libpython3.7`）。常见问题是 `libpython` 库被安装在非标准的共享库位置。可以通过在编译 Python 时使用构建选项设置替代库路径，或在系统的标准共享库位置创建指向 `libpython` 库文件的符号链接来解决此问题。通常，Python 3.5–3.7 的 `libpython` 共享库文件名为 `libpythonX.Ym.so.1.0`，而 Python 3.8 及以上则为 `libpythonX.Y.so.1.0`（例如 `libpython3.7m.so.1.0`、`libpython3.9.so.1.0`）。

## **常见问题**

**我需要安装 Microsoft PowerPoint 来进行转换和渲染吗？**

不需要，PowerPoint 不是必需的；Aspose.Slides 是一个独立的引擎，用于[创建](/slides/zh/python-net/create-presentation/)、修改、[转换](/slides/zh/python-net/convert-presentation/)和[渲染](/slides/zh/python-net/convert-powerpoint-to-png/)演示文稿。

**机器上是否需要特定的 .NET 版本（Core/5+/6+）？**

不需要安装 .NET Runtime 本身，但必须在 Linux/macOS 上存在其依赖项。这意味着系统应包含通常作为 .NET 依赖项安装的包，而无需完整安装运行时。

**渲染正确需要哪些字体？**

实际使用的演示文稿中的字体或相应的[替代字体](/slides/zh/python-net/font-substitution/)必须可用。为确保在 Linux/macOS 上渲染一致，建议安装常用字体包。