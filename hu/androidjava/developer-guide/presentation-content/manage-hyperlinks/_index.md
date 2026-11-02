---
title: Prezentációs hiperhivatkozások kezelése Androidon
linktitle: Hiperhivatkozások kezelése
type: docs
weight: 20
url: /hu/androidjava/manage-hyperlinks/
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
- Android
- Java
- Aspose.Slides
description: "Hiperhivatkozások hozzáadása, formázása, frissítése és eltávolítása PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Android via Java segítségével, Java példákkal."
---
## **Bevezetés**

A hiperhivatkozás összekapcsolja a prezentáció tartalmát egy weboldallal vagy a prezentáción belüli egy helyszínnel. A PowerPointban a hiperhivatkozások általában két célra szolgálnak:

* Weboldal megnyitása szövegből, alakzatból vagy média keretből.
* Navigálás egy másik diára, például egy tartalomjegyzékből.

Az Aspose.Slides for Android via Java lehetővé teszi ezen hivatkozások hozzáadását, megjelenésük és hangjuk szabályozását, tulajdonságaik frissítését, valamint eltávolításukat. Az alábbi példák bemutatják, hogyan kell dolgozni a hiperhivatkozásokkal egyedi elemeknél, valamint hogyan érhetők el a hiperhivatkozások a prezentáció, dia vagy szövegkeret szintjén.

