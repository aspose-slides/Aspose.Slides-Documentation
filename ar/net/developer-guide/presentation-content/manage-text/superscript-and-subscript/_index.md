---
title: إدارة النصوص المرتفعة والمتدنية في C#
linktitle: النص المرتفع والنص المتدنٍ
type: docs
weight: 80
url: /ar/net/superscript-and-subscript/
keywords:
- مرتفع
- متدنٍ
- إضافة نص مرتفع
- إضافة نص متدنٍ
- PowerPoint
- OpenDocument
- عرض تقديمي
- C#
- Csharp
- Aspose.Slides
description: "اتقن النصوص المرتفعة والمتدنية في Aspose.Slides for .NET وارتقِ بعروضك التقديمية باستخدام تنسيق نصي احترافي لتحقيق أقصى تأثير."
---

## **نظرة عامة**

توفر Aspose.Slides for .NET ميزات لدمج النصوص المرتفعة والنصوص السفلية في عروض PowerPoint (PPT، PPTX) وOpenDocument (ODP). سواء كنت تحتاج إلى تمييز الصيغ الكيميائية أو المعادلات الرياضية أو إضافة هوامش توضيحية، فإن خيارات التنسيق المتخصصة هذه تساعد على الحفاظ على الوضوح والدقة. في هذه المقالة، ستتعلم كيفية تطبيق أنماط النص المرتفع والنص السلفي بسلاسة وضمان نتائج احترافية في كل شريحة.

## **إضافة نص مرتفع وأسفل السطر**

يمكنك إضافة نص مرتفع وأسفل السطر داخل أي فقرة في عرض تقديمي. لتحقيق ذلك باستخدام Aspose.Slides، يجب عليك استخدام خاصية `Escapement` في فئة [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/).

تتيح لك هذه الخاصية ضبط النص كمرتفع أو سلفي، بقيم تتراوح من -100٪ (سلفي) إلى 100٪ (مرتفع).

خطوات التنفيذ:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. الحصول على مرجع إلى شريحة باستخدام فهرسها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) من النوع `Rectangle` إلى الشريحة.
1. الوصول إلى [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) المرتبط بـ [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).
1. مسح الفقرات الموجودة.
1. إنشاء [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) جديد للنص المرتفع وإضافته إلى مجموعة الفقرات في [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/).
1. إنشاء عنصر جزء نص جديد.
1. ضبط خاصية `Escapement` لجزء النص بين 0 إلى 100 لتطبيق النص المرتفع (0 يعني عدم وجود نص مرتفع).
1. تعيين بعض النص لـ [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion/) وإضافته إلى مجموعة الأجزاء في الفقرة.
1. إنشاء [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) جديد للنص السلفي وإضافته إلى مجموعة الفقرات.
1. إنشاء عنصر جزء نص جديد.
1. ضبط خاصية `Escapement` لجزء النص بين 0 إلى -100 لتطبيق النص السلفي (0 يعني عدم وجود نص سلفي).
1. تعيين بعض النص لـ [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion/) وإضافته إلى مجموعة الأجزاء في الفقرة.
1. حفظ العرض التقديمي كملف PPTX.

الكود C# التالي ينفّذ هذه الخطوات:
```c#
using (Presentation presentation = new Presentation())
{
    // احصل على الشريحة الأولى.
    ISlide slide = presentation.Slides[0];

    // إنشاء صندوق نص.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.TextFrame;

    textFrame.Paragraphs.Clear();

    // إنشاء فقرة لنص مرتفع.
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

    // إنشاء فقرة لنص سفلي.
    IParagraph paragraph2 = new Paragraph();

    // إنشاء جزء نص مع نص عادي.
    IPortion portion2 = new Portion();
    portion2.Text = "a";
    paragraph2.Portions.Add(portion2);

    // إنشاء جزء نص مع نص سفلي.
    IPortion subPortion = new Portion();
    subPortion.PortionFormat.Escapement = -25;
    subPortion.Text = "i";
    paragraph2.Portions.Add(subPortion);

    // إضافة الفقرات إلى صندوق النص.
    textFrame.Paragraphs.Add(superPar);
    textFrame.Paragraphs.Add(paragraph2);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


النتيجة:

![النص المرتفع والملفوف أسفل السطر](superscript_and_subscript.png)

## **الأسئلة الشائعة**

**هل سيُحافظ على النصوص المرتفعة والملفوفة أسفل السطر عند تصديرها إلى PDF أو تنسيقات أخرى؟**

نعم، يحتفظ Aspose.Slides for .NET بتنسيق النص المرتفع والملفوف أسفل السطر بشكل صحيح عند تصدير العروض إلى PDF أو PPT/PPTX أو الصور أو أي تنسيقات مدعومة أخرى. يظل التنسيق المتخصص محفوظًا في جميع ملفات الإخراج.

**هل يمكن دمج النصوص المرتفعة والملفوفة أسفل السطر مع أنماط تنسيق أخرى مثل الغامق أو المائل؟**

نعم، يتيح Aspose.Slides خلط الأنماط النصية المختلفة داخل جزء نص واحد. يمكنك تمكين الغامق أو المائل أو التح underline وتطبيق النص المرتفع أو السلفي في الوقت نفسه من خلال ضبط الخصائص المناسبة في [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/).

**هل يعمل تنسيق النص المرتفع والملفوف أسفل السطر للنص داخل الجداول أو المخططات أو SmartArt؟**

نعم، يدعم Aspose.Slides for .NET التنسيق داخل معظم الكائنات، بما في ذلك الجداول وعناصر المخططات. عند العمل مع SmartArt، يجب الوصول إلى العناصر المناسبة (مثل [SmartArtNode](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartnode/)) وحاويات النص الخاصة بها، ثم ضبط خصائص [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/) بنفس الطريقة.