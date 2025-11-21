---
title: النص العلوي والنص السفلي
type: docs
weight: 80
url: /ar/nodejs-java/superscript-and-subscript/
---

## **إدارة النص العلوي والنص السفلي**

يمكنك إضافة نص علوي أو نص سفلي داخل أي جزء من الفقرة. لإضافة نص علوي أو سفلي في إطار نص Aspose.Slides يجب استخدام طريقة [**setEscapement**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BasePortionFormat#setEscapement-float-) من فئة [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PortionFormat).

هذه الخاصية تُعيد أو تُحدد نصًا علويًا أو سفليًا (القيمة من -100% (سفلي) إلى 100% (علوي)). على سبيل المثال:

- إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
- الحصول على مرجع الشريحة باستخدام فهرسها.
- إضافة [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) من النوع [Rectangle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeType#Rectangle) إلى الشريحة.
- الوصول إلى [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) المرتبط بـ [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
- مسح الفقرات الموجودة.
- إنشاء كائن فقرة جديد لحمل نص علوي وإضافته إلى مجموعة [Paragraphs collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame#getParagraphs--) الخاصة بـ [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame).
- إنشاء كائن جزء جديد.
- تعيين خاصية Escapement للجزء بين 0 إلى 100 لإضافة نص علوي. (0 يعني عدم وجود نص علوي)
- ضبط بعض النص لـ [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion) ثم إضافته إلى مجموعة الأجزاء في الفقرة.
- إنشاء كائن فقرة جديد لحمل نص سفلي وإضافته إلى مجموعة IParagraphs الخاصة بـ ITextFrame.
- إنشاء كائن جزء جديد.
- تعيين خاصية Escapement للجزء بين 0 إلى -100 لإضافة نص سفلي. (0 يعني عدم وجود نص سفلي)
- ضبط بعض النص لـ [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion) ثم إضافته إلى مجموعة الأجزاء في الفقرة.
- حفظ العرض التقديمي كملف PPTX.

التنفيذ التفصيلي للخطوات المذكورة أعلاه موضح أدناه.
```javascript
// إنشاء كائن من فئة Presentation التي تمثل ملف PPTX
var pres = new aspose.slides.Presentation();
try {
    // الحصول على الشريحة
    var slide = pres.getSlides().get_Item(0);
    // إنشاء صندوق نص
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 200, 100);
    var textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();
    // إنشاء فقرة لنص العلوي
    var superPar = new aspose.slides.Paragraph();
    // إنشاء جزء بنص عادي
    var portion1 = new aspose.slides.Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);
    // إنشاء جزء بنص علوي
    var superPortion = new aspose.slides.Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);
    // إنشاء فقرة لنص سفلي
    var paragraph2 = new aspose.slides.Paragraph();
    // إنشاء جزء بنص عادي
    var portion2 = new aspose.slides.Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);
    // إنشاء جزء بنص سفلي
    var subPortion = new aspose.slides.Portion();
    subPortion.getPortionFormat().setEscapement(-25);
    subPortion.setText("i");
    paragraph2.getPortions().add(subPortion);
    // إضافة الفقرات إلى صندوق النص
    textFrame.getParagraphs().add(superPar);
    textFrame.getParagraphs().add(paragraph2);
    pres.save("formatText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **الأسئلة الشائعة**

**هل يتم الحفاظ على النص العلوي والنص السفلي عند التصدير إلى PDF أو صيغ أخرى؟**

نعم، تقوم Aspose.Slides بالحفاظ على تنسيق النص العلوي والسفلي بشكل صحيح عند تصدير العروض إلى PDF أو PPT/PPTX أو الصور أو الصيغ المدعومة الأخرى. يظل التنسيق المتخصص سليمًا في جميع ملفات الإخراج.

**هل يمكن دمج النص العلوي والنص السفلي مع أنماط تنسيق أخرى مثل الغامق أو المائل؟**

نعم، تسمح Aspose.Slides بخلط أنماط نصية مختلفة داخل جزء نص واحد. يمكنك تمكين الغامق أو المائل أو التسطير وتطبيق النص العلوي أو السفلي في الوقت نفسه عن طريق ضبط الخصائص المقابلة في [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/).

**هل يعمل تنسيق النص العلوي والنص السفلي للنص داخل الجداول أو المخططات أو SmartArt؟**

نعم، تدعم Aspose.Slides التنسيق داخل معظم الكائنات، بما في ذلك الجداول وعناصر المخططات. عند العمل مع SmartArt، تحتاج إلى الوصول إلى العناصر المناسبة (مثل [SmartArtNode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/)) وحاويات النص الخاصة بها، ثم ضبط خصائص [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/) بطريقة مماثلة.