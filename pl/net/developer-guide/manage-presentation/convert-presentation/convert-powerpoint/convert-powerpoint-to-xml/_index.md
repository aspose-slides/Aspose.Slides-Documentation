---
title: Konwertuj prezentacje PowerPoint do XML w .NET
linktitle: PowerPoint do XML
type: docs
weight: 145
url: /pl/net/convert-powerpoint-to-xml/
keywords:
- konwertuj PowerPoint do XML
- konwertuj prezentację do XML
- PPT do XML
- PPTX do XML
- ODP do XML
- Prezentacja PowerPoint XML
- SaveFormat.Xml
- zapisz prezentację jako XML
- eksportuj prezentację do XML
- strumień XML
- .NET
- C#
- Aspose.Slides
description: "Konwertuj prezentacje PowerPoint i OpenDocument do plików lub strumieni PowerPoint XML w języku C# przy użyciu Aspose.Slides for .NET."
---
## **Przegląd**

Aspose.Slides for .NET może konwertować prezentacje PowerPoint do formatu PowerPoint XML Presentation. Wyjście XML jest przydatne, gdy potrzebna jest tekstowa reprezentacja do analizowania struktury prezentacji, rozwiązywania problemów z wygenerowanymi dokumentami, porównywania wyników w testach automatycznych lub integracji z procesem, który wykorzystuje XML zamiast pakietu prezentacji.

Użyj metody [Presentation.Save](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/save/) z wartością `Xml` z wyliczenia [SaveFormat](https://reference.aspose.com/slides/pl/net/aspose.slides.export/saveformat/). Wynik możesz zapisać bezpośrednio do pliku lub do strumienia.

{{% alert color="info" title="Uwaga" %}}

`SaveFormat.Xml` tworzy PowerPoint XML Presentation. Nie wyodrębnia poszczególnych części Office Open XML przechowywanych wewnątrz pakietu PPTX. Jeśli potrzebujesz dokładnych części pakietu PPTX, takich jak `ppt/presentation.xml` lub pojedynczych plików XML slajdów, sprawdź sam pakiet PPTX.

{{% /alert %}}

## **Konwertuj prezentację na plik XML**

Wczytaj prezentację źródłową przy pomocy klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/) i następnie przekaż ścieżkę wyjściową oraz `SaveFormat.Xml` do [Presentation.Save](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/save/). Źródło może być w dowolnym formacie obsługiwanym przy wczytywaniu, takim jak PPT, PPTX lub ODP.

Poniższy przykład konwertuje prezentację PPTX na plik XML:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.xml", SaveFormat.Xml);
```

## **Zapisz wyjście XML do strumienia**

Użyj przeciążenia strumieniowego metody [Presentation.Save](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/save/) gdy XML musi pozostać w pamięci lub zostać przekazane do innego komponentu, takiego jak usługa sieciowa, dostawca storage lub potok przetwarzania XML. Poniższy przykład zapisuje wynik do [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream) i przewija go do początku w celu późniejszego odczytu:

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
using var xmlStream = new MemoryStream();

presentation.Save(xmlStream, SaveFormat.Xml);
xmlStream.Position = 0;

// Przekaż xmlStream do następnego komponentu w procesie.
```

## **Porównaj XML z formatami prezentacji i eksportu**

Wybierz format wyjściowy w zależności od tego, jak wynik będzie używany:

| Format | Wyjście | Typowe zastosowanie |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Prezentacja PowerPoint XML | Analiza struktury, rozwiązywanie problemów, porównywanie wygenerowanego wyniku oraz integracja oparta na XML |
| PPT (`.ppt`) | Starszy plik binarny prezentacji | Kompatybilność ze starszymi procesami PowerPoint |
| PPTX (`.pptx`) | Pakiet Office Open XML zawierający wiele części | Standardowa edycja PowerPoint i wymiana prezentacji |
| PDF lub TIFF | Strony o stałym układzie lub obraz wielostronicowy | Przeglądanie, drukowanie i archiwizacja |
| PNG, JPEG lub SVG | Renderowana reprezentacja pojedynczego slajdu | Miniatury, podglądy i zasoby graficzne |
| HTML lub HTML5 | Wyjście prezentacji przeznaczone dla sieci | Przeglądanie w przeglądarce i publikowanie w sieci |

W odróżnieniu od PPT i PPTX, wyjście XML jest przeznaczone głównie do inspekcji i procesów opartych na danych. W odróżnieniu od PDF, TIFF, HTML oraz formatów obrazów slajdów, reprezentuje dane prezentacji, a nie renderuje slajdów jako strony lub zasoby wizualne. Tabela [supported file formats](/slides/pl/net/supported-file-formats/) wymienia PowerPoint XML Presentation jako format wyłącznie do zapisu, więc nie używaj go, gdy proces wymaga wczytania wyeksportowanego pliku z powrotem do Aspose.Slides w celu dalszej edycji.

## **FAQ**

**Czy `SaveFormat.Xml` to to samo co zapisywanie pliku PPTX?**

Nie. PPTX jest pakietem zawierającym wiele części Office Open XML, natomiast `SaveFormat.Xml` tworzy plik PowerPoint XML Presentation.

**Czy mogę zapisać wyjście XML bez tworzenia pliku na dysku?**

Tak. Przekaż zapisywalny strumień do [Presentation.Save](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/save/). Na przykład użyj [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream) do przetwarzania w pamięci.

**Czy Aspose.Slides może ponownie wczytać wyeksportowany plik XML?**

Nie. PowerPoint XML Presentation jest obecnie obsługiwany tylko podczas zapisywania, a nie wczytywania. Użyj PPTX lub innego obsługiwanego formatu prezentacji, gdy wymagana jest edycja w obu kierunkach.

**Czy konwersja do XML renderuje każdy slajd jako stronę lub obraz?**

Nie. Konwersja do XML zapisuje strukturalne dane prezentacji. Użyj PDF lub TIFF dla wyjścia ukierunkowanego na strony, albo PNG, JPEG i SVG dla pojedynczych obrazów slajdów.