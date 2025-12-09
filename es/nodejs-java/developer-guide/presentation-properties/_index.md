---
title: Propiedades de presentación
type: docs
weight: 70
url: /es/nodejs-java/presentation-properties/
keywords:
- Propiedades de PowerPoint
- Propiedades de presentación
- Propiedades de documento
- Propiedades integradas
- Propiedades personalizadas
- Propiedades avanzadas
- Modificar propiedades
- Metadatos de documento
- Editar metadatos
- PowerPoint
- presentación
- Node.js
- JavaScript
- Aspose.Slides for Node.js via Java
description: "Administre las propiedades de presentaciones de PowerPoint en JavaScript"
---

{{% alert color="primary" %}} 

Microsoft PowerPoint proporciona una función para añadir algunas propiedades a los archivos de presentación. Estas propiedades de documento permiten almacenar información útil junto con los documentos (archivos de presentación). Existen dos tipos de propiedades de documento como se indica a continuación:

- Propiedades definidas por el sistema (integradas)
- Propiedades definidas por el usuario (personalizadas)

Las propiedades **integradas** contienen información general sobre el documento, como el título del documento, el nombre del autor, estadísticas del documento, etc. Las propiedades **personalizadas** son aquellas definidas por los usuarios como pares **Nombre/Valor**, donde tanto el nombre como el valor son definidos por el usuario. Utilizando Aspose.Slides for Node.js via Java, los desarrolladores pueden acceder y modificar los valores de las propiedades integradas así como de las personalizadas.

{{% /alert %}} 

## **Propiedades de documento en PowerPoint**

Microsoft PowerPoint 2007 permite gestionar las propiedades de documento de los archivos de presentación. Todo lo que tiene que hacer es hacer clic en el ícono de Office y, a continuación, en el elemento del menú **Prepare | Properties | Advanced Properties** de Microsoft PowerPoint 2007, como se muestra a continuación:

{{% alert color="primary" %}} 

Tenga en cuenta que no puede establecer valores para los campos **Application** y **Producer**, porque se mostrará Aspose Ltd. y Aspose.Slides for Node.js via Java x.x.x en dichos campos.

{{% /alert %}} 

|**Seleccionar elemento de menú Advanced Properties**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
Después de seleccionar el elemento de menú **Advanced Properties**, aparecerá un cuadro de diálogo que le permite gestionar las propiedades de documento del archivo PowerPoint, como se muestra a continuación en la figura:

|**Cuadro de diálogo de Propiedades**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
En el **Cuadro de diálogo de Propiedades** anterior, puede ver que hay varias páginas de pestañas como **General**, **Summary**, **Statistics**, **Contents** y **Custom**. Todas estas páginas permiten configurar diferentes tipos de información relacionada con los archivos PowerPoint. La pestaña **Custom** se utiliza para gestionar las propiedades personalizadas de los archivos PowerPoint.

### Trabajar con Propiedades de Documento usando Aspose.Slides for Node.js via Java

Como describimos anteriormente, Aspose.Slides for Node.js via Java admite dos tipos de propiedades de documento, que son **integradas** y **personalizadas**. Por lo tanto, los desarrolladores pueden acceder a ambos tipos de propiedades mediante la API de Aspose.Slides for Node.js via Java. Aspose.Slides for Node.js via Java proporciona la clase [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/documentproperties) que representa las propiedades de documento asociadas a un archivo de presentación a través de la propiedad **Presentation.DocumentProperties**.

Los desarrolladores pueden usar la propiedad **DocumentProperties** expuesta por el objeto [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) para acceder a las propiedades de documento de los archivos de presentación como se describe a continuación:

## **Acceder a propiedades integradas**

Estas propiedades, expuestas por el objeto [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/documentproperties), incluyen: **Creator** (Autor), **Description**, **Keywords**, **Created** (Fecha de creación), **Modified** (Fecha de modificación), **Printed** (Fecha de la última impresión), **LastModifiedBy**, **SharedDoc** (¿Se comparte entre diferentes productores?), **PresentationFormat**, **Subject** y **Title**  
```javascript
// Instanciar la clase Presentation que representa la presentación
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Crear una referencia al objeto IDocumentProperties asociado con Presentation
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

Modificar las propiedades integradas de los archivos de presentación es tan sencillo como acceder a ellas. Simplemente asigne un valor de cadena a cualquier propiedad deseada y el valor de la propiedad se modificará. En el ejemplo que se muestra a continuación, demostramos cómo podemos modificar las propiedades integradas de documento de un archivo de presentación usando Aspose.Slides for Node.js via Java.  
```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Crear una referencia al objeto IDocumentProperties asociado con Presentation
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


Este ejemplo modifica las propiedades integradas de la presentación, como se puede ver a continuación:

|**Propiedades de documento integradas después de la modificación**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Agregar propiedades de documento personalizadas**

