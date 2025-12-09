---
title: Metered-Lizenzierung
type: docs
weight: 100
url: /de/nodejs-java/metered-licensing/
keywords:
- Lizenz
- Metered-Lizenzierung
- Node.js
- Java
- Aspose.Slides für Node.js via Java
---

## **Metered-Schlüssel anwenden**

{{% alert color="primary" %}} 

Metered-Lizenzierung ist ein neuer Lizenzierungsmechanismus, der neben bestehenden Lizenzierungs‑Methoden verwendet werden kann. Wenn Sie basierend auf Ihrer Nutzung der Aspose.Slides‑API‑Funktionen abgerechnet werden möchten, wählen Sie die Metered‑Lizenzierung.

Wenn Sie eine Metered‑Lizenz erwerben, erhalten Sie Schlüssel (und keine Lizenzdatei). Dieser Metered‑Schlüssel kann über die [Metered](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/)‑Klasse verwendet werden, die Aspose für Meter‑Operationen bereitstellt. Weitere Details finden Sie in den [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. Erstellen Sie eine Instanz der [Metered](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/)‑Klasse.

1. Übergeben Sie Ihre öffentlichen und privaten Schlüssel an die Methode [setMeteredKey](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/#setMeteredKey).

1. Führen Sie einige Vorgänge (Tasks) aus.

1. Rufen Sie die Methode [getConsumptionQuantity](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/#getConsumptionQuantity) der `Metered`‑Klasse auf.

Sie sollten die bisher verbrauchte Menge/Anzahl von API‑Aufrufen sehen.

Dieses Beispiel zeigt, wie Sie die Metered‑Lizenzierung verwenden:
```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Erstellt eine Instanz der Metered-Klasse
var metered = new aspose.slides.Metered();

// Übergibt den öffentlichen und privaten Schlüssel an das Metered-Objekt
metered.setMeteredKey("<valid public key>", "<valid private key>");

// Holt den verbrauchten Mengenwert vor API-Aufrufen
var amountBefore = aspose.slides.Metered.getConsumptionQuantity();
console.log("Amount consumed before:", amountBefore);

// Führen Sie hier etwas mit der Aspose.Slides API aus
// ...

// Holt den verbrauchten Mengenwert nach API-Aufrufen
var amountAfter = aspose.slides.Metered.getConsumptionQuantity();
console.log("Amount consumed after:", amountAfter);
```


{{% alert color="warning" title="NOTE"  %}} 

Um Metered‑Lizenzierung zu nutzen, benötigen Sie eine stabile Internetverbindung, da der Lizenzmechanismus das Internet verwendet, um kontinuierlich mit unseren Diensten zu kommunizieren und Berechnungen durchzuführen.

{{% /alert %}} 

## **FAQ**

**Kann ich eine Metered‑Lizenz zusammen mit einer regulären (perpetual oder temporary) Lizenz in derselben Anwendung verwenden?**

Ja. Metered ist ein zusätzlicher Lizenzierungsmechanismus, der neben bestehenden [licensing methods](/slides/de/nodejs-java/licensing/) verwendet werden kann. Sie wählen beim Start der Anwendung, welcher Mechanismus angewendet wird.

**Was wird bei einer Metered‑Lizenz genau verbraucht: Vorgänge oder Dateien?**

Es wird die API‑Nutzung gezählt, also die Anzahl von Anfragen oder Vorgängen. Den aktuellen Verbrauch können Sie über die [consumption‑tracking methods](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/) abrufen.

**Ist Metered für Microservices und serverlose Umgebungen geeignet, in denen Instanzen häufig neu gestartet werden?**

Ja. Da die Abrechnung auf Ebene von API‑Aufrufen erfolgt, sind Szenarien mit häufigen Cold Starts kompatibel, vorausgesetzt, es besteht ein stabiler Netzwerkzugang für die Metered‑Berechnungen.

**Unterscheidet sich die Funktionsweise der Bibliothek bei Verwendung einer Metered‑Lizenz im Vergleich zu einer perpetual‑Lizenz?**

Nein. Es betrifft ausschließlich den Lizenz‑ und Abrechnungsmechanismus; die Fähigkeiten des Produkts bleiben unverändert.

**Wie verhält sich Metered im Vergleich zur Testversion und zur temporären Lizenz?**

Die Testversion hat Einschränkungen und Wasserzeichen, die [temporary license](https://purchase.aspose.com/temporary-license/) entfernt die Einschränkungen für 30 Tage, und Metered entfernt die Einschränkungen und berechnet nach tatsächlicher Nutzung.

**Kann ich das Budget kontrollieren, indem ich bei Überschreiten eines Verbrauchslimits automatisch reagiere?**

Ja. Ein gängiger Ansatz ist, periodisch den aktuellen Verbrauch über die [tracking methods](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/) auszulesen und eigene Limits oder Alarme auf Anwendungs‑ oder Monitoring‑Ebene zu implementieren.