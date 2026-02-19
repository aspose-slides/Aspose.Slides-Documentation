---
title: OLE-объект
type: docs
weight: 210
url: /ru/net/examples/elements/ole-object/
keywords:
- OLE-объект
- добавить OLE-объект
- доступ к OLE-объекту
- удалить OLE-объект
- обновить OLE-объект
- пример кода
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Работайте с OLE-объектами в Aspose.Slides for .NET: вставляйте, связывайте, обновляйте и извлекайте встроенное содержимое с помощью C# в презентациях PPT, PPTX и ODP."
---
В этой статье демонстрируется встраивание файла в виде OLE-объекта и обновление его данных с помощью **Aspose.Slides for .NET**.

## **Добавить OLE-объект**

Встроить PDF-файл в презентацию.

```csharp
static void AddOleObject()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var pdfData = File.ReadAllBytes("doc.pdf");
    var dataInfo = new OleEmbeddedDataInfo(pdfData, "pdf");
    var oleFrame = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, dataInfo);
}
```

## **Доступ к OLE-объекту**

Получить первый кадр OLE-объекта на слайде.

```csharp
static void AccessOleObject()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var pdfData = File.ReadAllBytes("doc.pdf");
    var dataInfo = new OleEmbeddedDataInfo(pdfData, "pdf");
    var oleFrame = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, dataInfo);

    var firstOleFrame = slide.Shapes.OfType<IOleObjectFrame>().First();
}
```

## **Удалить OLE-объект**

Удалить встроенный OLE-объект со слайда.

```csharp
static void RemoveOleObject()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var pdfData = File.ReadAllBytes("doc.pdf");
    var dataInfo = new OleEmbeddedDataInfo(pdfData, "pdf");
    var oleFrame = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, dataInfo);

    slide.Shapes.Remove(oleFrame);
}
```

## **Обновить данные OLE-объекта**

Заменить данные, встроенные в существующий OLE-объект.

```csharp
static void UpdateOleObjectData()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var pdfData = File.ReadAllBytes("doc.pdf");
    var dataInfo = new OleEmbeddedDataInfo(pdfData, "pdf");
    var oleFrame = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, dataInfo);

    var newData = File.ReadAllBytes("Picture.png");
    var newDataInfo = new OleEmbeddedDataInfo(newData, "png");
    oleFrame.SetEmbeddedData(newDataInfo);
}
```