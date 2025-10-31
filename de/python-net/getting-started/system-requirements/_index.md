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
description: "Entdecken Sie Aspose.Slides für Python über .NET Systemanforderungen. Stellen Sie nahtlose PowerPoint‑ und OpenDocument‑Unterstützung unter Windows, Linux und macOS sicher."
---

## **Einführung**

Aspose.Slides für Python via .NET erfordert keine Drittanbieter‑Produkte, wie Microsoft PowerPoint, die installiert sein müssen. Aspose.Slides ist eine Engine zum Erstellen, Ändern, Konvertieren und Rendern von Dokumenten in verschiedenen Formaten, einschließlich Microsoft‑PowerPoint‑Präsentationsformaten.

## **Unterstützte Betriebssysteme**

Aspose.Slides für Python unterstützt Windows (32‑Bit und 64‑Bit), macOS und 64‑Bit‑Linux auf Systemen mit installierten Python 3.5 oder höher.

<table>  
    <tr>
        <td style="font-weight: bold; width:400px">Betriebssystem</td>
        <td style="font-weight: bold; width:400px">Versionen</td>
    </tr>
    <tr>
        <td>Microsoft Windows</td>
        <td>
            <ul>
                <li>Windows 2003 Server</li>
                <li>Windows 2008 Server</li>
                <li>Windows 2012 Server</li>
                <li>Windows 2012 R2 Server</li>
                <li>Windows 2016 Server</li>
                <li>Windows 2019 Server</li>
                <li>Windows XP</li>
                <li>Windows Vista</li>
                <li>Windows 7</li>
                <li>Windows 8, 8.1</li>
                <li>Windows 10</li>
                <li>Windows 11</li>
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
                <li>12 „Monterey“</li>
            </ul>
        </td>
    </tr>
</table>

## **Systemanforderungen für Ziel‑Linux‑ und macOS‑Plattformen**

- GCC 6‑Laufzeitbibliotheken (oder neuer).
- [libgdiplus](https://github.com/mono/libgdiplus), eine Open‑Source‑Implementierung der GDI+‑API.
- Abhängigkeiten des .NET‑Core‑Runtimes. Die Installation des .NET‑Core‑Runtimes selbst ist NICHT erforderlich.
- Für Python 3.5–3.7: Der `pymalloc`‑Build von Python ist erforderlich. Die Build‑Option `--with-pymalloc` ist standardmäßig aktiviert. In der Regel ist der `pymalloc`‑Build von Python im Dateinamen mit einem `m`‑Suffix gekennzeichnet.
- Die gemeinsam genutzte Bibliothek `libpython`. Die Build‑Option `--enable-shared` von Python ist standardmäßig deaktiviert, und manche Python‑Distributionen enthalten die `libpython`‑Shared‑Library nicht. Auf einigen Linux‑Plattformen können Sie die `libpython`‑Shared‑Library über den Paketmanager installieren (z. B. `sudo apt-get install libpython3.7`). Ein häufiges Problem ist, dass die `libpython`‑Bibliothek an einem nichtstandardmäßigen Ort für Shared‑Libraries abgelegt ist. Sie können dies beheben, indem Sie beim Kompilieren von Python Build‑Optionen verwenden, um alternative Bibliothekspfade festzulegen, oder indem Sie einen symbolischen Link zur `libpython`‑Bibliotheksdatei im standardsmäßigen Shared‑Library‑Verzeichnis des Systems erstellen. Typischerweise lautet der Dateiname der `libpython`‑Shared‑Library `libpythonX.Ym.so.1.0` für Python 3.5–3.7 oder `libpythonX.Y.so.1.0` für Python 3.8 oder neuer (z. B. `libpython3.7m.so.1.0`, `libpython3.9.so.1.0`).

## **FAQ**

**Muss Microsoft PowerPoint für Konvertierungen und das Rendern installiert sein?**

Nein, PowerPoint ist nicht erforderlich; Aspose.Slides ist eine eigenständige Engine zum [Erstellen](/slides/de/python-net/create-presentation/), Ändern, [Konvertieren](/slides/de/python-net/convert-presentation/) und [Rendern](/slides/de/python-net/convert-powerpoint-to-png/) von Präsentationen.

**Ist eine bestimmte .NET‑Version (Core/5+/6+) auf dem Rechner erforderlich?**

Die Installation des .NET‑Runtimes selbst ist nicht nötig, aber seine Abhängigkeiten müssen unter Linux/macOS vorhanden sein. Das bedeutet, das System sollte die Pakete enthalten, die üblicherweise als .NET‑Abhängigkeiten installiert werden, ohne den kompletten Runtime zu installieren.

**Welche Schriftarten werden für korrektes Rendering benötigt?**

In der Praxis müssen die in der Präsentation verwendeten Schriftarten oder geeignete [Ersatz](/slides/de/python-net/font-substitution/) vorhanden sein. Um ein konsistentes Rendering unter Linux/macOS zu gewährleisten, empfiehlt es sich, gängige Schriftpakete zu installieren.