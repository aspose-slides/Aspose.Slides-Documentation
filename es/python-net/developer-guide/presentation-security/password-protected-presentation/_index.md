---
title: Presentación Protegida por Contraseña
type: docs
weight: 20
url: /es/python-net/password-protected-presentation/
keywords: "Bloquear PowerPoint, desbloquear PowerPoint, proteger PowerPoint, establecer contraseña, agregar contraseña, cifrar PowerPoint, descifrar PowerPoint, Protección de escritura, seguridad de PowerPoint, presentación de PowerPoint, Python, Aspose.Slides para Python a través de .NET"
description: "Protección por contraseña de PowerPoint, cifrado y seguridad en Python"

---

## **Acerca de la Protección por Contraseña**
### **¿Cómo funciona la protección por contraseña para presentaciones?**
Cuando proteges una presentación con contraseña, significa que estás estableciendo una contraseña que impone ciertas restricciones en la presentación. Para eliminar las restricciones, se debe ingresar la contraseña. Una presentación protegida por contraseña se considera una presentación bloqueada.

Típicamente, puedes establecer una contraseña para hacer cumplir estas restricciones en una presentación:

- **Modificación**

  Si deseas que solo ciertos usuarios modifiquen tu presentación, puedes establecer una restricción de modificación. La restricción aquí impide que las personas modifiquen, cambien o copien cosas en tu presentación (a menos que proporcionen la contraseña).

  Sin embargo, en este caso, incluso sin la contraseña, un usuario podrá acceder a tu documento y abrirlo. En este modo de solo lectura, el usuario puede ver el contenido o cosas—hipervínculos, animaciones, efectos y otros—dentro de tu presentación, pero no pueden copiar elementos ni guardar la presentación.

- **Apertura**

  Si deseas que solo ciertos usuarios abran tu presentación, puedes establecer una restricción de apertura. La restricción aquí impide que las personas incluso vean el contenido de tu presentación (a menos que proporcionen la contraseña).

  Técnicamente, la restricción de apertura también previene que los usuarios modifiquen tus presentaciones: cuando las personas no pueden abrir una presentación, no pueden modificarla ni hacer cambios.

  **Nota** que cuando proteges una presentación con contraseña para prevenir su apertura, el archivo de la presentación se convierte en un archivo cifrado.

## Cómo Proteger una Presentación con Contraseña en Línea

