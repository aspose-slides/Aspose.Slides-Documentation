---
title: Обобщённый API и несовместимые изменения в Aspose.Slides для Java 15.6.0
linktitle: Aspose.Slides для Java 15.6.0
type: docs
weight: 140
url: /ru/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/
aliases:
  - /java/aspose-slides-for-java-15-6-0-release-notes/
keywords:
  - миграция
  - унаследованный код
  - современный код
  - унаследованный подход
  - современный подход
  - PowerPoint
  - OpenDocument
  - презентация
  - Java
  - Aspose.Slides
description: "Обзор обновлений публичного API и разрушающих изменений в Aspose.Slides для Java, позволяющих плавно мигрировать ваши решения для презентаций PowerPoint PPT, PPTX и ODP."
---
{{% alert color="primary" %}} 

Эта страница перечисляет все [добавленные](/slides/ru/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) классы, методы, свойства и т.д., любые новые ограничения и другие [изменения](/slides/ru/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) введённые в API Aspose.Slides for Java 15.6.0.

{{% /alert %}} 
## **Изменения публичного API**
#### **Подпись конструктора com.aspose.slides.DataLabel изменена**
Подпись конструктора изменена с DataLabel(com.aspose.slides.IChartSeries) на DataLabel(com.aspose.slides.IChartDataPoint).
#### **Члены com.aspose.slides.IDocumentProperties.getCount(), .getPropertyName(int index)., .remove(String name), .contains(String name) помечены как устаревшие; вместо них введены замены**
Методы IDocumentProperties.getCount(), IDocumentProperties.getPropertyName(int index)., .remove(string name), .contains(string name) помечены как устаревшие. Вместо них введены методы IDocumentProperties.countOfCustomProperties(), IDocumentProperties.getCustomPropertyName(int index)., .removeCustomProperty(String name), .containsCustomProperty(string name).
#### **Метод com.aspose.slides.INotesSlideManager.removeNotesSlide() добавлен**
Метод com.aspose.slides.INotesSlideManager.RemoveNotesSlide() добавлен для удаления слайда заметок у некоторого слайда.
#### **Метод com.aspose.slides.ISlide.getNotesSlideManager() добавлен. Методы ISlide.getNotesSlide() и ISlide.addNotesSlide() помечены как устаревшие**
Методы ISlide.getNotesSlide() и ISlide.addNotesSlide() помечены как устаревшие. Вместо них используйте новый метод ISlide.getNotesSlideManager() вместо.

``` java

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.addNotesSlide(); - устарело

// notes = slide.getNotesSlide(); - устарело

notes = slide.getNotesSlideManager().getNotesSlide();

notes = slide.getNotesSlideManager().addNotesSlide();

slide.getNotesSlideManager().removeNotesSlide();

```
#### **Метод getAppVersion() добавлен в com.aspose.slides.IDocumentProperties**
Метод com.aspose.slides.IDocumentProperties.getAppVersion() добавлен для получения встроенного свойства документа, которое представляет внутренние номера версий, используемые в Microsoft PowerPoint.
#### **Метод remove() добавлен в com.aspose.slides.IComment**
Метод com.aspose.slides.IComment.remove() добавлен для удаления комментария из коллекции.
#### **Метод remove() добавлен в com.aspose.slides.ICommentAuthor**
Метод ICommentAuthor.Remove добавлен для удаления автора комментариев из коллекции.
#### **Методы clearCustomProperties() и clearBuiltInProperties() добавлены в com.aspose.slides.IDocumentProperties**
Метод com.aspose.slides.IDocumentProperties.clearCustomProperties() добавлен для удаления всех пользовательских свойств документа.
Метод com.aspose.slides.IDocumentProperties.clearBuiltInProperties() добавлен для удаления и установки значений по умолчанию для всех встроенных свойств документа (Company, Subject, Author и т.д.).
#### **Методы getBlackWhiteMode(), setBlackWhiteMode(byte) добавлены в com.aspose.slides.IShape**
Методы getBlackWhiteMode() и setBlackWhiteMode(byte) добавлены в com.aspose.slides.IShape.
Эти методы определяют, как форма будет отображаться в черно‑белом режиме. Возможные значения указаны в классе com.aspose.slides.BlackWhiteMode.

|**Значение**|**Описание**|
| :- | :- |
|Color|Возвращает с обычным цветом|
|Automatic|Возвращает с автоматическим цветом|
|Gray|Возвращает с серым цветом|
|LightGray|Возвращает со светло-серым цветом|
|InverseGray|Возвращает с инвертированным серым цветом|
|GrayWhite|Возвращает с серым и белым цветом|
|BlackGray|Возвращает с чёрным и серым цветом|
|BlackWhite|Возвращает с чёрным и белым цветом|
|Black|Возвращает только чёрным цветом|
|White|Возвращает с белым цветом|
|Hidden|Объект не отображается|
#### **Методы removeAt(int), remove(ICommentAuthor) и clear() добавлены в com.aspose.slides.ICommentAuthorCollection**
Метод ICommentAuthorCollection.removeAt(int) добавлен для удаления автора по указанному индексу. Метод ICommentAuthorCollection.remove(ICommentAuthor) добавлен для удаления указанного автора из коллекции. Метод ICommentAuthorCollection.clear() добавлен для удаления всех элементов из коллекции.