---
title: Licencias
description: "Aspose.Slides para Python a través de Java proporciona diferentes planes de compra o ofrece una Prueba Gratuita y una Licencia Temporal de 30 días para evaluación utilizando políticas de Licenciamiento y Suscripción."
type: docs
weight: 80
url: /python-java/licensing/
---

A veces, para obtener los mejores resultados de evaluación, puede ser necesario un enfoque práctico. Por esta razón, Aspose.Slides proporciona diferentes planes de compra y también ofrece una Prueba Gratuita y una Licencia Temporal de 30 días para evaluación.

{{% alert color="primary" %}}

Tenga en cuenta que hay una serie de políticas y prácticas generales que le guían sobre cómo evaluar, licenciar adecuadamente y comprar nuestros productos. Puede encontrarlas en la sección ["Políticas de Compra y Preguntas Frecuentes"](https://purchase.aspose.com/policies).

{{% /alert %}}

## **Evaluar Aspose.Slides**
Puede descargar fácilmente Aspose.Slides para evaluación. El paquete de evaluación es el mismo que el paquete comprado. La versión de evaluación simplemente se licencia después de que añada algunas líneas de código para aplicar la licencia.

## **Limitación de la Versión de Evaluación**
La versión de evaluación de Aspose.Slides (sin una licencia especificada) proporciona toda la funcionalidad del producto, pero inserta una marca de agua de evaluación en la parte superior del documento al abrirlo y guardarlo. También está limitado a una diapositiva al extraer textos de las diapositivas de presentación.

{{% alert color="primary" %}} 

Si desea probar Aspose.Slides sin las limitaciones de la versión de evaluación, puede solicitar una **Licencia Temporal de 30 Días**. Consulte [¿Cómo obtener una Licencia Temporal?](https://purchase.aspose.com/temporary-license) para más información.

{{% /alert %}} 

## **Acerca de la Licencia**
Puede descargar fácilmente una versión de evaluación de Aspose.Slides para Python a través de Java desde su [página de descarga](https://releases.aspose.com/slides/python-java/). La versión de evaluación proporciona absolutamente **mismas capacidades** que la versión licenciada de Aspose.Slides. Además, la versión de evaluación simplemente se licencia después de comprar una licencia y agregar un par de líneas de código para aplicar la licencia.

La licencia es un archivo XML en texto plano que contiene detalles como el nombre del producto, número de desarrolladores a los que está licenciada, fecha de caducidad de la suscripción, etc. El archivo está firmado digitalmente, por lo que no debe modificarlo. Incluso una adición inadvertida de un salto de línea extra en el contenido del archivo lo invalidará.

Para evitar las limitaciones asociadas con la versión de evaluación, necesita establecer una licencia antes de usar **Aspose.Slides**. Solo se requiere establecer una licencia una vez por aplicación o proceso.

## Licencia Comprada

Después de la compra, necesita aplicar el archivo o flujo de licencia. 

{{% alert color="primary" %}}

Debe establecer la licencia:
* solo una vez por dominio de aplicación
* antes de usar cualquier otra clase de Aspose.Slides

{{% /alert %}}

{{% alert color="primary" %}}

Puede encontrar información sobre precios en la página [“Información de Precios”](https://purchase.aspose.com/pricing/slides/family).

{{% /alert %}}

### **Configurando una Licencia en Aspose.Slides para Python a través de Java**

Las licencias pueden aplicarse desde estas ubicaciones:

* Ruta explícita
* Flujo
* Como Licencia Medida – un nuevo mecanismo de licenciamiento

{{% alert color="primary" %}}

Utilice el método **setLicense** para licenciar un componente.

Si bien múltiples llamadas a **setLicense** no son dañinas, son un desperdicio de recursos (procesador).

{{% /alert %}}

#### **Aplicando una Licencia Usando un Archivo**

Este fragmento de código se utiliza para establecer un archivo de licencia:

**Python**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, License

license = License();
pres = Presentation()
license.setLicense("Aspose.Slides.lic");

jpype.shutdownJVM()
```

Al llamar al método setLicense, el nombre de la licencia debe ser el mismo que el de su archivo de licencia. Por ejemplo, puede cambiar el nombre del archivo de licencia a "Aspose.Slides.lic.xml". Luego, en su código, debe pasar el nuevo nombre de licencia (Aspose.Slides.lic.xml) al método setLicense.

#### **Aplicando una Licencia de un Bytes**

Este fragmento de código se utiliza para aplicar una licencia de un bytes:

**Python**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, License

license = License();
input = open("Aspose.Slides.lic", mode="rb")
data = input.read()
pres = Presentation()
license.setLicenseFromBytes(data);

jpype.shutdownJVM()
```

#### Aplicar Licencia Medida

Aspose.Slides permite a los desarrolladores aplicar una clave medida. Este es un nuevo mecanismo de licenciamiento.

El nuevo mecanismo de licenciamiento se utilizará junto con el método de licenciamiento existente. Aquellos clientes que deseen ser facturados según el uso de las características de la API pueden utilizar la Licencia Medida.

Después de completar todos los pasos necesarios para obtener este tipo de licencia, recibirá las claves, no el archivo de licencia. Esta clave medida se puede aplicar utilizando la clase **Metered** especialmente introducida para este propósito.

El siguiente ejemplo de código muestra cómo establecer claves públicas y privadas medidas:

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, Metered, SaveFormat

# Crear una instancia de la clase Metered CAD
metered = Metered();

# Acceder a la propiedad set_metered_key y pasar claves públicas y privadas como parámetros
metered.setMeteredKey("*****", "*****");

# Obtener la cantidad de datos medidos antes de llamar a la API
amountbefore = Metered.getConsumptionQuantity()

# Mostrar información
print("Cantidad Consumida Antes: \" + amountbefore + \"" )

# Cargar el documento desde el disco.
pres = Presentation();

# Obtener el conteo de páginas del documento
print("Cantidad Consumida Después: \" +  pres.getSlides().size()) + \"" )

# guardar como PDF
pres.save("out_pdf.pdf", SaveFormat.Pdf);

# Obtener la cantidad de datos medidos después de llamar a la API
amountafter = Metered.getConsumptionQuantity()

# Mostrar información
print("Cantidad Consumida Después: \" + amountafter + \"" )

jpype.shutdownJVM()
```

{{% alert color="primary" %}}

Tenga en cuenta que debe tener una conexión a Internet estable para el uso correcto de la licencia medida, ya que el mecanismo medido requiere la interacción constante con nuestros servicios para cálculos correctos. Para más detalles, consulte la sección [“Preguntas Frecuentes sobre Licencias Medidas”](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}}