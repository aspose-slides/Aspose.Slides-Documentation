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
description: "Aplicar, gestionar y solucionar problemas de licencias en Aspose.Slides para C++. Garantice un acceso ininterrumpido a todas las funciones con nuestra guía paso a paso de licenciamiento."
---
## **Descripción general**

Aspose.Slides se puede usar en modo de evaluación o con una licencia válida. La versión de evaluación ofrece la misma funcionalidad que la versión con licencia, pero añade una marca de agua de evaluación cuando se abre o guarda una presentación y limita la extracción de texto a una diapositiva.

Este artículo explica cómo funciona la licencia en Aspose.Slides y cómo aplicar una licencia antes de usar la biblioteca. Una licencia puede cargarse desde un archivo, flujo o recurso incrustado mediante la clase `License`. El artículo también muestra cómo validar si una licencia se ha aplicado correctamente.

## **Evaluar Aspose.Slides**

{{% alert color="info" %}} 
Puede descargar una versión de evaluación de **Aspose.Slides for C++** desde [su página de descarga de NuGet](https://www.nuget.org/packages/Aspose.Slides.CPP/). La versión de evaluación ofrece la misma funcionalidad que el producto con licencia. De hecho, el paquete de evaluación es idéntico al adquirido; simplemente se licencia una vez que añada unas pocas líneas de código para aplicar la licencia.

Una vez que esté satisfecho con su evaluación de **Aspose.Slides**, puede [adquirir una licencia](https://purchase.aspose.com/buy). Le recomendamos revisar los tipos de suscripción disponibles. Si tiene alguna pregunta, no dude en contactar con el equipo de ventas de Aspose.

Cada licencia de Aspose incluye una suscripción de un año para actualizaciones gratuitas, incluidas nuevas versiones y correcciones de errores publicadas durante ese período. Tanto si usa una versión con licencia como una de evaluación, recibe soporte técnico gratuito e ilimitado.
{{% /alert %}} 

**Limitaciones de la versión de evaluación**

* Mientras la versión de evaluación de Aspose.Slides (cuando no se aplica ninguna licencia) ofrece la funcionalidad completa del producto, inserta una marca de agua de evaluación en la parte superior del documento durante las operaciones de apertura y guardado.
* La extracción de texto está limitada a una diapositiva al usar la versión de evaluación.

{{% alert color="info" %}} 
Para probar Aspose.Slides sin limitaciones, puede solicitar una **Licencia Temporal de 30 días**. Para obtener más información, consulte la página [Cómo obtener una licencia temporal](https://purchase.aspose.com/temporary-license).
{{% /alert %}}

## **Licencias en Aspose.Slides**

* Una versión de evaluación pasa a estar licenciada después de adquirir una licencia y aplicarla añadiendo un par de líneas de código.
* La licencia es un archivo XML de texto plano que contiene detalles como el nombre del producto, el número de desarrolladores a los que está licenciada, la fecha de vencimiento de la suscripción, entre otros.
* El archivo de licencia está firmado digitalmente, por lo que no debe modificarse. Incluso un cambio accidental, como añadir un salto de línea, invalidará el archivo.
* Aspose.Slides for C++ normalmente busca el archivo de licencia en las siguientes ubicaciones:
  * Una ruta especificada explícitamente en su código
  * La carpeta que contiene el DLL del componente (incluido en Aspose.Slides)
  * La carpeta que contiene el ensamblado que llama al DLL del componente
* Para evitar las limitaciones de la versión de evaluación, debe establecer la licencia antes de usar Aspose.Slides. Una licencia solo necesita establecerse una vez por aplicación o proceso.

## **Aplicar una licencia**

Una licencia puede cargarse desde un **archivo**, un **flujo** o un **recurso incrustado**.

{{% alert color="info" %}}
Aspose.Slides proporciona la clase [License](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.license/) para operaciones de licenciamiento.
{{% /alert %}} 

{{% alert color="warning" %}}
Las licencias nuevas solo pueden activar Aspose.Slides con la versión 21.4 o posterior. Las versiones anteriores utilizan un sistema de licenciamiento diferente y no reconocerán estas licencias.
{{% /alert %}}

### **Archivo**

La forma más sencilla de establecer una licencia es colocar el archivo de licencia en la misma carpeta que el DLL del componente (incluido en Aspose.Slides) y especificar solo el nombre del archivo, sin la ruta.

El siguiente código C++ muestra cómo establecer un archivo de licencia:

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

{{% alert color="warning" %}} 
Si coloca el archivo de licencia en un directorio diferente, al llamar al método [License::SetLicense](https://reference.aspose.com/slides/es/cpp/aspose.slides/license/setlicense/), el nombre del archivo al final de la ruta explícita especificada debe coincidir exactamente con el nombre de su archivo de licencia.

Por ejemplo, si renombra su archivo de licencia a *Aspose.Slides.lic.xml*, debe pasar la ruta completa que termine con *Aspose.Slides.lic.xml* al método [License::SetLicense](https://reference.aspose.com/slides/es/cpp/aspose.slides/license/setlicense/) en su código.
{{% /alert %}}

### **Flujo**

Puede cargar una licencia desde un flujo. El siguiente código C++ muestra cómo aplicar una licencia desde un flujo:

```c++
#include <Util/License.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto license = MakeObject<License>();

auto stream = File::OpenRead(u"Aspose.Slides.lic");

license->SetLicense(stream);
```

## **Validar una licencia**

Para comprobar si una licencia se ha configurado correctamente, puede validarla. El siguiente código C++ muestra cómo validar una licencia:

```c++
#include <Util/License.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto license = MakeObject<License>();

license->SetLicense(u"Aspose.Slides.lic");

if (license->IsLicensed())
{
    Console::WriteLine(u"License is good!");
    Console::ReadKey();
}
```

## **Seguridad en subprocesos**

{{% alert title="Note" color="warning" %}} 
El método [License::SetLicense](https://reference.aspose.com/slides/es/cpp/aspose.slides/license/setlicense/) **no es seguro para subprocesos**. Si necesita llamar a este método desde varios subprocesos simultáneamente, se recomienda usar primitivas de sincronización (como un bloqueo) para evitar posibles problemas.
{{% /alert %}}

## **Preguntas frecuentes**

### ¿Puedo aplicar la licencia en un entorno completamente offline (sin acceso a internet)?

Sí. La validación de la licencia se realiza localmente usando el archivo de licencia; no se requiere conexión a internet.

### ¿Qué ocurre después de que expira la suscripción de un año? ¿Dejará de funcionar la biblioteca?

No. La licencia es perpetua: puede seguir usando las versiones publicadas antes de la fecha de finalización de su suscripción; simplemente no podrá usar versiones más recientes sin renovar.