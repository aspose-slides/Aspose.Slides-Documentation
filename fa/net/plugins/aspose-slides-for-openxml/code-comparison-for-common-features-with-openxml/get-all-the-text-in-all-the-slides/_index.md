---
title: دریافت تمام متن‌ها در همه اسلایدها
type: docs
weight: 100
url: /fa/net/get-all-the-text-in-all-the-slides/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the text in a slide.pptx";

int numberOfSlides = CountSlides(FileName);

System.Console.WriteLine("Number of slides = {0}", numberOfSlides);

string slideText;

for (int i = 0; i < numberOfSlides; i++)

{

GetSlideIdAndText(out slideText, FileName, i);

System.Console.WriteLine("Slide #{0} contains: {1}", i + 1, slideText);

}

System.Console.ReadKey();

public static int CountSlides(string presentationFile)

{

    // ارائه را به‌صورت فقط‑خواندنی باز کنید.
    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))
    {
        // ارائه را به متد CountSlides بعدی ارسال کنید
        // و تعداد اسلایدها را برگردانید.
        return CountSlides(presentationDocument);
    }

}

// تعداد اسلایدها را در ارائه شمارش کنید.
public static int CountSlides(PresentationDocument presentationDocument)
{
    // بررسی کنید که شیء سند تهی (null) باشد یا نه.
    if (presentationDocument == null)
    {
        throw new ArgumentNullException("presentationDocument");
    }
    int slidesCount = 0;
    // بخش ارائه سند را دریافت کنید.
    PresentationPart presentationPart = presentationDocument.PresentationPart;
    // تعداد اسلایدها را از SlideParts دریافت کنید.
    if (presentationPart != null)
    {
        slidesCount = presentationPart.SlideParts.Count();
    }
    // تعداد اسلایدها را به متد قبلی برگردانید.
    return slidesCount;
}

public static void GetSlideIdAndText(out string sldText, string docName, int index)
{
    using (PresentationDocument ppt = PresentationDocument.Open(docName, false))
    {
        // شناسه‌ی رابطه (Relationship ID) اولین اسلاید را دریافت کنید.
        PresentationPart part = ppt.PresentationPart;
        OpenXmlElementList slideIds = part.Presentation.SlideIdList.ChildElements;
        string relId = (slideIds[index] as SlideId).RelationshipId;
        // بخش اسلاید را با استفاده از شناسه‌ی رابطه دریافت کنید.
        SlidePart slide = (SlidePart)part.GetPartById(relId);
        // یک شیء StringBuilder بسازید.
        StringBuilder paragraphText = new StringBuilder();
        // متن داخلی اسلاید را دریافت کنید:
        IEnumerable<A.Text> texts = slide.Slide.Descendants<A.Text>();
        foreach (A.Text text in texts)
        {
            paragraphText.Append(text.Text);
        }
        sldText = paragraphText.ToString();
    }
}
```
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the text in a slide.pptx";

int numberOfSlides = CountSlides(FileName);

System.Console.WriteLine("Number of slides = {0}", numberOfSlides);

string slideText;

for (int i = 0; i < numberOfSlides; i++)

{

slideText = GetSlideText(FileName, i);

System.Console.WriteLine("Slide #{0} contains: {1}", i + 1, slideText);

}

System.Console.ReadKey();

public static int CountSlides(string presentationFile)

{

    //یک نمونه از کلاس PresentationEx که نمایانگر PPTX است ایجاد کنید
    using (Presentation pres = new Presentation(presentationFile))
    {
        return pres.Slides.Count;
    }

}

public static string GetSlideText(string docName, int index)

{

    string sldText = "";

    //یک نمونه از کلاس PresentationEx که نمایانگر PPTX است ایجاد کنید
    using (Presentation pres = new Presentation(docName))
    {

        //دسترسی به اسلاید
        ISlide sld = pres.Slides[index];

        //در میان اشکال پیمایش کنید تا placeholder را پیدا کنید
        foreach (Shape shp in sld.Shapes)
            if (shp.Placeholder != null)
            {
                //متن هر placeholder را دریافت کنید
                sldText += ((AutoShape)shp).TextFrame.Text;
            }

    }

    return sldText;

}
```
## **دانلود کد نمونه**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20all%20slides%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20all%20slides/)