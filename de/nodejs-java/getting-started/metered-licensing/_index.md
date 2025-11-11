---
title: Verbrauchslizenzierung
type: docs
weight: 100
url: /de/nodejs-java/metered-licensing/
keywords:
- Lizenz
- verbrauchsbasierte Lizenzierung
- Node.js
- Java
- Aspose.Slides für Node.js via Java
---

## **Anwenden von Verbrauchsschlüsseln**

{{% alert color="primary" %}} 

Verbrauchslizenzierung ist ein neuer Lizenzierungsmechanismus, der neben bestehenden Lizenzmethoden verwendet werden kann. Wenn Sie basierend auf Ihrer Nutzung der Aspose.Slides‑API‑Funktionen abgerechnet werden möchten, wählen Sie die Verbrauchslizenzierung.

Wenn Sie eine Verbrauchslizenz erwerben, erhalten Sie Schlüssel (und keine Lizenzdatei). Dieser Verbrauchsschlüssel kann mithilfe der [Metered](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/)‑Klasse, die Aspose für Verbrauchsvorgänge bereitstellt, angewendet werden. Weitere Details finden Sie in den [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. Erstellen Sie eine Instanz der [Metered]‑Klasse.

1. Übergeben Sie Ihre öffentlichen und privaten Schlüssel an die [setMeteredKey](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/#setMeteredKey)‑Methode.

1. Führen Sie einige Verarbeitungen durch (Aufgaben ausführen).

1. Rufen Sie die [getConsumptionQuantity](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/#getConsumptionQuantity)‑Methode der `Metered`‑Klasse auf.

Sie sollten die Menge/Anzahl der API‑Anfragen sehen, die Sie bisher verbraucht haben.

Dieses Beispiel zeigt, wie Sie die Verbrauchslizenzierung verwenden:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Erstellt eine Instanz der Metered‑Klasse
var metered = new aspose.slides.Metered();

// Übergibt die öffentlichen und privaten Schlüssel an das Metered‑Objekt
metered.setMeteredKey("<valid public key>", "<valid private key>");

// Ermittelt den verbrauchten Mengenwert vor API‑Aufrufen
var amountBefore = aspose.slides.Metered.getConsumptionQuantity();
console.log("Amount consumed before:", amountBefore);

// Hier etwas mit der Aspose.Slides‑API tun
// ...

// Ermittelt den verbrauchten Mengenwert nach API‑Aufrufen
var amountAfter = aspose.slides.Metered.getConsumptionQuantity();
console.log("Amount consumed after:", amountAfter);
```

{{% alert color="warning" title="NOTE"  %}} 

Um Verbrauchslizenzierung zu nutzen, benötigen Sie eine stabile Internetverbindung, da der Lizenzierungsmechanismus das Internet verwendet, um kontinuierlich mit unseren Diensten zu interagieren und Berechnungen durchzuführen.

{{% /alert %}} 

## **FAQ**

**Kann ich eine Verbrauchslizenz zusammen mit einer regulären (perpetuieren oder temporären) Lizenz in derselben Anwendung verwenden?**

Ja. Metered ist ein zusätzlicher Lizenzierungsmechanismus, der neben bestehenden [Lizenzmethoden](/slides/de/nodejs-java/licensing/) verwendet werden kann. Sie wählen, welcher Mechanismus beim Start der Anwendung angewendet wird.

**Was genau wird bei einer Verbrauchslizenz als Verbrauch gezählt: Operationen oder Dateien?**

Die API‑Nutzung wird gezählt, d.h. die Anzahl der Anfragen oder Operationen. Den aktuellen Verbrauch können Sie über die [Verbrauchs‑Tracking‑Methoden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/) erhalten.

**Ist Verbrauchslizenzierung für Microservices und serverlose Umgebungen geeignet, in denen Instanzen häufig neu gestartet werden?**

Ja. Da die Abrechnung auf API‑Aufruf‑Ebene erfolgt, sind Szenarien mit häufigen Cold‑Starts kompatibel, sofern ein stabiles Netzwerk für die Berechnungen verfügbar ist.

**Unterscheidet sich die Funktionalität der Bibliothek bei Verwendung einer Verbrauchslizenz im Vergleich zu einer unbefristeten Lizenz?**

Nein. Dies betrifft nur den Lizenz‑ und Abrechnungsmechanismus; die Möglichkeiten des Produkts bleiben identisch.

**Wie steht die Verbrauchslizenzierung im Verhältnis zur Testversion und zur temporären Lizenz?**

Die Testversion hat Einschränkungen und Wasserzeichen, die [temporäre Lizenz](https://purchase.aspose.com/temporary-license/) entfernt die Einschränkungen für 30 Tage, und die Verbrauchslizenzierung entfernt Einschränkungen und berechnet nach tatsächlicher Nutzung.

**Kann ich das Budget steuern, indem ich automatisch reagiere, wenn ein Verbrauchsschwellenwert überschritten wird?**

Ja. Eine gängige Praxis ist, den aktuellen Verbrauch periodisch über die [Verbrauchs‑Tracking‑Methoden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/) auszulesen und eigene Grenzen oder Alarme auf Anwendungsebene bzw. Überwachungsebene zu implementieren.