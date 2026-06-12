---
title: Vytváření prezentací v Javě
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
description: "Vytvářejte prezentace v Javě pomocí Aspose.Slides - vytvářejte soubory PPT, PPTX a ODP, využijte podporu OpenDocument a uložte je programově pro spolehlivé výsledky."
---
## **Přehled**

Tento článek ukazuje, jak vytvořit prezentaci v Aspose.Slides, přidat jednoduchý obsah na snímek a uložit výsledek jako soubor. Dále demonstruje, jak vytvořit a uložit novou prezentaci, otevřít existující prezentaci v podporovaném formátu a uložit ji do jiného formátu. Kromě toho článek obsahuje krátké FAQ pokrývající běžné otázky související s formáty, šablonami, velikostí snímků, jednotkami, využitím paměti, vlákny, licencováním, digitálními podpisy a podporou VBA.

## **Vytvoření prezentace**

Vytvoření souboru PowerPoint od nuly v Aspose.Slides pro Java je tak jednoduché, jako vytvořit instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/). Konstruktor automaticky poskytne prázdnou prezentaci s jedním snímkem, což vám dává okamžitý podklad pro tvary, text, grafy nebo jakýkoli jiný obsah, který vaše aplikace potřebuje. Jakmile tento snímek upravíte – nebo přidáte nové – můžete výsledek uložit do formátu PPTX, staršího PPT nebo dokonce OpenDocument. Krátký ukázkový kód níže ilustruje tento postup přidáním jednoduchého tvaru na první snímek.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte objekt [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/) typu `Cloud` pomocí metody `addAutoShape`, která je k dispozici v kolekci `Shapes`.
1. Přidejte text do automatického tvaru.
1. Uložte upravenou prezentaci jako soubor PPTX.

V níže uvedeném příkladu je na první snímek prezentace přidán tvar oblaku.

```java
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
Presentation presentation = new Presentation();
try {
    // Získejte první snímek.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Přidejte automatický tvar typu Cloud.
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    // Uložte prezentaci jako soubor PPTX.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Nová prezentace](new_presentation.png)

## **Často kladené otázky**

**Do jakých formátů mohu novou prezentaci uložit?**

Můžete uložit do formátů [PPTX, PPT a ODP](/slides/cs/java/save-presentation/), a exportovat do [PDF](/slides/cs/java/convert-powerpoint-to-pdf/), [XPS](/slides/cs/java/convert-powerpoint-to-xps/), [HTML](/slides/cs/java/convert-powerpoint-to-html/), [SVG](/slides/cs/java/convert-powerpoint-to-png/) a [obrázků](/slides/cs/java/convert-powerpoint-to-png/), mezi jinými.

**Mohu začít ze šablony (POTX/POTM) a uložit jako běžný PPTX?**

Ano. Načtěte šablonu a uložte do požadovaného formátu; formáty POTX/POTM/PPTM a podobné [jsou podporovány](/slides/cs/java/supported-file-formats/).

**Jak mohu při vytváření prezentace kontrolovat velikost snímku/poměr stran?**

Nastavte [velikost snímku](/slides/cs/java/slide-size/) (včetně předvoleb jako 4:3 a 16:9 nebo vlastních rozměrů) a zvolte, jak má být obsah škálován.

**V jakých jednotkách jsou měřeny velikosti a souřadnice?**

V bodech: 1 palec odpovídá 72 jednotkám.

**Jak mohu zpracovat velmi velké prezentace (s mnoha mediálními soubory) a snížit využití paměti?**

Použijte [strategie správy BLOB](/slides/cs/java/manage-blob/), omezte ukládání do paměti využitím dočasných souborů a upřednostněte workflow založené na souborech před čistě paměťovými proudy.

**Mohu vytvářet/ukládat prezentace paralelně?**

Nemůžete pracovat se stejnou instancí [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) z [více vláken](/slides/cs/java/multithreading/). Spusťte samostatné, izolované instance pro každé vlákno nebo proces.

**Jak odebrat vodoznak verze zkoušky a omezení?**

[Aplikujte licenci](/slides/cs/java/licensing/) jednou na proces. Licenční XML musí zůstat nezměněná a nastavení licence by mělo být synchronizováno, pokud je zapojeno více vláken.

**Mohu digitálně podepsat PPTX, který vytvořím?**

Ano. [Digitální podpisy](/slides/cs/java/digital-signature-in-powerpoint/) (přidávání a ověřování) jsou pro prezentace podporovány.

**Jsou maker (VBA) podporována v vytvořených prezentacích?**

Ano. Můžete [vytvářet/upravovat projekty VBA](/slides/cs/java/presentation-via-vba/) a ukládat soubory s makry, například PPTM/PPSM.