---
title: التصدير إلى XAML
type: docs
weight: 30
url: /ar/nodejs-java/export-to-xaml/
---

## **تصدير العروض التقديمية إلى XAML**

{{% alert color="primary" %}} 
في [Aspose.Slides 21.6](https://docs.aspose.com/slides/nodejs-java/aspose-slides-for-java-21-6-release-notes/)، أضفنا دعمًا لتصدير XAML. يمكنك الآن تصدير عروضك التقديمية إلى XAML.
{{% /alert %}} 

## **حول XAML**

XAML هي لغة برمجة وصفية تتيح لك بناء أو كتابة فئات المستخدم للتطبيقات، خاصةً تلك التي تستخدم WPF (Windows Presentation Foundation)، UWP (Universal Windows Platform)، وXamarin Forms.

XAML، التي هي لغة مبنية على XML، هي نسخة مايكروسوفت لوصف واجهة المستخدم الرسومية. من المحتمل أن تستخدم أداة التصميم للعمل على ملفات XAML معظم الوقت، ولكن لا يزال بإمكانك كتابة وتحرير واجهتك الرسومية. 

## **تصدير العروض التقديمية إلى XAML باستخدام الإعدادات الافتراضية**

يعرض لك رمز JavaScript هذا كيفية تصدير عرض تقديمي إلى XAML باستخدام الإعدادات الافتراضية:
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

يمكنك اختيار الخيارات من فئة [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/XamlOptions) التي تتحكم في عملية التصدير وتحدد كيف يقوم Aspose.Slides بتصدير عرضك التقديمي إلى XAML.

على سبيل المثال، إذا كنت ترغب في أن يضيف Aspose.Slides الشرائح المخفية من عرضك التقديمي عند تصديره إلى XAML، يمكنك تعيين الطريقة [setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/XamlOptions#setExportHiddenSlides-boolean-) إلى true. راجع هذا مثال كود JavaScript:
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


## **الأسئلة المتكررة**

**كيف يمكنني ضمان خطوط متوقعة إذا كان الخط الأصلي غير متوفر على الجهاز؟**

استخدم [setDefaultRegularFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) في [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) — يُستخدم كخط احتياطي عندما يكون الخط الأصلي مفقودًا. يساعد ذلك على تجنب الاستبدالات غير المتوقعة.

**هل XAML المُصدّر مخصص فقط لـ WPF، أم يمكن استخدامه في أطر XAML أخرى كذلك؟**

XAML هي لغة توصيف واجهة مستخدم عامة تُستخدم في WPF وUWP وXamarin.Forms. يستهدف التصدير التوافق مع أطر Microsoft XAML؛ السلوك الدقيق ودعم البُنى المحددة يعتمد على منصة الهدف. اختبر العلامات في بيئتك.

**هل يتم دعم الشرائح المخفية، وكيف يمكنني منع تصديرها بشكل افتراضي؟**

بشكل افتراضي، لا يتم تضمين الشرائح المخفية. يمكنك التحكم في هذا السلوك عبر [setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/setexporthiddenslides/) في [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) — حافظ على تعطيلها إذا لم تحتاج إلى تصديرها.