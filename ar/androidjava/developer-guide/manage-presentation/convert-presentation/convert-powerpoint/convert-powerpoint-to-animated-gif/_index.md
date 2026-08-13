---
title: تحويل عروض PowerPoint إلى GIF متحركة على Android
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
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تحويل عروض PowerPoint (PPT, PPTX) بسهولة إلى GIF متحركة باستخدام Aspose.Slides لنظام Android عبر Java. نتائج سريعة وعالية الجودة."
---
## **نظرة عامة**

Aspose.Slides يتيح لك تحويل عروض PowerPoint إلى ملفات GIF متحركة ببضع أسطر من الشيفرة. هذا مفيد عندما تحتاج إلى مشاركة محتوى الشرائح بصيغة خفيفة الوزن ومدعومة على نطاق واسع ويمكن تضمينها في صفحات الويب أو الرسائل أو الوثائق. يشرح هذا المقال كيفية تصدير عرض تقديمي إلى GIF باستخدام الإعدادات الافتراضية وكيفية تخصيص المخرجات من خلال تكوين خيارات مثل حجم الإطار، تأخير الشريحة، ومعدل إطارات الانتقال عبر [GifOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/gifoptions/).

## **تحويل العروض التقديمية إلى GIF متحرك باستخدام الإعدادات الافتراضية**

هذا المثال البرمجي بلغة Java يوضح لك كيفية تحويل عرض تقديمي إلى GIF متحرك باستخدام الإعدادات القياسية:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
	pres.save("pres.gif", SaveFormat.Gif);
} finally {
	if (pres != null) pres.dispose();
}
```

سيتم إنشاء GIF المتحرك بمعلمات افتراضية.

{{%  alert  title="TIP"  color="info"  %}} 
إذا رغبت في تخصيص المعلمات للـ GIF، يمكنك استخدام الفئة [GifOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/GifOptions). راجع الشيفرة النموذجية أدناه.
{{% /alert %}} 

## **تحويل العروض التقديمية إلى GIF متحرك باستخدام الإعدادات المخصصة**

هذا المثال البرمجي يوضح لك كيفية تحويل عرض تقديمي إلى GIF متحرك باستخدام إعدادات مخصصة في Java:

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation pres = new Presentation("pres.pptx");
try {
	GifOptions gifOptions = new GifOptions();
	gifOptions.setFrameSize(new Dimension(960, 720)); // حجم GIF الناتج  
	gifOptions.setDefaultDelay(2000); // مدة عرض كل شريحة قبل الانتقال إلى التالية
	gifOptions.setTransitionFps(35); // زيادة FPS لتحسين جودة الرسوم المتحركة للانتقال
	
	pres.save("pres.gif", SaveFormat.Gif, gifOptions);
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="Info" color="info" %}}
قد ترغب في تجربة محول [Text to GIF](https://products.aspose.app/slides/ar/text-to-gif) المجاني الذي طورته Aspose.
{{% /alert %}}

## **الأسئلة المتكررة**

### ماذا لو لم تكن الخطوط المستخدمة في العرض التقديمي مثبتة على النظام؟

قم بتثبيت الخطوط المفقودة أو [تهيئة خطوط الاحتياط](/slides/ar/androidjava/powerpoint-fonts/). سيقوم Aspose.Slides بالاستبدال، لكن قد يختلف الشكل. للهوية البصرية، تأكد دائمًا من توفر الخطوط المطلوبة بشكل صريح.

### هل يمكنني إضافة علامة مائية على إطارات GIF؟

نعم. يمكنك [إضافة كائن/شعار شبه شفاف](/slides/ar/androidjava/watermark/) إلى الشريحة الرئيسية أو إلى الشرائح الفردية قبل التصدير — ستظهر العلامة المائية على كل إطار.