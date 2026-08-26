---
title: Proteger presentaciones con contraseña en Java
linktitle: Protección con contraseña
type: docs
weight: 20
url: /es/java/password-protected-presentation/
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
- Java
- Aspose.Slides
description: "Cifre, detecte, valide, abra y descifre presentaciones de PowerPoint PPT y PPTX protegidas con contraseña en Java con Aspose.Slides."
---
## **Visión general**

Una contraseña de apertura cifra una presentación. La contraseña correcta es necesaria para cargar y ver el contenido de la presentación, por lo que esta protección brinda confidencialidad.

Una contraseña de apertura es distinta de una contraseña de protección contra escritura. La protección contra escritura restringe la modificación pero no cifra el contenido ni impide que la presentación se cargue. Para gestionar contraseñas para modificar presentaciones, consulte [Write-Protect Presentations](/slides/es/java/write-protected-presentation/).

Los flujos de trabajo a continuación se aplican tanto a presentaciones PPT como PPTX. Los ejemplos utilizan ambos formatos cuando su comportamiento basado en archivos y en flujos es importante.

## **Cifrar una presentación con una contraseña de apertura**

Utilice [IProtectionManager.encrypt](https://reference.aspose.com/slides/es/java/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) para asignar una contraseña de apertura. Luego utilice [IPresentation.save](https://reference.aspose.com/slides/es/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) para guardar la presentación cifrada.

El siguiente ejemplo cifra una presentación PPTX:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Cargar una presentación cifrada**

Establezca [ILoadOptions.setPassword](https://reference.aspose.com/slides/es/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) con la contraseña de apertura y pase las opciones a [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/) al cargar el archivo. La carga falla cuando se requiere una contraseña de apertura pero la contraseña proporcionada falta o es incorrecta.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    // Trabajar con la presentación descifrada.
} finally {
    presentation.dispose();
}
```

## **Eliminar el cifrado de una presentación**

Cargue la presentación con su contraseña de apertura, llame a [IProtectionManager.removeEncryption](https://reference.aspose.com/slides/es/java/com.aspose.slides/iprotectionmanager/#removeEncryption--) y guarde el resultado. La presentación guardada entonces podrá cargarse sin contraseña.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Validar una contraseña de apertura antes de cargar**

Utilice [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/es/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) para obtener [IPresentationInfo](https://reference.aspose.com/slides/es/java/com.aspose.slides/ipresentationinfo/) sin crear una instancia completa de la presentación. Verifique [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/es/java/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) antes de solicitar o validar una contraseña. Cuando exista protección, valide el valor proporcionado con [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/es/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-).

### **Flujo de trabajo con ruta de archivo**

El siguiente ejemplo valida una contraseña de apertura para un archivo PPTX, pasa el valor validado a [ILoadOptions.setPassword](https://reference.aspose.com/slides/es/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-), y luego carga la presentación completa:

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;

String filePath = "protected-presentation.pptx";
String password = "open_password";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(filePath);

if (!presentationInfo.isPasswordProtected()) {
    System.out.println("The presentation does not have an opening password.");
} else if (!presentationInfo.checkPassword(password)) {
    System.out.println("The opening password is incorrect.");
} else {
    LoadOptions loadOptions = new LoadOptions();
    loadOptions.setPassword(password);

    Presentation presentation = new Presentation(filePath, loadOptions);
    try {
        System.out.println("The presentation was validated and loaded successfully.");
    } finally {
        presentation.dispose();
    }
}
```

### **Flujo de trabajo con flujo**

La sobrecarga de flujo de [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/es/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) proporciona el mismo flujo de trabajo. Restablezca la posición de un flujo buscable antes de cargar la presentación completa desde ese flujo.

El siguiente ejemplo utiliza un archivo PPT:

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;
import java.io.FileInputStream;

String password = "open_password";

FileInputStream presentationStream = new FileInputStream("protected-presentation.ppt");
try {
    IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(presentationStream);

    if (!presentationInfo.isPasswordProtected()) {
        System.out.println("The presentation does not have an opening password.");
    } else if (!presentationInfo.checkPassword(password)) {
        System.out.println("The opening password is incorrect.");
    } else {
        presentationStream.getChannel().position(0);

        LoadOptions loadOptions = new LoadOptions();
        loadOptions.setPassword(password);

        Presentation presentation = new Presentation(presentationStream, loadOptions);
        try {
            System.out.println("The presentation was validated and loaded successfully.");
        } finally {
            presentation.dispose();
        }
    }
} finally {
    presentationStream.close();
}
```

### **Valores de retorno de checkPassword**

[IPresentationInfo.checkPassword](https://reference.aspose.com/slides/es/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) devuelve `true` solo cuando la presentación tiene una contraseña de apertura y la contraseña suministrada es correcta. Devuelve `false` en cada uno de los siguientes casos:

- La contraseña es incorrecta.
- La presentación no tiene una contraseña de apertura.
- La contraseña suministrada es `null` o está vacía.

El comportamiento es el mismo para presentaciones PPT y PPTX.

## **Comprobar si una presentación cargada está cifrada**

Después de cargar una presentación con la contraseña correcta, inspeccione [IProtectionManager.isEncrypted](https://reference.aspose.com/slides/es/java/com.aspose.slides/iprotectionmanager/#isEncrypted--) para confirmar que la presentación fuente estaba cifrada. Para detectar la protección con contraseña de apertura antes de cargar, use `IPresentationInfo.isPasswordProtected` como se mostró arriba.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
    System.out.println("The presentation is encrypted: " + isEncrypted);
} finally {
    presentation.dispose();
}
```

## **Recomendaciones de seguridad**

{{% alert color="warning" title="Seguridad" %}}
No registre contraseñas de apertura ni las incluya en mensajes de diagnóstico. Evite intentos de validación repetidos e innecesarios, conserve las contraseñas en memoria solo el tiempo necesario y reutilice un resultado de validación exitoso al cargar inmediatamente la presentación.
{{% /alert %}}

## **Proteger una presentación con contraseña en línea**

1. Abra la aplicación [Aspose.Slides Lock](https://products.aspose.app/slides/es/lock).
1. Seleccione o cargue la presentación.
1. Introduzca una contraseña para la protección de visualización.
1. Opcionalmente introduzca una contraseña distinta para la protección de edición.
1. Aplique la protección y descargue el archivo resultante.

{{% alert color="info" title="Ver también" %}}
- [Write-Protect Presentations](/slides/es/java/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/es/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**¿Cuál es la diferencia entre una contraseña de apertura y una contraseña de protección contra escritura?**

Una contraseña de apertura cifra la presentación y es necesaria para cargar su contenido. Una contraseña de protección contra escritura restringe la modificación sin cifrar el contenido.

**¿Puedo validar una contraseña de apertura sin cargar todas las diapositivas?**

Sí. Obtenga la información de la presentación, compruebe si existe protección con contraseña de apertura y valide la contraseña antes de crear una instancia completa de la presentación.

**¿Los flujos de trabajo de comprobación de contraseñas son compatibles tanto con PPT como con PPTX?**

Sí. La detección y validación de contraseñas basadas en ruta de archivo y en flujo se comportan de la misma manera para presentaciones PPT y PPTX.