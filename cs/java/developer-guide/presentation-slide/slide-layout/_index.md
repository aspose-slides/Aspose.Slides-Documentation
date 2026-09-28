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
- úvodní snímek
- název a obsah
- hlavička sekce
- dva obsahy
- srovnání
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

Rozvržení snímku definuje pozice a formátování zástupných objektů, jako jsou nadpisy, text, obrázky, grafy a tabulky. Použití rozvržení poskytuje snímkům jednotnou strukturu a zároveň umožňuje, aby každý snímek obsahoval svůj vlastní obsah.

Nejčastější rozvržení zahrnují:

- **Úvodní snímek**: Obsahuje zástupné objekty pro název a podnadpis.
- **Název a obsah**: Obsahuje zástupný objekt pro název a obecný zástupný objekt pro obsah.
- **Prázdný**: Neobsahuje žádné zástupné objekty pro obsah a je užitečný, když bude každý tvar umístěn ručně.

## **Pochopení dědičnosti rozvržení**

Prezentace má tři související úrovně:

1. A [master slide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imasterslide/) definuje motiv, sdílené formátování, pozadí a společné objekty.
1. A [layout slide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilayoutslide/) patří k hlavnímu snímku a definuje konkrétní uspořádání zástupných objektů.
1. A [normal slide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islide/) používá jedno rozvržení a ukládá obsah zadaný pro tento snímek.

Normální snímek dědí motiv a formátování ze svého rozvržení a rozvržení dědí od svého hlavního snímku. Hodnota nastavená přímo na normálním snímku přepíše zděděnou hodnotu na této úrovni. Když je normální snímek vytvořen, jeho tvary zástupných objektů jsou generovány z vybraného rozvržení, zatímco obsah vložený do těchto zástupných objektů patří normálnímu snímku.

Přidejte požadované zástupné objekty do rozvržení před vytvořením snímků z něj. Přidání dalšího zástupného objektu do rozvržení později automaticky nepřidá odpovídající tvar zástupného objektu do existujících normálních snímků.

Tento vztah má dva důležité důsledky:

- Změna zděděného formátování nebo existující geometrie zástupných objektů v rozvržení může aktualizovat každý snímek, který na něm závisí. Před úpravou rozvržení, které je již používáno, zkontrolujte jeho závislé snímky a přezkoumejte výslednou prezentaci.
- Rozvržení, které je stále používáno nějakým snímkem, nelze odstranit. Nejdříve přiřaďte jeho závislé snímky k jinému rozvržení nebo odstraňte jen nepoužívaná rozvržení.

Pro další informace o nejvyšší úrovni této hierarchie viz [Slide Master](/slides/cs/java/slide-master/).

Pro skrytí zděděných log nebo dekorativních hlavních tvarů na jednom snímku nebo prostřednictvím sdíleného rozvržení viz [Control the Visibility of Master Graphics](/slides/cs/java/slide-master/). Příklad porovnává dva snímky používající stejný hlavní snímek.

## **Vyberte a použijte rozvržení snímku**

Použijte typ rozvržení, pokud prezentace následuje standardní definice rozvržení PowerPointu. Názvy rozvržení jsou upravitelné uživatelem a mohou být lokalizovány, takže výběr na základě názvu je méně spolehlivý, pokud neovládáte zdrojovou šablonu.

