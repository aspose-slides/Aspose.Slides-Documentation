---
title: Exportar presentaciones a XAML en Android
linktitle: Presentación a XAML
type: docs
weight: 30
url: /es/androidjava/export-to-xaml/
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
- Android
- Java
- Aspose.Slides
description: "Convierta diapositivas de PowerPoint y OpenDocument a XAML en Java usando Aspose.Slides para Android: solución rápida, sin Office, que mantiene intacto su diseño."
---
## **Resumen**

Este artículo explica cómo exportar presentaciones de PowerPoint a XAML usando Aspose.Slides para Android a través de Java. Incluye una breve introducción a XAML, muestra cómo guardar una presentación en XAML con la configuración predeterminada y demuestra cómo personalizar la exportación mediante [XamlOptions](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/xamloptions/), incluyendo la exportación de diapositivas ocultas. El artículo también responde a algunas preguntas frecuentes relacionadas con fuentes de reserva, compatibilidad de la pila XAML y el comportamiento de exportación de diapositivas ocultas.

## **Acerca de XAML**

XAML es un lenguaje de marcado basado en XML utilizado para describir interfaces de usuario en frameworks como WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) y Xamarin.Forms.

Puede trabajar con archivos XAML en un diseñador visual o escribir y editar el marcado directamente.

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

Por defecto, las diapositivas exportadas se guardan en una subcarpeta `pres` del directorio de trabajo actual del proceso. La carpeta se crea automáticamente, y cualquier imagen requerida también se guarda allí.

El nombre de la carpeta de salida se toma del nombre del archivo fuente sin su extensión. Para `pres.pptx`, los archivos de salida se denominan `pres/Slide_1.xaml`, `pres/Slide_2.xaml`, etc. Incluso si pasa una ruta absoluta al archivo de entrada, la carpeta de salida se crea en relación con el directorio de trabajo actual, y no junto al archivo de entrada.

En Android, utilice un archivo de entrada accesible para su aplicación. El directorio de trabajo actual puede no ser escribible; utilice un guardador de salida personalizado para mantener la exportación en memoria o escribirla en el almacenamiento de la aplicación, como se muestra a continuación. El XAML generado para WPF está destinado a un consumidor compatible y no es un recurso de diseño de Android.

## **Exportar presentaciones a XAML con opciones personalizadas**

Utilice la interfaz [IXamlOptions](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ixamloptions/) para controlar cómo Aspose.Slides exporta una presentación a XAML.

Para guardar la salida en una ubicación personalizada, implemente [IXamlOutputSaver](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ixamloutputsaver/) y pase una instancia de su implementación al método [setOutputSaver](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) de [XamlOptions](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/xamloptions/).

Para incluir diapositivas ocultas en la salida XAML, llame a [setExportHiddenSlides](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) con `true`, como se muestra en el siguiente ejemplo en Java:

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

Una exportación XAML puede producir un documento XAML por cada diapositiva exportada, además de imágenes y recursos de soporte separados. Asigne un [IXamlOutputSaver](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ixamloutputsaver/) personalizado a [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) para recibir estos artefactos en lugar de utilizar el guardador de sistema de archivos predeterminado. Inicie la exportación con la sobrecarga específica de XAML de [Presentation.save](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) que acepta opciones XAML.

### **Comprender el ciclo de vida de la devolución de llamada**

El exportador llama a [IXamlOutputSaver.save](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) por separado para cada artefacto generado:

- `path` identifica el artefacto y puede incluir directorios relativos. Conserve esta información porque XAML puede referenciar recursos usando rutas relativas.
- `data` contiene los bytes del artefacto. Las imágenes y otros recursos binarios no deben decodificarse como texto.
- El guardador es responsable de retener o persistir los datos antes de devolver. Los ejemplos copian cada matriz de bytes en memoria perteneciente a la aplicación.
- Considere la exportación como exitosa solo cuando la operación de guardado de la presentación devuelve y cada devolución de llamada ha finalizado correctamente. No suprima errores de almacenamiento ni inicie escrituras en segundo plano sin observar. Si la persistencia ocurre después, informe el éxito global solo después de que también se haya completado ese paso.

[setExportHiddenSlides](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) también se aplica a un guardador personalizado. La configuración predeterminada, `false`, excluye los documentos XAML de diapositivas ocultas. Pasar `true` los incluye junto con cualquier recurso necesario para su exportación. El recuento de recursos depende de la presentación; no asuma una devolución de llamada por diapositiva ni un orden fijo de devoluciones.

### **Exportar a memoria e inspeccionar los artefactos**

Este ejemplo completo carga `pres.pptx`, recoge cada artefacto en un [Map<String, byte[]>](https://docs.oracle.com/javase/8/docs/api/java/util/Map.html) y muestra su nombre, tipo y recuento de bytes. Conserva los nombres suministrados exactamente. Los nombres duplicados marcan la colección como inválida en lugar de sobrescribir silenciosamente un artefacto. El ejemplo verifica esto antes de usar los resultados.

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

    // Decodificar solo XAML, y solo cuando se necesite una inspección textual.
    if (isXaml && inspectXamlText) {
        String markup = new String(artifact.getValue(), StandardCharsets.UTF_8);
        System.out.println(markup);
    }
}
```

Las comprobaciones de extensión son útiles para la inspección; conserve todos los artefactos, incluidos los tipos de recurso desconocidos. Deje los bytes sin modificar al almacenarlos o transmitirlos. Use el constructor de [String](https://docs.oracle.com/javase/8/docs/api/java/lang/String.html#String-byte:A-java.nio.charset.Charset-) con UTF-8 solo para XAML que requiera procesamiento textual.

### **Empaquetar los artefactos recopilados en un archivo ZIP**

Este ejemplo independiente recopila la exportación, valida sus nombres y escribe los bytes originales en un archivo ZIP. Reemplace `/path/to/app/files` por la ruta devuelta por el método [getFilesDir](https://developer.android.com/reference/android/content/Context#getFilesDir()) de su contexto Android. Un nombre de archivo único separa los trabajos de exportación concurrentes. Las entradas ZIP usan barras diagonales y conservan los directorios relativos. Los nombres inseguros o que colisionen tras la normalización rechazan todo el paquete antes de escribirlo.

```java
import com.aspose.slides.*;
import java.util.LinkedHashMap;
import java.util.Map;
import java.io.IOException;
import java.io.File;
import java.io.FileOutputStream;
import java.util.Set;
import java.util.TreeSet;
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

