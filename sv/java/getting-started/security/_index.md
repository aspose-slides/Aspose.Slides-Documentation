---
title: Säkerhet
type: docs
weight: 160
url: /sv/java/security/
keywords:
- säkerhet
- beroenden
- tredjepartskomponenter
- Maven
- JAR-signatur
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Granska hur Aspose.Slides för Java bearbetar presentationer, vad det lägger till i ditt projekts beroenden, hur du verifierar JAR-filen och vilka tredjepartskomponenter det innehåller."
---
## **Introduktion**

Denna artikel samlar den information som en säkerhetsgranskning av en applikation som använder Aspose.Slides för Java vanligtvis behöver: hur biblioteket behandlar presentationer, vad det lägger till i ditt projekts beroenden, hur du kontrollerar att JAR‑filen kommer från Aspose, och vilka tredjepartskomponenter JAR‑filen innehåller.

## **Säkerhet i Aspose.Slides**

* Aspose.Slides för Java används för att skapa, modifiera och konvertera presentationer. Den kör inte skript i presentationer. Aspose.Slides analyserar presentationsstrukturen och låter din kod arbeta med objektmodellen.
* Aspose.Slides fungerar som ett bibliotek som analyserar och tolkar dokument utan att exekvera fjärrkod. Alla Aspose‑produkter körs på dina maskiner. De överför ingen data till Aspose. Det enda undantaget är [metered licensing](/slides/sv/java/metered-licensing/): om du använder den bearbetas endast information om ditt API‑användande.
* Aspose‑komponenter körs i samma användarkontext som vanliga applikationer. Därför utgör Aspose‑komponenter ingen risk för kritiska systemresurser. Dessutom körs makron inte automatiskt när en Aspose‑komponent öppnar ett dokument.

## **Maven‑beroenden**

Maven‑artefakten för Aspose.Slides för Java, `com.aspose:aspose-slides`, deklarerar inga beroenden: dess POM‑fil innehåller endast artefaktens egna koordinater. När du lägger till den i ett projekt lägger Maven till endast denna JAR‑fil och inget annat. För att lista varje artefakt som ditt projekt löser, inklusive transitiva beroenden, kör detta kommando i projektmappen:

```bash
mvn dependency:tree
```

I projektet från [Installation](/slides/sv/java/installation/), visar utskriften Aspose.Slides som det enda beroendet:

```text
[INFO] com.example:hello-slides:jar:1.0
[INFO] \- com.aspose:aspose-slides:jar:jdk16:26.9:compile
```

## **Verifiera JAR‑filen**

Aspose signerar JAR‑filen. För att kontrollera signaturen, kör verktyget `jarsigner` från JDK i den mapp som innehåller JAR‑filen:

```bash
jarsigner -verify aspose-slides-26.9-jdk16.jar
```

Kommandot skriver ut `jar verified.` när signaturen är giltig och ingen post har förändrats sedan filen signerades. Detta meddelande namnger inte signatören. För att bekräfta att Aspose signerade filen, lägg till flaggorna `-verbose` och `-certs` och kontrollera att signatarens certifikat är utfärdat till `CN=ASPOSE PTY LTD`. När Maven hämtar JAR‑filen kontrollerar den även SHA‑1‑kontrollsumman som lagringsplatsen publicerar bredvid filen.

## **Tredjepartskomponenter**

Aspose.Slides för Java innehåller kod och data från tredjepartskomponenter. De är en del av JAR‑filen, inte separata Maven‑artefakter, så `mvn dependency:tree` och andra verktyg som läser Maven‑beroenden listar dem inte. JAR‑filen innehåller notisen *META-INF/ThirdPartyLicenses-Aspose.Slides for Java.pdf*, som listar komponenterna och deras licenser:

| Komponent | Licens enligt notisen |
|---|---|
| DotNetZip | Microsoft Public License (Ms-PL) |
| Bouncy Castle | MIT-style license |
| Mono | MIT license; some parts under other licenses that the notice lists |
| RSWOP.ICM color profile | Microsoft license terms |
| sRGB_v4_ICC_preference.icc color profile | ICC permission to use, copy, and distribute the unchanged file |
| Apache | Apache License 2.0 |
| ANTLR | BSD License |
| sfntly | Apache License 2.0 |

För att extrahera notisen från JAR‑filen, kör verktyget `jar` från JDK i den mapp som innehåller JAR‑filen:

```bash
jar xf aspose-slides-26.9-jdk16.jar "META-INF/ThirdPartyLicenses-Aspose.Slides for Java.pdf"
```

## **FAQ**

**Använder Aspose.Slides för Java externa paket?**

Det har inga Maven‑beroenden, som [Maven Dependencies](#maven-dependencies) visar, men det inkluderar tredjepartskomponenterna som listas i [Third-Party Components](#third-party-components). Inkludera både JAR‑filen och dessa komponenter i din säkerhetsgranskning.

**Behöver Aspose.Slides för Java nätverksåtkomst?**

Nej. Att skapa, spara och rendera presentationer fungerar på ett system utan någon nätverksanslutning. Den enda funktionen som skickar data till Aspose är [metered licensing](/slides/sv/java/metered-licensing/), som rapporterar API‑användning.

**Innehåller Aspose.Slides för Java native‑kod?**

Nej. JAR‑filen innehåller endast Java‑klasser och resurser, så den lägger inte till några native‑bibliotek i din applikation. På Linux kräver Java‑runtime's teckensnittsstöd fontconfig‑biblioteket och teckensnitt från operativsystemet; se [System Requirements](/slides/sv/java/system-requirements/#linux).