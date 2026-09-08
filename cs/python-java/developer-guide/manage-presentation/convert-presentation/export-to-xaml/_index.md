---
title: Export prezentací do XAML v Pythonu přes Java
linktitle: Prezentace do XAML
type: docs
weight: 30
url: /cs/python-java/export-to-xaml/
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
- Python
- Java
- Aspose.Slides
description: "Exportujte prezentace PowerPoint a OpenDocument do XAML pomocí Aspose.Slides pro Python přes Java. Použijte výchozí možnosti nebo zahrňte skryté snímky."
---
## **Přehled**

Tento článek vysvětluje, jak exportovat prezentace PowerPoint a OpenDocument do XAML pomocí Aspose.Slides pro Python prostřednictvím Java. Představuje XAML, ukazuje, jak exportovat s výchozími nastaveními, a demonstruje, jak zahrnout skryté snímky pomocí [XamlOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/xamloptions/).

Příklady vyžadují Aspose.Slides pro Python prostřednictvím Java a kompatibilní Java runtime. Umístěte `pres.pptx` do aktuálního pracovního adresáře. Každý příklad spustí JVM pouze pokud již neběží.

## **O XAML**

XAML (Extensible Application Markup Language) je jazyk založený na XML pro popis uživatelských rozhraní. Používají jej rámce jako Windows Presentation Foundation (WPF). XAML můžete vytvářet a upravovat pomocí vizuálního návrháře nebo textového editoru.

## **Export prezentací do XAML s výchozími možnostmi**

Vytvořte [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) ze vstupního souboru a poté předávejte [XamlOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/xamloptions/) do [Presentation.save](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#save) pro export s výchozími nastaveními:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

## **Export prezentací do XAML s vlastními možnostmi**

Použijte [XamlOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/xamloptions/) pro konfiguraci exportu. Pro zahrnutí skrytých snímků zavolejte [setExportHiddenSlides](https://reference.aspose.com/slides/cs/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) s hodnotou `True` před uložením:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    xaml_options.setExportHiddenSlides(True)
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

## **Časté dotazy**

**Jak mohu zvolit náhradní font, když není původní font k dispozici?**

Použijte [setDefaultRegularFont](https://reference.aspose.com/slides/cs/python-java/aspose.slides/saveoptions/#setDefaultRegularFont) na vašem objektu [XamlOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/xamloptions/), abyste určili náhradní font. Ujistěte se, že vybraný font je k dispozici v prostředí exportu.

**Mohu použít exportovaný markup v libovolném XAML frameworku?**

XAML frameworky se liší ve svých podporovaných prvcích a funkcích. Otestujte exportovaný markup ve svém cílovém frameworku, než jej začleníte do aplikace.

**Jsou skryté snímky exportovány ve výchozím nastavení?**

Ne. Pro jejich zahrnutí zavolejte [setExportHiddenSlides](https://reference.aspose.com/slides/cs/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) s hodnotou `True`. Nastavte jej na `False`, pokud je chcete vyloučit.