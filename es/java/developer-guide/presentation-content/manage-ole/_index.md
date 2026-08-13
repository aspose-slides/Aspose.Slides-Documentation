---
title: Gestionar OLE en presentaciones usando Java
linktitle: Gestionar OLE
type: docs
weight: 40
url: /es/java/manage-ole/
keywords:
- objeto OLE
- Vinculación e incorporación de objetos
- añadir OLE
- incrustar OLE
- añadir objeto
- incrustar objeto
- añadir archivo
- incrustar archivo
- objeto vinculado
- archivo vinculado
- cambiar OLE
- icono OLE
- título OLE
- extraer OLE
- extraer objeto
- extraer archivo
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Optimice la gestión de objetos OLE en archivos PowerPoint y OpenDocument con Aspose.Slides para Java. Incruste, actualice y exporte contenido OLE sin problemas."
---
## **Introducción**

{{% alert color="info" %}} 

OLE (Object Linking & Embedding) es una tecnología de Microsoft que permite que datos y objetos creados en una aplicación se coloquen en otra aplicación mediante vinculación o incrustación. 

{{% /alert %}} 

Considere un gráfico creado en MS Excel. El gráfico se inserta dentro de una diapositiva de PowerPoint. Ese gráfico de Excel se considera un objeto OLE. 

- Un objeto OLE puede aparecer como un icono. En este caso, al hacer doble clic en el icono, el gráfico se abre en su aplicación asociada (Excel), o se le solicita al usuario que seleccione una aplicación para abrir o editar el objeto. 
- Un objeto OLE puede mostrar su contenido real, como el contenido de un gráfico. En este caso, el gráfico se activa en PowerPoint, se carga la interfaz del gráfico y puede modificar los datos del gráfico dentro de PowerPoint.

[Aspose.Slides for Java](https://products.aspose.com/slides/es/java/) permite insertar objetos OLE en diapositivas como marcos de objetos OLE ([OleObjectFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/OleObjectFrame)).

## **Agregar marcos de objetos OLE a diapositivas**

Suponiendo que ya haya creado un gráfico en Microsoft Excel y quiera incrustarlo en una diapositiva como un marco de objeto OLE usando Aspose.Slides for Java, puede hacerlo de la siguiente manera:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/Presentation).  
1. Obtener una referencia a la diapositiva mediante su índice.  
1. Leer el archivo Excel como una matriz de bytes.  
1. Añadir el [OleObjectFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/OleObjectFrame) a la diapositiva proporcionando la matriz de bytes y otra información sobre el objeto OLE.  
1. Guardar la presentación modificada como un archivo PPTX.  

