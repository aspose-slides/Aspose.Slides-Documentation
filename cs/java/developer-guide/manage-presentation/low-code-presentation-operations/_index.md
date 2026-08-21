---
title: Low-Code operace prezentací v Java
linktitle: Low-Code API
type: docs
weight: 50
url: /cs/java/low-code-presentation-operations/
keywords:
- low-code API pro prezentace
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
- Java
- Aspose.Slides
description: "Použijte low-code API Aspose.Slides v jazyce Java k převodu a sloučení prezentací, iteraci obsahu, sběru tvarů a snížení velikosti prezentace."
---
## **Přehled**

Balíček [com.aspose.slides](https://reference.aspose.com/slides/cs/java/com.aspose.slides/) poskytuje statické pomocné třídy pro běžné operace s prezentacemi. Tyto pomocníky zabalí často používané pracovní postupy objektového modelu do zaměřených metod, takže můžete převádět nebo slučovat soubory, zpracovávat prvky prezentace, sbírat tvary a odstraňovat nepoužitý obsah s méně kódem.

Low-code pomocníci jsou nejužitečnější, když se operace vztahuje na celý soubor nebo prezentaci a výchozí pracovní postup odpovídá vašim požadavkům. Použijte plný [Aspose.Slides object model](https://reference.aspose.com/slides/cs/java/com.aspose.slides/) když potřebujete jemnou kontrolu nad jednotlivými snímky, mastery, rozvrženími, tvary, nastavením exportu nebo vztahy mezi prvky prezentace.

Následující tabulka shrnuje dostupné pomocníky:

| Pomocník | K čemu použít |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/cs/java/com.aspose.slides/convert/) | Převod prezentace do jiného formátu pomocí přímého volání soubor‑na‑soubor. |
| [Merger](https://reference.aspose.com/slides/cs/java/com.aspose.slides/merger/) | Kombinování kompletních souborů prezentací stejného formátu. |
| [ForEach](https://reference.aspose.com/slides/cs/java/com.aspose.slides/foreach/) | Spuštění akce pro každý snímek, tvar, odstavec nebo část textu. |
| [Collect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/collect/) | Získání tvarů z celé prezentace pro opakované zpracování nebo analýzu. |
| [Compress](https://reference.aspose.com/slides/cs/java/com.aspose.slides/compress/) | Odstranění nepoužitých masterů a rozvržení a zmenšení vložených dat fontů. |

## **Převod prezentace**

Použijte [Convert.autoByExtension](https://reference.aspose.com/slides/cs/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) když je přípona výstupního souboru dostatečná pro výběr formátu exportu. Metoda otevře zdrojovou prezentaci, určí požadovaný formát z výstupní cesty a zapíše výsledek.

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

Třída [Convert](https://reference.aspose.com/slides/cs/java/com.aspose.slides/convert/) také poskytuje dedikované metody pro výstup do PDF, SVG, JPEG, PNG a TIFF. Použijte plný objektový model, když potřebujete před exportem prezentaci prohlédnout nebo upravit, nebo nakonfigurovat volbu exportu, která není vybraným pomocníkem zpřístupněna. Viz [Convert Presentation](/java/convert-presentation/) pro workflow a možnosti specifické pro formát.

## **Sloučení prezentací**

Použijte [Merger.process](https://reference.aspose.com/slides/cs/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) k sloučení kompletních souborů prezentací jedním voláním. Vstupní prezentace musí mít stejný formát souboru.

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

Pomocník je vhodný, když mají být všechny snímky připojeny k jednomu výsledku bez individuálního výběru nebo přemapování. Použijte plný objektový model, když potřebujete sloučit vybrané snímky, aplikovat cílový master nebo rozvržení, explicitně zachovat sekce nebo sladit různé velikosti snímků. Viz [Merge Presentations](/java/merge-presentation/) pro tyto scénáře.

## **Iterace přes prvky prezentace**

Třída [ForEach](https://reference.aspose.com/slides/cs/java/com.aspose.slides/foreach/) vyvolá zpětné volání pro každý požadovaný typ prvku prezentace. Vyhýbá se zanořovaným smyčkám sběru a je pohodlná pro celoprezentační inspekci nebo změny formátování.

Následující příklad používá [ForEach.slide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-), [ForEach.shape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/cs/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-) a [ForEach.portion](https://reference.aspose.com/slides/cs/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) k inspekci odpovídajících elementů:

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

Ve výchozím nastavení projde celoprezentační průchod tvarů a textu normální, master i rozvržení snímky. Přetížení s parametrem `includeNotes` může také zpracovat poznámkové snímky. Použijte přímé smyčky sběru, když je důležitý pořadí průchodu, brzký výstup, filtrování před voláním zpětného volání nebo podrobná kontrola rodič‑potomka.

## **Sbírání tvarů**

Použijte [Collect.shapes](https://reference.aspose.com/slides/cs/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) když potřebujete kolekci všech tvarů v prezentaci místo zpětného volání pro každý tvar. Toto je užitečné, pokud bude stejná sada filtrována, počítána nebo zpracována vícekrát.

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

Použijte [ForEach.shape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) místo toho, když může být každý tvar zpracován okamžitě a není potřeba uchovávat shromážděný výsledek.

## **Komprese obsahu prezentace**

Třída [Compress](https://reference.aspose.com/slides/cs/java/com.aspose.slides/compress/) může odstranit nepoužité strukturované elementy a zmenšit vložená data fontů:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/cs/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) odstraňuje snímky rozvržení, na které neodkazuje žádný normální snímek.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/cs/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) odstraňuje mastery, které už nejsou používány.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/cs/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) odstraňuje nepoužité znaky z vložených fontů.

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

Odstraňujte nepoužité rozvržení před nepoužitými mastery, aby master, který se po vyčištění rozvržení stane nepřipojeným, mohl být také odstraněn. Uložte optimalizovanou prezentaci do nového souboru, pokud budete později potřebovat původní mastery, rozvržení nebo kompletní vložená data fontů. Pro více detailů viz [Slide Master](/java/slide-master/) a [Embedded Font](/java/embedded-font/).

## **Často kladené otázky**

**Kdy bych měl použít low-code API místo plného objektového modelu?**

Používejte low-code pomocníky, když standardní operace platí pro celý soubor nebo prezentaci a nevyžaduje podrobnou kontrolu nad jednotlivými elementy. Použijte plný objektový model, když potřebujete vybrat konkrétní snímky, řídit vztahy mezi mastery a rozvrženími, inspektovat mezivýsledky nebo konfigurovat chování, které pomocník neexponuje.

**Může Merger kombinovat prezentace v různých formátech souborů?**

Ne. [Merger.process](https://reference.aspose.com/slides/cs/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) vyžaduje vstupní prezentace ve stejném formátu. Nejprve převeďte vstupní soubory do společného formátu, například pomocí [Convert.autoByExtension](https://reference.aspose.com/slides/cs/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-), a pak sloučte převedené soubory.

**Zpracovává ForEach master, layout a poznámkové snímky?**

[ForEach.slide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) iteruje přes normální snímky prezentace. Celoprezentační [ForEach.shape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/cs/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-) a [ForEach.portion](https://reference.aspose.com/slides/cs/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) zahrnují ve výchozím nastavení normální, master i layout snímky. Použijte jejich přetížení s `includeNotes` nastaveným na `true`, pokud chcete zahrnout i poznámkové snímky.

**Jaký je rozdíl mezi ForEach.shape a Collect.shapes?**

Použijte [ForEach.shape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) k okamžitému zpracování každého tvaru prostřednictvím zpětného volání. Použijte [Collect.shapes](https://reference.aspose.com/slides/cs/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) když potřebujete iterovatelný výsledek, který může být uložen, filtrován, počítán nebo procházen vícekrát.

**Zmenšuje Compress vždy velikost souboru prezentace?**

Ne nutně. Výsledek závisí na tom, zda prezentace obsahuje nepoužité rozvržení, nepoužité mastery nebo vložené fonty s nepoužitými znaky. Pokud žádné z těchto položek chybí, odpovídající operace [Compress](https://reference.aspose.com/slides/cs/java/com.aspose.slides/compress/) nemusí zmenšit velikost souboru.

**Ukládají se změny provedené pomocí ForEach nebo Compress automaticky?**

Ne. Tyto pomocníky pracují s načteným objektem [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) v paměti. Po změně elementů v zpětném volání [ForEach](https://reference.aspose.com/slides/cs/java/com.aspose.slides/foreach/) nebo po spuštění [Compress](https://reference.aspose.com/slides/cs/java/com.aspose.slides/compress/) zavolejte [Presentation.save](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#save-java.lang.String-int-) k zapsání výsledku.

## **Související články**

- [Convert Presentation](/java/convert-presentation/)
- [Merge Presentations](/java/merge-presentation/)
- [Slide Master](/java/slide-master/)
- [Manage Text Box](/java/manage-textbox/)
- [Embedded Font](/java/embedded-font/)