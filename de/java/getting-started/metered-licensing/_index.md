---
title: Metered Lizenzierung
type: docs
weight: 100
url: /de/java/metered-licensing/
keywords:
- Lizenz
- metergesteuerte Lizenz
- Lizenzschlüssel
- öffentlicher Schlüssel
- privater Schlüssel
- Verbrauchsmenge
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Erfahren Sie, wie die metergesteuerte Lizenzierung von Aspose.Slides für Java Ihnen ermöglicht, PowerPoint- und OpenDocument-Dateien flexibel zu verarbeiten und nur für das zu bezahlen, was Sie nutzen."
---
## **Einleitung**

Metergesteuerte Lizenzierung ist ein Lizenzierungsmechanismus, der neben bestehenden Lizenzierungsmethoden verwendet werden kann. Wenn Sie basierend auf Ihrer Nutzung der Aspose.Slides API‑Funktionen abgerechnet werden möchten, wählen Sie die metergesteuerte Lizenzierung.

## **Metergesteuerte Schlüssel anwenden**

{{% alert color="info" %}} 

Metergesteuerte Lizenzierung ist ein neuer Lizenzierungsmechanismus, der neben bestehenden Lizenzierungsmethoden verwendet werden kann. Wenn Sie basierend auf Ihrer Nutzung der Aspose.Slides API‑Funktionen abgerechnet werden möchten, wählen Sie die metergesteuerte Lizenzierung.

Wenn Sie eine metergesteuerte Lizenz erwerben, erhalten Sie Schlüssel (und keine Lizenzdatei). Dieser metergesteuerte Schlüssel kann mithilfe der von Aspose bereitgestellten Klasse [Metered](https://reference.aspose.com/slides/de/java/com.aspose.slides/metered/) für Messvorgänge angewendet werden. Weitere Details finden Sie in den [FAQ zur metergesteuerten Lizenzierung](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. Erstellen Sie eine Instanz der Klasse [Metered](https://reference.aspose.com/slides/de/java/com.aspose.slides/metered/).

1. Übergeben Sie Ihre öffentlichen und privaten Schlüssel an die Methode [setMeteredKey](https://reference.aspose.com/slides/de/java/com.aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-) .

1. Führen Sie einige Verarbeitungen durch (Aufgaben ausführen).

1. Rufen Sie die Methode [getConsumptionQuantity](https://reference.aspose.com/slides/de/java/com.aspose.slides/metered/#getConsumptionQuantity--) der Klasse `Metered` auf.

Sie sollten die Menge/Anzahl der API‑Anfragen sehen, die Sie bisher verbraucht haben.

Dieser Beispielcode zeigt Ihnen, wie Sie die metergesteuerte Lizenzierung verwenden:

```java
// Erstellt eine Instanz der Metered-Klasse
com.aspose.slides.Metered metered = new com.aspose.slides.Metered();

try {
    // Übergibt den öffentlichen und privaten Schlüssel an das Metered-Objekt
    metered.setMeteredKey("<valid public key>", "<valid private key>");

    // Ermittelt den verbrauchten Mengenwert vor den API-Aufrufen
    double amountBefore = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed before: " + amountBefore);

    // Führt hier etwas mit der Aspose.Slides API aus
    // ...

    // Ermittelt den verbrauchten Mengenwert nach den API-Aufrufen
    double amountAfter = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed after: " + amountAfter);
} catch (Exception ex) {
    ex.printStackTrace();
}
```

{{% alert color="warning" title="HINWEIS" %}} 

Um die metergesteuerte Lizenzierung zu verwenden, benötigen Sie eine stabile Internetverbindung, da der Lizenzierungsmechanismus das Internet nutzt, um ständig mit unseren Diensten zu interagieren und Berechnungen durchzuführen.

{{% /alert %}} 

## **FAQ**

### Kann ich eine metergesteuerte Lizenz zusammen mit einer regulären (unbefristeten oder temporären) Lizenz in derselben Anwendung verwenden?

Ja. Metergesteuerte Lizenzierung ist ein zusätzlicher Lizenzierungsmechanismus, der neben bestehenden [Lizenzierungsmethoden](/slides/de/java/licensing/) verwendet werden kann. Sie wählen beim Start der Anwendung, welcher Mechanismus angewendet werden soll.

### Was genau wird unter einer metergesteuerten Lizenz als Verbrauch gezählt: Vorgänge oder Dateien?

Die API‑Nutzung wird gezählt, also die Anzahl der Anfragen oder Vorgänge. Sie können den aktuellen Verbrauch über die [Verbrauchs‑Verfolgungsmethoden](https://reference.aspose.com/slides/de/java/com.aspose.slides/metered/) abrufen.

### Ist die metergesteuerte Lizenzierung für Microservices und serverlose Umgebungen geeignet, in denen Instanzen häufig neu gestartet werden?

Ja. Da die Abrechnung auf Ebene der API‑Aufrufe erfolgt, sind Szenarien mit häufigen Kaltstarts kompatibel, vorausgesetzt, es besteht ein stabiler Netzwerkzugang für die metergesteuerten Berechnungen.

### Unterscheidet sich die Funktionalität der Bibliothek bei Verwendung einer metergesteuerten Lizenz im Vergleich zu einer unbefristeten Lizenz?

Nein. Dabei geht es ausschließlich um den Lizenz‑ und Abrechnungsmechanismus; die Funktionalität des Produkts bleibt unverändert.

### Wie steht die metergesteuerte Lizenzierung im Verhältnis zur Testversion und zur temporären Lizenz?

Die Testversion hat Einschränkungen und Wasserzeichen, die [temporäre Lizenz](https://purchase.aspose.com/temporary-license/) entfernt die Einschränkungen für 30 Tage, und die metergesteuerte Lizenzierung entfernt Einschränkungen und berechnet basierend auf der tatsächlichen Nutzung.

### Kann ich das Budget kontrollieren, indem ich automatisch reagiere, wenn ein Verbrauchsschwellenwert überschritten wird?

Ja. Eine gängige Praxis ist, den aktuellen Verbrauch regelmäßig über die [Verfolgungsmethoden](https://reference.aspose.com/slides/de/java/com.aspose.slides/metered/) auszulesen und eigene Grenzwerte oder Alarme auf Anwendungs‑ oder Überwachungsebene zu implementieren.