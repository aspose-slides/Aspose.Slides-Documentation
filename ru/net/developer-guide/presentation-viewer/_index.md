---
title: Просмотрщик презентаций
type: docs
weight: 50
url: /ru/net/presentation-viewer/
keywords: "Просмотр презентации PowerPoint, просмотр ppt, просмотр PPTX, C#, Csharp, Aspose.Slides для .NET"
description: "Просмотр презентации PowerPoint на C# или .NET"
---

Aspose.Slides для .NET используется для создания файлов презентаций, состоящих из слайдов. Эти слайды можно просмотреть, открыв презентации с помощью Microsoft PowerPoint. Но иногда разработчикам также нужно просматривать слайды как изображения в любимом просмотрщике изображений или создать свой собственный просмотрщик презентаций. В таких случаях Aspose.Slides для .NET позволяет экспортировать отдельный слайд в изображение. Эта статья описывает, как это сделать.
## **Прямой пример**
Вы можете попробовать бесплатное приложение [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/), чтобы увидеть, что вы можете реализовать с помощью API Aspose.Slides:

![powerpoint-in-aspose-viewer](powerpoint-in-aspose-viewer.png)

## **Генерация SVG изображения из слайда**
Чтобы сгенерировать SVG изображение из любого нужного слайда с помощью Aspose.Slides.PPTX для .NET, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Получите ссылку на нужный слайд, используя его ID или индекс.
- Получите SVG изображение в памяти.
- Сохраните память в файл.

```c#
// Создайте экземпляр класса Presentation, представляющего файл презентации

using (Presentation pres = new Presentation("CreateSlidesSVGImage.pptx"))
{

    // Получите доступ к первому слайду
    ISlide sld = pres.Slides[0];

    // Создайте объект памяти
    MemoryStream SvgStream = new MemoryStream();

    // Генерация SVG изображения слайда и сохранение в памяти
    sld.WriteAsSvg(SvgStream);
    SvgStream.Position = 0;

    // Сохраните поток памяти в файл
    using (Stream fileStream = System.IO.File.OpenWrite("Aspose_out.svg"))
    {
        byte[] buffer = new byte[8 * 1024];
        int len;
        while ((len = SvgStream.Read(buffer, 0, buffer.Length)) > 0)
        {
            fileStream.Write(buffer, 0, len);
        }

    }
    SvgStream.Close();
}
```

## **Генерация SVG с пользовательскими идентификаторами форм**
Aspose.Slides для .NET может использоваться для генерации [SVG ](https://docs.fileformat.com/page-description-language/svg/)из слайда с пользовательским идентификатором формы. Для этого используйте свойство ID из [ISvgShape](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape), которое представляет пользовательский идентификатор форм в сгенерированном SVG. Можно использовать CustomSvgShapeFormattingController для установки идентификатора формы.

```c#
using (Presentation pres = new Presentation("pptxFileName.pptx"))
{
    using (FileStream stream = new FileStream(outputPath, FileMode.OpenOrCreate))
    {
        SVGOptions svgOptions = new SVGOptions
        {
            ShapeFormattingController = new CustomSvgShapeFormattingController()
        };

        pres.Slides[0].WriteAsSvg(stream, svgOptions);
    }
}
```

```c#
class CustomSvgShapeFormattingController : ISvgShapeFormattingController
{
	private int m_shapeIndex;
	
	public CustomSvgShapeFormattingController(int shapeStartIndex = 0)
	{
		m_shapeIndex = shapeStartIndex;
	}

	public void FormatShape(ISvgShape svgShape, IShape shape)
	{
		svgShape.Id = string.Format("shape-{0}", m_shapeIndex++);
	}
}
```

## **Создание эскиза слайда**
Aspose.Slides для .NET помогает вам генерировать эскизы изображений слайдов. Чтобы создать эскиз любого нужного слайда, используя Aspose.Slides для .NET:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Получите ссылку на любой нужный слайд, используя его ID или индекс.
3. Получите изображение эскиза соответствующего слайда на указанном масштабе.
4. Сохраните изображение эскиза в любом нужном формате.

```c#
// Создайте экземпляр класса Presentation, представляющего файл презентации
using (Presentation pres = new Presentation("ThumbnailFromSlide.pptx"))
{

    // Получите доступ к первому слайду
    ISlide sld = pres.Slides[0];

    // Создайте изображение полного масштаба
    Bitmap bmp = sld.GetThumbnail(1f, 1f);

    // Сохраните изображение на диск в формате JPEG
    bmp.Save("Thumbnail_out.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

}
```

## **Создание миниатюры с заданными пользователем размерами**
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Получите ссылку на любой нужный слайд, используя его ID или индекс.
3. Получите изображение эскиза соответствующего слайда на указанном масштабе.
4. Сохраните изображение эскиза в любом нужном формате.

```c#
// Создайте экземпляр класса Presentation, представляющего файл презентации
using (Presentation pres = new Presentation("ThumbnailWithUserDefinedDimensions.pptx"))
{

    // Получите доступ к первому слайду
    ISlide sld = pres.Slides[0];

    // Пользовательские размеры
    int desiredX = 1200;
    int desiredY = 800;

    // Получение масштабированных значений X и Y
    float ScaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float ScaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

    // Создайте изображение полного масштаба
    Bitmap bmp = sld.GetThumbnail(ScaleX, ScaleY);

    // Сохраните изображение на диск в формате JPEG
    bmp.Save("Thumbnail2_out.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
}
```

## **Создание миниатюры из слайда в режиме заметок**
Чтобы создать эскиз любого нужного слайда в режиме заметок с использованием Aspose.Slides для .NET:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Получите ссылку на любой нужный слайд, используя его ID или индекс.
3. Получите изображение эскиза соответствующего слайда на указанном масштабе в режиме заметок.
4. Сохраните изображение эскиза в любом нужном формате.

Приведенный ниже фрагмент кода генерирует миниатюру первого слайда презентации в режиме заметок.

```c#
// Создайте экземпляр класса Presentation, представляющего файл презентации
using (Presentation pres = new Presentation("ThumbnailFromSlideInNotes.pptx"))
{
    // Получите доступ к первому слайду
    ISlide sld = pres.Slides[0];

    // Пользовательские размеры
    int desiredX = 1200;
    int desiredY = 800;

    // Получение масштабированных значений X и Y
    float ScaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float ScaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

    // Создайте изображение полного масштаба                
    Bitmap bmp = sld.GetThumbnail(ScaleX, ScaleY);
    // Сохраните изображение на диск в формате JPEG
    bmp.Save("Notes_tnail_out.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
}
```