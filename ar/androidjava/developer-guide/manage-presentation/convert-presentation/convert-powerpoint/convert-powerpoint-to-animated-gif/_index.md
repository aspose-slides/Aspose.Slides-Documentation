---
title: تحويل عروض PowerPoint إلى صور GIF متحركة على Android
linktitle: تحويل PowerPoint إلى GIF
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
description: "حوّل عروض PowerPoint (PPT, PPTX) بسهولة إلى صور GIF متحركة باستخدام Aspose.Slides للـ Android عبر Java. نتائج سريعة وعالية الجودة."
---

## **تحويل العروض التقديمية إلى GIF متحرك باستخدام الإعدادات الافتراضية**

يعرض لك هذا المثال البرمجي بلغة Java كيفية تحويل عرض تقديمي إلى GIF متحرك باستخدام الإعدادات القياسية:
```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save("pres.gif", SaveFormat.Gif);
} finally {
	if (pres != null) pres.dispose();
}
```


ستُنشأ صورة GIF المتحركة باستخدام المعلمات الافتراضية. 

{{%  alert  title="TIP"  color="primary"  %}} 
إذا كنت تفضل تخصيص المعلمات الخاصة بـ GIF، يمكنك استخدام الفئة [GifOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GifOptions). راجع المثال البرمجي أدناه.
{{% /alert %}} 

## **تحويل العروض التقديمية إلى GIF متحرك باستخدام الإعدادات المخصصة**

يعرض لك هذا المثال البرمجي كيفية تحويل عرض تقديمي إلى GIF متحرك باستخدام إعدادات مخصصة في Java:
```java
Presentation pres = new Presentation("pres.pptx");
try {
	GifOptions gifOptions = new GifOptions();
	gifOptions.setFrameSize(new Dimension(960, 720)); // حجم GIF الناتج
	gifOptions.setDefaultDelay(2000); // المدة التي تُعرض فيها كل شريحة حتى يتم الانتقال إلى التالية
	gifOptions.setTransitionFps(35); // زيادة FPS لتحسين جودة الرسوم المتحركة للانتقال
	
	pres.save("pres.gif", SaveFormat.Gif, gifOptions);
} finally {
	if (pres != null) pres.dispose();
}
```


{{% alert title="Info" color="info" %}}
قد ترغب في تجربة محول مجاني من النص إلى GIF [Text to GIF](https://products.aspose.app/slides/text-to-gif) تم تطويره بواسطة Aspose. 
{{% /alert %}}

## **الأسئلة الشائعة**

**ماذا لو لم تكن الخطوط المستخدمة في العرض التقديمي مثبتة على النظام؟**

قم بتثبيت الخطوط المفقودة أو [configure fallback fonts](/slides/ar/androidjava/powerpoint-fonts/). سيستبدل Aspose.Slides الخطوط، لكن قد يختلف المظهر. بالنسبة للهوية البصریة، احرص دائمًا على توفير الخطوط المطلوبة بشكل صريح.

**هل يمكنني إضافة علامة مائية على إطارات GIF؟**

نعم. [Add a semi-transparent object/logo](/slides/ar/androidjava/watermark/) إلى الشريحة الرئيسية أو إلى الشرائح الفردية قبل التصدير — ستظهر العلامة المائية على كل إطار.