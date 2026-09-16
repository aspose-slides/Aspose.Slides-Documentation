---
title: Prezentációs hiperhivatkozások kezelése Java-ban
linktitle: Hiperhivatkozások kezelése
type: docs
weight: 20
url: /hu/java/manage-hyperlinks/
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
- Java
- Aspose.Slides
description: "Hiperhivatkozások hozzáadása, formázása, frissítése és eltávolítása PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Java segítségével, Java példákkal."
---
## **Bevezetés**

A hiperhivatkozás összeköti a bemutató tartalmát egy weboldallal vagy a bemutatón belüli helyszínnel. PowerPointban a hiperhivatkozások általában két célra szolgálnak:

* Egy weboldal megnyitása szövegből, alakzatból vagy média‑keretből.
* Navigálás egy másik dia felé, például egy tartalomjegyzékből.

Az Aspose.Slides for Java lehetővé teszi ezen hivatkozások hozzáadását, megjelenésük és hangjuk szabályozását, tulajdonságaik frissítését, valamint eltávolításukat. Az alábbi példák bemutatják, hogyan dolgozhatunk hiperhivatkozásokkal egyedi elemeknél, illetve hogyan érhetjük el a hiperhivatkozásokat a bemutató, dia vagy szöveg‑keret szintjén.

{{% alert color="info" title="Note" %}}

