---
title: Adicionar Quadros de Imagem a Apresentações com Python
linktitle: Quadro de Imagem
type: docs
weight: 10
url: /pt/python-net/picture-frame/
keywords:
- quadro de imagem
- adicionar quadro de imagem
- criar quadro de imagem
- adicionar imagem
- criar imagem
- extrair imagem
- imagem raster
- imagem vetorial
- recortar imagem
- área recortada
- propriedade StretchOff
- formatação de quadro de imagem
- propriedades de quadro de imagem
- escala relativa
- efeito de imagem
- proporção do aspecto
- transparência da imagem
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Adicione quadros de imagem a apresentações PowerPoint e OpenDocument com Aspose.Slides para Python via .NET. Simplifique seu fluxo de trabalho e melhore o design dos slides."
---
## **Introdução**

Quadros de imagem no Aspose.Slides for Python permitem que você coloque e gerencie imagens raster e vetoriais como formas nativas dos slides. Você pode inserir imagens a partir de arquivos ou fluxos, posicioná‑las e redimensioná‑las com coordenadas precisas, aplicar rotação, definir transparência e controlar a ordem Z juntamente com outras formas. A API também oferece suporte ao recorte, manutenção de proporções, definição de bordas e efeitos, e substituição da imagem subjacente sem reconstruir o layout. Como os quadros de imagem se comportam como formas regulares, você pode adicionar animações, hyperlinks e texto alternativo, facilitando a criação de apresentações visualmente ricas e acessíveis.

## **Criar Quadros de Imagem**

Esta seção mostra como inserir uma imagem em um slide criando um [PictureFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/pictureframe/) com Aspose.Slides for Python. Você aprenderá como carregar a imagem, posicioná‑la precisamente no slide e controlar seu tamanho e formatação.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
2. Obtenha um slide pelo seu índice.
3. Crie um [PPImage](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ppimage/) adicionando a imagem à [ImageCollection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/imagecollection/) da apresentação. Essa imagem será usada para preencher a forma.
4. Especifique a largura e a altura do quadro.
5. Crie um [PictureFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/pictureframe/) desse tamanho usando o método [add_picture_frame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shapecollection/add_picture_frame/).
6. Salve a apresentação como um arquivo PPTX.

```py
import aspose.slides as slides

# Instanciar a classe Presentation para representar um arquivo PPTX.
with slides.Presentation() as presentation:
    # Obter o primeiro slide.
    slide = presentation.slides[0]

    # Adicionar a imagem à apresentação.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Adicionar um quadro de imagem com tamanho da imagem.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # Salvar a apresentação como PPTX.
        presentation.save("picture_frame.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" %}}
Quadros de imagem permitem que você crie rapidamente slides de apresentação a partir de imagens. Quando você combina quadros de imagem com opções de salvamento do Aspose.Slides, pode controlar as operações de I/O para converter imagens de um formato para outro. Você pode querer ver estas páginas: converter [imagem para JPG](https://products.aspose.com/slides/pt/python-net/conversion/image-to-jpg/); converter [JPG para imagem](https://products.aspose.com/slides/pt/python-net/conversion/jpg-to-image/); converter [JPG para PNG](https://products.aspose.com/slides/pt/python-net/conversion/jpg-to-png/); converter [PNG para JPG](https://products.aspose.com/slides/pt/python-net/conversion/png-to-jpg/); converter [PNG para SVG](https://products.aspose.com/slides/pt/python-net/conversion/png-to-svg/); converter [SVG para PNG](https://products.aspose.com/slides/pt/python-net/conversion/svg-to-png/).
{{% /alert %}}

## **Criar Quadros de Imagem com Escala Relativa**

Esta seção demonstra como colocar uma imagem em tamanho fixo e, em seguida, aplicar escalonamento baseado em porcentagem independentemente à sua largura e altura. Como as porcentagens podem ser diferentes, a proporção pode mudar. O escalonamento é realizado em relação às dimensões originais da imagem.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
2. Obtenha um slide pelo seu índice.
3. Crie um [PPImage](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ppimage/) adicionando a imagem à [ImageCollection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/imagecollection/) da apresentação.
4. Adicione um [PictureFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/pictureframe/) ao slide.
5. Defina a largura e a altura relativas do quadro de imagem.
6. Salve a apresentação como um arquivo PPTX.

```py
import aspose.slides as slides

# Instanciar a classe Presentation para representar um arquivo PPTX.
with slides.Presentation() as presentation:
    # Obter o primeiro slide.
    slide = presentation.slides[0]

    # Adicionar a imagem à coleção de imagens da apresentação.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Adicionar um quadro de imagem ao slide.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

        # Definir a largura e altura de escala relativa.
        picture_frame.relative_scale_height = 0.8
        picture_frame.relative_scale_width = 1.35

        # Salvar a apresentação.
        presentation.save("relative_scaling.pptx", slides.export.SaveFormat.PPTX)
