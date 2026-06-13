---
title: دریافت عناوین تمام اسلایدها
type: docs
weight: 120
url: /fa/net/get-the-titles-of-all-the-slides/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get the titles of all the slides.pptx";

foreach (string s in GetSlideTitles(FileName))

Console.WriteLine(s);

Console.ReadKey();

// دریافت لیستی از عناوین تمام اسلایدهای ارائه.

public static IList<string> GetSlideTitles(string presentationFile)

{

    // ارائه را به صورت فقط‌خواندنی باز کنید.

    using (PresentationDocument presentationDocument =

        PresentationDocument.Open(presentationFile, false))

    {

        return GetSlideTitles(presentationDocument);

    }

}

// دریافت لیستی از عناوین تمام اسلایدهای ارائه.

public static IList<string> GetSlideTitles(PresentationDocument presentationDocument)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // دریافت یک شیء PresentationPart از شیء PresentationDocument.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    if (presentationPart != null &&

        presentationPart.Presentation != null)

    {

        // دریافت یک شیء Presentation از شیء PresentationPart.

        Presentation presentation = presentationPart.Presentation;

        if (presentation.SlideIdList != null)

        {

            List<string> titlesList = new List<string>();

            // دریافت عنوان هر اسلاید به ترتیب اسلایدها.

            foreach (var slideId in presentation.SlideIdList.Elements<SlideId>())

            {

                SlidePart slidePart = presentationPart.GetPartById(slideId.RelationshipId) as SlidePart;

                // دریافت عنوان اسلاید.

                string title = GetSlideTitle(slidePart);

                // می‌توان یک عنوان خالی نیز اضافه کرد.

                titlesList.Add(title);

            }

            return titlesList;

        }

    }

    return null;

}

// دریافت رشته عنوان اسلاید.

public static string GetSlideTitle(SlidePart slidePart)

{

    if (slidePart == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // اعلان جداکننده پاراگراف.

    string paragraphSeparator = null;

    if (slidePart.Slide != null)

    {

        // یافتن تمام شکل‌های عنوان.

        var shapes = from shape in slidePart.Slide.Descendants<Shape>()

                     where IsTitleShape(shape)

                     select shape;

        StringBuilder paragraphText = new StringBuilder();

        foreach (var shape in shapes)

        {

            // دریافت متن در هر پاراگراف این شکل.

            foreach (var paragraph in shape.TextBody.Descendants<D.Paragraph>())

            {

                // افزودن شکست خط.

                paragraphText.Append(paragraphSeparator);

                foreach (var text in paragraph.Descendants<D.Text>())

                {

                    paragraphText.Append(text.Text);

                }

                paragraphSeparator = "\n";

            }

        }

        return paragraphText.ToString();

    }

    return string.Empty;

}

// تعیین اینکه آیا شکل یک شکل عنوان است.

private static bool IsTitleShape(Shape shape)

{

    var placeholderShape = shape.NonVisualShapeProperties.ApplicationNonVisualDrawingProperties.GetFirstChild<PlaceholderShape>();

    if (placeholderShape != null && placeholderShape.Type != null && placeholderShape.Type.HasValue)

    {

        switch ((PlaceholderValues)placeholderShape.Type)

        {

            // هر شکل عنوان.

            case PlaceholderValues.Title:

            // یک عنوان وسط‌چین.

            case PlaceholderValues.CenteredTitle:

                return true;

            default:

                return false;

        }

    }

    return false;

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

GetSlideIdAndText(out slideText, FileName, i);

System.Console.WriteLine("Slide #{0} contains: {1}", i + 1, slideText);

}

System.Console.ReadKey();

public static int CountSlides(string presentationFile)

{

    // ارائه را به صورت فقط‌خواندنی باز کنید.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // ارائه را به متد CountSlides بعدی پاس بدهید

        // و تعداد اسلایدها را برگردانید.

        return CountSlides(presentationDocument);

    }

}

// شمارش اسلایدهای موجود در ارائه.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // بررسی شیء سند که آیا مقدار null دارد.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // دریافت بخش Presentation از سند.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // دریافت تعداد اسلایدها از SlideParts.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // برگرداندن تعداد اسلایدها به متد قبلی.

    return slidesCount;

}

public static void GetSlideIdAndText(out string sldText, string docName, int index)

{

    using (PresentationDocument ppt = PresentationDocument.Open(docName, false))

    {

        // دریافت شناسه رابطه (Relationship ID) اولین اسلاید.

        PresentationPart part = ppt.PresentationPart;

        OpenXmlElementList slideIds = part.Presentation.SlideIdList.ChildElements;

        string relId = (slideIds[index] as SlideId).RelationshipId;

        // دریافت بخش اسلاید از شناسه رابطه.

        SlidePart slide = (SlidePart)part.GetPartById(relId);

        // ساخت یک شیء StringBuilder.

        StringBuilder paragraphText = new StringBuilder();

        // دریافت متن داخلی اسلاید:

        IEnumerable<A.Text> texts = slide.Slide.Descendants<A.Text>();

        foreach (A.Text text in texts)

        {

            paragraphText.Append(text.Text);

        }

        sldText = paragraphText.ToString();

    }

}

``` 
## **دانلود کد نمونه**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Get%20the%20titles%20of%20all%20the%20slides%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Get%20the%20titles%20of%20all%20the%20slides/)