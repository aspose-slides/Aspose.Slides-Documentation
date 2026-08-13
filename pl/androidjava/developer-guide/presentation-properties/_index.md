---
title: Zarządzanie właściwościami prezentacji na Androidzie
linktitle: Właściwości prezentacji
type: docs
weight: 70
url: /pl/androidjava/presentation-properties/
keywords:
- właściwości PowerPoint
- właściwości prezentacji
- właściwości dokumentu
- wbudowane właściwości
- niestandardowe właściwości
- zaawansowane właściwości
- zarządzanie właściwościami
- modyfikowanie właściwości
- metadane dokumentu
- edycja metadanych
- język sprawdzania
- język domyślny
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Opanuj właściwości prezentacji w Aspose.Slides dla Androida przy użyciu Javy i usprawnij wyszukiwanie, branding oraz przepływ pracy w swoich plikach PowerPoint i OpenDocument."
---
## **Wprowadzenie**

Aspose.Slides obsługuje dwa typy właściwości dokumentu: **Built-in** i **Custom**. Oba te typy właściwości można łatwo odczytać i zarządzać nimi przy użyciu API Aspose.Slides.

Aspose.Slides umożliwia pracę z właściwościami dokumentu prezentacji za pośrednictwem interfejsu [IDocumentProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/idocumentproperties/) . Instancja tego interfejsu jest zwracana przez metodę [Presentation.getDocumentProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#getDocumentProperties--) . Poniższe przykłady pokazują, jak odczytywać, modyfikować i zarządzać tymi właściwościami.

{{% alert color="info" %}} 
Należy pamiętać, że pola **Application** i **AppVersion** nie mogą być modyfikowane. Aspose.Slides nadpisuje je przy każdym zapisie, więc zapisana prezentacja zawsze podaje nazwę produktu Aspose.Slides oraz wersję biblioteki, która ją wygenerowała. Każda wartość przekazana do `setNameOfApplication` jest pomijana podczas zapisu prezentacji.
{{% /alert %}} 

## **Właściwości dokumentu w programie PowerPoint**

Microsoft PowerPoint 2007 umożliwia zarządzanie właściwościami dokumentu plików prezentacji. Wystarczy kliknąć ikonę Office, a następnie wybrać pozycję menu **Prepare | Properties | Advanced Properties** w programie Microsoft PowerPoint 2007, jak pokazano poniżej:

|**Wybieranie pozycji menu Advanced Properties**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
Po wybraniu pozycji **Advanced Properties** pojawi się okno dialogowe umożliwiające zarządzanie właściwościami dokumentu pliku PowerPoint, jak pokazano na rysunku poniżej:

|**Okno właściwości**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
W powyższym **Okno właściwości** można zobaczyć wiele zakładek, takich jak **General**, **Summary**, **Statistics**, **Contents** oraz **Custom**. Wszystkie te zakładki umożliwiają konfigurowanie różnych rodzajów informacji związanych z plikami PowerPoint. Zakładka **Custom** służy do zarządzania niestandardowymi właściwościami plików PowerPoint.

## **Praca z właściwościami dokumentu przy użyciu Aspose.Slides dla Android via Java**

As we described earlier, Aspose.Slides for Android via Java obsługuje dwa rodzaje właściwości dokumentu, czyli **Built-in** i **Custom**. Programiści mogą więc uzyskać dostęp do obu rodzajów właściwości przy użyciu API Aspose.Slides for Android via Java. Aspose.Slides for Android via Java udostępnia klasę [IDocumentProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/idocumentproperties) , która reprezentuje właściwości dokumentu powiązane z plikiem prezentacji poprzez właściwość **Presentation.DocumentProperties**.

Programiści mogą używać właściwości **IDocumentProperties** udostępnianej przez obiekt [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation) , aby uzyskać dostęp do właściwości dokumentu plików prezentacji, jak opisano poniżej:

## **Dostęp do właściwości wbudowanych**

Właściwości udostępniane przez obiekt [IDocumentProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/idocumentproperties) obejmują: **Creator** (Autor), **Description**, **Keywords**, **Created** (Data utworzenia), **Modified** (Data modyfikacji), **Printed** (Data ostatniego wydruku), **LastModifiedBy**, **Keywords**, **SharedDoc** (Czy współdzielony między różnymi twórcami?), **PresentationFormat**, **Subject** oraz **Title**.

```java
import com.aspose.slides.*;

// Utwórz instancję klasy Presentation, która reprezentuje prezentację
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Utwórz referencję do obiektu IDocumentProperties powiązanego z prezentacją
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

Modyfikacja wbudowanych właściwości plików prezentacji jest tak prosta, jak ich odczyt. Wystarczy przypisać wartość tekstową do dowolnej wybranej właściwości, a jej wartość zostanie zmodyfikowana. W poniższym przykładzie pokazaliśmy, jak można zmodyfikować wbudowane właściwości dokumentu prezentacji przy użyciu Aspose.Slides for Android via Java.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Utwórz referencję do obiektu IDocumentProperties powiązanego z prezentacją
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

Ten przykład modyfikuje wbudowane właściwości prezentacji, które można zobaczyć poniżej:

|**Wbudowane właściwości dokumentu po modyfikacji**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Dodawanie niestandardowych właściwości dokumentu**

Aspose.Slides for Android via Java umożliwia także programistom dodawanie niestandardowych wartości do właściwości dokumentu prezentacji. Poniższy przykład dodaje trzy niestandardowe właściwości, następnie wyszukuje nazwę przechowywaną pod indeksem 2 i usuwa tę właściwość, dzięki czemu zapisana prezentacja zachowuje dwie z nich. Niestandardowe właściwości są indeksowane w kolejności alfabetycznej, a nie w kolejności ich dodania.

```java
import com.aspose.slides.*;

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
    
    // Zapis prezentacji
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**Dodane niestandardowe właściwości dokumentu**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Dostęp i modyfikacja niestandardowych właściwości**

Aspose.Slides for Android via Java umożliwia także programistom dostęp do wartości niestandardowych właściwości. Poniżej podany jest przykład, który pokazuje, jak uzyskać dostęp i zmodyfikować wszystkie te niestandardowe właściwości w prezentacji.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Utwórz referencję do obiektu DocumentProperties powiązanego z prezentacją
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Uzyskaj dostęp i zmodyfikuj niestandardowe właściwości
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Wyświetl nazwy i wartości niestandardowych właściwości
        System.out.println("Custom Property Name : " + dp.getCustomPropertyName(i));
        System.out.println("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // Modyfikuj wartości niestandardowych właściwości
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    
    // Zapisz swoją prezentację do pliku
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
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

{{% alert color="info" %}} 
Dodano nowe metody [ReadDocumentProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), i [WriteBindedPresentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) do interfejsu [IPresentationInfo](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IPresentationInfo), logika zestawiającego [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) została zmieniona.
{{% /alert %}} 

Te dwie nowe metody [ReadDocumentProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--) i [UpdateDocumentProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) zostały dodane do interfejsu [IPresentationInfo](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IPresentationInfo). Zapewniają szybki dostęp do właściwości dokumentu i umożliwiają zmianę oraz aktualizację właściwości bez ładowania całej prezentacji.

Typowy scenariusz: załadowanie właściwości, zmiana pewnej wartości i aktualizacja dokumentu można zaimplementować w następujący sposób:

```java
import com.aspose.slides.*;

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

Istnieje inny sposób użycia właściwości konkretnej prezentacji jako szablonu do aktualizacji właściwości w innych prezentacjach:

```java
import com.aspose.slides.*;

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
import com.aspose.slides.*;

private static void updateByTemplate(String path, IDocumentProperties template) 
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

Nowy szablon można utworzyć od podstaw, a następnie używać go do aktualizacji wielu prezentacji:

```java
import com.aspose.slides.*;

DocumentProperties template = new DocumentProperties();

template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" })
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **Ustaw język sprawdzania ortograficznego**

Aspose.Slides udostępnia właściwość LanguageId (udostępnianą przez klasę PortionFormat), umożliwiającą ustawienie języka sprawdzania ortograficznego dla dokumentu PowerPoint. Język sprawdzania to język, dla którego w PowerPoint sprawdzane są pisownia i gramatyka.

Ten kod Java pokazuje, jak ustawić język sprawdzania w PowerPoint:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
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

    portionFormat.setLanguageId("zh-CN"); // ustaw identyfikator języka sprawdzania ortograficznego

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ustaw domyślny język**

Ten kod Java pokazuje, jak ustawić domyślny język dla całej prezentacji PowerPoint:

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // Dodaje nowy prostokątny kształt z tekstem
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // Sprawdza język pierwszej porcji
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Przykład na żywo**

Wypróbuj aplikację online [**Aspose.Slides Metadata**](https://products.aspose.app/slides/pl/metadata), aby zobaczyć, jak pracować z właściwościami dokumentu przy użyciu API Aspose.Slides:

[![Wyświetl i edytuj metadane PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/pl/metadata)

## ***FAQ**

### Jak mogę usunąć wbudowaną właściwość z prezentacji?

Wbudowane właściwości są integralną częścią prezentacji i nie mogą być całkowicie usunięte. Można jednak zmienić ich wartości lub ustawić je jako puste, o ile dana właściwość na to pozwala.

### Co się stanie, jeśli dodam niestandardową właściwość, która już istnieje?

Jeśli dodasz niestandardową właściwość, która już istnieje, jej bieżąca wartość zostanie nadpisana nową. Nie musisz usuwać ani sprawdzać właściwości wcześniej, ponieważ Aspose.Slides automatycznie aktualizuje wartość właściwości.

### Czy mogę uzyskać dostęp do właściwości prezentacji bez pełnego ładowania prezentacji?

Tak, można uzyskać dostęp do właściwości prezentacji bez pełnego jej ładowania, używając metody `getPresentationInfo` z klasy [PresentationFactory](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentationfactory/) . Następnie, wykorzystując metodę `readDocumentProperties` udostępnioną przez interfejs [IPresentationInfo](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentationinfo/) , można efektywnie odczytać właściwości, oszczędzając pamięć i zwiększając wydajność.