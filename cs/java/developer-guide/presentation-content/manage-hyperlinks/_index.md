---
title: Správa hypertextových odkazů v prezentaci v Javě
linktitle: Správa hypertextových odkazů
type: docs
weight: 20
url: /cs/java/manage-hyperlinks/
keywords:
- přidat URL
- přidat hypertextový odkaz
- vytvořit hypertextový odkaz
- formátovat hypertextový odkaz
- odstranit hypertextový odkaz
- aktualizovat hypertextový odkaz
- hypertextový odkaz v textu
- hypertextový odkaz na snímek
- hypertextový odkaz ve tvaru
- hypertextový odkaz na obrázek
- hypertextový odkaz na video
- měnitelný hypertextový odkaz
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Přidávejte, formátujte, aktualizujte a odstraňujte hypertextové odkazy v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Java s ukázkami v Javě."
---
## **Úvod**

Odkaz (hyperlink) spojuje obsah prezentace s webovou stránkou nebo místem v prezentaci. V PowerPointu hypertextové odkazy obvykle slouží ke dvěma účelům:

* Otevřít webovou stránku z textu, tvaru nebo mediálního rámce.
* Přeskočit na jiný snímek, například z obsahu.

Aspose.Slides pro Java vám umožňuje tyto odkazy přidávat, řídit jejich vzhled a zvuk, aktualizovat jejich vlastnosti a odstraňovat je. Níže uvedené příklady ukazují, jak pracovat s hyperlinky na jednotlivých prvcích a jak získat přístup k hyperlinkům na úrovni prezentace, snímku nebo textového rámce.

