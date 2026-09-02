---
title: Gerenciar Formas de Apresentação em Java
linktitle: Manipulação de Formas
type: docs
weight: 40
url: /pt/java/shape-manipulations/
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
- Java
- Aspose.Slides
description: "Aprenda a identificar, ajustar, clonar, remover, ocultar, reorganizar, exportar, alinhar e inverter formas de apresentação com Aspose.Slides para Java."
---
## **Visão geral**

Aspose.Slides for Java representa as formas em um slide como uma **[IShapeCollection](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ishapecollection/)** ordenada. A coleção é tanto o local onde você encontra e modifica formas quanto a fonte da sua ordem de empilhamento: o índice `0` corresponde à forma mais ao fundo, enquanto o último índice corresponde à forma mais à frente.

Este artigo segue esse modelo. Primeiro explica como identificar uma forma de forma confiável e modificar pontos de ajuste predefinidos da forma, depois mostra como clonar, remover, ocultar e reordenar formas. As seções finais cobrem formatação em nível de layout, exportação SVG, alinhamento e configurações de inversão. Cada exemplo é independente, de modo que você pode usar apenas as operações que seu fluxo de trabalho requer.

## **Identificar e localizar formas**

Os índices da coleção são convenientes ao processar um arquivo conhecido, mas não são identificadores estáveis. Inserir, remover ou reordenar uma forma pode mudar seu índice. Escolha um identificador de acordo com a forma como a apresentação é criada e mantida:

