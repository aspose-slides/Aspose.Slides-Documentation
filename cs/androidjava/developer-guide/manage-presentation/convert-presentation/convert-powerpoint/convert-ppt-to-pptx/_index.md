---
title: Převod PPT na PPTX na Androidu
linktitle: PPT na PPTX
type: docs
weight: 20
url: /cs/androidjava/convert-ppt-to-pptx/
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
- Android
- Java
- Aspose.Slides
description: "Převod starých souborů PPT na PPTX na Androidu pomocí Aspose.Slides. Obsahuje příklady v Jave pro převod jednoho souboru i dávkový převod, zpracování chyb a poznámky o věrnosti."
---
## **Přehled**

PPT je starší binární formát PowerPointu, zatímco PPTX je novější formát Open XML. Aspose.Slides pro Android prostřednictvím Java může načíst soubor PPT a uložit jej jako PPTX bez Microsoft PowerPoint. Tento článek ukazuje, jak převést jeden soubor nebo adresář souborů a vysvětluje, co zkontrolovat po převodu.

## **Převod souboru PPT na PPTX**

Načtěte zdrojový soubor pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) , poté zavolejte [Presentation.save](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) s argumentem [SaveFormat.Pptx](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/saveformat/#Pptx) . Blok `finally` uvolní prezentaci a její zdroje.

```java
// Načíst starou prezentaci PPT.
com.aspose.slides.Presentation presentation = new com.aspose.slides.Presentation("presentation.ppt");
try {
    // Uložit prezentaci ve formátu PPTX.
    presentation.save("presentation.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Přípona souboru sama o sobě nevybírá výstupní formát; to dělá argument [SaveFormat.Pptx](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/saveformat/#Pptx) . Pokud potřebujete zachovat původní soubor PPT, udržujte vstupní a výstupní cesty odlišné.

## **Převod více souborů PPT**

Následující příklad převádí každý soubor `.ppt` v jednom adresáři. Každý soubor je zpracován nezávisle, takže jeden neúspěšný převod nezastaví zbytek dávky.

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

Pro produkční úlohy zaznamenávejte úplnou výjimku, rozhodněte, zda může být existující výstupní soubor přepsán, a zaznamenejte názvy neúspěšných souborů do fronty pro opakování nebo revizi. Poškozené soubory, soubory chráněné heslem otevřené bez požadovaného hesla, nedostupné cesty a nepodporovaný obsah mohou způsobit selhání převodu. Viz [Password-Protected Presentations](/androidjava/password-protected-presentation/) pro načítání šifrovaných souborů.

## **Věrnost a starší funkce**

Převod obvykle zachovává snímky, osnovy, rozvržení, text, tvary, obrázky, tabulky a grafy. Přesto PPT a PPTX nevyjadřují každou funkci přesně stejným způsobem. Starší funkce, která nemá ekvivalent v PPTX, nebo není knihovnou podporována, může být normalizována, vynechána nebo zobrazena odlišně.

Zkontrolujte převodovaný soubor, pokud obsahuje animace, přechody, vložené nebo propojené OLE objekty, ActiveX ovládací prvky, vložená média, neobvyklá písma nebo VBA makra. Pouhý soubor PPTX není formát podporující makra, proto použijte vhodný workflow podporující makra, když je třeba zachovat VBA. Také ověřte, že požadovaná písma a externí zdroje jsou přítomny v prostředí, kde bude převodovaná prezentace otevřena nebo vykreslena.

U důležitých dokumentů znovu otevřete vygenerovaný PPTX programově a prověřte klíčové počty snímků a jejich obsah, poté porovnejte jeho vzhled a chování prezentace ve zamýšleném prohlížeči. Nepovažujte úspěšné volání [Presentation.save](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) za důkaz, že každá starší funkce má přesnou PPTX reprezentaci.

## **Kdy použít PPTX**

Použijte PPTX, pokud bude prezentace upravována v aktuálních verzích PowerPointu, vyměňována se systémy pracujícími s balíčky Open XML, nebo ukládána ve formátu, který je snazší prozkoumat a obnovit než starší binární PPT. Uchovávejte původní PPT jako archivní nebo záložní kopii, dokud převodovaná prezentace neprojde vašimi kontrolami věrnosti.

Pokud místo toho potřebujete PDF, HTML, obrázky, XPS nebo jiný výstupní typ, použijte specifické pokyny pro formáty v [Convert Presentations to Multiple Formats](/slides/cs/androidjava/convert-presentation/) místo předpokladu, že všechny cíle zachovají editovatelné funkce PowerPointu.

## **Online převodník**

Pro občasný soubor nebo rychlé srovnání můžete použít [online PPT to PPTX converter](https://products.aspose.app/slides/cs/conversion/ppt-to-pptx). Pro opakované převody, dávkové zpracování nebo zpracování chyb na úrovni aplikace použijte Android via Java API.

## **Související články**

- [PPT vs PPTX](/slides/cs/androidjava/ppt-vs-pptx/)
- [Ukládat prezentace na Androidu](/slides/cs/androidjava/save-presentation/)
- [Podporované formáty souborů](/slides/cs/androidjava/supported-file-formats/)
- [Otevřít prezentace na Androidu](/slides/cs/androidjava/open-presentation/)

## **Často kladené otázky**

**Mohu převést PPT na PPTX bez nainstalovaného Microsoft PowerPoint?**

Ano. Aspose.Slides pro Android prostřednictvím Java načítá a ukládá soubory prezentací, aniž by vyžadoval Microsoft PowerPoint.

**Zachová převod PPT na PPTX veškerý obsah přesně?**

Uchovává běžný obsah prezentace, ale přesná věrnost není zaručena pro každou starší nebo nepodporovanou funkci. Prohlédněte vygenerovaný soubor, pokud obsahuje makra, OLE nebo ActiveX objekty, média, specializované animace nebo neobvyklá písma.

**Mohu převést soubor PPT chráněný heslem?**

Ano, pokud při načítání souboru zadáte správné heslo. Chybějící nebo nesprávné heslo způsobí selhání operace načtení.

**Mám po převodu smazat soubor PPT?**

Uchovávejte originál, dokud neověříte PPTX v prohlížečích a pracovních postupech, které jsou pro vás důležité. To poskytuje záložní kopii pro případ, že se starší funkce převede odlišně.