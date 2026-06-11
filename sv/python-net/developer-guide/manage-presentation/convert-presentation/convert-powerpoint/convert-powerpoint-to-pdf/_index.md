---
title: Konvertera PPT & PPTX till PDF i Python | Avancerade alternativ
linktitle: PowerPoint till PDF
type: docs
weight: 40
url: /sv/python-net/convert-powerpoint-to-pdf/
keywords:
- konvertera PowerPoint
- presentation
- PowerPoint till PDF
- PPT till PDF
- PPTX till PDF
- spara PowerPoint som PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Aspose.Slides for Python
description: "Steg-för-steg guide för att konvertera PPT, PPTX och ODP till högkvalitativa, WCAG-kompatibla PDF-filer i Python med Aspose.Slides—inkluderar lösenordsskydd, bildval och kontroll av bildkvalitet."
showReadingTime: true
---
## **Översikt**

Att konvertera PowerPoint‑presentationer (PPT, PPTX, ODP) till PDF‑format i Python erbjuder flera fördelar, inklusive att säkerställa kompatibilitet över olika enheter och bevara layouten och formateringen av din presentation. Denna guide visar hur du konverterar presentationer till PDF‑dokument, använder olika alternativ för att styra bildkvalitet, inkluderar dolda bilder, lösenordsskyddar PDF‑dokument, upptäcker teckensnittssubstitutioner, väljer specifika bilder för konvertering och tillämpar efterlevnadsstandarder på utdatan‑dokument.

## **PowerPoint till PDF‑konverteringar**

Med Aspose.Slides kan du konvertera presentationer i dessa format till PDF:

* **PPT**
* **PPTX**
* **ODP**

För att konvertera en presentation till PDF i Python behöver du bara ange filnamnet som argument i [Presentation](https://docs.aspose.com/slides/sv/python-net/api-reference/aspose.slides/presentation/)-klassen och sedan spara presentationen som en PDF med en [Save](https://docs.aspose.com/slides/sv/python-net/api-reference/aspose.slides/presentation/#methods)-metod. [Presentation](https://docs.aspose.com/slides/sv/python-net/api-reference/aspose.slides/presentation/)-klassen exponerar [Save](https://docs.aspose.com/slides/sv/python-net/api-reference/aspose.slides/presentation/#methods)-metoden som vanligtvis används för att konvertera en presentation till PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides för Python skriver direkt API‑information och versionsnummer i utdatadokumenten. Till exempel, när den konverterar en presentation till PDF, fyller Aspose.Slides för Python i Application‑fältet med värdet '*Aspose.Slides*' och PDF Producer‑fältet med ett värde i formen '*Aspose.Slides v XX.XX*'. **Obs** att du inte kan instruera Aspose.Slides för Python att ändra eller ta bort denna information från utdatadokument.

{{% /alert %}}

Aspose.Slides låter dig konvertera:

* Hela presentationer till PDF
* Specifika bilder i en presentation till PDF

Aspose.Slides exporterar presentationer till PDF och säkerställer att innehållet i de resulterande PDF‑filerna matchar originalpresentationerna nära. Element och attribut återges exakt i konverteringen, inklusive:

* Bilder
* Textrutor och former
* Textformatering
* Styckeformatering
* Hyperlänkar
* Sidhuvuden och sidfötter
* Punkter
* Tabeller

## **Konvertera PowerPoint till PDF**

Den standardmässiga PowerPoint‑PDF‑konverteringsoperationen körs med standardalternativ. I detta fall försöker Aspose.Slides konvertera den angivna presentationen till PDF med optimala inställningar på högsta kvalitetsnivåer. Denna Python‑kod visar hur du konverterar en PowerPoint till PDF:

*_Steg: PowerPoint‑till‑PDF‑konverteringar i Python_*

- <a name="python-net-powerpoint-to-pdf"><strong>Steg: Konvertera PowerPoint till PDF med Python via .NET</strong></a>
- <a name="python-net-ppt-to-pdf"><strong>Steg: Konvertera PPT till PDF med Python via .NET</strong></a>
- <a name="python-net-pptx-to-pdf"><strong>Steg: Konvertera PPTX till PDF med Python via .NET</strong></a>
- <a name="python-net-odp-to-pdf"><strong>Steg: Konvertera ODP till PDF med Python via .NET</strong></a>
- <a name="python-net-odp-to-pdf"><strong>Steg: Konvertera PPS till PDF med Python via .NET</strong></a>

_Kodsteg:_

- Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/)-klassen och ge den PowerPoint‑filen.
  * _.ppt_-ändelsen för att ladda **PPT**‑fil i _Presentation_-klassen.
  * _.pptx_-ändelsen för att ladda **PPTX**‑fil i _Presentation_-klassen.
  * _.odp_-ändelsen för att ladda **ODP**‑fil i _Presentation_-klassen.
  * _.pps_-ändelsen för att ladda **PPS**‑fil i _Presentation_-klassen.
