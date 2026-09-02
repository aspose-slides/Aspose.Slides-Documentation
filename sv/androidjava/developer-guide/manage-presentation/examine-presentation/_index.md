---
title: Hämta och uppdatera presentationsinformation på Android
linktitle: Presentationsinformation
type: docs
weight: 30
url: /sv/androidjava/examine-presentation/
keywords:
- presentationsformat
- presentationsegenskaper
- dokumentegenskaper
- hämta egenskaper
- läsa egenskaper
- ändra egenskaper
- modifiera egenskaper
- uppdatera egenskaper
- granska PPTX
- granska PPT
- granska ODP
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Utforska bilder, struktur och metadata i PowerPoint- och OpenDocument-presentationer med Java för snabbare insikter och smartare innehållsgranskning."
---
## **Översikt**

Aspose.Slides kan identifiera ett presentationsformat och läsa dokumentmetadata utan att skapa en komplett presentationsobjektmodell. Detta är användbart när du behöver klassificera filer, bygga ett inventarium eller inspektera egenskaper innan du bestämmer dig för om du ska ladda och bearbeta presentationsinnehållet.

Denna artikel demonstrerar lättviktig inspektion via [PresentationFactory](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentationfactory/) och [IPresentationInfo](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipresentationinfo/), samt riktade uppdateringar via [IDocumentProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/idocumentproperties/).

## **Kontrollera ett presentationsformat**

Använd [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) för att inspektera en fil utan att skapa en [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/)-instans. Metoden [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipresentationinfo/#getLoadFormat--) rapporterar det upptäckta formatet, t.ex. PPTX, PPT eller ODP.

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

## **Skapa ett lättviktigt presentationsinventarium**

När du bearbetar många presentationsfiler kan du behöva ett kompakt inventarium för validering, indexering eller ett dokumenthanteringssystem. I detta scenario, använd [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) för att erhålla ett [IPresentationInfo](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipresentationinfo/)-objekt, och anropa sedan [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) för att läsa dokumentmetadata. Detta tillvägagångssätt skapar ingen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/)-instans och kräver inte att du traverserar hela presentationsobjektmodellen.

De förlängda egenskaperna som exponeras av [IDocumentProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/idocumentproperties/) tillhandahåller följande inventarievärden:

