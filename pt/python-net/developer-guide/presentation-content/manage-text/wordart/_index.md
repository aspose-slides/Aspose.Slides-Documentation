---
title: Criar e Aplicar Efeitos de WordArt em Python
linktitle: WordArt
type: docs
weight: 110
url: /pt/python-net/wordart/
keywords:
- WordArt
- criar WordArt
- modelo WordArt
- efeito WordArt
- efeito sombra
- efeito de exibição
- efeito brilho
- transformação WordArt
- efeito 3D
- efeito de sombra externa
- efeito de sombra interna
- Python
- Aspose.Slides
description: "Aprenda como criar e personalizar efeitos de WordArt no Aspose.Slides para Python via .NET. Este guia passo a passo ajuda os desenvolvedores a melhorar apresentações com texto elegante e profissional em Python."
---
## **Visão geral**

Os efeitos de WordArt permitem que você adicione texto estilizado e visualmente atraente às suas apresentações PowerPoint. Com Aspose.Slides, os desenvolvedores podem criar, personalizar e gerenciar WordArt programaticamente, assim como no Microsoft PowerPoint—sem precisar ter o Office instalado. Este artigo oferece uma visão geral do trabalho com WordArt, incluindo como aplicar transformações de texto, estilos de preenchimento, contornos, sombras e outras opções de formatação para tornar o conteúdo da sua apresentação mais expressivo e envolvente. WordArt permite tratar o texto como um objeto gráfico. Consiste em efeitos ou modificações especiais aplicadas ao texto para torná‑lo mais atraente ou perceptível.

**WordArt no Microsoft PowerPoint**

Para usar WordArt no Microsoft PowerPoint, você deve selecionar um dos modelos predefinidos de WordArt. Um modelo de WordArt é um conjunto de efeitos que é aplicado a um texto ou à sua forma.

**WordArt no Aspose.Slides**

No Aspose.Slides for Python via .NET 20.10, implementamos suporte para WordArt e aprimoramos o recurso em versões subsequentes do Aspose.Slides for Python via .NET.

Com Aspose.Slides for Python via .NET, você pode criar facilmente seu próprio modelo de WordArt (um efeito ou combinação de efeitos) em Python e aplicá‑lo a textos.

## Criando um Modelo Simples de WordArt e Aplicando‑o a um Texto

**Usando Aspose.Slides** 

Primeiro, criamos um texto simples usando este código Python:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    textFrame = autoShape.text_frame

    portion = textFrame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"

    pres.save("wordart-1.pptx", slides.export.SaveFormat.PPTX)
```
Agora, definimos a altura da fonte do texto para um valor maior para que o efeito fique mais perceptível por meio deste código:

```py 
    fontData = slides.FontData("Arial Black")
    portion.portion_format.latin_font = fontData
    portion.portion_format.font_height = 36
```

**Usando Microsoft PowerPoint**

Vá ao menu de efeitos de WordArt no Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

No menu à direita, você pode escolher um efeito predefinido de WordArt. No menu à esquerda, pode especificar as configurações para um novo WordArt. 

Estes são alguns dos parâmetros ou opções disponíveis:

![todo:image_alt_text](image-20200930114015-3.png)

**Usando Aspose.Slides**

Aqui, aplicamos a cor de padrão SmallGrid ao texto e adicionamos uma borda de texto preta com largura 1 usando este código:

```py 
    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = draw.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = draw.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.SMALL_GRID
                
    portion.portion_format.line_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.line_format.fill_format.solid_fill_color.color = draw.Color.black
