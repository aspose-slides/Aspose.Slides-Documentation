---
title: Optimizar o Gerenciamento de Imagens em Apresentações Usando PHP
linktitle: Gerenciar Imagens
type: docs
weight: 10
url: /pt/php-java/image/
keywords:
- adicionar imagem
- adicionar foto
- adicionar bitmap
- substituir imagem
- substituir foto
- da web
- fundo
- adicionar PNG
- adicionar JPG
- adicionar SVG
- recursos SVG externos
- resolvedor SVG
- imagens SVG vinculadas
- fontes SVG
- adicionar EMF
- adicionar WMF
- adicionar TIFF
- PowerPoint
- OpenDocument
- apresentação
- EMF
- SVG
- PHP
- Aspose.Slides
description: "Simplifique o gerenciamento de imagens no PowerPoint e OpenDocument com Aspose.Slides para PHP via Java, otimizando o desempenho e automatizando seu fluxo de trabalho."
---
## **Introdução**

As imagens tornam as apresentações mais envolventes e visualmente atraentes. No Microsoft PowerPoint, você pode inserir imagens nos slides a partir de arquivos, da internet ou de outras fontes. Da mesma forma, Aspose.Slides permite adicionar imagens aos slides de apresentação de várias maneiras.

{{% alert  title="Dica" color="primary" %}} 

A Aspose fornece conversores gratuitos—[JPEG para PowerPoint](https://products.aspose.app/slides/pt/import/jpg-to-ppt) e [PNG para PowerPoint](https://products.aspose.app/slides/pt/import/png-to-ppt)—que permitem criar apresentações rapidamente a partir de imagens. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Se você quiser adicionar uma imagem como uma moldura—especialmente se pretender redimensioná‑la, aplicar efeitos ou usar outras opções de formatação padrão—veja [Moldura de Imagem](/slides/pt/php-java/picture-frame/). 

{{% /alert %}} 

{{% alert title="Nota" color="warning" %}}

Você pode converter imagens de um formato para outro. Consulte as páginas seguintes: converter [imagem para JPG](https://products.aspose.com/slides/pt/php-java/conversion/image-to-jpg/), [JPG para imagem](https://products.aspose.com/slides/pt/php-java/conversion/jpg-to-image/), [JPG para PNG](https://products.aspose.com/slides/pt/php-java/conversion/jpg-to-png/), [PNG para JPG](https://products.aspose.com/slides/pt/php-java/conversion/png-to-jpg/), [PNG para SVG](https://products.aspose.com/slides/pt/php-java/conversion/png-to-svg/), e [SVG para PNG](https://products.aspose.com/slides/pt/php-java/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides suporta imagens em formatos populares como JPEG, PNG, BMP, GIF e outros. 

## **Adicionar Imagens Armazenadas Localmente aos Slides**

Você pode adicionar uma ou mais imagens armazenadas no seu computador a um slide de apresentação. O código de exemplo PHP a seguir mostra como adicionar uma imagem a um slide:

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $picture = null;
    $image = Images::fromFile("image.png");
    try {
        $picture = $pres->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);

    $pres->save("pres.pptx", SaveFormat::Pptx);
} finally {
    $pres->dispose();
}
```

## **Adicionar Imagens da Web aos Slides**

Se a imagem que você deseja adicionar a um slide não estiver armazenada no seu computador, você pode adicioná‑la diretamente da web. 

O código de exemplo PHP a seguir mostra como adicionar uma imagem da web a um slide:

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $imageUrl = new Java("java.net.URL", "[REPLACE WITH URL]");
    $connection = $imageUrl->openConnection();
    $inputStream = $connection->getInputStream();

    $outputStream = new Java("java.io.ByteArrayOutputStream");
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = (new JavaClass("java.lang.Byte"))->TYPE;

    try {
        $buffer = $Array->newInstance($Byte, 1024);

        while (($read = java_values($inputStream->read($buffer, 0, $Array->getLength($buffer)))) != -1) {
            $outputStream->write($buffer, 0, $read);
        }

        $outputStream->flush();

        $image = $pres->getImages()->addImage($outputStream->toByteArray());
        $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $image);
    } finally {
        if (!java_is_null($inputStream)) {
            $inputStream->close();
        }
        $outputStream->close();
    }

    $pres->save("pres.pptx", SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
    $pres->dispose();
}
```

## **Adicionar Imagens aos Mestres de Slides**

Um mestre de slide armazena e controla informações como o tema e o layout para os slides que o utilizam. Quando você adiciona uma imagem a um mestre de slide, a imagem aparece em todos os slides baseados naquele mestre. 

O código de exemplo PHP a seguir mostra como adicionar uma imagem a um mestre de slide:

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);
    $masterSlide = $slide->getLayoutSlide()->getMasterSlide();

    $picture = null;
    $image = Images::fromFile("image.png");
    try {
        $picture = $pres->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $masterSlide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);

    $pres->save("pres.pptx", SaveFormat::Pptx);
} finally {
    $pres->dispose();
}
```

## **Adicionar Imagens como Fundo de Slide**

Você pode usar uma imagem como fundo para um ou mais slides. Para detalhes, veja *[Definir Imagens como Fundos para Slides](/slides/pt/php-java/presentation-background/#setting-images-as-background-for-slides)*.

## **Adicionar SVG a Apresentações**

O conteúdo SVG pode ser adicionado a uma apresentação usando a classe [SvgImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/svgimage/). O objeto de imagem SVG resultante pode então ser adicionado à coleção de imagens da apresentação e usado para criar uma moldura de imagem.

O exemplo PHP a seguir importa uma string SVG autocontida. Todas as imagens, estilos e outros recursos usados por este SVG são incorporados diretamente no conteúdo SVG.

```php
$svgContent =
    "<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>" .
    "    <rect width='320' height='180' fill='#4F81BD'/>" .
    "    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>" .
    "</svg>";

