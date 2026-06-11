---
title: Renderowanie prezentacji z czcionkami zapasowymi w PHP
linktitle: Renderowanie prezentacji
type: docs
weight: 30
url: /pl/php-java/render-presentation-with-fallback-font/
keywords:
- czcionka zapasowa
- renderowanie PowerPoint
- renderowanie prezentacji
- renderowanie slajdu
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Renderowanie prezentacji z czcionkami zapasowymi w Aspose.Slides dla PHP poprzez Java – zachowaj spójność tekstu w PPT, PPTX i ODP dzięki krok po kroku przykładom kodu."
---
## **Przegląd**

Aspose.Slides umożliwia renderowanie prezentacji przy użyciu reguł zapasowych czcionek. Ten artykuł pokazuje, jak utworzyć kolekcję reguł zapasowych czcionek, modyfikować jej reguły poprzez usuwanie lub dodawanie czcionek zapasowych oraz przypisać kolekcję do metody `FontsManager::setFontFallBackRulesCollection`.

Po przypisaniu kolekcji reguł zapasowych czcionek do `FontsManager` prezentacji, reguły są stosowane podczas operacji takich jak zapisywanie, renderowanie i konwertowanie prezentacji. Przykład demonstruje, jak używać skonfigurowanych reguł przy renderowaniu miniatury slajdu i zapisywaniu jej jako obrazu PNG.

## **Renderowanie slajdu przy użyciu reguł zapasowych czcionek**

Poniższy przykład zawiera następujące kroki:

1. Tworzymy [kolekcję reguł zapasowych czcionek](/slides/pl/php-java/create-fallback-fonts-collection/).
2. [Remove](https://reference.aspose.com/slides/pl/php-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) regułę zapasowej czcionki i [addFallBackFonts](https://reference.aspose.com/slides/pl/php-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) do innej reguły.
3. Ustaw kolekcję reguł w metodzie [getFontsManager](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/FontsManager#getFontFallBackRulesCollection--) .
4. Za pomocą metody [Presentation.save](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation#save-java.lang.String-int-) możemy zapisać prezentację w tym samym formacie lub w innym. Po ustawieniu kolekcji reguł zapasowych czcionek w [FontsManager](https://reference.aspose.com/slides/pl/php-java/aspose.slides/FontsManager), reguły te są stosowane podczas wszelkich operacji na prezentacji: zapisywanie, renderowanie, konwertowanie itp.

```php
  # Utwórz nową instancję kolekcji reguł
  $rulesList = new FontFallBackRulesCollection();
  # utwórz kilka reguł
  $rulesList->add(new FontFallBackRule(0x400, 0x4ff, "Times New Roman"));
  foreach($rulesList as $fallBackRule) {
    # Próba usunięcia czcionki zapasowej "Tahoma" z załadowanych reguł
    $fallBackRule->remove("Tahoma");
    # oraz aktualizacja reguł dla określonego zakresu
    if (java_values($fallBackRule->getRangeEndIndex()) >= 0x4000 && java_values($fallBackRule->getRangeStartIndex()) < 0x5000) {
      $fallBackRule->addFallBackFonts("Verdana");
    }
  }
  # Możemy również usunąć istniejące reguły z listy
  if (java_values($rulesList->size()) > 0) {
    $rulesList->remove($rulesList->get_Item(0));
  }
  $pres = new Presentation("input.pptx");
  try {
    # Przypisywanie przygotowanej listy reguł do użycia
    $pres->getFontsManager()->setFontFallBackRulesCollection($rulesList);
    # Renderowanie miniatury przy użyciu zainicjowanej kolekcji reguł i zapis do formatu JPEG
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    # Zapisz obraz na dysku w formacie JPEG
    try {
      $slideImage->save("Slide_0.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 
Dowiedz się więcej, jak [przekonwertować PPT i PPTX na JPG w PHP](/slides/pl/php-java/convert-powerpoint-to-jpg/).
{{% /alert %}}