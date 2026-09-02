---
title: Gerenciar conectores em apresentações no Android
linktitle: Conector
type: docs
weight: 10
url: /pt/androidjava/connector/
keywords:
- conector
- tipo de conector
- ponto de conector
- linha de conector
- ângulo do conector
- site de conexão
- ponto de ajuste
- conectar formas
- PowerPoint
- apresentação
- Android
- Java
- Aspose.Slides
description: "Aprenda como adicionar, anexar, reenquadrar, ajustar e inspecionar conectores PowerPoint retos, dobrados e curvos com Aspose.Slides para Android via Java."
---
## **Visão geral**

Um conector é uma linha que pode permanecer anexada a duas formas quando qualquer uma das formas se move. Suas extremidades se fixam em pontos de conexão, representados por pontos verdes no PowerPoint. Alguns conectores dobrados e curvos também expõem pontos de ajuste, representados por pontos laranja, que controlam a posição de segmentos individuais do conector.

Aspose.Slides representa conectores através da interface [IConnector](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iconnector/). Você pode criá‑los, anexar suas extremidades a formas, escolher pontos de conexão, rerroteá‑los e modificar a geometria dos conectores que possuem pontos de ajuste.

## **Tipos de conectores**

A classe [ShapeType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/shapetype/) inclui predefinições de conectores retos, dobrados e curvos. A tabela a seguir mostra as geometrias de conectores disponíveis e o número de pontos de ajuste definidos por cada predefinição.

| Conector | Imagem | Número de pontos de ajuste |
|---|---|---|
| `ShapeType.Line` | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType.BentConnector2` | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| `ShapeType.BentConnector3` | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| `ShapeType.BentConnector4` | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| `ShapeType.BentConnector5` | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| `ShapeType.CurvedConnector2` | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType.CurvedConnector3` | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType.CurvedConnector4` | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType.CurvedConnector5` | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

O número e o significado dos pontos de ajuste fazem parte da predefinição do conector selecionado. Não presuma que dois tipos diferentes de conectores exponham a mesma estrutura de coleção.

## **Conectar duas formas**

Use [IShapeCollection.addConnector](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ishapecollection/#addConnector-int-float-float-float-float-) para adicionar um conector e use [IConnector.setStartShapeConnectedTo](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iconnector/#setStartShapeConnectedTo-com.aspose.slides.IShape-) e [IConnector.setEndShapeConnectedTo](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iconnector/#setEndShapeConnectedTo-com.aspose.slides.IShape-) para anexar suas extremidades. Depois que ambas as extremidades estiverem anexadas, [IConnector.reroute](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iconnector/#reroute--) seleciona a rota mais curta entre as formas.

O exemplo a seguir conecta uma elipse e um retângulo com um conector dobrado:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 40, 80, 120, 80);
    IAutoShape rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 320, 240, 140, 80);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    connector.reroute();

    presentation.save("connected-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Aviso" %}}
