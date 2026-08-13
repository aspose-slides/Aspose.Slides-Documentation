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
- Edycja metadanych
- Język korekty
- Domyślny język
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Opanuj właściwości prezentacji w Aspose.Slides for .NET i usprawnij wyszukiwanie, branding oraz przepływ pracy w swoich plikach PowerPoint i OpenDocument."
---
## **Wprowadzenie**

Aspose.Slides for .NET obsługuje dwa typy właściwości dokumentu: **Wbudowane** i **Niestandardowe**. Oba te typy właściwości można łatwo uzyskać i zarządzać za pomocą interfejsu API Aspose.Slides for .NET.

Aspose.Slides umożliwia pracę z właściwościami dokumentu prezentacji za pomocą interfejsu [IDocumentProperties](https://reference.aspose.com/slides/pl/net/aspose.slides/idocumentproperties/) . Instancja tego interfejsu jest zwracana przez właściwość [Presentation.DocumentProperties](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/documentproperties/) . Poniższe przykłady pokazują, jak odczytywać, modyfikować i zarządzać tymi właściwościami.

{{% alert color="info" %}} 
Należy pamiętać, że pola **Application** i **Producer** nie mogą być modyfikowane, ponieważ zawsze będą wyświetlały „Aspose Ltd.” i „Aspose.Slides for .NET x.x.x”.
{{% /alert %}} 

## **Zarządzanie właściwościami prezentacji**

Microsoft PowerPoint udostępnia funkcję dodawania właściwości do plików prezentacji. Te właściwości dokumentu pozwalają przechowywać przydatne informacje razem z plikami. Istnieją dwa typy właściwości dokumentu:

- Właściwości zdefiniowane przez system (wbudowane)
- Właściwości zdefiniowane przez użytkownika (niestandardowe)

Właściwości **wbudowane** zawierają ogólne informacje o dokumencie, takie jak tytuł dokumentu, imię i nazwisko autora, statystyki dokumentu i inne.

Właściwości **niestandardowe** są definiowane przez użytkowników jako pary **Nazwa/Wartość**, gdzie zarówno nazwa, jak i wartość są określane przez użytkownika.

Za pomocą Aspose.Slides for .NET programiści mogą uzyskiwać dostęp i modyfikować zarówno wbudowane, jak i niestandardowe właściwości.

Microsoft PowerPoint umożliwia użytkownikom zarządzanie właściwościami dokumentu, klikając ikonę Office, a następnie wybierając **Plik → Informacje → Właściwości**. Po wybraniu **Właściwości zaawansowane**, pojawia się okno dialogowe, w którym można zarządzać wszystkimi właściwościami dokumentu pliku prezentacji.

W oknie dialogowym **Właściwości** znajduje się kilka zakładek, takich jak **Ogólne**, **Podsumowanie**, **Statystyka**, **Zawartość** i **Niestandardowe**.
Każda zakładka oferuje opcje konfigurowania określonych typów informacji związanych z plikiem PowerPoint. Zakładka **Niestandardowe** służy do zarządzania właściwościami definiowanymi przez użytkownika.

## **Uzyskiwanie dostępu do wbudowanych właściwości**

Te właściwości, udostępnione przez interfejs [IDocumentProperties](https://reference.aspose.com/slides/pl/net/aspose.slides/idocumentproperties/), obejmują: **Creator** (Autor), **Description**, **Keywords**, **Created** (Data utworzenia), **Modified** (Data modyfikacji), **Printed** (Data ostatniego wydruku), **LastModifiedBy**, **SharedDoc** (wskazuje, czy dokument jest współdzielony między różnymi producentami), **PresentationFormat**, **Subject**, **Title** i inne.

```cs
using Aspose.Slides;

// Instantiate the Presentation class that represents a presentation file.
using Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");

// Get a reference to the object of type IDocumentProperties associated with the presentation.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Display the Built-in properties.
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

Modyfikowanie wbudowanych właściwości plików prezentacji jest tak proste, jak ich odczytywanie. Można po prostu przypisać ciąg znaków do dowolnej żądanej właściwości, a wartość tej właściwości zostanie zaktualizowana. W poniższym przykładzie pokazujemy, jak zmodyfikować wbudowane właściwości dokumentu prezentacji.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
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

Niestandardowe właściwości prezentacji umożliwiają programistom przechowywanie dodatkowych metadanych lub konkretnych informacji w pliku prezentacji. Aspose.Slides ułatwia programowe tworzenie i zarządzanie tymi niestandardowymi właściwościami. Poniższe przykłady pokazują, jak dodać niestandardowe właściwości do prezentacji.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Utwórz instancję klasy Presentation.
using Presentation presentation = new Presentation();

// Uzyskaj odwołanie do obiektu typu IDocumentProperties powiązanego z prezentacją.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Dodaj własne właściwości.
documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

// Zapisz prezentację do pliku.
presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Uzyskiwanie dostępu i modyfikowanie niestandardowych właściwości**

Aspose.Slides również umożliwia programistom łatwy dostęp do istniejących niestandardowych właściwości oraz modyfikowanie ich wartości. Ta funkcjonalność pomaga utrzymać dokładne metadane i wspiera dynamiczne aktualizacje w oparciu o dane wejściowe użytkownika lub logikę biznesową. Poniższe przykłady ilustrują, jak pobrać i zaktualizować wartości niestandardowych właściwości w prezentacji.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Utwórz instancję klasy Presentation, która reprezentuje plik PPTX.
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// Uzyskaj odwołanie do obiektu typu IDocumentProperties powiązanego z prezentacją.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Access and modify the custom properties.
for (int i = 0; i < documentProperties.CountOfCustomProperties; i++)
{
    string propertyName = documentProperties.GetCustomPropertyName(i);
    object propertyValue = documentProperties[propertyName];

    // Wyświetl nazwę i wartość własnej właściwości.
    Console.WriteLine("Custom property name : " + propertyName);
    Console.WriteLine("Custom property value : " + propertyValue);

    // Zmień wartość własnej właściwości.
    documentProperties[propertyName] = "New Value " + (i + 1);
}

// Zapisz prezentację do pliku.
presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **Przykład na żywo**

Wypróbuj internetową aplikację [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/pl/metadata), aby zobaczyć, jak pracować z właściwościami dokumentu przy użyciu API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/pl/metadata)

## ***FAQ**

### Jak mogę usunąć wbudowaną właściwość z prezentacji?

Wbudowane właściwości są integralną częścią prezentacji i nie mogą być całkowicie usunięte. Można jednak zmienić ich wartości lub ustawić je jako puste, jeśli dana właściwość na to pozwala.

### Co się stanie, jeśli dodam niestandardową właściwość, która już istnieje?

Jeśli dodasz niestandardową właściwość, która już istnieje, jej istniejąca wartość zostanie nadpisana nową. Nie musisz usuwać ani sprawdzać właściwości wcześniej, ponieważ Aspose.Slides automatycznie aktualizuje wartość właściwości.

### Czy mogę uzyskać dostęp do właściwości prezentacji bez pełnego wczytywania prezentacji?

Tak, możesz uzyskać dostęp do właściwości prezentacji bez pełnego wczytywania jej, używając metody `GetPresentationInfo` z klasy [PresentationFactory](https://reference.aspose.com/slides/pl/net/aspose.slides/presentationfactory/). Następnie wykorzystaj metodę `ReadDocumentProperties` udostępnioną przez interfejs [IPresentationInfo](https://reference.aspose.com/slides/pl/net/aspose.slides/ipresentationinfo/), aby efektywnie odczytać właściwości, oszczędzając pamięć i zwiększając wydajność.