---
title: Gestionar OLE en presentaciones usando JavaScript
linktitle: Gestionar OLE
type: docs
weight: 40
url: /es/nodejs-java/manage-ole/
keywords:
- objeto OLE
- Enlace y incrustación de objetos
- agregar OLE
- incrustar OLE
- agregar objeto
- incrustar objeto
- agregar archivo
- incrustar archivo
- objeto enlazado
- archivo enlazado
- cambiar OLE
- icono OLE
- título OLE
- extraer OLE
- extraer objeto
- extraer archivo
- PowerPoint
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Optimice la gestión de objetos OLE en PowerPoint y archivos OpenDocument con Aspose.Slides para Node.js. Incruste, actualice y exporte contenido OLE sin problemas."
---

{{% alert color="primary" %}} 

OLE (Object Linking & Embedding) es una tecnología de Microsoft que permite que datos y objetos creados en una aplicación se coloquen en otra aplicación mediante enlace o incrustación. 

{{% /alert %}} 

Considere un gráfico creado en MS Excel. El gráfico se coloca dentro de una diapositiva de PowerPoint. Ese gráfico de Excel se considera un objeto OLE. 

- Un objeto OLE puede aparecer como un ícono. En este caso, al hacer doble clic en el ícono, el gráfico se abre en su aplicación asociada (Excel), o se le solicita seleccionar una aplicación para abrir o editar el objeto. 
- Un objeto OLE puede mostrar su contenido real, como el contenido de un gráfico. En este caso, el gráfico se activa en PowerPoint, se carga la interfaz del gráfico y puede modificar los datos del gráfico dentro de PowerPoint.

[Aspose.Slides for Node.js via Java](https://products.aspose.com/slides/nodejs-java/) permite insertar objetos OLE en diapositivas como marcos de objetos OLE ([OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame)).

## **Agregar marcos de objetos OLE a diapositivas**

Supongamos que ya ha creado un gráfico en Microsoft Excel y desea incrustarlo en una diapositiva como un marco de objeto OLE usando Aspose.Slides for Node.js via Java, puede hacerlo de la siguiente manera:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation). 
1. Obtener la referencia de una diapositiva mediante su índice. 
1. Leer el archivo Excel como una matriz de bytes. 
1. Agregar el [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) a la diapositiva que contiene la matriz de bytes y otra información sobre el objeto OLE. 
1. Escribir la presentación modificada como un archivo PPTX. 

En el ejemplo a continuación, agregamos un gráfico de un archivo Excel a una diapositiva como un marco de objeto OLE usando Aspose.Slides for Node.js via Java.  
**Nota** que el constructor [OleEmbeddedDataInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleEmbeddedDataInfo) recibe una extensión de objeto incrustable como segundo parámetro. Esta extensión permite a PowerPoint interpretar correctamente el tipo de archivo y elegir la aplicación adecuada para abrir este objeto OLE.  
```javascript
var presentation = new asposeSlides.Presentation();
var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(0);

// Prepare data for the OLE object.
var oleStream = fs.readFileSync("book.xlsx");
var fileData = Array.from(oleStream);
var dataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", fileData), "xlsx");

// Add the OLE object frame to the slide.
slide.getShapes().addOleObjectFrame(0, 0, slideSize.getWidth(), slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


### **Agregar marcos de objetos OLE enlazados**

Aspose.Slides for Node.js via Java permite agregar un [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) sin incrustar datos, solo con un enlace al archivo.  

Este código JavaScript muestra cómo agregar un [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) con un archivo Excel enlazado a una diapositiva:  
```javascript
var presentation = new asposeSlides.Presentation();
var slide = presentation.getSlides().get_Item(0);

// Add an OLE object frame with a linked Excel file.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **Acceder a marcos de objetos OLE**

Si un objeto OLE ya está incrustado en una diapositiva, puede encontrarlo o acceder a él fácilmente de esta manera:

1. Cargar una presentación con el objeto OLE incrustado creando una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation). 
2. Obtener la referencia de la diapositiva usando su índice. 
3. Acceder a la forma [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame). En nuestro ejemplo, usamos el PPTX creado anteriormente que tiene solo una forma en la primera diapositiva. 
4. Una vez accedido al marco del objeto OLE, puede realizar cualquier operación sobre él. 

