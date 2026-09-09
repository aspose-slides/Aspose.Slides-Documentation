---
title: Gerenciar Quadros de Imagem em Apresentações Usando Python
linktitle: Quadro de Imagem
type: docs
weight: 10
url: /pt/python-java/picture-frame/
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
- Java
- Aspose.Slides
description: "Criar, formatar, vincular, recortar, extrair e comprimir quadros de imagem em apresentações com Aspose.Slides para Python via Java."
---
## **Visão geral**

Um quadro de imagem é uma forma de slide que exibe uma imagem. No Aspose.Slides, o recurso de imagem e a forma que a exibe são objetos separados: uma [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) possui recursos de imagem incorporados através de sua [ImageCollection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/imagecollection/), enquanto um [PictureFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/pictureframe/) controla a posição, tamanho, formatação de linha, rotação, recorte, efeitos de imagem e outras configurações ao nível do quadro.

Esta separação é útil quando a mesma imagem é mostrada mais de uma vez. Adicione a imagem à apresentação uma vez, mantenha o [PPImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/ppimage/) retornado e use esse recurso de imagem ao criar quadros de imagem.

Quadros de imagem podem conter imagens raster, como PNG ou JPEG, e imagens vetoriais SVG. Eles também podem referir‑se a imagens vinculadas em vez de armazenar os bytes da imagem na apresentação. A escolha afeta portabilidade, tamanho do arquivo, extração e comportamento de exportação, portanto é útil decidir como a imagem deve ser armazenada antes de aplicar formatação ou otimização.

## **Adicionar e formatar uma imagem incorporada**

