---
title: Licenciamiento
type: docs
weight: 90
url: /es/java/licensing/
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
- Java
- Aspose.Slides
description: "Aplicar, gestionar y solucionar problemas de licencias en Aspose.Slides para Java. Garantice acceso ininterrumpido a todas las funciones con nuestra guía paso a paso de licenciamiento."
---
## **Visión general**

Aspose.Slides puede usarse en modo de evaluación o con una licencia válida. La versión de evaluación ofrece la misma funcionalidad que la versión con licencia, pero añade una marca de agua de evaluación a cada diapositiva de cada presentación que guarda y trunca el texto que su código lee a través de la API.

Este artículo explica cómo funciona el licenciamiento en Aspose.Slides y cómo aplicar una licencia antes de usar la biblioteca. Una licencia puede cargarse desde un archivo, un stream o un recurso incrustado mediante la clase `License`. El artículo también muestra cómo validar si una licencia se ha aplicado correctamente.

## **Evaluar Aspose.Slides**

{{% alert color="info" title="Note" %}}

Puede descargar una versión de evaluación de **Aspose.Slides for Java** desde su [página de descarga](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). La versión de evaluación ofrece las mismas funcionalidades que la versión licenciada del producto. El paquete de evaluación es idéntico al paquete comprado. La versión de evaluación simplemente se convierte en licenciada después de añadir unas pocas líneas de código (para aplicar la licencia).

Una vez que esté satisfecho con su evaluación de **Aspose.Slides**, puede [adquirir una licencia](https://purchase.aspose.com/pricing/slides/java/). Le recomendamos que revise los diferentes tipos de suscripción. Si tiene preguntas, contacte con el equipo de ventas de Aspose.

Cada licencia de Aspose incluye una suscripción de un año para actualizaciones gratuitas a nuevas versiones o correcciones lanzadas durante el período de suscripción. Los usuarios con productos licenciados (o incluso versiones de evaluación) obtienen soporte técnico gratuito e ilimitado.

{{% /alert %}} 

**Limitaciones de la versión de evaluación**

* La versión de evaluación (sin una licencia especificada) proporciona la funcionalidad completa del producto, pero añade un cuadro de texto de marca de agua de evaluación a cada diapositiva de cada presentación que guarda.
* El texto que su código lee a través de la API, incluido el texto que acaba de establecer, se trunca a sus primeros caracteres, seguido de un aviso sobre la limitación de la evaluación. El texto que su código escribe se guarda completo.

{{% alert color="info" title="Note" %}}

Para probar Aspose.Slides sin limitaciones, puede solicitar una **Licencia Temporal de 30 días**. Consulte la página [Cómo obtener una Licencia Temporal](https://purchase.aspose.com/temporary-license) para más información.

{{% /alert %}}

## **Licenciamiento en Aspose.Slides**

* Una versión de evaluación se convierte en licenciada después de adquirir una licencia y añadir un par de líneas de código (para aplicar la licencia).
* La licencia es un archivo XML de texto plano que contiene datos como el nombre del producto, el número de desarrolladores a los que está licenciada, la fecha de expiración de la suscripción, etc.
* El archivo de licencia está firmado digitalmente, por lo que no debe modificarse. Incluso la adición inadvertida de un salto de línea extra al contenido del archivo lo invalidará.
* Aspose.Slides for Java intenta normalmente encontrar la licencia en las siguientes ubicaciones:
  * Una ruta explícita
  * La carpeta que contiene Aspose.Slides.jar
* Para evitar las limitaciones asociadas a la versión de evaluación, debe establecer una licencia antes de usar **Aspose.Slides**. Sólo tiene que establecer la licencia una vez por aplicación o proceso.

{{% alert color="info" title="Note" %}}

Puede que desee consultar [Licenciamiento por Medición](/slides/es/java/metered-licensing/).

{{% /alert %}} 


## **Aplicar una licencia**

Una licencia puede cargarse desde un **archivo** o **stream**.

{{% alert color="info" title="Note" %}}

Aspose.Slides proporciona la clase [License](https://reference.aspose.com/slides/java/com.aspose.slides/license/) para operaciones de licenciamiento.

{{% /alert %}} 

{{% alert color="warning" title="Warning" %}}

Las licencias nuevas pueden activar Aspose.Slides solo con la versión 21.4 o posterior. Las versiones anteriores usan un sistema de licenciamiento diferente y no reconocerán estas licencias.

{{% /alert %}}

### **Archivo**

El método más sencillo para establecer una licencia consiste en colocar el archivo de licencia en la carpeta que contiene Aspose.Slides.jar o el jar de su aplicación.

Este código Java le muestra cómo establecer un archivo de licencia:

``` java
// Instancia la clase License
com.aspose.slides.License license = new com.aspose.slides.License();

// Establece la ruta del archivo de licencia
license.setLicense("Aspose.Slides.Java.lic");
```

{{% alert color="warning" title="Warning" %}}

Si coloca el archivo de licencia en un directorio distinto, al llamar al método [setLicense](https://reference.aspose.com/slides/java/com.aspose.slides/license/#setLicense-java.lang.String-) el nombre del archivo de licencia al final de la ruta especificada debe coincidir con el nombre de su archivo de licencia.

Por ejemplo, puede cambiar el nombre del archivo de licencia a *Aspose.Slides.Java.lic.xml*. Entonces, en su código, debe pasar la ruta al archivo (terminando con *Aspose.Slides.Java.lic.xml*) al método [setLicense](https://reference.aspose.com/slides/java/com.aspose.slides/license/#setLicense-java.lang.String-).

{{% /alert %}}

### **Stream**

Puede cargar una licencia desde un stream. Este código Java le muestra cómo aplicar una licencia desde un stream:

``` java
// Instancia la clase License
com.aspose.slides.License license = new com.aspose.slides.License();

// Establece la licencia a través de un stream
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Java.lic"));
```

### **PHP/Java Bridge**

Si utiliza Aspose.Slides for PHP a través de Java, puede establecer una licencia mediante un puente PHP/Java. Este puente le permite usar clases Java con sintaxis PHP. Para más información, consulte [Licencia en PHP](/slides/es/php-java/licensing/).

## **Validar una licencia**

Para comprobar si una licencia se ha configurado correctamente, puede validarla. Este código Java le muestra cómo validar una licencia:

```java
import com.aspose.slides.*;

License license = new License();
license.setLicense("Aspose.Slides.Java.lic");

if (license.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **Seguridad en hilos**

{{% alert color="warning" title="Warning" %}}

El método [setLicense](https://reference.aspose.com/slides/java/com.aspose.slides/license/#setLicense-java.io.InputStream-) no es seguro para hilos. Si este método debe llamarse simultáneamente desde varios hilos, quizás desee usar primitivas de sincronización (como un bloqueo) para evitar problemas.

{{% /alert %}}

## **FAQ**

### ¿Puedo aplicar la licencia en un entorno completamente offline (sin acceso a internet)?

Sí. La validación de la licencia se realiza localmente usando el archivo de licencia; no se requiere conexión a internet.

### ¿Qué ocurre después de que expira la suscripción de un año? ¿La biblioteca deja de funcionar?

No. La licencia es perpetua: puede seguir usando las versiones publicadas antes de la fecha de finalización de su suscripción; simplemente no podrá utilizar versiones más recientes sin renovar.