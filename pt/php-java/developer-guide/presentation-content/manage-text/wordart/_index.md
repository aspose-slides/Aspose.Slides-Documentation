---
title: Criar e Aplicar Efeitos WordArt em PHP
linktitle: WordArt
type: docs
weight: 110
url: /pt/php-java/wordart/
keywords:
- WordArt
- criar WordArt
- modelo WordArt
- efeito WordArt
- efeito sombra
- efeito exibição
- efeito brilho
- transformação WordArt
- efeito 3D
- efeito sombra externa
- efeito sombra interna
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Crie e personalize efeitos WordArt no Aspose.Slides para PHP via Java. Este guia passo a passo ajuda desenvolvedores a melhorar apresentações com texto profissional."
---
## **Visão geral**

Os efeitos WordArt permitem adicionar texto estilizado e visualmente atraente às suas apresentações do PowerPoint. Com Aspose.Slides, desenvolvedores podem criar, personalizar e gerenciar WordArt programaticamente, assim como no Microsoft PowerPoint — sem necessidade de ter o Office instalado. Este artigo fornece uma visão geral sobre como trabalhar com WordArt, incluindo como aplicar transformações de texto, estilos de preenchimento, contornos, sombras e outras opções de formatação para tornar o conteúdo da sua apresentação mais expressivo e envolvente. O WordArt permite tratar o texto como um objeto gráfico. Consiste em efeitos ou modificações especiais aplicadas ao texto para torná‑lo mais atrativo ou perceptível.

## **Criar um modelo WordArt simples e aplicá‑lo ao texto**

**Usando Aspose.Slides** 

Primeiro, criamos um texto simples usando este código PHP:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $autoShape->getTextFrame();
    $portion = $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
Agora, definimos a altura da fonte do texto para um valor maior, de modo que o efeito fique mais perceptível, através deste código:

```php
  $fontData = new FontData("Arial Black");
  $portion->getPortionFormat()->setLatinFont($fontData);
  $portion->getPortionFormat()->setFontHeight(36);

```

**Usando Microsoft PowerPoint**

Acesse o menu de efeitos WordArt no Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

No painel à direita, você pode escolher um efeito WordArt pré‑definido. No painel à esquerda, pode especificar as configurações para um novo WordArt. 

Estes são alguns dos parâmetros ou opções disponíveis:

![todo:image_alt_text](image-20200930114015-3.png)

**Usando Aspose.Slides**

