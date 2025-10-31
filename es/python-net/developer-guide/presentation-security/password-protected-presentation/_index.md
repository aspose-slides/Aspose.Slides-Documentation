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
- seguridad PowerPoint
- seguridad de la presentación
- eliminar contraseña
- eliminar protección
- eliminar cifrado
- desactivar contraseña
- desactivar protección
- eliminar protección contra escritura
- presentación PowerPoint
- Python
- Aspose.Slides
description: "Aprenda a bloquear y desbloquear de manera sencilla presentaciones de PowerPoint y OpenDocument protegidas con contraseña usando Aspose.Slides para Python mediante .NET. Aumente su productividad y asegure sus presentaciones con nuestra guía paso a paso."
---

## **Sobre la protección con contraseña**
### **¿Cómo funciona la protección con contraseña para una presentación?**
Cuando protege una presentación con contraseña, está estableciendo una contraseña que impone ciertas restricciones sobre la presentación. Para eliminar las restricciones, se debe introducir la contraseña. Una presentación protegida con contraseña se considera una presentación bloqueada.

Normalmente, puede establecer una contraseña para imponer estas restricciones en una presentación:

- **Modificación**

  Si desea que solo ciertos usuarios puedan modificar su presentación, puede establecer una restricción de modificación. Esta restricción impide que las personas modifiquen, cambien o copien elementos de su presentación (a menos que proporcionen la contraseña). 

  Sin embargo, en este caso, incluso sin la contraseña, un usuario podrá acceder a su documento y abrirlo. En este modo de solo lectura, el usuario puede ver el contenido o elementos —hipervínculos, animaciones, efectos y otros— dentro de su presentación, pero no puede copiar elementos ni guardar la presentación. 

- **Apertura**

  Si desea que solo ciertos usuarios puedan abrir su presentación, puede establecer una restricción de apertura. Esta restricción impide que las personas vean siquiera el contenido de su presentación (a menos que proporcionen la contraseña).

  Técnicamente, la restricción de apertura también impide que los usuarios modifiquen sus presentaciones: cuando la gente no puede abrir una presentación, no puede modificarla ni hacer cambios en ella. 
  
  **Nota** que cuando protege una presentación con contraseña para impedir su apertura, el archivo de la presentación se cifra.

## Cómo proteger una presentación con contraseña en línea

