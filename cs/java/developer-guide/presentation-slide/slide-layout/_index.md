---
title: Použít nebo změnit rozvržení snímků v Javě
linktitle: Rozvržení snímku
type: docs
weight: 60
url: /cs/java/slide-layout/
keywords:
- rozvržení snímku
- rozvržení obsahu
- zástupný objekt
- návrh prezentace
- návrh snímku
- nepoužité rozvržení
- viditelnost zápatí
- titulní snímek
- název a obsah
- hlavička sekce
- dva obsahy
- porovnání
- pouze název
- prázdné rozvržení
- obsah s popiskem
- obrázek s popiskem
- název a svislý text
- svislý název a text
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Použijte, vytvářejte a upravujte rozvržení snímků v Aspose.Slides pro Javu, přidávejte zástupné objekty, odstraňujte nepoužitá rozvržení a řiďte viditelnost zápatí."
---
## **Přehled**

Rozvržení snímku definuje pozice a formátování zástupných objektů, jako jsou nadpisy, text, obrázky, grafy a tabulky. Použití rozvržení poskytuje snímkům konzistentní strukturu a zároveň umožňuje každému snímku obsahovat vlastní obsah.

Nejčastější rozvržení zahrnují:

- **Title Slide**: Obsahuje zástupné objekty pro název a podnadpis.
- **Title and Content**: Obsahuje zástupný objekt pro název a obecný obsahový zástupný objekt.
- **Blank**: Neobsahuje žádné obsahové zástupné objekty a je užitečné, když bude každá forma umístěna ručně.

## **Pochopte dědičnost rozvržení**

Prezentace má tři související úrovně:

1. [master slide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imasterslide/) definuje motiv, sdílené formátování, pozadí a společné objekty.
2. [layout slide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilayoutslide/) patří k masteru a definuje konkrétní uspořádání zástupných objektů.
3. [normal slide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islide/) používá jedno rozvržení a ukládá obsah zadaný pro tento snímek.

Normální snímek dědí motiv a formátování ze svého rozvržení a rozvržení dědí z masteru. Hodnota nastavená přímo na normálním snímku přepíše zděděnou hodnotu na této úrovni. Když je normální snímek vytvořen, jeho tvary zástupných objektů jsou vygenerovány z vybraného rozvržení, zatímco obsah zadaný do těchto zástupných objektů patří normálnímu snímku.

Přidejte požadované zástupné objekty do rozvržení předtím, než z něj vytváříte snímky. Přidání dalšího zástupného objektu do rozvržení později automaticky nepřidá odpovídající tvar zástupného objektu do existujících normálních snímků.

Tento vztah má dva důležité důsledky:

- Změna zděděného formátování nebo geometrii existujících zástupných objektů v rozvržení může aktualizovat každý snímek, který na něm závisí. Před úpravou rozvržení, které je již používáno, proveďte kontrolu jeho závislých snímků a zkontrolujte výslednou prezentaci.
- Rozvržení, které je stále používáno nějakým snímkem, nelze odstranit. Nejprve přiřaďte jeho závislé snímky k jinému rozvržení nebo odstraňte jen nepoužívaná rozvržení.

Pro více informací o nejvyšší úrovni této hierarchie viz [Slide Master](/slides/cs/java/slide-master/).

## **Vyberte a použijte rozvržení snímku**

Používejte typ rozvržení, když prezentace následuje standardní definice rozvržení PowerPointu. Názvy rozvržení jsou upravitelná uživatelem a mohou být lokalizována, takže výběr podle názvu je méně spolehlivý, pokud neovládáte zdrojovou šablonu.

