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
- Modyfikacja właściwości
- Metadane dokumentu
- Edycja metadanych
- Język korekty
- Język domyślny
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Mistrzowskie zarządzanie właściwościami prezentacji w Aspose.Slides dla .NET oraz usprawnienie wyszukiwania, brandingu i przepływu pracy w plikach PowerPoint i OpenDocument."
---
## **Wprowadzenie**

Aspose.Slides for .NET obsługuje dwa rodzaje właściwości dokumentu: **Wbudowane** i **Niestandardowe**. Oba typy tych właściwości można łatwo uzyskać i zarządzać nimi przy użyciu API Aspose.Slides for .NET.

Aspose.Slides umożliwia pracę z właściwościami dokumentu prezentacji za pośrednictwem interfejsu [IDocumentProperties](https://reference.aspose.com/slides/pl/net/aspose.slides/idocumentproperties/) . Instancja tego interfejsu jest zwracana przez [IPresentation.DocumentProperties](https://reference.aspose.com/slides/pl/net/aspose.slides/ipresentation/documentproperties/). Poniższe przykłady pokazują, jak odczytywać, modyfikować i zarządzać tymi właściwościami.

{{% alert color="info" title="Note" %}}
Należy zauważyć, że pola **Application** i **Producer** nie mogą być modyfikowane, ponieważ zawsze wyświetlają "Aspose Ltd." i "Aspose.Slides for .NET x.x.x".
{{% /alert %}} 

## **Zarządzanie właściwościami prezentacji**

Microsoft PowerPoint udostępnia funkcję dodawania właściwości do plików prezentacji. Te właściwości dokumentu umożliwiają przechowywanie przydatnych informacji razem z plikami. Istnieją dwa typy właściwości dokumentu:

- Właściwości systemowe (wbudowane)
- Właściwości definiowane przez użytkownika (niestandardowe)

**Wbudowane** właściwości zawierają ogólne informacje o dokumencie, takie jak tytuł dokumentu, nazwisko autora, statystyki dokumentu i inne.

**Niestandardowe** właściwości są definiowane przez użytkowników jako pary **Nazwa/Wartość**, przy czym zarówno nazwa, jak i wartość są określane przez użytkownika.

Korzystając z Aspose.Slides for .NET, programiści mogą uzyskać dostęp i modyfikować zarówno wbudowane, jak i niestandardowe właściwości.

Microsoft PowerPoint pozwala użytkownikom zarządzać właściwościami dokumentu, klikając ikonę Office, a następnie wybierając **Plik → Informacje → Właściwości**. Po wybraniu **Zaawansowane właściwości** pojawia się okno dialogowe, w którym można zarządzać wszystkimi właściwościami dokumentu pliku prezentacji.

W oknie dialogowym **Właściwości** znajduje się kilka kart, takich jak **Ogólne**, **Podsumowanie**, **Statystyki**, **Zawartość** i **Niestandardowe**. Każda karta udostępnia opcje konfigurowania określonych typów informacji związanych z plikiem PowerPoint. Karta **Niestandardowe** służy do zarządzania właściwościami definiowanymi przez użytkownika.

## **Odczyt publicznych właściwości zaszyfrowanej prezentacji**

Hasło otwierające z reguły chroni zarówno zawartość prezentacji, jak i właściwości dokumentu. Gdy prezentacja jest zaszyfrowana przy użyciu [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/pl/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) ustawionego na `false`, jej właściwości pozostają publiczne. Aplikacja może wtedy ustawić [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/pl/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) na `true` i odczytać publiczne metadane bez podawania hasła otwierającego.

`OnlyLoadDocumentProperties` kontroluje, co Aspose.Slides ładuje; nie odszyfrowuje niczego. Jeśli właściwości były objęte szyfrowaniem, ich ładowanie bez hasła kończy się niepowodzeniem. Jeśli prezentacja nie jest zaszyfrowana, opcja jest ignorowana i ładowana jest pełna prezentacja.

Poniższy przykład weryfikuje tryb ładowania przy użyciu [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/pl/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/) i następnie odczytuje wbudowane właściwości za pośrednictwem [IPresentation.DocumentProperties](https://reference.aspose.com/slides/pl/net/aspose.slides/ipresentation/documentproperties/):

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { OnlyLoadDocumentProperties = true };
using var presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);

if (presentation.ProtectionManager.IsOnlyDocumentPropertiesLoaded)
{
    var properties = presentation.DocumentProperties;

    Console.WriteLine("Author: " + properties.Author);
    Console.WriteLine("Title: " + properties.Title);
    Console.WriteLine("Keywords: " + properties.Keywords);
}
else
{
    Console.WriteLine("The presentation was not loaded in document-properties-only mode.");
}
```

W tym trybie zawartość slajdów nie jest ładowana. Slajdy, wzorce, układy, kształty, media i inne obiekty prezentacji są niedostępne. Aplikacje powinny zawsze sprawdzać `IsOnlyDocumentPropertiesLoaded` przed wykonaniem operacji wymagającej pełnego modelu obiektowego prezentacji.

{{% alert color="warning" title="Security" %}}
Publiczne metadane mogą ujawnić imiona i nazwiska autorów, tytuły, tematy, słowa kluczowe, informacje o firmie, komentarze oraz wartości niestandardowe. Zaszyfruj wrażliwe właściwości razem z prezentacją. Pozostaw je publiczne wyłącznie wtedy, gdy systemy indeksowania, klasyfikacji, wyszukiwania lub zarządzania dokumentami mają konkretny wymóg dostępu do nich bez hasła.
{{% /alert %}}

## **Aktualizacja właściwości zaszyfrowanej prezentacji**

W przypadku zaszyfrowanego pliku PPTX prezentacja załadowana z `OnlyLoadDocumentProperties` służy do odczytu publicznych metadanych. Aspose.Slides nie może zapisać zmienionych właściwości z tego obiektu zawierającego jedynie metadane, ponieważ publiczne właściwości muszą pozostać spójne z odpowiadającymi danymi wewnątrz zaszyfrowanej prezentacji. Aktualizacja ich wymaga więc poprawnego hasła otwierającego i pełnego ładowania.

Poniższy przykład otwiera prezentację przy użyciu [LoadOptions.Password](https://reference.aspose.com/slides/pl/net/aspose.slides/loadoptions/password/), aktualizuje publiczne wbudowane właściwości i zapisuje wynik. Następnie używa [IPresentationInfo.IsEncrypted](https://reference.aspose.com/slides/pl/net/aspose.slides/ipresentationinfo/isencrypted/) do weryfikacji, czy szyfrowanie zostało zachowane, i ponownie otwiera publiczne metadane bez hasła, aby sprawdzić nowe wartości:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

const string inputPath = "public-properties-encrypted.pptx";
const string outputPath = "updated-public-properties-encrypted.pptx";

{
    var loadOptions = new LoadOptions { Password = "open_password" };
    using var presentation = new Presentation(inputPath, loadOptions);

    presentation.DocumentProperties.Title = "Updated Product Roadmap";
    presentation.DocumentProperties.Keywords = "roadmap, planning, indexed";
    presentation.Save(outputPath, SaveFormat.Pptx);
}

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(outputPath);
Console.WriteLine("The presentation is encrypted: " + presentationInfo.IsEncrypted);

var metadataLoadOptions = new LoadOptions { OnlyLoadDocumentProperties = true };
using var metadataPresentation = new Presentation(outputPath, metadataLoadOptions);

if (metadataPresentation.ProtectionManager.IsOnlyDocumentPropertiesLoaded)
{
    Console.WriteLine("Title: " + metadataPresentation.DocumentProperties.Title);
    Console.WriteLine("Keywords: " + metadataPresentation.DocumentProperties.Keywords);
}
else
{
    Console.WriteLine("The presentation was not loaded in document-properties-only mode.");
}
```

Jeśli aplikacja nie ma uprawnień do odszyfrowania lub załadowania zawartości prezentacji, musi traktować publiczne właściwości zaszyfrowanego pliku PPTX jako tylko do odczytu.

## **Dostęp do wbudowanych właściwości**

Właściwości te, udostępniane przez interfejs [IDocumentProperties](https://reference.aspose.com/slides/pl/net/aspose.slides/idocumentproperties/), obejmują: **Creator** (Autor), **Description**, **Keywords**, **Created** (Data utworzenia), **Modified** (Data modyfikacji), **Printed** (Data ostatniego wydruku), **LastModifiedBy**, **SharedDoc** (wskazuje, czy dokument jest współdzielony między różnymi producentami), **PresentationFormat**, **Subject**, **Title** i inne.

```cs
using Aspose.Slides;

// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
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

## **Modyfikacja wbudowanych właściwości**

Modyfikowanie wbudowanych właściwości plików prezentacji jest tak samo proste, jak ich odczytywanie. Wystarczy przypisać wartość typu string do dowolnej żądanej właściwości, a jej wartość zostanie zaktualizowana. W poniższym przykładzie pokazujemy, jak zmodyfikować wbudowane właściwości dokumentu prezentacji.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
using Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");

// Uzyskaj referencję do obiektu typu IDocumentProperties powiązanego z prezentacją.
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

Niestandardowe właściwości prezentacji umożliwiają programistom przechowywanie dodatkowych metadanych lub określonych informacji w pliku prezentacji. Aspose.Slides ułatwia tworzenie i zarządzanie tymi niestandardowymi właściwościami programowo. Poniższe przykłady demonstrują, jak dodać niestandardowe właściwości do Twoich prezentacji.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Utwórz instancję klasy Presentation.
using Presentation presentation = new Presentation();

// Pobierz referencję do obiektu typu IDocumentProperties powiązanego z prezentacją.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Dodaj niestandardowe właściwości.
documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

// Zapisz prezentację do pliku.
presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Dostęp i modyfikacja niestandardowych właściwości**

Aspose.Slides umożliwia także programistom dostęp do istniejących niestandardowych właściwości i łatwe modyfikowanie ich wartości. Funkcjonalność ta pomaga utrzymać dokładne metadane i wspiera dynamiczne aktualizacje w oparciu o dane wejściowe użytkownika lub logikę biznesową. Poniższe przykłady ilustrują, jak pobrać i zaktualizować wartości niestandardowych właściwości w ramach prezentacji.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Utwórz instancję klasy Presentation, która reprezentuje plik PPTX.
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// Uzyskaj referencję do obiektu typu IDocumentProperties powiązanego z prezentacją.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Uzyskaj dostęp i zmodyfikuj niestandardowe właściwości.
for (int i = 0; i < documentProperties.CountOfCustomProperties; i++)
{
    string propertyName = documentProperties.GetCustomPropertyName(i);
    object propertyValue = documentProperties[propertyName];

    // Wyświetl nazwę i wartość niestandardowej właściwości.
    Console.WriteLine("Custom property name : " + propertyName);
    Console.WriteLine("Custom property value : " + propertyValue);

    // Zmodyfikuj wartość niestandardowej właściwości.
    documentProperties[propertyName] = "New Value " + (i + 1);
}

// Zapisz prezentację do pliku.
presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **Przykład na żywo**

Wypróbuj aplikację online [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/pl/metadata), aby zobaczyć, jak pracować z właściwościami dokumentu przy użyciu API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/pl/metadata)

## **FAQ**

**Jak mogę usunąć wbudowaną właściwość z prezentacji?**

Wbudowane właściwości są integralną częścią prezentacji i nie mogą być całkowicie usunięte. Można jednak zmienić ich wartości lub ustawić je jako puste, jeśli dana właściwość na to pozwala.

**Co się stanie, jeśli dodam niestandardową właściwość, która już istnieje?**

Jeśli dodasz niestandardową właściwość, która już istnieje, jej dotychczasowa wartość zostanie nadpisana nową. Nie musisz usuwać ani sprawdzać właściwości wcześniej, ponieważ Aspose.Slides automatycznie aktualizuje jej wartość.

**Czy mogę uzyskać dostęp do właściwości prezentacji bez pełnego ładowania prezentacji?**

Tak. Użyj [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/pl/net/aspose.slides/presentationfactory/getpresentationinfo/) i następnie [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/pl/net/aspose.slides/ipresentationinfo/readdocumentproperties/), aby odczytać zapisane metadane dokumentu bez tworzenia instancji [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/). Zobacz [Build a Lightweight Presentation Inventory](/slides/pl/net/examine-presentation/) dla pełnego przykładu raportowania i ograniczeń specyficznych dla formatu.

**Czy mogę odczytać publiczne właściwości zaszyfrowanej prezentacji bez jej hasła otwierającego?**

Tak. Prezentacja musi być zaszyfrowana z ustawionym `EncryptDocumentProperties` na `false`, a musi być załadowana z `OnlyLoadDocumentProperties` ustawionym na `true`.

**Czy mogę zaktualizować zaszyfrowany plik PPTX w trybie tylko‑właściwości‑dokumentu?**

Nie. Publiczne i zaszyfrowane dane właściwości muszą pozostać spójne, więc aktualizacja zaszyfrowanego pliku PPTX wymaga pełnego załadowania prezentacji przy użyciu poprawnego hasła otwierającego.