En el ejemplo siguiente, añadimos un gráfico de un archivo Excel a una diapositiva como un marco de objeto OLE usando Aspose.Slides for Java.  
**Nota** que el constructor de [OleEmbeddedDataInfo](https://reference.aspose.com/slides/es/java/com.aspose.slides/OleEmbeddedDataInfo) recibe como segundo parámetro la extensión del objeto incrustable. Esta extensión permite a PowerPoint interpretar correctamente el tipo de archivo y elegir la aplicación adecuada para abrir este objeto OLE.

``` java 
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// Prepare data for the OLE object.
byte[] fileData = Files.readAllBytes(Paths.get("book.xlsx"));
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Add the OLE object frame to the slide.
slide.getShapes().addOleObjectFrame(0, 0, (float)slideSize.getWidth(), (float)slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **Agregar marcos de objetos OLE vinculados**

Aspose.Slides for Java permite añadir un [OleObjectFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/OleObjectFrame) sin incrustar datos, sino solo con un vínculo al archivo.

Este código Java muestra cómo añadir un [OleObjectFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/OleObjectFrame) con un archivo Excel vinculado a una diapositiva:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Añadir un marco de objeto OLE con un archivo Excel vinculado.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Acceder a marcos de objetos OLE**

Si un objeto OLE ya está incrustado en una diapositiva, puede encontrarlo o acceder a él fácilmente de esta forma:

1. Cargar una presentación con el objeto OLE incrustado creando una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/Presentation).  
2. Obtener la referencia de la diapositiva mediante su índice.  
3. Acceder a la forma [OleObjectFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/OleObjectFrame).  
   En nuestro ejemplo, utilizamos el PPTX creado previamente que tiene solo una forma en la primera diapositiva. Luego *convertimos* ese objeto a un [IOleObjectFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/IOleObjectFrame). Ese era el marco de objeto OLE que queríamos acceder.  
4. Una vez accedido al marco de objeto OLE, puede ejecutar cualquier operación sobre él.  

En el ejemplo siguiente, se accede a un marco de objeto OLE (un objeto de gráfico de Excel incrustado en una diapositiva) y a los datos del archivo.

``` java 
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;
    
    // Obtener los datos del archivo incrustado.
    byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // Obtener la extensión del archivo incrustado.
    String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```

### **Acceder a las propiedades del marco de objeto OLE vinculado**

Aspose.Slides permite acceder a las propiedades de los marcos de objetos OLE vinculados.

Este código Java muestra cómo comprobar si un objeto OLE está vinculado y, a continuación, obtener la ruta al archivo vinculado:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // Comprobar si el objeto OLE está vinculado.
    if (oleFrame.isObjectLink()) {
        // Imprimir la ruta completa al archivo vinculado.
        System.out.println("OLE object frame is linked to: " + oleFrame.getLinkPathLong());

        // Imprimir la ruta relativa al archivo vinculado si está presente.
        // Sólo las presentaciones PPT pueden contener la ruta relativa.
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **Cambiar los datos de un objeto OLE**

{{% alert color="info" %}} 

En esta sección, el ejemplo de código a continuación utiliza [Aspose.Cells for Java](/cells/java/). 

{{% /alert %}}

Si un objeto OLE ya está incrustado en una diapositiva, puede acceder a ese objeto y modificar sus datos de la siguiente manera:

1. Cargar una presentación con el objeto OLE incrustado creando una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/Presentation).  
2. Obtener la referencia de la diapositiva mediante su índice.  
3. Acceder a la forma del marco de objeto OLE.  
   En nuestro ejemplo, utilizamos el PPTX creado previamente que tiene una forma en la primera diapositiva. Luego *convertimos* ese objeto a un [IOleObjectFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/IOleObjectFrame). Ese era el marco de objeto OLE que queríamos acceder.  
4. Una vez accedido al marco de objeto OLE, puede ejecutar cualquier operación sobre él.  
5. Crear un objeto `Workbook` y acceder a los datos OLE.  
6. Acceder a la `Worksheet` deseada y modificar los datos.  
7. Guardar el `Workbook` actualizado en un flujo.  
8. Cambiar los datos del objeto OLE a partir del flujo.  

En el ejemplo siguiente, se accede a un marco de objeto OLE (un objeto de gráfico de Excel incrustado en una diapositiva) y se modifican sus datos de archivo para actualizar los datos del gráfico.

```java
import com.aspose.slides.*;
import com.aspose.cells.Workbook;
import com.aspose.cells.OoxmlSaveOptions;
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    ByteArrayInputStream oleStream = new ByteArrayInputStream(oleFrame.getEmbeddedData().getEmbeddedFileData());

    // Leer los datos del objeto OLE como un objeto Workbook.
    Workbook workbook = new Workbook(oleStream);

    ByteArrayOutputStream newOleStream = new ByteArrayOutputStream();

    // Modificar los datos del libro de trabajo.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(com.aspose.cells.SaveFormat.XLSX);
    workbook.save(newOleStream, fileOptions);

    // Cambiar los datos del objeto del marco OLE.
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Incrustar otros tipos de archivo en diapositivas**

Además de gráficos de Excel, Aspose.Slides for Java permite incrustar otros tipos de archivo en diapositivas. Por ejemplo, puede insertar archivos HTML, PDF y ZIP como objetos. Cuando el usuario hace doble clic en el objeto insertado, se abre automáticamente en el programa correspondiente, o se le solicita que elija un programa adecuado para abrirlo.

Este código Java muestra cómo incrustar HTML y ZIP en una diapositiva:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

byte[] htmlData = Files.readAllBytes(Paths.get("sample.html"));
IOleEmbeddedDataInfo htmlDataInfo = new OleEmbeddedDataInfo(htmlData, "html");
IOleObjectFrame htmlOleFrame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame.setObjectIcon(true);

byte[] zipData = Files.readAllBytes(Paths.get("sample.zip"));
IOleEmbeddedDataInfo zipDataInfo = new OleEmbeddedDataInfo(zipData, "zip");
IOleObjectFrame zipOleFrame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Definir tipos de archivo para objetos incrustados**

Al trabajar con presentaciones, puede necesitar sustituir objetos OLE antiguos por nuevos o reemplazar un objeto OLE no compatible por uno compatible. Aspose.Slides for Java permite definir el tipo de archivo para un objeto incrustado, lo que le permite actualizar los datos del marco OLE o su extensión.

Este código Java muestra cómo establecer el tipo de archivo para un objeto OLE incrustado a `zip`:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

System.out.println("Current embedded file extension is: " + fileExtension);

// Change the file type to ZIP.
oleFrame.setEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Establecer imágenes de icono y títulos para objetos incrustados**

Después de incrustar un objeto OLE, se añade automáticamente una vista previa que consiste en una imagen de icono. Esta vista previa es lo que ven los usuarios antes de acceder o abrir el objeto OLE. Si desea usar una imagen y un texto específicos como elementos de la vista previa, puede establecer la imagen de icono y el título con Aspose.Slides for Java.

Este código Java muestra cómo establecer la imagen de icono y el título para un objeto incrustado:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// Añadir una imagen a los recursos de la presentación.
byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
IPPImage oleImage = presentation.getImages().addImage(imageData);

// Establecer un título y la imagen para la vista previa del OLE.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Evitar que un marco de objeto OLE cambie de tamaño y posición**

Después de añadir un objeto OLE vinculado a una diapositiva de presentación, al abrir la presentación en PowerPoint puede aparecer un mensaje que le pide actualizar los vínculos. Al pulsar el botón «Update Links» (Actualizar vínculos) es posible que cambie el tamaño y la posición del marco del objeto OLE porque PowerPoint actualiza los datos del objeto vinculado y refresca la vista previa. Para evitar que PowerPoint solicite actualizar los datos del objeto, establezca el método `setUpdateAutomatic` de la interfaz [IOleObjectFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/ioleobjectframe/) a `false`:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

oleFrame.setUpdateAutomatic(false);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Extraer archivos incrustados**

Aspose.Slides for Java permite extraer los archivos incrustados en diapositivas como objetos OLE de la siguiente forma:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/Presentation) que contenga los objetos OLE que desea extraer.  
2. Recorrer todas las formas de la presentación y acceder a las formas [OLEObjectFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/oleobjectframe).  
3. Acceder a los datos de los archivos incrustados desde los marcos OLE y escribirlos en disco.  

