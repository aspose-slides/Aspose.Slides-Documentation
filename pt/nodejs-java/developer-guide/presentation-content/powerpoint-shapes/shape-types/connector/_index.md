---
title: Gerenciar Conectores em Apresentações Usando JavaScript
linktitle: Conector
type: docs
weight: 10
url: /pt/nodejs-java/connector/
keywords:
- conector
- tipo de conector
- ponto de conector
- linha de conector
- ângulo do conector
- conectar formas
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Capacite aplicativos JavaScript a desenhar, conectar e roteamento automático de linhas em slides do PowerPoint—obtenha controle total sobre conectores retos, em cotovelo e curvos."
---
## **Introdução**

Um conector do PowerPoint é uma linha especial que conecta ou associa duas formas e permanece anexado às formas mesmo quando elas são movidas ou reposicionadas em um slide determinado. 

Os conectores são tipicamente conectados a *pontos de conexão* (pontos verdes), que existem em todas as formas por padrão. Os pontos de conexão aparecem quando o cursor se aproxima deles.

*Pontos de ajuste* (pontos laranja), que existem apenas em certos conectores, são usados para modificar as posições e formas dos conectores.

## **Tipos de Conectores**

No PowerPoint, você pode usar conectores retos, em cotovelo (angulados) e curvos. 

O Aspose.Slides fornece esses conectores:

| Conector                        | Imagem                                                        | Número de pontos de ajuste |
| ------------------------------ | ------------------------------------------------------------ | --------------------------- |
| `ShapeType.Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                           |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                           |
| `ShapeType.BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                           |
| `ShapeType.BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                           |
| `ShapeType.BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                           |
| `ShapeType.BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                           |
| `ShapeType.CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                           |
| `ShapeType.CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                           |
| `ShapeType.CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                           |
| `ShapeType.CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                           |

## **Conectar Formas Usando Conectores**

1. Crie uma instância da classe [Presentation](https://apireference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
2. Obtenha a referência de um slide pelo seu índice.
3. Adicione duas [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/AutoShape) ao slide usando o método `addAutoShape` exposto pelo objeto `Shapes`.
4. Adicione um conector usando o método `addConnector` exposto pelo objeto `Shapes`, definindo o tipo de conector.
5. Conecte as formas usando o conector. 
6. Chame o método `reroute` para aplicar o caminho de conexão mais curto.
7. Salve a apresentação. 

Este código JavaScript mostra como adicionar um conector (um conector dobrado) entre duas formas (uma elipse e um retângulo):

```javascript
// Instancia uma classe de apresentação que representa o arquivo PPTX
var pres = new aspose.slides.Presentation();
try {
    // Acessa a coleção de formas de um slide específico
    var shapes = pres.getSlides().get_Item(0).getShapes();
    // Adiciona uma forma automática Elipse
    var ellipse = shapes.addAutoShape(aspose.slides.ShapeType.Ellipse, 0, 100, 100, 100);
    // Adiciona uma forma automática Retângulo
    var rectangle = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 300, 100, 100);
    // Adiciona uma forma de conector à coleção de formas do slide
    var connector = shapes.addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 10, 10);
    // Conecta as formas usando o conector
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    // Chama reroute que define o caminho automático mais curto entre as formas
    connector.reroute();
    // Salva a apresentação
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{%  alert title="NOTE"  color="warning"   %}} 

O método `Connector.reroute` redireciona um conector e força que ele siga o caminho mais curto possível entre as formas. Para atingir esse objetivo, o método pode alterar os pontos `setStartShapeConnectionSiteIndex` e `setEndShapeConnectionSiteIndex`. 

{{% /alert %}} 

## **Especificar Ponto de Conexão**

Se você quiser que um conector associe duas formas usando pontos específicos nas formas, você deve especificar os pontos de conexão preferidos desta maneira:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
2. Obtenha a referência de um slide pelo seu índice.
3. Adicione duas [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/AutoShape) ao slide usando o método `addAutoShape` exposto pelo objeto `Shapes`.
4. Adicione um conector usando o método `addConnector` exposto pelo objeto `Shapes`, definindo o tipo de conector.
5. Conecte as formas usando o conector. 
6. Defina seus pontos de conexão preferidos nas formas. 
7. Salve a apresentação.

Este código JavaScript demonstra uma operação onde um ponto de conexão preferido é especificado:

```javascript
// Instancia uma classe de apresentação que representa um arquivo PPTX
var pres = new aspose.slides.Presentation();
try {
    // Acessa a coleção de formas de um slide específico
    var shapes = pres.getSlides().get_Item(0).getShapes();
    // Adiciona uma forma automática Elipse
    var ellipse = shapes.addAutoShape(aspose.slides.ShapeType.Ellipse, 0, 100, 100, 100);
    // Adiciona uma forma automática Retângulo
    var rectangle = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 300, 100, 100);
    // Adiciona uma forma de conector à coleção de formas do slide
    var connector = shapes.addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 10, 10);
    // Conecta as formas usando o conector
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    // Define o índice do ponto de conexão preferido na forma Elipse
    var wantedIndex = 6;
    // Verifica se o índice preferido é menor que a contagem máxima de pontos de conexão
    if (ellipse.getConnectionSiteCount() > wantedIndex) {
        // Define o ponto de conexão preferido na forma automática Elipse
        connector.setStartShapeConnectionSiteIndex(wantedIndex);
    }
    // Salva a apresentação
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ajustar Ponto do Conector**

Você pode ajustar um conector existente através de seus pontos de ajuste. Apenas conectores com pontos de ajuste podem ser alterados dessa forma. Veja a tabela em **[Tipos de conectores.](/slides/pt/nodejs-java/connector/#types-of-connectors)**

### **Caso Simples**

Considere um caso onde um conector entre duas formas (A e B) passa por uma terceira forma (C):

![connector-obstruction](connector-obstruction.png)

```javascript
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    var shape = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 150, 150, 75);
    var shapeFrom = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 400, 100, 50);
    var shapeTo = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 70, 30);
    var connector = sld.getShapes().addConnector(aspose.slides.ShapeType.BentConnector5, 20, 20, 400, 300);
    connector.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setStartShapeConnectionSiteIndex(2);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Para evitar ou contornar a terceira forma, podemos ajustar o conector movendo sua linha vertical para a esquerda desta maneira:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```javascript
var adj2 = connector.getAdjustments().get_Item(1);
adj2.setRawValue(adj2.getRawValue() + 10000);
```

### **Casos Complexos** 

Para realizar ajustes mais complicados, você deve levar em conta as seguintes questões:

* O ponto ajustável de um conector está fortemente ligado a uma fórmula que calcula e determina sua posição. Portanto, alterações na localização do ponto podem mudar a forma do conector.
* Os pontos de ajuste de um conector são definidos em uma ordem estrita em um array. Os pontos de ajuste são numerados do ponto inicial ao ponto final do conector.
* Os valores dos pontos de ajuste refletem a porcentagem da largura/altura da forma do conector.
  * A forma é limitada pelos pontos inicial e final do conector multiplicados por 1000.
  * O primeiro ponto, o segundo ponto e o terceiro ponto definem, respectivamente, a porcentagem da largura, a porcentagem da altura e novamente a porcentagem da largura.
