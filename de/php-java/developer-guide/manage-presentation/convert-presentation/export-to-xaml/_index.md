---
title: Präsentationen nach XAML exportieren in PHP
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
- PPT zu XAML exportieren
- PPTX zu XAML exportieren
- ODP zu XAML exportieren
- PHP
- Aspose.Slides
description: "Konvertieren Sie PowerPoint- und OpenDocument-Folien zu XAML mit Aspose.Slides für PHP über Java — schnelle, Office-freie Lösung, die Ihr Layout unverändert lässt."
---


## **Exportieren von Präsentationen nach XAML**

Aspose.Slides unterstützt den XAML‑Export. Sie können Ihre Präsentationen in XAML konvertieren.

## **Über XAML**

XAML ist eine beschreibende Programmiersprache, mit der Sie Benutzeroberflächen für Apps erstellen oder schreiben können, insbesondere für solche, die WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) und Xamarin‑Forms verwenden.  

XAML, das auf XML basiert, ist Microsofts Variante zur Beschreibung einer GUI. Sie arbeiten wahrscheinlich die meiste Zeit mit einem Designer an XAML‑Dateien, können aber dennoch Ihre GUI schreiben und bearbeiten.

## **Exportieren von Präsentationen nach XAML mit Standardeinstellungen**

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


## **Exportieren von Präsentationen nach XAML mit benutzerdefinierten Einstellungen**

Sie können Optionen aus der [XamlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/)‑Klasse auswählen, die den Exportvorgang steuern und festlegen, wie Aspose.Slides Ihre Präsentation nach XAML exportiert.

Wenn Sie beispielsweise möchten, dass Aspose.Slides ausgeblendete Folien aus Ihrer Präsentation hinzufügen, wenn sie nach XAML exportiert wird, können Sie die Methode [setExportHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/setexporthiddenslides/) mit dem Wert `true` verwenden. Siehe diesen Beispiel‑PHP‑Code:
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

**Wie kann ich sicherstellen, dass vorhersehbare Schriftarten verwendet werden, wenn die Originalschriftart auf dem Rechner nicht verfügbar ist?**

Legen Sie in [XamlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/) eine [Standard‑Regulärschriftart](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) fest – diese wird als Ersatzschriftart verwendet, wenn die Originalschrift fehlt. So vermeiden Sie unerwartete Ersetzungen.

**Ist das exportierte XAML ausschließlich für WPF gedacht oder kann es auch in anderen XAML‑Stacks verwendet werden?**

XAML ist eine allgemeine UI‑Markup‑Sprache, die in WPF, UWP und Xamarin.Forms eingesetzt wird. Der Export zielt auf die Kompatibilität mit Microsoft‑XAML‑Stacks ab; das genaue Verhalten und die Unterstützung spezifischer Konstrukte hängen von der Zielplattform ab. Testen Sie das Markup in Ihrer Umgebung.

**Werden ausgeblendete Folien unterstützt und wie kann ich verhindern, dass sie standardmäßig exportiert werden?**

Standardmäßig werden ausgeblendete Folien nicht einbezogen. Sie können dieses Verhalten über [setExportHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/setexporthiddenslides/) in [XamlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/) steuern – lassen Sie die Option deaktiviert, wenn Sie sie nicht exportieren möchten.