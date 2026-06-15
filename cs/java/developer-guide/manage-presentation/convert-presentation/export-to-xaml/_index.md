---
title: Export prezentací do XAML v Javě
linktitle: Prezentace do XAML
type: docs
weight: 30
url: /cs/java/export-to-xaml/
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
- Java
- Aspose.Slides
description: "Převod snímků PowerPoint a OpenDocument do XAML v Javě pomocí Aspose.Slides — rychlé řešení bez Office, které zachovává vaše rozložení beze změny."
---
## **Přehled**

Tento článek vysvětluje, jak exportovat prezentace PowerPoint do formátu XAML pomocí Aspose.Slides. Obsahuje stručné představení XAML, ukazuje, jak uložit prezentaci do XAML s výchozím nastavením, a demonstruje, jak přizpůsobit export pomocí [XamlOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/xamloptions/), včetně exportu skrytých snímků. Článek také odpovídá na několik častých otázek týkajících se náhradních fontů, kompatibility XAML stacku a chování exportu skrytých snímků.

## **O XAML**

XAML je popisný programovací jazyk, který umožňuje vytvářet nebo psát uživatelská rozhraní pro aplikace, zejména pro WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) a Xamarin Forms.  

XAML, který je jazykem založeným na XML, je Microsoftova varianta pro popis GUI. Většinou budete používat návrháře k práci se soubory XAML, ale můžete také psát a upravovat své GUI ručně.

## **Exportovat prezentace do XAML s výchozími možnostmi**

Tento kód v jazyce Java ukazuje, jak exportovat prezentaci do XAML s výchozím nastavením:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save(new XamlOptions());
} finally {
	if (pres != null) pres.dispose();
}
```

## **Exportovat prezentace do XAML se vlastními možnostmi**

Můžete vybrat možnosti z rozhraní [IXamlOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IXamlOptions), které řídí proces exportu a určují, jak Aspose.Slides exportuje vaši prezentaci do XAML. 

Například, pokud chcete, aby Aspose.Slides přidal skryté snímky z vaší prezentace při exportu do XAML, můžete nastavit vlastnost [ExportHiddenSlides](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IXamlOptions#setExportHiddenSlides-boolean-) na true. Viz tento ukázkový kód v jazyce Java:

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

**Jak mohu zajistit předvídatelné fonty, pokud originální font není na stroji dostupný?**

Nastavte [výchozí běžný font](https://reference.aspose.com/slides/cs/java/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) v [XamlOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/xamloptions/) — je používán jako náhradní font, když originál chybí. To pomáhá předejít neočekávaným substitucím.

**Je exportovaný XAML určen pouze pro WPF, nebo může být použit i v jiných XAML stackech?**

XAML je obecný markup jazyk UI používaný ve WPF, UWP a Xamarin.Forms. Export cílí na kompatibilitu s Microsoft XAML stacky; konkrétní chování a podpora specifických konstrukcí závisí na cílové platformě. Otestujte markup ve svém prostředí.

**Jsou skryté snímky podporovány a jak mohu zabránit jejich výchozímu exportu?**

Ve výchozím nastavení nejsou skryté snímky zahrnuty. Toto chování můžete ovládat pomocí [setExportHiddenSlides](https://reference.aspose.com/slides/cs/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) v [XamlOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/xamloptions/) — ponechte jej vypnutý, pokud je nepotřebujete exportovat.