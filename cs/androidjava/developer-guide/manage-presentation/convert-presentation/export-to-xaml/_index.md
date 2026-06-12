---
title: Export prezentací do XAML na Androidu
linktitle: Prezentace do XAML
type: docs
weight: 30
url: /cs/androidjava/export-to-xaml/
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
- Android
- Java
- Aspose.Slides
description: "Převod snímků PowerPoint a OpenDocument do XAML v Javě pomocí Aspose.Slides pro Android -- rychlé řešení bez Office, které zachová váš rozvrh nedotčený."
---
## **Přehled**

Tento článek vysvětluje, jak exportovat prezentace PowerPoint do XAML pomocí Aspose.Slides. Obsahuje stručné představení XAML, ukazuje, jak uložit prezentaci do XAML s výchozími nastaveními, a demonstruje, jak přizpůsobit export pomocí [XamlOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/xamloptions/), včetně exportu skrytých snímků. Článek také odpovídá na několik častých otázek souvisejících s náhradními fonty, kompatibilitou XAML stacku a chováním exportu skrytých snímků.

## **O XAML**

XAML je popisný programovací jazyk, který vám umožňuje vytvářet nebo psát uživatelské rozhraní pro aplikace, zejména ty, které používají WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) a Xamarin Forms.  

XAML, což je jazyk založený na XML, je variantou Microsoftu pro popis GUI. Většinou používáte návrhář k práci se soubory XAML, ale můžete také GUI psát a upravovat ručně.

## **Export prezentací do XAML s výchozími možnostmi**

Tento Java kód ukazuje, jak exportovat prezentaci do XAML s výchozími nastaveními:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save(new XamlOptions());
} finally {
	if (pres != null) pres.dispose();
}
```

## **Export prezentací do XAML s vlastními možnostmi**

Můžete si vybrat možnosti z rozhraní [IXamlOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IXamlOptions), které řídí proces exportu a určují, jak Aspose.Slides exportuje vaši prezentaci do XAML.

Například pokud chcete, aby Aspose.Slides přidal skryté snímky z vaší prezentace při exportu do XAML, můžete nastavit vlastnost [ExportHiddenSlides](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IXamlOptions#setExportHiddenSlides-boolean-) na true. Viz tento ukázkový Java kód:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	XamlOptions xamlOptions = new XamlOptions();
	xamlOptions.setExportHiddenSlides(true);
	pres.save(xamlOptions);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Často kladené otázky**

**Jak mohu zajistit předvídatelná písma, pokud originální písmo není na počítači k dispozici?**

Nastavte [výchozí běžné písmo](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) v [XamlOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/xamloptions/) — použije se jako náhradní písmo, když originál chybí. Pomůže to zabránit neočekávaným náhradám.

**Je exportovaný XAML určen pouze pro WPF, nebo jej lze použít i v jiných XAML stackech?**

XAML je obecný jazyk pro popis UI používaný ve WPF, UWP a Xamarin.Forms. Export cílí na kompatibilitu s Microsoft XAML stacky; konkrétní chování a podpora specifických konstrukcí závisí na cílové platformě. Ověřte značkovací jazyk ve svém prostředí.

**Jsou podporovány skryté snímky a jak mohu zabránit jejich výchozímu exportu?**

Ve výchozím nastavení nejsou skryté snímky zahrnuty. Toto chování můžete ovládat pomocí [setExportHiddenSlides](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) v [XamlOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/xamloptions/) — ponechte jej zakázaný, pokud je nemusíte exportovat.