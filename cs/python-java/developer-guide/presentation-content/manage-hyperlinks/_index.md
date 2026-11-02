---
title: Správa hypertextových odkazů v prezentaci v Pythonu prostřednictvím Java
linktitle: Správa hypertextových odkazů
type: docs
weight: 20
url: /cs/python-java/manage-hyperlinks/
keywords:
- přidat URL
- přidat hypertextový odkaz
- vytvořit hypertextový odkaz
- formátovat hypertextový odkaz
- odstranit hypertextový odkaz
- aktualizovat hypertextový odkaz
- textový hypertextový odkaz
- hypertextový odkaz na snímek
- hypertextový odkaz na tvar
- hypertextový odkaz na obrázek
- hypertextový odkaz na video
- proměnný hypertextový odkaz
- PowerPoint
- OpenDocument
- prezentace
- Python
- Java
- Aspose.Slides
description: "Přidávejte, formátujte, aktualizujte a odstraňujte hypertextové odkazy v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Python prostřednictvím Java s ukázkami v Pythonu."
---
## **Úvod**

Hyperlink spojuje obsah prezentace s webovou stránkou nebo místem v rámci prezentace. V PowerPointu hypertextové odkazy běžně slouží ke dvěma účelům:

* Otevřít webovou stránku z textu, tvaru nebo mediálního rámečku.
* Přesunout se na jiný snímek, například z obsahu.

Aspose.Slides for Python via Java vám umožňuje tyto odkazy přidávat, ovládat jejich vzhled a zvuk, aktualizovat jejich vlastnosti a odstraňovat je. Níže uvedené příklady ukazují, jak pracovat s hypertextovými odkazy na jednotlivých prvcích a jak získat přístup k hypertextovým odkazům na úrovni prezentace, snímku nebo textového rámce.

{{% alert color="info" title="Note" %}}
Můžete také upravovat prezentace pomocí [bezplatného online editoru Aspose PowerPoint](https://products.aspose.app/slides/editor).
{{% /alert %}} 

## **Přidat URL odkazy**

Webovou adresu můžete přiřadit k textu, tvaru nebo mediálnímu rámečku. Prvek, ke kterému hypertextový odkaz přiřadíte, určuje klikací oblast: část textu odkazuje vybraný text, zatímco tvar nebo rámeček odkazuje na objekt snímku.

U prezentací obsahujících relativní hypertextové odkazy viz [Manage the Hyperlink Base](/slides/cs/python-java/presentation-properties/#manage-the-hyperlink-base) pro čtení, změnu nebo vymazání dokumentové základny.

### **Přidat URL odkazy do textu**

Pro propojení textu s webovou stránkou předáte [Hyperlink](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/) metodě [setHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#setHyperlinkClick) části textu, jak je ukázáno níže. Pouze tato část textu se stane klikací.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, False)
    shape.addTextFrame("Aspose: File Format APIs")

    portion_format = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setTooltip("Explore Aspose file format APIs")
    portion_format.setFontHeight(32)

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Přidat URL odkazy do tvarů a mediálních rámečků**

Aby byl tvar nebo rámeček klikací, zavolejte jeho metodu [setHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setHyperlinkClick). Hypertextový odkaz patří samotnému objektu, nikoli části textu uvnitř něj.

Stejný přístup platí pro rámečky s obrázkem, zvukem i videem: přiřaďte hypertextový odkaz rámečku a případně zavolejte [setTooltip](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setTooltip).

Následující příklad činí obdélník klikacím:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50)

    shape.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    shape.getHyperlinkClick().setTooltip("Explore Aspose file format APIs")

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Použít hypertextové odkazy k vytvoření obsahu**

Interní hypertextové odkazy umožňují čtenářům přejít z obsahu na konkrétní snímek. Následující příklad používá [setInternalHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#setInternalHyperlinkClick) k propojení textu „Page 2“ na prvním snímku se druhým snímkem.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Portion, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    second_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())

    table_of_contents = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100)
    table_of_contents.getFillFormat().setFillType(FillType.NoFill)
    table_of_contents.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    table_of_contents.getTextFrame().getParagraphs().clear()

    paragraph = Paragraph()
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph.setText("Title of slide 2 .......... ")

    link_portion = Portion()
    link_portion.setText("Page 2")
    link_portion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(second_slide)

    paragraph.getPortions().add(link_portion)
    table_of_contents.getTextFrame().getParagraphs().add(paragraph)

    presentation.save("link_to_slide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Formátovat hypertextové odkazy**

### **Barva**

Metoda [setColorSource](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setColorSource) třídy [Hyperlink](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/) určuje, zda hypertextový odkaz používá barvu odkazu prezentace nebo formátování části textu. Pro použití vlastní barvy textu vyberte [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkcolorsource/) a nastavte barvu výplně části. Tato funkce byla zavedena v PowerPointu 2019; starší verze toto nastavení nepoužijí.

Následující příklad přidává dva textové hypertextové odkazy na stejný snímek. První používá červenou výplň textu, druhý zachovává výchozí barvu odkazu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Hyperlink, HyperlinkColorSource, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    colored_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, False)
    colored_link_shape.addTextFrame("This hyperlink uses a custom color.")
    portion_format = colored_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat)
    portion_format.getFillFormat().setFillType(FillType.Solid)
    portion_format.getFillFormat().getSolidFillColor().setColor(Color.RED)

    default_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, False)
    default_link_shape.addTextFrame("This hyperlink uses the default color.")
    default_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com/"))

    presentation.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **Zvuk**

