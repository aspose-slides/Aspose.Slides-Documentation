---
title: Propiedades de la Presentación
type: docs
weight: 70
url: /es/java/presentation-properties/
---

{{% alert color="primary" %}} 

Microsoft PowerPoint proporciona una característica para agregar algunas propiedades a los archivos de presentación. Estas propiedades del documento permiten almacenar información útil junto con los documentos (archivos de presentación). Hay dos tipos de propiedades del documento como sigue:

- Propiedades Definidas por el Sistema (Integradas)
- Propiedades Definidas por el Usuario (Personalizadas)

**Integradas** contienen información general sobre el documento, como el título del documento, el nombre del autor, las estadísticas del documento, etc. Las propiedades **Personalizadas** son aquellas que son definidas por los usuarios como pares **Nombre/Valor**, donde tanto el nombre como el valor son definidos por el usuario. Usando Aspose.Slides para Java, los desarrolladores pueden acceder y modificar los valores de las propiedades integradas así como las propiedades personalizadas.

{{% /alert %}} 

## **Propiedades del Documento en PowerPoint**
Microsoft PowerPoint 2007 permite gestionar las propiedades del documento de los archivos de presentación. Todo lo que tienes que hacer es hacer clic en el ícono de Office y luego en el elemento de menú **Preparar | Propiedades | Propiedades Avanzadas** de Microsoft PowerPoint 2007 como se muestra a continuación:

{{% alert color="primary" %}} 

Por favor, ten en cuenta que no puedes establecer valores para los campos **Aplicación** y **Productor**, porque Aspose Ltd. y Aspose.Slides para Java x.x.x se mostrarán en estos campos.

{{% /alert %}} 

|**Seleccionando el elemento del menú Propiedades Avanzadas**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
Después de seleccionar el elemento del menú **Propiedades Avanzadas**, aparecerá un cuadro de diálogo que te permitirá gestionar las propiedades del documento del archivo de PowerPoint como se muestra a continuación en la figura:

|**Diálogo de Propiedades**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
En el **Diálogo de Propiedades** anterior, puedes ver que hay muchas pestañas como **General**, **Resumen**, **Estadísticas**, **Contenido** y **Personalizado**. Todas estas pestañas permiten configurar diferentes tipos de información relacionada con los archivos de PowerPoint. La pestaña **Personalizada** se utiliza para gestionar las propiedades personalizadas de los archivos de PowerPoint.

## Trabajando con Propiedades del Documento Usando Aspose.Slides para Java

Como hemos descrito anteriormente, Aspose.Slides para Java soporta dos tipos de propiedades del documento, que son las propiedades **Integradas** y **Personalizadas**. Así que, los desarrolladores pueden acceder a ambos tipos de propiedades con el uso de la API de Aspose.Slides para Java. Aspose.Slides para Java proporciona una clase [IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties) que representa las propiedades del documento asociadas con un archivo de presentación a través de la propiedad **Presentation.DocumentProperties**.

Los desarrolladores pueden usar la propiedad **IDocumentProperties** expuesta por el objeto [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) para acceder a las propiedades del documento de los archivos de presentación como se describe a continuación:

## **Acceder a las Propiedades Integradas**
Estas propiedades expuestas por el objeto [IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties) incluyen: **Creador** (Autor), **Descripción**, **Palabras Clave**, **Creado** (Fecha de Creación), **Modificado** (Fecha de Modificación), **Impreso** (Última Fecha de Impresión), **ÚltimoModificadoPor**, **Palabras Clave**, **DocCompartido** (¿Está compartido entre diferentes productores?), **Formato de Presentación**, **Tema** y **Título**.

