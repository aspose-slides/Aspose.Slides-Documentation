---
title: Vytváření prezentací na Androidu
linktitle: Vytvořit prezentaci
type: docs
weight: 10
url: /cs/androidjava/create-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Vytvářejte prezentace v Javě pomocí Aspose.Slides pro Android - vytvářejte soubory PPT, PPTX a ODP, využívejte podporu OpenDocument a ukládejte je programově pro spolehlivé výsledky."
---
## **Přehled**

Tento článek ukazuje, jak vytvořit prezentaci v Aspose.Slides pro Android pomocí Javy, přidat textové pole na první snímek a uložit výsledek jako soubor v úložišti vaší aplikace. Pro otevření existující prezentace nebo uložení v jiném formátu viz [Open Presentation](/slides/cs/androidjava/open-presentation/) a [Save Presentation](/slides/cs/androidjava/save-presentation/). Krátké FAQ na konci pokrývá běžné otázky o formátech, šablonách, velikosti snímků, jednotkách, využití paměti, vláknování, licencování, digitálních podpisů a podpoře VBA.

Než začnete, přidejte Aspose.Slides do svého Android projektu z Maven repozitáře Aspose. Viz [Installation](/slides/cs/androidjava/install-aspose-slides-for-android-via-java/).

## **Vytvořit PowerPoint prezentaci**

Chcete‑li vytvořit prezentaci a umístit textové pole na její první snímek, postupujte následovně:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/). Nová prezentace již obsahuje jeden prázdný snímek.
1. Získejte tento snímek z [slide collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/) podle jeho indexu, 0.
1. Přidejte obdélník pomocí metody [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) ze [shape collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/) a nastavte text jeho [text frame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) metodou [setText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#setText-java.lang.String-).
1. Uložte prezentaci jako soubor PPTX pomocí metody [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) ve formátu [SaveFormat.Pptx](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveformat/).

Kód běží uvnitř `Activity`, například v metodě `onCreate`. Ukládá soubor do adresáře vráceného metodou [getFilesDir](https://developer.android.com/reference/android/content/Context#getFilesDir()), tedy do soukromého úložiště vaší aplikace, kam lze zapisovat bez požadování oprávnění.

```java
import com.aspose.slides.*;
import java.io.File;

File outputFile = new File(getFilesDir(), "hello.pptx");

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Levá horní krajní bod obdélníka je vzdálen 50 bodů od levého okraje a 50 bodů od horního okraje snímku, šířka je 400 bodů a výška 100 bodů. Výsledný soubor obsahuje jeden snímek s tímto obdélníkem a jeho textem. Bez licence také Aspose.Slides přidává evaluační vodoznak ke každému uloženému snímku; viz [Licensing](/slides/cs/androidjava/licensing/).

Pro zobrazení souboru otevřete v Android Studiu [Device Explorer](https://developer.android.com/studio/debug/device-file-explorer) a najděte *hello.pptx* pod *data/data/* v adresáři *files* vaší aplikace. Ve skutečné aplikaci zpracovávejte prezentace na pozadí, aby uživatelské rozhraní zůstalo responzivní.

## **Často kladené otázky**

### Jaké formáty mohu použít pro uložení nové prezentace?

Můžete ukládat do [PPTX, PPT a ODP](/slides/cs/androidjava/save-presentation/) a exportovat do [PDF](/slides/cs/androidjava/convert-powerpoint-to-pdf/), [XPS](/slides/cs/androidjava/convert-powerpoint-to-xps/), [HTML](/slides/cs/androidjava/convert-powerpoint-to-html/), [SVG](/slides/cs/androidjava/render-a-slide-as-an-svg-image/) a [obrázků](/slides/cs/androidjava/convert-powerpoint-to-png/), mezi jinými.

### Mohu začít ze šablony (POTX/POTM) a uložit jako běžný PPTX?

Ano. Načtěte šablonu a uložte do požadovaného formátu; formáty POTX/POTM/PPTM a podobné [jsou podporovány](/slides/cs/androidjava/supported-file-formats/).

### Jak mohu kontrolovat velikost snímku/poměr stran při vytváření prezentace?

Nastavte [slide size](/slides/cs/androidjava/slide-size/) (včetně předvoleb jako 4:3 a 16:9 nebo vlastních rozměrů) a zvolte, jak se má obsah škálovat.

### V jakých jednotkách jsou měřeny rozměry a souřadnice?

V bodech: 1 palec odpovídá 72 jednotkám.

### Jak zacházet s velmi velkými prezentacemi (s mnoha mediálními soubory) pro snížení využití paměti?

Použijte [BLOB management strategies](/slides/cs/androidjava/manage-blob/), omezte ukládání do paměti využitím dočasných souborů a upřednostňujte workflow založené na souborech místo čistě paměťových streamů.

### Mohu vytvářet/ukládat prezentace paralelně?

Nelze pracovat se stejnou instancí [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) z [multiple threads](/slides/cs/androidjava/multithreading/). Používejte oddělené instance pro každé vlákno nebo proces.

### Jak odstranit zkušební vodoznak a omezení?

[Apply a license](/slides/cs/androidjava/licensing/) jednou na proces. Licenční XML nesmí být upravováno a nastavení licence by mělo být synchronizováno, pokud jsou zapojena více vláken.

### Mohu digitálně podepsat vytvořený PPTX?

Ano. [Digital signatures](/slides/cs/androidjava/digital-signature-in-powerpoint/) (přidávání i ověřování) jsou pro prezentace podporovány.

### Jsou makra (VBA) podporována v vytvořených prezentacích?

Ano. Můžete [create/edit VBA projects](/slides/cs/androidjava/presentation-via-vba/) a ukládat soubory s povolenými makry, například PPTM/PPSM.