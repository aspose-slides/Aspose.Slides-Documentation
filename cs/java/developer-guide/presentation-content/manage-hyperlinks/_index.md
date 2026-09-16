---
title: Spravovat hypertextové odkazy v prezentaci v Javě
linktitle: Spravovat hypertextové odkazy
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
- textový hypertextový odkaz
- hypertextový odkaz na snímek
- hypertextový odkaz na tvar
- hypertextový odkaz na obrázek
- hypertextový odkaz na video
- mutabilní hypertextový odkaz
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Přidávejte, formátujte, aktualizujte a odstraňujte hypertextové odkazy v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Javu, s využitím příkladů v Javě."
---
## **Úvod**

Hypertextový odkaz spojuje obsah prezentace s webovou stránkou nebo s místem v rámci prezentace. V PowerPointu hypertextové odkazy běžně slouží ke dvěma účelům:

* Otevřít webovou stránku z textu, tvaru nebo mediálního rámce.
* Přesunout se na jiný snímek, například z obsahu.

Aspose.Slides for Java vám umožňuje přidávat tyto odkazy, řídit jejich vzhled a zvuk, aktualizovat jejich vlastnosti a odstraňovat je. Níže uvedené příklady ukazují, jak pracovat s hypertextovými odkazy na jednotlivých prvcích a jak získat přístup k hypertextovým odkazům na úrovni prezentace, snímku nebo textového rámce.