Este código Java muestra cómo extraer archivos incrustados en una diapositiva como objetos OLE:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);

for (int index = 0; index < slide.getShapes().size(); index++) {
    IShape shape = slide.getShapes().get_Item(index);

    if (shape instanceof IOleObjectFrame) {
        IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

        byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();
        String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

        Path filePath = Paths.get("OLE_object_" + index + fileExtension);
        Files.write(filePath, fileData);
    }
}

presentation.dispose();
```

## **FAQ**

### ¿Se renderizará el contenido OLE al exportar diapositivas a PDF/imagenes?

Se renderiza lo que es visible en la diapositiva: el icono/imagen de sustitución (vista previa). El contenido OLE «en vivo» no se ejecuta durante el renderizado. Si es necesario, establezca su propia imagen de vista previa para garantizar la apariencia esperada en el PDF exportado.

### ¿Cómo puedo bloquear un objeto OLE en una diapositiva para que los usuarios no puedan moverlo/editarlo en PowerPoint?

Bloquee la forma: Aspose.Slides proporciona [bloqueos a nivel de forma](/slides/es/java/applying-protection-to-presentation/). No se trata de cifrado, pero evita eficazmente ediciones y movimientos accidentales.

### ¿Por qué un objeto Excel vinculado «salta» o cambia de tamaño al abrir la presentación?

PowerPoint puede refrescar la vista previa del OLE vinculado. Para obtener una apariencia estable, siga las prácticas de la [Solución funcional para el cambio de tamaño de hojas de cálculo](/slides/es/java/working-solution-for-worksheet-resizing/): ajuste el marco al rango o escale el rango a un marco fijo y establezca una imagen de sustitución adecuada.

### ¿Se conservarán las rutas relativas de los objetos OLE vinculados en el formato PPTX?

En PPTX no existe información de «ruta relativa», solo la ruta completa. Las rutas relativas aparecen en el antiguo formato PPT. Para portabilidad, utilice rutas absolutas fiables/URIs accesibles o incruste los archivos.