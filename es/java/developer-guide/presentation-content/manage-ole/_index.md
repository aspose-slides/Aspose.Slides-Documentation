---
title: Administrar OLE
type: docs
weight: 40
url: /es/java/manage-ole/
keywords:
- agregar OLE
- incrustar OLE
- agregar un objeto
- incrustar un objeto
- incrustar un archivo
- objeto vinculado
- Vinculación e Incorporación de Objetos
- objeto OLE
- PowerPoint 
- presentación
- Java
- Aspose.Slides para Java
description: Agregar objetos OLE a presentaciones de PowerPoint en Java
---

{{% alert color="primary" %}} 

OLE  (Vinculación e Incorporación de Objetos) es una tecnología de Microsoft que permite que datos y objetos creados en una aplicación sean colocados en otra aplicación a través de vinculación o incrustación. 

{{% /alert %}} 

Considera un gráfico creado en MS Excel. El gráfico se coloca dentro de una diapositiva de PowerPoint. Ese gráfico de Excel se considera un objeto OLE. 

- Un objeto OLE puede aparecer como un ícono. En este caso, cuando haces doble clic en el ícono, el gráfico se abre en su aplicación asociada (Excel), o se te pide seleccionar una aplicación para abrir o editar el objeto. 
- Un objeto OLE puede mostrar contenidos reales, por ejemplo, los contenidos de un gráfico. En este caso, el gráfico se activa en PowerPoint, se carga la interfaz del gráfico y puedes modificar los datos del gráfico dentro de la aplicación PowerPoint.

