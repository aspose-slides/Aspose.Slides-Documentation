---
title: Načtení a aktualizace informací o prezentaci v Javě
linktitle: Informace o prezentaci
type: docs
weight: 30
url: /cs/java/examine-presentation/
keywords:
- formát prezentace
- vlastnosti prezentace
- vlastnosti dokumentu
- získat vlastnosti
- číst vlastnosti
- měnit vlastnosti
- upravit vlastnosti
- aktualizovat vlastnosti
- prozkoumat PPTX
- prozkoumat PPT
- prozkoumat ODP
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Prozkoumejte snímky, strukturu a metadata v prezentacích PowerPoint a OpenDocument pomocí Javy pro rychlejší poznatky a chytřejší audit obsahu."
---
## **Přehled**

Aspose.Slides dokáže rozpoznat formát prezentace a načíst její metadata dokumentu, aniž by vytvořil kompletní objektový model prezentace. To je užitečné, když potřebujete soubory klasifikovat, vytvořit inventář nebo prozkoumat vlastnosti před tím, než se rozhodnete načíst a zpracovat obsah prezentace.

Tento článek demonstruje odlehčenou kontrolu pomocí [PresentationFactory](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentationfactory/) a [IPresentationInfo](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentationinfo/), stejně jako cílené aktualizace pomocí [IDocumentProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/idocumentproperties/).

## **Zkontrolujte formát prezentace**

Pokud již máte načtenou prezentaci, podívejte se na [Determine the Original Presentation Format](/slides/cs/java/detect-presentation-source-format/) pro detekci po načtení a na omezení starších PPT, PPS a POT proudů.

