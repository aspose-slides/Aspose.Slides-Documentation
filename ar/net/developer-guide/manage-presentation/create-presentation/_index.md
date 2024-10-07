---
title: إنشاء عرض تقديمي في .NET
linktitle: إنشاء عرض تقديمي
type: docs
weight: 10
url: /net/create-presentation/
keywords: "إنشاء باوربوينت، PPTX، PPT، إنشاء عرض تقديمي، تهيئة عرض تقديمي، C#، .NET"
description: "إنشاء عروض باوربوينت برمجياً في C# مثل PPT، PPTX، ODP إلخ."
---

## إنشاء عرض تقديمي باوربوينت
لإضافة خط عادي بسيط إلى شريحة محددة من العرض التقديمي، يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل من فئة Presentation.
1. الحصول على مرجع لشريحة باستخدام الفهرس الخاص بها.
1. إضافة شكل تلقائي من نوع خط باستخدام طريقة AddAutoShape المعروضة بواسطة كائن Shapes.
1. كتابة العرض التقديمي المعدل كملف PPTX.

في المثال المقدم أدناه، قمنا بإضافة خط إلى الشريحة الأولى من العرض التقديمي.

```c#
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
using (Presentation presentation = new Presentation())
{
    // الحصول على الشريحة الأولى
    ISlide slide = presentation.Slides[0];

    // إضافة شكل تلقائي من نوع خط
    slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);
    presentation.Save("NewPresentation_out.pptx", SaveFormat.Pptx);
}
```

## إنشاء وحفظ عرض تقديمي

<a name="csharp-create-save-presentation"><strong>خطوات: إنشاء وحفظ عرض تقديمي في C#</strong></a>

1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class.
2. حفظ _Presentation_ إلى أي تنسيق مدعوم بواسطة [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/)

```c#
Presentation presentation = new Presentation();

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```

## فتح وحفظ عرض تقديمي

<a name="csharp-open-save-presentation"><strong>خطوات: فتح وحفظ عرض تقديمي في C#</strong></a>

1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class بأي تنسيق مثل PPT، PPTX، ODP إلخ.
2. حفظ _Presentation_ إلى أي تنسيق مدعوم بواسطة [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/)

```c#
// تحميل أي ملف مدعوم في Presentation مثل ppt، pptx، odp إلخ.
Presentation presentation = new Presentation("Sample.odp");

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```