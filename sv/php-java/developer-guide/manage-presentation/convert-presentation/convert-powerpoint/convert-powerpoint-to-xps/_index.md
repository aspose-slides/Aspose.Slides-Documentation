---
title: Konvertera PowerPoint-presentationer till XPS i PHP
linktitle: PowerPoint till XPS
type: docs
weight: 70
url: /sv/php-java/convert-powerpoint-to-xps/
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
- PHP
- Aspose.Slides
description: "Konvertera PowerPoint PPT/PPTX till högkvalitativ, plattformsoberoende XPS med Aspose.Slides för PHP via Java. Få en steg-för-steg-guide och exempel på kod."
---
## **Översikt**

Aspose.Slides låter dig konvertera PowerPoint-presentationer till XPS genom att spara en PPT- eller PPTX-fil i XPS-formatet. Den här artikeln förklarar när XPS-formatet kan vara användbart och visar hur du utför konverteringen med Aspose.Slides med antingen standardinställningar eller anpassade [XpsOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/xpsoptions/) inställningar.

## **Om XPS**
Microsoft utvecklade [XPS](https://docs.fileformat.com/page-description-language/xps/) som ett alternativ till [PDF](https://docs.fileformat.com/pdf/).  Det låter dig skriva ut innehåll genom att skapa en fil som är mycket lik en PDF. XPS-formatet är baserat på XML. Layouten eller strukturen för en XPS-fil förblir densamma på alla operativsystem och skrivare. 

## **När du bör använda Microsoft XPS-format**

{{% alert color="primary" %}} 

För att se hur Aspose.Slides konverterar PPT- eller PPTX-presentation till XPS-formatet kan du prova [denna gratis online‑konverteringsapp](https://products.aspose.app/slides/sv/conversion). 

{{% /alert %}} 

Om du vill minska lagringskostnaderna kan du konvertera din Microsoft PowerPoint-presentation till XPS-formatet. På så sätt blir det enklare att spara, dela och skriva ut dina dokument. 

Microsoft fortsätter att erbjuda starkt stöd för XPS i Windows (även i Windows 10), så du kanske vill överväga att spara filer i detta format. Om du arbetar med Windows 8.1, Windows 8, Windows 7 och Windows Vista kan XPS faktiskt vara ditt bästa alternativ för vissa operationer. 

- **Windows 8** använder OXPS (Open XPS)-formatet för XPS‑filer. OXPS är en standardiserad version av det ursprungliga XPS-formatet. Windows 8 ger bättre stöd för XPS‑filer än för PDF‑filer. 
  - **XPS:** Inbyggd XPS‑visare/läsare och utskrift till XPS‑funktion tillgänglig. 
  - **PDF:** PDF‑läsare finns men ingen utskriftsfunktion till PDF. 

- **Windows 7 och Windows Vista** använder det ursprungliga XPS‑formatet. Dessa operativsystem ger också bättre stöd för XPS‑filer än för PDF‑filer. 
  - **XPS:** Inbyggd XPS‑visare och utskrift till XPS‑funktion tillgänglig. 
  - **PDF:** Ingen PDF‑läsare. Ingen utskriftsfunktion till PDF. 

|<p>**Ingående PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Utdata XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft införde så småningom stöd för utskriftsoperationer i PDF via funktionen Skriv ut till PDF i Windows 10. Tidigare förväntades användare skriva ut dokument via XPS-formatet. 

## **XPS-konvertering med Aspose.Slides**

I [**Aspose.Slides**](https://products.aspose.com/slides/sv/php-java/) för Java kan du använda [**Save**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-)‑metoden som tillhandahålls av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation) för att konvertera hela presentationen till ett XPS‑dokument.

När du konverterar en presentation till XPS måste du spara presentationen med någon av följande inställningar:

- Standardinställningar (utan [**XPSOptions**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/xpsoptions))
- Anpassade inställningar (med [**XPSOptions**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/xpsoptions))

### **Konvertera presentationer till XPS med standardinställningar**

Det här exempelprogrammet visar hur du konverterar en presentation till ett XPS‑dokument med standardinställningar:

```php
  # Instansiera ett Presentation-objekt som representerar en presentationsfil
  $pres = new Presentation("Convert_XPS.pptx");
  try {
    # Sparar presentationen till XPS-dokument
    $pres->save("XPS_Output_Without_XPSOption.xps", SaveFormat::Xps);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Konvertera presentationer till XPS med anpassade inställningar**
Det här exempelprogrammet visar hur du konverterar en presentation till ett XPS‑dokument med anpassade inställningar:

```php
  # Instansiera ett Presentation-objekt som representerar en presentationsfil
  $pres = new Presentation("Convert_XPS_Options.pptx");
  try {
    # Instansiera TiffOptions-klassen
    $options = new XpsOptions();
    # Spara MetaFiles som PNG
    $options->setSaveMetafilesAsPng(true);
    # Spara presentationen till XPS-dokument
    $pres->save("XPS_Output_With_Options.xps", SaveFormat::Xps, $options);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Kan jag spara till XPS i en ström istället för en fil?**

Ja—Aspose.Slides låter dig exportera direkt till en ström, vilket är idealiskt för webb‑API:er, server‑sidiga pipelines eller någon situation där du vill skicka XPS utan att röra filsystemet.

**Överförs dolda bilder till XPS, och kan jag utesluta dem?**

Som standard renderas endast vanliga (synliga) bilder. Du kan [inkludera eller exkludera dolda bilder](https://reference.aspose.com/slides/sv/php-java/aspose.slides/xpsoptions/setshowhiddenslides/) via [exportinställningar](https://reference.aspose.com/slides/sv/php-java/aspose.slides/xpsoptions/) innan du sparar till XPS, så att utdata exakt innehåller de sidor du avser.