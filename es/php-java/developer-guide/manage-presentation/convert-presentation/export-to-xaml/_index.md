---
title: Exportar presentaciones a XAML en PHP
linktitle: Presentación a XAML
type: docs
weight: 30
url: /es/php-java/export-to-xaml/
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
- PHP
- Aspose.Slides
description: "Convierte diapositivas de PowerPoint y OpenDocument a XAML usando Aspose.Slides para PHP vía Java — solución rápida, sin Office, que mantiene intacto el diseño."
---
## **Descripción general**

Este artículo explica cómo exportar presentaciones de PowerPoint a XAML usando Aspose.Slides. Incluye una breve introducción a XAML, muestra cómo guardar una presentación en XAML con la configuración predeterminada y demuestra cómo personalizar la exportación mediante [XamlOptions](https://reference.aspose.com/slides/es/php-java/aspose.slides/xamloptions/), incluyendo la exportación de diapositivas ocultas. El artículo también responde a algunas preguntas habituales relacionadas con fuentes de reserva, compatibilidad de pilas XAML y el comportamiento de exportación de diapositivas ocultas.

## **Acerca de XAML**

XAML es un lenguaje de marcado basado en XML que se utiliza para describir interfaces de usuario en marcos como WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) y Xamarin.Forms.

Puedes trabajar con archivos XAML en un diseñador visual o escribir y editar el marcado directamente.

## **Exportar presentaciones a XAML con opciones predeterminadas**

El siguiente ejemplo en PHP muestra cómo exportar una presentación a XAML con la configuración predeterminada. Inicializa PHP Java Bridge y carga `aspose.slides.php` antes de ejecutar los ejemplos de este artículo. Coloca `pres.pptx` en el directorio de trabajo del servidor Java Bridge, o proporciona una ruta absoluta accesible para ese servidor.

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $presentation->save($options);
} finally {
    $presentation->dispose();
}
```

Por defecto, las diapositivas exportadas se guardan en una subcarpeta `pres` del directorio de trabajo actual del servidor Java Bridge. La carpeta se crea automáticamente y cualquier imagen requerida también se guarda allí.

El nombre de la carpeta de salida se toma del nombre del archivo fuente sin su extensión. Para `pres.pptx`, los archivos de salida se llaman `pres/Slide_1.xaml`, `pres/Slide_2.xaml`, etc. Incluso si proporcionas una ruta absoluta a la presentación de entrada, la carpeta de salida se crea de forma relativa al directorio de trabajo actual del servidor Java Bridge, en lugar de junto al archivo de entrada.

## **Exportar presentaciones a XAML con opciones personalizadas**

Utiliza la interfaz [IXamlOptions](https://reference.aspose.com/slides/es/java/com.aspose.slides/ixamloptions/) para controlar cómo Aspose.Slides exporta una presentación a XAML.

Para guardar la salida en una ubicación personalizada, proporciona un proxy Java que implemente [IXamlOutputSaver](https://reference.aspose.com/slides/es/java/com.aspose.slides/ixamloutputsaver/) y pasa una instancia de tu implementación al método [setOutputSaver](https://reference.aspose.com/slides/es/php-java/aspose.slides/xamloptions/#setOutputSaver) de [XamlOptions](https://reference.aspose.com/slides/es/php-java/aspose.slides/xamloptions/).

Para incluir diapositivas ocultas en la salida XAML, llama a [setExportHiddenSlides](https://reference.aspose.com/slides/es/php-java/aspose.slides/xamloptions/#setExportHiddenSlides) con `true`, como se muestra en el siguiente ejemplo en PHP:

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $options->setExportHiddenSlides(true);
    $presentation->save($options);
} finally {
    $presentation->dispose();
}
```

## **Capturar todos los artefactos XAML generados**

