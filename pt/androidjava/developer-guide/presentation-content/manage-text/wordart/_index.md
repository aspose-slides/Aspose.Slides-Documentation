---
title: Criar e aplicar efeitos WordArt no Android
linktitle: WordArt
type: docs
weight: 110
url: /pt/androidjava/wordart/
keywords:
- WordArt
- criar WordArt
- modelo WordArt
- efeito WordArt
- efeito de sombra
- efeito de exibição
- efeito de brilho
- transformação WordArt
- efeito 3D
- efeito de sombra externa
- efeito de sombra interna
- PowerPoint
- apresentação
- Android
- Java
- Aspose.Slides
description: "Crie e personalize efeitos WordArt no Aspose.Slides para Android. Este guia passo a passo ajuda os desenvolvedores a aprimorar apresentações com texto profissional em Java."
---
## **Visão geral**

Os efeitos WordArt permitem que você adicione texto visualmente atraente e estilizado às suas apresentações PowerPoint. Com Aspose.Slides, os desenvolvedores podem criar, personalizar e gerenciar WordArt programaticamente, como no Microsoft PowerPoint — sem precisar ter o Office instalado. Este artigo fornece uma visão geral sobre o uso de WordArt, incluindo como aplicar transformações de texto, estilos de preenchimento, contornos, sombras e outras opções de formatação para tornar o conteúdo da sua apresentação mais expressivo e envolvente. WordArt permite tratar o texto como um objeto gráfico. Consiste em efeitos ou modificações especiais aplicadas ao texto para torná‑lo mais atraente ou perceptível.

## **Criar um modelo simples de WordArt e aplicá‑lo ao texto**

**Usando Aspose.Slides** 

Primeiro, criamos um texto simples usando este código Java: 

``` java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();

    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    if (pres != null) pres.dispose();
}
```
Agora, definimos a altura da fonte do texto para um valor maior para que o efeito fique mais perceptível, por meio deste código:

``` java 
FontData fontData = new FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```

**Usando o Microsoft PowerPoint**

Acesse o menu de efeitos WordArt no Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

No menu à direita, você pode escolher um efeito WordArt predefinido. No menu à esquerda, pode especificar as configurações para um novo WordArt. 

Estes são alguns dos parâmetros ou opções disponíveis:

![todo:image_alt_text](image-20200930114015-3.png)

**Usando Aspose.Slides**

