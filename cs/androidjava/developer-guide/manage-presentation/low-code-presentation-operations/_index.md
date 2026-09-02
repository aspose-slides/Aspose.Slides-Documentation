---
title: Operace prezentací s nízkým kódem na Androidu
linktitle: API s nízkým kódem
type: docs
weight: 50
url: /cs/androidjava/low-code-presentation-operations/
keywords:
- API pro prezentace s nízkým kódem
- převod prezentace
- sloučení prezentací
- iterace snímků
- iterace tvarů
- iterace textu
- shromažďování tvarů
- komprese prezentace
- odstranění nepoužívaných hlavních snímků
- odstranění nepoužívaných rozvržení snímků
- komprese vložených fontů
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Použijte API Aspose.Slides s nízkým kódem na Androidu pro převod a sloučení prezentací, iteraci obsahu, shromažďování tvarů a snížení velikosti prezentace."
---
## **Přehled**

Balíček [com.aspose.slides](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/) poskytuje statické pomocné třídy pro běžné operace s prezentacemi. Tyto pomocníky zapouzdřují často používané workflow objektového modelu do cílených metod, takže můžete konvertovat nebo slučovat soubory, zpracovávat prvky prezentace, shromažďovat tvary a odstraňovat nepoužívaný obsah s menším množstvím kódu.

Nástroje s nízkým kódem jsou nejvíce užitečné, když se operace týká celého souboru nebo prezentace a výchozí workflow odpovídá vašim požadavkům. Použijte plný [Aspose.Slides object model](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/), když potřebujete detailní kontrolu nad jednotlivými snímky, hlavami, rozvržením, tvary, nastavením exportu nebo vztahy mezi prvky prezentace.

The following table summarizes the available helpers:

| Helper | Use it for |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/convert/) | Převod prezentace do jiného formátu pomocí přímého volání soubor na soubor. |
| [Merger](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/merger/) | Kombinování kompletních souborů prezentací stejného formátu. |
| [ForEach](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/foreach/) | Spuštění akce pro každý snímek, tvar, odstavec nebo část textu. |
| [Collect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/collect/) | Získání tvarů z celé prezentace pro opakované zpracování nebo analýzu. |
| [Compress](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/compress/) | Odstranění nepoužívaných hlav a rozvržení a redukce vložených fontových dat. |

## **Převést prezentaci**

Použijte [Convert.autoByExtension](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) když je přípona výstupního souboru dostatečná pro výběr exportního formátu. Metoda otevře zdrojovou prezentaci, určí požadovaný formát z výstupní cesty a zapíše výsledek.

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

Třída [Convert](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/convert/) také poskytuje dedikované metody pro výstup do PDF, SVG, JPEG, PNG a TIFF. Použijte plný objektový model, když potřebujete před exportem prohlédnout nebo upravit prezentaci nebo nakonfigurovat exportní volbu, která není dostupná ve vybraném pomocníkovi. Viz [Convert Presentation](/slides/cs/androidjava/convert-presentation/) pro workflow a možnosti specifické pro formát.

## **Sloučit prezentace**

Použijte [Merger.process](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) k sloučení kompletních souborů prezentací jedním voláním. Vstupní prezentace musí mít stejný formát souboru.

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

Tento pomocník je vhodný, když mají být všechny snímky připojeny do jednoho výsledku bez individuálního výběru nebo přemapování. Použijte plný objektový model, když potřebujete sloučit vybrané snímky, použít cílovou hlavu nebo rozvržení, explicitně zachovat sekce nebo sladit různé velikosti snímků. Viz [Merge Presentations](/slides/cs/androidjava/merge-presentation/) pro tyto scénáře.

## **Iterovat přes prvky prezentace**

Třída [ForEach](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/foreach/) vyvolá zpětné volání pro každý požadovaný typ prvku prezentace. Vyhýbá se vnořeným smyčkám kolekcí a je praktická pro kontrolu nebo změny formátování na úrovni celé prezentace.

