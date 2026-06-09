---
title: Extrair Imagens de Formas de Apresentação em Python
linktitle: Imagem da Forma
type: docs
weight: 90
url: /pt/python-net/extracting-images-from-presentation-shapes/
keywords:
- extrair imagem
- recuperar imagem
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Extrair imagens de formas em apresentações PowerPoint e OpenDocument com Aspose.Slides para Python via .NET - solução rápida e amigável ao código."
---
## **Visão geral**

Imagens em uma apresentação podem aparecer em vários tipos de forma: como quadros de imagem comuns, como preenchimentos de imagem aplicados a formas, como imagens de visualização de objetos OLE, como miniaturas de quadros de vídeo ou áudio, como imagens de zoom ou como imagens aninhadas dentro de formas de tabela, gráfico e SmartArt. Aspose.Slides armazena essas imagens na coleção de imagens da apresentação, exposta através dos objetos [ImageCollection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/imagecollection/) e [PPImage](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ppimage/).

Se você só precisar exportar todos os recursos de imagem incorporados em uma apresentação, itere por `presentation.images`. Este artigo se concentra em uma tarefa diferente: percorrer as formas para encontrar onde as imagens são usadas nos slides, de modo que os arquivos salvos mantenham contexto útil, como o número do slide, a posição da forma e o tipo de origem (quadro de imagem, imagem de preenchimento, visualização de mídia, visualização OLE ou imagem de zoom).

{{% alert title="Tip" color="primary" %}}
Use a propriedade `binary_data` de [PPImage](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ppimage/) para preservar os dados de imagem codificados originais e o tipo de arquivo. Use a propriedade `image` com `save` quando quiser normalizar a saída para um formato específico, como PNG.
{{% /alert %}}

## **Métodos auxiliares compartilhados**

Os métodos auxiliares abaixo mantêm os exemplos curtos. `save_original_image` grava os bytes incorporados originais, escolhe uma extensão segura a partir do tipo MIME e ignora binários de imagem duplicados usando hash SHA-256.

```py
import hashlib
import re
from pathlib import Path

import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.slides.smartart as smartart


def save_original_image(image, output_directory, file_name_base, saved_image_hashes):
    image_data = bytes(image.binary_data)
    image_hash = hashlib.sha256(image_data).hexdigest()
    if image_hash in saved_image_hashes:
        return False

    saved_image_hashes.add(image_hash)
    extension = get_extension_from_content_type(image.content_type)
    file_name = f"{file_name_base}.{extension}"
    output_path = Path(output_directory) / file_name
    output_path.write_bytes(image_data)
    return True


def save_image_as_png(image, output_directory, file_name_base):
    file_name = f"{file_name_base}.png"
    output_path = Path(output_directory) / file_name
    image.image.save(str(output_path), slides.ImageFormat.PNG)


def get_picture_fill_image(fill_format):
    if fill_format is None or fill_format.fill_type != slides.FillType.PICTURE:
        return None

    return fill_format.picture_fill_format.picture.image


def enumerate_shapes(shapes, prefix, include_grouped_shapes):
    for shape_index, shape in enumerate(shapes, start=1):
        shape_name_part = f"{prefix}_shape_{shape_index}"
        yield shape, shape_name_part

        if include_grouped_shapes and isinstance(shape, slides.GroupShape):
            yield from enumerate_shapes(
                shape.shapes,
                shape_name_part,
                include_grouped_shapes)


def get_extension_from_content_type(content_type):
    if not content_type:
        return "bin"

    media_type = content_type.split(";")[0].strip().lower()
    extensions = {
        "image/jpeg": "jpg",
        "image/png": "png",
        "image/gif": "gif",
        "image/bmp": "bmp",
        "image/tiff": "tiff",
        "image/x-emf": "emf",
        "image/emf": "emf",
        "image/x-wmf": "wmf",
        "image/wmf": "wmf",
        "image/svg+xml": "svg",
    }

    if media_type in extensions:
        return extensions[media_type]

    if media_type.startswith("image/"):
        extension = media_type[len("image/"):]
        return make_safe_file_name_part(extension)

    return "bin"


def make_safe_file_name_part(value):
    return re.sub(r'[<>:"/\\|?*]', "_", value)
```

## **Extrair imagens de quadros de imagem**

