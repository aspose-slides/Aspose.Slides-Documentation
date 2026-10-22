---
title: Personalizar formas de presentación en JavaScript
linktitle: Forma personalizada
type: docs
weight: 20
url: /es/nodejs-java/custom-shape/
keywords:
- forma personalizada
- agregar forma
- crear forma
- cambiar forma
- geometría de forma
- ruta de geometría
- puntos de ruta
- puntos de edición
- agregar punto
- eliminar punto
- operación de edición
- esquina curva
- PowerPoint
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Crear y personalizar formas en presentaciones de PowerPoint con JavaScript y Aspose.Slides para Node.js: rutas de geometría, esquinas curvas, formas compuestas."
---
## **Descripción general**

Este artículo explica cómo personalizar las formas de una presentación en Aspose.Slides editando la geometría de las formas mediante puntos de edición y rutas de geometría. Muestra cómo trabajar con [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) para modificar formas existentes, realizar operaciones básicas de edición de rutas, agregar o eliminar puntos y aplicar la geometría actualizada de nuevo a una forma.

También demuestra cómo crear formas personalizadas y compuestas, construir formas con esquinas curvas, determinar si la geometría de una forma está cerrada, inspeccionar los elementos de la forma y convertir los contornos de texto de Java AWT en rutas de geometría.

## **Cambiar una forma usando puntos de edición**

En PowerPoint, puede usar **Edit Points** para modificar un cuadrado:

* Mover una esquina hacia adentro o hacia afuera.
* Ajustar la curvatura en un punto.
* Añadir nuevos puntos.

Editar puntos le permite modificar el contorno de una forma o utilizar una forma existente como base para una nueva.

## **Consejos para editar formas**

![overview_image](custom_shape_0.png)

Al editar formas en PowerPoint, tenga en cuenta estos conceptos:

* Una forma (o su ruta) puede estar cerrada o abierta.
* La ruta de una forma está compuesta por puntos de anclaje conectados por segmentos.
* Un segmento puede ser recto o curvo. Los puntos de anclaje y los manejadores de control determinan su forma.
* Los puntos de anclaje pueden ser puntos de esquina, puntos rectos o puntos suaves:
  * En un punto de esquina, los segmentos adyacentes pueden encontrarse en un ángulo.
  * En un punto suave, los dos manejadores de control están alineados y a la misma distancia del punto de anclaje.
  * En un punto recto, los dos manejadores de control están alineados pero pueden estar a diferentes distancias del punto de anclaje.
* Mover los puntos de anclaje o ajustar sus manejadores cambia el contorno de la forma.

Para editar formas de PowerPoint mediante puntos de edición, **Aspose.Slides** proporciona la clase [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/).

* Una instancia de [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) representa una ruta de geometría del objeto [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/).
* Para obtener el [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) del instancia de [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/) puede usar el método [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths).
* Para establecer el [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) de una forma, puede usar estos métodos: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) para formas con una única ruta y [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) para formas con varias rutas.
* Para añadir segmentos, puede usar los métodos bajo [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/).
* Usando los métodos [GeometryPath.setStroke](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setStroke) y [GeometryPath.setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setFillMode), puede establecer la apariencia de una ruta de geometría.
* Usando el método [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData), puede obtener la ruta de geometría de un [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/) como una matriz de segmentos de ruta.
* Para acceder a opciones adicionales de personalización de la geometría de la forma, puede leer un [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) a través de su [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) y reproducir los segmentos en un [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/).

## **Operaciones de edición simples**

Use los siguientes métodos para editar una ruta de geometría. Las sobrecargas que aceptan un índice insertan un segmento en esa posición basada en cero en la matriz de segmentos de la ruta.