Hypertextový odkaz může při aktivaci přehrát zvuk nebo zastavit již přehrávaný zvuk. K nastavení těchto chování použijte následující metody:

- [Hyperlink.setSound](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setSound) určuje zvuk spojený s hypertextovým odkazem.
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setStopSoundOnClick) řídí, zda aktivace odkazu zastaví předchozí zvuk.

#### **Přidat zvuk k hypertextovému odkazu**

Následující příklad načte `sampleaudio.wav` a přiřadí jej tlačítku na prvním snímku. Kliknutím na tlačítko se přehraje zvuk a převede na další snímek. Druhý tvar na tom snímku při kliknutí zastaví předchozí zvuk, aniž by provedl navigaci.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    audio_data = Path("sampleaudio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    hyperlink_sound = presentation.getAudios().addAudio(java_audio_data)
    first_slide = presentation.getSlides().get_Item(0)
    play_button = first_slide.getShapes().addAutoShape(ShapeType.SoundButton, 100, 100, 100, 50)
    play_button.setHyperlinkClick(Hyperlink.getNextSlide())
    if not play_button.getHyperlinkClick().getStopSoundOnClick() and play_button.getHyperlinkClick().getSound() is None:
        play_button.getHyperlinkClick().setSound(hyperlink_sound)
    second_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())
    stop_button = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 100, 50)
    stop_button.setHyperlinkClick(Hyperlink.getNoAction())
    stop_button.getHyperlinkClick().setStopSoundOnClick(True)
    presentation.save("hyperlink-sound.pptx", SaveFormat.Pptx)
except OSError as exception:
    print(f"Unable to read the audio file: {exception}")
finally:
    presentation.dispose()
```

#### **Extrahovat zvuk z hypertextového odkazu**

Následující příklad otevře výše vytvořenou prezentaci a načte zvuk hypertextového odkazu první tvaru do paměti pomocí [getSound](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getSound) a [getBinaryData](https://reference.aspose.com/slides/python-java/aspose.slides/audio/#getBinaryData).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("hyperlink-sound.pptx")
try:
    if presentation.getSlides().size() > 0 and presentation.getSlides().get_Item(0).getShapes().size() > 0:
        hyperlink = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getHyperlinkClick()
        sound = hyperlink.getSound() if hyperlink is not None else None
        if sound is not None:
            audio_data = bytes(sound.getBinaryData())
            print(f"Extracted {len(audio_data)} bytes of hyperlink audio.")
        else:
            print("The first shape has no hyperlink sound.")
    else:
        print("The presentation has no first slide or shape to inspect.")
finally:
    presentation.dispose()
```

### **Nástrojový tip a nastavení interakce**

Po přiřazení hypertextového odkazu k textu nebo tvaru můžete zavolat následující metody třídy [Hyperlink](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/):

