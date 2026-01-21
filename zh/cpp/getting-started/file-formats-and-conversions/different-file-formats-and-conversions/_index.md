---
title: 不同的文件格式和转换
type: docs
weight: 50
url: /zh/cpp/different-file-formats-and-conversions/
---

## **Microsoft PowerPoint (PPT)**
### **关于 PPT**
[PPT](https://en.wikipedia.org/wiki/Microsoft_PowerPoint) 是一种演示文稿文件格式，可由不同版本的 Microsoft PowerPoint 创建、读取、操作和写入。这是 Microsoft 开发的演示文稿的二进制格式。
### **C++ 版 Aspose.Slides 中的 PPT**
Aspose.Slides for C++ 能读取以下软件创建的 PPT 文件。

- Microsoft PowerPoint 97
- Microsoft PowerPoint 2000
- Microsoft PowerPoint XP
- Microsoft PowerPoint 2003

同样，由 Aspose.Slides for C++ 创建的 PPT 文件也可以被上述软件读取。
### **对 PPT 的全面支持**
Aspose.Slides for C++ 提供几乎所有与 PPT 文档文件格式相关的功能支持。它不仅涵盖了不同 Microsoft PowerPoint 版本提供的基本/高级 PPT 文档操作功能，还包括一些 Microsoft PowerPoint 本身不支持的功能。使用 Aspose.Slides for C++ API 库的主要优势在于处理这些功能的便利性。

除了创建、读取和写入 PPT 文档文件的基本任务外，Aspose.Slides for C++ 还提供了以下多项功能：

- 将其他 MS Office 文件格式导入为 PPT 文档中的 OLE 对象。
- 将 PPT 文档导出为 PDF、TIFF、XPS 格式。
- 将 PPT 文档中的幻灯片导出为 SVG 格式。
- 将幻灯片渲染为 C++ 框架支持的任意图像格式。
- 设置 PPT 文档中幻灯片的尺寸。
- 管理形状的动画效果。
- 管理幻灯片放映。
- 格式化幻灯片中的文本。
- 从 PPT 文档中扫描文本。
- 处理幻灯片中的表格。
- 使用克隆功能自动复制母版。

由 Aspose.Slides for C++ 生成并在 Microsoft PowerPoint 中打开的 PPT 文件
## **PresentationML（PPTX，XML）**
### **关于 PresentationML**
PresentationML 是一系列基于 XML 的演示文稿文件格式的名称。Office OpenXML（OOXML）是 Microsoft Office 2007 应用程序引入的基于 XML 的格式。Office OpenXML 是一种容器格式，包含多个专用的基于 XML 的标记语言。PresentationML 是 Microsoft Office PowerPoint 2007 用于存储文档的标记语言。
### **C++ 版 Aspose.Slides 中的 PresentationML**
OOXML PresentationML 文档以 PPTX 文件形式出现，PPTX 是遵循 [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/) 规范的压缩 XML 包。Aspose.Slides for C++ 广泛支持创建、读取、操作和写入 PresentationML 文档。此外，Aspose.Slides for C++ 能将 PresentationML 文档导出为多种常用文档格式，如 PDF、TIFF 和 XPS。这得益于 Aspose.Slides for C++ 旨在全面处理演示文稿，并且 PresentationML 本质上是以压缩 XML 包的形式保存文档内部结构。

由 Aspose.Slides for C++ 生成并在 Microsoft PowerPoint 中打开的 PPTX 文档

在压缩文件浏览器中查看由 Aspose.Slides for C++ 生成的 PPTX 文档
### **PresentationML 是开源的，为什么要使用 Aspose.Slides for C++**
由于 PresentationML 基于 XML，完全可以使用 XML 类自行构建处理和生成 PresentationML 文档的应用，而无需依赖像 Aspose.Slides for C++ 这样的第三方类库。然而，在使用 XML 类处理 PresentationML 文档时，使用 Aspose.Slides for C++ 仍有多项优势。

OOXML 规范篇幅极长，达数千页。这意味着若要正确处理 PresentationML 文档，需要花费大量时间和精力去理解其格式。相反，使用 Aspose.Slides for C++ 时，只需调用相应的类及其方法/属性即可完成那些通过 XML 类实现时相当复杂的操作。

以下功能即使使用 XML 类处理 PresentationML 文档也无法实现：

- 将 PPT 文档导出为 PDF、TIFF、XPS 格式
- 将 PPT 文档中的幻灯片导出为 SVG 格式
- 将幻灯片渲染为 C++ 框架支持的任意图像格式
- 使用克隆功能自动从源演示文稿复制母版
- 对形状应用保护

下面以一个包含单张幻灯片、其中有一个文本框写有“Hello World”文本的 PresentationML 文档为例。若要通过 XML 类读取该文本，需要编写程序从以下片段中解析此简单文本：

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

## **PPT 转 PPTX 转换**
### **关于转换**
Aspose.Slides 现在亦支持将 PPT 转换为 PPTX。
### **转换中支持的功能**
Aspose.Slides for C++ 为将 PPT 文档格式的演示转换为 PPTX 文件格式的演示提供了部分支持。由于此转换功能刚在 Aspose.Slides for C++ 中引入，当前功能仍然有限，仅适用于简单的演示文稿。使用 Aspose.Slides for C++ API 库进行 PPT 到 PPTX 的转换的主要优势在于 API 的易用性，可快速实现目标。请前往 this[link]() 的代码片段章节了解详细信息。以下部分清晰说明了在将 PPT 格式演示转换为 PPTX 格式演示时哪些功能受支持，哪些不受支持。
### **支持的功能**
转换过程中支持以下功能：

- 母版、版式和幻灯片结构的转换
- 母版、版式和幻灯片结构的转换
- 图表的转换
- 组合形状
- 自动形状（包括矩形和椭圆）的转换。但可能出现自动形状的调整值不正确的情况
- 具有自定义几何形状的形状。某些情况下可能无法转换
- 自动形状的纹理和图片填充样式。某些情况下可能无法转换
- 占位符的转换
- 文本框和文本占位符中的文本转换。但项目符号、对齐和制表符未完全实现
### **不支持的功能**
转换过程中不支持以下功能：

- 包含备注的幻灯片：PPTX 未实现读取备注。如果 PPT 中有备注，则无法保存为 PPTX。* 直线和折线的转换
- 线条和填充格式
- 渐变填充样式
- OLE 框架、表格、视频和音频框架等
- 动画及其他幻灯片属性被跳过

新的或缺失的功能将会在后续的 Aspose.Slides for C++ 版本中加入。

源 PPT 演示文稿

转换后的 PPTX 演示文稿
## **可移植文档格式（PDF）**
### **关于 PDF**
[Portable Document Format](https://en.wikipedia.org/wiki/PDF) 是 Adobe 系统创建的文件格式，用于在不同组织之间交换文档。该格式的目的是使文档内容的视觉外观不依赖于查看平台。
### **C++ 版 Aspose.Slides 中的 PDF**
任何可以加载到 Aspose.Slides for C++ 的演示文稿都可以转换为 PDF 文档，PDF 可符合 [PDF 1.5](https://en.wikipedia.org/wiki/PDF/A) 或 [PDF /A-1b](https://en.wikipedia.org/wiki/PDF/A) 标准，取决于您的选择。Aspose.Slides for C++ 将演示文稿导出为 PDF 时，大多数情况下导出的 PDF 文档外观几乎与原始演示文稿相似。Aspose 在转换为 PDF 文档时支持以下演示文稿功能：

- 图像、文本框和其他形状
- 文本及格式化
- 段落及格式化
- 超链接
- 页眉和页脚
- 项目符号
- 表格

您可以仅使用 Aspose.Slides for C++ 组件直接将演示文稿导出为 PDF 文档，无需任何其他第三方或 Aspose.Pdf 组件。此外，您还可以按照 this[link](/slides/zh/cpp/convert-powerpoint-to-pdf/) 中的说明，对演示到 PDF 的导出进行各种自定义选项设置。

通过 Aspose.Slides for C++ 将演示文稿转换为 PDF 文档
## **XML 打印规范（XPS）**
### **关于 XPS**
[XML Parser Specification](https://en.wikipedia.org/wiki/Open_XML_Paper_Specification) 是一种页面描述语言和固定文档格式，最初由 Microsoft 开发。与 PDF 类似，XPS 是一种固定布局的文档格式，旨在保持文档完整性并提供与设备无关的文档外观。
### **C++ 版 Aspose.Slides 中的 XPS**
任何可以由 Aspose.Slides for C++ 加载的演示文稿都可以转换为 XPS 格式。Aspose.Slides for C++ 使用高保真页面布局和渲染引擎生成固定布局的 XPS 文档。值得一提的是，Aspose.Slides for C++ 直接生成 XPS，而不依赖于随 C++ Framework 3.5 捆绑的 Windows Presentation Foundation（WPF）类，从而使其能够在运行早于 3.5 版本的 C++ Framework 的机器上生成 XPS 文档。您可以在 this[link](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-xps/) 中了解通过 Aspose.Slides for C++ 将演示文稿导出为 XPS 文档的方式。

通过 Aspose.Slides for C++ 将演示文稿转换为 XPS 文档