* Para os cálculos que determinam as coordenadas dos pontos de ajuste de um conector, você deve levar em consideração a rotação do conector e sua reflexão. **Observação** que o ângulo de rotação para todos os conectores exibidos em **[Tipos de conectores](/slides/pt/nodejs-java/connector/#types-of-connectors)** é 0.

#### **Caso 1**

Considere um caso onde dois objetos de quadro de texto são vinculados através de um conector:

![connector-shape-complex](connector-shape-complex.png)

```javascript
// Instancia uma classe de apresentação que representa um arquivo PPTX
var pres = new aspose.slides.Presentation();
try {
    // Obtém o primeiro slide da apresentação
    var sld = pres.getSlides().get_Item(0);
    // Adiciona formas que serão unidas através de um conector
    var shapeFrom = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    shapeFrom.getTextFrame().setText("From");
    var shapeTo = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 60, 25);
    shapeTo.getTextFrame().setText("To");
    // Adiciona um conector
    var connector = sld.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
    // Especifica a direção do conector
    connector.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
    // Especifica a cor do conector
    connector.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Especifica a espessura da linha do conector
    connector.getLineFormat().setWidth(3);
    // Conecta as formas usando o conector
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setEndShapeConnectionSiteIndex(2);
    // Obtém os pontos de ajuste do conector
    var adjValue_0 = connector.getAdjustments().get_Item(0);
    var adjValue_1 = connector.getAdjustments().get_Item(1);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

**Ajuste**

Podemos alterar os valores dos pontos de ajuste do conector aumentando as porcentagens correspondentes de largura e altura em 20% e 200%, respectivamente:

```javascript
// Altera os valores dos pontos de ajuste
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

O resultado:

![connector-adjusted-1](connector-adjusted-1.png)

Para definir um modelo que nos permita determinar as coordenadas e a forma das partes individuais do conector, vamos criar uma forma que corresponda ao componente horizontal do conector no ponto `connector.getAdjustments().get_Item(0)`:

```javascript
// Desenha o componente vertical do conector
var x = connector.getX() + ((connector.getWidth() * adjValue_0.getRawValue()) / 100000);
var y = connector.getY();
var height = (connector.getHeight() * adjValue_1.getRawValue()) / 100000;
sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, x, y, 0, height);
```

O resultado:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Caso 2**

Em **Caso 1**, demonstramos uma operação simples de ajuste de conector usando princípios básicos. Em situações normais, você deve levar em conta a rotação do conector e sua exibição (que são definidas por `connector.getRotation()`, `connector.getFrame().getFlipH()` e `connector.getFrame().getFlipV()`). Agora demonstraremos o processo.

Primeiro, vamos adicionar um novo objeto de quadro de texto (**To 1**) ao slide (para fins de conexão) e criar um novo conector (verde) que o conecte aos objetos que já criamos.

```javascript
// Cria um novo objeto de vinculação
var shapeTo_1 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.getTextFrame().setText("To 1");
// Cria um novo conector
connector = sld.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
connector.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
connector.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));
connector.getLineFormat().setWidth(3);
// Conecta objetos usando o conector recém‑criado
connector.setStartShapeConnectedTo(shapeFrom);
connector.setStartShapeConnectionSiteIndex(2);
connector.setEndShapeConnectedTo(shapeTo_1);
connector.setEndShapeConnectionSiteIndex(3);
// Obtém os pontos de ajuste do conector
adjValue_0 = connector.getAdjustments().get_Item(0);
adjValue_1 = connector.getAdjustments().get_Item(1);
// Altera os valores dos pontos de ajuste
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

O resultado:

![connector-adjusted-3](connector-adjusted-3.png)

Segundo, vamos criar uma forma que corresponda ao componente horizontal do conector que passa pelo novo ponto de ajuste do conector `connector.getAdjustments().get_Item(0)`. Usaremos os valores dos dados do conector para `connector.getRotation()`, `connector.getFrame().getFlipH()` e `connector.getFrame().getFlipV()` e aplicaremos a conhecida fórmula de conversão de coordenadas para rotação ao redor de um ponto x0:

```javascript
// Salva as coordenadas do conector
x = connector.getX();
y = connector.getY();
// Corrige as coordenadas do conector caso apareça
if (connector.getFrame().getFlipH() == aspose.slides.NullableBool.True) {
    x += connector.getWidth();
}
if (connector.getFrame().getFlipV() == aspose.slides.NullableBool.True) {
    y += connector.getHeight();
}
// Usa o valor do ponto de ajuste como coordenada
x += (connector.getWidth() * adjValue_0.getRawValue()) / 100000;
// Converte as coordenadas já que seno(90) = 1 e cosseno(90) = 0
var xx = (connector.getFrame().getCenterX() - y) + connector.getFrame().getCenterY();
var yy = (x - connector.getFrame().getCenterX()) + connector.getFrame().getCenterY();
// Determina a largura do componente horizontal usando o valor do segundo ponto de ajuste
var width = (connector.getHeight() * adjValue_1.getRawValue()) / 100000;
var shape = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, xx, yy, width, 0);
shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
```

O resultado:

![connector-adjusted-4](connector-adjusted-4.png)

Demonstramos cálculos envolvendo ajustes simples e pontos de ajuste complicados (pontos de ajuste com ângulos de rotação). Usando o conhecimento adquirido, você pode desenvolver seu próprio modelo (ou escrever um código) para obter um objeto `GraphicsPath` ou até mesmo definir os valores dos pontos de ajuste de um conector com base em coordenadas específicas do slide.

## **Encontrar Ângulo das Linhas do Conector**

1. Crie uma instância da classe.
2. Obtenha a referência de um slide pelo seu índice.
3. Acesse a forma da linha do conector.
4. Use a largura da linha, altura, altura da moldura da forma e largura da moldura da forma para calcular o ângulo.

Este código JavaScript demonstra uma operação na qual calculamos o ângulo para uma forma de linha de conector:

```javascript
var pres = new aspose.slides.Presentation("ConnectorLineAngle.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    for (var i = 0; i < slide.getShapes().size(); i++) {
        var dir = 0.0;
        var shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            var ashp = shape;
            if (ashp.getShapeType() == aspose.slides.ShapeType.Line) {
                dir = getDirection(ashp.getWidth(), ashp.getHeight(), ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
            }
        } else if (java.instanceOf(shape, "com.aspose.slides.Connector")) {
            var ashp = shape;
            dir = getDirection(ashp.getWidth(), ashp.getHeight(), ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
        }
        console.log(dir);
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

```javascript
function getDirection(w, h, flipH, flipV) {
    let endLineX = w * (flipH ? -1 : 1);
    let endLineY = h * (flipV ? -1 : 1);
    
    let endYAxisX = 0;
    let endYAxisY = h;

    let angle = Math.atan2(endYAxisY, endYAxisX) - Math.atan2(endLineY, endLineX);

    if (angle < 0) {
        angle += 2 * Math.PI;
    }

    return angle * 180.0 / Math.PI;
}
```

## **FAQ**

**Como posso saber se um conector pode ser "colado" a uma forma específica?**

Verifique se a forma expõe [pontos de conexão](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/getconnectionsitecount/). Se não houver nenhum ou a contagem for zero, a colagem não está disponível; nesse caso, use pontos finais livres e posicione‑os manualmente. É recomendável verificar a contagem de sites antes de anexar.

**O que acontece com um conector se eu excluir uma das formas conectadas?**

Suas extremidades serão desanexadas; o conector permanece no slide como uma linha comum com início/fim livre. Você pode excluí‑lo ou reassociar as conexões e, se necessário, [redirecionar](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/connector/reroute/).

**As ligações de conectores são preservadas ao copiar um slide para outra apresentação?**

Geralmente sim, desde que as formas de destino também sejam copiadas. Se o slide for inserido em outro arquivo sem as formas conectadas, as extremidades se tornam livres e será necessário reanexá‑las.