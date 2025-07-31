---
title: Конвертируйте презентации в анимированные GIF на Python
linktitle: Презентация в GIF
type: docs
weight: 65
url: /ru/python-net/convert-powerpoint-to-animated-gif/
keywords:
- анимированный GIF
- конвертировать PowerPoint
- конвертировать OpenDocument
- конвертировать презентацию
- конвертировать слайд
- конвертировать PPT
- конвертировать PPTX
- конвертировать ODP
- PowerPoint в GIF
- OpenDocument в GIF
- презентация в GIF
- слайд в GIF
- PPT в GIF
- PPTX в GIF
- ODP в GIF
- настройки по умолчанию
- пользовательские настройки
- Python
- Aspose.Slides
description: "Легко конвертируйте презентации PowerPoint (PPT, PPTX) и файлы OpenDocument (ODP) в анимированные GIF с помощью Aspose.Slides for Python via .NET. Быстро и качественно."
---

## Конвертация презентаций в анимированный GIF с использованием настроек по умолчанию ##

Этот пример кода на Python показывает, как конвертировать презентацию в анимированный GIF с использованием стандартных настроек:

```py
import aspose.slides as slides

pres = slides.Presentation(path + "pres.pptx")
pres.save("pres.gif", slides.export.SaveFormat.GIF)
```

Анимированный GIF будет создан с параметрами по умолчанию.

{{%  alert  title="СОВЕТ"  color="primary"  %}} 

Если вы хотите настроить параметры для GIF, вы можете использовать класс [GifOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/gifoptions/). См. пример кода ниже. 

{{% /alert %}} 

## Конвертация презентаций в анимированный GIF с использованием пользовательских настроек ##
Этот пример кода показывает, как конвертировать презентацию в анимированный GIF, используя пользовательские настройки на Python:

```py
import aspose.slides as slides
import aspose.pydrawing as drawing

pres = slides.Presentation(path + "pres.pptx")

options = slides.export.GifOptions()
options.frame_size = drawing.Size(960, 720) # размер получившегося GIF  
options.default_delay = 2000 # как долго будет показываться каждый слайд, прежде чем перейти к следующему
options.transition_fps = 35  # увеличьте FPS для лучшего качества анимации перехода

pres.save("pres.gif", slides.export.SaveFormat.GIF, options)
```

{{% alert title="Информация" color="info" %}}

Вам может быть интересно ознакомиться с БЕСПЛАТНЫМ конвертером [Текст в GIF](https://products.aspose.app/slides/text-to-gif), разработанным Aspose. 

{{% /alert %}}