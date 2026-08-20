---
title: Konvertera PPT till PPTX i Java
linktitle: PPT till PPTX
type: docs
weight: 20
url: /sv/java/convert-ppt-to-pptx/
keywords:
- konvertera PowerPoint
- konvertera presentation
- konvertera bild
- konvertera PPT
- PPT till PPTX
- spara PPT som PPTX
- exportera PPT till PPTX
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Konvertera äldre PPT-filer till PPTX i Java med Aspose.Slides. Inkluderar Java-exempel för enskild fil- och batch-konvertering, felhantering och noggrannhetsanteckningar."
---
## **Översikt**

PPT är det äldre binära PowerPoint‑formatet, medan PPTX är det nyare Open XML‑formatet. Aspose.Slides for Java kan läsa in en PPT‑fil och spara den som PPTX utan Microsoft PowerPoint. Den här artikeln visar hur du konverterar en fil eller en katalog med filer och förklarar vad du bör verifiera efter konverteringen.

## **Konvertera en PPT‑fil till PPTX**

Läs in källfilen med klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/), anropa sedan [Presentation.save](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#save-java.lang.String-int-) med [SaveFormat.Pptx](https://reference.aspose.com/slides/sv/java/com.aspose.slides/saveformat/#Pptx). `finally`‑blocket frigör presentationen och dess resurser.

```java
// Läs in den äldre PPT-presentationen.
com.aspose.slides.Presentation presentation = new com.aspose.slides.Presentation("presentation.ppt");
try {
    // Spara presentationen i PPTX-format.
    presentation.save("presentation.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Filändelsen väljer inte utdataformatet i sig; det gör argumentet [SaveFormat.Pptx](https://reference.aspose.com/slides/sv/java/com.aspose.slides/saveformat/#Pptx). Se till att in‑ och utdata­vägarna är olika om du behöver behålla den ursprungliga PPT‑filen.

## **Konvertera flera PPT‑filer**

Följande exempel konverterar alla `.ppt`‑filer i en katalog. Varje fil behandlas oberoende, så en misslyckad konvertering stoppar inte resten av batchen.

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

För produktionsarbetsbelastningar, logga hela undantaget, avgör om en befintlig utdatafil får skrivas över och skriv misslyckade filnamn till en återförsöks‑ eller granskningskö. Korrupta filer, lösenordsskyddade filer som öppnas utan rätt lösenord, otillgängliga sökvägar och innehåll som inte stöds kan alla leda till att en konvertering misslyckas. Se [Lösenordsskyddade presentationer](/java/password-protected-presentation/) för att läsa in krypterade filer.

## **Noggrannhet och äldre funktioner**

Konverteringen bevarar normalt bilder, master‑bilder, layouter, text, former, bilder, tabeller och diagram. Dock representerar inte PPT och PPTX varje funktion på exakt samma sätt. En äldre funktion som saknar motsvarande PPTX‑element, eller som inte stöds av biblioteket, kan normaliseras, utelämnas eller visas på ett annat sätt.

Granska den konverterade filen när den innehåller animationer, övergångar, inbäddade eller länkade OLE‑objekt, ActiveX‑kontroller, inbäddade media, ovanliga teckensnitt eller VBA‑makron. En vanlig PPTX‑fil är inte ett makro‑aktiverat format, så använd ett lämpligt makro‑aktiverat arbetsflöde när VBA måste vara tillgängligt. Verifiera också att nödvändiga teckensnitt och externa resurser finns i den miljö där den konverterade presentationen ska öppnas eller renderas.

För viktiga dokument, öppna den genererade PPTX‑filen programmässigt igen och inspektera viktiga bildantal och innehåll, jämför sedan dess utseende och bildspelsbeteende i den avsedda visaren. Behandla inte ett lyckat anrop av [Presentation.save](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#save-java.lang.String-int-) som bevis på att varje äldre funktion har en exakt PPTX‑representation.

## **När du ska använda PPTX**

Använd PPTX när presentationen ska redigeras i aktuella versioner av PowerPoint, utbytas med system som arbetar med Open XML‑paket eller lagras i ett format som är lättare att inspektera och återställa än det äldre binära PPT‑formatet. Behåll den ursprungliga PPT‑filen som ett arkiv‑ eller återställningskopi tills den konverterade presentationen har klarat dina noggrannhetskontroller.

Om du i stället behöver PDF, HTML, bilder, XPS eller en annan utdata­typ, använd den format‑specifika vägledningen i [Konvertera presentationer till flera format](/java/convert-presentation/) istället för att anta att alla mål bevarar redigerbara PowerPoint‑funktioner.

## **Online‑konverterare**

För en enstaka fil eller en snabb jämförelse kan du använda [online PPT‑till‑PPTX‑konverterare](https://products.aspose.app/slides/sv/conversion/ppt-to-pptx). För återkommande konverteringar, batch‑behandling eller felhantering på applikationsnivå, använd Java‑API:et.

## **Relaterade artiklar**

- [PPT vs PPTX](/java/ppt-vs-pptx/)
- [Spara presentationer i Java](/java/save-presentation/)
- [Stödda filformat](/java/supported-file-formats/)
- [Öppna presentationer i Java](/java/open-presentation/)

## **FAQ**

**Kan jag konvertera PPT till PPTX utan att Microsoft PowerPoint är installerat?**

Ja. Aspose.Slides for Java läser in och sparar presentationsfiler utan att kräva Microsoft PowerPoint.

**Kommer PPT‑till‑PPTX‑konverteringen att bevara allt innehåll exakt?**

Den bevarar vanligt presentationsinnehåll, men exakt noggrannhet garanteras inte för varje äldre eller ej‑stött funktion. Granska den genererade filen när den innehåller makron, OLE‑ eller ActiveX‑objekt, media, specialiserade animationer eller ovanliga teckensnitt.

**Kan jag konvertera en lösenordsskyddad PPT‑fil?**

Ja, om du anger rätt lösenord när du läser in filen. Ett saknat eller felaktigt lösenord får inläsningsoperationen att misslyckas.

**Bör jag ta bort PPT‑filen efter konverteringen?**

Behåll originalet tills du har verifierat PPTX‑filen i de visare och arbetsflöden som är viktiga för dig. Detta ger en återställningskopia om en äldre funktion konverteras på ett annat sätt.