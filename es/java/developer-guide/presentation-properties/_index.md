---
title: Administrar propiedades de presentación en Java
linktitle: Propiedades de la presentación
type: docs
weight: 70
url: /es/java/presentation-properties/
keywords:
- propiedades de PowerPoint
- propiedades de presentación
- propiedades de documento
- propiedades incorporadas
- propiedades personalizadas
- propiedades avanzadas
- gestionar propiedades
- modificar propiedades
- metadatos del documento
- editar metadatos
- idioma de corrector
- idioma predeterminado
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Domina las propiedades de presentación en Aspose.Slides for Java y optimiza la búsqueda, la marca y el flujo de trabajo en tus archivos PowerPoint y OpenDocument."
---

{{% alert color="primary" %}} 

Microsoft PowerPoint ofrece una funcionalidad para agregar algunas propiedades a los archivos de presentación. Estas propiedades de documento permiten almacenar información útil junto con los documentos (archivos de presentación). Existen dos tipos de propiedades de documento como sigue

- Propiedades definidas por el sistema (Built-in)
- Propiedades definidas por el usuario (Custom)

**Built-in** propiedades contienen información general sobre el documento como el título del documento, el nombre del autor, estadísticas del documento, etc. **Custom** propiedades son aquellas que son definidas por los usuarios como pares **Name/Value**, donde tanto el nombre como el valor son definidos por el usuario. Usando Aspose.Slides for Java, los desarrolladores pueden acceder y modificar los valores de las propiedades built-in así como las propiedades custom.

{{% /alert %}} 

## **Propiedades de documento en PowerPoint**

Microsoft PowerPoint 2007 permite administrar las propiedades de documento de los archivos de presentación. Todo lo que tienes que hacer es hacer clic en el icono de Office y luego en el elemento de menú **Prepare | Properties | Advanced Properties** de Microsoft PowerPoint 2007 como se muestra a continuación:

{{% alert color="primary" %}} 

Ten en cuenta que no puedes establecer valores en los campos **Application** y **Producer**, porque Aspose Ltd. y Aspose.Slides for Java x.x.x se mostrarán en esos campos.

{{% /alert %}} 

|**Seleccionar elemento del menú Advanced Properties**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
Después de seleccionar el elemento del menú **Advanced Properties**, aparecerá un cuadro de diálogo que permite administrar las propiedades de documento del archivo PowerPoint como se muestra a continuación en la figura:

|**Cuadro de diálogo de propiedades**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
En el **Properties Dialog** anterior, puedes ver que hay varias pestañas como **General**, **Summary**, **Statistics**, **Contents** y **Custom**. Todas estas pestañas permiten configurar diferentes tipos de información relacionada con los archivos PowerPoint. La pestaña **Custom** se usa para administrar las propiedades custom de los archivos PowerPoint.

Working with Document Properties Using Aspose.Slides for Java

Como describimos anteriormente, Aspose.Slides for Java admite dos tipos de propiedades de documento, que son **Built-in** y **Custom**. Por lo tanto, los desarrolladores pueden acceder a ambos tipos de propiedades mediante la API de Aspose.Slides for Java. Aspose.Slides for Java proporciona una clase [IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides.idocumentproperties) que representa las propiedades de documento asociadas a un archivo de presentación a través de la propiedad **Presentation.DocumentProperties**.

Los desarrolladores pueden usar la propiedad **IDocumentProperties** expuesta por el objeto [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) para acceder a las propiedades de documento de los archivos de presentación como se describe a continuación:

## **Acceder a propiedades Built-in**

Estas propiedades expuestas por el objeto [IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides.idocumentproperties) incluyen: **Creator** (Autor), **Description**, **Keywords**, **Created** (Fecha de creación), **Modified** (Fecha de modificación), **Printed** (Fecha del último imprimado), **LastModifiedBy**, **Keywords**, **SharedDoc** (¿Se comparte entre diferentes productores?), **PresentationFormat**, **Subject** y **Title**
```java
// Instanciar la clase Presentation que representa la presentación
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Crear una referencia al objeto IDocumentProperties asociado a la presentación
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Mostrar las propiedades incorporadas
    System.out.println("Category : " + dp.getCategory());
    System.out.println("Current Status : " + dp.getContentStatus());
    System.out.println("Creation Date : " + dp.getCreatedTime());
    System.out.println("Author : " + dp.getAuthor());
    System.out.println("Description : " + dp.getComments());
    System.out.println("KeyWords : " + dp.getKeywords());
    System.out.println("Last Modified By : " + dp.getLastSavedBy());
    System.out.println("Supervisor : " + dp.getManager());
    System.out.println("Modified Date : " + dp.getLastSavedTime());
    System.out.println("Presentation Format : " + dp.getPresentationFormat());
    System.out.println("Last Print Date : " + dp.getLastPrinted());
    System.out.println("Is Shared between producers : " + dp.getSharedDoc());
    System.out.println("Subject : " + dp.getSubject());
    System.out.println("Title : " + dp.getTitle());
} finally {
    if (pres != null) pres.dispose();
}
```


## **Modificar propiedades Built-in**

