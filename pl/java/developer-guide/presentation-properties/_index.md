---
title: Zarządzanie właściwościami prezentacji w Javie
linktitle: Właściwości prezentacji
type: docs
weight: 70
url: /pl/java/presentation-properties/
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
- Java
- Aspose.Slides
description: "Opanuj zarządzanie właściwościami prezentacji w Aspose.Slides dla Javy i usprawnij wyszukiwanie, branding oraz przepływ pracy w swoich plikach PowerPoint i OpenDocument."
---
## **Wprowadzenie**

Aspose.Slides obsługuje dwa rodzaje właściwości dokumentu: **Built-in** i **Custom**. Oba typy właściwości można łatwo uzyskać i zarządzać nimi przy użyciu API Aspose.Slides.

Aspose.Slides umożliwia pracę z właściwościami dokumentu prezentacji za pośrednictwem interfejsu [IDocumentProperties](https://reference.aspose.com/slides/pl/java/com.aspose.slides/idocumentproperties/) . Instancja tego interfejsu jest zwracana przez metodę [Presentation.getDocumentProperties](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#getDocumentProperties--) . Poniższe przykłady pokazują, jak odczytywać, modyfikować i zarządzać tymi właściwościami.

{{% alert color="primary" %}} 
Należy zauważyć, że pola **Application** i **Producer** nie mogą być modyfikowane, ponieważ zawsze będą wyświetlać „Aspose Ltd.” oraz „Aspose.Slides for Java x.x.x”.
{{% /alert %}} 

## **Właściwości dokumentu w programie PowerPoint**

Microsoft PowerPoint 2007 pozwala zarządzać właściwościami dokumentu plików prezentacji. Wystarczy kliknąć ikonę Office, a następnie pozycję menu **Prepare | Properties | Advanced Properties** w Microsoft PowerPoint 2007, jak pokazano poniżej:

|**Wybór elementu menu Advanced Properties**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Po wybraniu elementu menu **Advanced Properties** pojawi się okno dialogowe umożliwiające zarządzanie właściwościami dokumentu pliku PowerPoint, jak pokazano na rysunku poniżej:

|**Okno właściwości**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

W powyższym **Okno właściwości** można zobaczyć wiele zakładek, takich jak **General**, **Summary**, **Statistics**, **Contents** oraz **Custom**. Wszystkie te zakładki umożliwiają konfigurowanie różnych rodzajów informacji związanych z plikami PowerPoint. Zakładka **Custom** służy do zarządzania własnymi właściwościami plików PowerPoint.

### Praca z właściwościami dokumentu przy użyciu Aspose.Slides for Java

Jak opisaliśmy wcześniej, Aspose.Slides for Java obsługuje dwa rodzaje właściwości dokumentu, czyli właściwości **Built-in** i **Custom**. Programiści mogą więc uzyskać dostęp do obu rodzajów właściwości przy użyciu API Aspose.Slides for Java. Aspose.Slides for Java udostępnia klasę [IDocumentProperties](https://reference.aspose.com/slides/pl/java/com.aspose.slides/idocumentproperties) reprezentującą właściwości dokumentu powiązane z plikiem prezentacji poprzez właściwość **Presentation.DocumentProperties**.

Programiści mogą używać właściwości **IDocumentProperties** udostępnionej przez obiekt [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation) aby uzyskać dostęp do właściwości dokumentu plików prezentacji, jak opisano poniżej:

## **Dostęp do właściwości Built-in**

Te właściwości udostępnione przez obiekt [IDocumentProperties] obejmują: **Creator** (Autor), **Description**, **Keywords**, **Created** (Data utworzenia), **Modified** (Data modyfikacji), **Printed** (Data ostatniego wydruku), **LastModifiedBy**, **Keywords**, **SharedDoc** (Czy współdzielony między różnymi producentami?), **PresentationFormat**, **Subject** i **Title**

```java
// Utwórz instancję klasy Presentation, która reprezentuje prezentację
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Utwórz odwołanie do obiektu IDocumentProperties powiązanego z prezentacją
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Wyświetl wbudowane właściwości
    System.out.println("Category : " + dp.getCategory());
    System.out.println("Current Status : " + dp.getContentStatus());
    System.out.println("Creation Date : " + dp.getCreatedTime());
    System.out.println("Author : " + dp.getAuthor());
    System.out.println("Description : " + dp.getComments());
    System.out.println("KeyWords : " + dp.getKeywords());
    System.out.println("Last Modified By : " + dp.getLastSavedBy());
    System.out.println("Supervisor : " + dp.getManager());
    System.out.println("Modified Date : " + dp.getLastSavedTime());
    System.out.println("Presentation Format : " + dp.getPresentationFormat());
    System.out.println("Last Print Date : " + dp.getLastPrinted());
    System.out.println("Is Shared between producers : " + dp.getSharedDoc());
    System.out.println("Subject : " + dp.getSubject());
    System.out.println("Title : " + dp.getTitle());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Modyfikacja właściwości Built-in**

Modyfikacja wbudowanych właściwości plików prezentacji jest tak samo prosta jak ich odczytywanie. Wystarczy przypisać wartość tekstową do dowolnej wybranej właściwości, a jej wartość zostanie zmodyfikowana. W poniższym przykładzie pokazano, jak zmodyfikować wbudowane właściwości dokumentu prezentacji przy użyciu Aspose.Slides for Java.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Utwórz odwołanie do obiektu IDocumentProperties powiązanego z prezentacją
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Ustaw wbudowane właściwości
    dp.setAuthor("Aspose.Slides for Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    
    // Zapisz prezentację do pliku
    pres.save("DocProps.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Ten przykład modyfikuje wbudowane właściwości prezentacji, które można zobaczyć poniżej:

|**Wbudowane właściwości dokumentu po modyfikacji**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Dodawanie własnych właściwości dokumentu**

Aspose.Slides for Java pozwala także programistom dodać własne wartości do właściwości dokumentu prezentacji. Poniżej podano przykład, jak ustawić własne właściwości dla prezentacji.

```java
Presentation pres = new Presentation();
try {
    // Pobieranie właściwości dokumentu
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // Dodawanie własnych właściwości
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    
    // Pobieranie nazwy właściwości pod konkretnym indeksem
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // Usuwanie wybranej właściwości
    dProps.removeCustomProperty(getPropertyName);
    
    // Zapisywanie prezentacji
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**Dodane własne właściwości dokumentu**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Dostęp i modyfikacja własnych właściwości**

Aspose.Slides for Java umożliwia również programistom dostęp do wartości własnych właściwości. Poniżej znajduje się przykład, który pokazuje, jak uzyskać dostęp i zmodyfikować wszystkie te własne właściwości w prezentacji.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Utwórz odwołanie do obiektu DocumentProperties powiązanego z prezentacją
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Uzyskaj dostęp i modyfikuj własne właściwości
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Wyświetl nazwy i wartości własnych właściwości
        System.out.println("Custom Property Name : " + dp.getCustomPropertyName(i));
        System.out.println("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // Zmodyfikuj wartości własnych właściwości
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    
    // Zapisz prezentację do pliku
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Ten przykład modyfikuje własne właściwości [PPTX ](https://docs.fileformat.com/presentation/pptx/) prezentacji. Poniższe rysunki pokazują własne właściwości prezentacji przed i po modyfikacji:

|**Własne właściwości przed modyfikacją**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Własne właściwości po modyfikacji**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Zaawansowane właściwości dokumentu**

{{% alert color="primary" %}} 
Nowe metody [ReadDocumentProperties](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), i [WriteBindedPresentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) zostały dodane do [IPresentationInfo](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IPresentationInfo), zmieniona została logika settera właściwości [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/pl/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-).
{{% /alert %}} 

Te dwa nowe metody [ReadDocumentProperties](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) i [UpdateDocumentProperties](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) zostały dodane do interfejsu [IPresentationInfo](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IPresentationInfo). Zapewniają szybki dostęp do właściwości dokumentu oraz umożliwiają zmianę i aktualizację właściwości bez ładowania całej prezentacji.

Typowy scenariusz: załadować właściwości, zmienić niektóre wartości i zaktualizować dokument, można zrealizować w następujący sposób:

```java
// odczytaj informacje o prezentacji
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// pobierz bieżące właściwości
IDocumentProperties props = info.readDocumentProperties();

// ustaw nowe wartości pól Autor i Tytuł
props.setAuthor("New Author");
props.setTitle("New Title");

// zaktualizuj prezentację nowymi wartościami
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Jest jeszcze inny sposób wykorzystania właściwości konkretnej prezentacji jako szablonu do aktualizacji właściwości w innych prezentacjach:

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("template.pptx");
DocumentProperties template = (DocumentProperties) info.readDocumentProperties();

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

```java
private static void updateByTemplate(String path, IDocumentProperties template) 
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

Nowy szablon można utworzyć od podstaw, a następnie użyć go do aktualizacji wielu prezentacji:

```java
DocumentProperties template = new DocumentProperties();\

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

```java
private static void updateByTemplate(String path, IDocumentProperties template) 
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **Ustaw język korekty**

Aspose.Slides udostępnia właściwość LanguageId (udostępnioną przez klasę PortionFormat), aby umożliwić ustawienie języka korekty dla dokumentu PowerPoint. Język korekty to język, w którym sprawdzane są pisownia i gramatyka w PowerPoint.

Ten kod w Javie pokazuje, jak ustawić język korekty dla PowerPoint: xxx Dlaczego właściwość LanguageId brakuje w klasie Java PortionFormat?

```java
Presentation pres = new Presentation(pptxFileName);
try {
    AutoShape autoShape = (AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    Portion newPortion = new Portion();

    IFontData font = new FontData("SimSun");
    IPortionFormat portionFormat = newPortion.getPortionFormat();
    portionFormat.setComplexScriptFont(font);
    portionFormat.setEastAsianFont(font);
    portionFormat.setLatinFont(font);

    portionFormat.setLanguageId("zh-CN"); // ustaw Id języka korekty

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ustaw domyślny język**

Ten kod w Javie pokazuje, jak ustawić domyślny język dla całej prezentacji PowerPoint:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // Dodaje nowy prostokąt z tekstem
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // Sprawdza język pierwszej porcji
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Przykład na żywo**

Wypróbuj aplikację online [**Aspose.Slides Metadata**](https://products.aspose.app/slides/pl/metadata) aby zobaczyć, jak pracować z właściwościami dokumentu za pośrednictwem API Aspose.Slides:

[![Wyświetl i edytuj metadane PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/pl/metadata)

## ***FAQ**

**Jak mogę usunąć wbudowaną właściwość z prezentacji?**

Wbudowane właściwości są integralną częścią prezentacji i nie mogą być całkowicie usunięte. Można je jednak zmienić lub ustawić jako puste, jeśli dana właściwość na to pozwala.

**Co się stanie, jeśli dodam własną właściwość, która już istnieje?**

Jeśli dodasz własną właściwość, która już istnieje, jej dotychczasowa wartość zostanie nadpisana nową. Nie musisz usuwać ani sprawdzać właściwości wcześniej, ponieważ Aspose.Slides automatycznie aktualizuje wartość właściwości.

**Czy mogę uzyskać dostęp do właściwości prezentacji bez pełnego jej ładowania?**

Tak, możesz uzyskać dostęp do właściwości prezentacji bez jej pełnego ładowania, używając metody `getPresentationInfo` z klasy [PresentationFactory](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentationfactory/) . Następnie wykorzystaj metodę `readDocumentProperties` udostępnioną przez interfejs [IPresentationInfo](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipresentationinfo/) , aby efektywnie odczytać właściwości, oszczędzając pamięć i zwiększając wydajność.