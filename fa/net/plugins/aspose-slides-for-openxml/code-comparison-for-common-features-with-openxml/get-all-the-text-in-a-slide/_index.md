---
title: دریافت تمام متن در یک اسلاید
type: docs
weight: 110
url: /fa/net/get-all-the-text-in-a-slide/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the text in a slide.pptx";

foreach (string s in GetAllTextInSlide(FileName, 0))

Console.WriteLine(s);

Console.ReadKey();

// دریافت تمام متن در یک اسلاید.

public static string[] GetAllTextInSlide(string presentationFile, int slideIndex)

{

    // ارائه را به صورت فقط‌خواندنی باز می‌کند.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // ارائه و ایندکس اسلاید را عبور می‌دهد
        // به متد GetAllTextInSlide بعدی، و
        // سپس آرایه‌ای از رشته‌ها که برمی‌گرداند را برمی‌گرداند. 

        return GetAllTextInSlide(presentationDocument, slideIndex);

    }

}

public static string[] GetAllTextInSlide(PresentationDocument presentationDocument, int slideIndex)

{

    // اطمینان حاصل شود که سند ارائه وجود دارد.
    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // اطمینان حاصل شود که ایندکس اسلاید خارج از محدوده نیست.
    if (slideIndex < 0)

    {

        throw new ArgumentOutOfRangeException("slideIndex");

    }

    // دریافت بخش ارائه از سند ارائه.
    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // اطمینان حاصل شود که بخش ارائه و ارائه وجود دارند.
    if (presentationPart != null && presentationPart.Presentation != null)

    {

        // دریافت شیء Presentation از بخش ارائه.
        Presentation presentation = presentationPart.Presentation;

        // اطمینان حاصل شود که لیست شناسه‌ اسلایدها وجود دارد.
        if (presentation.SlideIdList != null)

        {

            // دریافت مجموعه‌ای از شناسه‌های اسلاید از لیست شناسه اسلایدها.
            DocumentFormat.OpenXml.OpenXmlElementList slideIds =

                presentation.SlideIdList.ChildElements;

            // اگر شناسه اسلاید در محدوده باشد...
            if (slideIndex < slideIds.Count)

            {

                // دریافت شناسه رابطه اسلاید.
                string slidePartRelationshipId = (slideIds[slideIndex] as SlideId).RelationshipId;

                // دریافت بخش اسلاید مشخص شده از شناسه رابطه.
                SlidePart slidePart =

                    (SlidePart)presentationPart.GetPartById(slidePartRelationshipId);

                // بخش اسلاید را به متد بعدی عبور می‌دهد، و
                // سپس آرایه‌ای از رشته‌ها که آن متد برمی‌گرداند را
                // به متد قبلی برمی‌گرداند.
                return GetAllTextInSlide(slidePart);

            }

        }

    }

    // در غیر اینصورت، null برمی‌گرداند.
    return null;

}

public static string[] GetAllTextInSlide(SlidePart slidePart)

{

    // اطمینان حاصل شود که بخش اسلاید وجود دارد.
    if (slidePart == null)

    {

        throw new ArgumentNullException("slidePart");

    }

    // ایجاد یک لیست پیوندی جدید از رشته‌ها.
    LinkedList<string> texts = new LinkedList<string>();

    // اگر اسلاید وجود داشته باشد...
    if (slidePart.Slide != null)

    {

        // پیمایش تمام پاراگراف‌ها در اسلاید.
        foreach (DocumentFormat.OpenXml.Drawing.Paragraph paragraph in

            slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Paragraph>())

        {

            // ایجاد یک StringBuilder جدید.                    
            StringBuilder paragraphText = new StringBuilder();

            // پیمایش خطوط پاراگراف.
            foreach (DocumentFormat.OpenXml.Drawing.Text text in

                paragraph.Descendants<DocumentFormat.OpenXml.Drawing.Text>())

            {

                // افزودن هر خط به خطوط قبلی.
                paragraphText.Append(text.Text);

            }

            if (paragraphText.Length > 0)

            {

                // افزودن هر پاراگراف به لیست پیوندی.
                texts.AddLast(paragraphText.ToString());

            }

        }

    }

    if (texts.Count > 0)

    {

        // برگرداندن آرایه‌ای از رشته‌ها.
        return texts.ToArray();

    }

    else

    {

        return null;

    }

}

``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the text in a slide.pptx";

foreach (string s in GetAllTextInSlide(FileName, 0))

Console.WriteLine(s);

Console.ReadKey();

// دریافت تمام متن در یک اسلاید.

public static List<string> GetAllTextInSlide(string presentationFile, int slideIndex)

{

// ایجاد یک لیست پیوندی جدید از رشته‌ها.

List<string> texts = new List<string>();

// نمونه‌سازی از کلاس PresentationEx که نمایانگر PPTX است

using (Presentation pres = new Presentation(presentationFile))

{

    // دسترسی به اسلاید

    ISlide sld = pres.Slides[slideIndex];

    // پیمایش اشکال برای یافتن جای‌دار

    foreach (Shape shp in sld.Shapes)

        if (shp.Placeholder != null)

        {

            // دریافت متن هر جای‌دار

            texts.Add(((AutoShape)shp).TextFrame.Text);

        }

}

// برگرداندن آرایه‌ای از رشته‌ها.

return texts;

}

``` 
## **دریافت کد نمونه**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20a%20slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20a%20slide/)