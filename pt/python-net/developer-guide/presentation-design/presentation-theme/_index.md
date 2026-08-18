---
title: Gerenciar Temas de Apresentação PowerPoint em Python
linktitle: Tema de Apresentação
type: docs
weight: 10
url: /pt/python-net/presentation-theme/
keywords:
- tema PowerPoint
- tema de apresentação
- tema de slide
- definir tema
- alterar tema
- gerenciar tema
- cor do tema
- paleta adicional
- fonte do tema
- estilo do tema
- efeito do tema
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Gerencie temas de apresentação no Aspose.Slides para Python via .NET para criar, personalizar e converter arquivos PowerPoint com identidade visual consistente."
---
## **Introdução**

Um tema de apresentação define um conjunto coordenado de cores, fontes, estilos de fundo, preenchimentos, linhas e efeitos. Objetos sensíveis ao tema referem‑se a essas definições compartilhadas em vez de armazenar cada propriedade visual como um valor fixo, de modo que uma mudança de tema pode atualizar muitos objetos de uma vez.

No Aspose.Slides, o tema ao nível da apresentação está disponível através da propriedade [Presentation.master_theme](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/master_theme/). Uma apresentação também pode conter substituições de tema em níveis mais baixos. Um mestre pode substituir o tema da apresentação por meio de [MasterThemeManager.override_theme](https://reference.aspose.com/slides/pt/python-net/aspose.slides.theme/masterthememanager/override_theme/), um layout pode substituir seu tema herdado por meio de [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/pt/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/), e um slide individual pode fazer o mesmo. Na prática, o tema efetivo para um slide é resolvido através desta cadeia de herança: tema da apresentação, substituição do mestre, substituição do layout e substituição do slide.

![Componentes do tema: cores, fontes, estilos de fundo e efeitos](theme-constituents.png)

As seções abaixo mostram os fluxos de trabalho de tema mais comuns: inspecionar um tema, alterar cores e fontes, copiar ou aplicar um tema, atualizar estilos de fundo e efeitos, e ler valores efetivos após a herança e substituições serem resolvidas.

## **Inspecionar um Tema**

O objeto [MasterTheme](https://reference.aspose.com/slides/pt/python-net/aspose.slides.theme/mastertheme/) expõe as propriedades [color_scheme](https://reference.aspose.com/slides/pt/python-net/aspose.slides.theme/mastertheme/color_scheme/), [font_scheme](https://reference.aspose.com/slides/pt/python-net/aspose.slides.theme/mastertheme/font_scheme/) e [format_scheme](https://reference.aspose.com/slides/pt/python-net/aspose.slides.theme/mastertheme/format_scheme/) do tema. Inspecionar essas coleções antes de alterá‑las é especialmente útil quando uma apresentação vem de uma fonte externa, pois o número e o conteúdo das entradas de estilo podem variar.

O exemplo a seguir lê as principais propriedades do tema e informa quantos estilos de fundo, preenchimento, linha e efeito estão armazenados no tema:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    theme = presentation.master_theme
    print(f"Theme name: {theme.name}")
    print(f"Accent 1: {theme.color_scheme.accent1.color}")
    print(f"Major Latin font: {theme.font_scheme.major.latin_font.font_name}")
    print(f"Minor Latin font: {theme.font_scheme.minor.latin_font.font_name}")
    print(f"Background fill styles: {len(theme.format_scheme.background_fill_styles)}")
    print(f"Fill styles: {len(theme.format_scheme.fill_styles)}")
    print(f"Line styles: {len(theme.format_scheme.line_styles)}")
    print(f"Effect styles: {len(theme.format_scheme.effect_styles)}")
```

Se um arquivo usar vários mestres, não presuma que cada slide tenha o mesmo tema efetivo. Inspecione o mestre associado ao slide e use o fluxo de trabalho de tema efetivo mostrado mais adiante neste artigo quando substituições de layout ou slide puderem estar presentes.

## **Alterar Cores do Tema**

Preenchimentos, linhas e texto sensíveis ao tema podem referir‑se a uma cor lógica da enumeração [SchemeColor](https://reference.aspose.com/slides/pt/python-net/aspose.slides/schemecolor/). Quando você altera a entrada correspondente no [ColorScheme](https://reference.aspose.com/slides/pt/python-net/aspose.slides.theme/colorscheme/) do tema, todos os objetos que ainda referenciam essa cor do tema são resolvidos com o novo valor. Objetos que utilizam uma cor RGB direta não são alterados por uma atualização de cor do tema.

O exemplo completo a seguir cria uma forma que usa `ACCENT4`, altera a cor `accent4` do tema para vermelho, salva a apresentação, reabre‑a e imprime a cor de preenchimento efetiva:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    presentation.master_theme.color_scheme.accent4.color = draw.Color.red
    presentation.save("theme-color.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("theme-color.pptx") as saved_presentation:
    saved_slide = saved_presentation.slides[0]
    saved_shape = saved_slide.shapes[0]
    effective_fill = saved_shape.fill_format.get_effective()
    print(f"Effective fill color: {effective_fill.solid_fill_color}")
```

Como o retângulo permanece vinculado a `ACCENT4`, sua cor visível torna‑se vermelha após a mudança do tema. Se você substituir a cor do esquema por uma cor direta na forma, alterações posteriores em `accent4` não afetarão mais esse preenchimento.

### **Usar Cores da Paleta Adicional**

O PowerPoint deriva variantes mais claras e mais escuras de uma cor do tema aplicando transformações de cor. O Aspose.Slides expõe essas transformações por meio da enumeração [ColorTransformOperation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/colortransformoperation/).

![Cores principais do tema e cores mais claras e mais escuras geradas a partir da paleta adicional](additional-palette-colors.png)

**1** - Cores principais do tema.  
**2** - Variantes mais claras e mais escuras produzidas a partir das cores principais do tema.

O exemplo a seguir cria seis retângulos baseados em `ACCENT4`, aplica transformações de luminância a cinco deles e salva o resultado:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 50, 50)
    shape1.fill_format.fill_type = slides.FillType.SOLID
    shape1.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 50, 50)
    shape2.fill_format.fill_type = slides.FillType.SOLID
    shape2.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.2)
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.8)
    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 50, 50)
    shape3.fill_format.fill_type = slides.FillType.SOLID
    shape3.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.4)
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.6)
    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 50, 50)
    shape4.fill_format.fill_type = slides.FillType.SOLID
    shape4.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.6)
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.4)
    shape5 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 250, 50, 50)
    shape5.fill_format.fill_type = slides.FillType.SOLID
    shape5.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape5.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.75)
    shape6 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 50, 50)
    shape6.fill_format.fill_type = slides.FillType.SOLID
    shape6.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape6.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.5)
    presentation.save("theme-color-palette.pptx", slides.export.SaveFormat.PPTX)
