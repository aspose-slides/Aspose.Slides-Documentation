---
title: Zarządzanie właściwościami prezentacji na Androidzie
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
description: "Mistrzowskie zarządzanie właściwościami prezentacji w Aspose.Slides dla Androida w Javie oraz usprawnienie wyszukiwania, brandingu i przepływu pracy w plikach PowerPoint i OpenDocument."
---
## **Wprowadzenie**

Aspose.Slides obsługuje dwa typy właściwości dokumentu: **Built-in** i **Custom**. Oba typy właściwości można łatwo odczytać i zarządzać nimi przy użyciu API Aspose.Slides.

Aspose.Slides umożliwia pracę z właściwościami dokumentu prezentacji poprzez interfejs [IDocumentProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/idocumentproperties/). Instancja tego interfejsu jest zwracana przez metodę [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--). Poniższe przykłady pokazują, jak odczytywać, modyfikować i zarządzać tymi właściwościami.

{{% alert color="info" title="Uwaga" %}}

Należy pamiętać, że pola **Application** i **AppVersion** nie mogą być modyfikowane. Aspose.Slides nadpisuje je przy każdym zapisie, więc zapisana prezentacja zawsze zgłasza nazwę produktu Aspose.Slides oraz wersję biblioteki, która ją utworzyła. Każda wartość przekazana do `setNameOfApplication` zostaje odrzucona podczas zapisu prezentacji.

{{% /alert %}} 

## **Właściwości dokumentu w PowerPoint**

Microsoft PowerPoint 2007 umożliwia zarządzanie właściwościami dokumentu plików prezentacji. Wystarczy kliknąć ikonę Office, a następnie wybrać pozycję menu **Prepare | Properties | Advanced Properties**, jak pokazano poniżej:

|**Wybór pozycji menu Advanced Properties**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
Po wybraniu pozycji **Advanced Properties** pojawi się okno dialogowe umożliwiające zarządzanie właściwościami dokumentu pliku PowerPoint, jak pokazano na rysunku poniżej:

|**Okno właściwości**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
W powyższym **Oknie właściwości** można zobaczyć wiele zakładek, takich jak **General**, **Summary**, **Statistics**, **Contents** oraz **Custom**. Wszystkie te zakładki umożliwiają konfigurowanie różnych informacji związanych z plikami PowerPoint. Zakładka **Custom** służy do zarządzania niestandardowymi właściwościami plików PowerPoint.



Praca z właściwościami dokumentu przy użyciu Aspose.Slides dla Androida w Javie

Jak opisano wcześniej, Aspose.Slides dla Androida w Javie obsługuje dwa rodzaje właściwości dokumentu: **Built-in** i **Custom**. Programiści mogą uzyskać dostęp do obu rodzajów właściwości przy użyciu API Aspose.Slides dla Androida w Javie. Aspose.Slides dla Androida w Javie udostępnia klasę [IDocumentProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/idocumentproperties), która reprezentuje właściwości dokumentu powiązane z plikiem prezentacji poprzez właściwość **Presentation.DocumentProperties**.

Programiści mogą używać właściwości **IDocumentProperties** udostępnianej przez obiekt [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation) do uzyskania dostępu do właściwości dokumentu plików prezentacji, jak opisano poniżej:

## **Odczyt publicznych właściwości z zaszyfrowanej prezentacji**

Hasło otwierające zwykle chroni zarówno zawartość prezentacji, jak i właściwości dokumentu. Gdy prezentacja jest szyfrowana przez przekazanie `false` do [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-), jej właściwości dokumentu pozostają publiczne. Aplikacja może wtedy przekazać `true` do [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) i odczytać publiczne metadane bez podawania hasła otwierającego.

Opcja ładowania wyłącznie właściwości dokumentu kontroluje, co Aspose.Slides ładuje; nie odczytuje ona niczego. Jeśli właściwości były objęte szyfrowaniem, ich ładowanie bez hasła kończy się niepowodzeniem. Jeśli prezentacja nie jest zaszyfrowana, opcja jest ignorowana i ładowana jest pełna prezentacja.

