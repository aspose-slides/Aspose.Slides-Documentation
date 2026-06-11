---
title: Exportera presentationer till XAML i PHP
linktitle: Presentation till XAML
type: docs
weight: 30
url: /sv/php-java/export-to-xaml/
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
- PHP
- Aspose.Slides
description: "Konvertera PowerPoint- och OpenDocument-bilder till XAML med Aspose.Slides för PHP via Java — snabb, Office-fri lösning som behåller din layout intakt."
---
## **Översikt**

Den här artikeln förklarar hur du exporterar PowerPoint-presentationer till XAML med Aspose.Slides. Den innehåller en kort introduktion till XAML, visar hur du sparar en presentation till XAML med standardinställningar och demonstrerar hur du anpassar exporten via [XamlOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/xamloptions/), inklusive export av dolda bilder. Artikeln svarar också på några vanliga frågor relaterade till reservteckensnitt, XAML‑stackkompatibilitet och beteendet för export av dolda bilder.

## **Om XAML**

XAML är ett beskrivande programmeringsspråk som låter dig bygga eller skriva användargränssnitt för appar, särskilt de som använder WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) och Xamarin‑formulär.  
XAML, som är ett XML‑baserat språk, är Microsofts variant för att beskriva ett GUI. Du kommer sannolikt att använda en designer för att arbeta med XAML‑filer för det mesta, men du kan fortfarande skriva och redigera ditt GUI.

## **Exportera presentationer till XAML med standardalternativ**

Den här PHP‑koden visar hur du exporterar en presentation till XAML med standardinställningar:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save(new XamlOptions());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Exportera presentationer till XAML med anpassade alternativ**

Du kan välja alternativ från [XamlOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/xamloptions/)‑klassen som styr exportprocessen och bestämmer hur Aspose.Slides exporterar din presentation till XAML.  

Till exempel, om du vill att Aspose.Slides ska lägga till dolda bilder från din presentation när du exporterar den till XAML, kan du använda metoden [setExportHiddenSlides](https://reference.aspose.com/slides/sv/php-java/aspose.slides/xamloptions/setexporthiddenslides/) med värdet `true`. Se detta exempel på PHP‑kod:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $xamlOptions = new XamlOptions();
    $xamlOptions->setExportHiddenSlides(true);
    $pres->save($xamlOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Vanliga frågor**

**Hur kan jag säkerställa förutsägbara teckensnitt om det ursprungliga teckensnittet inte är tillgängligt på maskinen?**

Ställ in [ett standardteckensnitt](https://reference.aspose.com/slides/sv/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) i [XamlOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/xamloptions/) — det används som ett reservteckensnitt när det ursprungliga saknas. Detta hjälper till att undvika oväntade ersättningar.

**Är den exporterade XAML:en avsedd endast för WPF, eller kan den också användas i andra XAML‑stackar?**

XAML är ett generellt UI‑markup‑språk som används i WPF, UWP och Xamarin.Forms. Exporten syftar till kompatibilitet med Microsofts XAML‑stackar; exakt beteende och stöd för specifika konstruktioner beror på målplattformen. Testa markupen i din miljö.

**Stöds dolda bilder, och hur kan jag förhindra att de exporteras som standard?**

Som standard inkluderas inte dolda bilder. Du kan styra detta beteende via [setExportHiddenSlides](https://reference.aspose.com/slides/sv/php-java/aspose.slides/xamloptions/setexporthiddenslides/) i [XamlOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/xamloptions/) — håll den inaktiverad om du inte behöver exportera dem.