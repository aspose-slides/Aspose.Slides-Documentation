---
title: Extrahování flashových objektů z prezentací na Android
linktitle: Flash
type: docs
weight: 10
url: /cs/androidjava/flash/
keywords:
- extrahovat flash
- flash objekt
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Naučte se, jak pomocí Aspose.Slides pro Android v Javě extrahovat flashové objekty z PowerPoint a OpenDocument snímků, včetně kompletních ukázek kódu a osvědčených postupů."
---
## **Přehled**

Tento článek vysvětluje, jak pomocí Aspose.Slides extrahovat flashové objekty z prezentací. Ukazuje, jak najít flashové ovládací prvky podle názvu ve sbírce ovládacích prvků snímku a pracovat s vloženými daty objektu SWF.

## **Extrahování flashových objektů z prezentací**

Aspose.Slides pro Android pomocí Javy poskytuje možnost extrahovat flashové objekty z prezentace. Můžete získat přístup k flashovému ovládacímu prvku podle názvu a extrahovat jej z prezentace včetně uložení dat objektu SWF.

```java
// Vytvořte instanci třídy Presentation, která představuje PPTX
Presentation pres = new Presentation();
try {
    IControlCollection controls = pres.getSlides().get_Item(0).getControls();
    Control flashControl = null;
    for (IControl control : controls)
    {
        if (control.getName() == "ShockwaveFlash1")
        {
            flashControl = (Control)control;
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Často kladené otázky**

**Jaké formáty prezentací jsou podporovány při extrahování flashového obsahu?**

[Aspose.Slides podporuje](/slides/cs/androidjava/supported-file-formats/) hlavní formáty PowerPointu, jako jsou PPT a PPTX, protože dokáže načíst tyto kontejnery a přistupovat k jejich ovládacím prvkům, včetně aktivních prvků ActiveX souvisejících s Flashem.

**Mohu převést prezentaci s Flashem do HTML5 a zachovat interaktivitu Flash?**

Ne. Aspose.Slides nespouští obsah SWF ani nekonvertuje jeho interaktivitu. Ačkoli je podporován export do [HTML](/slides/cs/androidjava/convert-powerpoint-to-html/)/[HTML5](/slides/cs/androidjava/export-to-html5/), Flash nebude v moderních prohlížečích přehráván kvůli ukončení podpory. Doporučeným řešením je nahradit Flash alternativami, jako jsou video nebo animace HTML5, před exportem.

**Z bezpečnostního hlediska, spouští Aspose.Slides soubory SWF při čtení prezentace?**

Ne. Aspose.Slides zachází s Flashem jako s binárními daty vloženými v souboru a během zpracování nespouští obsah SWF.

**Jak mám zacházet s prezentacemi, které obsahují Flash spolu s dalšími vloženými soubory přes OLE?**

Aspose.Slides podporuje [extrahování vložených objektů OLE](/slides/cs/androidjava/manage-ole/), takže můžete zpracovat celý související vložený obsah najednou, přičemž se postaráte o flashové ovládací prvky i další dokumenty vložené přes OLE.