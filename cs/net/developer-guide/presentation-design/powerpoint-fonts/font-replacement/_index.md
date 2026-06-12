---
title: Zefektivněte nahrazování písem v prezentacích v .NET
linktitle: Nahrazení písem
type: docs
weight: 60
url: /cs/net/font-replacement/
keywords:
- písmo
- nahradit písmo
- nahrazení písma
- změna písma
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Bezproblémově nahrazujte písma v Aspose.Slides pro .NET a zajistěte konzistentní typografii v prezentacích PowerPoint a OpenDocument."
---
## **Přehled**

Aspose.Slides vám umožňuje nahradit jedno písmo jiným v celé prezentaci. Když je písmo nahrazeno, všechny výskyty původního písma jsou změněny na nové písmo.

Chcete‑li provést nahrazení písma, načtěte prezentaci, určete zdrojové písmo a písmo náhrady, zavolejte metodu pro nahrazení písma a uložte upravenou prezentaci jako soubor PPTX. Tento postup je užitečný, když úmyslně chcete přepnout z jedné rodiny písma na jinou v celé prezentaci.

## **Nahrazení písem**

Pokud změníte názor na používání určitého písma, můžete ho nahradit jiným písmem. Všechny výskyty starého písma budou nahrazeny novým písmem.

Aspose.Slides vám umožňuje nahradit písmo tímto způsobem:

1. Načtěte příslušnou prezentaci. 
2. Načtěte písmo, které bude nahrazeno. 
3. Načtěte nové písmo. 
4. Nahraďte písmo. 
5. Uložte upravenou prezentaci jako soubor PPTX.

```c#
// Načte prezentaci
Presentation presentation = new Presentation("Fonts.pptx");

// Načte zdrojové písmo, které bude nahrazeno
IFontData sourceFont = new FontData("Arial");

// Načte nové písmo
IFontData destFont = new FontData("Times New Roman");

// Nahrazuje písma
presentation.FontsManager.ReplaceFont(sourceFont, destFont);

// Uloží prezentaci
presentation.Save("UpdatedFont_out.pptx", SaveFormat.Pptx);
```

{{% alert title="Note" color="warning" %}} 

Chcete‑li nastavit pravidla, která určují, co se stane v určitých podmínkách (například pokud není písmo přístupné), podívejte se na [**Náhrada písma**](/slides/cs/net/font-substitution/). 

{{% /alert %}}

## **Často kladené dotazy**

**Jaký je rozdíl mezi „náhradou písma“, „substitucí písma“ a „náhradními fonty“?**

Náhrada je úmyslný přechod z jedné rodiny písma na jinou v celém dokumentu. [Substituce](/slides/cs/net/font-substitution/) je pravidlo typu „pokud není písmo dostupné, použij X.“ [Náhradní font](/slides/cs/net/fallback-font/) se aplikuje cíleně na jednotlivé chybějící glyfy, když je základní písmo nainstalováno, ale neobsahuje požadované znaky.

**Platí náhrada i pro hlavní snímky, rozvržení, poznámky a komentáře?**

Ano. Náhrada ovlivňuje všechny objekty prezentace, které používají původní písmo, včetně hlavních snímků a poznámek; komentáře jsou také součástí dokumentu a jsou zohledněny fontovým enginem.

**Změní se písmo uvnitř vložených OLE objektů (například Excel)?**

Ne. [OLE obsah](/slides/cs/net/manage-ole/) je řízen vlastní aplikací. Náhrada v prezentaci neformátuje interní data OLE; může být zobrazena jako obrázek nebo jako externě editovatelný obsah.

**Mohu nahradit písmo jen v části prezentace (podle snímků nebo oblastí)?**

Cílená náhrada je možná, pokud změníte písmo na úrovni požadovaných objektů/rozsahů místo globální náhrady pro celý dokument. Celková logika výběru písma během renderování zůstává stejná.

**Jak mohu předem zjistit, jaká písma prezentace používá?**

Použijte [správce písem]https://reference.aspose.com/slides/cs/net/aspose.slides/fontsmanager/: poskytuje seznam [používaných rodin]https://reference.aspose.com/slides/cs/net/aspose.slides/fontsmanager/getfonts/ a informace o [substitucích/„neznámých“ písmech]https://reference.aspose.com/slides/cs/net/aspose.slides/fontsmanager/getsubstitutions/, což pomáhá naplánovat náhradu.

**Funguje náhrada písma při konverzi do PDF/obrázků?**

Ano. Během exportu Aspose.Slides používá stejnou [sekvenci výběru/substituce písem](/slides/cs/net/font-selection-sequence/), takže předem provedená náhrada bude při konverzi respektována.

**Musím nainstalovat cílové písmo do systému, nebo mohu připojit složku s fonty?**

Instalace není vyžadována: knihovna umožňuje [načítání externích fontů](/slides/cs/net/custom-font/) z uživatelských složek pro použití během [renderování a exportu](/slides/cs/net/convert-powerpoint/).

**Opraví náhrada „tofu“ (čtverečky) místo znaků?**

Pouze pokud cílové písmo skutečně obsahuje požadované glyfy. Pokud ne, [nastavte náhradní font](/slides/cs/net/fallback-font/) k pokrytí chybějících znaků.