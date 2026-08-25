---
title: Gerenciar quadros de imagem em apresentações com Python
linktitle: Quadro de Imagem
type: docs
weight: 10
url: /pt/python-net/picture-frame/
keywords:
- quadro de imagem
- adicionar quadro de imagem
- criar quadro de imagem
- imagem incorporada
- imagem vinculada
- extrair imagem
- imagem raster
- imagem SVG
- recortar imagem
- excluir áreas recortadas
- comprimir imagem
- StretchOffset
- formatação de quadro de imagem
- escala relativa
- efeito de imagem
- proporção
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Crie, formate, vincule, recorte, extraia e comprima quadros de imagem em apresentações com Aspose.Slides para Python via .NET."
---
## **Visão geral**

Um quadro de imagem é uma forma de slide que exibe uma imagem. No Aspose.Slides, o recurso de imagem e a forma que a exibe são objetos separados: uma [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) possui recursos de imagem incorporados através de sua [ImageCollection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/imagecollection/), enquanto um [PictureFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/pictureframe/) controla a posição, tamanho, formatação de linhas, rotação, recorte, efeitos de imagem e outras configurações ao nível do quadro.

Essa separação é útil quando a mesma imagem é mostrada mais de uma vez. Adicione a imagem à apresentação uma única vez, mantenha o [PPImage](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ppimage/) retornado e use esse recurso de imagem ao criar quadros de imagem.

Quadros de imagem podem conter imagens raster como PNG ou JPEG e imagens vetoriais SVG. Eles também podem referenciar imagens vinculadas em vez de armazenar os bytes da imagem na apresentação. A escolha afeta a portabilidade, o tamanho do arquivo, a extração e o comportamento de exportação, portanto é útil decidir como a imagem deve ser armazenada antes de aplicar formatação ou otimização.

## **Adicionar e formatar uma imagem incorporada**

Para uma imagem incorporada, adicione os dados da imagem à apresentação e crie um quadro de imagem com [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shapecollection/add_picture_frame/). A imagem torna‑se parte do pacote da apresentação, de modo que a apresentação permanece autocontida quando é movida para outro computador.

O exemplo a seguir adiciona uma imagem JPEG, cria um quadro nas dimensões nativas da imagem e aplica formatação de linha e rotação:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 100, image.width, image.height, image)
    picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
    picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
    picture_frame.line_format.width = 3
    picture_frame.rotation = 15

    presentation.save("picture-frame.pptx", slides.export.SaveFormat.PPTX)
```

O quadro de imagem controla a geometria exibida; mudar o tamanho do quadro não altera as dimensões de pixel originais armazenadas no recurso de imagem incorporado. Essa distinção torna‑se importante ao recortar ou compactar uma imagem posteriormente.

## **Usar escala relativa**

[PictureFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/pictureframe/) expõe [relative_scale_width](https://reference.aspose.com/slides/pt/python-net/aspose.slides/pictureframe/relative_scale_width/) e [relative_scale_height](https://reference.aspose.com/slides/pt/python-net/aspose.slides/pictureframe/relative_scale_height/) para o quadro. Um valor de `1.0` corresponde a 100 % do tamanho original da imagem. A escala relativa é útil quando um fluxo de trabalho precisa preservar uma relação com o tamanho da imagem de origem em vez de calcular as dimensões finais manualmente.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)
    picture_frame.relative_scale_width = 1.35
    picture_frame.relative_scale_height = 0.8

    presentation.save("relative-scale.pptx", slides.export.SaveFormat.PPTX)
```

A escala relativa altera as configurações de escala do quadro; ela não reamostra nem compacta a imagem incorporada.

## **Imagens incorporadas e vinculadas**

