---
title: "Mejora las presentaciones de PowerPoint con animaciones en PHP"
linktitle: "Animación de PowerPoint"
type: docs
weight: 150
url: /es/php-java/powerpoint-animation/
keywords:
- añadir animación
- actualizar animación
- cambiar animación
- eliminar animación
- gestionar animación
- controlar animación
- efecto de animación
- animación de PowerPoint
- línea de tiempo de animación
- animación interactiva
- animación personalizada
- animación de formas
- gráfico animado
- texto animado
- forma animada
- objeto OLE animado
- imagen animada
- tabla animada
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Explore las capacidades de Aspose.Slides para PHP mediante Java en la gestión de animaciones de PowerPoint. Características clave y perspectivas para mejorar sus presentaciones."
---
## **Introducción**

Dado que las presentaciones están diseñadas para presentar algo, su aspecto visual y comportamiento interactivo siempre se tienen en cuenta durante su creación.

**PowerPoint animation** desempeña un papel importante para que una presentación resulte llamativa y atractiva para los espectadores. Aspose.Slides para PHP mediante Java ofrece una amplia gama de opciones para añadir animaciones a presentaciones de PowerPoint:

- Aplicar varios tipos de efectos de animación de PowerPoint a formas, gráficos, tablas, objetos OLE y otros elementos de la presentación.  
- Utilizar múltiples efectos de animación de PowerPoint en una misma forma.  
- Aprovechar la línea de tiempo de animación para controlar los efectos de animación.  
- Crear animaciones personalizadas.

En Aspose.Slides para PHP mediante Java, se pueden aplicar diversos efectos de animación a las formas. Dado que cada elemento en una diapositiva, incluido texto, imágenes, objetos OLE y tablas, se considera una forma, los efectos de animación pueden aplicarse a cualquier elemento de la diapositiva.

## **Efectos de animación**
Aspose.Slides soporta **más de 150 efectos de animación**, incluidos efectos básicos como Bounce, PathFootball y Zoom, y efectos específicos como OLEObjectShow y OLEObjectOpen. Puede encontrar una lista completa en la clase [EffectType](https://reference.aspose.com/slides/es/php-java/aspose.slides/effecttype/).

Además, estos efectos de animación pueden usarse en combinación con los siguientes comportamientos:

- [ColorEffect](https://reference.aspose.com/slides/es/php-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/es/php-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/es/php-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/es/php-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/es/php-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/es/php-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/es/php-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/es/php-java/aspose.slides/SetEffect)

## **Animación personalizada**

Para ejemplos completos en PHP que crean, inspeccionan y modifican comportamientos y rutas de movimiento editables, consulte [Animación personalizada](/slides/es/php-java/custom-animation/).

Es posible crear sus propias **animaciones personalizadas** en Aspose.Slides. Esto se puede lograr combinando varios comportamientos en una nueva animación personalizada.

[Behavior](https://reference.aspose.com/slides/es/php-java/aspose.slides/behavior/) es un bloque de construcción de un efecto de animación de PowerPoint. Combine comportamientos para personalizar un efecto, o añada un comportamiento para ampliar un efecto predefinido. La repetición se configura mediante la configuración de temporización y no mediante un comportamiento de repetición separado.

[Animation Point](https://reference.aspose.com/slides/es/php-java/aspose.slides/point/) es un punto en el que debe aplicarse un comportamiento.

## **Línea de tiempo de animación**
[Sequence](https://reference.aspose.com/slides/es/php-java/aspose.slides/sequence/) es una colección de efectos de animación que pueden dirigirse a diferentes formas.

[Timeline](https://reference.aspose.com/slides/es/php-java/aspose.slides/animationtimeline/) es un conjunto de secuencias usadas en una diapositiva específica. Es un motor de animación introducido en PowerPoint 2002. En versiones anteriores de PowerPoint, añadir efectos de animación a las presentaciones era difícil y solo se lograba mediante diversas soluciones alternativas. La línea de tiempo ofrece un modelo de objetos más claro para las animaciones de PowerPoint. Una diapositiva solo puede tener una línea de tiempo de animación.

## **Animación interactiva**
[Trigger](https://reference.aspose.com/slides/es/php-java/aspose.slides/effecttriggertype/) permite definir acciones del usuario, como hacer clic en un botón, que inician una animación concreta.

## **Animación de formas**
Aspose.Slides permite aplicar animaciones a formas, que pueden incluir texto, rectángulos, líneas, marcos, objetos OLE y más.

{{% alert color="info" title="Note" %}}
Leer más [**Acerca de la animación de formas**](/slides/es/php-java/shape-animation/).
{{% /alert %}}

## **Gráficos animados**
Para crear gráficos animados, debe usar las mismas clases que para las formas. Sin embargo, las animaciones de PowerPoint solo pueden aplicarse a categorías de gráfico o series de gráfico. También puede aplicar efectos de animación a un elemento de categoría o a un elemento de serie.

{{% alert color="info" title="Note" %}}
Leer más [**Acerca de los gráficos animados**](/slides/es/php-java/animated-charts/).
{{% /alert %}}

## **Texto animado**
Además de animar texto, puede aplicar animación a un párrafo.

{{% alert color="info" title="Note" %}}
Leer más [**Acerca del texto animado**](/slides/es/php-java/animated-text/).
{{% /alert %}}

## **Preguntas frecuentes**

**¿Se conservarán las animaciones al exportar a PDF?**

No. PDF es un formato estático, por lo que las animaciones y las [slide transitions](/slides/es/php-java/slide-transition/) no se reproducen. Si necesita movimiento, exporte a [HTML5](/slides/es/php-java/export-to-html5/), [GIF animado](/slides/es/php-java/convert-powerpoint-to-animated-gif/) o [vídeo](/slides/es/php-java/convert-powerpoint-to-video/) en su lugar.

**¿Puedo convertir una presentación animada en un vídeo y controlar la velocidad de fotogramas y el tamaño del cuadro?**

Sí. Puede [renderizar la presentación como fotogramas](/slides/es/php-java/convert-powerpoint-to-video/) y codificarlos en un vídeo (por ejemplo, con ffmpeg), eligiendo los FPS y la resolución. Las animaciones y las transiciones de diapositiva se reproducen durante el renderizado.

**¿Las animaciones seguirán intactas al trabajar con ODP (no solo PPTX)?**

PPT, PPTX y ODP son compatibles para [leer](/slides/es/php-java/open-presentation/) y [escribir](/slides/es/php-java/save-presentation/), pero esto no garantiza la preservación de las animaciones. Los datos de animación personalizada pueden perderse al convertir a ODP. Consulte [Animación personalizada](/slides/es/php-java/custom-animation/) para ejemplos y orientaciones sobre la compatibilidad de formatos.