---
title: Metered-Lizenzierung
type: docs
weight: 90
url: /de/python-net/metered-licensing/
keywords:
- Lizenz
- Metered-Lizenz
- Lizenzschlüssel
- öffentlicher Schlüssel
- privater Schlüssel
- Verbrauchsmenge
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Aspose.Slides für Python via .NET Metered-Lizenzierung es Ihnen ermöglicht, PowerPoint- und OpenDocument-Dateien flexibel zu verarbeiten und nur für das zu bezahlen, was Sie nutzen."
---

## **Metered-Schlüssel anwenden**

{{% alert color="primary" %}} 

Metered-Lizenzierung ist ein neuer Lizenzierungsmechanismus, der neben vorhandenen Lizenzierungsmethoden verwendet werden kann. Wenn Sie basierend auf Ihrer Nutzung der Aspose.Slides API‑Funktionen abgerechnet werden möchten, wählen Sie die Metered‑Lizenzierung.

Wenn Sie eine Metered‑Lizenz erwerben, erhalten Sie Schlüssel (und keine Lizenzdatei). Dieser Metered‑Schlüssel kann mithilfe der von Aspose bereitgestellten [Metered](https://reference.aspose.com/slides/python-net/aspose.slides/metered/)‑Klasse für Messvorgänge angewendet werden. Weitere Details finden Sie in den [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. Erstellen Sie eine Instanz der [Metered](https://reference.aspose.com/slides/python-net/aspose.slides/metered/)‑Klasse.  
1. Übergeben Sie Ihre öffentlichen und privaten Schlüssel an die Methode [set_metered_key](https://reference.aspose.com/slides/python-net/aspose.slides/metered/set_metered_key/#str-str).  
1. Führen Sie einige Verarbeitungsschritte aus (Aufgaben ausführen).  
1. Rufen Sie die Methode [get_consumption_quantity](https://reference.aspose.com/slides/python-net/aspose.slides/metered/get_consumption_quantity/#) der `Metered`‑Klasse auf.

Sie sollten die Menge/Anzahl der bisher von Ihnen konsumierten API‑Anfragen sehen.

Dieser Beispielcode zeigt, wie Sie die Metered‑Lizenzierung verwenden:
```python
import aspose.slides as slides

# Erstellt eine Instanz der Metered-Klasse
metered = slides.Metered()

# Übergibt die öffentlichen und privaten Schlüssel an das Metered-Objekt
metered.set_metered_key("<valid public key>", "<valid private key>")

# Holt den Verbrauchswert vor API-Aufrufen
amount_before = slides.Metered.get_consumption_quantity()
print("Amount consumed before:", amount_before)

# Hier etwas mit der Aspose.Slides API machen
# ...

# Holt den Verbrauchswert nach API-Aufrufen
amount_after = slides.Metered.get_consumption_quantity()
print("Amount consumed after:", amount_after)
```


{{% alert color="warning" title="HINWEIS"  %}} 

Um Metered‑Lizenzierung zu verwenden, benötigen Sie eine stabile Internetverbindung, da der Lizenzierungsmechanismus das Internet nutzt, um ständig mit unseren Diensten zu interagieren und Berechnungen durchzuführen.

{{% /alert %}} 

## **FAQ**

**Kann ich eine Metered‑Lizenz zusammen mit einer regulären Lizenz (unbefristet oder zeitlich befristet) in derselben Anwendung verwenden?**

Ja. Metered ist ein zusätzlicher Lizenzierungsmechanismus, der neben bestehenden [Lizenzierungsmethoden](/slides/de/python-net/licensing/) verwendet werden kann. Sie wählen beim Start der Anwendung, welcher Mechanismus angewendet wird.

**Was genau wird bei einer Metered‑Lizenz als Verbrauch gezählt: Vorgänge oder Dateien?**

Der API‑Verbrauch wird gezählt, also die Anzahl der Anfragen oder Vorgänge. Sie können den aktuellen Verbrauch über die [Verbrauchserfassung‑Methoden](https://reference.aspose.com/slides/python-net/aspose.slides/metered/) abrufen.

**Ist Metered für Microservices und serverlose Umgebungen geeignet, in denen Instanzen häufig neu gestartet werden?**

Ja. Da die Abrechnung auf API‑Aufruf‑Ebene erfolgt, sind Szenarien mit häufigen Cold‑Starts kompatibel, vorausgesetzt, es besteht ein stabiler Netzwerkzugriff für Metered‑Berechnungen.

**Unterscheidet sich die Funktionalität der Bibliothek bei Verwendung einer Metered‑Lizenz im Vergleich zu einer unbefristeten Lizenz?**

Nein. Dies betrifft nur den Lizenz‑ und Abrechnungsmechanismus; die Fähigkeiten des Produkts bleiben unverändert.

**Wie steht Metered im Zusammenhang mit der Testversion und der temporären Lizenz?**

Die Testversion hat Einschränkungen und Wasserzeichen, die [temporäre Lizenz](https://purchase.aspose.com/temporary-license/) beseitigt die Einschränkungen für 30 Tage, und Metered beseitigt die Einschränkungen und berechnet basierend auf der tatsächlichen Nutzung.

**Kann ich das Budget kontrollieren, indem ich automatisch reagiere, wenn ein Verbrauchsschwellenwert überschritten wird?**

Ja. Eine gängige Praxis ist, den aktuellen Verbrauch regelmäßig über die [Verfolgungsmethoden](https://reference.aspose.com/slides/python-net/aspose.slides/metered/) auszulesen und eigene Limits oder Warnungen auf Anwendungs‑ oder Überwachungsebene zu implementieren.