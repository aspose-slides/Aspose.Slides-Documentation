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
description: "Installieren Sie Aspose.Slides für Python via Java unter Windows, Linux oder macOS, konfigurieren Sie Java und JPype und prüfen Sie die Einrichtung mit einem funktionierenden Beispiel."
---
Aspose.Slides für Python via Java läuft unter Windows, Linux und macOS. Es verwendet JPype, um von Python aus auf die Java‑Bibliothek zuzugreifen. Microsoft PowerPoint ist nicht erforderlich.

## **Voraussetzungen**

Bevor Sie die Python‑Pakete installieren, installieren Sie Python und ein JDK, das die [Systemanforderungen](/slides/de/python-java/system-requirements/) erfüllt. Auf dieser Seite finden Sie kompatible Versionen, Architektur‑Anforderungen und alle Abhängigkeiten, die zum Build von JPype aus dem Quellcode nötig sind.

Setzen Sie `JAVA_HOME` auf das JDK‑Installationsverzeichnis, **nicht** auf dessen Unterverzeichnis `bin`, und fügen Sie das `bin`‑Verzeichnis des JDK zum `PATH` hinzu. Öffnen Sie nach dem Ändern der Umgebungsvariablen ein neues Terminal.

## **Installation von PyPI**

Führen Sie die folgenden Befehle in einem Terminal aus, **nicht** in der interaktiven Python‑Eingabeaufforderung. Erstellen Sie ein Projektverzeichnis und eine virtuelle Umgebung, um die Pakete vom Rest Ihrer Projekte zu isolieren.

### **Windows**

Wenn Ihr gewählter Python‑Interpreter als `python` im `PATH` verfügbar ist, führen Sie die folgenden Befehle in der Eingabeaufforderung aus:

```bat
mkdir slides-example
cd slides-example
python -m venv .venv
.venv\Scripts\activate.bat
```

### **Linux und macOS**

Wenn Ihre gewünschte Python‑Version als `python3` verfügbar ist, führen Sie die folgenden Befehle in Bash oder zsh aus:

```bash
mkdir slides-example
cd slides-example
python3 -m venv .venv
source .venv/bin/activate
```

Unter Debian oder Ubuntu schlägt das Anlegen der Umgebung fehl, weil `ensurepip` nicht verfügbar ist. Installieren Sie dann das Paket `python3-venv` mit `sudo apt-get install python3-venv` und wiederholen Sie den Befehl zum Erstellen der Umgebung. Eine separat installierte Python‑Version benötigt möglicherweise das zugehörige versionsspezifische `venv`‑Paket.

### **Pakete installieren**

Nachdem die virtuelle Umgebung aktiviert ist, installieren Sie JPype und Aspose.Slides:

```sh
python -m pip install --upgrade pip
python -m pip install JPype1 aspose-slides-java
```

Die Verwendung von `python -m pip` stellt sicher, dass die Pakete für den Interpreter installiert werden, der Ihre Anwendung ausführt.

Um eine bestehende Aspose.Slides‑Installation zu aktualisieren, führen Sie `python -m pip install --upgrade aspose-slides-java` in derselben Umgebung aus.

## **Installation aus einem ZIP‑Archiv**

Sie können die Bibliothek auch von der [Aspose.Slides‑Downloadseite](https://releases.aspose.com/slides/de/python-java/) verwenden:

1. Installieren Sie Python und Java wie in den **Voraussetzungen** beschrieben.
2. Erstellen und aktivieren Sie eine virtuelle Umgebung gemäß den obigen Anweisungen.
3. Installieren Sie JPype mit `python -m pip install JPype1`.
4. Laden Sie das ZIP‑Archiv *Aspose.Slides für Python via Java* herunter und entpacken Sie es.
5. Finden Sie das entpackte Verzeichnis `asposeslides`. Bewahren Sie dessen Inhalt, einschließlich des `lib`‑Verzeichnisses und der JAR‑Datei, gemeinsam auf.
6. Legen Sie die Datei `example.py` aus dem nächsten Abschnitt neben das Verzeichnis `asposeslides`, sodass Python das Paket importieren kann.

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

Der Import von `asposeslides` registriert die mitgelieferte Java‑Bibliothek, bevor die JVM gestartet wird. Importieren Sie `asposeslides.api` nach dem Start der JVM und geben Sie die Präsentationsressourcen frei, bevor Sie die JVM herunterfahren.

{{% alert color="info" title="Hinweis" %}}

Ohne Lizenz enthält die Ausgabe ein Evaluations‑Wasserzeichen. Siehe [Evaluate Aspose.Slides](/slides/de/python-java/evaluate-aspose-slides/) für Evaluations‑Einschränkungen und Informationen zur temporären Lizenz.

{{% /alert %}}

## **FAQ**

**Warum meldet Python, dass die JVM nicht gefunden oder geladen werden kann?**

Stellen Sie sicher, dass `JAVA_HOME` auf ein JDK zeigt, das mit Ihrer Python‑ und JPype‑Installation kompatibel ist, wie in den [Systemanforderungen](/slides/de/python-java/system-requirements/) beschrieben. Weitere Prüfungen finden Sie im [JPype‑Installations‑Fehlerbehebungs‑Leitfaden](https://jpype.readthedocs.io/en/latest/install.html).

**Warum meldet Python nach der Installation, dass `asposeslides` fehlt?**

Das Paket wurde möglicherweise für einen anderen Python‑Interpreter installiert. Aktivieren Sie die für die Installation verwendete virtuelle Umgebung und führen Sie `python -m pip show aspose-slides-java` aus. Bei einer ZIP‑Installation stellen Sie sicher, dass das Verzeichnis `asposeslides` neben Ihrem Skript liegt oder anderweitig im Modul‑Suchpfad von Python verfügbar ist.

**Kann ich das Beispiel wiederholt in einem Notebook ausführen?**

Das Beispiel ist für einen eigenständigen Python‑Prozess vorgesehen. Bevor Sie es für wiederholte Notebook‑Ausführungen anpassen, lesen Sie die Hinweise zu [Einschränkungen und API‑Unterschieden](/slides/de/python-java/limitations-and-api-differences/#import-the-library) bezüglich des JVM‑Lebenszyklus und der Notebook‑Verwendung.

**Warum schlägt pip mit `CERTIFICATE_VERIFY_FAILED` fehl?**

Verwendet Ihr Netzwerk einen HTTPS‑Inspect‑Proxy, muss pip dessen Zertifizierungsstelle vertrauen. Konfigurieren Sie das vertrauenswürdige CA‑Bundle mittels der pip‑Option `--cert` oder der Umgebungsvariable `PIP_CERT`, gemäß den [pip‑HTTPS‑Zertifikats‑Anweisungen](https://pip.pypa.io/en/stable/topics/https-certificates/). Die benötigte Konfiguration hängt von Ihrem Netzwerk und Ihrer pip‑Version ab.