---
title: Конвертировать PowerPoint PPT в JPG на Python
linktitle: Конвертировать PowerPoint PPT в JPG
type: docs
weight: 60
url: /python-net/convert-powerpoint-to-jpg/
keywords: "python ppt в изображение, Конвертировать презентацию PowerPoint, JPG, JPEG, PowerPoint в JPG, PowerPoint в JPEG, PPT в JPG, PPTX в JPG, PPT в JPEG, PPTX в JPEG, Python, Aspose.Slides"
description: "Конвертировать PowerPoint в JPG на Python. Сохранить слайд как изображение JPG"
---

## **О конвертации PowerPoint в JPG**
С помощью [**Aspose.Slides .NET API**](https://products.aspose.com/slides/python-net/) вы можете конвертировать презентацию PowerPoint PPT или PPTX в изображение JPG на Python. Также можно конвертировать PPT/PPTX в BMP, PNG или SVG на Python. С помощью этих функций легко реализовать собственный просмотрщик презентаций, создать миниатюру для каждого слайда. Это может быть полезно, если вы хотите защитить слайды презентации от копирования, продемонстрировать презентацию в режиме только для чтения. Aspose.Slides позволяет конвертировать всю презентацию или определённый слайд в форматы изображений.

{{% alert color="primary" %}} 

Чтобы увидеть, как Aspose.Slides конвертирует PowerPoint в изображения JPG, вы можете попробовать эти бесплатные онлайн-конвертеры: PowerPoint [PPTX в JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) и [PPT в JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 

{{% /alert %}} 

![todo:image_alt_text](ppt-to-jpg.png)

## **Конвертация PowerPoint PPT/PPTX в JPG**
Вот шаги для конвертации PPT/PPTX в JPG:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите объект слайда типа [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) из коллекции [Presentation.Slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
3. Создайте миниатюру каждого слайда, а затем конвертируйте её в JPG. Метод [**ISlide.GetImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) используется для получения миниатюры слайда, он возвращает объект [IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/) в результате. Метод [GetImage](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) должен быть вызван у нужного слайда типа [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/), значения масштабов для полученной миниатюры передаются в этот метод.
4. После получения миниатюры слайда вызовите метод [**IImage.Save(string filename, ImageFormat format)**](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/) из объекта миниатюры. Передайте ему имя файла и формат изображения. 

{{% alert color="primary" %}} 
**Примечание**: Конвертация PPT/PPTX в JPG отличается от конвертации в другие типы в Aspose.Slides .NET API. Для других типов вы обычно используете метод [**IPresentation.SaveMethod(String, SaveFormat, ISaveOptions)**](https://reference.aspose.com/slides/python-net/aspose.slides/ipresentation/), но здесь вам нужен метод [**Image.Save(string filename, ImageFormat format)**](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.image.save?view=netframework-4.8).
{{% /alert %}} 

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

for sld in pres.slides:
    with sld.get_image(1, 1) as bmp:
        bmp.save("Slide_{num}.jpg".format(num=str(sld.slide_number)), slides.ImageFormat.JPEG)
```

## **Конвертация PowerPoint PPT/PPTX в JPG с настраиваемыми размерами**
Чтобы изменить размер полученной миниатюры и изображения JPG, вы можете установить значения *ScaleX* и *ScaleY*, передавая их в метод [**ISlide.GetImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/python-net/aspose.slides/islide/):

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

desiredX = 1200
desiredY = 800
scaleX = (float)(1.0 / pres.slide_size.size.width) * desiredX
scaleY = (float)(1.0 / pres.slide_size.size.height) * desiredY

for sld in pres.slides:
    with sld.get_image(scaleX, scaleY) as bmp:
        bmp.save("Slide_{num}.jpg".format(num=str(sld.slide_number)), slides.ImageFormat.JPEG)
```

{{% alert title="Совет" color="primary" %}}

Aspose предоставляет [БЕСПЛАТНОЕ веб-приложение Collage](https://products.aspose.app/slides/collage). С помощью этого онлайн-сервиса вы можете объединять [JPG в JPG](https://products.aspose.app/slides/collage/jpg) или PNG в PNG, создавать [фото-сетки](https://products.aspose.app/slides/collage/photo-grid) и так далее. 

Используя те же принципы, описанные в этой статье, вы можете конвертировать изображения из одного формата в другой. Для получения дополнительной информации смотрите эти страницы: конвертировать [изображение в JPG](https://products.aspose.com/slides/python-net/conversion/image-to-jpg/); конвертировать [JPG в изображение](https://products.aspose.com/slides/python-net/conversion/jpg-to-image/); конвертировать [JPG в PNG](https://products.aspose.com/slides/python-net/conversion/jpg-to-png/), конвертировать [PNG в JPG](https://products.aspose.com/slides/python-net/conversion/png-to-jpg/); конвертировать [PNG в SVG](https://products.aspose.com/slides/python-net/conversion/png-to-svg/), конвертировать [SVG в PNG](https://products.aspose.com/slides/python-net/conversion/svg-to-png/).

{{% /alert %}}

## **Смотрите также**

Смотрите другие варианты конвертации PPT/PPTX в изображение, такие как:

- [Конвертация PPT/PPTX в SVG](/slides/python-net/render-a-slide-as-an-svg-image/).