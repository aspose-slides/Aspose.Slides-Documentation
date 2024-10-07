---
title: Lizenzierung
description: "Aspose.Slides für Node.js über .NET bietet verschiedene Kaufpläne oder bietet eine kostenlose Testversion und eine 30-tägige temporäre Lizenz zur Bewertung unter Verwendung von Lizenzierungs- und Abonnementrichtlinien an."
type: docs
weight: 80
url: /nodejs-net/licensing/
---

Manchmal ist für die besten Bewertungsergebnisse ein praktischer Ansatz erforderlich. Aus diesem Grund bietet Aspose.Slides verschiedene Kaufpläne an und bietet auch eine kostenlose Testversion sowie eine 30-tägige temporäre Lizenz zur Bewertung.

{{% alert color="primary" %}}

Bitte beachten Sie, dass es eine Reihe von allgemeinen Richtlinien und Praktiken gibt, die Sie anleiten, wie Sie unsere Produkte angemessen bewerten, lizenzieren und kaufen können. Sie finden diese im Abschnitt ["Kaufrichtlinien und FAQ"](https://purchase.aspose.com/policies).

{{% /alert %}}

## **Aspose.Slides bewerten**
Sie können Aspose.Slides ganz einfach für eine Bewertung herunterladen. Das Evaluierungspaket ist dasselbe wie das gekaufte Paket. Die Evaluierungsversion wird einfach lizenziert, nachdem Sie ein paar Zeilen Code hinzugefügt haben, um die Lizenz anzuwenden.

## **Einschränkungen der Evaluierungsversion**
Die Evaluierungsversion von Aspose.Slides (ohne angegebene Lizenz) bietet die volle Produktfunktionalität, fügt jedoch beim Öffnen und Speichern einen Wasserzeichen-Evaluierungshinweis oben im Dokument hinzu. Außerdem sind Sie beim Extrahieren von Texten aus Präsentationsfolien auf eine Folie beschränkt.

{{% alert color="primary" %}} 

Wenn Sie Aspose.Slides ohne die Einschränkungen der Evaluierungsversion testen möchten, können Sie eine **30-tägige temporäre Lizenz** anfordern. Weitere Informationen finden Sie unter [Wie erhalte ich eine temporäre Lizenz?](https://purchase.aspose.com/temporary-license).

{{% /alert %}} 

## **Zur Lizenz**
Sie können eine Evaluierungsversion von Aspose.Slides für Node.js über .NET ganz einfach von der [Download-Seite](https://releases.aspose.com/slides/nodejs-net/) herunterladen. Die Evaluierungsversion bietet absolut **die gleichen Funktionen** wie die lizenzierte Version von Aspose.Slides. Darüber hinaus wird die Evaluierungsversion einfach lizenziert, nachdem Sie eine Lizenz gekauft und ein paar Zeilen Code hinzugefügt haben, um die Lizenz anzuwenden.

Die Lizenz ist eine einfache XML-Datei, die Details wie den Produktnamen, die Anzahl der lizenzierten Entwickler, das Ablaufdatum des Abonnements und so weiter enthält. Die Datei ist digital signiert, daher sollten Sie die Datei nicht ändern. Sogar eine unbeabsichtigte Hinzufügung eines zusätzlichen Zeilenumbruchs zum Inhalt der Datei führt zur Ungültigkeit.

Um die Einschränkungen der Evaluierungsversion zu vermeiden, müssen Sie eine Lizenz festlegen, bevor Sie **Aspose.Slides** verwenden. Sie müssen die Lizenz nur einmal pro Anwendung oder Prozess festlegen.

## Gekaufte Lizenz

Nach dem Kauf müssen Sie die Lizenzdatei oder den Stream anwenden. 

{{% alert color="primary" %}}

Sie müssen die Lizenz festlegen:
* nur einmal pro Anwendungsdomäne
* bevor Sie andere Aspose.Slides-Klassen verwenden

{{% /alert %}}

{{% alert color="primary" %}}

Diese Preisinformationen finden Sie auf der Seite [„Preisinformationen“](https://purchase.aspose.com/pricing/slides/family).

{{% /alert %}}

### **Festlegen einer Lizenz in Aspose.Slides für Node.js über .NET**

Lizenzen können von diesen Orten angewendet werden:

* Expliziter Pfad
* Stream
* Als metrische Lizenz – ein neues Lizenzierungsmechanismus

{{% alert color="primary" %}}

Verwenden Sie die Methode **setLicense**, um eine Komponente zu lizenzieren.

Obwohl mehrere Aufrufe von **setLicense** nicht schädlich sind, sind sie eine Ressourcenverschwendung (Prozessor).

{{% /alert %}}

#### **Anwenden einer Lizenz mithilfe einer Datei**

Dieser Codeausschnitt wird verwendet, um eine Lizenzdatei festzulegen:

**Node.js**

```javascript
// Importieren Sie das Aspose.Slides-Modul für die Bearbeitung von PowerPoint-Dateien
const asposeSlides = require('aspose.slides.via.net');

// Diese Funktion richtet die Aspose.Slides-Bibliothek mit einer Lizenz ein
function setupAsposeSlidesLicense() {
	
    // Initialisieren Sie die Lizenzklasse aus dem Aspose.Slides-Modul
    var license = new asposeSlides.License();
    
    // Wenden Sie die Lizenz aus einer Datei an
    // Ersetzen Sie "your_license_file.lic" durch den Pfad zu Ihrer tatsächlichen Lizenzdatei
    license.setLicense("your_license_file.lic");
}

// Führen Sie die Funktion aus, um die Lizenz für Aspose.Slides festzulegen
setupAsposeSlidesLicense();
```
{{% alert color="primary" %}}

Beim Aufrufen der Methode setLicense sollte der Lizenzname derselbe sein wie der Ihrer Lizenzdatei. Zum Beispiel können Sie den Namen der Lizenzdatei in "Aspose.Slides.lic.xml" ändern. Dann müssen Sie in Ihrem Code den neuen Lizenznamen (Aspose.Slides.lic.xml) an die Methode setLicense übergeben.

{{% /alert %}}