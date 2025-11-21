---
title: Requisitos del sistema
type: docs
weight: 60
url: /es/python-net/system-requirements/
keywords:
- requisitos del sistema
- sistema operativo
- instalación
- dependencias
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Descubra los requisitos del sistema de Aspose.Slides for Python via .NET. Garantice soporte sin problemas de PowerPoint y OpenDocument en Windows, Linux y macOS."
---

## **Introducción**

Aspose.Slides for Python via .NET no requiere que se instalen productos de terceros, como Microsoft PowerPoint. Aspose.Slides es un motor para crear, modificar, convertir y renderizar documentos en varios formatos, incluidos los formatos de presentación de Microsoft PowerPoint.

## **Sistemas operativos compatibles**

Aspose.Slides for Python es compatible con Windows (32 bits y 64 bits), macOS y Linux de 64 bits en sistemas con Python 3.5 o posterior instalado.

<table>  
    <tr>
        <td style="font-weight: bold; width:400px">Sistema operativo</td>
        <td style="font-weight: bold; width:400px">Versiones</td>
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
                <li>and others</li>
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

## **Requisitos del sistema para plataformas Linux y macOS de destino**

- Bibliotecas de tiempo de ejecución GCC 6 (o posteriores).  
- [libgdiplus](https://github.com/mono/libgdiplus), una implementación de código abierto de la API GDI+.  
- Dependencias del .NET Core Runtime. Instalar el propio .NET Core Runtime NO es necesario.  
- Para Python 3.5–3.7: se requiere la compilación `pymalloc` de Python. La opción de compilación `--with-pymalloc` está habilitada por defecto. Normalmente, la compilación `pymalloc` de Python se marca con el sufijo `m` en el nombre del archivo.  
- La biblioteca compartida `libpython`. La opción de compilación de Python `--enable-shared` está deshabilitada por defecto, y algunas distribuciones de Python no incluyen la biblioteca compartida `libpython`. En algunas plataformas Linux, puedes instalar la biblioteca compartida `libpython` usando el gestor de paquetes (por ejemplo, `sudo apt-get install libpython3.7`). Un problema frecuente es que la biblioteca `libpython` se instala en una ubicación no estándar para bibliotecas compartidas. Puedes solucionarlo usando opciones de compilación de Python para establecer rutas alternativas de biblioteca al compilar Python, o creando un enlace simbólico al archivo de la biblioteca `libpython` en la ubicación estándar de bibliotecas compartidas del sistema. Normalmente, el nombre del archivo de la biblioteca compartida `libpython` es `libpythonX.Ym.so.1.0` para Python 3.5–3.7 o `libpythonX.Y.so.1.0` para Python 3.8 o posterior (por ejemplo, `libpython3.7m.so.1.0`, `libpython3.9.so.1.0`).

## **Preguntas frecuentes**

**¿Necesito Microsoft PowerPoint instalado para conversiones y renderizado?**

No, PowerPoint no es necesario; Aspose.Slides es un motor independiente para [crear](/slides/es/python-net/create-presentation/), modificar, [convertir](/slides/es/python-net/convert-presentation/), y [renderizar](/slides/es/python-net/convert-powerpoint-to-png/) presentaciones.

**¿Se requiere una versión específica de .NET (Core/5+/6+) en la máquina?**

Instalar el propio .NET Runtime no es necesario, pero sus dependencias deben estar presentes en Linux/macOS. Esto significa que el sistema debe contener los paquetes que normalmente se instalan como dependencias de .NET, sin instalar el runtime completo.

**¿Qué fuentes se necesitan para un renderizado correcto?**

En la práctica, las fuentes usadas en la presentación o los [sustitutos](/slides/es/python-net/font-substitution/) adecuados deben estar disponibles. Para garantizar un renderizado coherente en Linux/macOS, se recomienda instalar paquetes de fuentes comunes.