| Metod | Inventarievärde |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/idocumentproperties/#getSlides--) | Totalt antal bilder. |
| [getHiddenSlides](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/idocumentproperties/#getHiddenSlides--) | Antal dolda bilder. |
| [getNotes](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/idocumentproperties/#getNotes--) | Antal bilder som innehåller anteckningar. |
| [getParagraphs](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/idocumentproperties/#getParagraphs--) | Totalt antal stycken, när tillgängligt. |
| [getWords](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/idocumentproperties/#getWords--) | Totalt antal ord. |
| [getMultimediaClips](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/idocumentproperties/#getMultimediaClips--) | Totalt antal ljud- och videoklipp. |

Följande exempel läser dessa värden utan att skapa ett [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/)-objekt och skriver ut ett kompakt inventarium. Det kombinerar också [getHeadingPairs](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/idocumentproperties/#getHeadingPairs--) med [getTitlesOfParts](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) för att visa innehållsgrupper såsom teckensnitt, teman och bildrubriker.

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

Varje [IHeadingPair](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iheadingpair/) levererar ett gruppnamn och antalet objekt i den gruppen. [IDocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) returnerar en platt, ordnad array, så konsumera antalet på varandra följande titlar som specificeras av varje rubrikpar.

### **Lagrade metadata och formatbegränsningar**

De inventarieegenskaper som returneras av [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) speglar metadata som finns i källdokumentet. Aspose.Slides laddar inte och traverserar inte presentationsobjektmodellen för att omräkna dessa värden för detta anrop. Saknade egenskaper representeras av standardvärden, och lagrade värden kan vara föråldrade om programmet som senast sparade filen inte uppdaterade dess dokumentegenskaper.

- **PPTX:** Formatet tillhandahåller förlängda dokumentegenskaper för bild, anteckning, dold bild, stycke, ord och multimediaklipp, samt rubrikpar och deltitlar. Tillgängligheten beror på vilka egenskaper som skrevs av dokumentproducenten.
- **PPT:** Det binära formatet kan lagra motsvarande dokument‑sammanfattningsegenskaper. Om en egenskap saknas eller inte uppdaterades av dokumentproducenten returnerar Aspose.Slides dess lagrade eller standardvärde snarare än att beräkna det från bilderna.
- **ODP:** OpenDocument‑metadata ger allmänna dokumentstatistik, såsom sid-, stycke‑ och ordantal, men dessa värden motsvarar inte varje PowerPoint‑specifik förlängd egenskap. Metadata för dold bild, anteckningsbild, multimedia, rubrikpar och deltitel kan vara otillgänglig, och inventarieegenskaperna kan returnera standardvärden. Behandla inte ett nollvärde eller en tom array som bevis på att motsvarande innehåll saknas.

Använd den lättviktiga metadata‑metoden för inventarier och preliminära kontroller. Ladda presentationen och inspektera dess levande objektmodell när resultatet måste spegla förändringar i minnet eller när du behöver verifiera det faktiska presentationsinnehållet.

## **Uppdatera presentationsegenskaper**

De egenskaper som returneras av [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) kan också ändras utan att skapa en [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/)-instans. Applicera ändringarna med [IPresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipresentationinfo/#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), och skriv sedan den bundna presentationen med [IPresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipresentationinfo/#writeBindedPresentation-java.io.OutputStream-).

Följande bild visar de ursprungliga dokumentegenskaperna för PowerPoint‑presentationen.

![Original dokumentegenskaper för PowerPoint-presentationen](input_properties.png)

Följande exempel ändrar titel och tid för senaste sparning och skriver resultatet till en ny fil:

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

Följande bild visar de ändrade dokumentegenskaperna för PowerPoint‑presentationen.

![Ändrade dokumentegenskaper för PowerPoint-presentationen](output_properties.png)

## **Användbara länkar**

För relaterade säkerhetskontroller och skyddsinställningar, se följande artiklar:

- [Lösenordsskydda presentationer](/slides/sv/androidjava/password-protected-presentation/)
- [Skrivskydda presentationer](/slides/sv/androidjava/write-protected-presentation/)

## **Vanliga frågor**

**Hur kan jag kontrollera om teckensnitt är inbäddade och vilka de är?**

Ladda presentationen och använd [Presentation.getFontsManager](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/#getFontsManager--). Anropa [IFontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) för att erhålla de inbäddade teckensnitten och [IFontsManager.getFonts](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ifontsmanager/#getFonts--) för att erhålla de teckensnitt som används av presentationen. Jämför de två resultaten för att hitta teckensnitt som behövs för rendering men som inte är inbäddade.

**Hur kan jag snabbt avgöra om filen har dolda bilder och hur många?**

När lagrad dokumentmetadata är tillräcklig, läs [IDocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/idocumentproperties/#getHiddenSlides--) via [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) och [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--). Detta är lämpligt för ett lättviktigt inventarium. Om presentationen har modifierats i minnet kan den lagrade metadata vara saknad eller föråldrad, eller så måste du verifiera levande värden genom att iterera över [Presentation.getSlides](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/#getSlides--) och inspektera varje bilds [ISlide.getHidden](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/islide/#getHidden--)‑metod istället.

**Kan jag upptäcka om en anpassad bildstorlek och orientering används, och om de skiljer sig från standardinställningarna?**

Ja. Ladda presentationen och anropa [Presentation.getSlideSize](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/#getSlideSize--). Använd [ISlideSize.getType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/islidesize/#getType--), [ISlideSize.getSize](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/islidesize/#getSize--) och [ISlideSize.getOrientation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/islidesize/#getOrientation--) för att jämföra de aktuella inställningarna med de förväntade förinställningarna och dimensionerna.

**Finns det ett snabbt sätt att se om diagram refererar till externa datakällor?**

Ja. Lokalisera varje [Chart](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/chart/) och anropa [IChartData.getDataSourceType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ichartdata/#getDataSourceType--). För en extern arbetsbok, anropa [IChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--). Datakälltypen och sökvägen identifierar en extern referens, men att verifiera om målet är tillgängligt kräver en separat resurstillgångskontroll.

**Hur kan jag bedöma 'tunga' bilder som kan sakta ner rendering eller PDF‑export?**

Det finns ingen enskild komplexitetsegenskap. Traversera [Presentation.getSlides](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/#getSlides--) och varje bilds [IBaseSlide.getShapes](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ibaseslide/#getShapes--)‑samling. Använd antalet former samt förekomsten av stora bilder, effekter, animationer eller multimedia som screening‑signaler, och mät en representativ rendering eller export innan du betraktar en bild som en bekräftad prestandaflaskhals.