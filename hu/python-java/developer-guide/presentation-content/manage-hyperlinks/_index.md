---
title: Prezentációs hiperhivatkozások kezelése Pythonban Java segítségével
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
description: "Hiperhivatkozások hozzáadása, formázása, frissítése és eltávolítása PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Python via Java használatával, Python példákkal."
---
## **Bevezetés**

A hiperhivatkozás összekapcsolja a bemutató tartalmát egy weboldallal vagy a bemutatón belüli helyszínnel. A PowerPointban a hiperhivatkozások általában két célra szolgálnak:

* Weboldal megnyitása szövegből, alakzatból vagy média keretből.
* Navigálás egy másik diára, például egy tartalomjegyzékből.

Az Aspose.Slides for Python via Java lehetővé teszi ezen hivatkozások hozzáadását, megjelenésük és hangjuk szabályozását, tulajdonságaik frissítését, valamint eltávolítását. Az alábbi példák bemutatják, hogyan kell a hiperhivatkozásokkal dolgozni egyedi elemeknél, illetve hogyan lehet a hiperhivatkozásokhoz hozzáférni a bemutató, dia vagy szövegkeret szintjén.

{{% alert color="info" title="Megjegyzés" %}}
A bemutatókat a [ingyenes online Aspose PowerPoint szerkesztővel](https://products.aspose.app/slides/editor) is szerkesztheti.
{{% /alert %}} 

## **URL hiperhivatkozások hozzáadása**

Weboldal URL-t rendelhet szöveghez, alakzathoz vagy média kerethez. Az a elem, amelyhez a hiperhivatkozást rendeli, határozza meg a kattintható területet: egy szövegrész a kiválasztott szöveget linkeli, míg egy alakzat vagy keret a diaobjektumot linkeli.

Relatív hiperhivatkozásokat tartalmazó bemutatók esetén tekintse meg a [Manage the Hyperlink Base](/slides/hu/python-java/presentation-properties/#manage-the-hyperlink-base) cikket a dokumentumszintű alap olvasásához, módosításához vagy törléséhez.

### **URL hiperhivatkozások hozzáadása szöveghez**

A szöveget egy weboldalra linkelheti, ha egy [Hyperlink](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/) objektumot ad át a szövegrész [setHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#setHyperlinkClick) metódusának, ahogy az alább látható. csak az adott szövegrész lesz kattintható.

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

### **URL hiperhivatkozások hozzáadása alakzatokhoz és média keretekhez**

Az alakzat vagy keret kattinthatóvá tételéhez hívja meg a [setHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setHyperlinkClick) metódusát. A hiperhivatkozás az objektumhoz tartozik, nem egy benne lévő szövegrészhez.

Ugyanaz a megközelítés érvényes kép, audio és video keretekre: a hiperhivatkozást a keretre kell rendelni, és szükség esetén meghívni a [setTooltip](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setTooltip) metódust.

Az alábbi példa egy téglalapot tesz kattinthatóvá:

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

## **Hiperhivatkozások használata tartalomjegyzék létrehozásához**

A belső hiperhivatkozások lehetővé teszik az olvasók számára, hogy egy tartalomjegyzékből egy adott diára ugorjanak. A következő példa a [setInternalHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#setInternalHyperlinkClick) metódust használja, hogy az első dián lévő „Page 2” szöveget a második diára linkelje.

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

A [setColorSource](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setColorSource) metódus a [Hyperlink](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/) osztályában határozza meg, hogy a hiperhivatkozás a bemutató hiperhivatkozás színét vagy a szövegrész formázását használja-e. Egy egyedi szövegszín alkalmazásához válassza a [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkcolorsource/) értéket, és állítsa be a rész kitöltő színét. Ez a funkció a PowerPoint 2019‑ben került bevezetésre; a régebbi verziók nem alkalmazzák ezt a beállítást.

Az alábbi példa két szöveges hiperhivatkozást ad ugyanarra a diára. Az első piros szövegtöltést használ, míg a második az alapértelmezett hiperhivatkozás színt tartja meg.

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

A hiperhivatkozás lejátszhat egy hangot aktiváláskor, vagy leállíthat egy már lejátszott hangot. A következő metódusokkal állíthatja be ezeket a viselkedéseket:

- [Hyperlink.setSound](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setSound) meghatározza a hiperhivatkozáshoz társított hangot.
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setStopSoundOnClick) szabályozza, hogy a hiperhivatkozás aktiválása leállítsa-e az előző hangot.

#### **Hiperhivatkozás hangjának hozzáadása**

Az alábbi példa betölti a `sampleaudio.wav` fájlt, és hozzárendeli egy gombhoz az első dián. A gomb megnyomása lejátsza a hangot és a következő diára navigál. Egy második alakzat ugyanazon a dián leállítja az előző hangot kattintáskor, anélkül, hogy navigációt végezne.

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

Az alábbi példa megnyitja a fent létrehozott bemutatót, és a [getSound](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getSound) és a [getBinaryData](https://reference.aspose.com/slides/python-java/aspose.slides/audio/#getBinaryData) metódusok segítségével memóriába olvassa az első alakzat hiperhivatkozás hangját.

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

### **Buboréksúgó és interakció beállítások**

A hiperhivatkozás szöveghez vagy alakzathoz való hozzárendelése után a következő [Hyperlink](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/) metódusok hívhatók meg:

- [setTooltip](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setTooltip) beállítja a szöveget, amelyet a néző a hivatkozás tippjeként megjeleníthet.
- [setTargetFrame](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setTargetFrame) meghatározza a célkeretet egy szülő HTML keretcsoportban, ha alkalmazható.
- [setHistory](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setHistory) szabályozza, hogy a hivatkozás aktiválása hozzáadja-e a célpontot a megtekintett hiperhivatkozások listájához.
- [setHighlightClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setHighlightClick) szabályozza, hogy a hiperhivatkozás ki legyen-e emelve kattintáskor.

## **Hiperhivatkozások eltávolítása bemutatókból**

A [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) használatával összegyűjtheti a hiperhivatkozás konténereket, beleértve a szövegrész hivatkozásait is, mielőtt módosítaná őket. Az alábbi példa eltávolítja mindkét aktivációs típust az első diáról. Ha csak az egyiket szeretné eltávolítani, hívja csak a [removeHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick) vagy a [removeHyperlinkMouseOver](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver) metódust; a kattintási művelet eltávolítása nem távolítja el az egér‑fölé‑húzás párját.

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

Feltétel nélküli eltávolításhoz a [removeAllHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks) egy hívásban eltávolítja mindkét aktivációs típust a kiválasztott hatókörben. Szelektív tisztításhoz és a master‑ek, elrendezések és jegyzetek lefedéséhez lásd a [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) szakaszt.

## **Teljes hiperhivatkozás leltár összeállítása**

Mielőtt terjesztené a bemutatót, készítsen leltárt az interaktív műveleteiről és webes hivatkozásairól. A [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) hiperhivatkozás‑konténereket ad vissza, például [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) és [PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/) objektumokat, nem egy egyszerű URL‑lista. Vizsgálja meg minden konténeren a [getHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getHyperlinkClick) és a [getHyperlinkMouseOver](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getHyperlinkMouseOver) metódusokat. Ezek függetlenek: ugyanaz a konténer is rendelkezhet mindkét művelettel, ezért egy teljes jelentés akár két sort is igényelhet konténerenként.

Csak alakzati szintű hiperhivatkozások beolvasása lemaradhat a szövegrészekhez csatolt hivatkozásokról. Kérdezze le a megfelelő hatókört, és tartsa meg a visszakapott konténereket, hogy később frissíthesse vagy eltávolíthassa azok műveleteit.

### **Prezentáció, dia és szövegkeret hatókörök lekérdezése**

A [HyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/) osztály a [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getHyperlinkQueries), a [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getHyperlinkQueries) és a [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getHyperlinkQueries) metódusokon keresztül érhető el. Minden hatókör ugyanazokat a lekérdezéseket támogatja:

- [getHyperlinkClicks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkClicks) konténereket ad vissza kattintási művelettel.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkMouseOvers) konténereket ad vissza egér‑fölé‑húzási művelettel.
- [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) konténereket ad vissza bármelyik vagy mindkét művelettel.

Az alábbi példa létrehozza a `hyperlink-audit-input.pptx` fájlt egy külső kattintási linkkel, egy fájl egér‑fölé‑húzási linkkel, belső dia‑navigációval, egy szöveg egér‑fölé‑húzási linkkel és egy makró‑művelettel. A példában egyik művelet sem kerül végrehajtásra. Ugyanaz a három lekérdezés minden hatókörben működik; a számlálók konténereket írnak le, nem a műveletek összegét. A szövegkeret hatókör kizárja a körülötte lévő alakzat saját linkjeit.

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

Ebben a példában a prezentáció‑ és dia‑lekérdezések három kattintási, két egér‑fölé‑húzási, valamint három olyan konténert jelentenek, amely valamelyik vagy mindkét műveletet tartalmaz. A szövegkeret lekérdezés egy konténert jelent minden kategóriában.

### **Műveletek és célpontok osztályozása**

A [Hyperlink.getActionType](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getActionType) segítségével értelmezhet egy műveletet, mielőtt a célpontját vizsgálná. A [HyperlinkActionType](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkactiontype/) értékek a webes navigáción túl is terjednek:

| Értékek | Jelentés ellenőrzéskor |
| --- | --- |
| `Hyperlink` | Külső hiperhivatkozás; ellenőrizze az URL‑t és annak sémáját. |
| `JumpSpecificSlide` | Belső navigáció egy adott diára. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Beépített diavetítés‑navigáció, a diavetítés kontextusában értelmezve. |
| `JumpEndShow`, `StartCustomSlideShow` | A jelenlegi előadás befejezése vagy egy egyéni előadás indítása. |
| `StartMacro` | Makró végrehajtása. |
| `StartProgram` | Program indítása. |
| `OpenFile`, `OpenPresentation` | Fájl vagy másik prezentáció megnyitása; külön kell ellenőrizni a webes URL‑ektől. |
| `StartStopMedia` | Média lejátszás indítása vagy leállítása. |
| `NoAction`, `Unknown` | Nincs navigációs művelet, vagy ismeretlen művelet, amely felülvizsgálatot igényel. |

Külső célpontokat a [getExternalUrl](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getExternalUrl) metódussal, a konkrét belső célpontokat a [getTargetSlide](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getTargetSlide) metódussal olvashatja. Belső műveletek és beépített parancsok esetén előfordulhat, hogy nincs külső URL; egy üres URL nem jelenti azt, hogy a konténernek nincs művelete. Ha a [getExternalUrlOriginal](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getExternalUrlOriginal) más értéket ad, mint a normalizált URL, azt meg kell őrizni, és ha elérhető, a [getTooltip](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getTooltip) által visszaadott buboréksúgót is tartalmazni kell.

### **Jelentés, tisztítás és hiperhivatkozások ellenőrzése**

Az alábbi Python‑példa egy meglévő bemutatót (használja a fent létrehozott fájlt) beolvas, kiírja a `hyperlink-audit.json` fájlt, alkalmaz egy szabályzatot, elmenti a `hyperlink-sanitized.pptx` fájlt, majd újra megnyitja, hogy újra ellenőrizze mindkét aktivációs típust. A példában a konténereket a módosítás előtt gyűjti, és referencia‑egyenlőséget használ, hogy ugyanazt a konténert ne dolgozza fel kétszer. A prezentáció‑lekérdezések a szokásos diákra vonatkoznak; egy csomag‑szintű leltárhoz expliciten lekérdezi a master‑eket, elrendezéseket, jegyzeteket, valamint a jegyzet‑ és füzet‑master‑eket, ha jelen vannak.

A jelentés rögzít egy egy‑alapú dia‑indexet és a [getSlideId](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideId) értéket, ahol elérhető. A [getSlide](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getSlide) a támogatott konténerekhez a szülő diát szolgáltatja. A master‑ek, elrendezések és jegyzetek nem rendelkeznek szokásos dia‑indexszel, ezért a hatókör alapján azonosítjuk őket. Az alakzat‑konténereket és a szövegrész‑formázási konténereket külön címkézzük; a többi konténer típusa megtartja a futásidejű típusnevét. Minden konténer kap egy jelentés‑helyi azonosítót, hogy a két művelet összekapcsolható legyen. A jelentés a művelettípusokat a Java‑enumeráció által definiált egész‑konstansokként tárolja.

Ez a szándékosan szigorú alkalmazási szabályzat csak abszolút HTTPS‑URL‑eket és érvényes belső dia‑célpontokat engedélyez. Elutasítja a makrókat, programokat, fájl‑műveleteket, egyéb diavetítés‑műveleteket, ismeretlen műveleteket és egyéb URL‑sémákat. Ezek az elutasítások szabályzati döntések, nem egy Aspose.Slides biztonsági ítélet. Az HTTPS önmagában nem jelent megbízhatást: adjon hozzá host‑engedélylistákat és egyéb ellenőrzéseket az alkalmazásához. Mind az eredeti, mind a normalizált külső URL‑ek ellenőrzésre kerülnek. A példa a metaadatokat ellenőrzi anélkül, hogy a linkeket követné vagy a műveleteket végrehajtaná.

Javításhoz a konténer [getHyperlinkManager](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getHyperlinkManager) támogatja a [setExternalHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick), a [removeHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick) és a [removeHyperlinkMouseOver](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver) metódusokat. Itt a tiltott külső kattintási linkek egy fix HTTPS‑belépő oldalra cserélődnek; a többi tiltott kattintás és tiltott egér‑fölé‑húzás művelet külön-külön eltávolításra kerül. A `replace_external_clicks` értékének `False`‑ra állítása minden szabálysértést eltávolít. Válasszon egy alkalmazás‑tulajdonú helyettesítő oldalt a kiélesítés előtt.

A jelentés export‑jelzője egy konzervatív PDF‑ellenőrzési szabályzatot használ: jelöli az egér‑fölé‑húzás műveleteket és minden mást, ami nem külső link vagy konkrét dia‑ugrás, potenciálisan nem támogatottként. Ez egy felülvizsgálati jelzés, nem egy képesség‑teszt vagy garancia arra, hogy a jelöletlen linkek megmaradnak az export során. A támogatott [PDF](/slides/hu/python-java/convert-powerpoint-to-pdf/) és [HTML](/slides/hu/python-java/convert-powerpoint-to-html/) exportok megőrizhetik a hiperhivatkozásokat, a művelettől, az export‑beállításoktól és a megjelenítőtől függően. A raszteres [images](/slides/hu/python-java/convert-powerpoint-to-png/) és [video](/slides/hu/python-java/convert-powerpoint-to-video/) nem őrizhetik meg az interaktív hiperhivatkozásokat; audit során ezen kimenetekhez minden műveletet jelölni kell.

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

A fent létrehozott bemenettel a jelentés öt műveleti sort tartalmaz. A fájl egér‑fölé‑húzás link és a makró‑kattintás eltávolításra kerül, míg a HTTPS‑linkek és a belső dia‑navigáció megmarad. Az ellenőrzés nulla tiltott műveletet ír ki. Egy tiltott külső kattintási URL‑t tartalmazó bemenet a helyettesítő ágat is végrehajtja. Egy engedélyezett kattintással és tiltott egér‑fölé‑húzással rendelkező konténer megtartja a kattintási műveletét.

Ez a szelektív tisztítás különbözik a [removeAllHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks) működésétől, amely a kiválasztott hatókörben mindkét aktivációs típust eltávolítja szabályzattól függetlenül. Itt az ellenőrzés csak a hiperhivatkozás‑műveleteket vizsgálja; nem távolítja el a beágyazott VBA‑projektet, OLE‑objektumokat vagy más aktív tartalmakat, és nem validálja az exportált PDF‑ vagy HTML‑fájlt.

## **GYIK**

**Hogyan linkelhetek egy szekcióra vagy annak első diájára?**

A PowerPointban a szekciók csoportosítják a diákat, de egy belső hiperhivatkozás egyetlen diára mutat. Navigáció létrehozásához a szekció első diájára hivatkozzon.

**Csatolhatok‑e hiperhivatkozást a mester diák elemeihez, hogy minden diáron működjön?**

Igen. A master‑dia és elrendezés elemei támogatják a hiperhivatkozásokat. Ezeken az elemeken lévő linkek a diavetítés során elérhetők azon diákon, amelyek a megfelelő master‑t vagy elrendezést használják.

**Megmaradnak‑e a hiperhivatkozások PDF, HTML, képek vagy videó exportálásakor?**

A támogatott PDF‑ és HTML‑exportok megőrizhetik a hiperhivatkozásokat; a raszteres képek és videó nem. Tekintse meg az exportálási megfontolásokat a [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) szakaszban.