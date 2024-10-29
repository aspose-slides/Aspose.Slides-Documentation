---
title: Exportieren nach XAML
type: docs
weight: 30
url: /de/cpp/export-to-xaml/

---

# Präsentationen nach XAML exportieren

{{% alert color="primary" %}} 

In [Aspose.Slides 21.6](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-21-6-release-notes/) haben wir die Unterstützung für den XAML-Export implementiert. Sie können jetzt Ihre Präsentationen nach XAML exportieren. 

{{% /alert %}} 

# Über XAML

XAML ist eine beschreibende Programmiersprache, mit der Sie Benutzeroberflächen für Apps erstellen oder schreiben können, insbesondere für solche, die WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) und Xamarin-Formulare verwenden.  

XAML, eine XML-basierte Sprache, ist Microsofts Variante zur Beschreibung einer GUI. Wahrscheinlich werden Sie die meiste Zeit einen Designer verwenden, um an XAML-Dateien zu arbeiten, aber Sie können Ihre GUI auch selbst schreiben und bearbeiten. 

## Präsentationen nach XAML mit Standardoptionen exportieren

Dieser C++-Code zeigt, wie Sie eine Präsentation mit den Standardeinstellungen nach XAML exportieren:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(System::MakeObject<XamlOptions>());
```

## Präsentationen nach XAML mit benutzerdefinierten Optionen exportieren

Sie können Optionen aus dem [IXamlOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xaml.i_xaml_options) Interface auswählen, die den Exportprozess steuern und bestimmen, wie Aspose.Slides Ihre Präsentation nach XAML exportiert. 

Wenn Sie beispielsweise möchten, dass Aspose.Slides beim Export nach XAML versteckte Folien aus Ihrer Präsentation hinzufügt, können Sie den Wert true an die [set_ExportHiddenSlides()](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xaml.i_xaml_options#a94c59a06cc2163b17e6fa2fe817c0313) Methode übergeben. Sehen Sie sich diesen Beispiel-C++-Code an: 

``` cpp
auto xamlOptions = System::MakeObject<XamlOptions>();
xamlOptions->set_ExportHiddenSlides(true);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(xamlOptions);
```