```

O texto resultante:

![todo:image_alt_text](image-20200930114108-4.png)

## Aplicando Outros Efeitos de WordArt

**Usando Microsoft PowerPoint**

Pela interface do programa, você pode aplicar esses efeitos a um texto, bloco de texto, forma ou elemento semelhante:

![todo:image_alt_text](image-20200930114129-5.png)

Por exemplo, os efeitos Sombra, Reflexão e Brilho podem ser aplicados a um texto; os efeitos Formato 3D e Rotação 3D podem ser aplicados a um bloco de texto; a propriedade Bordas Suaves pode ser aplicada a um Objeto Forma (ela ainda tem efeito quando nenhuma propriedade Formato 3D está definida). 

### Aplicando Efeitos de Sombra

Aqui, pretendemos definir propriedades relacionadas apenas ao texto. Aplicamos o efeito de sombra a um texto usando este código em Python:

```py 
    portion.portion_format.effect_format.enable_outer_shadow_effect()
    portion.portion_format.effect_format.outer_shadow_effect.shadow_color.color = draw.Color.black
    portion.portion_format.effect_format.outer_shadow_effect.scale_horizontal = 100
    portion.portion_format.effect_format.outer_shadow_effect.scale_vertical = 65
    portion.portion_format.effect_format.outer_shadow_effect.blur_radius = 4.73
    portion.portion_format.effect_format.outer_shadow_effect.direction = 230
    portion.portion_format.effect_format.outer_shadow_effect.distance = 2
    portion.portion_format.effect_format.outer_shadow_effect.skew_horizontal = 30
    portion.portion_format.effect_format.outer_shadow_effect.skew_vertical = 0
    portion.portion_format.effect_format.outer_shadow_effect.shadow_color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.32)
```

A API Aspose.Slides oferece três tipos de sombras: OuterShadow, InnerShadow e PresetShadow. 

Com PresetShadow, você pode aplicar uma sombra a um texto (usando valores predefinidos). 

**Usando Microsoft PowerPoint**

No PowerPoint, você pode usar um tipo de sombra. Aqui está um exemplo:

![todo:image_alt_text](image-20200930114225-6.png)

**Usando Aspose.Slides**

Aspose.Slides realmente permite aplicar dois tipos de sombras ao mesmo tempo: InnerShadow e PresetShadow.

**Observações:**

- Quando OuterShadow e PresetShadow são usados juntos, apenas o efeito OuterShadow é aplicado. 
- Se OuterShadow e InnerShadow forem usados simultaneamente, o efeito resultante ou aplicado depende da versão do PowerPoint. Por exemplo, no PowerPoint 2013, o efeito é dobrado. Mas no PowerPoint 2007, o efeito OuterShadow é aplicado. 

### Aplicando Display a Textos

Adicionamos display ao texto por meio deste exemplo de código em Python:

```py 
    portion.portion_format.effect_format.enable_reflection_effect()
    portion.portion_format.effect_format.reflection_effect.blur_radius = 0.5 
    portion.portion_format.effect_format.reflection_effect.distance = 4.72 
    portion.portion_format.effect_format.reflection_effect.start_pos_alpha = 0 
    portion.portion_format.effect_format.reflection_effect.end_pos_alpha = 60
    portion.portion_format.effect_format.reflection_effect.direction = 90 
    portion.portion_format.effect_format.reflection_effect.scale_horizontal = 100 
    portion.portion_format.effect_format.reflection_effect.scale_vertical = -100
    portion.portion_format.effect_format.reflection_effect.start_reflection_opacity = 60
    portion.portion_format.effect_format.reflection_effect.end_reflection_opacity = 0.9
    portion.portion_format.effect_format.reflection_effect.rectangle_align = slides.RectangleAlignment.BOTTOM_LEFT  
```

### Aplicando Efeito de Brilho a Textos

Aplicamos o efeito de brilho ao texto para que ele brilhe ou se destaque usando este código:

```py 
    portion.portion_format.effect_format.enable_glow_effect()
    portion.portion_format.effect_format.glow_effect.color.r = 255
    portion.portion_format.effect_format.glow_effect.color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.54)
    portion.portion_format.effect_format.glow_effect.radius = 7
