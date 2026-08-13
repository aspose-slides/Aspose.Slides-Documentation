---
title: Zarządzanie tagami i danymi własnymi w prezentacjach w .NET
linktitle: Tagi i dane własne
type: docs
weight: 300
url: /pl/net/managing-tags-and-custom-data/
keywords:
- właściwości dokumentu
- tag
- dane własne
- własny XML
- własna część XML
- metadane XML
- ItemId
- dodaj tag
- pary wartości
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Dowiedz się, jak zarządzać tagami i własnymi danymi XML w prezentacjach PowerPoint przy użyciu Aspose.Slides dla .NET, w tym jak dodawać, odczytywać, aktualizować, audytować i usuwać własne części XML."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak Aspose.Slides współpracuje z tagami i własnymi danymi w prezentacjach PowerPoint. Dane specyficzne dla prezentacji mogą być przechowywane jako tagi lub własne części XML. Tagi są prostymi parami klucz‑wartość w formie łańcucha znaków, podczas gdy własne części XML mogą przechowywać ustrukturyzowane metadane oraz ładunki XML specyficzne dla aplikacji.

Aspose.Slides udostępnia interfejsy API do dodawania, odczytywania, aktualizacji, audytu i usuwania własnych części XML na poziomach prezentacji, slajdu i kształtu. Własne części XML są przydatne w integracjach, które przechowują informacje takie jak identyfikatory zarządzania dokumentami, stan przepływu pracy, metadane zgodności, dane powiązane z szablonem lub inne ustrukturyzowane dane aplikacji wewnątrz prezentacji.

## **Przechowywanie danych w plikach prezentacji**

Pliki PPTX — pliki z rozszerzeniem `.pptx` — są przechowywane w formacie PresentationML, który jest częścią specyfikacji Office Open XML. Office Open XML definiuje strukturę pakietu i relacje używane do przechowywania treści prezentacji oraz powiązanych danych.

Prezentacja zawiera wiele części połączonych relacjami. Na przykład część slajdu zawiera zawartość jednego slajdu i może mieć explicite relacje do innych części określone w ISO/IEC 29500.

