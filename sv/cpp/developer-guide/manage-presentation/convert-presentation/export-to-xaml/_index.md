---
title: Exportera presentationer till XAML i C++
linktitle: Presentation till XAML
type: docs
weight: 30
url: /sv/cpp/export-to-xaml/
keywords:
- exportera PowerPoint
- exportera OpenDocument
- exportera presentation
- konvertera PowerPoint
- konvertera OpenDocument
- konvertera presentation
- PowerPoint till XAML
- OpenDocument till XAML
- presentation till XAML
- PPT till XAML
- PPTX till XAML
- ODP till XAML
- spara PPT som XAML
- spara PPTX som XAML
- spara ODP som XAML
- exportera PPT till XAML
- exportera PPTX till XAML
- exportera ODP till XAML
- C++
- Aspose.Slides
description: "Konvertera PowerPoint- och OpenDocument-bilder till XAML i C++ med Aspose.Slides — snabb, Office-fr i lösning som bevarar din layout intakt."
---
## **Översikt**

Den här artikeln förklarar hur du exporterar PowerPoint-presentationer till XAML med Aspose.Slides. Den innehåller en kort introduktion till XAML, visar hur du sparar en presentation till XAML med standardinställningar och demonstrerar hur du anpassar exporten via [XamlOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export.xaml/xamloptions/), inklusive export av dolda bilder. Artikeln svarar också på några vanliga frågor relaterade till reservfonter, XAML-stack-kompatibilitet och beteendet för export av dolda bilder.

## **Om XAML**

XAML är ett beskrivande programmeringsspråk som låter dig skapa eller skriva användargränssnitt för appar, särskilt sådana som använder WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) och Xamarin Forms.  

XAML, som är ett XML-baserat språk, är Microsofts variant för att beskriva ett grafiskt användargränssnitt. Du kommer sannolikt att använda en designer för att arbeta med XAML-filer för det mesta, men du kan fortfarande skriva och redigera ditt GUI. 

## **Exportera presentationer till XAML med standardalternativ**

Den här C++-koden visar hur du exporterar en presentation till XAML med standardinställningar:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(System::MakeObject<XamlOptions>());
```

## **Exportera presentationer till XAML med anpassade alternativ**

Du kan välja alternativ från IXamlOptions‑gränssnittet som styr exportprocessen och bestämmer hur Aspose.Slides exporterar din presentation till XAML. 

Till exempel, om du vill att Aspose.Slides ska lägga till dolda bilder från din presentation när den exporteras till XAML, kan du skicka true till metoden [set_ExportHiddenSlides()](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.export.xaml.i_xaml_options#a94c59a06cc2163b17e6fa2fe817c0313). Se detta exempel i C++-kod: 

``` cpp
auto xamlOptions = System::MakeObject<XamlOptions>();
xamlOptions->set_ExportHiddenSlides(true);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(xamlOptions);
```

## **Vanliga frågor**

**Hur kan jag säkerställa förutsägbara typsnitt om det ursprungliga typsnittet inte finns på maskinen?**

Använd [set_DefaultRegularFont](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) i [XamlOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export.xaml/xamloptions/) — det används som reservtypsnitt när det ursprungliga saknas. Detta hjälper till att undvika oväntade ersättningar.

**Är den exporterade XAML:en avsedd endast för WPF, eller kan den även användas i andra XAML‑stackar?**

XAML är ett allmänt UI-markup-språk som används i WPF, UWP och Xamarin.Forms. Exporten syftar till kompatibilitet med Microsofts XAML-stackar; exakt beteende och stöd för specifika konstruktioner beror på målplattformen. Testa markupen i din miljö.

**Stöds dolda bilder, och hur kan jag förhindra att de exporteras som standard?**

Som standard inkluderas inte dolda bilder. Du kan kontrollera detta beteende via [set_ExportHiddenSlides](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) i [XamlOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export.xaml/xamloptions/) — håll den inaktiverad om du inte behöver exportera dem.