- Spara _Presentation_ till **PDF**‑format genom att anropa **Save**‑metoden och använda **SaveFormat.PDF**‑enumerationen.
  

```python
import aspose.slides as slides

# Instansierar en Presentation-klass som representerar en PowerPoint-fil
presentation = slides.Presentation("PowerPoint.ppt")

# Sparar presentationen som en PDF
presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{%  alert  color="primary"  %}} 

Aspose erbjuder en gratis online **PowerPoint‑till‑PDF‑konverterare** som demonstrerar presentations‑till‑PDF‑konverteringsprocessen. För en levande implementation av proceduren som beskrivs här kan du göra ett test med konverteraren.

{{% /alert %}}

## **Konvertera PowerPoint till PDF med alternativ**

Aspose.Slides tillhandahåller anpassade alternativ—egenskaper under klassen [PdfOptions](https://docs.aspose.com/slides/sv/python-net/api-reference/aspose.slides.export/pdfoptions/)- som låter dig anpassa PDF‑filen (resultatet av konverteringsprocessen), låsa PDF‑filen med ett lösenord, eller till och med specificera hur konverteringsprocessen ska gå till.

### **Konvertera PowerPoint till PDF med anpassade alternativ**

Genom att använda anpassade konverteringsalternativ kan du ange din föredragna kvalitetsinställning för rasterbilder, specificera hur metafiler ska hanteras, ange en komprimeringsnivå för text, sätta DPI för bilder osv.

Kodexemplet nedan visar en operation där en PowerPoint‑presentation konverteras till PDF med flera anpassade alternativ:

```python
import aspose.slides as slides

# Instansierar PdfOptions-klassen
pdf_options = slides.export.PdfOptions()

# Anger kvaliteten för JPG-bilder
pdf_options.jpeg_quality = 90

# Anger DPI för bilder
pdf_options.sufficient_resolution = 300

# Anger beteendet för metafiler
pdf_options.save_metafiles_as_png = True

# Anger komprimeringsnivån för textinnehåll
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE

# Definierar PDF-efterlevnadsläget
pdf_options.compliance = slides.export.PdfCompliance.PDF15

# Instansierar Presentation-klassen som representerar ett PowerPoint-dokument
with slides.Presentation("PowerPoint.pptx") as presentation:
    # Sparar presentationen som ett PDF-dokument
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Konvertera PowerPoint till PDF med dolda bilder**

