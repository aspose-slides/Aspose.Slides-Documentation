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
description: "Aplique, administre y solucione problemas de licencias en Aspose.Slides para .NET. Garantice acceso ininterrumpido a todas las funciones con nuestra guía paso a paso de licenciamiento."
---

## **Evaluar Aspose.Slides**

{{% alert color="primary" %}} 

Puede descargar una versión de evaluación de **Aspose.Slides for NET** desde [su página de descarga en NuGet](https://www.nuget.org/packages/Aspose.Slides.NET/). La versión de evaluación ofrece las mismas funcionalidades que la versión con licencia del producto. El paquete de evaluación es idéntico al paquete adquirido. La versión de evaluación simplemente se vuelve con licencia después de agregar unas cuantas líneas de código (para aplicar la licencia).

Una vez que esté satisfecho con su evaluación de **Aspose.Slides**, puede [comprar una licencia](https://purchase.aspose.com/buy). Recomendamos que revise los diferentes tipos de suscripción. Si tiene preguntas, contacte al equipo de ventas de Aspose.

Cada licencia de Aspose incluye una suscripción de un año para actualizaciones gratuitas a nuevas versiones o correcciones lanzadas durante el período de suscripción. Los usuarios con productos con licencia o incluso versiones de evaluación obtienen soporte técnico gratuito e ilimitado.

{{% /alert %}} 

**Limitaciones de la versión de evaluación**

* Aunque la versión de evaluación de Aspose.Slides (sin una licencia especificada) brinda la funcionalidad completa del producto, inserta una marca de agua de evaluación en la parte superior del documento al abrirlo y guardarlo. 
* Está limitado a una diapositiva al extraer texto de las diapositivas de la presentación.

{{% alert color="primary" %}} 

Para probar Aspose.Slides sin limitaciones, puede solicitar una **Licencia Temporal de 30 Días**. Consulte la página [Cómo obtener una Licencia Temporal](https://purchase.aspose.com/temporary-license) para más información.

{{% /alert %}}

## **Licenciamiento en Aspose.Slides**
* Una versión de evaluación se convierte en con licencia después de comprar una licencia y agregar un par de líneas de código (para aplicar la licencia).
* La licencia es un archivo XML de texto plano que contiene detalles como el nombre del producto, el número de desarrolladores a los que está licenciada, la fecha de expiración de la suscripción, etc. 
* El archivo de licencia está firmado digitalmente, por lo que no debe modificarse. Incluso la adición inadvertida de una línea en blanco extra al contenido del archivo lo invalidará.
* Aspose.Slides para .NET normalmente busca la licencia en las siguientes ubicaciones:
  * Una ruta explícita
  * La carpeta que contiene el dll del componente (incluido en Aspose.Slides)
  * La carpeta que contiene el ensamblado que llamó al dll del componente (incluido en Aspose.Slides)
  * La carpeta que contiene el ensamblado de entrada (su .exe)
  * Un recurso incrustado en el ensamblado que llamó al dll del componente (incluido en Aspose.Slides).
* Para evitar las limitaciones asociadas con la versión de evaluación, debe establecer una licencia antes de usar Aspose.Slides. Solo necesita establecer la licencia una vez por aplicación o proceso.

{{% alert color="primary" %}} 

Es posible que desee ver [Licenciamiento Medido](https://docs.aspose.com/slides/net/metered-licensing/).

{{% /alert %}} 


## **Aplicar una Licencia**
Una licencia puede cargarse desde un **archivo**, **flujo**, o **recurso incrustado**. 

{{% alert color="primary" %}}

Aspose.Slides proporciona la clase [License](https://reference.aspose.com/slides/net/aspose.slides/license) para operaciones de licenciamiento.

{{% /alert %}} 

{{% alert color="warning" %}} 

Las licencias nuevas pueden activar Aspose.Slides solo con la versión 21.4 o posterior. Las versiones anteriores usan un sistema de licenciamiento diferente y no reconocerán estas licencias.

{{% /alert %}}

### **Archivo**
El método más sencillo para establecer una licencia requiere colocar el archivo de licencia en la misma carpeta que contiene el DLL del componente (incluido en Aspose.Slides) y especificar solo el nombre del archivo sin su ruta.

Este código C# le muestra cómo establecer un archivo de licencia:
``` csharp
// Instancia la clase License 
Aspose.Slides.License license = new Aspose.Slides.License();

// Establece la ruta del archivo de licencia
license.SetLicense("Aspose.Slides.lic");
```


{{% alert color="warning" %}} 

Si coloca el archivo de licencia en un directorio diferente, al llamar al método [SetLicense](https://reference.aspose.com/slides/net/aspose.slides/license/setlicense/#setlicense_1), el nombre del archivo de licencia al final de la ruta explícita especificada debe ser el mismo que su archivo de licencia.

Por ejemplo, puede cambiar el nombre del archivo de licencia a *Aspose.Slides.lic.xml*. Entonces, en su código, debe pasar la ruta al archivo (terminando con *Aspose.Slides.lic.xml*) al método [SetLicense](https://reference.aspose.com/slides/net/aspose.slides/license/setlicense/#setlicense_1).

{{% /alert %}}

### **Flujo**
Puede cargar una licencia desde un flujo. Este código C# le muestra cómo aplicar una licencia desde un flujo:
``` csharp
// Instancia la clase License 
Aspose.Slides.License license = new Aspose.Slides.License();

// Establece la licencia a través de un flujo
license.SetLicense(myStream);
```


### **Recurso Incrustado**
Puede empaquetar la licencia con su aplicación (para evitar perderla) agregando la licencia como un recurso incrustado en uno de los ensamblados que llaman al DLL del componente (incluido en Aspose.Slides). 

Así es como agrega un archivo de licencia como recurso incrustado:

1. En Visual Studio, agregue el archivo de licencia (.lic) al proyecto de la siguiente manera: Vaya a **File** > **Add Existing Item** > **Add**. 
2. Seleccione el archivo en el **Solution Explorer**.
3. En la ventana **Properties**, establezca **Build Action** a **Embedded Resource**.
4. Para acceder a la licencia incrustada en el ensamblado, agregue el archivo de licencia como recurso incrustado al proyecto y luego pase el nombre del archivo de licencia al método `SetLicense`. 


La clase `License` encuentra automáticamente el archivo de licencia en los recursos incrustados. No necesita llamar a los métodos `GetExecutingAssembly` y `GetManifestResourceStream` de la clase `System.Reflection.Assembly` en el Microsoft .NET Framework.

Este código C# le muestra cómo establecer una licencia como recurso incrustado:
``` csharp
// Instancia la clase License
Aspose.Slides.License license = new Aspose.Slides.License();

// Pasa el nombre del archivo de licencia incrustado en el ensamblado
license.SetLicense("Aspose.Slides.lic");
```


## **Validar una Licencia**

Para verificar si una licencia se ha establecido correctamente, puede validarla. Este código C# le muestra cómo validar una licencia:
```c#
Aspose.Slides.License license = new Aspose.Slides.License();

license.SetLicense("Aspose.Slides.lic");

if (license.IsLicensed())
{
    Console.WriteLine("License is good!");
    Console.Read();
}
```


## **Seguridad en Hilos**

{{% alert title="Note" color="warning" %}} 

El método [license.SetLicense](https://reference.aspose.com/slides/net/aspose.slides/license/setlicense/) no es seguro para hilo. Si este método debe llamarse simultáneamente desde muchos hilos, puede querer usar primitivas de sincronización (como un lock) para evitar problemas. 

{{% /alert %}}

## **Preguntas Frecuentes**

**¿Puedo aplicar la licencia en un entorno completamente desconectado (sin acceso a internet)?**

Sí. La validación de la licencia se realiza localmente usando el archivo de licencia; no se requiere conexión a internet.

**¿Qué ocurre cuando la suscripción de un año expira? ¿Dejará de funcionar la biblioteca?**

No. La licencia es perpetua: puede seguir usando las versiones lanzadas antes de la fecha de finalización de su suscripción; simplemente no será elegible para usar versiones más recientes sin renovar.