---
title: Abgerechnete Lizenzierung
type: docs
weight: 90
url: /de/python-net/metered-licensing/
---

{{% alert color="primary" %}} 

Die abgerechnete Lizenzierung ist ein neuer Lizenzierungsmechanismus, der neben bestehenden Lizenzierungsmethoden verwendet werden kann. Wenn Sie basierend auf Ihrer Nutzung der Funktionen der Aspose.Slides-API abgerechnet werden möchten, wählen Sie die abgerechnete Lizenzierung.

Wenn Sie eine abgerechnete Lizenz erwerben, erhalten Sie Schlüssel (und keine Lizenzdatei). Dieser abgerechnete Schlüssel kann mit der von Aspose bereitgestellten [Metered](https://reference.aspose.com/slides/python-net/aspose.slides/metered/) Klasse für Metering-Operationen angewendet werden. Weitere Einzelheiten finden Sie in den [Häufigen Fragen zur abgerechneten Lizenzierung](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. Erstellen Sie eine Instanz der [Metered](https://reference.aspose.com/slides/python-net/aspose.slides/metered/) Klasse.
1. Übergeben Sie Ihre öffentlichen und privaten Schlüssel an die Methode `set_metered_key`.
1. Führen Sie einige Verarbeitungen durch (führen Sie Aufgaben aus).
1. Rufen Sie die Methode `get_consumption_quantity()` der Metered-Klasse auf.

   Sie sollten die Menge/Anzahl der API-Anfragen sehen, die Sie bisher genutzt haben.

Dieser Python-Code zeigt Ihnen, wie Sie die öffentlichen und privaten Schlüssel für die abgerechnete Lizenzierung festlegen:

```python
import aspose.slides as slides

# Erstellt eine Instanz der CAD Metered-Klasse
metered = slides.Metered()

# Greift auf die set_metered_key-Eigenschaft zu und übergibt öffentliche und private Schlüssel als Parameter
metered.set_metered_key("*****", "*****")

# Holt die Menge der abgerechneten Daten vor dem Aufruf der API
amountbefore = slides.metered.get_consumption_quantity()
# Anzeige der Informationen
print("Vorher verbrauchte Menge: " + str(amountbefore))

# Lädt das Dokument von der Festplatte.
with slides.Presentation("Presentation.pptx") as pres:
   # Holt die Seitenanzahl des Dokuments
   print(len(pres.slides))
   # Speichert als PDF
   pres.save("out_pdf.pdf", slides.export.SaveFormat.PDF)

# Holt die Menge der abgerechneten Daten nach dem Aufruf der API
amountafter = slides.metered.get_consumption_quantity()
# Anzeige der Informationen
print("Nachher verbrauchte Menge: " + str(amountafter))
```

{{% alert color="warning" title="HINWEIS"  %}} 

Um die abgerechnete Lizenzierung zu nutzen, benötigen Sie eine stabile Internetverbindung, da der Lizenzierungsmechanismus das Internet verwendet, um ständig mit unseren Diensten zu interagieren und Berechnungen durchzuführen.

{{% /alert %}} 