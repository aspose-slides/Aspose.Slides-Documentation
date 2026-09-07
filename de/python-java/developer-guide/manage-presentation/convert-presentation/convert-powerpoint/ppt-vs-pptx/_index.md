---
title: "Den Unterschied verstehen: PPT vs PPTX"
linktitle: "PPT vs PPTX"
type: docs
weight: 10
url: /de/python-java/ppt-vs-pptx/
keywords:
- "PPT vs PPTX"
- "PPT oder PPTX"
- "Legacy-Format"
- "Modernes Format"
- "Binäres Format"
- "Office Open XML"
- "PowerPoint"
- "Präsentation"
- "Python"
- "Java"
- "Aspose.Slides"
description: "Vergleichen Sie PPT- und PPTX-Formate, Kompatibilität und Konvertierungsoptionen mit Aspose.Slides für Python via Java, einschließlich eines Python-Codebeispiels."
---
## **Überblick**

PPT und PPTX sind PowerPoint‑Präsentationsformate mit unterschiedlichen internen Strukturen und Funktionsunterstützung. PPT ist das ältere Binärformat, das von PowerPoint 97–2003 verwendet wurde. PPTX ist das Office‑Open‑XML‑Format, das mit PowerPoint 2007 eingeführt wurde. Dieser Artikel vergleicht die Formate und zeigt, wie eine PPT‑Datei mit Aspose.Slides für Python via Java in PPTX konvertiert wird.

## **Was ist PPT?**

[PPT](https://docs.fileformat.com/presentation/ppt/) speichert Präsentationsdaten in einer binären Struktur. Das Lesen oder Ändern des Inhalts erfordert Software, die diese Struktur versteht. PPT ist nützlich, wenn Dateien mit älteren PowerPoint‑Versionen ausgetauscht werden, aber die Möglichkeit, neuere Präsentationsfunktionen darzustellen, ist begrenzt.

## **Was ist PPTX?**

[PPTX](https://docs.fileformat.com/presentation/pptx/) basiert auf Office Open XML. Eine PPTX‑Datei ist ein ZIP‑Paket, das XML‑Teile, Medien und Beziehungen zwischen diesen Teilen enthält. Diese Struktur macht das Format leichter zu untersuchen und zu erweitern als das binäre PPT. PowerPoint verwendet PPTX seit PowerPoint 2007 als Standard‑Präsentationsformat.

## **PPT vs PPTX**

| Aspekt | PPT | PPTX |
| --- | --- | --- |
| Interne Struktur | Binäre Datensätze | ZIP‑Paket mit XML und Medien |
| Typische Kompatibilitätsanforderung | PowerPoint 97–2003 Arbeitsabläufe | PowerPoint 2007 und spätere Arbeitsabläufe |
| Neuere Präsentationsfunktionen | Begrenzte Unterstützung; einige Inhalte können vereinfacht werden | Breitere Unterstützung für neuere Objekte und Effekte |
| Empfohlene Verwendung | Austausch mit Systemen, die PPT benötigen | Neue Präsentationen und fortlaufende Bearbeitung |

Das Konvertieren zwischen den Formaten erfordert mehr als das Ändern der Dateierweiterung. Einige PPTX‑Funktionen haben kein direktes Gegenstück in PPT. PowerPoint kann zusätzliche Informationen in speziellen PPT‑Datensätzen, z. B. MetroBlob‑Daten, speichern, um neuere Inhalte für eine spätere Verwendung zu erhalten. Ältere PowerPoint‑Versionen können nicht alle Inhalte anzeigen, sodass das Speichern nicht garantiert, dass eine Präsentation in jedem Viewer gleich aussieht oder sich gleich verhält.

Aspose.Slides für Python via Java bietet eine einheitliche API zum Laden und Speichern beider Formate. Es unterstützt die Konvertierung in beide Richtungen, aber Formatunterschiede und nicht unterstützte Funktionen können das Ergebnis beeinflussen. Verwenden Sie nach Möglichkeit PPTX und prüfen Sie Präsentationen, die nach PPT konvertiert wurden, im jeweiligen Viewer.

{{% alert color="info" title="Note" %}}
Probieren Sie die [Aspose.Slides Conversion app](https://products.aspose.app/slides/de/conversion/) aus, um die Ergebnisse der PPT‑zu‑PPTX‑ und PPTX‑zu‑PPT‑Konvertierung online zu vergleichen.
{{% /alert %}}

## **PPT nach PPTX in Python konvertieren**

Laden Sie die PPT‑Datei mit der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Klasse und rufen Sie anschließend [Presentation.save](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#save) mit [SaveFormat.Pptx](https://reference.aspose.com/slides/de/python-java/aspose.slides/saveformat/#Pptx) auf. Microsoft PowerPoint ist nicht erforderlich.

Das Beispiel startet die Java‑Virtual‑Machine bei Bedarf und gibt Präsentationsressourcen in einem `finally`‑Block frei. Ersetzen Sie die Eingabe‑ und Ausgabepfade durch Ihre eigenen Dateinamen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Laden Sie die alte PPT-Präsentation.
presentation = Presentation("presentation.ppt")
try:
    # Speichern Sie die Präsentation im PPTX-Format.
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Für weitere Beispiele siehe [Convert PPT to PPTX in Python](/slides/de/python-java/convert-ppt-to-pptx/). Für die umgekehrte Konvertierung und deren Kompatibilitätsaspekte siehe [Convert PPTX to PPT in Python](/slides/de/python-java/convert-pptx-to-ppt/).

## **FAQ**

**Gibt es einen Grund, alte Präsentationen im PPT‑Format beizubehalten, wenn sie ohne Fehler geöffnet werden?**

Sie können PPT behalten, wenn ein bestehender Workflow dies erfordert. Für fortlaufende Bearbeitung und neuere Funktionen sollten Sie [die Konvertierung nach PPTX](/slides/de/python-java/convert-ppt-to-pptx/) in Betracht ziehen. Bewahren Sie das Original auf, bis Sie die konvertierte Präsentation überprüft haben.

**Welche Präsentationen sollte ich zuerst nach PPTX konvertieren?**

Priorisieren Sie Dateien, die häufig bearbeitet oder geteilt werden, komplexe [Charts](/slides/de/python-java/create-chart/) oder [Shapes](/slides/de/python-java/shape-manipulations/) enthalten oder Kompatibilitätswarnungen beim [Öffnen](/slides/de/python-java/open-presentation/) auslösen. Prüfen Sie ihr Aussehen und das Verhalten der Bildlauf-Show nach der Konvertierung.

**Wird der Passwortschutz beim Konvertieren zwischen PPT und PPTX beibehalten?**

Gehen Sie nicht davon aus, dass der Schutz des Ausgabedokuments automatisch dem Quellenschutz entspricht. Geben Sie das erforderliche Passwort beim Laden einer verschlüsselten Datei an, konfigurieren Sie den Ausgabeschutz explizit und überprüfen Sie die gespeicherte Datei. Siehe [Password‑Protected Presentations](/slides/de/python-java/password-protected-presentation/).

**Warum verschwinden einige Effekte oder werden einfacher, wenn PPTX nach PPT konvertiert wird?**

PPT kann nicht jedes neuere Objekt, jede Eigenschaft oder jeden Effekt darstellen. Einige Informationen können für eine spätere Wiederherstellung gespeichert werden, aber ältere Viewer können nicht alles anzeigen. Bewahren Sie das Original‑PPTX, wenn Sie neuere Funktionen erhalten müssen.