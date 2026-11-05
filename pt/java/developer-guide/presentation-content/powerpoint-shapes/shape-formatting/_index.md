---
title: Formatar Formas do PowerPoint em Java
linktitle: Formatação de Forma
type: docs
weight: 20
url: /pt/java/shape-formatting/
keywords:
- formatar forma
- formatar linha
- efeito de esboço
- linha de forma esboçada
- formatar estilo de junção
- preenchimento degradê
- preenchimento de padrão
- preenchimento de imagem
- preenchimento de textura
- preenchimento de cor sólida
- transparência de forma
- renderização de forma preto e branco
- renderização de forma em tons de cinza
- rotacionar forma
- efeito de chanfrado 3D
- efeito de rotação 3D
- redefinir formatação
- PowerPoint
- apresentação
- Java
- Aspose.Slides
description: "Aprenda a formatar formas do PowerPoint em Java usando Aspose.Slides — defina estilos de preenchimento, linha e efeito para arquivos PPT e PPTX com precisão e controle total."
---
## **Introdução**

Formate formas no PowerPoint ajustando seus contornos, preenchimentos e efeitos. Aspose.Slides for Java permite controlar essas configurações programaticamente, incluindo transparência, rotação e formatação 3D.

![Opções de formatação de forma no PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Java fornece interfaces e métodos que permitem formatar formas usando as mesmas opções disponíveis no PowerPoint.

## **Formatar linhas**

Use [IShape.getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) para controlar o contorno de uma forma. Este exemplo cria um retângulo sem preenchimento com um contorno azul pontilhado. [ILineFormat.setStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setStyle-byte-) seleciona uma linha composta grossa-fina, enquanto [ILineFormat.setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setWidth-double-) define sua largura para 7 pontos e [ILineFormat.setDashStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setDashStyle-byte-) seleciona o padrão de traço.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![As linhas formatadas na apresentação](formatted-lines.png)

### **Definir padrões de traço personalizados**

Use [ILineFormat.setCustomDashPattern](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setCustomDashPattern-float---) quando os estilos de linha predefinidos não fornecem os comprimentos de traço e intervalo que você precisa, por exemplo para contornos de marca ou diagramas técnicos. Atribuir um padrão altera automaticamente o estilo de traço da linha para [LineDashStyle.Custom](https://reference.aspose.com/slides/java/com.aspose.slides/linedashstyle/).

As entradas do array alternam entre comprimentos de traço e intervalo, começando com um traço. Cada valor é múltiplo da largura da linha: `{ 4, 2 }` com largura de 3 pontos produz um traço de 12 pontos seguido por um intervalo de 6 pontos. Use pares de valores finitos e não negativos para definir segmentos completos de traço e intervalo. O exemplo usa valores positivos para manter cada traço e intervalo visíveis.

Este exemplo cria cinco linhas azuis com o mesmo comprimento e extremidades planas. As três primeiras comparam padrões com largura de 3 pontos. A quarta repete o primeiro padrão com o dobro da largura, dobrando tanto o traço quanto o intervalo. A quinta troca de um padrão personalizado para uma linha contínua.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(600, 300, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    float[][] patterns = {
        { 4, 2 },
        { 1, 2 },
        { 6, 2, 1, 2 },
        { 4, 2 },
        { 4, 2 }
    };

    for (int i = 0; i < patterns.length; i++) {
        IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, 50, 50 + i * 50, 500, 0);
        line.getLineFormat().setWidth(i == 3 ? 6 : 3);
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
        line.getLineFormat().setCapStyle(LineCapStyle.Flat);
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setCustomDashPattern(patterns[i]);
    }

    // Retornar a última linha para um estilo sólido.
    slide.getShapes().get_Item(4).getLineFormat().setDashStyle(LineDashStyle.Solid);

    presentation.save("custom_dash_patterns.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Para voltar a um estilo de traço predefinido, passe [LineDashStyle.Dash](https://reference.aspose.com/slides/java/com.aspose.slides/linedashstyle/) para [ILineFormat.setDashStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setDashStyle-byte-). O estilo selecionado controla a aparência da linha.

O resultado no PowerPoint, de cima para baixo: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; e **Solid, 3 pt**.

![Três padrões de traço personalizados, uma linha mais larga usando o primeiro padrão e uma linha contínua no PowerPoint](custom-dash-patterns.png)

### **Definir estilos de extremidade da linha**

Use [ILineFormat.setCapStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setCapStyle-byte-) para definir as extremidades de uma linha aberta. A classe [LineCapStyle](https://reference.aspose.com/slides/java/com.aspose.slides/linecapstyle/) fornece três estilos explícitos de extremidade:

- `Flat`: O traço termina no ponto final.
- `Round`: Uma extremidade semicircular se estende além do ponto final em metade da largura da linha.
- `Square`: Uma extremidade quadrada se estende além do ponto final em metade da largura da linha.

A classe também inclui `NotDefined`, que significa que nenhum estilo de extremidade foi atribuído explicitamente.

Extremidades são diferentes de pontas de seta, que adicionam símbolos aos fins da linha, e de junções, que controlam cantos entre segmentos de linha. Este exemplo desativa pontas de seta através de [ILineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setBeginArrowheadStyle-byte-) e [ILineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setEndArrowheadStyle-byte-) para que apenas os formatos de extremidade sejam comparados.

O exemplo a seguir cria três linhas horizontais idênticas, 20 pontos de largura. De cima para baixo, usam extremidades flat, round e square. Seus pontos finais têm as mesmas coordenadas horizontais; as extremidades round e square se estendem 10 pontos além de cada ponto final.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(500, 240, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] capStyles = new byte[] { LineCapStyle.Flat, LineCapStyle.Round, LineCapStyle.Square };

    for (int i = 0; i < capStyles.length; i++) {
        IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, 100, 50 + i * 70, 300, 0);
        line.getLineFormat().setWidth(20);
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
        line.getLineFormat().setDashStyle(LineDashStyle.Solid);
        line.getLineFormat().setCapStyle(capStyles[i]);
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None);
    }

    presentation.save("line_caps.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado no PowerPoint, de cima para baixo: **Flat**, **Round** e **Square**.

![Extremidades flat, round e square em linhas espessas idênticas no PowerPoint](line-caps.png)

## **Aplicar efeitos de esboço às linhas da forma**

Um efeito de esboço faz a linha da forma parecer desenhada à mão. Use [IShape.getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) para acessar as configurações da linha, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getSketchFormat--) para acessar as configurações de esboço e [ISketchFormat.setSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/#setSketchType-int-) para selecionar um valor da classe [LineSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/).

O código Java a seguir mostra como aplicar um efeito [LineSketchType.Curved](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/), ler o valor atribuído explicitamente e remover o efeito com [LineSketchType.None](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();
    sketchFormat.setSketchType(LineSketchType.Curved);
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

O valor retornado por [ISketchFormat.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/#getSketchType--) representa a configuração atribuída diretamente à forma. Se a formatação da linha puder ser herdada de um tema, slide mestre ou slide de layout, use [ILineFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getEffective--), acesse [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformateffectivedata/#getSketchFormat--) e leia [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformateffectivedata/#getSketchType--). O valor efetivo reflete a formatação realmente aplicada após a resolução da herança. Este exemplo requer uma apresentação existente com ao menos uma forma no primeiro slide e imprime ambos os valores:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    ILineFormat lineFormat = shape.getLineFormat();
    int explicitSketchType = lineFormat.getSketchFormat().getSketchType();
    ILineFormatEffectiveData effectiveLineFormat = lineFormat.getEffective();
    int effectiveSketchType = effectiveLineFormat.getSketchFormat().getSketchType();

    System.out.println("Explicit sketch type: " + explicitSketchType);
    System.out.println("Effective sketch type: " + effectiveSketchType);
} finally {
    presentation.dispose();
}
```

## **Formatar estilos de junção**

Aqui estão as três opções de tipo de junção:

* Round
* Miter
* Bevel

O estilo de junção controla como dois segmentos de contorno se encontram em um canto. Use **Round** para cantos arredondados, **Miter** para cantos agudos ou **Bevel** para cantos achatados.

![O estilo de junção na apresentação](join-style-powerpoint.png)

Este exemplo cria três retângulos pretos com contornos azuis de 15 pontos de largura. Ele usa [ILineFormat.setJoinStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setJoinStyle-byte-) para definir os valores miter, bevel e round de [LineJoinStyle](https://reference.aspose.com/slides/java/com.aspose.slides/linejoinstyle/), respectivamente, para comparar como os cantos são desenhados.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape miterShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape bevelShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape roundShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    miterShape.getFillFormat().setFillType(FillType.Solid);
    miterShape.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    bevelShape.getFillFormat().setFillType(FillType.Solid);
    bevelShape.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    roundShape.getFillFormat().setFillType(FillType.Solid);
    roundShape.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    miterShape.getLineFormat().setWidth(15);
    bevelShape.getLineFormat().setWidth(15);
    roundShape.getLineFormat().setWidth(15);

    miterShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    miterShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    bevelShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    bevelShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    roundShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    roundShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    miterShape.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    bevelShape.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    roundShape.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    miterShape.getTextFrame().setText("Miter Join Style");
    bevelShape.getTextFrame().setText("Bevel Join Style");
    roundShape.getTextFrame().setText("Round Join Style");

    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Limitar junções miter em cantos agudos**

Use [ILineFormat.setMiterLimit](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setMiterLimit-float-) com [ILineFormat.setJoinStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setJoinStyle-byte-) definido como [LineJoinStyle.Miter](https://reference.aspose.com/slides/java/com.aspose.slides/linejoinstyle/) para limitar o quanto um canto agudo pode se estender.

O limite é a razão entre a distância entre os cantos interno e externo da junção e a largura da linha. Por exemplo, um valor de `8` permite um comprimento de miter de até oito vezes a largura da linha; não é uma medida em pontos. Se o canto exceder o limite, o PowerPoint usa uma junção chanfrada naquele canto. Um limite maior permite pontas mais agudas. A configuração afeta apenas junções miter e não tem efeito visível quando o canto permanece dentro dos limites.

Este exemplo cria dois triângulos idênticos, sem preenchimento, com contornos de 20 pontos de largura. O triângulo esquerdo usa um limite de `2` e o direito usa `8`. Cada triângulo tem 80 pontos de largura e 160 pontos de altura, proporcionando uma razão de comprimento de miter para largura de linha de aproximadamente `4.12`. Consequentemente, o PowerPoint chanfrará o ápice esquerdo e preservará o ápice direito.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(500, 320, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    float[] miterLimits = new float[] { 2f, 8f };

    for (int i = 0; i < miterLimits.length; i++) {
        IAutoShape triangle = slide.getShapes().addAutoShape(ShapeType.Triangle, 90 + i * 240, 110, 80, 160);
        triangle.getFillFormat().setFillType(FillType.NoFill);
        triangle.getLineFormat().setWidth(20);
        triangle.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        triangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
        triangle.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
        triangle.getLineFormat().setMiterLimit(miterLimits[i]);
    }

    presentation.save("miter_limits.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado no PowerPoint: **Miter limit 2** à esquerda e **miter limit 8** à direita.

![Um ápice chanfrado com limite miter 2 e um ápice pontiagudo com limite miter 8 no PowerPoint](miter-limits.png)

## **Preenchimento degradê**

Um preenchimento degradê mescla cores ao longo de uma forma. Este exemplo preenche uma elipse com um degradê linear a 45 graus do vermelho ao roxo usando [IFillFormat.getGradientFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getGradientFormat--). O método [IGradientStopCollection.addPresetColor](https://reference.aspose.com/slides/java/com.aspose.slides/igradientstopcollection/#addPresetColor-float-int-) coloca as paradas de cor em 0 e 1, o início e o fim do degradê. Limpar as paradas existentes garante que apenas essas duas cores sejam usadas.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);
    shape.getFillFormat().getGradientFormat().setLinearGradientAngle(45);
    shape.getFillFormat().getGradientFormat().getGradientStops().clear();
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0f, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0f, PresetColor.Red);

    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![A elipse com preenchimento degradê](gradient-fill.png)

Se um degradê parecer diferente em uma imagem exportada do que no PowerPoint, veja [Escolher um Estilo de Renderização de Gradiente](/slides/pt/java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Você pode selecionar um estilo de renderização sem alterar o preenchimento degradê armazenado na apresentação.

### **Definir o ângulo do degradê linear**

Use [IGradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-) para controlar a orientação de um preenchimento [GradientShape.Linear](https://reference.aspose.com/slides/java/com.aspose.slides/gradientshape/). O ângulo é medido em graus e aumenta no sentido horário: `0` vai da esquerda para a direita, `90` de cima para baixo, `180` da direita para a esquerda e `270` de baixo para cima. Ângulos fracionários são suportados. Ângulos finitos fora de `[0, 360)` são normalizados para uma revolução; por exemplo, `-45` torna‑se `315` e `360` torna‑se `0`.

Este exemplo cria seis retângulos com paradas de cor vermelha, verde e azul idênticas nas posições `0`, `0.5` e `1`. A escala está desativada para que o ângulo possa ser comparado independentemente das proporções dos retângulos. Os ângulos, da esquerda para a direita, são `0`, `45` e `90` na primeira fila, e `135`, `180` e `270` na segunda fila.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    float[] angles = new float[] { 0, 45, 90, 135, 180, 270 };

    for (int i = 0; i < angles.length; i++) {
        int x = 30 + (i % 3) * 230;
        int y = 30 + (i / 3) * 190;

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 200, 150);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        shape.getFillFormat().setFillType(FillType.Gradient);

        IGradientFormat gradient = shape.getFillFormat().getGradientFormat();
        gradient.setGradientShape(GradientShape.Linear);
        gradient.getGradientStops().clear();
        gradient.getGradientStops().add(0f, Color.RED);
        gradient.getGradientStops().add(0.5f, Color.GREEN);
        gradient.getGradientStops().add(1f, Color.BLUE);
        gradient.setLinearGradientScaled(NullableBool.False);
        gradient.setLinearGradientAngle(angles[i]);
    }

    presentation.save("linear_gradient_angles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado no PowerPoint:

![Degradês lineares em 0, 45 e 90 graus na primeira linha, e 135, 180 e 270 graus na segunda linha](linear-gradient-angles.png)

### **Escalar um degradê linear com a forma**

[IGradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setLinearGradientScaled-byte-) aceita um valor [NullableBool](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/). Defina‑o explicitamente como `False` para manter o ângulo geométrico do degradê ao mudar as proporções da forma, ou como `True` para escalar o degradê com a largura e altura da forma. Com a escala ativada, o ângulo visível pode diferir do ângulo atribuído em uma forma não quadrada.

O exemplo a seguir usa um ângulo de `45` graus e as mesmas paradas de cor do comparativo de ângulos. A coluna da esquerda usa `False`; a da direita usa `True`. Cada coluna contém um retângulo largo acima de um retângulo alto. Ambos começam com as mesmas dimensões largas; mudar a largura e altura do segundo retângulo demonstra como o preenchimento responde ao redimensionamento sem mudar suas configurações de degradê.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 460, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] scalingOptions = new byte[] { NullableBool.False, NullableBool.True };

    for (int column = 0; column < scalingOptions.length; column++) {
        for (int row = 0; row < 2; row++) {
            int x = 30 + column * 360;
            int y = row == 0 ? 30 : 150;

            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 300, 90);
            shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
            shape.getFillFormat().setFillType(FillType.Gradient);

            IGradientFormat gradient = shape.getFillFormat().getGradientFormat();
            gradient.setGradientShape(GradientShape.Linear);
            gradient.getGradientStops().clear();
            gradient.getGradientStops().add(0f, Color.RED);
            gradient.getGradientStops().add(0.5f, Color.GREEN);
            gradient.getGradientStops().add(1f, Color.BLUE);
            gradient.setLinearGradientAngle(45);
            gradient.setLinearGradientScaled(scalingOptions[column]);

            if (row == 1) {
                shape.setWidth(90);
                shape.setHeight(280);
            }
        }
    }

    presentation.save("linear_gradient_scaling.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado no PowerPoint, com escala desativada à esquerda e ativada à direita:

![Retângulos largos e altos com degradê de 45 graus, comparando LinearGradientScaled False à esquerda com True à direita](linear-gradient-scaling.png)

Com a escala desativada, as faixas de cor diagonal mantêm a mesma orientação em ambos os retângulos. Com a escala ativada, as faixas se esticam conforme as proporções da forma. Isso ajuda a reproduzir o degradê de um modelo ao adaptar uma forma a um tamanho diferente. Em uma forma quadrada, ativar a escala não altera a aparência deste degradê de `45` graus.

Tanto o ângulo quanto as configurações de escala se aplicam a degradês lineares. Eles não controlam preenchimentos [GradientShape.Radial ou GradientShape.Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/gradientshape/).

### **Combinar ângulo com direção do degradê**

[IGradientFormat.setGradientDirection](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setGradientDirection-int-) seleciona um estilo de degradê da classe [GradientDirection](https://reference.aspose.com/slides/java/com.aspose.slides/gradientdirection/); não substitui um ângulo numérico. Para um degradê linear, os estilos de canto podem mudar a área onde as cores são distribuídas sem mudar o ângulo atribuído por [setLinearGradientAngle](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-). Mantenha a direção inalterada ao comparar ângulos ou escala.

O exemplo a seguir aplica as mesmas configurações em ordem inversa. Os dois retângulos têm a mesma aparência: atribuir a direção antes ou depois do ângulo não altera o resultado.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (int i = 0; i < 2; i++) {
        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30 + i * 140, 320, 100);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        shape.getFillFormat().setFillType(FillType.Gradient);

        IGradientFormat gradient = shape.getFillFormat().getGradientFormat();
        gradient.setGradientShape(GradientShape.Linear);
        gradient.getGradientStops().clear();
        gradient.getGradientStops().add(0f, Color.RED);
        gradient.getGradientStops().add(0.5f, Color.GREEN);
        gradient.getGradientStops().add(1f, Color.BLUE);
        gradient.setLinearGradientScaled(NullableBool.True);

        if (i == 0) {
            gradient.setGradientDirection(GradientDirection.FromCorner1);
            gradient.setLinearGradientAngle(30);
        } else {
            gradient.setLinearGradientAngle(30);
            gradient.setGradientDirection(GradientDirection.FromCorner1);
        }
    }

    presentation.save("linear_gradient_direction.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Preenchimento de padrão**

Um preenchimento de padrão aplica um desenho bicolor, como pontos, listras ou xadrez. Este exemplo usa [IPatternFormat.setPatternStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ipatternformat/#setPatternStyle-byte-) para selecionar um padrão de treliça. [IPatternFormat.getBackColor](https://reference.aspose.com/slides/java/com.aspose.slides/ipatternformat/#getBackColor--) fornece o fundo cinza claro, e [IPatternFormat.getForeColor](https://reference.aspose.com/slides/java/com.aspose.slides/ipatternformat/#getForeColor--) fornece a cor amarela do padrão.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Pattern);
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![O retângulo com preenchimento de padrão](pattern-fill.png)

## **Preenchimento de imagem**

Um preenchimento de imagem usa uma imagem dentro de uma forma. Este exemplo requer uma imagem local e usa [Images.fromFile](https://reference.aspose.com/slides/java/com.aspose.slides/images/#fromFile-java.lang.String-) para carregá‑la na coleção de imagens da apresentação. Definir [IPictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-) para o modo em mosaico repete a imagem dentro do retângulo. A imagem de origem usada aqui é mostrada abaixo:

![A imagem do lótus](lotus.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    IImage image = Images.fromFile("lotus.png");
    IPPImage picture;
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![A forma com preenchimento de imagem](picture-fill.png)

### **Mosaicar imagem como textura**

Se você quiser definir uma imagem em mosaico como textura e personalizar o comportamento do mosaico, pode usar os seguintes métodos da interface [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) e da classe [PictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): define o modo de preenchimento da imagem — `Tile` ou `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): especifica o alinhamento das telhas dentro da forma.
- [setTileFlip](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): controla se a telha é virada horizontalmente, verticalmente ou em ambas as direções.
- [setTileOffsetX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): define o deslocamento horizontal da telha (em pontos) a partir da origem da forma.
- [setTileOffsetY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): define o deslocamento vertical da telha (em pontos) a partir da origem da forma.
- [setTileScaleX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): define a escala horizontal da telha como porcentagem.
- [setTileScaleY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): define a escala vertical da telha como porcentagem.

Este exemplo requer uma imagem local e configura [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) para repeti‑la a 50% de seu tamanho original. Deslocamentos de −32 pontos deslocam as telhas horizontal e verticalmente; alinhamento bottom‑right e inversão em ambas as direções determinam como a textura repetida é organizada.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);
    shape.getFillFormat().setFillType(FillType.Picture);

    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![As opções de mosaico](tile-options.png)

## **Preenchimento de cor sólida**

Um preenchimento sólido dá à forma uma única cor uniforme. Este exemplo usa [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) para definir o modo de preenchimento sólido e atribui amarelo através de [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--), então salva o retângulo em uma apresentação.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![A forma com preenchimento de cor sólida](solid-color-fill.png)

### **Copiar cores preservando referências de tema**

Use [IColorFormat.copyFrom](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/#copyFrom-com.aspose.slides.IColorFormat-) para copiar uma definição de cor, incluindo seu tipo de cor, referência de tema e transformações. Isso é útil ao transferir a cor de preenchimento entre formas que devem continuar seguindo o tema da apresentação. O método copia apenas a cor: não copia o tipo de preenchimento, contorno ou outra formatação da forma. Defina explicitamente o tipo de preenchimento de destino com [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-).

Este exemplo cria três retângulos, da esquerda para a direita: a fonte, uma cópia consciente do tema e uma cópia RGB fixa. A fonte usa [IColorFormat.setSchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/#setSchemeColor-int-) para referenciar a primeira cor de realce e adiciona um matiz através de [IColorOperationCollection.add](https://reference.aspose.com/slides/java/com.aspose.slides/icoloroperationcollection/#add-int-float-). A cópia RGB usa a cor de preenchimento efetiva da fonte, de modo que as três inicialmente parecem idênticas. Chamar [IColorFormat.setColor](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/#setColor-java.awt.Color-) define um valor RGB fixo e limpa quaisquer transformações de cor existentes.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(660, 220, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(new Color(65, 105, 225));

    IAutoShape source = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 40, 180, 140);
    IAutoShape themeCopy = slide.getShapes().addAutoShape(ShapeType.Rectangle, 240, 40, 180, 140);
    IAutoShape rgbCopy = slide.getShapes().addAutoShape(ShapeType.Rectangle, 450, 40, 180, 140);

    for (IAutoShape shape : new IAutoShape[] { source, themeCopy, rgbCopy }) {
        shape.getFillFormat().setFillType(FillType.Solid);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    }

    IColorFormat sourceColor = source.getFillFormat().getSolidFillColor();
    sourceColor.setSchemeColor(SchemeColor.Accent1);
    sourceColor.getColorTransform().add(ColorTransformOperation.Tint, 0.75f);

    themeCopy.getFillFormat().getSolidFillColor().copyFrom(sourceColor);
    rgbCopy.getFillFormat().getSolidFillColor().setColor(source.getFillFormat().getEffective().getSolidFillColor());

    IImage before = slide.getImage(1f, 1f);
    try {
        before.save("color-copy-before.png", ImageFormat.Png);
    } finally {
        before.dispose();
    }

    // As referências ao tema seguem a nova cor de realce; o valor RGB fixo não.
    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(new Color(255, 69, 0));

    IImage after = slide.getImage(1f, 1f);
    try {
        after.save("color-copy-after.png", ImageFormat.Png);
    } finally {
        after.dispose();
    }
    presentation.save("copied_colors.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Antes da mudança de tema, todos os três preenchimentos correspondem:

![Fonte, destino copyFrom e destino RGB fixo com preenchimentos azuis idênticos](color-copy-before.png)

Após a mudança de tema, a fonte e a cópia consciente do tema seguem a nova cor de realce e mantêm seu matiz. A cópia RGB fixa permanece azul:

![Fonte e destino copyFrom com preenchimentos laranja, enquanto o destino RGB fixo permanece azul](color-copy-after.png)

A definição copiada é independente da fonte. Alterar posteriormente a referência de tema da fonte, atribuir outra cor ou adicionar ou remover suas transformações não altera o destino. Uma mudança de tema ainda afeta ambas as formas porque cada uma refere‑se independentemente à mesma cor de tema.

Salvar e reabrir o PPTX preserva o tipo de cor copiada retornado por [IColorFormat.getColorType](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/#getColorType--), a referência de tema e a coleção de transformações retornada por [IColorFormat.getColorTransform](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/#getColorTransform--); não é convertido para RGB.

Ao copiar entre contextos de tema diferentes, como apresentações com paletas de realce distintas, a referência copiada é resolvida em relação ao tema de destino. A mesma referência e transformações podem, portanto, produzir uma cor visível diferente. Consulte [Tema da Apresentação](/slides/pt/java/presentation-theme/) para mais informações sobre configuração de cores de tema.

## **Usar o plano de fundo do slide como preenchimento da forma**

Use [IAutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#setUseBackgroundFill-boolean-) quando uma forma deve combinar com o plano de fundo do slide, por exemplo em um modelo de apresentação. Defina o tipo de preenchimento com [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) para [FillType.NotDefined](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) primeiro para remover qualquer preenchimento explícito. Com essa combinação, a forma usa o plano de fundo do slide em vez de seu preenchimento de estilo. Ativar a sinalização sozinha não remove um preenchimento explícito existente.

Isso difere de [FillType.NoFill](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/): o preenchimento de fundo cobre objetos atrás da forma com a área correspondente do plano de fundo do slide, enquanto nenhum preenchimento deixa esses objetos visíveis. Um degradê permanece alinhado com o slide em vez de reiniciar dentro de cada forma.

O exemplo a seguir cria um plano de fundo mestre herdado pelo slide e coloca uma faixa magenta atrás de três retângulos. O retângulo esquerdo usa o plano de fundo, o do meio não tem preenchimento e o da direita troca de preenchimento de plano de fundo para um preenchimento laranja explícito.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    // Herda o degradê do mestre.
    slide.getBackground().setType(BackgroundType.NotDefined);
    slide.getLayoutSlide().getBackground().setType(BackgroundType.NotDefined);
    IBackground background = slide.getLayoutSlide().getMasterSlide().getBackground();
    background.setType(BackgroundType.OwnBackground);
    background.getFillFormat().setFillType(FillType.Gradient);
    IGradientFormat gradient = background.getFillFormat().getGradientFormat();
    gradient.setGradientShape(GradientShape.Linear);
    gradient.setLinearGradientAngle(0);
    gradient.getGradientStops().clear();
    gradient.getGradientStops().add(0, new Color(0, 0, 139));
    gradient.getGradientStops().add(1, new Color(135, 206, 250));

    // Adicione este objeto primeiro para que ele apareça atrás dos retângulos.
    IAutoShape band = slide.getShapes().addAutoShape(ShapeType.Rectangle, 25, 150, 670, 100);
    band.getFillFormat().setFillType(FillType.Solid);
    band.getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    IAutoShape backgroundShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 100, 160, 200);
    backgroundShape.getFillFormat().setFillType(FillType.NotDefined);
    backgroundShape.setUseBackgroundFill(true);

    IAutoShape noFillShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 280, 100, 160, 200);
    noFillShape.getFillFormat().setFillType(FillType.NoFill);

    IAutoShape explicitShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 510, 100, 160, 200);
    explicitShape.getFillFormat().setFillType(FillType.NotDefined);
    explicitShape.setUseBackgroundFill(true);

    // Desative o preenchimento de fundo antes de aplicar um preenchimento explícito.
    explicitShape.setUseBackgroundFill(false);
    explicitShape.getFillFormat().setFillType(FillType.Solid);
    explicitShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));

    presentation.save("background_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado, da esquerda para a direita: **background fill**, **no fill** e **explicit fill**. A faixa magenta fica oculta pelos retângulos esquerdo e direito, mas permanece visível através do retângulo do meio.

![Preenchimento de plano de fundo, sem preenchimento e preenchimento laranja explícito sobre uma faixa magenta](background-fill.png)

O mesmo comportamento se aplica a um plano de fundo definido diretamente no slide ou herdado de um layout. A forma usa o plano de fundo resolvido do slide; o exemplo deixa os planos de fundo do slide e do layout indefinidos para que o mestre o forneça.

## **Definir transparência**

Para um preenchimento sólido, o componente alfa da cor controla a opacidade: 0 é totalmente transparente e 255 é totalmente opaco. Este exemplo usa um valor alfa de 128 para um retângulo amarelo, tornando‑o aproximadamente 50 % transparente para que o retângulo subjacente permaneça visível. A cor é atribuída através de [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--).

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 128));

    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![A forma transparente](shape-transparency.png)

