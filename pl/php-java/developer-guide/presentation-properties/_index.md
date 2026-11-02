---
title: Zarządzanie właściwościami prezentacji w PHP
linktitle: Właściwości prezentacji
type: docs
weight: 70
url: /pl/php-java/presentation-properties/
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
- Język domyślny
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Opanuj właściwości prezentacji w Aspose.Slides for PHP via Java i usprawnij wyszukiwanie, brandowanie oraz przepływ pracy w swoich plikach PowerPoint i OpenDocument."
---
## **Wprowadzenie**

Aspose.Slides for PHP via Java obsługuje **wbudowane** i **niestandardowe** właściwości dokumentu. Użyj tych właściwości, aby odczytywać i aktualizować metadane prezentacji, takie jak autor, tytuł oraz wartości definiowane przez użytkownika.

Aspose.Slides umożliwia pracę z właściwościami dokumentu prezentacji za pomocą klasy [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/). Instancja tej klasy jest zwracana przez [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getdocumentproperties/). Poniższe przykłady pokazują, jak odczytywać, modyfikować i zarządzać tymi właściwościami. Zakładają, że PHP/Java Bridge oraz wrapper Aspose.Slides dla PHP zostały zainicjowane.

{{% alert color="info" title="Note" %}}
Aspose.Slides zarządza metadanymi aplikacji i producenta podczas zapisywania prezentacji; pola te identyfikują oprogramowanie, które utworzyło wynik.
{{% /alert %}}

## **Zarządzanie właściwościami prezentacji**

Właściwości dokumentu przechowują opisowe informacje razem z zawartością prezentacji. Dzielą się na dwie kategorie:

- **Wbudowane właściwości** zawierają standardowe metadane, takie jak tytuł, autor i statystyki dokumentu.  
- **Niestandardowe właściwości** przechowują pary nazwa/wartość definiowane przez użytkownika.

Aspose.Slides for PHP via Java zapewnia dostęp do obu kategorii. W programie PowerPoint wybierz **Plik → Informacje → Właściwości → Właściwości zaawansowane**, aby przejrzeć metadane dokumentu. Okno dialogowe grupuje informacje w zakładkach, takich jak **Podsumowanie**, **Statystyki**, **Zawartość** i **Niestandardowe**. Użyj zakładki **Niestandardowe**, aby zarządzać właściwościami definiowanymi przez użytkownika.

## **Odczyt publicznych właściwości z zaszyfrowanej prezentacji**

Hasło otwierające zazwyczaj chroni zarówno zawartość prezentacji, jak i właściwości dokumentu. Gdy prezentacja jest szyfrowana po wywołaniu [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/setencryptdocumentproperties/) z wartością `false`, jej właściwości dokumentu pozostają publiczne. Aplikacja może wtedy wywołać [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) z wartością `true` i odczytać publiczne metadane bez podawania hasła otwierającego.

[LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) kontroluje, co Aspose.Slides ładuje; nie dokonuje żadnego odszyfrowywania. Jeśli właściwości zostały objęte szyfrowaniem, ich ładowanie bez hasła kończy się niepowodzeniem. Jeśli prezentacja nie jest szyfrowana, opcja jest ignorowana i ładowana jest cała prezentacja.

Przykład wymaga zaszyfrowanej prezentacji, której właściwości dokumentu zostały pozostawione publiczne. Weryfikuje tryb ładowania za pomocą [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/isonlydocumentpropertiesloaded/) i następnie odczytuje wbudowane właściwości poprzez [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getdocumentproperties/):

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setOnlyLoadDocumentProperties(true);

