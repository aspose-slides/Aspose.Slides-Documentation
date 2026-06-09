---
title: Adicionar Retângulos a Apresentações em PHP
linktitle: Retângulo
type: docs
weight: 80
url: /pt/php-java/rectangle/
keywords:
- adicionar retângulo
- criar retângulo
- forma de retângulo
- retângulo simples
- retângulo formatado
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Impulsione suas apresentações PowerPoint adicionando retângulos com Aspose.Slides para PHP via Java - projete e modifique formas programaticamente com facilidade."
---
## **Visão geral**

Este artigo mostra como adicionar formas de retângulo aos slides do PowerPoint usando Aspose.Slides. Ele cobre a criação de um retângulo simples, a criação de um retângulo formatado e a gravação da apresentação atualizada como um arquivo PPTX.

Você também verá como aplicar formatação básica ao retângulo, como cor de preenchimento sólido, cor da linha e espessura da linha. Além disso, a seção de FAQ do artigo aponta tarefas relacionadas a retângulos, incluindo cantos arredondados, preenchimentos de imagem, efeitos visuais, hyperlinks, bloqueios de forma, opções de exportação e propriedades efetivas.

## **Adicionar um retângulo a um slide**
Para adicionar um retângulo simples a um slide selecionado da apresentação, siga as etapas abaixo:

- Crie uma instância da [Apresentação](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation) classe.
- Obtenha a referência de um slide usando seu Índice.
- Adicione um [AutoShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/) do tipo Rectangle usando o método [addAutoShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shapecollection/#addAutoShape) exposto pelo objeto [ShapeCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shapecollection/).
- Grave a apresentação modificada como um arquivo PPTX.

No exemplo abaixo, adicionamos um retângulo simples ao primeiro slide da apresentação.

```php
  # Instanciar a classe Presentation que representa o PPTX
  $pres = new Presentation();
  try {
    # Obter o primeiro slide
    $sld = $pres->getSlides()->get_Item(0);
    # Adicionar AutoShape do tipo elipse
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 50);
    # Gravar o arquivo PPTX no disco
    $pres->save("RecShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Adicionar um retângulo formatado a um slide**
Para adicionar um retângulo formatado a um slide, siga as etapas abaixo:

- Crie uma instância da [Apresentação](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation) classe.
- Obtenha a referência de um slide usando seu Índice.
- Adicione um [AutoShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/) do tipo Rectangle usando o método [addAutoShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shapecollection/#addAutoShape) exposto pelo objeto [ShapeCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shapecollection/).
- Defina o [Fill Type](https://reference.aspose.com/slides/pt/php-java/aspose.slides/FillType) do retângulo como Solid.
- Defina a Cor do retângulo usando o método [ColorFormat::setColor](https://reference.aspose.com/slides/pt/php-java/aspose.slides/colorformat/#setColor) exposto pelo objeto [FillFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fillformat/) associado ao objeto [Shape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/).
- Defina a Cor das linhas do retângulo.
- Defina a Largura das linhas do retângulo.
- Grave a apresentação modificada como arquivo PPTX.

As etapas acima são implementadas no exemplo abaixo.

```php
  # Instanciar a classe Presentation que representa o PPTX
  $pres = new Presentation();
  try {
    # Obter o primeiro slide
    $sld = $pres->getSlides()->get_Item(0);
    # Adicionar AutoShape do tipo elipse
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 50);
    # Aplicar alguma formatação à forma elipse
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    # Aplicar alguma formatação à linha da elipse
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp->getLineFormat()->setWidth(5);
    # Gravar o arquivo PPTX no disco
    $pres->save("RecShp2.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Como adiciono um retângulo com cantos arredondados?**

Use o [tipo de forma](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shapetype/) de canto arredondado e ajuste o raio do canto nas propriedades da forma; o arredondamento também pode ser aplicado por canto via ajustes de geometria.

**Como preencho um retângulo com uma imagem (textura)?**

Selecione o [tipo de preenchimento](https://reference.aspose.com/slides/pt/php-java/aspose.slides/filltype/) de imagem, forneça a origem da imagem e configure os modos de [estiramento/azulejo](https://reference.aspose.com/slides/pt/php-java/aspose.slides/picturefillmode/).

**Um retângulo pode ter sombra e brilho?**

Sim. [Sombra externa/interna, brilho e bordas suaves](/slides/pt/php-java/shape-effect/) estão disponíveis com parâmetros ajustáveis.

**Posso transformar um retângulo em um botão com hyperlink?**

Sim. [Atribuir um hyperlink](/slides/pt/php-java/manage-hyperlinks/) ao clique da forma (ir para um slide, arquivo, endereço web ou e‑mail).

**Como protejo um retângulo contra movimentos e alterações?**

Use bloqueios de forma: você pode impedir mover, redimensionar, selecionar ou editar texto para preservar o layout.

**Posso converter um retângulo em imagem raster ou SVG?**

Sim. Você pode [render the shape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/#getImage) para uma imagem com tamanho/escala especificados ou [export it as SVG](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/writeassvg/) para uso vetorial.

**Como obtenho rapidamente as propriedades reais (efetivas) de um retângulo considerando tema e herança?**

[Usar as propriedades efetivas da forma](/slides/pt/php-java/shape-effective-properties/): a API devolve valores calculados que consideram estilos de tema, layout e configurações locais, simplificando a análise de formatação.