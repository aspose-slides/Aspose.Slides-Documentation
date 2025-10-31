---
title: Messlizenzierung
type: docs
weight: 90
url: /de/python-net/metered-licensing/
keywords:
- Lizenz
- Messlizenz
- Lizenzschlüssel
- öffentlicher Schlüssel
- privater Schlüssel
- Verbrauchsmenge
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Aspose.Slides für Python via .NET Messlizenzierung Ihnen flexible Verarbeitung von PowerPoint- und OpenDocument-Dateien ermöglicht, wobei Sie nur für das zahlen, was Sie nutzen."
---

## **Metered-Schlüssel anwenden**

{{% alert color="primary" %}} 

Messlizenzierung ist ein neuer Lizenzierungsmechanismus, der neben bestehenden Lizenzierungsmethoden verwendet werden kann. Wenn Sie basierend auf Ihrer Nutzung der Aspose.Slides‑API‑Funktionen abgerechnet werden möchten, wählen Sie Messlizenzierung.

Wenn Sie eine Messlizenz erwerben, erhalten Sie Schlüssel (und keine Lizenzdatei). Dieser Messschlüssel kann mit der von Aspose bereitgestellten [Metered](https://reference.aspose.com/slides/python-net/aspose.slides/metered/)‑Klasse für Messvorgänge angewendet werden. Weitere Details finden Sie in den [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. Erstellen Sie eine Instanz der [Metered](https://reference.aspose.com/slides/python-net/aspose.slides/metered/)‑Klasse.  
2. Übergeben Sie Ihre öffentlichen und privaten Schlüssel an die Methode [set_metered_key](https://reference.aspose.com/slides/python-net/aspose.slides/metered/set_metered_key/#str-str).  
3. Führen Sie einige Verarbeitungen (Aufgaben) aus.  
4. Rufen Sie die Methode [get_consumption_quantity](https://reference.aspose.com/slides/python-net/aspose.slides/metered/get_consumption_quantity/#) der `Metered`‑Klasse auf.

Sie sollten die bisher verbrauchte Menge/Anzahl der API‑Anfragen sehen.

Dieses Beispiel zeigt, wie Sie Messlizenzierung verwenden:

```python
import aspose.slides as slides

# Erstellt eine Instanz der Metered-Klasse
metered = slides.Metered()

# Übergibt die öffentlichen und privaten Schlüssel an das Metered-Objekt
metered.set_metered_key("<valid public key>", "<valid private key>")

# Ruft den verbrauchten Mengenwert vor API-Aufrufen ab
amount_before = slides.Metered.get_consumption_quantity()
print("Amount consumed before:", amount_before)

# Hier etwas mit der Aspose.Slides API machen
# ...

# Ruft den verbrauchten Mengenwert nach API-Aufrufen ab
amount_after = slides.Metered.get_consumption_quantity()
print("Amount consumed after:", amount_after)
```

{{% alert color="warning" title="HINWEIS"  %}} 

Um Messlizenzierung zu nutzen, benötigen Sie eine stabile Internetverbindung, da der Lizenzierungsmechanismus das Internet nutzt, um ständig mit unseren Diensten zu interagieren und Berechnungen durchzuführen.

{{% /alert %}} 

## **FAQ**

**Kann ich eine Messlizenz zusammen mit einer regulären (perpetuellen oder temporären) Lizenz in derselben Anwendung verwenden?**

Ja. Messlizenzierung ist ein zusätzlicher Lizenzierungsmechanismus, der neben bestehenden [Lizenzierungsmethoden](/slides/de/python-net/licensing/) genutzt werden kann. Sie wählen beim Anwendungsstart, welcher Mechanismus angewendet wird.

**Was genau wird bei einer Messlizenz als Verbrauch gezählt: Vorgänge oder Dateien?**

Es wird die API‑Nutzung gezählt, also die Anzahl von Anfragen oder Vorgängen. Den aktuellen Verbrauch können Sie über die [Verbrauchs‑Tracking‑Methoden](https://reference.aspose.com/slides/python-net/aspose.slides/metered/) abrufen.

**Ist Messlizenzierung für Microservices und serverlose Umgebungen geeignet, in denen Instanzen häufig neu gestartet werden?**

Ja. Da die Abrechnung auf Ebene einzelner API‑Aufrufe erfolgt, sind Szenarien mit häufigen Cold Starts kompatibel, vorausgesetzt, es besteht ein stabiler Netzwerkzugriff für die Messberechnungen.

**Unterscheidet sich die Funktionalität der Bibliothek bei Verwendung einer Messlizenz im Vergleich zu einer perpetual‑Lizenz?**

Nein. Es geht lediglich um den Lizenz‑ und Abrechnungsmechanismus; die Produktfähigkeiten bleiben unverändert.

**Wie steht Messlizenzierung im Verhältnis zur Testversion und zur temporären Lizenz?**

Die Testversion hat Einschränkungen und Wasserzeichen, die [temporäre Lizenz](https://purchase.aspose.com/temporary-license/) entfernt diese für 30 Tage, und Messlizenzierung entfernt Einschränkungen und berechnet nur die tatsächliche Nutzung.

**Kann ich das Budget steuern, indem ich automatisch reagiere, wenn ein Verbrauchsschwellenwert überschritten wird?**

Ja. Eine gängige Praxis ist, den aktuellen Verbrauch periodisch über die [Tracking‑Methoden](https://reference.aspose.com/slides/python-net/aspose.slides/metered/) auszulesen und eigene Grenzen oder Alarme auf Anwendungs‑ oder Monitoring‑Ebene zu implementieren.