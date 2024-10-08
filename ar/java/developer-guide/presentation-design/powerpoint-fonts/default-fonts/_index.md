---
title: الخطوط الافتراضية - واجهة برمجة تطبيقات PowerPoint لجافا
linktitle: الخطوط الافتراضية
type: docs
weight: 30
url: /ar/java/default-font/
description: تتيح لك واجهة برمجة تطبيقات PowerPoint لجافا تعيين الخط الافتراضي لعرض العرض التقديمي إلى PDF أو XPS أو الصور المصغرة. يوضح هذا المقال كيفية تعريف خط DefaultRegular وخط DefaultAsian لاستخدامهما كخطوط افتراضية.
---


## **استخدام الخطوط الافتراضية لعرض العرض التقديمي**
تتيح لك Aspose.Slides تعيين الخط الافتراضي لعرض العرض التقديمي إلى PDF أو XPS أو الصور المصغرة. يوضح هذا المقال كيفية تعريف خط DefaultRegular وخط DefaultAsian لاستخدامهما كخطوط افتراضية. يرجى اتباع الخطوات أدناه لتحميل الخطوط من الأدلة الخارجية باستخدام Aspose.Slides لواجهة برمجة تطبيقات جافا:

1. إنشاء مثيل من [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/LoadOptions).
1. [تعيين DefaultRegularFont](https://reference.aspose.com/slides/java/com.aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) إلى الخط المرغوب. في المثال التالي، استخدمت Wingdings.
1. [تعيين DefaultAsianFont](https://reference.aspose.com/slides/java/com.aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) إلى الخط المرغوب. استخدمت Wingdings في المثال التالي.
1. تحميل العرض التقديمي باستخدام Presentation وتعيين خيارات التحميل.
1. الآن، قم بإنشاء الصورة المصغرة للشريحة وPDF وXPS للتحقق من النتائج.

توضح الكود الخاص بالتنفيذ أعلاه أدناه.

```java
// استخدم خيارات التحميل لتعريف الخطوط الافتراضية العادية والآسيوية
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");

// تحميل العرض التقديمي
Presentation pres = new Presentation("DefaultFonts.pptx", loadOptions);
try {
    // إنشاء الصورة المصغرة للشريحة
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    try {
         // حفظ الصورة على القرص.
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }

    // إنشاء PDF
    pres.save("output_out.pdf", SaveFormat.Pdf);

    // إنشاء XPS
    pres.save("output_out.xps", SaveFormat.Xps);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```