- [setTooltip](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setTooltip) nastaví text, který může prohlížeč zobrazit jako nápovědu pro odkaz.
- [setTargetFrame](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setTargetFrame) určuje cílový rámec v rámci rodičovské sady HTML rámců, pokud je to relevantní.
- [setHistory](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setHistory) určuje, zda aktivace odkazu přidá jeho cíl do seznamu zobrazených hypertextových odkazů.
- [setHighlightClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setHighlightClick) určuje, zda je hypertextový odkaz po kliknutí zvýrazněn.

## **Odstranit hypertextové odkazy z prezentací**

Pro sběr kontejnerů hypertextových odkazů, včetně odkazů na části textu, použijte [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) před jejich změnou. Následující příklad odstraňuje oba typy aktivace z prvního snímku. Pro odstranění jen jednoho typu zavolejte jen [removeHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick) nebo [removeHyperlinkMouseOver](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver); odstranění akce kliknutí neodstraní odpovídající akci při přejetí myší.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        containers = list(presentation.getSlides().get_Item(0).getHyperlinkQueries().getAnyHyperlinks())
        for container in containers:
            container.getHyperlinkManager().removeHyperlinkClick()
            container.getHyperlinkManager().removeHyperlinkMouseOver()
        presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx)
    else:
        print("The presentation has no slides to process.")
finally:
    presentation.dispose()
