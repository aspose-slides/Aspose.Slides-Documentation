---
title: Exportar presentaciones a XAML en Java
linktitle: Presentación a XAML
type: docs
weight: 30
url: /es/java/export-to-xaml/
keywords:
- exportar PowerPoint
- exportar OpenDocument
- exportar presentación
- convertir PowerPoint
- convertir OpenDocument
- convertir presentación
- PowerPoint a XAML
- OpenDocument a XAML
- presentación a XAML
- PPT a XAML
- PPTX a XAML
- ODP a XAML
- guardar PPT como XAML
- guardar PPTX como XAML
- guardar ODP como XAML
- exportar PPT a XAML
- exportar PPTX a XAML
- exportar ODP a XAML
- Java
- Aspose.Slides
description: "Convertir diapositivas de PowerPoint y OpenDocument a XAML en Java usando Aspose.Slides—solución rápida y sin Office que mantiene intacto el diseño."
---
## **Resumen**

Este artículo explica cómo exportar presentaciones de PowerPoint a XAML usando Aspose.Slides. Incluye una breve introducción a XAML, muestra cómo guardar una presentación en XAML con la configuración predeterminada y demuestra cómo personalizar la exportación mediante [XamlOptions](https://reference.aspose.com/slides/es/java/com.aspose.slides/xamloptions/), incluida la exportación de diapositivas ocultas. El artículo también responde a algunas preguntas comunes relacionadas con las fuentes de reserva, la compatibilidad con distintas pilas XAML y el comportamiento de exportación de diapositivas ocultas.

## **Acerca de XAML**

XAML es un lenguaje de marcado basado en XML utilizado para describir interfaces de usuario en frameworks como WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) y Xamarin.Forms.

Puedes trabajar con archivos XAML en un diseñador visual o escribir y editar el marcado directamente.

## **Exportar presentaciones a XAML con opciones predeterminadas**

El siguiente ejemplo en Java muestra cómo exportar una presentación a XAML con la configuración predeterminada:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions xamlOptions = new XamlOptions();
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

