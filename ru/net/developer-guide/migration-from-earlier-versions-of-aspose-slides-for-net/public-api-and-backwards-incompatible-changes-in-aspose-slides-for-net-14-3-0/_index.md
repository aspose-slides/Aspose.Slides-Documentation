---
title: Общий API и несовместимые изменения в Aspose.Slides for .NET 14.3.0
linktitle: Aspose.Slides для .NET 14.3.0
type: docs
weight: 50
url: /ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-3-0/
keywords:
- миграция
- наследуемый код
- современный код
- унаследованный подход
- современный подход
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Обзор обновлений публичного API и несовместимых изменений в Aspose.Slides for .NET для плавной миграции ваших решений по работе с презентациями PowerPoint PPT, PPTX и ODP."
---

## **Публичный API и несовместимые изменения**
### **Добавлены перечисление Aspose.Slides.ShapeThumbnailBounds и методы Aspose.Slides.IShape.GetThumbnail()**
Методы GetThumbnail() и GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) используются для создания отдельного миниатюрного изображения фигуры. Перечисление ShapeThumbnailBounds определяет возможные типы границ миниатюры фигуры.
### **Свойство UniqueId добавлено в Aspose.Slides.IShape**
Свойство Aspose.Slides.IShape.UniqueId возвращает уникальный идентификатор фигуры в пределах презентации. Эти уникальные идентификаторы хранятся в пользовательских тегах фигуры.
### **Изменена сигнатура метода SetGroupingItem в IChartCategoryLevelsManager**
Сигнатура метода IChartCategoryLevelsManager

``` csharp

 void SetGroupingItem(int level, IChartDataCell value);

``` 

на данный момент устарела и заменена сигнатурой

``` csharp

 void SetGroupingItem(int level, object value);

``` 

Теперь вызовы вроде

``` csharp

 .SetGroupingItem(1, workbook.GetCell(0, "A2", "Group 1"));

``` 

должны быть заменены на вызовы вида

``` csharp

 .SetGroupingItem(1, "Group 1");

``` 

Передайте значение вроде "Group 1" в SetGroupingItem, а не значение типа IChartDataCell. Создание IChartDataCell с указанным листом, строкой и столбцом для уровней категорий должно удовлетворять определённым требованиям и было инкапсулировано в методе SetGroupingItem(int, object).
### **Свойство SlideId добавлено в интерфейс Aspose.Slides.IBaseSlide**
Свойство SlideId возвращает уникальный идентификатор слайда.
### **Свойство SoundName добавлено в ISlideShowTransition**
Строка с чтением и записью. Задает человекочитаемое название звука перехода. Свойство Sound должно быть присвоено для получения или установки имени звука. Это имя отображается в пользовательском интерфейсе PowerPoint при ручной настройке звука перехода. Может вызывать PptxException, если свойство Sound не присвоено.
### **Изменён тип свойства ChartSeriesGroup.Type**
Свойство ChartSeriesGroup.Type изменено с перечисления ChartType на новое перечисление CombinableSeriesTypesGroup. Перечисление CombinableSeriesTypesGroup представляет группы комбинируемых типов рядов.
### **Добавлена поддержка генерации отдельных миниатюр фигур**
Aspose.Slides.ShapeThumbnailBounds

Новые члены в Aspose.Slides.IShape, Aspose.Slides.Shape:
public Bitmap GetThumbnail()
public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)