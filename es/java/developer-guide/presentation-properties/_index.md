---
title: Gestionar propiedades de presentación en Java
linktitle: Propiedades de presentación
type: docs
weight: 70
url: /es/java/presentation-properties/
keywords:
- Propiedades de PowerPoint
- Propiedades de presentación
- Propiedades de documento
- Propiedades integradas
- Propiedades personalizadas
- Propiedades avanzadas
- Gestionar propiedades
- Modificar propiedades
- Metadatos de documento
- Editar metadatos
- Idioma de revisión
- Idioma predeterminado
- PowerPoint
- OpenDocument
- Presentación
- Java
- Aspose.Slides
description: "Domina las propiedades de presentación en Aspose.Slides para Java y optimiza la búsqueda, la identidad de marca y el flujo de trabajo en tus archivos PowerPoint y OpenDocument."
---
## **Introducción**

Aspose.Slides admite dos tipos de propiedades de documento: **Built-in** y **Custom**. Ambos tipos de propiedades pueden accederse y gestionarse fácilmente mediante la API de Aspose.Slides.

Aspose.Slides le permite trabajar con las propiedades de documento de una presentación a través de la interfaz [IDocumentProperties](https://reference.aspose.com/slides/es/java/com.aspose.slides/idocumentproperties/). Una instancia de esta interfaz se devuelve mediante el método [Presentation.getDocumentProperties](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/#getDocumentProperties--) . Los ejemplos siguientes muestran cómo leer, modificar y gestionar estas propiedades.

{{% alert color="info" title="Note" %}}
Tenga en cuenta que los campos **Application** y **AppVersion** no pueden modificarse. Aspose.Slides los reescribe en cada guardado, por lo que una presentación guardada siempre indica "Aspose.Slides for Java" y la versión de la biblioteca que la generó. Cualquier valor pasado a `setNameOfApplication` se descarta cuando se escribe la presentación.
{{% /alert %}} 

## **Propiedades de documento en PowerPoint**

Microsoft PowerPoint 2007 permite gestionar las propiedades de documento de los archivos de presentación. Todo lo que tiene que hacer es hacer clic en el icono de Office y luego en el elemento de menú **Prepare | Properties | Advanced Properties** de Microsoft PowerPoint 2007, como se muestra a continuación:

|**Seleccionar elemento del menú Propiedades avanzadas**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
Después de seleccionar el elemento del menú **Advanced Properties**, aparecerá un cuadro de diálogo que le permitirá gestionar las propiedades de documento del archivo PowerPoint, como se muestra a continuación en la figura:

|**Diálogo de propiedades**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
En el **Properties Dialog** anterior, puede observar que hay varias pestañas como **General**, **Summary**, **Statistics**, **Contents** y **Custom**. Todas estas pestañas permiten configurar distintos tipos de información relacionadas con los archivos PowerPoint. La pestaña **Custom** se utiliza para gestionar las propiedades personalizadas de los archivos PowerPoint.

### Trabajar con propiedades de documento usando Aspose.Slides para Java

Como describimos antes, Aspose.Slides para Java admite dos tipos de propiedades de documento, que son **Built-in** y **Custom**. Por lo tanto, los desarrolladores pueden acceder a ambos tipos de propiedades mediante la API de Aspose.Slides para Java. Aspose.Slides para Java proporciona la clase [IDocumentProperties](https://reference.aspose.com/slides/es/java/com.aspose.slides/idocumentproperties) que representa las propiedades de documento asociadas a un archivo de presentación a través de la propiedad **Presentation.DocumentProperties**.

Los desarrolladores pueden usar la propiedad **IDocumentProperties** expuesta por el objeto [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation) para acceder a las propiedades de documento de los archivos de presentación como se describe a continuación:

## **Acceder a propiedades integradas**

Estas propiedades expuestas por el objeto [IDocumentProperties](https://reference.aspose.com/slides/es/java/com.aspose.slides/idocumentproperties) incluyen: **Creator** (Autor), **Description**, **Keywords**, **Created** (Fecha de creación), **Modified** (Fecha de modificación), **Printed** (Fecha del último imprimado), **LastModifiedBy**, **Keywords**, **SharedDoc** (¿Se comparte entre diferentes usuarios?), **PresentationFormat**, **Subject** y **Title**.

```java
import com.aspose.slides.*;

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

Modificar las propiedades integradas de los archivos de presentación es tan sencillo como acceder a ellas. Simplemente asigne un valor de cadena a la propiedad deseada y el valor será modificado. En el ejemplo que sigue, demostramos cómo modificar las propiedades de documento integradas del archivo de presentación mediante Aspose.Slides para Java.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Crear una referencia al objeto IDocumentProperties asociado a Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Establecer las propiedades integradas
    dp.setAuthor("Aspose.Slides for Java");
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

Este ejemplo modifica las propiedades integradas de la presentación, como se muestra a continuación:

|**Propiedades de documento integradas después de la modificación**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Agregar propiedades de documento personalizadas**

Aspose.Slides para Java también permite a los desarrolladores añadir valores personalizados a las propiedades de documento de la presentación. El ejemplo a continuación añade tres propiedades personalizadas, luego busca el nombre almacenado en el índice 2 y elimina esa propiedad, de modo que la presentación guardada conserva dos de ellas. Las propiedades personalizadas se ordenan alfabéticamente, no en el orden en que se añadieron.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Obtener propiedades del documento
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // Añadir propiedades personalizadas
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    
    // Obtener el nombre de la propiedad en un índice concreto
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

Aspose.Slides para Java también permite a los desarrolladores acceder a los valores de las propiedades personalizadas. A continuación se muestra un ejemplo que ilustra cómo acceder y modificar todas estas propiedades personalizadas de una presentación.

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
    
    // Guardar la presentación en un archivo
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Este ejemplo modifica las propiedades personalizadas de la [PPTX](https://docs.fileformat.com/presentation/pptx/) presentación. Las siguientes figuras muestran las propiedades personalizadas de la presentación antes y después de la modificación:

|**Propiedades personalizadas antes de la modificación**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Propiedades personalizadas después de la modificación**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Propiedades avanzadas de documento**

{{% alert color="info" title="Note" %}}
Se han añadido los nuevos métodos [ReadDocumentProperties](https://reference.aspose.com/slides/es/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/es/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), y [WriteBindedPresentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) a [IPresentationInfo](https://reference.aspose.com/slides/es/java/com.aspose.slides/IPresentationInfo); la lógica del setter de la propiedad [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/es/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) ha cambiado.
{{% /alert %}} 

Los dos nuevos métodos [ReadDocumentProperties](https://reference.aspose.com/slides/es/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) y [UpdateDocumentProperties](https://reference.aspose.com/slides/es/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) se han añadido a la interfaz [IPresentationInfo](https://reference.aspose.com/slides/es/java/com.aspose.slides/IPresentationInfo). Permiten un acceso rápido a las propiedades de documento y posibilitan cambiar y actualizar las propiedades sin cargar toda la presentación.

El escenario típico de cargar las propiedades, modificar algún valor y actualizar el documento puede implementarse de la siguiente manera:

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

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" }) {
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
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

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" }) {
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **Establecer idioma de revisión**

Aspose.Slides proporciona la propiedad LanguageId (expuesta por la clase PortionFormat) para permitirle establecer el idioma de revisión de un documento PowerPoint. El idioma de revisión es el idioma con el que se comprueban la ortografía y la gramática en PowerPoint.

Este código Java muestra cómo establecer el idioma de revisión para un PowerPoint:

```java
import com.aspose.slides.*;

String pptxFileName = "presentation.pptx";

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

Este código Java muestra cómo establecer el idioma predeterminado para toda una presentación PowerPoint:

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

Pruebe la aplicación en línea [**Aspose.Slides Metadata**](https://products.aspose.app/slides/es/metadata) para ver cómo trabajar con las propiedades de documento a través de la API de Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/es/metadata)

## **Preguntas frecuentes**

**¿Cómo puedo eliminar una propiedad integrada de una presentación?**

Las propiedades integradas forman parte esencial de la presentación y no pueden eliminarse por completo. Sin embargo, puede cambiar sus valores o establecerlas en vacío si la propiedad lo permite.

**¿Qué ocurre si agrego una propiedad personalizada que ya existe?**

Si agrega una propiedad personalizada que ya existe, su valor actual será sobrescrito por el nuevo. No es necesario eliminarla ni comprobarla previamente, ya que Aspose.Slides actualiza automáticamente el valor de la propiedad.

**¿Puedo acceder a las propiedades de la presentación sin cargarla completamente?**

Sí. Use [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) y luego [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/es/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) para leer los metadatos almacenados sin crear una instancia de [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/). Consulte [Build a Lightweight Presentation Inventory](/slides/es/java/examine-presentation/) para un ejemplo completo de informe y limitaciones específicas por formato.