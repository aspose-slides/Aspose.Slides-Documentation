---
title: Presentaties opslaan in Java
linktitle: Presentatie opslaan
type: docs
weight: 80
url: /nl/java/save-presentation/
keywords:
- PowerPoint opslaan
- OpenDocument opslaan
- presentatie opslaan
- dia opslaan
- PPT opslaan
- PPTX opslaan
- ODP opslaan
- presentatie naar bestand
- presentatie naar stream
- voorgedefinieerd weergavetype
- Strict Office Open XML-formaat
- Zip64-modus
- miniatuur vernieuwen
- opslaaprogress
- Java
- Aspose.Slides
description: "Ontdek hoe je presentaties opslaat in Java met Aspose.Slides—exporteer naar PowerPoint of OpenDocument met behoud van lay-outs, lettertypen en effecten."
---
## **Overzicht**

[Open presentaties in Java](/slides/nl/java/open-presentation/) beschreef hoe de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) klasse gebruikt wordt om een presentatie te openen. Dit artikel legt uit hoe je presentaties maakt en opslaat. De [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) klasse bevat de inhoud van een presentatie. Of je nu een presentatie vanaf nul maakt of een bestaande wijzigt, je wilt deze opslaan wanneer je klaar bent. Met Aspose.Slides for Java kun je opslaan naar een **bestand** of **stream**. Dit artikel legt de verschillende manieren uit om een presentatie op te slaan.

## **Presentaties opslaan naar bestanden**

Sla een presentatie op naar een bestand door de `save`-methode van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) klasse aan te roepen. Geef de bestandsnaam en het opslaformat door aan de methode. Het volgende voorbeeld toont hoe je een presentatie opslaat met Aspose.Slides.

