---
title: تحويل PowerPoint إلى GIF متحرك
type: docs
weight: 65
url: /ar/nodejs-java/convert-powerpoint-to-animated-gif/
keywords: "تحويل PowerPoint إلى GIF متحرك, PPT إلى GIF, PPTX إلى GIF"
description: "تحويل PowerPoint إلى GIF متحرك: PPT إلى GIF, PPTX إلى GIF, باستخدام Aspose.Slides API."
---

## **تحويل العروض التقديمية إلى GIF متحرك باستخدام الإعدادات الافتراضية**

يعرض لك هذا المثال البرمجي بلغة JavaScript كيفية تحويل عرض تقديمي إلى GIF متحرك باستخدام الإعدادات القياسية:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.gif", aspose.slides.SaveFormat.Gif);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


سيتم إنشاء GIF المتحرك باستخدام المعلمات الافتراضية. 

{{%  alert  title="TIP"  color="primary"  %}} 
إذا كنت تفضّل تخصيص معلمات GIF، يمكنك استخدام الفئة [GifOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GifOptions). راجع المثال البرمجي أدناه.
{{% /alert %}} 

## **تحويل العروض التقديمية إلى GIF متحرك باستخدام إعدادات مخصصة**

يعرض لك هذا المثال البرمجي كيفية تحويل عرض تقديمي إلى GIF متحرك باستخدام إعدادات مخصصة في JavaScript:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var gifOptions = new aspose.slides.GifOptions();
    gifOptions.setFrameSize(java.newInstanceSync("java.awt.Dimension", 960, 720));// حجم GIF الناتج
    gifOptions.setDefaultDelay(2000);// المدة التي ستظهر فيها كل شريحة قبل الانتقال إلى التالية
    gifOptions.setTransitionFps(35);// زيادة FPS لتحسين جودة حركة الانتقال
    pres.save("pres.gif", aspose.slides.SaveFormat.Gif, gifOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert title="Info" color="info" %}}
قد ترغب في تجربة محوّل مجاني من [نص إلى GIF](https://products.aspose.app/slides/text-to-gif) تم تطويره بواسطة Aspose. 
{{% /alert %}}

## **الأسئلة الشائعة**

**ماذا لو لم تكن الخطوط المستخدمة في العرض التقديمي مثبتة على النظام؟**

قم بتثبيت الخطوط المفقودة أو [ضبط الخطوط الاحتياطية](/slides/ar/nodejs-java/powerpoint-fonts/). سيقوم Aspose.Slides باستبدالها، لكن قد يختلف الشكل. لضمان التوافق مع العلامة التجارية، تأكد دائماً من توفر الخطوط المطلوبة بشكل صريح.

**هل يمكنني إضافة علامة مائية على إطارات GIF؟**

نعم. يمكنك [إضافة عنصر/شعار شبه شفاف](/slides/ar/nodejs-java/watermark/) إلى الشريحة الرئيسية أو إلى الشرائح الفردية قبل التصدير — ستظهر العلامة المائية على كل إطار.