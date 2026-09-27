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
description: "Aplicar, gestionar y solucionar problemas de licencias en Aspose.Slides for Android via Java. Garantizar el acceso ininterrumpido a todas las funciones con nuestra guía de licenciamiento."
---
## **Visión general**

Aspose.Slides se puede usar en modo de evaluación o con una licencia válida. La versión de evaluación ofrece la misma funcionalidad que la versión con licencia, pero añade una marca de agua de evaluación a cada diapositiva de cada presentación que guarda y trunca el texto que su código lee de las presentaciones.

Este artículo explica cómo funciona el licenciamiento en Aspose.Slides y cómo aplicar una licencia antes de usar la biblioteca. Una licencia puede cargarse desde un archivo, un flujo o un recurso incrustado utilizando la clase [License](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/license/). El artículo también muestra cómo validar si una licencia se ha aplicado correctamente.

## **Evaluar Aspose.Slides**

{{% alert color="info" title="Note" %}}
Puede descargar una versión de evaluación de **Aspose.Slides for Android via Java** desde su [página de descarga](https://releases.aspose.com/slides/es/androidjava/). La versión de evaluación ofrece las mismas funcionalidades que la versión con licencia del producto. El paquete de evaluación es idéntico al paquete adquirido. La versión de evaluación pasa a estar licenciada simplemente añadiendo unas pocas líneas de código (para aplicar la licencia).

Una vez que esté satisfecho con su evaluación de **Aspose.Slides**, puede [adquirir una licencia](https://purchase.aspose.com/pricing/slides/es/android-java/). Recomendamos revisar los diferentes tipos de suscripción. Si tiene preguntas, contacte al equipo de ventas de Aspose.

Cada licencia de Aspose incluye una suscripción de un año para actualizaciones gratuitas a nuevas versiones o correcciones lanzadas durante el periodo de suscripción. Los usuarios con productos con licencia (o incluso versiones de evaluación) obtienen soporte técnico gratuito e ilimitado.
{{% /alert %}} 

**Limitaciones de la versión de evaluación**

* La versión de evaluación (sin especificar una licencia) ofrece la funcionalidad completa del producto, pero añade un cuadro de texto con marca de agua de evaluación a cada diapositiva de cada presentación que guarda.
* El texto que su código lee de una presentación se trunca a sus primeros caracteres, seguido de un aviso sobre la limitación de la evaluación. El texto que su código escribe se guarda completo.

{{% alert color="info" title="Note" %}}
Para probar Aspose.Slides sin limitaciones, puede solicitar una **30-Day Temporary License**. Consulte la página [Cómo obtener una licencia temporal](https://purchase.aspose.com/temporary-license) para obtener más información.
{{% /alert %}}

## **Licenciamiento en Aspose.Slides**

* Una versión de evaluación pasa a estar licenciada después de que compre una licencia y añada un par de líneas de código (para aplicar la licencia).
* La licencia es un archivo XML de texto plano que contiene detalles como el nombre del producto, el número de desarrolladores a los que está licenciada, la fecha de vencimiento de la suscripción, etc.
* El archivo de licencia está firmado digitalmente, por lo que no debe modificarlo. Incluso la adición inadvertida de un salto de línea extra al contenido del archivo lo invalidará.
* Aspose.Slides for Android via Java normalmente intenta encontrar la licencia en estas ubicaciones:
  * Una ruta explícita
  * La carpeta que contiene Aspose.Slides.jar
* Para evitar las limitaciones asociadas a la versión de evaluación, necesita establecer una licencia antes de usar **Aspose.Slides**. Sólo tiene que establecer una licencia una vez por aplicación o proceso.

## **Aplicar una licencia**

Una licencia puede cargarse desde un **archivo** o **flujo**.

{{% alert color="info" title="Note" %}}
Aspose.Slides proporciona la clase [License](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/license/) para operaciones de licenciamiento.
{{% /alert %}} 

{{% alert color="warning" title="Warning" %}}
Las licencias nuevas pueden activar Aspose.Slides sólo con la versión 21.4 o posterior. Las versiones anteriores usan un sistema de licenciamiento diferente y no reconocerán estas licencias.
{{% /alert %}}

### **Archivo**

El método más sencillo para establecer una licencia requiere que coloque el archivo de licencia en la carpeta que contiene Aspose.Slides.jar o el JAR de su aplicación.

{{% alert color="info" title="Note" %}}
En Android, la biblioteca y su aplicación se empaquetan en el APK, por lo que no hay una carpeta que contenga el archivo JAR de la biblioteca, y una ruta relativa como *Aspose.Slides.Android.via.Java.lic* no apunta a un archivo en su aplicación. Añada el archivo de licencia a los assets de su aplicación y cárguelo desde un flujo, como se muestra en [Flujo desde los recursos de la aplicación](#stream-from-app-assets).
{{% /alert %}}

``` java
// Instancia la clase License
com.aspose.slides.License license = new com.aspose.slides.License();

// Establece la ruta del archivo de licencia
license.setLicense("Aspose.Slides.Android.via.Java.lic");
```

{{% alert color="warning" title="Warning" %}}
Si coloca el archivo de licencia en un directorio diferente, al llamar al método [setLicense](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-) el nombre del archivo de licencia al final de la ruta especificada debe ser idéntico al nombre de su archivo de licencia.

Por ejemplo, puede cambiar el nombre del archivo de licencia a *Aspose.Slides.Android.via.Java.lic.xml*. Entonces, en su código, debe pasar la ruta al archivo (que termine con *Aspose.Slides.Android.via.Java.lic.xml*) al método [setLicense](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-).
{{% /alert %}}

### **Flujo**

Puede cargar una licencia desde un flujo. Este código Java le muestra cómo aplicar una licencia desde un flujo:

``` java
// Instancia la clase License
com.aspose.slides.License license = new com.aspose.slides.License();

// Establece la licencia mediante un flujo
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Android.via.Java.lic"));
```

### **Flujo desde los recursos de la aplicación**

En una aplicación Android, coloque el archivo de licencia en la carpeta *assets* del módulo de la aplicación, *app/src/main/assets*, de modo que se empaquete en el APK. Abra el archivo con el método [getAssets](https://developer.android.com/reference/android/content/Context#getAssets()) y pase el flujo al método [setLicense](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-). El código se ejecuta dentro de una `Activity`, por ejemplo en su método `onCreate`, antes de que la aplicación utilice Aspose.Slides:

```java
import android.util.Log;
import com.aspose.slides.License;
import java.io.IOException;
import java.io.InputStream;

License license = new License();
try (InputStream licenseStream = getAssets().open("Aspose.Slides.Android.via.Java.lic")) {
    license.setLicense(licenseStream);
} catch (IOException exception) {
    Log.e("Licensing", "Cannot read the license file from the app's assets.", exception);
}
```

El nombre de archivo pasado al método [open](https://developer.android.com/reference/android/content/res/AssetManager#open(java.lang.String)) es relativo a la carpeta *assets*. Si el archivo no está allí, el código registra el error y Aspose.Slides permanece en modo de evaluación. Para comprobar si la licencia se aplicó, consulte [Validar una licencia](#validating-a-license).

## **Validar una licencia**

Para comprobar si una licencia se ha configurado correctamente, puede validarla. Este código Java le muestra cómo validar una licencia:

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

{{% alert color="warning" title="Warning" %}}
El método [setLicense](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-) no es seguro para subprocesos. Si este método debe llamarse simultáneamente desde varios subprocesos, puede querer usar primitivas de sincronización (como un bloqueo) para evitar problemas.
{{% /alert %}}

## **Preguntas frecuentes**

### ¿Puedo aplicar la licencia en un entorno completamente offline (sin acceso a Internet)?

Sí. La validación de la licencia se realiza localmente usando el archivo de licencia; no se requiere conexión a Internet.

### ¿Qué ocurre cuando expira la suscripción de un año? ¿Dejará de funcionar la biblioteca?

No. La licencia es perpetua: puede seguir usando las versiones publicadas antes de la fecha de finalización de su suscripción; simplemente no podrá usar versiones más recientes sin renovarla.