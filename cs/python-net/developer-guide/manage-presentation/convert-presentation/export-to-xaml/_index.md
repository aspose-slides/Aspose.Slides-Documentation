---
title: Export prezentací do XAML pomocí Pythonu
linktitle: Export do XAML
type: docs
weight: 30
url: /cs/python-net/export-to-xaml/
keywords:
- exportovat PowerPoint
- exportovat OpenDocument
- exportovat prezentaci
- převést PowerPoint
- převést OpenDocument
- převést prezentaci
- PowerPoint do XAML
- OpenDocument do XAML
- prezentace do XAML
- PPT do XAML
- PPTX do XAML
- ODP do XAML
- Python
- Aspose.Slides
description: "Převod snímků PowerPoint a OpenDocument do XAML v Pythonu pomocí Aspose.Slides—rychlé řešení bez Office, které zachová váš rozvržení beze změny."
---
## **Přehled**

Tento článek vysvětluje, jak exportovat prezentace PowerPoint do XAML pomocí Aspose.Slides. Obsahuje stručný úvod do XAML, ukazuje, jak uložit prezentaci do XAML s výchozím nastavením, a demonstruje, jak přizpůsobit export pomocí [XamlOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export.xaml/xamloptions/), včetně exportu skrytých snímků. Článek také odpovídá na několik běžných otázek týkajících se rezervních fontů, kompatibility XAML stacku a chování exportu skrytých snímků.

## **O XAML**

XAML je popisovací programovací jazyk, který vám umožňuje vytvářet nebo psát uživatelská rozhraní pro aplikace, zejména ty, které používají WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) a Xamarin Forms.  

XAML, který je jazykem založeným na XML, je variantou Microsoftu pro popis GUI. Většinou budete pracovat s XAML soubory v návrháři, ale můžete také přímo psát a upravovat své GUI. 

## **Export prezentací do XAML s výchozími možnostmi**

Tento kód v Pythonu ukazuje, jak exportovat prezentaci do XAML s výchozím nastavením:

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")
pres.save(slides.export.xaml.XamlOptions())
```

## **Export prezentací do XAML s vlastními možnostmi**

Můžete vybrat možnosti ze třídy [XamlOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export.xaml/xamloptions/) , které řídí proces exportu a určují, jak Aspose.Slides exportuje vaši prezentaci do XAML. 

Například, pokud chcete, aby Aspose.Slides přidal skryté snímky z vaší prezentace při exportu do XAML, můžete nastavit vlastnost [export_hidden_slides](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) na `True`. Viz tento ukázkový kód v Pythonu: 

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

opt = slides.export.xaml.XamlOptions()
opt.export_hidden_slides = True

pres.save(opt)
```

## **Často kladené otázky**

**Jak mohu zajistit předvídatelné fonty, pokud originální font není k dispozici na stroji?**

Nastavte [default_regular_font](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export.xaml/xamloptions/default_regular_font/) v [XamlOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export.xaml/xamloptions/) — používá se jako rezervní font, když chybí originální. To pomáhá předejít neočekávaným náhradám.

**Je exportovaný XAML určen pouze pro WPF, nebo jej lze použít i v jiných XAML stackách?**

XAML je obecný značkovací jazyk UI používaný ve WPF, UWP a Xamarin.Forms. Export cílí na kompatibilitu s Microsoft XAML stacky; konkrétní chování a podpora specifických konstrukcí závisí na cílové platformě. Otestujte značky ve svém prostředí.

**Jsou podporovány skryté snímky a jak mohu zabránit jejich výchozímu exportu?**

Ve výchozím nastavení nejsou skryté snímky zahrnuty. Toto chování můžete ovládat pomocí [export_hidden_slides](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) v [XamlOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export.xaml/xamloptions/) — ponechte jej zakázáno, pokud je nechcete exportovat.