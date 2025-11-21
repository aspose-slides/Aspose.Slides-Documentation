---
title: Instalación
type: docs
weight: 70
url: /es/net/installation/
keywords: "Descargar Aspose.Slides, Instalar Aspose.Slides, Instalación de Aspose.Slides, Windows, macOS, .NET"
description: "Instalar Aspose.Slides para .NET en Windows o macOS"
---

## **Windows**
NuGet proporciona la manera más sencilla de descargar e instalar las APIs de Aspose para .NET en PCs. 

### **Método 1: Instalar o actualizar Aspose.Slides desde el Administrador de paquetes NuGet**

1. Abra Microsoft Visual Studio. 
2. Cree una aplicación de consola simple o abra un proyecto existente. 
3. Navegue a **Tools** > **NuGet package manager**.
4. En **Browse**, busque *Aspose Slides* en el campo de texto. 
{{% image img="installation_1.png" alt="Instalación de Aspose.Slides desde el Administrador de paquetes NuGet - 1" %}}
5. Haga clic en **Aspose.Slides.NET** y luego en **Install**. 
   * Si desea actualizar Aspose.Slides—asumiendo que ya lo instaló—haga clic en **Update** en su lugar. 

La API seleccionada se descarga y se referencia en su proyecto.

### **Método 2: Instalar o actualizar Aspose.Slides a través de la consola del Administrador de paquetes**

Así es como referencia la [Aspose.Slides API](https://www.nuget.org/packages/Aspose.Slides.NET/) mediante la consola del administrador de paquetes:

1. Abra Microsoft Visual Studio. 
2. Cree una aplicación de consola simple o abra un proyecto existente. 
3. Navegue a **Tools** > **Library Package Manager** > **Package Manager Console**. 
![todo:image_alt_text](installation_2.png)
4. Ejecute este comando: `Install-Package Aspose.Slides.NET` 
![todo:image_alt_text](installation_3.png)
La última versión completa se instala en su aplicación. 

* Alternativamente, puede añadir el sufijo `-prerelease` al comando para especificar que también se debe instalar la última versión (incluidos los hotfix). 

El consejo **Installing Aspose.Slides.NET** aparece cerca de la parte inferior de la ventana. 
![todo:image_alt_text](installation_4.png)

Una vez que la descarga se complete, debería ver algunos mensajes de confirmación. 

Si no está familiarizado con la [Aspose EULA](https://about.aspose.com/legal/eula), entonces quizá desee leer la licencia referenciada en la URL. 
![todo:image_alt_text](installation_5.png)

En su aplicación, debería ver que Aspose.Slides se ha añadido y referenciado correctamente. 
![todo:image_alt_text](installation_6.png)

En la Consola del Administrador de paquetes, puede ejecutar el comando `Update-Package Aspose.Slides.NET` para buscar actualizaciones del paquete Aspose.Slides. Las actualizaciones (si se encuentran) se instalan automáticamente. También puede usar el sufijo `-prerelease` para actualizar a la última versión.
#### **Consideraciones al ejecutar en un entorno de servidor compartido**
Recomendamos encarecidamente ejecutar todos los componentes Aspose .NET con el conjunto de permisos **Full Trust**, ya que los componentes Aspose a veces necesitan acceder a configuraciones del registro y a archivos ubicados en lugares diferentes al directorio virtual—por ejemplo, cuando los componentes Aspose deben leer fuentes. 

Además, los componentes Aspose.NET se basan en las clases centrales del sistema .NET, y algunas de esas clases también requieren el permiso **Full Trust** para ciertas operaciones. 

Los proveedores de servicios de Internet que alojan múltiples aplicaciones de diferentes compañías suelen aplicar el nivel de seguridad **Medium Trust**. En caso de .NET 2.0, dicho nivel de seguridad puede generar restricciones que afectan las operaciones de Aspose.Slides:

- **RegistryPermission** no está disponible. Esto significa que no puede acceder al registro, lo cual es necesario para enumerar las fuentes instaladas al renderizar documentos.
- **FileIOPermission** está restringido. Esto significa que sólo puede acceder a archivos dentro de la jerarquía del directorio virtual de su aplicación. También puede implicar que las fuentes no se puedan leer durante operaciones de exportación. 

Por las razones anteriores, recomendamos encarecidamente ejecutar Aspose.Slides con permisos **Full Trust**. Si usa **Medium trust**, podría experimentar inconsistencias—algunas funciones de la biblioteca (como el renderizado) podrían no funcionar al realizar ciertas tareas. 

## **macOS**

NuGet proporciona la manera más sencilla de descargar e instalar Aspose.Slides para .NET en Mac. 

**Instalar prerequisito**

El espacio de nombres `System.Drawing` funciona de manera diferente en macOS, por lo que debe instalar mono-libgdiplus. 

> En .NET 5 y versiones anteriores, el paquete NuGet [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/) funciona en Windows, Linux y macOS. Sin embargo, existen diferencias de plataforma. En Linux y macOS, la funcionalidad GDI+ es implementada por la biblioteca [libgdiplus](https://www.mono-project.com/docs/gui/libgdiplus/). Esta biblioteca no se instala por defecto en la mayoría de las distribuciones de Linux y no soporta toda la funcionalidad de GDI+ en Windows y macOS. Además, hay plataformas donde libgdiplus no está disponible en absoluto. Para usar tipos del paquete System.Drawing.Common en Linux y macOS, debe instalar libgdiplus por separado. Para más información, consulte [Install .NET on Linux](https://docs.microsoft.com/en-us/dotnet/core/install/linux) o [Install .NET on macOS](https://docs.microsoft.com/en-us/dotnet/core/install/macos#libgdiplus).s

Para instalar mono-libgdiplus por separado en su Mac, consulte [this article](https://docs.microsoft.com/en-us/dotnet/core/install/macos#libgdiplus) de la documentación de .NET. 

### **Instalar Aspose.Slides**

1. Abra Visual Studio. 
2. Cree una aplicación de consola simple o abra un proyecto existente.
3. Navegue a **Project** > **Manage NuGet Packages...**
   ![path-to-nuget-macos](path-to-nuget-macos.png)
4. Escriba *Aspose.Slides* en el campo de texto. 
5. Haga clic en **Aspose.Slides for .NET** y luego en **Add Package**. 
6. Añada un fragmento de código simple.
   * Puede copiar el código en [this page](/slides/es/net/create-presentation/).
7. Ejecute la aplicación.
8. Abra la *folder/bin/Debug/presentation_file_name* de su proyecto.

## **FAQ**

**¿Existe una versión gratuita o limitación de prueba?**

Sí, por defecto, Aspose.Slides se ejecuta en modo de evaluación, lo que coloca marcas de agua y puede tener otras limitaciones. Para eliminar las restricciones, necesita aplicar una [license](/slides/es/net/licensing/) válida.