## **Rotacionar formas**

Use [IShape.setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setRotation-float-) para girar uma forma no plano do slide. O ângulo é medido em graus; este exemplo gira um retângulo 5 graus no sentido horário e salva a apresentação.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.setRotation(5);

    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![A rotação da forma](shape-rotation.png)

## **Adicionar efeitos de chanfrado 3D**

Use [IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--) para dar profundidade e bordas chanfradas a uma forma. Este exemplo cria uma elipse verde com contorno laranja, usa [IThreeDFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setDepth-double-) para definir a profundidade em 4 pontos e aplica um chanfrado superior circular com largura e altura de 6 pontos através de [IThreeDFormat.getBevelTop](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getBevelTop--). Uma câmera ortográfica de frente e iluminação de três pontos tornam o chanfrado visível.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(0, 128, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));
    shape.getLineFormat().setWidth(2.0);
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![O efeito de chanfrado 3D](3D-bevel-effect.png)

## **Adicionar efeitos de rotação 3D**

A visualização 3D de uma forma é controlada pelas configurações da câmera. Este exemplo usa [ICamera.setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setRotation-float-float-float-) com ângulos de latitude, longitude e revolução de 40, 35 e 20 graus, respectivamente. Ele seleciona uma câmera isométrica através de [ICamera.setCameraType](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setCameraType-int-) e iluminação equilibrada através de [ILightRig.setLightType](https://reference.aspose.com/slides/java/com.aspose.slides/ilightrig/#setLightType-int-), então salva o retângulo formatado.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![O efeito de rotação 3D](3D-rotation-effect.png)

## **Controlar a renderização em preto e branco para formas**

O método [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) especifica como uma forma individual é renderizada quando uma apresentação é visualizada ou processada em modo preto e branco. Ele não habilita a exibição em preto e branco por si só, nem altera o preenchimento, linha ou outra formatação da forma no modo de cores normal.

Use um valor da classe [BlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/blackwhitemode/) para selecionar o comportamento desejado. Por exemplo, `Automatic` deixa o aplicativo de renderização escolher a conversão, `Gray` e `LightGray` usam cores em tons de cinza, `BlackWhite` usa apenas preto e branco, `Black` e `White` forçam uma única cor, `Color` preserva a coloração normal e `Hidden` omite a forma no modo preto e branco. `NotDefined` significa que nenhum modo de nível de forma foi atribuído.

Este exemplo cria um retângulo laranja e usa [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) para definir o modo como cinza. A forma salva mantém seu preenchimento laranja para exibição em cor normal e solicita coloração cinza de aplicativos que respeitam as configurações de exibição em preto e branco:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

No modo de cor normal, o retângulo mantém seu preenchimento laranja. Em um fluxo de trabalho de exibição em preto e branco, ele usa coloração cinza porque seu modo está definido como `Gray`. Isso permite preservar um slide em cores completas enquanto define uma aparência distinta para impressão, visualização ou outros fluxos que respeitam as configurações de exibição em preto e branco da apresentação.

## **Redefinir formatação**

Use [ISlide.reset](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#reset--) para restaurar a posição, tamanho e formatação de marcadores de posição do slide a partir de seus correspondentes marcadores de layout. Este exemplo requer uma apresentação existente com marcadores de posição vinculados a layouts e redefine cada slide antes de salvar. Formas sem marcadores de posição correspondentes no layout não são redefinidas.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        slide.reset();
    }

    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**A formatação da forma afeta o tamanho final do arquivo da apresentação?**

Cores, estilos de linha e configurações de efeito geralmente adicionam poucos dados em comparação com imagens e mídia incorporadas. Preenchimentos de imagem podem aumentar o tamanho do arquivo porque suas imagens são armazenadas na apresentação.

**Como posso detectar formas em um slide que compartilham formatação idêntica para agrupá‑las?**

Compare as principais propriedades de formatação de cada forma — preenchimento, linha e configurações de efeito. Se todos os valores correspondentes coincidirem, trate seus estilos como idênticos e agrupe logicamente essas formas, o que simplifica o gerenciamento posterior de estilos.

**Posso salvar um conjunto de estilos de forma personalizados em um arquivo separado para reutilizar em outras apresentações?**

Sim. Armazene formas de exemplo com os estilos desejados em um slide‑modelo ou em um arquivo de modelo .POTX. Ao criar uma nova apresentação, abra o modelo, clone as formas estilizadas de que precisar e reaplique sua formatação onde for necessário.