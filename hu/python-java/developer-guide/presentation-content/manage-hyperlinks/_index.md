---
title: Prezentációs hiperhivatkozások kezelése Pythonon keresztül Java-val
linktitle: Hiperhivatkozások kezelése
type: docs
weight: 20
url: /hu/python-java/manage-hyperlinks/
keywords:
- URL hozzáadása
- hiperhivatkozás hozzáadása
- hiperhivatkozás létrehozása
- hiperhivatkozás formázása
- hiperhivatkozás eltávolítása
- hiperhivatkozás frissítése
- szöveges hiperhivatkozás
- dia hiperhivatkozás
- alakzat hiperhivatkozás
- kép hiperhivatkozás
- videó hiperhivatkozás
- módosítható hiperhivatkozás
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Hiperhivatkozások hozzáadása, formázása, frissítése és eltávolítása PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Python via Java segítségével, Python példákkal."
---
## **Bevezetés**

A hiperhivatkozás összekapcsolja a bemutató tartalmát egy weboldallal vagy a bemutatón belüli helyszínnel. A PowerPointban a hiperhivatkozások általában két célra szolgálnak:

* Weboldal megnyitása szövegből, alakzatból vagy médiakeretből.
* Másik dia megnyitása, például a tartalomjegyzékből.

Az Aspose.Slides for Python via Java lehetővé teszi ezen hivatkozások hozzáadását, megjelenésük és hangjuk vezérlését, tulajdonságaik frissítését és eltávolítását. Az alábbi példák bemutatják, hogyan dolgozhatunk hiperhivatkozásokkal egyedi elemeknél, valamint hogyan érhetjük el a hiperhivatkozásokat a bemutató, dia vagy szövegkeret szintjén.

{{% alert color="info" title="Megjegyzés" %}}

