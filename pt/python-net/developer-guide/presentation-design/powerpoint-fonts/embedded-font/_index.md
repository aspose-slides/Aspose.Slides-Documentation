---
title: Incorporar fontes em apresentações com Python
linktitle: Fontes incorporadas
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
- apresentação
- Python
- Aspose.Slides
description: "Gerencie fontes incorporadas no PowerPoint com Aspose.Slides para Python via .NET. Use Python para adicionar, recuperar, remover e compactar fontes para preservar a aparência do texto e reduzir o tamanho do arquivo."
---
## **Introdução**

Incorporar fontes armazena os dados de fonte dentro de uma apresentação PowerPoint. Quando um visualizador suporta fontes incorporadas, ele pode exibir o texto usando essas fontes mesmo que não estejam instaladas no sistema de destino. Isso ajuda a preservar quebras de linha, espaçamento do texto e layout dos slides.

O Aspose.Slides for Python via .NET permite recuperar, adicionar e remover fontes incorporadas através da propriedade [fonts_manager](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/fonts_manager/) de um objeto [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/). Você também pode reduzir o tamanho dos dados das fontes incorporadas removendo caracteres que a apresentação não usa.

Os exemplos abaixo funcionam com arquivos PPTX. Antes de incorporar uma fonte, certifique-se de que os dados da fonte estejam disponíveis para o Aspose.Slides e que sua licença permita a incorporação.

## **Obter e Remover Fontes Incorporadas**

Use [get_embedded_fonts](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) para listar as fontes armazenadas em uma apresentação. Para remover uma, passe uma fonte dessa lista para [remove_embedded_font](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fontsmanager/remove_embedded_font/) e, em seguida, salve a apresentação.

O exemplo a seguir lista as fontes incorporadas em `EmbeddedFonts.pptx` e remove a Calibri se ela estiver presente:
```python
import aspose.slides as slides

with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    fonts_manager = presentation.fonts_manager
    embedded_fonts = fonts_manager.get_embedded_fonts()

    for font in embedded_fonts:
        print(font.font_name)

    font_to_remove = next((font for font in embedded_fonts if font.font_name.casefold() == "calibri"), None)
    if font_to_remove is not None:
        fonts_manager.remove_embedded_font(font_to_remove)
        presentation.save("WithoutEmbeddedCalibri.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("Calibri is not embedded. No output file was created.")
```

Remover uma fonte incorporada elimina seus dados de fonte armazenados; isso não altera a fonte atribuída ao texto. Se a fonte estiver instalada no sistema de destino, o texto ainda pode usá‑la. Caso contrário, a renderização pode exigir [font substitution](/slides/pt/python-net/font-substitution/), o que pode afetar o layout.

## **Inspecionar Dados de Fonte e Permissões de Incorporação**

Use a classe [FontsManager](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fontsmanager/) para inspecionar fontes antes de incorporá‑las. Chame [get_fonts](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fontsmanager/get_fonts/) para recuperar as fontes usadas na apresentação. Para cada fonte, passe um objeto [FontData](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fontdata/) e o valor requerido de [FontStyleType](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fontstyletype/) para [get_font_bytes](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fontsmanager/get_font_bytes/). O método retorna os dados binários daquele estilo de fonte, ou `None` quando a fonte ou o estilo solicitado não está disponível. Não passe um resultado `None` para [get_font_embedding_level](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fontsmanager/get_font_embedding_level/), pois esse método requer um array de bytes.

