---
title: PowerPoint in PDF in Java konvertieren
linktitle: PowerPoint in PDF konvertieren
type: docs
weight: 40
url: /androidjava/convert-powerpoint-to-pdf/
keywords:
- PowerPoint konvertieren
- Präsentation
- PowerPoint in PDF
- PPT in PDF
- PPTX in PDF
- PowerPoint als PDF speichern
- PDF/A1a
- PDF/A1b
- PDF/UA
- Java
- Aspose.Slides für Android über Java
description: "Konvertieren Sie PowerPoint-Präsentationen in PDF in Java. Speichern Sie PowerPoint als PDF unter Einhaltung von Compliance- oder Zugänglichkeitsstandards."
---

## **Übersicht**

Die Konvertierung von PowerPoint-Dokumenten in das PDF-Format bietet mehrere Vorteile, darunter die Gewährleistung der Kompatibilität auf verschiedenen Geräten und die Bewahrung des Layouts und der Formatierung Ihrer Präsentation. Dieser Artikel zeigt Ihnen, wie Sie Präsentationen in PDF-Dokumente umwandeln, verschiedene Optionen zur Steuerung der Bildqualität verwenden, versteckte Folien einfügen, PDF-Dokumente mit Passwörtern schützen, Schriftartsubstitutionen erkennen, Folien zur Konvertierung auswählen und Compliance-Standards auf Ausgabedokumente anwenden.

## **PowerPoint in PDF Konversionen**

Mit Aspose.Slides können Sie Präsentationen in diesen Formaten in PDF konvertieren:

* PPT
* PPTX
* ODP

Um eine Präsentation in PDF zu konvertieren, müssen Sie einfach den Dateinamen als Argument in der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) -Klasse übergeben und dann die Präsentation als PDF mit einer [Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) -Methode speichern. Die [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) -Klasse stellt die [Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) -Methode zur Verfügung, die typischerweise verwendet wird, um eine Präsentation in PDF zu konvertieren.

{{%  alert title="HINWEIS"  color="warning"   %}} 

Aspose.Slides für Android über Java schreibt direkt API-Informationen und Versionsnummer in Ausgabedokumente. Wenn beispielsweise eine Präsentation in PDF konvertiert wird, wird das Anwendungsfeld mit dem Wert '*Aspose.Slides*' und das PDF-Producers-Feld mit einem Wert in der Form '*Aspose.Slides v XX.XX*' befüllt. **Hinweis**: Sie können Aspose.Slides für Android über Java nicht anweisen, diese Informationen aus den Ausgabedokumenten zu ändern oder zu entfernen.

{{% /alert %}}


Aspose.Slides ermöglicht Ihnen die Konvertierung von:

* einer gesamten Präsentation in PDF
* spezifischen Folien in einer Präsentation in PDF
* einer Präsentation 

Aspose.Slides exportiert Präsentationen in PDF auf eine Weise, die den Inhalt der resultierenden PDFs sehr ähnlich zu dem in den ursprünglichen Präsentationen macht. Diese bekannten Elemente und Attribute werden oft korrekt in der Präsentation zu PDF-Konvertierung gerendert:

* Bilder
* Textfelder und andere Formen
* Texte und deren Formatierung
* Absätze und deren Formatierung
* Hyperlinks
* Kopf- und Fußzeilen
* Aufzählungszeichen
* Tabellen

## **PowerPoint in PDF konvertieren**

Die Standardoperation zur PDF-Konvertierung von PowerPoint wird mit den Standardeinstellungen durchgeführt. In diesem Fall versucht Aspose.Slides, die bereitgestellte Präsentation mit optimalen Einstellungen auf den maximalen Qualitätsstufen in PDF zu konvertieren.

Dieser Java-Code zeigt Ihnen, wie Sie eine PowerPoint in PDF konvertieren:

```java
// Instanziiert eine Presentation-Klasse, die eine PowerPoint-Datei darstellt
Presentation pres = new Presentation("PowerPoint.ppt");
try {
    // Speichert die Präsentation als PDF
    pres.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert  color="primary"  %}} 

Aspose bietet einen kostenlosen Online- [**PowerPoint zu PDF-Converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf), der den Prozess der Präsentation zu PDF-Konvertierung demonstriert. Für eine Live-Implementierung des hier beschriebenen Verfahrens können Sie einen Test mit dem Konverter durchführen.

{{% /alert %}}

## **PowerPoint in PDF mit Optionen konvertieren**

Aspose.Slides bietet benutzerdefinierte Optionen—Eigenschaften unter der [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PdfOptions) -Klasse—die es Ihnen ermöglichen, das PDF (das aus dem Konvertierungsprozess resultiert) anzupassen, das PDF mit einem Passwort zu sperren oder sogar anzugeben, wie der Konvertierungsprozess ablaufen soll.

### **PowerPoint in PDF mit benutzerdefinierten Optionen konvertieren**

Mit benutzerdefinierten Konvertierungsoptionen können Sie Ihre bevorzugte Qualitätseinstellung für Rasterbilder festlegen, angeben, wie Metadateien behandelt werden sollen, eine Kompressionsstufe für Texte festlegen, DPI für Bilder einstellen usw.

Das folgende Codebeispiel demonstriert eine Operation, bei der eine PowerPoint-Präsentation mit mehreren benutzerdefinierten Optionen in PDF konvertiert wird:

```java
// Instanziiert die PdfOptions-Klasse
PdfOptions pdfOptions = new PdfOptions();

