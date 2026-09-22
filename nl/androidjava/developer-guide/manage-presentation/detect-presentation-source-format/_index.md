---
title: Bepaal het originele presentatieformaat op Android
linktitle: Bronformaat
type: docs
weight: 35
url: /nl/androidjava/detect-presentation-source-format/
keywords:
- bronformaat
- presentatieformaat detecteren
- PowerPoint
- OpenDocument
- presentatie
- PPT
- PPTX
- Android
- Java
- Aspose.Slides
description: "Lees het originele formaat van een geladen presentatie op Android met Aspose.Slides voor Android via Java, vergelijk detectie‑API's en verwerk bestanden, streams en legacy‑formaten."
---
## **Overzicht**

Na het laden van een presentatie roep je de [Presentation.getSourceFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#getSourceFormat--) methode aan om het oorspronkelijke formaat te bepalen. De methode is ook beschikbaar via [IPresentation.getSourceFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentation/#getSourceFormat--). Gebruik deze wanneer de daaropvolgende verwerking afhangt van het formaat waarin de huidige instantie is geladen.

Het bronformaat verschilt van het [SaveFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/saveformat/) dat voor een uitvoerbestand is geselecteerd. Opslaan naar een ander formaat wijzigt het bronformaat van de bestaande instantie niet.

De voorbeelden gebruiken Java en bestands‑paden. Op Android vervang je de voorbeeldpaden door paden in de door de app toegankelijke opslag, bijvoorbeeld de interne bestandenmap van je app.

## **Het bronformaat van een bestand lezen**

Dit voorbeeld vereist een bestaand `sample.pptx`‑bestand. Het laadt het bestand en kiest een toepassingsverwerkingsbeleid met [Presentation.getSourceFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#getSourceFormat--), in plaats van de bestandsnaam. Pas het invoer‑pad aan om andere formaten te proberen. Het voorbeeld drukt het geselecteerde beleid af; vervang de berichten door je eigen toepassingslogica.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SourceFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    switch (presentation.getSourceFormat()) {
        case SourceFormat.Ppt:
        case SourceFormat.Pps:
        case SourceFormat.Pot:
            System.out.println("Use the legacy PowerPoint processing policy.");
            break;
        case SourceFormat.Pptx:
            System.out.println("Use the standard PPTX processing policy.");
            break;
        default:
            System.out.println("Use the general policy for source format " + presentation.getSourceFormat() + ".");
            break;
    }
} finally {
    presentation.dispose();
}
```

## **De ondersteunde waarden herkennen**

De class [SourceFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/sourceformat/) definieert integer‑constanten die de volgende presentatieformaten onderscheiden. De onderstaande extensies zijn conventionele extensies, geen reconstructie van de originele bestandsnaam.

| SourceFormat‑waarde | Extensie | Formaat |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint 97–2003‑presentatie |
| `Pptx` | `.pptx` | Office Open XML‑presentatie |
| `Pptm` | `.pptm` | Macro‑enabled Office Open XML‑presentatie |
| `Pps` | `.pps` | PowerPoint 97–2003‑diavoorstelling |
| `Ppsx` | `.ppsx` | Office Open XML‑diavoorstelling |
| `Ppsm` | `.ppsm` | Macro‑enabled Office Open XML‑diavoorstelling |
| `Pot` | `.pot` | PowerPoint 97–2003‑sjabloon |
| `Potx` | `.potx` | Office Open XML‑sjabloon |
| `Potm` | `.potm` | Macro‑enabled Office Open XML‑sjabloon |
| `Odp` | `.odp` | OpenDocument‑presentatie |
| `Otp` | `.otp` | OpenDocument‑presentatiesjabloon |
| `Fodp` | `.fodp` | Flat XML ODF‑presentatie |
| `Xml` | `.xml` | PowerPoint XML‑presentatie |

## **Het bronformaat van een stream lezen**

Dit voorbeeld vereist een bestaand `sample.pps`‑bestand. Het inlezen van de bytes in een geheugenstream modelleert invoer die zonder bestandsnaam wordt ontvangen, bijvoorbeeld een database‑waarde of een geüploade byte‑array. De [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑constructor ontvangt alleen de stream.

```java
import com.aspose.slides.Presentation;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.ByteArrayOutputStream;
import java.io.FileInputStream;

