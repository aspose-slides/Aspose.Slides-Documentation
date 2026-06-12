---
title: Extrahování objektů Flash z prezentací v JavaScriptu
linktitle: Flash
type: docs
weight: 10
url: /cs/nodejs-java/flash/
keywords:
- extrahovat flash
- flash objekt
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Naučte se, jak v JavaScriptu pomocí Aspose.Slides extrahovat objekty Flash z prezentací PowerPoint a OpenDocument, včetně kompletních ukázek kódu a osvědčených postupů."
---
## **Přehled**

Tento článek vysvětluje, jak pomocí Aspose.Slides extrahovat objekty Flash z prezentací. Ukazuje, jak najít ovládací prvek Flash podle názvu ve sbírce ovládacích prvků snímku a pracovat s vloženými daty objektu SWF.

## **Extrahování objektů Flash z prezentace**

Aspose.Slides pro Node.js prostřednictvím Java poskytuje prostředek pro extrahování objektů flash z prezentace. Můžete přistupovat k ovládacímu prvku flash podle názvu a extrahovat jej z prezentace včetně uložení dat objektu SWF.

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var controls = pres.getSlides().get_Item(0).getControls();
    var flashControl = null;
    for (var i = 0; i < controls.size(); i++) {
        var control = controls.get_Item(i);
        console.log(control.getName() === "ShockwaveFlash1");
        if (control.getName() === "ShockwaveFlash1") {
            flashControl = control;
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Často kladené otázky**

**Jaké formáty prezentací jsou podporovány při extrahování obsahu Flash?**

[Aspose.Slides podporuje](/slides/cs/nodejs-java/supported-file-formats/) hlavní formáty PowerPointu, jako jsou PPT a PPTX, protože dokáže načíst tyto kontejnery a přistupovat k jejich ovládacím prvkům, včetně souvisejících s Flash ActiveX prvků.

**Mohu převést prezentaci s Flash na HTML5 a zachovat interaktivitu Flash?**

Ne. Aspose.Slides nespouští obsah SWF ani nepřevádí jeho interaktivitu. Ačkoli je podporován export do [HTML](/slides/cs/nodejs-java/convert-powerpoint-to-html/)/[HTML5](/slides/cs/nodejs-java/export-to-html5/), Flash nebude v moderních prohlížečích přehráván kvůli ukončení podpory. Doporučený postup je nahradit Flash alternativami, jako jsou video nebo animace HTML5, před exportem.

**Z bezpečnostního hlediska spouští Aspose.Slides soubory SWF při načítání prezentace?**

Ne. Aspose.Slides považuje Flash za binární data vložená do souboru a během zpracování nespouští obsah SWF.

**Jak mám zacházet s prezentacemi, které obsahují Flash spolu s dalšími vloženými soubory přes OLE?**

Aspose.Slides podporuje [extrahování vložených OLE objektů](/slides/cs/nodejs-java/manage-ole/), takže můžete zpracovat veškerý související vložený obsah najednou, přičemž se vypořádáte s ovládacími prvky Flash i dalšími dokumenty vloženými přes OLE.