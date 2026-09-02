---
title: Spara presentationer i Java
linktitle: Spara presentation
type: docs
weight: 80
url: /sv/java/save-presentation/
keywords:
- spara PowerPoint
- spara OpenDocument
- spara presentation
- spara bild
- spara PPT
- spara PPTX
- spara ODP
- presentation till fil
- presentation till ström
- fördefinierad vytyp
- Strict Office Open XML-format
- Zip64-läge
- uppdatera miniatyrbild
- sparningsframsteg
- Java
- Aspose.Slides
description: "Upptäck hur du sparar presentationer i Java med Aspose.Slides — exportera till PowerPoint eller OpenDocument samtidigt som du behåller layouter, teckensnitt och effekter."
---
## **Översikt**

[Öppna presentationer i Java](/slides/sv/java/open-presentation/) beskriver hur man använder [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/)‑klassen för att öppna en presentation. Den här artikeln förklarar hur man skapar och sparar presentationer. [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/)‑klassen innehåller en presentations innehåll. Oavsett om du skapar en presentation från grunden eller modifierar en befintlig vill du spara den när du är klar. Med Aspose.Slides för Java kan du spara till en **fil** eller **ström**. Den här artikeln förklarar de olika sätten att spara en presentation.

## **Spara presentationer till filer**

Spara en presentation till en fil genom att anropa [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/)‑klassens `save`‑metod. Ange filnamnet och sparformatet till metoden. Följande exempel visar hur man sparar en presentation med Aspose.Slides.

```java
import com.aspose.slides.*;

// Instansiera Presentation-klassen som representerar en presentationsfil.
Presentation presentation = new Presentation();
try {
    // Utför något arbete här...

    // Spara presentationen till en fil.
    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Spara presentationer till strömmar**

Du kan spara en presentation till en ström genom att skicka en utdata‑ström till [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/)‑klassens `save`‑metod. En presentation kan skrivas till många strömtyper. I exemplet nedan skapar vi en ny presentation och sparar den till en filström.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.OutputStream;

// Instansiera Presentation-klassen som representerar en presentationsfil.
Presentation presentation = new Presentation();
try {
    OutputStream fileStream = new FileOutputStream("Output.pptx");
    try {
        // Spara presentationen till strömmen.
        presentation.save(fileStream, SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Spara presentationer med en fördefinierad vytyp**

Aspose.Slides låter dig ange den initiala vyn som PowerPoint använder när den genererade presentationen öppnas via [ViewProperties](https://reference.aspose.com/slides/sv/java/com.aspose.slides/viewproperties/)‑klassen. Använd [setLastView](https://reference.aspose.com/slides/sv/java/com.aspose.slides/viewproperties/#setLastView-int-)‑metoden med ett värde från [ViewType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/viewtype/)‑enumerationen.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Spara presentationer i Strict Office Open XML-format**

Aspose.Slides låter dig spara en presentation i Strict Office Open XML-formatet. Använd [PptxOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/pptxoptions/)‑klassen och ställ in dess conformance‑egenskap när du sparar. Om du sätter [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/sv/java/com.aspose.slides/conformance/#Iso29500-2008-Strict) sparas utdatafilen i Strict Office Open XML-formatet.

```java
import com.aspose.slides.*;

PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