```

Pro nepodmíněné odstranění [removeAllHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks) odstraňuje oba typy aktivace ve vybraném rozsahu jedním voláním. Pro selektivní úklid a pokrytí hlavních snímků, rozvržení a poznámek viz [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Vytvořit kompletní inventář hypertextových odkazů**

Před distribucí prezentace inventarizujte její interaktivní akce i webové odkazy. [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) vrací kontejnery hypertextových odkazů, jako jsou objekty [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) a [PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/), nikoli plochý seznam řetězců URL. Prohlédněte si jak [getHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getHyperlinkClick), tak [getHyperlinkMouseOver](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getHyperlinkMouseOver) na každém kontejneru. Jsou nezávislé: stejný kontejner může vystavovat obě akce, takže úplná zpráva potřebuje až dva řádky na kontejner.

Prohledávání jen hypertextových odkazů na úrovni tvaru může opomenout odkazy připojené k částem textu. dotazujte místo toho příslušný rozsah a uchovávejte vrácené kontejnery, abyste je mohli později aktualizovat nebo odstranit jejich akce.

### **Dotazovat prezentaci, snímek a rozsahy textových rámců**

Třída [HyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/) je dostupná přes [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getHyperlinkQueries), [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getHyperlinkQueries) a [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getHyperlinkQueries). Každý rozsah podporuje stejné dotazy:

- [getHyperlinkClicks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkClicks) vrací kontejnery s akcí kliknutí.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkMouseOvers) vrací kontejnery s akcí při přejetí myší.
- [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) vrací kontejnery s jednou nebo oběma akcemi.

Následující příklad vytvoří `hyperlink-audit-input.pptx` s externím odkazem kliknutí, odkazem na soubor při přejetí myší, interní navigací snímku, odkazem na text při přejetí myší a akcí makra. Neprovádí žádnou z těchto akcí. Stejné tři dotazy fungují v každém rozsahu; počty popisují kontejnery, nikoli celkový počet akcí. Rozsah textového rámce vylučuje odkazy vlastního tvaru.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType


def print_counts(scope, queries):
    click_count = queries.getHyperlinkClicks().size()
    mouse_over_count = queries.getHyperlinkMouseOvers().size()
    any_count = queries.getAnyHyperlinks().size()
    print(f"{scope}: click={click_count}, mouse-over={mouse_over_count}, any={any_count}")


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    destination = presentation.getSlides().addEmptySlide(slide.getLayoutSlide())
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60)
    shape.getTextFrame().setText("Click the text to go to slide 2")
    shape.getHyperlinkManager().setExternalHyperlinkClick("https://example.com/")
    shape.getHyperlinkClick().setTooltip("Public website")
    shape.getHyperlinkManager().setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx")
    portion_format = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.getHyperlinkManager().setInternalHyperlinkClick(destination)
    portion_format.getHyperlinkManager().setExternalHyperlinkMouseOver("https://example.com/help")
    macro_button = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 120, 200, 60)
    macro_button.getHyperlinkManager().setMacroHyperlinkClick("ReviewPresentation")
    print_counts("Presentation", presentation.getHyperlinkQueries())
    print_counts("Slide 1", slide.getHyperlinkQueries())
    print_counts("Text frame", shape.getTextFrame().getHyperlinkQueries())
    presentation.save("hyperlink-audit-input.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Pro tento příklad dotazy na prezentaci i snímek každé hlásí tři kontejnery kliknutí, dva kontejnery při přejetí myší a tři kontejnery s jednou či druhou akcí. Dotaz textového rámce hlásí po jednom kontejneru v každé kategorii.

### **Klasifikovat akce a cíle**

Použijte [Hyperlink.getActionType](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getActionType) k interpretaci akce před interpretací jejího cíle. Hodnoty [HyperlinkActionType](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkactiontype/) pokrývají více než webovou navigaci:

| Hodnoty | Význam pro audit |
| --- | --- |
| `Hyperlink` | Externí hypertextový odkaz; zkontrolujte URL a jeho schéma. |
| `JumpSpecificSlide` | Interní navigace na konkrétní snímek. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Vestavěná navigace prezentací, vyhodnocována v kontextu prezentace. |
| `JumpEndShow`, `StartCustomSlideShow` | Ukončit aktuální prezentaci nebo spustit vlastní prezentaci. |
| `StartMacro` | Spustit makro. |
| `StartProgram` | Spustit program. |
| `OpenFile`, `OpenPresentation` | Otevřít soubor nebo jinou prezentaci; posuzovat odděleně od webových URL. |
| `StartStopMedia` | Spustit nebo zastavit přehrávání média. |
| `NoAction`, `Unknown` | Žádná navigační akce, nebo nerozpoznaná akce vyžadující kontrolu. |

Externí cíle čtěte z [getExternalUrl](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getExternalUrl) a konkrétní interní cíle z [getTargetSlide](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getTargetSlide). Interní akce a vestavěné příkazy nemusí mít externí URL; prázdná URL neznamená, že kontejner nemá žádnou akci. Zachovejte hodnotu vrácenou metodou [getExternalUrlOriginal](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getExternalUrlOriginal), pokud se liší od normalizované URL, a zahrňte nástrojový tip vrácený metodou [getTooltip](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getTooltip), pokud je k dispozici.

### **Nahlásit, sanitizovat a ověřit hypertextové odkazy**

Následující příklad v Pythonu načte existující prezentaci (použijte výše vytvořený soubor), zapíše `hyperlink-audit.json`, aplikuje politiku, uloží `hyperlink-sanitized.pptx` a znovu ji otevře k ověření obou typů aktivace. Před jejich změnou sesbírá kontejnery a používá referenční rovnost, aby se stejný kontejner nezpracoval dvakrát. Dotazy na prezentaci pokrývají běžné snímky; pro inventář na úrovni balíčku také explicitně dotazuje hlavní snímky, rozvržení, poznámky a hlavní snímky poznámek a podkladových listů, jsou‑li přítomny.

Zpráva zaznamenává jednorozměrný index snímku a [getSlideId](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideId), pokud je dostupný. [getSlide](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getSlide) poskytuje vlastní snímek pro podporované kontejnery. Hlavní snímky, rozvržení a poznámky nemají běžný index snímku a jsou identifikovány svým rozsahem. Kontenery tvarů a kontejnery formátování částí textu jsou označeny odděleně; jiné typy kontejnerů si zachovávají svůj runtime typový název. Každý kontejner získá lokální ID zprávy, aby jeho dvě akce bylo možné vzájemně propojit. Zpráva ukládá typy akcí jako celočíselné konstanty definované Java výčtem.

Tato záměrně restriktivní aplikační politika povoluje jen absolutní HTTPS URL a platné interní cíle snímků. Odmítá makra, programy, souborové akce, další akce prezentace, neznámé akce a další schémata URL. Tyto odmítnutí jsou rozhodnutími politiky, nikoli bezpečnostním verdiktem Aspose.Slides. HTTPS samo o sobě nestanoví důvěru: přidejte hostitelské seznamy povolení a další kontroly pro vaši aplikaci. Kontrolují se jak původní, tak normalizované externí URL. Příklad audituje metadata bez následujících odkazů nebo spouštění akcí.

Pro opravu podporuje [getHyperlinkManager](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getHyperlinkManager) kontejnery metody [setExternalHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick), [removeHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick) a [removeHyperlinkMouseOver](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver). Zde jsou zakázané externí odkazy kliknutí nahrazeny fixní HTTPS vstupní stránkou; ostatní zakázané kliknutí a zakázané akce při přejetí myší jsou odstraněny nezávisle. Nastavte `replace_external_clicks` na `False` pro odstranění všech porušení politiky. Vyberte stránku náhradního obsahu vlastněnou aplikací před nasazením.

Exportní příznak zprávy používá konzervativní politiku revize PDF: označuje akce při přejetí myší a vše kromě externího odkazu nebo specifického skoku na snímek jako potenciálně nepodporované. Je to jen vodítko pro revizi, ne test schopností ani záruka, že neoznačené odkazy přežijí export. Podporované exporty do [PDF](/slides/cs/python-java/convert-powerpoint-to-pdf/) a [HTML](/slides/cs/python-java/convert-powerpoint-to-html/) mohou zachovat hypertextové odkazy, v závislosti na akci, nastavení exportu a prohlížeči. Rasterové [images](/slides/cs/python-java/convert-powerpoint-to-png/) a [video](/slides/cs/python-java/convert-powerpoint-to-video/) nemohou zachovat interaktivní hypertextové odkazy; při auditu pro tyto výstupy označte každou akci.

```python
import json
from pathlib import Path
from urllib.parse import urlsplit

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HyperlinkActionType, PortionFormat, Presentation, SaveFormat, Shape

