---
title: Конвертация PowerPoint в анимированный GIF
type: docs
weight: 65
url: /cpp/convert-powerpoint-to-animated-gif/
keywords: "Конвертация PowerPoint в анимированный GIF, "
description: "Конвертация PowerPoint в анимированный GIF: PPT в GIF, PPTX в GIF с использованием API Aspose.Slides."
---

## Конвертация презентаций в анимированный GIF с использованием стандартных настроек ##

Этот образец кода на C++ покажет вам, как конвертировать презентацию в анимированный GIF с использованием стандартных настроек:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif);
```

Анимированный GIF будет создан с параметрами по умолчанию. 

{{%  alert  title="СОВЕТ"  color="primary"  %}} 

Если вы предпочитаете настроить параметры для GIF, вы можете использовать класс [GifOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.gif_options). Смотрите образец кода ниже. 

{{% /alert %}} 

## Конвертация презентаций в анимированный GIF с использованием пользовательских настроек ##
Этот образец кода покажет вам, как конвертировать презентацию в анимированный GIF с использованием пользовательских настроек на C++:

``` cpp
auto gifOptions = System::MakeObject<GifOptions>();
// размер полученного GIF 
gifOptions->set_FrameSize(Size(960, 720));
// сколько времени будет показываться каждый слайд до его смены на следующий
gifOptions->set_DefaultDelay(2000);
// увеличьте FPS для улучшения качества анимации перехода
gifOptions->set_TransitionFps(35);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif, gifOptions);
```

{{% alert title="Информация" color="info" %}}

Вы можете ознакомиться с БЕСПЛАТНЫМ конвертером [Text to GIF](https://products.aspose.app/slides/text-to-gif), разработанным Aspose. 

{{% /alert %}}