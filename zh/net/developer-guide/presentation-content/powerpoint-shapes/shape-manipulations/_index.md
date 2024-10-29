---
title: 形状操作
type: docs
weight: 40
url: /zh/net/shape-manipulations/
keywords: "PowerPoint 形状, 幻灯片上的形状, 查找形状, 克隆形状, 删除形状, 隐藏形状, 更改形状顺序, 获取 interop 形状 ID, 形状替代文本, 形状布局格式, 将形状作为 SVG, 对齐形状, PowerPoint 演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "在 C# 或 .NET 中操作 PowerPoint 形状"
---

## **在幻灯片中查找形状**
本主题将描述一种简单的技术，使开发人员更容易查找幻灯片上的特定形状，而无需使用其内部 ID。重要的是要知道 PowerPoint 演示文稿文件没有任何方法来识别幻灯片上的形状，除了内部唯一 ID。开发人员似乎很难使用其内部唯一 ID 查找形状。添加到幻灯片的所有形状都有一些替代文本。我们建议开发人员使用替代文本来查找特定的形状。您可以使用 MS PowerPoint 为您计划在将来更改的对象定义替代文本。

在设置任何所需形状的替代文本后，您可以使用 Aspose.Slides for .NET 打开该演示文稿并遍历添加到幻灯片的所有形状。在每次迭代中，您可以检查该形状的替代文本，并且具有匹配替代文本的形状将是您所需的形状。为了更好地演示此技术，我们创建了一个方法，[FindShape](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/findshape/#findshape_1)，该方法可以找到幻灯片中的特定形状，然后简单地返回该形状。

```c#
public static void Run()
{
    // 实例化表示演示文稿文件的 Presentation 类
    using (Presentation p = new Presentation("FindingShapeInSlide.pptx"))
    {

        ISlide slide = p.Slides[0];
        // 要查找的形状的替代文本
        IShape shape = FindShape(slide, "Shape1");
        if (shape != null)
        {
            Console.WriteLine("形状名称: " + shape.Name);
        }
    }
}
        
// 使用其替代文本在幻灯片中查找形状的方法实现
public static IShape FindShape(ISlide slide, string alttext)
{
    // 遍历幻灯片中的所有形状
    for (int i = 0; i < slide.Shapes.Count; i++)
    {
        // 如果幻灯片的替代文本与所需的匹配，则
        // 返回该形状
        if (slide.Shapes[i].AlternativeText.CompareTo(alttext) == 0)
            return slide.Shapes[i];
    }
    return null;
}
```



## **克隆形状**
要使用 Aspose.Slides for .NET 将形状克隆到幻灯片中：

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 使用其索引获取幻灯片的引用。
1. 访问源幻灯片形状集合。
1. 向演示文稿添加新幻灯片。
1. 将形状从源幻灯片形状集合克隆到新幻灯片。
1. 将修改后的演示文稿保存为 PPTX 文件。

下面的示例将一个组合形状添加到幻灯片。

```c#
// 实例化 Presentation 类
using (Presentation srcPres = new Presentation("Source Frame.pptx"))
{
	IShapeCollection sourceShapes = srcPres.Slides[0].Shapes;
	ILayoutSlide blankLayout = srcPres.Masters[0].LayoutSlides.GetByType(SlideLayoutType.Blank);
	ISlide destSlide = srcPres.Slides.AddEmptySlide(blankLayout);
	IShapeCollection destShapes = destSlide.Shapes;
	destShapes.AddClone(sourceShapes[1], 50, 150 + sourceShapes[0].Height);
	destShapes.AddClone(sourceShapes[2]);                 
	destShapes.InsertClone(0, sourceShapes[0], 50, 150);

	// 将 PPTX 文件写入磁盘
	srcPres.Save("CloneShape_out.pptx", SaveFormat.Pptx);
}
```



## **删除形状**
Aspose.Slides for .NET 允许开发人员删除任何形状。要从任何幻灯片中删除形状，请按照以下步骤操作：

1. 创建 `Presentation` 类的实例。
1. 访问第一张幻灯片。
1. 查找具有特定替代文本的形状。
1. 删除该形状。
1. 将文件保存到磁盘。

```c#
// 创建 Presentation 对象
Presentation pres = new Presentation();

// 获取第一张幻灯片
ISlide sld = pres.Slides[0];

// 添加矩形类型的自动形状
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
String alttext = "用户定义";
int iCount = sld.Shapes.Count;
for (int i = 0; i < iCount; i++)
{
    AutoShape ashp = (AutoShape)sld.Shapes[0];
    if (String.Compare(ashp.AlternativeText, alttext, StringComparison.Ordinal) == 0)
    {
        sld.Shapes.Remove(ashp);
    }
}

// 将演示文稿保存到磁盘
pres.Save("RemoveShape_out.pptx", SaveFormat.Pptx);
```



## **隐藏形状**
Aspose.Slides for .NET 允许开发人员隐藏任何形状。要从任何幻灯片中隐藏形状，请按照以下步骤操作：

1. 创建 `Presentation` 类的实例。
1. 访问第一张幻灯片。
1. 查找具有特定替代文本的形状。
1. 隐藏该形状。
1. 将文件保存到磁盘。

```c#
// 实例化表示 PPTX 的 Presentation 类
Presentation pres = new Presentation();

// 获取第一张幻灯片
ISlide sld = pres.Slides[0];

// 添加矩形类型的自动形状
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
String alttext = "用户定义";
int iCount = sld.Shapes.Count;
for (int i = 0; i < iCount; i++)
{
	AutoShape ashp = (AutoShape)sld.Shapes[i];
	if (String.Compare(ashp.AlternativeText, alttext, StringComparison.Ordinal) == 0)
	{
		ashp.Hidden = true;
	}
}

// 将演示文稿保存到磁盘
pres.Save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
```



## **更改形状顺序**
Aspose.Slides for .NET 允许开发人员重新排序形状。重新排序形状指定哪个形状在前面或哪个形状在后面。要重新排序任何幻灯片上的形状，请按照以下步骤操作：

1. 创建 `Presentation` 类的实例。
1. 访问第一张幻灯片。
1. 添加一个形状。
1. 在形状的文本框中添加一些文本。
1. 添加另一个具有相同坐标的形状。
1. 重新排序形状。
1. 将文件保存到磁盘。

```c#
Presentation presentation1 = new Presentation("HelloWorld.pptx");
ISlide slide = presentation1.Slides[0];
IAutoShape shp3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 365, 400, 150);
shp3.FillFormat.FillType = FillType.NoFill;
shp3.AddTextFrame(" ");

ITextFrame txtFrame = shp3.TextFrame;
IParagraph para = txtFrame.Paragraphs[0];
IPortion portion = para.Portions[0];
portion.Text="水印文本 水印文本 水印文本";
shp3 = slide.Shapes.AddAutoShape(ShapeType.Triangle, 200, 365, 400, 150);
slide.Shapes.Reorder(2, shp3);
presentation1.Save( "Reshape_out.pptx", SaveFormat.Pptx);
```


## **获取 Interop 形状 ID**
Aspose.Slides for .NET 允许开发人员在幻灯片范围内获取唯一的形状标识符，区别于 UniqueId 属性，它允许获取演示文稿范围内的唯一标识符。属性 OfficeInteropShapeId 被添加到 IShape 接口和 Shape 类。OfficeInteropShapeId 属性返回的值对应于 Microsoft.Office.Interop.PowerPoint.Shape 对象的 Id 值。下面是一个示例代码。

```c#
public static void Run()
{
	using (Presentation presentation = new Presentation("Presentation.pptx"))
	{
		// 获取幻灯片范围内的唯一形状标识符
		long officeInteropShapeId = presentation.Slides[0].Shapes[0].OfficeInteropShapeId;
	}
}
```



## **设置形状的替代文本**
Aspose.Slides for .NET 允许开发人员设置任何形状的替代文本。 
在演示文稿中的形状可以通过替代文本或形状名称属性来区分。 
替代文本属性可以通过使用 Aspose.Slides 以及 Microsoft PowerPoint 进行读取或设置。 
使用此属性，您可以标记形状并执行不同的操作，如删除形状、 
隐藏形状或在幻灯片上重新排序形状。
要设置形状的替代文本，请按照以下步骤操作：

1. 创建 `Presentation` 类的实例。
1. 访问第一张幻灯片。
1. 向幻灯片添加任何形状。
1. 对新添加的形状执行一些操作。
1. 遍历形状以查找形状。
1. 设置替代文本。
1. 将文件保存到磁盘。

```c#
// 实例化表示 PPTX 的 Presentation 类
Presentation pres = new Presentation();

// 获取第一张幻灯片
ISlide sld = pres.Slides[0];

// 添加矩形类型的自动形状
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
shp2.FillFormat.FillType = FillType.Solid;
shp2.FillFormat.SolidFillColor.Color = Color.Gray;

for (int i = 0; i < sld.Shapes.Count; i++)
{
    var shape = sld.Shapes[i] as AutoShape;
    if (shape != null)
    {
        AutoShape ashp = shape;
        ashp.AlternativeText = "用户定义";
    }
}

// 将演示文稿保存到磁盘
pres.Save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
```




## **访问形状的布局格式**
 Aspose.Slides for .NET 提供了一个简单的 API 来访问形状的布局格式。 本文演示了您如何访问布局格式。

下面的示例代码。

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
	foreach (ILayoutSlide layoutSlide in pres.LayoutSlides)
	{
		IFillFormat[] fillFormats = layoutSlide.Shapes.Select(shape => shape.FillFormat).ToArray();
		ILineFormat[] lineFormats = layoutSlide.Shapes.Select(shape => shape.LineFormat).ToArray();
	}
}
```

## **将形状渲染为 SVG**
现在 Aspose.Slides for .NET 支持将形状渲染为 svg。 将 WriteAsSvg 方法（及其重载）添加到 Shape 类和 IShape 接口。 此方法允许将形状的内容保存为 SVG 文件。 下面的代码片段显示了如何将幻灯片的形状导出为 SVG 文件。

```c#
public static void Run()
{
	string outSvgFileName = "SingleShape.svg";
	using (Presentation pres = new Presentation("TestExportShapeToSvg.pptx"))
	{
		using (Stream stream = new FileStream(outSvgFileName, FileMode.Create, FileAccess.Write))
		{
			pres.Slides[0].Shapes[0].WriteAsSvg(stream);
		}
	}
}
```

## 对齐形状

通过 [SlidesUtil.AlignShape()](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/methods/alignshapes/index) 重载方法，您可以 

* 相对于幻灯片的边距对齐形状。请参见示例 1。 
* 相互对齐形状。请参见示例 2。 

[ShapesAlignmentType](https://reference.aspose.com/slides/net/aspose.slides/shapesalignmenttype) 枚举定义了可用的对齐选项。

### 示例 1

此 C# 代码向您展示如何将索引为 1、2 和 4 的形状沿幻灯片的顶部边界对齐：
下面的源代码将索引为 1、2 和 4 的形状对齐到幻灯片的上边界。 

``` csharp
using (Presentation pres = new Presentation("example.pptx"))
{
     ISlide slide = pres.Slides[0];
     IShape shape1 = slide.Shapes[1];
     IShape shape2 = slide.Shapes[2];
     IShape shape3 = slide.Shapes[4];
     SlideUtil.AlignShapes(ShapesAlignmentType.AlignTop, true, pres.Slides[0], new int[]
     {
          slide.Shapes.IndexOf(shape1),
          slide.Shapes.IndexOf(shape2),
          slide.Shapes.IndexOf(shape3)
     });
}
```

### 示例 2

此 C# 代码向您展示如何相对于集合中的底部形状对齐整个形状集合：

``` csharp
using (Presentation pres = new Presentation("example.pptx"))
{
    SlideUtil.AlignShapes(ShapesAlignmentType.AlignBottom, false, pres.Slides[0].Shapes);
}
```