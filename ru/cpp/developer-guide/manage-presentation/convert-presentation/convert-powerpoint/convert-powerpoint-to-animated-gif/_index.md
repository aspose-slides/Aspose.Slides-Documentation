---
title: "Преобразование презентаций PowerPoint в анимированные GIF в C++"
linktitle: "PowerPoint в GIF"
type: docs
weight: 65
url: /ru/cpp/convert-powerpoint-to-animated-gif/
keywords:
- анимированный GIF
- преобразовать PowerPoint
- преобразовать презентацию
- преобразовать слайд
- преобразовать PPT
- преобразовать PPTX
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
description: "Легко преобразуйте презентации PowerPoint (PPT, PPTX) в анимированные GIF с помощью Aspose.Slides для C++. Быстрые, высококачественные результаты."
---

## **Конвертирование презентаций в анимированный GIF с использованием настроек по умолчанию**

Этот пример кода на C++ показывает, как конвертировать презентацию в анимированный GIF, используя стандартные настройки:
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif);
```


Анимированный GIF будет создан с параметрами по умолчанию. 

{{%  alert  title="TIP"  color="primary"  %}} 

Если вы хотите настроить параметры GIF, можете использовать класс [GifOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.gif_options). См. пример кода ниже. 

{{% /alert %}} 

## **Конвертирование презентаций в анимированный GIF с пользовательскими настройками**

Этот пример кода показывает, как конвертировать презентацию в анимированный GIF, используя пользовательские настройки в C++:
``` cpp
auto gifOptions = System::MakeObject<GifOptions>();
// размер полученного GIF 
gifOptions->set_FrameSize(Size(960, 720));
// как долго каждый слайд будет показываться до перехода к следующему
gifOptions->set_DefaultDelay(2000);
// увеличьте FPS для улучшения качества анимации перехода
gifOptions->set_TransitionFps(35);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif, gifOptions);
```


{{% alert title="Info" color="info" %}}

Возможно, вам будет интересен БЕСПЛАТНЫЙ конвертер [Text to GIF](https://products.aspose.app/slides/text-to-gif), разработанный компанией Aspose. 

{{% /alert %}}

## **FAQ**

**Что делать, если шрифты, используемые в презентации, не установлены в системе?**

Установите отсутствующие шрифты или [configure fallback fonts](/slides/ru/cpp/powerpoint-fonts/). Aspose.Slides выполнит замену, но внешний вид может отличаться. Для брендинга всегда обеспечивайте явную доступность требуемых гарнитур.

**Могу ли я наложить водяной знак на кадры GIF?**

Да. [Add a semi-transparent object/logo](/slides/ru/cpp/watermark/) на образец слайда или на отдельные слайды перед экспортом — водяной знак будет отображаться на каждом кадре.