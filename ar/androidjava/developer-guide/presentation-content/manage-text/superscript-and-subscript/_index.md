---
title: إدارة النص العلوي والنص السفلي في العروض التقديمية على Android
linktitle: النص العلوي والنص السفلي
type: docs
weight: 80
url: /ar/androidjava/superscript-and-subscript/
keywords:
  - نص علوي
  - نص سفلي
  - إضافة نص علوي
  - إضافة نص سفلي
  - PowerPoint
  - OpenDocument
  - عرض تقديمي
  - Android
  - Java
  - Aspose.Slides
description: "إتقان النص العلوي والنص السفلي في Aspose.Slides لنظام Android عبر Java وتعزيز عروضك التقديمية بتنسيق نص احترافي لتحقيق أقصى تأثير."
---

## **إدارة النص العلوي والنص السفلي**
يمكنك إضافة نص عُلوي أو نص سفلي داخل أي جزء من الفقرة. لإضافة نص عُلوي أو نص سفلي في إطار نص Aspose.Slides يجب استخدام طريقة [**setEscapement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBasePortionFormat#setEscapement-float-) في فئة [PortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PortionFormat) .

هذه الخاصية تُعيد أو تُعيّن النص العُلوي أو السفلي (القيمة من -100% (سفلي) إلى 100% (عُلوي)). على سبيل المثال:

- إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- الحصول على مرجع الشريحة باستخدام الفهرس الخاص بها.
- إضافة كائن [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) من نوع [Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeType#Rectangle) إلى الشريحة.
- الوصول إلى [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) المرتبط بـ [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape).
- مسح الفقرات الموجودة.
- إنشاء كائن فقرة جديد لحمل النص العُلوي وإضافته إلى مجموعة [IParagraphs collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame#getParagraphs--) الخاصة بـ [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame).
- إنشاء كائن Portion جديد.
- تعيين خاصية Escapement للجزء بين 0 إلى 100 لإضافة نص عُلوي. (0 يعني عدم وجود نص عُلوي)
- وضع نص ما لـ [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Portion) ثم إضافته إلى مجموعة الأجزاء في الفقرة.
- إنشاء كائن فقرة جديد لحمل النص السفلي وإضافته إلى مجموعة IParagraphs الخاصة بـ ITextFrame.
- إنشاء كائن Portion جديد.
- تعيين خاصية Escapement للجزء بين 0 إلى -100 لإضافة نص سفلي. (0 يعني عدم وجود نص سفلي)
- وضع نص ما لـ [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Portion) ثم إضافته إلى مجموعة الأجزاء في الفقرة.
- حفظ العرض التقديمي كملف PPTX.

تنفيذ الخطوات المذكورة أعلاه موضح أدناه.
```java
// إنشاء كائن من فئة Presentation تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة
    ISlide slide = pres.getSlides().get_Item(0);

    // إنشاء صندوق نص
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    // إنشاء فقرة للنص العلوي
    IParagraph superPar = new Paragraph();

    // إنشاء جزء بنص عادي
    IPortion portion1 = new Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);

    // إنشاء جزء بنص علوي
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
**هل سيتم الحفاظ على النص العُلوي والنص السفلي عند التصدير إلى PDF أو صيغ أخرى؟**

نعم، يحافظ Aspose.Slides على تنسيق النص العُلوي والنص السفلي بشكل صحيح عند تصدير العروض التقديمية إلى PDF أو PPT/PPTX أو الصور أو غيرها من الصيغ المدعومة. يبقى التنسيق المتخصص محفوظًا في جميع ملفات الإخراج.

**هل يمكن الجمع بين النص العُلوي أو السفلي مع أنماط تنسيق أخرى مثل الغامق أو المائل؟**

نعم، يسمح Aspose.Slides بدمج أنماط نصية مختلفة داخل جزء نص واحد. يمكنك تمكين الغامق أو المائل أو التخطّط وتطبيق النص العُلوي أو السفلي في آنٍ واحد عن طريق ضبط الخصائص المناسبة في [PortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portionformat/).

**هل يعمل تنسيق النص العُلوي والسفلي للنص داخل الجداول أو المخططات أو SmartArt؟**

نعم، يدعم Aspose.Slides التنسيق داخل معظم الكائنات، بما في ذلك الجداول وعناصر المخططات. عند العمل مع SmartArt، تحتاج إلى الوصول إلى العناصر المناسبة (مثل [SmartArtNode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartartnode/)) وحاويات النص الخاصة بها، ثم ضبط خصائص [PortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portionformat/) بشكل مماثل.