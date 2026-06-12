---
title: Zefektivněte nahrazování písem v prezentacích pomocí С++
linktitle: Nahrazení písma
type: docs
weight: 60
url: /cs/cpp/font-replacement/
keywords:
- písmo
- nahrazení písma
- nahrazení písem
- změna písma
- PowerPoint
- OpenDocument
- prezentace
- С++
- Aspose.Slides
description: "Bez problémů nahraďte písma v Aspose.Slides pro С++ a zajistěte konzistentní typografii v prezentacích PowerPoint a OpenDocument."
---
## **Přehled**

Aspose.Slides vám umožňuje nahradit jedno písmo jiným v celé prezentaci. Když je písmo nahrazeno, všechny výskyty původního písma jsou změněny na nové písmo.

Pro provedení nahrazení písma načtěte prezentaci, určete zdrojové písmo a písmo náhrady, zavolejte metodu pro nahrazení písma a uložte upravenou prezentaci jako soubor PPTX. Tento postup je užitečný, když úmyslně chcete přejít z jedné rodiny písma na jinou v celé prezentaci.

## **Nahrazení písem**

Pokud změníte názor na používání písma, můžete toto písmo nahradit jiným. Všechny výskyty starého písma budou nahrazeny novým písmem.

Aspose.Slides vám umožňuje nahradit písmo tímto způsobem:

1. Načtěte příslušnou prezentaci.  
2. Načtěte písmo, které bude nahrazeno.  
3. Načtěte nové písmo.  
4. Nahraďte písmo.  
5. Uložte upravenou prezentaci jako soubor PPTX.

Tento C++ kód demonstruje nahrazení písma:

``` cpp
// Načte prezentaci
auto presentation = System::MakeObject<Presentation>(u"Fonts.pptx");

// Načte zdrojové písmo, které bude nahrazeno
auto sourceFont = System::MakeObject<FontData>(u"Arial");

// Načte nové písmo
auto destFont = System::MakeObject<FontData>(u"Times New Roman");

// Nahrazuje písma
presentation->get_FontsManager()->ReplaceFont(sourceFont, destFont);

// Uloží prezentaci
presentation->Save(u"UpdatedFont_out.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}} 
Chcete‑li nastavit pravidla určující, co se stane v určitých podmínkách (například pokud není písmo dostupné), viz [**Font Substitution**](/slides/cs/cpp/font-substitution/). 
{{% /alert %}}

## **Často kladené otázky**

**Jaký je rozdíl mezi „nahrazením písma“, „substitucí písma“ a „záložními písmy“?**

Nahrazení je úmyslný přechod z jedné rodiny na jinou v celém dokumentu. [Substitution](/slides/cs/cpp/font-substitution/) je pravidlo typu „pokud písmo není k dispozici, použij X.“ [Fallback](/slides/cs/cpp/fallback-font/) se uplatňuje cíleně pro jednotlivé chybějící glyfy, když je základní písmo nainstalované, ale neobsahuje požadované znaky.

**Platí nahrazení i pro hlavní snímky, rozvržení, poznámky a komentáře?**

Ano. Nahrazení ovlivňuje všechny objekty prezentace, které používají původní písmo, včetně hlavních snímků a poznámek; komentáře jsou také součástí dokumentu a jsou zohledněny fontovým enginem.

**Změní se písmo i uvnitř vložených OLE objektů (například Excel)?**

Ne. [OLE content](/slides/cs/cpp/manage-ole/) řídí vlastní aplikace. Nahrazení v prezentaci nemění interní data OLE; může být zobrazeno jako obrázek nebo jako externě editovatelný obsah.

**Mohu nahradit písmo jen v části prezentace (podle snímků nebo oblastí)?**

Cílené nahrazení je možné, pokud změníte písmo na úrovni požadovaných objektů/rozsahů místo aplikace globálního nahrazení na celý dokument. Celková logika výběru písma během renderování zůstává stejná.

**Jak mohu předem zjistit, která písma prezentace vůbec používá?**

Použijte [font manager] prezentace (https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontsmanager/): poskytuje seznam [používaných rodin] (https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontsmanager/getfonts/) a informace o [substitucích/„neznámých“ písmech] (https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontsmanager/getsubstitutions/), což pomáhá naplánovat nahrazení.

**Funguje nahrazení písma při konverzi do PDF/obrázků?**

Ano. Během exportu Aspose.Slides používá stejnou [font selection/substitution sequence](/slides/cs/cpp/font-selection-sequence/), takže nahrazení provedené předem bude při konverzi respektováno.

**Musím nainstalovat cílové písmo do systému, nebo mohu připojit složku s písmy?**

Instalace není vyžadována: knihovna umožňuje [loading external fonts](/slides/cs/cpp/custom-font/) ze složek uživatele pro použití během [renderování a exportu](/slides/cs/cpp/convert-powerpoint/).

**Opraví nahrazení „tofu“ (čtverečky) místo znaků?**

Pouze pokud cílové písmo skutečně obsahuje požadované glyfy. Pokud ne, [configure fallback](/slides/cs/cpp/fallback-font/) k pokrytí chybějících znaků.