{{% alert color="info" title="Note" %}}
Můžete také upravovat prezentace pomocí [bezplatného online editoru Aspose PowerPoint](https://products.aspose.app/slides/editor).
{{% /alert %}} 

## **Přidat URL odkazy**

Můžete přiřadit URL webové stránky k textu, tvaru nebo mediálnímu rámci. Prvek, ke kterému hypertextový odkaz přiřadíte, určuje oblast, na kterou lze kliknout: část textu odkazuje na vybraný text, zatímco tvar nebo rámec odkazují na objekt snímku.

U prezentací obsahujících relativní hypertextové odkazy se podívejte na [Správa základny hypertextových odkazů](/slides/cs/java/presentation-properties/#manage-the-hyperlink-base), kde můžete přečíst, změnit nebo vymazat základní úroveň dokumentu.

### **Přidat URL odkazy do textu**

Pro vytvoření odkazu textu na webovou stránku předáte třídu [Hyperlink](https://reference.aspose.com/slides/java/com.aspose.slides/hyperlink/) metodě [setHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/portionformat/#setHyperlinkClick-com.aspose.slides.IHyperlink-) podílu textu, jak je ukázáno níže. Pouze tato část textu se stane klikací.

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

Aby byl tvar nebo rámec klikací, zavolejte jeho metodu [setHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setHyperlinkClick-com.aspose.slides.IHyperlink-). Hyperlink patří samotnému objektu, nikoli části textu uvnitř něj.

Stejný postup platí pro rámy obrázků, audia a videa: přiřaďte hyperlink rámci a v případě potřeby zavolejte [setTooltip](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-).

Následující příklad učiní obdélník klikacím:

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

Vnitřní hypertextové odkazy umožňují čtenářům přeskakovat z obsahu na konkrétní snímek. Následující příklad používá [setInternalHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkmanager/#setInternalHyperlinkClick-com.aspose.slides.ISlide-) k propojení textu „Page 2“ na prvním snímku s druhým snímkem.

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

## **Formátovat hypertextové odkazy**

### **Barva**

Metoda [setColorSource](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setColorSource-int-) rozhraní [IHyperlink](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/) určuje, zda hypertextový odkaz používá barvu odkazu z celé prezentace nebo formátování dané části textu. Pro použití vlastní barvy textu vyberte [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/hyperlinkcolorsource/) a nastavte výplňovou barvu části. Tato funkce byla zavedena v PowerPoint 2019; starší verze tuto volbu nepoužívají.

Následující příklad přidá dva textové odkazy na stejný snímek. První používá červenou výplň textu, zatímco druhý zachovává výchozí barvu hypertextového odkazu.

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
### **Zvuk**

Hypertextový odkaz může při aktivaci přehrát zvuk nebo zastavit zvuk, který již přehrává. K nastavení tohoto chování použijte následující metody:

- [IHyperlink.setSound](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setSound-com.aspose.slides.IAudio-) určuje audio přidružené k hypertextovému odkazu.
- [IHyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setStopSoundOnClick-boolean-) určuje, zda aktivace odkazu zastaví předchozí zvuk.

#### **Přidat zvuk k hypertextovému odkazu**

Následující příklad načte `sampleaudio.wav` a přiřadí jej tlačítku na prvním snímku. Kliknutím na tlačítko se přehraje zvuk a přejde na další snímek. Druhý tvar na tomto snímku po kliknutí zastaví předchozí zvuk, aniž by provedl navigační akci.

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

#### **Extrahovat zvuk z hypertextového odkazu**

Následující příklad otevře výše vytvořenou prezentaci a načte audio hypertextového odkazu prvního tvaru do paměti pomocí [getSound](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getSound--) a [getBinaryData](https://reference.aspose.com/slides/java/com.aspose.slides/iaudio/#getBinaryData--).

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

### **Popisek a nastavení interakce**

Můžete po přiřazení hypertextového odkazu k textu nebo tvaru volat následující metody rozhraní [IHyperlink](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/):

- [setTooltip](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) nastaví text, který může prohlížeč zobrazit jako nápovědu k odkazu.
- [setTargetFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setTargetFrame-java.lang.String-) určuje cílový rámec v rámci rodičovské HTML sady rámců, pokud je to aplikovatelné.
- [setHistory](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setHistory-boolean-) řídí, zda aktivace odkazu přidá jeho cíl do seznamu zobrazených hypertextových odkazů.
- [setHighlightClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setHighlightClick-boolean-) řídí, zda bude hypertextový odkaz po kliknutí zvýrazněn.

## **Odstranit hypertextové odkazy z prezentací**

Použijte [getAnyHyperlinks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) k získání kontejnerů hypertextových odkazů, včetně odkazů na části textu, před jejich změnou. Následující příklad odstraňuje oba typy aktivace z prvního snímku. Pro odstranění jen jednoho typu zavolejte pouze [removeHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) nebo [removeHyperlinkMouseOver](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--); odstranění klikací akce neodstraní její protějšek při přejetí myší.

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

Pro bezpodmínek odstranění [removeAllHyperlinks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) odstraňuje oba typy aktivace ve vybraném rozsahu jedním voláním. Pro selektivní čištění a pokrytí hlav, rozložení a poznámek viz [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Vytvořit kompletní inventář hypertextových odkazů**

Před distribuováním prezentace si vytvořte inventář jejích interaktivních akcí i webových odkazů. [getAnyHyperlinks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) vrací objekty [IHyperlinkContainer](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/), nikoli plochý seznam URL řetězců. Prohlédněte jak [getHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) , tak [getHyperlinkMouseOver](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) u každého kontejneru. Jsou nezávislé: stejný kontejner může mít obě akce, takže úplná zpráva vyžaduje až dva řádky na kontejner.

Skenování pouze hypertextových odkazů na úrovni tvaru může opomenout odkazy připojené k částem textu. Místo toho dotazujte vhodný rozsah a uchovávejte vrácené kontejnery, abyste je mohli později aktualizovat nebo odstranit jejich akce.

### **Dotazování rozsahů prezentace, snímku a textového rámce**

Rozhraní [IHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/) je dostupné přes [IPresentation.getHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getHyperlinkQueries--), [IBaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getHyperlinkQueries--) a [ITextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getHyperlinkQueries--). Každý rozsah podporuje stejné dotazy:

- [getHyperlinkClicks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#getHyperlinkClicks--) vrací kontejnery s akcí kliknutí.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#getHyperlinkMouseOvers--) vrací kontejnery s akcí při přejetí myší.
- [getAnyHyperlinks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) vrací kontejnery s jednou nebo oběma akcemi.

Následující příklad vytvoří `hyperlink-audit-input.pptx` s externím klikacím odkazem, odkazem na soubor při přejetí myší, vnitřní navigací mezi snímky, textovým odkazem při přejetí myší a makro akcí. Žádná z těchto akcí se neprovede. Stejné tři dotazy fungují v každém rozsahu; počty popisují kontejnery, nikoli celkový počet akcí. Rozsah textového rámce vylučuje odkazy vlastního obklopujícího tvaru.

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

V tomto příkladu dotazy prezentace a snímku uvádějí tři kontejnery kliknutí, dva kontejnery při přejetí myší a tři kontejnery s jednou z akcí. Dotaz textového rámce uvádí po jednom kontejneru v každé kategorii.

### **Klasifikovat akce a cíle**

Použijte [IHyperlink.getActionType](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getActionType--) k interpretaci akce před interpretací jejího cíle. Hodnoty [HyperlinkActionType](https://reference.aspose.com/slides/java/com.aspose.slides/hyperlinkactiontype/) zahrnují více než webovou navigaci:

| Hodnoty | Význam pro audit |
| --- | --- |
| `Hyperlink` | Externí hypertextový odkaz; zkontrolujte URL a jeho schéma. |
| `JumpSpecificSlide` | Vnitřní navigace na konkrétní snímek. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Vestavěná navigace v prezentaci, řešená v kontextu prezentace. |
| `JumpEndShow`, `StartCustomSlideShow` | Ukončit aktuální prezentaci nebo spustit vlastní prezentaci. |
| `StartMacro` | Spustit makro. |
| `StartProgram` | Spustit program. |
| `OpenFile`, `OpenPresentation` | Otevřít soubor nebo jinou prezentaci; posoudit odděleně od webových URL. |
| `StartStopMedia` | Spustit nebo zastavit přehrávání média. |
| `NoAction`, `Unknown` | Žádná navigační akce, nebo nerozpoznaná akce vyžadující revizi. |

Přečtěte externí cíle pomocí [getExternalUrl](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getExternalUrl--) a konkrétní vnitřní cíle pomocí [getTargetSlide](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getTargetSlide--). Vnitřní akce a vestavěné příkazy mohou mít žádnou externí URL; prázdná URL neznamená, že kontejner nemá žádnou akci. Zachovejte hodnotu vrácenou [getExternalUrlOriginal](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) pokud se liší od normalizované URL, a zahrňte popisek vrácený [getTooltip](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getTooltip--) pokud je dostupný.

### **Vytvořit zprávu, očistit a ověřit hypertextové odkazy**

Následující Java příklad načte existující prezentaci (použijte výše vytvořený soubor), zapíše `hyperlink-audit.json`, aplikuje politiku, uloží `hyperlink-sanitized.pptx` a znovu jej otevře pro kontrolu obou typů aktivace. Před změnou sbírá kontejnery a používá referenční rovnost k zabránění dvojitému zpracování stejného kontejneru. Dotazy prezentace zahrnují obyčejné snímky; pro inventář na úrovni balíčku také explicitně dotazuje hlavní snímky, rozložení, poznámky a hlavní a podklady pro poznámky, pokud jsou přítomny.

Zpráva zaznamenává číslování snímků od jedné a [getSlideId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideId--) pokud je k dispozici. [ISlideComponent.getSlide](https://reference.aspose.com/slides/java/com.aspose.slides/islidecomponent/#getSlide--) poskytuje vlastní snímek pro podporované kontejnery. Hlavní snímky, rozložení a poznámky nemají běžné číslování snímků a jsou identifikovány podle svého rozsahu. Kontejnery tvarů a kontejner formátování částí textu jsou označeny samostatně; ostatní typy kontejnerů zachovávají název svého runtime typu. Každý kontejner získá místní ID v rámci zprávy, aby bylo možné propojit jeho dvě akce. Zpráva ukládá typy akcí jako celočíselné konstanty definované Java výčtem.

Tato záměrně restriktivní politika aplikace povoluje pouze absolutní HTTPS URL a platné vnitřní cíle snímků. Odmítá makra, programy, akce na souborech, jiné akce prezentace, neznámé akce a jiné schémata URL. Tato odmítnutí jsou rozhodnutí politiky, nikoli bezpečnostní verdikt Aspose.Slides. Pouze HTTPS nezaručuje důvěryhodnost: přidejte seznamy povolených hostitelů a další kontroly pro vaši aplikaci. Kontrolují se jak původní, tak normalizované externí URL. Příklad auditu metadata nevybírá odkazy ani nespouští akce.

Pro opravu podporuje kontejner [getHyperlinkManager](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) metody [setExternalHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-), [removeHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) nebo [removeHyperlinkMouseOver](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--). Zde jsou zakázané externí klikací odkazy nahrazeny pevnou HTTPS vstupní stránkou; ostatní zakázané klikání a zakázané akce při přejetí myší jsou odstraněny nezávisle. Nastavte `replaceExternalClicks` na `false` pro odstranění všech porušení politiky. Vyberte náhradní stránku spravovanou aplikací před nasazením.

Exportní příznak zprávy používá konzervativní politiku kontroly PDF: označuje akce při přejetí myší a vše kromě externího odkazu nebo konkrétního přechodu na snímek jako potenciálně nepodporované. Jedná se o návod pro revizi, nikoli test schopnosti nebo záruku, že neoznačené odkazy přežijí export. Podporované exporty do [PDF](/slides/cs/java/convert-powerpoint-to-pdf/) a [HTML](/slides/cs/java/convert-powerpoint-to-html/) mohou zachovat hypertextové odkazy v závislosti na akci, nastavení exportu a prohlížeči. Rasterové [obrázky](/slides/cs/java/convert-powerpoint-to-png/) a [video](/slides/cs/java/convert-powerpoint-to-video/) nemohou zachovat interaktivní hypertextové odkazy; označte každou akci při auditu pro tyto výstupy.

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

    // Serializovat ploché řádky této zprávy bez další závislosti na JSON.
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

S výše vytvořeným vstupem zpráva obsahuje pět řádků akcí. Odkaz při přejetí souboru a kliknutí na makro jsou odstraněny, zatímco HTTPS odkazy a vnitřní navigace mezi snímky zůstávají. Ověření vypíše nula zakázaných akcí. Vstup obsahující zakázané externí klikací URL také využívá větev nahrazení. Kontejner s povoleným kliknutím a zakázaným přejetím myší zachovává svou akci kliknutí.

Toto selektivní čištění se liší od [removeAllHyperlinks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--), který odstraňuje oba typy aktivace v celém vybraném rozsahu bez ohledu na politiku. Ověření zde kontroluje pouze akce hypertextových odkazů; neodstraňuje vložené VBA projekty, OLE objekty ani jiný aktivní obsah a nevaliduje exportovaný PDF ani HTML soubor.

## **Často kladené otázky**

**How can I link to a section or its first slide?**

Oddíly v PowerPointu seskupují snímky, ale vnitřní hypertextový odkaz cílí na konkrétní snímek. Pro vytvoření navigace na oddíl odkazujte na první snímek v tomto oddíle.

**Can I attach a hyperlink to master slide elements so it works on all slides?**

Ano. Prvky hlavního snímku a rozložení podporují hypertextové odkazy. Odkazy na těchto prvcích jsou k dispozici během prezentace na snímcích, které používají odpovídající hlavní snímek nebo rozložení.

**Will hyperlinks be preserved when exporting to PDF, HTML, images, or video?**

Podporované exporty do PDF a HTML mohou zachovat hypertextové odkazy; rastrové obrázky a video to nemohou. Viz úvahy o exportu v [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).