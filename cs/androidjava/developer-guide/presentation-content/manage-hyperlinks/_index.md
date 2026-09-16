---
title: Správa hypertextových odkazů v prezentacích na Androidu
linktitle: Správa hypertextových odkazů
type: docs
weight: 20
url: /cs/androidjava/manage-hyperlinks/
keywords:
- přidat URL
- přidat hypertextový odkaz
- vytvořit hypertextový odkaz
- formátovat hypertextový odkaz
- odstranit hypertextový odkaz
- aktualizovat hypertextový odkaz
- hypertextový odkaz v textu
- hypertextový odkaz na snímek
- hypertextový odkaz na tvar
- hypertextový odkaz na obrázek
- hypertextový odkaz na video
- měnitelný hypertextový odkaz
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Přidávejte, formátujte, aktualizujte a odstraňujte hypertextové odkazy v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Android prostřednictvím Javy, s využitím Java příkladů."
---
## **Úvod**

Hyperlink propojuje obsah prezentace s webovou stránkou nebo místem v rámci prezentace. V PowerPointu hypertextové odkazy běžně slouží ke dvěma účelům:

* Otevřít webovou stránku z textu, tvaru nebo mediálního rámce.
* Přejít na jiný snímek, například z obsahu.

Aspose.Slides for Android via Java vám umožňuje tyto odkazy přidávat, řídit jejich vzhled a zvuk, aktualizovat jejich vlastnosti a odstraňovat je. Níže uvedené příklady ukazují, jak pracovat s hypertextovými odkazy na jednotlivých prvcích a jak získat přístup k odkazům na úrovni prezentace, snímku nebo textového rámce.

