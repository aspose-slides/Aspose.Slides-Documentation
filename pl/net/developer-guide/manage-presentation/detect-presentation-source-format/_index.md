---
title: Określ pierwotny format prezentacji w .NET
linktitle: Format źródła
type: docs
weight: 35
url: /pl/net/detect-presentation-source-format/
keywords:
- format źródła
- wykryj format prezentacji
- PowerPoint
- OpenDocument
- prezentacja
- PPT
- PPTX
- C#
- .NET
- Aspose.Slides
description: "Odczytaj pierwotny format załadowanej prezentacji w C# przy użyciu Aspose.Slides dla .NET, porównaj API wykrywania i obsługuj pliki, strumienie oraz starsze formaty."
---
## **Przegląd**

Po załadowaniu prezentacji odczytaj tylko do odczytu właściwość [Presentation.SourceFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/sourceformat/), aby określić jej pierwotny format. Właściwość jest również dostępna przez [IPresentation.SourceFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/ipresentation/sourceformat/). Użyj jej, gdy dalsze przetwarzanie zależy od formatu, z którego załadowano bieżącą instancję.

Format źródłowy różni się od [SaveFormat](https://reference.aspose.com/slides/pl/net/aspose.slides.export/saveformat/) wybranego dla pliku wyjściowego. Zapis do innego formatu nie zmienia formatu źródłowego istniejącej instancji.

## **Odczytanie formatu źródłowego pliku**

Ten przykład wymaga istniejącego pliku `sample.pptx`. Ładuje plik i wybiera politykę przetwarzania aplikacji przy użyciu [Presentation.SourceFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/sourceformat/), zamiast nazwy pliku. Zmień ścieżkę wejściową, aby wypróbować inne formaty. Przykład wypisuje wybraną politykę; zamień komunikaty na własną logikę aplikacji.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

switch (presentation.SourceFormat)
{
    case SourceFormat.Ppt:
    case SourceFormat.Pps:
    case SourceFormat.Pot:
        Console.WriteLine("Use the legacy PowerPoint processing policy.");
        break;
    case SourceFormat.Pptx:
        Console.WriteLine("Use the standard PPTX processing policy.");
        break;
    default:
        Console.WriteLine($"Use the general policy for {presentation.SourceFormat}.");
        break;
}
```

## **Rozpoznanie obsługiwanych wartości**

Wyliczenie [SourceFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/sourceformat/) rozróżnia następujące formaty prezentacji. Poniższe rozszerzenia są konwencjonalnymi rozszerzeniami, a nie odtworzeniem oryginalnej nazwy pliku.

| Wartość SourceFormat | Rozszerzenie | Format |
| --- | --- | --- |
| `Ppt` | `.ppt` | Prezentacja PowerPoint 97–2003 |
| `Pptx` | `.pptx` | Prezentacja Office Open XML |
| `Pptm` | `.pptm` | Prezentacja Office Open XML z włączonymi makrami |
| `Pps` | `.pps` | Pokaz slajdów PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | Pokaz slajdów Office Open XML |
| `Ppsm` | `.ppsm` | Pokaz slajdów Office Open XML z włączonymi makrami |
| `Pot` | `.pot` | Szablon PowerPoint 97–2003 |
| `Potx` | `.potx` | Szablon Office Open XML |
| `Potm` | `.potm` | Szablon Office Open XML z włączonymi makrami |
| `Odp` | `.odp` | Prezentacja OpenDocument |
| `Otp` | `.otp` | Szablon prezentacji OpenDocument |
| `Fodp` | `.fodp` | Prezentacja Flat XML ODF |
| `Xml` | `.xml` | Prezentacja PowerPoint XML |

## **Odczytanie formatu źródłowego ze strumienia**

Ten przykład wymaga istniejącego pliku `sample.pps`. Odczytanie jego bajtów do strumienia w pamięci symuluje wejście otrzymane bez nazwy pliku, np. wartość z bazy danych lub przesłaną tablicę bajtów. Konstruktor [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/) przyjmuje wyłącznie strumień.

```csharp
using System;
using System.IO;
using Aspose.Slides;

var bytes = File.ReadAllBytes("sample.pps");
using var stream = new MemoryStream(bytes);
using var presentation = new Presentation(stream);

Console.WriteLine($"Source format: {presentation.SourceFormat}");
```

PPT, PPS i POT używają tego samego podstawowego formatu binarnego. Przy ładowaniu za pomocą ścieżki pliku rozszerzenie może pomóc odróżnić pokaz slajdów lub szablon. Bez nazwy pliku starsza zawartość PPS i POT może być zgłaszana jako `SourceFormat.Ppt`; przykład PPS powyżej zgłasza `Ppt`.

Jeśli aplikacja musi zachować tę różnicę, przechowuj oryginalną nazwę pliku lub metadane podtypu oddzielnie. Rozszerzenie jest przydatną wskazówką dla tych starszych podtypów, ale nie powinno być jedyną podstawą do identyfikacji dowolnej zawartości prezentacji.

## **Porównanie wykrywania przed i po załadowaniu**

Użyj [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/pl/net/aspose.slides/presentationfactory/getpresentationinfo/) i [IPresentationInfo.LoadFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/ipresentationinfo/loadformat/), gdy musisz przejrzeć plik przed załadowaniem jego pełnego modelu obiektowego prezentacji. Użyj [Presentation.SourceFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/sourceformat/) gdy instancja już istnieje.

Ten przykład wymaga `sample.pptx` i wypisuje `Pptx` dla obu sprawdzeń. W produkcji wybierz API odpowiednie do etapu przetwarzania; już załadowana prezentacja nie wymaga drugiej inspekcji wyłącznie w celu uzyskania jej formatu źródłowego.

```csharp
using System;
using Aspose.Slides;

var path = "sample.pptx";
var information = PresentationFactory.Instance.GetPresentationInfo(path);
Console.WriteLine($"Before loading: {information.LoadFormat}");

using var presentation = new Presentation(path);
Console.WriteLine($"After loading: {presentation.SourceFormat}");
```

Wyniki mają różne typy wyliczeń: [LoadFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/loadformat/) i [SourceFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/sourceformat/). Nie porównuj ich przez rzutowanie wartości liczbowych ani nie zakładaj, że każdy format ma identyczne wyniki wykrywania. W opisanym poniżej sprawdzeniu zapisu i ponownego otwarcia, PowerPoint XML był zgłaszany jako `LoadFormat.Unknown` przed załadowaniem i jako `SourceFormat.Xml` po załadowaniu.

## **Utrzymanie formatu źródłowego i wyjściowego osobno**

Ten przykład wymaga `sample.pptx` i zapisuje `converted.odp`. Wypisuje `Pptx` zarówno przed, jak i po zapisaniu pierwotnej instancji. Tylko nowa instancja załadowana z wyjściowego pliku ODP zgłasza `Odp`.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
Console.WriteLine($"Before saving: {presentation.SourceFormat}");

presentation.Save("converted.odp", SaveFormat.Odp);
Console.WriteLine($"After saving: {presentation.SourceFormat}");

using var reopened = new Presentation("converted.odp");
Console.WriteLine($"Reopened output: {reopened.SourceFormat}");
```

Prezentacja utworzona od podstaw za pomocą `new Presentation()` zgłasza `SourceFormat.Pptx`. Nie ma pliku wejściowego: jest to domyślna wartość dla nowo utworzonej instancji, a nie dowód, że został załadowany plik PPTX. Śledź, czy aplikacja utworzyła, czy załadowała instancję, jeśli ta różnica ma znaczenie.

## **Mapowanie formatu źródłowego na rozszerzenie**

Poniższy przykład wymaga `sample.pptx`. Mapuje każdą aktualnie obsługiwaną wartość [SourceFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/sourceformat/) na konwencjonalne rozszerzenie, bez parsowania nazwy pliku wejściowego. Zapasy zapobiegają cichemu przypisaniu rozszerzenia do nieznanej wartości.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var extension = presentation.SourceFormat switch
{
    SourceFormat.Ppt => ".ppt",
    SourceFormat.Pptx => ".pptx",
    SourceFormat.Pptm => ".pptm",
    SourceFormat.Pps => ".pps",
    SourceFormat.Ppsx => ".ppsx",
    SourceFormat.Ppsm => ".ppsm",
    SourceFormat.Pot => ".pot",
    SourceFormat.Potx => ".potx",
    SourceFormat.Potm => ".potm",
    SourceFormat.Odp => ".odp",
    SourceFormat.Otp => ".otp",
    SourceFormat.Fodp => ".fodp",
    SourceFormat.Xml => ".xml",
    _ => null
};

Console.WriteLine(extension ?? "No extension mapping is available.");
```

To mapowanie nie konwertuje pliku ani nie odzyskuje starszego podtypu PPS/POT utraconego podczas ładowania ze strumienia. Do rzeczywistego zapisu wybierz [SaveFormat](https://reference.aspose.com/slides/pl/net/aspose.slides.export/saveformat/) wyraźnie, lub użyj konwersji pokazanej w [Save Presentations in Their Original Format](/slides/pl/net/save-presentation/#save-presentations-in-their-original-format).

## **Weryfikacja formatów przez zapis i ponowne otwarcie**

Ten samodzielny przykład tworzy prezentację i zapisuje trzy pliki w katalogu roboczym, nadpisując pliki o tych samych nazwach. Otwiera każdy wynik zarówno przez ścieżkę, jak i przez strumień w pamięci. Dla PPTX i ODP obie drogi zgłaszają zapisany format. Dla PPS ładowanie po ścieżce zgłasza `Pps`, podczas gdy ładowanie tych samych bajtów bez nazwy pliku zgłasza `Ppt`.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var formats = new[] { SaveFormat.Pptx, SaveFormat.Odp, SaveFormat.Pps };

foreach (var format in formats)
{
    var path = $"roundtrip.{format.ToString().ToLowerInvariant()}";
    presentation.Save(path, format);

    using var fromFile = new Presentation(path);
    var bytes = File.ReadAllBytes(path);
    using var stream = new MemoryStream(bytes);
    using var fromStream = new Presentation(stream);

    Console.WriteLine($"{format}: file={fromFile.SourceFormat}, stream={fromStream.SourceFormat}");
}
```

To samo sprawdzenie dla wszystkich wymienionych wyżej formatów dało następujące wyniki dla wygenerowanych prezentacji z odpowiednimi rozszerzeniami:

| Zapisany format | SourceFormat z ścieżki pliku | SourceFormat z beznazwy strumienia |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` odpowiednio | Takie same jak ścieżka pliku |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` odpowiednio | Takie same jak ścieżka pliku |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` odpowiednio | Takie same jak ścieżka pliku |
| ODP, OTP | `Odp`, `Otp` odpowiednio | Takie same jak ścieżka pliku |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

W tych sprawdzeniach jedyną normalizacją formatu źródłowego było przekształcenie PPS/POT do `Ppt` dla strumieni bez nazwy. Tabela opisuje identyfikację formatu, a nie zachowanie wszystkich funkcji prezentacji podczas konwersji.

## **FAQ**

**Czy zapis do ODP zmienia format źródłowy prezentacji załadowanej z PPTX?**

Nie. Istniejąca instancja nadal zgłasza `Pptx`. Instancja załadowana z zapisanego pliku ODP zgłasza `Odp`.

**Czy strumień zawsze potrafi odróżnić starszą prezentację, pokaz slajdów i szablon?**

Nie. PPT, PPS i POT współdzielą format binarny. Przechowuj nazwę pliku lub metadane podtypu oddzielnie, gdy wymagana jest ta różnica.

**Jakie API powinienem użyć, jeśli prezentacja jest już załadowana?**

Odczytaj [Presentation.SourceFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/sourceformat/). Użyj [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/pl/net/aspose.slides/presentationfactory/getpresentationinfo/), aby przeprowadzić inspekcję przed załadowaniem.