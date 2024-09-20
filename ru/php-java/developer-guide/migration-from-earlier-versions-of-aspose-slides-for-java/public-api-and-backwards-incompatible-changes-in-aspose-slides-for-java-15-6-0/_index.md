---
title: Публичное API и изменения, несовместимые с предыдущими версиями в Aspose.Slides для PHP через Java 15.6.0
type: docs
weight: 140
url: /php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/
---

{{% alert color="primary" %}} 

Эта страница перечисляет все [добавленные](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) классы, методы, свойства и так далее, любые новые ограничения и другие [изменения](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) введенные с API Aspose.Slides для PHP через Java 15.6.0.

{{% /alert %}} 
## **Изменения в публичном API**
#### **Сигнатура конструктора com.aspose.slides.DataLabel изменена**
Сигнатура конструктора была изменена с DataLabel(com.aspose.slides.IChartSeries) на DataLabel(com.aspose.slides.IChartDataPoint).
#### **Члены com.aspose.slides.IDocumentProperties.getCount(), .getPropertyName(int index), .remove(String name), .contains(String name) отмечены как устаревшие; вместо них введены замены**
Методы IDocumentProperties.getCount(), IDocumentProperties.getPropertyName(int index), .remove(string name), .contains(string name) отмечены как устаревшие. Вместо них введены методы IDocumentProperties.countOfCustomProperties(), IDocumentProperties.getCustomPropertyName(int index), .removeCustomProperty(String name), .containsCustomProperty(string name).
#### **Метод com.aspose.slides.INotesSlideManager.removeNotesSlide() добавлен**
Метод com.aspose.slides.INotesSlideManager.removeNotesSlide() добавлен для удаления заметок слайда.
#### **Метод com.aspose.slides.ISlide.getNotesSlideManager() добавлен. Методы ISlide.getNotesSlide() и ISlide.addNotesSlide() отмечены как устаревшие**
Методы ISlide.getNotesSlide(), ISlide.addNotesSlide() отмечены как устаревшие. Вместо них используйте новый метод ISlide.getNotesSlideManager().

```php
  $slide = $$missing$;
  $notes;
  # notes = slide.addNotesSlide(); - устарело
  # notes = slide.getNotesSlide(); - устарело
  $notes = $slide->getNotesSlideManager()->getNotesSlide();
  $notes = $slide->getNotesSlideManager()->addNotesSlide();
  $slide->getNotesSlideManager()->removeNotesSlide();

```
#### **Метод getAppVersion() добавлен в com.aspose.slides.IDocumentProperties**
Метод com.aspose.slides.IDocumentProperties.getAppVersion() добавлен для получения встроенного свойства документа, которое представляет внутренние номера версий, используемые Microsoft PowerPoint.
#### **Метод remove() добавлен в com.aspose.slides.IComment**
Метод com.aspose.slides.IComment.remove() добавлен для удаления комментария из коллекции.
#### **Метод remove() добавлен в com.aspose.slides.ICommentAuthor**
Метод ICommentAuthor.Remove добавлен для удаления автора комментариев из коллекции.
#### **Методы clearCustomProperties() и clearBuiltInProperties() добавлены в com.aspose.slides.IDocumentProperties**
Метод com.aspose.slides.IDocumentProperties.clearCustomProperties() добавлен для удаления всех пользовательских свойств документа.
Метод com.aspose.slides.IDocumentProperties.clearBuiltInProperties() добавлен для удаления и установки значений по умолчанию для всех встроенных свойств документа (Компания, Тема, Автор и т.д.).
#### **Методы getBlackWhiteMode(), setBlackWhiteMode(byte) добавлены в com.aspose.slides.IShape**
Методы getBlackWhiteMode(), setBlackWhiteMode(byte) добавлены в com.aspose.slides.IShape.
Эти методы указывают, как форма будет отображаться в черно-белом режиме. Возможные значения указаны в классе com.aspose.slides.BlackWhiteMode.

|**Значение** |**Значение** |
| :- | :- |
|Color |Возвращение с нормальной раскраской |
|Automatic |Возвращение с автоматической раскраской |
|Gray |Возвращение с серой раскраской |
|LightGray |Возвращение с светло-серой раскраской |
|InverseGray |Возвращение с обратной серой раскраской |
|GrayWhite |Возвращение с серой и белой раскраской |
|BlackGray |Возвращение с черной и серой раскраской |
|BlackWhite |Возвращение с черной и белой раскраской |
|Black |Возвращение только с черной раскраской |
|White |Возвращение с белой раскраской |
|Hidden |Объект не отображается |
#### **Методы removeAt(int), remove(ICommentAuthor) и clear() добавлены в com.aspose.slides.ICommentAuthorCollection**
Метод ICommentAuthorCollection.removeAt(int) добавлен для удаления автора по указанному индексу. Метод ICommentAuthorCollection.remove(ICommentAuthor) добавлен для удаления указанного автора из коллекции. Метод ICommentAuthorCollection.clear() добавлен для удаления всех элементов из коллекции.