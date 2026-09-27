---
title: Vytvořte prezentace v Javě
linktitle: Vytvořit prezentaci
type: docs
weight: 10
url: /cs/java/create-presentation/
keywords:
- vytvořit prezentaci
- nová prezentace
- vytvořit PPT
- nový PPT
- vytvořit PPTX
- nový PPTX
- vytvořit ODP
- nový ODP
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Vytvářejte prezentace v Javě pomocí Aspose.Slides — vytvářejte soubory PPT, PPTX a ODP, využijte podporu OpenDocument a ukládejte je programově pro spolehlivé výsledky."
---
## **Přehled**

Tento článek ukazuje, jak vytvořit prezentaci v Aspose.Slides, přidat tvar s textem na její první snímek a výsledek uložit jako soubor PPTX. Pro otevření existující prezentace a uložení do jiného formátu viz [Open Presentations](/slides/cs/java/open-presentation/) a [Save Presentations](/slides/cs/java/save-presentation/). Krátké FAQ na konci pokrývá běžné otázky o formátech, šablonách, velikosti snímků, jednotkách, využití paměti, vláknování, licencování, digitálních podpisech a podpoře VBA.

Než začnete, přidejte Aspose.Slides for Java do svého projektu z Maven repozitáře Aspose. Viz [Installation](/slides/cs/java/installation/) pro nastavení Maven a pro požadavky na Linux.

## **Vytvoření prezentace**

Vytvoření souboru PowerPoint od nuly v Aspose.Slides for Java začíná instancí třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/). Konstruktor poskytuje prázdnou prezentaci s jedním snímkem, připravenou pro tvary, text, grafy nebo jakýkoli jiný obsah, který vaše aplikace potřebuje. Po úpravě tohoto snímku nebo přidání nových můžete výsledek uložit do formátů PPTX, staršího PPT nebo OpenDocument.

Pro vytvoření prezentace a umístění tvaru s textem na její první snímek postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/). Nová prezentace již obsahuje jeden prázdný snímek.  
2. Získejte tento snímek podle jeho indexu 0 z kolekce vrácené metodou [getSlides](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#getSlides--).  
3. Přidejte [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/) typu `Cloud` pomocí metody [addAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) a nastavte její text metodou [setText](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/#setText-java.lang.String-).  
4. Uložte prezentaci jako soubor PPTX pomocí metody [save](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#save-java.lang.String-int-).

Níže uvedený příklad je kompletní program. V Maven projektu podle [Installation](/slides/cs/java/installation/) jej uložte jako *src/main/java/HelloSlides.java* a spusťte `mvn compile exec:java`.

```java
import com.aspose.slides.*;

public class HelloSlides {
    public static void main(String[] args) {
        // Vytvořte prezentaci. Již obsahuje jeden prázdný snímek.
        Presentation presentation = new Presentation();
        try {
            // Získejte první snímek.
            ISlide slide = presentation.getSlides().get_Item(0);

            // Přidejte tvar mraku a vložte do něj text.
            IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80);
            autoShape.getTextFrame().setText("Hello, Aspose!");

            // Uložte prezentaci jako soubor PPTX.
            presentation.save("new_presentation.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

Levý horní roh mraku je od levého okraje snímku vzdálen 20 bodů a od horního okraje také 20 bodů; tvar má šířku 200 bodů a výšku 80 bodů. Program uloží *new_presentation.pptx* s jedním snímkem, který obsahuje mrak a jeho text. Bez licence Aspose.Slides také přidá vodotisk hodnocení na každý uložený snímek; viz [Licensing](/slides/cs/java/licensing/).

Výsledek:

![Nová prezentace](new_presentation.png)

## **Často kladené otázky**

### Do jakých formátů mohu uložit novou prezentaci?

Můžete uložit do [PPTX, PPT a ODP](/slides/cs/java/save-presentation/) a exportovat do [PDF](/slides/cs/java/convert-powerpoint-to-pdf/), [XPS](/slides/cs/java/convert-powerpoint-to-xps/), [HTML](/slides/cs/java/convert-powerpoint-to-html/), [SVG](/slides/cs/java/render-a-slide-as-an-svg-image/) a [obrázků](/slides/cs/java/convert-powerpoint-to-png/), mezi dalšími.

### Mohu začít ze šablony (POTX/POTM) a uložit jako běžný PPTX?

Ano. Načtěte šablonu a uložte do požadovaného formátu; formáty POTX/POTM/PPTM a podobné jsou [podporovány](/slides/cs/java/supported-file-formats/).

### Jak mohu řídit velikost snímku/poměr stran při vytváření prezentace?

Nastavte [velikost snímku](/slides/cs/java/slide-size/) (včetně předvoleb jako 4:3 a 16:9 nebo vlastních rozměrů) a zvolte, jak má být obsah škálován.

### V jakých jednotkách jsou měřeny velikosti a souřadnice?

V bodech: 1 palec odpovídá 72 jednotkám.

### Jak zvládnout velmi velké prezentace (s mnoha mediálními soubory) pro snížení využití paměti?

Použijte [strategie správy BLOB](/slides/cs/java/manage-blob/), omezte ukládání do paměti využitím dočasných souborů a upřednostněte workflow založené na souborech před čistě paměťovými proudy.

### Mohu vytvářet/ukládat prezentace paralelně?

Na stejnou instanci [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) nemůžete pracovat z [více vláken](/slides/cs/java/multithreading/). Spusťte samostatné, izolované instance na každé vlákno nebo proces.

### Jak odstranit vodotisk z hodnocení a omezení?

[Použijte licenci](/slides/cs/java/licensing/) jednou na proces. XML licence musí zůstat nezměněno a nastavení licence by mělo být synchronizováno, pokud jsou zapojena více vláken.

### Mohu digitálně podepsat vytvořený PPTX?

Ano. [Digitální podpisy](/slides/cs/java/digital-signature-in-powerpoint/) (přidávání i ověřování) jsou pro prezentace podporovány.

### Jsou makra (VBA) podporována v vytvořených prezentacích?

Ano. Můžete [vytvářet/upravovat VBA projekty](/slides/cs/java/presentation-via-vba/) a ukládat soubory s povolenými makry, například PPTM/PPSM.