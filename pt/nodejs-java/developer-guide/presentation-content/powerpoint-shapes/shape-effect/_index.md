---
title: Aplicar efeitos de forma em apresentações usando JavaScript
linktitle: Efeito de forma
type: docs
weight: 30
url: /pt/nodejs-java/shape-effect/
keywords:
- efeito de forma
- efeito de sombra
- efeito de reflexão
- efeito de brilho
- efeito de bordas suaves
- formato de efeito
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Transforme seus arquivos PPT e PPTX com efeitos avançados de forma usando JavaScript e Aspose.Slides para Node.js—crie slides impressionantes e profissionais em segundos."
---
## **Introdução**

Enquanto os efeitos no PowerPoint podem ser usados para fazer uma forma se destacar, eles diferem de [preenchimentos](/slides/pt/nodejs-java/shape-formatting/#gradient-fill) ou contornos. Usando os efeitos do PowerPoint, você pode criar reflexos convincentes em uma forma, espalhar o brilho de uma forma, etc.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* O PowerPoint oferece seis efeitos que podem ser aplicados a formas. Você pode aplicar um ou mais efeitos a uma forma. 

* Algumas combinações de efeitos ficam melhores que outras. Por esse motivo, as opções do PowerPoint estão sob **Preset**. As opções Predefinidas são essencialmente uma combinação já conhecida de dois ou mais efeitos com boa aparência. Dessa forma, ao selecionar uma predefinição, você não precisará perder tempo testando ou combinando diferentes efeitos para encontrar uma boa combinação.

Aspose.Slides fornece propriedades e métodos na classe [EffectFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/EffectFormat) que permitem aplicar os mesmos efeitos a formas em apresentações do PowerPoint.

## **Aplicar efeito de sombra**

Este código JavaScript mostra como aplicar o efeito de sombra externa ([getOuterShadowEffect](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/EffectFormat#getOuterShadowEffect)) a um retângulo:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(java.getStaticFieldValue("java.awt.Color", "DARK_GRAY"));
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Aplicar efeito de reflexão**

Este código JavaScript mostra como aplicar o efeito de reflexão a uma forma:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(aspose.slides.RectangleAlignment.Bottom);
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(55);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(4);
    pres.save("reflection.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Aplicar efeito de brilho**

Este código JavaScript mostra como aplicar o efeito de brilho a uma forma:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableGlowEffect();
    shape.getEffectFormat().getGlowEffect().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
    shape.getEffectFormat().getGlowEffect().setRadius(15);
    pres.save("glow.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Aplicar efeito de bordas suaves**

Este código JavaScript mostra como aplicar as bordas suaves a uma forma:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(15);
    pres.save("softEdges.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Posso aplicar vários efeitos à mesma forma?**

Sim, você pode combinar diferentes efeitos, como sombra, reflexão e brilho, em uma única forma para criar uma aparência mais dinâmica.

**Quais formas posso aplicar efeitos?**

Você pode aplicar efeitos a várias formas, incluindo autoshapes, gráficos, tabelas, imagens, objetos SmartArt, objetos OLE e muito mais.

**Posso aplicar efeitos a formas agrupadas?**

Sim, você pode aplicar efeitos a formas agrupadas. O efeito será aplicado a todo o grupo.