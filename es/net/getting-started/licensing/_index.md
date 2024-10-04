---
title: Licenciamiento
type: docs
weight: 80
url: /es/net/licensing/
---

## **Evaluar Aspose.Slides**

{{% alert color="primary" %}} 

Puedes descargar una versión de evaluación de **Aspose.Slides para .NET** desde [su página de descarga de NuGet](https://www.nuget.org/packages/Aspose.Slides.NET/). La versión de evaluación proporciona las mismas funcionalidades que la versión licenciada del producto. El paquete de evaluación es el mismo que el paquete comprado. La versión de evaluación simplemente se convierte en licenciada después de que agregues unas pocas líneas de código para aplicarla (para aplicar la licencia).

Una vez que estés satisfecho con tu evaluación de **Aspose.Slides**, puedes [comprar una licencia](https://purchase.aspose.com/buy). Te recomendamos que revises los diferentes tipos de suscripción. Si tienes preguntas, contacta al equipo de ventas de Aspose.

Cada licencia de Aspose viene con una suscripción de un año para actualizaciones gratuitas a nuevas versiones o correcciones lanzadas dentro del período de suscripción. Los usuarios con productos licenciados o incluso versiones de evaluación obtienen soporte técnico gratuito e ilimitado.

{{% /alert %}} 

**Limitaciones de la versión de evaluación**

* Mientras que la versión de evaluación de Aspose.Slides (sin una licencia especificada) proporciona la funcionalidad completa del producto, inserta una marca de agua de evaluación en la parte superior del documento al abrir y guardar operaciones.
* Estás limitado a una diapositiva al extraer textos de las diapositivas de presentación.

{{% alert color="primary" %}} 

Para probar Aspose.Slides sin limitaciones, puedes solicitar una **Licencia Temporal de 30 Días**. Consulta la página [Cómo obtener una Licencia Temporal](https://purchase.aspose.com/temporary-license) para más información.

{{% /alert %}}

## **Licenciamiento en Aspose.Slides**
* Una versión de evaluación se convierte en licenciada después de que compras una licencia y agregas un par de líneas de código para aplicarla (para aplicar la licencia).
* La licencia es un archivo XML de texto plano que contiene detalles como el nombre del producto, el número de desarrolladores a los que está licenciada, la fecha de vencimiento de la suscripción, etc.
* El archivo de licencia está firmado digitalmente, por lo que no debes modificar el archivo. Incluso una adición inadvertida de un salto de línea adicional al contenido del archivo lo invalidará.
* Aspose.Slides para .NET intenta encontrar la licencia típicamente en estas ubicaciones:
  * Un camino explícito
  * La carpeta que contiene el dll del componente (incluido en Aspose.Slides)
  * La carpeta que contiene el ensamblado que llamó al dll del componente (incluido en Aspose.Slides)
  * La carpeta que contiene el ensamblado de entrada (tu .exe)
  * Un recurso embebido en el ensamblado que llamó al dll del componente (incluido en Aspose.Slides).
* Para evitar las limitaciones asociadas con la versión de evaluación, necesitas establecer una licencia antes de usar Aspose.Slides. Solo tienes que establecer una licencia una vez por aplicación o proceso.

{{% alert color="primary" %}} 

Es posible que desees ver [Licenciamiento Medido](https://docs.aspose.com/slides/net/metered-licensing/).

{{% /alert %}} 

## **Aplicando una Licencia**
Una licencia puede ser cargada desde un **archivo**, **flujo** o **recurso embebido**. 

{{% alert color="primary" %}}

Aspose.Slides proporciona la clase [Licencia](https://reference.aspose.com/slides/net/aspose.slides/license) para operaciones de licenciamiento.

{{% /alert %}} 

### **Archivo**
El método más fácil de establecer una licencia requiere que coloques el archivo de licencia en la misma carpeta que contiene el DLL del componente (incluido en Aspose.Slides) y especifiques solo el nombre del archivo sin su ruta.

Este código C# te muestra cómo establecer un archivo de licencia:

``` csharp
// Instancia la clase Licencia 
Aspose.Slides.License license = new Aspose.Slides.License();

// Establece la ruta del archivo de licencia
license.SetLicense("Aspose.Slides.lic");
```

{{% alert color="warning" %}} 

Si colocas el archivo de licencia en un directorio diferente, cuando llames al método [SetLicense](https://reference.aspose.com/slides/net/aspose.slides/license/setlicense/#setlicense_1), el nombre del archivo de licencia al final del explícito especificado debe ser el mismo que tu archivo de licencia.

Por ejemplo, puedes cambiar el nombre del archivo de licencia a *Aspose.Slides.lic.xml*. Luego, en tu código, debes pasar la ruta al archivo (que termine con *Aspose.Slides.lic.xml*) al método [SetLicense](https://reference.aspose.com/slides/net/aspose.slides/license/setlicense/#setlicense_1).

{{% /alert %}}

### **Flujo**
Puedes cargar una licencia desde un flujo. Este código C# te muestra cómo aplicar una licencia desde un flujo:

``` csharp
// Instancia la clase Licencia 
Aspose.Slides.License license = new Aspose.Slides.License();

// Establece la licencia a través de un flujo
license.SetLicense(myStream);
```

### **Recurso Embebido**
Puedes empaquetar la licencia con tu aplicación (para evitar perderla) agregando la licencia como un recurso embebido en uno de los ensamblados que llaman al DLL del componente (incluido en Aspose.Slides).

Así es como agregas un archivo de licencia como un recurso embebido:

1. En Visual Studio, agrega el archivo de licencia (.lic) al proyecto de esta manera: Ve a **Archivo** > **Agregar Elemento Existente** > **Agregar**.
2. Selecciona el archivo en el **Explorador de Soluciones**.
3. En la ventana de **Propiedades**, establece la **Acción de Compilación** en **Recurso Embebido**.
4. Para acceder a la licencia embebida en el ensamblado, agrega el archivo de licencia como un recurso embebido al proyecto y luego pasa el nombre del archivo de licencia al método `SetLicense`.

La clase `Licencia` encuentra automáticamente el archivo de licencia en los recursos embebidos. No necesitas llamar a los métodos `GetExecutingAssembly` y `GetManifestResourceStream` de la clase `System.Reflection.Assembly` en el Microsoft .NET Framework.

Este código C# te muestra cómo establecer una licencia como un recurso embebido:

``` csharp
// Instancia la clase Licencia
Aspose.Slides.License license = new Aspose.Slides.License();

// Pasa el nombre del archivo de licencia embebido en el ensamblado
license.SetLicense("Aspose.Slides.lic");
```

## **Validar una Licencia**

Para verificar si una licencia se ha establecido correctamente, puedes validarla. Este código C# te muestra cómo validar una licencia:

```csharp
Aspose.Slides.License license = new Aspose.Slides.License();

license.SetLicense("Aspose.Slides.lic");

if (license.IsLicensed())
{
    Console.WriteLine("¡La licencia es válida!");
    Console.Read();
}
```

## **Seguridad en Hilos**

{{% alert title="Nota" color="warning" %}} 

El método [license.SetLicense](https://reference.aspose.com/slides/net/aspose.slides/license/setlicense/) no es seguro para hilos. Si este método tiene que ser llamado simultáneamente desde muchos hilos, puede que quieras usar primitivas de sincronización (como un bloqueo) para evitar problemas. 

{{% /alert %}}