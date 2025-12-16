---
title: Administrar propiedades de presentación en Android
linktitle: Propiedades de presentación
type: docs
weight: 70
url: /es/androidjava/presentation-properties/
keywords:
- Propiedades de PowerPoint
- Propiedades de presentación
- Propiedades de documento
- Propiedades integradas
- Propiedades personalizadas
- Propiedades avanzadas
- Administrar propiedades
- Modificar propiedades
- Metadatos de documento
- Editar metadatos
- Idioma de revisión
- Idioma predeterminado
- PowerPoint
- OpenDocument
- presentación
- Android
- Java
- Aspose.Slides
description: "Domina las propiedades de presentación en Aspose.Slides for Android via Java y optimiza la búsqueda, la marca y el flujo de trabajo en tus archivos PowerPoint y OpenDocument."
---

{{% alert color="primary" %}} 

Microsoft PowerPoint proporciona una característica para añadir algunas propiedades a los archivos de presentación. Estas propiedades de documento permiten almacenar información útil junto con los documentos (archivos de presentación). Existen dos tipos de propiedades de documento:

- Propiedades Definidas por el Sistema (Built-in)
- Propiedades Definidas por el Usuario (Custom)

**Built-in** properties contienen información general sobre el documento, como el título, el nombre del autor, estadísticas del documento, etc. **Custom** properties son aquellas definidas por los usuarios como pares **Nombre/Valor**, donde tanto el nombre como el valor son definidos por el usuario. Usando Aspose.Slides for Android via Java, los desarrolladores pueden acceder y modificar los valores de las propiedades integradas así como de las propiedades personalizadas.

{{% /alert %}} 

## **Propiedades de documento en PowerPoint**

Microsoft PowerPoint 2007 permite gestionar las propiedades del documento de los archivos de presentación. Todo lo que tienes que hacer es hacer clic en el icono de Office y luego en el elemento de menú **Prepare | Properties | Advanced Properties** de Microsoft PowerPoint 2007 como se muestra a continuación:

{{% alert color="primary" %}} 

Tenga en cuenta que no puede establecer valores en los campos **Application** y **Producer**, porque Aspose Ltd. y Aspose.Slides for Android via Java x.x.x se mostrarán en esos campos.

{{% /alert %}} 

|**Seleccionar elemento del menú Advanced Properties**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
Después de seleccionar el elemento del menú **Advanced Properties**, aparecerá un diálogo que le permitirá gestionar las propiedades del documento del archivo PowerPoint como se muestra a continuación:

|**Diálogo de propiedades**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
En el **Properties Dialog** anterior, puedes ver que hay varias pestañas como **General**, **Summary**, **Statistics**, **Contents** y **Custom**. Todas estas pestañas permiten configurar diferentes tipos de información relacionada con los archivos de PowerPoint. La pestaña **Custom** se utiliza para gestionar las propiedades personalizadas de los archivos de PowerPoint.



Trabajar con propiedades de documento usando Aspose.Slides for Android via Java

Como describimos anteriormente, Aspose.Slides for Android via Java admite dos tipos de propiedades de documento, que son **Built-in** y **Custom**. Por lo tanto, los desarrolladores pueden acceder a ambos tipos de propiedades mediante la API de Aspose.Slides for Android via Java. Aspose.Slides for Android via Java proporciona la clase [IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties) que representa las propiedades del documento asociadas a un archivo de presentación a través de la propiedad **Presentation.DocumentProperties**.

Los desarrolladores pueden usar la propiedad **IDocumentProperties** expuesta por el objeto [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) para acceder a las propiedades del documento de los archivos de presentación como se describe a continuación:

## **Acceder a propiedades integradas**

