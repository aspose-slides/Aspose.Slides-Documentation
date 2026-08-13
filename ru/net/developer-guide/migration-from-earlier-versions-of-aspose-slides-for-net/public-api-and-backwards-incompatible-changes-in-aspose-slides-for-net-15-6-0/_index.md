---
title: Публичный API и несовместимые назад изменения в Aspose.Slides для .NET 15.6.0
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
description: "Обзор обновлений публичного API и разрывных изменений в Aspose.Slides для .NET, позволяющий плавно мигрировать ваши решения презентаций PowerPoint PPT, PPTX и ODP."
---
{{% alert color="info" %}} 
Эта страница содержит список всех [добавленных](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) или [удалённых](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) классов, методов, свойств и т.д., а также других изменений, внесённых в API Aspose.Slides for .NET 15.6.0.
{{% /alert %}} 
## **Изменения публичного API**
#### **Изменена сигнатура конструктора DataLabel**
Сигнатура конструктора DataLabel изменена: было: DataLabel.#ctor(Aspose.Slides.Charts.IChartSeries); теперь: DataLabel.#ctor(Aspose.Slides.Charts.IChartDataPoint).
#### **Члены IDocumentProperties.Count, .GetPropertyName(int index), .Remove(string name), .Contains(string name) помечены как устаревшие, и вместо них введены их заменители.**
Свойство IDocumentProperties.Count и методы IDocumentProperties.GetPropertyName(int index), .Remove(string name), .Contains(string name) помечены как устаревшие. Вместо них добавлены свойство IDocumentProperties.CountOfCustomProperties и методы IDocumentProperties.GetCustomPropertyName(int index), .RemoveCustomProperty(string name), .ContainsCustomProperty(string name).
#### **Добавлен метод INotesSlideManager.RemoveNotesSlide()**
Метод INotesSlideManager.RemoveNotesSlide() добавлен для удаления слайда заметок у заданного слайда.
#### **В IComment добавлен метод Remove**
Метод IComment.Remove добавлен для удаления комментария из коллекции.
#### **В ICommentAuthor добавлен метод Remove**
Метод ICommentAuthor.Remove добавлен для удаления автора комментариев из коллекции.
#### **В IDocumentProperties добавлены методы ClearCustomProperties и ClearBuiltInProperties**
Метод IDocumentProperties.ClearCustomProperties добавлен для удаления всех пользовательских свойств документа.
Метод IDocumentProperties.ClearBuiltInProperties добавлен для удаления и установки значений по умолчанию для всех встроенных свойств документа (Company, Subject, Author и т.п.).
#### **В ICommentAuthorCollection добавлены методы RemoveAt, Remove и Clear**
Метод ICommentAuthorCollection.RemoveAt добавлен для удаления автора по указанному индексу.
Метод ICommentAuthorCollection.Remove добавлен для удаления указанного автора из коллекции.
Метод ICommentAuthorCollection.Clear добавлен для удаления всех элементов из коллекции.
#### **В IDocumentProperties добавлено свойство AppVersion**
Свойство IDocumentProperties.AppVersion добавлено для получения встроенного свойства документа, представляющего внутренние номера версий, используемые Microsoft во время разработки.
#### **В IShape и Shape добавлено свойство BlackWhiteMode**
Свойство BlackWhiteMode добавлено в IShape и Shape.
Это свойство определяет, как фигура будет отображаться в режиме черно‑белого.

|**Значение** |**Описание** |
| :- | :- |
|Color|Отображать с обычными цветами |
|Automatic|Отображать с автоматическим подбором цветов |
|Gray|Отображать в оттенках серого |
|LightGray|Отображать в светло‑сером |
|InverseGray|Отображать в инверсном сером |
|GrayWhite|Отображать в сером и белом |
|BlackGray|Отображать в черном и сером |
|BlackWhite|Отображать в черном и белом |
|Black|Отображать только в чёрном |
|White|Отображать в белом |
|Hidden|Не отображать |
|NotDefined|означает, что свойство не установлено|
#### **В ISlide добавлено свойство NotesSlideManager. Свойство ISlide.NotesSlide и метод ISlide.AddNotesSlide() помечены как устаревшие.**
Члены ISlide.NotesSlide и ISlide.AddNotesSlide() помечены как устаревшие. Вместо них используйте новое свойство ISlide.NotesSlideManager.
``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("sample.pptx"))
{
    ISlide slide = pres.Slides[0];

    INotesSlide notes;

    // notes = slide.AddNotesSlide(); - устаревший
    // notes = slide.NotesSlide; - устаревший

    notes = slide.NotesSlideManager.NotesSlide;
    notes = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.RemoveNotesSlide();
}
```