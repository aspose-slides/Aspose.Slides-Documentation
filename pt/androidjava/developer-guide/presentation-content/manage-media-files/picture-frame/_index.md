---
title: Gerenciar Quadros de Imagem em Apresentações no Android
linktitle: Quadro de Imagem
type: docs
weight: 10
url: /pt/androidjava/picture-frame/
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
- Android
- Java
- Aspose.Slides
description: "Criar, formatar, vincular, recortar, extrair e comprimir quadros de imagem em apresentações com Aspose.Slides para Android via Java."
---
## **Visão geral**

Um quadro de imagem é uma forma de slide que exibe uma imagem. No Aspose.Slides, o recurso de imagem e a forma que a exibe são objetos separados: um [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/) possui recursos de imagem incorporados por meio de sua [IImageCollection](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iimagecollection/), enquanto um [IPictureFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ipictureframe/) controla a posição, tamanho, formatação de linha, rotação, recorte, efeitos de imagem e outras configurações ao nível do quadro.

Essa separação é útil quando a mesma imagem é exibida mais de uma vez. Adicione a imagem à apresentação uma única vez, mantenha o [IPPImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ippimage/) retornado e use esse recurso de imagem ao criar quadros de imagem.

Quadros de imagem podem conter imagens raster, como PNG ou JPEG, e imagens vetoriais SVG. Eles também podem referenciar imagens vinculadas em vez de armazenar os bytes da imagem na apresentação. A escolha afeta portabilidade, tamanho do arquivo, extração e comportamento de exportação, portanto é útil decidir como a imagem deve ser armazenada antes de aplicar formatação ou otimização.

## **Adicionar e formatar uma imagem incorporada**

Para uma imagem incorporada, adicione os dados da imagem à apresentação e crie um quadro de imagem com [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-). A imagem torna‑se parte do pacote da apresentação, de modo que a apresentação permanece autônoma quando for movida para outro computador.

