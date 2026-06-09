---
title: Criar e aplicar efeitos de WordArt em JavaScript
linktitle: WordArt
type: docs
weight: 110
url: /pt/nodejs-java/wordart/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Crie e personalize efeitos de WordArt no Aspose.Slides para Node.js. Este guia passo a passo ajuda desenvolvedores a aprimorar apresentações com texto profissional."
---
## **Visão geral**

Os efeitos de WordArt permitem que você adicione texto visualmente atraente e estilizado às suas apresentações do PowerPoint. Com o Aspose.Slides, os desenvolvedores podem criar, personalizar e gerenciar WordArt programaticamente, assim como no Microsoft PowerPoint - sem precisar do Office instalado. Este artigo fornece uma visão geral de como trabalhar com WordArt, incluindo como aplicar transformações de texto, estilos de preenchimento, contornos, sombras e outras opções de formatação para tornar o conteúdo da sua apresentação mais expressivo e envolvente. O WordArt permite tratar o texto como um objeto gráfico. Ele consiste em efeitos ou modificações especiais aplicadas ao texto para torná‑lo mais atraente ou perceptível.

## **Criando um modelo simples de WordArt e aplicando‑o a um texto**

**Usando Aspose.Slides** 

Primeiro, criamos um texto simples usando este código JavaScript:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    var textFrame = autoShape.getTextFrame();
    var portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
Agora, definimos a altura da fonte do texto para um valor maior para que o efeito fique mais perceptível através deste código:

```javascript
var fontData = new aspose.slides.FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```

**Usando o Microsoft PowerPoint**

Acesse o menu de efeitos de WordArt no Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

No menu à direita, você pode escolher um efeito de WordArt predefinido. No menu à esquerda, pode especificar as configurações para um novo WordArt. 

Estes são alguns dos parâmetros ou opções disponíveis:

![todo:image_alt_text](image-20200930114015-3.png)

**Usando Aspose.Slides**

