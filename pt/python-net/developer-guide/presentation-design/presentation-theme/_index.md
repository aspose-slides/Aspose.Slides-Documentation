---
title: Gerenciar Temas de Apresentação do PowerPoint em Python
linktitle: Tema da Apresentação
type: docs
weight: 10
url: /pt/python-net/presentation-theme/
keywords:
- tema do PowerPoint
- tema da apresentação
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
description: "Domine temas de apresentação no Aspose.Slides para Python via .NET para criar, personalizar e converter arquivos PowerPoint com identidade visual consistente."
---
## **Introdução**

Um tema de apresentação define um conjunto coordenado de cores, fontes, estilos de plano de fundo, preenchimentos, linhas e efeitos. Objetos compatíveis com tema referem‑se a essas definições compartilhadas em vez de armazenar cada propriedade visual como um valor fixo, de modo que uma alteração no tema pode atualizar muitos objetos de uma só vez.

No Aspose.Slides, o tema a nível de apresentação está disponível através da propriedade [Presentation.master_theme](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/master_theme/). Uma apresentação também pode conter substituições de tema em níveis inferiores. Um mestre pode substituir o tema da apresentação através de [MasterThemeManager.override_theme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/masterthememanager/override_theme/), um layout pode substituir seu tema herdado através de [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/), e um slide individual pode fazer o mesmo. Na prática, o tema efetivo de um slide é resolvido por meio desta cadeia de herança: tema da apresentação, substituição do mestre, substituição do layout e substituição do slide.

![Componentes do tema: cores, fontes, estilos de plano de fundo e efeitos](theme-constituents.png)

As seções abaixo mostram os fluxos de trabalho mais comuns relacionados a temas: inspecionar um tema, alterar cores e fontes, copiar ou aplicar um tema, atualizar estilos de plano de fundo e efeitos, e ler valores efetivos após a herança e as substituições serem resolvidas.

## **Inspecionar um Tema**

O objeto [MasterTheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/mastertheme/) expõe as propriedades [color_scheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/mastertheme/color_scheme/), [font_scheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/mastertheme/font_scheme/) e [format_scheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/mastertheme/format_scheme/) do tema. Inspecionar essas coleções antes de alterá‑las é especialmente útil quando uma apresentação provém de uma fonte externa, pois o número e o conteúdo das entradas de estilo podem variar.

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

Se um arquivo usa vários mestres, não presuma que cada slide tem o mesmo tema efetivo. Inspecione o mestre associado ao slide e use o fluxo de trabalho de tema efetivo mostrado mais adiante neste artigo quando houver substituições de layout ou de slide.

## **Alterar Cores do Tema**

