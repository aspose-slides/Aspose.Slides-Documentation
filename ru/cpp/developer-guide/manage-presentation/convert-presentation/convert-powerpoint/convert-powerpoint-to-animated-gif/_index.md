---
title: Преобразование презентаций PowerPoint в анимированные GIF в C++
linktitle: PowerPoint в GIF
type: docs
weight: 65
url: /ru/cpp/convert-powerpoint-to-animated-gif/
keywords:
- анимированный GIF
- конвертировать PowerPoint
- конвертировать презентацию
- конвертировать слайд
- конвертировать PPT
- конвертировать PPTX
- PowerPoint в GIF
- презентация в GIF
- слайд в GIF
- PPT в GIF
- PPTX в GIF
- сохранить PPT как GIF
- сохранить PPTX как GIF
- экспортировать PPT как GIF
- экспортировать PPTX как GIF
- настройки по умолчанию
- пользовательские настройки
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Легко конвертировать презентации PowerPoint (PPT, PPTX) в анимированные GIF с помощью Aspose.Slides для C++. Быстро, высококачественный результат."
---

## **Преобразование презентаций в анимированный GIF с использованием настроек по умолчанию**

Этот пример кода на C++ показывает, как преобразовать презентацию в анимированный GIF, используя стандартные настройки:
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif);
```


Анимированный GIF будет создан с параметрами по умолчанию. 

{{%  alert  title="TIP"  color="primary"  %}} 
Если вы хотите настроить параметры GIF, вы можете использовать класс [GifOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.gif_options). См. пример кода ниже. 
{{% /alert %}} 

## **Преобразование презентаций в анимированный GIF с использованием пользовательских настроек**

Этот пример кода показывает, как преобразовать презентацию в анимированный GIF с пользовательскими настройками на C++:
``` cpp
auto gifOptions = System::MakeObject<GifOptions>();
// размер результирующего GIF 
gifOptions->set_FrameSize(Size(960, 720));
// как долго каждый слайд будет отображаться, пока не переключится на следующий
gifOptions->set_DefaultDelay(2000);
// увеличить FPS для лучшего качества анимации переходов
gifOptions->set_TransitionFps(35);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif, gifOptions);
```


{{% alert title="Info" color="info" %}}
Возможно, вам будет интересен БЕСПЛАТНЫЙ конвертер [Text to GIF](https://products.aspose.app/slides/text-to-gif), разработанный Aspose. 
{{% /alert %}}

## **FAQ**

**Что делать, если шрифты, используемые в презентации, не установлены в системе?**

Установите недостающие шрифты или [configure fallback fonts](/slides/ru/cpp/powerpoint-fonts/). Aspose.Slides заменит их, но внешний вид может отличаться. Для брендинга всегда гарантируйте, что необходимые шрифты явно доступны.

**Можно ли наложить водяной знак на кадры GIF?**

Да. [Add a semi-transparent object/logo](/slides/ru/cpp/watermark/) на главный слайд или на отдельные слайды перед экспортом — водяной знак будет отображаться на каждом кадре.