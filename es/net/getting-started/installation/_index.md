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
description: "Instale Aspose.Slides para .NET desde NuGet en Windows, Linux y macOS: elija entre los dos paquetes, añada uno con la CLI de .NET o Visual Studio, e instale los prerrequisitos de Linux."
---
## **Visión general**

Este artículo explica cómo añadir Aspose.Slides para .NET a un proyecto en Windows, Linux y macOS. Aspose.Slides se distribuye a través de NuGet. Puedes añadirlo con la CLI de .NET en cualquier sistema operativo, o con el Administrador de paquetes NuGet o la Consola del Administrador de paquetes en Visual Studio en Windows. El artículo también explica cuál de los dos paquetes NuGet elegir y qué necesita Linux adicionalmente.

Antes de la instalación, revisa los sistemas operativos compatibles, implementaciones de .NET y dependencias adicionales en [Requisitos del sistema](/slides/es/net/system-requirements/).

## **Elija un paquete**

Aspose.Slides for .NET se publica como dos paquetes NuGet. Ambos proporcionan los mismos espacios de nombres y clases de Aspose.Slides, por lo que su código no cambia al alternar entre ellos; solo difieren la referencia del paquete y los requisitos de plataforma.

| Paquete | Uso | Requisitos adicionales |
|---|---|---|
| [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) | Windows y aplicaciones .NET Framework | En Linux y macOS: la biblioteca `libgdiplus` y el interruptor `System.Drawing.EnableUnixSupport` habilitado al iniciar la aplicación |
| [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) | .NET 6 o posterior en Windows, Linux y macOS | En Linux: la biblioteca `fontconfig`, si aún no está instalada |

Si no estás seguro, usa Aspose.Slides.NET en Windows y Aspose.Slides.NET6.CrossPlatform en Linux y macOS. En Alpine Linux, y en sistemas Linux cuya glibc sea anterior a 2.23 (x64) o 2.39 (ARM64), usa Aspose.Slides.NET en su lugar. [Requisitos del sistema](/slides/es/net/system-requirements/) enumera las plataformas compatibles de cada paquete.

## **Instalar con la CLI de .NET**

Estos pasos funcionan en Windows, Linux y macOS con el .NET SDK 6 o posterior. Crea una aplicación de consola:

```bash
dotnet new console -n HelloSlides
cd HelloSlides
```

Luego agrega el paquete para tu plataforma. Añade solo uno de los dos paquetes a un proyecto.

- En Windows: `dotnet add package Aspose.Slides.NET`
- En Linux y macOS: `dotnet add package Aspose.Slides.NET6.CrossPlatform` (en Linux, instala primero su prerequisito; consulta [Linux](#linux))

Para comprobar que el paquete funciona, reemplaza el contenido de *Program.cs* con el primer ejemplo en [Create Presentations](/slides/es/net/create-presentation/) y ejecuta `dotnet run`. Guarda *hello.pptx* en la carpeta del proyecto.

## **Windows**

### **Método 1: Instalar o actualizar Aspose.Slides desde el Administrador de paquetes NuGet**

1. Abra Microsoft Visual Studio.
2. Cree una aplicación de consola o abra un proyecto existente.
3. En **Solution Explorer**, haga clic con el botón derecho del ratón sobre el proyecto y seleccione **Manage NuGet Packages** (o vaya a **Project** > **Manage NuGet Packages**).
4. Bajo **Browse**, busque *Aspose.Slides*.
{{% image img="installation_1.png" alt="Aspose.Slides Installation from NuGet Package Manager - 1" %}}
5. Haga clic en **Aspose.Slides.NET** y luego haga clic en **Install**.
   * Si ya instaló Aspose.Slides y desea actualizarlo, haga clic en **Update** en su lugar.

El paquete se descarga y se referencia en su proyecto.

### **Método 2: Instalar o actualizar Aspose.Slides a través de la Consola del Administrador de paquetes**

Así es como se referencia el [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) mediante la Consola del Administrador de paquetes:

1. Abra Microsoft Visual Studio.
2. Cree una aplicación de consola o abra un proyecto existente.
3. Vaya a **Tools** > **NuGet Package Manager** > **Package Manager Console**.
![Abriendo la Consola del Administrador de paquetes](installation_2.png)
4. Ejecute este comando: `Install-Package Aspose.Slides.NET`
![Ejecutando el comando Install-Package](installation_3.png)
Se instala la última versión en su proyecto.

El mensaje **Installing Aspose.Slides.NET** aparece cerca de la parte inferior de la ventana.
![Progreso de instalación en la Consola del Administrador de paquetes](installation_4.png)

Cuando la descarga se completa, aparecen mensajes de confirmación. El paquete se distribuye bajo la [Aspose EULA](https://about.aspose.com/legal/eula).
![Mensajes de confirmación de la instalación](installation_5.png)

Aspose.Slides ahora está añadido a su proyecto y referenciado.
![Aspose.Slides referenciado en el proyecto](installation_6.png)

Para actualizar el paquete, ejecute `Update-Package Aspose.Slides.NET` en la Consola del Administrador de paquetes.

## **Linux**

Utilice los pasos de la CLI de .NET anteriores. Elija el paquete e instale su prerequisito con el gestor de paquetes de su distribución. En Debian y Ubuntu:

- **Aspose.Slides.NET6.CrossPlatform**: instale `fontconfig`.

  ```bash
  sudo apt-get update && sudo apt-get install -y libfontconfig1
  dotnet add package Aspose.Slides.NET6.CrossPlatform
  ```

- **Aspose.Slides.NET**: instale `libgdiplus` y habilite el soporte Unix para System.Drawing antes de que su aplicación use Aspose.Slides.

  ```bash
  sudo apt-get update && sudo apt-get install -y libgdiplus
  dotnet add package Aspose.Slides.NET
  ```

  Añada esta instrucción al inicio de su aplicación, antes de cualquier llamada a Aspose.Slides. En un *Program.cs* con declaraciones de nivel superior, colóquela después de las directivas `using`:

  ```c#
  System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
  ```

  Use este paquete en Alpine Linux y en sistemas cuya glibc sea demasiado antigua para Aspose.Slides.NET6.CrossPlatform.

Las fuentes utilizadas en sus presentaciones, o sustitutos adecuados, deben estar instaladas en el sistema para que el texto se renderice correctamente. [Requisitos del sistema](/slides/es/net/system-requirements/) describe los paquetes que Aspose.Slides.NET necesita en Alpine Linux, incluidas las fuentes.

## **macOS**

Utilice los pasos de la CLI de .NET anteriores con el paquete **Aspose.Slides.NET6.CrossPlatform**, que admite tanto Macs Intel (x86_64) como Apple silicon (ARM64):

```bash
dotnet add package Aspose.Slides.NET6.CrossPlatform
```

## **FAQ**

**¿Existe una versión gratuita o limitación de prueba?**

Sí. Sin una licencia, Aspose.Slides se ejecuta en modo de evaluación: añade una marca de agua de evaluación a cada diapositiva que guarda y trunca el texto leído de las presentaciones. Para eliminar estas limitaciones, aplique una [licencia](/slides/es/net/licensing/).