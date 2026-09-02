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
- změnit vlastnosti
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
description: "Prozkoumejte snímky, strukturu a metadata v prezentacích PowerPoint a OpenDocument pomocí Javy pro rychlejší poznání a inteligentnější audity obsahu."
---
## **Přehled**

Aspose.Slides dokáže rozpoznat formát prezentace a přečíst metadata dokumentu, aniž by vytvářelo úplný model objektů prezentace. To je užitečné, když potřebujete klasifikovat soubory, vytvořit inventář nebo prozkoumat vlastnosti před tím, než se rozhodnete načíst a zpracovat obsah prezentace.

Tento článek demonstruje lehkou inspekci pomocí [PresentationFactory](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentationfactory/) a [IPresentationInfo](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentationinfo/), a také cílené aktualizace pomocí [IDocumentProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/idocumentproperties/).

## **Kontrola formátu prezentace**

Použijte [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) k prověření souboru, aniž byste vytvořili instanci [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/). Metoda [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentationinfo/#getLoadFormat--) uvádí detekovaný formát, například PPTX, PPT nebo ODP.

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

## **Vytvoření lehkého inventáře prezentací**

Když zpracováváte mnoho souborů prezentací, můžete potřebovat kompaktní inventář pro validaci, indexaci nebo systém správy dokumentů. V tomto scénáři použijte [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) k získání objektu [IPresentationInfo](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentationinfo/) a poté zavolejte [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) k načtení metadat dokumentu. Tento přístup nevytváří instanci [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) ani nevyžaduje procházet kompletním modelem objektů prezentace.

Rozšířené vlastnosti vystavené pomocí [IDocumentProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/idocumentproperties/) poskytují následující hodnoty inventáře:

| Metoda | Inventární hodnota |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/cs/java/com.aspose.slides/idocumentproperties/#getSlides--) | Celkový počet snímků. |
| [getHiddenSlides](https://reference.aspose.com/slides/cs/java/com.aspose.slides/idocumentproperties/#getHiddenSlides--) | Počet skrytých snímků. |
| [getNotes](https://reference.aspose.com/slides/cs/java/com.aspose.slides/idocumentproperties/#getNotes--) | Počet snímků, které obsahují poznámky. |
| [getParagraphs](https://reference.aspose.com/slides/cs/java/com.aspose.slides/idocumentproperties/#getParagraphs--) | Celkový počet odstavců, pokud jsou k dispozici. |
| [getWords](https://reference.aspose.com/slides/cs/java/com.aspose.slides/idocumentproperties/#getWords--) | Celkový počet slov. |
| [getMultimediaClips](https://reference.aspose.com/slides/cs/java/com.aspose.slides/idocumentproperties/#getMultimediaClips--) | Celkový počet audio a video klipů. |

Následující příklad načte tyto hodnoty, aniž by vytvořil objekt [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) a vypíše kompaktní inventář. Také kombinuje [getHeadingPairs](https://reference.aspose.com/slides/cs/java/com.aspose.slides/idocumentproperties/#getHeadingPairs--) s [getTitlesOfParts](https://reference.aspose.com/slides/cs/java/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) pro zobrazení skupin obsahu, jako jsou písma, motivy a názvy snímků.

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

Každý [IHeadingPair](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iheadingpair/) poskytuje název skupiny a počet položek v této skupině. [IDocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/cs/java/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) vrací ploché, uspořádané pole, takže zpracujte počet po sobě jdoucích názvů určených každým párem nadpisu.

### **Uložená metadata a omezení formátu**

Vlastnosti inventáře vrácené metodou [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) odrážejí metadata dostupná ve zdrojovém dokumentu. Aspose.Slides nenačítá a neprochází modelem objektů prezentace za účelem přepočítání těchto hodnot pro toto volání. Chybějící vlastnosti jsou reprezentovány výchozími hodnotami a uložené hodnoty mohou být zastaralé, pokud aplikace, která naposledy soubor uložila, neaktualizovala dokumentové vlastnosti.

- **PPTX:** Formát poskytuje rozšířené dokumentové vlastnosti pro počet snímků, poznámek, skrytých snímků, odstavců, slov a multimediálních klipů, stejně jako páry nadpisů a názvy částí. Dostupnost závisí na tom, které vlastnosti byly zapsány výrobcem dokumentu.
- **PPT:** Binární formát může uložit odpovídající souhrnné vlastnosti dokumentu. Pokud vlastnost chybí nebo nebyla výrobcem dokumentu aktualizována, Aspose.Slides vrátí její uloženou nebo výchozí hodnotu místo výpočtu ze snímků.
- **ODP:** Metadata OpenDocument poskytují obecné statistiky dokumentu, jako je počet stránek, odstavců a slov, ale tyto hodnoty neodpovídají všem specifickým rozšířeným vlastnostem PowerPointu. Metadata pro skryté snímky, poznámky, multimédia, páry nadpisů a názvy částí mohou být nedostupná a vlastnosti inventáře mohou vracet výchozí hodnoty. Nepovažujte nulovou hodnotu nebo prázdné pole za definitivní důkaz, že odpovídající obsah chybí.

Používejte lehký přístup k metadatům pro inventáře a předběžné kontroly. Načtěte prezentaci a prohlédněte její živý model objektů, když výsledek musí odrážet změny v paměti nebo když potřebujete ověřit skutečný obsah prezentace.

## **Aktualizace vlastností prezentace**

Vlastnosti vrácené metodou [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) lze také změnit bez vytvoření instance [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/). Proveďte změny pomocí [IPresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentationinfo/#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), a poté zapište svázanou prezentaci pomocí [IPresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentationinfo/#writeBindedPresentation-java.io.OutputStream-).

Následující obrázek zobrazuje původní vlastnosti dokumentu PowerPoint prezentace.

![Původní vlastnosti dokumentu PowerPoint prezentace](input_properties.png)

Následující příklad změní název a čas posledního uložení a zapíše výsledek do nového souboru:

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

Pro související bezpečnostní kontroly a nastavení ochrany si přečtěte následující články:

- [Prezentace chráněné heslem](/slides/cs/java/password-protected-presentation/)
- [Prezentace chráněné proti zápisu](/slides/cs/java/write-protected-presentation/)

## **Často kladené otázky**

**Jak mohu zjistit, zda jsou písma vložena a která to jsou?**

Načtěte prezentaci a použijte [Presentation.getFontsManager](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#getFontsManager--). Zavolejte [IFontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) pro získání vložených písem a [IFontsManager.getFonts](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ifontsmanager/#getFonts--) pro získání písem použitých v prezentaci. Porovnejte oba výsledky, abyste našli písma, která jsou potřebná pro vykreslování, ale nejsou vložena.

**Jak rychle zjistit, zda soubor obsahuje skryté snímky a kolik jich je?**

Když jsou uložená metadata dokumentu dostatečná, přečtěte [IDocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/cs/java/com.aspose.slides/idocumentproperties/#getHiddenSlides--) pomocí [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) a [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--). Toto je vhodné pro lehký inventář. Pokud byla prezentace v paměti upravena, uložená metadata mohou chybět nebo být zastaralá, nebo pokud potřebujete ověřit aktuální hodnoty, projděte [Presentation.getSlides](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#getSlides--) a zkontrolujte metodu [ISlide.getHidden](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islide/#getHidden--) každého snímku.

**Mohu zjistit, zda jsou použity vlastní rozměry a orientace snímků, a zda se liší od výchozích?**

Ano. Načtěte prezentaci a zavolejte [Presentation.getSlideSize](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#getSlideSize--). Použijte [ISlideSize.getType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islidesize/#getType--), [ISlideSize.getSize](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islidesize/#getSize--), a [ISlideSize.getOrientation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islidesize/#getOrientation--) abyste porovnali aktuální nastavení s očekávaným přednastavením a rozměry.

**Existuje rychlý způsob, jak zjistit, zda grafy odkazují na externí datové zdroje?**

Ano. Najděte každý [Chart](https://reference.aspose.com/slides/cs/java/com.aspose.slides/chart/) a zavolejte [IChartData.getDataSourceType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdata/#getDataSourceType--). Pro externí sešit zavolejte [IChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdata/#getExternalWorkbookPath--). Typ datového zdroje a cesta identifikují externí odkaz, ale ověření, zda je cíl dostupný, vyžaduje samostatnou kontrolu zdroje.

**Jak mohu posoudit 'těžké' snímky, které mohou zpomalovat vykreslování nebo export do PDF?**

Neexistuje jedna vlastnost určující složitost. Procházejte [Presentation.getSlides](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#getSlides--) a kolekci [IBaseSlide.getShapes](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibaseslide/#getShapes--) každého snímku. Použijte počet tvarů a přítomnost velkých obrázků, efektů, animací nebo multimédií jako signály, a změřte reprezentativní vykreslení nebo export, než označíte snímek za potvrzený úzký hrdlo výkonu.