Własne dane mogą być przechowywane jako tagi ([ITagCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/itagcollection)) lub własne części XML ([ICustomXmlPartCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/icustomxmlpartcollection)). Oba są dostępne poprzez interfejs [`ICustomData`](https://reference.aspose.com/slides/pl/net/aspose.slides/icustomdata/) .

{{% alert color="info" %}}
Tagi przechowują proste pary klucz‑wartość w postaci łańcucha znaków. Własne części XML przechowują ustrukturyzowane dane XML i mogą być powiązane z prezentacją, slajdem lub kształtem.
{{% /alert %}}

## **Praca z własnymi częściami XML**

Właściwość [`ICustomData.CustomXmlParts`](https://reference.aspose.com/slides/pl/net/aspose.slides/icustomdata/customxmlparts/) zwraca kolekcję własnych części XML skojarzonych z określonym obiektem prezentacji. Na przykład:

- `presentation.CustomData.CustomXmlParts` zawiera własne części XML powiązane z samą prezentacją.
- `slide.CustomData.CustomXmlParts` zawiera własne części XML powiązane z określonym slajdem.
- `shape.CustomData.CustomXmlParts` zawiera własne części XML powiązane z określonym kształtem.

Użyj [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/allcustomxmlparts/) gdy potrzebujesz przeglądać wszystkie własne części XML w prezentacji, niezależnie od tego, z czym są skojarzone.

### **Dodaj własną część XML do prezentacji**

Użyj [`ICustomXmlPartCollection.Add`](https://reference.aspose.com/slides/pl/net/aspose.slides/icustomxmlpartcollection/add/) aby dodać dane XML do kolekcji własnych części XML. XML musi być poprawny i niepusty.

Poniższy przykład dodaje ustrukturyzowane metadane do kolekcji danych własnych na poziomie prezentacji:

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

// Dodaje identyfikator automatycznie. Ustaw konkretny GUID tylko w razie potrzeby.
customXmlPart.ItemId = Guid.NewGuid();

presentation.Save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
```

Metoda `Add` może również przyjmować XML jako tablicę bajtów lub strumień, co jest przydatne, gdy zawartość XML jest już dostępna w postaci binarnej.

### **Dodaj własną część XML do slajdu lub kształtu**

Własne dane XML mogą być powiązane z określonym slajdem lub kształtem, zamiast z całą prezentacją. Jest to przydatne, gdy metadane opisują tylko jeden obiekt, taki jak klucz szablonu, zewnętrzny identyfikator rekordu lub informacje o powiązaniu.

Poniższy przykład dodaje jedną własną część XML do slajdu i drugą do kształtu:

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

Poziom, na którym część jest dodana, określa, w której kolekcji `CustomData.CustomXmlParts` obiektu znajduje się odniesienie do tej części. Dane na poziomie prezentacji są odpowiednie dla metadanych obejmujących cały dokument, dane na poziomie slajdu dla informacji należących do konkretnego slajdu, a dane na poziomie kształtu dla metadanych powiązanych z pojedynczym kształtem.

### **Wypisz i audytuj wszystkie własne części XML**

Użyj [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/allcustomxmlparts/) aby pobrać wszystkie własne części XML z prezentacji. Każda [`ICustomXmlPart`](https://reference.aspose.com/slides/pl/net/aspose.slides/icustomxmlpart/) udostępnia swój identyfikator, zawartość XML oraz powiązane schematy przestrzeni nazw.

Poniższy przykład wymienia wszystkie własne części XML oraz ich schematy przestrzeni nazw:

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

`ICustomXmlPart.NamespaceSchemas` zwraca schematy XML powiązane z własną częścią XML. Informacje te mogą być przydatne przy audycie prezentacji zawierających XML generowany przez systemy zewnętrzne.

### **Odczyt i aktualizacja zawartości XML oraz ItemId**

Użyj [`ICustomXmlPart.XmlAsString`](https://reference.aspose.com/slides/pl/net/aspose.slides/icustomxmlpart/xmlasstring/) aby pracować z XML jako ciągiem znaków UTF‑8, lub [`ICustomXmlPart.XmlData`](https://reference.aspose.com/slides/pl/net/aspose.slides/icustomxmlpart/xmldata/) aby pracować z surowymi bajtami XML. Obie właściwości można odczytywać i aktualizować.

Właściwość `ICustomXmlPart.ItemId` zawiera GUID identyfikujący własną część XML w dokumencie Office Open XML. Może być również zmieniona, gdy integracja wymaga nowego identyfikatora.

Poniższy przykład aktualizuje zawartość XML oraz identyfikator:

```csharp
using System;
using System.Text;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var customXmlPart = presentation.AllCustomXmlParts[0];

// Odczytaj bieżący XML jako tekst.
var currentXmlContent = customXmlPart.XmlAsString;
Console.WriteLine(currentXmlContent);

// Zaktualizuj XML jako ciąg znaków UTF-8.
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

Przy przypisywaniu `XmlAsString` lub `XmlData` podaj prawidłowy, niepusty XML. Użyj jednej z reprezentacji w zależności od tego, czy aplikacja pracuje głównie z ciągami znaków, czy z danymi bajtowymi.

### **Usuwanie własnej części XML**

Aspose.Slides oferuje kilka sposobów usunięcia własnych danych XML:

- `ICustomXmlPart.Remove` usuwa własną część XML z prezentacji.
- `ICustomXmlPartCollection.Remove` usuwa określoną część z kolekcji własnych części XML.
- `ICustomXmlPartCollection.RemoveAt` usuwa część pod wskazanym indeksem w kolekcji.
- `ICustomXmlPartCollection.Clear` usuwa wszystkie części z określonej kolekcji.

Poniższy przykład usuwa jedną własną część XML na poziomie prezentacji przy użyciu referencji:

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

Jeśli już posiadasz `ICustomXmlPart` i chcesz usunąć tę część z prezentacji, zamiast odnosić się do konkretnej kolekcji, wywołaj `customXmlPart.Remove()`.

Możesz również usunąć element według indeksu:

```csharp
presentation.CustomData.CustomXmlParts.RemoveAt(0);
```

### **Wyczyść wszystkie własne części XML z kolekcji**

Użyj `Clear`, gdy wszystkie własne części XML powiązane z określonym obiektem prezentacji mają zostać usunięte.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
presentation.Slides[0].CustomData.CustomXmlParts.Clear();

presentation.Save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx);
```

`Clear` wpływa tylko na wybraną kolekcję. Na przykład wyczyszczenie kolekcji slajdu nie usuwa kolekcji na poziomie prezentacji ani kształtu.

Aby usunąć wszystkie własne części XML w prezentacji, iteruj po `AllCustomXmlParts` i usuń każdą część:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var customXmlPart in presentation.AllCustomXmlParts)
{
    customXmlPart.Remove();
}

presentation.Save("all_custom_xml_removed.pptx", SaveFormat.Pptx);
```

### **Obsługa powiązanych lub współdzielonych własnych części XML**

W prezentacji Office Open XML ta sama własna część XML może być odwoływana z więcej niż jednego obiektu prezentacji. Na przykład istniejący plik może zawierać relacje z wielu slajdów lub kształtów do tej samej podstawowej własnej części XML.

Współdzielona część powinna być traktowana jako jeden obiekt danych z wieloma odniesieniami:

- Aktualizacja jej `XmlAsString`, `XmlData` lub `ItemId` zmienia podstawową własną część XML, więc zmiana obowiązuje wszędzie, gdzie ta część jest odwoływana.
- `ItemId` może być używany do identyfikacji tej samej własnej części XML podczas audytu kolekcji na poziomie obiektów.
- Usunięcie części z określonej kolekcji `CustomXmlParts` usuwa ją z tej kolekcji. Użyj `ICustomXmlPart.Remove()`, gdy sama część ma zostać usunięta z prezentacji.
- Przed usunięciem lub zastąpieniem współdzielonej części, sprawdź kolekcje na poziomie obiektów, aby określić, czy inne slajdy lub kształty nadal się do niej odwołują.

`Add` przeciążenia tworzą nową własną część XML z zawartości XML; nie przyjmują istniejącego `ICustomXmlPart`. Dlatego współdzielone relacje najczęściej pojawiają się przy ładowaniu prezentacji, które już je zawierają.

Poniższy przykład audytuje kolekcje na poziomie prezentacji, slajdu i kształtu według `ItemId` i raportuje części odwoływane z więcej niż jednego miejsca:

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

Tego rodzaju audyt jest przydatny przed modyfikacją lub usunięciem własnych danych XML w prezentacjach tworzonych przez systemy zewnętrzne, ponieważ ta sama część metadanych może brać udział w więcej niż jednej relacji.

## **Pobieranie wartości tagów**

W slajdach tag odpowiada właściwości `IDocumentProperties.Keywords`. Ten przykładowy kod pokazuje, jak pobrać wartość tagu przy użyciu Aspose.Slides dla .NET dla [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation):

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var keywords = presentation.DocumentProperties.Keywords;
```

## **Dodawanie tagów do prezentacji**

Aspose.Slides umożliwia dodawanie tagów do prezentacji. Tag zazwyczaj składa się z dwóch elementów:

- nazwa własnej właściwości, na przykład `MyTag`;
- wartość własnej właściwości, na przykład `My Tag Value`.

Jeśli potrzebujesz klasyfikować prezentacje według określonej reguły lub właściwości, możesz dodać odpowiednie tagi. Na przykład, jeśli chcesz kategoryzować prezentacje z krajów Ameryki Północnej, możesz utworzyć tag „North American” i przypisać jako wartość odpowiedni kraj.

Ten przykładowy kod pokazuje, jak dodać tag do [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation) używając Aspose.Slides dla .NET:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var tags = presentation.CustomData.Tags;
tags["MyTag"] = "My Tag Value";
```

Tagi mogą być również ustawiane dla [Slide](https://reference.aspose.com/slides/pl/net/aspose.slides/slide):

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
slide.CustomData.Tags["tag"] = "value";
```

Lub dla pojedynczego [Shape](https://reference.aspose.com/slides/pl/net/aspose.slides/shape):

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
shape.TextFrame.Text = "My text";
shape.CustomData.Tags["tag"] = "value";
```

### **Ograniczenia**

Tagi dodane przez kolekcję `CustomData.Tags` są przechowywane wyłącznie w pliku PowerPoint. Nie są **przenoszone** do struktury tagów PDF podczas eksportu prezentacji do PDF. W konsekwencji własny identyfikator przypisany jako tag nie może być odczytany z otagowanego PDF.

**Obejście**: Możesz przechowywać własny identyfikator w **Alt Text** obiektu (na przykład `shape.AlternativeText = "MyId"`). Po eksporcie do PDF, tekst alternatywny może pojawić się w strukturze tagów PDF.

## **FAQ**

**Czy mogę usunąć wszystkie tagi z prezentacji, slajdu lub kształtu w jednej operacji?**

Tak. [Kolekcja tagów](https://reference.aspose.com/slides/pl/net/aspose.slides/tagcollection/) obsługuje operację [Clear](https://reference.aspose.com/slides/pl/net/aspose.slides/tagcollection/clear/), która usuwa wszystkie pary klucz‑wartość jednocześnie.

**Jak usunąć pojedynczy tag po jego nazwie bez iterowania po całej kolekcji?**

Użyj [Remove(name)](https://reference.aspose.com/slides/pl/net/aspose.slides/tagcollection/remove/) na [TagCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/tagcollection/), aby usunąć tag po jego kluczu.

**Jak mogę pobrać pełną listę nazw tagów do analizy lub filtrowania?**

Użyj [GetNamesOfTags](https://reference.aspose.com/slides/pl/net/aspose.slides/tagcollection/getnamesoftags/) na [kolekcji tagów](https://reference.aspose.com/slides/pl/net/aspose.slides/tagcollection/); zwraca ona tablicę wszystkich nazw tagów.

**Jak mogę znaleźć wszystkie własne części XML, niezależnie od miejsca ich przechowywania?**

Użyj [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/allcustomxmlparts/), aby pobrać wszystkie własne części XML w prezentacji.

**Czy powinienem używać `XmlAsString` czy `XmlData` do aktualizacji własnej części XML?**

Użyj `XmlAsString`, gdy aplikacja pracuje z tekstem XML w formacie UTF‑8. Użyj `XmlData`, gdy XML jest już dostępny jako tablica bajtów lub gdy wygodniejsze jest przetwarzanie binarne. Obie właściwości reprezentują zawartość XML tej samej własnej części XML.