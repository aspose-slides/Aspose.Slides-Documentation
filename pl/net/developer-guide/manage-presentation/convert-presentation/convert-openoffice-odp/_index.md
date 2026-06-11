---
title: Przekształcanie prezentacji OpenDocument w .NET
linktitle: Przekształcanie OpenDocument
type: docs
weight: 10
url: /pl/net/convert-openoffice-odp/
keywords:
- konwertuj ODP
- ODP do obrazu
- ODP do GIF
- ODP do HTML
- ODP do JPG
- ODP do MD
- ODP do PDF
- ODP do PNG
- ODP do PPT
- ODP do PPTX
- ODP do TIFF
- ODP do wideo
- ODP do Word
- ODP do XPS
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides dla .NET umożliwia łatwe konwertowanie ODP do PDF, HTML i formatów obrazu. Zwiększ wydajność swoich aplikacji .NET dzięki szybkiej i dokładnej konwersji prezentacji."
---
## **Wprowadzenie**

[**Aspose.Slides API**](https://products.aspose.com/slides/pl/net/) umożliwia konwertowanie prezentacji OpenDocument (ODP) do wielu formatów (HTML, PDF, TIFF, SWF, XPS, itp.). API używane do konwertowania plików ODP na inne formaty dokumentów jest takie samo jak używane do operacji konwersji PowerPoint (PPT i PPTX).

Na przykład, jeśli potrzebujesz przekonwertować prezentację ODP na PDF, możesz to zrobić w następujący sposób:

```cs
using (Presentation presentation = new Presentation("presentation.odp"))
{
    presentation.Save("presentation.pdf", SaveFormat.Pdf);
}
```

## **Prezentacja OpenDocument w różnych aplikacjach**

Kiedy plik prezentacji OpenDocument (ODP) jest otwierany w programie PowerPoint, może nie zachować oryginalnego formatowania z aplikacji, w której został utworzony. Dzieje się tak, ponieważ aplikacja OpenDocument i aplikacja PowerPoint oferują różne funkcje i zachowania renderowania.

Oto niektóre z różnic:

- W programie PowerPoint tabele są zazwyczaj renderowane jako ostatnie i mogą nakładać się na inne kształty, niezależnie od ich kolejności na slajdzie ODP.
- Wypełnienie obrazem dla tabel ODP nie jest obsługiwane w programie PowerPoint.
- Pionowa rotacja tekstu (270°, układane) oraz wyrównanie rozproszone nie są obsługiwane w LibreOffice/OpenOffice Impress.
- Wypełnienie obrazem, wypełnienie gradientem i wypełnienie wzorem dla tekstu nie są obsługiwane w LibreOffice/OpenOffice Impress.

MS PowerPoint i LibreOffice/OpenOffice Impress również obsługują listy inaczej. Plik ODP utworzony w PowerPoint może nie wyświetlać się poprawnie w LibreOffice/OpenOffice Impress i odwrotnie.

Obraz poniżej pokazuje, jak lista wygląda po utworzeniu w LibreOffice Impress:

![przykład listy ODP](odp-list-example.png)

Aspose.Slides zapisuje listy ODP w sposób zapewniający ich prawidłowe wyświetlanie w LibreOffice/OpenOffice Impress.

[Dowiedz się więcej o formacie OpenDocument i programie PowerPoint](https://support.microsoft.com/en-us/office/use-powerpoint-to-save-or-open-a-presentation-in-the-opendocument-presentation-odp-format-94805e84-1b09-4c98-a8b5-0da2a52242a0).

## **FAQ**

**Co jeśli formatowanie mojego pliku ODP zmieni się po konwersji?**

ODP i PowerPoint używają różnych modeli prezentacji, a niektóre elementy — takie jak tabele, niestandardowe czcionki czy style wypełnień — mogą nie wyglądać dokładnie tak samo. Zaleca się przejrzenie wyniku i w razie potrzeby dostosowanie układu lub formatowania w kodzie.

**Czy potrzebuję zainstalowanego OpenOffice lub LibreOffice, aby używać konwersji ODP?**

Nie, Aspose.Slides dla .NET jest samodzielną biblioteką i nie wymaga instalacji OpenOffice ani LibreOffice w systemie.

**Czy mogę dostosować format wyjściowy podczas konwersji ODP (np. ustawić opcje PDF)?**

Tak, Aspose.Slides udostępnia rozbudowane opcje dostosowywania wyjścia. Na przykład przy zapisywaniu do PDF możesz kontrolować kompresję, jakość obrazów, renderowanie tekstu i wiele innych poprzez klasę [PdfOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/pdfoptions/).

**Czy Aspose.Slides jest odpowiedni do przetwarzania ODP po stronie serwera lub w chmurze?**

Absolutnie. Aspose.Slides dla .NET został zaprojektowany do pracy zarówno w środowiskach desktopowych, jak i serwerowych, w tym w platformach chmurowych takich jak Azure, AWS i kontenery Docker, bez żadnych zależności interfejsu użytkownika.