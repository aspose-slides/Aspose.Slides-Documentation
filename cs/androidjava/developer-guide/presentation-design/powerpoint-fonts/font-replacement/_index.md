---
title: Zjednodušte nahrazování písma v prezentacích na Androidu
linktitle: Nahrazení písma
type: docs
weight: 60
url: /cs/androidjava/font-replacement/
keywords:
- písmo
- nahrazení písma
- nahrazení písma
- změna písma
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Bezproblémově nahraďte písma v Aspose.Slides pro Android pomocí Javy a zajistěte konzistentní typografii v prezentacích PowerPoint a OpenDocument."
---
## **Přehled**

Aspose.Slides vám umožňuje nahradit jeden font jiným v celé prezentaci. Když je font nahrazen, všechny instance původního fontu jsou změněny na nový font.

Pro provedení nahrazení fontu načtěte prezentaci, definujte zdrojový font a náhradní font, zavolejte metodu pro nahrazení fontu a uložte upravenou prezentaci jako soubor PPTX. Tento postup je užitečný, když záměrně chcete přepnout z jedné rodiny fontů na jinou v celé prezentaci.

## **Nahrazení fontů**

Pokud změníte názor ohledně používání fontu, můžete tento font nahradit jiným fontem. Všechny instance starého fontu budou nahrazeny novým fontem.

Aspose.Slides vám umožňuje nahradit font tímto způsobem:

1. Načtěte příslušnou prezentaci.
2. Načtěte font, který bude nahrazen.
3. Načtěte nový font.
4. Nahraďte font.
5. Uložte upravenou prezentaci jako soubor PPTX.

```java
// Načte prezentaci
Presentation pres = new Presentation("Fonts.pptx");
try {
    // Načte zdrojový font, který bude nahrazen
    IFontData sourceFont = new FontData("Arial");
    
    // Načte nový font
    IFontData destFont = new FontData("Times New Roman");
    
    // Nahrazuje fonty
    pres.getFontsManager().replaceFont(sourceFont, destFont);
    
    // Uloží prezentaci
    pres.save("UpdatedFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
Chcete‑li nastavit pravidla, která určují, co se stane v určitých podmínkách (například pokud není font dostupný), podívejte se na [**Substituce písem**](/slides/cs/androidjava/font-substitution/).
{{% /alert %}}

## **Často kladené otázky**

**Jaký je rozdíl mezi „nahrazením fontu“, „substitucí fontu“ a „záložními fonty“?**

Nahrazení je úmyslný přechod z jedné rodiny fontů na jinou v celém dokumentu. [Substituce](/slides/cs/androidjava/font-substitution/) je pravidlo typu „pokud není font k dispozici, použijte X.“ [Záložní font](/slides/cs/androidjava/fallback-font/) se používá selektivně pro jednotlivé chybějící glify, když je základní font nainstalován, ale neobsahuje požadované znaky.

**Aplikuje se nahrazení na master snímky, rozvržení, poznámky a komentáře?**

Ano. Nahrazení ovlivňuje všechny objekty prezentace, které používají původní font, včetně master snímků a poznámek; komentáře jsou také součástí dokumentu a jsou zohledněny fontovým enginem.

**Změní se font uvnitř vložených OLE objektů (například Excelu)?**

Ne. [OLE obsah](/slides/cs/androidjava/manage-ole/) je řízen vlastní aplikací. Nahrazení v prezentaci nepřetváří interní data OLE; mohou být zobrazena jako obrázek nebo jako externě editovatelný obsah.

**Mohu nahradit font jen v části prezentace (podle snímků nebo oblastí)?**

Cílené nahrazení je možné, pokud změníte font na úrovni požadovaných objektů/rozsahů místo globálního nahrazení celého dokumentu. Celková logika výběru fontu během vykreslování zůstává stejná.

**Jak mohu předem zjistit, jaké fonty prezentace používá?**

Použijte [správce fontů](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fontsmanager/): poskytuje seznam [používaných rodin](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fontsmanager/#getFonts--) a informace o [substitucích/„neznámých“ fontech](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fontsmanager/#getSubstitutions--), což pomáhá naplánovat nahrazení.

**Funguje nahrazení fontů při převodu do PDF/obrázků?**

Ano. Během exportu Aspose.Slides použije stejnou [sekvenci výběru/substituce fontů](/slides/cs/androidjava/font-selection-sequence/), takže nahrazení provedené předem bude při převodu respektováno.

**Musím nainstalovat cílový font do systému, nebo mohu připojit složku s fonty?**

Instalace není vyžadována: knihovna umožňuje [načítání externích fontů](/slides/cs/androidjava/custom-font/) ze složek uživatele pro použití během [vykreslování a exportu](/slides/cs/androidjava/convert-powerpoint/).

**Opraví nahrazení „tofu“ (čtverečky) místo znaků?**

Pouze pokud cílový font skutečně obsahuje požadované glify. Pokud ne, [nastavte záložní font](/slides/cs/androidjava/fallback-font/) pro pokrytí chybějících znaků.