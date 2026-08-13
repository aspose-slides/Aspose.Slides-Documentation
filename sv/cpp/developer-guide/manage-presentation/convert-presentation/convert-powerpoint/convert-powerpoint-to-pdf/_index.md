---
title: Konvertera PPT och PPTX till PDF i C++ [Avancerade funktioner inkluderade]
linktitle: PowerPoint till PDF
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

Att konvertera PowerPoint-presentationer (PPT, PPTX, ODP osv.) till PDF-format i C++ ger flera fördelar, inklusive kompatibilitet över olika enheter och bevarandet av layout och formatering av din presentation. Denna guide visar hur man konverterar presentationer till PDF-dokument, använder olika alternativ för att styra bildkvalitet, inkluderar dolda bilder, lösenordsskyddar PDF-filer, upptäcker typsnittsersättningar, väljer specifika bilder för konvertering och tillämpar efterlevnadsstandarder på de resulterande dokumenten.

## **PowerPoint till PDF-konverteringar**

Med Aspose.Slides kan du konvertera presentationer i följande format till PDF:

* **PPT**
* **PPTX**
* **ODP**

För att konvertera en presentation till PDF, skicka filnamnet som ett argument till klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) och spara sedan presentationen som en PDF med hjälp av `Save`‑metoden. Klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) exponerar `Save`‑metoden som vanligtvis används för att konvertera en presentation till PDF.

{{%  alert title="NOTE"  color="warning"   %}} 
Aspose.Slides för C++ lägger till sin API‑information och versionsnummer i utdatadokument. Till exempel, när en presentation konverteras till PDF, fyller Aspose.Slides i fältet Application med "*Aspose.Slides*" och PDF‑Producer‑fältet med ett värde i formatet "*Aspose.Slides v XX.XX*". **Obs** att du inte kan instruera Aspose.Slides att ändra eller ta bort denna information från utdatadokument.
{{% /alert %}}

Aspose.Slides låter dig konvertera:

* Hela presentationer till PDF
* Specifika bilder från en presentation till PDF

Aspose.Slides exporterar presentationer till PDF och säkerställer att de resulterande PDF‑erna nära matchar de ursprungliga presentationerna. Element och attribut återges exakt i konverteringen, inklusive:

* Bilder
* Textlådor och former
* Textformatering
* Styckeformatering
* Hyperlänkar
* Sidhuvuden och sidfötter
* Punkter
* Tabeller

## **Konvertera PowerPoint till PDF**

Den standardmässiga PowerPoint‑till‑PDF‑konverteringsprocessen använder standardalternativ. I detta fall försöker Aspose.Slides konvertera den angivna presentationen till PDF med optimala inställningar på högsta kvalitetsnivå.

Den här C++‑koden visar hur du konverterar en presentation (PPT, PPTX, ODP osv.) till PDF:

```c++
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Skapa ett Presentation-objekt som representerar en PowerPoint- eller OpenDocument-fil.
auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");

// Spara presentationen som en PDF.
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);

presentation->Dispose();
```

