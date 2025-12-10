---
title: 新 HTML 导出系统 - Aspose.Slides.WebExtensions
type: docs
weight: 240
url: /zh/net/web-extensions/
keywords:
- Web 扩展
- 模板引擎
- 导出 PowerPoint
- 导出 OpenDocument
- 导出演示文稿
- 导出幻灯片
- 导出 PPT
- 导出 PPTX
- 导出 ODP
- PowerPoint 转 HTML
- OpenDocument 转 HTML
- 演示文稿转 HTML
- 幻灯片转 HTML
- PPT 转 HTML
- PPTX 转 HTML
- ODP 转 HTML
- .NET
- C#
- Aspose.Slides
description: "使用模板、CSS 和 JS 将演示文稿导出为 HTML——无需 SVG。了解单页或多页输出、资源控制以及针对 PPT、PPTX 和 ODP 的自定义。"
---

## **介绍**

* 在旧的 Aspose.Slides API 版本中，当您将 PowerPoint 导出为 HTML 时，生成的 HTML 会以 SVG 标记结合 HTML 的形式呈现。每张幻灯片都会导出为一个 SVG 容器。  
* 在新的 Aspose.Slides 版本中，当您使用 WebExtensions 系统将 PowerPoint 演示文稿导出为 HTML 时，您可以自定义 HTML 导出设置，以获得最佳效果。  

使用新的 WebExtensions 系统，您可以将整个演示文稿导出为带有一套 CSS 类和 JavaScript 动画（不使用 SVG）的 HTML。新的导出系统还提供了无限数量的选项和方法来定义导出过程。  

在以下情况和事件中使用新的 WebExtensions 系统从演示文稿生成 HTML：

* 使用自定义 CSS 样式或动画；覆盖某些形状类型的标记。  
* 覆盖文档结构，例如使用自定义页面之间的导航。  
* 将 .html、.css、.js 文件保存到具有自定义层次结构的文件夹中，包括将特定文件类型保存到不同的文件夹。例如，根据章节名称将幻灯片导出到相应的文件夹。  
* 默认情况下，将 CSS 和 JS 文件分别保存到独立文件夹中，然后将它们添加到 HTML 文件。图像和嵌入字体也会保存为独立文件。不过，它们也可以以 base64 格式嵌入到 HTML 文件中。您可以将部分资源保存为文件，其他资源以 base64 形式嵌入到 HTML 中。  

您可以在 GitHub 上的 [Aspose.Slides.WebExtensions 项目](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/) 中查看 PowerPoint 转 HTML 示例。该项目包含两个部分：**Examples\SinglePageApp** 和 **Examples\MultiPageApp**。本文使用的其他示例也可以在该仓库中找到。  

### **模板**

为了进一步扩展 HTML 导出的功能，我们建议使用 ASP.NET Razor 模板系统。可以将 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类实例与一组模板结合使用，以获取作为导出结果的 HTML 文档。  

**演示**

在本示例中，我们将把演示文稿中的文本导出为 HTML。首先，创建模板：
``` html
<!DOCTYPE html>
<body>
    @foreach (Slide slide in Model.Object.Slides)    
    {
        foreach (Shape shape in slide.Shapes)
        {
            if(shape is AutoShape)
            {
                ITextFrame textFrame = ((AutoShape)shape).TextFrame;
                <div class="text">@textFrame.Text</div>
            }
        }
    }
</body>
</html>
```

此模板以 “shape-template-hello-world.html” 保存到磁盘，在下一步中使用。  

