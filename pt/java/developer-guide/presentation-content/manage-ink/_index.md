---
title: Gerenciar objetos de tinta de apresentação em Java
linktitle: Gerenciar tinta
type: docs
weight: 95
url: /pt/java/manage-ink/
keywords:
- tinta
- objeto de tinta
- rastro de tinta
- gerenciar tinta
- desenhar tinta
- desenho
- PowerPoint
- apresentação
- Java
- Aspose.Slides
description: "Gerencie objetos de tinta do PowerPoint—crie, edite e estilize tinta digital com Aspose.Slides para Java. Obtenha exemplos de código para rastros, cor e tamanho do pincel."
---
## **Introdução**

O PowerPoint fornece a função de tinta para permitir que você desenhe figuras não padronizadas, que podem ser usadas para destacar outros objetos, mostrar conexões e processos e chamar a atenção para itens específicos em um slide. 

Aspose.Slides fornece todos os tipos de Ink (por exemplo, a classe [Ink](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ink/)) que você precisa para criar e gerenciar objetos de tinta. 

## **Diferenças entre Objetos Regulares e Objetos de Tinta**

Objetos em um slide do PowerPoint são tipicamente representados por objetos de forma. Um objeto de forma, na sua forma mais simples, é um contêiner que define a área do próprio objeto (sua moldura) juntamente com suas propriedades. Estas incluem o tamanho da área do contêiner, o formato do contêiner, o plano de fundo do contêiner etc. Para informações, veja [Formato de Layout de Forma](https://docs.aspose.com/slides/pt/java/shape-manipulations/#access-layout-formats-for-shape).

Entretanto, quando o PowerPoint lida com um objeto de tinta, ele ignora todas as propriedades da moldura do objeto (contêiner) exceto o seu tamanho. O tamanho da área do contêiner é determinado pelos valores padrão `width` e `height`:

![ink_powerpoint1](ink_powerpoint1.png)

## **Rastreamentos de Inkshape**

Um rastreamento é um elemento básico ou padrão usado para registrar a trajetória de uma caneta enquanto o usuário escreve tinta digital. Rastreamentos são gravações que descrevem sequências de pontos conectados. 

A forma mais simples de codificação especifica as coordenadas X e Y de cada ponto de amostra. Quando todos os pontos conectados são renderizados, eles produzem uma imagem como esta:

![ink_powerpoint2](ink_powerpoint2.png)

## **Propriedades do Pincel para Desenho**

Você pode usar um pincel para desenhar linhas que conectam os pontos dos elementos de rastreamento. O pincel tem sua própria cor e tamanho, correspondentes às propriedades `Brush.Color` e `Brush.Size`. 

### **Definir Cor do Pincel de Tinta**

Este código Java mostra como definir a cor para um pincel:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    IInk ink = (IInk)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IInkTrace[] traces = ink.getTraces();
    IInkBrush brush = traces[0].getBrush();
    Color brushColor = brush.getColor();
    brush.setColor(Color.RED);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Definir Tamanho do Pincel de Tinta** 

Este código Java mostra como definir o tamanho para um pincel:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    IInk ink = (IInk)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IInkTrace[] traces = ink.getTraces();
    IInkBrush brush = traces[0].getBrush();
    Dimension2D brushSize = brush.getSize();
    brush.setSize(new Dimension(5, 10));
} finally {
    if (pres != null) pres.dispose();
}
```

Geralmente, a largura e a altura de um pincel não coincidem, de modo que o PowerPoint não exibe o tamanho do pincel (a seção de dados fica cinza). Mas quando a largura e a altura do pincel coincidem, o PowerPoint exibe seu tamanho da seguinte forma:

![ink_powerpoint3](ink_powerpoint3.png)

Para clareza, vamos aumentar a altura do objeto de tinta e revisar as dimensões importantes: 

![ink_powerpoint4](ink_powerpoint4.png)

O contêiner (moldura) não considera o tamanho dos pincéis — ele sempre assume que a espessura da linha é zero (veja a última imagem). 

Portanto, para determinar a área visível de todo o objeto de tinta, devemos levar em conta o tamanho do pincel dos objetos de rastreamento. Aqui, o objeto alvo (o objeto de rastreamento de texto manuscrito) foi dimensionado para o tamanho do contêiner (moldura). Quando o tamanho do contêiner (moldura) muda, o tamanho do pincel permanece constante e vice‑versa. 

![ink_powerpoint5](ink_powerpoint5.png)

O PowerPoint apresenta o mesmo comportamento ao lidar com textos:

![ink_powerpoint6](ink_powerpoint6.png)

**Leitura adicional**

* Para ler sobre formas em geral, veja a seção [Formas do PowerPoint](https://docs.aspose.com/slides/pt/java/powerpoint-shapes/). 
* Para mais informações sobre valores efetivos, veja [Propriedades Efetivas da Forma](https://docs.aspose.com/slides/pt/java/shape-effective-properties/#getting-effective-font-height-value).