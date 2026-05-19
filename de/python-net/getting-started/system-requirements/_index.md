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
## **Einleitung**

Aspose.Slides für Python via .NET erfordert keine Drittanbieterprodukte, wie Microsoft PowerPoint, installiert zu werden. Aspose.Slides ist eine Engine zum Erstellen, Ändern, Konvertieren und Rendern von Dokumenten in verschiedenen Formaten, einschließlich Microsoft PowerPoint‑Präsentationsformaten.

## **Unterstützte Betriebssysteme**

Aspose.Slides für Python unterstützt Windows (32‑Bit und 64‑Bit), macOS und 64‑Bit‑Linux auf Systemen mit installiertem Python 3.5 oder neuer.

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

## **Systemanforderungen für Ziel‑Linux‑ und macOS‑Plattformen**

- GCC‑6‑Runtime‑Bibliotheken (oder neuer).
- [libgdiplus](https://github.com/mono/libgdiplus), eine Open‑Source‑Implementierung der GDI+‑API.
- Abhängigkeiten des .NET Core Runtime. Die Installation des .NET Core Runtime selbst ist NICHT erforderlich.
- Für Python 3.5–3.7: Der `pymalloc`‑Build von Python ist erforderlich. Die Build‑Option `--with-pymalloc` ist standardmäßig aktiviert. Typischerweise wird der `pymalloc`‑Build von Python durch ein `m`‑Suffix im Dateinamen gekennzeichnet.
- Die gemeinsam genutzte Bibliothek `libpython`. Die Python‑Build‑Option `--enable-shared` ist standardmäßig deaktiviert, und einige Python‑Distributionen enthalten die `libpython`‑Shared‑Bibliothek nicht. Auf einigen Linux‑Plattformen können Sie die `libpython`‑Shared‑Bibliothek über den Paket‑Manager installieren (zum Beispiel `sudo apt-get install libpython3.7`). Ein häufiges Problem ist, dass die `libpython`‑Bibliothek an einem nicht standardmäßigen Ort für Shared‑Bibliotheken installiert wird. Sie können dies beheben, indem Sie Python‑Build‑Optionen verwenden, um alternative Bibliothekspfade beim Kompilieren von Python festzulegen, oder indem Sie einen symbolischen Link zur `libpython`‑Bibliotheksdatei im standardmäßigen Shared‑Bibliotheksverzeichnis des Systems erstellen. Typischerweise lautet der Dateiname der `libpython`‑Shared‑Bibliothek `libpythonX.Ym.so.1.0` für Python 3.5–3.7 oder `libpythonX.Y.so.1.0` für Python 3.8 oder neuer (zum Beispiel `libpython3.7m.so.1.0`, `libpython3.9.so.1.0`).

## **FAQ**

**Benötige ich Microsoft PowerPoint für Konvertierungen und das Rendering installiert?**

Nein, PowerPoint ist nicht erforderlich; Aspose.Slides ist eine eigenständige Engine zum [Erstellen](/slides/de/python-net/create-presentation/), Ändern, [Konvertieren](/slides/de/python-net/convert-presentation/) und [Rendern](/slides/de/python-net/convert-powerpoint-to-png/) von Präsentationen.

**Ist eine bestimmte .NET‑Version (Core/5+/6+) auf dem Rechner erforderlich?**

Die Installation des .NET‑Runtime selbst ist nicht erforderlich, aber seine Abhängigkeiten müssen auf Linux/macOS vorhanden sein. Das bedeutet, dass das System die Pakete enthalten sollte, die normalerweise als .NET‑Abhängigkeiten installiert werden, ohne den Runtime vollständig zu installieren.

**Welche Schriftarten werden für korrektes Rendering benötigt?**

In der Praxis müssen die in der Präsentation verwendeten Schriftarten oder geeignete [Ersatzschriftarten](/slides/de/python-net/font-substitution/) verfügbar sein. Um ein konsistentes Rendering auf Linux/macOS sicherzustellen, wird empfohlen, gängige Schriftpakete zu installieren.

**Warum wird eine benutzerdefinierte Schriftart unter Linux als Ersatz oder fehlender Text gerendert?**

Wenn die Schriftdatei inkonsistente oder beschädigte Name‑Table‑Einträge enthält, kann der Linux‑Font‑Matching‑Stack (FreeType/fontconfig) einen ungültigen Eintrag auswählen, wodurch die Schriftart nicht aufgelöst wird. Die Verwendung einer Schriftart‑Version mit korrigierten Name‑Table‑Einträgen oder die Installation eines konsistenten Ersatzes löst das Problem.