O [EmbeddingLevel](https://reference.aspose.com/slides/pt/python-net/aspose.slides/embeddinglevel/) é uma enumeração de flags que relata as restrições de incorporação armazenadas na fonte:

- `INSTALLABLE` permite a incorporação e instalação permanente em outro sistema, sujeito à licença da fonte.
- `RESTRICTED` proíbe a incorporação, a menos que seja obtida permissão do proprietário legal da fonte quando for a única flag de permissão de uso.
- `PREVIEW_PRINT` permite uso temporário para visualização e impressão; um documento contendo a fonte deve ser somente-leitura.
- `EDITABLE` permite uso temporário e permite que o documento seja editado e salvo.
- `NO_SUBSETTING` é uma restrição adicional que proíbe a incorporação de apenas um subconjunto dos glifos. Incorpore todos os caracteres quando essa flag estiver presente.
- `BITMAP_ONLY` é uma restrição adicional que permite apenas a incorporação de bitmaps, não de dados de contorno. Se a fonte não possuir bitmaps, não pode ser incorporada.

Os quatro primeiros valores descrevem a permissão de uso, enquanto `NO_SUBSETTING` e `BITMAP_ONLY` podem ser combinados com eles. Verifique os modificadores usando operações bit-a-bit. Como `INSTALLABLE` é zero, masque os bits de permissão de uso e compare o resultado com `INSTALLABLE`. As fontes atuais devem definir no máximo um bit de permissão de uso. Para compatibilidade com fontes mais antigas que definem mais de um, o auxiliar abaixo seleciona a permissão menos restritiva: `EDITABLE`, depois `PREVIEW_PRINT`, depois `RESTRICTED`.

O exemplo a seguir audita os dados regular, negrito, itálico e negrito‑itálico disponíveis para cada fonte retornada por `get_fonts`. Ele ignora estilos indisponíveis, fontes restritas, fontes somente-bitmap, fontes limitadas a visualização e impressão porque a saída permanece editável, e fontes que já estão incorporadas. Se algum estilo disponível possuir `NO_SUBSETTING`, ele incorpora todos os caracteres para aquela família de fontes.
```python
import aspose.slides as slides


def get_usage_permission(level):
    permission_mask = slides.EmbeddingLevel.RESTRICTED | slides.EmbeddingLevel.PREVIEW_PRINT | slides.EmbeddingLevel.EDITABLE
    permissions = level & permission_mask

    if permissions & slides.EmbeddingLevel.EDITABLE:
        return slides.EmbeddingLevel.EDITABLE

    if permissions & slides.EmbeddingLevel.PREVIEW_PRINT:
        return slides.EmbeddingLevel.PREVIEW_PRINT

    if permissions & slides.EmbeddingLevel.RESTRICTED:
        return slides.EmbeddingLevel.RESTRICTED

    return slides.EmbeddingLevel.INSTALLABLE


with slides.Presentation("Fonts.pptx") as presentation:
    fonts_manager = presentation.fonts_manager
    font_styles = [slides.FontStyleType.REGULAR, slides.FontStyleType.BOLD, slides.FontStyleType.ITALIC, slides.FontStyleType.BOLD | slides.FontStyleType.ITALIC]

    embedded_font_names = {font.font_name.casefold() for font in fonts_manager.get_embedded_fonts()}

    embedding_plan = []
    for font in fonts_manager.get_fonts():
        if font.font_name.casefold() in embedded_font_names:
            print(f"{font.font_name}: already embedded.")
            continue

        has_available_data = False
        all_available_styles_can_be_embedded = True
        preview_print_only = False
        requires_full_font = False

        for font_style in font_styles:
            font_bytes = fonts_manager.get_font_bytes(font, font_style)
            if font_bytes is None:
                print(f"{font.font_name} ({font_style}): font data is unavailable.")
                continue

            has_available_data = True
            embedding_level = fonts_manager.get_font_embedding_level(font_bytes, font.font_name)
            usage_permission = get_usage_permission(embedding_level)
            no_subsetting = bool(embedding_level & slides.EmbeddingLevel.NO_SUBSETTING)
            bitmap_only = bool(embedding_level & slides.EmbeddingLevel.BITMAP_ONLY)

            requires_full_font |= no_subsetting
            preview_print_only |= usage_permission == slides.EmbeddingLevel.PREVIEW_PRINT
            all_available_styles_can_be_embedded &= usage_permission != slides.EmbeddingLevel.RESTRICTED and not bitmap_only

            print(f"{font.font_name} ({font_style}): {embedding_level}.")

        if not has_available_data:
            print(f"{font.font_name}: skipped because no requested style is available.")
        elif not all_available_styles_can_be_embedded:
            print(f"{font.font_name}: skipped because at least one available style does not permit outline embedding.")
        elif preview_print_only:
            print(f"{font.font_name}: skipped because this example produces an editable presentation.")
        else:
            rule = slides.export.EmbedFontCharacters.ALL if requires_full_font else slides.export.EmbedFontCharacters.ONLY_USED
            embedding_plan.append((font, rule))

    for font, rule in embedding_plan:
        fonts_manager.add_embedded_font(font, rule)

    presentation.save("WithAuditedFonts.pptx", slides.export.SaveFormat.PPTX)
```

Esta inspeção relata as restrições codificadas em cada arquivo de fonte. Ela não concede uma licença, não prova que você obteve a fonte legalmente, nem substitui a verificação do contrato de licença da fonte antes de distribuir uma cópia incorporada.

## **Adicionar Fontes Incorporadas**

Use [add_embedded_font](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fontsmanager/add_embedded_font/) para incorporar uma fonte. Seus overloads aceitam um objeto [FontData](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fontdata/) ou um array de bytes contendo os dados da fonte. A enumeração [EmbedFontCharacters](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/embedfontcharacters/) controla quais caracteres são incluídos:

- [ALL](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/embedfontcharacters/) incorpora todos os caracteres da fonte. Use esta opção quando os destinatários precisarem editar a apresentação e inserir novo texto.
- [ONLY_USED](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/embedfontcharacters/) incorpora somente os caracteres usados na apresentação para reduzir o tamanho do arquivo. Escolha esta opção para uma apresentação final que é principalmente destinada à visualização.

O exemplo a seguir usa [get_fonts](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fontsmanager/get_fonts/) para recuperar as fontes usadas em `Fonts.pptx` e incorpora aquelas que ainda não estão incorporadas. As fontes a serem adicionadas devem estar disponíveis na máquina que executa o código. As fontes já incorporadas mantêm seus conjuntos de caracteres atuais.
```python
import aspose.slides as slides

with slides.Presentation("Fonts.pptx") as presentation:
    fonts_manager = presentation.fonts_manager
    all_fonts = fonts_manager.get_fonts()
    embedded_fonts = fonts_manager.get_embedded_fonts()
    embedded_names = {font.font_name.casefold() for font in embedded_fonts}

    for font in all_fonts:
        normalized_name = font.font_name.casefold()
        if normalized_name not in embedded_names:
            fonts_manager.add_embedded_font(font, slides.export.EmbedFontCharacters.ALL)
            embedded_names.add(normalized_name)

    presentation.save("WithEmbeddedFonts.pptx", slides.export.SaveFormat.PPTX)
```

## **Compactar Fontes Incorporadas**

[compress_embedded_fonts](https://reference.aspose.com/slides/pt/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) reduz os dados de fontes incorporadas removendo caracteres não usados. Ele opera em fontes que já estão incorporadas, portanto a redução de tamanho depende da quantidade de dados de fonte não utilizados que a apresentação contém.

O exemplo a seguir compacta as fontes em `EmbeddedFonts.pptx` e salva o resultado como um arquivo separado:
```python
import aspose.slides as slides

with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    slides.lowcode.Compress.compress_embedded_fonts(presentation)
    presentation.save("CompressedEmbeddedFonts.pptx", slides.export.SaveFormat.PPTX)
```

Mantenha o arquivo original se os destinatários puderem precisar adicionar texto posteriormente. Os caracteres removidos durante a compactação não ficam mais disponíveis na fonte incorporada, mesmo que você tenha originalmente incorporado todos os caracteres.

## **FAQ**

**Como posso verificar se uma fonte incorporada ainda será substituída durante a renderização?**

Chame [get_substitutions](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fontsmanager/get_substitutions/) no ambiente onde você renderiza a apresentação para ver quais fontes o Aspose.Slides substituirá. Também verifique as configurações de [font substitution](/slides/pt/python-net/font-substitution/) e as regras de [font fallback](/slides/pt/python-net/fallback-font/). O fallback lida com caracteres ausentes, portanto, incorporar uma fonte não resolve caracteres que a própria fonte não contém.

**Devo incorporar fontes comuns como Arial e Calibri?**

Baseie a decisão no ambiente de destino. Se as fontes necessárias estiverem disponíveis em todas as máquinas que abrem ou renderizam a apresentação, incorporá‑las pode acrescentar tamanho de arquivo desnecessário. Se os destinatários ou servidores puderem não ter essas fontes, incorporá‑las pode ajudar a preservar a aparência pretendida, desde que suas licenças permitam.