Para uma imagem incorporada, adicione os dados da imagem à apresentação e crie um quadro de imagem com [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapecollection/#addPictureFrame). A imagem torna‑se parte do pacote da apresentação, de modo que a apresentação permanece autocontida quando é movida para outro computador.

O exemplo a seguir adiciona uma imagem JPEG, cria um quadro nas dimensões nativas da imagem e aplica formatação de linha e rotação:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.awt import Color
from asposeslides.api import FillType, Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image)
    picture_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    picture_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    picture_frame.getLineFormat().setWidth(3)
    picture_frame.setRotation(15)

    presentation.save("picture-frame.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

O quadro de imagem controla a geometria exibida; alterar o tamanho do quadro não altera as dimensões originais em pixels armazenadas no recurso de imagem incorporado. Essa distinção torna‑se importante ao recortar ou comprimir uma imagem posteriormente.

## **Usar escala relativa**

[PictureFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/pictureframe/) expõe a escala relativa de largura e altura para o quadro por meio de [setRelativeScaleWidth](https://reference.aspose.com/slides/pt/python-java/aspose.slides/pictureframe/#setRelativeScaleWidth) e [setRelativeScaleHeight](https://reference.aspose.com/slides/pt/python-java/aspose.slides/pictureframe/#setRelativeScaleHeight). Um valor de `1.0` corresponde a 100 % do tamanho original da imagem. A escala relativa é útil quando um fluxo de trabalho precisa preservar a relação com o tamanho da imagem fonte em vez de calcular as dimensões finais manualmente.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image)
    picture_frame.setRelativeScaleWidth(1.35)
    picture_frame.setRelativeScaleHeight(0.8)

    presentation.save("relative-scale.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A escala relativa altera as configurações de escala do quadro; não reamostra nem comprime a imagem incorporada.

## **Imagens incorporadas e vinculadas**

Uma imagem incorporada armazena os dados da imagem dentro da apresentação e, portanto, é a escolha mais segura para portabilidade e renderização previsível. Uma imagem vinculada armazena um local externo por meio do método [Picture.setLinkPathLong](https://reference.aspose.com/slides/pt/python-java/aspose.slides/picture/#setLinkPathLong) em vez de incorporar os dados da imagem da mesma forma.

Imagens vinculadas podem reduzir a quantidade de dados de imagem armazenados no PPTX, mas introduzem uma dependência externa. O arquivo vinculado deve permanecer acessível à aplicação que abre ou renderiza a apresentação. Se o caminho mudar, o arquivo for movido ou o recurso ficar indisponível, a imagem vinculada pode não ser exibida como esperado. Para apresentações que precisam ser enviadas por e‑mail, arquivadas ou renderizadas em ambientes isolados, imagens incorporadas são geralmente mais confiáveis.

### **Adicionar uma imagem vinculada**

O exemplo a seguir cria um quadro de imagem e o aponta para um arquivo de imagem local. Ele trata apenas de vinculação de imagens; a vinculação de vídeo é um fluxo de mídia separado e, intencionalmente, não foi misturada neste exemplo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, None)
    linked_image_file = Path("linked-image.jpg").resolve()
    link_path = str(linked_image_file)
    picture_frame.getPictureFormat().getPicture().setLinkPathLong(link_path)

    presentation.save("linked-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Use links quando a gestão externa de arquivos for intencional. Não os use apenas como substituto da compressão: um PPTX pequeno com dependências de imagem quebradas costuma ser menos útil que uma apresentação maior e autocontida.

## **Extrair imagens de quadros de imagem**

Antes de extrair uma imagem de uma apresentação existente, verifique se a forma é realmente um [PictureFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/pictureframe/) e se contém uma imagem incorporada. Quadros de imagem vinculados podem não conter bytes de imagem que possam ser extraídos da mesma forma.

### **Extrair uma imagem raster**

A API de imagem moderna trabalha diretamente com imagens raster e não requer o wrapper Java antigo. O exemplo a seguir localiza a primeira imagem raster incorporada em um slide e a salva como PNG:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, PictureFrame):
            continue

        picture_frame = shape
        embedded_image = picture_frame.getPictureFormat().getPicture().getImage()
        if embedded_image is None or embedded_image.getSvgImage() is not None:
            continue

        raster_image = embedded_image.getImage()
        try:
            raster_image.save("extracted-image.png", ImageFormat.Png)
        finally:
            raster_image.dispose()
        break
finally:
    presentation.dispose()
```

Salvar a imagem raster converte a imagem extraída para o formato de saída solicitado. Se precisar dos bytes codificados armazenados na apresentação em vez de um arquivo raster convertido, use os dados binários do recurso de imagem.

### **Extrair uma imagem SVG**

Para uma imagem SVG, o [PPImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/ppimage/) expõe um objeto [SvgImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/svgimage/). Isso permite recuperar os dados SVG diretamente em vez de rasterizar a imagem primeiro.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, PictureFrame):
            continue

        picture_frame = shape
        embedded_image = picture_frame.getPictureFormat().getPicture().getImage()
        svg_image = embedded_image.getSvgImage() if embedded_image is not None else None
        if svg_image is None:
            continue

        svg_data = svg_image.getSvgData()
        Path("extracted-image.svg").write_bytes(bytes(svg_data))
        break
finally:
    presentation.dispose()
```

Manter o conteúdo SVG como SVG preserva a fonte vetorial dentro da apresentação. Exportações raster, como PNG ou JPEG, renderizam esse conteúdo vetorial em pixels. A exportação de slides como PDF ou SVG também é uma operação de renderização, portanto os gráficos exportados não devem ser tratados como uma cópia byte‑a‑byte do SVG incorporado; use os dados de [SvgImage.getSvgData](https://reference.aspose.com/slides/pt/python-java/aspose.slides/svgimage/#getSvgData) quando o recurso vetorial original for necessário.

## **Recortar uma imagem**

O recorte altera qual parte de uma imagem é visível dentro do quadro. Os valores de recorte em [PictureFillFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/picturefillformat/) são percentuais das dimensões da imagem fonte. O recorte não exclui inicialmente os pixels ocultos da imagem incorporada; ele apenas muda a região visível.

O exemplo a seguir localiza um quadro de imagem com segurança e aplica valores de recorte:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        picture_frame.getPictureFormat().setCropLeft(23.6)
        picture_frame.getPictureFormat().setCropRight(21.5)
        picture_frame.getPictureFormat().setCropTop(3)
        picture_frame.getPictureFormat().setCropBottom(31)
        presentation.save("cropped-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Como os dados de imagem ocultos ainda estão presentes, o recorte pode ser alterado posteriormente sem perder os pixels originais. Se o tamanho do arquivo for mais importante que a reversibilidade, as regiões recortadas podem ser removidas fisicamente conforme descrito na próxima seção.

## **Remover dados de imagem recortados**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/pt/python-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) remove os dados da imagem fora do retângulo de recorte atual e devolve o recurso de imagem resultante. Isso pode reduzir o tamanho do arquivo, mas é uma otimização destrutiva: após a apresentação ser salva, os pixels removidos não estão mais disponíveis para uma operação de des‑recorte posterior.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PictureFrame

presentation = Presentation("cropped-image.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        cropped_image = picture_frame.getPictureFormat().deletePictureCroppedAreas()
        if cropped_image is not None:
            presentation.save("cropped-data-removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

O método pode adicionar um novo recurso de imagem à apresentação. Se a imagem original também for usada por outros quadros, esses quadros ainda precisarão do recurso existente, de modo que a exclusão das áreas recortadas não reduz necessariamente o número total de imagens. Recortar conteúdo WMF ou EMF com este método rasteriza o resultado recortado para PNG.

## **Comprimir imagens raster**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/picturefillformat/#compressImage) reduz a resolução da imagem raster em relação ao tamanho em que a imagem é exibida. Também pode remover regiões recortadas na mesma operação. O método devolve `True` quando a imagem foi redimensionada ou recortada e `False` quando nenhuma alteração foi necessária.

Use um valor pré‑definido de [PicturesCompression](https://reference.aspose.com/slides/pt/python-java/aspose.slides/picturescompression/) quando uma resolução‑alvo padrão for suficiente:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PicturesCompression, Presentation, SaveFormat, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        compressed = picture_frame.getPictureFormat().compressImage(True, PicturesCompression.Dpi150)
        print("The image was compressed." if compressed else "No compression was necessary.")
        presentation.save("compressed-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Um valor DPI positivo personalizado pode ser passado em vez de um valor pré‑definido quando um alvo específico for necessário.

A compressão destina‑se a imagens raster. Conteúdo SVG e metafile não é reduzido por este fluxo de compressão raster. Também lembre‑se de que resolução mais baixa e regiões recortadas excluídas não podem ser recuperadas da apresentação otimizada. Escolha uma resolução‑alvo com base no maior tamanho em que a imagem será realmente visualizada ou exportada, em vez de aplicar o DPI mais baixo globalmente.

## **Gerenciar efeitos de transformação de imagem**

Para um fluxo de trabalho completo que cobre brilho, contraste, transformações de cor, desfoque, efeitos alfa, cadeias ordenadas, inspeção, remoção e verificação de ida e volta, consulte [Image Transform Effects](/slides/pt/python-java/image-transform-effects/).

## **Bloquear a geometria do quadro de imagem**

As configurações de [PictureFrameLock](https://reference.aspose.com/slides/pt/python-java/aspose.slides/pictureframelock/) controlam quais operações de edição são desativadas para um quadro de imagem. Por exemplo, [setAspectRatioLocked](https://reference.aspose.com/slides/pt/python-java/aspose.slides/pictureframelock/#setAspectRatioLocked) preserva as proporções da forma enquanto ela é redimensionada.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image)
    picture_frame.getPictureFrameLock().setAspectRatioLocked(True)

    presentation.save("locked-picture-frame.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

O bloqueio se aplica à forma do quadro de imagem. Ele não força a imagem fonte a ser reamostrada ou alterada permanentemente para a mesma proporção.

## **Ajustar os valores de StretchOffset**

Quando o modo de preenchimento de imagem é stretch, os valores de stretch‑offset em [PictureFillFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/picturefillformat/) definem o retângulo de preenchimento relativo à caixa delimitadora do quadro de imagem. Percentuais positivos criam um recuo a partir de uma borda, enquanto percentuais negativos criam um extrusão.

Isso difere do recorte. Valores de recorte selecionam qual parte da imagem fonte fica visível; offsets de stretch alteram o retângulo no qual o preenchimento visível é esticado.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, PictureFillMode, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.png")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image)
    picture_frame.getPictureFormat().setPictureFillMode(PictureFillMode.Stretch)
    picture_frame.getPictureFormat().setStretchOffsetLeft(12)
    picture_frame.getPictureFormat().setStretchOffsetRight(12)
    picture_frame.getPictureFormat().setStretchOffsetTop(8)
    picture_frame.getPictureFormat().setStretchOffsetBottom(8)

    presentation.save("stretch-offsets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Use offsets de stretch para posicionamento de preenchimento. Use propriedades de recorte quando o objetivo for ocultar bordas da imagem fonte.

## **Considerações de armazenamento, tamanho de arquivo e exportação**

Os principais trade‑offs são mais fáceis de gerenciar quando o armazenamento de imagens e a formatação de quadros são tratados separadamente:

- **Imagens incorporadas** tornam a apresentação autocontida e são as mais confiáveis para compartilhamento e renderização no servidor, mas imagens raster grandes aumentam o tamanho do PPTX e o uso de memória.
- **Imagens vinculadas** podem manter o pacote menor, porém a apresentação depende de arquivos externos permanecerem disponíveis nos caminhos ou locais armazenados.
- **Recorte** é inicialmente não destrutivo. Os pixels ocultos permanecem incorporados até que áreas recortadas sejam explicitamente excluídas ou removidas durante a compressão.
- **Compressão** pode reduzir o tamanho do arquivo substancialmente para imagens raster excessivamente grandes, mas sacrifica a resolução original. Deve ser aplicada depois que o tamanho final na tela for conhecido.
- **Imagens SVG** devem permanecer como SVG quando a preservação vetorial é importante. Extraia o SVG incorporado diretamente quando precisar do recurso vetorial em si. Exportações de slides raster, como PNG ou JPEG, convertem o slide renderizado em pixels.
- **Imagens repetidas** devem reutilizar um recurso [PPImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/ppimage/) existente sempre que possível, em vez de carregar o mesmo arquivo repetidamente no fluxo de trabalho da apresentação.

Para apresentações grandes, a otimização de imagem costuma ser mais eficaz quando feita seletivamente: mantenha logotipos e diagramas como conteúdo vetorial, comprima fotografias de acordo com seu tamanho real de exibição, remova pixels recortados apenas quando a edição posterior não for necessária e evite links externos, a menos que a gestão de dependências faça parte do design de implantação.

## **Perguntas frequentes**

**Qual é a diferença entre um quadro de imagem e um recurso de imagem?**

Um [PPImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/ppimage/) representa um recurso de imagem associado à apresentação. Um [PictureFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/pictureframe/) é uma forma em um slide que exibe uma imagem e armazena geometria e formatação ao nível do quadro, como tamanho, rotação, valores de recorte, efeitos e travas.

**Devo incorporar ou vincular imagens?**

Incorpore imagens quando a apresentação precisar ser portátil, arquivada ou renderizada sem acesso a recursos externos. Vincule imagens apenas quando manter os arquivos de imagem fora do PPTX for intencional e os locais externos puderem ser mantidos de forma confiável.

**O recorte reduz o tamanho do arquivo PPTX?**

Não por si só. Configurações normais de recorte ocultam partes da imagem fonte, mas mantêm os pixels subjacentes. Use [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/pt/python-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) ou compressão de imagem com remoção de áreas recortadas quando esses pixels puderem ser descartados permanentemente.

**Posso restaurar a qualidade da imagem após a compressão?**

Não. A compressão pode reduzir a resolução raster armazenada e a remoção de regiões recortadas elimina dados de imagem. Mantenha a imagem fonte original fora da apresentação se futuras edições em alta resolução forem necessárias.

**Como as imagens SVG devem ser tratadas?**

Mantenha o conteúdo SVG como SVG quando a fidelidade vetorial for importante. O [SvgImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/svgimage/) incorporado pode ser extraído diretamente. Renderizar um slide para um formato raster, como PNG ou JPEG, rasteriza o SVG como parte da imagem do slide.

**Como posso evitar casts inseguros ao ler slides existentes?**

Verifique o tipo da forma antes de usar membros específicos de quadro de imagem. Uma verificação `isinstance` contra [PictureFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/pictureframe/) evita casts inválidos e permite que o código trate slides que não contêm quadros de imagem.