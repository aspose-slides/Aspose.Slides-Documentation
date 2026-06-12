---
title: Systémové požadavky
type: docs
weight: 60
url: /cs/python-net/system-requirements/
keywords:
- systémové požadavky
- operační systém
- instalace
- závislosti
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Objevte systémové požadavky Aspose.Slides pro Python přes .NET. Zajistěte bezproblémovou podporu PowerPoint a OpenDocument na Windows, Linuxu a macOS."
---
## **Úvod**

Aspose.Slides pro Python přes .NET nevyžaduje instalaci žádných produktů třetích stran, jako je Microsoft PowerPoint. Aspose.Slides je motor pro vytváření, úpravu, konverzi a vykreslování dokumentů v různých formátech, včetně formátů prezentací Microsoft PowerPoint.

## **Podporované operační systémy**

Aspose.Slides pro Python podporuje Windows (32‑bitové i 64‑bitové), macOS a 64‑bitový Linux na systémech s nainstalovaným Pythonem 3.5 nebo novějším.

<table>  
    <tr>
        <td style="font-weight: bold; width:400px">Operační systém</td>
        <td style="font-weight: bold; width:400px">Verze</td>
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
                <li>a další</li>
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

## **Systémové požadavky pro cílové platformy Linux a macOS**

- Knihovny běhového prostředí GCC 6 (nebo novější).
- [libgdiplus](https://github.com/mono/libgdiplus) je open‑source implementace API GDI+.
- Závislosti .NET Core Runtime. Instalace samotného .NET Core Runtime NENÍ vyžadována.
- Pro Python 3.5–3.7: je požadována verze Pythonu s `pymalloc`. Přepínač sestavení `--with-pymalloc` je ve výchozím nastavení povolen. Obvykle je verze Pythonu s `pymalloc` označena příponou `m` v názvu souboru.
- `libpython` sdílená knihovna. Přepínač sestavení Pythonu `--enable-shared` je ve výchozím nastavení vypnutý a některé distribuce Pythonu neobsahují sdílenou knihovnu `libpython`. Na některých platformách Linux můžete sdílenou knihovnu `libpython` nainstalovat pomocí správce balíčků (například `sudo apt-get install libpython3.7`). Častým problémem je, že knihovna `libpython` je nainstalována na nestandardním místě pro sdílené knihovny. Toto můžete vyřešit použitím možností sestavení Pythonu k nastavení alternativních cest ke knihovnám při kompilaci Pythonu, nebo vytvořením symbolického odkazu na soubor knihovny `libpython` v standardním umístění sdílených knihoven systému. Obvykle má název souboru sdílené knihovny `libpython` podobu `libpythonX.Ym.so.1.0` pro Python 3.5–3.7 nebo `libpythonX.Y.so.1.0` pro Python 3.8 a novější (například `libpython3.7m.so.1.0`, `libpython3.9.so.1.0`).

## **Často kladené otázky**

**Potřebuji mít nainstalovaný Microsoft PowerPoint pro konverze a vykreslování?**

Ne, PowerPoint není vyžadován; Aspose.Slides je samostatný motor pro [vytváření](/slides/cs/python-net/create-presentation/), úpravu, [konvertování](/slides/cs/python-net/convert-presentation/) a [vykreslování](/slides/cs/python-net/convert-powerpoint-to-png/) prezentací.

**Je na stroji vyžadována konkrétní verze .NET (Core/5+/6+)?**

Instalace samotného .NET Runtime není vyžadována, ale její závislosti musí být přítomny na Linuxu/macOS. To znamená, že systém by měl obsahovat balíčky, které jsou obvykle instalovány jako závislosti .NET, aniž by se instaloval celý runtime.

**Jaká písma jsou potřebná pro správné vykreslování?**

V praxi musí být k dispozici písma použité v prezentaci nebo vhodné [náhrady](/slides/cs/python-net/font-substitution/). Pro zajištění konzistentního vykreslování na Linuxu/macOS se doporučuje nainstalovat běžné balíčky písem.

**Proč se vlastní písmo na Linuxu vykresluje jako náhradní nebo chybějící text?**

Pokud soubor písma obsahuje nekonzistentní nebo poškozené záznamy v tabulce názvů, může stack pro výběr písma na Linuxu (FreeType/fontconfig) vybrat neplatný záznam, což způsobí, že písmo nebude rozpoznáno. Použití verze písma s opravenými záznamy v tabulce názvů nebo instalace konzistentní náhrady problém vyřeší.