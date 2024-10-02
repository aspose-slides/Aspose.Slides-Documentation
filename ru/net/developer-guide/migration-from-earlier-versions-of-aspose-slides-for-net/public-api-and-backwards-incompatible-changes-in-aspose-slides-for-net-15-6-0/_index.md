---
title: Публичный API и изменения, несовместимые с предыдущими версиями в Aspose.Slides для .NET 15.6.0
type: docs
weight: 170
url: /ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/
---

{{% alert color="primary" %}} 

Эта страница содержит список всех [добавленных](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) или [удаленных](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) классов, методов, свойств и других изменений, представленных в API Aspose.Slides для .NET 15.6.0.

{{% /alert %}} 
## **Изменения в публичном API**
#### **Подпись конструктора DataLabel была изменена**
Подпись конструктора DataLabel была изменена:
было: DataLabel.#ctor(Aspose.Slides.Charts.IChartSeries);
стало: DataLabel.#ctor(Aspose.Slides.Charts.IChartDataPoint).
#### **Члены IDocumentProperties.Count, .GetPropertyName(int index), .Remove(string name), .Contains(string name) были помечены как устаревшие, и вместо них были предложены их замены.**
Свойство IDocumentProperties.Count и методы IDocumentProperties.GetPropertyName(int index), .Remove(string name), .Contains(string name) были помечены как устаревшие. Вместо них были добавлены свойства IDocumentProperties.CountOfCustomProperties и методы IDocumentProperties.GetCustomPropertyName(int index), .RemoveCustomProperty(string name), .ContainsCustomProperty(string name).
#### **Метод INotesSlideManager.RemoveNotesSlide() был добавлен**
Метод INotesSlideManager.RemoveNotesSlide() был добавлен для удаления заметок с определенного слайда.
#### **Метод Remove был добавлен в IComment**
Метод IComment.Remove был добавлен для удаления комментария из коллекции.
#### **Метод Remove был добавлен в ICommentAuthor**
Метод ICommentAuthor.Remove был добавлен для удаления автора комментариев из коллекции.
#### **Методы ClearCustomProperties и ClearBuiltInProperties были добавлены в IDocumentProperties**
Метод IDocumentProperties.ClearCustomProperties был добавлен для удаления всех пользовательских свойств документа.
Метод IDocumentProperties.ClearBuiltInProperties был добавлен для удаления и установки значений по умолчанию для всех встроенных свойств документа (Компания, Тема, Автор и т.д.).
#### **Методы RemoveAt, Remove и Clear были добавлены в ICommentAuthorCollection**
Метод ICommentAuthorCollection.RemoveAt был добавлен для удаления автора по указанному индексу.
Метод ICommentAuthorCollection.Remove был добавлен для удаления указанного автора из коллекции.
Метод ICommentAuthorCollection.Clear был добавлен для удаления всех элементов из коллекции.
#### **Свойство AppVersion было добавлено в IDocumentProperties**
Свойство IDocumentProperties.AppVersion было добавлено для получения встроенного свойства документа, представляющего внутренние номера версий, используемые Microsoft в процессе разработки.
#### **Свойство BlackWhiteMode было добавлено в IShape и в Shape**
Свойство BlackWhiteMode было добавлено в IShape и в Shape.

Это свойство определяет, как форма будет отображаться в черно-белом режиме.

|**Значение** |**Значение** |
| :- | :- |
|Color |Отображать с обычной раскраской |
|Automatic |Отображать с автоматической раскраской |
|Gray |Отображать с серой раскраской |
|LightGray |Отображать с светло-серой раскраской |
|InverseGray |Отображать с инверсной серой раскраской |
|GrayWhite |Отображать с серой и белой раскраской |
|BlackGray |Отображать с черной и серой раскраской |
|BlackWhite |Отображать с черной и белой раскраской |
|Black |Отображать только черным цветом |
|White |Отображать белым цветом |
|Hidden |Не отображать |
|NotDefined|означает, что свойство не установлено|
#### **Свойство ISlide.NotesSlideManager было добавлено. Свойство ISlide.NotesSlide и метод ISlide.AddNotesSlide() были помечены как устаревшие.**
Члены ISlide.NotesSlide, ISlide.AddNotesSlide() были помечены как устаревшие. Вместо этого используйте новое свойство ISlide.NotesSlideManager.

``` csharp

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.AddNotesSlide(); - устарело

// notes = slide.NotesSlide; - устарело

notes = slide.NotesSlideManager.NotesSlide;

notes = slide.NotesSlideManager.AddNotesSlide();

slide.NotesSlideManager.RemoveNotesSlide();

``` 