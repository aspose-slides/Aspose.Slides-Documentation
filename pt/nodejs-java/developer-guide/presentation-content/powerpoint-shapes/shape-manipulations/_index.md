---
title: Gerenciar formas de apresentação em JavaScript
linktitle: Manipulação de formas
type: docs
weight: 40
url: /pt/nodejs-java/shape-manipulations/
keywords:
- Forma PowerPoint
- Forma de apresentação
- Forma no slide
- Encontrar forma
- Clonar forma
- Remover forma
- Ocultar forma
- Alterar ordem da forma
- Obter ID de forma interop
- Texto alternativo da forma
- Ponto de ajuste da forma
- Ajuste de forma predefinido
- Geometria da forma
- Formatos de layout da forma
- Forma como SVG
- Forma para SVG
- Alinhar forma
- Inverter forma
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda como identificar, ajustar, clonar, remover, ocultar, reordenar, exportar, alinhar e inverter formas de apresentação com Aspose.Slides para Node.js via Java."
---
## **Visão geral**

Aspose.Slides for Node.js via Java representa as formas em um slide como uma coleção ordenada [ShapeCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shapecollection/). A coleção é tanto o local onde você encontra e modifica formas quanto a fonte da ordem de empilhamento: o índice `0` é a forma mais ao fundo, enquanto o último índice é a forma mais à frente.

Este artigo segue esse modelo. Primeiro explica como identificar uma forma de forma confiável e modificar pontos de ajuste predefinidos, depois mostra como clonar, remover, ocultar e reordenar formas. As seções finais cobrem formatação em nível de layout, exportação SVG, alinhamento e configurações de inversão. Cada exemplo é independente, de modo que você pode usar apenas as operações necessárias ao seu fluxo de trabalho.

## **Identificar e localizar formas**

Os índices da coleção são convenientes ao processar um arquivo conhecido, mas não são identificadores estáveis. Adicionar, remover ou reordenar uma forma pode mudar seu índice. Escolha um identificador de acordo com a forma como a apresentação é criada e mantida:

- [Name](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/getname/) é útil para modelos controlados por desenvolvedores e é fácil de inspecionar no Painel de Seleção do PowerPoint. Nomes podem ser editados e não são garantidos como únicos, portanto estabeleça uma convenção de nomenclatura se o código depender deles.
- [AlternativeText](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/getalternativetext/) é útil quando uma descrição de acessibilidade ou uma etiqueta fornecida pelo autor já identifica a forma. É visível para os usuários, pode ser localizada ou reescrita para acessibilidade e não é garantida como única. Não reutilize silenciosamente texto de acessibilidade significativo como chave de banco de dados.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/) é um identificador somente‑leitura que é único dentro de um slide e corresponde ao ID de forma usado pela interoperabilidade do PowerPoint. Use‑o ao integrar com o PowerPoint ou quando precisar de uma referência inequívoca durante a vida útil de uma forma. Uma forma clonada ou recriada é uma forma diferente e recebe seu próprio ID.

O método relacionado [getUniqueId](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/getuniqueid/) devolve um identificador com escopo de apresentação, mas esse identificador é destinado a complementos e pode ser reassigned. Não deve ser tratado como chave externa permanente. Se a identidade a longo prazo for essencial, mantenha o mapeamento em dados da aplicação e valide se a forma esperada ainda existe.

