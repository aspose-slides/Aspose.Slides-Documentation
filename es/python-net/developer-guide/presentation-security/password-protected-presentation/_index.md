---
title: Presentaciones seguras con contraseñas usando Python
linktitle: Protección con contraseña
type: docs
weight: 20
url: /es/python-net/password-protected-presentation/
keywords:
- bloquear PowerPoint
- bloquear presentación
- desbloquear PowerPoint
- desbloquear presentación
- proteger PowerPoint
- proteger presentación
- establecer contraseña
- añadir contraseña
- cifrar PowerPoint
- cifrar presentación
- descifrar PowerPoint
- descifrar presentación
- protección contra escritura
- seguridad de PowerPoint
- seguridad de la presentación
- eliminar contraseña
- eliminar protección
- eliminar cifrado
- desactivar contraseña
- desactivar protección
- eliminar protección contra escritura
- presentación de PowerPoint
- Python
- Aspose.Slides
description: "Aprende a bloquear y desbloquear de forma sencilla presentaciones de PowerPoint y OpenDocument protegidas con contraseña usando Aspose.Slides para Python a través de .NET. Incrementa tu productividad y protege tus presentaciones con nuestra guía paso a paso."
---
## **Introducción**

Cuando proteges una presentación con contraseña, estás estableciendo una contraseña que impone ciertas restricciones sobre la presentación. Para eliminar esas restricciones, es necesario introducir la contraseña. Una presentación protegida con contraseña se considera una presentación bloqueada.

Normalmente, puedes establecer una contraseña para aplicar estas restricciones a una presentación:

- **Modificación**

  Si deseas que solo ciertos usuarios puedan modificar tu presentación, puedes establecer una restricción de modificación. Esta restricción impide que las personas modifiquen, cambien o copien elementos de tu presentación (a menos que proporcionen la contraseña).

  Sin embargo, en este caso, incluso sin la contraseña, un usuario podrá acceder a tu documento y abrirlo. En modo solo lectura, el usuario puede ver el contenido o elementos —hipervínculos, animaciones, efectos y otros— dentro de tu presentación, pero no puede copiar elementos ni guardar la presentación.

- **Apertura**

  Si deseas que solo ciertos usuarios puedan abrir tu presentación, puedes establecer una restricción de apertura. Esta restricción impide que las personas vean el contenido de tu presentación (a menos que proporcionen la contraseña).

  Técnicamente, la restricción de apertura también impide que los usuarios modifiquen tus presentaciones: cuando la gente no puede abrir una presentación, no puede modificarla ni realizar cambios en ella.

  **Nota** que cuando proteges una presentación con contraseña para impedir su apertura, el archivo de la presentación se cifra.

## Cómo proteger con contraseña una presentación en línea

