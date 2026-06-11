---
title: Zarządzanie właściwościami prezentacji w Androidzie
linktitle: Właściwości prezentacji
type: docs
weight: 70
url: /pl/androidjava/presentation-properties/
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
- Android
- Java
- Aspose.Slides
description: "Opanuj właściwości prezentacji w Aspose.Slides dla Androida za pomocą Java i usprawnij wyszukiwanie, branding oraz przepływ pracy w swoich plikach PowerPoint i OpenDocument."
---
## **Wprowadzenie**

Aspose.Slides obsługuje dwa rodzaje właściwości dokumentu: **Wbudowane** i **Niestandardowe**. Oba typy właściwości można łatwo odczytać i zarządzać nimi przy użyciu API Aspose.Slides.

Aspose.Slides umożliwia pracę z właściwościami dokumentu prezentacji poprzez interfejs [IDocumentProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/idocumentproperties/) . Instancja tego interfejsu jest zwracana przez metodę [Presentation.getDocumentProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#getDocumentProperties--) . Poniższe przykłady pokazują, jak odczytywać, modyfikować i zarządzać tymi właściwościami.

{{% alert color="primary" %}} 
Należy pamiętać, że pola **Application** i **Producer** nie mogą być modyfikowane, ponieważ zawsze będą wyświetlały „Aspose Ltd.” oraz „Aspose.Slides for Android via Java x.x.x”.
{{% /alert %}} 

## **Właściwości dokumentu w PowerPoint**

Microsoft PowerPoint 2007 umożliwia zarządzanie właściwościami dokumentu plików prezentacji. Wystarczy kliknąć ikonę Office i wybrać pozycję menu **Prepare | Properties | Advanced Properties** w programie Microsoft PowerPoint 2007, jak pokazano poniżej:

|**Wybór pozycji menu Advanced Properties**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
Po wybraniu pozycji menu **Advanced Properties** pojawi się okno dialogowe umożliwiające zarządzanie właściwościami dokumentu pliku PowerPoint, jak pokazano na rysunku:

|**Okno właściwości**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
W powyższym **Oknie właściwości** widoczne są zakładki takie jak **General**, **Summary**, **Statistics**, **Contents** oraz **Custom**. Wszystkie te zakładki umożliwiają konfigurowanie różnych informacji związanych z plikami PowerPoint. Zakładka **Custom** służy do zarządzania niestandardowymi właściwościami plików PowerPoint.



### Praca z właściwościami dokumentu przy użyciu Aspose.Slides for Android via Java

Jak opisano wcześniej, Aspose.Slides for Android via Java obsługuje dwa rodzaje właściwości dokumentu: **Wbudowane** i **Niestandardowe**. Dlatego programiści mogą uzyskać dostęp do obu rodzajów właściwości przy użyciu API Aspose.Slides for Android via Java. Aspose.Slides for Android via Java udostępnia klasę [IDocumentProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/idocumentproperties), która reprezentuje właściwości dokumentu powiązane z plikiem prezentacji poprzez właściwość **Presentation.DocumentProperties**.

Programiści mogą używać właściwości **IDocumentProperties** udostępnionej przez obiekt [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation), aby uzyskać dostęp do właściwości dokumentu plików prezentacji, jak opisano poniżej:

## **Dostęp do właściwości wbudowanych**

Właściwości udostępniane przez obiekt [IDocumentProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/idocumentproperties) obejmują: **Creator** (Autor), **Description**, **Keywords**, **Created** (Data utworzenia), **Modified** (Data modyfikacji), **Printed** (Data ostatniego drukowania), **LastModifiedBy**, **SharedDoc** (Czy dokument jest współdzielony między różnymi producentami?), **PresentationFormat**, **Subject** oraz **Title**.

```java
// Utwórz instancję klasy Presentation, która reprezentuje prezentację
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Utwórz odwołanie do obiektu IDocumentProperties powiązanego z Presentation
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

## **Modyfikacja właściwości wbudowanych**

Modyfikowanie wbudowanych właściwości plików prezentacji jest tak proste, jak ich odczyt. Wystarczy przypisać wartość łańcuchową do dowolnej żądanej właściwości, a jej wartość zostanie zmieniona. W poniższym przykładzie pokazano, jak można modyfikować wbudowane właściwości dokumentu prezentacji przy użyciu Aspose.Slides for Android via Java.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Utwórz odwołanie do obiektu IDocumentProperties powiązanego z Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Ustaw wbudowane właściwości
    dp.setAuthor("Aspose.Slides for Android via Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    
    // Zapisz swoją prezentację do pliku
    pres.save("DocProps.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Ten przykład modyfikuje wbudowane właściwości prezentacji, co widać na poniższym zrzucie ekranu:

|**Wbudowane właściwości dokumentu po modyfikacji**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Dodawanie niestandardowych właściwości dokumentu**

Aspose.Slides for Android via Java umożliwia programistom dodawanie niestandardowych wartości do właściwości dokumentu prezentacji. Poniżej znajduje się przykład, który pokazuje, jak ustawić niestandardowe właściwości dla prezentacji.

```java
Presentation pres = new Presentation();
try {
    // Pobieranie właściwości dokumentu
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // Dodawanie niestandardowych właściwości
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    
    // Pobieranie nazwy właściwości pod określonym indeksem
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // Usuwanie wybranej właściwości
    dProps.removeCustomProperty(getPropertyName);
    
    // Zapisywanie prezentacji
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**Dodane niestandardowe właściwości dokumentu**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Dostęp i modyfikacja niestandardowych właściwości**

Aspose.Slides for Android via Java umożliwia również programistom dostęp do wartości niestandardowych właściwości. Poniżej znajduje się przykład, który pokazuje, jak uzyskać dostęp i zmodyfikować wszystkie te niestandardowe właściwości dla prezentacji.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Utwórz odwołanie do obiektu DocumentProperties powiązanego z Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Uzyskaj dostęp i zmodyfikuj niestandardowe właściwości
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Wyświetl nazwy i wartości niestandardowych właściwości
        System.out.println("Custom Property Name : " + dp.getCustomPropertyName(i));
        System.out.println("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // Zmodyfikuj wartości niestandardowych właściwości
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    
    // Zapisz swoją prezentację do pliku
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Ten przykład modyfikuje niestandardowe właściwości [PPTX](https://docs.fileformat.com/presentation/pptx/). Poniższe ilustracje przedstawiają niestandardowe właściwości prezentacji przed i po modyfikacji:

|**Niestandardowe właściwości przed modyfikacją**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Niestandardowe właściwości po modyfikacji**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Zaawansowane właściwości dokumentu**

{{% alert color="primary" %}} 
Do interfejsu [IPresentationInfo](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IPresentationInfo) dodano nowe metody [ReadDocumentProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), oraz [WriteBindedPresentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-). Zmieniono logikę settera właściwości [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-).
{{% /alert %}} 

Dwie nowe metody [ReadDocumentProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--) i [UpdateDocumentProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) zostały dodane do interfejsu [IPresentationInfo](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IPresentationInfo). Umożliwiają szybki dostęp do właściwości dokumentu oraz pozwalają zmieniać i aktualizować właściwości bez wczytywania całej prezentacji.

Typowy scenariusz – wczytanie właściwości, zmiana wartości i aktualizacja dokumentu – można zrealizować w następujący sposób:

```java
// odczytaj informacje o prezentacji
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// pobierz bieżące właściwości
IDocumentProperties props = info.readDocumentProperties();

// ustaw nowe wartości pól Author i Title
props.setAuthor("New Author");
props.setTitle("New Title");

// zaktualizuj prezentację nowymi wartościami
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Inny sposób to użycie właściwości konkretnej prezentacji jako szablonu do aktualizacji właściwości w innych prezentacjach:

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

Nowy szablon można utworzyć od podstaw, a następnie używać go do aktualizacji wielu prezentacji:

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

## **Ustawienie języka korekty**

Aspose.Slides udostępnia właściwość LanguageId (udostępnianą przez klasę PortionFormat), aby umożliwić ustawienie języka korekty dla dokumentu PowerPoint. Język korekty to język, w którym sprawdzane są pisownia i gramatyka w PowerPoint.

Ten kod Java pokazuje, jak ustawić język korekty dla pliku PowerPoint: xxx Why is LanguageId missing from Java PortionFormat class?

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

    portionFormat.setLanguageId("zh-CN"); // ustaw identyfikator języka korekty

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ustawienie domyślnego języka**

Ten kod Java pokazuje, jak ustawić domyślny język dla całej prezentacji PowerPoint:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // Dodaje nowy prostokątny kształt z tekstem
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // Sprawdza język pierwszej części
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Przykład na żywo**

Wypróbuj aplikację online [**Aspose.Slides Metadata**](https://products.aspose.app/slides/pl/metadata), aby zobaczyć, jak pracować z właściwościami dokumentu przy użyciu API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/pl/metadata)

## ***FAQ**

**Jak mogę usunąć wbudowaną właściwość z prezentacji?**

Wbudowane właściwości są integralną częścią prezentacji i nie mogą być całkowicie usunięte. Można jednak zmienić ich wartości lub ustawić je na pustą wartość, o ile dana właściwość na to pozwala.

**Co się stanie, jeśli dodam niestandardową właściwość, która już istnieje?**

Jeśli dodasz niestandardową właściwość, która już istnieje, jej dotychczasowa wartość zostanie nadpisana nową. Nie musisz usuwać ani sprawdzać właściwości wcześniej, ponieważ Aspose.Slides automatycznie aktualizuje jej wartość.

**Czy mogę uzyskać dostęp do właściwości prezentacji bez pełnego wczytywania pliku?**

Tak, możesz uzyskać dostęp do właściwości prezentacji bez pełnego wczytywania pliku, korzystając z metody `getPresentationInfo` klasy [PresentationFactory](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentationfactory/). Następnie użyj metody `readDocumentProperties` udostępnionej przez interfejs [IPresentationInfo](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentationinfo/), aby efektywnie odczytać właściwości, oszczędzając pamięć i zwiększając wydajność.