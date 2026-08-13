---
title: Konwertowanie prezentacji PowerPoint na dokumenty Word w .NET
linktitle: PowerPoint do Word
type: docs
weight: 110
url: /pl/net/convert-powerpoint-to-word/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- konwertuj slajd
- konwertuj PPT
- konwertuj PPTX
- PowerPoint do Word
- prezentacja do Word
- slajd do Word
- PPT do Word
- PPTX do Word
- PowerPoint do DOCX
- prezentacja do DOCX
- slajd do DOCX
- PPT do DOCX
- PPTX do DOCX
- PowerPoint do DOC
- prezentacja do DOC
- slajd do DOC
- PPT do DOC
- PPTX do DOC
- zapisz PPT jako DOCX
- zapisz PPTX jako DOCX
- eksportuj PPT do DOCX
- eksportuj PPTX do DOCX
- .NET
- C#
- Aspose.Slides
description: "Konwertuj slajdy PowerPoint PPT i PPTX na edytowalne dokumenty Word w C# przy użyciu Aspose.Slides dla .NET, zachowując precyzyjny układ, obrazy i formatowanie."
---
## **Przegląd**

Ten artykuł zapewnia rozwiązanie dla programistów dotyczące konwertowania prezentacji PowerPoint i OpenDocument na dokumenty Word przy użyciu Aspose.Slides dla .NET i Aspose.Words dla .NET. Przewodnik krok po kroku prowadzi Cię przez każdy etap procesu konwersji.

## **Konwertowanie prezentacji na dokument Word**

Postępuj zgodnie z poniższymi instrukcjami, aby przekonwertować prezentację PowerPoint lub OpenDocument na dokument Word:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/) i załaduj plik prezentacji.
2. Utwórz instancje klas [Document](https://reference.aspose.com/words/net/aspose.words/document/) i [DocumentBuilder](https://reference.aspose.com/words/net/aspose.words/documentbuilder/) w celu wygenerowania dokumentu Word.
3. Ustaw rozmiar strony dokumentu Word tak, aby odpowiadał rozmiarowi prezentacji, używając właściwości [DocumentBuilder.PageSetup](https://reference.aspose.com/words/net/aspose.words/documentbuilder/pagesetup/).
4. Ustaw marginesy w dokumencie Word, korzystając z właściwości [DocumentBuilder.PageSetup](https://reference.aspose.com/words/net/aspose.words/documentbuilder/pagesetup/).
5. Przejdź przez wszystkie slajdy prezentacji, używając właściwości [Presentation.Slides](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/slides/pl/).
    - Wygeneruj obraz slajdu, używając metody `GetImage` z interfejsu [ISlide](https://reference.aspose.com/slides/pl/net/aspose.slides/islide/) i zapisz go do strumienia pamięci.
    - Dodaj obraz slajdu do dokumentu Word, używając metody `InsertImage` z klasy [DocumentBuilder](https://reference.aspose.com/words/net/aspose.words/documentbuilder/).
6. Zapisz dokument Word do pliku.

Załóżmy, że mamy prezentację „sample.pptx”, która wygląda następująco:

![Prezentacja PowerPoint](PowerPoint.png)

Poniższy przykład kodu C# demonstruje, jak przekonwertować prezentację PowerPoint na dokument Word:

```cs
using Aspose.Slides;
using Aspose.Words;

// Ładuj plik prezentacji.
using var presentation = new Presentation("sample.pptx");

// Utwórz obiekty Document i DocumentBuilder.
var document = new Document();
var builder = new DocumentBuilder(document);

// Ustaw rozmiar strony w dokumencie Word.
var slideSize = presentation.SlideSize.Size;
builder.PageSetup.PageWidth = slideSize.Width;
builder.PageSetup.PageHeight = slideSize.Height;

// Ustaw marginesy w dokumencie Word.
builder.PageSetup.LeftMargin = 0;
builder.PageSetup.RightMargin = 0;
builder.PageSetup.TopMargin = 0;
builder.PageSetup.BottomMargin = 0;

const float scaleX = 2, scaleY = 2;

// Przejdź przez wszystkie slajdy prezentacji.
foreach (var slide in presentation.Slides)
{
    // Wygeneruj obraz slajdu i zapisz go do strumienia pamięci.
    using var image = slide.GetImage(scaleX, scaleY);
    using var imageStream = new MemoryStream();
    image.Save(imageStream, ImageFormat.Png);

    // Dodaj obraz slajdu do dokumentu Word.
    imageStream.Seek(0, SeekOrigin.Begin);
    builder.InsertImage(imageStream.ToArray(), builder.PageSetup.PageWidth, builder.PageSetup.PageHeight);

    builder.InsertBreak(BreakType.PageBreak);
}

// Zapisz dokument Word do pliku.
document.Save("output.docx");
```

Wynik:

![Dokument Word](Word.png)

{{% alert color="info" %}} 
Wypróbuj nasz [**Internetowy konwerter PPT na Word**](https://products.aspose.app/slides/pl/conversion/ppt-to-word), aby zobaczyć, co możesz zyskać, konwertując prezentacje PowerPoint i OpenDocument na dokumenty Word. 
{{% /alert %}}

## **FAQ**

### Jakie komponenty należy zainstalować, aby konwertować prezentacje PowerPoint i OpenDocument na dokumenty Word?

Wystarczy dodać odpowiednie pakiety NuGet dla [Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET) i [Aspose.Words for .NET](https://www.nuget.org/packages/Aspose.Words/) do swojego projektu C#. Obie biblioteki działają jako samodzielne API i nie ma wymogu instalacji Microsoft Office.

### Czy wszystkie formaty prezentacji PowerPoint i OpenDocument są obsługiwane?

Aspose.Slides for .NET [obsługuje wszystkie formaty prezentacji](/slides/pl/net/supported-file-formats/), w tym PPT, PPTX, ODP i inne popularne typy plików. Dzięki temu możesz pracować z prezentacjami utworzonymi w różnych wersjach Microsoft PowerPoint.