1. Ve a nuestra página [**Aspose.Slides Lock**](https://products.aspose.app/slides/es/lock).

   ![todo:image_alt_text](slides-lock.png)

2. Haz clic en **Drop or upload your files**.

3. Selecciona el archivo que deseas proteger con contraseña en tu equipo.

4. Introduce la contraseña que prefieras para la protección de edición; introduce la contraseña que prefieras para la protección de visualización.

5. Si deseas que los usuarios vean tu presentación como la copia final, marca la casilla **Mark as final**.

6. Haz clic en **PROTECT NOW.**

7. Haz clic en **DOWNLOAD NOW.**

## **Protección con contraseña para presentaciones en Aspose.Slides**
**Formatos compatibles**

Aspose.Slides admite protección con contraseña, cifrado y operaciones similares para presentaciones en estos formatos:

- PPTX y PPT – Presentación de Microsoft PowerPoint
- ODP – Presentación OpenDocument
- OTP – Plantilla de presentación OpenDocument

**Operaciones compatibles**

Aspose.Slides permite usar protección con contraseña en presentaciones para evitar modificaciones de las siguientes maneras:

- Cifrar una presentación
- Establecer una protección de escritura en una presentación

**Otras operaciones**

Aspose.Slides permite realizar otras tareas relacionadas con la protección con contraseña y el cifrado de las siguientes formas:

- Descifrar una presentación; abrir una presentación cifrada
- Eliminar el cifrado; desactivar la protección con contraseña
- Eliminar la protección de escritura de una presentación
- Obtener las propiedades de una presentación cifrada
- Comprobar si una presentación está cifrada
- Comprobar si una presentación está protegida con contraseña.

## **Cifrado de una presentación**

Puedes cifrar una presentación estableciendo una contraseña. Entonces, para modificar la presentación bloqueada, el usuario debe proporcionar la contraseña.

Para cifrar o proteger con contraseña una presentación, debes usar el método encrypt (de [ProtectionManager](https://reference.aspose.com/slides/es/python-net/aspose.slides/protectionmanager/)) para establecer una contraseña para la presentación. Pasas la contraseña al método encrypt y utilizas el método save para guardar la presentación ahora cifrada.

Este fragmento de código muestra cómo cifrar una presentación:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.encrypt("123123")
    pres.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Establecimiento de protección de escritura en una presentación**

Puedes añadir una marca que indique “No modificar” a una presentación. De este modo, indicas a los usuarios que no deseas que realicen cambios en la presentación.

**Nota** que el proceso de protección de escritura no cifra la presentación. Por lo tanto, los usuarios —si realmente lo desean— pueden modificar la presentación, pero para guardar los cambios, tendrán que crear una presentación con un nombre diferente.

Para establecer una protección de escritura, debes usar el método setWriteProtection. Este fragmento de código muestra cómo establecer una protección de escritura en una presentación:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.set_write_protection("123123")
    pres.save("write-protected-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Descifrado de una presentación; apertura de una presentación cifrada**

Aspose.Slides permite cargar un archivo cifrado pasando su contraseña. Para descifrar una presentación, debes llamar al método [remove_encryption](https://reference.aspose.com/slides/es/python-net/aspose.slides/protectionmanager/) sin parámetros. A continuación, deberás introducir la contraseña correcta para cargar la presentación.

Este fragmento de código muestra cómo descifrar una presentación:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    print(pres.document_properties.author)
```

## **Eliminación del cifrado; desactivación de la protección con contraseña**

Puedes eliminar el cifrado o la protección con contraseña de una presentación. Así, los usuarios podrán acceder o modificar la presentación sin restricciones.

Para eliminar el cifrado o la protección con contraseña, debes llamar al método [remove_encryption](https://reference.aspose.com/slides/es/python-net/aspose.slides/protectionmanager/). Este fragmento de código muestra cómo eliminar el cifrado de una presentación:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    pres.protection_manager.remove_encryption()
    pres.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Eliminación de la protección de escritura de una presentación**

Puedes usar Aspose.Slides para eliminar la protección de escritura aplicada a un archivo de presentación. De este modo, los usuarios pueden modificar a su antojo y no reciben advertencias al realizar dichas tareas.

Puedes eliminar la protección de escritura de una presentación mediante el método [remove_write_protection](https://reference.aspose.com/slides/es/python-net/aspose.slides/protectionmanager/). Este fragmento de código muestra cómo eliminar la protección de escritura de una presentación:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    pres.protection_manager.remove_write_protection()
    pres.save("write-protection-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Obtención de propiedades de una presentación cifrada**

Normalmente, los usuarios tienen dificultades para recuperar las propiedades del documento de una presentación cifrada o protegida con contraseña. Sin embargo, Aspose.Slides ofrece un mecanismo que permite proteger una presentación con contraseña y, al mismo tiempo, mantener la capacidad de los usuarios para acceder a sus propiedades.

**Nota:** Por defecto, cuando Aspose.Slides cifra una presentación, las propiedades del documento de la presentación también quedan protegidas con contraseña. Si necesitas que las propiedades del documento sean accesibles incluso después del cifrado, Aspose.Slides permite hacerlo.

Si deseas que los usuarios mantengan la capacidad de acceder a las propiedades de una presentación cifrada, establece la propiedad `encrypt_document_properties` de [ProtectionManager](https://reference.aspose.com/slides/es/python-net/aspose.slides/protectionmanager/) a `False`. Este fragmento de código muestra cómo cifrar una presentación mientras se sigue proporcionando a los usuarios acceso a sus propiedades de documento:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.encrypt_document_properties = False
    presentation.protection_manager.encrypt("123123")
    presentation.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Carga solo de propiedades del documento de una presentación cifrada**

Para inspeccionar los metadatos de una presentación cifrada sin cargar sus diapositivas u otro contenido, crea un objeto [LoadOptions](https://reference.aspose.com/slides/es/python-net/aspose.slides/loadoptions/) y establece [only_load_document_properties](https://reference.aspose.com/slides/es/python-net/aspose.slides/loadoptions/only_load_document_properties/) a `True`. En este modo, Aspose.Slides ignora la contraseña y carga solo las propiedades del documento que son accesibles públicamente.

El siguiente ejemplo de código lee las propiedades de documento incorporadas y enumera las propiedades de documento personalizadas mediante [Presentation.document_properties](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/document_properties/):

```py
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.only_load_document_properties = True

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    document_properties = presentation.document_properties

    # Leer propiedades de documento integradas.
    print("Title: " + document_properties.title)
    print("Author: " + document_properties.author)

    # Enumerar propiedades de documento personalizadas.
    custom_property_count = document_properties.count_of_custom_properties

    for property_index in range(custom_property_count):
        property_name = document_properties.get_custom_property_name(property_index)
        print(property_name)
```

Este flujo de trabajo solo funciona cuando las propiedades del documento se dejaron sin cifrar (públicas) al cifrar la presentación. Si las propiedades del documento están cifradas, establecer `only_load_document_properties` a `True` provoca una excepción porque la contraseña se ignora en este modo. Para acceder a propiedades de documento cifradas o cargar la presentación completa, incluidas sus diapositivas y demás contenido, proporciona el valor correcto de `password` en [LoadOptions](https://reference.aspose.com/slides/es/python-net/aspose.slides/loadoptions/).

## **Comprobación de si una presentación está protegida con contraseña antes de cargarla**

Antes de cargar una presentación, puede que quieras comprobar y confirmar que la presentación no está protegida con contraseña. De este modo, evitas errores y problemas similares que aparecen al cargar una presentación protegida sin su contraseña.

Este código Python muestra cómo examinar una presentación para ver si está protegida con contraseña (sin cargar la presentación propiamente dicha):

```python
import aspose.slides as slides

presentationInfo = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print("The presentation is password protected: " + str(presentationInfo.is_password_protected))
```

## **Comprobación de si una presentación está cifrada**

Aspose.Slides permite comprobar si una presentación está cifrada. Para realizar esta tarea, puedes usar la propiedad [is_encrypted](https://reference.aspose.com/slides/es/python-net/aspose.slides/protectionmanager/), que devuelve `True` si la presentación está cifrada o `False` si no lo está.

Este fragmento de código muestra cómo comprobar si una presentación está cifrada:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    print(str(pres.protection_manager.is_encrypted))
```

## **Comprobación de si una presentación está protegida contra escritura**

Aspose.Slides permite comprobar si una presentación está protegida contra escritura. Para realizar esta tarea, puedes usar la propiedad [is_write_protected](https://reference.aspose.com/slides/es/python-net/aspose.slides/protectionmanager/), que devuelve `True` si la presentación está protegida contra escritura o `False` si no lo está.

Este fragmento de código muestra cómo comprobar si una presentación está protegida contra escritura:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    print(str(pres.protection_manager.is_write_protected))
```

## **Validación o confirmación de que una contraseña específica se ha utilizado para proteger una presentación**

Puede que necesites comprobar y confirmar que se ha usado una contraseña específica para proteger un documento de presentación. Aspose.Slides proporciona los medios para validar una contraseña.

Este fragmento de código muestra cómo validar una contraseña:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    # comprobar si "pass" coincide
    matched = pres.protection_manager.check_write_protection("my_password")
    print(str(matched))
```

Devuelve `True` si la presentación ha sido cifrada con la contraseña especificada. En caso contrario, devuelve `False`.

{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/es/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Preguntas frecuentes**

**¿Qué métodos de cifrado son compatibles con Aspose.Slides?**

Aspose.Slides admite métodos de cifrado modernos, incluidos algoritmos basados en AES, garantizando un alto nivel de seguridad de datos para tus presentaciones.

**¿Qué ocurre si se introduce una contraseña incorrecta al intentar abrir una presentación?**

Se lanza una excepción si se usa una contraseña incorrecta, indicando que el acceso a la presentación ha sido denegado. Esto ayuda a prevenir accesos no autorizados y protege el contenido de la presentación.

**¿Existen implicaciones de rendimiento al trabajar con presentaciones protegidas con contraseña?**

El proceso de cifrado y descifrado puede introducir una ligera sobrecarga durante las operaciones de apertura y guardado. En la mayoría de los casos, este impacto en el rendimiento es mínimo y no afecta de manera significativa al tiempo total de procesamiento de tus tareas con presentaciones.