Následující příklad hledá **Title and Content** na prvním masteru. Pokud toto rozvržení není k dispozici, úmyslně přejde na **Blank**. Druhá kontrola na null je nutná, protože prezentace může obsahovat pouze vlastní rozvržení. Vybrané rozvržení je pak použito na první normální snímek pomocí metody [ISlide.setLayoutSlide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islide/#setLayoutSlide-com.aspose.slides.ILayoutSlide-).

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

Změna rozvržení snímku neodstraňuje běžné tvary přidané přímo do snímku. Nicméně pozice zástupných objektů, zděděné formátování a shoda mezi existujícími zástupnými objekty a novým rozvržením se mohou změnit, proto při přepínání mezi podstatně odlišnými rozvrženími kontrolujte výstup.

## **Přidat rozvržení snímku**

Výběr a vytvoření jsou samostatné operace. Předchozí příklad vybírá existující rozvržení; nevytváří jej. Pro vytvoření rozvržení zavolejte metodu [IMasterLayoutSlideCollection.add](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imasterlayoutslidecollection/#add-byte-java.lang.String-) na kolekci rozvržení cílového masteru.

Následující příklad vždy přidá nové rozvržení **Title and Content** pojmenované `Report Title and Content` a poté přidá normální snímek založený na tomto rozvržení. Názvy rozvržení musí být v kolekci jedinečné.

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

Přidávejte rozvržení jen tehdy, když šablona skutečně potřebuje další opakovaně použitelnou strukturu. Pokud již existuje vhodné rozvržení, vyberte a použijte jej místo vytváření duplikátu.

## **Přidat zástupné objekty do rozvržení snímku**

Metoda [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) poskytuje [ILayoutPlaceholderManager](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilayoutplaceholdermanager/) pro přidávání tvarů zástupných objektů do rozvržení.

| PowerPoint zástupný objekt       | Metoda `ILayoutPlaceholderManager` |
| --------------------------------- | ----------------------------------- |
| ![Obsah](content.png)             | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilayoutplaceholdermanager/#addContentPlaceholder-float-float-float-float-) |
| ![Obsah (vertikální)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalContentPlaceholder-float-float-float-float-) |
| ![Text](text.png)                 | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilayoutplaceholdermanager/#addTextPlaceholder-float-float-float-float-) |
| ![Text (vertikální)](textV.png)   | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalTextPlaceholder-float-float-float-float-) |
| ![Obrázek](picture.png)           | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilayoutplaceholdermanager/#addPicturePlaceholder-float-float-float-float-) |
| ![Graf](chart.png)                | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilayoutplaceholdermanager/#addChartPlaceholder-float-float-float-float-) |
| ![Tabulka](table.png)             | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilayoutplaceholdermanager/#addTablePlaceholder-float-float-float-float-) |
| ![SmartArt](smartart.png)         | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilayoutplaceholdermanager/#addSmartArtPlaceholder-float-float-float-float-) |
| ![Média](media.png)               | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilayoutplaceholdermanager/#addMediaPlaceholder-float-float-float-float-) |
| ![Online obrázek](onlineImage.png) | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilayoutplaceholdermanager/#addOnlineImagePlaceholder-float-float-float-float-) |

Následující příklad ověřuje, že rozvržení **Blank** existuje, přidá k němu čtyři zástupné objekty a poté vytvoří normální snímek, který používá upravené rozvržení. Pořadí je úmyslné: zástupné objekty jsou přidány před vytvořením normálního snímku, aby Aspose.Slides mohl vygenerovat odpovídající tvary zástupných objektů na tomto snímku.

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

![Zástupné objekty na rozvržení snímku](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Změna zděděného formátování nebo geometrie existujících zástupných objektů v rozvržení může ovlivnit závislé snímky. Nově přidaný zástupný objekt rozvržení není automaticky doplněn do existujících normálních snímků. Testujte změny rozvržení na kopii prezentace a kontrolujte každý závislý snímek.
{{% /alert %}}

## **Odstranit nepoužívaná rozvržení snímků**

Použijte metodu [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/cs/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) k odebrání rozvržení, na která neodkazuje žádný normální snímek. Metoda ponechá rozvržení, která jsou stále používána, beze změny.

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

Pro odebrání konkrétního rozvržení nejprve použijte jeho metodu [hasDependingSlides](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilayoutslide/#hasDependingSlides--) nebo [getDependingSlides](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilayoutslide/#getDependingSlides--). Před voláním [ILayoutSlide.remove](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilayoutslide/#remove--) přesuňte všechny závislé snímky. Pokus o odstranění rozvržení, které je používáno, vyvolá výjimku [PptxEditException](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pptxeditexception/).

## **Ovládání viditelnosti zápatí na rozvržení snímku**

Rozvržení má vlastní zástupné objekty zápatí, čísla snímku a datum‑čas. Použijte metodu [ILayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilayoutslide/#getHeaderFooterManager--) k řízení těchto zástupných objektů pro jedno rozvržení. To je užitečné například, když obsahová rozvržení mají zobrazovat zápatí, ale titulní rozvržení ne.

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

## **Ovládání viditelnosti zápatí na masteru a jeho podřízených rozvrženích**

Pro jednotné nastavení zápatí napříč hierarchií masteru použijte metodu [IMasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imasterslide/#getHeaderFooterManager--). Propagační metody [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imasterslideheaderfootermanager/) působí na master a jeho závislé rozvržení snímků i normální snímky; neovlivňují jen jeden normální snímek.

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

## **FAQ**

**Jaký je rozdíl mezi master snímkem a layout snímkem?**

Master snímek definuje motiv a sdílené formátování prezentace. Layout snímek patří k masteru a určuje jedno opakovatelné uspořádání zástupných objektů. Normální snímky používají tato rozvržení a ukládají specifický obsah snímku.

**Mohu zkopírovat layout snímek z jedné prezentace do druhé?**

Ano. Přidejte kopii do cílové kolekce pomocí metody [addClone](https://reference.aspose.com/slides/cs/java/com.aspose.slides/igloballayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-). Při kopírování mezi prezentacemi také ověřte písma, motivy, obrázky a další prostředky použité ve zdrojovém rozvržení.

**Co se stane, když upravím rozvržení, které je již používáno?**

Závislé snímky zdědí změny rozvržení, pokud lokálně nepřepíšou ovlivněné formátování nebo objekty. Geometrie zástupných objektů a zděděné stylování se tak mohou změnit na mnoha snímcích najednou. Použijte [getDependingSlides](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilayoutslide/#getDependingSlides--) k identifikaci ovlivněných snímků před úpravou rozvržení.

**Co se stane, když odstraním rozvržení, které je stále používáno?**

Aspose.Slides vyvolá výjimku [PptxEditException](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pptxeditexception/). Nejprve přiřaďte závislé snímky k jinému rozvržení, nebo použijte [removeUnusedLayoutSlides](https://reference.aspose.com/slides/cs/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) k odstranění pouze neodkazovaných rozvržení.