---
title: Gestionar propiedades de la presentación en Android
linktitle: Propiedades de la presentación
type: docs
weight: 70
url: /es/androidjava/presentation-properties/
keywords:
- Propiedades de PowerPoint
- Propiedades de la presentación
- Propiedades del documento
- Propiedades integradas
- Propiedades personalizadas
- Propiedades avanzadas
- Gestionar propiedades
- Modificar propiedades
- Metadatos del documento
- Editar metadatos
- Idioma de corrección
- Idioma predeterminado
- PowerPoint
- OpenDocument
- presentación
- Android
- Java
- Aspose.Slides
description: "Domina las propiedades de la presentación en Aspose.Slides para Android mediante Java y optimiza la búsqueda, la marca y el flujo de trabajo en tus archivos PowerPoint y OpenDocument."
---
## **Introducción**

Aspose.Slides admite dos tipos de propiedades de documento: **Integradas** y **Personalizadas**. Ambos tipos de propiedades pueden accederse y gestionarse fácilmente mediante la API de Aspose.Slides.

Aspose.Slides le permite trabajar con las propiedades de documento de una presentación a través de la interfaz [IDocumentProperties](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/idocumentproperties/). Una instancia de esta interfaz se obtiene mediante [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--). Los ejemplos siguientes muestran cómo leer, modificar y gestionar estas propiedades.

{{% alert color="info" title="Nota" %}}
Tenga en cuenta que los campos **Application** y **AppVersion** no pueden modificarse. Aspose.Slides los sobrescribe en cada guardado, por lo que una presentación guardada siempre indica el nombre del producto Aspose.Slides y la versión de la biblioteca que la generó. Cualquier valor pasado a `setNameOfApplication` se descarta al escribir la presentación.
{{% /alert %}} 

## **Propiedades del documento en PowerPoint**

Microsoft PowerPoint 2007 permite gestionar las propiedades del documento de los archivos de presentación. Todo lo que tiene que hacer es hacer clic en el icono de Office y luego el elemento del menú **Prepare | Properties | Advanced Properties** de Microsoft PowerPoint 2007 como se muestra a continuación:

|**Seleccionar elemento del menú Propiedades avanzadas**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Después de seleccionar el elemento del menú **Advanced Properties**, aparecerá un cuadro de diálogo que permite gestionar las propiedades del documento del archivo PowerPoint, como se muestra a continuación en la figura:

|**Cuadro de diálogo de propiedades**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

En el **Cuadro de diálogo de propiedades** anterior, puede ver que hay varias pestañas como **General**, **Summary**, **Statistics**, **Contents** y **Custom**. Todas estas pestañas permiten configurar diferentes tipos de información relacionada con los archivos PowerPoint. La pestaña **Custom** se utiliza para gestionar las propiedades personalizadas de los archivos PowerPoint.



Trabajar con las propiedades del documento usando Aspose.Slides para Android mediante Java

Como hemos descrito anteriormente, Aspose.Slides para Android mediante Java admite dos tipos de propiedades de documento, que son propiedades **Integradas** y **Personalizadas**. Por lo tanto, los desarrolladores pueden acceder a ambos tipos de propiedades mediante la API de Aspose.Slides para Android mediante Java. Aspose.Slides para Android mediante Java proporciona una clase [IDocumentProperties](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/idocumentproperties) que representa las propiedades del documento asociadas a un archivo de presentación a través de la propiedad **Presentation.DocumentProperties**.

Los desarrolladores pueden usar la propiedad **IDocumentProperties** expuesta por el objeto [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation) para acceder a las propiedades del documento de los archivos de presentación, como se describe a continuación:

## **Leer propiedades públicas de una presentación cifrada**

Una contraseña de apertura normalmente protege tanto el contenido de la presentación como las propiedades del documento. Cuando una presentación se cifra pasando `false` a [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-), sus propiedades de documento permanecen públicas. Una aplicación puede entonces pasar `true` a [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) y leer los metadatos públicos sin proporcionar la contraseña de apertura.

La opción de sólo cargar propiedades del documento controla lo que Aspose.Slides carga; no descifra nada. Si las propiedades estaban incluidas en el cifrado, cargarlas sin la contraseña falla. Si la presentación no está cifrada, la opción se ignora y se carga la presentación completa.

