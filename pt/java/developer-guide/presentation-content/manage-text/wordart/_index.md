---
title: Criar e Aplicar Efeitos WordArt em Java
linktitle: WordArt
type: docs
weight: 110
url: /pt/java/wordart/
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
- Java
- Aspose.Slides
description: "Criar e personalizar efeitos WordArt no Aspose.Slides para Java. Este guia passo a passo ajuda os desenvolvedores a aprimorar apresentações com texto profissional em Java."
---
## **Visão geral**

Os efeitos WordArt permitem que você adicione texto estilizado e visualmente atraente às suas apresentações PowerPoint. Com Aspose.Slides, os desenvolvedores podem criar, personalizar e gerenciar WordArt programaticamente, assim como no Microsoft PowerPoint — sem precisar do Office instalado. Este artigo oferece uma visão geral sobre o trabalho com WordArt, incluindo como aplicar transformações de texto, estilos de preenchimento, contornos, sombras e outras opções de formatação para tornar o conteúdo da sua apresentação mais expressivo e envolvente. WordArt permite tratar o texto como um objeto gráfico. Consiste em efeitos ou modificações especiais aplicadas ao texto para torná‑lo mais atraente ou perceptível.

## **Criando um Modelo Simples de WordArt e Aplicando‑lo a um Texto**

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
Agora, definimos a altura da fonte do texto para um valor maior para que o efeito fique mais perceptível por meio deste código:

``` java 
FontData fontData = new FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```

**Usando Microsoft PowerPoint**

Acesse o menu de efeitos WordArt no Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

No menu à direita, você pode escolher um efeito WordArt predefinido. No menu à esquerda, pode especificar as configurações para um novo WordArt. 

Estes são alguns dos parâmetros ou opções disponíveis:

![todo:image_alt_text](image-20200930114015-3.png)

**Usando Aspose.Slides**