在此模板中，我们遍历演示文稿形状中的文本框以显示文本。使用 WebDocument 生成 HTML 文件，然后将 Presentation 导出到该文件：
``` csharp
using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 150);
    shape.TextFrame.Text = "Hello World";
                
    WebDocumentOptions options = new WebDocumentOptions
    {
        TemplateEngine = new RazorTemplateEngine(), // 我们打算使用 Razor 模板引擎。也可以通过实现 ITemplateEngine 来使用其他模板引擎  
        OutputSaver = new FileOutputSaver() // 也可以通过实现 IOutputSaver 接口来使用其他结果保存器
    };
    WebDocument document = new WebDocument(options);

    // 添加文档 “input” - 将使用什么来源生成 HTML 文档
    document.Input
        .AddTemplate<Presentation>( // 模板将以 Presentation 作为 “model” 对象 (Model.Object) 
        "index", // 模板键 - 模板引擎需要它来将对象 (Presentation) 与磁盘上加载的模板 ("shape-template-hello-world.html") 匹配  
        @"custom-templates\shape-template-hello-world.html"); // 我们之前创建的模板
                
    // 添加输出 - 导出到磁盘时生成的 HTML 文档将如何呈现
    document.Output.Add(
        "hello-world.html", // 输出文件路径
        "index", // 将用于此文件的模板键（我们在前面的语句中设置的）  
        pres); // 实际的 Model.Object 实例 
                
    document.Save();
}
```


例如，我们想向导出结果添加 CSS 样式，使文本颜色变为红色。添加 CSS 模板：
``` css
.text {
    color: red;
}
```


随后，将其加入输入和输出：
``` csharp
using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 150);
    shape.TextFrame.Text = "Hello World";
                
    WebDocumentOptions options = new WebDocumentOptions { TemplateEngine = new RazorTemplateEngine(), OutputSaver = new FileOutputSaver() };
    WebDocument document = new WebDocument(options);

    document.Input.AddTemplate<Presentation>("index", @"custom-templates\shape-template-hello-world.html");
    document.Input.AddTemplate<Presentation>("styles", @"custom-templates\styles\shape-template-hello-world.css");
    document.Output.Add("hello-world.html", "index", pres); 
    document.Output.Add("hello-world.css", "styles", pres);
                
    document.Save();
}
```


将对样式的引用添加到模板的 `text` 类中：
``` html
<!DOCTYPE html>
<head>
    <link rel="stylesheet" type="text/css" href="hello-world.css" />
</head>
...
</html>
```


### **默认模板**

WebExtensions 提供两套基本模板，用于将演示文稿导出为 HTML：

* 单页：所有演示文稿内容导出到一个 HTML 文件中，所有其他资源（图像、字体、样式等）导出为独立文件。  
* 多页：每张幻灯片导出为单独的 HTML 文件。资源导出的默认逻辑与单页相同。  

可以使用 `PresentationExtensions` 类通过模板简化演示文稿导出过程。`PresentationExtensions` 类包含一组针对 `Presentation` 类的扩展方法。要将演示文稿导出为单页，只需引用 `Aspose.Slides.WebExtensions` 命名空间并调用两个方法。第一个方法 `ToSinglePageWebDocument` 创建 `WebDocument` 实例。第二个方法保存 HTML 文档：
``` csharp
using (Presentation pres = new Presentation("demo.pptx"))
{
    WebDocument document = pres.ToSinglePageWebDocument("templates\\single-page", @"single-page-output");
    document.Save();
}
```


`ToSinglePageWebDocument` 方法可以接受两个参数：模板文件夹和导出文件夹。  

要将演示文稿导出为多页，使用带有相同参数的 `ToMultiPageWebDocument` 方法：
``` csharp
using (Presentation pres = new Presentation("demo.pptx"))
{
    WebDocument document = pres.ToMultiPageWebDocument("templates\\multi-page", @"mutil-page-output");
    document.Save();
}
```


在 WebExtensions 中，每个用于标记生成的模板都绑定到一个键。该键可在模板中使用。例如，在 `@Include` 指令中，您可以通过键将某个模板插入到另一个模板中。  

