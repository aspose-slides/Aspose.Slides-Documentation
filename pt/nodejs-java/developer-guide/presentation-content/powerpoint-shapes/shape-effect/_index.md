---
title: Aplicar Efeitos de Forma em Apresentações Usando JavaScript
linktitle: Efeito de Forma
type: docs
weight: 30
url: /pt/nodejs-java/shape-effect/
keywords:
- efeito de forma
- efeito de sombra
- efeito de reflexo
- efeito de brilho
- efeito de bordas suaves
- formato de efeito
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Transforme seus arquivos PPT e PPTX com efeitos avançados de forma usando JavaScript e Aspose.Slides para Node.js — crie slides impressionantes e profissionais em segundos."
---
## **Introdução**

Enquanto os efeitos no PowerPoint podem ser usados para fazer uma forma se destacar, eles diferem de [preenchimentos](/slides/pt/nodejs-java/shape-formatting/#gradient-fill) ou contornos. Usando os efeitos do PowerPoint, você pode criar reflexos convincentes em uma forma, espalhar o brilho de uma forma etc.

![Efeito de forma](shape-effect.png)

O PowerPoint fornece seis efeitos que podem ser aplicados a formas. Você pode aplicar um ou mais efeitos a uma forma.

Algumas combinações de efeitos ficam melhores que outras. Por esse motivo, o PowerPoint oferece opções em **Predefinição**. As opções de Predefinição são combinações de dois ou mais efeitos que são conhecidos por ter boa aparência. Dessa forma, ao selecionar uma predefinição, você não precisará perder tempo testando ou combinando efeitos diferentes para encontrar uma boa combinação.

Aspose.Slides fornece propriedades e métodos na classe [EffectFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/) que permitem aplicar os mesmos efeitos a formas em apresentações do PowerPoint.

## **Aplicar um Efeito de Sombra**

Aspose.Slides para Node.js via Java oferece suporte a sombras externas e internas para formas. Você pode personalizar a cor, direção, distância e raio de desfoque para combinar com o design da sua apresentação.

### **Aplicar uma Sombra Externa**

Use uma sombra externa para fazer um cartão ou painel se destacar contra o plano de fundo do slide. A sombra se estende além das bordas da forma, criando a impressão de que a forma está elevada acima do slide. Ajuste sua cor, direção, distância e raio de desfoque para combinar com a iluminação e o estilo do seu modelo.

Este código JavaScript mostra como aplicar o [efeito de sombra externa](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getOuterShadowEffect) a um retângulo:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableOuterShadowEffect();
    const color = java.newInstanceSync("java.awt.Color", 169, 169, 169);
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(color);
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    presentation.save("shadow_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Efeito de sombra](shadow_effect.png)

### **Aplicar uma Sombra Interna**

Ao reproduzir o estilo visual de um modelo, use uma sombra interna para dar a um cartão ou painel uma aparência recuada. Uma sombra externa se estende fora da forma e faz com que pareça elevada, enquanto uma sombra interna sombreia o interior de suas bordas.

Chame [enableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#enableInnerShadowEffect), então configure a sombra retornada por [getInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getInnerShadowEffect). Valores maiores de raio de desfoque produzem bordas mais suaves.

Este exemplo JavaScript cria um cartão azul claro com uma sombra interna cinza escura e o salva como um arquivo PPTX. A direção da sombra é 225 graus, sua distância é 7 pontos e o raio de desfoque é 6 pontos:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 173, 216, 230);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    shape.getEffectFormat().enableInnerShadowEffect();
    const shadow = shape.getEffectFormat().getInnerShadowEffect();
    const color = java.newInstanceSync("java.awt.Color", 105, 105, 105);
    shadow.getShadowColor().setColor(color);
    shadow.setDirection(225);
    shadow.setDistance(7);
    shadow.setBlurRadius(6);

    presentation.save("inner_shadow_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Retângulo azul claro com sombra interna](inner_shadow_effect.png)

Para remover a sombra interna, chame [disableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableInnerShadowEffect) no formato de efeito da forma.

## **Aplicar um Efeito de Reflexo**

Para aplicar um efeito de reflexo no Aspose.Slides para Node.js via Java, você pode adicionar um reflexo semelhante a um espelho nas formas, ajustando parâmetros como distância, transparência e tamanho. Esse efeito aprimora a estética de suas apresentações ao conferir às formas uma aparência mais polida e sofisticada. É fácil de implementar com código simples, permitindo aplicação rápida em vários elementos para um design consistente.

Este código JavaScript mostra como aplicar o [efeito de reflexo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getReflectionEffect) a uma forma:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(java.newByte(aspose.slides.RectangleAlignment.Bottom));
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(40);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(2);

    presentation.save("reflection_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Efeito de reflexo](reflection_effect.png)

## **Aplicar um Efeito de Brilho**

Para aplicar um efeito de brilho a uma forma no Aspose.Slides para Node.js via Java, você pode adicionar uma aura suave e luminosa ao redor das formas, ajustando propriedades como cor e tamanho. Esse efeito ajuda a destacar as formas e adiciona um elemento visual atraente e chamativo à sua apresentação. É fácil de implementar com código mínimo, aprimorando a aparência geral dos seus slides.

Este código JavaScript mostra como aplicar o [efeito de brilho](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getGlowEffect) a uma forma:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableGlowEffect();
    const color = java.getStaticFieldValue("java.awt.Color", "MAGENTA");
    shape.getEffectFormat().getGlowEffect().getColor().setColor(color);
    shape.getEffectFormat().getGlowEffect().setRadius(15);

    presentation.save("glow_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Efeito de brilho](glow_effect.png)

## **Aplicar um Efeito de Bordas Suaves**

Para aplicar um efeito de bordas suaves no Aspose.Slides para Node.js via Java, você pode criar uma transição suave e borrada ao redor das bordas de uma forma. Esse efeito adiciona uma aparência mais sutil e refinada, perfeita para designs que precisam de um aspecto delicado e mais suave. Você pode ajustar facilmente parâmetros como raio para obter o efeito desejado em várias formas da sua apresentação.

Este código JavaScript mostra como aplicar o [efeito de bordas suaves](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getSoftEdgeEffect) a uma forma:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(8);

    presentation.save("soft_edges_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Efeito de bordas suaves](soft_edges_effect.png)

## **Aplicar um Efeito de Desfoque**

Use o desfoque de forma para suavizar o preenchimento e o contorno de uma forma mantendo-a editável. Chame [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect) no formato de efeito da forma. O raio é medido em pontos (1/72 polegada): use um valor não negativo, com valores maiores produzindo um desfoque mais forte. Um raio zero deixa a aparência inalterada.

A configuração [getGrow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blur/#getGrow) controla os limites visíveis do efeito. Com `false`, o desfoque é recortado aos limites originais pintados, incluindo o contorno. Com `true`, o desfoque pode se estender além desses limites. Nenhuma das configurações altera a posição ou as dimensões da forma.

A comparação abaixo usa o mesmo preenchimento, contorno e dimensões da forma em todo o exemplo. A primeira linha usa `grow = false`; a segunda linha usa `grow = true`.

![Retângulo original comparado com raios de desfoque de 5 e 15 pontos, com grow desativado e ativado](shape_blur_comparison.png)

Este exemplo JavaScript cria um retângulo laranja com contorno azul escuro, aplica um desfoque de 5 pontos e depois o atualiza para um desfoque de 15 pontos chamando [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect) novamente. Ele salva ambos os estados desfocados, então chama [disableBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableBlurEffect) e salva a forma sem desfoque.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 80, 160, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const lineColor = java.newInstanceSync("java.awt.Color", 0, 0, 139);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(lineColor);
    shape.getLineFormat().setWidth(8);

    shape.getEffectFormat().setBlurEffect(5, false);
    presentation.save("shape_blur_5.pptx", aspose.slides.SaveFormat.Pptx);

    shape.getEffectFormat().setBlurEffect(15, true);
    presentation.save("shape_blur_15.pptx", aspose.slides.SaveFormat.Pptx);

    shape.getEffectFormat().disableBlurEffect();
    presentation.save("shape_blur_removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O desfoque de forma afeta o preenchimento e o contorno juntos. Um efeito de bordas suaves desvanece as bordas da forma, enquanto o desfoque de sombra suaviza apenas a sombra. Os efeitos de transformação de imagem operam no conteúdo da imagem; este exemplo aplica desfoque diretamente ao formato de efeito da forma sem converter a forma em imagem.

## **Perguntas Frequentes**

**Posso aplicar múltiplos efeitos à mesma forma?**

Sim, você pode combinar diferentes efeitos, como sombra, reflexo e brilho, em uma única forma para criar uma aparência mais dinâmica.

**Quais formas posso aplicar efeitos?**

Você pode aplicar efeitos a várias formas, incluindo autoshapes, gráficos, tabelas, imagens, objetos SmartArt, objetos OLE e muito mais.

**Posso aplicar efeitos a formas agrupadas?**

Sim, você pode aplicar efeitos a formas agrupadas. O efeito será aplicado a todo o grupo.