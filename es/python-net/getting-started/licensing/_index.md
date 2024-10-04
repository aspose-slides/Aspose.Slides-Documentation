---
title: Licenciamiento
description: "Aspose.Slides para Python a través de .NET proporciona diferentes planes de compra o ofrece una Prueba Gratuita y una Licencia Temporal de 30 días para evaluación utilizando políticas de Licenciamiento y Suscripción."
type: docs
weight: 80
url: /es/python-net/licensing/
---

## **Evaluar Aspose.Slides**

{{% alert color="primary" %}} 

Puede descargar una versión de evaluación de **Aspose.Slides para Python a través de .NET** desde su [página de descarga](https://pypi.org/project/Aspose.Slides/). La versión de evaluación proporciona las mismas funcionalidades que la versión licenciada del producto. El paquete de evaluación es el mismo que el paquete comprado. La versión de evaluación simplemente se convierte en licenciada después de que agregue algunas líneas de código (para aplicar la licencia).

Una vez que esté satisfecho con su evaluación de **Aspose.Slides**, puede [comprar una licencia](https://purchase.aspose.com/buy). Le recomendamos que revise los diferentes tipos de suscripción. Si tiene preguntas, contacte al equipo de ventas de Aspose.

Cada licencia de Aspose viene con una suscripción de un año para actualizaciones gratuitas a nuevas versiones o correcciones lanzadas dentro del período de suscripción. Los usuarios con productos licenciados o incluso versiones de evaluación obtienen soporte técnico gratuito y ilimitado.

{{% /alert %}} 

**Limitaciones de la versión de evaluación**

* Aunque la versión de evaluación de Aspose.Slides (sin una licencia especificada) proporciona funcionalidad completa del producto, inserta una marca de agua de evaluación en la parte superior del documento en operaciones de apertura y guardado. 
* Está limitado a una diapositiva al extraer textos de las diapositivas de presentación.

{{% alert color="primary" %}} 

Para probar Aspose.Slides sin limitaciones, puede solicitar una **Licencia Temporal de 30 Días**. Vea la página [Cómo obtener una Licencia Temporal](https://purchase.aspose.com/temporary-license) para más información.

{{% /alert %}}

## **Licenciamiento en Aspose.Slides**

* Una versión de evaluación se convierte en licenciada después de que compre una licencia y agregue un par de líneas de código (para aplicar la licencia).
* La licencia es un archivo XML de texto plano que contiene detalles como el nombre del producto, el número de desarrolladores a los que está licenciada, la fecha de caducidad de la suscripción, etc. 
* El archivo de licencia está digitalmente firmado, por lo que no debe modificar el archivo. Incluso una adición inadvertida de un salto de línea extra al contenido del archivo lo invalidará.
* Aspose.Slides para Python a través de .NET intenta típicamente encontrar la licencia en estas ubicaciones:
  * Un camino explícito
  * La carpeta que contiene el script de Python que llama a Aspose.Slides para Python a través de .NET
* Para evitar las limitaciones asociadas con la versión de evaluación, necesita establecer una licencia antes de usar Aspose.Slides. Solo tiene que establecer una licencia una vez por aplicación o proceso.

{{% alert color="primary" %}} 

Quizás quiera ver [Licenciamiento Medido](/slides/es/python-net/metered-licensing/).

{{% /alert %}} 


## **Aplicando una Licencia**

Una licencia puede ser cargada desde un **archivo**, **flujo** o **recurso integrado**. 

{{% alert color="primary" %}}

Aspose.Slides proporciona la clase [License](https://reference.aspose.com/slides/python-net/aspose.slides/license/) para operaciones de licenciamiento.

{{% /alert %}} 

### **Archivo**

El método más fácil de establecer una licencia requiere que coloque el archivo de licencia en la misma carpeta que contiene el DLL del componente (incluido en Aspose.Slides) y especifique el nombre del archivo sin su ruta.

Este código Python le muestra cómo establecer un archivo de licencia:

``` python
import aspose.slides as slides

# Instancia la clase License 
license = slides.License()

# Establece la ruta del archivo de licencia
license.set_license("Aspose.Slides.lic")
```

{{% alert color="warning" %}} 

Si coloca el archivo de licencia en un directorio diferente, cuando llame al método [License.set_license()](https://reference.aspose.com/slides/python-net/aspose.slides/license/), el nombre del archivo de licencia al final de la ruta explícita especificada debe ser el mismo que su archivo de licencia.

Por ejemplo, puede cambiar el nombre del archivo de licencia a *Aspose.Slides.lic.xml*. Luego, en su código, debe pasar la ruta al archivo (terminando con *Aspose.Slides.lic.xml*) al método [License.set_license()](https://reference.aspose.com/slides/python-net/aspose.slides/license/).

{{% /alert %}}

### **Flujo**

Puede cargar una licencia desde un flujo. Este código Python le muestra cómo aplicar una licencia desde un flujo:

``` python
import aspose.slides as slides

# Instancia la clase License 
license = slides.License()

# Establece la licencia a través de un flujo
license.set_license(stream)
```

## **Validando una Licencia**

Para verificar si una licencia se ha establecido correctamente, puede validarla. Este código Python le muestra cómo validar una licencia:

```python
import aspose.slides as slides

license = slides.License()

license.set_license("Aspose.Slides.lic")

if license.is_licensed():
    print("¡La licencia es válida!")
```

## **Seguridad en Hilos**

{{% alert title="Nota" color="warning" %}} 

El método [License.set_license()](https://reference.aspose.com/slides/python-net/aspose.slides/license/) no es seguro para hilos. Si este método debe ser llamado simultáneamente desde muchos hilos, puede que desee usar primitivas de sincronización (como un bloqueo) para evitar problemas. 

{{% /alert %}}