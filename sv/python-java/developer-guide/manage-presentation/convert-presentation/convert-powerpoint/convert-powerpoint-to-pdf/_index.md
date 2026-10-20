---
title: Konvertera PPT och PPTX till PDF i Python via Java [Avancerade funktioner inkluderade]
linktitle: PowerPoint till PDF
type: docs
weight: 40
url: /sv/python-java/convert-powerpoint-to-pdf/
keywords:
- konvertera PowerPoint
- konvertera presentation
- PowerPoint till PDF
- presentation till PDF
- PPT till PDF
- konvertera PPT till PDF
- PPTX till PDF
- konvertera PPTX till PDF
- spara PowerPoint som PDF
- spara PPT som PDF
- spara PPTX som PDF
- exportera PPT till PDF
- exportera PPTX till PDF
- bilaga
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Java
- Aspose.Slides
description: "Konvertera PowerPoint PPT/PPTX till högkvalitativa, sökbara PDF-filer i Python via Java med Aspose.Slides, med snabba kodexempel och avancerade konverteringsalternativ."
---
## **Översikt**

Att konvertera PowerPoint‑presentationer (PPT, PPTX, ODP osv.) till PDF‑format i Python via Java erbjuder flera fördelar, inklusive kompatibilitet över olika enheter och bevarande av presentationens layout och formatering. Denna guide visar hur man konverterar presentationer till PDF‑dokument, använder olika alternativ för att kontrollera bildkvalitet, inkluderar dolda bilder, lösenordsskyddar PDF‑filer, upptäcker teckensnittsersättningar, väljer specifika bilder för konvertering och tillämpar efterlevnadsstandarder på utdata.

## **PowerPoint till PDF‑konverteringar**

Med Aspose.Slides kan du konvertera presentationer i följande format till PDF:

* **PPT**
* **PPTX**
* **ODP**

För att konvertera en presentation till PDF, skicka filnamnet som ett argument till klassen [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) och spara sedan presentationen som en PDF med metoden [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save). Klassen [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) exponerar metoden [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) som vanligtvis används för att konvertera en presentation till PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java infogar sin API‑information och versionsnummer i utdatadokument. Till exempel, när en presentation konverteras till PDF, fyller Aspose.Slides i fältet Application med "*Aspose.Slides*" och PDF Producer‑fältet med ett värde i formen "*Aspose.Slides v XX.XX*". **Observera** att du inte kan instruera Aspose.Slides att ändra eller ta bort denna information från utdatadokument.
{{% /alert %}}

Aspose.Slides låter dig konvertera:

* Hela presentationer till PDF
* Specifika bilder från en presentation till PDF

Aspose.Slides exporterar presentationer till PDF och säkerställer att de resulterande PDF:erna matchar originalpresentationerna nära. Element och attribut renderas exakt i konverteringen, inklusive:

* Bilder
* Textrutor och former
* Textformatering
* Styckeformatering
* Hyperlänkar
* Sidhuvuden och sidfötter
* Punktlistor
* Tabeller

## **Konvertera PowerPoint till PDF**

Standardkonverteringen använder standardinställningarna för PDF‑export. Använd anpassade alternativ när du behöver kontrollera bildkvalitet, sidinnehåll eller PDF‑efterlevnad.

