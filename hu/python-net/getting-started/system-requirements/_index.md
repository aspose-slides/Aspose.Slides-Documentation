---
title: Rendszerkövetelmények
type: docs
weight: 60
url: /hu/python-net/system-requirements/
keywords:
- rendszerkövetelmények
- operációs rendszer
- telepítés
- függőségek
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for Python via .NET rendszerkövetelményeit. Biztosítsa a zökkenőmentes PowerPoint és OpenDocument támogatást Windows, Linux és macOS rendszereken."
---
## **Bevezetés**

Az Aspose.Slides for Python via .NET nem igényel semmilyen harmadik fél termékét, például a Microsoft PowerPointot, a telepítéshez. Az Aspose.Slides egy motor a dokumentumok létrehozásához, módosításához, átalakításához és rendereléséhez különböző formátumokban, beleértve a Microsoft PowerPoint prezentációs formátumokat.

## **Támogatott operációs rendszerek**

Az Aspose.Slides for Python támogatja a Windows (32-bit és 64-bit), macOS és 64-bit Linux rendszereket olyan rendszereken, ahol a Python 3.5 vagy újabb telepítve van.

<table>  
    <tr>
        <td style="font-weight: bold; width:400px">Operációs rendszer</td>
        <td style="font-weight: bold; width:400px">Verziók</td>
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
                <li>és egyebek</li>
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

## **Rendszerkövetelmények a cél Linux és macOS platformokhoz**

- GCC 6 futásidejű könyvtárak (vagy újabb).
- [libgdiplus](https://github.com/mono/libgdiplus), a GDI+ API nyílt forráskódú megvalósítása.
- A .NET Core Runtime függőségei. A .NET Core Runtime telepítése NEM szükséges.
- Python 3.5–3.7 esetén a `pymalloc` buildű Python szükséges. A `--with-pymalloc` build opció alapértelmezés szerint engedélyezett. Általában a `pymalloc` buildű Python fájlnévben az `m` utótag jelenik meg.
- A `libpython` megosztott könyvtár. A `--enable-shared` Python build opció alapértelmezés szerint le van tiltva, és egyes Python disztribúciók nem tartalmazzák a `libpython` megosztott könyvtárat. Néhány Linux platformon a csomagkezelővel telepítheti a `libpython` megosztott könyvtárat (például `sudo apt-get install libpython3.7`). Gyakori probléma, hogy a `libpython` könyvtár nem szabványos helyen van telepítve a megosztott könyvtárak számára. Ezt úgy oldhatja meg, hogy a Python fordítási beállításokkal alternatív könyvtárútvonalakat ad meg a Python fordításakor, vagy szimbolikus linket hoz létre a `libpython` könyvtárfájlra a rendszer szabványos megosztott könyvtárhelyén. Általában a `libpython` megosztott könyvtár fájlneve `libpythonX.Ym.so.1.0` Python 3.5–3.7 esetén, vagy `libpythonX.Y.so.1.0` Python 3.8 vagy újabb esetén (például `libpython3.7m.so.1.0`, `libpython3.9.so.1.0`).

## **GYIK**

**Szükségem van a Microsoft PowerPoint telepítésére a konvertáláshoz és rendereléshez?**

Nem, a PowerPoint nem szükséges; az Aspose.Slides egy önálló motor a prezentációk [létrehozásához](/slides/hu/python-net/create-presentation/), módosításához, [konvertálásához](/slides/hu/python-net/convert-presentation/) és [rendereléséhez](/slides/hu/python-net/convert-powerpoint-to-png/).

**Szükséges-e egy konkrét .NET verzió (Core/5+/6+) a gépen?**

A .NET Runtime telepítése nem szükséges, de annak függőségeinek jelen kell lenniük Linux/macOS rendszeren. Ez azt jelenti, hogy a rendszernek tartalmaznia kell azokat a csomagokat, amelyeket általában .NET függőségekként telepítenek, anélkül hogy a teljes runtime-ot telepítenék.

**Milyen betűtípusokra van szükség a helyes rendereléshez?**

Gyakorlatban a prezentációban használt betűtípusoknak vagy megfelelő [helyettesítők](/slides/hu/python-net/font-substitution/)nek elérhetőnek kell lenniük. A Linux/macOS rendszeren a konzisztens renderelés biztosítása érdekében ajánlott általános betűcsomagokat telepíteni.

**Miért jelenik meg egy egyedi betűtípus helyettesítőként vagy hiányzó szövegként Linuxon?**

Ha a betűtípus fájlban inkonzisztens vagy sérült névtábla-bejegyzések vannak, a Linux betűtípus-illesztő (FreeType/fontconfig) érvénytelen rekordot választhat, ami a betűtípus feloldásának hiányához vezet. Egy javított névtábla-bejegyzésekkel rendelkező betűtípus verzió használata vagy egy konzisztens helyettesítő telepítése megoldja a problémát.