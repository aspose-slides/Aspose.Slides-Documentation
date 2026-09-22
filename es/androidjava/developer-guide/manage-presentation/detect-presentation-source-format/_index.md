---
title: Determinar el formato original de la presentación en Android
linktitle: Formato de origen
type: docs
weight: 35
url: /es/androidjava/detect-presentation-source-format/
keywords:
- formato de origen
- detectar formato de presentación
- PowerPoint
- OpenDocument
- presentación
- PPT
- PPTX
- Android
- Java
- Aspose.Slides
description: "Lea el formato original de una presentación cargada en Android con Aspose.Slides para Android mediante Java, compare las APIs de detección y gestione archivos, flujos y formatos heredados."
---
## **Descripción general**

Después de cargar una presentación, llame al método [Presentation.getSourceFormat](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/#getSourceFormat--) para determinar su formato original. El método también está disponible a través de [IPresentation.getSourceFormat](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ipresentation/#getSourceFormat--). Úselo cuando el procesamiento posterior dependa del formato con el que se cargó la instancia actual.

El formato de origen es distinto del [SaveFormat](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/saveformat/) seleccionado para un archivo de salida. Guardar en otro formato no cambia el formato de origen de la instancia existente.

Los ejemplos usan Java y rutas de archivo. En Android, sustituya las rutas de ejemplo por rutas en el almacenamiento accesible por la aplicación, como el directorio de archivos internos de su aplicación.

## **Leer el formato de origen de un archivo**

Este ejemplo requiere un archivo `sample.pptx` existente. Carga el archivo y selecciona una política de procesamiento de la aplicación usando [Presentation.getSourceFormat](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/#getSourceFormat--), en lugar del nombre de archivo. Cambie la ruta de entrada para probar otros formatos. El ejemplo muestra la política seleccionada; reemplace los mensajes con la lógica de su aplicación.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SourceFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    switch (presentation.getSourceFormat()) {
        case SourceFormat.Ppt:
        case SourceFormat.Pps:
        case SourceFormat.Pot:
            System.out.println("Use the legacy PowerPoint processing policy.");
            break;
        case SourceFormat.Pptx:
            System.out.println("Use the standard PPTX processing policy.");
            break;
        default:
            System.out.println("Use the general policy for source format " + presentation.getSourceFormat() + ".");
            break;
    }
} finally {
    presentation.dispose();
}
```

## **Reconocer los valores compatibles**

La clase [SourceFormat](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/sourceformat/) define constantes enteras que distinguen los siguientes formatos de presentación. Las extensiones que aparecen a continuación son extensiones convencionales, no una reconstrucción del nombre de archivo original.

| Valor de SourceFormat | Extensión | Formato |
| --- | --- | --- |
| `Ppt` | `.ppt` | Presentación PowerPoint 97–2003 |
| `Pptx` | `.pptx` | Presentación Office Open XML |
| `Pptm` | `.pptm` | Presentación Office Open XML con macros |
| `Pps` | `.pps` | Presentación de diapositivas PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | Presentación de diapositivas Office Open XML |
| `Ppsm` | `.ppsm` | Presentación de diapositivas Office Open XML con macros |
| `Pot` | `.pot` | Plantilla PowerPoint 97–2003 |
| `Potx` | `.potx` | Plantilla Office Open XML |
| `Potm` | `.potm` | Plantilla Office Open XML con macros |
| `Odp` | `.odp` | Presentación OpenDocument |
| `Otp` | `.otp` | Plantilla de presentación OpenDocument |
| `Fodp` | `.fodp` | Presentación ODF XML plano |
| `Xml` | `.xml` | Presentación PowerPoint XML |

## **Leer el formato de origen de un flujo**

Este ejemplo requiere un archivo `sample.pps` existente. Leer sus bytes en un flujo de memoria modela una entrada recibida sin nombre de archivo, como un valor de base de datos o un arreglo de bytes subido. El constructor de [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/) recibe solo el flujo.

```java
import com.aspose.slides.Presentation;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.ByteArrayOutputStream;
import java.io.FileInputStream;

