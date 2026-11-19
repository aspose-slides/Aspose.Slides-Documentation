---
title: Prezentáció hiperhivatkozások kezelése Pythonon keresztül Java segítségével
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
- video hiperhivatkozás
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

A hiperhivatkozás a bemutató tartalmát egy weboldalhoz vagy a bemutatón belüli helyhez kapcsolja. A PowerPointban a hiperhivatkozások általában két célt szolgálnak:

* Weboldal megnyitása szövegből, alakzatból vagy média keretből.
* Ugrás egy másik diára, például egy tartalomjegyzékből.

Az Aspose.Slides for Python via Java lehetővé teszi ezen hivatkozások hozzáadását, megjelenésük és hangjuk vezérlését, tulajdonságaik frissítését, valamint eltávolításukat. Az alábbi példák bemutatják, hogyan dolgozhatunk hiperhivatkozásokkal egyedi elemeknél, és hogyan érhetjük el a hiperhivatkozásokat a bemutató, dia vagy szövegkeret szinten.

{{% alert color="info" title="Note" %}}
A bemutatókat a [ingyenes online Aspose PowerPoint szerkesztővel](https://products.aspose.app/slides/editor) is szerkesztheti.
{{% /alert %}}

## **URL hiperhivatkozások hozzáadása**

Weboldal URL-t adhat szöveghez, alakzathoz vagy média kerethez. Az elem, amelyhez a hiperhivatkozást rendeli, határozza meg a kattintható területet: egy szövegrész a kiválasztott szöveget linkeli, míg egy alakzat vagy keret a diaobjektumot linkeli.

A relatív hiperhivatkozásokat tartalmazó bemutatók esetén tekintse meg a [Hiperhivatkozási alap kezelése](/slides/hu/python-java/presentation-properties/#manage-the-hyperlink-base) oldalt, hogy beolvassa, módosítsa vagy törölje a dokumentumszintű alapot.

### **URL hiperhivatkozások hozzáadása szöveghez**

A szöveg weboldalhoz kapcsolásához adjon át egy [Hyperlink](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/) objektumot a szövegrész [setHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#setHyperlinkClick) metódusának, ahogyan az alább látható. Csak az a szövegrész lesz kattintható.

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

A téglalapra hívja meg a [setHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setHyperlinkClick) metódust, hogy az egész területe kattintható legyen. Használja a [setTooltip](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setTooltip) metódust, hogy a felhasználónak tippet mutasson a célpontról, amikor az egérrel a téglalap fölé viszi. Mindkét metódus alkalmazható képek, hang és videó keretekre is.

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

A belső hiperhivatkozások lehetővé teszik, hogy az olvasók a tartalomjegyzékből egy adott diára ugorjanak. Az alábbi példa a [setInternalHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#setInternalHyperlinkClick) metódust használja, hogy az első dián lévő „Page 2” szöveget a második diához kapcsolja.

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

Megváltoztathatja a hivatkozott szöveg színét, lejátszhat vagy leállíthat egy hangot, amikor a felhasználó aktivál egy hivatkozást, valamint beállíthatja a lebegőtipust, amely az egér fölé vitt esetén megjelenik.

### **Szín**

A [Hyperlink](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/) [setColorSource](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setColorSource) metódusa határozza meg, hogy a hiperhivatkozás a bemutató hiperhivatkozási színét vagy a szövegrész formázását használja-e. Egy egyéni szövegszín alkalmazásához válassza a [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkcolorsource/) lehetőséget, és állítsa be a rész kitöltőszínét. Ez a funkció a PowerPoint 2019-ben került bevezetésre; a régebbi verziók nem alkalmazzák ezt a beállítást.

Ebben a példában a [setColorSource](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setColorSource) az első hivatkozásnál a szövegrész piros kitöltését használja. A második hivatkozás a bemutató hiperhivatkozási színét tartja meg.

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

Hiperhivatkozás lejátszhat egy hangot aktiváláskor vagy leállíthat egy már lejátszott hangot. Az alábbi módszerekkel állíthatja be ezeket a viselkedéseket:

- [Hyperlink.setSound](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setSound) megadja a hiperhivatkozáshoz társított hangot.
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setStopSoundOnClick) vezérli, hogy a hiperhivatkozás aktiválása leállítja-e az előző hangot.

#### **Hiperhivatkozás hangjának hozzáadása**

Az első dián lévő gomb a [Hyperlink.setSound](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setSound) metódust használja, hogy a `sampleaudio.wav` által tartalmazott hangot lejátsza, amikor a felhasználó kattint a továbblépéshez. A második dián egy külön gomb a [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setStopSoundOnClick) metódust használja, hogy leállítsa a lejátszást és a felhasználót azon a dián tartsa.

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

Az alábbi példa megnyitja a fent létrehozott bemutatót, és a [getSound](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getSound) valamint a [getBinaryData](https://reference.aspose.com/slides/python-java/aspose.slides/audio/#getBinaryData) metódusok segítségével beolvassa az első alakzat hiperhivatkozásához tartozó hangot a memóriába.

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

### **Lebegő tippek és interakció beállítások**

Miután egy hiperhivatkozást szöveghez vagy alakzathoz rendelt, a következő [Hyperlink](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/) metódusokat hívhatja meg:

- [setTooltip](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setTooltip) beállítja a szöveget, amelyet a néző a hivatkozás tippjeként megjeleníthet.
- [setTargetFrame](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setTargetFrame) megadja a céltáblát egy szülő HTML keretcsoporton belül, ha alkalmazható.
- [setHistory](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setHistory) vezérli, hogy a hivatkozás aktiválása a megtekintett hiperhivatkozások listájához adja-e a célt.
- [setHighlightClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setHighlightClick) vezérli, hogy a hiperhivatkozás ki legyen-e emelve kattintáskor.

## **Hiperhivatkozások eltávolítása a bemutatókból**

Használja a [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) metódust, hogy a módosítás előtt összegyűjtse a hiperhivatkozás tárolókat, beleértve a szövegrész hivatkozásokat is. Az alábbi példa eltávolítja mindkét aktiválási típust az első diáról. Ha csak egy típust szeretne eltávolítani, hívja csak a [removeHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick) vagy a [removeHyperlinkMouseOver](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver) metódust; a kattintási művelet eltávolítása nem távolítja el az egér fölé viszéses megfelelőjét.

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

Feltétel nélküli eltávolítás esetén a [removeAllHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks) egy hívással eltávolítja mindkét aktiválási típust a kiválasztott hatókörben. A szelektív tisztításhoz és a mester, elrendezés és jegyzetek lefedéséhez tekintse meg a [Jelentés, szűrés és hiperhivatkozások ellenőrzése](#report-sanitize-and-verify-hyperlinks) oldalt.

### **Hiperhivatkozások törlése a SmartArt szöveg cseréje előtt**

Ha egy meglévő SmartArt csomópontban egy bekezdést cserél, a szövegrészek törlése elhagyhat egy régi hiperhivatkozást. A bekezdést a [SmartArtNode.getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#getTextFrame) segítségével kapja meg. A részek törlése előtt hívja meg a [getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getHyperlinkQueries) metódust a csomópont alakzatának szövegkeretén, majd a visszaadott objektumon a [removeAllHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks) metódust. Ez eltávolítja az összes hiperhivatkozást abban a keretben, beleértve a többi bekezdés hivatkozásait is.

A példa azt feltételezi, hogy a `SmartArtHyperlink.pptx` első diájának harmadik alakzata egy SmartArt grafika. A negyedik csomópont első bekezdését cseréli. Ebben a bemutatóban a csomópont első alakzata jeleníti meg ezt a bekezdést.

A két rész hozzáadása után a példa a [getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective) metódussal olvassa ki a hatékony formázásukat. Ebben a formázásban a `getHyperlinkClick` az első részhez visszaadja az új hiperhivatkozást, a másodikhoz pedig `None` értéket.

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
    print(text.getPortionFormat().getEffective().getHyperlinkClick())  # None
finally:
    presentation.dispose()
```

## **Teljes hiperhivatkozás-nyilvántartás felépítése**

Mielőtt egy bemutatót terjesztene, készítsen leltárt a interaktív műveleteiről és a webes hivatkozásairól. A [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) hiperhivatkozás-tárolókat ad vissza, például [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) és [PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/) objektumokat, nem pedig egy egyszerű URL karakterlánc-listát. Vizsgálja meg mind a [getHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getHyperlinkClick), mind a [getHyperlinkMouseOver](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getHyperlinkMouseOver) metódusokat minden tárolón. Ezek függetlenek: ugyanaz a tároló mindkét műveletet kiteszi, így egy teljes jelentéshez legfeljebb két sorra van szükség tárolónként.

### **Prezentáció, dia és szövegkeret hatókörök lekérdezése**

A [HyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/) osztály elérhető a [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getHyperlinkQueries), a [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getHyperlinkQueries) és a [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getHyperlinkQueries) segítségével. Minden hatókör támogatja ugyanazokat a lekérdezéseket:

- [getHyperlinkClicks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkClicks) visszaadja a kattintási művelettel rendelkező tárolókat.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkMouseOvers) visszaadja az egér fölé viszést aktiváló művelettel rendelkező tárolókat.
- [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) visszaadja a tárolókat, amelyek valamelyik vagy mindkét művelettel rendelkeznek.

Ez a példa kattintási és egér fölé viszési műveleteket rendel egy alakzathoz és annak szövegéhez, valamint egy makró műveletet egy külön gombhoz. Összehasonlítja a [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) által visszaadott tárolók számát az egyes aktiválási típusok számlálójával. A szövegkeret lekérdezés csak a szövegben lévő hivatkozásokat számolja. A körülvevő alakzat saját műveletei a dia és a bemutató lekérdezéseiben jelennek meg.

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

Ehhez a példához a bemutató és a diák lekérdezései három kattintási tárolót, két egér fölé viszési tárolót és három, valamelyik művelettel rendelkező tárolót jelentenek. A szövegkeret lekérdezés minden kategóriában egy tárolót jelent.

### **Műveletek és célpontok osztályozása**

Használja a [Hyperlink.getActionType](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getActionType) metódust, hogy a célpont értelmezése előtt értelmezze a műveletet. A [HyperlinkActionType](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkactiontype/) értékek a webes navigáción túl is terjednek:

| Values | Meaning for an audit |
| --- | --- |
| `Hyperlink` | Külső hiperhivatkozás; ellenőrizze az URL-t és annak sémáját. |
| `JumpSpecificSlide` | Belső navigáció egy adott diára. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Beépített diavetítés-navigáció, a diavetítés kontextusában értelmezve. |
| `JumpEndShow`, `StartCustomSlideShow` | A jelenlegi előadás befejezése vagy egy egyedi előadás indítása. |
| `StartMacro` | Makró végrehajtása. |
| `StartProgram` | Program indítása. |
| `OpenFile`, `OpenPresentation` | Fájl vagy másik bemutató megnyitása; külön kell ellenőrizni a webes URL-ekkel. |
| `StartStopMedia` | Média lejátszás indítása vagy leállítása. |
| `NoAction`, `Unknown` | Nincs navigációs művelet, vagy egy ismeretlen művelet, amely felülvizsgálatot igényel. |

Külső célpontokat a [getExternalUrl](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getExternalUrl) segítségével, a specifikus belső célpontokat pedig a [getTargetSlide](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getTargetSlide) metódus által olvashatja. A belső műveletek és beépített parancsok nem feltétlenül rendelkeznek külső URL-lel; egy üres URL nem jelenti, hogy a tároló nem tartalmaz műveletet. Tartsa meg a [getExternalUrlOriginal](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getExternalUrlOriginal) által visszaadott értéket, ha eltér a normalizált URL-től, és adja hozzá a [getTooltip](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getTooltip) által visszaadott lebegő tippszöveget, ha elérhető.

### **Jelentés, szűrés és hiperhivatkozások ellenőrzése**

Ez a példa megnyitja az előző példából származó bemutatót, és minden műveletről egy JSON rekordot ír. A [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) segítségével összegyűjti a tárolókat a szokásos diákon, mastereken, elrendezéseken és jegyzeteken, beleértve a jegyzet és a segédlet mastereket, ha jelen vannak. Referencia-egyenlőséget használ minden tároló egyszeri számlálásához, alkalmazza az alább leírt irányelvet, és újból megnyitja a mentett bemutatót, hogy ellenőrizze a kattintási és egér fölé viszési műveleteket.

A jelentés egy egy-alapú diaindexet és a rendelkezésre álló [getSlideId](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideId) értéket rögzíti. A [getSlide](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getSlide) biztosítja a tulajdonos darabot a támogatott tárolókhoz. A masterek, elrendezések és jegyzetek nem rendelkeznek szokásos diaindexszel, és a hatókörük alapján azonosíthatók. Az alakzat-tárolók és a szövegrész-formázási tárolók külön jelöltek; más tárolótípusok megtartják a futásidejű típusnevet. Minden tároló kap egy jelentésbeli helyi azonosítót, hogy a két művelete összekapcsolható legyen. A jelentés a művelettípusokat a Java felsorolásban definiált egész konstansokként tárolja.

Ez a szándékosan szigorú alkalmazási irányelv csak abszolút HTTPS URL-eket és érvényes belső diacélpontokat engedélyez. Elutasítja a makrókat, programokat, fájlműveleteket, egyéb diavetítés-műveleteket, ismeretlen műveleteket és egyéb URL-sémákat. Ezek az elutasítások irányelvi döntések, nem az Aspose.Slides biztonsági ítélete. Az egyszerű HTTPS nem biztosít bizalmat: adjon hozzá gazda fehérlistákat és egyéb ellenőrzéseket az alkalmazásához. Az eredeti és a normalizált külső URL-ek is ellenőrzésre kerülnek. A példa metaadatokat ellenőriz anélkül, hogy a hivatkozásokat követné vagy a műveleteket végrehajtaná.

Javítás esetén a tároló [getHyperlinkManager](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getHyperlinkManager) támogatja a [setExternalHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick), a [removeHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick) és a [removeHyperlinkMouseOver](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver) metódusokat. Itt a tiltott külső kattintási hivatkozásokat egy rögzített HTTPS céloldallal helyettesítik; a többi tiltott kattintás és a tiltott egér fölé viszés műveleteket függetlenül távolítják el. Állítsa a `replace_external_clicks` értékét `False`-ra, hogy helyette minden szabálysértést eltávolítson. Válasszon egy alkalmazás-tulajdonú helyettesítő oldalt a telepítés előtt.

A jelentés exportálási jelzője egy konzervatív PDF-ellenőrzési irányelvet használ: jelöli az egér fölé viszési műveleteket és minden mást, ami nem külső hivatkozás vagy specifikus diaugrás, potenciálisan nem támogatottként. Ez egy ellenőrzési jelzés, nem pedig egy képesség-teszt vagy garancia arra, hogy a nem jelölt hivatkozások megmaradnak exportáláskor. A támogatott [PDF](/slides/hu/python-java/convert-powerpoint-to-pdf/) és [HTML](/slides/hu/python-java/convert-powerpoint-to-html/) exportok megőrizhetik a hiperhivatkozásokat, az adott művelettől, export beállításoktól és a megjelenítőtől függően. A raszteres [images](/slides/hu/python-java/convert-powerpoint-to-png/) és [video](/slides/hu/python-java/convert-powerpoint-to-video/) nem tudja megőrizni az interaktív hiperhivatkozásokat; auditáláskor jelölje meg minden műveletet ezekhez a kimenetekhez.

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

A fent létrehozott bemenettel a jelentés öt műveleti sort tartalmaz. A fájl egér fölé viszési hivatkozása és a makró kattintás eltávolításra kerül, míg a HTTPS hivatkozások és a belső dia navigáció megmarad. Az ellenőrzés nulla tiltott műveletet jelez. Egy tiltott külső kattintási URL-t tartalmazó bemenet is a helyettesítő ágat teszteli. Egy olyan tároló, amelynek engedélyezett a kattintás, de tiltott a egér fölé viszés, megtartja a kattintási műveletet.

Ez a szelekciós tisztítás eltér a [removeAllHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks) módszertől, amely a kiválasztott hatókörben a politikától függetlenül eltávolítja mindkét aktiválási típust. Az itt végzett ellenőrzés csak a hiperhivatkozás műveleteket vizsgálja; nem távolítja el a beágyazott VBA projektek, OLE objektumok vagy egyéb aktív tartalmak, és nem validálja a exportált PDF vagy HTML fájlt.

## **GYIK**

**Hogyan kapcsolhatok egy szakaszhoz vagy annak első diájához?**

A PowerPoint szakaszok diákat csoportosítanak, de a belső hiperhivatkozás egy adott diát céloz meg. Egy szakaszhoz való navigáció létrehozásához a szakasz első diájára hivatkozzon.

**Csatolhatok hiperhivatkozást a mesterdia elemeihez, hogy minden dián működjön?**

Igen. A mesterdia és elrendezés elemei támogatják a hiperhivatkozásokat. Ezekre az elemekre helyezett hivatkozások a diavetítés során elérhetők azon diákon, amelyek a megfelelő mestert vagy elrendezést használják.

**Megmaradnak a hiperhivatkozások PDF, HTML, képek vagy videó exportálásakor?**

A támogatott PDF és HTML exportok megőrizhetik a hiperhivatkozásokat; a raszteres képek és videó nem. Lásd az exportálási szempontokat a [Jelentés, szűrés és hiperhivatkozások ellenőrzése](#report-sanitize-and-verify-hyperlinks) részben.