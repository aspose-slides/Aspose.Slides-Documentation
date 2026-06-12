---
title: Export prezentací do XAML v .NET
linktitle: Prezentace do XAML
type: docs
weight: 30
url: /cs/net/export-to-xaml/
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
- .NET
- C#
- Aspose.Slides
description: "Převod snímků PowerPoint a OpenDocument do XAML v .NET pomocí Aspose.Slides — rychlé řešení bez Office, které zachová vaše rozvržení nedotčené."
---
## **Přehled**

Tento článek vysvětluje, jak exportovat prezentace PowerPoint do XAML pomocí Aspose.Slides. Obsahuje stručné představení XAML, ukazuje, jak uložit prezentaci do XAML s výchozími nastaveními, a demonstruje, jak přizpůsobit export pomocí [XamlOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export.xaml/xamloptions/), včetně exportu skrytých snímků. Článek také odpovídá na několik častých otázek týkajících se náhradních písem, kompatibility XAML stacku a chování exportu skrytých snímků.

## **O XAML**

XAML je popisovací programovací jazyk, který vám umožňuje vytvářet nebo psát uživatelská rozhraní pro aplikace, zejména pro ty, které používají WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) a Xamarin Forms.  

XAML, který je založen na XML, je varianta Microsoftu pro popis GUI. Většinou budete používat návrhář k práci se soubory XAML, ale můžete také GUI psát a editovat.

## **Exportovat prezentace do XAML s výchozími možnostmi**

Tento C# kód ukazuje, jak exportovat prezentaci do XAML s výchozími nastaveními:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save(new XamlOptions());
}
```

## **Exportovat prezentace do XAML s vlastním nastavením**

Můžete vybrat možnosti z rozhraní [IXamlOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export.xaml/ixamloptions), které řídí proces exportu a určují, jak Aspose.Slides exportuje vaši prezentaci do XAML.  

Například pokud chcete, aby Aspose.Slides přidal skryté snímky z vaší prezentace při exportu do XAML, můžete nastavit vlastnost [ExportHiddenSlides](https://reference.aspose.com/slides/cs/net/aspose.slides.export.xaml/ixamloptions/properties/exporthiddenslides) na true. Viz tento ukázkový C# kód:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save(new XamlOptions { ExportHiddenSlides = true });
}
```

## **Často kladené otázky**

**Jak mohu zajistit předvídatelné písmo, pokud originální písmo není na počítači dostupné?**

Nastavte [DefaultRegularFont](https://reference.aspose.com/slides/cs/net/aspose.slides.export/saveoptions/defaultregularfont/) v [XamlOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export.xaml/xamloptions/) — použije se jako náhradní písmo, když originální chybí. To pomáhá předejít neočekávaným substitucím.

**Je exportovaný XAML určen pouze pro WPF, nebo jej lze použít i v jiných XAML stackách?**

XAML je obecný jazyk pro popis uživatelských rozhraní používaný ve WPF, UWP a Xamarin.Forms. Export je zaměřen na kompatibilitu s Microsoft XAML stacky; konkrétní chování a podpora specifických konstrukcí závisí na cílové platformě. Otestujte značky ve svém prostředí.

**Jsou skryté snímky podporovány a jak mohu zabránit jejich výchozímu exportu?**

Ve výchozím nastavení nejsou skryté snímky zahrnuty. Toto chování můžete ovládat pomocí [ExportHiddenSlides](https://reference.aspose.com/slides/cs/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) v [XamlOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export.xaml/xamloptions/) — ponechte jej zakázáno, pokud je nepotřebujete exportovat.