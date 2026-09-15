---
title: Metered-Lizenzierung
type: docs
weight: 100
url: /de/python-java/metered-licensing/
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
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Aspose.Slides für Python via Java Metered-Lizenzierung es Ihnen ermöglicht, PowerPoint- und OpenDocument-Dateien flexibel zu verarbeiten und nur für das zu zahlen, was Sie verwenden."
---
## **Einleitung**

Metered-Lizenzierung ist ein Lizenzierungsmechanismus, der neben bestehenden Lizenzierungsmethoden verwendet werden kann. Wenn Sie basierend auf Ihrer Nutzung der Aspose.Slides API‑Funktionen abgerechnet werden möchten, wählen Sie Metered‑Lizenzierung.

## **Metered‑Schlüssel anwenden**

{{% alert color="info" title="Hinweis" %}}

Metered‑Lizenzierung ist ein neuer Lizenzierungsmechanismus, der neben bestehenden Lizenzierungsmethoden verwendet werden kann. Wenn Sie basierend auf Ihrer Nutzung der Aspose.Slides API‑Funktionen abgerechnet werden möchten, wählen Sie Metered‑Lizenzierung.

Wenn Sie eine Metered‑Lizenz erwerben, erhalten Sie Schlüssel (und keine Lizenzdatei). Dieser Metered‑Schlüssel kann mit der [Metered](https://reference.aspose.com/slides/de/python-java/aspose.slides/metered/)‑Klasse, die von Aspose für Meter‑Operationen bereitgestellt wird, angewendet werden. Weitere Details finden Sie in den [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}}

1. Erstellen Sie eine Instanz der [Metered](https://reference.aspose.com/slides/de/python-java/aspose.slides/metered/)‑Klasse.  
2. Übergeben Sie Ihre öffentlichen und privaten Schlüssel an die Methode [setMeteredKey](https://reference.aspose.com/slides/de/python-java/aspose.slides/metered/#setMeteredKey).  
3. Führen Sie einige Verarbeitungen (Aufgaben) aus.  
4. Rufen Sie die Methode [getConsumptionQuantity](https://reference.aspose.com/slides/de/python-java/aspose.slides/metered/#getConsumptionQuantity) der [Metered](https://reference.aspose.com/slides/de/python-java/aspose.slides/metered/)‑Klasse auf.

Sie sollten die bisher verbrauchte Menge/Anzahl von API‑Anfragen sehen.

Dieser Beispielcode zeigt, wie Sie Metered‑Lizenzierung verwenden:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Metered

# Erstellen Sie eine Instanz der Metered-Klasse.
metered = Metered()

try:
    # Übergeben Sie die öffentlichen und privaten Schlüssel an das Metered-Objekt.
    metered.setMeteredKey("<valid public key>", "<valid private key>")

    # Erhalten Sie die verbrauchte Menge vor API-Aufrufen.
    amount_before = Metered.getConsumptionQuantity()
    print("Amount consumed before:", amount_before)

    # Führen Sie hier etwas mit der Aspose.Slides API aus.
    # ...

    # Erhalten Sie die verbrauchte Menge nach API-Aufrufen.
    amount_after = Metered.getConsumptionQuantity()
    print("Amount consumed after:", amount_after)
except Exception as error:
    print(error)
```

{{% alert color="warning" title="Warnung" %}}

Um Metered‑Lizenzierung zu nutzen, benötigen Sie eine stabile Internetverbindung, da der Lizenzierungsmechanismus das Internet verwendet, um ständig mit unseren Diensten zu kommunizieren und Berechnungen durchzuführen.

{{% /alert %}}

## **FAQ**

**Kann ich eine Metered‑Lizenz zusammen mit einer regulären (perpetual oder temporary) Lizenz in derselben Anwendung verwenden?**

Ja. Metered ist ein zusätzlicher Lizenzierungsmechanismus, der neben bestehenden [Lizenzierungsmethoden](/slides/de/python-java/licensing/) verwendet werden kann. Sie wählen beim Anwendungsstart, welcher Mechanismus angewendet wird.

**Was wird bei einer Metered‑Lizenz genau als Verbrauch gezählt: Vorgänge oder Dateien?**

Der API‑Verbrauch wird gezählt, also die Anzahl von Anfragen oder Vorgängen. Den aktuellen Verbrauch können Sie über die [Verbrauchs‑Tracking‑Methoden](https://reference.aspose.com/slides/de/python-java/aspose.slides/metered/) ermitteln.

**Ist Metered für Microservices und serverlose Umgebungen geeignet, in denen Instanzen häufig neu gestartet werden?**

Ja. Da die Abrechnung auf API‑Aufruf‑Ebene erfolgt, sind Szenarien mit häufigen Cold Starts kompatibel, vorausgesetzt, es besteht ein stabiler Netzwerkzugang für die Metered‑Berechnungen.

**Unterscheidet sich die Funktionalität der Bibliothek bei Verwendung einer Metered‑Lizenz im Vergleich zu einer perpetual Lizenz?**

Nein. Es betrifft nur den Lizenz‑ und Abrechnungsmechanismus; die Fähigkeiten des Produkts bleiben unverändert.

**Wie steht Metered im Vergleich zur Testversion und zur temporären Lizenz?**

Die Testversion hat Einschränkungen und Wasserzeichen, die [temporary license](https://purchase.aspose.com/temporary-license/) entfernt die Einschränkungen für 30 Tage, und Metered entfernt Einschränkungen und berechnet basierend auf tatsächlicher Nutzung.

**Kann ich das Budget steuern, indem ich automatisch reagiere, wenn ein Verbrauchsschwellenwert überschritten wird?**

Ja. Ein gängiger Ansatz ist, den aktuellen Verbrauch periodisch über die [Tracking‑Methoden](https://reference.aspose.com/slides/de/python-java/aspose.slides/metered/) auszulesen und eigene Limits oder Warnungen auf Anwendungs‑ oder Monitoring‑Ebene zu implementieren.