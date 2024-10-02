---
title: Генерация миниатюры слайда в формате JPEG
type: docs
weight: 90
url: /ru/net/generate-slide-thumbnail-as-jpeg/
---

Чтобы сгенерировать миниатюру любого желаемого слайда с помощью Aspose.Slides для .NET:

- Создайте экземпляр класса Presentation.
- Получите ссылку на любой желаемый слайд, используя его ID или индекс.
- Получите изображение миниатюры указанного слайда в заданном масштабе.
- Сохраните изображение миниатюры в любом желаемом формате изображения.
## **Пример**
``` 

 //Создайте экземпляр класса Presentation, представляющий файл презентации

using (Presentation pres = new Presentation("Slides Test Presentation.pptx"))

{

  //Получите доступ к первому слайду

  ISlide sld = pres.Slides[0];

  //Создайте изображение в полном масштабе

  Bitmap bmp = sld.GetThumbnail(1f, 1f);

  //Сохраните изображение на диск в формате JPEG

  bmp.Save("Test Thumbnail.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

``` 
## **Скачать работающий пример**
- [CodePlex](https://asposeslidesvsto.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in VSTO/Slide Thumbnail to JPEG/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Slide%20Thumbnail%20to%20JPEG)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d/view/SourceCode)
## **Скачать пример кода**
- [CodePlex](https://asposeslidesvsto.codeplex.com/releases/view/620001)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d#content)

{{% alert color="primary" %}} 

Для получения дополнительной информации посетите [Создание изображения миниатюры слайдов](/slides/ru/net/presentation-viewer/#presentationviewer-creatingslidesthumbnailimage).

{{% /alert %}}