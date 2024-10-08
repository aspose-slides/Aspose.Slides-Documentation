---
title: 系统要求
type: docs
weight: 60
url: /python-net/system-requirements/
---
Aspose.Slides for Python via .NET 不需要安装任何第三方产品，例如 Microsoft PowerPoint。Aspose.Slides 本身是一个用于创建、修改、转换和呈现各种格式文档的引擎，包括 Microsoft PowerPoint 演示文稿格式。

## 受支持的操作系统

Aspose.Slides for Python via .NET 支持安装了 Python 3.5 或更高版本的 Windows 64 位和 32 位、macOS、Linux 64 位操作系统。

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
                <li>还有其他</li>
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

## 目标 Linux 和 macOS 平台的系统要求

- GCC-6 运行时库（或更高版本）。
- [`libgdiplus`](https://github.com/mono/libgdiplus)：GDI+ API 的开源实现。
- .NET Core 运行时的依赖项。安装 .NET Core 运行时本身不是必需的。
- 对于 Python 3.5-3.7：需要 Python 的 `pymalloc` 构建。默认启用 `--with-pymalloc` Python 构建选项。通常，Python 的 `pymalloc` 构建在文件名中以 `m` 后缀标记。
- `libpython` 共享 Python 库。默认情况下，`--enable-shared` Python 构建选项是禁用的，一些 Python 发行版不包含 `libpython` 共享库。对于某些 Linux 平台，可以使用包管理器安装 `libpython` 共享库，例如：`sudo apt-get install libpython3.7`。常见问题是 `libpython` 库安装在与系统共享库的标准位置不同的位置。可以通过使用 Python 构建选项在编译 Python 时设置替代库路径来解决此问题，或者通过在系统共享库的标准位置创建指向 `libpython` 库文件的符号链接来解决此问题。通常，Python 3.5-3.7 的 `libpython` 共享库文件名为 `libpythonX.Ym.so.1.0`，或 Python 3.8 或更高版本的 `libpythonX.Y.so.1.0`（例如：libpython3.7m.so.1.0，libpython3.9.so.1.0）。  