try {
    byte[] bytes;
    try (FileInputStream input = new FileInputStream("sample.pps");
         ByteArrayOutputStream output = new ByteArrayOutputStream()) {
        byte[] buffer = new byte[8192];
        int bytesRead;
        while ((bytesRead = input.read(buffer)) != -1) {
            output.write(buffer, 0, bytesRead);
        }
        bytes = output.toByteArray();
    }
    try (ByteArrayInputStream stream = new ByteArrayInputStream(bytes)) {
        Presentation presentation = new Presentation(stream);
        try {
            System.out.println("Source format: " + presentation.getSourceFormat());
        } finally {
            presentation.dispose();
        }
    }
} catch (IOException exception) {
    System.err.println("Cannot read the presentation: " + exception.getMessage());
}
```

PPT, PPS y POT utilizan el mismo formato binario subyacente. Cuando se carga por ruta de archivo, la extensión puede ayudar a distinguir una presentación de diapositivas o una plantilla. Sin un nombre de archivo, el contenido heredado PPS y POT puede reportarse como `SourceFormat.Ppt`; el ejemplo PPS anterior muestra el valor entero de `SourceFormat.Ppt`.

Si su aplicación debe conservar la distinción, mantenga el nombre de archivo original o los metadatos de subtipo por separado. Una extensión es una pista útil para estos subtipos heredados, pero no debe ser la única base para identificar contenido de presentación arbitrario.

## **Comparar la detección antes y después de cargar**

Utilice [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) y [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ipresentationinfo/#getLoadFormat--) cuando necesite inspeccionar un archivo antes de cargar su modelo de objetos de presentación completo. Use [Presentation.getSourceFormat](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/#getSourceFormat--) cuando la instancia ya exista.

Este ejemplo requiere `sample.pptx` y muestra los valores enteros de `LoadFormat.Pptx` y `SourceFormat.Pptx`, respectivamente. En producción, elija la API adecuada para su etapa de procesamiento; una presentación ya cargada no necesita una segunda inspección únicamente para obtener su formato de origen.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.PresentationFactory;

String path = "sample.pptx";
IPresentationInfo information = PresentationFactory.getInstance().getPresentationInfo(path);
System.out.println("Before loading: " + information.getLoadFormat());

Presentation presentation = new Presentation(path);
try {
    System.out.println("After loading: " + presentation.getSourceFormat());
} finally {
    presentation.dispose();
}
```

Los resultados usan constantes de diferentes clases: [LoadFormat](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/loadformat/) y [SourceFormat](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/sourceformat/). No compare sus valores numéricos ni asuma que cada formato tiene resultados de detección idénticos. PowerPoint XML puede reportarse como `LoadFormat.Unknown` antes de cargar y como `SourceFormat.Xml` después de cargar.

## **Mantener separados los formatos de origen y de salida**

