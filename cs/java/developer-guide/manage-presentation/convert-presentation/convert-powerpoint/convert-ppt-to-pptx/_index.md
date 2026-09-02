---
title: Převod PPT na PPTX v Javě
linktitle: PPT na PPTX
type: docs
weight: 20
url: /cs/java/convert-ppt-to-pptx/
keywords:
- převést PowerPoint
- převést prezentaci
- převést snímek
- převést PPT
- PPT na PPTX
- uložit PPT jako PPTX
- exportovat PPT do PPTX
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Převod starých souborů PPT na PPTX v Javě s Aspose.Slides. Obsahuje příklady v Javě pro převod jednoho souboru i dávkový převod, zpracování chyb a poznámky o věrnosti."
---
## **Přehled**

PPT je starší binární formát PowerPointu, zatímco PPTX je novější formát Open XML. Aspose.Slides pro Java může načíst soubor PPT a uložit jej jako PPTX bez Microsoft PowerPointu. Tento článek ukazuje, jak převést jeden soubor nebo adresář souborů a vysvětluje, co ověřit po konverzi.

## **Převod souboru PPT na PPTX**

Načtěte zdrojový soubor pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/), poté zavolejte [Presentation.save](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#save-java.lang.String-int-) s argumentem [SaveFormat.Pptx](https://reference.aspose.com/slides/cs/java/com.aspose.slides/saveformat/#Pptx). Blok `finally` uvolní prezentaci a její prostředky.

```java
// Načtěte starou PPT prezentaci.
com.aspose.slides.Presentation presentation = new com.aspose.slides.Presentation("presentation.ppt");
try {
    // Uložte prezentaci ve formátu PPTX.
    presentation.save("presentation.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Přípona souboru sama o sobě nevybírá výstupní formát; to určuje argument [SaveFormat.Pptx](https://reference.aspose.com/slides/cs/java/com.aspose.slides/saveformat/#Pptx). Ujistěte se, že vstupní a výstupní cesty jsou odlišné, pokud potřebujete zachovat původní soubor PPT.

## **Převod více souborů PPT**

Následující příklad převádí každý soubor `.ppt` v jednom adresáři. Každý soubor je zpracován samostatně, takže selhání jedné konverze nezastaví zbytek dávky.

```java
java.io.File inputDirectory = new java.io.File("input");
java.io.File outputDirectory = new java.io.File("output");
if (!outputDirectory.exists() && !outputDirectory.mkdirs()) {
    throw new IllegalStateException("Cannot create the output directory: " + outputDirectory);
}

java.io.File[] inputFiles = inputDirectory.listFiles((directory, name) -> name.toLowerCase(java.util.Locale.ROOT).endsWith(".ppt"));
if (inputFiles == null) {
    throw new IllegalStateException("Cannot read the input directory: " + inputDirectory);
}

for (java.io.File inputFile : inputFiles) {
    String inputPath = inputFile.getPath();
    String fileName = inputFile.getName();
    String outputFileName = fileName.substring(0, fileName.length() - 4) + ".pptx";
    String outputPath = new java.io.File(outputDirectory, outputFileName).getPath();
    com.aspose.slides.Presentation presentation = null;

    try {
        presentation = new com.aspose.slides.Presentation(inputPath);
        presentation.save(outputPath, com.aspose.slides.SaveFormat.Pptx);
        System.out.println("Converted: " + inputPath);
    } catch (Exception exception) {
        System.err.println("Failed: " + inputPath + " (" + exception.getMessage() + ")");
    } finally {
        if (presentation != null) {
            presentation.dispose();
        }
    }
}
```

Pro produkční úlohy zaznamenejte celé výjimky, rozhodněte, zda může být přepsán existující výstupní soubor, a zapište názvy souborů, u kterých konverze selhala, do fronty pro opakování nebo revizi. Poškozené soubory, soubory chráněné heslem otevřené bez požadovaného hesla, nedostupné cesty a nepodporovaný obsah mohou všechny způsobit selhání konverze. Viz [Password-Protected Presentations](/java/password-protected-presentation/) pro načítání šifrovaných souborů.

## **Věrnost a starší funkce**

Konverze obvykle zachovává snímky, mastery, rozložení, text, tvary, obrázky, tabulky a grafy. Nicméně PPT a PPTX nepředstavují každou funkci přesně stejným způsobem. Starší funkce, která nemá ekvivalent v PPTX nebo není knihovnou podporována, může být normalizována, vynechána nebo zobrazena odlišně.

Zkontrolujte převedený soubor, pokud obsahuje animace, přechody, vložené nebo propojené objekty OLE, ovládací prvky ActiveX, vložená média, neobvyklá písma nebo makra VBA. Pouhý soubor PPTX není formát podporující makra, proto použijte vhodný workflow pro soubory s povolenými makry, pokud je třeba zachovat VBA. Také ověřte, že požadovaná písma a externí zdroje jsou přítomny v prostředí, kde bude převedená prezentace otevřena nebo vykreslena.

U důležitých dokumentů znovu otevřete vygenerovaný PPTX programově a prověřte klíčové počty snímků a obsah, poté porovnejte jeho vzhled a chování prezentace ve zamýšleném prohlížeči. Nepovažujte úspěšné volání [Presentation.save](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#save-java.lang.String-int-) za důkaz, že každá starší funkce má přesnou reprezentaci v PPTX.

## **Kdy použít PPTX**

Používejte PPTX, když bude prezentace upravována v aktuálních verzích PowerPointu, výměnou s systémy pracujícími s Open XML balíčky, nebo ukládána ve formátu, který je snadněji kontrolovatelný a obnovitelný než starý binární PPT. Uchovávejte původní PPT jako archivní nebo záložní kopii, dokud převedená prezentace neprojde vašimi kontrolami věrnosti.

Pokud místo toho potřebujete PDF, HTML, obrázky, XPS nebo jiný výstupní typ, použijte specifické pokyny pro formát v [Convert Presentations to Multiple Formats](/java/convert-presentation/) místo předpokladu, že všechny cíle zachovají editovatelné funkce PowerPointu.

## **Online převodník**

Pro občasný soubor nebo rychlé srovnání můžete použít [online PPT to PPTX converter](https://products.aspose.app/slides/cs/conversion/ppt-to-pptx). Pro opakované konverze, dávkové zpracování nebo zpracování chyb na úrovni aplikace použijte Java API.

## **Související články**

- [PPT vs PPTX](/java/ppt-vs-pptx/)
- [Ukládat prezentace v Javě](/java/save-presentation/)
- [Podporované formáty souborů](/java/supported-file-formats/)
- [Otevírání prezentací v Javě](/java/open-presentation/)

## **Často kladené otázky**

**Mohu převést PPT na PPTX bez nainstalovaného Microsoft PowerPointu?**

Ano. Aspose.Slides pro Java načítá a ukládá soubory prezentací bez nutnosti Microsoft PowerPointu.

**Zachová konverze PPT na PPTX veškerý obsah přesně?**

Zachovává běžný obsah prezentací, ale přesná věrnost není zaručena pro každou starší nebo nepodporovanou funkci. Zkontrolujte vygenerovaný soubor, pokud obsahuje makra, objekty OLE nebo ActiveX, média, specializované animace či neobvyklá písma.

**Mohu převést soubor PPT chráněný heslem?**

Ano, pokud při načítání souboru zadáte správné heslo. Chybějící nebo nesprávné heslo způsobí selhání načítací operace.

**Mám po konverzi soubor PPT smazat?**

Uchovávejte originál, dokud neověříte PPTX v prohlížečích a pracovních postupech, které jsou pro vás důležité. To poskytuje záložní kopii pro případ, že se starší funkce převede odlišně.