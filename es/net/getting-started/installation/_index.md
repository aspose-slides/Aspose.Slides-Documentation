---
title: Instalación
type: docs
weight: 70
url: /es/net/installation/
keywords:
- instalar Aspose.Slides
- descargar Aspose.Slides
- usar Aspose.Slides
- instalación de Aspose.Slides
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Aprenda cómo instalar rápidamente Aspose.Slides para .NET. Guía paso a paso, requisitos del sistema y ejemplos de código — comience a trabajar con presentaciones de PowerPoint hoy mismo!"
---

## **Windows**
NuGet ofrece la forma más sencilla de descargar e instalar las API de Aspose para .NET en PC. 

### **Method 1: Install or Update Aspose.Slides from the NuGet Package Manager**

1. Abra Microsoft Visual Studio. 
2. Cree una aplicación de consola simple o abra un proyecto existente. 
3. Vaya a **Tools** > **NuGet package manager**.
4. En **Browse**, busque *Aspose Slides* en el campo de texto. 
{{% image img="installation_1.png" alt="Aspose.Slides Installation from NuGet Package Manager - 1" %}}
5. Haga clic en **Aspose.Slides.NET** y luego en **Install**. 
   * Si desea actualizar Aspose.Slides —asumiendo que ya lo instaló— haga clic en **Update**. 

La API seleccionada se descarga y se referencia en su proyecto.

### **Method 2: Install or Update Aspose.Slides Through the Package Manager Console**

Así es como se hace referencia a la [Aspose.Slides API](https://www.nuget.org/packages/Aspose.Slides.NET/) mediante la consola del Administrador de paquetes:

1. Abra Microsoft Visual Studio. 
2. Cree una aplicación de consola simple o abra un proyecto existente. 
3. Vaya a **Tools** > **Library Package Manager** > **Package Manager Console**. 
![todo:image_alt_text](installation_2.png)
4. Ejecute este comando: `Install-Package Aspose.Slides.NET` 
![todo:image_alt_text](installation_3.png)
La última versión completa se instala en su aplicación. 

* Alternativamente, puede añadir el sufijo `-prerelease` al comando para especificar que también se debe instalar la última versión (incluidos los hotfixes). 

El consejo **Installing Aspose.Slides.NET** aparece alrededor de la parte inferior de la ventana. 
![todo:image_alt_text](installation_4.png)

Una vez que la descarga se complete, debería ver algunos mensajes de confirmación. 

Si no está familiarizado con la [Aspose EULA](https://about.aspose.com/legal/eula), es posible que desee leer la licencia referenciada en la URL. 
![todo:image_alt_text](installation_5.png)

En su aplicación, debería ver que Aspose.Slides se ha añadido y referenciado correctamente. 
![todo:image_alt_text](installation_6.png)

En la consola del Administrador de paquetes, puede ejecutar el comando `Update-Package Aspose.Slides.NET` para buscar actualizaciones del paquete Aspose.Slides. Las actualizaciones (si se encuentran) se instalan automáticamente. También puede usar el sufijo `-prerelease` para actualizar a la última versión.
#### **Considerations When Running on a Shared Server Environment**
Recomendamos encarecidamente ejecutar todos los componentes Aspose .NET con el conjunto de permisos **Full Trust**, ya que a veces los componentes Aspose necesitan acceder a configuraciones del registro y archivos ubicados en lugares diferentes al directorio virtual, por ejemplo, cuando los componentes Aspose deben leer fuentes. 

Además, los componentes Aspose.NET se basan en las clases del sistema central de .NET, y algunas de esas clases también requieren permiso **Full Trust** para ciertas operaciones. 

Los proveedores de servicios de Internet, que alojan múltiples aplicaciones de diferentes compañías, suelen aplicar el nivel de seguridad Medium Trust. En el caso de .NET 2.0, dicho nivel de seguridad puede generar restricciones que afectan las operaciones de Aspose.Slides:

- **RegistryPermission** no está disponible. Esto significa que no puede acceder al registro, lo cual es necesario para enumerar las fuentes instaladas al renderizar documentos.
- **FileIOPermission** está restringido. Esto significa que solo puede acceder a archivos en la jerarquía del directorio virtual de su aplicación. También puede implicar que las fuentes no se puedan leer durante operaciones de exportación. 

Por las razones anteriores, recomendamos encarecidamente ejecutar Aspose.Slides con permisos **Full Trust**. Si usa **Medium trust**, podría experimentar inconsistencias: algunas funciones de la biblioteca (por ejemplo, renderizado) pueden no funcionar al realizar ciertas tareas. 

## **macOS**

NuGet ofrece la forma más sencilla de descargar e instalar Aspose.Slides para .NET en Macs. 

**Install Prerequisite**

El espacio de nombres `System.Drawing` funciona de manera diferente en macOS, por lo que debe instalar mono-libgdiplus. 

> In .NET 5 and previous versions, the [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/) NuGet package works on Windows, Linux, and macOS. However, there are some platform differences. On Linux and macOS, the GDI+ functionality is implemented by the [libgdiplus)](https://www.mono-project.com/docs/gui/libgdiplus/) library. This library is not installed by default in most Linux distributions and doesn't support all the functionality of GDI+ on Windows and macOS. There are also platforms where libgdiplus is not available at all. To use types from the System.Drawing.Common package on Linux and macOS, you must install libgdiplus separately. For more information, see [Install .NET on Linux](https://docs.microsoft.com/en-us/dotnet/core/install/linux) or [Install .NET on macOS](https://docs.microsoft.com/en-us/dotnet/core/install/macos#libgdiplus).s

Para instalar mono-libgdiplus por separado en su Mac, consulte [este artículo](https://docs.microsoft.com/en-us/dotnet/core/install/macos#libgdiplus) de la documentación de .NET. 

### **Install Aspose.Slides**

1. Abra Visual Studio. 
2. Cree una aplicación de consola simple o abra un proyecto existente.
3. Vaya a **Project** > **Manage NuGet Packages...**
   ![path-to-nuget-macos](path-to-nuget-macos.png)
4. Escriba *Aspose.Slides* en el campo de texto. 
5. Haga clic en **Aspose.Slides for .NET** y luego en **Add Package.** 
6. Añada un fragmento de código simple.
   * Puede copiar el código en [esta página](/slides/es/net/create-presentation/).
7. Ejecute la aplicación.
8. Abra *folder/bin/Debug/presentation_file_name* de su proyecto.

## **FAQ**

**¿Existe una versión gratuita o limitación de prueba?**

Sí, por defecto, Aspose.Slides se ejecuta en modo de evaluación, lo que coloca marcas de agua y puede tener otras limitaciones. Para eliminar restricciones, debe aplicar una [licencia](/slides/es/net/licensing/) válida.