[Aspose.Slides para Java](https://products.aspose.com/slides/java/) te permite insertar Objetos OLE en diapositivas como Marcos de Objetos OLE ([OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame)).

## **Agregar Marcos de Objetos OLE a Diapositivas**
Suponiendo que ya has creado un gráfico en Microsoft Excel y deseas incrustar ese gráfico en una diapositiva como un Marco de Objeto OLE usando Aspose.Slides para Java, puedes hacerlo de esta manera:

1. Crea una instancia de la [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) clase.
2. Obtén la referencia de la diapositiva usando su índice.
3. Abre el archivo de Excel que contiene el objeto gráfico de Excel y guárdalo en `MemoryStream`.
4. Agrega el [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) a la diapositiva que contiene el arreglo de bytes y otra información sobre el objeto OLE.
5. Escribe la presentación modificada como un archivo PPTX.

En el ejemplo a continuación, hemos agregado un gráfico de un archivo de Excel a una diapositiva como un Marco de Objeto OLE usando Aspose.Slides para Java.  
**Nota** que el constructor [IOleEmbeddedDataInfo](https://reference.aspose.com/slides/java/com.aspose.slides/IOleEmbeddedDataInfo) toma una extensión de objeto incrustable como segundo parámetro. Esta extensión permite que PowerPoint interprete correctamente el tipo de archivo y elija la aplicación correcta para abrir este objeto OLE.

``` java 
// Instancia la clase Presentation que representa el archivo PPTX
Presentation pres = new Presentation();
try {
    // Accede a la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Carga un archivo excel a un stream
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

    // Agrega una forma de Marco de Objeto Ole
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
Si un objeto OLE ya está incrustado en una diapositiva, puedes encontrar o acceder a ese objeto fácilmente de esta forma:

1. Crea una instancia de la [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) clase.
2. Obtén la referencia de la diapositiva usando su índice.
3. Accede a la forma de Marco de Objeto OLE.

   En nuestro ejemplo, usamos el PPTX previamente creado, que tiene solo una forma en la primera diapositiva. Luego *convertimos* ese objeto como un [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame). Este fue el Marco de Objeto OLE deseado que se iba a acceder.
4. Una vez que se accede al Marco de Objeto OLE, puedes realizar cualquier operación en él.

En el ejemplo a continuación, se accede a un Marco de Objeto OLE (un objeto gráfico de Excel incrustado en una diapositiva) y luego los datos de su archivo se escriben en un archivo de Excel.

``` java 
// Carga el PPTX a un objeto Presentation
Presentation pres = new Presentation("AccessingOLEObjectFrame.pptx");
try {
    // Accede a la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Convierte la forma a OleObjectFrame
    OleObjectFrame oleObjectFrame = (OleObjectFrame) sld.getShapes().get_Item(0);

    // Lee el objeto OLE y lo escribe en disco
    if (oleObjectFrame != null) {
        // Obtiene los datos del archivo incrustado
        byte[] data = oleObjectFrame.getEmbeddedData().getEmbeddedFileData();

        // Obtiene la extensión del archivo incrustado
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

1. Abre la presentación deseada con el Objeto OLE incrustado creando una instancia de la [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) clase.
2. Obtén la referencia de la diapositiva a través de su índice. 
3. Accede a la forma de Marco de Objeto OLE.

   En nuestro ejemplo, usamos el PPTX previamente creado que tiene solo una forma en la primera diapositiva. Luego *convertimos* ese objeto como un [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame). Este fue el Marco de Objeto OLE deseado que se iba a acceder.
4. Una vez que se accede al Marco de Objeto OLE, puedes realizar cualquier operación en él.
5. Crea el objeto Workbook y accede a los Datos OLE.
6. Accede a la Hoja de Cálculo deseada y modifica los datos.
7. Guarda el Workbook actualizado en streams.
8. Cambia los datos del objeto OLE a partir de los datos del stream.

En el ejemplo a continuación, se accede a un Marco de Objeto OLE (un objeto gráfico de Excel incrustado en una diapositiva) y luego sus datos de archivo se modifican para cambiar los datos del gráfico:

``` java 
Presentation pres = new Presentation("ChangeOLEObjectData.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
	
    OleObjectFrame ole = null;

    // Recorre todas las formas en busca del marco Ole
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
            // Lee los datos del objeto en el Workbook
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

                // Cambia los datos del objeto del marco Ole
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

## Incrustando Otros Tipos de Archivos en Diapositivas

Además de gráficos de Excel, Aspose.Slides para Java te permite incrustar otros tipos de archivos en diapositivas. Por ejemplo, puedes insertar archivos HTML, PDF y ZIP como objetos en una diapositiva. Cuando un usuario hace doble clic en el objeto insertado, el objeto se lanza automáticamente en el programa correspondiente, o se le dirige al usuario a seleccionar un programa apropiado para abrir el objeto. 

Este código Java te muestra cómo incrustar HTML y ZIP en una diapositiva:

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

## Estableciendo Tipos de Archivo para Objetos Incrustados

Al trabajar en presentaciones, puede que necesites reemplazar objetos OLE antiguos por otros nuevos. O puede que necesites reemplazar un objeto OLE no compatible por uno que sí lo sea. 

Aspose.Slides para Java te permite establecer el tipo de archivo para un objeto incrustado. De esta manera, puedes cambiar los datos del marco OLE o su extensión. 

Este código Java te muestra cómo establecer el tipo de archivo para un objeto OLE incrustado:

```java
Presentation pres = new Presentation("embeddedOle.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IOleObjectFrame oleObjectFrame = (IOleObjectFrame)slide.getShapes().get_Item(0);
    System.out.println("La extensión de datos incrustados actual es: " + oleObjectFrame.getEmbeddedData().getEmbeddedFileExtension());

    oleObjectFrame.setEmbeddedData(new OleEmbeddedDataInfo(Files.readAllBytes(Paths.get("embedOle.zip")), "zip"));

    pres.save("embeddedChanged.pptx", SaveFormat.Pptx);
} catch (Exception e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## Estableciendo Imágenes de Íconos y Títulos para Objetos Incrustados

Después de incrustar un objeto OLE, se añade automáticamente una vista previa que consiste en una imagen de ícono y un título. La vista previa es lo que los usuarios ven antes de acceder o abrir el objeto OLE. 

Si deseas usar una imagen y un texto específicos como elementos en la vista previa, puedes establecer la imagen de ícono y el título usando Aspose.Slides para Java. 

Este código Java te muestra cómo establecer la imagen de ícono y el título para un objeto incrustado: 

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

## **Prevenir que un Marco de Objeto OLE Sea Redimensionado y Reposicionado**

Después de agregar un objeto OLE vinculado a una diapositiva de presentación, cuando abres la presentación en PowerPoint, podrías ver un mensaje pidiéndote que actualices los enlaces. Al hacer clic en el botón "Actualizar Enlaces", puede cambiar el tamaño y la posición del marco del objeto OLE porque PowerPoint actualiza los datos del objeto OLE vinculado y refresca la vista previa del objeto. Para evitar que PowerPoint te pida actualizar los datos del objeto, establece el método `setUpdateAutomatic` de la interfaz [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/) en `false`:

```java
oleObjectFrame.setUpdateAutomatic(false);
```

## Extrayendo Archivos Incrustados

Aspose.Slides para Java te permite extraer los archivos incrustados en las diapositivas como objetos OLE de esta manera:

1. Crea una instancia de la [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) clase que contiene el objeto OLE que pretendes extraer.
2. Recorre todas las formas en la presentación y accede a la forma [OLEObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/oleobjectframe).
3. Accede a los datos del archivo incrustado desde el Marco de Objeto OLE y escríbelos en el disco. 

Este código Java te muestra cómo extraer un archivo incrustado en una diapositiva como un objeto OLE:

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