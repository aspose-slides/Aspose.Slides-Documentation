---
title: 新的 HTML 导出系统 - Aspose.Slides.WebExtensions
type: docs
weight: 240
url: /zh/net/web-extensions/
keywords:
- 网页扩展
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
description: "使用模板、CSS 和 JS 将演示文稿导出为 HTML——不使用 SVG。了解单页或多页输出、资源控制以及针对 PPT、PPTX 和 ODP 的自定义。"
---

## 简介

* 在旧的 Aspose.Slides API 版本中，将 PowerPoint 导出为 HTML 时，生成的 HTML 以 SVG 标记结合 HTML 的形式呈现。每个幻灯片都会导出为一个 SVG 容器。  
* 在新的 Aspose.Slides 版本中，使用 WebExtensions 系统导出 PowerPoint 演示文稿为 HTML 时，可以自定义 HTML 导出设置，以获得最佳效果。  

使用新的 WebExtensions 系统，您可以将整个演示文稿导出为带有一组 CSS 类和 JavaScript 动画的 HTML（无需 SVG）。新导出系统还提供了无限数量的选项和方法来定义导出过程。  

在以下情况和事件中使用新的 WebExtensions 系统从演示文稿生成 HTML：

* 使用自定义 CSS 样式或动画；覆盖某些类型形状的标记。  
* 覆盖文档结构，例如使用自定义页面间导航。  
* 将 .html、.css、.js 文件保存到具有自定义层次结构的文件夹中，并在不同文件夹中包含特定文件类型。例如，将幻灯片导出到基于章节名称的文件夹。  
* 默认将 CSS 和 JS 文件分别保存到不同文件夹，然后将它们添加到 HTML 文件中。图像和嵌入字体也会保存为单独的文件。但它们也可以以 base64 格式嵌入到 HTML 文件中。您可以将部分资源保存为文件，其他资源以 base64 嵌入到 HTML 中。  

您可以在 GitHub 上的 [Aspose.Slides.WebExtensions project](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/) 中查看 PowerPoint 转 HTML 示例。该项目包含两个部分：**Examples\SinglePageApp** 和 **Examples\MultiPageApp**。本文中使用的其他示例也可以在该 GitHub 仓库中找到。  

### **模板**

为进一步扩展 HTML 导出的功能，我们建议您使用 ASP.NET Razor 模板系统。可以将 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类实例与一组模板一起使用，以获取 HTML 文档作为导出结果。

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

此模板保存为磁盘上的 “shape-template-hello-world.html”，将在下一步使用。

在该模板中，我们遍历演示文稿形状中的文本框以显示文本。使用 WebDocument 生成 HTML 文件并将 Presentation 导出到该文件：
``` csharp
using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 150);
    shape.TextFrame.Text = "Hello World";
                
    WebDocumentOptions options = new WebDocumentOptions
    {
        TemplateEngine = new RazorTemplateEngine(), // 我们打算使用 Razor 模板引擎。通过实现 ITemplateEngine 可以使用其他模板引擎  
        OutputSaver = new FileOutputSaver() // 通过实现 IOutputSaver 接口可以使用其他结果保存器
    };
    WebDocument document = new WebDocument(options);

    // 添加文档 "input" - 将使用何种来源生成 HTML 文档
    document.Input
        .AddTemplate<Presentation>( // 模板将把 Presentation 作为 "model" 对象 (Model.Object) 
        "index", // 模板键 - 模板引擎需要它来将对象 (Presentation) 匹配到磁盘上加载的模板 ("shape-template-hello-world.html")  
        @"custom-templates\shape-template-hello-world.html"); // 我们之前创建的模板
                
    // 添加输出 - 导出到磁盘时生成的 HTML 文档的外观
    document.Output.Add(
        "hello-world.html", // 输出文件路径
        "index", // 将用于此文件的模板键（我们在前面的语句中已设置）  
        pres); // 实际的 Model.Object 实例 
                
    document.Save();
}
```


例如，我们希望向导出结果添加 CSS 样式以将文本颜色更改为红色。添加 CSS 模板：
``` css
.text {
    color: red;
}
```


现在，将其加入输入和输出：
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


将样式引用添加到模板并为类 “text” 添加引用：
``` html
<!DOCTYPE html>
<head>
    <link rel="stylesheet" type="text/css" href="hello-world.css" />
</head>
...
</html>
```


### **默认模板**

WebExtensions 提供两套基本模板用于将演示文稿导出为 HTML：
* 单页：所有演示文稿内容导出到一个 HTML 文件中，所有其他资源（图像、字体、样式等）导出为单独的文件。  
* 多页：每个幻灯片导出为单独的 HTML 文件。资源导出的默认逻辑与单页相同。  

`PresentationExtensions` 类可用于通过模板简化演示文稿的导出过程。`PresentationExtensions` 类包含一组针对 Presentation 类的扩展方法。要将演示文稿导出为单页，只需包含 Aspose.Slides.WebExtensions 命名空间并调用两个方法。第一个方法 `ToSinglePageWebDocument` 创建 `WebDocument` 实例。第二个方法保存 HTML 文档：
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


在 WebExtensions 中，每个用于标记生成的模板都绑定到一个键。该键可以在模板中使用。例如，在 @Include 指令中，您可以通过键将某个模板插入到另一个模板中。  

