---
title: تطبيق سمة على عرض تقديمي
type: docs
weight: 30
url: /net/apply-a-theme-to-a-presentation/
---

## **OpenXML عرض تقديمي:**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "تطبيق سمة على عرض تقديمي.pptx";

string ThemeFileName = FilePath + "Theme.pptx";

ApplyThemeToPresentation(FileName, ThemeFileName);

// تطبيق سمة جديدة على العرض التقديمي. 

public static void ApplyThemeToPresentation(string presentationFile, string themePresentation)

{

    using (PresentationDocument themeDocument = PresentationDocument.Open(themePresentation, false))

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        ApplyThemeToPresentation(presentationDocument, themeDocument);

    }

}

// تطبيق سمة جديدة على العرض التقديمي. 

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

    // الحصول على جزء العرض من مستند العرض التقديمي.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // الحصول على جزء شريحة الماستر الموجودة.

    SlideMasterPart slideMasterPart = presentationPart.SlideMasterParts.ElementAt(0);

    string relationshipId = presentationPart.GetIdOfPart(slideMasterPart);

    // الحصول على جزء شريحة الماستر الجديدة.

    SlideMasterPart newSlideMasterPart = themeDocument.PresentationPart.SlideMasterParts.ElementAt(0);

    // إزالة جزء السمة الموجود.

    presentationPart.DeletePart(presentationPart.ThemePart);

    // إزالة جزء شريحة الماستر القديمة.

    presentationPart.DeletePart(slideMasterPart);

    // استيراد جزء شريحة الماستر الجديدة، وإعادة استخدام معرف العلاقة القديمة.

    newSlideMasterPart = presentationPart.AddPart(newSlideMasterPart, relationshipId);

    // التغيير إلى جزء السمة الجديدة.

    presentationPart.AddPart(newSlideMasterPart.ThemePart);

    Dictionary<string, SlideLayoutPart> newSlideLayouts = new Dictionary<string, SlideLayoutPart>();

    foreach (var slideLayoutPart in newSlideMasterPart.SlideLayoutParts)

    {

        newSlideLayouts.Add(GetSlideLayoutType(slideLayoutPart), slideLayoutPart);

    }

    string layoutType = null;

    SlideLayoutPart newLayoutPart = null;

    // إدراج الكود للتخطيط لهذا المثال.

    string defaultLayoutType = "العنوان والمحتوى";

    // إزالة علاقة تخطيط الشريحة على جميع الشرائح. 

    foreach (var slidePart in presentationPart.SlideParts)

    {

        layoutType = null;

        if (slidePart.SlideLayoutPart != null)

        {

            // تحديد نوع تخطيط الشريحة لكل شريحة.

            layoutType = GetSlideLayoutType(slidePart.SlideLayoutPart);

            // حذف جزء التخطيط القديم.

            slidePart.DeletePart(slidePart.SlideLayoutPart);

        }

        if (layoutType != null && newSlideLayouts.TryGetValue(layoutType, out newLayoutPart))

        {

            // تطبيق جزء التخطيط الجديد.

            slidePart.AddPart(newLayoutPart);

        }

        else

        {

            newLayoutPart = newSlideLayouts[defaultLayoutType];

            // تطبيق جزء التخطيط الافتراضي الجديد.

            slidePart.AddPart(newLayoutPart);

        }

    }

}

// الحصول على نوع تخطيط الشريحة.

public static string GetSlideLayoutType(SlideLayoutPart slideLayoutPart)

{

    CommonSlideData slideData = slideLayoutPart.SlideLayout.CommonSlideData;

    // ملاحظات: إذا تم استخدام هذا في كود الإنتاج، تحقق من وجود مرجع فارغ.

    return slideData.Name;

}   

``` 
## **Aspose.Slides**
لتطبيق السمة نحتاج إلى نسخ الشريحة مع الماستر، يرجى اتباع الخطوات أدناه:

- إنشاء مثيل من فئة العرض (Presentation) يحتوي على العرض المصدر الذي ستنسخ منه الشريحة.
- إنشاء مثيل من فئة العرض (Presentation) يحتوي على العرض الوجهة التي ستنسخ إليه الشريحة.
- الوصول إلى الشريحة التي سيتم نسخها إلى جانب الشريحة الرئيسية.
- إنشاء مثيل من فئة IMasterSlideCollection بالإشارة إلى مجموعة الـ Masters المعروضة بواسطة كائن العرض (Presentation) للعرض الوجهة.
- استدعاء الطريقة AddClone المعروضة بواسطة كائن IMasterSlideCollection وتمرير الماستر من ملف PPTX المصدر ليتم نسخه كمعامل إلى طريقة AddClone.
- إنشاء مثيل من فئة ISlideCollection عن طريق تعيين المرجع إلى مجموعة الشرائح المعروضة بواسطة كائن العرض (Presentation) للعرض الوجهة.
- استدعاء الطريقة AddClone المعروضة بواسطة كائن ISlideCollection وتمرير الشريحة من العرض المصدر ليتم نسخها والشريحة الرئيسية كمعامل إلى طريقة AddClone.
- كتابة ملف العرض الوجهة المعدل.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "تطبيق سمة على عرض تقديمي.pptx";

string ThemeFileName = FilePath + "Theme.pptx";

ApplyThemeToPresentation(ThemeFileName, FileName);

public static void ApplyThemeToPresentation(string presentationFile, string outputFile)

{

    //إنشاء مثيل لفئة العرض لتحميل ملف العرض المصدر

    Presentation srcPres = new Presentation(presentationFile);

    //إنشاء مثيل لفئة العرض للعرض الوجهة (حيث سيتم نسخ الشريحة)

    Presentation destPres = new Presentation(outputFile);

    //إنشاء ISlide من مجموعة الشرائح في العرض المصدر إلى جانب

    //الشريحة الرئيسية

    ISlide SourceSlide = srcPres.Slides[0];

    //نسخ الشريحة الرئيسية المطلوبة من العرض المصدر إلى مجموعة الماستر في

    //العرض الوجهة

    IMasterSlideCollection masters = destPres.Masters;

    IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

    //نسخ الشريحة الرئيسية المطلوبة من العرض المصدر إلى مجموعة الماستر في

    //العرض الوجهة

    IMasterSlide iSlide = masters.AddClone(SourceMaster);

    //نسخ الشريحة المطلوبة من العرض المصدر مع الماستر المطلوب إلى نهاية مجموعة الشرائح في العرض الوجهة

    ISlideCollection slds = destPres.Slides;

    slds.AddClone(SourceSlide, iSlide, true);

    //نسخ الشريحة الرئيسية المطلوبة من العرض المصدر إلى مجموعة الماستر في العرض الوجهة

    //حفظ العرض الوجهة إلى القرص

    destPres.Save(outputFile, SaveFormat.Pptx);

}

``` 
## **تنزيل مثال الوظائف**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **كود العينة**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Apply%20Theme%20to%20Presentation)