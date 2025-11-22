---
title: تحويل عروض PowerPoint إلى GIF متحرك في Java
linktitle: PowerPoint إلى GIF
type: docs
weight: 65
url: /ar/java/convert-powerpoint-to-animated-gif/
keywords:
- GIF متحرك
- تحويل PowerPoint
- تحويل العرض التقديمي
- تحويل الشريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى GIF
- العرض التقديمي إلى GIF
- الشريحة إلى GIF
- PPT إلى GIF
- PPTX إلى GIF
- حفظ PPT بصيغة GIF
- حفظ PPTX بصيغة GIF
- تصدير PPT بصيغة GIF
- تصدير PPTX بصيغة GIF
- الإعدادات الافتراضية
- الإعدادات المخصصة
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "قم بسهولة بتحويل عروض PowerPoint (PPT، PPTX) إلى GIF متحرك باستخدام Aspose.Slides لـ Java. نتائج سريعة وعالية الجودة."
---

## تحويل العروض التقديمية إلى GIF متحرك باستخدام الإعدادات الافتراضية ##

يوضح لك هذا المثال البرمجي بلغة Java كيفية تحويل عرض تقديمي إلى GIF متحرك باستخدام الإعدادات القياسية:
```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save("pres.gif", SaveFormat.Gif);
} finally {
	if (pres != null) pres.dispose();
}
```


سيتم إنشاء GIF المتحرك باستخدام المعلمات الافتراضية. 

{{%  alert  title="TIP"  color="primary"  %}} 
إذا كنت تفضل تخصيص المعلمات الخاصة بـ GIF، يمكنك استخدام الفئة [GifOptions](https://reference.aspose.com/slides/java/com.aspose.slides/GifOptions) . راجع مثال الكود أدناه. 
{{% /alert %}} 

## تحويل العروض التقديمية إلى GIF متحرك باستخدام الإعدادات المخصصة ##
هذا المثال البرمجي يوضح لك كيفية تحويل عرض تقديمي إلى GIF متحرك باستخدام إعدادات مخصصة في Java:
```java
Presentation pres = new Presentation("pres.pptx");
try {
	GifOptions gifOptions = new GifOptions();
	gifOptions.setFrameSize(new Dimension(960, 720)); // حجم GIF الناتج  
	gifOptions.setDefaultDelay(2000); // المدة التي ستُعرض فيها كل شريحة قبل الانتقال إلى التالية
	gifOptions.setTransitionFps(35); // زيادة عدد الإطارات في الثانية لتحسين جودة حركة الانتقال
	
	pres.save("pres.gif", SaveFormat.Gif, gifOptions);
} finally {
	if (pres != null) pres.dispose();
}
```


{{% alert title="Info" color="info" %}}
قد ترغب في تجربة محول مجاني من النص إلى GIF طورته Aspose. 
{{% /alert %}}