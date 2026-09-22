---
title: Bepaal het oorspronkelijke presentatieformaat in Java
linktitle: Bronformaat
type: docs
weight: 35
url: /nl/java/detect-presentation-source-format/
keywords:
- bronformaat
- detecteer presentatieformaat
- PowerPoint
- OpenDocument
- presentatie
- PPT
- PPTX
- Java
- Aspose.Slides
description: "Lees het oorspronkelijke formaat van een geladen presentatie in Java met Aspose.Slides for Java, vergelijk detectie‑API's en verwerk bestanden, streams en legacy‑formaten."
---
## **Overzicht**

Na het laden van een presentatie, roep je de [Presentation.getSourceFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#getSourceFormat--) methode aan om het oorspronkelijke formaat te bepalen. De methode is ook beschikbaar via [IPresentation.getSourceFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipresentation/#getSourceFormat--). Gebruik deze wanneer verdere verwerking afhankelijk is van het formaat waaruit de huidige instantie is geladen.

Het bronformaat is verschillend van het [SaveFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/saveformat/) dat voor een uitvoerbestand is geselecteerd. Opslaan naar een ander formaat wijzigt het bronformaat van de bestaande instantie niet.

## **Het bronformaat van een bestand lezen**

Dit voorbeeld vereist een bestaand bestand `sample.pptx`. Het laadt het bestand en selecteert een toepassingsverwerkingsbeleid met behulp van [Presentation.getSourceFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#getSourceFormat--), in plaats van de bestandsnaam. Wijzig het invoerpad om andere formaten te proberen. Het voorbeeld drukt het geselecteerde beleid af; vervang de berichten door je eigen toepassingslogica.

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

## **Herken de ondersteunde waarden**

De [SourceFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/sourceformat/) klasse definieert integer‑constanten die de volgende presentatieformaten onderscheiden. De onderstaande extensies zijn conventionele extensies, geen reconstructie van de oorspronkelijke bestandsnaam.

| SourceFormat-waarde | Extensie | Formaat |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint 97–2003 presentatie |
| `Pptx` | `.pptx` | Office Open XML presentatie |
| `Pptm` | `.pptm` | Macro‑ingeschakelde Office Open XML presentatie |
| `Pps` | `.pps` | PowerPoint 97–2003 diavoorstelling |
| `Ppsx` | `.ppsx` | Office Open XML diavoorstelling |
| `Ppsm` | `.ppsm` | Macro‑ingeschakelde Office Open XML diavoorstelling |
| `Pot` | `.pot` | PowerPoint 97–2003 sjabloon |
| `Potx` | `.potx` | Office Open XML sjabloon |
| `Potm` | `.potm` | Macro‑ingeschakelde Office Open XML sjabloon |
| `Odp` | `.odp` | OpenDocument presentatie |
| `Otp` | `.otp` | OpenDocument presentatiesjabloon |
| `Fodp` | `.fodp` | Flat XML ODF presentatie |
| `Xml` | `.xml` | PowerPoint XML presentatie |

## **Het bronformaat van een stream lezen**

Dit voorbeeld vereist een bestaand bestand `sample.pps`. Het lezen van de bytes naar een memory‑stream modelleert invoer zonder bestandsnaam, zoals een database‑waarde of een geüploade byte‑array. De [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) constructor ontvangt alleen de stream.

```java
import com.aspose.slides.Presentation;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

try {
    byte[] bytes = Files.readAllBytes(Paths.get("sample.pps"));
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

PPT, PPS en POT gebruiken hetzelfde onderliggende binaire formaat. Bij het laden via een pad kan de extensie helpen om een diavoorstelling of sjabloon te onderscheiden. Zonder bestandsnaam kan legacy PPS‑ en POT‑inhoud worden gerapporteerd als `SourceFormat.Ppt`; het PPS‑voorbeeld hierboven drukt de integer‑waarde van `SourceFormat.Ppt` af.

Als je toepassing het onderscheid moet behouden, bewaar dan de oorspronkelijke bestandsnaam of sub‑type‑metadata apart. Een extensie is een nuttige hint voor deze legacy‑subtypen, maar mag niet de enige basis zijn voor het identificeren van willekeurige presentaties.

## **Detectie vóór en na het laden vergelijken**

Gebruik [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) en [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipresentationinfo/#getLoadFormat--) wanneer je een bestand moet inspecteren vóór het volledig laden van het presentatie‑objectmodel. Gebruik [Presentation.getSourceFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#getSourceFormat--) wanneer de instantie al bestaat.

Dit voorbeeld vereist `sample.pptx` en drukt de integer‑waarden van `LoadFormat.Pptx` en `SourceFormat.Pptx` respectievelijk af. In productie kies je de API die past bij je verwerkingsstadium; een al geladen presentatie heeft geen tweede inspectie nodig uitsluitend om het bronformaat te verkrijgen.

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

De resultaten gebruiken constanten uit verschillende klassen: [LoadFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/loadformat/) en [SourceFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/sourceformat/). Vergelijk hun numerieke waarden niet en ga er niet vanuit dat elk formaat identieke detectieresultaten oplevert. PowerPoint XML kan vóór het laden worden gerapporteerd als `LoadFormat.Unknown` en na het laden als `SourceFormat.Xml`.

## **Houd bron- en uitvoerformaten gescheiden**

Dit voorbeeld vereist `sample.pptx` en schrijft `converted.odp`. Het drukt de integer‑waarde van `SourceFormat.Pptx` zowel vóór als na het opslaan van de oorspronkelijke instantie af. Alleen de nieuwe instantie die is geladen uit de ODP‑output meldt `Odp`.

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

Een presentatie die vanaf nul is gemaakt met `new Presentation()` meldt `SourceFormat.Pptx`. Ze heeft geen invoerbestand: dit is de standaardwaarde voor een nieuw aangemaakte instantie, geen bewijs dat er een PPTX‑bestand is geladen. Houd apart bij of je toepassing de instantie heeft gecreëerd of geladen als dat onderscheid belangrijk is.

## **Map een bronformaat naar een extensie**

Het volgende voorbeeld vereist `sample.pptx`. Het mappt elke momenteel ondersteunde [SourceFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/sourceformat/) waarde naar een conventionele extensie, zonder de invoer‑bestandsnaam te analyseren. De fallback voorkomt stilzwijgend toewijzen van een extensie aan een niet‑herkende waarde.

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

Deze mapping converteert geen bestand en herstelt geen legacy PPS/POT‑subtype dat verloren ging tijdens het laden vanuit een stream. Voor daadwerkelijk opslaan selecteer je expliciet een [SaveFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/saveformat/) of gebruik je de conversie die wordt getoond in [Save Presentations in Their Original Format](/slides/nl/java/save-presentation/#save-presentations-in-their-original-format).

## **Verifieer formaten door op te slaan en opnieuw te openen**

Dit zelf‑containende voorbeeld maakt een presentatie en schrijft drie bestanden in de werkmap, waarbij bestanden met dezelfde namen worden overschreven. Het opent elke output zowel via pad als via een memory‑stream opnieuw. Voor PPTX en ODP rapporteren beide routes het opgeslagen formaat. Voor PPS rapporteert laden via pad `Pps`, terwijl laden van dezelfde bytes zonder bestandsnaam `Ppt` rapporteert.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    int[] formats = { SaveFormat.Pptx, SaveFormat.Odp, SaveFormat.Pps };
    String[] extensions = { "pptx", "odp", "pps" };

    for (int i = 0; i < formats.length; i++) {
        String path = "roundtrip." + extensions[i];
        presentation.save(path, formats[i]);

        Presentation fromFile = new Presentation(path);
        try {
            byte[] bytes = Files.readAllBytes(Paths.get(path));
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

| Opgeslagen formaat | SourceFormat vanaf een bestandsnaam | SourceFormat vanaf een naamloze stream |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` respectievelijk | Same as file path |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` respectievelijk | Same as file path |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` respectievelijk | Same as file path |
| ODP, OTP | `Odp`, `Otp` respectievelijk | Same as file path |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

PPS/POT‑inhoud wordt geïdentificeerd als `Ppt` voor naamloze streams. De tabel beschrijft formatidentificatie, niet de behoud van elk presentatiefunctie tijdens conversie.

## **FAQ**

**Verandert het opslaan naar ODP het bronformaat van een presentatie die is geladen vanuit PPTX?**

Nee. De bestaande instantie meldt nog steeds `Pptx`. Een instantie die is geladen vanuit het opgeslagen ODP‑bestand meldt `Odp`.

**Kan een stream altijd een legacy‑presentatie, diavoorstelling en sjabloon van elkaar onderscheiden?**

Nee. PPT, PPS en POT delen hetzelfde binaire formaat. Bewaar de bestandsnaam of sub‑type‑metadata apart wanneer dat onderscheid vereist is.

**Welke API moet ik gebruiken als de presentatie al geladen is?**

Lees [Presentation.getSourceFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#getSourceFormat--). Gebruik [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) voor inspectie vóór het laden.