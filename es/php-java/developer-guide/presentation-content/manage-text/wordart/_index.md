---
title: Crear y aplicar efectos de WordArt en PHP
linktitle: WordArt
type: docs
weight: 110
url: /es/php-java/wordart/
keywords:
  - WordArt
  - Crear WordArt
  - Plantilla WordArt
  - Efecto WordArt
  - Efecto sombra
  - Efecto de visualización
  - Efecto resplandor
  - Transformación WordArt
  - Efecto 3D
  - Efecto de sombra externa
  - Efecto de sombra interna
  - PowerPoint
  - presentación
  - PHP
  - Aspose.Slides
description: "Crear y personalizar efectos de WordArt en Aspose.Slides para PHP a través de Java. Esta guía paso a paso ayuda a los desarrolladores a mejorar presentaciones con texto profesional."
---

## **¿Acerca de WordArt?**
WordArt o Word Art es una función que permite aplicar efectos a textos para que destaquen. Con WordArt, por ejemplo, puedes contornear un texto o rellenarlo con un color (o degradado), añadirle efectos 3D, etc. También puedes sesgar, doblar y estirar la forma de un texto.

{{% alert color="primary" %}} 
WordArt te permite tratar un texto como lo harías con un objeto gráfico. En general, WordArt consiste en efectos o modificaciones especiales aplicadas a textos para que sean más atractivos o notables. 
{{% /alert %}} 

**WordArt en Microsoft PowerPoint**

Para usar WordArt en Microsoft PowerPoint, debes seleccionar una de las plantillas predefinidas de WordArt. Una plantilla de WordArt es un conjunto de efectos que se aplican a un texto o a su forma. 

**WordArt en Aspose.Slides**

En Aspose.Slides para PHP vía Java 20.10, implementamos soporte para WordArt y mejoramos la función en versiones posteriores de Aspose.Slides para PHP vía Java.

Con Aspose.Slides para PHP vía Java, puedes crear fácilmente tu propia plantilla de WordArt (un efecto o una combinación de efectos) y aplicarla a textos.

## **Crear una plantilla de WordArt sencilla y aplicarla a texto**

**Usando Aspose.Slides** 

Primero, creamos un texto sencillo con este código PHP:
```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $autoShape->getTextFrame();
    $portion = $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Ahora, establecemos la altura de fuente del texto a un valor mayor para que el efecto sea más notable mediante este código:
```php
  $fontData = new FontData("Arial Black");
  $portion->getPortionFormat()->setLatinFont($fontData);
  $portion->getPortionFormat()->setFontHeight(36);

```


**Usando Microsoft PowerPoint**

Ve al menú de efectos de WordArt en Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

Desde el menú de la derecha, puedes elegir un efecto de WordArt predefinido. Desde el menú de la izquierda, puedes especificar los ajustes para un nuevo WordArt. 

Estos son algunos de los parámetros u opciones disponibles:

![todo:image_alt_text](image-20200930114015-3.png)

**Usando Aspose.Slides**

Aquí, aplicamos el patrón de color [SmallGrid](https://reference.aspose.com/slides/php-java/aspose.slides/PatternStyle#SmallGrid) al texto y añadimos un borde de texto negro de ancho 1 mediante este código:
```php
  $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Pattern);
  $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->ORANGE);
  $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->WHITE);
  $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle->SmallGrid);
  $portion->getPortionFormat()->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $portion->getPortionFormat()->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
