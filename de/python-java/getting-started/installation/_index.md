---
title: Installation
type: docs
weight: 70
url: /de/python-java/installation/
keywords:
- Aspose.Slides herunterladen
- Aspose.Slides installieren
- Aspose.Slides Installation
- Python
- Java
- JPype
- Windows
- macOS
- Linux
description: "Installieren Sie Aspose.Slides für Python über Java unter Windows, Linux oder macOS, konfigurieren Sie Java und JPype und überprüfen Sie die Einrichtung mit einem funktionierenden Beispiel."
---
Aspose.Slides für Python über Java läuft unter Windows, Linux und macOS. Es verwendet JPype, um von Python aus auf die Java-Bibliothek zuzugreifen. Microsoft PowerPoint ist nicht erforderlich.

## **Voraussetzungen**

Bevor Sie die Python-Pakete installieren, installieren Sie Python und ein JDK, das die [Systemanforderungen](/slides/de/python-java/system-requirements/) erfüllt. Diese Seite listet kompatible Versionen, Architektur­anforderungen und alle Abhängigkeiten auf, die zum Erstellen von JPype aus dem Quellcode benötigt werden.

Setzen Sie `JAVA_HOME` auf das JDK-Installationsverzeichnis, nicht auf dessen Unterverzeichnis `bin`, und fügen Sie das `bin`‑Verzeichnis des JDK zu `PATH` hinzu. Öffnen Sie ein neues Terminal, nachdem Sie die Umgebungsvariablen geändert haben.

## **Installation von PyPI**

Führen Sie die folgenden Befehle in einem Terminal aus, nicht in der interaktiven Python‑Eingabeaufforderung. Erstellen Sie ein Projektverzeichnis und eine virtuelle Umgebung, um die Pakete von anderen Projekten zu isolieren.

### **Windows**

Wenn Ihr ausgewählter Python‑Interpreter als `python` im `PATH` verfügbar ist, führen Sie die folgenden Befehle in der Eingabeaufforderung aus:

```bat
mkdir slides-example
cd slides-example
python -m venv .venv
.venv\Scripts\activate.bat
```

### **Linux und macOS**

Wenn Ihre gewählte Python‑Version als `python3` verfügbar ist, führen Sie die folgenden Befehle in Bash oder zsh aus:

```bash
mkdir slides-example
cd slides-example
python3 -m venv .venv
source .venv/bin/activate
```

Unter Debian oder Ubuntu schlägt die Erstellung der Umgebung fehl, weil `ensurepip` nicht verfügbar ist, installieren Sie das Paket `python3-venv` mit `sudo apt-get install python3-venv` und wiederholen Sie anschließend den Befehl zur Umgebungserstellung. Eine separat installierte Python‑Version benötigt möglicherweise das entsprechende versionsspezifische `venv`‑Paket.

### **Pakete installieren**

Mit aktivierter virtueller Umgebung installieren Sie JPype und Aspose.Slides:

```sh
python -m pip install --upgrade pip
python -m pip install JPype1 aspose-slides-java
```

`python -m pip` stellt sicher, dass die Pakete für den Interpreter installiert werden, der Ihre Anwendung ausführt.

Um eine vorhandene Aspose.Slides‑Installation zu aktualisieren, führen Sie `python -m pip install --upgrade aspose-slides-java` in derselben Umgebung aus.

## **Installation aus einem ZIP-Archiv**

