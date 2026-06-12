---
title: "Extrahování objektů Flash z prezentací v .NET"
linktitle: "Flash"
type: docs
weight: 10
url: /cs/net/flash/
keywords:
- "extrahovat flash"
- "objekt flash"
- "PowerPoint"
- "OpenDocument"
- "prezentace"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Zjistěte, jak extrahovat objekty Flash z prezentací PowerPoint a OpenDocument v .NET pomocí Aspose.Slides, včetně kompletních ukázek kódu v C# a nejlepších postupů."
---
## **Přehled**

Tento článek vysvětluje, jak pomocí Aspose.Slides extrahovat objekty Flash z prezentací. Ukazuje, jak najít ovládací prvek Flash podle názvu ve sbírce ovládacích prvků snímku a pracovat s vloženými daty objektu SWF.

## **Extrahování objektů Flash z prezentací**
Aspose.Slides pro .NET poskytuje prostředek pro extrahování objektů Flash z prezentace. Můžete přistupovat k ovládacímu prvku Flash podle názvu a extrahovat jej z prezentace včetně uložení dat objektu SWF.

```c#
using (Presentation pres = new Presentation("withFlash.pptm"))
{
    IControlCollection controls = pres.Slides[0].Controls;
    Control flashControl = null;
    foreach (IControl control in controls)
    {
        if (control.Name == "ShockwaveFlash1")
        {
            flashControl = (Control)control;
        }
    }
}
```

## **Často kladené otázky**

**Jaké formáty prezentací jsou podporovány při extrahování obsahu Flash?**

[Aspose.Slides podporuje](/slides/cs/net/supported-file-formats/) hlavní formáty PowerPoint, jako jsou PPT a PPTX, protože může načíst tyto kontejnery a získat přístup k jejich ovládacím prvkům, včetně prvků ActiveX souvisejících s Flashem.

**Mohu převést prezentaci s Flashem do HTML5 a zachovat interaktivitu Flash?**

Ne. Aspose.Slides nespouští obsah SWF ani nepřevádí jeho interaktivitu. Ačkoli je podporován export do [HTML](/slides/cs/net/convert-powerpoint-to-html/)/[HTML5](/slides/cs/net/export-to-html5/), Flash se v moderních prohlížečích nepřehraje kvůli ukončení podpory. Doporučeným postupem je nahradit Flash alternativami, jako jsou video nebo animace HTML5, před exportem.

**Z hlediska zabezpečení, spouští Aspose.Slides soubory SWF při čtení prezentace?**

Ne. Aspose.Slides zachází s Flashem jako s binárními daty vloženými do souboru a během zpracování nespouští obsah SWF.

**Jak mám zacházet s prezentacemi, které obsahují Flash spolu s dalšími vloženými soubory přes OLE?**

Aspose.Slides podporuje [extrahování vložených objektů OLE](/slides/cs/net/manage-ole/), takže můžete zpracovat veškerý související vložený obsah najednou, přičemž se zabýváte ovládacími prvky Flash a dalšími dokumenty vloženými přes OLE.