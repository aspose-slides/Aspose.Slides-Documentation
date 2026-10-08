---
title: Konvertera PPT & PPTX till PDF i Python | Avancerade alternativ
linktitle: PowerPoint till PDF
type: docs
weight: 40
url: /sv/python-net/convert-powerpoint-to-pdf/
aliases:
  - /python-net/convert-to-pdf/
keywords:
- konvertera PowerPoint
- presentation
- PowerPoint till PDF
- PPT till PDF
- PPTX till PDF
- spara PowerPoint som PDF
- bilaga
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Aspose.Slides för Python
description: "Steg-för-steg-guide för att konvertera PPT, PPTX och ODP till högkvalitativa, WCAG-kompatibla PDF-filer i Python med Aspose.Slides—inkluderar lösenordsskydd, bildurval och kontroll av bildkvalitet."
showReadingTime: true
---
## **Översikt**

Att konvertera PowerPoint‑presentationer (PPT, PPTX, ODP) till PDF‑format i Python erbjuder flera fördelar, inklusive att säkerställa kompatibilitet över olika enheter och bevara layouten och formateringen av din presentation. Den här guiden visar hur du konverterar presentationer till PDF‑dokument, använder olika alternativ för att kontrollera bildkvalitet, inkluderar dolda bilder, lösenordsskyddar PDF‑dokument, upptäcker typsnittsbyten, väljer specifika bilder för konvertering och tillämpar efterlevnadsstandarder på utmatningsdokument.

## **PowerPoint till PDF‑konverteringar**

Med Aspose.Slides kan du konvertera presentationer i dessa format till PDF:

* **PPT**
* **PPTX**
* **ODP**

För att konvertera en presentation till PDF i Python behöver du bara skicka filnamnet som ett argument till klassen [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) och sedan spara presentationen som en PDF med hjälp av en [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/)-metod. Klassen [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) exponerar [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/)-metoden som vanligtvis används för att konvertera en presentation till PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides för Python inför sina API‑information och versionsnummer i utdata‑dokument. Till exempel, när den konverterar en presentation till PDF, fyller Aspose.Slides för Python i Application‑fältet med värdet '*Aspose.Slides*' och PDF‑Producer‑fältet med ett värde i formatet '*Aspose.Slides v XX.XX*'. **Obs** att du inte kan instruera Aspose.Slides för Python att ändra eller ta bort denna information från utdata‑dokument.
{{% /alert %}}

Aspose.Slides låter dig konvertera:

* Hela presentationer till PDF
* Specifika bilder i en presentation till PDF

Aspose.Slides exporterar presentationer till PDF och säkerställer att innehållet i de resulterande PDF‑erna noggrant matchar originalpresentationerna. Element och attribut återges exakt i konverteringen, inklusive:

* Bilder
* Textrutor och former
* Textformatering
* Styckeformatering
* Hyperlänkar
* Sidhuvuden och sidfötter
* Punktlistor
* Tabeller

## **Konvertera PowerPoint till PDF**

Den standardiserade PowerPoint‑till‑PDF‑konverteringsprocessen använder standardalternativ. I det här fallet försöker Aspose.Slides konvertera den angivna presentationen till PDF med optimala inställningar på högsta kvalitetsnivåer.

Följande exempel läser in en presentation och sparar alla synliga bilder till PDF med standardexportinställningarna.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.ppt") as presentation:
    presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{% alert color="info" title="Note" %}}
