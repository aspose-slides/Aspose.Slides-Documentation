---
title: Použít nebo změnit rozvržení snímků na Androidu
linktitle: Rozvržení snímku
type: docs
weight: 60
url: /cs/androidjava/slide-layout/
keywords:
- rozvržení snímku
- rozvržení obsahu
- zástupný prvek
- návrh prezentace
- návrh snímku
- nepoužité rozvržení
- viditelnost zápatí
- titulní snímek
- nadpis a obsah
- hlavička sekce
- dva obsahy
- srovnání
- pouze nadpis
- prázdné rozvržení
- obsah s titulkem
- obrázek s titulkem
- nadpis a svislý text
- svislý nadpis a text
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Používejte, vytvářejte a upravujte rozvržení snímků v Aspose.Slides pro Android pomocí Javy, přidávejte zástupné prvky, odstraňujte nepoužitá rozvržení a ovládejte viditelnost zápatí."
---
## **Přehled**

Rozložení snímku určuje pozice a formátování zástupných prvků, jako jsou nadpisy, text, obrázky, grafy a tabulky. Použití rozložení poskytuje snímkům konzistentní strukturu a zároveň umožňuje každému snímku obsahovat vlastní data.

Nejčastější rozložení jsou:

- **Titulek snímku**: Obsahuje zástupné prvky nadpisu a podnadpisu.
- **Nadpis a obsah**: Obsahuje zástupný prvek nadpisu a obecný zástupný prvek pro obsah.
- **Prázdný**: Neobsahuje žádné zástupné prvky a je užitečný, když bude každý tvar umístěn ručně.

## **Pochopení dědičnosti rozložení**

Prezentace má tři související úrovně:

1. [master slide](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imasterslide/) určuje motiv, sdílené formátování, pozadí a společné objekty.
1. [layout slide](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilayoutslide/) patří k masteru a určuje konkrétní uspořádání zástupných prvků.
1. [normal slide](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islide/) používá jedno rozložení a ukládá obsah zadaný pro tento snímek.

Normální snímek dědí motiv a formátování ze svého rozložení a rozložení dědí ze svého masteru. Hodnota nastavená přímo na normálním snímku přepíše zděděnou hodnotu na této úrovni. Když je vytvořen normální snímek, jeho tvary zástupných prvků jsou vygenerovány podle vybraného rozložení, zatímco obsah zadaný do těchto zástupných prvků patří k normálnímu snímku.

Přidejte požadované zástupné prvky do rozložení před vytvořením snímků z něj. Přidání dalšího zástupného prvku do rozložení později automaticky nepřidá odpovídající tvar zástupného prvku do existujících normálních snímků.

Tento vztah má dva důležité důsledky:

- Změna zděděného formátování nebo existující geometrie zástupného prvku v rozložení může aktualizovat každý snímek, který na něj závisí. Před úpravou rozložení, které je již používáno, zkontrolujte jeho závislé snímky a prověřte výslednou prezentaci.
- Rozložení, které je stále používáno snímkem, nelze odstranit. Předtím přesuňte jeho závislé snímky na jiné rozložení nebo odstraňte jen nepoužívaná rozložení.

Další informace o nejvyšší úrovni této hierarchie naleznete v [Slide Master](/slides/cs/androidjava/slide-master/).

## **Výběr a použití rozložení snímku**

Používejte typ rozložení, když prezentace dodržuje standardní definice rozložení PowerPointu. Názvy rozložení lze upravovat a lokalizovat, takže výběr založený na názvu je méně spolehlivý, pokud neovládáte zdrojovou šablonu.