Estas propiedades expuestas por el objeto IDocumentProperties incluyen: **Creator** (Autor), **Description**, **Keywords**, **Created** (Fecha de creación), **Modified** (Fecha de modificación), **Printed** (Fecha de la última impresión), **LastModifiedBy**, **Keywords**, **SharedDoc** (¿Compartido entre diferentes productores?), **PresentationFormat**, **Subject** y **Title**.
```java
// Instanciar la clase Presentation que representa la presentación
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Crear una referencia al objeto IDocumentProperties asociado a Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Mostrar las propiedades integradas
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


## **Modificar propiedades integradas**

Modificar las propiedades integradas de los archivos de presentación es tan sencillo como acceder a ellas. Simplemente puedes asignar un valor de cadena a cualquier propiedad deseada y el valor de la propiedad será modificado. En el ejemplo a continuación, demostramos cómo podemos modificar las propiedades de documento integradas del archivo de presentación utilizando Aspose.Slides for Android via Java.
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Crear una referencia al objeto IDocumentProperties asociado a Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Establecer las propiedades integradas
    dp.setAuthor("Aspose.Slides for Android via Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    
    // Guardar la presentación en un archivo
    pres.save("DocProps.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


Este ejemplo modifica las propiedades integradas de la presentación, que pueden verse como se muestra a continuación:

|**Propiedades de documento integradas después de la modificación**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Añadir propiedades de documento personalizadas**

Aspose.Slides for Android via Java también permite a los desarrolladores añadir valores personalizados para las propiedades de documento de la presentación. A continuación se muestra un ejemplo que indica cómo establecer las propiedades personalizadas para una presentación.
```java
Presentation pres = new Presentation();
try {
    // Obtener propiedades del documento
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // Agregar propiedades personalizadas
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    
    // Obtener nombre de la propiedad en índice específico
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // Eliminar la propiedad seleccionada
    dProps.removeCustomProperty(getPropertyName);
    
    // Guardar la presentación
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


|**Propiedades de documento personalizadas añadidas**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Acceder y modificar propiedades personalizadas**

Aspose.Slides for Android via Java también permite a los desarrolladores acceder a los valores de las propiedades personalizadas. A continuación se muestra un ejemplo que indica cómo puedes acceder y modificar todas estas propiedades personalizadas para una presentación.
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Crear una referencia al objeto DocumentProperties asociado a Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Acceder y modificar propiedades personalizadas
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Mostrar nombres y valores de las propiedades personalizadas
        System.out.println("Custom Property Name : " + dp.getCustomPropertyName(i));
        System.out.println("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // Modificar valores de las propiedades personalizadas
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    
    // Guardar su presentación en un archivo
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


Este ejemplo modifica las propiedades personalizadas de la [PPTX ](https://docs.fileformat.com/presentation/pptx/)presentación. Las siguientes figuras muestran las propiedades personalizadas de la presentación antes y después de la modificación:

|**Propiedades personalizadas antes de la modificación**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |


|**Propiedades personalizadas después de la modificación**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Propiedades de documento avanzadas**

{{% alert color="primary" %}} 

Se han añadido los nuevos métodos [ReadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), y [WriteBindedPresentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) a [IPresentationInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo), y se ha cambiado la lógica del setter de la propiedad [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-).

{{% /alert %}} 

Los dos nuevos métodos [ReadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--) y [UpdateDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) se han añadido a la interfaz [IPresentationInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo). Proporcionan acceso rápido a las propiedades del documento y permiten cambiar y actualizar las propiedades sin cargar una presentación completa.

El escenario típico de cargar las propiedades, cambiar algún valor y actualizar el documento puede implementarse de la siguiente manera:
```java
// leer la información de la presentación
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// obtener las propiedades actuales
IDocumentProperties props = info.readDocumentProperties();

// establecer los nuevos valores de los campos Autor y Título
props.setAuthor("New Author");
props.setTitle("New Title");

// actualizar la presentación con nuevos valores
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```


Existe otra forma de usar las propiedades de una presentación como plantilla para actualizar las propiedades en otras presentaciones:
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


Se puede crear una nueva plantilla desde cero y luego usarla para actualizar múltiples presentaciones:
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


## **Establecer idioma de revisión**

Aspose.Slides proporciona la propiedad LanguageId (expuesta por la clase PortionFormat) para permitir establecer el idioma de revisión de un documento PowerPoint. El idioma de revisión es el idioma para el cual se verifica la ortografía y la gramática en PowerPoint.

Este código Java muestra cómo establecer el idioma de revisión para un PowerPoint: xxx Why is LanguageId missing from Java PortionFormat class?
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

    portionFormat.setLanguageId("zh-CN"); // establecer el Id de un idioma de revisión

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Establecer idioma predeterminado**

Este código Java muestra cómo establecer el idioma predeterminado para una presentación completa de PowerPoint:
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // Añade una nueva forma rectangular con texto
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // Comprueba el idioma de la primera porción
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```


## **Ejemplo en vivo**

Pruebe la aplicación en línea [**Aspose.Slides Metadata**](https://products.aspose.app/slides/metadata) para ver cómo trabajar con propiedades de documento a través de la API de Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## ***Preguntas frecuentes**

**¿Cómo puedo eliminar una propiedad integrada de una presentación?**

Las propiedades integradas forman parte integral de la presentación y no pueden eliminarse por completo. Sin embargo, puedes cambiar sus valores o establecerlas en vacío si la propiedad específica lo permite.

**¿Qué ocurre si añado una propiedad personalizada que ya existe?**

Si añades una propiedad personalizada que ya existe, su valor actual será sobrescrito con el nuevo. No es necesario eliminarla o comprobarla previamente, ya que Aspose.Slides actualiza automáticamente el valor de la propiedad.

**¿Puedo acceder a las propiedades de la presentación sin cargarla completamente?**

Sí, puedes acceder a las propiedades de la presentación sin cargarla completamente usando el método `getPresentationInfo` de la clase [PresentationFactory](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationfactory/). Luego, utiliza el método `readDocumentProperties` proporcionado por la interfaz [IPresentationInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationinfo/) para leer las propiedades de manera eficiente, ahorrando memoria y mejorando el rendimiento.