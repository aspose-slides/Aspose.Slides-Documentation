---
title: Gerenciar Objetos de Tinta em Apresentações com Python
linktitle: Gerenciar Tinta
type: docs
weight: 95
url: /pt/python-net/manage-ink/
keywords:
- tinta
- objeto de tinta
- rastro de tinta
- gerenciar tinta
- desenhar tinta
- desenho
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Gerencie objetos de tinta do PowerPoint — crie, edite e estilize tinta digital com Aspose.Slides para Python via .NET. Obtenha exemplos de código para rastros, cor e tamanho do pincel."
---
## **Introdução**

O PowerPoint oferece a função de tinta para permitir que você desenhe figuras não padronizadas, que podem ser usadas para destacar outros objetos, mostrar conexões e processos e chamar a atenção para itens específicos em um slide. 

Aspose.Slides fornece o namespace [aspose.slides.ink](https://reference.aspose.com/slides/pt/python-net/aspose.slides.ink/), que contém os tipos necessários para criar e gerenciar objetos de tinta. 

## **Diferenças entre Objeto Regular e Objetos de Tinta**

Objetos em um slide do PowerPoint são tipicamente representados por objetos de forma. Um objeto de forma, em sua forma mais simples, é um contêiner que define a área do próprio objeto (sua moldura) juntamente com suas propriedades. Estas incluem o tamanho da área do contêiner, o formato do contêiner, o plano de fundo do contêiner etc. Para mais informações, veja [Formato de Layout de Forma](https://docs.aspose.com/slides/pt/python-net/shape-manipulations/#access-layout-formats-for-shape).

Entretanto, quando o PowerPoint lida com um objeto de tinta, ele ignora todas as propriedades da moldura do objeto (contêiner) exceto seu tamanho. O tamanho da área do contêiner é determinado pelos valores padrão `width` e `height`:

![ink_powerpoint1](ink_powerpoint1.png)

## **Rastros de Inkshape**

Rastro é um elemento básico ou padrão usado para registrar a trajetória de uma caneta enquanto o usuário escreve tinta digital. Rastos são gravações que descrevem sequências de pontos conectados. 

A forma mais simples de codificação especifica as coordenadas X e Y de cada ponto de amostra. Quando todos os pontos conectados são renderizados, eles produzem uma imagem como esta:

![ink_powerpoint2](ink_powerpoint2.png)

## Propriedades do Pincel para Desenho 

Você pode usar um pincel para desenhar linhas que conectam os pontos dos elementos de rastro. O pincel tem sua própria cor e tamanho, correspondentes às propriedades `Brush.color` e `Brush.size`. 

### **Definir Cor do Pincel de Tinta**

Este código Python mostra como definir a cor para um pincel:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as pres:
    ink = pres.slides[0].shapes[0]
    traces = ink.traces
    brush = traces[0].brush
    brush_color = brush.color
    brush.color = draw.Color.red
```

### **Definir Tamanho do Pincel de Tinta** 

Este código Python mostra como definir o tamanho para um pincel:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as pres:
    ink = pres.slides[0].shapes[0]
    traces = ink.traces
    brush = traces[0].brush
    brush_size = brush.size
    brush.size = draw.SizeF(5.0, 10.0)
```

Geralmente, a largura e a altura de um pincel não coincidem, portanto o PowerPoint não exibe o tamanho do pincel (a seção de dados fica esmaecida). Mas quando a largura e a altura do pincel coincidem, o PowerPoint exibe seu tamanho da seguinte forma:

![ink_powerpoint3](ink_powerpoint3.png)

Para clareza, vamos aumentar a altura do objeto de tinta e revisar as dimensões importantes: 

![ink_powerpoint4](ink_powerpoint4.png)

O contêiner (moldura) não considera o tamanho dos pincéis — ele sempre assume que a espessura da linha é zero (veja a última imagem). 

Portanto, para determinar a área visível de todo o objeto de tinta, devemos considerar o tamanho do pincel dos objetos de rastro. Aqui, o objeto-alvo (o objeto de rastro de texto manuscrito) foi dimensionado para o tamanho do contêiner (moldura). Quando o tamanho do contêiner (moldura) muda, o tamanho do pincel permanece constante e vice‑versa. 

![ink_powerpoint5](ink_powerpoint5.png)

O PowerPoint apresenta o mesmo comportamento ao lidar com textos:

![ink_powerpoint6](ink_powerpoint6.png)

**Leitura adicional**

* Para ler sobre formas em geral, consulte a seção [PowerPoint Shapes](https://docs.aspose.com/slides/pt/python-net/powerpoint-shapes/). 
* Para mais informações sobre valores efetivos, veja [Shape Effective Properties](https://docs.aspose.com/slides/pt/python-net/shape-effective-properties/#get-effective-font-height-value).