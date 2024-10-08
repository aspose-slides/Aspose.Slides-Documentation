---
title: تحويل PowerPoint إلى GIF متحرك
type: docs
weight: 65
url: /ar/cpp/convert-powerpoint-to-animated-gif/
keywords: "تحويل PowerPoint إلى GIF متحرك, "
description: "تحويل PowerPoint إلى GIF متحرك: PPT إلى GIF، PPTX إلى GIF، باستخدام Aspose.Slides API."
---

## تحويل العروض التقديمية إلى GIF متحرك باستخدام الإعدادات الافتراضية ##

هذا الكود النموذجي في C++ يوضح لك كيفية تحويل عرض تقديمي إلى GIF متحرك باستخدام الإعدادات القياسية:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif);
```

سيتم إنشاء GIF المتحرك بمعلمات افتراضية.

{{%  alert  title="نصيحة"  color="primary"  %}} 

إذا كنت تفضل تخصيص المعلمات لـ GIF، يمكنك استخدام فئة [GifOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.gif_options). راجع الكود النموذجي أدناه.

{{% /alert %}} 

## تحويل العروض التقديمية إلى GIF متحرك باستخدام الإعدادات المخصصة ##
هذا الكود النموذجي يوضح لك كيفية تحويل عرض تقديمي إلى GIF متحرك باستخدام الإعدادات المخصصة في C++:

``` cpp
auto gifOptions = System::MakeObject<GifOptions>();
// حجم GIF الناتج
gifOptions->set_FrameSize(Size(960, 720));
// مدة عرض كل شريحة قبل الانتقال إلى الشريحة التالية
gifOptions->set_DefaultDelay(2000);
// زيادة FPS لتحسين جودة انتقال الرسوم المتحركة
gifOptions->set_TransitionFps(35);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif, gifOptions);
```

{{% alert title="معلومات" color="info" %}}

قد ترغب في الاطلاع على محول [نص إلى GIF](https://products.aspose.app/slides/text-to-gif) مجاني تم تطويره بواسطة Aspose.

{{% /alert %}}