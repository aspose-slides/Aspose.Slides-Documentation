---
title: Systemanforderungen
type: docs
weight: 60
url: /de/python-net/getting-started/system-requirements/
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
description: "Entdecken Sie die Systemanforderungen von Aspose.Slides für Python via .NET. Gewährleisten Sie nahtlose PowerPoint- und OpenDocument-Unterstützung unter Windows, Linux und macOS."
---

## **Einleitung**

Aspose.Slides für Python via .NET benötigt keine Drittanbieterprodukte, wie Microsoft PowerPoint, die installiert sein müssen. Aspose.Slides ist eine Engine zum Erstellen, Ändern, Konvertieren und Rendern von Dokumenten in verschiedenen Formaten, einschließlich Microsoft PowerPoint‑Präsentationsformaten.

## **Unterstützte Betriebssysteme**

Aspose.Slides für Python unterstützt Windows (32‑Bit und 64‑Bit), macOS und 64‑Bit‑Linux auf Systemen mit installiertem Python 3.5 oder höher.

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
                <li>12 "Monterey"</li>
            </ul>
        </td>
    </tr>
</table>

## **Systemanforderungen für Linux- und macOS-Zielplattformen**

- GCC‑6‑Laufzeitbibliotheken (oder neuer).  
- [libgdiplus](https://github.com/mono/libgdiplus), eine Open‑Source‑Implementierung der GDI+‑API.  
- Abhängigkeiten des .NET Core‑Runtime. Die Installation des .NET Core‑Runtime selbst ist **NICHT** erforderlich.  
- Für Python 3.5–3.7: Der `pymalloc`‑Build von Python ist erforderlich. Die Build‑Option `--with-pymalloc` ist standardmäßig aktiviert. Typischerweise ist der `pymalloc`‑Build von Python im Dateinamen mit einem `m`‑Suffix gekennzeichnet.  
- Die gemeinsam genutzte Bibliothek `libpython`. Die Build‑Option `--enable-shared` ist standardmäßig deaktiviert, und einige Python‑Distributionen enthalten die Bibliothek `libpython` nicht. Auf manchen Linux‑Plattformen können Sie die Bibliothek `libpython` über den Paket‑Manager installieren (z. B. `sudo apt-get install libpython3.7`). Ein häufiges Problem ist, dass die `libpython`‑Bibliothek an einem nicht standardmäßigen Ort für Shared‑Libraries installiert wird. Sie können dies beheben, indem Sie beim Kompilieren von Python alternative Bibliothekspfade setzen oder einen symbolischen Link zur `libpython`‑Datei im standardmäßigen Bibliothekssuchpfad des Systems erstellen. Typischerweise lautet der Dateiname der `libpython`‑Bibliothek `libpythonX.Ym.so.1.0` für Python 3.5–3.7 oder `libpythonX.Y.so.1.0` für Python 3.8 oder höher (z. B. `libpython3.7m.so.1.0`, `libpython3.9.so.1.0`).

## **FAQ**

**Benötige ich Microsoft PowerPoint für Konvertierungen und Rendering?**

Nein, PowerPoint ist nicht erforderlich; Aspose.Slides ist eine eigenständige Engine zum [Erstellen](/slides/de/python-net/create-presentation/), Ändern, [Konvertieren](/slides/de/python-net/convert-presentation/) und [Rendern](/slides/de/python-net/convert-powerpoint-to-png/) von Präsentationen.

**Ist eine bestimmte .NET‑Version (Core/5+/6+) auf dem Rechner erforderlich?**

Die Installation des .NET‑Runtime selbst ist nicht nötig, aber seine Abhängigkeiten müssen auf Linux/macOS vorhanden sein. Das bedeutet, das System sollte die Pakete enthalten, die üblicherweise als .NET‑Abhängigkeiten installiert werden, ohne das komplette Runtime‑Paket zu installieren.

**Welche Schriftarten werden für korrektes Rendering benötigt?**

In der Praxis müssen die in der Präsentation verwendeten Schriftarten oder geeignete [Ersatzschriften](/slides/de/python-net/font-substitution/) verfügbar sein. Um ein konsistentes Rendering unter Linux/macOS zu gewährleisten, empfiehlt es sich, gängige Schriftpakete zu installieren.