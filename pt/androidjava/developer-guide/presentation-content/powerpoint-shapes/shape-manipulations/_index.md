---
title: Gerenciar formas de apresentação no Android
linktitle: Manipulação de Formas
type: docs
weight: 40
url: /pt/androidjava/shape-manipulations/
keywords:
- Forma do PowerPoint
- Forma de apresentação
- Forma no slide
- Encontrar forma
- Clonar forma
- Remover forma
- Ocultar forma
- Alterar ordem da forma
- Obter ID da forma interop
- Texto alternativo da forma
- Formatos de layout da forma
- Forma como SVG
- Forma para SVG
- Alinhar forma
- Inverter forma
- PowerPoint
- apresentação
- Android
- Java
- Aspose.Slides
description: "Aprenda como identificar, clonar, remover, ocultar, reordenar, exportar, alinhar e inverter formas de apresentação com Aspose.Slides for Android via Java."
---
## **Visão geral**

Aspose.Slides for Android via Java representa as formas em um slide como uma [IShapeCollection](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ishapecollection/) ordenada. A coleção é tanto o local onde você encontra e modifica formas quanto a fonte da sua ordem de empilhamento: o índice `0` corresponde à forma mais ao fundo, enquanto o último índice corresponde à forma mais ao frente.

Este artigo segue esse modelo. Primeiro explica como identificar uma forma de maneira confiável, depois mostra como clonar, remover, ocultar e reordenar formas. As seções finais abordam formatação em nível de layout, exportação SVG, alinhamento e configurações de inversão. Cada exemplo é independente, permitindo usar apenas as operações necessárias ao seu fluxo de trabalho.

## **Identificar e localizar formas**

Os índices da coleção são convenientes ao processar um arquivo conhecido, mas não são identificadores estáveis. Adicionar, remover ou reordenar uma forma pode mudar seu índice. Escolha um identificador de acordo com a forma como a apresentação é criada e mantida:

- **Name** é útil para modelos controlados por desenvolvedor e fácil de inspecionar no Painel de Seleção do PowerPoint. Os nomes podem ser editados e não são garantidos como únicos, portanto estabeleça uma convenção de nomenclatura se o código depender deles.
- **AlternativeText** é útil quando uma descrição de acessibilidade ou uma tag fornecida pelo autor já identifica a forma. É visível aos usuários, pode ser localizado ou reescrito para acessibilidade e não é garantido como único. Não reutilize silenciosamente texto de acessibilidade significativo como chave de banco de dados.
- **OfficeInteropShapeId** é um identificador somente‑leitura que é único dentro de um slide e corresponde ao ID de forma usado pela interoperabilidade do PowerPoint. Use‑o ao integrar com o PowerPoint ou quando precisar de uma referência inequívoca durante a vida útil de uma forma. Uma forma clonada ou recriada é uma forma diferente e recebe seu próprio ID.

