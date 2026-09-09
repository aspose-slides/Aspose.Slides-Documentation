---
title: Extrahovat objekty Flash z prezentací v Pythonu
linktitle: Flash
type: docs
weight: 10
url: /cs/python-java/flash/
keywords:
- extrahovat flash
- flash objekt
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Naučte se, jak v Pythonu s Aspose.Slides extrahovat objekty Flash z prezentací PowerPoint a OpenDocument, včetně kompletních ukázek kódu a nejlepších postupů."
---
## **Přehled**

Tento článek vysvětluje, jak pomocí Aspose.Slides extrahovat objekty Flash z prezentací. Ukazuje, jak najít ovládací prvek Flash podle názvu v kolekci ovládacích prvků snímku a pracovat s vloženými daty objektu SWF.

## **Extrahování objektů Flash z prezentací**

Aspose.Slides pro Python přes Java poskytuje prostředek pro extrahování objektů Flash z prezentace. Můžete přistupovat k ovládacímu prvku Flash podle názvu a extrahovat jej z prezentace, včetně uložených dat objektu SWF.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

# Vytvořte instanci třídy Presentation, která představuje soubor PPTX.
presentation = Presentation()
try:
    controls = presentation.getSlides().get_Item(0).getControls()
    flash_control = None
    for control in controls:
        if control.getName() == "ShockwaveFlash1":
            flash_control = control
finally:
    presentation.dispose()
```

## **Často kladené otázky**

**Jaké formáty prezentací jsou podporovány při extrahování obsahu Flash?**

[Aspose.Slides podporuje](/slides/cs/python-java/supported-file-formats/) hlavní formáty PowerPointu, jako jsou PPT a PPTX, protože dokáže načíst tyto kontejnery a přistupovat k jejich ovládacím prvkům, včetně prvků ActiveX souvisejících s Flashem.

**Mohu převést prezentaci s Flashem na HTML5 a zachovat interaktivitu Flash?**

Ne. Aspose.Slides nespouští obsah SWF ani nepřevádí jeho interaktivitu. Zatímco export do [HTML](/slides/cs/python-java/convert-powerpoint-to-html/)/[HTML5](/slides/cs/python-java/export-to-html5/) je podporován, Flash se v moderních prohlížečích nebude přehrávat kvůli ukončení podpory. Doporučeným postupem je nahradit Flash alternativami, jako je video nebo HTML5 animace, před exportem.

**Z bezpečnostního hlediska, spouští Aspose.Slides soubory SWF během čtení prezentace?**

Ne. Aspose.Slides zachází s Flashem jako s binárními daty vloženými do souboru a během zpracování nespouští obsah SWF.

**Jak mám zacházet s prezentacemi, které obsahují Flash spolu s dalšími vloženými soubory přes OLE?**

Aspose.Slides podporuje [extrahování vložených OLE objektů](/slides/cs/python-java/manage-ole/), takže můžete zpracovat celý související vložený obsah najednou, včetně ovládacích prvků Flash a dalších OLE‑vložených dokumentů.