---
title: Crear y aplicar efectos de WordArt en PHP
linktitle: WordArt
type: docs
weight: 110
url: /es/php-java/wordart/
keywords:
- WordArt
- crear WordArt
- plantilla WordArt
- efecto WordArt
- efecto sombra
- efecto visualización
- efecto resplandor
- transformación WordArt
- efecto 3D
- efecto de sombra externa
- efecto de sombra interna
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Cree y personalice efectos de WordArt en Aspose.Slides para PHP a través de Java. Esta guía paso a paso ayuda a los desarrolladores a mejorar presentaciones con texto profesional."
---

## **¿Qué es WordArt?**
WordArt o Word Art es una característica que permite aplicar efectos a los textos para que destaquen. Con WordArt, por ejemplo, puedes contornear un texto o rellenarlo con un color (o degradado), añadirle efectos 3D, etc. También puedes sesgar, doblar y estirar la forma de un texto. 

{{% alert color="primary" %}} 
WordArt le permite tratar un texto como lo haría con un objeto gráfico. En general, WordArt consiste en efectos o modificaciones especiales aplicadas a los textos para que sean más atractivos o llamativos. 
{{% /alert %}} 

**WordArt en Microsoft PowerPoint**

Para usar WordArt en Microsoft PowerPoint, debes seleccionar una de las plantillas de WordArt predefinidas. Una plantilla de WordArt es un conjunto de efectos que se aplican a un texto o a su forma. 

**WordArt en Aspose.Slides**

En Aspose.Slides for PHP via Java 20.10, implementamos soporte para WordArt y realizamos mejoras en la característica en versiones posteriores de Aspose.Slides for PHP via Java. 

Con Aspose.Slides for PHP via Java, puedes crear fácilmente tu propia plantilla de WordArt (un efecto o una combinación de efectos) y aplicarla a los textos.

## **Crear una plantilla simple de WordArt y aplicarla al texto**

**Usando Aspose.Slides** 

Primero, creamos un texto simple usando este código PHP:
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

Ahora, establecemos la altura de la fuente del texto a un valor mayor para que el efecto sea más visible mediante este código:
```php
  $fontData = new FontData("Arial Black");
  $portion->getPortionFormat()->setLatinFont($fontData);
  $portion->getPortionFormat()->setFontHeight(36);

```


**Usando Microsoft PowerPoint**

Accede al menú de efectos de WordArt en Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

En el menú de la derecha, puedes elegir un efecto de WordArt predefinido. En el menú de la izquierda, puedes especificar la configuración para un nuevo WordArt. 

Estos son algunos de los parámetros u opciones disponibles:

![todo:image_alt_text](image-20200930114015-3.png)

**Usando Aspose.Slides**

