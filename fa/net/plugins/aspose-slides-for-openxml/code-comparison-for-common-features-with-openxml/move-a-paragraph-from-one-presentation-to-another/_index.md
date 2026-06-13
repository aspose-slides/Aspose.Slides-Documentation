---
title: جابجایی یک پاراگراف از یک ارائه به ارائه دیگر
type: docs
weight: 130
url: /fa/net/move-a-paragraph-from-one-presentation-to-another/
---
## **ارائه OpenXML**
``` csharp

  string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a Paragraph from One Presentation to Another 1.pptx";

string DestFileName = FilePath + "Move a Paragraph from One Presentation to Another 2.pptx";

MoveParagraphToPresentation(FileName, DestFileName);

}

// Moves a paragraph range in a TextBody shape in the source document
// to another TextBody shape in the target document.

public static void MoveParagraphToPresentation(string sourceFile, string targetFile)

{

    // Open the source file as read/write.
    using (PresentationDocument sourceDoc = PresentationDocument.Open(sourceFile, true))
    {

        // Open the target file as read/write.
        using (PresentationDocument targetDoc = PresentationDocument.Open(targetFile, true))
        {

            // Get the first slide in the source presentation.
            SlidePart slide1 = GetFirstSlide(sourceDoc);
            // Get the first TextBody shape in it.
            TextBody textBody1 = slide1.Slide.Descendants<TextBody>().First();
            // Get the first paragraph in the TextBody shape.
            // Note: "Drawing" is the alias of namespace DocumentFormat.OpenXml.Drawing
            Drawing.Paragraph p1 = textBody1.Elements<Drawing.Paragraph>().First();
            // Get the first slide in the target presentation.
            SlidePart slide2 = GetFirstSlide(targetDoc);
            // Get the first TextBody shape in it.
            TextBody textBody2 = slide2.Slide.Descendants<TextBody>().First();
            // Clone the source paragraph and insert the cloned. paragraph into the target TextBody shape.
            // Passing "true" creates a deep clone, which creates a copy of the 
            // Paragraph object and everything directly or indirectly referenced by that object.
            textBody2.Append(p1.CloneNode(true));
            // Remove the source paragraph from the source file.
            textBody1.RemoveChild<Drawing.Paragraph>(p1);
            // Replace the removed paragraph with a placeholder.
            textBody1.AppendChild<Drawing.Paragraph>(new Drawing.Paragraph());
            // Save the slide in the source file.
            slide1.Slide.Save();
            // Save the slide in the target file.
            slide2.Slide.Save();

        }

    }

}

// Get the slide part of the first slide in the presentation document.
public static SlidePart GetFirstSlide(PresentationDocument presentationDocument)

{

    // Get relationship ID of the first slide
    PresentationPart part = presentationDocument.PresentationPart;
    SlideId slideId = part.Presentation.SlideIdList.GetFirstChild<SlideId>();
    string relId = slideId.RelationshipId;

    // Get the slide part by the relationship ID.
    SlidePart slidePart = (SlidePart)part.GetPartById(relId);
    return slidePart;

}
``` 
## **Aspose.Slides**
اغلب مواردی که توسعه‌دهندگان نیاز به استخراج متن از یک ارائه دارند رواج دارد. برای این کار، باید متن را از تمام شکل‌ها در تمام اسلایدهای یک ارائه استخراج کنید. این مقاله توضیح می‌دهد چگونه می‌توانید متن را از ارائه‌های Microsoft PowerPoint با فرمت PPTX با استفاده از Aspose.Slides استخراج کنید. چه بخواهید متن را از یک اسلاید یا کل ارائه استخراج کنید، Aspose.Slides از کلاس PresentationScanner و متدهای استاتیک آن استفاده می‌کند. همه این‌ها تحت فضای‌نام [Aspose.Slides.Util](https://reference.aspose.com/slides/fa/net/aspose.slides.util/slideutil) بسته‌بندی شده‌اند.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a Paragraph from One Presentation to Another 1.pptx";

string DestFileName = FilePath + "Move a Paragraph from One Presentation to Another 2.pptx";

MoveParagraphToPresentation(FileName, DestFileName);

// بازه‌ای از پاراگراف را در یک شکل TextBody در سند منبع جابجا می‌کند
// به شکل TextBody دیگری در سند هدف.

public static void MoveParagraphToPresentation(string sourceFile, string targetFile)

{

    string Text = "";

    //ایجاد شیء Presentation که نمایانگر PPTX است//ایجاد شیء Presentation که نمایانگر PPTX است
    Presentation sourcePres = new Presentation(sourceFile);

    //دسترسی به اولین شکل در اولین اسلاید
    IShape shp = sourcePres.Slides[0].Shapes[0];

    if (shp.Placeholder != null)

    {

        //دریافت متن از جای‌دار
        Text = ((IAutoShape)shp).TextFrame.Text;

        ((IAutoShape)shp).TextFrame.Text = "";

    }

    Presentation destPres = new Presentation(targetFile);

    //دسترسی به اولین شکل در اولین اسلاید
    IShape destshp = sourcePres.Slides[0].Shapes[0];

    if (destshp.Placeholder != null)

    {

        //دریافت متن از جای‌دار
        ((IAutoShape)destshp).TextFrame.Text += Text;

    }

    sourcePres.Save(sourceFile, Aspose.Slides.Export.SaveFormat.Pptx);

    destPres.Save(targetFile, Aspose.Slides.Export.SaveFormat.Pptx);

}

}   
``` 
## **دانلود مثال کد در حال اجرا**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **کد نمونه**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Move%20a%20Paragraph)