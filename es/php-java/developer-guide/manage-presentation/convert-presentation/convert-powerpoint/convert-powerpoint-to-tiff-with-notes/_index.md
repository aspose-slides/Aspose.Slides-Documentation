---
title: Convertir PowerPoint a TIFF con Notas
type: docs
weight: 100
url: /es/php-java/convert-powerpoint-to-tiff-with-notes/
keywords: "Convertir PowerPoint a TIFF con notas"
description: "Convertir PowerPoint a TIFF con notas en Aspose.Slides."
---

## **Convertir PPT(X) en Vista de Diapositivas de Notas a TIFF**
El método [Save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) expuesto por la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) se puede usar para convertir toda la presentación en vista de Diapositivas de Notas a TIFF. Los fragmentos de código a continuación actualizan la presentación de muestra a imágenes TIFF en vista de Diapositivas de Notas, como se muestra a continuación:

```php
//Instanciar un objeto Presentation que representa un archivo de presentación
  $pres = new Presentation("demo.pptx");
  try {
    $opts = new TiffOptions();
    $opts->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomFull);
    # Guardando la presentación a TIFF con notas
    $pres->save("Tiff-Notes.tiff", SaveFormat::Tiff, $opts);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Los fragmentos de código anteriores actualizan la presentación de muestra a imágenes TIFF en vista de Diapositivas de Notas, como se muestra a continuación:

|**La vista de la presentación fuente con notas de diapositiva**|** |
| :- | :- |
|![todo:image_alt_text](http://i.imgur.com/6HdY6IV.png)| |


|**La imagen TIFF generada en vista de Diapositivas de Notas**|** |
| :- | :- |
|![todo:image_alt_text](http://i.imgur.com/A3ttT2y.png)| |

{{% alert title="Consejo" color="primary" %}}

Es posible que desee consultar el convertidor de Aspose [GRATIS de PowerPoint a Póster](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).

{{% /alert %}}