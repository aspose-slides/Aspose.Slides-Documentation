---
title: Präsentationen nach XAML auf Android exportieren
linktitle: Präsentation nach XAML
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
- Android
- Java
- Aspose.Slides
description: "Konvertieren Sie PowerPoint- und OpenDocument-Folien in Java mit Aspose.Slides für Android - schnelle, Office-freie Lösung, die Ihr Layout unverändert beibehält."
---

## **Präsentationen nach XAML exportieren**

Aspose.Slides unterstützt den Export nach XAML. Sie können Ihre Präsentationen in XAML konvertieren.

## **Über XAML**

XAML ist eine beschreibende Programmiersprache, mit der Sie Benutzeroberflächen für Apps erstellen oder schreiben können, insbesondere für solche, die WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) und Xamarin-Forms verwenden.  

XAML, eine XML-basierte Sprache, ist Microsofts Variante zur Beschreibung einer GUI. Sie werden die meiste Zeit wahrscheinlich einen Designer verwenden, um an XAML-Dateien zu arbeiten, können aber auch Ihre GUI selbst schreiben und bearbeiten.

## **Präsentationen mit den Standardeinstellungen nach XAML exportieren**

Dieser Java-Code zeigt, wie Sie eine Präsentation mit den Standardeinstellungen nach XAML exportieren:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save(new XamlOptions());
} finally {
    if (pres != null) pres.dispose();
}
```


## **Präsentationen mit benutzerdefinierten Optionen nach XAML exportieren**

Sie können Optionen aus dem [IXamlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IXamlOptions)-Interface auswählen, die den Exportvorgang steuern und bestimmen, wie Aspose.Slides Ihre Präsentation nach XAML exportiert.

Zum Beispiel, wenn Sie möchten, dass Aspose.Slides beim Export nach XAML versteckte Folien Ihrer Präsentation einfügt, können Sie die Eigenschaft [ExportHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IXamlOptions#setExportHiddenSlides-boolean-) auf true setzen. Siehe dieses Beispiel-Java-Code:
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

**Wie kann ich vorhersehbare Schriftarten sicherstellen, wenn die Originalschriftart auf dem Rechner nicht verfügbar ist?**

Legen Sie in [XamlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xamloptions/) eine [Standard-Normalschriftart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) fest – sie wird als Ersatzschriftart verwendet, wenn die Originalschriftart fehlt. Das verhindert unerwartete Ersetzungen.

**Ist das exportierte XAML nur für WPF gedacht oder kann es auch in anderen XAML-Stacks verwendet werden?**

XAML ist eine allgemeine UI-Markup-Sprache, die in WPF, UWP und Xamarin.Forms verwendet wird. Der Export zielt auf die Kompatibilität mit den Microsoft-XAML-Stacks ab; das genaue Verhalten und die Unterstützung bestimmter Konstrukte hängen von der Zielplattform ab. Testen Sie das Markup in Ihrer Umgebung.

**Werden versteckte Folien unterstützt und wie kann ich verhindern, dass sie standardmäßig exportiert werden?**

Standardmäßig werden versteckte Folien nicht einbezogen. Sie können dieses Verhalten über [setExportHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) in [XamlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xamloptions/) steuern – deaktivieren Sie es, wenn Sie sie nicht exportieren möchten.