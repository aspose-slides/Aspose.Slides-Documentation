---
title: Presentaciones protegidas con contraseña en Python
linktitle: Protección con contraseña
type: docs
weight: 20
url: /es/python-net/password-protected-presentation/
keywords:
- presentación protegida con contraseña
- contraseña de apertura
- cifrar PowerPoint
- descifrar PowerPoint
- validar contraseña de presentación
- comprobar contraseña de presentación
- abrir presentación cifrada
- eliminar cifrado
- PowerPoint
- PPT
- PPTX
- presentación
- Python
- Aspose.Slides
description: "Cifrar, detectar, validar, abrir y descifrar presentaciones de PowerPoint PPT y PPTX protegidas con contraseña en Python con Aspose.Slides."
---
## **Descripción general**

Una contraseña de apertura cifra una presentación. Se requiere la contraseña correcta para cargar y ver el contenido de la presentación, por lo que esta protección brinda confidencialidad.

Una contraseña de apertura es diferente de una contraseña de protección de escritura. La protección de escritura restringe la modificación pero no cifra el contenido ni impide que se cargue la presentación. Para gestionar contraseñas para modificar presentaciones, consulte [Write-Protect Presentations](/slides/es/python-net/write-protected-presentation/).

Los flujos de trabajo a continuación se aplican tanto a presentaciones PPT como PPTX. Los ejemplos utilizan ambos formatos cuando su comportamiento basado en archivos y en flujos es importante.

## **Cifrar una presentación con una contraseña de apertura**

Utilice [ProtectionManager.encrypt](https://reference.aspose.com/slides/es/python-net/aspose.slides/protectionmanager/encrypt/) para asignar una contraseña de apertura. Luego utilice [Presentation.save](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/save/) para guardar la presentación cifrada.

El siguiente ejemplo cifra una presentación PPTX:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.encrypt("open_password")
    presentation.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Cargar una presentación cifrada**

Establezca [LoadOptions.password](https://reference.aspose.com/slides/es/python-net/aspose.slides/loadoptions/password/) a la contraseña de apertura y pase las opciones a [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/) al cargar el archivo. La carga falla cuando se requiere una contraseña de apertura pero la contraseña proporcionada falta o es incorrecta.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    # Trabajar con la presentación descifrada.
    pass
```

## **Eliminar el cifrado de una presentación**

Cargue la presentación con su contraseña de apertura, llame a [ProtectionManager.remove_encryption](https://reference.aspose.com/slides/es/python-net/aspose.slides/protectionmanager/remove_encryption/) y guarde el resultado. La presentación guardada puede entonces cargarse sin una contraseña.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    presentation.protection_manager.remove_encryption()
    presentation.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Validar una contraseña de apertura antes de cargar**

Utilice [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentationfactory/get_presentation_info/) para obtener [PresentationInfo](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentationinfo/) sin crear una instancia completa de la presentación. Verifique [PresentationInfo.is_password_protected](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentationinfo/is_password_protected/) antes de solicitar o validar una contraseña. Cuando la protección está presente, valide el valor suministrado con [PresentationInfo.check_password](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentationinfo/check_password/).

### **Flujo de trabajo con ruta de archivo**

El siguiente ejemplo valida una contraseña de apertura para un archivo PPTX, pasa el valor validado a [LoadOptions.password](https://reference.aspose.com/slides/es/python-net/aspose.slides/loadoptions/password/) y luego carga la presentación completa:

```python
import aspose.slides as slides

file_path = "protected-presentation.pptx"
password = "open_password"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_path)

if not presentation_info.is_password_protected:
    print("The presentation does not have an opening password.")
elif not presentation_info.check_password(password):
    print("The opening password is incorrect.")
else:
    load_options = slides.LoadOptions()
    load_options.password = password

    with slides.Presentation(file_path, load_options) as presentation:
        print("The presentation was validated and loaded successfully.")
```

### **Flujo de trabajo con flujo**

La sobrecarga de flujo de [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentationfactory/get_presentation_info/) proporciona el mismo flujo de trabajo. Restablezca la posición de un flujo buscable antes de cargar la presentación completa desde ese flujo.

El siguiente ejemplo utiliza un archivo PPT:

```python
import aspose.slides as slides

password = "open_password"

with open("protected-presentation.ppt", "rb") as presentation_stream:
    presentation_info = slides.PresentationFactory.instance.get_presentation_info(presentation_stream)

    if not presentation_info.is_password_protected:
        print("The presentation does not have an opening password.")
    elif not presentation_info.check_password(password):
        print("The opening password is incorrect.")
    else:
        presentation_stream.seek(0)
        load_options = slides.LoadOptions()
        load_options.password = password

        with slides.Presentation(presentation_stream, load_options) as presentation:
            print("The presentation was validated and loaded successfully.")
```

### **Valores de retorno de CheckPassword**

[PresentationInfo.check_password](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentationinfo/check_password/) devuelve `True` solo cuando la presentación tiene una contraseña de apertura y la contraseña suministrada es correcta. Devuelve `False` en cada uno de estos casos:

- La contraseña es incorrecta.
- La presentación no tiene una contraseña de apertura.
- La contraseña suministrada es `None` o está vacía.

El comportamiento es el mismo para presentaciones PPT y PPTX.

## **Comprobar si una presentación cargada está cifrada**

Después de cargar una presentación con la contraseña correcta, inspeccione [ProtectionManager.is_encrypted](https://reference.aspose.com/slides/es/python-net/aspose.slides/protectionmanager/is_encrypted/) para confirmar que la presentación original estaba cifrada. Para detectar la protección con contraseña de apertura antes de cargar, utilice `PresentationInfo.is_password_protected` como se mostró arriba.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    is_encrypted = presentation.protection_manager.is_encrypted
    print("The presentation is encrypted: " + str(is_encrypted))
```

## **Recomendaciones de seguridad**

{{% alert color="warning" title="Seguridad" %}}
No registre contraseñas de apertura ni las incluya en mensajes de diagnóstico. Evite intentos de validación repetidos innecesarios, mantenga las contraseñas en memoria solo el tiempo necesario y reutilice un resultado de validación exitoso al cargar inmediatamente la presentación.
{{% /alert %}}

## **Proteger una presentación con contraseña en línea**

1. Abra la aplicación [Aspose.Slides Lock](https://products.aspose.app/slides/es/lock).
1. Seleccione o cargue la presentación.
1. Introduzca una contraseña para la protección de visualización.
1. Opcionalmente, introduzca una contraseña distinta para la protección de edición.
1. Aplique la protección y descargue el archivo resultante.

{{% alert color="info" title="Véase también" %}}
- [Write-Protect Presentations](/slides/es/python-net/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/es/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre una contraseña de apertura y una contraseña de protección de escritura?**

Una contraseña de apertura cifra la presentación y es necesaria para cargar su contenido. Una contraseña de protección de escritura restringe la modificación sin cifrar el contenido.

**¿Puedo validar una contraseña de apertura sin cargar todas las diapositivas?**

Sí. Obtenga la información de la presentación, compruebe si hay protección con contraseña de apertura y valide la contraseña antes de crear una instancia completa de la presentación.

**¿Los flujos de trabajo de comprobación de contraseñas son compatibles tanto con PPT como con PPTX?**

Sí. La detección y validación de contraseñas basadas en rutas de archivo y en flujos se comportan de la misma manera para presentaciones PPT y PPTX.