Preenchimentos, linhas e texto compatíveis com tema podem referir‑se a uma cor lógica da enumeração [SchemeColor](https://reference.aspose.com/slides/python-net/aspose.slides/schemecolor/). Quando você altera a entrada correspondente no [ColorScheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/colorscheme/) do tema, todos os objetos que ainda referenciam essa cor de tema são resolvidos contra o novo valor. Objetos que usam uma cor RGB direta não são alterados por uma atualização de cor do tema.

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

Como o retângulo continua vinculado ao `ACCENT4`, sua cor visível torna‑se vermelha após a mudança de tema. Se você substituir a cor de esquema por uma cor direta na forma, alterações posteriores em `accent4` não afetarão mais esse preenchimento.

### **Usar Cores da Paleta Adicional**

O PowerPoint deriva variantes mais claras e mais escuras de uma cor de tema aplicando transformações de cor. O Aspose.Slides expõe essas transformações por meio da enumeração [ColorTransformOperation](https://reference.aspose.com/slides/python-net/aspose.slides/colortransformoperation/).

![Cores principais do tema e cores claras e escuras geradas a partir da paleta adicional](additional-palette-colors.png)

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

### **Mapear Valores `SchemeColor` para Slots `ColorScheme`**

A enumeração [SchemeColor](https://reference.aspose.com/slides/python-net/aspose.slides/schemecolor/) usa `TEXT1`, `BACKGROUND1`, `TEXT2` e `BACKGROUND2`, enquanto [ColorScheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/colorscheme/) expõe os mesmos slots do tema como `dark1`, `light1`, `dark2` e `light2`. O mapeamento é fixo:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

Esses são nomes alternativos para os mesmos slots de tema; não são valores convertidos dinamicamente de uma forma para outra.

## **Alterar Fontes do Tema**

Um esquema de fontes do tema contém um conjunto principal de fontes para títulos e um conjunto secundário para o corpo do texto. As propriedades [FontScheme.major](https://reference.aspose.com/slides/python-net/aspose.slides.theme/fontscheme/major/) e [FontScheme.minor](https://reference.aspose.com/slides/python-net/aspose.slides.theme/fontscheme/minor/) expõem esses conjuntos.

Identificadores de fontes de tema compatíveis com PowerPoint podem ser usados na formatação de texto:

* `+mn‑lt` – Fonte do Corpo Latin (Minor Latin Font)
* `+mj‑lt` – Fonte do Título Latin (Major Latin Font)
* `+mn‑ea` – Fonte do Corpo East Asian (Minor East Asian Font)
* `+mj‑ea` – Fonte do Título East Asian (Major East Asian Font)
* `+mn‑cs` – Fonte do Corpo Complex Script (Minor Complex Script Font)
* `+mj‑cs` – Fonte do Título Complex Script (Major Complex Script Font)

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

As coleções de fontes principal e secundária também podem conter mapeamentos de fontes para sistemas de escrita individuais, como cirílico, árabe, japonês, georgiano e thaana. Para inspecionar, adicionar, substituir ou remover esses mapeamentos, veja [Script-Specific Theme Fonts](/slides/pt/python-net/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Para mais informações sobre fontes em apresentações, veja [PowerPoint Fonts](/slides/pt/python-net/powerpoint-fonts/).
{{% /alert %}}

### **Resolver Referências de Fonte do Tema**

Ao inspecionar texto, [FontData.font_name](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/font_name/) pode conter uma referência de tema como `+mn‑lt` em vez de um nome de família de fonte. Chame [FontData.get_font_name](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/get_font_name/) com o [IThemeEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides.theme/ithemeeffectivedata/) apropriado para resolver essa referência. Os prefixos `+mj` e `+mn` selecionam os conjuntos de fontes principal e secundário; os sufixos `-lt`, `-ea` e `-cs` selecionam, respectivamente, as fontes Latin, East Asian e Complex Script.

Obtenha o tema efetivo através de [Slide.create_theme_effective](https://reference.aspose.com/slides/python-net/aspose.slides/slide/create_theme_effective/) no objeto ao qual o tema se aplica ao texto inspecionado. Para texto comum em um slide, use `slide.create_theme_effective` para que o contexto inclua o tema herdado desse slide e as substituições locais. Ao inspecionar um layout ou mestre, use seu próprio tema efetivo. Não presuma que o tema do primeiro mestre se aplique a todos os slides.

O exemplo a seguir cria uma porção de texto que referencia explicitamente a fonte Latin secundária. Ele inicializa um esquema de fontes de slide através de [OverrideTheme.init_font_scheme_from_inherited](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from_inherited/) e define as famílias Latin principal e secundária como `Arial` e `Calibri`, tornando o resultado reproduzível sem um arquivo de entrada.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    theme = slide.theme_manager.override_theme
    theme.init_font_scheme_from_inherited()
    theme.font_scheme.major.latin_font = slides.FontData("Arial")
    theme.font_scheme.minor.latin_font = slides.FontData("Calibri")

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 60)
    shape.text_frame.text = "Text using the minor theme font"

    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.latin_font = slides.FontData("+mn-lt")

    font = portion.portion_format.latin_font
    effective_theme = slide.create_theme_effective()
    print(f"{font.font_name} -> {font.get_font_name(effective_theme)}")

    explicit_font = slides.FontData("Verdana")
    print(f"{explicit_font.font_name} -> {explicit_font.get_font_name(effective_theme)}")
```

A saída é `+mn‑lt -> Calibri` seguida de `Verdana -> Verdana`. A referência armazenada permanece inalterada, enquanto um nome de família explícito é retornado como está. Se a porção usasse `+mj‑lt`, ela seria resolvida para `Arial` neste tema.

Resolver uma referência de tema identifica a família de fonte especificada pelo tema. Não verifica a disponibilidade da fonte nem determina o arquivo de fonte realmente usado após substituição ou fallback de glifos durante a renderização. Consulte [Font Selection Sequence](/slides/pt/python-net/font-selection-sequence/) e [Font Substitution](/slides/pt/python-net/font-substitution/) para essas etapas separadas.

## **Copiar ou Aplicar um Tema**

Os fluxos de trabalho abaixo resolvem diferentes problemas relacionados a temas.

### **Aplicar um Tema Externo a Slides Dependentes de um Mestre**

Use [MasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/apply_external_theme_to_depending_slides/) quando você possui um arquivo de tema do PowerPoint (`.thmx`) e deseja restilizar todos os slides que dependem de um mestre específico. Selecione o mestre da coleção [Presentation.masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) ([MasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/)) e passe o caminho do arquivo de tema para o método.

O método executa as seguintes operações:

1. Cria um novo slide mestre baseado no mestre selecionado.
1. Aplica o tema externo ao novo mestre.
1. Atribui o novo mestre a todos os slides que anteriormente dependiam do mestre selecionado.
1. Retorna o [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/) recém‑criado.

O exemplo a seguir aplica um tema externo aos slides que dependem do primeiro mestre e salva a apresentação:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    selected_master = presentation.masters[0]

    themed_master = selected_master.apply_external_theme_to_depending_slides("corporate-theme.thmx")
    print(f"Created master: {themed_master.name}")

    presentation.save("presentation-with-external-theme.pptx", slides.export.SaveFormat.PPTX)
```

Um tema inválido, corrompido ou não suportado pode causar [PptxException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxexception/) ou uma de suas subclasses relacionadas a formato. Valide os caminhos fornecidos pelos usuários, trate falhas de acesso ao sistema de arquivos e salve a apresentação somente após o tema ter sido aplicado com sucesso.

Apenas os slides que dependiam do mestre selecionado são reatribuídos. Slides associados a outros mestres mantêm seus mestres e temas existentes. Cores, fontes, preenchimentos, linhas, planos de fundo e efeitos compatíveis com tema são resolvidos contra o tema externo. Cores, fontes, preenchimentos e outras formatações explicitamente atribuídas podem permanecer inalterados. Substituições a nível de layout e slide também podem ter precedência sobre valores herdados do novo mestre.

O tema pode referenciar fontes que não estão disponíveis no ambiente de execução. Para renderização e exportação consistentes, instale as fontes necessárias, forneça‑as através de [fontes personalizadas](/slides/pt/python-net/custom-font/), ou configure a [substituição de fontes](/slides/pt/python-net/font-substitution/).

Este é um fluxo de trabalho direto a nível de mestre: o método aceita um caminho de arquivo `.thmx` e não requer a criação manual de substituições de tema a nível de slide ou layout.

### **Aplicar Temas Externos Diferentes em uma Apresentação Multi‑Mestre**

Quando o mestre relevante não é conhecido previamente, obtenha‑o a partir de um slide representativo por meio de [Slide.layout_slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/layout_slide/) e [LayoutSlide.master_slide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/master_slide/). Armazene as referências originais dos mestres antes de aplicar quaisquer temas, pois cada chamada cria outro mestre na apresentação.

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

### **Preservar um Tema de Origem ao Mover Slides**

Se você quiser mover um slide para outra apresentação e preservar seu design original, clone o mestre de origem na apresentação de destino com [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/add_clone/), depois clone o slide com [SlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/) e o mestre clonado. Isso transporta o mestre, seus layouts e o tema associado juntos.

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

Este é o fluxo de trabalho preferido quando o slide de origem deve ter a mesma aparência no destino. Clonar apenas o conteúdo em um mestre de destino não relacionado pode alterar cores, fontes, planos de fundo e efeitos controlados por tema.

### **Aplicar Valores de Tema a um Slide Existente**

Se o slide de destino deve permanecer no mestre e layout atuais, inicialize uma substituição a nível de slide a partir do tema de origem. Os métodos [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/), [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/) e [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) copiam os três componentes principais do tema para a substituição.

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

Isso altera o tema usado por esse slide sem mudar o tema herdado por outros slides. Para remover a substituição local e retornar aos valores herdados, chame [OverrideTheme.clear](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/clear/).

### **Aplicar uma Substituição de Tema a um Layout**

Uma substituição a nível de layout se aplica aos slides que usam esse layout, a menos que um slide específico possua sua própria substituição. Os mesmos métodos de inicialização podem ser usados através do [LayoutSlideThemeManager](https://reference.aspose.com/slides/python-net/aspose.slides.theme/layoutslidethememanager/) do layout:

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

Use um tema a nível de mestre ou apresentação quando muitos layouts e slides devem compartilhar o mesmo design base, uma substituição de layout quando uma família de layouts precisa de estilo diferente, e uma substituição de slide apenas para exceções reais. Substituições excessivas a nível de slide dificultam previsões sobre mudanças globais de tema posteriores.

## **Atualizar Estilos de Plano de Fundo do Tema**

Os preenchimentos de plano de fundo do tema são armazenados em [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/background_fill_styles/). O PowerPoint pode apresentar mais opções de plano de fundo em sua interface do que o número de definições de preenchimento fisicamente armazenadas nesta coleção, pois a UI pode combinar preenchimentos de tema com cores de tema e outras referências de estilo.

![Galeria de estilos de plano de fundo do PowerPoint para um tema de apresentação](presentation-design_8.png)

Antes de usar um estilo de plano de fundo, inspecione a coleção armazenada e o [Background.style_index](https://reference.aspose.com/slides/python-net/aspose.slides/background/style_index/) atual. `style_index` usa `0` para nenhum preenchimento temático; valores positivos são referências a estilos de plano de fundo do tema. Isso difere da indexação direta de uma coleção Python, onde `[0]` significa o primeiro item armazenado. Não presuma que toda apresentação contenha o mesmo número de estilos de preenchimento de plano de fundo.

O exemplo a seguir informa a quantidade de preenchimentos de plano de fundo disponíveis, atribui uma referência de plano de fundo temático ao primeiro mestre e salva a apresentação:

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

O resultado visível depende da entrada de tema referenciada pelo mestre e de quaisquer substituições de plano de fundo no layout ou no slide. Se um slide usa seu próprio plano de fundo, alterar apenas o plano de fundo do mestre pode não mudar esse slide. Use [Background.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/background/get_effective/) quando precisar conhecer o plano de fundo final após a aplicação da herança.

{{% alert color="warning" title="Warning" %}}
Não trate `style_index` como um índice de coleção baseado em zero. Também evite codificar um número de estilo de um arquivo e presumir que ele tenha a mesma aparência em outro arquivo; definições de estilo de tema são específicas da apresentação.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Para formatação direta de plano de fundo e herança de plano de fundo, veja [Presentation Background](/slides/pt/python-net/presentation-background/).
{{% /alert %}}

## **Atualizar Efeitos do Tema**

Um esquema de formato de tema contém coleções distintas de [FormatScheme.fill_styles](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/fill_styles/), [FormatScheme.line_styles](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/line_styles/) e [FormatScheme.effect_styles](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/effect_styles/). Temas típicos do Office costumam conter três entradas principais de estilo que correspondem visualmente a formatação sutil, moderada e intensa, mas o código deve inspecionar cada coleção em vez de supor uma contagem fixa.

![Efeitos de tema sutis, moderados e intensos aplicados à mesma forma](presentation-design_10.png)

Ao acessar essas coleções em Python, o índice da coleção é baseado em zero: `[0]` é o primeiro estilo armazenado e `[2]` é o terceiro. Os índices de referência de estilo de uma forma são um conceito separado, exposto através de [ShapeStyle](https://reference.aspose.com/slides/python-net/aspose.slides/shapestyle/). Modificar um estilo de tema afeta formas que referenciam esse estilo; formas com formatação direta podem permanecer inalteradas.

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

Para formas que referenciam esses slots, o primeiro estilo de linha do tema torna‑se vermelho, o terceiro estilo de preenchimento do tema torna‑se verde floresta sólido e o terceiro estilo de efeito ganha uma sombra externa com distância de 10 pontos. O resultado visual exato ainda depende de quais slots de estilo cada forma referencia e se a formatação direta sobrescreve o tema.

![Estilos de efeito do tema após mudança de linha, preenchimento e sombra](presentation-design_11.png)

## **Selecionar Estilos de Preenchimento e Linha do Tema para uma Forma**

Uma forma pode selecionar seu preenchimento e contorno independentemente através de [ShapeStyle.fill_style_index](https://reference.aspose.com/slides/python-net/aspose.slides/shapestyle/fill_style_index/) e [ShapeStyle.line_style_index](https://reference.aspose.com/slides/python-net/aspose.slides/shapestyle/line_style_index/). Para ambas as propriedades, o índice `1` seleciona a primeira entrada na coleção temática correspondente (`fill_styles[0]` ou `line_styles[0]`) e o índice `2` seleciona a segunda entrada.

O exemplo a seguir define dois preenchimentos (ouro e azul celeste) e dois contornos (azul escuro a 6 pt e vermelho escuro a 12 pt) no tema padrão de uma nova apresentação. Ele salva o slide em três etapas para que você possa comparar os resultados no PowerPoint.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    styles = presentation.master_theme.format_scheme

    gold_fill = styles.fill_styles[0]
    gold_fill.fill_type = slides.FillType.SOLID
    gold_fill.solid_fill_color.preset_color = slides.PresetColor.GOLD
    blue_fill = styles.fill_styles[1]
    blue_fill.fill_type = slides.FillType.SOLID
    blue_fill.solid_fill_color.preset_color = slides.PresetColor.SKY_BLUE

    thin_line = styles.line_styles[0]
    thin_line.fill_format.fill_type = slides.FillType.SOLID
    thin_line.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
    thin_line.width = 6
    thick_line = styles.line_styles[1]
    thick_line.fill_format.fill_type = slides.FillType.SOLID
    thick_line.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_RED
    thick_line.width = 12

    shapes = presentation.slides[0].shapes
    left = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 205, 200, 130)
    right = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 420, 205, 200, 130)
    left.shape_style.fill_style_index = 1
    right.shape_style.fill_style_index = 2
    left.shape_style.line_style_index = 1
    right.shape_style.line_style_index = 1
    presentation.save("01-initial.pptx", slides.export.SaveFormat.PPTX)

    right.shape_style.line_style_index = 2
    presentation.save("02-line-changed.pptx", slides.export.SaveFormat.PPTX)

    gold_fill.solid_fill_color.preset_color = slides.PresetColor.SEA_GREEN
    presentation.save("03-theme-changed.pptx", slides.export.SaveFormat.PPTX)
```

| Estilos iniciais | Alterar o contorno da direita | Editar o primeiro preenchimento do tema |
|:---:|:---:|:---:|
| ![Retângulos dourado e azul-céu com contornos finos azul escuro correspondentes](theme-style-initial.png) | ![O retângulo azul-céu agora tem um contorno vermelho escuro espesso](theme-style-line-changed.png) | ![O retângulo esquerdo agora está verde e ambos os contornos permanecem inalterados](theme-style-fill-changed.png) |

Selecionar um estilo de linha diferente altera apenas o contorno do retângulo da direita. Editar o primeiro preenchimento do tema atualiza todas as formas que o utilizam. Aqui, apenas o retângulo esquerdo fica verde.

Em uma forma existente, uma cor de preenchimento local, cor de linha ou espessura de linha pode sobrescrever essa parte do estilo do tema. Se mudar um índice de estilo não produzir efeito visível, verifique a [formatação direta](/slides/pt/python-net/shape-formatting/) da forma.

## **Determinar se um Preenchimento Sólido Efetivo Usa uma Cor de Tema**

Um preenchimento pode ser armazenado diretamente em um objeto ou herdado de um parágrafo, layout, mestre, estilo de tema ou outro nível de formatação. Chame [FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/) para resolver essa hierarquia em um [IFillFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/) imutável. Primeiro verifique [IFillFormatEffectiveData.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/fill_type/). Só quando for `FillType.SOLID` você deve ler as propriedades de preenchimento sólido.

Para um preenchimento sólido, [IFillFormatEffectiveData.solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/solid_fill_color/) retorna o valor RGB final renderizado após herança, busca no tema e aplicação de transformações de cor. [IFillFormatEffectiveData.solid_fill_scheme_color](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/solid_fill_scheme_color/) retorna o slot lógico correspondente de [SchemeColor](https://reference.aspose.com/slides/python-net/aspose.slides/schemecolor/), como `TEXT1` ou `ACCENT6`. Um valor `SchemeColor.NOT_DEFINED` significa que o preenchimento sólido efetivo não se baseia em uma cor de esquema. Em um fluxo onde preenchimentos são ou cores de tema ou cores RGB diretas, esse valor identifica um preenchimento RGB direto.

Não use apenas o valor local de [ColorFormat.scheme_color](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/scheme_color/) para classificar um preenchimento. Por exemplo, uma porção de texto pode não ter cor de esquema definida localmente, portanto seu valor local é `NOT_DEFINED`, enquanto seu preenchimento efetivo herda uma cor de tema e resolve para `TEXT1` ou `ACCENT6`. Por outro lado, `solid_fill_scheme_color` indica qual slot lógico do tema produziu a cor efetiva, mas não indica se esse slot veio do objeto, parágrafo, layout, mestre ou outro nível da hierarquia.

O exemplo a seguir carrega uma apresentação, auditoria tanto os preenchimentos de formas quanto os de porções de texto, imprime cada valor RGB final e a cor de esquema associada, e destaca preenchimentos sólidos que não acompanharão alterações de cor do tema:

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

O ramo `NOT_DEFINED` fornece uma lista de auditoria de preenchimentos sólidos que não responderão a mudanças nos slots de cor do tema. Revise esses objetos quando uma apresentação precisar seguir uma nova paleta de marca. O valor RGB reportado ainda mostra a aparência atual, enquanto o valor de esquema explica se essa aparência está conectada ao tema.

Objetos de formato‑efetivo são instantâneos. Após mudar o tema da apresentação, uma substituição de tema ou qualquer formatação herdada, chame `get_effective` novamente e leia um novo objeto `IFillFormatEffectiveData` antes de comparar ou relatar cores.

## **Ler Valores de Tema Efetivos**

Objetos de tema brutos informam o que está definido em um nível específico. Valores efetivos informam o que um slide ou forma realmente usa após a herança e substituições locais serem resolvidas. Para um slide, chame [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/). Para um plano de fundo, use [Background.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/background/get_effective/), e para um preenchimento, use [FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/).

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

Use dados efetivos para diagnóstico de renderização, validação e comparações. Se você inspecionar apenas [Presentation.master_theme](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/master_theme/), pode perder um mestre, layout, slide ou substituição de forma que altere a aparência final.

## **FAQ**

**Aplicar um tema externo afeta todos os slides da apresentação?**

Não. [MasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/apply_external_theme_to_depending_slides/) reatribui apenas os slides que dependem do mestre selecionado. Slides que usam outros mestres mantêm seus temas existentes.

**Posso aplicar um tema a um único slide sem mudar o mestre?**

Sim. Use o [SlideThemeManager](https://reference.aspose.com/slides/python-net/aspose.slides.theme/slidethememanager/) do slide e inicialize sua substituição de tema. A alteração permanece local a esse slide; os demais slides continuam a herdar seus temas atuais.

**Qual é a maneira mais segura de transferir um tema de uma apresentação para outra?**

Ao mover um slide e preservar sua aparência de origem, clone o mestre de origem no destino e clone o slide com esse mestre usando [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/add_clone/) e [SlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/). Isso mantém o mestre, os layouts e o tema juntos.

**Como posso ver os valores efetivos após herança e substituições?**

Use [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) para um slide ou tema de layout e os métodos de dados efetivos correspondentes para objetos de formato, como [Background.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/background/get_effective/) e [FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/). Essas APIs retornam os valores resolvidos após a aplicação de herança e substituições.