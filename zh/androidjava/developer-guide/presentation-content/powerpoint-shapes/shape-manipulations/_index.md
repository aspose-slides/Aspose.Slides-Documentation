---
title: 形状操作
type: docs
weight: 40
url: /androidjava/shape-manipulations/
---

## **在幻灯片中查找形状**
本主题将描述一种简单的技术，以帮助开发人员在幻灯片上查找特定形状，而无需使用其内部 ID。重要的是要知道 PowerPoint 演示文稿文件除了使用内部唯一 ID 外，没有其他方法来识别幻灯片上的形状。似乎开发人员使用其内部唯一 ID 查找形状具有一定的困难。添加到幻灯片上的所有形状都有一些替代文本。我们建议开发人员使用替代文本来查找特定形状。您可以使用 MS PowerPoint 为您计划将来更改的对象定义替代文本。

在设置完任何所需形状的替代文本后，您可以通过 Java 使用 Aspose.Slides for Android 打开该演示文稿，并遍历添加到幻灯片的所有形状。在每次迭代中，您可以检查形状的替代文本，具有匹配替代文本的形状就是您所需的形状。为了更好地演示此技术，我们创建了一个方法，[findShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-)，它能够在幻灯片中找到特定形状并简单返回该形状。

```java
// 实例化表示演示文稿文件的 Presentation 类
Presentation pres = new Presentation("FindingShapeInSlide.pptx");
try {

    ISlide slide = pres.getSlides().get_Item(0);
    // 要查找的形状的替代文本
    IShape shape = findShape(slide, "Shape1");
    if (shape != null)
    {
        System.out.println("形状名称: " + shape.getName());
    }
} finally {
    if (pres != null) pres.dispose();
}
```
```java
// 使用其替代文本查找幻灯片中形状的实现方法
public static IShape findShape(ISlide slide, String alttext)
{
    // 在幻灯片内部遍历所有形状
    for (int i = 0; i < slide.getShapes().size(); i++)
    {
        // 如果幻灯片的替代文本与所需文本匹配
        // 返回该形状
        if (slide.getShapes().get_Item(i).getAlternativeText().compareTo(alttext) == 0)
            return slide.getShapes().get_Item(i);
    }
    return null;
}
```

## **克隆形状**
要使用 Aspose.Slides for Android 通过 Java 将形状克隆到幻灯片：

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
1. 通过使用其索引获取幻灯片的引用。
1. 访问源幻灯片形状集合。
1. 向演示文稿中添加新幻灯片。
1. 从源幻灯片形状集合克隆形状到新幻灯片。
1. 将修改后的演示文稿保存为 PPTX 文件。

下面的示例在幻灯片中添加一个组合形状。

