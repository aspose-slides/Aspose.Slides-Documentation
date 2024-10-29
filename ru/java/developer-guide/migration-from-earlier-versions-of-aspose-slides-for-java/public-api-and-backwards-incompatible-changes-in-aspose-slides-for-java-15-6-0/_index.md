---
title: Публичный API и несовместимые изменения в Aspose.Slides для Java 15.6.0
type: docs
weight: 140
url: /ru/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/
---

{{% alert color="primary" %}} 

Эта страница содержит все [добавленные](/slides/ru/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) классы, методы, свойства и так далее, любые новые ограничения и другие [изменения](/slides/ru/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/), введенные с API Aspose.Slides для Java 15.6.0.

{{% /alert %}} 
## **Изменения в публичном API**
#### **Подпись конструктора com.aspose.slides.DataLabel была изменена**
Подпись конструктора была изменена с DataLabel(com.aspose.slides.IChartSeries) на DataLabel(com.aspose.slides.IChartDataPoint).
#### **Члены com.aspose.slides.IDocumentProperties.getCount(), .getPropertyName(int index), .remove(String name), .contains(String name) были помечены как устаревшие; вместо них были введены замены**
Методы IDocumentProperties.getCount(), IDocumentProperties.getPropertyName(int index), .remove(string name), .contains(string name) были помечены как устаревшие. Вместо них были введены методы IDocumentProperties.countOfCustomProperties(), IDocumentProperties.getCustomPropertyName(int index), .removeCustomProperty(String name), .containsCustomProperty(string name).
#### **Метод com.aspose.slides.INotesSlideManager.removeNotesSlide() был добавлен**
Метод com.aspose.slides.INotesSlideManager.RemoveNotesSlide() был добавлен для удаления слайдов заметок с определенного слайда.
#### **Метод com.aspose.slides.ISlide.getNotesSlideManager() был добавлен. Методы ISlide.getNotesSlide() и ISlide.addNotesSlide() были помечены как устаревшие**
Методы ISlide.getNotesSlide(), ISlide.addNotesSlide() были помечены как устаревшие. Вместо них используйте новый метод ISlide.getNotesSlideManager().

``` java

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.addNotesSlide(); - устаревший

// notes = slide.getNotesSlide(); - устаревший

notes = slide.getNotesSlideManager().getNotesSlide();

notes = slide.getNotesSlideManager().addNotesSlide();

slide.getNotesSlideManager().removeNotesSlide();

```
#### **Метод getAppVersion() был добавлен в com.aspose.slides.IDocumentProperties**
Метод com.aspose.slides.IDocumentProperties.getAppVersion() был добавлен для получения встроенного свойства документа, которое представляет внутренние номера версий, используемые Microsoft PowerPoint.
#### **Метод remove() был добавлен в com.aspose.slides.IComment**
Метод com.aspose.slides.IComment.remove() был добавлен для удаления комментария из коллекции.
#### **Метод remove() был добавлен в com.aspose.slides.ICommentAuthor**
Метод ICommentAuthor.Remove был добавлен для удаления автора комментариев из коллекции.
#### **Методы clearCustomProperties() и clearBuiltInProperties() были добавлены в com.aspose.slides.IDocumentProperties**
Метод com.aspose.slides.IDocumentProperties.clearCustomProperties() был добавлен для удаления всех пользовательских свойств документа.
Метод com.aspose.slides.IDocumentProperties.clearBuiltInProperties() был добавлен для удаления и установки значений по умолчанию для всех встроенных свойств документа (Компания, Тема, Автор и т.д.).
#### **Методы getBlackWhiteMode(), setBlackWhiteMode(byte) были добавлены в com.aspose.slides.IShape**
Методы getBlackWhiteMode(), setBlackWhiteMode(byte) были добавлены в com.aspose.slides.IShape.
Эти методы определяют, как фигура будет отображаться в черно-белом режиме. Возможные значения указаны в классе com.aspose.slides.BlackWhiteMode.

|**Значение** |**Значение** |
| :- | :- |
|Color |Возвращать с обычной цветовой раскраской |
|Automatic |Возвращать с автоматической раскраской |
|Gray |Возвращать с серой раскраской |
|LightGray |Возвращать с светло-серой раскраской |
|InverseGray |Возвращать с инверсной серой раскраской |
|GrayWhite |Возвращать с серой и белой раскраской |
|BlackGray |Возвращать с черной и серой раскраской |
|BlackWhite |Возвращать с черной и белой раскраской |
|Black |Возвращать только с черной раскраской |
|White |Возвращать с белой раскраской |
|Hidden |Объект не отображается |
#### **Методы removeAt(int), remove(ICommentAuthor) и clear() были добавлены в com.aspose.slides.ICommentAuthorCollection**
Метод ICommentAuthorCollection.removeAt(int) был добавлен для удаления автора по указанному индексу. Метод ICommentAuthorCollection.remove(ICommentAuthor) был добавлен для удаления указанного автора из коллекции. Метод ICommentAuthorCollection.clear() был добавлен для удаления всех элементов из коллекции.