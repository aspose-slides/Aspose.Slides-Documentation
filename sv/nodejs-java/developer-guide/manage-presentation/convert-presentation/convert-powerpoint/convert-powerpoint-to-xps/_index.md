---
title: Konvertera PowerPoint-presentationer till XPS i JavaScript
linktitle: PowerPoint till XPS
type: docs
weight: 70
url: /sv/nodejs-java/convert-powerpoint-to-xps/
keywords:
- konvertera PowerPoint
- konvertera presentation
- konvertera bild
- konvertera PPT
- konvertera PPTX
- PowerPoint till XPS
- presentation till XPS
- bild till XPS
- PPT till XPS
- PPTX till XPS
- spara PPT som XPS
- spara PPTX som XPS
- exportera PPT till XPS
- exportera PPTX till XPS
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Konvertera PowerPoint PPT/PPTX till högkvalitativ, plattformsoberoende XPS i JavaScript med Aspose.Slides för Node.js. Få en steg-för-steg-guide och exempelkod."
---
## **Översikt**

Aspose.Slides låter dig konvertera PowerPoint-presentationer till XPS genom att spara en PPT- eller PPTX-fil i XPS-formatet. Denna artikel förklarar när XPS-formatet kan vara användbart och visar hur du utför konverteringen med Aspose.Slides med antingen standardinställningar eller anpassade [XpsOptions]‑inställningar.

## **Om XPS**

Microsoft utvecklade [XPS](https://docs.fileformat.com/page-description-language/xps/) som ett alternativ till [PDF](https://docs.fileformat.com/pdf/). Det låter dig skriva ut innehåll genom att producera en fil som är mycket lik en PDF. XPS-formatet är baserat på XML. Layouten eller strukturen för en XPS-fil förblir densamma på alla operativsystem och skrivare.

## **När du bör använda Microsoft XPS-format**

{{% alert color="primary" %}} 

För att se hur Aspose.Slides konverterar PPT‑ eller PPTX‑presentation till XPS‑formatet kan du prova [denna gratis onlinekonverteringsapp](https://products.aspose.app/slides/sv/conversion). 

{{% /alert %}} 

Om du vill minska lagringskostnaderna kan du konvertera din Microsoft PowerPoint-presentation till XPS-formatet. På så sätt blir det enklare att spara, dela och skriva ut dina dokument. 

Microsoft fortsätter att implementera starkt stöd för XPS i Windows (även i Windows 10), så du kanske vill överväga att spara filer i detta format. Om du arbetar med Windows 8.1, Windows 8, Windows 7 och Windows Vista kan XPS faktiskt vara det bästa alternativet för vissa operationer. 

- **Windows 8** använder OXPS (Open XPS)-formatet för XPS‑filer. OXPS är en standardiserad version av det ursprungliga XPS-formatet. Windows 8 erbjuder bättre support för XPS‑filer än för PDF‑filer. 
  - **XPS:** Inbyggd XPS‑visare/läsare och utskriftsfunktion till XPS finns tillgänglig. 
  - **PDF:** PDF‑läsare finns men ingen utskriftsfunktion till PDF. 

- **Windows 7 och Windows Vista** använder det ursprungliga XPS‑formatet. Dessa operativsystem erbjuder också bättre stöd för XPS‑filer än för PDF‑filer. 
  - **XPS:** Inbyggd XPS‑visare och utskriftsfunktion till XPS finns tillgänglig. 
  - **PDF:** Ingen PDF‑läsare. Ingen utskriftsfunktion till PDF. 

|<p>**Inmatning PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Utdata XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft införde så småningom stöd för utskriftsoperationer i PDF via funktionen Skriv ut till PDF i Windows 10. Tidigare förväntades användare skriva ut dokument via XPS‑formatet. 

## **XPS‑konvertering med Aspose.Slides**

I **Aspose.Slides for Node.js via Java** kan du använda metoden [**save**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) som exponeras av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation) för att konvertera hela presentationen till ett XPS‑dokument.

När du konverterar en presentation till XPS måste du spara presentationen med någon av följande inställningar:

- Standardinställningar (utan [**XPSOptions**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/xpsoptions))
- Anpassade inställningar (med [**XPSOptions**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/xpsoptions))

### **Konvertera presentationer till XPS med standardinställningar**

Denna exempel­kod i JavaScript visar hur du konverterar en presentation till ett XPS‑dokument med standardinställningar:

```javascript
// Instansiera ett Presentation-objekt som representerar en presentationsfil
var pres = new aspose.slides.Presentation("Convert_XPS.pptx");
try {
    // Sparar presentationen till XPS-dokument
    pres.save("XPS_Output_Without_XPSOption.xps", aspose.slides.SaveFormat.Xps);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Konvertera presentationer till XPS med anpassade inställningar**

Denna exempel­kod visar hur du konverterar en presentation till ett XPS‑dokument med anpassade inställningar i JavaScript:

```javascript
// Instansiera ett Presentation-objekt som representerar en presentationsfil
var pres = new aspose.slides.Presentation("Convert_XPS_Options.pptx");
try {
    // Instansiera TiffOptions-klassen
    var options = new aspose.slides.XpsOptions();
    // Spara MetaFiles som PNG
    options.setSaveMetafilesAsPng(true);
    // Spara presentationen till XPS-dokument
    pres.save("XPS_Output_With_Options.xps", aspose.slides.SaveFormat.Xps, options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Vanliga frågor**

**Kan jag spara till XPS i en ström istället för en fil?**

Ja—Aspose.Slides låter dig exportera direkt till en ström, vilket är idealiskt för webb‑API:er, server‑sidiga pipelines eller någon situation där du vill skicka XPS utan att röra filsystemet.

**Överförs dolda bilder till XPS, och kan jag exkludera dem?**

Som standard renderas endast vanliga (synliga) bilder. Du kan [include or exclude hidden slides](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/xpsoptions/setshowhiddenslides/) via [export settings](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/xpsoptions/) innan du sparar till XPS, vilket säkerställer att utdata innehåller exakt de sidor du avser.