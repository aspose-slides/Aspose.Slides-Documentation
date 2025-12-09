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
- PPT zu XAML exportieren
- PPTX zu XAML exportieren
- ODP zu XAML exportieren
- .NET
- C#
- Aspose.Slides
description: "Konvertieren Sie PowerPoint- und OpenDocument‑Folien nach XAML in .NET mit Aspose.Slides — schnelle, Office‑freie Lösung, die Ihr Layout unverändert lässt."
---

# **Exportieren von Präsentationen nach XAML**

{{% alert title="Info" color="info" %}} 

In [Aspose.Slides 21.6](https://docs.aspose.com/slides/net/aspose-slides-for-net-21-6-release-notes/), haben wir die Unterstützung für den XAML-Export implementiert. Sie können Ihre Präsentationen jetzt nach XAML exportieren. 

{{% /alert %}} 

# **Über XAML**

XAML ist eine beschreibende Programmiersprache, die es Ihnen ermöglicht, Benutzeroberflächen für Apps zu erstellen oder zu schreiben, insbesondere für solche, die WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) und Xamarin Forms verwenden.  

XAML, das eine XML-basierte Sprache ist, ist Microsofts Variante zur Beschreibung einer GUI. Sie werden wahrscheinlich die meiste Zeit einen Designer verwenden, um an XAML‑Dateien zu arbeiten, aber Sie können Ihre GUI auch selbst schreiben und bearbeiten. 

## **Exportieren von Präsentationen nach XAML mit Standardoptionen**

Dieser C#‑Code zeigt, wie Sie eine Präsentation mit den Standardeinstellungen nach XAML exportieren:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save(new XamlOptions());
}
```


## **Exportieren von Präsentationen nach XAML mit benutzerdefinierten Optionen**

Sie können Optionen aus dem [IXamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions)‑Interface auswählen, die den Exportvorgang steuern und bestimmen, wie Aspose.Slides Ihre Präsentation nach XAML exportiert. 

Wenn Sie beispielsweise möchten, dass Aspose.Slides ausgeblendete Folien aus Ihrer Präsentation beim Export nach XAML hinzufügt, können Sie die [ExportHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions/properties/exporthiddenslides)‑Eigenschaft auf true setzen. Siehe diesen Beispiel‑C#‑Code: 
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save(new XamlOptions { ExportHiddenSlides = true });
}
```


## **FAQ**

**Wie kann ich vorhersehbare Schriften sicherstellen, wenn die Originalschriftart auf dem Computer nicht verfügbar ist?**

Setzen Sie [DefaultRegularFont](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/defaultregularfont/) in [XamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/) — es wird als Ersatzschriftart verwendet, wenn die Originalschriftart fehlt. Dies hilft, unerwartete Ersetzungen zu vermeiden.

**Ist das exportierte XAML nur für WPF gedacht oder kann es auch in anderen XAML‑Stacks verwendet werden?**

XAML ist eine allgemeine UI‑Markup‑Sprache, die in WPF, UWP und Xamarin.Forms verwendet wird. Der Export zielt auf Kompatibilität mit den Microsoft XAML‑Stacks ab; das genaue Verhalten und die Unterstützung spezifischer Konstrukte hängen von der Zielplattform ab. Testen Sie das Markup in Ihrer Umgebung.

**Werden ausgeblendete Folien unterstützt und wie kann ich verhindern, dass sie standardmäßig exportiert werden?**

Standardmäßig werden ausgeblendete Folien nicht einbezogen. Sie können dieses Verhalten über [ExportHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) in [XamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/) steuern — deaktivieren Sie es, wenn Sie sie nicht exportieren möchten.