```

## **Extrair Imagens Raster de Quadros de Imagem**

Você pode extrair imagens raster de objetos [PictureFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/pictureframe/) e salvá‑las em PNG, JPG e outros formatos. O exemplo de código abaixo demonstra como extrair uma imagem do documento “sample.pptx” e salvá‑la em formato PNG.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    first_slide = presentation.slides[0]
    first_shape = first_slide.shapes[0]

    if isinstance(first_shape, slides.PictureFrame):
        image = first_shape.picture_format.picture.image.image
        image.save("slide_1_shape_1.png", slides.ImageFormat.PNG)
```

## **Extrair Imagens SVG de Quadros de Imagem**

Quando uma apresentação contém gráficos SVG colocados dentro de formas [PictureFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/pictureframe/), o Aspose.Slides for Python via .NET permite recuperar as imagens vetoriais originais com fidelidade total. Percorrendo a coleção de formas do slide, você pode identificar cada [PictureFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/pictureframe/), verificar se o [PPImage](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ppimage/) subjacente contém conteúdo SVG e, então, salvar essa imagem em disco ou em um fluxo no seu formato SVG nativo.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.PictureFrame):
        svg_image = shape.picture_format.picture.image.svg_image

        if svg_image is not None:
            with open("output.svg", "w", encoding="utf-8") as svg_stream:
                svg_stream.write(svg_image.svg_content)
```

## **Obter Transparência da Imagem**

Aspose.Slides permite que você recupere o efeito de transparência aplicado a uma imagem. Este código Python demonstra a operação:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    picture_frame = presentation.slides[0].shapes[0]
    image_transform = picture_frame.picture_format.picture.image_transform
    for effect in image_transform:
        if isinstance(effect, slides.effects.AlphaModulateFixed):
            transparency_value = 100 - effect.amount
            print("Picture transparency: " + str(transparency_value))
```

{{% alert color="primary" %}}
Todos os efeitos aplicados a imagens podem ser encontrados em [aspose.slides.effects](https://reference.aspose.com/slides/pt/python-net/aspose.slides.effects/).
{{% /alert %}}

## **Formatação de Quadros de Imagem**

Aspose.Slides fornece diversas opções de formatação que podem ser aplicadas a um quadro de imagem. Com essas opções, você pode ajustar um quadro de imagem para atender a requisitos específicos.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
2. Obtenha um slide pelo seu índice.
3. Crie um [PPImage](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ppimage/) adicionando a imagem à [ImageCollection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/imagecollection/) da apresentação. Essa imagem será usada para preencher a forma.
4. Especifique a largura e a altura do quadro.
5. Crie um [PictureFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/pictureframe/) desse tamanho usando o método [add_picture_frame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shapecollection/add_picture_frame/) da slide.
6. Defina a cor da linha do quadro de imagem.
7. Defina a espessura da linha do quadro de imagem.
8. Gire o quadro de imagem fornecendo um valor positivo (horário) ou negativo (anti‑horário).
9. Salve a apresentação modificada como um arquivo PPTX.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanciar a classe Presentation para representar um arquivo PPTX.
with slides.Presentation() as presentation:
    # Obter o primeiro slide.
    slide = presentation.slides[0]

    # Adicionar a imagem à coleção de imagens da apresentação.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Adicionar um quadro de imagem dimensionado à imagem.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # Aplicar formatação ao quadro de imagem.
        picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
        picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
        picture_frame.line_format.width = 20
        picture_frame.rotation = 45

    # Salvar a apresentação como PPTX.
    presentation.save("picture_formatting.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Dica" color="primary" %}}