```

O resultado da operação:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

Você pode alterar os parâmetros de sombra, display e brilho. As propriedades dos efeitos são definidas separadamente para cada porção do texto. 

{{% /alert %}} 

### Usando Transformações em WordArt

Usamos a propriedade Transform (inata ao bloco inteiro de texto) por meio deste código:
```py 
textFrame.text_frame_format.transform = slides.TextShapeType.ARCH_UP_POUR
```

O resultado:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Tanto o Microsoft PowerPoint quanto o Aspose.Slides for Python via .NET fornecem um número de tipos de transformação predefinidos. 

{{% /alert %}} 

**Usando PowerPoint**

Para acessar os tipos de transformação predefinidos, siga: **Format**->**TextEffect**->**Transform**

**Usando Aspose.Slides**

Para selecionar um tipo de transformação, use o enum TextShapeType. 

### Aplicando efeitos 3D a Textos e Formas

Definimos um efeito 3D a uma forma de texto usando este código de exemplo:

```py 
    autoShape.three_d_format.bevel_bottom.bevel_type = slides.BevelPresetType.CIRCLE
    autoShape.three_d_format.bevel_bottom.height = 10.5
    autoShape.three_d_format.bevel_bottom.width = 10.5

    autoShape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    autoShape.three_d_format.bevel_top.height = 12.5
    autoShape.three_d_format.bevel_top.width = 11

    autoShape.three_d_format.extrusion_color.color = draw.Color.orange
    autoShape.three_d_format.extrusion_height = 6

    autoShape.three_d_format.contour_color.color = draw.Color.dark_red
    autoShape.three_d_format.contour_width = 1.5

    autoShape.three_d_format.depth = 3

    autoShape.three_d_format.material = slides.MaterialPresetType.PLASTIC

    autoShape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    autoShape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    autoShape.three_d_format.light_rig.set_rotation(0, 0, 40)

    autoShape.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
```

O texto resultante e sua forma:

![todo:image_alt_text](image-20200930114816-9.png)

Aplicamos um efeito 3D ao texto com este código Python:

```py 
    textFrame.text_frame_format.three_d_format.bevel_bottom.bevel_type = slides.BevelPresetType.CIRCLE
    textFrame.text_frame_format.three_d_format.bevel_bottom.height = 3.5
    textFrame.text_frame_format.three_d_format.bevel_bottom.width = 3.5

    textFrame.text_frame_format.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    textFrame.text_frame_format.three_d_format.bevel_top.height = 4
    textFrame.text_frame_format.three_d_format.bevel_top.width = 4

    textFrame.text_frame_format.three_d_format.extrusion_color.color = draw.Color.orange
    textFrame.text_frame_format.three_d_format.extrusion_height= 6

    textFrame.text_frame_format.three_d_format.contour_color.color = draw.Color.dark_red
    textFrame.text_frame_format.three_d_format.contour_width = 1.5

    textFrame.text_frame_format.three_d_format.depth= 3

    textFrame.text_frame_format.three_d_format.material = slides.MaterialPresetType.PLASTIC

    textFrame.text_frame_format.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    textFrame.text_frame_format.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    textFrame.text_frame_format.three_d_format.light_rig.set_rotation(0, 0, 40)

    textFrame.text_frame_format.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