En el ejemplo a continuación, se accede a un marco de objeto OLE (un objeto de gráfico de Excel incrustado en una diapositiva) y a sus datos de archivo.  
```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;
    
    // Obtener los datos del archivo incrustado.
    var fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // Obtener la extensión del archivo incrustado.
    var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```


### **Acceder a propiedades del marco de objeto OLE enlazado**

Aspose.Slides permite acceder a las propiedades del marco de objeto OLE enlazado.  

Este código JavaScript muestra cómo comprobar si un objeto OLE está enlazado y luego obtener la ruta al archivo enlazado:  
```javascript
var presentation = new asposeSlides.Presentation("sample.ppt");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    // Verificar si el objeto OLE está enlazado.
    if (oleFrame.isObjectLink()) {
        // Imprimir la ruta completa al archivo enlazado.
        console.log("OLE object frame is linked to:", oleFrame.getLinkPathLong());

        // Imprimir la ruta relativa al archivo enlazado si está presente.
        // Solo las presentaciones PPT pueden contener la ruta relativa.
        if (oleFrame.getLinkPathRelative() != null && oleFrame.getLinkPathRelative() != "") {
            console.log("OLE object frame relative path:", oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```


## **Cambiar datos del objeto OLE**

{{% alert color="primary" %}} 

En esta sección, el ejemplo de código a continuación usa [Aspose.Cells for Java](/cells/java/). 

{{% /alert %}}

Si un objeto OLE ya está incrustado en una diapositiva, puede acceder a ese objeto y modificar sus datos de esta manera:

1. Cargar una presentación con el objeto OLE incrustado creando una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation). 
2. Obtener la referencia de la diapositiva mediante su índice. 
3. Acceder a la forma del marco de objeto OLE. En nuestro ejemplo, usamos el PPTX creado anteriormente que tiene una forma en la primera diapositiva. 
4. Una vez accedido al marco del objeto OLE, puede realizar cualquier operación sobre él. 
5. Crear un objeto `Workbook` y acceder a los datos OLE. 
6. Acceder a la `Worksheet` deseada y modificar los datos. 
7. Guardar el `Workbook` actualizado en un flujo. 
8. Cambiar los datos del objeto OLE desde el flujo. 

En el ejemplo a continuación, se accede a un marco de objeto OLE (un objeto de gráfico de Excel incrustado en una diapositiva) y se modifican sus datos de archivo para actualizar los datos del gráfico.  
```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    var oleStream = java.newInstanceSync("java.io.ByteArrayInputStream", oleFrame.getEmbeddedData().getEmbeddedFileData());

    // Leer los datos del objeto OLE como un objeto Workbook.
    var workbook = java.newInstanceSync("Workbook", oleStream);

    var newOleStream = java.newInstanceSync("java.io.ByteArrayOutputStream");

    // Modificar los datos del Workbook.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    var fileOptions = java.newInstanceSync("OoxmlSaveOptions", java.getStaticFieldValue("com.aspose.cells.SaveFormat", "XLSX"));
    workbook.save(newOleStream, fileOptions);

    // Cambiar los datos del objeto del marco OLE.
    var newData = new asposeSlides.OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);

    newOleStream.close();
    oleStream.close();
}

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **Incrustar otros tipos de archivo en diapositivas**

Además de gráficos de Excel, Aspose.Slides for Node.js via Java permite incrustar otros tipos de archivos en diapositivas. Por ejemplo, puede insertar archivos HTML, PDF y ZIP como objetos. Cuando un usuario hace doble clic en el objeto insertado, se abre automáticamente en el programa correspondiente, o se le solicita al usuario seleccionar un programa adecuado para abrirlo.  

Este código JavaScript muestra cómo incrustar HTML y ZIP en una diapositiva:  
```javascript
var presentation = new asposeSlides.Presentation();
var slide = presentation.getSlides().get_Item(0);

var htmlBuffer = fs.readFileSync("sample.html");
var htmlData = Array.from(htmlBuffer);
var htmlDataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", htmlData), "html");
var htmlOleFrame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame.setObjectIcon(true);

