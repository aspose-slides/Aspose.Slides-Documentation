---
title: تحويل PowerPoint إلى GIF متحرك
type: docs
weight: 65
url: /androidjava/convert-powerpoint-to-animated-gif/
keywords: "تحويل PowerPoint إلى GIF متحرك، PPT إلى GIF، PPTX إلى GIF"
description: "تحويل PowerPoint إلى GIF متحرك: PPT إلى GIF، PPTX إلى GIF، باستخدام Aspose.Slides API."
---

## تحويل العروض التقديمية إلى GIF متحرك باستخدام الإعدادات الافتراضية ##

يظهر هذا الكود النموذجي بلغة Java كيفية تحويل عرض تقديمي إلى GIF متحرك باستخدام الإعدادات القياسية:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save("pres.gif", SaveFormat.Gif);
} finally {
	if (pres != null) pres.dispose();
}
```

سيتم إنشاء GIF المتحرك بالمعلمات الافتراضية.

{{%  alert  title="نصيحة"  color="primary"  %}} 

إذا كنت تفضل تخصيص المعلمات لـ GIF، يمكنك استخدام فئة [GifOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GifOptions). انظر الكود النموذجي أدناه.

{{% /alert %}} 

## تحويل العروض التقديمية إلى GIF متحرك باستخدام إعدادات مخصصة ##
يظهر هذا الكود النموذجي كيفية تحويل عرض تقديمي إلى GIF متحرك باستخدام إعدادات مخصصة بلغة Java:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	GifOptions gifOptions = new GifOptions();
	gifOptions.setFrameSize(new Dimension(960, 720)); // حجم GIF الناتج  
	gifOptions.setDefaultDelay(2000); // مدة عرض كل شريحة قبل الانتقال إلى الشريحة التالية
	gifOptions.setTransitionFps(35); // زيادة معدل الإطارات للحصول على جودة انتقال أفضل
	
	pres.save("pres.gif", SaveFormat.Gif, gifOptions);
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="معلومات" color="info" %}}

قد ترغب في الاطلاع على محول [Text to GIF](https://products.aspose.app/slides/text-to-gif) المجاني الذي طورته Aspose.

{{% /alert %}}