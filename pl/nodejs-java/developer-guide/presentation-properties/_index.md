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
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Opanuj właściwości prezentacji w Aspose.Slides for Node.js via Java i usprawnij wyszukiwanie, branding oraz przepływ pracy w swoich plikach PowerPoint i OpenDocument."
---
## **Wprowadzenie**

Aspose.Slides obsługuje dwa typy właściwości dokumentu: **Wbudowane** i **Niestandardowe**. Oba te typy właściwości można łatwo odczytywać i zarządzać nimi przy użyciu API Aspose.Slides.

Aspose.Slides umożliwia pracę z właściwościami dokumentu prezentacji za pośrednictwem klasy [DocumentProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/documentproperties/) . Instancja tej klasy jest zwracana przez metodę [Presentation.getDocumentProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#getDocumentProperties). Poniższe przykłady pokazują, jak odczytywać, modyfikować i zarządzać tymi właściwościami.

{{% alert color="primary" %}} 

Należy pamiętać, że nie można ustawiać wartości pól **Application** i **Producer**, ponieważ w tych polach będą wyświetlane informacje o Aspose Ltd. oraz Aspose.Slides for Node.js via Java x.x.x.

{{% /alert %}} 

## **Zarządzanie właściwościami prezentacji**

Microsoft PowerPoint udostępnia funkcję umożliwiającą dodawanie niektórych właściwości do plików prezentacji. Właściwości dokumentu pozwalają przechowywać przydatne informacje razem z dokumentami (plikami prezentacji). Istnieją dwa rodzaje właściwości dokumentu:

- Systemowe (Wbudowane) właściwości  
- Definiowane przez użytkownika (Niestandardowe) właściwości  

**Wbudowane** właściwości zawierają ogólne informacje o dokumencie, takie jak tytuł, nazwisko autora, statystyki dokumentu itp. **Niestandardowe** właściwości są definiowane przez użytkowników jako pary **Nazwa/Wartość**, gdzie zarówno nazwa, jak i wartość są określone przez użytkownika. Korzystając z Aspose.Slides for Node.js via Java, programiści mogą odczytywać i modyfikować zarówno wbudowane, jak i niestandardowe właściwości.

## **Właściwości dokumentu w programie PowerPoint**

Microsoft PowerPoint 2007 pozwala zarządzać właściwościami dokumentu plików prezentacji. Wystarczy kliknąć ikonę Office, a następnie wybrać **Prepare | Properties | Advanced Properties** w programie Microsoft PowerPoint 2007, jak pokazano poniżej:

|**Wybór pozycji menu Zaawansowane właściwości**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Po wybraniu pozycji **Advanced Properties** pojawi się okno dialogowe umożliwiające zarządzanie właściwościami dokumentu pliku PowerPoint, jak pokazano na rysunku:

|**Okno właściwości**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

W powyższym **Oknie właściwości** można zobaczyć wiele zakładek, takich jak **General**, **Summary**, **Statistics**, **Contents** oraz **Custom**. Wszystkie te zakładki umożliwiają konfigurowanie różnych rodzajów informacji związanych z plikami PowerPoint. Zakładka **Custom** służy do zarządzania niestandardowymi właściwościami plików PowerPoint.

### Praca z właściwościami dokumentu przy użyciu Aspose.Slides for Node.js via Java

Jak opisano wcześniej, Aspose.Slides for Node.js via Java obsługuje dwa rodzaje właściwości dokumentu: **Wbudowane** i **Niestandardowe**. Dzięki temu programiści mogą uzyskiwać dostęp do obu rodzajów właściwości przy użyciu API Aspose.Slides for Node.js via Java. Aspose.Slides for Node.js via Java udostępnia klasę [DocumentProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/documentproperties), która reprezentuje właściwości dokumentu powiązane z plikiem prezentacji za pośrednictwem właściwości **Presentation.DocumentProperties**.

Programiści mogą używać właściwości **DocumentProperties** wystawionej przez obiekt [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation), aby uzyskać dostęp do właściwości dokumentu plików prezentacji, jak opisano poniżej:

## **Dostęp do wbudowanych właściwości**

Te właściwości udostępniane przez obiekt [DocumentProperties] obejmują: **Creator** (Autor), **Description**, **Keywords**, **Created** (Data utworzenia), **Modified** (Data modyfikacji), **Printed** (Data ostatniego wydruku), **LastModifiedBy**, **Keywords**, **SharedDoc** (Czy współdzielony między różnymi producentami?), **PresentationFormat**, **Subject** i **Title**.

```javascript
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

## **Modyfikacja wbudowanych właściwości**

Modyfikowanie wbudowanych właściwości plików prezentacji jest tak samo proste, jak ich odczytywanie. Wystarczy przypisać wartość tekstową do dowolnej żądanej właściwości i wartość zostanie zmieniona. W poniższym przykładzie pokazano, jak zmodyfikować wbudowane właściwości dokumentu prezentacji przy użyciu Aspose.Slides for Node.js via Java.

```javascript
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

Przykład ten modyfikuje wbudowane właściwości prezentacji, co można zobaczyć na poniższym rysunku:

|**Wbudowane właściwości dokumentu po modyfikacji**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Dodawanie niestandardowych właściwości dokumentu**

Aspose.Slides for Node.js via Java umożliwia także programistom dodawanie niestandardowych wartości do właściwości dokumentu prezentacji. Poniżej znajduje się przykład, który pokazuje, jak ustawić niestandardowe właściwości dla prezentacji.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Pobieranie właściwości dokumentu
    var dProps = pres.getDocumentProperties();
    // Dodawanie niestandardowych właściwości
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

Aspose.Slides for Node.js via Java umożliwia również programistom dostęp do wartości niestandardowych właściwości. Poniżej znajduje się przykład, który pokazuje, jak uzyskać dostęp i zmodyfikować wszystkie te niestandardowe właściwości prezentacji.

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Utwórz referencję do obiektu DocumentProperties powiązanego z prezentacją
    var dp = pres.getDocumentProperties();
    // Uzyskaj dostęp i modyfikuj niestandardowe właściwości
    for (var i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Wyświetl nazwy i wartości niestandardowych właściwości
        console.log("Custom Property Name : " + dp.getCustomPropertyName(i));
        console.log("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
        // Modyfikuj wartości niestandardowych właściwości
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

Ten przykład modyfikuje niestandardowe właściwości [PPTX](https://docs.fileformat.com/presentation/pptx/) prezentacji. Poniższe rysunki przedstawiają niestandardowe właściwości prezentacji przed i po modyfikacji:

|**Niestandardowe właściwości przed modyfikacją**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Niestandardowe właściwości po modyfikacji**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Zaawansowane właściwości dokumentu**

{{% alert color="primary" %}} 

Nowe metody [ReadDocumentProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-), oraz [WriteBindedPresentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/PresentationInfo#writeBindedPresentation-java.lang.String-) zostały dodane do klasy [PresentationInfo](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/PresentationInfo); logika setter’a właściwości [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/documentproperties#setLastSavedTime-java.util.Date-) została zmieniona.

{{% /alert %}} 

Dwie nowe metody [ReadDocumentProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--) i [UpdateDocumentProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) zostały dodane do klasy [PresentationInfo](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/PresentationInfo). Umożliwiają one szybki dostęp do właściwości dokumentu oraz ich zmianę i aktualizację bez ładowania całej prezentacji.

Typowy scenariusz polega na załadowaniu właściwości, zmianie niektórych wartości i aktualizacji dokumentu w następujący sposób:

```javascript
// odczytaj informacje prezentacji
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");
// obtain the current properties
var props = info.readDocumentProperties();
// set the new values of Author and Title fields
props.setAuthor("New Author");
props.setTitle("New Title");
// update the presentation with a new values
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Istnieje inny sposób wykorzystania właściwości konkretnej prezentacji jako szablonu do aktualizacji właściwości w innych prezentacjach:

```javascript
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
function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

Nowy szablon można utworzyć od podstaw, a następnie używać go do aktualizacji wielu prezentacji:

```javascript
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
function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **Ustaw język korekty**

Aspose.Slides udostępnia właściwość LanguageId (udostępnioną przez klasę PortionFormat), aby umożliwić ustawienie języka korekty dla dokumentu PowerPoint. Język korekty to język, dla którego sprawdzane są pisownia i gramatyka w PowerPoint.

Ten kod JavaScript pokazuje, jak ustawić język korekty dla PowerPoint: xxx Why is LanguageId missing from JavaScript PortionFormat class?

```javascript
var pres = new aspose.slides.Presentation(pptxFileName);
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
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");
var pres = new aspose.slides.Presentation(loadOptions);
try {
    // Dodaje nowy prostokątny kształt z tekstem
    var shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");
    // Sprawdza język pierwszej porcji
    console.log(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Przykład na żywo**

Wypróbuj aplikację online [**Aspose.Slides Metadata**](https://products.aspose.app/slides/pl/metadata), aby zobaczyć, jak pracować z właściwościami dokumentu za pośrednictwem API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/pl/metadata)

## ***FAQ**

**Jak mogę usunąć wbudowaną właściwość z prezentacji?**

Wbudowane właściwości są integralną częścią prezentacji i nie mogą być całkowicie usunięte. Można jednak zmienić ich wartości lub, jeśli dana właściwość na to pozwala, ustawić je jako puste.

**Co się stanie, jeśli dodam niestandardową właściwość, która już istnieje?**

Jeśli dodasz niestandardową właściwość, która już istnieje, jej bieżąca wartość zostanie nadpisana nową. Nie musisz usuwać ani sprawdzać właściwości wcześniej, ponieważ Aspose.Slides automatycznie aktualizuje wartość właściwości.

**Czy mogę uzyskać dostęp do właściwości prezentacji bez pełnego ładowania prezentacji?**

Tak, możesz uzyskać dostęp do właściwości prezentacji bez pełnego jej ładowania, używając metody `getPresentationInfo` z klasy [PresentationFactory](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentationfactory/). Następnie skorzystaj z metody `readDocumentProperties` udostępnionej przez klasę [PresentationInfo](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentationinfo/), aby efektywnie odczytać właściwości, oszczędzając pamięć i zwiększając wydajność.