Následující příklad hledá **Title and Content** na prvním hlavním snímku. Pokud toto rozvržení není k dispozici, úmyslně přejde na **Blank**. Druhá kontrola na null je nezbytná, protože prezentace může obsahovat pouze vlastní rozvržení. Vybrané rozvržení je pak aplikováno na první normální snímek pomocí metody [ISlide.setLayoutSlide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islide/#setLayoutSlide-com.aspose.slides.ILayoutSlide-).

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

Změna rozvržení snímku neodstraňuje běžné tvary přidané přímo na snímek. Avšak pozice zástupných objektů, zděděné formátování a shoda mezi existujícími zástupnými objekty a novým rozvržením se mohou změnit, takže je třeba zkontrolovat výstup při přepínání mezi výrazně odlišnými rozvrženími.

## **Přidejte rozvržovací snímek**

Výběr a vytvoření jsou samostatné operace. Předchozí příklad vybere existující rozvržení; nevytvoří ho. Pro vytvoření rozvržení zavolejte metodu [IMasterLayoutSlideCollection.add](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imasterlayoutslidecollection/#add-byte-java.lang.String-) na kolekci rozvržení cílového hlavního snímku.

Následující příklad vždy přidá nové rozvržení **Title and Content** pojmenované `Report Title and Content` a poté přidá normální snímek založený na něm. Názvy rozvržení musí být v kolekci jedinečné.

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

Přidejte rozvržení jen tehdy, když šablona skutečně potřebuje další opakovaně použitelnu strukturu. Pokud již existuje vhodné rozvržení, vyberte a znovu jej použijte místo vytváření duplikátu.

## **Přidejte zástupné objekty do rozvržovacího snímku**

Metoda [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) poskytuje [ILayoutPlaceholderManager](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilayoutplaceholdermanager/) pro přidávání tvarů zástupných objektů do rozvržení.

| Zástupný objekt PowerPointu | Metoda `ILayoutPlaceholderManager` |
| --------------------------- | ----------------------------------- |
| ![Obsah](content.png) | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilayoutplaceholdermanager/#addContentPlaceholder-float-float-float-float-) |
| ![Obsah (svisle)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalContentPlaceholder-float-float-float-float-) |
| ![Text](text.png) | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilayoutplaceholdermanager/#addTextPlaceholder-float-float-float-float-) |
| ![Text (svisle)](textV.png) | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalTextPlaceholder-float-float-float-float-) |
| ![Obrázek](picture.png) | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilayoutplaceholdermanager/#addPicturePlaceholder-float-float-float-float-) |
| ![Graf](chart.png) | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilayoutplaceholdermanager/#addChartPlaceholder-float-float-float-float-) |
| ![Tabulka](table.png) | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilayoutplaceholdermanager/#addTablePlaceholder-float-float-float-float-) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilayoutplaceholdermanager/#addSmartArtPlaceholder-float-float-float-float-) |
| ![Média](media.png) | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilayoutplaceholdermanager/#addMediaPlaceholder-float-float-float-float-) |
| ![Online obrázek](onlineImage.png) | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilayoutplaceholdermanager/#addOnlineImagePlaceholder-float-float-float-float-) |

Následující příklad ověří, že rozvržení **Blank** existuje, přidá k němu čtyři zástupné objekty a poté vytvoří normální snímek, který použije upravené rozvržení. Pořadí je úmyslné: zástupné objekty jsou přidány před vytvořením normálního snímku, aby Aspose.Slides mohl vygenerovat odpovídající tvary zástupných objektů na tomto snímku.

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

![Zástupné objekty na rozvržovacím snímku](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Změna zděděného formátování nebo geometrie existujících zástupných objektů v rozvržení může ovlivnit závislé snímky. Nově přidaný zástupný objekt rozvržení není doplněn do existujících normálních snímků. Otestujte změny rozvržení na kopii prezentace a zkontrolujte každý závislý snímek.
{{% /alert %}}

## **Odstraňte nepoužívaná rozvržení snímků**

Použijte metodu [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/cs/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) k odstranění rozvržení, na která neodkazuje žádný normální snímek. Metoda ponechá rozvržení, která jsou stále používána, nedotčena.

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

Pro odstranění konkrétního rozvržení nejprve použijte jeho metodu [hasDependingSlides](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilayoutslide/#hasDependingSlides--) nebo [getDependingSlides](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilayoutslide/#getDependingSlides--). Před voláním [ILayoutSlide.remove](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilayoutslide/#remove--) přiřaďte všechny závislé snímky. Pokus o odstranění používání rozvržení vyvolá výjimku [PptxEditException](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pptxeditexception/).

## **Ovládání viditelnosti zápatí na rozvržovacím snímku**

Rozvržení má své vlastní zástupné objekty zápatí, čísla snímků a datum‑čas. Použijte metodu [ILayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilayoutslide/#getHeaderFooterManager--) k ovládání těchto zástupných objektů pro jedno rozvržení. To je užitečné například, když rozvržení obsahu má zobrazovat zápatí, ale rozvržení titulku ne.

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

## **Ovládání viditelnosti zápatí na hlavním snímku a jeho podřízených rozvrženích**

Pro aplikaci jednotných nastavení zápatí napříč hierarchií hlavního snímku použijte metodu [IMasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imasterslide/#getHeaderFooterManager--). Metody šíření [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imasterslideheaderfootermanager/) působí na hlavní snímek a jeho závislé rozvržovací a normální snímky; neadresují pouze jeden normální snímek.

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

**Jaký je rozdíl mezi hlavním snímkem a rozvržovacím snímkem?**

Hlavní snímek definuje motiv prezentace a sdílené formátování. Rozvržovací snímek patří k hlavnímu snímku a definuje jedno opakovatelné uspořádání zástupných objektů. Normální snímky používají tato rozvržení a ukládají obsah specifický pro jednotlivý snímek.

**Mohu zkopírovat rozvržovací snímek z jedné prezentace do druhé?**

Ano. Přidejte kopii do cílové kolekce pomocí metody [addClone](https://reference.aspose.com/slides/cs/java/com.aspose.slides/igloballayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-). Při kopírování mezi prezentacemi také ověřte písma, motivy, obrázky a další zdroje použité ve zdrojovém rozvržení.

**Co se stane, když upravím rozvržení, které již je používáno?**

Závislé snímky zdědí změny rozvržení, pokud lokálně nepřepíší postižené formátování nebo objekty. Geometrie zástupných objektů a zděděné stylování se tak mohou změnit na mnoha snímcích najednou. Před úpravou rozvržení použijte [getDependingSlides](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilayoutslide/#getDependingSlides--) k identifikaci ovlivněných snímků.

**Co se stane, pokud odstraním rozvržení, které je stále používáno?**

Aspose.Slides vyhodí výjimku [PptxEditException](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pptxeditexception/). Nejprve přiřaďte závislé snímky jinam nebo použijte [removeUnusedLayoutSlides](https://reference.aspose.com/slides/cs/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) k odstranění pouze neodkazovaných rozvržení.