Modificar las propiedades built-in de los archivos de presentación es tan fácil como acceder a ellas. Simplemente puedes asignar un valor de cadena a cualquier propiedad deseada y el valor de la propiedad será modificado. En el ejemplo que se muestra a continuación, hemos demostrado cómo podemos modificar las propiedades de documento built-in del archivo de presentación usando Aspose.Slides for Java.
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Crear una referencia al objeto IDocumentProperties asociado a la presentación
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Establecer las propiedades incorporadas
    dp.setAuthor("Aspose.Slides for Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    
    // Guardar su presentación en un archivo
    pres.save("DocProps.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


Este ejemplo modifica las propiedades built-in de la presentación, lo cual puede observarse como se muestra a continuación:

|**Built-in document properties after modification**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Agregar propiedades de documento Custom**

Aspose.Slides for Java también permite a los desarrolladores agregar valores custom a las propiedades de documento de la presentación. A continuación se muestra un ejemplo que indica cómo establecer propiedades custom para una presentación.
```java
Presentation pres = new Presentation();
try {
    // Obteniendo propiedades del documento
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // Agregando propiedades personalizadas
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    
    // Obteniendo el nombre de la propiedad en un índice específico
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // Eliminando la propiedad seleccionada
    dProps.removeCustomProperty(getPropertyName);
    
    // Guardando la presentación
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


|**Custom Document Properties Added**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Acceder y modificar propiedades Custom**

Aspose.Slides for Java también permite a los desarrolladores acceder a los valores de las propiedades custom. A continuación se muestra un ejemplo que indica cómo puedes acceder y modificar todas estas propiedades custom para una presentación.
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Crear una referencia al objeto DocumentProperties asociado con la presentación
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Acceder y modificar propiedades personalizadas
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Mostrar los nombres y valores de las propiedades personalizadas
        System.out.println("Custom Property Name : " + dp.getCustomPropertyName(i));
        System.out.println("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // Modificar los valores de las propiedades personalizadas
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    
    // Guardar su presentación en un archivo
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


Este ejemplo modifica las propiedades custom de la presentación [PPTX ](https://docs.fileformat.com/presentation/pptx/). Las siguientes figuras muestran las propiedades custom de la presentación antes y después de la modificación:

|**Custom Properties before Modification**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |


|**Custom Properties after Modification**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Propiedades de documento avanzadas**

{{% alert color="primary" %}} 

Se han agregado nuevos métodos [ReadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), y [WriteBindedPresentation](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) a [IPresentationInfo](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo), la lógica del setter de la propiedad [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) ha sido modificada.

{{% /alert %}} 

Los dos nuevos métodos [ReadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) y [UpdateDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) se han agregado a la interfaz [IPresentationInfo](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo). Proporcionan acceso rápido a las propiedades de documento y permiten cambiar y actualizar propiedades sin cargar una presentación completa.

El escenario típico de cargar las propiedades, cambiar algún valor y actualizar el documento puede implementarse de la siguiente manera:
```java
// leer la información de la presentación
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// obtain the current properties
IDocumentProperties props = info.readDocumentProperties();

// set the new values of Author and Title fields
props.setAuthor("New Author");
props.setTitle("New Title");

// update the presentation with a new values
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```


Existe otra forma de usar las propiedades de una presentación específica como plantilla para actualizar propiedades en otras presentaciones:
```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("template.pptx");
DocumentProperties template = (DocumentProperties) info.readDocumentProperties();

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

```java
private static void updateByTemplate(String path, IDocumentProperties template) 
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```


Una nueva plantilla puede crearse desde cero y luego usarse para actualizar múltiples presentaciones:
```java
DocumentProperties template = new DocumentProperties();\

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

```java
private static void updateByTemplate(String path, IDocumentProperties template) 
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```


## **Establecer idioma de corrección**

Aspose.Slides proporciona la propiedad LanguageId (expuesta por la clase PortionFormat) para permitir establecer el idioma de corrección de un documento PowerPoint. El idioma de corrección es el idioma para el cual se revisan la ortografía y la gramática en PowerPoint.

Este código Java muestra cómo establecer el idioma de corrección para un PowerPoint: xxx ¿Por qué falta LanguageId en la clase Java PortionFormat?
```java
Presentation pres = new Presentation(pptxFileName);
try {
    AutoShape autoShape = (AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    Portion newPortion = new Portion();

    IFontData font = new FontData("SimSun");
    IPortionFormat portionFormat = newPortion.getPortionFormat();
    portionFormat.setComplexScriptFont(font);
    portionFormat.setEastAsianFont(font);
    portionFormat.setLatinFont(font);

    portionFormat.setLanguageId("zh-CN"); // establecer el Id del idioma de corrección

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Establecer idioma predeterminado**

Este código Java muestra cómo establecer el idioma predeterminado para una presentación PowerPoint completa:
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // Agrega una nueva forma rectangular con texto
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // Verifica el idioma de la primera porción
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```


## **Ejemplo en vivo**

Prueba la aplicación en línea [**Aspose.Slides Metadata**](https://products.aspose.app/slides/metadata) para ver cómo trabajar con propiedades de documento a través de la API de Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## ***Preguntas frecuentes**

**¿Cómo puedo eliminar una propiedad built-in de una presentación?**

Las propiedades built-in son una parte integral de la presentación y no pueden eliminarse por completo. Sin embargo, puedes cambiar sus valores o establecerlas como vacías si la propiedad específica lo permite.

**¿Qué ocurre si agrego una propiedad custom que ya existe?**

Si agregas una propiedad custom que ya existe, su valor existente será sobrescrito con el nuevo. No necesitas eliminar o verificar la propiedad previamente, ya que Aspose.Slides actualiza automáticamente el valor de la propiedad.

**¿Puedo acceder a las propiedades de la presentación sin cargarla completamente?**

Sí, puedes acceder a las propiedades de la presentación sin cargarla completamente usando el método `getPresentationInfo` de la clase [PresentationFactory](https://reference.aspose.com/slides/java/com.aspose.slides/presentationfactory/). Luego, utiliza el método `readDocumentProperties` proporcionado por la interfaz [IPresentationInfo](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationinfo/) para leer las propiedades de manera eficiente, ahorrando memoria y mejorando el rendimiento.