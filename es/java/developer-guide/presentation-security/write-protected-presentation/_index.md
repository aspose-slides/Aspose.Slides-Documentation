---
title: Protección contra escritura de presentaciones en Java
linktitle: Protección contra escritura
type: docs
weight: 25
url: /es/java/write-protected-presentation/
keywords:
- protección contra escritura
- PowerPoint con protección contra escritura
- contraseña para modificar
- restringir la edición de la presentación
- eliminar la protección contra escritura
- validar la contraseña de modificación
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Establecer, detectar, validar y eliminar contraseñas de protección contra escritura en presentaciones PowerPoint PPT y PPTX mediante Aspose.Slides para Java."
---
## **Introducción**

Una contraseña de protección contra escritura restringe la modificación de una presentación pero no cifra su contenido. Los usuarios pueden cargar y ver una presentación protegida contra escritura sin la contraseña. Según la aplicación, también pueden editar el contenido y guardarlo con un nombre diferente, por lo que la protección contra escritura no debe considerarse un mecanismo de confidencialidad.

Una contraseña de apertura tiene un propósito diferente: cifra la presentación y es necesaria para cargar su contenido. Para cifrar una presentación o validar una contraseña de apertura, consulte [Password-Protect Presentations](/slides/es/java/password-protected-presentation/).

Los flujos de trabajo de este artículo se aplican tanto a presentaciones PPT como PPTX. Los ejemplos utilizan archivos PPTX; al guardar en PPT, utilice la extensión `.ppt` y el formato de guardado PPT correspondiente.

## **Establecer protección contra escritura en una presentación**

Utilice [IProtectionManager.setWriteProtection](https://reference.aspose.com/slides/es/java/com.aspose.slides/iprotectionmanager/#setWriteProtection-java.lang.String-) para asignar una contraseña que permita modificar una presentación. Guardar la presentación conserva la configuración de protección.

El siguiente ejemplo establece protección contra escritura en una presentación PPTX:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("modify_password");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Cargar una presentación protegida contra escritura**

Dado que la protección contra escritura no cifra el contenido de la presentación, no se requiere contraseña para cargar la presentación. La contraseña solo es relevante al validar la autorización para modificar la presentación protegida.

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("write-protected-pres.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

No pase una contraseña de protección contra escritura a [ILoadOptions.setPassword](https://reference.aspose.com/slides/es/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-). Ese método acepta una contraseña de apertura para contenido cifrado. Si una presentación tiene ambos tipos de protección, proporcione la contraseña de apertura para cargarla y gestione la contraseña de protección contra escritura por separado.

## **Eliminar la protección contra escritura de una presentación**

Utilice [IProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/es/java/com.aspose.slides/iprotectionmanager/#removeWriteProtection--) para eliminar la restricción de modificación y, a continuación, guarde la presentación.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("write-protected-pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Comprobar si una presentación está protegida contra escritura**

Para inspeccionar un archivo sin crear una instancia completa de [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/), llame a [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/es/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) y revise [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/es/java/com.aspose.slides/ipresentationinfo/#isWriteProtected--). El método utiliza [NullableBool](https://reference.aspose.com/slides/es/java/com.aspose.slides/nullablebool/) y devuelve `NullableBool.True` cuando se detecta protección contra escritura.

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.NullableBool;
import com.aspose.slides.PresentationFactory;

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() == NullableBool.True) {
    System.out.println("The presentation is write protected.");
} else {
    System.out.println("Write protection was not detected.");
}
```

La sobrecarga de flujo de [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/es/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) proporciona la misma información para una presentación suministrada como flujo.

## **Validar una contraseña de protección contra escritura**

Utilice [IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/es/java/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-) para validar una contraseña de modificación sin cargar la presentación completa. Verifique primero [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/es/java/com.aspose.slides/ipresentationinfo/#isWriteProtected--) para que la aplicación solicite o valide una contraseña solo cuando la protección contra escritura esté presente.

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.NullableBool;
import com.aspose.slides.PresentationFactory;

IPPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() != NullableBool.True) {
    System.out.println("The presentation is not write protected.");
} else if (presentationInfo.checkWriteProtection("modify_password")) {
    System.out.println("The write-protection password is correct.");
} else {
    System.out.println("The write-protection password is incorrect.");
}
```

[IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/es/java/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-) valida solo la contraseña de protección contra escritura. No valida una contraseña de apertura ni determina si el contenido cifrado puede cargarse. Por el contrario, [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/es/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) valida únicamente una contraseña de apertura. Si ya se ha cargado una presentación completa, [IProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/es/java/com.aspose.slides/iprotectionmanager/#checkWriteProtection-java.lang.String-) ofrece la comprobación equivalente de protección contra escritura a través de su gestor de protección.

En aplicaciones de producción, no registre contraseñas ni las incluya en mensajes de diagnóstico. Evite intentos de validación repetidos e innecesarios, y mantenga las contraseñas en memoria solo el tiempo necesario.

{{% alert color="info" title="Ver también" %}}
- [Password-Protect Presentations](/slides/es/java/password-protected-presentation/)
- [Read-Only Presentations](/slides/es/java/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/es/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Preguntas frecuentes**

**¿La protección contra escritura cifra una presentación?**

No. Restringe la modificación pero deja el contenido de la presentación disponible para cargar y ver.

**¿Se requiere la contraseña de protección contra escritura para abrir una presentación?**

No. Sólo se requiere una contraseña de apertura para cargar el contenido cifrado de la presentación.

**¿Puede una presentación tener tanto una contraseña de apertura como una contraseña de protección contra escritura?**

Sí. Proporcione la contraseña de apertura mediante las opciones de carga para abrir la presentación cifrada y valide la contraseña de protección contra escritura por separado cuando se requiera autorización de modificación.