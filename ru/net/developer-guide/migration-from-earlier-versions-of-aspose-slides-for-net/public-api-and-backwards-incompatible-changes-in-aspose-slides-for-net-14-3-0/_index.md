---
title: Публичный API и несовместимые изменения в Aspose.Slides для .NET 14.3.0
linktitle: Aspose.Slides для .NET 14.3.0
type: docs
weight: 50
url: /ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-3-0/
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
description: "Обзор обновлений публичного API и нарушающих совместимость изменений в Aspose.Slides для .NET, позволяющий плавно мигрировать ваши решения для презентаций PowerPoint PPT, PPTX и ODP."
---

## **Публичный API и несовместимые изменения**
### **Добавлено перечисление Aspose.Slides.ShapeThumbnailBounds и методы Aspose.Slides.IShape.GetThumbnail()**
Методы GetThumbnail() и GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) используются для создания отдельной миниатюры фигуры. Перечисление ShapeThumbnailBounds определяет возможные типы границ миниатюры фигуры.
### **В свойство Aspose.Slides.IShape добавлен UniqueId**
Свойство Aspose.Slides.IShape.UniqueId получает уникальный идентификатор фигуры в пределах презентации. Эти уникальные идентификаторы хранятся в пользовательских тегах фигуры.
### **Изменена сигнатура метода SetGroupingItem в IChartCategoryLevelsManager**
Signature of the IChartCategoryLevelsManager method

``` csharp

 void SetGroupingItem(int level, IChartDataCell value);

``` 

is obsolete now and replaced with the signature

``` csharp

 void SetGroupingItem(int level, object value);

``` 

Now calls like

``` csharp

 .SetGroupingItem(1, workbook.GetCell(0, "A2", "Group 1"));

``` 

must be changed to calls like

``` csharp

 .SetGroupingItem(1, "Group 1");

``` 

Передавайте значение типа "Group 1" в SetGroupingItem, а не значение типа IChartDataCell. Создание IChartDataCell с указанием листа, строки и столбца для уровней категорий требует выполнения некоторых условий и инкапсулировано в методе SetGroupingItem(int, object).
### **В интерфейс Aspose.Slides.IBaseSlide добавлено свойство SlideId**
Свойство SlideId получает уникальный идентификатор слайда.
### **В ISlideShowTransition добавлено свойство SoundName**
Строка с возможностью чтения и записи. Указывает человекочитаемое имя звука перехода. Свойство Sound должно быть назначено для получения или установки имени звука. Это имя отображается в пользовательском интерфейсе PowerPoint при ручной настройке звука перехода. Может вызвать PptxException, если свойство Sound не назначено.
### **Изменён тип свойства ChartSeriesGroup.Type**
Свойство ChartSeriesGroup.Type изменено: оно теперь использует новое перечисление CombinableSeriesTypesGroup вместо перечисления ChartType. Перечисление CombinableSeriesTypesGroup представляет группы комбинируемых типов серий.
### **Добавлена поддержка генерации отдельных миниатюр фигур**
Aspose.Slides.ShapeThumbnailBounds

Новые члены в Aspose.Slides.IShape, Aspose.Slides.Shape:
public Bitmap GetThumbnail()
public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)