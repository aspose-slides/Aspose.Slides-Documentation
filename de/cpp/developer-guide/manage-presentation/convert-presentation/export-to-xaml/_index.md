---
title: Exportieren von Präsentationen nach XAML in C++
linktitle: Präsentation nach XAML
type: docs
weight: 30
url: /de/cpp/export-to-xaml/
keywords:
- PowerPoint exportieren
- OpenDocument exportieren
- Präsentation exportieren
- PowerPoint konvertieren
- OpenDocument konvertieren
- Präsentation konvertieren
- PowerPoint nach XAML
- OpenDocument nach XAML
- Präsentation nach XAML
- PPT nach XAML
- PPTX nach XAML
- ODP nach XAML
- PPT als XAML speichern
- PPTX als XAML speichern
- ODP als XAML speichern
- PPT nach XAML exportieren
- PPTX nach XAML exportieren
- ODP nach XAML exportieren
- C++
- Aspose.Slides
description: "PowerPoint- und OpenDocument-Folien in XAML in C++ mit Aspose.Slides konvertieren - schnelle, Office-freie Lösung, die das Layout beibehält."
---

## **Präsentationen nach XAML exportieren**

{{% alert color="primary" %}} 
In [Aspose.Slides 21.6](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-21-6-release-notes/), haben wir die Unterstützung für den XAML-Export implementiert. Sie können Ihre Präsentationen jetzt nach XAML exportieren. 
{{% /alert %}} 

## **Über XAML**

XAML ist eine beschreibende Programmiersprache, mit der Sie Benutzeroberflächen für Apps erstellen oder schreiben können, insbesondere solche, die WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) und Xamarin Forms verwenden.  

XAML, eine XML-basierte Sprache, ist Microsofts Variante zur Beschreibung einer GUI. Sie werden wahrscheinlich die meiste Zeit einen Designer verwenden, um an XAML-Dateien zu arbeiten, können aber weiterhin Ihre GUI schreiben und bearbeiten. 

## **Präsentationen nach XAML mit Standardoptionen exportieren**

Dieser C++‑Code zeigt, wie Sie eine Präsentation mit den Standardeinstellungen nach XAML exportieren:
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(System::MakeObject<XamlOptions>());
```


## **Präsentationen nach XAML mit benutzerdefinierten Optionen exportieren**

Sie können Optionen aus der [IXamlOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xaml.i_xaml_options)‑Schnittstelle auswählen, die den Exportvorgang steuern und festlegen, wie Aspose.Slides Ihre Präsentation nach XAML exportiert. 

Beispiel: Wenn Sie möchten, dass Aspose.Slides beim Export nach XAML versteckte Folien Ihrer Präsentation hinzufügt, können Sie den Wert true an die [set_ExportHiddenSlides()](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xaml.i_xaml_options#a94c59a06cc2163b17e6fa2fe817c0313)‑Methode übergeben. Siehe diesen Beispiel‑C++‑Code: 
``` cpp
auto xamlOptions = System::MakeObject<XamlOptions>();
xamlOptions->set_ExportHiddenSlides(true);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(xamlOptions);
```


## **FAQ**

**Wie kann ich vorhersehbare Schriften sicherstellen, wenn die Originalschrift auf dem Rechner nicht verfügbar ist?**

Verwenden Sie [set_DefaultRegularFont](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) in [XamlOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export.xaml/xamloptions/) — es wird als Ersatzschrift verwendet, wenn die Originalschrift fehlt. Das verhindert unerwartete Ersetzungen.

**Ist das exportierte XAML nur für WPF gedacht oder kann es auch in anderen XAML‑Stacks verwendet werden?**

XAML ist eine allgemeine UI‑Markup‑Sprache, die in WPF, UWP und Xamarin.Forms verwendet wird. Der Export zielt auf die Kompatibilität mit den Microsoft‑XAML‑Stacks ab; das genaue Verhalten und die Unterstützung spezieller Konstrukte hängen von der Zielplattform ab. Testen Sie das Markup in Ihrer Umgebung.

**Werden versteckte Folien unterstützt und wie kann ich verhindern, dass sie standardmäßig exportiert werden?**

Standardmäßig werden versteckte Folien nicht einbezogen. Sie können dieses Verhalten über [set_ExportHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) in [XamlOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export.xaml/xamloptions/) steuern — lassen Sie es deaktiviert, wenn Sie sie nicht exportieren möchten.