---
title: Administrar OLE
type: docs
weight: 40
url: /es/androidjava/manage-ole/
---

{{% alert color="primary" %}} 

OLE  (Object Linking & Embedding) es una tecnología de Microsoft que permite que los datos y objetos creados en una aplicación se inserten en otra aplicación a través de enlaces o incrustaciones. 

{{% /alert %}} 

Considera un gráfico creado en MS Excel. El gráfico se coloca dentro de una diapositiva de PowerPoint. Ese gráfico de Excel se considera un objeto OLE. 

- Un objeto OLE puede aparecer como un ícono. En este caso, cuando haces doble clic en el ícono, el gráfico se abre en su aplicación asociada (Excel), o se te pide que selecciones una aplicación para abrir o editar el objeto.
- Un objeto OLE puede mostrar contenidos reales, por ejemplo, el contenido de un gráfico. En este caso, el gráfico se activa en PowerPoint, la interfaz del gráfico se carga y puedes modificar los datos del gráfico dentro de la aplicación de PowerPoint.

[Aspose.Slides para Android a través de Java](https://products.aspose.com/slides/androidjava/) te permite insertar objetos OLE en diapositivas como marcos de objetos OLE ([OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame)).

## **Agregar Marcos de Objetos OLE a Diapositivas**
Suponiendo que ya creaste un gráfico en Microsoft Excel y quieres incrustar ese gráfico en una diapositiva como un marco de objeto OLE usando Aspose.Slides para Android a través de Java, puedes hacerlo de la siguiente manera:

1. Crea una instancia de la [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) clase.
1. Obtén la referencia de la diapositiva usando su índice.
1. Abre el archivo de Excel que contiene el objeto gráfico de Excel y guárdalo en `MemoryStream`.
1. Agrega el [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) a la diapositiva que contiene el arreglo de bytes y otra información sobre el objeto OLE.
1. Escribe la presentación modificada como un archivo PPTX.

En el ejemplo a continuación, agregamos un gráfico de un archivo de Excel a una diapositiva como un marco de objeto OLE usando Aspose.Slides para Android a través de Java.
**Nota** que el constructor de [IOleEmbeddedDataInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IOleEmbeddedDataInfo) toma una extensión de objeto embebible como segundo parámetro. Esta extensión permite que PowerPoint interprete correctamente el tipo de archivo y elija la aplicación adecuada para abrir este objeto OLE.

``` java 
// Instancia la clase Presentation que representa el archivo PPTX
Presentation pres = new Presentation();
try {
    // Accede a la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Carga un archivo excel en el stream
    FileInputStream fs = new FileInputStream("book1.xlsx");
    ByteArrayOutputStream mstream = new ByteArrayOutputStream();
    byte[] buf = new byte[4096];
    while (true)
    {
        int bytesRead = fs.read(buf, 0, buf.length);
        if (bytesRead <= 0)
            break;
        mstream.write(buf, 0, bytesRead);
    }
    fs.close();

    // Crea un objeto de datos para incrustar
    IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(mstream.toByteArray(), "xlsx");
    mstream.close();

    // Agrega un marco de objeto Ole
    IOleObjectFrame oleObjectFrame = sld.getShapes().addOleObjectFrame(0, 0,
            (float) pres.getSlideSize().getSize().getWidth(),
            (float) pres.getSlideSize().getSize().getHeight(),
            dataInfo);

    //Escribe el archivo PPTX en el disco
    pres.save("OleEmbed_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Accediendo a Marcos de Objetos OLE**
Si un objeto OLE ya está incrustado en una diapositiva, puedes encontrar o acceder a ese objeto fácilmente de esta manera:

1. Crea una instancia de la [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) clase.
1. Obtén la referencia de la diapositiva usando su índice.
1. Accede a la forma del marco de objeto OLE.

   En nuestro ejemplo, utilizamos el PPTX previamente creado, que solo tiene una forma en la primera diapositiva. Luego *convertimos* ese objeto en un [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame). Este fue el marco de objeto OLE deseado al que acceder.
1. Una vez que se accede al marco de objeto OLE, puedes realizar cualquier operación sobre él.

En el ejemplo a continuación, se accede a un marco de objeto OLE (un objeto gráfico de Excel incrustado en una diapositiva) y luego sus datos de archivo se escriben en un archivo de Excel.

``` java 
// Carga el PPTX a un objeto Presentation
Presentation pres = new Presentation("AccessingOLEObjectFrame.pptx");
try {
    // Accede a la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Convierte la forma a OleObjectFrame
    OleObjectFrame oleObjectFrame = (OleObjectFrame) sld.getShapes().get_Item(0);

    // Lee el OLE Object y lo escribe en disco
    if (oleObjectFrame != null) {
        // Obtiene datos del archivo embebido
        byte[] data = oleObjectFrame.getEmbeddedData().getEmbeddedFileData();

        // Obtiene la extensión del archivo embebido
        String fileExtention = oleObjectFrame.getEmbeddedData().getEmbeddedFileExtension();

        // Crea una ruta para guardar el archivo extraído
        String extractedPath = "excelFromOLE_out" + fileExtention;

        // Guarda los datos extraídos
        FileOutputStream fstr = new FileOutputStream(extractedPath);
        try {
            fstr.write(data, 0, data.length);
        } finally {
            fstr.close();
        }
    }
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Cambiando los Datos del Objeto OLE**

Si un objeto OLE ya está incrustado en una diapositiva, puedes acceder fácilmente a ese objeto y modificar sus datos de esta manera:

1. Abre la presentación deseada con el objeto OLE incrustado creando una instancia de la [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) clase.
1. Obtén la referencia de la diapositiva a través de su índice. 
1. Accede a la forma del marco de objeto OLE.

   En nuestro ejemplo, utilizamos el PPTX previamente creado que solo tiene una forma en la primera diapositiva. Luego *convertimos* ese objeto en un [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame). Este fue el marco de objeto OLE deseado al que acceder.
1. Una vez que se accede al marco de objeto OLE, puedes realizar cualquier operación sobre él.
1. Crea el objeto Workbook y accede a los datos OLE.
1. Accede a la hoja de trabajo deseada y modifica los datos.
1. Guarda el Workbook actualizado en flujos.
1. Cambia los datos del objeto OLE a partir de los datos del flujo.

En el ejemplo a continuación, se accede a un marco de objeto OLE (un objeto gráfico de Excel incrustado en una diapositiva) y luego sus datos de archivo se modifican para cambiar los datos del gráfico:

``` java 
Presentation pres = new Presentation("ChangeOLEObjectData.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
	
    OleObjectFrame ole = null;

    // Recorre todas las formas para el marco Ole
    for (IShape shape : slide.getShapes()) 
    {
        if (shape instanceof OleObjectFrame) 
        {
            ole = (OleObjectFrame) shape;
        }
    }

    if (ole != null) {
        ByteArrayInputStream msln = new ByteArrayInputStream(ole.getEmbeddedData().getEmbeddedFileData());
        try {
            // Lee los datos del objeto en Workbook
            Workbook Wb = new Workbook(msln);

            ByteArrayOutputStream msout = new ByteArrayOutputStream();
            try {
                // Modifica los datos del workbook
                Wb.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
                Wb.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
                Wb.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
                Wb.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

                OoxmlSaveOptions so1 = new OoxmlSaveOptions(com.aspose.cells.SaveFormat.XLSX);
                Wb.save(msout, so1);

                // Cambia los datos del objeto en el marco Ole
                IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(msout.toByteArray(), ole.getEmbeddedData().getEmbeddedFileExtension());
                ole.setEmbeddedData(newData);
            } finally {
                if (msout != null) msout.close();
            }
        } finally {
            if (msln != null) msln.close();
        }
    }

    pres.save("OleEdit_out.pptx", SaveFormat.Pptx);
} catch (Exception e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## Incrustar Otros Tipos de Archivos en Diapositivas

Además de gráficos de Excel, Aspose.Slides para Android a través de Java permite incrustar otros tipos de archivos en las diapositivas. Por ejemplo, puedes insertar archivos HTML, PDF y ZIP como objetos en una diapositiva. Cuando un usuario hace doble clic en el objeto insertado, este se lanza automáticamente en el programa relevante, o se le dirige al usuario a seleccionar un programa apropiado para abrir el objeto.

Este código Java muestra cómo incrustar HTML y ZIP en una diapositiva:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    byte[] htmlBytes = Files.readAllBytes(Paths.get("embedOle.html"));
    IOleEmbeddedDataInfo dataInfoHtml = new OleEmbeddedDataInfo(htmlBytes, "html");
    IOleObjectFrame oleFrameHtml = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, dataInfoHtml);
    oleFrameHtml.setObjectIcon(true);

    byte[] zipBytes = Files.readAllBytes(Paths.get("embedOle.zip"));
    IOleEmbeddedDataInfo dataInfoZip = new OleEmbeddedDataInfo(zipBytes, "zip");
    IOleObjectFrame oleFrameZip = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, dataInfoZip);
    oleFrameZip.setObjectIcon(true);

    pres.save("embeddedOle.pptx", SaveFormat.Pptx);
} catch (Exception e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## Establecer Tipos de Archivo para Objetos Incrustados

Al trabajar en presentaciones, es posible que necesites reemplazar antiguos objetos OLE con nuevos. O puede que necesites reemplazar un objeto OLE no soportado con uno soportado. 

Aspose.Slides para Android a través de Java te permite establecer el tipo de archivo para un objeto incrustado. De esta manera, puedes cambiar los datos del marco OLE o su extensión.

Este Java muestra cómo establecer el tipo de archivo para un objeto OLE incrustado:

```java
Presentation pres = new Presentation("embeddedOle.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IOleObjectFrame oleObjectFrame = (IOleObjectFrame)slide.getShapes().get_Item(0);
    System.out.println("La extensión de datos embebidos actuales es: " + oleObjectFrame.getEmbeddedData().getEmbeddedFileExtension());

    oleObjectFrame.setEmbeddedData(new OleEmbeddedDataInfo(Files.readAllBytes(Paths.get("embedOle.zip")), "zip"));

    pres.save("embeddedChanged.pptx", SaveFormat.Pptx);
} catch (Exception e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## Establecer Imágenes de Ícono y Títulos para Objetos Incrustados

Después de incrustar un objeto OLE, una vista previa que consiste en una imagen de ícono y un título se agrega automáticamente. La vista previa es lo que los usuarios ven antes de acceder u abrir el objeto OLE. 

Si deseas usar una imagen y texto específicos como elementos en la vista previa, puedes establecer la imagen de ícono y el título usando Aspose.Slides para Android a través de Java.

Este código Java muestra cómo establecer la imagen de ícono y el título para un objeto incrustado: 

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IOleObjectFrame oleObjectFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

        IPPImage oleImage;
        IImage image = Images.fromFile("image.png");
        try {
             oleImage = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    oleObjectFrame.setSubstitutePictureTitle("Mi título");
    oleObjectFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleObjectFrame.setObjectIcon(false);

    pres.save("embeddedOle-newImage.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## Extracción de Archivos Incrustados

Aspose.Slides para Android a través de Java te permite extraer archivos incrustados en diapositivas como objetos OLE de esta manera:

1. Crea una instancia de la [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) clase que contenga el objeto OLE que deseas extraer.
2. Recorre todas las formas en la presentación y accede a la forma [OLEObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/oleobjectframe).
3. Accede a los datos del archivo incrustado desde el marco de objeto OLE y escríbelo en disco. 

Este código Java muestra cómo extraer un archivo incrustado en una diapositiva como un objeto OLE:

```java
Presentation pres = new Presentation("embeddedOle.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    for (int index = 0; index < slide.getShapes().size(); index++)
    {
        IShape shape = slide.getShapes().get_Item(index);
        IOleObjectFrame oleFrame = (IOleObjectFrame)shape;

        if (oleFrame != null) 
		{
            byte[] data = oleFrame.getEmbeddedData().getEmbeddedFileData();
            String extension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

            // Guarda los datos extraídos
            FileOutputStream fstr = new FileOutputStream("oleFrame" + index + extension);
            try {
                fstr.write(data, 0, data.length);
            } finally {
                fstr.close();
            }
        }
    }
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```