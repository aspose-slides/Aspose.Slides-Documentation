---
title: تحويل عروض PowerPoint التقديمية إلى GIF متحرك في C++
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
description: "قم بسهولة بتحويل عروض PowerPoint التقديمية (PPT، PPTX) إلى GIF متحرك باستخدام Aspose.Slides لـ C++. نتائج سريعة وعالية الجودة."
---

## **تحويل العروض التقديمية إلى GIF متحرك باستخدام الإعدادات الافتراضية**

يعرض لك هذا الكود النموذجي بلغة C++ كيفية تحويل عرض تقديمي إلى GIF متحرك باستخدام الإعدادات القياسية:
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif);
```


سيتم إنشاء GIF المتحرك باستخدام المعلمات الافتراضية. 

{{%  alert  title="TIP"  color="primary"  %}} 

إذا كنت تفضل تخصيص المعلمات الخاصة بـ GIF، يمكنك استخدام الفئة [GifOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.gif_options). راجع الكود النموذجي أدناه. 

{{% /alert %}} 

## **تحويل العروض التقديمية إلى GIF متحرك باستخدام إعدادات مخصصة**

يعرض لك هذا الكود النموذجي كيفية تحويل عرض تقديمي إلى GIF متحرك باستخدام إعدادات مخصصة في C++:
``` cpp
auto gifOptions = System::MakeObject<GifOptions>();
// حجم GIF الناتج
gifOptions->set_FrameSize(Size(960, 720));
// المدة التي ستُعرض فيها كل شريحة قبل الانتقال إلى التالية
gifOptions->set_DefaultDelay(2000);
// زيادة عدد الإطارات في الثانية لتحسين جودة انتقال الرسوم المتحركة
gifOptions->set_TransitionFps(35);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif, gifOptions);
```


{{% alert title="Info" color="info" %}}

قد ترغب في تجربة محول مجاني من النص إلى GIF [Text to GIF](https://products.aspose.app/slides/text-to-gif) تم تطويره بواسطة Aspose. 

{{% /alert %}}

## **الأسئلة الشائعة**

**ماذا لو لم تكن الخطوط المستخدمة في العرض التقديمي مثبتة على النظام؟**

قم بتثبيت الخطوط المفقودة أو [تكوين الخطوط الاحتياطية](/slides/ar/cpp/powerpoint-fonts/). سيقوم Aspose.Slides باستبدالها، لكن قد يختلف المظهر. بالنسبة للهوية البصرية، تأكد دائمًا من توفر الخطوط المطلوبة بشكل صريح.

**هل يمكنني إضافة علامة مائية على إطارات الـ GIF؟**

نعم. [أضف كائن/شعار نصف شفاف](/slides/ar/cpp/watermark/) إلى الشريحة الرئيسية أو إلى الشرائح الفردية قبل التصدير — ستظهر العلامة المائية على كل إطار.