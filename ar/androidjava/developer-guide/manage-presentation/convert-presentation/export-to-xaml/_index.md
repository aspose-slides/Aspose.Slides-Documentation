---
title: تصدير إلى XAML
type: docs
weight: 30
url: /ar/androidjava/export-to-xaml/

---

# تصدير العروض التقديمية إلى XAML

{{% alert color="primary" %}} 

في [Aspose.Slides 21.6](https://docs.aspose.com/slides/androidjava/aspose-slides-for-java-21-6-release-notes/)، قمنا بتنفيذ دعم لتصدير XAML. يمكنك الآن تصدير العروض التقديمية الخاصة بك إلى XAML.

{{% /alert %}} 

# حول XAML

XAML هي لغة برمجة وصفية تتيح لك بناء أو كتابة واجهات مستخدم للتطبيقات، خاصة تلك التي تستخدم WPF (Windows Presentation Foundation) و UWP (Universal Windows Platform) و Xamarin Forms.  

XAML، وهي لغة قائمة على XML، هي النسخة الخاصة بميكروسوفت لوصف واجهة المستخدم. من المحتمل أن تستخدم مصممًا للعمل على ملفات XAML معظم الوقت، ولكن يمكنك أيضًا كتابة وتحرير واجهة المستخدم الخاصة بك. 

## تصدير العروض التقديمية إلى XAML مع الخيارات الافتراضية

يوضح لك هذا الكود Java كيفية تصدير عرض تقديمي إلى XAML مع الإعدادات الافتراضية:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save(new XamlOptions());
} finally {
	if (pres != null) pres.dispose();
}
```

## تصدير العروض التقديمية إلى XAML مع خيارات مخصصة

يمكنك اختيار الخيارات من واجهة [IXamlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IXamlOptions) التي تتحكم في عملية التصدير وتحدد كيفية تصدير Aspose.Slides لعرضك التقديمي إلى XAML.

على سبيل المثال، إذا كنت تريد من Aspose.Slides إضافة الشرائح المخفية من عرضك التقديمي عند تصديره إلى XAML، يمكنك تعيين خاصية [ExportHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IXamlOptions#setExportHiddenSlides-boolean-) إلى true. انظر هذا الكود Java كمثال:

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