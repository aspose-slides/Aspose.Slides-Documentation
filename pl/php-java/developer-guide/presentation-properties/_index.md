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
- Domyślny język
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Opanuj właściwości prezentacji w Aspose.Slides dla PHP via Java oraz usprawnij wyszukiwanie, branding i przepływ pracy w plikach PowerPoint i OpenDocument."
---
## **Wprowadzenie**

Aspose.Slides obsługuje dwa typy właściwości dokumentu: **Wbudowane** i **Niestandardowe**. Oba te typy właściwości można łatwo uzyskać i zarządzać przy użyciu API Aspose.Slides.

Aspose.Slides umożliwia pracę z właściwościami dokumentu prezentacji za pomocą klasy [DocumentProperties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/documentproperties/) . Instancja tej klasy jest zwracana przez metodę [Presentation::getDocumentProperties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#getDocumentProperties). Poniższe przykłady pokazują, jak odczytywać, modyfikować i zarządzać tymi właściwościami.

{{% alert color="info" title="Uwaga" %}}
Należy pamiętać, że pola **Application** i **AppVersion** nie mogą być modyfikowane. Aspose.Slides nadpisuje je przy każdym zapisie, więc zapisana prezentacja zawsze zgłasza „Aspose.Slides for PHP via Java” oraz wersję biblioteki, która ją wygenerowała. Każda wartość przekazana do `setNameOfApplication` jest odrzucana podczas zapisu prezentacji.
{{% /alert %}} 

## **Zarządzanie właściwościami prezentacji**

Microsoft PowerPoint udostępnia funkcję dodawania niektórych właściwości do plików prezentacji. Te właściwości dokumentu umożliwiają przechowywanie przydatnych informacji razem z dokumentami (plikami prezentacji). Istnieją dwa rodzaje właściwości dokumentu, jak poniżej.

- Właściwości systemowe (Wbudowane)
- Właściwości definiowane przez użytkownika (Niestandardowe)

**Wbudowane** właściwości zawierają informacje ogólne o dokumencie, takie jak tytuł dokumentu, imię i nazwisko autora, statystyki dokumentu itd. **Niestandardowe** właściwości to te definiowane przez użytkowników jako pary **Nazwa/Wartość**, gdzie zarówno nazwa, jak i wartość są określane przez użytkownika. Korzystając z Aspose.Slides dla PHP via Java, programiści mogą uzyskać dostęp i modyfikować wartości wbudowanych oraz niestandardowych właściwości.

## **Właściwości dokumentu w programie PowerPoint**

Microsoft PowerPoint 2007 pozwala na zarządzanie właściwościami dokumentu plików prezentacji. Wystarczy kliknąć ikonę Office, a następnie element menu **Prepare | Properties | Advanced Properties** w programie Microsoft PowerPoint 2007, jak pokazano poniżej:

|**Wybieranie elementu menu Advanced Properties**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| ** **|

Po wybraniu elementu menu **Advanced Properties** pojawi się okno dialogowe umożliwiające zarządzanie właściwościami dokumentu pliku PowerPoint, jak pokazano na rysunku poniżej:

|**Okno właściwości**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| ** **|

W powyższym **Oknie właściwości** można zobaczyć wiele kart, takich jak **General**, **Summary**, **Statistics**, **Contents** oraz **Custom**. Wszystkie te karty umożliwiają konfigurowanie różnych rodzajów informacji związanych z plikami PowerPoint. Karta **Custom** służy do zarządzania niestandardowymi właściwościami plików PowerPoint.

Praca z właściwościami dokumentu przy użyciu Aspose.Slides dla PHP via Java

Jak opisaliśmy wcześniej, Aspose.Slides dla PHP via Java obsługuje dwa rodzaje właściwości dokumentu: **Wbudowane** i **Niestandardowe**. Dlatego programiści mogą uzyskać dostęp do obu rodzajów właściwości przy użyciu API Aspose.Slides dla PHP via Java. Aspose.Slides dla PHP via Java udostępnia klasę [DocumentProperties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/documentproperties), która reprezentuje właściwości dokumentu powiązane z plikiem prezentacji poprzez właściwość **Presentation.DocumentProperties**.

Programiści mogą używać właściwości **DocumentProperties** udostępnionej przez obiekt [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation), aby uzyskać dostęp do właściwości dokumentu plików prezentacji, jak opisano poniżej:

## **Odczyt publicznych właściwości z zaszyfrowanej prezentacji**

Hasło otwierające zazwyczaj chroni zarówno zawartość prezentacji, jak i właściwości dokumentu. Gdy prezentacja jest szyfrowana przy przekazaniu `false` do [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties), jej właściwości dokumentu pozostają publiczne. Aplikacja może wtedy przekazać `true` do [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties), aby odczytać publiczne metadane bez podawania hasła otwierającego.

Opcja ładowania wyłącznie właściwości dokumentu kontroluje, co Aspose.Slides ładuje; nie dokonuje ona odszyfrowania. Jeśli właściwości zostały objęte szyfrowaniem, ich ładowanie bez hasła kończy się niepowodzeniem. Jeśli prezentacja nie jest szyfrowana, opcja jest ignorowana i ładowana jest pełna prezentacja.

Następujący przykład weryfikuje tryb ładowania za pomocą [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/pl/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded), a następnie odczytuje wbudowane właściwości za pomocą [Presentation::getDocumentProperties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#getDocumentProperties):

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setOnlyLoadDocumentProperties(true);

$presentation = new Presentation("public-properties-encrypted.pptx", $loadOptions);
try {
    if (java_values($presentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        $properties = $presentation->getDocumentProperties();

        echo("Author: " . $properties->getAuthor() . "\n");
        echo("Title: " . $properties->getTitle() . "\n");
        echo("Keywords: " . $properties->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode.\n");
    }
} finally {
    $presentation->dispose();
}
```

W tym trybie zawartość slajdów nie jest ładowana. Slajdy, master‑y, układy, kształty, media i inne obiekty prezentacji są niedostępne. Aplikacje powinny zawsze sprawdzać [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/pl/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded), przed wykonaniem operacji wymagającej pełnego modelu obiektowego prezentacji.

{{% alert color="warning" title="Ostrzeżenie" %}}
Publiczne metadane mogą ujawniać nazwiska autorów, tytuły, tematy, słowa kluczowe, informacje o firmie, komentarze i wartości niestandardowe. Zaszyfruj wrażliwe właściwości razem z prezentacją. Pozostaw je publiczne tylko wtedy, gdy indeksowanie, klasyfikacja, wyszukiwanie lub systemy zarządzania dokumentami mają konkretny wymóg dostępu do nich bez hasła.
{{% /alert %}}

## **Aktualizacja właściwości zaszyfrowanej prezentacji**

Dla zaszyfrowanego pliku PPTX prezentacja załadowana w trybie wyłącznie właściwości dokumentu służy do odczytu publicznych metadanych. Aspose.Slides nie może zapisać zmienionych właściwości z tego obiektu zawierającego jedynie metadane, ponieważ publiczne właściwości muszą pozostać zgodne z odpowiadającymi danymi w zaszyfrowanej prezentacji. Aktualizacja wymaga więc poprawnego hasła otwierającego i pełnego załadowania.

Następujący przykład otwiera prezentację przy użyciu [LoadOptions::setPassword](https://reference.aspose.com/slides/pl/php-java/aspose.slides/loadoptions/#setPassword), aktualizuje publiczne wbudowane właściwości i zapisuje wynik. Następnie używa [PresentationInfo::isEncrypted](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentationinfo/#isEncrypted), aby zweryfikować, że szyfrowanie zostało zachowane, i ponownie otwiera publiczne metadane bez hasła, aby sprawdzić nowe wartości:

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
    $presentation->getDocumentProperties()->setTitle("Updated Product Roadmap");
    $presentation->getDocumentProperties()->setKeywords("roadmap, planning, indexed");
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
        echo("The presentation was not loaded in document-properties-only mode.\n");
    }
} finally {
    $metadataPresentation->dispose();
}
```

Jeśli aplikacja nie ma uprawnień do odszyfrowania lub załadowania zawartości prezentacji, musi traktować publiczne właściwości zaszyfrowanego pliku PPTX jako tylko do odczytu.

## **Dostęp do wbudowanych właściwości**

Te właściwości udostępniane przez obiekt [DocumentProperties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/documentproperties) obejmują: **Creator** (Autor), **Description**, **Keywords**, **Created** (Data utworzenia), **Modified** (Data modyfikacji), **Printed** (Data ostatniego wydruku), **LastModifiedBy**, **Keywords**, **SharedDoc** (Czy jest współdzielony między różnymi producentami?), **PresentationFormat**, **Subject** i **Title**.

```php
  # Utwórz instancję klasy Presentation, która reprezentuje prezentację
  $pres = new Presentation("Presentation.pptx");
  try {
    # Utwórz odwołanie do obiektu IDocumentProperties powiązanego z prezentacją
    $dp = $pres->getDocumentProperties();
    # Wyświetl wbudowane właściwości
    echo("Category : " . $dp->getCategory());
    echo("Current Status : " . $dp->getContentStatus());
    echo("Creation Date : " . $dp->getCreatedTime());
    echo("Author : " . $dp->getAuthor());
    echo("Description : " . $dp->getComments());
    echo("KeyWords : " . $dp->getKeywords());
    echo("Last Modified By : " . $dp->getLastSavedBy());
    echo("Supervisor : " . $dp->getManager());
    echo("Modified Date : " . $dp->getLastSavedTime());
    echo("Presentation Format : " . $dp->getPresentationFormat());
    echo("Last Print Date : " . $dp->getLastPrinted());
    echo("Is Shared between producers : " . $dp->getSharedDoc());
    echo("Subject : " . $dp->getSubject());
    echo("Title : " . $dp->getTitle());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Modyfikacja wbudowanych właściwości**

Modyfikowanie wbudowanych właściwości plików prezentacji jest tak proste, jak ich odczytywanie. Można po prostu przypisać wartość tekstową dowolnej właściwości, a jej wartość zostanie zmodyfikowana. W poniższym przykładzie przedstawiono, jak zmodyfikować wbudowane właściwości dokumentu pliku prezentacji przy użyciu Aspose.Slides dla PHP via Java.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Utwórz odwołanie do obiektu IDocumentProperties powiązanego z prezentacją
    $dp = $pres->getDocumentProperties();
    # Ustaw wbudowane właściwości
    $dp->setAuthor("Aspose.Slides for PHP via Java");
    $dp->setTitle("Modifying Presentation Properties");
    $dp->setSubject("Aspose Subject");
    $dp->setComments("Aspose Description");
    $dp->setManager("Aspose Manager");
    # Zapisz prezentację do pliku
    $pres->save("DocProps.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Ten przykład modyfikuje wbudowane właściwości prezentacji, które można zobaczyć jak poniżej:

|**Wbudowane właściwości dokumentu po modyfikacji**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| ** **|

## **Dodawanie niestandardowych właściwości dokumentu**

Aspose.Slides dla PHP via Java umożliwia również programistom dodawanie niestandardowych wartości do właściwości dokumentu prezentacji. Poniżej przedstawiono przykład, jak ustawić niestandardowe właściwości dla prezentacji.

```php
  $pres = new Presentation();
  try {
    # Pobieranie właściwości dokumentu
    $dProps = $pres->getDocumentProperties();
    # Dodawanie niestandardowych właściwości
    $dProps->set_Item("New Custom", 12);
    $dProps->set_Item("My Name", "Mudassir");
    $dProps->set_Item("Custom", 124);
    # Pobieranie nazwy właściwości pod określonym indeksem
    $getPropertyName = $dProps->getCustomPropertyName(2);
    # Usuwanie wybranej właściwości
    $dProps->removeCustomProperty($getPropertyName);
    # Zapisywanie prezentacji
    $pres->save("CustomDemo.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|**Dodane niestandardowe właściwości dokumentu**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| ** **|

## **Dostęp i modyfikacja niestandardowych właściwości**

Aspose.Slides dla PHP via Java umożliwia także programistom dostęp do wartości niestandardowych właściwości. Poniżej znajduje się przykład, który pokazuje, jak uzyskać dostęp i zmodyfikować wszystkie te niestandardowe właściwości w prezentacji.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Utwórz odwołanie do obiektu DocumentProperties powiązanego z prezentacją
    $dp = $pres->getDocumentProperties();
    # Uzyskaj dostęp i zmodyfikuj niestandardowe właściwości
    for($i = 0; $i < java_values($dp->getCountOfCustomProperties()) ; $i++) {
      # Wyświetl nazwy i wartości niestandardowych właściwości
      echo("Custom Property Name : " . $dp->getCustomPropertyName($i));
      echo("Custom Property Value : " . $dp->get_Item($dp->getCustomPropertyName($i)));
      # Zmodyfikuj wartości niestandardowych właściwości
      $dp->set_Item($dp->getCustomPropertyName($i), "New Value " . $i + 1);
    }
    # Zapisz prezentację do pliku
    $pres->save("CustomDemoModified.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Ten przykład modyfikuje niestandardowe właściwości [PPTX](https://docs.fileformat.com/presentation/pptx/) prezentacji. Poniższe ilustracje pokazują niestandardowe właściwości prezentacji przed i po modyfikacji:

|**Niestandardowe właściwości przed modyfikacją**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| ** **|

|**Niestandardowe właściwości po modyfikacji**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| ** **|

## **Zaawansowane właściwości dokumentu**

{{% alert color="info" title="Uwaga" %}}
Nowe metody [readDocumentProperties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/PresentationInfo/#readDocumentProperties), [updateDocumentProperties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) i [writeBindedPresentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/PresentationInfo/#writeBindedPresentation) zostały dodane do klasy [PresentationInfo](https://reference.aspose.com/slides/pl/php-java/aspose.slides/PresentationInfo), logika ustawiania właściwości [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/pl/php-java/aspose.slides/documentproperties/#setLastSavedTime) została zmieniona.
{{% /alert %}} 

Dwie nowe metody [readDocumentProperties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/PresentationInfo/#readDocumentProperties) i [updateDocumentProperties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) zostały dodane do klasy [PresentationInfo](https://reference.aspose.com/slides/pl/php-java/aspose.slides/PresentationInfo). Zapewniają szybki dostęp do właściwości dokumentu i umożliwiają zmianę oraz aktualizację właściwości bez ładowania całej prezentacji.

Typowy scenariusz: załaduj właściwości, zmień niektóre wartości i zaktualizuj dokument, można zaimplementować w następujący sposób:

```php
  # odczytaj informacje o prezentacji
  $info = PresentationFactory->getInstance()->getPresentationInfo("presentation.pptx");
  # pobierz bieżące właściwości
  $props = $info->readDocumentProperties();
  # ustaw nowe wartości pól Autor i Tytuł
  $props->setAuthor("New Author");
  $props->setTitle("New Title");
  # zaktualizuj prezentację nowymi wartościami
  $info->updateDocumentProperties($props);
  $info->writeBindedPresentation("presentation.pptx");
```

Istnieje inny sposób użycia właściwości konkretnej prezentacji jako szablonu do aktualizacji właściwości w innych prezentacjach:

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("template.pptx");
  $template = $info->readDocumentProperties();
  $template->setAuthor("Template Author");
  $template->setTitle("Template Title");
  $template->setCategory("Template Category");
  $template->setKeywords("Keyword1, Keyword2, Keyword3");
  $template->setCompany("Our Company");
  $template->setComments("Created from template");
  $template->setContentType("Template Content");
  $template->setSubject("Template Subject");
  updateByTemplate("doc1.pptx", $template);
  updateByTemplate("doc2.odp", $template);
  updateByTemplate("doc3.ppt", $template);
```

```php

```

Nowy szablon można utworzyć od podstaw, a następnie użyć go do aktualizacji wielu prezentacji:

```php
  $template = new DocumentProperties();
  $template->setAuthor("Template Author");
  $template->setTitle("Template Title");
  $template->setCategory("Template Category");
  $template->setKeywords("Keyword1, Keyword2, Keyword3");
  $template->setCompany("Our Company");
  $template->setComments("Created from template");
  $template->setContentType("Template Content");
  $template->setSubject("Template Subject");
  updateByTemplate("doc1.pptx", $template);
  updateByTemplate("doc2.odp", $template);
  updateByTemplate("doc3.ppt", $template);
```

## **Ustaw język korekty**

Aspose.Slides udostępnia właściwość LanguageId (udostępnianą przez klasę PortionFormat), pozwalającą ustawić język korekty dla dokumentu PowerPoint. Język korekty to język, dla którego sprawdzane są pisownia i gramatyka w PowerPoint.

Ten kod PHP pokazuje, jak ustawić język korekty dla PowerPoint: xxx Dlaczego w klasie Java PortionFormat brakuje właściwości LanguageId?

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();
    $newPortion = new Portion();
    $font = new FontData("SimSun");
    $portionFormat = $newPortion->getPortionFormat();
    $portionFormat->setComplexScriptFont($font);
    $portionFormat->setEastAsianFont($font);
    $portionFormat->setLatinFont($font);
    $portionFormat->setLanguageId("zh-CN");// ustaw identyfikator języka korekty

    $newPortion->setText("1。");
    $paragraph->getPortions()->add($newPortion);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ustaw domyślny język**

Ten kod PHP pokazuje, jak ustawić domyślny język dla całej prezentacji PowerPoint:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setDefaultTextLanguage("en-US");
  $pres = new Presentation($loadOptions);
  try {
    # Dodaje nowy prostokątny kształt z tekstem
    $shp = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    $shp->getTextFrame()->setText("New Text");
    # Sprawdza język pierwszej porcji
    echo($shp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getLanguageId());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Przykład na żywo**

Wypróbuj aplikację online [**Aspose.Slides Metadata**](https://products.aspose.app/slides/pl/metadata), aby zobaczyć, jak pracować z właściwościami dokumentu za pomocą API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/pl/metadata)

## **FAQ**

**Jak mogę usunąć wbudowaną właściwość z prezentacji?**

Wbudowane właściwości są integralną częścią prezentacji i nie mogą być całkowicie usunięte. Można jednak zmienić ich wartości lub ustawić je jako puste, jeśli dana właściwość na to pozwala.

**Co się stanie, jeśli dodam niestandardową właściwość, która już istnieje?**

Jeśli dodasz niestandardową właściwość, która już istnieje, jej istniejąca wartość zostanie nadpisana nową. Nie musisz usuwać ani sprawdzać właściwości wcześniej, ponieważ Aspose.Slides automatycznie aktualizuje wartość właściwości.

**Czy mogę uzyskać dostęp do właściwości prezentacji bez pełnego ładowania prezentacji?**

Tak. Użyj [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentationfactory/) , a następnie [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentationinfo/#readDocumentProperties), aby odczytać przechowywane metadane dokumentu bez tworzenia instancji [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/). Zobacz [Build a Lightweight Presentation Inventory](/slides/pl/php-java/examine-presentation/) po pełny przykład raportowania oraz ograniczenia specyficzne dla formatu.

**Czy mogę odczytać publiczne właściwości zaszyfrowanej prezentacji bez hasła otwierającego?**

Tak. Szyfrowanie właściwości dokumentu musiało zostać wyłączone przed zaszyfrowaniem prezentacji, a prezentacja musi być załadowana w trybie wyłącznie właściwości dokumentu.

**Czy mogę zaktualizować zaszyfrowany plik PPTX w trybie wyłącznie właściwości dokumentu?**

Nie. Publiczne i zaszyfrowane dane właściwości muszą pozostać spójne, dlatego aktualizacja zaszyfrowanego pliku PPTX wymaga pełnego załadowania prezentacji z poprawnym hasłem otwierającym.