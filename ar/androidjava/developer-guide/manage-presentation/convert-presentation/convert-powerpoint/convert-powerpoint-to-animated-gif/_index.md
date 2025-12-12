---
title: تحويل عروض PowerPoint التقديمية إلى ملفات GIF متحركة على Android
linktitle: PowerPoint إلى GIF
type: docs
weight: 65
url: /ar/androidjava/convert-powerpoint-to-animated-gif/
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
- حفظ PPT كـ GIF
- حفظ PPTX كـ GIF
- تصدير PPT كـ GIF
- تصدير PPTX كـ GIF
- الإعدادات الافتراضية
- الإعدادات المخصصة
- PowerPoint
- العرض التقديمي
- Android
- Java
- Aspose.Slides
description: "تحويل عروض PowerPoint (PPT، PPTX) بسهولة إلى GIF متحركة باستخدام Aspose.Slides للأندرويد عبر Java. نتائج سريعة وعالية الجودة."
---

## **تحويل العروض التقديمية إلى GIF متحرك باستخدام الإعدادات الافتراضية**

هذا مثال شفرة في Java يوضح لك كيفية تحويل عرض تقديمي إلى GIF متحرك باستخدام الإعدادات القياسية:
```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save("pres.gif", SaveFormat.Gif);
} finally {
	if (pres != null) pres.dispose();
}
```


سيتم إنشاء GIF المتحرك باستخدام المعلمات الافتراضية. 

{{%  alert  title="نصيحة"  color="primary"  %}} 

إذا كنت تفضل تخصيص المعلمات للـ GIF، يمكنك استخدام الفئة [GifOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GifOptions). راجع الشفرة النموذجية أدناه.

{{% /alert %}} 

## **تحويل العروض التقديمية إلى GIF متحرك باستخدام إعدادات مخصصة**

هذا المثال يوضح لك كيفية تحويل عرض تقديمي إلى GIF متحرك باستخدام إعدادات مخصصة في Java:
```java
Presentation pres = new Presentation("pres.pptx");
try {
	GifOptions gifOptions = new GifOptions();
	gifOptions.setFrameSize(new Dimension(960, 720)); // حجم GIF الناتج  
	gifOptions.setDefaultDelay(2000); // المدة التي ستظهر فيها كل شريحة حتى يتم تغييرها إلى التالية
	gifOptions.setTransitionFps(35); // زيادة عدد الإطارات في الثانية لتحسين جودة حركة الانتقال
	
	pres.save("pres.gif", SaveFormat.Gif, gifOptions);
} finally {
	if (pres != null) pres.dispose();
}
```


{{% alert title="معلومة" color="info" %}}

قد ترغب في تجربة محول مجاني [Text to GIF](https://products.aspose.app/slides/text-to-gif) تم تطويره بواسطة Aspose. 

{{% /alert %}}

## **الأسئلة المتكررة**

**ماذا يحدث إذا لم تكن الخطوط المستخدمة في العرض مثبتة على النظام؟**

قم بتثبيت الخطوط المفقودة أو [تكوين الخطوط الاحتياطية](/slides/ar/androidjava/powerpoint-fonts/). ستستبدل Aspose.Slides الخطوط، لكن قد يختلف المظهر. لضمان العلامة التجارية، تأكد دائمًا من توفر الخطوط المطلوبة بشكل صريح.

**هل يمكنني إضافة علامة مائية على إطارات الـ GIF؟**

نعم. [إضافة كائن/شعار شبه شفاف](/slides/ar/androidjava/watermark/) إلى الشريحة الرئيسية أو إلى الشرائح الفردية قبل التصدير — ستظهر العلامة المائية على كل إطار.