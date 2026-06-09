---
title: "Gerenciar Temas de Apresentação em PHP"
linktitle: "Tema de Apresentação"
type: docs
weight: 10
url: /pt/php-java/presentation-theme/
keywords:
  - "Tema PowerPoint"
  - "tema de apresentação"
  - "tema de slide"
  - "definir tema"
  - "alterar tema"
  - "gerenciar tema"
  - "cor do tema"
  - "paleta adicional"
  - "fonte do tema"
  - "estilo do tema"
  - "efeito do tema"
  - "PowerPoint"
  - "OpenDocument"
  - "apresentação"
  - "PHP"
  - "Aspose.Slides"
description: "Domine os temas de apresentação no Aspose.Slides para PHP via Java para criar, personalizar e converter arquivos PowerPoint com identidade visual consistente."
---
## **Introdução**

Um tema de apresentação define as propriedades dos elementos de design. Ao selecionar um tema de apresentação, você está essencialmente escolhendo um conjunto específico de elementos visuais e suas propriedades.

No PowerPoint, um tema compreende cores, [fontes](/slides/pt/php-java/powerpoint-fonts/), [estilos de plano de fundo](/slides/pt/php-java/presentation-background/), e efeitos.

![theme-constituents](theme-constitutents.png)

## **Alterar Cor do Tema**

Um tema do PowerPoint usa um conjunto específico de cores para diferentes elementos em um slide. Se você não gostar das cores, pode alterá‑las aplicando novas cores ao tema. Para permitir que você selecione uma nova cor de tema, o Aspose.Slides fornece valores na enumeração [SchemeColor](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SchemeColor).

Este código PHP mostra como alterar a cor de destaque de um tema:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Você pode determinar o valor efetivo da cor resultante desta forma:

```php
  $fillEffective = $shape->getFillFormat()->getEffective();
  $effectiveColor = $fillEffective->getSolidFillColor();
  echo(sprintf("Color [A=%d, R=%d, G=%d, B=%d]", $effectiveColor->getAlpha(), $effectiveColor->getRed(), $effectiveColor->getGreen(), $effectiveColor->getBlue()));
```

Para demonstrar ainda mais a operação de alteração de cor, criamos outro elemento e atribuímos a cor de destaque (da operação inicial) a ele. Em seguida, alteramos a cor no tema:

```php
  $otherShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 120, 100, 100);
  $otherShape->getFillFormat()->setFillType(FillType::Solid);
  $otherShape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
  $pres->getMasterTheme()->getColorScheme()->getAccent4()->setColor(java("java.awt.Color")->RED);

```

A nova cor é aplicada automaticamente em ambos os elementos.

### **Definir Cor do Tema a partir de uma Paleta Adicional**

Quando você aplica transformações de luminância à cor principal do tema(1), cores da paleta adicional(2) são geradas. Você pode então definir e obter essas cores de tema.

![additional-palette-colors](additional-palette-colors.png)

**1** - Cores principais do tema

**2** - Cores da paleta adicional.

Este código PHP demonstra uma operação em que as cores da paleta adicional são obtidas a partir da cor principal do tema e então usadas em formas:

```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # Realce 4
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 50, 50);
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    # Realce 4, 80% mais claro
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 70, 50, 50);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.2);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.8);
    # Realce 4, 60% mais claro
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 130, 50, 50);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.6);
    # Realce 4, 40% mais claro
    $shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 190, 50, 50);
    $shape4->getFillFormat()->setFillType(FillType::Solid);
    $shape4->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.6);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.4);
    # Realce 4, 25% mais escuro
    $shape5 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 250, 50, 50);
    $shape5->getFillFormat()->setFillType(FillType::Solid);
    $shape5->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape5->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.75);
    # Realce 4, 50% mais escuro
    $shape6 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 50, 50);
    $shape6->getFillFormat()->setFillType(FillType::Solid);
    $shape6->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape6->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.5);
    $presentation->save($path . "example_accent4.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

### **Mapear `SchemeColor` para Cores `ColorScheme`**

Ao trabalhar com [SchemeColor](https://reference.aspose.com/slides/pt/php-java/aspose.slides/schemecolor/), você pode notar que ele contém os seguintes valores de cor de tema:

`Background1`, `Background2`, `Text1`, and `Text2`.

Entretanto, `Presentation::getMasterTheme()::getColorScheme()` devolve [ColorScheme](https://reference.aspose.com/slides/pt/php-java/aspose.slides/colorscheme/), que expõe as cores correspondentes como:

`Dark1`, `Dark2`, `Light1`, and `Light2`.

Essa diferença está apenas no nome. Esses valores referem‑se aos mesmos espaços de cor do tema e o mapeamento é fixo:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Não há conversão dinâmica entre `Text`/`Background` e `Dark`/`Light`. Elas são apenas nomes alternativos para as mesmas cores de tema.

Essa diferença de nomenclatura vem da terminologia do Microsoft Office. Versões mais antigas do Office usavam `Dark 1`, `Light 1`, `Dark 2` e `Light 2`, enquanto versões mais recentes da UI exibem os mesmos slots como `Text 1`, `Background 1`, `Text 2` e `Background 2`.

## **Alterar Fonte do Tema**

Para permitir que você selecione fontes para temas e outros fins, o Aspose.Slides usa estes identificadores especiais (semelhantes aos usados no PowerPoint):

* **+mn-lt** - Fonte do Corpo Latin (Fonte Latina Menor)
* **+mj-lt** - Fonte do Cabeçalho Latin (Fonte Latina Maior)
* **+mn-ea** - Fonte do Corpo East Asian (Fonte Leste‑Asiática Menor)
* **+mj-ea** - Fonte do Corpo East Asian (Fonte Leste‑Asiática Maior)

Este código PHP mostra como atribuir a fonte Latin a um elemento do tema:

```php
  $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
  $paragraph = new Paragraph();
  $portion = new Portion("Theme text format");
  $paragraph->getPortions()->add($portion);
  $shape->getTextFrame()->getParagraphs()->add($paragraph);
  $portion->getPortionFormat()->setLatinFont(new FontData("+mn-lt"));
