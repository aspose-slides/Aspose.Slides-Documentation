---
title: 系统要求
type: docs
weight: 80
url: /zh/java/system-requirements/
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
- Java
- Aspose.Slides
description: "了解 Aspose.Slides for Java 的系统要求。确保在 Windows、Linux 和 macOS 上实现无缝的 PowerPoint 和 OpenDocument 支持。"
---
## **概述**
Aspose.Slides for Java 不需要安装 Microsoft PowerPoint，因为 Aspose.Slides 本身就是一个 Microsoft PowerPoint 文档创建、转换、页面布局和渲染引擎。
## **受支持的操作系统**
Aspose.Slides for Java 支持运行 Java 运行时的任何 32 位或 64 位操作系统，包括但不限于：
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
- Linux (Ubuntu, OpenSUSE, CentOS 等)

### **Mac**
- Mac OS X

## **受支持的 Java 版本**
Aspose.Slides for Java 支持 J2SE 6.0 (Java 1.6) 及更高版本。

## **常见问题**

**是否需要安装 Microsoft PowerPoint 才能进行转换和渲染？**

不需要，PowerPoint 不是必需的；Aspose.Slides 是一个独立的引擎，用于[创建](/slides/zh/java/create-presentation/)、修改、[转换](/slides/zh/java/convert-presentation/)和[渲染](/slides/zh/java/convert-powerpoint-to-png/)演示文稿。

**正确渲染需要哪些字体？**

实际使用中，需要演示文稿中使用的字体或相应的[替代字体](/slides/zh/java/font-substitution/)可用。为确保在 Linux/macOS 上渲染一致，建议安装常用字体包。

**为什么自定义字体在 Linux 上会渲染为回退或缺失的文字？**

如果字体文件的 name-table 条目不一致或损坏，Linux 的字体匹配栈（FreeType/fontconfig）可能会选择无效记录，从而导致字体未解析。使用修正了 name-table 记录的字体版本或安装一致的替代品即可解决此问题。