A bemutatókat a [ingyenes online Aspose PowerPoint szerkesztővel](https://products.aspose.app/slides/hu/editor) is szerkesztheti.

{{% /alert %}} 

## **URL hiperhivatkozások hozzáadása**

Webcím (URL) hozzárendelhető szöveghez, alakzathoz vagy médiakerethez. Az elem, amelyhez a hiperhivatkozást rendeli, meghatározza a kattintható területet: egy szövegrészlet a kijelölt szöveget, míg egy alakzat vagy keret a dia objektumát teszi kattinthatóvá.

### **URL hiperhivatkozások hozzáadása szöveghez**

A szöveg weboldalra való hivatkozásához egy [Hyperlink](https://reference.aspose.com/slides/hu/python-java/aspose.slides/hyperlink/) objektumot adjon át a szövegrészlet [setHyperlinkClick](https://reference.aspose.com/slides/hu/python-java/aspose.slides/portionformat/#setHyperlinkClick) metódusának, ahogy az alább látható. Csak ez a szövegrészlet lesz kattintható.

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

### **URL hiperhivatkozások hozzáadása alakzatokhoz és médiakeretekhez**

Az alakzat vagy keret kattinthatóvá tételéhez hívja meg annak [setHyperlinkClick](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#setHyperlinkClick) metódusát. A hiperhivatkozás az objektumhoz tartozik, nem egy benne lévő szövegrészlethez.

Ugyanez a megközelítés érvényes kép-, hang- és videókeretekre is: rendelje hozzá a hiperhivatkozást a kerethez, és szükség esetén hívja meg a [setTooltip](https://reference.aspose.com/slides/hu/python-java/aspose.slides/hyperlink/#setTooltip) metódust.

Az alábbi példa egy téglalapot tesz kattinthatóvá:

```python
import jpide
import asposeslides

if not jpide.isJVMStarted():
    jpide.startJVM()

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

## **Hiperhivatkozások használata tartalomjegyzék létrehozásához**

A belső hiperhivatkozások lehetővé teszik az olvasók számára, hogy a tartalomjegyzékből egy adott diára ugorjanak. Az alábbi példa a [setInternalHyperlinkClick](https://reference.aspose.com/slides/hu/python-java/aspose.slides/hyperlinkmanager/#setInternalHyperlinkClick) metódust használja, hogy a „2. oldal” szöveget az első diárról a második diára mutassa.

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

## **Hiperhivatkozások formázása**

### **Szín**

A [Hyperlink](https://reference.aspose.com/slides/hu/python-java/aspose.slides/hyperlink/) [setColorSource](https://reference.aspose.com/slides/hu/python-java/aspose.slides/hyperlink/#setColorSource) metódusa határozza meg, hogy a hiperhivatkozás a bemutató hiperhivatkozás‑színét vagy a szövegrészlet formázását használja-e. Egy egyéni szövegszín alkalmazásához válassza a [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/hyperlinkcolorsource/) értéket, és állítsa be a részlet kitöltőszínét. Ez a funkció a PowerPoint 2019‑ben került bevezetésre; a régebbi verziók nem alkalmazzák ezt a beállítást.

Az alábbi példa két szöveges hiperhivatkozást ad ugyanarra a diára. Az első piros szövegszínnel jelenik meg, míg a másik a alapértelmezett hiperhivatkozás‑színt használja.

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
### **Hang**

A hiperhivatkozás aktiváláskor lejátszhat egy hangot, vagy leállíthat egy már futó hangot. Az alábbi metódusokkal konfigurálhatja ezeket a viselkedéseket:

- [Hyperlink.setSound](https://reference.aspose.com/slides/hu/python-java/aspose.slides/hyperlink/#setSound) a hiperhivatkozáshoz társított audiót adja meg.
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/hu/python-java/aspose.slides/hyperlink/#setStopSoundOnClick) szabályozza, hogy a hiperhivatkozás aktiválása leállítsa‑e az előző hangot.

#### **Hiperhivatkozás hangjának hozzáadása**

Az alábbi példa betölti a `sampleaudio.wav` fájlt, és egy gombhoz rendeli az első dián. A gomb megnyomásakor a hang lejátszásra kerül, és a következő diára navigál. Egy másik alakzat ugyanazon a dián a hang leállítását végzi kattintáskor, anélkül hogy navigációt indítana.

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

#### **Hiperhivatkozás hangjának kinyerése**

Az alábbi példa megnyitja a fent létrehozott bemutatót, és a [getSound](https://reference.aspose.com/slides/hu/python-java/aspose.slides/hyperlink/#getSound) és [getBinaryData](https://reference.aspose.com/slides/hu/python-java/aspose.slides/audio/#getBinaryData) metódusok segítségével a memóriába olvassa az első alakzat hiperhivatkozás‑audióját.

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

### **Buborék és interakciós beállítások**

A szöveghez vagy alakzathoz hiperhivatkozás hozzárendelése után a következő [Hyperlink](https://reference.aspose.com/slides/hu/python-java/aspose.slides/hyperlink/) metódusok hívhatók meg:

- [setTooltip](https://reference.aspose.com/slides/hu/python-java/aspose.slides/hyperlink/#setTooltip) a linkhez megjelenő tipp szövegének beállításához.
- [setTargetFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/hyperlink/#setTargetFrame) a célkeret meghatározásához egy szülő HTML‑keretcsoportban, ha releváns.
- [setHistory](https://reference.aspose.com/slides/hu/python-java/aspose.slides/hyperlink/#setHistory) szabályozza, hogy a link aktiválása felvegye‑e a célját a megtekintett hiperhivatkozások listájába.
- [setHighlightClick](https://reference.aspose.com/slides/hu/python-java/aspose.slides/hyperlink/#setHighlightClick) azt határozza meg, hogy a hiperhivatkozás kattintáskor ki legyen‑e emelve.

## **Hiperhivatkozások eltávolítása a bemutatókból**

A [getAnyHyperlinks](https://reference.aspose.com/slides/hu/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) metódus segítségével gyűjthetőek a hiperhivatkozás‑konténerek (beleértve a szövegrészlet‑hivatkozásokat) a módosítás előtt. Az alábbi példa eltávolítja mindkét aktiválási típust az első diáról. Ha csak az egyiket szeretné eltávolítani, hívja meg kizárólag a [removeHyperlinkClick](https://reference.aspose.com/slides/hu/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick) vagy a [removeHyperlinkMouseOver](https://reference.aspose.com/slides/hu/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver) metódust; egy kattintási művelet eltávolítása nem távolítja el az egér‑túlfuttatás szerinti változatot.

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

Feltétel nélküli eltávolítás esetén a [removeAllHyperlinks](https://reference.aspose.com/slides/hu/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks) egy hívással mindkét aktiválási típust eltávolítja a kiválasztott körben. A mester, elrendezés és jegyzetek szelektív tisztításáról és átfedéséről lásd a **[Jelentés, tisztítás és hiperhivatkozások ellenőrzése](#report-sanitize-and-verify-hyperlinks)** részt.

## **Teljes hiperhivatkozás‑leltár készítése**

A bemutató terjesztése előtt vegye fel az interaktív műveleteket és a webes hivatkozásokat. A [getAnyHyperlinks](https://reference.aspose.com/slides/hu/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) konténereket ad vissza, mint például a [Shape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/) és a [PortionFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/portionformat/) objektumokat, nem egyszerű URL‑listát. Vizsgálja meg mind a [getHyperlinkClick](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getHyperlinkClick), mind a [getHyperlinkMouseOver](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getHyperlinkMouseOver) metódusokat minden konténeren. Ezek függetlenek: egy konténer mindkét műveletet tartalmazhatja, ezért egy teljes jelentés akár két sorra is kiterjedhet egy konténerhez.

Csak alakzat‑szintű hiperhivatkozások vizsgálata kihagyhat szövegrészlet‑hivatkozásokat. Kérdezze le a megfelelő környezetet, és tartsa meg a visszakapott konténereket, hogy később frissíthesse vagy eltávolíthassa azok műveleteit.

### **Bemutató, dia és szövegkeret körök lekérdezése**

A [HyperlinkQueries](https://reference.aspose.com/slides/hu/python-java/aspose.slides/hyperlinkqueries/) osztály a következőkkel érhető el: [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getHyperlinkQueries), [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseslide/#getHyperlinkQueries) és [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframe/#getHyperlinkQueries). Minden kör ugyanazokat a lekérdezéseket támogatja:

- [getHyperlinkClicks](https://reference.aspose.com/slides/hu/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkClicks) a kattintási művelettel rendelkező konténereket adja vissza.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/hu/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkMouseOvers) a egér‑túlfuttatás művelettel rendelkezőket.
- [getAnyHyperlinks](https://reference.aspose.com/slides/hu/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) mindkét vagy bármelyik művelettel rendelkezőket.

Az alábbi példa létrehoz egy `hyperlink-audit-input.pptx` fájlt, amely külső kattintási linket, fájl egér‑túlfuttatás linket, belső dia‑navigációt, szöveg egér‑túlfuttatás linket és makró‑műveletet tartalmaz. A példában egyetlen művelet sem hajtódik végre. A három lekérdezés minden körben működik; a számlálók konténereket, nem műveleteket adnak vissza. A szövegkeret kör kizárja a befoglaló alakzat saját linkjeit.

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

Ebben a példában a bemutató- és dia‑lekérdezések három kattintási, két egér‑túlfuttatás és három vegyes konténert jelentettek. A szövegkeret lekérdezése egy‑egy konténert adott minden kategóriában.

### **Műveletek és célpontok osztályozása**

Használja a [Hyperlink.getActionType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/hyperlink/#getActionType) metódust a művelet értelmezéséhez, mielőtt a célpontot vizsgálná. A [HyperlinkActionType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/hyperlinkactiontype/) értékek a web‑navigáción túl is terjednek:

| Értékek | Jelentés auditáláskor |
| --- | --- |
| `Hyperlink` | Külső hiperhivatkozás; ellenőrizze az URL‑t és séma‑t. |
| `JumpSpecificSlide` | Belső navigáció egy adott diára. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Beépített diavetítés‑navigáció, a diavetítés kontextusában értelmezve. |
| `JumpEndShow`, `StartCustomSlideShow` | Az aktuális bemutató befejezése vagy egy egyéni bemutató indítása. |
| `StartMacro` | Makró végrehajtása. |
| `StartProgram` | Program indítása. |
| `OpenFile`, `OpenPresentation` | Fájl vagy másik bemutató megnyitása; külön kell vizsgálni a web‑URL‑ktől. |
| `StartStopMedia` | Média lejátszás indítása vagy leállítása. |
| `NoAction`, `Unknown` | Nincs navigációs művelet, vagy ismeretlen művelet, amely felülvizsgálatot igényel. |

Külső célpontok olvashatók a [getExternalUrl](https://reference.aspose.com/slides/hu/python-java/aspose.slides/hyperlink/#getExternalUrl) metódussal, a belső célpontok pedig a [getTargetSlide](https://reference.aspose.com/slides/hu/python-java/aspose.slides/hyperlink/#getTargetSlide) segítségével. Belső műveletek és beépített parancsok esetén előfordulhat, hogy nincs külső URL; az üres URL nem jelenti, hogy a konténernek nincs művelete. Amikor a [getExternalUrlOriginal](https://reference.aspose.com/slides/hu/python-java/aspose.slides/hyperlink/#getExternalUrlOriginal) más, mint a normalizált URL, őrizze meg az eredetit, és ha rendelkezésre áll, adja hozzá a [getTooltip](https://reference.aspose.com/slides/hu/python-java/aspose.slides/hyperlink/#getTooltip) által visszaadott tippet is.

### **Jelentés, tisztítás és hiperhivatkozások ellenőrzése**

Az alábbi Python‑példa beolvassa a meglévő bemutatót (használja a fent létrehozott fájlt), létrehozza a `hyperlink-audit.json` fájlt, alkalmaz egy szabályzatot, elmenti a `hyperlink-sanitized.pptx`‑t, majd újra megnyitja, hogy újra ellenőrizze mindkét aktiválási típust. A módosítás előtt gyűjti a konténereket, és referenciabeli egyenlőséggel kerül a duplikált feldolgozás. A bemutató‑lekérdezések szokásos diákra vonatkoznak; a csomag‑szintű leltárhoz kifejezetten lekérdezésre kerülnek a mesterek, elrendezések, jegyzetek és a jegyzet‑‑ és szórólap‑mesterek is, ha jelen vannak.

A jelentés egy‑alapú dia‑indexet és a [getSlideId](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseslide/#getSlideId) értéket (ha elérhető) rögzíti. A [getSlide](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getSlide) biztosítja a tulajdonos diát a támogatott konténerekhez. A mestereket, elrendezéseket és jegyzeteket nincs rendes dia‑indexük, ezért a környezetük alapján azonosítja őket. Az alakzat‑konténerek és a szövegrészlet‑formázási konténerek külön vannak címkézve; egyéb konténer‑típusok megtartják futási típusuk nevét. Minden konténer kap egy jelentés‑belső azonosítót, hogy a két művelet összekapcsolható legyen. A jelentés a művelettípusokat a Java‑enumeráció egész‑konstansaként tárolja.

Ez a szándékosan szigorú alkalmazási szabályzat csak abszolút HTTPS URL‑eket és érvényes belső dia‑célpontokat engedélyezi. Elutasítja a makrókat, programokat, fájl‑műveleteket, egyéb diavetítés‑műveleteket, ismeretlen műveleteket és egyéb URL‑sémákat. Ezek a visszautasítások szabályzat‑döntések, nem az Aspose.Slides biztonsági megítélése. Az HTTPS önmagában nem jelenti a megbízhatóságot: vegyen fel host‑engedélylistákat és egyéb ellenőrzéseket a saját alkalmazásához. Mind az eredeti, mind a normalizált külső URL‑ket ellenőrzi a rendszer. A példa metaadat‑auditot végez anélkül, hogy a linkekre kattintana vagy a műveleteket végrehajtaná.

Javítás céljából a konténer [getHyperlinkManager](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getHyperlinkManager) támogatja a [setExternalHyperlinkClick](https://reference.aspose.com/slides/hu/python-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick), a [removeHyperlinkClick](https://reference.aspose.com/slides/hu/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick) és a [removeHyperlinkMouseOver](https://reference.aspose.com/slides/hu/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver) metódusokat. Itt a tiltott külső kattintási hivatkozásokat egy rögzített HTTPS céloldallal helyettesítjük; a további tiltott kattintásokat és egér‑túlfuttatás‑műveleteket külön-külön eltávolítjuk. Állítsa a `replace_external_clicks` értékét `False`‑ra, ha az összes szabályszegést el akarja távolítani. Válasszon egy alkalmazás‑saját helyettesítő oldalt a kiadás előtt.

A jelentés export‑jelzője konzervatív PDF‑ellenőrzési szabályt alkalmaz: jelöli az egér‑túlfuttatás‑műveleteket, illetve minden olyan elemet, amely nem külső link vagy konkrét dia‑ugrás, potenciálisan nem támogatottként. Ez egy ellenőrzési útmutató, nem képesség‑teszt vagy garancia arra, hogy a megjelöletlen linkek exportáláskor megmaradnak. A támogatott [PDF](/slides/hu/python-java/convert-powerpoint-to-pdf/) és [HTML](/slides/hu/python-java/convert-powerpoint-to-html/) exportálások megőrizhetik a hiperhivatkozásokat, a művelet, export‑opciók és a nézőtől függően. A raszter [images](/slides/hu/python-java/convert-powerpoint-to-png/) és [video](/slides/hu/python-java/convert-powerpoint-to-video/) nem képesek megtartani az interaktív hiperhivatkozásokat; az ilyen kimenetek auditálásakor jelölje meg minden műveletet.

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

A fent létrehozott bemenet alapján a jelentés öt műveleti sort tartalmaz. A fájl‑egér‑túlfuttatás link és a makró‑kattintás eltávolításra kerül, míg a HTTPS‑linkek és a belső dia‑navigáció megmarad. A verifikáció nulla tiltott műveletet jelez. Egy tiltott külső kattintási URL‑t tartalmazó bemenet a helyettesítési ágat is végrehajtja. Egy engedélyezett kattintású, de tiltott egér‑túlfuttatású konténer megtartja a kattintási műveletét.

Ez a szelektív tisztítás különbözik a [removeAllHyperlinks](https://reference.aspose.com/slides/hu/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks) módszertől, amely a kiválasztott körben mindkét aktiválási típust eltávolítja szabályzat nélkül. Az ellenőrzés itt csak a hiperhivatkozás‑műveleteket vizsgálja; nem távolítja el a beágyazott VBA‑projket, OLE‑objektumokat vagy egyéb aktív tartalmakat, és nem ellenőrzi a kiexportált PDF‑ vagy HTML‑fájlokat.

## **GYIK**

**Hogyan tudok egy szakaszra vagy annak első diájára hivatkozni?**

A PowerPoint szakaszok diákat csoportosítanak, de egy belső hiperhivatkozás egyetlen diát célba vesz. A szakaszra való navigáció létrehozásához hivatkozzon a szakasz első diájára.

**Csatolhatok hiperhivatkozást a mesterdia elemeihez, hogy minden dián működjön?**

Igen. A mesterdia és az elrendezés elemei támogatják a hiperhivatkozásokat. Ezek a linkek a diavetítés során elérhetők azon diákon, amelyek a megfelelő mestert vagy elrendezést használják.

**Megmaradnak a hiperhivatkozások PDF, HTML, képek vagy videó exportálásakor?**

A támogatott PDF és HTML exportálások megőrizhetik a hiperhivatkozásokat; a raszter képek és a videó nem. Lásd a **[Jelentés, tisztítás és hiperhivatkozások ellenőrzése](#report-sanitize-and-verify-hyperlinks)** részt az export‑szempontokért.