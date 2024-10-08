---
title: 添加幻灯片到演示文稿
type: docs
weight: 20
url: /net/adding-slide-to-presentation/
---

## **OpenXML 演示文稿**
在下面的功能中，默认情况下，幻灯片被添加到演示文稿。这里我们在索引 2 上添加了一个包含一些文本的新幻灯片。

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "添加幻灯片到演示文稿.pptx";

InsertNewSlide(FileName, 1, "我的新幻灯片");

// 将幻灯片插入到指定的演示文稿中。

public static void InsertNewSlide(string presentationFile, int position, string slideTitle)

{

    // 以读/写方式打开源文档。 

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        // 将源文档、插入幻灯片的位置和标题传递给下一个方法。

        InsertNewSlide(presentationDocument, position, slideTitle);

    }

}

// 将指定的幻灯片插入到指定位置的演示文稿中。

public static void InsertNewSlide(PresentationDocument presentationDocument, int position, string slideTitle)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    if (slideTitle == null)

    {

        throw new ArgumentNullException("slideTitle");

    }

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // 验证演示文稿是否为空。

    if (presentationPart == null)

    {

        throw new InvalidOperationException("演示文档是空的。");

    }

    // 声明并实例化一个新的幻灯片。

    Slide slide = new Slide(new CommonSlideData(new ShapeTree()));

    uint drawingObjectId = 1;

    // 构造幻灯片内容。            

    // 指定新幻灯片的非视觉属性。

    NonVisualGroupShapeProperties nonVisualProperties = slide.CommonSlideData.ShapeTree.AppendChild(new NonVisualGroupShapeProperties());

    nonVisualProperties.NonVisualDrawingProperties = new NonVisualDrawingProperties() { Id = 1, Name = "" };

    nonVisualProperties.NonVisualGroupShapeDrawingProperties = new NonVisualGroupShapeDrawingProperties();

    nonVisualProperties.ApplicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

    // 指定新幻灯片的组形状属性。

    slide.CommonSlideData.ShapeTree.AppendChild(new GroupShapeProperties());

    // 声明并实例化新幻灯片的标题形状。

    Shape titleShape = slide.CommonSlideData.ShapeTree.AppendChild(new Shape());

    drawingObjectId++;

    // 指定标题形状所需的形状属性。 

    titleShape.NonVisualShapeProperties = new NonVisualShapeProperties

        (new NonVisualDrawingProperties() { Id = drawingObjectId, Name = "标题" },

        new NonVisualShapeDrawingProperties(new Drawing.ShapeLocks() { NoGrouping = true }),

        new ApplicationNonVisualDrawingProperties(new PlaceholderShape() { Type = PlaceholderValues.Title }));

    titleShape.ShapeProperties = new ShapeProperties();

    // 指定标题形状的文本。

    titleShape.TextBody = new TextBody(new Drawing.BodyProperties(),

            new Drawing.ListStyle(),

            new Drawing.Paragraph(new Drawing.Run(new Drawing.Text() { Text = slideTitle })));

    // 声明并实例化新幻灯片的主体形状。

    Shape bodyShape = slide.CommonSlideData.ShapeTree.AppendChild(new Shape());

    drawingObjectId++;

    // 指定主体形状所需的形状属性。

    bodyShape.NonVisualShapeProperties = new NonVisualShapeProperties(new NonVisualDrawingProperties() { Id = drawingObjectId, Name = "内容占位符" },

            new NonVisualShapeDrawingProperties(new Drawing.ShapeLocks() { NoGrouping = true }),

            new ApplicationNonVisualDrawingProperties(new PlaceholderShape() { Index = 1 }));

    bodyShape.ShapeProperties = new ShapeProperties();

    // 指定主体形状的文本。

    bodyShape.TextBody = new TextBody(new Drawing.BodyProperties(),

            new Drawing.ListStyle(),

            new Drawing.Paragraph());

    // 为新幻灯片创建幻灯片部分。

    SlidePart slidePart = presentationPart.AddNewPart<SlidePart>();

    // 保存新幻灯片部分。

    slide.Save(slidePart);

    // 修改演示文稿部分中的幻灯片 ID 列表。

    // 幻灯片 ID 列表不应为空。

    SlideIdList slideIdList = presentationPart.Presentation.SlideIdList;

    // 查找当前列表中最高的幻灯片 ID。

    uint maxSlideId = 1;

    SlideId prevSlideId = null;

    foreach (SlideId slideId in slideIdList.ChildElements)

    {

        if (slideId.Id > maxSlideId)

        {

            maxSlideId = slideId.Id;

        }

        position--;

        if (position == 0)

        {

            prevSlideId = slideId;

        }

    }

    maxSlideId++;

    // 获取上一个幻灯片的 ID。

    SlidePart lastSlidePart;

    if (prevSlideId != null)

    {

        lastSlidePart = (SlidePart)presentationPart.GetPartById(prevSlideId.RelationshipId);

    }

    else

    {

        lastSlidePart = (SlidePart)presentationPart.GetPartById(((SlideId)(slideIdList.ChildElements[0])).RelationshipId);

    }

    // 使用与上一个幻灯片相同的幻灯片布局。

    if (null != lastSlidePart.SlideLayoutPart)

    {

        slidePart.AddPart(lastSlidePart.SlideLayoutPart);

    }

    // 在上一个幻灯片之后将新幻灯片插入到幻灯片列表中。

    SlideId newSlideId = slideIdList.InsertAfter(new SlideId(), prevSlideId);

    newSlideId.Id = maxSlideId;

    newSlideId.RelationshipId = presentationPart.GetIdOfPart(slidePart);

    // 保存修改后的演示文稿。

    presentationPart.Presentation.Save();

}

}

``` 
## **Aspose.Slides**
每个 PowerPoint 演示文稿文件包含一个 **主母版幻灯片** 和其他 **普通幻灯片**。这意味着演示文稿文件至少包含一张或多张幻灯片。重要的是要知道，没有幻灯片的演示文稿文件不受 Aspose.Slides for .NET 的支持。每张幻灯片都有特定的位置和 **唯一 ID**。**幻灯片 ID** 可以在母版幻灯片中范围从 0 到 255，在普通幻灯片中范围从 256 到 65535。

Aspose.Slides for .NET 允许开发人员使用 **Presentation** 对象暴露的 **AddEmptySlide** 方法向演示文稿中添加空幻灯片。要在演示文稿中添加空幻灯片，请按照以下步骤操作：

- 创建 Presentation 类的实例
- 调用 Presentation 对象暴露的 AddEmptySlide 方法
- 对新添加的空幻灯片进行操作
- 添加另一张幻灯片并在其上插入文本。
- 最后，使用 Presentation 对象暴露的 Write 方法写入 PPT 文件

``` csharp

 string FileName = FilePath + "添加幻灯片到演示文稿.pptx";

// 实例化表示 PPT 文件的 PresentationEx 类

Presentation pres = new Presentation();

// 当您从默认构造函数创建演示文稿时，会默认添加空白幻灯片

// 向演示文稿添加空幻灯片并获取该空幻灯片的引用

ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

// 将输出写入磁盘

pres.Save(FileName,Aspose.Slides.Export.SaveFormat.Pptx);

``` 
## **下载示例代码**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/)