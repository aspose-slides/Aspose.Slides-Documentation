---
title: إدارة النص الفائق والنص السفلي في العروض التقديمية على Android
linktitle: النص الفائق والنص السفلي
type: docs
weight: 80
url: /ar/androidjava/superscript-and-subscript/
keywords:
- نص فائق
- نص سفلي
- إضافة نص فائق
- إضافة نص سفلي
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "اتقن النص الفائق والنص السفلي في Aspose.Slides لنظام Android عبر Java وارتقِ بعروضك التقديمية بتنسيق نصي محترف لتحقيق أقصى تأثير."
---

## **إدارة النص الفائق والنص السفلي**
يمكنك إضافة نص فائق أو نص سفلي داخل أي جزء من الفقرة. لإضافة نص فائق أو نص سفلي في إطار نص Aspose.Slides يجب استخدام طريقة [**setEscapement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBasePortionFormat#setEscapement-float-) من فئة [PortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PortionFormat).

تُعيد هذه الخاصية أو تُعيّن قيمة النص الفائق أو السفلي (القيمة من -100٪ (نص سفلي) إلى 100٪ (نص فائق)). على سبيل المثال:

- إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- الحصول على مرجع شريحة باستخدام فهرستها.
- إضافة [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) من النوع [Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeType#Rectangle) إلى الشريحة.
- الوصول إلى [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) المرتبط بـ [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape).
- مسح الفقرات الموجودة.
- إنشاء كائن فقرة جديد لحمل النص الفائق وإضافته إلى مجموعة [IParagraphs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame#getParagraphs--) الخاصة بـ [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame).
- إنشاء كائن جزء جديد.
- تعيين خاصية Escapement للجزء بين 0 إلى 100 لإضافة النص الفائق. (0 يعني عدم وجود نص فائق)
- تعيين بعض النص لـ [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Portion) ثم إضافته إلى مجموعة الأجزاء في الفقرة.
- إنشاء كائن فقرة جديد لحمل النص السفلي وإضافته إلى مجموعة IParagraphs الخاصة بـ ITextFrame.
- إنشاء كائن جزء جديد.
- تعيين خاصية Escapement للجزء بين 0 إلى -100 لإضافة النص السفلي. (0 يعني عدم وجود نص سفلي)
- تعيين بعض النص لـ [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Portion) ثم إضافته إلى مجموعة الأجزاء في الفقرة.
- حفظ العرض التقديمي كملف PPTX.

التنفيذ للخطوات المذكورة أعلاه موضح أدناه.
```java
// إنشاء كائن من فئة Presentation يمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة
    ISlide slide = pres.getSlides().get_Item(0);

    // إنشاء صندوق نص
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    // إنشاء فقرة للنص الفائق
    IParagraph superPar = new Paragraph();

    // إنشاء جزء بنص عادي
    IPortion portion1 = new Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);

    // إنشاء جزء بنص فائق
    IPortion superPortion = new Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);

    // إنشاء فقرة للنص السفلي
    IParagraph paragraph2 = new Paragraph();

    // إنشاء جزء بنص عادي
    IPortion portion2 = new Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);

    // إنشاء جزء بنص سفلي
    IPortion subPortion = new Portion();
    subPortion.getPortionFormat().setEscapement(-25);
    subPortion.setText("i");
    paragraph2.getPortions().add(subPortion);

    // إضافة الفقرات إلى صندوق النص
    textFrame.getParagraphs().add(superPar);
    textFrame.getParagraphs().add(paragraph2);

    pres.save("formatText.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **الأسئلة المتكررة**

**هل سيُحافظ على النص الفائق والنص السفلي عند التصدير إلى PDF أو صيغ أخرى؟**

نعم، تقوم Aspose.Slides بالحفاظ بشكل صحيح على تنسيق النص الفائق والنص السفلي عند تصدير العروض التقديمية إلى PDF أو PPT/PPTX أو صور أو صيغ أخرى مدعومة. يبقى التنسيق المتخصص سليماً في جميع الملفات الناتجة.

**هل يمكن دمج النص الفائق والنص السفلي مع أنماط تنسيق أخرى مثل السميك أو المائل؟**

نعم، تسمح Aspose.Slides بخلط أنماط النص المختلفة داخل جزء نص واحد. يمكنك تفعيل السميك أو المائل أو التسطير وتطبيق النص الفائق أو السفلي في الوقت نفسه من خلال ضبط الخصائص المقابلة في [PortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portionformat/).

**هل يعمل تنسيق النص الفائق والنص السفلي للنص داخل الجداول أو المخططات أو SmartArt؟**

نعم، تدعم Aspose.Slides التنسيق داخل معظم الكائنات بما في ذلك الجداول وعناصر المخطط. عند العمل مع SmartArt، تحتاج إلى الوصول إلى العناصر المناسبة (مثل [SmartArtNode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartartnode/)) وحاويات النص الخاصة بها، ثم ضبط خصائص [PortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portionformat/) بنفس الطريقة.