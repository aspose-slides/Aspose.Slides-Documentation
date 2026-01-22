---
title: Präsentationen nach XAML in JavaScript exportieren
linktitle: Präsentation nach XAML
type: docs
weight: 30
url: /de/nodejs-java/export-to-xaml/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Konvertieren Sie PowerPoint- und OpenDocument-Folien nach XAML in JavaScript mit Aspose.Slides für Node.js - schnelle, Office-freie Lösung, die Ihr Layout unverändert lässt."
---

## **Exportieren von Präsentationen nach XAML**

Aspose.Slides unterstützt den XAML‑Export. Sie können Ihre Präsentationen in XAML konvertieren.

## **Über XAML**

XAML ist eine beschreibende Programmiersprache, die es Ihnen ermöglicht, Benutzerklassen für Apps zu erstellen oder zu schreiben, insbesondere für solche, die WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) und Xamarin Forms verwenden.

XAML, das eine XML-basierte Sprache ist, ist Microsofts Variante zur Beschreibung einer GUI. Sie werden höchstwahrscheinlich die meiste Zeit einen Designer verwenden, um an XAML-Dateien zu arbeiten, aber Sie können Ihre GUI weiterhin schreiben und bearbeiten.

## **Exportieren von Präsentationen nach XAML mit Standardoptionen**

Dieser JavaScript-Code zeigt Ihnen, wie Sie eine Präsentation mit den Standardeinstellungen nach XAML exportieren:
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

Sie können Optionen aus der Klasse [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/XamlOptions) auswählen, die den Exportvorgang steuern und festlegen, wie Aspose.Slides Ihre Präsentation nach XAML exportiert.

Zum Beispiel, wenn Sie möchten, dass Aspose.Slides beim Exportieren nach XAML versteckte Folien aus Ihrer Präsentation hinzufügt, können Sie die Methode [setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/XamlOptions#setExportHiddenSlides-boolean-) auf true setzen. Siehe diesen Beispiel-JavaScript-Code:
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

**Wie kann ich vorhersehbare Schriftarten sicherstellen, wenn die Originalschriftart auf dem Rechner nicht verfügbar ist?**

Verwenden Sie [setDefaultRegularFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) in [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) — sie wird als Ersatzschriftart verwendet, wenn die Originalschriftart fehlt. Das hilft, unerwartete Ersetzungen zu vermeiden.

**Ist das exportierte XAML nur für WPF gedacht, oder kann es auch in anderen XAML-Stacks verwendet werden?**

XAML ist eine allgemeine UI-Markup-Sprache, die in WPF, UWP und Xamarin.Forms verwendet wird. Der Export zielt auf die Kompatibilität mit Microsoft-XAML-Stacks ab; das genaue Verhalten und die Unterstützung spezifischer Konstrukte hängen von der Zielplattform ab. Testen Sie das Markup in Ihrer Umgebung.

**Werden versteckte Folien unterstützt und wie kann ich verhindern, dass sie standardmäßig exportiert werden?**

Standardmäßig werden versteckte Folien nicht einbezogen. Sie können dieses Verhalten über [setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/setexporthiddenslides/) in [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) steuern — lassen Sie es deaktiviert, wenn Sie sie nicht exportieren müssen.