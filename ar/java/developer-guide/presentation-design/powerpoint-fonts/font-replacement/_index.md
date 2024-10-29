---
title: استبدال الخط - واجهة برمجة تطبيقات PowerPoint Java
linktitle: استبدال الخط
type: docs
weight: 60
url: /ar/java/font-replacement/
description: تعلم كيفية استبدال الخطوط باستخدام طريقة الاستبدال الصريحة في PowerPoint باستخدام واجهة برمجة تطبيقات Java.
---

إذا غيرت رأيك بشأن استخدام خط، يمكنك استبدال ذلك الخط بخط آخر. سيتم استبدال جميع حالات الخط القديم بالخط الجديد.

تتيح لك Aspose.Slides استبدال خط بهذه الطريقة:

1. تحميل العرض التقديمي المعني.
2. تحميل الخط الذي سيتم استبداله.
3. تحميل الخط الجديد.
4. استبدال الخط.
5. كتابة العرض التقديمي المعدل كملف PPTX.

توضح هذه الشفرة بلغة Java كيفية استبدال الخط:

```java
// تحميل عرض تقديمي
Presentation pres = new Presentation("Fonts.pptx");
try {
    // تحميل الخط المصدر الذي سيتم استبداله
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

لتحديد القواعد التي تحدد ما يحدث في ظروف معينة (إذا لم يكن من الممكن الوصول إلى خط، على سبيل المثال)، انظر [**استبدال الخط**](/slides/ar/java/font-substitution/). 

{{% /alert %}}