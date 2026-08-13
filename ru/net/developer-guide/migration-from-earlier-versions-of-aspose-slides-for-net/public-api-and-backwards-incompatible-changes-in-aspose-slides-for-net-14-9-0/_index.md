---
title: Публичный API и несовместимые изменения в Aspose.Slides for .NET 14.9.0
linktitle: Aspose.Slides for .NET 14.9.0
type: docs
weight: 110
url: /ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/
keywords:
- миграция
- устаревший код
- современный код
- устаревший подход
- современный подход
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Обзор обновлений публичного API и несовместимых изменений в Aspose.Slides for .NET для плавной миграции ваших решений презентаций PowerPoint PPT, PPTX и ODP."
---
{{% alert color="info" %}} 

Эта страница перечисляет все [добавленные](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) или [удалённые](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) классы, методы, свойства и т.д., а также другие изменения, введённые в Aspose.Slides for .NET 14.9.0 API.

{{% /alert %}} 
## **Изменения публичного API**
#### **Наследование от интерфейсов ICollection и Generic IEnumerable добавлено в ISmartArtNodeCollection**
Класс Aspose.Slides.SmartArt.SmartArtNodeCollection (и связанный интерфейс Aspose.Slides.SmartArt.ISmartArtNodeCollection) наследуют обобщённый интерфейс IEnumerable<ISmartArtNode> и интерфейс ICollection.
#### **Добавлено значение перечисления SmartArtLayoutType.Custom**
Тип пользовательского макета SmartArt представляет схему с пользовательским шаблоном. Пользовательские схемы можно загружать только из файла презентации и нельзя создавать с помощью метода ShapeCollection.AddSmartArt(x, y, width, height, SmartArtLayoutType.Custom).
#### **Добавлены класс SmartArtShape и интерфейс ISmartArtShape**
Класс Aspose.Slides.SmartArt.SmartArtShape (и его интерфейс Aspose.Slides.SmartArt.ISmartArtShape) предоставляют доступ к отдельным фигурам в диаграмме SmartArt. SmartArtShape можно использовать для изменения FillFormat, LineFormat, добавления гиперссылок и других задач.

{{% alert color="info" %}} 

**Note**: SmartArtShape не поддерживает свойства IShape RawFrame, Frame, Rotation, X, Y, Width, Height и бросает System.NotSupportedException при попытке доступа к ним.

Пример использования:

``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using (Presentation pres = new Presentation())
{
  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  ISmartArtNode node = smart.AllNodes[0];

  foreach (ISmartArtShape shape in node.Shapes)
  {
    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.Color = Color.Red;
  }

  pres.Save("out.pptx", SaveFormat.Pptx);
}
``` 

{{% /alert %}} 
#### **Добавлены класс SmartArtShapeCollection, интерфейс ISmartArtShapeCollection и свойство ISmartArtNode.Shapes**
Класс Aspose.Slides.SmartArt.SmartArtShapeCollection (и его интерфейс Aspose.Slides.SmartArt.ISmartArtShapeCollection) добавляют доступ к отдельным фигурам в диаграмме SmartArt. Коллекция содержит фигуры, связанные с SmartArtNode. Свойство SmartArtNode.Shapes возвращает коллекцию всех фигур, связанных с узлом.

{{% alert color="info" %}} 

**Note**: в зависимости от SmartArtLayoutType одна SmartArtShape может быть общей для нескольких узлов.

``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using (Presentation pres = new Presentation())
{
  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  ISmartArtNode node = smart.AllNodes[0];

  foreach (ISmartArtShape shape in node.Shapes)
  {
    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.Color = Color.Red;
  }

  pres.Save("out.pptx", SaveFormat.Pptx);
}
``` 

{{% /alert %}} 
#### **Добавлены методы сохранения слайдов с сохранением номеров страниц**
Были добавлены следующие методы:

- void IPresentation.Save(string fname, int[] slides, SaveFormat format);
- void IPresentation.Save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

Эти методы позволяют разработчикам сохранять указанные слайды презентации в форматы PDF, XPS, TIFF, HTML. Массив «slides» используется для указания номеров страниц, начиная с 1.
Save(string fname, int[] slides, SaveFormat format);

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("presentation.pptx"))
{
    int[] slides = new int[] { 2, 3, 5 }; //Массив позиций слайдов

    presentation.Save("output.pdf", slides, SaveFormat.Pdf);
}
``` 
#### **Добавлены методы замены изображений в PPImage, IPPImage**
Новые методы:

- IPPImage.ReplaceImage(byte[] newImageData)
- IPPImage.ReplaceImage(Image newImage)
- IPPImage.ReplaceImage(IPPImage newImage)

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("presentation.pptx"))
{
    //Первый метод

    byte[] data = File.ReadAllBytes("image0.jpeg");

    IPPImage oldImage = presentation.Images[0];

    oldImage.ReplaceImage(data);

    //Второй метод

    IImage newImage = Images.FromFile("image1.png");

    oldImage = presentation.Images[1];

    oldImage.ReplaceImage(newImage);

    //Третий метод

    oldImage = presentation.Images[2];

    oldImage.ReplaceImage(presentation.Images[3]);

    presentation.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```