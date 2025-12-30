---
title: Gestionar conectores en presentaciones con PHP
linktitle: Conector
type: docs
weight: 10
url: /es/php-java/connector/
keywords:
- conector
- tipo de conector
- punto de conector
- línea de conector
- ángulo de conector
- conectar formas
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Permita a las aplicaciones PHP dibujar, conectar y encaminar automáticamente líneas en diapositivas de PowerPoint — obtenga un control total sobre conectores rectos, en codo y curvos."
---

Un conector de PowerPoint es una línea especial que une o enlaza dos formas y permanece adherida a las formas incluso cuando se mueven o reposicionan en una diapositiva concreta.  

Los conectores suelen estar vinculados a *puntos de conexión* (puntos verdes), que existen en todas las formas por defecto. Los puntos de conexión aparecen cuando el cursor se acerca a ellos.  

*Puntos de ajuste* (puntos naranjas), que sólo existen en ciertos conectores, se utilizan para modificar la posición y forma de los conectores.  

## **Tipos de conectores**

En PowerPoint, puede usar conectores rectos, en codo (angulados) y curvos.  

Aspose.Slides proporciona estos conectores:

| Conector | Imagen | Número de puntos de ajuste |
| ------------------------------ | ------------------------------------------------------------ | --------------------------- |
| `ShapeType::Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0 |
| `ShapeType::StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType::BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0 |
| `ShapeType::BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1 |
| `ShapeType::BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2 |
| `ShapeType::BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3 |
| `ShapeType::CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType::CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType::CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType::CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

## **Conectar formas usando conectores**

