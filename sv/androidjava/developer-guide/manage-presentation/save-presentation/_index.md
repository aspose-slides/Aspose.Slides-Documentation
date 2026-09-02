---
title: Spara presentationer på Android
linktitle: Spara presentation
type: docs
weight: 80
url: /sv/androidjava/save-presentation/
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
- sparande framsteg
- Android
- Java
- Aspose.Slides
description: "Upptäck hur du sparar presentationer i Java med Aspose.Slides för Android—exportera till PowerPoint eller OpenDocument samtidigt som du behåller layouter, typsnitt och effekter."
---
## **Översikt**

[Öppna presentationer på Android](/slides/sv/androidjava/open-presentation/) beskriver hur du använder [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/)‑klassen för att öppna en presentation. Den här artikeln förklarar hur du skapar och sparar presentationer. [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/)‑klassen innehåller en presentations innehåll. Oavsett om du skapar en presentation från början eller ändrar en befintlig, vill du spara den när du är klar. Med Aspose.Slides för Android kan du spara till en **fil** eller **ström**. Den här artikeln förklarar de olika sätten att spara en presentation.

## **Spara presentationer till filer**

Spara en presentation till en fil genom att anropa [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/) klassens `save`‑metod. Skicka filnamnet och sparaformatet till metoden. Följande exempel visar hur du sparar en presentation med Aspose.Slides.

```java
import com.aspose.slides.*;

// Instansiera Presentation-klassen som representerar en presentationsfil.
Presentation presentation = new Presentation();
try {
    // Gör något arbete här...

    // Spara presentationen till en fil.
    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Spara presentationer till strömmar**

Du kan spara en presentation till en ström genom att skicka en utskriftsström till [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/) klassens `save`‑metod. En presentation kan skrivas till många strömmar. I exemplet nedan skapar vi en ny presentation och sparar den till en filström.

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

Aspose.Slides låter dig ange den initiala vy som PowerPoint använder när den genererade presentationen öppnas via [ViewProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/viewproperties/)‑klassen. Använd [setLastView](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/viewproperties/#setLastView-int-)‑metoden med ett värde från [ViewType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/viewtype/)‑enumerationen.

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

## **Spara presentationer i det strikta Office Open XML‑formatet**

Aspose.Slides låter dig spara en presentation i det strikta Office Open XML‑formatet. Använd [PptxOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/pptxoptions/)‑klassen och ange dess conformance‑egenskap vid sparning. Om du anger [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/conformance/#Iso29500-2008-Strict) sparas utdatafilen i det strikta Office Open XML‑formatet.

```java
import com.aspose.slides.*;

PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

