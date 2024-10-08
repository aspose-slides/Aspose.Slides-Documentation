---
title: 在演示文稿中更改形状的填充颜色
type: docs
weight: 40
url: /zh/net/change-the-fill-color-of-a-shape-in-a-presentation/
---

## **OpenXML 演示文稿**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Fill color of a shape.pptx";

SetPPTShapeColor(FileName);

// 更改形状的填充颜色。

// 测试文件必须在第一张幻灯片的第一个形状中包含填充形状。

public static void SetPPTShapeColor(string docName)

{

    using (PresentationDocument ppt = PresentationDocument.Open(docName, true))

    {

        // 获取第一张幻灯片的关系 ID。

        PresentationPart part = ppt.PresentationPart;

        OpenXmlElementList slideIds = part.Presentation.SlideIdList.ChildElements;

        string relId = (slideIds[0] as SlideId).RelationshipId;

        // 从关系 ID 获取幻灯片部分。

        SlidePart slide = (SlidePart)part.GetPartById(relId);

        if (slide != null)

        {

            // 获取包含要更改的形状的形状树。

            ShapeTree tree = slide.Slide.CommonSlideData.ShapeTree;

            // 获取形状树中的第一个形状。

            Shape shape = tree.GetFirstChild<Shape>();

            if (shape != null)

            {

                // 获取形状的样式。

                ShapeStyle style = shape.ShapeStyle;

                // 获取填充引用。

                Drawing.FillReference fillRef = style.FillReference;

                // 将填充颜色设置为 SchemeColor Accent 6;

                fillRef.SchemeColor = new Drawing.SchemeColor();

                fillRef.SchemeColor.Val = Drawing.SchemeColorValues.Accent6;

                // 保存修改后的幻灯片。

                slide.Slide.Save();

            }

        }

    }

}

``` 
## **Aspose.Slides**
我们需要遵循以下步骤来填充演示文稿中的形状：

- 创建 Presentation 类的实例。
- 通过使用其索引获取幻灯片的引用。
- 向幻灯片添加 IShape。
- 将形状的填充类型设置为 Solid。
- 设置形状的颜色。
- 将修改后的演示文稿写入 PPTX 文件。

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Fill color of a shape.pptx";

// 实例化表示 PPTX 的 PrseetationEx 类 

using (Presentation pres = new Presentation())

{

    // 获取第一张幻灯片

    ISlide sld = pres.Slides[0];

    // 添加矩形类型的自动形状

    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    // 将填充类型设置为 Solid

    shp.FillFormat.FillType = FillType.Solid;

    // 设置矩形的颜色

    shp.FillFormat.SolidFillColor.Color = Color.Yellow;

    // 将 PPTX 文件写入磁盘

    pres.Save(FileName, SaveFormat.Pptx);

}

``` 
## **下载运行代码示例**
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **示例代码**
- [CodePlex](https://asposeopenxml.codeplex.com/SourceControl/latest#Aspose.Slides VS OpenXML/Apply Theme to Presentation/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Fill%20Color%20of%20a%20Shape)