1. Visite nuestra página [**Aspose.Slides Lock**](https://products.aspose.app/slides/lock). 

   ![todo:image_alt_text](slides-lock.png)

2. Haga clic en **Drop or upload your files**.

3. Seleccione el archivo que desea proteger con contraseña en su computadora. 

4. Introduzca la contraseña que prefiera para la protección de edición; introduzca la contraseña que prefiera para la protección de visualización. 

5. Si desea que los usuarios vean su presentación como la copia final, marque la casilla **Mark as final**.

6. Haga clic en **PROTECT NOW.** 

7. Haga clic en **DOWNLOAD NOW.**

## **Protección con contraseña para presentaciones en Aspose.Slides**
**Formatos compatibles**

Aspose.Slides admite la protección con contraseña, cifrado y operaciones similares para presentaciones en los siguientes formatos: 

- PPTX y PPT - Presentación de Microsoft PowerPoint 
- ODP - Presentación OpenDocument 
- OTP - Plantilla de presentación OpenDocument 

**Operaciones compatibles**

Aspose.Slides le permite usar la protección con contraseña en presentaciones para impedir modificaciones de las siguientes maneras:

- Cifrado de una presentación
- Establecimiento de protección contra escritura en una presentación

**Otras operaciones**

Aspose.Slides le permite realizar otras tareas relacionadas con la protección con contraseña y el cifrado de las siguientes maneras:

- Descifrar una presentación; abrir una presentación cifrada
- Eliminar cifrado; desactivar protección con contraseña
- Eliminar protección contra escritura de una presentación
- Obtener las propiedades de una presentación cifrada
- Comprobar si una presentación está cifrada
- Comprobar si una presentación está protegida con contraseña.

## **Cifrado de una presentación**

Puede cifrar una presentación estableciendo una contraseña. Luego, para modificar la presentación bloqueada, el usuario debe proporcionar la contraseña. 

Para cifrar o proteger con contraseña una presentación, debe usar el método **encrypt** (de [ProtectionManager](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/)) para establecer una contraseña para la presentación. Pasa la contraseña al método **encrypt** y usa el método **save** para guardar la presentación ahora cifrada. 

Este ejemplo de código muestra cómo cifrar una presentación:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.encrypt("123123")
    pres.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Establecer protección contra escritura en una presentación** 

Puede añadir una marca que indique “No modificar” a una presentación. De esta forma, indica a los usuarios que no desea que realicen cambios en la presentación.  

**Nota** que el proceso de protección contra escritura no cifra la presentación. Por lo tanto, los usuarios—si realmente lo desean—pueden modificar la presentación, pero para guardar los cambios tendrán que crear una presentación con un nombre diferente. 

Para establecer una protección contra escritura, debe usar el método **setWriteProtection**. Este ejemplo de código muestra cómo establecer una protección contra escritura en una presentación:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.set_write_protection("123123")
    pres.save("write-protected-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Descifrando una presentación; abrir una presentación cifrada**

Aspose.Slides le permite cargar un archivo cifrado pasando su contraseña. Para descifrar una presentación, debe llamar al método [remove_encryption](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/) sin parámetros. Luego deberá introducir la contraseña correcta para cargar la presentación. 

Este ejemplo de código muestra cómo descifrar una presentación: 

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    print(pres.document_properties.author)
```

## **Eliminar cifrado; desactivar protección con contraseña**

Puede eliminar el cifrado o la protección con contraseña de una presentación. De esta forma, los usuarios pueden acceder o modificar la presentación sin restricciones. 

Para eliminar el cifrado o la protección con contraseña, debe llamar al método [remove_encryption](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/). Este ejemplo de código muestra cómo eliminar el cifrado de una presentación:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    pres.protection_manager.remove_encryption()
    pres.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Eliminar protección contra escritura de una presentación**

Puede usar Aspose.Slides para eliminar la protección contra escritura utilizada en un archivo de presentación. De esta forma, los usuarios pueden modificar a su antojo—y no recibirán advertencias al realizar esas tareas.

Puede eliminar la protección contra escritura de una presentación mediante el método [remove_write_protection](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/). Este ejemplo de código muestra cómo eliminar la protección contra escritura de una presentación:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    pres.protection_manager.remove_write_protection()
    pres.save("write-protection-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Obtener las propiedades de una presentación cifrada**

Normalmente, los usuarios tienen dificultades para obtener las propiedades del documento de una presentación cifrada o protegida con contraseña. Aspose.Slides, sin embargo, ofrece un mecanismo que le permite proteger una presentación con contraseña mientras mantiene la posibilidad de que los usuarios accedan a sus propiedades.

**Nota** que cuando Aspose.Slides cifra una presentación, las propiedades del documento de la presentación también se protegen con contraseña por defecto. Pero si necesita que las propiedades de la presentación sean accesibles (incluso después de que la presentación se haya cifrado), Aspose.Slides le permite hacerlo precisamente. 

Si desea que los usuarios conserven la capacidad de acceder a las propiedades de una presentación que ha cifrado, puede establecer la propiedad [EncryptDocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/) en `True`. Este ejemplo de código muestra cómo cifrar una presentación mientras se brinda a los usuarios el acceso a sus propiedades del documento:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.encrypt_document_properties = True
    pres.protection_manager.encrypt("123123")
```

## **Comprobar si una presentación está protegida con contraseña antes de cargarla**

Antes de cargar una presentación, puede que desee comprobar y confirmar que la presentación no está protegida con contraseña. De esta forma, evita errores y problemas similares que aparecen cuando se carga una presentación protegida sin su contraseña.

Este código Python muestra cómo examinar una presentación para ver si está protegida con contraseña (sin cargar la presentación propiamente dicha):

```python
import aspose.slides as slides

presentationInfo = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print("The presentation is password protected: " + str(presentationInfo.is_password_protected))
```

## **Comprobar si una presentación está cifrada**

Aspose.Slides le permite comprobar si una presentación está cifrada. Para realizar esta tarea, puede usar la propiedad [is_encrypted](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/), que devuelve `True` si la presentación está cifrada o `False` si no lo está. 

Este ejemplo de código muestra cómo comprobar si una presentación está cifrada:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    print(str(pres.protection_manager.is_encrypted))
```

## **Comprobar si una presentación tiene protección contra escritura**

Aspose.Slides le permite comprobar si una presentación tiene protección contra escritura. Para realizar esta tarea, puede usar la propiedad [is_write_protected](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/), que devuelve `True` si la presentación está protegida contra escritura o `False` si no lo está. 

Este ejemplo de código muestra cómo comprobar si una presentación tiene protección contra escritura:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    print(str(pres.protection_manager.is_write_protected))
```

## **Validar o confirmar que se ha usado una contraseña específica para proteger una presentación**

Puede que desee comprobar y confirmar que se ha usado una contraseña específica para proteger un documento de presentación. Aspose.Slides le brinda los medios para validar una contraseña. 

Este ejemplo de código muestra cómo validar una contraseña:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    # comprobar si "pass" coincide con
    matched = pres.protection_manager.check_write_protection("my_password")
    print(str(matched))
```

Devuelve `True` si la presentación ha sido cifrada con la contraseña especificada. De lo contrario, devuelve `False`. 

{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/es/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Preguntas frecuentes**

**¿Qué métodos de cifrado admite Aspose.Slides?**

Aspose.Slides admite métodos de cifrado modernos, incluidos algoritmos basados en AES, garantizando un alto nivel de seguridad de datos para sus presentaciones.

**¿Qué ocurre si se introduce una contraseña incorrecta al intentar abrir una presentación?**

Se lanza una excepción si se utiliza una contraseña incorrecta, alertándole de que el acceso a la presentación está denegado. Esto ayuda a prevenir accesos no autorizados y protege el contenido de la presentación.

**¿Existen implicaciones de rendimiento al trabajar con presentaciones protegidas con contraseña?**

El proceso de cifrado y descifrado puede introducir una ligera sobrecarga durante las operaciones de apertura y guardado. En la mayoría de los casos, este impacto en el rendimiento es mínimo y no afecta significativamente el tiempo de procesamiento total de sus tareas con presentaciones.