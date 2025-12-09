---
title: Публичный API и несовместимые изменения в Aspose.Slides для .NET 14.9.0
linktitle: Aspose.Slides для .NET 14.9.0
type: docs
weight: 110
url: /ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/
keywords:
- миграция
- унаследованный код
- современный код
- унаследованный подход
- современный подход
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Обзор обновлений публичного API и разрушающих изменений в Aspose.Slides для .NET, чтобы плавно мигрировать ваши решения презентаций PowerPoint PPT, PPTX и ODP."
---

{{% alert color="primary" %}} 

На этой странице перечислены все [добавленные](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) или [удалённые](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) классы, методы, свойства и т.д., а также другие изменения, введённые в API Aspose.Slides для .NET 14.9.0.

{{% /alert %}} 
## **Изменения публичного API**
#### **Наследование от интерфейсов ICollection и Generic IEnumerable добавлено в ISmartArtNodeCollection**
Класс Aspose.Slides.SmartArt.SmartArtNodeCollection (и связанный интерфейс Aspose.Slides.SmartArt.ISmartArtNodeCollection) наследует обобщённый интерфейс IEnumerable<ISmartArtNode> и интерфейс ICollection.
#### **Добавлено значение перечисления SmartArtLayoutType.Custom**
Тип пользовательского макета SmartArt представляет диаграмму с пользовательским шаблоном. Пользовательские диаграммы можно загрузить только из файла презентации и нельзя создать с помощью метода ShapeCollection.AddSmartArt(x, y, width, height, SmartArtLayoutType.Custom).
#### **Добавлены класс SmartArtShape и интерфейс ISmartArtShape**
Класс Aspose.Slides.SmartArt.SmartArtShape (и его интерфейс Aspose.Slides.SmartArt.ISmartArtShape) предоставляет доступ к отдельным фигурам в диаграмме SmartArt. SmartArtShape можно использовать для изменения FillFormat, LineFormat, добавления гиперссылок и других задач.

{{% alert color="primary" %}} 

**Note**: SmartArtShape не поддерживает свойства IShape RawFrame, Frame, Rotation, X, Y, Width, Height и бросает System.NotSupportedException при попытке доступа к ним.

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
#### **Добавлены класс SmartArtShapeCollection, интерфейс ISmartArtShapeCollection и свойство ISmartArtNode.Shapes**
Класс Aspose.Slides.SmartArt.SmartArtShapeCollection (и его интерфейс Aspose.Slides.SmartArt.ISmartArtShapeCollection) предоставляет доступ к отдельным фигурам в диаграмме SmartArt. Коллекция содержит фигуры, связанные с SmartArtNode. Свойство SmartArtNode.Shapes возвращает коллекцию всех фигур, связанных с узлом.

{{% alert color="primary" %}} 

**Note**: в зависимости от SmartArtLayoutType одна SmartArtShape может быть общей для нескольких узлов.

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
#### **Добавлены методы сохранения с указанием номеров слайдов**
Были добавлены следующие методы:

- void IPresentation.Save(string fname, int[] slides, SaveFormat format);
- void IPresentation.Save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

Эти методы позволяют разработчикам сохранять указанные слайды презентации в форматы PDF, XPS, TIFF, HTML. Массив 'slides' используется для указания номеров страниц, начиная с 1.
Save(string fname, int[] slides, SaveFormat format);

``` csharp

 Presentation presentation = new Presentation(presentationFileName);

int[] slides = new int[] { 2, 3, 5 }; //Массив позиций слайдов

presentation.Save(outFileName, slides, SaveFormat.Pdf);

``` 
#### **Добавлены методы замены изображений в PPImage, IPPImage**
Добавлены новые методы:

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