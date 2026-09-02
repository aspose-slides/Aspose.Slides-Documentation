---
title: Optimizar o gerenciamento de imagens em apresentações no Android
linktitle: Gerenciar Imagens
type: docs
weight: 10
url: /pt/androidjava/image/
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
- Android
- Java
- Aspose.Slides
description: "Otimize o gerenciamento de imagens no PowerPoint e OpenDocument com Aspose.Slides para Android via Java, melhorando o desempenho e automatizando seu fluxo de trabalho."
---
## **Introdução**

Imagens tornam as apresentações mais atraentes e visualmente agradáveis. No Microsoft PowerPoint, você pode inserir fotos nos slides a partir de arquivos, da internet ou de outras fontes. Da mesma forma, o Aspose.Slides permite que você adicione imagens aos slides da apresentação de várias maneiras.

{{% alert  title="Dica" color="primary" %}} 

A Aspose fornece conversores gratuitos—[JPEG para PowerPoint](https://products.aspose.app/slides/pt/import/jpg-to-ppt) e [PNG para PowerPoint](https://products.aspose.app/slides/pt/import/png-to-ppt)—que permitem criar rapidamente apresentações a partir de imagens. 

{{% /alert %}} 

{{% alert title="Informação" color="info" %}}

Se você quiser adicionar uma imagem como moldura de foto—especialmente se planeja redimensioná‑la, aplicar efeitos ou usar outras opções padrão de formatação—consulte [Moldura de Foto](/slides/pt/androidjava/picture-frame/). 

{{% /alert %}} 

{{% alert title="Observação" color="warning" %}}

Você pode converter imagens de um formato para outro. Veja as páginas a seguir: converter [imagem para JPG](https://products.aspose.com/slides/pt/androidjava/conversion/image-to-jpg/), [JPG para imagem](https://products.aspose.com/slides/pt/androidjava/conversion/jpg-to-image/), [JPG para PNG](https://products.aspose.com/slides/pt/androidjava/conversion/jpg-to-png/), [PNG para JPG](https://products.aspose.com/slides/pt/androidjava/conversion/png-to-jpg/), [PNG para SVG](https://products.aspose.com/slides/pt/androidjava/conversion/png-to-svg/), e [SVG para PNG](https://products.aspose.com/slides/pt/androidjava/conversion/svg-to-png/).

{{% /alert %}}

O Aspose.Slides oferece suporte a imagens em formatos populares, como JPEG, PNG, BMP, GIF e outros. 

## **Adicionar imagens armazenadas localmente aos slides**

Você pode adicionar uma ou mais imagens armazenadas no seu computador a um slide da apresentação. O exemplo de código Java a seguir mostra como adicionar uma imagem a um slide:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Adicionar imagens da Web aos slides**

Se a imagem que você deseja adicionar a um slide não estiver armazenada no seu computador, pode inseri‑la diretamente da Web. 

O exemplo de código Java a seguir demonstra como adicionar uma imagem da Web a um slide:

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.net.URL;
import java.net.URLConnection;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    URL imageUrl = new URL("[REPLACE WITH URL]");
    URLConnection connection = imageUrl.openConnection();
    InputStream inputStream = connection.getInputStream();

    ByteArrayOutputStream outputStream = new ByteArrayOutputStream();
    try {
        byte[] buffer = new byte[1024];
        int read;

        while ((read = inputStream.read(buffer, 0, buffer.length)) != -1) {
            outputStream.write(buffer, 0, read);
        }

        outputStream.flush();

        IPPImage image = pres.getImages().addImage(outputStream.toByteArray());
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    } finally {
        if (inputStream != null) inputStream.close();
        outputStream.close();
    }

    pres.save("pres.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

## **Adicionar imagens a mestres de slide**

Um mestre de slide armazena e controla informações como tema e layout dos slides que o utilizam. Quando você adiciona uma imagem a um mestre de slide, a imagem aparece em todos os slides baseados nesse mestre. 

O exemplo de código Java a seguir mostra como adicionar uma imagem a um mestre de slide:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IMasterSlide masterSlide = slide.getLayoutSlide().getMasterSlide();

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    masterSlide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Adicionar imagens como planos de fundo de slides**

Você pode usar uma foto como plano de fundo de um ou mais slides. Para detalhes, consulte *[Definindo imagens como plano de fundo para slides](/slides/pt/androidjava/presentation-background/#setting-images-as-background-for-slides)*.

## **Adicionar SVG a apresentações**

O conteúdo SVG pode ser adicionado a uma apresentação usando a classe [SvgImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/svgimage/). O objeto resultante [ISvgImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/isvgimage/) pode então ser inserido na coleção de imagens da apresentação e usado para criar uma moldura de foto.

O exemplo Java a seguir importa uma string SVG autocontida. Todas as imagens, estilos e outros recursos usados por esse SVG são incorporados diretamente no conteúdo SVG.

```java
import com.aspose.slides.*;

String svgContent =
        "<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>" +
        "    <rect width='320' height='180' fill='#4F81BD'/>" +
        "    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>" +
        "</svg>";

Presentation presentation = new Presentation();
try {
    ISvgImage svgImage = new SvgImage(svgContent);
    IPPImage image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("self-contained-svg.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Importar conteúdo SVG com recursos externos**

Arquivos SVG exportados de ferramentas de design, editores de diagramas, sistemas de ícones e pipelines da Web podem referenciar recursos armazenados fora do documento SVG. Por exemplo, um SVG pode conter um link de imagem como `images/photo.png`, um valor CSS `url(...)` ou uma URL de fonte.

Para importar esse tipo de conteúdo SVG, crie uma implementação de [IExternalResourceResolver](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iexternalresourceresolver/) e passe‑a, junto com um URI base, a um construtor apropriado de [SvgImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/svgimage/). O URI base identifica a localização do documento SVG e é usado para resolver links relativos.

A interface [ISvgImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/isvgimage/) fornece acesso a informações sobre o SVG importado:

- `getSvgContent()` devolve a marcação SVG como string.
- `getSvgData()` devolve o conteúdo SVG como um array de bytes.
- `getBaseUri()` devolve o URI base usado para links relativos.
- `getExternalResourceResolver()` devolve o resolvedor atribuído à imagem SVG.

### **Implementar um resolvedor de recursos externos**

O resolvedor possui dois métodos:

- `resolveUri` combina o URI base e um link de recurso relativo e devolve um URI absoluto. Retorne `null` quando o link não puder ser resolvido ou não for permitido.
- `getEntity` devolve um fluxo legível para um URI de recurso absoluto. Retorne `null` quando o recurso estiver ausente, bloqueado ou indisponível. Um fluxo de fallback também pode ser devolvido quando apropriado.

O resolvedor a seguir carrega recursos vinculados apenas de um diretório local permitido. Recursos de rede e caminhos fora do diretório permitido são bloqueados. Uma imagem de fallback opcional é devolvida para links de imagem não resolvidos.

```java
import com.aspose.slides.ExternalResourceResolver;

import java.io.ByteArrayInputStream;
import java.io.InputStream;
import java.net.URI;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Locale;

class LocalSvgResourceResolver extends ExternalResourceResolver {
    private final Path allowedRoot;
    private final byte[] fallbackImageData;

    public LocalSvgResourceResolver(String allowedRoot, byte[] fallbackImageData) {
        this.allowedRoot = Paths.get(allowedRoot).toAbsolutePath().normalize();
        this.fallbackImageData = fallbackImageData;
    }

    @Override
    public String resolveUri(String baseUri, String relativeUri) {
        if (baseUri == null || baseUri.trim().isEmpty() ||
                relativeUri == null || relativeUri.trim().isEmpty()) {
            return null;
        }

        try {
            URI baseAddress = URI.create(baseUri);
            URI absoluteAddress = baseAddress.resolve(relativeUri);

            // Este resolvedor permite intencionalmente apenas arquivos locais.
            if (!"file".equalsIgnoreCase(absoluteAddress.getScheme())) {
                return null;
            }

            Path resourcePath = Paths.get(absoluteAddress).toAbsolutePath().normalize();
            if (!isInsideAllowedRoot(resourcePath)) {
                return null;
            }

            return resourcePath.toUri().toString();
        } catch (Exception e) {
            return null;
        }
    }

    @Override
    public InputStream getEntity(String absoluteUri) {
        try {
            URI resourceUri = URI.create(absoluteUri);
            if (!"file".equalsIgnoreCase(resourceUri.getScheme())) {
                return null;
            }

            Path resourcePath = Paths.get(resourceUri).toAbsolutePath().normalize();
            if (!isInsideAllowedRoot(resourcePath)) {
                return null;
            }

            if (Files.exists(resourcePath)) {
                return Files.newInputStream(resourcePath);
            }

            // Use um fallback apenas para recursos de imagem. Retornar um fluxo de imagem
            // para uma fonte ou folha de estilo ausente não seria válido.
            if (fallbackImageData != null && isImageFile(resourcePath)) {
                return new ByteArrayInputStream(fallbackImageData);
            }
        } catch (Exception e) {
            return null;
        }

        return null;
    }

    private boolean isInsideAllowedRoot(Path resourcePath) {
        return resourcePath.normalize().startsWith(allowedRoot);
    }

    private static boolean isImageFile(Path path) {
        String fileName = path.getFileName().toString().toLowerCase(Locale.ROOT);

        return fileName.endsWith(".png") ||
                fileName.endsWith(".jpg") ||
                fileName.endsWith(".jpeg") ||
                fileName.endsWith(".gif") ||
                fileName.endsWith(".bmp");
    }
}
```

### **Resolver recursos vinculados durante a importação de SVG**

Suponha que `assets/diagram.svg` contenha uma referência relativa como:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

O exemplo Java a seguir passa o URI do arquivo SVG como URI base e fornece um resolvedor personalizado. O resolvedor converte o link de imagem relativo em um URI absoluto e devolve um fluxo contendo o recurso vinculado enquanto o Aspose.Slides processa o SVG.

```java
import com.aspose.slides.*;

import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Path svgFilePath = Paths.get("assets", "diagram.svg").toAbsolutePath().normalize();
Path assetDirectory = svgFilePath.getParent();
String svgContent = new String(Files.readAllBytes(svgFilePath), StandardCharsets.UTF_8);

// O URI base representa a localização do documento SVG.
String baseUri = svgFilePath.toUri().toString();

byte[] fallbackImageData = null;
Path fallbackImagePath = assetDirectory.resolve("fallback.png");
if (Files.exists(fallbackImagePath)) {
    fallbackImageData = Files.readAllBytes(fallbackImagePath);
}

IExternalResourceResolver resolver = new LocalSvgResourceResolver(assetDirectory.toString(), fallbackImageData);
ISvgImage svgImage = new SvgImage(svgContent, resolver, baseUri);

// ISvgImage expõe o conteúdo fonte, os dados binários, o URI base e o resolvedor.
String importedContent = svgImage.getSvgContent();
byte[] importedData = svgImage.getSvgData();
String importedBaseUri = svgImage.getBaseUri();
IExternalResourceResolver importedResolver = svgImage.getExternalResourceResolver();

Presentation presentation = new Presentation();
try {
    IPPImage image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("svg-with-linked-resources.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A classe `SvgImage` também fornece sobrecargas que aceitam dados SVG como array de bytes ou fluxo de entrada, juntamente com um resolvedor de recursos externos e um URI base.

{{% alert title="Importante" color="warning" %}}

O resolvedor de recursos disponibiliza recursos externos enquanto o Aspose.Slides processa e renderiza o SVG. Ele não modifica a marcação SVG original nem incorpora automaticamente os recursos resolvidos nele.

Quando um `ISvgImage` é adicionado à coleção de imagens da apresentação, o arquivo PPTX pode conter tanto a representação SVG original quanto uma imagem raster de fallback. Um recurso vinculado pode aparecer na imagem de fallback gerada, enquanto um link relativo como `images/photo.png` permanece inalterado no SVG armazenado. Uma aplicação que renderiza a representação SVG nativa pode, portanto, omitir o conteúdo vinculado quando o recurso externo original não estiver disponível.

{{% /alert %}}

### **Criar uma imagem SVG portátil**

Para criar uma imagem SVG que não dependa de arquivos externos, torne o SVG autocontido antes de criar o `SvgImage`. Por exemplo, substitua URLs de imagens vinculadas por URIs `data:` que contenham os dados da imagem:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Depois que todos os recursos necessários estiverem incorporados ao conteúdo SVG, crie o `SvgImage`, adicione‑o à coleção de imagens da apresentação e insira‑o em uma moldura de foto como mostrado no exemplo anterior.

### **Tratar recursos ausentes ou bloqueados**

Retorne `null` de `resolveUri` quando um URI de recurso for inválido, proibido ou não puder ser resolvido. Retorne `null` de `getEntity` quando o recurso não puder ser lido. O Aspose.Slides continua o processamento do SVG sem esse recurso sempre que possível.

Um fluxo de fallback pode ser devolvido para um recurso ausente, mas seu conteúdo deve ser compatível com o tipo de recurso solicitado. Por exemplo, devolva um fluxo de imagem apenas para uma imagem ausente, não para uma fonte ou folha de estilos.

{{% alert title="Segurança" color="warning" %}}

Não resolva caminhos de arquivo arbitrários ou URLs de rede ilimitadas a partir de arquivos SVG não confiáveis. Restrinja esquemas, diretórios e hosts permitidos. Para recursos de rede, aplique também limites de tempo de conexão, tamanhos de resposta e validação de conteúdo.

{{% /alert %}}

## **Converter SVG em um conjunto de formas**

O Aspose.Slides pode converter um SVG em um conjunto de formas, similar à funcionalidade correspondente no PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

Essa funcionalidade é fornecida por uma sobrecarga do método [addGroupShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) da interface [IShapeCollection](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IShapeCollection) que aceita um objeto [ISvgImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ISvgImage) como primeiro argumento.

O exemplo de código Java a seguir mostra como usar esse método para converter um arquivo SVG em um conjunto de formas:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

// Nome do arquivo SVG de origem.
String svgFileName = "sample.svg";

// Nome do arquivo de apresentação de saída.
String outPptxPath = "presentation.pptx";

// Criar uma nova apresentação.
IPresentation presentation = new Presentation();
try {
    // Ler o conteúdo do arquivo SVG.
    byte[] svgContent = Files.readAllBytes(Paths.get(svgFileName));

    // Criar um objeto SvgImage.
    ISvgImage svgImage = new SvgImage(svgContent);

    // Obter o tamanho do slide.
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // Converter a imagem SVG em um grupo de formas e dimensioná‑la ao tamanho do slide.
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(
            svgImage, 0f, 0f,
            (float) slideSize.getWidth(), (float) slideSize.getHeight());

    // Salvar a apresentação no formato PPTX.
    presentation.save(outPptxPath, SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    presentation.dispose();
}
```

## **Adicionar imagens como EMF aos slides**

O Aspose.Slides for Android via Java permite gerar imagens EMF a partir de planilhas Excel com o Aspose.Cells e adicioná‑las aos slides da apresentação.

O exemplo de código Java a seguir demonstra como fazer isso:

```java
import com.aspose.slides.*;
import com.aspose.cells.ImageOrPrintOptions;
import com.aspose.cells.ImageType;
import com.aspose.cells.SheetRender;
import com.aspose.cells.Workbook;
import com.aspose.cells.Worksheet;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStream;

Workbook book = new Workbook("chart.xlsx");
Worksheet sheet = book.getWorksheets().get(0);

ImageOrPrintOptions options = new ImageOrPrintOptions();
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(ImageType.EMF);

// Salvar a pasta de trabalho em um fluxo.
SheetRender sr = new SheetRender(sheet, options);
Presentation pres = new Presentation();
try {
    pres.getSlides().removeAt(0);

    String emfSheetName;
    for (int j = 0; j < sr.getPageCount(); j++) {
        emfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, emfSheetName);

        // Adicionar o arquivo como está para que a imagem permaneça um vetor EMF em vez de ser rasterizada.
        IPPImage picture;
        InputStream imageStream = new FileInputStream(emfSheetName);
        try {
            picture = pres.getImages().addImage(imageStream);
        } finally {
            imageStream.close();
        }

        ISlide slide = pres.getSlides().addEmptySlide(
                pres.getLayoutSlides().getByType(SlideLayoutType.Blank));
        slide.getShapes().addPictureFrame(
                ShapeType.Rectangle,
                0,
                0,
                (float) pres.getSlideSize().getSize().getWidth(),
                (float) pres.getSlideSize().getSize().getHeight(),
                picture);
    }

    pres.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

## **Substituir imagens na coleção de imagens**

O Aspose.Slides permite substituir imagens armazenadas na coleção de imagens de uma apresentação, inclusive imagens usadas por formas de slide. Esta seção descreve várias formas de atualizar imagens na coleção. Você pode substituir uma imagem usando dados brutos de bytes, uma instância de [IImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iimage/) ou outra imagem que já exista na coleção.

Siga os passos abaixo:

1. Carregue o arquivo da apresentação que contém imagens usando a classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/).
1. Carregue uma nova imagem de um arquivo em um array de bytes.
1. Substitua a imagem alvo pela nova imagem usando o array de bytes.
1. Na segunda abordagem, carregue a imagem em um objeto [IImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iimage/) e substitua a imagem alvo por esse objeto.
1. Na terceira abordagem, substitua a imagem alvo por uma imagem que já exista na coleção de imagens da apresentação.
1. Grave a apresentação modificada como um arquivo PPTX.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

// Instanciar a classe Presentation que representa um arquivo de apresentação.
Presentation presentation = new Presentation("sample.pptx");
try {
    // A primeira forma.
    byte[] imageData = Files.readAllBytes(Paths.get("image0.jpeg"));
    IPPImage oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);

    // A segunda forma.
    IImage newImage = Images.fromFile("image1.png");
    try {
        oldImage = presentation.getImages().get_Item(1);
        oldImage.replaceImage(newImage);
    } finally {
        if (newImage != null) newImage.dispose();
    }

    // A terceira forma.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));

    // Salvar a apresentação em um arquivo.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Informação" color="info" %}}

Com o conversor gratuito [Texto para GIF](https://products.aspose.app/slides/pt/text-to-gif) da Aspose, você pode animar texto facilmente e criar GIFs a partir de texto. 

{{% /alert %}}

## **FAQ**

**A resolução original da imagem permanece intacta após a inserção?**

Sim. Os pixels de origem são preservados, mas a aparência final depende de como o [picture](/slides/pt/androidjava/picture-frame/) é dimensionado no slide e de qualquer compressão aplicada ao salvar.

**Qual a melhor maneira de substituir o mesmo logotipo em dezenas de slides de uma vez?**

Coloque o logotipo no mestre de slide ou em um layout e substitua‑o na coleção de imagens da apresentação—as atualizações se propagarão para todos os elementos que utilizam esse recurso.

**Um SVG inserido pode ser convertido em formas editáveis?**

Sim. Você pode converter um SVG em um grupo de formas, após o qual as partes individuais se tornam editáveis com as propriedades padrão de forma.

**Como definir uma imagem como plano de fundo para vários slides ao mesmo tempo?**

[Defina a imagem como plano de fundo](/slides/pt/androidjava/presentation-background/) no mestre de slide ou no layout relevante—qualquer slide que use esse mestre/layout herdará o plano de fundo.

**Como evitar que uma apresentação fique muito grande por causa de muitas imagens?**

Reutilize um único recurso de imagem em vez de duplicatas, escolha resoluções razoáveis, aplique compressão ao salvar e mantenha gráficos repetidos no mestre quando apropriado.