---
title: Administrar OLE
type: docs
weight: 40
url: /androidjava/manage-ole/
keywords:
- agregar OLE
- incrustar OLE
- agregar un objeto
- incrustar un objeto
- incrustar un archivo
- objeto vinculado
- Vinculación e Incrustación de Objetos
- objeto OLE
- PowerPoint 
- presentación
- Android
- Java
- Aspose.Slides para Android a través de Java
description: Agregar objetos OLE a presentaciones de PowerPoint en Java
---

{{% alert color="primary" %}} 

OLE  (Vinculación e Incrustación de Objetos) es una tecnología de Microsoft que permite que los datos y objetos creados en una aplicación se coloquen en otra aplicación a través de enlaces o incrustaciones. 

{{% /alert %}} 

Considere un gráfico creado en MS Excel. El gráfico se coloca luego dentro de una diapositiva de PowerPoint. Ese gráfico de Excel se considera un objeto OLE. 

- Un objeto OLE puede aparecer como un ícono. En este caso, cuando hace doble clic en el ícono, el gráfico se abre en su aplicación asociada (Excel), o se le pide que seleccione una aplicación para abrir o editar el objeto. 
- Un objeto OLE puede mostrar contenidos reales; por ejemplo, los contenidos de un gráfico. En este caso, el gráfico se activa en PowerPoint, se carga la interfaz del gráfico y puede modificar los datos del gráfico dentro de la aplicación de PowerPoint.