Aqui, aplicamos a cor de padrão [SmallGrid](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/PatternStyle#SmallGrid) ao texto e adicionamos uma borda de texto preta de largura 1 usando este código:

```javascript
portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.SmallGrid));
portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
```

O texto resultante:

![todo:image_alt_text](image-20200930114108-4.png)

## **Aplicando outros efeitos de WordArt**

**Usando Microsoft PowerPoint**

Na caixa de ferramentas do programa, você pode aplicar esses efeitos a um texto, bloco de texto, forma ou elemento similar:

![todo:image_alt_text](image-20200930114129-5.png)

Por exemplo, os efeitos Sombra, Reflexão e Brilho podem ser aplicados a um texto; os efeitos Formato 3D e Rotação 3D podem ser aplicados a um bloco de texto; a propriedade Borda Suave pode ser aplicada a um objeto Shape (ele ainda tem efeito quando nenhuma propriedade Formato 3D está definida). 

### **Aplicando efeitos de sombra**

Aqui, pretendemos definir as propriedades relacionadas apenas a um texto. Aplicamos o efeito de sombra a um texto usando este código em JavaScript:

```javascript
portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(65);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4.73);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(2);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(30);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(aspose.slides.ColorTransformOperation.SetAlpha, 0.32);
```

A API Aspose.Slides suporta três tipos de sombras: OuterShadow, InnerShadow e PresetShadow. 

Com PresetShadow, você pode aplicar uma sombra a um texto (usando valores predefinidos). 

**Usando Microsoft PowerPoint**

No PowerPoint, você pode usar um tipo de sombra. Aqui está um exemplo:

![todo:image_alt_text](image-20200930114225-6.png)

**Usando Aspose.Slides**

O Aspose.Slides realmente permite aplicar dois tipos de sombras simultaneamente: InnerShadow e PresetShadow.

**Observações:**

- Quando OuterShadow e PresetShadow são usados juntos, apenas o efeito OuterShadow é aplicado. 
- Se OuterShadow e InnerShadow forem usados simultaneamente, o efeito resultante ou aplicado depende da versão do PowerPoint. Por exemplo, no PowerPoint 2013, o efeito é dobrado. Mas no PowerPoint 2007, o efeito OuterShadow é aplicado. 

### **Aplicando exibição a textos**

Adicionamos exibição ao texto através deste exemplo de código em JavaScript:

```javascript
portion.getPortionFormat().getEffectFormat().enableReflectionEffect();
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(0.0);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(60.0);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(60.0);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(0.9);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(aspose.slides.RectangleAlignment.BottomLeft);
```

### **Aplicando efeito de brilho a textos**

Aplicamos o efeito de brilho ao texto para fazê‑lo brilhar ou se destacar usando este código:

```javascript
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR(255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(aspose.slides.ColorTransformOperation.SetAlpha, 0.54);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```

O resultado da operação:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

Você pode alterar os parâmetros de sombra, exibição e brilho. As propriedades dos efeitos são definidas separadamente para cada parte do texto. 

{{% /alert %}} 

### **Usando transformações em WordArt**

Usamos a propriedade Transform (inata em todo o bloco de texto) através deste código:
```javascript
textFrame.getTextFrameFormat().setTransform(java.newByte(aspose.slides.TextShapeType.ArchUpPour));
```

O resultado:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Tanto o Microsoft PowerPoint quanto o Aspose.Slides para Node.js via Java fornecem um certo número de tipos de transformação predefinidos.

{{% /alert %}} 

**Usando PowerPoint**

Para acessar tipos de transformação predefinidos, vá em: **Format** -> **TextEffect** -> **Transform**

**Usando Aspose.Slides**

Para selecionar um tipo de transformação, use o enum TextShapeType. 

### **Aplicando efeitos 3D a textos e formas**

Definimos um efeito 3D a uma forma de texto usando este código de exemplo:

```javascript
autoShape.getThreeDFormat().getBevelBottom().setBevelType(aspose.slides.BevelPresetType.Circle);
autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);
autoShape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
autoShape.getThreeDFormat().getBevelTop().setWidth(11);
autoShape.getThreeDFormat().getExtrusionColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
autoShape.getThreeDFormat().setExtrusionHeight(6);
autoShape.getThreeDFormat().getContourColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
autoShape.getThreeDFormat().setContourWidth(1.5);
autoShape.getThreeDFormat().setDepth(3);
autoShape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);
autoShape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);
autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);
```

O texto resultante e sua forma:

![todo:image_alt_text](image-20200930114816-9.png)

Aplicamos um efeito 3D ao texto com este código JavaScript:

```javascript
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(aspose.slides.BevelPresetType.Circle);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);
textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);
textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);
textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);
textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);
textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);
```

O resultado da operação:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

A aplicação de efeitos 3D a textos ou suas formas e as interações entre os efeitos são baseadas em certas regras. 

Considere uma cena para um texto e a forma que contém esse texto. O efeito 3D contém a representação do objeto 3D e a cena na qual o objeto foi colocado. 

- Quando a cena está definida tanto para a figura quanto para o texto, a cena da figura tem prioridade maior — a cena do texto é ignorada. 
- Quando a figura não tem sua própria cena, mas possui representação 3D, a cena do texto é usada. 
- Caso contrário — quando a forma originalmente não tem efeito 3D — a forma é plana e o efeito 3D é aplicado apenas ao texto. 

Essas descrições estão relacionadas aos métodos ThreeDFormat.getLightRig() e ThreeDFormat.getCamera(). 

{{% /alert %}} 

## **Aplicar efeitos de sombra externa a textos**

O Aspose.Slides para Node.js via Java fornece as classes [**OuterShadow**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/outershadow/) e [**InnerShadow**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/innershadow/) que permitem aplicar efeitos de sombra a um texto contido em [TextFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/). Siga estas etapas:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation).  
2. Obtenha a referência de um slide usando seu índice.  
3. Adicione um AutoShape do tipo Retângulo ao slide.  
4. Acesse o TextFrame associado ao AutoShape.  
5. Defina o FillType do AutoShape como NoFill.  
6. Instancie a classe OuterShadow  
7. Defina o BlurRadius da sombra.  
8. Defina a Direction da sombra  
9. Defina a Distance da sombra.  
10. Defina o RectanglelAlign como TopLeft.  
11. Defina o PresetColor da sombra como Black.  
12. Grave a apresentação como um arquivo [PPTX](https://docs.fileformat.com/presentation/pptx/) file.

Este código de exemplo em Java — uma implementação das etapas acima — mostra como aplicar o efeito de sombra externa a um texto:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Obter referência do slide
    var sld = pres.getSlides().get_Item(0);
    // Adicionar um AutoShape do tipo Retângulo
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 150, 50);
    // Adicionar TextFrame ao Retângulo
    ashp.addTextFrame("Aspose TextBox");
    // Desativar preenchimento da forma caso queiramos obter sombra do texto
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Adicionar sombra externa e definir todos os parâmetros necessários
    ashp.getEffectFormat().enableOuterShadowEffect();
    var shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(aspose.slides.RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(aspose.slides.PresetColor.Black);
    // Gravar a apresentação no disco
    pres.save("pres_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Aplicar efeito de sombra interna a formas**

Siga estas etapas:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation).  
2. Obtenha uma referência do slide.  
3. Adicione um AutoShape do tipo Retângulo.  
4. Habilite InnerShadowEffect.  
5. Defina todos os parâmetros necessários.  
6. Defina o ColorType como Scheme.  
7. Defina a Scheme Color.  
8. Grave a apresentação como um arquivo [PPTX](https://docs.fileformat.com/presentation/pptx/).  

Este código de exemplo (baseado nas etapas acima) mostra como adicionar um conector entre duas formas em JavaScript:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Obter referência do slide
    var slide = pres.getSlides().get_Item(0);
    // Adicionar um AutoShape do tipo Retângulo
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Adicionar TextFrame ao Retângulo
    ashp.addTextFrame("Aspose TextBox");
    var port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    var pf = port.getPortionFormat();
    pf.setFontHeight(50);
    // Habilitar InnerShadowEffect
    var ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();
    // Definir todos os parâmetros necessários
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB(189);
    // Definir ColorType como Scheme
    ef.getInnerShadowEffect().getShadowColor().setColorType(aspose.slides.ColorType.Scheme);
    // Definir cor do Scheme
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(aspose.slides.SchemeColor.Accent1);
    // Salvar apresentação
    pres.save("WordArt_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Posso usar efeitos de WordArt com diferentes fontes ou scripts (por exemplo, Árabe, Chinês)?**

Sim, o Aspose.Slides suporta Unicode e funciona com todas as principais fontes e scripts. Os efeitos de WordArt, como sombra, preenchimento e contorno, podem ser aplicados independentemente do idioma, embora a disponibilidade da fonte e a renderização possam depender das fontes do sistema.

**Posso aplicar efeitos de WordArt aos elementos do slide mestre?**

Sim, você pode aplicar efeitos de WordArt a formas nos slides mestre, incluindo marcadores de título, rodapés ou texto de fundo. Alterações feitas no layout mestre serão refletidas em todos os slides associados.

**Os efeitos de WordArt afetam o tamanho do arquivo da apresentação?**

Um pouco. Efeitos de WordArt como sombras, brilhos e preenchimentos em gradiente podem aumentar ligeiramente o tamanho do arquivo devido a metadados de formatação adicionais, mas a diferença costuma ser insignificante.

**Posso visualizar o resultado dos efeitos de WordArt sem salvar a apresentação?**

Sim, você pode renderizar slides que contêm WordArt em imagens (por exemplo, PNG, JPEG) usando o método `getImage` das classes [Shape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/) ou [Slide](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slide/). Isso permite visualizar o resultado em memória ou na tela antes de salvar ou exportar a apresentação completa.