我们可以在段落模板中使用文本段落模板的示例中演示此过程。示例位于 Aspose.Slides.WebExtensions 项目中：[`Templates\common\paragraph.html`](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/Templates/common/paragraph.html)。要在段落中绘制各段落，我们使用 Razor Engine 的 `@foreach` 指令遍历它们：
``` html
@foreach (Portion portion in contextObject.Portions) 
{ 
    var subModel = Model.SubModel(portion);
    subModel.Local.Put("parentTextFrame", parentTextFrame);
    subModel.Local.Put("tableContent", tableContentFlag);
	@Raw(Include("portion", subModel).ToString().Replace(Environment.NewLine, ""));
}
```


段落的模板为 [portion.html](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/Templates/common/portion.html)，为其生成了模型。该模型将被添加到输出的 `paragraph.html` 模板中：
``` html
@Raw(Include("portion", subModel).ToString().Replace(Environment.NewLine, ""));
```


对于每种形状类型，我们使用自定义模板，该模板会被添加到 Aspose.Slides.WebExtensions 项目中的通用模板集合中。`ToSinglePageWebDocument` 和 `ToMultiPageWebDocument` 方法会将这些模板组合，以提供最终结果。这些是单页和多页共用的通用模板：

```
-templates
+-common
  ¦ +-scripts: 幻灯片切换动画的 JavaScript 脚本实例。
  ¦ +-styles: 通用 CSS 样式。
  +-multi-page: 多页输出的 index、menu、slide 模板。
  +-single-page: 单页输出的 index、slide 模板。
```

您可以在 `PresentationExtensions.AddCommonInputOutput` 方法中查看通用部分如何绑定到所有模板，链接如下：[这里](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/PresentationExtensions.cs)。  

### **默认模板自定义**

您可以修改通用模型模板中的任何元素。例如，您可能想更改表格的格式样式，但希望单页的其他样式保持不变。  

默认情况下使用 `Templates\common\table.html`，其外观与 PowerPoint 中的表格相同。下面使用自定义 CSS 样式更改表格格式：
``` css
.custom-table {
    border: 1px solid black;
}
.custom-table tr:nth-child(even) {background: #CCC}
.custom-table tr:nth-child(odd) {background: #ffb380}
```


我们可以在调用 `PresentationExtensions.ToSinglePageWebDocument` 方法时，创建相同的输入模板结构和输出文件（如生成的那样）。为此添加 `ExportCustomTableStyles_AddCommonStructure` 方法。该方法与 `ToSinglePageWebDocument` 的区别在于——我们无需添加标准表格模板和主索引页面（它们将被替换为对自定义表格样式的引用）：
``` csharp
private static void ExportCustomTableStyles_AddCommonStructure(
    Presentation pres, 
    WebDocument document,
    string templatesPath, 
    string outputPath, 
    bool embedImages)
{
    AddCommonStylesTemplates(document, templatesPath);
            
    document.Input.AddTemplate<Slide>("slide", Path.Combine(templatesPath, "slide.html"));
    document.Input.AddTemplate<AutoShape>("autoshape", Path.Combine(templatesPath, "autoshape.html"));
    document.Input.AddTemplate<TextFrame>("textframe", Path.Combine(templatesPath, "textframe.html"));
    document.Input.AddTemplate<Paragraph>("paragraph", Path.Combine(templatesPath, "paragraph.html"));
    document.Input.AddTemplate<Paragraph>("bullet", Path.Combine(templatesPath, "bullet.html"));
    document.Input.AddTemplate<Portion>("portion", Path.Combine(templatesPath, "portion.html"));
    document.Input.AddTemplate<VideoFrame>("videoframe", Path.Combine(templatesPath, "videoframe.html"));
    document.Input.AddTemplate<PictureFrame>("pictureframe", Path.Combine(templatesPath, "pictureframe.html")); ;
    document.Input.AddTemplate<Shape>("shape", Path.Combine(templatesPath, "shape.html"));

    AddSinglePageCommonOutput(pres, document, outputPath);
            
    AddResourcesOutput(pres, document, embedImages);
            
    AddScriptsOutput(document, templatesPath);
}
```


