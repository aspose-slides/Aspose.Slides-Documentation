---
title: Licenciamiento
type: docs
weight: 120
url: /es/cpp/licensing/
keywords:
- licencia
- licencia temporal
- establecer licencia
- usar licencia
- validar licencia
- archivo de licencia
- versión de evaluación
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Aplicar, gestionar y solucionar problemas de licencias en Aspose.Slides para C++. Garantice un acceso ininterrumpido a todas las funciones con nuestra guía paso a paso sobre licenciamiento."
---
## **Resumen**

Aspose.Slides puede usarse en modo de evaluación o con una licencia válida. La versión de evaluación ofrece la misma funcionalidad que la versión con licencia, pero añade una marca de agua de evaluación a cada diapositiva de cada presentación que guarda y trunca el texto que su código lee de las presentaciones.

Este artículo explica cómo funciona el licenciamiento en Aspose.Slides y cómo aplicar una licencia antes de usar la biblioteca. Una licencia puede cargarse desde un archivo o un flujo mediante la clase `License`. El artículo también muestra cómo validar si una licencia se ha aplicado correctamente.

## **Evaluar Aspose.Slides**

{{% alert color="info" title="Note" %}}
Puede descargar una versión de evaluación de **Aspose.Slides for C++** desde [su página de descarga de NuGet](https://www.nuget.org/packages/Aspose.Slides.Cpp/) o, como paquete ZIP, desde la [página de descargas](https://releases.aspose.com/slides/es/cpp/). La versión de evaluación ofrece la misma funcionalidad que el producto con licencia. De hecho, el paquete de evaluación es idéntico al adquirido; simplemente se licencia una vez que añade unas pocas líneas de código para aplicar la licencia.

Una vez que esté satisfecho con su evaluación de **Aspose.Slides**, puede [adquirir una licencia](https://purchase.aspose.com/pricing/slides/es/cpp/). Recomendamos revisar los tipos de suscripción disponibles. Si tiene alguna pregunta, no dude en contactar al equipo de ventas de Aspose.

Todas las licencias de Aspose incluyen una suscripción de un año para actualizaciones gratuitas, incluidas nuevas versiones y correcciones de errores publicadas durante ese periodo. Tanto si usa una versión con licencia como una de evaluación, recibe soporte técnico gratuito e ilimitado.
{{% /alert %}} 

**Limitaciones de la versión de evaluación**

* La versión de evaluación (sin especificar una licencia) proporciona la funcionalidad completa del producto, pero añade un cuadro de texto de marca de agua de evaluación a cada diapositiva de cada presentación que guarda.
* El texto que su código lee de una presentación se trunca a sus primeros caracteres, seguido de un aviso sobre la limitación de la evaluación. El texto que su código escribe se guarda íntegramente.

{{% alert color="info" title="Note" %}}
Para probar Aspose.Slides sin limitaciones, puede solicitar una **Licencia Temporal de 30 días**. Para obtener más información, consulte la página [How to Get a Temporary License](https://purchase.aspose.com/temporary-license).
{{% /alert %}}

## **Licenciamiento en Aspose.Slides**

* Una versión de evaluación se licencia después de adquirir una licencia y aplicarla añadiendo un par de líneas de código.
* La licencia es un archivo XML de texto plano que contiene detalles como el nombre del producto, el número de desarrolladores a los que se licencia, la fecha de vencimiento de la suscripción y más.
* El archivo de licencia está firmado digitalmente, por lo que no debe modificarse. Incluso un cambio accidental —como añadir un salto de línea— invalidará el archivo.
* Cuando pasa un nombre de archivo sin carpeta, Aspose.Slides for C++ busca el archivo de licencia únicamente en el directorio de trabajo actual. No busca en la carpeta de su ejecutable ni en la biblioteca Aspose.Slides, por lo que debe pasar la ruta completa cuando el archivo de licencia se almacena en otro lugar.
* Para evitar las limitaciones de la versión de evaluación, debe establecer la licencia antes de usar Aspose.Slides. Una licencia solo necesita establecerse una vez por aplicación o proceso.

## **Aplicar una licencia**

Una licencia puede cargarse desde un **archivo** o un **flujo**.

{{% alert color="info" title="Note" %}}
Aspose.Slides proporciona la clase [License](https://reference.aspose.com/slides/es/cpp/aspose.slides/license/) para operaciones de licenciamiento.
{{% /alert %}} 

{{% alert color="warning" title="Warning" %}}
Las licencias nuevas pueden activar Aspose.Slides solo con la versión 21.4 o posterior. Las versiones anteriores utilizan un sistema de licenciamiento diferente y no reconocerán estas licencias.
{{% /alert %}}

### **Archivo**

La forma más sencilla de establecer una licencia es colocar el archivo de licencia en el directorio de trabajo de su programa y especificar solo el nombre del archivo, sin la ruta. De lo contrario, especifique la ruta completa al archivo.

El siguiente código C++ aplica el archivo de licencia *Aspose.Slides.lic* desde el directorio de trabajo del programa:

```c++
#include <Util/License.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

int main()
{
    auto license = MakeObject<License>();
    license->SetLicense(u"Aspose.Slides.lic");

    return 0;
}
```

Si la licencia es válida, [License::SetLicense](https://reference.aspose.com/slides/es/cpp/aspose.slides/license/setlicense/) devuelve y el programa finaliza sin salida; a partir de ese momento, Aspose.Slides funciona sin las limitaciones de evaluación. Si el archivo no está en el directorio de trabajo, el método lanza una [FileNotFoundException](https://reference.aspose.com/slides/es/cpp/system.io/filenotfoundexception/) con el mensaje *License "Aspose.Slides.lic" doesn't exist or access is restricted*. El ejemplo no controla la excepción, por lo que el programa se detiene.

{{% alert color="warning" title="Warning" %}}
Si coloca el archivo de licencia en un directorio diferente, al llamar al método [License::SetLicense](https://reference.aspose.com/slides/es/cpp/aspose.slides/license/setlicense/), el nombre del archivo al final de la ruta explícita especificada debe coincidir exactamente con el nombre de su archivo de licencia.

Por ejemplo, si renombra su archivo de licencia a *Aspose.Slides.lic.xml*, debe pasar la ruta completa que termine en *Aspose.Slides.lic.xml* al método [License::SetLicense](https://reference.aspose.com/slides/es/cpp/aspose.slides/license/setlicense/) en su código.
{{% /alert %}}

### **Flujo**

Cargue una licencia desde un flujo cuando su programa no conserva la licencia como un archivo que pueda nombrar, por ejemplo, cuando la lee desde una base de datos. [License::SetLicense](https://reference.aspose.com/slides/es/cpp/aspose.slides/license/setlicense/) acepta cualquier [Stream](https://reference.aspose.com/slides/es/cpp/system.io/stream/) que contenga la licencia. Para mantener el ejemplo breve, el siguiente código C++ abre *Aspose.Slides.lic* en el directorio de trabajo con [File::OpenRead](https://reference.aspose.com/slides/es/cpp/system.io/file/openread/) y aplica la licencia desde ese flujo:

```c++
#include <Util/License.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

int main()
{
    auto license = MakeObject<License>();
    auto stream = File::OpenRead(u"Aspose.Slides.lic");
    license->SetLicense(stream);

    return 0;
}
```

Una licencia válida produce el mismo resultado que en el ejemplo con archivo. Si el archivo no existe, [File::OpenRead](https://reference.aspose.com/slides/es/cpp/system.io/file/openread/) lanza una [FileNotFoundException](https://reference.aspose.com/slides/es/cpp/system.io/filenotfoundexception/) antes de que se aplique la licencia, y el programa se detiene.

## **Validar una licencia**

Para comprobar si una licencia se ha configurado correctamente, llame a [License::IsLicensed](https://reference.aspose.com/slides/es/cpp/aspose.slides/license/islicensed/). Devuelve `true` solo después de que se haya aplicado una licencia válida, y `false` antes de eso. El siguiente código C++ aplica el archivo de licencia desde el directorio de trabajo y luego lo verifica:

```c++
#include <Util/License.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

int main()
{
    auto license = MakeObject<License>();
    license->SetLicense(u"Aspose.Slides.lic");

    if (license->IsLicensed())
    {
        Console::WriteLine(u"License is good!");
    }

    return 0;
}
```

Con una licencia válida, el programa muestra *License is good!*. Si el archivo falta o no es un archivo de licencia, [License::SetLicense](https://reference.aspose.com/slides/es/cpp/aspose.slides/license/setlicense/) lanza una excepción antes de la comprobación, y el programa se detiene sin imprimir nada. Si el archivo es una licencia cuya firma no coincide, por ejemplo porque se ha editado, SetLicense devuelve sin error pero `IsLicensed` devuelve `false`, por lo que no se imprime nada y Aspose.Slides permanece en modo de evaluación.

## **Seguridad en hilos**

{{% alert color="warning" title="Warning" %}}
El método [License::SetLicense](https://reference.aspose.com/slides/es/cpp/aspose.slides/license/setlicense/) **no es seguro para hilos**. Si necesita llamar a este método desde varios hilos simultáneamente, se recomienda usar primitivas de sincronización (como un candado) para evitar problemas potenciales.
{{% /alert %}}

## **FAQ**

### ¿Puedo aplicar la licencia en un entorno completamente sin conexión (sin acceso a Internet)?

Sí. La validación de la licencia se realiza localmente usando el archivo de licencia; no se requiere conexión a Internet.

### ¿Qué ocurre después de que expira la suscripción de un año? ¿Dejará de funcionar la biblioteca?

No. La licencia es perpetua: puede seguir usando las versiones publicadas antes de la fecha de finalización de su suscripción; simplemente no podrá usar versiones más recientes sin renovar.