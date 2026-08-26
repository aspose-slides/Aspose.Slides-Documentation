---
title: Proteger presentaciones contra escritura en JavaScript
linktitle: Protección contra escritura
type: docs
weight: 25
url: /es/nodejs-java/write-protected-presentation/
keywords:
- protección contra escritura
- PowerPoint con protección contra escritura
- contraseña para modificar
- restringir la edición de la presentación
- eliminar la protección contra escritura
- validar contraseña de modificación
- PowerPoint
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Establecer, detectar, validar y eliminar contraseñas de protección contra escritura en presentaciones PowerPoint PPT y PPTX utilizando Aspose.Slides para Node.js mediante Java."
---
## **Introducción**

Una contraseña de protección contra escritura restringe la modificación de una presentación pero no cifra su contenido. Los usuarios pueden cargar y ver una presentación protegida contra escritura sin la contraseña. Según la aplicación, también pueden editar el contenido y guardarlo con otro nombre, por lo que la protección contra escritura no debe considerarse un mecanismo de confidencialidad.

Una contraseña de apertura cumple un propósito diferente: cifra la presentación y es necesaria para cargar su contenido. Para cifrar una presentación o validar una contraseña de apertura, consulte [Password-Protect Presentations](/slides/es/nodejs-java/password-protected-presentation/).

Los flujos de trabajo de este artículo se aplican tanto a presentaciones PPT como PPTX. Los ejemplos utilizan archivos PPTX; al guardar en PPT, use la extensión `.ppt` y el formato de guardado correspondiente de PPT.

## **Establecer protección contra escritura en una presentación**

Utilice [ProtectionManager.setWriteProtection](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/protectionmanager/#setWriteProtection) para asignar una contraseña que modifique una presentación. Guardar la presentación persiste la configuración de protección.

El siguiente ejemplo establece protección contra escritura en una presentación PPTX:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("modify_password");
    presentation.save("write-protected-pres.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Cargar una presentación protegida contra escritura**

Dado que la protección contra escritura no cifra el contenido de la presentación, no se requiere contraseña para cargarla. La contraseña es relevante sólo al validar la autorización para modificar la presentación protegida.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("write-protected-pres.pptx");
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

No pase una contraseña de protección contra escritura a [LoadOptions.setPassword](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/loadoptions/#setPassword). Ese método acepta una contraseña de apertura para contenido cifrado. Si una presentación tiene ambos tipos de protección, proporcione la contraseña de apertura para cargarla y gestione la contraseña de protección contra escritura por separado.

## **Eliminar la protección contra escritura de una presentación**

Utilice [ProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/protectionmanager/#removeWriteProtection) para eliminar la restricción de modificación y, a continuación, guarde la presentación.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("write-protected-pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Comprobar si una presentación está protegida contra escritura**

Para inspeccionar un archivo sin crear una instancia completa de [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/), llame a [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) y examine [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentationinfo/#isWriteProtected). El método usa [NullableBool](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/nullablebool/) y devuelve `NullableBool.True` cuando se detecta protección contra escritura.

```javascript
const slides = require("aspose.slides.via.java");

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() === slides.NullableBool.True) {
    console.log("The presentation is write protected.");
} else {
    console.log("Write protection was not detected.");
}
```

El método basado en flujos [PresentationFactory.getPresentationInfoFromStream](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfoFromStream) proporciona la misma información para una presentación suministrada como un flujo legible de Node.js.

## **Validar una contraseña de protección contra escritura**

Utilice [PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentationinfo/#checkWriteProtection) para validar una contraseña de modificación sin cargar la presentación completa. Compruebe primero [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentationinfo/#isWriteProtected) de modo que la aplicación solicite o valide una contraseña sólo cuando exista protección contra escritura.

```javascript
const slides = require("aspose.slides.via.java");

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() !== slides.NullableBool.True) {
    console.log("The presentation is not write protected.");
} else if (presentationInfo.checkWriteProtection("modify_password")) {
    console.log("The write-protection password is correct.");
} else {
    console.log("The write-protection password is incorrect.");
}
```

[PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentationinfo/#checkWriteProtection) valida únicamente la contraseña de protección contra escritura. No valida una contraseña de apertura ni determina si se puede cargar contenido cifrado. Por el contrario, [PresentationInfo.checkPassword](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentationinfo/#checkPassword) valida sólo una contraseña de apertura. Si ya se ha cargado una presentación completa, [ProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/protectionmanager/#checkWriteProtection) ofrece la comprobación equivalente de protección contra escritura a través de su gestor de protección.

En aplicaciones de producción, no registre contraseñas ni las incluya en mensajes de diagnóstico. Evite intentos de validación repetidos innecesarios y conserve las contraseñas en memoria sólo el tiempo necesario.

{{% alert color="info" title="Ver también" %}}
- [Password-Protect Presentations](/slides/es/nodejs-java/password-protected-presentation/)
- [Read-Only Presentations](/slides/es/nodejs-java/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/es/nodejs-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Preguntas frecuentes**

**¿La protección contra escritura cifra una presentación?**

No. Restringe la modificación pero deja el contenido de la presentación disponible para cargar y ver.

**¿Se necesita la contraseña de protección contra escritura para abrir una presentación?**

No. Sólo se necesita una contraseña de apertura para cargar el contenido cifrado de la presentación.

**¿Puede una presentación tener tanto una contraseña de apertura como una de protección contra escritura?**

Sí. suministre la contraseña de apertura a través de las opciones de carga para abrir la presentación cifrada y valide la contraseña de protección contra escritura por separado cuando sea necesario autorizar la modificación.