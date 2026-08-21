---
title: Operace prezentací s nízkokódovým rozhraním na Androidu
linktitle: Nízkokódové API
type: docs
weight: 50
url: /cs/androidjava/low-code-presentation-operations/
keywords:
- nízkokódové rozhraní prezentací
- převod prezentace
- sloučení prezentací
- iterace snímků
- iterace tvarů
- iterace textu
- sběr tvarů
- komprese prezentace
- odstranění nepoužitých master snímků
- odstranění nepoužitých rozvržení snímků
- komprese vložených fontů
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Použijte nízkokódové API Aspose.Slides na Androidu k převodu a sloučení prezentací, iteraci obsahu, sběru tvarů a snížení velikosti prezentace."
---
## **Přehled**

Balíček [com.aspose.slides](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/) poskytuje statické pomocné třídy pro běžné operace s prezentacemi. Tyto pomocníky zabalí často používané workflow objektového modelu do zaměřených metod, takže můžete převádět nebo spojovat soubory, zpracovávat prvky prezentace, sbírat tvary a odstraňovat nepoužitý obsah s menším množstvím kódu.

Nízkokódové pomocníky jsou nejvíce užitečné, když se operace vztahuje na celý soubor nebo prezentaci a výchozí workflow odpovídá vašim požadavkům. Použijte plný [Aspose.Slides objektový model](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/), když potřebujete jemnozrnnou kontrolu nad jednotlivými snímky, mistry, rozvržením, tvary, nastavením exportu nebo vztahy mezi prvky prezentace.

Následující tabulka shrnuje dostupné pomocníky:

| Pomocník | K čemu ho použít |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/convert/) | Převod prezentace do jiného formátu pomocí přímého volání soubor‑na‑soubor. |
| [Merger](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/merger/) | Kombinování kompletních souborů prezentací ve stejném formátu. |
| [ForEach](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/foreach/) | Spuštění akce pro každý snímek, tvar, odstavec nebo část textu. |
| [Collect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/collect/) | Získání tvarů z celé prezentace pro opakované zpracování nebo analýzu. |
| [Compress](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/compress/) | Odstranění nepoužitých mistrů a rozvržení a zmenšení vložených dat fontů. |

## **Převod prezentace**

Použijte [Convert.autoByExtension](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) když je přípona výstupního souboru dostačující pro výběr formátu exportu. Metoda otevře zdrojovou prezentaci, určí požadovaný formát z cesty výstupu a zapíše výsledek.

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

Třída [Convert](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/convert/) také poskytuje vyhrazené metody pro výstup PDF, SVG, JPEG, PNG a TIFF. Použijte plný objektový model, když potřebujete před exportem prohlédnout nebo upravit prezentaci nebo nastavit možnost exportu, která není vybrané pomocníky zpřístupněna. Viz [Convert Presentation](/androidjava/convert-presentation/) pro workflow a možnosti specifické pro formáty.

## **Sloučení prezentací**

Použijte [Merger.process](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) k sloučení kompletních souborů prezentací jedním voláním. Vstupní prezentace musí mít stejný formát souboru.

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

Tento pomocník je vhodný, když mají být všechny snímky připojeny do jednoho výsledku bez individuálního výběru nebo přemapování. Použijte plný objektový model, když potřebujete sloučit vybrané snímky, použít cílový master nebo rozvržení, výslovně zachovat sekce nebo sladit různé velikosti snímků. Viz [Merge Presentations](/androidjava/merge-presentation/) pro tyto scénáře.

## **Iterace přes prvky prezentace**

Třída [ForEach](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/foreach/) vyvolá zpětné volání pro každý požadovaný typ prvku prezentace. Vyhýbá se vnořeným smyčkám sbírek a je vhodná pro inspekci nebo změny formátování na úrovni celé prezentace.

Následující příklad používá [ForEach.slide](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-), [ForEach.shape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), a [ForEach.portion](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) aby inspektoval odpovídající prvky:

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

