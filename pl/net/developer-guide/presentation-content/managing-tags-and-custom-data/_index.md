---
title: Zarządzanie tagami i danymi niestandardowymi w prezentacjach w .NET
linktitle: Tagi i dane niestandardowe
type: docs
weight: 300
url: /pl/net/managing-tags-and-custom-data/
keywords:
- właściwości dokumentu
- tag
- dane niestandardowe
- niestandardowy XML
- niestandardowa część XML
- metadane XML
- ItemId
- dodaj tag
- pary wartości
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Dowiedz się, jak zarządzać tagami i niestandardowymi danymi XML w prezentacjach PowerPoint przy użyciu Aspose.Slides dla .NET, w tym dodawanie, odczytywanie, aktualizowanie, audyt oraz usuwanie niestandardowych części XML."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak Aspose.Slides działa z tagami i danymi niestandardowymi w prezentacjach PowerPoint. Dane specyficzne dla prezentacji mogą być przechowywane jako tagi lub niestandardowe części XML. Tagi są prostymi parami klucz‑wartość w postaci ciągów znaków, podczas gdy niestandardowe części XML mogą przechowywać ustrukturyzowane metadane oraz specyficzne dla aplikacji ładunki XML.

Aspose.Slides udostępnia API do dodawania, odczytywania, aktualizacji, audytu i usuwania niestandardowych części XML na poziomach prezentacji, slajdu i kształtu. Niestandardowe części XML są przydatne w integracjach, które przechowują informacje takie jak identyfikatory zarządzania dokumentami, stan przepływu pracy, metadane zgodności, dane powiązane z szablonem lub inne ustrukturyzowane dane aplikacji wewnątrz prezentacji.

## **Przechowywanie danych w plikach prezentacji**

Pliki PPTX — pliki z rozszerzeniem `.pptx` — są przechowywane w formacie PresentationML, będącym częścią specyfikacji Office Open XML. Office Open XML definiuje strukturę pakietu oraz zależności używane do przechowywania treści prezentacji i powiązanych danych.

Prezentacja zawiera wiele części połączonych zależnościami. Na przykład część slajdu zawiera treść jednego slajdu i może mieć jawne zależności do innych części określone w ISO/IEC 29500.

