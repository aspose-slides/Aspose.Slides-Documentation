---
title: Exportar presentaciones a XAML en JavaScript
linktitle: Presentación a XAML
type: docs
weight: 30
url: /es/nodejs-java/export-to-xaml/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Convertir diapositivas de PowerPoint y OpenDocument a XAML en JavaScript usando Aspose.Slides—solución rápida, sin Office, que mantiene intacto el diseño."
---
## **Visión general**

Este artículo explica cómo exportar presentaciones de PowerPoint a XAML usando Aspose.Slides. Incluye una breve introducción a XAML, muestra cómo guardar una presentación en XAML con la configuración predeterminada y demuestra cómo personalizar la exportación mediante [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/), incluida la exportación de diapositivas ocultas. El artículo también responde a algunas preguntas frecuentes relacionadas con fuentes de respaldo, compatibilidad de pilas XAML y el comportamiento de exportación de diapositivas ocultas.

## **Acerca de XAML**

XAML es un lenguaje de marcado basado en XML utilizado para describir interfaces de usuario en frameworks como WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) y Xamarin.Forms.

Puede trabajar con archivos XAML en un diseñador visual o escribir y editar el marcado directamente.

## **Exportar presentaciones a XAML con opciones predeterminadas**

El siguiente ejemplo de JavaScript muestra cómo exportar una presentación a XAML con la configuración predeterminada:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const xamlOptions = new aspose.slides.XamlOptions();
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

De forma predeterminada, las diapositivas exportadas se guardan en una subcarpeta `input` del directorio de trabajo actual del proceso. La carpeta se crea automáticamente y también se guardan allí las imágenes necesarias.

El nombre de la carpeta de salida se toma del nombre del archivo fuente sin su extensión. En Aspose.Slides para Node.js a través de Java 26.8, exportar `input.pptx` produce una ruta anidada como `input/input/Slide_1.xaml`. Preserve las rutas generadas completas al manejar la salida. La salida predeterminada es relativa al directorio de trabajo actual, en lugar de estar necesariamente junto al archivo de entrada.

## **Exportar presentaciones a XAML con opciones personalizadas**

Utilice la interfaz [IXamlOptions](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloptions/) para controlar cómo Aspose.Slides exporta una presentación a XAML.

Para guardar la salida en una ubicación personalizada, implemente [IXamlOutputSaver](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloutputsaver/) y pase una instancia de su implementación al método [setOutputSaver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) de [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/).

Para incluir diapositivas ocultas en la salida XAML, llame a [setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) con `true`, como se muestra en el siguiente ejemplo de JavaScript:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const xamlOptions = new aspose.slides.XamlOptions();
    xamlOptions.setExportHiddenSlides(true);
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

## **Capturar todos los artefactos XAML generados**

Una exportación XAML puede producir un documento XAML para cada diapositiva exportada más imágenes separadas y recursos de apoyo. Asigne un [IXamlOutputSaver](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloutputsaver/) personalizado a [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) para recibir estos artefactos en lugar de usar el guardador predeterminado del sistema de archivos. Inicie la exportación con la sobrecarga específica de XAML de [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save) que acepta opciones XAML.

En Node.js, implemente la interfaz Java con `java.newProxy` del paquete `java` utilizado por Aspose.Slides. Mantenga el proxy accesible hasta que la exportación finalice.

### **Entender el ciclo de vida de la devolución de llamada**

El exportador llama a [IXamlOutputSaver.save](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) por separado para cada artefacto generado:

- `path` identifica el artefacto y puede incluir directorios relativos. Conserve esta información porque XAML puede referenciar recursos mediante rutas relativas.
- `data` contiene los bytes del artefacto. Las imágenes y otros recursos binarios no deben decodificarse como texto.
- El guardador es responsable de retener o persistir los datos antes de devolver. Los ejemplos copian cada matriz de bytes Java en un búfer de Node.js propiedad de la aplicación.
- Considere la exportación como exitosa solo cuando la operación de guardado de la presentación devuelve y cada devolución de llamada ha finalizado correctamente. No suprima errores de almacenamiento ni inicie escrituras en segundo plano sin observar. Si la persistencia ocurre después, informe el éxito general solo después de que ese paso también haya tenido éxito.

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) también se aplica a un guardador personalizado. La configuración predeterminada, `false`, excluye los documentos XAML de diapositivas ocultas. Pasar `true` los incluye junto con los recursos necesarios para su exportación. El recuento de recursos depende de la presentación; no asuma una devolución de llamada por diapositiva ni un orden fijo de devoluciones.