1. Ve a nuestra página de [**Aspose.Slides Lock**](https://products.aspose.app/slides/lock).

   ![todo:image_alt_text](slides-lock.png)

2. Haz clic en **Suelta o carga tus archivos**.

3. Selecciona el archivo que deseas proteger con contraseña en tu computadora.

4. Ingresa tu contraseña preferida para la protección de edición; Ingresa tu contraseña preferida para la protección de vista.

5. Si deseas que los usuarios vean tu presentación como una copia final, marca la casilla **Marcar como final**.

6. Haz clic en **PROTEGER AHORA.**

7. Haz clic en **DESCARGAR AHORA.**

## **Protección por Contraseña para Presentaciones en Aspose.Slides**
**Formatos Admitidos**

Aspose.Slides admite la protección por contraseña, cifrado y operaciones similares para presentaciones en estos formatos:

- PPTX y PPT - Presentación de Microsoft PowerPoint
- ODP - Presentación de OpenDocument
- OTP - Plantilla de Presentación de OpenDocument

**Operaciones Admitidas**

Aspose.Slides te permite usar la protección por contraseña en presentaciones para prevenir modificaciones de estas maneras:

- Cifrando una presentación
- Estableciendo una protección de escritura a una presentación

**Otras operaciones**

Aspose.Slides te permite realizar otras tareas que implican la protección por contraseña y el cifrado de estas maneras:

- Descifrando una presentación; abriendo una presentación cifrada
- Eliminando el cifrado; deshabilitando la protección por contraseña
- Eliminando la protección de escritura de una presentación
- Obteniendo las propiedades de una presentación cifrada
- Verificando si una presentación está cifrada
- Verificando si una presentación está protegida por contraseña.

## **Cifrando una Presentación**

Puedes cifrar una presentación estableciendo una contraseña. Luego, para modificar la presentación bloqueada, un usuario debe proporcionar la contraseña.

Para cifrar o proteger con contraseña una presentación, debes usar el método encrypt (de [ProtectionManager](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/)) para establecer una contraseña para la presentación. Pasas la contraseña al método encrypt y usas el método save para guardar la presentación ahora cifrada.

Este código de muestra te muestra cómo cifrar una presentación:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.encrypt("123123")
    pres.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Estableciendo Protección de Escritura a una Presentación**

Puedes agregar una marca que indique “No modificar” a una presentación. De esta manera, informas a los usuarios que no deseas que hagan cambios en la presentación.

**Nota** que el proceso de protección de escritura no cifra la presentación. Por lo tanto, los usuarios—si realmente lo desean—pueden modificar la presentación, pero para guardar los cambios, tendrán que crear una presentación con un nombre diferente.

Para establecer una protección de escritura, debes usar el método setWriteProtection. Este código de muestra te muestra cómo establecer una protección de escritura a una presentación:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.set_write_protection("123123")
    pres.save("write-protected-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Descifrando una Presentación; Abriendo una Presentación Cifrada**

Aspose.Slides te permite cargar un archivo cifrado pasando su contraseña. Para descifrar una presentación, debes llamar al método [remove_encryption](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/) sin parámetros. Luego tendrás que ingresar la contraseña correcta para cargar la presentación.

Este código de muestra te muestra cómo descifrar una presentación:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    print(pres.document_properties.author)
```

## **Eliminando el Cifrado; Deshabilitando la Protección por Contraseña**

Puedes eliminar el cifrado o la protección por contraseña de una presentación. De esta manera, los usuarios pueden acceder o modificar la presentación sin restricciones.

Para eliminar el cifrado o la protección por contraseña, debes llamar al método [remove_encryption](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/). Este código de muestra te muestra cómo eliminar el cifrado de una presentación:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    pres.protection_manager.remove_encryption()
    pres.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Eliminando la Protección de Escritura de una Presentación**

Puedes usar Aspose.Slides para eliminar la protección de escritura utilizada en un archivo de presentación. De esta manera, los usuarios pueden modificar a su gusto—y no recibirán advertencias cuando realicen tales tareas.

Puedes eliminar la protección de escritura de una presentación utilizando el método [remove_write_protection](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/). Este código de muestra te muestra cómo eliminar la protección de escritura de una presentación:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    pres.protection_manager.remove_write_protection()
    pres.save("write-protection-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Obteniendo las Propiedades de una Presentación Cifrada**

Típicamente, los usuarios luchan por obtener las propiedades del documento de una presentación cifrada o protegida por contraseña. Sin embargo, Aspose.Slides ofrece un mecanismo que te permite proteger con contraseña una presentación mientras retiene los medios para que los usuarios accedan a las propiedades de esa presentación.

**Nota** que cuando Aspose.Slides cifra una presentación, las propiedades del documento de la presentación también quedan protegidas por contraseña por defecto. Pero si necesitas hacer que las propiedades de la presentación sean accesibles (incluso después de que la presentación sea cifrada), Aspose.Slides permite hacer precisamente eso.

Si deseas que los usuarios mantengan la capacidad de acceder a las propiedades de una presentación que cifraste, puedes establecer la propiedad [EncryptDocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/) en `True`. Este código de muestra te muestra cómo cifrar una presentación mientras proporcionas los medios para que los usuarios accedan a sus propiedades del documento:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.encrypt_document_properties = True
    pres.protection_manager.encrypt("123123")
```

## **Verificando si una Presentación está Protegida por Contraseña Antes de Cargarla**

Antes de cargar una presentación, es posible que desees verificar y confirmar que la presentación no ha sido protegida con una contraseña. De esta manera, evitas errores y problemas similares, que surgen cuando se carga una presentación protegida por contraseña sin su contraseña.

Este código Python te muestra cómo examinar una presentación para ver si está protegida por contraseña (sin cargar la presentación misma):

```python
import aspose.slides as slides

presentationInfo = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print("La presentación está protegida por contraseña: " + str(presentationInfo.is_password_protected))
```

## **Verificando si una Presentación está Cifrada**

Aspose.Slides te permite verificar si una presentación está cifrada. Para realizar esta tarea, puedes usar la propiedad [is_encrypted](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/) que devuelve `True` si la presentación está cifrada o `False` si la presentación no está cifrada.

Este código de muestra te muestra cómo verificar si una presentación está cifrada:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    print(str(pres.protection_manager.is_encrypted))
```

## **Verificando si una Presentación está Protegida contra Escritura**

Aspose.Slides te permite verificar si una presentación está protegida contra escritura. Para realizar esta tarea, puedes usar la propiedad [is_write_protected](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/) que devuelve `True` si la presentación está protegida y `False` si la presentación no está protegida.

Este código de muestra te muestra cómo verificar si una presentación está protegida contra escritura:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    print(str(pres.protection_manager.is_write_protected))
```

## **Validando o Confirmando que una Contraseña Específica se Ha Utilizado para Proteger una Presentación**

Es posible que desees verificar y confirmar que se ha utilizado una contraseña específica para proteger un documento de presentación. Aspose.Slides proporciona los medios para que valides una contraseña.

Este código de muestra te muestra cómo validar una contraseña:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    # verificar si "pass" coincide con
    matched = pres.protection_manager.check_write_protection("my_password")
    print(str(matched))
```

Devuelve `True` si la presentación ha sido cifrada con la contraseña especificada. De lo contrario, devuelve `False`.

{{% alert color="primary" title="Ver también" %}} 
- [Firma Digital en PowerPoint](/slides/es/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}