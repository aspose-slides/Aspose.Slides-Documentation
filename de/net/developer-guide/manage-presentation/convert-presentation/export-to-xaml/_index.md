---
title: Präsentationen nach XAML in .NET exportieren
linktitle: Präsentation nach XAML
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
- .NET
- C#
- Aspose.Slides
description: "Konvertieren Sie PowerPoint- und OpenDocument-Folien in XAML unter .NET mit Aspose.Slides - schnelle, Office-freie Lösung, die Ihr Layout unverändert beibehält."
---

# **Präsentationen nach XAML exportieren**

{{% alert title="Info" color="info" %}} 

In [Aspose.Slides 21.6](https://docs.aspose.com/slides/net/aspose-slides-for-net-21-6-release-notes/), haben wir die Unterstützung für XAML-Export implementiert. Sie können jetzt Ihre Präsentationen nach XAML exportieren. 

{{% /alert %}} 

# **Über XAML**

XAML ist eine beschreibende Programmiersprache, die es Ihnen ermöglicht, Benutzeroberflächen für Apps zu erstellen oder zu schreiben, insbesondere für solche, die WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) und Xamarin Forms verwenden.  

XAML, das eine XML-basierte Sprache ist, ist Microsofts Variante zur Beschreibung einer GUI. Wahrscheinlich verwenden Sie die meiste Zeit einen Designer, um an XAML-Dateien zu arbeiten, aber Sie können die GUI auch selbst schreiben und bearbeiten. 

## **Präsentationen nach XAML mit Standardoptionen exportieren**

Dieser C#-Code zeigt, wie Sie eine Präsentation mit den Standardeinstellungen nach XAML exportieren:  
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save(new XamlOptions());
}
```


## **Präsentationen nach XAML mit benutzerdefinierten Optionen exportieren**

Sie können Optionen aus der Schnittstelle [IXamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions) auswählen, die den Exportvorgang steuern und festlegen, wie Aspose.Slides Ihre Präsentation nach XAML exportiert. 

Wenn Sie beispielsweise möchten, dass Aspose.Slides beim Export nach XAML versteckte Folien Ihrer Präsentation hinzufügt, können Sie die Eigenschaft [ExportHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions/properties/exporthiddenslides) auf true setzen. Siehe diesen Beispiel-C#-Code:  
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save(new XamlOptions { ExportHiddenSlides = true });
}
```


## **FAQ**

**Wie kann ich vorhersehbare Schriftarten sicherstellen, wenn die Originalschriftart auf dem Rechner nicht verfügbar ist?**

Setzen Sie [DefaultRegularFont](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/defaultregularfont/) in [XamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/) - es wird als Ersatzschriftart verwendet, wenn die Originalschriftart fehlt. Das verhindert unerwartete Ersetzungen.

**Ist das exportierte XAML nur für WPF gedacht, oder kann es auch in anderen XAML-Stacks verwendet werden?**

XAML ist eine allgemeine UI-Markup-Sprache, die in WPF, UWP und Xamarin.Forms verwendet wird. Der Export zielt auf die Kompatibilität mit Microsoft-XAML-Stacks ab; das genaue Verhalten und die Unterstützung bestimmter Konstrukte hängen von der Zielplattform ab. Testen Sie das Markup in Ihrer Umgebung.

**Werden versteckte Folien unterstützt und wie kann ich verhindern, dass sie standardmäßig exportiert werden?**

Standardmäßig werden versteckte Folien nicht einbezogen. Sie können dieses Verhalten über [ExportHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) in [XamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/) steuern - lassen Sie es deaktiviert, wenn Sie sie nicht exportieren müssen.