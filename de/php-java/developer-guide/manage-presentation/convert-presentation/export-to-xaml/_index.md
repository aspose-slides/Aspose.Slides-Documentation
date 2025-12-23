---
title: Präsentationen nach XAML in PHP exportieren
linktitle: Präsentation zu XAML
type: docs
weight: 30
url: /de/php-java/export-to-xaml/
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
- PHP
- Aspose.Slides
description: "Konvertieren Sie PowerPoint- und OpenDocument-Folien mit Aspose.Slides für PHP über Java in XAML – eine schnelle, Office-freie Lösung, die Ihr Layout unverändert beibehält."
---

## **Präsentationen nach XAML exportieren**

{{% alert color="primary" %}} 

In [Aspose.Slides 21.6](https://docs.aspose.com/slides/php-java/aspose-slides-for-java-21-6-release-notes/), haben wir Unterstützung für den XAML-Export implementiert. Sie können jetzt Ihre Präsentationen nach XAML exportieren.

{{% /alert %}} 

## **Über XAML**

XAML ist eine deklarative Programmiersprache, mit der Sie Benutzeroberflächen für Anwendungen erstellen oder schreiben können, insbesondere solche, die WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) und Xamarin Forms verwenden.  

XAML, eine XML-basierte Sprache, ist Microsofts Variante zur Beschreibung einer GUI. Sie arbeiten wahrscheinlich die meiste Zeit mit einem Designer an XAML‑Dateien, können aber die GUI auch selbst schreiben und bearbeiten. 

## **Präsentationen nach XAML mit Standardeinstellungen exportieren**

Dieser PHP‑Code zeigt, wie Sie eine Präsentation mit den Standardeinstellungen nach XAML exportieren:
```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save(new XamlOptions());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Präsentationen nach XAML mit benutzerdefinierten Optionen exportieren**

Sie können Optionen aus der [IXamlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/IXamlOptions)-Schnittstelle auswählen, die den Exportprozess steuern und bestimmen, wie Aspose.Slides Ihre Präsentation nach XAML exportiert.

Beispielsweise können Sie, wenn Sie möchten, dass Aspose.Slides ausgeblendete Folien aus Ihrer Präsentation beim Export nach XAML hinzufügt, die Eigenschaft [ExportHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/IXamlOptions#setExportHiddenSlides-boolean-) auf **true** setzen. Siehe diesen Beispiel‑PHP‑Code:
```php
  $pres = new Presentation("pres.pptx");
  try {
    $xamlOptions = new XamlOptions();
    $xamlOptions->setExportHiddenSlides(true);
    $pres->save($xamlOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Wie kann ich vorhersehbare Schriftarten sicherstellen, wenn die Originalschriftart nicht auf dem Rechner verfügbar ist?**

Legen Sie in [XamlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/) eine [Standard‑Regelschriftart](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) fest — sie wird als Ersatzschriftart verwendet, wenn die Originalschriftart fehlt. Das verhindert unerwartete Ersetzungen.

**Ist das exportierte XAML nur für WPF vorgesehen, oder kann es auch in anderen XAML‑Stacks verwendet werden?**

XAML ist eine allgemeine UI‑Markup‑Sprache, die in WPF, UWP und Xamarin.Forms verwendet wird. Der Export zielt auf die Kompatibilität mit Microsoft‑XAML‑Stacks ab; das genaue Verhalten und die Unterstützung bestimmter Konstrukte hängen von der Zielplattform ab. Testen Sie das Markup in Ihrer Umgebung.

**Werden ausgeblendete Folien unterstützt, und wie kann ich verhindern, dass sie standardmäßig exportiert werden?**

Standardmäßig werden ausgeblendete Folien nicht einbezogen. Sie können dieses Verhalten über [setExportHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/setexporthiddenslides/) in [XamlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/) steuern — lassen Sie die Option deaktiviert, wenn Sie sie nicht exportieren möchten.