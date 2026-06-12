---
title: Exportovat prezentace do XAML v C++
linktitle: Prezentace do XAML
type: docs
weight: 30
url: /cs/cpp/export-to-xaml/
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
- uložit PPT jako XAML
- uložit PPTX jako XAML
- uložit ODP jako XAML
- exportovat PPT do XAML
- exportovat PPTX do XAML
- exportovat ODP do XAML
- C++
- Aspose.Slides
description: "Převést snímky PowerPoint a OpenDocument do XAML v C++ pomocí Aspose.Slides—rychlé řešení bez Office, které zachová vaše rozložení beze změny."
---
## **Přehled**

Tento článek vysvětluje, jak exportovat prezentace PowerPoint do XAML pomocí Aspose.Slides. Obsahuje stručný úvod do XAML, ukazuje, jak uložit prezentaci do XAML s výchozím nastavením, a demonstruje, jak přizpůsobit export pomocí [XamlOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export.xaml/xamloptions/), včetně exportu skrytých snímků. Článek také odpovídá na několik běžných otázek souvisejících s náhradními fonty, kompatibilitou XAML stacku a chováním exportu skrytých snímků.

## **O XAML**

XAML je popisovací programovací jazyk, který vám umožňuje vytvářet nebo psát uživatelská rozhraní pro aplikace, zejména pro ty, které používají WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) a Xamarin Forms.

XAML, což je jazyk založený na XML, je variantou Microsoftu pro popis GUI. Většinou pravděpodobně použijete návrháře k práci s XAML soubory, ale můžete také psát a upravovat své GUI.

## **Export prezentací do XAML s výchozími možnostmi**

Tento C++ kód vám ukazuje, jak exportovat prezentaci do XAML s výchozím nastavením:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(System::MakeObject<XamlOptions>());
```

## **Export prezentací do XAML s vlastními možnostmi**

Můžete vybrat možnosti z rozhraní [IXamlOptions](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.export.xaml.i_xaml_options), které řídí proces exportu a určují, jak Aspose.Slides exportuje vaši prezentaci do XAML.

Například pokud chcete, aby Aspose.Slides při exportu do XAML přidal skryté snímky z vaší prezentace, můžete předat hodnotu true metodě [set_ExportHiddenSlides()](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.export.xaml.i_xaml_options#a94c59a06cc2163b17e6fa2fe817c0313). Viz tento ukázkový C++ kód:

``` cpp
auto xamlOptions = System::MakeObject<XamlOptions>();
xamlOptions->set_ExportHiddenSlides(true);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(xamlOptions);
```

## **Často kladené otázky**

**Jak mohu zajistit předvídatelné fonty, pokud původní font není na stroji dostupný?**

Použijte [set_DefaultRegularFont](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) v [XamlOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export.xaml/xamloptions/) — používá se jako náhradní font, když původní chybí. To pomáhá předejít neočekávaným náhradám.

**Je exportovaný XAML určen pouze pro WPF, nebo ho lze použít i v jiných XAML stackech?**

XAML je obecný značkovací jazyk UI používaný ve WPF, UWP a Xamarin.Forms. Export cílí na kompatibilitu s Microsoft XAML stacky; konkrétní chování a podpora specifických konstrukcí závisí na cílové platformě. Otestujte značkování ve vašem prostředí.

**Jsou skryté snímky podporovány a jak mohu zabránit jejich výchozímu exportu?**

Ve výchozím nastavení nejsou skryté snímky zahrnuty. Toto chování můžete řídit pomocí [set_ExportHiddenSlides](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) v [XamlOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export.xaml/xamloptions/) — nechte jej zakázaný, pokud je nepotřebujete exportovat.