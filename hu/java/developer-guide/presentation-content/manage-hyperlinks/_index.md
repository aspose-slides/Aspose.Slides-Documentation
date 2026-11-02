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
description: "Hiperhivatkozások hozzáadása, formázása, frissítése és eltávolítása PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Java használatával, Java példákkal."
---
## **Bevezetés**

A hiperhivatkozás összekapcsolja a bemutató tartalmát egy weboldallal vagy a bemutatón belüli helyszínnel. A PowerPoint-ban a hiperhivatkozások általában két célt szolgálnak:

* Weboldal megnyitása szövegből, alakzatból vagy médiakeretből.
* Navigálás egy másik diára, például egy tartalomjegyzékből.

Aspose.Slides for Java lehetővé teszi ezen hivatkozások hozzáadását, megjelenésük és hangjuk vezérlését, tulajdonságaik frissítését és eltávolítását. Az alábbi példák bemutatják, hogyan dolgozhatunk hiperhivatkozásokkal egyedi elemeknél, illetve hogyan érhetjük el a hiperhivatkozásokat a bemutató, dia vagy szövegkeret szintjén.

{{% alert color="info" title="Note" %}}
A bemutatókat szintén szerkesztheti az [ingyenes online Aspose PowerPoint szerkesztő](https://products.aspose.app/slides/editor).
{{% /alert %}} 

## **URL hiperhivatkozások hozzáadása**

Weboldal URL-t rendelhet szöveghez, alakzathoz vagy médiakerethez. Az a elem, amelyhez a hiperhivatkozást rendeli, meghatározza a kattintható területet: egy szövegrész a kiválasztott szöveget teszi linkké, míg egy alakzat vagy keret a diaobjektumot linkeli.

A relatív hiperhivatkozásokat tartalmazó bemutatók esetén tekintse meg a [Hyperlink alap kezelését](/slides/hu/java/presentation-properties/#manage-the-hyperlink-base), hogy elolvassa, módosítsa vagy törölje a dokumentumszintű alapot.

### **URL hiperhivatkozások hozzáadása szöveghez**

A szöveget egy weboldalra hivatkozáshoz adja át egy [Hyperlink](https://reference.aspose.com/slides/java/com.aspose.slides/hyperlink/) a szövegrész [setHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/portionformat/#setHyperlinkClick-com.aspose.slides.IHyperlink-) metódusnak, ahogy az alább látható. Csak az a szövegrész lesz kattintható.

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

### **URL hiperhivatkozások hozzáadása alakzatokhoz és médiakeretekhez**

Az alakzat vagy keret kattinthatóvá tételéhez hívja meg a [setHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setHyperlinkClick-com.aspose.slides.IHyperlink-) metódusát. A hiperhivatkozás az objektumhoz tartozik, nem a benne lévő szövegrészhez.

Ugyanez a megközelítés alkalmazható kép-, hang- és videókeretekre: rendelje a hiperhivatkozást a kerethez, és szükség esetén hívja meg a [setTooltip](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) metódust.

A következő példa egy téglalapot tesz kattinthatóvá:

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

A belső hiperhivatkozások lehetővé teszik az olvasók számára, hogy a tartalomjegyzékből egy meghatározott diára ugorjanak. A következő példa a [setInternalHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkmanager/#setInternalHyperlinkClick-com.aspose.slides.ISlide-) metódust használja, hogy az első dián lévő „2. oldal” szöveget a második diára linkelje.

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

Az [setColorSource](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setColorSource-int-) metódus a [IHyperlink](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/) esetében meghatározza, hogy a hiperhivatkozás a bemutató hiperhivatkozás színét vagy a szövegrész formázását használja-e. Egy egyedi szövegszín alkalmazásához válassza a [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/hyperlinkcolorsource/) lehetőséget, és állítsa be a rész kitöltőszínét. Ez a funkció a PowerPoint 2019‑ből érhető el; régebbi verziókban ez a beállítás nem érvényesül.

A következő példa két szöveges hiperhivatkozást ad ugyanarra a diára. Az első piros szövegtöltést használ, míg a második az alapértelmezett hiperhivatkozás színt tartja meg.

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

A hiperhivatkozás lejátszhat egy hangot aktiváláskor, vagy leállíthat egy már lejátszott hangot. Használja a következő metódusokat ezen viselkedések beállításához:

- [IHyperlink.setSound](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setSound-com.aspose.slides.IAudio-) megadja a hiperhivatkozáshoz társított hangot.
- [IHyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setStopSoundOnClick-boolean-) szabályozza, hogy a hiperhivatkozás aktiválása leállítsa-e az előző hangot.

#### **Hiperhivatkozás hangjának hozzáadása**

A következő példa betölti a `sampleaudio.wav` fájlt, és a első dián lévő gombhoz társítja. A gombra kattintva a hang lejátszódik, és a következő diára navigál. Az azon a dián lévő második alakzat kattintáskor leállítja az előző hangot, anélkül, hogy navigációs műveletet végezne.

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

#### **Hiperhivatkozás hangjának kinyerése**

A következő példa megnyitja a fent létrehozott bemutatót, és a [getSound](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getSound--) és a [getBinaryData](https://reference.aspose.com/slides/java/com.aspose.slides/iaudio/#getBinaryData--) segítségével beolvassa az első alakzat hiperhivatkozás hangját a memóriába.

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

Miután hiperhivatkozást rendelt szöveghez vagy alakzathoz, a következő [IHyperlink](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/) metódusokat hívhatja meg:

- [setTooltip](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) beállítja azt a szöveget, amelyet a néző a hivatkozás tippjeként megjeleníthet.
- [setTargetFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setTargetFrame-java.lang.String-) megadja a célkeretet egy szülő HTML keretkészleten belül, ha alkalmazható.
- [setHistory](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setHistory-boolean-) szabályozza, hogy a hivatkozás aktiválása hozzáadja-e a célját a megtekintett hiperhivatkozások listájához.
- [setHighlightClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setHighlightClick-boolean-) szabályozza, hogy a hiperhivatkozás kattintáskor ki legyen-e emelve.

## **Hiperhivatkozások eltávolítása a bemutatókból**

Használja a [getAnyHyperlinks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) metódust a hiperhivatkozás konténerek (beleértve a szövegrész hivatkozásokat) összegyűjtéséhez, mielőtt módosítaná őket. A következő példa eltávolítja mindkét aktivációs típust az első diáról. Egy típus eltávolításához csak a [removeHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) vagy a [removeHyperlinkMouseOver](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--) metódust hívja; a kattintási művelet eltávolítása nem távolítja el a rá mutató egér fölé lépéshez tartozót.

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

Feltétel nélküli eltávolításhoz a [removeAllHyperlinks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) egy hívással eltávolítja mindkét aktivációs típust a kiválasztott környezetben. A szelektív tisztításhoz és a mester-, elrendezés- és jegyzet-szintű lefedettséghez lásd a [Jelentés, szűrés és ellenőrzés a hiperhivatkozásokra vonatkozóan](#report-sanitize-and-verify-hyperlinks) szakaszt.

## **Teljes hiperhivatkozás-nyilvántartás létrehozása**

Mielőtt egy bemutatót terjesztene, készítsen leltárt az interaktív műveleteiről és webhivatkozásairól. A [getAnyHyperlinks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) [IHyperlinkContainer](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/) objektumokat ad vissza, nem egy egyszerű URL karakterlánc listát. Vizsgálja meg minden konténeren a [getHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) és a [getHyperlinkMouseOver](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) metódusokat. Ezek függetlenek: ugyanaz a konténer mindkét akciót tartalmazhat, így egy teljes jelentés akár két sort is igényelhet konténerenként.

Csak alakzatszintű hiperhivatkozások beolvasása elszalaszthatja a szövegrészekhez csatolt hivatkozásokat. Inkább a megfelelő környezetben kérdezze le, és őrizze meg a visszaadott konténereket, hogy később frissíthesse vagy eltávolíthatja azok akcióit.

### **Prezentáció, dia és szövegkeret környezetek lekérdezése**

A [IHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/) interfész a követőkön keresztül érhető el: [IPresentation.getHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getHyperlinkQueries--), [IBaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getHyperlinkQueries--), és [ITextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getHyperlinkQueries--). Minden környezet ugyanazokat a lekérdezéseket támogatja:

- [getHyperlinkClicks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#getHyperlinkClicks--) konténereket ad vissza kattintási akcióval.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#getHyperlinkMouseOvers--) konténereket ad vissza egér fölé lépés akcióval.
- [getAnyHyperlinks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) konténereket ad vissza bármelyik vagy mindkét akcióval.

A következő példa létrehoz egy `hyperlink-audit-input.pptx` fájlt, amely külső kattintási linket, fájl egér fölé lépés linket, belső dia navigációt, szöveges egér fölé lépés linket és makró akciót tartalmaz. Ezek egyike sem hajtódik végre. Ugyanez a három lekérdezés minden környezetben működik; a számok konténereket írnak le, nem az akciók összegét. A szövegkeret környezet kizárja a körülvevő alakzat saját hivatkozásait.

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

Ezen példa esetén a prezentáció- és dia lekérdezések mindegyike három kattintási konténert, két egér fölé lépés konténert és három olyan konténert jelent, amely bármelyik akciót tartalmazza. A szövegkeret lekérdezés minden kategóriában egy konténert jelent.

### **Műveletek és célok osztályozása**

Használja az [IHyperlink.getActionType](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getActionType--) metódust egy művelet értelmezéséhez, mielőtt a célját értelmezné. A [HyperlinkActionType](https://reference.aspose.com/slides/java/com.aspose.slides/hyperlinkactiontype/) értékek a webes navigáción túlmennek:

| Értékek | Jelentés audit során |
| --- | --- |
| `Hyperlink` | Külső hiperhivatkozás; ellenőrizze az URL-t és annak sémaját. |
| `JumpSpecificSlide` | Belső navigáció egy adott diára. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Beépített diavetítés navigáció, a diavetítés kontextusában értelmezve. |
| `JumpEndShow`, `StartCustomSlideShow` | Az aktuális előadás befejezése vagy egy egyedi előadás indítása. |
| `StartMacro` | Makró végrehajtása. |
| `StartProgram` | Program indítása. |
| `OpenFile`, `OpenPresentation` | Fájl vagy másik prezentáció megnyitása; külön vizsgálja a webes URL-ekkel. |
| `StartStopMedia` | Média lejátszás indítása vagy leállítása. |
| `NoAction`, `Unknown` | Nincs navigációs akció, vagy nem felismert akció, amely felülvizsgálatot igényel. |

Olvassa be a külső célpontokat a [getExternalUrl](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getExternalUrl--) metódussal, és a specifikus belső célpontokat a [getTargetSlide](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getTargetSlide--) segítségével. Belső akciók és beépített parancsok esetén előfordulhat, hogy nincs külső URL; egy üres URL nem jelenti, hogy a konténernek nincs akciója. Tartsa meg a [getExternalUrlOriginal](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) által visszaadott értéket, ha eltér a normalizált URL-től, és vegye bele a [getTooltip](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getTooltip--) által visszaadott buborék szöveget, ha elérhető.

### **Jelentés, szűrés és ellenőrzés a hiperhivatkozásokra vonatkozóan**

A következő Java példa beolvas egy meglévő bemutatót (használja a fent létrehozott fájlt), írja a `hyperlink-audit.json` fájlt, alkalmaz egy szabályt, menti a `hyperlink-sanitized.pptx` fájlt, majd újra megnyitja, hogy újból ellenőrizze mindkét aktivációs típust. A módosítások előtt összegyűjti a konténereket, és referenciához viszonyított egyenlőséget használ, hogy ne dolgozza fel ugyanazt a konténert kétszer. A prezentáció lekérdezései az általános diákra vonatznak; egy csomagra kiterjedő leltárhoz kifejezetten lekérdezi a mestereket, elrendezéseket, jegyzeteket, valamint a jegyzet- és anyaglevonat mestereket, ha vannak.

A jelentés egy egytől kezdődő dia indexet és a [getSlideId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideId--) értéket rögzíti, ahol elérhető. Az [ISlideComponent.getSlide](https://reference.aspose.com/slides/java/com.aspose.slides/islidecomponent/#getSlide--) biztosítja a tulajdonos diát a támogatott konténerekhez. A mesterek, elrendezések és jegyzetek nem rendelkeznek hagyományos dia indexszel, és a környezetük alapján azonosíthatók. Az alakzat konténereket és a szövegrész formázási konténereket külön címkézzük; a többi konténer típus megtartja a futási időben definiált típus nevét. Minden konténer egy jelentéshelyi azonosítót kap, így a két akció összekapcsolható. A jelentés az akció típusát a Java enumeráció által definiált egész konstansként tárolja.

Ez a szándékosan szigorú alkalmazási szabály csak abszolút HTTPS URL-eket és érvényes belső dia célpontokat engedélyez. Elutasítja a makrókat, programokat, fájl műveleteket, egyéb diavetítés műveleteket, ismeretlen akciókat és egyéb URL sémákat. Ezek az elutasítások szabályalapú döntések, nem az Aspose.Slides biztonsági ítélete. Maga a HTTPS önmagában nem biztosít bizalmat: adjon hozzá host engedélylistákat és egyéb ellenőrzéseket az alkalmazásához. Mind az eredeti, mind a normalizált külső URL-ek ellenőrzésre kerülnek. A példa a metaadatokat ellenőrzi anélkül, hogy a linkeket követné vagy a műveleteket végrehajtaná.

A helyreállításhoz a konténer [getHyperlinkManager](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) támogatja a [setExternalHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-), a [removeHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) és a [removeHyperlinkMouseOver](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--) metódusokat. Itt a tiltott külső kattintási linkek egy rögzített HTTPS céloldallal cserélődnek; a többi tiltott kattintás és a tiltott egér fölé lépés akció külön-külön eltávolításra kerül. Állítsa a `replaceExternalClicks` értéket `false`-ra, hogy helyette az összes szabályszegést eltávolítsa. Válasszon egy alkalmazás által kezelt helyettesítő oldalt a telepítés előtt.

A jelentés exportálási jelzője egy konzervatív PDF felülvizsgálati szabályt használ: jelöli az egér fölé lépés akciókat és mindazt, ami nem külső link vagy konkrét diaugrás, potenciálisan nem támogatottként. Ez egy felülvizsgálati útmutató, nem egy képességteszt vagy garancia arra, hogy a nem jelölt linkek exportáláskor megmaradnak. A támogatott [PDF](/slides/hu/java/convert-powerpoint-to-pdf/) és [HTML](/slides/hu/java/convert-powerpoint-to-html/) exportok megőrizhetik a hiperhivatkozásokat, a művelettől, exportbeállításoktól és a megjelenítőtől függően. A raszteres [képek](/slides/hu/java/convert-powerpoint-to-png/) és [videók](/slides/hu/java/convert-powerpoint-to-video/) nem tudják megőrizni az interaktív hiperhivatkozásokat; auditáláskor minden akciót jelöljön, ha ezek a kimenetek a cél.

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

    // Sorosítja a jelentés lapos sorait további JSON függőség nélkül.
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

A fent létrehozott bemenettel a jelentés öt akciósort tartalmaz. A fájl egér fölé lépés link és a makró kattintás eltávolításra kerül, míg a HTTPS linkek és a belső dia navigáció megmarad. Az ellenőrzés nulla tiltott akciót ír ki. Egy tiltott külső kattintási URL-t tartalmazó bemenet a csere ágat is végrehajtja. Egy engedélyezett kattintással és tiltott egér fölé lépés akcióval rendelkező konténer megtartja a kattintási akciót.

Ez a szelektív tisztítás eltér a [removeAllHyperlinks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) metódustól, amely a kiválasztott környezetben a szabálytól függetlenül eltávolítja mindkét aktivációs típust. Itt az ellenőrzés csak a hiperhivatkozás akciókat vizsgálja; nem távolítja el a beágyazott VBA projekteket, OLE objektumokat vagy egyéb aktív tartalmakat, és nem ellenőrzi az exportált PDF vagy HTML fájlt.

## **GYIK**

**Hogyan linkelhetek egy szakaszra vagy annak első diájára?**

A PowerPoint szakaszok diákat csoportosítanak, de egy belső hiperhivatkozás egy egyedi diára mutat. Egy szakaszra való navigáláshoz linkelje a szakasz első diáját.

**Csatolhatok hiperhivatkozást a mesterdia elemeihez, hogy minden dián működjön?**

Igen. A mesterdia és elrendezés elemek támogatják a hiperhivatkozásokat. Ezeken az elemeken lévő linkek a diavetítés során elérhetők azon diákon, amelyek a megfelelő mestert vagy elrendezést használják.

**Megőrzik a hiperhivatkozásokat a PDF, HTML, képek vagy videó exportálásakor?**

A támogatott PDF és HTML exportok megőrizhetik a hiperhivatkozásokat; a raszteres képek és a videó nem képesek. Lásd az exportálási megfontolásokat a [Jelentés, szűrés és ellenőrzés a hiperhivatkozásokra vonatkozóan](#report-sanitize-and-verify-hyperlinks) szakaszban.