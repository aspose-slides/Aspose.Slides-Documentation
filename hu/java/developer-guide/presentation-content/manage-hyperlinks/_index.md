---
title: Java-ban bemutatók hiperhivatkozásainak kezelése
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
- bemutató
- Java
- Aspose.Slides
description: "Hiperhivatkozások hozzáadása, formázása, frissítése és eltávolítása PowerPoint és OpenDocument bemutatókban az Aspose.Slides for Java segítségével, Java példákat használva."
---
## **Bevezetés**

A hiperhivatkozás összekapcsolja a bemutató tartalmát egy weboldallal vagy a bemutatón belüli helyszínnel. A PowerPointban a hiperhivatkozások általában két célra szolgálnak:

* Szövegből, alakzatból vagy médiakeretből nyit meg egy weboldalt.
* Ugrás egy másik diara, például egy tartalomjegyzékből.

Az Aspose.Slides for Java lehetővé teszi ezeknek a hivatkozásoknak a hozzáadását, megjelenésük és hangjuk vezérlését, tulajdonságaik frissítését és eltávolítását. Az alábbi példák bemutatják, hogyan dolgozhat a hiperhivatkozásokkal egyedi elemeknél, valamint hogyan érheti el a hiperhivatkozásokat a bemutató, a dia vagy a szövegkeret szintjén.

