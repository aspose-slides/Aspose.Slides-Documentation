---
title: PresentationML (PPTX, XML)
type: docs
weight: 20
url: /zh/cpp/presentationml-pptx-xml/
---

## **关于 PresentationML**
PresentationML 是一个用于演示文档的基于 XML 的格式家族的名称。Office OpenXML（OOXML）是 Microsoft Office 2007 应用程序中引入的基于 XML 的格式。Office OpenXML 是一个容器格式，包含多个专门的基于 XML 的标记语言。PresentationML 是 Microsoft Office PowerPoint 2007 用于存储其文档的标记语言。
## **Aspose.Slides for C++ 中的 PresentationML**
OOXML PresentationML 文档以 PPTX 文件的形式存在，这些文件是按照 [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/) 规范打包的 XML 文件。Aspose.Slides for C++ 广泛支持创建、读取、操作和写入 PresentationML 文档。此外，Aspose.Slides for C++ 能够将 PresentationML 文档导出为 PDF、TIFF 和 XPS 等不同的广泛使用的文档格式。之所以能够这样，是因为 Aspose.Slides for C++ 的设计旨在全面处理演示文档，而 PresentationML 基本上将文档的内部演示保留为压缩的 XML 包。

## **PresentationML 是开放的，为什么使用 Aspose.Slides for C++**
由于 PresentationML 是基于 XML 的，因此通过使用 XML 类构建处理和生成 PresentationML 文档的应用程序是完全可能的，而不依赖于像 Aspose.Slides for C++ 这样的第三方类库。然而，在处理 PresentationML 文档时，使用 Aspose.Slides for C++ 相对于 XML 类有几个优势。

OOXML 规范的长度达到几千页。这意味着，为了正确处理 PresentationML 文档，您将不得不花费大量的时间和精力来理解这些文档的格式。另一方面，使用 Aspose.Slides for C++ 时，您只需使用相关的类及其各自的方法/属性来执行操作，这些操作通过 XML 类执行时看起来相当复杂。

以下是一些通过 XML 类处理 PresentationML 文档时甚至无法获得的功能：

- 将 PPT 文档导出为 PDF、TIFF、XPS 格式
- 将 PPT 文档中的幻灯片导出为 SVG 格式
- 将幻灯片呈现为 C++ 框架支持的任何图像格式
- 使用克隆功能自动复制源演示文稿中的母版
- 对形状应用保护

让我们以一个包含一张幻灯片和一个包含 "Hello World" 文本的文本框的 PresentationML 文档为例。为了通过 XML 类读取文本，您必须编写一个程序来解析以下片段中的简单文本：
## **示例**


``` cpp

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