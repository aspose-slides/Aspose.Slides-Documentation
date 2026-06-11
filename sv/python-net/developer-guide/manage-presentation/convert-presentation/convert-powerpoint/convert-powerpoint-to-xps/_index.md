---
title: Konvertera PowerPoint-presentationer till XPS i Python
linktitle: PowerPoint till XPS
type: docs
weight: 70
url: /sv/python-net/convert-powerpoint-to-xps/
keywords:
- konvertera PowerPoint
- konvertera presentation
- PowerPoint till XPS
- presentation till XPS
- PPT till XPS
- PPTX till XPS
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Konvertera PowerPoint PPT/PPTX till högkvalitativ, plattformsoberoende XPS i Python med Aspose.Slides. Få steg-for-steg-guide och exempel på kod."
---
## **Översikt**

Aspose.Slides låter dig konvertera PowerPoint‑presentationer till XPS genom att spara en PPT‑ eller PPTX‑fil i XPS‑formatet. Den här artikeln förklarar när XPS‑formatet kan vara användbart och visar hur du utför konverteringen med Aspose.Slides med antingen standardinställningar eller anpassade [XpsOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/xpsoptions/)‑inställningar.

## **Om XPS**
Microsoft utvecklade [XPS](https://docs.fileformat.com/page-description-language/xps/) som ett alternativ till [PDF](https://docs.fileformat.com/pdf/). Det gör att du kan skriva ut innehåll genom att generera en fil som är mycket lik en PDF. XPS‑formatet är baserat på XML. Layouten eller strukturen i en XPS‑fil förblir densamma på alla operativsystem och skrivare. 

## När du ska använda Microsoft XPS‑format

{{% alert color="primary" %}} 

För att se hur Aspose.Slides konverterar PPT‑ eller PPTX‑presentationer till XPS‑formatet kan du prova [this free online converter app](https://products.aspose.app/slides/sv/conversion). 

{{% /alert %}} 

Om du vill minska lagringskostnaderna kan du konvertera din Microsoft PowerPoint‑presentation till XPS‑formatet. På så sätt blir det enklare att spara, dela och skriva ut dina dokument. 

Microsoft fortsätter att implementera starkt stöd för XPS i Windows (även i Windows 10), så du kanske vill överväga att spara filer i detta format. Om du arbetar med Windows 8.1, Windows 8, Windows 7 och Windows Vista kan XPS faktiskt vara ditt bästa alternativ för vissa operationer. 

- **Windows 8** använder OXPS (Open XPS)‑formatet för XPS‑filer. OXPS är en standardiserad version av det ursprungliga XPS‑formatet. Windows 8 erbjuder bättre stöd för XPS‑filer än för PDF‑filer. 
  - **XPS:** Inbyggd XPS‑visare/läsare och utskrift till XPS‑funktion tillgänglig. 
  - **PDF:** PDF‑läsare finns men ingen utskrift‑till‑PDF‑funktion. 

- **Windows 7 och Windows Vista** använder det ursprungliga XPS‑formatet. Dessa operativsystem ger också bättre stöd för XPS‑filer än för PDF‑filer. 
  - **XPS:** Inbyggd XPS‑visare och utskrift till XPS‑funktion tillgänglig. 
  - **PDF:** Ingen PDF‑läsare. Ingen utskrift‑till‑PDF‑funktion. 

|<p>**Inmatning PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Utdata XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |



Microsoft implementerade så småningom stöd för utskriftsoperationer i PDF genom funktionen Skriv ut till PDF i Windows 10. Tidigare förväntades användare skriva ut dokument via XPS‑formatet. 

## XPS‑konvertering med Aspose.Slides

I [**Aspose.Slides**](https://products.aspose.com/slides/sv/python-net/) för .NET kan du använda metoden [**Save**](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) som exponeras av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) för att konvertera hela presentationen till ett XPS‑dokument. 

När du konverterar en presentation till XPS måste du spara presentationen med någon av dessa inställningar:

- Standardinställningar (utan [**XPSOptions**](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/xpsoptions/))
- Anpassade inställningar (med [**XPSOptions**](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/xpsoptions/))

### **Konvertera presentationer till XPS med standardinställningar**

Detta exempel i Python visar hur du konverterar en presentation till ett XPS‑dokument med standardinställningar:

```py
import aspose.slides as slides

# Skapa ett Presentation-objekt som representerar en presentationsfil
pres = slides.Presentation("Convert_XPS.pptx")

# Spara presentationen till XPS-dokument
pres.save("XPS_Output_Without_XPSOption_out.xps", slides.export.SaveFormat.XPS)
```


### **Konvertera presentationer till XPS med anpassade inställningar**

Detta exempel visar hur du konverterar en presentation till ett XPS‑dokument med anpassade inställningar i Python:

```py
import aspose.slides as slides

# Skapa ett Presentation-objekt som representerar en presentationsfil
pres = slides.Presentation("Convert_XPS_Options.pptx")

# Instansiera TiffOptions-klassen
options = slides.export.XpsOptions()

# Spara MetaFiles som PNG
options.save_metafiles_as_png = True

# Spara presentationen till XPS-dokument
pres.save("XPS_With_Options_out.xps", slides.export.SaveFormat.XPS, options)
```

## **FAQ**

**Kan jag spara till XPS i en ström istället för en fil?**

Ja—Aspose.Slides låter dig exportera direkt till en ström, vilket är idealiskt för webb‑API:er, serversides‑pipelines eller alla scenarier där du vill skicka XPS utan att röra filsystemet.

**Följer dolda bilder med till XPS, och kan jag exkludera dem?**

Som standard renderas bara vanliga (synliga) bilder. Du kan [include or exclude hidden slides](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/xpsoptions/show_hidden_slides/) via [export settings](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/xpsoptions/) innan du sparar till XPS, vilket säkerställer att utdata exakt innehåller de sidor du önskar.