O método relacionado [getUniqueId](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ishape/#getUniqueId--) devolve um identificador com escopo de apresentação, mas esse identificador destina‑se a complementos e pode ser reatribuído. Não deve ser tratado como uma chave externa permanente. Se a identidade de longo prazo for essencial, mantenha o mapeamento nos dados da aplicação e valide se a forma esperada ainda existe.

O exemplo a seguir pesquisa por nome com comparação exata e relata o ID de interop no escopo do slide. Quando o modelo não contém a forma esperada, o código relata esse resultado em vez de continuar com o objeto incorreto.

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

Quando uma operação é específica a um tipo de forma, verifique a interface antes de usar membros específicos do tipo. Este exemplo atualiza o texto e o texto alternativo apenas se o objeto nomeado for um [IAutoShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iautoshape/).

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

## **Modificar a coleção de formas**

Os métodos de adicionar, clonar, remover e reordenar operam sobre a coleção imediatamente. Se uma operação alterar o número ou a ordem das formas, não continue a depender de índices capturados antes dessa operação.

### **Clonar uma forma**

[addClone](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) cria uma cópia independente e a anexa à coleção de destino. [insertClone](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) também cria uma cópia, mas a coloca em um índice de ordem Z especificado. As sobrecargas que aceitam coordenadas movem a cópia sem alterar seu tamanho; as sobrecargas com largura e altura podem redimensioná‑la também.

O exemplo cria um slide de destino, clona um retângulo rotulado para a frente e insere um segundo clone no fundo. Alterações em qualquer um dos clones não modificam a forma original.

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

Clonar copia o conteúdo e a formatação da forma, incluindo seu nome e texto alternativo. Atribua novos identificadores lógicos ao clone quando esses valores precisarem ser únicos. Recursos usados por formas complexas são gerenciados pela apresentação, mas um clone permanece como um novo item da coleção com uma nova identidade de forma.

### **Remover formas**

[remove](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) exclui um objeto forma específico da sua coleção. Ao remover várias correspondências durante iteração indexada, percorra do final para que cada índice restante permaneça válido.

Este exemplo remove todas as formas com um nome designado. Ele lê a forma no índice atual, não um item fixo da coleção, e não faz cast desnecessário da forma.

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

Após a remoção, a contagem de formas e os índices das formas subsequentes mudam. Referências a formas não afetadas permanecem mais confiáveis que índices armazenados. Considere também conectores, animações e outros recursos da apresentação que possam referenciar o objeto removido; remover uma forma visível pode mudar mais do que a aparência do slide.

### **Ocultar uma forma**

Definir [Hidden](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ishape/#setHidden-boolean-) como `true` mantém a forma na coleção, mas impede que ela apareça na apresentação normal. Seu índice, formatação e conteúdo permanecem disponíveis ao código, portanto ocultar é adequado para elementos opcionais que podem ser restaurados posteriormente.

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

Ocultar não é exclusão nem segurança. O objeto ainda pode ser descoberto e tornado visível novamente por um usuário ou por código, e continua fazendo parte do arquivo da apresentação.

### **Alterar a ordem Z**

Formas sobrepostas são pintadas na ordem da coleção. [reorder](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) move uma forma existente para um índice alvo sem cloná‑la. O índice `0` está no fundo; `size() - 1` está na frente.

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
    orangeEllipse.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    slide.getShapes().reorder(slide.getShapes().size() - 1, blueRectangle);
    presentation.save("reordered-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O retângulo é criado primeiro e inicialmente fica atrás da elipse. Movê‑lo para o índice final o coloca na frente. Finalize a ordem Z após adicionar ou clonar todas as formas relacionadas, pois essas operações anexam ou inserem novos itens na coleção e podem alterar a pilha pretendida.

## **Inspecionar formas em slides de layout**

Slides normais, slides de layout e slides mestre possuem coleções de formas separadas. Uma forma na coleção de layout não é o mesmo objeto que uma forma posicionada de forma semelhante em um slide normal. Inspecione as formas de layout quando precisar entender ou mudar a formatação fornecida por um layout.

O exemplo a seguir lê o [FillFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ishape/#getFillFormat--) e o [LineFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ishape/#getLineFormat--) de cada forma de layout sem assumir que toda forma é um `AutoShape`.

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

Editar um layout pode afetar vários slides que o utilizam. Antes de mudar uma forma de layout, determine se um slide normal herda o objeto ou contém uma sobrescrita local, e teste cada slide que usa aquele layout.

## **Exportar uma forma para SVG**

[writeAsSvg](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) grava o conteúdo renderizado de uma forma em um fluxo. O resultado contém apenas a forma, não o fundo completo do slide ou formas vizinhas.

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

Mantenha a apresentação aberta durante a renderização. A saída depende da formatação da forma e de recursos como fontes e imagens. Se precisar de toda a composição, exporte o slide em vez de uma forma individual. O chamador possui o fluxo e deve fechá‑lo.

## **Alinhar formas**

Os overloads de [SlideUtil.alignShapes](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) alinham todas as formas ou índices de coleção selecionados. [ShapesAlignmentType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/shapesalignmenttype/) especifica a borda, linha central ou modo de distribuição. Defina `alignToSlide` como `true` para usar as bordas do slide; defina como `false` para alinhar as formas selecionadas entre si.

Este exemplo alinha três formas ao topo do slide. As referências de forma retornadas são convertidas para seus índices atuais imediatamente antes do alinhamento.

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

Alinhamento altera posições, não a ordem Z. O alinhamento relativo normalmente requer pelo menos duas formas, enquanto a distribuição horizontal ou vertical exige formas suficientes para definir o espaçamento. Recalcule os índices se modificar a coleção antes de chamar o método.

## **Inverter uma forma**

A classe [ShapeFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/shapeframe/) armazena posição, tamanho, configurações de inversão horizontal e vertical e rotação. Seus valores `getFlipH` e `getFlipV` usam [NullableBool](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/nullablebool/): `True` habilita a inversão, `False` a desabilita e `NotDefined` preserva o estado não especificado/padrão.

A apresentação de entrada abaixo contém uma forma não invertida.

![The shape before flipping](shape_to_be_flipped.png)

O exemplo preserva todos os demais valores do quadro e substitui apenas as duas configurações de inversão. Isso é importante porque atribuir um novo [Frame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) substitui o quadro completo.

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

A forma salva é espelhada horizontal e verticalmente, mantendo sua posição, tamanho e rotação.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Devo usar um índice de coleção como identificador de forma?**

Somente para processamento de curta duração, quando a coleção não mudará antes que o índice seja usado. Prefira uma convenção validada de `Name` ou `AlternativeText` para modelos criados, ou `OfficeInteropShapeId` para trabalho de interoperabilidade com escopo de slide.

**Ocultar uma forma a remove da ordem Z?**

Não. Uma forma ocultada permanece na coleção no mesmo índice. Ela pode ser encontrada, reordenada, editada ou tornada visível novamente.

**Por que uma forma clonada apareceu à frente de outra forma?**

`addClone` anexa o clone ao final da coleção, que corresponde à frente da ordem Z. Use `insertClone` para escolher o índice inicial ou `reorder` após todas as formas terem sido adicionadas.