---
title: Převod PPT na PPTX v Javě
linktitle: PPT na PPTX
type: docs
weight: 20
url: /cs/java/convert-ppt-to-pptx/
keywords:
- převod PowerPointu
- převod prezentace
- převod snímku
- převod PPT
- PPT na PPTX
- uložit PPT jako PPTX
- exportovat PPT do PPTX
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Převod starých souborů PPT na PPTX v Javě pomocí Aspose.Slides. Obsahuje Java příklady pro konverzi jednoho souboru i dávkové konverze, zpracování chyb a poznámky o věrnosti."
---
## **Přehled**

PPT je starší binární formát PowerPointu, zatímco PPTX je novější formát Open XML. Aspose.Slides pro Java dokáže načíst soubor PPT a uložit jej jako PPTX bez Microsoft PowerPoint. Tento článek ukazuje, jak převést jeden soubor nebo adresář souborů a vysvětluje, co po převodu ověřit.

## **Převést soubor PPT na PPTX**

Načtěte zdrojový soubor pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) , poté zavolejte [Presentation.save](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#save-java.lang.String-int-) s argumentem [SaveFormat.Pptx](https://reference.aspose.com/slides/cs/java/com.aspose.slides/saveformat/#Pptx) . Blok `finally` uvolní prezentaci a její prostředky.

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

Přípona souboru sama o sobě nevybírá výstupní formát; rozhoduje o tom argument [SaveFormat.Pptx](https://reference.aspose.com/slides/cs/java/com.aspose.slides/saveformat/#Pptx) . Uchovávejte vstupní a výstupní cesty odlišné, pokud potřebujete zachovat původní soubor PPT.

## **Převést více souborů PPT**

Následující příklad převádí každý soubor `.ppt` v jednom adresáři. Každý soubor je zpracován nezávisle, takže selhání jedné konverze neukončí zbytek dávky.

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

Pro produkční pracovní zátěže zaznamenejte úplnou výjimku, rozhodněte, zda může být existující výstupní soubor přepsán, a zapište názvy neúspěšných souborů do fronty pro opakování nebo revizi. Poškozené soubory, soubory chráněné heslem otevřené bez požadovaného hesla, nedostupné cesty a nepodporovaný obsah mohou způsobit selhání konverze. Viz [Password-Protected Presentations](/slides/cs/java/password-protected-presentation/) pro načítání šifrovaných souborů.

## **Věrnost a starší funkce**

Konverze obvykle zachovává snímky, mastery, rozvržení, text, tvary, obrázky, tabulky a grafy. Nicméně PPT a PPTX nepředstavují každou funkci přesně stejným způsobem. Starší funkce, která nemá ekvivalent v PPTX nebo není knihovnou podporována, může být normalizována, vynechána nebo zobrazena odlišně.

Zkontrolujte převedený soubor, pokud obsahuje animace, přechody, vložené nebo odkazované OLE objekty, ovládací prvky ActiveX, vložená média, neobvyklá písma nebo VBA makra. Čistý soubor PPTX není formát podporující makra, takže použijte odpovídající workflow s podporou maker, pokud musí být VBA k dispozici. Také ověřte, že požadovaná písma a externí zdroje jsou přítomny v prostředí, kde bude převedená prezentace otevřena nebo vykreslena.

U důležitých dokumentů znovu otevřete generovaný PPTX programově a zkontrolujte klíčové počty snímků a jejich obsah, poté porovnejte jeho vzhled a chování prezentace ve zamýšleném prohlížeči. Nepovažujte úspěšné volání [Presentation.save](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#save-java.lang.String-int-) za důkaz, že každá starší funkce má přesnou PPTX reprezentaci.

## **Kdy použít PPTX**

Používejte PPTX, pokud bude prezentace upravována v aktuálních verzích PowerPointu, vyměňována se systémy pracujícími s balíčky Open XML, nebo uložena ve formátu, který je snadněji prověřitelný a obnovitelný než starší binární PPT. Uchovávejte původní PPT jako archivní nebo záložní kopii, dokud převedená prezentace neprojde vašimi kontrolami věrnosti.

Pokud místo toho potřebujete PDF, HTML, obrázky, XPS nebo jiný výstupní typ, použijte specifické pokyny pro formát v [Convert Presentations to Multiple Formats](/slides/cs/java/convert-presentation/) místo předpokladu, že všechny cíle zachovají upravitelná PowerPointová funkcionalita.

## **Online převaděč**

Pro občasný soubor nebo rychlé srovnání můžete použít [online PPT to PPTX converter](https://products.aspose.app/slides/cs/conversion/ppt-to-pptx) . Pro opakované konverze, dávkové zpracování nebo zpracování chyb na úrovni aplikace použijte Java API.

## **Související články**

- [PPT vs PPTX](/slides/cs/java/ppt-vs-pptx/)
- [Uložit prezentace v Javě](/slides/cs/java/save-presentation/)
- [Podporované formáty souborů](/slides/cs/java/supported-file-formats/)
- [Otevřít prezentace v Javě](/slides/cs/java/open-presentation/)

## **Často kladené otázky**

**Mohu převést PPT na PPTX bez nainstalovaného Microsoft PowerPoint?**

Ano. Aspose.Slides pro Java načítá a ukládá soubory prezentací bez potřeby Microsoft PowerPoint.

**Zachová konverze PPT na PPTX veškerý obsah přesně?**

Zachovává běžný obsah prezentace, ale přesná věrnost není zaručena pro každou starší či nepodporovanou funkci. Prohlédněte vygenerovaný soubor, pokud obsahuje makra, OLE nebo ActiveX objekty, média, specializované animace nebo neobvyklá písma.

**Mohu převést soubor PPT chráněný heslem?**

Ano, pokud při načítání souboru zadáte správné heslo. Chybějící nebo nesprávné heslo způsobí selhání načítací operace.

**Mám po konverzi smazat soubor PPT?**

Uchovávejte originál, dokud jste neověřili PPTX ve prohlížečích a pracovních postupech, které jsou pro vás důležité. To poskytuje záložní kopii pro případ, že starší funkce bude převedena odlišně.