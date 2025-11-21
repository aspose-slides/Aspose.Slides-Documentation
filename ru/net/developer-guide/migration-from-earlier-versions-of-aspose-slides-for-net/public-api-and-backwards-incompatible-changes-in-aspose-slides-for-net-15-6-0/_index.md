---
title: Публичный API и несовместимые изменения в Aspose.Slides для .NET 15.6.0
linktitle: Aspose.Slides для .NET 15.6.0
type: docs
weight: 170
url: /ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/
keywords:
- миграция
- устаревший код
- современный код
- устаревший подход
- современный подход
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Обзор обновлений публичного API и разрушающих изменений в Aspose.Slides для .NET для плавной миграции ваших решений по работе с презентациями PowerPoint PPT, PPTX и ODP."
---

{{% alert color="primary" %}} 

Эта страница содержит список всех [добавленных](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) или [удалённых](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) классов, методов, свойств и т.п., а также других изменений, введённых в API Aspose.Slides for .NET 15.6.0.

{{% /alert %}} 
## **Изменения публичного API**
#### **Сигнатура конструктора DataLabel была изменена**
Сигнатура конструктора DataLabel была изменена:
was: DataLabel.#ctor(Aspose.Slides.Charts.IChartSeries);
now: DataLabel.#ctor(Aspose.Slides.Charts.IChartDataPoint).
#### **Члены IDocumentProperties.Count, .GetPropertyName(int index), .Remove(string name), .Contains(string name) помечены как устаревшие, и вместо них введены их заменители.**
Свойство IDocumentProperties.Count и методы IDocumentProperties.GetPropertyName(int index), .Remove(string name), .Contains(string name) помечены как устаревшие. Вместо них добавлены свойство IDocumentProperties.CountOfCustomProperties и методы IDocumentProperties.GetCustomPropertyName(int index), .RemoveCustomProperty(string name), .ContainsCustomProperty(string name).
#### **Метод INotesSlideManager.RemoveNotesSlide() добавлен**
Метод INotesSlideManager.RemoveNotesSlide() добавлен для удаления слайда заметок у некоторого слайда.
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
Свойство IDocumentProperties.AppVersion добавлено для получения встроенного свойства документа, представляющего внутренние номера версии, используемые Microsoft во время разработки.
#### **Свойство BlackWhiteMode добавлено в IShape и в Shape**
Свойство BlackWhiteMode добавлено в IShape и в Shape.

Это свойство указывает, как форма будет отображаться в режиме черно‑белого отображения.

|**Значение** |**Описание** |
| :- | :- |
|Color |Отображается в обычных цветах |
|Automatic |Отображается с автоматическим подбором цвета |
|Gray |Отображается в серых тонах |
|LightGray |Отображается в светло‑серых тонах |
|InverseGray |Отображается в инвертированных серых тонах |
|GrayWhite |Отображается в серо‑белой гамме |
|BlackGray |Отображается в чёрно‑серой гамме |
|BlackWhite |Отображается в чёрно‑белой гамме |
|Black |Отображается только чёрным цветом |
|White |Отображается белым цветом |
|Hidden |Не отображается |
|NotDefined|означает, что свойство не установлено|
#### **Свойство ISlide.NotesSlideManager добавлено. Свойство ISlide.NotesSlide и метод ISlide.AddNotesSlide() помечены как устаревшие.**
Члены ISlide.NotesSlide и ISlide.AddNotesSlide() помечены как устаревшие. Используйте новое свойство ISlide.NotesSlideManager вместо них.

``` csharp

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.AddNotesSlide(); - устарело

// notes = slide.NotesSlide; - устарело

notes = slide.NotesSlideManager.NotesSlide;

notes = slide.NotesSlideManager.AddNotesSlide();

slide.NotesSlideManager.RemoveNotesSlide();

```