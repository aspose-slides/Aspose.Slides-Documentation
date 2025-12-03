---
title: أتمتة توطين العروض التقديمية في Java
linktitle: توطين العروض التقديمية
type: docs
weight: 100
url: /ar/java/presentation-localization/
keywords:
- تغيير اللغة
- التدقيق الإملائي
- معرف اللغة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "أتمتة توطين شرائح PowerPoint و OpenDocument في Java باستخدام Aspose.Slides، مع أمثلة شيفرة عملية ونصائح لتسريع الإطلاق العالمي."
---

## **تغيير لغة العرض ونص الشكل**
- إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
- الحصول على مرجع الشريحة باستخدام فهرستها.
- إضافة [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) من نوع [Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeType#Rectangle) إلى الشريحة.
- إضافة بعض النص إلى TextFrame.
- [تعيين معرف اللغة](https://reference.aspose.com/slides/java/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) للنص.
- حفظ العرض كملف PPTX.

يتم توضيح تنفيذ الخطوات السابقة في المثال أدناه.
```java
Presentation pres = new Presentation("test.pptx");
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.addTextFrame("Text to apply spellcheck language");

    shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLanguageId("en-EN");

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **الأسئلة الشائعة**

**هل يؤدي معرف اللغة إلى ترجمة النص تلقائيًا؟**

لا. [Language ID](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) في Aspose.Slides يخزن اللغة لتدقيق الإملاء وتصحيح القواعد، لكنه لا يترجم أو يغير محتوى النص. إنها بيانات وصفية يفهمها PowerPoint للتدقيق.

**هل يؤثر معرف اللغة على تجزئة الكلمات وفواصل الأسطر أثناء العرض؟**

في Aspose.Slides، يُستخدم [معرف اللغة](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) للتدقيق. تعتمد جودة تجزئة الكلمات وتغليف السطور بشكل أساسي على توفر [الخطوط المناسبة](/slides/ar/java/powerpoint-fonts/) وإعدادات تخطيط/كسر السطر لنظام الكتابة. لضمان العرض الصحيح، احرص على توفير الخطوط المطلوبة، وتكوين [قواعد استبدال الخطوط](/slides/ar/java/font-substitution/)، و/أو [تضمين الخطوط](/slides/ar/java/embedded-font/) في العرض.

**هل يمكنني تعيين لغات مختلفة داخل فقرة واحدة؟**

نعم. يُطبق [معرف اللغة](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) على مستوى جزء النص، لذا يمكن للفقرة الواحدة دمج لغات متعددة بإعدادات تدقيق مختلفة.