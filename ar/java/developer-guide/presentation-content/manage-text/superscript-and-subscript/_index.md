---
title: إدارة النص الفائق والنص السفلي في العروض التقديمية باستخدام Java
linktitle: النص الفائق والنص السفلي
type: docs
weight: 80
url: /ar/java/superscript-and-subscript/
keywords:
- نص فائق
- نص سفلي
- إضافة نص فوقي
- إضافة نص سفلي
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "إتقان النص الفائق والنص السفلي في Aspose.Slides لـ Java وتعزيز عروضك التقديمية بتنسيق نص احترافي لتحقيق أقصى تأثير."
---

## **إدارة النص الفوقي والنص السفلي**
يمكنك إضافة نص فائق أو نص سفلي داخل أي جزء من الفقرة. لإضافة نص فائق أو سفلي في إطار نص Aspose.Slides يجب استخدام طريقة [**setEscapement**](https://reference.aspose.com/slides/java/com.aspose.slides/IBasePortionFormat#setEscapement-float-) التابعة لفئة [PortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/PortionFormat).

هذه الخاصية تُعيد أو تعيّن قيمة النص الفائق أو النص السفلي (القيمة تتراوح من -100٪ (نص سفلي) إلى 100٪ (نص فائق)). على سبيل المثال:

- أنشئ مثيلاً لفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- احصل على مرجع الشريحة باستخدام فهرسها.
- أضف عنصرًا من نوع [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) من النوع [Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeType#Rectangle) إلى الشريحة.
- احصل على الـ[ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame) المرتبط بـ[IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
- مسح الفقرات الموجودة.
- أنشئ كائن فقرة جديد للاحتفاظ بالنص الفائق وأضفه إلى مجموعة [IParagraphs](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame#getParagraphs--) الخاصة بـ[ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame).
- أنشئ كائن Portion جديد.
- عيّن خاصية Escapement للقسم بين 0 إلى 100 لإضافة نص فائق. (0 يعني لا نص فائق)
- عيّن بعض النص لـ[Portion](https://reference.aspose.com/slides/java/com.aspose.slides/Portion) ثم أضفه إلى مجموعة الأجزاء في الفقرة.
- أنشئ كائن فقرة جديد للاحتفاظ بالنص السفلي وأضفه إلى مجموعة IParagraphs الخاصة بـITextFrame.
- أنشئ كائن Portion جديد.
- عيّن خاصية Escapement للقسم بين 0 إلى -100 لإضافة نص سفلي. (0 يعني لا نص سفلي)
- عيّن بعض النص لـ[Portion](https://reference.aspose.com/slides/java/com.aspose.slides/Portion) ثم أضفه إلى مجموعة الأجزاء في الفقرة.
- احفظ العرض التقديمي كملف PPTX.

التنفيذ للخطوات السابقة موضح أدناه.
```java
// إنشاء كائن من فئة Presentation يمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة
    ISlide slide = pres.getSlides().get_Item(0);

    // إنشاء مربع نص
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    // إنشاء فقرة للنص الفوقي
    IParagraph superPar = new Paragraph();

    // إنشاء جزء بنص عادي
    IPortion portion1 = new Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);

    // إنشاء جزء بنص فوقي
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

    // إضافة الفقرات إلى مربع النص
    textFrame.getParagraphs().add(superPar);
    textFrame.getParagraphs().add(paragraph2);

    pres.save("formatText.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**هل يتم الاحتفاظ بالنص الفوقي والنص السفلي عند التصدير إلى PDF أو صيغ أخرى؟**

نعم، يتميز Aspose.Slides بالحفاظ على تنسيق النص الفوقي والنص السفلي بشكل صحيح عند تصدير العروض إلى PDF، PPT/PPTX، صور، وغيرها من الصيغ المدعومة. يظل التنسيق المتخصص سليمًا في جميع ملفات الإخراج.

**هل يمكن دمج النص الفوقي أو السفلي مع أنماط تنسيق أخرى مثل الغامق أو المائل؟**

نعم، يتيح Aspose.Slides مزج أنماط نصية مختلفة داخل جزء نصي واحد. يمكنك تمكين الغامق، المائل، التسطير، وتطبيق النص الفوقي أو السفلي في الوقت نفسه عن طريق ضبط الخصائص المناسبة في [PortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/portionformat/).

**هل يعمل تنسيق النص الفوقي والسفلي للنص داخل الجداول أو الرسوم البيانية أو SmartArt؟**

نعم، يدعم Aspose.Slides التنسيق داخل معظم الكائنات، بما في ذلك الجداول وعناصر الرسوم البيانية. عند العمل مع SmartArt، تحتاج إلى الوصول إلى العناصر المناسبة (مثل [SmartArtNode](https://reference.aspose.com/slides/java/com.aspose.slides/smartartnode/)) وحاويات النص الخاصة بها، ثم ضبط خصائص [PortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/portionformat/) بطريقة مماثلة.