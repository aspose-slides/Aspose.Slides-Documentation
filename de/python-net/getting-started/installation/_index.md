---
title: Installation
type: docs
weight: 70
url: /de/python-net/installation/
keywords:
- Aspose.Slides herunterladen
- Aspose.Slides installieren
- Aspose.Slides verwenden
- Installation von Aspose.Slides
- pip
- PyPI
- Windows
- Linux
- macOS
- Python
description: "Installieren Sie Aspose.Slides für Python via .NET von PyPI mit pip unter Windows, Linux und macOS und installieren Sie die nativen Bibliotheken, die Linux und macOS benötigen."
---
## **Übersicht**

Dieser Artikel beschreibt, wie Aspose.Slides für Python via .NET unter Windows, Linux und macOS installiert wird. Das Paket wird auf [PyPI](https://pypi.org/project/aspose.slides/) veröffentlicht und mit pip installiert. Es enthält die .NET‑Laufzeit, die es verwendet, sodass .NET nicht separat installiert werden muss. Unter Linux und macOS benötigt diese Laufzeit native Bibliotheken, die das Betriebssystem möglicherweise nicht bereitstellt; die folgenden Abschnitte nennen sie.

Aspose.Slides für Python via .NET unterstützt Python 3.5 bis 3.14. PyPI stellt Pakete für Windows (32‑Bit und 64‑Bit), Linux (x86_64 und ARM64) und macOS (Intel und Apple‑Silicon) bereit.

## **Windows**

Unter Windows das Paket mit pip installieren. Weitere Bibliotheken sind nicht erforderlich.

```bash
pip install aspose.slides
```

## **Linux**

Unter Linux benötigt die im Paket enthaltene .NET‑Laufzeit zwei Bibliotheken:

- **libgdiplus**, eine Implementierung der Windows‑GDI+‑Grafikschnittstelle. Ohne sie schlägt das Speichern einer Präsentation mit dem Fehler `The type initializer for 'Gdip' threw an exception` fehl.
- **ICU** (International Components for Unicode). Ohne sie beendet sich der Python‑Prozess beim ersten Aufruf von Aspose.Slides mit der Meldung `Couldn't find a valid ICU package installed on the system`.

Unter Debian und Ubuntu beide Bibliotheken mit apt installieren:

```bash
sudo apt-get update && sudo apt-get install -y libgdiplus libicu76
```

Der Name des ICU‑Pakets enthält die Versionsnummer: `libicu76` ist das Paket für Debian 13. Für Debian 12 installiere stattdessen `libicu72` und für Ubuntu 24.04 `libicu74`. Um den Namen auf deinem System zu ermitteln, führe aus:

```bash
apt-cache search --names-only '^libicu[0-9]+$'
```

Anschließend das Paket in einer virtuellen Umgebung installieren. In den aktuellen Debian‑ und Ubuntu‑Versionen erlaubt das systemeigene Python kein `pip install` außerhalb einer virtuellen Umgebung und bricht mit dem Fehler `externally-managed-environment` ab.

```bash
sudo apt-get install -y python3-venv
python3 -m venv .venv
. .venv/bin/activate
pip install aspose.slides
```

Führe deine Skripte mit aktivierter virtueller Umgebung aus. Wenn du ein Python verwendest, das deine Distribution nicht verwaltet, etwa das in den offiziellen `python`‑Docker‑Images, kannst du `pip install aspose.slides` auch ohne virtuelle Umgebung ausführen.

Die in deinen Präsentationen verwendeten Schriften bzw. geeignete Ersatzschriften müssen im System installiert sein, damit Text bei der Konvertierung von Folien zu PDF oder Bildern korrekt gerendert wird.

## **macOS**

Wir haben die Installation unter macOS nicht verifiziert. Unter macOS benötigt Aspose.Slides folgende Voraussetzungen:

- **Python mit Shared‑Libraries**, d. h. Python, das mit der Konfigurationsoption `--enable-shared` gebaut wurde. Wenn du Python mit [pyenv](https://github.com/pyenv/pyenv#homebrew-in-macos) installierst, setze die Umgebungsvariable `PYTHON_CONFIGURE_OPTS` auf `--enable-shared`, wenn du eine Python‑Version installierst.
- **Die libpython‑Bibliothek in einem System‑Bibliotheksverzeichnis.** Ein mit pyenv installiertes Python legt seine libpython‑Bibliothek, z. B. *libpython3.9.dylib*, unter *~/.pyenv/versions* ab; erstelle dort einen symbolischen Link nach */usr/local/lib*.
- **libgdiplus**, eine Implementierung der Windows‑GDI+‑Grafikschnittstelle. Homebrew stellt es als Paket `mono-libgdiplus` bereit.

Anschließend das Paket mit pip installieren.

## **Installation überprüfen**

Um die Installation zu prüfen, speichere das erste Beispiel aus [Create Presentations](/slides/de/python-net/create-presentation/) als *hello.py* und führe `python hello.py` aus. Dabei wird *new_presentation.pptx* im aktuellen Ordner gespeichert.

## **Upgrade**

Um eine bestehende Installation auf die neueste Version zu aktualisieren, führe in der Umgebung, in der du das Paket installiert hast, folgenden Befehl aus:

```bash
pip install --upgrade aspose.slides
```

## **FAQ**

**Kann ich Aspose.Slides in einer virtuellen Umgebung installieren?**

Ja. Du kannst es in jeder Python‑virtuellen Umgebung mit pip installieren. Die nativen Bibliotheken, die Linux und macOS benötigen, werden im System installiert, nicht in der virtuellen Umgebung.

**Kann ich Aspose.Slides in Docker‑Containern verwenden?**

Ja. Das Image muss dieselben nativen Bibliotheken wie ein Linux‑System enthalten – libgdiplus und ICU – sowie die Schriften, die deine Präsentationen verwenden.

**Gibt es eine kostenlose Version oder Einschränkungen in der Testphase?**

Ja. Ohne Lizenz läuft Aspose.Slides im Evaluierungsmodus: Es fügt jedem gespeicherten Folien eine Wasserzeichen‑Anzeige hinzu und kürzt Text, der aus Präsentationen gelesen wird. Um diese Einschränkungen zu entfernen, wende eine gültige [license](/slides/de/python-net/licensing/) an.