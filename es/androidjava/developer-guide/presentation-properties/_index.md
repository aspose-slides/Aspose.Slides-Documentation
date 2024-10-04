---
title: Propiedades de Presentación
type: docs
weight: 70
url: /androidjava/presentation-properties/
---

{{% alert color="primary" %}} 

Microsoft PowerPoint proporciona una función para agregar algunas propiedades a los archivos de presentación. Estas propiedades del documento permiten almacenar información útil junto con los documentos (archivos de presentación). Hay dos tipos de propiedades del documento como se sigue

- Propiedades Definidas por el Sistema (Integradas)
- Propiedades Definidas por el Usuario (Personalizadas)

Las propiedades **Integradas** contienen información general sobre el documento como el título del documento, el nombre del autor, las estadísticas del documento, etc. Las propiedades **Personalizadas** son aquellas que son definidas por los usuarios como pares **Nombre/Valor**, donde tanto el nombre como el valor son definidos por el usuario. Usando Aspose.Slides para Android a través de Java, los desarrolladores pueden acceder y modificar los valores de las propiedades integradas así como de las propiedades personalizadas.

{{% /alert %}} 

## **Propiedades del Documento en PowerPoint**
Microsoft PowerPoint 2007 permite gestionar las propiedades del documento de los archivos de presentación. Todo lo que tienes que hacer es hacer clic en el ícono de Office y luego en el elemento del menú **Preparar | Propiedades | Propiedades Avanzadas** de Microsoft PowerPoint 2007 como se muestra a continuación:

{{% alert color="primary" %}} 

Ten en cuenta que no puedes establecer valores en los campos **Aplicación** y **Productor**, porque Aspose Ltd. y Aspose.Slides para Android a través de Java x.x.x serán mostrados en estos campos.

{{% /alert %}} 

|**Seleccionando el elemento del menú Propiedades Avanzadas**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
Después de seleccionar el elemento del menú **Propiedades Avanzadas**, aparecerá un diálogo que te permitirá gestionar las propiedades del documento del archivo de PowerPoint como se muestra a continuación en la figura:

|**Diálogo de Propiedades**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
En el anterior **Diálogo de Propiedades**, puedes ver que hay muchas pestañas como **General**, **Resumen**, **Estadísticas**, **Contenido** y **Personalizadas**. Todas estas pestañas permiten configurar diferentes tipos de información relacionada con los archivos de PowerPoint. La pestaña **Personalizadas** se usa para gestionar las propiedades personalizadas de los archivos de PowerPoint.


Trabajando con Propiedades del Documento Usando Aspose.Slides para Android a través de Java

Como hemos descrito anteriormente, Aspose.Slides para Android a través de Java soporta dos tipos de propiedades del documento, que son propiedades **Integradas** y **Personalizadas**. Así que, los desarrolladores pueden acceder a ambos tipos de propiedades con el uso de la API de Aspose.Slides para Android a través de Java. Aspose.Slides para Android a través de Java proporciona una clase [IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties) que representa las propiedades del documento asociadas con un archivo de presentación a través de la propiedad **Presentation.DocumentProperties**.

Los desarrolladores pueden utilizar la propiedad **IDocumentProperties** expuesta por el objeto [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) para acceder a las propiedades del documento de los archivos de presentación como se describe a continuación:

## **Acceder a las Propiedades Integradas**
Estas propiedades expuestas por el objeto [IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties) incluyen: **Creador** (Autor), **Descripción**, **Palabras clave**, **Creado** (Fecha de Creación), **Modificado** (Fecha de Modificación), **Impreso** (Fecha de Última Impresión), **Último Modificado Por**, **Palabras clave**, **Documento Compartido** (¿Está compartido entre diferentes productores?), **Formato de Presentación**, **Asunto** y **Título**

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
    System.out.println("Fecha de Última Impresión : " + dp.getLastPrinted());
    System.out.println("Está Compartido entre productores : " + dp.getSharedDoc());
    System.out.println("Asunto : " + dp.getSubject());
    System.out.println("Título : " + dp.getTitle());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Modificar Propiedades Integradas**
Modificar las propiedades integradas de los archivos de presentación es tan fácil como acceder a ellas. Simplemente puedes asignar un valor de cadena a cualquier propiedad deseada y el valor de la propiedad será modificado. En el ejemplo dado a continuación, hemos demostrado cómo podemos modificar las propiedades del documento integradas del archivo de presentación usando Aspose.Slides para Android a través de Java.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Crear una referencia al objeto IDocumentProperties asociado con la Presentación
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Establecer las propiedades integradas
    dp.setAuthor("Aspose.Slides para Android a través de Java");
    dp.setTitle("Modificar Propiedades de Presentación");
    dp.setSubject("Asunto de Aspose");
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
Aspose.Slides para Android a través de Java también permite a los desarrolladores agregar los valores personalizados para las propiedades del documento de presentación. A continuación se da un ejemplo que muestra cómo establecer las propiedades personalizadas para una presentación.