改为添加自定义模板：
``` csharp
using (Presentation pres = new Presentation("table.pptx"))
{
    const string templatesPath = "templates\\single-page";
    const string outputPath = "custom-table-styles";
                
    var options = new WebDocumentOptions
    {
        TemplateEngine = new RazorTemplateEngine(),
        OutputSaver = new FileOutputSaver(),
        EmbedImages = false
    };

    // 设置全局文档值
    WebDocument document = new WebDocument(options);
    SetupGlobals(document, options, outputPath);

    // 添加公共结构（不包括表格模板）
    ExportCustomTableStyles_AddCommonStructure(pres, document, templatesPath, outputPath, options.EmbedImages);
                
    // 添加自定义表格模板
    document.Input.AddTemplate<Table>("table", @"custom-templates\table-custom-style.html");
                
    // 添加自定义表格样式
    document.Input.AddTemplate<Presentation>("table-custom-style", @"custom-templates\styles\table-custom-style.css");
    document.Output.Add(Path.Combine(outputPath, "table-custom-style.css"), "table-custom-style", pres);
                
    // 添加自定义索引 - 这只是标准 "index.html" 的副本，但
    // 包含对 "table-custom-style.css" 的引用
    document.Input.AddTemplate<Presentation>("index", @"custom-templates\index-table-custom-style.html");
                
    document.Save();
}
```

``` html
@model TemplateContext<Table>

@{
	Table contextObject = Model.Object;
	
	var origin = Model.Local.Get<Point>("origin");
	var positionStyle = string.Format("left: {0}px; top: {1}px; width: {2}px; height: {3}px;",
										(int)contextObject.X + origin.X,
										(int)contextObject.Y + origin.Y,
										(int)contextObject.Width,
										(int)contextObject.Height);
}

	<table class="table custom-table" style="@positionStyle">
	@for (int i = 0; i < contextObject.Rows.Count; i++)
	{
		var rowHeight = string.Format("height: {0}px", contextObject.Rows[i].Height);
		<tr style="@rowHeight">
		@for (int j = 0; j < contextObject.Columns.Count; j++)
		{
			var cell = contextObject[j, i];
			if (cell.FirstRowIndex ==  i && cell.FirstColumnIndex == j)
			{
				var spans = cell.IsMergedCell ? string.Format("rowspan=\"{0}\" colspan=\"{1}\"", cell.RowSpan, cell.ColSpan) : "";
				<td width="@cell.Width px" @Raw(spans)>
					@{
						for(int k = 0; k < cell.TextFrame.Paragraphs.Count; k++)
						{
							var para = (Paragraph)cell.TextFrame.Paragraphs[k];
						
							var subModel = Model.SubModel(para);
							double[] margins = new double[] { cell.MarginLeft, cell.MarginTop, cell.MarginRight, cell.MarginBottom };
							subModel.Local.Put("margins", margins);
							subModel.Local.Put("parent", cell.TextFrame);
							subModel.Local.Put("parentContainerSize", new SizeF((float)cell.Width, (float)cell.Height));
                            subModel.Local.Put("tableContent", true);
							
							@Include("paragraph", subModel)
						}
					}
				</td>
			}
		}
		</tr>
	}
</table>
```


**注意**，自定义表格模板使用了与标准表格相同的 “table” 键。因此，您可以在不重新编写的情况下替换特定的默认模板。您也可以使用默认结构中的模板，只要键相同。例如，您可以在表格模板中使用标准段落模板，或用相同键替换它。  

您还可以使用 `index.html` 将对自定义表格 CSS 样式的引用包含进去：
``` html
<!DOCTYPE html>    
    
<html     
    xmlns="http://www.w3.org/1999/xhtml"    
    xmlns:svg="http://www.w3.org/2000/svg"    
    xmlns:xlink="http://www.w3.org/1999/xlink">    
<head>    
     ...
    <link rel="stylesheet" type="text/css" href="table-custom-style.css" />
    ...
</head>    
<body>    
    ...
</body>
</html>
```


## **从头创建项目：动画幻灯片切换**