Následující příklad používá [ForEach.slide](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-), [ForEach.shape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), a [ForEach.portion](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) aby prozkoumal odpovídající prvky:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ForEach.slide(presentation, (slide, index) -> {
        System.out.println(String.format("Slide %d: %d shapes", index, slide.getShapes().size()));
    });

    ForEach.shape(presentation, (shape, slide, index) -> {
        System.out.println(String.format("Shape %d on %s: %s", index, slide.getClass().getSimpleName(), shape.getName()));
    });

    ForEach.paragraph(presentation, (paragraph, slide, index) -> {
        System.out.println(String.format("Paragraph %d on %s: %s", index, slide.getClass().getSimpleName(), paragraph.getText()));
    });

    ForEach.portion(presentation, (portion, paragraph, slide, index) -> {
        System.out.println(String.format("Portion %d on %s: %s", index, slide.getClass().getSimpleName(), portion.getText()));
    });
} finally {
    presentation.dispose();
}
```

Ve výchozím nastavení zahrnuje procházení tvarů a textu v celé prezentaci normální, hlavní a rozvržení snímky. Přetížení s parametrem `includeNotes` mohou také zpracovávat snímky poznámek. Použijte přímé smyčky kolekcí, když je důležitý pořadí průchodu, předčasný ukončení, filtrování před voláním zpětné funkce nebo detailní kontrola nad rodičovským a podřízeným vztahem.

## **Sbírat tvary**

Použijte [Collect.shapes](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) když potřebujete kolekci všech tvarů v prezentaci místo zpětného volání pro každý tvar. To je užitečné, pokud bude stejná sada filtrována, počítána nebo zpracovávána vícekrát.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Iterable<Shape> shapes = Collect.shapes(presentation);

    for (Shape shape : shapes) {
        System.out.println(String.format("%s: %s", shape.getName(), shape.getClass().getSimpleName()));
    }
} finally {
    presentation.dispose();
}
```

Použijte místo toho [ForEach.shape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) když může být každý tvar zpracován okamžitě a není nutné uchovávat shromážděný výsledek.

## **Komprimovat obsah prezentace**

Třída [Compress](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/compress/) může odstranit nepoužívané strukturální prvky a snížit vložená data fontů:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) odstraňuje rozvržení snímky, na které neodkazuje žádný normální snímek.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) odstraňuje hlavní snímky, které již nejsou používány.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) odstraňuje nepoužívané znaky z vložených fontů.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);
    Compress.removeUnusedMasterSlides(presentation);
    Compress.compressEmbeddedFonts(presentation);

    presentation.save("compressed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Odstraňte nepoužívaná rozvržení před nepoužívanými hlavami, aby mohla být hlavní hlava, která se po vyčištění rozvržení stane neodkazovanou, také odstraněna. Uložte optimalizovanou prezentaci do nového souboru, pokud budete později potřebovat originální hlavy, rozvržení nebo kompletní vložená data fontů. Další podrobnosti viz [Slide Master](/slides/cs/androidjava/slide-master/) a [Embedded Font](/slides/cs/androidjava/embedded-font/).

## **Často kladené otázky**

**Kdy bych měl použít low-code API místo plného objektového modelu?**

Nástroje s nízkým kódem použijte, když standardní operace platí pro celý soubor nebo prezentaci a nevyžaduje detailní kontrolu nad jednotlivými prvky. Plný objektový model použijte, když potřebujete vybrat konkrétní snímky, řídit vztahy hlav a rozvržení, prohlédnout mezistav nebo nakonfigurovat chování, které pomocník neumožňuje.

**Může Merger kombinovat prezentace v různých formátech souborů?**

Ne. [Merger.process](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) vyžaduje vstupní prezentace ve stejném formátu. Nejprve převeďte vstupní soubory do společného formátu, například pomocí [Convert.autoByExtension](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-), a poté sloučte převedené soubory.

**Zpracovává ForEach hlavní, rozvržení a snímky poznámek?**

[ForEach.slide](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) iteruje přes normální snímky prezentace. Celoprezentační operace [ForEach.shape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), a [ForEach.portion](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) zahrnují ve výchozím nastavení normální, hlavní a rozvržení snímky. Použijte jejich přetížení s `includeNotes` nastaveným na `true`, aby byly zahrnuty i snímky poznámek.

**Jaký je rozdíl mezi ForEach.shape a Collect.shapes?**

Použijte [ForEach.shape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), když chcete zpracovat každý tvar okamžitě pomocí zpětného volání. Použijte [Collect.shapes](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-), když potřebujete iterovatelný výsledek, který lze uchovat, filtrovat, počítat nebo procházet vícekrát.

**Zmenšuje Compress vždy velikost souboru prezentace?**

Není to nutně. Výsledek závisí na tom, zda prezentace obsahuje nepoužívaná rozvržení, nepoužívané hlavy nebo vložené fonty s nepoužívanými znaky. Pokud žádné z těchto věcí nejsou přítomny, odpovídající operace [Compress](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/compress/) nemusí zmenšit velikost souboru.

**Ukládají se změny provedené pomocí ForEach nebo Compress automaticky?**

Ne. Tyto pomocníky pracují s načteným objektem [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) v paměti. Po změně elementů v zpětném volání [ForEach](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/foreach/) nebo po spuštění [Compress](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/compress/), zavolejte [Presentation.save](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-), abyste výsledek zapsali.

## **Související články**

- [Převod prezentace](/slides/cs/androidjava/convert-presentation/)
- [Sloučení prezentací](/slides/cs/androidjava/merge-presentation/)
- [Slide Master](/slides/cs/androidjava/slide-master/)
- [Spravovat textové pole](/slides/cs/androidjava/manage-textbox/)
- [Vložený font](/slides/cs/androidjava/embedded-font/)