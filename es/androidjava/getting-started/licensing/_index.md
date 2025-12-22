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
description: "Aplicar, gestionar y solucionar problemas de licencias en Aspose.Slides para Android mediante Java. Garantiza un acceso ininterrumpido a todas las funciones con nuestra guía de licenciamiento."
---

## **Evaluar Aspose.Slides**

{{% alert color="primary" %}} 

Puede descargar una versión de evaluación de **Aspose.Slides for Android via Java** desde su [página de descarga](https://releases.aspose.com/slides/androidjava/). La versión de evaluación ofrece las mismas funcionalidades que la versión con licencia del producto. El paquete de evaluación es el mismo que el paquete adquirido. La versión de evaluación simplemente se licencia después de que añada unas pocas líneas de código (para aplicar la licencia).

Una vez que esté satisfecho con su evaluación de **Aspose.Slides**, puede [comprar una licencia](https://purchase.aspose.com/buy). Le recomendamos revisar los diferentes tipos de suscripción. Si tiene preguntas, contacte al equipo de ventas de Aspose.

Cada licencia de Aspose incluye una suscripción de un año para actualizaciones gratuitas a nuevas versiones o correcciones lanzadas dentro del periodo de suscripción. Los usuarios con productos con licencia (incluso versiones de evaluación) obtienen soporte técnico gratuito e ilimitado.

{{% /alert %}} 

**Limitaciones de la versión de evaluación**

* Aunque la versión de evaluación de Aspose.Slides (sin una licencia especificada) ofrece la funcionalidad completa del producto, inserta una marca de agua de evaluación en la parte superior del documento al abrirlo y guardarlo. 
* Está limitado a una diapositiva al extraer texto de las diapositivas de la presentación.

{{% alert color="primary" %}} 

Para probar Aspose.Slides sin limitaciones, puede solicitar una **Licencia Temporal de 30 Días**. Consulte la página [Cómo obtener una Licencia Temporal](https://purchase.aspose.com/temporary-license) para más información.

{{% /alert %}}

## **Licenciamiento en Aspose.Slides**

* Una versión de evaluación se licencian después de que compra una licencia y agrega un par de líneas de código (para aplicar la licencia).
* La licencia es un archivo XML de texto plano que contiene detalles como el nombre del producto, el número de desarrolladores a los que está licenciada, la fecha de expiración de la suscripción, etc.
* El archivo de licencia está firmado digitalmente, por lo que no debe modificarlo. Incluso una adición inadvertida de una línea en blanco extra al contenido del archivo lo invalidará.
* Aspose.Slides for Android via Java normalmente intenta encontrar la licencia en estas ubicaciones:
  * Una ruta explícita
  * La carpeta que contiene Aspose.Slides.jar
* Para evitar las limitaciones asociadas a la versión de evaluación, debe establecer una licencia antes de usar **Aspose.Slides**. Sólo tiene que establecer una licencia una vez por aplicación o proceso.

{{% alert color="primary" %}} 

Puede que desee ver [Licenciamiento por Medida](/slides/es/androidjava/metered-licensing/).

{{% /alert %}} 


## **Aplicar una Licencia**

Una licencia puede cargarse desde un **archivo** o **flujo**.

{{% alert color="primary" %}}

Aspose.Slides proporciona la clase [License](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/) para operaciones de licenciamiento.

{{% /alert %}} 

{{% alert color="warning" %}}

Las licencias nuevas pueden activar Aspose.Slides solo con la versión 21.4 o posterior. Las versiones anteriores usan un sistema de licenciamiento diferente y no reconocerán estas licencias.

{{% /alert %}}

### **Archivo**

El método más sencillo para establecer una licencia requiere que coloque el archivo de licencia en la carpeta que contiene Aspose.Slides.jar o el jar de su aplicación.

Este código Java le muestra cómo establecer un archivo de licencia:
``` java
// Instancia la clase License
com.aspose.slides.License license = new com.aspose.slides.License();

// Establece la ruta del archivo de licencia
license.setLicense("Aspose.Slides.Android.via.Java.lic");
```


{{% alert color="warning" %}} 

Si coloca el archivo de licencia en un directorio diferente, al llamar al método [SetLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-), el nombre del archivo de licencia al final de la ruta explícita especificada debe ser el mismo que su archivo de licencia.

Por ejemplo, puede cambiar el nombre del archivo de licencia a *Aspose.Slides.Android.via.Java.lic.xml*. Entonces, en su código, debe pasar la ruta al archivo (que termine con *Aspose.Slides.Android.via.Java.lic.xml*) al método [SetLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-).

{{% /alert %}}

### **Flujo**

Puede cargar una licencia desde un flujo. Este código Java le muestra cómo aplicar una licencia desde un flujo:
``` java
// Instancia la clase License
com.aspose.slides.License license = new com.aspose.slides.License();

// Establece la licencia a través de un stream
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Android.via.Java.lic"));
```


## **Validar una Licencia**

Para comprobar si una licencia se ha establecido correctamente, puede validarla. Este código Java le muestra cómo validar una licencia:
```java
License license = new License();
license.setLicense("Aspose.Slides.Android.via.Java.lic");

if (License.isLicensed()) 
{
    System.out.println("License is good!");
}
```


## **Seguridad en Subprocesos**

{{% alert title="Note" color="warning" %}} 

El método [SetLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-) no es seguro para subprocesos. Si este método debe llamarse simultáneamente desde varios subprocesos, puede que desee usar primitivas de sincronización (como un bloqueo) para evitar problemas. 

{{% /alert %}}

## **Preguntas Frecuentes**

**¿Puedo aplicar la licencia en un entorno completamente offline (sin acceso a internet)?**

Sí. La validación de la licencia se realiza localmente usando el archivo de licencia; no se requiere conexión a internet.

**¿Qué ocurre después de que expira la suscripción de un año? ¿La biblioteca dejará de funcionar?**

No. La licencia es perpetua: puede seguir usando las versiones publicadas antes de la fecha de finalización de su suscripción; solo no será elegible para usar versiones más recientes sin renovar.