---
title: Otimizar o Gerenciamento de Imagens em Apresentações Usando JavaScript
linktitle: Gerenciar Imagens
type: docs
weight: 10
url: /pt/nodejs-java/image/
keywords:
- adicionar imagem
- adicionar foto
- adicionar bitmap
- substituir imagem
- substituir foto
- da web
- plano de fundo
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Otimize o gerenciamento de imagens no PowerPoint e OpenDocument com Aspose.Slides for Node.js via Java, melhorando o desempenho e automatizando seu fluxo de trabalho."
---
## **Introdução**

Imagens tornam as apresentações mais envolventes e visualmente atraentes. No Microsoft PowerPoint, você pode inserir imagens nos slides a partir de arquivos, da internet ou de outras fontes. Da mesma forma, o Aspose.Slides permite adicionar imagens aos slides de apresentação de várias maneiras.

{{% alert  title="Tip" color="primary" %}} 
A Aspose oferece conversores gratuitos—[JPEG to PowerPoint](https://products.aspose.app/slides/pt/import/jpg-to-ppt) e [PNG to PowerPoint](https://products.aspose.app/slides/pt/import/png-to-ppt)—que permitem criar apresentações rapidamente a partir de imagens. 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
Se você deseja adicionar uma imagem como quadro de foto—especialmente se planeja redimensioná‑la, aplicar efeitos ou usar outras opções padrão de formatação—consulte [Picture Frame](/slides/pt/nodejs-java/picture-frame/). 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}}
Você pode converter imagens de um formato para outro. Consulte as páginas a seguir: convert [image to JPG](https://products.aspose.com/slides/pt/nodejs-java/conversion/image-to-jpg/), [JPG to image](https://products.aspose.com/slides/pt/nodejs-java/conversion/jpg-to-image/), [JPG to PNG](https://products.aspose.com/slides/pt/nodejs-java/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/pt/nodejs-java/conversion/png-to-jpg/), [PNG to SVG](https://products.aspose.com/slides/pt/nodejs-java/conversion/png-to-svg/), e [SVG to PNG](https://products.aspose.com/slides/pt/nodejs-java/conversion/svg-to-png/).
{{% /alert %}}

Aspose.Slides suporta imagens em formatos populares como JPEG, PNG, BMP, GIF e outros. 

## **Adicionar Imagens Armazenadas Localmente aos Slides**

Você pode adicionar uma ou mais imagens armazenadas no seu computador a um slide de apresentação. O código de exemplo JavaScript a seguir mostra como adicionar uma imagem a um slide:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);

    let picture;
    const image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }

    slide.getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Adicionar Imagens da Web aos Slides**

Se a imagem que você deseja adicionar a um slide não estiver armazenada no seu computador, você pode adicioná‑la diretamente da web. 

O código de exemplo JavaScript a seguir mostra como adicionar uma imagem da web a um slide:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);

    const imageUrl = java.newInstanceSync("java.net.URL", "[REPLACE WITH URL]");
    const inputStream = imageUrl.openStream();
    try {
        let picture;
        const image = aspose.slides.Images.fromStream(inputStream);
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) {
                image.dispose();
            }
        }

        slide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    } finally {
        if (inputStream != null) {
            inputStream.close();
        }
    }

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Adicionar Imagens a Mestres de Slide**

Um mestre de slide armazena e controla informações como o tema e o layout dos slides que o utilizam. Quando você adiciona uma imagem a um mestre de slide, a imagem aparece em todos os slides baseados nesse mestre. 

O código de exemplo JavaScript a seguir mostra como adicionar uma imagem a um mestre de slide:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);
    const masterSlide = slide.getLayoutSlide().getMasterSlide();

    let picture;
    const image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }

    masterSlide.getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Adicionar Imagens como Plano de Fundo dos Slides**