{{% alert color="info" title="Note" %}}
A prezentációkat szerkesztheti a [gratis online Aspose PowerPoint szerkesztővel](https://products.aspose.app/slides/editor).
{{% /alert %}} 

## **URL hiperhivatkozások hozzáadása**

Webhely URL-jét szöveghez, alakzathoz vagy média kerethez rendelhet. Az a elem, amelyhez a hiperhivatkozást rendeli, meghatározza a kattintható területet: egy szövegrészlet a kijelölt szöveget kapcsolja, míg egy alakzat vagy keret a diaobjektumot.

A relatív hiperhivatkozásokat tartalmazó prezentációkhoz tekintse meg a [Hiperhivatkozás-alap kezelése](/slides/hu/androidjava/presentation-properties/#manage-the-hyperlink-base) szakaszt a dokumentumszintű alap beolvasásához, módosításához vagy törléséhez.

### **URL hiperhivatkozások hozzáadása szöveghez**

A szöveget egy weboldalra hivatkozáshoz adja át egy [Hyperlink](https://reference.aspose.com/slides/androidjava/com.aspose.slides/hyperlink/) objektumot a szövegrészlet [setHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portionformat/#setHyperlinkClick-com.aspose.slides.IHyperlink-) metódusával, ahogy az alább látható. Csak ez a szövegrészlet lesz kattintható.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IAutoShape textShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
    textShape.addTextFrame("Aspose: File Format APIs");
    IPortionFormat portionFormat = textShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");
    portionFormat.setFontHeight(32);

    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **URL hiperhivatkozások hozzáadása alakzatokhoz és média keretekhez**

Egy alakzat vagy keret kattinthatóvá tételéhez hívja meg a [setHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setHyperlinkClick-com.aspose.slides.IHyperlink-) metódust. A hiperhivatkozás az objektumhoz, nem egy benne lévő szöveghez tartozik.

Ugyanez a megközelítés érvényes kép-, audio- és videókeretekre is: adja hozzá a hiperhivatkozást a kerethez, és szükség esetén hívja meg a [setTooltip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) metódust.

Az alábbi példa egy téglalapot tesz kattinthatóvá:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

    shape.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    shape.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");

    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Hiperhivatkozások használata tartalomjegyzék létrehozásához**

A belső hiperhivatkozások lehetővé teszik az olvasók számára, hogy a tartalomjegyzékről egy adott diára ugorjanak. Az alábbi példa a [setInternalHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#setInternalHyperlinkClick-com.aspose.slides.ISlide-) metódust használja a “Page 2” szöveg első dián való hivatkozásához a második diára.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ISlide secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    IAutoShape tableOfContents = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100);
    tableOfContents.getFillFormat().setFillType(FillType.NoFill);
    tableOfContents.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    tableOfContents.getTextFrame().getParagraphs().clear();

    Paragraph paragraph = new Paragraph();
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    paragraph.setText("Title of slide 2 .......... ");

    Portion linkPortion = new Portion();
    linkPortion.setText("Page 2");
    linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);

    paragraph.getPortions().add(linkPortion);
    tableOfContents.getTextFrame().getParagraphs().add(paragraph);

    presentation.save("link_to_slide.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Hiperhivatkozások formázása**

### **Szín**

Az [IHyperlink](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/) [setColorSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setColorSource-int-) metódusa határozza meg, hogy a hiperhivatkozás a prezentáció hiperhivatkozás-színét vagy a szövegrészlet formázását használja-e. Egyedi szövegszín alkalmazásához válassza a [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/hyperlinkcolorsource/) értéket, és állítsa be a rész kitöltőszínét. Ez a funkció a PowerPoint 2019‑ben került bevezetésre; régebbi verziókban ez a beállítás nem alkalmazható.

Az alábbi példa két szöveghiperhivatkozást ad ugyanarra a diára. Az első piros szöveggel van formázva, a második a szabványos hiperhivatkozás-színnel marad.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    IAutoShape coloredShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
    coloredShape.addTextFrame("This hyperlink uses a custom color.");
    IPortionFormat coloredPortionFormat = coloredShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    coloredPortionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    coloredPortionFormat.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat);
    coloredPortionFormat.getFillFormat().setFillType(FillType.Solid);
    coloredPortionFormat.getFillFormat().getSolidFillColor().setColor(Color.RED);

    IAutoShape defaultShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
    defaultShape.addTextFrame("This hyperlink uses the default color.");
    defaultShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));

    presentation.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
### **Hang**

A hiperhivatkozás aktiválásakor lejátszhat hangot, vagy leállíthat egy már lejátszó hangot. A következő metódusokkal állíthatja be ezeket a viselkedéseket:

- [IHyperlink.setSound](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setSound-com.aspose.slides.IAudio-) adja meg a hiperhivatkozáshoz tartozó hangot.
- [IHyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setStopSoundOnClick-boolean-) szabályozza, hogy a hiperhivatkozás aktiválása leállítja-e az előző hangot.

#### **Hiperhivatkozás hangjának hozzáadása**

Az alábbi példa betölti a `sampleaudio.wav` fájlt, és egy gombhoz kapcsolja az első dián. A gomb megnyomásakor a hang lejátszódik, és a következő diára navigál. Egy másik alakzat ugyanazon a dián leállítja a korábbi hangot kattintáskor, anélkül, hogy navigációt végezne.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    IAudio hyperlinkSound;
    try (FileInputStream audioStream = new FileInputStream("sampleaudio.wav")) {
        hyperlinkSound = presentation.getAudios().addAudio(audioStream);
    }

    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IAutoShape playButton = firstSlide.getShapes().addAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
    playButton.setHyperlinkClick(Hyperlink.getNextSlide());

    if (!playButton.getHyperlinkClick().getStopSoundOnClick() && playButton.getHyperlinkClick().getSound() == null)
    {
        playButton.getHyperlinkClick().setSound(hyperlinkSound);
    }

    ISlide secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    IAutoShape stopButton = secondSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
    stopButton.setHyperlinkClick(Hyperlink.getNoAction());

    stopButton.getHyperlinkClick().setStopSoundOnClick(true);

    presentation.save("hyperlink-sound.pptx", SaveFormat.Pptx);
} catch (IOException exception) {
    System.out.println("Unable to read the audio file: " + exception.getMessage());
} finally {
    presentation.dispose();
}
```

#### **Hiperhivatkozás hangjának kinyerése**

Az alábbi példa megnyitja a fent létrehozott prezentációt, és a [getSound](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getSound--) illetve a [getBinaryData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudio/#getBinaryData--) metódusok segítségével beolvassa az első alakzat hiperhivatkozás-audióját a memóriába.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("hyperlink-sound.pptx");
try {
    if (presentation.getSlides().size() > 0 && presentation.getSlides().get_Item(0).getShapes().size() > 0) {
        IHyperlink hyperlink = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getHyperlinkClick();
        IAudio sound = hyperlink == null ? null : hyperlink.getSound();
        if (sound != null) {
            byte[] audioData = sound.getBinaryData();
            System.out.println("Extracted " + audioData.length + " bytes of hyperlink audio.");
        } else {
            System.out.println("The first shape has no hyperlink sound.");
        }
    } else {
        System.out.println("The presentation has no first slide or shape to inspect.");
    }
} finally {
    presentation.dispose();
}
```

