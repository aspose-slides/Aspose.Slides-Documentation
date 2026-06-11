---
title: Wyodrębnianie obiektów Flash z prezentacji w PHP
linktitle: Flash
type: docs
weight: 10
url: /pl/php-java/flash/
keywords:
- wyodrębnić flash
- obiekt flash
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Dowiedz się, jak wyodrębniać obiekty Flash z slajdów PowerPoint i OpenDocument przy użyciu Aspose.Slides for PHP via Java, z pełnymi przykładami kodu i najlepszymi praktykami."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak wyodrębnić obiekty Flash z prezentacji przy użyciu Aspose.Slides. Pokazuje, jak znaleźć kontrolkę Flash po nazwie w kolekcji kontrolek slajdu oraz pracować z osadzonymi danymi obiektu SWF.

## **Wyodrębnianie obiektów Flash z prezentacji**

Aspose.Slides for PHP via Java udostępnia funkcję wyodrębniania obiektów flash z prezentacji. Można uzyskać dostęp do kontrolki flash po nazwie i wyodrębnić ją z prezentacji, w tym przechowywać dane obiektu SWF.

```php
  # Utwórz instancję klasy Presentation reprezentującej plik PPTX
  $pres = new Presentation();
  try {
    $controls = $pres->getSlides()->get_Item(0)->getControls();
    $flashControl = null;
    foreach($controls as $control) {
      if (java_values($control->getName()) == "ShockwaveFlash1") {
        $flashControl = $control;
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Jakie formaty prezentacji są obsługiwane przy wyodrębnianiu treści Flash?**

[Aspose.Slides supports](/slides/pl/php-java/supported-file-formats/) główne formaty PowerPoint, takie jak PPT i PPTX, ponieważ może ładować te kontenery i uzyskiwać dostęp do ich kontrolek, w tym elementów ActiveX związanych z Flash.

**Czy mogę skonwertować prezentację z Flash do HTML5 i zachować interaktywność Flash?**

Nie. Aspose.Slides nie wykonuje treści SWF ani nie konwertuje jej interaktywności. Chociaż eksport do [HTML](/slides/pl/php-java/convert-powerpoint-to-html/)/[HTML5](/slides/pl/php-java/export-to-html5/) jest wspierany, Flash nie będzie odtwarzany w nowoczesnych przeglądarkach z powodu zakończenia wsparcia. Zalecanym rozwiązaniem jest zastąpienie Flash alternatywami, takimi jak wideo lub animacje HTML5, przed eksportem.

**Z perspektywy bezpieczeństwa, czy Aspose.Slides wykonuje pliki SWF podczas odczytu prezentacji?**

Nie. Aspose.Slides traktuje Flash jako binarne dane osadzone w pliku i nie wykonuje treści SWF podczas przetwarzania.

**Jak powinienem postępować z prezentacjami zawierającymi Flash wraz z innymi osadzonymi plikami poprzez OLE?**

Aspose.Slides obsługuje [wyodrębnianie osadzonych obiektów OLE](/slides/pl/php-java/manage-ole/), więc możesz przetworzyć całą powiązaną zawartość osadzoną w jednym przebiegu, obsługując kontrolki Flash oraz inne dokumenty osadzone przez OLE razem.