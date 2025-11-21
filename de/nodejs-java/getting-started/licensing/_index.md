---
title: Lizenzierung
description: "Aspose.Slides für Node.js via Java bietet verschiedene Kaufpläne oder stellt eine kostenlose Testversion und eine 30-tägige temporäre Lizenz zur Evaluierung gemäß Lizenz- und Abonnementrichtlinien bereit."
type: docs
weight: 80
url: /de/nodejs-java/licensing/
---

Manchmal ist für die besten Evaluierungsergebnisse ein praktischer Ansatz erforderlich. Aus diesem Grund bietet Aspose.Slides verschiedene Kaufpläne sowie eine kostenlose Testversion und eine 30‑tägige Temporäre Lizenz zur Evaluierung an.

{{% alert color="primary" %}}
Beachten Sie, dass es eine Reihe von allgemeinen Richtlinien und Praktiken gibt, die Sie dabei unterstützen, unsere Produkte zu evaluieren, korrekt zu lizenzieren und zu kaufen. Sie finden sie im Abschnitt ["Kaufrichtlinien und FAQ"](https://purchase.aspose.com/policies).
{{% /alert %}}

## **Aspose.Slides evaluieren**
Sie können Aspose.Slides ganz einfach zur Evaluierung herunterladen. Das Evaluierungspaket ist identisch mit dem gekauften Paket. Die Evaluierungsversion wird einfach lizenziert, sobald Sie ein paar Codezeilen hinzufügen, um die Lizenz anzuwenden. 

## **Einschränkungen der Evaluierungsversion**
Die Evaluierungsversion von Aspose.Slides (ohne angegebene Lizenz) bietet die gesamte Produktfunktionalität, fügt jedoch beim Öffnen und Speichern ein Evaluierungswasserzeichen oben im Dokument ein. Außerdem sind Sie beim Extrahieren von Texten aus Präsentationsfolien auf eine Folie beschränkt.

{{% alert color="primary" %}} 
Wenn Sie Aspose.Slides ohne die Einschränkungen der Evaluierungsversion testen möchten, können Sie eine **30‑tägige Temporäre Lizenz** anfordern. Weitere Informationen finden Sie unter [How to get a Temporary License?](https://purchase.aspose.com/temporary-license).
{{% /alert %}} 

## **Zur Lizenz**
Sie können ganz einfach eine Evaluierungsversion von Aspose.Slides für Node.js via Java von seiner [download page](https://releases.aspose.com/slides/nodejs-java/) herunterladen. Die Evaluierungsversion bietet exakt **die gleichen Fähigkeiten** wie die lizenzierte Version von Aspose.Slides. Darüber hinaus wird die Evaluierungsversion einfach lizenziert, sobald Sie eine Lizenz erwerben und ein paar Codezeilen hinzufügen, um die Lizenz anzuwenden.

Die Lizenz ist eine reine Text‑XML‑Datei, die Details wie Produktname, Anzahl der lizenzierten Entwickler, Ablaufdatum des Abonnements usw. enthält. Die Datei ist digital signiert, daher darf sie nicht geändert werden. Selbst das versehentliche Hinzufügen eines zusätzlichen Zeilenumbruchs zum Inhalt der Datei macht sie ungültig.

Um die mit der Evaluierungsversion verbundenen Einschränkungen zu vermeiden, müssen Sie vor der Verwendung von **Aspose.Slides** eine Lizenz setzen. Sie müssen die Lizenz nur einmal pro Anwendung oder Prozess setzen.

{{% alert color="primary" %}} 
Möglicherweise möchten Sie sich [Metered Licensing](https://docs.aspose.com/slides/nodejs-java/metered-licensing/) ansehen.
{{% /alert %}} 

## **Gekaufte Lizenz**
Nach dem Kauf müssen Sie die Lizenzdatei oder den Lizenz‑Stream anwenden. 

{{% alert color="primary" %}}
Sie müssen die Lizenz setzen:
* nur einmal pro Anwendungsdomäne
* bevor Sie irgendeine andere Aspose.Slides‑Klasse verwenden
{{% /alert %}}

{{% alert color="primary" %}}
Preis‑Informationen finden Sie auf der Seite [“Pricing Information”](https://purchase.aspose.com/pricing/slides/family).
{{% /alert %}}

### **Lizenz setzen in Aspose.Slides für Node.js via Java**
Lizenzen können aus folgenden Quellen angewendet werden:

* Expliziter Pfad
* Stream
* Als Metered License – ein neuer Lizenzierungsmechanismus

{{% alert color="primary" %}}
Verwenden Sie die Methode **setLicense**, um eine Komponente zu lizenzieren. Mehrfache Aufrufe von **setLicense** sind zwar nicht schädlich, verschwenden jedoch Ressourcen (Prozessor).
{{% /alert %}}

{{% alert color="warning" %}}
Neue Lizenzen können Aspose.Slides nur mit Version 21.4 oder höher aktivieren. Ältere Versionen verwenden ein anderes Lizenzsystem und erkennen diese Lizenzen nicht.
{{% /alert %}}

#### **Lizenz mittels Datei anwenden**
Dieses Code‑Snippet wird verwendet, um eine Lizenzdatei zu setzen:

**Node.js**
```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var license = new aspose.slides.License();
license.setLicense("Aspose.Slides.lic");
```


Beim Aufruf der Methode setLicense sollte der Lizenzname dem Namen Ihrer Lizenzdatei entsprechen. Zum Beispiel können Sie den Dateinamen in "Aspose.Slides.lic.xml" ändern. Dann müssen Sie in Ihrem Code den neuen Lizenznamen (Aspose.Slides.lic.xml) an die Methode setLicense übergeben.

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

**Kann ich die Lizenz in einer vollständig offline Umgebung (kein Internetzugang) anwenden?**
Ja. Die Lizenzvalidierung erfolgt lokal mit der Lizenzdatei; eine Internetverbindung ist nicht erforderlich.

**Was passiert, wenn das einjährige Abonnement abläuft? Hört die Bibliothek auf zu funktionieren?**
Nein. Die Lizenz ist unbefristet: Sie können weiterhin Versionen verwenden, die vor Ablauf Ihres Abonnements veröffentlicht wurden; Sie können jedoch neuere Releases nur mit einer Verlängerung nutzen.