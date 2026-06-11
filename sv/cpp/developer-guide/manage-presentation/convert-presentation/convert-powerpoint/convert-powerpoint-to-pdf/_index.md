---
title: "Konvertera PPT och PPTX till PDF i C++ [Avancerade funktioner inkluderade]"
linktitle: "PowerPoint till PDF"
type: docs
weight: 40
url: /sv/cpp/convert-powerpoint-to-pdf/
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
- PDF/A1a
- PDF/A1b
- PDF/UA
- C++
- Aspose.Slides
description: "Konvertera PowerPoint PPT/PPTX till högkvalitativa, sökbara PDF-filer i C++ med Aspose.Slides, med snabba kodexempel och avancerade konverteringsalternativ."
---
## **Översikt**

Att konvertera PowerPoint‑presentationer (PPT, PPTX, ODP osv.) till PDF‑format i C++ ger flera fördelar, inklusive kompatibilitet över olika enheter och bevarande av layout och formatering i din presentation. Denna guide visar hur du konverterar presentationer till PDF‑dokument, använder olika alternativ för att styra bildkvalitet, inkluderar dolda bilder, lösenordsskyddar PDF‑filer, upptäcker teckensnittsersättningar, väljer specifika bilder för konvertering och tillämpar efterlevnadsstandarder på utdata‑dokument.

## **PowerPoint till PDF‑konverteringar**

Med Aspose.Slides kan du konvertera presentationer i följande format till PDF:

* **PPT**
* **PPTX**
* **ODP**

För att konvertera en presentation till PDF, skicka filnamnet som argument till [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/)-klassen och spara sedan presentationen som PDF med en `Save`‑metod. [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/)-klassen exponerar `Save`‑metoden som vanligtvis används för att konvertera en presentation till PDF.

{{%  alert title="OBS"  color="warning"   %}} 

Aspose.Slides för C++ infogar API‑information och versionsnummer i utdata‑dokumenten. Till exempel, när en presentation konverteras till PDF, fyller Aspose.Slides i fältet Application med "*Aspose.Slides*" och PDF‑Producer‑fältet med ett värde i formatet "*Aspose.Slides v XX.XX*". **Observera** att du inte kan instruera Aspose.Slides att ändra eller ta bort denna information från utdata‑dokumenten.

{{% /alert %}}

Aspose.Slides låter dig konvertera:

* Hela presentationer till PDF
* Specifika bilder från en presentation till PDF

Aspose.Slides exporterar presentationer till PDF och säkerställer att de resulterande PDF‑filerna nära matchar de ursprungliga presentationerna. Element och attribut återges exakt i konverteringen, inklusive:

* Bilder
* Textrutor och former
* Textformatering
* Styckeformatering
* Hyperlänkar
* Sidhuvuden och sidfötter
* Punktlistor
* Tabeller

## **Konvertera PowerPoint till PDF**

Den standardiserade PowerPoint‑till‑PDF‑konverteringsprocessen använder standardalternativ. I detta fall försöker Aspose.Slides konvertera den angivna presentationen till PDF med optimala inställningar på högsta kvalitet.

Denna C++‑kod visar hur du konverterar en presentation (PPT, PPTX, ODP osv.) till PDF:

```c++
// Skapa ett Presentation-objekt som representerar en PowerPoint- eller OpenDocument-fil.
auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");

// Spara presentationen som en PDF.
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);

presentation->Dispose();
```

{{%  alert  color="primary"  %}} 