Una exportación a XAML puede producir un documento XAML para cada diapositiva exportada, además de imágenes y recursos de soporte separados. Asigna un [IXamlOutputSaver](https://reference.aspose.com/slides/es/java/com.aspose.slides/ixamloutputsaver/) personalizado a [XamlOptions::setOutputSaver](https://reference.aspose.com/slides/es/php-java/aspose.slides/xamloptions/#setOutputSaver) para recibir estos artefactos en lugar de usar el guardador de sistema de archivos predeterminado. Inicia la exportación con la sobrecarga específica de XAML de [Presentation::save](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/#save) que acepta opciones XAML.

La función `java_closure` del PHP Java Bridge expone un objeto PHP como interfaz Java. Mantén tanto el guardador PHP como su proxy vivos hasta que la exportación finalice. Los enlaces de la interfaz apuntan a la API Java implementada por el proxy.

### **Entender el ciclo de vida de la devolución de llamada**

El exportador llama a [IXamlOutputSaver::save](https://reference.aspose.com/slides/es/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) por separado para cada artefacto generado:

- `path` identifica el artefacto y puede incluir directorios relativos. Conserva esta información porque XAML puede referenciar recursos mediante rutas relativas.
- `data` contiene los bytes del artefacto. Las imágenes y otros recursos binarios no deben decodificarse como texto.
- El guardador es responsable de retener o persistir los datos antes de devolver. Los ejemplos convierten cada matriz de bytes Java en una cadena binaria PHP gestionada por la aplicación.
- Considera la exportación como exitosa solo cuando la operación de guardado de la presentación devuelve y cada devolución de llamada se ha completado satisfactoriamente. No suprimas errores de almacenamiento ni inicies escrituras en segundo plano no observadas. Si la persistencia ocurre después, informa del éxito total solo después de que esa etapa también haya tenido éxito.

[XamlOptions::setExportHiddenSlides](https://reference.aspose.com/slides/es/php-java/aspose.slides/xamloptions/#setExportHiddenSlides) también se aplica a un guardador personalizado. La configuración predeterminada, `false`, excluye los documentos XAML de diapositivas ocultas. Pasar `true` los incluye junto con cualquier recurso necesario para su exportación. El recuento de recursos depende de la presentación; no asumas una devolución de llamada por diapositiva ni un orden fijo de devoluciones de llamada.

### **Exportar a memoria e inspeccionar los artefactos**

Este ejemplo completo carga `pres.pptx`, recoge cada artefacto en un array asociativo PHP de cadenas binarias y muestra su nombre, tipo y recuento de bytes. Conserva los nombres suministrados tal cual. Los nombres duplicados marcan la colección como inválida en lugar de sobrescribir silenciosamente un artefacto. El ejemplo verifica esto antes de usar los resultados.

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

class MemoryXamlSaver {
    public $artifacts = [];
    public $valid = true;

    public function save($path, $data) {
        $name = (string) java_values($path);
        if (array_key_exists($name, $this->artifacts)) {
            $this->valid = false;
            echo "Export rejected: duplicate artifact name: " . $name . PHP_EOL;
            return;
        }
        $bytes = java_values($data);
        if (is_string($bytes)) {
            $binary = $bytes;
        } else {
            $binary = "";
            foreach ($bytes as $byte) {
                $binary .= chr($byte & 0xff);
            }
        }
        $this->artifacts[$name] = $binary;
    }
}

$saver = new MemoryXamlSaver();
$proxy = java_closure($saver, null, java("com.aspose.slides.IXamlOutputSaver"));
$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $options->setOutputSaver($proxy);
    $options->setExportHiddenSlides(true);
    $presentation->save($options);
} finally {
    $presentation->dispose();
}

if (!$saver->valid) {
    echo "Export rejected: the artifact collection is invalid." . PHP_EOL;
    return;
}

$inspectXamlText = false;
foreach ($saver->artifacts as $name => $bytes) {
    $extension = strtolower(pathinfo($name, PATHINFO_EXTENSION));
    $isXaml = $extension === "xaml";
    $isImage = in_array($extension, ["png", "jpg", "jpeg", "gif", "bmp", "tif", "tiff", "svg"], true);
    $kind = $isXaml ? "slide XAML" : ($isImage ? "image" : "supporting resource");
    echo $name . ": " . strlen($bytes) . " bytes (" . $kind . ")" . PHP_EOL;

    // Solo XAML se trata como texto UTF-8 para inspección opcional.
    if ($isXaml && $inspectXamlText) {
        echo $bytes . PHP_EOL;
    }
}
```

Las comprobaciones de extensión son útiles para la inspección; conserva todos los artefactos, incluidos los tipos de recurso desconocidos. Deja los bytes sin modificar al almacenarlos o transmitirlos. Las cadenas PHP pueden retener datos binarios, incluidos los bytes cero. Trata una cadena como texto UTF‑8 solo al inspeccionar XAML; no transcodifiques los bytes de imágenes o recursos.

### **Empaquetar los artefactos recopilados en un archivo ZIP**

Este ejemplo independiente recopila la exportación, valida sus nombres y escribe los bytes originales en un archivo ZIP. Un directorio de trabajo creado exclusivamente separa los trabajos de exportación concurrentes. Este ejemplo requiere la extensión PHP Phar con soporte ZIP. Las entradas ZIP usan barras diagonales hacia adelante y conservan los directorios relativos. Los nombres inseguros o los nombres que colisionan tras la normalización se rechazan antes de escribir el paquete completo.

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

class MemoryXamlSaver {
    public $artifacts = [];
    public $valid = true;

    public function save($path, $data) {
        $name = (string) java_values($path);
        if (array_key_exists($name, $this->artifacts)) {
            $this->valid = false;
            echo "Export rejected: duplicate artifact name: " . $name . PHP_EOL;
            return;
        }
        $bytes = java_values($data);
        if (is_string($bytes)) {
            $binary = $bytes;
        } else {
            $binary = "";
            foreach ($bytes as $byte) {
                $binary .= chr($byte & 0xff);
            }
        }
        $this->artifacts[$name] = $binary;
    }
}

$saver = new MemoryXamlSaver();
$proxy = java_closure($saver, null, java("com.aspose.slides.IXamlOutputSaver"));
$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $options->setOutputSaver($proxy);
    $options->setExportHiddenSlides(false);
    $presentation->save($options);
} finally {
    $presentation->dispose();
}

if (!$saver->valid) {
    echo "Export rejected: the artifact collection is invalid." . PHP_EOL;
    return;
}

$entries = [];
$entryNames = [];
foreach ($saver->artifacts as $name => $bytes) {
    $entryName = str_replace("\\", "/", $name);
    $unsafeName = substr($entryName, 0, 1) === "/" || strpos($entryName, ":") !== false;
    foreach (explode("/", $entryName) as $segment) {
        $unsafeName = $unsafeName || trim($segment) === "" || $segment === "." || $segment === "..";
    }
    $key = strtolower($entryName);
    if ($unsafeName || isset($entryNames[$key])) {
        echo "Export rejected: unsafe or duplicate artifact name: " . $name . PHP_EOL;
        return;
    }
    $entryNames[$key] = true;
    $entries[$entryName] = $bytes;
}

$jobDirectory = "xaml-" . bin2hex(random_bytes(16));
if (!mkdir($jobDirectory, 0700)) {
    echo "Cannot create the export directory." . PHP_EOL;
    return;
}
$archivePath = $jobDirectory . "/export.zip";
try {
    $archive = new PharData($archivePath, 0, null, Phar::ZIP);
    foreach ($entries as $name => $bytes) {
        $archive->addFromString($name, $bytes);
    }
    unset($archive);
    echo "Saved " . count($entries) . " artifacts to " . $archivePath . PHP_EOL;
} catch (Throwable $exception) {
    unset($archive);
    echo "Archive persistence failed: " . $exception->getMessage() . PHP_EOL;
}
```

El ejemplo utiliza [PharData](https://www.php.net/manual/en/class.phardata.php) para escribir un archivo ZIP local en el directorio de trabajo del proceso PHP; el propio exportador no escribe archivos XAML o de imagen sueltos. Para almacenamiento remoto, sustituye la fase de escritura del archivo por cargas de las cadenas binarias recopiladas. Usa un identificador de trabajo de exportación más el nombre relativo completo del artefacto como clave de blob, o almacena el identificador del trabajo, el nombre relativo y los datos binarios en una fila de base de datos. Publica el trabajo solo después de que todas las cargas hayan finalizado o la transacción de base de datos se haya confirmado. Elimina la salida parcial si la persistencia falla.

Para presentaciones grandes, un guardador personalizado puede persistir cada artefacto directamente en el almacenamiento de la aplicación para evitar mantener una copia adicional de toda la exportación en la memoria de la aplicación. Mantén cada devolución de llamada sincrónica desde la perspectiva del exportador: devuelve solo después de que el destino haya aceptado los bytes y permite que los fallos lleguen al llamador.

### **Preservar nombres de recursos y verificar referencias**

- Normaliza los separadores de ruta cuando el destino lo requiera, pero conserva los directorios relativos. No uses solo [basename](https://www.php.net/manual/en/function.basename.php) a menos que cada nombre generado sea conocido por ser único y las referencias a recursos sigan siendo válidas.
- Aplica la validación de nombres específica del destino. Al escribir archivos sueltos, rechaza rutas absolutas y segmentos de recorrido, resuelve el destino a una ruta absoluta y verifica que permanezca bajo el directorio de exportación previsto, incluyendo el separador de directorio en la comprobación de contención. Usa un directorio controlado por la aplicación sin enlaces simbólicos que puedan redirigir escrituras.
- Utiliza un guardador y un espacio de nombres de almacenamiento separados para cada trabajo de exportación. Detecta colisiones después de la normalización de separadores y según las reglas de sensibilidad a mayúsculas del destino.
- Antes de publicar, analiza cada documento XAML como XML e inspecciona sus referencias a recursos basados en archivos, como los atributos `Source` o `ImageSource` de imágenes. Resuelve cada URI relativa contra el directorio del artefacto XAML contenedor, normaliza el nombre de almacenamiento resultante y confirma que la clave del mapa correspondiente, la entrada ZIP o el objeto almacenado exista. Trata las URIs externas y las expresiones de marcado XAML por separado de los nombres de archivo relativos.

Por ejemplo, si `pres/Slide_1.xaml` hace referencia a `images/image1.png`, el recurso almacenado debe estar disponible como `pres/images/image1.png`. Mantener solo `image1.png` rompería esa relación. Para almacenamiento de objetos, preserva la misma estructura bajo el prefijo del trabajo y haz que esas URLs de recursos sean accesibles para el consumidor XAML. Vuelve a abrir el ZIP completado para verificar los nombres de entrada y los bytes de los recursos, y carga diapositivas representativas en el entorno XAML de destino para confirmar que las imágenes se resuelven correctamente.

## **Preguntas frecuentes**

**¿Cómo puedo garantizar fuentes predecibles si la fuente original no está disponible en el equipo?**

Llama a [setDefaultRegularFont](https://reference.aspose.com/slides/es/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) en [XamlOptions](https://reference.aspose.com/slides/es/php-java/aspose.slides/xamloptions/) — se usa como fuente de reserva durante la exportación cuando la original falta. Esto no garantiza que el XAML generado haga referencia a la fuente de reserva o que la fuente esté disponible en la máquina objetivo. Asegúrate de que las fuentes referenciadas por el XAML estén disponibles en el entorno donde se visualice.

**¿El XAML exportado está destinado solo a WPF o puede usarse también en otras pilas XAML?**

Aspose.Slides exporta XAML de WPF a través de su API pública. La compatibilidad con otras pilas XAML, como UWP y Xamarin.Forms, no está garantizada. Prueba el marcado generado en tu entorno de destino.

**¿Se admiten diapositivas ocultas y cómo puedo evitar que se exporten por defecto?**

Por defecto, las diapositivas ocultas no se incluyen. Puedes controlar este comportamiento mediante [setExportHiddenSlides](https://reference.aspose.com/slides/es/php-java/aspose.slides/xamloptions/#setExportHiddenSlides) en [XamlOptions](https://reference.aspose.com/slides/es/php-java/aspose.slides/xamloptions/) — mantenlo desactivado si no necesitas exportarlas.