我们可以在段落模板内部使用文本段落模板的示例中演示此过程。您可以在 Aspose.Slides.WebExtensions 项目中找到示例： [Templates\common\paragraph.html](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/Templates/common/paragraph.html)。要在段落中绘制片段，我们使用 Razor Engine 的 @foreach 指令遍历它们：
``` html
@foreach (Portion portion in contextObject.Portions) 
{ 
    var subModel = Model.SubModel(portion);
    subModel.Local.Put("parentTextFrame", parentTextFrame);
    subModel.Local.Put("tableContent", tableContentFlag);
	@Raw(Include("portion", subModel).ToString().Replace(Environment.NewLine, ""));
}
```


片段拥有自己的模板 [portion.html](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/Templates/common/portion.html)，并为其生成模型。该模型将被添加到输出的 paragraph.html 模板中：
``` html
@Raw(Include("portion", subModel).ToString().Replace(Environment.NewLine, ""));
```


对于每种形状类型，我们使用自定义模板，该模板会添加到 Aspose.Slides.WebExtensions 项目中通用模板集合中。模板在 `ToSinglePageWebDocument` 和 `ToMultiPageWebDocument` 方法中合并，以提供最终结果。这些是单页和多页共享的通用模板：

-templates  
+-common  
  ¦ +-scripts：用于幻灯片切换动画的 JavaScript 脚本示例。  
  ¦ +-styles：通用 CSS 样式。  
  +-multi-page：多页输出的索引、菜单、幻灯片模板。  
  +-single-page：单页输出的索引、幻灯片模板。  

您可以在 `PresentationExtensions.AddCommonInputOutput` 方法中查看通用部分是如何绑定到所有模板的，详见[这里](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/PresentationExtensions.cs)。  

### **默认模板自定义**

您可以修改通用模型模板中的任何元素。例如，您可能想更改表格格式样式，但希望单页的其他样式保持不变。  

默认使用 Templates\common\table.html，表格外观与 PowerPoint 中的表格相同。使用自定义 CSS 样式更改表格格式：
``` css
.custom-table {
    border: 1px solid black;
}
.custom-table tr:nth-child(even) {background: #CCC}
.custom-table tr:nth-child(odd) {background: #ffb380}
```


我们可以在调用 `PresentationExtensions.ToSinglePageWebDocument` 方法时，创建相同的输入模板和输出文件结构（如生成的那样）。为此添加 `ExportCustomTableStyles_AddCommonStructure` 方法。此方法与 `ToSinglePageWebDocument` 的区别在于——我们不需要添加表格的标准模板和主索引页（它将被替换以包含对自定义表格样式的引用）：
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

    // 添加通用结构（除表格模板外）
    ExportCustomTableStyles_AddCommonStructure(pres, document, templatesPath, outputPath, options.EmbedImages);
                
    // 添加自定义表格模板
    document.Input.AddTemplate<Table>("table", @"custom-templates\table-custom-style.html");
                
    // 添加自定义表格样式
    document.Input.AddTemplate<Presentation>("table-custom-style", @"custom-templates\styles\table-custom-style.css");
    document.Output.Add(Path.Combine(outputPath, "table-custom-style.css"), "table-custom-style", pres);
                
    // 添加自定义索引 - 它只是标准 "index.html" 的副本，但包含对 "table-custom-style.css" 的引用
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


**注意** 自定义表格模板使用与标准表格相同的 “table” 键。因此，您可以在不重写的情况下替换特定默认模板。您也可以使用默认结构中的模板并保留相同键。例如，您可以在表格模板中使用标准段落模板；也可以使用键进行替换。您还可以使用 index.html 将对自定义表格 CSS 样式的引用包含进去：
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


## **从零创建项目：动画幻灯片切换**

WebExtensions 允许您导出包含动画幻灯片切换的演示文稿——只需在 `WebDocumentOptions` 中将 `AnimateTransitions` 属性设为 `true`：
``` csharp
WebDocumentOptions options = new WebDocumentOptions
{
    // ... 其他选项
    AnimateTransitions = true
};
```


让我们创建一个使用 Aspose.Slides 和 Aspose.Slides.WebExtensions 的新项目，用于为 PDF 创建具有平滑动画页面切换的 HTML 查看器。此处需使用 Aspose.Slides 的 PDF 导入功能。  

创建 PdfToPresentationToHtml 项目并添加 Aspose.Slides.WebExtensions NuGet 包（Aspose.Slides 包也会作为依赖项添加）：
![NuGet Package](screen.png)

首先导入 PDF 文档，该文档将被动画化并导出为 HTML 演示文稿：
``` csharp
using (Presentation pres = new Presentation())
{
    pres.Slides.RemoveAt(0);
    pres.Slides.AddFromPdf("sample.pdf");
}
```


现在，可以设置动画幻灯片切换（每张幻灯片对应导入的 PDF 页面）。示例 PDF 文档使用了 9 张幻灯片。为每张幻灯片添加切换效果（在查看 HTML 时演示）：
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


最后，使用 `WebDocument` 导出为 HTML，并将 `AnimateTransitions` 属性设为 `true`：
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


以上就是从 PDF 文档生成带动画页面切换的 HTML 所需的全部步骤。  

* [下载示例 HTML 文件](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/tree/main/Examples)。  
* [下载示例项目](/slides/zh/net/web-extensions/sample.zip)。