### **Exportar a memoria e inspeccionar los artefactos**

Este ejemplo completo carga `input.pptx`, recopila cada artefacto en un mapa de JavaScript de nombres a búferes y muestra su nombre, tipo y recuento de bytes. Preserva exactamente los nombres proporcionados. Los nombres duplicados marcan la colección como inválida en lugar de sobrescribir silenciosamente un artefacto. El ejemplo verifica esto antes de usar los resultados.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const artifacts = new Map();
let valid = true;
const saver = java.newProxy("com.aspose.slides.IXamlOutputSaver", {
    save: function(path, data) {
        const name = String(path);
        if (artifacts.has(name)) {
            valid = false;
            console.error("Export rejected: duplicate artifact name: " + name);
            return;
        }
        const retainedData = Buffer.from(data);
        artifacts.set(name, retainedData);
    }
});

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(true);
    presentation.save(options);
} finally {
    presentation.dispose();
}

if (!valid) {
    console.error("Export rejected: the artifact collection is invalid.");
} else {
    const inspectXamlText = false;
    for (const [name, data] of artifacts) {
        const isXaml = /\.xaml$/i.test(name);
        const isImage = /\.(png|jpg|jpeg|gif|bmp|tif|tiff|svg)$/i.test(name);
        const kind = isXaml ? "slide XAML" : isImage ? "image" : "supporting resource";
        console.log(name + ": " + data.length + " bytes (" + kind + ")");

        // Decode only XAML, and only when textual inspection is needed.
        if (isXaml && inspectXamlText) {
            console.log(data.toString("utf8"));
        }
    }
}
```

Las comprobaciones de extensión son útiles para la inspección; conserve todos los artefactos, incluidos los tipos de recurso desconocidos. Deje los bytes sin modificar al almacenarlos o transmitirlos. Use la decodificación UTF‑8 solo para XAML que necesite procesamiento textual.

### **Empaquetar los artefactos recopilados en un archivo ZIP**

Este ejemplo independiente recopila la exportación, valida sus nombres y escribe los bytes originales en un archivo ZIP usando el puente Java. El ZIP se ensambla en memoria antes de guardarse en disco. Un nombre de archivo único separa los trabajos de exportación simultáneos. Las entradas del ZIP usan barras diagonales hacia adelante y conservan los directorios relativos. Nombres inseguros o que colisionen tras la normalización rechazan todo el paquete antes de escribirlo.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const artifacts = new Map();
let valid = true;
const saver = java.newProxy("com.aspose.slides.IXamlOutputSaver", {
    save: function(path, data) {
        const name = String(path);
        if (artifacts.has(name)) {
            valid = false;
            console.error("Export rejected: duplicate artifact name: " + name);
            return;
        }
        const retainedData = Buffer.from(data);
        artifacts.set(name, retainedData);
    }
});

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(false);
    presentation.save(options);
} finally {
    presentation.dispose();
}

const entries = new Map();
const entryNames = new Set();
for (const [name, data] of artifacts) {
    const entryName = name.replace(/\\/g, "/");
    const segments = entryName.split("/");
    const unsafeName = entryName.startsWith("/") || entryName.includes(":") || segments.some(segment => segment.trim() === "" || segment === "." || segment === "..");
    const comparisonName = entryName.toLowerCase();
    if (unsafeName || entryNames.has(comparisonName)) {
        valid = false;
        console.error("Export rejected: unsafe or duplicate artifact name: " + name);
        break;
    }
    entryNames.add(comparisonName);
    entries.set(entryName, data);
}

if (!valid) {
    console.error("Export rejected: the artifact collection is invalid.");
} else {
    const fs = require("node:fs");
    const crypto = require("node:crypto");
    const archivePath = "xaml-" + crypto.randomUUID() + ".zip";
    const output = java.newInstanceSync("java.io.ByteArrayOutputStream");
    const archive = java.newInstanceSync("java.util.zip.ZipOutputStream", output);
    try {
        for (const [name, data] of entries) {
            const entry = java.newInstanceSync("java.util.zip.ZipEntry", name);
            archive.putNextEntry(entry);
            const bytes = java.newArray("byte", Array.from(data));
            archive.write(bytes);
            archive.closeEntry();
        }
    } finally {
        archive.close();
    }

    // Cerrar finaliza el directorio ZIP antes de que el archivo se persista.
    const archiveData = Buffer.from(output.toByteArray());
    try {
        fs.writeFileSync(archivePath, archiveData, { flag: "wx" });
        console.log("Saved " + entries.size + " artifacts to " + archivePath);
    } catch (error) {
        console.error("Archive persistence failed: " + error.message);
    }
}
```

