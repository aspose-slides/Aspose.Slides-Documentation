---
title: Obsługiwane formaty plików
type: docs
weight: 20
url: /pl/cpp/supported-file-formats/
keywords:
- format pliku
- obsługiwany format
- PPT
- POT
- PPS
- PPTX
- POTX
- PPSX
- PPTM
- PPSM
- POTM
- ODP
- FODP
- OTP
- TIFF
- EMF
- PDF
- XPS
- JPEG
- PNG
- GIF
- BMP
- SVG
- SWF
- HTML
- XAML
- MD
- XML
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Odkryj wszystkie formaty plików, które Aspose.Slides dla C++ może otwierać, zapisywać i konwertować — w tym PPT, PPTX i ODP — wraz z przejrzystymi notatkami o obsłudze importu/eksportu."
---
## **Przegląd**

Aspose.Slides obsługuje pliki prezentacji od Microsoft PowerPoint 97 aż po Office 365, w tym Microsoft PowerPoint dla Mac. Ten artykuł wymienia wersje PowerPoint obsługiwane przez bibliotekę oraz zawiera tabelę formatów plików, które mogą być wczytywane, zapisywane lub oba.

Artykuł zawiera również odpowiedzi na często zadawane pytania dotyczące zgodności PDF, osadzania czcionek, plików chronionych hasłem, czcionek niestandardowych, mechanizmów zastępowania czcionek oraz opcji eksportu do XPS.

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
- Microsoft PowerPoint dla MAC
- Office 365

## **Obsługiwane formaty plików**
Ta tabela zawiera formaty plików, które Aspose.Slides dla C++ może wczytywać i zapisywać:

|**Format**|**Opis**|**Wczytywanie**|**Zapisywanie**|**Uwagi**|
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
|[ODP/FODP](https://docs.fileformat.com/presentation/odp/)|Prezentacja OpenDocument|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[OTP](https://docs.fileformat.com/presentation/otp/)|Szablon prezentacji OpenDocument|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[TIFF](https://docs.fileformat.com/image/tiff/)|Tag Image File Format| |{{< emoticons/tick >}}| |
|[EMF](https://docs.fileformat.com/image/emf/)|Enhanced Metafile Format| |{{< emoticons/tick >}}| |
|[PDF](https://docs.fileformat.com/pdf/)|Portable Document Format|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|XML Paper Specification| |{{< emoticons/tick >}}| |
|[JPEG](https://docs.fileformat.com/image/jpeg/)|Joint Photographic Experts Group| |{{< emoticons/tick >}}| |
|[PNG](https://docs.fileformat.com/image/png/)|Portable Network Graphics| |{{< emoticons/tick >}}| |
|[GIF](https://docs.fileformat.com/image/gif/)|Graphics Interchange Format| |{{< emoticons/tick >}}| |
|[BMP](https://docs.fileformat.com/image/bmp/)|Device Independent Bitmap| |{{< emoticons/tick >}}| |
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Scalable Vector Graphics| |{{< emoticons/tick >}}| |
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Small Web Format| |{{< emoticons/tick >}}| |
|[HTML](https://docs.fileformat.com/web/html/)|Hypertext Markup Language|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[XAML](https://docs.fileformat.com/web/xaml/)|Extensible Application Markup Language| |{{< emoticons/tick >}}| |
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown| |{{< emoticons/tick >}}| |
|[XML](https://docs.fileformat.com/web/xml/)|Prezentacja PowerPoint XML| |{{< emoticons/tick >}}| |

## **FAQ**

**Czy mogę zapisać prezentacje do formatu PDF spełniające standardy archiwizacji i dostępności (PDF/A i PDF/UA)?**

Tak. Aspose.Slides obsługuje eksport do PDF z poziomami zgodności takimi jak PDF/A-2a, PDF/A-2b, PDF/A-2u, PDF/A-3a, PDF/A-3b oraz PDF/UA poprzez ustawienie [zgodność](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/pdfoptions/set_compliance/) w [opcjach eksportu PDF](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/pdfoptions/).

**Czy biblioteka obsługuje osadzanie czcionek przy eksporcie do PDF, z precyzyjną kontrolą tego, co jest osadzane?**

Tak. Możesz kontrolować, czy czcionki są w pełni osadzone czy podzestawiane (tylko użyte glify), określić, jak traktowane są popularne czcionki systemowe, oraz skonfigurować zachowanie dla tekstu ASCII poprzez [opcje eksportu PDF](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/pdfoptions/).

**Czy mogę wykryć, czy plik jest zabezpieczony hasłem przed jego załadowaniem?**

Tak. Korzystając z [API inspekcji opartego na fabryce](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentationfactory/), możesz zapytać plik prezentacji o to, czy jest chroniony hasłem, nie otwierając go w pełni.

**Czy istnieją mechanizmy zastępowania czcionek i obsługa czcionek niestandardowych?**

Tak. Biblioteka obsługuje [ładowanie](/slides/pl/cpp/custom-font/) i [osadzanie](/slides/pl/cpp/embedded-font/) czcionek niestandardowych oraz zapewnia [zasady zastępowania czcionek](/slides/pl/cpp/fallback-font/), aby uniknąć brakujących glifów podczas renderowania i konwersji.

**Czy mogę wyeksportować slajdy do XPS i czy istnieją opcje dostosowania wyjścia XPS?**

Tak. [Eksport do XPS](/slides/pl/cpp/convert-powerpoint-to-xps/) jest obsługiwany, a odpowiednie [opcje zapisu](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/xpsoptions/) pozwalają kontrolować jakość oraz zawartość dokumentu XPS.