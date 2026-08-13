---
title: تحويل عروض PowerPoint إلى GIF متحركة في Java
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
- حفظ PPT كـ GIF
- حفظ PPTX كـ GIF
- تصدير PPT كـ GIF
- تصدير PPTX كـ GIF
- الإعدادات الافتراضية
- الإعدادات المخصصة
- PowerPoint
- العرض التقديمي
- Java
- Aspose.Slides
description: "قم بتحويل عروض PowerPoint (PPT، PPTX) بسهولة إلى GIF متحركة باستخدام Aspose.Slides للـ Java. نتائج سريعة وعالية الجودة."
---
## **نظرة عامة**

تتيح لك Aspose.Slides تحويل عروض PowerPoint إلى ملفات GIF متحركة ببضع أسطر من الشيفرة فقط. هذا مفيد عندما تحتاج إلى مشاركة محتوى الشرائح بتنسيق متحرك خفيف الوزن ومدعوم على نطاق واسع يمكن تضمينه في صفحات الويب أو التطبيقات المراسلة أو الوثائق. يشرح هذا المقال كيفية تصدير عرض تقديمي إلى GIF باستخدام الإعدادات الافتراضية وكيفية تخصيص الناتج عن طريق تكوين الخيارات مثل حجم الإطار، وتأخير الشريحة، ومعدل إطارات الانتقال من خلال [GifOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/gifoptions/).

## **تحويل العروض التقديمية إلى GIF متحرك باستخدام الإعدادات الافتراضية**

يعرض لك هذا الكود التجريبي في Java كيفية تحويل عرض تقديمي إلى GIF متحرك باستخدام الإعدادات القياسية:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
	pres.save("pres.gif", SaveFormat.Gif);
} finally {
	if (pres != null) pres.dispose();
}
```

سيتم إنشاء الـ GIF المتحرك باستخدام المعاملات الافتراضية. 

{{%  alert  title="TIP"  color="info"  %}} 
إذا كنت تفضل تخصيص المعاملات للـ GIF، يمكنك استخدام الفئة [GifOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/GifOptions). راجع الكود التجريبي أدناه. 
{{% /alert %}} 

## **تحويل العروض التقديمية إلى GIF متحرك باستخدام الإعدادات المخصصة**

يعرض لك هذا الكود التجريبي كيفية تحويل عرض تقديمي إلى GIF متحرك باستخدام إعدادات مخصصة في Java:

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation pres = new Presentation("pres.pptx");
try {
	GifOptions gifOptions = new GifOptions();
	gifOptions.setFrameSize(new Dimension(960, 720)); // حجم GIF الناتج
	gifOptions.setDefaultDelay(2000); // المدة التي ستظهر فيها كل شريحة حتى يتم الانتقال إلى التالية
	gifOptions.setTransitionFps(35); // زيادة عدد الإطارات في الثانية لتحسين جودة حركة الانتقال
	
	pres.save("pres.gif", SaveFormat.Gif, gifOptions);
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="Info" color="info" %}}
قد ترغب في تجربة محول [Text to GIF](https://products.aspose.app/slides/ar/text-to-gif) مجاني تم تطويره من قبل Aspose. 
{{% /alert %}}

## **الأسئلة المتكررة**

### ماذا لو لم تكن الخطوط المستخدمة في العرض التقديمي مثبتة على النظام؟

قم بتثبيت الخطوط المفقودة أو [تكوين خطوط الاحتياط](/slides/ar/java/powerpoint-fonts/). سيستبدل Aspose.Slides الخطوط، لكن قد يختلف الشكل. بالنسبة للعلامة التجارية، تأكد دائمًا من توفر الخطوط المطلوبة بصورة صريحة.

### هل يمكنني وضع علامة مائية على إطارات الـ GIF؟

نعم. [إضافة كائن/شعار شبه شفاف](/slides/ar/java/watermark/) إلى الشريحة الأساسية أو إلى الشرائح الفردية قبل التصدير — ستظهر العلامة المائية على كل إطار.