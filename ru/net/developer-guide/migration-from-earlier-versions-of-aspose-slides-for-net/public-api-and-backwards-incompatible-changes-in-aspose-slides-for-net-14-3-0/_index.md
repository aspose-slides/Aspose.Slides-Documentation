---
title: Публичный API и несовместимые изменения в Aspose.Slides для .NET 14.3.0
type: docs
weight: 50
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-3-0/
---

## **Публичный API и несовместимые изменения**
### **Добавлены перечисление Aspose.Slides.ShapeThumbnailBounds и методы Aspose.Slides.IShape.GetThumbnail()**
Методы GetThumbnail() и GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) используются для создания отдельного эскиза формы. Перечисление ShapeThumbnailBounds определяет возможные типы границ эскиза формы.
### **Свойство UniqueId добавлено в Aspose.Slides.IShape**
Свойство Aspose.Slides.IShape.UniqueId получает уникальный идентификатор формы в пределах презентации. Эти уникальные идентификаторы хранятся в пользовательских тегах формы.
### **Подпись метода SetGroupingItem изменена в IChartCategoryLevelsManager**
Подпись метода IChartCategoryLevelsManager

``` csharp

 void SetGroupingItem(int level, IChartDataCell value);

``` 

теперь устарела и заменена на подпись

``` csharp

 void SetGroupingItem(int level, object value);

``` 

Теперь такие вызовы, как

``` csharp

 .SetGroupingItem(1, workbook.GetCell(0, "A2", "Группа 1"));

``` 

должны быть изменены на вызовы, такие как

``` csharp

 .SetGroupingItem(1, "Группа 1");

``` 

Передайте значение, такое как "Группа 1", в SetGroupingItem, а не значение типа IChartDataCell. Конструирование IChartDataCell с заданным рабочим листом, строкой и столбцом для уровней категорий должно соответствовать определенным требованиям и было инкапсулировано в методе SetGroupingItem(int, object).
### **Свойство SlideId добавлено в интерфейс Aspose.Slides.IBaseSlide**
Свойство SlideId получает уникальный идентификатор слайда.
### **Свойство SoundName добавлено в ISlideShowTransition**
Читаемая и запись строка. Указывает человекочитаемое имя для звука перехода. Свойство Sound должно быть задано, чтобы получить или установить имя звука. Это имя появляется в пользовательском интерфейсе PowerPoint при ручной настройке звука перехода. Может вызвать PptxException, если свойство Sound не задано.
### **Тип свойства ChartSeriesGroup.Type изменен**
Свойство ChartSeriesGroup.Type было изменено с перечисления ChartType на новое перечисление CombinableSeriesTypesGroup. Перечисление CombinableSeriesTypesGroup представляет группы комбинируемых типов серии.
### **Добавлена поддержка генерации индивидуальных миниатюр форм**
Aspose.Slides.ShapeThumbnailBounds

Новые члены в Aspose.Slides.IShape, Aspose.Slides.Shape:
public Bitmap GetThumbnail()
public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)