---
title: تصدير العروض التقديمية إلى XAML على Android
linktitle: العرض التقديمي إلى XAML
type: docs
weight: 30
url: /ar/androidjava/export-to-xaml/
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
- Android
- Java
- Aspose.Slides
description: "تحويل شرائح PowerPoint و OpenDocument إلى XAML في Java باستخدام Aspose.Slides لنظام Android — حل سريع وخالي من Office يحافظ على تنسيقك الأصلي."
---

## **تصدير العروض التقديمية إلى XAML**

{{% alert color="primary" %}} 
في [Aspose.Slides 21.6](https://docs.aspose.com/slides/androidjava/aspose-slides-for-java-21-6-release-notes/)، تم إضافة الدعم لتصدير XAML. يمكنك الآن تصدير عروضك التقديمية إلى XAML.
{{% /alert %}} 

## **حول XAML**

XAML هي لغة برمجة وصفية تتيح لك بناء أو كتابة واجهات مستخدم للتطبيقات، خاصةً تلك التي تستخدم WPF (Windows Presentation Foundation) وUWP (Universal Windows Platform) وXamarin Forms.  

XAML، التي هي لغة مستندة إلى XML، هي نسخة مايكروسوفت لوصف واجهة المستخدم الرسومية. من المرجح أن تستخدم مصممًا للعمل على ملفات XAML في الغالب، لكن لا يزال بإمكانك كتابة وتعديل واجهة المستخدم الخاصة بك. 

## **تصدير العروض التقديمية إلى XAML باستخدام الخيارات الافتراضية**

يعرض لك هذا الكود Java كيفية تصدير عرض تقديمي إلى XAML باستخدام الإعدادات الافتراضية:
```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save(new XamlOptions());
} finally {
	if (pres != null) pres.dispose();
}
```


## **تصدير العروض التقديمية إلى XAML باستخدام الخيارات المخصصة**

يمكنك اختيار الخيارات من واجهة [IXamlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IXamlOptions) التي تتحكم في عملية التصدير وتحدد كيفية تصدير Aspose.Slides للعرض التقديمي إلى XAML.

على سبيل المثال، إذا كنت تريد أن يضيف Aspose.Slides الشرائح المخفية من عرضك التقديمي عند تصديره إلى XAML، يمكنك تعيين الخاصية [ExportHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IXamlOptions#setExportHiddenSlides-boolean-) إلى true. انظر إلى مثال الكود Java هذا:
```java
Presentation pres = new Presentation("pres.pptx");
try {
	XamlOptions xamlOptions = new XamlOptions();
	xamlOptions.setExportHiddenSlides(true);
	pres.save(xamlOptions);
} finally {
	if (pres != null) pres.dispose();
}
```


## **الأسئلة المتكررة**

**كيف يمكنني ضمان خطوط متوقعة إذا لم يتوفر الخط الأصلي على الجهاز؟**

قم بتعيين [خط عادي افتراضي](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) في [XamlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xamloptions/) — يتم استخدامه كخط احتياطي عندما يكون الخط الأصلي مفقودًا. يساعد ذلك في تجنب الاستبدالات غير المتوقعة.

**هل XAML المصدر مخصص فقط لـ WPF، أم يمكن استخدامه في أطر XAML أخرى أيضًا؟**

XAML هي لغة توصيف واجهة مستخدم عامة تُستخدم في WPF وUWP وXamarin.Forms. يستهدف التصدير التوافق مع أطر Microsoft XAML؛ السلوك الدقيق والدعم للبُنى المحددة يعتمد على النظام الأساسي المستهدف. اختبر العلامات في بيئتك.

**هل يتم دعم الشرائح المخفية، وكيف يمكنني منع تصديرها بشكل افتراضي؟**

بشكل افتراضي، لا تُدرج الشرائح المخفية. يمكنك التحكم في هذا السلوك عبر [setExportHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) في [XamlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xamloptions/) — ابقِه معطلاً إذا لم تحتاج إلى تصديرها.