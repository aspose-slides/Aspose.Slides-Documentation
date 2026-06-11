---
title: Zarządzanie projektami VBA w prezentacjach przy użyciu PHP
linktitle: Prezentacja za pomocą VBA
type: docs
weight: 250
url: /pl/php-java/presentation-via-vba/
keywords:
- makro
- VBA
- makro VBA
- dodaj makro
- usuń makro
- wyodrębnij makro
- dodaj VBA
- usuń VBA
- wyodrębnij VBA
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Odkryj, jak generować i manipulować prezentacjami PowerPoint i OpenDocument przy użyciu VBA z Aspose.Slides dla PHP przy użyciu Java, aby usprawnić swój przepływ pracy."
---
## **Wprowadzenie**

API Aspose.Slides zawiera klasy umożliwiające pracę z makrami i kodem VBA.

{{% alert title="Note" color="warning" %}} 

Podczas konwertowania prezentacji zawierającej makra do innego formatu pliku (PDF, HTML itp.), Aspose.Slides ignoruje wszystkie makra (makra nie są przenoszone do wynikowego pliku).

Gdy dodajesz makra do prezentacji lub ponownie zapisujesz prezentację zawierającą makra, Aspose.Slides po prostu zapisuje bajty makr.

Aspose.Slides **nigdy** nie uruchamia makr w prezentacji.

{{% /alert %}}

## **Dodawanie makr VBA**

Aspose.Slides udostępnia klasę [VbaProject](https://reference.aspose.com/slides/pl/php-java/aspose.slides/vbaproject/) umożliwiającą tworzenie projektów VBA (i odwołań projektowych) oraz edytowanie istniejących modułów. Możesz używać klasy `VbaProject` do zarządzania VBA osadzonym w prezentacji.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation) .
1. Użyj konstruktora [VbaProject](https://reference.aspose.com/slides/pl/php-java/aspose.slides/vbaproject/#VbaProject) aby dodać nowy projekt VBA.
1. Dodaj moduł do VbaProject.
1. Ustaw kod źródłowy modułu.
1. Dodaj odwołania do <stdole>.
1. Dodaj odwołania do **Microsoft Office**.
1. Powiąż odwołania z projektem VBA.
1. Zapisz prezentację.

Ten kod PHP pokazuje, jak od podstaw dodać makro VBA do prezentacji:

```php
  # Tworzy instancję klasy prezentacji
  $pres = new Presentation();
  try {
    # Tworzy nowy projekt VBA
    $pres->setVbaProject(new VbaProject());
    # Dodaje pusty moduł do projektu VBA
    $module = $pres->getVbaProject()->getModules()->addEmptyModule("Module");
    # Ustawia kod źródłowy modułu
    $module->setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    # Tworzy odwołanie do <stdole>
    $stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    # Tworzy odwołanie do Office
    $officeReference = new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    # Dodaje odwołania do projektu VBA
    $pres->getVbaProject()->getReferences()->add($stdoleReference);
    $pres->getVbaProject()->getReferences()->add($officeReference);
    # Zapisuje prezentację
    $pres->save("test.pptm", SaveFormat::Pptm);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 

Możesz chcieć wypróbować **Aspose** [Macro Remover](https://products.aspose.app/slides/pl/remove-macros), który jest darmową aplikacją internetową służącą do usuwania makr z dokumentów PowerPoint, Excel i Word.

{{% /alert %}} 

## **Usuwanie makr VBA**

Korzystając z właściwości [VbaProject](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#getVbaProject) klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation), możesz usunąć makro VBA.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation) i wczytaj prezentację zawierającą makro.
1. Uzyskaj dostęp do modułu makra i usuń go.
1. Zapisz zmodyfikowaną prezentację.

Ten kod PHP pokazuje, jak usunąć makro VBA:

```php
  # Wczytuje prezentację zawierającą makro
  $pres = new Presentation("VBA.pptm");
  try {
    # Uzyskuje dostęp do modułu Vba i usuwa go
    $pres->getVbaProject()->getModules()->remove($pres->getVbaProject()->getModules()->get_Item(0));
    # Zapisuje prezentację
    $pres->save("test.pptm", SaveFormat::Pptm);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Wyodrębnianie makr VBA**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation) i wczytaj prezentację zawierającą makro.
2. Sprawdź, czy prezentacja zawiera projekt VBA.
3. Iteruj po wszystkich modułach zawartych w projekcie VBA, aby wyświetlić makra.

Ten kod PHP pokazuje, jak wyodrębnić makra VBA z prezentacji zawierającej makra:

```php
  # Wczytuje prezentację zawierającą makro
  $pres = new Presentation("VBA.pptm");
  try {
    # Sprawdza, czy prezentacja zawiera projekt VBA
    if (!java_is_null($pres->getVbaProject())) {
      foreach($pres->getVbaProject()->getModules() as $module) {
        echo($module->getName());
        echo($module->getSourceCode());
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Sprawdzanie, czy projekt VBA jest chroniony hasłem**

Korzystając z metody [VbaProject::isPasswordProtected](https://reference.aspose.com/slides/pl/php-java/aspose.slides/vbaproject/#isPasswordProtected), możesz określić, czy właściwości projektu są chronione hasłem.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) i wczytaj prezentację zawierającą makro.
2. Sprawdź, czy prezentacja zawiera [projekt VBA](https://reference.aspose.com/slides/pl/php-java/aspose.slides/vbaproject/).
3. Sprawdź, czy projekt VBA jest chroniony hasłem, aby wyświetlić jego właściwości.

```php
$presentation = new Presentation("VBA.pptm");
try {
    if ($presentation->getVbaProject() != null) { // Sprawdź, czy prezentacja zawiera projekt VBA.
        if ($presentation->getVbaProject()->isPasswordProtected()) {
            printf("The VBA Project '%s' is protected by password to view project properties.", 
                    $presentation->getVbaProject()->getName());
        }
    }
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Co się dzieje z makrami, gdy zapisuję prezentację jako PPTX?**

Makra zostaną usunięte, ponieważ format PPTX nie obsługuje VBA. Aby zachować makra, wybierz PPTM, PPSM lub POTM.

**Czy Aspose.Slides może uruchamiać makra w prezentacji, na przykład w celu odświeżenia danych?**

Nie. Biblioteka nigdy nie wykonuje kodu VBA; wykonanie jest możliwe jedynie w PowerPoint przy odpowiednich ustawieniach zabezpieczeń.

**Czy obsługa kontrolek ActiveX powiązanych z kodem VBA jest wspierana?**

Tak, możesz uzyskać dostęp do istniejących [kontrolek ActiveX](/slides/pl/php-java/activex/), modyfikować ich właściwości i usuwać je. Jest to przydatne, gdy makra współdziałają z ActiveX.