Use esta abordagem para imagens inseridas como objetos independentes. Um [PictureFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/pictureframe/) armazena sua imagem em `picture_format.picture.image`, que retorna um objeto [PPImage](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ppimage/).

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "extracted-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if type(shape) is slides.PictureFrame:
                image = shape.picture_format.picture.image
                save_original_image(image, output_directory, name_part, saved_image_hashes)
```

## **Extrair imagens de formas preenchidas com imagem**

Formas podem usar uma imagem como preenchimento. Verifique primeiro o tipo de preenchimento da forma: se não for [FillType.PICTURE](https://reference.aspose.com/slides/pt/python-net/aspose.slides/filltype/), não há imagem para extrair desse preenchimento. O exemplo abaixo trata objetos [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/) e salva cada imagem como PNG através da propriedade `image` de [PPImage](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ppimage/).

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "shape-fill-images"
output_directory.mkdir(parents=True, exist_ok=True)

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if isinstance(shape, slides.AutoShape):
                image = get_picture_fill_image(shape.fill_format)
                if image is not None:
                    save_image_as_png(image, output_directory, name_part)
```

## **Extrair imagens de visualização de quadros de objeto OLE**

Um [OleObjectFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/oleobjectframe/) pode ter uma imagem substituta que o PowerPoint usa como visualização do objeto em um slide. Essa imagem está disponível através de `substitute_picture_format.picture.image`. Extrair essa imagem fornece a imagem de visualização, não o conteúdo do pacote OLE incorporado.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "ole-preview-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if isinstance(shape, slides.OleObjectFrame):
                image = shape.substitute_picture_format.picture.image
                if image is not None:
                    file_name_base = f"{name_part}_ole_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
```

## **Extrair imagens de visualização de quadros de vídeo**

Um [VideoFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/videoframe/) também pode armazenar uma imagem de visualização em `picture_format.picture.image`. Esta é a imagem de poster ou miniatura exibida no slide, não um quadro decodificado do fluxo de vídeo.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "video-preview-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if isinstance(shape, slides.VideoFrame):
                image = shape.picture_format.picture.image
                if image is not None:
                    file_name_base = f"{name_part}_video_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
```

## **Extrair imagens de visualização de quadros de áudio**

Um [AudioFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/audioframe/) pode armazenar uma miniatura em `picture_format.picture.image`. Esta é a imagem exibida para o objeto de áudio no slide.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "audio-preview-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if isinstance(shape, slides.AudioFrame):
                image = shape.picture_format.picture.image
                if image is not None:
                    file_name_base = f"{name_part}_audio_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
```

## **Extrair imagens de objetos de zoom**

[ZoomFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/zoomframe/) e [SectionZoomFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/sectionzoomframe/) podem usar imagens personalizadas. Leia `zoom_image` do quadro de zoom.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "zoom-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if isinstance(shape, slides.ZoomFrame) and shape.zoom_image is not None:
                file_name_base = f"{name_part}_zoom"
                save_original_image(shape.zoom_image, output_directory, file_name_base, saved_image_hashes)
                continue

            if isinstance(shape, slides.SectionZoomFrame) and shape.zoom_image is not None:
                file_name_base = f"{name_part}_section_zoom"
                save_original_image(shape.zoom_image, output_directory, file_name_base, saved_image_hashes)
                continue
```

## **Extrair imagens de quadros de resumo de zoom**

Um [SummaryZoomFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/summaryzoomframe/) também é uma forma. Seus itens de seção podem usar imagens personalizadas, expostas através da propriedade `zoom_image` de cada seção de resumo de zoom.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "summary-zoom-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if isinstance(shape, slides.SummaryZoomFrame):
                section_count = len(shape.summary_zoom_collection)
                for section_index in range(section_count):
                    section = shape.summary_zoom_collection[section_index]
                    if section.zoom_image is not None:
                        display_index = section_index + 1
                        file_name_base = f"{name_part}_summary_zoom_{display_index}"
                        save_original_image(section.zoom_image, output_directory, file_name_base, saved_image_hashes)
```

## **Extrair imagens de formas de tabela**

Uma [Table](https://reference.aspose.com/slides/pt/python-net/aspose.slides/table/) é uma forma. Imagens em uma tabela geralmente são armazenadas como preenchimentos de imagem nas células da tabela.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "table-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=True):
            if isinstance(shape, slides.Table):
                row_count = len(shape.rows)
                column_count = len(shape.columns)
                for row_index in range(row_count):
                    for column_index in range(column_count):
                        cell = shape.rows[row_index][column_index]
                        image = get_picture_fill_image(cell.cell_format.fill_format)
                        if image is not None:
                            file_name_base = f"{name_part}_cell_{row_index + 1}_{column_index + 1}"
                            save_original_image(image, output_directory, file_name_base, saved_image_hashes)
```

