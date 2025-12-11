---
title: PPT und PPTX auf Android in PDF konvertieren [Erweiterte Funktionen enthalten]
linktitle: PowerPoint zu PDF
type: docs
weight: 40
url: /de/androidjava/convert-powerpoint-to-pdf/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- PowerPoint zu PDF
- Präsentation zu PDF
- PPT zu PDF
- PPT zu PDF konvertieren
- PPTX zu PDF
- PPTX zu PDF konvertieren
- PowerPoint als PDF speichern
- PPT als PDF speichern
- PPTX als PDF speichern
- PPT nach PDF exportieren
- PPTX nach PDF exportieren
- PDF/A1a
- PDF/A1b
- PDF/UA
- Android
- Java
- Aspose.Slides
description: "PowerPoint PPT/PPTX in hochwertige, durchsuchbare PDFs in Java mit Aspose.Slides für Android konvertieren, mit schnellen Codebeispielen und erweiterten Konvertierungsoptionen."
---

## **Übersicht**

Das Konvertieren von PowerPoint‑Präsentationen (PPT, PPTX, ODP usw.) in das PDF‑Format unter Android bietet mehrere Vorteile, darunter Kompatibilität über verschiedene Geräte hinweg und die Beibehaltung von Layout und Formatierung Ihrer Präsentation. Dieser Leitfaden zeigt, wie Sie Präsentationen in PDF‑Dokumente konvertieren, verschiedene Optionen zur Steuerung der Bildqualität verwenden, versteckte Folien einbinden, PDF‑Dateien mit einem Passwort schützen, Font‑Substitutionen erkennen, bestimmte Folien für die Konvertierung auswählen und Compliance‑Standards auf Ausgabedokumente anwenden.

## **PowerPoint‑zu‑PDF‑Konvertierungen**

Mit Aspose.Slides können Sie Präsentationen in den folgenden Formaten in PDF konvertieren:

* **PPT**
* **PPTX**
* **ODP**

Um eine Präsentation in PDF zu konvertieren, übergeben Sie den Dateinamen als Argument an die Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) und speichern Sie die Präsentation anschließend mit einer `save`‑Methode als PDF. Die Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) stellt die `save`‑Methode bereit, die typischerweise zum Konvertieren einer Präsentation in PDF verwendet wird.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Android via Java fügt seinen API‑Informationen und die Versionsnummer in Ausgabedokumente ein. Zum Beispiel füllt Aspose.Slides beim Konvertieren einer Präsentation in PDF das Feld *Application* mit "*Aspose.Slides*" und das Feld *PDF Producer* mit einem Wert in der Form "*Aspose.Slides v XX.XX*". **Hinweis**, dass Sie Aspose.Slides nicht anweisen können, diese Informationen aus Ausgabedokumenten zu entfernen oder zu ändern.

{{% /alert %}}

Aspose.Slides ermöglicht es Ihnen, Folgendes zu konvertieren:

* Gesamte Präsentationen in PDF
* Bestimmte Folien einer Präsentation in PDF

Aspose.Slides exportiert Präsentationen nach PDF und stellt sicher, dass die resultierenden PDFs den Originalpräsentationen sehr nahe kommen. Elemente und Attribute werden bei der Konvertierung exakt gerendert, einschließlich:

* Bilder
* Textfelder und Formen
* Textformatierung
* Absatzformatierung
* Hyperlinks
* Kopf‑ und Fußzeilen
* Aufzählungszeichen
* Tabellen

## **PowerPoint in PDF konvertieren**

Der standardmäßige PowerPoint‑zu‑PDF‑Konvertierungsprozess verwendet Standardoptionen. In diesem Fall versucht Aspose.Slides, die bereitgestellte Präsentation mit optimalen Einstellungen und maximaler Qualität in PDF zu konvertieren.

```java
// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    // Speichern Sie die Präsentation als PDF.
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```


{{%  alert  color="primary"  %}} 

