---
title: Создание слайда в формате SVG
type: docs
weight: 70
url: /ru/net/create-slide-as-svg-image/
---

Чтобы сгенерировать SVG-изображение из любого нужного слайда с использованием Aspose.Slides.Pptx для .NET, выполните следующие шаги:

- Создайте экземпляр класса Presentation.
- Получите ссылку на нужный слайд, используя его ID или индекс.
- Получите SVG-изображение в потоке памяти.
- Сохраните поток памяти в файл.
## **Пример**

```

 //Создайте экземпляр класса Presentation, который представляет файл презентации

using (Presentation pres = new Presentation("Slides Test Presentation.pptx"))

{

   //Получите доступ ко второму слайду

   ISlide sld = pres.Slides[1];

   //Создайте объект потока памяти

   MemoryStream SvgStream = new MemoryStream();

   //Сгенерируйте SVG-изображение слайда и сохраните в поток памяти

   sld.WriteAsSvg(SvgStream);

   SvgStream.Position = 0;

   //Сохраните поток памяти в файл

   using (Stream fileStream = System.IO.File.OpenWrite("PresentatoinTemplate.svg"))

   {

     byte[] buffer = new byte[8 * 1024];

     int len;

     while ((len = SvgStream.Read(buffer, 0, buffer.Length)) > 0)

     {

       fileStream.Write(buffer, 0, len);

     }

}

SvgStream.Close();

``` 
## **Скачать работающий пример**
- [CodePlex](https://asposeslidesvsto.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in VSTO/Creating Slide SVG Image/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Creating%20Slide%20SVG%20Image)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d/view/SourceCode)
## **Скачать пример кода**
- [CodePlex](https://asposeslidesvsto.codeplex.com/releases/view/620001)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d#content)

{{% alert color="primary" %}} 

Для получения дополнительной информации посетите [Создание SVG-изображения слайда](/slides/ru/net/presentation-viewer/).

{{% /alert %}}