{{%  alert  color="info"  %}} 
Aspose erbjuder en gratis online‑[**PowerPoint till PDF‑konverterare**](https://products.aspose.app/slides/sv/conversion/ppt-to-pdf) som demonstrerar processen för presentation‑till‑PDF‑konvertering. Du kan köra ett test med denna konverterare för en live‑implementering av proceduren som beskrivs här.
{{% /alert %}}

## **Konvertera PowerPoint till PDF med alternativ**

Aspose.Slides tillhandahåller anpassade alternativ—egenskaper under klassen [PdfOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/pdfoptions/)—som låter dig anpassa den resulterande PDF‑en, låsa PDF‑en med ett lösenord eller ange hur konverteringsprocessen ska gå till.

### **Konvertera PowerPoint till PDF med anpassade alternativ**

Genom att använda anpassade konverteringsalternativ kan du definiera din föredragna kvalitetsinställning för rasterbilder, ange hur metafiler ska hanteras, sätta en komprimeringsnivå för text, konfigurera DPI för bilder och mer.

Kodexemplet nedan demonstrerar hur man konverterar en PowerPoint‑presentation till PDF med flera anpassade alternativ.

```c++
#include <DOM/Presentation.h>
#include <Export/PdfCompliance.h>
#include <Export/PdfOptions.h>
#include <Export/PdfTextCompression.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instansiera PdfOptions-klassen.
auto pdfOptions = MakeObject<PdfOptions>();

// Ange kvaliteten för JPG-bilder.
pdfOptions->set_JpegQuality(90);

// Ange DPI för bilder.
pdfOptions->set_SufficientResolution(300);

// Ange beteendet för metafiler.
pdfOptions->set_SaveMetafilesAsPng(true);

// Ange komprimeringsnivån för textinnehåll.
pdfOptions->set_TextCompression(PdfTextCompression::Flate);

// Definiera PDF-efterlevnadsläget.
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

// Instansiera Presentation-klassen som representerar en PowerPoint- eller OpenDocument-fil.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Spara presentationen som ett PDF-dokument.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Konvertera PowerPoint till PDF med dolda bilder**

Om en presentation innehåller dolda bilder kan du använda metoden [set_ShowHiddenSlides](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) från klassen [PdfOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/pdfoptions/) för att inkludera de dolda bilderna som sidor i den resulterande PDF‑en.

Den här C++‑koden visar hur man konverterar en PowerPoint‑presentation till PDF med dolda bilder inkluderade:

```c++
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instansiera Presentation-klassen som representerar en PowerPoint- eller OpenDocument-fil.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Instansiera PdfOptions-klassen.
auto pdfOptions = MakeObject<PdfOptions>();

// Lägg till dolda bilder.
pdfOptions->set_ShowHiddenSlides(true);

// Spara presentationen som en PDF.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Konvertera PowerPoint till lösenordsskyddad PDF**

Den här C++‑koden demonstrerar hur man konverterar en PowerPoint‑presentation till en lösenordsskyddad PDF med hjälp av skyddsparametrarna från klassen [PdfOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/pdfoptions/):

```c++
#include <DOM/Presentation.h>
#include <Export/PdfAccessPermissions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instansiera Presentation-klassen som representerar en PowerPoint- eller OpenDocument-fil.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Instansiera PdfOptions-klassen.
auto pdfOptions = MakeObject<PdfOptions>();

// Ange ett PDF-lösenord och åtkomstbehörigheter.
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

// Spara presentationen som en PDF.
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Upptäck typsnittsersättningar**

Aspose.Slides tillhandahåller metoden [set_WarningCallback](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/saveoptions/set_warningcallback/) under klassen [PdfOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/pdfoptions/), vilket gör det möjligt att upptäcka typsnittsersättningar under presentation‑till‑PDF‑konverteringsprocessen.

Den här C++‑koden visar hur man upptäcker typsnittsersättningar:

```c++
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <Warnings/IWarningCallback.h>
#include <Warnings/IWarningInfo.h>
#include <Warnings/ReturnAction.h>
#include <Warnings/WarningType.h>
#include <system/console.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Warnings;
using namespace System;

// Implementering av varningsåteranropet.
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
    // Instansiera Presentation-klassen som representerar en PowerPoint- eller OpenDocument-fil.
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // Ange varningsåteranropet i PDF-alternativen.
    auto pdfOptions = MakeObject<PdfOptions>();
    pdfOptions->set_WarningCallback(MakeObject<FontSubstitutionHandler>());

    // Spara presentationen som en PDF.
    presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);

    presentation->Dispose();

    return 0;
}
```

{{%  alert color="info"  %}} 
Ska du ha mer information om att ta emot återanrop för typsnittsersättningar under rendering‑processen, se [Getting Warning Callbacks for Fonts Substitution](/slides/sv/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

För mer information om typsnittsersättning, se artikeln [Font Substitution](/slides/sv/cpp/font-substitution/).
{{% /alert %}} 

## **Konvertera valda bilder från PowerPoint till PDF**

Den här C++‑koden demonstrerar hur man endast konverterar specifika bilder från en PowerPoint‑presentation till PDF:

```C++
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instansiera Presentation-klassen som representerar en PowerPoint- eller OpenDocument-fil.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Ange en array med bildnummer.
auto slides = MakeArray<int32_t>({ 1, 3 });

// Spara presentationen som en PDF.
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);

presentation->Dispose();
```

## **Konvertera PowerPoint till PDF med anpassad bildstorlek**

Den här C++‑koden demonstrerar hur man konverterar en PowerPoint‑presentation till PDF med en specificerad bildstorlek:

```C++
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto slideWidth = 612;
auto slideHeight = 792;