{{% alert color="info" title="Note" %}}
A bemutatókat az [ingyenes online Aspose PowerPoint szerkesztő](https://products.aspose.app/slides/editor) segítségével is szerkesztheti.
{{% /alert %}}

## **URL hiperhivatkozások hozzáadása**

Weboldal URL-t rendelhet szöveghez, alakzathoz vagy médiakerethez. Az a elem, amelyhez a hiperhivatkozást rendeli, meghatározza a kattintható területet: egy szövegrész a kiválasztott szövegre hivatkozik, míg egy alakzat vagy keret a dia objektumára mutat.

Relatív hiperhivatkozásokat tartalmazó bemutatók esetén lásd a [Hiperhivatkozás alapjának kezelése](/slides/hu/java/presentation-properties/#manage-the-hyperlink-base) részt, amelyben olvashatja, módosíthatja vagy törölheti a dokumentumszintű alapot.

### **URL hiperhivatkozások hozzáadása szöveghez**

A szöveget egy weboldalra hivatkozáshoz adja át egy [Hyperlink](https://reference.aspose.com/slides/java/com.aspose.slides/hyperlink/) a szövegrész [setHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/portionformat/#setHyperlinkClick-com.aspose.slides.IHyperlink-) metódusának, ahogy alább látható. Csak a szöveg ezen része lesz kattintható.

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

Hívja meg a [setHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setHyperlinkClick-com.aspose.slides.IHyperlink-) metódust a téglalapon, hogy annak teljes területe kattintható legyen. Használja a [setTooltip](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) metódust, hogy a felhasználók a téglalap fölé húzva tippet kapjanak a célról. Mindkét metódus alkalmazható képek, hang- és videokeretekre is.

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

A belső hiperhivatkozások lehetővé teszik a felhasználók számára, hogy a tartalomjegyzékből egy adott diára ugorjanak. A következő példa a [setInternalHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkmanager/#setInternalHyperlinkClick-com.aspose.slides.ISlide-) használatával kapcsolja a „Page 2” szöveget az első dián a második diához.

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

Megváltoztathatja a hivatkozott szöveg színét, lejátszhat vagy leállíthat egy hangot, amikor a felhasználó aktiválja a hivatkozást, és beállíthatja a feljövő tippet.

### **Szín**

A [setColorSource](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setColorSource-int-) metódus az [IHyperlink](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/) interfészben meghatározza, hogy a hiperhivatkozás a bemutató hiperhivatkozás színét vagy a szövegrész formázását használja-e. Egy egyéni szövegszín alkalmazásához válassza a [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/hyperlinkcolorsource/) értéket, és állítsa be a rész kitöltő színét. Ez a funkció a PowerPoint 2019‑ben került bevezetésre; a régebbi verziók nem alkalmazzák ezt a beállítást.

Ebben a példában a [setColorSource](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setColorSource-int-) az első hivatkozást a szövegrész piros kitöltésével jeleníti meg. A második hivatkozás a bemutató hiperhivatkozás színét megtartja.

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

A hiperhivatkozás aktiváláskor lejátszhat egy hangot, vagy leállíthat egy már lejátszott hangot. Az alábbi módszerekkel állíthatja be ezeket a viselkedéseket:

- [IHyperlink.setSound](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setSound-com.aspose.slides.IAudio-) határozza meg a hiperhivatkozáshoz rendelt audio-t.
- [IHyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setStopSoundOnClick-boolean-) szabályozza, hogy a hiperhivatkozás aktiválása megállítja-e az előző hangot.

#### **Hiperhivatkozás hangjának hozzáadása**

Az első dián lévő gomb a [IHyperlink.setSound](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setSound-com.aspose.slides.IAudio-) metódust használja, hogy a `sampleaudio.wav` hangfájlt játssza le, amikor a felhasználó kattint a továbblépéshez. A második dián egy külön gomb a [IHyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setStopSoundOnClick-boolean-) metódust használja a lejátszás leállításához és a felhasználó azon a dián tartásához.

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

A következő példa megnyitja a fent létrehozott bemutatót, és a [getSound](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getSound--) valamint a [getBinaryData](https://reference.aspose.com/slides/java/com.aspose.slides/iaudio/#getBinaryData--) segítségével a memóriába olvassa be az első alakzat hiperhivatkozás hangját.

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

### **Tippek és interakció beállítások**

A következő [IHyperlink](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/) metódusok hívhatók meg egy hiperhivatkozás szöveghez vagy alakzathoz rendelése után:

- [setTooltip](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) beállítja a szöveget, amelyet a néző tippként jeleníthet meg a hivatkozáshoz.
- [setTargetFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setTargetFrame-java.lang.String-) határozza meg a célt keretet egy szülő HTML keretcsoportban, ha alkalmazható.
- [setHistory](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setHistory-boolean-) szabályozza, hogy a hivatkozás aktiválása hozzáadja-e a célját a megtekintett hiperhivatkozások listájához.
- [setHighlightClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setHighlightClick-boolean-) szabályozza, hogy a hiperhivatkozás ki legyen-e emelve kattintáskor.

## **Hiperhivatkozások eltávolítása a bemutatókból**

Használja a [getAnyHyperlinks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) metódust a hiperhivatkozás konténerek – beleértve a szövegrész hivatkozásokat – összegyűjtéséhez a módosításuk előtt. A következő példa eltávolítja mindkét aktiválási típust az első diáról. Egy típus eltávolításához csak a [removeHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) vagy a [removeHyperlinkMouseOver](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--) metódust hívja; a kattintási művelet eltávolítása nem távolítja el az egérfeletti megfelelőjét.

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

Az érvénytelen eltávolításhoz a [removeAllHyperlinks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) egy hívással eltávolítja mindkét aktiválási típust a kiválasztott környezetben. Szelektív tisztításhoz és a mester, elrendezés és jegyzetek lefedéséhez lásd a [Jelentés, tisztítás és ellenőrzés hiperhivatkozások](#report-sanitize-and-verify-hyperlinks) részt.

### **Hiperhivatkozások törlése a SmartArt szöveg cseréje előtt**

Amikor egy meglévő SmartArt csomópontban bekezdést cserél, a szövegrészek törlése elhagyott régi hiperhivatkozást eredményezhet. A bekezdést a [ISmartArtNode.getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ismartartnode/#getTextFrame--) metódussal szerezze meg. A részek törlése előtt hívja meg a [getHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getHyperlinkQueries--) metódust a csomópont alakzatának szövegkeretén, majd a visszaadott objektumon a [removeAllHyperlinks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) metódust. Ez eltávolítja az összes hiperhivatkozást az adott keretből, beleértve a többi bekezdés hivatkozásait is.

A példa feltételezi, hogy a `SmartArtHyperlink.pptx` első diájának harmadik alakzata egy SmartArt grafika. A negyedik csomópont első bekezdését cseréli. Ebben a bemutatóban a csomópont első alakzata jeleníti meg azt a bekezdést.

A két rész hozzáadása után a példa a [getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/#getEffective--) metódussal olvassa ki a hatékony formázást. Az ezen formázáson a [getHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformateffectivedata/#getHyperlinkClick--) az első részhez új hiperhivatkozást, a másodikhoz pedig `null` értéket ad vissza.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("SmartArtHyperlink.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = (ISmartArt) slide.getShapes().get_Item(2);
    ISmartArtNode node = smartArt.getAllNodes().get_Item(3);
    IParagraph paragraph = node.getTextFrame().getParagraphs().get_Item(0);

    node.getShapes().get_Item(0).getTextFrame().getHyperlinkQueries().removeAllHyperlinks();
    paragraph.getPortions().clear();

    IPortion link = new Portion("New reference");
    link.getPortionFormat().setHyperlinkClick(new Hyperlink("https://example.com/new"));
    paragraph.getPortions().add(link);
    IPortion text = new Portion(" (updated)");
    paragraph.getPortions().add(text);

    System.out.println(link.getPortionFormat().getEffective().getHyperlinkClick().getExternalUrl()); // https://example.com/new
    System.out.println(text.getPortionFormat().getEffective().getHyperlinkClick()); // null
} finally {
    presentation.dispose();
}
```

## **Teljes hiperhivatkozás leltár létrehozása**

A bemutató terjesztése előtt inventáriusolja annak interaktív műveleteit és webes linkjeit. A [getAnyHyperlinks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) [IHyperlinkContainer](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/) objektumokat ad vissza, nem egy lapos URL-listát. Vizsgálja meg mind a [getHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) , mind a [getHyperlinkMouseOver](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) metódusokat minden konténeren. Függetlenek: ugyanaz a konténer is kifejezhet mindkét akciót, ezért egy teljes jelentéshez akár két sor is kell egy konténerhez.

Csak alakzatszintű hiperhivatkozások beolvasása kihagyhatja a szövegrészhez csatolt linkeket. Kérdezze le a megfelelő környezetet, és őrizze meg a visszakapott konténereket, hogy később frissíthesse vagy eltávolíthassa azok műveleteit.

### **Bemutató, dia és szövegkeret körök lekérdezése**

Az [IHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/) interfész elérhető az [IPresentation.getHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getHyperlinkQueries--) , az [IBaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getHyperlinkQueries--) és az [ITextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getHyperlinkQueries--) segítségével. Minden környezet ugyanazokat a lekérdezéseket támogatja:

- [getHyperlinkClicks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#getHyperlinkClicks--) konténereket ad vissza kattintási művelettel.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#getHyperlinkMouseOvers--) konténereket ad vissza egérfeletti művelettel.
- [getAnyHyperlinks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) konténereket ad vissza valamelyik vagy mindkét akcióval.

Ez a példa kattintási és egérfeletti műveleteket rendel egy alakzathoz és annak szövegéhez, valamint egy makró műveletet egy külön gombhoz. Összehasonlítja a [getAnyHyperlinks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) által visszaadott konténerek számát az egyes aktiválási típusok számaival. A szövegkeret lekérdezése csak a szövegben lévő linkeket számolja. A körülvevő alakzat saját műveletei a dia- és bemutatólekérdezésekben is megjelennek.

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

Ehhez a példához a bemutató‑ és diakeresések három kattintási, két egérfeletti és három vegyes konténert adnak vissza. A szövegkeret‑lekérdezés egy konténert jelent minden kategóriában.

### **Műveletek és célpontok osztályozása**

Használja az [IHyperlink.getActionType](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getActionType--) metódust, hogy a műveletet a célpont értelmezése előtt elemezze. A [HyperlinkActionType](https://reference.aspose.com/slides/java/com.aspose.slides/hyperlinkactiontype/) értékek többek között a webes navigáción túl is kiterjednek:

| Values | Meaning for an audit |
| --- | --- |
| `Hyperlink` | Külső hiperhivatkozás; ellenőrizze az URL-t és annak sémáját. |
| `JumpSpecificSlide` | Belső navigáció egy adott diára. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Beépített diavetítés navigáció, a diavetítés kontextusában értelmezve. |
| `JumpEndShow`, `StartCustomSlideShow` | Az aktuális bemutató befejezése vagy egy egyedi bemutató indítása. |
| `StartMacro` | Makró végrehajtása. |
| `StartProgram` | Program indítása. |
| `OpenFile`, `OpenPresentation` | Fájl vagy egy másik bemutató megnyitása; külön kell vizsgálni a webes URL-ekkel szemben. |
| `StartStopMedia` | Média lejátszás indítása vagy leállítása. |
| `NoAction`, `Unknown` | Nincs navigációs művelet, vagy ismeretlen művelet, amely felülvizsgálatot igényel. |

Olvassa ki a külső célpontokat a [getExternalUrl](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getExternalUrl--) metódussal, a belső célpontokat a [getTargetSlide](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getTargetSlide--)‑vel. Belső műveletek és beépített parancsok esetén előfordulhat, hogy nincs külső URL; az üres URL nem jelenti, hogy a konténernek nincs művelete. Tartsa meg a [getExternalUrlOriginal](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) által visszaadott értéket, ha az eltér a normalizált URL‑től, és adja hozzá a [getTooltip](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getTooltip--) által visszaadott tippet, ha rendelkezésre áll.

### **Jelentés, tisztítás és ellenőrzés hiperhivatkozások**

Ez a példa megnyitja az előző példában létrehozott bemutatót, és minden művelethez egy JSON rekordot ír. A [getAnyHyperlinks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) segítségével gyűjti össze a normál diák, mesterek, elrendezések és jegyzetek konténereit, beleértve a meglévő jegyzet‑ és kiosztási mestereket is. A referenciális egyenlőséget használja minden konténer egyszeri számolásához, alkalmazza az alább leírt szabályt, majd újra megnyitja a mentett bemutatót, hogy ellenőrizze a kattintási és egérfeletti műveleteket.

A jelentés egy 1‑től kezdődő diák indexet és a [getSlideId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideId--) értéket rögzíti, ha elérhető. Az [ISlideComponent.getSlide](https://reference.aspose.com/slides/java/com.aspose.slides/islidecomponent/#getSlide--) biztosítja a tulajdonos diát a támogatott konténerekhez. A mesterek, elrendezések és jegyzetek nem rendelkeznek szokásos diák indexszel, azonosítva vannak a környezetük alapján. Az alakzat‑konténereket és a szövegrész‑formázási konténereket külön címkézi; a többi konténer típus megtartja futás‑időben kapott típusnevét. Minden konténer kap egy jelentés‑helyi azonosítót, hogy a két művelet összekapcsolható legyen. A jelentés a művelettípusokat a Java felsorolás által definiált egész konstansokként tárolja.

Ez a szándékosan szigorú alkalmazási politika csak abszolút HTTPS URL‑eket és érvényes belső diacélpontokat engedélyez. Elutasítja a makrókat, programokat, fájl műveleteket, egyéb diavetítés‑műveleteket, ismeretlen műveleteket és egyéb URL‑sémákat. Ezek az elutasítások politika‑döntések, nem az Aspose.Slides biztonsági megítélése. A HTTPS önmagában nem garantál bizalmat: adjon hozzá host‑fehérlistákat és egyéb ellenőrzéseket az alkalmazásához. Az eredeti és a normalizált külső URL‑eket is ellenőrzi a példa, és a metaadatokat auditorolja anélkül, hogy a linkeket követné vagy a műveleteket végrehajtaná.

Javításhoz a konténer [getHyperlinkManager](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) támogatja a [setExternalHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-), a [removeHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) és a [removeHyperlinkMouseOver](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--) metódusokat. Itt a tiltott külső kattintási linkek egy rögzített HTTPS céloldallal kerülnek helyettesítésre; a többi tiltott kattintás és a tiltott egérfeletti művelet önállóan eltávolításra kerül. Állítsa a `replaceExternalClicks` értékét `false`‑ra, ha minden szabálysértést el akar távolítani. Válasszon egy alkalmazás‑tulajdonú helyettesítő oldalt a telepítés előtt.

A jelentés export‑jelzője egy konzervatív PDF‑ellenőrzési politikát alkalmaz: egérfeletti műveleteket és minden mást, ami nem külső link vagy konkrét diára ugrás, potenciálisan nem támogatottként jelöli. Ez egy felülvizsgálati útmutató, nem képesség‑teszt vagy garancia arra, hogy a jelöletlen linkek megmaradnak exportáláskor. A támogatott [PDF](/slides/hu/java/convert-powerpoint-to-pdf/) és [HTML](/slides/hu/java/convert-powerpoint-to-html/) exportálások megőrizhetik a hiperhivatkozásokat, a művelettől, az export‑opcióktól és a megjelenítőtől függően. A raszteres [images](/slides/hu/java/convert-powerpoint-to-png/) és [video](/slides/hu/java/convert-powerpoint-to-video/) nem tudják megőrizni az interaktív hiperhivatkozásokat; ezért a kimenetek ellenőrzésekor minden műveletet jelölni kell.

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

A fenti bemenet alapján a jelentés öt művelet‑sort tartalmaz. A fájl egérfeletti linkje és a makró‑kattintás eltávolításra kerül, míg a HTTPS linkek és a belső diánavigáció megmarad. Az ellenőrzés nulla tiltott műveletet jelez. Egy tiltott külső kattintási URL‑t tartalmazó bemenet is a helyettesítési ágat aktiválja. Egy engedélyezett kattintással és tiltott egérfeletti művelettel rendelkező konténer megtartja a kattintási műveletét.

Ez a szelektív tisztítás különbözik a [removeAllHyperlinks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--)‑tól, amely a kiválasztott környezetben mindkét aktiválási típust eltávolítja a politika tekintet nélkül. Az itt végzett ellenőrzés csak a hiperhivatkozás‑műveleteket vizsgálja; nem távolítja el a beágyazott VBA‑projket, OLE‑objektumokat vagy egyéb aktív tartalmakat, és nem validálja az exportált PDF‑ vagy HTML‑fájlt.

## **GYIK**

**Hogyan linkelhetek egy szekcióra vagy annak első diájára?**

A PowerPoint szekciók csoportosítják a diákat, de egy belső hiperhivatkozás egyetlen diát céloz. A szekcióra való navigáció létrehozásához a szekció első diájára hivatkozzon.

**Csatolhatok-e hiperhivatkozást mesterdia elemeihez, hogy minden dián működjön?**

Igen. A mesterdia és az elrendezés elemei támogatják a hiperhivatkozásokat. Ezeken az elemeken lévő linkek a diavetítés során elérhetők azon diákon, amelyek a megfelelő mestert vagy elrendezést használják.

**Megmaradnak a hiperhivatkozások PDF, HTML, képek vagy videó exportálásakor?**

A támogatott PDF és HTML exportálások megőrizhetik a hiperhivatkozásokat; a raszteres képek és a videó nem. Lásd az exportálási megfontolásokat a [Jelentés, tisztítás és ellenőrzés hiperhivatkozások](#report-sanitize-and-verify-hyperlinks) részben.