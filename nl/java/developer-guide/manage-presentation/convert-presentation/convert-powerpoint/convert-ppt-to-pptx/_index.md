---
title: PPT naar PPTX converteren in Java
linktitle: PPT naar PPTX
type: docs
weight: 20
url: /nl/java/convert-ppt-to-pptx/
keywords:
- PowerPoint converteren
- presentatie converteren
- dia converteren
- PPT converteren
- PPT naar PPTX
- PPT opslaan als PPTX
- PPT exporteren naar PPTX
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Converteer legacy PPT-bestanden naar PPTX in Java met Aspose.Slides. Bevat Java-voorbeelden voor enkelvoudige en batch-conversie, foutafhandeling en nauwkeurigheid-opmerkingen."
---
## **Overzicht**

PPT is het legacy binaire PowerPoint-formaat, terwijl PPTX het nieuwere Open XML-formaat is. Aspose.Slides for Java kan een PPT‑bestand laden en opslaan als PPTX zonder Microsoft PowerPoint. Dit artikel laat zien hoe u één bestand of een map met bestanden kunt converteren en legt uit wat u na de conversie moet controleren.

## **Een PPT‑bestand naar PPTX converteren**

Laad het bronbestand met de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑klasse en roep vervolgens [Presentation.save](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#save-java.lang.String-int-) aan met [SaveFormat.Pptx](https://reference.aspose.com/slides/nl/java/com.aspose.slides/saveformat/#Pptx). Het `finally`‑blok maakt de presentatie vrij en geeft de bronnen vrij.

```java
// Laad de oude PPT-presentatie.
com.aspose.slides.Presentation presentation = new com.aspose.slides.Presentation("presentation.ppt");
try {
    // Sla de presentatie op in PPTX-formaat.
    presentation.save("presentation.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De bestandsextensie bepaalt niet zelfstandig het uitvoerformaat; het argument [SaveFormat.Pptx](https://reference.aspose.com/slides/nl/java/com.aspose.slides/saveformat/#Pptx) doet dat. Houd de invoer‑ en uitvoer‑paden verschillend als u het oorspronkelijke PPT‑bestand wilt behouden.

## **Meerdere PPT‑bestanden converteren**

Het onderstaande voorbeeld converteert elk `.ppt`‑bestand in één map. Elk bestand wordt onafhankelijk verwerkt, zodat één mislukte conversie de rest van de batch niet stopt.

```java
java.io.File inputDirectory = new java.io.File("input");
java.io.File outputDirectory = new java.io.File("output");
if (!outputDirectory.exists() && !outputDirectory.mkdirs()) {
    throw new IllegalStateException("Cannot create the output directory: " + outputDirectory);
}

java.io.File[] inputFiles = inputDirectory.listFiles((directory, name) -> name.toLowerCase(java.util.Locale.ROOT).endsWith(".ppt"));
if (inputFiles == null) {
    throw new IllegalStateException("Cannot read the input directory: " + inputDirectory);
}

for (java.io.File inputFile : inputFiles) {
    String inputPath = inputFile.getPath();
    String fileName = inputFile.getName();
    String outputFileName = fileName.substring(0, fileName.length() - 4) + ".pptx";
    String outputPath = new java.io.File(outputDirectory, outputFileName).getPath();
    com.aspose.slides.Presentation presentation = null;

    try {
        presentation = new com.aspose.slides.Presentation(inputPath);
        presentation.save(outputPath, com.aspose.slides.SaveFormat.Pptx);
        System.out.println("Converted: " + inputPath);
    } catch (Exception exception) {
        System.err.println("Failed: " + inputPath + " (" + exception.getMessage() + ")");
    } finally {
        if (presentation != null) {
            presentation.dispose();
        }
    }
}
```

Voor productie‑omgevingen moet u de volledige exceptie loggen, beslissen of een bestaand uitvoerbestand overschreven mag worden, en mislukte bestandsnamen naar een retry‑ of review‑wachtrij schrijven. Beschadigde bestanden, met wachtwoord beveiligde bestanden die zonder het vereiste wachtwoord worden geopend, ontoegankelijke paden en niet‑ondersteunde inhoud kunnen allemaal een conversie doen mislukken. Zie [Password-Protected Presentations](/java/password-protected-presentation/) voor het laden van versleutelde bestanden.

## **Nauwkeurigheid en legacy‑functies**

Conversie behoudt normaal gesproken dia's, masters, lay-outs, tekst, vormen, afbeeldingen, tabellen en diagrammen. Echter, PPT en PPTX vertegenwoordigen niet elke functie op exact dezelfde manier. Een legacy‑functie zonder PPTX‑equivalent, of die niet wordt ondersteund door de bibliotheek, kan genormaliseerd, weggelaten of anders weergegeven worden.

Controleer het geconverteerde bestand wanneer het animaties, overgangen, ingebedde of gekoppelde OLE‑objecten, ActiveX‑besturingselementen, ingebedde media, ongebruikelijke lettertypen of VBA‑macro's bevat. Een standaard PPTX‑bestand is geen macro‑enabled formaat, dus gebruik een geschikt macro‑enabled werkproces wanneer VBA beschikbaar moet blijven. Verifieer ook dat vereiste lettertypen en externe bronnen aanwezig zijn in de omgeving waarin de geconverteerde presentatie wordt geopend of gerenderd.

Voor belangrijke documenten dient u de gegenereerde PPTX programmatisch opnieuw te openen en belangrijke dia‑aantallen en inhoud te inspecteren, daarna de weergave en dia‑show‑gedrag te vergelijken in de beoogde viewer. Beschouw een succesvolle aanroep van [Presentation.save](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#save-java.lang.String-int-) niet als bewijs dat elke legacy‑functie een exacte PPTX‑representatie heeft.

## **Wanneer PPTX gebruiken**

Gebruik PPTX wanneer de presentatie wordt bewerkt in de huidige PowerPoint‑versies, wordt uitgewisseld met systemen die met Open XML‑pakketten werken, of wordt opgeslagen in een formaat dat makkelijker te inspecteren en te herstellen is dan het legacy binaire PPT. Bewaar het oorspronkelijke PPT als een archief‑ of rollback‑kopie totdat de geconverteerde presentatie uw nauwkeurigheidstests heeft doorstaan.

Als u in plaats daarvan PDF, HTML, afbeeldingen, XPS of een ander uitvoertype nodig heeft, gebruik dan de format‑specifieke richtlijnen in [Convert Presentations to Multiple Formats](/java/convert-presentation/) in plaats van aan te nemen dat alle doelpunten bewerkbare PowerPoint‑functies behouden.

## **Online converter**

Voor een incidenteel bestand of een snelle vergelijking kunt u de [online PPT to PPTX converter](https://products.aspose.app/slides/nl/conversion/ppt-to-pptx) gebruiken. Voor herhaalbare conversies, batchverwerking of foutafhandeling op applicatieniveau, gebruik de Java‑API.

## **Gerelateerde artikelen**

- [PPT vs PPTX](/java/ppt-vs-pptx/)
- [Save Presentations in Java](/java/save-presentation/)
- [Supported File Formats](/java/supported-file-formats/)
- [Open Presentations in Java](/java/open-presentation/)

## **FAQ**

**Kan ik PPT naar PPTX converteren zonder Microsoft PowerPoint geïnstalleerd?**

Ja. Aspose.Slides for Java laadt en slaat presentaties op zonder dat Microsoft PowerPoint vereist is.

**Zal de PPT‑naar‑PPTX‑conversie alle inhoud exact behouden?**

Het behoudt de gebruikelijke presentatiewaarde, maar exacte nauwkeurigheid is niet gegarandeerd voor elke legacy‑ of niet‑ondersteunde functie. Controleer het gegenereerde bestand wanneer het macro's, OLE‑ of ActiveX‑objecten, media, gespecialiseerde animaties of ongebruikelijke lettertypen bevat.

**Kan ik een met wachtwoord beveiligd PPT‑bestand converteren?**

Ja, als u het correcte wachtwoord opgeeft bij het laden van het bestand. Een ontbrekend of onjuist wachtwoord zorgt ervoor dat de laadoperatie faalt.

**Moet ik het PPT‑bestand na de conversie verwijderen?**

Bewaar het origineel tot u het PPTX hebt geverifieerd in de viewers en werkstromen die voor u van belang zijn. Dit biedt een rollback‑kopie als een legacy‑functie anders wordt geconverteerd.