---
title: PresentationML (PPTX, XML)（历史）
type: docs
weight: 20
url: /zh/java/presentationml-pptx-xml/
keywords:
- PresentationML
- PPTX
- Office Open XML
- 历史
- Java
- Aspose.Slides
description: "历史：Aspose.Slides for Java 中对 PresentationML (PPTX) 格式的较早概述，保留供现有链接使用。当前支持的格式列表请参见 Supported File Formats。"
---
{{% alert color="info" title="Note" %}}

这是一个历史页面，保留用于现有链接。它并未描述 Aspose.Slides for Java 的当前版本。有关 Aspose.Slides for Java 加载、导入、保存和呈现的格式以及每种格式的 API，请参阅[Supported File Formats](/slides/zh/java/supported-file-formats/)。要比较 PPTX 与 PPT，请参阅[Understanding the Difference: PPT vs PPTX](/slides/zh/java/ppt-vs-pptx/).

{{% /alert %}}

{{% alert color="info" title="Note" %}}

PresentationML 是一族用于演示文稿的基于 XML 的格式的名称。Office OpenXML（OOXML）是 Microsoft Office 2007 应用程序引入的基于 XML 的格式。Office OpenXML 是用于多种专用基于 XML 的标记语言的容器格式。PresentationML 是 Microsoft Office PowerPoint 2007 用于存储文档的标记语言。

{{% /alert %}}

## **Aspose.Slides for Java 中的 PresentationML**

OOXML PresentationML 文档以 PPTX 文件形式存在，即遵循[OOXML ECMA-376](https://ecma-international.org/publications-and-standards/standards/ecma-376/)规范的压缩 XML 包。Aspose.Slides for Java 广泛支持创建、读取、操作和写入 PresentationML 文档。此外，Aspose.Slides for Java 还能将 PresentationML 文档导出为广泛使用的文档格式，如 PDF。这得益于 Aspose.Slides for Java 的设计目标是全面处理演示文稿，而 PresentationML 基本上以压缩 XML 包的形式保存文档的内部表示。

**由 Aspose.Slides for Java 生成并在 Microsoft PowerPoint 中打开的 PPTX 文档**

![由 Aspose.Slides for Java 生成并在 Microsoft PowerPoint 中打开的 PPTX 文档](presentationml-pptx-xml_1.png)


**在 ZIP 中查看由 Aspose.Slides for Java 生成的相同 PPTX 文档**

![相同的 PPTX 文档作为 ZIP 包查看](presentationml-pptx-xml_2.jpg)


## **PresentationML 是开放的，为什么要使用 Aspose.Slides for Java？**
由于 PresentationML 基于 XML，完全可以使用 XML 类构建处理和生成 PresentationML 文档的应用程序，而无需依赖诸如 Aspose.Slides for Java 的第三方类库。然而，在处理 PresentationML 文档时，使用 Aspose.Slides for Java 相比 XML 类有若干优势。

OOXML 规范有数千页之多，要正确处理 PresentationML 文档，你必须花费大量时间和精力去了解该格式。相反，使用 Aspose.Slides for Java 时，只需使用类及其方法和属性即可执行通过 XML 类实现时看起来很复杂的操作。

通过 XML 类处理 PresentationML 文档时，Aspose.Slides 提供的一些功能甚至不可用：

- 将 PPT 文档导出为 PDF 格式。
- 将幻灯片渲染为 Java 框架支持的任意图像格式。
- 使用克隆功能自动从源演示文稿复制母版。
- 对形状应用保护。

以下是一个示例 PresentationML 文档，其中包含一个幻灯片，幻灯片内有一个文本框，文本为 “Hello World”。要使用 XML 类读取该文本，你必须编写程序从以下片段中解析此简单文本。Aspose.Slides 会为你完成此操作。

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