---
title: تحويل عروض PowerPoint التقديمية إلى GIF متحرك باستخدام C++
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
description: "قم بتحويل عروض PowerPoint التقديمية (PPT، PPTX) بسهولة إلى GIF متحركة باستخدام Aspose.Slides للغة C++. نتائج سريعة وعالية الجودة."
---

## **تحويل العروض التقديمية إلى GIF متحرك باستخدام الإعدادات الافتراضية**

يعرض لك هذا المثال البرمجي بلغة C++ كيفية تحويل عرض تقديمي إلى GIF متحرك باستخدام الإعدادات القياسية:
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif);
```


سيتم إنشاء GIF المتحرك باستخدام المعلمات الافتراضية. 

{{%  alert  title="TIP"  color="primary"  %}} 

إذا كنت تفضل تخصيص معلمات الـ GIF، يمكنك استخدام الفئة [GifOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.gif_options). راجع مثال الشيفرة أدناه. 

{{% /alert %}} 

## **تحويل العروض التقديمية إلى GIF متحرك باستخدام الإعدادات المخصصة**

يوضح لك هذا المثال البرمجي كيفية تحويل عرض تقديمي إلى GIF متحرك باستخدام إعدادات مخصصة في C++:
``` cpp
auto gifOptions = System::MakeObject<GifOptions>();
// حجم الـ GIF الناتج
gifOptions->set_FrameSize(Size(960, 720));
// مدة عرض كل شريحة قبل الانتقال إلى التالية
gifOptions->set_DefaultDelay(2000);
// زيادة عدد الإطارات في الثانية لتحسين جودة التحولات المتحركة
gifOptions->set_TransitionFps(35);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif, gifOptions);
```


{{% alert title="Info" color="info" %}}

قد ترغب في تجربة محول مجانية [Text to GIF](https://products.aspose.app/slides/text-to-gif) تم تطويره بواسطة Aspose. 

{{% /alert %}}

## **الأسئلة المتكررة**

**ماذا لو الخطوط المستخدمة في العرض التقديمي غير مثبتة على النظام؟**

قم بتثبيت الخطوط المفقودة أو [تكوين الخطوط الاحتياطية](/slides/ar/cpp/powerpoint-fonts/). سيقوم Aspose.Slides باستبدالها، لكن المظهر قد يختلف. بالنسبة للعلامة التجارية، احرص دائمًا على توفر الخطوط المطلوبة صراحةً.

**هل يمكنني وضع علامة مائية فوق إطارات GIF؟**

نعم. [Add a semi-transparent object/logo](/slides/ar/cpp/watermark/) إلى الشريحة الرئيسية أو إلى الشرائح الفردية قبل التصدير — ستظهر العلامة المائية على كل إطار.