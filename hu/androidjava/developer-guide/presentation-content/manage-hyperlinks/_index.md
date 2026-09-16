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

Egy hiperhivatkozás összeköti a prezentáció tartalmát egy weboldallal vagy a prezentáción belüli helyszínnel. A PowerPointban a hiperhivatkozások általában két célt szolgálnak:

* Weboldal megnyitása szövegből, alakzatból vagy média keretből.
* Navigálás egy másik diára, például a tartalomjegyzékből.

Az Aspose.Slides for Android via Java lehetővé teszi ezen hivatkozások hozzáadását, megjelenésük és hangjuk szabályozását, tulajdonságaik frissítését, valamint eltávolításukat. Az alábbi példák bemutatják, hogyan dolgozhatunk hiperhivatkozásokkal egyedi elemekkel, illetve hogyan érhetjük el a hiperhivatkozásokat a prezentáció, dia vagy szövegkeret szinten.

{{% alert color="info" title="Megjegyzés" %}}

A prezentációkat a [ingyenes online Aspose PowerPoint szerkesztővel](https://products.aspose.app/slides/hu/editor) is szerkesztheti.

{{% /alert %}} 

## **URL‑hiperhivatkozások hozzáadása**

Weboldal URL‑jét hozzárendelheti szöveghez, alakzathoz vagy média kerethez. Az a elem, amelyhez a hiperhivatkozást rendeli, meghatározza a kattintható területet: egy szövegrészlet az adott szövegre, míg egy alakzat vagy keret a diára helyezett objektumra hivatkozik.

### **URL‑hiperhivatkozások hozzáadása szöveghez**

A szöveget weboldalra mutató hivatkozással kell ellátni, ehhez adjon át egy [Hyperlink](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/hyperlink/) objektumot a szövegrészlet [setHyperlinkClick](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/portionformat/#setHyperlinkClick-com.aspose.slides.IHyperlink-) metódusának, ahogy az alább látható. Csak ez a szövegrészlet lesz kattintható.

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

### **URL‑hiperhivatkozások hozzáadása alakzatokhoz és média keretekhez**

A kattintható alakzat vagy keret létrehozásához hívja meg annak [setHyperlinkClick](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/shape/#setHyperlinkClick-com.aspose.slides.IHyperlink-) metódusát. A hiperhivatkozás az objektumhoz tartozik, nem egy benne levő szövegrésszel.

Ugyanez a megközelítés vonatkozik kép, hang és videó keretekre: a hivatkozást a kerethez rendeli, és szükség esetén meghívja a [setTooltip](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) metódust.

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

A belső hiperhivatkozások lehetővé teszik az olvasók számára, hogy egy tartalomjegyzékből egy adott diára ugorjanak. Az alábbi példa a [setInternalHyperlinkClick](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ihyperlinkmanager/#setInternalHyperlinkClick-com.aspose.slides.ISlide-) metódust használja, hogy az első dia „2. oldal” szövegét a második diára irányítsa.

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

Az [IHyperlink](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ihyperlink/) [setColorSource](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ihyperlink/#setColorSource-int-) metódusa határozza meg, hogy a hiperhivatkozás a prezentáció hiperhivatkozás‑színét vagy a szövegrészlet formázását használja. Egyéni szövegszín alkalmazásához válassza a [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/hyperlinkcolorsource/) értéket, és állítsa be a részlet kitöltőszínét. Ez a funkció a PowerPoint 2019‑ben került bevezetésre; régebbi verziók nem alkalmazzák ezt a beállítást.

Az alábbi példa két szöveges hiperhivatkozást ad ugyanarra a diára. Az első piros szöveggel, a második az alapértelmezett hiperhivatkozás‑színnel jelenik meg.

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

A hiperhivatkozás aktiváláskor hangot játszhat le, vagy megállíthat egy már lejátszott hangot. A következő metódusokkal konfigurálhatja ezeket a viselkedéseket:

- [IHyperlink.setSound](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ihyperlink/#setSound-com.aspose.slides.IAudio-) adja meg a hiperhivatkozáshoz tartozó audiót.
- [IHyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ihyperlink/#setStopSoundOnClick-boolean-) határozza meg, hogy a hiperhivatkozás aktiválása leállítsa‑e az előző hangot.

#### **Hiperhivatkozás‑hang hozzáadása**

Az alábbi példa betölti a `sampleaudio.wav` fájlt, és hozzárendeli az első dia egy gombjához. A gombra kattintva a hang lejátszódik, majd a következő diára navigál. Egy másik alakzat ugyanazon a dián a kattintáskor leállítja az előző hangot, anélkül hogy navigációt végezne.

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

#### **Hiperhivatkozás‑hang kinyerése**

Az alábbi példa megnyitja a fent létrehozott prezentációt, és a [getSound](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ihyperlink/#getSound--) valamint a [getBinaryData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iaudio/#getBinaryData--) segítségével memóriába olvassa az első alakzat hiperhivatkozás‑audióját.

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

### **Buborék és interakció beállítások**

A hiperhivatkozás szöveghez vagy alakzathoz rendelése után a következő [IHyperlink](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ihyperlink/) metódusokat hívhatja meg:

- [setTooltip](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) állítja be a felhasználó számára megjelenő tippet.
- [setTargetFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ihyperlink/#setTargetFrame-java.lang.String-) adja meg a célkeretet egy szülő HTML framesetben, ha releváns.
- [setHistory](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ihyperlink/#setHistory-boolean-) szabályozza, hogy a hivatkozás aktiválása felvegye‑e a célját a megtekintett hiperhivatkozások listájába.
- [setHighlightClick](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ihyperlink/#setHighlightClick-boolean-) meghatározza, hogy a hiperhivatkozás kattintáskor ki legyen‑e emelve.

## **Hiperhivatkozások eltávolítása a prezentációkból**

A [getAnyHyperlinks](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) segítségével gyűjtheti össze a hiperhivatkozás‑konténereket, beleértve a szövegrész‑hivatkozásokat is, mielőtt módosítaná őket. Az alábbi példa mindkét aktiválási típust eltávolítja az első diáról. Ha csak egy típust kíván eltávolítani, hívja meg a [removeHyperlinkClick](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) vagy a [removeHyperlinkMouseOver](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--) metódust; egy kattintási művelet eltávolítása nem vonja el a rámutatási (mouse‑over) változatot.

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

Feltétlen eltávolításhoz a [removeAllHyperlinks](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) egy hívásban mindkét aktiválási típust eltávolítja a kijelölt tartományban. A mester‑, elrendezés‑ és jegyzet‑szintű selektív takarításhoz és lefedettséghez tekintse meg a [Jelentés, tisztítás és hiperhivatkozások ellenőrzése](#report-sanitize-and-verify-hyperlinks) részt.

## **Teljes hiperhivatkozás‑leltár felépítése**

A prezentáció közzététele előtt készítsen leltárt az interaktív műveletekről és a webes hivatkozásokról. A [getAnyHyperlinks](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) [IHyperlinkContainer](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ihyperlinkcontainer/) objektumokat ad vissza, nem egy egyszerű URL‑lista. Minden konténeren vizsgálja meg a [getHyperlinkClick](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) és a [getHyperlinkMouseOver](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) értékeket. Ezek egymástól függetlenek: ugyanazon konténer mindkét akciót tartalmazhatja, ezért egy teljes jelentéshez akár két sort is szükség lehet konténerenként.

Csak alakzatszintű hiperhivatkozások beolvasása kihagyhatja a szövegrészekhez csatolt linkeket. Használja a megfelelő tartomány‑lekérdezést, és őrizze meg a visszakapott konténereket a későbbi frissítéshez vagy eltávolításhoz.

### **Prezentáció, dia és szövegkeret tartományok lekérdezése**

Az [IHyperlinkQueries](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ihyperlinkqueries/) interfész a következő útvonalakon érhető el: [IPresentation.getHyperlinkQueries](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentation/#getHyperlinkQueries--), [IBaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibaseslide/#getHyperlinkQueries--), és [ITextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/#getHyperlinkQueries--). Minden tartomány ugyanazokat a lekérdezéseket támogatja:

- [getHyperlinkClicks](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkClicks--) visszaadja a kattintási akcióval rendelkező konténereket.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkMouseOvers--) visszaadja a rámutatási akcióval rendelkező konténereket.
- [getAnyHyperlinks](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) visszaadja a bármelyik vagy mindkét akcióval rendelkező konténereket.

Az alábbi példa létrehozza a `hyperlink-audit-input.pptx` fájlt egy külső kattintási linkgel, egy fájl rámutatási linkkel, belső dia‑navigációval, egy szövegrésszel történő rámutatással és egy makró­akcióval. A példában egyik akció sem hajtódik végre. Ugyanaz a három lekérdezés minden tartományban működik; a számlálók konténereket adnak vissza, nem az akciók összegét. A szövegkeret‑tartomány kizárja a befoglaló alakzat saját linkjeit.

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

Ebben a példában a prezentáció‑ és dia‑lekérdezések három kattintási, két rámutatási és három vegyes konténert jelentenek. A szövegkeret‑lekérdezés egy konténert ad vissza minden kategóriában.

### **Akciók és célok osztályozása**

Az [IHyperlink.getActionType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ihyperlink/#getActionType--) segítségével értelmezze az akciót, mielőtt a célra fókuszálna. A [HyperlinkActionType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/hyperlinkactiontype/) értékek a webes navigáción túl is kiterjednek:

| Értékek | Jelentés audit során |
| --- | --- |
| `Hyperlink` | Külső hiperhivatkozás; vizsgálja meg az URL‑t és annak sémáját. |
| `JumpSpecificSlide` | Belső navigáció egy meghatározott diára. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Beépített diavetítés‑navigáció, a diavetítés kontextusában értelmezve. |
| `JumpEndShow`, `StartCustomSlideShow` | Az aktuális bemutató befejezése vagy egy egyedi bemutató indítása. |
| `StartMacro` | Makró végrehajtása. |
| `StartProgram` | Program indítása. |
| `OpenFile`, `OpenPresentation` | Fájl vagy másik prezentáció megnyitása; külön ellenőrizze a webes URL‑ktől. |
| `StartStopMedia` | Média lejátszásának indítása vagy leállítása. |
| `NoAction`, `Unknown` | Nincs navigációs akció, vagy ismeretlen akció, amely felülvizsgálatot igényel. |

Külső célokat a [getExternalUrl](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ihyperlink/#getExternalUrl--) adja vissza, a belső célokat a [getTargetSlide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ihyperlink/#getTargetSlide--) adja meg. Belső akciók és beépített parancsok esetén előfordulhat, hogy nincs külső URL; egy üres URL nem jelenti azt, hogy a konténernek nincs akciója. Amikor a [getExternalUrlOriginal](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) eredménye eltér a normalizált URL‑től, őrizze meg az eredetit, és adja meg a [getTooltip](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ihyperlink/#getTooltip--) által visszaadott buborék‑szöveget, ha elérhető.

### **Hiperhivatkozások jelentése, tisztítása és ellenőrzése**

Az alábbi Java‑példa beolvas egy meglévő prezentációt (használja a fenti fájlt), írja a `hyperlink-audit.json` fájlt, egy szabályt alkalmaz, elmenti a `hyperlink-sanitized.pptx` fájlt, majd újra megnyitja, hogy újra ellenőrizze mindkét aktiválási típust. A konténereket a módosítás előtt gyűjti, és referenciákat használ, hogy ne dolgozza fel ugyanazt a konténert kétszer. A prezentáció‑lekérdezések a szokásos diákat fedik le; a csomag‑szintű leltárhoz kifejezetten a mester‑, elrendezés‑, jegyzet‑ és a jegyzet‑/osztópáros mester‑elemeket is lekérdezi, ha jelen vannak.

A jelentés egy 1‑től számozott diát és a [getSlideId](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibaseslide/#getSlideId--) értékét rögzíti, ha elérhető. Az [ISlideComponent.getSlide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islidecomponent/#getSlide--) a támogatott konténerekhez a tulajdonos diát adja vissza. A mesterek, elrendezések és jegyzetek nem rendelkeznek szokásos dia‑indexszel, ezért a tartományuk szerint azonosítjuk őket. Az alakzat‑konténereket és a szövegrész‑formázási konténereket külön jelöli; más konténer‑típusok a futási típusként kapják nevüket. Minden konténer kap egy jelentés‑helyi azonosítót, hogy a két akcióját összekapcsolhassa. A jelentés az akciótípusokat a Java‑enumeráció egész‑konstansaként tárolja.

Ez a szándékosan szigorú alkalmazási szabály csak abszolút HTTPS‑URL‑eket és érvényes belső diacélokat engedélyez. Tiltja a makrókat, programokat, fájl‑akciókat, egyéb diavetítési akciókat, ismeretlen akciókat és egyéb URL‑sémákat. Ezek a tiltások szabályozási döntések, nem az Aspose.Slides biztonsági megítélése. A HTTPS önmagában nem garantál megbízhatóságot: adjon hozzá host‑engedélylistákat és egyéb ellenőrzéseket az alkalmazásához. Mind az eredeti, mind a normalizált külső URL‑ket ellenőrzi a rendszer. A példa metaadat‑auditot végez a linkek követése vagy akciók futtatása nélkül.

Javításhoz a konténer [getHyperlinkManager](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) támogatja a [setExternalHyperlinkClick](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-), a [removeHyperlinkClick](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) és a [removeHyperlinkMouseOver](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--) metódusokat. Itt a tiltott külső kattintási hivatkozásokat egy rögzített HTTPS landoló oldalra cserélik; a többi tiltott kattintást és rámutatást külön‑külön eltávolítják. Állítsa a `replaceExternalClicks` értékét `false`‑ra, hogy minden szabálysértést eltávolítson. Válasszon egy alkalmazás‑tulajdonú helyettesítő oldalt a telepítés előtt.

A jelentés export‑jelzője egy konzervatív PDF‑ellenőrzési szabályt alkalmaz: jelöli a rámutatási akciókat és minden – egy külső hivatkozás vagy egyedi dia‑ugrás kivételével – potenciálisan nem támogatott elemet. Ez csak egy felülvizsgálati tipp, nem egy képesség‑teszt vagy garancia arra, hogy a jelöletlen linkek megmaradnak az exportálás során. A támogatott [PDF](/slides/hu/androidjava/convert-powerpoint-to-pdf/) és [HTML](/slides/hu/androidjava/convert-powerpoint-to-html/) exportok megőrizhetik a hiperhivatkozásokat, az akciótól, export‑opcióktól és a megjelenítőtől függően. A raszteres [képek](/slides/hu/androidjava/convert-powerpoint-to-png/) és [videók](/slides/hu/androidjava/convert-powerpoint-to-video/) nem tudják megőrizni az interaktív hiperhivatkozásokat; ezért az ilyen kimenetek auditálásakor minden akciót jelölje.

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

    // A jelentés lapos sorainak sorosítása további JSON függőség nélkül.
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

A fenti bemenettel a jelentés öt akciósort tartalmaz. A fájl‑rámutatási link és a makró‑kattintás eltávolításra kerül, míg a HTTPS‑linkek és a belső dia‑navigáció megmarad. Az ellenőrzés nulla tiltott akciót jelez. Egy tiltott külső kattintási URL‑t tartalmazó bemenet a cserélési ágat is demonstrálja. Egy engedélyezett kattintással, tiltott rámutatással rendelkező konténer megtartja a kattintási akciót.

Ez a szelektív tisztítás különbözik a [removeAllHyperlinks](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) módszertől, amely a kiválasztott tartományban mindkét aktiválási típust eltávolítja a szabályoktól függetlenül. Az itt végzett ellenőrzés csak a hiperhivatkozás‑akciókat vizsgálja; nem távolít el beágyazott VBA‑projekteket, OLE‑objektumokat vagy egyéb aktív tartalmakat, és nem validálja az exportált PDF‑ vagy HTML‑fájlokat.

## **GYIK**

**Hogyan linkelhetek egy szekcióra vagy annak első diájára?**

A PowerPoint szekciók a diákat csoportosítják, de egy belső hiperhivatkozás egyedi diát céloz meg. Egy szekcióra való navigáció létrehozásához linkelje az adott szekció első diáját.

**Hozzáadhatok‑e hiperhivatkozást a mester dia elemeihez, hogy minden dián működjön?**

Igen. A mester dia és az elrendezés elemei támogatják a hiperhivatkozásokat. Ezek a linkek a diavetítés során elérhetők azon diákon, amelyek a megfelelő mestert vagy elrendezést használják.

**Megmaradnak‑e a hiperhivatkozások PDF, HTML, képek vagy videó exportálásakor?**

A támogatott PDF és HTML exportok megőrizhetik a hiperhivatkozásokat; a raszteres képek és videók nem. Tekintse meg a [Jelentés, tisztítás és hiperhivatkozások ellenőrzése](#report-sanitize-and-verify-hyperlinks) részben leírt exporti szempontokat.