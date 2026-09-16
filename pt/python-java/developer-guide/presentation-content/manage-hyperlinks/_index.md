---
title: Gerenciar Hiperlinks de Apresentação em Python via Java
linktitle: Gerenciar Hiperlinks
type: docs
weight: 20
url: /pt/python-java/manage-hyperlinks/
keywords:
- adicionar URL
- adicionar hiperlink
- criar hiperlink
- formatar hiperlink
- remover hiperlink
- atualizar hiperlink
- hiperlink de texto
- hiperlink de slide
- hiperlink de forma
- hiperlink de imagem
- hiperlink de vídeo
- hiperlink mutável
- PowerPoint
- OpenDocument
- apresentação
- Python
- Java
- Aspose.Slides
description: "Adicionar, formatar, atualizar e remover hiperlinks em apresentações PowerPoint e OpenDocument com Aspose.Slides para Python via Java, usando exemplos em Python."
---
## **Introdução**

Um hiperlink conecta o conteúdo da apresentação a um site ou a uma localização dentro da apresentação. No PowerPoint, os hiperlinks normalmente cumprem dois propósitos:

* Abrir um site a partir de texto, forma ou quadro de mídia.
* Navegar para outro slide, por exemplo, a partir de um índice.

O Aspose.Slides for Python via Java permite adicionar esses links, controlar sua aparência e som, atualizar suas propriedades e removê-los. Os exemplos abaixo mostram como trabalhar com hiperlinks em elementos individuais e como acessar hiperlinks no nível de apresentação, slide ou caixa de texto.