```

Essas variantes permanecem baseadas na cor do tema. Se `accent4` mudar mais tarde, as cores transformadas são recalculadas a partir do novo valor de `accent4`.

### **Mapear Valores `SchemeColor` para Slots `ColorScheme`**

A enumeração [SchemeColor](https://reference.aspose.com/slides/pt/python-net/aspose.slides/schemecolor/) usa `TEXT1`, `BACKGROUND1`, `TEXT2` e `BACKGROUND2`, enquanto [ColorScheme](https://reference.aspose.com/slides/pt/python-net/aspose.slides.theme/colorscheme/) expõe os mesmos slots do tema como `dark1`, `light1`, `dark2` e `light2`. O mapeamento é fixo:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

Esses são nomes alternativos para os mesmos slots do tema; não são valores convertidos dinamicamente de uma forma para outra.

## **Alterar Fontes do Tema**

Um esquema de fontes do tema contém um conjunto de fontes principal para títulos e um conjunto de fontes secundário para o corpo do texto. As propriedades [FontScheme.major](https://reference.aspose.com/slides/pt/python-net/aspose.slides.theme/fontscheme/major/) e [FontScheme.minor](https://reference.aspose.com/slides/pt/python-net/aspose.slides.theme/fontscheme/minor/) expõem esses conjuntos.

Identificadores de fontes de tema compatíveis com PowerPoint podem ser usados na formatação de texto:

* `+mn-lt` – Fonte do Corpo Latin (Fonte Secundária Latin)
* `+mj-lt` – Fonte do Título Latin (Fonte Principal Latin)
* `+mn-ea` – Fonte do Corpo East Asian (Fonte Secundária East Asian)
* `+mj-ea` – Fonte do Título East Asian (Fonte Principal East Asian)

O exemplo a seguir cria um título que usa a fonte Latin principal do tema e uma linha de corpo que usa a fonte Latin secundária do tema. Em seguida, altera as fontes do tema e salva o resultado:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    heading = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 500, 60)
    heading.text_frame.text = "Theme heading"
    heading.text_frame.paragraphs[0].portions[0].portion_format.latin_font = slides.FontData("+mj-lt")
    body = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 120, 500, 60)
    body.text_frame.text = "Theme body text"
    body.text_frame.paragraphs[0].portions[0].portion_format.latin_font = slides.FontData("+mn-lt")
    presentation.master_theme.font_scheme.major.latin_font = slides.FontData("Aptos Display")
    presentation.master_theme.font_scheme.minor.latin_font = slides.FontData("Arial")
    presentation.save("theme-fonts.pptx", slides.export.SaveFormat.PPTX)
```