Uma imagem incorporada armazena os dados da imagem dentro da apresentação e, portanto, é a escolha mais segura para portabilidade e renderização previsível. Uma imagem vinculada armazena um local externo por meio do caminho de link [Picture](https://reference.aspose.com/slides/pt/python-net/aspose.slides/picture/) em vez de incorporar os dados da imagem da mesma forma.

Imagens vinculadas podem reduzir a quantidade de dados de imagem armazenados no PPTX, mas introduzem uma dependência externa. O arquivo vinculado deve permanecer acessível ao aplicativo que abre ou renderiza a apresentação. Se o caminho mudar, o arquivo for movido ou o recurso ficar indisponível, a imagem vinculada pode não ser exibida como esperado. Para apresentações que precisam ser enviadas por e‑mail, arquivadas ou renderizadas em ambientes isolados, imagens incorporadas são geralmente mais confiáveis.

### **Adicionar uma imagem vinculada**

O exemplo a seguir cria um quadro de imagem e aponta para um arquivo de imagem local. Ele trata apenas de vinculação de imagem; a vinculação de vídeo é um fluxo de mídia separado e intencionalmente não está misturada neste exemplo.

```python
import os
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 320, 180, None)
    linked_image_path = os.path.abspath("linked-image.jpg")
    picture_frame.picture_format.picture.link_path_long = linked_image_path

    presentation.save("linked-image.pptx", slides.export.SaveFormat.PPTX)
```

Use links quando o gerenciamento externo de arquivos for intencional. Não os use apenas como substituto para compressão: um PPTX pequeno com dependências de imagem quebradas costuma ser menos útil que uma apresentação maior e autocontida.

## **Extrair imagens de quadros de imagem**

Antes de extrair uma imagem de uma apresentação existente, verifique se uma forma é realmente um [PictureFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/pictureframe/) e se contém uma imagem incorporada. Quadros de imagem vinculados podem não conter bytes de imagem que possam ser extraídos da mesma forma.

### **Extrair uma imagem raster**

A API moderna de imagem usa [IImage](https://reference.aspose.com/slides/pt/python-net/aspose.slides/iimage/) diretamente. O exemplo a seguir encontra a primeira imagem raster incorporada em um slide e a salva como PNG:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, slides.PictureFrame):
            continue

        embedded_image = shape.picture_format.picture.image
        if embedded_image is None or embedded_image.svg_image is not None:
            continue

        raster_image = embedded_image.image
        raster_image.save("extracted-image.png", slides.ImageFormat.PNG)
        break
```

Salvar por meio de [IImage](https://reference.aspose.com/slides/pt/python-net/aspose.slides/iimage/) converte a imagem extraída para o formato de saída solicitado. Se precisar dos bytes codificados armazenados na apresentação em vez de um arquivo raster convertido, use a propriedade [PPImage.binary_data](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ppimage/binary_data/) .

### **Extrair uma imagem SVG**

Para uma imagem SVG, o [PPImage](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ppimage/) expõe um objeto [SvgImage](https://reference.aspose.com/slides/pt/python-net/aspose.slides/svgimage/). Isso permite recuperar os dados SVG diretamente em vez de rasterizar a imagem primeiro.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, slides.PictureFrame):
            continue

        embedded_image = shape.picture_format.picture.image
        svg_image = embedded_image.svg_image if embedded_image is not None else None
        if svg_image is None:
            continue

        svg_data = bytes(svg_image.svg_data)
        with open("extracted-image.svg", "wb") as svg_stream:
            svg_stream.write(svg_data)
        break
```

Manter o conteúdo SVG como SVG preserva a fonte vetorial dentro da apresentação. Exportações raster, como PNG ou JPEG, necessariamente renderizam esse conteúdo vetorial em pixels. A exportação de slide em PDF ou SVG também é uma operação de renderização, portanto os gráficos exportados não devem ser tratados como uma cópia byte‑a‑byte do SVG incorporado original; use o [SvgImage.svg_data](https://reference.aspose.com/slides/pt/python-net/aspose.slides/svgimage/svg_data/) incorporado quando o recurso vetorial original for necessário.

## **Recortar uma imagem**

O recorte altera a parte da imagem visível dentro do quadro. Os valores de recorte em [PictureFillFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides/picturefillformat/) são percentuais das dimensões da imagem de origem. O recorte não exclui inicialmente os pixels ocultos da imagem incorporada; ele apenas muda a região visível.

O exemplo a seguir encontra um quadro de imagem de forma segura e aplica valores de recorte:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        picture_frame.picture_format.crop_left = 23.6
        picture_frame.picture_format.crop_right = 21.5
        picture_frame.picture_format.crop_top = 3
        picture_frame.picture_format.crop_bottom = 31
        presentation.save("cropped-image.pptx", slides.export.SaveFormat.PPTX)
```

Como os dados de imagem ocultos ainda estão presentes, o recorte pode ser alterado posteriormente sem perder os pixels originais. Se o tamanho do arquivo for mais importante que a reversibilidade, as regiões recortadas podem ser removidas fisicamente como descrito na seção seguinte.

## **Remover dados de imagem recortados**

[PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/pt/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) remove os dados de imagem fora do retângulo de recorte atual e devolve o recurso de imagem resultante. Isso pode reduzir o tamanho do arquivo, mas é uma otimização destrutiva: depois que a apresentação é salva, os pixels removidos não ficam mais disponíveis para uma operação de “desrecorte” posterior.

```python
import aspose.slides as slides

with slides.Presentation("cropped-image.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()
        if cropped_image is not None:
            presentation.save("cropped-data-removed.pptx", slides.export.SaveFormat.PPTX)
```

O método pode adicionar um novo recurso de imagem à apresentação. Se a imagem original também for usada por outros quadros de imagem, esses quadros ainda precisarão do recurso existente, de modo que excluir áreas recortadas não reduz necessariamente o número total de imagens. Recortar conteúdo WMF ou EMF com este método rasteriza o resultado recortado para PNG.

## **Comprimir imagens raster**

[PictureFillFormat.compress_image](https://reference.aspose.com/slides/pt/python-net/aspose.slides/picturefillformat/compress_image/) reduz a resolução da imagem raster em relação ao tamanho em que a imagem é exibida. Também pode remover regiões recortadas na mesma operação. O método devolve `True` quando a imagem foi redimensionada ou recortada e `False` quando nenhuma alteração foi necessária.

Use um valor predefinido de [PicturesCompression](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/picturescompression/) quando uma resolução alvo padrão for suficiente:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        compressed = picture_frame.picture_format.compress_image(True, slides.export.PicturesCompression.DPI150)
        print("The image was compressed." if compressed else "No compression was necessary.")
        presentation.save("compressed-image.pptx", slides.export.SaveFormat.PPTX)
```

Um valor DPI positivo personalizado pode ser passado em vez de um valor enum quando um alvo específico for requerido.

A compressão destina‑se a imagens raster. SVG e conteúdo de metafile não são reduzidos por este fluxo de compressão raster. Também lembre‑se de que resolução mais baixa e regiões recortadas excluídas não podem ser recuperadas da apresentação otimizada. Escolha uma resolução alvo com base no maior tamanho em que a imagem será realmente visualizada ou exportada, em vez de aplicar o DPI mais baixo globalmente.

## **Gerenciar efeitos de transformação de imagem**

Para um fluxo de trabalho completo que cobre brilho, contraste, transformações de cor, desfoque, efeitos alfa, cadeias ordenadas, inspeção, remoção e verificação de ida‑e‑volta, veja [Image Transform Effects](/slides/pt/python-net/image-transform-effects/).

## **Bloquear a geometria do quadro de imagem**

As configurações de [PictureFrameLock](https://reference.aspose.com/slides/pt/python-net/aspose.slides/pictureframelock/) controlam quais operações de edição são desabilitadas para um quadro de imagem. Por exemplo, a propriedade [aspect_ratio_locked](https://reference.aspose.com/slides/pt/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) preserva as proporções da forma enquanto ela é redimensionada.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 100, image.width, image.height, image)
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("locked-picture-frame.pptx", slides.export.SaveFormat.PPTX)
```

O bloqueio aplica‑se à forma do quadro de imagem. Ele não força a imagem de origem a ser reamostrada ou permanentemente alterada para a mesma proporção.

## **Ajustar os valores StretchOffset**

Quando o modo de preenchimento da imagem é “stretch”, os valores de stretch‑offset em [PictureFillFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides/picturefillformat/) definem o retângulo de preenchimento relativo à caixa delimitadora do quadro de imagem. Percentuais positivos criam um recuo a partir de uma borda, enquanto percentuais negativos criam um extrusão.

Isso difere do recorte. Valores de recorte selecionam qual parte da imagem de origem fica visível; stretch offsets alteram o retângulo no qual o preenchimento da imagem visível é esticado.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 400, 300, image)
    picture_frame.picture_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    picture_frame.picture_format.stretch_offset_left = 12
    picture_frame.picture_format.stretch_offset_right = 12
    picture_frame.picture_format.stretch_offset_top = 8
    picture_frame.picture_format.stretch_offset_bottom = 8

    presentation.save("stretch-offsets.pptx", slides.export.SaveFormat.PPTX)
```

Use stretch offsets para posicionamento de preenchimento. Use propriedades de recorte quando o objetivo for ocultar as bordas da imagem de origem.

## **Armazenamento, tamanho de arquivo e considerações de exportação**

Os principais trade‑offs são mais fáceis de gerenciar quando o armazenamento de imagens e a formatação de quadros de imagem são tratados separadamente:

- **Imagens incorporadas** tornam a apresentação autocontida e são as mais confiáveis para compartilhamento e renderização no servidor, mas imagens raster grandes aumentam o tamanho do PPTX e o uso de memória.
- **Imagens vinculadas** podem manter o pacote menor, mas a apresentação depende de arquivos externos permanecendo disponíveis nos caminhos ou locais armazenados.
- **Recorte** é inicialmente não destrutivo. Os pixels ocultos permanecem incorporados até que áreas recortadas sejam explicitamente excluídas ou removidas durante a compressão.
- **Compressão** pode reduzir o tamanho do arquivo substancialmente para imagens raster excessivamente grandes, mas sacrifica a resolução original. Deve ser aplicada após o tamanho final da imagem no slide ser conhecido.
- **Imagens SVG** devem permanecer como SVG quando a preservação vetorial for importante. Extraia o SVG incorporado diretamente quando precisar do recurso vetorial em si. Exportações de slide raster sempre convertem o slide renderizado em pixels.
- **Imagens repetidas** devem reutilizar um recurso [PPImage](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ppimage/) existente sempre que possível, em vez de carregar o mesmo arquivo repetidamente no fluxo de trabalho da apresentação.

Para apresentações grandes, a otimização de imagens costuma ser mais eficaz quando feita seletivamente: mantenha logotipos e diagramas como conteúdo vetorial, comprima fotografias de acordo com seu tamanho real de exibição, remova pixels recortados apenas quando a edição posterior não for necessária e evite links externos, a menos que o gerenciamento de dependências faça parte do design de implantação.

## **Perguntas frequentes**

**Qual é a diferença entre um quadro de imagem e um recurso de imagem?**

Um [PPImage](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ppimage/) representa um recurso de imagem associado à apresentação. Um [PictureFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/pictureframe/) é uma forma em um slide que exibe uma imagem e armazena geometria e formatação ao nível do quadro, como tamanho, rotação, valores de recorte, efeitos e bloqueios.

**Devo incorporar ou vincular imagens?**

Incorpore imagens quando a apresentação precisar ser portátil, arquivada ou renderizada sem acesso a recursos externos. Vincule imagens apenas quando manter arquivos de imagem fora do PPTX for intencional e os locais externos puderem ser mantidos de forma confiável.

**O recorte reduz o tamanho do arquivo PPTX?**

Não por si só. Configurações normais de recorte ocultam partes da imagem de origem, mas mantêm os pixels subjacentes. Use [PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/pt/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) ou compressão de imagem com remoção de áreas recortadas quando esses pixels puderem ser descartados permanentemente.

**Posso restaurar a qualidade da imagem após a compressão?**

Não. A compressão pode reduzir a resolução raster armazenada, e a remoção de regiões recortadas descarta dados da imagem. Mantenha a imagem original fora da apresentação se edições de alta resolução posteriores forem necessárias.

**Como devo tratar imagens SVG?**

Mantenha o conteúdo SVG como SVG quando a fidelidade vetorial for importante. O [SvgImage](https://reference.aspose.com/slides/pt/python-net/aspose.slides/svgimage/) incorporado pode ser extraído diretamente. Renderizar um slide para um formato raster como PNG ou JPEG rasteriza o SVG como parte da imagem do slide.

**Como evitar casts inseguros ao ler slides existentes?**

Verifique o tipo da forma antes de usar membros específicos de quadro de imagem. Usar `isinstance(shape, slides.PictureFrame)` evita casts inválidos e permite que o código trate slides que não contêm quadros de imagem.