Om en presentation innehåller dolda bilder kan du använda ett anpassat alternativ—egenskapen `show_hidden_slides` från klassen [PdfOptions](https://docs.aspose.com/slides/sv/python-net/api-reference/aspose.slides.export/pdfoptions/)-för att instruera Aspose.Slides att inkludera de dolda bilderna som sidor i den resulterande PDF‑filen.

Den här Python‑koden visar hur du konverterar en PowerPoint‑presentation till PDF med dolda bilder inkluderade:

```python
import aspose.slides as slides

# Instansierar en Presentation-klass som representerar en PowerPoint-fil
presentation = slides.Presentation("PowerPoint.pptx")

# Instansierar PdfOptions-klassen
pdfOptions = slides.export.PdfOptions()

# Lägger till dolda bilder
pdfOptions.show_hidden_slides = True

# Sparar presentationen som en PDF
presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

### **Konvertera PowerPoint till lösenordsskyddad PDF**

Den här Python‑koden visar hur du konverterar en PowerPoint till en lösenordsskyddad PDF (med skyddsparametrar från klassen [PdfOptions](https://docs.aspose.com/slides/sv/python-net/api-reference/aspose.slides.export/pdfoptions/)):

```python
import aspose.slides as slides

# Instansierar ett Presentation-objekt som representerar en PowerPoint-fil
presentation = slides.Presentation("PowerPoint.pptx")

# Instansierar PdfOptions-klassen
pdfOptions = slides.export.PdfOptions()

# Anger PDF-lösenord och åtkomstbehörigheter
pdfOptions.password = "password"
pdfOptions.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

# Sparar presentationen som en PDF
presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

## **Konvertera valda bilder i PowerPoint till PDF**

Den här Python‑koden visar hur du konverterar specifika bilder i en PowerPoint‑presentation till PDF:

```python
import aspose.slides as slides

# Instansierar ett Presentation-objekt som representerar en PowerPoint-fil
presentation = slides.Presentation("PowerPoint.pptx")

# Anger en array med bildpositioner
slides_array = [ 1, 3 ]

# Sparar presentationen som en PDF
presentation.save("PPTX-to-PDF.pdf", slides_array, slides.export.SaveFormat.PDF)
```

## **Konvertera PowerPoint till PDF med anpassad bildstorlek**

Den här Python‑koden visar hur du konverterar en PowerPoint när dess bildstorlek är specificerad till en PDF:

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

# Instansierar Presentation-klassen som representerar en PowerPoint- eller OpenDocument-fil.
with slides.Presentation("SelectedSlides.pptx") as presentation:

    # Skapar en ny presentation med justerad bildstorlek.
    with slides.Presentation() as resized_presentation:

        # Ställer in den anpassade bildstorleken.
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)

        # Klonar den första bilden från den ursprungliga presentationen.
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # Sparar den ändrade presentationen till en PDF med anteckningar.
        resized_presentation.save("PDF_with_notes.pdf", slides.export.SaveFormat.PDF)
```

## **Konvertera PowerPoint till PDF i anteckningsvy för bilder**

Den här Python‑koden visar hur du konverterar en PowerPoint till PDF‑anteckningar:

```python
import aspose.slides as slides

# Instansierar en Presentation-klass som representerar en PowerPoint-fil
presentation = slides.Presentation("NotesFile.pptx")

pdfOptions = slides.export.PdfOptions()
pdfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Sparar presentationen till PDF-anteckningar
presentation.Save("Pdf_Notes_out.tiff", slides.export.SaveFormat.PDF, pdfOptions)
```

## **Tillgänglighet och efterlevnadsstandarder för PDF**

Aspose.Slides låter dig använda en konverteringsprocedur som följer [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Du kan exportera ett PowerPoint‑dokument till PDF med någon av dessa efterlevnadsstandarder: **PDF/A1a**, **PDF/A1b** och **PDF/UA**.

Det här Python‑koden demonstrerar en PowerPoint‑till‑PDF‑konverteringsoperation där flera PDF‑filer baserade på olika efterlevnadsstandarder erhålls:

```python
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

options = slides.export.PdfOptions()

options.compliance = slides.export.PdfCompliance.PDF_A1A
pres.save("pres-a1a-compliance.pdf", slides.export.SaveFormat.PDF, options)

