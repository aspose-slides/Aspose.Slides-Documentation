---
title: تحويل عروض PowerPoint إلى GIF متحرك في C++
linktitle: PowerPoint إلى GIF
type: docs
weight: 65
url: /ar/cpp/convert-powerpoint-to-animated-gif/
keywords:
- GIF متحرك
- تحويل PowerPoint
- تحويل عرض تقديمي
- تحويل شريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى GIF
- عرض تقديمي إلى GIF
- شريحة إلى GIF
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
- C++
- Aspose.Slides
description: "تحويل عروض PowerPoint (PPT, PPTX) إلى GIF متحرك بسهولة باستخدام Aspose.Slides للـ C++. نتائج سريعة وعالية الجودة."
---

## **تحويل العروض التقديمية إلى GIF متحرك باستخدام الإعدادات الافتراضية**

يُظهر لك هذا المثال البرمجي بلغة C++ كيفية تحويل عرض تقديمي إلى GIF متحرك باستخدام الإعدادات القياسية:
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif);
```


سيتم إنشاء الـ GIF المتحرك باستخدام المعاملات الافتراضية. 

{{%  alert  title="TIP"  color="primary"  %}} 

إذا كنت تفضل تخصيص المعاملات للـ GIF، يمكنك استخدام الفئة [GifOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.gif_options). راجع المثال البرمجي أدناه. 

{{% /alert %}} 

## **تحويل العروض التقديمية إلى GIF متحرك باستخدام إعدادات مخصصة**

يعرض لك هذا المثال البرمجي كيفية تحويل عرض تقديمي إلى GIF متحرك باستخدام إعدادات مخصصة بلغة C++:
``` cpp
auto gifOptions = System::MakeObject<GifOptions>();
// حجم GIF الناتج
gifOptions->set_FrameSize(Size(960, 720));
// مدة عرض كل شريحة قبل الانتقال إلى التالية
gifOptions->set_DefaultDelay(2000);
// زيادة عدد الإطارات في الثانية لتحسين جودة انتقال الرسوم المتحركة
gifOptions->set_TransitionFps(35);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif, gifOptions);
```


{{% alert title="Info" color="info" %}}

قد ترغب في الاطلاع على محول مجاني من نوع [Text to GIF](https://products.aspose.app/slides/text-to-gif) تم تطويره بواسطة Aspose. 

{{% /alert %}}

## **الأسئلة المتكررة**

**ماذا لو لم تكن الخطوط المستخدمة في العرض التقديمي مثبتة على النظام؟**

قم بتثبيت الخطوط المفقودة أو [تكوين الخطوط الاحتياطية](/slides/ar/cpp/powerpoint-fonts/). سيستبدل Aspose.Slides الخطوط، لكن قد يختلف المظهر. بالنسبة للعلامة التجارية، تأكد دائمًا من توفر الخطوط المطلوبة صراحة.

**هل يمكنني وضع علامة مائية على إطارات الـ GIF؟**

نعم. [أضف كائنًا/شعارًا شبه شفاف](/slides/ar/cpp/watermark/) إلى الشريحة الأساسية أو إلى الشرائح الفردية قبل التصدير — ستظهر العلامة المائية على كل إطار.