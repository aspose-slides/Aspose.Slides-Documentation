---
title: جابه‌جایی اسلاید به موقعیت جدید
type: docs
weight: 140
url: /fa/net/move-a-slide-to-a-new-position/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a slide to a new position.pptx";

MoveSlide(FileName, 1, 2);

// شمارش اسلایدها در ارائه.

public static int CountSlides(string presentationFile)

{

    // باز کردن ارائه به صورت فقط خواندنی.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // ارائه را به متد CountSlides بعدی پاس می‌دهیم
        // و تعداد اسلایدها را برمی‌گردانیم.
        return CountSlides(presentationDocument);

    }

}

// شمارش اسلایدها در ارائه.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // بررسی شیء سند برابر null باشد.

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

    // برگرداندن تعداد اسلایدها به متد قبلی.

    return slidesCount;

}

// جابه‌جا کردن اسلاید به موقعیت متفاوتی در ترتیب اسلایدهای ارائه.

public static void MoveSlide(string presentationFile, int from, int to)

{

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        MoveSlide(presentationDocument, from, to);

    }

}

// جابه‌جا کردن اسلاید به موقعیت متفاوتی در ترتیب اسلایدهای ارائه.

public static void MoveSlide(PresentationDocument presentationDocument, int from, int to)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // فراخوانی متد CountSlides برای دریافت تعداد اسلایدهای ارائه.

    int slidesCount = CountSlides(presentationDocument);

    // اطمینان از این که هر دو موقعیت from و to در محدوده هستند و متفاوت از یکدیگرند.

    if (from < 0 || from >= slidesCount)

    {

        throw new ArgumentOutOfRangeException("from");

    }

    if (to < 0 || from >= slidesCount || to == from)

    {

        throw new ArgumentOutOfRangeException("to");

    }

    // دریافت بخش ارائه از سند ارائه.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // تعداد اسلایدها صفر نیست، بنابراین ارائه باید حاوی اسلاید باشد.            

    Presentation presentation = presentationPart.Presentation;

    SlideIdList slideIdList = presentation.SlideIdList;

    // دریافت شناسه اسلاید منبع.

    SlideId sourceSlide = slideIdList.ChildElements[from] as SlideId;

    SlideId targetSlide = null;

    // تعیین موقعیت اسلاید هدف که پس از آن اسلاید منبع جابه‌جا می‌شود.

    if (to == 0)

    {

        targetSlide = null;

    }

    if (from < to)

    {

        targetSlide = slideIdList.ChildElements[to] as SlideId;

    }

    else

    {

        targetSlide = slideIdList.ChildElements[to - 1] as SlideId;

    }

    // حذف اسلاید منبع از موقعیت فعلی آن.

    sourceSlide.Remove();

    // درج اسلاید منبع در موقعیت جدید پس از اسلاید هدف.

    slideIdList.InsertAfter(sourceSlide, targetSlide);

    // ذخیرهٔ ارائهٔ تغییر یافته.

    presentation.Save();

} 

``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a slide to a new position.pptx";

MoveSlide(FileName, 1, 2);

// جابه‌جا کردن اسلاید به موقعیت متفاوتی در ترتیب اسلایدها در ارائه.

public static void MoveSlide(string presentationFile, int from, int to)

{

    // نمونه‌سازی کلاس PresentationEx برای بارگذاری فایل PPTX منبع

    using (Presentation pres = new Presentation(presentationFile))

    {

        // دریافت اسلایدی که موقعیت آن باید تغییر کند

        ISlide sld = pres.Slides[from];

        ISlide sld2 = pres.Slides[to];

        // تنظیم موقعیت جدید برای اسلاید

        sld2.SlideNumber = from;

        sld.SlideNumber = to;

        // نوشتن فایل PPTX به دیسک

        pres.Save(presentationFile,Aspose.Slides.Export.SaveFormat.Pptx);

    }

}

``` 
## **Download Sample Code**
- [گیت‌هاب](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [سورسفورج](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Move%20a%20slide%20to%20a%20new%20position%20%28Aspose.Slides%29.zip/download)
- [بیت‌باکت](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Move%20a%20slide%20to%20a%20new%20position/)