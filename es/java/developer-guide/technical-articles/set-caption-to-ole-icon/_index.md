---
title: Establecer título en icono OLE
type: docs
weight: 130
url: /es/java/set-caption-to-ole-icon/
---

Se han añadido nuevos métodos **getSubstitutePictureTitle** y **setSubstitutePictureTitle** a la interfaz **IOleObjectFrame** y a la clase **OleObjectFrame**. Permite obtener, establecer o cambiar el título de un icono OLE. El siguiente fragmento de código muestra un ejemplo de creación de un objeto de Excel y establecimiento de su título.

```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Agregar un objeto OLE al diapositiva
byte[] allBytes = Files.readAllBytes(Paths.get("oleSourceFile.xlsx"));
OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(allBytes, "xlsx");

IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(20, 20, 50, 50, dataInfo);

// Agregar una imagen a la colección de imágenes de la presentación
IImage image = Images.fromFile("oleIconFile.ico");
IPPImage ppImage = presentation.getImages().addImage(image);
image.dispose();

// Establecer la imagen como un icono para el objeto OLE
oleFrame.setObjectIcon(true);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(ppImage);

// Establecer un título en el icono OLE
oleFrame.setSubstitutePictureTitle("Ejemplo de título");
```