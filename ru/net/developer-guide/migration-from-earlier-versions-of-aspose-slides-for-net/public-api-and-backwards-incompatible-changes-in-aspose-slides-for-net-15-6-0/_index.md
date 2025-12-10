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
description: "Обзор обновлений публичного API и разрушающих изменений в Aspose.Slides для .NET, позволяющий плавно перенести решения для презентаций PowerPoint PPT, PPTX и ODP."
---

{{% alert color="primary" %}} 

Эта страница перечисляет все [added](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) или [removed](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) классы, методы, свойства и т.д., а также другие изменения, внесённые в API Aspose.Slides for .NET 15.6.0.

{{% /alert %}} 
## **Изменения публичного API**
#### **Сигнатура конструктора DataLabel изменена**
Сигнатура конструктора DataLabel изменена:
было: DataLabel.#ctor(Aspose.Slides.Charts.IChartSeries);
сейчас: DataLabel.#ctor(Aspose.Slides.Charts.IChartDataPoint).
#### **Члены IDocumentProperties.Count, .GetPropertyName(int index), .Remove(string name), .Contains(string name) помечены как устаревшие, и вместо них введены их заменители.**
Свойство IDocumentProperties.Count и методы IDocumentProperties.GetPropertyName(int index), .Remove(string name), .Contains(string name) помечены как устаревшие. Вместо них добавлены свойство IDocumentProperties.CountOfCustomProperties и методы IDocumentProperties.GetCustomPropertyName(int index), .RemoveCustomProperty(string name), .ContainsCustomProperty(string name).
#### **Метод INotesSlideManager.RemoveNotesSlide() добавлен**
Метод INotesSlideManager.RemoveNotesSlide() добавлен для удаления заметок с определённого слайда.
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
#### **Свойство BlackWhiteMode добавлено в IShape и Shape**
Свойство BlackWhiteMode добавлено в IShape и Shape.

Это свойство определяет, как фигура будет отображаться в режиме черно‑белого отображения.

|**Значение** |**Описание** |
| :- | :- |
|Color |Отображать с обычными цветами |
|Automatic |Отображать с автоматическим окрашиванием |
|Gray |Отображать в оттенках серого |
|LightGray |Отображать в светло‑сером цвете |
|InverseGray |Отображать с инвертированным серым цветом |
|GrayWhite |Отображать в сером и белом цвете |
|BlackGray |Отображать в черном и сером цвете |
|BlackWhite |Отображать в черном и белом цвете |
|Black |Отображать только в чёрном цвете |
|White |Отображать в белом цвете |
|Hidden |Не отображать |
|NotDefined|означает, что свойство не установлено|
#### **Свойство ISlide.NotesSlideManager добавлено. Свойство ISlide.NotesSlide и метод ISlide.AddNotesSlide() помечены как устаревшие.**
Члены ISlide.NotesSlide, ISlide.AddNotesSlide() помечены как устаревшие. Используйте новое свойство ISlide.NotesSlideManager вместо них.

``` csharp

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.AddNotesSlide(); - obsolete

// notes = slide.NotesSlide; - obsolete

notes = slide.NotesSlideManager.NotesSlide;

notes = slide.NotesSlideManager.AddNotesSlide();

slide.NotesSlideManager.RemoveNotesSlide();

```