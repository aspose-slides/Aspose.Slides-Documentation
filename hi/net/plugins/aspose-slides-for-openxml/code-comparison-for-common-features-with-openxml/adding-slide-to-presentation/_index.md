---
title: स्लाइड को प्रस्तुति में जोड़ना
type: docs
weight: 20
url: /hi/net/adding-slide-to-presentation/
---
## **OpenXML प्रस्तुति**
नीचे की कार्यक्षमता में डिफ़ॉल्ट रूप से एक स्लाइड प्रस्तुति में जोड़ी जाती है। यहाँ हम इंडेक्स 2 पर एक नई स्लाइड जोड़ रहे हैं जिसमें कुछ टेक्स्ट है।

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
प्रत्येक PowerPoint प्रस्तुति फ़ाइल में एक **मुख्य मास्टर स्लाइड** और अन्य **सामान्य स्लाइड्स** होती हैं। इसका मतलब है कि एक प्रस्तुति फ़ाइल में कम से कम एक या अधिक स्लाइड्स होते हैं। यह जानना महत्वपूर्ण है कि स्लाइड्स के बिना प्रस्तुतियों को Aspose.Slides for .NET द्वारा समर्थित नहीं किया जाता। प्रत्येक स्लाइड का एक विशिष्ट स्थान और एक **अद्वितीय Id** होता है। **स्लाइड Id** मास्टर स्लाइड्स के लिए 0 से 255 तक और सामान्य स्लाइड्स के लिए 256 से 65535 तक हो सकता है।

Aspose.Slides for .NET डेवलपर्स को **Presentation** ऑब्जेक्ट द्वारा प्रदत्त **AddEmptySlide** मेथड का उपयोग करके प्रस्तुतियों में खाली स्लाइड्स जोड़ने की अनुमति देता है। प्रस्तुति में एक खाली स्लाइड जोड़ने के लिए, नीचे दिए गए चरणों का पालन करें:

- Presentation क्लास का एक इंस्टेंस बनाएं
- Presentation ऑब्जेक्ट द्वारा प्रदत्त AddEmptySlide मेथड को कॉल करें
- नई जोड़ी गई खाली स्लाइड के साथ कुछ काम करें
- एक और स्लाइड जोड़ें और उस पर टेक्स्ट डालें।
- अंत में, Presentation ऑब्जेक्ट द्वारा प्रदत्त Write मेथड का उपयोग करके PPT फ़ाइल को लिखें

``` csharp

 string FileName = FilePath + "Adding Slide to Presentation.pptx";

//PresentationEx क्लास को इंस्टैंसिएट करें जो PPT फ़ाइल का प्रतिनिधित्व करता है
Presentation pres = new Presentation();

//डिफ़ॉल्ट रूप से एक खाली स्लाइड जोड़ी जाती है, जब आप बनाते हैं
//डिफ़ॉल्ट कन्स्ट्रक्टर से प्रस्तुति
//प्रस्तुति में एक खाली स्लाइड जोड़ना और उसका रेफ़रेंस प्राप्त करना
//उस खाली स्लाइड का
ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

//आउटपुट को डिस्क पर लिखें
pres.Save(FileName,Aspose.Slides.Export.SaveFormat.Pptx);
``` 
## **नमूना कोड डाउनलोड करें**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/)