Sie können die Bibliothek auch von der [Aspose.Slides‑Downloadseite](https://releases.aspose.com/slides/python-java/) verwenden:

1. Installieren Sie Python und Java wie unter [Voraussetzungen](#prerequisites) beschrieben.
2. Erstellen und aktivieren Sie eine virtuelle Umgebung nach den obigen Anweisungen.
3. Installieren Sie JPype mit `python -m pip install JPype1`.
4. Laden Sie das ZIP‑Archiv von Aspose.Slides für Python über Java herunter und extrahieren Sie es.
5. Suchen Sie das extrahierte `asposeslides`‑Paketverzeichnis. Bewahren Sie dessen Inhalt, einschließlich des `lib`‑Verzeichnisses und der JAR‑Datei, zusammen auf.
6. Platzieren Sie `example.py` aus dem nächsten Abschnitt neben dem `asposeslides`‑Verzeichnis, damit Python das Paket importieren kann. Das Archiv enthält bereits ein eigenes `example.py` neben `asposeslides`; ersetzen Sie es durch das untenstehende.

## **Installation überprüfen**

Speichern Sie den folgenden Code als `example.py`. Er erstellt eine Präsentation mit einem Textfeld und speichert sie als `out.pptx` im aktuellen Arbeitsverzeichnis.

```python
import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import Presentation, SaveFormat, ShapeType

    presentation = Presentation()
    try:
        slide = presentation.getSlides().get_Item(0)
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 500, 80)
        shape.getTextFrame().setText("Aspose.Slides is ready!")
        presentation.save("out.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    jpype.shutdownJVM()
```

Mit aktivierter virtueller Umgebung führen Sie das Beispiel aus dem Verzeichnis aus, das `example.py` enthält:

```sh
python example.py
```

Der Import von `asposeslides` registriert die mitgelieferte Java‑Bibliothek, bevor die JVM startet. Importieren Sie `asposeslides.api` nach dem Starten der JVM und geben Sie die Präsentations‑Ressourcen frei, bevor Sie sie herunterfahren.

{{% alert color="info" title="Note" %}}
Ohne Lizenz enthält die Ausgabe ein Evaluationswasserzeichen. Siehe [Bewertung von Aspose.Slides](/slides/de/python-java/evaluate-aspose-slides/) für Evaluationsbeschränkungen und Informationen zur temporären Lizenz.
{{% /alert %}}

## **FAQ**

**Warum meldet Python, dass die JVM nicht gefunden oder geladen werden kann?**

Stellen Sie sicher, dass `JAVA_HOME` auf ein JDK zeigt, das mit Ihrer Python‑ und JPype‑Installation kompatibel ist, wie in den [Systemanforderungen](/slides/de/python-java/system-requirements/) beschrieben. Weitere Prüfungen finden Sie im [JPype‑Installations‑Fehlerbehebungs‑Leitfaden](https://jpype.readthedocs.io/en/latest/install.html).

**Warum meldet Python, dass `asposeslides` nach der Installation fehlt?**

Das Paket wurde möglicherweise für einen anderen Python‑Interpreter installiert. Aktivieren Sie die für die Installation verwendete virtuelle Umgebung und führen Sie `python -m pip show aspose-slides-java` aus. Bei einer ZIP‑Installation stellen Sie sicher, dass das `asposeslides`‑Verzeichnis neben Ihrem Skript liegt oder anderweitig im Modul‑Suchpfad von Python verfügbar ist.

**Kann ich das Beispiel wiederholt in einem Notebook ausführen?**

Das Beispiel ist für einen eigenständigen Python‑Prozess gedacht. Bevor Sie es für wiederholte Notebook‑Ausführungen anpassen, lesen Sie die [Einschränkungen und API‑Unterschiede](/slides/de/python-java/limitations-and-api-differences/#import-the-library) bezüglich des JVM‑Lebenszyklus und der Notebook‑Hinweise.

**Warum schlägt pip mit `CERTIFICATE_VERIFY_FAILED` fehl?**

Wenn Ihr Netzwerk einen HTTPS‑Inspection‑Proxy verwendet, muss pip dessen Zertifizierungsstelle vertrauen. Konfigurieren Sie das vertrauenswürdige CA‑Bundle mit pip‑Option `--cert` oder der Umgebungsvariablen `PIP_CERT`, gemäß den [pip‑HTTPS‑Zertifikats‑Anleitungen](https://pip.pypa.io/en/stable/topics/https-certificates/). Die erforderliche Konfiguration hängt von Ihrem Netzwerk und der pip‑Version ab.