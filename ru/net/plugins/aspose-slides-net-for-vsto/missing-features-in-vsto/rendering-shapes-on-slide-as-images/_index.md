---
title: Отображение форм на слайде как изображений
type: docs
weight: 120
url: /ru/net/rendering-shapes-on-slide-as-images/
---

Это охватывает две основные функции:

- Извлечение изображения из формы в файл.
- Извлечение форм как файла изображения.
## **Извлечение изображения из формы в файл**
Изображения добавляются на фон слайда и формы. Иногда необходимо извлечь изображения, добавленные в формы презентации.

В **Aspose.Slides для .NET** изображения могут быть добавлены в форму слайда и фон слайда. Изображения добавляются в **ImageCollectionEx** презентации. В этом примере мы пройдемся по каждой форме внутри каждого слайда презентации и посмотрим, есть ли какое-либо изображение, добавленное в форму слайда. Если для какой-либо формы будет найдено изображение, мы извлечем его и сохраним в файл. Следующий фрагмент кода служит этой цели.

``` csharp

 //Доступ к презентации

PresentationEx pres = new PresentationEx("RenderImageFromShape.pptx");

ImageEx img = null;

int slideIndex = 0;

String ImageType = "";

bool ifImageFound = false;

for (int i = 0; i < pres.Slides.Count; i++)

{

	slideIndex++;

	//Доступ к первому слайду

	SlideEx sl = pres.Slides[i];

	System.Drawing.Imaging.ImageFormat Format = System.Drawing.Imaging.ImageFormat.Jpeg;

	for (int j = 0; j < sl.Shapes.Count; j++)

	{

		// Доступ к форме с изображением

		ShapeEx sh = sl.Shapes[j];

		if (sh is AutoShapeEx)

		{

			AutoShapeEx ashp = (AutoShapeEx)sh;

			if (ashp.FillFormat.FillType == FillTypeEx.Picture)

			{

				img = ashp.FillFormat.PictureFillFormat.Picture.Image;

				ImageType = img.ContentType;

				ImageType = ImageType.Remove(0, ImageType.IndexOf("/") + 1);

				ifImageFound = true;

			}

		}

		else if (sh is PictureFrameEx)

		{

			PictureFrameEx pf = (PictureFrameEx)sh;

			if (pf.FillFormat.FillType == FillTypeEx.Picture)

			{

				img = pf.PictureFormat.Picture.Image;

				ImageType = img.ContentType;

				ImageType = ImageType.Remove(0, ImageType.IndexOf("/") + 1);

				ifImageFound = true;

			}

		}


		//

		//Устанавливаем желаемый формат изображения

		if (ifImageFound)

		{

			switch (ImageType)

			{

				case "jpeg":

					Format = System.Drawing.Imaging.ImageFormat.Jpeg;

					break;

				case "emf":

					Format = System.Drawing.Imaging.ImageFormat.Emf;

					break;

				case "bmp":

					Format = System.Drawing.Imaging.ImageFormat.Bmp;

					break;

				case "png":

					Format = System.Drawing.Imaging.ImageFormat.Png;

					break;

				case "wmf":

					Format = System.Drawing.Imaging.ImageFormat.Wmf;

					break;

				case "gif":

					Format = System.Drawing.Imaging.ImageFormat.Gif;

					break;

			}

			//

			img.Image.Save(path+"ResultedImage"+"." + ImageType, Format);

		}

		ifImageFound = false;

``` 
## **Скачать образец кода**
- [Codeplex](http://goo.gl/G3JI6p)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Rendering%20Shapes%20and%20Slide%20to%20Images%20%28Aspose.Slides%29.zip)
## **Извлечение форм как файла изображения**
``` csharp

 //Создание объекта Presentation, который представляет файл PPT

Presentation pres = new Presentation("RenderShapeAsImage.ppt");

//Доступ к слайду с использованием его позиции слайда

Slide slide = pres.GetSlideByPosition(2);


//Итерация по всем формам на слайде и создание миниатюр

ShapeCollection shapes = slide.Shapes;

for (int i = 0; i < shapes.Count; i++)

{

	Shape shape = shapes[i];

	//Получение миниатюрного изображения формы

	Image img = slide.GetThumbnail(new object[] { shape }, 1.0, 1.0, shape.ShapeRectangle);

	//Сохранение миниатюрного изображения в формате gif

	img.Save(i + ".gif", ImageFormat.Gif);

}

``` 

*Примечание:* Извлечение формы в настоящее время поддерживается в файле .ppt.
## **Скачать образец кода**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/812536)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Rendering%20Individual%20Shapes%20as%20Images%20%28Aspose.Slides%29.zip)