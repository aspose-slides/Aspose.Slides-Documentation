---
title: Fondo de Presentación
type: docs
weight: 20
url: /java/presentation-background/
keywords: "fondo de PowerPoint, establecer fondo en Java"
description: "Establecer fondo en presentación de PowerPoint en Java"
---

Los colores sólidos, los colores degradados y las imágenes se utilizan a menudo como imágenes de fondo para las diapositivas. Puedes establecer el fondo ya sea para una **diapositiva normal** (diapositiva individual) o **diapositiva maestra** (varias diapositivas a la vez)

<img src="powerpoint-background.png" alt="powerpoint-background"  />

## **Establecer Color Sólido como Fondo para Diapositiva Normal**

Aspose.Slides te permite establecer un color sólido como fondo para una diapositiva específica en una presentación (incluso si esa presentación contiene una diapositiva maestra). El cambio de fondo afecta solo a la diapositiva seleccionada.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Establece el enum [BackgroundType](https://reference.aspose.com/slides/java/com.aspose.slides/backgroundtype/) para la diapositiva como `OwnBackground`.
3. Establece el enum [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) para el fondo de la diapositiva como `Solid`.
4. Usa la propiedad [SolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/#getSolidFillColor--) expuesta por [FillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/) para especificar un color sólido para el fondo.
5. Guarda la presentación modificada.

Este código Java te muestra cómo establecer un color sólido (azul) como fondo para una diapositiva normal: 

```java
// Crea una instancia de la clase Presentation
Presentation pres = new Presentation("MasterBG.pptx");
try {
    // Establece el color de fondo para la primera ISlide como Azul
    pres.getSlides().get_Item(0).getBackground().setType(BackgroundType.OwnBackground);
    pres.getSlides().get_Item(0).getBackground().getFillFormat().setFillType(FillType.Solid);
    pres.getSlides().get_Item(0).getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    
    // Escribe la presentación en disco
    pres.save("ContentBG.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Establecer Color Sólido como Fondo para Diapositiva Maestra**

Aspose.Slides te permite establecer un color sólido como fondo para la diapositiva maestra en una presentación. La diapositiva maestra actúa como una plantilla que contiene y controla las configuraciones de formato para todas las diapositivas. Por lo tanto, cuando seleccionas un color sólido como el fondo para la diapositiva maestra, ese nuevo fondo se utilizará para todas las diapositivas.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Establece el enum [BackgroundType](https://reference.aspose.com/slides/java/com.aspose.slides/backgroundtype/) para la diapositiva maestra (`Masters`) como `OwnBackground`.
3. Establece el enum [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) para el fondo de la diapositiva maestra como `Solid`.
4. Usa la propiedad [SolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/#getSolidFillColor--) expuesta por [FillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/) para especificar un color sólido para el fondo.
5. Guarda la presentación modificada.

Este código Java te muestra cómo establecer un color sólido (verde bosque) como fondo para una diapositiva maestra en una presentación:

```java
// Crea una instancia de la clase Presentation
Presentation pres = new Presentation();
try {
    // Establece el color de fondo para la Master ISlide como Verde Bosque
    pres.getMasters().get_Item(0).getBackground().setType(BackgroundType.OwnBackground);
    pres.getMasters().get_Item(0).getBackground().getFillFormat().setFillType(FillType.Solid);
    pres.getMasters().get_Item(0).getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    
    // Escribe la presentación en disco
    pres.save("MasterBG.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Establecer Color Degradado como Fondo para Diapositiva**

Un degradado es un efecto gráfico basado en un cambio gradual de color. Los colores degradados, cuando se utilizan como fondos para diapositivas, hacen que las presentaciones luzcan artísticas y profesionales. Aspose.Slides te permite establecer un color degradado como fondo para las diapositivas en presentaciones.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Establece el enum [BackgroundType](https://reference.aspose.com/slides/java/com.aspose.slides/backgroundtype/) para la diapositiva como `OwnBackground`.
3. Establece el enum [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) para el fondo de la diapositiva maestra como `Gradient`.
4. Usa la propiedad [GradientFormat](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/#getGradientFormat--) expuesta por [FillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/) para especificar tu configuración de degradado preferida.
5. Guarda la presentación modificada.

Este código Java te muestra cómo establecer un color degradado como fondo para una diapositiva:

```java
// Crea una instancia de la clase Presentation
Presentation pres = new Presentation("MasterBG.pptx");
try {
    // Aplica el efecto de Degradado al Fondo
    pres.getSlides().get_Item(0).getBackground().setType(BackgroundType.OwnBackground);
    pres.getSlides().get_Item(0).getBackground().getFillFormat().setFillType(FillType.Gradient);
    pres.getSlides().get_Item(0).getBackground().getFillFormat().getGradientFormat().setTileFlip(TileFlip.FlipBoth);
    
    // Escribe la presentación en disco
    pres.save("ContentBG_Grad.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Establecer Imagen como Fondo para Diapositiva**

Además de colores sólidos y colores degradados, Aspose.Slides también te permite establecer imágenes como el fondo para diapositivas en presentaciones.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Establece el enum [BackgroundType](https://reference.aspose.com/slides/java/com.aspose.slides/backgroundtype/) para la diapositiva como `OwnBackground`.
3. Establece el enum [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) para el fondo de la diapositiva maestra como `Picture`.
4. Carga la imagen que deseas usar como fondo de la diapositiva.
5. Agrega la imagen a la colección de imágenes de la presentación.
6. Usa la propiedad [PictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/#getPictureFillFormat--) expuesta por [FillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/) para establecer la imagen como el fondo.
7. Guarda la presentación modificada.

Este código Java te muestra cómo establecer una imagen como el fondo para una diapositiva: 

```java
// Crea una instancia de la clase Presentation
Presentation pres = new Presentation();
try {
    // Establece condiciones para la imagen de fondo
    pres.getSlides().get_Item(0).getBackground().setType(BackgroundType.OwnBackground);
    pres.getSlides().get_Item(0).getBackground().getFillFormat().setFillType(FillType.Picture);
    pres.getSlides().get_Item(0).getBackground().getFillFormat().getPictureFillFormat()
            .setPictureFillMode(PictureFillMode.Stretch);
    
    // Carga la imagen
    IPPImage imgx;
    IImage image = Images.fromFile("Desert.jpg");
    try {
        imgx = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    // Agrega la imagen a la colección de imágenes de la presentación
    pres.getSlides().get_Item(0).getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(imgx);
    
    // Escribe la presentación en disco
    pres.save("ContentBG_Img.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

### **Cambiar Transparencia de la Imagen de Fondo**

Es posible que desees ajustar la transparencia de la imagen de fondo de una diapositiva para hacer que los contenidos de la diapositiva resalten. Este código Java te muestra cómo cambiar la transparencia para una imagen de fondo de diapositiva:

```java
int transparencyValue = 30; // por ejemplo

// Obtiene una colección de operaciones de transformación de imagen
IImageTransformOperationCollection imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

// Busca un efecto de transparencia con porcentaje fijo.
AlphaModulateFixed transparenciaOperation = null;
for (IImageTransformOperation operation : imageTransform)
{
    if (operation instanceof AlphaModulateFixed)
    {
        transparenciaOperation = (AlphaModulateFixed)operation;
        break;
    }
}

// Establece el nuevo valor de transparencia.
if (transparenciaOperation == null)
{
    imageTransform.addAlphaModulateFixedEffect(100 - transparenciaValue);
}
else
{
    transparenciaOperation.setAmount(100 - transparenciaValue);
}
```

## **Obtener Valor del Fondo de Diapositiva**

Aspose.Slides proporciona la interfaz [IBackgroundEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ibackgroundeffectivedata/) para permitirte obtener los valores efectivos de los fondos de las diapositivas. Esta interfaz contiene información sobre el efectivo [FillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) y el efectivo [EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--).

Usando la propiedad [Background](https://reference.aspose.com/slides/java/com.aspose.slides/baseslide/#getBackground--) de la clase [BaseSlide](https://reference.aspose.com/slides/java/com.aspose.slides/baseslide/), puedes obtener el valor efectivo para el fondo de una diapositiva.

Este código Java te muestra cómo obtener el valor efectivo del fondo de una diapositiva:

```java
// Crea una instancia de la clase Presentation
Presentation pres = new Presentation("SamplePresentation.pptx");
try {
    IBackgroundEffectiveData effBackground = pres.getSlides().get_Item(0).getBackground().getEffective();
    
    if (effBackground.getFillFormat().getFillType() == FillType.Solid)
        System.out.println("Color de relleno: " + effBackground.getFillFormat().getSolidFillColor());
    else
        System.out.println("Tipo de relleno: " + effBackground.getFillFormat().getFillType());
} finally {
    if (pres != null) pres.dispose();
}
```