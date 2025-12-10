---
title: Metered-Lizenzierung
type: docs
weight: 100
url: /de/java/metered-licensing/
keywords:
- Lizenz
- Metered-Lizenz
- Lizenzschlüssel
- öffentlicher Schlüssel
- privater Schlüssel
- Verbrauchsmenge
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Aspose.Slides für Java Metered-Lizenzierung Ihnen ermöglicht, PowerPoint- und OpenDocument-Dateien flexibel zu verarbeiten und nur für das zu zahlen, was Sie nutzen."
---

## **Metered-Schlüssel anwenden**

{{% alert color="primary" %}} 

Metered-Lizenzierung ist ein neuer Lizenzierungsmechanismus, der neben bestehenden Lizenzierungsmethoden verwendet werden kann. Wenn Sie basierend auf Ihrer Nutzung der Aspose.Slides API‑Funktionen abgerechnet werden möchten, wählen Sie die Metered‑Lizenzierung.

Wenn Sie eine Metered‑Lizenz erwerben, erhalten Sie Schlüssel (und keine Lizenzdatei). Dieser Metered‑Schlüssel kann mit der von Aspose bereitgestellten Klasse [Metered](https://reference.aspose.com/slides/java/com.aspose.slides/metered/) für Abrechnungsoperationen angewendet werden. Weitere Details finden Sie in den [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. Erstellen Sie eine Instanz der Klasse [Metered](https://reference.aspose.com/slides/java/com.aspose.slides/metered/).

1. Übergeben Sie Ihre öffentlichen und privaten Schlüssel an die Methode [setMeteredKey](https://reference.aspose.com/slides/java/com.aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-) .

1. Führen Sie einige Vorgänge aus (Aufgaben ausführen).

1. Rufen Sie die Methode [getConsumptionQuantity](https://reference.aspose.com/slides/java/com.aspose.slides/metered/#getConsumptionQuantity--) der `Metered`‑Klasse auf.

Sie sollten die bisher verbrauchte Menge/Anzahl von API‑Anfragen sehen.

Dieser Beispielcode zeigt, wie man Metered‑Lizenzierung verwendet:

```java
// Creates an instance of the Metered class
com.aspose.slides.Metered metered = new com.aspose.slides.Metered();

try {
    // Passes the public and private keys to the Metered object
    metered.setMeteredKey("<valid public key>", "<valid private key>");

    // Gets the consumed quantity value before API calls
    double amountBefore = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed before: " + amountBefore);

    // Do something with Aspose.Slides API here
    // ...

    // Gets the consumed quantity value after API calls
    double amountAfter = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed after: " + amountAfter);
} catch (Exception ex) {
    ex.printStackTrace();
}
```

{{% alert color="warning" title="NOTE"  %}} 

Um Metered‑Lizenzierung zu verwenden, benötigen Sie eine stabile Internetverbindung, da der Lizenzierungsmechanismus das Internet nutzt, um ständig mit unseren Diensten zu interagieren und Berechnungen durchzuführen.

{{% /alert %}} 

## **FAQ**

**Kann ich eine Metered‑Lizenz zusammen mit einer regulären (perpetualen oder temporären) Lizenz in derselben Anwendung verwenden?**

Ja. Metered ist ein zusätzlicher Lizenzierungsmechanismus, der neben bestehenden [Lizenzierungsmethoden](/slides/de/java/licensing/) verwendet werden kann. Sie wählen beim Start der Anwendung, welchen Mechanismus Sie anwenden möchten.

**Was genau wird bei einer Metered‑Lizenz als Verbrauch gezählt: Vorgänge oder Dateien?**

Der API‑Verbrauch wird gezählt, also die Anzahl der Anfragen oder Vorgänge. Sie können den aktuellen Verbrauch über die [consumption-tracking methods](https://reference.aspose.com/slides/java/com.aspose.slides/metered/) erhalten.

**Ist Metered für Microservices und serverlose Umgebungen geeignet, in denen Instanzen häufig neu gestartet werden?**

Ja. Da die Abrechnung auf Ebene der API‑Aufrufe erfolgt, sind Szenarien mit häufigen Cold Starts kompatibel, vorausgesetzt, es besteht ein stabiler Netzwerkzugriff für Metered‑Berechnungen.

**Unterscheidet sich die Funktionalität der Bibliothek bei Verwendung einer Metered‑Lizenz im Vergleich zu einer perpetual‑Lizenz?**

Nein. Dies betrifft nur den Lizenz‑ und Abrechnungsmechanismus; die Fähigkeiten des Produkts bleiben unverändert.

**Wie steht Metered im Zusammenhang mit der Testversion und der temporären Lizenz?**

Die Testversion hat Einschränkungen und Wasserzeichen, die [temporäre Lizenz](https://purchase.aspose.com/temporary-license/) entfernt die Einschränkungen für 30 Tage, und Metered entfernt die Einschränkungen und verrechnet nach tatsächlicher Nutzung.

**Kann ich das Budget steuern, indem ich automatisch reagiere, wenn ein Verbrauchsschwellenwert überschritten wird?**

Ja. Eine gängige Praxis besteht darin, den aktuellen Verbrauch periodisch über die [tracking methods](https://reference.aspose.com/slides/java/com.aspose.slides/metered/) auszulesen und eigene Grenzen oder Alarme auf Anwendungs‑ bzw. Überwachungsebene zu implementieren.