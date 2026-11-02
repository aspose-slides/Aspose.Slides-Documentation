---
title: Zarządzanie właściwościami prezentacji w JavaScript
linktitle: Właściwości prezentacji
type: docs
weight: 70
url: /pl/nodejs-java/presentation-properties/
keywords:
- właściwości PowerPoint
- właściwości prezentacji
- właściwości dokumentu
- wbudowane właściwości
- niestandardowe właściwości
- zaawansowane właściwości
- zarządzanie właściwościami
- modyfikacja właściwości
- metadane dokumentu
- edycja metadanych
- język korekty
- język domyślny
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Opanuj właściwości prezentacji w Aspose.Slides for Node.js via Java i usprawnij wyszukiwanie, brandowanie oraz przepływ pracy w plikach PowerPoint i OpenDocument."
---
## **Wprowadzenie**

Aspose.Slides for Node.js via Java obsługuje **wbudowane** i **niestandardowe** właściwości dokumentu. Użyj tych właściwości, aby odczytać i zaktualizować metadane prezentacji, takie jak autor, tytuł oraz wartości określone przez użytkownika.

Aspose.Slides umożliwia pracę z właściwościami dokumentu prezentacji za pomocą klasy [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties). Instancja tej klasy jest zwracana przez [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties). Następujące przykłady pokazują, jak odczytywać, modyfikować i zarządzać tymi właściwościami.

{{% alert color="info" title="Note" %}}
Aspose.Slides zarządza metadanymi aplikacji i producenta podczas zapisywania prezentacji; pola te identyfikują oprogramowanie, które stworzyło wynik.
{{% /alert %}}

## **Zarządzanie właściwościami prezentacji**

Właściwości dokumentu przechowują opisowe informacje wraz z treścią prezentacji. Dzielą się na dwie kategorie:

- **Wbudowane właściwości** zawierają standardowe metadane, takie jak tytuł, autor i statystyki dokumentu.
- **Niestandardowe właściwości** przechowują pary nazwa/wartość określone przez użytkownika.

Aspose.Slides for Node.js via Java zapewnia dostęp do obu kategorii. W PowerPoint wybierz **Plik → Informacje → Właściwości → Zaawansowane właściwości**, aby sprawdzić metadane dokumentu. Okno dialogowe grupuje informacje w zakładkach, takich jak **Podsumowanie**, **Statystyki**, **Zawartość** i **Niestandardowe**. Użyj zakładki **Niestandardowe**, aby zarządzać właściwościami określonymi przez użytkownika.

## **Odczyt publicznych właściwości z zaszyfrowanej prezentacji**

Hasło otwierające zwykle chroni zarówno treść prezentacji, jak i właściwości dokumentu. Gdy prezentacja jest szyfrowana po wywołaniu [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#setEncryptDocumentProperties) z wartością `false`, jej właściwości dokumentu pozostają publiczne. Aplikacja może wtedy wywołać [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) z `true` i odczytać publiczne metadane bez podawania hasła otwierającego.

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) kontroluje, co Aspose.Slides ładuje; nie odszyfrowuje niczego. Jeśli właściwości zostały uwzględnione w szyfrowaniu, ich ładowanie bez hasła kończy się niepowodzeniem. Jeśli prezentacja nie jest szyfrowana, opcja jest ignorowana i ładowana jest cała prezentacja.

