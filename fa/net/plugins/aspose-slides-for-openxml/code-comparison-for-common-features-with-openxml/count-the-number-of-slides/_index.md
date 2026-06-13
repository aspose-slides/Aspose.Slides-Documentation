---
title: شمارش تعداد اسلایدها
type: docs
weight: 50
url: /fa/net/count-the-number-of-slides/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Count the number of slides.pptx";

Console.WriteLine("Number of slides = {0}",

CountSlides(FileName));

Console.ReadKey();

// دریافت شیء ارائه و ارسال آن به متد CountSlides بعدی.

public static int CountSlides(string presentationFile)

{

    // باز کردن ارائه به صورت فقط خواندنی.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // ارسال ارائه به متد CountSlide بعدی

        // و بازگرداندن تعداد اسلایدها.

        return CountSlides(presentationDocument);

    }

}

// شمارش اسلایدهای موجود در ارائه.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // بررسی اشیاء سند که مقدار null دارند.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // دریافت بخش ارائه از سند.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // دریافت تعداد اسلایدها از SlideParts.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // بازگرداندن تعداد اسلایدها به متد قبلی.

    return slidesCount;

} 
```
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Count the number of slides.pptx";

Console.WriteLine("Number of slides = {0}",

CountSlides(FileName));

Console.ReadKey();

public static int CountSlides(string presentationFile)

{

  //یک شیء PresentationEx که نمایانگر فایل PPTX است را نمونه‌سازی کنید

  using (Presentation pres = new Presentation(presentationFile))

  {

     return pres.Slides.Count;

  }

}  

```
## **کد نمونه را دانلود کنید**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Count%20the%20number%20of%20Slides%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Count%20the%20number%20of%20Slides/)