// Instansiera Presentation-klassen som representerar en PowerPoint- eller OpenDocument-fil.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Create a new presentation with an adjusted slide size.
auto resizedPresentation = MakeObject<Presentation>();

// Set the custom slide size.
resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

// Clone the first slide from the original presentation.
auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// Save the resized presentation to a PDF with notes.
resizedPresentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **Konvertera PowerPoint till PDF i bildvisning med anteckningar**

Den här C++‑koden demonstrerar hur man konverterar en PowerPoint‑presentation till en PDF som innehåller anteckningar:

```C++
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instansiera Presentation-klassen som representerar en PowerPoint- eller OpenDocument-fil.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Konfigurera PDF-alternativen med notlayout.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Spara presentationen som en PDF med anteckningar.
presentation->Save(u"PDF_with_notes.tiff", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

## **Tillgänglighet och efterlevnadsstandarder för PDF**

Aspose.Slides låter dig använda en konverteringsprocedur som följer [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Du kan exportera ett PowerPoint‑dokument till PDF med någon av dessa efterlevnadsstandarder: **PDF/A1a**, **PDF/A1b** och **PDF/UA**.

Den här C++‑koden demonstrerar en PowerPoint‑till‑PDF‑konverteringsprocess som producerar flera PDF‑er baserade på olika efterlevnadsstandarder:

```C++
#include <DOM/Presentation.h>
#include <Export/PdfCompliance.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

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

{{% alert title="Note" color="warning" %}} 
Aspose.Slides stöder PDF‑konverteringsoperationer, vilket gör det möjligt att konvertera PDF‑filer till populära filformat. Du kan utföra konverteringar som [PDF to HTML](https://products.aspose.com/slides/sv/cpp/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/sv/cpp/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/sv/cpp/conversion/pdf-to-jpg/), och [PDF to PNG](https://products.aspose.com/slides/sv/cpp/conversion/pdf-to-png/). Andra PDF‑konverteringsoperationer till specialiserade format—[PDF to SVG](https://products.aspose.com/slides/sv/cpp/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/sv/cpp/conversion/pdf-to-tiff/), och [PDF to XML](https://products.aspose.com/slides/sv/cpp/conversion/pdf-to-xml/)—stöds också.
{{% /alert %}}

> **Obs:** När du exporterar till PDF/UA behandlar Aspose.Slides komplex grafik som SmartArt, diagram och formler som en enda figur. Enskilda ban‑element bevaras inte som separerat innehåll och kan markeras som artefakter; alternativ text tillhandahålls endast för hela figuren.

## **Vanliga frågor**

### Kan jag konvertera flera PowerPoint‑filer till PDF i batch?

Ja, Aspose.Slides stöder batch‑konvertering av flera PPT‑ eller PPTX‑filer till PDF. Du kan iterera igenom dina filer och tillämpa konverteringsprocessen programmässigt.

### Är det möjligt att lösenordsskydda den konverterade PDF‑filen?

Absolut. Använd klassen [PdfOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/pdfoptions/) för att ange ett lösenord och definiera åtkomsträttigheter under konverteringsprocessen.

### Hur inkluderar jag dolda bilder i PDF‑en?

Använd metoden `set_ShowHiddenSlides` i klassen [PdfOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/pdfoptions/) för att inkludera dolda bilder i den resulterande PDF‑en.

### Kan Aspose.Slides bevara hög bildkvalitet i PDF‑en?

Ja, du kan styra bildkvaliteten genom att använda metoder som `set_JpegQuality` och `set_SufficientResolution` i klassen [PdfOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/pdfoptions/) för att säkerställa högkvalitativa bilder i din PDF.

### Stöder Aspose.Slides PDF/A‑efterlevnadsstandarder?

Ja, Aspose.Slides låter dig exportera PDF‑er som följer olika standarder, inklusive PDF/A1a, PDF/A1b och PDF/UA, vilket säkerställer att dina dokument uppfyller krav på tillgänglighet och arkivering.

## **Ytterligare resurser**

- [Aspose.Slides för C++‑dokumentation](/slides/sv/cpp/)
- [Aspose.Slides för C++ API‑referens](https://reference.aspose.com/slides/sv/cpp/)
- [Aspose gratis online‑konverterare](https://products.aspose.app/slides/sv/conversion)