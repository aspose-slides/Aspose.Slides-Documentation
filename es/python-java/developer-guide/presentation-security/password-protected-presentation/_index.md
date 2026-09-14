---
title: Proteger presentaciones con contraseña en Python
linktitle: Protección con contraseña
type: docs
weight: 20
url: /es/python-java/password-protected-presentation/
keywords:
- presentación protegida con contraseña
- contraseña de apertura
- cifrar PowerPoint
- descifrar PowerPoint
- validar la contraseña de la presentación
- comprobar la contraseña de la presentación
- abrir presentación cifrada
- eliminar el cifrado
- PowerPoint
- PPT
- PPTX
- presentación
- Python
- Aspose.Slides
description: "Cifre, detecte, valide, abra y descifre presentaciones de PowerPoint PPT y PPTX protegidas con contraseña con Aspose.Slides para Python a través de Java."
---
## **Visión general**

Una contraseña de apertura cifra una presentación. La contraseña correcta es obligatoria para cargar y ver el contenido de la presentación, por lo que esta protección brinda confidencialidad.

Una contraseña de apertura es distinta de una contraseña de protección contra escritura. La protección contra escritura restringe la modificación pero no cifra el contenido ni impide que la presentación se cargue. Para gestionar contraseñas para modificar presentaciones, vea [Write-Protect Presentations](/slides/es/python-java/write-protected-presentation/).

Los flujos de trabajo a continuación se aplican tanto a presentaciones PPT como PPTX. Los ejemplos usan ambos formatos cuando su comportamiento basado en archivos y en streams es importante.

## **Cifrar una presentación con una contraseña de apertura**