Följande exempel läser in en presentation och sparar alla synliga bilder till PDF med standardinställningarna för export.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Aspose erbjuder en gratis online [**PowerPoint till PDF‑konverterare**](https://products.aspose.app/slides/conversion/ppt-to-pdf) som demonstrerar konverteringsprocessen från presentation till PDF. Du kan köra ett test med denna konverterare för en levande implementering av proceduren som beskrivs här.
{{% /alert %}}

## **Konvertera PowerPoint till PDF med alternativ**

Aspose.Slides tillhandahåller anpassade alternativ – egenskaper under klassen [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) – som låter dig anpassa den resulterande PDF‑en, låsa PDF‑en med ett lösenord eller ange hur konverteringsprocessen ska gå till.

### **Konvertera PowerPoint till PDF med anpassade alternativ**

Genom att använda anpassade konverteringsalternativ kan du definiera din föredragna kvalitetsinställning för rasterbilder, ange hur metafiler ska hanteras, sätta en komprimeringsnivå för text, konfigurera DPI för bilder och mer.

Följande exempel exporterar en presentation till PDF 1.5 med JPEG‑kvalitet satt till 90, bildupplösning satt till 300 DPI, metafiler sparade som PNG och Flate‑textkomprimering.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfCompliance, PdfOptions, PdfTextCompression, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setJpegQuality(jpype.JByte(90))
pdf_options.setSufficientResolution(300)
pdf_options.setSaveMetafilesAsPng(True)
pdf_options.setTextCompression(PdfTextCompression.Flate)
pdf_options.setCompliance(PdfCompliance.Pdf15)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-custom.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Välj automatiskt bildkomprimering**

När en presentation innehåller många fotografier eller skärmdumpar kan minskning av den exporterade PDF‑ens storlek göra den enklare att e‑posta eller ladda ner. Anropa [PdfOptions.setBestImagesCompressionRatio](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setBestImagesCompressionRatio) med `True` för att automatiskt välja den mest lämpliga komprimeringsalgoritmen för varje bild under PDF‑export.

Följande exempel läser in en befintlig presentation, aktiverar automatisk bildkomprimeringsval och sparar den som ett PDF‑dokument. Alla andra PDF‑exportinställningar behåller sina standardvärden.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setBestImagesCompressionRatio(True)

presentation = Presentation("image-heavy.pptx")
try:
    presentation.save("image-heavy.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

Detta alternativ väljer en komprimeringsalgoritm för varje bild. Att sänka värdet som skickas till [setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setJpegQuality) minskar i stället JPEG‑bildkvaliteten, medan att sänka värdet som skickas till [setSufficientResolution](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setSufficientResolution) gör att bilder kan samplas ner till en lägre upplösning, vilket kan reducera detaljer. Aktivering av automatisk komprimeringsval sänker inte i sig dessa inställningar.

Att välja bildkomprimeringsalgoritmer kräver extra bearbetningstid och minne. Storleksminskningen beror på presentationens bilder och exportinställningar; en fast minskning är inte garanterad för varje presentation.

### **Bevara inbäddade OLE‑filer som PDF‑bilagor**

Om en presentation innehåller en inbäddad Excel‑arbetsbok kan du vilja att PDF‑mottagarna får åtkomst till arbetsbokens data samt kan se bilderna. Anropa [setIncludeOleData](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setIncludeOleData) med `True` för att bevara inbäddade OLE‑filer som bilagor i den resulterande PDF‑en.

Standardvärdet är `False`: OLE‑objektets förhandsgranskningsbild eller ikon renderas på PDF‑sidan, men den inbäddade filen inkluderas inte som en bilaga. Att sätta alternativet till `True` inkluderar dessutom filens data. Förhandsgranskningen förblir en visuell representation; bilagan låter mottagarna öppna eller spara den inbäddade filen separat. OLE‑objektet blir inte ett interaktivt Excel‑arkblad på PDF‑sidan.

Följande exempel läser in en presentation som redan innehåller en inbäddad Excel‑arbetsbok och exporterar den till PDF med arbetsboken bifogad.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setIncludeOleData(True)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

För att kontrollera resultatet:

1. Öppna den exporterade PDF‑en i en visare som stöder filbilagor, till exempel Adobe Acrobat Reader.
2. Öppna visarens **Bilagor**‑panel och lokalisera den inbäddade arbetsboken.
3. Spara bilagan och öppna den i Excel för att inspektera dess data, eller öppna den direkt om visaren tillåter det. Förhandsgranskningen på PDF‑sidan är separat från bilagan.

{{% alert color="info" title="Note" %}}
PDF/A‑standarderna inför begränsningar för bilagor: PDF/A-1 förbjuder inbäddade filer, PDF/A-2 tillåter endast PDF/A‑bilagor, och PDF/A-3 tillåter andra filtyper, inklusive Excel‑arbetsböcker. Detta är krav från standarderna, inte begränsningar specifika för Aspose.Slides. Detta exempel använder standardinställningen för PDF‑efterlevnad och demonstrerar inte PDF/A‑export.
{{% /alert %}}

### **Konvertera PowerPoint till PDF med dolda bilder**

Om en presentation innehåller dolda bilder kan du använda metoden [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) från klassen [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) för att inkludera de dolda bilderna som sidor i den resulterande PDF‑en.

Följande exempel exporterar en presentation till PDF, inklusive eventuella dolda bilder.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setShowHiddenSlides(True)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-hidden-slides.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Konvertera PowerPoint till ett lösenordsskyddat PDF**

Följande exempel exporterar en presentation till ett PDF som kräver lösenordet `password` för att öppnas. Åtkomstbehörigheterna tillåter utskrift, inklusive utskrift av hög kvalitet.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfAccessPermissions, PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setPassword("password")
pdf_options.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-protected.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Upptäcka teckensnittsersättningar**

Aspose.Slides tillhandahåller metoden [setWarningCallback](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setWarningCallback) under klassen [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) som låter dig upptäcka teckensnittsersättningar under konverteringsprocessen från presentation till PDF.

Följande exempel exporterar en presentation till PDF och skriver ut varningar för teckensnittsersättningar till konsolen. En varning skrivs ut endast när ett otillgängligt teckensnitt ersätts under export. Använd en JPype‑proxy för att ta emot varningsåteruppringningar från Java‑API:t. Konvertera Java‑beskrivningssträngen till en Python‑sträng innan du kontrollerar dess prefix:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, ReturnAction, SaveFormat, WarningType

class FontSubstitutionHandler:
    def warning(self, warning):
        description = str(warning.getDescription())
        if warning.getWarningType() == WarningType.DataLoss and description.startswith("Font will be substituted"):
            print(f"Font substitution warning: {description}")
        return ReturnAction.Continue


handler = FontSubstitutionHandler()
callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)

pdf_options = PdfOptions()
pdf_options.setWarningCallback(callback)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-font-warnings.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
För mer information om teckensnittsersättningar, se artikeln [Font Substitution](/slides/sv/python-java/font-substitution/).
{{% /alert %}}

### **Hantera teckensnitt utan en dedikerad fet stil**

En presentation kan använda fet formatering på text även när dess teckensnitt saknar en dedikerad fet stil. Texten kan ändå visas fet genom syntetisk fetstil, vilket artificiellt förtjockar de vanliga glyferna. När den texten ser för tung ut eller på annat sätt avviker från den avsedda visningen i PDF, prova att anropa [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles) med `True`. Detta alternativ renderar den påverkade texten som en bitmap under PDF‑export och kan förbättra dess utseende för vissa teckensnitt. Dess standardvärde är `False`.

Exempelpresentationen innehåller två textrutor: en med vanlig text och en med fet formatering applicerad på samma teckensnitt, som saknar en dedikerad fet stil. Följande exempel läser in presentationen, aktiverar rasterisering av teckensnittsstilar som saknar fet stil, och exporterar den till PDF:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setRasterizeUnsupportedFontStyles(True)

presentation = Presentation("unsupported-bold.pptx")
try:
    presentation.save("rasterized.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

Följande förhandsvisningar visar den inaktiverade och den aktiverade utdata. I detta exempel har den feta texten tjockare linjer när alternativet är avstängt. När alternativet är påslaget är linjerna lättare; den vanliga texten är oförändrad. Jämför resultaten innan du väljer inställningen för din presentation.

| Alternativ avstängt (`False`, standard) | Alternativ påslaget (`True`) |
|---|---|
| ![PDF med rasterisering av ostödd fet fontstil inaktiverad](unsupported-bold-disabled.png) | ![PDF med rasterisering av ostödd fet fontstil aktiverad](unsupported-bold-enabled.png) |

I detta exempel gör aktivering av alternativet att endast den feta texten blir en bitmap: den kan inte väljas, kopieras eller sökas som text utan OCR, och dess kanter ser mjukare ut vid 800 % zoom. Den vanliga texten förblir sökbar. När alternativet är avstängt förblir båda strängarna text.

Detta alternativ rasteriserar text som är formaterad som fet när dess teckensnitt saknar en dedikerad fet stil. [Font substitution](/slides/sv/python-java/font-substitution/) väljer istället ett annat teckensnitt när det ursprungliga är otillgängligt.

## **Konvertera valda bilder från PowerPoint till PDF**

Bildnummer som skickas till [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) är 1‑baserade. Detta exempel exporterar bilderna 1 och 3 när båda finns:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide_numbers = jpype.JArray(jpype.JInt)([1, 3])
    presentation.save("presentation-selected-slides.pdf", slide_numbers, SaveFormat.Pdf)
finally:
    presentation.dispose()
```

## **Konvertera PowerPoint till PDF med anpassad bildstorlek**

Detta exempel exporterar den första bilden på en sida som mäter 612 × 792 punkter (US Letter). Det klonar bilden till en ny presentation med den angivna storleken och skalar bildens innehåll för att passa.

```python
import jpime
import asposeslides

if not jpype.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation("presentation.pptx")
resized_presentation = Presentation()
try:
    resized_presentation.getSlideSize().setSize(612, 792, SlideSizeScaleType.EnsureFit)
    slide = presentation.getSlides().get_Item(0)
    resized_presentation.getSlides().insertClone(0, slide)

    # Ta bort den tomma bilden som den nya presentationen skapades med.
    resized_presentation.getSlides().removeAt(1)

    resized_presentation.save("presentation-custom-size.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
    resized_presentation.dispose()
```

## **Konvertera PowerPoint till PDF i anteckningsbildsvy**

Följande exempel exporterar en presentation till PDF och placerar varje bilds talarnoteringar under bilden. Använd en presentation som innehåller talarnoteringar för att se resultatet.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

notes_options = NotesCommentsLayoutingOptions()
notes_options.setNotesPosition(NotesPositions.BottomFull)

pdf_options = PdfOptions()
pdf_options.setSlidesLayoutOptions(notes_options)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-with-notes.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

## **Tillgänglighet och efterlevnadsstandarder för PDF**

När du förbereder tillgängliga PDF‑filer, konsultera [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Använd [PdfOptions.setCompliance](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setCompliance) för att välja en utdatastandard: **PDF/A1a**, **PDF/A1b** och **PDF/UA**.

Denna kod demonstrerar en PowerPoint‑till‑PDF‑konverteringsprocess som producerar flera PDF:er baserade på olika efterlevnadsstandarder:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfCompliance, PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()

    pdf_options.setCompliance(PdfCompliance.PdfA1a)
    presentation.save("presentation-a1a.pdf", SaveFormat.Pdf, pdf_options)

    pdf_options.setCompliance(PdfCompliance.PdfA1b)
    presentation.save("presentation-a1b.pdf", SaveFormat.Pdf, pdf_options)
    
    pdf_options.setCompliance(PdfCompliance.PdfUa)
    presentation.save("presentation-ua.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

> **Obs:** När du exporterar till PDF/UA behandlar Aspose.Slides komplex grafik såsom SmartArt, diagram och formler som en enda figur. Enskilda ban‑element bevaras inte som separat innehåll och kan markeras som artefakter; alternativ text tillhandahålls endast för hela figuren.

## **FAQ**

**Kan jag konvertera flera PowerPoint‑filer till PDF i bulk?**

Ja, Aspose.Slides stödjer batch‑konvertering av flera PPT‑ eller PPTX‑filer till PDF. Du kan iterera genom dina filer och tillämpa konverteringsprocessen programmässigt.

**Är det möjligt att lösenordsskydda den konverterade PDF‑en?**

Ja. Använd klassen [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) för att ange ett lösenord och definiera åtkomstbehörigheter under konverteringsprocessen.

**Hur inkluderar jag dolda bilder i PDF‑en?**

Anropa [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) med `True` i klassen [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) för att inkludera dolda bilder i den resulterande PDF‑en.

**Kan Aspose.Slides behålla hög bildkvalitet i PDF‑en?**

Ja, du kan kontrollera bildkvaliteten genom att använda metoder som [setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setJpegQuality) och [setSufficientResolution](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setSufficientResolution) i klassen [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) för att säkerställa högkvalitativa bilder i ditt PDF.

**Stöder Aspose.Slides PDF/A‑efterlevnadsstandarder?**

Ja, Aspose.Slides låter dig exportera PDF:er som följer [olika standarder](https://reference.aspose.com/slides/python-java/aspose.slides/pdfcompliance/), inklusive PDF/A1a, PDF/A1b och PDF/UA, för tillgänglighet eller arkivering. Välj lämplig standard och granska utdata mot dina krav.

## **Ytterligare resurser**

- [Aspose.Slides för Python via Java‑dokumentation](/slides/sv/python-java/)
- [Aspose.Slides för Python via Java API‑referens](https://reference.aspose.com/slides/python-java/)
- [Aspose gratis online‑konverterare](https://products.aspose.app/slides/conversion)