---
title: "Jak wyodrębnić tekst z plików PPT, PPTX i ODP przy użyciu Open XML SDK w .NET"
linktitle: Open XML SDK
type: docs
weight: 20
url: /pl/net/extracting-text-on-cloud-platforms-using-open-xml-sdk/
keywords:
- platformy chmurowe
- integracja chmurowa
- Open XML SDK
- wyodrębnianie tekstu PPTX
- przetwarzanie slajdów .NET
- wyodrębnianie tekstu prezentacji
- slajd wzorcowy
- notatki prelegenta
- wyodrębnianie tekstu ze slajdów
- C#
description: "Dowiedz się, jak wyodrębnić tekst z plików PPT, PPTX i ODP w .NET przy użyciu Open XML SDK, z dostępem opartym na XML, wskazówkami dotyczącymi wydajności oraz obejściami konwersji dla aplikacji chmurowych."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak wyodrębnić tekst z plików prezentacji przy użyciu Open XML SDK w .NET. Skupia się na bezpośrednim dostępie do XML dla plików PPTX, gdzie tekst można pobrać ze strukturalnych elementów slajdów bez renderowania slajdów i bez wymogu Microsoft PowerPoint. Artykuł opisuje także korzyści wydajnościowe, takie jak szybsze przetwarzanie i mniejsze zużycie pamięci.

Dla plików PPT i ODP artykuł wyjaśnia, że tekst nie może być wyodrębniony bezpośrednio przy użyciu Open XML SDK. Zamiast tego te formaty należy najpierw przekonwertować na PPTX, po czym tekst można wyodrębnić z powstałego pliku.

## **Open XML SDK**

**Open XML SDK** zapewnia wysoce ustrukturyzowaną i wydajną metodę wyodrębniania tekstu z plików prezentacji — szczególnie **PPTX**, które stosuje standard Open XML. Dzięki bezpośredniemu dostępowi do znajdującego się pod spodem XML, SDK umożliwia szybsze i bardziej elastyczne przetwarzanie zawartości slajdów w porównaniu z tradycyjnymi metodami.

## **Bezpośredni dostęp do XML**

- **Analiza tekstu bezpośrednio**: Open XML SDK pozwala wyodrębnić tekst z części XML bez renderowania slajdów.
- **Ustrukturyzowane elementy**: Ponieważ tekst jest przechowywany w precyzyjnie zdefiniowanych znacznikach XML, jego pobranie i przetworzenie jest prostsze.

### **Przykład: Bezpośrednie wyodrębnianie tekstu z zawartości XML slajdu**

```csharp
using (PresentationDocument presentation = PresentationDocument.Open("presentation.pptx", false))
{
    var slidePart = presentation.PresentationPart.SlideParts.FirstOrDefault();
    if (slidePart != null)
    {
        var textElements = slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>();
        foreach (var text in textElements)
        {
            Console.WriteLine(text.Text);
        }
    }
}
```

## **Zalety wydajnościowe**

- **Szybsze wyodrębnianie**: Omija narzut otwierania PowerPointa lub innych wysokopoziomowych interfejsów API.
- **Mniejsze użycie pamięci**: Dostęp uzyskiwany jest tylko do istotnych części XML, co zmniejsza zużycie zasobów.
- **Brak wymogu Microsoft PowerPoint**: Umożliwia pracę bez dodatkowych wymagań instalacyjnych.

### **Przykład: Efektywne wyodrębnianie tekstu bez ładowania całej prezentacji**

```csharp
using (PresentationDocument presentation = PresentationDocument.Open("presentation.pptx", false))
{
    foreach (var slidePart in presentation.PresentationPart.SlideParts)
    {
        var texts = slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>().Select(t => t.Text);
        Console.WriteLine(string.Join(" ", texts));
    }
}
```

## **Identyfikowanie elementów tekstowych**

### **Szczegóły wyodrębniania tekstu z prezentacji**

Podczas wyodrębniania tekstu z prezentacji należy wziąć pod uwagę następujące czynniki:

- **Tekst może znajdować się w różnych sekcjach**: zwykłe slajdy, slajdy wzorcowe, układy lub notatki prelegenta.
- **Domyślne pola zastępcze**: Slajdy wzorcowe i układy mogą zawierać pola zastępcze (np. „Kliknij, aby edytować styl tytułu wzorca”), które nie są rzeczywistą treścią prezentacji.
- **Filtrowanie pustego lub ukrytego tekstu**: Niektóre elementy mogą być puste lub nieprzeznaczone do wyświetlania.

### **Tagi zawierające tekst**

W pliku **PPTX** tekst jest zazwyczaj przechowywany w:

- elementy `<a:t>` wewnątrz `<a:p>` (akapity)
- elementy `<a:r>` (segmenty tekstu w akapitach)

### **Przykład: Wyodrębnianie wszystkich elementów tekstowych ze slajdu**

```csharp
var textElements = slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>();
foreach (var text in textElements)
{
    Console.WriteLine(text.Text);
}
```

## **ODP i PPT**

### **Niemożność bezpośredniego wyodrębniania tekstu**

- W przeciwieństwie do **PPTX**, **PPT** (format binarny) i **ODP** (OpenDocument Presentation) **nie są obsługiwane** przez Open XML SDK.
- **PPT** przechowuje treść w zamkniętym formacie binarnym, co utrudnia wyodrębnianie tekstu.
- **ODP** opiera się na **OpenDocument XML**, który strukturalnie różni się od PPTX.

### **Obejście: konwersja do PPTX**

Aby wyodrębnić tekst z **PPT** lub **ODP**, zalecane podejście to:

1. Konwertuj PPT → PPTX przy użyciu PowerPointa lub narzędzia firm trzecich.
2. Konwertuj ODP → PPTX za pomocą LibreOffice lub PowerPointa.
3. Wyodrębnij tekst z nowego pliku PPTX przy użyciu Open XML SDK.

### **Przykład: Konwersja ODP do PPTX za pomocą wiersza poleceń LibreOffice**

```sh
soffice --headless --convert-to pptx presentation.odp
```

## **Obsługiwane platformy i frameworki**

- **Windows**: .NET Framework 4.6.1 i nowsze, .NET Core 2.1+, .NET 5/6/7.
- **Linux/macOS**: .NET Core 2.1+, .NET 5/6/7.
- **Środowiska chmurowe**: Microsoft Azure Functions, AWS Lambda (.NET Core), kontenery Docker.
- **Kompatybilność z aplikacjami Office**: Brak wymogu instalacji Microsoft Office.
- **Obsługiwane języki programowania**: Open XML SDK może być używany z **C#**, **VB.NET**, **F#** oraz innymi językami obsługiwanymi przez .NET.

## **Podsumowanie**

Wykorzystanie **Open XML SDK** do **wyodrębniania tekstu z PPTX** zapewnia zarówno wydajność, jak i przejrzystość, podczas gdy **PPT i ODP** wymagają początkowego kroku konwersji dla płynnego przetwarzania. Przyjęcie tego podejścia zapewnia **wysoką wydajność**, **elastyczność** i **szeroką kompatybilność** z nowoczesnymi aplikacjami .NET.