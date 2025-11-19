---
title: Licenciamiento
type: docs
weight: 80
url: /es/python-net/licensing/
keywords:
- licencia
- licencia temporal
- establecer licencia
- usar licencia
- validar licencia
- archivo de licencia
- versión de evaluación
- Python
- Aspose.Slides
description: "Aprenda cómo aplicar, gestionar y solucionar problemas de licencias en Aspose.Slides para Python a través de .NET. Garantice un acceso ininterrumpido a todas las funciones con nuestra guía paso a paso de licenciamiento."
---

## **Evaluar Aspose.Slides**

Puede descargar una versión de evaluación de **Aspose.Slides for Python via .NET** desde su [página de descarga](https://pypi.org/project/Aspose.Slides/). La versión de evaluación ofrece las mismas funciones que el producto con licencia. El paquete de evaluación es idéntico al paquete adquirido y se licencia después de agregar unas pocas líneas de código para aplicar la licencia.

Cuando esté satisfecho con su evaluación de **Aspose.Slides**, puede [comprar una licencia](https://purchase.aspose.com/buy). Le recomendamos revisar las opciones de suscripción disponibles. Si tiene preguntas, contacte al equipo de ventas de Aspose.

Cada licencia de Aspose incluye una suscripción de un año con actualizaciones gratuitas a nuevas versiones y correcciones lanzadas durante ese período. Tanto los usuarios con licencia como los de evaluación reciben soporte técnico gratuito e ilimitado.

**Limitaciones de la versión de evaluación**

* Aunque la versión de evaluación de Aspose.Slides (cuando no se aplica una licencia) proporciona funcionalidad completa, agrega una marca de agua de evaluación en la parte superior del documento cada vez que lo abre o lo guarda.
* Al extraer texto de una presentación, está limitado a una diapositiva.

{{% alert color="primary" %}}

Para probar Aspose.Slides sin limitaciones, puede solicitar una **licencia temporal de 30 días**. Consulte la página [Cómo obtener una licencia temporal](https://purchase.aspose.com/temporary-license) para más detalles.

{{% /alert %}}

## **Licenciamiento en Aspose.Slides**

* Una versión de evaluación se licencia después de comprar una licencia y agregar un par de líneas de código para aplicarla.
* La licencia es un archivo XML de texto plano que contiene detalles como el nombre del producto, el número de desarrolladores que cubre, la fecha de expiración de la suscripción, etc.
* El archivo de licencia está firmado digitalmente, por lo que no debe modificarse. Incluso agregar un solo salto de línea lo invalidará.
* Aspose.Slides for Python via .NET normalmente busca la licencia en estas ubicaciones:
  * Una ruta explícita que usted proporcione
  * La carpeta que contiene el script de Python que llama a Aspose.Slides for Python via .NET
* Para evitar las limitaciones de evaluación, establezca la licencia antes de usar Aspose.Slides. Solo necesita establecerla una vez por aplicación o proceso.

{{% alert color="primary" %}}

También puede revisar [Licenciamiento por consumo](/slides/es/python-net/metered-licensing/).

{{% /alert %}}

## **Aplicar una licencia**

Una licencia puede cargarse desde un **archivo**, **stream** o **recurso incrustado**. 

{{% alert color="primary" %}}

Aspose.Slides proporciona la clase [License](https://reference.aspose.com/slides/python-net/aspose.slides/license/) para gestionar la licenciamiento.

{{% /alert %}}

{{% alert color="warning" %}}

Las licencias nuevas pueden activar Aspose.Slides solo con la versión 21.4 o posterior. Las versiones anteriores utilizan un sistema de licenciamiento diferente y no reconocerán estas licencias.

{{% /alert %}}

### **Archivo**

La forma más sencilla de establecer una licencia es colocar el archivo de licencia en la misma carpeta que el DLL del componente y especificar solo el nombre del archivo (sin ruta).

El siguiente código Python muestra cómo establecer el archivo de licencia:
```py
import aspose.slides as slides

# Instancia la clase License. 
license = slides.License()

# Establece la ruta del archivo de licencia.
license.set_license("Aspose.Slides.lic")
```


{{% alert color="warning" %}}

Si coloca el archivo de licencia en un directorio diferente, al llamar a [License.set_license()](https://reference.aspose.com/slides/python-net/aspose.slides/license/set_license/#str), el nombre del archivo al final de la ruta explícita debe coincidir con el nombre de su archivo de licencia.

Por ejemplo, puede renombrar el archivo de licencia a *Aspose.Slides.lic.xml*. Luego, en su código, pase la ruta completa a ese archivo (terminando con Aspose.Slides.lic.xml) al método [License.set_license()](https://reference.aspose.com/slides/python-net/aspose.slides/license/set_license/#str).

{{% /alert %}}

### **Stream**

Puede cargar una licencia desde un stream. El siguiente ejemplo Python muestra cómo aplicar una licencia desde un stream:
```py
import aspose.slides as slides

# Instancia la clase License.
license = slides.License()

# Establece la licencia desde un stream.
license.set_license(stream)
```


## **Validar una licencia**

Para verificar que la licencia se ha aplicado correctamente, puede validarla. El siguiente código Python demuestra cómo validar una licencia:
```py
import aspose.slides as slides

license = slides.License()

license.set_license("Aspuse.Slides.lic")

if license.is_licensed():
    print("License is good!")
```


## **Seguridad en hilos**

{{% alert title="Note" color="warning" %}}

Los métodos [License.set_license](https://reference.aspose.com/slides/python-net/aspose.slides/license/) no son seguros para hilos. Si deben llamarse concurrentemente desde varios hilos, use primitivas de sincronización (p. ej., `threading.Lock`) para evitar problemas.

{{% /alert %}}

## **Preguntas frecuentes**

**¿Puedo aplicar la licencia en un entorno totalmente offline (sin acceso a internet)?**

Sí. La validación de la licencia se realiza localmente usando el archivo de licencia; no se requiere conexión a internet.

**¿Qué ocurre después de que expira la suscripción de un año? ¿La biblioteca dejará de funcionar?**

No. La licencia es perpetua: puede seguir usando las versiones lanzadas antes de la fecha de fin de su suscripción; simplemente no podrá usar versiones más recientes sin renovar.