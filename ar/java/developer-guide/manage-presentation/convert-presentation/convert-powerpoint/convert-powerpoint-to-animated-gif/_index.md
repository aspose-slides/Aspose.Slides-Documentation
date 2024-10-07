---
title: تحويل PowerPoint إلى GIF متحرك
type: docs
weight: 65
url: /java/convert-powerpoint-to-animated-gif/
keywords: "تحويل PowerPoint إلى GIF متحرك، PPT إلى GIF، PPTX إلى GIF"
description: "تحويل PowerPoint إلى GIF متحرك: PPT إلى GIF، PPTX إلى GIF، باستخدام واجهة برمجة التطبيقات Aspose.Slides."
---

## تحويل العروض التقديمية إلى GIF متحرك باستخدام الإعدادات الافتراضية ##

تظهر لك هذه الكود النموذجي بلغة Java كيفية تحويل عرض تقديمي إلى GIF متحرك باستخدام الإعدادات القياسية:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save("pres.gif", SaveFormat.Gif);
} finally {
	if (pres != null) pres.dispose();
}
```

سيتم إنشاء GIF المتحرك باستخدام المعلمات الافتراضية.

{{% alert title="نصيحة" color="primary" %}} 

إذا كنت تفضل تخصيص المعلمات لـ GIF، يمكنك استخدام فئة [GifOptions](https://reference.aspose.com/slides/java/com.aspose.slides/GifOptions). انظر الكود النموذجي أدناه. 

{{% /alert %}} 

## تحويل العروض التقديمية إلى GIF متحرك باستخدام الإعدادات المخصصة ##
يوضح لك هذا الكود النموذجي كيفية تحويل عرض تقديمي إلى GIF متحرك باستخدام الإعدادات المخصصة بلغة Java:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	GifOptions gifOptions = new GifOptions();
	gifOptions.setFrameSize(new Dimension(960, 720)); // حجم GIF الناتج  
	gifOptions.setDefaultDelay(2000); // مدة عرض كل شريحة قبل الانتقال إلى الشريحة التالية
	gifOptions.setTransitionFps(35); // زيادة FPS لتحسين جودة انتقال الرسوم المتحركة
	
	pres.save("pres.gif", SaveFormat.Gif, gifOptions);
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="معلومات" color="info" %}}

قد ترغب في الاطلاع على محول [نص إلى GIF](https://products.aspose.app/slides/text-to-gif) مجاني تم تطويره بواسطة Aspose.

{{% /alert %}}