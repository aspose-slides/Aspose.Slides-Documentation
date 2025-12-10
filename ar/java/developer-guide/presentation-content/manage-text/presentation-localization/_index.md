---
title: أتمتة توطين العروض التقديمية في جافا
linktitle: توطين العرض التقديمي
type: docs
weight: 100
url: /ar/java/presentation-localization/
keywords:
- تغيير اللغة
- التدقيق الإملائي
- معرف اللغة
- باوربوينت
- مستند مفتوح
- عرض تقديمي
- جافا
- Aspose.Slides
description: "أتمتة توطين شرائح PowerPoint و OpenDocument في جافا باستخدام Aspose.Slides، مع نماذج شفرة عملية ونصائح لتسريع النشر العالمي."
---

## **تغيير لغة العرض والنص داخل الشكل**
- إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
- الحصول على مرجع شريحة باستخدام فهرسها.
- إضافة [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) من نوع [Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeType#Rectangle) إلى الشريحة.
- إضافة بعض النص إلى TextFrame.
- [تعيين معرف اللغة](https://reference.aspose.com/slides/java/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) للنص.
- كتابة العرض كملف PPTX.

تم توضيح تنفيذ الخطوات السابقة أدناه في مثال.
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


## **الأسئلة المتكررة**

**هل يؤدي معرف اللغة إلى ترجمة النص تلقائيًا؟**

لا. [Language ID](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) في Aspose.Slides يخزن اللغة للتدقيق الإملائي وإثبات القواعد، لكنه لا يترجم أو يغيّر محتوى النص. إنها بيانات وصفية يفهمها PowerPoint للتدقيق.

**هل يؤثر معرف اللغة على التجزيء وفواصل السطر أثناء العرض؟**

في Aspose.Slides، [language ID](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) مخصص للإثبات. جودة التجزيء ولف السطر تعتمد أساسًا على توفر [proper fonts](/slides/ar/java/powerpoint-fonts/) وإعدادات التخطيط/فواصل السطر لنظام الكتابة. لضمان العرض الصحيح، وفر الخطوط المطلوبة، ضبط [font substitution rules](/slides/ar/java/font-substitution/)، و/أو [embed fonts](/slides/ar/java/embedded-font/) في العرض.

**هل يمكنني تعيين لغات مختلفة داخل فقرة واحدة؟**

نعم. يُطبق [Language ID](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) على مستوى جزء النص، لذا يمكن لفقرة واحدة دمج عدة لغات بإعدادات إثبات مختلفة.