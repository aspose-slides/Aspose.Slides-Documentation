---
title: Extrahovat objekty Flash z prezentací v PHP
linktitle: Flash
type: docs
weight: 10
url: /cs/php-java/flash/
keywords:
- extrahovat flash
- objekt flash
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Naučte se, jak extrahovat objekty Flash ze snímků PowerPoint a OpenDocument pomocí Aspose.Slides pro PHP přes Java, včetně úplných ukázek kódu a osvědčených postupů."
---
## **Přehled**

Tento článek vysvětluje, jak pomocí Aspose.Slides extrahovat objekty Flash z prezentací. Ukazuje, jak najít ovládací prvek Flash podle názvu v kolekci ovládacích prvků snímku a pracovat s vloženými daty objektu SWF.

## **Extrahovat objekty Flash z prezentací**

Aspose.Slides pro PHP přes Java poskytuje funkci pro extrakci objektů Flash z prezentace. Můžete získat ovládací prvek Flash podle názvu a extrahovat jej z prezentace včetně uložení dat objektu SWF.

```php
  # Vytvořte instanci třídy Presentation, která představuje soubor PPTX
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

## **Často kladené otázky**

**Jaké formáty prezentací jsou podporovány při extrahování obsahu Flash?**

[Aspose.Slides podporuje](/slides/cs/php-java/supported-file-formats/) hlavní formáty PowerPointu, jako jsou PPT a PPTX, protože může načíst tyto kontejnery a přistupovat k jejich ovládacím prvkům, včetně prvků ActiveX souvisejících s Flash.

**Mohu převést prezentaci s Flash na HTML5 a zachovat interaktivitu Flash?**

Ne. Aspose.Slides nespouští obsah SWF ani nepřevádí jeho interaktivitu. Ačkoliv je podporován export do [HTML](/slides/cs/php-java/convert-powerpoint-to-html/)/[HTML5](/slides/cs/php-java/export-to-html5/), Flash se v moderních prohlížečích nepřehrává kvůli ukončení podpory. Doporučený postup je nahradit Flash alternativami, jako jsou video nebo animace HTML5, před exportem.

**Z bezpečnostního hlediska spouští Aspose.Slides soubory SWF při čtení prezentace?**

Ne. Aspose.Slides zachází s Flashem jako s binárními daty vloženými v souboru a během zpracování nespouští obsah SWF.

**Jak mám nakládat s prezentacemi, které obsahují Flash spolu s jinými vloženými soubory přes OLE?**

Aspose.Slides podporuje [extrakci vložených objektů OLE](/slides/cs/php-java/manage-ole/), takže můžete zpracovat celý související vložený obsah najednou, a to jak ovládací prvky Flash, tak další OLE-vložené dokumenty.