Ve výchozím nastavení procházení tvarů a textu v celé prezentaci zahrnuje normální, master a layout snímky. Přetížení s parametrem `includeNotes` mohou také zpracovávat snímky poznámek. Použijte přímé smyčky sbírek, když je důležitý pořadí procházení, předčasný ukončení, filtrování před vyvoláním zpětného volání nebo podrobnější kontrola rodič‑dítě.

## **Sběr tvarů**

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

Použijte místo toho [ForEach.shape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) když může být každý tvar zpracován okamžitě a není potřeba uchovávat shromážděný výsledek.

## **Komprimace obsahu prezentace**

Třída [Compress](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/compress/) může odstranit nepoužité strukturalní prvky a snížit vložená data fontů:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) odstraňuje rozvržení snímků, na které neodkazuje žádný normální snímek.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) odstraňuje master snímky, které již nejsou používány.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) odstraňuje nepoužité znaky z vložených fontů.

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

Odstraňte nepoužitá rozvržení před nepoužitými mistry, aby se master, který po úklidu rozvržení zůstane neodkazovaný, také mohl odstranit. Uložte optimalizovanou prezentaci do nového souboru, pokud můžete později potřebovat původní mistry, rozvržení nebo kompletní data vložených fontů. Pro více podrobností viz [Slide Master](/androidjava/slide-master/) a [Embedded Font](/androidjava/embedded-font/).

## **Často kladené otázky**

**Kdy mám použít low‑code API místo plného objektového modelu?**

Používejte low‑code pomocníky, když se standardní operace vztahuje na celý soubor nebo prezentaci a nevyžaduje detailní kontrolu nad jednotlivými prvky. Použijte plný objektový model, když potřebujete vybrat konkrétní snímky, ovládat vztahy mezi mistry a rozvržením, prohlížet mezistav nebo konfigurovat chování, které pomocník neodhaluje.

**Může Merger kombinovat prezentace v různých formátech souborů?**

Ne. [Merger.process](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) vyžaduje vstupní prezentace ve stejném formátu. Nejprve převěďte vstupní soubory do společného formátu, například pomocí [Convert.autoByExtension](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-), a poté sloučte převedené soubory.

**Zpracovává ForEach mistry, rozvržení a poznámkové snímky?**

[ForEach.slide](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) prochází normální snímky prezentace. [ForEach.shape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), a [ForEach.portion](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) operace na úrovni celé prezentace zahrnují ve výchozím nastavení normální, master a layout snímky. Použijte jejich přetížení s `includeNotes` nastaveným na `true`, aby byly zahrnuty i poznámkové snímky.

**Jaký je rozdíl mezi ForEach.shape a Collect.shapes?**

Použijte [ForEach.shape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), abyste každým tvarem zpracovali okamžitě prostřednictvím zpětného volání. Použijte [Collect.shapes](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-), když potřebujete iterovatelný výsledek, který lze uchovat, filtrovat, počítat nebo procházet vícekrát.

**Zmenšuje Compress vždy velikost souboru prezentace?**

Není to nutně pravda. Výsledek závisí na tom, zda prezentace obsahuje nepoužitá rozvržení, nepoužité mistry nebo vložené fonty s nepoužitými znaky. Pokud žádné z toho není přítomno, odpovídající operace [Compress](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/compress/) nemusí zmenšit velikost souboru.

**Ukládají se změny provedené pomocí ForEach nebo Compress automaticky?**

Ne. Títo pomocníci pracují s načteným objektem [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) v paměti. Po změně prvků v zpětném volání [ForEach](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/foreach/) nebo po spuštění [Compress](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/compress/), zavolejte [Presentation.save](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) k zápisu výsledku.

## **Související články**

- [Convert Presentation](/androidjava/convert-presentation/)
- [Merge Presentations](/androidjava/merge-presentation/)
- [Slide Master](/androidjava/slide-master/)
- [Manage Text Box](/androidjava/manage-textbox/)
- [Embedded Font](/androidjava/embedded-font/)