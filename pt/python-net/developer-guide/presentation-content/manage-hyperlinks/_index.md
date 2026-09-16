---
title: Gerenciar Hyperlinks de Apresentação em Python
linktitle: Gerenciar Hyperlinks
type: docs
weight: 20
url: /pt/python-net/manage-hyperlinks/
keywords:
- adicionar URL
- adicionar hyperlink
- criar hyperlink
- formatar hyperlink
- remover hyperlink
- atualizar hyperlink
- hyperlink de texto
- hyperlink de slide
- hyperlink de forma
- hyperlink de imagem
- hyperlink de vídeo
- hyperlink mutável
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Adicionar, formatar, atualizar e remover hyperlinks em apresentações PowerPoint e OpenDocument com Aspose.Slides para Python via .NET, usando exemplos em Python."
---
## **Introdução**

Um hyperlink conecta o conteúdo da apresentação a um site ou a um local dentro da apresentação. No PowerPoint, hyperlinks geralmente atendem a dois propósitos:

* Abrir um site a partir de texto, forma ou quadro de mídia.
* Navegar para outro slide, por exemplo, a partir de um sumário.

O Aspose.Slides for Python via .NET permite adicionar esses links, controlar sua aparência e som, atualizar suas propriedades e removê-los. Os exemplos abaixo mostram como trabalhar com hyperlinks em elementos individuais e como acessar hyperlinks no nível da apresentação, slide ou quadro de texto.

