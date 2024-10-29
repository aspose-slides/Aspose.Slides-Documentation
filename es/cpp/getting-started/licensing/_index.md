---
title: Licencias
type: docs
weight: 120
url: /es/cpp/licensing/
---

## **Evaluar Aspose.Slides**

{{% alert color="primary" %}} 

Puedes descargar una versión de evaluación de **Aspose.Slides for C++** desde [su página de descarga de NuGet](https://www.nuget.org/packages/Aspose.Slides.CPP/). La versión de evaluación ofrece las mismas funcionalidades que la versión licenciada del producto. El paquete de evaluación es el mismo que el paquete comprado. La versión de evaluación simplemente se convierte en licenciada después de que agregues algunas líneas de código (para aplicar la licencia).

Una vez que estés satisfecho con tu evaluación de **Aspose.Slides**, puedes [comprar una licencia](https://purchase.aspose.com/buy). Te recomendamos revisar los diferentes tipos de suscripción. Si tienes preguntas, contacta al equipo de ventas de Aspose.

Cada licencia de Aspose viene con un año de suscripción para actualizaciones gratuitas a nuevas versiones o correcciones lanzadas dentro del período de suscripción. Los usuarios con productos licenciados o incluso versiones de evaluación obtienen soporte técnico gratuito e ilimitado.

{{% /alert %}} 

**Limitaciones de la versión de evaluación**

* Mientras que la versión de evaluación de Aspose.Slides (sin una licencia especificada) proporciona funcionalidad completa del producto, inserta una marca de agua de evaluación en la parte superior del documento en las operaciones de apertura y guardado. 
* Estás limitado a una diapositiva al extraer textos de las diapositivas de la presentación.

{{% alert color="primary" %}} 

Para probar Aspose.Slides sin limitaciones, puedes solicitar una **Licencia Temporal de 30 Días**. Consulta la página [Cómo obtener una Licencia Temporal](https://purchase.aspose.com/temporary-license) para más información.

{{% /alert %}}

## **Licenciamiento en Aspose.Slides**

* Una versión de evaluación se convierte en licenciada después de que compras una licencia y agregas un par de líneas de código (para aplicar la licencia).
* La licencia es un archivo XML de texto plano que contiene detalles como el nombre del producto, el número de desarrolladores a los que está licenciada, la fecha de caducidad de la suscripción, etc.
* El archivo de licencia está firmado digitalmente, por lo que no debes modificar el archivo. Incluso una adición inadvertida de un salto de línea extra al contenido del archivo lo invalidará.
* Aspose.Slides para C++ normalmente intenta encontrar la licencia en estas ubicaciones:
  * Un camino explícito
  * La carpeta que contiene el DLL del componente (incluido en Aspose.Slides)
  * La carpeta que contiene el ensamblaje que llama al DLL del componente (incluido en Aspose.Slides)
* Para evitar las limitaciones asociadas con la versión de evaluación, necesitas establecer una licencia antes de usar Aspose.Slides. Solo tienes que establecer una licencia una vez por aplicación o proceso.

## **Aplicar una Licencia**

Una licencia puede ser cargada desde un **archivo**, **flujo** o **recurso incrustado**. 

{{% alert color="primary" %}}

Aspose.Slides proporciona la clase [License](https://reference.aspose.com/slides/cpp/class/aspose.slides.license/) para operaciones de licenciamiento.

{{% /alert %}} 

### **Archivo**

El método más fácil para establecer una licencia requiere que coloques el archivo de licencia en la misma carpeta que contiene el DLL del componente (incluido en Aspose.Slides) y especifiques el nombre del archivo sin su ruta.

Este código C++ te muestra cómo establecer un archivo de licencia:

```c++
SharedPtr<Aspose::Slides::License> lic = MakeObject<Aspose::Slides::License>();

lic->SetLicense(L"Aspose.Slides.lic");
```

{{% alert color="warning" %}} 

Si colocas el archivo de licencia en un directorio diferente, al llamar al método [License::SetLicense()](https://reference.aspose.com/slides/cpp/class/aspose.slides.license#a44102d1d52a5e45643345448b1814a67), el nombre del archivo de licencia al final de la especificación explícita debe ser el mismo que tu archivo de licencia.

Por ejemplo, puedes cambiar el nombre del archivo de licencia a *Aspose.Slides.lic.xml*. Luego, en tu código, debes pasar la ruta al archivo (terminando con *Aspose.Slides.lic.xml*) al método [License::SetLicense()](https://reference.aspose.com/slides/cpp/class/aspose.slides.license#a44102d1d52a5e45643345448b1814a67).

{{% /alert %}}

### **Flujo**

Puedes cargar una licencia desde un flujo. Este código C++ te muestra cómo aplicar una licencia desde un flujo:

```c++
SharedPtr<Aspose::Slides::License> lic = MakeObject<Aspose::Slides::License>();

System::SharedPtr<System::IO::FileStream> stream= System::IO::File::OpenRead(L"Aspose.Slides.lic");

lic->SetLicense(stream); 
```

## **Validar una Licencia**

Para verificar si una licencia se ha establecido correctamente, puedes validarla. Este código C++ te muestra cómo validar una licencia:

```c++
System::SharedPtr<Aspose::Slides::License> license = System::MakeObject<Aspose::Slides::License>();
license->SetLicense(u"Aspose.Slides.lic");
if (license->IsLicensed())
{
    System::Console::WriteLine(u"¡La licencia es válida!");
    System::Console::Read();
}
```

## **Seguridad en Hilos**

{{% alert title="Nota" color="warning" %}} 

El método [License::SetLicense()](https://reference.aspose.com/slides/cpp/class/aspose.slides.license#a44102d1d52a5e45643345448b1814a67) no es seguro para hilos. Si este método tiene que ser llamado simultáneamente desde muchos hilos, es posible que desees usar primitivas de sincronización (como un bloqueo) para evitar problemas. 

{{% /alert %}}