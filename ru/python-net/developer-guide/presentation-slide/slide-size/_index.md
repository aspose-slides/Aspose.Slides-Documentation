---
title: Размер слайда
type: docs
weight: 70
url: /ru/python-net/slide-size/
keywords: "Установить слайд, изменить размер слайда, PowerPoint Presentation, настраиваемый размер слайда, решить проблемы со слайдами, Python, Aspose.Slides"
descriptions: "Установите и измените размер слайда или соотношение сторон в PowerPoint на Python"
---

## Размеры слайдов в презентациях PowerPoint

Aspose.Slides для Python через .NET позволяет изменять размер слайда или соотношение сторон в презентациях PowerPoint. Если вы планируете распечатать свою презентацию или отображать ее слайды на экране, вам необходимо обратить внимание на размер слайда или соотношение сторон. 

Вот самые распространенные размеры слайдов и соотношения сторон:

- **Стандартный (соотношение 4:3)**

  Если ваша презентация будет отображаться на относительно старых устройствах или экранах, вы можете захотеть использовать эту настройку. 

- **Широкий экран (соотношение 16:9)** 

  Если ваша презентация будет просматриваться на современных проекторов или дисплеях, вы можете захотеть использовать эту настройку. 

Вы не можете использовать несколько настроек размера слайда в одной презентации. Когда вы выбираете размер слайда для презентации, эта настройка применяется ко всем слайдам в презентации. 

Если вы предпочитаете использовать специальный размер слайда для своих презентаций, мы настоятельно рекомендуем сделать это заранее. В идеале вы должны указать свой предпочтительный размер слайда в начале, то есть, когда вы только настраиваете презентацию — до того, как добавлять любой контент. Таким образом, вы избежите проблем, возникающих из-за (будущих) изменений, внесенных в размер слайдов. 

{{% alert color="primary" %}} 

 При использовании Aspose.Slides для создания презентации все слайды автоматически получают стандартный размер или соотношение 4:3.

{{% /alert %}} 

## Изменение размера слайда в презентациях 

 Этот образец кода демонстрирует, как изменить размер слайда в презентации на Python с помощью Aspose.Slides:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(slides.SlideSizeType.ON_SCREEN16X9, slides.SlideSizeScaleType.DO_NOT_SCALE)
    pres.save("pres-4x3-aspect-ratio.pptx", slides.export.SaveFormat.PPTX)
```

## Указание настраиваемых размеров слайдов в презентациях

Если стандартные размеры слайдов (4:3 и 16:9) не соответствуют вашим требованиям, вы можете решить использовать конкретный или уникальный размер слайда. Например, если вы планируете распечатать слайды полного размера из своей презентации на кастомной странице или если вы собираетесь отображать свою презентацию на определенных типах экранов, вам, вероятно, будет выгодно использовать настройку настраиваемого размера для своей презентации. 

Этот образец кода показывает, как использовать Aspose.Slides для Python через .NET, чтобы указать настраиваемый размер слайда для презентации на Python:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(780, 540, slides.SlideSizeScaleType.DO_NOT_SCALE) # Размер бумаги A4
    pres.save("pres-a4-slide-size.pptx", slides.export.SaveFormat.PPTX)
```

## Работа с проблемами при изменении размера слайдов в презентациях

После изменения размера слайда для презентации содержимое слайдов (например, изображения или объекты) может исказиться. По умолчанию объекты автоматически изменяются по размеру, чтобы соответствовать новому размеру слайда. Однако при изменении размера слайда презентации вы можете указать настройку, определяющую, как Aspose.Slides обрабатывает содержимое на слайдах.

В зависимости от того, что вы собираетесь делать или чего хотите достичь, вы можете использовать любые из этих настроек:

- `DO_NOT_SCALE`

  Если вы НЕ хотите, чтобы объекты на слайдах изменялись по размеру, используйте эту настройку.

- `ENSURE_FIT`

  Если вы хотите уменьшить размер слайда и вам нужно, чтобы Aspose.Slides уменьшил объекты на слайдах, чтобы они все помещались на слайды (так вы избегаете потери содержания), используйте эту настройку. 

- `MAXIMIZE`

  Если вы хотите увеличить размер слайда и вам нужно, чтобы Aspose.Slides увеличил объекты на слайдах, чтобы они были пропорциональны новому размеру слайда, используйте эту настройку. 

Этот образец кода показывает, как использовать настройку `MAXIMIZE` при изменении размера слайда в презентации:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
   pres.slide_size.set_size(slides.SlideSizeType.LEDGER, slides.SlideSizeScaleType.MAXIMIZE)
```