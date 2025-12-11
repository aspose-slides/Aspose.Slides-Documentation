---
title: "أتمتة تعريب العروض التقديمية على Android"
linktitle: "تعريب العرض التقديمي"
type: docs
weight: 100
url: /ar/androidjava/presentation-localization/
keywords:
  - "تغيير اللغة"
  - "تدقيق إملائي"
  - "معرف اللغة"
  - "PowerPoint"
  - "OpenDocument"
  - "عرض تقديمي"
  - "Android"
  - "Java"
  - "Aspose.Slides"
description: "أتمتة تعريب شرائح PowerPoint وOpenDocument في Java باستخدام Aspose.Slides لنظام Android، مع أمثلة شفرات عملية ونصائح لتسريع تنفيذ النشر العالمي."
---

## **تغيير لغة العرض التقديمي ونص الشكل**
- إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) .
- الحصول على مرجع الشريحة باستخدام الفهرس الخاص بها.
- إضافة [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) من النوع [Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeType#Rectangle) إلى الشريحة.
- إضافة نص إلى الـ TextFrame.
- تعيين معرف اللغة [Setting Language Id](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) إلى النص.
- حفظ العرض التقديمي كملف PPTX.

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

**هل يسبب معرف اللغة ترجمة تلقائية للنص؟**

لا. [Language ID](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) في Aspose.Slides يخزن اللغة للتدقيق الإملائي وإثبات القواعد، لكنه لا يترجم أو يغيّر محتوى النص. إنه بيانات وصفية تفهمها PowerPoint لأغراض التدقيق.

**هل يؤثر معرف اللغة على التجزئة والكسور السطرية أثناء العرض؟**

في Aspose.Slides، يُستخدم [language ID](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) للتدقيق فقط. جودة التجزئة وإحاطة السطر تعتمد أساسًا على توفر [الخطوط المناسبة](/slides/ar/androidjava/powerpoint-fonts/) وإعدادات التخطيط/كسر السطر للنظام الكتابي. لضمان عرض صحيح، قم بإتاحة الخطوط المطلوبة، واضبط [قواعد استبدال الخطوط](/slides/ar/androidjava/font-substitution/)، أو [دمج الخطوط](/slides/ar/androidjava/embedded-font/) في العرض التقديمي.

**هل يمكنني تعيين لغات مختلفة داخل فقرة واحدة؟**

نعم. يُطبق [Language ID](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) على مستوى الجزء النصي، لذا يمكن لفقرة واحدة أن تحتوي على لغات متعددة بإعدادات تدقيق متميزة.