## **Extrair imagens de formas de gráfico**

Um [Chart](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chart/) é uma forma. O exemplo abaixo extrai uma imagem do preenchimento de imagem da área do gráfico.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "chart-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=True):
            if isinstance(shape, charts.Chart):
                fill_format = shape.fill_format
                image = get_picture_fill_image(fill_format)
                if image is not None:
                    file_name_base = f"{name_part}_chart_area"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
```

## **Extrair imagens de formas SmartArt**

Um objeto [SmartArt](https://reference.aspose.com/slides/pt/python-net/aspose.slides.smartart/smartart/) é uma forma. Dependendo do layout do SmartArt, as imagens podem ser armazenadas nos preenchimentos de marcadores de nós ou nos formatos de preenchimento das formas de nó.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "smartart-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=True):
            if isinstance(shape, smartart.SmartArt):
                node_count = len(shape.all_nodes)
                for node_index in range(node_count):
                    node = shape.all_nodes[node_index]
                    bullet_image = get_picture_fill_image(node.bullet_fill_format)
                    if bullet_image is not None:
                        file_name_base = f"{name_part}_smartart_node_{node_index + 1}_bullet"
                        save_original_image(bullet_image, output_directory, file_name_base, saved_image_hashes)

                    node_shape_count = len(node.shapes)
                    for node_shape_index in range(node_shape_count):
                        node_shape = node.shapes[node_shape_index]
                        image = get_picture_fill_image(node_shape.fill_format)
                        if image is not None:
                            file_name_base = f"{name_part}_smartart_node_{node_index + 1}_shape_{node_shape_index + 1}"
                            save_original_image(image, output_directory, file_name_base, saved_image_hashes)
```

## **Incluir imagens dentro de formas agrupadas**

Formas agrupadas contêm suas próprias coleções de formas. O auxílio compartilhado `enumerate_shapes` possui a opção `include_grouped_shapes`. Defina-a como `True` quando quiser inspecionar formas dentro de objetos [GroupShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/groupshape/). O exemplo abaixo extrai imagens de quadros de imagem, formas preenchidas com imagem, visualizações de objetos OLE, miniaturas de quadros de vídeo e miniaturas de quadros de áudio. Para incluir também imagens de tabelas, gráficos, SmartArt e resumo de zoom, reutilize a lógica de extração especializada das seções anteriores mantendo a mesma travessia recursiva de formas.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "all-shape-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=True):
            if isinstance(shape, slides.OleObjectFrame):
                image = shape.substitute_picture_format.picture.image
                if image is not None:
                    file_name_base = f"{name_part}_ole_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)

                continue

            if isinstance(shape, slides.VideoFrame):
                image = shape.picture_format.picture.image
                if image is not None:
                    file_name_base = f"{name_part}_video_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)

                continue

            if isinstance(shape, slides.AudioFrame):
                image = shape.picture_format.picture.image
                if image is not None:
                    file_name_base = f"{name_part}_audio_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)

                continue

            if type(shape) is slides.PictureFrame:
                image = shape.picture_format.picture.image
                save_original_image(image, output_directory, name_part, saved_image_hashes)
                continue

            if isinstance(shape, slides.AutoShape):
                image = get_picture_fill_image(shape.fill_format)
                if image is not None:
                    save_original_image(image, output_directory, name_part, saved_image_hashes)