// Instansiera Presentation-klassen som representerar en presentationsfil.
Presentation presentation = new Presentation();
try {
    // Spara presentationen i Strict Office Open XML-formatet.
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Spara presentationer i Office Open XML-format i Zip64‑läge**

En Office Open XML‑fil är ett ZIP‑arkiv som har en gräns på 4 GB (2^32 byte) för den okomprimerade storleken på någon fil, den komprimerade storleken på någon fil samt den totala storleken på arkivet, och den begränsar även arkivet till 65 535 (2^16‑1) filer. ZIP64‑formatförlängningar höjer dessa begränsningar till 2^64.

[IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipptxoptions/#setZip64Mode-int-)‑metoden låter dig välja när ZIP64‑formatförlängningar ska användas vid sparande av en Office Open XML‑fil.

Denna metod kan användas med följande lägen:

- [IfNecessary](https://reference.aspose.com/slides/sv/java/com.aspose.slides/zip64mode/#IfNecessary) använder ZIP64‑formatförlängningar endast om presentationen överskrider begränsningarna ovan. Detta är standardläget.
- [Never](https://reference.aspose.com/slides/sv/java/com.aspose.slides/zip64mode/#Never) använder aldrig ZIP64‑formatförlängningar.
- [Always](https://reference.aspose.com/slides/sv/java/com.aspose.slides/zip64mode/#Always) använder alltid ZIP64‑formatförlängningar.

Följande kod demonstrerar hur man sparar en presentation som en PPTX‑fil med ZIP64‑formatförlängningar aktiverade:

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setZip64Mode(Zip64Mode.Always);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}}
När du sparar med Zip64Mode.Never kastas ett PptxException om presentationen inte kan sparas i ZIP32‑format.
{{% /alert %}}

## **Spara presentationer i Office Open XML-format med komprimeringsnivåer**

När du arbetar med stora presentationer kan du justera komprimeringsnivån för att balansera filstorlek och bearbetningstid. Beroende på dina krav kan du föredra snabbare bearbetning eller mindre utdatafiler.

Aspose.Slides tillhandahåller [IPptxOptions.setCompressionLevel](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipptxoptions/#setCompressionLevel-int-)‑metoden, som låter dig ange komprimeringsnivån som används när en presentation sparas i Office Open XML‑format.

Följande komprimeringsnivåer är tillgängliga:

- [**None**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/compressionlevel/#None): Ingen komprimering tillämpas. Filer lagras som de är.
- [**Level1**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/compressionlevel/#Level1): Den snabbaste komprimeringen med lägst komprimeringsförhållande.
- [**Level2**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/compressionlevel/#Level2): Snabbare komprimering med något bättre komprimeringsförhållande än **Level1**.
- [**Level3**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/compressionlevel/#Level3): Ger bättre komprimering än **Level2** med måttlig påverkan på bearbetningstiden.
- [**Level4**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/compressionlevel/#Level4): Ger bättre komprimering än **Level3**.
- [**Level5**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/compressionlevel/#Level5): Ger förbättrad komprimering jämfört med **Level4** med extra bearbetningstid.
- [**Level6**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/compressionlevel/#Level6): Standardkomprimering som ger en bra balans mellan bearbetningshastighet och filstorlek. Detta är *standardkomprimeringsnivån*.
- [**Level7**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/compressionlevel/#Level7): Ger bättre komprimering än **Level6** med långsammare bearbetning.
- [**Level8**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/compressionlevel/#Level8): Ger bättre komprimering än **Level7**.
- [**Level9**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/compressionlevel/#Level9): Maximal komprimering. Ger den minsta filstorleken men kräver längst bearbetningstid.

Följande exempel demonstrerar hur man sparar en presentation som en PPTX‑fil *utan komprimering*:

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setCompressionLevel(CompressionLevel.None);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Sample-out.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

Detta exempel visar hur man sparar en presentation som en PPTX‑fil med *maximal kompression*:

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setCompressionLevel(CompressionLevel.Level9);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Sample-level9.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

## **Spara presentationer utan att uppdatera miniatyrbilden**

PptxOptions.setRefreshThumbnail‑metoden styr miniatyrbildsgenerering vid sparande av en presentation till PPTX:

- Om den sätts till `true` uppdateras miniatyrbilden under sparandet. Detta är standard.
- Om den sätts till `false` bevaras den aktuella miniatyrbilden. Om presentationen saknar miniatyrbild genereras ingen.

I koden nedan sparas presentationen till PPTX utan att uppdatera dess miniatyrbild.

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setRefreshThumbnail(false);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pptx", SaveFormat.Pptx, pptxOptions);
}
finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
Detta alternativ hjälper till att minska den tid som krävs för att spara en presentation i PPTX‑format.
{{% /alert %}}

## **Spara framstegsupdateringar i procent**

[IProgressCallback](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iprogresscallback/)‑gränssnittet används via `setProgressCallback`‑metoden som exponeras av [ISaveOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isaveoptions/)‑gränssnittet och den abstrakta [SaveOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/saveoptions/)‑klassen. Tilldela en IProgressCallback‑implementation med `setProgressCallback` för att få spar‑framstegsupdateringar i procent.

Följande kodsnutt visar hur man använder IProgressCallback.

```java
import com.aspose.slides.*;

class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        // Använd procentvärdet för framsteg här.
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}

ISaveOptions saveOptions = new PdfOptions();
saveOptions.setProgressCallback(new ExportProgressHandler());

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", SaveFormat.Pdf, saveOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
Aspose har utvecklat en gratis PowerPoint‑splitter‑app som använder deras egna API. Appen låter dig dela en presentation i flera filer genom att spara valda bilder som nya PPTX‑ eller PPT‑filer.
{{% /alert %}}

## **Vanliga frågor**

**Stöds ”snabb sparning” (inkrementell sparning) så att endast ändringar skrivs?**

Nej. Sparning skapar hela målfilen varje gång; inkrementell ”snabb sparning” stöds inte.

**Är det trådsäkert att spara samma Presentation‑instans från flera trådar?**

Nej. En Presentation‑instans är inte trådsäker; spara den från en enda tråd.

**Vad händer med hyperlänkar och externt länkade filer vid sparande?**

[Hyperlänkar](/slides/sv/java/manage-hyperlinks/) bevaras. Externt länkade filer (t.ex. videor via relativa sökvägar) kopieras inte automatiskt — se till att de refererade sökvägarna förblir tillgängliga.

**Kan jag ange/spara dokumentmetadata (Author, Title, Company, Date)?**

Ja. Standard dokumentegenskaper stöds och kommer att skrivas till filen vid sparning.