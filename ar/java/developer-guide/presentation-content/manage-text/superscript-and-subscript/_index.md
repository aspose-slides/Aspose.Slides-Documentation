---
title: النص العلوي والنص السفلي
type: docs
weight: 80
url: /ar/java/superscript-and-subscript/
---

## **إدارة نص العلوي والنص السفلي**
يمكنك إضافة نص علوي ونص سفلي داخل أي جزء من الفقرة. لإضافة نص علوي أو نص سفلي في إطار نص Aspose.Slides، يجب استخدام [**setEscapement**](https://reference.aspose.com/slides/java/com.aspose.slides/IBasePortionFormat#setEscapement-float-) من فئة [PortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/PortionFormat).

تُرجع هذه الخاصية أو تعيّن النص العلوي أو النص السفلي (قيمة من -100% (نص سفلي) إلى 100% (نص علوي). على سبيل المثال:

- إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- الحصول على مرجع الشريحة باستخدام الفهرس الخاص بها.
- إضافة [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) من نوع [Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeType#Rectangle) إلى الشريحة.
- الوصول إلى [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame) المرتبط بـ [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
- مسح الفقرات الموجودة
- إنشاء كائن فقرة جديدة لتخزين النص العلوي وإضافته إلى [IParagraphs collection](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame#getParagraphs--) من [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame).
- إنشاء كائن جزء جديد
- تعيين خاصية Escapement للجزء بين 0 إلى 100 لإضافة نص علوي. (0 تعني لا توجد نص علوي)
- تعيين بعض النص لـ [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/Portion) ثم إضافته في مجموعة الأجزاء الخاصة بالفقرة.
- إنشاء كائن فقرة جديدة لتخزين النص السفلي وإضافته إلى مجموعة IParagraphs من ITextFrame.
- إنشاء كائن جزء جديد
- تعيين خاصية Escapement للجزء بين 0 إلى -100 لإضافة نص سفلي. (0 تعني لا توجد نص سفلي)
- تعيين بعض النص لـ [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/Portion) ثم إضافته في مجموعة الأجزاء الخاصة بالفقرة.
- حفظ العرض التقديمي كملف PPTX.

تنفيذ الخطوات أعلاه مُعطى أدناه.

```java
// إنشاء عرض تقديمي يُمثل PPTX
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة
    ISlide slide = pres.getSlides().get_Item(0);

    // إنشاء مربع نص
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    // إنشاء فقرة لنص علوي
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

    // إنشاء فقرة لنص سفلي
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