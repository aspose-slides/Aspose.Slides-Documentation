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
description: "Konvertieren Sie PowerPoint- und OpenDocument-Folien zu XAML in .NET mit Aspose.Slides — eine schnelle, Office-freie Lösung, die Ihr Layout unverändert lässt."
---

## **Präsentationen nach XAML exportieren**

{{% alert title="Info" color="info" %}} 

In [Aspose.Slides 21.6](https://docs.aspose.com/slides/net/aspose-slides-for-net-21-6-release-notes/), haben wir die Unterstützung für den XAML‑Export implementiert. Sie können jetzt Ihre Präsentationen nach XAML exportieren. 

{{% /alert %}} 

## **Über XAML**

XAML ist eine beschreibende Programmiersprache, die es Ihnen ermöglicht, Benutzeroberflächen für Apps zu erstellen oder zu schreiben, insbesondere für solche, die WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) und Xamarin Forms verwenden.  

XAML, das eine XML‑basierte Sprache ist, ist Microsofts Variante zur Beschreibung einer GUI. Sie werden wahrscheinlich die meiste Zeit einen Designer verwenden, um an XAML‑Dateien zu arbeiten, aber Sie können Ihre GUI auch selbst schreiben und bearbeiten. 

## **Präsentationen nach XAML mit Standardeinstellungen exportieren**

Dieser C#‑Code zeigt, wie Sie eine Präsentation mit den Standardeinstellungen nach XAML exportieren:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save(new XamlOptions());
}
```


## **Präsentationen nach XAML mit benutzerdefinierten Optionen exportieren**

Sie können Optionen aus der [IXamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions)-Schnittstelle auswählen, die den Exportvorgang steuern und bestimmen, wie Aspose.Slides Ihre Präsentation nach XAML exportiert. 

Zum Beispiel, wenn Sie möchten, dass Aspose.Slides verborgene Folien Ihrer Präsentation beim Export nach XAML hinzufügt, können Sie die [ExportHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions/properties/exporthiddenslides)-Eigenschaft auf true setzen. Siehe diesen Beispiel‑C#‑Code: 
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save(new XamlOptions { ExportHiddenSlides = true });
}
```


## **FAQ**

**Wie kann ich vorhersehbare Schriftarten sicherstellen, wenn die Originalschriftart auf dem Rechner nicht verfügbar ist?**

Setzen Sie [DefaultRegularFont](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/defaultregularfont/) in [XamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/) — sie wird als Ersatzschriftart verwendet, wenn die Originalschriftart fehlt. Das verhindert unerwartete Ersetzungen.

**Ist das exportierte XAML nur für WPF gedacht, oder kann es auch in anderen XAML‑Stacks verwendet werden?**

XAML ist eine allgemeine UI‑Markup‑Sprache, die in WPF, UWP und Xamarin.Forms verwendet wird. Der Export zielt auf die Kompatibilität mit Microsoft‑XAML‑Stacks ab; das genaue Verhalten und die Unterstützung bestimmter Konstrukte hängen von der Zielplattform ab. Testen Sie das Markup in Ihrer Umgebung.

**Werden verborgene Folien unterstützt und wie kann ich verhindern, dass sie standardmäßig exportiert werden?**

Standardmäßig werden verborgene Folien nicht einbezogen. Sie können dieses Verhalten über [ExportHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) in [XamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/) steuern — lassen Sie es deaktiviert, wenn Sie sie nicht exportieren möchten.