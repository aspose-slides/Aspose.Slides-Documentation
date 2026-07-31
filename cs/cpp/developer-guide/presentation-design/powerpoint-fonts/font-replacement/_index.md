---
title: Zjednodušte nahrazení písem v prezentacích pomocí C++
linktitle: Nahrazení písma
type: docs
weight: 60
url: /cs/cpp/font-replacement/
keywords:
- písmo
- nahrazení písma
- nahrazení písma
- změna písma
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Bez problémů nahraďte písma v Aspose.Slides pro C++, abyste zajistili konzistentní typografii v prezentacích PowerPoint a OpenDocument."
---
## **Přehled**

Aspose.Slides umožňuje nahradit jedno písmo jiným v celé prezentaci. Když je písmo nahrazeno, všechny výskyty původního písma jsou změněny na nové písmo.

Pro provedení nahrazení písma načtěte prezentaci, určete zdrojové písmo a náhradní písmo, zavolejte metodu pro nahrazení písma a uložte upravenou prezentaci jako soubor PPTX. Tento postup je užitečný, když chcete úmyslně přejít z jedné rodiny písem na jinou v celé prezentaci.

## **Nahradit písma**

Pokud změníte názor na používání písma, můžete toto písmo nahradit jiným písmem. Všechny výskyty starého písma budou nahrazeny novým písmem.

Aspose.Slides umožňuje nahradit písmo následovně:

1. Načtěte příslušnou prezentaci. 
2. Načtěte písmo, které bude nahrazeno.
3. Načtěte nové písmo. 
4. Proveďte nahrazení písma. 
5. Uložte upravenou prezentaci jako soubor PPTX.

Tento C++ kód demonstruje nahrazení písma:

``` cpp
// Načte prezentaci
auto presentation = System::MakeObject<Presentation>(u"Fonts.pptx");

// Načte zdrojové písmo, které bude nahrazeno
auto sourceFont = System::MakeObject<FontData>(u"Arial");

// Načte nové písmo
auto destFont = System::MakeObject<FontData>(u"Times New Roman");

// Nahradí písma
presentation->get_FontsManager()->ReplaceFont(sourceFont, destFont);

// Uloží prezentaci
presentation->Save(u"UpdatedFont_out.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}} 
Chcete-li nastavit pravidla, která určují, co se stane v určitých podmínkách (například pokud není písmo dostupné), podívejte se na [**Náhradu písem**](/slides/cs/cpp/font-substitution/). 
{{% /alert %}}

## **Často kladené dotazy**

**Jaký je rozdíl mezi „náhradou písma“, „substitucí písma“ a „náhradními písmy“?**

Náhrada je úmyslný přechod z jedné rodiny písem na jinou v celém dokumentu. [Substituce](/slides/cs/cpp/font-substitution/) je pravidlo typu „pokud není písmo dostupné, použij X.“ [Náhradní písmo](/slides/cs/cpp/fallback-font/) se používá selektivně pro jednotlivé chybějící glyfy, když je základní písmo nainstalované, ale neobsahuje požadované znaky.

**Platí náhrada na hlavní snímky, rozvržení, poznámky a komentáře?**

Ano. Náhrada ovlivňuje všechny objekty prezentace, které používají původní písmo, včetně hlavních snímků a poznámek; komentáře jsou také součástí dokumentu a jsou zohledněny fontovým enginem.

**Změní se písmo uvnitř vložených OLE objektů (například Excel)?**

Ne. [OLE obsah](/slides/cs/cpp/manage-ole/) je řízen vlastním aplikací. Náhrada v prezentaci nepřetváří interní OLE data; může být zobrazena jako obrázek nebo jako externě editovatelný obsah.

**Mohu nahradit písmo jen v části prezentace (podle snímků nebo oblastí)?**

Cílená náhrada je možná, pokud měníte písmo na úrovni požadovaných objektů/oborů místo globální náhrady v celém dokumentu. Celková logika výběru písma při vykreslování zůstává stejná.

**Jak mohu předem zjistit, jaká písma prezentace používá?**

Použijte [správce písem] prezentace(https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontsmanager/): poskytuje seznam [používaných rodin] (https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontsmanager/getfonts/) a informace o [substitucích/„neznámých“ písmech] (https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontsmanager/getsubstitutions/), což pomáhá naplánovat náhradu.

**Funguje náhrada písma při převodu do PDF/obrázků?**

Ano. Během exportu Aspose.Slides používá stejnou [sekvenci výběru/substituce písma](/slides/cs/cpp/font-selection-sequence/), takže provedená náhrada bude při konverzi respektována.

**Musím nainstalovat cílové písmo do systému, nebo mohu připojit složku s fonty?**

Instalace není vyžadována: knihovna umožňuje [načítání externích fontů](/slides/cs/cpp/custom-font/) z uživatelských složek pro použití během [vykreslování a exportu](/slides/cs/cpp/convert-powerpoint/).

**Opraví náhrada „tofu“ (čtverečky) místo znaků?**

Pouze pokud cílové písmo skutečně obsahuje požadované glyfy. Pokud ne, [nastavte náhradní písmo](/slides/cs/cpp/fallback-font/) pro pokrytí chybějících znaků.