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
description: "Převod starších souborů PPT na PPTX na Androidu pomocí Aspose.Slides. Obsahuje příklady v jazyce Java pro konverzi jednoho souboru i dávkovou konverzi, zpracování chyb a poznámky o věrnosti."
---
## **Přehled**

PPT je starší binární formát PowerPointu, zatímco PPTX je novější formát Open XML. Aspose.Slides pro Android prostřednictvím Java může načíst soubor PPT a uložit jej jako PPTX bez Microsoft PowerPoint. Tento článek ukazuje, jak převést jeden soubor nebo adresář souborů a vysvětluje, co ověřit po konverzi.

## **Převod souboru PPT na PPTX**

Načtěte zdrojový soubor pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/), pak zavolejte [Presentation.save](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) s argumentem [SaveFormat.Pptx](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/saveformat/#Pptx). Blok `finally` uvolní prezentaci a její prostředky.

```java
// Načíst starou PPT prezentaci.
com.aspose.slides.Presentation presentation = new com.aspose.slides.Presentation("presentation.ppt");
try {
    // Uložit prezentaci ve formátu PPTX.
    presentation.save("presentation.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Přípona souboru sama o sobě nevybírá výstupní formát; to dělá argument [SaveFormat.Pptx](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/saveformat/#Pptx). Uchovávejte vstupní a výstupní cesty odlišné, pokud potřebujete zachovat původní soubor PPT.

## **Převod více souborů PPT**

Následující příklad převádí každý soubor `.ppt` v jednom adresáři. Každý soubor je zpracován nezávisle, takže selhání jedné konverze nezastaví zbytek dávky.

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

Pro produkční zátěže zaznamenávejte úplnou výjimku, rozhodněte, zda může být existující výstupní soubor přepsán, a zapisujte názvy neúspěšných souborů do fronty pro opakování nebo revizi. Poškozené soubory, soubory chráněné heslem otevřené bez požadovaného hesla, nedostupné cesty a nepodporovaný obsah mohou všechny způsobit selhání konverze. Viz [Password-Protected Presentations](/androidjava/password-protected-presentation/) pro načítání šifrovaných souborů.

## **Věrnost a starší funkce**

Konverze obvykle zachovává snímky, předlohy, rozvržení, text, tvary, obrázky, tabulky a grafy. Přesto PPT a PPTX nepředstavují každou funkci přesně stejným způsobem. Starší funkce, která nemá ekvivalent v PPTX nebo není knihovnou podporována, může být normalizována, vynechána nebo zobrazena odlišně.

Zkontrolujte převedený soubor, pokud obsahuje animace, přechody, vložené nebo propojené OLE objekty, ActiveX ovládací prvky, vložená média, neobvyklá písma nebo VBA makra. Soubor PPTX není formát s podporou maker, takže použijte vhodný workflow s podporou maker, pokud musí být VBA k dispozici. Také ověřte, že požadovaná písma a externí zdroje jsou přítomny v prostředí, kde bude převedená prezentace otevřena nebo vykreslena.

Pro důležité dokumenty otevřete vygenerovaný PPTX programově a zkontrolujte klíčové počty snímků a obsah, poté porovnejte vzhled a chování prezentace v zamýšleném prohlížeči. Nepovažujte úspěšné volání [Presentation.save](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) za důkaz, že každá starší funkce má přesnou reprezentaci v PPTX.

## **Kdy použít PPTX**

Použijte PPTX, když bude prezentace upravována v aktuálních verzích PowerPointu, vyměňována se systémy pracujícími s balíčky Open XML, nebo ukládána ve formátu, který je snadnější zkontrolovat a obnovit než starý binární PPT. Uchovávejte původní PPT jako archivní nebo záložní kopii, dokud převedená prezentace neprojde vašimi kontrolami věrnosti.

Pokud potřebujete PDF, HTML, obrázky, XPS nebo jiný výstupní typ, použijte specifické pokyny v [Convert Presentations to Multiple Formats](/androidjava/convert-presentation/) místo předpokladu, že všechny cíle zachovávají editovatelné funkce PowerPointu.

## **Online převodník**

Pro příležitostný soubor nebo rychlé srovnání můžete použít [online PPT to PPTX converter](https://products.aspose.app/slides/cs/conversion/ppt-to-pptx). Pro opakovatelné konverze, dávkové zpracování nebo zpracování chyb na úrovni aplikace použijte Android via Java API.

## **Související články**

- [PPT vs PPTX](/androidjava/ppt-vs-pptx/)
- [Ukládání prezentací na Androidu](/androidjava/save-presentation/)
- [Podporované formáty souborů](/androidjava/supported-file-formats/)
- [Otevírání prezentací na Androidu](/androidjava/open-presentation/)

## **Často kladené otázky**

**Mohu převést PPT na PPTX bez nainstalovaného Microsoft PowerPoint?**

Ano. Aspose.Slides pro Android prostřednictvím Java načítá a ukládá soubory prezentací bez nutnosti Microsoft PowerPoint.

**Zachová konverze PPT na PPTX veškerý obsah přesně?**

Zachová běžný obsah prezentace, ale přesná věrnost není zaručena pro každou starší nebo nepodporovanou funkci. Zkontrolujte vygenerovaný soubor, pokud obsahuje makra, OLE nebo ActiveX objekty, média, specializované animace nebo neobvyklá písma.

**Mohu převést soubor PPT chráněný heslem?**

Ano, pokud při načítání souboru zadáte správné heslo. Chybějící nebo nesprávné heslo způsobí selhání načítání.

**Mám po konverzi soubor PPT smazat?**

Uchovávejte originál, dokud neověříte PPTX ve prohlížečích a pracovních postupech, které jsou pro vás důležité. To poskytuje záložní kopii, pokud se starší funkce převedou odlišně.