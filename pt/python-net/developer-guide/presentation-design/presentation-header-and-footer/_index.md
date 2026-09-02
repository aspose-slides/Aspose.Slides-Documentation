---
title: Gerenciar cabeçalhos e rodapés de apresentação com Python
linktitle: Cabeçalho e Rodapé
type: docs
weight: 140
url: /pt/python-net/presentation-header-and-footer/
keywords:
- cabeçalho
- texto do cabeçalho
- rodapé
- texto do rodapé
- definir cabeçalho
- definir rodapé
- folheto
- anotações
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Aprenda como gerenciar marcadores de espaço de rodapé, data/hora, número de slide e cabeçalho em slides, páginas de anotações e folhetos com Aspose.Slides para Python via .NET."
---
## **Visão geral**

O PowerPoint usa diferentes marcadores de espaço de cabeçalho e rodapé dependendo do tipo de página. Aspose.Slides for Python via .NET permite controlar o texto e a visibilidade desses marcadores de espaço por meio de classes de gerenciador de cabeçalho/rodapé.

Os marcadores de espaço disponíveis dependem do escopo:

| Escopo | Cabeçalho | Rodapé | Data/hora | Número do slide/página |
|---|---|---|---|---|
| Slide regular | Não | Sim | Sim | Sim |
| Mestre de anotações | Sim | Sim | Sim | Sim |
| Slide de anotações | Sim | Sim | Sim | Sim |
| Mestre de folhetos | Sim | Sim | Sim | Sim |

Um slide regular de apresentação não possui um marcador de espaço de cabeçalho. Cabeçalhos estão disponíveis em páginas de notas e folhetos. Para slides regulares, use os marcadores de espaço de rodapé, data/hora e número do slide.

O escopo de uma alteração depende do gerenciador que você usar. A classe [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slideheaderfootermanager/) controla um slide regular. A classe [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/python-net/aspose.slides/notesslideheaderfootermanager/) controla um slide de notas. Gerenciadores de mestre e layout também podem propagar configurações para slides dependentes, enquanto a classe [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/python-net/aspose.slides/masterhandoutslideheaderfootermanager/) controla o mestre de folhetos.

## **Definir rodapé, data/hora e números de slide em slides regulares**

Para slides regulares, o fluxo básico é acessar o gerenciador de cabeçalho/rodapé de cada slide, definir o texto do rodapé e da data/hora, habilitar os marcadores de espaço necessários e salvar a apresentação. Os números de slide são gerados pela apresentação, portanto você só precisa controlar sua visibilidade.

