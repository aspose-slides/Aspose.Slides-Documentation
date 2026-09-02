---
title: Načíst a aktualizovat informace o prezentaci na Androidu
linktitle: Informace o prezentaci
type: docs
weight: 30
url: /cs/androidjava/examine-presentation/
keywords:
- formát prezentace
- vlastnosti prezentace
- vlastnosti dokumentu
- získat vlastnosti
- číst vlastnosti
- změnit vlastnosti
- upravit vlastnosti
- aktualizovat vlastnosti
- zkoumat PPTX
- zkoumat PPT
- zkoumat ODP
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Prozkoumejte snímky, strukturu a metadata v prezentacích PowerPoint a OpenDocument pomocí Javy pro rychlejší poznatky a inteligentnější audity obsahu."
---
## **Přehled**

Aspose.Slides může identifikovat formát prezentace a přečíst její metadata dokumentu, aniž by vytvářel kompletní objektový model prezentace. To je užitečné, když potřebujete klasifikovat soubory, vytvořit inventář nebo prověřit vlastnosti před tím, než se rozhodnete načíst a zpracovat obsah prezentace.

Tento článek demonstruje lehkou inspekci pomocí [PresentationFactory](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentationfactory/) a [IPresentationInfo](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentationinfo/), a také cílené aktualizace pomocí [IDocumentProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/idocumentproperties/).

## **Zkontrolovat formát prezentace**

