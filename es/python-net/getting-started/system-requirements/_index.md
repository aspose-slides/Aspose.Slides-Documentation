---
title: Requisitos del Sistema
type: docs
weight: 60
url: /es/python-net/system-requirements/
---
Aspose.Slides para Python a través de .NET no requiere la instalación de ningún producto de terceros como Microsoft PowerPoint. Aspose.Slides en sí mismo es un motor para crear, modificar, convertir y renderizar documentos en varios formatos, incluidos los formatos de presentación de Microsoft PowerPoint.

## Sistemas Operativos Soportados

Aspose.Slides para Python a través de .NET es compatible con sistemas operativos Windows de 64 bits y 32 bits, macOS y Linux de 64 bits donde Python 3.5 o posterior está instalado.

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

## Requisitos del Sistema para Plataformas Linux y macOS Objetivo

- Bibliotecas de tiempo de ejecución GCC-6 (o posteriores).
- [`libgdiplus`](https://github.com/mono/libgdiplus): una implementación de código abierto de la API GDI+.
- Dependencias de .NET Core Runtime. No se requiere la instalación de .NET Core Runtime en sí.
- Para Python 3.5-3.7: Se necesita la construcción de Python `pymalloc`. La opción de construcción de Python `--with-pymalloc` está habilitada por defecto. Típicamente, la construcción `pymalloc` de Python está marcada con el sufijo `m` en el nombre del archivo.
- Biblioteca compartida Python `libpython`. La opción de construcción de Python `--enable-shared` está deshabilitada por defecto, algunas distribuciones de Python no contienen la biblioteca compartida `libpython`. Para algunas plataformas de linux, la biblioteca compartida `libpython` se puede instalar utilizando el administrador de paquetes, por ejemplo: `sudo apt-get install libpython3.7`. El problema común es que la biblioteca `libpython` está instalada en una ubicación diferente de la ubicación estándar del sistema para bibliotecas compartidas. El problema se puede solucionar utilizando las opciones de construcción de Python para establecer rutas de biblioteca alternativas al compilar Python, o se puede solucionar creando un enlace simbólico al archivo de la biblioteca `libpython` en la ubicación estándar del sistema para bibliotecas compartidas. Típicamente, el nombre del archivo de la biblioteca compartida `libpython` es `libpythonX.Ym.so.1.0` para Python 3.5-3.7, o `libpythonX.Y.so.1.0` para Python 3.8 o posterior (por ejemplo: libpython3.7m.so.1.0, libpython3.9.so.1.0).  