Použijte [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) k prohlédnutí souboru bez vytváření instance [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/). Metoda [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentationinfo/#getLoadFormat--) hlásí detekovaný formát, např. PPTX, PPT nebo ODP.

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadFormat;
import com.aspose.slides.PresentationFactory;

String[] fileNames = { "pres.pptx", "pres.ppt", "pres.odp" };

for (String fileName : fileNames) {
    IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(fileName);
    int loadFormat = presentationInfo.getLoadFormat();
    String formatName = "Other (" + loadFormat + ")";

    if (loadFormat == LoadFormat.Pptx) {
        formatName = "PPTX";
    } else if (loadFormat == LoadFormat.Ppt) {
        formatName = "PPT";
    } else if (loadFormat == LoadFormat.Odp) {
        formatName = "ODP";
    }

    System.out.println(fileName + ": " + formatName);
}
```

## **Vytvořte odlehčený inventář prezentací**

Když zpracováváte mnoho souborů prezentací, můžete potřebovat kompaktní inventář pro validaci, indexování nebo systém správy dokumentů. V tomto scénáři použijte [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) k získání objektu [IPresentationInfo](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentationinfo/), a poté zavolejte [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) k načtení metadat dokumentu. Tento přístup nevytváří instanci [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) ani nevyžaduje procházet kompletní objektový model prezentace.

Rozšířené vlastnosti vystavené [IDocumentProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/idocumentproperties/) poskytují následující hodnoty inventáře:

| Metoda | Hodnota inventáře |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/cs/java/com.aspose.slides/idocumentproperties/#getSlides--) | Celkový počet snímků. |
| [getHiddenSlides](https://reference.aspose.com/slides/cs/java/com.aspose.slides/idocumentproperties/#getHiddenSlides--) | Počet skrytých snímků. |
| [getNotes](https://reference.aspose.com/slides/cs/java/com.aspose.slides/idocumentproperties/#getNotes--) | Počet snímků, které obsahují poznámky. |
| [getParagraphs](https://reference.aspose.com/slides/cs/java/com.aspose.slides/idocumentproperties/#getParagraphs--) | Celkový počet odstavců, pokud jsou k dispozici. |
| [getWords](https://reference.aspose.com/slides/cs/java/com.aspose.slides/idocumentproperties/#getWords--) | Celkový počet slov. |
| [getMultimediaClips](https://reference.aspose.com/slides/cs/java/com.aspose.slides/idocumentproperties/#getMultimediaClips--) | Celkový počet audio a video klipů. |

Následující příklad načte tyto hodnoty bez vytvoření objektu [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) a vypíše kompaktní inventář. Také kombinuje [getHeadingPairs](https://reference.aspose.com/slides/cs/java/com.aspose.slides/idocumentproperties/#getHeadingPairs--) s [getTitlesOfParts](https://reference.aspose.com/slides/cs/java/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) pro zobrazení skupin obsahu, jako jsou písma, motivy a názvy snímků.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IHeadingPair;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadFormat;
import com.aspose.slides.PresentationFactory;
import java.nio.file.Paths;

String filePath = "sample.pptx";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(filePath);
IDocumentProperties documentProperties = presentationInfo.readDocumentProperties();

int loadFormat = presentationInfo.getLoadFormat();
String formatName = "Other (" + loadFormat + ")";

if (loadFormat == LoadFormat.Pptx) {
    formatName = "PPTX";
} else if (loadFormat == LoadFormat.Ppt) {
    formatName = "PPT";
} else if (loadFormat == LoadFormat.Odp) {
    formatName = "ODP";
}

System.out.println("File: " + Paths.get(filePath).getFileName());
System.out.println("Format: " + formatName);
System.out.println("Title: " + documentProperties.getTitle());
System.out.println("Author: " + documentProperties.getAuthor());
System.out.println("Statistics:");
System.out.println("  Slides: " + documentProperties.getSlides());
System.out.println("  Hidden slides: " + documentProperties.getHiddenSlides());
System.out.println("  Slides with notes: " + documentProperties.getNotes());
System.out.println("  Paragraphs: " + documentProperties.getParagraphs());
System.out.println("  Words: " + documentProperties.getWords());
System.out.println("  Multimedia clips: " + documentProperties.getMultimediaClips());

IHeadingPair[] headingPairs = documentProperties.getHeadingPairs();
String[] titlesOfParts = documentProperties.getTitlesOfParts();
headingPairs = headingPairs != null ? headingPairs : new IHeadingPair[0];
titlesOfParts = titlesOfParts != null ? titlesOfParts : new String[0];
int partIndex = 0;

if (headingPairs.length == 0 || titlesOfParts.length == 0) {
    System.out.println("Content groups: not available");
} else {
    System.out.println("Content groups:");

    for (IHeadingPair headingPair : headingPairs) {
        System.out.println("  " + headingPair.getName() + " (" + headingPair.getCount() + ")");

        for (int partOffset = 0; partOffset < headingPair.getCount() && partIndex < titlesOfParts.length; partOffset++) {
            System.out.println("    - " + titlesOfParts[partIndex]);
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.length) {
        System.out.println("  Other parts:");

        while (partIndex < titlesOfParts.length) {
            System.out.println("    - " + titlesOfParts[partIndex]);
            partIndex++;
        }
    }
}
```

Každý [IHeadingPair](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iheadingpair/) poskytuje název skupiny a počet položek v této skupině. [IDocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/cs/java/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) vrací ploché, seřazené pole, takže je třeba spotřebovat počet po sobě jdoucích názvů určených každým párem nadpisů.

### **Uložená metadata a omezení formátu**

Vlastnosti inventáře vrácené metodou [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) odrážejí metadata dostupná ve zdrojovém dokumentu. Aspose.Slides nenačítá a neprochází objektový model prezentace pro přepočet těchto hodnot během tohoto volání. Chybějící vlastnosti jsou reprezentovány výchozími hodnotami a uložené hodnoty mohou být zastaralé, pokud aplikace, která soubor naposledy uložila, neaktualizovala jeho vlastnosti dokumentu.

- **PPTX:** Formát poskytuje rozšířené vlastnosti dokumentu pro počty snímků, poznámek, skrytých snímků, odstavců, slov a multimedií, stejně jako páry nadpisů a názvy částí. Dostupnost závisí na tom, které vlastnosti byly zapsány výrobcem dokumentu.
- **PPT:** Binární formát může uložit odpovídající vlastnosti souhrnu dokumentu. Pokud vlastnost chybí nebo nebyla aktualizována výrobcem dokumentu, Aspose.Slides vrátí její uloženou nebo výchozí hodnotu místo výpočtu z snímků.
- **ODP:** Metadata OpenDocument poskytují obecné statistiky dokumentu, jako jsou počty stránek, odstavců a slov, ale tyto hodnoty neodpovídají všem rozšířeným vlastnostem specifickým pro PowerPoint. Metadata pro skryté snímky, poznámky, multimédia, páry nadpisů a názvy částí mohou být nedostupná a vlastnosti inventáře mohou vracet výchozí hodnoty. Nevnímejte nulovou hodnotu nebo prázdné pole jako autoritativní důkaz, že odpovídající obsah chybí.

Použijte odlehčený přístup k metadatům pro inventáře a předběžné kontroly. Načtěte prezentaci a prověřte její živý objektový model, když výsledek musí odrážet změny v paměti nebo když potřebujete ověřit skutečný obsah prezentace.

## **Aktualizace vlastností prezentace**

Vlastnosti vrácené metodou [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) lze také změnit bez vytvoření instance [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/). Použijte [IPresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentationinfo/#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) a poté zapište vázanou prezentaci pomocí [IPresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentationinfo/#writeBindedPresentation-java.io.OutputStream-).

Následující obrázek zobrazuje původní vlastnosti dokumentu.

![Původní vlastnosti dokumentu PowerPoint prezentace](input_properties.png)

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.PresentationFactory;
import java.io.FileOutputStream;
import java.io.OutputStream;
import java.util.Date;

String sourceFile = "sample.pptx";
String outputFile = "sample_with_updated_properties.pptx";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(sourceFile);
IDocumentProperties documentProperties = presentationInfo.readDocumentProperties();

documentProperties.setTitle("Quarterly sales report");
documentProperties.setLastSavedTime(new Date());

presentationInfo.updateDocumentProperties(documentProperties);
try (OutputStream outputStream = new FileOutputStream(outputFile)) {
    presentationInfo.writeBindedPresentation(outputStream);
}
```

Následující obrázek zobrazuje aktualizované vlastnosti dokumentu.

![Změněné vlastnosti dokumentu PowerPoint prezentace](output_properties.png)

## **Užitečné odkazy**

Pro související bezpečnostní kontroly a nastavení ochrany si prohlédněte následující články:

- [Password-Protect Presentations](/slides/cs/java/password-protected-presentation/)
- [Write-Protect Presentations](/slides/cs/java/write-protected-presentation/)

## **Často kladené otázky**

**Jak mohu zkontrolovat, zda jsou písma vložena a která to jsou?**

Načtěte prezentaci a použijte [Presentation.getFontsManager](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#getFontsManager--). Zavolejte [IFontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) pro získání vložených písem a [IFontsManager.getFonts](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ifontsmanager/#getFonts--) pro získání písem použitých v prezentaci. Porovnejte oba výsledky a zjistěte, která písma jsou pro vykreslení nutná, ale nejsou vložena.

**Jak mohu rychle zjistit, zda soubor obsahuje skryté snímky a kolik jich je?**

Když jsou uložená metadata dokumentu dostatečná, přečtěte [IDocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/cs/java/com.aspose.slides/idocumentproperties/#getHiddenSlides--) přes [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) a [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--). To je vhodné pro odlehčený inventář. Pokud byla prezentace změněna v paměti, mohou být uložená metadata chybějící nebo zastaralá, nebo pokud potřebujete ověřit aktuální hodnoty, projděte [Presentation.getSlides](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#getSlides--) a pro každý snímek použijte metodu [ISlide.getHidden](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islide/#getHidden--).

**Mohu zjistit, zda je použita vlastní velikost a orientace snímku, a zda se liší od výchozích?**

Ano. Načtěte prezentaci a zavolejte [Presentation.getSlideSize](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#getSlideSize--). Použijte [ISlideSize.getType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islidesize/#getType--), [ISlideSize.getSize](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islidesize/#getSize--) a [ISlideSize.getOrientation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islidesize/#getOrientation--) k porovnání aktuálního nastavení s očekávaným předdefinovaným a rozměry.

**Existuje rychlý způsob, jak zjistit, zda grafy odkazují na externí datové zdroje?**

Ano. Najděte každý [Chart](https://reference.aspose.com/slides/cs/java/com.aspose.slides/chart/) a zavolejte [IChartData.getDataSourceType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdata/#getDataSourceType--). Pro externí sešit zavolejte [IChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdata/#getExternalWorkbookPath--). Typ datového zdroje a cesta identifikují externí odkaz, ale ověření, zda je cíl dostupný, vyžaduje samostatnou kontrolu zdrojů.

**Jak mohu posoudit „těžké“ snímky, které mohou zpomalit vykreslování nebo export do PDF?**

Neexistuje jediná vlastnost komplexnosti. Projděte [Presentation.getSlides](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#getSlides--) a kolekci [IBaseSlide.getShapes](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibaseslide/#getShapes--) každého snímku. Použijte počet tvarů a přítomnost velkých obrázků, efektů, animací nebo multimédií jako signály pro screening a změřte reprezentativní vykreslení nebo export, než označíte snímek za potvrzený výkonový úzký hrdlo.