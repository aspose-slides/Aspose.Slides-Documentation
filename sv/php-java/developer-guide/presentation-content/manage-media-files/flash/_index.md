---
title: Extrahera Flash-objekt från presentationer i PHP
linktitle: Flash
type: docs
weight: 10
url: /sv/php-java/flash/
keywords:
- extrahera flash
- flash-objekt
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Lär dig hur du extraherar Flash-objekt från PowerPoint- och OpenDocument-bilder med Aspose.Slides för PHP via Java, kompletta kodexempel och bästa praxis."
---
## **Översikt**

Denna artikel förklarar hur man extraherar Flash-objekt från presentationer med Aspose.Slides. Den visar hur man hittar en Flash‑kontroll efter namn i en bilds kontrollsamling och arbetar med de inbäddade SWF‑objektdatan.

## **Extrahera Flash-objekt från presentationer**

Aspose.Slides för PHP via Java tillhandahåller en funktion för att extrahera flash-objekt från en presentation. Du kan komma åt flash‑kontrollen efter namn och extrahera den från presentationen samt lagra SWF‑objektdatan.

```php
  # Instansiera Presentation-klassen som representerar PPTX
  $pres = new Presentation();
  try {
    $controls = $pres->getSlides()->get_Item(0)->getControls();
    $flashControl = null;
    foreach($controls as $control) {
      if (java_values($control->getName()) == "ShockwaveFlash1") {
        $flashControl = $control;
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Vilka presentationsformat stöds när flash-innehåll extraheras?**

[Aspose.Slides stöder](/slides/sv/php-java/supported-file-formats/) de huvudsakliga PowerPoint-formaten såsom PPT och PPTX, eftersom den kan läsa in dessa behållare och komma åt deras kontroller, inklusive Flash-relaterade ActiveX-element.

**Kan jag konvertera en presentation med Flash till HTML5 och bevara Flash-interaktiviteten?**

Nej. Aspose.Slides kör inte SWF‑innehåll eller konverterar dess interaktivitet. Även om export till [HTML](/slides/sv/php-java/convert-powerpoint-to-html/)/[HTML5](/slides/sv/php-java/export-to-html5/) stöds, kommer Flash inte att spelas upp i moderna webbläsare på grund av att stödet har upphört. Det rekommenderade är att ersätta Flash med alternativ som video eller HTML5‑animationer innan export.

**Ur ett säkerhetsperspektiv, kör Aspose.Slides SWF-filer när den läser en presentation?**

Nej. Aspose.Slides behandlar Flash som binär data som är inbäddad i filen och kör inte SWF‑innehåll under bearbetning.

**Hur ska jag hantera presentationer som innehåller Flash tillsammans med andra inbäddade filer via OLE?**

Aspose.Slides stöder [extrahering av inbäddade OLE-objekt](/slides/sv/php-java/manage-ole/), så du kan bearbeta allt relaterat inbäddat innehåll i ett steg, hantera Flash‑kontroller och andra OLE‑inbäddade dokument tillsammans.