### **Buborék és interakciós beállítások**

A hiperhivatkozás szöveghez vagy alakzathoz történő hozzárendelése után a következő [IHyperlink](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/) metódusokat hívhatja meg:

- [setTooltip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) a hivatkozásra mutató tippek megjelenítéséhez.
- [setTargetFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setTargetFrame-java.lang.String-) a célkeret meghatározásához egy szülő HTML keretcsoportban, ha alkalmazható.
- [setHistory](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setHistory-boolean-) szabályozza, hogy a hivatkozás aktiválása felvegye‑e a célját a megtekintett hiperhivatkozások listájába.
- [setHighlightClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setHighlightClick-boolean-) szabályozza, hogy a hiperhivatkozás kattintáskor ki legyen‑e emelve.

## **Hiperhivatkozások eltávolítása a prezentációkból**

A [getAnyHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) segítségével gyűjtheti a hiperhivatkozás‑konténereket, köztük a szövegrészlet‑hivatkozásokat, a módosítás előtt. Az alábbi példa mindkét aktiválási típust eltávolítja az első diáról. Egy típus eltávolításához csak a [removeHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) vagy a [removeHyperlinkMouseOver](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--) metódust hívja; a kattintási művelet eltávolítása nem távolítja el az egér‑felette lépést.

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.List;

