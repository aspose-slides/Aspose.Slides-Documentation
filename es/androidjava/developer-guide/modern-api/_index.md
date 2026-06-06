---
title: Mejorar el procesamiento de imágenes con la API moderna
linktitle: API moderna
type: docs
weight: 237
url: /es/androidjava/modern-api/
keywords:
- android.graphics
- API moderna
- dibujo
- miniatura de diapositiva
- diapositiva a imagen
- miniatura de forma
- forma a imagen
- miniatura de presentación
- presentación a imágenes
- añadir imagen
- añadir foto
- Android
- Java
- Aspose.Slides
description: "Modernice el procesamiento de imágenes de diapositivas sustituyendo las API de imágenes obsoletas por la API moderna de Java para una automatización fluida de PowerPoint y OpenDocument."
---
## **Introducción**

Históricamente, Aspose Slides tiene una dependencia de android.graphics y en la API pública contiene las siguientes clases de ahí:
- [Canvas](https://developer.android.com/reference/android/graphics/Canvas)
- [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap)

A partir de la versión 24.4, esta API pública está declarada obsoleta.

Para deshacernos de las dependencias de estas clases, añadimos la llamada “API moderna”, es decir, la API que debe usarse en lugar de la obsoleta, cuyas firmas contienen dependencias de [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap). [Canvas](https://developer.android.com/reference/android/graphics/Canvas) está declarada obsoleta y su soporte se ha eliminado de la API pública de Slides.

En las versiones actuales, trate la API pública que depende de tipos de android.graphics como legado/obsoleta. Utilice la API moderna para nuevo código y al migrar flujos de trabajo de procesamiento de imágenes existentes.

## **API moderna**

Se añadieron las siguientes clases y enumeraciones a la API pública:

- [IImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iimage/) - representa la imagen raster o vectorial.
- [ImageFormat](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/imageformat/) - representa el formato de archivo de la imagen.
- [Images](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/images/) - métodos para instanciar y trabajar con la interfaz [IImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iimage/).

Tenga en cuenta que [IImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iimage/) es desechable y su uso debe ir seguido de una llamada a `dispose()` o de otro patrón de eliminación conveniente.

Utilice `getImage` para renderizar una diapositiva o forma única. Utilice `getImages` para renderizar varias diapositivas de la presentación. Utilice los métodos de [Images](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/images/) para cargar imágenes, `addImage` con [IImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iimage/) para añadirlas a una presentación, y `replaceImage` con [IImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iimage/) para actualizar una imagen existente de la presentación.

Un escenario típico de uso de la nueva API puede verse como sigue:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage;
    // instanciar una instancia desechable de IImage a partir del archivo en disco.
    IImage image = Images.fromFile("image.png");
    try {
        // crear una imagen de PowerPoint añadiendo una instancia de IImage a las imágenes de la presentación.
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // añadir una forma de imagen en la diapositiva #1
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // obtener una instancia de IImage que representa la diapositiva #1.
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Size(1920, 1080));
    try {
        // guardar la imagen en el disco.
        slideImage.save("slide1.jpeg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Reemplazando el código antiguo con la API moderna**

En general, necesitará sustituir las llamadas que utilizan [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap) por los nuevos métodos que usan [IImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iimage/).

Legacy/deprecated API:
``` java
Presentation pres = new Presentation();
try {
    Bitmap slideImage = pres.getSlides().get_Item(0).getThumbnail(new Size(1920, 1080));
    FileOutputStream fos = null;
    try {
        fos = new FileOutputStream("image.png");
        slideImage.compress(android.graphics.Bitmap.CompressFormat.PNG, 100, fos);
    } catch (FileNotFoundException e) {
        e.printStackTrace();
    } finally {
        if (fos != null) {
            try {
                fos.close();
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```
Modern API:
``` java
Presentation pres = new Presentation();
try {
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Size(1920, 1080));
    try {
        slideImage.save("image.png", ImageFormat.Png);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **Obteniendo una miniatura de diapositiva**

Legacy/deprecated API:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    Bitmap slideImage = pres.getSlides().get_Item(0).getThumbnail();
    FileOutputStream fos = null;
    try {
        fos = new FileOutputStream("slide1.png");
        slideImage.compress(android.graphics.Bitmap.CompressFormat.PNG, 100, fos);
    } catch (FileNotFoundException e) {
        e.printStackTrace();
    } finally {
        if (fos != null) {
            try {
                fos.close();
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

Modern API:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    IImage slideImage = pres.getSlides().get_Item(0).getImage();
    try {
        slideImage.save("slide1.png", ImageFormat.Png);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **Obteniendo una miniatura de forma**

Legacy/deprecated API:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    Bitmap shapeImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThumbnail();
    FileOutputStream fos = null;
    try {
        fos = new FileOutputStream("shape.png");
        shapeImage.compress(android.graphics.Bitmap.CompressFormat.PNG, 100, fos);
    } catch (FileNotFoundException e) {
        e.printStackTrace();
    } finally {
        if (fos != null) {
            try {
                fos.close();
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

Modern API:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    IImage shapeImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    try {
        shapeImage.save("shape.png");
    } finally {
        if (shapeImage != null) shapeImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **Obteniendo una miniatura de presentación**

Legacy/deprecated API:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    Bitmap[] bitmaps = pres.getThumbnails(new RenderingOptions(), new Size(1980, 1028));
    for (int index = 0; index < bitmaps.length; index++)
    {
        android.graphics.Bitmap thumbnail = bitmaps[index];
        FileOutputStream fos = null;
        try {
            fos = new FileOutputStream("slide" + index + ".png");
            thumbnail.compress(android.graphics.Bitmap.CompressFormat.PNG, 100, fos);
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } finally {
            if (fos != null) {
                try {
                    fos.close();
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

Modern API:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    IImage[] images = pres.getImages(new RenderingOptions(), new Size(1980, 1028));
    try
    {
        for (int index = 0; index < images.length; index++)
        {
            IImage thumbnail = images[index];
            thumbnail.save("slide" + index + ".png", ImageFormat.Png);
        }
    }
    finally
    {
        for (IImage image : images)
        {
            image.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **Añadiendo una imagen a una presentación**

Legacy/deprecated API:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage = null;
    File file = new File("image.png");
    Bitmap bitmap = BitmapFactory.decodeFile(file.getAbsolutePath());
    ppImage = pres.getImages().addImage(bitmap);

    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
} finally {
    if (pres != null) pres.dispose();
}
```

Modern API:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage;
    IImage image = Images.fromFile("image.png");
    try {
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Métodos obsoletos y su sustitución en la API moderna**

### **Presentation**
| Firma del método | Firma del método de sustitución |
|------------------|---------------------------------|
| public final Bitmap[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, Size imageSize) | public final IImage[] getImages(IRenderingOptions options, Size imageSize) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Size imageSize) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |

### **Shape**
| Firma del método | Firma del método de sustitución |
|------------------|---------------------------------|
| public final Bitmap getThumbnail() | public final IImage getImage() |
| public final Bitmap getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| Firma del método | Firma del método de sustitución |
|------------------|---------------------------------|
| public final Bitmap getThumbnail() | public final IImage getImage() |
| public final Bitmap getThumbnail(Size imageSize) | public final IImage getImage(Size imageSize) |
| public final Bitmap getThumbnail(float scaleX, float scaleY) | public final IImage getImage(float scaleX, float scaleY) |
| public final Bitmap getThumbnail(IRenderingOptions options) | public final IImage getImage(IRenderingOptions options) |
| public final Bitmap getThumbnail(IRenderingOptions options, Size imageSize) | public final IImage getImage(IRenderingOptions options, Size imageSize) |
| public final Bitmap getThumbnail(IRenderingOptions options, float scaleX, float scaleY) | public final IImage getImage(IRenderingOptions options, float scaleX, float scaleY) |
| public final Bitmap getThumbnail(ITiffOptions options) | public final IImage getImage(ITiffOptions options) |
| public final void renderToGraphics(IRenderingOptions options, Canvas graphics) | No Modern API replacement |
| public final void renderToGraphics(IRenderingOptions options, Canvas graphics, Size renderingSize) | No Modern API replacement |
| public final void renderToGraphics(IRenderingOptions options, Canvas graphics, float scaleX, float scaleY) | No Modern API replacement |

### **Output**
| Firma del método | Firma del método de sustitución |
|------------------|---------------------------------|
| public final IOutputFile add(String path, Bitmap image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| Firma del método | Firma del método de sustitución |
|------------------|---------------------------------|
| public final IPPImage addImage(Bitmap image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| Firma del método | Firma del método de sustitución |
|------------------|---------------------------------|
| public final Bitmap getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| Firma del método | Firma del método de sustitución |
|------------------|---------------------------------|
| public final Bitmap getTileImage(Integer styleColor) | public final IImage getTile(Integer styleColor) |
| public final Bitmap getTileImage(Integer background, Integer foreground) | public final IImage getTile(Integer background, Integer foreground) |

### **PatternFormatEffectiveData**
| Firma del método | Firma del método de sustitución |
|------------------|---------------------------------|
| public final Bitmap getTileImage(Integer background, Integer foreground) | public final IImage getTileIImage(Integer background, Integer foreground) |

## **Soporte de API para Canvas**

Los métodos que utilizan [Canvas](https://developer.android.com/reference/android/graphics/Canvas) están declarados obsoletos y no tienen una sustitución directa en la API moderna.

Utilice los métodos de renderizado de imágenes de la API moderna en lugar de la API que renderiza a [Canvas](https://developer.android.com/reference/android/graphics/Canvas):

[Slide](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics)](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-)
- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics, Size renderingSize)](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-com.aspose.slides.android.Size-)

## **Preguntas frecuentes**

**¿Por qué se eliminó android.graphics.Canvas?**

El soporte para [Canvas](https://developer.android.com/reference/android/graphics/Canvas) está obsoleto en la API pública para unificar el trabajo con renderizado e imágenes, eliminar vínculos con dependencias específicas de la plataforma y pasar a un enfoque multiplataforma con [IImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iimage/). Utilice `getImage` o `getImages` en lugar de renderizar a [Canvas](https://developer.android.com/reference/android/graphics/Canvas).

**¿Cuál es el beneficio práctico de [IImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iimage/) respecto a [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap)?**

[IImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iimage/) unifica el trabajo con imágenes raster y vectoriales y simplifica el guardado en varios formatos mediante [ImageFormat](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/imageformat/).

**¿Afectará la API moderna al rendimiento de la generación de miniaturas?**

Pasar de `getThumbnail` a `getImage` no empeora los escenarios: los nuevos métodos ofrecen las mismas capacidades para producir imágenes con opciones y tamaños, manteniendo el soporte para opciones de renderizado. La ganancia o pérdida específica depende del caso, pero funcionalmente los reemplazos son equivalentes.