Aqui, aplicamos o padrão de cor [SmallGrid](https://reference.aspose.com/slides/pt/java/com.aspose.slides/PatternStyle#SmallGrid) ao texto e adicionamos uma borda de texto preta com largura 1 usando este código:

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

## **Aplicando Outros Efeitos WordArt**

**Usando Microsoft PowerPoint**

Pela interface do programa, você pode aplicar esses efeitos a um texto, bloco de texto, forma ou elemento semelhante:

![todo:image_alt_text](image-20200930114129-5.png)

Por exemplo, os efeitos Sombra, Reflexão e Brilho podem ser aplicados a um texto; os efeitos Formato 3D e Rotação 3D podem ser aplicados a um bloco de texto; a propriedade Borda Suave pode ser aplicada a um Objeto Forma (ela ainda tem efeito quando nenhuma propriedade Formato 3D está definida). 

### **Aplicando Efeitos de Sombra**

Aqui, pretendemos definir as propriedades relacionadas apenas ao texto. Aplicamos o efeito de sombra ao texto usando este código Java:

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

**Usando Microsoft PowerPoint**

No PowerPoint, você pode usar um tipo de sombra. Veja um exemplo:

![todo:image_alt_text](image-20200930114225-6.png)

**Usando Aspose.Slides**

Aspose.Slides realmente permite aplicar dois tipos de sombras simultaneamente: InnerShadow e PresetShadow.

**Observações:**

- Quando OuterShadow e PresetShadow são usados juntos, somente o efeito OuterShadow é aplicado. 
- Se OuterShadow e InnerShadow forem usados ao mesmo tempo, o efeito resultante ou aplicado depende da versão do PowerPoint. Por exemplo, no PowerPoint 2013, o efeito é duplicado. Mas no PowerPoint 2007, o efeito OuterShadow é aplicado. 

### **Aplicando Exibição a Textos**

Adicionamos exibição ao texto por meio deste exemplo de código Java:

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

### **Aplicando Efeito de Brilho a Textos**

Aplicamos o efeito de brilho ao texto para que ele brilhe ou se destaque usando este código:

``` java
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```

O resultado da operação:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 
Você pode alterar os parâmetros de sombra, exibição e brilho. As propriedades dos efeitos são definidas separadamente para cada parte do texto. 
{{% /alert %}} 

### **Usando Transformações em WordArt**

Usamos a propriedade Transform (incorporada em todo o bloco de texto) por meio deste código:
``` java 
textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
```

O resultado:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 
Tanto o Microsoft PowerPoint quanto o Aspose.Slides para Java fornecem um número determinado de tipos de transformação predefinidos. 
{{% /alert %}} 

**Usando PowerPoint**

Para acessar os tipos de transformação predefinidos, navegue por: **Format** -> **TextEffect** -> **Transform**

**Usando Aspose.Slides**

Para selecionar um tipo de transformação, use o enum TextShapeType. 

### **Aplicando Efeitos 3D a Textos e Formas**

Definimos um efeito 3D para uma forma de texto usando este código de exemplo:

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

O texto resultante e sua forma:

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

Considere uma cena para um texto e a forma que contém esse texto. O efeito 3D contém a representação do objeto 3D e a cena onde o objeto foi colocado. 

- Quando a cena está definida tanto para a figura quanto para o texto, a cena da figura tem prioridade mais alta — a cena do texto é ignorada. 
- Quando a figura não possui sua própria cena, mas tem representação 3D, a cena do texto é usada. 
- Caso contrário — quando a forma originalmente não tem efeito 3D — a forma permanece plana e o efeito 3D é aplicado apenas ao texto. 

Essas descrições estão relacionadas aos métodos ThreeDFormat.getLightRig() e ThreeDFormat.getCamera(). 
{{% /alert %}} 

## **Aplicar Efeitos de Sombra Externa a Textos**
Aspose.Slides para Java fornece as classes [**IOuterShadow**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ioutershadow/) e [**IInnerShadow**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iinnershadow/) que permitem aplicar efeitos de sombra a um texto contido em [TextFrame](https://reference.aspose.com/slides/pt/java/com.aspose.slides/textframe/). Siga estas etapas:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation). 
2. Obtenha a referência de um slide usando seu índice. 
3. Adicione um AutoShape do tipo Rectangle ao slide. 
4. Acesse o TextFrame associado ao AutoShape. 
5. Defina o FillType do AutoShape como NoFill. 
6. Instancie a classe OuterShadow 
7. Defina o BlurRadius da sombra. 
8. Defina a Direction da sombra 
9. Defina o Distance da sombra. 
10. Defina o RectanglelAlign como TopLeft. 
11. Defina o PresetColor da sombra como Black. 
12. Grave a apresentação como um arquivo [PPTX](https://docs.fileformat.com/presentation/pptx/). 

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

    // Salvar a apresentação no disco
    pres.save("pres_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Aplicar Efeito de Sombra Interna a Formas**
Siga estas etapas:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation). 
2. Obtenha a referência do slide. 
3. Adicione um AutoShape do tipo Rectangle. 
4. Habilite InnerShadowEffect. 
5. Defina todos os parâmetros necessários. 
6. Defina o ColorType como Scheme. 
7. Defina a Scheme Color. 
8. Grave a apresentação como um arquivo [PPTX](https://docs.fileformat.com/presentation/pptx/). 

Este código de exemplo (baseado nas etapas acima) mostra como adicionar um conector entre duas formas em Java:

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

**Posso usar efeitos WordArt com fontes ou scripts diferentes (por exemplo, árabe, chinês)?**

Sim, Aspose.Slides oferece suporte a Unicode e funciona com todas as fontes e scripts principais. Efeitos WordArt como sombra, preenchimento e contorno podem ser aplicados independentemente do idioma, embora a disponibilidade de fontes e a renderização possam depender das fontes do sistema.

**Posso aplicar efeitos WordArt a elementos do slide mestre?**

Sim, você pode aplicar efeitos WordArt a formas nos slides mestres, incluindo marcadores de título, rodapés ou texto de fundo. Alterações feitas no layout mestre serão refletidas em todos os slides associados.

**Os efeitos WordArt afetam o tamanho do arquivo da apresentação?**

Um pouco. Efeitos WordArt como sombras, brilhos e preenchimentos em gradiente podem aumentar levemente o tamanho do arquivo devido à adição de metadados de formatação, mas a diferença geralmente é insignificante.

**Posso pré‑visualizar o resultado dos efeitos WordArt sem salvar a apresentação?**

Sim, você pode renderizar slides contendo WordArt em imagens (por exemplo, PNG, JPEG) usando o método `getImage` das interfaces [IShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ishape/) ou [ISlide](https://reference.aspose.com/slides/pt/java/com.aspose.slides/islide/). Isso permite que você pré‑visualize o resultado na memória ou na tela antes de salvar ou exportar a apresentação completa.