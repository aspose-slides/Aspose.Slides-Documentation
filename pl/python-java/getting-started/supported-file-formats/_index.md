---
title: Obsługiwane formaty plików
type: docs
weight: 30
url: /pl/python-java/supported-file-formats/
keywords:
- obsługiwane formaty plików
- formaty prezentacji
- PowerPoint
- OpenDocument
- PPT
- PPTX
- ODP
- PDF
- HTML
- obrazy slajdów
- Python
- Aspose.Slides for Python via Java
description: "Poznaj formaty prezentacji, dokumentów, stron internetowych i obrazów, które Aspose.Slides for Python via Java może ładować, importować, zapisywać i eksportować."
---
## **Przegląd**

Aspose.Slides dla Pythona poprzez Java odczytuje i zapisuje prezentacje PowerPoint oraz OpenDocument. Potrafi także importować treść PDF i HTML do slajdów oraz eksportować prezentacje lub pojedyncze slajdy do formatów dokumentów, stron internetowych i obrazów.

Poniższa tabela rozróżnia ładowanie prezentacji, import treści i renderowanie slajdów. Aby uzyskać przegląd możliwości edycji i renderowania, zobacz [Features Overview](/slides/pl/python-java/features-overview/).

## **Obsługiwane wersje Microsoft PowerPoint**

- Microsoft PowerPoint 97
- Microsoft PowerPoint 2000
- Microsoft PowerPoint XP
- Microsoft PowerPoint 2003
- Microsoft PowerPoint 2007
- Microsoft PowerPoint 2010
- Microsoft PowerPoint 2013
- Microsoft PowerPoint 2016
- Microsoft PowerPoint 2019
- Microsoft PowerPoint dla Mac
- PowerPoint dla Microsoft 365 (dawniej Office 365)


## **Obsługiwane formaty plików**

Poniższa tabela wymienia obsługiwane formaty wejściowe i wyjściowe. **Ładowanie / Import** obejmuje otwieranie plików prezentacji oraz importowanie treści PDF lub HTML. **Zapis / Eksport** obejmuje zapisywanie prezentacji i renderowanie slajdów do obrazów. Myślnik oznacza, że odpowiednia operacja nie jest obsługiwana jako konwersja prezentacji.

|**Format**|**Opis**|**Ładowanie / Import**|**Zapis / Eksport**|**Uwagi**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|Prezentacja PowerPoint 97-2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POT](https://docs.fileformat.com/presentation/pot/)|Szablon PowerPoint 97-2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPS](https://docs.fileformat.com/presentation/pps/)|Pokaz PowerPoint 97-2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|Prezentacja PowerPoint|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POTX](https://docs.fileformat.com/presentation/potx/)|Szablon PowerPoint|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPSX](https://docs.fileformat.com/presentation/ppsx/)|Pokaz PowerPoint|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|Prezentacja PowerPoint z obsługą makr|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|Pokaz PowerPoint z obsługą makr|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POTM](https://docs.fileformat.com/presentation/potm/)|Szablon PowerPoint z obsługą makr|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[ODP](https://docs.fileformat.com/presentation/odp/)|Prezentacja OpenDocument|{{< emoticons/tick >}}|{{< emoticons/tick >}}|Pakowany format OpenDocument.|
|FODP|Prezentacja OpenDocument w formacie płaskiego XML|{{< emoticons/tick >}}|{{< emoticons/tick >}}|Przechowuje prezentację jako pojedynczy dokument XML.|
|[OTP](https://docs.fileformat.com/presentation/otp/)|Szablon prezentacji OpenDocument|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[TIFF](https://docs.fileformat.com/image/tiff/)|Format pliku obrazu TIFF|—|{{< emoticons/tick >}}|Obsługuje wyjście wielostronicowe.|
|[EMF](https://docs.fileformat.com/image/emf/)|Rozszerzony Metafile|—|{{< emoticons/tick >}}|Eksportuje pojedyncze slajdy jako obrazy wektorowe.|
|[PDF](https://docs.fileformat.com/pdf/)|Format Portable Document|Import|{{< emoticons/tick >}}|Importuje strony PDF jako slajdy; eksportuje prezentacje do PDF.|
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|Specyfikacja XML Paper|—|{{< emoticons/tick >}}|Wyjście w stałym układzie dokumentu.|
|[JPEG](https://docs.fileformat.com/image/jpeg/)|Obraz JPEG|—|{{< emoticons/tick >}}|Renderuje pojedyncze slajdy jako obrazy rastrowe.|
|[PNG](https://docs.fileformat.com/image/png/)|Grafika PNG|—|{{< emoticons/tick >}}|Renderuje pojedyncze slajdy jako obrazy rastrowe.|
|[GIF](https://docs.fileformat.com/image/gif/)|Format wymiany grafiki GIF|—|{{< emoticons/tick >}}|Wyjście obrazu.|
|[BMP](https://docs.fileformat.com/image/bmp/)|Obraz bitmapowy BMP|—|{{< emoticons/tick >}}|Renderuje pojedyncze slajdy jako obrazy rastrowe.|
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Grafika wektorowa SVG|—|{{< emoticons/tick >}}|Eksportuje pojedyncze slajdy jako obrazy wektorowe.|
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Mały format sieciowy SWF|—|{{< emoticons/tick >}}|Wyjście Flash.|
|[HTML](https://docs.fileformat.com/web/html/)|Język znaczników hipertekstowych HTML|Import|{{< emoticons/tick >}}|Importuje treść HTML jako slajdy; obsługuje eksport do HTML i HTML5.|
|[XAML](https://docs.fileformat.com/web/xaml/)|Rozszerzalny język znaczników aplikacji XAML|—|{{< emoticons/tick >}}|Eksportuje zawartość prezentacji jako XAML.|
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown|—|{{< emoticons/tick >}}|Eksportuje zawartość prezentacji do Markdown.|
|[XML](https://docs.fileformat.com/web/xml/)|Prezentacja PowerPoint XML|—|{{< emoticons/tick >}}|Wyjście XML specyficzne dla PowerPoint, nie dowolny XML.|

## **Uwagi dotyczące importu i eksportu**

- **Import PDF i HTML:** Użyj [SlideCollection.addFromPdf](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidecollection/#addfrompdf) lub [SlideCollection.addFromHtml](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidecollection/#addfromhtml) aby utworzyć slajdy z treści źródłowej i dodać je do prezentacji.
- **Wyjście prezentacji:** [SaveFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/saveformat/) wymienia dostępne formaty zapisu prezentacji, w tym osobne opcje eksportu HTML i HTML5.
- **Wyjście obrazu:** Eksportowanie slajdu do obrazu tworzy jego wizualną reprezentację. Kolumna wejściowa nie opisuje, czy obraz może zostać wstawiony do prezentacji.

## **FAQ**

**Czy mogę konwertować prezentację PPT na PPTX lub ODP?**

Tak. PPT jest obsługiwany jako format wejściowy, a zarówno PPTX, jak i ODP jako formaty wyjściowe. Wynik konwersji zależy od funkcji dostępnych w docelowym formacie.

**Czy import PDF lub HTML otwiera źródło jako plik PowerPoint?**

Nie. Import tworzy slajdy z stron PDF lub treści HTML. Następnie można zapisać powstałą prezentację w obsługiwanym formacie prezentacji.

**Czy mogę wczytać wyeksportowany PNG lub SVG jako edytowalną prezentację?**

Nie. Te eksporty przedstawiają jedynie wygląd slajdu. Zachowaj oryginalną prezentację, gdy potrzebujesz później edytować tekst, kształty, wykresy i inne obiekty.