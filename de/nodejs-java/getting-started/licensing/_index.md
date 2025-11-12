---
title: Lizenzierung
description: "Aspose.Slides für Node.js via Java bietet verschiedene Kaufpläne oder ein kostenloses Testangebot und eine 30‑tägige temporäre Lizenz für die Evaluierung unter Verwendung von Lizenz‑ und Abonnement‑Richtlinien."
type: docs
weight: 80
url: /de/nodejs-java/licensing/
---

Manchmal ist für die besten Evaluierungsergebnisse ein praktischer Ansatz erforderlich. Aus diesem Grund bietet Aspose.Slides verschiedene Kaufpläne und auch eine kostenlose Testversion sowie eine 30‑tägige temporäre Lizenz zur Evaluierung an.

{{% alert color="primary" %}}
Beachten Sie, dass es eine Reihe von allgemeinen Richtlinien und Praktiken gibt, die Sie dabei unterstützen, unsere Produkte zu evaluieren, korrekt zu lizenzieren und zu erwerben. Sie finden diese im Abschnitt ["Purchase Policies and FAQ"](https://purchase.aspose.com/policies).
{{% /alert %}}

## **Aspose.Slides evaluieren**
Sie können Aspose.Slides ganz einfach zum Evaluieren herunterladen. Das Evaluierungspaket ist identisch mit dem gekauften Paket. Die Evaluierungsversion wird einfach lizenziert, sobald Sie ein paar Codezeilen hinzufügen, um die Lizenz anzuwenden. 

## **Einschränkungen der Evaluierungsversion**
Die Evaluierungsversion von Aspose.Slides (ohne angegebene Lizenz) bietet die volle Produktfunktionalität, fügt jedoch beim Öffnen und Speichern ein Evaluierungswasserzeichen oben im Dokument ein. Außerdem sind Sie beim Extrahieren von Texten aus Präsentationsfolien auf eine Folie begrenzt.

{{% alert color="primary" %}} 
Wenn Sie Aspose.Slides ohne die Einschränkungen der Evaluierungsversion testen möchten, können Sie eine **30‑tägige temporäre Lizenz** anfordern. Weitere Informationen finden Sie unter [How to get a Temporary License?](https://purchase.aspose.com/temporary-license).
{{% /alert %}} 

## **Zur Lizenz**
Sie können die Evaluierungsversion von Aspose.Slides für Node.js via Java ganz einfach von der zugehörigen [Download‑Seite](https://releases.aspose.com/slides/nodejs-java/) herunterladen. Die Evaluierungsversion bietet absolut **die gleichen Fähigkeiten** wie die lizenzierte Version von Aspose.Slides. Darüber hinaus wird die Evaluierungsversion einfach lizenziert, sobald Sie eine Lizenz erwerben und ein paar Codezeilen hinzufügen, um die Lizenz anzuwenden.

Die Lizenz ist eine reine Text‑XML‑Datei, die Details wie Produktname, Anzahl der Entwickler, für die sie lizenziert ist, Ablaufdatum des Abonnements usw. enthält. Die Datei ist digital signiert, ändern Sie sie also nicht. Selbst ein unbeabsichtigtes Hinzufügen einer zusätzlichen Zeilenumbruchs zu dem Inhalt der Datei macht sie ungültig.

Um die mit der Evaluierungsversion verbundenen Einschränkungen zu vermeiden, müssen Sie vor der Verwendung von **Aspose.Slides** eine Lizenz setzen. Sie müssen die Lizenz nur einmal pro Anwendung oder Prozess setzen.

{{% alert color="primary" %}} 
Sie möchten vielleicht [Verbrauchslizenzierung](https://docs.aspose.com/slides/nodejs-java/metered-licensing/).
{{% /alert %}} 

## **Gekaufte Lizenz**

Nach dem Kauf müssen Sie die Lizenzdatei oder den Stream anwenden. 

{{% alert color="primary" %}}
Sie müssen die Lizenz setzen:
* nur einmal pro Anwendungsdomäne
* bevor Sie irgendeine andere Aspose.Slides‑Klasse verwenden
{{% /alert %}}

{{% alert color="primary" %}}
Preisdetails finden Sie auf der Seite [„Preisinfo“](https://purchase.aspose.com/pricing/slides/family).
{{% /alert %}}

### **Festlegen einer Lizenz in Aspose.Slides für Node.js via Java**

Lizenzen können von folgenden Orten aus angewendet werden:

* Expliziter Pfad
* Stream
* Als Verbrauchslizenz – ein neuer Lizenzierungsmechanismus

{{% alert color="primary" %}}
Verwenden Sie die **setLicense**‑Methode, um eine Komponente zu lizenzieren.

Obwohl mehrere Aufrufe von **setLicense** nicht schädlich sind, verschwenden sie Ressourcen (Prozessor).
{{% /alert %}}

{{% alert color="warning" %}}
Neue Lizenzen können Aspose.Slides nur mit Version 21.4 oder neuer aktivieren. Ältere Versionen verwenden ein anderes Lizenzsystem und erkennen diese Lizenzen nicht.
{{% /alert %}}

#### **Lizenz mithilfe einer Datei anwenden**

Dieses Code‑Snippet wird verwendet, um eine Lizenzdatei zu setzen:

**Node.js**

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var license = new aspose.slides.License();
license.setLicense("Aspose.Slides.lic");
```

Beim Aufruf der `setLicense`‑Methode sollte der Lizenzname dem Namen Ihrer Lizenzdatei entsprechen. Beispielsweise können Sie den Lizenzdateinamen in "Aspose.Slides.lic.xml" ändern. Dann müssen Sie in Ihrem Code den neuen Lizenznamen (Aspose.Slides.lic.xml) an die `setLicense`‑Methode übergeben.

#### **Lizenz aus einem Stream anwenden**

Dieses Code‑Snippet wird verwendet, um eine Lizenz aus einem Stream anzuwenden:

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

## **FAQ**

**Kann ich die Lizenz in einer vollständig offline Umgebung (keine Internetverbindung) anwenden?**

Ja. Die Lizenzvalidierung erfolgt lokal mit der Lizenzdatei; eine Internetverbindung ist nicht erforderlich.

**Was passiert, wenn das einjährige Abonnement abläuft? Hört die Bibliothek dann auf zu funktionieren?**

Nein. Die Lizenz ist unbefristet: Sie können weiterhin Versionen verwenden, die vor dem Ende Ihres Abonnements veröffentlicht wurden; Sie dürfen jedoch neuere Releases ohne Verlängerung nicht nutzen.