// Instansiera Presentation-klassen som representerar en presentationsfil.
Presentation presentation = new Presentation();
try {
    // Spara presentationen i det strikta Office Open XML-formatet.
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Spara presentationer i Office Open XML‑format i Zip64‑läge**

En Office Open XML‑fil är ett ZIP‑arkiv som begränsar 4 GB (2^32 byte) för den okomprimerade storleken på någon fil, den komprimerade storleken på någon fil och den totala storleken på arkivet, och den begränsar också arkivet till 65 535 (2^16‑1) filer. ZIP64‑formatets tillägg höjer dessa gränser till 2^64.

[IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipptxoptions/#setZip64Mode-int-)‑metoden låter dig välja när ZIP64‑formatets tillägg ska användas vid sparning av en Office Open XML‑fil.

Denna metod kan användas med följande lägen:

- [IfNecessary](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/zip64mode/#IfNecessary) använder ZIP64‑formatets tillägg endast om presentationen överskrider begränsningarna ovan. Detta är standardläget.
- [Never](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/zip64mode/#Never) använder aldrig ZIP64‑formatets tillägg.
- [Always](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/zip64mode/#Always) använder alltid ZIP64‑formatets tillägg.

Följande kod demonstrerar hur du sparar en presentation som en PPTX‑fil med ZIP64‑formatets tillägg aktiverade:

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
När du sparar med [Zip64Mode.Never](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/zip64mode/#Never) kastas ett [PptxException](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/pptxexception/) om presentationen inte kan sparas i ZIP32‑format.
{{% /alert %}}

## **Spara presentationer i Office Open XML‑format med komprimeringsnivåer**

När du arbetar med stora presentationer kan du justera komprimeringsnivån för att balansera filstorlek och bearbetningstid. Beroende på dina krav kan du föredra snabbare bearbetning eller mindre utdatafiler.

Aspose.Slides tillhandahåller metoden [IPptxOptions.setCompressionLevel](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipptxoptions/#setCompressionLevel-int-) som låter dig ange vilken komprimeringsnivå som ska användas när en presentation sparas i Office Open XML‑format.

Följande komprimeringsnivåer finns tillgängliga:

- [**None**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/compressionlevel/#None): Ingen komprimering tillämpas. Filer sparas som de är.
- [**Level1**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/compressionlevel/#Level1): Den snabbaste komprimeringen med den lägsta komprimeringsgraden.
- [**Level2**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/compressionlevel/#Level2): Snabbare komprimering med en något bättre komprimeringsgrad än **Level1**.
- [**Level3**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/compressionlevel/#Level3): Ger bättre komprimering än **Level2** med måttlig påverkan på bearbetningstiden.
- [**Level4**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/compressionlevel/#Level4): Ger bättre komprimering än **Level3**.
- [**Level5**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/compressionlevel/#Level5): Ger förbättrad komprimering jämfört med **Level4** med extra bearbetningstid.
- [**Level6**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/compressionlevel/#Level6): Standardkomprimering som erbjuder en bra balans mellan hastighet och filstorlek. Detta är *standardkomprimeringsnivån*.
- [**Level7**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/compressionlevel/#Level7): Ger bättre kompression än **Level6** med långsammare bearbetning.
- [**Level8**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/compressionlevel/#Level8): Ger bättre kompression än **Level7**.
- [**Level9**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/compressionlevel/#Level9): Maximal kompression. Ger den minsta filstorleken men med längst bearbetningstid.

Följande exempel visar hur du sparar en presentation som en PPTX‑fil *utan kompression*:

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

Detta exempel visar hur du sparar en presentation som en PPTX‑fil med *maximal kompression*:

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

[PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-)‑metoden styr miniatyrbildsgenerering när en presentation sparas till PPTX:

- Om den sätts till `true` uppdateras miniatyrbilden under sparning. Detta är standard.
- Om den sätts till `false` bevaras den befintliga miniatyrbilden. Om presentationen saknar miniatyrbild genereras ingen.

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

## **Spara förloppsuppdateringar i procent**

[IProgressCallback](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iprogresscallback/)‑gränssnittet används via `setProgressCallback`‑metoden som exponeras av [ISaveOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isaveoptions/)‑gränssnittet och den abstrakta [SaveOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/saveoptions/)‑klassen. Tilldela en [IProgressCallback](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iprogresscallback/)‑implementation med `setProgressCallback` för att få sparförloppsuppdateringar i procent.

Följande kodsnuttar visar hur du använder `IProgressCallback`.

```java
import com.aspose.slides.*;

ISaveOptions saveOptions = new PdfOptions();
saveOptions.setProgressCallback(new ExportProgressHandler());

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", SaveFormat.Pdf, saveOptions);
} finally {
    presentation.dispose();
}
```
```java
import com.aspose.slides.*;

class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        // Använd procentvärdet för framsteg här.
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Aspose har utvecklat en [gratis PowerPoint Splitter‑app](https://products.aspose.app/slides/sv/splitter) med sitt eget API. Appen låter dig dela en presentation i flera filer genom att spara valda bildspel som nya PPTX‑ eller PPT‑filer.
{{% /alert %}}

## **FAQ**

**Stöds “snabb sparning” (inkrementell sparning) så att bara förändringar skrivs?**

Nej. Vid sparning skapas hela målfilen varje gång; inkrementell “snabb sparning” stöds inte.

**Är det trådsäkert att spara samma Presentation‑instans från flera trådar?**

Nej. En [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/)‑instans är [inte trådsäker](/slides/sv/androidjava/multithreading/); spara den från en enda tråd.

**Vad händer med hyperlänkar och externt länkade filer vid sparning?**

[Hyperlinks](/slides/sv/androidjava/manage-hyperlinks/) bevaras. Externt länkade filer (t.ex. videor via relativa sökvägar) kopieras inte automatiskt – se till att de refererade sökvägarna förblir tillgängliga.

**Kan jag sätta/ spara dokumentmetadata (författare, titel, företag, datum)?**

Ja. Standard [dokumentegenskaper](/slides/sv/androidjava/presentation-properties/) stöds och kommer att skrivas till filen vid sparning.