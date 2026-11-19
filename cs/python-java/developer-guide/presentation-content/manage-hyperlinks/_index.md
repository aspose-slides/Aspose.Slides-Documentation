---
title: Správa hypertextových odkazů v prezentaci v Pythonu přes Java
linktitle: Spravovat hypertextové odkazy
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
- mutabilní hypertextový odkaz
- PowerPoint
- OpenDocument
- prezentace
- Python
- Java
- Aspose.Slides
description: "Přidávejte, formátujte, aktualizujte a odstraňujte hypertextové odkazy v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Python přes Java s využitím ukázek v Pythonu."
---
## **Úvod**

Hyperlink propojuje obsah prezentace s webovou stránkou nebo místem v rámci prezentace. V PowerPointu slouží hyperlinky obvykle k dvěma účelům:

* Otevřít webovou stránku z textu, tvaru nebo multimediálního rámce.
* Přesunout se na jiný snímek, například z obsahu.

Aspose.Slides pro Python via Java vám umožňuje tyto odkazy přidávat, řídit jejich vzhled a zvuk, aktualizovat jejich vlastnosti a odstraňovat je. Níže uvedené příklady ukazují, jak pracovat s hyperlinky na jednotlivých prvcích a jak přistupovat k hyperlinkům na úrovni prezentace, snímku nebo textového rámce.

