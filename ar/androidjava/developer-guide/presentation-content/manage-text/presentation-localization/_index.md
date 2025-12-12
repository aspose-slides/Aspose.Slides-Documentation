---
title: أتمتة تعريب العروض التقديمية على Android
linktitle: تعريب العرض التقديمي
type: docs
weight: 100
url: /ar/androidjava/presentation-localization/
keywords:
- تغيير اللغة
- تدقيق إملائي
- معرف اللغة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "أتمتة تعريب شرائح PowerPoint وOpenDocument في Java باستخدام Aspose.Slides لنظام Android، مع أمثلة شفرة عملية ونصائح لتسريع الانتشار العالمي."
---

## **تغيير اللغة لعرض تقديمي ونص الشكل**
- إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) .
- الحصول على مرجع الشريحة باستخدام الفهرس الخاص بها.
- إضافة [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) من النوع [Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeType#Rectangle) إلى الشريحة.
- إضافة بعض النص إلى TextFrame.
- [Setting Language Id](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) للنص.
- حفظ العرض التقديمي كملف PPTX.

يتم توضيح تنفيذ الخطوات المذكورة أعلاه في المثال أدناه.
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

**هل يؤدي معرف اللغة إلى ترجمة تلقائية للنص؟**

لا. [Language ID](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) في Aspose.Slides يُخزّن اللغة للتدقيق الإملائي وإثبات القواعد، لكنه لا يترجم أو يغيّر محتوى النص. إنه بيانات تعريفية يفهمها PowerPoint للتدقيق.

**هل يؤثر معرف اللغة على التجزيء وفواصل الأسطر أثناء العرض؟**

في Aspose.Slides، [language ID](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) مخصص للتدقيق. جودة التجزيء وتغليف الأسطر تعتمد أساسًا على توفر [proper fonts](/slides/ar/androidjava/powerpoint-fonts/) وإعدادات التخطيط/فواصل الأسطر لنظام الكتابة. لضمان العرض الصحيح، احرص على إتاحة الخطوط المطلوبة، وتكوين [font substitution rules](/slides/ar/androidjava/font-substitution/)، و/أو [embed fonts](/slides/ar/androidjava/embedded-font/) في العرض.

**هل يمكنني تعيين لغات مختلفة داخل فقرة واحدة؟**

نعم. [Language ID](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) يتم تطبيقه على مستوى جزء النص، لذا يمكن لفقرة واحدة أن تحتوي على لغات متعددة بإعدادات تدقيق متميزة.