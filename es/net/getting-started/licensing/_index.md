---
title: Licenciamiento
type: docs
weight: 80
url: /es/net/licensing/
---

## **Evaluar Aspose.Slides**

{{% alert color="primary" %}} 

Puede descargar una versión de evaluación de **Aspose.Slides for NET** desde la [página de descarga de NuGet](https://www.nuget.org/packages/Aspose.Slides.NET/). La versión de evaluación proporciona las mismas funcionalidades que la versión licenciada del producto. El paquete de evaluación es idéntico al paquete comprado. La versión de evaluación simplemente se licencia después de que añada unas pocas líneas de código (para aplicar la licencia).

Una vez que esté satisfecho con su evaluación de **Aspose.Slides**, puede [comprar una licencia](https://purchase.aspose.com/buy). Le recomendamos que revise los diferentes tipos de suscripción. Si tiene preguntas, contacte al equipo de ventas de Aspose.

Cada licencia de Aspose incluye una suscripción de un año para actualizaciones gratuitas a nuevas versiones o correcciones publicadas dentro del período de suscripción. Los usuarios con productos licenciados o incluso con versiones de evaluación reciben soporte técnico gratuito e ilimitado.

{{% /alert %}} 

## **Limitaciones de la versión de evaluación**

* Aunque la versión de evaluación de Aspose.Slides (sin una licencia especificada) ofrece la funcionalidad completa del producto, inserta una marca de agua de evaluación en la parte superior del documento al abrirlo y guardarlo. 
* Está limitado a una diapositiva al extraer texto de las diapositivas de la presentación.

{{% alert color="primary" %}} 

Para probar Aspose.Slides sin limitaciones, puede solicitar una **Licencia Temporal de 30 Días**. Consulte la página [Cómo obtener una Licencia Temporal](https://purchase.aspose.com/temporary-license) para obtener más información.

{{% /alert %}}

## **Licenciamiento en Aspose.Slides**
* Una versión de evaluación se licencia después de que compre una licencia y añada un par de líneas de código (para aplicar la licencia).
* La licencia es un archivo XML de texto plano que contiene detalles como el nombre del producto, el número de desarrolladores a los que está licenciada, la fecha de vencimiento de la suscripción, etc. 
* El archivo de licencia está firmado digitalmente, por lo que no debe modificarlo. Incluso la adición involuntaria de una línea extra al contenido del archivo lo invalidará.
* Aspose.Slides for .NET normalmente intenta encontrar la licencia en las siguientes ubicaciones:
  * Una ruta explícita
  * La carpeta que contiene el dll del componente (incluido en Aspose.Slides)
  * La carpeta que contiene el ensamblado que llamó al dll del componente (incluido en Aspose.Slides)
  * La carpeta que contiene el ensamblado de entrada (su .exe)
  * Un recurso incrustado en el ensamblado que llamó al dll del componente (incluido en Aspose.Slides).
* Para evitar las limitaciones asociadas con la versión de evaluación, debe establecer una licencia antes de usar Aspose.Slides. Sólo necesita establecer la licencia una vez por aplicación o proceso.

{{% alert color="primary" %}} 

Quizá quiera ver [Licenciamiento por Métricas](https://docs.aspose.com/slides/net/metered-licensing/).

{{% /alert %}} 


## **Aplicar una licencia**
Una licencia puede cargarse desde un **archivo**, **flujo** o **recurso incrustado**. 

{{% alert color="primary" %}}

Aspose.Slides proporciona la clase [License](https://reference.aspose.com/slides/net/aspose.slides/license) para operaciones de licenciamiento.

{{% /alert %}} 

{{% alert color="warning" %}} 

Las licencias nuevas pueden activar Aspose.Slides solo con la versión 21.4 o posterior. Las versiones anteriores utilizan un sistema de licenciamiento diferente y no reconocerán estas licencias.

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


{{% alert color="warning" %}} 

Si coloca el archivo de licencia en un directorio diferente, al llamar al método [SetLicense](https://reference.aspose.com/slides/net/aspose.slides/license/setlicense/#setlicense_1), el nombre del archivo de licencia al final de la ruta explícita especificada debe ser el mismo que su archivo de licencia.

Por ejemplo, puede cambiar el nombre del archivo de licencia a *Aspose.Slides.lic.xml*. Entonces, en su código, debe pasar la ruta al archivo (terminada con *Aspose.Slides.lic.xml*) al método [SetLicense](https://reference.aspose.com/slides/net/aspose.slides/license/setlicense/#setlicense_1).

{{% /alert %}}

### **Flujo**
Puede cargar una licencia desde un flujo. Este código C# le muestra cómo aplicar una licencia desde un flujo:
``` csharp
// Instancia la clase License 
Aspose.Slides.License license = new Aspose.Slides.License();

// Establece la licencia mediante un flujo
license.SetLicense(myStream);
```


### **Recurso incrustado**
Puede empaquetar la licencia con su aplicación (para evitar perderla) añadiendo la licencia como un recurso incrustado en uno de los ensamblados que llaman al DLL del componente (incluido en Aspose.Slides). 

Así es como agrega un archivo de licencia como recurso incrustado:

1. En Visual Studio, agregue el archivo de licencia (.lic) al proyecto de esta manera: Vaya a **Archivo** > **Agregar elemento existente** > **Agregar**. 
2. Seleccione el archivo en el **Explorador de soluciones**.
3. En la ventana **Propiedades**, establezca la **Acción de compilación** a **Recurso incrustado**.
4. Para acceder a la licencia incrustada en el ensamblado, agregue el archivo de licencia como recurso incrustado al proyecto y luego pase el nombre del archivo de licencia al método `SetLicense`. 


La clase `License` encuentra automáticamente el archivo de licencia en los recursos incrustados. No es necesario llamar a los métodos `GetExecutingAssembly` y `GetManifestResourceStream` de la clase `System.Reflection.Assembly` en el Microsoft .NET Framework.

Este código C# le muestra cómo establecer una licencia como recurso incrustado:
``` csharp
// Instancia la clase License
Aspose.Slides.License license = new Aspose.Slides.License();

// Pasa el nombre del archivo de licencia incrustado en el ensamblado
license.SetLicense("Aspose.Slides.lic");
```


## **Validar una licencia**

Para comprobar si una licencia se ha establecido correctamente, puede validarla. Este código C# le muestra cómo validar una licencia:
```c#
Aspose.Slides.License license = new Aspose.Slides.License();

license.SetLicense("Aspose.Slides.lic");

if (license.IsLicensed())
{
    Console.WriteLine("License is good!");
    Console.Read();
}
```


## **Seguridad en subprocesos**

{{% alert title="Note" color="warning" %}} 

El método [license.SetLicense](https://reference.aspose.com/slides/net/aspose.slides/license/setlicense/) no es seguro para subprocesos. Si este método debe llamarse simultáneamente desde varios subprocesos, puede que desee usar primitivas de sincronización (como un bloqueo) para evitar problemas. 

{{% /alert %}}

## **Preguntas frecuentes**

**¿Puedo aplicar la licencia en un entorno completamente offline (sin acceso a internet)?**

Sí. La validación de la licencia se realiza localmente usando el archivo de licencia; no se requiere conexión a internet.

**¿Qué ocurre después de que expira la suscripción de un año? ¿Dejará de funcionar la biblioteca?**

No. La licencia es perpetua: puede seguir usando las versiones publicadas antes de la fecha de fin de su suscripción; simplemente no podrá utilizar versiones más recientes sin renovarla.