Následující příklad hledá **Title and Content** na prvním masteru. Pokud není toto rozložení k dispozici, úmyslně přepne na **Blank**. Druhá kontrola na null je nutná, protože prezentace může obsahovat pouze vlastní rozložení. Vybrané rozložení je následně aplikováno na první normální snímek pomocí metody [ISlide.setLayoutSlide](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islide/#setLayoutSlide-com.aspose.slides.ILayoutSlide-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterLayoutSlideCollection layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide targetLayout = layoutSlides.getByType(SlideLayoutType.TitleAndObject);

    if (targetLayout == null) {
        targetLayout = layoutSlides.getByType(SlideLayoutType.Blank);
    }

    if (targetLayout == null) {
        throw new IllegalStateException("The first master does not contain a suitable layout slide.");
    }

    presentation.getSlides().get_Item(0).setLayoutSlide(targetLayout);
    presentation.save("output-with-new-layout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Změna rozložení snímku neodstraňuje obyčejné tvary přidané přímo do snímku. Nicméně pozice zástupných prvků, zděděné formátování a shoda mezi existujícími zástupnými prvky a novým rozložením se mohou změnit, proto při přechodu mezi výrazně odlišnými rozloženími zkontrolujte výstup.

## **Přidání rozložení snímku**

Výběr a vytvoření jsou oddělené operace. Předchozí příklad vybral existující rozložení; nevytvořil ho. Pro vytvoření rozložení zavolejte metodu [IMasterLayoutSlideCollection.add](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imasterlayoutslidecollection/#add-byte-java.lang.String-) na kolekci rozložení cílového masteru.

Následující příklad vždy přidá nové rozložení **Title and Content** s názvem `Report Title and Content` a poté přidá normální snímek, který je na něm založen. Názvy rozložení musí být v kolekci jedinečné.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide reportLayout = masterSlide.getLayoutSlides().add(SlideLayoutType.TitleAndObject, "Report Title and Content");
    presentation.getSlides().addEmptySlide(reportLayout);

    presentation.save("output-with-report-layout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Přidejte rozložení jen tehdy, když šablona skutečně potřebuje další opakovaně použitelnou strukturu. Pokud již existuje vhodné rozložení, vyberte a znovu jej použijte místo vytvoření duplikátu.

## **Přidání zástupných prvků do rozložení snímku**

Metoda [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) poskytuje [ILayoutPlaceholderManager](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilayoutplaceholdermanager/) pro přidávání tvarů zástupných prvků do rozložení.

| PowerPoint Placeholder | `ILayoutPlaceholderManager` Method |
| ---------------------- | ---------------------------------- |
| ![Content](content.png) | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addContentPlaceholder-float-float-float-float-) |
| ![Content (Vertical)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalContentPlaceholder-float-float-float-float-) |
| ![Text](text.png) | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addTextPlaceholder-float-float-float-float-) |
| ![Text (Vertical)](textV.png) | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalTextPlaceholder-float-float-float-float-) |
| ![Picture](picture.png) | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addPicturePlaceholder-float-float-float-float-) |
| ![Chart](chart.png) | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addChartPlaceholder-float-float-float-float-) |
| ![Table](table.png) | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addTablePlaceholder-float-float-float-float-) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addSmartArtPlaceholder-float-float-float-float-) |
| ![Media](media.png) | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addMediaPlaceholder-float-float-float-float-) |
| ![Online Image](onlineImage.png) | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addOnlineImagePlaceholder-float-float-float-float-) |