// Setzt die Qualität für JPG-Bilder
pdfOptions.setJpegQuality((byte)90);

// Setzt DPI für Bilder
pdfOptions.setSufficientResolution(300);

// Setzt das Verhalten für Metadateien
pdfOptions.setSaveMetafilesAsPng(true);

// Setzt die Textkompressionsstufe für textuelle Inhalte
pdfOptions.setTextCompression(PdfTextCompression.Flate);

// Definiert den PDF-Compliance-Modus
pdfOptions.setCompliance(PdfCompliance.Pdf15);

// Instanziiert die Presentation-Klasse, die ein PowerPoint-Dokument darstellt
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Speichert die Präsentation als PDF-Dokument
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **PowerPoint in PDF mit versteckten Folien konvertieren**

Wenn eine Präsentation versteckte Folien enthält, können Sie eine benutzerdefinierte Option—die [ShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPdfOptions#getShowHiddenSlides--) -Eigenschaft aus der [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PdfOptions) -Klasse verwenden, um Aspose.Slides anzuweisen, die versteckten Folien als Seiten in das resultierende PDF aufzunehmen.

Dieser Java-Code zeigt Ihnen, wie Sie eine PowerPoint-Präsentation in PDF konvertieren, wobei versteckte Folien eingeschlossen sind:

```java
// Instanziiert eine Presentation-Klasse, die eine PowerPoint-Datei darstellt
Presentation pres = new Presentation("PowerPoint.pptx");
try {
    // Instanziiert die PdfOptions-Klasse
    PdfOptions pdfOptions = new PdfOptions();
    
    // Fügt versteckte Folien hinzu
    pdfOptions.setShowHiddenSlides(true);
    
    // Speichert die Präsentation als PDF
    pres.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

### **PowerPoint in passwortgeschütztes PDF konvertieren**

Dieser Java-Code zeigt Ihnen, wie Sie eine PowerPoint in ein passwortgeschütztes PDF konvertieren (unter Verwendung von Schutzparametern aus der [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PdfOptions) -Klasse):

```java
// Instanziiert ein Presentation-Objekt, das eine PowerPoint-Datei darstellt
Presentation pres = new Presentation("PowerPoint.pptx");
try {
    /// Instanziiert die PdfOptions-Klasse
    PdfOptions pdfOptions = new PdfOptions();
    
    // Setzt das PDF-Passwort und die Zugriffsberechtigungen
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);
    
    // Speichert die Präsentation als PDF
    pres.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Schriftartsubstitutionen erkennen**

Aspose.Slides bietet die [getWarningCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#getWarningCallback--) -Methode unter der [SaveOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/) -Klasse, um Ihnen zu ermöglichen, Schriftartsubstitutionen in einem Präsentation zu PDF-Konvertierungsprozess zu erkennen.

Dieser Java-Code zeigt Ihnen, wie Sie Schriftartsubstitutionen erkennen: 

```java
public void main(String[] args)
{
    LoadOptions loadOptions = new LoadOptions();
    FontSubstSendsWarningCallback warningCallback = new FontSubstSendsWarningCallback();
    loadOptions.setWarningCallback(warningCallback);

    Presentation pres = new Presentation("pres.pptx", loadOptions);
    try {
        
    } finally {
        if (pres != null) pres.dispose();
    }
}

private class FontSubstSendsWarningCallback implements IWarningCallback
{
    public int warning(IWarningInfo warning)
    {
        if (warning.getWarningType() == WarningType.CompatibilityIssue)
            return ReturnAction.Continue;

        if (warning.getWarningType() == WarningType.DataLoss &&
                warning.getDescription().startsWith("Font will be substituted"))
        {
            System.out.println("Warnung zur Schriftartsubstitution: " + warning.getDescription());
        }

        return ReturnAction.Continue;
    }
}
```

{{%  alert color="primary"  %}} 

Für weitere Informationen zum Erhalten von Rückrufen für Schriftartsubstitutionen in einem Rendering-Prozess siehe [Erhalt von Rückrufen für Warnungen zur Schriftartsubstitution](https://docs.aspose.com/slides/androidjava/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Für weitere Informationen zur Schriftartsubstitution siehe den Artikel [Schriftartsubstitution](https://docs.aspose.com/slides/androidjava/font-substitution/).

{{% /alert %}} 

## **Ausgewählte Folien in PowerPoint in PDF konvertieren**

Dieser Java-Code zeigt Ihnen, wie Sie spezifische Folien in einer PowerPoint-Präsentation in PDF konvertieren:

```java
// Instanziiert ein Presentation-Objekt, das eine PowerPoint-Datei darstellt
Presentation pres = new Presentation("PowerPoint.pptx");
try {
    // Setzt ein Array von Folienpositionen
    int[] slides = { 1, 3 };
    
    // Speichert die Präsentation als PDF
    pres.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

## **PowerPoint in PDF mit benutzerdefinierter Foliengröße konvertieren**

Dieser Java-Code zeigt Ihnen, wie Sie eine PowerPoint konvertieren, wenn die Foliengröße für ein PDF angegeben ist:

```java
// Instanziiert ein Presentation-Objekt, das eine PowerPoint-Datei darstellt 
Presentation pres = new Presentation("SelectedSlides.pptx");
try {
    Presentation outPres = new Presentation();
    try {
        ISlide slide = pres.getSlides().get_Item(0);

        outPres.getSlides().insertClone(0, slide);
        
        // Setzt den Folientyp und die Größe 
        outPres.getSlideSize().setSize(612F, 792F, SlideSizeScaleType.EnsureFit);
        
        PdfOptions pdfOptions = new PdfOptions();
        INotesCommentsLayoutingOptions options = pdfOptions.getNotesCommentsLayouting();
        options.setNotesPosition(NotesPositions.BottomFull);

        outPres.save("PDFnotes_out.pdf", SaveFormat.Pdf, pdfOptions);
    } finally {
        if (pres != null) pres.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **PowerPoint in PDF im Notizen-Folienansicht konvertieren**

Dieser Java-Code zeigt Ihnen, wie Sie eine PowerPoint in PDF-Notizen konvertieren:

```java
// Instanziert eine Presentation-Klasse, die eine PowerPoint-Datei darstellt
Presentation pres = new Presentation("SelectedSlides.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    INotesCommentsLayoutingOptions options = pdfOptions.getNotesCommentsLayouting();
    options.setNotesPosition(NotesPositions.BottomFull);

    pres.save("Pdf_With_Notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Zugänglichkeits- und Compliance-Standards für PDF**

Aspose.Slides ermöglicht es Ihnen, ein Konvertierungsverfahren zu verwenden, das den [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) entspricht. Sie können ein PowerPoint-Dokument in PDF unter Verwendung dieser Compliance-Standards exportieren: **PDF/A1a**, **PDF/A1b** und **PDF/UA**.

Dieser Java-Code demonstriert eine PowerPoint-zu-PDF-Konvertierungsoperation, bei der mehrere PDFs basierend auf verschiedenen Compliance-Standards erstellt werden:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    
    pdfOptions.setCompliance(PdfCompliance.PdfA1a);
    pres.save("pres-a1a-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfA1b);
    pres.save("pres-a1b-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfUa);
    pres.save("pres-ua-compliance.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Hinweis" color="warning" %}} 

Die Unterstützung von Aspose.Slides für PDF-Konvertierungsoperationen erstreckt sich darauf, Ihnen zu ermöglichen, PDF in die gebräuchlichsten Dateiformate zu konvertieren. Sie können [PDF in HTML](https://products.aspose.com/slides/androidjava/conversion/pdf-to-html/), [PDF in Bild](https://products.aspose.com/slides/androidjava/conversion/pdf-to-image/), [PDF in JPG](https://products.aspose.com/slides/androidjava/conversion/pdf-to-jpg/) und [PDF in PNG](https://products.aspose.com/slides/androidjava/conversion/pdf-to-png/) Konversionen durchführen. Weitere PDF-Konvertierungsoperationen in spezielle Formate—[PDF in SVG](https://products.aspose.com/slides/androidjava/conversion/pdf-to-svg/), [PDF in TIFF](https://products.aspose.com/slides/androidjava/conversion/pdf-to-tiff/) und [PDF in XML](https://products.aspose.com/slides/androidjava/conversion/pdf-to-xml/)—werden ebenfalls unterstützt.

{{% /alert %}}