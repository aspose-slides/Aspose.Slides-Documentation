---
title: Export nach XAML
type: docs
weight: 30
url: /de/php-java/export-to-xaml/

---

# Präsentationen nach XAML exportieren

{{% alert color="primary" %}} 

In [Aspose.Slides 21.6](https://docs.aspose.com/slides/php-java/aspose-slides-for-java-21-6-release-notes/) haben wir die Unterstützung für den XAML-Export implementiert. Sie können jetzt Ihre Präsentationen nach XAML exportieren.

{{% /alert %}} 

# Über XAML

XAML ist eine beschreibende Programmiersprache, die es Ihnen ermöglicht, Benutzeroberflächen für Apps zu erstellen oder zu schreiben, insbesondere für solche, die WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) und Xamarin-Formulare verwenden.

XAML, eine XML-basierte Sprache, ist Microsofts Variante zur Beschreibung einer GUI. Sie werden höchstwahrscheinlich einen Designer verwenden, um an XAML-Dateien zu arbeiten, aber Sie können Ihre Benutzeroberfläche auch selbst schreiben und bearbeiten.

## Präsentationen nach XAML mit Standardoptionen exportieren

Dieser PHP-Code zeigt Ihnen, wie Sie eine Präsentation mit den Standardeinstellungen nach XAML exportieren:

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

## Präsentationen nach XAML mit benutzerdefinierten Optionen exportieren

Sie können Optionen aus der [IXamlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/IXamlOptions) Schnittstelle auswählen, die den Exportprozess steuern und festlegen, wie Aspose.Slides Ihre Präsentation nach XAML exportiert.

Wenn Sie beispielsweise möchten, dass Aspose.Slides versteckte Folien aus Ihrer Präsentation beim Export nach XAML hinzufügt, können Sie die Eigenschaft [ExportHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/IXamlOptions#setExportHiddenSlides-boolean-) auf true setzen. Sehen Sie sich diesen Beispiel-PHP-Code an:

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