Následující příklad ověří, že rozložení **Blank** existuje, přidá k němu čtyři zástupné prvky a poté vytvoří normální snímek, který použije upravené rozložení. Pořadí je úmyslné: zástupné prvky jsou přidány před vytvořením normálního snímku, takže Aspose.Slides může vygenerovat odpovídající tvary zástupných prvků na tomto snímku.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    if (blankLayout == null) {
        throw new IllegalStateException("The presentation does not contain a Blank layout slide.");
    }

    ILayoutPlaceholderManager placeholderManager = blankLayout.getPlaceholderManager();
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    presentation.getSlides().addEmptySlide(blankLayout);
    presentation.save("output-with-placeholders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![The placeholders on the layout slide](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Změna zděděného formátování nebo geometrie existujících zástupných prvků rozložení může ovlivnit závislé snímky. Nově přidaný zástupný prvek rozložení se nevyplní do existujících normálních snímků. Testujte změny rozložení na kopii prezentace a zkontrolujte každý závislý snímek.
{{% /alert %}}

## **Odstranění nepoužívaných rozložení snímků**

Pro odstranění rozložení, na která neodkazuje žádný normální snímek, použijte metodu [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-). Metoda ponechá rozložení, která jsou stále používána, nedotčena.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);
    presentation.save("output-without-unused-layouts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pro odstranění konkrétního rozložení nejprve použijte jeho metodu [hasDependingSlides](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilayoutslide/#hasDependingSlides--) nebo [getDependingSlides](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilayoutslide/#getDependingSlides--). Před zavoláním [ILayoutSlide.remove](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilayoutslide/#remove--) přesuňte všechny závislé snímky. Pokus o odstranění použitého rozložení vyvolá výjimku [PptxEditException](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/pptxeditexception/).

## **Řízení viditelnosti zápatí na rozložení snímku**

Rozložení má vlastní zástupné prvky zápatí, čísla snímku a data/času. Pro řízení těchto zástupných prvků pro jedno rozložení použijte metodu [ILayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilayoutslide/#getHeaderFooterManager--). To je užitečné, například když rozložení obsahu má zobrazovat zápatí, ale rozložení titulku ne.

Následující příklad bezpečně vybere rozložení a zobrazí jeho prvky zápatí:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject);

    if (layoutSlide == null) {
        layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    }

    if (layoutSlide == null) {
        throw new IllegalStateException("The presentation does not contain a suitable layout slide.");
    }

    ILayoutSlideHeaderFooterManager headerFooterManager = layoutSlide.getHeaderFooterManager();
    headerFooterManager.setFooterVisibility(true);
    headerFooterManager.setSlideNumberVisibility(true);
    headerFooterManager.setDateTimeVisibility(true);
    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("output-with-layout-footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Řízení viditelnosti zápatí na masteru a jeho podřízených rozloženích**

Pro uplatnění jednotných nastavení zápatí v celé hierarchii masteru použijte metodu [IMasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imasterslide/#getHeaderFooterManager--). Propagační metody [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imasterslideheaderfootermanager/) působí na master a jeho závislé rozložení snímků i normální snímky; necílí pouze na jeden normální snímek.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();
    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);
    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("output-with-master-footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Často kladené otázky**

**Jaký je rozdíl mezi master snímkem a layout snímkem?**

Master snímek určuje motiv a sdílené formátování prezentace. Layout snímek patří k masteru a definuje jedno opakovaně použitelné uspořádání zástupných prvků. Normální snímky používají tato rozložení a ukládají obsah specifický pro konkrétní snímek.

**Mohu zkopírovat layout snímek z jedné prezentace do druhé?**

Ano. Přidejte kopii do cílové kolekce pomocí metody [addClone](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/igloballayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-). Při kopírování mezi prezentacemi také ověřte písma, motivy, obrázky a další zdroje použité ve zdrojovém rozložení.

**Co se stane, když upravím rozložení, které je již používáno?**

Závislé snímky zdědí změny rozložení, pokud místně nepřepíšou ovlivněné formátování nebo objekty. Geometrie zástupných prvků a zděděné styly se tak mohou změnit na mnoha snímcích najednou. Před úpravou rozložení použijte [getDependingSlides](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilayoutslide/#getDependingSlides--) k určení ovlivněných snímků.

**Co se stane, když odstraním rozložení, které je stále používáno?**

Aspose.Slides vyvolá výjimku [PptxEditException](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/pptxeditexception/). Nejprve přesuňte závislé snímky, nebo použijte [removeUnusedLayoutSlides](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) k odstranění jen neodkazovaných rozložení.