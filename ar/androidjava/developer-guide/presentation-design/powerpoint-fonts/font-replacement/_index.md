---
title: استبدال الخطوط - واجهة برمجة تطبيقات PowerPoint باللغة Java
linktitle: استبدال الخطوط
type: docs
weight: 60
url: /androidjava/font-replacement/
description: تعرف على كيفية استبدال الخطوط باستخدام طريقة الاستبدال الصريحة في PowerPoint باستخدام واجهة برمجة التطبيقات Java.
---

إذا غيرت رأيك بشأن استخدام خط معين، يمكنك استبدال ذلك الخط بخط آخر. سيتم استبدال جميع حالات الخط القديم بالخط الجديد.

تسمح لك Aspose.Slides باستبدال الخط بهذه الطريقة:

1. تحميل العرض التقديمي المعني.
2. تحميل الخط الذي سيتم استبداله.
3. تحميل الخط الجديد.
4. استبدال الخط.
5. كتابة العرض التقديمي المعدل كملف PPTX.

يظهر هذا الكود بلغة Java استبدال الخط:

```java
// تحميل عرض تقديمي
Presentation pres = new Presentation("Fonts.pptx");
try {
    // تحميل خط المصدر الذي سيتم استبداله
    IFontData sourceFont = new FontData("Arial");
    
    // تحميل الخط الجديد
    IFontData destFont = new FontData("Times New Roman");
    
    // استبدال الخطوط
    pres.getFontsManager().replaceFont(sourceFont, destFont);
    
    // حفظ العرض التقديمي
    pres.save("UpdatedFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="ملاحظة" color="warning" %}} 

لتعيين قواعد تحدد ما يحدث في ظروف معينة (إذا لم يكن بإمكانك الوصول إلى خط، على سبيل المثال)، راجع [**استبدال الخطوط**](/slides/androidjava/font-substitution/).

{{% /alert %}}