Aquí, aplicamos el color de patrón [SmallGrid](https://reference.aspose.com/slides/php-java/aspose.slides/patternstyle/#SmallGrid) al texto y añadimos un borde negro de ancho 1 al texto mediante este código:
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

Por ejemplo, los efectos Sombra, Reflejo y Resplandor pueden aplicarse a un texto; los efectos Formato 3D y Rotación 3D pueden aplicarse a un bloque de texto; la propiedad Bordes suaves puede aplicarse a un Objeto Forma (sigue teniendo efecto cuando no se establece la propiedad Formato 3D). 

### **Aplicar efectos de sombra**

Aquí, pretendemos establecer solo las propiedades relacionadas con un texto. Aplicamos el efecto de sombra a un texto usando este código :
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

En PowerPoint, puedes usar un tipo de sombra. Aquí tienes un ejemplo:

![todo:image_alt_text](image-20200930114225-6.png)

**Usando Aspose.Slides**

Aspose.Slides realmente permite aplicar dos tipos de sombras a la vez: InnerShadow y PresetShadow.

**Notas:**

- Cuando se utilizan OuterShadow y PresetShadow juntos, solo se aplica el efecto OuterShadow. 
- Si OuterShadow e InnerShadow se usan simultáneamente, el efecto resultante o aplicado depende de la versión de PowerPoint. Por ejemplo, en PowerPoint 2013 el efecto se duplica. Pero en PowerPoint 2007 se aplica el efecto OuterShadow. 

### **Aplicar efectos de reflejo al texto**

Añadimos reflejo al texto mediante este ejemplo de código :
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
Puedes cambiar los parámetros de sombra, reflejo y resplandor. Las propiedades de los efectos se establecen por separado en cada porción del texto. 
{{% /alert %}} 

### **Usar transformaciones en WordArt**

Utilizamos la propiedad Transform (heredada en todo el bloque de texto) mediante este código:
```php
  $textFrame->getTextFrameFormat()->setTransform(TextShapeType::ArchUpPour);
```


El resultado:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 
Tanto Microsoft PowerPoint como Aspose.Slides for PHP via Java ofrecen una serie de tipos de transformación predefinidos.
{{% /alert %}} 

**Usando PowerPoint**

Para acceder a los tipos de transformación predefinidos, ve a: **Formato** -> **Efecto de texto** -> **Transformar**

**Usando Aspose.Slides**

Para seleccionar un tipo de transformación, usa el enum TextShapeType. 

### **Aplicar efectos 3D al texto y a las formas**

Establecemos un efecto 3D a una forma de texto usando este código de ejemplo:
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


El texto resultante y su forma:

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
La aplicación de efectos 3D a los textos o sus formas y las interacciones entre efectos se basan en ciertas reglas. 

Considera una escena para un texto y la forma que contiene ese texto. El efecto 3D contiene la representación del objeto 3D y la escena en la que se coloca el objeto. 

- Cuando la escena está establecida tanto para la figura como para el texto, la escena de la figura tiene mayor prioridad y la escena del texto se ignora. 
- Cuando la figura no tiene su propia escena pero tiene representación 3D, se utiliza la escena del texto. 
- En caso contrario, cuando la forma originalmente no tiene efecto 3D, la forma es plana y el efecto 3D solo se aplica al texto. 

Estas descripciones están relacionadas con los métodos ThreeDFormat.getLightRig() y ThreeDFormat.getCamera(). 
{{% /alert %}} 

## **Aplicar efectos de sombra externa al texto**
Aspose.Slides for PHP via Java proporciona las clases [OuterShadow](https://reference.aspose.com/slides/php-java/aspose.slides/outershadow/) y [InnerShadow](https://reference.aspose.com/slides/php-java/aspose.slides/innershadow/) que permiten aplicar efectos de sombra a un texto contenido en un [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/). Sigue estos pasos:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Obtener la referencia de una diapositiva mediante su índice.
3. Agregar una AutoShape de tipo Rectángulo a la diapositiva.
4. Acceder al TextFrame asociado a la AutoShape.
5. Establecer la propiedad FillType de la AutoShape a NoFill.
6. Instanciar la clase OuterShadow.
7. Establecer el BlurRadius de la sombra.
8. Establecer la Direction de la sombra.
9. Establecer la Distance de la sombra.
10. Establecer RectanglelAlign a TopLeft.
11. Establecer PresetColor de la sombra a Black.
12. Guardar la presentación como archivo [PPTX](https://docs.fileformat.com/presentation/pptx/) .

Este código de ejemplo —una implementación de los pasos anteriores— muestra cómo aplicar el efecto de sombra externa a un texto:
```php
  $pres = new Presentation();
  try {
    # Obtener referencia de la diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Agregar una AutoShape de tipo Rectángulo
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # Agregar TextFrame al rectángulo
    $ashp->addTextFrame("Aspose TextBox");
    # Desactivar el relleno de la forma en caso de que queramos obtener la sombra del texto
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


## **Aplicar efectos de sombra interna a las formas**
Sigue estos pasos:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Obtener una referencia de la diapositiva.
3. Agregar una AutoShape del tipo Rectangle.
4. Habilitar InnerShadowEffect.
5. Establecer todos los parámetros necesarios.
6. Establecer ColorType como Scheme.
7. Establecer Scheme Color.
8. Guardar la presentación como archivo [PPTX](https://docs.fileformat.com/presentation/pptx/) .

Este código de ejemplo (basado en los pasos anteriores) muestra cómo añadir un conector entre dos formas :
```php
  $pres = new Presentation();
  try {
    # Obtener referencia de la diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Agregar una AutoShape de tipo Rectángulo
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
    # Guardar la presentación
    $pres->save("WordArt_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**¿Puedo usar efectos de WordArt con diferentes fuentes o escrituras (p. ej., árabe, chino)?**

Sí, Aspose.Slides admite Unicode y funciona con todas las fuentes y escrituras principales. Los efectos de WordArt, como sombra, relleno y contorno, pueden aplicarse indepdientemente del idioma, aunque la disponibilidad de fuentes y el renderizado pueden depender de las fuentes del sistema.

**¿Puedo aplicar efectos de WordArt a los elementos de la diapositiva maestra?**

Sí, puedes aplicar efectos de WordArt a las formas en las diapositivas maestras, incluidos los marcadores de posición de título, pies de página o texto de fondo. Los cambios realizados en el diseño maestro se reflejarán en todas las diapositivas asociadas.

**¿Los efectos de WordArt afectan al tamaño del archivo de la presentación?**

Un poco. Los efectos de WordArt como sombras, resplandores y rellenos degradados pueden aumentar ligeramente el tamaño del archivo debido a los metadatos de formato añadidos, pero la diferencia suele ser insignificante.

**¿Puedo previsualizar el resultado de los efectos de WordArt sin guardar la presentación?**

Sí, puedes renderizar diapositivas que contengan WordArt a imágenes (p. ej., PNG, JPEG) usando el método `getImage` de las clases [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) o [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/). Esto te permite previsualizar el resultado en memoria o en pantalla antes de guardar o exportar la presentación completa.