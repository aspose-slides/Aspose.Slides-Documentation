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
- Strikt Office Open XML-format
- Zip64-läge
- uppdatera miniatyr
- sparningsframsteg
- Java
- Aspose.Slides
description: "Upptäck hur du sparar presentationer i Java med Aspose.Slides—exportera till PowerPoint eller OpenDocument samtidigt som du behåller layouter, typsnitt och effekter."
---
## **Översikt**

[Öppna presentationer i Java](/slides/sv/java/open-presentation/) beskriver hur du använder [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/)‑klassen för att öppna en presentation. Denna artikel förklarar hur du skapar och sparar presentationer. Presentation‑klassen innehåller en presentations innehåll. Oavsett om du skapar en presentation från början eller modifierar en befintlig, vill du spara den när du är klar. Med Aspose.Slides för Java kan du spara till en **fil** eller **ström**. Denna artikel förklarar de olika sätten att spara en presentation.

## **Spara presentationer till filer**

Spara en presentation till en fil genom att anropa Presentation‑klassens `save`‑metod. Skicka filnamnet och sparformatet till metoden. Följande exempel visar hur man sparar en presentation med Aspose.Slides.

```java
// Skapa en Presentation-klass som representerar en presentationsfil.
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

Du kan spara en presentation till en ström genom att skicka en output‑ström till Presentation‑klassens `save`‑metod. En presentation kan skrivas till många olika strömmar. I exemplet nedan skapar vi en ny presentation och sparar den till en filström.

```java
// Skapa en Presentation-klass som representerar en presentationsfil.
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

Aspose.Slides låter dig ställa in den initiala vyn som PowerPoint använder när den genererade presentationen öppnas via [ViewProperties](https://reference.aspose.com/slides/sv/java/com.aspose.slides/viewproperties/)-klassen. Använd `setLastView`‑metoden med ett värde från [ViewType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/viewtype/)-enumerationen.

```java
Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Spara presentationer i det strikta Office Open XML‑formatet**

Aspose.Slides låter dig spara en presentation i det strikta Office Open XML‑formatet. Använd [PptxOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/pptxoptions/)-klassen och ange dess `conformance`‑egenskap när du sparar. Om du sätter [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/sv/java/com.aspose.slides/conformance/#Iso29500-2008-Strict) sparas utdatafilen i det strikta Office Open XML‑formatet.

Exemplet nedan skapar en presentation och sparar den i det strikta Office Open XML‑formatet.

```java
// Skapa Presentation-klassen som representerar en presentationsfil.
Presentation presentation = new Presentation();
try {
    // Spara presentationen i det Strikta Office Open XML-formatet.
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Spara presentationer i Office Open XML‑format i Zip64‑läge**

En Office Open XML‑fil är ett ZIP‑arkiv som har en gräns på 4 GB (2^32 byte) för den okomprimerade storleken på någon fil, den komprimerade storleken på någon fil samt den totala storleken på arkivet, och den begränsar också arkivet till 65 535 (2^16−1) filer. ZIP64‑formatutökningar höjer dessa gränser till 2^64.

[IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipptxoptions/#setZip64Mode-int-)‑metoden låter dig välja när du vill använda ZIP64‑formatutökningar vid sparning av en Office Open XML‑fil.

Denna metod kan användas med följande lägen:

- [IfNecessary](https://reference.aspose.com/slides/sv/java/com.aspose.slides/zip64mode/#IfNecessary) använder ZIP64‑formatutökningar endast om presentationen överskrider begränsningarna ovan. Detta är standardläget.
- [Never](https://reference.aspose.com/slides/sv/java/com.aspose.slides/zip64mode/#Never) använder aldrig ZIP64‑formatutökningar.
- [Always](https://reference.aspose.com/slides/sv/java/com.aspose.slides/zip64mode/#Always) använder alltid ZIP64‑formatutökningar.

Följande kod visar hur du sparar en presentation som PPTX med ZIP64‑formatutökningar aktiverade:

```java
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
När du sparar med [Zip64Mode.Never](https://reference.aspose.com/slides/sv/java/com.aspose.slides/zip64mode/#Never) kastas ett [PptxException](https://reference.aspose.com/slides/sv/java/com.aspose.slides/pptxexception/) om presentationen inte kan sparas i ZIP32‑format.
{{% /alert %}}

## **Spara presentationer utan att uppdatera miniatyren**

[PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/sv/java/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-)‑metoden styr miniatyrgenerering när en presentation sparas till PPTX:

- Om den är satt till `true` uppdateras miniatyren under sparning. Detta är standard.
- Om den är satt till `false` bevaras den befintliga miniatyren. Om presentationen saknar miniatyr genereras ingen.

I koden nedan sparas presentationen till PPTX utan att dess miniatyr uppdateras.

```java
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

[IProgressCallback](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iprogresscallback/)-gränssnittet används via `setProgressCallback`‑metoden som exponeras av [ISaveOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isaveoptions/)-gränssnittet och den abstrakta [SaveOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/saveoptions/)-klassen. Tilldela en [IProgressCallback](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iprogresscallback/)-implementation med `setProgressCallback` för att få sparnings‑framsteg som procentandel.

Följande kodsnuttar visar hur du använder `IProgressCallback`.

```java
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
class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        // Använd procentvärdet för framsteg här.
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Aspose har utvecklat en [gratis PowerPoint Splitter‑app](https://products.aspose.app/slides/sv/splitter) som använder sitt eget API. Appen låter dig dela en presentation i flera filer genom att spara valda bilder som nya PPTX‑ eller PPT‑filer.
{{% /alert %}}

## **FAQ**

**Stöds "snabbspara" (inkrementell sparning) så att bara ändringar skrivs?**

Nej. Sparning skapar hela målfilen varje gång; inkrementell "snabbspara" stöds inte.

**Är det trådsäkert att spara samma Presentation‑instans från flera trådar?**

Nej. En [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/)‑instans är inte trådsäker; spara den från en enda tråd.

**Vad händer med hyperlänkar och externt länkade filer vid sparning?**

[Hyperlänkar](/slides/sv/java/manage-hyperlinks/) bevaras. Externt länkade filer (t.ex. videor via relativa sökvägar) kopieras inte automatiskt – se till att de refererade sökvägarna förblir åtkomliga.

**Kan jag ange/spara dokumentmetadata (Författare, Titel, Företag, Datum)?**

Ja. Standard [dokumentegenskaper](/slides/sv/java/presentation-properties/) stöds och kommer att skrivas till filen vid sparning.