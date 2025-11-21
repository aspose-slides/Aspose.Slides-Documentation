---
title: Export nach XAML
type: docs
weight: 30
url: /de/nodejs-java/export-to-xaml/
---

## **Exportieren von Präsentationen nach XAML**

{{% alert color="primary" %}} 
In [Aspose.Slides 21.6](https://docs.aspose.com/slides/nodejs-java/aspose-slides-for-java-21-6-release-notes/), haben wir die Unterstützung für den XAML-Export implementiert. Sie können nun Ihre Präsentationen nach XAML exportieren.
{{% /alert %}} 

## **Über XAML**

XAML ist eine beschreibende Programmiersprache, die es Ihnen ermöglicht, Benutzerklassen für Apps zu erstellen oder zu schreiben, insbesondere für solche, die WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) und Xamarin Forms verwenden.

XAML, das eine XML-basierte Sprache ist, ist Microsofts Variante zur Beschreibung einer GUI. Sie werden wahrscheinlich die meiste Zeit einen Designer verwenden, um an XAML-Dateien zu arbeiten, können aber dennoch Ihre GUI schreiben und bearbeiten. 

## **Exportieren von Präsentationen nach XAML mit Standardoptionen**

Dieser JavaScript‑Code zeigt Ihnen, wie Sie eine Präsentation mit den Standardeinstellungen nach XAML exportieren:
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


## **Exportieren von Präsentationen nach XAML mit benutzerdefinierten Optionen**

Sie können Optionen aus der Klasse [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/XamlOptions) auswählen, die den Exportvorgang steuern und bestimmen, wie Aspose.Slides Ihre Präsentation nach XAML exportiert.

Zum Beispiel, wenn Sie möchten, dass Aspose.Slides beim Export nach XAML versteckte Folien Ihrer Präsentation hinzufügt, können Sie die Methode [setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/XamlOptions#setExportHiddenSlides-boolean-) auf true setzen. Siehe diesen Beispiel‑JavaScript‑Code:
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

**Wie kann ich vorhersehbare Schriftarten sicherstellen, wenn die Originalschriftart nicht auf dem Rechner vorhanden ist?**

Verwenden Sie [setDefaultRegularFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) in [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) — sie wird als Ersatzschriftart verwendet, wenn die Originalschriftart fehlt. Dies hilft, unerwartete Ersetzungen zu vermeiden.

**Ist das exportierte XAML nur für WPF gedacht oder kann es auch in anderen XAML‑Stacks verwendet werden?**

XAML ist eine allgemeine UI‑Markup‑Sprache, die in WPF, UWP und Xamarin.Forms verwendet wird. Der Export zielt auf die Kompatibilität mit Microsoft‑XAML‑Stacks ab; das genaue Verhalten und die Unterstützung bestimmter Konstrukte hängen von der Zielplattform ab. Testen Sie das Markup in Ihrer Umgebung.

**Werden versteckte Folien unterstützt und wie kann ich verhindern, dass sie standardmäßig exportiert werden?**

Standardmäßig werden versteckte Folien nicht eingeschlossen. Sie können dieses Verhalten über [setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/setexporthiddenslides/) in [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) steuern — lassen Sie es deaktiviert, wenn Sie sie nicht exportieren müssen.