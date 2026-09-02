---
title: "Zarządzanie właściwościami prezentacji w PHP"
linktitle: "Właściwości prezentacji"
type: docs
weight: 70
url: /pl/php-java/presentation-properties/
keywords:
- "Właściwości PowerPoint"
- "Właściwości prezentacji"
- "Właściwości dokumentu"
- "Wbudowane właściwości"
- "Niestandardowe właściwości"
- "Zaawansowane właściwości"
- "Zarządzanie właściwościami"
- "Modyfikowanie właściwości"
- "Metadane dokumentu"
- "Edycja metadanych"
- "Język korekty"
- "Domyślny język"
- "PowerPoint"
- "OpenDocument"
- "prezentacja"
- "PHP"
- "Aspose.Slides"
description: "Opanuj zarządzanie właściwościami prezentacji w Aspose.Slides for PHP via Java oraz usprawnij wyszukiwanie, branding i przepływ pracy w swoich plikach PowerPoint i OpenDocument."
---
## **Introduction**

Aspose.Slides obsługuje dwa typy właściwości dokumentu: **Built-in** i **Custom**. Oba te typy właściwości można łatwo uzyskać i zarządzać przy użyciu API Aspose.Slides.

Aspose.Slides umożliwia pracę z właściwościami dokumentu prezentacji za pośrednictwem klasy [DocumentProperties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/documentproperties/) . Instancja tej klasy jest zwracana przez metodę [Presentation::getDocumentProperties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#getDocumentProperties) . Poniższe przykłady pokazują, jak odczytywać, modyfikować i zarządzać tymi właściwościami.

{{% alert color="info" title="Note" %}}
Należy pamiętać, że pola **Application** i **AppVersion** nie mogą być modyfikowane. Aspose.Slides nadpisuje je przy każdym zapisaniu, więc zapisana prezentacja zawsze raportuje „Aspose.Slides for PHP via Java” oraz wersję biblioteki, która ją wygenerowała. Każda wartość przekazana do `setNameOfApplication` jest odrzucana podczas zapisu prezentacji.
{{% /alert %}} 

## **Zarządzanie właściwościami prezentacji**

Microsoft PowerPoint udostępnia funkcję umożliwiającą dodawanie pewnych właściwości do plików prezentacji. Te właściwości dokumentu pozwalają przechowywać przydatne informacje razem z dokumentami (plikami prezentacji). Istnieją dwa rodzaje właściwości dokumentu, jak poniżej

- Właściwości definiowane przez system (Built-in)
- Właściwości definiowane przez użytkownika (Custom)

Właściwości **Built-in** zawierają ogólne informacje o dokumencie, takie jak tytuł dokumentu, imię autora, statystyki dokumentu itp. Właściwości **Custom** to te, które są definiowane przez użytkowników jako pary **Nazwa/Wartość**, gdzie zarówno nazwa, jak i wartość są określone przez użytkownika. Korzystając z Aspose.Slides for PHP via Java, deweloperzy mogą uzyskiwać dostęp i modyfikować wartości zarówno wbudowanych, jak i własnych właściwości.

## **Właściwości dokumentu w PowerPoint**

Microsoft PowerPoint 2007 umożliwia zarządzanie właściwościami dokumentu plików prezentacji. Wystarczy kliknąć ikonę Office i dalej wybrać **Prepare | Properties | Advanced Properties** w programie Microsoft PowerPoint 2007, jak pokazano poniżej:

|**Wybranie pozycji menu Advanced Properties**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
Po wybraniu pozycji **Advanced Properties** pojawi się okno dialogowe umożliwiające zarządzanie właściwościami dokumentu pliku PowerPoint, jak pokazano poniżej na rysunku:

|**Okno właściwości**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
W powyższym **Oknie właściwości** można zobaczyć wiele zakładek, takich jak **General**, **Summary**, **Statistics**, **Contents** oraz **Custom**. Wszystkie te zakładki umożliwiają konfigurowanie różnych rodzajów informacji związanych z plikami PowerPoint. Zakładka **Custom** służy do zarządzania własnymi właściwościami plików PowerPoint.

Praca z właściwościami dokumentu przy użyciu Aspose.Slides for PHP via Java

Jak opisano wcześniej, Aspose.Slides for PHP via Java obsługuje dwa rodzaje właściwości dokumentu, czyli **Built-in** i **Custom**. Dlatego deweloperzy mogą uzyskać dostęp do obu rodzajów właściwości przy użyciu API Aspose.Slides for PHP via Java. Aspose.Slides for PHP via Java udostępnia klasę [DocumentProperties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/documentproperties) reprezentującą właściwości dokumentu powiązane z plikiem prezentacji poprzez właściwość **Presentation.DocumentProperties**.

Deweloperzy mogą używać właściwości **DocumentProperties** udostępnionej przez obiekt [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation), aby uzyskać dostęp do właściwości dokumentu plików prezentacji, jak opisano poniżej:

## **Dostęp do właściwości Built-in**

Te właściwości udostępniane przez obiekt [DocumentProperties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/documentproperties) obejmują: **Creator** (Autor), **Description**, **Keywords**, **Created** (Data utworzenia), **Modified** (Data modyfikacji), **Printed** (Data ostatniego drukowania), **LastModifiedBy**, **SharedDoc** (Czy współdzielony między różnymi twórcami?), **PresentationFormat**, **Subject** oraz **Title**

```php
  # Utwórz instancję klasy Presentation, która reprezentuje prezentację
  $pres = new Presentation("Presentation.pptx");
  try {
    # Utwórz odniesienie do obiektu IDocumentProperties powiązanego z prezentacją
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

## **Modyfikacja właściwości Built-in**

Modyfikowanie wbudowanych właściwości plików prezentacji jest tak proste, jak ich odczytywanie. Wystarczy przypisać wartość tekstową do dowolnej żądanej właściwości i jej wartość zostanie zmodyfikowana. W poniższym przykładzie przedstawiono, jak można zmodyfikować wbudowane właściwości dokumentu pliku prezentacji przy użyciu Aspose.Slides for PHP via Java.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Utwórz odniesienie do obiektu IDocumentProperties powiązanego z prezentacją
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

|**Wbudowane właściwości dokumentu po modyfikacji**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Dodawanie własnych właściwości dokumentu**

Aspose.Slides for PHP via Java pozwala również deweloperom dodać własne wartości do właściwości dokumentu prezentacji. Poniżej podano przykład, który pokazuje, jak ustawić własne właściwości dla prezentacji.

```php
  $pres = new Presentation();
  try {
    # Pobieranie właściwości dokumentu
    $dProps = $pres->getDocumentProperties();
    # Dodawanie własnych właściwości
    $dProps->set_Item("New Custom", 12);
    $dProps->set_Item("My Name", "Mudassir");
    $dProps->set_Item("Custom", 124);
    # Pobieranie nazwy właściwości pod konkretnym indeksem
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

|**Dodane własne właściwości dokumentu**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Dostęp i modyfikacja własnych właściwości**

Aspose.Slides for PHP via Java umożliwia również deweloperom dostęp do wartości własnych właściwości. Poniżej znajduje się przykład, który pokazuje, jak można uzyskać dostęp i zmodyfikować wszystkie te własne właściwości dla prezentacji.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Utwórz odniesienie do obiektu DocumentProperties powiązanego z prezentacją
    $dp = $pres->getDocumentProperties();
    # Uzyskaj dostęp i zmodyfikuj własne właściwości
    for($i = 0; $i < java_values($dp->getCountOfCustomProperties()) ; $i++) {
      # Wyświetl nazwy i wartości własnych właściwości
      echo("Custom Property Name : " . $dp->getCustomPropertyName($i));
      echo("Custom Property Value : " . $dp->get_Item($dp->getCustomPropertyName($i)));
      # Zmodyfikuj wartości własnych właściwości
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

Ten przykład modyfikuje własne właściwości [PPTX ](https://docs.fileformat.com/presentation/pptx/)prezentacji. Poniższe obrazy pokazują własne właściwości prezentacji przed i po modyfikacji:

|**Własne właściwości przed modyfikacją**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Własne właściwości po modyfikacji**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Zaawansowane właściwości dokumentu**

{{% alert color="info" title="Note" %}}
Do klasy [PresentationInfo](https://reference.aspose.com/slides/pl/php-java/aspose.slides/PresentationInfo) dodano nowe metody [readDocumentProperties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/PresentationInfo/#readDocumentProperties), [updateDocumentProperties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) oraz [writeBindedPresentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/PresentationInfo/#writeBindedPresentation). Logika zestawiającego właściwość [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/pl/php-java/aspose.slides/documentproperties/#setLastSavedTime) została zmieniona.
{{% /alert %}} 

Te dwie nowe metody [readDocumentProperties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/PresentationInfo/#readDocumentProperties) i [updateDocumentProperties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) zostały dodane do klasy [PresentationInfo](https://reference.aspose.com/slides/pl/php-java/aspose.slides/PresentationInfo). Umożliwiają szybki dostęp do właściwości dokumentu i pozwalają zmieniać oraz aktualizować je bez ładowania całej prezentacji.

Typowy scenariusz: wczytać właściwości, zmienić niektóre wartości i zaktualizować dokument, można zaimplementować w następujący sposób:

```php
  # odczytaj informacje o prezentacji
  $info = PresentationFactory->getInstance()->getPresentationInfo("presentation.pptx");
  # uzyskaj bieżące właściwości
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

Nowy szablon można stworzyć od podstaw, a następnie używać go do aktualizacji wielu prezentacji:

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

Aspose.Slides udostępnia właściwość LanguageId (udostępnianą przez klasę PortionFormat), która pozwala ustawić język korekty dla dokumentu PowerPoint. Język korekty to język, dla którego sprawdzane są pisownia i gramatyka w PowerPoint.

Ten kod PHP pokazuje, jak ustawić język korekty dla PowerPoint: xxx Dlaczego właściwość LanguageId brakuje w klasie Java PortionFormat?

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
    # Sprawdza język pierwszej części
    echo($shp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getLanguageId());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Przykład na żywo**

Wypróbuj aplikację online [**Aspose.Slides Metadata**](https://products.aspose.app/slides/pl/metadata), aby zobaczyć, jak pracować z właściwościami dokumentu przy użyciu API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/pl/metadata)

## **FAQ**

**Jak mogę usunąć wbudowaną właściwość z prezentacji?**

Wbudowane właściwości są integralną częścią prezentacji i nie mogą być całkowicie usunięte. Można jednak zmienić ich wartości lub ustawić je jako puste, jeśli dana właściwość na to pozwala.

**Co się stanie, jeśli dodam własną właściwość, która już istnieje?**

Jeśli dodasz własną właściwość, która już istnieje, jej dotychczasowa wartość zostanie nadpisana nową. Nie trzeba usuwać ani sprawdzać tej właściwości wcześniej, ponieważ Aspose.Slides automatycznie aktualizuje jej wartość.

**Czy mogę uzyskać dostęp do właściwości prezentacji bez pełnego wczytywania prezentacji?**

Tak. Użyj [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentationfactory/) a następnie [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentationinfo/#readDocumentProperties), aby odczytać przechowywane metadane dokumentu bez tworzenia instancji [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/). Zobacz [Build a Lightweight Presentation Inventory](/slides/pl/php-java/examine-presentation/) po pełny przykład raportowania i ograniczenia specyficzne dla formatu.