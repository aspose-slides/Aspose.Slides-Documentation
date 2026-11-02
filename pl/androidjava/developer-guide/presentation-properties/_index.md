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
description: "Zarządzaj właściwościami prezentacji w Aspose.Slides for Android via Java i usprawnij wyszukiwanie, branding oraz przepływ pracy w swoich plikach PowerPoint i OpenDocument."
---
## **Wprowadzenie**

Aspose.Slides for Android via Java obsługuje **wbudowane** i **niestandardowe** właściwości dokumentu. Użyj tych właściwości, aby odczytywać i aktualizować metadane prezentacji, takie jak autor, tytuł i wartości definiowane przez użytkownika.

Aspose.Slides umożliwia pracę z właściwościami dokumentu prezentacji za pośrednictwem interfejsu [IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/) . Instancja tego interfejsu jest zwracana przez metodę [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--) . Poniższe przykłady pokazują, jak odczytywać, modyfikować i zarządzać tymi właściwościami.

{{% alert color="info" title="Note" %}}
Aspose.Slides zarządza metadanymi aplikacji i producenta podczas zapisywania prezentacji; pola te identyfikują oprogramowanie, które wygenerowało wynik.
{{% /alert %}}

## **Zarządzanie właściwościami prezentacji**

Właściwości dokumentu przechowują opisowe informacje obok treści prezentacji. Dzielą się na dwie kategorie:

- **Wbudowane właściwości** zawierają standardowe metadane, takie jak tytuł, autor i statystyki dokumentu.
- **Niestandardowe właściwości** przechowują pary nazw/wartości definiowane przez użytkownika.

Aspose.Slides for Android via Java zapewnia dostęp do obu kategorii. W programie PowerPoint wybierz **File → Info → Properties → Advanced Properties**, aby przeglądać metadane dokumentu. Okno dialogowe grupuje informacje w zakładkach, takich jak **Summary**, **Statistics**, **Contents** i **Custom**. Użyj zakładki **Custom**, aby zarządzać właściwościami definiowanymi przez użytkownika.

## **Odczyt publicznych właściwości z zaszyfrowanej prezentacji**

Hasło otwierające zazwyczaj chroni zarówno zawartość prezentacji, jak i właściwości dokumentu. Gdy prezentacja jest szyfrowana po wywołaniu metody [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) z wartością `false`, jej właściwości dokumentu pozostają publiczne. Aplikacja może wtedy wywołać [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) z wartością `true` i odczytać publiczne metadane bez podawania hasła otwierającego.

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) kontroluje, co Aspose.Slides ładuje; nie odszyfrowuje niczego. Jeśli właściwości zostały objęte szyfrowaniem, ich ładowanie bez hasła kończy się niepowodzeniem. Jeśli prezentacja nie jest zaszyfrowana, opcja jest ignorowana i ładowana jest pełna prezentacja.

Przykład wymaga zaszyfrowanej prezentacji, której właściwości dokumentu pozostawiono publiczne. Weryfikuje tryb ładowania za pomocą [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) i następnie odczytuje wbudowane właściwości za pośrednictwem [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--):
```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        IDocumentProperties documentProperties = presentation.getDocumentProperties();

        System.out.println("Author: " + documentProperties.getAuthor());
        System.out.println("Title: " + documentProperties.getTitle());
        System.out.println("Keywords: " + documentProperties.getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

W tym trybie zawartość slajdów nie jest ładowana. Slajdy, szablony, układy, kształty, multimedia i inne obiekty prezentacji są niedostępne. Aplikacje powinny zawsze sprawdzać [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) przed wykonaniem operacji wymagającej pełnego modelu obiektowego prezentacji.

{{% alert color="warning" title="Warning" %}}
Publiczne metadane mogą ujawnić nazwiska autorów, tytuły, tematy, słowa kluczowe, informacje o firmie, komentarze oraz wartości niestandardowe. Szyfruj wrażliwe właściwości razem z prezentacją. Pozostaw je publiczne tylko wtedy, gdy systemy indeksowania, klasyfikacji, wyszukiwania lub zarządzania dokumentami mają konkretny wymóg dostępu do nich bez hasła.
{{% /alert %}}

## **Aktualizacja właściwości zaszyfrowanej prezentacji**

W przypadku zaszyfrowanego pliku PPTX, prezentacja załadowana po wywołaniu [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) z wartością `true` służy do odczytu publicznych metadanych. Aspose.Slides nie może zapisać zmienionych właściwości z tego obiektu zawierającego wyłącznie metadane, ponieważ publiczne właściwości muszą pozostać zgodne z odpowiadającymi danymi wewnątrz zaszyfrowanej prezentacji. Aktualizacja wymaga więc prawidłowego hasła otwierającego oraz pełnego ładowania.

Przykład wymaga zaszyfrowanej prezentacji PPTX z publicznymi właściwościami dokumentu oraz znanym hasłem otwierającym. Otwiera pełną prezentację przy użyciu [LoadOptions.setPassword](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-), aktualizuje publiczne wbudowane właściwości i zapisuje wynik. Następnie używa [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationinfo/#isEncrypted--) aby zweryfikować, że szyfrowanie zostało zachowane, i ponownie otwiera publiczne metadane bez hasła, aby sprawdzić nowe wartości:
```java
import com.aspose.slides.IDocumentProperties;
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
    IDocumentProperties documentProperties = presentation.getDocumentProperties();
    documentProperties.setTitle("Updated Product Roadmap");
    documentProperties.setKeywords("roadmap, planning, indexed");
    
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

