---
title: Otimizar o Gerenciamento de Imagens em Apresentações no Android
linktitle: Gerenciar Imagens
type: docs
weight: 10
url: /pt/androidjava/image/
keywords:
- adicionar imagem
- adicionar foto
- substituir imagem
- coleção de imagens
- quadro de imagem
- imagem vinculada
- plano de fundo
- adicionar PNG
- adicionar JPG
- adicionar SVG
- SVG para formas
- recursos SVG externos
- PowerPoint
- OpenDocument
- apresentação
- Android
- Java
- Aspose.Slides
description: "Saiba como adicionar, reutilizar, vincular, substituir e gerenciar imagens raster e SVG em apresentações PowerPoint e OpenDocument com Aspose.Slides para Android via Java."
---
## **Introdução**

Aspose.Slides for Android via Java oferece várias maneiras de trabalhar com imagens, e cada uma serve a um propósito diferente. Você pode armazenar uma imagem em uma apresentação, exibí‑la em um quadro de imagem, usá‑la como plano de fundo de slide, vincular a uma imagem externa, substituir um recurso de imagem compartilhado ou converter conteúdo SVG em formas editáveis.

Este artigo foca nos recursos de imagem e como eles são usados em toda a apresentação. Para recorte, transparência, efeitos, esticamento e outras formatações aplicadas a um quadro de imagem individual, veja [Quadro de Imagem](/slides/pt/androidjava/picture-frame/).

## **Entender o Modelo de Imagem**

Os conceitos de API a seguir são intimamente relacionados, mas não intercambiáveis:

- A [coleção de imagens da apresentação](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iimagecollection/) armazena recursos de imagem usados pela apresentação. Use [ImageCollection.addImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/imagecollection/) para adicionar dados de imagem e obter um recurso [IPPImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ippimage/).
- Um [quadro de imagem](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ipictureframe/) é uma forma que exibe uma imagem em um slide, layout ou mestre. Use [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ishapecollection/) para colocar um recurso de imagem em um slide.
- Um plano de fundo de slide usa uma imagem como parte do preenchimento do slide, e não como uma forma. Portanto, não se comporta como um quadro de imagem.
- [IPPImage.replaceImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ippimage/) substitui um recurso de imagem. Se vários elementos da apresentação usarem esse recurso, todos usarão a substituição.
- Converter um SVG em formas cria formas editáveis de slide. Após a conversão, o conteúdo deixa de ser gerenciado como um único recurso de imagem.

Um fluxo de trabalho típico, portanto, é: adicionar dados de imagem à coleção de imagens, receber um [IPPImage](/slides/pt/androidjava/com.aspose.slides/ippimage/), e então usar esse recurso em um ou mais quadros de imagem ou preenchimentos.

## **Adicionar uma Imagem Incorporada**

Para inserir uma imagem local, carregue o arquivo, adicione‑a à coleção de imagens e crie um quadro de imagem que use o `IPPImage` retornado.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) sourceImage.dispose();
    }

    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);

    presentation.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A imagem adicionada desta forma é incorporada na apresentação, de modo que o arquivo resultante não depende da disponibilidade contínua do arquivo de imagem original.

### **Adicionar uma Imagem da Web**

Quando uma imagem está disponível via HTTP ou HTTPS, baixe seus bytes, adicione‑os à coleção de imagens da apresentação e use o recurso de imagem retornado da mesma forma que uma imagem local.

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.net.HttpURLConnection;
import java.net.URI;
import java.net.URL;

