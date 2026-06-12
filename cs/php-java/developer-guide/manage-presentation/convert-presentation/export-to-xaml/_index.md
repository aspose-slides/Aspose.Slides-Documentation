---
title: Exportovat prezentace do XAML v PHP
linktitle: Prezentace do XAML
type: docs
weight: 30
url: /cs/php-java/export-to-xaml/
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
- PHP
- Aspose.Slides
description: "Převeďte snímky PowerPoint a OpenDocument do XAML pomocí Aspose.Slides pro PHP přes Java — rychlé řešení bez Office, které zachová vaše rozložení."
---
## **Přehled**

Tento článek vysvětluje, jak exportovat prezentace PowerPoint do XAML pomocí Aspose.Slides. Obsahuje stručný úvod do XAML, ukazuje, jak uložit prezentaci do XAML s výchozími nastaveními, a demonstruje, jak přizpůsobit export pomocí [XamlOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/xamloptions/), včetně exportu skrytých snímků. Článek také odpovídá na několik častých otázek týkajících se náhradních písem, kompatibility XAML stacku a chování exportu skrytých snímků.

## **O XAML**

XAML je popisný programovací jazyk, který vám umožňuje vytvářet nebo psát uživatelská rozhraní pro aplikace, zejména pro ty, které používají WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) a Xamarin Forms.  

XAML, který je jazyk založený na XML, je Microsoftova varianta pro popis GUI. Pravděpodobně budete většinu času používat návrháře k práci s XAML soubory, ale můžete také GUI psát a upravovat. 

## **Export prezentací do XAML s výchozími možnostmi**

Tento PHP kód vám ukazuje, jak exportovat prezentaci do XAML s výchozími nastaveními:

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

## **Export prezentací do XAML s vlastními možnostmi**

Můžete vybrat možnosti ze třídy [XamlOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/xamloptions/), které řídí proces exportu a určují, jak Aspose.Slides exportuje vaši prezentaci do XAML.

Například pokud chcete, aby Aspose.Slides přidal skryté snímky z vaší prezentace při exportu do XAML, můžete použít metodu [setExportHiddenSlides](https://reference.aspose.com/slides/cs/php-java/aspose.slides/xamloptions/setexporthiddenslides/) s hodnotou `true`. Viz tento ukázkový PHP kód:

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

## **Často kladené otázky**

**Jak mohu zajistit předvídatelná písma, pokud originální písmo není na zařízení dostupné?**

Nastavte [výchozí běžné písmo](https://reference.aspose.com/slides/cs/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) v [XamlOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/xamloptions/) — používá se jako náhradní písmo, když originál chybí. Pomáhá to předejít nečekaným substitucím.

**Je exportovaný XAML určen pouze pro WPF, nebo může být použit i v jiných XAML stackech?**

XAML je obecný jazyk značkování UI používaný ve WPF, UWP a Xamarin.Forms. Export cílí na kompatibilitu s Microsoft XAML stacky; konkrétní chování a podpora specifických konstrukcí závisí na cílové platformě. Otestujte značky ve svém prostředí.

**Jsou podporovány skryté snímky a jak mohu zabránit jejich výchozímu exportu?**

Ve výchozím nastavení nejsou skryté snímky zahrnuty. Toto chování můžete ovládat pomocí [setExportHiddenSlides](https://reference.aspose.com/slides/cs/php-java/aspose.slides/xamloptions/setexporthiddenslides/) v [XamlOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/xamloptions/) — ponechte jej zakázáno, pokud je nepotřebujete exportovat.