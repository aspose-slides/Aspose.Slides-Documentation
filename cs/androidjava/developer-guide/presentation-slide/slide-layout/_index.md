---
title: "Použití nebo změna rozložení snímků na Androidu"
linktitle: "Rozložení snímku"
type: docs
weight: 60
url: /cs/androidjava/slide-layout/
keywords:
- rozložení snímku
- rozložení obsahu
- zástupný objekt
- návrh prezentace
- návrh snímku
- nepoužité rozložení
- viditelnost zápatí
- úvodní snímek
- nadpis a obsah
- záhlaví sekce
- dva obsahy
- srovnání
- pouze nadpis
- prázdné rozložení
- obsah s popiskem
- obrázek s popiskem
- nadpis a vertikální text
- vertikální nadpis a text
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Použijte, vytvářejte a upravujte rozložení snímků v Aspose.Slides pro Android pomocí Javy, přidávejte zástupné objekty, odstraňujte nepoužitá rozložení a ovládejte viditelnost zápatí."
---
## **Přehled**

Rozložení snímku určuje polohu a formátování zástupných objektů, jako jsou nadpisy, text, obrázky, grafy a tabulky. Použití rozložení poskytuje snímkům jednotnou strukturu a zároveň umožňuje, aby každý snímek obsahoval svůj vlastní obsah.

Nejčastější rozložení zahrnují:

- **Title Slide**: Obsahuje zástupné objekty nadpisu a podnadpisu.  
- **Title and Content**: Obsahuje zástupný objekt nadpisu a obecný obsahový zástupný objekt.  
- **Blank**: Neobsahuje žádné zástupné objekty a hodí se, když budou všechny tvary umístěny ručně.

## **Pochopte dědičnost rozvržení**

Prezentace má tři související úrovně:

1. [hlavní snímek](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imasterslide/) definuje motiv, sdílené formátování, pozadí a společné objekty.  
1. [rozvržení snímku](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilayoutslide/) patří k hlavnímu snímku a určuje konkrétní uspořádání zástupných objektů.  
1. [normální snímek](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islide/) používá jedno rozvržení a ukládá obsah zadaný pro daný snímek.

Normální snímek dědí motiv a formátování ze svého rozvržení a rozvržení dědí z hlavního snímku. Hodnota nastavená přímo na normálním snímku přepíše zděděnou hodnotu na této úrovni. Když je normální snímek vytvořen, jeho tvary zástupných objektů jsou vygenerovány z vybraného rozvržení, přičemž obsah zadaný do těchto zástupných objektů patří k normálnímu snímku.

Přidejte požadované zástupné objekty do rozvržení před tím, než z něj budete vytvářet snímky. Přidání dalšího zástupného objektu do rozvržení později automaticky nepřidá odpovídající tvar zástupného objektu do existujících normálních snímků.

Tento vztah má dva důležité důsledky:

- Změna zděděného formátování nebo existující geometrie zástupných objektů v rozvržení může aktualizovat každý snímek, který na něm závisí. Před úpravou rozvržení, které již je používáno, zkontrolujte jeho závislé snímky a přezkoumejte výslednou prezentaci.  
- Rozvržení, které je stále používáno nějakým snímkem, nelze odstranit. Předtím přeřiďte jeho závislé snímky na jiné rozvržení nebo odstraňte jen nepoužívaná rozvržení.

Další informace o nejvyšší úrovni této hierarchie najdete v [Slide Master](/slides/cs/androidjava/slide-master/).

Pro skrytí zděděných log a dekorativních tvarů hlavního snímku na jednom snímku nebo skrze sdílené rozvržení si přečtěte [Control the Visibility of Master Graphics](/slides/cs/androidjava/slide-master/). Příklad srovnává dva snímky používající stejný hlavní snímek.

## **Vyberte a použijte rozvržení snímku**

Použijte typ rozvržení, když prezentace následuje standardní definice rozvržení PowerPointu. Názvy rozvržení jsou editovatelné uživatelem a mohou být lokalizovány, takže výběr založený na názvu je méně spolehlivý, pokud neovládáte zdrojovou šablonu.

