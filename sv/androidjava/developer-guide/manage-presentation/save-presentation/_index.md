---
title: "Spara presentationer på Android"
linktitle: "Spara presentation"
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
- uppdatera miniatyr
- spara framsteg
- Android
- Java
- Aspose.Slides
description: "Upptäck hur du sparar presentationer i Java med Aspose.Slides för Android—exportera till PowerPoint eller OpenDocument samtidigt som du behåller layouter, typsnitt och effekter."
---
## **Översikt**

[Open Presentations on Android](/slides/sv/androidjava/open-presentation/) beskriver hur man använder klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/) för att öppna en presentation. Den här artikeln förklarar hur man skapar och sparar presentationer. Klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/) innehåller en presentations innehåll. Oavsett om du skapar en presentation från början eller modifierar en befintlig, vill du spara den när du är klar. Med Aspose.Slides för Android kan du spara till en **fil** eller **ström**. Den här artikeln förklarar de olika sätten att spara en presentation.

## **Spara presentationer till filer**

Spara en presentation till en fil genom att anropa klassens [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/) `save`‑metod. Ange filnamnet och sparaformatet till metoden. Följande exempel visar hur man sparar en presentation med Aspose.Slides.

```java
// Instansiera Presentation-klassen som representerar en presentationsfil.
Presentation presentation = new Presentation();
try {
    // Utför lite arbete här...

    // Spara presentationen till en fil.
    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Spara presentationer till strömmar**

Du kan spara en presentation till en ström genom att skicka en output‑ström till klassens [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/) `save`‑metod. En presentation kan skrivas till många olika strömtyper. I exemplet nedan skapar vi en ny presentation och sparar den till en filström.

```java
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

Aspose.Slides låter dig ange den initiala vyn som PowerPoint använder när den genererade presentationen öppnas via klassen [ViewProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/viewproperties/). Använd metoden [setLastView](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/viewproperties/#setLastView-int-) med ett värde från enumen [ViewType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/viewtype/).

```java
Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Spara presentationer i Strict Office Open XML-format**

Aspose.Slides låter dig spara en presentation i Strict Office Open XML-format. Använd klassen [PptxOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/pptxoptions/) och ange dess conformance‑egenskap vid sparande. Om du anger [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/conformance/#Iso29500-2008-Strict) sparas utdatafilen i Strict Office Open XML-format.

Exemplet nedan skapar en presentation och sparar den i Strict Office Open XML-format.

```java
PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

// Instansiera Presentation-klassen som representerar en presentationsfil.
Presentation presentation = new Presentation();
try {
    // Spara presentationen i Strict Office Open XML-format.
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Spara presentationer i Office Open XML-format i Zip64‑läge**

En Office Open XML‑fil är ett ZIP‑arkiv som begränsar den okomprimerade storleken för varje fil till 4 GB (2^32 byte), den komprimerade storleken för varje fil samt den totala storleken på arkivet, och den begränsar även antalet filer i arkivet till 65 535 (2^16‑1) filer. ZIP64‑formatutökningar höjer dessa begränsningar till 2^64.

Metoden [IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipptxoptions/#setZip64Mode-int-) låter dig välja när ZIP64‑formatutökningar ska användas vid sparande av en Office Open XML‑fil.

Denna metod kan användas med följande lägen:

- [IfNecessary](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/zip64mode/#IfNecessary) använder ZIP64‑formatutökningar endast om presentationen överskrider ovanstående begränsningar. Detta är standardläget.
- [Never](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/zip64mode/#Never) använder aldrig ZIP64‑formatutökningar.
- [Always](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/zip64mode/#Always) använder alltid ZIP64‑formatutökningar.

Följande kod demonstrerar hur man sparar en presentation som PPTX med ZIP64‑formatutökningar aktiverade:

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
När du sparar med [Zip64Mode.Never](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/zip64mode/#Never), kastas ett [PptxException](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/pptxexception/) om presentationen inte kan sparas i ZIP32‑format.
{{% /alert %}}

## **Spara presentationer utan att uppdatera miniatyren**

Metoden [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) styr generering av miniatyrbild när en presentation sparas till PPTX:

- Om den sätts till `true` uppdateras miniatyren vid sparning. Detta är standard.
- Om den sätts till `false` bevaras den befintliga miniatyren. Om presentationen saknar miniatyr genereras ingen.

I koden nedan sparas presentationen till PPTX utan att uppdatera dess miniatyr.

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

## **Spara framstegsuppdateringar i procent**

Gränssnittet [IProgressCallback](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iprogresscallback/) används via metoden `setProgressCallback` som exponeras av gränssnittet [ISaveOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isaveoptions/) och den abstrakta klassen [SaveOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/saveoptions/). Tilldela en [IProgressCallback](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iprogresscallback/)-implementation med `setProgressCallback` för att få spar‑framstegsuppdateringar i procent.

Följande kodsnuttar visar hur man använder `IProgressCallback`.

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
Aspose har utvecklat en [gratis PowerPoint‑delningsapp](https://products.aspose.app/slides/sv/splitter) med sitt eget API. Appen låter dig dela en presentation i flera filer genom att spara valda bilder som nya PPTX‑ eller PPT‑filer.
{{% /alert %}}

## **FAQ**

**Stöds "snabb sparning" (inkrementell sparning) så att bara ändringar skrivs?**

Nej. Sparning skapar hela målfilen varje gång; inkrementell "snabb sparning" stöds inte.

**Är det trådsäkert att spara samma Presentation‑instans från flera trådar?**

Nej. En [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/)‑instans [är inte trådsäker](/slides/sv/androidjava/multithreading/); spara den från en enda tråd.

**Vad händer med hyperlänkar och externt länkade filer vid sparning?**

[Hyperlinks](/slides/sv/androidjava/manage-hyperlinks/) bevaras. Externt länkade filer (t.ex. videor via relativa sökvägar) kopieras inte automatiskt – se till att de refererade sökvägarna förblir tillgängliga.

**Kan jag ange/spara dokumentmetadata (författare, titel, företag, datum)?**

Ja. Standard [document properties](/slides/sv/androidjava/presentation-properties/) stöds och kommer att skrivas till filen vid sparning.