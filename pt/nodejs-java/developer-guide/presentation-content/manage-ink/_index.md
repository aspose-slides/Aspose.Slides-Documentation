---
title: Gerenciar Objetos de Tinta de Apresentação em JavaScript
linktitle: Gerenciar Tinta
type: docs
weight: 95
url: /pt/nodejs-java/manage-ink/
keywords:
- tinta
- objeto de tinta
- traço de tinta
- gerenciar tinta
- desenhar tinta
- desenho
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Gerencie objetos de tinta do PowerPoint—crie, edite e estilize tinta digital com Aspose.Slides para Node.js. Obtenha exemplos de código JavaScript para traços, cor e tamanho do pincel."
---
## **Introdução**

PowerPoint oferece a função de tinta para permitir que você desenhe figuras não‑padrão, que podem ser usadas para destacar outros objetos, mostrar conexões e processos, e chamar a atenção para itens específicos em um slide. 

Aspose.Slides fornece todos os tipos de Ink (por exemplo, a classe [Ink](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ink/)) que você precisa para criar e gerenciar objetos de tinta.

## **Diferenças entre Objeto Normal e Objetos de Tinta**

Objetos em um slide do PowerPoint são tipicamente representados por objetos de forma. Um objeto de forma, em sua forma mais simples, é um contêiner que define a área do próprio objeto (sua moldura) juntamente com suas propriedades. Estas últimas incluem o tamanho da área do contêiner, a forma do contêiner, o plano de fundo do contêiner, etc. Para informações, veja [Formato de Layout de Forma](https://docs.aspose.com/slides/pt/nodejs-java/shape-manipulations/#access-layout-formats-for-shape).

Contudo, quando o PowerPoint lida com um objeto de tinta, ele ignora todas as propriedades da moldura do objeto (contêiner) exceto seu tamanho. O tamanho da área do contêiner é determinado pelos valores padrão `width` e `height`:

![ink_powerpoint1](ink_powerpoint1.png)

## **Traços de Inkshape**

Traço é um elemento básico ou padrão usado para registrar a trajetória de uma caneta enquanto o usuário escreve tinta digital. Traços são gravações que descrevem sequências de pontos conectados. 

A forma mais simples de codificação especifica as coordenadas X e Y de cada ponto de amostra. Quando todos os pontos conectados são renderizados, produzem uma imagem como esta:

![ink_powerpoint2](ink_powerpoint2.png)

## Propriedades do Pincel para Desenho 

Você pode usar um pincel para desenhar linhas conectando os pontos dos elementos de traço. O pincel tem sua própria cor e tamanho, correspondendo aos métodos `Brush.setColor` e `Brush.setSize`. 

### **Definir Cor do Pincel de Ink**

Este código JavaScript mostra como definir a cor para um pincel:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var ink = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var traces = ink.getTraces();
    var brush = traces[0].getBrush();
    var brushColor = brush.getColor();
    brush.setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Definir Tamanho do Pincel de Ink** 

Este código JavaScript mostra como definir o tamanho para um pincel:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var ink = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var traces = ink.getTraces();
    var brush = traces[0].getBrush();
    var brushSize = brush.getSize();
    brush.setSize(java.newInstanceSync("java.awt.Dimension", 5, 10));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Geralmente, a largura e a altura de um pincel não coincidem, portanto o PowerPoint não exibe o tamanho do pincel (a seção de dados fica acinzentada). Mas quando a largura e a altura do pincel coincidem, o PowerPoint exibe seu tamanho desta forma:

![ink_powerpoint3](ink_powerpoint3.png)

Para clareza, vamos aumentar a altura do objeto de tinta e revisar as dimensões importantes: 

![ink_powerpoint4](ink_powerpoint4.png)

O contêiner (moldura) não considera o tamanho dos pincéis — ele sempre supõe que a espessura da linha é zero (veja a última imagem). 

Portanto, para determinar a área visível de todo o objeto de tinta, devemos considerar o tamanho do pincel dos objetos de traço. Aqui, o objeto alvo (o objeto de traço de texto manuscrito) foi redimensionado para o tamanho do contêiner (moldura). Quando o tamanho do contêiner (moldura) muda, o tamanho do pincel permanece constante e vice‑versa. 

![ink_powerpoint5](ink_powerpoint5.png)

O PowerPoint apresenta o mesmo comportamento ao lidar com textos:

![ink_powerpoint6](ink_powerpoint6.png)

**Leitura adicional**

* Para ler sobre formas em geral, veja a seção [Formas do PowerPoint](https://docs.aspose.com/slides/pt/nodejs-java/powerpoint-shapes/).
* Para mais informações sobre valores efetivos, veja [Propriedades Efetivas da Forma](https://docs.aspose.com/slides/pt/nodejs-java/shape-effective-properties/#getting-effective-font-height-value).