```java
// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
Presentation presentation = new Presentation();
try {
    // Doe hier wat werk...

    // Sla de presentatie op naar een bestand.
    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Presentaties opslaan naar streams**

Je kunt een presentatie opslaan naar een stream door een output‑stream door te geven aan de `save`‑methode van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) klasse. Een presentatie kan naar veel verschillende stream‑typen geschreven worden. In het onderstaande voorbeeld maken we een nieuwe presentatie en slaan we deze op naar een bestands‑stream.

```java
// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
Presentation presentation = new Presentation();
try {
    OutputStream fileStream = new FileOutputStream("Output.pptx");
    try {
        // Sla de presentatie op naar de stream.
        presentation.save(fileStream, SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Presentaties opslaan met een vooraf gedefinieerd weergavetype**

Aspose.Slides laat je de initiële weergave instellen die PowerPoint gebruikt wanneer de gegenereerde presentatie wordt geopend via de [ViewProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/viewproperties/) klasse. Gebruik de [setLastView](https://reference.aspose.com/slides/nl/java/com.aspose.slides/viewproperties/#setLastView-int-) methode met een waarde uit de [ViewType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/viewtype/) enumeratie.

```java
Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Presentaties opslaan in het Strict Office Open XML‑formaat**

Aspose.Slides stelt je in staat een presentatie op te slaan in het Strict Office Open XML‑formaat. Gebruik de [PptxOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pptxoptions/) klasse en stel de conformance‑eigenschap in bij het opslaan. Als je [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/nl/java/com.aspose.slides/conformance/#Iso29500-2008-Strict) instelt, wordt het uitvoerbestand opgeslagen in het Strict Office Open XML‑formaat.

Het onderstaande voorbeeld maakt een presentatie en slaat deze op in het Strict Office Open XML‑formaat.

```java
PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
Presentation presentation = new Presentation();
try {
    // Sla de presentatie op in het Strict Office Open XML-formaat.
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Presentaties opslaan in Office Open XML‑formaat in Zip64‑modus**

Een Office Open XML‑bestand is een ZIP‑archief dat limieten van 4 GB (2^32 bytes) oplegt aan de ongecomprimeerde grootte van elk bestand, de gecomprimeerde grootte van elk bestand en de totale grootte van het archief, en het beperkt het archief tot 65 535 (2^16‑1) bestanden. ZIP64‑formaatuitbreidingen verhogen deze limieten tot 2^64.

De [IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipptxoptions/#setZip64Mode-int-) methode laat je kiezen wanneer ZIP64‑formaatuitbreidingen gebruikt worden bij het opslaan van een Office Open XML‑bestand.

Deze methode kan gebruikt worden met de volgende modi:

- [IfNecessary](https://reference.aspose.com/slides/nl/java/com.aspose.slides/zip64mode/#IfNecessary) gebruikt ZIP64‑formaatuitbreidingen alleen als de presentatie de bovenstaande limieten overschrijdt. Dit is de standaardmodus.
- [Never](https://reference.aspose.com/slides/nl/java/com.aspose.slides/zip64mode/#Never) gebruikt nooit ZIP64‑formaatuitbreidingen.
- [Always](https://reference.aspose.com/slides/nl/java/com.aspose.slides/zip64mode/#Always) gebruikt altijd ZIP64‑formaatuitbreidingen.

De volgende code toont hoe je een presentatie opslaat als PPTX met ingeschakelde ZIP64‑formaatuitbreidingen:

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

{{% alert title="OPMERKING" color="warning" %}}

Wanneer je opslaat met [Zip64Mode.Never](https://reference.aspose.com/slides/nl/java/com.aspose.slides/zip64mode/#Never), wordt een [PptxException](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pptxexception/) gegooid als de presentatie niet opgeslagen kan worden in ZIP32‑formaat.

{{% /alert %}}

## **Presentaties opslaan zonder het miniatuurbeeld te vernieuwen**

De [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) methode regelt de generatie van miniatuurbeelden bij het opslaan van een presentatie naar PPTX:

- Als ingesteld op `true`, wordt het miniatuurbeeld ververst tijdens het opslaan. Dit is de standaard.
- Als ingesteld op `false`, blijft het huidige miniatuurbeeld behouden. Als de presentatie geen miniatuurbeeld heeft, wordt er geen gegenereerd.

In de code hieronder wordt de presentatie opgeslagen naar PPTX zonder het miniatuurbeeld te vernieuwen.

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

Deze optie helpt de tijd te verkorten die nodig is om een presentatie op te slaan in PPTX‑formaat.

{{% /alert %}}

## **Voortgangsupdates opslaan in percentage**

De [IProgressCallback](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iprogresscallback/) interface wordt gebruikt via de `setProgressCallback`‑methode die wordt blootgesteld door de [ISaveOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isaveoptions/) interface en de abstracte [SaveOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/saveoptions/) klasse. Wijs een [IProgressCallback](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iprogresscallback/) implementatie toe met `setProgressCallback` om voortgangsupdates tijdens het opslaan als percentage te ontvangen.

De volgende codefragmenten tonen hoe je `IProgressCallback` gebruikt.

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
        // Gebruik hier de voortgangspercentagewaarde.
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}

Aspose heeft een [gratis PowerPoint Splitter‑app](https://products.aspose.app/slides/nl/splitter) ontwikkeld met behulp van haar eigen API. De app laat je een presentatie splitsen in meerdere bestanden door geselecteerde dia’s op te slaan als nieuwe PPTX‑ of PPT‑bestanden.

{{% /alert %}}

## **FAQ**

**Wordt “snelle opslaan” (incrementeel opslaan) ondersteund zodat alleen wijzigingen worden weggeschreven?**

Nee. Opslaan maakt elke keer het volledige doelbestand; incrementeel “snelle opslaan” wordt niet ondersteund.

**Is het thread‑safe om dezelfde Presentation‑instantie vanuit meerdere threads op te slaan?**

Nee. Een [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) instantie [is niet thread‑safe](/slides/nl/java/multithreading/); sla deze op vanuit één enkele thread.

**Wat gebeurt er met hyperlinks en extern gekoppelde bestanden bij het opslaan?**

[Hyperlinks](/slides/nl/java/manage-hyperlinks/) blijven behouden. Extern gekoppelde bestanden (bijv. video's via relatieve paden) worden niet automatisch gekopieerd – zorg dat de verwezen paden toegankelijk blijven.

**Kan ik document‑metadata (Auteur, Titel, Bedrijf, Datum) instellen/opslaan?**

Ja. Standaard [documenteigenschappen](/slides/nl/java/presentation-properties/) worden ondersteund en bij het opslaan in het bestand geschreven.