var zipBuffer = fs.readFileSync("sample.zip");
var zipData = Array.from(zipBuffer);
var zipDataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", zipData), "zip");
var zipOleFrame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame.setObjectIcon(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **Establecer tipos de archivo para objetos incrustados**

Al trabajar con presentaciones, puede necesitar reemplazar objetos OLE antiguos por nuevos o sustituir un objeto OLE no compatible por uno compatible. Aspose.Slides for Node.js via Java permite establecer el tipo de archivo para un objeto incrustado, lo que le permite actualizar los datos del marco OLE o su extensión.  

Este código JavaScript muestra cómo establecer el tipo de archivo para un objeto OLE incrustado a `zip`:  
```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
var oleFileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

console.log("Current embedded file extension is:", fileExtension);

// Cambiar el tipo de archivo a ZIP.
var fileData = java.newArray("byte", Array.from(oleFileData));
oleFrame.setEmbeddedData(new asposeSlides.OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **Establecer imágenes de ícono y títulos para objetos incrustados**

Después de incrustar un objeto OLE, se agrega automáticamente una vista previa que consiste en una imagen de ícono. Esta vista previa es lo que los usuarios ven antes de acceder o abrir el objeto OLE. Si desea usar una imagen y texto específicos como elementos de la vista previa, puede establecer la imagen del ícono y el título usando Aspose.Slides for Node.js via Java.  

Este código JavaScript muestra cómo establecer la imagen del ícono y el título para un objeto incrustado:  
```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

// Añadir una imagen a los recursos de la presentación.
var image = asposeSlides.Images.fromFile("image.png");
var oleImage = presentation.getImages().addImage(image);
image.dispose();

// Establecer un título y la imagen para la vista previa del OLE.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **Evitar que un marco de objeto OLE se redimensione y reposicione**

Después de agregar un objeto OLE enlazado a una diapositiva de presentación, al abrir la presentación en PowerPoint, puede aparecer un mensaje solicitando actualizar los enlaces. Al hacer clic en el botón “Update Links” el tamaño y la posición del marco del objeto OLE pueden cambiar porque PowerPoint actualiza los datos del objeto enlazado y refresca la vista previa del objeto. Para evitar que PowerPoint solicite actualizar los datos del objeto, use el método `setUpdateAutomatic` de la clase [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/) con el valor `false`:  
```javascript
oleFrame.setUpdateAutomatic(false);
```


## **Extraer archivos incrustados**

Aspose.Slides for Node.js via Java permite extraer los archivos incrustados en diapositivas como objetos OLE de la siguiente manera:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) que contenga los objetos OLE que desea extraer. 
2. Recorrer todas las formas de la presentación y acceder a las formas [OLEObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe). 
3. Acceder a los datos de los archivos incrustados desde los marcos de objetos OLE y escribirlos en disco. 

Este código JavaScript muestra cómo extraer archivos incrustados en una diapositiva como objetos OLE:  
```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);

for (var index = 0; index < slide.getShapes().size(); index++) {
    var shape = slide.getShapes().get_Item(index);

    if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
        var oleFrame = shape;

        var fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();
        var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

        var filePath = "OLE_object_" + index + fileExtension;
        fs.writeFileSync(filePath, Buffer.from(fileData));
    }
}

presentation.dispose();
```


## **FAQ**

**¿Se renderizará el contenido OLE al exportar diapositivas a PDF/imágenes?**

Lo que es visible en la diapositiva se renderiza: el ícono/imagen de sustitución (vista previa). El contenido OLE “en vivo” no se ejecuta durante el renderizado. Si es necesario, establezca su propia imagen de vista previa para garantizar la apariencia esperada en el PDF exportado.

**¿Cómo puedo bloquear un objeto OLE en una diapositiva para que los usuarios no puedan moverlo/editarlo en PowerPoint?**

Bloquee la forma: Aspose.Slides proporciona [bloqueos a nivel de forma](/slides/es/nodejs-java/applying-protection-to-presentation/). No es encriptación, pero impide eficazmente ediciones y movimientos accidentales.

**¿Se conservarán las rutas relativas de los objetos OLE enlazados en el formato PPTX?**

En PPTX no existe información de “ruta relativa”, solo la ruta completa. Las rutas relativas se encuentran en el formato PPT más antiguo. Para portabilidad, prefiera rutas absolutas confiables/URIs accesibles o la incrustación.  