---
title: Exportovat prezentace do XAML v JavaScriptu
linktitle: Prezentace do XAML
type: docs
weight: 30
url: /cs/nodejs-java/export-to-xaml/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Konvertujte snímky PowerPoint a OpenDocument do XAML v JavaScriptu pomocí Aspose.Slides pro Node.js - rychlé řešení bez Office, které zachová rozložení."
---
## **Přehled**

Tento článek vysvětluje, jak exportovat prezentace PowerPoint do XAML pomocí Aspose.Slides. Obsahuje stručné úvodní informace o XAML, ukazuje, jak uložit prezentaci do XAML s výchozími nastaveními, a demonstruje, jak přizpůsobit export pomocí [XamlOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/xamloptions/), včetně exportu skrytých snímků. Článek také odpovídá na několik častých otázek souvisejících s náhradními fonty, kompatibilitou XAML stacku a chováním exportu skrytých snímků.

## **O XAML**

XAML je popisovací programovací jazyk, který vám umožňuje vytvářet nebo psát uživatelské třídy pro aplikace, zejména ty, které používají WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) a Xamarin Forms.

XAML, což je jazyk založený na XML, je Microsoftova varianta pro popis GUI. Většinou budete používat návrháře k práci se soubory XAML, ale můžete také GUI psát a upravovat ručně.

## **Export prezentací do XAML s výchozími možnostmi**

Tento JavaScriptový kód ukazuje, jak exportovat prezentaci do XAML s výchozími nastaveními:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save(new aspose.slides.XamlOptions());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Export prezentací do XAML s vlastními možnostmi**

Můžete vybrat možnosti ze třídy [XamlOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/XamlOptions), které řídí proces exportu a určují, jak Aspose.Slides exportuje vaši prezentaci do XAML.

Například pokud chcete, aby Aspose.Slides při exportu do XAML přidal skryté snímky z vaší prezentace, můžete nastavit metodu [setExportHiddenSlides](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/XamlOptions#setExportHiddenSlides-boolean-) na true. Viz tento ukázkový JavaScriptový kód:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var xamlOptions = new aspose.slides.XamlOptions();
    xamlOptions.setExportHiddenSlides(true);
    pres.save(xamlOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Jak mohu zajistit předvídatelná písma, pokud originální písmo není na stroji k dispozici?**

Použijte [setDefaultRegularFont](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) v [XamlOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/xamloptions/) — používá se jako náhradní font, když originál chybí. To pomáhá předejít neočekávaným náhradám.

**Je exportovaný XAML určen pouze pro WPF, nebo může být použit i v jiných XAML stackech?**

XAML je obecný markup jazyk UI používaný ve WPF, UWP a Xamarin.Forms. Export je zaměřen na kompatibilitu s Microsoft XAML stacky; konkrétní chování a podpora specifických konstrukcí závisí na cílové platformě. Otestujte markup ve svém prostředí.

**Podporují se skryté snímky a jak mohu zabránit jejich výchozímu exportu?**

Ve výchozím nastavení nejsou skryté snímky zahrnuty. Toto chování můžete řídit pomocí [setExportHiddenSlides](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/xamloptions/setexporthiddenslides/) v [XamlOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/xamloptions/) — ponechte jej deaktivovaný, pokud je nechcete exportovat.