Presentation presentation = new Presentation();
try {
    URL imageUrl = URI.create("https://example.com/image.png").toURL();
    HttpURLConnection connection = (HttpURLConnection) imageUrl.openConnection();
    connection.setConnectTimeout(10000);
    connection.setReadTimeout(10000);

    try (InputStream inputStream = connection.getInputStream(); 
         ByteArrayOutputStream outputStream = new ByteArrayOutputStream()) {
        byte[] buffer = new byte[8192];
        int bytesRead;
        while ((bytesRead = inputStream.read(buffer)) != -1) outputStream.write(buffer, 0, bytesRead);

        IPPImage image = presentation.getImages().addImage(outputStream.toByteArray());
        ISlide slide = presentation.getSlides().get_Item(0);
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);
    }

    presentation.save("presentation-from-web.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Em aplicações de longa duração, reutilize um cliente HTTP ou uma estratégia de gerenciamento de conexões adequada ao aplicativo, em vez de criar repetidamente infraestrutura de rede desnecessária. Também valide URLs remotas, tamanhos de resposta e tipos de conteúdo quando a origem não for confiável.

## **Reutilizar Imagens em Vários Slides**

Se a mesma imagem for necessária mais de uma vez, adicione‑a à apresentação uma única vez e reutilize o [IPPImage](/slides/pt/androidjava/com.aspose.slides/ippimage/) retornado ao criar quadros de imagem adicionais. Isso evita o carregamento repetido da mesma fonte de dados e torna explícita a relação entre o recurso de imagem compartilhado e seus usos.

Para gráficos que devem aparecer automaticamente em muitos slides, como o logotipo da empresa, considere colocar o quadro de imagem em um [mestre de slide](/slides/pt/androidjava/slide-master/) ou layout em vez de adicionar uma forma equivalente a cada slide.

## **Usar uma Imagem como Plano de Fundo do Slide**

Uma imagem de fundo é atribuída ao preenchimento do slide; não é adicionada como uma forma de quadro de imagem. Isso é útil quando a imagem deve cobrir todo o fundo do slide e não deve ser manipulada como um objeto de slide normal.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("background.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) sourceImage.dispose();
    }

    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Picture);
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(image);

    presentation.save("background-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Para opções adicionais de fundo, incluindo fundos de mestre e layout, veja [Plano de Fundo da Apresentação](/slides/pt/androidjava/presentation-background/).

## **Imagens Incorporadas e Imagens Vinculadas**

Imagens incorporadas e vinculadas têm diferentes concessões de portabilidade e tamanho de arquivo:

- **Imagem incorporada:** os dados da imagem são armazenados dentro da apresentação. A apresentação é autocontida, mas o tamanho do arquivo inclui os dados da imagem.
- **Imagem vinculada:** a apresentação armazena um caminho ou URL para uma imagem externa. Isso pode reduzir o tamanho da apresentação, mas o recurso externo deve permanecer acessível quando a apresentação for aberta ou renderizada.

Uma imagem vinculada pode ser criada atribuindo o caminho ou URL externo através de [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/islidespicture/) em vez de incorporar os dados da imagem.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, null);
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong("https://example.com/image.png");

    presentation.save("linked-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Use imagens vinculadas somente quando o ambiente de implantação puder acessar o recurso externo de forma confiável. Para apresentações que precisam funcionar offline ou ser movidas entre sistemas, imagens incorporadas geralmente são mais seguras.

## **Trabalhar com Imagens SVG**

SVG é um formato vetorial, podendo ser útil para ícones, diagramas e outros gráficos que devem escalar sem a mesma perda de detalhe das imagens raster. Aspose.Slides oferece suporte a SVG tanto como recurso de imagem quanto como fonte para formas de slide editáveis.

### **Adicionar um SVG como Imagem**

Crie um [SvgImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/svgimage/), adicione‑o à coleção de imagens e coloque o recurso de imagem resultante em um quadro de imagem.

```java
import com.aspose.slides.*;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] imageData = Files.readAllBytes(Paths.get("icon.svg"));
    String svgContent = new String(imageData, StandardCharsets.UTF_8);
    ISvgImage svgImage = new SvgImage(svgContent);

    IPPImage image = presentation.getImages().addImage(svgImage);
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 200, image);

    presentation.save("svg-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Arquivos SVG com Recursos Externos**

Um SVG pode referenciar imagens, folhas de estilo ou fontes externas. Para esses casos, [SvgImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/svgimage/) fornece construtores que aceitam um [IExternalResourceResolver](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iexternalresourceresolver/) e um URI base. O resolvedor pode mapear um URI relativo para um URI absoluto permitido e devolver um fluxo para o recurso solicitado.

O resolvedor disponibiliza recursos externos enquanto o Aspose.Slides processa o SVG, mas não reescreve o SVG em um documento autocontido. Se o SVG precisar permanecer portátil, incorpore seus recursos necessários no próprio SVG, por exemplo usando URIs `data:` para imagens vinculadas.

Quando arquivos SVG provêm de fontes não confiáveis, restrinja os esquemas, locais de arquivos e hosts que o resolvedor pode acessar. Resolvedores de rede também devem aplicar tempos limite, limites de tamanho de resposta e validação de conteúdo.

### **Converter SVG para Formas Editáveis**

Aspose.Slides pode converter um SVG em um grupo de formas de slide editáveis, semelhante ao comando correspondente do PowerPoint.

![Menu Pop-up do PowerPoint](img_01_01.png)

Use a sobrecarga de [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ishapecollection/) que aceita um [ISvgImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/isvgimage/) para realizar a conversão.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] imageData = Files.readAllBytes(Paths.get("diagram.svg"));
    String svgContent = new String(imageData, StandardCharsets.UTF_8);
    ISvgImage svgImage = new SvgImage(svgContent);

    SizeF slideSize = presentation.getSlideSize().getSize();
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addGroupShape(svgImage, 0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight());

    presentation.save("editable-svg-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Use a conversão de SVG para formas quando elementos vetoriais individuais precisarem ser editados como formas do PowerPoint. Se o SVG precisar apenas ser exibido, mantê‑lo como imagem é mais simples e evita criar muitas formas separadas.

## **Substituir um Recurso de Imagem Existente**

Use [IPPImage.replaceImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ippimage/) quando quiser substituir um recurso de imagem existente. Isto é especialmente útil para gráficos compartilhados, como logotipos.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IPPImage imageToReplace = presentation.getImages().get_Item(0);

    IImage replacementImage = Images.fromFile("new-logo.png");
    try {
        imageToReplace.replaceImage(replacementImage);
    } finally {
        if (replacementImage != null) replacementImage.dispose();
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Se vários quadros de imagem, planos de fundo, mestres ou layouts utilizarem o mesmo recurso de imagem, substituir esse recurso atualiza todos esses usos. Se apenas um quadro de imagem deve mudar, atribua uma imagem diferente a esse quadro em vez de substituir o recurso compartilhado.

`replaceImage` também oferece sobrecargas que aceitam um array de bytes ou outro [IPPImage](/slides/pt/androidjava/com.aspose.slides/ippimage/).

## **Orientações Práticas de Gerenciamento de Imagens**

### **Controlar o Tamanho da Apresentação**

Imagens raster grandes podem tornar uma apresentação desnecessariamente pesada. Use imagens de origem com dimensões adequadas ao tamanho de exibição previsto, reutilize recursos de imagem compartilhados quando possível e evite incorporar cópias repetidas do mesmo gráfico em alta resolução.

Para imagens raster que já foram colocadas em quadros de imagem, [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ipicturefillformat/) pode reduzir os dados da imagem de acordo com a resolução selecionada e configurações de corte. Isso é processamento de quadro de imagem, não gerenciamento da coleção de imagens, portanto consulte [Quadro de Imagem](/slides/pt/androidjava/picture-frame/) para operações de formatação relacionadas.

### **Escolher entre Conteúdo Incorporado e Vinculado**

Incorporar torna a apresentação portátil porque todos os dados de imagem necessários viajam com o arquivo. Vincular pode reduzir o tamanho do arquivo, mas introduz uma dependência externa. Use vínculos somente quando essa dependência for aceitável e estável.

### **Reutilizar Marca Compartilhada**

Para logotipos, marcas d’água ou gráficos decorativos que se repetem, use um único recurso de imagem e reutilize‑o. Se o gráfico pertencer ao design da apresentação em vez ao conteúdo dos slides, coloque‑o em um mestre ou layout para que seja herdado pelos slides apropriados.

### **Manter Recursos SVG Portáteis**

Um SVG autocontido é mais fácil de mover e renderizar de forma consistente que um SVG que depende de arquivos externos ou recursos de rede. Sempre que possível, incorpore os recursos necessários antes de importar o SVG. Converta SVG para formas apenas quando os elementos vetoriais individuais precisarem ser editados.

### **Usar a API de Imagem Moderna e Multiplataforma**

Para novo código Android via Java, use as APIs Aspose.Slides [IImage](/slides/pt/androidjava/modern-api/) e [Images](/slides/pt/androidjava/modern-api/) em vez da API pública legada baseada em `android.graphics.Bitmap`. Veja [API Moderna](/slides/pt/androidjava/modern-api/) para orientações de migração.

WMF e EMF requerem considerações especiais. Quando esses formatos são passados através de um [IImage](/slides/pt/androidjava/modern-api/), [ImageCollection.addImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/imagecollection/) converte o metafile em uma representação PNG raster antes da inserção. Se a preservação dos dados do metafile for importante, use a sobrecarga baseada em fluxo de [ImageCollection.addImage](/slides/pt/androidjava/modern-api/). Gerar conteúdo EMF a partir de planilhas ou outros produtos é um fluxo de integração separado e está fora do escopo deste artigo.

## **FAQ**

**Qual a diferença entre a coleção de imagens e um quadro de imagem?**

A coleção de imagens armazena recursos de imagem reutilizáveis. Um quadro de imagem é uma forma de slide que exibe um desses recursos e fornece formatação específica de imagem, como recorte e efeitos.

**Qual a melhor forma de substituir o mesmo logotipo em todos os lugares?**

Se o logotipo já estiver compartilhado como um recurso de imagem, substitua esse recurso com [IPPImage.replaceImage](/slides/pt/androidjava/com.aspose.slides/ippimage/). Para marca em toda a apresentação, colocar o logotipo em um mestre ou layout também pode reduzir conteúdo duplicado nos slides.

**Por que uma imagem vinculada desaparece em outro computador?**

Uma imagem vinculada depende de seu arquivo externo ou URL. Se esse recurso não puder ser alcançado a partir do outro computador, a imagem vinculada pode ficar indisponível. Incorpore a imagem quando a apresentação precisar ser autocontida.

**É possível editar um SVG inserido como formas do PowerPoint?**

Sim. Converta o SVG com [IShapeCollection.addGroupShape](/slides/pt/androidjava/com.aspose.slides/ishapecollection/); o grupo resultante contém formas de slide editáveis em vez de uma única imagem SVG.

**Como manter apresentações com muitas imagens menores?**

Reutilize recursos de imagem compartilhados, evite fontes raster desnecessariamente grandes, comprima imagens raster adequadas quando apropriado, mantenha marcas repetidas em mestres ou layouts e use imagens vinculadas somente quando a dependência externa for aceitável.