Aspose bietet einen kostenlosen Online-**[**PowerPoint-zu-PDF-Konverter**]**(https://products.aspose.app/slides/conversion/ppt-to-pdf), der den Präsentation‑zu‑PDF‑Konvertierungsprozess demonstriert. Sie können mit diesem Konverter einen Test für eine Live‑Implementierung des hier beschriebenen Verfahrens durchführen.

{{% /alert %}}

## **PowerPoint in PDF mit Optionen konvertieren**

Aspose.Slides stellt benutzerdefinierte Optionen — Eigenschaften der Klasse [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) — zur Verfügung, mit denen Sie das resultierende PDF anpassen, das PDF mit einem Passwort schützen oder festlegen können, wie der Konvertierungsprozess ablaufen soll.

### **PowerPoint in PDF mit benutzerdefinierten Optionen konvertieren**

Mit benutzerdefinierten Konvertierungsoptionen können Sie Ihre bevorzugten Bildeinstellungen für Rastergrafiken festlegen, bestimmen, wie Metadateien verarbeitet werden, ein Kompressionsniveau für Text setzen, die DPI für Bilder konfigurieren und mehr.

```java
// Instanziieren Sie die PdfOptions-Klasse.
PdfOptions pdfOptions = new PdfOptions();

// Legen Sie die Qualität für JPG-Bilder fest.
pdfOptions.setJpegQuality((byte)90);

// Legen Sie die DPI für Bilder fest.
pdfOptions.setSufficientResolution(300);

/// Legen Sie das Verhalten für Metadateien fest.
pdfOptions.setSaveMetafilesAsPng(true);

// Legen Sie das Textkomprimierungsniveau für Textinhalt fest.
pdfOptions.setTextCompression(PdfTextCompression.Flate);

// Definieren Sie den PDF-Compliance-Modus.
pdfOptions.setCompliance(PdfCompliance.Pdf15);

// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Speichern Sie die Präsentation als PDF-Dokument.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


### **PowerPoint in PDF mit versteckten Folien konvertieren**

Enthält eine Präsentation versteckte Folien, können Sie die Methode [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) der Klasse [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) verwenden, um die versteckten Folien als Seiten in das resultierende PDF einzufügen.

```java
// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Instanziieren Sie die PdfOptions-Klasse.
    PdfOptions pdfOptions = new PdfOptions();

    // Versteckte Folien hinzufügen.
    pdfOptions.setShowHiddenSlides(true);

    // Speichern Sie die Präsentation als PDF.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


### **PowerPoint in passwortgeschütztes PDF konvertieren**

Dieser Code demonstriert, wie Sie eine PowerPoint‑Präsentation mit den Schutzparametern der Klasse [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) in ein passwortgeschütztes PDF konvertieren:

```java
// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Instanziieren Sie die PdfOptions-Klasse.
    PdfOptions pdfOptions = new PdfOptions();

    // Legen Sie ein PDF-Passwort und Zugriffsberechtigungen fest.
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);

    // Speichern Sie die Präsentation als PDF.
    presentation.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


### **Font‑Substitutionen erkennen**

Aspose.Slides bietet die Methode [setWarningCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) unter der Klasse [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) an, um Font‑Substitutionen während des Präsentation‑zu‑PDF‑Konvertierungsprozesses zu erkennen.

```java
public static void main(String[] args) {
    // Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
    Presentation presentation = new Presentation("sample.pptx");

    // Setzen Sie den Warn-Callback in den PDF-Optionen.
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setWarningCallback(new FontSubstitutionHandler());

    // Speichern Sie die Präsentation als PDF.
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
}

// Implementierung des Warn-Callbacks.
private static class FontSubstitutionHandler implements IWarningCallback {
    public int warning(IWarningInfo warning) {
        if (warning.getWarningType() == WarningType.DataLoss &&
                warning.getDescription().startsWith("Font will be substituted")) {
            System.out.println("Font substitution warning: " + warning.getDescription());
        }

        return ReturnAction.Continue;
    }
}
```


{{%  alert color="primary"  %}} 

Weitere Informationen zum Empfangen von Warnrückrufen für Font‑Substitutionen während des Renderns finden Sie unter **[Abrufen von Warnrückrufen für Font‑Substitution]**(/slides/de/androidjava/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Weitere Informationen zu Font‑Substitutionen finden Sie im Artikel **[Font‑Substitution]**(/slides/de/androidjava/font-substitution/).

{{% /alert %}} 

## **Ausgewählte Folien aus PowerPoint in PDF konvertieren**

Dieser Code demonstriert, wie Sie nur bestimmte Folien einer PowerPoint‑Präsentation in PDF konvertieren:

```java
// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Array von Folienzahlen festlegen.
    int[] slides = { 1, 3 };

    // Speichern Sie die Präsentation als PDF.
    presentation.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```


## **PowerPoint in PDF mit benutzerdefinierter Foliengröße konvertieren**

Dieser Code demonstriert, wie Sie eine PowerPoint‑Präsentation mit einer festgelegten Foliengröße in PDF konvertieren:

```java
float slideWidth = 612;
float slideHeight = 792;

// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
Presentation presentation = new Presentation("SelectedSlides.pptx");

// Erstellen Sie eine neue Präsentation mit angepasster Foliengröße.
Presentation resizedPresentation = new Presentation();

try {
    // Legen Sie die benutzerdefinierte Foliengröße fest.
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

    // Klonen Sie die erste Folie aus der Originalpräsentation.
    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Speichern Sie die skalierte Präsentation als PDF mit Notizen.
    resizedPresentation.save("PDF_with_notes.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```


## **PowerPoint in PDF im Notiz‑Folien‑Modus konvertieren**

Dieser Code demonstriert, wie Sie eine PowerPoint‑Präsentation in ein PDF konvertieren, das Notizen enthält:

```java
// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    // Konfigurieren Sie die PDF-Optionen mit Notizen-Layout.
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // Speichern Sie die Präsentation als PDF mit Notizen.
    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


## **Barrierefreiheit und Compliance‑Standards für PDF**

Aspose.Slides ermöglicht ein Konvertierungsverfahren, das den [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) entspricht. Sie können ein PowerPoint‑Dokument mit einem der folgenden Compliance‑Standards in PDF exportieren: **PDF/A1a**, **PDF/A1b** und **PDF/UA**.

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();

    pdfOptions.setCompliance(PdfCompliance.PdfA1a);
    presentation.save("pres-a1a-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfA1b);
    presentation.save("pres-a1b-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfUa);
    presentation.save("pres-ua-compliance.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


{{% alert title="Note" color="warning" %}} 

Aspose.Slides unterstützt PDF‑Konvertierungsoperationen, mit denen Sie PDF‑Dateien in gängige Formate konvertieren können. Sie können **[PDF zu HTML]**(https://products.aspose.com/slides/java/conversion/pdf-to-html/), **[PDF zu Bild]**(https://products.aspose.com/slides/java/conversion/pdf-to-image/), **[PDF zu JPG]**(https://products.aspose.com/slides/java/conversion/pdf-to-jpg/) und **[PDF zu PNG]**(https://products.aspose.com/slides/java/conversion/pdf-to-png/) Konvertierungen durchführen. Weitere PDF‑Konvertierungen zu spezialisierten Formaten — **[PDF zu SVG]**(https://products.aspose.com/slides/java/conversion/pdf-to-svg/), **[PDF zu TIFF]**(https://products.aspose.com/slides/java/conversion/pdf-to-tiff/) und **[PDF zu XML]**(https://products.aspose.com/slides/java/conversion/pdf-to-xml/) — werden ebenfalls unterstützt.

{{% /alert %}}

## **FAQ**

**Kann ich mehrere PowerPoint‑Dateien stapelweise in PDF konvertieren?**

Ja, Aspose.Slides unterstützt die Stapelkonvertierung mehrerer PPT‑ oder PPTX‑Dateien in PDF. Sie können Ihre Dateien iterativ durchlaufen und den Konvertierungsprozess programmatisch anwenden.

**Ist es möglich, das konvertierte PDF mit einem Passwort zu schützen?**

Absolut. Verwenden Sie die Klasse [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/), um ein Passwort festzulegen und Zugriffsrechte während des Konvertierungsprozesses zu definieren.

**Wie kann ich versteckte Folien im PDF einbinden?**

Verwenden Sie die Methode `setShowHiddenSlides` in der Klasse [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/), um versteckte Folien in das resultierende PDF aufzunehmen.

**Kann Aspose.Slides eine hohe Bildqualität im PDF beibehalten?**

Ja, Sie können die Bildqualität steuern, indem Sie Methoden wie `setJpegQuality` und `setSufficientResolution` der Klasse [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) verwenden, um hochwertige Bilder in Ihrem PDF sicherzustellen.

**Unterstützt Aspose.Slides PDF/A‑Compliance‑Standards?**

Ja, Aspose.Slides ermöglicht das Exportieren von PDFs, die verschiedenen Standards entsprechen, darunter PDF/A1a, PDF/A1b und PDF/UA, sodass Ihre Dokumente Barrierefreiheit und Archivierungsanforderungen erfüllen.

## **Zusätzliche Ressourcen**

- [Aspose.Slides für Android via Java Dokumentation](/slides/de/androidjava/)
- [Aspose.Slides für Android via Java API‑Referenz](https://reference.aspose.com/slides/androidjava/)
- [Aspose Kostenlose Online‑Konverter](https://products.aspose.app/slides/conversion)