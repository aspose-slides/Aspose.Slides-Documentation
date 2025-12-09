---
title: Systemanforderungen
type: docs
weight: 60
url: /de/python-net/system-requirements/
keywords:
- Systemanforderungen
- Betriebssystem
- Installation
- Abhängigkeiten
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Entdecken Sie die Systemanforderungen von Aspose.Slides für Python via .NET. Stellen Sie nahtlose Unterstützung für PowerPoint und OpenDocument unter Windows, Linux und macOS sicher."
---

## **Einführung**

Aspose.Slides for Python via .NET erfordert keine Drittanbieterprodukte, wie Microsoft PowerPoint, installiert zu haben. Aspose.Slides ist eine Engine zum Erstellen, Ändern, Konvertieren und Rendern von Dokumenten in verschiedenen Formaten, einschließlich Microsoft PowerPoint‑Präsentationsformaten.

## **Unterstützte Betriebssysteme**

Aspose.Slides for Python unterstützt Windows (32‑Bit und 64‑Bit), macOS und 64‑Bit‑Linux auf Systemen mit Python 3.5 oder höher.

<table>  
    <tr>
        <td style="font-weight: bold; width:400px">Betriebssystem</td>
        <td style="font-weight: bold; width:400px">Versionen</td>
    </tr>
    <tr>
        <td>Microsoft Windows</td>
        <td>
            <ul>
                <li>Windows 2003 Server</li>
                <li>Windows 2008 Server</li>
                <li>Windows 2012 Server</li>
                <li>Windows 2012 R2 Server</li>
                <li>Windows 2016 Server</li>
                <li>Windows 2019 Server</li>
                <li>Windows XP</li>
                <li>Windows Vista</li>
                <li>Windows 7</li>
                <li>Windows 8, 8.1</li>
                <li>Windows 10</li>
                <li>Windows 11</li>
            </ul>
        </td>
    </tr>
    <tr>
        <td>Linux</td>
        <td>
            <ul>
                <li>Ubuntu</li>
                <li>OpenSUSE</li>
                <li>CentOS</li>
                <li>und andere</li>
            </ul>
        </td>
    </tr>
    <tr>
        <td>macOS</td>
        <td>
            <ul>
                <li>12 „Monterey“</li>
            </ul>
        </td>
    </tr>
</table>

## **Systemanforderungen für Ziel‑Linux‑ und macOS‑Plattformen**

- GCC‑6‑Laufzeitbibliotheken (oder neuer).
- [libgdiplus](https://github.com/mono/libgdiplus), eine Open‑Source‑Implementierung der GDI+‑API.
- Abhängigkeiten des .NET‑Core‑Runtimes. Die Installation des .NET‑Core‑Runtimes selbst ist NICHT erforderlich.
- Für Python 3.5–3.7: Der `pymalloc`‑Build von Python ist erforderlich. Die Build‑Option `--with-pymalloc` ist standardmäßig aktiviert. Typischerweise ist der `pymalloc`‑Build von Python durch ein `m`‑Suffix im Dateinamen gekennzeichnet.
- Die gemeinsam genutzte Bibliothek `libpython`. Die Build‑Option `--enable-shared` von Python ist standardmäßig deaktiviert, und einige Python‑Distributionen enthalten die gemeinsam genutzte Bibliothek `libpython` nicht. Auf manchen Linux‑Plattformen kann die gemeinsam genutzte Bibliothek `libpython` über den Paketmanager installiert werden (z. B. `sudo apt-get install libpython3.7`). Ein häufiges Problem ist, dass die `libpython`‑Bibliothek an einem nichtstandardmäßigen Ort für Shared‑Libraries installiert ist. Dies kann behoben werden, indem beim Kompilieren von Python alternative Bibliothekspfade über Build‑Optionen gesetzt werden oder indem ein symbolischer Link zur `libpython`‑Bibliotheksdatei im standardmäßigen System‑Shared‑Library‑Verzeichnis erstellt wird. Typischerweise lautet der Dateiname der gemeinsam genutzten Bibliothek `libpythonX.Ym.so.1.0` für Python 3.5–3.7 oder `libpythonX.Y.so.1.0` für Python 3.8 oder neuer (z. B. `libpython3.7m.so.1.0`, `libpython3.9.so.1.0`).

## **FAQ**

**Muss Microsoft PowerPoint für Konvertierungen und das Rendern installiert sein?**

Nein, PowerPoint ist nicht erforderlich; Aspose.Slides ist eine eigenständige Engine zum [Erstellen](/slides/de/python-net/create-presentation/), Ändern, [Konvertieren](/slides/de/python-net/convert-presentation/) und [Rendern](/slides/de/python-net/convert-powerpoint-to-png/) von Präsentationen.

**Ist eine bestimmte .NET-Version (Core/5+/6+) auf dem Rechner erforderlich?**

Die Installation des .NET‑Runtimes selbst ist nicht erforderlich, aber seine Abhängigkeiten müssen auf Linux/macOS vorhanden sein. Das bedeutet, das System sollte die Pakete enthalten, die üblicherweise als .NET‑Abhängigkeiten installiert werden, ohne den Runtime‑Komplettinstall zu benötigen.

**Welche Schriftarten werden für korrektes Rendern benötigt?**

In der Praxis müssen die in der Präsentation verwendeten Schriftarten oder passende [Ersatzschriften](/slides/de/python-net/font-substitution/) verfügbar sein. Um ein konsistentes Rendern auf Linux/macOS sicherzustellen, empfiehlt es sich, gängige Schriftpakete zu installieren.