Przykład wymaga zaszyfrowanej prezentacji, której właściwości dokumentu zostały pozostawione publiczne. Weryfikuje tryb ładowania przy użyciu [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#isOnlyDocumentPropertiesLoaded) i następnie odczytuje wbudowane właściwości przez [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties):

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

const presentation = new slides.Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        const documentProperties = presentation.getDocumentProperties();

        console.log("Author: " + documentProperties.getAuthor());
        console.log("Title: " + documentProperties.getTitle());
        console.log("Keywords: " + documentProperties.getKeywords());
    } else {
        console.log("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

W tym trybie zawartość slajdów nie jest ładowana. Slajdy, mastery, układy, kształty, media i inne obiekty prezentacji są niedostępne. Aplikacje powinny zawsze sprawdzać [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#isOnlyDocumentPropertiesLoaded) przed wykonaniem operacji wymagającej pełnego modelu obiektowego prezentacji.

{{% alert color="warning" title="Warning" %}}
Publiczne metadane mogą ujawnić nazwiska autorów, tytuły, tematy, słowa kluczowe, informacje o firmie, komentarze i wartości niestandardowe. Zaszyfruj wrażliwe właściwości razem z prezentacją. Pozostaw je publiczne tylko wtedy, gdy systemy indeksowania, klasyfikacji, wyszukiwania lub zarządzania dokumentami mają konkretny wymóg dostępu do nich bez hasła.
{{% /alert %}}

## **Aktualizacja właściwości zaszyfrowanej prezentacji**

Dla zaszyfrowanego pliku PPTX prezentacja załadowana po wywołaniu [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) z `true` jest przeznaczona do odczytu publicznych metadanych. Aspose.Slides nie może zapisać zmienionych właściwości z tego obiektu zawierającego wyłącznie metadane, ponieważ publiczne właściwości muszą pozostać zgodne z odpowiadającymi danymi w zaszyfrowanej prezentacji. Aktualizacja wymaga więc prawidłowego hasła otwierającego i pełnego załadowania.

Przykład wymaga zaszyfrowanej prezentacji PPTX z publicznymi właściwościami dokumentu oraz znanym hasłem otwierającym. Otwiera pełną prezentację przy użyciu [LoadOptions.setPassword](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setPassword), aktualizuje publiczne wbudowane właściwości i zapisuje wynik. Następnie używa [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#isEncrypted), aby zweryfikować, że szyfrowanie zostało zachowane, i ponownie otwiera publiczne metadane bez hasła w celu sprawdzenia nowych wartości:

```javascript
const slides = require("aspose.slides.via.java");

const inputPath = "public-properties-encrypted.pptx";
const outputPath = "updated-public-properties-encrypted.pptx";

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation(inputPath, loadOptions);
try {
    const documentProperties = presentation.getDocumentProperties();
    documentProperties.setTitle("Updated Product Roadmap");
    documentProperties.setKeywords("roadmap, planning, indexed");
    
    presentation.save(outputPath, slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo(outputPath);
console.log("The presentation is encrypted: " + presentationInfo.isEncrypted());

const metadataLoadOptions = new slides.LoadOptions();
metadataLoadOptions.setOnlyLoadDocumentProperties(true);

const metadataPresentation = new slides.Presentation(outputPath, metadataLoadOptions);
try {
    if (metadataPresentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        console.log("Title: " + metadataPresentation.getDocumentProperties().getTitle());
        console.log("Keywords: " + metadataPresentation.getDocumentProperties().getKeywords());
    } else {
        console.log("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    metadataPresentation.dispose();
}
```

Jeśli aplikacja nie ma uprawnień do odszyfrowania lub załadowania zawartości prezentacji, musi traktować publiczne właściwości zaszyfrowanego pliku PPTX jako tylko do odczytu.

## **Dostęp do wbudowanych właściwości**

Klasa [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties) udostępnia wbudowane metadane za pomocą metod getter, w tym [getAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getAuthor), [getTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getTitle) oraz [getCreatedTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCreatedTime). Ten przykład otwiera istniejącą prezentację i wypisuje jej zapisane metadane w konsoli. Wartości zależą od wejściowej prezentacji; niektóre pola mogą być puste.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("AccessBuiltInProperties.pptx");
try {
    const documentProperties = presentation.getDocumentProperties();

    console.log("Category: " + documentProperties.getCategory());
    console.log("Content status: " + documentProperties.getContentStatus());
    console.log("Creation date: " + documentProperties.getCreatedTime());
    console.log("Author: " + documentProperties.getAuthor());
    console.log("Comments: " + documentProperties.getComments());
    console.log("Keywords: " + documentProperties.getKeywords());
    console.log("Last modified by: " + documentProperties.getLastSavedBy());
    console.log("Manager: " + documentProperties.getManager());
    console.log("Modified date: " + documentProperties.getLastSavedTime());
    console.log("Presentation format: " + documentProperties.getPresentationFormat());
    console.log("Last print date: " + documentProperties.getLastPrinted());
    console.log("Is shared between producers: " + documentProperties.getSharedDoc());
    console.log("Subject: " + documentProperties.getSubject());
    console.log("Title: " + documentProperties.getTitle());
} finally {
    presentation.dispose();
}
```

## **Modyfikacja wbudowanych właściwości**

Aby zaktualizować wbudowane metadane, użyj metod setter na obiekcie zwróconym przez [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties). Ten przykład otwiera istniejącą prezentację, wywołuje [setAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setAuthor), [setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setTitle), [setSubject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setSubject), [setComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setComments) oraz [setManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setManager), a następnie zapisuje zaktualizowaną prezentację przy użyciu [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save). Zapisany plik PPTX zawiera nowe metadane.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("ModifyBuiltInProperties.pptx");
try {
    const documentProperties = presentation.getDocumentProperties();

    documentProperties.setAuthor("Aspose.Slides for Node.js via Java");
    documentProperties.setTitle("Manage PowerPoint Presentation Properties");
    documentProperties.setSubject("Modify Built-in Properties");
    documentProperties.setComments("Aspose description");
    documentProperties.setManager("Aspose manager");

    presentation.save("DocumentProperties_output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Zarządzanie podstawą hiperłącz**

[DocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getHyperlinkBase) zwraca bazę dokumentu dla względnych hiperłączy. Użyj [DocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setHyperlinkBase), aby zmienić ją lub wyczyścić. Jest to przydatne przy przenoszeniu prezentacji i powiązanych plików w inne miejsce. Jest to oddzielne od indywidualnego hiperłącza metodą [Hyperlink.getExternalUrl](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getExternalUrl): zmiana bazy nie przepisuje zapisanych adresów linków ani nie zmienia docelowych ścieżek bezwzględnych.

Przykład wymaga prezentacji zawierającej zarówno względny link, np. `target.html`, jak i bezwzględny link, np. `https://example.org/absolute.html`. Odczytuje istniejącą bazę, przypisuje nowy adres bazy i zapisuje oraz ponownie otwiera prezentację, aby sprawdzić wartość. Następnie wyczyści bazę pustym ciągiem i weryfikuje pustą wartość w osobnym zapisanym pliku. Zamień przykładowy adres bazy na lokalizację swoich plików powiązanych.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("hyperlinks.pptx");
try {
    console.log("Original base: " + presentation.getDocumentProperties().getHyperlinkBase());

    const newBase = "https://example.com/new/";
    presentation.getDocumentProperties().setHyperlinkBase(newBase);
    presentation.save("hyperlinks-updated.pptx", slides.SaveFormat.Pptx);

    const updatedPresentation = new slides.Presentation("hyperlinks-updated.pptx");
    try {
        console.log("Base preserved: " + (newBase === updatedPresentation.getDocumentProperties().getHyperlinkBase()));

        updatedPresentation.getDocumentProperties().setHyperlinkBase("");
        updatedPresentation.save("hyperlinks-cleared.pptx", slides.SaveFormat.Pptx);

        const clearedPresentation = new slides.Presentation("hyperlinks-cleared.pptx");
        try {
            console.log("Base cleared: " + ("" === clearedPresentation.getDocumentProperties().getHyperlinkBase()));
        } finally {
            clearedPresentation.dispose();
        }
    } finally {
        updatedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

Dwie wiadomości weryfikacyjne powinny wypisać `true`. Czyszczenie bazy nie zmienia adresów poszczególnych hiperłączy.

Względny link do `target.pptx` otwierał `old/target.pptx`, gdy baza wskazywała folder `old`. Po zmianie bazy na folder `new`, zapisaniu i ponownym otwarciu prezentacji ten sam link otwierał `new/target.pptx`. Link bezwzględny nadal otwierał ten sam plik. Przetestuj swoje względne linki w PowerPoint przed i po przeniesieniu prezentacji lub zmianie jej bazy.

## **Dodawanie niestandardowych właściwości prezentacji**

Niestandardowe właściwości przechowują metadane, które nie mają odpowiadającego wbudowanego pola. Metoda [DocumentProperties.set_Item](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#set_Item) pozwala przypisać wartość po nazwie właściwości. Ten przykład tworzy prezentację, dodaje dwie wartości tekstowe i jedną wartość wersji całkowitej, a następnie zapisuje prezentację przy użyciu [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save). Przypisanie wartości do istniejącej nazwy zastępuje wartość tej właściwości.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const documentProperties = presentation.getDocumentProperties();

    documentProperties.set_Item("Reviewed by", "John Smith");
    documentProperties.set_Item("Confidentiality level", "Internal");
    documentProperties.set_Item("Document version", 2);

    presentation.save("CustomDocumentProperties_output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Dostęp i modyfikacja niestandardowych właściwości**

Ten przykład otwiera prezentację zawierającą niestandardowe właściwości i wykorzystuje [getCountOfCustomProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCountOfCustomProperties) do iteracji po nich. [getCustomPropertyName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCustomPropertyName) przyjmuje indeks zerowy i zwraca nazwę używaną przez [DocumentProperties.set_Item](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#set_Item). Przykład wypisuje każdą oryginalną nazwę i wartość, zastępuje każdą wartość numerowanym ciągiem niezależnie od oryginalnego typu i zapisuje zmiany. Jeśli nie ma niestandardowych właściwości, pętla nie wprowadza zmian.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("AccessAndModifyProperties.pptx");
try {
    const documentProperties = presentation.getDocumentProperties();

    for (let i = 0; i < documentProperties.getCountOfCustomProperties(); i++) {
        const propertyName = documentProperties.getCustomPropertyName(i);
        const propertyValue = documentProperties.get_Item(propertyName);

        console.log("Custom property name: " + propertyName);
        console.log("Custom property value: " + propertyValue);

        documentProperties.set_Item(propertyName, "New Value " + (i + 1));
    }

    presentation.save("CustomProperties_output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Przykład na żywo**

Wypróbuj aplikację online [**Zobacz i edytuj metadane PowerPoint**](https://products.aspose.app/slides/metadata), aby zobaczyć, jak pracować z właściwościami dokumentu przy użyciu API Aspose.Slides:

[![Zobacz i edytuj metadane PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**Jak mogę usunąć wbudowaną właściwość z prezentacji?**

Wbudowane właściwości są integralną częścią prezentacji i nie mogą być całkowicie usunięte. Można jednak zmienić ich wartości lub ustawić je jako puste, o ile dana właściwość na to pozwala.

**Co się stanie, jeśli dodam niestandardową właściwość, która już istnieje?**

Jeśli dodasz niestandardową właściwość, która już istnieje, jej dotychczasowa wartość zostanie nadpisana nową. Nie musisz usuwać ani sprawdzać właściwości wcześniej, ponieważ Aspose.Slides automatycznie aktualizuje wartość właściwości.

**Czy mogę uzyskać dostęp do właściwości prezentacji bez pełnego ładowania prezentacji?**

Tak. Użyj [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationFactory#getPresentationInfo), a następnie [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties), aby odczytać zapisane metadane dokumentu bez tworzenia instancji [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation). Zobacz przykład pełnego raportowania w [Build a Lightweight Presentation Inventory](/slides/pl/nodejs-java/examine-presentation/) oraz ograniczenia specyficzne dla formatów.

**Czy mogę odczytać publiczne właściwości zaszyfrowanej prezentacji bez jej hasła otwierającego?**

Tak. Prezentacja musi być zaszyfrowana po wywołaniu [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#setEncryptDocumentProperties) z `false`, a następnie ładowana po wywołaniu [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) z `true`.

**Czy mogę zaktualizować zaszyfrowany plik PPTX w trybie tylko-właściwości-dokumentu?**

Nie. Publiczne i zaszyfrowane dane właściwości muszą pozostać spójne, więc aktualizacja zaszyfrowanego pliku PPTX wymaga pełnego załadowania prezentacji z prawidłowym hasłem otwierającym.