{{% alert color="info" title="Note" %}}
Você também pode editar apresentações com o [editor gratuito online de PowerPoint da Aspose](https://products.aspose.app/slides/pt/editor).
{{% /alert %}}

## **Adicionar Hyperlinks de URL**

Você pode atribuir um URL de site a texto, forma ou quadro de mídia. O elemento ao qual você atribui o hyperlink determina a área clicável: uma porção de texto vincula o texto selecionado, enquanto uma forma ou quadro vincula o objeto do slide.

### **Adicionar Hyperlinks de URL ao Texto**

Para vincular texto a um site, atribua um [Hyperlink](https://reference.aspose.com/slides/pt/python-net/aspose.slides/hyperlink/) à propriedade [hyperlink_click](https://reference.aspose.com/slides/pt/python-net/aspose.slides/portionformat/hyperlink_click/) da porção de texto, como mostrado abaixo. Apenas essa porção de texto se torna clicável.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    text_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    text_shape.add_text_frame("Aspose: File Format APIs")
    portion_format = text_shape.text_frame.paragraphs[0].portions[0].portion_format
    portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    portion_format.hyperlink_click.tooltip = "Explore Aspose file format APIs"
    portion_format.font_height = 32
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

### **Adicionar Hyperlinks de URL a Formas e Quadros de Mídia**

Para tornar uma forma ou quadro clicável, defina sua propriedade [hyperlink_click](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shape/hyperlink_click/). O hyperlink pertence ao próprio objeto, não a uma porção de texto dentro dele.

A mesma abordagem se aplica a quadros de imagem, áudio e vídeo: atribua o hyperlink ao quadro e defina o [tooltip](https://reference.aspose.com/slides/pt/python-net/aspose.slides/hyperlink/tooltip/) do link, se necessário.

O exemplo a seguir torna um retângulo clicável:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)
    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "Explore Aspose file format APIs"
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

## **Usar Hyperlinks para Criar um Sumário**

Hyperlinks internos permitem que os leitores pulem de um sumário para um slide específico. O exemplo a seguir usa [set_internal_hyperlink_click](https://reference.aspose.com/slides/pt/python-net/aspose.slides/hyperlinkmanager/set_internal_hyperlink_click/) para vincular o texto “Page 2” no primeiro slide ao segundo slide.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(first_slide.layout_slide)
    table_of_contents = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 300, 100)
    table_of_contents.fill_format.fill_type = slides.FillType.NO_FILL
    table_of_contents.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    table_of_contents.text_frame.paragraphs.clear()
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph.text = "Title of slide 2 .......... "
    link_portion = slides.Portion()
    link_portion.text = "Page 2"
    link_portion.portion_format.hyperlink_manager.set_internal_hyperlink_click(second_slide)
    paragraph.portions.add(link_portion)
    table_of_contents.text_frame.paragraphs.add(paragraph)
    presentation.save("link_to_slide.pptx", slides.export.SaveFormat.PPTX)
```

## **Formatar Hyperlinks**

### **Cor**

A propriedade [color_source](https://reference.aspose.com/slides/pt/python-net/aspose.slides/hyperlink/color_source/) de [Hyperlink](https://reference.aspose.com/slides/pt/python-net/aspose.slides/hyperlink/) determina se um hyperlink usa a cor de hyperlink da apresentação ou a formatação da porção de texto. Para aplicar uma cor de texto personalizada, selecione [HyperlinkColorSource.PORTION_FORMAT](https://reference.aspose.com/slides/pt/python-net/aspose.slides/hyperlinkcolorsource/) e defina a cor de preenchimento da porção. Esse recurso foi introduzido no PowerPoint 2019; versões anteriores não aplicam essa configuração.

O exemplo a seguir adiciona dois hyperlinks de texto ao mesmo slide. O primeiro usa preenchimento de texto vermelho, enquanto o segundo mantém a cor padrão de hyperlink.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    colored_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 450, 50, False)
    colored_shape.add_text_frame("This hyperlink uses a custom color.")
    colored_portion_format = colored_shape.text_frame.paragraphs[0].portions[0].portion_format
    colored_portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    colored_portion_format.hyperlink_click.color_source = slides.HyperlinkColorSource.PORTION_FORMAT
    colored_portion_format.fill_format.fill_type = slides.FillType.SOLID
    colored_portion_format.fill_format.solid_fill_color.color = draw.Color.red
    default_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 450, 50, False)
    default_shape.add_text_frame("This hyperlink uses the default color.")
    default_shape.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    presentation.save("presentation-out-hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

### **Som**

Um hyperlink pode reproduzir um som ao ser ativado ou interromper um som que já está sendo reproduzido. Use as propriedades a seguir para configurar esses comportamentos:

- [Hyperlink.sound](https://reference.aspose.com/slides/pt/python-net/aspose.slides/hyperlink/sound/) especifica o áudio associado ao hyperlink.
- [Hyperlink.stop_sound_on_click](https://reference.aspose.com/slides/pt/python-net/aspose.slides/hyperlink/stop_sound_on_click/) controla se a ativação do hyperlink interrompe o som anterior.

#### **Adicionar Som a um Hyperlink**

O exemplo a seguir carrega `sampleaudio.wav` e o associa a um botão no primeiro slide. Clicar no botão reproduz o som e navega para o próximo slide. Uma segunda forma naquele slide interrompe o som anterior ao ser clicada, sem executar ação de navegação.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("sampleaudio.wav", "rb") as audio_file:
        audio_data = audio_file.read()
    hyperlink_sound = presentation.audios.add_audio(audio_data)
    first_slide = presentation.slides[0]
    play_button = first_slide.shapes.add_auto_shape(slides.ShapeType.SOUND_BUTTON, 100, 100, 100, 50)
    play_button.hyperlink_click = slides.Hyperlink.next_slide
    if not play_button.hyperlink_click.stop_sound_on_click and play_button.hyperlink_click.sound is None:
        play_button.hyperlink_click.sound = hyperlink_sound

    second_slide = presentation.slides.add_empty_slide(first_slide.layout_slide)
    stop_button = second_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 100, 50)
    stop_button.hyperlink_click = slides.Hyperlink.no_action
    stop_button.hyperlink_click.stop_sound_on_click = True
    presentation.save("hyperlink-sound.pptx", slides.export.SaveFormat.PPTX)
```

#### **Extrair Som de um Hyperlink**

O exemplo a seguir abre a apresentação criada acima e lê o áudio do hyperlink da primeira forma para a memória através de [sound](https://reference.aspose.com/slides/pt/python-net/aspose.slides/hyperlink/sound/) e [binary_data](https://reference.aspose.com/slides/pt/python-net/aspose.slides/audio/binary_data/).

```python
import aspose.slides as slides

with slides.Presentation("hyperlink-sound.pptx") as presentation:
    if len(presentation.slides) > 0 and len(presentation.slides[0].shapes) > 0:
        hyperlink = presentation.slides[0].shapes[0].hyperlink_click
        sound = hyperlink.sound if hyperlink is not None else None
        if sound is not None:
            audio_data = sound.binary_data
            print(f"Extracted {len(audio_data)} bytes of hyperlink audio.")
        else:
            print("The first shape has no hyperlink sound.")
    else:
        print("The presentation has no first slide or shape to inspect.")
```

### **Configurações de Tooltip e Interação**

Você pode atualizar as seguintes propriedades de [Hyperlink](https://reference.aspose.com/slides/pt/python-net/aspose.slides/hyperlink/) após atribuir um hyperlink a texto ou forma:

- [tooltip](https://reference.aspose.com/slides/pt/python-net/aspose.slides/hyperlink/tooltip/) define o texto que o visualizador pode exibir como dica para o link.
- [target_frame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/hyperlink/target_frame/) especifica o quadro de destino dentro de um frameset HTML pai, quando aplicável.
- [history](https://reference.aspose.com/slides/pt/python-net/aspose.slides/hyperlink/history/) controla se a ativação do link adiciona seu destino à lista de hyperlinks visualizados.
- [highlight_click](https://reference.aspose.com/slides/pt/python-net/aspose.slides/hyperlink/highlight_click/) controla se o hyperlink é destacado ao ser clicado.

## **Remover Hyperlinks de Apresentações**

Use [get_any_hyperlinks](https://reference.aspose.com/slides/pt/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) para coletar contêineres de hyperlink, incluindo links de porções de texto, antes de alterá‑los. O exemplo a seguir remove ambos os tipos de ativação do primeiro slide. Para remover apenas um tipo, chame somente [remove_hyperlink_click](https://reference.aspose.com/slides/pt/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/) ou [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/pt/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/); remover a ação de clique não remove sua contraparte de mouse‑over.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    if len(presentation.slides) > 0:
        containers = list(presentation.slides[0].hyperlink_queries.get_any_hyperlinks())
        for container in containers:
            container.hyperlink_manager.remove_hyperlink_click()
            container.hyperlink_manager.remove_hyperlink_mouse_over()
        presentation.save("pres-removed-hyperlinks.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The presentation has no slides to process.")
```

Para remoção incondicional, [remove_all_hyperlinks](https://reference.aspose.com/slides/pt/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/) remove ambos os tipos de ativação no escopo selecionado em uma única chamada. Para limpeza seletiva e cobertura de mestres, layouts e notas, veja [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Construir um Inventário Completo de Hyperlinks**

Antes de distribuir uma apresentação, faça o inventário de suas ações interativas e de seus links web. [get_any_hyperlinks](https://reference.aspose.com/slides/pt/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) devolve objetos [IHyperlinkContainer](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ihyperlinkcontainer/), não uma lista plana de strings de URL. Inspecione tanto [hyperlink_click](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_click/) quanto [hyperlink_mouse_over](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_mouse_over/) em cada contêiner. Eles são independentes: o mesmo contêiner pode expor ambas as ações, portanto um relatório completo pode precisar de até duas linhas por contêiner.

A varredura apenas de hyperlinks em nível de forma pode perder links anexados a porções de texto. Consulte o escopo apropriado em vez disso e retenha os contêineres retornados para que possa atualizar ou remover suas ações posteriormente.

### **Consultar Escopos de Apresentação, Slide e Quadro de Texto**

A classe [HyperlinkQueries](https://reference.aspose.com/slides/pt/python-net/aspose.slides/hyperlinkqueries/) está disponível através de [Presentation.hyperlink_queries](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/hyperlink_queries/), [BaseSlide.hyperlink_queries](https://reference.aspose.com/slides/pt/python-net/aspose.slides/baseslide/hyperlink_queries/) e [TextFrame.hyperlink_queries](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/hyperlink_queries/). Cada escopo suporta as mesmas consultas:

- [get_hyperlink_clicks](https://reference.aspose.com/slides/pt/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_clicks/) retorna contêineres com ação de clique.
- [get_hyperlink_mouse_overs](https://reference.aspose.com/slides/pt/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_mouse_overs/) retorna contêineres com ação de mouse‑over.
- [get_any_hyperlinks](https://reference.aspose.com/slides/pt/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) retorna contêineres com uma ou ambas as ações.

O exemplo a seguir cria `hyperlink-audit-input.pptx` com um link de clique externo, um link de mouse‑over de arquivo, navegação interna de slide, um link de mouse‑over de texto e uma ação de macro. Ele não executa nenhuma dessas ações. As três consultas funcionam em todos os escopos; as contagens descrevem contêineres, não totais de ações. O escopo de quadro de texto exclui os próprios links da forma que o contém.

```python
import aspose.slides as slides


def print_counts(scope, queries):
    click_containers = queries.get_hyperlink_clicks()
    mouse_over_containers = queries.get_hyperlink_mouse_overs()
    all_containers = queries.get_any_hyperlinks()
    print(f"{scope}: click={len(click_containers)}, mouse-over={len(mouse_over_containers)}, any={len(all_containers)}")


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    destination = presentation.slides.add_empty_slide(slide.layout_slide)
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 60)
    shape.text_frame.text = "Click the text to go to slide 2"
    shape.hyperlink_manager.set_external_hyperlink_click("https://example.com/")
    shape.hyperlink_click.tooltip = "Public website"
    shape.hyperlink_manager.set_external_hyperlink_mouse_over("file:///C:/private/report.xlsx")

    portion_format = shape.text_frame.paragraphs[0].portions[0].portion_format
    portion_format.hyperlink_manager.set_internal_hyperlink_click(destination)
    portion_format.hyperlink_manager.set_external_hyperlink_mouse_over("https://example.com/help")
    macro_button = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 120, 200, 60)
    macro_button.hyperlink_manager.set_macro_hyperlink_click("ReviewPresentation")

    print_counts("Presentation", presentation.hyperlink_queries)
    print_counts("Slide 1", slide.hyperlink_queries)
    print_counts("Text frame", shape.text_frame.hyperlink_queries)
    presentation.save("hyperlink-audit-input.pptx", slides.export.SaveFormat.PPTX)
```

Para este exemplo, consultas de apresentação e de slide relatam três contêineres de clique, dois de mouse‑over e três contêineres com qualquer ação. A consulta de quadro de texto relata um contêiner em cada categoria.

### **Classificar Ações e Destinos**

Use [Hyperlink.action_type](https://reference.aspose.com/slides/pt/python-net/aspose.slides/hyperlink/action_type/) para interpretar uma ação antes de interpretar seu destino. Os valores de [HyperlinkActionType](https://reference.aspose.com/slides/pt/python-net/aspose.slides/hyperlinkactiontype/) abrangem mais do que navegação web:

| Values | Meaning for an audit |
| --- | --- |
| `HYPERLINK` | Hyperlink externo; inspecione a URL e seu esquema. |
| `JUMP_SPECIFIC_SLIDE` | Navegação interna para um slide específico. |
| `JUMP_FIRST_SLIDE`, `JUMP_PREVIOUS_SLIDE`, `JUMP_NEXT_SLIDE`, `JUMP_LAST_SLIDE`, `JUMP_LAST_VIEWED_SLIDE` | Navegação interna de apresentação incorporada, resolvida no contexto da apresentação. |
| `JUMP_END_SHOW`, `START_CUSTOM_SLIDE_SHOW` | Encerrar o show atual ou iniciar um show personalizado. |
| `START_MACRO` | Executar uma macro. |
| `START_PROGRAM` | Iniciar um programa. |
| `OPEN_FILE`, `OPEN_PRESENTATION` | Abrir um arquivo ou outra apresentação; revise separadamente de URLs web. |
| `START_STOP_MEDIA` | Iniciar ou interromper a reprodução de mídia. |
| `NO_ACTION`, `UNKNOWN` | Nenhuma ação de navegação, ou ação não reconhecida que requer revisão. |

Leia destinos externos de [external_url](https://reference.aspose.com/slides/pt/python-net/aspose.slides/hyperlink/external_url/) e destinos internos específicos de [target_slide](https://reference.aspose.com/slides/pt/python-net/aspose.slides/hyperlink/target_slide/). Ações internas e comandos incorporados podem não ter URL externa; uma URL vazia não significa que o contêiner não tenha ação. Preserve [external_url_original](https://reference.aspose.com/slides/pt/python-net/aspose.slides/hyperlink/external_url_original/) quando diferente da URL normalizada e inclua o [tooltip](https://reference.aspose.com/slides/pt/python-net/aspose.slides/hyperlink/tooltip/) quando disponível.

### **Relatar, Sanitizar e Verificar Hyperlinks**

O exemplo Python a seguir lê uma apresentação existente (use o arquivo criado acima), grava `hyperlink-audit.json`, aplica uma política, salva `hyperlink-sanitized.pptx` e o reabre para verificar novamente ambos os tipos de ativação. Ele coleta contêineres antes de alterá‑los e consulta cada escopo de slide uma única vez para evitar processamento duplicado. Consultas de apresentação cobrem slides ordinários; para um inventário de todo o pacote, o exemplo consulta slides ordinários, mestres, layouts, notas e os mestres de notas e folhetos quando presentes.

O relatório registra um índice de slide baseado em 1 e [slide_id](https://reference.aspose.com/slides/pt/python-net/aspose.slides/baseslide/slide_id/) quando disponível. O coletor retém o slide proprietário e o escopo junto de cada contêiner retornado. Mestres, layouts e notas não possuem índice de slide ordinário e são identificados pelo seu escopo. Contêineres de forma e contêineres de formatação de porção de texto são rotulados separadamente; outros tipos de contêiner mantêm seu nome de tipo em tempo de execução. Cada contêiner recebe um ID local de relatório para que suas duas ações possam ser correlacionadas.

Esta política de aplicação deliberadamente restritiva permite apenas URLs HTTPS absolutas e alvos internos de slide válidos. Ela rejeita macros, programas, ações de arquivo, outras ações de apresentação, ações desconhecidas e outros esquemas de URL. Essas rejeições são decisões de política, não um veredicto de segurança do Aspose.Slides. HTTPS isolado não estabelece confiança: adicione listas de permissão de hosts e outras verificações para sua aplicação. Tanto URLs externas originais quanto normalizadas são verificadas. O exemplo audita metadados sem seguir links ou executar ações.

Para remediação, o [hyperlink_manager](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_manager/) do contêiner oferece suporte a [set_external_hyperlink_click](https://reference.aspose.com/slides/pt/python-net/aspose.slides/hyperlinkmanager/set_external_hyperlink_click/), [remove_hyperlink_click](https://reference.aspose.com/slides/pt/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/) e [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/pt/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/). Aqui, links externos proibidos de clique são substituídos por uma página de destino HTTPS fixa; cliques proibidos e ações de mouse‑over proibidas são removidos independentemente. Defina `replace_external_clicks` como `False` para remover todas as violações de política. Escolha uma página de substituição de propriedade da aplicação antes da implantação.

A bandeira de exportação do relatório usa uma política conservadora de revisão de PDF: sinalize ações de mouse‑over e tudo que não seja um link externo ou salto de slide específico como potencialmente não suportado. É uma dica de revisão, não um teste de capacidade ou garantia de que links não sinalizados sobreviverão à exportação. Exportações suportadas de [PDF](/slides/pt/python-net/convert-powerpoint-to-pdf/) e [HTML](/slides/pt/python-net/convert-powerpoint-to-html/) podem preservar hyperlinks, dependendo da ação, opções de exportação e visualizador. Imagens raster [images](/slides/pt/python-net/convert-powerpoint-to-png/) e [video](/slides/pt/python-net/convert-powerpoint-to-video/) não podem preservar hyperlinks interativos; sinalize cada ação ao auditar para esses tipos de saída.

```python
import json
import sys
from urllib.parse import urlsplit
import aspose.slides as slides


def is_https(value):
    if not value or any(character.isspace() for character in value):
        return False
    try:
        uri = urlsplit(value)
        return uri.scheme.lower() == "https" and bool(uri.hostname)
    except ValueError:
        return False


def policy_violation(link):
    if link is None:
        return None
    if link.action_type == slides.HyperlinkActionType.JUMP_SPECIFIC_SLIDE:
        return "Missing target slide" if link.target_slide is None else None
    if link.action_type != slides.HyperlinkActionType.HYPERLINK:
        return "Action is not allowed"
    if not is_https(link.external_url):
        return "Normalized URL is not absolute HTTPS"
    original = link.external_url_original
    if original and not is_https(original):
        return "Original URL is not absolute HTTPS"
    return None


def slide_index(presentation, slide):
    if slide is not None:
        for index, candidate in enumerate(presentation.slides, start=1):
            if candidate.slide_id == slide.slide_id:
                return index
    return None


def collect_containers(presentation):
    # Consulte cada escopo de slide uma vez, mantendo o proprietário com cada contêiner.
    scopes = [("Slide", slide) for slide in presentation.slides]
    scopes.extend(("Master", master) for master in presentation.masters)
    scopes.extend(("Layout", layout) for layout in presentation.layout_slides)
    scopes.extend(("Notes", slide.notes_slide_manager.notes_slide) for slide in presentation.slides)
    scopes.append(("Notes master", presentation.master_notes_slide_manager.master_notes_slide))
    scopes.append(("Handout master", presentation.master_handout_slide_manager.master_handout_slide))
    found = []
    for scope, owner in scopes:
        if owner is not None:
            containers = list(owner.hyperlink_queries.get_any_hyperlinks())
            found.extend((container, scope, owner) for container in containers)
    return found


def add_row(rows, presentation, link, activation, container, container_id, scope, owner):
    if link is None:
        return
    target_slide = link.target_slide
    violation = policy_violation(link)
    if isinstance(container, slides.Shape):
        owner_type = "Shape"
    elif isinstance(container, slides.PortionFormat):
        owner_type = "Text portion"
    else:
        owner_type = type(container).__name__
    ordinary_action = link.action_type in (slides.HyperlinkActionType.HYPERLINK, slides.HyperlinkActionType.JUMP_SPECIFIC_SLIDE)
    original_url = link.external_url_original if link.external_url_original != link.external_url else None
    rows.append({
        "container_id": container_id,
        "slide_index": slide_index(presentation, owner) if scope == "Slide" else None,
        "slide_id": owner.slide_id,
        "scope": scope,
        "owner_type": owner_type,
        "activation": activation,
        "action_type": link.action_type.name,
        "external_url": link.external_url,
        "target_slide_index": slide_index(presentation, target_slide),
        "target_slide_id": target_slide.slide_id if target_slide is not None else None,
        "tooltip": link.tooltip,
        "original_external_url": original_url,
        "potentially_unsafe": violation is not None,
        "policy_violation": violation,
        "target_export": "PDF",
        "potentially_unsupported_by_export": activation == "mouse-over" or not ordinary_action,
    })


replace_external_clicks = True
replacement_url = "https://example.com/blocked-link"

with slides.Presentation("hyperlink-audit-input.pptx") as presentation:
    containers = collect_containers(presentation)
    rows = []
    for container_id, (container, scope, owner) in enumerate(containers, start=1):
        add_row(rows, presentation, container.hyperlink_click, "click", container, container_id, scope, owner)
        add_row(rows, presentation, container.hyperlink_mouse_over, "mouse-over", container, container_id, scope, owner)

    with open("hyperlink-audit.json", "w", encoding="utf-8") as report_file:
        json.dump(rows, report_file, indent=2)

    for container, scope, owner in containers:
        click = container.hyperlink_click
        if policy_violation(click) is not None:
            if replace_external_clicks and click.action_type == slides.HyperlinkActionType.HYPERLINK:
                container.hyperlink_manager.set_external_hyperlink_click(replacement_url)
            else:
                container.hyperlink_manager.remove_hyperlink_click()
        if policy_violation(container.hyperlink_mouse_over) is not None:
            container.hyperlink_manager.remove_hyperlink_mouse_over()

    presentation.save("hyperlink-sanitized.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("hyperlink-sanitized.pptx") as reopened:
    remaining_containers = collect_containers(reopened)
    violations = 0
    for container, scope, owner in remaining_containers:
        if policy_violation(container.hyperlink_click) is not None:
            violations += 1
        if policy_violation(container.hyperlink_mouse_over) is not None:
            violations += 1
    print(f"Audit rows: {len(rows)}; prohibited actions after reopening: {violations}")
    if violations != 0:
        print("Verification failed: do not distribute the saved presentation.")
        sys.exit(1)
```

Com a entrada criada acima, o relatório contém cinco linhas de ação. O link de mouse‑over de arquivo e o clique de macro são removidos, enquanto os links HTTPS e a navegação interna de slide permanecem. A verificação imprime zero ações proibidas. Uma entrada contendo um URL de clique externo proibido também exercita o ramo de substituição. Um contêiner com clique permitido e mouse‑over proibido mantém sua ação de clique.

Esta limpeza seletiva difere de [remove_all_hyperlinks](https://reference.aspose.com/slides/pt/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/), que remove ambos os tipos de ativação em todo o escopo selecionado independentemente da política. A verificação aqui checa apenas ações de hyperlink; não remove projetos VBA incorporados, objetos OLE ou outro conteúdo ativo, e não valida um PDF ou HTML exportado.

## **FAQ**

**Como posso vincular a uma seção ou ao seu primeiro slide?**

Seções no PowerPoint agrupam slides, mas um hyperlink interno aponta para um slide individual. Para criar navegação para uma seção, vincule ao primeiro slide dessa seção.

**Posso anexar um hyperlink a elementos do slide mestre para que funcione em todos os slides?**

Sim. Elementos do slide mestre e de layout suportam hyperlinks. Links nesses elementos ficam disponíveis durante a apresentação nos slides que utilizam o respectivo mestre ou layout.

**Os hyperlinks serão preservados ao exportar para PDF, HTML, imagens ou vídeo?**

Exportações suportadas de PDF e HTML podem preservar hyperlinks; imagens raster e vídeo não podem. Veja as considerações de exportação em [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).