| Operación | Método |
| --- | --- |
| Añadir o insertar una línea recta. | [GeometryPath.lineTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#lineTo) |
| Añadir o insertar una curva Bézier cúbica con dos puntos de control y un punto final. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#cubicBezierTo) |
| Añadir o insertar una curva Bézier cuadrática con un punto de control y un punto final. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| Añadir un arco elíptico con las dimensiones y ángulos especificados en grados. | [GeometryPath.arcTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#arcTo) |
| Cerrar la figura actual conectando su punto final con su punto inicial. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#closeFigure) |
| Establecer el punto inicial de una figura. | [GeometryPath.moveTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#moveTo) |
| Eliminar un segmento en un índice basado en cero. | [GeometryPath.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#removeAt) |

## **Agregar puntos personalizados a una forma**

Este ejemplo inserta dos puntos en una forma rectangular usando [GeometryPath.lineTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#lineTo) y aplica la ruta editada con [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath). Las coordenadas son locales a la forma: ambos puntos nuevos están en su centro, a 100 puntos del borde izquierdo y 50 puntos del borde superior. Los índices de segmento 1 y 4 los sitúan en los bordes superior e inferior, tirando esos bordes hacia adentro.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 200, 100);

    const geometryPath = shape.getGeometryPaths()[0];
    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);

    shape.setGeometryPath(geometryPath);
} finally {
    presentation.dispose();
}
```

![example1_image](custom_shape_1.png)

## **Eliminar puntos de una forma**

Este ejemplo modifica el contorno de una forma en forma de corazón eliminando el segmento en el índice basado en cero 2 con [GeometryPath.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#removeAt). Aplicar la ruta modificada con [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) actualiza el contorno de la forma.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Heart, 100, 100, 300, 300);

    const path = shape.getGeometryPaths()[0];
    path.removeAt(2);

    shape.setGeometryPath(path);
} finally {
    presentation.dispose();
}
```
![example2_image](custom_shape_2.png)

## **Crear una forma personalizada**

Este ejemplo construye una estrella de cinco puntas con [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/). Los radios exteriores e interiores alternados de 100 y 50 puntos definen las puntas y las hendiduras; un paso de 72 grados separa uniformemente las cinco puntas. La ruta se cierra con [GeometryPath.closeFigure](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#closeFigure) y se aplica a una forma rectangular usando [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath), sustituyendo su contorno.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const points = [];
const outerRadius = 100;
const innerRadius = 50;
const angleStep = 72;

for (let angle = -90; angle < 270; angle += angleStep) {
    let radians = angle * Math.PI / 180;
    points.push({ x: outerRadius * Math.cos(radians) + outerRadius, y: outerRadius * Math.sin(radians) + outerRadius });
    radians = (angle + angleStep / 2) * Math.PI / 180;
    points.push({ x: innerRadius * Math.cos(radians) + outerRadius, y: innerRadius * Math.sin(radians) + outerRadius });
}

const starPath = new slides.GeometryPath();
starPath.moveTo(java.newFloat(points[0].x), java.newFloat(points[0].y));
for (let i = 1; i < points.length; i++) {
    starPath.lineTo(java.newFloat(points[i].x), java.newFloat(points[i].y));
}
starPath.closeFigure();

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, outerRadius * 2, outerRadius * 2);
    shape.setGeometryPath(starPath);
} finally {
    presentation.dispose();
}
```
![example3_image](custom_shape_3.png)

## **Crear una forma personalizada compuesta**

Este ejemplo define dos objetos [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) cerrados para el tercio superior e inferior de una forma. Aplicar ambas rutas con [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) crea una única forma compuesta con una abertura en su tercio medio.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 200, 100);

    const topPath = new slides.GeometryPath();
    topPath.moveTo(0, 0);
    topPath.lineTo(shape.getWidth(), 0);
    topPath.lineTo(shape.getWidth(), java.newFloat(shape.getHeight() / 3));
    topPath.lineTo(0, java.newFloat(shape.getHeight() / 3));
    topPath.closeFigure();

    const bottomPath = new slides.GeometryPath();
    bottomPath.moveTo(0, java.newFloat(shape.getHeight() / 3 * 2));
    bottomPath.lineTo(shape.getWidth(), java.newFloat(shape.getHeight() / 3 * 2));
    bottomPath.lineTo(shape.getWidth(), shape.getHeight());
    bottomPath.lineTo(0, shape.getHeight());
    bottomPath.closeFigure();

    const paths = java.newArray("com.aspose.slides.GeometryPath", [topPath, bottomPath]);
    shape.setGeometryPaths(paths);
} finally {
    presentation.dispose();
}
```
![example4_image](custom_shape_4.png)

## **Crear una forma personalizada con esquinas curvas**

Este ejemplo combina segmentos rectos con [GeometryPath.arcTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#arcTo) para crear una forma con esquinas curvadas hacia adentro. Cada tamaño de esquina establece el ancho y la altura del arco en puntos, y el barrido de -90 grados dibuja un cuarto de elipse en sentido antihorario. La ruta completada se aplica con [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath), y la presentación se guarda en formato PPTX.

```javascript
const slides = require("aspose.slides.via.java");

const shapeX = 20;
const shapeY = 20;
const shapeWidth = 300;
const shapeHeight = 200;

const leftTopSize = 50;
const rightTopSize = 20;
const rightBottomSize = 40;
const leftBottomSize = 10;

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    const geometryPath = new slides.GeometryPath();
    geometryPath.moveTo(leftTopSize, 0);
    geometryPath.lineTo(shapeWidth - rightTopSize, 0);
    geometryPath.arcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.lineTo(shapeWidth, shapeHeight - rightBottomSize);
    geometryPath.arcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.lineTo(leftBottomSize, shapeHeight);
    geometryPath.arcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.lineTo(0, leftTopSize);
    geometryPath.arcTo(leftTopSize, leftTopSize, 90, -90);
    geometryPath.closeFigure();

    shape.setGeometryPath(geometryPath);

    presentation.save("output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Descubrir si la geometría de una forma está cerrada**

El siguiente asistente comprueba si cada ruta de geometría no vacía termina con un segmento de cierre. Lee [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData) y compara el comando del segmento final [PathSegment.getPathCommand](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathsegment/#getPathCommand) con [PathCommandType.Close](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathcommandtype/). Devuelve false cuando no hay rutas no vacías. Esto verifica el comando final de cada ruta; no inspecciona cada subfigura dentro de una ruta. El ejemplo muestra `true` para un rectángulo.

```javascript
const slides = require("aspose.slides.via.java");

function isGeometryClosed(geometryShape) {
    let hasNonemptyPath = false;
    for (const geometryPath of geometryShape.getGeometryPaths()) {
        const segments = geometryPath.getPathData();
        if (segments.length === 0) {
            continue;
        }
        hasNonemptyPath = true;
        const lastSegment = segments[segments.length - 1];
        if (lastSegment.getPathCommand() !== slides.PathCommandType.Close) {
            return false;
        }
    }
    return hasNonemptyPath;
}

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 200, 100);

    const closed = isGeometryClosed(shape);
    console.log(closed);
} finally {
    presentation.dispose();
}
```

## **Extraer e inspeccionar elementos de forma**

Utilice [GeometryShape.createShapeElements](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#createShapeElements) para inspeccionar una forma existente como elementos que contienen puntos de ruta y tipos de punto. Use cada [ShapeElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/) devuelto para obtener las matrices de puntos y tipos mediante los métodos [getPathPoints](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/#getPathPoints) y [getPathTypes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/#getPathTypes). Esta representación es útil para el análisis de contornos o para pasar la geometría a herramientas de dibujo personalizadas.

El ejemplo abre input.pptx, encuentra la primera forma de geometría directamente en la primera diapositiva y muestra sus segmentos de ruta. Use una presentación que contenga una forma con segmentos rectos y curvos para ver ambos tipos de salida. No busca dentro de grupos.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    let shape = null;
    for (let index = 0; index < slide.getShapes().size(); index++) {
        const candidate = slide.getShapes().get_Item(index);
        if (java.instanceOf(candidate, "com.aspose.slides.GeometryShape")) {
            shape = candidate;
            break;
        }
    }

    if (shape == null) {
        console.log("No geometry shape found on the first slide.");
    } else {
        for (const shapeElement of shape.createShapeElements()) {
            const points = shapeElement.getPathPoints();
            const types = shapeElement.getPathTypes();
            console.log("Shape element:");

            for (let i = 0; i < points.length; i++) {
                const pointType = types[i] & 0x07; // Mantener el tipo de segmento, excluyendo banderas.
                switch (pointType) {
                    case 0:
                        console.log("Start figure at " + points[i]);
                        break;
                    case 1:
                        console.log("Line to " + points[i]);
                        break;
                    case 3:
                        console.log("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // Consumir ambos puntos de control y el punto final.
                        break;
                }

                if ((types[i] & 0x80) != 0) {
                    console.log("Close subpath back to its starting point.");
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Las matrices corresponden por índice: `points[i]` es un punto y `types[i]` describe su función. El tipo `0` inicia una figura, y el tipo `1` dibuja una línea desde el punto anterior al punto actual. Un segmento Bézier cúbico comienza en el punto final anterior y usa tres entradas consecutivas de tipo `3`: dos puntos de control seguidos del nuevo punto final. El bucle consume estas tres entradas juntas y verifica el punto final para el cierre.

Los tipos de punto también contienen indicadores. Enmascare con `0x07` para identificar el tipo de segmento, y pruebe `0x80` por separado para detectar una subruta cerrada. Por ejemplo, `129` (`0x81`) significa un punto final de línea que cierra una subruta, y `131` (`0x83`) significa un punto final Bézier que cierra una. Java almacena estos indicadores en bytes con signo; el enmascarado conserva los valores de bits previstos. Comparar el valor bruto solo con `1` o `3` pasaría por alto estos casos. Otros indicadores, como guión (`0x10`) y marcador (`0x20`), no cambian el tipo de segmento base.

**Coordenadas y transformaciones.** Los puntos se miden en puntos (1/72 de pulgada), con X incrementando hacia la derecha e Y incrementando hacia abajo. Para una forma sin agrupar, las coordenadas extraídas ya incluyen la posición devuelta por [getX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getX) y [getY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getY) y reflejan su ancho y alto actuales. Por ejemplo, un rectángulo sin rotar en `(100, 200)` con tamaño `120 × 80` tiene límites de contorno `(100, 200)`–`(220, 280)`. No añada de nuevo la posición de la forma. Reste su X e Y para obtener coordenadas relativas a su marco sin rotar.

Los puntos extraídos no aplican la rotación de la forma, devuelta por [getRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getRotation), ni los giros horizontales y verticales. Para reproducir el contorno mostrado, aplique esas transformaciones alrededor del centro de la forma. Para formas agrupadas, también tenga en cuenta el mapeo de coordenadas del grupo y sus transformaciones; no asuma que los puntos extraídos son las coordenadas finales renderizadas de la diapositiva ni aplique una traslación o escala dos veces si ya está reflejada en el marco del hijo.

**Inspección versus edición.** Las matrices extraídas describen el contorno; cambiarlas no actualiza la forma original. Elija este enfoque cuando su análisis o código de dibujo necesite matrices de punto/tipo. Use [getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths) cuando necesite comandos de geometría en el sistema de coordenadas local de la forma o quiera editar su geometría. Aplique rutas editadas mediante [setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) o [setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths).

## **Convertir una forma Java AWT a GeometryPath**

Este ejemplo combina un contorno rectangular con texto convertido a geometría. El método [setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setFillMode) del contorno desactiva su relleno. Un [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) crea el contorno del texto en un [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). Su [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) suministra segmentos de mover, línea, cuadrático, cúbico y cierre, que el ejemplo reproduce en un [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/).

El puente Java utiliza valores explícitos de float y byte para los parámetros Java correspondientes. El iterador escribe coordenadas en una matriz float de Java; la reflexión lee sus valores actualizados de vuelta a JavaScript. El texto usa una fuente Arial de 40 puntos. El contorno se desplaza 20 puntos horizontalmente y se posiciona con su parte superior visual 10 puntos por debajo del borde superior de la forma. La ruta del texto se rellena, mientras que el rectángulo original permanece como contorno. Aplicar ambas rutas con [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) produce una única forma que contiene el rectángulo y el texto.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 300, 100);
    
    const originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(java.newByte(slides.PathFillModeType.None));

    const font = java.newInstanceSync("java.awt.Font", "Arial", java.getStaticFieldValue("java.awt.Font", "PLAIN"), 40);
    const image = java.newInstanceSync("java.awt.image.BufferedImage", 100, 100, java.getStaticFieldValue("java.awt.image.BufferedImage", "TYPE_INT_ARGB"));
    const graphics = image.createGraphics();
    let graphicsPath;
    try {
        const fontContext = graphics.getFontRenderContext();
        const glyphVector = font.createGlyphVector(fontContext, "Text in shape");
        const textBounds = glyphVector.getVisualBounds();
        const baseline = java.newFloat(-textBounds.getY() + 10);
        graphicsPath = glyphVector.getOutline(java.newFloat(20), baseline);
    } finally {
        graphics.dispose();
    }

    const textPath = new slides.GeometryPath();
    const pathIterator = graphicsPath.getPathIterator(null);
    const coordinates = java.newArray("float", [0, 0, 0, 0, 0, 0]);

    while (!pathIterator.isDone()) {
        const segmentType = pathIterator.currentSegment(coordinates);
        const points = [];
        for (let i = 0; i < 6; i++) {
            const coordinate = java.callStaticMethodSync("java.lang.reflect.Array", "getFloat", coordinates, i);
            points.push(java.newFloat(coordinate));
        }
        switch (segmentType) {
            case 0: // Mover a.
                textPath.moveTo(points[0], points[1]);
                break;
            case 1: // Línea a.
                textPath.lineTo(points[0], points[1]);
                break;
            case 2: // Curva Bezier cuadrática.
                textPath.quadraticBezierTo(points[0], points[1], points[2], points[3]);
                break;
            case 3: // Curva Bezier cúbica.
                textPath.cubicBezierTo(points[0], points[1], points[2], points[3], points[4], points[5]);
                break;
            case 4: // Cerrar figura.
                textPath.closeFigure();
                break;
        }
        pathIterator.next();
    }
    textPath.setFillMode(java.newByte(slides.PathFillModeType.Normal));
    const paths = java.newArray("com.aspose.slides.GeometryPath", [originalPath, textPath]);
    shape.setGeometryPaths(paths);
} finally {
    presentation.dispose();
}
```
![example5_image](custom_shape_5.png)

## **Preguntas frecuentes**

**¿Qué ocurrirá con el relleno y el contorno después de reemplazar la geometría?**

El estilo permanece con la forma; solo cambia el contorno. El relleno y el contorno se aplican automáticamente a la nueva geometría.

**¿Cómo rotar correctamente una forma personalizada junto con su geometría?**

Utilice el método [setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setRotation) de la forma; la geometría rota con la forma porque está vinculada al propio sistema de coordenadas de la forma.

**¿Puedo convertir una forma personalizada en una imagen para “bloquear” el resultado?**

Sí. Exporte la zona de la [diapositiva](/slides/es/nodejs-java/convert-powerpoint-to-png/) requerida o la propia [forma](/slides/es/nodejs-java/create-shape-thumbnails/) a un formato raster; esto simplifica el trabajo posterior con geometrías complejas.