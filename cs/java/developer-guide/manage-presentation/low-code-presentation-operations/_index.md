---
title: Operace s prezentacemi s nízkým kódem v Javě
linktitle: API s nízkým kódem
type: docs
weight: 50
url: /cs/java/low-code-presentation-operations/
keywords:
- API prezentace s nízkým kódem
- převod prezentace
- sloučení prezentací
- iterace snímků
- iterace tvarů
- iterace textu
- sběr tvarů
- komprese prezentace
- odstranění nepoužívaných hlavních snímků
- odstranění nepoužívaných rozvržení snímků
- komprese vložených fontů
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Použijte low-code API Aspose.Slides v Javě k převodu a sloučení prezentací, iteraci obsahu, sběru tvarů a snížení velikosti prezentace."
---
## **Přehled**

Balíček [com.aspose.slides](https://reference.aspose.com/slides/cs/java/com.aspose.slides/) poskytuje statické pomocné třídy pro běžné operace s prezentacemi. Tyto pomocníky zapouzdřují často používané pracovní postupy objektového modelu do zaměřených metod, takže můžete konvertovat nebo slučovat soubory, zpracovávat prvky prezentace, sbírat tvary a odstraňovat nepoužívaný obsah s menším množstvím kódu.

Nástroje s nízkým kódem jsou nejužitečnější, když se operace vztahuje na celý soubor nebo prezentaci a výchozí pracovní postup odpovídá vašim požadavkům. Použijte plný [Aspose.Slides object model](https://reference.aspose.com/slides/cs/java/com.aspose.slides/), pokud potřebujete jemnozrnnou kontrolu nad jednotlivými snímky, hlavními snímky, rozvržením, tvary, nastavením exportu nebo vztahy mezi prvky prezentace.

Následující tabulka shrnuje dostupné pomocníky:

| Pomocník | K čemu použít |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/cs/java/com.aspose.slides/convert/) | Převod prezentace do jiného formátu pomocí přímého volání soubor‑na‑soubor. |
| [Merger](https://reference.aspose.com/slides/cs/java/com.aspose.slides/merger/) | Kombinování kompletních souborů prezentací stejného formátu. |
| [ForEach](https://reference.aspose.com/slides/cs/java/com.aspose.slides/foreach/) | Spuštění akce pro každý snímek, tvar, odstavec nebo část textu. |
| [Collect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/collect/) | Získání tvarů z celé prezentace pro opakované zpracování nebo analýzu. |
| [Compress](https://reference.aspose.com/slides/cs/java/com.aspose.slides/compress/) | Odstranění nepoužívaných hlavních snímků a rozvržení a zmenšení vložených dat fontů. |

## **Převod prezentace**

Použijte [Convert.autoByExtension](https://reference.aspose.com/slides/cs/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) když je přípona výstupního souboru dostačující pro výběr formátu exportu. Metoda otevře zdrojovou prezentaci, určí požadovaný formát z výstupní cesty a zapíše výsledek.

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

[Convert](https://reference.aspose.com/slides/cs/java/com.aspose.slides/convert/) třída také poskytuje specializované metody pro výstup do PDF, SVG, JPEG, PNG a TIFF. Použijte plný objektový model, pokud potřebujete před exportem prezentaci prohlédnout nebo upravit či nakonfigurovat volbu exportu, která není poskytována vybraným pomocníkem. Viz [Convert Presentation](/slides/cs/java/convert-presentation/) pro pracovně‑specifické postupy a možnosti.

## **Sloučení prezentací**

Použijte [Merger.process](https://reference.aspose.com/slides/cs/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) pro sloučení kompletních souborů prezentací jedním voláním. Vstupní prezentace musí mít stejný formát souboru.

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

Tento pomocník je vhodný, když mají být všechny snímky připojeny k jednomu výsledku bez individuálního výběru nebo přemapování. Použijte plný objektový model, pokud potřebujete sloučit vybrané snímky, použít cílový hlavní snímek nebo rozvržení, explicitně zachovat sekce nebo sladit různé velikosti snímků. Viz [Merge Presentations](/slides/cs/java/merge-presentation/) pro tyto scénáře.

## **Iterace přes prvky prezentace**

Třída [ForEach](https://reference.aspose.com/slides/cs/java/com.aspose.slides/foreach/) volá zpětnou funkci pro každý požadovaný typ prvku prezentace. Vyhýbá se vnořeným smyčkám sbírek a je pohodlná pro celoprezentační kontrolu nebo změny formátování.

Následující příklad používá [ForEach.slide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-), [ForEach.shape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/cs/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), a [ForEach.portion](https://reference.aspose.com/slides/cs/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) k prozkoumání odpovídajících prvků:

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

Ve výchozím nastavení procházení tvarů a textu v celé prezentaci zahrnuje normální, hlavní a rozvržené snímky. Přetížení s parametrem `includeNotes` mohou také zpracovávat snímky poznámek. Použijte přímé smyčky sbírek, když je důležitý pořadí procházení, předčasný ukončení, filtrování před voláním zpětné funkce nebo podrobná kontrola rodič‑potomka.

## **Sbírání tvarů**

Použijte [Collect.shapes](https://reference.aspose.com/slides/cs/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) pokud potřebujete kolekci všech tvarů v prezentaci místo zpětné funkce pro každý tvar. To je užitečné, když bude stejná sada filtrována, počítána nebo zpracovávána více než jednou.

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

Použijte [ForEach.shape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) místo toho, když lze každý tvar zpracovat okamžitě a není potřeba uchovávat shromážděný výsledek.

## **Komprese obsahu prezentace**

Třída [Compress](https://reference.aspose.com/slides/cs/java/com.aspose.slides/compress/) může odstranit nepoužívané strukturální prvky a snížit data vložených fontů:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/cs/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) odstraňuje rozvržení snímků, na které neodkazuje žádný normální snímek.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/cs/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) odstraňuje hlavní snímky, které již nejsou používány.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/cs/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) odstraňuje nepoužívané znaky z vložených fontů.

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

Odstraňte nepoužívaná rozvržení před nepoužívanými hlavními snímky, aby hlavní snímek, který se po úklidu rozvržení stane neodkazovaným, mohl být také odstraněn. Uložte optimalizovanou prezentaci do nového souboru, pokud budete později potřebovat původní hlavní snímky, rozvržení nebo kompletní data vložených fontů. Další podrobnosti najdete v [Slide Master](/slides/cs/java/slide-master/) a [Embedded Font](/slides/cs/java/embedded-font/).

## **Často kladené otázky**

**Kdy bych měl použít low-code API místo kompletního objektového modelu?**

Používejte low-code pomocníky, když standardní operace platí pro celý soubor či prezentaci a nevyžaduje podrobnou kontrolu jednotlivých prvků. Použijte kompletní objektový model, pokud potřebujete vybrat konkrétní snímky, řídit vztahy hlavních snímků a rozvržení, prohlédnout mezistav nebo nakonfigurovat chování, které pomocník neexponuje.

**Může Merger kombinovat prezentace v různých formátech souborů?**

Ne. [Merger.process](https://reference.aspose.com/slides/cs/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) vyžaduje vstupní prezentace ve stejném formátu. Nejprve převeďte vstupní soubory do společného formátu, například pomocí [Convert.autoByExtension](https://reference.aspose.com/slides/cs/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-), a poté spojte převedené soubory.

**Zpracovává ForEach hlavní, rozvržené a poznámkové snímky?**

[ForEach.slide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) prochází normální snímky prezentace. Celoprezentační operace [ForEach.shape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/cs/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-) a [ForEach.portion](https://reference.aspose.com/slides/cs/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) zahrnují ve výchozím nastavení normální, hlavní a rozvržené snímky. Použijte jejich přetížení s parametrem `includeNotes` nastaveným na `true`, pokud chcete zahrnout i snímky poznámek.

**Jaký je rozdíl mezi ForEach.shape a Collect.shapes?**

Použijte [ForEach.shape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), pokud chcete každý tvar zpracovat okamžitě pomocí zpětné funkce. Použijte [Collect.shapes](https://reference.aspose.com/slides/cs/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-), pokud potřebujete iterovatelný výsledek, který lze uchovat, filtrovat, počítat nebo procházet vícekrát.

**Zmenšuje Compress vždy velikost souboru prezentace?**

Ne nutně. Výsledek závisí na tom, zda prezentace obsahuje nepoužívaná rozvržení, nepoužívané hlavní snímky nebo vložené fonty s nepoužívanými znaky. Pokud žádné z nich nejsou, odpovídající operace [Compress] nemusí velikost souboru zmenšit.

**Ukládají se změny provedené pomocí ForEach nebo Compress automaticky?**

Ne. Títo pomocníci pracují s načteným objektem [Presentation] v paměti. Po změně prvků v zpětné funkci [ForEach] nebo spuštění [Compress] zavolejte [Presentation.save](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#save-java.lang.String-int-) pro zápis výsledku.

## **Související články**

- [Convert Presentation](/slides/cs/java/convert-presentation/)
- [Merge Presentations](/slides/cs/java/merge-presentation/)
- [Slide Master](/slides/cs/java/slide-master/)
- [Manage Text Box](/slides/cs/java/manage-textbox/)
- [Embedded Font](/slides/cs/java/embedded-font/)