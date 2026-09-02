---
title: Konvertera PPT till PPTX i PHP
linktitle: PPT till PPTX
type: docs
weight: 20
url: /sv/php-java/convert-ppt-to-pptx/
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
- PHP
- Aspose.Slides
description: "Konvertera äldre PPT-filer till PPTX i PHP med Aspose.Slides. Innehåller PHP-exempel för enkel- och batchkonvertering, felhantering och noggrannhetsanteckningar."
---
## **Översikt**

PPT är det äldre binära PowerPoint‑formatet, medan PPTX är det nyare Open XML‑formatet. Aspose.Slides för PHP via Java kan läsa in en PPT‑fil och spara den som PPTX utan Microsoft PowerPoint. Denna artikel visar hur man konverterar en fil eller en katalog med filer och förklarar vad som ska verifieras efter konvertering.

## **Konvertera en PPT‑fil till PPTX**

Läs in källfilen med klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/) , anropa sedan [Presentation::save](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#save) med [SaveFormat::Pptx](https://reference.aspose.com/slides/sv/php-java/aspose.slides/saveformat/#Pptx) . `finally`‑blocket frigör presentationen och släpper dess resurser.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

// Läs in den äldre PPT-presentationen.
$presentation = new Presentation("presentation.ppt");
try {
    // Spara presentationen i PPTX-format.
    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Filändelsen väljer inte utdataformatet i sig; argumentet [SaveFormat::Pptx](https://reference.aspose.com/slides/sv/php-java/aspose.slides/saveformat/#Pptx) gör det. Håll in‑ och utdata‑sökvägarna olika om du måste behålla den ursprungliga PPT‑filen.

## **Konvertera flera PPT‑filer**

Följande exempel konverterar varje `.ppt`‑fil i en katalog. Varje fil behandlas oberoende, så en misslyckad konvertering stoppar inte resten av batchen.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputDirectory = "input";
$outputDirectory = "output";
if (!is_dir($outputDirectory) && !mkdir($outputDirectory, 0777, true)) {
    throw new RuntimeException("Cannot create the output directory: " . $outputDirectory);
}

$inputFiles = [];
foreach (new DirectoryIterator($inputDirectory) as $fileInfo) {
    if ($fileInfo->isFile() && strtolower($fileInfo->getExtension()) === "ppt") {
        $inputFiles[] = $fileInfo->getPathname();
    }
}

foreach ($inputFiles as $inputPath) {
    $outputFileName = pathinfo($inputPath, PATHINFO_FILENAME) . ".pptx";
    $outputPath = $outputDirectory . DIRECTORY_SEPARATOR . $outputFileName;
    $presentation = null;

    try {
        $presentation = new Presentation($inputPath);
        $presentation->save($outputPath, SaveFormat::Pptx);
        echo "Converted: " . $inputPath . PHP_EOL;
    } catch (Throwable $exception) {
        fwrite(STDERR, "Failed: " . $inputPath . " (" . $exception->getMessage() . ")" . PHP_EOL);
    } finally {
        if ($presentation !== null) {
            $presentation->dispose();
        }
    }
}
```

För produktionsarbetsbelastningar, logga hela undantaget, avgör om en befintlig utdatafil får skrivas över och skriv misslyckade filnamn till en återförsök‑ eller granskningskö. Korrupta filer, lösenordsskyddade filer som öppnas utan korrekt lösenord, otillgängliga sökvägar och innehåll som inte stöds kan alla orsaka att konverteringen misslyckas. Se [Password-Protected Presentations](/slides/sv/php-java/password-protected-presentation/) för att läsa in krypterade filer.

## **Noggrannhet och äldre funktioner**

Konverteringen bevarar normalt bilder, master‑bilder, layout, text, former, bilder, tabeller och diagram. Dock representerar inte PPT och PPTX varje funktion på exakt samma sätt. En äldre funktion som saknar motsvarande PPTX‑element, eller som inte stöds av biblioteket, kan normaliseras, uteslutas eller visas på ett annat sätt.

Granska den konverterade filen när den innehåller animationer, övergångar, inbäddade eller länkade OLE‑objekt, ActiveX‑kontroller, inbäddade media, ovanliga teckensnitt eller VBA‑makron. En vanlig PPTX‑fil är inte ett makro‑aktiverat format, så använd ett lämpligt makro‑aktiverat arbetsflöde när VBA måste vara tillgängligt. Verifiera också att nödvändiga teckensnitt och externa resurser finns i den miljö där den konverterade presentationen kommer att öppnas eller renderas.

För viktiga dokument, öppna den genererade PPTX‑filen programmatic och inspektera viktiga bildantal och innehåll, jämför sedan dess utseende och bildspelsbeteende i den avsedda visaren. Betrakta inte ett lyckat anrop av [Presentation::save](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#save) som bevis för att varje äldre funktion har en exakt PPTX‑representation.

## **När man ska använda PPTX**

Använd PPTX när presentationen ska redigeras i aktuella PowerPoint‑versioner, utbytas med system som arbetar med Open XML‑paket, eller lagras i ett format som är lättare att inspektera och återställa än det äldre binära PPT‑formatet. Behåll den ursprungliga PPT‑filen som en arkiv‑ eller återställningskopia tills den konverterade presentationen har klarat dina noggrannhetskontroller.

Om du istället behöver PDF, HTML, bilder, XPS eller någon annan utmatningstyp, använd den format‑specifika vägledningen i [Convert Presentations to Multiple Formats](/slides/sv/php-java/convert-presentation/) istället för att anta att alla mål bevarar redigerbara PowerPoint‑funktioner.

## **Online‑konverterare**

För en enstaka fil eller en snabb jämförelse kan du använda [online PPT to PPTX converter](https://products.aspose.app/slides/sv/conversion/ppt-to-pptx). För återkommande konverteringar, batch‑behandling eller felhantering på applikationsnivå, använd PHP‑API‑et.

## **Relaterade artiklar**

- [PPT vs PPTX](/slides/sv/php-java/ppt-vs-pptx/)
- [Spara presentationer i PHP](/slides/sv/php-java/save-presentation/)
- [Filformat som stöds](/slides/sv/php-java/supported-file-formats/)
- [Öppna presentationer i PHP](/slides/sv/php-java/open-presentation/)

## **FAQ**

**Kan jag konvertera PPT till PPTX utan att ha Microsoft PowerPoint installerat?**

Ja. Aspose.Slides för PHP via Java läser in och sparar presentationsfiler utan att kräva Microsoft PowerPoint.

**Kommer PPT‑till‑PPTX‑konverteringen att bevara allt innehåll exakt?**

Den bevarar vanligt presentationsinnehåll, men exakt noggrannhet är inte garanterad för varje äldre eller ej stödjande funktion. Granska den genererade filen när den innehåller makron, OLE‑ eller ActiveX‑objekt, media, specialiserade animationer eller ovanliga teckensnitt.

**Kan jag konvertera en lösenordsskyddad PPT‑fil?**

Ja, om du anger rätt lösenord när du läser in filen. Ett saknat eller felaktigt lösenord får inläsningsoperationen att misslyckas.

**Bör jag ta bort PPT‑filen efter konvertering?**

Behåll den ursprungliga filen tills du har verifierat PPTX i de visare och arbetsflöden som är viktiga för dig. Detta ger en återställningskopia om en äldre funktion konverteras annorlunda.