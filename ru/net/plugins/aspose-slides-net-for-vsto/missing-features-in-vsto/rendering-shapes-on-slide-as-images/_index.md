---
title: Рендеринг фигур на слайде в виде изображений
type: docs
weight: 120
url: /ru/net/rendering-shapes-on-slide-as-images/
---

Это охватывает две основные функции:

- Извлечение изображения из фигуры в файл.
- Извлечение фигур в виде файлов изображений.
## **Извлечение изображения из фигуры в файл**
Изображения добавляются в фон слайда и в фигуры. Иногда требуется извлечь изображения, добавленные в фигуры презентации.

В **Aspose.Slides for .NET** изображения могут быть добавлены в форму слайда и в фон слайда. Изображения находятся в **ImageCollectionEx** презентации. В этом примере мы пройдемся по каждой форме внутри каждого слайда презентации и проверим, есть ли изображение, добавленное в форму слайда. Если изображение будет найдено для любой формы, мы извлечём его и сохраним в файл. Следующий фрагмент кода выполнит эту задачу.
``` csharp

 //Получение доступа к презентации
PresentationEx pres = new PresentationEx("RenderImageFromShape.pptx");

ImageEx img = null;

int slideIndex = 0;

String ImageType = "";

bool ifImageFound = false;

for (int i = 0; i < pres.Slides.Count; i++)

{

	slideIndex++;

	//Получение доступа к первому слайду
	SlideEx sl = pres.Slides[i];
	System.Drawing.Imaging.ImageFormat Format = System.Drawing.Imaging.ImageFormat.Jpeg;

	for (int j = 0; j < sl.Shapes.Count; j++)

	{

		// Доступ к фигуре с изображением
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

		//Установка требуемого формата изображения
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
## **Download Sample Code**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Rendering%20Shapes%20and%20Slide%20to%20Images%20%28Aspose.Slides%29.zip)
## **Extract Shapes as Image Files**
```cs
//Создание объекта Presentation, представляющего файл PPT
Presentation pres = new Presentation("RenderShapeAsImage.ppt");

//Получение доступа к слайду по его позиции
ISlide slide = pres.Slides[2];

for (int i = 0; i < slide.Shapes.Count; i++)
{
    IShape shape = slide.Shapes[i];

    //Получение миниатюры изображения фигуры
    using (IImage image = shape.GetImage(ShapeThumbnailBounds.Shape, 1.0f, 1.0f))
    {
        //Сохранение миниатюры изображения в формате GIF
        image.Save(i + ".gif", ImageFormat.Gif);
    }
}
```


*Примечание:*Извлечение формы в настоящее время поддерживается в файлах .ppt.
## **Скачать пример кода**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Rendering%20Individual%20Shapes%20as%20Images%20%28Aspose.Slides%29.zip)