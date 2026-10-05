---
title: Gestionar OLE en presentaciones en Android
linktitle: Gestionar OLE
type: docs
weight: 40
url: /es/androidjava/manage-ole/
keywords:
- Objeto OLE
- Enlace y incrustación de objetos
- Agregar OLE
- Incrustar OLE
- Agregar objeto
- Incrustar objeto
- Agregar archivo
- Incrustar archivo
- Objeto vinculado
- Archivo vinculado
- Cambiar OLE
- Icono OLE
- Título OLE
- Extraer OLE
- Extraer objeto
- Extraer archivo
- PowerPoint
- presentación
- Android
- Java
- Aspose.Slides
description: "Optimice la gestión de objetos OLE en archivos PowerPoint y OpenDocument con Aspose.Slides for Android via Java. Incruste, actualice y exporte contenido OLE sin problemas."
---
## **Introducción**

{{% alert color="info" title="Nota" %}}

OLE (Object Linking & Embedding) es una tecnología de Microsoft que permite que datos y objetos creados en una aplicación se coloquen en otra aplicación mediante enlace o incrustación. 

{{% /alert %}} 

Considere un gráfico creado en MS Excel. El gráfico se coloca luego dentro de una diapositiva de PowerPoint. Ese gráfico de Excel se considera un objeto OLE. 

- Un objeto OLE puede aparecer como un icono. En este caso, al hacer doble clic en el icono, el gráfico se abre en su aplicación asociada (Excel), o se le solicita que seleccione una aplicación para abrir o editar el objeto.
- Un objeto OLE puede mostrar su contenido real, como el contenido de un gráfico. En este caso, el gráfico se activa en PowerPoint, se carga la interfaz del gráfico y puede modificar los datos del gráfico dentro de PowerPoint.

