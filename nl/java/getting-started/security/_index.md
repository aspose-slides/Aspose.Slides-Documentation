---
title: Beveiliging
type: docs
weight: 160
url: /nl/java/security/
keywords:
- beveiliging
- afhankelijkheden
- componenten van derden
- Maven
- JAR-handtekening
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Bekijk hoe Aspose.Slides for Java presentaties verwerkt, wat het toevoegt aan de afhankelijkheden van uw project, hoe u het JAR-bestand kunt verifiëren, en welke componenten van derden het bevat."
---
## **Inleiding**

Dit artikel verzamelt de informatie die een beveiligingsbeoordeling van een applicatie die Aspose.Slides for Java gebruikt doorgaans nodig heeft: hoe de bibliotheek presentaties verwerkt, wat het toevoegt aan de afhankelijkheden van uw project, hoe te controleren of het JAR‑bestand van Aspose afkomstig is, en welke componenten van derden het JAR‑bestand bevat.

## **Beveiliging in Aspose.Slides**

Aspose hanteert best practices bij de ontwikkeling van haar producten.

* Aspose.Slides for Java wordt gebruikt om presentaties te maken, te wijzigen en te converteren. Het voert geen scripts uit in presentaties. Aspose.Slides parseert de presentatiestructuur en laat uw code werken met het objectmodel.
* Aspose.Slides functioneert als een bibliotheek die documenten parseert en interpreteert zonder externe code uit te voeren. Alle Aspose‑producten draaien op uw machines. Ze verzenden geen gegevens naar Aspose. De enige uitzondering is [metered licensing](/slides/nl/java/metered-licensing/): als u dit gebruikt, wordt alleen uw API‑gebruik verwerkt.
* Aspose‑componenten draaien in dezelfde gebruikerscontext als reguliere applicaties. Daarom vormen Aspose‑componenten geen risico voor vitale systeembronnen. Bovendien worden macro’s niet automatisch uitgevoerd wanneer een Aspose‑component een document opent.

## **Maven‑afhankelijkheden**

Het Maven‑artifact van Aspose.Slides for Java, `com.aspose:aspose-slides`, declareert geen afhankelijkheden: het POM‑bestand bevat alleen de coördinaten van het eigen artifact. Wanneer u het aan een project toevoegt, voegt Maven dit ene JAR‑bestand toe en niets anders. Om elk artifact dat uw project oplost, inclusief transitieve afhankelijkheden, weer te geven, voert u het volgende commando uit in de projectmap:

```bash
mvn dependency:tree
```

In het project van [Installation](/slides/nl/java/installation/) toont de output Aspose.Slides als de enige afhankelijkheid:

```text
[INFO] com.example:hello-slides:jar:1.0
[INFO] \- com.aspose:aspose-slides:jar:jdk16:26.9:compile
```

## **Controleer het JAR‑bestand**

Aspose ondertekent het JAR‑bestand. Om de handtekening te controleren, voert u het `jarsigner`‑hulpmiddel uit de JDK uit in de map die het JAR‑bestand bevat:

```bash
jarsigner -verify aspose-slides-26.9-jdk16.jar
```

Het commando laat `jar verified.` zien wanneer de handtekening geldig is en er geen entry is gewijzigd sinds het bestand is ondertekend. Deze boodschap noemt de ondertekenaar niet. Om te bevestigen dat Aspose het bestand heeft ondertekend, voegt u de opties `-verbose` en `-certs` toe en controleert u of het certificaat van de ondertekenaar is uitgegeven aan `CN=ASPOSE PTY LTD`. Wanneer Maven het JAR‑bestand downloadt, controleert het tevens de SHA‑1‑controlesom die de repository naast het bestand publiceert.

## **Componenten van derden**

Aspose.Slides for Java bevat code en data van componenten van derden. Ze maken deel uit van het JAR‑bestand, niet van afzonderlijke Maven‑artifacts, zodat `mvn dependency:tree` en andere tools die Maven‑afhankelijkheden lezen ze niet weergeven. Het JAR‑bestand bevat de notice *META-INF/ThirdPartyLicenses-Aspose.Slides for Java.pdf*, waarin de componenten en hun licenties worden opgesomd:

| Component | Licentie vermeld in de notice |
|---|---|
| DotNetZip | Microsoft Public License (Ms-PL) |
| Bouncy Castle | MIT‑style licentie |
| Mono | MIT‑licentie; sommige delen onder andere licenties die in de notice staan |
| RSWOP.ICM color profile | Microsoft licentievoorwaarden |
| sRGB_v4_ICC_preference.icc color profile | ICC‑toestemming om ongewijzigde file te gebruiken, kopiëren en distribueren |
| Apache | Apache License 2.0 |
| ANTLR | BSD License |
| sfntly | Apache License 2.0 |

Om de notice uit het JAR‑bestand te halen, voert u het `jar`‑hulpmiddel uit de JDK uit in de map die het JAR‑bestand bevat:

```bash
jar xf aspose-slides-26.9-jdk16.jar "META-INF/ThirdPartyLicenses-Aspose.Slides for Java.pdf"
```

## **FAQ**

**Gebruikt Aspose.Slides for Java externe pakketten?**

Het heeft geen Maven‑afhankelijkheden, zoals [Maven-afhankelijkheden](#maven-afhankelijkheden) laat zien, maar het bevat wel de componenten van derden die in [Componenten van derden](#componenten-van-derden) worden opgesomd. Neem zowel het JAR‑bestand als deze componenten op in uw beveiligingsbeoordeling.

**Heeft Aspose.Slides for Java netwerktoegang nodig?**

Nee. Het maken, opslaan en renderen van presentaties werkt op een systeem zonder enige netwerkverbinding. De enige functie die gegevens naar Aspose verzendt is [metered licensing](/slides/nl/java/metered-licensing/), die API‑gebruik rapporteert.

**Bevat Aspose.Slides for Java native code?**

Nee. Het JAR‑bestand bevat alleen Java‑klassen en resources, dus het voegt geen native libraries toe aan uw applicatie. Op Linux heeft de font‑ondersteuning van de Java‑runtime de `fontconfig`‑bibliotheek en fonts van het besturingssysteem nodig; zie [System Requirements](/slides/nl/java/system-requirements/#linux).