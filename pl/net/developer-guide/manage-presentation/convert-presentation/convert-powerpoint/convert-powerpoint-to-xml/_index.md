---
title: Konwertowanie prezentacji PowerPoint do XML w .NET
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
description: "Konwertuj prezentacje PowerPoint i OpenDocument do plików PowerPoint XML lub strumieni w C# przy użyciu Aspose.Slides dla .NET."
---
## **Przegląd**

Aspose.Slides for .NET może konwertować prezentacje PowerPoint do formatu PowerPoint XML Presentation. Wyjście XML jest przydatne, gdy potrzebujesz tekstowej reprezentacji do przeglądania struktury prezentacji, rozwiązywania problemów z wygenerowanymi dokumentami, porównywania wyników w testach automatycznych lub integrowania z przepływem pracy, który przetwarza XML zamiast pakietu prezentacji.

Użyj metody [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) z wartością `Xml` z wyliczenia [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/). Wynik możesz zapisać bezpośrednio do pliku lub strumienia.

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` tworzy prezentację PowerPoint XML. Nie wydobywa pojedynczych części Office Open XML przechowywanych w pakiecie PPTX. Jeśli potrzebujesz dokładnych części pakietu PPTX, takich jak `ppt/presentation.xml` lub poszczególnych plików XML slajdów, sprawdź sam pakiet PPTX.
{{% /alert %}}

## **Konwertowanie prezentacji na plik XML**

Wczytaj źródłową prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), a następnie przekaż ścieżkę wyjściową i `SaveFormat.Xml` do [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). Źródło może być w dowolnym formacie prezentacji obsługiwanym przy wczytywaniu, takim jak PPT, PPTX lub ODP.

Poniższy przykład konwertuje prezentację PPTX na plik XML:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.xml", SaveFormat.Xml);
```

## **Zapis wyjścia XML do strumienia**

Użyj przeciążenia strumieniowego metody [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/), gdy XML musi pozostać w pamięci lub być przekazany do innego komponentu, takiego jak usługa sieciowa, dostawca pamięci masowej lub potok przetwarzania XML. Poniższy przykład zapisuje wynik do [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream?view=net-10.0) i przewija go wstecz w celu późniejszego odczytu:

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
using var xmlStream = new MemoryStream();

presentation.Save(xmlStream, SaveFormat.Xml);
xmlStream.Position = 0;

// Przekaż xmlStream do kolejnego komponentu w przepływie pracy.
```

## **Porównanie XML z formatami prezentacji i eksportu**

Wybierz format wyjściowy w zależności od tego, jak wynik będzie używany:

| Format | Wyjście | Typowe zastosowanie |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Prezentacja PowerPoint XML | Przeglądanie struktury, rozwiązywanie problemów, porównywanie wygenerowanego wyjścia oraz integracja oparta na XML |
| PPT (`.ppt`) | Starszy binarny plik prezentacji | Zgodność ze starszymi przepływami pracy PowerPoint |
| PPTX (`.pptx`) | Pakiet Office Open XML zawierający wiele części | Standardowa edycja PowerPoint i wymiana prezentacji |
| PDF lub TIFF | Strony o stałym układzie lub obrazy TIFF | Przeglądanie, drukowanie i archiwizacja |
| PNG, JPEG lub SVG | Renderowane przedstawienie pojedynczego slajdu | Miniatury, podglądy i zasoby graficzne |
| HTML lub HTML5 | Wyjście prezentacji przeznaczone dla sieci | Wyświetlanie w przeglądarce i publikowanie w sieci |

W przeciwieństwie do PPT i PPTX, wyjście XML jest przede wszystkim przeznaczone do inspekcji i przepływów pracy opartych na danych. W przeciwieństwie do PDF, TIFF, HTML oraz formatów obrazów slajdów, reprezentuje dane prezentacji, a nie renderuje slajdów jako stron lub zasobów wizualnych. Tabela [obsługiwane formaty plików](/slides/pl/net/supported-file-formats/) wymienia wszystkie formaty, które Aspose.Slides może wczytywać, importować, zapisywać lub renderować.

## **FAQ**

**Czy `SaveFormat.Xml` jest tym samym co zapisywanie pliku PPTX?**

Nie. PPTX jest pakietem zawierającym wiele części Office Open XML, podczas gdy `SaveFormat.Xml` tworzy plik prezentacji PowerPoint XML.

**Czy mogę zapisać wyjście XML bez tworzenia pliku na dysku?**

Tak. Przekaż zapisywalny strumień do [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). Na przykład użyj [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream?view=net-10.0) do przetwarzania w pamięci.

**Czy Aspose.Slides może ponownie wczytać wyeksportowany plik XML?**

Tak. Przekaż plik XML lub strumień do konstruktora [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/). [Presentation.SourceFormat](https://reference.aspose.com/slides/net/aspose.slides/presentation/sourceformat/) zwraca wtedy `SourceFormat.Xml`. [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) zwraca `LoadFormat.Unknown` dla tego formatu, więc nie używaj go do decydowania, czy plik XML można otworzyć.

**Czy konwersja XML renderuje każdy slajd jako stronę lub obraz?**

Nie. Konwersja XML zapisuje ustrukturyzowane dane prezentacji. Użyj PDF lub TIFF do wyjścia ukierunkowanego na strony, lub PNG, JPEG i SVG do obrazów pojedynczych slajdów.