{{% alert color="info" title="Nota" %}}
Você também pode editar apresentações com o [editor gratuito online de PowerPoint da Aspose](https://products.aspose.app/slides/pt/editor).
{{% /alert %}} 

## **Adicionar Hiperlinks de URL**

Você pode atribuir uma URL de site a texto, forma ou quadro de mídia. O elemento ao qual você atribui o hiperlink determina a área clicável: uma porção de texto vincula o texto selecionado, enquanto uma forma ou quadro vincula o objeto do slide.

### **Adicionar Hiperlinks de URL ao Texto**

Para vincular texto a um site, passe um [Hyperlink](https://reference.aspose.com/slides/pt/python-java/aspose.slides/hyperlink/) ao método [setHyperlinkClick](https://reference.aspose.com/slides/pt/python-java/aspose.slides/portionformat/#setHyperlinkClick) da porção de texto, como mostrado abaixo. Apenas essa porção de texto se torna clicável.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, False)
    shape.addTextFrame("Aspose: File Format APIs")

    portion_format = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setTooltip("Explore Aspose file format APIs")
    portion_format.setFontHeight(32)

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Adicionar Hiperlinks de URL a Formas e Quadros de Mídia**

Para tornar uma forma ou quadro clicável, chame seu método [setHyperlinkClick](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/#setHyperlinkClick). O hiperlink pertence ao próprio objeto, não a uma porção de texto dentro dele.

A mesma abordagem se aplica a quadros de imagem, áudio e vídeo: atribua o hiperlink ao quadro e chame [setTooltip](https://reference.aspose.com/slides/pt/python-java/aspose.slides/hyperlink/#setTooltip) se necessário.

O exemplo a seguir torna um retângulo clicável:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50)

    shape.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    shape.getHyperlinkClick().setTooltip("Explore Aspose file format APIs")

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Usar Hiperlinks para Criar um Índice**

Hiperlinks internos permitem que os leitores pulem de um índice para um slide específico. O exemplo a seguir usa [setInternalHyperlinkClick](https://reference.aspose.com/slides/pt/python-java/aspose.slides/hyperlinkmanager/#setInternalHyperlinkClick) para vincular o texto “Página 2” no primeiro slide ao segundo slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Portion, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    second_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())

    table_of_contents = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100)
    table_of_contents.getFillFormat().setFillType(FillType.NoFill)
    table_of_contents.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    table_of_contents.getTextFrame().getParagraphs().clear()

    paragraph = Paragraph()
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph.setText("Title of slide 2 .......... ")

    link_portion = Portion()
    link_portion.setText("Page 2")
    link_portion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(second_slide)

    paragraph.getPortions().add(link_portion)
    table_of_contents.getTextFrame().getParagraphs().add(paragraph)

    presentation.save("link_to_slide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Formatar Hiperlinks**

### **Cor**

O método [setColorSource](https://reference.aspose.com/slides/pt/python-java/aspose.slides/hyperlink/#setColorSource) de [Hyperlink](https://reference.aspose.com/slides/pt/python-java/aspose.slides/hyperlink/) determina se um hiperlink usa a cor de hiperlink da apresentação ou a formatação da porção de texto. Para aplicar uma cor de texto personalizada, selecione [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/hyperlinkcolorsource/) e defina a cor de preenchimento da porção. Esse recurso foi introduzido no PowerPoint 2019; versões mais antigas não aplicam essa configuração.

O exemplo a seguir adiciona dois hiperlinks de texto ao mesmo slide. O primeiro usa preenchimento de texto vermelho, enquanto o segundo mantém a cor padrão de hiperlink.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Hyperlink, HyperlinkColorSource, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    colored_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, False)
    colored_link_shape.addTextFrame("This hyperlink uses a custom color.")
    portion_format = colored_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat)
    portion_format.getFillFormat().setFillType(FillType.Solid)
    portion_format.getFillFormat().getSolidFillColor().setColor(Color.RED)

    default_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, False)
    default_link_shape.addTextFrame("This hyperlink uses the default color.")
    default_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com/"))

    presentation.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **Som**

Um hiperlink pode reproduzir um som quando ativado ou interromper um som que já está sendo reproduzido. Use os métodos a seguir para configurar esses comportamentos:

- [Hyperlink.setSound](https://reference.aspose.com/slides/pt/python-java/aspose.slides/hyperlink/#setSound) especifica o áudio associado ao hiperlink.
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/pt/python-java/aspose.slides/hyperlink/#setStopSoundOnClick) controla se a ativação do hiperlink interrompe o som anterior.

#### **Adicionar um Som ao Hiperlink**

O exemplo a seguir carrega `sampleaudio.wav` e o associa a um botão no primeiro slide. Clicar no botão reproduz o som e navega para o próximo slide. Uma segunda forma naquele slide interrompe o som anterior ao ser clicada, sem executar nenhuma navegação.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    audio_data = Path("sampleaudio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    hyperlink_sound = presentation.getAudios().addAudio(java_audio_data)
    first_slide = presentation.getSlides().get_Item(0)
    play_button = first_slide.getShapes().addAutoShape(ShapeType.SoundButton, 100, 100, 100, 50)
    play_button.setHyperlinkClick(Hyperlink.getNextSlide())
    if not play_button.getHyperlinkClick().getStopSoundOnClick() and play_button.getHyperlinkClick().getSound() is None:
        play_button.getHyperlinkClick().setSound(hyperlink_sound)
    second_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())
    stop_button = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 100, 50)
    stop_button.setHyperlinkClick(Hyperlink.getNoAction())
    stop_button.getHyperlinkClick().setStopSoundOnClick(True)
    presentation.save("hyperlink-sound.pptx", SaveFormat.Pptx)
except OSError as exception:
    print(f"Unable to read the audio file: {exception}")
finally:
    presentation.dispose()
```

#### **Extrair o Som do Hiperlink**

O exemplo a seguir abre a apresentação criada acima e lê o áudio do hiperlink da primeira forma para a memória por meio de [getSound](https://reference.aspose.com/slides/pt/python-java/aspose.slides/hyperlink/#getSound) e [getBinaryData](https://reference.aspose.com/slides/pt/python-java/aspose.slides/audio/#getBinaryData).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("hyperlink-sound.pptx")
try:
    if presentation.getSlides().size() > 0 and presentation.getSlides().get_Item(0).getShapes().size() > 0:
        hyperlink = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getHyperlinkClick()
        sound = hyperlink.getSound() if hyperlink is not None else None
        if sound is not None:
            audio_data = bytes(sound.getBinaryData())
            print(f"Extracted {len(audio_data)} bytes of hyperlink audio.")
        else:
            print("The first shape has no hyperlink sound.")
    else:
        print("The presentation has no first slide or shape to inspect.")
finally:
    presentation.dispose()
```

### **Dica de Ferramenta e Configurações de Interação**

Você pode chamar os seguintes métodos de [Hyperlink](https://reference.aspose.com/slides/pt/python-java/aspose.slides/hyperlink/) após atribuir um hiperlink a texto ou forma:

- [setTooltip](https://reference.aspose.com/slides/pt/python-java/aspose.slides/hyperlink/#setTooltip) define o texto que o visualizador pode exibir como dica para o link.
- [setTargetFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/hyperlink/#setTargetFrame) especifica o quadro de destino dentro de um frameset HTML pai, quando aplicável.
- [setHistory](https://reference.aspose.com/slides/pt/python-java/aspose.slides/hyperlink/#setHistory) controla se a ativação do link adiciona seu destino à lista de hiperlinks visualizados.
- [setHighlightClick](https://reference.aspose.com/slides/pt/python-java/aspose.slides/hyperlink/#setHighlightClick) controla se o hiperlink é realçado ao ser clicado.

## **Remover Hiperlinks de Apresentações**

Use [getAnyHyperlinks](https://reference.aspose.com/slides/pt/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) para coletar contêineres de hiperlink, incluindo links de porções de texto, antes de alterá‑los. O exemplo a seguir remove ambos os tipos de ativação do primeiro slide. Para remover apenas um tipo, chame somente [removeHyperlinkClick](https://reference.aspose.com/slides/pt/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick) ou [removeHyperlinkMouseOver](https://reference.aspose.com/slides/pt/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver); remover a ação de clique não remove sua contrapartida de passagem do mouse.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        containers = list(presentation.getSlides().get_Item(0).getHyperlinkQueries().getAnyHyperlinks())
        for container in containers:
            container.getHyperlinkManager().removeHyperlinkClick()
            container.getHyperlinkManager().removeHyperlinkMouseOver()
        presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx)
    else:
        print("The presentation has no slides to process.")
finally:
    presentation.dispose()
```

Para remoção incondicional, [removeAllHyperlinks](https://reference.aspose.com/slides/pt/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks) elimina ambos os tipos de ativação no escopo selecionado em uma única chamada. Para limpeza seletiva e cobertura de mestres, layouts e notas, veja [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Construir um Inventário Completo de Hiperlinks**

Antes de distribuir uma apresentação, faça um inventário de suas ações interativas, bem como de seus links web. [getAnyHyperlinks](https://reference.aspose.com/slides/pt/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) devolve contêineres de hiperlink, como objetos [Shape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/) e [PortionFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/portionformat/), não uma lista plana de strings de URL. Inspecione tanto [getHyperlinkClick](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/#getHyperlinkClick) quanto [getHyperlinkMouseOver](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/#getHyperlinkMouseOver) em cada contêiner. Eles são independentes: o mesmo contêiner pode expor ambas as ações, de modo que um relatório completo pode precisar de até duas linhas por contêiner.

A varredura apenas de hiperlinks em nível de forma pode deixar de detectar links anexados a porções de texto. Consulte o escopo apropriado e retenha os contêineres retornados para que você possa atualizá‑los ou removê‑los posteriormente.

### **Consultas a Escopos de Apresentação, Slide e Caixa de Texto**

A classe [HyperlinkQueries](https://reference.aspose.com/slides/pt/python-java/aspose.slides/hyperlinkqueries/) está disponível por meio de [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getHyperlinkQueries), [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/pt/python-java/aspose.slides/baseslide/#getHyperlinkQueries) e [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textframe/#getHyperlinkQueries). Cada escopo suporta as mesmas consultas:

- [getHyperlinkClicks](https://reference.aspose.com/slides/pt/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkClicks) devolve contêineres com ação de clique.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/pt/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkMouseOvers) devolve contêineres com ação de passagem do mouse.
- [getAnyHyperlinks](https://reference.aspose.com/slides/pt/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) devolve contêineres com uma ou ambas as ações.

O exemplo a seguir cria `hyperlink-audit-input.pptx` com um link externo de clique, um link de passagem do mouse para arquivo, navegação interna de slide, um link de passagem do mouse em texto e uma ação de macro. Ele não executa nenhuma dessas ações. As mesmas três consultas funcionam em cada escopo; as contagens descrevem contêineres, não totais de ações. O escopo de caixa de texto exclui os próprios links da forma que a contém.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType


def print_counts(scope, queries):
    click_count = queries.getHyperlinkClicks().size()
    mouse_over_count = queries.getHyperlinkMouseOvers().size()
    any_count = queries.getAnyHyperlinks().size()
    print(f"{scope}: click={click_count}, mouse-over={mouse_over_count}, any={any_count}")


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    destination = presentation.getSlides().addEmptySlide(slide.getLayoutSlide())
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60)
    shape.getTextFrame().setText("Click the text to go to slide 2")
    shape.getHyperlinkManager().setExternalHyperlinkClick("https://example.com/")
    shape.getHyperlinkClick().setTooltip("Public website")
    shape.getHyperlinkManager().setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx")
    portion_format = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.getHyperlinkManager().setInternalHyperlinkClick(destination)
    portion_format.getHyperlinkManager().setExternalHyperlinkMouseOver("https://example.com/help")
    macro_button = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 120, 200, 60)
    macro_button.getHyperlinkManager().setMacroHyperlinkClick("ReviewPresentation")
    print_counts("Presentation", presentation.getHyperlinkQueries())
    print_counts("Slide 1", slide.getHyperlinkQueries())
    print_counts("Text frame", shape.getTextFrame().getHyperlinkQueries())
    presentation.save("hyperlink-audit-input.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Para este exemplo, as consultas de apresentação e de slide relatam três contêineres de clique, dois de passagem do mouse e três contêineres com qualquer ação. A consulta de caixa de texto relata um contêiner em cada categoria.

### **Classificar Ações e Destinos**

Use [Hyperlink.getActionType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/hyperlink/#getActionType) para interpretar uma ação antes de interpretar seu destino. Os valores de [HyperlinkActionType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/hyperlinkactiontype/) abrangem mais que navegação web:

| Valores | Significado para auditoria |
| --- | --- |
| `Hyperlink` | Hiperlink externo; inspecione a URL e seu esquema. |
| `JumpSpecificSlide` | Navegação interna para um slide específico. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Navegação interna de apresentação incorporada, resolvida no contexto da apresentação. |
| `JumpEndShow`, `StartCustomSlideShow` | Encerrar a apresentação atual ou iniciar uma apresentação personalizada. |
| `StartMacro` | Executar uma macro. |
| `StartProgram` | Iniciar um programa. |
| `OpenFile`, `OpenPresentation` | Abrir um arquivo ou outra apresentação; reveja separadamente de URLs web. |
| `StartStopMedia` | Iniciar ou interromper a reprodução de mídia. |
| `NoAction`, `Unknown` | Nenhuma ação de navegação, ou ação não reconhecida que requer revisão. |

Leia destinos externos via [getExternalUrl](https://reference.aspose.com/slides/pt/python-java/aspose.slides/hyperlink/#getExternalUrl) e destinos internos específicos via [getTargetSlide](https://reference.aspose.com/slides/pt/python-java/aspose.slides/hyperlink/#getTargetSlide). Ações internas e comandos incorporados podem não ter URL externa; uma URL vazia não significa que o contêiner não possui ação. Preserve o valor devolvido por [getExternalUrlOriginal](https://reference.aspose.com/slides/pt/python-java/aspose.slides/hyperlink/#getExternalUrlOriginal) quando ele difere da URL normalizada e inclua a dica de ferramenta devolvida por [getTooltip](https://reference.aspose.com/slides/pt/python-java/aspose.slides/hyperlink/#getTooltip) quando disponível.

### **Relatório, Sanitização e Verificação de Hiperlinks**

O exemplo Python a seguir lê uma apresentação existente (use o arquivo criado acima), grava `hyperlink-audit.json`, aplica uma política, salva `hyperlink-sanitized.pptx` e reabre‑a para verificar novamente ambos os tipos de ativação. Ele coleta contêineres antes de alterá‑los e usa igualdade de referência para evitar processar o mesmo contêiner duas vezes. As consultas de apresentação cobrem slides comuns; para um inventário de todo o pacote, ele também consulta explicitamente mestres, layouts, notas e os mestres de notas e folhetos quando presentes.

O relatório registra um índice de slide base 1 e [getSlideId](https://reference.aspose.com/slides/pt/python-java/aspose.slides/baseslide/#getSlideId) quando disponível. [getSlide](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/#getSlide) fornece o slide proprietário para contêineres suportados. Mestres, layouts e notas não têm índice de slide comum e são identificados pelo seu escopo. Contêineres de forma e de formatação de porção de texto são rotulados separadamente; outros tipos de contêiner mantêm seu nome de tipo em tempo de execução. Cada contêiner recebe um ID de relatório local para que suas duas ações possam ser correlacionadas. O relatório armazena tipos de ação como os constantes inteiros definidos pela enumeração Java.

Esta política de aplicação deliberadamente restritiva permite apenas URLs HTTPS absolutas e alvos internos de slide válidos. Ela rejeita macros, programas, ações de arquivo, outras ações de apresentação, ações desconhecidas e outros esquemas de URL. Essas rejeições são decisões de política, não um veredicto de segurança do Aspose.Slides. HTTPS por si só não estabelece confiança: adicione listas de permissões de hosts e outras verificações para sua aplicação. Tanto URLs externas originais quanto normalizadas são verificadas. O exemplo audita metadados sem seguir links ou executar ações.

Para remediação, o [getHyperlinkManager](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/#getHyperlinkManager) do contêiner oferece [setExternalHyperlinkClick](https://reference.aspose.com/slides/pt/python-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick), [removeHyperlinkClick](https://reference.aspose.com/slides/pt/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick) e [removeHyperlinkMouseOver](https://reference.aspose.com/slides/pt/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver). Aqui, links externos de clique proibidos são substituídos por uma página fixa HTTPS; outros cliques proibidos e ações de passagem do mouse proibidas são removidos de forma independente. Defina `replace_external_clicks` como `False` para remover todas as violações de política. Escolha uma página de substituição de propriedade da aplicação antes da implantação.

A bandeira de exportação do relatório usa uma política de revisão conservadora para PDF: sinalize ações de passagem do mouse e tudo que não seja um link externo ou salto de slide específico como potencialmente não suportado. É uma dica de revisão, não um teste de capacidade ou garantia de que links não sinalizados sobreviverão à exportação. As exportações suportadas de [PDF](/slides/pt/python-java/convert-powerpoint-to-pdf/) e [HTML](/slides/pt/python-java/convert-powerpoint-to-html/) podem preservar hiperlinks, dependendo da ação, opções de exportação e visualizador. Imagens raster [images](/slides/pt/python-java/convert-powerpoint-to-png/) e [video](/slides/pt/python-java/convert-powerpoint-to-video/) não podem preservar hiperlinks interativos; sinalize toda ação ao auditar para esses resultados.

```python
import json
from pathlib import Path
from urllib.parse import urlsplit

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HyperlinkActionType, PortionFormat, Presentation, SaveFormat, Shape

IdentityHashMap = jpype.JClass("java.util.IdentityHashMap")


def slide_index(presentation, slide):
    for index, candidate in enumerate(presentation.getSlides(), start=1):
        if candidate == slide:
            return index
    return None


def is_https(value):
    if not value:
        return False
    value = str(value)
    if any(character.isspace() or ord(character) < 32 for character in value):
        return False
    try:
        uri = urlsplit(value)
        return uri.scheme.lower() == "https" and bool(uri.hostname)
    except ValueError:
        return False


def policy_violation(link):
    if link is None:
        return None
    if link.getActionType() == HyperlinkActionType.JumpSpecificSlide:
        return "Missing target slide" if link.getTargetSlide() is None else None
    if link.getActionType() != HyperlinkActionType.Hyperlink:
        return "Action is not allowed"
    if not is_https(link.getExternalUrl()):
        return "Normalized URL is not absolute HTTPS"
    original = link.getExternalUrlOriginal()
    if original and not is_https(original):
        return "Original URL is not absolute HTTPS"
    return None


def collect_containers(presentation):
    found = list(presentation.getHyperlinkQueries().getAnyHyperlinks())
    scopes = list(presentation.getMasters()) + list(presentation.getLayoutSlides())
    for slide in presentation.getSlides():
        scopes.append(slide.getNotesSlideManager().getNotesSlide())
    scopes.append(presentation.getMasterNotesSlideManager().getMasterNotesSlide())
    scopes.append(presentation.getMasterHandoutSlideManager().getMasterHandoutSlide())
    for scope in scopes:
        if scope is not None:
            found.extend(scope.getHyperlinkQueries().getAnyHyperlinks())
    seen = IdentityHashMap()
    unique = []
    for container in found:
        if not seen.containsKey(container):
            seen.put(container, True)
            unique.append(container)
    return unique


def text_or_none(value):
    return str(value) if value is not None else None


def add_row(rows, presentation, link, activation, container, container_id):
    if link is None:
        return
    owner_slide = container.getSlide() if hasattr(container, "getSlide") else None
    target_slide = link.getTargetSlide()
    violation = policy_violation(link)
    if isinstance(container, Shape):
        owner_type = "Shape"
    elif isinstance(container, PortionFormat):
        owner_type = "Text portion"
    else:
        owner_type = str(container.getClass().getSimpleName())
    ordinary_action = link.getActionType() in (HyperlinkActionType.Hyperlink, HyperlinkActionType.JumpSpecificSlide)
    original = link.getExternalUrlOriginal()
    rows.append({
        "ContainerId": container_id,
        "SlideIndex": slide_index(presentation, owner_slide),
        "SlideId": int(owner_slide.getSlideId()) if owner_slide is not None else None,
        "Scope": str(owner_slide.getClass().getSimpleName()) if owner_slide is not None else None,
        "OwnerType": owner_type,
        "Activation": activation,
        "ActionType": int(link.getActionType()),
        "ExternalUrl": text_or_none(link.getExternalUrl()),
        "TargetSlideIndex": slide_index(presentation, target_slide),
        "TargetSlideId": int(target_slide.getSlideId()) if target_slide is not None else None,
        "Tooltip": text_or_none(link.getTooltip()),
        "OriginalExternalUrl": text_or_none(original) if original != link.getExternalUrl() else None,
        "PotentiallyUnsafe": violation is not None,
        "PolicyViolation": violation,
        "TargetExport": "PDF",
        "PotentiallyUnsupportedByExport": activation == "mouse-over" or not ordinary_action,
    })


replace_external_clicks = True
replacement_url = "https://example.com/blocked-link"
presentation = Presentation("hyperlink-audit-input.pptx")
try:
    containers = collect_containers(presentation)
    rows = []
    for container_id, container in enumerate(containers, start=1):
        add_row(rows, presentation, container.getHyperlinkClick(), "click", container, container_id)
        add_row(rows, presentation, container.getHyperlinkMouseOver(), "mouse-over", container, container_id)
    report = json.dumps(rows, indent=2)
    Path("hyperlink-audit.json").write_text(report, encoding="utf-8")

    for container in containers:
        click = container.getHyperlinkClick()
        if policy_violation(click) is not None:
            if replace_external_clicks and click.getActionType() == HyperlinkActionType.Hyperlink:
                container.getHyperlinkManager().setExternalHyperlinkClick(replacement_url)
            else:
                container.getHyperlinkManager().removeHyperlinkClick()
        if policy_violation(container.getHyperlinkMouseOver()) is not None:
            container.getHyperlinkManager().removeHyperlinkMouseOver()
    presentation.save("hyperlink-sanitized.pptx", SaveFormat.Pptx)

    reopened = Presentation("hyperlink-sanitized.pptx")
    try:
        remaining_containers = collect_containers(reopened)
        violations = 0
        for container in remaining_containers:
            if policy_violation(container.getHyperlinkClick()) is not None:
                violations += 1
            if policy_violation(container.getHyperlinkMouseOver()) is not None:
                violations += 1
        print(f"Audit rows: {len(rows)}; prohibited actions after reopening: {violations}")
        if violations != 0:
            print("Verification failed: do not distribute the saved presentation.")
    finally:
        reopened.dispose()
except OSError as exception:
    print(f"Unable to write the audit report: {exception}")
finally:
    presentation.dispose()
```

Com a entrada criada acima, o relatório contém cinco linhas de ação. O link de passagem do mouse para arquivo e a macro de clique são removidos, enquanto os links HTTPS e a navegação interna de slide permanecem. A verificação imprime zero ações proibidas. Uma entrada contendo um URL de clique externo proibido também exercita o ramo de substituição. Um contêiner com clique permitido e passagem do mouse proibida mantém sua ação de clique.

Essa limpeza seletiva difere de [removeAllHyperlinks](https://reference.aspose.com/slides/pt/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks), que remove ambos os tipos de ativação em todo o escopo selecionado, independentemente da política. A verificação aqui checa apenas ações de hiperlink; não remove projetos VBA embutidos, objetos OLE ou outro conteúdo ativo, nem valida um PDF ou HTML exportado.

## **FAQ**

**Como posso vincular a uma seção ou ao seu primeiro slide?**

Seções no PowerPoint agrupam slides, mas um hiperlink interno aponta para um slide individual. Para criar navegação a uma seção, vincule ao primeiro slide dessa seção.

**Posso anexar um hiperlink a elementos de mestre de slide para que ele funcione em todos os slides?**

Sim. Elementos de mestre de slide e de layout suportam hiperlinks. Links nesses elementos ficam disponíveis durante a apresentação nos slides que utilizam o mestre ou layout correspondente.

**Os hiperlinks serão preservados ao exportar para PDF, HTML, imagens ou vídeo?**

Exportações suportadas de PDF e HTML podem preservar hiperlinks; imagens raster e vídeo não podem. Consulte as considerações de exportação em [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).