De forma predeterminada, las diapositivas exportadas se guardan en una subcarpeta `pres` del directorio de trabajo actual del proceso, resuelta a partir de una ruta vacía con [Paths.get](https://docs.oracle.com/javase/8/docs/api/java/nio/file/Paths.html#get-java.lang.String-java.lang.String...). La carpeta se crea automáticamente y cualquier imagen necesaria también se guarda allí.

El nombre de la carpeta de salida se toma del nombre del archivo fuente sin su extensión. Para `pres.pptx`, los archivos resultantes se nombran `pres/Slide_1.xaml`, `pres/Slide_2.xaml`, etc. Incluso si pasas una ruta absoluta a la presentación de entrada, la carpeta de salida se crea de forma relativa al directorio de trabajo actual, en lugar de junto al archivo de entrada.

## **Exportar presentaciones a XAML con opciones personalizadas**

Utiliza la interfaz [IXamlOptions](https://reference.aspose.com/slides/es/java/com.aspose.slides/ixamloptions/) para controlar cómo Aspose.Slides exporta una presentación a XAML.

Para guardar la salida en una ubicación personalizada, implementa [IXamlOutputSaver](https://reference.aspose.com/slides/es/java/com.aspose.slides/ixamloutputsaver/) y pasa una instancia de tu implementación al método [setOutputSaver](https://reference.aspose.com/slides/es/java/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) de [XamlOptions](https://reference.aspose.com/slides/es/java/com.aspose.slides/xamloptions/).

Para incluir diapositivas ocultas en la salida XAML, llama a [setExportHiddenSlides](https://reference.aspose.com/slides/es/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) con `true`, como se muestra en el siguiente ejemplo en Java:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions xamlOptions = new XamlOptions();
    xamlOptions.setExportHiddenSlides(true);
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

## **Capturar todos los artefactos XAML generados**

Una exportación XAML puede producir un documento XAML por cada diapositiva exportada, además de imágenes y recursos auxiliares separados. Asigna un [IXamlOutputSaver](https://reference.aspose.com/slides/es/java/com.aspose.slides/ixamloutputsaver/) personalizado a [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/es/java/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) para recibir estos artefactos en lugar de usar el guardador predeterminado del sistema de archivos. Inicia la exportación con la sobrecarga específica de XAML de [Presentation.save](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) que acepta opciones XAML.

### **Entender el ciclo de vida de las devoluciones de llamada**

El exportador llama a [IXamlOutputSaver.save](https://reference.aspose.com/slides/es/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) de forma independiente para cada artefacto generado:

- `path` identifica el artefacto y puede incluir directorios relativos. Conserva esta información porque XAML puede referenciar recursos mediante rutas relativas.
- `data` contiene los bytes del artefacto. Las imágenes y otros recursos binarios no deben decodificarse como texto.
- El guardador es responsable de retener o persistir los datos antes de devolver. Los ejemplos copian cada matriz de bytes en memoria propia de la aplicación.
- Considera la exportación como exitosa solo cuando la operación de guardado de la presentación devuelve y todas las devoluciones de llamada se han completado satisfactoriamente. No suprimas errores de almacenamiento ni inicies escrituras en segundo plano no observadas. Si la persistencia ocurre después, informa el éxito global solo tras también completarse ese paso.

[ XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/es/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) también se aplica a un guardador personalizado. La configuración predeterminada, `false`, excluye los documentos XAML de diapositivas ocultas. Pasar `true` los incluye junto con cualquier recurso necesario para su exportación. El recuento de recursos depende de la presentación; no asumas una devolución de llamada por diapositiva ni un orden fijo de devoluciones.

### **Exportar a memoria e inspeccionar los artefactos**

Este ejemplo completo carga `pres.pptx`, recopila cada artefacto en un [Map<String, byte[]>](https://docs.oracle.com/javase/8/docs/api/java/util/Map.html) y muestra su nombre, tipo y número de bytes. Conserva los nombres suministrados tal cual. Los nombres duplicados marcan la colección como inválida en lugar de sobrescribir silenciosamente un artefacto. El ejemplo verifica esto antes de usar los resultados.

```java
import com.aspose.slides.*;
import java.util.LinkedHashMap;
import java.util.Map;
import java.nio.charset.StandardCharsets;
import java.util.Locale;

class MemoryXamlSaver implements IXamlOutputSaver {
    final Map<String, byte[]> artifacts = new LinkedHashMap<>();
    boolean valid = true;

    @Override
    public void save(String path, byte[] data) {
        if (artifacts.containsKey(path)) {
            valid = false;
            System.err.println("Export rejected: duplicate artifact name: " + path);
            return;
        }
        byte[] retainedData = data.clone();
        artifacts.put(path, retainedData);
    }
}

MemoryXamlSaver saver = new MemoryXamlSaver();
Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions options = new XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(true);
    presentation.save(options);
} finally {
    presentation.dispose();
}

if (!saver.valid) {
    System.err.println("Export rejected: the artifact collection is invalid.");
    return;
}

boolean inspectXamlText = false;
for (Map.Entry<String, byte[]> artifact : saver.artifacts.entrySet()) {
    String name = artifact.getKey().toLowerCase(Locale.ROOT);
    boolean isXaml = name.endsWith(".xaml");
    boolean isImage = name.matches(".*\\.(png|jpg|jpeg|gif|bmp|tif|tiff|svg)$");
    String kind = isXaml ? "slide XAML" : isImage ? "image" : "supporting resource";
    System.out.println(artifact.getKey() + ": " + artifact.getValue().length + " bytes (" + kind + ")");

    // Decodificar solo XAML, y solo cuando se necesita inspección textual.
    if (isXaml && inspectXamlText) {
        String markup = new String(artifact.getValue(), StandardCharsets.UTF_8);
        System.out.println(markup);
    }
}
```

Las comprobaciones de extensión son útiles para la inspección; conserva todos los artefactos, incluidos los tipos de recurso desconocidos. No modifiques los bytes al almacenarlos o transmitirlos. Usa el constructor [String](https://docs.oracle.com/javase/8/docs/api/java/lang/String.html#String-byte:A-java.nio.charset.Charset-) con UTF-8 únicamente para XAML que requiera procesamiento textual.

### **Empaquetar los artefactos recopilados en un archivo ZIP**

Este ejemplo independiente recopila la exportación, valida sus nombres y escribe los bytes originales en un archivo ZIP. Un nombre de archivo único separa trabajos de exportación concurrentes. Las entradas ZIP utilizan barras diagonales y conservan los directorios relativos. Los nombres inseguros o que colisionan después de la normalización rechazan todo el paquete antes de escribirlo.

```java
import com.aspose.slides.*;
import java.util.LinkedHashMap;
import java.util.Map;
import java.io.IOException;
import java.io.OutputStream;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.nio.file.StandardOpenOption;
import java.util.Set;
import java.util.TreeSet;
import java.util.UUID;
import java.util.zip.ZipEntry;
import java.util.zip.ZipOutputStream;

class MemoryXamlSaver implements IXamlOutputSaver {
    final Map<String, byte[]> artifacts = new LinkedHashMap<>();
    boolean valid = true;

    @Override
    public void save(String path, byte[] data) {
        if (artifacts.containsKey(path)) {
            valid = false;
            System.err.println("Export rejected: duplicate artifact name: " + path);
            return;
        }
        byte[] retainedData = data.clone();
        artifacts.put(path, retainedData);
    }
}

MemoryXamlSaver saver = new MemoryXamlSaver();
Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions options = new XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(false);
    presentation.save(options);
} finally {
    presentation.dispose();
}

if (!saver.valid) {
    System.err.println("Export rejected: the artifact collection is invalid.");
    return;
}

Map<String, byte[]> entries = new LinkedHashMap<>();
Set<String> entryNames = new TreeSet<>(String.CASE_INSENSITIVE_ORDER);
for (Map.Entry<String, byte[]> artifact : saver.artifacts.entrySet()) {
    String entryName = artifact.getKey().replace('\\', '/');
    String[] segments = entryName.split("/", -1);
    boolean unsafeName = entryName.startsWith("/") || entryName.contains(":");
    for (String segment : segments) {
        unsafeName |= segment.trim().isEmpty() || segment.equals(".") || segment.equals("..");
    }

    if (unsafeName || !entryNames.add(entryName)) {
        System.err.println("Export rejected: unsafe or duplicate artifact name: " + artifact.getKey());
        return;
    }
    entries.put(entryName, artifact.getValue());
}

Path archivePath = Paths.get("xaml-" + UUID.randomUUID() + ".zip");
try {
    OutputStream output = Files.newOutputStream(archivePath, StandardOpenOption.CREATE_NEW, StandardOpenOption.WRITE);
    try (OutputStream archiveOutput = output; ZipOutputStream archive = new ZipOutputStream(archiveOutput)) {
        for (Map.Entry<String, byte[]> artifact : entries.entrySet()) {
            ZipEntry entry = new ZipEntry(artifact.getKey());
            archive.putNextEntry(entry);
            archive.write(artifact.getValue());
            archive.closeEntry();
        }
    }

    // El directorio ZIP se ha finalizado al cerrar antes de informar del éxito.
    System.out.println("Saved " + entries.size() + " artifacts to " + archivePath);
} catch (IOException exception) {
    System.err.println("Archive persistence failed: " + exception.getMessage());
}
```

El ejemplo usa [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) para escribir un archivo local; el exportador en sí no escribe archivos XAML o de imágenes sueltos. Para almacenamiento remoto, reemplaza la fase de escritura del archivo por cargas de los arreglos de bytes recopilados. Utiliza un identificador de trabajo de exportación más el nombre de artefacto relativo completo como clave de blob, o almacena el identificador del trabajo, el nombre relativo y los datos binarios en una fila de base de datos. Publica el trabajo solo después de que todas las cargas finalicen o la transacción de base de datos se confirme. Elimina la salida parcial si la persistencia falla.

Para presentaciones grandes, un guardador personalizado puede persistir cada artefacto directamente en el almacenamiento de la aplicación para evitar mantener una copia adicional de toda la exportación en memoria. Mantén cada devolución de llamada sincrónica desde la perspectiva del exportador: devuelve solo después de que el destino haya aceptado los bytes y permite que los errores lleguen al llamador.

### **Conservar los nombres de recursos y verificar referencias**

- Normaliza los separadores de ruta cuando el destino lo requiera, pero conserva los directorios relativos. No uses solo [Path.getFileName](https://docs.oracle.com/javase/8/docs/api/java/nio/file/Path.html#getFileName--) a menos que cada nombre generado sea conocido como único y las referencias de recursos sigan siendo válidas.
- Aplica validación de nombres específica del destino. Al escribir archivos sueltos, rechaza rutas absolutas y segmentos de travesía, resuelve el destino con [Path.toAbsolutePath](https://docs.oracle.com/javase/8/docs/api/java/nio/file/Path.html#toAbsolutePath--), y verifica que permanezca bajo el directorio de exportación previsto, incluyendo el separador de directorio en la comprobación de contención. Usa un directorio controlado por la aplicación sin enlaces simbólicos que puedan redirigir escrituras.
- Utiliza un guardador y un espacio de nombres de almacenamiento separados para cada trabajo de exportación. Detecta colisiones después de la normalización de separadores y de acuerdo con las reglas de sensibilidad a mayúsculas del destino.
- Antes de publicar, analiza cada documento XAML como XML e inspecciona sus referencias a recursos basados en archivos, como los atributos `Source` o `ImageSource` de imágenes. Resuelve cada URI relativa respecto al directorio del artefacto XAML contenedor, normaliza el nombre de almacenamiento resultante y confirma que la clave del mapa, la entrada ZIP o el objeto almacenado correspondiente exista. Trata las URIs externas y las expresiones de marcado XAML por separado de los nombres de archivo relativos.

Por ejemplo, si `pres/Slide_1.xaml` hace referencia a `images/image1.png`, el recurso almacenado debe estar disponible como `pres/images/image1.png`. Conservar solo `image1.png` rompería esa relación. Para almacenamiento de objetos, conserva la misma estructura bajo el prefijo del trabajo y haz que esas URL de recursos sean accesibles para el consumidor de XAML. Vuelve a abrir el ZIP completado para verificar los nombres de entrada y los bytes de recursos, y carga diapositivas representativas en el entorno XAML de destino para confirmar que las imágenes se resuelven correctamente.

## **Preguntas frecuentes**

**¿Cómo puedo garantizar fuentes predecibles si la fuente original no está disponible en la máquina?**

Llama a [setDefaultRegularFont](https://reference.aspose.com/slides/es/java/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) en [XamlOptions](https://reference.aspose.com/slides/es/java/com.aspose.slides/xamloptions/) — se usa como fuente de reserva durante la exportación cuando la original falta. Esto no garantiza que el XAML generado haga referencia a la fuente de reserva ni que la fuente esté disponible en la máquina de destino. Asegúrate de que las fuentes referenciadas por el XAML estén disponibles en el entorno donde se mostrará.

**¿El XAML exportado está pensado solo para WPF o puede usarse también en otras pilas XAML?**

Aspose.Slides exporta XAML de WPF a través de su API pública. La compatibilidad con otras pilas XAML, como UWP y Xamarin.Forms, no está garantizada. Prueba el marcado generado en tu entorno objetivo.

**¿Se admiten diapositivas ocultas y cómo puedo evitar que se exporten por defecto?**

De forma predeterminada, las diapositivas ocultas no se incluyen. Puedes controlar este comportamiento mediante [setExportHiddenSlides](https://reference.aspose.com/slides/es/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) en [XamlOptions](https://reference.aspose.com/slides/es/java/com.aspose.slides/xamloptions/) — mantenlo desactivado si no necesitas exportarlas.