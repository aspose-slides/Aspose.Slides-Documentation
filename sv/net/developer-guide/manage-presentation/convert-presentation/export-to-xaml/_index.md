---
title: Exportera presentationer till XAML i .NET
linktitle: Presentation till XAML
type: docs
weight: 30
url: /sv/net/export-to-xaml/
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
- .NET
- C#
- Aspose.Slides
description: "Konvertera PowerPoint- och OpenDocument-bilder till XAML i .NET med Aspose.Slides—snabb, Office-fri lösning som bevarar din layout intakt."
---
## **Översikt**

Denna artikel förklarar hur du exporterar PowerPoint-presentationer till XAML med Aspose.Slides. Den innehåller en kort introduktion till XAML, visar hur du sparar en presentation till XAML med standardinställningar och demonstrerar hur du anpassar exporten via [XamlOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export.xaml/xamloptions/), inklusive export av dolda bilder. Artikeln svarar också på några vanliga frågor relaterade till reservtypsnitt, XAML‑stackkompatibilitet och beteende för export av dolda bilder.

## **Om XAML**

XAML är ett beskrivande programmeringsspråk som låter dig bygga eller skriva användargränssnitt för appar, särskilt de som använder WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) och Xamarin‑forms.  

XAML, som är ett XML‑baserat språk, är Microsofts variant för att beskriva ett GUI. Du använder sannolikt en designer för att arbeta med XAML‑filerna det mesta av tiden, men du kan fortfarande skriva och redigera ditt GUI.

## **Exportera presentationer till XAML med standardalternativ**

Denna C#‑kod visar hur du exporterar en presentation till XAML med standardinställningar:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save(new XamlOptions());
}
```

## **Exportera presentationer till XAML med anpassade alternativ**

Du kan välja alternativ från gränssnittet IXamlOptions som styr exportprocessen och bestämmer hur Aspose.Slides exporterar din presentation till XAML. 

Till exempel, om du vill att Aspose.Slides ska lägga till dolda bilder från din presentation när du exporterar den till XAML, kan du sätta egenskapen ExportHiddenSlides till true. Se detta exempel på C#‑kod: 

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save(new XamlOptions { ExportHiddenSlides = true });
}
```

## **Vanliga frågor**

**Hur kan jag säkerställa förutsägbara typsnitt om det ursprungliga typsnittet inte finns på maskinen?**

Ange DefaultRegularFont i [XamlOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export.xaml/xamloptions/) — den används som reservtypsnitt när det ursprungliga saknas. Detta hjälper till att undvika oväntade ersättningar.

**Är den exporterade XAML‑en avsedd endast för WPF, eller kan den användas i andra XAML‑stackar också?**

XAML är ett generellt UI‑markeringsspråk som används i WPF, UWP och Xamarin.Forms. Exporten syftar till kompatibilitet med Microsofts XAML‑stackar; exakt beteende och stöd för specifika konstruktioner beror på målplattformen. Testa markup‑en i din miljö.

**Stöds dolda bilder, och hur kan jag förhindra att de exporteras som standard?**

Som standard inkluderas inte dolda bilder. Du kan styra detta beteende via [ExportHiddenSlides](https://reference.aspose.com/slides/sv/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) i [XamlOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export.xaml/xamloptions/) — håll den inaktiverad om du inte behöver exportera dem.