---
title: Zjednodušte nahrazování písem v prezentacích pomocí Pythonu přes Java
linktitle: Nahrazování písem
type: docs
weight: 60
url: /cs/python-java/font-replacement/
keywords:
- písmo
- nahrazení písma
- nahrazování písma
- změna písma
- PowerPoint
- OpenDocument
- prezentace
- Python
- Java
- Aspose.Slides
description: "Bezproblémově nahraďte písma v Aspose.Slides pro Python přes Java a zajistěte konzistentní typografii v prezentacích PowerPoint a OpenDocument."
---
## **Přehled**

Aspose.Slides vám umožňuje nahradit jedno písmo jiným v celé prezentaci. Když je písmo nahrazeno, všechny instance původního písma jsou změněny na nové písmo.

Pro provedení nahrazení písma načtěte prezentaci, určete zdrojové písmo a písmo, kterým jej nahradíte, zavolejte metodu pro nahrazení písma a uložte upravenou prezentaci jako soubor PPTX. Tento postup je užitečný, když úmyslně chcete v celé prezentaci přejít z jedné rodiny písem na jinou.

## **Nahrazení písem**

Pokud změníte názor na používání daného písma, můžete toto písmo nahradit jiným. Všechny instance starého písma budou nahrazeny novým písmem.

Aspose.Slides vám umožňuje nahradit písmo tímto způsobem:

1. Načtěte příslušnou prezentaci.
2. Načtěte písmo, které má být nahrazeno.
3. Načtěte nové písmo.
4. Nahraďte písmo.
5. Zapište upravenou prezentaci jako soubor PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, SaveFormat

# Načtěte prezentaci.
presentation = Presentation("Fonts.pptx")
try:
    # Načtěte zdrojové písmo, které bude nahrazeno.
    source_font = FontData("Arial")

    # Načtěte nové písmo.
    destination_font = FontData("Times New Roman")

    # Nahraďte písmo.
    presentation.getFontsManager().replaceFont(source_font, destination_font)

    # Uložte prezentaci.
    presentation.save("UpdatedFont_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Poznámka" color="info" %}} 

Chcete‑li nastavit pravidla určující, co se stane v určitých podmínkách (například pokud není písmo přístupné), podívejte se na [Substituce písma](/slides/cs/python-java/font-substitution/). 

{{% /alert %}}

## **Často kladené otázky**

**Jaký je rozdíl mezi „nahrazením písma“, „substitucí písma“ a „záložními písmy“?**

Nahrazení je úmyslný přechod z jedné rodiny písem na jinou v celém dokumentu. [Substituce](/slides/cs/python-java/font-substitution/) je pravidlo typu „pokud není písmo dostupné, použij X.“ [Záložní písmo](/slides/cs/python-java/fallback-font/) se použije pro jednotlivé chybějící glyfy, když je základní písmo nainstalováno, ale neobsahuje požadované znaky.

**Platí nahrazení i pro hlavní snímky, rozvržení, poznámky a komentáře?**

Ano. Nahrazení ovlivňuje všechny objekty prezentace, které používají původní písmo, včetně hlavních snímků a poznámek; komentáře jsou také součástí dokumentu a jsou zohledněny fontovým enginem.

**Změní se písmo uvnitř vložených OLE objektů (například Excel)?**

Ne. [OLE obsah](/slides/cs/python-java/manage-ole/) je řízen jeho vlastní aplikací. Nahrazení v prezentaci neformátuje interní data OLE; mohou být zobrazena jako obrázek nebo jako externě upravitelný obsah.

**Mohu nahradit písmo jen v části prezentace (podle snímků nebo oblastí)?**

Cílené nahrazení je možné, pokud měníte písmo na úrovni požadovaných objektů/rozsahů místo aplikace globálního nahrazení na celý dokument. Celková logika výběru písma během vykreslování zůstává stejná.

**Jak mohu předem zjistit, jaká písma prezentace používá?**

Použijte [správce písem](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontsmanager/): poskytuje seznam [používaných rodin](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontsmanager/#getFonts) a informace o [substitucích/„neznámých“ písmech](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontsmanager/#getSubstitutions), což pomáhá naplánovat nahrazení.

**Funguje nahrazení písma při konverzi do PDF/obrázků?**

Ano. Během exportu Aspose.Slides používá stejnou [sekvenci výběru/substituce písem](/slides/cs/python-java/font-selection-sequence/), takže nahrazení provedené předem bude během konverze respektováno.

**Musím nainstalovat cílové písmo do systému, nebo mohu připojit složku s písmy?**

Instalace není vyžadována: knihovna umožňuje [načítání externích písem](/slides/cs/python-java/custom-font/) ze složek uživatele pro použití během [vykreslování a exportu](/slides/cs/python-java/convert-powerpoint/).

**Opraví nahrazení „tofu“ (čtverečky) místo znaků?**

Pouze pokud cílové písmo skutečně obsahuje požadované glyfy. Pokud ne, [nastavte záložní písmo](/slides/cs/python-java/fallback-font/) pro pokrytí chybějících znaků.