try {
    byte[] bytes;
    try (FileInputStream input = new FileInputStream("sample.pps");
         ByteArrayOutputStream output = new ByteArrayOutputStream()) {
        byte[] buffer = new byte[8192];
        int bytesRead;
        while ((bytesRead = input.read(buffer)) != -1) {
            output.write(buffer, 0, bytesRead);
        }
        bytes = output.toByteArray();
    }
    try (ByteArrayInputStream stream = new ByteArrayInputStream(bytes)) {
        Presentation presentation = new Presentation(stream);
        try {
            System.out.println("Source format: " + presentation.getSourceFormat());
        } finally {
            presentation.dispose();
        }
    }
} catch (IOException exception) {
    System.err.println("Cannot read the presentation: " + exception.getMessage());
}
```

PPT, PPS en POT gebruiken hetzelfde onderliggende binaire formaat. Bij het laden via een bestands‑pad kan de extensie helpen om een diavoorstelling of sjabloon te onderscheiden. Zonder bestandsnaam kan legacy‑inhoud van PPS en POT gerapporteerd worden als `SourceFormat.Ppt`; het PPS‑voorbeeld hierboven drukt de integer‑waarde van `SourceFormat.Ppt` af.

Moet je applicatie dit onderscheid behouden, bewaar dan de originele bestandsnaam of sub‑type‑metadata apart. Een extensie is een bruikbare hint voor deze legacy‑subtypes, maar mag niet de enige basis zijn om willekeurige presentatiedata te identificeren.

## **Detectie vóór en na het laden vergelijken**

Gebruik [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) en [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentationinfo/#getLoadFormat--) wanneer je een bestand moet inspecteren voordat je het volledige presentatie‑objectmodel laadt. Gebruik [Presentation.getSourceFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#getSourceFormat--) wanneer de instantie al bestaat.

Dit voorbeeld vereist `sample.pptx` en drukt de integer‑waarden van `LoadFormat.Pptx` en `SourceFormat.Pptx` respectievelijk af. In productie kies je de API die past bij je verwerkingsfase; een reeds geladen presentatie hoeft niet opnieuw geïnspecteerd te worden alleen om het bronformaat te verkrijgen.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.PresentationFactory;

String path = "sample.pptx";
IPresentationInfo information = PresentationFactory.getInstance().getPresentationInfo(path);
System.out.println("Before loading: " + information.getLoadFormat());

Presentation presentation = new Presentation(path);
try {
    System.out.println("After loading: " + presentation.getSourceFormat());
} finally {
    presentation.dispose();
}
```

De resultaten gebruiken constante waarden uit verschillende classes: [LoadFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/loadformat/) en [SourceFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/sourceformat/). Vergelijk hun numerieke waarden niet en ga er niet van uit dat elk formaat identieke detectieresultaten oplevert. PowerPoint XML kan vóór het laden gerapporteerd worden als `LoadFormat.Unknown` en na het laden als `SourceFormat.Xml`.

## **Bron‑ en uitvoerformaten gescheiden houden**

