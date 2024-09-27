---
title: Конвертация PowerPoint в JPG на C#
linktitle: Конвертация PowerPoint PPT в JPG
type: docs
weight: 60
url: /ru/net/convert-powerpoint-to-jpg/
keywords: "Конвертация презентации PowerPoint, JPG, JPEG, PowerPoint в JPG, PowerPoint в JPEG, PPT в JPG, PPTX в JPG, PPT в JPEG, PPTX в JPEG, C#, Csharp, .NET, Aspose.Slides"
description: "Конвертация PowerPoint в JPG на C# или .NET. Сохранение слайда как изображения JPG"
---

## **Обзор**

В этой статье объясняется, как конвертировать презентацию PowerPoint в формат JPG с использованием C#. Рассматриваются следующие темы:

- [C# Конвертация PowerPoint в JPG](#convert-powerpoint-pptpptx-to-jpg)
- [C# Конвертация PPT в JPG](#convert-powerpoint-pptpptx-to-jpg)
- [C# Конвертация PPTX в JPG](#convert-powerpoint-pptpptx-to-jpg)
- [C# Конвертация ODP в JPG](#convert-powerpoint-pptpptx-to-jpg)
- [C# Конвертация слайда PowerPoint в изображение](#convert-powerpoint-pptpptx-to-jpg)

## **C# PowerPoint в JPG**

Для получения примера кода на C# для конвертации PowerPoint в JPG, пожалуйста, ознакомьтесь с разделом ниже т.е. [Конвертация PowerPoint в JPG](#convert-powerpoint-pptpptx-to-jpg). Код может загружать несколько форматов, таких как PPT, PPTX и ODP в объект Presentation, а затем сохранять его миниатюру слайда в формате JPG. Другие конверсии PowerPoint в изображения, подобные PNG, BMP, TIFF и SVG, обсуждаются в этих статьях.

- [C# PowerPoint в PNG](https://docs.aspose.com/slides/net/convert-powerpoint-to-png/)
- [C# PowerPoint в BMP](#convert-powerpoint-pptpptx-to-jpg)
- [C# PowerPoint в TIFF](https://docs.aspose.com/slides/net/convert-powerpoint-to-tiff/)
- [C# PowerPoint в SVG](https://docs.aspose.com/slides/net/render-a-slide-as-an-svg-image/)

## **О конвертации PowerPoint в JPG**
С помощью [**Aspose.Slides .NET API**](https://products.aspose.com/slides/net/) вы можете конвертировать презентацию PowerPoint PPT или PPTX в изображение JPG. Также возможно конвертировать PPT/PPTX в BMP, PNG или SVG. С этими функциями легко реализовать свой собственный просмотрщик презентаций, создать миниатюру для каждого слайда. Это может быть полезно, если вы хотите защитить слайды презентации от копирования, демонстрировать презентацию в режиме только для чтения. Aspose.Slides позволяет конвертировать всю презентацию или определенный слайд в форматы изображений. 

{{% alert color="primary" %}} 

Чтобы увидеть, как Aspose.Slides конвертирует PowerPoint в изображения JPG, вы можете попробовать эти бесплатные онлайн-конвертеры: PowerPoint [PPTX в JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) и [PPT в JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 

{{% /alert %}} 

![todo:image_alt_text](ppt-to-jpg.png)

## **Конвертация PowerPoint PPT/PPTX в JPG**
Вот шаги для конвертации PPT/PPTX в JPG:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Получите объект слайда типа [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide) из коллекции [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides).
3. Создайте миниатюру каждого слайда, а затем конвертируйте его в JPG. Метод [**ISlide.GetThumbnail(float scaleX, float scaleY)**](https://reference.aspose.com/slides/net/aspose.slides.islide/getthumbnail/methods/6) используется для получения миниатюры слайда, он возвращает объект [Bitmap](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.bitmap?view=netframework-4.8) в качестве результата. Метод [GetThumbnail](https://reference.aspose.com/slides/net/aspose.slides.islide/getthumbnail/methods/6) должен быть вызван для нужного слайда типа [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide), значения масштабов полученной миниатюры передаются в метод.
4. После получения миниатюры слайда вызовите метод [**Image.Save(string filename, ImageFormat format)**](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.image.save?view=netframework-4.8) из объекта миниатюры. Передайте в него имя результирующего файла и формат изображения. 

{{% alert color="primary" %}} 
**Примечание**: Конвертация PPT/PPTX в JPG отличается от конвертации в другие типы в Aspose.Slides .NET API. Для других типов вы обычно используете метод [**IPresentation.SaveMethod(String, SaveFormat, ISaveOptions)** ](https://reference.aspose.com/slides/net/aspose.slides.ipresentation/save/methods/5), но здесь вам нужен метод [**Image.Save(string filename, ImageFormat format)**](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.image.save?view=netframework-4.8).
{{% /alert %}} 

```c#
using (Presentation pres = new Presentation("PowerPoint-Presentation.ppt"))
{
	foreach (ISlide sld in pres.Slides)
	{
		// Создает изображение полного масштаба
		Bitmap bmp = sld.GetThumbnail(1f, 1f);

		// Сохраняет изображение на диск в формате JPEG
		bmp.Save(string.Format("Slide_{0}.jpg", sld.SlideNumber), System.Drawing.Imaging.ImageFormat.Jpeg);
	}
}
```

## **Конвертация PowerPoint PPT/PPTX в JPG с настроенными размерами**
Чтобы изменить размеры полученной миниатюры и изображения JPG, вы можете установить значения *ScaleX* и *ScaleY*, передав их в метод [**ISlide.GetThumbnail(float scaleX, float scaleY)**](https://reference.aspose.com/slides/net/aspose.slides.islide/getthumbnail/methods/6):

```c#
using (Presentation pres = new Presentation("PowerPoint-Presentation.pptx"))
{
	// Определяет размеры
	int желаемыйX = 1200;
	int желаемыйY = 800;
	// Получает масштабированные значения X и Y
	float ScaleX = (float)(1.0 / pres.SlideSize.Size.Width) * желаемыйX;
	float ScaleY = (float)(1.0 / pres.SlideSize.Size.Height) * желаемыйY;

	foreach (ISlide sld in pres.Slides)
	{
		// Создает изображение полного масштаба
		Bitmap bmp = sld.GetThumbnail(ScaleX, ScaleY);

		// Сохраняет изображение на диск в формате JPEG
		bmp.Save(string.Format("Slide_{0}.jpg", sld.SlideNumber), System.Drawing.Imaging.ImageFormat.Jpeg);
	}
}
```

## **Отображение комментариев при сохранении презентации в изображение**
Aspose.Slides для .NET предоставляет возможность отображать комментарии в слайдах презентации при конвертации этих слайдов в изображения. Этот код на C# демонстрирует операцию:

```c#
Presentation pres = new Presentation("test.pptx");
Bitmap bmp = new Bitmap(740, 960);

IRenderingOptions opts = new RenderingOptions();
opts.NotesCommentsLayouting.NotesPosition = NotesPositions.BottomTruncated;
opts.NotesCommentsLayouting.CommentsAreaColor = Color.Red;
opts.NotesCommentsLayouting.CommentsAreaWidth = 200;
opts.NotesCommentsLayouting.CommentsPosition = CommentsPositions.Right;

using (Graphics graphics = Graphics.FromImage(bmp))
{
	pres.Slides[0].RenderToGraphics(opts, graphics);
}
bmp.Save("OutPresBitmap.png", ImageFormat.Png);
System.Diagnostics.Process.Start("OutPresBitmap.png");
```

{{% alert title="Совет" color="primary" %}}

Aspose предоставляет [БЕСПЛАТНОЕ веб-приложение Collage](https://products.aspose.app/slides/collage). С помощью этого онлайн-сервиса вы можете объединять [JPG в JPG](https://products.aspose.app/slides/collage/jpg) или изображения PNG в PNG, создавать [фото сетки](https://products.aspose.app/slides/collage/photo-grid) и так далее. 

Используя те же принципы, описанные в этой статье, вы можете конвертировать изображения из одного формата в другой. Для получения дополнительной информации смотрите эти страницы: конвертировать [изображение в JPG](https://products.aspose.com/slides/net/conversion/image-to-jpg/); конвертировать [JPG в изображение](https://products.aspose.com/slides/net/conversion/jpg-to-image/); конвертировать [JPG в PNG](https://products.aspose.com/slides/net/conversion/jpg-to-png/), конвертировать [PNG в JPG](https://products.aspose.com/slides/net/conversion/png-to-jpg/); конвертировать [PNG в SVG](https://products.aspose.com/slides/net/conversion/png-to-svg/), конвертировать [SVG в PNG](https://products.aspose.com/slides/net/conversion/svg-to-png/).

{{% /alert %}}

## **Смотрите также**

Смотрите другие варианты конвертации PPT/PPTX в изображения, такие как:

- [Конвертация PPT/PPTX в SVG](/slides/ru/net/render-a-slide-as-an-svg-image/).