---
title: Публичный API и несовместимые изменения в Aspose.Slides для Java 15.6.0
type: docs
weight: 140
url: /androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/
---

{{% alert color="primary" %}} 

Эта страница содержит список всех [добавленных](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) классов, методов, свойств и т.д., любых новых ограничений и других [изменений](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/), введенных в API Aspose.Slides для Java 15.6.0.

{{% /alert %}} 
## **Изменения в публичном API**
#### **Подпись конструктора com.aspose.slides.DataLabel была изменена**
Подпись конструктора была изменена с DataLabel(com.aspose.slides.IChartSeries) на DataLabel(com.aspose.slides.IChartDataPoint).
#### **Члены com.aspose.slides.IDocumentProperties.getCount(), .getPropertyName(int index), .remove(String name), .contains(String name) были отмечены как устаревшие; вместо них были введены замены**
Методы IDocumentProperties.getCount(), IDocumentProperties.getPropertyName(int index), .remove(String name), .contains(String name) были отмечены как устаревшие. Вместо них были введены методы IDocumentProperties.countOfCustomProperties(), IDocumentProperties.getCustomPropertyName(int index), .removeCustomProperty(String name), .containsCustomProperty(String name).
#### **Метод com.aspose.slides.INotesSlideManager.removeNotesSlide() был добавлен**
Метод com.aspose.slides.INotesSlideManager.removeNotesSlide() был добавлен для удаления слайдов с заметками из какого-либо слайда.
#### **Метод com.aspose.slides.ISlide.getNotesSlideManager() был добавлен. Методы ISlide.getNotesSlide() и ISlide.addNotesSlide() были отмечены как устаревшие**
Методы ISlide.getNotesSlide(), ISlide.addNotesSlide() были отмечены как устаревшие. Вместо них используйте новый метод ISlide.getNotesSlideManager().

``` java

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.addNotesSlide(); - устарел

// notes = slide.getNotesSlide(); - устарел

notes = slide.getNotesSlideManager().getNotesSlide();

notes = slide.getNotesSlideManager().addNotesSlide();

slide.getNotesSlideManager().removeNotesSlide();

```
#### **Метод getAppVersion() был добавлен в com.aspose.slides.IDocumentProperties**
Метод com.aspose.slides.IDocumentProperties.getAppVersion() был добавлен для получения встроенного свойства документа, которое представляет собой внутренние номера версий, используемые Microsoft PowerPoint.
#### **Метод remove() был добавлен в com.aspose.slides.IComment**
Метод com.aspose.slides.IComment.remove() был добавлен для удаления комментария из коллекции.
#### **Метод remove() был добавлен в com.aspose.slides.ICommentAuthor**
Метод ICommentAuthor.remove() был добавлен для удаления автора комментариев из коллекции.
#### **Методы clearCustomProperties() и clearBuiltInProperties() были добавлены в com.aspose.slides.IDocumentProperties**
Метод com.aspose.slides.IDocumentProperties.clearCustomProperties() был добавлен для удаления всех пользовательских свойств документа.
Метод com.aspose.slides.IDocumentProperties.clearBuiltInProperties() был добавлен для удаления и установки значений по умолчанию для всех встроенных свойств документа (Компания, Тема, Автор и т.д.).
#### **Методы getBlackWhiteMode(), setBlackWhiteMode(byte) были добавлены в com.aspose.slides.IShape**
Методы getBlackWhiteMode(), setBlackWhiteMode(byte) были добавлены в com.aspose.slides.IShape.
Эти методы определяют, как форма будет отображаться в черно-белом режиме. Возможные значения указаны в классе com.aspose.slides.BlackWhiteMode.

|**Значение** |**Значение** |
| :- | :- |
|Color |Возвращает с нормальной окраской |
|Automatic |Возвращает с автоматической окраской |
|Gray |Возвращает с серой окраской |
|LightGray |Возвращает со светло-серой окраской |
|InverseGray |Возвращает с инверсной серой окраской |
|GrayWhite |Возвращает с серой и белой окраской |
|BlackGray |Возвращает с черной и серой окраской |
|BlackWhite |Возвращает с черной и белой окраской |
|Black |Возвращает только с черной окраской |
|White |Возвращает с белой окраской |
|Hidden |Объект не отображается |
#### **Методы removeAt(int), remove(ICommentAuthor) и clear() были добавлены в com.aspose.slides.ICommentAuthorCollection**
Метод ICommentAuthorCollection.removeAt(int) был добавлен для удаления автора по указанному индексу. Метод ICommentAuthorCollection.remove(ICommentAuthor) был добавлен для удаления указанного автора из коллекции. Метод ICommentAuthorCollection.clear() был добавлен для удаления всех элементов из коллекции.