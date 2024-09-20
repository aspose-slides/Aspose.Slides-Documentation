---
title: Конвертация PowerPoint в PNG
type: docs
weight: 30
url: /python-net/convert-powerpoint-to-png/
keywords: PowerPoint в PNG, PPT в PNG, PPTX в PNG, Python, Aspose.Slides для Python через .NET
description: Конвертация презентации PowerPoint в PNG
---

## **О конвертации PowerPoint в PNG**

Формат PNG (Portable Network Graphics) не так популярен, как JPEG (Joint Photographic Experts Group), но всё же очень распространён.

**Случай использования:** Когда у вас есть сложное изображение и размер не имеет значения, PNG является лучшим форматом изображения, чем JPEG.

{{% alert title="Совет" color="primary" %}} Вам может быть интересно ознакомиться с бесплатными **конвертерами PowerPoint в PNG** от Aspose: [PPTX в PNG](https://products.aspose.app/slides/conversion/pptx-to-png) и [PPT в PNG](https://products.aspose.app/slides/conversion/ppt-to-png). Это действующая реализация процесса, описанного на этой странице. {{% /alert %}}

## **Конвертация PowerPoint в PNG**

Следуйте этим шагам:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите объект слайда из коллекции [Presentation.Slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) через интерфейс [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/).
3. Используйте метод [ISlide.GetImage](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) для получения миниатюры для каждого слайда.
4. Используйте метод [IPresentation.SaveMethod(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/python-net/aspose.slides/ipresentation/) для сохранения миниатюры слайда в формате PNG.

Этот код на Python показывает, как конвертировать презентацию PowerPoint в PNG:

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

for index in range(pres.slides.length):
    slide = pres.slides[index]
    with slide.get_image() as image:
        image.save("slide_{i}.png".format(i = index), slides.ImageFormat.PNG)
```

## **Конвертация PowerPoint в PNG с пользовательскими размерами**

Если вы хотите получить PNG-файлы определенного масштаба, вы можете установить значения `desiredX` и `desiredY`, которые определяют размеры результирующей миниатюры.

Этот код на Python демонстрирует описанную операцию:

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

scaleX = 2
scaleY = 2
for index in range(pres.slides.length):
    slide = pres.slides[index]
    with slide.get_image(scaleX, scaleY) as image:
        image.save("slide_{index}.png".format(index=index), slides.ImageFormat.PNG)
```

## **Конвертация PowerPoint в PNG с заданным размером**

Если вы хотите получить PNG-файлы определенного размера, вы можете передать свои предпочтительные аргументы `width` и `height` для `ImageSize`.

Этот код показывает, как конвертировать PowerPoint в PNG, указывая размер для изображений:

```py
import aspose.slides as slides
import aspose.pydrawing as drawing

pres = slides.Presentation(path + "pres.pptx")

size = drawing.Size(960, 720)

for index in range(pres.slides.length):
    slide = pres.slides[index]
    with slide.get_image(size) as image:
        image.save("slide_{index}.png".format(index=index), slides.ImageFormat.PNG)
```