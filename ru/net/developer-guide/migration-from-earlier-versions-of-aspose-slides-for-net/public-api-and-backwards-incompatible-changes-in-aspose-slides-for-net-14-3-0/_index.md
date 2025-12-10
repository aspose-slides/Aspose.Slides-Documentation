---
title: "Общедоступный API и несовместимые изменения в Aspose.Slides для .NET 14.3.0"
linktitle: "Aspose.Slides для .NET 14.3.0"
type: docs
weight: 50
url: /ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-3-0/
keywords:
- миграция
- унаследованный код
- современный код
- устаревший подход
- современный подход
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Обзор обновлений публичного API и разрушающих изменений в Aspose.Slides для .NET, позволяющих плавно мигрировать решения презентаций PowerPoint PPT, PPTX и ODP."
---

## **Публичный API и несовместимые изменения**
### **Добавлены перечисление Aspose.Slides.ShapeThumbnailBounds и методы Aspose.Slides.IShape.GetThumbnail()**
Методы GetThumbnail() и GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) используются для создания отдельной миниатюры формы. Перечисление ShapeThumbnailBounds определяет возможные типы ограничений миниатюры формы.
### **Свойство UniqueId добавлено в Aspose.Slides.IShape**
Свойство Aspose.Slides.IShape.UniqueId возвращает уникальный идентификатор формы в пределах презентации. Эти уникальные идентификаторы хранятся в пользовательских тегах формы.
### **Подпись метода SetGroupingItem изменена в IChartCategoryLevelsManager**
Подпись метода IChartCategoryLevelsManager

```csharp
void SetGroupingItem(int level, IChartDataCell value);
```

теперь устарела и заменена подписью

```csharp
void SetGroupingItem(int level, object value);
```

Теперь вызовы вида

```csharp
.SetGroupingItem(1, workbook.GetCell(0, "A2", "Group 1"));
```

должны быть изменены на вызовы вида

```csharp
.SetGroupingItem(1, "Group 1");
```

Передавайте значение типа `"Group 1"` в SetGroupingItem, а не значение типа IChartDataCell. Создание IChartDataCell с определённым листом, строкой и столбцом для уровней категорий требует выполнения ряда условий и было инкапсулировано в методе SetGroupingItem(int, object).
### **Свойство SlideId добавлено в интерфейс Aspose.Slides.IBaseSlide**
Свойство SlideId возвращает уникальный идентификатор слайда.
### **Свойство SoundName добавлено в ISlideShowTransition**
Строка с возможностью чтения и записи. Указывает человекочитаемое имя для звука перехода. Свойство Sound должно быть назначено для получения или установки имени звука. Это имя отображается в пользовательском интерфейсе PowerPoint при ручной настройке звука перехода. Может вызвать PptxException, если свойство Sound не назначено.
### **Тип свойства ChartSeriesGroup.Type изменён**
Свойство ChartSeriesGroup.Type изменилось с перечисления ChartType на новое перечисление CombinableSeriesTypesGroup. Перечисление CombinableSeriesTypesGroup представляет группы комбинируемых типов рядов.
### **Добавлена поддержка создания отдельных миниатюр форм**
Aspose.Slides.ShapeThumbnailBounds

Новые члены в Aspose.Slides.IShape, Aspose.Slides.Shape:
public Bitmap GetThumbnail()
public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)