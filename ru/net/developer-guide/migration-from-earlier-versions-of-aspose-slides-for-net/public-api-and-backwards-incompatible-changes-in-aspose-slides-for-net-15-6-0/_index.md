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
- традиционный подход
- современный подход
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Изучите обновления публичного API и разрушающие изменения в Aspose.Slides для .NET, чтобы плавно мигрировать ваши решения для презентаций PowerPoint PPT, PPTX и ODP."
---

{{% alert color="primary" %}} 

Эта страница перечисляет все [добавленные](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) или [удалённые](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) классы, методы, свойства и т.д., а также другие изменения, введённые в API Aspose.Slides for .NET 15.6.0.

{{% /alert %}} 
## **Изменения публичного API**
#### **Подпись конструктора DataLabel изменена**
Подпись конструктора DataLabel изменена:
was: DataLabel.#ctor(Aspose.Slides.Charts.IChartSeries);
now: DataLabel.#ctor(Aspose.Slides.Charts.IChartDataPoint).
#### **Члены IDocumentProperties.Count, .GetPropertyName(int index), .Remove(string name), .Contains(string name) помечены как устаревшие, и вместо них введены их замены.**
Свойство IDocumentProperties.Count и методы IDocumentProperties.GetPropertyName(int index), .Remove(string name), .Contains(string name) помечены как устаревшие. Вместо них добавлены свойство IDocumentProperties.CountOfCustomProperties и методы IDocumentProperties.GetCustomPropertyName(int index), .RemoveCustomProperty(string name), .ContainsCustomProperty(string name).
#### **Метод INotesSlideManager.RemoveNotesSlide() добавлен**
Метод INotesSlideManager.RemoveNotesSlide() добавлен для удаления заметок слайда некоторого слайда.
#### **Метод Remove добавлен в IComment**
Метод IComment.Remove добавлен для удаления комментария из коллекции.
#### **Метод Remove добавлен в ICommentAuthor**
Метод ICommentAuthor.Remove добавлен для удаления автора комментариев из коллекции.
#### **Методы ClearCustomProperties и ClearBuiltInProperties добавлены в IDocumentProperties**
Метод IDocumentProperties.ClearCustomProperties добавлен для удаления всех пользовательских свойств документа.
Метод IDocumentProperties.ClearBuiltInProperties добавлен для удаления и установки значений по умолчанию для всех встроенных свойств документа (Company, Subject, Author и др.).
#### **Методы RemoveAt, Remove и Clear добавлены в ICommentAuthorCollection**
Метод ICommentAuthorCollection.RemoveAt добавлен для удаления автора по указанному индексу.
Метод ICommentAuthorCollection.Remove добавлен для удаления указанного автора из коллекции.
Метод ICommentAuthorCollection.Clear добавлен для удаления всех элементов из коллекции.
#### **Свойство AppVersion добавлено в IDocumentProperties**
Свойство IDocumentProperties.AppVersion добавлено для получения встроенного свойства документа, представляющего внутренние номера версии, используемые Microsoft во время разработки.
#### **Свойство BlackWhiteMode добавлено в IShape и в Shape**
Свойство BlackWhiteMode добавлено в IShape и в Shape.

Это свойство определяет, как фигура будет отображаться в черно‑белом режиме.

|**Значение**|**Описание**|
| :- | :- |
|Color|Отображать с обычной цветовой схемой|
|Automatic|Отображать с автоматической цветовой схемой|
|Gray|Отображать со серой окраской|
|LightGray|Отображать со светло‑серой окраской|
|InverseGray|Отображать с инверсной серой окраской|
|GrayWhite|Отображать с серой и белой окраской|
|BlackGray|Отображать с черной и серой окраской|
|BlackWhite|Отображать с черно‑белой окраской|
|Black|Отображать только черным цветом|
|White|Отображать белым цветом|
|Hidden|Не отображать|
|NotDefined|означает, что свойство не установлено|
#### **Свойство ISlide.NotesSlideManager добавлено. Свойство ISlide.NotesSlide и метод ISlide.AddNotesSlide() помечены как устаревшие.**
Члены ISlide.NotesSlide и ISlide.AddNotesSlide() помечены как устаревшие. Вместо них используйте новое свойство ISlide.NotesSlideManager.

``` csharp

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.AddNotesSlide(); - устаревший

// notes = slide.NotesSlide; - устаревший

notes = slide.NotesSlideManager.NotesSlide;

notes = slide.NotesSlideManager.AddNotesSlide();

slide.NotesSlideManager.RemoveNotesSlide();

```