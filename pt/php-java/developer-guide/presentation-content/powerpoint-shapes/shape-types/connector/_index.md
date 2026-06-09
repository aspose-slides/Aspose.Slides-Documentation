---
title: Gerenciar Conectores em Apresentações Usando PHP
linktitle: Conector
type: docs
weight: 10
url: /pt/php-java/connector/
keywords:
- conector
- tipo de conector
- ponto de conector
- linha de conector
- ângulo do conector
- conectar formas
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Capacite aplicativos PHP a desenhar, conectar e rotear automaticamente linhas em slides do PowerPoint — obtenha controle total sobre conectores retos, em ângulo e curvos."
---
## **Introdução**

Um conector do PowerPoint é uma linha especial que conecta ou une duas formas e permanece anexada a elas mesmo quando são movidas ou reposicionadas em um determinado slide. 

Os conectores normalmente são ligados a *pontos de conexão* (pontos verdes), que existem em todas as formas por padrão. Os pontos de conexão aparecem quando o cursor se aproxima deles.

*Pontos de ajuste* (pontos laranja), que existem apenas em certos conectores, são usados para modificar as posições e formas dos conectores.

## **Tipos de Conectores**

No PowerPoint, você pode usar conectores retos, em ângulo (elbow) e curvos. 

Aspose.Slides fornece esses conectores:

| Conector                      | Imagem                                                        | Número de pontos de ajuste |
| ------------------------------ | ------------------------------------------------------------ | --------------------------- |
| `ShapeType::Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                           |
| `ShapeType::StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                           |
| `ShapeType::BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                           |
| `ShapeType::BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                           |
| `ShapeType::BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                           |
| `ShapeType::BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                           |
| `ShapeType::CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                           |
| `ShapeType::CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                           |
| `ShapeType::CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                           |
| `ShapeType::CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                           |

## **Conectar Formas Usando Conectores**

1. Crie uma instância da classe [Presentation](https://apireference.aspose.com/slides/pt/php-java/aspose.slides/Presentation).
1. Obtenha a referência de um slide pelo seu índice.
1. Adicione duas [AutoShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/AutoShape) ao slide usando o método `addAutoShape` exposto pelo objeto `Shapes`.
1. Adicione um conector usando o método `addConnector` exposto pelo objeto `Shapes`, definindo o tipo de conector.
1. Conecte as formas usando o conector. 
1. Chame o método `reroute` para aplicar o caminho de conexão mais curto.
1. Salve a apresentação. 

Este código PHP mostra como adicionar um conector (um conector dobrado) entre duas formas (uma elipse e um retângulo):

```php
// Instancia uma classe de apresentação que representa o arquivo PPTX
  $pres = new Presentation();
  try {
    # Acessa a coleção de formas de um slide específico
    $shapes = $pres->getSlides()->get_Item(0)->getShapes();
    # Adiciona uma forma automática Elipse
    $ellipse = $shapes->addAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);
    # Adiciona uma forma automática Retângulo
    $rectangle = $shapes->addAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);
    # Adiciona uma forma de conector à coleção de formas do slide
    $connector = $shapes->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);
    # Conecta as formas usando o conector
    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);
    # Chama reroute que define o caminho automático mais curto entre as formas
    $connector->reroute();
    # Salva a apresentação
    $pres->save("output.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) $pres.dispose();
}
```

{{%  alert title="NOTE"  color="warning"   %}} 

O método `Connector.reroute` reencaminha um conector e obriga‑o a seguir o caminho mais curto possível entre as formas. Para alcançar esse objetivo, o método pode mudar os pontos `setStartShapeConnectionSiteIndex` e `setEndShapeConnectionSiteIndex`. 

{{% /alert %}} 

## **Especificar um Ponto de Conexão**

Se desejar que um conector una duas formas usando pontos específicos nas formas, especifique seus pontos de conexão preferidos da seguinte forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation).
1. Obtenha a referência de um slide pelo seu índice.
1. Adicione duas [AutoShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/AutoShape) ao slide usando o método `addAutoShape` exposto pelo objeto `Shapes`.
1. Adicione um conector usando o método `addConnector` exposto pelo objeto `Shapes`, definindo o tipo de conector.
1. Conecte as formas usando o conector. 
1. Defina seus pontos de conexão preferidos nas formas. 
1. Salve a apresentação.

Este código PHP demonstra uma operação em que um ponto de conexão preferido é especificado:

```php
  # Instancia uma classe de apresentação que representa um arquivo PPTX
  $pres = new Presentation();
  try {
    # Acessa a coleção de formas de um slide específico
    $shapes = $pres->getSlides()->get_Item(0)->getShapes();
    # Adiciona uma forma automática Elipse
    $ellipse = $shapes->addAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);
    # Adiciona uma forma automática Retângulo
    $rectangle = $shapes->addAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);
    # Adiciona uma forma de conector à coleção de formas do slide
    $connector = $shapes->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);
    # Conecta as formas usando o conector
    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);
    # Define o índice do ponto de conexão preferido na forma Elipse
    $wantedIndex = 6;
    # Verifica se o índice preferido é menor que a contagem máxima de sites
    if ($ellipse->getConnectionSiteCount() > $wantedIndex) {
      # Define o ponto de conexão preferido na forma automática Elipse
      $connector->setStartShapeConnectionSiteIndex($wantedIndex);
    }
    # Salva a apresentação
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ajustar um Ponto de Conector**

Você pode ajustar um conector existente por meio de seus pontos de ajuste. Apenas conectores com pontos de ajuste podem ser alterados dessa maneira. Veja a tabela sob **[Tipos de conectores.](/slides/pt/php-java/connector/#types-of-connectors)**

### **Caso Simples**

Considere um caso em que um conector entre duas formas (A e B) passa por uma terceira forma (C):

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

Para evitar ou contornar a terceira forma, podemos ajustar o conector movendo sua linha vertical para a esquerda da seguinte forma:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```php
  $adj2 = $connector->getAdjustments()->get_Item(1);
  $adj2->setRawValue($adj2->getRawValue() + 10000);