Aqui, aplicamos a cor de padrão [SmallGrid](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/PatternStyle#SmallGrid) ao texto e adicionamos um contorno preto de largura 1 usando este código:

``` java 
portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.ORANGE);
portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
```

O texto resultante:

![todo:image_alt_text](image-20200930114108-4.png)

## **Aplicar outros efeitos de WordArt**

**Usando o Microsoft PowerPoint**

A partir da interface do programa, você pode aplicar esses efeitos a um texto, bloco de texto, forma ou elemento semelhante:

![todo:image_alt_text](image-20200930114129-5.png)

Por exemplo, efeitos de Sombra, Reflexo e Brilho podem ser aplicados a um texto; efeitos de Formato 3D e Rotação 3D podem ser aplicados a um bloco de texto; a propriedade Borda Suave pode ser aplicada a um Objeto Shape (ela ainda tem efeito quando nenhuma propriedade Formato 3D está definida). 

### **Aplicar efeitos de sombra**

Aqui, pretendemos definir propriedades relacionadas apenas a um texto. Aplicamos o efeito de sombra a um texto usando este código em Java:

``` java
portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.BLACK);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(65);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4.73);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(2);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(30);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32f);
```

A API Aspose.Slides oferece três tipos de sombras: OuterShadow, InnerShadow e PresetShadow. 

Com PresetShadow, você pode aplicar uma sombra a um texto (usando valores predefinidos). 

**Usando o Microsoft PowerPoint**

No PowerPoint, você pode usar um tipo de sombra. Aqui está um exemplo:

![todo:image_alt_text](image-20200930114225-6.png)

**Usando Aspose.Slides**

O Aspose.Slides realmente permite aplicar dois tipos de sombras ao mesmo tempo: InnerShadow e PresetShadow.

**Notas:**

- Quando OuterShadow e PresetShadow são usados juntos, apenas o efeito OuterShadow é aplicado. 
- Se OuterShadow e InnerShadow forem usados simultaneamente, o efeito resultante ou aplicado depende da versão do PowerPoint. Por exemplo, no PowerPoint 2013, o efeito é dobrado. Mas no PowerPoint 2007, o efeito OuterShadow é aplicado. 

### **Aplicar efeitos de reflexo ao texto**

Adicionamos exibição ao texto por meio deste exemplo de código em Java:

``` java
portion.getPortionFormat().getEffectFormat().enableReflectionEffect();
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(0f);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(60f);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(60f);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(0.9f);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.BottomLeft);   
```

### **Aplicar efeitos de brilho ao texto**

Aplicamos o efeito de brilho ao texto para que ele se destaque usando este código:

``` java
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```

O resultado da operação:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

Você pode alterar os parâmetros de sombra, exibição e brilho. As propriedades dos efeitos são definidas separadamente em cada porção do texto. 

{{% /alert %}} 

### **Usar transformações no WordArt**

Usamos a propriedade Transform (inata a todo o bloco de texto) através deste código:
``` java 
textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
```

O resultado:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Tanto o Microsoft PowerPoint quanto o Aspose.Slides para Android via Java oferecem um certo número de tipos de transformação predefinidos.

{{% /alert %}} 

**Usando o PowerPoint**

Para acessar os tipos de transformação predefinidos, navegue em: **Format** -> **TextEffect** -> **Transform**

**Usando Aspose.Slides**

Para selecionar um tipo de transformação, use o enum TextShapeType. 

### **Aplicar efeitos 3D ao texto e formas**

Definimos um efeito 3D a uma forma de texto usando este código de exemplo:

``` java
autoShape.getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);

autoShape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
autoShape.getThreeDFormat().getBevelTop().setWidth(11);

autoShape.getThreeDFormat().getExtrusionColor().setColor(Color.ORANGE);
autoShape.getThreeDFormat().setExtrusionHeight(6);

autoShape.getThreeDFormat().getContourColor().setColor(Color.RED);
autoShape.getThreeDFormat().setContourWidth(1.5);

autoShape.getThreeDFormat().setDepth(3);

autoShape.getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

autoShape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);

autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
```

O texto e a forma resultantes:

![todo:image_alt_text](image-20200930114816-9.png)

Aplicamos um efeito 3D ao texto com este código Java:

``` java
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);

textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);

textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(Color.ORANGE);
textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);

textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(Color.RED);
textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);

textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);

textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);

textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
```

O resultado da operação:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

A aplicação de efeitos 3D a textos ou suas formas e as interações entre os efeitos são baseadas em certas regras. 

Considere uma cena para um texto e a forma que contém esse texto. O efeito 3D contém a representação do objeto 3D e a cena na qual o objeto foi colocado. 

- Quando a cena está definida tanto para a figura quanto para o texto, a cena da figura tem prioridade mais alta — a cena do texto é ignorada. 
- Quando a figura não possui sua própria cena, mas tem representação 3D, a cena do texto é usada. 
- Caso contrário — quando a forma originalmente não tem efeito 3D — a forma é plana e o efeito 3D é aplicado apenas ao texto. 

Essas descrições estão relacionadas aos métodos ThreeDFormat.getLightRig() e ThreeDFormat.getCamera(). 

{{% /alert %}} 

## **Aplicar efeitos de sombra externa ao texto**
Aspose.Slides para Android via Java fornece as classes [**IOuterShadow**](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ioutershadow/) e [**IInnerShadow**](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iinnershadow/) que permitem aplicar efeitos de sombra a um texto contido em um [TextFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/textframe/). Siga estas etapas:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation).  
2. Obtenha a referência de um slide usando seu índice.  
3. Adicione um AutoShape do tipo Rectangle ao slide.  
4. Acesse o TextFrame associado ao AutoShape.  
5. Defina a propriedade FillType do AutoShape como NoFill.  
6. Instancie a classe OuterShadow.  
7. Defina o BlurRadius da sombra.  
8. Defina a Direction da sombra.  
9. Defina a Distance da sombra.  
10. Defina a RectanglelAlign como TopLeft.  
11. Defina a PresetColor da sombra como Black.  
12. Salve a apresentação como um arquivo [PPTX](https://docs.fileformat.com/presentation/pptx/) .  

Este código de exemplo em Java — uma implementação das etapas acima — mostra como aplicar o efeito de sombra externa a um texto:

```java
Presentation pres = new Presentation();
try {
    // Obter referência do slide
    ISlide sld = pres.getSlides().get_Item(0);

    // Adicionar um AutoShape do tipo Retângulo
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Adicionar TextFrame ao Retângulo
    ashp.addTextFrame("Aspose TextBox");

    // Desativar preenchimento da forma caso queiramos obter sombra do texto
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Adicionar sombra externa e definir todos os parâmetros necessários
    ashp.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(PresetColor.Black);

    //Gravar a apresentação no disco
    pres.save("pres_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Aplicar efeitos de sombra interna a formas**
Siga estas etapas:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation).  
2. Obtenha uma referência do slide.  
3. Adicione um AutoShape do tipo Rectangle.  
4. Habilite InnerShadowEffect.  
5. Defina todos os parâmetros necessários.  
6. Defina ColorType como Scheme.  
7. Defina a Scheme Color.  
8. Salve a apresentação como um arquivo [PPTX](https://docs.fileformat.com/presentation/pptx/) .  

Este código de exemplo (com base nas etapas acima) mostra como adicionar um conector entre duas formas em Java:

```java
Presentation pres = new Presentation();
try {
    // Obter referência do slide
    ISlide slide = pres.getSlides().get_Item(0);

    // Adicionar um AutoShape do tipo Retângulo
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Adicionar TextFrame ao Retângulo
    ashp.addTextFrame("Aspose TextBox");
    IPortion port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormat pf = port.getPortionFormat();
    pf.setFontHeight(50);

    // Habilitar InnerShadowEffect
    IEffectFormat ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();

    // Definir todos os parâmetros necessários
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0F);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB((byte)189);

    // Definir ColorType como Scheme
    ef.getInnerShadowEffect().getShadowColor().setColorType(ColorType.Scheme);

    // Definir cor do esquema
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(SchemeColor.Accent1);

    // Salvar apresentação
    pres.save("WordArt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Posso usar efeitos WordArt com diferentes fontes ou scripts (por exemplo, árabe, chinês)?**

Sim, o Aspose.Slides tem suporte a Unicode e funciona com todas as principais fontes e scripts. Efeitos WordArt como sombra, preenchimento e contorno podem ser aplicados independentemente do idioma, embora a disponibilidade da fonte e a renderização possam depender das fontes instaladas no sistema.

**Posso aplicar efeitos WordArt a elementos do slide mestre?**

Sim, você pode aplicar efeitos WordArt a formas em slides mestres, incluindo marcadores de título, rodapés ou textos de fundo. Alterações feitas no layout mestre serão refletidas em todos os slides associados.

**Os efeitos WordArt afetam o tamanho do arquivo da apresentação?**

Um pouco. Efeitos WordArt como sombras, brilhos e preenchimentos em gradiente podem aumentar ligeiramente o tamanho do arquivo devido ao aumento nos metadados de formatação, mas a diferença costuma ser insignificante.

**Posso visualizar o resultado dos efeitos WordArt sem salvar a apresentação?**

Sim, você pode renderizar slides que contêm WordArt em imagens (por exemplo, PNG, JPEG) usando o método `getImage` das interfaces [IShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ishape/) ou [ISlide](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/islide/). Isso permite pré‑visualizar o resultado na memória ou na tela antes de salvar ou exportar a apresentação completa.