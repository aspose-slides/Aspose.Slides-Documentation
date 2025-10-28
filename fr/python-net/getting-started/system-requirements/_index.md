---
title: Exigences système
type: docs
weight: 60
url: /fr/python-net/system-requirements/
keywords:
- exigences système
- système d'exploitation
- installation
- dépendances
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Découvrez les exigences système d'Aspose.Slides pour Python via .NET. Assurez une prise en charge transparente de PowerPoint et d'OpenDocument sous Windows, Linux et macOS."
---

## **Introduction**

Aspose.Slides for Python via .NET ne nécessite aucun produit tiers, tel que Microsoft PowerPoint, installé. Aspose.Slides est un moteur permettant de créer, modifier, convertir et rendre des documents dans divers formats, y compris les formats de présentation Microsoft PowerPoint.

## **Systèmes d'exploitation pris en charge**

Aspose.Slides pour Python prend en charge Windows (32 bits et 64 bits), macOS et Linux 64 bits sur des systèmes où Python 3.5 ou ultérieur est installé.

<table>  
    <tr>
        <td style="font-weight: bold; width:400px">Système d'exploitation</td>
        <td style="font-weight: bold; width:400px">Versions</td>
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
                <li>et autres</li>
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

## **Exigences système pour les plateformes Linux et macOS cibles**

- Bibliothèques d'exécution GCC 6 (ou ultérieures).
- [libgdiplus](https://github.com/mono/libgdiplus), une implémentation open source de l'API GDI+.
- Dépendances du .NET Core Runtime. L'installation du .NET Core Runtime lui‑même N'EST PAS requise.
- Pour Python 3.5–3.7 : la version `pymalloc` de Python est requise. L'option de compilation `--with-pymalloc` est activée par défaut. En général, la version `pymalloc` de Python est indiquée par le suffixe `m` dans le nom de fichier.
- La bibliothèque partagée `libpython`. L'option de compilation Python `--enable-shared` est désactivée par défaut, et certaines distributions Python n'incluent pas la bibliothèque partagée `libpython`. Sur certaines plateformes Linux, vous pouvez installer la bibliothèque partagée `libpython` à l'aide du gestionnaire de paquets (par exemple, `sudo apt-get install libpython3.7`). Un problème fréquent est que la bibliothèque `libpython` est installée dans un emplacement non standard pour les bibliothèques partagées. Vous pouvez résoudre cela en utilisant les options de compilation de Python pour définir des chemins de bibliothèque alternatifs lors de la compilation de Python, ou en créant un lien symbolique vers le fichier de bibliothèque `libpython` dans l'emplacement standard des bibliothèques partagées du système. En général, le nom de fichier de la bibliothèque partagée `libpython` est `libpythonX.Ym.so.1.0` pour Python 3.5–3.7 ou `libpythonX.Y.so.1.0` pour Python 3.8 ou ultérieur (par exemple, `libpython3.7m.so.1.0`, `libpython3.9.so.1.0`).

## **FAQ**

**Dois‑je installer Microsoft PowerPoint pour les conversions et le rendu ?**

Non, PowerPoint n'est pas requis ; Aspose.Slides est un moteur autonome pour [créer](/slides/fr/python-net/create-presentation/), modifier, [convertir](/slides/fr/python-net/convert-presentation/), et [rendre](/slides/fr/python-net/convert-powerpoint-to-png/) les présentations.

**Une version spécifique de .NET (Core/5+/6+) est‑elle requise sur la machine ?**

L'installation du Runtime .NET lui‑même n'est pas requise, mais ses dépendances doivent être présentes sous Linux/macOS. Cela signifie que le système doit contenir les paquets généralement installés en tant que dépendances de .NET, sans installer le runtime complet.

**Quelles polices sont nécessaires pour un rendu correct ?**

En pratique, les polices utilisées dans la présentation ou les [substituts](/slides/fr/python-net/font-substitution/) appropriés doivent être disponibles. Pour garantir un rendu cohérent sous Linux/macOS, il est conseillé d'installer des paquets de polices courantes.