---
title: Gestionar propiedades de la presentación en JavaScript
linktitle: Propiedades de la presentación
type: docs
weight: 70
url: /es/nodejs-java/presentation-properties/
keywords:
- propiedades de PowerPoint
- propiedades de la presentación
- propiedades del documento
- propiedades integradas
- propiedades personalizadas
- propiedades avanzadas
- gestionar propiedades
- modificar propiedades
- metadatos del documento
- editar metadatos
- idioma de revisión
- idioma predeterminado
- PowerPoint
- OpenDocument
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Domine las propiedades de presentación en Aspose.Slides for Node.js via Java y optimice la búsqueda, la identidad corporativa y el flujo de trabajo en sus archivos PowerPoint y OpenDocument."
---
## **Introducción**

Aspose.Slides admite dos tipos de propiedades de documento: **Built-in** y **Custom**. Ambos tipos de propiedades pueden accederse y gestionarse fácilmente mediante la API de Aspose.Slides.

Aspose.Slides permite trabajar con las propiedades de documento de una presentación a través de la clase [DocumentProperties](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/documentproperties/) . Una instancia de esta clase se devuelve mediante el método [Presentation.getDocumentProperties](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/#getDocumentProperties) . Los ejemplos siguientes muestran cómo leer, modificar y gestionar estas propiedades.

{{% alert color="info" title="Nota" %}}

Tenga en cuenta que los campos **Application** y **AppVersion** no pueden modificarse. Aspose.Slides los sobrescribe en cada guardado, de modo que una presentación guardada siempre informa "Aspose.Slides for Node.js via Java" y la versión de la biblioteca que la generó. Cualquier valor pasado a `setNameOfApplication` se descarta al escribir la presentación.

{{% /alert %}} 

## **Gestionar propiedades de la presentación**

Microsoft PowerPoint proporciona una función para añadir algunas propiedades a los archivos de presentación. Estas propiedades de documento permiten almacenar información útil junto con los documentos (archivos de presentación). Existen dos tipos de propiedades de documento:

- Propiedades definidas por el sistema (Built-in)
- Propiedades definidas por el usuario (Custom)

Las propiedades **Built-in** contienen información general sobre el documento, como el título, el nombre del autor, estadísticas del documento, etc. Las propiedades **Custom** son aquellas definidas por los usuarios como pares **Nombre/Valor**, donde tanto el nombre como el valor son definidos por el usuario. Con Aspose.Slides for Node.js via Java, los desarrolladores pueden acceder y modificar los valores de las propiedades integradas así como de las personalizadas.

## **Propiedades de documento en PowerPoint**

Microsoft PowerPoint 2007 permite gestionar las propiedades de documento de los archivos de presentación. Sólo hay que hacer clic en el icono de Office y luego en el elemento del menú **Prepare | Properties | Advanced Properties** de Microsoft PowerPoint 2007, como se muestra a continuación:

|**Seleccionar la opción Propiedades avanzadas**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
Después de seleccionar el elemento del menú **Advanced Properties**, aparecerá un cuadro de diálogo que permite gestionar las propiedades de documento del archivo PowerPoint, como se muestra en la figura siguiente:

|**Cuadro de diálogo de propiedades**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
En el **Cuadro de diálogo de propiedades** anterior, se pueden observar varias pestañas como **General**, **Summary**, **Statistics**, **Contents** y **Custom**. Todas estas pestañas permiten configurar diferentes tipos de información relacionada con los archivos PowerPoint. La pestaña **Custom** se utiliza para gestionar las propiedades personalizadas de los archivos PowerPoint.

## **Trabajar con propiedades de documento usando Aspose.Slides for Node.js via Java**

Como se describió antes, Aspose.Slides for Node.js via Java admite dos tipos de propiedades de documento, que son **Built-in** y **Custom**. Por lo tanto, los desarrolladores pueden acceder a ambos tipos de propiedades mediante la API de Aspose.Slides for Node.js via Java. Aspose.Slides for Node.js via Java proporciona la clase [DocumentProperties](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/documentproperties) que representa las propiedades de documento asociadas a un archivo de presentación a través de la propiedad **Presentation.DocumentProperties**.

Los desarrolladores pueden usar la propiedad **DocumentProperties** expuesta por el objeto [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation) para acceder a las propiedades de documento de los archivos de presentación, como se describe a continuación:

## **Leer propiedades públicas de una presentación cifrada**

Una contraseña de apertura normalmente protege tanto el contenido de la presentación como sus propiedades de documento. Cuando una presentación se cifra pasando `false` a [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties), sus propiedades de documento permanecen públicas. Una aplicación puede entonces pasar `true` a [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) y leer los metadatos públicos sin suministrar la contraseña de apertura.

La opción de solo cargar propiedades de documento controla lo que Aspose.Slides carga; no descifra nada. Si las propiedades estaban incluidas en el cifrado, cargarlas sin la contraseña falla. Si la presentación no está cifrada, la opción se ignora y se carga la presentación completa.

El siguiente ejemplo verifica el modo de carga mediante [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) y luego lee propiedades integradas mediante [Presentation.getDocumentProperties](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/#getDocumentProperties):

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

const presentation = new slides.Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        const properties = presentation.getDocumentProperties();

        console.log("Author: " + properties.getAuthor());
        console.log("Title: " + properties.getTitle());
        console.log("Keywords: " + properties.getKeywords());
    } else {
        console.log("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

En este modo, el contenido de las diapositivas no se carga. Diapositivas, maestros, diseños, formas, medios y otros objetos de la presentación no están disponibles. Las aplicaciones deben comprobar siempre [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) antes de realizar una operación que requiera el modelo de objetos completo de la presentación.

{{% alert color="warning" title="Advertencia" %}}
Los metadatos públicos pueden exponer nombres de autores, títulos, asuntos, palabras clave, información de la empresa, comentarios y valores personalizados. Encripte las propiedades sensibles junto con la presentación. Déjelas públicas solo cuando los sistemas de indexación, clasificación, búsqueda o gestión documental tengan un requisito específico para acceder a ellas sin contraseña.
{{% /alert %}}

## **Actualizar propiedades de una presentación cifrada**

Para un archivo PPTX cifrado, una presentación cargada en modo solo propiedades de documento está destinada a leer metadatos públicos. Aspose.Slides no puede guardar propiedades modificadas de ese objeto de solo metadatos porque las propiedades públicas deben permanecer consistentes con los datos correspondientes dentro de la presentación cifrada. Por lo tanto, actualizarlas requiere la contraseña de apertura correcta y una carga completa.

El siguiente ejemplo abre la presentación con [LoadOptions.setPassword](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/loadoptions/#setPassword), actualiza las propiedades públicas integradas y guarda el resultado. Luego utiliza [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentationinfo/#isEncrypted) para comprobar que el cifrado se conserva y vuelve a abrir los metadatos públicos sin contraseña para verificar los nuevos valores:

```javascript
const slides = require("aspose.slides.via.java");

const inputPath = "public-properties-encrypted.pptx";
const outputPath = "updated-public-properties-encrypted.pptx";

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation(inputPath, loadOptions);
try {
    presentation.getDocumentProperties().setTitle("Updated Product Roadmap");
    presentation.getDocumentProperties().setKeywords("roadmap, planning, indexed");
    presentation.save(outputPath, slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo(outputPath);
console.log("The presentation is encrypted: " + presentationInfo.isEncrypted());

const metadataLoadOptions = new slides.LoadOptions();
metadataLoadOptions.setOnlyLoadDocumentProperties(true);

const metadataPresentation = new slides.Presentation(outputPath, metadataLoadOptions);
try {
    if (metadataPresentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        console.log("Title: " + metadataPresentation.getDocumentProperties().getTitle());
        console.log("Keywords: " + metadataPresentation.getDocumentProperties().getKeywords());
    } else {
        console.log("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    metadataPresentation.dispose();
}
```

Si una aplicación no tiene permiso para descifrar o cargar el contenido de la presentación, debe tratar las propiedades públicas de un archivo PPTX cifrado como de solo lectura.

## **Acceder a propiedades integradas**

Estas propiedades, expuestas por el objeto [DocumentProperties](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/documentproperties), incluyen: **Creator** (Autor), **Description**, **Keywords**, **Created** (Fecha de creación), **Modified** (Fecha de modificación), **Printed** (Fecha del último imprimado), **LastModifiedBy**, **Keywords**, **SharedDoc** (¿Está compartido entre diferentes productores?), **PresentationFormat**, **Subject** y **Title**.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instanciar la clase Presentation que representa la presentación
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Crear una referencia al objeto IDocumentProperties asociado a la presentación
    var dp = pres.getDocumentProperties();
    // Mostrar las propiedades integradas
    console.log("Category : " + dp.getCategory());
    console.log("Current Status : " + dp.getContentStatus());
    console.log("Creation Date : " + dp.getCreatedTime());
    console.log("Author : " + dp.getAuthor());
    console.log("Description : " + dp.getComments());
    console.log("KeyWords : " + dp.getKeywords());
    console.log("Last Modified By : " + dp.getLastSavedBy());
    console.log("Supervisor : " + dp.getManager());
    console.log("Modified Date : " + dp.getLastSavedTime());
    console.log("Presentation Format : " + dp.getPresentationFormat());
    console.log("Last Print Date : " + dp.getLastPrinted());
    console.log("Is Shared between producers : " + dp.getSharedDoc());
    console.log("Subject : " + dp.getSubject());
    console.log("Title : " + dp.getTitle());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Modificar propiedades integradas**

Modificar las propiedades integradas de los archivos de presentación es tan sencillo como acceder a ellas. Simplemente asigne un valor de cadena a cualquier propiedad deseada y el valor de la propiedad se modificará. En el ejemplo siguiente, demostramos cómo podemos modificar las propiedades integradas del documento de la presentación usando Aspose.Slides for Node.js via Java.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Crear una referencia al objeto IDocumentProperties asociado a la Presentación
    var dp = pres.getDocumentProperties();
    // Establecer las propiedades integradas
    dp.setAuthor("Aspose.Slides for Node.js via Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    // Guardar la presentación en un archivo
    pres.save("DocProps.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Este ejemplo modifica las propiedades integradas de la presentación, como se muestra a continuación:

|**Propiedades de documento integradas después de la modificación**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Añadir propiedades de documento personalizadas**

Aspose.Slides for Node.js via Java también permite a los desarrolladores añadir valores personalizados a las propiedades de documento de la presentación. A continuación se muestra un ejemplo que indica cómo establecer propiedades personalizadas para una presentación.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    // Obteniendo propiedades del documento
    var dProps = pres.getDocumentProperties();
    // Añadiendo propiedades personalizadas
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    // Obteniendo el nombre de la propiedad en un índice concreto
    var getPropertyName = dProps.getCustomPropertyName(2);
    // Eliminando la propiedad seleccionada
    dProps.removeCustomProperty(getPropertyName);
    // Guardando la presentación
    pres.save("CustomDemo.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|**Propiedades de documento personalizadas añadidas**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Acceder y modificar propiedades personalizadas**

Aspose.Slides for Node.js via Java también permite a los desarrolladores acceder a los valores de las propiedades personalizadas. A continuación se muestra un ejemplo que indica cómo puede acceder y modificar todas estas propiedades personalizadas para una presentación.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Crear una referencia al objeto DocumentProperties asociado a la Presentación
    var dp = pres.getDocumentProperties();
    // Acceder y modificar propiedades personalizadas
    for (var i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Mostrar nombres y valores de las propiedades personalizadas
        console.log("Custom Property Name : " + dp.getCustomPropertyName(i));
        console.log("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
        // Modificar valores de las propiedades personalizadas
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    // Guardar la presentación en un archivo
    pres.save("CustomDemoModified.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Este ejemplo modifica las propiedades personalizadas de la presentación [PPTX](https://docs.fileformat.com/presentation/pptx/). Las figuras siguientes muestran las propiedades personalizadas de la presentación antes y después de la modificación:

|**Propiedades personalizadas antes de la modificación**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Propiedades personalizadas después de la modificación**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Propiedades de documento avanzadas**

{{% alert color="info" title="Nota" %}}

Se han añadido los nuevos métodos [ReadDocumentProperties](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-), y [WriteBindedPresentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/PresentationInfo#writeBindedPresentation-java.lang.String-) a [PresentationInfo](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/PresentationInfo), y se ha cambiado la lógica del setter de la propiedad [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/documentproperties#setLastSavedTime-java.util.Date-).

{{% /alert %}} 

Los dos nuevos métodos [ReadDocumentProperties](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--) y [UpdateDocumentProperties](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) se han añadido a la clase [PresentationInfo](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/PresentationInfo). Proporcionan acceso rápido a las propiedades de documento y permiten cambiar y actualizar propiedades sin cargar una presentación completa.

El escenario típico: cargar las propiedades, cambiar algún valor y actualizar el documento, puede implementarse de la siguiente manera:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// leer la información de la presentación
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");
// obtener las propiedades actuales
var props = info.readDocumentProperties();
// establecer los nuevos valores de los campos Author y Title
props.setAuthor("New Author");
props.setTitle("New Title");
// actualizar la presentación con nuevos valores
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Existe otra forma de usar las propiedades de una presentación concreta como plantilla para actualizar propiedades en otras presentaciones:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) {
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}

var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("template.pptx");
var template = info.readDocumentProperties();
template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");
updateByTemplate("doc1.pptx", template);
updateByTemplate("doc2.odp", template);
updateByTemplate("doc3.ppt", template);
```

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

Se puede crear una nueva plantilla desde cero y luego usarla para actualizar varias presentaciones:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) {
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}

var template = new aspose.slides.DocumentProperties();
template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");
updateByTemplate("doc1.pptx", template);
updateByTemplate("doc2.odp", template);
updateByTemplate("doc3.ppt", template);
```

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **Establecer idioma de revisión**

Aspose.Slides proporciona la propiedad LanguageId (expuesta por la clase PortionFormat) para permitir establecer el idioma de revisión de un documento PowerPoint. El idioma de revisión es el idioma para el que se verifica la ortografía y la gramática en PowerPoint.

Este código JavaScript muestra cómo establecer el idioma de revisión para un PowerPoint: xxx ¿Por qué falta LanguageId en la clase JavaScript PortionFormat?

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();
    var newPortion = new aspose.slides.Portion();
    var font = new aspose.slides.FontData("SimSun");
    var portionFormat = newPortion.getPortionFormat();
    portionFormat.setComplexScriptFont(font);
    portionFormat.setEastAsianFont(font);
    portionFormat.setLatinFont(font);
    portionFormat.setLanguageId("zh-CN");// set the Id of a proofing language
    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Establecer idioma predeterminado**

Este código JavaScript muestra cómo establecer el idioma predeterminado para toda una presentación PowerPoint:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");
var pres = new aspose.slides.Presentation(loadOptions);
try {
    // Añade una nueva forma rectangular con texto
    var shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");
    // Comprueba el idioma de la primera porción
    console.log(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ejemplo en vivo**

Pruebe la aplicación en línea [**Aspose.Slides Metadata**](https://products.aspose.app/slides/es/metadata) para ver cómo trabajar con propiedades de documento mediante la API de Aspose.Slides:

[![Ver y editar metadatos de PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/es/metadata)

## **Preguntas frecuentes**

**¿Cómo puedo eliminar una propiedad integrada de una presentación?**

Las propiedades integradas forman parte esencial de la presentación y no pueden eliminarse por completo. Sin embargo, puede cambiar sus valores o establecerlas como vacías si la propiedad específica lo permite.

**¿Qué ocurre si añado una propiedad personalizada que ya existe?**

Si añade una propiedad personalizada que ya existe, su valor actual será sobrescrito por el nuevo. No es necesario eliminar o comprobar la propiedad antes, ya que Aspose.Slides actualiza automáticamente el valor de la propiedad.

**¿Puedo acceder a las propiedades de la presentación sin cargarla completamente?**

Sí. Use [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) y luego [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) para leer los metadatos almacenados sin crear una instancia de [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/) . Consulte [Build a Lightweight Presentation Inventory](/slides/es/nodejs-java/examine-presentation/) para un ejemplo completo de informe y limitaciones específicas por formato.

**¿Puedo leer propiedades públicas de una presentación cifrada sin su contraseña de apertura?**

Sí. El cifrado de propiedades de documento debe haberse desactivado antes de que la presentación fuera cifrada, y la presentación debe cargarse en modo solo propiedades de documento.

**¿Puedo actualizar un archivo PPTX cifrado en modo solo propiedades de documento?**

No. Los datos de propiedades públicas y cifradas deben permanecer consistentes, por lo que actualizar un archivo PPTX cifrado requiere cargar la presentación completa con la contraseña de apertura correcta.