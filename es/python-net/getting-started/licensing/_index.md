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
description: "Aprenda cómo aplicar, gestionar y solucionar problemas de licencias en Aspose.Slides para Python a través de .NET. Garantice un acceso ininterrumpido a todas las funciones con nuestra guía paso a paso sobre licenciamiento."
---
## **Visión general**

Aspose.Slides puede usarse en modo de evaluación o con una licencia válida. La versión de evaluación proporciona la misma funcionalidad que la versión con licencia, pero añade una marca de agua de evaluación a cada diapositiva de cada presentación que guarda y trunca el texto que su código lee de las presentaciones.

## **Evaluar Aspose.Slides**

Puede descargar una versión de evaluación de **Aspose.Slides for Python via .NET** desde su [página de descarga](https://pypi.org/project/Aspose.Slides/). La versión de evaluación proporciona las mismas características que el producto con licencia. El paquete de evaluación es idéntico al paquete adquirido y se licencia después de añadir unas cuantas líneas de código para aplicar la licencia.

Cuando esté satisfecho con su evaluación de **Aspose.Slides**, puede [adquirir una licencia](https://purchase.aspose.com/pricing/slides/es/python-net/). Recomendamos revisar las opciones de suscripción disponibles. Si tiene preguntas, contacte al equipo de ventas de Aspose.

Cada licencia de Aspose incluye una suscripción de un año con actualizaciones gratuitas a nuevas versiones y correcciones publicadas durante ese periodo. Tanto los usuarios con licencia como los de evaluación reciben soporte técnico gratuito e ilimitado.

**Limitaciones de la versión de evaluación**

* La versión de evaluación (cuando no se aplica ninguna licencia) ofrece la funcionalidad completa, pero añade un cuadro de texto con marca de agua de evaluación a cada diapositiva de cada presentación que guarda.
* El texto que su código lee de una presentación se trunca a sus primeros caracteres, seguido de un aviso sobre la limitación de evaluación. El texto que su código escribe se guarda completo.

{{% alert color="info" title="Note" %}}
Para probar Aspose.Slides sin limitaciones, puede solicitar una **Licencia temporal de 30 días**. Consulte la página [Cómo obtener una licencia temporal](https://purchase.aspose.com/temporary-license) para obtener más detalles.
{{% /alert %}}

## **Licenciamiento en Aspose.Slides**

* Una versión de evaluación se licencia después de adquirir una licencia y añadir un par de líneas de código para aplicarla.
* La licencia es un archivo XML de texto plano que contiene detalles como el nombre del producto, el número de desarrolladores que cubre, la fecha de expiración de la suscripción, etc.
* El archivo de licencia está firmado digitalmente, por lo que no debe modificarlo. Incluso añadir un salto de línea invalidará la licencia.
* Aspose.Slides for Python via .NET busca la licencia en la ruta que le indique. Una ruta relativa, o un nombre de archivo sin ruta, se resuelve respecto al directorio de trabajo actual, que no es necesariamente la carpeta que contiene su script Python.
* Para evitar las limitaciones de la versión de evaluación, establezca la licencia antes de usar Aspose.Slides. Solo necesita configurarla una vez por aplicación o proceso.

{{% alert color="info" title="Note" %}}
También puede que desee revisar [Licenciamiento por consumo](/slides/es/python-net/metered-licensing/).
{{% /alert %}}

## **Aplicar una licencia**

Una licencia puede cargarse desde un **archivo** o un **flujo**.

{{% alert color="info" title="Note" %}}
Aspose.Slides proporciona la clase [License](https://reference.aspose.com/slides/es/python-net/aspose.slides/license/) para gestionar la licencia.
{{% /alert %}}

{{% alert color="warning" title="Warning" %}}
Las licencias nuevas pueden activar Aspose.Slides solo con la versión 21.4 o posterior. Las versiones anteriores utilizan un sistema de licenciamiento diferente y no reconocerán estas licencias.
{{% /alert %}}

### **Archivo**

La forma más sencilla de establecer una licencia es pasar la ruta del archivo de licencia al método [set_license](https://reference.aspose.com/slides/es/python-net/aspose.slides/license/set_license/). Si pasa solo el nombre del archivo, como en el ejemplo siguiente, Aspose.Slides busca el archivo en el directorio de trabajo actual.

El siguiente código Python muestra cómo establecer el archivo de licencia:

```py
import aspose.slides as slides

# Instancia la clase License. 
license = slides.License()

# Establece la ruta del archivo de licencia.
license.set_license("Aspose.Slides.lic")
```

{{% alert color="warning" title="Warning" %}}
Si coloca el archivo de licencia en un directorio diferente, al llamar a [License.set_license](https://reference.aspose.com/slides/es/python-net/aspose.slides/license/set_license/#str), el nombre del archivo al final de la ruta explícita debe coincidir con el nombre de su archivo de licencia.

Por ejemplo, puede renombrar el archivo de licencia a *Aspose.Slides.lic.xml*. Entonces, en su código, pase la ruta completa a ese archivo (terminando con Aspose.Slides.lic.xml) al método [License.set_license](https://reference.aspose.com/slides/es/python-net/aspose.slides/license/set_license/#str).
{{% /alert %}}

### **Flujo**

Puede cargar una licencia desde un flujo. El siguiente ejemplo en Python muestra cómo aplicar una licencia desde un flujo:

```py
import aspose.slides as slides

# Instancia la clase License.
license = slides.License()

# Establece la licencia desde un flujo.
with open("Aspose.Slides.lic", "rb") as stream:
    license.set_license(stream)
```

## **Validar una licencia**

Para verificar que la licencia se ha aplicado correctamente, puede validarla. El siguiente código Python muestra cómo validar una licencia:

```py
import aspose.slides as slides

license = slides.License()

license.set_license("Aspose.Slides.lic")

if license.is_licensed():
    print("License is good!")
```

## **Seguridad de subprocesos**

{{% alert color="warning" title="Warning" %}}
El método [License.set_license](https://reference.aspose.com/slides/es/python-net/aspose.slides/license/set_license/) no es seguro para subprocesos. Si necesita llamarlo simultáneamente desde varios subprocesos, use un elemento de sincronización, como `threading.Lock`, para evitar problemas.
{{% /alert %}}

## **FAQ**

### ¿Puedo aplicar la licencia en un entorno completamente offline (sin acceso a internet)?

Sí. La validación de la licencia se realiza localmente usando el archivo de licencia; no se necesita conexión a internet.

### ¿Qué ocurre después de que expire la suscripción de un año? ¿Dejará de funcionar la biblioteca?

No. La licencia es perpetua: puede seguir usando las versiones lanzadas antes de la fecha de finalización de su suscripción; simplemente no podrá usar versiones más recientes sin renovar.