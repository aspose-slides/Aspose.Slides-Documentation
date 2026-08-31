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
description: "Aprenda a instalar rápidamente Aspose.Slides para .NET. Guía paso a paso, requisitos del sistema y ejemplos de código — ¡empiece a trabajar con presentaciones de PowerPoint hoy!"
---
## **Descripción general**

Este artículo explica cómo instalar Aspose.Slides para .NET en Windows, Linux y macOS. Se centra en la instalación basada en NuGet y muestra cómo añadir la biblioteca mediante el Administrador de paquetes NuGet o la Consola del Administrador de paquetes en Windows, a un proyecto .NET en Linux y a un proyecto Visual Studio en macOS. También describe cómo actualizar el paquete e instalar versiones preliminares cuando sea necesario.

Antes de la instalación, revise los sistemas operativos compatibles, las implementaciones de .NET y las dependencias adicionales en [Requisitos del sistema](/slides/es/net/system-requirements/).

## **Windows**
NuGet ofrece la vía más sencilla para descargar e instalar las APIs de Aspose para .NET en PCs. 

### **Método 1: Instalar o actualizar Aspose.Slides desde el Administrador de paquetes NuGet**

1. Abra Microsoft Visual Studio. 
2. Cree una aplicación de consola sencilla o abra un proyecto existente. 
3. Vaya a **Tools** > **NuGet package manager**.
4. En **Browse**, busque *Aspose Slides* en el campo de texto. 
{{% image img="installation_1.png" alt="Aspose.Slides Installation from NuGet Package Manager - 1" %}}
5. Haga clic en **Aspose.Slides.NET** y luego en **Install**. 
   * Si desea actualizar Aspose.Slides—suponiendo que ya lo haya instalado—haga clic en **Update** en su lugar. 

La API seleccionada se descarga y se referencia en su proyecto.

### **Método 2: Instalar o actualizar Aspose.Slides mediante la Consola del Administrador de paquetes**

Así es como se referencia la [API de Aspose.Slides](https://www.nuget.org/packages/Aspose.Slides.NET/) mediante la consola del Administrador de paquetes:

1. Abra Microsoft Visual Studio. 
2. Cree una aplicación de consola sencilla o abra un proyecto existente. 
3. Vaya a **Tools** > **Library Package Manager** > **Package Manager Console**. 
![todo:image_alt_text](installation_2.png)
4. Ejecute este comando: `Install-Package Aspose.Slides.NET` 
![todo:image_alt_text](installation_3.png)
La última versión completa se instala en su aplicación. 

* Alternativamente, puede añadir el sufijo `-prerelease` al comando para especificar que también se debe instalar la última versión (incluidos los hotfixes).

El consejo **Installing Aspose.Slides.NET** aparece cerca de la parte inferior de la ventana. 
![todo:image_alt_text](installation_4.png)

Una vez completada la descarga, debería ver algunos mensajes de confirmación. 

Si no está familiarizado con la [EULA de Aspose](https://about.aspose.com/legal/eula), quizá desee leer la licencia referenciada en la URL. 
![todo:image_alt_text](installation_5.png)

En su aplicación, debería ver que Aspose.Slides se ha añadido y referenciado correctamente. 
![todo:image_alt_text](installation_6.png)

En la Consola del Administrador de paquetes, puede ejecutar el comando `Update-Package Aspose.Slides.NET` para comprobar actualizaciones del paquete Aspose.Slides. Las actualizaciones (si se encuentran) se instalan automáticamente. También puede usar el sufijo `-prerelease` para actualizar la última versión.
#### **Consideraciones al ejecutar en un entorno de servidor compartido**
Recomendamos encarecidamente ejecutar todos los componentes Aspose .NET con el conjunto de permisos **Full Trust**, ya que a veces los componentes Aspose necesitan acceder a la configuración del registro y a archivos ubicados en lugares distintos al directorio virtual, por ejemplo, cuando los componentes Aspose deben leer fuentes. 

Además, los componentes Aspose.NET se basan en las clases centrales del sistema .NET, y algunas de esas clases también requieren permiso **Full Trust** para determinadas operaciones. 

Los proveedores de servicios de Internet, que albergan múltiples aplicaciones de diferentes compañías, suelen aplicar el nivel de seguridad Medium Trust. En el caso de .NET 2.0, dicho nivel de seguridad puede generar restricciones que afecten a las operaciones de Aspose.Slides:

- **RegistryPermission** no está disponible. Esto significa que no puede acceder al registro, lo cual es necesario para enumerar fuentes instaladas al renderizar documentos.
- **FileIOPermission** está restringido. Esto significa que sólo puede acceder a archivos en la jerarquía del directorio virtual de su aplicación. También podría significar que las fuentes no pueden leerse durante operaciones de exportación. 

Por las razones anteriores, recomendamos encarecidamente ejecutar Aspose.Slides con permisos **Full Trust**. Si utiliza **Medium trust**, podría experimentar inconsistencias: algunas funciones de la biblioteca (por ejemplo, renderizado) podrían no funcionar al realizar ciertas tareas. 

## **Linux**

NuGet ofrece la vía más sencilla para descargar e instalar Aspose.Slides para .NET en Linux. Añada el paquete [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) a su proyecto .NET.

## **macOS**

NuGet ofrece la vía más sencilla para descargar e instalar Aspose.Slides para .NET en Mac.

### **Instalar Aspose.Slides**

1. Abra Visual Studio. 
2. Cree una aplicación de consola sencilla o abra un proyecto existente.
3. Vaya a **Project** > **Manage NuGet Packages...**
   ![path-to-nuget-macos](path-to-nuget-macos.png)
4. Escriba *Aspose.Slides* en el campo de texto. 
5. Haga clic en **Aspose.Slides for .NET** y luego en **Add Package.** 
6. Añada un fragmento de código sencillo.
   * Puede copiar el código en [esta página](/slides/es/net/create-presentation/).
7. Ejecute la aplicación.
8. Abra *folder/bin/Debug/presentation_file_name* de su proyecto.

## **FAQ**

**¿Existe una versión gratuita o limitaciones en la prueba?**

Sí, por defecto, Aspose.Slides se ejecuta en modo de evaluación, lo que añade marcas de agua y puede tener otras limitaciones. Para eliminar las restricciones, debe aplicar una [licencia](/slides/es/net/licensing/).