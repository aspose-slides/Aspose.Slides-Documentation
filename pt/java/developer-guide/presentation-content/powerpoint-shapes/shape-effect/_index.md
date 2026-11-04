---
title: Aplicar Efeitos de Forma em Apresentações Usando Java
linktitle: Efeito de Forma
type: docs
weight: 30
url: /pt/java/shape-effect/
keywords:
- efeito de forma
- efeito de sombra
- efeito de reflexo
- efeito de brilho
- efeito de bordas suaves
- formato de efeito
- PowerPoint
- apresentação
- Java
- Aspose.Slides
description: "Transforme seus arquivos PPT e PPTX com efeitos avançados de forma usando Aspose.Slides for Java — crie slides impressionantes e profissionais em segundos."
---
## **Introdução**

Embora os efeitos no PowerPoint possam ser usados para fazer uma forma se destacar, eles diferem de [preenchimentos](/slides/pt/java/shape-formatting/#gradient-fill) ou contornos. Usando efeitos do PowerPoint, você pode criar reflexos convincentes em uma forma, espalhar o brilho de uma forma, etc.

![Shape effect](shape-effect.png)

O PowerPoint oferece seis efeitos que podem ser aplicados a formas. Você pode aplicar um ou mais efeitos a uma forma.

Algumas combinações de efeitos ficam melhores que outras. Por esse motivo, o PowerPoint oferece opções em **Preset**. As opções de Preset são combinações de dois ou mais efeitos que são conhecidos por ficar bem. Dessa forma, ao selecionar um preset, você não precisará perder tempo testando ou combinando diferentes efeitos para encontrar uma boa combinação.

Aspose.Slides fornece propriedades e métodos na classe [EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/) que permitem aplicar os mesmos efeitos a formas em apresentações do PowerPoint.

## **Aplicar um Efeito de Sombra**

Aspose.Slides for Java suporta sombras externas e internas para formas. Você pode personalizar sua cor, direção, distância e raio de desfoque para combinar com o design da sua apresentação.

### **Aplicar uma Sombra Externa**

Use uma sombra externa para fazer um cartão ou painel se destacar contra o plano de fundo do slide. A sombra se estende além das bordas da forma, criando a impressão de que a forma está elevada acima do slide. Ajuste sua cor, direção, distância e raio de desfoque para combinar com a iluminação e o estilo do seu modelo.

Este código Java mostra como aplicar o [efeito de sombra externa](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getOuterShadowEffect--) a um retângulo:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(new Color(169, 169, 169));
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    presentation.save("shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Shadow effect](shadow_effect.png)

### **Aplicar uma Sombra Interna**

Ao reproduzir o estilo visual de um modelo, use uma sombra interna para dar a um cartão ou painel uma aparência rebaixada. Uma sombra externa se estende fora da forma e faz com que ela pareça elevada, enquanto uma sombra interna sombreia o interior de suas bordas.

Chame [enableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#enableInnerShadowEffect--), então configure a sombra retornada por [getInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getInnerShadowEffect--). Valores maiores de raio de desfoque produzem bordas mais suaves.

Este exemplo Java cria um cartão azul‑claro com uma sombra interna cinza‑escura e o salva como um arquivo PPTX. A direção da sombra é 225 graus, a distância é 7 pontos e o raio de desfoque é 6 pontos:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(173, 216, 230));
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    shape.getEffectFormat().enableInnerShadowEffect();
    IInnerShadow shadow = shape.getEffectFormat().getInnerShadowEffect();
    shadow.getShadowColor().setColor(new Color(105, 105, 105));
    shadow.setDirection(225);
    shadow.setDistance(7);
    shadow.setBlurRadius(6);

    presentation.save("inner_shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Light blue rectangle with an inner shadow](inner_shadow_effect.png)

Para remover a sombra interna, chame [disableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#disableInnerShadowEffect--) no formato de efeito da forma.

## **Aplicar um Efeito de Reflexo**

Para aplicar um efeito de reflexo no Aspose.Slides for Java, você pode adicionar um reflexo semelhante a um espelho nas formas, ajustando parâmetros como distância, transparência e tamanho. Esse efeito aprimora a estética das suas apresentações ao dar às formas uma aparência mais polida e sofisticada. É fácil de implementar com código simples, permitindo a aplicação rápida em vários elementos para um design consistente.

Este código Java mostra como aplicar o [efeito de reflexo](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getReflectionEffect--) a uma forma:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.Bottom);
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(40);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(2);

    presentation.save("reflection_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Reflection effect](reflection_effect.png)

## **Aplicar um Efeito de Brilho**

Para aplicar um efeito de brilho a uma forma no Aspose.Slides for Java, você pode adicionar uma aura suave e luminosa ao redor das formas, ajustando propriedades como cor e tamanho. Esse efeito ajuda a destacar as formas e acrescenta um elemento visual atraente e chamativo à sua apresentação. É fácil de implementar com código mínimo, realçando a aparência geral dos seus slides.

Este código Java mostra como aplicar o [efeito de brilho](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getGlowEffect--) a uma forma:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableGlowEffect();
    shape.getEffectFormat().getGlowEffect().getColor().setColor(Color.MAGENTA);
    shape.getEffectFormat().getGlowEffect().setRadius(15);

    presentation.save("glow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Glow effect](glow_effect.png)

## **Aplicar um Efeito de Bordas Suaves**

Para aplicar um efeito de bordas suaves no Aspose.Slides for Java, você pode criar uma transição lisa e borrada ao redor das bordas de uma forma. Esse efeito confere um visual mais sutil e refinado, perfeito para designs que necessitam de uma aparência delicada. Você pode ajustar facilmente parâmetros como raio para obter o efeito desejado em diversas formas da sua apresentação.

Este código Java mostra como aplicar o [efeito de bordas suaves](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getSoftEdgeEffect--) a uma forma:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(8);

    presentation.save("soft_edges_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Soft edges effect](soft_edges_effect.png)

## **Aplicar um Efeito de Desfoque**

Use desfoque de forma para suavizar o preenchimento e o contorno de uma forma mantendo-a editável. Chame [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) no formato de efeito da forma. O raio é medido em pontos (1/72 polegada): use um valor não negativo, sendo que valores maiores produzem um desfoque mais forte. Um raio zero deixa a aparência inalterada.

A configuração [getGrow](https://reference.aspose.com/slides/java/com.aspose.slides/iblur/#getGrow--) controla os limites visíveis do efeito. Com `false`, o desfoque é recortado aos limites pintados originais, incluindo o contorno. Com `true`, o desfoque pode se estender além desses limites. Nenhuma das configurações altera a posição ou as dimensões da forma.

A comparação abaixo usa o mesmo preenchimento, contorno e dimensões da forma em todo o teste. A linha superior usa `grow = false`; a linha inferior usa `grow = true`.

![Original rectangle compared with blur radii of 5 and 15 points, with grow disabled and enabled](shape_blur_comparison.png)

Este exemplo Java cria um retângulo laranja com contorno azul‑escuro, aplica um desfoque de 5 pontos e depois o atualiza para um desfoque de 15 pontos chamando [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) novamente. Ele salva ambos os estados borrados, então chama [disableBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#disableBlurEffect--) e salva a forma sem desfoque.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 80, 160, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
    shape.getLineFormat().setWidth(8);

    shape.getEffectFormat().setBlurEffect(5, false);
    presentation.save("shape_blur_5.pptx", SaveFormat.Pptx);

    shape.getEffectFormat().setBlurEffect(15, true);
    presentation.save("shape_blur_15.pptx", SaveFormat.Pptx);

    shape.getEffectFormat().disableBlurEffect();
    presentation.save("shape_blur_removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O desfoque de forma afeta o preenchimento e o contorno juntos. Um efeito de bordas suaves desvanece as bordas da forma, enquanto o desfoque da sombra suaviza apenas a sombra. Os efeitos de transformação de imagem operam no conteúdo da imagem; este exemplo aplica desfoque diretamente ao formato de efeito da forma sem converter a forma em uma imagem.

## **FAQ**

**Posso aplicar vários efeitos à mesma forma?**

Sim, você pode combinar diferentes efeitos, como sombra, reflexo e brilho, em uma única forma para criar uma aparência mais dinâmica.

**Em quais formas posso aplicar efeitos?**

Você pode aplicar efeitos a várias formas, incluindo autoshapes, gráficos, tabelas, imagens, objetos SmartArt, objetos OLE e mais.

**Posso aplicar efeitos a formas agrupadas?**

Sim, você pode aplicar efeitos a formas agrupadas. O efeito será aplicado a todo o grupo.