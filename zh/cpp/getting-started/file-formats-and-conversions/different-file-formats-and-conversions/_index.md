---
title: 不同文件格式和转换
type: docs
weight: 50
url: /cpp/different-file-formats-and-conversions/
---

## **Microsoft PowerPoint (PPT)**
### **关于 PPT**
[PPT](https://en.wikipedia.org/wiki/Microsoft_PowerPoint) 是一种演示文档文件格式，可以由不同版本的 Microsoft PowerPoint 创建、读取、处理和写入。这是 Microsoft 开发的演示文档的二进制格式。
### **Aspose.Slides for C++ 中的 PPT**
Aspose.Slides for C++ 可以读取由以下软件创建的 PPT 文件。

- Microsoft PowerPoint 97
- Microsoft PowerPoint 2000
- Microsoft PowerPoint XP
- Microsoft PowerPoint 2003

同样，Aspose.Slides for C++ 创建的 PPT 文件可以被上述软件读取。
### **对 PPT 的全面支持**
Aspose.Slides for C++ 提供对几乎所有与 PPT 文档文件格式相关的功能的支持。它不仅涵盖了不同 Microsoft PowerPoint 版本为 PPT 文档处理提供的基本/高级功能，还包括一些 Microsoft PowerPoint 甚至不支持的功能。使用 Aspose.Slides for C++ API 库的主要优势是处理这些功能的简便性。

除了与创建、读取和写入 PPT 文档文件相关的基本任务外，Aspose.Slides for C++ 还提供了一些功能，例如：

- 将其他 MS Office 文件格式作为 OLE 对象导入到 PPT 文档中。
- 将 PPT 文档导出为 PDF、TIFF、XPS 格式。
- 将 PPT 文档中的幻灯片导出为 SVG 格式。
- 将幻灯片呈现为 C++ 框架支持的任何图像格式。
- 设置 PPT 文档中幻灯片的大小。
- 管理形状上的动画。
- 管理幻灯片放映。
- 格式化幻灯片上的文本。
- 从 PPT 文档中扫描文本。
- 处理幻灯片上的表格。
- 使用克隆功能自动复制母版。

由 Aspose.Slides for C++ 生成并在 Microsoft PowerPoint 中打开的 PPT 文件
## **PresentationML (PPTX, XML)**
### **关于 PresentationML**
PresentationML 是一系列基于 XML 的演示文档格式的名称。Office OpenXML (OOXML) 是在 Microsoft Office 2007 应用程序中引入的基于 XML 的格式。Office OpenXML 是多个专用的基于 XML 的标记语言的容器格式。PresentationML 是 Microsoft Office PowerPoint 2007 用于存储其文档的标记语言。
### **Aspose.Slides for C++ 中的 PresentationML**
OOXML PresentationML 文档以 PPTX 文件形式出现，这些文件是遵循了 [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/) 规范的压缩 XML 包。Aspose.Slides for C++ 广泛支持创建、读取、处理和写入 PresentationML 文档。此外，Aspose.Slides for C++ 还能够将 PresentationML 文档导出为 PDF、TIFF 和 XPS 等不同广泛使用的文档格式。这是因为 Aspose.Slides for C++ 的设计目标是全面处理演示文档，而 PresentationML 基本上将文档的内部表示保持为压缩的 XML 包。

由 Aspose.Slides for C++ 生成并在 Microsoft PowerPoint 中打开的 PPTX 文档

在 Zip 应用程序中查看由 Aspose.Slides for C++ 生成的 PPTX 文档
### **PresentationML 是开放的，为什么使用 Aspose.Slides for C++**
由于 PresentationML 是基于 XML 的，因此可以通过使用 XML 类来构建处理和生成 PresentationML 文档的应用程序，而不依赖于像 Aspose.Slides for C++ 这样的第三方类库。然而，在处理 PresentationML 文档时，使用 Aspose.Slides for C++ 相对于 XML 类还有几个优势。

OOXML 规范长达数千页。这意味着为了正确处理 PresentationML 文档，您需要花费大量的时间和精力来理解这些文档的格式。另一方面，使用 Aspose.Slides for C++ 时，您只需使用相关类及其各自的方法/属性来执行操作，而通过 XML 类执行这些操作似乎相当复杂。

在通过 XML 类处理 PresentationML 文档时，以下一些功能是不可用的：

- 将 PPT 文档导出为 PDF、TIFF、XPS 格式
- 将 PPT 文档中的幻灯片导出为 SVG 格式
- 将幻灯片呈现为 C++ 框架支持的任何图像格式
- 使用克隆功能从源演示文稿自动复制母版
- 对形状应用保护

让我们以一个包含“Hello World”文本的文本框的单张幻灯片的 PresentationML 文档为例。为了通过 XML 类读取文本，您必须编写一个可以从以下片段解析这段简单文本的程序：

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
## **PPT 到 PPTX 转换**
### **关于转换**
Aspose.Slides 现在还支持将 PPT 转换为 PPTX。
### **转换中支持的功能**
Aspose.Slides for C++ 提供对将 PPT 文档文件格式演示转换为 PPTX 文件格式演示的部分支持。由于 PPT 转换功能刚刚在 Aspose.Slides for C++ 中引入，因此目前其功能有限，仅适用于简单形式的演示。Aspose.Slides for C++ API 库在将 PPT 演示转换为 PPTX 格式演示时提供的主要优势在于使用 API 实现所需目标的简易性。请前往此 [link]() 的代码片段部分以获取更多详情。以下部分清晰地说明了在将 PPT 格式演示转换为 PPTX 格式演示时支持和不支持的功能。
### **支持的功能**
在转换过程中支持以下功能：

- 母版、布局和幻灯片结构的转换
- 图表的转换
- 组合形状
- 包括矩形和椭圆在内的自动形状的转换。然而，自动形状可能具有错误的调整值
- 带有自定义几何的形状。有时候可能无法转换
- 自动形状的纹理和图片填充样式。有时候可能无法转换
- 占位符的转换
- 文本框和文本持有者中的文本转换。然而，项目符号、对齐和制表符尚未完全实现
### **不支持的功能**
在转换期间，以下功能不受支持：

- 带备注的幻灯片，因为 PPTX 中未实现阅读备注。如果 PPT 有它，则无法保存为 PPTX*
- 线条和多边形的转换
- 线条和填充格式
- 渐变填充样式
- OLE 框、表格、视频和音频框等
- 动画和其他幻灯片放映属性被跳过
  新功能或缺失的功能将随后的 Aspose.Slides for C++ 的版本中添加。

源 PPT 演示

已转换的 PPTX 演示
## **便携文档格式 (PDF)**
### **关于 PDF**
[便携文档格式](https://en.wikipedia.org/wiki/PDF) 是 Adobe 系统为不同组织之间交换文档而创建的文件格式。此格式的目的是使文档内容的表示方式不依赖于查看该内容的平台。
### **Aspose.Slides for C++ 中的 PDF**
任何可以加载到 Aspose.Slides for C++ 的演示文档都可以转换为 PDF 文档，这些 PDF 文档可能符合 [PDF 1.5](https://en.wikipedia.org/wiki/PDF/A) 或 [PDF /A-1b](https://en.wikipedia.org/wiki/PDF/A)，具体取决于您的选择。Aspose.Slides for C++ 将演示文档导出为 PDF 的方式通常使导出的 PDF 文档看起来与原始演示文档几乎相似。Aspose 解决方案在转换为 PDF 文档时支持以下演示文档的功能：

- 图像、文本框和其他形状
- 文本和格式
- 段落和格式
- 超链接
- 页眉和页脚
- 项目符号
- 表格

您可以仅使用 Aspose.Slides for C++ 组件直接将演示文档导出为 PDF 文档。也就是说，您不需要其他第三方或 Aspose.Pdf 组件。进一步，您可以根据 [此主题](/slides/cpp/converting-presentation-to-pdf/) 中的说明自定义演示导出为 PDF 的选项。

通过 Aspose.Slides for C++ 转换为 PDF 文档的演示文档
## **XML 解析器规范 (XPS)**
### **关于 XPS**
[XML 解析器规范](https://en.wikipedia.org/wiki/Open_XML_Paper_Specification) 是一种页面描述语言和固定文档格式，最初由 Microsoft 开发。与 PDF 类似，XPS 是一种固定布局的文档格式，旨在保持文档的忠实度并提供设备无关的文档外观。
### **Aspose.Slides for C++ 中的 XPS**
任何可以被 Aspose.Slides for C++ 加载的演示文档都可以转换为 XPS 格式。Aspose.Slides for C++ 使用高保真的页面布局和渲染引擎以生成固定布局的 XPS 文档格式。值得一提的是，Aspose.Slides for C++ 直接生成 XPS，而无需依赖与 C++ 框架 3.5 一起打包的 Windows Presentation Foundation (WPF) 类，因此允许 Aspose.Slides for C++ 在运行 C++ 框架版本低于 3.5 的机器上生成 XPS 文档。您可以通过 Aspose.Slides for C++ 在 [此主题](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-xps/) 中了解有关将演示文档导出为 XPS 文档的详细信息。

通过 Aspose.Slides for C++ 转换为 XPS 文档的演示文档