---
title: Export nach XAML
type: docs
weight: 30
url: /de/java/export-to-xaml/

---

# Präsentationen nach XAML exportieren

{{% alert color="primary" %}} 

In [Aspose.Slides 21.6](https://docs.aspose.com/slides/java/aspose-slides-for-java-21-6-release-notes/) haben wir die Unterstützung für den XAML-Export implementiert. Sie können jetzt Ihre Präsentationen nach XAML exportieren.

{{% /alert %}} 

# Über XAML

XAML ist eine beschreibende Programmiersprache, die es Ihnen ermöglicht, Benutzeroberflächen für Apps zu erstellen oder zu schreiben, insbesondere solche, die WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) und Xamarin-Formulare verwenden.  

XAML, eine XML-basierte Sprache, ist die Variante von Microsoft zur Beschreibung einer GUI. In der Regel werden Sie einen Designer verwenden, um an XAML-Dateien zu arbeiten, aber Sie können Ihre GUI dennoch schreiben und bearbeiten.

## Präsentationen nach XAML mit Standardoptionen exportieren

Dieser Java-Code zeigt Ihnen, wie Sie eine Präsentation mit den Standardeinstellungen nach XAML exportieren:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save(new XamlOptions());
} finally {
	if (pres != null) pres.dispose();
}
```

## Präsentationen nach XAML mit benutzerdefinierten Optionen exportieren

Sie können Optionen aus dem [IXamlOptions](https://reference.aspose.com/slides/java/com.aspose.slides/IXamlOptions) Interface auswählen, die den Exportprozess steuern und bestimmen, wie Aspose.Slides Ihre Präsentation in XAML exportiert. 

Wenn Sie beispielsweise möchten, dass Aspose.Slides beim Export nach XAML versteckte Folien aus Ihrer Präsentation hinzufügt, können Sie die Eigenschaft [ExportHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/IXamlOptions#setExportHiddenSlides-boolean-) auf true setzen. Sehen Sie sich diesen Beispiel-Java-Code an:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	XamlOptions xamlOptions = new XamlOptions();
	xamlOptions.setExportHiddenSlides(true);
	pres.save(xamlOptions);
} finally {
	if (pres != null) pres.dispose();
}
```