```

Este código PHP mostra como alterar a fonte do tema da apresentação:

```php
  $pres->getMasterTheme()->getFontScheme()->getMinor()->setLatinFont(new FontData("Arial"));
```

A fonte em todas as caixas de texto será atualizada.

{{% alert color="primary" title="TIP" %}} 
Você pode querer ver [fontes do PowerPoint](/slides/pt/php-java/powerpoint-fonts/).
{{% /alert %}}

## **Alterar Estilo de Plano de Fundo do Tema**

Por padrão, o aplicativo PowerPoint oferece 12 planos de fundo predefinidos, mas apenas 3 desses 12 são salvos em uma apresentação típica.

![todo:image_alt_text](presentation-design_8.png)

Por exemplo, depois de salvar uma apresentação no aplicativo PowerPoint, você pode executar este código PHP para descobrir o número de planos de fundo predefinidos na apresentação:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $numberOfBackgroundFills = $pres->getMasterTheme()->getFormatScheme()->getBackgroundFillStyles()->size();
    echo("Number of background fill styles for theme is " . $numberOfBackgroundFills);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" %}} 
Usando a propriedade [BackgroundFillStyles](https://reference.aspose.com/slides/pt/php-java/aspose.slides/FormatScheme#getBackgroundFillStyles--) da classe [FormatScheme](https://reference.aspose.com/slides/pt/php-java/aspose.slides/FormatScheme), você pode adicionar ou acessar o estilo de plano de fundo em um tema do PowerPoint.
{{% /alert %}} 

Este código PHP mostra como definir o plano de fundo para uma apresentação:

```php
  $pres->getMasters()->get_Item(0)->getBackground()->setStyleIndex(2);
```

**Guia de índice**: 0 é usado para sem preenchimento. O índice começa em 1.

{{% alert color="primary" title="TIP" %}} 
Você pode querer ver [Plano de Fundo do PowerPoint](/slides/pt/php-java/presentation-background/).
{{% /alert %}}

## **Alterar Efeito do Tema**

Um tema do PowerPoint geralmente contém 3 valores para cada array de estilo. Esses arrays são combinados nesses 3 efeitos: sutil, moderado e intenso. Por exemplo, este é o resultado quando os efeitos são aplicados a uma forma específica:

![todo:image_alt_text](presentation-design_10.png)

Usando 3 propriedades ([FillStyles](https://reference.aspose.com/slides/pt/php-java/aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/pt/php-java/aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/pt/php-java/aspose.slides/FormatScheme#getEffectStyles--)) da classe [FormatScheme](https://reference.aspose.com/slides/pt/php-java/aspose.slides/FormatScheme) você pode alterar os elementos de um tema (de forma ainda mais flexível que as opções no PowerPoint).

Este código PHP mostra como alterar um efeito de tema modificando partes dos elementos:

```php
  $pres = new Presentation("Subtle_Moderate_Intense.pptx");
  try {
    $pres->getMasterTheme()->getFormatScheme()->getLineStyles()->get_Item(0)->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $pres->getMasterTheme()->getFormatScheme()->getFillStyles()->get_Item(2)->setFillType(FillType::Solid);
    $pres->getMasterTheme()->getFormatScheme()->getFillStyles()->get_Item(2)->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $pres->getMasterTheme()->getFormatScheme()->getEffectStyles()->get_Item(2)->getEffectFormat()->getOuterShadowEffect()->setDistance(10.0);
    $pres->save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

As alterações resultantes na cor de preenchimento, tipo de preenchimento, efeito de sombra, etc.:

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

**Posso aplicar um tema a um único slide sem mudar o mestre?**

Sim. O Aspose.Slides suporta substituições de tema em nível de slide, portanto você pode aplicar um tema local apenas a esse slide enquanto mantém o tema mestre intacto (via o [SlideThemeManager](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slidethememanager/)).

**Qual é a forma mais segura de transferir um tema de uma apresentação para outra?**

[Clonar slides](/slides/pt/php-java/clone-slides/) juntamente com seu mestre para a apresentação de destino. Isso preserva o mestre original, layouts e o tema associado, de modo que a aparência permaneça consistente.

**Como posso ver os valores "efetivos" após toda a herança e substituições?**

Use as ["visualizações efetivas"](/slides/pt/php-java/shape-effective-properties/) da API para tema/cor/fonte/efeito. Elas retornam as propriedades resolvidas e finais após a aplicação do mestre mais quaisquer substituições locais.