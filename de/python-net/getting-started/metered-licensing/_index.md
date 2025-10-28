---
title: Messbasierte Lizenzierung
type: docs
weight: 90
url: /de/python-net/metered-licensing/
keywords:
- Lizenz
- messbasierte Lizenz
- Lizenzschlüssel
- öffentlicher Schlüssel
- privater Schlüssel
- Verbrauchsmenge
- Python
- Aspose.Slides
description: "Erfahren Sie, wie die messbasierte Lizenzierung von Aspose.Slides für Python via .NET es Ihnen ermöglicht, PowerPoint- und OpenDocument-Dateien flexibel zu verarbeiten und nur das zu bezahlen, was Sie nutzen."
---

## **Messbasierte Schlüssel anwenden**

{{% alert color="primary" %}} 

Messbasierte Lizenzierung ist ein neuer Lizenzierungsmechanismus, der neben bestehenden Lizenzierungsverfahren verwendet werden kann. Wenn Sie basierend auf Ihrer Nutzung der Aspose.Slides‑API‑Funktionen abrechnen lassen möchten, wählen Sie die messbasierte Lizenzierung.

Beim Kauf einer messbasierten Lizenz erhalten Sie Schlüssel (und keine Lizenzdatei). Dieser messbasierte Schlüssel kann über die von Aspose bereitgestellte [Metered](https://reference.aspose.com/slides/python-net/aspose.slides/metered/)‑Klasse für Messvorgänge angewendet werden. Weitere Details finden Sie in den [FAQ zur messbasierten Lizenzierung](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. Erstellen Sie eine Instanz der [Metered](https://reference.aspose.com/slides/python-net/aspose.slides/metered/)‑Klasse.
1. Übergeben Sie Ihre öffentlichen und privaten Schlüssel an die Methode [set_metered_key](https://reference.aspose.com/slides/python-net/aspose.slides/metered/set_metered_key/#str-str).
1. Führen Sie die Verarbeitung durch (Aufgaben ausführen).
1. Rufen Sie die Methode [get_consumption_quantity](https://reference.aspose.com/slides/python-net/aspose.slides/metered/get_consumption_quantity/#) der `Metered`‑Klasse auf.

Sie sollten die bisher verbrauchte Menge/Anzahl der API‑Aufrufe sehen.

Dieses Beispiel zeigt, wie die messbasierte Lizenzierung verwendet wird:

```python
import aspose.slides as slides

# Erstellt eine Instanz der Metered‑Klasse
metered = slides.Metered()

# Übergibt die öffentlichen und privaten Schlüssel an das Metered‑Objekt
metered.set_metered_key("<gültiger öffentlicher Schlüssel>", "<gültiger privater Schlüssel>")

# Ermittelt den verbrauchten Mengenwert vor API‑Aufrufen
amount_before = slides.Metered.get_consumption_quantity()
print("Verbrauchter Betrag vorher:", amount_before)

# Hier etwas mit der Aspose.Slides‑API tun
# ...

# Ermittelt den verbrauchten Mengenwert nach API‑Aufrufen
amount_after = slides.Metered.get_consumption_quantity()
print("Verbrauchter Betrag danach:", amount_after)
```

{{% alert color="warning" title="HINWEIS"  %}} 

Um die messbasierte Lizenzierung zu nutzen, benötigen Sie eine stabile Internetverbindung, da der Lizenzierungsmechanismus das Internet verwendet, um ständig mit unseren Diensten zu interagieren und Berechnungen durchzuführen.

{{% /alert %}} 

## **FAQ**

**Kann ich eine messbasierte Lizenz zusammen mit einer regulären (unbefristeten oder temporären) Lizenz in derselben Anwendung verwenden?**

Ja. Messbasierte Lizenzierung ist ein zusätzlicher Lizenzierungsmechanismus, der neben bestehenden [Lizenzierungsmethoden](/slides/de/python-net/licensing/) verwendet werden kann. Sie wählen beim Start der Anwendung, welcher Mechanismus angewendet wird.

**Was genau wird bei einer messbasierten Lizenz als Verbrauch gezählt: Vorgänge oder Dateien?**

Der API‑Verbrauch wird gezählt, d.h. die Anzahl der Anfragen oder Vorgänge. Der aktuelle Verbrauch kann über [Verbrauchs‑Tracking‑Methoden](https://reference.aspose.com/slides/python-net/aspose.slides/metered/) abgerufen werden.

**Ist messbasierte Lizenzierung für Microservices und serverlose Umgebungen geeignet, in denen Instanzen häufig neu gestartet werden?**

Ja. Da die Abrechnung auf Ebene der API‑Aufrufe erfolgt, sind Szenarien mit häufigen Cold Starts kompatibel, vorausgesetzt, es besteht ein stabiler Netzwerkzugriff für die Messberechnungen.

**Unterscheidet sich die Funktionsweise der Bibliothek bei einer messbasierten Lizenz im Vergleich zu einer unbefristeten Lizenz?**

Nein. Dies betrifft ausschließlich den Lizenz‑ und Abrechnungsmechanismus; die Fähigkeiten des Produkts bleiben identisch.

**Wie verhält sich die messbasierte Lizenzierung im Vergleich zur Testversion und zur temporären Lizenz?**

Die Testversion hat Einschränkungen und Wasserzeichen, die [temporäre Lizenz](https://purchase.aspose.com/temporary-license/) entfernt Einschränkungen für 30 Tage, und die messbasierte Lizenzierung entfernt Einschränkungen und berechnet basierend auf dem tatsächlichen Verbrauch.

**Kann ich das Budget steuern, indem ich automatisch reagiere, wenn ein Verbrauchsschwellenwert überschritten wird?**

Ja. Eine gängige Praxis besteht darin, regelmäßig den aktuellen Verbrauch über [Tracking‑Methoden](https://reference.aspose.com/slides/python-net/aspose.slides/metered/) auszulesen und eigene Limits oder Warnungen auf Anwendungsebene oder im Monitoring zu implementieren.