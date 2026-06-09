---
title: Gerenciar objetos de tinta da apresentação em PHP
linktitle: Gerenciar tinta
type: docs
weight: 95
url: /pt/php-java/manage-ink/
keywords:
- tinta
- objeto de tinta
- rastreamento de tinta
- gerenciar tinta
- desenhar tinta
- desenho
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Gerencie objetos de tinta do PowerPoint — crie, edite e estilize tinta digital com Aspose.Slides para PHP via Java. Obtenha exemplos de código para rastreamentos, cor e tamanho do pincel."
---
## **Introdução**

O PowerPoint fornece a função de tinta para permitir que você desenhe figuras não padrão, que podem ser usadas para destacar outros objetos, mostrar conexões e processos, e chamar a atenção para itens específicos em um slide. 

Aspose.Slides fornece todos os tipos de Ink (por exemplo, a classe [Ink](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ink/)) que você precisa para criar e gerenciar objetos de tinta.

## **Diferenças entre Objetos Regulares e Objetos de Tinta**

Objetos em um slide do PowerPoint são tipicamente representados por objetos shape. Um objeto shape, em sua forma mais simples, é um contêiner que define a área do próprio objeto (sua moldura) juntamente com suas propriedades. Estas incluem o tamanho da área do contêiner, o formato do contêiner, o plano de fundo do contêiner, etc. Para informações, veja [Shape Layout Format](https://docs.aspose.com/slides/pt/php-java/shape-manipulations/#access-layout-formats-for-shape).

No entanto, quando o PowerPoint está lidando com um objeto de tinta, ele ignora todas as propriedades da moldura do objeto (contêiner) exceto seu tamanho. O tamanho da área do contêiner é determinado pelos valores padrão `width` e `height`:

![ink_powerpoint1](ink_powerpoint1.png)

## **Rastreamentos de Inkshape**

Rastreamento é um elemento básico ou padrão usado para registrar a trajetória de uma caneta enquanto o usuário escreve tinta digital. Rastreamentos são gravações que descrevem sequências de pontos conectados. 

A forma mais simples de codificação especifica as coordenadas X e Y de cada ponto de amostra. Quando todos os pontos conectados são renderizados, eles produzem uma imagem como esta:

![ink_powerpoint2](ink_powerpoint2.png)

## **Propriedades do Pincel para Desenho**

Você pode usar um pincel para desenhar linhas que conectam os pontos dos elementos de rastreamento. O pincel tem sua própria cor e tamanho, correspondentes às propriedades `Brush.Color` e `Brush.Size`. 

### **Definir Cor do Pincel de Tinta**

Este código PHP mostra como definir a cor de um pincel:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $ink = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $traces = $ink->getTraces();
    $brush = $traces[0]->getBrush();
    $brushColor = $brush->getColor();
    $brush->setColor(java("java.awt.Color")->RED);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Definir Tamanho do Pincel de Tinta** 

Este código PHP mostra como definir o tamanho de um pincel:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $ink = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $traces = $ink->getTraces();
    $brush = $traces[0]->getBrush();
    $brushSize = $brush->getSize();
    $brush->setSize(new Java("java.awt.Dimension", 5, 10));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Geralmente, a largura e a altura de um pincel não correspondem, portanto o PowerPoint não exibe o tamanho do pincel (a seção de dados fica esmaecida). Mas quando a largura e a altura do pincel coincidem, o PowerPoint exibe seu tamanho desta forma:

![ink_powerpoint3](ink_powerpoint3.png)

Para maior clareza, vamos aumentar a altura do objeto de tinta e revisar as dimensões importantes: 

![ink_powerpoint4](ink_powerpoint4.png)

O contêiner (quadro) não considera o tamanho dos pincéis — ele sempre assume que a espessura da linha é zero (veja a última imagem). 

Portanto, para determinar a área visível de todo o objeto de tinta, devemos considerar o tamanho do pincel dos objetos de rastreamento. Aqui, o objeto alvo (o objeto de rastreamento de texto manuscrito) foi dimensionado para o tamanho do contêiner (quadro). Quando o tamanho do contêiner (quadro) muda, o tamanho do pincel permanece constante e vice‑versa. 

![ink_powerpoint5](ink_powerpoint5.png)

O PowerPoint apresenta o mesmo comportamento ao lidar com textos:

![ink_powerpoint6](ink_powerpoint6.png)

**Leitura adicional**

* Para ler sobre formas em geral, veja a seção [PowerPoint Shapes](https://docs.aspose.com/slides/pt/php-java/powerpoint-shapes/).
* Para mais informações sobre valores efetivos, veja [Shape Effective Properties](https://docs.aspose.com/slides/pt/php-java/shape-effective-properties/#getting-effective-font-height-value).