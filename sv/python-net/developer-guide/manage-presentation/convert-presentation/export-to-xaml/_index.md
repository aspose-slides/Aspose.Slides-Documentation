---
title: Exportera presentationer till XAML med Python
linktitle: Exportera till XAML
type: docs
weight: 30
url: /sv/python-net/export-to-xaml/
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
- Python
- Aspose.Slides
description: "Konvertera PowerPoint- och OpenDocument-bilder till XAML i Python med Aspose.Slides – snabb, Office-fri lösning som behåller din layout intakt."
---
## **Översikt**

Den här artikeln förklarar hur du exporterar PowerPoint-presentationer till XAML med Aspose.Slides. Den innehåller en kort introduktion till XAML, visar hur du sparar en presentation till XAML med standardinställningar och demonstrerar hur du anpassar exporten via [XamlOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export.xaml/xamloptions/), inklusive export av dolda bilder. Artikeln svarar också på några vanliga frågor relaterade till reservfonter, XAML-stackkompatibilitet och beteende vid export av dolda bilder.

## **Om XAML**

XAML är ett beskrivande programmeringsspråk som gör det möjligt att bygga eller skriva användargränssnitt för appar, särskilt sådana som använder WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) och Xamarin Forms.  

XAML, som är ett XML-baserat språk, är Microsofts variant för att beskriva ett GUI. Du kommer troligen att använda en designer för att arbeta med XAML-filer det mesta av tiden, men du kan fortfarande skriva och redigera ditt GUI. 

## **Exportera presentationer till XAML med standardalternativ**

Denna Python-kod visar hur du exporterar en presentation till XAML med standardinställningar:

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")
pres.save(slides.export.xaml.XamlOptions())
```

## **Exportera presentationer till XAML med anpassade alternativ**

Du kan välja alternativ från klassen [XamlOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export.xaml/xamloptions/) som styr exportprocessen och bestämmer hur Aspose.Slides exporterar din presentation till XAML. 

Till exempel, om du vill att Aspose.Slides ska lägga till dolda bilder från din presentation vid export till XAML, kan du sätta egenskapen [export_hidden_slides](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) till `True`. Se detta exempel på Python-kod: 

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

opt = slides.export.xaml.XamlOptions()
opt.export_hidden_slides = True

pres.save(opt)
```

## **FAQ**

**Hur kan jag säkerställa förutsägbara teckensnitt om det ursprungliga teckensnittet inte finns på maskinen?**

Ange [default_regular_font](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export.xaml/xamloptions/default_regular_font/) i [XamlOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export.xaml/xamloptions/) — den används som reservteckensnitt när det ursprungliga saknas. Detta hjälper till att undvika oväntade ersättningar.

**Är den exporterade XAML:en avsedd endast för WPF, eller kan den också användas i andra XAML-stackar?**

XAML är ett generellt UI-markeringsspråk som används i WPF, UWP och Xamarin.Forms. Exporten syftar till kompatibilitet med Microsofts XAML-stackar; exakt beteende och stöd för specifika konstruktioner beror på målplattformen. Testa markup-en i din miljö.

**Stöds dolda bilder, och hur kan jag förhindra att de exporteras som standard?**

Som standard inkluderas inte dolda bilder. Du kan styra detta beteende via [export_hidden_slides](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) i [XamlOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export.xaml/xamloptions/) — håll den inaktiverad om du inte behöver exportera dem.