Utilice [ProtectionManager.encrypt](https://reference.aspose.com/slides/es/python-java/aspose.slides/protectionmanager/#encrypt) para asignar una contraseña de apertura. Luego use [Presentation.save](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#save) para guardar la presentación cifrada.

El siguiente ejemplo cifra una presentación PPTX:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.getProtectionManager().encrypt("open_password")
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Mantener públicas las propiedades del documento**

De forma predeterminada, Aspose.Slides incluye las propiedades del documento en el cifrado de la presentación. El método [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/es/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) controla este comportamiento de forma independiente al cifrado del contenido de las diapositivas. Pase `False` antes de llamar a [ProtectionManager.encrypt](https://reference.aspose.com/slides/es/python-java/aspose.slides/protectionmanager/#encrypt) cuando un sistema de indexado, clasificación, búsqueda o gestión documental necesite leer los metadatos sin la contraseña de apertura.

El siguiente ejemplo crea una presentación PPTX cifrada dejando sus propiedades de documento incorporadas públicas:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    properties = presentation.getDocumentProperties()
    properties.setAuthor("Contoso Knowledge Management")
    properties.setTitle("Quarterly Product Roadmap")
    properties.setKeywords("roadmap, planning, internal")

    presentation.getSlides().get_Item(0).setName("Encrypted presentation content")
    presentation.getProtectionManager().setEncryptDocumentProperties(False)
    presentation.getProtectionManager().encrypt("open_password")
    presentation.save("public-properties-encrypted.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Pasar `False` a [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/es/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) no hace públicas las diapositivas, maestros, diseños, formas, medios u otro contenido de la presentación. Afecta sólo a las propiedades del documento. Para leer esas propiedades sin cargar el contenido cifrado, vea [Manage Presentation Properties](/slides/es/python-java/presentation-properties/).

## **Cargar una presentación cifrada**

Establezca [LoadOptions.setPassword](https://reference.aspose.com/slides/es/python-java/aspose.slides/loadoptions/#setPassword) con la contraseña de apertura y pase las opciones a [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) al cargar el archivo. La carga falla cuando se requiere una contraseña de apertura pero la contraseña suministrada falta o es incorrecta.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-pres.pptx", load_options)
try:
    # Trabajar con la presentación descifrada.
    pass
finally:
    presentation.dispose()
```

## **Eliminar el cifrado de una presentación**

Cargue la presentación con su contraseña de apertura, llame a [ProtectionManager.removeEncryption](https://reference.aspose.com/slides/es/python-java/aspose.slides/protectionmanager/#removeEncryption) y guarde el resultado. La presentación guardada puede entonces cargarse sin contraseña.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SaveFormat

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-pres.pptx", load_options)
try:
    presentation.getProtectionManager().removeEncryption()
    presentation.save("encryption-removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Validar una contraseña de apertura antes de cargar**

Use [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentationfactory/#getPresentationInfo) para obtener [PresentationInfo](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentationinfo/) sin crear una instancia completa de la presentación. Compruebe [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentationinfo/#isPasswordProtected) antes de solicitar o validar una contraseña. Cuando la protección está presente, valide el valor suministrado con [PresentationInfo.checkPassword](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentationinfo/#checkPassword).

### **Flujo de trabajo con ruta de archivo**

El siguiente ejemplo valida una contraseña de apertura para un archivo PPTX, pasa el valor validado a [LoadOptions.setPassword](https://reference.aspose.com/slides/es/python-java/aspose.slides/loadoptions/#setPassword) y luego carga la presentación completa:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationFactory

file_path = "protected-presentation.pptx"
password = "open_password"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_path)

if not presentation_info.isPasswordProtected():
    print("The presentation does not have an opening password.")
elif not presentation_info.checkPassword(password):
    print("The opening password is incorrect.")
else:
    load_options = LoadOptions()
    load_options.setPassword(password)

    presentation = Presentation(file_path, load_options)
    try:
        print("The presentation was validated and loaded successfully.")
    finally:
        presentation.dispose()
```

### **Flujo de trabajo con secuencia**

La sobrecarga de stream de [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentationfactory/#getPresentationInfo) ofrece el mismo flujo de trabajo. Restablezca la posición de un stream posicionable antes de cargar la presentación completa desde ese stream.

El siguiente ejemplo utiliza un archivo PPT:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationFactory

FileInputStream = jpype.JClass("java.io.FileInputStream")

password = "open_password"

presentation_stream = FileInputStream("protected-presentation.ppt")
try:
    presentation_info = PresentationFactory.getInstance().getPresentationInfo(presentation_stream)

    if not presentation_info.isPasswordProtected():
        print("The presentation does not have an opening password.")
    elif not presentation_info.checkPassword(password):
        print("The opening password is incorrect.")
    else:
        presentation_stream.getChannel().position(0)

        load_options = LoadOptions()
        load_options.setPassword(password)

        presentation = Presentation(presentation_stream, load_options)
        try:
            print("The presentation was validated and loaded successfully.")
        finally:
            presentation.dispose()
finally:
    presentation_stream.close()
```

### **Valores devueltos de checkPassword**

[PresentationInfo.checkPassword](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentationinfo/#checkPassword) devuelve `True` sólo cuando la presentación tiene una contraseña de apertura y la contraseña suministrada es correcta. Devuelve `False` en cada uno de estos casos:

- La contraseña es incorrecta.
- La presentación no tiene una contraseña de apertura.
- La contraseña suministrada es `None` o está vacía.

El comportamiento es el mismo para presentaciones PPT y PPTX.

## **Comprobar si una presentación cargada está cifrada**

Después de cargar una presentación con la contraseña correcta, inspeccione [ProtectionManager.isEncrypted](https://reference.aspose.com/slides/es/python-java/aspose.slides/protectionmanager/#isEncrypted) para confirmar que la presentación origen estaba cifrada. Para detectar la protección por contraseña de apertura antes de cargar, use [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentationinfo/#isPasswordProtected) como se mostró anteriormente.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-pres.pptx", load_options)
try:
    is_encrypted = presentation.getProtectionManager().isEncrypted()
    print(f"The presentation is encrypted: {is_encrypted}")
finally:
    presentation.dispose()
```

## **Recomendaciones de seguridad**

{{% alert color="warning" title="Seguridad" %}}
No registre contraseñas de apertura ni las incluya en mensajes de diagnóstico. Evite intentos de validación repetidos innecesarios, mantenga las contraseñas en memoria sólo el tiempo necesario y reutilice un resultado de validación exitoso al cargar inmediatamente la presentación.

Las propiedades públicas del documento pueden revelar nombres de autores, títulos, asuntos, palabras clave, información de la empresa, comentarios y valores personalizados aun cuando el contenido de la presentación está cifrado. Cifre los metadatos sensibles junto con la presentación. Dejar las propiedades públicas debe ser una decisión explícita que sólo se tome cuando los sistemas deban indexar, clasificar, buscar o gestionar el archivo sin una contraseña de apertura.
{{% /alert %}}

## **Proteger con contraseña una presentación en línea**

1. Abra la aplicación [Aspose.Slides Lock](https://products.aspose.app/slides/es/lock).
1. Seleccione o cargue la presentación.
1. Introduzca una contraseña para la protección de visualización.
1. Opcionalmente, introduzca una contraseña distinta para la protección de edición.
1. Aplique la protección y descargue el archivo resultante.

{{% alert color="info" title="Véase también" %}}
- [Write-Protect Presentations](/slides/es/python-java/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/es/python-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre una contraseña de apertura y una contraseña de protección contra escritura?**

Una contraseña de apertura cifra la presentación y es necesaria para cargar su contenido. Una contraseña de protección contra escritura restringe la modificación sin cifrar el contenido.

**¿Puedo validar una contraseña de apertura sin cargar todas las diapositivas?**

Sí. Obtenga la información de la presentación, compruebe si existe protección por contraseña de apertura y valide la contraseña antes de crear una instancia completa de la presentación.

**¿Puede una aplicación leer los metadatos sin la contraseña de apertura?**

Sí, pero sólo cuando la presentación se cifró con la encriptación de propiedades del documento desactivada. La aplicación debe entonces usar el modo de carga únicamente de propiedades del documento descrito en [Manage Presentation Properties](/slides/es/python-java/presentation-properties/).

**¿Los flujos de trabajo de comprobación de contraseña admiten tanto PPT como PPTX?**

Sí. La detección y validación de contraseñas basada en rutas de archivo y en streams se comporta igual para presentaciones PPT y PPTX.