{{% alert color="info" title="Note" %}}
Můžete také upravovat prezentace pomocí [bezplatného online editoru Aspose PowerPoint](https://products.aspose.app/slides/editor).
{{% /alert %}}

## **Přidat URL hypertextové odkazy**

Můžete přiřadit URL webové stránky k textu, tvaru nebo multimediálnímu rámci. Prvek, ke kterému hyperlink přiřadíte, určuje klikací oblast: část textu propojí vybraný text, zatímco tvar nebo rámec propojí objekt snímku.

Pro prezentace obsahující relativní hyperlinky viz [Manage the Hyperlink Base](/slides/cs/python-java/presentation-properties/#manage-the-hyperlink-base) pro čtení, změnu nebo vymazání dokumentové základny.

### **Přidat URL hypertextové odkazy k textu**

Pro propojení textu s webovou stránkou předáte [Hyperlink](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/) metodě [setHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#setHyperlinkClick) částí textu, jak je ukázáno níže. Pouze tato část textu se stane klikací.

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

### **Přidat URL hypertextové odkazy k tvarům a multimediálním rámcům**

Zavolejte [setHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setHyperlinkClick) na obdélník, aby se celá jeho plocha stala klikací. Použijte [setTooltip](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setTooltip) pro zobrazení nápovědy o cíli, když uživatel přejede myší po obdélníku. Obě metody platí také pro obrázkové, audio a video rámečky.

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

Interní hypertextové odkazy umožňují čtenářům přejít z obsahu na konkrétní snímek. Následující příklad používá [setInternalHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#setInternalHyperlinkClick) k propojení textu „Page 2“ na prvním snímku na druhý snímek.

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

Můžete změnit barvu propojeného textu, přehrát nebo zastavit zvuk při aktivaci odkazu a nastavit tip nástroje, který se zobrazí při najetí.

### **Barva**

Metoda [setColorSource](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setColorSource) třídy [Hyperlink](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/) určuje, zda hyperlink používá barvu hyperlinku prezentace nebo formátování části textu. Pro aplikaci vlastní barvy textu vyberte [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkcolorsource/) a nastavte výplňovou barvu části. Tato funkce byla zavedena v PowerPoint 2019; starší verze toto nastavení nepoužijí.

V tomto příkladu [setColorSource](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setColorSource) způsobí, že první odkaz použije červenou výplň části textu. Druhý odkaz zachová barvu hyperlinku prezentace.

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

Hyperlink může při aktivaci přehrát zvuk nebo zastavit již přehrávaný zvuk. K nastavení tohoto chování použijte následující metody:

- [Hyperlink.setSound](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setSound) určuje audio soubor spojený s hyperlinkem.
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setStopSoundOnClick) řídí, zda aktivace hyperlinku zastaví předchozí zvuk.

#### **Přidat zvuk hypertextového odkazu**

Tlačítko na prvním snímku používá [Hyperlink.setSound](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setSound) k přehrání audia ze souboru `sampleaudio.wav`, když čtenář klikne pro posun. Na druhém snímku samostatné tlačítko používá [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setStopSoundOnClick) k zastavení přehrávání a ponechání čtenáře na tomto snímku.

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

#### **Extrahovat zvuk hypertextového odkazu**

Následující příklad otevře výše vytvořenou prezentaci a načte audio hyperlinku první grafiky do paměti pomocí [getSound](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getSound) a [getBinaryData](https://reference.aspose.com/slides/python-java/aspose.slides/audio/#getBinaryData).

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

### **Tip nástroje a nastavení interakce**

Po přiřazení hyperlinku textu nebo tvaru můžete volat následující metody třídy [Hyperlink](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/):

- [setTooltip](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setTooltip) nastaví text, který se zobrazí jako nápověda pro odkaz.
- [setTargetFrame](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setTargetFrame) určuje cílový rámec v rodičovském HTML framesetu, pokud je to relevantní.
- [setHistory](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setHistory) řídí, zda aktivace odkazu přidá jeho cíl do seznamu zobrazených hyperlinků.
- [setHighlightClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setHighlightClick) řídí, zda se hyperlink zvýrazní po kliknutí.

## **Odstranit hypertextové odkazy z prezentací**

Použijte [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) pro shromáždění kontejnerů hyperlinků, včetně odkazů částí textu, před jejich změnou. Následující příklad odstraňuje oba typy aktivace z prvního snímku. Pro odstranění jen jednoho typu zavolejte pouze [removeHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick) nebo [removeHyperlinkMouseOver](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver); odstranění akce kliknutí neodstraňuje její protějšek při najetí myší.

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

Pro bezpodmínečné odstranění [removeAllHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks) odstraňuje oba typy aktivace ve vybraném rozsahu jedním voláním. Pro selektivní úklid a pokrytí masterů, rozvržení a poznámek viz [Zpráva, sanitizace a ověření hypertextových odkazů](#report-sanitize-and-verify-hyperlinks).

### **Vymazat hypertextové odkazy před nahrazením textu SmartArt**

Když v existujícím uzlu SmartArt nahradíte odstavec, vymazání jeho částí textu může zanechat starý hyperlink v platnosti. Získejte odstavec pomocí [SmartArtNode.getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#getTextFrame). Před vymazáním jeho částí zavolejte [getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getHyperlinkQueries) na textovém rámci uzlu, který zobrazuje odstavec, a pak [removeAllHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks) na vráceném objektu. Tím se odstraní každý hyperlink v tomto rámci, včetně odkazů v dalších odstavcích.

Příklad předpokládá, že třetí grafika na prvním snímku souboru `SmartArtHyperlink.pptx` je SmartArt. Nahrazuje první odstavec čtvrtého uzlu. V této prezentaci první grafika uzlu zobrazuje tento odstavec.

Po přidání obou částí příklad načte jejich efektivní formátování pomocí [getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective). Na tomto formátování `getHyperlinkClick` vrací nový hyperlink pro první část a `None` pro druhou.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Portion, Presentation

presentation = Presentation("SmartArtHyperlink.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    
    smart_art = slide.getShapes().get_Item(2)
    node = smart_art.getAllNodes().get_Item(3)
    paragraph = node.getTextFrame().getParagraphs().get_Item(0)

    node.getShapes().get_Item(0).getTextFrame().getHyperlinkQueries().removeAllHyperlinks()
    paragraph.getPortions().clear()

    link = Portion("New reference")
    link.getPortionFormat().setHyperlinkClick(Hyperlink("https://example.com/new"))
    paragraph.getPortions().add(link)
    text = Portion(" (updated)")
    paragraph.getPortions().add(text)

    print(link.getPortionFormat().getEffective().getHyperlinkClick().getExternalUrl())  # https://example.com/new
    print(text.getPortionFormat().getEffective().getHyperlinkClick())  # Žádná hodnota
finally:
    presentation.dispose()
```

## **Vytvořit kompletní inventář hypertextových odkazů**

Před distribucí prezentace inventarizujte její interaktivní akce i webové odkazy. [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) vrací kontejnery hyperlinků, například objekty [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) a [PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/), nikoli plochý seznam URL řetězců. Prohlédněte si jak [getHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getHyperlinkClick), tak [getHyperlinkMouseOver](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getHyperlinkMouseOver) na každém kontejneru. Jsou nezávislé: stejný kontejner může vystavovat oba akce, takže kompletní zpráva potřebuje až dva řádky na kontejner.

Prohledávání pouze na úrovni tvaru může opomenout odkazy připojené k částem textu. Dotazujte místo toho vhodný rozsah a uchovávejte vrácené kontejnery, abyste je později mohli aktualizovat nebo odstranit jejich akce.

### **Dotazovat oblasti prezentace, snímku a textového rámce**

Třída [HyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/) je dostupná přes [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getHyperlinkQueries), [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getHyperlinkQueries) a [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getHyperlinkQueries). Každý rozsah podporuje stejné dotazy:

- [getHyperlinkClicks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkClicks) vrací kontejnery s akcí kliknutí.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkMouseOvers) vrací kontejnery s akcí najetí myší.
- [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) vrací kontejnery s jednou nebo oběma akcemi.

Tento příklad přiřadí akce kliknutí a najetí myší tvaru a jeho textu a makro akci samostatnému tlačítku. Porovná počet kontejnerů vrácených metodou [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) s počty pro jednotlivé typy aktivace. Dotaz na textový rámec počítá jen odkazy v textu. Akce obklopujícího tvaru se objeví v dotazech snímku i prezentace.

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

Pro tento příklad dotazy na prezentaci i snímek každé uvádějí tři kontejnery kliknutí, dva kontejnery najetí myší a tři kontejnery s libovolnou akcí. Dotaz na textový rámec uvádí po jednom kontejneru v každé kategorii.

### **Klasifikovat akce a cíle**

Použijte [Hyperlink.getActionType](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getActionType) pro interpretaci akce před interpretací jejího cíle. Hodnoty [HyperlinkActionType](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkactiontype/) pokrývají více než webovou navigaci:

| Hodnoty | Význam pro audit |
| --- | --- |
| `Hyperlink` | Externí hypertextový odkaz; zkontrolujte URL a jeho schéma. |
| `JumpSpecificSlide` | Interní navigace na konkrétní snímek. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Vestavěná navigace prezentace, řešená v kontextu prezentace. |
| `JumpEndShow`, `StartCustomSlideShow` | Ukončit aktuální prezentaci nebo spustit vlastní prezentaci. |
| `StartMacro` | Spustit makro. |
| `StartProgram` | Spustit program. |
| `OpenFile`, `OpenPresentation` | Otevřít soubor nebo jinou prezentaci; posuzovat odděleně od webových URL. |
| `StartStopMedia` | Spustit nebo zastavit přehrávání média. |
| `NoAction`, `Unknown` | Žádná navigační akce, nebo nerozpoznaná akce vyžadující revizi. |

Externí cíle čtěte z [getExternalUrl](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getExternalUrl) a specifické interní cíle z [getTargetSlide](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getTargetSlide). Interní akce a vestavěné příkazy nemusí mít externí URL; prázdná URL neznamená, že kontejner nemá žádnou akci. Zachovejte hodnotu vrácenou metodou [getExternalUrlOriginal](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getExternalUrlOriginal), pokud se liší od normalizované URL, a zahrňte tip nástroje vrácený metodou [getTooltip](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getTooltip), pokud je dostupný.

### **Zpráva, sanitizace a ověření hypertextových odkazů**

Tento příklad otevře prezentaci z předchozího příkladu a zapíše jeden JSON záznam na akci. Používá [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) pro shromáždění kontejnerů na běžných snímcích, masterech, rozvrženích a poznámkách, včetně masterů poznámek a ručního výtisku, pokud jsou přítomny. Používá referenční rovnost k jednorázovému spočítání každého kontejneru, aplikuje níže popsanou politiku a znovu načte uloženou prezentaci pro kontrolu jak akcí kliknutí, tak najetí myší.

Zpráva zaznamenává jednorázový index snímku a [getSlideId](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideId), kde je to možné. [getSlide](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getSlide) poskytuje vlastní snímek pro podporované kontejnery. Mastere, rozvržení a poznámky nemají běžný index snímku a jsou identifikovány podle svého rozsahu. Kontejnery tvarů a kontejnerů formátování částí textu jsou označeny samostatně; jiné typy kontejnerů si ponechávají název runtime typu. Každý kontejner získá lokální ID zprávy, aby jeho dvě akce mohly být korelovány. Akční typy jsou uloženy jako celočíselné konstanty definované Java výčtem.

Tato úmyslně restriktivní aplikační politika povoluje jen absolutní HTTPS URL a platné interní cíle snímků. Zamítá makra, programy, souborové akce, jiné akce prezentace, neznámé akce a jiné schémata URL. Tato zamítnutí jsou rozhodnutí politiky, nikoli bezpečnostní verdikt Aspose.Slides. HTTPS samo o sobě nezaručuje důvěru: přidejte seznamy povolených hostitelů a další kontroly pro vaši aplikaci. Obě, originální i normalizované externí URL, jsou kontrolovány. Příklad audituje metadata bez následování odkazů nebo spouštění akcí.

Pro opravu kontejnerů [getHyperlinkManager](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getHyperlinkManager) podporuje [setExternalHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick), [removeHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick) a [removeHyperlinkMouseOver](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver). Zde jsou zakázané externí odkazy na kliknutí nahrazeny pevnou HTTPS vstupní stránkou; ostatní zakázané kliknutí a zakázané akce najetí myší jsou odstraněny nezávisle. Nastavte `replace_external_clicks` na `False` pro odstranění všech porušení politiky. Vyberte stránku nahrazení vlastněnou aplikací před nasazením.

Exportní příznak zprávy používá konzervativní politiku revize PDF: označuje akce najetí myší a vše kromě externího odkazu nebo konkrétního skoku snímku jako potenciálně nepodporované. Je to jen vodítko pro revizi, ne test schopností ani záruka, že neoznačené odkazy přežijí export. Podporované exporty [PDF](/slides/cs/python-java/convert-powerpoint-to-pdf/) a [HTML](/slides/cs/python-java/convert-powerpoint-to-html/) mohou zachovat hyperlinky, v závislosti na akci, nastavení exportu a prohlížeči. Rasterové [images](/slides/cs/python-java/convert-powerpoint-to-png/) a [video](/slides/cs/python-java/convert-powerpoint-to-video/) nemohou zachovat interaktivní hyperlinky; při auditu pro tyto výstupy označte každou akci.

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

S výše vytvořeným vstupem obsahuje zpráva pět řádků akcí. Odkaz na soubor při najetí myší a makro kliknutí jsou odstraněny, zatímco HTTPS odkazy a interní navigace snímků zůstávají. Ověření vypíše nula zakázaných akcí. Vstup obsahující zakázané externí URL kliknutí také vyzkouší větev nahrazení. Kontejner s povoleným kliknutím a zakázaným najetím myší si zachová akci kliknutí.

Tento selektivní úklid se liší od [removeAllHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks), který odstraňuje oba typy aktivace v celém vybraném rozsahu bez ohledu na politiku. Ověření zde kontroluje jen akce hyperlinku; neodstraňuje vložené VBA projekty, OLE objekty ani jiný aktivní obsah a nevaliduje exportovaný PDF nebo HTML soubor.

## **FAQ**

**Jak mohu odkázat na sekci nebo její první snímek?**

Sekce v PowerPointu seskupují snímky, ale interní hyperlink cílí na jednotlivý snímek. Pro vytvoření navigace do sekce odkažte na první snímek v této sekci.

**Mohu připojit hyperlink k elementům master snímku, aby fungoval na všech snímcích?**

Ano. Elementy master snímku a rozvržení podporují hyperlinky. Odkazy na těchto prvcích jsou dostupné během prezentace na snímcích, které používají odpovídající master nebo rozvržení.

**Zůstanou hyperlinky zachovány při exportu do PDF, HTML, obrázků nebo videa?**

Podporované exporty PDF a HTML mohou zachovat hyperlinky; rastrové obrázky a video ne. Viz exportní úvahy v [Zpráva, sanitizace a ověření hypertextových odkazů](#report-sanitize-and-verify-hyperlinks).