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
- Prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Opanuj właściwości prezentacji w Aspose.Slides for Node.js via Java i usprawnij wyszukiwanie, branding oraz przepływ pracy w swoich plikach PowerPoint i OpenDocument."
---
## **Wstęp**

Aspose.Slides obsługuje dwa typy właściwości dokumentu: **Wbudowane** i **Niestandardowe**. Oba te typy właściwości można łatwo uzyskać i zarządzać przy użyciu API Aspose.Slides.

Aspose.Slides umożliwia pracę z właściwościami dokumentu prezentacji za pośrednictwem klasy [DocumentProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/documentproperties/) . Instancja tej klasy jest zwracana przez metodę [Presentation.getDocumentProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#getDocumentProperties) . Poniższe przykłady pokazują, jak odczytywać, modyfikować i zarządzać tymi właściwościami.

{{% alert color="info" title="Note" %}}
Należy pamiętać, że pola **Application** i **AppVersion** nie mogą być modyfikowane. Aspose.Slides nadpisuje je przy każdym zapisie, więc zapisana prezentacja zawsze raportuje „Aspose.Slides for Node.js via Java” oraz wersję biblioteki, która ją utworzyła. Każda wartość przekazana do `setNameOfApplication` jest odrzucana podczas zapisu prezentacji.
{{% /alert %}} 

## **Zarządzanie właściwościami prezentacji**

Microsoft PowerPoint udostępnia funkcję umożliwiającą dodawanie właściwości do plików prezentacji. Te właściwości dokumentu pozwalają przechowywać przydatne informacje razem z dokumentami (plikami prezentacji). Istnieją dwa rodzaje właściwości dokumentu, jak poniżej

- Właściwości systemowe (Wbudowane)
- Właściwości definiowane przez użytkownika (Niestandardowe)

**Wbudowane** właściwości zawierają ogólne informacje o dokumencie, takie jak tytuł dokumentu, nazwa autora, statystyki dokumentu itp. **Niestandardowe** właściwości to te definiowane przez użytkowników jako pary **Nazwa/Wartość**, gdzie zarówno nazwa, jak i wartość są określane przez użytkownika. Korzystając z Aspose.Slides for Node.js via Java, deweloperzy mogą uzyskać dostęp i modyfikować wartości wbudowanych oraz niestandardowych właściwości.

## **Właściwości dokumentu w programie PowerPoint**

Microsoft PowerPoint 2007 umożliwia zarządzanie właściwościami dokumentu plików prezentacji. Wszystko, co musisz zrobić, to kliknąć ikonę Office, a następnie wybrać pozycję menu **Prepare | Properties | Advanced Properties** w Microsoft PowerPoint 2007, jak pokazano poniżej:

|**Wybór pozycji menu Advanced Properties**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Po wybraniu pozycji menu **Advanced Properties** pojawi się okno dialogowe umożliwiające zarządzanie właściwościami dokumentu pliku PowerPoint, jak pokazano poniżej na rysunku:

|**Okno właściwości**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

W powyższym **Oknie właściwości** można zobaczyć wiele kart, takich jak **General**, **Summary**, **Statistics**, **Contents** oraz **Custom**. Wszystkie te karty umożliwiają konfigurowanie różnych rodzajów informacji związanych z plikami PowerPoint. Karta **Custom** służy do zarządzania niestandardowymi właściwościami plików PowerPoint.

Praca z własnościami dokumentu przy użyciu Aspose.Slides for Node.js via Java

Jak opisaliśmy wcześniej, Aspose.Slides for Node.js via Java obsługuje dwa rodzaje właściwości dokumentu, czyli **Wbudowane** i **Niestandardowe**. Dlatego deweloperzy mogą uzyskać dostęp do obu rodzajów właściwości przy użyciu API Aspose.Slides for Node.js via Java. Aspose.Slides for Node.js via Java udostępnia klasę [DocumentProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/documentproperties) reprezentującą właściwości dokumentu powiązane z plikiem prezentacji poprzez własność **Presentation.DocumentProperties**.

Deweloperzy mogą używać własności **DocumentProperties** udostępnionej przez obiekt [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation) aby uzyskać dostęp do właściwości dokumentu plików prezentacji, jak opisano poniżej:

## **Dostęp do właściwości wbudowanych**

Te właściwości udostępnione przez obiekt [DocumentProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/documentproperties) obejmują: **Creator** (Autor), **Description**, **Keywords**, **Created** (Data utworzenia), **Modified** (Data modyfikacji), **Printed** (Data ostatniego drukowania), **LastModifiedBy**, **Keywords**, **SharedDoc** (Czy współdzielony między różnymi producentami?), **PresentationFormat**, **Subject** oraz **Title**

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Utwórz instancję klasy Presentation, która reprezentuje prezentację
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Utwórz referencję do obiektu IDocumentProperties powiązanego z prezentacją
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

## **Modyfikacja właściwości wbudowanych**

Modyfikowanie wbudowanych właściwości plików prezentacji jest tak proste, jak ich odczytywanie. Można po prostu przypisać wartość tekstową dowolnej żądanej właściwości i zostanie ona zmieniona. W poniższym przykładzie przedstawiliśmy, jak można zmodyfikować wbudowane właściwości dokumentu prezentacji przy użyciu Aspose.Slides for Node.js via Java.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Utwórz referencję do obiektu IDocumentProperties powiązanego z prezentacją
    var dp = pres.getDocumentProperties();
    // Ustaw wbudowane właściwości
    dp.setAuthor("Aspose.Slides for Node.js via Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    // Zapisz swoją prezentację do pliku
    pres.save("DocProps.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Ten przykład modyfikuje wbudowane właściwości prezentacji, które można zobaczyć poniżej:

|**Wbudowane właściwości dokumentu po modyfikacji**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Dodawanie niestandardowych właściwości dokumentu**

Aspose.Slides for Node.js via Java umożliwia również deweloperom dodawanie niestandardowych wartości właściwości dokumentu prezentacji. Poniżej podano przykład, który pokazuje, jak ustawić niestandardowe właściwości dla prezentacji.

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

|**Dodane niestandardowe właściwości dokumentu**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Dostęp i modyfikacja niestandardowych właściwości**

Aspose.Slides for Node.js via Java umożliwia również deweloperom dostęp do wartości niestandardowych właściwości. Poniżej podano przykład, który pokazuje, jak uzyskać dostęp i zmodyfikować wszystkie te niestandardowe właściwości w prezentacji.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Utwórz referencję do obiektu DocumentProperties powiązanego z prezentacją
    var dp = pres.getDocumentProperties();
    // Dostęp i modyfikacja własnych właściwości
    for (var i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Wyświetl nazwy i wartości własnych właściwości
        console.log("Custom Property Name : " + dp.getCustomPropertyName(i));
        console.log("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
        // Modyfikuj wartości własnych właściwości
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    // Zapisz swoją prezentację do pliku
    pres.save("CustomDemoModified.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Ten przykład modyfikuje niestandardowe właściwości [PPTX](https://docs.fileformat.com/presentation/pptx/) prezentacji. Poniższe ilustracje pokazują niestandardowe właściwości prezentacji przed i po modyfikacji:

|**Niestandardowe właściwości przed modyfikacją**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |


|**Niestandardowe właściwości po modyfikacji**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Zaawansowane właściwości dokumentu**

{{% alert color="info" title="Note" %}}
Dodano nowe metody [ReadDocumentProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-), oraz [WriteBindedPresentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/PresentationInfo#writeBindedPresentation-java.lang.String-) . Logika settera właściwości [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/documentproperties#setLastSavedTime-java.util.Date-) została zmieniona.
{{% /alert %}} 

Dwie nowe metody [ReadDocumentProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--) i [UpdateDocumentProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) zostały dodane do klasy [PresentationInfo](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/PresentationInfo). Zapewniają szybki dostęp do właściwości dokumentu i umożliwiają ich zmianę oraz aktualizację bez ładowania całej prezentacji.

Typowy scenariusz ładowania właściwości, zmiany wartości i aktualizacji dokumentu można zaimplementować w następujący sposób:

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

Nowy szablon może zostać utworzony od podstaw, a następnie użyty do aktualizacji wielu prezentacji:

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

Aspose.Slides udostępnia własność LanguageId (udostępnianą przez klasę PortionFormat), aby umożliwić ustawienie języka korekty dla dokumentu PowerPoint. Język korekty to język, dla którego sprawdzane są pisownia i gramatyka w PowerPoint.

Ten kod JavaScript pokazuje, jak ustawić język korekty dla PowerPoint: xxx Dlaczego właściwość LanguageId brak w klasie JavaScript PortionFormat?

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
    portionFormat.setLanguageId("zh-CN");// ustaw Id języka korekty
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
    // Dodaje nowy prostokątny kształt z tekstem
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

Wypróbuj aplikację online [**Aspose.Slides Metadata**](https://products.aspose.app/slides/pl/metadata), aby zobaczyć, jak pracować z właściwościami dokumentu za pośrednictwem API Aspose.Slides:

[![Wyświetl i edytuj metadane PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/pl/metadata)

## **FAQ**

**Jak mogę usunąć wbudowaną właściwość z prezentacji?**

Wbudowane właściwości są integralną częścią prezentacji i nie mogą być całkowicie usunięte. Można jednak zmienić ich wartości lub ustawić je jako puste, o ile dana właściwość na to pozwala.

**Co się stanie, jeśli dodam niestandardową właściwość, która już istnieje?**

Jeśli dodasz niestandardową właściwość, która już istnieje, jej istniejąca wartość zostanie nadpisana nową. Nie musisz usuwać ani sprawdzać właściwości wcześniej, ponieważ Aspose.Slides automatycznie aktualizuje wartość właściwości.

**Czy mogę uzyskać dostęp do właściwości prezentacji bez pełnego wczytywania prezentacji?**

Tak. Użyj [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) i następnie [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) aby odczytać przechowywane metadane dokumentu bez tworzenia instancji [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/) . Zobacz [Build a Lightweight Presentation Inventory](/slides/pl/nodejs-java/examine-presentation/) dla pełnego przykładu raportowania i ograniczeń specyficznych dla formatów.