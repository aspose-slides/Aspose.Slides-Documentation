---
title: إدارة النص المرتفع والنص المنخفض في العروض التقديمية في .NET
linktitle: النص المرتفع والنص المنخفض
type: docs
weight: 80
url: /ar/net/superscript-and-subscript/
keywords:
- النص المرتفع
- النص المنخفض
- إضافة نص مرتفع
- إضافة نص منخفض
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إتقان النص المرتفع والنص المنخفض في Aspose.Slides لـ .NET وتعزيز عروضك التقديمية بتنسيق نص احترافي لتحقيق أقصى تأثير."
---

## **لمحة عامة**

Aspose.Slides for .NET توفر ميزات لإدماج النص المرتفع والنص المنخفض في عروض PowerPoint (PPT، PPTX) وعروض OpenDocument (ODP). سواء كنت تحتاج إلى تمييز الصيغ الكيميائية أو المعادلات الرياضية أو إضافة هوامش توضيحية، تساعدك هذه الخيارات المتخصصة على الحفاظ على الوضوح والدقة. في هذه المقالة، ستتعلم كيفية تطبيق أنماط النص المرتفع والنص المنخفض بسلاسة وضمان نتائج احترافية في كل شريحة.

## **إضافة نص مرتفع أو نص منخفض**

يمكنك إضافة نص مرتفع أو نص منخفض داخل أي فقرة في العرض. لتحقيق ذلك باستخدام Aspose.Slides، عليك استعمال خاصية `Escapement` في فئة [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/).

تسمح لك هذه الخاصية بتعيين النص كمرتفع أو منخفض، بقيم تتراوح بين -100 % (نص منخفض) إلى 100 % (نص مرتفع).

خطوات التنفيذ:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. الحصول على مرجع إلى شريحة باستخدام فهرسها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) من النوع `Rectangle` إلى الشريحة.
1. الوصول إلى [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) المرتبط بـ [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).
1. مسح الفقرات الحالية.
1. إنشاء [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) جديد للنص المرتفع وإضافته إلى مجموعة الفقرات في [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/).
1. إنشاء كائن جزء نص جديد.
1. ضبط خاصية `Escapement` لجزء النص بين 0 إلى 100 لتطبيق النص المرتفع (0 يعني لا نص مرتفع).
1. تعيين بعض النص لـ [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion/) وإضافته إلى مجموعة الأجزاء في الفقرة.
1. إنشاء [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) جديد للنص المنخفض وإضافته إلى مجموعة الفقرات.
1. إنشاء كائن جزء نص جديد.
1. ضبط خاصية `Escapement` لجزء النص بين 0 إلى -100 لتطبيق النص المنخفض (0 يعني لا نص منخفض).
1. تعيين بعض النص لـ [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion/) وإضافته إلى مجموعة الأجزاء في الفقرة.
1. حفظ العرض كملف PPTX.

الكود C# التالي يطبّق هذه الخطوات:
```c#
using (Presentation presentation = new Presentation())
{
    // احصل على الشريحة الأولى.
    ISlide slide = presentation.Slides[0];

    // إنشاء مربع نص.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.TextFrame;

    textFrame.Paragraphs.Clear();

    // إنشاء فقرة للنص المرتفع.
    IParagraph superPar = new Paragraph();

    // إنشاء جزء نص مع نص عادي.
    IPortion portion1 = new Portion();
    portion1.Text = "MyProduct";
    superPar.Portions.Add(portion1);

    // إنشاء جزء نص مع نص مرتفع.
    IPortion superPortion = new Portion();
    superPortion.PortionFormat.Escapement = 30;
    superPortion.Text = "TM";
    superPar.Portions.Add(superPortion);

    // إنشاء فقرة للنص المنخفض.
    IParagraph paragraph2 = new Paragraph();

    // إنشاء جزء نص مع نص عادي.
    IPortion portion2 = new Portion();
    portion2.Text = "a";
    paragraph2.Portions.Add(portion2);

    // إنشاء جزء نص مع نص منخفض.
    IPortion subPortion = new Portion();
    subPortion.PortionFormat.Escapement = -25;
    subPortion.Text = "i";
    paragraph2.Portions.Add(subPortion);

    // إضافة الفقرات إلى مربع النص.
    textFrame.Paragraphs.Add(superPar);
    textFrame.Paragraphs.Add(paragraph2);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


النتيجة:

![النص المرتفع والنص المنخفض](superscript_and_subscript.png)

## **الأسئلة الشائعة**

**هل يبقى النص المرتفع والنص المنخفض محفوظين عند التصدير إلى PDF أو صيغ أخرى؟**

نعم، Aspose.Slides for .NET تحتفظ بشكل صحيح بتنسيق النص المرتفع والنص المنخفض عند تصدير العروض إلى PDF، PPT/PPTX، الصور، وغيرها من الصيغ المدعومة. يبقى التنسيق المتخصص سليمًا في جميع ملفات الإخراج.

**هل يمكن دمج النص المرتفع أو المنخفض مع أنماط تنسيق أخرى مثل الغامق أو المائل؟**

نعم، Aspose.Slides يسمح بخلط أنماط النص المختلفة داخل جزء نص واحد. يمكنك تفعيل الغامق، المائل، التسطير، وتطبيق النص المرتفع أو المنخفض في الوقت نفسه عبر ضبط الخصائص المناسبة في [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/).

**هل يعمل تنسيق النص المرتفع والنص المنخفض للنص داخل الجداول أو المخططات أو SmartArt؟**

نعم، Aspose.Slides for .NET يدعم التنسيق داخل معظم الكائنات، بما في ذلك الجداول وعناصر المخططات. عند العمل مع SmartArt، تحتاج إلى الوصول إلى العناصر المناسبة (مثل [SmartArtNode](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartnode/)) وحاويات النص الخاصة بها، ثم ضبط خصائص [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/) بنفس الطريقة.