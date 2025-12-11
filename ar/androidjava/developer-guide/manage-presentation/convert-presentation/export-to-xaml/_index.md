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
- أندرويد
- جافا
- Aspose.Slides
description: "تحويل شرائح PowerPoint و OpenDocument إلى XAML في Java باستخدام Aspose.Slides للأندرويد—حل سريع وخالٍ من Office يحافظ على تخطيطك دون تعديل."
---

## **تصدير العروض التقديمية إلى XAML**

{{% alert color="primary" %}} 

في [Aspose.Slides 21.6](https://docs.aspose.com/slides/androidjava/aspose-slides-for-java-21-6-release-notes/)، قمنا بتنفيذ دعم لتصدير XAML. يمكنك الآن تصدير عروضك التقديمية إلى XAML.

{{% /alert %}} 

## **حول XAML**

XAML هي لغة برمجة وصفية تتيح لك بناء أو كتابة واجهات المستخدم للتطبيقات، خاصةً تلك التي تستخدم WPF (Windows Presentation Foundation) أو UWP (Universal Windows Platform) أو نماذج Xamarin.  

XAML، التي هي لغة مبنية على XML، هي نسخة مايكروسوفت لوصف واجهة المستخدم الرسومية. من المحتمل أن تستخدم المصمم للعمل على ملفات XAML في معظم الأوقات، ولكن لا يزال بإمكانك كتابة وتحرير واجهة المستخدم الخاصة بك. 

## **تصدير العروض التقديمية إلى XAML باستخدام الخيارات الافتراضية**

يظهر لك هذا الكود Java كيفية تصدير عرض تقديمي إلى XAML باستخدام الإعدادات الافتراضية:
```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save(new XamlOptions());
} finally {
	if (pres != null) pres.dispose();
}
```


## **تصدير العروض التقديمية إلى XAML باستخدام الخيارات المخصصة**

يمكنك اختيار الخيارات من واجهة [IXamlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IXamlOptions) التي تتحكم في عملية التصدير وتحدد كيفية قيام Aspose.Slides بتصدير عرضك التقديمي إلى XAML.

على سبيل المثال، إذا أردت أن يقوم Aspose.Slides بإضافة الشرائح المخفية من عرضك التقديمي عند تصديره إلى XAML، يمكنك ضبط الخاصية [ExportHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IXamlOptions#setExportHiddenSlides-boolean-) إلى true. شاهد هذا المثال من كود Java:
{{6e4b7983-237f-4792-8f64-0ae095d7ac5}}

## **الأسئلة المتكررة**

**كيف يمكنني ضمان خطوط متوقعة إذا لم يكن الخط الأصلي متوفرًا على الجهاز؟**

قم بتعيين [خط عادي افتراضي](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) في [XamlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xamloptions/) — يُستخدم كخط احتياطي عندما يكون الخط الأصلي مفقودًا. يساعد ذلك على تجنب الاستبدالات غير المتوقعة.

**هل يُقصد بـ XAML المُصدَّر فقط لـ WPF، أم يمكن استخدامه في أنظمة XAML أخرى أيضًا؟**

XAML هي لغة توصيف عامة لواجهة المستخدم تُستخدم في WPF وUWP وXamarin.Forms. تستهدف عملية التصدير التوافق مع أنظمة Microsoft XAML؛ السلوك الدقيق والدعم للبنود المحددة يعتمد على المنصة المستهدفة. اختبر العلامات في بيئتك.

**هل يتم دعم الشرائح المخفية، وكيف يمكنني منع تصديرها بشكل افتراضي؟**

بشكل افتراضي، لا يتم تضمين الشرائح المخفية. يمكنك التحكم في هذا السلوك عبر [setExportHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) في [XamlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xamloptions/) — اتركه معطلاً إذا لم تحتاج إلى تصديرها.