O título segue a fonte principal e o texto do corpo segue a fonte secundária. Texto que possui um nome de fonte explícito em vez de um identificador de tema não mudará automaticamente quando o esquema de fontes do tema for alterado.

{{% alert color="info" title="Dica" %}}

Para mais informações sobre fontes em apresentações, veja [PowerPoint Fonts](/slides/pt/python-net/powerpoint-fonts/).

{{% /alert %}}

## **Copiar ou Aplicar um Tema**

Existem dois fluxos de trabalho comuns, e eles resolvem problemas diferentes.

### **Preservar um Tema de Origem ao Mover Slides**

Se você quiser mover um slide para outra apresentação e preservar seu design original, clone o mestre de origem na apresentação de destino com [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/pt/python-net/aspose.slides/masterslidecollection/add_clone/), então clone o slide com [SlideCollection.add_clone](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slidecollection/add_clone/) e o mestre clonado. Isso transporta o mestre, seus layouts e o tema associado juntos.

```python
import aspose.slides as slides

with slides.Presentation("source-theme.pptx") as source:
    with slides.Presentation("target.pptx") as target:
        source_slide = source.slides[0]
        source_master = source_slide.layout_slide.master_slide
        cloned_master = target.masters.add_clone(source_master)
        target.slides.add_clone(source_slide, cloned_master, True)
        target.save("theme-preserved.pptx", slides.export.SaveFormat.PPTX)
```

Este é o fluxo de trabalho preferido quando o slide de origem deve permanecer visualmente idêntico no destino. Simplesmente clonar conteúdo em um mestre de destino não relacionado pode alterar cores, fontes, fundos e efeitos controlados pelo tema.

### **Aplicar Valores de Tema a um Slide Existente**

Se o slide de destino deve permanecer no seu mestre e layout atuais, inicialize uma substituição ao nível do slide a partir do tema de origem. Os métodos [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/pt/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/), [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/pt/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/) e [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/pt/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) copiam os três principais componentes do tema para a substituição.

```python
import aspose.slides as slides

with slides.Presentation("source-theme.pptx") as source:
    with slides.Presentation("target.pptx") as target:
        target_slide = target.slides[0]
        override_theme = target_slide.theme_manager.override_theme
        override_theme.init_color_scheme_from(source.master_theme.color_scheme)
        override_theme.init_font_scheme_from(source.master_theme.font_scheme)
        override_theme.init_format_scheme_from(source.master_theme.format_scheme)
        target.save("theme-applied-to-slide.pptx", slides.export.SaveFormat.PPTX)
```