Chamar `reroute` pode alterar os valores de [setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iconnector/#setStartShapeConnectionSiteIndex-long-) e [setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iconnector/#setEndShapeConnectionSiteIndex-long-). Atribua sites de conexão específicos após o reroute se esses sites precisarem permanecer fixos.
{{% /alert %}}

## **Escolher um ponto de conexão**

Cada forma conectável informa seu número de sites por meio de [IShape.getConnectionSiteCount](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ishape/#getConnectionSiteCount--). Valide um índice de site zero‑based preferido antes de atribuí‑lo a uma extremidade do conector; a contagem de sites varia conforme a geometria da forma.

Este exemplo anexa o conector a um site específico na elipse quando esse site existe:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 40, 80, 120, 80);
    IAutoShape rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 320, 240, 140, 80);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector3, 0, 0, 10, 10);

    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);

    long preferredSiteIndex = 2;
    if (preferredSiteIndex < ellipse.getConnectionSiteCount()) {
        connector.setStartShapeConnectionSiteIndex(preferredSiteIndex);
    } else {
        System.out.println("The ellipse has only " + ellipse.getConnectionSiteCount() + " connection sites.");
    }

    presentation.save("specific-connection-site.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ajustar um ponto de conector**

Conectores com pontos de ajuste os expõem por meio de [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/igeometryshape/#getAdjustments--). Inspecione cada [IAdjustValue](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iadjustvalue/) e verifique seu valor de [getType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iadjustvalue/#getType--) antes de alterá‑lo com [setRawValue](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iadjustvalue/#setRawValue-long-). As regras gerais para identificar ajustes de formas predefinidas são descritas em [Manipulação de Forma](/slides/pt/androidjava/shape-manipulations/).

O número, a ordem, o significado e o intervalo de valores válidos dos ajustes de conector dependem da predefinição do conector. O tipo de ajuste é somente leitura, enquanto o valor do ajuste pode ser escrito. O método somente leitura [getName](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iadjustvalue/#getName--) fornece identificação adicional quando um conector contém mais de um ajuste do mesmo tipo semântico.

### **Roteamento em torno de um obstáculo**

No layout a seguir, um conector `BentConnector5` entre duas formas passa por uma terceira forma:

![connector-obstruction](connector-obstruction.png)

Este código cria o conector obstruído:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setStartShapeConnectionSiteIndex(2);

    presentation.save("connector-obstruction.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Mover a dobra vertical altera a rota de modo que o conector contorne o obstáculo:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Em vez de presumir que o índice da coleção `1` sempre representa a dobra vertical, este exemplo procura por `ConnectorBendPositionY` e o altera apenas quando o tipo semântico esperado está presente:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setStartShapeConnectionSiteIndex(2);

    IAdjustValue verticalBend = null;
    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        System.out.println(adjustment.getName() + ": " + adjustment.getType() + ", raw value = " + adjustment.getRawValue());
        if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
            break;
        }
    }

    if (verticalBend == null) {
        System.out.println("The connector does not expose a vertical bend adjustment.");
    } else {
        verticalBend.setRawValue(60000);
        presentation.save("connector-obstruction-fixed.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Um `BentConnector5` possui dois ajustes `ConnectorBendPositionX` e um ajuste `ConnectorBendPositionY`. Se o tipo que você precisa ocorrer mais de uma vez, inspecione `getName` e a geometria conhecida dessa predefinição antes de selecionar um. Se um ajuste relatar `ShapeAdjustmentType.Custom`, trate seu significado e intervalo como específicos da predefinição e não o altere até que esse contrato seja conhecido.

## **Relacionar valores de ajuste à geometria do conector**

Para conectores dobrados, os valores de ajuste podem ser usados para estimar as posições de segmentos individuais. Esses cálculos são específicos da predefinição do conector:

- `BentConnector4` normalmente expõe um ajuste `ConnectorBendPositionX` e um ajuste `ConnectorBendPositionY`.
- Para essas posições de dobra, dividir o valor retornado por `getRawValue` por `100000f` produz a fração da largura ou altura da moldura do conector usada nos exemplos abaixo.
- A moldura do conector pode ser girada ou espelhada, portanto as coordenadas da moldura devem ser transformadas antes de serem comparadas com as coordenadas do slide.

Os exemplos a seguir usam `getType` para identificar primeiro os ajustes. Eles não tratam índices de coleção como identificadores portáteis.

### **Conector não girado**

O layout inicial contém duas formas de texto conectadas por um `BentConnector4`:

![connector-shape-complex](connector-shape-complex.png)

Este exemplo inspeciona o conector e obtém seus ajustes de dobra horizontal e vertical:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    sourceShape.getTextFrame().setText("From");
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
    targetShape.getTextFrame().setText("To");
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
    connector.getLineFormat().setWidth(3);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(2);

    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        System.out.println(adjustment.getName() + ": " + adjustment.getType() + ", raw value = " + adjustment.getRawValue());
    }
} finally {
    presentation.dispose();
}
```

Para mudar ambas as dobras, localize cada tipo esperado e modifique os valores somente depois que ambos forem encontrados:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(2);

    IAdjustValue horizontalBend = null;
    IAdjustValue verticalBend = null;
    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX) {
            horizontalBend = adjustment;
        } else if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
        }
    }

    if (horizontalBend == null || verticalBend == null) {
        System.out.println("The connector does not expose the expected bend adjustments.");
    } else {
        horizontalBend.setRawValue(horizontalBend.getRawValue() + 20000);
        verticalBend.setRawValue(verticalBend.getRawValue() + 200000);
        presentation.save("connector-adjusted.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

O resultado é um conector cujos segmentos horizontal e vertical foram movidos:

![connector-adjusted-1](connector-adjusted-1.png)

Uma vez conhecidos os tipos semânticos, seus valores podem ser convertidos em coordenadas da moldura do conector. Este exemplo desenha um retângulo fino sobre o segmento vertical controlado pelos dois ajustes de dobra:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(2);

    IAdjustValue horizontalBend = null;
    IAdjustValue verticalBend = null;
    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX) {
            horizontalBend = adjustment;
        } else if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
        }
    }

    if (horizontalBend == null || verticalBend == null) {
        System.out.println("The connector does not expose the expected bend adjustments.");
    } else {
        float x = connector.getX() + connector.getWidth() * horizontalBend.getRawValue() / 100000f;
        float y = connector.getY();
        float height = connector.getHeight() * verticalBend.getRawValue() / 100000f;
        slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 1, height);
        presentation.save("connector-segment-guide.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

A forma de guia marca o segmento calculado:

![connector-adjusted-2](connector-adjusted-2.png)

### **Conector girado ou espelhado**

Quando a mesma geometria de conector está orientada verticalmente, os valores de [IShape.getFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ishape/#getFrame--), [ShapeFrame.getFlipH](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/shapeframe/#getFlipH--) e [ShapeFrame.getFlipV](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/shapeframe/#getFlipV--) afetam a conversão das coordenadas da moldura do conector para coordenadas do slide.

Este exemplo cria e ajusta o conector orientado verticalmente:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    sourceShape.getTextFrame().setText("From");
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
    targetShape.getTextFrame().setText("To 1");
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    int connectorColor = Color.rgb(102, 205, 170);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(connectorColor);
    connector.getLineFormat().setWidth(3);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(2);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(3);

    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX) {
            adjustment.setRawValue(adjustment.getRawValue() + 20000);
        } else if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY) {
            adjustment.setRawValue(adjustment.getRawValue() + 200000);
        }
    }

    presentation.save("vertical-connector-adjusted.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O conector ajustado aparece verticalmente entre as formas:

![connector-adjusted-3](connector-adjusted-3.png)

Para um ângulo de rotação arbitrário `alpha`, rotacione um ponto da moldura do conector `(x, y)` ao redor do centro da moldura `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

O código a seguir trata a orientação de 90 graus usada neste exemplo e desenha uma guia vermelha sobre o segmento correspondente do conector:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(2);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(3);

    IAdjustValue horizontalBend = null;
    IAdjustValue verticalBend = null;
    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX) {
            horizontalBend = adjustment;
        } else if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
        }
    }

    if (horizontalBend == null || verticalBend == null) {
        System.out.println("The connector does not expose the expected bend adjustments.");
    } else {
        horizontalBend.setRawValue(horizontalBend.getRawValue() + 20000);
        verticalBend.setRawValue(verticalBend.getRawValue() + 200000);

        float x = connector.getX();
        float y = connector.getY();
        if (connector.getFrame().getFlipH() == NullableBool.True) {
            x += connector.getWidth();
        }
        if (connector.getFrame().getFlipV() == NullableBool.True) {
            y += connector.getHeight();
        }

        x += connector.getWidth() * horizontalBend.getRawValue() / 100000f;
        float rotatedX = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY();
        float rotatedY = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY();
        float segmentWidth = connector.getHeight() * verticalBend.getRawValue() / 100000f;
        IAutoShape guide = slide.getShapes().addAutoShape(ShapeType.Rectangle, rotatedX, rotatedY, segmentWidth, 1);
        guide.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        guide.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

        presentation.save("rotated-connector-segment-guide.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

A guia vermelha marca o segmento calculado após a transformação de coordenadas:

![connector-adjusted-4](connector-adjusted-4.png)

Essas fórmulas descrevem as predefinições usadas nos exemplos, não um modelo universal de conector. Valide os tipos de ajuste, a orientação da moldura e os intervalos de valores antes de aplicar o mesmo cálculo a uma predefinição diferente.

## **Encontrar o ângulo de direção de um conector**

A direção de um conector reto pode ser calculada a partir de sua largura e altura, com inversões horizontais e verticais aplicadas. O exemplo a seguir relata o ângulo horário a partir do eixo horizontal positivo nas coordenadas do slide:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IConnector connector = slide.getShapes().addConnector(ShapeType.StraightConnector1, 100, 100, 200, 100);

    boolean flipH = connector.getFrame().getFlipH() == NullableBool.True;
    boolean flipV = connector.getFrame().getFlipV() == NullableBool.True;
    float deltaX = connector.getWidth() * (flipH ? -1 : 1);
    float deltaY = connector.getHeight() * (flipV ? -1 : 1);
    double angle = Math.atan2(deltaY, deltaX) * 180.0 / Math.PI;

    if (angle < 0) {
        angle += 360;
    }

    System.out.printf("Connector direction: %.2f degrees%n", angle);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Como saber se um conector pode ser anexado a uma forma?**

Verifique o valor de [getConnectionSiteCount](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ishape/#getConnectionSiteCount--) da forma. Uma contagem positiva significa que a forma expõe sites de conexão. Valide o índice do site selecionado antes de atribuí‑lo a qualquer extremidade do conector.

**Posso identificar um ajuste de conector pelo seu índice de coleção?**

Um índice tem significado apenas para uma predefinição de conector conhecida e sua estrutura de coleção. Verifique [IAdjustValue.getType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iadjustvalue/#getType--) antes de modificar um valor e use [IAdjustValue.getName](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iadjustvalue/#getName--) como informação adicional quando o mesmo tipo semântico ocorre mais de uma vez.

**O que acontece quando uma forma conectada é excluída?**

A extremidade correspondente do conector fica destacada. O conector permanece no slide e pode ser excluído, posicionado como uma linha livre ou anexado a outra forma.

**As ligações de conectores são preservadas ao copiar um slide?**

As ligações são geralmente preservadas quando as formas conectadas são copiadas junto com o slide. Se um conector for copiado sem uma de suas formas‑alvo, a extremidade afetada deverá ser anexada novamente.