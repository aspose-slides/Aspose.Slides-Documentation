---
title: Gerenciar objetos de tinta da apresentação em C++
linktitle: Gerenciar tinta
type: docs
weight: 95
url: /pt/cpp/manage-ink/
keywords:
- tinta
- objeto de tinta
- traço de tinta
- gerenciar tinta
- desenhar tinta
- desenho
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Gerencie objetos de tinta do PowerPoint — crie, edite e estilize tinta digital com Aspose.Slides para C++. Obtenha exemplos de código para traços, cor e tamanho do pincel."
---
## **Introdução**

O PowerPoint fornece a função de tinta para permitir que você desenhe figuras não padrão, que podem ser usadas para destacar outros objetos, mostrar conexões e processos e chamar a atenção para itens específicos em um slide. 

Aspose.Slides fornece a interface [Aspose.Slides.Ink](https://reference.aspose.com/slides/pt/cpp/aspose.slides.ink/) que contém os tipos necessários para criar e gerenciar objetos de tinta. 

## **Diferenças entre Objetos Regulares e Objetos Ink**

Objetos em um slide do PowerPoint são tipicamente representados por objetos de forma. Um objeto de forma, em sua forma mais simples, é um contêiner que define a área do próprio objeto (sua moldura) juntamente com suas propriedades. Estas incluem o tamanho da área do contêiner, a forma do contêiner, o plano de fundo do contêiner etc. Para obter informações, veja [Shape Layout Format](https://docs.aspose.com/slides/pt/cpp/shape-manipulations/#access-layout-formats-for-shape).

Entretanto, ao lidar com um objeto Ink, o PowerPoint ignora todas as propriedades da moldura do objeto (contêiner) exceto seu tamanho. O tamanho da área do contêiner é determinado pelos valores padrão `width` e `height`:

![ink_powerpoint1](ink_powerpoint1.png)

## **Traços de Inkshape**

Traço é um elemento básico ou padrão usado para registrar a trajetória de uma caneta enquanto o usuário escreve tinta digital. Traços são gravações que descrevem sequências de pontos conectados. 

A forma mais simples de codificação especifica as coordenadas X e Y de cada ponto de amostra. Quando todos os pontos conectados são renderizados, eles produzem uma imagem como esta:

![ink_powerpoint2](ink_powerpoint2.png)

## **Propriedades de Pincel para Desenho**

Você pode usar um pincel para desenhar linhas que conectam os pontos dos elementos de traço. O pincel tem sua própria cor e tamanho, correspondentes às propriedades `Brush.Color` e `Brush.Size`. 

### **Definir Cor do Pincel Ink**

Este código C++ mostra como definir a cor de um pincel:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<IInk> ink = System::ExplicitCast<IInk>(pres->get_Slide(0)->get_Shape(0));
System::ArrayPtr<System::SharedPtr<IInkTrace>> traces = ink->get_Traces();
System::SharedPtr<IInkBrush> brush = traces[0]->get_Brush();
System::Drawing::Color brushColor = brush->get_Color();
brush->set_Color(System::Drawing::Color::get_Red());
```

### **Definir Tamanho do Pincel Ink**

Este código C++ mostra como definir o tamanho de um pincel:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<IInk> ink = System::ExplicitCast<IInk>(pres->get_Slide(0)->get_Shape(0));
System::ArrayPtr<System::SharedPtr<IInkTrace>> traces = ink->get_Traces();
System::SharedPtr<IInkBrush> brush = traces[0]->get_Brush();
System::Drawing::SizeF brushSize = brush->get_Size();
brush->set_Size(System::Drawing::SizeF(5.0f, 10.0f));
```

Geralmente, a largura e a altura de um pincel não coincidem, portanto o PowerPoint não exibe o tamanho do pincel (a seção de dados fica cinza). Mas quando a largura e a altura do pincel coincidem, o PowerPoint exibe seu tamanho da seguinte forma:

![ink_powerpoint3](ink_powerpoint3.png)

Para maior clareza, vamos aumentar a altura do objeto de tinta e revisar as dimensões importantes: 

![ink_powerpoint4](ink_powerpoint4.png)

O contêiner (moldura) não considera o tamanho dos pincéis — ele sempre assume que a espessura da linha é zero (veja a última imagem). 

Portanto, para determinar a área visível de todo o objeto Ink, devemos considerar o tamanho do pincel dos objetos de traço. Aqui, o objeto alvo (o objeto de traço de texto manuscrito) foi dimensionado ao tamanho do contêiner (moldura). Quando o tamanho do contêiner (moldura) muda, o tamanho do pincel permanece constante e vice‑versa. 

![ink_powerpoint5](ink_powerpoint5.png)

O PowerPoint apresenta o mesmo comportamento ao lidar com textos:

![ink_powerpoint6](ink_powerpoint6.png)

**Leitura adicional**

* Para ler sobre formas em geral, consulte a seção [PowerPoint Shapes](https://docs.aspose.com/slides/pt/cpp/powerpoint-shapes/). 
* Para mais informações sobre valores efetivos, veja [Shape Effective Properties](https://docs.aspose.com/slides/pt/cpp/shape-effective-properties/#get-effective-font-height-value).