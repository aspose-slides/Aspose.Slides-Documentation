---
title: Aplicar Efeitos de Forma em Apresentações Usando PHP
linktitle: Efeito de Forma
type: docs
weight: 30
url: /pt/php-java/shape-effect/
keywords:
- efeito de forma
- efeito de sombra
- efeito de reflexão
- efeito de brilho
- efeito de bordas suaves
- formato de efeito
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Transforme seus arquivos PPT e PPTX com efeitos de forma avançados usando Aspose.Slides for PHP via Java—crie slides impressionantes e profissionais em segundos."
---
## **Introdução**

Embora os efeitos no PowerPoint possam ser usados para fazer uma forma se destacar, eles diferem dos [preenchimentos](/slides/pt/php-java/shape-formatting/#gradient-fill) ou contornos. Usando efeitos do PowerPoint, você pode criar reflexos convincentes em uma forma, espalhar o brilho de uma forma, etc.

![Efeito de forma](shape-effect.png)

O PowerPoint fornece seis efeitos que podem ser aplicados a formas. Você pode aplicar um ou mais efeitos a uma forma.

Algumas combinações de efeitos ficam melhores que outras. Por esse motivo, o PowerPoint oferece opções sob **Preset**. As opções Preset são combinações de dois ou mais efeitos que são conhecidos por ficar bem. Dessa forma, ao selecionar um preset, você não precisará perder tempo testando ou combinando diferentes efeitos para encontrar uma boa combinação.

Aspose.Slides fornece propriedades e métodos na classe [EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/) que permitem aplicar os mesmos efeitos a formas em apresentações do PowerPoint.

## **Aplicar um Efeito de Sombra**

Aspose.Slides for PHP via Java oferece sombras externas e internas para formas. Você pode personalizar sua cor, direção, distância e raio de desfoque para combinar com o design da sua apresentação.

### **Aplicar uma Sombra Externa**

Use uma sombra externa para fazer um cartão ou painel se destacar em relação ao fundo do slide. A sombra se estende além das bordas da forma, criando a impressão de que a forma está elevada acima do slide. Ajuste sua cor, direção, distância e raio de desfoque para combinar com a iluminação e o estilo do seu modelo.

Este código PHP mostra como aplicar o [efeito de sombra externa](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getOuterShadowEffect) a um retângulo:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableOuterShadowEffect();
    $shadowColor = new Java("java.awt.Color", 169, 169, 169);
    $shape->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->setColor($shadowColor);
    $shape->getEffectFormat()->getOuterShadowEffect()->setDistance(10);
    $shape->getEffectFormat()->getOuterShadowEffect()->setDirection(45);

    $presentation->save("shadow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Efeito de sombra](shadow_effect.png)

### **Aplicar uma Sombra Interna**

Ao reproduzir o estilo visual de um modelo, use uma sombra interna para dar a um cartão ou painel uma aparência rebaixada. Uma sombra externa se estende fora da forma e a faz parecer elevada, enquanto uma sombra interna sombreia o interior de suas bordas.

Chame [enableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enableInnerShadowEffect), então configure a sombra retornada por [getInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getInnerShadowEffect). Valores maiores de raio de desfoque produzem bordas mais suaves.

Este exemplo PHP cria um cartão azul‑claro com uma sombra interna cinza‑escura e o salva como um arquivo PPTX. A direção da sombra é 225 graus, sua distância é 7 pontos e seu raio de desfoque é 6 pontos:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 200, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 173, 216, 230);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $shape->getEffectFormat()->enableInnerShadowEffect();
    $shadow = $shape->getEffectFormat()->getInnerShadowEffect();
    $shadowColor = new Java("java.awt.Color", 105, 105, 105);
    $shadow->getShadowColor()->setColor($shadowColor);
    $shadow->setDirection(225);
    $shadow->setDistance(7);
    $shadow->setBlurRadius(6);

    $presentation->save("inner_shadow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Retângulo azul‑claro com sombra interna](inner_shadow_effect.png)

Para remover a sombra interna, chame [disableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableInnerShadowEffect) no formato de efeito da forma.

## **Aplicar um Efeito de Reflexo**

Para aplicar um efeito de reflexo no Aspose.Slides for PHP via Java, você pode adicionar um reflexo semelhante a um espelho nas formas, ajustando parâmetros como distância, transparência e tamanho. Esse efeito realça a estética das suas apresentações ao conferir às formas um aspecto mais polido e sofisticado. É fácil de implementar com código simples, permitindo aplicação rápida em vários elementos para um design consistente.

Este código PHP mostra como aplicar o [efeito de reflexo](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getReflectionEffect) a uma forma:

```php
use aspose\slides\Presentation;
use aspose\slides\RectangleAlignment;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableReflectionEffect();
    $shape->getEffectFormat()->getReflectionEffect()->setRectangleAlign(RectangleAlignment::Bottom);
    $shape->getEffectFormat()->getReflectionEffect()->setDirection(90);
    $shape->getEffectFormat()->getReflectionEffect()->setDistance(40);
    $shape->getEffectFormat()->getReflectionEffect()->setBlurRadius(2);

    $presentation->save("reflection_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Efeito de reflexo](reflection_effect.png)

## **Aplicar um Efeito de Brilho**

Para aplicar um efeito de brilho a uma forma no Aspose.Slides for PHP via Java, você pode adicionar uma aura suave e luminosa ao redor das formas, ajustando propriedades como cor e tamanho. Esse efeito ajuda a destacar as formas e adiciona um elemento visual atraente e chamativo à sua apresentação. É fácil de implementar com código mínimo, aprimorando a aparência geral dos seus slides.

Este código PHP mostra como aplicar o [efeito de brilho](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getGlowEffect) a uma forma:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableGlowEffect();
    $shape->getEffectFormat()->getGlowEffect()->getColor()->setColor(java("java.awt.Color")->MAGENTA);
    $shape->getEffectFormat()->getGlowEffect()->setRadius(15);

    $presentation->save("glow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Efeito de brilho](glow_effect.png)

## **Aplicar um Efeito de Bordas Suaves**

Para aplicar um efeito de bordas suaves no Aspose.Slides for PHP via Java, você pode criar uma transição lisa e desfocada ao redor das bordas de uma forma. Esse efeito adiciona um visual mais sutil e refinado, perfeito para designs que precisam de uma aparência delicada e mais suave. Você pode ajustar facilmente parâmetros como raio para obter o efeito desejado em várias formas da sua apresentação.

Este código PHP mostra como aplicar o [efeito de bordas suaves](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getSoftEdgeEffect) a uma forma:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 150);
    $shape->getEffectFormat()->enableSoftEdgeEffect();
    $shape->getEffectFormat()->getSoftEdgeEffect()->setRadius(8);

    $presentation->save("soft_edges_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Efeito de bordas suaves](soft_edges_effect.png)

## **Aplicar um Efeito de Desfoque**

Use desfoque de forma para suavizar o preenchimento e o contorno de uma forma mantendo-a editável. Chame [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect) no formato de efeito da forma. O raio é medido em pontos (1/72 polegada): use um valor não negativo, com valores maiores produzindo desfoque mais forte. Um raio zero deixa a aparência inalterada.

A configuração [getGrow](https://reference.aspose.com/slides/php-java/aspose.slides/blur/#getGrow) controla os limites visíveis do efeito. Com `false`, o desfoque é recortado aos limites pintados originais, incluindo o contorno. Com `true`, o desfoque pode se estender além desses limites. Nenhuma das configurações altera a posição ou as dimensões da forma.

A comparação abaixo usa o mesmo preenchimento, contorno e dimensões de forma em todo o exemplo. A linha superior usa `grow = false`; a linha inferior usa `grow = true`.

![Retângulo original comparado com raios de desfoque de 5 e 15 pontos, com grow desativado e ativado](shape_blur_comparison.png)

Este exemplo PHP cria um retângulo laranja com contorno azul‑escuro, aplica um desfoque de 5 pontos e depois o atualiza para 15 pontos chamando [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect) novamente. Ele salva ambos os estados desfocados, então chama [disableBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableBlurEffect) e salva a forma sem desfoque.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 80, 160, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 165, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $lineColor = new Java("java.awt.Color", 0, 0, 139);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
    $shape->getLineFormat()->setWidth(8);

    $shape->getEffectFormat()->setBlurEffect(5, false);
    $presentation->save("shape_blur_5.pptx", SaveFormat::Pptx);

    $shape->getEffectFormat()->setBlurEffect(15, true);
    $presentation->save("shape_blur_15.pptx", SaveFormat::Pptx);

    $shape->getEffectFormat()->disableBlurEffect();
    $presentation->save("shape_blur_removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

O desfoque de forma afeta o preenchimento e o contorno juntos. Um efeito de bordas suaves desvanece as bordas da forma, enquanto o desfoque de sombra suaviza apenas a sombra. Os efeitos de transformação de imagem operam no conteúdo da imagem; este exemplo aplica desfoque diretamente ao formato de efeito da forma sem converter a forma em imagem.

## **Perguntas Frequentes**

**Posso aplicar múltiplos efeitos à mesma forma?**

Sim, você pode combinar diferentes efeitos, como sombra, reflexo e brilho, em uma única forma para criar uma aparência mais dinâmica.

**A quais formas posso aplicar efeitos?**

Você pode aplicar efeitos a várias formas, incluindo autoshapes, gráficos, tabelas, imagens, objetos SmartArt, objetos OLE e muito mais.

**Posso aplicar efeitos a formas agrupadas?**

Sim, você pode aplicar efeitos a formas agrupadas. O efeito será aplicado a todo o grupo.