```java
Presentation pres = new Presentation();
try {
    // Obtener Propiedades del Documento
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // Agregar propiedades Personalizadas
    dProps.set_Item("Nueva Personalizada", 12);
    dProps.set_Item("Mi Nombre", "Mudassir");
    dProps.set_Item("Personalizada", 124);
    
    // Obtener el nombre de la propiedad en un índice particular
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // Eliminar la propiedad seleccionada
    dProps.removeCustomProperty(getPropertyName);
    
    // Guardando la presentación
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**Propiedades de Documento Personalizadas Agregadas**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Acceder y Modificar Propiedades Personalizadas**
Aspose.Slides para Android a través de Java también permite a los desarrolladores acceder a los valores de las propiedades personalizadas. A continuación se da un ejemplo que muestra cómo puedes acceder y modificar todas estas propiedades personalizadas para una presentación.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Crear una referencia al objeto DocumentProperties asociado con la Presentación
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Acceder y modificar propiedades personalizadas
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Mostrar nombres y valores de las propiedades personalizadas
        System.out.println("Nombre de Propiedad Personalizada : " + dp.getCustomPropertyName(i));
        System.out.println("Valor de Propiedad Personalizada : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // Modificar valores de las propiedades personalizadas
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

Se han añadido nuevos métodos [ReadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) y [WriteBindedPresentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) a [IPresentationInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo), la lógica del setter de la propiedad [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) ha cambiado.

{{% /alert %}} 

Los dos nuevos métodos [ReadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--) y [UpdateDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) se han añadido a la interfaz [IPresentationInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo). Proporcionan acceso rápido a las propiedades del documento y permiten cambiar y actualizar propiedades sin cargar una presentación completa.

El escenario típico de cargar las propiedades, cambiar algún valor y actualizar el documento se puede implementar de la siguiente manera:

```java
// leer la información de la presentación
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// obtener las propiedades actuales
IDocumentProperties props = info.readDocumentProperties();

// establecer los nuevos valores de los campos Autor y Título
props.setAuthor("Nuevo Autor");
props.setTitle("Nuevo Título");

// actualizar la presentación con nuevos valores
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Hay otra forma de usar las propiedades de una presentación particular como plantilla para actualizar propiedades en otras presentaciones:

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("template.pptx");
DocumentProperties template = (DocumentProperties) info.readDocumentProperties();

template.setAuthor("Autor de Plantilla");
template.setTitle("Título de Plantilla");
template.setCategory("Categoría de Plantilla");
template.setKeywords("PalabraClave1, PalabraClave2, PalabraClave3");
template.setCompany("Nuestra Empresa");
template.setComments("Creado a partir de una plantilla");
template.setContentType("Contenido de Plantilla");
template.setSubject("Asunto de Plantilla");

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

Se puede crear una nueva plantilla desde cero y luego utilizarse para actualizar múltiples presentaciones:

```java
DocumentProperties template = new DocumentProperties();\

template.setAuthor("Autor de Plantilla");
template.setTitle("Título de Plantilla");
template.setCategory("Categoría de Plantilla");
template.setKeywords("PalabraClave1, PalabraClave2, PalabraClave3");
template.setCompany("Nuestra Empresa");
template.setComments("Creado a partir de una plantilla");
template.setContentType("Contenido de Plantilla");
template.setSubject("Asunto de Plantilla");

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

## **Verificar si la Presentación está Modificada o Creada**
Aspose.Slides para Android a través de Java proporciona la facilidad de verificar si una presentación está modificada o creada. A continuación se da un ejemplo que muestra cómo verificar si la presentación fue creada o modificada.

```java
IPresentationInfo info=PresentationFactory.getInstance().getPresentationInfo("props.pptx");

IDocumentProperties props = info.readDocumentProperties();
String app = props.getNameOfApplication();
String ver = props.getAppVersion();

System.out.println("Nombre de la Aplicación: " + app);
System.out.println("Versión de la Aplicación: " + ver);
```

## **Establecer Idioma de Corrección**

Aspose.Slides proporciona la propiedad LanguageId (expuesta por la clase PortionFormat) para permitirte establecer el idioma de corrección para un documento de PowerPoint. El idioma de corrección es el idioma para el cual se verifican las ortografías y la gramática en el PowerPoint.

Este código Java te muestra cómo establecer el idioma de corrección para un PowerPoint: xxx ¿Por qué falta LanguageId en la clase Java PortionFormat?

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

## **Establecer Idioma Predeterminado**

Este código Java te muestra cómo establecer el idioma predeterminado para toda la presentación de PowerPoint:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // Agrega una nueva forma rectangular con texto
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("Nuevo Texto");

    // Verifica el idioma de la primera porción
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```