Jeśli aplikacja nie ma zezwolenia na odszyfrowanie lub załadowanie zawartości prezentacji, musi traktować publiczne właściwości zaszyfrowanego pliku PPTX jako tylko do odczytu.

## **Dostęp do wbudowanych właściwości**

Interfejs [IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/) udostępnia wbudowane metadane za pośrednictwem metod getter, w tym [getAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getAuthor--), [getTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getTitle--), oraz [getCreatedTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getCreatedTime--). Ten przykład otwiera istniejącą prezentację i wypisuje jej zapisane metadane na konsolę. Wartości zależą od wejściowej prezentacji; niektóre pola mogą być puste.
```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    System.out.println("Category: " + documentProperties.getCategory());
    System.out.println("Content status: " + documentProperties.getContentStatus());
    System.out.println("Creation date: " + documentProperties.getCreatedTime());
    System.out.println("Author: " + documentProperties.getAuthor());
    System.out.println("Comments: " + documentProperties.getComments());
    System.out.println("Keywords: " + documentProperties.getKeywords());
    System.out.println("Last modified by: " + documentProperties.getLastSavedBy());
    System.out.println("Manager: " + documentProperties.getManager());
    System.out.println("Modified date: " + documentProperties.getLastSavedTime());
    System.out.println("Presentation format: " + documentProperties.getPresentationFormat());
    System.out.println("Last print date: " + documentProperties.getLastPrinted());
    System.out.println("Is shared between producers: " + documentProperties.getSharedDoc());
    System.out.println("Subject: " + documentProperties.getSubject());
    System.out.println("Title: " + documentProperties.getTitle());
} finally {
    presentation.dispose();
}
```

## **Modyfikacja wbudowanych właściwości**

Aby zaktualizować wbudowane metadane, użyj metod setter na obiekcie zwróconym przez [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--) . Ten przykład otwiera istniejącą prezentację, wywołuje [setAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setAuthor-java.lang.String-), [setTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setTitle-java.lang.String-), [setSubject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setSubject-java.lang.String-), [setComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setComments-java.lang.String-) oraz [setManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setManager-java.lang.String-), a następnie zapisuje zaktualizowaną prezentację przy użyciu [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) . Zapisany plik PPTX zawiera nowe metadane.
```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    documentProperties.setAuthor("Aspose.Slides for Android via Java");
    documentProperties.setTitle("Manage PowerPoint Presentation Properties");
    documentProperties.setSubject("Modify Built-in Properties");
    documentProperties.setComments("Aspose description");
    documentProperties.setManager("Aspose manager");

    presentation.save("DocumentProperties_output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Zarządzanie bazą hiperłącza**

[IDocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getHyperlinkBase--) zwraca bazowy poziom dokumentu dla relatywnych hiperlinków. Użyj [IDocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setHyperlinkBase-java.lang.String-) , aby go zmienić lub wyczyścić. Jest to przydatne przy przenoszeniu prezentacji i jej powiązanych plików w inne miejsce. Jest to oddzielne od [IHyperlink.getExternalUrl](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getExternalUrl--) pojedynczego hiperłącza: zmiana bazy nie powoduje przepisania zapisanych adresów linków ani zmiany ich bezwzględnych celów.

Przykład wymaga prezentacji zawierającej zarówno relatywny link, taki jak `target.html`, jak i bezwzględny link, taki jak `https://example.org/absolute.html`. Odczytuje istniejącą bazę, przypisuje nowy adres bazy, zapisuje i ponownie otwiera prezentację w celu sprawdzenia wartości. Następnie czyści bazę za pomocą pustego ciągu i weryfikuje pustą wartość w osobnym zapisanym pliku. Zastąp przykładowy adres bazy lokalizacją swoich plików powiązanych.
```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("hyperlinks.pptx");
try {
    System.out.println("Original base: " + presentation.getDocumentProperties().getHyperlinkBase());

    final String newBase = "https://example.com/new/";
    presentation.getDocumentProperties().setHyperlinkBase(newBase);
    presentation.save("hyperlinks-updated.pptx", SaveFormat.Pptx);

    Presentation updatedPresentation = new Presentation("hyperlinks-updated.pptx");
    try {
        System.out.println("Base preserved: " + newBase.equals(updatedPresentation.getDocumentProperties().getHyperlinkBase()));

        updatedPresentation.getDocumentProperties().setHyperlinkBase("");
        updatedPresentation.save("hyperlinks-cleared.pptx", SaveFormat.Pptx);

        Presentation clearedPresentation = new Presentation("hyperlinks-cleared.pptx");
        try {
            System.out.println("Base cleared: " + "".equals(clearedPresentation.getDocumentProperties().getHyperlinkBase()));
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

Oba komunikaty weryfikacyjne powinny wypisać `true`. Czyszczenie bazy pozostawia niezmienione adresy poszczególnych hiperłączy.

Relatywny link do `target.pptx` otwierał `old/target.pptx`, gdy baza wskazywała na folder `old`. Po zmianie bazy na folder `new`, zapisaniu i ponownym otwarciu prezentacji, ten sam link otworzył `new/target.pptx`. Bezpośredni link nadal otwierał ten sam plik. Przetestuj swoje relatywne linki w programie PowerPoint przed i po przeniesieniu prezentacji lub zmianie jej bazy.

## **Dodawanie niestandardowych właściwości prezentacji**

Niestandardowe właściwości przechowują metadane, które nie mają odpowiedniego wbudowanego pola. Metoda [IDocumentProperties.set_Item](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-) pozwala przypisać wartość według nazwy właściwości. Ten przykład tworzy prezentację, dodaje dwie wartości tekstowe oraz całkowitą wartość wersji i zapisuje prezentację przy użyciu [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) . Przypisanie wartości do istniejącej nazwy zastępuje wartość tej właściwości.
```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    documentProperties.set_Item("Reviewed by", "John Smith");
    documentProperties.set_Item("Confidentiality level", "Internal");
    documentProperties.set_Item("Document version", 2);

    presentation.save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Dostęp i modyfikacja niestandardowych właściwości**