{{% alert color="info" title="Note" %}}
Můžete také upravovat prezentace pomocí [bezplatného online editoru Aspose PowerPoint](https://products.aspose.app/slides/cs/editor).
{{% /alert %}} 

## **Přidat URL odkazy**

Můžete přiřadit URL webové stránky k textu, tvaru nebo mediálnímu rámci. Prvek, ke kterému odkaz přiřadíte, určuje klikací oblast: část textu propojí vybraný text, zatímco tvar nebo rámec propojí objekt snímku.

### **Přidat URL odkazy do textu**

Chcete‑li propojit text s webovou stránkou, předejte [Hyperlink](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/hyperlink/) metodě [setHyperlinkClick](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/portionformat/#setHyperlinkClick-com.aspose.slides.IHyperlink-) části textu, jak je ukázáno níže. Klikací se stane pouze tato část textu.

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

### **Přidat URL odkazy do tvarů a mediálních rámců**

Aby byl tvar nebo rámec klikací, zavolejte jeho metodu [setHyperlinkClick](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/shape/#setHyperlinkClick-com.aspose.slides.IHyperlink-). Hyperlink patří k samotnému objektu, nikoli k části textu uvnitř něj.

Stejný postup platí pro obrázkové, audio a video rámy: přiřaďte odkaz rámečku a v případě potřeby zavolejte [setTooltip](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-).

Následující příklad vytvoří klikací obdélník:

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

## **Použít hypertextové odkazy k vytvoření obsahu**

Interní hypertextové odkazy umožňují čtenářům přejít z obsahu na konkrétní snímek. Následující příklad používá [setInternalHyperlinkClick](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ihyperlinkmanager/#setInternalHyperlinkClick-com.aspose.slides.ISlide-) k propojení textu „Page 2“ na prvním snímku se druhým snímkem.

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

## **Formátovat hypertextové odkazy**

### **Barva**

Metoda [setColorSource](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ihyperlink/#setColorSource-int-) rozhraní [IHyperlink] určuje, zda odkaz používá barvu hypertextu prezentace nebo formátování části textu. Pro vlastní barvu textu vyberte [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/hyperlinkcolorsource/) a nastavte výplň barvu části. Tato funkce byla zavedena v PowerPoint 2019; starší verze tuto volbu nepoužívají.

Následující příklad přidá dva textové odkazy na stejný snímek. První používá červenou výplň textu, druhý zachovává výchozí barvu odkazu.

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
### **Zvuk**

Hypertextový odkaz může při aktivaci přehrát zvuk nebo zastavit zvuk, který již běží. Použijte následující metody k nastavení tohoto chování:

- [IHyperlink.setSound](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ihyperlink/#setSound-com.aspose.slides.IAudio-) určuje audio spojené s odkazem.
- [IHyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ihyperlink/#setStopSoundOnClick-boolean-) určuje, zda aktivace odkazu zastaví předchozí zvuk.

#### **Přidat zvuk k hypertextovému odkazu**

Následující příklad načte `sampleaudio.wav` a přiřadí jej tlačítku na prvním snímku. Kliknutí na tlačítko přehraje zvuk a přejde na další snímek. Druhý tvar na tom snímku při kliknutí zastaví předchozí zvuk, aniž by provedl navigaci.

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

#### **Extrahovat zvuk z hypertextového odkazu**

Následující příklad otevře výše vytvořenou prezentaci a načte audio odkazu první tvary do paměti pomocí [getSound](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ihyperlink/#getSound--) a [getBinaryData](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iaudio/#getBinaryData--).

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

### **Nápověda a nastavení interakce**

Po přiřazení odkazu k textu nebo tvaru můžete zavolat následující metody rozhraní [IHyperlink]:

- [setTooltip](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) nastavuje text, který může divák zobrazit jako nápovědu k odkazu.
- [setTargetFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ihyperlink/#setTargetFrame-java.lang.String-) určuje cílový rámec v nadřazeném HTML framesetu, pokud je to použitelné.
- [setHistory](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ihyperlink/#setHistory-boolean-) určuje, zda aktivace odkazu přidá jeho cíl do seznamu zobrazených odkazů.
- [setHighlightClick](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ihyperlink/#setHighlightClick-boolean-) určuje, zda je odkaz zvýrazněn po kliknutí.

## **Odstranit hypertextové odkazy z prezentací**

Použijte [getAnyHyperlinks](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) k získání kontejnerů odkazů, včetně odkazů na části textu, před jejich změnou. Následující příklad odstraňuje oba typy aktivace z prvního snímku. Chcete‑li odstranit pouze jeden typ, zavolejte jen [removeHyperlinkClick](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) nebo [removeHyperlinkMouseOver](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--); odstranění akce kliknutí neodstraní její ekvivalent při najetí myší.

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

Pro bezpodmínečné odstranění [removeAllHyperlinks](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) odstraňuje oba typy aktivace v zvoleném rozsahu jedním voláním. Pro selektivní úklid a pokrytí masterů, rozložení a poznámek viz [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Vytvořit úplný inventář hypertextových odkazů**

Před distribucí prezentace zkontrolujte její interaktivní akce i webové odkazy. [getAnyHyperlinks](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) vrací objekty [IHyperlinkContainer](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ihyperlinkcontainer/), nikoli plochý seznam řetězců URL. Prohlédněte jak [getHyperlinkClick](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) tak [getHyperlinkMouseOver](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) na každém kontejneru. Jsou nezávislé: stejný kontejner může mít oba typy akcí, takže úplná zpráva může potřebovat až dva řádky na kontejner.

Prohledávání pouze úrovně tvarů může vynechat odkazy připojené k částem textu. Dotazujte se na příslušný rozsah a uchovávejte vrácené kontejnery, abyste je mohli později aktualizovat nebo odstranit jejich akce.

### **Dotazovat se na rozsahy Prezentace, Snímku a Textového rámce**

Rozhraní [IHyperlinkQueries] je dostupné přes [IPresentation.getHyperlinkQueries](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentation/#getHyperlinkQueries--), [IBaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ibaseslide/#getHyperlinkQueries--) a [ITextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextframe/#getHyperlinkQueries--). Každý rozsah podporuje stejné dotazy:

- [getHyperlinkClicks](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkClicks--) vrací kontejnery s akcí kliknutí.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkMouseOvers--) vrací kontejnery s akcí při najetí myší.
- [getAnyHyperlinks](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) vrací kontejnery s jednou či oběma akcemi.

Následující příklad vytvoří `hyperlink-audit-input.pptx` s externím odkazem na kliknutí, souborovým odkazem při najetí, interní navigací mezi snímky, odkazem na text při najetí a makrem. Neprovádí žádnou z těchto akcí. Stejné tři dotazy fungují v každém rozsahu; počty popisují kontejnery, nikoli celkový počet akcí. Rozsah textového rámce vylučuje odkazy vlastnímu tvaru.

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

Pro tento příklad dotazy na prezentaci a snímek uvádějí po třech kontejnerech s kliknutím, dvou s najetím a třech s libovolnou akcí. Dotaz na textový rámec uvádí po jednom kontejneru v každé kategorii.

### **Klasifikovat akce a cíle**

Použijte [IHyperlink.getActionType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ihyperlink/#getActionType--) k interpretaci akce před interpretací jejího cíle. Hodnoty [HyperlinkActionType] pokrývají více než jen webovou navigaci:

| Hodnoty | Význam pro audit |
| --- | --- |
| `Hyperlink` | Externí hypertextový odkaz; prověřte URL a její schéma. |
| `JumpSpecificSlide` | Interní navigace na konkrétní snímek. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Vestavěná navigace v prezentaci, vyhodnocována v kontextu promítání. |
| `JumpEndShow`, `StartCustomSlideShow` | Ukončit aktuální ukázku nebo spustit vlastní ukázku. |
| `StartMacro` | Spustit makro. |
| `StartProgram` | Spustit program. |
| `OpenFile`, `OpenPresentation` | Otevřít soubor nebo jinou prezentaci; posuzujte odděleně od webových URL. |
| `StartStopMedia` | Spustit nebo zastavit přehrávání média. |
| `NoAction`, `Unknown` | Žádná navigační akce, nebo neznámá akce vyžadující kontrolu. |

Externí cíle načtěte pomocí [getExternalUrl](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ihyperlink/#getExternalUrl--) a konkrétní interní cíle pomocí [getTargetSlide](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ihyperlink/#getTargetSlide--). Interní akce a vestavěné příkazy nemusí mít externí URL; prázdná URL neznamená, že kontejner nemá žádnou akci. Zachovejte hodnotu vrácenou [getExternalUrlOriginal](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) pokud se liší od normalizované URL, a zahrňte nápovědu vrácenou [getTooltip](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ihyperlink/#getTooltip--) pokud je k dispozici.

### **Zpráva, sanitizace a ověření hypertextových odkazů**

Následující Java příklad načte existující prezentaci (použijte soubor vytvořený výše), zapíše `hyperlink-audit.json`, použije politiku, uloží `hyperlink-sanitized.pptx` a znovu jej otevře ke kontrole obou typů aktivace. Před změnou sbírá kontejnery a využívá referenční rovnost, aby se stejný kontejner nezkontroloval dvakrát. Dotazy na prezentaci pokrývají běžné snímky; pro inventář celého balíčku explicitně dotazuje i master‑snímky, rozložení, poznámky a notifikační master‑snímky, pokud jsou přítomny.

Zpráva zaznamenává jednorozměrný index snímku a [getSlideId](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ibaseslide/#getSlideId--) kde je to možné. [ISlideComponent.getSlide](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islidecomponent/#getSlide--) poskytuje vlastní snímek pro podporované kontejnery. Master‑snímky, rozložení a poznámky nemají běžný index snímku a jsou identifikovány svým rozsahem. Kontejnery tvarů a formátování částí textu jsou označeny zvlášť; jiné typy kontejnerů si ponechávají název svého runtime typu. Každý kontejner získá lokální ID zprávy, aby jeho dvě akce bylo možné propojit. Akce jsou uloženy jako celočíselné konstanty definované Java enumerací.

Tato úmyslně restriktivní aplikační politika povoluje pouze absolutní HTTPS URL a platné interní cíle snímků. Zamítá makra, programy, souborové akce, ostatní akce promítání, neznámé akce a jiné schémata URL. Jedná se o rozhodnutí politiky, nikoli o závěr o bezpečnosti Aspose.Slides. HTTPS samo o sobě nezaručuje důvěru: přidejte seznam povolených hostitelů a další kontroly podle potřeb aplikace. Kontrolují se jak originální, tak normalizované externí URL. Příklad audituje metadata bez následování odkazů nebo spouštění akcí.

Pro opravu podporuje [getHyperlinkManager](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) metody [setExternalHyperlinkClick](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-), [removeHyperlinkClick](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) a [removeHyperlinkMouseOver](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--). Zde jsou zakázané externí odkazy na kliknutí nahrazeny pevnou HTTPS vstupní stránkou; ostatní zakázané kliknutí a zakázané akce při najetí jsou odstraněny samostatně. Nastavte `replaceExternalClicks` na `false`, chcete‑li odstranit všechny porušení politiky. Vyberte vlastní náhradní stránku před nasazením.

Exportní příznak zprávy používá konzervativní politiku revize PDF: označuje akce při najetí a vše kromě externího odkazu nebo konkrétního skoku na snímek jako potenciálně nepodporované. Jedná se o vodítko k revizi, nikoli o test schopností nebo záruku, že neoznačené odkazy přežijí export. Podporované exporty do [PDF](/slides/cs/androidjava/convert-powerpoint-to-pdf/) a [HTML](/slides/cs/androidjava/convert-powerpoint-to-html/) mohou odkazy zachovat, v závislosti na akci, exportních možnostech a prohlížeči. Rasterové [images](/slides/cs/androidjava/convert-powerpoint-to-png/) a [video](/slides/cs/androidjava/convert-powerpoint-to-video/) nemohou zachovat interaktivní odkazy; při auditu pro tyto výstupy označte každou akci.

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

    // Serializujte ploché řádky této zprávy bez další závislosti na JSON.
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

S výše vytvořeným vstupem zpráva obsahuje pět řádků s akcemi. Odkaz na soubor při najetí a makro kliknutí jsou odstraněny, zatímco HTTPS odkazy a interní navigace mezi snímky zůstávají. Ověření vypíše nula zakázaných akcí. Vstup obsahující zakázaný externí odkaz na kliknutí také demonstruje větev nahrazení. Kontejner s povoleným kliknutím a zakázaným najetím si zachová klikací akci.

Tento selektivní úklid se liší od [removeAllHyperlinks](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--), který odstraňuje oba typy aktivace v celém vybraném rozsahu bez ohledu na politiku. Ověření zde kontroluje pouze akce hypertextových odkazů; neodstraňuje vložené VBA projekty, OLE objekty ani jiný aktivní obsah a nevaliduje exportovaný PDF ani HTML soubor.

## **Často kladené otázky**

**Jak mohu vytvořit odkaz na sekci nebo její první snímek?**

Sekce v PowerPointu seskupují snímky, ale interní hypertextový odkaz cílí na konkrétní snímek. Pro navigaci na sekci vytvořte odkaz na první snímek této sekce.

**Mohu připojit hypertextový odkaz k prvkům master‑snímků, aby fungoval na všech snímcích?**

Ano. Prvky master‑snímků a rozložení podporují hypertextové odkazy. Odkazy na těchto prvcích jsou dostupné během prezentace na snímcích, které používají odpovídající master nebo rozložení.

**Zůstanou hypertextové odkazy zachovány při exportu do PDF, HTML, obrázků nebo videa?**

Podporované exporty do PDF a HTML mohou odkazy zachovat; rastrové obrázky a video odkazy nemohou. Viz úvahy o exportu v [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).