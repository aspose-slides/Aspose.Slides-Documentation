---
title: Systemanforderungen
type: docs
weight: 60
url: /de/python-net/system-requirements/
---
Aspose.Slides für Python über .NET erfordert kein drittes Produkt wie Microsoft PowerPoint, das installiert sein muss. Aspose.Slides selbst ist eine Engine zum Erstellen, Modifizieren, Konvertieren und Rendern von Dokumenten in verschiedenen Formaten, einschließlich der Microsoft PowerPoint-Präsentationsformate.

## Unterstützte Betriebssysteme

Aspose.Slides für Python über .NET unterstützt die Betriebssysteme Windows 64-Bit und 32-Bit, macOS und Linux 64-Bit, auf denen Python 3.5 oder höher installiert ist.

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

## Systemanforderungen für Zielplattformen Linux und macOS

- GCC-6 Runtime-Bibliotheken (oder höher).
- [`libgdiplus`](https://github.com/mono/libgdiplus): eine Open-Source-Implementierung der GDI+ API.
- Abhängigkeiten der .NET Core Runtime. Die Installation der .NET Core Runtime selbst ist NICHT erforderlich.
- Für Python 3.5-3.7: Der `pymalloc` Build von Python wird benötigt. Die `--with-pymalloc` Python Build-Option ist standardmäßig aktiviert. Typischerweise ist der `pymalloc` Build von Python im Dateinamen mit dem `m` Suffix gekennzeichnet.
- `libpython` gemeinsame Python-Bibliothek. Die `--enable-shared` Python Build-Option ist standardmäßig deaktiviert, einige Python-Distributionen enthalten nicht die `libpython` gemeinsame Bibliothek. Für einige Linux-Plattformen kann die `libpython` gemeinsame Bibliothek mit dem Paketmanager installiert werden, zum Beispiel: `sudo apt-get install libpython3.7`. Ein häufiges Problem ist, dass die `libpython` Bibliothek an einem anderen Ort installiert ist als der Standard-Systemort für gemeinsame Bibliotheken. Das Problem kann behoben werden, indem die Python Build-Optionen verwendet werden, um alternativen Bibliothekspfade beim Kompilieren von Python festzulegen, oder es kann behoben werden, indem ein symbolischer Link zur `libpython` Bibliotheksdatei am Standardort für gemeinsame Bibliotheken im System erstellt wird. Typischerweise hat die Datei der `libpython` gemeinsamen Bibliothek den Dateinamen `libpythonX.Ym.so.1.0` für Python 3.5-3.7 oder `libpythonX.Y.so.1.0` für Python 3.8 oder höher (zum Beispiel: libpython3.7m.so.1.0, libpython3.9.so.1.0).