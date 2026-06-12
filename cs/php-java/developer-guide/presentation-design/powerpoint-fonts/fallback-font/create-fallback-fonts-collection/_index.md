---
title: Konfigurace kolekcí náhradních fontů v PHP
linktitle: Kolekce náhradního fontu
type: docs
weight: 20
url: /cs/php-java/create-fallback-fonts-collection/
keywords:
- náhradní font
- náhradní pravidlo
- kolekce fontů
- konfigurace fontu
- nastavení fontu
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Nastavte kolekci náhradních fontů v Aspose.Slides pro PHP přes Java, aby byl text v prezentacích PowerPoint a OpenDocument konzistentní a ostrý."
---
## **Přehled**

Aspose.Slides umožňuje nakonfigurovat kolekci pravidel náhradních fontů pro prezentaci. Každé pravidlo náhradního fontu je reprezentováno třídou `FontFallBackRule` a může být přidáno do `FontFallBackRulesCollection`.

Po vytvoření kolekce ji můžete přiřadit pomocí metody `setFontFallBackRulesCollection` třídy `FontsManager` prezentace. `FontsManager` řídí fonty napříč prezentací a každá instance `Presentation` má svůj vlastní `FontsManager`.

Jakmile je `FontsManager` inicializován s kolekcí náhradních fontů, jsou specifikované náhradní fonty použity během vykreslování prezentace.

## **Použití pravidel náhradního fontu**

Instance třídy [FontFallBackRule](https://reference.aspose.com/slides/cs/php-java/aspose.slides/FontFallBackRule) mohou být uspořádány do [FontFallBackRulesCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/FontFallBackRulesCollection). Je možné přidávat nebo odebírat pravidla z kolekce.

Pak může být tato kolekce přiřazena metodě [FontFallBackRulesCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/FontFallBackRulesCollection) třídy [FontsManager](https://reference.aspose.com/slides/cs/php-java/aspose.slides/FontsManager). FontsManager řídí fonty napříč prezentací.

Každý [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation) má metodu [getFontsManager](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation#getFontsManager) se svojí vlastní instancí třídy [FontsManager](https://reference.aspose.com/slides/cs/php-java/aspose.slides/FontsManager).

Zde je příklad, jak vytvořit kolekci pravidel náhradních fontů a přiřadit ji do [FontsManager](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation#getFontsManager) konkrétní prezentace:  

```php
  $pres = new Presentation();
  try {
    $userRulesList = new FontFallBackRulesCollection();
    $userRulesList->add(new FontFallBackRule(0xb80, 0xbff, "Vijaya"));
    $userRulesList->add(new FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic"));
    $pres->getFontsManager()->setFontFallBackRulesCollection($userRulesList);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Po inicializaci FontsManageru s kolekcí náhradních fontů jsou náhradní fonty použity během vykreslování prezentace.

{{% alert color="primary" %}} 
Přečtěte si více o tom, jak [Vykreslení prezentace s náhradním fontem](/slides/cs/php-java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **Často kladené otázky**

**Budou mé pravidla náhradních fontů vložena do souboru PPTX a viditelné v PowerPointu po uložení?**

Ne. Pravidla náhradních fontů jsou nastavení vykreslování za běhu; nejsou serializována do PPTX a nebudou se zobrazovat v uživatelském rozhraní PowerPointu.

**Platí náhrada i na text uvnitř SmartArt, WordArt, grafů a tabulek?**

Ano. Pro jakýkoli text v těchto objektech se používá stejný mechanismus substituce glifu.

**Distribuuje Aspose nějaké fonty s knihovnou?**

Ne. Fonty přidáváte a používáte na své straně a na vlastní odpovědnost.

**Lze použít nahrazení/substituci chybějících fontů a náhradu chybějících glifů současně?**

Ano. Jedná se o nezávislé fáze stejného pipeline řešení fontů: nejprve engine zjistí dostupnost fontů ([náhrada](/slides/cs/php-java/font-replacement/)/[substituce](/slides/cs/php-java/font-substitution/)), poté náhrada vyplní mezery pro chybějící glyfy v dostupných fontech.