1. Cree una instancia de la clase [Presentación](https://apireference.aspose.com/slides/php-java/aspose.slides/Presentation).  
1. Obtenga una referencia a una diapositiva mediante su índice.  
1. Añada dos [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape) a la diapositiva usando el método `addAutoShape` expuesto por el objeto `Shapes`.  
1. Añada un conector usando el método `addConnector` expuesto por el objeto `Shapes` definiendo el tipo de conector.  
1. Conecte las formas mediante el conector.  
1. Llame al método `reroute` para aplicar la ruta de conexión más corta.  
1. Guarde la presentación.  

Este código PHP muestra cómo añadir un conector (un conector doblado) entre dos formas (una elipse y un rectángulo):
```php
// Instancia una clase de presentación que representa el archivo PPTX
  $pres = new Presentation();
  try {
    # Accede a la colección de formas de una diapositiva concreta
    $shapes = $pres->getSlides()->get_Item(0)->getShapes();
    # Añade una forma automática de elipse
    $ellipse = $shapes->addAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);
    # Añade una forma automática de rectángulo
    $rectangle = $shapes->addAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);
    # Añade una forma de conector a la colección de formas de la diapositiva
    $connector = $shapes->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);
    # Conecta las formas usando el conector
    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);
    # Llama a reroute que establece la ruta automática más corta entre las formas
    $connector->reroute();
    # Guarda la presentación
    $pres->save("output.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) $pres.dispose();
}
```


{{%  alert title="NOTE"  color="warning"   %}} 

El método `Connector.reroute` vuelve a encaminar un conector y lo obliga a tomar la ruta más corta posible entre las formas. Para conseguir su objetivo, el método puede modificar los puntos `setStartShapeConnectionSiteIndex` y `setEndShapeConnectionSiteIndex`. 

{{% /alert %}} 

## **Especificar un punto de conexión**

Si desea que un conector una dos formas usando puntos específicos de las formas, debe especificar los puntos de conexión preferidos de esta manera:

1. Cree una instancia de la clase [Presentación](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).  
1. Obtenga una referencia a una diapositiva mediante su índice.  
1. Añada dos [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape) a la diapositiva usando el método `addAutoShape` expuesto por el objeto `Shapes`.  
1. Añada un conector usando el método `addConnector` expuesto por el objeto `Shapes` definiendo el tipo de conector.  
1. Conecte las formas mediante el conector.  
1. Establezca sus puntos de conexión preferidos en las formas.  
1. Guarde la presentación.  

Este código PHP muestra una operación donde se especifica un punto de conexión preferido:
```php
  # Instancia una clase de presentación que representa un archivo PPTX
  $pres = new Presentation();
  try {
    # Accede a la colección de formas de una diapositiva concreta
    $shapes = $pres->getSlides()->get_Item(0)->getShapes();
    # Añade una forma automática de elipse
    $ellipse = $shapes->addAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);
    # Añade una forma automática de rectángulo
    $rectangle = $shapes->addAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);
    # Añade una forma de conector a la colección de formas de la diapositiva
    $connector = $shapes->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);
    # Conecta las formas usando el conector
    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);
    # Establece el índice del punto de conexión preferido en la forma de elipse
    $wantedIndex = 6;
    # Comprueba si el índice preferido es menor que el recuento máximo de sitios
    if ($ellipse->getConnectionSiteCount() > $wantedIndex) {
      # Establece el punto de conexión preferido en la forma automática de elipse
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


## **Ajustar un punto de conector**

Puede ajustar un conector existente a través de sus puntos de ajuste. Sólo los conectores con puntos de ajuste pueden modificarse de esta forma. Consulte la tabla bajo **[Tipos de conectores.](/slides/es/php-java/connector/#types-of-connectors)**  

### **Caso simple**

Considere un caso en el que un conector entre dos formas (A y B) pasa por una tercera forma (C):

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


Para evitar o eludir la tercera forma, podemos ajustar el conector desplazando su línea vertical hacia la izquierda de esta manera:

![connector-obstruction-fixed](connector-obstruction-fixed.png)
```php
  $adj2 = $connector->getAdjustments()->get_Item(1);
  $adj2->setRawValue($adj2->getRawValue() + 10000);

```


### **Casos complejos** 

Para realizar ajustes más complicados, debe tener en cuenta los siguientes aspectos:

* El punto ajustable de un conector está fuertemente ligado a una fórmula que calcula y determina su posición. Por ello, los cambios en la ubicación del punto pueden alterar la forma del conector.  
* Los puntos de ajuste de un conector se definen en un orden estricto dentro de una matriz. Los puntos de ajuste se numeran desde el punto de inicio del conector hasta su final.  
* Los valores de los puntos de ajuste reflejan el porcentaje del ancho/alto de la forma del conector.  
  * La forma está limitada por los puntos de inicio y fin del conector multiplicados por 1000.  
  * El primer punto, segundo punto y tercer punto definen respectivamente el porcentaje del ancho, el porcentaje del alto y de nuevo el porcentaje del ancho.  
* Para los cálculos que determinan las coordenadas de los puntos de ajuste de un conector, debe considerar la rotación del conector y su reflexión. **Nota** que el ángulo de rotación para todos los conectores mostrados bajo **[Tipos de conectores](/slides/es/php-java/connector/#types-of-connectors)** es 0.  

#### **Caso 1**

Considere un caso en el que dos objetos de marco de texto están enlazados mediante un conector:

![connector-shape-complex](connector-shape-complex.png)
```php
  # Instancia una clase de presentación que representa un archivo PPTX
  $pres = new Presentation();
  try {
    # Obtiene la primera diapositiva de la presentación
    $sld = $pres->getSlides()->get_Item(0);
    # Añade formas que se unirán mediante un conector
    $shapeFrom = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $shapeFrom->getTextFrame()->setText("From");
    $shapeTo = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
    $shapeTo->getTextFrame()->setText("To");
    # Añade un conector
    $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
    # Especifica la dirección del conector
    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    # Especifica el color del conector
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Especifica el grosor de la línea del conector
    $connector->getLineFormat()->setWidth(3);
    # Enlaza las formas con el conector
    $connector->setStartShapeConnectedTo($shapeFrom);
    $connector->setStartShapeConnectionSiteIndex(3);
    $connector->setEndShapeConnectedTo($shapeTo);
    $connector->setEndShapeConnectionSiteIndex(2);
    # Obtiene los puntos de ajuste del conector
    $adjValue_0 = $connector->getAdjustments()->get_Item(0);
    $adjValue_1 = $connector->getAdjustments()->get_Item(1);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


**Ajuste**

Podemos cambiar los valores de los puntos de ajuste del conector aumentando el porcentaje correspondiente de ancho y alto en un 20 % y un 200 %, respectivamente:
```php
  # Cambia los valores de los puntos de ajuste
  $adjValue_0->setRawValue($adjValue_0->getRawValue() + 20000);
  $adjValue_1->setRawValue($adjValue_1->getRawValue() + 200000);
```


El resultado:

![connector-adjusted-1](connector-adjusted-1.png)

Para definir un modelo que nos permita determinar las coordenadas y la forma de las partes individuales del conector, crearemos una forma que corresponda al componente horizontal del conector en el punto `connector.getAdjustments().get_Item(0)`:
```php
  # Dibuja el componente vertical del conector
  $x = $connector->getX() . $connector->getWidth() * $adjValue_0->getRawValue() / 100000;
  $y = $connector->getY();
  $height = $connector->getHeight() * $adjValue_1->getRawValue() / 100000;
  $sld->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 0, $height);
```


El resultado:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Caso 2**

En **Caso 1**, demostramos una operación simple de ajuste de conector usando principios básicos. En situaciones normales, debe tener en cuenta la rotación del conector y su visualización (que se establecen mediante `connector.getRotation()`, `connector.getFrame().getFlipH()` y `connector.getFrame().getFlipV()`). Ahora mostraremos el proceso.

Primero, añadamos un nuevo objeto de marco de texto (**To 1**) a la diapositiva (para fines de conexión) y creemos un nuevo conector (verde) que lo una a los objetos ya creados.
```php
  # Crea un nuevo objeto de vinculación
  $shapeTo_1 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 400, 60, 25);
  $shapeTo_1->getTextFrame()->setText("To 1");
  # Crea un nuevo conector
  $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
  $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
  $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
  $connector->getLineFormat()->setWidth(3);
  # Conecta los objetos usando el conector recién creado
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

Segundo, creemos una forma que corresponda al componente horizontal del conector que pasa por el nuevo punto de ajuste `connector.getAdjustments().get_Item(0)`. Utilizaremos los valores de los datos del conector para `connector.getRotation()`, `connector.getFrame().getFlipH()` y `connector.getFrame().getFlipV()` y aplicaremos la conocida fórmula de conversión de coordenadas para rotación alrededor de un punto x₀:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;  

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;  

En nuestro caso, el ángulo de rotación del objeto es 90 grados y el conector se muestra verticalmente, por lo que el código correspondiente es:
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
  # Toma el valor del punto de ajuste como coordenada
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

Demostramos cálculos que implican ajustes simples y puntos de ajuste complejos (puntos de ajuste con ángulos de rotación). Con el conocimiento adquirido, puede desarrollar su propio modelo (o escribir código) para obtener un objeto `GraphicsPath` o incluso establecer los valores de los puntos de ajuste de un conector basándose en coordenadas específicas de la diapositiva.

## **Encontrar el ángulo de las líneas del conector**

1. Cree una instancia de la clase.  
1. Obtenga una referencia a una diapositiva mediante su índice.  
1. Acceda a la forma de la línea del conector.  
1. Utilice el ancho, la altura, la altura del marco de la forma y el ancho del marco de la forma para calcular el ángulo.  

Este código PHP muestra una operación en la que calculamos el ángulo de una forma de línea de conector:
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


## **FAQ**

**¿Cómo puedo saber si un conector puede "pegarse" a una forma concreta?**

Compruebe que la forma expone [sitios de conexión](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getconnectionsitecount/). Si no hay ninguno o el recuento es cero, no es posible pegar; en ese caso, use extremos libres y colóquelos manualmente. Es recomendable comprobar el recuento de sitios antes de adjuntar.  

**¿Qué ocurre con un conector si elimino una de las formas conectadas?**

Sus extremos se separarán; el conector permanecerá en la diapositiva como una línea ordinaria con inicio/final libres. Puede eliminarlo o reasignar las conexiones y, si es necesario, [volver a encaminar](https://reference.aspose.com/slides/php-java/aspose.slides/connector/reroute/).  

**¿Se conservan los enlaces del conector al copiar una diapositiva a otra presentación?**

Generalmente sí, siempre que las formas objetivo también se copien. Si la diapositiva se inserta en otro archivo sin las formas conectadas, los extremos se vuelven libres y será necesario volver a adjuntarlos.