Isso altera o tema usado por esse slide sem mudar o tema herdado por outros slides. Para remover a substituição local e retornar aos valores herdados, chame [OverrideTheme.clear](https://reference.aspose.com/slides/pt/python-net/aspose.slides.theme/overridetheme/clear/).

### **Aplicar uma Substituição de Tema a um Layout**

Uma substituição ao nível do layout se aplica aos slides que usam esse layout, salvo se um slide específico possuir sua própria substituição. Os mesmos métodos de inicialização podem ser usados através do [LayoutSlideThemeManager](https://reference.aspose.com/slides/pt/python-net/aspose.slides.theme/layoutslidethememanager/) do layout:

```python
import aspose.slides as slides

with slides.Presentation("source-theme.pptx") as source:
    with slides.Presentation("target.pptx") as target:
        target_slide = target.slides[0]
        override_theme = target_slide.layout_slide.theme_manager.override_theme
        override_theme.init_color_scheme_from(source.master_theme.color_scheme)
        override_theme.init_font_scheme_from(source.master_theme.font_scheme)
        override_theme.init_format_scheme_from(source.master_theme.format_scheme)
        target.save("theme-applied-to-layout.pptx", slides.export.SaveFormat.PPTX)
```

Use um tema ao nível de mestre ou apresentação quando muitos layouts e slides devem compartilhar o mesmo design base, uma substituição de layout quando uma família de layouts necessita de estilização diferente, e uma substituição de slide apenas para exceções reais. Substituições excessivas ao nível de slide tornam mudanças globais de tema posteriores mais difíceis de prever.

## **Atualizar Estilos de Fundo do Tema**

Os preenchimentos de fundo do tema são armazenados em [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/pt/python-net/aspose.slides.theme/formatscheme/background_fill_styles/). O PowerPoint pode apresentar mais opções de fundo em sua UI do que o número de definições de preenchimento fisicamente armazenadas nesta coleção, pois a UI pode combinar preenchimentos de tema com cores de tema e outras referências de estilo.

![Galeria de estilos de fundo do PowerPoint para um tema de apresentação](presentation-design_8.png)

Antes de usar um estilo de fundo, inspecione a coleção armazenada e o [Background.style_index](https://reference.aspose.com/slides/pt/python-net/aspose.slides/background/style_index/) atual. `style_index` usa `0` para nenhum preenchimento temático; valores positivos são referências a estilos de fundo temáticos. Isso difere da indexação direta de uma coleção Python, onde `[0]` significa o primeiro item armazenado. Não presuma que toda apresentação contenha o mesmo número de estilos de preenchimento de fundo.

O exemplo a seguir informa a quantidade de preenchimentos de fundo disponíveis, atribui uma referência de fundo temático ao primeiro mestre e salva a apresentação:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    background_styles = presentation.master_theme.format_scheme.background_fill_styles
    print(f"Background fill styles: {len(background_styles)}")
    if len(background_styles) == 0:
        raise RuntimeError("The presentation theme does not contain background fill styles.")
    master_slide = presentation.masters[0]
    master_slide.background.type = slides.BackgroundType.THEMED
    master_slide.background.style_index = 1
    presentation.save("theme-background.pptx", slides.export.SaveFormat.PPTX)
```

O resultado visível depende da entrada de tema referenciada pelo mestre e de quaisquer substituições de fundo no layout ou no nível do slide. Se um slide usar seu próprio fundo, alterar apenas o fundo do mestre pode não mudar esse slide. Use [Background.get_effective](https://reference.aspose.com/slides/pt/python-net/aspose.slides/background/get_effective/) quando precisar conhecer o fundo final após a aplicação da herança.

{{% alert color="warning" title="Aviso" %}}

Não trate `style_index` como um índice de coleção baseado em zero. Também evite codificar um número de estilo de um arquivo e presumir que ele terá a mesma aparência em outro arquivo; definições de estilo de tema são específicas da apresentação.

{{% /alert %}}

{{% alert color="info" title="Dica" %}}

Para formatação direta de fundo e herança de fundo, veja [Presentation Background](/slides/pt/python-net/presentation-background/).

{{% /alert %}}

## **Atualizar Efeitos do Tema**

Um esquema de formato de tema contém coleções separadas [FormatScheme.fill_styles](https://reference.aspose.com/slides/pt/python-net/aspose.slides.theme/formatscheme/fill_styles/), [FormatScheme.line_styles](https://reference.aspose.com/slides/pt/python-net/aspose.slides.theme/formatscheme/line_styles/) e [FormatScheme.effect_styles](https://reference.aspose.com/slides/pt/python-net/aspose.slides.theme/formatscheme/effect_styles/). Temas típicos do Office costumam conter três entradas principais de estilo que correspondem visualmente a formatações sutil, moderada e intensa, mas o código deve inspecionar cada coleção em vez de presumir uma contagem fixa.

![Efeitos de tema sutis, moderados e intensos aplicados à mesma forma](presentation-design_10.png)

Ao acessar essas coleções em Python, o índice da coleção é baseado em zero: `[0]` é o primeiro estilo armazenado e `[2]` é o terceiro. Os índices de referência de estilo de uma forma são um conceito separado, exposto por [IShapeStyle](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ishapestyle/). Modificar um estilo de tema afeta as formas que referenciam esse estilo; formas com formatação direta podem permanecer inalteradas.

O exemplo a seguir verifica se as entradas de estilo necessárias existem, altera o primeiro estilo de linha, altera o terceiro estilo de preenchimento, habilita uma sombra externa no terceiro estilo de efeito e salva o resultado:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("Subtle_Moderate_Intense.pptx") as presentation:
    format_scheme = presentation.master_theme.format_scheme
    if len(format_scheme.line_styles) < 1 or len(format_scheme.fill_styles) < 3 or len(format_scheme.effect_styles) < 3:
        raise RuntimeError("The theme does not contain the style entries required by this example.")
    format_scheme.line_styles[0].fill_format.fill_type = slides.FillType.SOLID
    format_scheme.line_styles[0].fill_format.solid_fill_color.color = draw.Color.red
    format_scheme.fill_styles[2].fill_type = slides.FillType.SOLID
    format_scheme.fill_styles[2].solid_fill_color.color = draw.Color.forest_green
    format_scheme.effect_styles[2].effect_format.enable_outer_shadow_effect()
    format_scheme.effect_styles[2].effect_format.outer_shadow_effect.distance = 10
    presentation.save("theme-effects.pptx", slides.export.SaveFormat.PPTX)
```

Para formas que referenciam esses slots, o primeiro estilo de linha do tema torna‑se vermelho, o terceiro estilo de preenchimento do tema torna‑se verde floresta sólido, e o terceiro estilo de efeito ganha uma sombra externa com distância de 10 pontos. O resultado visual exato ainda depende de quais slots de estilo cada forma referencia e se a formatação direta sobrescreve o tema.

![Estilos de efeito do tema após a alteração de linha, preenchimento e sombra](presentation-design_11.png)

## **Ler Valores Efetivos do Tema**

Objetos de tema bruto informam o que está definido em um determinado nível. Valores efetivos informam o que um slide ou forma realmente usa após a herança e substituições locais serem resolvidas. Para um slide, chame [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/pt/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/). Para um fundo, use [Background.get_effective](https://reference.aspose.com/slides/pt/python-net/aspose.slides/background/get_effective/), e para um preenchimento, use [FillFormat.get_effective](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fillformat/get_effective/).

O exemplo a seguir lê o tema efetivo, o fundo e o primeiro preenchimento de forma de um slide:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]
    effective_theme = slide.theme_manager.create_theme_effective()
    effective_background = slide.background.get_effective()
    print(f"Effective major Latin font: {effective_theme.font_scheme.major.latin_font.font_name}")
    print(f"Effective minor Latin font: {effective_theme.font_scheme.minor.latin_font.font_name}")
    print(f"Effective background fill type: {effective_background.fill_format.fill_type}")
    if len(slide.shapes) > 0:
        effective_fill = slide.shapes[0].fill_format.get_effective()
        print(f"First shape effective fill type: {effective_fill.fill_type}")
        if effective_fill.fill_type == slides.FillType.SOLID:
            print(f"First shape effective fill color: {effective_fill.solid_fill_color}")
```

Use dados efetivos para diagnóstico de renderização, validação e comparações. Se você inspecionar apenas [Presentation.master_theme](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/master_theme/), pode perder um mestre, layout, slide ou substituição de forma que altere a aparência final.

## **FAQ**

**Posso aplicar um tema a um único slide sem mudar o mestre?**

Sim. Use o [SlideThemeManager](https://reference.aspose.com/slides/pt/python-net/aspose.slides.theme/slidethememanager/) do slide e inicialize seu tema de substituição. A alteração permanece local a esse slide; os outros slides continuam a herdar seus temas existentes.

**Qual é a maneira mais segura de transportar um tema de uma apresentação para outra?**

Ao mover um slide e preservar sua aparência original, clone o mestre de origem na apresentação de destino e clone o slide com esse mestre usando [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/pt/python-net/aspose.slides/masterslidecollection/add_clone/) e [SlideCollection.add_clone](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slidecollection/add_clone/). Isso mantém o mestre, os layouts e o tema juntos.

**Como posso ver os valores efetivos após a herança e substituições?**

Use [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/pt/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) para um slide ou tema de layout e os métodos de dados efetivos correspondentes para objetos de formato, como [Background.get_effective](https://reference.aspose.com/slides/pt/python-net/aspose.slides/background/get_effective/) e [FillFormat.get_effective](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fillformat/get_effective/). Essas APIs retornam os valores resolvidos após a aplicação da herança e das substituições.