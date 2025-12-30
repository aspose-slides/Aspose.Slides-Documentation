---
title: Metered-Lizenzierung
type: docs
weight: 100
url: /de/php-java/metered-licensing/
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
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Aspose.Slides für PHP über Java Metered-Lizenzierung Ihnen ermöglicht, PowerPoint- und OpenDocument-Dateien flexibel zu verarbeiten und nur für das zu bezahlen, was Sie nutzen."
---

## **Metered-Schlüssel anwenden**

{{% alert color="primary" %}} 

Metered‑Lizenzierung ist ein neuer Lizenzierungsmechanismus, der neben bestehenden Lizenzierungsmethoden verwendet werden kann. Wenn Sie basierend auf Ihrer Nutzung der Aspose.Slides‑API‑Funktionen abgerechnet werden möchten, wählen Sie die metered‑Lizenzierung.

Wenn Sie eine metered‑Lizenz erwerben, erhalten Sie Schlüssel (und keine Lizenzdatei). Dieser metered‑Schlüssel kann mithilfe der von Aspose bereitgestellten Klasse [Metered](https://reference.aspose.com/slides/php-java/aspose.slides/metered/) für Messvorgänge angewendet werden. Weitere Details finden Sie in den [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. Erstellen Sie eine Instanz der Klasse [Metered](https://reference.aspose.com/slides/php-java/aspose.slides/metered/).

2. Übergeben Sie Ihre öffentlichen und privaten Schlüssel an die Methode [setMeteredKey](https://reference.aspose.com/slides/php-java/aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-).

3. Führen Sie einige Verarbeitungen durch (Aufgaben ausführen).

4. Rufen Sie die Methode [getConsumptionQuantity](https://reference.aspose.com/slides/php-java/aspose.slides/metered/#getConsumptionQuantity--) der Klasse `Metered` auf.

Sie sollten die Menge/Anzahl der API‑Anfragen sehen, die Sie bisher verbraucht haben.

Dieser Beispielcode zeigt, wie Sie die metered‑Lizenzierung verwenden:
```php
// Erstellt eine Instanz der Metered-Klasse
$metered = new Metered();

try {
    // Übergibt die öffentlichen und privaten Schlüssel an das Metered-Objekt
    $metered->setMeteredKey("<valid pablic key>", "<valid private key>");

    // Ruft den Verbrauchswert vor den API-Aufrufen ab
    $amountBefore = Metered::getConsumptionQuantity();
    echo("Amount consumed before: " . $amountBefore);

    // Tut etwas mit der Aspose.Slides API hier
    // ...

    // Ruft den Verbrauchswert nach den API-Aufrufen ab
    $amountAfter = Metered::getConsumptionQuantity();
    echo("Amount consumed after: " . $amountAfter);
} catch (JavaException $ex) {
  $ex->printStackTrace();
}
```


{{% alert color="warning" title="HINWEIS" %}} 

Um die metered‑Lizenzierung zu nutzen, benötigen Sie eine stabile Internetverbindung, da der Lizenzierungsmechanismus das Internet verwendet, um ständig mit unseren Diensten zu interagieren und Berechnungen durchzuführen.

{{% /alert %}} 

## **FAQ**

**Kann ich eine metered‑Lizenz zusammen mit einer regulären (dauerhaften oder temporären) Lizenz in derselben Anwendung verwenden?**

Ja. Metered ist ein zusätzlicher Lizenzierungsmechanismus, der neben den bestehenden [Lizenzierungsmethoden](/slides/de/php-java/licensing/) verwendet werden kann. Sie wählen aus, welcher Mechanismus beim Start der Anwendung angewendet wird.

**Was genau wird bei einer metered‑Lizenz als Verbrauch gezählt: Vorgänge oder Dateien?**

Der API‑Verbrauch wird gezählt, also die Anzahl der Anfragen oder Vorgänge. Den aktuellen Verbrauch können Sie über die [Verbrauch‑Tracking‑Methoden](https://reference.aspose.com/slides/php-java/aspose.slides/metered/) abrufen.

**Ist metered für Microservices und Serverless‑Umgebungen geeignet, in denen Instanzen häufig neu starten?**

Ja. Da die Abrechnung auf Ebene von API‑Aufrufen erfolgt, sind Szenarien mit häufigen Cold‑Starts kompatibel, vorausgesetzt, es besteht ein stabiler Netzwerkzugriff für die metered‑Berechnungen.

**Unterscheidet sich die Funktionalität der Bibliothek bei Verwendung einer metered‑Lizenz im Vergleich zu einer dauerhaften Lizenz?**

Nein. Es geht nur um den Lizenz‑ und Abrechnungsmechanismus; die Fähigkeiten des Produkts bleiben unverändert.

**Wie steht metered im Zusammenhang mit der Testversion und der temporären Lizenz?**

Die Testversion hat Einschränkungen und Wasserzeichen, die [temporäre Lizenz](https://purchase.aspose.com/temporary-license/) entfernt die Einschränkungen für 30 Tage, und metered entfernt die Einschränkungen und berechnet basierend auf tatsächlicher Nutzung.

**Kann ich das Budget steuern, indem ich automatisch reagiere, wenn ein Verbrauchsschwellenwert überschritten wird?**

Ja. Eine gängige Praxis ist, den aktuellen Verbrauch periodisch über die [Tracking‑Methoden](https://reference.aspose.com/slides/php-java/aspose.slides/metered/) auszulesen und eigene Beschränkungen oder Benachrichtigungen auf Anwendungs‑ oder Überwachungsebene zu implementieren.