```

### **Casos Complexos** 

Para realizar ajustes mais complicados, você deve levar em consideração as seguintes questões:

* O ponto ajustável de um conector está fortemente ligado a uma fórmula que calcula e determina sua posição. Portanto, alterações na localização do ponto podem modificar a forma do conector.
* Os pontos de ajuste de um conector são definidos em ordem estrita em um array. Os pontos de ajuste são numerados do ponto inicial ao ponto final do conector.
* Os valores dos pontos de ajuste refletem a porcentagem da largura/altura da forma do conector. 
  * A forma é limitada pelos pontos inicial e final do conector multiplicados por 1000. 
  * O primeiro ponto, segundo ponto e terceiro ponto definem, respectivamente, a porcentagem da largura, a porcentagem da altura e novamente a porcentagem da largura.
* Para cálculos que determinam as coordenadas dos pontos de ajuste de um conector, é necessário considerar a rotação do conector e sua reflexão. **Note** que o ângulo de rotação para todos os conectores mostrados em **[Tipos de conectores](/slides/pt/php-java/connector/#types-of-connectors)** é 0.

#### **Caso 1**

Considere um caso em que dois objetos de quadro de texto são ligados entre si por meio de um conector:

![connector-shape-complex](connector-shape-complex.png)

```php
  # Instancia uma classe de apresentação que representa um arquivo PPTX
  $pres = new Presentation();
  try {
    # Obtém o primeiro slide da apresentação
    $sld = $pres->getSlides()->get_Item(0);
    # Adiciona formas que serão unidas por meio de um conector
    $shapeFrom = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $shapeFrom->getTextFrame()->setText("From");
    $shapeTo = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
    $shapeTo->getTextFrame()->setText("To");
    # Adiciona um conector
    $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
    # Especifica a direção do conector
    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    # Especifica a cor do conector
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Especifica a espessura da linha do conector
    $connector->getLineFormat()->setWidth(3);
    # Liga as formas juntas com o conector
    $connector->setStartShapeConnectedTo($shapeFrom);
    $connector->setStartShapeConnectionSiteIndex(3);
    $connector->setEndShapeConnectedTo($shapeTo);
    $connector->setEndShapeConnectionSiteIndex(2);
    # Obtém os pontos de ajuste do conector
    $adjValue_0 = $connector->getAdjustments()->get_Item(0);
    $adjValue_1 = $connector->getAdjustments()->get_Item(1);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

**Ajuste**

Podemos alterar os valores dos pontos de ajuste do conector aumentando a porcentagem de largura e altura correspondentes em 20 % e 200 %, respectivamente:

```php
  # Altera os valores dos pontos de ajuste
  $adjValue_0->setRawValue($adjValue_0->getRawValue() + 20000);
  $adjValue_1->setRawValue($adjValue_1->getRawValue() + 200000);

```

O resultado:

![connector-adjusted-1](connector-adjusted-1.png)

Para definir um modelo que nos permita determinar as coordenadas e a forma das partes individuais do conector, vamos criar uma forma que corresponda ao componente horizontal do conector no ponto `connector.getAdjustments().get_Item(0)`:

```php
  # Desenha o componente vertical do conector
  $x = $connector->getX() . $connector->getWidth() * $adjValue_0->getRawValue() / 100000;
  $y = $connector->getY();
  $height = $connector->getHeight() * $adjValue_1->getRawValue() / 100000;
  $sld->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 0, $height);

```

O resultado:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Caso 2**

No **Caso 1**, demonstramos uma operação simples de ajuste de conector usando princípios básicos. Em situações normais, é preciso levar em conta a rotação do conector e sua exibição (definidas por `connector.getRotation()`, `connector.getFrame().getFlipH()` e `connector.getFrame().getFlipV()`). Agora demonstraremos o processo.

Primeiro, adicione um novo objeto de quadro de texto (**To 1**) ao slide (para fins de conexão) e crie um novo conector (verde) que o una aos objetos já criados.

```php
  # Cria um novo objeto de vínculo
  $shapeTo_1 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 400, 60, 25);
  $shapeTo_1->getTextFrame()->setText("To 1");
  # Cria um novo conector
  $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
  $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
  $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
  $connector->getLineFormat()->setWidth(3);
  # Conecta os objetos usando o conector recém-criado
  $connector->setStartShapeConnectedTo($shapeFrom);
  $connector->setStartShapeConnectionSiteIndex(2);
  $connector->setEndShapeConnectedTo($shapeTo_1);
  $connector->setEndShapeConnectionSiteIndex(3);
  # Obtém os pontos de ajuste do conector
  $adjValue_0 = $connector->getAdjustments()->get_Item(0);
  $adjValue_1 = $connector->getAdjustments()->get_Item(1);
  # Altera os valores dos pontos de ajuste
  $adjValue_0->setRawValue($adjValue_0->getRawValue() + 20000);
  $adjValue_1->setRawValue($adjValue_1->getRawValue() + 200000);
```

O resultado:

![connector-adjusted-3](connector-adjusted-3.png)

Em segundo lugar, crie uma forma que corresponda ao componente horizontal do conector que passa pelo novo ponto de ajuste `connector.getAdjustments().get_Item(0)`. Usaremos os valores de `connector.getRotation()`, `connector.getFrame().getFlipH()` e `connector.getFrame().getFlipV()` e aplicaremos a fórmula popular de conversão de coordenadas para rotação em torno de um ponto x0:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

No nosso caso, o ângulo de rotação do objeto é 90 graus e o conector é exibido verticalmente, portanto o código correspondente é:

```php
  # Salva as coordenadas do conector
  $x = $connector->getX();
  $y = $connector->getY();
  # Corrige as coordenadas do conector caso apareça
  if ($connector->getFrame()->getFlipH() == NullableBool::True) {
    $x += $connector->getWidth();
  }
  if ($connector->getFrame()->getFlipV() == NullableBool::True) {
    $y += $connector->getHeight();
  }
  # Usa o valor do ponto de ajuste como coordenada
  $x += $connector->getWidth() * $adjValue_0->getRawValue() / 100000;
  # Converte as coordenadas já que Sin(90) = 1 e Cos(90) = 0
  $xx = $connector->getFrame()->getCenterX() - $y . $connector->getFrame()->getCenterY();
  $yy = $x - $connector->getFrame()->getCenterX() . $connector->getFrame()->getCenterY();
  # Determina a largura do componente horizontal usando o valor do segundo ponto de ajuste
  $width = $connector->getHeight() * $adjValue_1->getRawValue() / 100000;
  $shape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, $xx, $yy, $width, 0);
  $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
```

O resultado:

![connector-adjusted-4](connector-adjusted-4.png)

Demonstramos cálculos envolvendo ajustes simples e pontos de ajuste complicados (pontos de ajuste com ângulos de rotação). Usando o conhecimento adquirido, você pode desenvolver seu próprio modelo (ou escrever um código) para obter um objeto `GraphicsPath` ou até mesmo definir valores de ponto de ajuste do conector com base em coordenadas específicas do slide.

## **Encontrar o Ângulo das Linhas do Conector**

1. Crie uma instância da classe.
1. Obtenha a referência de um slide pelo seu índice.
1. Acesse a forma de linha do conector.
1. Use a largura, altura, altura da moldura da forma e largura da moldura da forma para calcular o ângulo.

Este código PHP demonstra uma operação em que calculamos o ângulo de uma forma de linha de conector:

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

**Como posso saber se um conector pode ser “colado” a uma forma específica?**

Verifique se a forma expõe [sites de conexão](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/getconnectionsitecount/). Se não houver nenhum ou a contagem for zero, a colagem não está disponível; nesse caso, use extremidades livres e posicione-as manualmente. É prudente verificar a contagem de sites antes de anexar.

**O que acontece com um conector se eu excluir uma das formas conectadas?**

Suas extremidades serão desanexadas; o conector permanece no slide como uma linha comum com início/fim livres. Você pode excluí‑lo ou reassociar as conexões e, se necessário, [reroute](https://reference.aspose.com/slides/pt/php-java/aspose.slides/connector/reroute/).

**As ligações de conectores são preservadas ao copiar um slide para outra apresentação?**

Geralmente sim, desde que as formas de destino também sejam copiadas. Se o slide for inserido em outro arquivo sem as formas conectadas, as extremidades tornam‑se livres e será necessário reanexá‑las.