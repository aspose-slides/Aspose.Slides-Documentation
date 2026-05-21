---
title: 系统要求
type: docs
weight: 80
url: /zh/cpp/system-requirements/
keywords:
- 系统需求
- 操作系统
- 安装
- 依赖项
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "了解 Aspose.Slides for C++ 的系统要求。确保在 Windows、Linux 和 macOS 上实现无缝的 PowerPoint 和 OpenDocument 支持。"
---
## **介绍**

Aspose.Slides 不需要安装 Microsoft PowerPoint，因为 Aspose.Slides 是一个独立的 Microsoft PowerPoint 文档创建、转换、页面布局和渲染引擎。

## **受支持的操作系统**
Aspose.Slides for C++ 是一个原生 C++ 库。Aspose.Slides for C++ 支持以下 64 位和 32 位操作系统及平台：

### **Windows**
- Microsoft Windows Server 2008 (x64, x86)
- Microsoft Windows Server 2012 (x64, x86)
- Microsoft Windows Server 2012 R2 (x64, x86)
- Microsoft Windows Server 2016 (x64, x86)
- Microsoft Windows Server 2019 (x64, x86)
- Microsoft Windows XP (x64, x86)
- Microsoft Windows 7 (x64, x86)
- Microsoft Windows 8, 8.1 (x64, x86)
- Microsoft Windows 10 (x64, x86)

### **Linux**
- Ubuntu 16.04 或更高版本的操作系统。
- CentOS 8 或更高版本。
- Fedora 24 或更高版本。
- 其他带有 glibc 2.23 或更高版本的 Linux x86_64。

### **macOS**
- macOS Monterey 12.1 或更高版本。

## **开发环境**
在为 Windows、Linux 或 macOS 开发应用程序时，可以使用 Aspose.Slides for C++。

### **Windows**
- Microsoft Visual Studio 2017 或更高版本。
- CMake 3.18 或更高版本。

### **Linux**
- Clang 3.9 或更高版本。
- GCC 6.1 或更高版本。
- CMake 3.18 或更高版本。

### **macOS**
- Xcode 13.4 或更高版本。

## **FAQ**

**我是否需要安装 Microsoft PowerPoint 才能进行转换和渲染？**

不，需要安装 PowerPoint；Aspose.Slides 是一个独立的引擎，用于[创建](/slides/zh/cpp/create-presentation/)、修改、[转换](/slides/zh/cpp/convert-presentation/)和[渲染](/slides/zh/cpp/convert-powerpoint-to-png/)演示文稿。

**正确渲染需要哪些字体？**

实际上，演示文稿中使用的字体或合适的[替代字体](/slides/zh/cpp/font-substitution/)必须可用。为确保在 Linux/macOS 上渲染一致，建议安装常见的字体包。

**为什么在 Linux 上自定义字体会显示为回退或缺失文本？**

如果字体文件的名称表条目不一致或损坏，Linux 的字体匹配堆栈（FreeType/fontconfig）可能会选择无效记录，导致字体无法解析。使用名称表已修正的字体版本或安装一致的替代字体即可解决此问题。