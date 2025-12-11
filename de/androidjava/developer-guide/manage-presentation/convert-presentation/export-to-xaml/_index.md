---
title: Präsentationen nach XAML auf Android exportieren
linktitle: Präsentation zu XAML
type: docs
weight: 30
url: /de/androidjava/export-to-xaml/
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
- PPT speichern als XAML
- PPTX speichern als XAML
- ODP speichern als XAML
- PPT nach XAML exportieren
- PPTX nach XAML exportieren
- ODP nach XAML exportieren
- Android
- Java
- Aspose.Slides
description: "Konvertieren Sie PowerPoint- und OpenDocument-Folien zu XAML in Java mit Aspose.Slides für Android—schnelle, Office-freie Lösung, die Ihr Layout unverändert lässt."
---

## **Präsentationen nach XAML exportieren**

{{% alert color="primary" %}} 

In [Aspose.Slides 21.6](https://docs.aspose.com/slides/androidjava/aspose-slides-for-java-21-6-release-notes/) haben wir die Unterstützung für den XAML‑Export implementiert. Sie können nun Ihre Präsentationen nach XAML exportieren.

{{% /alert %}} 

## **Über XAML**

XAML ist eine beschreibende Programmiersprache, mit der Sie Benutzeroberflächen für Apps erstellen oder schreiben können, insbesondere für solche, die WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) und Xamarin Forms verwenden.  

XAML, eine XML‑basierte Sprache, ist Microsofts Variante zur Beschreibung einer GUI. Sie werden die meiste Zeit wahrscheinlich einen Designer verwenden, um an XAML‑Dateien zu arbeiten, können aber die GUI auch direkt schreiben und bearbeiten. 

## **Präsentationen nach XAML mit Standardeinstellungen exportieren**

Dieser Java‑Code zeigt Ihnen, wie Sie eine Präsentation mit den Standardeinstellungen nach XAML exportieren:
```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save(new XamlOptions());
} finally {
	if (pres != null) pres.dispose();
}
```


## **Präsentationen nach XAML mit benutzerdefinierten Optionen exportieren**

Sie können Optionen aus der [IXamlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IXamlOptions)-Schnittstelle auswählen, die den Exportvorgang steuern und bestimmen, wie Aspose.Slides Ihre Präsentation nach XAML exportiert.

Wenn Sie zum Beispiel möchten, dass Aspose.Slides beim Export nach XAML versteckte Folien aus Ihrer Präsentation hinzufügt, können Sie die Eigenschaft [ExportHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IXamlOptions#setExportHiddenSlides-boolean-) auf **true** setzen. Siehe diesen Beispiel‑Java‑Code:
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


## **FAQ**

**Wie kann ich sicherstellen, dass vorhersehbare Schriftarten verwendet werden, wenn die Originalschriftart auf dem System nicht verfügbar ist?**

Legen Sie in [eine Standardschriftart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) in [XamlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xamloptions/) fest — sie wird als Ersatzschriftart verwendet, wenn die Originalschriftart fehlt. Dies hilft, unerwartete Ersetzungen zu vermeiden.

**Ist das exportierte XAML nur für WPF gedacht, oder kann es auch in anderen XAML‑Stacks verwendet werden?**

XAML ist eine allgemeine UI‑Markup‑Sprache, die in WPF, UWP und Xamarin.Forms verwendet wird. Der Export zielt auf die Kompatibilität mit Microsoft‑XAML‑Stacks ab; das genaue Verhalten und die Unterstützung spezieller Konstrukte hängen von der Zielplattform ab. Testen Sie das Markup in Ihrer Umgebung.

**Werden versteckte Folien unterstützt und wie kann ich verhindern, dass sie standardmäßig exportiert werden?**

Standardmäßig werden versteckte Folien nicht einbezogen. Sie können dieses Verhalten über [setExportHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) in [XamlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xamloptions/) steuern — deaktivieren Sie es, wenn Sie die Folien nicht exportieren möchten.