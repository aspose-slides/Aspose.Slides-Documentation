---
title: Licenciamiento
type: docs
weight: 90
url: /es/java/licensing/
---

## **Evaluar Aspose.Slides**

{{% alert color="primary" %}} 

Puedes descargar una versión de evaluación de **Aspose.Slides for Java** desde su [página de descarga](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). La versión de evaluación proporciona las mismas funcionalidades que la versión licenciada del producto. El paquete de evaluación es el mismo que el paquete comprado. La versión de evaluación simplemente se convierte en licenciada después de que agregues unas pocas líneas de código (para aplicar la licencia).

Una vez que estés satisfecho con tu evaluación de **Aspose.Slides**, puedes [comprar una licencia](https://purchase.aspose.com/buy). Te recomendamos que revises los diferentes tipos de suscripción. Si tienes preguntas, contacta al equipo de ventas de Aspose.

Cada licencia de Aspose incluye un año de suscripción para actualizaciones gratuitas a nuevas versiones o correcciones lanzadas dentro del período de suscripción. Los usuarios con productos licenciados (o incluso versiones de evaluación) obtienen soporte técnico gratuito e ilimitado.

{{% /alert %}} 

**Limitaciones de la versión de evaluación**

* Mientras que la versión de evaluación de Aspose.Slides (sin una licencia especificada) proporciona funcionalidad completa del producto, inserta una marca de agua de evaluación en la parte superior del documento en las operaciones de apertura y guardado.
* Estás limitado a una diapositiva al extraer textos de las diapositivas de presentación.

{{% alert color="primary" %}} 

Para probar Aspose.Slides sin limitaciones, puedes solicitar una **Licencia Temporal de 30 Días**. Consulta la página [Cómo obtener una Licencia Temporal](https://purchase.aspose.com/temporary-license) para más información.

{{% /alert %}}

## **Licenciamiento en Aspose.Slides**

* Una versión de evaluación se convierte en licenciada después de que compras una licencia y agregas un par de líneas de código (para aplicar la licencia).
* La licencia es un archivo XML de texto plano que contiene detalles como el nombre del producto, el número de desarrolladores a los que está licenciada, la fecha de caducidad de la suscripción, y así sucesivamente.
* El archivo de licencia está digitalmente firmado, por lo que no debes modificar el archivo. Incluso una adición inadvertida de un salto de línea adicional al contenido del archivo lo invalidará.
* Aspose.Slides for Java normalmente intenta encontrar la licencia en estas ubicaciones:
  * Un camino explícito
  * La carpeta que contiene Aspose.Slides.jar
* Para evitar las limitaciones asociadas con la versión de evaluación, debes establecer una licencia antes de usar **Aspose.Slides**. Solo tienes que establecer una licencia una vez por aplicación o proceso.

{{% alert color="primary" %}} 

Puede que quieras ver [Licenciamiento Medido](/slides/es/java/metered-licensing/).

{{% /alert %}} 

## **Aplicando una Licencia**

Una licencia puede ser cargada desde un **archivo** o **flujo**.

{{% alert color="primary" %}}

Aspose.Slides proporciona la clase [License](https://reference.aspose.com/slides/java/com.aspose.slides/License) para operaciones de licencia.

{{% /alert %}} 

### **Archivo**

El método más fácil de establecer una licencia requiere que coloques el archivo de licencia en la carpeta que contiene Aspose.Slides.jar o el jar de tu aplicación.

Este código Java te muestra cómo establecer un archivo de licencia:

``` java
// Instancia la clase License
com.aspose.slides.License license = new com.aspose.slides.License();

// Establece la ruta del archivo de licencia
license.setLicense("Aspose.Slides.Java.lic");
```

{{% alert color="warning" %}} 

Si colocas el archivo de licencia en un directorio diferente, cuando llames al método [SetLicense](https://reference.aspose.com/slides/java/com.aspose.slides/License#setLicense-java.lang.String-) el nombre del archivo de licencia al final del explícito debe ser el mismo que el de tu archivo de licencia.

Por ejemplo, puedes cambiar el nombre del archivo de licencia a *Aspose.Slides.Java.lic.xml*. Luego, en tu código, debes pasar la ruta al archivo (terminando en *Aspose.Slides.Java.lic.xml*) al método [SetLicense](https://reference.aspose.com/slides/java/com.aspose.slides/License#setLicense-java.lang.String-).

{{% /alert %}}

### **Flujo**

Puedes cargar una licencia desde un flujo. Este código Java te muestra cómo aplicar una licencia desde un flujo:

``` java
// Instancia la clase License
com.aspose.slides.License license = new com.aspose.slides.License();

// Establece la licencia a través de un flujo
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Java.lic"));
```

### **Puente PHP/Java**

Si utilizas Aspose.Slides para PHP a través de Java, puedes establecer una licencia a través de un puente PHP/Java. Este puente te permite usar clases de Java en sintaxis PHP. Para más información, consulta [Licencia en PHP](/slides/es/php-java/licensing/).

## **Validando una Licencia**

Para comprobar si una licencia ha sido establecida correctamente, puedes validarla. Este código Java te muestra cómo validar una licencia:

```java
License license = new License();
license.setLicense("Aspose.Slides.Java.lic");

if (License.isLicensed()) 
{
    System.out.println("¡La licencia es válida!");
}
```

## **Seguridad de Hilos**

{{% alert title="Nota" color="warning" %}} 

El método [SetLicense](https://reference.aspose.com/slides/java/com.aspose.slides/License#setLicense-java.io.InputStream-) no es seguro para hilos. Si este método debe ser llamado simultáneamente desde muchos hilos, puede que desees usar primitivos de sincronización (como un bloqueo) para evitar problemas.

{{% /alert %}}