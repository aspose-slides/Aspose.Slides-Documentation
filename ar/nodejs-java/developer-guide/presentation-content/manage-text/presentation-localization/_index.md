---
title: توطين العرض التقديمي
type: docs
weight: 100
url: /ar/nodejs-java/presentation-localization/
---

## **تغيير اللغة لعرض الشرائح ونص الشكل**

- إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
- الحصول على مرجع الشريحة باستخدام فهرسها.
- إضافة [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) من نوع [Rectangle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeType#Rectangle) إلى الشريحة.
- إضافة بعض النص إلى TextFrame.
- [تعيين معرف اللغة](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BasePortionFormat#setLanguageId-java.lang.String-) إلى النص.
- حفظ العرض التقديمي كملف PPTX.

تم توضيح تنفيذ الخطوات السابقة في مثال أدناه.
```javascript
var pres = new aspose.slides.Presentation("test.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 50);
    shape.addTextFrame("Text to apply spellcheck language");
    shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLanguageId("en-EN");
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **الأسئلة الشائعة**

**هل يؤدي معرف اللغة إلى ترجمة النص تلقائيًا؟**

No. [setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) في Aspose.Slides يخزن اللغة للتدقيق الإملائي وإثبات القواعد، لكنه لا يترجم أو يغيّر محتوى النص. إنه بيانات وصفية يفهمها PowerPoint للإثبات.

**هل يؤثر معرف اللغة على التجزئة وفواصل الأسطر أثناء العرض؟**

في Aspose.Slides، يُستخدم [setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) لإثبات القواعد. تعتمد جودة التجزئة ولف الأسطر أساسًا على توفر [الخطوط المناسبة](/slides/ar/nodejs-java/powerpoint-fonts/) وإعدادات التخطيط/فواصل الأسطر لنظام الكتابة. لضمان العرض الصحيح، احرص على إتاحة الخطوط المطلوبة، وتكوين [قواعد استبدال الخطوط](/slides/ar/nodejs-java/font-substitution/)، و/أو [تضمين الخطوط](/slides/ar/nodejs-java/embedded-font/) في العرض.

**هل يمكنني تعيين لغات مختلفة داخل فقرة واحدة؟**

نعم. يُطبق [setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) على مستوى جزء النص، لذا يمكن لفقرة واحدة خلط عدة لغات بإعدادات إثبات مختلفة.