```

## **Casos limites e observações práticas**

- **Imagens duplicadas:** Várias formas podem referenciar a mesma imagem ou imagens separadas com bytes idênticos. Faça hash da propriedade `binary_data` de [PPImage](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ppimage/) antes de gravar os arquivos se quiser um arquivo de saída por imagem única.
- **Dados originais vs. saída convertida:** Salvar a propriedade `binary_data` de [PPImage](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ppimage/) preserva os dados incorporados JPEG, PNG, GIF, SVG, EMF ou WMF. Salvar a propriedade `image` através de `save` é útil quando você deseja um formato de saída consistente.
- **Tipos de preenchimento não suportados:** Formas sólidas, gradientes, padrões e sem preenchimento não contêm preenchimento de imagem. Verifique [FillType](https://reference.aspose.com/slides/pt/python-net/aspose.slides/filltype/) antes de ler `picture_fill_format`.
- **Formas agrupadas:** A coleção de formas de nível superior do slide não achata os grupos. Inspecione recursivamente [GroupShape.shapes](https://reference.aspose.com/slides/pt/python-net/aspose.slides/groupshape/shapes/) quando o conteúdo agrupado for relevante.
- **Visualizações de objetos OLE:** Um [OleObjectFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/oleobjectframe/) pode expor uma imagem de visualização através de `substitute_picture_format`, mas essa imagem é apenas a visualização do slide. Não é o arquivo incorporado dentro do objeto OLE.
- **Miniaturas de quadros de vídeo:** Um [VideoFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/videoframe/) pode expor uma imagem de visualização através de `picture_format`, mas essa imagem é apenas o poster exibido no slide. Não é extraída do fluxo de vídeo.
- **Miniaturas de quadros de áudio:** Um [AudioFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/audioframe/) pode expor um ícone ou miniatura através de `picture_format`; não são os dados de áudio incorporados.
- **Imagens de zoom:** Formas de zoom de slide, zoom de seção e resumo de zoom podem usar objetos [PPImage](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ppimage/) personalizados através de `image`.
- **Modelos de forma aninhados:** Objetos de tabela, gráfico e SmartArt implementam [Shape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shape/), mas suas imagens geralmente são armazenadas em objetos de formatação de célula de tabela, elemento de gráfico ou nó de SmartArt.
- **Imagens recortadas ou transformadas:** Acessar [PPImage](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ppimage/) fornece o recurso de imagem armazenado. Não renderiza recorte, transparência, recolorização, rotação ou outros efeitos visuais aplicados pela forma.

## **FAQ**

**Posso extrair a imagem original sem recorte, efeitos ou transformações de forma?**

Sim. Acesse o objeto [PPImage](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ppimage/) e grave sua propriedade `binary_data` no disco. Isso preserva a imagem codificada original armazenada na apresentação, não a forma como a imagem é renderizada no slide.

**Posso exportar todas as imagens extraídas como PNG?**

Sim. Use a propriedade `image` de [PPImage](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ppimage/) para obter um objeto de imagem e, em seguida, chame `save` com [ImageFormat.PNG](https://reference.aspose.com/slides/pt/python-net/aspose.slides/imageformat/). Isso converte a saída e pode não preservar o tipo de arquivo original ou dados vetoriais.

**Como evito salvar a mesma imagem mais de uma vez?**

Use um hash da propriedade `binary_data` de [PPImage](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ppimage/) e mantenha os hashes em um conjunto. Se uma nova imagem tiver um hash que já exista, ignore-a ou registre outra referência ao arquivo de saída existente.

**Por que algumas formas não geram uma imagem?**

Quadros de imagem, formas preenchidas com imagem, quadros de objeto OLE, quadros de mídia, quadros de zoom, tabelas, gráficos e objetos SmartArt podem referenciar imagens. Alguns tipos de forma expõem imagens por meio de objetos de formatação aninhados, portanto uma verificação simples de `picture_format` ou `fill_format` da forma nem sempre é suficiente.

**Posso extrair a miniatura mostrada para um quadro de vídeo?**

Sim. Use [VideoFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/videoframe/) e leia `picture_format.picture.image`. Isso extrai a imagem de poster armazenada com o quadro de vídeo, não um quadro gerado a partir do arquivo de vídeo.

**Como posso determinar quais formas usam uma imagem específica da coleção de imagens da apresentação?**

Aspose.Slides não armazena links inversos de [PPImage](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ppimage/) para formas. Construa um mapeamento durante a travessia: sempre que encontrar uma referência de imagem, registre o número do slide, o caminho da forma e o hash ou item da coleção da imagem.

**Posso extrair imagens incorporadas dentro de objetos OLE, como documentos anexados?**

Você pode extrair a visualização de slide do objeto OLE a partir da propriedade `substitute_picture_format` de [OleObjectFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/oleobjectframe/). Contudo, essa visualização não é o documento incorporado em si. Para extrair imagens de dentro do arquivo incorporado, extraia os dados OLE e inspecione-os com ferramentas adequadas ao tipo de arquivo.