{{% alert color="info" title="Note" %}}
Můžete také upravovat prezentace pomocí [bezplatného online editoru Aspose PowerPoint](https://products.aspose.app/slides/cs/editor).
{{% /alert %}} 

## **Přidání URL hypertextových odkazů**

Můžete přiřadit URL webové stránky k textu, tvaru nebo mediálnímu rámci. Prvek, ke kterému hypertextový odkaz přiřadíte, určuje klikací oblast: textová část odkazuje vybraný text, zatímco tvar nebo rámec odkazuje na objekt snímku.

### **Přidání URL hypertextových odkazů do textu**

Pro propojení textu s webovou stránkou předávejte [Hyperlink](https://reference.aspose.com/slides/cs/java/com.aspose.slides/hyperlink/) metodě [setHyperlinkClick](https://reference.aspose.com/slides/cs/java/com.aspose.slides/portionformat/#setHyperlinkClick-com.aspose.slides.IHyperlink-) textové části, jak je ukázáno níže. Pouze tato část textu se stane klikací.

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

### **Přidání URL hypertextových odkazů do tvarů a mediálních rámců**

Aby byl tvar nebo rámec klikací, zavolejte jeho metodu [setHyperlinkClick](https://reference.aspose.com/slides/cs/java/com.aspose.slides/shape/#setHyperlinkClick-com.aspose.slides.IHyperlink-). Hypertextový odkaz patří samotnému objektu, nikoli textové části uvnitř něj.

Stejný postup platí pro obrazové, audio a video rámy: přiřaďte hypertextový odkaz rámci a v případě potřeby zavolejte [setTooltip](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-).

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

## **Použití hypertextových odkazů k vytvoření obsahu**

Interní hypertextové odkazy umožňují čtenářům přejít z obsahu na konkrétní snímek. Následující příklad používá [setInternalHyperlinkClick](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ihyperlinkmanager/#setInternalHyperlinkClick-com.aspose.slides.ISlide-) k propojení textu „Page 2“ na prvním snímku se druhým snímkem.

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

## **Formátování hypertextových odkazů**

### **Barva**

Metoda [setColorSource](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ihyperlink/#setColorSource-int-) rozhraní [IHyperlink](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ihyperlink/) určuje, zda hypertextový odkaz používá barvu hypertextových odkazů prezentace nebo formátování textové části. Pro použití vlastní barvy textu vyberte [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/hyperlinkcolorsource/) a nastavte barvu výplně části. Tato funkce byla zavedena v PowerPointu 2019; starší verze tuto volbu nepoužívají.

Následující příklad přidává dva textové hypertextové odkazy na stejný snímek. První používá červenou výplň textu, zatímco druhý zachovává výchozí barvu hypertextového odkazu.

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

Hypertextový odkaz může při aktivaci přehrát zvuk nebo zastavit již přehrávaný zvuk. Použijte následující metody pro nastavení těchto chování:

- [IHyperlink.setSound](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ihyperlink/#setSound-com.aspose.slides.IAudio-) určuje audio spojené s hypertextovým odkazem.
- [IHyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ihyperlink/#setStopSoundOnClick-boolean-) řídí, zda aktivace hypertextového odkazu zastaví předchozí zvuk.

#### **Přidání zvuku k hypertextovému odkazu**

Následující příklad načte `sampleaudio.wav` a přiřadí jej tlačítku na prvním snímku. Kliknutí na tlačítko přehraje zvuk a přejde na další snímek. Druhý tvar na tomto snímku zastaví předchozí zvuk po kliknutí, aniž by provedl navigační akci.

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

#### **Extrahování zvuku z hypertextového odkazu**

Následující příklad otevře výše vytvořenou prezentaci a načte audio hypertextového odkazu prvního tvaru do paměti pomocí [getSound](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ihyperlink/#getSound--) a [getBinaryData](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iaudio/#getBinaryData--).

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

### **Nástrojový tip a nastavení interakce**

Můžete zavolat následující metody rozhraní [IHyperlink](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ihyperlink/) po přiřazení hypertextového odkazu k textu nebo tvaru:

- [setTooltip](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) nastaví text, který může prohlížeč zobrazit jako nápovědu pro odkaz.
- [setTargetFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ihyperlink/#setTargetFrame-java.lang.String-) určuje cílový rámec v rámci rodičovské HTML sady rámců, pokud je to relevantní.
- [setHistory](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ihyperlink/#setHistory-boolean-) řídí, zda aktivace odkazu přidá jeho cíl do seznamu zobrazených hypertextových odkazů.
- [setHighlightClick](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ihyperlink/#setHighlightClick-boolean-) řídí, zda je hypertextový odkaz po kliknutí zvýrazněn.

## **Odstranění hypertextových odkazů z prezentací**

Použijte [getAnyHyperlinks](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) abyste shromáždili kontejnery hypertextových odkazů, včetně odkazů na textové části, před jejich změnou. Následující příklad odstraňuje oba typy aktivace z prvního snímku. Chcete-li odstranit jen jeden typ, zavolejte pouze [removeHyperlinkClick](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) nebo [removeHyperlinkMouseOver](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--); odstranění akce kliknutí neodstraňuje její akci při najetí myší.

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

Pro bezpodmínečné odstranění [removeAllHyperlinks](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) odstraní oba typy aktivace ve vybraném rozsahu jedním voláním. Pro selektivní vyčištění a zahrnutí masterů, rozložení a poznámek viz [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Vytvoření kompletní inventury hypertextových odkazů**

Před distribucí prezentace proveďte inventuru jejích interaktivních akcí i webových odkazů. [getAnyHyperlinks](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) vrací objekty [IHyperlinkContainer](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ihyperlinkcontainer/), nikoli plochý seznam řetězců URL. Prozkoumejte na každém kontejneru jak [getHyperlinkClick](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) , tak [getHyperlinkMouseOver](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) . Jsou nezávislé: stejný kontejner může poskytovat oba typy akcí, takže kompletní zpráva potřebuje až dva řádky na kontejner.

Skenování pouze hypertextových odkazů na úrovni tvaru může opomenout odkazy připojené k textovým částem. Místo toho dotazujte vhodný rozsah a uchovávejte vrácené kontejnery, abyste je později mohli aktualizovat nebo odstranit jejich akce.

### **Dotazování na rozsahy prezentace, snímku a textového rámce**

Rozhraní [IHyperlinkQueries](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ihyperlinkqueries/) je k dispozici přes [IPresentation.getHyperlinkQueries](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentation/#getHyperlinkQueries--), [IBaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibaseslide/#getHyperlinkQueries--), a [ITextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/#getHyperlinkQueries--). Každý rozsah podporuje stejné dotazy:

- [getHyperlinkClicks](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ihyperlinkqueries/#getHyperlinkClicks--) vrací kontejnery s akcí kliknutí.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ihyperlinkqueries/#getHyperlinkMouseOvers--) vrací kontejnery s akcí při najetí myší.
- [getAnyHyperlinks](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) vrací kontejnery s jednou nebo oběma akcemi.

Následující příklad vytvoří `hyperlink-audit-input.pptx` s externím odkazem kliknutí, odkazem na soubor při najetí myší, interní navigací mezi snímky, textovým odkazem při najetí myší a makrovou akcí. Neprovedou se žádné z těchto akcí. Stejné tři dotazy fungují v každém rozsahu; počty popisují kontejnery, nikoli celkový počet akcí. Rozsah textového rámce vylučuje odkazy samotného obklopujícího tvaru.

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

Pro tento příklad dotazy na prezentaci a snímek uvádějí každé tři kontejnery s akcí kliknutí, dva kontejnery s akcí při najetí myší a tři kontejnery s jednou z akcí. Dotaz na textový rámec uvádí po jednom kontejneru v každé kategorii.

### **Klasifikace akcí a cílů**

Použijte [IHyperlink.getActionType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ihyperlink/#getActionType--) , abyste interpretovali akci před interpretací jejího cíle. Hodnoty [HyperlinkActionType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/hyperlinkactiontype/) zahrnují více než jen webovou navigaci:

| Hodnoty | Význam pro audit |
| --- | --- |
| `Hyperlink` | Externí hypertextový odkaz; zkontrolujte URL a její schéma. |
| `JumpSpecificSlide` | Interní navigace na konkrétní snímek. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Vestavěná navigace v prezentaci, řešená v kontextu prezentace. |
| `JumpEndShow`, `StartCustomSlideShow` | Ukončení aktuální prezentace nebo spuštění vlastní prezentace. |
| `StartMacro` | Spuštění makra. |
| `StartProgram` | Spuštění programu. |
| `OpenFile`, `OpenPresentation` | Otevření souboru nebo jiné prezentace; kontrolovat odděleně od webových URL. |
| `StartStopMedia` | Spuštění nebo zastavení přehrávání médií. |
| `NoAction`, `Unknown` | Žádná navigační akce, nebo neznámá akce vyžadující kontrolu. |

Externí cíle načtěte pomocí [getExternalUrl](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ihyperlink/#getExternalUrl--), konkrétní interní cíle pomocí [getTargetSlide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ihyperlink/#getTargetSlide--). Interní akce a vestavěné příkazy nemusí mít externí URL; prázdná URL neznamená, že kontejner nemá žádnou akci. Zachovejte hodnotu vrácenou metodou [getExternalUrlOriginal](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) , pokud se liší od normalizované URL, a zahrňte nástrojový tip vrácený metodou [getTooltip](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ihyperlink/#getTooltip--) , pokud je dostupný.

### **Zpráva, sanitizace a ověření hypertextových odkazů**

Následující Java příklad načte existující prezentaci (použijte soubor vytvořený výše), zapíše `hyperlink-audit.json`, použije politiku, uloží `hyperlink-sanitized.pptx` a znovu jej otevře k opětovné kontrole obou typů aktivace. Před změnou shromažďuje kontejnery a používá porovnání odkazů, aby se zabránilo dvojímu zpracování stejného kontejneru. Dotazy na prezentaci zahrnují běžné snímky; pro inventuru v celém balíčku také explicitně dotazuje mastery, rozložení, poznámky a mastery poznámek a letáků, pokud jsou přítomny.

Zpráva zaznamenává číslování snímků od jedné a [getSlideId](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibaseslide/#getSlideId--) , pokud je dostupný. [ISlideComponent.getSlide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islidecomponent/#getSlide--) poskytuje vlastní snímek pro podporované kontejnery. Mastery, rozložení a poznámky nemají běžné číslování snímků a jsou identifikovány podle svého rozsahu. Kontejnery tvarů a kontejnery formátování textových částí jsou označeny zvlášť; ostatní typy kontejnerů si zachovávají název svého runtime typu. Každý kontejner získá v rámci zprávy lokální ID, aby mohly být propojeny jeho dvě akce. Zpráva ukládá typy akcí jako celočíselné konstanty definované v Java výčtu.

Tato záměrně restriktivní politika aplikace povoluje jen absolutní HTTPS URL a platné interní cíle snímků. Odmítá makra, programy, souborové akce, jiné akce prezentace, neznámé akce a jiné schémata URL. Tato odmítnutí jsou rozhodnutí politiky, nikoli bezpečnostní verdikt Aspose.Slides. Pouze HTTPS nestanovuje důvěru: přidejte seznamy povolených hostitelů a další kontroly pro vaši aplikaci. Kontrolují se jak původní, tak normalizované externí URL. Příklad audituje metadata bez sledování odkazů nebo spouštění akcí.

Pro nápravu kontejnerů metoda [getHyperlinkManager](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) podporuje [setExternalHyperlinkClick](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-), [removeHyperlinkClick](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--), a [removeHyperlinkMouseOver](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--). Zde jsou zakázané externí odkazy kliknutí nahrazeny pevnou HTTPS vstupní stránkou; ostatní zakázané kliknutí a zakázané akce při najetí myší jsou odstraněny nezávisle. Nastavte `replaceExternalClicks` na `false`, chcete-li místo toho odstranit všechna porušení politiky. Před nasazením vyberte náhradní stránku vlastněnou aplikací.

Exportní příznak zprávy používá konzervativní politiku revize PDF: označte akce při najetí myší a vše, co není externí odkaz nebo konkrétní skok na snímek, jako potenciálně nepodporované. Jedná se o návod k revizi, nikoli test schopnosti ani záruku, že neoznačené odkazy přežijí export. Podporované exporty do [PDF](/slides/cs/java/convert-powerpoint-to-pdf/) a [HTML](/slides/cs/java/convert-powerpoint-to-html/) mohou zachovat hypertextové odkazy v závislosti na akci, nastavení exportu a prohlížeči. Rasterové [obrázky](/slides/cs/java/convert-powerpoint-to-png/) a [video](/slides/cs/java/convert-powerpoint-to-video/) nemohou zachovat interaktivní hypertextové odkazy; při auditu pro tyto výstupy označte každou akci.

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

S výše vytvořeným vstupem zpráva obsahuje pět řádků akcí. Odkaz na soubor při najetí myší a kliknutí na makro jsou odstraněny, zatímco HTTPS odkazy a interní navigace mezi snímky zůstávají. Ověření vypíše nula zakázaných akcí. Vstup obsahující zakázaný externí odkaz kliknutí také aktivuje větev nahrazení. Kontejner s povoleným kliknutím a zakázaným odkazem při najetí myší si zachovává akci kliknutí.

Toto selektivní čištění se liší od [removeAllHyperlinks](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--), který odstraňuje oba typy aktivace v celém vybraném rozsahu bez ohledu na politiku. Ověření zde kontroluje pouze akce hypertextových odkazů; neodstraňuje vložené projekty VBA, OLE objekty ani jiný aktivní obsah a neověřuje exportovaný PDF ani HTML soubor.

## **Často kladené otázky**

**Jak mohu odkazovat na sekci nebo její první snímek?**

Oddíly v PowerPointu seskupují snímky, ale interní hypertextový odkaz cílí na konkrétní snímek. Pro vytvoření navigace k sekci odkažte na první snímek v daném oddíle.

**Mohu připojit hypertextový odkaz k prvkům hlavního snímku, aby fungoval na všech snímcích?**

Ano. Prvky hlavního snímku a rozložení podporují hypertextové odkazy. Odkazy na těchto prvcích jsou k dispozici během prezentace na snímcích, které používají odpovídající master nebo rozložení.

**Zůstanou hypertextové odkazy zachovány při exportu do PDF, HTML, obrázků nebo videa?**

Podporované exporty do PDF a HTML mohou zachovat hypertextové odkazy; rastrové obrázky a video nemohou. Viz úvahy o exportu v [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).