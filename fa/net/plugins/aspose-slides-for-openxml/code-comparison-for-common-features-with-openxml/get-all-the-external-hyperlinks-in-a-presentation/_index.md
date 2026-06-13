---
title: دریافت تمام پیوندهای خارجی در یک ارائه
type: docs
weight: 90
url: /fa/net/get-all-the-external-hyperlinks-in-a-presentation/
---
## **ارائه OpenXML**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the External Eyperlinks.pptx";

foreach (string s in GetAllExternalHyperlinksInPresentation(FileName))

Console.WriteLine(s);

// تمام پیوندهای خارجی را در اسلایدهای یک ارائه برمی‌گرداند.

public static IEnumerable<String> GetAllExternalHyperlinksInPresentation(string fileName)

{

// یک لیست از رشته‌ها را اعلام می‌کند.

// فایل ارائه را به صورت فقط‌خواندنی باز می‌کند.

using (PresentationDocument document = PresentationDocument.Open(fileName, false))

{

    // از تمام بخش‌های اسلاید در بخش ارائه عبور می‌کند.

    foreach (SlidePart slidePart in document.PresentationPart.SlideParts)

    {

        IEnumerable<Drawing.HyperlinkType> links = slidePart.Slide.Descendants<Drawing.HyperlinkType>();

        // از تمام پیوندها در بخش اسلاید عبور می‌کند.

        foreach (Drawing.HyperlinkType link in links)

        {

            // از تمام روابط خارجی در بخش اسلاید عبور می‌کند. 

            foreach (HyperlinkRelationship relation in slidePart.HyperlinkRelationships)

            {

                // اگر شناسهٔ رابطه با شناسهٔ پیوند مطابقت داشته باشد...

                if (relation.Id.Equals(link.Id))

                {

                    // URI رابطهٔ خارجی را به لیست رشته‌ها اضافه می‌کند.

                    ret.Add(relation.Uri.AbsoluteUri);

                }

            }

        }

    }

}

// لیست رشته‌ها را برمی‌گرداند.

return ret;

}
```
## **Aspose.Slides**
Aspose.Slides برای .NET به توسعه‌دهندگان امکان مدیریت پیوندهای فراگیر در ارائه را در سطح ارائه، اسلاید و فریم متن می‌دهد. کلاس **IHyperlinkQueries** به مدیریت پیوندهای فراگیر در یک ارائه کمک می‌کند.
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the External Eyperlinks.pptx";

//یک شی Presentation ایجاد کنید که نمایانگر یک فایل PPTX باشد

Presentation pres = new Presentation(FileName);

//Get the hyperlinks from presentation

IList<IHyperlinkContainer> links = pres.HyperlinkQueries.GetAnyHyperlinks();

foreach (IHyperlinkContainer link in links)

    Console.WriteLine(link.HyperlinkClick.ExternalUrl);

```
## **دانلود مثال کد در حال اجرا**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **کد نمونه**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Get%20all%20the%20External%20Hyperlinks)