Použijte [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) pro inspekci souboru bez vytvoření instance [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/). Metoda [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentationinfo/#getLoadFormat--) uvádí detekovaný formát, například PPTX, PPT nebo ODP.

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

## **Vytvořit lehký inventář prezentací**

Když zpracováváte mnoho souborů prezentací, můžete potřebovat kompaktní inventář pro validaci, indexaci nebo systém správy dokumentů. V tomto scénáři použijte [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) pro získání objektu [IPresentationInfo](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentationinfo/) a poté zavolejte [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) pro přečtení metadat dokumentu. Tento přístup nevytváří instanci [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) ani nevyžaduje procházení kompletním objektním modelem prezentace.

Rozšířené vlastnosti poskytované rozhraním [IDocumentProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/idocumentproperties/) poskytují následující hodnoty inventáře:

| Metoda | Inventární hodnota |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/idocumentproperties/#getSlides--) | Celkový počet snímků. |
| [getHiddenSlides](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/idocumentproperties/#getHiddenSlides--) | Počet skrytých snímků. |
| [getNotes](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/idocumentproperties/#getNotes--) | Počet snímků, které obsahují poznámky. |
| [getParagraphs](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/idocumentproperties/#getParagraphs--) | Celkový počet odstavců, pokud jsou dostupné. |
| [getWords](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/idocumentproperties/#getWords--) | Celkový počet slov. |
| [getMultimediaClips](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/idocumentproperties/#getMultimediaClips--) | Celkový počet audio a video klipů. |

Následující příklad načte tyto hodnoty bez vytvoření objektu [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) a vytiskne kompaktní inventář. Také kombinuje [getHeadingPairs](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/idocumentproperties/#getHeadingPairs--) s [getTitlesOfParts](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) pro zobrazení skupin obsahu, jako jsou písma, motivy a názvy snímků.

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

Každý [IHeadingPair](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iheadingpair/) poskytuje název skupiny a počet položek v této skupině. Metoda [IDocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) vrací ploché, uspořádané pole, takže je třeba spotřebovat počet po sobě jdoucích názvů určených každým párem záhlaví.

### **Uložená metadata a omezení formátu**

Vlastnosti inventáře vrácené metodou [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) odrážejí metadata dostupná ve zdrojovém dokumentu. Aspose.Slides nenačítá ani neprochází objektovým modelem prezentace pro přepočet těchto hodnot pro toto volání. Chybějící vlastnosti jsou reprezentovány výchozími hodnotami a uložené hodnoty mohou být zastaralé, pokud aplikace, která soubor naposledy uložila, neaktualizovala jeho vlastnosti dokumentu.

- **PPTX:** Formát poskytuje rozšířené vlastnosti dokumentu pro počty snímků, poznámek, skrytých snímků, odstavců, slov a multimédií, stejně jako páry záhlaví a názvy částí. Dostupnost závisí na tom, které vlastnosti byly zápisem vytvořitele dokumentu.
- **PPT:** Binární formát může ukládat odpovídající vlastnosti souhrnu dokumentu. Pokud je vlastnost nepřítomna nebo nebyla aktualizována tvůrcem dokumentu, Aspose.Slides vrátí její uloženou nebo výchozí hodnotu místo výpočtu z snímků.
- **ODP:** Metadata OpenDocument poskytují obecnou statistiku dokumentu, jako je počet stránek, odstavců a slov, ale tyto hodnoty neodpovídají každé rozšířené vlastnosti specifické pro PowerPoint. Metadata skrytých snímků, poznámek, multimédií, páry záhlaví a názvy částí mohou být nedostupné a inventární vlastnosti mohou vracet výchozí hodnoty. Nevnímejte nulovou hodnotu nebo prázdné pole jako autoritativní důkaz, že odpovídající obsah chybí.

Používejte lehký přístup k metadatům pro inventáře a předběžné kontroly. Načtěte prezentaci a prohlédněte si její živý objektový model, pokud výsledek musí odrážet změny v paměti nebo pokud potřebujete ověřit skutečný obsah prezentace.

## **Aktualizovat vlastnosti prezentace**

Vlastnosti vrácené metodou [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) lze také změnit bez vytvoření instance [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/). Aplikujte změny pomocí [IPresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentationinfo/#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) a poté zapište svázanou prezentaci pomocí [IPresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentationinfo/#writeBindedPresentation-java.io.OutputStream-).

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

Následující obrázek zobrazuje změněné vlastnosti dokumentu PowerPoint prezentace.

![Změněné vlastnosti dokumentu PowerPoint prezentace](output_properties.png)

## **Užitečné odkazy**

Pro související bezpečnostní kontroly a nastavení ochrany viz následující články:

- [Prezentace chráněné heslem](/slides/cs/androidjava/password-protected-presentation/)
- [Prezentace chráněné zápisem](/slides/cs/androidjava/write-protected-presentation/)

## **Často kladené otázky**

**Jak mohu zkontrolovat, zda jsou písma vložena a která jsou to?**

Načtěte prezentaci a použijte [Presentation.getFontsManager](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#getFontsManager--). Zavolejte [IFontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) pro získání vložených písem a [IFontsManager.getFonts](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ifontsmanager/#getFonts--) pro získání písem použité v prezentaci. Porovnejte oba výsledky a najděte písma, která jsou potřebná pro vykreslení, ale nejsou vložena.

**Jak mohu rychle zjistit, zda soubor obsahuje skryté snímky a kolik jich je?**

Když jsou uložená metadata dokumentu dostatečná, přečtěte [IDocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/idocumentproperties/#getHiddenSlides--) přes [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) a [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--). To je vhodné pro lehký inventář. Pokud byla prezentace upravena v paměti, uložená metadata mohou chybět nebo být zastaralá, nebo pokud potřebujete ověřit aktuální hodnoty, projděte [Presentation.getSlides](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#getSlides--) a u každého snímku zkontrolujte metodu [ISlide.getHidden](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islide/#getHidden--).

**Mohu zjistit, zda je použita vlastní velikost snímku a orientace, a zda se liší od výchozích hodnot?**

Ano. Načtěte prezentaci a zavolejte [Presentation.getSlideSize](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#getSlideSize--). Použijte [ISlideSize.getType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islidesize/#getType--), [ISlideSize.getSize](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islidesize/#getSize--) a [ISlideSize.getOrientation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islidesize/#getOrientation--) pro porovnání aktuálního nastavení s očekávaným přednastavením a rozměry.

**Existuje rychlý způsob, jak zjistit, zda grafy odkazují na externí zdroje dat?**

Ano. Najděte každý [Chart](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/chart/) a zavolejte [IChartData.getDataSourceType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdata/#getDataSourceType--). Pro externí sešit zavolejte [IChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--). Typ zdroje dat a cesta identifikují externí odkaz, ale ověření dostupnosti cíle vyžaduje samostatnou kontrolu zdroje.

**Jak mohu posoudit „těžké“ snímky, které mohou zpomalit vykreslování nebo export do PDF?**

Neexistuje jediná vlastnost komplexnosti. Projděte [Presentation.getSlides](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#getSlides--) a kolekci [IBaseSlide.getShapes](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ibaseslide/#getShapes--) každého snímku. Použijte počet tvarů a přítomnost velkých obrázků, efektů, animací nebo multimédií jako signály pro výběr a před provedením měření představte reprezentativní vykreslení nebo export, než snímek označíte za potvrzený úzký profil výkonu.