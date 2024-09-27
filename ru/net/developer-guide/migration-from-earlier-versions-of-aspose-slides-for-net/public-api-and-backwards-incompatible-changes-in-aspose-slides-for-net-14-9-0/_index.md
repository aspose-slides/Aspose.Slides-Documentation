---
title: Публичное API и несовместимые изменения в Aspose.Slides для .NET 14.9.0
type: docs
weight: 110
url: /ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/
---

{{% alert color="primary" %}} 

Эта страница перечисляет все [добавленные](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) или [удаленные](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) классы, методы, свойства и т.д., а также другие изменения, введенные в API Aspose.Slides для .NET 14.9.0.

{{% /alert %}} 
## **Изменения в публичном API**
#### **Добавлено наследование от интерфейсов ICollection и Generic IEnumerable в ISmartArtNodeCollection**
Класс Aspose.Slides.SmartArt.SmartArtNodeCollection (и связанный с ним интерфейс Aspose.Slides.SmartArt.ISmartArtNodeCollection) наследует общий интерфейс IEnumerable<ISmartArtNode> и интерфейс ICollection.
#### **Добавлено значение перечисления SmartArtLayoutType.Custom**
Тип макета SmartArt Custom представляет диаграмму с пользовательским шаблоном. Пользовательские диаграммы могут быть загружены только из файла презентации и не могут быть созданы с помощью метода ShapeCollection.AddSmartArt(x, y, width, height, SmartArtLayoutType.Custom).
#### **Добавлен класс SmartArtShape и интерфейс ISmartArtShape**
Класс Aspose.Slides.SmartArt.SmartArtShape (и его интерфейс Aspose.Slides.SmartArt.ISmartArtShape) предоставляют доступ к отдельным формам в диаграмме SmartArt. SmartArtShape можно использовать для изменения FillFormat, LineFormat, добавления гиперссылок и других задач.

{{% alert color="primary" %}} 

**Примечание**: SmartArtShape не поддерживает свойства IShape RawFrame, Frame, Rotation, X, Y, Width, Height и вызывает System.NotSupportedException при попытке к ним получить доступ.

Пример использования:

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
Класс Aspose.Slides.SmartArt.SmartArtShapeCollection (и его интерфейс Aspose.Slides.SmartArt.ISmartArtShapeCollection) предоставляют доступ к отдельным формам в диаграмме SmartArt. Коллекция содержит формы, связанные с SmartArtNode. Свойство SmartArtNode.Shapes возвращает коллекции всех форм, связанных с узлом.

{{% alert color="primary" %}} 

**Примечание**: в зависимости от SmartArtLayoutType одна SmartArtShape может быть общей между несколькими узлами.

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
#### **Добавлены методы для сохранения слайдов с сохранением номеров страниц**
Добавлены следующие методы:

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
#### **Добавлены методы для замены изображений в PPImage, IPPImage**
Добавлены новые методы:

- IPPImage.ReplaceImage(byte[] newImageData)
- IPPImage.ReplaceImage(Image newImage)
- IPPImage.ReplaceImage(IPPImage newImage)

``` csharp

 Presentation presentation = new Presentation(presentation.pptx);

//Первый метод

byte[] data = File.ReadAllBytes(image0.jpeg);

IPPImage oldImage = presentation.Images[0];

oldImage.ReplaceImage(data);

//Второй метод

Image newImage = Image.FromFile(image1.png);

oldImage = presentation.Images[1];

oldImage.ReplaceImage(newImage);

//Третий метод

oldImage = presentation.Images[2];

oldImage.ReplaceImage(presentation.Images[3]);

presentation.Save(presentation_out.pptx, SaveFormat.Pptx);

``` 