```java
// 实例化 Presentation 类
Presentation pres = new Presentation("Source Frame.pptx");
try {
    IShapeCollection sourceShapes = pres.getSlides().get_Item(0).getShapes();
    ILayoutSlide blankLayout = pres.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank);
    ISlide destSlide = pres.getSlides().addEmptySlide(blankLayout);
    IShapeCollection destShapes = destSlide.getShapes();
    destShapes.addClone(sourceShapes.get_Item(1), 50, 150 + sourceShapes.get_Item(0).getHeight());
    destShapes.addClone(sourceShapes.get_Item(2));
    destShapes.insertClone(0, sourceShapes.get_Item(0), 50, 150);

    // 将 PPTX 文件写入磁盘
    pres.save("CloneShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **移除形状**
Aspose.Slides for Android 通过 Java 允许开发人员移除任何形状。要从任何幻灯片中移除形状，请按照以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
1. 访问第一张幻灯片。
1. 查找具有特定替代文本的形状。
1. 移除该形状。
1. 将文件保存到磁盘。

```java
// 创建 Presentation 对象
Presentation pres = new Presentation();
try {
    // 获取第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);

    // 添加矩形类型的自动形状
    sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);

    String altText = "用户定义";
    int iCount = sld.getShapes().size();
    for (int i = 0; i < iCount; i++)
    {
        AutoShape ashp = (AutoShape)sld.getShapes().get_Item(0);
        if (altText.equals(ashp.getAlternativeText()))
        {
            sld.getShapes().remove(ashp);
        }
    }

    // 将演示文稿保存到磁盘
    pres.save("RemoveShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **隐藏形状**
Aspose.Slides for Android 通过 Java 允许开发人员隐藏任何形状。要从任何幻灯片中隐藏形状，请按照以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
1. 访问第一张幻灯片。
1. 查找具有特定替代文本的形状。
1. 隐藏该形状。
1. 将文件保存到磁盘。

```java
// 实例化表示 PPTX 的 Presentation 类
Presentation pres = new Presentation();
try {
    // 获取第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);

    // 添加矩形类型的自动形状
    sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);

    String altText = "用户定义";
    int iCount = sld.getShapes().size();
    for (int i = 0; i < iCount; i++)
    {
        AutoShape ashp = (AutoShape)sld.getShapes().get_Item(i);
        if (altText.equals(ashp.getAlternativeText()))
        {
            ashp.setHidden(true);
        }
    }

    // 将演示文稿保存到磁盘
    pres.save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **更改形状顺序**
Aspose.Slides for Android 通过 Java 允许开发人员重新排列形状。重新排列形状指定哪个形状在前面，哪个形状在后面。要从任何幻灯片中重新排列形状，请按照以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
1. 访问第一张幻灯片。
1. 添加形状。
1. 在形状的文本框中添加一些文本。
1. 以相同的坐标添加另一个形状。
1. 重新排列形状。
1. 将文件保存到磁盘。

```java
Presentation pres = new Presentation("ChangeShapeOrder.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape shp3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 365, 400, 150);
    shp3.getFillFormat().setFillType(FillType.NoFill);
    shp3.addTextFrame(" ");

    IParagraph para = shp3.getTextFrame().getParagraphs().get_Item(0);
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("水印文本 水印文本 水印文本");

    shp3 = slide.getShapes().addAutoShape(ShapeType.Triangle, 200, 365, 400, 150);

    slide.getShapes().reorder(2, shp3);

    pres.save("Reshape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **获取互操作形状 ID**
Aspose.Slides for Android 通过 Java 允许开发人员获取幻灯片范围内的唯一形状标识符，与 [getUniqueId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getUniqueId--) 方法相对，该方法允许获取演示文稿范围内的唯一标识符。方法 [getOfficeInteropShapeId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getOfficeInteropShapeId--) 被添加到 [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) 接口和 [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Shape) 类中。通过 [getOfficeInteropShapeId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getOfficeInteropShapeId--) 方法返回的值对应于 Microsoft.Office.Interop.PowerPoint.Shape 对象的 ID 值。以下是给出的示例代码。

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // 获取幻灯片范围内的唯一形状标识符
    long officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();

} finally {
    if (pres != null) pres.dispose();
}
```

## **为形状设置替代文本**
Aspose.Slides for Android 通过 Java 允许开发人员为任何形状设置替代文本。在演示文稿中的形状可以通过 [AlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) 或 [形状名称](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setName-java.lang.String-) 方法来区分。
[setAlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) 和 [getAlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getAlternativeText--) 方法可以通过 Aspose.Slides 以及 Microsoft PowerPoint 进行读取或设置。
通过使用此方法，您可以标记形状并执行不同的操作，例如移除形状、隐藏形状或重新排序幻灯片上的形状。
要设置形状的替代文本，请按照以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
1. 访问第一张幻灯片。
1. 向幻灯片添加任何形状。
1. 对新添加的形状进行一些操作。
1. 遍历形状以查找某个形状。
1. 设置替代文本。
1. 将文件保存到磁盘。

```java
// 实例化表示 PPTX 的 Presentation 类
Presentation pres = new Presentation();
try {
    // 获取第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);

    // 添加矩形类型的自动形状
    IShape shp1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    IShape shp2 = sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);
    shp2.getFillFormat().setFillType(FillType.Solid);
    shp2.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    for (int i = 0; i < sld.getShapes().size(); i++)
    {
        AutoShape shape = (AutoShape) sld.getShapes().get_Item(i);
        if (shape != null)
        {
            shape.setAlternativeText("用户定义");
        }
    }

    // 将演示文稿保存到磁盘
    pres.save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **访问形状的布局格式**
Aspose.Slides for Android 通过 Java 提供了简单的 API 来访问形状的布局格式。本文演示了如何访问布局格式。

以下是给出的示例代码。

```java
Presentation pres = new Presentation("pres.pptx");
try {
    for (ILayoutSlide layoutSlide : pres.getLayoutSlides())
    {
        for (IShape shape : layoutSlide.getShapes())
        {
            IFillFormat fillFormats = shape.getFillFormat();
            ILineFormat lineFormats = shape.getLineFormat();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **将形状渲染为 SVG**
现在，Aspose.Slides for Android 通过 Java 支持将形状渲染为 SVG。方法 [writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#writeAsSvg-java.io.OutputStream-)（及其重载）已被添加到 [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Shape) 类和 [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) 接口。此方法允许将形状内容保存为 SVG 文件。下面的代码片段显示如何将幻灯片的形状导出到 SVG 文件。

```java
Presentation pres = new Presentation("TestExportShapeToSvg.pptx");
try {
    FileOutputStream stream = new FileOutputStream("SingleShape.svg");
    try {
        pres.getSlides().get_Item(0).getShapes().get_Item(0).writeAsSvg(stream);
    } finally {
        if (stream != null) stream.close();
    }
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **形状对齐**
Aspose.Slides 允许对形状进行对齐，可以相对于幻灯片边距，也可以相对于彼此。为此，添加了重载方法 [SlidesUtil.alignShape()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-)。枚举 [ShapesAlignmentType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapesAlignmentType) 定义了可用的对齐选项。

**示例 1**

下面的源代码将索引为 1、2 和 4 的形状对齐到幻灯片的顶部边框。

```java
Presentation pres = new Presentation("example.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IShape shape1 = slide.getShapes().get_Item(1);
    IShape shape2 = slide.getShapes().get_Item(2);
    IShape shape3 = slide.getShapes().get_Item(4);
    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, true, pres.getSlides().get_Item(0), new int[]
    {
        slide.getShapes().indexOf(shape1),
        slide.getShapes().indexOf(shape2),
        slide.getShapes().indexOf(shape3)
    });
} finally {
    if (pres != null) pres.dispose();
}
```

**示例 2**

下面的示例展示了如何相对于集合中的最底部形状对齐整个形状集合。

```java
Presentation pres = new Presentation("example.pptx");
try {
    SlideUtil.alignShapes(ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) pres.dispose();
}
```