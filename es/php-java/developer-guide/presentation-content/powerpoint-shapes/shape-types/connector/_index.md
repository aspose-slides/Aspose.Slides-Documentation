---
title: Conector
type: docs
weight: 10
url: /php-java/connector/
keywords: "Conectar formas, conectores, formas de PowerPoint, presentación de PowerPoint, Java, Aspose.Slides para PHP a través de Java"
description: "Conectar formas de PowerPoint"
---

Un conector de PowerPoint es una línea especial que conecta o enlaza dos formas entre sí y permanece conectado a las formas incluso cuando se trasladan o reposicionan en una diapositiva dada.

Los conectores normalmente están conectados a *puntos de conexión* (puntos verdes), que existen en todas las formas por defecto. Los puntos de conexión aparecen cuando un cursor se acerca a ellos.

*Puntos de ajuste* (puntos naranjas), que existen solo en ciertos conectores, se utilizan para modificar las posiciones y formas de los conectores.

## **Tipos de Conectores**

En PowerPoint, puedes utilizar conectores rectos, de codo (angulados) y curvados.

Aspose.Slides proporciona estos conectores:

| Conector                          | Imagen                                                         | Número de puntos de ajuste |
| -------------------------------- | -------------------------------------------------------------- | -------------------------- |
| `ShapeType::Line`                | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                          |
| `ShapeType::StraightConnector1`  | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                          |
| `ShapeType::BentConnector2`      | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                          |
| `ShapeType::BentConnector3`      | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                          |
| `ShapeType::BentConnector4`      | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                          |
| `ShapeType::BentConnector5`      | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                          |
| `ShapeType::CurvedConnector2`    | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                          |
| `ShapeType::CurvedConnector3`    | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                          |
| `ShapeType::CurvedConnector4`    | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                          |
| `ShapeType::CurvedConnector5`    | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                          |

## **Conectar Formas Usando Conectores**

1. Crea una instancia de la clase [Presentation](https://apireference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Obtén la referencia de una diapositiva a través de su índice.
1. Agrega dos [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape) a la diapositiva usando el método `addAutoShape` expuesto por el objeto `Shapes`.
1. Agrega un conector usando el método `addConnector` expuesto por el objeto `Shapes` definiendo el tipo de conector.
1. Conecta las formas usando el conector.
1. Llama al método `reroute` para aplicar el camino de conexión más corto.
1. Guarda la presentación.

Este código PHP te muestra cómo agregar un conector (un conector doblado) entre dos formas (una elipse y un rectángulo):

```php
// Instancia una clase de presentación que representa el archivo PPTX
  $pres = new Presentation();
  try {
    # Accede a la colección de formas para una diapositiva específica
    $shapes = $pres->getSlides()->get_Item(0)->getShapes();
    # Agrega una autoshape Elipse
    $ellipse = $shapes->addAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);
    # Agrega una autoshape Rectángulo
    $rectangle = $shapes->addAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);
    # Agrega una forma de conector a la colección de formas de la diapositiva
    $connector = $shapes->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);
    # Conecta las formas usando el conector
    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);
    # Llama a reroute que establece el camino automático más corto entre formas
    $connector->reroute();
    # Guarda la presentación
    $pres->save("output.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) $pres->dispose();
}
```

{{% alert title="NOTA" color="warning" %}}

El método `Connector.reroute` reorienta un conector y le obliga a tomar el camino más corto posible entre las formas. Para alcanzar su objetivo, el método puede cambiar los puntos `setStartShapeConnectionSiteIndex` y `setEndShapeConnectionSiteIndex`.

{{% /alert %}}

## **Especificar Punto de Conexión**

Si deseas que un conector enlace dos formas usando puntos específicos en las formas, debes especificar tus puntos de conexión preferidos de esta manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Obtén la referencia de una diapositiva a través de su índice.
1. Agrega dos [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape) a la diapositiva usando el método `addAutoShape` expuesto por el objeto `Shapes`.
1. Agrega un conector usando el método `addConnector` expuesto por el objeto `Shapes` definiendo el tipo de conector.
1. Conecta las formas usando el conector.
1. Establece tus puntos de conexión preferidos en las formas.
1. Guarda la presentación.

Este código PHP demuestra una operación donde se especifica un punto de conexión preferido:

```php
  # Instancia una clase de presentación que representa un archivo PPTX
  $pres = new Presentation();
  try {
    # Accede a la colección de formas para una diapositiva específica
    $shapes = $pres->getSlides()->get_Item(0)->getShapes();
    # Agrega una autoshape Elipse
    $ellipse = $shapes->addAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);
    # Agrega una autoshape Rectángulo
    $rectangle = $shapes->addAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);
    # Agrega una forma de conector a la colección de formas de la diapositiva
    $connector = $shapes->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);
    # Conecta las formas usando el conector
    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);
    # Establece el índice de punto de conexión preferido en la forma Elipse
    $wantedIndex = 6;
    # Verifica si el índice preferido es menor que la cantidad máxima de índice de sitio
    if ($ellipse->getConnectionSiteCount() > $wantedIndex) {
      # Establece el punto de conexión preferido en la autoshape Elipse
      $connector->setStartShapeConnectionSiteIndex($wantedIndex);
    }
    # Guarda la presentación
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ajustar Punto de Conector**

Puedes ajustar un conector existente a través de sus puntos de ajuste. Solo los conectores con puntos de ajuste pueden alterarse de esta manera. Consulta la tabla bajo **[Tipos de conectores.](/slides/php-java/connector/#types-of-connectors)**

#### **Caso Simple**

Considera un caso donde un conector entre dos formas (A y B) pasa a través de una tercera forma (C):

![connector-obstruction](connector-obstruction.png)

```php
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    $shape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 150, 150, 75);
    $shapeFrom = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 400, 100, 50);
    $shapeTo = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 70, 30);
    $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector5, 20, 20, 400, 300);
    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $connector->setStartShapeConnectedTo($shapeFrom);
    $connector->setEndShapeConnectedTo($shapeTo);
    $connector->setStartShapeConnectionSiteIndex(2);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Para evitar o eludir la tercera forma, podemos ajustar el conector moviendo su línea vertical hacia la izquierda de esta manera:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```php
  $adj2 = $connector->getAdjustments()->get_Item(1);
  $adj2->setRawValue($adj2->getRawValue() + 10000);
```

