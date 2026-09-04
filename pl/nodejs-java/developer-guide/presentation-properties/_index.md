---
title: Zarządzanie właściwościami prezentacji w JavaScript
linktitle: Właściwości prezentacji
type: docs
weight: 70
url: /pl/nodejs-java/presentation-properties/
keywords:
- Właściwości PowerPoint
- Właściwości prezentacji
- Właściwości dokumentu
- Wbudowane właściwości
- Własne właściwości
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Opanuj właściwości prezentacji w Aspose.Slides for Node.js via Java i usprawnij wyszukiwanie, branding oraz przepływ pracy w swoich plikach PowerPoint i OpenDocument."
---
## **Wprowadzenie**

Aspose.Slides obsługuje dwa typy właściwości dokumentu: **Built-in** i **Custom**. Oba te typy właściwości można łatwo uzyskać i zarządzać nimi przy użyciu API Aspose.Slides.

Aspose.Slides umożliwia pracę z właściwościami dokumentu prezentacji za pośrednictwem klasy [DocumentProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/documentproperties/). Instancja tej klasy jest zwracana przez metodę [Presentation.getDocumentProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#getDocumentProperties). Poniższe przykłady pokazują, jak odczytywać, modyfikować i zarządzać tymi właściwościami.

{{% alert color="info" title="Note" %}}
Uwaga: pola **Application** i **AppVersion** nie mogą być modyfikowane. Aspose.Slides nadpisuje je przy każdym zapisie, więc zapisana prezentacja zawsze raportuje „Aspose.Slides for Node.js via Java” oraz wersję biblioteki, która ją wygenerowała. Każda wartość przekazana do `setNameOfApplication` jest odrzucana podczas zapisu prezentacji.
{{% /alert %}} 

## **Zarządzanie właściwościami prezentacji**

Microsoft PowerPoint udostępnia funkcję dodawania pewnych właściwości do plików prezentacji. Te własności dokumentu pozwalają na przechowywanie przydatnych informacji wraz z dokumentami (plikami prezentacji). Istnieją dwa rodzaje właściwości dokumentu, jak poniżej:

- System Defined (Built-in) Properties
- User-Defined (Custom) Properties

**Built-in** właściwości zawierają ogólne informacje o dokumencie, takie jak tytuł dokumentu, imię autora, statystyki dokumentu itp. **Custom** właściwości są definiowane przez użytkowników jako pary **Name/Value**, gdzie zarówno nazwa, jak i wartość są określone przez użytkownika. Korzystając z Aspose.Slides for Node.js via Java, deweloperzy mogą uzyskać dostęp i modyfikować wartości zarówno wbudowanych, jak i własnych właściwości.

## **Właściwości dokumentu w PowerPoint**

Microsoft PowerPoint 2007 umożliwia zarządzanie właściwościami dokumentu plików prezentacji. Wystarczy kliknąć ikonę Office, a następnie wybrać pozycję menu **Prepare | Properties | Advanced Properties** w programie Microsoft PowerPoint 2007, jak pokazano poniżej:

|**Wybór pozycji menu Advanced Properties**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Po wybraniu pozycji menu **Advanced Properties** pojawi się dialog umożliwiający zarządzanie właściwościami dokumentu pliku PowerPoint, jak pokazano poniżej na rysunku:

|**Dialog właściwości**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

W powyższym **Properties Dialog** można zobaczyć wiele kart, takich jak **General**, **Summary**, **Statistics**, **Contents** oraz **Custom**. Wszystkie te karty umożliwiają konfigurowanie różnych rodzajów informacji związanych z plikami PowerPoint. Karta **Custom** służy do zarządzania własnymi właściwościami plików PowerPoint.

## **Praca z właściwościami dokumentu przy użyciu Aspose.Slides for Node.js via Java**

Jak opisano wcześniej, Aspose.Slides for Node.js via Java obsługuje dwa rodzaje właściwości dokumentu, czyli **Built-in** i **Custom**. Dzięki temu deweloperzy mogą uzyskać dostęp do obu rodzajów właściwości za pomocą API Aspose.Slides for Node.js via Java. Aspose.Slides for Node.js via Java udostępnia klasę [DocumentProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/documentproperties) , która reprezentuje właściwości dokumentu powiązane z plikiem prezentacji poprzez właściwość **Presentation.DocumentProperties**.

Deweloperzy mogą używać właściwości **DocumentProperties** udostępnionej przez obiekt [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation) , aby uzyskać dostęp do właściwości dokumentu plików prezentacji, jak opisano poniżej:

## **Odczyt publicznych właściwości z zaszyfrowanej prezentacji**

Hasło otwierające zazwyczaj chroni zarówno zawartość prezentacji, jak i właściwości dokumentu. Gdy prezentacja jest szyfrowana poprzez przekazanie `false` do [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties), jej właściwości pozostają publiczne. Następnie aplikacja może przekazać `true` do [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties), aby odczytać publiczne metadane bez podawania hasła otwierającego.

Opcja ładowania wyłącznie właściwości dokumentu kontroluje, co Aspose.Slides ładuje; nie dokonuje ona odszyfrowania. Jeśli właściwości były objęte szyfrowaniem, ich ładowanie bez hasła kończy się niepowodzeniem. Jeśli prezentacja nie jest szyfrowana, opcja jest ignorowana i ładowana zostaje pełna prezentacja.

Przykład poniżej weryfikuje tryb ładowania przy użyciu [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) i następnie odczytuje wbudowane właściwości przez [Presentation.getDocumentProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#getDocumentProperties):

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

const presentation = new slides.Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        const properties = presentation.getDocumentProperties();

        console.log("Author: " + properties.getAuthor());
        console.log("Title: " + properties.getTitle());
        console.log("Keywords: " + properties.getKeywords());
    } else {
        console.log("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

W tym trybie zawartość slajdów nie jest ładowana. Slajdy, mastery, układy, kształty, media i inne obiekty prezentacji są niedostępne. Aplikacje powinny zawsze sprawdzać [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) przed wykonaniem operacji wymagającej pełnego modelu obiektowego prezentacji.

{{% alert color="warning" title="Warning" %}}
Publiczne metadane mogą ujawniać nazwiska autorów, tytuły, tematy, słowa kluczowe, informacje o firmie, komentarze oraz własne wartości. Szyfruj wrażliwe właściwości razem z prezentacją. Pozostaw je publiczne wyłącznie wtedy, gdy systemy indeksowania, klasyfikacji, wyszukiwania lub zarządzania dokumentami mają konkretny wymóg dostępu do nich bez hasła.
{{% /alert %}}

## **Aktualizacja właściwości zaszyfrowanej prezentacji**

Dla zaszyfrowanego pliku PPTX, prezentacja załadowana w trybie wyłącznie właściwości dokumentu służy do odczytu publicznych metadanych. Aspose.Slides nie może zapisać zmienionych właściwości z tego obiektu zawierającego tylko metadane, ponieważ publiczne właściwości muszą pozostać zgodne z odpowiadającymi danymi wewnątrz zaszyfrowanej prezentacji. Aktualizacja wymaga więc prawidłowego hasła otwierającego i pełnego załadowania.

Poniższy przykład otwiera prezentację przy użyciu [LoadOptions.setPassword](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/loadoptions/#setPassword), aktualizuje publiczne wbudowane właściwości i zapisuje wynik. Następnie używa [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentationinfo/#isEncrypted), aby zweryfikować, że szyfrowanie zostało zachowane, i ponownie otwiera publiczne metadane bez hasła, aby sprawdzić nowe wartości:

```javascript
const slides = require("aspose.slides.via.java");

const inputPath = "public-properties-encrypted.pptx";
const outputPath = "updated-public-properties-encrypted.pptx";

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation(inputPath, loadOptions);
try {
    presentation.getDocumentProperties().setTitle("Updated Product Roadmap");
    presentation.getDocumentProperties().setKeywords("roadmap, planning, indexed");
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

Te właściwości udostępniane przez obiekt [DocumentProperties] obejmują: **Creator** (Autor), **Description**, **Keywords**, **Created** (Data utworzenia), **Modified** (Data modyfikacji), **Printed** (Data ostatniego wydruku), **LastModifiedBy**, **SharedDoc** (Czy udostępniono między różnymi twórcami?), **PresentationFormat**, **Subject** oraz **Title**.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Utwórz instancję klasy Presentation, która reprezentuje prezentację
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Utwórz odwołanie do obiektu IDocumentProperties powiązanego z prezentacją
    var dp = pres.getDocumentProperties();
    // Wyświetl wbudowane właściwości
    console.log("Category : " + dp.getCategory());
    console.log("Current Status : " + dp.getContentStatus());
    console.log("Creation Date : " + dp.getCreatedTime());
    console.log("Author : " + dp.getAuthor());
    console.log("Description : " + dp.getComments());
    console.log("KeyWords : " + dp.getKeywords());
    console.log("Last Modified By : " + dp.getLastSavedBy());
    console.log("Supervisor : " + dp.getManager());
    console.log("Modified Date : " + dp.getLastSavedTime());
    console.log("Presentation Format : " + dp.getPresentationFormat());
    console.log("Last Print Date : " + dp.getLastPrinted());
    console.log("Is Shared between producers : " + dp.getSharedDoc());
    console.log("Subject : " + dp.getSubject());
    console.log("Title : " + dp.getTitle());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Modyfikacja wbudowanych właściwości**

Modyfikacja wbudowanych właściwości plików prezentacji jest tak prosta, jak ich odczyt. Można po prostu przypisać wartość tekstową do dowolnej żądanej właściwości, a wartość zostanie zmodyfikowana. W poniższym przykładzie pokazujemy, jak można zmodyfikować wbudowane właściwości dokumentu prezentacji przy użyciu Aspose.Slides for Node.js via Java.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Utwórz odwołanie do obiektu IDocumentProperties powiązanego z prezentacją
    var dp = pres.getDocumentProperties();
    // Ustaw wbudowane właściwości
    dp.setAuthor("Aspose.Slides for Node.js via Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    // Zapisz prezentację do pliku
    pres.save("DocProps.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Ten przykład modyfikuje wbudowane właściwości prezentacji, co można zobaczyć poniżej:

|**Wbudowane właściwości dokumentu po modyfikacji**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Dodawanie własnych właściwości dokumentu**

Aspose.Slides for Node.js via Java umożliwia również deweloperom dodawanie własnych wartości do właściwości dokumentu prezentacji. Poniższy przykład pokazuje, jak ustawić własne właściwości dla prezentacji.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    // Pobieranie właściwości dokumentu
    var dProps = pres.getDocumentProperties();
    // Dodawanie własnych właściwości
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    // Pobieranie nazwy właściwości pod określonym indeksem
    var getPropertyName = dProps.getCustomPropertyName(2);
    // Usuwanie wybranej właściwości
    dProps.removeCustomProperty(getPropertyName);
    // Zapisywanie prezentacji
    pres.save("CustomDemo.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|**Dodane własne właściwości dokumentu**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Dostęp i modyfikacja własnych właściwości**

Aspose.Slides for Node.js via Java umożliwia również deweloperom dostęp do wartości własnych właściwości. Poniższy przykład pokazuje, jak możesz uzyskać dostęp i modyfikować wszystkie te własne właściwości prezentacji.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Utwórz odwołanie do obiektu DocumentProperties powiązanego z prezentacją
    var dp = pres.getDocumentProperties();
    // Uzyskaj dostęp i zmodyfikuj własne właściwości
    for (var i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Wyświetl nazwy i wartości własnych właściwości
        console.log("Custom Property Name : " + dp.getCustomPropertyName(i));
        console.log("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
        // Zmodyfikuj wartości własnych właściwości
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    // Zapisz prezentację do pliku
    pres.save("CustomDemoModified.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Ten przykład modyfikuje własne właściwości [PPTX ](https://docs.fileformat.com/presentation/pptx/) prezentacji. Poniższe rysunki pokazują własne właściwości prezentacji przed i po modyfikacji:

|**Własne właściwości przed modyfikacją**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Własne właściwości po modyfikacji**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Zaawansowane właściwości dokumentu**

{{% alert color="info" title="Note" %}}
Do klasy [PresentationInfo] zostały dodane nowe metody [ReadDocumentProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-), oraz [WriteBindedPresentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/PresentationInfo#writeBindedPresentation-java.lang.String-), a logika setter'a właściwości [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/documentproperties#setLastSavedTime-java.util.Date-) została zmieniona.
{{% /alert %}} 

Dwie nowe metody [ReadDocumentProperties] i [UpdateDocumentProperties] zostały dodane do klasy [PresentationInfo]. Zapewniają szybki dostęp do właściwości dokumentu oraz umożliwiają zmianę i aktualizację właściwości bez ładowania całej prezentacji.

Typowy scenariusz: załadować właściwości, zmienić jakąś wartość i zaktualizować dokument, można zaimplementować w następujący sposób:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// odczytaj informacje o prezentacji
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");
// pobierz bieżące właściwości
var props = info.readDocumentProperties();
// ustaw nowe wartości pól Author i Title
props.setAuthor("New Author");
props.setTitle("New Title");
// zaktualizuj prezentację nowymi wartościami
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Istnieje inny sposób użycia właściwości konkretnej prezentacji jako szablonu do aktualizacji właściwości w innych prezentacjach:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) {
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}

var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("template.pptx");
var template = info.readDocumentProperties();
template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");
updateByTemplate("doc1.pptx", template);
updateByTemplate("doc2.odp", template);
updateByTemplate("doc3.ppt", template);
```

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

Nowy szablon można utworzyć od zera, a następnie użyć go do aktualizacji wielu prezentacji:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) {
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}

var template = new aspose.slides.DocumentProperties();
template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");
updateByTemplate("doc1.pptx", template);
updateByTemplate("doc2.odp", template);
updateByTemplate("doc3.ppt", template);
```

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **Ustaw język korekty**

Aspose.Slides udostępnia właściwość LanguageId (udostępnianą przez klasę PortionFormat), która pozwala ustawić język korekty dla dokumentu PowerPoint. Język korekty to język, w którym sprawdzane są pisownia i gramatyka w PowerPoint.

Ten kod JavaScript pokazuje, jak ustawić język korekty dla PowerPoint: xxx Dlaczego właściwość LanguageId brakuje w klasie JavaScript PortionFormat?

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();
    var newPortion = new aspose.slides.Portion();
    var font = new aspose.slides.FontData("SimSun");
    var portionFormat = newPortion.getPortionFormat();
    portionFormat.setComplexScriptFont(font);
    portionFormat.setEastAsianFont(font);
    portionFormat.setLatinFont(font);
    portionFormat.setLanguageId("zh-CN");// ustaw identyfikator języka korekty
    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ustaw domyślny język**

Ten kod JavaScript pokazuje, jak ustawić domyślny język dla całej prezentacji PowerPoint:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");
var pres = new aspose.slides.Presentation(loadOptions);
try {
    // Dodaje nowy kształt prostokąta z tekstem
    var shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");
    // Sprawdza język pierwszej części
    console.log(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Przykład na żywo**

Wypróbuj aplikację online [**Aspose.Slides Metadata**](https://products.aspose.app/slides/pl/metadata), aby zobaczyć, jak pracować z właściwościami dokumentu za pomocą API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/pl/metadata)

## **FAQ**

**Jak mogę usunąć wbudowaną właściwość z prezentacji?**

Wbudowane właściwości są integralną częścią prezentacji i nie mogą być całkowicie usunięte. Jednak możesz zmienić ich wartości lub ustawić je jako puste, o ile dana właściwość na to pozwala.

**Co się stanie, jeśli dodam własną właściwość, która już istnieje?**

Jeśli dodasz własną właściwość, która już istnieje, jej istniejąca wartość zostanie nadpisana nową. Nie musisz usuwać ani sprawdzać właściwości wcześniej, ponieważ Aspose.Slides automatycznie aktualizuje wartość właściwości.

**Czy mogę uzyskać dostęp do właściwości prezentacji bez pełnego ładowania prezentacji?**

Tak. Użyj [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) a następnie [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/), aby odczytać przechowywane metadane dokumentu bez tworzenia instancji [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/). Zobacz [Build a Lightweight Presentation Inventory](/slides/pl/nodejs-java/examine-presentation/) po pełny przykład raportowania i ograniczenia specyficzne dla formatu.

**Czy mogę odczytać publiczne właściwości zaszyfrowanej prezentacji bez jej hasła otwierającego?**

Tak. Szyfrowanie właściwości dokumentu musiało być wyłączone przed zaszyfrowaniem prezentacji, a prezentacja musi być załadowana w trybie wyłącznie właściwości dokumentu.

**Czy mogę zaktualizować zaszyfrowany plik PPTX w trybie wyłącznie właściwości dokumentu?**

Nie. Dane publicznych i zaszyfrowanych właściwości muszą pozostać spójne, więc aktualizacja zaszyfrowanego pliku PPTX wymaga załadowania pełnej prezentacji z prawidłowym hasłem otwierającym.