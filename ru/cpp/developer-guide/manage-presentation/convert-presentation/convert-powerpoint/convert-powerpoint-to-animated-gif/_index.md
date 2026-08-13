---
title: Конвертировать презентации PowerPoint в анимированные GIF в C++
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
- презентацию в GIF
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
description: "Легко конвертировать презентации PowerPoint (PPT, PPTX) в анимированные GIF с помощью Aspose.Slides для C++. Быстрые, высококачественные результаты."
---
## **Обзор**

Aspose.Slides позволяет конвертировать презентации PowerPoint в анимированные GIF‑файлы всего несколькими строками кода. Это полезно, когда необходимо делиться содержимым слайдов в лёгком, широко поддерживаемом анимированном формате, который можно встраивать в веб‑страницы, мессенджеры или документацию. В этой статье объясняется, как экспортировать презентацию в GIF с использованием настроек по умолчанию и как настроить результат, задав параметры, такие как размер кадра, задержка между слайдами и частота кадров переходов, через [GifOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/gifoptions/).

## **Конвертация презентаций в анимированный GIF с использованием настроек по умолчанию**

Этот пример кода на C++ показывает, как конвертировать презентацию в анимированный GIF с использованием стандартных настроек:

``` cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif);
```

Анимированный GIF будет создан с параметрами по умолчанию. 

{{%  alert  title="TIP"  color="info"  %}} 
Если вы хотите настроить параметры GIF, используйте класс [GifOptions](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.export.gif_options). См. пример кода ниже. 
{{% /alert %}} 

## **Конвертация презентаций в анимированный GIF с пользовательскими настройками**

Этот пример кода показывает, как конвертировать презентацию в анимированный GIF с пользовательскими настройками на C++:

``` cpp
#include <DOM/Presentation.h>
#include <Export/GifOptions.h>
#include <Export/SaveFormat.h>
#include <drawing/size.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto gifOptions = System::MakeObject<GifOptions>();
// размер полученного GIF
gifOptions->set_FrameSize(System::Drawing::Size(960, 720));
// как долго каждый слайд будет отображаться, пока не будет заменён следующим
gifOptions->set_DefaultDelay(2000);
// увеличить FPS для лучшего качества анимации переходов
gifOptions->set_TransitionFps(35);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif, gifOptions);
```

{{% alert title="Info" color="info" %}}
Возможно, вам будет интересен бесплатный конвертер [Text to GIF](https://products.aspose.app/slides/ru/text-to-gif), разработанный компанией Aspose. 
{{% /alert %}}

## **FAQ**

### Что делать, если шрифты, используемые в презентации, не установлены в системе?

Установите недостающие шрифты или [configure fallback fonts](/slides/ru/cpp/powerpoint-fonts/). Aspose.Slides выполнит подстановку, но внешний вид может отличаться. Для брендинга всегда обеспечивайте явную доступность требуемых шрифтов.

### Можно ли наложить водяной знак на кадры GIF?

Да. [Add a semi-transparent object/logo](/slides/ru/cpp/watermark/) на главный слайд или на отдельные слайды перед экспортом — водяной знак появится на каждом кадре.