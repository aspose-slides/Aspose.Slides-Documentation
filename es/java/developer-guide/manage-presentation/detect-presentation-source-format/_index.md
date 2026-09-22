---
title: Determinar el formato original de la presentación en Java
linktitle: Formato de origen
type: docs
weight: 35
url: /es/java/detect-presentation-source-format/
keywords:
- formato de origen
- detectar formato de presentación
- PowerPoint
- OpenDocument
- presentación
- PPT
- PPTX
- Java
- Aspose.Slides
description: "Lea el formato original de una presentación cargada en Java con Aspose.Slides for Java, compare las API de detección y gestione archivos, flujos y formatos heredados."
---
## **Visión general**

Después de cargar una presentación, llame al [Presentation.getSourceFormat](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/#getSourceFormat--) método para determinar su formato original. El método también está disponible a través de [IPresentation.getSourceFormat](https://reference.aspose.com/slides/es/java/com.aspose.slides/ipresentation/#getSourceFormat--). Úselo cuando el procesamiento posterior dependa del formato con el que se cargó la instancia actual.

El formato de origen es distinto del [SaveFormat](https://reference.aspose.com/slides/es/java/com.aspose.slides/saveformat/) seleccionado para un archivo de salida. Guardar en otro formato no cambia el formato de origen de la instancia existente.

## **Leer el formato de origen de un archivo**

Este ejemplo requiere un archivo `sample.pptx` existente. Carga el archivo y selecciona una política de procesamiento de la aplicación usando [Presentation.getSourceFormat](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/#getSourceFormat--), en lugar del nombre de archivo. Cambie la ruta de entrada para probar otros formatos. El ejemplo imprime la política seleccionada; reemplace los mensajes con la lógica de su aplicación.

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

## **Reconocer los valores admitidos**

La clase [SourceFormat](https://reference.aspose.com/slides/es/java/com.aspose.slides/sourceformat/) define constantes enteras que distinguen los siguientes formatos de presentación. Las extensiones a continuación son extensiones convencionales, no una reconstrucción del nombre de archivo original.

| Valor de SourceFormat | Extensión | Formato |
| --- | --- | --- |
| `Ppt` | `.ppt` | Presentación PowerPoint 97–2003 |
| `Pptx` | `.pptx` | Presentación Office Open XML |
| `Pptm` | `.pptm` | Presentación Office Open XML con macros |
| `Pps` | `.pps` | Show de diapositivas PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | Show de diapositivas Office Open XML |
| `Ppsm` | `.ppsm` | Show de diapositivas Office Open XML con macros |
| `Pot` | `.pot` | Plantilla PowerPoint 97–2003 |
| `Potx` | `.potx` | Plantilla Office Open XML |
| `Potm` | `.potm` | Plantilla Office Open XML con macros |
| `Odp` | `.odp` | Presentación OpenDocument |
| `Otp` | `.otp` | Plantilla de presentación OpenDocument |
| `Fodp` | `.fodp` | Presentación ODF XML plano |
| `Xml` | `.xml` | Presentación PowerPoint XML |

## **Leer el formato de origen de un flujo**

Este ejemplo requiere un archivo `sample.pps` existente. Leer sus bytes en un flujo de memoria modela una entrada recibida sin nombre de archivo, como un valor de base de datos o un arreglo de bytes cargado. El constructor [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/) recibe sólo el flujo.

```java
import com.aspose.slides.Presentation;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

try {
    byte[] bytes = Files.readAllBytes(Paths.get("sample.pps"));
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

PPT, PPS y POT usan el mismo formato binario subyacente. Al cargar por ruta de archivo, la extensión puede ayudar a distinguir un show de diapositivas o una plantilla. Sin un nombre de archivo, el contenido heredado de PPS y POT puede informarse como `SourceFormat.Ppt`; el ejemplo PPS anterior imprime el valor entero de `SourceFormat.Ppt`.

Si su aplicación debe preservar la distinción, conserve el nombre de archivo original o los metadatos de subtipo por separado. Una extensión es una pista útil para estos subtipos heredados, pero no debe ser la única base para identificar contenido de presentación arbitrario.

## **Comparar la detección antes y después de la carga**

Utilice [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) y [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/es/java/com.aspose.slides/ipresentationinfo/#getLoadFormat--) cuando necesite inspeccionar un archivo antes de cargar su modelo de objetos de presentación completo. Utilice [Presentation.getSourceFormat](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/#getSourceFormat--) cuando la instancia ya exista.

Este ejemplo requiere `sample.pptx` e imprime los valores enteros de `LoadFormat.Pptx` y `SourceFormat.Pptx`, respectivamente. En producción, elija la API adecuada para su etapa de procesamiento; una presentación ya cargada no necesita una segunda inspección solo para obtener su formato de origen.

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

Los resultados utilizan constantes de distintas clases: [LoadFormat](https://reference.aspose.com/slides/es/java/com.aspose.slides/loadformat/) y [SourceFormat](https://reference.aspose.com/slides/es/java/com.aspose.slides/sourceformat/). No compare sus valores numéricos ni asuma que cada formato tiene resultados de detección idénticos. PowerPoint XML puede informarse como `LoadFormat.Unknown` antes de la carga y `SourceFormat.Xml` después de la carga.

## **Mantener separados los formatos de origen y de salida**

Este ejemplo requiere `sample.pptx` y escribe `converted.odp`. Imprime el valor entero de `SourceFormat.Pptx` tanto antes como después de guardar la instancia original. Sólo la nueva instancia cargada desde la salida ODP informa `Odp`.

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

Una presentación creada desde cero con `new Presentation()` informa `SourceFormat.Pptx`. No tiene archivo de entrada: este es el valor predeterminado para una instancia recién creada, no evidencia de que se haya cargado un archivo PPTX. Controle si su aplicación creó o cargó la instancia por separado si esa distinción es importante.

## **Mapear un formato de origen a una extensión**

El siguiente ejemplo requiere `sample.pptx`. Asigna cada valor actualmente admitido de [SourceFormat](https://reference.aspose.com/slides/es/java/com.aspose.slides/sourceformat/) a una extensión convencional, sin analizar el nombre de archivo de entrada. La alternativa evita asignar silenciosamente una extensión a un valor no reconocido.

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

Este mapeo no convierte un archivo ni recupera un subtipo heredado PPS/POT perdido durante la carga del flujo. Para el guardado real, seleccione un [SaveFormat](https://reference.aspose.com/slides/es/java/com.aspose.slides/saveformat/) explícitamente, o use la conversión mostrada en [Save Presentations in Their Original Format](/slides/es/java/save-presentation/#save-presentations-in-their-original-format).

## **Verificar formatos guardando y volviendo a abrir**

Este ejemplo autónomo crea una presentación y escribe tres archivos en el directorio de trabajo, sobrescribiendo archivos con los mismos nombres. Vuelve a abrir cada salida tanto por ruta como a través de un flujo de memoria. Para PPTX y ODP, ambas rutas informan el formato guardado. Para PPS, la carga por ruta informa `Pps`, mientras que la carga de los mismos bytes sin nombre de archivo informa `Ppt`.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    int[] formats = { SaveFormat.Pptx, SaveFormat.Odp, SaveFormat.Pps };
    String[] extensions = { "pptx", "odp", "pps" };

    for (int i = 0; i < formats.length; i++) {
        String path = "roundtrip." + extensions[i];
        presentation.save(path, formats[i]);

        Presentation fromFile = new Presentation(path);
        try {
            byte[] bytes = Files.readAllBytes(Paths.get(path));
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

La tabla siguiente resume la identificación del formato de origen para presentaciones con extensiones coincidentes. Los nombres denotan constantes; los ejemplos Java imprimen sus valores enteros:

| Formato guardado | SourceFormat desde una ruta de archivo | SourceFormat desde un flujo sin nombre |
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

El contenido PPS/POT se identifica como `Ppt` para flujos sin nombre. La tabla describe la identificación del formato, no la preservación de cada característica de la presentación durante la conversión.

## **FAQ**

**¿Guardar en ODP cambia el formato de origen de una presentación cargada desde PPTX?**

No. La instancia existente sigue informando `Pptx`. Una instancia cargada desde el archivo ODP guardado informa `Odp`.

**¿Puede un flujo distinguir siempre una presentación heredada, un show de diapositivas y una plantilla?**

No. PPT, PPS y POT comparten el formato binario. Mantenga el nombre de archivo o los metadatos de subtipo por separado cuando sea necesario preservar esa distinción.

**¿Qué API debo usar si la presentación ya está cargada?**

Lea [Presentation.getSourceFormat](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/#getSourceFormat--). Use [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) para inspección antes de la carga.