Szerkesztheti a bemutatókat a [ingyenes online Aspose PowerPoint szerkesztővel](https://products.aspose.app/slides/hu/editor).

{{% /alert %}} 

## **URL hiperhivatkozások hozzáadása**

Kijelölhet egy webcím‑URL‑t szövegre, alakzatra vagy média‑keretre. Az a elem, amelyhez a hiperhivatkozást hozzárendeli, meghatározza a kattintható területet: egy szövegrész a kijelölt szöveget linkeli, míg egy alakzat vagy keret a diaobjektumot.

### **URL hiperhivatkozások hozzáadása szöveghez**

A szöveg weboldalra történő hivatkozásához adjon át egy [Hyperlink](https://reference.aspose.com/slides/hu/java/com.aspose.slides/hyperlink/) objektumot a szövegrész [setHyperlinkClick](https://reference.aspose.com/slides/hu/java/com.aspose.slides/portionformat/#setHyperlinkClick-com.aspose.slides.IHyperlink-) metódusának, ahogy az alább látható. Csak ez a szövegrész lesz kattintható.

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

### **URL hiperhivatkozások hozzáadása alakzatokhoz és média‑keretekhez**

Az alakzat vagy keret kattinthatóvá tételéhez hívja meg annak [setHyperlinkClick](https://reference.aspose.com/slides/hu/java/com.aspose.slides/shape/#setHyperlinkClick-com.aspose.slides.IHyperlink-) metódusát. A hiperhivatkozás az objektumhoz tartozik, nem egy benne lévő szövegrészhez.

Ugyanez a megközelítés érvényes kép, hang és videó keretekre is: rendelje hozzá a hiperhivatkozást a kerethez, és szükség esetén hívja meg a [setTooltip](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) metódust.

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

A belső hiperhivatkozások lehetővé teszik az olvasó számára, hogy a tartalomjegyzékből egy konkrét diára ugorjon. Az alábbi példa a [setInternalHyperlinkClick](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ihyperlinkmanager/#setInternalHyperlinkClick-com.aspose.slides.ISlide-) metódust használja, hogy az első dia „2. oldal” szövegét a második dia‑linkkel lássa el.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

Az [IHyperlink](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ihyperlink/) [setColorSource](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ihyperlink/#setColorSource-int-) metódusa határozza meg, hogy a hiperhivatkozás a bemutató hiperhivatkozás‑színét vagy a szövegrész formázását használja-e. Egyedi szövegszín alkalmazásához válassza a [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/hyperlinkcolorsource/) értéket, és állítsa be a rész kitöltőszínét. Ez a funkció a PowerPoint 2019‑ben került bevezetésre; régebbi verziók nem alkalmazzák ezt a beállítást.

Az alábbi példában két szöveges hiperhivatkozás kerül ugyanarra a diára. Az első piros kitöltéssel, a második az alapértelmezett hiperhivatkozás‑színnel rendelkezik.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

A hiperhivatkozás aktiváláskor lejátszhat egy hangot, vagy leállíthat egy már folyamatban lévő hangot. Az alábbi metódusokkal állíthatja be ezeket a viselkedéseket:

- [IHyperlink.setSound](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ihyperlink/#setSound-com.aspose.slides.IAudio-) adja meg a hiperhivatkozáshoz rendelt audiót.
- [IHyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ihyperlink/#setStopSoundOnClick-boolean-) szabályozza, hogy a hiperhivatkozás aktiválásakor leálljon‑e az előző hang.

#### **Hiperhivatkozás‑hang hozzáadása**

Az alábbi példa betölti a `sampleaudio.wav` fájlt, és egy gombhoz rendeli az első dián. A gomb megnyomása lejátssza a hangot és a következő diára navigál. Egy másik alakzat ugyanazon a dián a kattintáskor leállítja az előző hangot, anélkül, hogy navigációt végezne.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] audioData = Files.readAllBytes(Paths.get("sampleaudio.wav"));
    IAudio hyperlinkSound = presentation.getAudios().addAudio(audioData);

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

#### **Hiperhivatkozás‑hang kinyerése**

Az alábbi példa megnyitja a fent létrehozott bemutatót, és a [getSound](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ihyperlink/#getSound--) valamint a [getBinaryData](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iaudio/#getBinaryData--) metódusok segítségével a memóriaba tölti az első alakzat hiperhivatkozás‑audióját.

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

A szöveghez vagy alakzathoz hiperhivatkozást rendelve a következő [IHyperlink](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ihyperlink/) metódusok hívhatók meg:

- [setTooltip](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) állít be egy szöveget, amelyet a néző a hivatkozás tippeként láthat.
- [setTargetFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ihyperlink/#setTargetFrame-java.lang.String-) adja meg a célkeretet egy szülő HTML‑framesetben, ha releváns.
- [setHistory](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ihyperlink/#setHistory-boolean-) szabályozza, hogy a hivatkozás aktiválása felvegye‑e a célját a megtekintett hiperhivatkozások listájába.
- [setHighlightClick](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ihyperlink/#setHighlightClick-boolean-) szabályozza, hogy a hiperhivatkozás kattintáskor ki legyen‑e emelve.

## **Hiperhivatkozások eltávolítása a bemutatóból**

A [getAnyHyperlinks](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) metódus használatával gyűjthetőek a hiperhivatkozás‑konténerek, beleértve a szövegrész‑linkeket is, mielőtt módosítaná őket. Az alábbi példa mindkét aktiválási típust eltávolítja az első diáról. Egy adott típus eltávolításához csak a [removeHyperlinkClick](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) vagy a [removeHyperlinkMouseOver](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--) metódust hívja; egy kattintási akció eltávolítása nem vonja el a mouse‑over párt.

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

Feltétel nélküli eltávolításhoz a [removeAllHyperlinks](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) mindkét aktiválási típust egy hívással törli a kiválasztott hatókörben. Kiválasztott takarításról és a mester‑, elrendezés‑ és jegyzet‑szintek lefedettségéről lásd a [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) részt.

## **Teljes hiperhivatkozás‑leltár összeállítása**

Mielőtt közzétenne egy bemutatót, készítsen leltárt az interaktív műveletekről és a webes linkekről is. A [getAnyHyperlinks](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) [IHyperlinkContainer](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ihyperlinkcontainer/) objektumokat ad vissza, nem egyszerű URL‑listát. Vizsgálja meg mind a [getHyperlinkClick](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) , mind a [getHyperlinkMouseOver](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) metódusokat minden konténeren. Ezek függetlenek: egy konténer mindkét műveletet is tartalmazhat, ezért egy teljes jelentés akár két sort is igényelhet konténerenként.

Csak alakzatszintű hiperhivatkozások keresése kihagyhatja a szövegrész‑linkeket. Kérdezze le a megfelelő hatókört, és tartsa meg a visszakapott konténereket a későbbi frissítéshez vagy eltávolításhoz.

### **Bemutató, dia és szöveg‑keret hatókörök lekérdezése**

Az [IHyperlinkQueries](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ihyperlinkqueries/) interfész elérhető a [IPresentation.getHyperlinkQueries](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentation/#getHyperlinkQueries--), az [IBaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibaseslide/#getHyperlinkQueries--) és az [ITextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/#getHyperlinkQueries--) metódusokon keresztül. Minden hatókör ugyanazokat a lekérdezéseket támogatja:

- [getHyperlinkClicks](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ihyperlinkqueries/#getHyperlinkClicks--) konténereket ad vissza kattintási művelettel.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ihyperlinkqueries/#getHyperlinkMouseOvers--) konténereket ad vissza mouse‑over művelettel.
- [getAnyHyperlinks](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) konténereket ad vissza bármely, vagy mindkét művelettel.

Az alábbi példa létrehozza a `hyperlink-audit-input.pptx`‑et egy külső kattintási linkgel, egy fájl‑mouse‑over linkgel, belső dia‑navigációval, egy szöveg‑mouse‑over linkgel és egy makró‑művelettel. A példák nem hajtják végre ezeket a műveleteket. A három lekérdezés minden hatókörben ugyanúgy működik; a számlálók konténereket, nem műveleteket adnak vissza. A szöveg‑keret hatókör kizárja a körülvevő alakzat saját linkjeit.

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

A példában a bemutató‑ és dia‑lekérdezések három kattintási, két mouse‑over és három vegyes konténert adnak vissza. A szöveg‑keret lekérdezés minden kategóriában egy konténert jelent.

### **Műveletek és célpontok osztályozása**

Használja az [IHyperlink.getActionType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ihyperlink/#getActionType--) metódust a művelet értelmezéséhez, mielőtt a célpontot vizsgálná. A [HyperlinkActionType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/hyperlinkactiontype/) értékek a webes navigáción túl is kiterjednek:

| Értékek | Jelentés auditáláskor |
| --- | --- |
| `Hyperlink` | Külső hiperhivatkozás; vizsgálja meg az URL‑t és séma‑ját. |
| `JumpSpecificSlide` | Belső navigáció egy adott dia felé. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Beépített diavetítés‑navigáció, a diavetítés kontextusában értelmezve. |
| `JumpEndShow`, `StartCustomSlideShow` | Az aktuális show befejezése vagy egy egyedi show indítása. |
| `StartMacro` | Makró végrehajtása. |
| `StartProgram` | Program indítása. |
| `OpenFile`, `OpenPresentation` | Fájl vagy más bemutató megnyitása; külön kell ellenőrizni a webes URL‑ktől. |
| `StartStopMedia` | Média lejátszás indítása vagy leállítása. |
| `NoAction`, `Unknown` | Nincs navigációs művelet, vagy ismeretlen művelet, amely felülvizsgálatot igényel. |

A külső célpontokat a [getExternalUrl](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ihyperlink/#getExternalUrl--) metódussal, a belső célpontokat a [getTargetSlide](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ihyperlink/#getTargetSlide--) metódussal olvashatja. Belső műveletek és beépített parancsok esetén lehet, hogy nincs külső URL; egy üres URL nem jelenti azt, hogy a konténernek nincs művelete. Amikor a [getExternalUrlOriginal](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) értéke eltér a normalizált URL‑től, őrizze meg az eredetit, és adja hozzá a [getTooltip](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ihyperlink/#getTooltip--) által visszaadott buborékszöveget, ha elérhető.

### **Hiperhivatkozások jelentése, tisztítása és ellenőrzése**

Az alábbi Java‑példa beolvas egy meglévő bemutatót (használja a fent létrehozott fájlt), kiírja a `hyperlink-audit.json`‑t, egy szabályt alkalmaz, elmenti a `hyperlink-sanitized.pptx`‑et, majd újra megnyitja, hogy újból ellenőrizze a két aktiválási típust. A konténereket a módosítás előtt gyűjti, és referenciális egyenlőséget használ, hogy ne dolgozza fel ugyanazt a konténert kétszer. A bemutató‑lekérdezések a szokásos diákra vonatkoznak; a csomag‑szintű leltárhoz explicit módon lekérdezi a master‑, elrendezés‑, jegyzet‑ és a jegyzet‑ és kinyomtatási master‑eket, ha léteznek.

A jelentés egy egy‑alapú diaindexet és a [getSlideId](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibaseslide/#getSlideId--) értéket rögzíti, ha elérhető. A [ISlideComponent.getSlide](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islidecomponent/#getSlide--) biztosítja a szülődiát a támogatott konténerekhez. Master‑, elrendezés‑ és jegyzet‑elemeknek nincs szokásos diaindexük, ezért a hatókörük alapján azonosítjuk őket. Az alakzat‑konténereket és a szövegrész‑formázási konténereket külön jelöljük; egyéb konténer‑típusok megtartják futási típusképüket. Minden konténer kap egy jelentés‑helyi azonosítót, hogy a két művelet összerendelhető legyen. A jelentés a művelettípusokat a Java‑enumeráció egész‑konstansaként tárolja.

Ez a szándékosan szigorú alkalmazási szabály csak abszolút HTTPS URL‑ket és érvényes belső dia‑célpontokat engedélyez. Elutasítja a makrókat, programokat, fájl‑műveleteket, egyéb diavetítés‑műveleteket, ismeretlen műveleteket és egyéb URL‑sémákat. Ezek a visszautasítások szabályzat‑döntések, nem az Aspose.Slides biztonsági megállapítása. Az HTTPS önmagában nem ad garanciát: adjon hozzá host‑engedélylistákat és egyéb ellenőrzéseket az alkalmazásához. Mind az eredeti, mind a normalizált külső URL‑ket ellenőrzi a rendszer. A példa metaadatokat auditál, anélkül, hogy követné a linkeket vagy végrehajtaná a műveleteket.

Javításhoz a konténer [getHyperlinkManager](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) támogatja a [setExternalHyperlinkClick](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-), a [removeHyperlinkClick](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) és a [removeHyperlinkMouseOver](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--) metódusokat. Itt a tiltott külső kattintási linkek egy fix HTTPS landoló oldalra cserélődnek; a többi tiltott kattintás és mouse‑over művelet önállóan eltávolításra kerül. Állítsa a `replaceExternalClicks` értékét `false`‑ra, ha minden szabálysértést el szeretne távolítani. Válasszon egy alkalmazás‑tulajdonú csereoldalt a telepítés előtt.

A jelentés export‑zászlója egy konzervatív PDF‑ellenőrzési szabályt alkalmaz: jelöli a mouse‑over műveleteket és bármit, ami nem külső link vagy konkrét dia‑ugrás, potenciálisan nem támogatottként. Ez egy ellenőrzési utalás, nem egy képesség‑teszt vagy garancia, hogy a jelöletlen linkek megmaradnak az exportálás során. A támogatott [PDF](/slides/hu/java/convert-powerpoint-to-pdf/) és [HTML](/slides/hu/java/convert-powerpoint-to-html/) exportok megőrizhetik a hiperhivatkozásokat, a művelettől, az export‑opcióktól és a megjelenítőtől függően. A raster [images](/slides/hu/java/convert-powerpoint-to-png/) és [video](/slides/hu/java/convert-powerpoint-to-video/) nem képes megőrizni az interaktív hiperhivatkozásokat; ezért auditáláskor minden ilyen műveletet jelöljen.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.net.URI;
import java.net.URISyntaxException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;
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

    // Sorozza ezt a jelentés lapos sorait további JSON függőség nélkül.
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
            objects.add("  {\n" + String.join(",\n", fields) + "\n  }");
        }
        return "[\n" + String.join(",\n", objects) + "\n]\n";
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
    Files.write(Paths.get("hyperlink-audit.json"), jsonData);

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

A fenti bemenet alapján a jelentés öt műveleti sort tartalmaz. A fájl‑mouse‑over link és a makró‑kattintás eltávolításra kerül, míg a HTTPS linkek és a belső dia‑navigáció megmarad. Az ellenőrzés nulla tiltott műveletet jelez. Egy tiltott külső kattintási URL‑t tartalmazó bemenet a csere‑ágat is lefutassa. Egy engedélyezett kattintással, de tiltott mouse‑overrel rendelkező konténer megtartja a kattintási műveletet.

Ez a szelektív takarítás különbözik a [removeAllHyperlinks](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) módszertől, amely a kiválasztott hatókörben mindkét aktiválási típust eltávolítja a szabályzat függetlenül. Az itt végzett ellenőrzés csak a hiperhivatkozás‑műveleteket vizsgálja; nem távolítja el a beágyazott VBA‑projket, OLE‑objektumokat vagy egyéb aktív tartalmakat, és nem ellenőrzi a exportált PDF‑ vagy HTML‑fájlokat.

## **GYIK**

**Hogyan linkelhetek egy szekcióra vagy annak első diájára?**

A PowerPointban a szekciók diák csoportjai, de egy belső hiperhivatkozás egy adott diát céloz meg. Egy szekcióra mutató navigáció létrehozásához linkelje a szekció első diáját.

**Csatolhatok-e hiperhivatkozást a master‑dia elemeihez, hogy minden dián működjön?**

Igen. A master‑dia és elrendezés elemei támogatják a hiperhivatkozásokat. Ezek a linkek a diavetítés során elérhetők minden olyan dián, amely a megfelelő master‑t vagy elrendezést használja.

**Megmaradnak-e a hiperhivatkozások PDF, HTML, képek vagy videó exportálásakor?**

A támogatott PDF és HTML exportok megőrizhetik a hiperhivatkozásokat; a raster képek és videók nem. Tekintse meg az export‑szempontokat a [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) részben.