Você pode usar uma imagem como plano de fundo de um ou mais slides. Para detalhes, veja *[Setting Images as Backgrounds for Slides](/slides/pt/nodejs-java/presentation-background/#setting-images-as-background-for-slides)*.

## **Adicionar SVG às Apresentações**

Conteúdo SVG pode ser adicionado a uma apresentação usando a classe [SvgImage](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/svgimage/). O objeto de imagem SVG resultante pode então ser adicionado à coleção de imagens da apresentação e usado para criar um quadro de foto.

O exemplo JavaScript a seguir importa uma string SVG autônoma. Todas as imagens, estilos e outros recursos usados por esse SVG são incorporados diretamente no conteúdo SVG.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const svgContent =
    "<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>" +
    "    <rect width='320' height='180' fill='#4F81BD'/>" +
    "    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>" +
    "</svg>";

const presentation = new aspose.slides.Presentation();
try {
    const svgImage = new aspose.slides.SvgImage(svgContent);
    const image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle,
        20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("self-contained-svg.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Importar Conteúdo SVG com Recursos Externos**

Arquivos SVG exportados de ferramentas de design, editores de diagramas, sistemas de ícones e pipelines da web podem referenciar recursos que estão armazenados fora do documento SVG. Por exemplo, um SVG pode conter um link de imagem como `images/photo.png`, um valor CSS `url(...)` ou uma URL de fonte.

Para importar esse conteúdo SVG, forneça um resolvedor de recursos externo e passe‑o, juntamente com uma URI base, para um construtor apropriado de [SvgImage](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/svgimage/). A URI base identifica a localização do documento SVG e é usada para resolver links relativos.

A classe `SvgImage` fornece acesso a informações sobre o SVG importado:

- `getSvgContent()` retorna a marcação SVG como uma string.
- `getSvgData()` retorna o conteúdo SVG como um array de bytes.
- `getBaseUri()` retorna a URI base usada para links relativos.
- `getExternalResourceResolver()` retorna o resolvedor atribuído à imagem SVG.

### **Implementar um Resolvedor de Recursos Externos**

O resolvedor tem dois métodos:

- `resolveUri` combina a URI base e um link de recurso relativo e retorna uma URI absoluta. Retorne `null` quando o link não puder ser resolvido ou não for permitido.
- `getEntity` retorna um stream Java legível para uma URI de recurso absoluta. Retorne `null` quando o recurso estiver ausente, bloqueado ou indisponível. Um stream de fallback também pode ser retornado quando apropriado.

O helper a seguir cria um resolvedor que carrega recursos vinculados somente de um diretório local permitido. Recursos de rede e caminhos fora do diretório permitido são bloqueados. Uma imagem de fallback opcional é retornada para links de imagem não resolvidos.

```javascript
const fs = require("fs");
const path = require("path");
const java = require("java");
const { fileURLToPath, pathToFileURL } = require("url");

function isInsideAllowedRoot(resourcePath, allowedRoot) {
    const relativePath = path.relative(allowedRoot, resourcePath);

    return relativePath === "" ||
        (relativePath !== ".." &&
         !relativePath.startsWith(".." + path.sep) &&
         !path.isAbsolute(relativePath));
}

function isImageFile(filePath) {
    const extension = path.extname(filePath).toLowerCase();
    return [".png", ".jpg", ".jpeg", ".gif", ".bmp"].includes(extension);
}

function createLocalSvgResourceResolver(allowedRoot, fallbackImageData) {
    const normalizedRoot = path.resolve(allowedRoot);

    return java.newProxy("com.aspose.slides.IExternalResourceResolver", {
        resolveUri: function(baseUri, relativeUri) {
            if (baseUri == null || baseUri.trim() === "" ||
                    relativeUri == null || relativeUri.trim() === "") {
                return null;
            }

            try {
                const absoluteAddress = new URL(relativeUri, baseUri);

                // Este resolvedor permite intencionalmente apenas arquivos locais.
                if (absoluteAddress.protocol !== "file:") {
                    return null;
                }

                const resourcePath = path.resolve(fileURLToPath(absoluteAddress));
                if (!isInsideAllowedRoot(resourcePath, normalizedRoot)) {
                    return null;
                }

                return pathToFileURL(resourcePath).href;
            } catch (e) {
                return null;
            }
        },

        getEntity: function(absoluteUri) {
            try {
                const resourceUrl = new URL(absoluteUri);
                if (resourceUrl.protocol !== "file:") {
                    return null;
                }

                const resourcePath = path.resolve(fileURLToPath(resourceUrl));
                if (!isInsideAllowedRoot(resourcePath, normalizedRoot)) {
                    return null;
                }

                if (fs.existsSync(resourcePath)) {
                    return java.newInstanceSync("java.io.FileInputStream", resourcePath);
                }

                // Use um fallback apenas para recursos de imagem. Retornar um stream de imagem
                // para uma fonte ou folha de estilo ausente não seria válido.
                if (fallbackImageData != null && isImageFile(resourcePath)) {
                    const javaBytes = java.newArray("byte", Array.from(fallbackImageData));
                    return java.newInstanceSync("java.io.ByteArrayInputStream", javaBytes);
                }
            } catch (e) {
                return null;
            }

            return null;
        }
    });
}
```

### **Resolver Recursos Vinculados Durante a Importação de SVG**

Assuma que `assets/diagram.svg` contém uma referência relativa como:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

O exemplo JavaScript a seguir passa a URI do arquivo SVG como a URI base e fornece um resolvedor personalizado. O resolvedor converte o link de imagem relativo em uma URI absoluta e retorna um stream contendo o recurso vinculado enquanto o Aspose.Slides processa o SVG.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const path = require("path");
const { pathToFileURL } = require("url");

const svgFilePath = path.resolve("assets", "diagram.svg");
const assetDirectory = path.dirname(svgFilePath);
const svgContent = fs.readFileSync(svgFilePath, "utf8");

// A URI base representa a localização do documento SVG.
const baseUri = pathToFileURL(svgFilePath).href;

let fallbackImageData = null;
const fallbackImagePath = path.join(assetDirectory, "fallback.png");
if (fs.existsSync(fallbackImagePath)) {
    fallbackImageData = fs.readFileSync(fallbackImagePath);
}

const resolver = createLocalSvgResourceResolver(assetDirectory, fallbackImageData);
const svgImage = new aspose.slides.SvgImage(svgContent, resolver, baseUri);

// SvgImage expõe o conteúdo fonte, os dados binários, a URI base e o resolvedor.
const importedContent = svgImage.getSvgContent();
const importedData = svgImage.getSvgData();
const importedBaseUri = svgImage.getBaseUri();
const importedResolver = svgImage.getExternalResourceResolver();

const presentation = new aspose.slides.Presentation();
try {
    const image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle,
        20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("svg-with-linked-resources.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A classe `SvgImage` também oferece sobrecargas que aceitam dados SVG como um array de bytes, bem como métodos de fábrica baseados em streams, juntamente com um resolvedor de recursos externo e uma URI base.

{{% alert title="Important" color="warning" %}}
O resolvedor de recursos disponibiliza recursos externos enquanto o Aspose.Slides processa e renderiza o SVG. Ele não modifica a marcação SVG original nem incorpora automaticamente os recursos resolvidos nela.

Quando uma imagem SVG é adicionada à coleção de imagens da apresentação, o arquivo PPTX pode conter tanto a representação SVG original quanto uma imagem raster de fallback. Um recurso vinculado pode aparecer na imagem de fallback gerada, enquanto um link relativo como `images/photo.png` permanece inalterado no SVG armazenado. Um aplicativo que renderiza a representação SVG nativa pode, portanto, omitir o conteúdo vinculado quando o recurso externo original não estiver disponível.
{{% /alert %}}

### **Criar uma Imagem SVG Portátil**

Para criar uma imagem SVG que não dependa de arquivos externos, torne o SVG autônomo antes de criar o `SvgImage`. Por exemplo, substitua URLs de imagens vinculadas por URIs `data:` que contenham os dados da imagem:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Depois que todos os recursos necessários estiverem incorporados no conteúdo SVG, crie o `SvgImage`, adicione-o à coleção de imagens da apresentação e insira-o em um quadro de foto conforme mostrado no exemplo anterior.

### **Manipular Recursos Ausentes ou Bloqueados**

Retorne `null` de `resolveUri` quando uma URI de recurso for inválida, proibida ou não puder ser resolvida. Retorne `null` de `getEntity` quando o recurso não puder ser lido. O Aspose.Slides continua processando o SVG sem esse recurso quando possível.

Um stream de fallback pode ser retornado para um recurso ausente, mas seu conteúdo deve ser compatível com o tipo de recurso solicitado. Por exemplo, retorne um stream de imagem apenas para uma imagem ausente, não para uma fonte ou folha de estilo.

{{% alert title="Security" color="warning" %}}
Não resolva caminhos de arquivos arbitrários ou URLs de rede sem restrições a partir de arquivos SVG não confiáveis. Restrinja esquemas, diretórios e hosts permitidos. Para recursos de rede, aplique também limites de tempo de conexão, tamanho de resposta e validação de conteúdo.
{{% /alert %}}

## **Converter SVG em um Conjunto de Formas**

Aspose.Slides pode converter um SVG em um conjunto de formas, similar à funcionalidade correspondente no PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

Essa funcionalidade é fornecida por uma sobrecarga do método [addGroupShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ShapeCollection#addGroupShape-aspose.slides.ISvgImage-float-float-float-float-) da classe [ShapeCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ShapeCollection) que recebe um objeto de imagem SVG como seu primeiro argumento.

O código de exemplo JavaScript a seguir mostra como usar este método para converter um arquivo SVG em um conjunto de formas:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

// Nome do arquivo SVG de origem.
const svgFileName = "sample.svg";

// Nome do arquivo de apresentação de saída.
const outPptxPath = "presentation.pptx";

// Criar uma nova apresentação.
const presentation = new aspose.slides.Presentation();
try {
    // Ler o conteúdo do arquivo SVG.
    const svgContent = java.newArray("byte", Array.from(fs.readFileSync(svgFileName)));

    // Criar um objeto SvgImage.
    const svgImage = new aspose.slides.SvgImage(svgContent);

    // Obter o tamanho do slide.
    const slideSize = presentation.getSlideSize().getSize();

    // Converter a imagem SVG em um grupo de formas e dimensioná‑la ao tamanho do slide.
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(
        svgImage, 0.0, 0.0, slideSize.getWidth(), slideSize.getHeight());

    // Salvar a apresentação no formato PPTX.
    presentation.save(outPptxPath, aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Adicionar Imagens como EMF aos Slides**

Aspose.Slides for Node.js via Java permite gerar imagens EMF a partir de planilhas Excel com Aspose.Cells e adicioná‑las aos slides de apresentação.

O código de exemplo JavaScript a seguir mostra como fazer isso:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const book = java.newInstanceSync("aspose.cells.Workbook", "chart.xlsx");
const sheet = book.getWorksheets().get(0);

const options = java.newInstanceSync("aspose.cells.ImageOrPrintOptions");
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(java.getStaticFieldValue("ImageType", "EMF"));

// Salvar a pasta de trabalho em um stream.
const sr = java.newInstanceSync("SheetRender", sheet, options);
const pres = new aspose.slides.Presentation();
try {
    pres.getSlides().removeAt(0);

    for (let j = 0; j < sr.getPageCount(); j++) {
        const emfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, emfSheetName);

        // Adicionar o arquivo como está para que a imagem permaneça um EMF vetorial em vez de ser rasterizada.
        let picture;
        const imageStream = java.newInstanceSync("java.io.FileInputStream", emfSheetName);
        try {
            picture = pres.getImages().addImage(imageStream);
        } finally {
            imageStream.close();
        }

        const slide = pres.getSlides().addEmptySlide(
            pres.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank));
        slide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle,
            0,
            0,
            pres.getSlideSize().getSize().getWidth(),
            pres.getSlideSize().getSize().getHeight(),
            picture);
    }

    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Substituir Imagens na Coleção de Imagens**

Aspose.Slides permite substituir imagens armazenadas na coleção de imagens de uma apresentação, inclusive imagens usadas por formas de slide. Esta seção descreve várias maneiras de atualizar imagens na coleção. Você pode substituir uma imagem usando dados brutos de bytes, uma instância de [IImage](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/iimage/) ou outra imagem que já exista na coleção.

Siga os passos abaixo:

1. Carregue o arquivo de apresentação que contém imagens usando a classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/).
1. Carregue uma nova imagem a partir de um arquivo em um array de bytes.
1. Substitua a imagem alvo pela nova imagem usando o array de bytes.
1. Na segunda abordagem, carregue a imagem em um objeto [IImage](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/iimage/) e substitua a imagem alvo por esse objeto.
1. Na terceira abordagem, substitua a imagem alvo por uma imagem que já exista na coleção de imagens da apresentação.
1. Grave a apresentação modificada como um arquivo PPTX.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

// Instanciar a classe Presentation que representa um arquivo de apresentação.
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // A primeira forma.
    const imageData = java.newArray("byte", Array.from(fs.readFileSync("image0.jpeg")));
    let oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);

    // A segunda forma.
    const newImage = aspose.slides.Images.fromFile("image1.png");
    try {
        oldImage = presentation.getImages().get_Item(1);
        oldImage.replaceImage(newImage);
    } finally {
        if (newImage != null) {
            newImage.dispose();
        }
    }

    // A terceira forma.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));

    // Salvar a apresentação em um arquivo.
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
Com o conversor gratuito da Aspose [Text to GIF](https://products.aspose.app/slides/pt/text-to-gif), você pode animar texto facilmente e criar GIFs a partir de texto. 
{{% /alert %}}

## **Perguntas Frequentes**

**A resolução original da imagem permanece intacta após a inserção?**

Sim. Os pixels originais são preservados, mas a aparência final depende de como o [picture](/slides/pt/nodejs-java/picture-frame/) é dimensionado no slide e de qualquer compressão aplicada ao salvar.

**Qual a melhor maneira de substituir o mesmo logotipo em dezenas de slides de uma só vez?**

Coloque o logotipo no slide mestre ou em um layout e substitua‑lo na coleção de imagens da apresentação — as atualizações serão propagadas para todos os elementos que utilizam esse recurso.

**Um SVG inserido pode ser convertido em formas editáveis?**

Sim. Você pode converter um SVG em um grupo de formas, após o qual as partes individuais tornam‑se editáveis com as propriedades padrão de forma.

**Como posso definir uma imagem como plano de fundo de vários slides de uma só vez?**

[Atribua a imagem como plano de fundo](/slides/pt/nodejs-java/presentation-background/) no slide mestre ou no layout relevante — quaisquer slides que utilizem esse mestre/layout herdarão o plano de fundo.

**Como evito que uma apresentação se torne muito grande por causa de muitas imagens?**

Reutilize um único recurso de imagem em vez de duplicatas, escolha resoluções razoáveis, aplique compressão ao salvar e mantenha gráficos repetidos no mestre quando apropriado.