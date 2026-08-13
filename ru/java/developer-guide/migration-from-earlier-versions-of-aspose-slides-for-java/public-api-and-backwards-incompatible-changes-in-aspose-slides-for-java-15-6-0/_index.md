---
title: "Публичный API и обратно несовместимые изменения в Aspose.Slides for Java 15.6.0"
linktitle: "Aspose.Slides для Java 15.6.0"
type: docs
weight: 140
url: /ru/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/
aliases:
  - /java/aspose-slides-dlya-java-15-6-0-reliznye-zametki/
keywords:
  - миграция
  - наследуемый код
  - современный код
  - наследуемый подход
  - современный подход
  - PowerPoint
  - OpenDocument
  - презентация
  - Java
  - Aspose.Slides
description: "Обзор обновлений публичного API и разбивающих изменений в Aspose.Slides for Java для плавной миграции ваших решений по презентациям PowerPoint PPT, PPTX и ODP."
---
{{% alert color="info" %}} 
Эта страница перечисляет все [добавленные](/slides/ru/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) классы, методы, свойства и т.д., любые новые ограничения и другие [изменения](/slides/ru/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) внедрённые в API Aspose.Slides for Java 15.6.0.
{{% /alert %}} 
## **Public API changes**
#### **com.aspose.slides.DataLabel constructor signature has been changed**
Сигнатура конструктора com.aspose.slides.DataLabel была изменена с DataLabel(com.aspose.slides.IChartSeries) на DataLabel(com.aspose.slides.IChartDataPoint).
#### **Members com.aspose.slides.IDocumentProperties.getCount(), .getPropertyName(int index)., .remove(String name), .contains(String name) have been marked as Deprecated; substitutions have been introduced instead**
Члены com.aspose.slides.IDocumentProperties.getCount(), .getPropertyName(int index)., .remove(String name), .contains(String name) были помечены как устаревшие; вместо них введены альтернативы. Методы IDocumentProperties.getCount(), IDocumentProperties.getPropertyName(int index)., .remove(string name), .contains(string name) были помечены как устаревшие. Вместо них введены методы IDocumentProperties.countOfCustomProperties(), IDocumentProperties.getCustomPropertyName(int index)., .removeCustomProperty(String name), .containsCustomProperty(string name).
#### **Method com.aspose.slides.INotesSlideManager.removeNotesSlide() has been added**
Метод com.aspose.slides.INotesSlideManager.removeNotesSlide() был добавлен для удаления слайда заметок у некоторого слайда.
#### **Method com.aspose.slides.ISlide.getNotesSlideManager() has been added. Methods ISlide.getNotesSlide() and ISlide.addNotesSlide() have been marked as Deprecated**
Метод com.aspose.slides.ISlide.getNotesSlideManager() был добавлен. Методы ISlide.getNotesSlide() и ISlide.addNotesSlide() были помечены как устаревшие. Методы ISlide.getNotesSlide() и ISlide.addNotesSlide() были помечены как устаревшие. Вместо них используйте новый метод ISlide.getNotesSlideManager().
``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    INotesSlide notes;

    // notes = slide.addNotesSlide(); - устаревший

    // notes = slide.getNotesSlide(); - устаревший

    notes = slide.getNotesSlideManager().getNotesSlide();

    notes = slide.getNotesSlideManager().addNotesSlide();

    slide.getNotesSlideManager().removeNotesSlide();
} finally {
    if (pres != null) pres.dispose();
}
```
#### **Method getAppVersion() has been added to com.aspose.slides.IDocumentProperties**
Метод getAppVersion() был добавлен в com.aspose.slides.IDocumentProperties. Метод com.aspose.slides.IDocumentProperties.getAppVersion() был добавлен для получения встроенного свойства документа, представляющего внутренние версии, используемые Microsoft PowerPoint.
#### **Method remove() has been added to com.aspose.slides.IComment**
Метод remove() был добавлен в com.aspose.slides.IComment. Метод com.aspose.slides.IComment.remove() был добавлен для удаления комментария из коллекции.
#### **Method remove() has been added to com.aspose.slides.ICommentAuthor**
Метод remove() был добавлен в com.aspose.slides.ICommentAuthor. Метод ICommentAuthor.Remove был добавлен для удаления автора комментариев из коллекции.
#### **Methods clearCustomProperties() and clearBuiltInProperties() have been added to com.aspose.slides.IDocumentProperties**
Методы clearCustomProperties() и clearBuiltInProperties() были добавлены в com.aspose.slides.IDocumentProperties. Метод com.aspose.slides.IDocumentProperties.clearCustomProperties() был добавлен для удаления всех пользовательских свойств документа. Метод com.aspose.slides.IDocumentProperties.clearBuiltInProperties() был добавлен для удаления и установки значений по умолчанию для всех встроенных свойств документа (Company, Subject, Author и т.д.).
#### **Methods getBlackWhiteMode(), setBlackWhiteMode(byte) have been added to com.aspose.slides.IShape**
Методы getBlackWhiteMode() и setBlackWhiteMode(byte) были добавлены в com.aspose.slides.IShape. Эти методы определяют, как фигура будет отображаться в черно‑белом режиме. Возможные значения указаны в классе com.aspose.slides.BlackWhiteMode.

|**Значение**|**Описание**|
| :- | :- |
|Color|Возвращает с обычной окраской|
|Automatic|Возвращает с автоматической окраской|
|Gray|Возвращает с серой окраской|
|LightGray|Возвращает с светло‑серой окраской|
|InverseGray|Возвращает с обратной серой окраской|
|GrayWhite|Возвращает с серой и белой окраской|
|BlackGray|Возвращает с черной и серой окраской|
|BlackWhite|Возвращает с черной и белой окраской|
|Black|Возвращает только с черной окраской|
|White|Возвращает с белой окраской|
|Hidden|Объект не отображается|
#### **Methods removeAt(int), remove(ICommentAuthor) and clear() have been added to com.aspose.slides.ICommentAuthorCollection**
Методы removeAt(int), remove(ICommentAuthor) и clear() были добавлены в com.aspose.slides.ICommentAuthorCollection. Метод ICommentAuthorCollection.removeAt(int) был добавлен для удаления автора по указанному индексу. Метод ICommentAuthorCollection.remove(ICommentAuthor) был добавлен для удаления указанного автора из коллекции. Метод ICommentAuthorCollection.clear() был добавлен для удаления всех элементов из коллекции.