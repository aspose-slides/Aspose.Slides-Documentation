---
title: Переобразование презентаций PowerPoint в анимированные GIF в C++
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
description: "Легко преобразуйте презентации PowerPoint (PPT, PPTX) в анимированные GIF с помощью Aspose.Slides для C++. Быстрый, высококачественный результат."
---

## **Преобразование презентаций в анимированный GIF с использованием настроек по умолчанию**

Этот пример кода на C++ показывает, как преобразовать презентацию в анимированный GIF, используя стандартные настройки:
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif);
```


Анимированный GIF будет создан с параметрами по умолчанию. 

{{%  alert  title="TIP"  color="primary"  %}} 

Если вы хотите настроить параметры GIF, можете использовать класс [GifOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.gif_options). Смотрите пример кода ниже. 

{{% /alert %}} 

## **Преобразование презентаций в анимированный GIF с пользовательскими настройками**

Этот пример кода показывает, как преобразовать презентацию в анимированный GIF с пользовательскими настройками на C++:
``` cpp
auto gifOptions = System::MakeObject<GifOptions>();
// размер полученного GIF 
gifOptions->set_FrameSize(Size(960, 720));
// как долго каждый слайд будет показываться, пока не будет переключен на следующий
gifOptions->set_DefaultDelay(2000);
// увеличить FPS для лучшего качества анимации перехода
gifOptions->set_TransitionFps(35);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif, gifOptions);
```


{{% alert title="Info" color="info" %}}

Вы можете попробовать бесплатный конвертер [Text to GIF](https://products.aspose.app/slides/text-to-gif), разработанный Aspose. 

{{% /alert %}}

## **FAQ**

**Что делать, если шрифты, использованные в презентации, не установлены в системе?**

Установите отсутствующие шрифты или [настроить резервные шрифты](/slides/ru/cpp/powerpoint-fonts/). Aspose.Slides заменит их, но внешний вид может отличаться. Для брендинга всегда обеспечьте явную доступность необходимых гарнитур.

**Можно ли наложить водяной знак на кадры GIF?**

Да. [Добавить полупрозрачный объект/логотип](/slides/ru/cpp/watermark/) можно добавить на главный слайд или на отдельные слайды перед экспортом — водяной знак появится на каждом кадре.