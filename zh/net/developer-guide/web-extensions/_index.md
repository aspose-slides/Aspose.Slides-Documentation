---
title: 新的 HTML 导出系统 - Aspose.Slides.WebExtensions
type: docs
weight: 240
url: /zh/net/web-extensions/
keywords: "导出 PowerPoint HTML, PowerPoint 演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "在 C# 或 .NET 中导出 PowerPoint HTML"
---


## 介绍

* 在旧版本的 Aspose.Slides API 中，当你将 PowerPoint 导出为 HTML 时，生成的 HTML 以 SVG 标记和 HTML 组合的形式表示。每个幻灯片被导出为一个 SVG 容器。
* 在新的 Aspose.Slides 版本中，当你使用 WebExtensions 系统将 PowerPoint 演示文稿导出为 HTML 时，你可以自定义 HTML 导出设置以提供最佳结果。

使用新的 WebExtensions 系统，你可以将整个演示文稿导出为 HTML，并使用一组 CSS 类和 JavaScript 动画（不使用 SVG）。新的导出系统还提供了无限数量的选项和方法来定义导出过程。

新的 WebExtensions 系统将在以下情况下和事件中用于从演示文稿生成 HTML：

* 使用自定义 CSS 样式或动画；覆盖某些类型形状的标记。
* 当覆盖文档结构时，例如，在页面之间使用自定义导航。
* 当将 .html、.css、.js 文件保存到具有自定义层次结构的文件夹中，包括不同文件夹中的特定文件类型。例如，基于部分名称将幻灯片导出到一个文件夹中。
* 默认情况下，将 CSS 和 JS 文件保存到单独的文件夹中，然后将它们添加到 HTML 文件中。图像和嵌入字体也保存在单独的文件中。然而，它们可以以 base64 格式嵌入 HTML 文件中。你可以将某些资源部分保存到文件中，并将其他资源以 base64 形式嵌入 HTML。

你可以在 [Aspose.Slides.WebExtensions 项目](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/) 的 GitHub 上查看 PowerPoint 到 HTML 的示例。该项目包含两个部分：**Examples\SinglePageApp** 和 **Examples\MultiPageApp**。本文中使用的其他示例也可以在 GitHub 仓库中找到。

### **模板**

