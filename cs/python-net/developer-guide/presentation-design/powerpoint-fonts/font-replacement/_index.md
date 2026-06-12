---
title: Zefektivněte nahrazování písem v prezentacích pomocí Pythonu
linktitle: Nahrazení písma
type: docs
weight: 60
url: /cs/python-net/font-replacement/
keywords:
- písmo
- nahradit písmo
- nahrazení písma
- změna písma
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Bez problémů nahraďte písma v Aspose.Slides Python pomocí .NET a zajistěte konzistentní typografii v prezentacích PowerPoint i OpenDocument."
---
## **Přehled**

Aspose.Slides umožňuje nahradit jeden font jiným v celé prezentaci. Když je font nahrazen, všechny instance původního fontu jsou změněny na nový font.

Pro provedení nahrazení fontu načtěte prezentaci, určete zdrojový font a náhradní font, zavolejte metodu pro nahrazení fontu a uložte upravenou prezentaci jako soubor PPTX. Tento postup je užitečný, když chcete záměrně přepnout z jedné rodiny fontů na jinou v celé prezentaci.

## **Nahrazení fontů**

Pokud změníte názor na použití fontu, můžete tento font nahradit jiným. Všechny instance starého fontu budou nahrazeny novým fontem.

Aspose.Slides umožňuje nahradit font takto:

1. Načtěte příslušnou prezentaci. 
2. Načtěte font, který bude nahrazen.
3. Načtěte nový font. 
4. Nahraďte font. 
5. Uložte upravenou prezentaci jako soubor PPTX.

Tento Python kód ukazuje nahrazení fontu:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

# Načte prezentaci
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # Načte zdrojové písmo, které bude nahrazeno
    sourceFont = slides.FontData("Arial")

    # Načte nové písmo
    destFont = slides.FontData("Times New Roman")

    # Nahrazuje písma
    presentation.fonts_manager.replace_font(sourceFont, destFont)

    # Uloží prezentaci
    presentation.save("UpdatedFont_out.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Note" color="warning" %}} 

Pro nastavení pravidel, která určují, co se má stát v určitých podmínkách (například pokud není font přístupný), viz [**Font Substitution**](/slides/cs/python-net/font-substitution/). 

{{% /alert %}}

## **Často kladené otázky**

**Jaký je rozdíl mezi „nahrazením fontu“, „nahrazením fontu“ a „záložními fonty“?**

Nahrazení je úmyslný přechod z jedné rodiny na druhou v celém dokumentu. [Substitution](/slides/cs/python-net/font-substitution/) je pravidlo typu „pokud není font dostupný, použij X.“ [Fallback](/slides/cs/python-net/fallback-font/) se aplikuje selektivně pro jednotlivé chybějící glyfy, když je základní font nainstalován, ale neobsahuje požadované znaky.

**Platí nahrazení i pro hlavní snímky, rozvržení, poznámky a komentáře?**

Ano. Nahrazení ovlivňuje všechny objekty prezentace, které používají původní font, včetně hlavních snímků a poznámek; komentáře jsou také součástí dokumentu a jsou zohledněny fontovým enginem.

**Změní se font uvnitř vložených OLE objektů (například Excel)?**

Ne. [OLE content](/slides/cs/python-net/manage-ole/) je řízeno vlastní aplikací. Nahrazení v prezentaci neformátuje interní OLE data; může být zobrazeno jako obrázek nebo jako externě editovatelný obsah.

**Mohu nahradit font pouze v části prezentace (podle snímků nebo oblastí)?**

Cílené nahrazení je možné, pokud změníte font na úrovni požadovaných objektů nebo rozsahů místo aplikace globálního nahrazení na celý dokument. Celková logika výběru fontu během vykreslování zůstává stejná.

**Jak mohu předem zjistit, jaké fonty prezentace používá?**

Použijte [font manager](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fontsmanager/): poskytuje seznam [families in use](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fontsmanager/get_fonts/) a informace o [substitutions/"unknown" fonts](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fontsmanager/get_substitutions/), což pomáhá naplánovat nahrazení.

**Funguje nahrazení fontu při konverzi do PDF/obrázků?**

Ano. Během exportu Aspose.Slides použije stejnou [font selection/substitution sequence](/slides/cs/python-net/font-selection-sequence/), takže nahrazení provedené předem bude během konverze respektováno.

**Musím nainstalovat cílový font do systému, nebo mohu připojit složku s fonty?**

Instalace není povinná: knihovna umožňuje [loading external fonts](/slides/cs/python-net/custom-font/) z uživatelských složek pro použití během [rendering and export](/slides/cs/python-net/convert-powerpoint/).

**Opraví nahrazení „tofu“ (čtverce) místo znaků?**

Pouze pokud cílový font skutečně obsahuje požadované glyfy. Pokud ne, [configure fallback](/slides/cs/python-net/fallback-font/) k pokrytí chybějících znaků.