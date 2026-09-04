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
- validar la contraseña de la presentación
- comprobar la contraseña de la presentación
- abrir presentación cifrada
- eliminar el cifrado
- PowerPoint
- PPT
- PPTX
- presentación
- Java
- Aspose.Slides
description: "Cifrar, detectar, validar, abrir y descifrar presentaciones de PowerPoint PPT y PPTX protegidas con contraseña en Java con Aspose.Slides."
---
## **Visión general**

Una contraseña de apertura cifra una presentación. Se requiere la contraseña correcta para cargar y ver el contenido de la presentación, por lo que esta protección brinda confidencialidad.

Una contraseña de apertura es distinta de una contraseña de protección de escritura. La protección de escritura restringe la modificación pero no cifra el contenido ni impide que la presentación se cargue. Para administrar contraseñas para modificar presentaciones, consulte [Presentaciones con protección de escritura](/slides/es/java/write-protected-presentation/).

Los flujos de trabajo a continuación se aplican tanto a presentaciones PPT como PPTX. Los ejemplos utilizan ambos formatos cuando su comportamiento basado en archivos y en flujos es importante.

## **Cifrar una presentación con una contraseña de apertura**

Utilice [IProtectionManager.encrypt](https://reference.aspose.com/slides/es/java/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) para asignar una contraseña de apertura. Después, use [IPresentation.save](https://reference.aspose.com/slides/es/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) para persistir la presentación cifrada.

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

## **Mantener las propiedades del documento públicas**

De manera predeterminada, Aspose.Slides incluye las propiedades del documento en el cifrado de la presentación. El método [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/es/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) controla este comportamiento de forma independiente al cifrado del contenido de las diapositivas. Pase `false` antes de llamar a [IProtectionManager.encrypt](https://reference.aspose.com/slides/es/java/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) cuando un sistema de indexación, clasificación, búsqueda o gestión documental deba leer los metadatos sin la contraseña de apertura.

El siguiente ejemplo crea una presentación PPTX cifrada dejando sus propiedades de documento integradas públicas:

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    IDocumentProperties properties = presentation.getDocumentProperties();
    properties.setAuthor("Contoso Knowledge Management");
    properties.setTitle("Quarterly Product Roadmap");
    properties.setKeywords("roadmap, planning, internal");

    presentation.getSlides().get_Item(0).setName("Encrypted presentation content");
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("public-properties-encrypted.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pasar `false` a [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/es/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) no hace públicas las diapositivas, maestros, diseños, formas, medios u otro contenido de la presentación. Afecta únicamente a las propiedades del documento. Para leer esas propiedades sin cargar el contenido cifrado, consulte [Administrar propiedades de la presentación](/slides/es/java/presentation-properties/).

## **Cargar una presentación cifrada**

Establezca [ILoadOptions.setPassword](https://reference.aspose.com/slides/es/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) con la contraseña de apertura y pase las opciones a [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/) al cargar el archivo. La carga falla cuando se requiere una contraseña de apertura pero la contraseña suministrada falta o es incorrecta.

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

Cargue la presentación con su contraseña de apertura, llame a [IProtectionManager.removeEncryption](https://reference.aspose.com/slides/es/java/com.aspose.slides/iprotectionmanager/#removeEncryption--) y guarde el resultado. La presentación guardada podrá cargarse posteriormente sin contraseña.

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

Utilice [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/es/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) para obtener [IPresentationInfo](https://reference.aspose.com/slides/es/java/com.aspose.slides/ipresentationinfo/) sin crear una instancia completa de la presentación. Verifique [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/es/java/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) antes de solicitar o validar una contraseña. Cuando la protección está presente, valide el valor suministrado con [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/es/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-).

### **Flujo de trabajo con ruta de archivo**

El siguiente ejemplo valida una contraseña de apertura para un archivo PPTX, pasa el valor validado a [ILoadOptions.setPassword](https://reference.aspose.com/slides/es/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) y luego carga la presentación completa:

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

El siguiente ejemplo usa un archivo PPT:

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

[IPresentationInfo.checkPassword](https://reference.aspose.com/slides/es/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) devuelve `true` solo cuando la presentación tiene una contraseña de apertura y la contraseña suministrada es correcta. Devuelve `false` en cada uno de estos casos:

- La contraseña es incorrecta.
- La presentación no tiene una contraseña de apertura.
- La contraseña suministrada es `null` o está vacía.

El comportamiento es el mismo para presentaciones PPT y PPTX.

## **Comprobar si una presentación cargada está cifrada**

Después de cargar una presentación con la contraseña correcta, inspeccione [IProtectionManager.isEncrypted](https://reference.aspose.com/slides/es/java/com.aspose.slides/iprotectionmanager/#isEncrypted--) para confirmar que la presentación origen estaba cifrada. Para detectar la protección por contraseña de apertura antes de cargar, use `IPresentationInfo.isPasswordProtected` como se mostró anteriormente.

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
No registre las contraseñas de apertura ni las incluya en mensajes de diagnóstico. Evite intentos de validación repetidos innecesarios, mantenga las contraseñas en memoria solo el tiempo necesario y reutilice un resultado de validación exitoso cuando se cargue la presentación inmediatamente.

Las propiedades públicas del documento pueden revelar nombres de autor, títulos, asuntos, palabras clave, información de la empresa, comentarios y valores personalizados aunque el contenido de la presentación esté cifrado. Cifre los metadatos sensibles junto con la presentación. Dejar las propiedades públicas debe ser una decisión explícita tomada solo cuando los sistemas deben indexar, clasificar, buscar o gestionar el archivo sin una contraseña de apertura.
{{% /alert %}}

## **Proteger una presentación con contraseña en línea**

1. Abra la aplicación [Aspose.Slides Lock](https://products.aspose.app/slides/es/lock).
1. Seleccione o cargue la presentación.
1. Introduzca una contraseña para la protección de visualización.
1. Opcionalmente introduzca una contraseña distinta para la protección de edición.
1. Aplique la protección y descargue el archivo resultante.

{{% alert color="info" title="Ver también" %}}
- [Presentaciones con protección de escritura](/slides/es/java/write-protected-presentation/)
- [Firma digital en PowerPoint](/slides/es/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre una contraseña de apertura y una contraseña de protección de escritura?**

Una contraseña de apertura cifra la presentación y es necesaria para cargar su contenido. Una contraseña de protección de escritura restringe la modificación sin cifrar el contenido.

**¿Puedo validar una contraseña de apertura sin cargar todas las diapositivas?**

Sí. Obtenga la información de la presentación, compruebe si la protección por contraseña de apertura está presente y valide la contraseña antes de crear una instancia completa de la presentación.

**¿Puede una aplicación leer los metadatos sin la contraseña de apertura?**

Sí, pero solo cuando la presentación se cifró con el cifrado de propiedades del documento desactivado. La aplicación debe entonces usar el modo de carga solo de propiedades del documento descrito en [Administrar propiedades de la presentación](/slides/es/java/presentation-properties/).

**¿Los flujos de trabajo de comprobación de contraseñas admiten tanto PPT como PPTX?**

Sí. La detección y validación de contraseñas basadas en ruta de archivo y en flujo se comportan de la misma forma para presentaciones PPT y PPTX.