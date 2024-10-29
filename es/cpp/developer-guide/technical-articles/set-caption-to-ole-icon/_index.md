---
title: Establecer título del icono OLE
type: docs
weight: 110
url: /es/cpp/set-caption-to-ole-icon/
---

Se han añadido los métodos **get_SubstitutePictureTitle()** y **set_SubstitutePictureTitle()** a las clases **IOleObjectFrame** y **OleObjectFrame**. Permiten obtener, establecer o cambiar el título de un icono OLE. El siguiente fragmento de código muestra un ejemplo de cómo crear un objeto de Excel y establecer su título.

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Agregar un objeto OLE a la diapositiva
auto allBytes = System::IO::File::ReadAllBytes(u"oleSourceFile.xlsx");
auto dataInfo = System::MakeObject<OleEmbeddedDataInfo>(allBytes, "xlsx");

auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(20, 20, 50, 50, dataInfo);
    
// Agregar una imagen a la colección de imágenes de la presentación
auto image = Images::FromFile(u"oleIconFile.ico");
auto ppImage = presentation->get_Images()->AddImage(image);
image->Dispose();

// Establecer la imagen como un icono para el objeto OLE
oleFrame->set_IsObjectIcon(true);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(ppImage);

// Establecer un título al icono OLE
oleFrame->set_SubstitutePictureTitle(u"Ejemplo de título");
```