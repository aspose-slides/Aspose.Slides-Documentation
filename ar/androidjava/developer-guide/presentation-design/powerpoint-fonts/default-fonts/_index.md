---
title: الخطوط الافتراضية - PowerPoint Java API
linktitle: الخطوط الافتراضية
type: docs
weight: 30
url: /ar/androidjava/default-font/
description: تتيح لك PowerPoint Java API تعيين الخط الافتراضي لعرض العرض التقديمي إلى PDF أو XPS أو الصور المصغرة. توضح هذه المقالة كيفية تعريف خط DefaultRegular وخط DefaultAsian لاستخدامهما كخطوط افتراضية.
---


## **استخدام الخطوط الافتراضية لعرض العرض التقديمي**
تتيح لك Aspose.Slides تعيين الخط الافتراضي لعرض العرض التقديمي إلى PDF أو XPS أو الصور المصغرة. توضح هذه المقالة كيفية تعريف خط DefaultRegular وخط DefaultAsian لاستخدامهما كخطوط افتراضية. يرجى اتباع الخطوات أدناه لتحميل الخطوط من أدلة خارجية عن طريق استخدام Aspose.Slides لـ Android عبر واجهة برمجة التطبيقات Java:

1. أنشئ مثيلًا من [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LoadOptions).
1. [قم بتعيين DefaultRegularFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) إلى الخط الذي تريده. في المثال التالي، استخدمت Wingdings.
1. [قم بتعيين DefaultAsianFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) إلى الخط الذي تريده. لقد استخدمت Wingdings في المثال التالي.
1. تحميل العرض التقديمي باستخدام Presentation وضبط خيارات التحميل.
1. الآن، قم بإنشاء الصورة المصغرة للشريحة، PDF و XPS للتحقق من النتائج.

يتم إعطاء تنفيذ ما سبق أدناه.

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