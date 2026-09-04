---
title: Einschränkungen und API-Unterschiede
type: docs
weight: 100
url: /de/python-java/limitations-and-api-differences/
keywords:
- Aspose.Slides für Python über Java
- API-Unterschiede
- Python
- Java
- JPype
- JVM-Einschränkungen
- PowerPoint
description: "Erfahren Sie mehr über JVM-Einschränkungen und API-Unterschiede zwischen Aspose.Slides für Java und Python über Java, einschließlich Importen, Ressourcenbereinigung und Dateiverarbeitung."
---
## **Übersicht**

Aspose.Slides für Python über Java verwendet JPype, um von Python aus auf die Java‑Bibliothek zuzugreifen. Die nachstehenden Beispiele vergleichen Paketimporte, das Erstellen von Präsentationen und die Dateiverarbeitung in den beiden APIs.

## **Bekannte Einschränkungen**

- **JVM‑Lebenszyklus:** JPype unterstützt eine JVM pro Python‑Prozess. Nach dem Herunterfahren kann sie im selben Prozess nicht erneut gestartet werden. Starten Sie sie einmal und verwenden Sie sie für nachfolgende Präsentations‑Operationen wieder.
- **Kompatibilität der Architektur:** Python und Java müssen über passende Architekturen verfügen. Siehe [Systemanforderungen](/slides/de/python-java/system-requirements/#python-java-and-jpype-requirements) für Details.

Weitere Details zu diesen Einschränkungen und zur Java‑Interoperabilität finden Sie im [JPype-Benutzerhandbuch](https://jpype.readthedocs.io/en/latest/userguide.html).

## **Unterschiede in der öffentlichen API**

Vergleichen Sie die nachstehenden Java‑ und Python‑Beispiele. Details zu den Mitgliedern von Python über Java finden Sie in der [API‑Referenz](/slides/de/python-java/api-reference/).

### **Importieren der Bibliothek**

Java importiert Klassen aus `com.aspose.slides`. In Python importieren Sie `asposeslides`, bevor Sie die JVM starten, und danach Klassen aus `asposeslides.api`, sobald die JVM läuft. Verwenden Sie [jpype.isJVMStarted](https://jpype.readthedocs.io/en/latest/api.html#jpype.isJVMStarted), um zu vermeiden, dass eine bereits laufende JVM gestartet wird.

**Aspose.Slides for Java**

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
```

**Aspose.Slides for Python via Java**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
```

{{% alert color="info" title="Note" %}}
Die Python‑Beispiele lassen die JVM laufen, bis der Python‑Prozess beendet wird. In einem Notebook können Sie die aktive JVM über mehrere Zellen hinweg wiederverwenden. Falls sie bereits heruntergefahren wurde, starten Sie den Notebook‑Kernel neu, bevor Sie Java‑Objekte erneut verwenden.
{{% /alert %}}

### **Erstellen einer Präsentation**

Java verwendet das Schlüsselwort `new`; Python ruft die Klasse [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) direkt auf. Geben Sie Präsentationsressourcen mit [Presentation.dispose](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#dispose) in einem `finally`‑Block frei.

Beide Beispiele speichern eine leere Präsentation mit [Presentation.save](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#save) und [SaveFormat.Pptx](https://reference.aspose.com/slides/de/python-java/aspose.slides/saveformat/#pptx).

**Aspose.Slides for Java**

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    presentation.save("new-presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Aspose.Slides for Python via Java**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.save("new-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Dateien lesen und Formatkonstanten verwenden**

Java kann eine Präsentation aus einem Java‑Eingabestream laden. In Python lesen Sie die Datei als Binärdaten und übergeben die resultierenden Bytes an [Presentation.createPresentationFromBytes](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#createpresentationfrombytes). Ein Python‑Dateiobjekt ist kein Java‑Eingabestream.

Die nachstehenden Beispiele benötigen eine vorhandene `presentation.pptx` im Arbeitsverzeichnis und speichern eine Kopie als `result.pptx`. Beide schließen die Eingabedatei und geben Präsentationsressourcen frei. Das Python‑Beispiel liest die gesamte Eingabedatei in den Speicher.

**Aspose.Slides for Java**

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.FileInputStream;
import java.io.InputStream;

try (InputStream inputStream = new FileInputStream("presentation.pptx")) {
    Presentation presentation = new Presentation(inputStream);
    try {
        presentation.save("result.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

**Aspose.Slides for Python via Java**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

with open("presentation.pptx", "rb") as input_file:
    data = input_file.read()

presentation = Presentation.createPresentationFromBytes(data)
try:
    presentation.save("result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Muss ich die JVM für jede Präsentation neu starten?**

Nein. Lassen Sie die JVM laufen und erstellen bzw. entsorgen Sie Präsentationsobjekte nach Bedarf. Das Herunterfahren der JVM verhindert weitere Java‑Operationen im selben Python‑Prozess.

**Kann ich eine Präsentation direkt von einem Dateipfad aus öffnen?**

Ja. Der Konstruktor [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) akzeptiert einen Dateipfad. Verwenden Sie den bytebasierten Helfer, wenn die Präsentationsdaten bereits als Python‑Bytes vorliegen.

**Soll ich die Namen der Formatkonstanten ändern, wenn ich Java‑Beispiele nach Python übertrage?**

Nein. Beispielsweise verwendet [SaveFormat.Pptx](https://reference.aspose.com/slides/de/python-java/aspose.slides/saveformat/#pptx) in beiden APIs die gleiche Schreibweise und Groß‑/Kleinschreibung.