IdentityHashMap = jpype.JClass("java.util.IdentityHashMap")


def slide_index(presentation, slide):
    for index, candidate in enumerate(presentation.getSlides(), start=1):
        if candidate == slide:
            return index
    return None


def is_https(value):
    if not value:
        return False
    value = str(value)
    if any(character.isspace() or ord(character) < 32 for character in value):
        return False
    try:
        uri = urlsplit(value)
        return uri.scheme.lower() == "https" and bool(uri.hostname)
    except ValueError:
        return False


def policy_violation(link):
    if link is None:
        return None
    if link.getActionType() == HyperlinkActionType.JumpSpecificSlide:
        return "Missing target slide" if link.getTargetSlide() is None else None
    if link.getActionType() != HyperlinkActionType.Hyperlink:
        return "Action is not allowed"
    if not is_https(link.getExternalUrl()):
        return "Normalized URL is not absolute HTTPS"
    original = link.getExternalUrlOriginal()
    if original and not is_https(original):
        return "Original URL is not absolute HTTPS"
    return None


def collect_containers(presentation):
    found = list(presentation.getHyperlinkQueries().getAnyHyperlinks())
    scopes = list(presentation.getMasters()) + list(presentation.getLayoutSlides())
    for slide in presentation.getSlides():
        scopes.append(slide.getNotesSlideManager().getNotesSlide())
    scopes.append(presentation.getMasterNotesSlideManager().getMasterNotesSlide())
    scopes.append(presentation.getMasterHandoutSlideManager().getMasterHandoutSlide())
    for scope in scopes:
        if scope is not None:
            found.extend(scope.getHyperlinkQueries().getAnyHyperlinks())
    seen = IdentityHashMap()
    unique = []
    for container in found:
        if not seen.containsKey(container):
            seen.put(container, True)
            unique.append(container)
    return unique


def text_or_none(value):
    return str(value) if value is not None else None


def add_row(rows, presentation, link, activation, container, container_id):
    if link is None:
        return
    owner_slide = container.getSlide() if hasattr(container, "getSlide") else None
    target_slide = link.getTargetSlide()
    violation = policy_violation(link)
    if isinstance(container, Shape):
        owner_type = "Shape"
    elif isinstance(container, PortionFormat):
        owner_type = "Text portion"
    else:
        owner_type = str(container.getClass().getSimpleName())
    ordinary_action = link.getActionType() in (HyperlinkActionType.Hyperlink, HyperlinkActionType.JumpSpecificSlide)
    original = link.getExternalUrlOriginal()
    rows.append({
        "ContainerId": container_id,
        "SlideIndex": slide_index(presentation, owner_slide),
        "SlideId": int(owner_slide.getSlideId()) if owner_slide is not None else None,
        "Scope": str(owner_slide.getClass().getSimpleName()) if owner_slide is not None else None,
        "OwnerType": owner_type,
        "Activation": activation,
        "ActionType": int(link.getActionType()),
        "ExternalUrl": text_or_none(link.getExternalUrl()),
        "TargetSlideIndex": slide_index(presentation, target_slide),
        "TargetSlideId": int(target_slide.getSlideId()) if target_slide is not None else None,
        "Tooltip": text_or_none(link.getTooltip()),
        "OriginalExternalUrl": text_or_none(original) if original != link.getExternalUrl() else None,
        "PotentiallyUnsafe": violation is not None,
        "PolicyViolation": violation,
        "TargetExport": "PDF",
        "PotentiallyUnsupportedByExport": activation == "mouse-over" or not ordinary_action,
    })


