---
title: Requisitos del Sistema
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
description: "Descubra los requisitos del sistema de Aspose.Slides para Python a través de .NET. Garantice un soporte perfecto de PowerPoint y OpenDocument en Windows, Linux y macOS."
---

## **Introducción**

Aspose.Slides para Python a través de .NET no requiere que se instalen productos de terceros, como Microsoft PowerPoint. Aspose.Slides es un motor para crear, modificar, convertir y renderizar documentos en varios formatos, incluidos los formatos de presentación de Microsoft PowerPoint.

## **Sistemas Operativos Compatibles**

Aspose.Slides para Python es compatible con Windows (32 bits y 64 bits), macOS y Linux de 64 bits en sistemas con Python 3.5 o posterior instalado.

<table>  
    <tr>
        <td style="font-weight: bold; width:400px">Sistema Operativo</td>
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
                <li>y otros</li>
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

## **Requisitos del Sistema para Plataformas Linux y macOS de Destino**

- Bibliotecas en tiempo de ejecución GCC 6 (o posteriores).  
- [libgdiplus](https://github.com/mono/libgdiplus), una implementación de código abierto de la API GDI+.  
- Dependencias del .NET Core Runtime. La instalación del .NET Core Runtime en sí NO es necesaria.  
- Para Python 3.5–3.7: se requiere la compilación `pymalloc` de Python. La opción de compilación `--with-pymalloc` está habilitada por defecto. Normalmente, la compilación `pymalloc` de Python lleva un sufijo `m` en el nombre del archivo.  
- La biblioteca compartida `libpython`. La opción de compilación Python `--enable-shared` está deshabilitada por defecto, y algunas distribuciones de Python no incluyen la biblioteca compartida `libpython`. En algunas plataformas Linux, puede instalar la biblioteca compartida `libpython` mediante el gestor de paquetes (por ejemplo, `sudo apt-get install libpython3.7`). Un problema frecuente es que la biblioteca `libpython` se instala en una ubicación no estándar para bibliotecas compartidas. Puede resolverlo usando opciones de compilación de Python para establecer rutas de biblioteca alternativas al compilar Python, o creando un enlace simbólico al archivo de la biblioteca `libpython` en la ubicación estándar de bibliotecas compartidas del sistema. Normalmente, el nombre de archivo de la biblioteca compartida `libpython` es `libpythonX.Ym.so.1.0` para Python 3.5–3.7 o `libpythonX.Y.so.1.0` para Python 3.8 o posterior (por ejemplo, `libpython3.7m.so.1.0`, `libpython3.9.so.1.0`).

## **Preguntas frecuentes**

**¿Necesito que Microsoft PowerPoint esté instalado para conversiones y renderizado?**

No, PowerPoint no es necesario; Aspose.Slides es un motor independiente para [crear](/slides/es/python-net/create-presentation/), modificar, [convertir](/slides/es/python-net/convert-presentation/) y [renderizar](/slides/es/python-net/convert-powerpoint-to-png/) presentaciones.

**¿Se requiere una versión específica de .NET (Core/5+/6+) en la máquina?**

La instalación del .NET Runtime en sí no es requerida, pero sus dependencias deben estar presentes en Linux/macOS. Esto significa que el sistema debe contener los paquetes que normalmente se instalan como dependencias de .NET, sin instalar el runtime completo.

**¿Qué fuentes son necesarias para un renderizado correcto?**

En la práctica, las fuentes utilizadas en la presentación o los [sustitutos](/slides/es/python-net/font-substitution/) adecuados deben estar disponibles. Para garantizar un renderizado coherente en Linux/macOS, se recomienda instalar paquetes de fuentes comunes.