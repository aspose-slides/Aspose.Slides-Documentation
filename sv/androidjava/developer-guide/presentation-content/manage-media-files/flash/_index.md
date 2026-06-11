---
title: Extrahera Flash-objekt från presentationer på Android
linktitle: Flash
type: docs
weight: 10
url: /sv/androidjava/flash/
keywords:
- extrahera flash
- flash-objekt
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Lär dig hur du extraherar Flash-objekt från PowerPoint- och OpenDocument-bilder i Java med Aspose.Slides för Android, kompletta kodexempel och bästa praxis."
---
## **Översikt**

Den här artikeln förklarar hur du extraherar Flash-objekt från presentationer med Aspose.Slides. Den visar hur du hittar en Flash-kontroll efter namn i en bilds kontrollsamling och arbetar med de inbäddade SWF-objektdata.

## **Extrahera Flash-objekt från presentationer**

Aspose.Slides för Android via Java erbjuder en funktion för att extrahera flash-objekt från en presentation. Du kan komma åt flash-kontrollen efter namn och extrahera den från presentationen samt lagra SWF-objektdata.

```java
// Instansiera Presentation-klassen som representerar PPTX
Presentation pres = new Presentation();
try {
    IControlCollection controls = pres.getSlides().get_Item(0).getControls();
    Control flashControl = null;
    for (IControl control : controls)
    {
        if (control.getName() == "ShockwaveFlash1")
        {
            flashControl = (Control)control;
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Vilka presentationsformat stöds vid extrahering av Flash-innehåll?**

[Aspose.Slides supports](/slides/sv/androidjava/supported-file-formats/) de viktigaste PowerPoint-formaten såsom PPT och PPTX, eftersom den kan läsa in dessa behållare och komma åt deras kontroller, inklusive Flash-relaterade ActiveX‑element.

**Kan jag konvertera en presentation med Flash till HTML5 och bevara Flash-interaktiviteten?**

Nej. Aspose.Slides kör inte SWF‑innehåll eller konverterar dess interaktivitet. Även om export till [HTML](/slides/sv/androidjava/convert-powerpoint-to-html/)/[HTML5](/slides/sv/androidjava/export-to-html5/) stöds, kommer Flash inte att spelas i moderna webbläsare på grund av att stödet har upphört. Den rekommenderade vägen är att ersätta Flash med alternativ som video eller HTML5‑animationer innan export.

**Ur ett säkerhetsperspektiv, kör Aspose.Slides SWF‑filer när den läser en presentation?**

Nej. Aspose.Slides behandlar Flash som binär data som är inbäddad i filen och kör inte SWF‑innehåll under bearbetning.

**Hur bör jag hantera presentationer som innehåller Flash tillsammans med andra inbäddade filer via OLE?**

Aspose.Slides stöder [extracting embedded OLE objects](/slides/sv/androidjava/manage-ole/), så du kan bearbeta allt relaterat inbäddat innehåll i ett steg, hantera Flash‑kontroller och andra OLE‑inbäddade dokument tillsammans.