replace_external_clicks = True
replacement_url = "https://example.com/blocked-link"
presentation = Presentation("hyperlink-audit-input.pptx")
try:
    containers = collect_containers(presentation)
    rows = []
    for container_id, container in enumerate(containers, start=1):
        add_row(rows, presentation, container.getHyperlinkClick(), "click", container, container_id)
        add_row(rows, presentation, container.getHyperlinkMouseOver(), "mouse-over", container, container_id)
    report = json.dumps(rows, indent=2)
    Path("hyperlink-audit.json").write_text(report, encoding="utf-8")

    for container in containers:
        click = container.getHyperlinkClick()
        if policy_violation(click) is not None:
            if replace_external_clicks and click.getActionType() == HyperlinkActionType.Hyperlink:
                container.getHyperlinkManager().setExternalHyperlinkClick(replacement_url)
            else:
                container.getHyperlinkManager().removeHyperlinkClick()
        if policy_violation(container.getHyperlinkMouseOver()) is not None:
            container.getHyperlinkManager().removeHyperlinkMouseOver()
    presentation.save("hyperlink-sanitized.pptx", SaveFormat.Pptx)

    reopened = Presentation("hyperlink-sanitized.pptx")
    try:
        remaining_containers = collect_containers(reopened)
        violations = 0
        for container in remaining_containers:
            if policy_violation(container.getHyperlinkClick()) is not None:
                violations += 1
            if policy_violation(container.getHyperlinkMouseOver()) is not None:
                violations += 1
        print(f"Audit rows: {len(rows)}; prohibited actions after reopening: {violations}")
        if violations != 0:
            print("Verification failed: do not distribute the saved presentation.")
    finally:
        reopened.dispose()
except OSError as exception:
    print(f"Unable to write the audit report: {exception}")
finally:
    presentation.dispose()
```

S výše vytvořeným vstupem obsahuje zpráva pět řádků akcí. Odkaz na soubor při přejetí myší a kliknutí na makro jsou odstraněny, zatímco HTTPS odkazy a interní navigace snímků zůstávají. Ověření vypíše nula zakázaných akcí. Vstup obsahující zakázané externí URL pro kliknutí také otestuje větev nahrazení. Kontejner s povoleným kliknutím a zakázaným přejetím myší si zachová akci kliknutí.

Tento selektivní úklid se liší od [removeAllHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks), který odstraňuje oba typy aktivace v celém vybraném rozsahu bez ohledu na politiku. Ověření zde kontroluje jen akce hypertextových odkazů; neodstraňuje vložené VBA projekty, OLE objekty ani jiný aktivní obsah a nekontroluje exportovaný PDF ani HTML soubor.

## **Často kladené otázky**

**Jak mohu odkazovat na sekci nebo její první snímek?**

Sekce v PowerPointu seskupují snímky, ale interní hypertextový odkaz cíluje na konkrétní snímek. Pro vytvoření navigace na sekci odkažte na první snímek v dané sekci.

**Mohu připojit hypertextový odkaz k prvkům hlavního (master) snímku, aby fungoval na všech snímcích?**

Ano. Prvky hlavního snímku a rozvržení podporují hypertextové odkazy. Odkazy na těchto prvcích jsou k dispozici během prezentace na snímcích, které používají odpovídající hlavní nebo rozvržení.

**Zůstanou hypertextové odkazy zachovány při exportu do PDF, HTML, obrázků nebo videa?**

Podporované exporty do PDF a HTML mohou zachovat hypertextové odkazy; rasterové obrázky a video ne. Viz úvahy o exportu v [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).