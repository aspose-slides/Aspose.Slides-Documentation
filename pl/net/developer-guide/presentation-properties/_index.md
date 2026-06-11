---
title: Zarządzanie właściwościami prezentacji w .NET
linktitle: Właściwości prezentacji
type: docs
weight: 70
url: /pl/net/presentation-properties/
keywords:
- Właściwości PowerPoint
- Właściwości prezentacji
- Właściwości dokumentu
- Wbudowane właściwości
- Niestandardowe właściwości
- Zaawansowane właściwości
- Zarządzanie właściwościami
- Modyfikowanie właściwości
- Metadane dokumentu
- Edytowanie metadanych
- Język korekty
- Domyślny język
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Opanuj właściwości prezentacji w Aspose.Slides dla .NET i usprawnij wyszukiwanie, branding oraz przepływ pracy w plikach PowerPoint i OpenDocument."
---
## **Wprowadzenie**

Aspose.Slides for .NET obsługuje dwa typy właściwości dokumentu: **Wbudowane** i **Niestandardowe**. Oba te typy właściwości można łatwo odczytywać i zarządzać nimi przy użyciu API Aspose.Slides for .NET.

Aspose.Slides umożliwia pracę z właściwościami dokumentu prezentacji za pośrednictwem interfejsu [IDocumentProperties](https://reference.aspose.com/slides/pl/net/aspose.slides/idocumentproperties/). Instancja tego interfejsu jest zwracana przez właściwość [Presentation.DocumentProperties](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/documentproperties/). Poniższe przykłady pokazują, jak odczytywać, modyfikować i zarządzać tymi właściwościami.

{{% alert color="primary" %}} 

Należy pamiętać, że pola **Application** i **Producer** nie mogą być modyfikowane, ponieważ te pola zawsze wyświetlają „Aspose Ltd.” i „Aspose.Slides for .NET x.x.x”.

{{% /alert %}} 

## **Zarządzanie właściwościami prezentacji**

Microsoft PowerPoint udostępnia funkcję dodawania właściwości do plików prezentacji. Te właściwości dokumentu pozwalają przechowywać przydatne informacje razem z plikami. Istnieją dwa typy właściwości dokumentu:

- Właściwości definiowane przez system (wbudowane)
- Właściwości definiowane przez użytkownika (niestandardowe)

**Wbudowane** właściwości zawierają ogólne informacje o dokumencie, takie jak tytuł dokumentu, nazwisko autora, statystyki dokumentu i inne.

**Niestandardowe** właściwości są definiowane przez użytkowników jako pary **Nazwa/Wartość**, przy czym zarówno nazwa, jak i wartość są określane przez użytkownika.

Korzystając z Aspose.Slides for .NET, programiści mogą uzyskać dostęp do wbudowanych i niestandardowych właściwości oraz je modyfikować.

Microsoft PowerPoint umożliwia użytkownikom zarządzanie właściwościami dokumentu, klikając ikonę Office, a następnie wybierając **Plik → Informacje → Właściwości**. Po wybraniu **Zaawansowane właściwości** pojawia się okno dialogowe, w którym można zarządzać wszystkimi właściwościami dokumentu pliku prezentacji.

W oknie dialogowym **Właściwości** znajduje się kilka zakładek, takich jak **Ogólne**, **Podsumowanie**, **Statystyki**, **Zawartość** i **Niestandardowe**. Każda zakładka oferuje opcje konfigurowania określonych typów informacji związanych z plikiem PowerPoint. Zakładka **Niestandardowe** służy do zarządzania właściwościami definiowanymi przez użytkownika.

## **Dostęp do wbudowanych właściwości**

Te właściwości, udostępnione przez interfejs [IDocumentProperties](https://reference.aspose.com/slides/pl/net/aspose.slides/idocumentproperties/), obejmują: **Creator** (Autor), **Description**, **Keywords**, **Created** (Data utworzenia), **Modified** (Data modyfikacji), **Printed** (Data ostatniego drukowania), **LastModifiedBy**, **SharedDoc** (wskazuje, czy dokument jest współdzielony między różnymi producentami), **PresentationFormat**, **Subject**, **Title** i inne.

```cs
// Utwórz klasę Presentation, która reprezentuje plik prezentacji.
using Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");

// Uzyskaj odwołanie do obiektu typu IDocumentProperties powiązanego z prezentacją.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Wyświetl wbudowane właściwości.
Console.WriteLine("Category : " + documentProperties.Category);
Console.WriteLine("Content status : " + documentProperties.ContentStatus);
Console.WriteLine("Creation date : " + documentProperties.CreatedTime);
Console.WriteLine("Author : " + documentProperties.Author);
Console.WriteLine("Comments : " + documentProperties.Comments);
Console.WriteLine("Key words : " + documentProperties.Keywords);
Console.WriteLine("Last modified by : " + documentProperties.LastSavedBy);
Console.WriteLine("Manager : " + documentProperties.Manager);
Console.WriteLine("Modified date : " + documentProperties.LastSavedTime);
Console.WriteLine("Presentation format : " + documentProperties.PresentationFormat);
Console.WriteLine("Last print date : " + documentProperties.LastPrinted);
Console.WriteLine("Is shared between producers : " + documentProperties.SharedDoc);
Console.WriteLine("Subject : " + documentProperties.Subject);
Console.WriteLine("Title : " + documentProperties.Title);
```

## **Modyfikowanie wbudowanych właściwości**

Modyfikowanie wbudowanych właściwości plików prezentacji jest tak proste, jak ich odczytywanie. Wystarczy przypisać łańcuch znaków do dowolnej żądanej właściwości, a jej wartość zostanie zaktualizowana. W poniższym przykładzie pokazujemy, jak zmienić wbudowane właściwości dokumentu prezentacji.

```cs
// Utwórz klasę Presentation, która reprezentuje plik prezentacji.
using Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");

// Uzyskaj odwołanie do obiektu typu IDocumentProperties powiązanego z prezentacją.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Ustaw wbudowane właściwości.
documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

// Zapisz prezentację do pliku.
presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Dodawanie niestandardowych właściwości prezentacji**

Niestandardowe właściwości prezentacji umożliwiają programistom przechowywanie dodatkowych metadanych lub konkretnych informacji w pliku prezentacji. Aspose.Slides ułatwia programowe tworzenie i zarządzanie tymi niestandardowymi właściwościami. Poniższe przykłady demonstrują, jak dodać niestandardowe właściwości do prezentacji.

```cs
// Utwórz instancję klasy Presentation.
using Presentation presentation = new Presentation();

// Uzyskaj odwołanie do obiektu typu IDocumentProperties powiązanego z prezentacją.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Dodaj niestandardowe właściwości.
documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

// Zapisz prezentację do pliku.
presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Dostęp i modyfikacja niestandardowych właściwości**

Aspose.Slides pozwala również programistom na dostęp do istniejących niestandardowych właściwości oraz łatwe ich modyfikowanie. Ta funkcjonalność pomaga utrzymać dokładne metadane i wspiera dynamiczne aktualizacje na podstawie danych wejściowych użytkownika lub logiki biznesowej. Poniższe przykłady ilustrują, jak odczytać i zaktualizować wartości niestandardowych właściwości w prezentacji.

```cs
// Utwórz instancję klasy Presentation, która reprezentuje plik PPTX.
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// Uzyskaj odwołanie do obiektu typu IDocumentProperties powiązanego z prezentacją.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Uzyskaj dostęp i zmodyfikuj niestandardowe właściwości.
for (int i = 0; i < documentProperties.CountOfCustomProperties; i++)
{
    string propertyName = documentProperties.GetCustomPropertyName(i);
    object propertyValue = documentProperties[propertyName];

    // Wyświetl nazwę i wartość niestandardowej właściwości.
    Console.WriteLine("Custom property name : " + propertyName);
    Console.WriteLine("Custom property value : " + propertyValue);

    // Zmień wartość niestandardowej właściwości.
    documentProperties[propertyName] = "New Value " + (i + 1);
}

// Zapisz prezentację do pliku.
presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **Przykład na żywo**

Wypróbuj aplikację online [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/pl/metadata), aby zobaczyć, jak pracować z właściwościami dokumentu przy użyciu API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/pl/metadata)

## ***FAQ**

**Jak mogę usunąć wbudowaną właściwość z prezentacji?**

Wbudowane właściwości są integralną częścią prezentacji i nie można ich całkowicie usunąć. Można jednak zmienić ich wartości lub, jeśli dana właściwość na to pozwala, ustawić je jako puste.

**Co się stanie, jeśli dodam niestandardową właściwość, która już istnieje?**

Jeśli dodasz niestandardową właściwość, która już istnieje, jej bieżąca wartość zostanie zastąpiona nową. Nie musisz usuwać ani sprawdzać właściwości wcześniej, ponieważ Aspose.Slides automatycznie aktualizuje wartość właściwości.

**Czy mogę uzyskać dostęp do właściwości prezentacji bez pełnego ładowania prezentacji?**

Tak, możesz uzyskać dostęp do właściwości prezentacji bez pełnego ładowania pliku, używając metody `GetPresentationInfo` z klasy [PresentationFactory](https://reference.aspose.com/slides/pl/net/aspose.slides/presentationfactory/). Następnie wykorzystaj metodę `ReadDocumentProperties` udostępnioną przez interfejs [IPresentationInfo](https://reference.aspose.com/slides/pl/net/aspose.slides/ipresentationinfo/), aby efektywnie odczytać właściwości, oszczędzając pamięć i zwiększając wydajność.