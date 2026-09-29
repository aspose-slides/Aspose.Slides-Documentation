---
title: Kom igång
type: docs
weight: 10
url: /sv/java/getting-started/
keywords:
- kom igång
- systemkrav
- installation
- första presentation
- Maven
- PPT-behandling
- PPTX-behandling
- ODP-behandling
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Vägen från ett nytt Java-projekt till en först sparad presentation med Aspose.Slides: kontrollera kraven, lägg till biblioteket från Asposes Maven-arkiv, kör ett första program och fortsätt med vanliga uppgifter."
---
## **Översikt**

Arbeta igenom de fyra stegen nedan i ordning. Varje steg anger vad som ska göras och länkar till artikeln med detaljerna. Utvärdering, licensiering och support behandlas efter stegen.

## **Steg 1: Kontrollera systemkraven**

Aspose.Slides för Java är en enda JAR-fil utan inbyggd kod, så den körs på alla operativsystem som har en stödjande Java-runtime. [System Requirements](/slides/sv/java/system-requirements/) listar de stödjande operativsystemen och Java-versionerna. Projektet och kommandona i nästa steg kräver JDK 11 eller senare och, för Maven‑vägen, [Apache Maven](https://maven.apache.org/install.html).

## **Steg 2: Lägg till biblioteket i ditt projekt**

Aspose.Slides för Java publiceras i Asposes eget Maven‑arkiv, inte i Maven Central. Välj ett av dessa alternativ:

- Med Maven: deklarera arkivet `https://releases.aspose.com/java/repo/` i din *pom.xml* och lägg till beroendet `com.aspose:aspose-slides` med `jdk16`‑klassificeraren.
- Utan Maven: ladda ner JAR‑filen vars namn slutar på *-jdk16.jar* från arkivet och placera den på klassvägen.

På Linux, installera även fontconfig‑biblioteket och minst ett teckensnitt. Utan dem misslyckas sparandet av en presentation med felet "Fontconfig head is null, check your fonts or fonts configuration".

[Installation](/slides/sv/java/installation/) innehåller *pom.xml*-posterna, JAR‑nedladdningen och Linux‑kommandot.

## **Steg 3: Skapa din första presentation**

Den [snabba starten på Aspose.Slides för Java‑hemsidan](/slides/sv/java/#your-first-presentation) är ett komplett Maven‑projekt: en *pom.xml*-fil och ett program som lägger till en molnform med text på en bild och sparar presentationen som en PPTX‑fil. Du kör det med `mvn compile exec:java`. [Create Presentations](/slides/sv/java/create-presentation/) förklarar samma program steg för steg. För att öppna en befintlig presentation och spara den i ett annat format, se [Open Presentations](/slides/sv/java/open-presentation/) och [Save Presentations](/slides/sv/java/save-presentation/).

## **Steg 4: Fortsätt med vanliga uppgifter**

- [Öppna en presentation](/slides/sv/java/open-presentation/)
- [Spara en presentation](/slides/sv/java/save-presentation/)
- [Konvertera en presentation till PDF](/slides/sv/java/convert-powerpoint-to-pdf/)
- [Rendera bildspel som bilder](/slides/sv/java/convert-slide/)
- [Redigera presentationstext](/slides/sv/java/manage-text/)
- [Exempel per bildspelselement](/slides/sv/java/examples/)

## **Utvärdera och licensiera**

Utan en licens körs Aspose.Slides i utvärderingsläge: den lägger till ett vattenstämpel på varje bild den sparar och trunkerar text som din kod läser från presentationer.

- [Evaluate Aspose.Slides](/slides/sv/java/evaluate-aspose-slides/) beskriver utvärderingsbegränsningarna och hur du begär en tillfällig licens.
- [Licensing](/slides/sv/java/licensing/) visar hur du tillämpar en licens från en fil eller en ström.
- [Metered Licensing](/slides/sv/java/metered-licensing/) behandlar licensiering som faktureras per användning.
- [Supported File Formats](/slides/sv/java/supported-file-formats/) listar de format som Aspose.Slides kan läsa och spara.

## **Få hjälp**

[Technical Support](/slides/sv/java/technical-support/) förklarar hur du ställer en fråga på [gratis supportforum](https://forum.aspose.com/c/slides/sv/11) och vad du ska inkludera när du rapporterar ett problem.

## **FAQ**

**Behöver jag Microsoft PowerPoint installerat?**

Nej. Aspose.Slides läser och skriver presentationsfiler själv och använder inte PowerPoint, så den kan även köras på servrar och på Linux.

**Varför hittar inte Maven Aspose.Slides för Java?**

Biblioteket finns inte i Maven Central. Deklarera Asposes arkiv i din *pom.xml*, som visas i [Installation](/slides/sv/java/installation/), och Maven hämtar biblioteket därifrån.

**Betyder `jdk16`‑klassificeraren att biblioteket behöver Java 16?**

Nej. Klassificeraren väljer Java SE‑byggnaden av biblioteket; den andra byggnaden är för Android. Samma byggnad körs på aktuella JDK:er, såsom JDK 21.