El ejemplo utiliza [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) para escribir un archivo local; el exportador en sí no escribe archivos sueltos de XAML o imágenes. Para almacenamiento remoto, reemplace la fase de escritura del archivo por cargas de los arreglos de bytes recopilados. Use un identificador de trabajo de exportación más el nombre de artefacto relativo completo como clave de blob, o almacene el identificador del trabajo, el nombre relativo y los datos binarios en una fila de base de datos. Publique el trabajo solo después de que todas las cargas se completen o la transacción de base de datos se confirme. Elimine la salida parcial si la persistencia falla.

Para presentaciones grandes, un guardador personalizado puede persistir cada artefacto directamente en el almacenamiento de la aplicación para evitar mantener una copia adicional de toda la exportación en la memoria de la aplicación. Mantenga cada devolución de llamada síncrona desde la perspectiva del exportador: devuelva solo después de que el destino haya aceptado los bytes y permita que los fallos lleguen al llamador.

### **Conservar los nombres de recursos y verificar las referencias**

- Normalice los separadores de ruta cuando el destino lo requiera, pero conserve los directorios relativos. No use solo el nombre base a menos que cada nombre generado sea conocido por ser único y las referencias de recursos sigan siendo válidas.
- Aplique la validación de nombres específica del destino. Al escribir archivos sueltos, rechace rutas absolutas y segmentos de traversa, resuelva el destino a una ruta absoluta y verifique que permanezca bajo el directorio de exportación previsto, incluida la separación del directorio en la comprobación de contención. Use un directorio controlado por la aplicación sin enlaces simbólicos que puedan redirigir escrituras.
- Use un guardador y un espacio de nombres de almacenamiento separados para cada trabajo de exportación. Detecte colisiones tras la normalización de separadores y de acuerdo con las reglas de sensibilidad a mayúsculas/minúsculas del destino.
- Antes de publicar, analice cada documento XAML como XML e inspeccione sus referencias de recursos basadas en archivos, como los atributos `Source` o `ImageSource` de imágenes. Resuelva cada URI relativa contra el directorio del artefacto XAML contenedor, normalice el nombre de almacenamiento resultante y confirme que la clave del mapa correspondiente, la entrada del ZIP o el objeto almacenado exista. Trate las URIs externas y las expresiones de marcado XAML por separado de los nombres de archivo relativos.

Por ejemplo, si `input/Slide_1.xaml` hace referencia a `images/image1.png`, el recurso almacenado debe estar disponible como `input/images/image1.png`. Mantener solo `image1.png` rompería esa relación. Para almacenamiento de objetos, preserve la misma estructura bajo el prefijo del trabajo y haga que esas URLs de recursos sean accesibles para el consumidor de XAML. Reabra el ZIP completado para verificar los nombres de entrada y los bytes de los recursos, y cargue diapositivas representativas en el entorno XAML de destino para confirmar que las imágenes se resuelvan correctamente.

## **Preguntas frecuentes**

**¿Cómo puedo asegurar fuentes predecibles si la fuente original no está disponible en la máquina?**

Llame a [setDefaultRegularFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) en [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) — se usa como fuente de respaldo durante la exportación cuando la original falta. Esto no garantiza que el XAML generado haga referencia a la fuente de respaldo o que la fuente esté disponible en la máquina de destino. Asegúrese de que las fuentes referenciadas por el XAML estén presentes en el entorno donde se visualiza.

**¿El XAML exportado está pensado solo para WPF o puede usarse también en otras pilas XAML?**

Aspose.Slides exporta XAML de WPF a través de su API pública. La compatibilidad con otras pilas XAML, como UWP y Xamarin.Forms, no está garantizada. Pruebe el marcado generado en su entorno objetivo.

**¿Se admiten diapositivas ocultas y cómo puedo evitar que se exporten por defecto?**

De forma predeterminada, las diapositivas ocultas no se incluyen. Puede controlar este comportamiento mediante [setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) en [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) — manténgalo desactivado si no necesita exportarlas.