Presentation presentation = new Presentation("pres.pptx");
try {
    if (presentation.getSlides().size() > 0) {
        List<IHyperlinkContainer> containers = new ArrayList<>();
        for (IHyperlinkContainer container : presentation.getSlides().get_Item(0).getHyperlinkQueries().getAnyHyperlinks()) {
            containers.add(container);
        }
        for (IHyperlinkContainer container : containers) {
            container.getHyperlinkManager().removeHyperlinkClick();
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
        presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The presentation has no slides to process.");
    }
} finally {
    presentation.dispose();
}
```

Feltétlen eltávolításhoz a [removeAllHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) egy hívással mindkét aktiválási típust törli a kiválasztott hatókörben. Kiválasztott tisztításhoz és a mesterek, elrendezések és jegyzetek lefedéséhez tekintse meg a [Hiperhivatkozások jelentése, szanitizálása és ellenőrzése](#report-sanitize-and-verify-hyperlinks) részt.

## **Teljes hiperhivatkozás‑leltár felállítása**

A prezentáció terjesztése előtt auditálja interaktív műveleteit és webes hivatkozásait. A [getAnyHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) [IHyperlinkContainer](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkcontainer/) objektumokat ad vissza, nem egyszerű URL‑lista formájában. Vizsgálja meg mind a [getHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) , mind a [getHyperlinkMouseOver](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) metódusokat minden konténeren. Függetlenek: egy konténer mindkét műveletet tartalmazhatja, ezért egy teljes jelentés akár két sorra is szükséges konténerenként.

Csak alakzatszintű hiperhivatkozások lekérdezése kihagyhatja a szöveg‑részletekhez csatolt hivatkozásokat. Kérdezze le a megfelelő hatókört, és őrizze meg a visszaadott konténereket a későbbi frissítéshez vagy eltávolításhoz.

### **Prezentáció, dia és szövegkeret hatókörök lekérdezése**

Az [IHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/) interfészt a [IPresentation.getHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getHyperlinkQueries--), a [IBaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getHyperlinkQueries--) és az [ITextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getHyperlinkQueries--) biztosítja. Minden hatókör ugyanazokat a lekérdezéseket támogatja:

- [getHyperlinkClicks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkClicks--) a kattintási művelettel rendelkező konténereket adja vissza.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkMouseOvers--) az egér‑felette lépéses művelettel rendelkező konténereket adja vissza.
- [getAnyHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) az egy vagy mindkét művelettel rendelkező konténereket adja vissza.

Az alábbi példa létrehoz egy `hyperlink-audit-input.pptx` fájlt egy külső kattintási linkkel, egy fájl‑egér‑felette linkkel, belső dia‑navigációval, egy szöveg‑egér‑felette linkkel és egy makró‑művelettel. Nem hajtja végre ezeket a műveleteket. A három lekérdezés minden hatókörben ugyanúgy működik; a számlálók konténereket, nem művelet‑összesítéseket adnak vissza. A szövegkeret‑hatókör kizárja a körülvevő alakzat saját linkjeit.

```java
import com.aspose.slides.*;

class QueryCounts {
    void print(String scope, IHyperlinkQueries queries) {
        int clickCount = queries.getHyperlinkClicks().size();
        int mouseOverCount = queries.getHyperlinkMouseOvers().size();
        int anyCount = queries.getAnyHyperlinks().size();
        System.out.println(scope + ": click=" + clickCount + ", mouse-over=" + mouseOverCount + ", any=" + anyCount);
    }
}

QueryCounts counts = new QueryCounts();
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ISlide destination = presentation.getSlides().addEmptySlide(slide.getLayoutSlide());
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Click the text to go to slide 2");
    shape.getHyperlinkManager().setExternalHyperlinkClick("https://example.com/");
    shape.getHyperlinkClick().setTooltip("Public website");
    shape.getHyperlinkManager().setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

    IPortionFormat portionFormat = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.getHyperlinkManager().setInternalHyperlinkClick(destination);
    portionFormat.getHyperlinkManager().setExternalHyperlinkMouseOver("https://example.com/help");
    IAutoShape macroButton = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 120, 200, 60);
    macroButton.getHyperlinkManager().setMacroHyperlinkClick("ReviewPresentation");

    counts.print("Presentation", presentation.getHyperlinkQueries());
    counts.print("Slide 1", slide.getHyperlinkQueries());
    counts.print("Text frame", shape.getTextFrame().getHyperlinkQueries());
    presentation.save("hyperlink-audit-input.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ebben a példában a prezentáció‑ és dia‑lekérdezések három kattintási, két egér‑felette és három kombinált konténert jeleznek. A szövegkeret‑lekérdezés egy konténert ad minden kategóriában.

### **Műveletek és célpontok osztályozása**

Használja az [IHyperlink.getActionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getActionType--) metódust, hogy a célpont meghatározása előtt értelmezze a műveletet. A [HyperlinkActionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/hyperlinkactiontype/) értékek a web‑navigációt meghaladják:

| Értékek | Jelentés auditáláskor |
| --- | --- |
| `Hyperlink` | Külső hiperhivatkozás; ellenőrizze az URL‑t és séma‑elemét. |
| `JumpSpecificSlide` | Belső navigáció egy adott diára. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Beépített diavetítés‑navigáció, a diavetítés környezetében értelmezve. |
| `JumpEndShow`, `StartCustomSlideShow` | Jelenlegi előadás befejezése vagy egy egyedi előadás indítása. |
| `StartMacro` | Makró végrehajtása. |
| `StartProgram` | Program indítása. |
| `OpenFile`, `OpenPresentation` | Fájl vagy másik prezentáció megnyitása; külön kezelendő a web‑URL‑ektől. |
| `StartStopMedia` | Média lejátszás indítása vagy leállítása. |
| `NoAction`, `Unknown` | Nincs navigációs művelet, vagy ismeretlen művelet, amely felülvizsgálatot igényel. |

A külső célpontokat a [getExternalUrl](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getExternalUrl--) metódussal, a belső célpontokat a [getTargetSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getTargetSlide--) metódussal olvassa ki. Belső műveletek és beépített parancsok esetén lehet, hogy nincs külső URL; egy üres URL nem jelenti, hogy a konténernek nincs művelete. Tartsa meg a [getExternalUrlOriginal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) által visszaadott értéket, ha eltér a normalizált URL‑től, és adja hozzá a [getTooltip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getTooltip--) által visszaadott buborék‑szöveget, ha elérhető.

### **Hiperhivatkozások jelentése, szanitizálása és ellenőrzése**

Az alábbi Java‑példa beolvassa egy meglévő prezentációt (a fenti fájlt használja), kiírja a `hyperlink-audit.json` fájlt, alkalmaz egy szabályt, menti a `hyperlink-sanitized.pptx`‑et, majd újból megnyitja, hogy újra ellenőrizze mindkét aktiválási típust. A változtatások előtt összegyűjti a konténereket, és referenciakénti egyenlőséget használ a duplikációk elkerüléséhez. A prezentáció‑lekérdezések a szokásos diákra vonatkoznak; a csomag‑széles leltárhoz kifejezetten a mestereket, elrendezéseket, jegyzeteket és a jegyzet‑ illetve kiosztó‑mestereket is lekérdezi, ha léteznek.

A jelentés egy egy‑alapú dia‑indexet és a [getSlideId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getSlideId--) értéket rögzíti, ahol elérhető. Az [ISlideComponent.getSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecomponent/#getSlide--) biztosítja a tulajdonos diát a támogatott konténerekhez. A mesterek, elrendezések és jegyzetek nem rendelkeznek szokásos dia‑indexszel, hanem a hatókörük alapján azonosíthatók. Az alakzat‑konténereket és a szövegrészlet‑formázási konténereket külön jelöli; egyéb konténer‑típusok megtartják a futás‑idejű típusnevüket. Minden konténer kap egy helyi jelentés‑azonosítót, hogy a két művelet összerendelhető legyen. A jelentés a művelettípusokat a Java‑enumeráció által definiált egész‑konstansokként tárolja.

Ez a szándékosan szigorú alkalmazási szabály csak abszolút HTTPS‑URL‑eket és érvényes belső dia‑célokat engedélyez. Visszautasítja a makrókat, programokat, fájl‑műveleteket, egyéb diavetítési műveleteket, ismeretlen műveleteket és egyéb URL‑sémákat. Ezek az elutasítások szabályozási döntések, nem az Aspose.Slides biztonsági megítélését tükrözik. A HTTPS önmagában nem garantálja a megbízhatóságot: adjon meg gazdagép‑fehérlistákat és egyéb ellenőrzéseket az alkalmazásához. Az eredeti és a normalizált külső URL‑eket egyaránt ellenőrzik. A példa a metaadatokat auditálja anélkül, hogy linkeket követne vagy műveleteket hajtana végre.

Javításhoz a konténer [getHyperlinkManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) támogatja a [setExternalHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-), [removeHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) és [removeHyperlinkMouseOver](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--) metódusokat. Itt a tiltott külső kattintási linkek egy rögzített HTTPS céloldalra cserélődnek; a többi tiltott kattintás és egér‑felette művelet önállóan eltávolításra kerül. A `replaceExternalClicks` értékének `false`‑ra állítása minden szabálysértés eltávolítását eredményezi. Válasszon egy alkalmazás‑tulajdonú helyettesítő oldalt a telepítés előtt.

A jelentés export‑jelzője egy konzervatív PDF‑áttekintési szabályt használ: jelöli az egér‑felette műveleteket és mindent, ami nem külső link vagy konkrét dia‑ugrás, potenciálisan nem támogatottként. Ez egy ellenőrzési tipp, nem egy képesség‑teszt vagy garancia arra, hogy a jelöletlen linkek megmaradnak az export során. A támogatott [PDF](/slides/hu/androidjava/convert-powerpoint-to-pdf/) és [HTML](/slides/hu/androidjava/convert-powerpoint-to-html/) exportok a hiperhivatkozásokat megőrizhetik, a művelettől, export‑beállításoktól és a megjelenítőtől függően. A raszteres [képek](/slides/hu/androidjava/convert-powerpoint-to-png/) és [videók](/slides/hu/androidjava/convert-powerpoint-to-video/) nem őrizhetik meg az interaktív hiperhivatkozásokat; ezeknél minden művelet jelölendő auditáláskor.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.net.URI;
import java.net.URISyntaxException;
import java.nio.charset.StandardCharsets;
import java.io.FileOutputStream;
import android.text.TextUtils;
import java.util.ArrayList;
import java.util.Collections;
import java.util.IdentityHashMap;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;
import java.util.Objects;
import java.util.Set;

class HyperlinkAudit {
    Integer slideIndex(IPresentation presentation, IBaseSlide slide) {
        for (int index = 0; index < presentation.getSlides().size(); index++) {
            if (presentation.getSlides().get_Item(index) == slide) return index + 1;
        }
        return null;
    }

    boolean isHttps(String value) {
        if (value == null || value.isEmpty()) return false;
        try {
            URI uri = new URI(value);
            return uri.isAbsolute() && "https".equalsIgnoreCase(uri.getScheme()) && uri.getHost() != null;
        } catch (URISyntaxException exception) {
            return false;
        }
    }

    String policyViolation(IHyperlink link) {
        if (link == null) return null;
        if (link.getActionType() == HyperlinkActionType.JumpSpecificSlide) {
            return link.getTargetSlide() == null ? "Missing target slide" : null;
        }
        if (link.getActionType() != HyperlinkActionType.Hyperlink) return "Action is not allowed";
        if (!isHttps(link.getExternalUrl())) return "Normalized URL is not absolute HTTPS";
        String original = link.getExternalUrlOriginal();
        if (original != null && !original.isEmpty() && !isHttps(original)) return "Original URL is not absolute HTTPS";
        return null;
    }

    void addScope(List<IHyperlinkContainer> found, IBaseSlide slide) {
        if (slide != null) {
            for (IHyperlinkContainer container : slide.getHyperlinkQueries().getAnyHyperlinks()) {
                found.add(container);
            }
        }
    }

    List<IHyperlinkContainer> collectContainers(IPresentation presentation) {
        List<IHyperlinkContainer> found = new ArrayList<>();
        for (IHyperlinkContainer container : presentation.getHyperlinkQueries().getAnyHyperlinks()) {
            found.add(container);
        }
        for (IMasterSlide master : presentation.getMasters()) addScope(found, master);
        for (ILayoutSlide layout : presentation.getLayoutSlides()) addScope(found, layout);
        for (ISlide slide : presentation.getSlides()) addScope(found, slide.getNotesSlideManager().getNotesSlide());
        addScope(found, presentation.getMasterNotesSlideManager().getMasterNotesSlide());
        addScope(found, presentation.getMasterHandoutSlideManager().getMasterHandoutSlide());
        Set<IHyperlinkContainer> seen = Collections.newSetFromMap(new IdentityHashMap<IHyperlinkContainer, Boolean>());
        List<IHyperlinkContainer> unique = new ArrayList<>();
        for (IHyperlinkContainer container : found) {
            if (seen.add(container)) unique.add(container);
        }
        return unique;
    }

    void addRow(List<Map<String, Object>> rows, IPresentation presentation, IHyperlink link, String activation, IHyperlinkContainer container, int containerId) {
        if (link == null) return;
        IBaseSlide ownerSlide = container instanceof ISlideComponent ? ((ISlideComponent) container).getSlide() : null;
        ISlide targetSlide = link.getTargetSlide();
        String violation = policyViolation(link);
        String ownerType = container instanceof IShape ? "Shape" : container instanceof IPortionFormat ? "Text portion" : container.getClass().getSimpleName();
        boolean ordinaryAction = link.getActionType() == HyperlinkActionType.Hyperlink || link.getActionType() == HyperlinkActionType.JumpSpecificSlide;
        Map<String, Object> row = new LinkedHashMap<>();
        row.put("ContainerId", containerId);
        row.put("SlideIndex", slideIndex(presentation, ownerSlide));
        row.put("SlideId", ownerSlide == null ? null : ownerSlide.getSlideId());
        row.put("Scope", ownerSlide == null ? null : ownerSlide.getClass().getSimpleName());
        row.put("OwnerType", ownerType);
        row.put("Activation", activation);
        row.put("ActionType", link.getActionType());
        row.put("ExternalUrl", link.getExternalUrl());
        row.put("TargetSlideIndex", slideIndex(presentation, targetSlide));
        row.put("TargetSlideId", targetSlide == null ? null : targetSlide.getSlideId());
        row.put("Tooltip", link.getTooltip());
        row.put("OriginalExternalUrl", Objects.equals(link.getExternalUrlOriginal(), link.getExternalUrl()) ? null : link.getExternalUrlOriginal());
        row.put("PotentiallyUnsafe", violation != null);
        row.put("PolicyViolation", violation);
        row.put("TargetExport", "PDF");
        row.put("PotentiallyUnsupportedByExport", "mouse-over".equals(activation) || !ordinaryAction);
        rows.add(row);
    }

    // A jelentés lapos sorait további JSON függőség nélkül sorosítja.
    String jsonValue(Object value) {
        if (value == null) return "null";
        if (value instanceof Number || value instanceof Boolean) return value.toString();
        StringBuilder escaped = new StringBuilder("\"");
        for (char character : value.toString().toCharArray()) {
            if (character == '"' || character == '\\') {
                escaped.append('\\').append(character);
            } else if (character < 0x20 || Character.isSurrogate(character)) {
                escaped.append(String.format("\\u%04x", (int) character));
            } else {
                escaped.append(character);
            }
        }
        return escaped.append('"').toString();
    }

    String toJson(List<Map<String, Object>> rows) {
        List<String> objects = new ArrayList<>();
        for (Map<String, Object> row : rows) {
            List<String> fields = new ArrayList<>();
            for (Map.Entry<String, Object> field : row.entrySet()) {
                fields.add("    " + jsonValue(field.getKey()) + ": " + jsonValue(field.getValue()));
            }
            objects.add("  {\n" + TextUtils.join(",\n", fields) + "\n  }");
        }
        return "[\n" + TextUtils.join(",\n", objects) + "\n]\n";
    }
}

boolean replaceExternalClicks = true;
String replacementUrl = "https://example.com/blocked-link";
HyperlinkAudit audit = new HyperlinkAudit();
Presentation presentation = new Presentation("hyperlink-audit-input.pptx");
try {
    List<IHyperlinkContainer> containers = audit.collectContainers(presentation);
    List<Map<String, Object>> rows = new ArrayList<>();
    for (int index = 0; index < containers.size(); index++) {
        IHyperlinkContainer container = containers.get(index);
        audit.addRow(rows, presentation, container.getHyperlinkClick(), "click", container, index + 1);
        audit.addRow(rows, presentation, container.getHyperlinkMouseOver(), "mouse-over", container, index + 1);
    }
    String json = audit.toJson(rows);
    byte[] jsonData = json.getBytes(StandardCharsets.UTF_8);
    try (FileOutputStream reportStream = new FileOutputStream("hyperlink-audit.json")) {
        reportStream.write(jsonData);
    }

    for (IHyperlinkContainer container : containers) {
        IHyperlink click = container.getHyperlinkClick();
        if (audit.policyViolation(click) != null) {
            if (replaceExternalClicks && click.getActionType() == HyperlinkActionType.Hyperlink) {
                container.getHyperlinkManager().setExternalHyperlinkClick(replacementUrl);
            } else {
                container.getHyperlinkManager().removeHyperlinkClick();
            }
        }
        if (audit.policyViolation(container.getHyperlinkMouseOver()) != null) {
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
    }
    presentation.save("hyperlink-sanitized.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("hyperlink-sanitized.pptx");
    try {
        List<IHyperlinkContainer> remainingContainers = audit.collectContainers(reopened);
        int violations = 0;
        for (IHyperlinkContainer container : remainingContainers) {
            if (audit.policyViolation(container.getHyperlinkClick()) != null) violations++;
            if (audit.policyViolation(container.getHyperlinkMouseOver()) != null) violations++;
        }
        System.out.println("Audit rows: " + rows.size() + "; prohibited actions after reopening: " + violations);
        if (violations != 0) {
            System.out.println("Verification failed: do not distribute the saved presentation.");
        }
    } finally {
        reopened.dispose();
    }
} catch (IOException exception) {
    System.out.println("Unable to write the audit report: " + exception.getMessage());
} finally {
    presentation.dispose();
}
```

A fenti bemenet alapján a jelentés öt műveleti sort tartalmaz. A fájl‑egér‑felette link és a makró‑kattintás eltávolításra kerül, míg a HTTPS‑linkek és a belső dia‑navigáció megmarad. Az ellenőrzés nulla tiltott műveletet jelez. Egy tiltott külső kattintási URL‑t tartalmazó bemenet a helyettesítő ágat is aktiválja. Egy engedélyezett kattintással és tiltott egér‑felette művelettel rendelkező konténer megtartja a kattintási műveletet.

Ez a szelektív tisztítás különbözik a [removeAllHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) módszertől, amely a kiválasztott hatókörben mindkét aktiválási típust eltávolítja, függetlenül a szabálytól. Az ellenőrzés itt csak a hiperhivatkozás‑műveleteket vizsgálja; nem távolítja el a beágyazott VBA‑projket, OLE‑objektumokat vagy egyéb aktív tartalmakat, és nem ellenőrzi a kiexportált PDF‑ vagy HTML‑fájlokat.

## **GYIK**

**Hogyan hozhatok létre hivatkozást egy szakaszra vagy annak első diájára?**

A PowerPointban a szakaszok a diák csoportosítására szolgálnak, de egy belső hiperhivatkozás egy adott diára mutat. A szakaszra való navigációhoz hivatkozzon a szakasz első diájára.

**Hozzá tudok-e rendelni hiperhivatkozást a mesterdia elemeihez, hogy minden dián működjön?**

Igen. A mesterdia- és elrendezés‑elemek támogatják a hiperhivatkozásokat. Ezeken az elemeken lévő linkek a diavetítés során elérhetők azokra a diákra, amelyek a megfelelő mestert vagy elrendezést használják.

**Megmaradnak‑e a hiperhivatkozások PDF, HTML, kép vagy videó exportálásakor?**

A támogatott PDF‑ és HTML‑exportok megőrizhetik a hiperhivatkozásokat; a raszteres képek és a videók nem. Lásd a [Hiperhivatkozások jelentése, szanitizálása és ellenőrzése](#report-sanitize-and-verify-hyperlinks) részt az exportálással kapcsolatos megfontolásokról.