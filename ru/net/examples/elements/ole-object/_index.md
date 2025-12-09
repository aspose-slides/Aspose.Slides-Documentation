---
title: OLE-объект
type: docs
weight: 210
url: /ru/net/examples/elements/ole-object/
keywords:
- Пример OLE-объекта
- добавление OLE-объекта
- доступ к OLE-объекту
- удаление OLE-объекта
- обновление OLE-объекта
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Работа с OLE-объектами в C# с использованием Aspose.Slides: вставка или обновление встроенных файлов, установка значков или ссылок, извлечение содержимого, управление поведением для PPT, PPTX и ODP."
---

Продемонстрировано встраивание файла как OLE-объекта и обновление его данных с помощью **Aspose.Slides for .NET**.

## Добавление OLE-объекта

Вставьте PDF-файл в презентацию.
```csharp
static void Add_Ole_Object()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    var pdfData = new OleEmbeddedDataInfo(File.ReadAllBytes("doc.pdf"), "pdf");
    var ole = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, pdfData);
}
```


## Доступ к OLE-объекту

Получите первый кадр OLE-объекта на слайде.
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


## Удаление OLE-объекта

Удалите встраиваемый OLE-объект со слайда.
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


## Обновление данных OLE-объекта

Замените данные, встроенные в существующий OLE-объект.
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
