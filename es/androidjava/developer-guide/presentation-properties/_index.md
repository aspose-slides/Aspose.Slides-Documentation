---
title: Gestionar propiedades de presentación en Android
linktitle: Propiedades de presentación
type: docs
weight: 70
url: /es/androidjava/presentation-properties/
keywords:
- Propiedades de PowerPoint
- Propiedades de presentación
- Propiedades del documento
- Propiedades incorporadas
- Propiedades personalizadas
- Propiedades avanzadas
- Gestionar propiedades
- Modificar propiedades
- Metadatos del documento
- Editar metadatos
- Idioma de revisión
- Idioma predeterminado
- PowerPoint
- OpenDocument
- presentación
- Android
- Java
- Aspose.Slides
description: "Domine las propiedades de presentación en Aspose.Slides para Android mediante Java y optimice la búsqueda, la marca y el flujo de trabajo en sus archivos PowerPoint y OpenDocument."
---
## **Introducción**

Aspose.Slides admite dos tipos de propiedades de documento: **Built-in** y **Custom**. Ambos tipos de propiedades pueden accederse y gestionarse fácilmente mediante la API de Aspose.Slides.

Aspose.Slides le permite trabajar con las propiedades del documento de una presentación a través de la interfaz [IDocumentProperties](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/idocumentproperties/) . Una instancia de esta interfaz es devuelta por el método [Presentation.getDocumentProperties](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/#getDocumentProperties--) . Los siguientes ejemplos muestran cómo leer, modificar y gestionar estas propiedades.

{{% alert color="info" title="Note" %}}
Tenga en cuenta que los campos **Application** y **AppVersion** no pueden modificarse. Aspose.Slides los sobrescribe en cada guardado, por lo que una presentación guardada siempre muestra el nombre del producto Aspose.Slides y la versión de la biblioteca que la generó. Cualquier valor pasado a `setNameOfApplication` se descarta cuando se escribe la presentación.
{{% /alert %}} 

## **Propiedades del documento en PowerPoint**

Microsoft PowerPoint 2007 permite gestionar las propiedades del documento de los archivos de presentación. Todo lo que tiene que hacer es pulsar el icono de Office y el elemento del menú **Prepare | Properties | Advanced Properties** de Microsoft PowerPoint 2007 como se muestra a continuación:

|**Seleccionar la opción del menú Propiedades avanzadas**|**|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)||
Después de seleccionar el elemento del menú **Advanced Properties**, aparecerá un cuadro de diálogo que permite gestionar las propiedades del documento del archivo PowerPoint, como se muestra a continuación:

|**Diálogo de propiedades**|**|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)||
En el **Diálogo de propiedades** anterior, puede ver que hay varias pestañas como **General**, **Summary**, **Statistics**, **Contents** y **Custom**. Todas estas pestañas permiten configurar diferentes tipos de información relacionados con los archivos PowerPoint. La pestaña **Custom** se usa para gestionar las propiedades personalizadas de los archivos PowerPoint.

## **Trabajar con propiedades de documento usando Aspose.Slides para Android a través de Java**

Como hemos descrito anteriormente, Aspose.Slides para Android a través de Java admite dos tipos de propiedades de documento, que son **Built-in** y **Custom**. Por lo tanto, los desarrolladores pueden acceder a ambos tipos de propiedades mediante la API de Aspose.Slides para Android a través de Java. Aspose.Slides para Android a través de Java proporciona una clase [IDocumentProperties](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/idocumentproperties) que representa las propiedades del documento asociadas a un archivo de presentación a través de la propiedad **Presentation.DocumentProperties**.

Los desarrolladores pueden usar la propiedad **IDocumentProperties** expuesta por el objeto [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation) para acceder a las propiedades del documento de los archivos de presentación como se describe a continuación:

## **Acceder a propiedades incorporadas**

Estas propiedades expuestas por el objeto [IDocumentProperties](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/idocumentproperties) incluyen: **Creator** (Autor), **Description**, **Keywords**, **Created** (Fecha de creación), **Modified** (Fecha de modificación), **Printed** (Fecha del último impresión), **LastModifiedBy**, **Keywords**, **SharedDoc** (¿Compartido entre diferentes productores?), **PresentationFormat**, **Subject** y **Title**.