File exportDirectory = new File("/path/to/app/files");
try {
    File archiveFile = File.createTempFile("xaml-", ".zip", exportDirectory);
    try (FileOutputStream archiveOutput = new FileOutputStream(archiveFile); ZipOutputStream archive = new ZipOutputStream(archiveOutput)) {
        for (Map.Entry<String, byte[]> artifact : entries.entrySet()) {
            ZipEntry entry = new ZipEntry(artifact.getKey());
            archive.putNextEntry(entry);
            archive.write(artifact.getValue());
            archive.closeEntry();
        }
    }

    // El directorio ZIP se ha finalizado al cerrar antes de informar del éxito.
    System.out.println("Saved " + entries.size() + " artifacts to " + archiveFile);
} catch (IOException exception) {
    System.err.println("Archive persistence failed: " + exception.getMessage());
}
```

El ejemplo utiliza [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) para escribir un único archivo de archivo; el exportador en sí no escribe archivos XAML o de imagen sueltos. Para almacenamiento remoto, reemplace la fase de escritura del archivo por cargas de los arrays de bytes recopilados. Use un identificador de trabajo de exportación más el nombre relativo completo del artefacto como clave de blob, o almacene el identificador del trabajo, el nombre relativo y los datos binarios en una fila de base de datos. Publique el trabajo solo después de que se completen todas las cargas o se confirme la transacción de la base de datos. Limpie la salida parcial si la persistencia falla.

Para presentaciones grandes, un guardador personalizado puede persistir cada artefacto directamente en el almacenamiento de la aplicación para evitar mantener una copia adicional de toda la exportación en memoria. Mantenga cada devolución de llamada síncrona desde la perspectiva del exportador: devuelva solo después de que el destino haya aceptado los bytes y permita que los fallos lleguen al llamador.

### **Conservar los nombres de recursos y verificar referencias**

- Normalice los separadores de ruta cuando el destino lo requiera, pero conserve los directorios relativos. No use solo [File.getName](https://developer.android.com/reference/java/io/File#getName()) a menos que cada nombre generado sea conocido como único y las referencias de recursos sigan siendo válidas.
- Aplique la validación de nombres específica del destino. Al escribir archivos sueltos, rechace rutas ancladas y segmentos de recorrido, resuelva el destino con [File.getCanonicalPath](https://developer.android.com/reference/java/io/File#getCanonicalPath()), y verifique que permanezca bajo el directorio de exportación previsto, incluyendo el separador de directorio en la verificación de contención. Use un directorio controlado por la aplicación sin enlaces simbólicos que puedan redirigir escrituras.
- Use un guardador y un espacio de nombres de almacenamiento separados para cada trabajo de exportación. Detecte colisiones tras la normalización de separadores y según las reglas de sensibilidad a mayúsculas del destino.
- Antes de publicar, analice cada documento XAML como XML e inspeccione sus referencias a recursos basados en archivos, como atributos `Source` o `ImageSource` de imágenes. Resuelva cada URI relativa contra el directorio del artefacto XAML contenedor, normalice el nombre de almacenamiento resultante y confirme que la clave del mapa, la entrada ZIP o el objeto almacenado correspondiente existan. Trate las URIs externas y las expresiones de marcado XAML por separado de los nombres de archivo relativos.

Por ejemplo, si `pres/Slide_1.xaml` hace referencia a `images/image1.png`, el recurso almacenado debe estar disponible como `pres/images/image1.png`. Mantener solo `image1.png` rompería esa relación. Para el almacenamiento de objetos, conserve la misma estructura bajo el prefijo del trabajo y haga que esas URL de recursos estén accesibles para el consumidor de XAML. Vuelva a abrir el ZIP completado para verificar los nombres de entrada y los bytes de los recursos, y cargue diapositivas representativas en el entorno XAML de destino para confirmar que las imágenes se resuelvan correctamente.

## **Preguntas frecuentes**

**¿Cómo puedo garantizar fuentes predecibles si la fuente original no está disponible en la máquina?**

Llame a [setDefaultRegularFont](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) en [XamlOptions](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/xamloptions/) — se utiliza como fuente de reserva durante la exportación cuando falta la original. Esto no garantiza que el XAML generado haga referencia a la fuente de reserva o que la fuente esté disponible en la máquina de destino. Asegúrese de que las fuentes referenciadas por el XAML estén disponibles en el entorno donde se muestre.

**¿El XAML exportado está pensado solo para WPF o puede usarse también en otras pilas XAML?**

Aspose.Slides exporta XAML para WPF a través de su API pública. La compatibilidad con otras pilas XAML, como UWP y Xamarin.Forms, no está garantizada. Pruebe el marcado generado en su entorno objetivo.

**¿Se admiten diapositivas ocultas y cómo puedo evitar que se exporten por defecto?**

Por defecto, las diapositivas ocultas no se incluyen. Puede controlar este comportamiento mediante [setExportHiddenSlides](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) en [XamlOptions](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/xamloptions/) — manténgalo desactivado si no necesita exportarlas.