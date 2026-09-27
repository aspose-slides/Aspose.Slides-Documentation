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
- licencia medida
- limitaciones de evaluación
description: "Aplicar una licencia desde archivo, basada en bytes o medida en Aspose.Slides para Python vía Java y eliminar las limitaciones de evaluación de sus aplicaciones."
---
## **Resumen**

Aspose.Slides for Python via Java puede ejecutarse en modo de evaluación o con una licencia. En modo de evaluación, añade un cuadro de texto de marca de agua de evaluación a cada diapositiva de cada presentación que guarda y trunca el texto que su código lee de las presentaciones. Este artículo explica cómo aplicar una licencia desde un archivo o desde bytes y cómo configurar la licencia medida.

Para opciones de compra, consulte [Pricing Information](https://purchase.aspose.com/pricing/slides/es/family). Para preguntas generales sobre licencias y compras, consulte [Purchase Policies and FAQ](https://purchase.aspose.com/policies).

Para conocer las limitaciones de evaluación y cómo solicitar una licencia temporal, consulte [Evaluate Aspose.Slides](/slides/es/python-java/evaluate-aspose-slides/). Aplique una licencia temporal del mismo modo que un archivo de licencia comprado.

## **Sobre la licencia**

Un archivo de licencia contiene información como el nombre del producto, el número de desarrolladores con licencia y la fecha de expiración de la suscripción. El archivo es XML firmado digitalmente.

{{% alert color="warning" title="Warning" %}}
No edite el archivo de licencia. Incluso un salto de línea adicional puede invalidar su firma digital.
{{% /alert %}}

Aplique la licencia una vez por aplicación o proceso, antes de crear presentaciones o realizar otras operaciones de Aspose.Slides. Para un archivo de licencia, utilice la clase [License](https://reference.aspose.com/slides/es/python-java/aspose.slides/license/). La licencia medida utiliza un par de claves pública y privada en lugar de un archivo de licencia.

## **Aplicar una licencia**

Los siguientes ejemplos asumen que Aspose.Slides for Python via Java y sus requisitos previos están instalados. Cada ejemplo es un script autónomo que inicia la JVM, importa la API y aplica una licencia. En su aplicación, realice sus operaciones de presentación después de aplicar la licencia y apague la JVM solo después de que todo el trabajo de Aspose.Slides haya finalizado.

### **Aplicar una licencia desde un archivo**

Pase la ruta del archivo de licencia a [License.setLicense](https://reference.aspose.com/slides/es/python-java/aspose.slides/license/#setLicense). Reemplace `Aspose.Slides.lic` por la ruta a su archivo de licencia.

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
        # Realizar operaciones de presentación aquí, antes de cerrar la JVM.
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

Utilice el nombre exacto del archivo, incluida su extensión. Por ejemplo, si el archivo se llama `Aspose.Slides.lic.xml`, incluya `.xml` en la ruta. Una ruta absoluta evita ambigüedades sobre el directorio de trabajo de la aplicación.

El ejemplo usa [License.isLicensed](https://reference.aspose.com/slides/es/python-java/aspose.slides/license/#isLicensed) para comprobar si la licencia se ha aplicado.

### **Aplicar una licencia desde bytes**

Use [License.setLicenseFromBytes](https://reference.aspose.com/slides/es/python-java/aspose.slides/license/#setLicenseFromBytes) cuando la licencia esté disponible como bytes de Python. El siguiente ejemplo lee el archivo en modo binario y lo cierra antes de aplicar la licencia.

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
        # Realizar operaciones de presentación aquí, antes de cerrar la JVM.
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

Mantenga los bytes originales sin cambios. No decodifique, reformatee ni modifique de ningún modo el contenido de la licencia antes de aplicarla.

## **Aplicar una licencia medida**

La licencia medida le factura según el uso de la API. Después de obtener una licencia medida, aplique sus claves pública y privada con [Metered.setMeteredKey](https://reference.aspose.com/slides/es/python-java/aspose.slides/metered/#setMeteredKey). Inicialice el objeto [Metered](https://reference.aspose.com/slides/es/python-java/aspose.slides/metered/) y aplique las claves una vez al iniciar la aplicación.

El siguiente ejemplo lee las claves de las variables de entorno `ASPOSE_METERED_PUBLIC_KEY` y `ASPOSE_METERED_PRIVATE_KEY`. Defina ambas variables antes de ejecutar el script.

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
        # Realizar operaciones de presentación aquí, antes de cerrar la JVM.
    else:
        print("Set both metered licensing environment variables before running this example.")
finally:
    jpype.shutdownJVM()
```

{{% alert color="info" title="Note" %}}
La licencia medida requiere una conexión a Internet para validar las claves e informar del uso. Mantenga la clave privada fuera del código fuente y de los registros. Consulte la [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered) para detalles sobre conectividad y facturación.
{{% /alert %}}

## **FAQ**

**¿Necesito instalar un paquete diferente después de comprar una licencia?**

No. Aplique la licencia al mismo paquete que utilizó para la evaluación.

**¿Debo aplicar una licencia para cada presentación?**

No. Aplíquela una vez al iniciar la aplicación, antes de crear o cargar presentaciones.

**¿Puedo cambiar el nombre del archivo de licencia?**

Sí. Use el nuevo nombre exacto del archivo en su código y mantenga el contenido del archivo sin cambios.

**¿Puedo usar una licencia temporal con el ejemplo basado en bytes?**

Sí. Lea el archivo de licencia temporal como bytes y aplíquelo de la misma manera que una licencia comprada.