```java
import com.aspose.slides.*;

// Instanciar la clase Presentation que representa la presentación
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Crear una referencia al objeto IDocumentProperties asociado a Presentation
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

## **Modificar propiedades incorporadas**

Modificar las propiedades incorporadas de los archivos de presentación es tan fácil como acceder a ellas. Simplemente asigne un valor de cadena a la propiedad deseada y el valor de la propiedad se modificará. En el ejemplo que se muestra a continuación, hemos demostrado cómo podemos modificar las propiedades incorporadas del documento de la presentación usando Aspose.Slides para Android a través de Java.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Crear una referencia al objeto IDocumentProperties asociado a Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Establecer las propiedades incorporadas
    dp.setAuthor("Aspose.Slides for Android via Java");
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

Este ejemplo modifica las propiedades incorporadas de la presentación que pueden verse como se muestra a continuación:

|**Propiedades de documento incorporadas después de la modificación**|**|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)||

## **Agregar propiedades personalizadas del documento**

Aspose.Slides para Android a través de Java también permite a los desarrolladores agregar valores personalizados para las propiedades del documento de la presentación. El ejemplo a continuación agrega tres propiedades personalizadas, luego busca el nombre almacenado en el índice 2 y elimina esa propiedad, de modo que la presentación guardada conserva dos de ellas. Las propiedades personalizadas se indexan en orden alfabético, no en el orden en que se añadieron.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Obtener propiedades del documento
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // Añadiendo propiedades personalizadas
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    
    // Obtener el nombre de la propiedad en un índice particular
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // Eliminando la propiedad seleccionada
    dProps.removeCustomProperty(getPropertyName);
    
    // Guardando la presentación
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**Propiedades personalizadas del documento añadidas**|**|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)||

## **Acceder y modificar propiedades personalizadas**

Aspose.Slides para Android a través de Java también permite a los desarrolladores acceder a los valores de las propiedades personalizadas. A continuación se muestra un ejemplo que indica cómo puede acceder y modificar todas estas propiedades personalizadas para una presentación.

```java
import com.aspose.slides.*;

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

Este ejemplo modifica las propiedades personalizadas de la presentación [PPTX](https://docs.fileformat.com/presentation/pptx/). Las figuras siguientes muestran las propiedades personalizadas de la presentación antes y después de la modificación:

|**Propiedades personalizadas antes de la modificación**|**|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)||

|**Propiedades personalizadas después de la modificación**|**|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)||

## **Propiedades avanzadas del documento**

{{% alert color="info" title="Note" %}}
Nuevos métodos [ReadDocumentProperties](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), y [WriteBindedPresentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) se han añadido a [IPresentationInfo](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IPresentationInfo), la lógica del setter de la propiedad [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) ha sido cambiada.
{{% /alert %}} 

Los dos nuevos métodos [ReadDocumentProperties](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--) y [UpdateDocumentProperties](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) se han añadido a la interfaz [IPresentationInfo](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IPresentationInfo). Proporcionan acceso rápido a las propiedades del documento y permiten cambiar y actualizar las propiedades sin cargar una presentación completa.

El escenario típico que carga las propiedades, cambia algún valor y actualiza el documento puede implementarse de la siguiente manera:

```java
import com.aspose.slides.*;

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

Existe otra forma de usar las propiedades de una presentación concreta como plantilla para actualizar propiedades en otras presentaciones:

```java
import com.aspose.slides.*;

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
import com.aspose.slides.*;

private static void updateByTemplate(String path, IDocumentProperties template) 
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

Se puede crear una nueva plantilla desde cero y luego usarla para actualizar varias presentaciones:

```java
import com.aspose.slides.*;

DocumentProperties template = new DocumentProperties();

template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" })
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **Establecer idioma de revisión**

Aspose.Slides proporciona la propiedad LanguageId (expuesta por la clase PortionFormat) para permitirle establecer el idioma de revisión de un documento PowerPoint. El idioma de revisión es el idioma para el que se revisan ortografía y gramática en PowerPoint.

Este código Java le muestra cómo establecer el idioma de revisión para un PowerPoint:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
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

Este código Java le muestra cómo establecer el idioma predeterminado para toda una presentación PowerPoint:

```java
import com.aspose.slides.*;

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

Pruebe la aplicación en línea **Aspose.Slides Metadata** para ver cómo trabajar con propiedades de documento mediante la API de Aspose.Slides:

[![Ver y editar metadatos de PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/es/metadata)

## **Preguntas frecuentes**

**¿Cómo puedo eliminar una propiedad incorporada de una presentación?**

Las propiedades incorporadas son una parte integral de la presentación y no pueden eliminarse por completo. Sin embargo, puede cambiar sus valores o establecerlas en vacío si la propiedad específica lo permite.

**¿Qué ocurre si añado una propiedad personalizada que ya existe?**

Si añade una propiedad personalizada que ya existe, su valor actual será sobrescrito por el nuevo. No es necesario eliminar o comprobar la propiedad previamente, ya que Aspose.Slides actualiza automáticamente el valor de la propiedad.

**¿Puedo acceder a las propiedades de la presentación sin cargarla completamente?**

Sí. Utilice [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) y luego [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) para leer los metadatos del documento almacenados sin crear una instancia de [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/) . Consulte [Build a Lightweight Presentation Inventory](/slides/es/androidjava/examine-presentation/) para un ejemplo completo de informes y limitaciones específicas de formato.