为进一步扩展 HTML 导出的功能，我们建议你使用 ASP.NET Razor 模板系统。[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类实例可以与一组模板一起使用，以获取作为导出结果的 HTML 文档。

**演示**

在此示例中，我们将从演示文稿导出文本到 HTML。首先，让我们创建模板：

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
此模板保存在磁盘上，名为 "shape-template-hello-world.html"，将在下一步中使用。

在此模板中，我们正在遍历演示文稿形状中的文本框以显示文本。让我们使用 WebDocument 生成 HTML 文件，然后将演示文稿导出到该文件中：

``` csharp
using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 150);
    shape.TextFrame.Text = "Hello World";
                
    WebDocumentOptions options = new WebDocumentOptions
    {
        TemplateEngine = new RazorTemplateEngine(), // 我们打算使用 Razor 模板引擎。可以通过实现 ITemplateEngine 来使用其他模板引擎  
        OutputSaver = new FileOutputSaver() // 可以通过实现 IOutputSaver 接口来使用其他结果保存器
    };
    WebDocument document = new WebDocument(options);

    // 添加文档“输入” - 将使用什么源来生成 HTML 文档
    document.Input
        .AddTemplate<Presentation>( // 模板将具有 Presentation 作为“模型”对象 (Model.Object) 
        "index", // 模板键 - 模板引擎所需的，以将对象 (Presentation) 匹配到从磁盘加载的模板 ("shape-template-hello-world.html")  
        @"custom-templates\shape-template-hello-world.html"); // 我们之前创建的模板
                
    // 添加输出 - 导出的 HTML 文档在导出到磁盘时的外观
    document.Output.Add(
        "hello-world.html", // 输出文件路径
        "index", // 将用于此文件的模板键 (我们在上一个语句中设置)  
        pres); // 真实的 Model.Object 实例 
                
    document.Save();
}
```

例如，我们希望向导出结果添加 CSS 样式，以将文本颜色更改为红色。让我们添加 CSS 模板：

``` css
.text {
    color: red;
}
```

现在，我们将其添加到输入和输出中：

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

让我们在模板及类 "text" 中添加对样式的引用：
``` html
<!DOCTYPE html>
<head>
    <link rel="stylesheet" type="text/css" href="hello-world.css" />
</head>
...
</html>
```

### **默认模板**

WebExtensions 提供了两组基本模板，用于将演示文稿导出为 HTML：
* 单页：所有演示文稿内容导出到一个 HTML 文件中。所有其他资源（图像、字体、样式等）导出到单独的文件中。
* 多页：每个演示文稿幻灯片导出到单独的 HTML 文件中。导出资源的默认逻辑与单页相同。

`PresentationExtensions` 类可用于简化使用模板的演示导出过程。`PresentationExtensions` 类包含一组用于 Presentation 类的扩展方法。要将演示文稿导出为单页，只需包含 Aspose.Slides.WebExtensions 命名空间并调用两个方法。第一个方法 `ToSinglePageWebDocument` 创建一个 `WebDocument` 实例。第二个方法保存 HTML 文档：

``` csharp
using (Presentation pres = new Presentation("demo.pptx"))
{
    WebDocument document = pres.ToSinglePageWebDocument("templates\\single-page", @"single-page-output");
    document.Save();
}
```

ToSinglePageWebDocument 方法可以接受两个参数：模板文件夹和导出文件夹。

要将演示文稿导出为多页，请使用与相同参数的 ToMultiPageWebDocument 方法：

``` csharp
using (Presentation pres = new Presentation("demo.pptx"))
{
    WebDocument document = pres.ToMultiPageWebDocument("templates\\multi-page", @"mutil-page-output");
    document.Save();
}
```

在 WebExtensions 中，用于标记生成的每个模板都绑定到一个键。该键可以在模板中使用。例如，在 @Include 指令中，你可以通过该键将某个模板插入到另一个模板中。

我们可以通过在段落模板内使用文本部分模板的示例来演示该过程。你可以在 Aspose.Slides.WebExtensions 项目中找到该示例：[Templates\common\paragraph.html](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/Templates/common/paragraph.html)。要在段落中绘制部分，我们使用 Razor 引擎的 @foreach 指令进行迭代：

``` html
@foreach (Portion portion in contextObject.Portions) 
{ 
    var subModel = Model.SubModel(portion);
    subModel.Local.Put("parentTextFrame", parentTextFrame);
    subModel.Local.Put("tableContent", tableContentFlag);
	@Raw(Include("portion", subModel).ToString().Replace(Environment.NewLine, ""));
}
```

Portion 有其自己的模板 [portion.html](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/Templates/common/portion.html)，并为其生成一个模型。该模型将添加到输出的 paragraph.html 模板中：
``` html
@Raw(Include("portion", subModel).ToString().Replace(Environment.NewLine, ""));
```

对于每种形状类型，我们使用一个自定义模板，该模板被添加到 Aspose.Slides.WebExtensions 项目的通用模板集中。模板在 ToSinglePageWebDocument 和 ToMultiPageWebDocument 方法中组合以提供最终结果。这些是单页和多页都使用的通用模板：

-templates
+-common
  ¦ +-scripts: 用于幻灯片过渡动画的 JavaScript 脚本，例如。
  ¦ +-styles: 通用 CSS 样式。
  +-multi-page: 多页输出的索引、菜单、幻灯片模板。
  +-single-page: 单页输出的索引、幻灯片模板。

你可以找到如何在 `PresentationExtensions.AddCommonInputOutput` 方法中绑定所有模板的通用部分 [在这里](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/PresentationExtensions.cs)。

### **默认模板自定义**

你可以修改通用模型模板中的任何元素。例如，你可能决定更改表格格式样式，但希望单页的所有其他样式保持不变。

默认情况下，Templates\common\table.html 被使用，表格的外观与 PowerPoint 中的表格相同。让我们使用自定义 CSS 样式更改表格格式：
``` css
.custom-table {
    border: 1px solid black;
}
.custom-table tr:nth-child(even) {background: #CCC}
.custom-table tr:nth-child(odd) {background: #ffb380}
```

我们可以创建相同的输入模板和输出文件结构（如生成时）同时调用 `PresentationExtensions.ToSinglePageWebDocument` 方法。让我们为此添加 `ExportCustomTableStyles_AddCommonStructure` 方法。此方法与 `ToSinglePageWebDocument` 方法之间的区别在于——我们不需要添加标准的表格模板和主索引页面（它将被替换以包含自定义表格样式的引用）：

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

让我们改为添加自定义模板：

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

    // 添加通用结构（除了表格模板）
    ExportCustomTableStyles_AddCommonStructure(pres, document, templatesPath, outputPath, options.EmbedImages);
                
    // 添加自定义表格模板
    document.Input.AddTemplate<Table>("table", @"custom-templates\table-custom-style.html");
                
    // 添加自定义表格样式
    document.Input.AddTemplate<Presentation>("table-custom-style", @"custom-templates\styles\table-custom-style.css");
    document.Output.Add(Path.Combine(outputPath, "table-custom-style.css"), "table-custom-style", pres);
                
    // 添加自定义索引 - 它仅仅是标准 "index.html" 的副本，但包含对 "table-custom-style.css" 的引用
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

**注意**，自定义表格模板是使用与标准表格相同的“表格”键添加的。因此，你可以在不重写它的情况下替换某个默认模板。你也可以使用默认结构中具有相同键的模板。例如，你可以在表格模板中使用标准段落模板；你也可以用键替换它。
你也可以使用 index.html 将对自定义表格 CSS 样式的引用包含在其中：

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

## **从零开始创建项目：动画幻灯片过渡**

WebExtensions 允许你导出具有动画幻灯片过渡的演示文稿——你只需将 `WebDocumentOptions` 中的 `AnimateTransitions` 属性设置为 `true`：

``` csharp
WebDocumentOptions options = new WebDocumentOptions
{
    // ... 其他选项
    AnimateTransitions = true
};
```

让我们创建一个新项目，使用 Aspose.Slides 和 Aspose.Slides.WebExtensions 创建具有平滑动画页面过渡的 PDF HTML 查看器。在这里，我们需要使用 Aspose.Slides 的 PDF 导入功能。

让我们创建一个 PdfToPresentationToHtml 项目，并添加 Aspose.Slides.WebExtensions NuGet 包（Aspose.Slides 包也将作为依赖项添加）：
![NuGet 包](screen.png)

我们首先导入将被动画化并导出为 HTML 演示文稿的 PDF 文档：

``` csharp
using (Presentation pres = new Presentation())
{
    pres.Slides.RemoveAt(0);
    pres.Slides.AddFromPdf("sample.pdf");
}
```

现在，我们可以设置动画幻灯片过渡（每个幻灯片是导入的 PDF 页面）。我们在示例 PDF 文档中使用了 9 个幻灯片。让我们在其中每个幻灯片中添加幻灯片过渡（在查看 HTML 时的演示）：

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

最后，让我们使用将 `AnimateTransitions` 属性设置为 `true` 的 `WebDocument` 将其导出为 HTML：

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

完整源代码示例：
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

这就是你从 PDF 文档生成带有动画页面过渡的 HTML 所需的一切。

* [下载示例 HTML 文件](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/tree/main/Examples).
* [下载示例项目](/slides/zh/net/web-extensions/sample.zip).