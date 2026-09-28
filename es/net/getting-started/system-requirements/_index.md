---
title: Requisitos del sistema
type: docs
weight: 60
url: /es/net/system-requirements/
keywords:
- requisitos del sistema
- plataformas compatibles
- frameworks de destino
- .NET Framework
- .NET Standard
- libgdiplus
- fontconfig
- Alpine
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Compruebe qué necesita Aspose.Slides para .NET antes de instalarlo: los frameworks a los que se dirige cada paquete NuGet, los sistemas operativos y procesadores compatibles, y las bibliotecas y fuentes que requiere Linux."
---
## **Introducción**

Aspose.Slides for .NET es una biblioteca independiente: no necesita Microsoft PowerPoint ni Microsoft Office. Se publica como dos paquetes NuGet, [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) y [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/). Ambos proporcionan los mismos espacios de nombres y clases de Aspose.Slides; difieren en los frameworks a los que se dirigen y en cómo dibujan las diapositivas, lo que determina dónde se ejecutan y qué necesitan.

Este artículo enumera las versiones .NET y plataformas que admite cada paquete, así como las bibliotecas del sistema y fuentes que Linux necesita, y termina con un pequeño programa que verifica su configuración. Para agregar un paquete a un proyecto, consulte [Instalación](/slides/es/net/installation/).

## **Versiones .NET compatibles**

Cada paquete contiene una compilación de Aspose.Slides por framework de destino, y NuGet selecciona la compilación que coincide con el framework de destino de su proyecto.

| Paquete | Frameworks de destino en el paquete | Su proyecto puede dirigirse a |
|---|---|---|
| Aspose.Slides.NET | `net462`, `net6.0`, `netstandard2.0` | .NET Framework 4.6.2 o posterior; .NET 6 o posterior, incluidos .NET 8, .NET 9 y .NET 10 |
| Aspose.Slides.NET6.CrossPlatform | `net6.0` | .NET 6 o posterior, incluidos .NET 8, .NET 9 y .NET 10 |

La compilación `netstandard2.0` permite que una biblioteca de clases .NET Standard 2.0 haga referencia a Aspose.Slides.NET. Una aplicación que utiliza dicha biblioteca ejecuta la compilación que coincide con el framework de destino de la propia aplicación: una aplicación .NET 8, por ejemplo, ejecuta la compilación `net6.0`.

## **Sistemas operativos y procesadores compatibles**

