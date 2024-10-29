---
title: النص العلوي والنص السفلي
type: docs
weight: 80
url: /ar/androidjava/superscript-and-subscript/
---

## **إدارة نصوص النص العلوي والنص السفلي**
يمكنك إضافة نصوص علوية وسفلية داخل أي جزء من الفقرة. لإضافة نص علوي أو نص سفلي في إطار نصوص Aspose.Slides، يجب استخدام طريقة [**setEscapement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBasePortionFormat#setEscapement-float-) من فئة [PortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PortionFormat).

تعيد هذه الخاصية أو تضبط النص العلوي أو السفلي (قيمة تتراوح من -100% (نص سفلي) إلى 100% (نص علوي). على سبيل المثال:

- إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- الحصول على مرجع شريحة باستخدام الفهرس الخاص بها.
- إضافة [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) من نوع [Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeType#Rectangle) إلى الشريحة.
- الوصول إلى [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) المرتبط بـ [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape).
- مسح الفقرات الموجودة
- إنشاء عنصر فقرة جديد لحفظ نص علوي وإضافته إلى مجموعة [IParagraphs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame#getParagraphs--) من [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame).
- إنشاء عنصر جزء جديد
- ضبط خاصية Escapement للجزء بين 0 و 100 لإضافة نص علوي. (0 تعني عدم وجود نص علوي)
- ضبط نص لبعض [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Portion) ثم إضافته إلى مجموعة أجزاء الفقرة.
- إنشاء عنصر فقرة جديد لحفظ نص سفلي وإضافته إلى مجموعة IParagraphs من ITextFrame.
- إنشاء عنصر جزء جديد
- ضبط خاصية Escapement للجزء بين 0 و -100 لإضافة نص سفلي. (0 تعني عدم وجود نص سفلي)
- ضبط نص لبعض [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Portion) ثم إضافته إلى مجموعة أجزاء الفقرة.
- حفظ العرض التقديمي كملف PPTX.

تم تقديم تنفيذ الخطوات السابقة أدناه.

```java
// Instantiate a Presentation class that represents a PPTX
Presentation pres = new Presentation();
try {
    // Get slide
    ISlide slide = pres.getSlides().get_Item(0);

    // Create text box
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    // Create paragraph for superscript text
    IParagraph superPar = new Paragraph();

    // Create portion with usual text
    IPortion portion1 = new Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);

    // Create portion with superscript text
    IPortion superPortion = new Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);

    // Create paragraph for subscript text
    IParagraph paragraph2 = new Paragraph();

    // Create portion with usual text
    IPortion portion2 = new Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);

    // Create portion with subscript text
    IPortion subPortion = new Portion();
    subPortion.getPortionFormat().setEscapement(-25);
    subPortion.setText("i");
    paragraph2.getPortions().add(subPortion);

    // Add paragraphs to text box
    textFrame.getParagraphs().add(superPar);
    textFrame.getParagraphs().add(paragraph2);

    pres.save("formatText.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```