Poniższy przykład weryfikuje tryb ładowania przy użyciu [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) i następnie odczytuje wbudowane właściwości przez [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--):

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        IDocumentProperties properties = presentation.getDocumentProperties();

        System.out.println("Author: " + properties.getAuthor());
        System.out.println("Title: " + properties.getTitle());
        System.out.println("Keywords: " + properties.getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

W tym trybie zawartość slajdów nie jest ładowana. Slajdy, mastery, układy, kształty, multimedia i inne obiekty prezentacji są niedostępne. Aplikacje powinny zawsze sprawdzać [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) przed wykonaniem operacji wymagającej pełnego modelu obiektowego prezentacji.

{{% alert color="warning" title="Ostrzeżenie" %}}
Publiczne metadane mogą ujawniać nazwiska autorów, tytuły, tematy, słowa kluczowe, informacje o firmie, komentarze i niestandardowe wartości. Zaszyfruj wrażliwe właściwości razem z prezentacją. Pozostaw je publiczne tylko wtedy, gdy systemy indeksowania, klasyfikacji, wyszukiwania lub zarządzania dokumentami mają konkretny wymóg dostępu do nich bez hasła.
{{% /alert %}}

## **Aktualizacja właściwości zaszyfrowanej prezentacji**

Dla zaszyfrowanego pliku PPTX, prezentacja załadowana w trybie wyłącznie właściwości dokumentu jest przeznaczona do odczytu publicznych metadanych. Aspose.Slides nie może zapisać zmienionych właściwości z tego obiektu tylko z metadanymi, ponieważ publiczne właściwości muszą pozostać zgodne z odpowiednimi danymi wewnątrz zaszyfrowanej prezentacji. Dlatego ich aktualizacja wymaga prawidłowego hasła otwierającego i pełnego załadowania.

Poniższy przykład otwiera prezentację przy użyciu [LoadOptions.setPassword](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-), aktualizuje publiczne wbudowane właściwości i zapisuje wynik. Następnie używa [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentationinfo/#isEncrypted--) do weryfikacji, że szyfrowanie zostało zachowane, i ponownie otwiera publiczne metadane bez hasła, aby sprawdzić nowe wartości:

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;
import com.aspose.slides.SaveFormat;

final String inputPath = "public-properties-encrypted.pptx";
final String outputPath = "updated-public-properties-encrypted.pptx";

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation(inputPath, loadOptions);
try {
    presentation.getDocumentProperties().setTitle("Updated Product Roadmap");
    presentation.getDocumentProperties().setKeywords("roadmap, planning, indexed");
    presentation.save(outputPath, SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(outputPath);
System.out.println("The presentation is encrypted: " + presentationInfo.isEncrypted());

LoadOptions metadataLoadOptions = new LoadOptions();
metadataLoadOptions.setOnlyLoadDocumentProperties(true);

Presentation metadataPresentation = new Presentation(outputPath, metadataLoadOptions);
try {
    if (metadataPresentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        System.out.println("Title: " + metadataPresentation.getDocumentProperties().getTitle());
        System.out.println("Keywords: " + metadataPresentation.getDocumentProperties().getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    metadataPresentation.dispose();
}
```

Jeśli aplikacja nie ma uprawnień do odszyfrowania lub załadowania zawartości prezentacji, musi traktować publiczne właściwości zaszyfrowanego pliku PPTX jako tylko do odczytu.

## **Dostęp do wbudowanych właściwości**

Właściwości udostępniane przez obiekt [IDocumentProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/idocumentproperties) obejmują: **Creator** (Autor), **Description**, **Keywords**, **Created** (Data utworzenia), **Modified** (Data modyfikacji), **Printed** (Data ostatniego wydruku), **LastModifiedBy**, **SharedDoc** (Czy współdzielona między różnymi twórcami?), **PresentationFormat**, **Subject** oraz **Title**.

```java
import com.aspose.slides.*;

// Utwórz instancję klasy Presentation reprezentującej prezentację
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Utwórz odniesienie do obiektu IDocumentProperties powiązanego z prezentacją
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

## **Modyfikacja wbudowanych właściwości**

Modyfikowanie wbudowanych właściwości plików prezentacji jest tak proste, jak ich odczyt. Wystarczy przypisać wartość tekstową do dowolnej żądanej właściwości, a wartość zostanie zmieniona. W poniższym przykładzie pokazujemy, jak zmodyfikować wbudowane właściwości dokumentu prezentacji przy użyciu Aspose.Slides dla Androida w Javie.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Utwórz odniesienie do obiektu IDocumentProperties powiązanego z prezentacją
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

Przykład ten modyfikuje wbudowane właściwości prezentacji, co można zobaczyć na poniższym obrazku:

|**Wbudowane właściwości dokumentu po modyfikacji**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Dodawanie niestandardowych właściwości dokumentu**

Aspose.Slides dla Androida w Javie umożliwia także programistom dodawanie niestandardowych wartości do właściwości dokumentu prezentacji. Poniższy przykład dodaje trzy niestandardowe właściwości, następnie wyszukuje nazwę przechowywaną pod indeksem 2 i usuwa tę właściwość, dzięki czemu zapisana prezentacja zachowuje dwie z nich. Niestandardowe właściwości są indeksowane w kolejności alfabetycznej, a nie w kolejności ich dodania.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Pobieranie właściwości dokumentu
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // Dodawanie własnych właściwości
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

|**Dodane niestandardowe właściwości dokumentu**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Dostęp i modyfikacja niestandardowych właściwości**

Aspose.Slides dla Androida w Javie pozwala także programistom na dostęp do wartości niestandardowych właściwości. Poniżej znajduje się przykład pokazujący, jak uzyskać dostęp i zmodyfikować wszystkie te niestandardowe właściwości w prezentacji.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Utwórz odniesienie do obiektu DocumentProperties powiązanego z prezentacją
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Uzyskaj dostęp i zmodyfikuj własne właściwości
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Wyświetl nazwy i wartości własnych właściwości
        System.out.println("Custom Property Name : " + dp.getCustomPropertyName(i));
        System.out.println("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // Modyfikuj wartości własnych właściwości
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    
    // Zapisz swoją prezentację do pliku
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Przykład ten modyfikuje niestandardowe właściwości [PPTX ](https://docs.fileformat.com/presentation/pptx/). Następujące rysunki przedstawiają niestandardowe właściwości prezentacji przed i po modyfikacji:

|**Niestandardowe właściwości przed modyfikacją**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Niestandardowe właściwości po modyfikacji**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Zaawansowane właściwości dokumentu**

{{% alert color="info" title="Uwaga" %}}

Dodano nowe metody [ReadDocumentProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), oraz [WriteBindedPresentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) do interfejsu [IPresentationInfo](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IPresentationInfo); logika właściwości [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) została zmieniona.

{{% /alert %}} 

Dwie nowe metody [ReadDocumentProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--) i [UpdateDocumentProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) zostały dodane do interfejsu [IPresentationInfo](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IPresentationInfo). Umożliwiają szybki dostęp do właściwości dokumentu oraz ich zmianę i aktualizację bez ładowania całej prezentacji.

Typowy scenariusz ładowania właściwości, zmiany wartości i aktualizacji dokumentu można zaimplementować w następujący sposób:

```java
import com.aspose.slides.*;

// odczytaj informacje o prezentacji
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// obtain the current properties
IDocumentProperties props = info.readDocumentProperties();

// set the new values of Author and Title fields
props.setAuthor("New Author");
props.setTitle("New Title");

// update the presentation with a new values
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

## **Ustaw język korekty**

Aspose.Slides udostępnia właściwość LanguageId (eksponowaną przez klasę PortionFormat), aby umożliwić ustawienie języka korekty dla dokumentu PowerPoint. Język korekty to język, dla którego sprawdzane są pisownia i gramatyka w PowerPoint.

Ten kod Java pokazuje, jak ustawić język korekty dla PowerPoint:

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

    portionFormat.setLanguageId("zh-CN"); // ustaw identyfikator języka korekty

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

    // Sprawdza język pierwszej części
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Przykład na żywo**

Wypróbuj aplikację online [**Aspose.Slides Metadata**](https://products.aspose.app/slides/pl/metadata), aby zobaczyć, jak pracować z właściwościami dokumentu za pomocą API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/pl/metadata)

## **FAQ**

**Jak usunąć wbudowaną właściwość z prezentacji?**

Wbudowane właściwości są integralną częścią prezentacji i nie mogą być całkowicie usunięte. Można jednak zmienić ich wartości lub ustawić je jako puste, jeśli dana właściwość na to pozwala.

**Co się stanie, jeśli dodam niestandardową właściwość, która już istnieje?**

Jeśli dodasz niestandardową właściwość, która już istnieje, jej istniejąca wartość zostanie nadpisana nową. Nie musisz usuwać ani sprawdzać właściwości wcześniej, ponieważ Aspose.Slides automatycznie aktualizuje jej wartość.

**Czy mogę uzyskać dostęp do właściwości prezentacji bez pełnego ładowania prezentacji?**

Tak. Użyj [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) i następnie [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) aby odczytać zapisane metadane dokumentu bez tworzenia instancji [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/). Zobacz [Build a Lightweight Presentation Inventory](/slides/pl/androidjava/examine-presentation/) po kompletny przykład raportowania i ograniczenia specyficzne dla formatów.

**Czy mogę odczytać publiczne właściwości zaszyfrowanej prezentacji bez jej hasła otwierającego?**

Tak. Szyfrowanie właściwości dokumentu musiało być wyłączone przed zaszyfrowaniem prezentacji, a prezentacja musi być załadowana w trybie wyłącznie właściwości dokumentu.

**Czy mogę zaktualizować zaszyfrowany plik PPTX w trybie wyłącznie właściwości dokumentu?**

Nie. Publiczne i zaszyfrowane dane właściwości muszą pozostać spójne, więc aktualizacja zaszyfrowanego pliku PPTX wymaga pełnego załadowania prezentacji z prawidłowym hasłem otwierającym.