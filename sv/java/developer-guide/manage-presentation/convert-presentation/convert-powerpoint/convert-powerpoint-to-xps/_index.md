---
title: Konvertera PowerPoint-presentationer till XPS i Java
linktitle: PowerPoint till XPS
type: docs
weight: 70
url: /sv/java/convert-powerpoint-to-xps/
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
- Java
- Aspose.Slides
description: "Konvertera PowerPoint PPT/PPTX till högkvalitativ, plattformsoberoende XPS i Java med Aspose.Slides. Få en steg‑för‑steg‑guide och exempel på kod."
---
## **Översikt**

Aspose.Slides låter dig konvertera PowerPoint‑presentationer till XPS genom att spara en PPT‑ eller PPTX‑fil i XPS‑formatet. Denna artikel förklarar när XPS‑formatet kan vara användbart och visar hur du utför konverteringen med Aspose.Slides med antingen standardinställningar eller anpassade [XpsOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/xpsoptions/)‑inställningar.

## **Om XPS**
Microsoft utvecklade [XPS](https://docs.fileformat.com/page-description-language/xps/) som ett alternativ till [PDF](https://docs.fileformat.com/pdf/). Det gör att du kan skriva ut innehåll genom att skapa en fil som är mycket lik en PDF. XPS‑formatet baseras på XML. Layouten eller strukturen för en XPS‑fil förblir densamma på alla operativsystem och skrivare. 

## **När du ska använda Microsoft XPS‑format**

{{% alert color="info" %}} 

För att se hur Aspose.Slides konverterar PPT‑ eller PPTX‑presentationer till XPS‑formatet kan du prova [denna kostnadsfria onlinekonverteringsapp](https://products.aspose.app/slides/sv/conversion). 

{{% /alert %}} 

Om du vill minska lagringskostnaderna kan du konvertera din Microsoft PowerPoint‑presentation till XPS‑formatet. På så sätt blir det enklare att spara, dela och skriva ut dina dokument. 

Microsoft fortsätter att implementera starkt stöd för XPS i Windows (även i Windows 10), så du kan överväga att spara filer i detta format. Om du arbetar med Windows 8.1, Windows 8, Windows 7 och Windows Vista kan XPS faktiskt vara det bästa alternativet för vissa operationer. 

- **Windows 8** använder OXPS (Open XPS)‑formatet för XPS‑filer. OXPS är en standardiserad version av det ursprungliga XPS‑formatet. Windows 8 erbjuder bättre stöd för XPS‑filer än för PDF‑filer. 
  - **XPS:** Inbyggd XPS‑visare/‑läsare och utskrift till XPS‑funktion tillgänglig. 
  - **PDF:** PDF‑läsare tillgänglig men ingen utskrift till PDF‑funktion. 

- **Windows 7 och Windows Vista** använder det ursprungliga XPS‑formatet. Dessa operativsystem erbjuder också bättre stöd för XPS‑filer än för PDF‑filer. 
  - **XPS:** Inbyggd XPS‑visare och utskrift till XPS‑funktion tillgänglig. 
  - **PDF:** Ingen PDF‑läsare. Ingen utskrift till PDF‑funktion. 

|<p>**Ingång PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Utdata XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |



Microsoft implementerade så småningom stöd för utskriftsoperationer i PDF genom funktionen Skriv ut till PDF i Windows 10. Tidigare förväntades användare skriva ut dokument via XPS‑formatet. 

## **XPS‑konvertering med Aspose.Slides**

I [**Aspose.Slides**](https://products.aspose.com/slides/sv/java/) för Java kan du använda [**Save**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-)‑metoden som exponeras av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation) för att konvertera hela presentationen till ett XPS‑dokument. 

När du konverterar en presentation till XPS måste du spara presentationen med någon av dessa inställningar:

- Standardinställningar (utan [**XPSOptions**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/xpsoptions))
- Anpassade inställningar (med [**XPSOptions**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/xpsoptions))

### **Konvertera presentationer till XPS med standardinställningar**

Den här exempelkoden i Java visar hur du konverterar en presentation till ett XPS‑dokument med standardinställningar:

```java
import com.aspose.slides.*;

// Instansiera ett Presentation-objekt som representerar en presentationsfil
Presentation pres = new Presentation("Convert_XPS.pptx");
try {
    // Spara presentationen till XPS-dokument
    pres.save("XPS_Output_Without_XPSOption.xps", SaveFormat.Xps);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Konvertera presentationer till XPS med anpassade inställningar**
Den här exempelkoden visar hur du konverterar en presentation till ett XPS‑dokument med anpassade inställningar i Java:

```java
import com.aspose.slides.*;

// Instansiera ett Presentation-objekt som representerar en presentationsfil
Presentation pres = new Presentation("Convert_XPS_Options.pptx");
try {
    // Instansiera XpsOptions-klassen
    XpsOptions options = new XpsOptions();

    // Spara metafiler som PNG
    options.setSaveMetafilesAsPng(true);

    // Spara presentationen till XPS-dokument
    pres.save("XPS_Output_With_Options.xps", SaveFormat.Xps, options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Vanliga frågor**

### Kan jag spara XPS till en ström istället för en fil?

Ja — Aspose.Slides låter dig exportera direkt till en ström, vilket är idealiskt för webb‑API:er, server‑sidspipelines eller alla scenarier där du vill skicka XPS utan att röra filsystemet.

### Överförs dolda bilder till XPS, och kan jag exkludera dem?

Som standard renderas endast vanliga (synliga) bilder. Du kan [inkludera eller exkludera dolda bilder](https://reference.aspose.com/slides/sv/java/com.aspose.slides/xpsoptions/#setShowHiddenSlides-boolean-) via [exportinställningar](https://reference.aspose.com/slides/sv/java/com.aspose.slides/xpsoptions/) innan du sparar till XPS, vilket säkerställer att utdata innehåller exakt de sidor du avser.