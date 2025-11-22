---
title: 形状操作
type: docs
weight: 40
url: /zh/net/shape-manipulations/
keywords: "PowerPoint 形状, 幻灯片上的形状, 查找形状, 克隆形状, 删除形状, 隐藏形状, 更改形状顺序, 获取 Interop 形状 ID, 形状替代文本, 形状布局格式, 形状为 SVG, 对齐形状, PowerPoint 演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "在 C# 或 .NET 中操作 PowerPoint 形状"
---

## **在幻灯片中查找形状**
本章节将介绍一种简便技术，帮助开发人员在不使用内部 Id 的情况下查找幻灯片上的特定形状。需了解的是，PowerPoint 演示文件只能通过内部唯一 Id 来标识幻灯片上的形状。开发人员直接使用内部唯一 Id 查找形状往往比较困难。所有添加到幻灯片的形状都有一些替代文本（Alt Text）。我们建议开发人员使用替代文本来查找特定形状。您可以使用 MS PowerPoint 为计划以后更改的对象定义替代文本。

在为任意所需形状设置替代文本后，您可以使用 Aspose.Slides for .NET 打开该演示文稿，并遍历幻灯片中添加的所有形状。在每次遍历时检查形状的替代文本，匹配的替代文本即为您需要的形状。为更好地演示此技术，我们创建了一个方法[FindShape](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/findshape/#findshape_1)，它能够在幻灯片中查找特定形状并返回该形状。
```c#
public static void Run()
{
    // 实例化表示演示文件的 Presentation 类
    using (Presentation p = new Presentation("FindingShapeInSlide.pptx"))
    {

        ISlide slide = p.Slides[0];
        // 要查找的形状的替代文本
        IShape shape = FindShape(slide, "Shape1");
        if (shape != null)
        {
            Console.WriteLine("Shape Name: " + shape.Name);
        }
    }
}
        
// 使用替代文本在幻灯片中查找形状的方法实现
public static IShape FindShape(ISlide slide, string alttext)
{
    // 遍历幻灯片中的所有形状
    for (int i = 0; i < slide.Shapes.Count; i++)
    {
        // 如果幻灯片的替代文本与所需的匹配则
        // 返回该形状
        if (slide.Shapes[i].AlternativeText.CompareTo(alttext) == 0)
            return slide.Shapes[i];
    }
    return null;
}
```




## **克隆形状**
使用 Aspose.Slides for .NET 将形状克隆到幻灯片的步骤：

1. 创建[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)类的实例。
1. 使用索引获取幻灯片引用。
1. 访问源幻灯片的形状集合。
1. 向演示文稿添加新幻灯片。
1. 将形状从源幻灯片形状集合克隆到新幻灯片。
1. 将修改后的演示文稿另存为 PPTX 文件。

下面的示例向幻灯片添加了一个组合形状。
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
Aspose.Slides for .NET 允许开发人员删除任意形状。要从任意幻灯片删除形状，请按以下步骤操作：

1. 创建 `Presentation` 类的实例。
1. 访问第一张幻灯片。
1. 查找具有特定 AlternativeText 的形状。
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
String alttext = "User Defined";
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
Aspose.Slides for .NET 允许开发人员隐藏任意形状。要隐藏幻灯片中的形状，请按以下步骤操作：

1. 创建 `Presentation` 类的实例。
1. 访问第一张幻灯片。
1. 查找具有特定 AlternativeText 的形状。
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
String alttext = "User Defined";
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
Aspose.Slides for .NET 允许开发人员重新排列形状。重新排列决定哪个形状位于前面或后面。要重新排列幻灯片中的形状，请按以下步骤操作：

1. 创建 `Presentation` 类的实例。
1. 访问第一张幻灯片。
1. 添加一个形状。
1. 在形状的文本框中添加一些文本。
1. 再添加一个具有相同坐标的形状。
1. 重新排列这些形状。
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
portion.Text="Watermark Text Watermark Text Watermark Text";
shp3 = slide.Shapes.AddAutoShape(ShapeType.Triangle, 200, 365, 400, 150);
slide.Shapes.Reorder(2, shp3);
presentation1.Save( "Reshape_out.pptx", SaveFormat.Pptx);
```



## **获取 Interop 形状 ID**
Aspose.Slides for .NET 允许开发人员获取幻灯片范围内唯一的形状标识符，这与 UniqueId 属性（获取演示文稿范围内的唯一标识符）不同。`OfficeInteropShapeId` 属性已添加到 `IShape` 接口和 `Shape` 类。`OfficeInteropShapeId` 返回的值对应 Microsoft.Office.Interop.PowerPoint.Shape 对象的 Id。以下提供示例代码。
```c#
public static void Run()
{
	using (Presentation presentation = new Presentation("Presentation.pptx"))
	{
		// 获取幻灯片范围内唯一的形状标识符
		long officeInteropShapeId = presentation.Slides[0].Shapes[0].OfficeInteropShapeId;
	}
}
```




## **为形状设置替代文本**
Aspose.Slides for .NET 允许开发人员为任意形状设置 AlternateText。演示文稿中的形状可以通过 AlternativeText 或 Shape Name 属性进行区分。AlternativeText 属性既可以使用 Aspose.Slides 读取，也可以使用 Microsoft PowerPoint 读取或设置。通过此属性，您可以标记形状并执行删除、隐藏或重新排序等不同操作。设置形状的 AlternateText，请按以下步骤操作：

1. 创建 `Presentation` 类的实例。
1. 访问第一张幻灯片。
1. 向幻灯片添加任意形状。
1. 对新添加的形状进行一些操作。
1. 遍历形状以查找目标形状。
1. 设置 AlternativeText。
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
        ashp.AlternativeText = "User Defined";
    }
}

// 将演示文稿保存到磁盘
pres.Save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
```





## **访问形状的布局格式**
Aspose.Slides for .NET 提供了简便的 API 来访问形状的布局格式。本文演示如何访问布局格式。

以下提供示例代码。
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
现在 Aspose.Slides for .NET 支持将形状渲染为 SVG。`WriteAsSvg` 方法（及其重载）已添加到 `Shape` 类和 `IShape` 接口。此方法可将形状内容保存为 SVG 文件。下面的代码片段演示如何将幻灯片的形状导出为 SVG 文件。
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


## **对齐形状**

通过[SlidesUtil.AlignShape()](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/methods/alignshapes/index)的重载方法，您可以

* 相对于幻灯片边距对齐形状。参见示例 1。
* 相互之间对齐形状。参见示例 2。

[ShapesAlignmentType](https://reference.aspose.com/slides/net/aspose.slides/shapesalignmenttype) 枚举定义了可用的对齐选项。

**示例 1**

以下 C# 代码演示如何将索引为 1、2 和 4 的形状对齐到幻灯片顶部边框：
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


**示例 2**

以下 C# 代码演示如何将整个形状集合相对于集合中最底部的形状进行对齐：
``` csharp
using (Presentation pres = new Presentation("example.pptx"))
{
    SlideUtil.AlignShapes(ShapesAlignmentType.AlignBottom, false, pres.Slides[0].Shapes);
}
```


## **翻转属性**

在 Aspose.Slides 中，[ShapeFrame](https://reference.aspose.com/slides/net/aspose.slides/shapeframe/) 类通过 `FlipH` 和 `FlipV` 属性提供对形状水平和垂直镜像的控制。这两个属性的类型为 [NullableBool](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/)，可取 `True`（翻转）、`False`（不翻转）或 `NotDefined`（使用默认行为）。这些值可以通过形状的 [Frame](https://reference.aspose.com/slides/net/aspose.slides/ishape/frame/) 访问。

要修改翻转设置，需要使用形状当前的位置、大小以及期望的 `FlipH`、`FlipV` 值和旋转角度构造一个新的 [ShapeFrame](https://reference.aspose.com/slides/net/aspose.slides/shapeframe/) 实例。将该实例赋给形状的 [Frame](https://reference.aspose.com/slides/net/aspose.slides/ishape/frame/) 并保存演示文稿，即可应用镜像变换并写入输出文件。

假设我们有一个 sample.pptx 文件，其中第一页包含一个默认翻转设置的单一形状，如下所示。

![The shape to be flipped](shape_to_be_flipped.png)

以下代码示例获取形状的当前翻转属性，并同时对其进行水平和垂直翻转。
```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];

    // 检索形状的水平翻转属性。
    NullableBool horizontalFlip = shape.Frame.FlipH;
    Console.WriteLine($"Horizontal flip: {horizontalFlip}");

    // 检索形状的垂直翻转属性。
    NullableBool verticalFlip = shape.Frame.FlipV;
    Console.WriteLine($"Vertical flip: {verticalFlip}");

    float x = shape.Frame.X;
    float y = shape.Frame.Y;
    float width = shape.Frame.Width;
    float height = shape.Frame.Height;
    NullableBool flipH = NullableBool.True; // 水平翻转。
    NullableBool flipV = NullableBool.True; // 垂直翻转。
    float rotation = shape.Frame.Rotation;

    shape.Frame = new ShapeFrame(x, y, width, height, flipH, flipV, rotation);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


结果：

![The flipped shape](flipped_shape.png)

## **FAQ**

**我可以像桌面编辑器那样在幻灯片上合并形状（并集/交集/差集）吗？**

目前没有内置的布尔运算 API。您可以自己构建所需轮廓，例如使用 [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) 计算结果几何形状，然后创建具有该轮廓的新形状，并可选择删除原始形状。

**如何控制堆叠顺序（z‑order），使形状始终位于“最上层”？**

更改幻灯片的 [shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/) 集合中的插入/移动顺序。为获得可预测的结果，请在完成所有其他幻灯片修改后最终确定 z‑order。

**我可以“锁定”形状，以防用户在 PowerPoint 中编辑它吗？**

可以。设置[形状级别的保护标志](/slides/zh/net/applying-protection-to-presentation/)（例如锁定选择、移动、调整大小、文本编辑）。如有需要，可在母版或布局上镜像这些限制。请注意这属于 UI 级别的保护，而非安全特性；若需更强的保护，可结合文件级限制，如[只读建议或密码](/slides/zh/net/password-protected-presentation/)。