WebExtensions 允许您导出带有动画幻灯片切换的演示文稿——只需在 `WebDocumentOptions` 中将 `AnimateTransitions` 属性设为 `true`：
``` csharp
WebDocumentOptions options = new WebDocumentOptions
{
    // ... 其他选项
    AnimateTransitions = true
};
```


让我们创建一个新项目，使用 Aspose.Slides 和 Aspose.Slides.WebExtensions 为 PDF 创建带平滑动画页面切换的 HTML 查看器。这里需要使用 Aspose.Slides 的 PDF 导入功能。

创建 `PdfToPresentationToHtml` 项目并添加 Aspose.Slides.WebExtensions NuGet 包（Aspose.Slides 包也会作为依赖项添加）：
![NuGet Package](screen.png)

首先导入 PDF 文档，该文档将被动画化并导出为 HTML 演示文稿：
``` csharp
using (Presentation pres = new Presentation())
{
    pres.Slides.RemoveAt(0);
    pres.Slides.AddFromPdf("sample.pdf");
}
```


现在，我们可以设置动画幻灯片切换（每张幻灯片对应导入的 PDF 页面）。示例 PDF 文档中使用了 9 张幻灯片。为它们每一张添加幻灯片切换（在浏览 HTML 时演示）：
``` csharp
pres.Slides[0].SlideShowTransition.Type = TransitionType.Fade;
pres.Slides[1].SlideShowTransition.Type = TransitionType.RandomBar;
pres.Slides[2].SlideShowTransition.Type = TransitionType.Cover;
pres.Slides[3].SlideShowTransition.Type = TransitionType.Dissolve;
pres.Slides[4].SlideShowTransition.Type = TransitionType.Switch;
pres.Slides[5].SlideShowTransition.Type = TransitionType.Pan;
pres.Slides[6].SlideShowTransition.Type = TransitionType.Ferris;
pres.Slides[7].SlideShowTransition.Type = TransitionType.Pull;
pres.Slides[8].SlideShowTransition.Type = TransitionType.Plus;
```


最后，使用 `WebDocument` 将 `AnimateTransitions` 属性设为 `true`，将其导出为 HTML：
``` csharp
WebDocumentOptions options = new WebDocumentOptions
{
    TemplateEngine = new RazorTemplateEngine(),
    OutputSaver = new FileOutputSaver(),
    AnimateTransitions = true
};

WebDocument document = pres.ToSinglePageWebDocument(options, "templates\\single-page", "animated-pdf");
document.Save();
```


完整源码示例：
``` csharp
using (Presentation pres = new Presentation())
{
    pres.Slides.RemoveAt(0);
    pres.Slides.AddFromPdf("sample.pdf");

    pres.Slides[0].SlideShowTransition.Type = TransitionType.Fade;
    pres.Slides[1].SlideShowTransition.Type = TransitionType.RandomBar;
    pres.Slides[2].SlideShowTransition.Type = TransitionType.Cover;
    pres.Slides[3].SlideShowTransition.Type = TransitionType.Dissolve;
    pres.Slides[4].SlideShowTransition.Type = TransitionType.Switch;
    pres.Slides[5].SlideShowTransition.Type = TransitionType.Pan;
    pres.Slides[6].SlideShowTransition.Type = TransitionType.Ferris;
    pres.Slides[7].SlideShowTransition.Type = TransitionType.Pull;
    pres.Slides[8].SlideShowTransition.Type = TransitionType.Plus;

    WebDocumentOptions options = new WebDocumentOptions
    {
        TemplateEngine = new RazorTemplateEngine(),
        OutputSaver = new FileOutputSaver(),
        AnimateTransitions = true
    };

    WebDocument document = pres.ToSinglePageWebDocument(options, "templates\\single-page", "animated-pdf");
    document.Save();
}
```


以上即为从 PDF 文档生成带动画页面切换的 HTML 所需的全部内容。  

* [下载示例 HTML 文件](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/tree/main/Examples)  
* [下载示例项目](/slides/zh/net/web-extensions/sample.zip)