- **[Name](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ishape/#getName--)** é útil para modelos controlados por desenvolvedor e é fácil de inspecionar no painel de seleção do PowerPoint. Nomes podem ser editados e não são garantidos como únicos, portanto estabeleça uma convenção de nomenclatura se o código depender deles.
- **[AlternativeText](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ishape/#getAlternativeText--)** é útil quando uma descrição de acessibilidade ou uma tag fornecida pelo autor já identifica a forma. É visível para os usuários, pode ser localizado ou reescrito para acessibilidade e não é garantido como único. Não reutilize silenciosamente textos de acessibilidade significativos como chave de banco de dados.
- **[OfficeInteropShapeId](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--)** é um identificador somente leitura que é único dentro de um slide e corresponde ao ID de forma usado pela interoperabilidade do PowerPoint. Use‑o ao integrar com o PowerPoint ou quando precisar de uma referência inequívoca durante a vida útil de uma forma. Uma forma clonada ou recriada é uma forma diferente e recebe seu próprio ID.

O método relacionado **[getUniqueId](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ishape/#getUniqueId--)** devolve um identificador com escopo de apresentação, mas esse identificador destina‑se a complementos e pode ser reatribuído. Não deve ser tratado como uma chave externa permanente. Se a identidade a longo prazo for essencial, mantenha o mapeamento nos dados da aplicação e valide se a forma esperada ainda existe.

O exemplo a seguir pesquisa por nome com comparação exata e relata o ID de interop com escopo de slide. Quando o modelo não contém a forma esperada, o código relata esse resultado em vez de continuar com o objeto errado.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape targetShape = null;
    for (IShape shape : slide.getShapes()) {
        if ("RevenueChart".equals(shape.getName())) {
            targetShape = shape;
            break;
        }
    }

    if (targetShape == null) {
        System.out.println("The shape 'RevenueChart' was not found on slide 1.");
    } else {
        System.out.println("Found " + targetShape.getName() + "; interop ID: " + targetShape.getOfficeInteropShapeId());
    }
} finally {
    presentation.dispose();
}
```

Quando uma operação é específica a um tipo de forma, verifique a interface antes de usar membros específicos do tipo. Este exemplo atualiza texto e texto alternativo somente se o objeto nomeado for um **[IAutoShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iautoshape/)**.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape candidate = null;
    for (IShape shape : slide.getShapes()) {
        if ("StatusLabel".equals(shape.getName())) {
            candidate = shape;
            break;
        }
    }

    if (candidate instanceof IAutoShape) {
        IAutoShape autoShape = (IAutoShape) candidate;
        autoShape.getTextFrame().setText("Approved");
        autoShape.setAlternativeText("Approval status: approved");
        presentation.save("identified-shape.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("'StatusLabel' is missing or is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

## **Identificar e modificar ajustes predefinidos de forma**

Formas de geometria predefinida podem expor pontos de ajuste que controlam recursos como tamanho de canto, proporções de seta ou ângulos de arco. Acesse‑os através da coleção somente leitura **[IGeometryShape.getAdjustments](https://reference.aspose.com/slides/pt/java/com.aspose.slides/igeometryshape/#getAdjustments--)**. A própria coleção é fornecida pela forma, mas cada **[IAdjustValue](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iadjustvalue/)** contém um valor que pode ser alterado.

Não dependa apenas de um índice fixo da coleção. Percorra os ajustes e inspecione o método somente leitura **[getType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iadjustvalue/#getType--)**, cujo valor **[ShapeAdjustmentType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/shapeadjustmenttype/)** descreve o que o ajuste controla. O método somente leitura **[getName](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iadjustvalue/#getName--)** fornece informações adicionais de identificação e é especialmente útil quando um predefinido contém mais de um ajuste com o mesmo tipo semântico.

Use o método de valor que coincide com o significado do ajuste:

| Tipo de ajuste | Propósito | Valor a alterar |
|---|---|---|
| `CornerSize` | Tamanho dos cantos arredondados | [setRawValue](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iadjustvalue/#setRawValue-long-) |
| `ArrowTailThickness` | Espessura da cauda da seta | `setRawValue` |
| `ArrowheadLength` | Comprimento da cabeça da seta | `setRawValue` |
| `ArrowheadWidth` | Largura da cabeça da seta | `setRawValue` |
| `StartAngle` | Ângulo inicial de uma fatia ou arco | [setAngleValue](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iadjustvalue/#setAngleValue-float-) |
| `EndAngle` | Ângulo final de uma fatia ou arco | `setAngleValue` |

`getType` e `getName` retornam informações somente leitura. `getRawValue` e `setRawValue` trabalham com um inteiro nas unidades nativas de geometria do predefinido, enquanto `getAngleValue` e `setAngleValue` trabalham com ângulo em graus. O número, a ordem, o significado e o intervalo válido dos ajustes dependem do predefinido **[ShapeType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/igeometryshape/#getShapeType--)**. Um valor válido para um predefinido pode ser inválido ou ter efeito diferente para outro.

Quando `getType` retorna `ShapeAdjustmentType.Custom`, a API não reconhece um significado semântico padrão. Inspecione `getName`, o tipo do predefinido e o valor existente, e deixe o ajuste inalterado a menos que o significado e o intervalo esperados sejam conhecidos. Mesmo para tipos reconhecidos, verifique se o mesmo tipo ocorre mais de uma vez antes de selecionar um valor. O artigo **[Connector](/slides/pt/java/connector/)** mostra essa situação com ajustes de curvatura de conectores.

O exemplo completo a seguir cria versões padrão e modificadas de três formas predefinidas. Ele percorre cada ajuste, relata seu nome e tipo, altera valores relacionados ao tamanho através de `setRawValue`, altera ângulos através de `setAngleValue` e salva o resultado. A coluna da esquerda mantém a geometria padrão; a coluna da direita mostra o retângulo arredondado ajustado, a seta de quatro vias e a fatia.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Adiciona cabeçalhos para as colunas de formas padrão e ajustadas.
    IAutoShape defaultColumnLabel = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 20, 250, 30);
    defaultColumnLabel.getTextFrame().setText("Default preset geometry");
    IAutoShape adjustedColumnLabel = slide.getShapes().addAutoShape(ShapeType.Rectangle, 390, 20, 250, 30);
    adjustedColumnLabel.getTextFrame().setText("Modified adjustment values");

    slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 80, 70, 160, 70);
    IGeometryShape modifiedRoundedRectangle = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 430, 70, 160, 70);
    modifiedRoundedRectangle.setName("ModifiedRoundedRectangle");

    slide.getShapes().addAutoShape(ShapeType.QuadArrow, 80, 180, 160, 110);
    IGeometryShape modifiedArrow = slide.getShapes().addAutoShape(ShapeType.QuadArrow, 430, 180, 160, 110);
    modifiedArrow.setName("ModifiedQuadArrow");

    slide.getShapes().addAutoShape(ShapeType.Pie, 95, 330, 130, 130);
    IGeometryShape modifiedPie = slide.getShapes().addAutoShape(ShapeType.Pie, 445, 330, 130, 130);
    modifiedPie.setName("ModifiedPie");

    IGeometryShape[] shapesToAdjust = {
        modifiedRoundedRectangle,
        modifiedArrow,
        modifiedPie
    };

    for (IGeometryShape shape : shapesToAdjust) {
        for (int adjustmentIndex = 0; adjustmentIndex < shape.getAdjustments().size(); adjustmentIndex++) {
            IAdjustValue adjustment = shape.getAdjustments().get_Item(adjustmentIndex);
            System.out.println(shape.getName() + " / " + adjustment.getName() + ": " + adjustment.getType());

            switch (adjustment.getType()) {
                case ShapeAdjustmentType.CornerSize:
                    adjustment.setRawValue(5000);
                    break;
                case ShapeAdjustmentType.ArrowTailThickness:
                    adjustment.setRawValue(25000);
                    break;
                case ShapeAdjustmentType.ArrowheadLength:
                    adjustment.setRawValue(30000);
                    break;
                case ShapeAdjustmentType.ArrowheadWidth:
                    adjustment.setRawValue(40000);
                    break;
                case ShapeAdjustmentType.StartAngle:
                    adjustment.setAngleValue(30);
                    break;
                case ShapeAdjustmentType.EndAngle:
                    adjustment.setAngleValue(300);
                    break;
                case ShapeAdjustmentType.Custom:
                    System.out.println("Custom adjustment '" + adjustment.getName() + "' was not changed.");
                    break;
            }
        }
    }

    presentation.save("preset-shape-adjustments.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Verificar o tipo semântico antes de mudar um valor torna o código explícito quanto à sua intenção e evita assumir que um determinado índice da coleção tem o mesmo significado em diferentes formas predefinidas.

## **Modificar a coleção de formas**

Os métodos de adicionar, clonar, remover e reordenar operam na coleção imediatamente. Se uma operação altera o número ou a ordem das formas, não continue confiando em índices capturados antes dessa operação.

### **Clonar uma forma**

**[addClone](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-)** cria uma cópia independente e a anexa à coleção de destino. **[insertClone](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-)** também cria uma cópia, mas a coloca em um índice de ordem Z especificado. As sobrecargas que aceitam coordenadas movem o clone sem mudar seu tamanho; as sobrecargas com largura e altura podem redimensioná‑lo também.

O exemplo cria um slide de destino, clona um retângulo rotulado para a frente e insere um segundo clone na parte de trás. Alterações em qualquer clone não modificam a forma original.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide sourceSlide = presentation.getSlides().get_Item(0);
    IAutoShape sourceShape = sourceSlide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 180, 60);
    sourceShape.setName("SourceLabel");
    sourceShape.getTextFrame().setText("Source");

    ILayoutSlide blankLayout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank);
    ISlide destinationSlide = presentation.getSlides().addEmptySlide(blankLayout);

    IShape frontCloneShape = destinationSlide.getShapes().addClone(sourceShape, 80, 80);
    frontCloneShape.setName("FrontClone");
    if (frontCloneShape instanceof IAutoShape) {
        IAutoShape frontClone = (IAutoShape) frontCloneShape;
        frontClone.getTextFrame().setText("Front clone");
    } else {
        System.out.println("The front clone is not an AutoShape; its text was not changed.");
    }

    IShape backCloneShape = destinationSlide.getShapes().insertClone(0, sourceShape, 80, 180);
    backCloneShape.setName("BackClone");
    if (backCloneShape instanceof IAutoShape) {
        IAutoShape backClone = (IAutoShape) backCloneShape;
        backClone.getTextFrame().setText("Back clone");
    } else {
        System.out.println("The back clone is not an AutoShape; its text was not changed.");
    }

    presentation.save("cloned-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Clonar copia o conteúdo e a formatação da forma, incluindo seu nome e texto alternativo. Atribua novos identificadores lógicos ao clone quando esses valores precisarem ser únicos. Recursos usados por formas complexas são gerenciados pela apresentação, mas um clone continua sendo um novo item da coleção com uma nova identidade de forma.

### **Remover formas**

**[remove](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-)** exclui um objeto de forma específico de sua coleção. Ao remover múltiplas correspondências durante uma iteração indexada, percorra do final para que cada índice restante permaneça válido.

Este exemplo remove todas as formas com um nome designado. Ele lê a forma no índice atual, não um item fixo da coleção, e não faz casting desnecessário da forma.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape keepShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 140, 60);
    keepShape.setName("Keep");

    IAutoShape firstTemporaryShape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 220, 40, 80, 80);
    firstTemporaryShape.setName("Temporary");

    IAutoShape secondTemporaryShape = slide.getShapes().addAutoShape(ShapeType.Triangle, 340, 40, 100, 80);
    secondTemporaryShape.setName("Temporary");

    for (int i = slide.getShapes().size() - 1; i >= 0; i--) {
        IShape shape = slide.getShapes().get_Item(i);
        if ("Temporary".equals(shape.getName())) {
            slide.getShapes().remove(shape);
        }
    }

    presentation.save("removed-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Após a remoção, a contagem de formas e os índices das formas posteriores mudam. Referências a formas não afetadas permanecem mais confiáveis que índices salvos. Considere também conectores, animações e outros recursos da apresentação que podem referir‑se ao objeto removido; remover uma forma visível pode mudar mais do que a aparência do slide.

### **Ocultar uma forma**

Definir **[Hidden](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ishape/#setHidden-boolean-)** como `true` mantém a forma na coleção, mas impede que ela apareça na exibição normal de slides. Seu índice, formatação e conteúdo permanecem disponíveis ao código, de modo que ocultar é apropriado para elementos opcionais que podem ser restaurados posteriormente.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape visibleShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 160, 60);
    visibleShape.setName("VisibleLabel");

    IAutoShape optionalShape = slide.getShapes().addAutoShape(ShapeType.Moon, 240, 40, 100, 100);
    optionalShape.setName("OptionalDecoration");

    for (IShape shape : slide.getShapes()) {
        if ("OptionalDecoration".equals(shape.getName())) {
            shape.setHidden(true);
        }
    }

    presentation.save("hidden-shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ocultar não é exclusão nem segurança. O objeto ainda pode ser descoberto e tornar‑se visível novamente por um usuário ou por código, e continua fazendo parte do arquivo da apresentação.

### **Alterar a ordem Z**

Formas sobrepostas são pintadas na ordem da coleção. **[reorder](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-)** move uma forma existente para um índice alvo sem cloná‑la. O índice `0` está ao fundo; `size() - 1` está à frente.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape blueRectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 220, 120);
    blueRectangle.setName("BlueRectangle");
    blueRectangle.getFillFormat().setFillType(FillType.Solid);
    blueRectangle.getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    IAutoShape orangeEllipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 180, 140, 220, 120);
    orangeEllipse.setName("OrangeEllipse");
    orangeEllipse.getFillFormat().setFillType(FillType.Solid);
    orangeEllipse.getFillFormat().getSolidFillColor().setColor(Color.ORANGE);

    slide.getShapes().reorder(slide.getShapes().size() - 1, blueRectangle);
    presentation.save("reordered-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O retângulo é criado primeiro e inicialmente fica atrás da elipse. Movê‑lo para o índice final coloca‑o à frente. Finalize a ordem Z depois de adicionar ou clonar todas as formas relacionadas, pois essas operações anexam ou inserem novos itens na coleção e podem alterar a pilha pretendida.

## **Inspecionar formas em slides de layout**

Slides normais, slides de layout e slides mestre têm coleções de formas separadas. Uma forma em uma coleção de layout não é o mesmo objeto que uma forma posicionada de forma semelhante em um slide normal. Inspecione as formas de layout quando precisar entender ou alterar a formatação fornecida por um layout.

O exemplo a seguir lê o **[FillFormat](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ishape/#getFillFormat--)** e o **[LineFormat](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ishape/#getLineFormat--)** de cada forma de layout sem supor que cada forma seja uma `AutoShape`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ILayoutSlide layoutSlide : presentation.getLayoutSlides()) {
        for (IShape shape : layoutSlide.getShapes()) {
            int fillType = shape.getFillFormat().getFillType();
            double lineWidth = shape.getLineFormat().getWidth();
            System.out.println(layoutSlide.getName() + " / " + shape.getName() + ": fill=" + fillType + ", line width=" + lineWidth);
        }
    }
} finally {
    presentation.dispose();
}
```

Editar um layout pode afetar múltiplos slides que o utilizam. Antes de mudar uma forma de layout, determine se um slide normal herda o objeto ou contém uma sobrescrita local, e teste cada slide que usa esse layout.

## **Exportar uma forma para SVG**

**[writeAsSvg](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-)** grava o conteúdo renderizado de uma forma em um fluxo. O resultado contém a forma, não o fundo inteiro do slide nem formas vizinhas.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() == 0) {
        System.out.println("Slide 1 does not contain a shape to export.");
    } else {
        IShape shape = slide.getShapes().get_Item(0);
        try (FileOutputStream svgStream = new FileOutputStream("shape.svg")) {
            shape.writeAsSvg(svgStream);
        } catch (IOException exception) {
            System.out.println("The SVG file could not be written: " + exception.getMessage());
        }
    }
} finally {
    presentation.dispose();
}
```

Mantenha a apresentação aberta durante a renderização. A saída depende da formatação da forma e de recursos como fontes e imagens. Se precisar da composição completa, exporte o slide em vez de uma forma individual. O chamador possui o fluxo e deve fechá‑lo.

## **Alinhar formas**

Os **[SlideUtil.alignShapes](https://reference.aspose.com/slides/pt/java/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-)** têm sobrecargas que alinham todas as formas ou índices de coleção selecionados. **[ShapesAlignmentType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/shapesalignmenttype/)** especifica a borda, linha central ou modo de distribuição. Defina `alignToSlide` como `true` para usar as bordas do slide; defina como `false` para alinhar as formas selecionadas entre si.

Este exemplo alinha três formas à borda superior do slide. As referências de forma retornadas são convertidas para seus índices atuais imediatamente antes do alinhamento.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape firstShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 60, 80, 120, 50);
    IAutoShape secondShape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 240, 160, 120, 50);
    IAutoShape thirdShape = slide.getShapes().addAutoShape(ShapeType.Triangle, 420, 240, 120, 50);
    firstShape.setName("FirstAlignedShape");
    secondShape.setName("SecondAlignedShape");
    thirdShape.setName("ThirdAlignedShape");

    int[] shapeIndexes = {slide.getShapes().indexOf(firstShape), slide.getShapes().indexOf(secondShape), slide.getShapes().indexOf(thirdShape)};

    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
    presentation.save("aligned-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Alinhamento altera posições, não a ordem Z. O alinhamento relativo normalmente requer pelo menos duas formas, enquanto a distribuição horizontal ou vertical requer formas suficientes para definir o espaçamento. Recalcule os índices se modificar a coleção antes de chamar o método.

## **Inverter uma forma**

A classe **[ShapeFrame](https://reference.aspose.com/slides/pt/java/com.aspose.slides/shapeframe/)** armazena posição, tamanho, configurações de inversão horizontal e vertical, e rotação. Seus valores `getFlipH` e `getFlipV` usam **[NullableBool](https://reference.aspose.com/slides/pt/java/com.aspose.slides/nullablebool/)**: `True` habilita a inversão, `False` a desabilita, e `NotDefined` preserva o estado não especificado/padrão.

A apresentação de entrada abaixo contém uma forma não invertida.

![The shape before flipping](shape_to_be_flipped.png)

O exemplo preserva todos os demais valores de frame e substitui apenas as duas configurações de inversão. Isso é importante porque atribuir um novo **[Frame](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-)** substitui o frame completo.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IShapeFrame frame = shape.getFrame();

    System.out.println("Horizontal flip before change: " + frame.getFlipH());
    System.out.println("Vertical flip before change: " + frame.getFlipV());

    shape.setFrame(new ShapeFrame(frame.getX(), frame.getY(), frame.getWidth(), frame.getHeight(), NullableBool.True, NullableBool.True, frame.getRotation()));

    presentation.save("flipped-shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A forma salva fica espelhada horizontal e verticalmente, mantendo sua posição, tamanho e rotação.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Devo usar um índice de coleção como identificador de forma?**

Somente para processamento de curta duração quando a coleção não mudará antes do uso do índice. Prefira uma convenção validada de `Name` ou `AlternativeText` para modelos criados, ou `OfficeInteropShapeId` para trabalho de interop focado em slides.

**Ocultar uma forma a remove da ordem Z?**

Não. Uma forma oculta permanece na coleção no mesmo índice. Ela pode ser encontrada, reordenada, editada ou tornada visível novamente.

**Por que uma forma clonada apareceu à frente de outra forma?**

`addClone` anexa o clone ao final da coleção, que é a frente da ordem Z. Use `insertClone` para escolher o índice inicial ou `reorder` depois que todas as formas forem adicionadas.

**Posso usar um índice fixo para identificar um ajuste predefinido de forma?**

Somente após validar o predefinido exato e o layout da coleção. Prefira percorrer `IGeometryShape.getAdjustments` e verificar `IAdjustValue.getType`; use `IAdjustValue.getName` como informação adicional quando o mesmo tipo semântico aparecer mais de uma vez.