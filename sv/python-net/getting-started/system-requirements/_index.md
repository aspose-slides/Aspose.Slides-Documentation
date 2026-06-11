---
title: Systemkrav
type: docs
weight: 60
url: /sv/python-net/system-requirements/
keywords:
- systemkrav
- operativsystem
- installation
- beroenden
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Upptäck systemkraven för Aspose.Slides för Python via .NET. Säkerställ sömlöst stöd för PowerPoint och OpenDocument på Windows, Linux och macOS."
---
## **Introduktion**

Aspose.Slides för Python via .NET kräver inte att några tredjepartsprodukter, såsom Microsoft PowerPoint, är installerade. Aspose.Slides är en motor för att skapa, modifiera, konvertera och rendera dokument i olika format, inklusive Microsoft PowerPoint-presentationformat.

## **Stödda operativsystem**

Aspose.Slides för Python stöder Windows (32‑bit och 64‑bit), macOS och 64‑bit Linux på system med Python 3.5 eller senare installerat.

<table>  
    <tr>
        <td style="font-weight: bold; width:400px">Operativsystem</td>
        <td style="font-weight: bold; width:400px">Versioner</td>
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
                <li>och andra</li>
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

## **Systemkrav för mål‑Linux‑och macOS‑plattformar**

- GCC 6‑körningsbibliotek (eller senare).
- [libgdiplus](https://github.com/mono/libgdiplus), en öppen källkodsimplementation av GDI+-API:et.
- Beroenden för .NET Core Runtime. Att installera .NET Core Runtime själv är INTE obligatoriskt.
- För Python 3.5–3.7: `pymalloc`‑byggnaden av Python krävs. Byggalternativet `--with-pymalloc` är aktiverat som standard. Vanligtvis markeras `pymalloc`‑byggnaden av Python med ett `m`‑suffix i filnamnet.
- Den delade `libpython`‑biblioteket. Byggalternativet `--enable-shared` för Python är inaktiverat som standard, och vissa Python‑distributioner inkluderar inte det delade `libpython`‑biblioteket. På vissa Linux‑plattformar kan du installera det delade `libpython`‑biblioteket via pakethanteraren (till exempel `sudo apt-get install libpython3.7`). Ett vanligt problem är att `libpython`‑biblioteket installeras på en icke‑standardplats för delade bibliotek. Du kan lösa detta genom att använda Python‑byggalternativ för att ange alternativa biblioteksökvägar vid kompilation av Python, eller genom att skapa en symbolisk länk till `libpython`‑biblioksfilen i systemets standardplats för delade bibliotek. Vanligtvis är filnamnet på det delade `libpython`‑biblioteket `libpythonX.Ym.so.1.0` för Python 3.5–3.7 eller `libpythonX.Y.so.1.0` för Python 3.8 eller senare (till exempel `libpython3.7m.so.1.0`, `libpython3.9.so.1.0`).

## **Vanliga frågor**

**Behöver jag Microsoft PowerPoint installerat för konverteringar och rendering?**

Nej, PowerPoint krävs inte; Aspose.Slides är en fristående motor för [skapa](/slides/sv/python-net/create-presentation/), modifiera, [konvertera](/slides/sv/python-net/convert-presentation/) och [rendera](/slides/sv/python-net/convert-powerpoint-to-png/) presentationer.

**Krävs en specifik .NET‑version (Core/5+/6+) på maskinen?**

Att installera .NET‑runtime själv är inte nödvändigt, men dess beroenden måste finnas på Linux/macOS. Det innebär att systemet bör innehålla de paket som vanligtvis installeras som .NET‑beroenden, utan att installera hela runtime‑miljön.

**Vilka teckensnitt behövs för korrekt rendering?**

I praktiken måste de teckensnitt som används i presentationen eller lämpliga [ersättningar](/slides/sv/python-net/font-substitution/) finnas tillgängliga. För att säkerställa konsekvent rendering på Linux/macOS är det rekommenderat att installera vanliga teckensnittspaket.

**Varför renderas ett eget teckensnitt som reserv eller saknad text på Linux?**

Om teckensnittsfilen har inkonsekventa eller korrupta namn‑tabellsposter kan Linux‑teckensnittsmatchningsstacken (FreeType/fontconfig) välja en ogiltig post, vilket gör att teckensnittet blir olösligt. Att använda en teckensnittsversion med korrigerade namn‑tabellsposter eller installera en konsekvent ersättning löser problemet.