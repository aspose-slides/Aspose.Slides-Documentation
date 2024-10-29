---
title: Lizenzierung
description: "Aspose.Slides für Node.js über Java bietet verschiedene Kaufpläne an oder bietet eine kostenlose Testversion und eine 30-tägige temporäre Lizenz zur evaluierung unter Verwendung von Lizenzierungs- und Abonnementrichtlinien."
type: docs
weight: 80
url: /de/nodejs-java/licensing/
---

Manchmal ist für die besten Evaluierungsergebnisse ein praktischer Ansatz erforderlich. Aus diesem Grund bietet Aspose.Slides verschiedene Kaufpläne an und bietet auch eine kostenlose Testversion sowie eine 30-tägige temporäre Lizenz zur Evaluierung an.

{{% alert color="primary" %}}

Bitte beachten Sie, dass es eine Reihe von allgemeinen Richtlinien und Praktiken gibt, die Sie anleiten, wie Sie unsere Produkte evaluieren, korrekt lizenzieren und kaufen. Sie finden diese im Abschnitt ["Kaufrichtlinien und FAQ"](https://purchase.aspose.com/policies).

{{% /alert %}}

## **Aspose.Slides evaluieren**
Sie können Aspose.Slides problemlos zum Testen herunterladen. Das Evaluierungspaket ist identisch mit dem gekauften Paket. Die Evaluierungsversion wird einfach lizenziert, nachdem Sie einige Codezeilen hinzugefügt haben, um die Lizenz anzuwenden.

## **Einschränkung der Evaluierungsversion**
Die Evaluierungsversion von Aspose.Slides (ohne angegebene Lizenz) bietet die volle Produktfunktionalität, aber sie fügt beim Öffnen und Speichern ein Evaluierungs-Wasserzeichen an den oberen Rand des Dokuments ein. Sie sind auch auf eine Folie beschränkt, wenn Sie Texte aus Präsentationsfolien extrahieren.

{{% alert color="primary" %}} 

Wenn Sie Aspose.Slides ohne die Einschränkungen der Evaluierungsversion testen möchten, können Sie eine **30-tägige temporäre Lizenz** anfordern. Bitte beziehen Sie sich auf [Wie man eine temporäre Lizenz erhält?](https://purchase.aspose.com/temporary-license) für weitere Informationen.

{{% /alert %}} 

## **Über die Lizenz**
Sie können eine Evaluierungsversion von Aspose.Slides für Node.js über Java ganz einfach von der [Download-Seite](https://releases.aspose.com/slides/nodejs-java/) herunterladen. Die Evaluierungsversion bietet absolut **die gleichen Funktionen** wie die lizenzierte Version von Aspose.Slides. Darüber hinaus wird die Evaluierungsversion einfach lizenziert, nachdem Sie eine Lizenz erworben und ein paar Codezeilen hinzugefügt haben, um die Lizenz anzuwenden.

Die Lizenz ist eine XML-Datei im Klartext, die Details wie den Produktnamen, die Anzahl der Entwickler, für die sie lizenziert ist, das Ablaufdatum des Abonnements usw. enthält. Die Datei ist digital signiert, daher sollten Sie die Datei nicht ändern. Bereits eine unbeabsichtigte Hinzufügung eines zusätzlichen Zeilenumbruchs zu den Inhalten der Datei macht sie ungültig.

Um die mit der Evaluierungsversion verbundenen Einschränkungen zu vermeiden, müssen Sie eine Lizenz festlegen, bevor Sie **Aspose.Slides** verwenden. Sie müssen eine Lizenz nur einmal pro Anwendung oder Prozess festlegen.

## Gekaufte Lizenz

Nach dem Kauf müssen Sie die Lizenzdatei oder den Stream anwenden. 

{{% alert color="primary" %}}

Sie müssen die Lizenz festlegen:
* nur einmal pro Anwendungsbereich
* bevor Sie andere Aspose.Slides-Klassen verwenden

{{% /alert %}}

{{% alert color="primary" %}}

Preisinformationen finden Sie auf der Seite [„Preisinformationen“](https://purchase.aspose.com/pricing/slides/family).

{{% /alert %}}

### **Festlegen einer Lizenz in Aspose.Slides für Node.js über Java**

Lizenzen können von diesen Standorten angewendet werden:

* Expliziter Pfad
* Stream
* Als gemessene Lizenz – ein neues Lizenzierungssystem

{{% alert color="primary" %}}

Verwenden Sie die Methode **setLicense**, um eine Komponente zu lizenzieren.

Obwohl mehrere Aufrufe von **setLicense** nicht schädlich sind, sind sie eine Verschwendung von Ressourcen (Prozessor).

{{% /alert %}}

#### **Anwenden einer Lizenz mit einer Datei**

Dieser Codeausschnitt wird verwendet, um eine Lizenzdatei festzulegen:

**Node.js**

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var license = new aspose.slides.License();
license.setLicense("Aspose.Slides.lic");
```

Bei der Aufruf der setLicense-Methode sollte der Lizenzname der Bezeichnung Ihrer Lizenzdatei entsprechen. Zum Beispiel können Sie den Lizenzdateinamen in "Aspose.Slides.lic.xml" ändern. Dann müssen Sie in Ihrem Code den neuen Lizenznamen (Aspose.Slides.lic.xml) an die setLicense-Methode übergeben.

#### **Anwenden einer Lizenz aus einem Stream**

Dieser Codeausschnitt wird verwendet, um eine Lizenz aus einem Stream anzuwenden:

**Node.js**

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var license = new aspose.slides.License();

var fs = require("fs");

var readStream = fs.createReadStream("Aspose.Slides.lic");

license.setLicense(readStream, function(err, list) {
    if(err) { 
        console.error(err); return; 
    }});
```

#### Anwenden der gemessenen Lizenz

Aspose.Slides ermöglicht Entwicklern, einen gemessenen Schlüssel anzuwenden. Dies ist ein neues Lizenzierungssystem.

Das neue Lizenzierungssystem wird zusammen mit der bestehenden Lizenzierungsmethode verwendet. Kunden, die basierend auf der Nutzung von API-Funktionen abgerechnet werden möchten, können die gemessene Lizenzierung verwenden.

Nachdem Sie alle notwendigen Schritte zur Erlangung dieser Art von Lizenz abgeschlossen haben, erhalten Sie die Schlüssel, nicht die Lizenzdatei. Dieser gemessene Schlüssel kann mit der speziell zu diesem Zweck eingeführten **Metered**-Klasse angewendet werden.

Im folgenden Codebeispiel wird gezeigt, wie Sie die gemessenen öffentlichen und privaten Schlüssel festlegen:

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

# Erstellen Sie eine Instanz der CAD Metered-Klasse
var metered = new aspose.slides.Metered();

# Greifen Sie auf die set_metered_key-Eigenschaft zu und übergeben Sie öffentliche und private Schlüssel als Parameter
metered.setMeteredKey("*****", "*****");

# Holen Sie sich die Menge an gemessenen Daten, bevor Sie die API aufrufen
var amountbefore = aspose.slides.Metered.getConsumptionQuantity();
# Information anzeigen
console.log('Vorher verbrauchter Betrag: " + amountbefore + "' );

# Dokument von der Festplatte laden.
var pres = new aspose.slides.Presentation();
# Seitenanzahl des Dokuments abrufen
console.log('Nachher verbrauchter Betrag: " +  pres.getSlides().size()) + "' );
# als PDF speichern
pres.save("out_pdf.pdf", aspose.slides.SaveFormat.Pdf);

# Holen Sie sich die Menge an gemessenen Daten nach dem API-Aufruf
var amountafter = aspose.slides.Metered.getConsumptionQuantity();
# Information anzeigen
console.log('Nachher verbrauchter Betrag: " + amountafter + "' );
```

{{% alert color="primary" %}}

Bitte beachten Sie, dass Sie eine stabile Internetverbindung benötigen, um die gemessene Lizenz korrekt zu verwenden, da der gemessene Mechanismus eine ständige Interaktion mit unseren Diensten für korrekte Berechnungen erfordert. Für weitere Einzelheiten siehe den Abschnitt [„Häufige Fragen zur gemessenen Lizenzierung“](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}}