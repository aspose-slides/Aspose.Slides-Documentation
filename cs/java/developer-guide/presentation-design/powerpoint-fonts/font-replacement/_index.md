---
title: Zjednodušte nahrazení písem v prezentacích pomocí Java
linktitle: Nahrazení písma
type: docs
weight: 60
url: /cs/java/font-replacement/
keywords:
- písmo
- nahrazení písma
- nahrazení písem
- změna písma
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Bezproblémově nahraďte písma v Aspose.Slides pro Java a zajistěte konzistentní typografii v prezentacích PowerPoint a OpenDocument."
---
## **Přehled**

Aspose.Slides umožňuje nahradit jedno písmo jiným v celé prezentaci. Když je písmo nahrazeno, všechny výskyty původního písma jsou změněny na nové písmo.

Pro provedení nahrazení písma načtěte prezentaci, určete výchozí písmo a nahrazující písmo, zavolejte metodu pro nahrazení písma a uložte upravenou prezentaci jako soubor PPTX. Tento přístup je užitečný, když záměrně chcete v celé prezentaci přepnout z jedné rodiny písma na jinou.

## **Nahrazení písem**

Pokud změníte názor na používání písma, můžete toto písmo nahradit jiným písmem. Všechny výskyty starého písma budou nahrazeny novým písmem.

Aspose.Slides umožňuje nahradit písmo tímto způsobem:

1. Načtěte příslušnou prezentaci.  
2. Načtěte písmo, které bude nahrazeno.  
3. Načtěte nové písmo.  
4. Nahraďte písmo.  
5. Uložte upravenou prezentaci jako soubor PPTX.

Tento kód v jazyce Java demonstruje nahrazení písma:

```java
// Načte prezentaci
Presentation pres = new Presentation("Fonts.pptx");
try {
    // Načte zdrojové písmo, které bude nahrazeno
    IFontData sourceFont = new FontData("Arial");
    
    // Načte nové písmo
    IFontData destFont = new FontData("Times New Roman");
    
    // Nahradí písma
    pres.getFontsManager().replaceFont(sourceFont, destFont);
    
    // Uloží prezentaci
    pres.save("UpdatedFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
Chcete‑li nastavit pravidla, která určují, co se stane v určitých podmínkách (například pokud není písmo přístupné), viz [**Substituce písma**](/slides/cs/java/font-substitution/). 
{{% /alert %}}

## **Často kladené otázky**

**Jaký je rozdíl mezi „nahrazením písma“, „substitucí písma“ a „záložními písmy“?**

Nahrazení je záměrný přechod z jedné rodiny písma na jinou v celém dokumentu. [Substituce](/slides/cs/java/font-substitution/) je pravidlo typu „pokud není písmo k dispozici, použij X.“ [Záložní písmo](/slides/cs/java/fallback-font/) se aplikuje cíleně na jednotlivé chybějící glyfy, když je základní písmo nainstalováno, ale neobsahuje požadované znaky.

**Platí nahrazení i pro hlavní snímky, rozvržení, poznámky a komentáře?**

Ano. Nahrazení ovlivňuje všechny objekty prezentace, které používají původní písmo, včetně hlavních snímků a poznámek; komentáře jsou také součástí dokumentu a jsou zohledněny fontovým enginem.

**Změní se písmo ve vložených objektech OLE (například Excel)?**

Ne. [Obsah OLE](/slides/cs/java/manage-ole/) je řízen vlastní aplikací. Nahrazení v prezentaci nepřeformátuje interní data OLE; mohou být zobrazena jako obrázek nebo jako externě editovatelný obsah.

**Mohu nahradit písmo jen v části prezentace (podle snímků nebo oblastí)?**

Cílené nahrazení je možné, pokud změníte písmo na úrovni požadovaných objektů/rozsahů místo globálního nahrazení v celém dokumentu. Celková logika výběru písma během vykreslování zůstává stejná.

**Jak mohu dopředu zjistit, jaká písma prezentace používá?**

Použijte [správce písem](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fontsmanager/): poskytuje seznam [používaných rodin](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fontsmanager/#getFonts--) a informace o [substitucích/„neznámých“ písmenech](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fontsmanager/#getSubstitutions--), což pomáhá naplánovat nahrazení.

**Funguje nahrazení písma při převodu do PDF/obrázků?**

Ano. Během exportu Aspose.Slides používá stejnou [sekvenci výběru/substituce písem](/slides/cs/java/font-selection-sequence/), takže nahrazení provedené předem bude při převodu respektováno.

**Je nutné nainstalovat cílové písmo do systému, nebo mohu připojit složku s písmy?**

Instalace není povinná: knihovna umožňuje [načítání externích písem](/slides/cs/java/custom-font/) ze složek uživatele pro použití během [vykreslování a exportu](/slides/cs/java/convert-powerpoint/).

**Opravení „tofu“ (čtverců) místo znaků nahrazením písma?**

Pouze pokud cílové písmo skutečně obsahuje požadované glyfy. Pokud ne, [nastavte záložní písmo](/slides/cs/java/fallback-font/) pro pokrytí chybějících znaků.