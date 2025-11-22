---
title: Metered Lizenzierung
type: docs
weight: 90
url: /de/net/metered-licensing/
keywords:
- Lizenz
- Metered Lizenzierung
- C#
- Aspose.Slides für .NET
---

## **Metered‑Schlüssel anwenden**

{{% alert color="primary" %}} 

Metered‑Lizenzierung ist ein neuer Lizenzierungsmechanismus, der neben bestehenden Lizenzmethoden verwendet werden kann. Wenn Sie basierend auf Ihrer Nutzung der Aspose.Slides‑API‑Funktionen abgerechnet werden möchten, wählen Sie die Metered‑Lizenzierung.

Beim Kauf einer Metered‑Lizenz erhalten Sie Schlüssel (und keine Lizenzdatei). Dieser Metered‑Schlüssel kann mit der [Metered](https://reference.aspose.com/slides/net/aspose.slides/metered/)‑Klasse verwendet werden, die Aspose für Meter‑Operationen bereitstellt. Weitere Details finden Sie in den [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. Erstellen Sie eine Instanz der [Metered](https://reference.aspose.com/slides/net/aspose.slides/metered/)‑Klasse.  
1. Übergeben Sie Ihre öffentlichen und privaten Schlüssel an die Methode [SetMeteredKey](https://reference.aspose.com/slides/net/aspose.slides/metered/setmeteredkey/).  
1. Führen Sie einige Verarbeitungen (Aufgaben) aus.  
1. Rufen Sie die Methode [GetConsumptionQuantity](https://reference.aspose.com/slides/net/aspose.slides/metered/getconsumptionquantity/) der `Metered`‑Klasse auf.

Sie sollten die bisher verbrauchte Menge/Anzahl von API‑Aufrufen sehen.

Dieses Beispiel zeigt, wie Sie die Metered‑Lizenzierung verwenden:

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

Um Metered‑Lizenzierung zu verwenden, benötigen Sie eine stabile Internetverbindung, da der Lizenzierungsmechanismus das Internet nutzt, um ständig mit unseren Diensten zu kommunizieren und Berechnungen durchzuführen.

{{% /alert %}} 

## **FAQ**

**Kann ich eine Metered‑Lizenz zusammen mit einer regulären (unbefristeten oder temporären) Lizenz in derselben Anwendung verwenden?**

Ja. Metered ist ein zusätzlicher Lizenzierungsmechanismus, der neben den bestehenden [licensing methods](/slides/de/net/licensing/) verwendet werden kann. Sie wählen beim Anwendungsstart, welcher Mechanismus angewendet wird.

**Was wird bei einer Metered‑Lizenz genau als Verbrauch gezählt: Operationen oder Dateien?**

Der API‑Verbrauch wird gezählt, also die Anzahl von Anfragen oder Operationen. Den aktuellen Verbrauch können Sie über die [consumption‑tracking methods](https://reference.aspose.com/slides/net/aspose.slides/metered/) abrufen.

**Eignet sich Metered für Microservices und serverless Umgebungen, in denen Instanzen häufig neu gestartet werden?**

Ja. Da die Abrechnung auf Ebene einzelner API‑Aufrufe erfolgt, sind Szenarien mit häufigen Cold‑Starts kompatibel, sofern ein stabiler Netzwerkzugang für die Metered‑Berechnungen besteht.

**Unterscheidet sich die Funktionalität der Bibliothek bei Verwendung einer Metered‑Lizenz im Vergleich zu einer unbefristeten Lizenz?**

Nein. Es betrifft ausschließlich den Lizenz‑ und Abrechnungsmechanismus; die Produkt‑Funktionalitäten bleiben identisch.

**Wie steht Metered im Verhältnis zur Testversion und zur temporären Lizenz?**

Die Testversion hat Einschränkungen und Wasserzeichen, die [temporary license](https://purchase.aspose.com/temporary-license/) hebt die Einschränkungen für 30 Tage auf, und Metered entfernt Einschränkungen und berechnet basierend auf tatsächlicher Nutzung.

**Kann ich das Budget kontrollieren, indem ich automatisch reagiere, wenn ein Verbrauchsschwellenwert überschritten wird?**

Ja. Eine gängige Praxis ist, den aktuellen Verbrauch periodisch über die [tracking methods](https://reference.aspose.com/slides/net/aspose.slides/metered/) auszulesen und eigene Grenzwerte oder Alarme auf Anwendungs‑ oder Monitoring‑Ebene zu implementieren.