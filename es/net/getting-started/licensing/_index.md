---
title: Licenciamiento
type: docs
weight: 80
url: /es/net/licensing/
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
- .NET
- C#
- Aspose.Slides
description: "Aplicar, gestionar y solucionar problemas de licencias en Aspose.Slides para .NET. Garantice acceso ininterrumpido a todas las funciones con nuestra guía paso a paso de licenciamiento."
---
## **Visión general**

Aspose.Slides puede usarse en modo de evaluación o con una licencia válida. La versión de evaluación proporciona la misma funcionalidad que la versión con licencia, pero añade una marca de agua de evaluación a cada diapositiva de cada presentación que guarda y trunca el texto que su código lee de las presentaciones.

Este artículo explica cómo funciona el licenciamiento en Aspose.Slides y cómo aplicar una licencia antes de usar la biblioteca. Una licencia puede cargarse desde un archivo, flujo o recurso incrustado mediante la clase `License`. El artículo también muestra cómo validar si una licencia se ha aplicado correctamente.

## **Evaluar Aspose.Slides**

{{% alert color="info" title="Note" %}}

Puede descargar una versión de evaluación de **Aspose.Slides for .NET** desde [su página de descarga de NuGet](https://www.nuget.org/packages/Aspose.Slides.NET/). La versión de evaluación proporciona las mismas funcionalidades que la versión con licencia del producto. El paquete de evaluación es el mismo que el paquete adquirido. La versión de evaluación pasa a estar licenciada simplemente añadiendo unas cuantas líneas de código (para aplicar la licencia).

Una vez que esté satisfecho con su evaluación de **Aspose.Slides**, puede [adquirir una licencia](https://purchase.aspose.com/pricing/slides/es/net/). Le recomendamos que revise los distintos tipos de suscripción. Si tiene preguntas, contacte con el equipo de ventas de Aspose.

Cada licencia de Aspose incluye una suscripción de un año para actualizaciones gratuitas a nuevas versiones o correcciones publicadas dentro del período de suscripción. Los usuarios con productos con licencia o incluso versiones de evaluación obtienen soporte técnico gratuito e ilimitado.

{{% /alert %}} 

**Limitaciones de la versión de evaluación**

* La versión de evaluación (sin una licencia especificada) proporciona la funcionalidad completa del producto, pero añade un cuadro de texto con marca de agua de evaluación a cada diapositiva de cada presentación que guarda.
* El texto que su código lee de una presentación se trunca a sus primeros caracteres, seguido de una notificación sobre la limitación de evaluación. El texto que su código escribe se guarda completo.

{{% alert color="info" title="Note" %}}

Para probar Aspose.Slides sin limitaciones, puede solicitar una **Licencia temporal de 30 días**. Consulte la página [Cómo obtener una licencia temporal](https://purchase.aspose.com/temporary-license) para más información.

{{% /alert %}}

## **Licenciamiento en Aspose.Slides**
* Una versión de evaluación pasa a estar licenciada después de que adquiera una licencia y añada un par de líneas de código (para aplicar la licencia).
* La licencia es un archivo XML de texto sin formato que contiene detalles como el nombre del producto, el número de desarrolladores a los que está licenciada, la fecha de expiración de la suscripción, etc. 
* El archivo de licencia está firmado digitalmente, por lo que no debe modificarlo. Incluso la adición inadvertida de un salto de línea extra al contenido del archivo lo invalidará.
* Aspose.Slides for .NET normalmente intenta encontrar la licencia en estas ubicaciones:
  * Una ruta explícita
  * La carpeta que contiene el dll del componente (incluido en Aspose.Slides)
  * La carpeta que contiene el ensamblado que llamó al dll del componente (incluido en Aspose.Slides)
  * La carpeta que contiene el ensamblado de entrada (su .exe)
  * Un recurso incrustado en el ensamblado que llamó al dll del componente (incluido en Aspose.Slides).
* Para evitar las limitaciones asociadas a la versión de evaluación, debe establecer una licencia antes de usar Aspose.Slides. Sólo tiene que establecer la licencia una vez por aplicación o proceso.

{{% alert color="info" title="Note" %}}

Puede que desee consultar [Licenciamiento por consumo](/slides/es/net/metered-licensing/).

{{% /alert %}} 

## **Aplicar una licencia**
Una licencia puede cargarse desde un **archivo**, **flujo** o **recurso incrustado**. 

{{% alert color="info" title="Note" %}}

Aspose.Slides proporciona la clase [License](https://reference.aspose.com/slides/es/net/aspose.slides/license) para operaciones de licenciamiento.

{{% /alert %}} 

{{% alert color="warning" title="Warning" %}}

Las licencias nuevas pueden activar Aspose.Slides sólo con la versión 21.4 o posterior. Las versiones anteriores usan un sistema de licenciamiento diferente y no reconocerán estas licencias.

{{% /alert %}}

### **Archivo**
El método más sencillo para establecer una licencia requiere que coloque el archivo de licencia en la misma carpeta que contiene el DLL del componente (incluido en Aspose.Slides) y que indique solo el nombre del archivo sin su ruta.

Este código C# le muestra cómo establecer un archivo de licencia:

``` csharp
// Instancia la clase License
Aspose.Slides.License license = new Aspose.Slides.License();

// Establece la ruta del archivo de licencia
license.SetLicense("Aspose.Slides.lic");
```

{{% alert color="warning" title="Warning" %}}

Si coloca el archivo de licencia en un directorio diferente, cuando llame al método [SetLicense](https://reference.aspose.com/slides/es/net/aspose.slides/license/setlicense/#setlicense_1), el nombre del archivo de licencia al final de la ruta especificada debe ser idéntico al nombre de su archivo de licencia.

Por ejemplo, puede cambiar el nombre del archivo de licencia a *Aspose.Slides.lic.xml*. Entonces, en su código, debe pasar la ruta al archivo (finalizando con *Aspose.Slides.lic.xml*) al método [SetLicense](https://reference.aspose.com/slides/es/net/aspose.slides/license/setlicense/#setlicense_1).

{{% /alert %}}

### **Flujo**
Puede cargar una licencia desde un flujo. Este código C# le muestra cómo aplicar una licencia desde un flujo:

``` csharp
// Instancia la clase License
Aspose.Slides.License license = new Aspose.Slides.License();

// Abre el archivo de licencia como flujo
using FileStream licenseStream = File.OpenRead("Aspose.Slides.lic");

// Establece la licencia mediante un flujo
license.SetLicense(licenseStream);
```

### **Recurso incrustado**
Puede empaquetar la licencia con su aplicación (para evitar perderla) añadiendo la licencia como recurso incrustado en uno de los ensamblados que llaman al DLL del componente (incluido en Aspose.Slides). 

Así es como se añade un archivo de licencia como recurso incrustado:

1. En Visual Studio, añada el archivo de licencia (.lic) al proyecto de esta manera: vaya a **File** > **Add Existing Item** > **Add**. 
2. Seleccione el archivo en el **Solution Explorer**.
3. En la ventana **Properties**, establezca **Build Action** a **Embedded Resource**.
4. Para acceder a la licencia incrustada en el ensamblado, añada el archivo de licencia como recurso incrustado al proyecto y luego pase el nombre del archivo de licencia al método `SetLicense`. 


La clase `License` encuentra automáticamente el archivo de licencia en los recursos incrustados. No necesita llamar a los métodos `GetExecutingAssembly` y `GetManifestResourceStream` de la clase `System.Reflection.Assembly` en el Microsoft .NET Framework.

Este código C# le muestra cómo establecer una licencia como recurso incrustado:

``` csharp
// Instancia la clase License
Aspose.Slides.License license = new Aspose.Slides.License();

// Pasa el nombre del archivo de licencia incrustado en el ensamblado
license.SetLicense("Aspose.Slides.lic");
```

## **Validar una licencia**

Para comprobar si una licencia se ha configurado correctamente, puede validarla. Este código C# le muestra cómo validar una licencia:

```c#
Aspose.Slides.License license = new Aspose.Slides.License();

license.SetLicense("Aspose.Slides.lic");

if (license.IsLicensed())
{
    Console.WriteLine("License is good!");
    Console.Read();
}
```

## **Seguridad de subprocesos**

{{% alert color="warning" title="Warning" %}}

El método [license.SetLicense](https://reference.aspose.com/slides/es/net/aspose.slides/license/setlicense/) no es seguro en entornos multihilo. Si este método debe llamarse simultáneamente desde varios hilos, conviene usar primitivas de sincronización (como un candado) para evitar problemas. 

{{% /alert %}}

## **Preguntas frecuentes**

### ¿Puedo aplicar la licencia en un entorno completamente offline (sin acceso a internet)?

Sí. La validación de la licencia se realiza localmente mediante el archivo de licencia; no se requiere conexión a Internet.

### ¿Qué ocurre después de que expire la suscripción de un año? ¿Dejará de funcionar la biblioteca?

No. La licencia es perpetua: puede seguir usando las versiones publicadas antes de la fecha de fin de su suscripción; simplemente no podrá utilizar versiones más recientes sin renovar.