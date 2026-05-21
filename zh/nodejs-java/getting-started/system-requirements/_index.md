---
title: 系统要求
type: docs
weight: 60
url: /zh/nodejs-java/system-requirements/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "了解 Aspose.Slides for Node.js via Java 的系统要求。确保在 Windows、Linux 和 macOS 上无缝支持 PowerPoint 和 OpenDocument。"
---
## **介绍**

Aspose.Slides for Node.js via Java 不需要安装任何第三方产品，例如 Microsoft PowerPoint。Aspose.Slides 本身是一个用于创建、修改、转换和渲染各种格式文档的引擎，包括 Microsoft PowerPoint 演示文稿格式。

## **支持的操作系统**

Aspose.Slides for Node.js via Java 支持运行 Java 运行时的任何 32 位或 64 位操作系统，包括但不限于：

### **Windows**
- Microsoft Windows 2003 Server ( x64, x86)
- Microsoft Windows 2008 Server ( x64, x86)
- Microsoft Windows 2012 Server ( x64, x86)
- Microsoft Windows 2012 R2 Server ( x64, x86)
- Microsoft Windows 2016 Server ( x64, x86)
- Microsoft Windows 2019 Server ( x64, x86)
- Microsoft Windows Vista ( x64, x86)
- Microsoft Windows XP ( x64, x86)
- Microsoft Windows 7 ( x64, x86)
- Microsoft Windows 8, 8.1 ( x64, x86)
- Microsoft Windows 10 ( x64, x86)

### **Linux**
- Linux (Ubuntu、CentOS 等)

### **Mac**
- Mac OS X

## **常见问题**

**是否需要安装 Microsoft PowerPoint 才能进行转换和渲染？**

不需要，PowerPoint 不是必需的；Aspose.Slides 是一个独立的引擎，用于[创建](/slides/zh/nodejs-java/create-presentation/)、修改、[转换](/slides/zh/nodejs-java/convert-presentation/)以及[渲染](/slides/zh/nodejs-java/convert-powerpoint-to-png/)演示文稿。

**正确渲染需要哪些字体？**

实际上，演示文稿中使用的字体或相应的[替代字体](/slides/zh/nodejs-java/font-substitution/)必须可用。为确保在 Linux/macOS 上的一致渲染，建议安装常用字体包。

**为什么自定义字体在 Linux 上渲染为回退或缺失的文本？**

如果字体文件的名称表条目不一致或已损坏，Linux 的字体匹配堆栈（FreeType/fontconfig）可能会选择无效记录，导致字体未解析。使用名称表记录已修正的字体版本或安装一致的替代字体即可解决此问题。