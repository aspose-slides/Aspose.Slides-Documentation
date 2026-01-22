---
title: تصدير العروض التقديمية إلى XAML في جافا سكريبت
linktitle: العرض التقديمي إلى XAML
type: docs
weight: 30
url: /ar/nodejs-java/export-to-xaml/
keywords:
- تصدير PowerPoint
- تصدير OpenDocument
- تصدير العرض التقديمي
- تحويل PowerPoint
- تحويل OpenDocument
- تحويل العرض التقديمي
- PowerPoint إلى XAML
- OpenDocument إلى XAML
- العرض التقديمي إلى XAML
- PPT إلى XAML
- PPTX إلى XAML
- ODP إلى XAML
- حفظ PPT كـ XAML
- حفظ PPTX كـ XAML
- حفظ ODP كـ XAML
- تصدير PPT إلى XAML
- تصدير PPTX إلى XAML
- تصدير ODP إلى XAML
- Node.js
- JavaScript
- Aspose.Slides
description: "تحويل شرائح PowerPoint و OpenDocument إلى XAML في جافا سكريبت باستخدام Aspose.Slides لـ Node.js — حل سريع بدون Office يحافظ على تخطيطك دون تغيير."
---

## **تصدير العروض التقديمية إلى XAML**

Aspose.Slides يدعم تصدير XAML. يمكنك تحويل عروضك التقديمية إلى XAML.

## **حول XAML**

XAML هي لغة برمجة وصفية تسمح لك بإنشاء أو كتابة فئات مستخدم للتطبيقات، خاصة تلك التي تستخدم WPF (Windows Presentation Foundation) وUWP (Universal Windows Platform) وXamarin Forms.

XAML، وهي لغة قائمة على XML، هي نسخة مايكروسوفت لوصف واجهة المستخدم الرسومية. من المحتمل أنك ستستخدم المصمم للعمل على ملفات XAML معظم الوقت، لكن لا يزال بإمكانك كتابة وتحرير واجهة المستخدم الخاصة بك.

## **تصدير العروض التقديمية إلى XAML باستخدام الخيارات الافتراضية**

يُظهر لك هذا الكود JavaScript كيفية تصدير عرض تقديمي إلى XAML باستخدام الإعدادات الافتراضية:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save(new aspose.slides.XamlOptions());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **تصدير العروض التقديمية إلى XAML باستخدام خيارات مخصصة**

يمكنك اختيار الخيارات من فئة [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/XamlOptions) التي تتحكم في عملية التصدير وتحدد كيفية تصدير Aspose.Slides للعرض التقديمي الخاص بك إلى XAML.

على سبيل المثال، إذا كنت ترغب أن يقوم Aspose.Slides بإضافة الشرائح المخفية من عرضك التقديمي عند تصديره إلى XAML، يمكنك ضبط طريقة [setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/XamlOptions#setExportHiddenSlides-boolean-) لتكون true. راجع هذا المثال JavaScript:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var xamlOptions = new aspose.slides.XamlOptions();
    xamlOptions.setExportHiddenSlides(true);
    pres.save(xamlOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **الأسئلة الشائعة**

**كيف يمكنني ضمان خطوط متوقعة إذا الخط الأصلي غير متاح على الجهاز؟**

استخدم [setDefaultRegularFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) في [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) — يتم استخدامه كخط احتياطي عندما يكون الأصلي مفقودًا. يساعد ذلك على تجنب الاستبدالات غير المتوقعة.

**هل يُقصد بالـ XAML المُصدّر أن يُستخدم فقط في WPF، أم يمكن استخدامه في أطر XAML أخرى أيضًا؟**

XAML هي لغة توصيف واجهة مستخدم عامة تُستخدم في WPF وUWP وXamarin.Forms. تستهدف عملية التصدير التوافق مع أطر Microsoft XAML؛ السلوك الدقيق والدعم للبُنى المحددة يعتمد على منصة الهدف. اختبر العلامات في بيئتك.

**هل يتم دعم الشرائح المخفية، وكيف يمكنني منع تصديرها بشكل افتراضي؟**

بشكل افتراضي، لا تُدرج الشرائح المخفية. يمكنك التحكم في هذا السلوك عبر [setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/setexporthiddenslides/) في [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) — احتفظ به معطلاً إذا لم تحتاج لتصديرها.