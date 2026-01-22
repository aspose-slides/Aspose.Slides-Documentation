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
description: "تحويل شرائح PowerPoint وOpenDocument إلى XAML في Java باستخدام Aspose.Slides لأندرويد - حل سريع لا يتطلب Office ويحافظ على تنسيقك الأصلي."
---

## **تصدير العروض التقديمية إلى XAML**

يدعم Aspose.Slides تصدير XAML. يمكنك تحويل عروضك التقديمية إلى XAML.

## **حول XAML**

XAML هي لغة برمجة وصفية تتيح لك بناء أو كتابة واجهات المستخدم للتطبيقات، خاصة تلك التي تستخدم WPF (Windows Presentation Foundation) وUWP (Universal Windows Platform) وXamarin Forms.  

XAML، وهي لغة مبنية على XML، هي نسخة مايكروسوفت لوصف واجهة المستخدم الرسومية. من المحتمل أن تستخدم أداة تصميم للعمل على ملفات XAML معظم الوقت، ولكن لا يزال بإمكانك كتابة وتحرير واجهتك الرسومية. 

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


## **تصدير العروض التقديمية إلى XAML باستخدام خيارات مخصصة**

يمكنك اختيار الخيارات من واجهة [IXamlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IXamlOptions) التي تتحكم في عملية التصدير وتحدد كيفية تصدير Aspose.Slides لعرضك التقديمي إلى XAML.

على سبيل المثال، إذا كنت تريد أن يقوم Aspose.Slides بإضافة الشرائح المخفية من عرضك التقديمي عند تصديره إلى XAML، يمكنك ضبط الخاصية [ExportHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IXamlOptions#setExportHiddenSlides-boolean-) إلى true. انظر هذا الكود Java النموذجي:
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


## **الأسئلة الشائعة**

**كيف يمكنني ضمان خطوط متوقعة إذا كان الخط الأصلي غير متوفر على الجهاز؟**

قم بتعيين [خط عادي افتراضي](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) في [XamlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xamloptions/) — يُستخدم كخط احتياطي عندما يكون الخط الأصلي مفقودًا. يساعد ذلك في تجنب الاستبدالات غير المتوقعة.

**هل يُقصد من XAML المُصدّر أن يُستخدم فقط مع WPF، أم يمكن استخدامه في مجموعات XAML الأخرى أيضًا؟**

XAML هي لغة توصيف واجهة مستخدم عامة تُستخدم في WPF وUWP وXamarin.Forms. يهدف التصدير إلى التوافق مع مجموعات XAML من مايكروسوفت؛ السلوك الدقيق ودعم البنيات المحددة يعتمد على المنصة المستهدفة. اختبر العلامات في بيئتك.

**هل يتم دعم الشرائح المخفية، وكيف يمكنني منع تصديرها بشكل افتراضي؟**

بشكل افتراضي، لا تُدرج الشرائح المخفية. يمكنك التحكم في هذا السلوك عبر [setExportHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) في [XamlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xamloptions/) — احتفظ به غير مفعل إذا لم تكن بحاجة لتصديرها.