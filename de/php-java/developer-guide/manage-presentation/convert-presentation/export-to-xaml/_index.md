---
title: Präsentationen nach XAML in PHP exportieren
linktitle: Präsentation nach XAML
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
description: "Konvertieren Sie PowerPoint- und OpenDocument-Folien zu XAML mit Aspose.Slides für PHP über Java - schnelle, Office-freie Lösung, die das Layout unverändert beibehält."
---

## **Präsentationen nach XAML exportieren**

{{% alert color="primary" %}} 
In [Aspose.Slides 21.6](https://docs.aspose.com/slides/php-java/aspose-slides-for-java-21-6-release-notes/), haben wir die Unterstützung für den XAML-Export implementiert. Sie können jetzt Ihre Präsentationen nach XAML exportieren.
{{% /alert %}} 

## **Über XAML**

XAML ist eine beschreibende Programmiersprache, mit der Sie Benutzeroberflächen für Apps erstellen oder schreiben können, insbesondere für solche, die WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) und Xamarin Forms verwenden.  

XAML, das eine XML-basierte Sprache ist, ist Microsofts Variante zur Beschreibung einer GUI. Sie werden höchstwahrscheinlich die meiste Zeit einen Designer verwenden, um an XAML-Dateien zu arbeiten, aber Sie können Ihre GUI weiterhin manuell schreiben und bearbeiten. 

## **Präsentationen nach XAML mit Standardoptionen exportieren**

Dieser PHP-Code zeigt, wie man eine Präsentation mit den Standardeinstellungen nach XAML exportiert:
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

Sie können Optionen aus der Klasse [XamlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/) auswählen, die den Exportvorgang steuern und festlegen, wie Aspose.Slides Ihre Präsentation nach XAML exportiert.

Zum Beispiel, wenn Sie möchten, dass Aspose.Slides versteckte Folien aus Ihrer Präsentation beim Export nach XAML hinzufügt, können Sie die Methode [setExportHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/setexporthiddenslides/) mit dem Wert `true` verwenden. Siehe diesen Beispiel-PHP-Code:
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

**Wie kann ich vorhersehbare Schriftarten sicherstellen, wenn die ursprüngliche Schriftart auf dem Rechner nicht verfügbar ist?**

Setzen Sie [eine Standardschriftart](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) in [XamlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/) — sie wird als Ersatzschriftart verwendet, wenn die ursprüngliche fehlt. Dies hilft, unerwartete Ersetzungen zu vermeiden.

**Ist das exportierte XAML nur für WPF gedacht, oder kann es auch in anderen XAML-Stacks verwendet werden?**

XAML ist eine allgemeine UI-Markup-Sprache, die in WPF, UWP und Xamarin.Forms verwendet wird. Der Export zielt auf die Kompatibilität mit Microsoft XAML-Stacks ab; das genaue Verhalten und die Unterstützung bestimmter Konstrukte hängen von der Zielplattform ab. Testen Sie das Markup in Ihrer Umgebung.

**Werden versteckte Folien unterstützt und wie kann ich verhindern, dass sie standardmäßig exportiert werden?**

Standardmäßig werden versteckte Folien nicht einbezogen. Sie können dieses Verhalten über [setExportHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/setexporthiddenslides/) in [XamlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/) steuern — deaktivieren Sie es, wenn Sie sie nicht exportieren müssen.