---
title: Публичный API и несовместимые изменения в Aspose.Slides для .NET 15.6.0
linktitle: Aspose.Slides для .NET 15.6.0
type: docs
weight: 170
url: /ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/
keywords:
- миграция
- наследуемый код
- современный код
- наследуемый подход
- современный подход
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Обзор обновлений публичного API и разрывных изменений в Aspose.Slides для .NET, позволяющих плавно мигрировать ваши решения для презентаций PowerPoint PPT, PPTX и ODP."
---

{{% alert color="primary" %}} 

Эта страница содержит список всех [added](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) или [removed](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) классов, методов, свойств и т.д., а также других изменений, внесённых в API Aspose.Slides for .NET 15.6.0.

{{% /alert %}} 
## **Изменения публичного API**
#### **Подпись конструктора DataLabel изменена**
Подпись конструктора DataLabel изменена:
было: DataLabel.#ctor(Aspose.Slides.Charts.IChartSeries);
сейчас: DataLabel.#ctor(Aspose.Slides.Charts.IChartDataPoint).
#### **Свойства IDocumentProperties.Count, .GetPropertyName(int index), .Remove(string name), .Contains(string name) помечены как Obsolete, вместо них введены заменяющие свойства и методы.**
Свойство IDocumentProperties.Count и методы IDocumentProperties.GetPropertyName(int index), .Remove(string name), .Contains(string name) помечены как Obsolete. Вместо них добавлены свойство IDocumentProperties.CountOfCustomProperties и методы IDocumentProperties.GetCustomPropertyName(int index), .RemoveCustomProperty(string name), .ContainsCustomProperty(string name).
#### **Метод INotesSlideManager.RemoveNotesSlide() добавлен**
Метод INotesSlideManager.RemoveNotesSlide() добавлен для удаления слайда заметок у определённого слайда.
#### **Метод Remove добавлен в IComment**
Метод IComment.Remove добавлен для удаления комментария из коллекции.
#### **Метод Remove добавлен в ICommentAuthor**
Метод ICommentAuthor.Remove добавлен для удаления автора комментариев из коллекции.
#### **Методы ClearCustomProperties и ClearBuiltInProperties добавлены в IDocumentProperties**
Метод IDocumentProperties.ClearCustomProperties добавлен для удаления всех пользовательских свойств документа.
Метод IDocumentProperties.ClearBuiltInProperties добавлен для удаления и установки значений по умолчанию для всех встроенных свойств документа (Company, Subject, Author и т.д.).
#### **Методы RemoveAt, Remove и Clear добавлены в ICommentAuthorCollection**
Метод ICommentAuthorCollection.RemoveAt добавлен для удаления автора по указанному индексу.
Метод ICommentAuthorCollection.Remove добавлен для удаления указанного автора из коллекции.
Метод ICommentAuthorCollection.Clear добавлен для удаления всех элементов из коллекции.
#### **Свойство AppVersion добавлено в IDocumentProperties**
Свойство IDocumentProperties.AppVersion добавлено для получения встроенного свойства документа, которое представляет внутренние номера версии, используемые Microsoft во время разработки.
#### **Свойство BlackWhiteMode добавлено в IShape и в Shape**
Свойство BlackWhiteMode добавлено в IShape и в Shape.

Это свойство определяет, как форма будет отображаться в режиме черно‑белого отображения.

|**Значение** |**Описание** |
| :- | :- |
|Color |Отрисовывать с обычной раскраской |
|Automatic |Отрисовывать с автоматической раскраской |
|Gray |Отрисовывать со сплошной серой раскраской |
|LightGray |Отрисовывать со светло‑серой раскраской |
|InverseGray |Отрисовывать с обратной серой раскраской |
|GrayWhite |Отрисовывать с серой и белой раскраской |
|BlackGray |Отрисовывать с черной и серой раскраской |
|BlackWhite |Отрисовывать с черной и белой раскраской |
|Black |Отрисовывать только черным цветом |
|White |Отрисовывать белым цветом |
|Hidden |Не отрисовывать |
|NotDefined |означает, что свойство не задано|
#### **Свойство ISlide.NotesSlideManager добавлено. Свойства ISlide.NotesSlide и метод ISlide.AddNotesSlide() помечены как Obsolete.**
Члены ISlide.NotesSlide, ISlide.AddNotesSlide() помечены как Obsolete. Используйте новое свойство ISlide.NotesSlideManager вместо них.

``` csharp

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.AddNotesSlide(); - устарело

// notes = slide.NotesSlide; - устарело

notes = slide.NotesSlideManager.NotesSlide;

notes = slide.NotesSlideManager.AddNotesSlide();

slide.NotesSlideManager.RemoveNotesSlide();

```