Aspose erbjuder en gratis online‑[**PowerPoint till PDF‑konverterare**](https://products.aspose.app/slides/sv/conversion/ppt-to-pdf) som demonstrerar konverteringsprocessen. Du kan köra ett test med denna konverterare för en live‑implementation av proceduren som beskrivs här.

{{% /alert %}}

## **Konvertera PowerPoint till PDF med alternativ**

Aspose.Slides tillhandahåller anpassade alternativ—egenskaper under [PdfOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/pdfoptions/)-klassen—som låter dig anpassa den resulterande PDF‑en, låsa PDF‑en med ett lösenord eller ange hur konverteringsprocessen ska gå till.

### **Konvertera PowerPoint till PDF med anpassade alternativ**

Med anpassade konverteringsalternativ kan du definiera din föredragna kvalitetsinställning för rasterbilder, ange hur metafiler ska hanteras, sätta en komprimeringsnivå för text, konfigurera DPI för bilder och mer.

Kodexemplet nedan demonstrerar hur du konverterar en PowerPoint‑presentation till PDF med flera anpassade alternativ.

```c++
// Skapa en PdfOptions-klass.
auto pdfOptions = MakeObject<PdfOptions>();

// Ställ in kvaliteten för JPG-bilder.
pdfOptions->set_JpegQuality(90);

// Ställ in DPI för bilder.
pdfOptions->set_SufficientResolution(300);

// Ställ in beteendet för metafiler.
pdfOptions->set_SaveMetafilesAsPng(true);

// Ställ in textkomprimeringsnivån för textinnehåll.
pdfOptions->set_TextCompression(PdfTextCompression::Flate);

// Definiera PDF‑efterlevnadsläget.
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

// Skapa ett Presentation-objekt som representerar en PowerPoint‑ eller OpenDocument‑fil.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Spara presentationen som ett PDF-dokument.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Konvertera PowerPoint till PDF med dolda bilder**

Om en presentation innehåller dolda bilder kan du använda metoden [set_ShowHiddenSlides](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) från [PdfOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/pdfoptions/)-klassen för att inkludera de dolda bilderna som sidor i den resulterande PDF‑en.

Denna C++‑kod visar hur du konverterar en PowerPoint‑presentation till PDF med dolda bilder inkluderade:

```c++
// Skapa ett Presentation-objekt som representerar en PowerPoint- eller OpenDocument-fil.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Skapa en PdfOptions-klass.
auto pdfOptions = MakeObject<PdfOptions>();

// Lägg till dolda bilder.
pdfOptions->set_ShowHiddenSlides(true);

// Spara presentationen som en PDF.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Konvertera PowerPoint till lösenordsskyddad PDF**

Denna C++‑kod demonstrerar hur du konverterar en PowerPoint‑presentation till en lösenordsskyddad PDF med skyddsparametrarna från [PdfOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/pdfoptions/)-klassen:

```c++
// Skapa ett Presentation-objekt som representerar en PowerPoint- eller OpenDocument-fil.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Skapa en PdfOptions-klass.
auto pdfOptions = MakeObject<PdfOptions>();

// Ange ett PDF-lösenord och åtkomstbehörigheter.
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

// Spara presentationen som en PDF.
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Detektera teckensnittsersättningar**

Aspose.Slides tillhandahåller metoden [set_WarningCallback](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/saveoptions/set_warningcallback/) under [PdfOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/pdfoptions/)-klassen, vilket gör att du kan upptäcka teckensnittsersättningar under konverteringsprocessen från presentation till PDF.

Denna C++‑kod visar hur du detekterar teckensnittsersättningar:

```c++
// Implementering av varningsåterkallning.
class FontSubstitutionHandler : public IWarningCallback
{
public:
    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override;
};

ReturnAction FontSubstitutionHandler::Warning(SharedPtr<IWarningInfo> warning)
{
    if (warning->get_WarningType() == WarningType::DataLoss && 
        warning->get_Description().StartsWith(u"Font will be substituted"))
    {
        Console::WriteLine(u"Font substitution warning: {0}", warning->get_Description());
    }

    return ReturnAction::Continue;
}

int main()
{
    // Skapa ett Presentation-objekt som representerar en PowerPoint- eller OpenDocument-fil.
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // Ställ in varningsåterkallning i PDF-alternativ.
    auto pdfOptions = MakeObject<PdfOptions>();
    pdfOptions->set_WarningCallback(MakeObject<FontSubstitutionHandler>());

    // Spara presentationen som en PDF.
    presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
    
    presentation->Dispose();

    return 0;
}
```

{{%  alert color="primary"  %}} 

För mer information om att ta emot återanrop för teckensnittsersättningar under renderingsprocessen, se [Getting Warning Callbacks for Fonts Substitution](/slides/sv/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

För mer information om teckensnittsersättning, se artikeln [Font Substitution](/slides/sv/cpp/font-substitution/).

{{% /alert %}} 

## **Konvertera utvalda bilder från PowerPoint till PDF**

Denna C++‑kod demonstrerar hur du endast konverterar specifika bilder från en PowerPoint‑presentation till PDF:

```C++
// Skapa ett Presentation-objekt som representerar en PowerPoint- eller OpenDocument-fil.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Ställ in en array med bildnummer.
auto slides = MakeArray<int32_t>({ 1, 3 });

// Spara presentationen som en PDF.
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);

presentation->Dispose();
```

## **Konvertera PowerPoint till PDF med anpassad bildstorlek**

Denna C++‑kod demonstrerar hur du konverterar en PowerPoint‑presentation till PDF med en angiven bildstorlek:

```C++
auto slideWidth = 612;
auto slideHeight = 792;

// Skapa ett Presentation-objekt som representerar en PowerPoint- eller OpenDocument-fil.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Skapa en ny presentation med justerad bildstorlek.
auto resizedPresentation = MakeObject<Presentation>();

// Ställ in den anpassade bildstorleken.
resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

// Klona den första bilden från den ursprungliga presentationen.
auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// Spara den anpassade presentationen till en PDF med anteckningar.
resizedPresentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **Konvertera PowerPoint till PDF i anteckningsvy**

Denna C++‑kod demonstrerar hur du konverterar en PowerPoint‑presentation till en PDF som inkluderar anteckningar:

```C++
// Skapa ett Presentation-objekt som representerar en PowerPoint- eller OpenDocument-fil.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Konfigurera PDF-alternativen med anteckningslayout.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Spara presentationen till en PDF med anteckningar.
presentation->Save(u"PDF_with_notes.tiff", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

## **Tillgänglighet och efterlevnadsstandarder för PDF**

Aspose.Slides låter dig använda en konverteringsprocedur som följer [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Du kan exportera ett PowerPoint‑dokument till PDF med någon av dessa efterlevnadsstandarder: **PDF/A1a**, **PDF/A1b** och **PDF/UA**.

Denna C++‑kod demonstrerar en PowerPoint‑till‑PDF‑konverteringsprocess som producerar flera PDF‑filer baserat på olika efterlevnadsstandarder:

```C++
auto presentation = MakeObject<Presentation>(u"pres.pptx");

auto pdfOptionsA1a = MakeObject<PdfOptions>();

pdfOptionsA1a->set_Compliance(PdfCompliance::PdfA1a);
presentation->Save(u"pres-a1a-compliance.pdf", SaveFormat::Pdf, pdfOptionsA1a);

auto pdfOptionsA1b = MakeObject<PdfOptions>();
pdfOptionsA1b->set_Compliance(PdfCompliance::PdfA1b);
presentation->Save(u"pres-a1b-compliance.pdf", SaveFormat::Pdf, pdfOptionsA1b);

auto pdfOptionsUa = MakeObject<PdfOptions>();
pdfOptionsUa->set_Compliance(PdfCompliance::PdfUa);

presentation->Save(u"pres-ua-compliance.pdf", SaveFormat::Pdf, pdfOptionsUa);

presentation->Dispose();
```

{{% alert title="Obs" color="warning" %}} 

Aspose.Slides stöder PDF‑konverteringsoperationer, så att du kan konvertera PDF‑filer till populära filformat. Du kan utföra [PDF till HTML](https://products.aspose.com/slides/sv/cpp/conversion/pdf-to-html/), [PDF till bild](https://products.aspose.com/slides/sv/cpp/conversion/pdf-to-image/), [PDF till JPG](https://products.aspose.com/slides/sv/cpp/conversion/pdf-to-jpg/) och [PDF till PNG](https://products.aspose.com/slides/sv/cpp/conversion/pdf-to-png/)‑konverteringar. Andra PDF‑konverteringsoperationer till specialiserade format—[PDF till SVG](https://products.aspose.com/slides/sv/cpp/conversion/pdf-to-svg/), [PDF till TIFF](https://products.aspose.com/slides/sv/cpp/conversion/pdf-to-tiff/), och [PDF till XML](https://products.aspose.com/slides/sv/cpp/conversion/pdf-to-xml/)—stöds också.

{{% /alert %}}

> **Obs:** När du exporterar till PDF/UA behandlar Aspose.Slides komplex grafik såsom SmartArt, diagram och formler som en enda figur. Enskilda element i sökvägen bevaras inte som separat innehåll och kan märkas som artefakter; alternativ text tillhandahålls endast för hela figuren.

## **FAQ**

**Kan jag konvertera flera PowerPoint‑filer till PDF i bulk?**

Ja, Aspose.Slides stöder batch‑konvertering av flera PPT‑ eller PPTX‑filer till PDF. Du kan iterera genom dina filer och applicera konverteringsprocessen programmässigt.

**Är det möjligt att lösenordsskydda den konverterade PDF‑en?**

Absolut. Använd [PdfOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/pdfoptions/)-klassen för att sätta ett lösenord och definiera åtkomstbehörigheter under konverteringsprocessen.

**Hur inkluderar jag dolda bilder i PDF‑en?**

Använd metoden `set_ShowHiddenSlides` i [PdfOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/pdfoptions/)-klassen för att inkludera dolda bilder i den resulterande PDF‑en.

**Kan Aspose.Slides behålla hög bildkvalitet i PDF‑en?**

Ja, du kan styra bildkvaliteten genom metoder som `set_JpegQuality` och `set_SufficientResolution` i [PdfOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/pdfoptions/)-klassen för att säkerställa högkvalitativa bilder i din PDF.

**Stöder Aspose.Slides PDF/A‑efterlevnadsstandarder?**

Ja, Aspose.Slides låter dig exportera PDF‑filer som följer olika standarder, inklusive PDF/A1a, PDF/A1b och PDF/UA, vilket säkerställer att dina dokument uppfyller tillgänglighets- och arkiveringskrav.

## **Ytterligare resurser**

- [Aspose.Slides för C++‑dokumentation](/slides/sv/cpp/)
- [Aspose.Slides för C++ API‑referens](https://reference.aspose.com/slides/sv/cpp/)
- [Aspose fria online‑konverterare](https://products.aspose.app/slides/sv/conversion)