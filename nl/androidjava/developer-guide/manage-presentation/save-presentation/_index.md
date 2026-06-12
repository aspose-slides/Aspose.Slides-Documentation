---
title: Presentaties opslaan op Android
linktitle: Presentatie opslaan
type: docs
weight: 80
url: /nl/androidjava/save-presentation/
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
- vooraf gedefinieerd weergavetype
- Strict Office Open XML-formaat
- Zip64-modus
- miniatuur vernieuwen
- voortgang opslaan
- Android
- Java
- Aspose.Slides
description: "Ontdek hoe je presentaties kunt opslaan in Java met Aspose.Slides voor Android—exporteren naar PowerPoint of OpenDocument terwijl lay-outs, lettertypen en effecten behouden blijven."
---
## **Overzicht**

[Open Presentations on Android](/slides/nl/androidjava/open-presentation/) beschrijft hoe je de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑klasse gebruikt om een presentatie te openen. Dit artikel legt uit hoe je presentaties maakt en opslaat. De [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑klasse bevat de inhoud van een presentatie. Of je nu een presentatie vanaf nul maakt of een bestaande aanpast, je wilt ze opslaan wanneer je klaar bent. Met Aspose.Slides voor Android kun je opslaan naar een **bestand** of **stream**. Dit artikel legt de verschillende manieren uit om een presentatie op te slaan.

## **Presentaties opslaan naar bestanden**

Sla een presentatie op naar een bestand door de `save`‑methode van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑klasse aan te roepen. Geef de bestandsnaam en het opslagformaat door aan de methode. Het volgende voorbeeld laat zien hoe je een presentatie opslaat met Aspose.Slides.

```java
// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
Presentation presentation = new Presentation();
try {
    // Voer hier wat werkzaamheden uit...

    // Sla de presentatie op naar een bestand.
    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Presentaties opslaan naar streams**

Je kunt een presentatie opslaan naar een stream door een output‑stream door te geven aan de `save`‑methode van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑klasse. Een presentatie kan naar vele soorten streams worden geschreven. In het voorbeeld hieronder maken we een nieuwe presentatie en slaan we die op naar een bestands‑stream.

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

Aspose.Slides laat je het initiële weergavetype instellen dat PowerPoint gebruikt wanneer de gegenereerde presentatie wordt geopend via de [ViewProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/viewproperties/)‑klasse. Gebruik de [setLastView](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/viewproperties/#setLastView-int-)‑methode met een waarde uit de [ViewType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/viewtype/)‑enumeratie.

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

Aspose.Slides laat je een presentatie opslaan in het Strict Office Open XML‑formaat. Gebruik de [PptxOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/pptxoptions/)‑klasse en stel de eigenschap **conformance** in bij het opslaan. Als je [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/conformance/#Iso29500-2008-Strict) zet, wordt het uitvoerbestand opgeslagen in het Strict Office Open XML‑formaat.

Het voorbeeld hieronder maakt een presentatie en slaat die op in het Strict Office Open XML‑formaat.

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

Een Office Open XML‑bestand is een ZIP‑archief dat een limiet van 4 GB (2^32 bytes) oplegt aan de ongecomprimeerde grootte van elk bestand, de gecomprimeerde grootte van elk bestand en de totale grootte van het archief, en tevens een limiet van 65 535 (2^16‑1) bestanden. ZIP64‑formatextensies verhogen deze limieten tot 2^64.

De [IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipptxoptions/#setZip64Mode-int-)‑methode laat je kiezen wanneer ZIP64‑formatextensies te gebruiken bij het opslaan van een Office Open XML‑bestand.

Deze methode kan met de volgende modi worden gebruikt:

- [IfNecessary](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/zip64mode/#IfNecessary) gebruikt ZIP64‑formatextensies alleen als de presentatie de bovengenoemde limieten overschrijdt. Dit is de standaardmodus.
- [Never](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/zip64mode/#Never) gebruikt nooit ZIP64‑formatextensies.
- [Always](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/zip64mode/#Always) gebruikt altijd ZIP64‑formatextensies.

De volgende code demonstreert hoe je een presentatie opslaat als PPTX met ZIP64‑formatextensies ingeschakeld:

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

Wanneer je opslaat met [Zip64Mode.Never](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/zip64mode/#Never), wordt er een [PptxException](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/pptxexception/) gegooid als de presentatie niet kan worden opgeslagen in ZIP32‑formaat.

{{% /alert %}}

## **Presentaties opslaan zonder de miniatuur te vernieuwen**

De [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-)‑methode regelt de generatie van miniaturen bij het opslaan van een presentatie naar PPTX:

- Als deze op `true` staat, wordt de miniatuur tijdens het opslaan vernieuwd. Dit is de standaardwaarde.
- Als deze op `false` staat, wordt de huidige miniatuur behouden. Als de presentatie geen miniatuur heeft, wordt er geen gemaakt.

In de onderstaande code wordt de presentatie opgeslagen naar PPTX zonder de miniatuur te vernieuwen.

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

## **Opslaan met voortgangsupdates in procenten**

De [IProgressCallback](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iprogresscallback/)‑interface wordt gebruikt via de `setProgressCallback`‑methode die wordt blootgesteld door de [ISaveOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isaveoptions/)‑interface en de abstracte [SaveOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/saveoptions/)‑klasse. Ken een [IProgressCallback](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iprogresscallback/)‑implementatie toe met `setProgressCallback` om voortgangsupdates van het opslaan als percentage te ontvangen.

De volgende code‑fragmenten laten zien hoe je `IProgressCallback` gebruikt.

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
        // Gebruik hier de voortgangspercentage-waarde.
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}

Aspose heeft een [gratis PowerPoint‑splitter‑app](https://products.aspose.app/slides/nl/splitter) ontwikkeld met behulp van haar eigen API. De app laat je een presentatie in meerdere bestanden opsplitsen door geselecteerde dia’s op te slaan als nieuwe PPTX‑ of PPT‑bestanden.

{{% /alert %}}

## **FAQ**

**Wordt “snelle opslaan” (incrementeel opslaan) ondersteund zodat alleen wijzigingen worden weggeschreven?**

Nee. Elke keer wordt het volledige doelbestand aangemaakt; incrementeel “snelle opslaan” wordt niet ondersteund.

**Is het thread‑safe om dezelfde Presentation‑instantie vanuit meerdere threads op te slaan?**

Nee. Een [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑instantie is **niet thread‑safe** (/slides/nl/androidjava/multithreading/); sla deze op vanuit één thread.

**Wat gebeurt er met hyperlinks en extern gelinkte bestanden bij het opslaan?**

[Hyperlinks](/slides/nl/androidjava/manage-hyperlinks/) blijven behouden. Externe gelinkte bestanden (bijv. video’s via relatieve paden) worden niet automatisch gekopieerd – zorg ervoor dat de verwezen paden toegankelijk blijven.

**Kan ik documentmetadata (Auteur, Titel, Bedrijf, Datum) instellen/opslaan?**

Ja. Standaard [documenteigenschappen](/slides/nl/androidjava/presentation-properties/) worden ondersteund en bij het opslaan in het bestand geschreven.