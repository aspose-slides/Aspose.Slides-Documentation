---
title: إزالة شريحة من العرض التقديمي
type: docs
weight: 30
url: /net/remove-slide-from-presentation/
keywords: "إزالة شريحة، حذف شريحة، باوربوينت، عرض تقديمي، C#، Csharp، .NET، Aspose.Slides"
description: "إزالة شريحة من باوربوينت عن طريق المرجع أو الفهرس في C# أو .NET"

---

إذا أصبحت شريحة (أو محتوياتها) زائدة عن الحاجة، يمكنك حذفها. تقدم Aspose.Slides فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) التي تضم [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection)، وهي مستودع لجميع الشرائح في عرض تقديمي. باستخدام المؤشرات (المرجع أو الفهرس) لكائن [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/) المعروف، يمكنك تحديد الشريحة التي تريد إزالتها.

## **إزالة شريحة عن طريق المرجع**

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
1. الحصول على مرجع الشريحة التي تريد إزالتها من خلال معرفها أو فهرسها.
1. إزالة الشريحة المرجعية من العرض التقديمي.
1. حفظ العرض التقديمي المعدل.

تظهر لك هذه الشيفرة بلغة C# كيفية إزالة شريحة من خلال مرجعها:

```c#
// إنشاء كائن Presentation الذي يمثل ملف عرض تقديمي
using (Presentation pres = new Presentation("RemoveSlideUsingReference.pptx"))
{

    // الوصول إلى شريحة من خلال فهرسها في مجموعة الشرائح
    ISlide slide = pres.Slides[0];

    // إزالة شريحة من خلال مرجعها
    pres.Slides.Remove(slide);

    // حفظ العرض التقديمي المعدل
    pres.Save("modified_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **إزالة شريحة عن طريق الفهرس**

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
1. إزالة الشريحة من العرض التقديمي من خلال موقع فهرسها.
1. حفظ العرض التقديمي المعدل.

تظهر لك هذه الشيفرة بلغة C# كيفية إزالة شريحة من خلال فهرسها:

```c#
// إنشاء كائن Presentation الذي يمثل ملف عرض تقديمي
using (Presentation pres = new Presentation("RemoveSlideUsingIndex.pptx"))
{

    // إزالة شريحة من خلال فهرسها
    pres.Slides.RemoveAt(0);

    // حفظ العرض التقديمي المعدل
    pres.Save("modified_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **إزالة شريحة تخطيط غير مستخدمة**

تقدم Aspose.Slides الطريقة [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) (من فئة [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/)) للسماح لك بحذف الشرائح التخطيطية غير المرغوب فيها وغير المستخدمة. تظهر لك هذه الشيفرة بلغة C# كيفية إزالة شريحة تخطيط من عرض تقديمي باوربوينت:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedLayoutSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **إزالة شريحة ماستر غير مستخدمة**

تقدم Aspose.Slides الطريقة [RemoveUnusedMasterSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) (من فئة [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/)) للسماح لك بحذف الشرائح الرئيسية غير المرغوب فيها وغير المستخدمة. تظهر لك هذه الشيفرة بلغة C# كيفية إزالة شريحة ماستر من عرض تقديمي باوربوينت:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```