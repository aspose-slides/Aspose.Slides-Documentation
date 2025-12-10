---
title: تحويل عروض PowerPoint إلى صور GIF متحركة في C++
linktitle: PowerPoint إلى GIF
type: docs
weight: 65
url: /ar/cpp/convert-powerpoint-to-animated-gif/
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
- C++
- Aspose.Slides
description: "تحويل عروض PowerPoint (PPT, PPTX) بسهولة إلى صور GIF متحركة باستخدام Aspose.Slides للغة C++. نتائج سريعة وعالية الجودة."
---

## **تحويل العروض التقديمية إلى GIF متحرك باستخدام الإعدادات الافتراضية**

يعرض هذا المثال البرمجي بلغة C++ كيفية تحويل عرض تقديمي إلى GIF متحرك باستخدام الإعدادات القياسية:
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif);
```


سيتم إنشاء GIF المتحرك باستخدام المعلمات الافتراضية. 

{{%  alert  title="نصيحة"  color="primary"  %}} 

إذا كنت تفضل تخصيص معلمات الـ GIF، يمكنك استخدام الفئة [GifOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.gif_options). راجع المثال البرمجي أدناه. 

{{% /alert %}} 

## **تحويل العروض التقديمية إلى GIF متحرك باستخدام إعدادات مخصصة**

يعرض هذا المثال البرمجي كيفية تحويل عرض تقديمي إلى GIF متحرك باستخدام إعدادات مخصصة في C++:
``` cpp
auto gifOptions = System::MakeObject<GifOptions>();
// حجم GIF الناتج
gifOptions->set_FrameSize(Size(960, 720));
// المدة التي ستظهر فيها كل شريحة حتى يتم استبدالها بالأخرى
gifOptions->set_DefaultDelay(2000);
// زيادة عدد الإطارات في الثانية لتحسين جودة حركة الانتقال
gifOptions->set_TransitionFps(35);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif, gifOptions);
```


{{% alert title="معلومات" color="info" %}}

قد ترغب في تجربة أداة تحويل مجانية من النص إلى GIF تم تطويرها من قبل Aspose. 

{{% /alert %}}

## **الأسئلة الشائعة**

**ماذا لو لم تكن الخطوط المستخدمة في العرض التقديمي مثبتة على النظام؟**

قم بتثبيت الخطوط المفقودة أو [اضبط الخطوط الاحتياطية](/slides/ar/cpp/powerpoint-fonts/). ستستبدل Aspose.Slides الخطوط، لكن قد يختلف الشكل. من أجل الهوية التجارية، تأكد دائمًا من توفر الخطوط المطلوبة بشكل صريح.

**هل يمكنني إضافة علامة مائية على إطارات GIF؟**

نعم. [أضف كائنًا/شعارًا شبه شفاف](/slides/ar/cpp/watermark/) إلى الشريحة الأساسية أو إلى الشرائح الفردية قبل التصدير — ستظهر العلامة المائية على كل إطار.