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
description: "Aplicar, gestionar y solucionar problemas de licencias en Aspose.Slides para .NET. Garantiza un acceso ininterrumpido a todas las funciones con nuestra guía paso a paso de licenciamiento."
---
## **Visión general**

Aspose.Slides puede usarse en modo de evaluación o con una licencia válida. La versión de evaluación ofrece la misma funcionalidad que la versión con licencia, pero añade una marca de agua de evaluación cuando se abren o guardan presentaciones y limita la extracción de texto a una diapositiva.

Este artículo explica cómo funciona el licenciamiento en Aspose.Slides y cómo aplicar una licencia antes de usar la biblioteca. Una licencia puede cargarse desde un archivo, un flujo o un recurso incrustado mediante la clase `License`. El artículo también muestra cómo validar si una licencia se ha aplicado correctamente.

## **Evaluar Aspose.Slides**

{{% alert color="info" %}} 

Puedes descargar una versión de evaluación de **Aspose.Slides for NET** desde [su página de descarga en NuGet](https://www.nuget.org/packages/Aspose.Slides.NET/). La versión de evaluación proporciona las mismas funcionalidades que la versión con licencia del producto. El paquete de evaluación es idéntico al paquete adquirido. La versión de evaluación pasa a estar licenciada después de que añadas unas pocas líneas de código (para aplicar la licencia).

Una vez que estés satisfecho con tu evaluación de **Aspose.Slides**, puedes [comprar una licencia](https://purchase.aspose.com/buy). Te recomendamos que revises los diferentes tipos de suscripción. Si tienes preguntas, contacta al equipo de ventas de Aspose.

Todas las licencias de Aspose incluyen una suscripción de un año para actualizaciones gratuitas a nuevas versiones o correcciones publicadas dentro del periodo de suscripción. Los usuarios con productos con licencia o incluso versiones de evaluación obtienen soporte técnico gratuito e ilimitado.

{{% /alert %}} 

**Limitaciones de la versión de evaluación**

* Aunque la versión de evaluación de Aspose.Slides (sin una licencia especificada) ofrece la funcionalidad completa del producto, inserta una marca de agua de evaluación en la parte superior del documento al abrirlo y guardarlo. 
* Solo puedes extraer texto de una diapositiva.

{{% alert color="info" %}} 

Para probar Aspose.Slides sin limitaciones, puedes solicitar una **licencia temporal de 30 días**. Consulta la página [Cómo obtener una licencia temporal](https://purchase.aspose.com/temporary-license) para más información.

{{% /alert %}}

## **Licenciamiento en Aspose.Slides**
* Una versión de evaluación se licencía después de que compres una licencia y añadas un par de líneas de código (para aplicar la licencia).
* La licencia es un archivo XML de texto plano que contiene detalles como el nombre del producto, el número de desarrolladores a los que está licenciado, la fecha de caducidad de la suscripción, etc. 
* El archivo de licencia está firmado digitalmente, por lo que no debes modificarlo. Incluso la adición inadvertida de un salto de línea adicional invalida la licencia.
* Aspose.Slides for .NET normalmente busca la licencia en las siguientes ubicaciones:
  * Una ruta explícita
  * La carpeta que contiene el DLL del componente (incluido en Aspose.Slides)
  * La carpeta que contiene el ensamblado que llamó al DLL del componente (incluido en Aspose.Slides)
  * La carpeta que contiene el ensamblado principal (tu .exe)
  * Un recurso incrustado en el ensamblado que llamó al DLL del componente (incluido en Aspose.Slides).
* Para evitar las limitaciones asociadas a la versión de evaluación, debes establecer una licencia antes de usar Aspose.Slides. Solo tienes que establecer la licencia una vez por aplicación o proceso.

{{% alert color="info" %}} 

Puede que quieras consultar [Licenciamiento por consumo](https://docs.aspose.com/slides/es/net/metered-licensing/).

{{% /alert %}} 


## **Aplicar una licencia**
Una licencia puede cargarse desde un **archivo**, **flujo** o **recurso incrustado**. 

{{% alert color="info" %}}

Aspose.Slides proporciona la clase [License](https://reference.aspose.com/slides/es/net/aspose.slides/license) para operaciones de licenciamiento.

{{% /alert %}} 

{{% alert color="warning" %}} 

Las licencias nuevas pueden activar Aspose.Slides solo a partir de la versión 21.4 o posterior. Las versiones anteriores usan un sistema de licenciamiento diferente y no reconocerán estas licencias.

{{% /alert %}}

### **Archivo**
El método más sencillo para establecer una licencia consiste en colocar el archivo de licencia en la misma carpeta que contiene el DLL del componente (incluido en Aspose.Slides) y especificar solo el nombre del archivo sin su ruta.

Este código C# muestra cómo establecer un archivo de licencia:

``` csharp
// Instancia la clase License 
Aspose.Slides.License license = new Aspose.Slides.License();

// Establece la ruta del archivo de licencia
license.SetLicense("Aspose.Slides.lic");
```

{{% alert color="warning" %}} 

Si colocas el archivo de licencia en un directorio diferente, al llamar al método [SetLicense](https://reference.aspose.com/slides/es/net/aspose.slides/license/setlicense/#setlicense_1), el nombre del archivo de licencia al final de la ruta explícita debe coincidir con el nombre real de tu archivo de licencia.

Por ejemplo, puedes cambiar el nombre del archivo de licencia a *Aspose.Slides.lic.xml*. Entonces, en tu código, deberás pasar la ruta al archivo (terminada en *Aspose.Slides.lic.xml*) al método [SetLicense](https://reference.aspose.com/slides/es/net/aspose.slides/license/setlicense/#setlicense_1).

{{% /alert %}}

### **Flujo**
Puedes cargar una licencia desde un flujo. Este código C# muestra cómo aplicar una licencia desde un flujo:

``` csharp
// Instancia la clase License
Aspose.Slides.License license = new Aspose.Slides.License();

// Abre el archivo de licencia como un stream
using FileStream licenseStream = File.OpenRead("Aspose.Slides.lic");

// Establece la licencia mediante un stream
license.SetLicense(licenseStream);
```

### **Recurso incrustado**
Puedes empaquetar la licencia con tu aplicación (para evitar perderla) añadiendo la licencia como recurso incrustado en uno de los ensamblados que llaman al DLL del componente (incluido en Aspose.Slides). 

Así es como añades un archivo de licencia como recurso incrustado:

1. En Visual Studio, añade el archivo de licencia (.lic) al proyecto de esta forma: **Archivo** > **Agregar elemento existente** > **Agregar**. 
2. Selecciona el archivo en el **Explorador de soluciones**.
3. En la ventana de **Propiedades**, establece **Acción de compilación** a **Recurso incrustado**.
4. Para acceder a la licencia incrustada en el ensamblado, agrega el archivo de licencia como recurso incrustado al proyecto y luego pasa el nombre del archivo de licencia al método `SetLicense`. 


La clase `License` encuentra automáticamente el archivo de licencia en los recursos incrustados. No necesitas llamar a los métodos `GetExecutingAssembly` y `GetManifestResourceStream` de la clase `System.Reflection.Assembly` en el Microsoft .NET Framework.

Este código C# muestra cómo establecer una licencia como recurso incrustado:

``` csharp
// Instancia la clase License
Aspose.Slides.License license = new Aspose.Slides.License();

// Pasa el nombre del archivo de licencia incrustado en el ensamblado
license.SetLicense("Aspose.Slides.lic");
```

## **Validar una licencia**

Para comprobar si una licencia se ha establecido correctamente, puedes validarla. Este código C# muestra cómo validar una licencia:

```c#
Aspose.Slides.License license = new Aspose.Slides.License();

license.SetLicense("Aspose.Slides.lic");

if (license.IsLicensed())
{
    Console.WriteLine("License is good!");
    Console.Read();
}
```

## **Seguridad en entornos multi‑hilo**

{{% alert title="Nota" color="warning" %}} 

El método [license.SetLicense](https://reference.aspose.com/slides/es/net/aspose.slides/license/setlicense/) no es seguro para su uso simultáneo en varios hilos. Si este método debe llamarse simultáneamente desde muchos hilos, conviene usar primitivas de sincronización (como un bloqueo) para evitar problemas. 

{{% /alert %}}

## **Preguntas frecuentes**

### ¿Puedo aplicar la licencia en un entorno completamente fuera de línea (sin acceso a Internet)?

Sí. La validación de la licencia se realiza localmente usando el archivo de licencia; no se necesita conexión a Internet.

### ¿Qué ocurre cuando expira la suscripción de un año? ¿Dejará de funcionar la biblioteca?

No. La licencia es perpetua: puedes seguir usando las versiones publicadas antes de la fecha de fin de tu suscripción; simplemente no podrás utilizar versiones más recientes sin renovar.