$presentation = new Presentation("public-properties-encrypted.pptx", $loadOptions);
try {
    if (java_values($presentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        $documentProperties = $presentation->getDocumentProperties();

        echo("Author: " . $documentProperties->getAuthor() . "\n");
        echo("Title: " . $documentProperties->getTitle() . "\n");
        echo("Keywords: " . $documentProperties->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode." . "\n");
    }
} finally {
    $presentation->dispose();
}
```

W tym trybie zawartość slajdów nie jest ładowana. Slajdy, wzorce, układy, kształty, multimedia i inne obiekty prezentacji są niedostępne. Aplikacje powinny zawsze sprawdzać [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/isonlydocumentpropertiesloaded/) przed wykonaniem operacji wymagającej pełnego modelu obiektowego prezentacji.

{{% alert color="warning" title="Warning" %}}
Publiczne metadane mogą ujawnić nazwiska autorów, tytuły, tematy, słowa kluczowe, informacje o firmie, komentarze i niestandardowe wartości. Szyfruj wrażliwe właściwości razem z prezentacją. Pozostaw je publiczne tylko wtedy, gdy systemy indeksowania, klasyfikacji, wyszukiwania lub zarządzania dokumentami mają konkretny wymóg dostępu do nich bez hasła.
{{% /alert %}}

## **Aktualizacja właściwości zaszyfrowanej prezentacji**

W przypadku zaszyfrowanego pliku PPTX prezentacja załadowana po wywołaniu [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) z wartością `true` służy do odczytu publicznych metadanych. Aspose.Slides nie może zapisać zmienionych właściwości z takiego obiektu trybu „tylko właściwości dokumentu”, ponieważ publiczne właściwości muszą pozostać zgodne z danymi wewnątrz zaszyfrowanej prezentacji. Aktualizacja wymaga więc poprawnego hasła otwierającego oraz pełnego załadowania prezentacji.

Przykład wymaga zaszyfrowanej prezentacji PPTX z publicznymi właściwościami dokumentu oraz znanego hasła otwierającego. Otwiera pełną prezentację przy użyciu [LoadOptions::setPassword](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setpassword/), aktualizuje publiczne wbudowane właściwości i zapisuje wynik. Następnie korzysta z [PresentationInfo::isEncrypted](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/isencrypted/), aby zweryfikować, że szyfrowanie zostało zachowane, oraz ponownie otwiera publiczne metadane bez hasła, aby sprawdzić nowe wartości:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;
use aspose\slides\SaveFormat;

$inputPath = "public-properties-encrypted.pptx";
$outputPath = "updated-public-properties-encrypted.pptx";

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation($inputPath, $loadOptions);
try {
    $documentProperties = $presentation->getDocumentProperties();
    $documentProperties->setTitle("Updated Product Roadmap");
    $documentProperties->setKeywords("roadmap, planning, indexed");
    
    $presentation->save($outputPath, SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($outputPath);
echo("The presentation is encrypted: " . (java_values($presentationInfo->isEncrypted()) ? "true" : "false") . "\n");

$metadataLoadOptions = new LoadOptions();
$metadataLoadOptions->setOnlyLoadDocumentProperties(true);

$metadataPresentation = new Presentation($outputPath, $metadataLoadOptions);
try {
    if (java_values($metadataPresentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        echo("Title: " . $metadataPresentation->getDocumentProperties()->getTitle() . "\n");
        echo("Keywords: " . $metadataPresentation->getDocumentProperties()->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode." . "\n");
    }
} finally {
    $metadataPresentation->dispose();
}
```

Jeśli aplikacja nie ma uprawnień do odszyfrowania lub załadowania zawartości prezentacji, musi traktować publiczne właściwości zaszyfrowanego pliku PPTX jako tylko do odczytu.

## **Dostęp do wbudowanych właściwości**

Klasa [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) udostępnia wbudowane metadane poprzez metody getter, w tym [getAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getauthor/), [getTitle](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/gettitle/) i [getCreatedTime](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getcreatedtime/). Ten przykład otwiera istniejącą prezentację i wypisuje jej zapisane metadane na konsoli. Wartości zależą od konkretnej prezentacji; niektóre pola mogą być puste.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("AccessBuiltInProperties.pptx");
try {
    $documentProperties = $presentation->getDocumentProperties();

    echo("Category: " . $documentProperties->getCategory() . "\n");
    echo("Content status: " . $documentProperties->getContentStatus() . "\n");
    echo("Creation date: " . $documentProperties->getCreatedTime() . "\n");
    echo("Author: " . $documentProperties->getAuthor() . "\n");
    echo("Comments: " . $documentProperties->getComments() . "\n");
    echo("Keywords: " . $documentProperties->getKeywords() . "\n");
    echo("Last modified by: " . $documentProperties->getLastSavedBy() . "\n");
    echo("Manager: " . $documentProperties->getManager() . "\n");
    echo("Modified date: " . $documentProperties->getLastSavedTime() . "\n");
    echo("Presentation format: " . $documentProperties->getPresentationFormat() . "\n");
    echo("Last print date: " . $documentProperties->getLastPrinted() . "\n");
    echo("Is shared between producers: " . (java_values($documentProperties->getSharedDoc()) ? "true" : "false") . "\n");
    echo("Subject: " . $documentProperties->getSubject() . "\n");
    echo("Title: " . $documentProperties->getTitle() . "\n");
} finally {
    $presentation->dispose();
}
```

## **Modyfikacja wbudowanych właściwości**

Aby zaktualizować wbudowane metadane, użyj metod setter na obiekcie zwróconym przez [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getdocumentproperties/). Ten przykład otwiera istniejącą prezentację, wywołuje [setAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setauthor/), [setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/settitle/), [setSubject](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setsubject/), [setComments](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setcomments/) oraz [setManager](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setmanager/), a następnie zapisuje zaktualizowaną prezentację przy użyciu [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/). Zapisany plik PPTX zawiera nowe metadane.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("ModifyBuiltInProperties.pptx");
try {
    $documentProperties = $presentation->getDocumentProperties();

    $documentProperties->setAuthor("Aspose.Slides for PHP via Java");
    $documentProperties->setTitle("Manage PowerPoint Presentation Properties");
    $documentProperties->setSubject("Modify Built-in Properties");
    $documentProperties->setComments("Aspose description");
    $documentProperties->setManager("Aspose manager");

    $presentation->save("DocumentProperties_output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Zarządzanie bazą hiperłącza**

[DocumentProperties::getHyperlinkBase](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/gethyperlinkbase/) zwraca bazowy adres dokumentu dla względnych hiperłączy. Użyj [DocumentProperties::setHyperlinkBase](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/sethyperlinkbase/), aby zmienić go lub wyczyścić. Jest to przydatne przy przenoszeniu prezentacji i powiązanych plików w inne miejsce. Nie wpływa to na indywidualny adres [Hyperlink::getExternalUrl](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getexternalurl/): zmiana bazy nie przepisuje zapisanych adresów linków ani nie zmienia ich bezwzględnych docelowych lokalizacji.

Przykład wymaga prezentacji zawierającej zarówno względny link (np. `target.html`), jak i bezwzględny link (np. `https://example.org/absolute.html`). Odczytuje istniejącą bazę, przypisuje nowy adres bazowy, zapisuje i ponownie otwiera prezentację, aby sprawdzić wartość. Następnie czyści bazę, ustawiając pusty ciąg znaków, i weryfikuje pustą wartość w osobnym zapisanym pliku. Zamień przykładowy adres bazowy na lokalizację swoich plików powiązanych.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("hyperlinks.pptx");
try {
    echo("Original base: " . $presentation->getDocumentProperties()->getHyperlinkBase() . "\n");

    $newBase = "https://example.com/new/";
    $presentation->getDocumentProperties()->setHyperlinkBase($newBase);
    $presentation->save("hyperlinks-updated.pptx", SaveFormat::Pptx);

    $updatedPresentation = new Presentation("hyperlinks-updated.pptx");
    try {
        echo("Base preserved: " . ((string) $updatedPresentation->getDocumentProperties()->getHyperlinkBase() === $newBase ? "true" : "false") . "\n");

        $updatedPresentation->getDocumentProperties()->setHyperlinkBase("");
        $updatedPresentation->save("hyperlinks-cleared.pptx", SaveFormat::Pptx);

        $clearedPresentation = new Presentation("hyperlinks-cleared.pptx");
        try {
            echo("Base cleared: " . ((string) $clearedPresentation->getDocumentProperties()->getHyperlinkBase() === "" ? "true" : "false") . "\n");
        } finally {
            $clearedPresentation->dispose();
        }
    } finally {
        $updatedPresentation->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Oba komunikaty weryfikacyjne powinny wypisać `true`. Czyszczenie bazy nie zmienia adresów poszczególnych hiperłączy.

Względny link do `target.pptx` otwierał `old/target.pptx`, gdy baza wskazywała folder `old`. Po zmianie bazy na folder `new`, zapisaniu i ponownym otwarciu prezentacji, ten sam link otwiera `new/target.pptx`. Bezpośredni link nadal otwierał ten sam plik. Przetestuj swoje względne linki w PowerPoint przed i po przeniesieniu prezentacji lub zmianie jej bazy.

## **Dodawanie niestandardowych właściwości prezentacji**

Niestandardowe właściwości przechowują metadane, które nie mają odpowiednika w wbudowanych polach. Metoda [DocumentProperties::set_Item](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/set_item/) umożliwia przypisanie wartości po nazwie właściwości. Ten przykład tworzy prezentację, dodaje dwie wartości tekstowe oraz wartość całkowitą wersji, i zapisuje prezentację przy użyciu [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/). Przypisanie wartości do istniejącej nazwy zastępuje dotychczasową wartość właściwości.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $documentProperties = $presentation->getDocumentProperties();

    $documentProperties->set_Item("Reviewed by", "John Smith");
    $documentProperties->set_Item("Confidentiality level", "Internal");
    $documentProperties->set_Item("Document version", 2);

    $presentation->save("CustomDocumentProperties_output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Dostęp i modyfikacja niestandardowych właściwości**

Ten przykład otwiera prezentację zawierającą niestandardowe właściwości i używa [getCountOfCustomProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getcountofcustomproperties/), aby je iterować. [getCustomPropertyName](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getcustompropertyname/) przyjmuje indeks zero‑based i zwraca nazwę używaną przez [DocumentProperties::set_Item](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/set_item/). Przykład wypisuje każdą oryginalną nazwę i wartość, zastępuje każdą wartość ciągiem numerowanym niezależnie od pierwotnego typu i zapisuje zmiany. Jeśli nie ma niestandardowych właściwości, pętla nie wprowadza zmian.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("AccessAndModifyProperties.pptx");
try {
    $documentProperties = $presentation->getDocumentProperties();

    for ($i = 0; $i < java_values($documentProperties->getCountOfCustomProperties()); $i++) {
        $propertyName = $documentProperties->getCustomPropertyName($i);
        $propertyValue = $documentProperties->get_Item($propertyName);

        echo("Custom property name: " . $propertyName . "\n");
        echo("Custom property value: " . $propertyValue . "\n");

        $documentProperties->set_Item($propertyName, "New Value " . ($i + 1));
    }

    $presentation->save("CustomProperties_output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Przykład na żywo**

Wypróbuj internetową aplikację [**Wyświetl i edytuj metadane PowerPoint**](https://products.aspose.app/slides/metadata), aby zobaczyć, jak pracować z właściwościami dokumentu przy użyciu API Aspose.Slides:

[![Wyświetl i edytuj metadane PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**Jak mogę usunąć wbudowaną właściwość z prezentacji?**

Wbudowane właściwości są integralną częścią prezentacji i nie mogą być całkowicie usunięte. Można jednak zmienić ich wartości lub, jeśli dana właściwość na to pozwala, ustawić je na pustą wartość.

**Co się stanie, jeśli dodam niestandardową właściwość, która już istnieje?**

Jeśli dodasz niestandardową właściwość, która już istnieje, jej dotychczasowa wartość zostanie nadpisana nową. Nie musisz usuwać ani sprawdzać właściwości wcześniej, ponieważ Aspose.Slides automatycznie aktualizuje jej wartość.

**Czy mogę uzyskać dostęp do właściwości prezentacji bez pełnego ładowania prezentacji?**

Tak. Użyj [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/presentationfactory/getpresentationinfo/) i potem [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/readdocumentproperties/), aby odczytać zapisane metadane dokumentu bez tworzenia instancji [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/). Zobacz [Zbuduj lekki inwentarz prezentacji](/slides/pl/php-java/examine-presentation/) po pełnym przykładzie raportowania oraz ograniczenia specyficzne dla formatu.

**Czy mogę odczytać publiczne właściwości zaszyfrowanej prezentacji bez jej hasła otwierającego?**

Tak. Prezentacja musi być zaszyfrowana po wywołaniu [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/setencryptdocumentproperties/) z wartością `false`, a następnie ładowana po wywołaniu [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) z wartością `true`.

**Czy mogę zaktualizować zaszyfrowany plik PPTX w trybie „tylko właściwości dokumentu”?**

Nie. Publiczne i zaszyfrowane dane właściwości muszą pozostać zgodne, więc aktualizacja zaszyfrowanego pliku PPTX wymaga pełnego załadowania prezentacji z poprawnym hasłem otwierającym.