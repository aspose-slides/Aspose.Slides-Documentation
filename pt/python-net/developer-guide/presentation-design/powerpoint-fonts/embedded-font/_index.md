---
title: Incorporar fontes em apresentações com Python
linktitle: Incorporando Fonte
type: docs
weight: 40
url: /pt/python-net/embedded-font/
keywords:
- adicionar fonte
- incorporar fonte
- incorporação de fonte
- obter fonte incorporada
- adicionar fonte incorporada
- remover fonte incorporada
- compactar fonte incorporada
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Incorpore fontes TrueType em apresentações PowerPoint e OpenDocument com Aspose.Slides para Python via .NET, garantindo renderização precisa em todas as plataformas."
---
## **Introdução**

**Incorporar fontes no PowerPoint** garante que sua apresentação mantenha a aparência pretendida em diferentes sistemas. Seja usando fontes exclusivas para criatividade ou fontes padrão, incorporar fontes impede interrupções de texto e layout.

Se você usou uma fonte de terceiros ou não padrão porque se tornou criativo com seu trabalho, então tem ainda mais razões para incorporar sua fonte. Caso contrário (sem fontes incorporadas), os textos ou números nos seus slides, o layout, a estilização, etc. podem mudar ou se transformar em retângulos confusos.

Utilize as classes [FontsManager](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fontsmanager/), [FontData](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fontdata/), e [Compress](https://reference.aspose.com/slides/pt/python-net/aspose.slides.lowcode/compress/) para gerenciar fontes incorporadas.

## **Obter e Remover Fontes Incorporadas**

Recupere ou remova fontes incorporadas de uma apresentação de forma simples com os métodos [get_embedded_fonts](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) e [remove_embedded_font](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fontsmanager/remove_embedded_font/).

Este código Python mostra como obter e remover fontes incorporadas de uma apresentação:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanciar a classe Presentation que representa um arquivo de apresentação.
with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    slide = presentation.slides[0]

    # Renderizar o slide que contém um quadro de texto que usa a fonte incorporada 'FunSized'.
    with slide.get_image(draw.Size(960, 720)) as image:
        image.save("picture1_out.png", slides.ImageFormat.PNG)

    fonts_manager = presentation.fonts_manager

    # Obter todas as fontes incorporadas.
    embedded_fonts = fonts_manager.get_embedded_fonts()

    # Encontrar a fonte 'Calibri'.
    font_data = list(filter(lambda data : data.font_name == "Calibri", embedded_fonts))[0]

    # Remover a fonte 'Calibri'.
    fonts_manager.remove_embedded_font(font_data)

    # Renderizar o slide; a fonte 'Calibri' será substituída por uma existente.
    with slide.get_image(draw.Size(960, 720)) as image:
        image.save("picture2_out.png", slides.ImageFormat.PNG)

    # Salvar a apresentação sem a fonte incorporada 'Calibri' no disco.
    presentation.save("WithoutEmbeddedFonts.ppt", slides.export.SaveFormat.PPT)
```

## **Adicionar Fontes Incorporadas**

Usando o enum [EmbedFontCharacters](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/embedfontcharacters/) e duas sobrecargas do método [add_embedded_font](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fontsmanager/add_embedded_font/), você pode selecionar sua regra (de incorporação) preferida para incorporar as fontes em uma apresentação. Este código Python mostra como incorporar e adicionar fontes a uma apresentação:

```python
import aspose.slides as slides

# Carregar uma apresentação.
with slides.Presentation("Fonts.pptx") as presentation:
    all_fonts = presentation.fonts_manager.get_fonts()
    embedded_fonts = presentation.fonts_manager.get_embedded_fonts()

    for font in all_fonts:
        if font not in embedded_fonts:
            presentation.fonts_manager.add_embedded_font(font, slides.export.EmbedFontCharacters.ALL)

    # Salvar a apresentação no disco.
    presentation.save("AddEmbeddedFont.pptx", slides.export.SaveFormat.PPTX)
```

## **Comprimir Fontes Incorporadas**

Otimize o tamanho do arquivo comprimindo fontes incorporadas usando [compress_embedded_fonts](https://reference.aspose.com/slides/pt/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/).

Exemplo de código para compressão:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.compress_embedded_fonts(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Como posso saber que uma fonte específica na apresentação ainda será substituída durante a renderização, apesar de estar incorporada?**

Verifique as [informações de substituição](/slides/pt/python-net/font-substitution/) no gerenciador de fontes e as [regras de fallback/substituição](/slides/pt/python-net/fallback-font/): se a fonte estiver indisponível ou restrita, um fallback será usado.

**Vale a pena incorporar fontes “do sistema” como Arial/Calibri?**

Normalmente não – elas quase sempre estão disponíveis. Mas para total portabilidade em ambientes “leves” (Docker, um servidor Linux sem fontes pré‑instaladas), incorporar fontes do sistema pode eliminar o risco de substituições inesperadas.