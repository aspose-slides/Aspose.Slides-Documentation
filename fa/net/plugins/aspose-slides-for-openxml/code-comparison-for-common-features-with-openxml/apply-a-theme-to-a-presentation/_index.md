---
title: اعمال تم به یک ارائه
type: docs
weight: 30
url: /fa/net/apply-a-theme-to-a-presentation/
---
## **ارائه OpenXML**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Apply Theme to Presentation.pptx";

string ThemeFileName = FilePath + "Theme.pptx";

ApplyThemeToPresentation(FileName, ThemeFileName);

// یک تم جدید به ارائه اعمال کنید. 

public static void ApplyThemeToPresentation(string presentationFile, string themePresentation)

{

    using (PresentationDocument themeDocument = PresentationDocument.Open(themePresentation, false))

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        ApplyThemeToPresentation(presentationDocument, themeDocument);

    }

}

// یک تم جدید به ارائه اعمال کنید. 

public static void ApplyThemeToPresentation(PresentationDocument presentationDocument, PresentationDocument themeDocument)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    if (themeDocument == null)

    {

        throw new ArgumentNullException("themeDocument");

    }

    // بخش ارائه سند ارائه را دریافت کنید.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // بخش مستر اسلاید موجود را دریافت کنید.

    SlideMasterPart slideMasterPart = presentationPart.SlideMasterParts.ElementAt(0);

    string relationshipId = presentationPart.GetIdOfPart(slideMasterPart);

    // بخش مستر اسلاید جدید را دریافت کنید.

    SlideMasterPart newSlideMasterPart = themeDocument.PresentationPart.SlideMasterParts.ElementAt(0);

    // بخش تم موجود را حذف کنید.

    presentationPart.DeletePart(presentationPart.ThemePart);

    // بخش مستر اسلاید قدیمی را حذف کنید.

    presentationPart.DeletePart(slideMasterPart);

    // بخش مستر اسلاید جدید را وارد کنید و شناسه رابطهٔ قدیمی را مجدداً استفاده کنید.

    newSlideMasterPart = presentationPart.AddPart(newSlideMasterPart, relationshipId);

    // به بخش تم جدید تغییر دهید.

    presentationPart.AddPart(newSlideMasterPart.ThemePart);

    Dictionary<string, SlideLayoutPart> newSlideLayouts = new Dictionary<string, SlideLayoutPart>();

    foreach (var slideLayoutPart in newSlideMasterPart.SlideLayoutParts)

    {

        newSlideLayouts.Add(GetSlideLayoutType(slideLayoutPart), slideLayoutPart);

    }

    string layoutType = null;

    SlideLayoutPart newLayoutPart = null;

    // کد مربوط به چینش برای این مثال را وارد کنید.

    string defaultLayoutType = "Title and Content";

    // روابط چینش اسلاید را در تمام اسلایدها حذف کنید. 

    foreach (var slidePart in presentationPart.SlideParts)

    {

        layoutType = null;

        if (slidePart.SlideLayoutPart != null)

        {

            // نوع چینش اسلاید را برای هر اسلاید تعیین کنید.

            layoutType = GetSlideLayoutType(slidePart.SlideLayoutPart);

            // بخش چینش قدیمی را حذف کنید.

            slidePart.DeletePart(slidePart.SlideLayoutPart);

        }

        if (layoutType != null && newSlideLayouts.TryGetValue(layoutType, out newLayoutPart))

        {

            // بخش چینش جدید را اعمال کنید.

            slidePart.AddPart(newLayoutPart);

        }

        else

        {

            newLayoutPart = newSlideLayouts[defaultLayoutType];

            // بخش چینش پیش‌فرض جدید را اعمال کنید.

            slidePart.AddPart(newLayoutPart);

        }

    }

}

// نوع چینش اسلاید را دریافت کنید.

public static string GetSlideLayoutType(SlideLayoutPart slideLayoutPart)

{

    CommonSlideData slideData = slideLayoutPart.SlideLayout.CommonSlideData;

    // توضیح: اگر در کد تولیدی استفاده می‌شود، وجود مرجع تهی را بررسی کنید.

    return slideData.Name;

}   

``` 
## **Aspose.Slides**
برای اعمال تم باید اسلاید را همراه با مستر کلون کنیم، لطفاً مراحل زیر را دنبال کنید:

- یک نمونه از کلاس Presentation ایجاد کنید که شامل ارائه منبع باشد که اسلاید از آن کلون می‌شود.
- یک نمونه از کلاس Presentation ایجاد کنید که شامل ارائه مقصد باشد که اسلاید به آن کلون می‌شود.
- به اسلایدی که باید کلون شود همراه با اسلاید مستر آن دسترسی پیدا کنید.
- کلاس IMasterSlideCollection را با ارجاع به مجموعه Masters که توسط شیء Presentation ارائه مقصد ارائه شده است، نمونه‌سازی کنید.
- متد AddClone را که توسط شیء IMasterSlideCollection ارائه شده است، فراخوانی کنید و مستر از فایل PPTX منبع که باید کلون شود را به‌عنوان پارامتر به متد AddClone پاس دهید.
- کلاس ISlideCollection را با تنظیم ارجاع به مجموعه Slides که توسط شیء Presentation ارائه مقصد ارائه شده است، نمونه‌سازی کنید.
- متد AddClone را که توسط شیء ISlideCollection ارائه شده است، فراخوانی کنید و اسلاید از ارائه منبع که باید کلون شود و اسلاید مستر را به‌عنوان پارامتر به متد AddClone پاس دهید.
- فایل ارائه مقصد اصلاح‌شده را بنویسید.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Apply Theme to Presentation.pptx";

string ThemeFileName = FilePath + "Theme.pptx";

ApplyThemeToPresentation(ThemeFileName, FileName);

public static void ApplyThemeToPresentation(string presentationFile, string outputFile)

{

    //کلاس Presentation را برای بارگذاری فایل ارائه منبع ایجاد کنید
    Presentation srcPres = new Presentation(presentationFile);

    //کلاس Presentation را برای ارائه مقصد (جایی که اسلاید باید کلون شود) ایجاد کنید
    Presentation destPres = new Presentation(outputFile);

    //یک ISlide را از مجموعه اسلایدهای ارائه منبع همراه با
    //اسلاید مستر
    ISlide SourceSlide = srcPres.Slides[0];

    //اسلاید مستر مورد نظر را از ارائه منبع به مجموعه مسترها در
    //ارائه مقصد
    IMasterSlideCollection masters = destPres.Masters;

    IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

    //اسلاید مستر مورد نظر را از ارائه منبع به مجموعه مسترها در
    //ارائه مقصد
    IMasterSlide iSlide = masters.AddClone(SourceMaster);

    //اسلاید مورد نظر را از ارائه منبع با مستر مورد نظر تا انتهای
    //مجموعه اسلایدها در ارائه مقصد
    ISlideCollection slds = destPres.Slides;

    slds.AddClone(SourceSlide, iSlide, true);

    //اسلاید مستر مورد نظر را از ارائه منبع به مجموعه مسترها در //ارائه مقصد
    //ارائه مقصد را روی دیسک ذخیره کنید
    destPres.Save(outputFile, SaveFormat.Pptx);

}

``` 
## **دانلود مثال کد اجرایی**
- [گیت‌هاب](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **کد نمونه**
- [گیت‌هاب](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Apply%20Theme%20to%20Presentation)