---
title: Lizenzierung
type: docs
weight: 80
url: /de/nodejs-java/licensing/
keywords:
- Lizenz
- Temporäre Lizenz
- Lizenz festlegen
- Lizenz verwenden
- Lizenz validieren
- Lizenzdatei
- Evaluierungsversion
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Lizenzen in Aspose.Slides für Node.js anwenden, verwalten und Fehlersuche durchführen. Stellen Sie einen ununterbrochenen Zugriff auf alle Funktionen mit unserer Schritt-für-Schritt-Lizenzierungsanleitung sicher."
---
## **Einleitung**

Manchmal ist für die besten Evaluierungsergebnisse ein praktischer Ansatz erforderlich. Aus diesem Grund bietet Aspose.Slides verschiedene Kaufpläne sowie eine kostenlose Testversion und eine 30‑tägige temporäre Lizenz zur Evaluierung an.

{{% alert color="info" title="Note" %}}
Beachten Sie, dass es eine Reihe von allgemeinen Richtlinien und Praktiken gibt, die Sie dabei unterstützen, unsere Produkte zu evaluieren, korrekt zu lizenzieren und zu kaufen. Sie finden sie im Abschnitt ["Kaufrichtlinien und FAQ"](https://purchase.aspose.com/policies).
{{% /alert %}}

## **Aspose.Slides evaluieren**
Sie können Aspose.Slides ganz einfach zur Evaluierung herunterladen. Das Evaluierungspaket ist identisch mit dem gekauften Paket. Die Evaluierungsversion wird einfach lizenziert, sobald Sie ein paar Codezeilen hinzufügen, um die Lizenz anzuwenden. 

## **Einschränkungen der Evaluierungsversion**
Die Evaluierungsversion von Aspose.Slides (ohne angegebene Lizenz) bietet die gesamte Produktfunktionalität, jedoch mit zwei Einschränkungen:

* Sie fügt jedem Folienblatt jeder Präsentation, die sie speichert, ein Wasserzeichen‑Textfeld für die Evaluierung hinzu.
* Text, der länger als fünf Zeichen ist und den Ihr Code aus einer Präsentation liest, wird auf die ersten fünf Zeichen gekürzt, gefolgt von `... text has been truncated due to evaluation version limitation.` Texte mit fünf Zeichen oder weniger werden unverändert zurückgegeben, und von Ihrem Code geschriebener Text wird vollständig gespeichert.

{{% alert color="info" title="Note" %}}
Wenn Sie Aspose.Slides ohne die Einschränkungen der Evaluierungsversion testen möchten, können Sie eine **30‑tägige temporäre Lizenz** anfordern. Weitere Informationen finden Sie unter [How to get a Temporary License?](https://purchase.aspose.com/temporary-license).
{{% /alert %}}

## **Zur Lizenz**
Sie können ganz einfach eine Evaluierungsversion von Aspose.Slides für Node.js über Java von der [Download‑Seite](https://releases.aspose.com/slides/de/nodejs-java/) herunterladen. Die Evaluierungsversion verfügt über dieselben Funktionen wie die lizenzierte Version, mit den oben beschriebenen Einschränkungen. Außerdem wird die Evaluierungsversion einfach lizenziert, sobald Sie eine Lizenz erwerben und ein paar Codezeilen hinzufügen, um die Lizenz anzuwenden.

Die Lizenz ist eine reine Text‑XML‑Datei, die Details wie den Produktnamen, die Anzahl der lizenzierten Entwickler, das Ablaufdatum des Abonnements usw. enthält. Die Datei ist digital signiert, daher dürfen Sie sie nicht ändern. Selbst das versehentliche Hinzufügen eines zusätzlichen Zeilenumbruchs zum Inhalt der Datei macht sie ungültig.

Um die mit der Evaluierungsversion verbundenen Einschränkungen zu vermeiden, müssen Sie eine Lizenz festlegen, bevor Sie **Aspose.Slides** verwenden. Sie müssen die Lizenz nur einmal pro Anwendung oder Prozess festlegen.

{{% alert color="info" title="Note" %}}
Vielleicht möchten Sie sich [Metered Licensing](/slides/de/nodejs-java/metered-licensing/) ansehen.
{{% /alert %}}

## **Gekaufte Lizenz**

Nach dem Kauf müssen Sie die Lizenzdatei oder den Stream anwenden. 

{{% alert color="info" title="Note" %}}
Sie müssen die Lizenz festlegen:
* nur einmal pro Prozess
* bevor Sie andere Aspose.Slides‑Klassen verwenden
{{% /alert %}}

{{% alert color="info" title="Note" %}}
Preis‑Informationen finden Sie auf der Seite [“Pricing Information”](https://purchase.aspose.com/pricing/slides/de/family).
{{% /alert %}}

### **Festlegen einer Lizenz in Aspose.Slides für Node.js über Java**
Lizenzen können aus folgenden Orten angewendet werden:

* Expliziter Pfad
* Stream
* Als Metered License – ein neuer Lizenzierungsmechanismus

{{% alert color="info" title="Note" %}}
Verwenden Sie die **setLicense**‑Methode, um eine Komponente zu lizenzieren.

Obwohl mehrere Aufrufe von **setLicense** nicht schädlich sind, verschwenden sie Ressourcen (Prozessor).
{{% /alert %}}

#### **Anwenden einer Lizenz über eine Datei**
Dieses Code‑Snippet wird verwendet, um eine Lizenzdatei festzulegen:

**Node.js**

```javascript
const asposeSlides = require("aspose.slides.via.java");

const license = new asposeSlides.License();
license.setLicense("Aspose.Slides.lic");
console.log("The license was applied.");

// Aspose.Slides läuft in einer Java Virtual Machine, die Node.js am Laufen hält, daher den Prozess explizit beenden.
process.exit(0);
```

Beim Aufruf der setLicense‑Methode sollte der Lizenzname mit dem Ihrer Lizenzdatei übereinstimmen. Beispielsweise können Sie den Dateinamen der Lizenzdatei in "Aspose.Slides.lic.xml" ändern. Dann müssen Sie in Ihrem Code den neuen Lizenznamen (Aspose.Slides.lic.xml) an die setLicense‑Methode übergeben. Wenn die Datei fehlt oder keine gültige Lizenz enthält, wirft [setLicense](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/license/setlicense/) eine Ausnahme, die das Skript mit einem Fehler beendet.

#### **Anwenden einer Lizenz aus einem Stream**
Um eine Lizenz aus einem Stream anzuwenden, übergeben Sie das [License](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/license/)‑Objekt und einen lesbaren Stream an die statische Methode [setLicenseFromStream](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/license/setlicense/). Der Stream wird asynchron gelesen, und der Callback erhält einen Fehler, wenn der Stream keine gültige Lizenz enthält:

**Node.js**

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");

const license = new asposeSlides.License();
const readStream = fs.createReadStream("Aspose.Slides.lic");
asposeSlides.License.setLicenseFromStream(license, readStream, function (error) {
    if (error) {
        console.error("The license was not applied:", error.message);
    } else {
        console.log("The license was applied.");
    }

    // Aspose.Slides läuft in einer Java Virtual Machine, die Node.js am Laufen hält, daher den Prozess explizit beenden.
    process.exit(0);
});
```

Die Lizenz wird angewendet, sobald der gesamte Stream gelesen wurde, direkt bevor der Callback ausgeführt wird, sodass Sie weitere Aspose.Slides‑Arbeiten im Callback starten können.

Beide Beispiele rufen `process.exit(0)` auf, wenn sie fertig sind, da die Java‑Virtual‑Machine, die Aspose.Slides ausführt, Node.js am Laufen hält. In einer Anwendung setzen Sie Ihren Aspose.Slides‑Code fort, anstatt den Prozess zu beenden.

## **FAQ**

### Kann ich die Lizenz in einer komplett offline Umgebung (keine Internetverbindung) anwenden?
Ja. Die Lizenzvalidierung erfolgt lokal anhand der Lizenzdatei; eine Internetverbindung ist nicht erforderlich.

### Was passiert, wenn das einjährige Abonnement abläuft? Wird die Bibliothek nicht mehr funktionieren?
Nein. Die Lizenz ist unbefristet: Sie können weiterhin Versionen verwenden, die vor dem Ende Ihres Abonnements veröffentlicht wurden; Sie können jedoch neuere Versionen nur nach einer Verlängerung nutzen.