Este ejemplo requiere `sample.pptx` y escribe `converted.odp`. Muestra el valor entero de `SourceFormat.Pptx` tanto antes como después de guardar la instancia original. Solo la nueva instancia cargada desde el archivo ODP de salida reporta `Odp`.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    System.out.println("Before saving: " + presentation.getSourceFormat());

    presentation.save("converted.odp", SaveFormat.Odp);
    System.out.println("After saving: " + presentation.getSourceFormat());

    Presentation reopened = new Presentation("converted.odp");
    try {
        System.out.println("Reopened output: " + reopened.getSourceFormat());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Una presentación creada desde cero con `new Presentation()` reporta `SourceFormat.Pptx`. No tiene archivo de entrada: este es el valor predeterminado para una instancia recién creada, no evidencia de que se haya cargado un archivo PPTX. Controle por separado si su aplicación creó o cargó la instancia si esa distinción es importante.

## **Asignar una extensión a un formato de origen**

El siguiente ejemplo requiere `sample.pptx`. Asigna cada valor actualmente compatible de [SourceFormat](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/sourceformat/) a una extensión convencional, sin analizar el nombre de archivo de entrada. El valor por defecto evita asignar silenciosamente una extensión a un valor no reconocido.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SourceFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    String extension;
    switch (presentation.getSourceFormat()) {
        case SourceFormat.Ppt:
            extension = ".ppt";
            break;
        case SourceFormat.Pptx:
            extension = ".pptx";
            break;
        case SourceFormat.Pptm:
            extension = ".pptm";
            break;
        case SourceFormat.Pps:
            extension = ".pps";
            break;
        case SourceFormat.Ppsx:
            extension = ".ppsx";
            break;
        case SourceFormat.Ppsm:
            extension = ".ppsm";
            break;
        case SourceFormat.Pot:
            extension = ".pot";
            break;
        case SourceFormat.Potx:
            extension = ".potx";
            break;
        case SourceFormat.Potm:
            extension = ".potm";
            break;
        case SourceFormat.Odp:
            extension = ".odp";
            break;
        case SourceFormat.Otp:
            extension = ".otp";
            break;
        case SourceFormat.Fodp:
            extension = ".fodp";
            break;
        case SourceFormat.Xml:
            extension = ".xml";
            break;
        default:
            extension = null;
            break;
    }

    System.out.println(extension != null ? extension : "No extension mapping is available.");
} finally {
    presentation.dispose();
}
```

Esta asignación no convierte un archivo ni recupera un subtipo heredado PPS/POT perdido durante la carga desde un flujo. Para el guardado real, seleccione explícitamente un [SaveFormat](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/saveformat/) o utilice la conversión mostrada en [Save Presentations in Their Original Format](/slides/es/androidjava/save-presentation/#save-presentations-in-their-original-format).

## **Verificar formatos guardando y volviendo a abrir**

Este ejemplo autocontenido crea una presentación y escribe tres archivos en el directorio de trabajo, sobrescribiendo archivos con los mismos nombres. Vuelve a abrir cada salida tanto por ruta como a través de un flujo de memoria. Para PPTX y ODP, ambas vías reportan el formato guardado. Para PPS, cargar por ruta reporta `Pps`, mientras que cargar los mismos bytes sin nombre de archivo reporta `Ppt`.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.ByteArrayOutputStream;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    int[] formats = { SaveFormat.Pptx, SaveFormat.Odp, SaveFormat.Pps };
    String[] extensions = { "pptx", "odp", "pps" };

    for (int i = 0; i < formats.length; i++) {
        String path = "roundtrip." + extensions[i];
        presentation.save(path, formats[i]);

        Presentation fromFile = new Presentation(path);
        try {
            byte[] bytes;
            try (FileInputStream input = new FileInputStream(path);
                 ByteArrayOutputStream output = new ByteArrayOutputStream()) {
                byte[] buffer = new byte[8192];
                int bytesRead;
                while ((bytesRead = input.read(buffer)) != -1) {
                    output.write(buffer, 0, bytesRead);
                }
                bytes = output.toByteArray();
            }
            try (ByteArrayInputStream stream = new ByteArrayInputStream(bytes)) {
                Presentation fromStream = new Presentation(stream);
                try {
                    System.out.println(extensions[i] + ": file=" + fromFile.getSourceFormat() + ", stream=" + fromStream.getSourceFormat());
                } finally {
                    fromStream.dispose();
                }
            }
        } finally {
            fromFile.dispose();
        }
    }
} catch (IOException exception) {
    System.err.println("Cannot read a saved presentation: " + exception.getMessage());
} finally {
    presentation.dispose();
}
```

La tabla siguiente resume la identificación del formato de origen para presentaciones con extensiones coincidentes. Los nombres denotan constantes; los ejemplos en Java imprimen sus valores enteros:

| Formato guardado | SourceFormat desde ruta de archivo | SourceFormat desde flujo sin nombre |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` respectivamente | Igual que la ruta de archivo |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` respectivamente | Igual que la ruta de archivo |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` respectivamente | Igual que la ruta de archivo |
| ODP, OTP | `Odp`, `Otp` respectivamente | Igual que la ruta de archivo |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

El contenido PPS/POT se identifica como `Ppt` para flujos sin nombre. La tabla describe la identificación del formato, no la conservación de todas las características de la presentación durante la conversión.

## **Preguntas frecuentes**

**¿Guardar en ODP cambia el formato de origen de una presentación cargada desde PPTX?**

No. La instancia existente sigue reportando `Pptx`. Una instancia cargada desde el archivo ODP guardado reporta `Odp`.

**¿Puede un flujo distinguir siempre una presentación heredada, una presentación de diapositivas y una plantilla?**

No. PPT, PPS y POT comparten el formato binario. Mantenga el nombre de archivo o los metadatos de subtipo por separado cuando se requiera esa distinción.

**¿Qué API debo usar si la presentación ya está cargada?**

Lea [Presentation.getSourceFormat](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/#getSourceFormat--). Use [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) para inspección antes de cargar.