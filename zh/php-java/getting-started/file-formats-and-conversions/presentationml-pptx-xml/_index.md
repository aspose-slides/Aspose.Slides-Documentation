---
title: PresentationML (PPTX, XML)
type: docs
weight: 20
url: /zh/php-java/presentationml-pptx-xml/
---

{{% alert color="primary" %}} 

PresentationML 是一组基于 XML 的格式的名称，用于演示文档。Office OpenXML (OOXML) 是在 Microsoft Office 2007 应用程序中引入的基于 XML 的格式。Office OpenXML 是多种专业 XML 标记语言的容器格式。PresentationML 是 Microsoft Office PowerPoint 2007 用于存储文档的标记语言。

{{% /alert %}} 

## **在 Aspose.Slides for PHP via Java 中使用 PresentationML**
OOXML PresentationML 文档以 PPTX 文件形式出现，这些文件是压缩的 XML 包，遵循 [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/) 规范。Aspose.Slides for PHP via Java 广泛支持创建、读取、操作和写入 PresentationML 文档。此外，Aspose.Slides for PHP via Java 还能够将 PresentationML 文档导出为广泛使用的文档格式，如 PDF。这是可能的，因为 Aspose.Slides for PHP via Java 旨在全面处理演示文档，而 PresentationML 基本上将文档的内部演示存储为压缩的 XML 包。

**由 Aspose.Slides for PHP via Java 生成并在 Microsoft PowerPoint 中打开的 PPTX 文档**

![todo:image_alt_text](presentationml-pptx-xml_1.png)


**在 ZIP 中查看由 Aspose.Slides for PHP via Java 生成的相同 PPTX 文档**

![todo:image_alt_text](presentationml-pptx-xml_2.jpg)


## **PresentationML 是开放的，为什么使用 Aspose.Slides for PHP via Java?**
由于 PresentationML 是基于 XML 的，因此可能会构建应用程序来处理和生成 PresentationML 文档，使用 XML 类而不依赖于第三方类库，如 Aspose.Slides for PHP via Java。然而，在处理 PresentationML 文档时，使用 Aspose.Slides for PHP via Java 相较于 XML 类有几个优势。

OOXML 规范长达数千页，因此要正确处理 PresentationML 文档，您必须花费大量时间和精力去理解该格式。另一方面，使用 Aspose.Slides for PHP via Java，您只需使用类及其方法和属性来执行看似复杂的操作，而无需通过 XML 类实现这些操作。

使用 XML 类处理 PresentationML 文档时，一些 Aspose.Slides 提供的功能甚至无法实现：

- 将 PPT 文档导出为 PDF 格式。
- 将幻灯片渲染为 Java 框架支持的任何图像格式。
- 使用克隆功能自动从源演示文稿中复制母版。
- 对形状应用保护。

以下是一个包含单个幻灯片的 PresentationML 文档示例，该幻灯片包含文本框，文本为 “Hello World”。要使用 XML 类读取该文本，您必须编写一个能从以下片段解析此简单文本的程序。Aspose.Slides 会为您执行此操作。

**XML**

``` xml
<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<p:sld xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main" xmlns:r="http://schemas.openxmlformats.org/officeDocument/2006/relationships" xmlns:p="http://schemas.openxmlformats.org/presentationml/2006/main">
  <p:cSld>
    <p:spTree>
      <p:nvGrpSpPr>
        <p:cNvPr id="1" name=""/>
        <p:cNvGrpSpPr/>
        <p:nvPr/>
      </p:nvGrpSpPr>
      <p:grpSpPr>
        <a:xfrm>
          <a:off x="0" y="0"/>
          <a:ext cx="0" cy="0"/>
          <a:chOff x="0" y="0"/>
          <a:chExt cx="0" cy="0"/>
        </a:xfrm></p:grpSpPr><p:sp>
          <p:nvSpPr><p:cNvPr id="4" name="TextBox 3"/>
          <p:cNvSpPr txBox="1"/>
            <p:nvPr/>
          </p:nvSpPr>
          <p:spPr>
            <a:xfrm>
              <a:off x="2819400" y="2590800"/>
              <a:ext cx="1297086" cy="369332"/>
            </a:xfrm>
            <a:prstGeom prst="rect">
              <a:avLst/>
            </a:prstGeom>
            <a:noFill/>
          </p:spPr>
          <p:txBody>
            <a:bodyPr wrap="none" rtlCol="0">
              <a:spAutoFit/>
            </a:bodyPr>
            <a:lstStyle/>
            <a:p>
              <a:r>
                <a:rPr lang="en-US"/>
                <a:t>Hello World
                </a:t>
              </a:r>
              <a:endParaRPr lang="en-US"/>
            </a:p>
          </p:txBody>
        </p:sp>
    </p:spTree>
  </p:cSld>
  <p:clrMapOvr>
    <a:masterClrMapping/>
  </p:clrMapOvr>
</p:sld>
```php

```