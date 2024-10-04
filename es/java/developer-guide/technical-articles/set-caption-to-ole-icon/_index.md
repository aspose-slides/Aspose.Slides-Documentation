---
titulo: Establecer título en el ícono OLE
tipo: docs
peso: 130
url: /java/set-caption-to-ole-icon/
---

Se han agregado nuevos métodos **getSubstitutePictureTitle** y **setSubstitutePictureTitle** a la interfaz **IOleObjectFrame** y a la clase **OleObjectFrame**. Esto permite obtener, establecer o cambiar el título de un ícono OLE. El fragmento de código a continuación muestra un ejemplo de creación de un objeto de Excel y establecimiento de su título.

```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Agregar un objeto OLE a la diapositiva
byte[] allBytes = Files.readAllBytes(Paths.get("oleSourceFile.xlsx"));
OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(allBytes, "xlsx");

IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(20, 20, 50, 50, dataInfo);

// Agregar una imagen a la colección de imágenes de la presentación
IImage image = Images.fromFile("oleIconFile.ico");
IPPImage ppImage = presentation.getImages().addImage(image);
image.dispose();

// Establecer la imagen como un ícono para el objeto OLE
oleFrame.setObjectIcon(true);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(ppImage);

// Establecer un título para el ícono OLE
oleFrame.setSubstitutePictureTitle("Ejemplo de título");
```