```

O resultado da operação:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

A aplicação de efeitos 3D a textos ou suas formas e as interações entre efeitos baseiam‑se em certas regras. 

Considere uma cena para um texto e a forma que contém esse texto. O efeito 3D contém a representação do objeto 3D e a cena na qual o objeto foi colocado. 

- Quando a cena é definida tanto para a figura quanto para o texto, a cena da figura tem prioridade maior—a cena do texto é ignorada. 
- Quando a figura não possui sua própria cena, mas tem representação 3D, a cena do texto é usada. 
- Caso contrário—quando a forma originalmente não tem efeito 3D— a forma é plana e o efeito 3D é aplicado apenas ao texto. 

As descrições estão ligadas às propriedades [ThreeDFormat.LightRig](https://reference.aspose.com/slides/pt/python-net/aspose.slides/threedformat/) e [ThreeDFormat.Camera](https://reference.aspose.com/slides/pt/python-net/aspose.slides/threedformat/). 

{{% /alert %}} 

## **Aplicar Efeitos de Sombra Externa a Textos**
Aspose.Slides for Python via .NET fornece as classes [**IOuterShadow**](https://reference.aspose.com/slides/pt/python-net/aspose.slides.effects/ioutershadow/) e [**IInnerShadow**](https://reference.aspose.com/slides/pt/python-net/aspose.slides.effects/iinnershadow/) que permitem aplicar efeitos de sombra a um texto contido em TextFrame. Siga estas etapas:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/). 
2. Obtenha a referência de um slide usando seu índice. 
3. Adicione um AutoShape do tipo Rectangle ao slide. 
4. Acesse o TextFrame associado ao AutoShape. 
5. Defina o FillType do AutoShape como NoFill. 
6. Instancie a classe OuterShadow 
7. Defina o BlurRadius da sombra. 
8. Defina a Direction da sombra 
9. Defina a Distance da sombra. 
10. Defina o RectanglelAlign para TopLeft. 
11. Defina o PresetColor da sombra como Black. 
12. Salve a apresentação como um arquivo PPTX. 

Este código de exemplo em Python—uma implementação das etapas acima—mostra como aplicar o efeito de sombra externa a um texto:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:

    # Obter referência do slide
    sld = pres.slides[0]

    # Adicionar um AutoShape do tipo Retângulo
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    # Adicionar TextFrame ao Retângulo
    ashp.add_text_frame("Aspose TextBox")

    # Desativar preenchimento da forma caso queiramos obter sombra do texto
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Adicionar sombra externa e definir todos os parâmetros necessários
    ashp.effect_format.enable_outer_shadow_effect()
    shadow = ashp.effect_format.outer_shadow_effect
    shadow.blur_radius = 4.0
    shadow.direction = 45
    shadow.distance = 3
    shadow.rectangle_align = slides.RectangleAlignment.TOP_LEFT
    shadow.shadow_color.preset_color = slides.PresetColor.BLACK

    #Gravar a apresentação no disco
    pres.save("pres_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Aplicar Efeito de Sombra Interna a Formas**
Siga estas etapas:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/). 
2. Obtenha a referência do slide. 
3. Adicione um AutoShape do tipo Rectangle. 
4. Habilite InnerShadowEffect. 
5. Defina todos os parâmetros necessários. 
6. Defina o ColorType como Scheme. 
7. Defina a Scheme Color. 
8. Salve a apresentação como um arquivo [PPTX](https://docs.fileformat.com/presentation/pptx/). 

Este código de exemplo (baseado nas etapas acima) mostra como adicionar um conector entre duas formas em Python:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    # Obter referência de um slide
    slide = presentation.slides[0]

    # Adicionar um AutoShape do tipo Retângulo
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 400, 300)
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Adicionar TextFrame ao Retângulo
    ashp.add_text_frame("Aspose TextBox")
    port = ashp.text_frame.paragraphs[0].portions[0]
    pf = port.portion_format
    pf.font_height = 50

    # Habilitar inner_shadow_effect    
    ef = pf.effect_format
    ef.enable_inner_shadow_effect()

    # Definir todos os parâmetros necessários
    ef.inner_shadow_effect.blur_radius = 8.0
    ef.inner_shadow_effect.direction = 90.0
    ef.inner_shadow_effect.distance = 6.0
    ef.inner_shadow_effect.shadow_color.b = 189

    # Definir ColorType como Scheme
    ef.inner_shadow_effect.shadow_color.color_type = slides.ColorType.SCHEME

    # Definir Scheme Color
    ef.inner_shadow_effect.shadow_color.scheme_color = slides.SchemeColor.ACCENT1

    # Salvar a apresentação
    presentation.save("WordArt_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Perguntas Frequentes**

**Posso usar efeitos de WordArt com fontes ou scripts diferentes (por exemplo, árabe, chinês)?**

Sim, Aspose.Slides oferece suporte a Unicode e funciona com todas as principais fontes e scripts. Efeitos de WordArt como sombra, preenchimento e contorno podem ser aplicados independentemente do idioma, embora a disponibilidade da fonte e a renderização possam depender das fontes do sistema.

**Posso aplicar efeitos de WordArt a elementos do mestre de slides?**

Sim, você pode aplicar efeitos de WordArt a formas nos mestres de slides, incluindo marcadores de título, rodapés ou textos de fundo. Alterações feitas no layout mestre serão refletidas em todos os slides associados.

**Os efeitos de WordArt afetam o tamanho do arquivo da apresentação?**

Um pouco. Efeitos de WordArt como sombras, brilhos e preenchimentos degradê podem aumentar ligeiramente o tamanho do arquivo devido ao metadado de formatação adicional, mas a diferença costuma ser insignificante.

**Posso visualizar o resultado dos efeitos de WordArt sem salvar a apresentação?**

Sim, você pode renderizar slides contendo WordArt em imagens (por exemplo, PNG, JPEG) usando o método `get_image` das classes [Shape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shape/) ou [Slide](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slide/). Isso permite pré‑visualizar o resultado na memória ou na tela antes de salvar ou exportar a apresentação completa.