Ten przykład otwiera prezentację zawierającą niestandardowe właściwości i używa [getCountOfCustomProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getCountOfCustomProperties--) do iteracji po nich. [getCustomPropertyName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getCustomPropertyName-int-) przyjmuje indeks zerowy i zwraca nazwę używaną przez [IDocumentProperties.set_Item](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-) . Przykład wypisuje każdą oryginalną nazwę i wartość, zastępuje każdą wartość numerowaną ciągiem niezależnie od jej pierwotnego typu oraz zapisuje zmiany. Jeśli nie ma niestandardowych właściwości, pętla nie wprowadza zmian.
```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    for (int i = 0; i < documentProperties.getCountOfCustomProperties(); i++) {
        String propertyName = documentProperties.getCustomPropertyName(i);
        Object propertyValue = documentProperties.get_Item(propertyName);

        System.out.println("Custom property name: " + propertyName);
        System.out.println("Custom property value: " + propertyValue);

        documentProperties.set_Item(propertyName, "New Value " + (i + 1));
    }

    presentation.save("CustomProperties_output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Przykład na żywo**

Wypróbuj aplikację online [**Wyświetl i edytuj metadane PowerPoint**](https://products.aspose.app/slides/metadata), aby zobaczyć, jak pracować z właściwościami dokumentu przy użyciu API Aspose.Slides:

[![Wyświetl i edytuj metadane PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**Jak mogę usunąć wbudowaną właściwość z prezentacji?**

Wbudowane właściwości są integralną częścią prezentacji i nie mogą być całkowicie usunięte. Można jednak zmienić ich wartości lub ustawić je jako puste, o ile dana właściwość na to pozwala.

**Co się stanie, jeśli dodam niestandardową właściwość, która już istnieje?**

Jeśli dodasz niestandardową właściwość, która już istnieje, jej obecna wartość zostanie nadpisana nową. Nie musisz usuwać ani sprawdzać właściwości wcześniej, ponieważ Aspose.Slides automatycznie aktualizuje wartość właściwości.

**Czy mogę uzyskać dostęp do właściwości prezentacji bez pełnego ładowania prezentacji?**

Tak. Użyj [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) a następnie [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) , aby odczytać przechowywane metadane dokumentu bez tworzenia instancji [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) . Zobacz [Build a Lightweight Presentation Inventory](/slides/pl/androidjava/examine-presentation/) po kompletny przykład raportowania i ograniczenia specyficzne dla formatu.

**Czy mogę odczytać publiczne właściwości zaszyfrowanej prezentacji bez jej hasła otwierającego?**

Tak. Prezentacja musi zostać zaszyfrowana po wywołaniu [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) z wartością `false`, oraz musi być załadowana po wywołaniu [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) z wartością `true`.

**Czy mogę zaktualizować zaszyfrowany plik PPTX w trybie tylko-właściwości-dokumentu?**

Nie. Publiczne i zaszyfrowane dane właściwości muszą pozostawać spójne, więc aktualizacja zaszyfrowanego pliku PPTX wymaga załadowania pełnej prezentacji z prawidłowym hasłem otwierającym.