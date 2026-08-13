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
description: "Aplicar, gestionar y solucionar problemas de licencias en Aspose.Slides para Java. Garantice acceso ininterrumpido a todas las funciones con nuestra guía paso a paso sobre licenciamiento."
---
## **Visión general**

Aspose.Slides puede usarse en modo de evaluación o con una licencia válida. La versión de evaluación ofrece la misma funcionalidad que la versión con licencia, pero añade una marca de agua de evaluación cuando se abren o guardan presentaciones y limita la extracción de texto a una diapositiva.

Este artículo explica cómo funciona la licencia en Aspose.Slides y cómo aplicar una licencia antes de usar la biblioteca. Una licencia puede cargarse desde un archivo, flujo o recurso incrustado mediante la clase `License`. El artículo también muestra cómo validar si una licencia se ha aplicado correctamente.

## **Evaluar Aspose.Slides**

{{% alert color="info" %}} 

Puede descargar una versión de evaluación de **Aspose.Slides for Java** desde su [página de descarga](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). La versión de evaluación proporciona las mismas funcionalidades que la versión con licencia del producto. El paquete de evaluación es idéntico al paquete adquirido. La versión de evaluación simplemente se convierte en licenciada después de añadir unas pocas líneas de código (para aplicar la licencia).

Una vez que quede satisfecho con la evaluación de **Aspose.Slides**, puede [adquirir una licencia](https://purchase.aspose.com/buy). Le recomendamos que revise los diferentes tipos de suscripción. Si tiene preguntas, contacte con el equipo de ventas de Aspose.

Cada licencia de Aspose incluye una suscripción de un año para actualizaciones gratuitas a nuevas versiones o correcciones publicadas durante el periodo de suscripción. Los usuarios con productos licenciados (incluso versiones de evaluación) reciben soporte técnico gratuito e ilimitado.

{{% /alert %}} 

**Limitaciones de la versión de evaluación**

* Aunque la versión de evaluación de Aspose.Slides (sin especificar una licencia) ofrece la funcionalidad completa del producto, inserta una marca de agua de evaluación en la parte superior del documento al abrirlo y guardarlo. 
* La extracción de texto de diapositivas está limitada a una sola diapositiva.

{{% alert color="info" %}} 

Para probar Aspose.Slides sin limitaciones, puede solicitar una **Licencia Temporal de 30 días**. Consulte la página [Cómo obtener una Licencia Temporal](https://purchase.aspose.com/temporary-license) para más información.

{{% /alert %}}

## **Licenciamiento en Aspose.Slides**

* Una versión de evaluación se convierte en licenciada después de comprar una licencia y añadir un par de líneas de código (para aplicar la licencia).
* La licencia es un archivo XML de texto plano que contiene detalles como el nombre del producto, número de desarrolladores a los que está licenciada, fecha de expiración de la suscripción, etc. 
* El archivo de licencia está firmado digitalmente, por lo que no debe modificarse. Incluso la adición accidental de una línea extra al contenido del archivo lo invalidará.
* Aspose.Slides for Java normalmente busca la licencia en las siguientes ubicaciones:
  * Una ruta explícita
  * La carpeta que contiene Aspose.Slides.jar
* Para evitar las limitaciones asociadas a la versión de evaluación, es necesario establecer una licencia antes de usar **Aspose.Slides**. Sólo tiene que establecer la licencia una vez por aplicación o proceso.

{{% alert color="info" %}} 

Puede consultar [Licenciamiento por consumo](/slides/es/java/metered-licensing/).

{{% /alert %}} 


## **Aplicar una licencia**

Una licencia puede cargarse desde un **archivo** o **flujo**.

{{% alert color="info" %}}

Aspose.Slides ofrece la clase [License](https://reference.aspose.com/slides/es/java/com.aspose.slides/License) para las operaciones de licenciamiento.

{{% /alert %}} 

{{% alert color="warning" %}}

Las licencias nuevas pueden activar Aspose.Slides sólo a partir de la versión 21.4 o posterior. Las versiones anteriores utilizan un sistema de licenciamiento diferente y no reconocerán estas licencias.

{{% /alert %}}

### **Archivo**

El método más sencillo para establecer una licencia consiste en colocar el archivo de licencia en la carpeta que contiene Aspose.Slides.jar o el JAR de su aplicación.

Este código Java muestra cómo establecer un archivo de licencia:

``` java
// Instancia la clase License
com.aspose.slides.License license = new com.aspose.slides.License();

// Establece la ruta del archivo de licencia
license.setLicense("Aspose.Slides.Java.lic");
```

{{% alert color="warning" %}} 

Si coloca el archivo de licencia en un directorio diferente, al llamar al método [SetLicense](https://reference.aspose.com/slides/es/java/com.aspose.slides/License#setLicense-java.lang.String-) el nombre del archivo de licencia al final de la ruta explícita debe coincidir con el nombre de su archivo de licencia.

Por ejemplo, puede cambiar el nombre del archivo de licencia a *Aspose.Slides.Java.lic.xml*. Entonces, en su código, debe pasar la ruta al archivo (finalizando con *Aspose.Slides.Java.lic.xml*) al método [SetLicense](https://reference.aspose.com/slides/es/java/com.aspose.slides/License#setLicense-java.lang.String-).

{{% /alert %}}

### **Flujo**

Puede cargar una licencia desde un flujo. Este código Java muestra cómo aplicar una licencia desde un flujo:

``` java
// Instancia la clase License
com.aspose.slides.License license = new com.aspose.slides.License();

// Establece la licencia mediante un flujo
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Java.lic"));
```

### **PHP/Java Bridge**

Si utiliza Aspose.Slides para PHP a través de Java, puede establecer una licencia mediante un puente PHP/Java. Este puente le permite usar clases Java con sintaxis PHP. Para más información, consulte [Licencia en PHP](/slides/es/php-java/licensing/).

## **Validar una licencia**

Para comprobar si una licencia se ha configurado correctamente, puede validarla. Este código Java muestra cómo validar una licencia:

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

{{% alert title="Note" color="warning" %}} 

El método [SetLicense](https://reference.aspose.com/slides/es/java/com.aspose.slides/License#setLicense-java.io.InputStream-) no es seguro para hilos. Si este método debe llamarse simultáneamente desde varios hilos, conviene utilizar primitivas de sincronización (como un bloqueo) para evitar problemas. 

{{% /alert %}}

## **FAQ**

### ¿Puedo aplicar la licencia en un entorno completamente offline (sin acceso a Internet)?

Sí. La validación de la licencia se realiza localmente mediante el archivo de licencia; no se necesita conexión a Internet.

### ¿Qué ocurre cuando expira la suscripción de un año? ¿Dejará de funcionar la biblioteca?

No. La licencia es perpetua: puede seguir usando las versiones publicadas antes de la fecha de finalización de su suscripción; simplemente no podrá utilizar versiones más recientes sin renovar.