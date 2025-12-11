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
description: "Aplicar, gestionar y solucionar problemas de licencias en Aspose.Slides para C++. Garantiza un acceso ininterrumpido a todas las funciones con nuestra guía paso a paso de licenciamiento."
---

## **Evaluar Aspose.Slides**

{{% alert color="primary" %}} 

Puede descargar una versión de evaluación de **Aspose.Slides for C++** desde [su página de descarga en NuGet](https://www.nuget.org/packages/Aspose.Slides.CPP/). La versión de evaluación ofrece la misma funcionalidad que el producto con licencia. De hecho, el paquete de evaluación es idéntico al adquirido; simplemente se convierte en licenciado una vez que agrega unas pocas líneas de código para aplicar la licencia.

Una vez que esté satisfecho con su evaluación de **Aspose.Slides**, puede [comprar una licencia](https://purchase.aspose.com/buy). Le recomendamos revisar los tipos de suscripción disponibles. Si tiene alguna pregunta, no dude en contactar al equipo de ventas de Aspose.

Cada licencia de Aspose incluye una suscripción de un año para actualizaciones gratuitas, incluidas nuevas versiones y correcciones de errores lanzadas durante ese período. Tanto si usa una versión con licencia como una de evaluación, recibe soporte técnico gratuito e ilimitado.

{{% /alert %}} 

**Limitaciones de la versión de evaluación**

* Mientras la versión de evaluación de Aspose.Slides (cuando no se aplica una licencia) proporciona la funcionalidad completa del producto, inserta una marca de agua de evaluación en la parte superior del documento durante las operaciones de apertura y guardado.
* La extracción de texto está limitada a una diapositiva cuando se utiliza la versión de evaluación.

{{% alert color="primary" %}} 

Para probar Aspose.Slides sin limitaciones, puede solicitar una **Licencia temporal de 30 días**. Para más información, consulte la página [Cómo obtener una licencia temporal](https://purchase.aspose.com/temporary-license).

{{% /alert %}}

## **Licencias en Aspose.Slides**

* Una versión de evaluación se convierte en licenciada después de que compre una licencia y la aplique agregando un par de líneas de código.
* La licencia es un archivo XML de texto plano que contiene detalles como el nombre del producto, el número de desarrolladores a los que se licencia, la fecha de expiración de la suscripción y más.
* El archivo de licencia está firmado digitalmente, por lo que no debe modificarse. Incluso un cambio accidental, como agregar un salto de línea, invalidará el archivo.
* Aspose.Slides for C++ normalmente busca el archivo de licencia en las siguientes ubicaciones:
  * Una ruta especificada explícitamente en su código
  * La carpeta que contiene el DLL del componente (incluido en Aspose.Slides)
  * La carpeta que contiene el ensamblado que llama al DLL del componente
* Para evitar las limitaciones de la versión de evaluación, debe establecer la licencia antes de usar Aspose.Slides. Una licencia solo necesita establecerse una vez por aplicación o proceso.

## **Aplicar una licencia**

Una licencia puede cargarse desde un **archivo**, un **flujo** o un **recurso incrustado**.

{{% alert color="primary" %}}

Aspose.Slides proporciona la clase [License](https://reference.aspose.com/slides/cpp/class/aspose.slides.license/) para operaciones de licenciamiento.

{{% /alert %}} 

{{% alert color="warning" %}}

Las licencias nuevas pueden activar Aspose.Slides solo con la versión 21.4 o posterior. Las versiones anteriores usan un sistema de licenciamiento diferente y no reconocerán estas licencias.

{{% /alert %}}

### **Archivo**

La forma más sencilla de establecer una licencia es colocar el archivo de licencia en la misma carpeta que el DLL del componente (incluido en Aspose.Slides) y especificar solo el nombre del archivo, sin la ruta.

El siguiente código C++ muestra cómo establecer un archivo de licencia:
```c++
#include <Util/License.h>

using namespace Aspose::Slides;

int main()
{
    auto license = MakeObject<License>();
    license->SetLicense(u"Aspose.Slides.lic");

    return 0;
}
```


{{% alert color="warning" %}} 

Si coloca el archivo de licencia en un directorio diferente, entonces al llamar al método [License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/), el nombre del archivo al final de la ruta explícita especificada debe coincidir exactamente con el nombre de su archivo de licencia.

Por ejemplo, si renombra su archivo de licencia a *Aspose.Slides.lic.xml*, debe pasar la ruta completa terminada en *Aspose.Slides.lic.xml* al método [License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) en su código.

{{% /alert %}}

### **Flujo**

Puede cargar una licencia desde un flujo. El siguiente código C++ muestra cómo aplicar una licencia desde un flujo:
```c++
auto license = MakeObject<License>();

auto stream = File::OpenRead(u"Aspose.Slides.lic");

license->SetLicense(stream);
```


## **Validar una licencia**

Para comprobar si una licencia se ha establecido correctamente, puede validarla. El siguiente código C++ muestra cómo validar una licencia:
```c++
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

El método [License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) **no es seguro para subprocesos**. Si necesita llamar a este método desde varios subprocesos simultáneamente, se recomienda usar primitivas de sincronización (como un bloqueo) para evitar posibles problemas.

{{% /alert %}}

## **FAQ**

**¿Puedo aplicar la licencia en un entorno completamente offline (sin acceso a Internet)?**

Sí. La validación de la licencia se realiza localmente usando el archivo de licencia; no se requiere conexión a Internet.

**¿Qué ocurre después de que expire la suscripción de un año? ¿La biblioteca dejará de funcionar?**

No. La licencia es perpetua: puede seguir usando las versiones lanzadas antes de la fecha de finalización de su suscripción; simplemente no podrá usar versiones más recientes sin renovar.