options.compliance = slides.export.PdfCompliance.PDF_A1B
pres.save("pres-a1b-compliance.pdf", slides.export.SaveFormat.PDF, options)

options.compliance = slides.export.PdfCompliance.PDF_UA
pres.save("pres-ua-compliance.pdf", slides.export.SaveFormat.PDF, options)
```

{{% alert title="Note" color="warning" %}} 

Aspose.Slides‑stöd för PDF‑konverteringsoperationer sträcker sig till att låta dig konvertera PDF till de mest populära filformaten. Du kan göra [PDF till HTML](https://products.aspose.com/slides/sv/python-net/conversion/pdf-to-html/), [PDF till bild](https://products.aspose.com/slides/sv/python-net/conversion/pdf-to-image/), [PDF till JPG](https://products.aspose.com/slides/sv/python-net/conversion/pdf-to-jpg/), och [PDF till PNG](https://products.aspose.com/slides/sv/python-net/conversion/pdf-to-png/) konverteringar. Andra PDF‑konverteringsoperationer till specialiserade format—[PDF till SVG](https://products.aspose.com/slides/sv/python-net/conversion/pdf-to-svg/), [PDF till TIFF](https://products.aspose.com/slides/sv/python-net/conversion/pdf-to-tiff/), och [PDF till XML](https://products.aspose.com/slides/sv/python-net/conversion/pdf-to-xml/)—stöds också.

{{% /alert %}}

> **Obs:** När du exporterar till PDF/UA behandlar Aspose.Slides komplex grafik som SmartArt, diagram och formler som en enda figur. Enskilda path‑element bevaras inte som separat innehåll och kan markeras som artefakter; alternativ text tillhandahålls endast för hela figuren.

## **Vanliga frågor**

**Kan Aspose.Slides för Python ta bort programinformationen från PDF‑filen?**

Nej, Aspose.Slides för Python lägger automatiskt till API‑information och versionsnumret i den genererade PDF‑filen. Denna information kan inte ändras eller tas bort.

**Hur inkluderar jag bara specifika bilder i PDF‑konverteringen?**

Du kan ange de bildindex du vill konvertera genom att skicka en array med bildpositioner till `save`‑metoden.

**Är det möjligt att lösenordsskydda PDF‑filen under konverteringen?**

Ja, du kan sätta ett lösenord och definiera åtkomsträttigheter med hjälp av `PdfOptions`‑klassen innan du sparar presentationen som PDF.

**Stöder Aspose.Slides konvertering av PDF till andra format?**

Ja, Aspose.Slides stöder konvertering av PDF‑filer till format som HTML, bildformat (JPG, PNG), SVG, TIFF och XML.

**Hur kan jag säkerställa att min PDF följer tillgänglighetsstandarder?**

Ställ in egenskapen `compliance` i `PdfOptions` till standarder som `PDF_A1A`, `PDF_A1B` eller `PDF_UA` för att säkerställa efterlevnad av tillgänglighetsriktlinjer.

**Kan jag inkludera dolda bilder i PDF‑utdata?**

Ja, genom att sätta `show_hidden_slides`‑egenskapen i `PdfOptions` till `True` inkluderas dolda bilder i PDF‑filen.

**Hur justerar jag bildkvalitet och upplösning under konverteringen?**

Använd egenskaperna `jpeg_quality` och `sufficient_resolution` i `PdfOptions` för att styra bildkvalitet och upplösning i den resulterande PDF‑filen.

**Hantera Aspose.Slides teckensnittssubstitutioner automatiskt?**

Aspose.Slides upptäcker teckensnittssubstitutioner under konverteringen, och du kan hantera dem med egenskapen `warning_callback` i `SaveOptions` (för närvarande begränsad).

## **Ytterligare resurser**

- [Aspose.Slides för .NET Documentation](https://docs.aspose.com/slides/sv/python-net/)
- [Aspose.Slides API Reference](https://reference.aspose.com/slides/sv/python-net/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/sv/conversion)