El siguiente ejemplo verifica el modo de carga a través de [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) y luego lee las propiedades integradas mediante [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--):

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        IDocumentProperties properties = presentation.getDocumentProperties();

        System.out.println("Author: " + properties.getAuthor());
        System.out.println("Title: " + properties.getTitle());
        System.out.println("Keywords: " + properties.getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

En este modo, el contenido de las diapositivas no se carga. Las diapositivas, maestros, diseños, formas, medios y otros objetos de presentación no están disponibles. Las aplicaciones deben siempre comprobar [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) antes de realizar una operación que requiera el modelo de objeto de presentación completo.

{{% alert color="warning" title="Advertencia" %}}
Los metadatos públicos pueden revelar nombres de autores, títulos, asuntos, palabras clave, información de la empresa, comentarios y valores personalizados. Encripte las propiedades sensibles junto con la presentación. Déjelas públicas sólo cuando los sistemas de indexación, clasificación, búsqueda o gestión documental tengan un requisito específico para acceder a ellas sin una contraseña.
{{% /alert %}}

## **Actualizar propiedades de una presentación cifrada**

Para un archivo PPTX cifrado, una presentación cargada en modo solo propiedades del documento está destinada a leer los metadatos públicos. Aspose.Slides no puede guardar propiedades modificadas de ese objeto de solo metadatos porque las propiedades públicas deben permanecer consistentes con los datos correspondientes dentro de la presentación cifrada. Por lo tanto, actualizarlas requiere la contraseña de apertura correcta y una carga completa.

El siguiente ejemplo abre la presentación con [LoadOptions.setPassword](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-), actualiza las propiedades integradas públicas y guarda el resultado. A continuación utiliza [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ipresentationinfo/#isEncrypted--) para verificar que el cifrado se mantiene y vuelve a abrir los metadatos públicos sin una contraseña para comprobar los nuevos valores:

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;
import com.aspose.slides.SaveFormat;

final String inputPath = "public-properties-encrypted.pptx";
final String outputPath = "updated-public-properties-encrypted.pptx";

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation(inputPath, loadOptions);
try {
    presentation.getDocumentProperties().setTitle("Updated Product Roadmap");
    presentation.getDocumentProperties().setKeywords("roadmap, planning, indexed");
    presentation.save(outputPath, SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(outputPath);
System.out.println("The presentation is encrypted: " + presentationInfo.isEncrypted());

LoadOptions metadataLoadOptions = new LoadOptions();
metadataLoadOptions.setOnlyLoadDocumentProperties(true);

Presentation metadataPresentation = new Presentation(outputPath, metadataLoadOptions);
try {
    if (metadataPresentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        System.out.println("Title: " + metadataPresentation.getDocumentProperties().getTitle());
        System.out.println("Keywords: " + metadataPresentation.getDocumentProperties().getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    metadataPresentation.dispose();
}
```

Si una aplicación no tiene permiso para descifrar o cargar el contenido de la presentación, debe tratar las propiedades públicas de un archivo PPTX cifrado como de solo lectura.

## **Acceder a propiedades integradas**

Estas propiedades expuestas por el objeto [IDocumentProperties](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/idocumentproperties) incluyen: **Creator** (Autor), **Description**, **Keywords**, **Created** (Fecha de creación), **Modified** (Fecha de modificación), **Printed** (Fecha del último impresión), **LastModifiedBy**, **Keywords**, **SharedDoc** (¿Compartido entre diferentes productores?), **PresentationFormat**, **Subject** y **Title**

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

Modificar las propiedades integradas de los archivos de presentación es tan fácil como acceder a ellas. Simplemente puede asignar un valor de cadena a cualquier propiedad deseada y el valor de la propiedad se modificará. En el ejemplo que se muestra a continuación, hemos demostrado cómo podemos modificar las propiedades integradas del documento de la presentación usando Aspose.Slides para Android mediante Java.

```java
import com.aspose.slides.*;

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

|**Propiedades del documento integradas después de la modificación**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Agregar propiedades de documento personalizadas**

Aspose.Slides para Android mediante Java también permite a los desarrolladores añadir valores personalizados a las propiedades de documento de la presentación. El ejemplo siguiente añade tres propiedades personalizadas, luego busca el nombre almacenado en el índice 2 y elimina esa propiedad, de modo que la presentación guardada conserva dos de ellas. Las propiedades personalizadas se indexan en orden alfabético, no en el orden en que se añadieron.

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

Aspose.Slides para Android mediante Java también permite a los desarrolladores acceder a los valores de las propiedades personalizadas. A continuación se muestra un ejemplo que indica cómo puede acceder y modificar todas estas propiedades personalizadas de una presentación.

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

Este ejemplo modifica las propiedades personalizadas de la presentación [PPTX ](https://docs.fileformat.com/presentation/pptx/). Las siguientes figuras muestran las propiedades personalizadas de la presentación antes y después de la modificación:

|**Propiedades personalizadas antes de la modificación**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Propiedades personalizadas después de la modificación**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Propiedades avanzadas del documento**

{{% alert color="info" title="Nota" %}}
Se han añadido nuevos métodos [ReadDocumentProperties](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), y [WriteBindedPresentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) a [IPresentationInfo](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IPresentationInfo); la lógica del setter de la propiedad [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) ha sido modificada.
{{% /alert %}} 

La interfaz [IPresentationInfo](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IPresentationInfo) ha incorporado los dos nuevos métodos [ReadDocumentProperties](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--) y [UpdateDocumentProperties](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-). Proporcionan un acceso rápido a las propiedades del documento y permiten cambiar y actualizar las propiedades sin cargar una presentación completa.

El escenario típico de cargar las propiedades, cambiar algún valor y actualizar el documento puede implementarse de la siguiente manera:

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

Hay otra forma de usar las propiedades de una presentación concreta como plantilla para actualizar propiedades en otras presentaciones:

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

Se puede crear una nueva plantilla desde cero y luego usarla para actualizar múltiples presentaciones:

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

## **Establecer idioma de corrección**

Aspose.Slides proporciona la propiedad LanguageId (expuesta por la clase PortionFormat) para permitirle establecer el idioma de corrección de un documento PowerPoint. El idioma de corrección es el idioma en el que se revisan la ortografía y la gramática en PowerPoint.

Este código Java muestra cómo establecer el idioma de corrección para un PowerPoint:

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

    portionFormat.setLanguageId("zh-CN"); // establecer el Id de un idioma de corrección

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Establecer idioma predeterminado**

Este código Java muestra cómo establecer el idioma predeterminado para una presentación completa de PowerPoint:

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

Pruebe la aplicación en línea [**Aspose.Slides Metadata**](https://products.aspose.app/slides/es/metadata) para ver cómo trabajar con las propiedades del documento mediante la API de Aspose.Slides:

[![Ver y editar metadatos de PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/es/metadata)

## **Preguntas frecuentes**

**¿Cómo puedo eliminar una propiedad integrada de una presentación?**

Las propiedades integradas son una parte integral de la presentación y no pueden eliminarse por completo. Sin embargo, puede cambiar sus valores o establecerlas en vacío si la propiedad específica lo permite.

**¿Qué ocurre si añado una propiedad personalizada que ya existe?**

Si añade una propiedad personalizada que ya existe, su valor actual se sobrescribirá con el nuevo. No es necesario eliminar o comprobar la propiedad previamente, ya que Aspose.Slides actualiza automáticamente el valor de la propiedad.

**¿Puedo acceder a las propiedades de la presentación sin cargarla completamente?**

Sí. Utilice [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) y luego [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) para leer los metadatos del documento almacenados sin crear una instancia de [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/). Consulte [Build a Lightweight Presentation Inventory](/slides/es/androidjava/examine-presentation/) para un ejemplo completo de informe y limitaciones específicas de formato.

**¿Puedo leer las propiedades públicas de una presentación cifrada sin su contraseña de apertura?**

Sí. El cifrado de las propiedades del documento debe haber sido desactivado antes de que la presentación fuera cifrada, y la presentación debe cargarse en modo solo propiedades del documento.

**¿Puedo actualizar un archivo PPTX cifrado en modo solo propiedades del documento?**

No. Los datos de propiedades públicas y cifradas deben permanecer consistentes, por lo que actualizar un archivo PPTX cifrado requiere cargar la presentación completa con la contraseña de apertura correcta.