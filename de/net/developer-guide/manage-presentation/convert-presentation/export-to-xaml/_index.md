---
title: Export nach XAML
type: docs
weight: 30
url: /de/net/export-to-xaml/
keywords: "PowerPoint-Präsentation exportieren, PowerPoint konvertieren, XAML, PowerPoint nach XAML, PPT nach XAML, PPTX nach XAML, C#, Csharp, .NET"
description: "Exportieren oder konvertieren Sie eine PowerPoint-Präsentation nach XAML"
---

# Exportieren von Präsentationen nach XAML

{{% alert title="Info" color="info" %}} 

In [Aspose.Slides 21.6](https://docs.aspose.com/slides/net/aspose-slides-for-net-21-6-release-notes/) haben wir die Unterstützung für den XAML-Export implementiert. Sie können jetzt Ihre Präsentationen nach XAML exportieren. 

{{% /alert %}} 

# Über XAML

XAML ist eine beschreibende Programmiersprache, die es Ihnen ermöglicht, Benutzeroberflächen für Apps zu erstellen oder zu schreiben, insbesondere für solche, die WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) und Xamarin-Formulare verwenden.  

XAML, eine XML-basierte Sprache, ist die Variante von Microsoft zur Beschreibung einer GUI. In den meisten Fällen werden Sie wahrscheinlich einen Designer verwenden, um an XAML-Dateien zu arbeiten, aber Sie können Ihre GUI auch weiterhin schreiben und bearbeiten. 

## Exportieren von Präsentationen nach XAML mit Standardoptionen

Dieser C#-Code zeigt Ihnen, wie Sie eine Präsentation mit Standardeinstellungen nach XAML exportieren:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save(new XamlOptions());
}
```

## Exportieren von Präsentationen nach XAML mit benutzerdefinierten Optionen

Sie können Optionen aus dem [IXamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions) Schnittstelle auswählen, die den Exportprozess steuern und bestimmen, wie Aspose.Slides Ihre Präsentation nach XAML exportiert. 

Wenn Sie beispielsweise möchten, dass Aspose.Slides beim Exportieren Ihrer Präsentation nach XAML verborgene Folien hinzufügt, können Sie die [ExportHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions/properties/exporthiddenslides) -Eigenschaft auf true setzen. Siehe diesen Beispiel-C#-Code: 

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save(new XamlOptions { ExportHiddenSlides = true });
}
```