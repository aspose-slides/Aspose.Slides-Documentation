---
title: Präsentationen nach XAML exportieren in .NET
linktitle: Präsentation zu XAML
type: docs
weight: 30
url: /de/net/export-to-xaml/
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
- .NET
- C#
- Aspose.Slides
description: "PowerPoint- und OpenDocument-Folien nach XAML in .NET mit Aspose.Slides konvertieren – schnelle, office-freie Lösung, die das Layout unverändert beibehält."
---

# **Exportieren von Präsentationen nach XAML**

{{% alert title="Info" color="info" %}} 
In [Aspose.Slides 21.6](https://docs.aspose.com/slides/net/aspose-slides-for-net-21-6-release-notes/), haben wir die Unterstützung für den XAML-Export implementiert. Sie können Ihre Präsentationen jetzt nach XAML exportieren. 
{{% /alert %}} 

# **Über XAML**

XAML ist eine beschreibende Programmiersprache, mit der Sie Benutzeroberflächen für Apps erstellen oder schreiben können, insbesondere für solche, die WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) und Xamarin Forms verwenden.  

XAML, eine XML-basierte Sprache, ist Microsofts Variante zur Beschreibung einer GUI. Sie verwenden wahrscheinlich meistens einen Designer, um an XAML‑Dateien zu arbeiten, können jedoch weiterhin Ihre GUI schreiben und bearbeiten. 

## **Exportieren von Präsentationen nach XAML mit Standardoptionen**

Dieser C#‑Code zeigt Ihnen, wie Sie eine Präsentation mit den Standardeinstellungen nach XAML exportieren:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save(new XamlOptions());
}
```


## **Exportieren von Präsentationen nach XAML mit benutzerdefinierten Optionen**

Sie können Optionen aus der Schnittstelle [IXamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions) auswählen, die den Exportvorgang steuern und bestimmen, wie Aspose.Slides Ihre Präsentation nach XAML exportiert. 

Wenn Sie beispielsweise möchten, dass Aspose.Slides beim Export nach XAML versteckte Folien aus Ihrer Präsentation hinzufügt, können Sie die Eigenschaft [ExportHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions/properties/exporthiddenslides) auf true setzen. Siehe diesen Beispiel‑C#‑Code: 
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save(new XamlOptions { ExportHiddenSlides = true });
}
```


## **FAQ**

**Wie kann ich vorhersehbare Schriftarten sicherstellen, wenn die Originalschriftart auf dem System nicht verfügbar ist?**

Setzen Sie [DefaultRegularFont](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/defaultregularfont/) in [XamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/) — diese wird als Ersatzschriftart verwendet, wenn die Originalschriftart fehlt. Das hilft, unerwartete Ersetzungen zu vermeiden.

**Ist das exportierte XAML nur für WPF gedacht oder kann es auch in anderen XAML‑Stacks verwendet werden?**

XAML ist eine allgemeine UI‑Markup‑Sprache, die in WPF, UWP und Xamarin.Forms verwendet wird. Der Export zielt auf die Kompatibilität mit Microsoft‑XAML‑Stacks ab; das genaue Verhalten und die Unterstützung bestimmter Konstrukte hängen von der Zielplattform ab. Testen Sie das Markup in Ihrer Umgebung.

**Werden versteckte Folien unterstützt und wie kann ich verhindern, dass sie standardmäßig exportiert werden?**

Standardmäßig werden versteckte Folien nicht einbezogen. Sie können dieses Verhalten über [ExportHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) in [XamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/) steuern – lassen Sie es deaktiviert, wenn Sie diese nicht exportieren müssen.