O exemplo a seguir adiciona uma imagem JPEG, cria um quadro com as dimensões nativas da imagem e aplica formatação de linha e rotação:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pictureFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pictureFrame.getLineFormat().setWidth(3);
    pictureFrame.setRotation(15);

    presentation.save("picture-frame.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O quadro de imagem controla a geometria exibida; alterar o tamanho do quadro não altera as dimensões originais em pixels armazenadas no recurso de imagem incorporada. Essa distinção torna‑se importante ao recortar ou comprimir uma imagem posteriormente.

## **Usar escala relativa**

[IPictureFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ipictureframe/) expõe a escala relativa de largura e altura para o quadro por meio de [setRelativeScaleWidth](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) e [setRelativeScaleHeight](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-). Um valor de `1.0` corresponde a 100 % do tamanho original da imagem. A escala relativa é útil quando um fluxo de trabalho precisa preservar a relação com o tamanho da imagem fonte em vez de calcular manualmente as dimensões finais.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image);
    pictureFrame.setRelativeScaleWidth(1.35f);
    pictureFrame.setRelativeScaleHeight(0.8f);

    presentation.save("relative-scale.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A escala relativa altera as configurações de escala do quadro; não reamostra nem comprime a imagem incorporada.

## **Imagens incorporadas e vinculadas**

Uma imagem incorporada armazena os dados da imagem dentro da apresentação e, portanto, é a escolha mais segura para portabilidade e renderização previsível. Uma imagem vinculada armazena um local externo por meio do método [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) em vez de incorporar os dados da imagem da mesma forma.

Imagens vinculadas podem reduzir a quantidade de dados de imagem armazenados no PPTX, mas introduzem uma dependência externa. O arquivo vinculado deve permanecer acessível ao aplicativo que abre ou renderiza a apresentação. Se o caminho mudar, o arquivo for movido ou o recurso ficar indisponível, a imagem vinculada pode não ser exibida como esperado. Para apresentações que precisam ser enviadas por e‑mail, arquivadas ou renderizadas em ambientes isolados, imagens incorporadas costumam ser mais confiáveis.

### **Adicionar uma imagem vinculada**

O exemplo a seguir cria um quadro de imagem e o aponta para um arquivo de imagem local. Ele trata apenas do vínculo de imagem; o vínculo de vídeo é um fluxo de mídia separado e foi intencionalmente não misturado neste exemplo.

```java
import com.aspose.slides.*;
import java.io.File;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, null);
    File linkedImageFile = new File("linked-image.jpg");
    String linkPath = linkedImageFile.getAbsolutePath();
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong(linkPath);

    presentation.save("linked-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Use vínculos quando a gestão de arquivos externos for intencional. Não os use apenas como substituto para compressão: um PPTX pequeno com dependências de imagem quebradas costuma ser menos útil que uma apresentação maior e autônoma.

## **Extrair imagens de quadros de imagem**

Antes de extrair uma imagem de uma apresentação existente, verifique se a forma é realmente um [IPictureFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ipictureframe/) e se contém uma imagem incorporada. Quadros de imagem vinculados podem não conter os bytes da imagem que podem ser extraídos da mesma forma.

### **Extrair uma imagem raster**

A API de imagem moderna usa [IImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iimage/) diretamente e não requer o wrapper Java mais antigo. O exemplo a seguir encontra a primeira imagem raster incorporada em um slide e a salva como PNG:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IPictureFrame)) {
            continue;
        }

        IPictureFrame pictureFrame = (IPictureFrame) shape;
        IPPImage embeddedImage = pictureFrame.getPictureFormat().getPicture().getImage();
        if (embeddedImage == null || embeddedImage.getSvgImage() != null) {
            continue;
        }

        IImage rasterImage = embeddedImage.getImage();
        try {
            rasterImage.save("extracted-image.png", ImageFormat.Png);
        } finally {
            rasterImage.dispose();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

Salvar por meio de [IImage.save](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) converte a imagem extraída para o formato de saída solicitado. Se precisar dos bytes codificados armazenados na apresentação em vez de um arquivo raster convertido, use os dados binários do recurso de imagem.

### **Extrair uma imagem SVG**

Para uma imagem SVG, o [IPPImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ippimage/) expõe um objeto [ISvgImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/isvgimage/). Isso permite recuperar os dados SVG diretamente em vez de rasterizar a imagem primeiro.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IPictureFrame)) {
            continue;
        }

        IPictureFrame pictureFrame = (IPictureFrame) shape;
        IPPImage embeddedImage = pictureFrame.getPictureFormat().getPicture().getImage();
        ISvgImage svgImage = embeddedImage != null ? embeddedImage.getSvgImage() : null;
        if (svgImage == null) {
            continue;
        }

        byte[] svgData = svgImage.getSvgData();
        FileOutputStream outputStream = new FileOutputStream("extracted-image.svg");
        try {
            outputStream.write(svgData);
        } finally {
            outputStream.close();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

Manter o conteúdo SVG como SVG preserva a origem vetorial dentro da apresentação. Exportações raster, como PNG ou JPEG, necessariamente renderizam esse conteúdo vetorial em pixels. Exportar slides como PDF ou SVG também é uma operação de renderização, portanto os gráficos exportados não devem ser tratados como uma cópia byte a byte do SVG incorporado original; use os dados de [ISvgImage.getSvgData](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/isvgimage/#getSvgData--) quando o recurso vetorial original for necessário.

## **Recortar uma imagem**

O recorte altera a parte da imagem que fica visível dentro do quadro. Os valores de recorte em [IPictureFillFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ipicturefillformat/) são percentuais das dimensões da imagem fonte. O recorte não exclui inicialmente os pixels ocultos da imagem incorporada; ele apenas altera a região visível.

O exemplo a seguir localiza de forma segura um quadro de imagem e aplica valores de recorte:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        pictureFrame.getPictureFormat().setCropLeft(23.6f);
        pictureFrame.getPictureFormat().setCropRight(21.5f);
        pictureFrame.getPictureFormat().setCropTop(3f);
        pictureFrame.getPictureFormat().setCropBottom(31f);
        presentation.save("cropped-image.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Como os dados da imagem oculta ainda estão presentes, o recorte pode ser alterado posteriormente sem perder os pixels originais. Se o tamanho do arquivo for mais importante que a reversibilidade, as regiões recortadas podem ser removidas fisicamente como descrito na próxima seção.

## **Remover dados de imagem recortados**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) remove os dados da imagem fora do retângulo de recorte atual e devolve o recurso de imagem resultante. Isso pode reduzir o tamanho do arquivo, mas é uma otimização destrutiva: após a apresentação ser salva, os pixels removidos não ficam mais disponíveis para uma operação de “desrecortar” posterior.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("cropped-image.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IPPImage croppedImage = pictureFrame.getPictureFormat().deletePictureCroppedAreas();
        if (croppedImage != null) {
            presentation.save("cropped-data-removed.pptx", SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

O método pode adicionar um novo recurso de imagem à apresentação. Se a imagem original também for usada por outros quadros de imagem, esses quadros ainda precisarão do recurso existente, de modo que a exclusão de áreas recortadas não reduz necessariamente o número total de imagens. Recortar conteúdo WMF ou EMF com este método rasteriza o resultado recortado para PNG.

## **Comprimir imagens raster**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) reduz a resolução de imagens raster em relação ao tamanho em que a imagem é exibida. Também pode remover regiões recortadas na mesma operação. O método devolve `true` quando a imagem foi redimensionada ou recortada e `false` quando nenhuma alteração foi necessária.

Use um valor predefinido de [PicturesCompression](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/picturescompression/) quando uma resolução‑alvo padrão for suficiente:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        boolean compressed = pictureFrame.getPictureFormat().compressImage(true, PicturesCompression.Dpi150);
        System.out.println(compressed ? "The image was compressed." : "No compression was necessary.");
        presentation.save("compressed-image.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Um valor DPI positivo personalizado pode ser passado em vez de um valor predefinido quando for necessário um alvo específico.

A compressão destina‑se a imagens raster. Conteúdo SVG e metafile não é reduzido por esse fluxo de compressão raster. Também lembre‑se de que resolução mais baixa e regiões recortadas excluídas não podem ser recuperadas da apresentação otimizada. Escolha a resolução‑alvo com base no maior tamanho no qual a imagem será realmente visualizada ou exportada, em vez de aplicar o DPI mais baixo globalmente.

## **Inspecionar efeitos de imagem**

Os efeitos de imagem são armazenados na imagem usada pelo quadro. A coleção de transformações de imagem pode conter efeitos como modulação alfa fixa para transparência e luminância para brilho e contraste. O exemplo abaixo lê com segurança ambos os tipos de efeito do primeiro quadro de imagem em um slide:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        for (IImageTransformOperation effect : imageTransform) {
            if (effect instanceof IAlphaModulateFixed) {
                IAlphaModulateFixed alphaModulateFixed = (IAlphaModulateFixed) effect;
                float transparency = 100 - alphaModulateFixed.getAmount();
                System.out.println("Transparency: " + transparency);
            }

            if (effect instanceof ILuminance) {
                ILuminance luminanceEffect = (ILuminance) effect;
                ILuminanceEffectiveData luminance = luminanceEffect.getEffective();
                System.out.println("Brightness: " + luminance.getBrightness());
                System.out.println("Contrast: " + luminance.getContrast());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Esses efeitos alteram a forma como a imagem é renderizada no quadro; não reescrevem os bytes da imagem incorporada original.

## **Bloquear a geometria do quadro de imagem**

As configurações de [IPictureFrameLock](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ipictureframelock/) controlam quais operações de edição são desativadas para um quadro de imagem. Por exemplo, [setAspectRatioLocked](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) preserva as proporções da forma enquanto ela é redimensionada.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);

    presentation.save("locked-picture-frame.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O bloqueio se aplica à forma do quadro de imagem. Ele não força a imagem fonte a ser reamostrada ou permanentemente alterada para a mesma proporção.

## **Ajustar os valores StretchOffset**

Quando o modo de preenchimento da imagem é “stretch”, os valores de stretch‑offset em [IPictureFillFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ipicturefillformat/) definem o retângulo de preenchimento relativo à caixa delimitadora do quadro. Percentuais positivos criam um recuo a partir de uma borda, enquanto percentuais negativos criam um avanço.

Isso difere do recorte. Valores de recorte selecionam qual parte da imagem fonte fica visível; stretch‑offsets alteram o retângulo no qual o preenchimento da imagem visível é esticado.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image);
    pictureFrame.getPictureFormat().setPictureFillMode(PictureFillMode.Stretch);
    pictureFrame.getPictureFormat().setStretchOffsetLeft(12f);
    pictureFrame.getPictureFormat().setStretchOffsetRight(12f);
    pictureFrame.getPictureFormat().setStretchOffsetTop(8f);
    pictureFrame.getPictureFormat().setStretchOffsetBottom(8f);

    presentation.save("stretch-offsets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Use stretch‑offsets para posicionamento de preenchimento. Use propriedades de recorte quando o objetivo for ocultar as bordas da imagem fonte.

## **Considerações sobre armazenamento, tamanho de arquivo e exportação**

Os principais trade‑offs são mais fáceis de gerenciar quando o armazenamento de imagens e a formatação de quadros de imagem são tratados separadamente:

- **Imagens incorporadas** deixam a apresentação autônoma e são a escolha mais confiável para compartilhamento e renderização no lado do servidor, porém imagens raster grandes aumentam o tamanho do PPTX e o uso de memória.
- **Imagens vinculadas** podem manter o pacote menor, mas a apresentação depende de arquivos externos que devam permanecer disponíveis nos caminhos ou locais armazenados.
- **Recorte** inicialmente não é destrutivo. Os pixels ocultos permanecem incorporados até que as áreas recortadas sejam explicitamente excluídas ou removidas durante a compressão.
- **Compressão** pode reduzir substancialmente o tamanho do arquivo para imagens raster excessivamente grandes, mas sacrifica a resolução fonte. Deve ser aplicada depois que o tamanho final na slide for conhecido.
- **Imagens SVG** devem permanecer como SVG quando a preservação vetorial for importante. Extraia o SVG incorporado diretamente quando precisar do recurso vetorial em si. Exportações de slide raster, como PNG ou JPEG, sempre convertem o slide renderizado em pixels.
- **Imagens repetidas** devem reutilizar um recurso [IPPImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ippimage/) existente sempre que possível, em vez de carregar o mesmo arquivo repetidamente no fluxo de trabalho da apresentação.

Para apresentações grandes, a otimização de imagens costuma ser mais eficaz quando feita seletivamente: mantenha logotipos e diagramas como conteúdo vetorial, comprima fotografias de acordo com seu tamanho real de exibição, remova pixels recortados somente quando a edição futura não for necessária e evite vínculos externos a menos que a gestão de dependências faça parte do design de implantação.

## **FAQ**

**Qual é a diferença entre um quadro de imagem e um recurso de imagem?**

Um [IPPImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ippimage/) representa um recurso de imagem associado à apresentação. Um [IPictureFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ipictureframe/) é uma forma em um slide que exibe uma imagem e armazena a geometria e formatação ao nível do quadro, como tamanho, rotação, valores de recorte, efeitos e bloqueios.

**Devo incorporar ou vincular imagens?**

Incorpore imagens quando a apresentação precisar ser portátil, arquivada ou renderizada sem acesso a recursos externos. Vincule imagens somente quando manter os arquivos de imagem fora do PPTX for intencional e os locais externos puderem ser mantidos de forma confiável.

**O recorte reduz o tamanho do arquivo PPTX?**

Não por si só. Configurações de recorte normais ocultam partes da imagem fonte, mas mantêm os pixels subjacentes. Use [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) ou compressão de imagem com remoção de áreas recortadas quando esses pixels puderem ser descartados permanentemente.

**Posso restaurar a qualidade da imagem após a compressão?**

Não. A compressão pode reduzir a resolução raster armazenada e a remoção de regiões recortadas descarta dados da imagem. Mantenha a imagem fonte original fora da apresentação se edições posteriores em alta resolução puderem ser necessárias.

**Como as imagens SVG devem ser tratadas?**

Mantenha o conteúdo SVG como SVG quando a fidelidade vetorial for importante. O [ISvgImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/isvgimage/) incorporado pode ser extraído diretamente. Renderizar um slide para um formato raster, como PNG ou JPEG, rasteriza o SVG como parte da imagem do slide.

**Como posso evitar casts inseguros ao ler slides existentes?**

Verifique o tipo da forma antes de usar membros específicos de quadro de imagem. Uma verificação `instanceof` contra [IPictureFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ipictureframe/) evita casts inválidos e permite que o código trate slides que não contêm quadros de imagem.