### **Casos Complejos**

Para realizar ajustes más complicados, debes tener en cuenta estas cosas:

* Un punto ajustable de un conector está fuertemente vinculado a una fórmula que calcula y determina su posición. Por lo tanto, los cambios en la ubicación del punto pueden alterar la forma del conector.
* Los puntos de ajuste de un conector se definen en un estricto orden en un array. Los puntos de ajuste se numeran desde el punto de inicio de un conector hasta su final.
* Los valores de los puntos de ajuste reflejan el porcentaje del ancho/altura de la forma de un conector.
  * La forma está limitada por los puntos de inicio y fin del conector multiplicados por 1000.
  * El primer punto, el segundo punto y el tercer punto definen el porcentaje del ancho, el porcentaje de la altura y el porcentaje del ancho (de nuevo) respectivamente.
* Para cálculos que determinan las coordenadas de los puntos de ajuste de un conector, debes tener en cuenta la rotación del conector y su reflexión. **Nota** que el ángulo de rotación para todos los conectores mostrados bajo **[Tipos de conectores](/slides/php-java/connector/#types-of-connectors)** es 0.

#### **Caso 1**

Considera un caso donde dos objetos de marco de texto están enlazados a través de un conector:

![connector-shape-complex](connector-shape-complex.png)

```php
  # Instancia una clase de presentación que representa un archivo PPTX
  $pres = new Presentation();
  try {
    # Obtiene la primera diapositiva en la presentación
    $sld = $pres->getSlides()->get_Item(0);
    # Agrega formas que serán unidas a través de un conector
    $shapeFrom = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $shapeFrom->getTextFrame()->setText("Desde");
    $shapeTo = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
    $shapeTo->getTextFrame()->setText("Hasta");
    # Agrega un conector
    $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
    # Especifica la dirección del conector
    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    # Especifica el color del conector
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Especifica el grosor de la línea del conector
    $connector->getLineFormat()->setWidth(3);
    # Une las formas con el conector
    $connector->setStartShapeConnectedTo($shapeFrom);
    $connector->setStartShapeConnectionSiteIndex(3);
    $connector->setEndShapeConnectedTo($shapeTo);
    $connector->setEndShapeConnectionSiteIndex(2);
    # Obtiene los puntos de ajuste para el conector
    $adjValue_0 = $connector->getAdjustments()->get_Item(0);
    $adjValue_1 = $connector->getAdjustments()->get_Item(1);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

**Ajuste**

Podemos cambiar los valores de los puntos de ajuste del conector aumentando el porcentaje correspondiente de ancho y altura en un 20% y 200%, respectivamente:

```php
  # Cambia los valores de los puntos de ajuste
  $adjValue_0->setRawValue($adjValue_0->getRawValue() + 20000);
  $adjValue_1->setRawValue($adjValue_1->getRawValue() + 200000);
```

El resultado:

![connector-adjusted-1](connector-adjusted-1.png)

Para definir un modelo que nos permita determinar las coordenadas y la forma de las partes individuales del conector, vamos a crear una forma que corresponda al componente horizontal del conector en el punto connector.getAdjustments().get_Item(0):

```php
  # Dibuja el componente vertical del conector
  $x = $connector->getX() + $connector->getWidth() * $adjValue_0->getRawValue() / 100000;
  $y = $connector->getY();
  $height = $connector->getHeight() * $adjValue_1->getRawValue() / 100000;
  $sld->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 0, $height);
