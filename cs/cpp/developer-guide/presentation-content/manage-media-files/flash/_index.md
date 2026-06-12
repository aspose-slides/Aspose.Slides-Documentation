---
title: Extrahování objektů Flash z prezentací v C++
linktitle: Flash
type: docs
weight: 10
url: /cs/cpp/flash/
keywords:
- extrahovat flash
- objekt flash
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Naučte se, jak v C++ s Aspose.Slides extrahovat objekty Flash z prezentací PowerPoint a OpenDocument, včetně kompletních ukázek kódu a osvědčených postupů."
---
## **Přehled**

Tento článek vysvětluje, jak pomocí Aspose.Slides extrahovat objekty Flash z prezentací. Ukazuje, jak najít ovládací prvek Flash podle názvu v kolekci ovládacích prvků snímku a pracovat s vloženými daty objektu SWF.

## **Extrahování objektů Flash z prezentací**
Aspose.Slides pro C++ poskytuje funkci pro extrahování objektů flash z prezentace. Můžete získat přístup k ovládacímu prvku flash podle názvu a extrahovat jej z prezentace včetně uložení dat objektu SWF.

``` cpp
auto pres = System::MakeObject<Presentation>(u"withFlash.pptm");
auto controls = pres->get_Slides()->idx_get(0)->get_Controls();
System::SharedPtr<Control> flashControl;
for (const auto& control : controls)
{
    if (control->get_Name() == u"ShockwaveFlash1")
    {
        flashControl = System::ExplicitCast<Control>(control);
    }
}
```

## **Často kladené otázky**

**Jaké formáty prezentací jsou podporovány při extrahování obsahu Flash?**

[Aspose.Slides podporuje](/slides/cs/cpp/supported-file-formats/) hlavní formáty PowerPoint, jako jsou PPT a PPTX, protože může načíst tyto kontejnery a přistupovat k jejich ovládacím prvkům, včetně ActiveX prvků souvisejících s Flash.

**Mohu převést prezentaci s Flash na HTML5 a zachovat interaktivitu Flash?**

Ne. Aspose.Slides nespouští obsah SWF ani nepřevádí jeho interaktivitu. I když je podporován export na [HTML](/slides/cs/cpp/convert-powerpoint-to-html/)/[HTML5](/slides/cs/cpp/export-to-html5/), Flash nebude v moderních prohlížečích přehráván kvůli ukončení podpory. Doporučený postup je nahradit Flash alternativami, jako je video nebo animace HTML5, před exportem.

**Z hlediska bezpečnosti, spouští Aspose.Slides soubory SWF při čtení prezentace?**

Ne. Aspose.Slides zachází s Flashem jako s binárními daty vloženými do souboru a během zpracování nespouští obsah SWF.

**Jak bych měl zacházet s prezentacemi, které obsahují Flash spolu s dalšími vloženými soubory přes OLE?**

Aspose.Slides podporuje [extrahování vložených OLE objektů](/slides/cs/cpp/manage-ole/), takže můžete zpracovat veškerý související vložený obsah najednou, přičemž se budou společně zpracovávat ovládací prvky Flash i další OLE vložené dokumenty.