---
title: Aplicar ou Alterar Layouts de Slides em Python
linktitle: Layout de Slide
type: docs
weight: 60
url: /pt/python-net/slide-layout/
keywords:
- layout de slide
- layout de conteúdo
- espaço reservado
- design de apresentação
- design de slide
- layout não utilizado
- visibilidade de rodapé
- slide de título
- título e conteúdo
- cabeçalho de seção
- dois conteúdos
- comparação
- apenas título
- layout em branco
- conteúdo com legenda
- imagem com legenda
- título e texto vertical
- título vertical e texto
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Aprenda a gerenciar e personalizar layouts de slides no Aspose.Slides for Python via .NET. Explore tipos de layout, controle de espaços reservados, visibilidade de rodapé e manipulação de layouts através de exemplos de código em Python."
---
## **Introdução**

Um layout de slide define a disposição das caixas de espaço reservado e a formatação do conteúdo em um slide. Ele controla quais espaços reservados estão disponíveis e onde eles aparecem. Os layouts de slides ajudam a criar apresentações de forma rápida e consistente—seja criando algo simples ou mais complexo. Alguns dos layouts de slide mais comuns no PowerPoint incluem:

**Layout de Slide de Título** – Inclui dois espaços reservados de texto: um para o título e outro para o subtítulo.

**Layout de Título e Conteúdo** – Apresenta um espaço reservado de título menor na parte superior e um maior abaixo para o conteúdo principal (como texto, marcadores, gráficos, imagens e mais).

**Layout em Branco** – Não contém espaços reservados, dando controle total para projetar o slide do zero.

Os layouts de slides fazem parte de um slide mestre, que é o slide de nível superior que define estilos de layout para a apresentação. Você pode acessar e modificar slides de layout através do slide mestre—por tipo, nome ou ID exclusivo. Alternativamente, pode editar um layout de slide específico diretamente na apresentação.

Para trabalhar com layouts de slides no Aspose.Slides for Python, você pode usar:

- Propriedades como [layout_slides](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/layout_slides/) e [masters](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/masters/) da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/)
- Tipos como [LayoutSlide](https://reference.aspose.com/slides/pt/python-net/aspose.slides/layoutslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/masterlayoutslidecollection/), [LayoutPlaceholderManager](https://reference.aspose.com/slides/pt/python-net/aspose.slides/layoutplaceholdermanager/) e [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/pt/python-net/aspose.slides/layoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Para saber mais sobre como trabalhar com slides mestres, veja o artigo [Gerenciar Slides Mestres do PowerPoint em Python](/slides/pt/python-net/slide-master/).
{{% /alert %}}

## **Adicionar Layouts de Slides às Apresentações**

Para personalizar a aparência e a estrutura dos seus slides, pode ser necessário adicionar novos layouts de slide a uma apresentação. O Aspose.Slides for Python permite verificar se um layout específico já existe, adicionar um novo se necessário e usá‑lo para inserir slides com base nesse layout.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
2. Acesse a [MasterLayoutSlideCollection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/masterlayoutslidecollection/).
3. Verifique se o layout de slide desejado já existe na coleção. Se não, adicione o layout de slide que precisar.
4. Adicione um slide vazio baseado no novo layout de slide.
5. Salve a apresentação.

O código Python a seguir demonstra como adicionar um layout de slide a uma apresentação PowerPoint:

```python
import aspose.slides as slides

# Instanciar a classe Presentation para abrir o arquivo de apresentação.
with slides.Presentation("sample.pptx") as presentation:
    # Percorrer os tipos de layout de slide para selecionar um layout de slide.
    layout_slides = presentation.masters[0].layout_slides
    layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)
    if layout_slide is None:
         layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.TITLE)

    if layout_slide is None:
        # Situação em que a apresentação não contém todos os tipos de layout.
        # O arquivo de apresentação contém apenas os tipos de layout Em Branco e Personalizado.
        # No entanto, os layouts de slide com tipos personalizados podem ter nomes reconhecíveis,
        # como "Título", "Título e Conteúdo", etc., que podem ser usados para a seleção de layout de slide.
        # Também é possível basear-se em um conjunto de tipos de forma de espaço reservado.
        # Por exemplo, um slide de Título deve ter apenas o tipo de espaço reservado Título, e assim por diante.
        for title_and_object_layout_slide in layout_slides:
            if title_and_object_layout_slide.name == "Title and Object":
                layout_slide = title_and_object_layout_slide
                break

        if layout_slide is None:
            for title_layout_slide in layout_slides:
                if title_layout_slide.name == "Title":
                    layout_slide = title_layout_slide
                    break

            if layout_slide is None:
                layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
                if layout_slide is None:
                    layout_slide = layout_slides.Add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Title and Object")

    # Adicionar um slide vazio usando o layout de slide adicionado.
    presentation.slides.insert_empty_slide(0, layout_slide)

    # Salvar a apresentação no disco.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Remover Layouts de Slide Não Utilizados**

O Aspose.Slides fornece o método [remove_unused_layout_slides](https://reference.aspose.com/slides/pt/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) da classe [Compress](https://reference.aspose.com/slides/pt/python-net/aspose.slides.lowcode/compress/) para permitir excluir layouts de slide indesejados e não utilizados.

O código Python a seguir mostra como remover um layout de slide de uma apresentação PowerPoint:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Adicionar Espaços Reservados a Layouts de Slide**

O Aspose.Slides fornece a propriedade [LayoutSlide.placeholder_manager](https://reference.aspose.com/slides/pt/python-net/aspose.slides/layoutslide/placeholder_manager/), que permite adicionar novos espaços reservados a um layout de slide.

Este gerenciador contém métodos para os seguintes tipos de espaço reservado:

| Espaço Reservado do PowerPoint | Método |
| ------------------------------ | ------ |
| ![Conteúdo](content.png) | add_content_placeholder(x: float, y: float, width: float, height: float) |
| ![Conteúdo (Vertical)](contentV.png) | add_vertical_content_placeholder(x: float, y: float, width: float, height: float) |
| ![Texto](text.png) | add_text_placeholder(x: float, y: float, width: float, height: float) |
| ![Texto (Vertical)](textV.png) | add_vertical_text_placeholder(x: float, y: float, width: float, height: float) |
| ![Imagem](picture.png) | add_picture_placeholder(x: float, y: float, width: float, height: float) |
| ![Gráfico](chart.png) | add_chart_placeholder(x: float, y: float, width: float, height: float) |
| ![Tabela](table.png) | add_table_placeholder(x: float, y: float, width: float, height: float) |
| ![SmartArt](smartart.png) | add_smart_art_placeholder(x: float, y: float, width: float, height: float) |
| ![Mídia](media.png) | add_media_placeholder(x: float, y: float, width: float, height: float) |
| ![Imagem Online](onlineimage.png) | add_online_image_placeholder(x: float, y: float, width: float, height: float) |

O código Python a seguir demonstra como adicionar novas formas de espaço reservado ao slide de layout em branco:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Obter o slide de layout em branco.
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    # Obter o gerenciador de espaços reservados do slide de layout.
    placeholder_manager = layout.placeholder_manager

    # Adicionar diferentes espaços reservados ao slide de layout em branco.
    placeholder_manager.add_content_placeholder(20, 20, 310, 270)
    placeholder_manager.add_vertical_text_placeholder(350, 20, 350, 270)
    placeholder_manager.add_chart_placeholder(20, 310, 310, 180)
    placeholder_manager.add_table_placeholder(350, 310, 350, 180)

    # Adicionar um novo slide com o layout em branco.
    new_slide = presentation.slides.add_empty_slide(layout)

    presentation.save("placeholders.pptx", slides.export.SaveFormat.PPTX)
```

O resultado:

![The placeholders on the layout slide](add_placeholders.png)

## **Definir Visibilidade do Rodapé para um Layout de Slide**

Em apresentações PowerPoint, elementos de rodapé como data, número do slide e texto personalizado podem ser mostrados ou ocultados dependendo do layout do slide. O Aspose.Slides for Python permite controlar a visibilidade desses espaços reservados de rodapé. Isso é útil quando você deseja que determinados layouts exibam informações de rodapé enquanto outros permanecem limpos e minimalistas.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
2. Obtenha uma referência ao layout de slide pelo seu índice.
3. Defina o espaço reservado do rodapé do slide como visível.
4. Defina o espaço reservado do número do slide como visível.
5. Defina o espaço reservado da data/hora como visível.
6. Salve a apresentação.

O código Python a seguir mostra como definir a visibilidade do rodapé de um slide e executar tarefas relacionadas:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    header_footer_manager = presentation.layout_slides[0].header_footer_manager

    if not header_footer_manager.is_footer_visible: 
        header_footer_manager.set_footer_visibility(True) 

    if not header_footer_manager.is_slide_number_visible:  
        header_footer_manager.set_slide_number_visibility(True) 

    if not header_footer_manager.is_date_time_visible: 
        header_footer_manager.set_date_time_visibility(True)

    header_footer_manager.set_footer_text("Footer text") 
    header_footer_manager.set_date_time_text("Date and time text") 

    presentation.save("output.ppt", slides.export.SaveFormat.PPT)
```

## **Definir Visibilidade do Rodapé Filho para um Slide**

Em apresentações PowerPoint, elementos de rodapé como data, número do slide e texto personalizado podem ser controlados no nível do slide mestre para garantir consistência em todos os layouts de slide. O Aspose.Slides for Python permite definir a visibilidade e o conteúdo desses espaços reservados de rodapé no slide mestre e propagar essas configurações a todos os layouts filhos. Essa abordagem garante informações de rodapé uniformes em toda a apresentação.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
2. Obtenha uma referência ao slide mestre pelo seu índice.
3. Defina os espaços reservados de rodapé do mestre e de todos os filhos como visíveis.
4. Defina os espaços reservados de número do slide do mestre e de todos os filhos como visíveis.
5. Defina os espaços reservados de data/hora do mestre e de todos os filhos como visíveis.
6. Salve a apresentação.

O código Python a seguir demonstra essa operação:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    header_footer_manager = presentation.masters[0].header_footer_manager

    header_footer_manager.set_footer_and_child_footers_visibility(True)
    header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
    header_footer_manager.set_date_time_and_child_date_times_visibility(True)

    header_footer_manager.set_footer_and_child_footers_text("Footer text")
    header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Perguntas Frequentes**

**Qual a diferença entre um slide mestre e um layout de slide?**

Um slide mestre define o tema geral e a formatação padrão, enquanto os layouts de slide definem arranjos específicos de espaços reservados para diferentes tipos de conteúdo.

**Posso copiar um layout de slide de uma apresentação para outra?**

Sim, você pode clonar um layout de slide da coleção [layout_slides](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/layout_slides/) de uma apresentação e inseri‑lo em outra usando o método `add_clone`.

**O que acontece se eu excluir um layout de slide que ainda está sendo usado por um slide?**

Se você tentar excluir um layout de slide que ainda é referenciado por pelo menos um slide na apresentação, o Aspose.Slides lançará uma [PptxEditException](https://reference.aspose.com/slides/pt/python-net/aspose.slides/pptxeditexception/). Para evitar isso, use [remove_unused_layout_slides](https://reference.aspose.com/slides/pt/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) que remove com segurança apenas os layouts de slide que não estão em uso.