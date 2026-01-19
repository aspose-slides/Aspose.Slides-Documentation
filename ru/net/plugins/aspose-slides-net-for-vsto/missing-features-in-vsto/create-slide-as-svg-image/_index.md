---
title: Создать слайд как SVG‑изображение
type: docs
weight: 70
url: /ru/net/create-slide-as-svg-image/
---

Чтобы создать SVG‑изображение из любого нужного слайда с помощью Aspose.Slides.Pptx for .NET, выполните следующие шаги:

- Создайте экземпляр класса Presentation.
- Получите ссылку на нужный слайд, используя его ID или индекс.
- Получите SVG‑изображение в поток памяти.
- Сохраните поток памяти в файл.
## **Пример**

```

 //Instantiate a Presentation class that represents the presentation file

using (Presentation pres = new Presentation("Slides Test Presentation.pptx"))

{

   //Access the second slide

   ISlide sld = pres.Slides[1];

   //Create a memory stream object

   MemoryStream SvgStream = new MemoryStream();

   //Generate SVG image of slide and save in memory stream

   sld.WriteAsSvg(SvgStream);

   SvgStream.Position = 0;

   //Save memory stream to file

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
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Creating%20Slide%20SVG%20Image)
## **Скачать пример кода**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 
Для получения более подробной информации перейдите по ссылке [Отобразить слайды презентации как SVG‑изображения в .NET](/slides/ru/net/render-a-slide-as-an-svg-image/).
{{% /alert %}}