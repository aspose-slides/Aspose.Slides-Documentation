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
description: "Konvertera äldre PPT-filer till PPTX i PHP med Aspose.Slides. Inkluderar PHP-exempel för enskild fil- och batchkonvertering, felhantering och noggrannhetsanmärkningar."
---
## **Översikt**

PPT är det äldre binära PowerPoint‑formatet, medan PPTX är det nyare Open XML‑formatet. Aspose.Slides för PHP via Java kan läsa in en PPT‑fil och spara den som PPTX utan Microsoft PowerPoint. Denna artikel visar hur man konverterar en fil eller en katalog med filer och förklarar vad som ska verifieras efter konverteringen.

## **Konvertera en PPT‑fil till PPTX**

Läs in källfilen med klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/), och anropa sedan [Presentation::save](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#save) med [SaveFormat::Pptx](https://reference.aspose.com/slides/sv/php-java/aspose.slides/saveformat/#Pptx). `finally`‑blocket frigör presentationen och släpper dess resurser.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

// Ladda den äldre PPT-presentationen.
$presentation = new Presentation("presentation.ppt");
try {
    // Spara presentationen i PPTX-format.
    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Filändelsen väljer inte utdataformatet i sig; argumentet [SaveFormat::Pptx](https://reference.aspose.com/slides/sv/php-java/aspose.slides/saveformat/#Pptx) gör det. Håll in- och utdata‑sökvägarna olika om du behöver behålla den ursprungliga PPT‑filen.

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

För produktionsmiljöer, logga hela undantaget, avgör om en befintlig utdatafil får skrivas över och skriv misslyckade filnamn till en återförsök‑ eller granskningskö. Korrupta filer, lösenordsskyddade filer som öppnas utan rätt lösenord, otillgängliga sökvägar och innehåll som inte stöds kan alla orsaka att en konvertering misslyckas. Se [Password-Protected Presentations](/php-java/password-protected-presentation/) för att läsa in krypterade filer.

## **Noggrannhet och äldre funktioner**

Konvertering bevarar normalt bilder, master‑bilder, layouter, text, former, bilder, tabeller och diagram. Däremot representerar inte PPT och PPTX varje funktion på exakt samma sätt. En äldre funktion som saknar motsvarande PPTX‑version eller som inte stöds av biblioteket kan normaliseras, utelämnas eller visas annorlunda.

Granska den konverterade filen när den innehåller animationer, övergångar, inbäddade eller länkade OLE‑objekt, ActiveX‑kontroller, inbäddad media, ovanliga typsnitt eller VBA‑makron. En vanlig PPTX‑fil är inte ett makro‑aktiverat format, så använd ett lämpligt makro‑aktiverat arbetsflöde när VBA måste förbli tillgängligt. Verifiera också att nödvändiga typsnitt och externa resurser finns i den miljö där den konverterade presentationen ska öppnas eller renderas.

För viktiga dokument, öppna den genererade PPTX‑filen programmässigt och inspektera viktiga bildantal och innehåll, jämför sedan dess utseende och bildspelsbeteende i den avsedda visaren. Betrakta inte ett lyckat anrop av [Presentation::save](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#save) som ett bevis på att varje äldre funktion har en exakt PPTX‑representation.

## **När du ska använda PPTX**

Använd PPTX när presentationen ska redigeras i nuvarande versioner av PowerPoint, utbytas med system som arbetar med Open XML‑paket, eller lagras i ett format som är lättare att inspektera och återställa än det äldre binära PPT‑formatet. Behåll den ursprungliga PPT‑filen som ett arkiv‑ eller återställningskopi tills den konverterade presentationen har klarat dina kontroll av noggrannhet.

Om du istället behöver PDF, HTML, bilder, XPS eller någon annan utmatningstyp, använd den format‑specifika vägledningen i [Convert Presentations to Multiple Formats](/php-java/convert-presentation/) i stället för att anta att alla mål bevarar redigerbara PowerPoint‑funktioner.

## **Online‑konverterare**

För enstaka filer eller en snabb jämförelse kan du använda [online PPT till PPTX‑konverterare](https://products.aspose.app/slides/sv/conversion/ppt-to-pptx). För återkommande konverteringar, batch‑behandling eller felhantering på applikationsnivå, använd PHP‑ API‑t.

## **Relaterade artiklar**

- [PPT vs PPTX](/php-java/ppt-vs-pptx/)
- [Spara presentationer i PHP](/php-java/save-presentation/)
- [Stödda filformat](/php-java/supported-file-formats/)
- [Öppna presentationer i PHP](/php-java/open-presentation/)

## **FAQ**

**Kan jag konvertera PPT till PPTX utan att Microsoft PowerPoint är installerat?**

Ja. Aspose.Slides för PHP via Java läser in och sparar presentationsfiler utan att Microsoft PowerPoint krävs.

**Kommer PPT‑till‑PPTX‑konvertering att bevara allt innehåll exakt?**

Den bevarar vanligt presentationsinnehåll, men exakt noggrannhet är inte garanterad för varje äldre eller ej‑stödd funktion. Granska den genererade filen när den innehåller makron, OLE‑ eller ActiveX‑objekt, media, specialiserade animationer eller ovanliga typsnitt.

**Kan jag konvertera en lösenordsskyddad PPT‑fil?**

Ja, om du anger rätt lösenord när filen läses in. Ett saknat eller felaktigt lösenord får inläsningsoperationen att misslyckas.

**Ska jag ta bort PPT‑filen efter konvertering?**

Behåll originalfilen tills du har verifierat PPTX i de visare och arbetsflöden som är viktiga för dig. Detta ger en återställningskopi om en äldre funktion konverteras på ett annat sätt.