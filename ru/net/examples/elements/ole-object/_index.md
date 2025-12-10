---
title: OLE-объект
type: docs
weight: 210
url: /ru/net/examples/elements/ole-object/
keywords:
- Пример OLE-объекта
- добавить OLE-объект
- доступ к OLE-объекту
- удалить OLE-объект
- обновить OLE-объект
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Работайте с OLE-объектами в C# с использованием Aspose.Slides: вставляйте или обновляйте встроенные файлы, задавайте значки или ссылки, извлекайте содержимое, управляйте поведением для PPT, PPTX и ODP."
---

Продемонстрировано встраивание файла в виде OLE‑объекта и обновление его данных с использованием **Aspose.Slides for .NET**.

## **Добавить OLE‑объект**

Вставьте PDF‑файл в презентацию.
```csharp
static void Add_Ole_Object()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    var pdfData = new OleEmbeddedDataInfo(File.ReadAllBytes("doc.pdf"), "pdf");
    var ole = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, pdfData);
}
```


## **Получить OLE‑объект**

Получите первый кадр OLE‑объекта на слайде.
```csharp
static void Access_Ole_Object()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var pdfData = new OleEmbeddedDataInfo(File.ReadAllBytes("doc.pdf"), "pdf");
    var ole = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, pdfData);

    var firstOle = slide.Shapes.OfType<IOleObjectFrame>().First();
}
```


## **Удалить OLE‑объект**

Удалите встроенный OLE‑объект со слайда.
```csharp
static void Remove_Ole_Object()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var pdfData = new OleEmbeddedDataInfo(File.ReadAllBytes("doc.pdf"), "pdf");
    var ole = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, pdfData);

    slide.Shapes.Remove(ole);
}
```


## **Обновить данные OLE‑объекта**

Замените данные, встроенные в существующий OLE‑объект.
```csharp
static void Update_Ole_Object_Data()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var pdfData = new OleEmbeddedDataInfo(File.ReadAllBytes("doc.pdf"), "pdf");
    var ole = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, pdfData);

    var newData = new OleEmbeddedDataInfo(File.ReadAllBytes("Picture.png"), "png");
    ole.SetEmbeddedData(newData);
}
```