```

El resultado:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Caso 2**

En **Caso 1**, demostramos una operación simple de ajuste del conector utilizando principios básicos. En situaciones normales, debes tener en cuenta la rotación del conector y su representación (que se establecen mediante connector.getRotation(), connector.getFrame().getFlipH(), y connector.getFrame().getFlipV()). Ahora demostraremos el proceso.

Primero, agreguemos un nuevo objeto de marco de texto (**Hasta 1**) a la diapositiva (para propósitos de conexión) y crearemos un nuevo conector (verde) que lo conecte a los objetos que ya creamos.

```php
  # Crea un nuevo objeto de unión
  $shapeTo_1 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 400, 60, 25);
  $shapeTo_1->getTextFrame()->setText("Hasta 1");
  # Crea un nuevo conector
  $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
  $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
  $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
  $connector->getLineFormat()->setWidth(3);
  # Conecta objetos usando el conector recién creado
  $connector->setStartShapeConnectedTo($shapeFrom);
  $connector->setStartShapeConnectionSiteIndex(2);
  $connector->setEndShapeConnectedTo($shapeTo_1);
  $connector->setEndShapeConnectionSiteIndex(3);
  # Obtiene los puntos de ajuste del conector
  $adjValue_0 = $connector->getAdjustments()->get_Item(0);
  $adjValue_1 = $connector->getAdjustments()->get_Item(1);
  # Cambia los valores de los puntos de ajuste
  $adjValue_0->setRawValue($adjValue_0->getRawValue() + 20000);
  $adjValue_1->setRawValue($adjValue_1->getRawValue() + 200000);
```

El resultado:

![connector-adjusted-3](connector-adjusted-3.png)

Segundo, vamos a crear una forma que corresponderá al componente horizontal del conector que pasa a través del nuevo punto de ajuste del conector connector.getAdjustments().get_Item(0). Usaremos los valores de los datos del conector para connector.getRotation(), connector.getFrame().getFlipH(), y connector.getFrame().getFlipV() y aplicaremos la fórmula de conversión de coordenadas popular para la rotación alrededor de un punto dado x0:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

En nuestro caso, el ángulo de rotación del objeto es de 90 grados y el conector se muestra verticalmente, así que este es el código correspondiente:

```php
  # Guarda las coordenadas del conector
  $x = $connector->getX();
  $y = $connector->getY();
  # Corrige las coordenadas del conector en caso de que aparezca
  if ($connector->getFrame()->getFlipH() == NullableBool::True) {
    $x += $connector->getWidth();
  }
  if ($connector->getFrame()->getFlipV() == NullableBool::True) {
    $y += $connector->getHeight();
  }
  # Toma el valor del punto de ajuste como la coordenada
  $x += $connector->getWidth() * $adjValue_0->getRawValue() / 100000;
  # Convierte las coordenadas ya que Sin(90) = 1 y Cos(90) = 0
  $xx = $connector->getFrame()->getCenterX() - $y . $connector->getFrame()->getCenterY();
  $yy = $x - $connector->getFrame()->getCenterX() . $connector->getFrame()->getCenterY();
  # Determina el ancho del componente horizontal usando el valor del segundo punto de ajuste
  $width = $connector->getHeight() * $adjValue_1->getRawValue() / 100000;
  $shape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, $xx, $yy, $width, 0);
  $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
```

El resultado:

![connector-adjusted-4](connector-adjusted-4.png)

Demostramos cálculos que involucran ajustes simples y puntos de ajuste complicados (puntos de ajuste con ángulos de rotación). Con el conocimiento adquirido, puedes desarrollar tu propio modelo (o escribir un código) para obtener un objeto `GraphicsPath` o incluso establecer los valores de los puntos de ajuste de un conector en base a coordenadas específicas de la diapositiva.

## **Encontrar el Ángulo de las Líneas del Conector**

1. Crea una instancia de la clase.
1. Obtén la referencia de una diapositiva a través de su índice.
1. Accede a la forma de línea del conector.
1. Utiliza el ancho de línea, altura, altura del marco de la forma y ancho del marco de la forma para calcular el ángulo.

Este código PHP demuestra una operación en la que calculamos el ángulo para una forma de línea de conector:

```php
  $pres = new Presentation("ConnectorLineAngle.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    for($i = 0; $i < java_values($slide->getShapes()->size()) ; $i++) {
      $dir = 0.0;
      $shape = $slide->getShapes()->get_Item($i);
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
        $ashp = $shape;
        if ($ashp->getShapeType() == ShapeType::Line) {
          $dir = getDirection($ashp->getWidth(), $ashp->getHeight(), java_values($ashp->getFrame()->getFlipH()) > 0, $ashp->getFrame()->getFlipV() > 0);
        }
      } else if (java_instanceof($shape, new JavaClass("com.aspose.slides.Connector"))) {
        $ashp = $shape;
        $dir = getDirection($ashp->getWidth(), $ashp->getHeight(), java_values($ashp->getFrame()->getFlipH()) > 0, java_values($ashp->getFrame()->getFlipV()) > 0);
      }
      echo($dir);
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```