**Aspose.Slides.NET** contiene solo código administrado independiente del procesador (AnyCPU), por lo que se ejecuta en la arquitectura del runtime .NET que lo carga. Dibuja diapositivas a través de la biblioteca System.Drawing.Common de Microsoft, la cual Microsoft admite [solo en Windows](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only). En Linux, Aspose.Slides.NET por lo tanto necesita la biblioteca `libgdiplus` y un interruptor de inicio, descritos en [Linux](#linux). Se ejecuta en distribuciones Linux que proporcionan `libgdiplus`, como Debian, Ubuntu y Alpine Linux.

**Aspose.Slides.NET6.CrossPlatform** dibuja diapositivas con su propio motor gráfico. El motor es una biblioteca nativa que el paquete contiene en una compilación por plataforma, por lo que el paquete solo se ejecuta en estas plataformas:

| Sistema operativo | Procesadores | Notas |
|---|---|---|
| Windows | x86, x64 | Windows en ARM64 no es compatible. |
| Linux | x64, ARM64 | Requiere glibc 2.23 o posterior en x64 y glibc 2.39 o posterior en ARM64. |
| macOS | x64 (Intel), ARM64 (Apple silicon) |  |

Aspose.Slides.NET6.CrossPlatform no se ejecuta en Alpine Linux u otras distribuciones basadas en musl en lugar de glibc, ni en distribuciones con una glibc más antigua, como CentOS 7. Use Aspose.Slides.NET en esos sistemas.

En Windows, la biblioteca nativa de Aspose.Slides.NET6.CrossPlatform utiliza el runtime de Microsoft Visual C++ (*MSVCP140.dll* y *VCRUNTIME140.dll*, además de *VCRUNTIME140_1.dll* en x64). Si estos archivos faltan en la máquina objetivo, instale el [Microsoft Visual C++ Redistributable](https://learn.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist?view=msvc-170).

## **Linux**

Ambos paquetes necesitan bibliotecas de sistema adicionales en Linux. Sin ellas, el primer ejemplo en [Crear presentaciones](/slides/es/net/create-presentation/) falla con una excepción en lugar de guardar el archivo. Los comandos a continuación son para Debian y Ubuntu; en estas distribuciones, cada biblioteca también incluye las fuentes DejaVu (`fonts-dejavu-core`), de modo que el texto se muestra sin paquetes de fuentes adicionales.

### **Aspose.Slides.NET6.CrossPlatform**

La biblioteca Linux del paquete requiere la biblioteca `fontconfig`:

```bash
sudo apt-get update && sudo apt-get install -y libfontconfig1
```

Sin ella, crear una [Presentación](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/) falla con una `TypeInitializationException` cuyo `DllNotFoundException` interno indica que no se puede abrir `libfontconfig.so.1`.

Las imágenes base mínimas también pueden no incluir `fontconfig`. La imagen base de AWS Lambda para .NET 8, por ejemplo, no contiene ni `fontconfig` ni fuentes. En una imagen de contenedor construida sobre ella, ejecute `dnf install -y fontconfig`, lo que también instala las fuentes Noto Sans.

### **Aspose.Slides.NET**

El paquete requiere dos cosas en Linux:

1. La biblioteca `libgdiplus`:

   ```bash
   sudo apt-get update && sudo apt-get install -y libgdiplus
   ```

2. El interruptor `System.Drawing.EnableUnixSupport`, habilitado al inicio de su aplicación antes de cualquier llamada a Aspose.Slides. En un *Program.cs* con declaraciones de nivel superior, colóquelo después de las directivas `using`:

   ```c#
   System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
   ```

Sin `libgdiplus`, guardar una presentación falla con una `TypeInitializationException` cuyo `DllNotFoundException` interno indica que no se puede cargar `libgdiplus`. Sin el interruptor, la excepción interna es `PlatformNotSupportedException: System.Drawing.Common no es compatible con plataformas que no sean Windows`.

{{% alert color="warning" title="Warning" %}}
El interruptor solo funciona con System.Drawing.Common 6, la versión de la que depende Aspose.Slides.NET. Microsoft lo eliminó en System.Drawing.Common 7. Si su proyecto hace referencia a System.Drawing.Common 7 o posterior, directa o indirectamente a través de otro paquete, Aspose.Slides.NET falla en Linux con `PlatformNotSupportedException` incluso con `libgdiplus` instalado y el interruptor habilitado. En ese caso, use Aspose.Slides.NET6.CrossPlatform.
{{% /alert %}}

### **Alpine Linux**

En Alpine Linux, use Aspose.Slides.NET con el interruptor descrito arriba. Las imágenes Alpine normalmente no contienen fuentes, y `libgdiplus` por sí solo no instala ninguna, por lo que instale `libgdiplus` junto con al menos un paquete de fuentes. Sin fuentes, guardar una presentación falla con este error:

```text
System.ArgumentException: Font '?' cannot be found.
```

**Opción 1: fuentes DejaVu**

La opción recomendada es el paquete `ttf-dejavu`:

```dockerfile
RUN apk add --no-cache \
    libgdiplus \
    ttf-dejavu
```

En las versiones actuales de Alpine, `ttf-dejavu` instala el paquete `font-dejavu`, que también instala `fontconfig` y las herramientas de fuentes de las que depende.

**Opción 2: fuentes centrales de Microsoft**

Si sus presentaciones usan fuentes de Microsoft como Arial, Times New Roman, Courier New o Verdana, instale las fuentes centrales de Microsoft en su lugar. El paso `update-ms-fonts` descarga las fuentes mientras se construye la imagen, por lo que la compilación necesita acceso a Internet:

```dockerfile
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```

### **Compatibilidad de globalización**

Ambos paquetes necesitan compatibilidad de globalización de .NET, que .NET en Linux proporciona a través de las bibliotecas ICU. En el [modo de globalización invariante](https://learn.microsoft.com/en-us/dotnet/core/runtime-config/globalization), crear una [Presentación](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/) falla con `CultureNotFoundException: Only the invariant culture is supported in globalization-invariant mode`.

Algunas imágenes de contenedor activan este modo. Las imágenes de tiempo de ejecución .NET para Alpine Linux (`runtime-deps`, `runtime` y `aspnet`), por ejemplo, establecen `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=true` y no incluyen ICU. En una imagen construida sobre ellas, instale ICU y desactive el modo:

```dockerfile
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk --no-cache add icu-libs
```

Además, asegúrese de que su archivo de proyecto no establezca la propiedad `InvariantGlobalization` en `true`.

## **Compruebe su configuración**

Para verificar que un paquete y sus requisitos estén presentes, ejecute un programa que guarde una presentación y renderice una diapositiva a una imagen. Guardar y renderizar utilizan la biblioteca gráfica y las fuentes, que son lo que proporcionan los requisitos de Linux anteriores.

Cree una aplicación de consola y agregue el paquete como se describe en [Instalación](/slides/es/net/installation/), reemplace el contenido de *Program.cs* con el código a continuación y ejecute `dotnet run`. Si usa Aspose.Slides.NET en Linux, añada la sentencia del interruptor `System.Drawing.EnableUnixSupport` mostrada en [Linux](#linux) después de las directivas `using`. El programa utiliza declaraciones de nivel superior y declaraciones `using`, que requieren C# 9 o posterior. Los proyectos que apuntan a .NET 6 o posterior usan una versión de C# más reciente por defecto; en un proyecto que apunta a .NET Framework, añada `<LangVersion>latest</LangVersion>` a un `PropertyGroup` en el archivo de proyecto.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);

using var image = slide.GetImage(1f, 1f);
image.Save("hello.png", ImageFormat.Png);
```

El programa agrega un rectángulo con texto a la primera diapositiva y guarda la presentación como *hello.pptx* con el método [Save](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/save/). Luego renderiza la diapositiva con [GetImage](https://reference.aspose.com/slides/es/net/aspose.slides/slide/getimage/) y guarda el resultado como *hello.png* con [IImage.Save](https://reference.aspose.com/slides/es/net/aspose.slides/iimage/save/) en el formato [ImageFormat.Png](https://reference.aspose.com/slides/es/net/aspose.slides/imageformat/). Los factores de escala de 1 renderizan un píxel por punto, por lo que la diapositiva predeterminada de 720 × 540 puntos se convierte en una imagen de 720 × 540 píxeles, con el texto visible dentro del rectángulo. Sin una licencia, ambos archivos también llevan una marca de agua de evaluación; vea [Licencias](/slides/es/net/licensing/). Si falta algún requisito, el programa se detiene con una de las excepciones descritas en [Linux](#linux).

## **Herramientas de desarrollo**

Puede compilar aplicaciones que utilizan Aspose.Slides con cualquier herramienta que admita el framework de destino de su proyecto: el SDK .NET y su interfaz de línea de comandos `dotnet` en Windows, Linux y macOS, o Visual Studio en Windows. [Instalación](/slides/es/net/installation/) describe ambas.

## **Preguntas frecuentes**

**¿Necesito tener Microsoft PowerPoint instalado para conversiones y renderizado?**

No, PowerPoint no es necesario. Aspose.Slides es un motor independiente para [crear](/slides/es/net/create-presentation/), modificar, [convertir](/slides/es/net/convert-presentation/) y [renderizar](/slides/es/net/convert-powerpoint-to-png/) presentaciones.

**¿Qué paquete debo usar?**

Use Aspose.Slides.NET en Windows y Aspose.Slides.NET6.CrossPlatform en Linux y macOS. En Alpine Linux, en sistemas Linux cuya glibc sea más antigua que las versiones indicadas arriba, y en proyectos que apunten a .NET Framework, use Aspose.Slides.NET. Añada solo uno de los dos paquetes a un proyecto.

**¿Qué fuentes se necesitan para un renderizado correcto?**

Las fuentes utilizadas en la presentación, o sustitutos adecuados, deben estar disponibles en el sistema operativo. En Linux y macOS, instale los paquetes de fuentes que sus presentaciones necesiten para obtener un renderizado coherente. En Alpine Linux, instale al menos un paquete de fuentes además de `libgdiplus`, como se describe en [Alpine Linux](#alpine-linux).

**¿Por qué una fuente personalizada se muestra como sustituta o texto faltante en Linux?**

Si el archivo de fuente tiene entradas de tabla de nombres inconsistentes o corruptas, la pila de coincidencia de fuentes de Linux (FreeType/fontconfig) puede seleccionar un registro inválido, lo que hace que la fuente no se resuelva. Utilizar una versión de la fuente con registros de tabla de nombres corregidos o instalar un sustituto coherente resuelve el problema.