[Aspose.Slides para Android a través de Java](https://products.aspose.com/slides/androidjava/) le permite insertar Objetos OLE en diapositivas como Marcos de Objetos OLE ([OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame)).

## **Agregar Marcos de Objetos OLE a las Diapositivas**
Suponiendo que ya haya creado un gráfico en Microsoft Excel y desea incrustar ese gráfico en una diapositiva como un Marco de Objeto OLE utilizando Aspose.Slides para Android a través de Java, puede hacerlo de esta manera:

1. Cree una instancia de la [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) clase.
2. Obtenga la referencia de la diapositiva utilizando su índice.
3. Abra el archivo de Excel que contiene el objeto gráfico de Excel y guárdelo en `MemoryStream`.
4. Agregue el [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) a la diapositiva que contiene la matriz de bytes y otra información sobre el objeto OLE.
5. Escriba la presentación modificada como un archivo PPTX.

En el ejemplo a continuación, agregamos un gráfico de un archivo de Excel a una diapositiva como un Marco de Objeto OLE utilizando Aspose.Slides para Android a través de Java.
**Nota** que el constructor [IOleEmbeddedDataInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IOleEmbeddedDataInfo) acepta una extensión de objeto embebible como segundo parámetro. Esta extensión permite que PowerPoint interprete correctamente el tipo de archivo y elija la aplicación adecuada para abrir este objeto OLE.

``` java 
// Instancia la clase Prseetation que representa el archivo PPTX
Presentation pres = new Presentation();
try {
    // Accede a la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Carga un archivo de excel a la secuencia
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

    // Crea un objeto de datos para incrustación
    IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(mstream.toByteArray(), "xlsx");
    mstream.close();

    // Agrega una forma de Marco de Objeto OLE
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
Si un objeto OLE ya está incrustado en una diapositiva, puede encontrar o acceder a ese objeto fácilmente de esta manera:

1. Cree una instancia de la [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) clase.
2. Obtenga la referencia de la diapositiva utilizando su índice.
3. Acceda a la forma de Marco de Objeto OLE.

   En nuestro ejemplo, utilizamos el PPTX creado anteriormente, que tiene solo una forma en la primera diapositiva. Luego *convertemos* ese objeto en un [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame). Este fue el Marco de Objeto OLE deseado para acceder.
4. Una vez que se accede al Marco de Objeto OLE, puede realizar cualquier operación en él.

En el ejemplo a continuación, se accede a un Marco de Objeto OLE (un objeto gráfico de Excel incrustado en una diapositiva) y luego se escriben los datos de su archivo en un archivo de Excel.

``` java 
// Carga el PPTX a un objeto Presentation
Presentation pres = new Presentation("AccessingOLEObjectFrame.pptx");
try {
    // Accede a la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Convierte la forma a OleObjectFrame
    OleObjectFrame oleObjectFrame = (OleObjectFrame) sld.getShapes().get_Item(0);

    // Lee el objeto OLE y lo escribe en el disco
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

Si un objeto OLE ya está incrustado en una diapositiva, puede acceder fácilmente a ese objeto y modificar sus datos de esta manera:

1. Abra la presentación deseada con el Objeto OLE incrustado creando una instancia de la [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) clase.
2. Obtenga la referencia de la diapositiva a través de su índice. 
3. Acceda a la forma de Marco de Objeto OLE.

   En nuestro ejemplo, utilizamos el PPTX creado anteriormente que tiene solo una forma en la primera diapositiva. Luego *convertemos* ese objeto en un [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame). Este fue el Marco de Objeto OLE deseado para acceder.
4. Una vez que se accede al Marco de Objeto OLE, puede realizar cualquier operación en él.
5. Cree el objeto Workbook y acceda a los datos OLE.
6. Acceda a la Hoja de Cálculo deseada y enmiende los datos.
7. Guarde el Workbook actualizado en secuencias.
8. Cambie los datos del objeto OLE desde los datos de la secuencia.

En el ejemplo a continuación, se accede a un Marco de Objeto OLE (un objeto gráfico de Excel incrustado en una diapositiva) y luego se modifican los datos de su archivo para cambiar los datos del gráfico:

``` java 
Presentation pres = new Presentation("ChangeOLEObjectData.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
	
    OleObjectFrame ole = null;

    // Recorre todas las formas para el marco OLE
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
                // Modifica los datos del libro
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

## Incrustar Otros Tipos de Archivos en Diapositivas

Además de gráficos de Excel, Aspose.Slides para Android a través de Java le permite incrustar otros tipos de archivos en diapositivas. Por ejemplo, puede insertar archivos HTML, PDF y ZIP como objetos en una diapositiva. Cuando un usuario hace doble clic en el objeto insertado, el objeto se inicia automáticamente en el programa relevante, o se dirige al usuario a seleccionar un programa apropiado para abrir el objeto.

Este código Java le muestra cómo incrustar HTML y ZIP en una diapositiva:

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

## Establecer Tipos de Archivos para Objetos Incrustados

Al trabajar en presentaciones, es posible que necesite reemplazar objetos OLE antiguos por nuevos. O puede que necesite reemplazar un objeto OLE no compatible por uno compatible. 

Aspose.Slides para Android a través de Java le permite establecer el tipo de archivo para un objeto incrustado. De esta manera, puede cambiar los datos del marco OLE o su extensión.

Este Java le muestra cómo establecer el tipo de archivo para un objeto OLE incrustado:

```java
Presentation pres = new Presentation("embeddedOle.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IOleObjectFrame oleObjectFrame = (IOleObjectFrame)slide.getShapes().get_Item(0);
    System.out.println("La extensión de datos incrustados actuales es: " + oleObjectFrame.getEmbeddedData().getEmbeddedFileExtension());

    oleObjectFrame.setEmbeddedData(new OleEmbeddedDataInfo(Files.readAllBytes(Paths.get("embedOle.zip")), "zip"));

    pres.save("embeddedChanged.pptx", SaveFormat.Pptx);
} catch (Exception e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## Establecer Imágenes de Icono y Títulos para Objetos Incrustados

Después de que incruste un objeto OLE, se agrega automáticamente una vista previa que consiste en una imagen de ícono y un título. La vista previa es lo que los usuarios ven antes de acceder o abrir el objeto OLE. 

Si desea usar una imagen y un texto específicos como elementos en la vista previa, puede establecer la imagen del icono y el título utilizando Aspose.Slides para Android a través de Java.

Este código Java le muestra cómo establecer la imagen del ícono y el título para un objeto incrustado: 

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

## **Prevenir que un Marco de Objeto OLE sea Redimensionado y Reposicionado**

Después de agregar un objeto OLE vinculado a una diapositiva de presentación, al abrir la presentación en PowerPoint, es posible que vea un mensaje que le pida que actualice los vínculos. Hacer clic en el botón "Actualizar Vínculos" puede cambiar el tamaño y la posición del marco del objeto OLE porque PowerPoint actualiza los datos del objeto OLE vinculado y actualiza la vista previa del objeto. Para evitar que PowerPoint le pida que actualice los datos del objeto, configure el método `setUpdateAutomatic` de la interfaz [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/) a `false`:

```java
oleObjectFrame.setUpdateAutomatic(false);
```

## Extracción de Archivos Incrustados

Aspose.Slides para Android a través de Java le permite extraer los archivos incrustados en diapositivas como objetos OLE de esta manera:

1. Cree una instancia de la [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) clase que contenga el objeto OLE que desea extraer.
2. Recorra todas las formas en la presentación y acceda a la forma [OLEObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/oleobjectframe).
3. Acceda a los datos del archivo incrustado desde el Marco de Objeto OLE y escríbalo en el disco. 

Este código Java le muestra cómo extraer un archivo incrustado en una diapositiva como un objeto OLE:

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