A Aspose desenvolveu um [Collage Maker](https://products.aspose.app/slides/pt/collage) gratuito. Se precisar [mesclar JPG/JPEG](https://products.aspose.app/slides/pt/collage/jpg) ou PNG, ou [criar grades de fotos](https://products.aspose.app/slides/pt/collage/photo-grid), pode usar esse serviço.
{{% /alert %}}

## **Adicionar Imagens como Links**

Para manter os arquivos de apresentação pequenos, você pode adicionar imagens ou vídeos via links ao invés de incorporar os arquivos diretamente nas apresentações. O código Python a seguir mostra como inserir uma imagem e um vídeo em um placeholder:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    shapes_to_remove = []

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        if shape.placeholder.type == slides.PlaceholderType.PICTURE:
            picture_frame = slide.shapes.add_picture_frame(
                slides.ShapeType.RECTANGLE, shape.x, shape.y, shape.width, shape.height, None)

            picture_frame.picture_format.picture.link_path_long = \
                "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg"

            shapes_to_remove.append(shape)

        elif shape.placeholder.type == slides.PlaceholderType.MEDIA:
            video_frame = slide.shapes.add_video_frame(shape.X, shape.Y, shape.width, shape.height, "")

            video_frame.picture_format.picture.link_path_long = \
                "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg"

            video_frame.link_path_long = "https://youtu.be/t_1LYZ102RA"
            shapes_to_remove.append(shape)

    for shape in shapes_to_remove:
        slide.shapes.remove(shape)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Recortar Imagens**

Nesta seção, você aprenderá como recortar a área visível de uma imagem dentro de um quadro de imagem sem alterar o arquivo fonte. Também aprenderá o método básico para aplicar margens de recorte e criar uma composição limpa e focada diretamente no slide.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Adicionar a imagem à coleção de imagens da apresentação.
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # Adicionar um quadro de imagem ao slide.
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 100, 100, 420, 250, image)

    # Recortar a imagem (valores em percentual).
    picture_frame.picture_format.crop_left = 23.6
    picture_frame.picture_format.crop_right = 21.5
    picture_frame.picture_format.crop_top = 3
    picture_frame.picture_format.crop_bottom = 31

    # Salvar o resultado.
    presentation.save("cropped_image.pptx", slides.export.SaveFormat.PPTX)
```

## **Excluir Áreas Recortadas de Imagens**

Se quiser excluir as áreas recortadas de uma imagem em um quadro, use o método [delete_picture_cropped_areas](https://reference.aspose.com/slides/pt/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/). Esse método devolve a imagem recortada, ou a imagem original se nenhum recorte for necessário.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Obter o PictureFrame do primeiro slide.
    picture_frame = slides.shape[0]

    # Obter o PictureFrame do primeiro slide.
    cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()

    # Salvar o resultado.
    presentation.save("deleted_cropped_areas.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="OBSERVAÇÃO" color="warning" %}}
O método [delete_picture_cropped_areas](https://reference.aspose.com/slides/pt/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) adiciona a imagem recortada à coleção de imagens da apresentação. Se a imagem for usada somente no [PictureFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/pictureframe/) processado, isso pode reduzir o tamanho da apresentação; caso contrário, o número de imagens na apresentação resultante pode aumentar.

Durante o recorte, este método converte arquivos metafile WMF/EMF para uma imagem PNG raster.
{{% /alert %}}

## **Comprimir Imagens**

Você pode comprimir uma imagem em uma apresentação usando o método [PictureFillFormat.compress_image](https://reference.aspose.com/slides/pt/python-net/aspose.slides/picturefillformat/compress_image/). Esse método comprime uma imagem reduzindo seu tamanho com base no tamanho da forma e na resolução especificada, com a opção de excluir áreas recortadas.

Ele ajusta o tamanho e a resolução da imagem de forma semelhante ao recurso **Formato da Imagem → Comprimir Imagens → Resolução** do PowerPoint.

Os exemplos Python a seguir demonstram como comprimir uma imagem em uma apresentação especificando uma resolução alvo e, opcionalmente, removendo áreas recortadas:

```python
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes[0]

    # Comprimir a imagem com resolução alvo de 150 DPI (resolução Web) e remover áreas recortadas.
    result = picture_frame.picture_format.compress_image(True, slides.export.PicturesCompression.DPI150)

    # Verificar o resultado da compressão.
    if result:
        print("Image successfully compressed.")
    else:
        print("Image compression failed or no changes were necessary.")

    presentation.save("compressed_image.pptx", slides.export.SaveFormat.PPTX)