Use [`set_footer_text`](https://reference.aspose.com/slides/pt/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_text/) e [`set_date_time_text`](https://reference.aspose.com/slides/pt/python-net/aspose.slides/baseslideheaderfootermanager/set_date_time_text/) para definir texto, e use [`set_footer_visibility`](https://reference.aspose.com/slides/pt/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_visibility/), [`set_date_time_visibility`](https://reference.aspose.com/slides/pt/python-net/aspose.slides/baseslideheaderfootermanager/set_date_time_visibility/), e [`set_slide_number_visibility`](https://reference.aspose.com/slides/pt/python-net/aspose.slides/baseslideheaderfootermanager/set_slide_number_visibility/) para mostrar os marcadores de espaço correspondentes.

O exemplo completo a seguir aplica o mesmo rodapé, texto de data/hora e visibilidade de número de slide a todos os slides regulares:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        header_footer_manager = slide.header_footer_manager

        header_footer_manager.set_footer_text("Company Confidential")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_slide_footers.pptx", slides.export.SaveFormat.PPTX)
```

Se precisar atualizar apenas um slide, acesse esse slide diretamente através da coleção [`slides`](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/slides/pt/) em vez de iterar por toda a coleção.

## **Definir cabeçalhos e rodapés no mestre de notas**

O mestre de notas define a formatação comum e o comportamento dos marcadores de espaço nas páginas de notas. Use a classe [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/python-net/aspose.slides/masternotesslideheaderfootermanager/) quando quiser alterar apenas o próprio mestre de notas.

O exemplo a seguir define cabeçalho, rodapé e texto de data/hora no mestre de notas e torna todos os marcadores de espaço suportados visíveis nesse mestre:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        header_footer_manager.set_header_text("Notes header")
        header_footer_manager.set_header_visibility(True)

        header_footer_manager.set_footer_text("Notes footer")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_notes_master_footers.pptx", slides.export.SaveFormat.PPTX)
```

Uma apresentação pode não conter um mestre de notas, portanto verifique o valor retornado para `None` antes de alterá‑lo.

## **Aplicar configurações do mestre de notas a slides de notas filhos**

Um mestre de notas pode aplicar configurações de cabeçalho e rodapé a si mesmo e a todos os slides de notas dependentes. Use os métodos de propagação dedicados em [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/python-net/aspose.slides/masternotesslideheaderfootermanager/) quando as mesmas configurações devem ser aplicadas em toda a hierarquia de notas.

Por exemplo, [`set_header_and_child_headers_text`](https://reference.aspose.com/slides/pt/python-net/aspose.slides/masternotesslideheaderfootermanager/set_header_and_child_headers_text/) e [`set_header_and_child_headers_visibility`](https://reference.aspose.com/slides/pt/python-net/aspose.slides/masternotesslideheaderfootermanager/set_header_and_child_headers_visibility/) atualizam o cabeçalho do mestre de notas e todos os cabeçalhos filhos. Métodos equivalentes estão disponíveis para rodapés, data/hora e números de slide.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        header_footer_manager.set_header_and_child_headers_text("Notes header")
        header_footer_manager.set_header_and_child_headers_visibility(True)

        header_footer_manager.set_footer_and_child_footers_text("Notes footer")
        header_footer_manager.set_footer_and_child_footers_visibility(True)

        header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")
        header_footer_manager.set_date_time_and_child_date_times_visibility(True)

        header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)

    presentation.save("presentation_with_child_notes_footers.pptx", slides.export.SaveFormat.PPTX)
```

Os métodos de propagação usados acima são [`set_footer_and_child_footers_text`](https://reference.aspose.com/slides/pt/python-net/aspose.slides/masternotesslideheaderfootermanager/set_footer_and_child_footers_text/), [`set_footer_and_child_footers_visibility`](https://reference.aspose.com/slides/pt/python-net/aspose.slides/masternotesslideheaderfootermanager/set_footer_and_child_footers_visibility/), [`set_date_time_and_child_date_times_text`](https://reference.aspose.com/slides/pt/python-net/aspose.slides/masternotesslideheaderfootermanager/set_date_time_and_child_date_times_text/), [`set_date_time_and_child_date_times_visibility`](https://reference.aspose.com/slides/pt/python-net/aspose.slides/masternotesslideheaderfootermanager/set_date_time_and_child_date_times_visibility/), e [`set_slide_number_and_child_slide_numbers_visibility`](https://reference.aspose.com/slides/pt/python-net/aspose.slides/masternotesslideheaderfootermanager/set_slide_number_and_child_slide_numbers_visibility/).

## **Definir cabeçalhos e rodapés em um slide de notas individual**

Um slide de notas pertence a um slide regular específico. Use a classe [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/python-net/aspose.slides/notesslideheaderfootermanager/) quando quiser personalizar apenas essa página de notas.

O método [`add_notes_slide`](https://reference.aspose.com/slides/pt/python-net/aspose.slides/notesslidemanager/add_notes_slide/) retorna o slide de notas para o slide atual e cria um caso não exista. O exemplo a seguir configura a página de notas associada ao primeiro slide da apresentação:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    notes_slide = presentation.slides[0].notes_slide_manager.add_notes_slide()
    header_footer_manager = notes_slide.header_footer_manager

    header_footer_manager.set_header_text("Header for the first notes page")
    header_footer_manager.set_header_visibility(True)

    header_footer_manager.set_footer_text("Footer for the first notes page")
    header_footer_manager.set_footer_visibility(True)

    header_footer_manager.set_date_time_text("Date and time text")
    header_footer_manager.set_date_time_visibility(True)

    header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_custom_notes_footers.pptx", slides.export.SaveFormat.PPTX)
```

Se primeiro propagar configurações do mestre de notas e depois alterar um slide de notas individual, as configurações posteriores por slide permitem personalizar essa página de notas de forma independente.

## **Definir cabeçalhos e rodapés no mestre de folhetos**

Páginas de folhetos usam o mestre de folhetos para seus marcadores de espaço de cabeçalho, rodapé, data/hora e número de página. Diferente das páginas de notas, as configurações de folhetos são gerenciadas através do mestre de folhetos e não por slides de folhetos individuais.

Use a propriedade [`master_handout_slide`](https://reference.aspose.com/slides/pt/python-net/aspose.slides/imasterhandoutslidemanager/master_handout_slide/) para acessar o mestre de folhetos. Se ele não estiver presente, chame [`set_default_master_handout_slide`](https://reference.aspose.com/slides/pt/python-net/aspose.slides/imasterhandoutslidemanager/set_default_master_handout_slide/) para criar o mestre de folhetos padrão.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_handout_slide = presentation.master_handout_slide_manager.master_handout_slide

    if master_handout_slide is None:
        presentation.master_handout_slide_manager.set_default_master_handout_slide()
        master_handout_slide = presentation.master_handout_slide_manager.master_handout_slide

    if master_handout_slide is not None:
        header_footer_manager = master_handout_slide.header_footer_manager

        header_footer_manager.set_header_text("Handout header")
        header_footer_manager.set_header_visibility(True)

        header_footer_manager.set_footer_text("Handout footer")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_handout_footers.pptx", slides.export.SaveFormat.PPTX)
```

## **Compreender escopo e herança**

Escolha o gerenciador de cabeçalho/rodapé que corresponde ao escopo que deseja alterar:

- [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slideheaderfootermanager/) altera as configurações de rodapé, data/hora e número de slide para um slide regular.
- [`LayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/python-net/aspose.slides/layoutslideheaderfootermanager/) controla um slide de layout e pode propagar configurações suportadas para slides dependentes.
- [`MasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/python-net/aspose.slides/masterslideheaderfootermanager/) controla um mestre de slide regular e pode propagar configurações suportadas para slides dependentes.
- [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/python-net/aspose.slides/masternotesslideheaderfootermanager/) controla o mestre de notas e pode propagar configurações para todos os slides de notas dependentes.
- [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/python-net/aspose.slides/notesslideheaderfootermanager/) altera um slide de notas e suporta um marcador de espaço de cabeçalho além de rodapé, data/hora e número de slide.
- [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/python-net/aspose.slides/masterhandoutslideheaderfootermanager/) altera o mestre de folhetos e suporta os quatro tipos de marcadores de espaço.

Use a propagação a partir de um mestre ou layout quando a mesma configuração deve ser aplicada em toda a hierarquia. Use um gerenciador de slide individual ou de slide de notas quando precisar de uma configuração local para uma única página.

## **Perguntas frequentes**

**Posso adicionar um cabeçalho a um slide regular?**

Não. O PowerPoint não define um marcador de espaço de cabeçalho para slides regulares. Em slides regulares, use os marcadores de espaço de rodapé, data/hora e número de slide. Marcadores de espaço de cabeçalho estão disponíveis em páginas de notas e folhetos.

**E se um marcador de espaço de rodapé, data/hora ou número de slide não estiver visível?**

Use o gerenciador de cabeçalho/rodapé correspondente para verificar sua visibilidade e habilitá‑lo quando necessário. Por exemplo, [`is_footer_visible`](https://reference.aspose.com/slides/pt/python-net/aspose.slides/baseslideheaderfootermanager/is_footer_visible/) informa se um marcador de espaço de rodapé está presente, e [`set_footer_visibility`](https://reference.aspose.com/slides/pt/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_visibility/) altera sua visibilidade.

**Como iniciar a numeração de slides a partir de um valor diferente de 1?**

Defina a propriedade [`first_slide_number`](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/first_slide_number/) da apresentação. Os marcadores de espaço de número de slide então usarão a sequência de numeração atualizada.

**O que acontece com cabeçalhos e rodapés ao exportar para PDF, imagens ou HTML?**

Elementos de cabeçalho e rodapé visíveis são renderizados juntamente com o restante do conteúdo da apresentação no formato de saída. Sua aparência depende do tipo de página exportada e das configurações de visibilidade dos marcadores de espaço correspondentes.