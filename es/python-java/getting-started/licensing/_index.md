---
title: Licencias
type: docs
weight: 80
url: /es/python-java/licensing/
keywords:
- Aspose.Slides
- Python
- Java
- archivo de licencia
- licencia temporal
- licencia por consumo
- limitaciones de evaluación
description: "Aplique una licencia de archivo, basada en bytes o por consumo en Aspose.Slides para Python a través de Java y elimine las limitaciones de evaluación de sus aplicaciones."
---
## **Visión general**

Aspose.Slides for Python via Java puede ejecutarse en modo de evaluación o con una licencia. Este artículo explica cómo aplicar una licencia desde un archivo o desde bytes y cómo configurar la licencia por consumo.

Para opciones de compra, consulte [Información de precios](https://purchase.aspose.com/pricing/slides/es/family). Para preguntas generales sobre licencias y compras, consulte [Políticas de compra y preguntas frecuentes](https://purchase.aspose.com/policies).

Para conocer las limitaciones de la evaluación y cómo solicitar una licencia temporal, consulte [Evaluar Aspose.Slides](/slides/es/python-java/evaluate-aspose-slides/). Aplique una licencia temporal de la misma manera que un archivo de licencia adquirido.

## **Sobre la licencia**

Un archivo de licencia contiene información como el nombre del producto, el número de desarrolladores con licencia y la fecha de vencimiento de la suscripción. El archivo es XML firmado digitalmente.

{{% alert color="warning" title="Advertencia" %}}
No edite el archivo de licencia. Incluso un salto de línea adicional puede invalidar su firma digital.
{{% /alert %}}

Aplique la licencia una vez por aplicación o proceso, antes de crear presentaciones o realizar otras operaciones de Aspose.Slides. Para un archivo de licencia, utilice la clase [License](https://reference.aspose.com/slides/es/python-java/aspose.slides/license/). La licencia por consumo utiliza un par de claves pública y privada en lugar de un archivo de licencia.

## **Aplicar una licencia**

Los siguientes ejemplos asumen que Aspose.Slides for Python via Java y sus requisitos previos están instalados. Cada ejemplo es un script independiente que inicia la JVM, importa la API y aplica una licencia. En su aplicación, realice las operaciones de presentación después de aplicar la licencia y cierre la JVM solo cuando todo el trabajo con Aspose.Slides haya finalizado.

### **Aplicar una licencia desde un archivo**

Pase la ruta del archivo de licencia a [License.setLicense](https://reference.aspose.com/slides/es/python-java/aspose.slides/license/#setLicense). Reemplace `Aspose.Slides.lic` con la ruta a su archivo de licencia.

```python
from pathlib import Path

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import License

    license_path = Path("Aspose.Slides.lic")
    if license_path.is_file():
        license = License()
        license.setLicense(str(license_path))
        print("Licensed:", license.isLicensed())
        # Realice las operaciones de presentación aquí, antes de cerrar la JVM.
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

Utilice el nombre exacto del archivo, incluida su extensión. Por ejemplo, si el archivo se llama `Aspose.Slides.lic.xml`, incluya `.xml` en la ruta. Una ruta absoluta evita ambigüedades sobre el directorio de trabajo de la aplicación.

El ejemplo utiliza [License.isLicensed](https://reference.aspose.com/slides/es/python-java/aspose.slides/license/#isLicensed) para comprobar si la licencia se ha aplicado.

### **Aplicar una licencia desde bytes**

Utilice [License.setLicenseFromBytes](https://reference.aspose.com/slides/es/python-java/aspose.slides/license/#setLicenseFromBytes) cuando la licencia está disponible como bytes de Python. El siguiente ejemplo lee el archivo en modo binario y lo cierra antes de aplicar la licencia.

```python
from pathlib import Path

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import License

    license_path = Path("Aspose.Slides.lic")
    if license_path.is_file():
        with license_path.open("rb") as license_file:
            license_data = license_file.read()

        license = License()
        license.setLicenseFromBytes(license_data)
        print("Licensed:", license.isLicensed())
        # Realice las operaciones de presentación aquí, antes de cerrar la JVM.
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

Mantenga los bytes originales sin cambios. No decodifique, reformatee ni modifique de otro modo el contenido de la licencia antes de aplicarla.

## **Aplicar una licencia por consumo**

La licencia por consumo le factura según el uso de la API. Después de obtener una licencia por consumo, aplique sus claves pública y privada con [Metered.setMeteredKey](https://reference.aspose.com/slides/es/python-java/aspose.slides/metered/#setMeteredKey). Inicialice el objeto [Metered](https://reference.aspose.com/slides/es/python-java/aspose.slides/metered/) y aplique las claves una sola vez al iniciar la aplicación.

El siguiente ejemplo lee las claves de las variables de entorno `ASPOSE_METERED_PUBLIC_KEY` y `ASPOSE_METERED_PRIVATE_KEY`. Establezca ambas variables antes de ejecutar el script.

```python
import os

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import Metered

    public_key = os.environ.get("ASPOSE_METERED_PUBLIC_KEY")
    private_key = os.environ.get("ASPOSE_METERED_PRIVATE_KEY")

    if public_key and private_key:
        metered = Metered()
        metered.setMeteredKey(public_key, private_key)
        # Realice las operaciones de presentación aquí, antes de cerrar la JVM.
    else:
        print("Set both metered licensing environment variables before running this example.")
finally:
    jpype.shutdownJVM()
```

{{% alert color="info" title="Nota" %}}
La licencia por consumo requiere una conexión a Internet para validar las claves e informar del uso. Mantenga la clave privada fuera del código fuente y de los registros. Consulte la [FAQ de licencia por consumo](https://purchase.aspose.com/faqs/licensing/metered) para obtener detalles sobre conectividad y facturación.
{{% /alert %}}

## **Preguntas frecuentes**

**¿Necesito instalar un paquete diferente después de comprar una licencia?**

No. Aplique la licencia al mismo paquete que utilizó para la evaluación.

**¿Debo aplicar una licencia para cada presentación?**

No. Aplíquela una sola vez durante el inicio de la aplicación, antes de crear o cargar presentaciones.

**¿Puedo cambiar el nombre del archivo de licencia?**

Sí. Utilice el nuevo nombre exacto del archivo en su código y mantenga el contenido del archivo sin cambios.

**¿Puedo usar una licencia temporal con el ejemplo basado en bytes?**

Sí. Lea el archivo de licencia temporal como bytes y aplíquelo de la misma manera que una licencia comprada.