Aspose erbjuder en gratis online [**PowerPoint till PDF‑konverterare**](https://products.aspose.app/slides/conversion/ppt-to-pdf) som demonstrerar konverteringsprocessen från presentation till PDF. För en levande implementering av proceduren som beskrivs här kan du testa konverteraren.
{{% /alert %}}

## **Konvertera PowerPoint till PDF med alternativ**

Aspose.Slides tillhandahåller anpassade alternativ—egenskaper under klassen [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/)—som låter dig anpassa PDF‑en (resultatet av konverteringsprocessen), låsa PDF‑en med ett lösenord eller till och med specificera hur konverteringsprocessen ska gå till.

### **Konvertera PowerPoint till PDF med anpassade alternativ**

Genom att använda anpassade konverteringsalternativ kan du ange din föredragna kvalitetsinställning för rasterbilder, specificera hur metafiler ska hanteras, ställa in en komprimeringsnivå för text, ange DPI för bilder osv.

Följande exempel exporterar en presentation till PDF 1.5 med JPEG‑kvalitet satt till 90, bildupplösning satt till 300 DPI, metafiler sparade som PNG och Flate‑textkomprimering.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.jpeg_quality = 90
pdf_options.sufficient_resolution = 300
pdf_options.save_metafiles_as_png = True
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE
pdf_options.compliance = slides.export.PdfCompliance.PDF15

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Bevara inbäddade OLE‑filer som PDF‑bilagor**

Om en presentation innehåller en inbäddad Excel‑arbetsbok kan du vilja att PDF‑mottagare ska kunna komma åt arbetsbokens data samt visa bilderna. Sätt [PdfOptions.include_ole_data](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/include_ole_data/) till `True` för att bevara inbäddade OLE‑filer som bilagor i den resulterande PDF‑en.

Standardvärdet är `False`: OLE‑objektets förhandsgranskningsbild eller ikon återges på PDF‑sidan, men den inbäddade filen inkluderas inte som en bilaga. Genom att sätta alternativet till `True` inkluderas dessutom fildata. Förhandsgranskningen förblir en visuell representation; bilagan låter mottagare öppna eller spara den inbäddade filen separat. OLE‑objektet blir inte ett interaktivt Excel‑kalkylblad på PDF‑sidan.

Följande exempel läser in en presentation som redan innehåller en inbäddad Excel‑arbetsbok och exporterar den till PDF med arbetsboken bifogad.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.include_ole_data = True

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

För att kontrollera resultatet:

1. Öppna den exporterade PDF‑en i en visare som stödjer filbilagor, till exempel Adobe Acrobat Reader.
2. Öppna visarens **Attachments**‑panel och lokalisera den inbäddade arbetsboken.
3. Spara bilagan och öppna den i Excel för att inspektera dess data, eller öppna den direkt om visaren tillåter det. Förhandsgranskningen på PDF‑sidan är separat från bilagan.

{{% alert color="info" title="Note" %}}
PDF/A‑standarderna inför restriktioner för bilagor: PDF/A-1 förbjuder inbäddade filer, PDF/A-2 tillåter endast PDF/A‑bilagor, och PDF/A-3 tillåter andra filtyper, inklusive Excel‑arbetsböcker. Detta är krav från standarderna, inte restriktioner specifika för Aspose.Slides. Detta exempel använder standardinställningen för PDF‑efterlevnad och demonstrerar inte PDF/A‑export.
{{% /alert %}}

### **Konvertera PowerPoint till PDF med dolda bilder**

Om en presentation innehåller dolda bilder kan du använda ett anpassat alternativ—egenskapen [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) från klassen [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/)—för att instruera Aspose.Slides att inkludera de dolda bilderna som sidor i den resulterande PDF‑en.

Följande exempel exporterar en presentation till PDF och inkluderar eventuella dolda bilder.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.show_hidden_slides = True

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Konvertera PowerPoint till ett lösenordsskyddat PDF**

Följande exempel exporterar en presentation till en PDF som kräver lösenordet `password` för att öppnas. Åtkomstbehörigheterna tillåter utskrift, inklusive utskrift av hög kvalitet.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.password = "password"
pdf_options.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Hantera typsnitt utan en dedikerad fet stil**

En presentation kan applicera fet formatering på text även när dess typsnitt saknar en dedikerad fet stil. Texten kan ändå visas fet genom syntetisk fetning, vilket artificiellt förtjockar de vanliga glyferna. När den texten ser för tung ut eller på annat sätt avviker från den avsedda utseendet i PDF, prova att sätta [PdfOptions.rasterize_unsupported_font_styles](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/rasterize_unsupported_font_styles/) till `True`. Detta alternativ återger den påverkade texten som en bitmap under PDF‑export och kan förbättra dess utseende för vissa typsnitt. Standardvärdet är `False`.

Exempelpresentationen innehåller två textrutor: en med vanlig text och en med fet formatering applicerad på samma typsnitt, som saknar en dedikerad fet stil. Följande exempel läser in presentationen, aktiverar rasterisering av ej stödda typsnittsstilar och exporterar den till PDF:

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.rasterize_unsupported_font_styles = True

with slides.Presentation("unsupported-bold.pptx") as presentation:
    presentation.save("rasterized.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Följande förhandsgranskningar visar den avaktiverade och den aktiverade utmatningen. I detta exempel har den feta texten tjockare linjer när alternativet är avaktiverat. När alternativet är aktiverat är linjerna ljusare; den vanliga texten förblir oförändrad. Jämför resultaten innan du väljer inställningen för din presentation.

| Alternativ avaktiverat (`False`, standard) | Alternativ aktiverat (`True`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

I detta exempel gör aktivering av alternativet att endast den feta texten blir en bitmap: den kan inte väljas, kopieras eller sökas som text utan OCR, och dess kanter verkar mjukare vid 800 % zoom. Den vanliga texten förblir sökbar. Med alternativet avaktiverat förblir båda strängarna text.

Detta alternativ rasteriserar text formaterad som fet när dess typsnitt saknar en dedikerad fet stil. [Font substitution](/slides/sv/python-net/font-substitution/) väljer i stället ett annat typsnitt när originalet är otillgängligt.

## **Konvertera valda bilder i PowerPoint till PDF**

Följande exempel exporterar bilderna 1 och 3 från en presentation till PDF. Bildnumren i denna array är en-baserade, och den ingående presentationen måste innehålla minst tre bilder.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.pptx") as presentation:
    slide_numbers = [1, 3]
    presentation.save("PPTX-to-PDF.pdf", slide_numbers, slides.export.SaveFormat.PDF)
```

## **Konvertera PowerPoint till PDF med anpassad bildstorlek**

Följande exempel kopierar den första bilden från en presentation till en ny presentation med en bildstorlek på 612 × 792 punkter (8,5 × 11 tum). Det skalar bildinnehållet för att passa och exporterar den enda bilden till PDF.

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

with slides.Presentation("SelectedSlides.pptx") as presentation:
    with slides.Presentation() as resized_presentation:
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # Ta bort den tomma bilden som den nya presentationen skapades med.
        resized_presentation.slides.remove_at(1)

        resized_presentation.save("PDF_with_custom_slide_size.pdf", slides.export.SaveFormat.PDF)
```

## **Konvertera PowerPoint till PDF i anteckningsvyn**

Följande exempel exporterar en presentation till PDF och placerar varje bilds talarnoteringar under bilden. Använd en presentation som innehåller talarnoteringar för att se resultatet.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.slides_layout_options = slides.export.NotesCommentsLayoutingOptions()
pdf_options.slides_layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

with slides.Presentation("NotesFile.pptx") as presentation:
    presentation.save("Pdf_Notes_out.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

## **Tillgänglighets- och efterlevnadsstandarder för PDF**

Aspose.Slides låter dig använda en konverteringsprocedur som följer [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Du kan exportera ett PowerPoint‑dokument till PDF med någon av dessa efterlevnadsstandarder: **PDF/A1a**, **PDF/A1b** och **PDF/UA**.

Denna Python‑kod demonstrerar en PowerPoint‑till‑PDF‑konverteringsoperation där flera PDF‑er baserade på olika efterlevnadsstandarder erhålls:

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

{{% alert color="info" title="Note" %}}
Aspose.Slides stöd för PDF‑konverteringsoperationer låter dig konvertera PDF till de mest populära filformaten. Du kan göra [PDF till HTML](https://products.aspose.com/slides/python-net/conversion/pdf-to-html/), [PDF till bild](https://products.aspose.com/slides/python-net/conversion/pdf-to-image/), [PDF till JPG](https://products.aspose.com/slides/python-net/conversion/pdf-to-jpg/), och [PDF till PNG](https://products.aspose.com/slides/python-net/conversion/pdf-to-png/) konverteringar. Andra PDF‑konverteringsoperationer till specialiserade format—[PDF till SVG](https://products.aspose.com/slides/python-net/conversion/pdf-to-svg/), [PDF till TIFF](https://products.aspose.com/slides/python-net/conversion/pdf-to-tiff/), och [PDF till XML](https://products.aspose.com/slides/python-net/conversion/pdf-to-xml/)—stöds också.
{{% /alert %}}

> **Obs:** När du exporterar till PDF/UA behandlar Aspose.Slides komplex grafik såsom SmartArt, diagram och formler som en enda figur. Enskilda banor bevaras inte som separat innehåll och kan märkas som artefakter; alternativ text tillhandahålls endast för hela figuren.

## **Vanliga frågor**

**Kan Aspose.Slides för Python ta bort applikationsinformationen från PDF‑en?**  
Nej, Aspose.Slides för Python inkluderar automatiskt API‑information och versionsnumret i den genererade PDF‑en. Denna information kan inte ändras eller tas bort.

**Hur inkluderar jag bara specifika bilder i PDF‑konverteringen?**  
Du kan ange de bildindex du vill konvertera genom att skicka en array med bildpositioner till [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/)-metoden.

**Är det möjligt att lösenordsskydda PDF‑en under konverteringen?**  
Ja, du kan sätta ett lösenord och definiera åtkomstbehörigheter med hjälp av klassen [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) innan du sparar presentationen som PDF.

**Stöder Aspose.Slides konvertering av PDF till andra format?**  
Ja, Aspose.Slides stöder konvertering av PDF‑er till format som HTML, bildformat (JPG, PNG), SVG, TIFF och XML.

**Hur kan jag säkerställa att min PDF följer tillgänglighetsstandarder?**  
Ange egenskapen [compliance](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/compliance/) i [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) till standarder som `PDF_A1A`, `PDF_A1B` eller `PDF_UA` för att säkerställa efterlevnad av tillgänglighetsriktlinjer.

**Kan jag inkludera dolda bilder i PDF‑utmatningen?**  
Ja, genom att sätta egenskapen [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) i [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) till `True` kommer dolda bilder att inkluderas i PDF‑en.

**Hur justerar jag bildkvalitet och upplösning under konverteringen?**  
Använd egenskaperna [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/) och [sufficient_resolution](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) i [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) för att styra bildkvalitet och upplösning i den resulterande PDF‑en.

**Hantera Aspose.Slides typsnittssubstitutioner automatiskt?**  
Aspose.Slides upptäcker typsnittssubstitutioner under konverteringen, och du kan hantera dem med hjälp av egenskapen `warning_callback` i `SaveOptions` (för närvarande begränsad).

## **Ytterligare resurser**

- [Aspose.Slides för Python via .NET-dokumentation](/slides/sv/python-net/)
- [Aspose.Slides API‑referens](https://reference.aspose.com/slides/python-net/)
- [Aspose fria online‑konverterare](https://products.aspose.app/slides/conversion)