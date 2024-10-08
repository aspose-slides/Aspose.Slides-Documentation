---
title: 将PPTX转换为PPT的C++
linktitle: 将PPTX转换为PPT
type: docs
weight: 21
url: /cpp/convert-pptx-to-ppt/
keywords: "C++ 将PPTX转换为PPT, 转换PowerPoint演示文稿, PPTX到PPT, Python, Aspose.Slides"
description: "在C++中将PowerPoint PPTX转换为PPT"
---

## **概述**

本文解释了如何使用C++将PPTX格式的PowerPoint演示文稿转换为PPT格式。以下主题将被涵盖。

- 在C++中将PPTX转换为PPT

## **C++ 将PPTX转换为PPT**

有关将PPTX转换为PPT的C++示例代码，请参阅以下部分，即[将PPTX转换为PPT](#convert-pptx-to-ppt)。它只需加载PPTX文件并以PPT格式保存。通过指定不同的保存格式，您还可以将PPTX文件保存为其他多种格式，如PDF、XPS、ODP、HTML等，具体内容可参见这些文章。

- [C++ 将PPTX转换为PDF](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-pdf/)
- [C++ 将PPTX转换为XPS](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-xps/)
- [C++ 将PPTX转换为HTML](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-html/)
- [C++ 将PPTX转换为ODP](https://docs.aspose.com/slides/cpp/save-presentation/)
- [C++ 将PPTX转换为图像](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-png/)

## **将PPTX转换为PPT**
要将PPTX转换为PPT，只需将文件名和保存格式传递给[**Presentation**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/)类的**Save**方法。下面的C++代码示例使用默认选项将Presentation从PPTX转换为PPT。

```cpp
// 加载PPTX。
SharedPtr<Presentation> prs = MakeObject<Presentation>(u"sourceFile.pptx");

// 以PPT格式保存。
prs->Save(u"convertedFile.ppt", Aspose::Slides::Export::SaveFormat::Ppt);
```