---
title: Präsentationen nach XAML in C++ exportieren
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
- PowerPoint zu XAML
- OpenDocument zu XAML
- Präsentation zu XAML
- PPT zu XAML
- PPTX zu XAML
- ODP zu XAML
- PPT als XAML speichern
- PPTX als XAML speichern
- ODP als XAML speichern
- PPT nach XAML exportieren
- PPTX nach XAML exportieren
- ODP nach XAML exportieren
- C++
- Aspose.Slides
description: "Konvertieren Sie PowerPoint- und OpenDocument-Folien nach XAML in C++ mit Aspose.Slides -- eine schnelle, Office-freie Lösung, die Ihr Layout unverändert lässt."
---

## **Präsentationen nach XAML exportieren**

{{% alert color="primary" %}} 

In [Aspose.Slides 21.6](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-21-6-release-notes/), haben wir die Unterstützung für den XAML-Export implementiert. Sie können jetzt Ihre Präsentationen nach XAML exportieren. 

{{% /alert %}} 

## **Über XAML**

XAML ist eine beschreibende Programmiersprache, die es Ihnen ermöglicht, Benutzeroberflächen für Apps zu erstellen oder zu schreiben, insbesondere für solche, die WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) und Xamarin Forms verwenden.  

XAML, eine XML-basierte Sprache, ist Microsofts Variante zur Beschreibung einer GUI. Wahrscheinlich verwenden Sie die meiste Zeit einen Designer, um an XAML-Dateien zu arbeiten, aber Sie können die GUI auch selbst schreiben und bearbeiten. 

## **Präsentationen nach XAML mit Standardoptionen exportieren**

Dieser C++-Code zeigt, wie Sie eine Präsentation mit den Standardeinstellungen nach XAML exportieren:
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(System::MakeObject<XamlOptions>());
```


## **Präsentationen nach XAML mit benutzerdefinierten Optionen exportieren**

Sie können Optionen aus der Schnittstelle [IXamlOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xaml.i_xaml_options) auswählen, die den Exportvorgang steuern und bestimmen, wie Aspose.Slides Ihre Präsentation nach XAML exportiert. 

Zum Beispiel können Sie, wenn Sie möchten, dass Aspose.Slides versteckte Folien aus Ihrer Präsentation beim Export nach XAML hinzufügt, den Wert true an die Methode [set_ExportHiddenSlides()](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xaml.i_xaml_options#a94c59a06cc2163b17e6fa2fe817c0313) übergeben. Siehe diesen Beispiel-C++-Code: 
``` cpp
auto xamlOptions = System::MakeObject<XamlOptions>();
xamlOptions->set_ExportHiddenSlides(true);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(xamlOptions);
```


## **FAQ**

**Wie kann ich sicherstellen, dass vorhersehbare Schriftarten verwendet werden, wenn die Originalschriftart nicht auf dem Rechner vorhanden ist?**

Verwenden Sie [set_DefaultRegularFont](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) in [XamlOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export.xaml/xamloptions/) — sie wird als Ersatzschriftart verwendet, wenn die Originalschriftart fehlt. Das hilft, unerwartete Ersatzschriften zu vermeiden.

**Ist das exportierte XAML nur für WPF gedacht oder kann es auch in anderen XAML-Stacks verwendet werden?**

XAML ist eine allgemeine UI-Markup-Sprache, die in WPF, UWP und Xamarin.Forms verwendet wird. Der Export zielt auf Kompatibilität mit Microsoft-XAML-Stacks; das genaue Verhalten und die Unterstützung bestimmter Konstrukte hängen von der Zielplattform ab. Testen Sie das Markup in Ihrer Umgebung.

**Werden versteckte Folien unterstützt und wie kann ich verhindern, dass sie standardmäßig exportiert werden?**

Standardmäßig werden versteckte Folien nicht eingeschlossen. Sie können dieses Verhalten über [set_ExportHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) in [XamlOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export.xaml/xamloptions/) steuern — lassen Sie es deaktiviert, wenn Sie sie nicht exportieren möchten.