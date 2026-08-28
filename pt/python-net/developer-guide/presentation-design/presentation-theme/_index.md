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
- tema externo
- THMX
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
description: "Domine os temas de apresentação no Aspose.Slides para Python via .NET para criar, personalizar e converter arquivos PowerPoint com identidade visual consistente."
---
## **Introdução**

Um tema de apresentação define um conjunto coordenado de cores, fontes, estilos de plano de fundo, preenchimentos, linhas e efeitos. Objetos que reconhecem temas referem‑se a essas definições compartilhadas em vez de armazenar cada propriedade visual como um valor fixo, de modo que uma alteração de tema pode atualizar muitos objetos de uma só vez.

No Aspose.Slides, o tema ao nível da apresentação está disponível através da propriedade [Presentation.master_theme](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/master_theme/). Uma apresentação também pode conter sobrescritas de tema em níveis inferiores. Um mestre pode sobrescrever o tema da apresentação por meio de [MasterThemeManager.override_theme](https://reference.aspose.com/slides/pt/python-net/aspose.slides.theme/masterthememanager/override_theme/), um layout pode sobrescrever o tema herdado por meio de [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/pt/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/), e um slide individual pode fazer o mesmo. Na prática, o tema efetivo de um slide é resolvido através desta cadeia de herança: tema da apresentação, sobrescrita do mestre, sobrescrita do layout e sobrescrita do slide.

![Componentes do tema: cores, fontes, estilos de plano de fundo e efeitos](theme-constituents.png)

As seções abaixo mostram os fluxos de trabalho de tema mais comuns: inspeção de um tema, alteração de cores e fontes, cópia ou aplicação de um tema, atualização de estilos de plano de fundo e efeitos, e leitura de valores efetivos após a herança e sobrescritas serem resolvidas.

## **Inspecionar um Tema**

O objeto [MasterTheme](https://reference.aspose.com/slides/pt/python-net/aspose.slides.theme/mastertheme/) expõe as propriedades [color_scheme](https://reference.aspose.com/slides/pt/python-net/aspose.slides.theme/mastertheme/color_scheme/), [font_scheme](https://reference.aspose.com/slides/pt/python-net/aspose.slides.theme/mastertheme/font_scheme/) e [format_scheme](https://reference.aspose.com/slides/pt/python-net/aspose.slides.theme/mastertheme/format_scheme/). Inspecionar essas coleções antes de alterá‑las é especialmente útil quando uma apresentação vem de uma fonte externa, pois o número e o conteúdo das entradas de estilo podem variar.

O exemplo a seguir lê as principais propriedades do tema e relata quantos estilos de plano de fundo, preenchimento, linha e efeito estão armazenados no tema:

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

Se um arquivo usa vários mestres, não presuma que todo slide tem o mesmo tema efetivo. Inspecione o mestre associado ao slide e use o fluxo de trabalho de tema efetivo mostrado mais adiante neste artigo quando houver sobrescritas de layout ou slide.

## **Alterar Cores do Tema**

Preenchimentos, linhas e textos sensíveis ao tema podem referir‑se a uma cor lógica da enumeração [SchemeColor](https://reference.aspose.com/slides/pt/python-net/aspose.slides/schemecolor/). Quando você altera a entrada correspondente no [ColorScheme](https://reference.aspose.com/slides/pt/python-net/aspose.slides.theme/colorscheme/) do tema, todos os objetos que ainda referenciam essa cor de tema são resolvidos contra o novo valor. Objetos que utilizam uma cor RGB direta não são alterados por uma atualização de cor de tema.

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

Como o retângulo permanece vinculado ao `ACCENT4`, sua cor visível torna‑se vermelha após a mudança de tema. Se você substituir a cor do esquema por uma cor direta na forma, alterações posteriores em `accent4` não afetarão mais esse preenchimento.

### **Usar Cores da Paleta Adicional**

O PowerPoint gera variantes mais claras e mais escuras a partir de uma cor de tema aplicando transformações de cor. O Aspose.Slides expõe essas transformações por meio da enumeração [ColorTransformOperation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/colortransformoperation/).

![Cores principais do tema e cores mais claras e mais escuras geradas a partir da paleta adicional](additional-palette-colors.png)

**1** – Cores principais do tema.  
**2** – Variantes mais claras e mais escuras produzidas a partir das cores principais do tema.

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

Essas variantes permanecem baseadas na cor do tema. Se `accent4` mudar posteriormente, as cores transformadas são recalculadas a partir do novo valor de `accent4`.

### **Mapear Valores de `SchemeColor` para Slots de `ColorScheme`**

A enumeração [SchemeColor](https://reference.aspose.com/slides/pt/python-net/aspose.slides/schemecolor/) usa `TEXT1`, `BACKGROUND1`, `TEXT2` e `BACKGROUND2`, enquanto [ColorScheme](https://reference.aspose.com/slides/pt/python-net/aspose.slides.theme/colorscheme/) expõe os mesmos slots de tema como `dark1`, `light1`, `dark2` e `light2`. O mapeamento é fixo:

* `TEXT1` = `dark1`  
* `BACKGROUND1` = `light1`  
* `TEXT2` = `dark2`  
* `BACKGROUND2` = `light2`

Estes são nomes alternativos para os mesmos slots de tema; não são valores convertidos dinamicamente de uma forma para outra.

## **Alterar Fontes do Tema**

Um esquema de fontes de tema contém um conjunto de fontes principal para títulos e um conjunto secundário para texto do corpo. As propriedades [FontScheme.major](https://reference.aspose.com/slides/pt/python-net/aspose.slides.theme/fontscheme/major/) e [FontScheme.minor](https://reference.aspose.com/slides/pt/python-net/aspose.slides.theme/fontscheme/minor/) expõem esses conjuntos.

Identificadores de fonte de tema compatíveis com PowerPoint podem ser usados na formatação de texto:

* `+mn-lt` – Fonte do Corpo Latin (Minor Latin Font)  
* `+mj-lt` – Fonte do Título Latin (Major Latin Font)  
* `+mn-ea` – Fonte do Corpo East Asian (Minor East Asian Font)  
* `+mj-ea` – Fonte do Título East Asian (Major East Asian Font)

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

As coleções de fontes principal e secundária também podem conter mapeamentos de fontes para sistemas de escrita individuais, como cirílico, árabe, japonês, georgiano e thaana. Para inspecionar, adicionar, substituir ou remover esses mapeamentos, consulte [Script-Specific Theme Fonts](/slides/pt/python-net/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}

Para mais informações sobre fontes de apresentação, veja [PowerPoint Fonts](/slides/pt/python-net/powerpoint-fonts/).

{{% /alert %}}

## **Copiar ou Aplicar um Tema**

Os fluxos de trabalho abaixo resolvem diferentes problemas relacionados a temas.

### **Aplicar um Tema Externo aos Slides Dependentes de um Mestre**

Use [IMasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/pt/python-net/aspose.slides/imasterslide/apply_external_theme_to_depending_slides/) quando você possui um arquivo de tema do PowerPoint (`.thmx`) e deseja restilizar todos os slides que dependem de um mestre específico. Selecione o mestre da coleção [Presentation.masters](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/masters/), que implementa [MasterSlideCollection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/masterslidecollection/), e passe o caminho do arquivo de tema para o método.

O método realiza as seguintes operações:

1. Cria um novo slide mestre baseado no mestre selecionado.  
1. Aplica o tema externo ao novo mestre.  
1. Atribui o novo mestre a todos os slides que anteriormente dependiam do mestre selecionado.  
1. Retorna o recém‑criado [IMasterSlide](https://reference.aspose.com/slides/pt/python-net/aspose.slides/imasterslide/).

O exemplo a seguir aplica um tema externo aos slides que dependem do primeiro mestre e salva a apresentação:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    selected_master = presentation.masters[0]
    themed_master = selected_master.apply_external_theme_to_depending_slides("corporate-theme.thmx")

    print(f"Created master: {themed_master.name}")
    presentation.save("presentation-with-external-theme.pptx", slides.export.SaveFormat.PPTX)
```

Um tema inválido, corrompido ou não suportado pode gerar [PptxException](https://reference.aspose.com/slides/pt/python-net/aspose.slides/pptxexception/) ou uma de suas subclasses relacionadas a formato. Valide os caminhos fornecidos pelos usuários, trate falhas de acesso ao sistema de arquivos e salve a apresentação somente depois que o tema for aplicado com sucesso.

Apenas os slides que dependiam do mestre selecionado são reatribuidos. Slides associados a outros mestres mantêm seus mestres e temas existentes. Cores, fontes, preenchimentos, linhas, planos de fundo e efeitos sensíveis a tema são resolvidos contra o tema externo. Cores, fontes, preenchimentos e outras formatações atribuídas diretamente podem permanecer inalterados. Sobrescritas ao nível de layout e de slide também podem ter precedência sobre valores herdados do novo mestre.

O tema pode referenciar fontes que não estão disponíveis no ambiente de tempo de execução. Para renderização e exportação consistentes, instale as fontes necessárias, forneça‑as por meio de [fontes personalizadas](/slides/pt/python-net/custom-font/), ou configure a [substituição de fontes](/slides/pt/python-net/font-substitution/).

Este é um fluxo de trabalho direto ao nível do mestre: o método aceita um caminho de arquivo `.thmx` e não requer a criação manual de sobrescritas de tema ao nível de slide ou layout.

### **Aplicar Temas Externos Diferentes em uma Apresentação Multi‑Mestre**

Quando o mestre relevante não é conhecido antecipadamente, obtenha‑o a partir de um slide representativo por meio de [Slide.layout_slide](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slide/layout_slide/) e [LayoutSlide.master_slide](https://reference.aspose.com/slides/pt/python-net/aspose.slides/layoutslide/master_slide/). Armazene as referências originais dos mestres antes de aplicar quaisquer temas, pois cada chamada cria outro mestre na apresentação.

O exemplo a seguir usa slides de duas seções para localizar seus mestres e aplica um tema externo diferente a cada grupo:

```python
import aspose.slides as slides

with slides.Presentation("multi-master-presentation.pptx") as presentation:
    if len(presentation.slides) < 5:
        print("The presentation does not contain the expected representative slides.")
    else:
        first_group_master = presentation.slides[0].layout_slide.master_slide
        second_group_master = presentation.slides[4].layout_slide.master_slide

        if first_group_master.slide_id == second_group_master.slide_id:
            print("The representative slides use the same master.")
        else:
            first_themed_master = first_group_master.apply_external_theme_to_depending_slides("blue-theme.thmx")
            second_themed_master = second_group_master.apply_external_theme_to_depending_slides("green-theme.thmx")

            print(f"First themed master: {first_themed_master.name}")
            print(f"Second themed master: {second_themed_master.name}")
            presentation.save("multi-master-with-external-themes.pptx", slides.export.SaveFormat.PPTX)
```

A primeira chamada afeta apenas os slides que dependiam de `first_group_master`, e a segunda chamada afeta apenas os slides que dependiam de `second_group_master`. Slides pertencentes a qualquer outro mestre não são restilizados.

### **Preservar o Tema de Origem ao Mover Slides**

Se você deseja mover um slide para outra apresentação e preservar seu design original, clone o mestre de origem para a apresentação de destino com [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/pt/python-net/aspose.slides/masterslidecollection/add_clone/), depois clone o slide com [SlideCollection.add_clone](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slidecollection/add_clone/) e o mestre clonado. Isso transporta o mestre, seus layouts e o tema associado juntos.

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

Este é o fluxo de trabalho preferido quando o slide de origem deve ter a mesma aparência no destino. Simplesmente clonar conteúdo sobre um mestre de destino não relacionado pode alterar cores, fontes, planos de fundo e efeitos controlados por tema.

### **Aplicar Valores de Tema a um Slide Existente**

Se o slide de destino deve permanecer no seu mestre e layout atuais, inicialize uma sobrescrita ao nível de slide a partir do tema de origem. Os métodos [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/pt/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/), [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/pt/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/) e [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/pt/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) copiam os três principais componentes do tema para a sobrescrita.

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

Isso altera o tema usado por aquele slide sem mudar o tema herdado por outros slides. Para remover a sobrescrita local e retornar aos valores herdados, chame [OverrideTheme.clear](https://reference.aspose.com/slides/pt/python-net/aspose.slides.theme/overridetheme/clear/).

### **Aplicar uma Sobrescrita de Tema a um Layout**

Uma sobrescrita ao nível de layout se aplica aos slides que utilizam aquele layout, salvo se um slide específico possuir sua própria sobrescrita. Os mesmos métodos de inicialização podem ser usados através do [LayoutSlideThemeManager](https://reference.aspose.com/slides/pt/python-net/aspose.slides.theme/layoutslidethememanager/) do layout:

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

Use um tema ao nível de mestre ou de apresentação quando muitos layouts e slides devem compartilhar o mesmo design base, uma sobrescrita de layout quando uma família de layouts precisa de estilo diferente, e uma sobrescrita de slide apenas para exceções reais. Sobrescritas excessivas ao nível de slide tornam mudanças globais de tema posteriores mais difíceis de prever.

## **Atualizar Estilos de Plano de Fundo do Tema**

Os preenchimentos de plano de fundo do tema são armazenados em [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/pt/python-net/aspose.slides.theme/formatscheme/background_fill_styles/). O PowerPoint pode apresentar mais opções de plano de fundo em sua interface do que o número de definições de preenchimento realmente armazenadas nesta coleção, pois a UI pode combinar preenchimentos de tema com cores de tema e outras referências de estilo.

![Galeria de estilos de plano de fundo do PowerPoint para um tema de apresentação](presentation-design_8.png)

Antes de usar um estilo de plano de fundo, inspecione a coleção armazenada e o [Background.style_index](https://reference.aspose.com/slides/pt/python-net/aspose.slides/background/style_index/) atual. `style_index` usa `0` para “sem preenchimento temático”; valores positivos são referências a estilos de plano de fundo do tema. Isso difere da indexação direta de uma coleção Python, onde `[0]` indica o primeiro item armazenado. Não presuma que toda apresentação contém o mesmo número de estilos de preenchimento de plano de fundo.

O exemplo a seguir relata a contagem de preenchimentos de plano de fundo disponíveis, atribui uma referência de plano de fundo temático ao primeiro mestre e salva a apresentação:

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

O resultado visível depende da entrada de tema referenciada pelo mestre e de quaisquer sobrescritas de plano de fundo ao nível de layout ou slide. Se um slide usa seu próprio plano de fundo, mudar apenas o plano de fundo do mestre pode não afetar esse slide. Use [Background.get_effective](https://reference.aspose.com/slides/pt/python-net/aspose.slides/background/get_effective/) quando precisar conhecer o plano de fundo final após a aplicação da herança.

{{% alert color="warning" title="Warning" %}}

Não trate `style_index` como um índice de coleção zero‑based. Também evite codificar um número de estilo de um arquivo e presumir que ele terá a mesma aparência em outro arquivo; definições de estilo de tema são específicas da apresentação.

{{% /alert %}}

{{% alert color="info" title="Tip" %}}

Para formatação direta de plano de fundo e herança de plano de fundo, veja [Presentation Background](/slides/pt/python-net/presentation-background/).

{{% /alert %}}

## **Atualizar Efeitos do Tema**

Um esquema de formato de tema contém coleções separadas de [FormatScheme.fill_styles](https://reference.aspose.com/slides/pt/python-net/aspose.slides.theme/formatscheme/fill_styles/), [FormatScheme.line_styles](https://reference.aspose.com/slides/pt/python-net/aspose.slides.theme/formatscheme/line_styles/) e [FormatScheme.effect_styles](https://reference.aspose.com/slides/pt/python-net/aspose.slides.theme/formatscheme/effect_styles/). Temas típicos do Office costumam conter três entradas principais que correspondem visualmente a formatações sutil, moderada e intensa, mas o código deve inspecionar cada coleção em vez de supor uma contagem fixa.

![Efeitos de tema sutis, moderados e intensos aplicados ao mesmo shape](presentation-design_10.png)

Ao acessar essas coleções em Python, o índice da coleção é zero‑based: `[0]` é o primeiro estilo armazenado e `[2]` é o terceiro. Os índices de referência de estilo de uma forma são um conceito separado, exposto por [IShapeStyle](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ishapestyle/). Modificar um estilo de tema afeta as formas que referenciam esse estilo; formas com formatação direta podem permanecer inalteradas.

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

Para as formas que referenciam esses slots, o primeiro estilo de linha do tema torna‑se vermelho, o terceiro estilo de preenchimento do tema torna‑se verde floresta sólido, e o terceiro estilo de efeito ganha uma sombra externa com distância de 10 pontos. O resultado visual exato ainda depende de quais slots de estilo cada forma referencia e se a formatação direta sobrescreve o tema.

![Estilos de efeito de tema após alterarem linha, preenchimento e sombra](presentation-design_11.png)

## **Determinar se um Preenchimento Sólido Efetivo Usa uma Cor de Tema**

Um preenchimento pode ser armazenado diretamente em um objeto ou herdado de um parágrafo, layout, mestre, estilo de tema ou outro nível de formatação. Chame [FillFormat.get_effective](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fillformat/get_effective/) para resolver essa hierarquia em um objeto imutável [IFillFormatEffectiveData](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ifillformateffectivedata/). Primeiro verifique [IFillFormatEffectiveData.fill_type](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ifillformateffectivedata/fill_type/). Só quando for `FillType.SOLID` você deve ler as propriedades de preenchimento sólido.

Para um preenchimento sólido, [IFillFormatEffectiveData.solid_fill_color](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ifillformateffectivedata/solid_fill_color/) retorna o valor RGB final renderizado após herança, busca no tema e aplicação de transformações de cor. [IFillFormatEffectiveData.solid_fill_scheme_color](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ifillformateffectivedata/solid_fill_scheme_color/) retorna o slot lógico correspondente da enumeração [SchemeColor](https://reference.aspose.com/slides/pt/python-net/aspose.slides/schemecolor/), como `TEXT1` ou `ACCENT6`. Um valor de `SchemeColor.NOT_DEFINED` indica que o preenchimento sólido efetivo não se baseia em uma cor de esquema. Em um fluxo de trabalho onde preenchimentos são cores de tema ou cores RGB diretas, esse valor identifica um preenchimento RGB direto.

Não use apenas o valor local de [IColorFormat.scheme_color](https://reference.aspose.com/slides/pt/python-net/aspose.slides/icolorformat/scheme_color/) para classificar um preenchimento. Por exemplo, uma parte de texto pode não ter um esquema de cor definido localmente, portanto seu valor local é `NOT_DEFINED`, enquanto seu preenchimento efetivo herda uma cor de tema e resolve para `TEXT1` ou `ACCENT6`. Por outro lado, `solid_fill_scheme_color` indica qual slot lógico do tema produziu a cor efetiva, mas não informa se esse slot veio do objeto, parágrafo, layout, mestre ou outro nível da hierarquia de formatação.

O exemplo a seguir carrega uma apresentação, audita os preenchimentos de formas e de porções de texto, imprime cada valor RGB final e o esquema de cor associado, e sinaliza preenchimentos sólidos que não seguirão alterações de cor de tema:

```python
import aspose.slides as slides


def audit_fill(object_name, local_fill):
    effective_fill = local_fill.get_effective()

    if effective_fill.fill_type != slides.FillType.SOLID:
        print(f"{object_name}: fill type = {effective_fill.fill_type}; not a solid fill.")
        return

    rgb = effective_fill.solid_fill_color
    effective_scheme_color = effective_fill.solid_fill_scheme_color
    local_scheme_color = local_fill.solid_fill_color.scheme_color

    print(f"{object_name}: RGB = #{rgb.r:02X}{rgb.g:02X}{rgb.b:02X}")
    print(f"{object_name}: local scheme = {local_scheme_color}, effective scheme = {effective_scheme_color}")

    if effective_scheme_color == slides.SchemeColor.NOT_DEFINED:
        print(f"{object_name}: direct RGB or another non-scheme fill; audit as theme-independent.")
    else:
        print(f"{object_name}: theme-dependent through {effective_scheme_color}.")


with slides.Presentation("input.pptx") as presentation:
    for slide_index, slide in enumerate(presentation.slides):
        for shape_index, shape in enumerate(slide.shapes):
            shape_name = f"Slide {slide_index + 1}, shape {shape_index + 1}"
            audit_fill(shape_name, shape.fill_format)

            if isinstance(shape, slides.AutoShape):
                for paragraph_index, paragraph in enumerate(shape.text_frame.paragraphs):
                    for portion_index, portion in enumerate(paragraph.portions):
                        portion_name = f"{shape_name}, paragraph {paragraph_index + 1}, portion {portion_index + 1}"
                        audit_fill(portion_name, portion.portion_format.fill_format)
```

O ramo `NOT_DEFINED` fornece uma lista de auditoria de preenchimentos sólidos que não responderão a mudanças nos slots de cor de tema. Revise esses objetos quando uma apresentação precisar seguir uma nova paleta de marca. O valor RGB informado ainda mostra a aparência atual, enquanto o valor de esquema explica se essa aparência está conectado ao tema.

Objetos de formato efetivo são instantâneos. Depois de mudar o tema da apresentação, uma sobrescrita de tema ou qualquer formatação herdada, chame `get_effective` novamente e leia um novo objeto `IFillFormatEffectiveData` antes de comparar ou relatar cores.

## **Ler Valores Efetivos do Tema**

Objetos de tema brutos mostram o que está definido em um nível específico. Valores efetivos mostram o que um slide ou forma realmente usa após a herança e sobrescritas locais serem resolvidas. Para um slide, chame [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/pt/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/). Para um plano de fundo, use [Background.get_effective](https://reference.aspose.com/slides/pt/python-net/aspose.slides/background/get_effective/), e para um preenchimento, use [FillFormat.get_effective](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fillformat/get_effective/).

O exemplo a seguir lê o tema efetivo, o plano de fundo e o primeiro preenchimento de forma de um slide:

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

Use dados efetivos para diagnósticos de renderização, validação e comparações. Se você inspecionar apenas [Presentation.master_theme](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/master_theme/), pode perder um mestre, layout, slide ou sobrescrita de forma que altere a aparência final.

## **FAQ**

**Aplicar um tema externo afeta todos os slides da apresentação?**

Não. [IMasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/pt/python-net/aspose.slides/imasterslide/apply_external_theme_to_depending_slides/) reatribui apenas os slides que dependem do mestre selecionado. Slides que utilizam outros mestres mantêm seus temas existentes.

**Posso aplicar um tema a um único slide sem mudar o mestre?**

Sim. Use o [SlideThemeManager](https://reference.aspose.com/slides/pt/python-net/aspose.slides.theme/slidethememanager/) do slide e inicialize sua sobrescrita de tema. A mudança permanece local ao slide; os demais slides continuam a herdar seus temas existentes.

**Qual é a maneira mais segura de transportar um tema de uma apresentação para outra?**

Ao mover um slide e preservar sua aparência original, clone o mestre de origem para o destino e clone o slide com esse mestre usando [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/pt/python-net/aspose.slides/masterslidecollection/add_clone/) e [SlideCollection.add_clone](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slidecollection/add_clone/). Isso mantém o mestre, os layouts e o tema juntos.

**Como posso ver os valores efetivos após herança e sobrescritas?**

Use [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/pt/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) para um slide ou tema de layout e os métodos correspondentes de dados efetivos para objetos de formato, como [Background.get_effective](https://reference.aspose.com/slides/pt/python-net/aspose.slides/background/get_effective/) e [FillFormat.get_effective](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fillformat/get_effective/). Essas APIs retornam os valores resolvidos após a aplicação de herança e sobrescritas.