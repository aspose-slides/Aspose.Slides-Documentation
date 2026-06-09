---
title: Gerenciar cabeçalhos e rodapés da apresentação com Python
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
- apresentação
- Python
- Aspose.Slides
description: "Use o Aspose.Slides para Python via .NET para adicionar e personalizar cabeçalhos e rodapés em apresentações PowerPoint e OpenDocument, proporcionando um visual profissional."
---
## **Visão geral**

O Aspose.Slides for Python permite controlar os marcadores de cabeçalho e rodapé em toda a apresentação com escopo preciso. O texto do rodapé, data/hora e números de slides são gerenciados a partir do nível mestre e podem ser aplicados globalmente ou ajustados por slide. Os cabeçalhos são suportados em anotações e folhetos, onde você pode alternar a visibilidade e definir o texto para cabeçalho, rodapé, data/hora e números de página através do gerenciador dedicado de cabeçalho e rodapé no slide mestre de anotações ou em slides de anotações individuais. Este artigo descreve os principais padrões para atualizar esses marcadores e propagar as alterações de forma consistente em todo o seu conjunto de slides.

## **Gerenciar texto de cabeçalho e rodapé**

Nesta seção, você aprenderá como gerenciar o conteúdo de cabeçalho e rodapé em uma apresentação — habilitar ou modificar o rodapé, data e hora, e números de slides. Descreveremos brevemente os escopos para aplicar essas configurações (toda a apresentação, slides individuais e visualizações de anotações/folhetos) e mostraremos como usar a API do Aspose.Slides para atualizá-los de forma rápida e consistente.

O exemplo de código abaixo abre uma apresentação, habilita e define o texto do rodapé, atualiza o texto do cabeçalho no slide mestre de anotações e salva o arquivo.

```py
import aspose.slides as slides

# Função para definir o texto do cabeçalho.
def update_header_footer_text(master):
    for shape in master.shapes:
        if shape.placeholder is not None:
            if shape.placeholder.type == slides.PlaceholderType.HEADER:
                shape.text_frame.text = "Hi, there is a header"


# Carregar a apresentação.
with slides.Presentation("sample.pptx") as presentation:
    # Definir o rodapé.
    presentation.header_footer_manager.set_all_footers_text("My Footer text")
    presentation.header_footer_manager.set_all_footers_visibility(True)

    # Acessar e atualizar o cabeçalho.
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        update_header_footer_text(master_notes_slide)

    # Salvar a apresentação.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Gerenciar cabeçalho e rodapé em slides de anotações**

Nesta seção, você aprenderá como gerenciar cabeçalhos e rodapés especificamente para slides de anotações no Aspose.Slides. Abordaremos a habilitação dos marcadores relevantes, a definição de texto para rodapés, data/hora e números de página, e a aplicação dessas alterações de forma consistente no mestre de anotações e nas páginas de anotações individuais.

Siga os passos abaixo:

1. Carregue um arquivo de apresentação.
1. Obtenha o slide mestre de anotações e seu [gerenciador de cabeçalho e rodapé](https://reference.aspose.com/slides/pt/python-net/aspose.slides/masternotesslideheaderfootermanager/).
1. No slide mestre de anotações, habilite a visibilidade de Cabeçalho, Rodapé, Número do slide e Data/hora para o mestre e todos os slides de anotações filhos.
1. No slide mestre de anotações, defina o texto para Cabeçalho, Rodapé e Data/hora para o mestre e todos os slides de anotações filhos.
1. Obtenha o slide de anotações para o primeiro slide da apresentação e seu [gerenciador de cabeçalho e rodapé](https://reference.aspose.com/slides/pt/python-net/aspose.slides/notesslideheaderfootermanager/).
1. Para este primeiro slide de anotações somente, garanta que Cabeçalho, Rodapé, Número do slide e Data/hora estejam visíveis (ative qualquer que esteja desativado).
1. Para este primeiro slide de anotações somente, defina o texto para Cabeçalho, Rodapé e Data/hora.
1. Salve a apresentação no formato PPTX.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        # Torne o slide mestre de anotações e todos os marcadores filhos de cabeçalho, rodapé, número do slide e data/hora visíveis.
        header_footer_manager.set_header_and_child_headers_visibility(True)
        header_footer_manager.set_footer_and_child_footers_visibility(True)
        header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
        header_footer_manager.set_date_time_and_child_date_times_visibility(True)

        # Defina o texto no slide mestre de anotações e em todos os marcadores filhos de cabeçalho, rodapé e data/hora.
        header_footer_manager.set_header_and_child_headers_text("Header text")
        header_footer_manager.set_footer_and_child_footers_text("Footer text")
        header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    # Altere as configurações de cabeçalho, rodapé, número do slide e data/hora apenas para o primeiro slide de anotações.
    notesSlide = presentation.slides[0].notes_slide_manager.notes_slide
    if notesSlide is not None:
        header_footer_manager = notesSlide.header_footer_manager

        # Garanta que os marcadores de cabeçalho, rodapé, número do slide e data/hora estejam visíveis.
        if not header_footer_manager.is_header_visible:
            header_footer_manager.set_header_visibility(True)

        if not header_footer_manager.is_footer_visible:
            header_footer_manager.set_footer_visibility(True)

        if not header_footer_manager.is_slide_number_visible:
            header_footer_manager.set_slide_number_visibility(True)

        if not header_footer_manager.is_date_time_visible:
            header_footer_manager.set_date_time_visibility(True)

        # Defina o texto nos marcadores de cabeçalho, rodapé e data/hora do slide de anotações.
        header_footer_manager.set_header_text("New header text")
        header_footer_manager.set_footer_text("New footer text")
        header_footer_manager.set_date_time_text("New date and time text")

    # Salvar a apresentação.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Perguntas frequentes**

**Posso adicionar um "cabeçalho" aos slides normais?**

No PowerPoint, “Cabeçalho” existe apenas para anotações e folhetos; nos slides normais, os elementos suportados são rodapé, data/hora e número do slide. No Aspose.Slides isso reflete as mesmas limitações: cabeçalho apenas para Anotações/Folhetos, e nos slides — Rodapé/DataHora/NúmeroDoSlide.

**E se o layout não contiver uma área de rodapé — posso “ativar” sua visibilidade?**

Sim. Verifique a visibilidade através do gerenciador de cabeçalho/rodapé e habilite-a se necessário. Esses indicadores e métodos da API foram projetados para casos em que o marcador está ausente ou oculto.

**Como faço para que o número do slide comece a partir de um valor diferente de 1?**

Defina o [primeiro número do slide](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/first_slide_number/) da apresentação; depois disso, toda a numeração será recalculada. Por exemplo, você pode iniciar em 0 ou 10 e ocultar o número no slide de título.

**O que acontece com cabeçalhos/rodapés ao exportar para PDF/imagens/HTML?**

Eles são renderizados como elementos de texto regulares da apresentação. Ou seja, se os elementos estiverem visíveis nos slides/páginas de anotações, também aparecerão no formato de saída juntamente com o restante do conteúdo.