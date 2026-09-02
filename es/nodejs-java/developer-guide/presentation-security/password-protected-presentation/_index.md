---
title: Presentaciones protegidas con contraseña en JavaScript
linktitle: Protección con contraseña
type: docs
weight: 20
url: /es/nodejs-java/password-protected-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Cifra, detecta, valida, abre y descifra presentaciones de PowerPoint PPT y PPTX protegidas con contraseña en JavaScript con Aspose.Slides."
---
## **Visión general**

Una contraseña de apertura cifra una presentación. La contraseña correcta es necesaria para cargar y ver el contenido de la presentación, por lo que esta protección proporciona confidencialidad.

Una contraseña de apertura es distinta de una contraseña de protección contra escritura. La protección contra escritura restringe la modificación pero no cifra el contenido ni impide que la presentación se cargue. Para gestionar contraseñas para modificar presentaciones, consulte [Proteger presentaciones contra escritura](/slides/es/nodejs-java/write-protected-presentation/).

Los flujos de trabajo a continuación se aplican tanto a presentaciones PPT como PPTX. Los ejemplos utilizan ambos formatos cuando su comportamiento basado en archivos y en streams es importante.

## **Cifrar una presentación con una contraseña de apertura**

Utilice [ProtectionManager.encrypt](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/protectionmanager/#encrypt) para asignar una contraseña de apertura. Luego use [Presentation.save](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/#save) para guardar la presentación cifrada.

El siguiente ejemplo cifra una presentación PPTX:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("encrypted-pres.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Cargar una presentación cifrada**

Establezca [LoadOptions.setPassword](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/loadoptions/#setPassword) con la contraseña de apertura y pase las opciones a [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/) al cargar el archivo. La carga falla cuando se requiere una contraseña de apertura pero la contraseña suministrada falta o es incorrecta.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    // Trabajar con la presentación descifrada.
} finally {
    presentation.dispose();
}
```

## **Eliminar el cifrado de una presentación**

Cargue la presentación con su contraseña de apertura, llame a [ProtectionManager.removeEncryption](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/protectionmanager/#removeEncryption) y guarde el resultado. La presentación guardada puede entonces cargarse sin una contraseña.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Validar una contraseña de apertura antes de cargar**

Utilice [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) para obtener [PresentationInfo](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentationinfo/) sin crear una instancia completa de la presentación. Compruebe [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected) antes de solicitar o validar una contraseña. Cuando la protección está presente, valide el valor suministrado con [PresentationInfo.checkPassword](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentationinfo/#checkPassword).

### **Flujo de trabajo con ruta de archivo**

La siguiente ejemplo valida una contraseña de apertura para un archivo PPTX, pasa el valor validado a [LoadOptions.setPassword](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/loadoptions/#setPassword) y luego carga la presentación completa:

```javascript
const slides = require("aspose.slides.via.java");

const filePath = "protected-presentation.pptx";
const password = "open_password";
const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo(filePath);

if (!presentationInfo.isPasswordProtected()) {
    console.log("The presentation does not have an opening password.");
} else if (!presentationInfo.checkPassword(password)) {
    console.log("The opening password is incorrect.");
} else {
    const loadOptions = new slides.LoadOptions();
    loadOptions.setPassword(password);

    const presentation = new slides.Presentation(filePath, loadOptions);
    try {
        console.log("The presentation was validated and loaded successfully.");
    } finally {
        presentation.dispose();
    }
}
```

### **Flujo de trabajo con stream**

Utilice [PresentationFactory.getPresentationInfoFromStream](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfoFromStream) para inspeccionar un stream legible de Node.js. Después de que el stream de inspección se haya consumido, cree un nuevo stream antes de cargar la presentación completa con [Presentation.createPresentationFromStream](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/#createPresentationFromStream).

El siguiente ejemplo utiliza un archivo PPT:

```javascript
const slides = require("aspose.slides.via.java");
const fs = require("fs");

const filePath = "protected-presentation.ppt";
const password = "open_password";
const presentationFactory = slides.PresentationFactory.getInstance();
const infoStream = fs.createReadStream(filePath);

slides.PresentationFactory.getPresentationInfoFromStream(presentationFactory, infoStream, function(infoError, presentationInfo) {
    if (infoError) {
        console.log("The presentation information could not be read: " + infoError.message);
    } else if (!presentationInfo.isPasswordProtected()) {
        console.log("The presentation does not have an opening password.");
    } else if (!presentationInfo.checkPassword(password)) {
        console.log("The opening password is incorrect.");
    } else {
        const loadOptions = new slides.LoadOptions();
        loadOptions.setPassword(password);
        const presentationStream = fs.createReadStream(filePath);

        slides.Presentation.createPresentationFromStream(presentationStream, loadOptions, function(loadError, presentation) {
            if (loadError) {
                console.log("The presentation could not be loaded: " + loadError.message);
            } else {
                try {
                    console.log("The presentation was validated and loaded successfully.");
                } finally {
                    presentation.dispose();
                }
            }
        });
    }
});
```

### **Valores de retorno de checkPassword**

[PresentationInfo.checkPassword](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentationinfo/#checkPassword) devuelve `true` solo cuando la presentación tiene una contraseña de apertura y la contraseña suministrada es correcta. Devuelve `false` en cada uno de los siguientes casos:

- La contraseña es incorrecta.
- La presentación no tiene una contraseña de apertura.
- La contraseña suministrada es `null` o está vacía.

El comportamiento es el mismo para presentaciones PPT y PPTX.

## **Comprobar si una presentación cargada está cifrada**

Después de cargar una presentación con la contraseña correcta, inspeccione [ProtectionManager.isEncrypted](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/protectionmanager/#isEncrypted) para confirmar que la presentación original estaba cifrada. Para detectar la protección mediante contraseña de apertura antes de cargar, utilice [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected) como se mostró arriba.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    const isEncrypted = presentation.getProtectionManager().isEncrypted();
    console.log("The presentation is encrypted: " + isEncrypted);
} finally {
    presentation.dispose();
}
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

{{% alert color="info" title="Ver también" %}}
- [Proteger presentaciones contra escritura](/slides/es/nodejs-java/write-protected-presentation/)
- [Firma digital en PowerPoint](/slides/es/nodejs-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre una contraseña de apertura y una contraseña de protección contra escritura?**

Una contraseña de apertura cifra la presentación y es necesaria para cargar su contenido. Una contraseña de protección contra escritura restringe la modificación sin cifrar el contenido.

**¿Puedo validar una contraseña de apertura sin cargar todas las diapositivas?**

Sí. Obtenga la información de la presentación, compruebe si está presente la protección mediante contraseña de apertura y valide la contraseña antes de crear una instancia completa de la presentación.

**¿Los flujos de trabajo de comprobación de contraseñas son compatibles tanto con PPT como con PPTX?**

Sí. La detección y validación de contraseñas basadas en rutas de archivo y en streams se comportan de la misma manera para presentaciones PPT y PPTX.