Aqui, aplicamos a cor de padrão [SmallGrid](https://reference.aspose.com/slides/pt/php-java/aspose.slides/patternstyle/#SmallGrid) ao texto e adicionamos um contorno preto de largura 1 usando este código:

```php
  $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Pattern);
  $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->ORANGE);
  $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->WHITE);
  $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle->SmallGrid);
  $portion->getPortionFormat()->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $portion->getPortionFormat()->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

```

O texto resultante:

![todo:image_alt_text](image-20200930114108-4.png)

## **Aplicar outros efeitos WordArt**

**Usando Microsoft PowerPoint**

Pela interface do programa, você pode aplicar esses efeitos a um texto, bloco de texto, forma ou elemento similar:

![todo:image_alt_text](image-20200930114129-5.png)

Por exemplo, os efeitos Sombra, Reflexo e Brilho podem ser aplicados a um texto; os efeitos Formato 3D e Rotação 3D podem ser aplicados a um bloco de texto; a propriedade Borda Suave pode ser aplicada a um Objeto Forma (ela ainda tem efeito quando nenhuma propriedade Formato 3D está definida). 

### **Aplicar efeitos de sombra**

Aqui, pretendemos definir as propriedades relacionadas apenas ao texto. Aplicamos o efeito de sombra ao texto usando este código:

```php
  $portion->getPortionFormat()->getEffectFormat()->enableOuterShadowEffect();
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->setColor(java("java.awt.Color")->BLACK);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setScaleHorizontal(100);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setScaleVertical(65);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setBlurRadius(4.73);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setDirection(230);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setDistance(2);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setSkewHorizontal(30);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setSkewVertical(0);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->getColorTransform()->add(ColorTransformOperation->SetAlpha, 0.32);

```

A API Aspose.Slides oferece três tipos de sombras: OuterShadow, InnerShadow e PresetShadow. 

Com PresetShadow, você pode aplicar uma sombra a um texto (usando valores predefinidos). 

**Usando Microsoft PowerPoint**

No PowerPoint, você pode usar um tipo de sombra. Veja um exemplo:

![todo:image_alt_text](image-20200930114225-6.png)

**Usando Aspose.Slides**

O Aspose.Slides realmente permite aplicar dois tipos de sombras ao mesmo tempo: InnerShadow e PresetShadow.

**Observações:**

- Quando OuterShadow e PresetShadow são usados juntos, somente o efeito OuterShadow é aplicado. 
- Se OuterShadow e InnerShadow forem usados simultaneamente, o efeito resultante ou aplicado depende da versão do PowerPoint. Por exemplo, no PowerPoint 2013, o efeito é duplicado. Mas no PowerPoint 2007, o efeito OuterShadow é aplicado. 

### **Aplicar efeitos de reflexo ao texto**

Adicionamos reflexo ao texto através deste exemplo de código:

```php
  $portion->getPortionFormat()->getEffectFormat()->enableReflectionEffect();
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setBlurRadius(0.5);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setDistance(4.72);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setStartPosAlpha(0.0);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setEndPosAlpha(60.0);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setDirection(90);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setScaleHorizontal(100);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setScaleVertical(-100);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setStartReflectionOpacity(60.0);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setEndReflectionOpacity(0.9);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setRectangleAlign(RectangleAlignment->BottomLeft);
```

### **Aplicar efeitos de brilho ao texto**

Aplicamos o efeito de brilho ao texto para que ele se destaque usando este código:

```php
  $portion->getPortionFormat()->getEffectFormat()->enableGlowEffect();
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->setR(255);
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->getColorTransform()->add(ColorTransformOperation->SetAlpha, 0.54);
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->setRadius(7);
```

O resultado da operação:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

Você pode alterar os parâmetros de sombra, reflexo e brilho. As propriedades dos efeitos são definidas separadamente para cada porção do texto. 

{{% /alert %}} 

### **Usar transformações no WordArt**

Utilizamos a propriedade Transform (inata a todo o bloco de texto) através deste código:
```php
  $textFrame->getTextFrameFormat()->setTransform(TextShapeType::ArchUpPour);
```

O resultado:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Tanto o Microsoft PowerPoint quanto o Aspose.Slides for PHP via Java fornecem um número definido de tipos de transformação predefinidos.

{{% /alert %}} 

**Usando PowerPoint**

Para acessar os tipos de transformação predefinidos, navegue até: **Format** -> **TextEffect** -> **Transform**

**Usando Aspose.Slides**

Para selecionar um tipo de transformação, use o enum TextShapeType. 

### **Aplicar efeitos 3D ao texto e às formas**

Definimos um efeito 3D a uma forma de texto usando este código de exemplo:

```php
  $autoShape->getThreeDFormat()->getBevelBottom()->setBevelType(BevelPresetType::Circle);
  $autoShape->getThreeDFormat()->getBevelBottom()->setHeight(10.5);
  $autoShape->getThreeDFormat()->getBevelBottom()->setWidth(10.5);
  $autoShape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
  $autoShape->getThreeDFormat()->getBevelTop()->setHeight(12.5);
  $autoShape->getThreeDFormat()->getBevelTop()->setWidth(11);
  $autoShape->getThreeDFormat()->getExtrusionColor()->setColor(java("java.awt.Color")->ORANGE);
  $autoShape->getThreeDFormat()->setExtrusionHeight(6);
  $autoShape->getThreeDFormat()->getContourColor()->setColor(java("java.awt.Color")->RED);
  $autoShape->getThreeDFormat()->setContourWidth(1.5);
  $autoShape->getThreeDFormat()->setDepth(3);
  $autoShape->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);
  $autoShape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
  $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
  $autoShape->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);
  $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);
```

O texto resultante e sua forma:

![todo:image_alt_text](image-20200930114816-9.png)

Aplicamos um efeito 3D ao texto com este código PHP:

```php
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setBevelType(BevelPresetType::Circle);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setHeight(3.5);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setWidth(3.5);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setHeight(4);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setWidth(4);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getExtrusionColor()->setColor(java("java.awt.Color")->ORANGE);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->setExtrusionHeight(6);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getContourColor()->setColor(java("java.awt.Color")->RED);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->setContourWidth(1.5);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->setDepth(3);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);
```

O resultado da operação:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

A aplicação de efeitos 3D a textos ou suas formas e as interações entre os efeitos baseiam‑se em determinadas regras. 

Considere uma cena para um texto e a forma que contém esse texto. O efeito 3D contém a representação do objeto 3D e a cena na qual o objeto foi colocado. 

- Quando a cena está definida tanto para a figura quanto para o texto, a cena da figura tem prioridade maior — a cena do texto é ignorada. 
- Quando a figura não tem sua própria cena, mas possui representação 3D, a cena do texto é usada. 
- Caso contrário — quando a forma originalmente não tem efeito 3D — a forma permanece plana e o efeito 3D é aplicado apenas ao texto. 

Essas descrições estão relacionadas aos métodos ThreeDFormat.getLightRig() e ThreeDFormat.getCamera().

{{% /alert %}} 

## **Aplicar efeitos de sombra externa ao texto**
O Aspose.Slides for PHP via Java fornece as classes [OuterShadow](https://reference.aspose.com/slides/pt/php-java/aspose.slides/outershadow/) e [InnerShadow](https://reference.aspose.com/slides/pt/php-java/aspose.slides/innershadow/) que permitem aplicar efeitos de sombra a um texto contido em um [TextFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/). Siga estas etapas:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/).  
2. Obtenha a referência de um slide usando seu índice.  
3. Adicione uma AutoShape do tipo Retângulo ao slide.  
4. Acesse o TextFrame associado à AutoShape.  
5. Defina o FillType da AutoShape como NoFill.  
6. Instancie a classe OuterShadow.  
7. Defina o BlurRadius da sombra.  
8. Defina a Direction da sombra.  
9. Defina a Distance da sombra.  
10. Defina o RectanglelAlign como TopLeft.  
11. Defina o PresetColor da sombra como Black.  
12. Grave a apresentação como um arquivo [PPTX](https://docs.fileformat.com/presentation/pptx/).  

Este código de exemplo — uma implementação das etapas acima — demonstra como aplicar o efeito de sombra externa a um texto:

```php
  $pres = new Presentation();
  try {
    # Obter referência do slide
    $sld = $pres->getSlides()->get_Item(0);
    # Adicionar um AutoShape do tipo Retângulo
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # Adicionar TextFrame ao Retângulo
    $ashp->addTextFrame("Aspose TextBox");
    # Desativar preenchimento da forma caso queiramos obter sombra do texto
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Adicionar sombra externa e definir todos os parâmetros necessários
    $ashp->getEffectFormat()->enableOuterShadowEffect();
    $shadow = $ashp->getEffectFormat()->getOuterShadowEffect();
    $shadow->setBlurRadius(4.0);
    $shadow->setDirection(45);
    $shadow->setDistance(3);
    $shadow->setRectangleAlign(RectangleAlignment->TopLeft);
    $shadow->getShadowColor()->setPresetColor(PresetColor->Black);
    # Salvar a apresentação no disco
    $pres->save("pres_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Aplicar efeitos de sombra interna às formas**
Siga estas etapas:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/).  
2. Obtenha a referência do slide.  
3. Adicione uma AutoShape do tipo Retângulo.  
4. Habilite InnerShadowEffect.  
5. Defina todos os parâmetros necessários.  
6. Defina o ColorType como Scheme.  
7. Defina a Scheme Color.  
8. Grave a apresentação como um arquivo [PPTX](https://docs.fileformat.com/presentation/pptx/).  

Este código de exemplo (baseado nas etapas acima) mostra como adicionar um conector entre duas formas:

```php
  $pres = new Presentation();
  try {
    # Obter referência do slide
    $slide = $pres->getSlides()->get_Item(0);
    # Adicionar um AutoShape do tipo Retângulo
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 400, 300);
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Adicionar TextFrame ao Retângulo
    $ashp->addTextFrame("Aspose TextBox");
    $port = $ashp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $pf = $port->getPortionFormat();
    $pf->setFontHeight(50);
    # Habilitar InnerShadowEffect
    $ef = $pf->getEffectFormat();
    $ef->enableInnerShadowEffect();
    # Definir todos os parâmetros necessários
    $ef->getInnerShadowEffect()->setBlurRadius(8.0);
    $ef->getInnerShadowEffect()->setDirection(90.0);
    $ef->getInnerShadowEffect()->setDistance(6.0);
    $ef->getInnerShadowEffect()->getShadowColor()->setB(189);
    # Definir ColorType como Scheme
    $ef->getInnerShadowEffect()->getShadowColor()->setColorType(ColorType::Scheme);
    # Definir Cor do Esquema
    $ef->getInnerShadowEffect()->getShadowColor()->setSchemeColor(SchemeColor->Accent1);
    # Salvar a apresentação
    $pres->save("WordArt_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Perguntas frequentes**

**Posso usar efeitos WordArt com diferentes fontes ou scripts (por exemplo, árabe, chinês)?**

Sim, o Aspose.Slides oferece suporte a Unicode e funciona com todas as principais fontes e scripts. Os efeitos WordArt, como sombra, preenchimento e contorno, podem ser aplicados independentemente do idioma, embora a disponibilidade da fonte e a renderização possam depender das fontes instaladas no sistema.

**Posso aplicar efeitos WordArt a elementos do slide mestre?**

Sim, você pode aplicar efeitos WordArt a formas em slides mestres, incluindo marcadores de título, rodapés ou texto de fundo. As alterações feitas no layout mestre serão refletidas em todos os slides associados.

**Os efeitos WordArt afetam o tamanho do arquivo da apresentação?**

Um pouco. Efeitos WordArt como sombras, brilhos e preenchimentos em degradê podem aumentar ligeiramente o tamanho do arquivo devido ao metadado de formatação adicional, mas a diferença costuma ser insignificante.

**Posso visualizar o resultado dos efeitos WordArt sem salvar a apresentação?**

Sim, você pode renderizar slides contendo WordArt como imagens (por exemplo, PNG, JPEG) usando o método `getImage` das classes [Shape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/) ou [Slide](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slide/). Isso permite pré‑visualizar o resultado em memória ou na tela antes de salvar ou exportar a apresentação completa.