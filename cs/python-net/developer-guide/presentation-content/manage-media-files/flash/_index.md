---
title: Extrahovat objekty Flash z prezentací v Pythonu
linktitle: Flash
type: docs
weight: 10
url: /cs/python-net/flash/
keywords:
- extrahovat flash
- flash objekt
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Zjistěte, jak extrahovat objekty Flash z prezentací PowerPoint a OpenDocument v Pythonu pomocí Aspose.Slides, kompletní ukázky kódu a osvědčené postupy."
---
## **Přehled**

Tento článek vysvětluje, jak pomocí Aspose.Slides extrahovat objekty Flash z prezentací. Ukazuje, jak najít ovládací prvek Flash podle názvu v kolekci ovládacích prvků snímku a pracovat s vloženými daty objektu SWF.

## **Extrahovat objekty Flash z prezentace**
Aspose.Slides pro Python prostřednictvím .NET poskytuje funkci pro extrahování objektů flash z prezentace. Můžete přistupovat k ovládacímu prvku flash podle názvu a extrahovat jej z prezentace včetně uložení dat objektu SWF.

```py
import aspose.slides as slides

with slides.Presentation("withFlash.pptm") as pres:
    controls = pres.slides[0].controls
    for control in controls:
        if control.Name == "ShockwaveFlash1":
            flashControl = control
```

## **Často kladené otázky**

**Jaké formáty prezentací jsou podporovány při extrahování obsahu Flash?**

[Aspose.Slides podporuje](/slides/cs/python-net/supported-file-formats/) hlavní formáty PowerPointu, jako jsou PPT a PPTX, protože může načíst tyto kontejnery a přistupovat k jejich ovládacím prvkům, včetně prvků ActiveX souvisejících s Flashem.

**Mohu převést prezentaci s Flashem do HTML5 a zachovat interaktivitu Flash?**

Ne. Aspose.Slides neprovádí obsah SWF ani nepřevádí jeho interaktivitu. Zatímco export do [HTML](/slides/cs/python-net/convert-powerpoint-to-html/)/[HTML5](/slides/cs/python-net/export-to-html5/) je podporován, Flash nebude v moderních prohlížečích přehráván kvůli ukončení podpory. Doporučený postup je nahradit Flash alternativami, jako jsou video nebo animace HTML5, před exportem.

**Z hlediska zabezpečení, spouští Aspose.Slides soubory SWF během čtení prezentace?**

Ne. Aspose.Slides zachází s Flashem jako s binárními daty vloženými v souboru a během zpracování neprovádí obsah SWF.

**Jak bych měl zacházet s prezentacemi, které obsahují Flash spolu s dalšími vloženými soubory přes OLE?**

Aspose.Slides podporuje [extracting embedded OLE objects](/slides/cs/python-net/manage-ole/), takže můžete zpracovat veškerý související vložený obsah najednou, zpracovávat ovládací prvky Flash a další OLE‑vložené dokumenty společně.