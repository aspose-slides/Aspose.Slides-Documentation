---
title: Licenciamiento
type: docs
weight: 90
url: /es/androidjava/licensing/
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
- Android
- Java
- Aspose.Slides
description: "Aplicar, gestionar y solucionar problemas de licencias en Aspose.Slides para Android mediante Java. Garantiza un acceso continuo a todas las funciones con nuestra guía de licenciamiento."
---
## **Visión general**

Aspose.Slides puede usarse en modo de evaluación o con una licencia válida. La versión de evaluación brinda la misma funcionalidad que la versión con licencia, pero añade una marca de agua de evaluación cuando se abren o guardan presentaciones y limita la extracción de texto a una sola diapositiva.

Este artículo explica cómo funciona el licenciamiento en Aspose.Slides y cómo aplicar una licencia antes de usar la biblioteca. Una licencia puede cargarse desde un archivo, un flujo o un recurso incrustado mediante la clase `License`. El artículo también muestra cómo validar si una licencia se ha aplicado correctamente.

## **Evaluar Aspose.Slides**

{{% alert color="info" %}} 

Puedes descargar una versión de evaluación de **Aspose.Slides for Android via Java** desde su [página de descarga](https://releases.aspose.com/slides/es/androidjava/). La versión de evaluación ofrece las mismas funcionalidades que la versión con licencia del producto. El paquete de evaluación es idéntico al paquete adquirido. La versión de evaluación simplemente se convierte en licenciada después de añadir unas pocas líneas de código (para aplicar la licencia).

Una vez que estés satisfecho con tu evaluación de **Aspose.Slides**, puedes [comprar una licencia](https://purchase.aspose.com/buy). Te recomendamos que revises los diferentes tipos de suscripción. Si tienes preguntas, contacta al equipo de ventas de Aspose.

Cada licencia de Aspose incluye una suscripción de un año para actualizaciones gratuitas a nuevas versiones o correcciones publicadas dentro del período de suscripción. Los usuarios con productos licenciados (o incluso versiones de evaluación) obtienen soporte técnico gratuito e ilimitado.

{{% /alert %}} 

**Limitaciones de la versión de evaluación**

* Mientras la versión de evaluación de Aspose.Slides (sin especificar una licencia) proporciona la funcionalidad completa del producto, inserta una marca de agua de evaluación en la parte superior del documento al abrirlo o guardarlo. 
* Se limita a una diapositiva la extracción de texto de las presentaciones.

{{% alert color="info" %}} 

Para probar Aspose.Slides sin limitaciones, puedes solicitar una **Licencia temporal de 30 días**. Consulta la página de [Cómo obtener una licencia temporal](https://purchase.aspose.com/temporary-license) para más información.

{{% /alert %}}

## **Licenciamiento en Aspose.Slides**

* Una versión de evaluación se convierte en licenciada después de comprar una licencia y añadir un par de líneas de código (para aplicar la licencia).
* La licencia es un archivo XML de texto sin formato que contiene detalles como el nombre del producto, el número de desarrolladores a los que está licenciada, la fecha de expiración de la suscripción, etc. 
* El archivo de licencia está firmado digitalmente, por lo que no debes modificarlo. Incluso la adición accidental de un salto de línea extra al contenido del archivo lo invalidará.
* Aspose.Slides for Android via Java normalmente busca la licencia en estas ubicaciones:
  * Una ruta explícita
  * La carpeta que contiene Aspose.Slides.jar
* Para evitar las limitaciones asociadas con la versión de evaluación, necesitas establecer una licencia antes de usar **Aspose.Slides**. Sólo tienes que establecer una licencia una vez por aplicación o proceso.

## **Aplicar una licencia**

Una licencia puede cargarse desde un **archivo** o un **flujo**.

{{% alert color="info" %}}

Aspose.Slides proporciona la clase [License](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/license/) para operaciones de licenciamiento.

{{% /alert %}} 

{{% alert color="warning" %}}

Las licencias nuevas pueden activar Aspose.Slides solo con la versión 21.4 o posterior. Las versiones anteriores usan un sistema de licenciamiento diferente y no reconocerán estas licencias.

{{% /alert %}}

### **Archivo**

El método más sencillo de establecer una licencia requiere que coloques el archivo de licencia en la carpeta que contiene Aspose.Slides.jar o el jar de tu aplicación.

Este código Java muestra cómo establecer un archivo de licencia:

``` java
// Instancia la clase License
com.aspose.slides.License license = new com.aspose.slides.License();

// Establece la ruta del archivo de licencia
license.setLicense("Aspose.Slides.Android.via.Java.lic");
```

{{% alert color="warning" %}} 

Si colocas el archivo de licencia en un directorio diferente, al llamar al método [SetLicense](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-) el nombre del archivo de licencia al final de la ruta explícita debe ser el mismo que el de tu archivo de licencia.

Por ejemplo, puedes cambiar el nombre del archivo de licencia a *Aspose.Slides.Android.via.Java.lic.xml*. Entonces, en tu código, debes pasar la ruta al archivo (terminando con *Aspose.Slides.Android.via.Java.lic.xml*) al método [SetLicense](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-).

{{% /alert %}}

### **Flujo**

Puedes cargar una licencia desde un flujo. Este código Java muestra cómo aplicar una licencia desde un flujo:

``` java
// Instancia la clase License
com.aspose.slides.License license = new com.aspose.slides.License();

// Establece la licencia mediante un flujo
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Android.via.Java.lic"));
```

## **Validar una licencia**

Para comprobar si una licencia se ha configurado correctamente, puedes validarla. Este código Java muestra cómo validar una licencia:

```java
import com.aspose.slides.*;

License license = new License();
license.setLicense("Aspose.Slides.Android.via.Java.lic");

if (license.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **Seguridad en subprocesos**

{{% alert title="Note" color="warning" %}} 

El método [SetLicense](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-) no es seguro para subprocesos. Si este método debe llamarse simultáneamente desde varios subprocesos, quizá quieras usar primitivas de sincronización (como un bloqueo) para evitar problemas. 

{{% /alert %}}

## **Preguntas frecuentes**

### ¿Puedo aplicar la licencia en un entorno totalmente offline (sin acceso a internet)?

Sí. La validación de la licencia se realiza localmente usando el archivo de licencia; no se requiere conexión a internet.

### ¿Qué ocurre después de que expira la suscripción de un año? ¿Dejará de funcionar la biblioteca?

No. La licencia es perpetua: puedes seguir usando las versiones publicadas antes de la fecha de finalización de tu suscripción; simplemente no podrás utilizar versiones más recientes sin renovar.