Dane niestandardowe mogą być przechowywane jako tagi ([ITagCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/itagcollection)) lub niestandardowe części XML ([ICustomXmlPartCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/icustomxmlpartcollection)). Oba są dostępne poprzez interfejs [`ICustomData`](https://reference.aspose.com/slides/pl/net/aspose.slides/icustomdata/) .

{{% alert color="primary" %}}
Tagi przechowują proste pary klucz‑wartość jako ciągi znaków. Niestandardowe części XML przechowują ustrukturyzowane dane XML i mogą być powiązane z prezentacją, slajdem lub kształtem.
{{% /alert %}}

## **Praca z niestandardowymi częściami XML**

Właściwość [`ICustomData.CustomXmlParts`](https://reference.aspose.com/slides/pl/net/aspose.slides/icustomdata/customxmlparts/) zwraca kolekcję niestandardowych części XML powiązanych z określonym obiektem prezentacji. Na przykład:

- `presentation.CustomData.CustomXmlParts` zawiera niestandardowe części XML powiązane z samą prezentacją.
- `slide.CustomData.CustomXmlParts` zawiera niestandardowe części XML powiązane z określonym slajdem.
- `shape.CustomData.CustomXmlParts` zawiera niestandardowe części XML powiązane z określonym kształtem.

Użyj [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/allcustomxmlparts/) gdy potrzebujesz przejrzeć wszystkie niestandardowe części XML w prezentacji, niezależnie od tego, z czym są powiązane.

### **Dodaj niestandardową część XML do prezentacji**

Użyj [`ICustomXmlPartCollection.Add`](https://reference.aspose.com/slides/pl/net/aspose.slides/icustomxmlpartcollection/add/) aby dodać dane XML do kolekcji niestandardowych części XML. XML musi być prawidłowy i niepusty.

Poniższy przykład dodaje ustrukturyzowane metadane do kolekcji danych niestandardowych na poziomie prezentacji:

```csharp
using System;
using Aspose.Slides;

var customXmlContent =
    "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Draft</workflowState>" +
    "</metadata>";

using var presentation = new Presentation();
var customXmlPart = presentation.CustomData.CustomXmlParts.Add(customXmlContent);

// Add przypisuje identyfikator automatycznie. Ustaw konkretny GUID tylko w razie potrzeby.
customXmlPart.ItemId = Guid.NewGuid();

presentation.Save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
```

Metoda `Add` może także przyjmować XML jako tablicę bajtów lub strumień, co jest przydatne, gdy zawartość XML jest już dostępna w postaci binarnej.

### **Dodaj niestandardową część XML do slajdu lub kształtu**

Dane XML mogą być powiązane z konkretnym slajdem lub kształtem zamiast z całą prezentacją. Jest to przydatne, gdy metadane opisują tylko jeden obiekt, np. klucz szablonu, zewnętrzny identyfikator rekordu lub informacje o powiązaniu.

Poniższy przykład dodaje jedną niestandardową część XML do slajdu i inną do kształtu:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.CustomData.CustomXmlParts.Add(
    "<slideMetadata xmlns=\"urn:example:slides\">" +
        "<templateKey>TitleSlide</templateKey>" +
    "</slideMetadata>");

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 250, 80);

shape.TextFrame.Text = "Customer data";
shape.CustomData.CustomXmlParts.Add(
    "<shapeMetadata xmlns=\"urn:example:shapes\">" +
        "<recordId>CRM-4281</recordId>" +
    "</shapeMetadata>");

presentation.Save("object_custom_xml.pptx", SaveFormat.Pptx);
```

Poziom, na którym dodana jest część, określa, w której kolekcji `CustomData.CustomXmlParts` znajduje się odniesienie do tej części. Dane na poziomie prezentacji są odpowiednie dla metadanych obejmujących cały dokument, dane na poziomie slajdu dla informacji należących do konkretnego slajdu, a dane na poziomie kształtu dla metadanych związanych z pojedynczym kształtem.

### **Wymień i audytuj wszystkie niestandardowe części XML**

Użyj [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/allcustomxmlparts/) aby pobrać wszystkie niestandardowe części XML z prezentacji. Każdy [`ICustomXmlPart`](https://reference.aspose.com/slides/pl/net/aspose.slides/icustomxmlpart/) udostępnia swój identyfikator, zawartość XML i powiązane schematy przestrzeni nazw.

Poniższy przykład wypisuje wszystkie niestandardowe części XML oraz ich schematy przestrzeni nazw:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var customXmlPart in presentation.AllCustomXmlParts)
{
    Console.WriteLine("ItemId: " + customXmlPart.ItemId);
    Console.WriteLine("XML:");
    Console.WriteLine(customXmlPart.XmlAsString);

    foreach (var namespaceSchema in customXmlPart.NamespaceSchemas)
    {
        Console.WriteLine("Namespace schema: " + namespaceSchema);
    }

    Console.WriteLine();
}
```

[`ICustomXmlPart.NamespaceSchemas`](https://reference.aspose.com/slides/pl/net/aspose.slides/icustomxmlpart/namespaceschemas/) zwraca schematy XML powiązane z niestandardową częścią XML. Informacje te mogą być przydatne przy audycie prezentacji zawierających XML wyprodukowany przez systemy zewnętrzne.

### **Odczyt i aktualizacja treści XML oraz ItemId**

Użyj [`ICustomXmlPart.XmlAsString`](https://reference.aspose.com/slides/pl/net/aspose.slides/icustomxmlpart/xmlasstring/) aby pracować z XML jako ciągiem UTF‑8 lub [`ICustomXmlPart.XmlData`](https://reference.aspose.com/slides/pl/net/aspose.slides/icustomxmlpart/xmldata/) aby pracować z surowymi bajtami XML. Obie właściwości można odczytywać i aktualizować.

Właściwość [`ICustomXmlPart.ItemId`](https://reference.aspose.com/slides/pl/net/aspose.slides/icustomxmlpart/itemid/) zawiera GUID identyfikujący niestandardową część XML w dokumencie Office Open XML. Może być również zmieniony, gdy integracja wymaga nowego identyfikatora.

Poniższy przykład aktualizuje zawartość XML oraz identyfikator:

```csharp
using System;
using System.Text;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var customXmlPart = presentation.AllCustomXmlParts[0];

// Odczytaj bieżące XML jako tekst.
var currentXmlContent = customXmlPart.XmlAsString;
Console.WriteLine(currentXmlContent);

// Zaktualizuj XML jako ciąg UTF-8.
customXmlPart.XmlAsString =
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Approved</workflowState>" +
    "</metadata>";

// XmlData dostarcza tę samą zawartość XML jako surowe bajty.
var customXmlData = customXmlPart.XmlData;
Console.WriteLine(Encoding.UTF8.GetString(customXmlData));

// Zastąp identyfikator, gdy wymaga tego integracja.
customXmlPart.ItemId = Guid.NewGuid();

presentation.Save("updated_custom_xml.pptx", SaveFormat.Pptx);
```

Przy przypisywaniu `XmlAsString` lub `XmlData` podawaj prawidłowy, niepusty XML. Użyj jednej reprezentacji lub drugiej w zależności od tego, czy aplikacja pracuje głównie z tekstem, czy z danymi bajtowymi.

### **Usuń niestandardową część XML**

Aspose.Slides oferuje kilka sposobów usunięcia niestandardowych danych XML:

- [`ICustomXmlPart.Remove`](https://reference.aspose.com/slides/pl/net/aspose.slides/icustomxmlpart/remove/) usuwa niestandardową część XML z prezentacji.
- [`ICustomXmlPartCollection.Remove`](https://reference.aspose.com/slides/pl/net/aspose.slides/icustomxmlpartcollection/remove/) usuwa określoną część z kolekcji części XML.
- [`ICustomXmlPartCollection.RemoveAt`](https://reference.aspose.com/slides/pl/net/aspose.slides/icustomxmlpartcollection/removeat/) usuwa część pod wskazanym indeksem kolekcji.
- [`ICustomXmlPartCollection.Clear`](https://reference.aspose.com/slides/pl/net/aspose.slides/icustomxmlpartcollection/clear/) usuwa wszystkie części z danej kolekcji.

Poniższy przykład usuwa jedną niestandardową część XML na poziomie prezentacji, odwołując się do niej:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var customXmlParts = presentation.CustomData.CustomXmlParts;

if (customXmlParts.Count > 0)
{
    var customXmlPart = customXmlParts[0];
    customXmlParts.Remove(customXmlPart);
}

presentation.Save("custom_xml_removed.pptx", SaveFormat.Pptx);
```

Jeśli już posiadasz `ICustomXmlPart` i chcesz usunąć tę część z prezentacji, a nie z konkretnej kolekcji, wywołaj `customXmlPart.Remove()`.

Możesz także usunąć element po indeksie:

```csharp
presentation.CustomData.CustomXmlParts.RemoveAt(0);
```

### **Wyczyść wszystkie niestandardowe części XML z kolekcji**

Użyj `Clear`, gdy wszystkie niestandardowe części XML powiązane z określonym obiektem prezentacji powinny zostać usunięte.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
presentation.Slides[0].CustomData.CustomXmlParts.Clear();

presentation.Save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx);
```

`Clear` wpływa tylko na wybraną kolekcję. Na przykład wyczyszczenie kolekcji slajdu nie usuwa części na poziomie prezentacji ani kształtu.

Aby usunąć każdą niestandardową część XML w prezentacji, przeiteruj `AllCustomXmlParts` i usuń każdą część:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var customXmlPart in presentation.AllCustomXmlParts)
{
    customXmlPart.Remove();
}

presentation.Save("all_custom_xml_removed.pptx", SaveFormat.Pptx);
```

### **Obsługa powiązanych lub współdzielonych niestandardowych części XML**

W prezentacji Office Open XML ta sama niestandardowa część XML może być odwoływana z więcej niż jednego obiektu prezentacji. Na przykład istniejący plik może zawierać zależności z wielu slajdów lub kształtów do tej samej części XML.

Współdzielona część powinna być traktowana jako jeden obiekt danych z wieloma odwołaniami:

- Aktualizacja `XmlAsString`, `XmlData` lub `ItemId` zmienia podstawową część XML, więc zmiana obowiązuje wszędzie, gdzie część jest odwoływana.
- `ItemId` może być używany do identyfikacji tej samej części XML podczas audytu kolekcji na poziomie obiektów.
- Usunięcie części z konkretnej kolekcji `CustomXmlParts` usuwa ją tylko z tej kolekcji. Użyj `ICustomXmlPart.Remove()` gdy cała część ma zostać usunięta z prezentacji.
- Przed usunięciem lub zamianą współdzielonej części sprawdź kolekcje na poziomie obiektów, aby określić, czy inne slajdy lub kształty nadal odwołują się do niej.

Przeciążenia `Add` tworzą nową niestandardową część XML z treści XML; nie akceptują istniejącego `ICustomXmlPart`. Dlatego współdzielone zależności najczęściej występują przy ładowaniu prezentacji, które już je zawierają.

Poniższy przykład audytuje kolekcje na poziomie prezentacji, slajdu i kształtu według `ItemId` i zgłasza części odwoływane z więcej niż jednego miejsca:

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var referencesByItemId = new Dictionary<Guid, List<string>>();

var registerCustomXmlParts = (string ownerName, ICustomXmlPartCollection customXmlParts) =>
    {
        foreach (var customXmlPart in customXmlParts)
        {
            if (!referencesByItemId.ContainsKey(customXmlPart.ItemId))
            {
                referencesByItemId[customXmlPart.ItemId] = new List<string>();
            }

            referencesByItemId[customXmlPart.ItemId].Add(ownerName);
        }
    };

registerCustomXmlParts("Presentation", presentation.CustomData.CustomXmlParts);

for (var slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
{
    var slide = presentation.Slides[slideIndex];
    registerCustomXmlParts("Slide " + (slideIndex + 1), slide.CustomData.CustomXmlParts);

    for (var shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
    {
        var shape = slide.Shapes[shapeIndex];
        registerCustomXmlParts("Slide " + (slideIndex + 1) + ", shape " + shapeIndex, shape.CustomData.CustomXmlParts);
    }
}

foreach (var referenceEntry in referencesByItemId)
{
    if (referenceEntry.Value.Count > 1)
    {
        Console.WriteLine("Shared custom XML part: " + referenceEntry.Key);

        foreach (var ownerName in referenceEntry.Value)
        {
            Console.WriteLine("  Referenced by: " + ownerName);
        }
    }
}
```

Tego typu audyt jest przydatny przed modyfikacją lub usunięciem danych XML w prezentacjach tworzonych przez systemy zewnętrzne, ponieważ ta sama część metadanych może uczestniczyć w więcej niż jednej zależności.

## **Uzyskaj wartości tagów**

W slajdach tag odpowiada właściwości `IDocumentProperties.Keywords`. Ten przykładowy kod pokazuje, jak uzyskać wartość tagu przy użyciu Aspose.Slides for .NET dla [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation):

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var keywords = presentation.DocumentProperties.Keywords;
```

## **Dodaj tagi do prezentacji**

Aspose.Slides pozwala dodawać tagi do prezentacji. Tag zazwyczaj składa się z dwóch elementów:

- nazwy własności niestandardowej, np. `MyTag`;
- wartości własności niestandardowej, np. `My Tag Value`.

Jeśli potrzebujesz klasyfikować prezentacje według konkretnej reguły lub własności, możesz dodać odpowiednie tagi. Na przykład, aby kategoryzować prezentacje z krajów Ameryki Północnej, możesz utworzyć tag „NorthAmerican” i przypisać jako wartość odpowiedni kraj.

Ten przykładowy kod pokazuje, jak dodać tag do [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation) przy użyciu Aspose.Slides for .NET:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var tags = presentation.CustomData.Tags;
tags["MyTag"] = "My Tag Value";
```

Tagi można także ustawiać dla [Slide](https://reference.aspose.com/slides/pl/net/aspose.slides/slide):

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
slide.CustomData.Tags["tag"] = "value";
```

lub dla pojedynczego [Shape](https://reference.aspose.com/slides/pl/net/aspose.slides/shape):

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
shape.TextFrame.Text = "My text";
shape.CustomData.Tags["tag"] = "value";
```

### **Ograniczenia**

Tagi dodane przez kolekcję `CustomData.Tags` są przechowywane wyłącznie w pliku PowerPoint. Nie są **przenoszone** do struktury tagów PDF podczas eksportu prezentacji do PDF. W konsekwencji niestandardowy identyfikator zapisany jako tag nie może być odczytany z otagowanego pliku PDF.

**Workaround**: możesz przechowywać niestandardowy identyfikator w **Alt Text** obiektu (np. `shape.AlternativeText = "MyId"`). Po eksporcie do PDF Alt Text może pojawić się w strukturze tagów PDF.

## **FAQ**

**Czy mogę usunąć wszystkie tagi z prezentacji, slajdu lub kształtu w jednej operacji?**

Tak. Kolekcja [tagów](https://reference.aspose.com/slides/pl/net/aspose.slides/tagcollection/) obsługuje operację [Clear](https://reference.aspose.com/slides/pl/net/aspose.slides/tagcollection/clear/), która usuwa wszystkie pary klucz‑wartość jednocześnie.

**Jak usunąć pojedynczy tag po nazwie bez iteracji po całej kolekcji?**

Użyj `Remove(name)` na [TagCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/tagcollection/) aby usunąć tag po jego kluczu.

**Jak pobrać pełną listę nazw tagów do analiz lub filtrowania?**

Użyj `GetNamesOfTags` na kolekcji tagów; zwraca tablicę wszystkich nazw tagów.

**Jak znaleźć wszystkie niestandardowe części XML, niezależnie od miejsca ich przechowywania?**

Użyj [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/allcustomxmlparts/) aby pobrać wszystkie niestandardowe części XML w prezentacji.

**Czy powinienem używać `XmlAsString` czy `XmlData` do aktualizacji niestandardowej części XML?**

Używaj `XmlAsString`, gdy aplikacja pracuje z tekstem XML w formacie UTF‑8. Używaj `XmlData`, gdy XML jest już dostępny jako tablica bajtów lub gdy przetwarzanie binarne jest wygodniejsze. Obie właściwości reprezentują tę samą zawartość XML niestandardowej części.