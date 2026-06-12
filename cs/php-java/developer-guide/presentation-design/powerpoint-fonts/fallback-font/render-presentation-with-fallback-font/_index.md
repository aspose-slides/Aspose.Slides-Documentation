---
title: Vykreslení prezentací s náhradními fonty v PHP
linktitle: Vykreslit prezentace
type: docs
weight: 30
url: /cs/php-java/render-presentation-with-fallback-font/
keywords:
- náhradní font
- vykreslit PowerPoint
- vykreslit prezentaci
- vykreslit snímek
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Vykreslete prezentace s náhradními fonty v Aspose.Slides pro PHP pomocí Javy – zachovejte konzistentní text napříč PPT, PPTX a ODP pomocí podrobných ukázek kódu."
---
## **Přehled**

Aspose.Slides vám umožňuje vykreslovat prezentace pomocí pravidel náhradních fontů. Tento článek ukazuje, jak vytvořit kolekci pravidel náhradních fontů, upravit její pravidla odebráním nebo přidáním náhradních fontů a přiřadit kolekci metodě `FontsManager::setFontFallBackRulesCollection`.

Jakmile je kolekce pravidel náhradních fontů přiřazena k `FontsManager` prezentace, pravidla jsou použita během operací, jako je ukládání, vykreslování a převod prezentace. Příklad ukazuje, jak použít nakonfigurovaná pravidla při vykreslování miniatury snímku a jejím uložení jako PNG obrázek.

## **Vykreslení snímku pomocí pravidel náhradních fontů**

1. Vytvoříme [kolekci pravidel náhradních fontů](/slides/cs/php-java/create-fallback-fonts-collection/).
2. [Odebereme](https://reference.aspose.com/slides/cs/php-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) pravidlo náhradního fontu a [addFallBackFonts](https://reference.aspose.com/slides/cs/php-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) k jinému pravidlu.
3. Nastavíme kolekci pravidel pomocí [getFontsManager](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/FontsManager#getFontFallBackRulesCollection--) metody.
4. Pomocí [Presentation.save](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation#save-java.lang.String-int-) metody můžeme prezentaci uložit ve stejném formátu nebo v jiném. Po nastavení kolekce pravidel náhradních fontů do [FontsManager](https://reference.aspose.com/slides/cs/php-java/aspose.slides/FontsManager) jsou tato pravidla použita během všech operací s prezentací: ukládání, vykreslování, převod atd.

```php
  # Vytvořte novou instanci kolekce pravidel
  $rulesList = new FontFallBackRulesCollection();
  # vytvořte několik pravidel
  $rulesList->add(new FontFallBackRule(0x400, 0x4ff, "Times New Roman"));
  foreach($rulesList as $fallBackRule) {
    # Pokus o odebrání náhradního fontu "Tahoma" z načtených pravidel
    $fallBackRule->remove("Tahoma");
    # A aktualizace pravidel pro zadaný rozsah
    if (java_values($fallBackRule->getRangeEndIndex()) >= 0x4000 && java_values($fallBackRule->getRangeStartIndex()) < 0x5000) {
      $fallBackRule->addFallBackFonts("Verdana");
    }
  }
  # Také můžeme odebrat jakákoli existující pravidla ze seznamu
  if (java_values($rulesList->size()) > 0) {
    $rulesList->remove($rulesList->get_Item(0));
  }
  $pres = new Presentation("input.pptx");
  try {
    # Přiřazení připraveného seznamu pravidel k použití
    $pres->getFontsManager()->setFontFallBackRulesCollection($rulesList);
    # Vykreslení miniatury s použitím inicializované kolekce pravidel a uložení do JPEG
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    # Uložte obrázek na disk ve formátu JPEG
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
Přečtěte si více o tom, jak [převést PPT a PPTX do JPG v PHP](/slides/cs/php-java/convert-powerpoint-to-jpg/).
{{% /alert %}}