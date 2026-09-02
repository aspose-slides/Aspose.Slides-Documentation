---
title: Converter Slides de Apresentação em Imagens no Android
linktitle: Slide para Imagem
type: docs
weight: 35
url: /pt/androidjava/convert-slide/
keywords:
- converter slide
- exportar slide
- slide para imagem
- salvar slide como imagem
- slide para EMF
- slide para PNG
- slide para JPEG
- slide para bitmap
- slide para TIFF
- PowerPoint
- OpenDocument
- apresentação
- Android
- Java
- Aspose.Slides
description: "Converta slides de apresentações PPT, PPTX e ODP para PNG, JPEG, GIF, TIFF, EMF e outros formatos de imagem no Android com Aspose.Slides."
---
## **Introdução**

Aspose.Slides for Android via Java pode renderizar slides individuais de apresentações PowerPoint e OpenDocument como PNG, JPEG, GIF, TIFF e outros formatos de imagem.

Para converter um slide em uma imagem, siga estas etapas:

1. Carregue a apresentação com a classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/).
2. Selecione o slide que você deseja renderizar.
3. Se necessário, configure a renderização com a classe [RenderingOptions](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/renderingoptions/) ou [TiffOptions](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/tiffoptions/).
4. Chame o método [ISlide.getImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/islide/#getImage--). Ele retorna um objeto [IImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iimage/).
5. Chame o método [IImage.save](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) e especifique o formato de saída com um valor [ImageFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/imageformat/).

## **Converter um Slide para Imagem PNG**

A conversão mais simples usa as configurações padrão de renderização. O objeto [IImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iimage/) resultante pode ser processado na memória ou salvo em um arquivo.

O exemplo Java a seguir renderiza o primeiro slide e o salva como uma imagem PNG:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage();
    try {
        image.save("Slide_0.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Converter Slides para Imagens com Tamanhos Personalizados**

Use a sobrecarga [ISlide.getImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) que aceita um valor [Size](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides.android/size/) para renderizar um slide com dimensões de pixel exatas.

O exemplo a seguir cria uma imagem JPEG de 1820 × 1040:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;
import com.aspose.slides.android.Size;

Size imageSize = new Size(1820, 1040);

Presentation presentation = new Presentation("Presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage(imageSize);
    try {
        image.save("Slide_0.jpg", ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Converter Slides com Notas e Comentários para Imagens**

Por padrão, as imagens dos slides não incluem notas ou comentários. Passe um objeto [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/notescommentslayoutingoptions/) para o método [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/renderingoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) para controlar onde notas e comentários aparecem.

O exemplo a seguir coloca notas truncadas abaixo do slide e comentários à sua direita:

```java
import android.graphics.Color;
import com.aspose.slides.CommentsPositions;
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.NotesCommentsLayoutingOptions;
import com.aspose.slides.NotesPositions;
import com.aspose.slides.Presentation;
import com.aspose.slides.RenderingOptions;

float scaleX = 2f;
float scaleY = scaleX;

int commentsAreaColor = Color.rgb(250, 235, 215);

NotesCommentsLayoutingOptions layoutOptions = new NotesCommentsLayoutingOptions();
layoutOptions.setNotesPosition(NotesPositions.BottomTruncated);
layoutOptions.setCommentsPosition(CommentsPositions.Right);
layoutOptions.setCommentsAreaWidth(500);
layoutOptions.setCommentsAreaColor(commentsAreaColor);

RenderingOptions renderingOptions = new RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutOptions);

Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage(renderingOptions, scaleX, scaleY);
    try {
        image.save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Aviso" color="warning" %}}
Para a conversão de slide para imagem, não passe [BottomFull](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/notespositions/) ao método [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/notescommentslayoutingoptions/#setNotesPosition-int-). As notas podem conter mais texto do que o tamanho fixo da imagem pode acomodar. Use [BottomTruncated](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/notespositions/) em vez disso.
{{% /alert %}}

## **Converter Slides para Imagens Usando Opções TIFF**

A classe [TiffOptions](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/tiffoptions/) permite controlar o tamanho, a resolução e outras propriedades da imagem TIFF renderizada.

O exemplo a seguir renderiza o primeiro slide como uma imagem TIFF de 2160 × 2880 a 300 DPI:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;
import com.aspose.slides.TiffOptions;
import com.aspose.slides.android.Size;

Size imageSize = new Size(2160, 2880);

TiffOptions tiffOptions = new TiffOptions();
tiffOptions.setImageSize(imageSize);
tiffOptions.setDpiX(300);
tiffOptions.setDpiY(300);

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage(tiffOptions);
    try {
        image.save("output.tiff", ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Converter Todos os Slides para Imagens**

Itere através da coleção de slides para converter toda a apresentação em uma série de imagens. Slides ocultos são incluídos, a menos que você os ignore explicitamente.

O exemplo a seguir renderiza cada slide como uma imagem JPEG com fatores de escala horizontal e vertical de 2:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;

float scaleX = 2f;
float scaleY = scaleX;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage(scaleX, scaleY);
        try {
            image.save("Slide_" + index + ".jpg", ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Criar Saída de Metarquivo Avançado**

Enhanced Metafile (EMF) é útil quando gráficos baseados em vetor precisam ser trocados com o Microsoft Office ou outros aplicativos Windows que suportam metafiles do Windows. Ao contrário de uma imagem baseada em pixels, um EMF pode preservar operações de desenho vetorial que escalam sem a mesma perda de nitidez. No entanto, o EMF é principalmente um formato de compatibilidade para aplicativos com suporte a metafiles do Windows, não um formato de intercâmbio universal. Além disso, conteúdo complexo de slides, como imagens bitmap e alguns efeitos, pode ser armazenado como elementos rasterizados dentro do contêiner de metafile vetorial.

### **Exportar um Slide para EMF**

O método [ISlide.writeAsEmf](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-) grava um [ISlide](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/islide/) em um fluxo de destino no formato EMF. O exemplo a seguir carrega uma apresentação, seleciona o primeiro slide e o grava em um fluxo de arquivo EMF:

```java
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    FileOutputStream emfStream = new FileOutputStream("Slide_0.emf");
    try {
        slide.writeAsEmf(emfStream);
    } finally {
        emfStream.close();
    }
} finally {
    presentation.dispose();
}
```

O chamador possui o fluxo passado para [ISlide.writeAsEmf](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-) e é responsável por fechá-lo, conforme mostrado acima.

### **Converter uma Imagem SVG para EMF e Adicioná‑la a uma Apresentação**

Use [ISvgImage.writeAsEmf](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-) para converter conteúdo SVG em EMF. Os bytes resultantes podem ser adicionados à apresentação através de [IImageCollection.addImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iimagecollection/#addImage-byte:A-) e colocados em um slide com [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-).

O exemplo a seguir cria um [SvgImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/svgimage/) a partir de marcação SVG, converte‑lo em um EMF em memória, insere o metafile no primeiro slide e salva a apresentação:

```java
import com.aspose.slides.IPPImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ISvgImage;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;
import com.aspose.slides.SvgImage;
import java.io.ByteArrayOutputStream;

String svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
ISvgImage svgImage = new SvgImage(svgContent);

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ByteArrayOutputStream emfStream = new ByteArrayOutputStream();
    try {
        svgImage.writeAsEmf(emfStream);

        byte[] emfData = emfStream.toByteArray();
        IPPImage image = presentation.getImages().addImage(emfData);
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 100, image);
    } finally {
        emfStream.close();
    }

    presentation.save("Presentation_with_emf.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[ISvgImage.writeAsEmf](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-) não assume a propriedade do fluxo de destino. Um [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) armazena todos os dados gerados na memória, portanto não é necessário redefinir a posição antes de chamar `toByteArray`. O array de bytes retornado permanece válido após o fluxo ser fechado.

A geração de EMF está disponível nas versões Android suportadas e nas configurações de dispositivo, mas a renderização pode variar quando fontes ou dependências gráficas não estão disponíveis. Instale as fontes usadas pelo conteúdo de origem ou configure substituições adequadas, siga o [guia de instalação](/slides/pt/androidjava/install-aspose-slides-for-android-via-java/) para Aspose.Slides for Android via Java e valide o resultado no aplicativo de destino que consome EMF. Aplicativos em plataformas não Windows frequentemente têm suporte limitado ou inconsistente para exibir e editar metafiles do Windows.

## **Renderização de Emoji Colorido**

{{% alert title="Nota" color="info" %}}
Para renderizar emojis coloridos corretamente ao converter slides de apresentação em imagens, as fontes de emoji usadas na apresentação devem estar instaladas e disponíveis no sistema que realiza a conversão. Por exemplo, se a apresentação usar **Segoe UI Emoji** e essa fonte estiver ausente, os emojis podem aparecer em monocromático nas imagens de saída.
{{% /alert %}}

## **FAQ**

**O Aspose.Slides suporta renderização de slides com animações?**

Não. O método [ISlide.getImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/islide/#getImage--) renderiza uma imagem estática do slide e não exporta animações.

**Slides ocultos podem ser exportados como imagens?**

Sim. Slides ocultos podem ser renderizados como slides normais. Inclua‑os no loop de processamento, como mostrado no exemplo acima.

**Sombras e outros efeitos são preservados nas imagens dos slides?**

Sim. Aspose.Slides renderiza sombras, transparência e outros efeitos gráficos suportados nas imagens dos slides.