Aspose.Slides for Node.js via Java también permite a los desarrolladores agregar valores personalizados para las propiedades de documento de la presentación. A continuación se muestra un ejemplo que indica cómo establecer propiedades personalizadas para una presentación.  
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Obtener propiedades del documento
    var dProps = pres.getDocumentProperties();
    // Añadiendo propiedades personalizadas
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    // Obtener el nombre de la propiedad en un índice particular
    var getPropertyName = dProps.getCustomPropertyName(2);
    // Eliminar la propiedad seleccionada
    dProps.removeCustomProperty(getPropertyName);
    // Guardar la presentación
    pres.save("CustomDemo.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


|**Propiedades de documento personalizadas agregadas**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Acceder y modificar propiedades personalizadas**

Aspose.Slides for Node.js via Java también permite a los desarrolladores acceder a los valores de las propiedades personalizadas. A continuación se muestra un ejemplo que indica cómo puede acceder y modificar todas estas propiedades personalizadas para una presentación.  
```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Crear una referencia al objeto DocumentProperties asociado con Presentation
    var dp = pres.getDocumentProperties();
    // Acceder y modificar propiedades personalizadas
    for (var i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Mostrar nombres y valores de propiedades personalizadas
        console.log("Custom Property Name : " + dp.getCustomPropertyName(i));
        console.log("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
        // Modificar valores de propiedades personalizadas
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    // Guardar su presentación en un archivo
    pres.save("CustomDemoModified.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Este ejemplo modifica las propiedades personalizadas del [PPTX ](https://docs.fileformat.com/presentation/pptx/)presentación. Las siguientes figuras muestran las propiedades personalizadas de la presentación antes y después de la modificación:

|**Propiedades personalizadas antes de la modificación**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Propiedades personalizadas después de la modificación**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Propiedades de documento avanzadas**

{{% alert color="primary" %}} 

Se han añadido los nuevos métodos [ReadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-), y [WriteBindedPresentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#writeBindedPresentation-java.lang.String-) a [PresentationInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo), y se ha cambiado la lógica del setter de la propiedad [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/documentproperties#setLastSavedTime-java.util.Date-).  

{{% /alert %}} 

Los dos nuevos métodos [ReadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--) y [UpdateDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) se han añadido a la clase [PresentationInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo). Proporcionan acceso rápido a las propiedades de documento y permiten cambiar y actualizar las propiedades sin cargar una presentación completa.

El escenario típico de cargar las propiedades, cambiar algún valor y actualizar el documento se puede implementar de la siguiente manera:  
```javascript
// leer la información de la presentación
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");
// obtener las propiedades actuales
var props = info.readDocumentProperties();
// establecer los nuevos valores de los campos Autor y Título
props.setAuthor("New Author");
props.setTitle("New Title");
// actualizar la presentación con nuevos valores
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```


Existe otra forma de usar las propiedades de una presentación concreta como plantilla para actualizar propiedades en otras presentaciones:  
```javascript
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
function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```


Se puede crear una nueva plantilla desde cero y luego usarla para actualizar varias presentaciones:  
```javascript
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
function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```


## **Establecer idioma de revisión**

Aspose.Slides proporciona la propiedad LanguageId (expuesta por la clase PortionFormat) para permitirle establecer el idioma de revisión de un documento PowerPoint. El idioma de revisión es el idioma para el cual se verifica la ortografía y la gramática en PowerPoint.

Este código JavaScript le muestra cómo establecer el idioma de revisión para un PowerPoint: xxx Why is LanguageId missing from JavaScript PortionFormat class?  
```javascript
var pres = new aspose.slides.Presentation(pptxFileName);
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
    portionFormat.setLanguageId("zh-CN");// establecer el Id de un idioma de revisión
    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Establecer idioma predeterminado**

Este código JavaScript le muestra cómo establecer el idioma predeterminado para una presentación completa de PowerPoint:  
```javascript
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

Pruebe la aplicación en línea [**Aspose.Slides Metadata**](https://products.aspose.app/slides/metadata) para ver cómo trabajar con propiedades de documento mediante la API de Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## ***FAQ**

**¿Cómo puedo eliminar una propiedad integrada de una presentación?**

Las propiedades integradas forman parte integral de la presentación y no pueden eliminarse por completo. Sin embargo, puede cambiar sus valores o establecerlas como vacías si la propiedad lo permite.

**¿Qué ocurre si agrego una propiedad personalizada que ya existe?**

Si agrega una propiedad personalizada que ya existe, su valor actual será sobrescrito por el nuevo. No es necesario eliminar o verificar la propiedad previamente, ya que Aspose.Slides actualiza automáticamente el valor de la propiedad.

**¿Puedo acceder a las propiedades de la presentación sin cargarla completamente?**

Sí, puede acceder a las propiedades de la presentación sin cargarla completamente utilizando el método `getPresentationInfo` de la clase [PresentationFactory](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationfactory/). Luego, utilice el método `readDocumentProperties` proporcionado por la clase [PresentationInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationinfo/) para leer las propiedades de manera eficiente, ahorrando memoria y mejorando el rendimiento.