O exemplo a seguir procura por nome com comparação exata e relata o ID de interop com escopo de slide. Quando o modelo não contém a forma esperada, o código relata esse resultado em vez de continuar com o objeto errado.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    var targetShape = null;
    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "RevenueChart") {
            targetShape = shape;
            break;
        }
    }

    if (targetShape === null) {
        console.log("The shape 'RevenueChart' was not found on slide 1.");
    } else {
        console.log("Found " + targetShape.getName() + "; interop ID: " + targetShape.getOfficeInteropShapeId());
    }
} finally {
    presentation.dispose();
}
```

Quando uma operação é específica a um tipo de forma, verifique a classe em tempo de execução antes de usar membros específicos do tipo. Este exemplo atualiza texto e texto alternativo apenas se o objeto nomeado for um [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/).

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    var candidate = null;
    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "StatusLabel") {
            candidate = shape;
            break;
        }
    }

    if (candidate !== null && java.instanceOf(candidate, "com.aspose.slides.AutoShape")) {
        candidate.getTextFrame().setText("Approved");
        candidate.setAlternativeText("Approval status: approved");
        presentation.save("identified-shape.pptx", asposeSlides.SaveFormat.Pptx);
    } else {
        console.log("'StatusLabel' is missing or is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

## **Identificar e modificar ajustes predefinidos de forma**

Formas de geometria predefinida podem expor pontos de ajuste que controlam recursos como tamanho de cantos, proporções de setas ou ângulos de arcos. Acesse‑os através da coleção somente‑leitura [GeometryShape.getAdjustments](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/geometryshape/). A própria coleção é fornecida pela forma, mas cada [AdjustValue](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/adjustvalue/) contém um valor que pode ser alterado.

Não confie apenas em um índice fixo da coleção. Percorra os ajustes e inspecione o método somente‑leitura [getType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/adjustvalue/) cujo valor [ShapeAdjustmentType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shapeadjustmenttype/) descreve o que o ajuste controla. O método somente‑leitura [getName](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/adjustvalue/getname/) fornece informações adicionais de identificação e é especialmente útil quando um predefinido contém mais de um ajuste com o mesmo tipo semântico.

Use o método de valor que corresponde ao significado do ajuste:

| Tipo de ajuste | Propósito | Valor a alterar |
|---|---|---|
| `CornerSize` | Tamanho dos cantos arredondados | [setRawValue](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/adjustvalue/setrawvalue/) |
| `ArrowTailThickness` | Espessura da cauda da seta | `setRawValue` |
| `ArrowheadLength` | Comprimento da ponta da seta | `setRawValue` |
| `ArrowheadWidth` | Largura da ponta da seta | `setRawValue` |
| `StartAngle` | Ângulo inicial de um setor ou arco | [setAngleValue](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/adjustvalue/setanglevalue/) |
| `EndAngle` | Ângulo final de um setor ou arco | `setAngleValue` |

`getType` e `getName` retornam informações somente‑leitura. `getRawValue` e `setRawValue` trabalham com um inteiro nas unidades nativas da geometria do predefinido, enquanto `getAngleValue` e `setAngleValue` trabalham com um ângulo em graus. O número, a ordem, o significado e o intervalo válido dos ajustes dependem do predefinido [GeometryShape.getShapeType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/geometryshape/). Um valor válido para um predefinido pode ser inválido ou ter efeito diferente para outro.

Quando `getType` devolve `ShapeAdjustmentType.Custom`, a API não reconhece um significado semântico padrão. Inspecione `getName`, o tipo do predefinido e o valor existente, e deixe o ajuste inalterado a menos que o significado e o intervalo esperados sejam conhecidos. Mesmo para tipos reconhecidos, verifique se o mesmo tipo ocorre mais de uma vez antes de selecionar um valor. O artigo [Connector](/slides/pt/nodejs-java/connector/) mostra essa situação com ajustes de curvatura de conectores.

O exemplo completo a seguir cria versões padrão e modificadas de três formas predefinidas. Ele percorre cada ajuste, relata seu nome e tipo, altera valores relacionados ao tamanho através de `setRawValue`, altera ângulos através de `setAngleValue` e salva o resultado. A coluna da esquerda mantém a geometria padrão; a coluna da direita mostra o retângulo arredondado ajustado, a seta de quatro pontas e o setor.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    // Adiciona cabeçalhos para as colunas de forma padrão e ajustada.
    var defaultColumnLabel = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 20, 250, 30);
    defaultColumnLabel.getTextFrame().setText("Default preset geometry");
    var adjustedColumnLabel = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 390, 20, 250, 30);
    adjustedColumnLabel.getTextFrame().setText("Modified adjustment values");

    slide.getShapes().addAutoShape(asposeSlides.ShapeType.RoundCornerRectangle, 80, 70, 160, 70);
    var modifiedRoundedRectangle = slide.getShapes().addAutoShape(asposeSlides.ShapeType.RoundCornerRectangle, 430, 70, 160, 70);
    modifiedRoundedRectangle.setName("ModifiedRoundedRectangle");

    slide.getShapes().addAutoShape(asposeSlides.ShapeType.QuadArrow, 80, 180, 160, 110);
    var modifiedArrow = slide.getShapes().addAutoShape(asposeSlides.ShapeType.QuadArrow, 430, 180, 160, 110);
    modifiedArrow.setName("ModifiedQuadArrow");

    slide.getShapes().addAutoShape(asposeSlides.ShapeType.Pie, 95, 330, 130, 130);
    var modifiedPie = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Pie, 445, 330, 130, 130);
    modifiedPie.setName("ModifiedPie");

    var shapesToAdjust = [modifiedRoundedRectangle, modifiedArrow, modifiedPie];

    for (var shapeIndex = 0; shapeIndex < shapesToAdjust.length; shapeIndex++) {
        var shape = shapesToAdjust[shapeIndex];
        for (var adjustmentIndex = 0; adjustmentIndex < shape.getAdjustments().size(); adjustmentIndex++) {
            var adjustment = shape.getAdjustments().get_Item(adjustmentIndex);
            console.log(shape.getName() + " / " + adjustment.getName() + ": " + adjustment.getType());

            switch (adjustment.getType()) {
                case asposeSlides.ShapeAdjustmentType.CornerSize:
                    adjustment.setRawValue(5000);
                    break;
                case asposeSlides.ShapeAdjustmentType.ArrowTailThickness:
                    adjustment.setRawValue(25000);
                    break;
                case asposeSlides.ShapeAdjustmentType.ArrowheadLength:
                    adjustment.setRawValue(30000);
                    break;
                case asposeSlides.ShapeAdjustmentType.ArrowheadWidth:
                    adjustment.setRawValue(40000);
                    break;
                case asposeSlides.ShapeAdjustmentType.StartAngle:
                    adjustment.setAngleValue(30);
                    break;
                case asposeSlides.ShapeAdjustmentType.EndAngle:
                    adjustment.setAngleValue(300);
                    break;
                case asposeSlides.ShapeAdjustmentType.Custom:
                    console.log("Custom adjustment '" + adjustment.getName() + "' was not changed.");
                    break;
            }
        }
    }

    presentation.save("preset-shape-adjustments.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Verificar o tipo semântico antes de alterar um valor torna o código explícito quanto à sua intenção e evita assumir que um determinado índice da coleção tem o mesmo significado em diferentes formas predefinidas.

## **Modificar a coleção de formas**

Os métodos de adicionar, clonar, remover e reordenar operam na coleção imediatamente. Se uma operação altera o número ou a ordem das formas, não continue a confiar em índices capturados antes dessa operação.

### **Clonar uma forma**

[addClone](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shapecollection/addclone/) cria uma cópia independente e a anexa à coleção de destino. [insertClone](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shapecollection/insertclone/) também cria uma cópia, mas a coloca em um índice de ordem Z especificado. As sobrecargas que aceitam coordenadas movem o clone sem mudar seu tamanho; as sobrecargas com largura e altura podem redimensioná‑lo também.

O exemplo cria um slide de destino, clona um retângulo rotulado para a frente e insere um segundo clone na parte de trás. Alterações em qualquer clone não modificam a forma original.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var sourceSlide = presentation.getSlides().get_Item(0);
    var sourceShape = sourceSlide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 180, 60);
    sourceShape.setName("SourceLabel");
    sourceShape.getTextFrame().setText("Source");

    var blankLayout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(java.newByte(asposeSlides.SlideLayoutType.Blank));
    var destinationSlide = presentation.getSlides().addEmptySlide(blankLayout);

    var frontClone = destinationSlide.getShapes().addClone(sourceShape, 80, 80);
    frontClone.setName("FrontClone");
    if (java.instanceOf(frontClone, "com.aspose.slides.AutoShape")) {
        frontClone.getTextFrame().setText("Front clone");
    } else {
        console.log("The front clone is not an AutoShape; its text was not changed.");
    }

    var backClone = destinationSlide.getShapes().insertClone(0, sourceShape, 80, 180);
    backClone.setName("BackClone");
    if (java.instanceOf(backClone, "com.aspose.slides.AutoShape")) {
        backClone.getTextFrame().setText("Back clone");
    } else {
        console.log("The back clone is not an AutoShape; its text was not changed.");
    }

    presentation.save("cloned-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Clonar copia o conteúdo e a formatação da forma, incluindo seu nome e texto alternativo. Atribua novos identificadores lógicos ao clone quando esses valores precisarem ser únicos. Recursos usados por formas complexas são tratados pela apresentação, mas um clone permanece um novo item da coleção com uma nova identidade de forma.

### **Remover formas**

[remove](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shapecollection/remove/) exclui um objeto de forma específico da sua coleção. Ao remover múltiplas correspondências durante iteração indexada, percorra do final para que cada índice restante permaneça válido.

Este exemplo remove todas as formas com um nome designado. Ele lê a forma no índice atual e não assume um tipo de forma específico.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var keepShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 140, 60);
    keepShape.setName("Keep");

    var firstTemporaryShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 220, 40, 80, 80);
    firstTemporaryShape.setName("Temporary");

    var secondTemporaryShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Triangle, 340, 40, 100, 80);
    secondTemporaryShape.setName("Temporary");

    for (var i = slide.getShapes().size() - 1; i >= 0; i--) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "Temporary") {
            slide.getShapes().remove(shape);
        }
    }

    presentation.save("removed-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Após a remoção, a contagem de formas e os índices das formas posteriores mudam. Referências a formas não afetadas permanecem mais confiáveis que índices salvos. Também considere conectores, animações e outros recursos da apresentação que possam referir‑se ao objeto removido; remover uma forma visível pode mudar mais do que a aparência do slide.

### **Ocultar uma forma**

Definir [Hidden](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/sethidden/) como `true` mantém a forma na coleção, mas impede que ela apareça na apresentação normal. Seu índice, formatação e conteúdo permanecem disponíveis ao código, de modo que ocultar é adequado para elementos opcionais que podem ser restaurados posteriormente.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var visibleShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 160, 60);
    visibleShape.setName("VisibleLabel");

    var optionalShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Moon, 240, 40, 100, 100);
    optionalShape.setName("OptionalDecoration");

    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "OptionalDecoration") {
            shape.setHidden(true);
        }
    }

    presentation.save("hidden-shape.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ocultar não é exclusão nem segurança. O objeto ainda pode ser descoberto e tornado visível novamente por um usuário ou por código, e continua parte do arquivo da apresentação.

### **Alterar a ordem Z**

Formas sobrepostas são pintadas na ordem da coleção. [reorder](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shapecollection/reorder/) move uma forma existente para um índice alvo sem cloná‑la. O índice `0` é o fundo; `size() - 1` é a frente.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var blueRectangle = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 100, 100, 220, 120);
    blueRectangle.setName("BlueRectangle");
    blueRectangle.getFillFormat().setFillType(java.newByte(asposeSlides.FillType.Solid));
    blueRectangle.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    var orangeEllipse = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 180, 140, 220, 120);
    orangeEllipse.setName("OrangeEllipse");
    orangeEllipse.getFillFormat().setFillType(java.newByte(asposeSlides.FillType.Solid));
    orangeEllipse.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));

    slide.getShapes().reorder(slide.getShapes().size() - 1, blueRectangle);
    presentation.save("reordered-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O retângulo é criado primeiro e inicialmente fica atrás da elipse. Movê‑lo para o índice final coloca‑o à frente. Finalize a ordem Z depois de adicionar ou clonar todas as formas relacionadas, pois essas operações adicionam ou inserem novos itens na coleção e podem alterar a pilha pretendida.

## **Inspecionar formas em slides de layout**

Slides normais, slides de layout e slides mestre têm coleções de formas separadas. Uma forma em uma coleção de layout não é o mesmo objeto que uma forma posicionada de forma semelhante em um slide normal. Inspecione formas de layout quando precisar entender ou mudar a formatação fornecida por um layout.

O exemplo a seguir lê o [FillFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/getfillformat/) e o [LineFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/getlineformat/) de cada forma de layout sem presumir que toda forma seja um `AutoShape`.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    for (var i = 0; i < presentation.getLayoutSlides().size(); i++) {
        var layoutSlide = presentation.getLayoutSlides().get_Item(i);
        for (var j = 0; j < layoutSlide.getShapes().size(); j++) {
            var shape = layoutSlide.getShapes().get_Item(j);
            var fillType = shape.getFillFormat().getFillType();
            var lineWidth = shape.getLineFormat().getWidth();
            console.log(layoutSlide.getName() + " / " + shape.getName() + ": fill=" + fillType + ", line width=" + lineWidth);
        }
    }
} finally {
    presentation.dispose();
}
```

