---
title: تصدير إلى XAML
type: docs
weight: 30
url: /java/export-to-xaml/

---

# تصدير العروض التقديمية إلى XAML

{{% alert color="primary" %}} 

في [Aspose.Slides 21.6](https://docs.aspose.com/slides/java/aspose-slides-for-java-21-6-release-notes/)، قمنا بتنفيذ دعم تصدير XAML. يمكنك الآن تصدير عروضك التقديمية إلى XAML. 

{{% /alert %}} 

# عن XAML

XAML هو لغة برمجة وصفية تسمح لك ببناء أو كتابة واجهات المستخدم للتطبيقات، خاصة تلك التي تستخدم WPF (Windows Presentation Foundation) وUWP (Universal Windows Platform) وXamarin forms.  

XAML، وهي لغة قائمة على XML، هي النسخة التي تستخدمها مايكروسوفت لوصف واجهة المستخدم. من المحتمل أن تستخدم مصممًا للعمل على ملفات XAML معظم الوقت، ولكن يمكنك أيضًا كتابة وتحرير واجهة المستخدم الخاصة بك. 

## تصدير العروض التقديمية إلى XAML مع الخيارات الافتراضية

يوضح هذا الكود بلغة Java كيفية تصدير عرض تقديمي إلى XAML مع الإعدادات الافتراضية:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save(new XamlOptions());
} finally {
	if (pres != null) pres.dispose();
}
```

## تصدير العروض التقديمية إلى XAML مع خيارات مخصصة

يمكنك اختيار خيارات من واجهة [IXamlOptions](https://reference.aspose.com/slides/java/com.aspose.slides/IXamlOptions) التي تتحكم في عملية التصدير وتحدد كيف تقوم Aspose.Slides بتصدير عرضك التقديمي إلى XAML. 

على سبيل المثال، إذا كنت ترغب في أن تقوم Aspose.Slides بإضافة شريحة مخفية من عرضك التقديمي عند تصديرها إلى XAML، يمكنك تعيين خاصية [ExportHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/IXamlOptions#setExportHiddenSlides-boolean-) إلى true. انظر هذا المثال من كود Java:

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