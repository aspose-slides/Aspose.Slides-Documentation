---
title: Публичный API и несовместимые изменения в Aspose.Slides для .NET 14.3.0
linktitle: Aspose.Slides для .NET 14.3.0
type: docs
weight: 50
url: /ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-3-0/
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
description: "Обзор обновлений публичного API и разрушающих изменений в Aspose.Slides для .NET, позволяющих плавно мигрировать ваши решения для презентаций PowerPoint PPT, PPTX и ODP."
---

## **Public API and Backwards Incompatible Changes**
### **Aspose.Slides.ShapeThumbnailBounds Enumeration and Aspose.Slides.IShape.GetThumbnail() Methods Added**
Методы GetThumbnail() и GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) используются для создания отдельной миниатюры фигуры. Перечисление ShapeThumbnailBounds определяет возможные типы границ миниатюры фигуры.
### **Property UniqueId has been added to Aspose.Slides.IShape**
Свойство Aspose.Slides.IShape.UniqueId возвращает уникальный в рамках презентации идентификатор фигуры. Эти уникальные идентификаторы хранятся в пользовательских тегах фигуры.
### **Signature of the SetGroupingItem Method Changed in IChartCategoryLevelsManager**
Signature of the IChartCategoryLevelsManager method

``` csharp

 void SetGroupingItem(int level, IChartDataCell value);

``` 

устарела и заменена сигнатурой

``` csharp

 void SetGroupingItem(int level, object value);

``` 

Теперь вызовы вида

``` csharp

 .SetGroupingItem(1, workbook.GetCell(0, "A2", "Group 1"));

``` 

должны быть заменены вызовами вида

``` csharp

 .SetGroupingItem(1, "Group 1");

``` 

Передайте значение вроде "Group 1" в SetGroupingItem, а не значение типа IChartDataCell. Создание IChartDataCell с указанием листа, строки и столбца для уровней категорий требует соблюдения некоторых требований и было инкапсулировано в методе SetGroupingItem(int, object).
### **SlideId Property Added to the Aspose.Slides.IBaseSlide Interface**
Свойство SlideId возвращает уникальный идентификатор слайда.
### **SoundName Property Added to ISlideShowTransition**
Читаемая и записываемая строка. Указывает человекочитаемое название звука перехода. Свойство Sound должно быть присвоено для получения или установки названия звука. Это название отображается в пользовательском интерфейсе PowerPoint при ручной настройке звука перехода. Может вызвать PptxException, если свойство Sound не присвоено.
### **Type of ChartSeriesGroup.Type Property Changed**
Свойство ChartSeriesGroup.Type было изменено: вместо перечисления ChartType теперь используется новое перечисление CombinableSeriesTypesGroup. Перечисление CombinableSeriesTypesGroup представляет группы комбинируемых типов серий.
### **Support for Generating Individual Shape Thumbnails Added**
Aspose.Slides.ShapeThumbnailBounds

Новые члены в Aspose.Slides.IShape, Aspose.Slides.Shape:
public Bitmap GetThumbnail()
public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)