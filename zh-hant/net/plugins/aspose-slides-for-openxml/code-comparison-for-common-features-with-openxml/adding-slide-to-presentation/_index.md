---
title: 將投影片加入簡報
type: docs
weight: 20
url: /zh-hant/net/adding-slide-to-presentation/
---
## **OpenXML 簡報**
在以下功能中，預設會向簡報新增一張投影片。此處我們在索引 2 位置加入新投影片，並在其中加入一些文字。

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Adding Slide to Presentation.pptx";

InsertNewSlide(FileName, 1, "My new slide");

// Insert a slide into the specified presentation.

public static void InsertNewSlide(string presentationFile, int position, string slideTitle)

{

    // Open the source document as read/write. 

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        // Pass the source document and the position and title of the slide to be inserted to the next method.

        InsertNewSlide(presentationDocument, position, slideTitle);

    }

}

// Insert the specified slide into the presentation at the specified position.

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

    // Verify that the presentation is not empty.

    if (presentationPart == null)

    {

        throw new InvalidOperationException("The presentation document is empty.");

    }

    // Declare and instantiate a new slide.

    Slide slide = new Slide(new CommonSlideData(new ShapeTree()));

    uint drawingObjectId = 1;

    // Construct the slide content.            

    // Specify the non-visual properties of the new slide.

    NonVisualGroupShapeProperties nonVisualProperties = slide.CommonSlideData.ShapeTree.AppendChild(new NonVisualGroupShapeProperties());

    nonVisualProperties.NonVisualDrawingProperties = new NonVisualDrawingProperties() { Id = 1, Name = "" };

    nonVisualProperties.NonVisualGroupShapeDrawingProperties = new NonVisualGroupShapeDrawingProperties();

    nonVisualProperties.ApplicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

    // Specify the group shape properties of the new slide.

    slide.CommonSlideData.ShapeTree.AppendChild(new GroupShapeProperties());

    // Declare and instantiate the title shape of the new slide.

    Shape titleShape = slide.CommonSlideData.ShapeTree.AppendChild(new Shape());

    drawingObjectId++;

    // Specify the required shape properties for the title shape. 

    titleShape.NonVisualShapeProperties = new NonVisualShapeProperties

        (new NonVisualDrawingProperties() { Id = drawingObjectId, Name = "Title" },

        new NonVisualShapeDrawingProperties(new Drawing.ShapeLocks() { NoGrouping = true }),

        new ApplicationNonVisualDrawingProperties(new PlaceholderShape() { Type = PlaceholderValues.Title }));

    titleShape.ShapeProperties = new ShapeProperties();

    // Specify the text of the title shape.

    titleShape.TextBody = new TextBody(new Drawing.BodyProperties(),

            new Drawing.ListStyle(),

            new Drawing.Paragraph(new Drawing.Run(new Drawing.Text() { Text = slideTitle })));

    // Declare and instantiate the body shape of the new slide.

    Shape bodyShape = slide.CommonSlideData.ShapeTree.AppendChild(new Shape());

    drawingObjectId++;

    // Specify the required shape properties for the body shape.

    bodyShape.NonVisualShapeProperties = new NonVisualShapeProperties(new NonVisualDrawingProperties() { Id = drawingObjectId, Name = "Content Placeholder" },

            new NonVisualShapeDrawingProperties(new Drawing.ShapeLocks() { NoGrouping = true }),

            new ApplicationNonVisualDrawingProperties(new PlaceholderShape() { Index = 1 }));

    bodyShape.ShapeProperties = new ShapeProperties();

    // Specify the text of the body shape.

    bodyShape.TextBody = new TextBody(new Drawing.BodyProperties(),

            new Drawing.ListStyle(),

            new Drawing.Paragraph());

    // Create the slide part for the new slide.

    SlidePart slidePart = presentationPart.AddNewPart<SlidePart>();

    // Save the new slide part.

    slide.Save(slidePart);

    // Modify the slide ID list in the presentation part.

    // The slide ID list should not be null.

    SlideIdList slideIdList = presentationPart.Presentation.SlideIdList;

    // Find the highest slide ID in the current list.

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

    // Get the ID of the previous slide.

    SlidePart lastSlidePart;

    if (prevSlideId != null)

    {

        lastSlidePart = (SlidePart)presentationPart.GetPartById(prevSlideId.RelationshipId);

    }

    else

    {

        lastSlidePart = (SlidePart)presentationPart.GetPartById(((SlideId)(slideIdList.ChildElements[0])).RelationshipId);

    }

    // Use the same slide layout as that of the previous slide.

    if (null != lastSlidePart.SlideLayoutPart)

    {

        slidePart.AddPart(lastSlidePart.SlideLayoutPart);

    }

    // Insert the new slide into the slide list after the previous slide.

    SlideId newSlideId = slideIdList.InsertAfter(new SlideId(), prevSlideId);

    newSlideId.Id = maxSlideId;

    newSlideId.RelationshipId = presentationPart.GetIdOfPart(slidePart);

    // Save the modified presentation.

    presentationPart.Presentation.Save();

}

}
``` 
## **Aspose.Slides**
每個 PowerPoint 簡報檔案包含一個 **Main Master slide** 和其他 **Normal slides**。這表示簡報檔案至少包含一張或多張投影片。需要注意的是，不含投影片的簡報檔案不受 Aspose.Slides for .NET 支援。每張投影片都有特定的位置以及 **unique Id**。**slide Id** 的範圍對於母片投影片為 0 到 255，對於一般投影片則為 256 到 65535。

Aspose.Slides for .NET 允許開發人員使用 **Presentation** 物件所提供的 **AddEmptySlide** 方法向簡報加入空白投影片。若要在簡報中加入空白投影片，請遵循以下步驟：

- 建立 Presentation 類別的實例
- 呼叫 Presentation 物件所提供的 AddEmptySlide 方法
- 對新加入的空白投影片執行一些操作
- 再加入一張投影片並在其上插入文字。
- 最後，使用 Presentation 物件所提供的 Write 方法寫入 PPT 檔案

``` csharp

 string FileName = FilePath + "Adding Slide to Presentation.pptx";
//實例化 PresentationEx 類別以表示 PPT 檔案
Presentation pres = new Presentation();
//建立簡報時會預設加入空白投影片，
//使用預設建構函式
//將空白投影片加入簡報，並取得該投影片的參考
//該空白投影片
ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
//將輸出寫入磁碟
pres.Save(FileName,Aspose.Slides.Export.SaveFormat.Pptx);

``` 
## **下載範例程式碼**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/)