Editar um layout pode afetar múltiplos slides que o utilizam. Antes de mudar uma forma de layout, determine se um slide normal herda o objeto ou contém uma sobrescrita local, e teste cada slide que usa esse layout.

## **Exportar uma forma para SVG**

[writeAsSvg](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/writeassvg/) grava o conteúdo renderizado de uma forma em um fluxo. O resultado contém apenas a forma, não o fundo inteiro do slide nem as formas vizinhas.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() === 0) {
        console.log("Slide 1 does not contain a shape to export.");
    } else {
        var shape = slide.getShapes().get_Item(0);
        var svgStream = null;
        try {
            svgStream = java.newInstanceSync("java.io.FileOutputStream", "shape.svg");
            shape.writeAsSvg(svgStream);
        } catch (error) {
            console.log("The SVG file could not be written: " + error.message);
        } finally {
            if (svgStream !== null) {
                svgStream.close();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Mantenha a apresentação aberta enquanto renderiza. A saída depende da formatação da forma e de recursos como fontes e imagens. Se precisar de toda a composição, exporte o slide em vez de uma forma individual. O chamador possui o fluxo e deve fechá‑lo.

## **Alinhar formas**

Os overloads de [SlideUtil.alignShapes](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slideutil/alignshapes/) alinham todas as formas ou índices de coleção selecionados. [ShapesAlignmentType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shapesalignmenttype/) especifica a borda, a linha central ou o modo de distribuição. Defina `alignToSlide` como `true` para usar as bordas do slide; defina como `false` para alinhar as formas selecionadas em relação umas às outras.

Este exemplo alinha três formas ao topo do slide. As referências de forma retornadas são convertidas para seus índices atuais imediatamente antes do alinhamento.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var firstShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 60, 80, 120, 50);
    var secondShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 240, 160, 120, 50);
    var thirdShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Triangle, 420, 240, 120, 50);
    firstShape.setName("FirstAlignedShape");
    secondShape.setName("SecondAlignedShape");
    thirdShape.setName("ThirdAlignedShape");

    var shapeIndexes = java.newArray("int", [slide.getShapes().indexOf(firstShape), slide.getShapes().indexOf(secondShape), slide.getShapes().indexOf(thirdShape)]);

    asposeSlides.SlideUtil.alignShapes(asposeSlides.ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
    presentation.save("aligned-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Alinhamento altera posições, não a ordem Z. Alinhamento relativo normalmente requer ao menos duas formas, enquanto distribuição horizontal ou vertical requer formas suficientes para definir o espaçamento. Recalcule os índices se modificar a coleção antes de chamar o método.

## **Inverter uma forma**

A classe [ShapeFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shapeframe/) armazena posição, tamanho, configurações de inversão horizontal e vertical e rotação. Seus valores `getFlipH` e `getFlipV` usam [NullableBool](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/nullablebool/): `True` habilita a inversão, `False` a desabilita, e `NotDefined` preserva o estado não especificado/padrão.

A apresentação de entrada abaixo contém uma forma não invertida.

![The shape before flipping](shape_to_be_flipped.png)

O exemplo preserva todos os demais valores de frame e substitui apenas as duas configurações de inversão. Isso é importante porque atribuir um novo [Frame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/setframe/) substitui todo o frame.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    var frame = shape.getFrame();

    console.log("Horizontal flip before change: " + frame.getFlipH());
    console.log("Vertical flip before change: " + frame.getFlipV());

    var changedFrame = new asposeSlides.ShapeFrame(java.newFloat(frame.getX()), java.newFloat(frame.getY()), java.newFloat(frame.getWidth()), java.newFloat(frame.getHeight()), java.newByte(asposeSlides.NullableBool.True), java.newByte(asposeSlides.NullableBool.True), java.newFloat(frame.getRotation()));
    shape.setFrame(changedFrame);

    presentation.save("flipped-shape.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A forma salva é espelhada horizontal e verticalmente, mantendo sua posição, tamanho e rotação.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Devo usar um índice de coleção como identificador de forma?**

Apenas para processamento de curta duração quando a coleção não mudará antes do uso do índice. Prefira uma convenção validada de `Name` ou `AlternativeText` para modelos criados, ou `OfficeInteropShapeId` para trabalho de interop com escopo de slide.

**Ocultar uma forma a remove da ordem Z?**

Não. Uma forma oculta permanece na coleção no mesmo índice. Ela pode ser encontrada, reordenada, editada ou tornada visível novamente.

**Por que uma forma clonada apareceu à frente de outra forma?**

`addClone` anexa o clone ao final da coleção, que é a frente da ordem Z. Use `insertClone` para escolher o índice inicial ou `reorder` após todas as formas terem sido adicionadas.

**Posso usar um índice fixo para identificar um ajuste predefinido de forma?**

Somente após validar o predefinido exato e o layout da coleção. Prefira percorrer `GeometryShape.getAdjustments` e verificar `AdjustValue.getType`; use `AdjustValue.getName` como informação adicional quando o mesmo tipo semântico aparecer mais de uma vez.