Dit voorbeeld vereist `sample.pptx` en schrijft `converted.odp`. Het drukt de integer‑waarde van `SourceFormat.Pptx` zowel vóór als ná het opslaan van de originele instantie af. Alleen de nieuwe instantie die wordt geladen uit de ODP‑output rapporteert `Odp`.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    System.out.println("Before saving: " + presentation.getSourceFormat());

    presentation.save("converted.odp", SaveFormat.Odp);
    System.out.println("After saving: " + presentation.getSourceFormat());

    Presentation reopened = new Presentation("converted.odp");
    try {
        System.out.println("Reopened output: " + reopened.getSourceFormat());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Een presentatie die van nul wordt aangemaakt met `new Presentation()` rapporteert `SourceFormat.Pptx`. Ze heeft geen invoerbestand: dit is de standaardwaarde voor een pas aangemaakte instantie, niet een aanwijzing dat er een PPTX‑bestand is geladen. Houd bij of je applicatie de instantie heeft gecreëerd of geladen, als dat onderscheid van belang is.

## **Een bronformaat omzetten naar een extensie**

Het volgende voorbeeld vereist `sample.pptx`. Het zet elke momenteel ondersteunde [SourceFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/sourceformat/)‑waarde om naar een conventionele extensie, zonder de invoer‑bestandsnaam te analyseren. De fallback voorkomt dat er stilzwijgend een extensie wordt toegewezen aan een niet‑herkende waarde.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SourceFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    String extension;
    switch (presentation.getSourceFormat()) {
        case SourceFormat.Ppt:
            extension = ".ppt";
            break;
        case SourceFormat.Pptx:
            extension = ".pptx";
            break;
        case SourceFormat.Pptm:
            extension = ".pptm";
            break;
        case SourceFormat.Pps:
            extension = ".pps";
            break;
        case SourceFormat.Ppsx:
            extension = ".ppsx";
            break;
        case SourceFormat.Ppsm:
            extension = ".ppsm";
            break;
        case SourceFormat.Pot:
            extension = ".pot";
            break;
        case SourceFormat.Potx:
            extension = ".potx";
            break;
        case SourceFormat.Potm:
            extension = ".potm";
            break;
        case SourceFormat.Odp:
            extension = ".odp";
            break;
        case SourceFormat.Otp:
            extension = ".otp";
            break;
        case SourceFormat.Fodp:
            extension = ".fodp";
            break;
        case SourceFormat.Xml:
            extension = ".xml";
            break;
        default:
            extension = null;
            break;
    }

    System.out.println(extension != null ? extension : "No extension mapping is available.");
} finally {
    presentation.dispose();
}
```

Deze mapping converteert geen bestand en herstelt geen legacy‑PPS/POT‑subtype dat verloren ging tijdens het laden van een stream. Voor daadwerkelijk opslaan, selecteer je expliciet een [SaveFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/saveformat/) of gebruik je de conversie die wordt getoond in [Save Presentations in Their Original Format](/slides/nl/androidjava/save-presentation/#save-presentations-in-their-original-format).

## **Formaten verifiëren door op te slaan en opnieuw te openen**

Dit zelf‑containende voorbeeld maakt een presentatie aan en schrijft drie bestanden in de werkmap, waarbij bestanden met dezelfde naam overschreven worden. Het opent elke output zowel via pad als via een geheugenstream opnieuw. Voor PPTX en ODP rapporteren beide routes het opgeslagen formaat. Voor PPS rapporteert het laden via pad `Pps`, terwijl het laden van dezelfde bytes zonder bestandsnaam `Ppt` rapporteert.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.ByteArrayOutputStream;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    int[] formats = { SaveFormat.Pptx, SaveFormat.Odp, SaveFormat.Pps };
    String[] extensions = { "pptx", "odp", "pps" };

    for (int i = 0; i < formats.length; i++) {
        String path = "roundtrip." + extensions[i];
        presentation.save(path, formats[i]);

        Presentation fromFile = new Presentation(path);
        try {
            byte[] bytes;
            try (FileInputStream input = new FileInputStream(path);
                 ByteArrayOutputStream output = new ByteArrayOutputStream()) {
                byte[] buffer = new byte[8192];
                int bytesRead;
                while ((bytesRead = input.read(buffer)) != -1) {
                    output.write(buffer, 0, bytesRead);
                }
                bytes = output.toByteArray();
            }
            try (ByteArrayInputStream stream = new ByteArrayInputStream(bytes)) {
                Presentation fromStream = new Presentation(stream);
                try {
                    System.out.println(extensions[i] + ": file=" + fromFile.getSourceFormat() + ", stream=" + fromStream.getSourceFormat());
                } finally {
                    fromStream.dispose();
                }
            }
        } finally {
            fromFile.dispose();
        }
    }
} catch (IOException exception) {
    System.err.println("Cannot read a saved presentation: " + exception.getMessage());
} finally {
    presentation.dispose();
}
```

De volgende tabel geeft een overzicht van bron‑formaat‑identificatie voor presentaties met overeenkomstige extensies. De namen duiden op constanten; de Java‑voorbeelden drukken hun integer‑waarden af:

| Opgeslagen formaat | SourceFormat via bestands‑pad | SourceFormat via naamloze stream |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | respectievelijk `Pptx`, `Pptm` | Zelfde als bestands‑pad |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | respectievelijk `Ppsx`, `Ppsm` | Zelfde als bestands‑pad |
| POT | `Pot` | `Ppt` |
| POTX, POTM | respectievelijk `Potx`, `Potm` | Zelfde als bestands‑pad |
| ODP, OTP | respectievelijk `Odp`, `Otp` | Zelfde als bestands‑pad |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

PPS/POT‑inhoud wordt geïdentificeerd als `Ppt` voor naamloze streams. De tabel beschrijft format‑identificatie, niet het behoud van elk presentatiefunctie‑aspect tijdens conversie.

## **FAQ**

**Verandert het opslaan naar ODP het bronformaat van een presentatie die uit PPTX is geladen?**

Nee. De bestaande instantie rapporteert nog steeds `Pptx`. Een instantie die wordt geladen uit het opgeslagen ODP‑bestand rapporteert `Odp`.

**Kan een stream altijd een legacy‑presentatie, diavoorstelling en sjabloon onderscheiden?**

Nee. PPT, PPS en POT delen hetzelfde binaire formaat. Bewaar de bestandsnaam of sub‑type‑metadata apart wanneer dat onderscheid vereist is.

**Welke API moet ik gebruiken wanneer de presentatie al is geladen?**

Lees [Presentation.getSourceFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#getSourceFormat--). Gebruik [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) voor inspectie vóór het laden.