```


El texto resultante:

![todo:image_alt_text](image-20200930114108-4.png)

## **Aplicar otros efectos de WordArt**

**Usando Microsoft PowerPoint**

Desde la interfaz del programa, puedes aplicar estos efectos a un texto, bloque de texto, forma o elemento similar:

![todo:image_alt_text](image-20200930114129-5.png)

Por ejemplo, los efectos Sombra, Reflexión y Resplandor pueden aplicarse a un texto; los efectos Formato 3D y Rotación 3D pueden aplicarse a un bloque de texto; la propiedad Bordes suaves puede aplicarse a un Objeto Forma (todavía tiene efecto cuando no se establece la propiedad Formato 3D). 

### **Aplicar efectos de sombra**

Aquí, pretendemos establecer las propiedades relacionadas solo con un texto. Aplicamos el efecto de sombra a un texto usando este código:
```php
  $portion->getPortionFormat()->getEffectFormat()->enableOuterShadowEffect();
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->setColor(java("java.awt.Color")->BLACK);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setScaleHorizontal(100);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setScaleVertical(65);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setBlurRadius(4.73);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setDirection(230);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setDistance(2);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setSkewHorizontal(30);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setSkewVertical(0);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->getColorTransform()->add(ColorTransformOperation->SetAlpha, 0.32);
```


La API de Aspose.Slides admite tres tipos de sombras: OuterShadow, InnerShadow y PresetShadow. 

Con PresetShadow, puedes aplicar una sombra a un texto (usando valores predefinidos). 

**Usando Microsoft PowerPoint**

En PowerPoint, solo puedes usar un tipo de sombra. Aquí tienes un ejemplo:

![todo:image_alt_text](image-20200930114225-6.png)

**Usando Aspose.Slides**

Aspose.Slides permite aplicar dos tipos de sombras a la vez: InnerShadow y PresetShadow.

**Notas:**

- Cuando se usan OuterShadow y PresetShadow juntos, solo se aplica el efecto OuterShadow. 
- Si se usan OuterShadow e InnerShadow simultáneamente, el efecto resultante o aplicado depende de la versión de PowerPoint. Por ejemplo, en PowerPoint 2013, el efecto se duplica. Pero en PowerPoint 2007, se aplica el efecto OuterShadow. 

### **Aplicar efectos de reflexión al texto**

Añadimos reflexión al texto mediante este fragmento de código:
```php
  $portion->getPortionFormat()->getEffectFormat()->enableReflectionEffect();
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setBlurRadius(0.5);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setDistance(4.72);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setStartPosAlpha(0.0);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setEndPosAlpha(60.0);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setDirection(90);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setScaleHorizontal(100);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setScaleVertical(-100);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setStartReflectionOpacity(60.0);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setEndReflectionOpacity(0.9);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setRectangleAlign(RectangleAlignment->BottomLeft);
```


### **Aplicar efectos de resplandor al texto**

Aplicamos el efecto de resplandor al texto para que brille o destaque usando este código:
```php
  $portion->getPortionFormat()->getEffectFormat()->enableGlowEffect();
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->setR(255);
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->getColorTransform()->add(ColorTransformOperation->SetAlpha, 0.54);
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->setRadius(7);
```


El resultado de la operación:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 
Puedes cambiar los parámetros de sombra, reflexión y resplandor. Las propiedades de los efectos se establecen en cada porción del texto por separado. 
{{% /alert %}} 

### **Usar transformaciones en WordArt**

Utilizamos la propiedad Transform (inherente a todo el bloque de texto) mediante este código:
```php
  $textFrame->getTextFrameFormat()->setTransform(TextShapeType::ArchUpPour);
```


El resultado:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 
Tanto Microsoft PowerPoint como Aspose.Slides para PHP vía Java ofrecen un número determinado de tipos de transformación predefinidos. 
{{% /alert %}} 

**Usando PowerPoint**

Para acceder a los tipos de transformación predefinidos, ve a: **Formato** → **Efecto de texto** → **Transformar**

**Usando Aspose.Slides**

Para seleccionar un tipo de transformación, usa el enumerado TextShapeType. 

### **Aplicar efectos 3D a texto y formas**

Establecemos un efecto 3D a una forma de texto mediante este fragmento de código:
```php
  $autoShape->getThreeDFormat()->getBevelBottom()->setBevelType(BevelPresetType::Circle);
  $autoShape->getThreeDFormat()->getBevelBottom()->setHeight(10.5);
  $autoShape->getThreeDFormat()->getBevelBottom()->setWidth(10.5);
  $autoShape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
  $autoShape->getThreeDFormat()->getBevelTop()->setHeight(12.5);
  $autoShape->getThreeDFormat()->getBevelTop()->setWidth(11);
  $autoShape->getThreeDFormat()->getExtrusionColor()->setColor(java("java.awt.Color")->ORANGE);
  $autoShape->getThreeDFormat()->setExtrusionHeight(6);
  $autoShape->getThreeDFormat()->getContourColor()->setColor(java("java.awt.Color")->RED);
  $autoShape->getThreeDFormat()->setContourWidth(1.5);
  $autoShape->getThreeDFormat()->setDepth(3);
  $autoShape->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);
  $autoShape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
  $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
  $autoShape->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);
  $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);
