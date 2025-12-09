---
title: Публичный API и несовместимые изменения в Aspose.Slides for .NET 14.9.0
linktitle: Aspose.Slides for .NET 14.9.0
type: docs
weight: 110
url: /ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/
keywords:
- миграция
- наследуемый код
- современный код
- устаревший подход
- современный подход
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Обзор обновлений публичного API и несовместимых изменений в Aspose.Slides for .NET для плавной миграции ваших решений PowerPoint PPT, PPTX и ODP презентаций."
---

{{% alert color="primary" %}} 
Эта страница перечисляет все [добавленные](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) или [удалённые](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) классы, методы, свойства и т.п., а также другие изменения, внесённые в API Aspose.Slides for .NET 14.9.0.
{{% /alert %}} 
## **Изменения публичного API**
#### **Наследование от интерфейсов ICollection и обобщённого IEnumerable добавлено в ISmartArtNodeCollection**
#### **Значение перечисления SmartArtLayoutType.Custom добавлено**
#### **Класс SmartArtShape и интерфейс ISmartArtShape добавлены**
Класс Aspose.Slides.SmartArt.SmartArtShape (и его интерфейс Aspose.Slides.SmartArt.ISmartArtShape) предоставляет доступ к отдельным фигурам в диаграмме SmartArt. SmartArtShape можно использовать для изменения FillFormat, LineFormat, добавления гиперссылок и других задач.

{{% alert color="primary" %}} 
**Примечание**: SmartArtShape не поддерживает свойства IShape RawFrame, Frame, Rotation, X, Y, Width, Height и генерирует System.NotSupportedException при попытке доступа к ним.

Example of usage:

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  ISmartArtNode node = smart.AllNodes[0];

  foreach (SmartArtShape shape in node.Shapes)

  {

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.Color = Color.Red;

  }

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 

{{% /alert %}} 
#### **Класс SmartArtShapeCollection, интерфейс ISmartArtShapeCollection и свойство ISmartArtNode.Shapes добавлены**
Класс Aspose.Slides.SmartArt.SmartArtShapeCollection (и его интерфейс Aspose.Slides.SmartArt.ISmartArtShapeCollection) предоставляет доступ к отдельным фигурам в диаграмме SmartArt. Коллекция содержит фигуры, связанные с SmartArtNode. Свойство SmartArtNode.Shapes возвращает коллекцию всех фигур, связанных с узлом.

{{% alert color="primary" %}} 
**Примечание**: в зависимости от SmartArtLayoutType один SmartArtShape может быть общим для нескольких узлов.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  ISmartArtNode node = smart.AllNodes[0];

  foreach (SmartArtShape shape in node.Shapes)

  {

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.Color = Color.Red;

  }

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 

{{% /alert %}} 
#### **Добавлены методы сохранения слайдов с указанием номеров страниц**
The following methods have been added:

- void IPresentation.Save(string fname, int[] slides, SaveFormat format);
- void IPresentation.Save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

These methods allow developers to save specified presentation slides to PDF, XPS, TIFF, HTML formats. The 'slides' array is used to specify page numbers, starting from 1.
Save(string fname, int[] slides, SaveFormat format);

``` csharp

 Presentation presentation = new Presentation(presentationFileName);

int[] slides = new int[] { 2, 3, 5 }; //Array of slides positions

presentation.Save(outFileName, slides, SaveFormat.Pdf);

``` 
#### **Методы замены изображений, добавленные в PPImage, IPPImage**
New methods added:

- IPPImage.ReplaceImage(byte[] newImageData)
- IPPImage.ReplaceImage(Image newImage)
- IPPImage.ReplaceImage(IPPImage newImage)

``` csharp

 Presentation presentation = new Presentation(presentation.pptx);

//First method

byte[] data = File.ReadAllBytes(image0.jpeg);

IPPImage oldImage = presentation.Images[0];

oldImage.ReplaceImage(data);

//Second method

Image newImage = Image.FromFile(image1.png);

oldImage = presentation.Images[1];

oldImage.ReplaceImage(newImage);

//Third method

oldImage = presentation.Images[2];

oldImage.ReplaceImage(presentation.Images[3]);

presentation.Save(presentation_out.pptx, SaveFormat.Pptx);

```