```java
// Instanciar la clase Presentation que representa la presentación
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Crear una referencia al objeto IDocumentProperties asociado con la Presentación
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Mostrar las propiedades integradas
    System.out.println("Categoría : " + dp.getCategory());
    System.out.println("Estado Actual : " + dp.getContentStatus());
    System.out.println("Fecha de Creación : " + dp.getCreatedTime());
    System.out.println("Autor : " + dp.getAuthor());
    System.out.println("Descripción : " + dp.getComments());
    System.out.println("Palabras Clave : " + dp.getKeywords());
    System.out.println("Último Modificado Por : " + dp.getLastSavedBy());
    System.out.println("Supervisor : " + dp.getManager());
    System.out.println("Fecha de Modificación : " + dp.getLastSavedTime());
    System.out.println("Formato de Presentación : " + dp.getPresentationFormat());
    System.out.println("Última Fecha de Impresión : " + dp.getLastPrinted());
    System.out.println("¿Está Compartido entre productores : " + dp.getSharedDoc());
    System.out.println("Tema : " + dp.getSubject());
    System.out.println("Título : " + dp.getTitle());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Modificar Propiedades Integradas**
Modificar las propiedades integradas de los archivos de presentación es tan fácil como acceder a ellas. Simplemente puedes asignar un valor de cadena a cualquier propiedad deseada y el valor de la propiedad se modificará. En el ejemplo que se da a continuación, hemos demostrado cómo podemos modificar las propiedades del documento integradas del archivo de presentación usando Aspose.Slides para Java.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Crear una referencia al objeto IDocumentProperties asociado con la Presentación
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Establecer las propiedades integradas
    dp.setAuthor("Aspose.Slides para Java");
    dp.setTitle("Modificando Propiedades de Presentación");
    dp.setSubject("Tema de Aspose");
    dp.setComments("Descripción de Aspose");
    dp.setManager("Gerente de Aspose");
    
    // Guardar tu presentación en un archivo
    pres.save("DocProps.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Este ejemplo modifica las propiedades integradas de la presentación que se pueden ver como se muestra a continuación:

|**Propiedades del documento integradas después de la modificación**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Agregar Propiedades de Documento Personalizadas**
Aspose.Slides para Java también permite a los desarrolladores agregar valores personalizados para las propiedades del Documento de presentación. A continuación se presenta un ejemplo que muestra cómo establecer las propiedades personalizadas para una presentación.

```java
Presentation pres = new Presentation();
try {
    // Obtener las Propiedades del Documento
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // Agregar propiedades personalizadas
    dProps.set_Item("Nueva Personalizada", 12);
    dProps.set_Item("Mi Nombre", "Mudassir");
    dProps.set_Item("Personalizada", 124);
    
    // Obtener el nombre de la propiedad en un índice particular
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // Eliminar propiedad seleccionada
    dProps.removeCustomProperty(getPropertyName);
    
    // Guardar presentación
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**Propiedades de Documento Personalizadas Agregadas**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Acceder y Modificar Propiedades Personalizadas**
Aspose.Slides para Java también permite a los desarrolladores acceder a los valores de las propiedades personalizadas. A continuación se presenta un ejemplo que muestra cómo puedes acceder y modificar todas estas propiedades personalizadas para una presentación.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Crear una referencia al objeto DocumentProperties asociado con la Presentación
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Acceder y modificar propiedades personalizadas
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Mostrar nombres y valores de propiedades personalizadas
        System.out.println("Nombre de Propiedad Personalizada : " + dp.getCustomPropertyName(i));
        System.out.println("Valor de Propiedad Personalizada : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // Modificar valores de propiedades personalizadas
        dp.set_Item(dp.getCustomPropertyName(i), "Nuevo Valor " + (i + 1));
    }
    
    // Guardar tu presentación en un archivo
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Este ejemplo modifica las propiedades personalizadas de la presentación [PPTX ](https://docs.fileformat.com/presentation/pptx/). Las siguientes figuras muestran las propiedades personalizadas de la presentación antes y después de la modificación:

|**Propiedades Personalizadas antes de la Modificación**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |


|**Propiedades Personalizadas después de la Modificación**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Propiedades Avanzadas del Documento**
{{% alert color="primary" %}} 

Se han agregado nuevos métodos [ReadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) y [WriteBindedPresentation](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) a la interfaz [IPresentationInfo](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo), la lógica del setter de la propiedad [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) ha sido cambiada.

{{% /alert %}} 

Los dos nuevos métodos [ReadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) y [UpdateDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) se han agregado a la interfaz [IPresentationInfo](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo). Estos proporcionan acceso rápido a las propiedades del documento y permiten cambiar y actualizar propiedades sin cargar toda la presentación.

El escenario típico de cargar las propiedades, cambiar algún valor y actualizar el documento se puede implementar de la siguiente manera:

```java
// leer la información de la presentación
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// obtener las propiedades actuales
IDocumentProperties props = info.readDocumentProperties();

// establecer los nuevos valores de los campos Autor y Título
props.setAuthor("Nuevo Autor");
props.setTitle("Nuevo Título");

// actualizar la presentación con los nuevos valores
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Hay otra forma de usar las propiedades de una presentación particular como plantilla para actualizar las propiedades en otras presentaciones:

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("template.pptx");
DocumentProperties template = (DocumentProperties) info.readDocumentProperties();

template.setAuthor("Autor de la Plantilla");
template.setTitle("Título de la Plantilla");
template.setCategory("Categoría de la Plantilla");
template.setKeywords("PalabraClave1, PalabraClave2, PalabraClave3");
template.setCompany("Nuestra Empresa");
template.setComments("Creado a partir de la plantilla");
template.setContentType("Contenido de la Plantilla");
template.setSubject("Tema de la Plantilla");

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

template.setAuthor("Autor de la Plantilla");
template.setTitle("Título de la Plantilla");
template.setCategory("Categoría de la Plantilla");
template.setKeywords("PalabraClave1, PalabraClave2, PalabraClave3");
template.setCompany("Nuestra Empresa");
template.setComments("Creado a partir de la plantilla");
template.setContentType("Contenido de la Plantilla");
template.setSubject("Tema de la Plantilla");

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

## **Comprobar si la Presentación ha sido Modificada o Creada**
Aspose.Slides para Java proporciona la facilidad de verificar si una presentación ha sido modificada o creada. A continuación se presenta un ejemplo que muestra cómo comprobar si la presentación ha sido creada o modificada.

```java
IPresentationInfo info=PresentationFactory.getInstance().getPresentationInfo("props.pptx");

IDocumentProperties props = info.readDocumentProperties();
String app = props.getNameOfApplication();
String ver = props.getAppVersion();

System.out.println("Nombre de la Aplicación: " + app);
System.out.println("Versión de la Aplicación: " + ver);
```

## **Establecer el Idioma de Corrección**

Aspose.Slides proporciona la propiedad LanguageId (expuesta por la clase PortionFormat) para permitirte establecer el idioma de corrección para un documento de PowerPoint. El idioma de corrección es el idioma para el cual se verifican las ortografías y la gramática en PowerPoint.

Este código Java muestra cómo establecer el idioma de corrección para un PowerPoint: xxx ¿Por qué falta LanguageId en la clase PortionFormat de Java?

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

    portionFormat.setLanguageId("zh-CN"); // establecer el Id de un idioma de corrección

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Establecer el Idioma Predeterminado**

Este código Java muestra cómo establecer el idioma predeterminado para toda una presentación de PowerPoint:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // Agregar una nueva forma rectangular con texto
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("Nuevo Texto");

    // Verificar el idioma de la primera porción
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```