```


El texto y su forma resultantes:

![todo:image_alt_text](image-20200930114816-9.png)

Aplicamos un efecto 3D al texto con este código PHP:
```php
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setBevelType(BevelPresetType::Circle);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setHeight(3.5);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setWidth(3.5);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setHeight(4);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setWidth(4);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getExtrusionColor()->setColor(java("java.awt.Color")->ORANGE);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->setExtrusionHeight(6);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getContourColor()->setColor(java("java.awt.Color")->RED);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->setContourWidth(1.5);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->setDepth(3);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);
```


El resultado de la operación:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 
La aplicación de efectos 3D a textos o sus formas y las interacciones entre efectos se basan en ciertas reglas. 

Considera una escena para un texto y la forma que contiene ese texto. El efecto 3D contiene la representación del objeto 3D y la escena en la que se coloca el objeto. 

- Cuando la escena está establecida tanto para la figura como para el texto, la escena de la figura tiene mayor prioridad; la escena del texto se ignora. 
- Cuando la figura carece de su propia escena pero tiene representación 3D, se usa la escena del texto. 
- En caso contrario—cuando la forma originalmente no tiene efecto 3D—la forma es plana y el efecto 3D solo se aplica al texto. 

Estas descripciones están vinculadas a los métodos ThreeDFormat.getLightRig() y ThreeDFormat.getCamera(). 
{{% /alert %}} 

## **Aplicar efectos de sombra externa al texto**
Aspose.Slides para PHP vía Java proporciona las clases [**IOuterShadow**](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IOuterShadow) y [**IInnerShadow**](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IInnerShadow) que permiten aplicar efectos de sombra a un texto contenido en [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/classes/TextFrame). Sigue estos pasos:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation). 
2. Obtén la referencia de una diapositiva usando su índice. 
3. Añade un AutoShape de tipo Rectángulo a la diapositiva. 
4. Accede al TextFrame asociado al AutoShape. 
5. Establece el FillType del AutoShape a NoFill. 
6. Instancia la clase OuterShadow 
7. Define el BlurRadius de la sombra. 
8. Define la Direction de la sombra 
9. Define la Distance de la sombra. 
10. Establece el RectanglelAlign a TopLeft. 
11. Define el PresetColor de la sombra a Black. 
12. Guarda la presentación como un archivo [PPTX](https://docs.fileformat.com/presentation/pptx/). 

Este fragmento de código —una implementación de los pasos anteriores— muestra cómo aplicar el efecto de sombra externa a un texto:
```php
  $pres = new Presentation();
  try {
    # Obtener referencia de la diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Agregar un AutoShape de tipo Rectángulo
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # Agregar TextFrame al Rectángulo
    $ashp->addTextFrame("Aspose TextBox");
    # Desactivar el relleno de la forma en caso de que queramos obtener sombra del texto
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Agregar sombra externa y establecer todos los parámetros necesarios
    $ashp->getEffectFormat()->enableOuterShadowEffect();
    $shadow = $ashp->getEffectFormat()->getOuterShadowEffect();
    $shadow->setBlurRadius(4.0);
    $shadow->setDirection(45);
    $shadow->setDistance(3);
    $shadow->setRectangleAlign(RectangleAlignment->TopLeft);
    $shadow->getShadowColor()->setPresetColor(PresetColor->Black);
    # Guardar la presentación en disco
    $pres->save("pres_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Aplicar efectos de sombra interna a formas**
Sigue estos pasos:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation). 
2. Obtén la referencia de la diapositiva. 
3. Añade un AutoShape de tipo Rectángulo. 
4. Habilita InnerShadowEffect. 
5. Define todos los parámetros necesarios. 
6. Establece el ColorType como Scheme. 
7. Define el Scheme Color. 
8. Guarda la presentación como un archivo [PPTX](https://docs.fileformat.com/presentation/pptx/). 

Este fragmento de código (basado en los pasos anteriores) muestra cómo añadir un conector entre dos formas:
```php
  $pres = new Presentation();
  try {
    # Obtener referencia de la diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Agregar un AutoShape de tipo Rectángulo
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 400, 300);
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Agregar TextFrame al Rectángulo
    $ashp->addTextFrame("Aspose TextBox");
    $port = $ashp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $pf = $port->getPortionFormat();
    $pf->setFontHeight(50);
    # Habilitar InnerShadowEffect
    $ef = $pf->getEffectFormat();
    $ef->enableInnerShadowEffect();
    # Establecer todos los parámetros necesarios
    $ef->getInnerShadowEffect()->setBlurRadius(8.0);
    $ef->getInnerShadowEffect()->setDirection(90.0);
    $ef->getInnerShadowEffect()->setDistance(6.0);
    $ef->getInnerShadowEffect()->getShadowColor()->setB(189);
    # Establecer ColorType como Scheme
    $ef->getInnerShadowEffect()->getShadowColor()->setColorType(ColorType::Scheme);
    # Establecer Scheme Color
    $ef->getInnerShadowEffect()->getShadowColor()->setSchemeColor(SchemeColor->Accent1);
    # Guardar Presentación
    $pres->save("WordArt_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Preguntas frecuentes**

**¿Puedo usar los efectos de WordArt con diferentes fuentes o scripts (p. ej., árabe, chino)?**

Sí, Aspose.Slides admite Unicode y funciona con todas las fuentes y scripts principales. Los efectos de WordArt como sombra, relleno y contorno pueden aplicarse sin importar el idioma, aunque la disponibilidad de la fuente y el renderizado pueden depender de las fuentes del sistema.

**¿Puedo aplicar los efectos de WordArt a elementos del patrón de diapositivas?**

Sí, puedes aplicar los efectos de WordArt a formas en las diapositivas maestras, incluyendo marcadores de posición de título, pies de página o texto de fondo. Los cambios realizados en el diseño maestro se reflejarán en todas las diapositivas asociadas.

**¿Los efectos de WordArt afectan al tamaño del archivo de la presentación?**

Un poco. Los efectos de WordArt como sombras, resplandores y rellenos degradados pueden incrementar ligeramente el tamaño del archivo debido a los metadatos de formato añadidos, pero la diferencia suele ser insignificante.

**¿Puedo previsualizar el resultado de los efectos de WordArt sin guardar la presentación?**

Sí, puedes renderizar diapositivas que contengan WordArt a imágenes (p. ej., PNG, JPEG) usando el método `getImage` de las interfaces [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) o [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/). Esto te permite previsualizar el resultado en memoria o en pantalla antes de guardar o exportar la presentación completa.