$presentation = new Presentation();
try {
    $svgImage = new SvgImage($svgContent);
    $image = $presentation->getImages()->addImage($svgImage);

    $presentation->getSlides()->get_Item(0)->getShapes()->addPictureFrame(
        ShapeType::Rectangle,
        20,
        20,
        $image->getWidth(),
        $image->getHeight(),
        $image
    );

    $presentation->save("self-contained-svg.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Importar Conteúdo SVG com Recursos Externos**

Arquivos SVG exportados de ferramentas de design, editores de diagramas, sistemas de ícones e pipelines web podem referenciar recursos que estão armazenados fora do documento SVG. Por exemplo, um SVG pode conter um link de imagem como `images/photo.png`, um valor CSS `url(...)` ou uma URL de fonte.

Para importar esse tipo de conteúdo SVG, crie uma implementação de [ExternalResourceResolver](https://reference.aspose.com/slides/pt/php-java/aspose.slides/externalresourceresolver/) e passe‑a, junto com um URI base, a um construtor adequado de [SvgImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/svgimage/). O URI base identifica a localização do documento SVG e é usado para resolver links relativos.

O objeto de imagem SVG fornece acesso a informações sobre o SVG importado:

- `getSvgContent()` retorna a marcação SVG como uma string.
- `getSvgData()` retorna o conteúdo SVG como um array de bytes.
- `getBaseUri()` retorna o URI base usado para links relativos.
- `getExternalResourceResolver()` retorna o resolvedor atribuído à imagem SVG.

### **Implementar um Resolutor de Recursos Externos**

O resolvedor tem dois métodos:

- `resolveUri` combina o URI base e um link de recurso relativo e retorna um URI absoluto. Retorne `null` quando o link não puder ser resolvido ou não for permitido.
- `getEntity` retorna um fluxo legível para um URI de recurso absoluto. Retorne `null` quando o recurso estiver ausente, bloqueado ou indisponível. Um fluxo de fallback também pode ser retornado quando apropriado.

O resolvedor a seguir carrega recursos vinculados apenas de um diretório local permitido. Recursos de rede e caminhos fora do diretório permitido são bloqueados. Uma imagem de fallback opcional é retornada para links de imagem não resolvidos.

```php
class LocalSvgResourceResolver extends ExternalResourceResolver
{
    private $allowedRoot;
    private $fallbackImageData;

    public function __construct($allowedRoot, $fallbackImageData)
    {
        parent::__construct();

        $Paths = new JavaClass("java.nio.file.Paths");
        $this->allowedRoot = $Paths->get($allowedRoot)->toAbsolutePath()->normalize();
        $this->fallbackImageData = $fallbackImageData;
    }

    public function resolveUri($baseUri, $relativeUri)
    {
        if ($baseUri === null || trim(java_values($baseUri)) === "" ||
            $relativeUri === null || trim(java_values($relativeUri)) === "") {
            return null;
        }

        try {
            $URI = new JavaClass("java.net.URI");
            $baseAddress = $URI->create($baseUri);
            $absoluteAddress = $baseAddress->resolve($relativeUri);

            // Este resolvedor permite intencionalmente apenas arquivos locais.
            if (strcasecmp(java_values($absoluteAddress->getScheme()), "file") !== 0) {
                return null;
            }

            $Paths = new JavaClass("java.nio.file.Paths");
            $resourcePath = $Paths->get($absoluteAddress)->toAbsolutePath()->normalize();

            if (!$this->isInsideAllowedRoot($resourcePath)) {
                return null;
            }

            return $resourcePath->toUri()->toString();
        } catch (JavaException $e) {
            return null;
        }
    }

    public function getEntity($absoluteUri)
    {
        try {
            $URI = new JavaClass("java.net.URI");
            $resourceUri = $URI->create($absoluteUri);

            if (strcasecmp(java_values($resourceUri->getScheme()), "file") !== 0) {
                return null;
            }

            $Paths = new JavaClass("java.nio.file.Paths");
            $resourcePath = $Paths->get($resourceUri)->toAbsolutePath()->normalize();

            if (!$this->isInsideAllowedRoot($resourcePath)) {
                return null;
            }

            $Files = new JavaClass("java.nio.file.Files");
            if (java_values($Files->exists($resourcePath))) {
                return $Files->newInputStream($resourcePath);
            }

            // Use um fallback apenas para recursos de imagem. Retornar um fluxo de imagem
            // para uma fonte ou folha de estilo ausente não seria válido.
            if ($this->fallbackImageData !== null && $this->isImageFile($resourcePath)) {
                return new Java("java.io.ByteArrayInputStream", $this->fallbackImageData);
            }
        } catch (JavaException $e) {
            return null;
        }

        return null;
    }

    private function isInsideAllowedRoot($resourcePath)
    {
        return java_values($resourcePath->normalize()->startsWith($this->allowedRoot));
    }

    private function isImageFile($path)
    {
        $fileName = strtolower(java_values($path->getFileName()->toString()));

        return str_ends_with($fileName, ".png") ||
            str_ends_with($fileName, ".jpg") ||
            str_ends_with($fileName, ".jpeg") ||
            str_ends_with($fileName, ".gif") ||
            str_ends_with($fileName, ".bmp");
    }
}
```

### **Resolver Recursos Vinculados Durante a Importação de SVG**

Presuma que `assets/diagram.svg` contenha uma referência relativa como:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

O exemplo PHP a seguir passa o URI do arquivo SVG como URI base e fornece um resolvedor personalizado. O resolvedor converte o link de imagem relativo em um URI absoluto e retorna um fluxo contendo o recurso vinculado enquanto o Aspose.Slides processa o SVG.

```php
$Paths = new JavaClass("java.nio.file.Paths");
$Files = new JavaClass("java.nio.file.Files");
$StandardCharsets = new JavaClass("java.nio.charset.StandardCharsets");

$svgFilePath = $Paths->get("assets", "diagram.svg")->toAbsolutePath()->normalize();
$assetDirectory = $svgFilePath->getParent();

$svgData = $Files->readAllBytes($svgFilePath);
$svgContent = new Java("java.lang.String", $svgData, $StandardCharsets->UTF_8);

// O URI base representa a localização do documento SVG.
$baseUri = $svgFilePath->toUri()->toString();

$fallbackImageData = null;
$fallbackImagePath = $assetDirectory->resolve("fallback.png");
if (java_values($Files->exists($fallbackImagePath))) {
    $fallbackImageData = $Files->readAllBytes($fallbackImagePath);
}

$resolver = new LocalSvgResourceResolver(java_values($assetDirectory->toString()), $fallbackImageData);
$svgImage = new SvgImage($svgContent, $resolver, $baseUri);

// O objeto de imagem SVG expõe o conteúdo fonte, os dados binários, o URI base e o resolvedor.
$importedContent = $svgImage->getSvgContent();
$importedData = $svgImage->getSvgData();
$importedBaseUri = $svgImage->getBaseUri();
$importedResolver = $svgImage->getExternalResourceResolver();

$presentation = new Presentation();
try {
    $image = $presentation->getImages()->addImage($svgImage);

    $presentation->getSlides()->get_Item(0)->getShapes()->addPictureFrame(
        ShapeType::Rectangle,
        20,
        20,
        $image->getWidth(),
        $image->getHeight(),
        $image
    );

    $presentation->save("svg-with-linked-resources.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

A classe `SvgImage` também fornece sobrecargas que aceitam dados SVG como um array de bytes ou um stream de entrada, juntamente com um resolvedor de recursos externos e um URI base.

{{% alert title="Importante" color="warning" %}}

O resolvedor de recursos torna recursos externos disponíveis enquanto o Aspose.Slides processa e renderiza o SVG. Ele não modifica a marcação SVG original nem incorpora automaticamente os recursos resolvidos nela.

Quando uma imagem SVG é adicionada à coleção de imagens da apresentação, o arquivo PPTX pode conter tanto a representação SVG original quanto uma imagem raster de fallback. Um recurso vinculado pode aparecer na imagem de fallback gerada enquanto um link relativo como `images/photo.png` permanece inalterado no SVG armazenado. Uma aplicação que renderiza a representação SVG nativa pode, portanto, omitir o conteúdo vinculado quando o recurso externo original não está disponível.

{{% /alert %}}

### **Criar uma Imagem SVG Portátil**

Para criar uma imagem SVG que não dependa de arquivos externos, torne o SVG autocontido antes de criar o `SvgImage`. Por exemplo, substitua URLs de imagens vinculadas por URIs `data:` que contenham os dados da imagem:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Depois que todos os recursos necessários estiverem incorporados ao conteúdo SVG, crie o `SvgImage`, adicione‑o à coleção de imagens da apresentação e insira‑o em uma moldura de imagem como mostrado no exemplo anterior.

### **Tratar Recursos Ausentes ou Bloqueados**

Retorne `null` de `resolveUri` quando um URI de recurso for inválido, proibido ou não puder ser resolvido. Retorne `null` de `getEntity` quando o recurso não puder ser lido. O Aspose.Slides continua processando o SVG sem esse recurso quando possível.

Um fluxo de fallback pode ser retornado para um recurso ausente, mas seu conteúdo deve ser compatível com o tipo de recurso solicitado. Por exemplo, retorne um fluxo de imagem apenas para uma imagem ausente, não para uma fonte ou folha de estilo.

{{% alert title="Segurança" color="warning" %}}

Não resolva caminhos de arquivo arbitrários ou URLs de rede irrestritos de arquivos SVG não confiáveis. Restrinja esquemas, diretórios e hosts permitidos. Para recursos de rede, aplique também tempos limite de conexão, limites de tamanho de resposta e validação de conteúdo.

{{% /alert %}}

## **Converter SVG em um Conjunto de Formas**

Aspose.Slides pode converter um SVG em um conjunto de formas, similar à funcionalidade correspondente no PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

Essa funcionalidade é fornecida por uma sobrecarga do método [addGroupShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shapecollection/addgroupshape/) da classe [ShapeCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shapecollection/) que aceita um objeto [SvgImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/svgimage/) como primeiro argumento.

O código de exemplo PHP a seguir mostra como usar esse método para converter um arquivo SVG em um conjunto de formas:

```php
// Nome do arquivo SVG de origem.
$svgFileName = "sample.svg";

// Nome do arquivo de apresentação de saída.
$outPptxPath = "presentation.pptx";

// Criar uma nova apresentação.
$presentation = new Presentation();
try {
    // Ler o conteúdo do arquivo SVG.
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = (new JavaClass("java.lang.Byte"))->TYPE;

    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", $svgFileName));
    try {
        $svgContent = $Array->newInstance($Byte, $dis->available());
        $dis->readFully($svgContent);
    } finally {
        if (!java_is_null($dis)) {
            $dis->close();
        }
    }

    // Criar um objeto SvgImage.
    $svgImage = new SvgImage($svgContent);

    // Obter o tamanho do slide.
    $slideSize = $presentation->getSlideSize()->getSize();

    // Converter a imagem SVG em um grupo de formas e dimensioná‑la ao tamanho do slide.
    $presentation->getSlides()->get_Item(0)->getShapes()->addGroupShape(
        $svgImage,
        0.0,
        0.0,
        $slideSize->getWidth(),
        $slideSize->getHeight()
    );

    // Salvar a apresentação no formato PPTX.
    $presentation->save($outPptxPath, SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
    $presentation->dispose();
}
```

## **Adicionar Imagens como EMF aos Slides**

Aspose.Slides for PHP via Java permite gerar imagens EMF a partir de planilhas Excel com Aspose.Cells e adicioná‑las a slides de apresentação.

O código de exemplo PHP a seguir mostra como fazer isso:

```php
$book = new Workbook("chart.xlsx");
$sheet = $book->getWorksheets()->get(0);

$options = new ImageOrPrintOptions();
$options->setHorizontalResolution(200);
$options->setVerticalResolution(200);
$options->setImageType(ImageType::EMF);

// Salvar a pasta de trabalho em um fluxo.
$sr = new SheetRender($sheet, $options);
$pres = new Presentation();
try {
    $pres->getSlides()->removeAt(0);

    for ($j = 0; $j < java_values($sr->getPageCount()); $j++) {
        $emfSheetName = "test" . $sheet->getName() . " Page" . ($j + 1) . ".out.emf";
        $sr->toImage($j, $emfSheetName);

        // Adicionar o arquivo como está para que a imagem permaneça um vetor EMF em vez de ser rasterizada.
        $picture = null;
        $imageStream = new Java("java.io.FileInputStream", $emfSheetName);
        try {
            $picture = $pres->getImages()->addImage($imageStream);
        } finally {
            $imageStream->close();
        }

        $slide = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->getByType(SlideLayoutType::Blank));
        $slide->getShapes()->addPictureFrame(
            ShapeType::Rectangle,
            0,
            0,
            $pres->getSlideSize()->getSize()->getWidth(),
            $pres->getSlideSize()->getSize()->getHeight(),
            $picture
        );
    }

    $pres->save("output.pptx", SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
    $pres->dispose();
}
```

## **Substituir Imagens na Coleção de Imagens**

Aspose.Slides permite substituir imagens armazenadas na coleção de imagens de uma apresentação, incluindo imagens usadas por formas de slide. Esta seção descreve várias maneiras de atualizar imagens na coleção. Você pode substituir uma imagem usando dados brutos de bytes, uma instância de [IImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/iimage/) ou outra imagem que já exista na coleção.

Siga os passos abaixo:

1. Carregue o arquivo de apresentação que contém imagens usando a classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/).
2. Carregue uma nova imagem de um arquivo em um array de bytes.
3. Substitua a imagem alvo pela nova imagem usando o array de bytes.
4. Na segunda abordagem, carregue a imagem em um objeto [IImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/iimage/) e substitua a imagem alvo por esse objeto.
5. Na terceira abordagem, substitua a imagem alvo por uma imagem que já exista na coleção de imagens da apresentação.
6. Grave a apresentação modificada como um arquivo PPTX.

```php
// Instanciar a classe Presentation que representa um arquivo de apresentação.
$presentation = new Presentation("sample.pptx");
try {
    // A primeira forma.
    $imagePath = (new Java("java.io.File", "image0.jpeg"))->toPath();
    $imageData = (new JavaClass("java.nio.file.Files"))->readAllBytes($imagePath);
    $oldImage = $presentation->getImages()->get_Item(0);
    $oldImage->replaceImage($imageData);

    // A segunda forma.
    $newImage = Images::fromFile("image1.png");
    try {
        $oldImage = $presentation->getImages()->get_Item(1);
        $oldImage->replaceImage($newImage);
    } finally {
        if (!java_is_null($newImage)) {
            $newImage->dispose();
        }
    }

    // A terceira forma.
    $oldImage = $presentation->getImages()->get_Item(2);
    $oldImage->replaceImage($presentation->getImages()->get_Item(3));

    // Salvar a apresentação em um arquivo.
    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Info" color="info" %}}

Com o conversor gratuito [Text to GIF](https://products.aspose.app/slides/pt/text-to-gif) da Aspose, você pode animar texto facilmente e criar GIFs a partir de texto. 

{{% /alert %}}

## **FAQ**

**A resolução original da imagem permanece intacta após a inserção?**

Sim. Os pixels originais são preservados, mas a aparência final depende de como a [imagem](/slides/pt/php-java/picture-frame/) é dimensionada no slide e de qualquer compressão aplicada ao salvar.

**Qual a melhor maneira de substituir o mesmo logotipo em dezenas de slides de uma só vez?**

Coloque o logotipo no slide mestre ou em um layout e substitua‑lo na coleção de imagens da apresentação—as atualizações se propagarão para todos os elementos que usam esse recurso.

**É possível converter um SVG inserido em formas editáveis?**

Sim. Você pode converter um SVG em um grupo de formas, após o que as partes individuais tornam‑se editáveis com as propriedades padrão de forma.

**Como definir uma imagem como fundo de vários slides ao mesmo tempo?**

[Defina a imagem como fundo](/slides/pt/php-java/presentation-background/) no slide mestre ou no layout relevante—qualquer slide que use esse mestre/layout herdará o fundo.

**Como impedir que uma apresentação se torne muito grande por causa de muitas imagens?**

Reutilize um único recurso de imagem em vez de duplicados, escolha resoluções razoáveis, aplique compressão ao salvar e mantenha gráficos repetidos no mestre quando apropriado.