[Aspose.Slides for Android via Java](https://products.aspose.com/slides/androidjava/) permite insertar objetos OLE en diapositivas como marcos de objetos OLE ([OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame)).

## **Agregar marcos de objetos OLE a diapositivas**

Suponiendo que ya haya creado un gráfico en Microsoft Excel y desea incrustarlo en una diapositiva como un marco de objeto OLE usando Aspose.Slides for Android via Java, puede hacerlo de la siguiente manera:

1. Crear una instancia de la clase [Presentación](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Obtener la referencia de una diapositiva mediante su índice.
3. Leer el archivo Excel como una matriz de bytes.
4. Añadir el [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) a la diapositiva que contiene la matriz de bytes y otra información sobre el objeto OLE.
5. Guardar la presentación modificada como un archivo PPTX.

En el ejemplo a continuación, añadimos un gráfico de un archivo Excel a una diapositiva como un marco de objeto OLE usando Aspose.Slides for Android via Java.  
**Nota** que el constructor de [OleEmbeddedDataInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleEmbeddedDataInfo) recibe como segundo parámetro una extensión de objeto incrustable. Esta extensión permite a PowerPoint interpretar correctamente el tipo de archivo y elegir la aplicación adecuada para abrir este objeto OLE.

```java 
import com.aspose.slides.*;
import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// Prepare data for the OLE object.
File file = new File("book.xlsx");
byte fileData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(fileData);

IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Add the OLE object frame to the slide.
slide.getShapes().addOleObjectFrame(0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **Agregar marcos de objetos OLE vinculados**

Aspose.Slides for Android via Java permite agregar un [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) sin incrustar datos, sino sólo mediante un vínculo al archivo.

Este código Java muestra cómo agregar un [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) con un archivo Excel vinculado a una diapositiva:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Añadir un marco de objeto OLE con un archivo Excel vinculado.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Acceder a los marcos de objetos OLE**

Si un objeto OLE ya está incrustado en una diapositiva, puede encontrarlo o acceder a él de la siguiente forma:

1. Cargar una presentación con el objeto OLE incrustado creando una instancia de la clase [Presentación](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Obtener la referencia de la diapositiva usando su índice.
3. Acceder a la forma [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame).  
   En nuestro ejemplo, usamos el PPTX creado anteriormente que tiene una sola forma en la primera diapositiva. Luego *cast* ese objeto como un [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/). Este era el marco de objeto OLE deseado para ser accedido.
4. Una vez accedido al marco de objeto OLE, puede realizar cualquier operación sobre él.

En el ejemplo a continuación, se accede a un marco de objeto OLE (un objeto de gráfico Excel incrustado en una diapositiva) y a sus datos de archivo.

```java 
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

Este código Java muestra cómo comprobar si un objeto OLE está vinculado y luego obtener la ruta al archivo vinculado:

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

## **Cambiar los datos del objeto OLE**

{{% alert color="info" title="Nota" %}}

En esta sección, el ejemplo de código a continuación utiliza [Aspose.Cells for Android via Java](https://docs.aspose.com/cells/androidjava/).

{{% /alert %}}

Si un objeto OLE ya está incrustado en una diapositiva, puede acceder fácilmente a ese objeto y modificar sus datos de la siguiente manera:

1. Cargar una presentación con el objeto OLE incrustado creando una instancia de la clase [Presentación](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Obtener la referencia de la diapositiva mediante su índice. 
3. Acceder a la forma del marco de objeto OLE.  
   En nuestro ejemplo, usamos el PPTX creado anteriormente que tiene una forma en la primera diapositiva. Luego *cast* ese objeto como un [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/). Este era el marco de objeto OLE deseado para ser accedido.
4. Una vez accedido al marco de objeto OLE, puede realizar cualquier operación sobre él.
5. Crear un objeto `Workbook` y acceder a los datos OLE.
6. Acceder a la `Worksheet` deseada y modificar los datos.
7. Guardar el `Workbook` actualizado en un flujo.
8. Cambiar los datos del objeto OLE a partir del flujo.

En el ejemplo a continuación, se accede a un marco de objeto OLE (un objeto de gráfico Excel incrustado en una diapositiva) y se modifican sus datos de archivo para actualizar los datos del gráfico.

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

    // Modificar los datos del Workbook.
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

## **Incrustar otros tipos de archivos en diapositivas**

Además de los gráficos de Excel, Aspose.Slides for Android via Java permite incrustar otros tipos de archivos en diapositivas. Por ejemplo, puede insertar archivos HTML, PDF y ZIP como objetos. Cuando el usuario hace doble clic en el objeto insertado, se abre automáticamente en el programa correspondiente, o se le solicita que seleccione un programa apropiado para abrirlo.

Este código Java muestra cómo incrustar HTML y ZIP en una diapositiva:

```java
import com.aspose.slides.*;
import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

File fileHtml = new File("sample.html");
byte htmlData[] = new byte[(int) fileHtml.length()];
BufferedInputStream bisHtml = new BufferedInputStream(new FileInputStream(fileHtml));
DataInputStream disHtml = new DataInputStream(bisHtml);
disHtml.readFully(htmlData);
IOleEmbeddedDataInfo htmlDataInfo = new OleEmbeddedDataInfo(htmlData, "html");
IOleObjectFrame htmlOleFrame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame.setObjectIcon(true);

File fileZip = new File("sample.zip");
byte zipData[] = new byte[(int) fileZip.length()];
BufferedInputStream bisZip = new BufferedInputStream(new FileInputStream(fileZip));
DataInputStream disZip = new DataInputStream(bisZip);
disZip.readFully(zipData);
IOleEmbeddedDataInfo zipDataInfo = new OleEmbeddedDataInfo(zipData, "zip");
IOleObjectFrame zipOleFrame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Establecer tipos de archivo para objetos incrustados**

Al trabajar con presentaciones, puede necesitar reemplazar objetos OLE antiguos por nuevos o sustituir un objeto OLE no compatible por uno compatible. Aspose.Slides for Android via Java permite establecer el tipo de archivo para un objeto incrustado, lo que le permite actualizar los datos del marco OLE o su extensión.

Este código Java muestra cómo establecer el tipo de archivo para un objeto OLE incrustado a `zip`:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

System.out.println("Current embedded file extension is: " + fileExtension);

// Cambiar el tipo de archivo a ZIP.
oleFrame.setEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Establecer imágenes de icono y títulos para objetos incrustados**

Después de incrustar un objeto OLE, se añade automáticamente una vista previa que consiste en una imagen de icono. Esta vista previa es lo que los usuarios ven antes de acceder o abrir el objeto OLE. Si desea usar una imagen y un texto específicos como elementos en la vista previa, puede establecer la imagen del icono y el título mediante Aspose.Slides for Android via Java.

Este código Java muestra cómo establecer la imagen del icono y el título para un objeto incrustado:

```java
import com.aspose.slides.*;
import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// Añadir una imagen a los recursos de la presentación.
File file = new File("image.png");
byte imageData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(imageData);
IPPImage oleImage = presentation.getImages().addImage(imageData);

// Establecer un título y la imagen para la vista previa del OLE.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Evitar que un marco de objeto OLE sea redimensionado y reposicionado**

Después de agregar un objeto OLE vinculado a una diapositiva de presentación, al abrir la presentación en PowerPoint puede aparecer un mensaje que le pide actualizar los vínculos. Al hacer clic en el botón "Update Links" (Actualizar vínculos) el tamaño y la posición del marco del objeto OLE pueden cambiar porque PowerPoint actualiza los datos del objeto OLE vinculado y refresca la vista previa del objeto. Para evitar que PowerPoint solicite actualizar los datos del objeto, llame al método [setUpdateAutomatic](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#setUpdateAutomatic-boolean-) de la interfaz [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/) con `false`:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    oleFrame.setUpdateAutomatic(false);

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Extraer archivos incrustados**

Aspose.Slides for Android via Java permite extraer los archivos incrustados en diapositivas como objetos OLE de la siguiente manera:

1. Crear una instancia de la clase [Presentación](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) que contenga los objetos OLE que desea extraer.
2. Recorrer todas las formas de la presentación y acceder a las formas [OLEObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/oleobjectframe).
3. Acceder a los datos de los archivos incrustados en los marcos de objetos OLE y escribirlos en disco.

Este código Java muestra cómo extraer archivos incrustados en una diapositiva como objetos OLE:

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);

for (int index = 0; index < slide.getShapes().size(); index++) {
    IShape shape = slide.getShapes().get_Item(index);

    if (shape instanceof IOleObjectFrame) {
        IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

        byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();
        String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

        FileOutputStream fos = new FileOutputStream(new File("OLE_object_" + index + fileExtension));
        fos.write(fileData);
        fos.close();
    }
}

presentation.dispose();
```

## **Preguntas frecuentes**

**¿Se renderizará el contenido OLE al exportar diapositivas a PDF/imagenes?**

Lo que es visible en la diapositiva se renderiza: el icono/imagen sustituta (vista previa). El contenido OLE "en vivo" no se ejecuta durante el renderizado. Si es necesario, establezca su propia imagen de vista previa para garantizar la apariencia esperada en el PDF exportado.

Para preservar también el archivo incrustado como un adjunto PDF, llame a [setIncludeOleData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) con `true`. Esta opción está desactivada de forma predeterminada. Para un ejemplo e instrucciones sobre cómo comprobar el adjunto, consulte [Preserve Embedded OLE Files as PDF Attachments](/slides/es/androidjava/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**¿Cómo puedo bloquear un objeto OLE en una diapositiva para que los usuarios no puedan moverlo/editarlo en PowerPoint?**

Bloquee la forma: Aspose.Slides proporciona bloqueos a nivel de forma. No es cifrado, pero impide eficazmente ediciones y movimientos accidentales.

**¿Por qué un objeto Excel vinculado "salta" o cambia de tamaño al abrir la presentación?**

PowerPoint puede refrescar la vista previa del OLE vinculado. Para una apariencia estable, siga las prácticas de la [Working Solution for Worksheet Resizing](/slides/es/androidjava/working-solution-for-worksheet-resizing/): ajuste el marco al rango, o escale el rango a un marco fijo y establezca una imagen sustituta adecuada.

**¿Se conservarán las rutas relativas de los objetos OLE vinculados en el formato PPTX?**

En PPTX la información de "ruta relativa" no está disponible, solo la ruta completa. Las rutas relativas se encuentran en el formato PPT más antiguo. Para portabilidad, prefiera rutas absolutas fiables/URIs accesibles o la incrustación.