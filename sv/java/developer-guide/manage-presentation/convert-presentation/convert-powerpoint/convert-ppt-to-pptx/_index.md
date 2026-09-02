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
description: "Konvertera äldre PPT-filer till PPTX i Java med Aspose.Slides. Inkluderar Java-exempel för enkel-fil- och batch-konvertering, felhantering och noggrannhetsnoteringar."
---
## **Översikt**

PPT är det äldre binära PowerPoint‑formatet, medan PPTX är det nyare Open XML‑formatet. Aspose.Slides for Java kan läsa in en PPT‑fil och spara den som PPTX utan Microsoft PowerPoint. Denna artikel visar hur man konverterar en fil eller en katalog med filer och förklarar vad som bör kontrolleras efter konverteringen.

## **Konvertera en PPT‑fil till PPTX**

Läs in källfilen med klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/) . Anropa sedan [Presentation.save](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#save-java.lang.String-int-) med [SaveFormat.Pptx](https://reference.aspose.com/slides/sv/java/com.aspose.slides/saveformat/#Pptx) . `finally`‑blocket frigör presentationen och dess resurser.

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

Filändelsen väljer inte utdataformatet i sig; det gör argumentet [SaveFormat.Pptx](https://reference.aspose.com/slides/sv/java/com.aspose.slides/saveformat/#Pptx) . Håll in- och utdata‑sökvägarna olika om du behöver behålla den ursprungliga PPT‑filen.

## **Konvertera flera PPT‑filer**

Följande exempel konverterar varje `.ppt`‑fil i en katalog. Varje fil behandlas oberoende, så en misslyckad konvertering stoppar inte resten av batchen.

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

För produktionsarbetsbelastningar, logga hela undantaget, avgör om en befintlig utdatafil får skrivas över och skriv misslyckade filnamn till en återförsök‑ eller granskningskö. Korrupta filer, lösenordsskyddade filer som öppnas utan erforderligt lösenord, otillgängliga sökvägar och innehåll som inte stöds kan alla få en konvertering att misslyckas. Se [Password-Protected Presentations](/slides/sv/java/password-protected-presentation/) för inläsning av krypterade filer.

## **Noggrannhet och äldre funktioner**

Konverteringen bevarar normalt bilder, master‑bilder, layout, text, former, bilder, tabeller och diagram. PPT och PPTX representerar dock inte varje funktion exakt på samma sätt. En äldre funktion som saknar motsvarande i PPTX, eller som inte stöds av biblioteket, kan normaliseras, utelämnas eller visas annorlunda.

Kontrollera den konverterade filen när den innehåller animationer, övergångar, inbäddade eller länkade OLE‑objekt, ActiveX‑kontroller, inbäddade medier, ovanliga typsnitt eller VBA‑makron. En vanlig PPTX‑fil är inte ett makro‑aktiverat format, så använd ett lämpligt makro‑aktiverat arbetsflöde när VBA måste vara tillgängligt. Verifiera också att nödvändiga typsnitt och externa resurser finns i den miljö där den konverterade presentationen ska öppnas eller renderas.

För viktiga dokument, öppna den genererade PPTX‑filen programatiskt och inspektera viktiga bildantal och innehåll, jämför sedan dess utseende och bildspel‑beteende i den avsedda visaren. Anse inte ett lyckat anrop till [Presentation.save](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#save-java.lang.String-int-) som bevis för att varje äldre funktion har en exakt PPTX‑representation.

## **När du ska använda PPTX**

Använd PPTX när presentationen ska redigeras i aktuella PowerPoint‑versioner, utbytas med system som arbetar med Open XML‑paket, eller lagras i ett format som är lättare att inspektera och återställa än det äldre binära PPT‑formatet. Behåll den ursprungliga PPT‑filen som ett arkiv‑ eller återställningskopi tills den konverterade presentationen har klarat dina noggrannhetskontroller.

Om du istället behöver PDF, HTML, bilder, XPS eller någon annan utmatningstyp, använd den format‑specifika vägledningen i [Convert Presentations to Multiple Formats](/slides/sv/java/convert-presentation/) istället för att anta att alla mål bevarar redigerbara PowerPoint‑funktioner.

## **Online‑konverterare**

För enstaka filer eller en snabb jämförelse kan du använda [online PPT to PPTX converter](https://products.aspose.app/slides/sv/conversion/ppt-to-pptx). För återkommande konverteringar, batch‑behandling eller applikations‑nivå felhantering, använd Java‑API‑et.

## **Relaterade artiklar**

- [PPT vs PPTX](/slides/sv/java/ppt-vs-pptx/)
- [Spara presentationer i Java](/slides/sv/java/save-presentation/)
- [Stödda filformat](/slides/sv/java/supported-file-formats/)
- [Öppna presentationer i Java](/slides/sv/java/open-presentation/)

## **FAQ**

**Kan jag konvertera PPT till PPTX utan att Microsoft PowerPoint är installerat?**

Ja. Aspose.Slides for Java läser in och sparar presentationsfiler utan att kräva Microsoft PowerPoint.

**Kommer PPT‑till‑PPTX‑konverteringen att bevara allt innehåll exakt?**

Den bevarar vanligt presentationsinnehåll, men exakt noggrannhet garanteras inte för varje äldre eller ej‑stödd funktion. Granska den genererade filen när den innehåller makron, OLE‑ eller ActiveX‑objekt, media, specialiserade animationer eller ovanliga typsnitt.

**Kan jag konvertera en lösenordsskyddad PPT‑fil?**

Ja, om du anger rätt lösenord när filen läses in. Ett saknat eller felaktigt lösenord får inläsningsoperationen att misslyckas.

**Ska jag ta bort PPT‑filen efter konvertering?**

Behåll originalet tills du har verifierat PPTX i de visare och arbetsflöden som är viktiga för dig. Detta ger en återställningskopia om en äldre funktion konverteras annorlunda.