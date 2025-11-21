---
title: Metered Lizenzierung
type: docs
weight: 90
url: /de/net/metered-licensing/
keywords:
- Lizenz
- Metered Lizenz
- Lizenzschlüssel
- öffentlicher Schlüssel
- privater Schlüssel
- Verbrauchsmenge
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie die Metered Lizenzierung von Aspose.Slides für .NET es Ihnen ermöglicht, PowerPoint- und OpenDocument-Dateien flexibel zu verarbeiten und nur für das zu bezahlen, was Sie nutzen."
---

## **Metered‑Schlüssel anwenden**

{{% alert color="primary" %}} 

Metered‑Lizenzierung ist ein neuer Lizenzmechanismus, der neben bestehenden Lizenzmethoden verwendet werden kann. Wenn Sie basierend auf Ihrer Nutzung der Aspose.Slides‑API‑Funktionen abgerechnet werden möchten, wählen Sie die Metered‑Lizenzierung.

Beim Kauf einer Metered‑Lizenz erhalten Sie Schlüssel (und keine Lizenzdatei). Dieser Metered‑Schlüssel kann mit der von Aspose bereitgestellten [Metered](https://reference.aspose.com/slides/net/aspose.slides/metered/)‑Klasse für Meter‑Operationen angewendet werden. Weitere Details finden Sie in den [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. Erstellen Sie eine Instanz der [Metered](https://reference.aspose.com/slides/net/aspose.slides/metered/)‑Klasse.  
1. Übergeben Sie Ihre öffentlichen und privaten Schlüssel an die Methode [SetMeteredKey](https://reference.aspose.com/slides/net/aspose.slides/metered/setmeteredkey/).  
1. Führen Sie einige Verarbeitungen (Aufgaben) aus.  
1. Rufen Sie die Methode [GetConsumptionQuantity](https://reference.aspose.com/slides/net/aspose.slides/metered/getconsumptionquantity/) der `Metered`‑Klasse auf.

Sie sollten die bisher verbrauchte Menge/Anzahl von API‑Aufrufen sehen.

Dieses Beispiel zeigt, wie die Metered‑Lizenzierung verwendet wird:

```cs
// Creates an instance of the Metered class
Aspose.Slides.Metered metered = new Aspose.Slides.Metered();

// Passes the public and private keys to the Metered object
metered.SetMeteredKey("<valid public key>", "<valid private key>");

// Gets the metered data quantity before API call
decimal amountBefore = Aspose.Slides.Metered.GetConsumptionQuantity();
Console.WriteLine("Amount consumed before: " + amountBefore.ToString());

// Do something with Aspose.Slides API here
// ...

// Gets the metered data amount after API call
decimal amountAfter = Aspose.Slides.Metered.GetConsumptionQuantity();
Console.WriteLine("Amount consumed after: " + amountAfter.ToString());
```

{{% alert color="warning" title="NOTE"  %}} 

Um die Metered‑Lizenzierung zu nutzen, benötigen Sie eine stabile Internetverbindung, da der Lizenzmechanismus das Internet verwendet, um ständig mit unseren Diensten zu interagieren und Berechnungen durchzuführen.

{{% /alert %}} 

## **FAQ**

**Kann ich eine Metered‑Lizenz zusammen mit einer regulären (perpetuellen oder temporären) Lizenz in derselben Anwendung verwenden?**

Ja. Metered ist ein zusätzlicher Lizenzmechanismus, der neben bestehenden [licensing methods](/slides/de/net/licensing/) verwendet werden kann. Sie entscheiden beim Anwendungsstart, welcher Mechanismus angewendet werden soll.

**Was wird bei einer Metered‑Lizenz genau gezählt: Vorgänge oder Dateien?**

Es wird die API‑Nutzung gezählt, also die Anzahl der Aufrufe bzw. Vorgänge. Den aktuellen Verbrauch können Sie über die [consumption‑tracking methods](https://reference.aspose.com/slides/net/aspose.slides/metered/) abrufen.

**Ist Metered für Microservices und serverlose Umgebungen geeignet, in denen Instanzen häufig neu gestartet werden?**

Ja. Da die Abrechnung auf Ebene der API‑Aufrufe erfolgt, sind Szenarien mit häufigen Cold Starts kompatibel, vorausgesetzt, es besteht ein stabiler Netzwerkzugang für die Metered‑Berechnungen.

**Unterscheidet sich die Funktionalität der Bibliothek bei einer Metered‑Lizenz im Vergleich zu einer perpetual‑Lizenz?**

Nein. Dies betrifft nur den Lizenz‑ und Abrechnungsmechanismus; die Fähigkeiten des Produkts bleiben unverändert.

**Wie steht Metered im Verhältnis zur Testversion und zur temporären Lizenz?**

Die Testversion hat Einschränkungen und Wasserzeichen, die [temporary license](https://purchase.aspose.com/temporary-license/) entfernt die Einschränkungen für 30 Tage, und Metered entfernt die Einschränkungen und berechnet basierend auf dem tatsächlichen Verbrauch.

**Kann ich das Budget steuern, indem ich automatisch reagiere, wenn ein Verbrauchsschwellenwert überschritten wird?**

Ja. Eine gängige Praxis ist es, periodisch den aktuellen Verbrauch über die [tracking methods](https://reference.aspose.com/slides/net/aspose.slides/metered/) auszulesen und eigene Beschränkungen oder Warnungen auf Anwendungs‑ oder Monitoring‑Ebene zu implementieren.