---
title: Exigences système
type: docs
weight: 60
url: /fr/python-net/system-requirements/
---
Aspose.Slides pour Python via .NET ne nécessite aucun produit tiers tel que Microsoft PowerPoint à installer. Aspose.Slides lui-même est un moteur pour créer, modifier, convertir et rendre des documents dans divers formats, y compris les formats de présentation Microsoft PowerPoint.

## Systèmes d'exploitation pris en charge

Aspose.Slides pour Python via .NET prend en charge les systèmes d'exploitation Windows 64 bits et 32 bits, macOS, Linux 64 bits où Python 3.5 ou ultérieur est installé.

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
                <li>et d'autres</li>
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

## Exigences système pour les plateformes cibles Linux et macOS

- Bibliothèques d'exécution GCC-6 (ou ultérieures).
- [`libgdiplus`](https://github.com/mono/libgdiplus) : une implémentation Open Source de l'API GDI+.
- Dépendances de l'exécution .NET Core. L'installation de .NET Core Runtime elle-même n'est PAS requise.
- Pour Python 3.5-3.7 : La version `pymalloc` de Python est nécessaire. L'option de construction Python `--with-pymalloc` est activée par défaut. En général, la version `pymalloc` de Python est marquée par le suffixe `m` dans le nom de fichier.
- Bibliothèque Python partagée `libpython`. L'option de construction Python `--enable-shared` est désactivée par défaut, certaines distributions Python ne contiennent pas la bibliothèque partagée `libpython`. Pour certaines plateformes Linux, la bibliothèque partagée `libpython` peut être installée à l'aide du gestionnaire de paquets, par exemple : `sudo apt-get install libpython3.7`. Le problème courant est que la bibliothèque `libpython` est installée dans un emplacement différent de l'emplacement standard du système pour les bibliothèques partagées. Le problème peut être résolu en utilisant les options de construction Python pour définir des chemins de bibliothèque alternatifs lors de la compilation de Python, ou résolu en créant un lien symbolique vers le fichier de bibliothèque `libpython` dans l'emplacement standard du système pour les bibliothèques partagées. En général, le nom de fichier de la bibliothèque partagée `libpython` est `libpythonX.Ym.so.1.0` pour Python 3.5-3.7, ou `libpythonX.Y.so.1.0` pour Python 3.8 ou ultérieures (par exemple : libpython3.7m.so.1.0, libpython3.9.so.1.0).  