Následující ukázka hledá **Title and Content** na prvním hlavním snímku. Pokud toto rozvržení není k dispozici, úmyslně přejde na **Blank**. Druhá kontrola na null je nutná, protože prezentace může obsahovat jen vlastní rozvržení. Vybrané rozvržení je poté použito na prvním normálním snímku pomocí metody [ISlide.setLayoutSlide](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islide/#setLayoutSlide-com.aspose.slides.ILayoutSlide-) .

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

Změna rozvržení snímku neodstraní běžné tvary přidané přímo na snímek. Nicméně pozice zástupných objektů, zděděné formátování a shoda mezi existujícími zástupnými objekty a novým rozvržením se může změnit, proto při přepínání mezi podstatně odlišnými rozvrženími zkontrolujte výstup.

## **Přidejte rozvržení snímku**

Výběr a vytvoření jsou oddělené operace. Předchozí ukázka vybere existující rozvržení; nevytváří ho. Pro vytvoření rozvržení zavolejte metodu [IMasterLayoutSlideCollection.add](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imasterlayoutslidecollection/#add-byte-java.lang.String-) na kolekci rozvržení cílového hlavního snímku.

Následující příklad vždy přidá nové rozvržení **Title and Content** s názvem `Report Title and Content` a poté přidá normální snímek založený na něm. Názvy rozvržení musí být v rámci kolekce jedinečné.

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

Přidejte rozvržení pouze tehdy, když šablona skutečně potřebuje další znovupoužitelnou strukturu. Pokud již existuje vhodné rozvržení, vyberte a znovu ho použijte místo vytváření duplikátu.

## **Přidejte zástupné objekty do rozvržení snímku**

Metoda [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) poskytuje [ILayoutPlaceholderManager](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilayoutplaceholdermanager/) pro přidávání tvarů zástupných objektů do rozvržení.

| Placeholder PowerPointu            | `ILayoutPlaceholderManager` metoda |
| ----------------------------------- | ----------------------------------- |
| ![Obsah](content.png)               | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addContentPlaceholder-float-float-float-float-) |
| ![Obsah (Vertikální)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalContentPlaceholder-float-float-float-float-) |
| ![Text](text.png)                   | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addTextPlaceholder-float-float-float-float-) |
| ![Text (Vertikální)](textV.png)     | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalTextPlaceholder-float-float-float-float-) |
| ![Obrázek](picture.png)             | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addPicturePlaceholder-float-float-float-float-) |
| ![Graf](chart.png)                  | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addChartPlaceholder-float-float-float-float-) |
| ![Tabulka](table.png)               | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addTablePlaceholder-float-float-float-float-) |
| ![SmartArt](smartart.png)           | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addSmartArtPlaceholder-float-float-float-float-) |
| ![Média](media.png)                 | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addMediaPlaceholder-float-float-float-float-) |
| ![Online obrázek](onlineImage.png)  | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addOnlineImagePlaceholder-float-float-float-float-) |

Následující ukázka ověřuje, že rozvržení **Blank** existuje, přidá k němu čtyři zástupné objekty a poté vytvoří normální snímek, který používá upravené rozvržení. Pořadí je úmyslné: zástupné objekty jsou přidány před vytvořením normálního snímku, takže Aspose.Slides může vygenerovat odpovídající tvary zástupných objektů na tomto snímku.

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
Změna zděděného formátování nebo geometrie existujících zástupných objektů v rozvržení může ovlivnit závislé snímky. Nově přidaný zástupný objekt rozvržení není automaticky doplněn do existujících normálních snímků. Testujte změny rozvržení na kopii prezentace a zkontrolujte každý závislý snímek.
{{% /alert %}}

## **Odstraňte nepoužívaná rozvržení snímků**

Použijte metodu [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) k odebrání rozvržení, na která neodkazuje žádný normální snímek. Metoda ponechá rozvržení, která jsou stále používána, nedotčena.

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

Pro odebrání konkrétního rozvržení nejprve použijte jeho metodu [hasDependingSlides](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilayoutslide/#hasDependingSlides--) nebo [getDependingSlides](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilayoutslide/#getDependingSlides--). Před voláním [ILayoutSlide.remove](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilayoutslide/#remove--) přesuňte všechny závislé snímky. Pokus o odebrání rozvržení, které je používáno, vyvolá výjimku [PptxEditException](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/pptxeditexception/).

## **Řízení viditelnosti zápatí na rozvržení snímku**

Rozvržení má vlastní zástupné objekty zápatí, čísla snímku a data/času. Použijte metodu [ILayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilayoutslide/#getHeaderFooterManager--) k řízení těchto zástupných objektů pro konkrétní rozvržení. To je užitečné například, když obsahová rozvržení mají zobrazovat zápatí, ale rozvržení nadpisu ne.

Následující ukázka bezpečně vybere rozvržení a zpřístupní jeho elementy zápatí:

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

## **Řízení viditelnosti zápatí na hlavním snímku a jeho podřízených rozvrženích**

Pro aplikaci jednotných nastavení zápatí napříč hierarchií hlavního snímku použijte metodu [IMasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imasterslide/#getHeaderFooterManager--). Propagační metody [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imasterslideheaderfootermanager/) působí na hlavní snímek, jeho závislé rozvržení snímků i normální snímky; neovlivňují jen jeden normální snímek.

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

**Jaký je rozdíl mezi hlavním snímkem a rozvržením snímku?**

Hlavní snímek definuje motiv prezentace a sdílené formátování. Rozvržení snímku patří k hlavnímu snímku a určuje jednorázové opakovatelné uspořádání zástupných objektů. Normální snímky používají tato rozvržení a ukládají obsah specifický pro konkrétní snímek.

**Mohu zkopírovat rozvržení snímku z jedné prezentace do druhé?**

Ano. Přidejte kopii do cílové kolekce metodou [addClone](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/igloballayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-). Při kopírování mezi prezentacemi také ověřte písma, motivy, obrázky a další zdroje používané zdrojovým rozvržením.

**Co se stane, když upravím rozvržení, které je již používáno?**

Závislé snímky zdědí změny rozvržení, pokud místně nepřepíší dotčené formátování nebo objekty. Geometrie zástupných objektů a zděděné styly se mohou tedy změnit na mnoha snímcích najednou. Použijte [getDependingSlides](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilayoutslide/#getDependingSlides--) k identifikaci ovlivněných snímků před úpravou rozvržení.

**Co se stane, když odstraním rozvržení, které je stále používáno?**

Aspose.Slides vyvolá výjimku [PptxEditException](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/pptxeditexception/). Nejprve přesuňte závislé snímky, nebo použijte [removeUnusedLayoutSlides](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) k odebrání pouze neodkazovaných rozvržení.