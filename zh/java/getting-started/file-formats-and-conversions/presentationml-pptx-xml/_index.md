---
title: PresentationML (PPTX, XML)
type: docs
weight: 20
url: /java/presentationml-pptx-xml/
---

{{% alert color="primary" %}} 

PresentationML 是一系列基于 XML 的演示文档格式的名称。Office OpenXML (OOXML) 是在 Microsoft Office 2007 应用程序中引入的基于 XML 的格式。Office OpenXML 是一个容器格式，用于多种专用的基于 XML 的标记语言。PresentationML 是 Microsoft Office PowerPoint 2007 用于存储文档的标记语言。

{{% /alert %}} 

## **在 Aspose.Slides for Java 中使用 PresentationML**
OOXML PresentationML 文档以 PPTX 文件的形式出现，压缩的 XML 包符合 [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/) 规范。Aspose.Slides for Java 广泛支持创建、读取、操作和编写 PresentationML 文档。此外，Aspose.Slides for Java 还能够将 PresentationML 文档导出为广泛使用的文档格式，如 PDF。这是因为 Aspose.Slides for Java 的设计旨在全面处理演示文档，而 PresentationML 基本上以压缩的 XML 包形式保存文档的内部表示。

**由 Aspose.Slides for Java 生成并在 Microsoft PowerPoint 中打开的 PPTX 文档** 

![todo:image_alt_text](presentationml-pptx-xml_1.png)


**在 ZIP 中查看由 Aspose.Slides for Java 生成的相同 PPTX 文档** 

![todo:image_alt_text](presentationml-pptx-xml_2.jpg)


## **PresentationML 是开放的，为什么使用 Aspose.Slides for Java?**
由于 PresentationML 是基于 XML 的，因此可以使用 XML 类构建应用程序来处理和生成 PresentationML 文档，而无需依赖如 Aspose.Slides for Java 这样的第三方类库。然而，在处理 PresentationML 文档时，使用 Aspose.Slides for Java 相对于 XML 类有几个优势。

OOXML 规范长达几千页，因此为了正确处理 PresentationML 文档，您需要花费大量时间和精力来理解该格式。另一方面，使用 Aspose.Slides for Java，您只需使用类及其方法和属性来执行操作，这在通过 XML 类执行时看起来复杂。

一些 Aspose.Slides 提供的功能在通过 XML 类处理 PresentationML 文档时甚至不可用：

- 将 PPT 文档导出为 PDF 格式。
- 将幻灯片渲染为 Java 框架支持的任何图像格式。
- 使用克隆功能自动从源演示文稿中复制母版。
- 对形状应用保护。

下面是一个包含文本框且文本为“Hello World”的单个幻灯片的 PresentationML 文档示例。要使用 XML 类读取此文本，您必须编写一个程序来解析以下片段中的简单文本。Aspose.Slides 为您完成了此操作。

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
```