```

Ou usando um valor DPI personalizado diretamente:

```python
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes[0]

    # Comprimir a imagem para 150 DPI (resolução web), removendo áreas recortadas.
    picture_frame.picture_format.compress_image(True, 150)

    presentation.save("compressed_image.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="OBSERVAÇÃO" color="warning" %}}
O método converte a imagem para uma resolução menor com base no tamanho da forma e no DPI fornecido. Regiões recortadas também podem ser excluídas para otimizar o tamanho do arquivo.
Se a imagem for um metafile (WMF/EMF) ou SVG, a compressão não será aplicada. Além disso, a qualidade JPEG é preservada ou ligeiramente reduzida conforme a resolução, de forma similar ao tratamento de JPEGs de alta resolução pelo PowerPoint.
{{% /alert %}}

## **Bloquear a Proporção do Aspecto**

Se quiser que uma forma que contém uma imagem mantenha sua proporção depois de mudar as dimensões da imagem, defina a propriedade [aspect_ratio_locked](https://reference.aspose.com/slides/pt/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) como `True`.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.CUSTOM)
    empty_slide = presentation.slides.add_empty_slide(layout)

    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = empty_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

    # Bloquear a proporção ao redimensionar.
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("aspect_ratio_locked.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="OBSERVAÇÃO" color="warning" %}}
Esta configuração *Bloquear Proporção do Aspecto* preserva apenas a proporção da forma, não a proporção da imagem contida nela.
{{% /alert %}}

## **Usar Propriedades de Deslocamento de Estiramento**

Usando as propriedades `stretch_offset_left`, `stretch_offset_top`, `stretch_offset_right` e `stretch_offset_bottom` da classe [PictureFillFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides/picturefillformat/), você pode definir um retângulo de preenchimento.

Quando o estiramento é especificado para uma imagem, o retângulo de origem é escalonado para caber no retângulo de preenchimento. Cada borda do retângulo de preenchimento é definida por um deslocamento percentual a partir da borda correspondente da caixa delimitadora da forma. Um percentual positivo indica um recuo, enquanto um percentual negativo indica um extrusão.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
2. Obtenha uma referência a um slide por seu índice.
3. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/) retangular.
4. Defina o tipo de preenchimento da forma.
5. Defina o modo de preenchimento de imagem da forma.
6. Carregue uma imagem.
7. Atribua a imagem para preencher a forma.
8. Especifique deslocamentos de imagem a partir das bordas correspondentes da caixa delimitadora da forma.
9. Salve a apresentação como um arquivo PPTX.

```py
import aspose.slides as slides

# Instanciar a classe Presentation que representa um arquivo PPTX.
with slides.Presentation() as presentation:
    # Obter o primeiro slide.
    slide = presentation.slides[0]

    # Adicionar um AutoShape retangular.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 300, 300)

    # Definir o tipo de preenchimento da forma.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Definir o modo de preenchimento de imagem da forma.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # Carregar a imagem e adicioná‑la à apresentação.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

    # Atribuir a imagem para preencher a forma.
    shape.fill_format.picture_fill_format.picture.image = image

    # Especificar deslocamentos de imagem a partir das bordas correspondentes da caixa delimitadora da forma.
    shape.fill_format.picture_fill_format.stretch_offset_left = 25
    shape.fill_format.picture_fill_format.stretch_offset_right = 25
    shape.fill_format.picture_fill_format.stretch_offset_top = -20
    shape.fill_format.picture_fill_format.stretch_offset_bottom = -10

    # Salvar o arquivo PPTX no disco.
    presentation.save("stretch_offset.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Dica" color="primary" %}}
A Aspose fornece conversores gratuitos — [JPEG para PowerPoint](https://products.aspose.app/slides/pt/import/jpg-to-ppt) e [PNG para PowerPoint](https://products.aspose.app/slides/pt/import/png-to-ppt) — que permitem criar rapidamente apresentações a partir de imagens.
{{% /alert %}}

## **Perguntas Frequentes**

**Como posso descobrir quais formatos de imagem são suportados para PictureFrame?**  
Aspose.Slides suporta tanto imagens raster (PNG, JPEG, BMP, GIF etc.) quanto imagens vetoriais (por exemplo, SVG) por meio do objeto de imagem atribuído a um [PictureFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/pictureframe/). A lista de formatos suportados geralmente se sobrepõe às capacidades do motor de conversão de slides e imagens.

**Como a adição de dezenas de imagens grandes afetará o tamanho e o desempenho do PPTX?**  
Incorporar imagens grandes aumenta o tamanho do arquivo e o uso de memória; vincular imagens ajuda a manter o tamanho da apresentação reduzido, mas requer que os arquivos externos permaneçam acessíveis. Aspose.Slides oferece a possibilidade de adicionar imagens por link para reduzir o tamanho do arquivo.

**Como posso impedir que um objeto de imagem seja movido ou redimensionado acidentalmente?**  
Use [travas de forma](https://reference.aspose.com/slides/pt/python-net/aspose.slides/pictureframe/picture_frame_lock/) para um [PictureFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/pictureframe/) (por exemplo, desabilitar movimento ou redimensionamento). O mecanismo de travamento é descrito para formas em um artigo de [proteção separado](/slides/pt/python-net/applying-protection-to-presentation/) e é suportado para vários tipos de forma, incluindo [PictureFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/pictureframe/).

**A fidelidade do vetor SVG é preservada ao exportar uma apresentação para PDF/imagens?**  
Aspose.Slides permite extrair um SVG de um [PictureFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/pictureframe/) como o vetor original. Ao [exportar para PDF](/slides/pt/python-net/convert-powerpoint-to-pdf/) ou para [formatos raster](/slides/pt/python-net/convert-powerpoint-to-png/), o resultado pode ser rasterizado dependendo das configurações de exportação; o fato de o SVG original ser armazenado como vetor é confirmado pelo comportamento de extração.