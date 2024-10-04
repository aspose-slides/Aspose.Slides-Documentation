---
title: Instalación
type: docs
weight: 70
url: /net/installation/
keywords: "Descargar Aspose.Slides, Instalar Aspose.Slides, Instalación de Aspose.Slides, Windows, macOS, .NET"
description: "Instalar Aspose.Slides para .NET en Windows o macOS"
---

## **Windows**
NuGet proporciona la forma más sencilla de descargar e instalar las API de Aspose para .NET en PCs.

### **Método 1: Instalar o actualizar Aspose.Slides desde el Administrador de paquetes NuGet**

1. Abre Microsoft Visual Studio.
2. Crea una aplicación de consola simple o abre un proyecto existente.
3. Ve a **Herramientas** > **Administrador de paquetes NuGet**.
4. En **Explorar**, busca *Aspose Slides* en el campo de texto.
{{% image img="installation_1.png" alt="Instalación de Aspose.Slides desde el Administrador de paquetes NuGet - 1" %}}
5. Haz clic en **Aspose.Slides.NET** y luego haz clic en **Instalar**.
   * Si deseas actualizar Aspose.Slides—suponiendo que ya lo hayas instalado—haz clic en **Actualizar** en su lugar.

La API seleccionada se descarga y se referencia en tu proyecto.

### **Método 2: Instalar o actualizar Aspose.Slides a través de la Consola del Administrador de paquetes**

Así es como se referencia [Aspose.Slides API](https://www.nuget.org/packages/Aspose.Slides.NET/) a través de la consola del administrador de paquetes:

1. Abre Microsoft Visual Studio.
2. Crea una aplicación de consola simple o abre un proyecto existente.
3. Ve a **Herramientas** > **Administrador de paquetes de la biblioteca** > **Consola del Administrador de paquetes**.
![todo:image_alt_text](installation_2.png)
4. Ejecuta este comando: `Install-Package Aspose.Slides.NET`
![todo:image_alt_text](installation_3.png)
La última versión completa se instalará en tu aplicación.

* Alternativamente, puedes agregar el sufijo `-prerelease` al comando para especificar que también se debe instalar la última versión (incluidos los parches).

El consejo **Instalando Aspose.Slides.NET** aparece alrededor de la parte inferior de la ventana.
![todo:image_alt_text](installation_4.png)

Una vez que la descarga se complete, deberías ver algunos mensajes de confirmación.

Si no estás familiarizado con [Aspose EULA](https://about.aspose.com/legal/eula), entonces puede que quieras leer la licencia referenciada en la URL.
![todo:image_alt_text](installation_5.png)

En tu aplicación, deberías ver que Aspose.Slides se ha añadido y referenciado correctamente.
![todo:image_alt_text](installation_6.png)

En la Consola del Administrador de paquetes, puedes ejecutar el comando `Update-Package Aspose.Slides.NET` para buscar actualizaciones del paquete Aspose.Slides. Las actualizaciones (si se encuentran) se instalan automáticamente. También puedes usar el sufijo `-prerelease` para actualizar la última versión.
#### **Consideraciones al ejecutar en un entorno de servidor compartido**
Recomendamos encarecidamente que ejecutes todos los componentes de Aspose .NET con el conjunto de permisos de **Full Trust** porque los componentes de Aspose a veces necesitan acceder a configuraciones del registro y archivos ubicados en lugares distintos al directorio virtual; por ejemplo, cuando los componentes de Aspose tienen que leer fuentes.

Además, los componentes de Aspose.NET se basan en las clases del sistema .NET y algunas de esas clases también requieren permisos de Full Trust para operaciones en ciertos casos.

Los Proveedores de Servicios de Internet, que alojan múltiples aplicaciones de diferentes empresas, en su mayoría exigen el nivel de seguridad Medium Trust. En el caso de .NET 2.0, tal nivel de seguridad puede resultar en restricciones que afectan las operaciones de Aspose.Slides:

- **RegistryPermission** no está disponible. Esto significa que no puedes acceder al registro, lo que se requiere para enumerar las fuentes instaladas al renderizar documentos.
- **FileIOPermission** está restringido. Esto significa que solo puedes acceder a archivos en la jerarquía del directorio virtual de tu aplicación. Esto también significa potencialmente que las fuentes no pueden leerse durante las operaciones de exportación.

Por las razones anteriores, recomendamos encarecidamente que ejecutes Aspose.Slides con permisos de **Full Trust**. Si usas **Medium Trust**, podrías experimentar inconsistencias; algunas funciones de la biblioteca (renderización, por ejemplo) podrían no funcionar al realizar ciertas tareas.

## **macOS**

NuGet proporciona la forma más sencilla de descargar e instalar Aspose.Slides para .NET en Macs.

**Instalar requisito previo**

El espacio de nombres `System.Drawing` funciona de manera diferente en macOS, por lo que debes instalar mono-libgdiplus.

> En .NET 5 y versiones anteriores, el paquete NuGet [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/) funciona en Windows, Linux y macOS. Sin embargo, hay algunas diferencias de plataforma. En Linux y macOS, la funcionalidad de GDI+ es implementada por la biblioteca [libgdiplus)](https://www.mono-project.com/docs/gui/libgdiplus/). Esta biblioteca no está instalada por defecto en la mayoría de las distribuciones de Linux y no soporta toda la funcionalidad de GDI+ en Windows y macOS. También hay plataformas donde libgdiplus no está disponible en absoluto. Para usar tipos del paquete System.Drawing.Common en Linux y macOS, debes instalar libgdiplus por separado. Para más información, consulta [Instalar .NET en Linux](https://docs.microsoft.com/en-us/dotnet/core/install/linux) o [Instalar .NET en macOS](https://docs.microsoft.com/en-us/dotnet/core/install/macos#libgdiplus).

Para instalar mono-libgdiplus por separado en tu Mac, revisa [este artículo](https://docs.microsoft.com/en-us/dotnet/core/install/macos#libgdiplus) de la documentación de .NET.

### **Instalar Aspose.Slides**

1. Abre Visual Studio.
2. Crea una aplicación de consola simple o abre un proyecto existente.
3. Ve a **Proyecto** > **Administrar paquetes NuGet...**
   ![path-to-nuget-macos](path-to-nuget-macos.png)
4. Escribe *Aspose.Slides* en el campo de texto.
5. Haz clic en **Aspose.Slides para .NET** y luego haz clic en **Agregar paquete.**
6. Añade un fragmento de código simple.
   * Puedes copiar el código en [esta página](/slides/net/create-presentation/).
7. Ejecuta la aplicación.
8. Abre la *carpeta/bin/Debug/nombre_archivo_presentación* de tu proyecto.