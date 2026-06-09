---
title: Otimizar o Gerenciamento de Imagens em Apresentações no Android
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
- fundo
- adicionar PNG
- adicionar JPG
- adicionar SVG
- adicionar EMF
- adicionar WMF
- adicionar TIFF
- PowerPoint
- OpenDocument
- apresentação
- Android
- Java
- Aspose.Slides
description: "Simplifique o gerenciamento de imagens no PowerPoint e OpenDocument com Aspose.Slides para Android via Java, otimizando o desempenho e automatizando seu fluxo de trabalho."
---
## **Introdução**

Imagens tornam as apresentações mais atraentes e interessantes. No Microsoft PowerPoint, você pode inserir imagens a partir de um arquivo, da internet ou de outros locais nos slides. Da mesma forma, Aspose.Slides permite adicionar imagens aos slides em suas apresentações por meio de diferentes procedimentos. 

{{% alert  title="Tip" color="primary" %}} 

Aspose fornece conversores gratuitos—[JPEG to PowerPoint](https://products.aspose.app/slides/pt/import/jpg-to-ppt) e [PNG to PowerPoint](https://products.aspose.app/slides/pt/import/png-to-ppt)—que permitem às pessoas criar apresentações rapidamente a partir de imagens. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Se você quiser adicionar uma imagem como um objeto de quadro—especialmente se planeja usar opções de formatação padrão nele para alterar seu tamanho, adicionar efeitos e assim por diante—consulte [Picture Frame](https://docs.aspose.com/slides/pt/androidjava/picture-frame/).

{{% /alert %}} 

Aspose.Slides oferece suporte a operações com imagens nestes formatos populares: JPEG, PNG, GIF e outros. 

## **Adicionar Imagens Armazenadas Localmente aos Slides**

Você pode adicionar uma ou várias imagens do seu computador a um slide em uma apresentação. Este código de exemplo em Java mostra como adicionar uma imagem a um slide:

```java
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
	if (pres != null) pres.dispose();
}
```

## **Adicionar Imagens da Web aos Slides**

Se a imagem que você deseja adicionar a um slide não estiver disponível no seu computador, você pode adicioná‑la diretamente da web. 

Este código de exemplo mostra como adicionar uma imagem da web a um slide em Java:

```java
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

		while ((read = inputStream.read(buffer, 0, buffer.length)) != -1)
			outputStream.write(buffer, 0, read);

		outputStream.flush();

		IPPImage image = pres.getImages().addImage(outputStream.toByteArray());
		slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
	} finally {
		if (inputStream != null) inputStream.close();
		outputStream.close();
	}

	pres.save("pres.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

## **Adicionar Imagens aos Mestres de Slides**

Um slide master é o slide principal que armazena e controla informações (tema, layout, etc.) sobre todos os slides abaixo dele. Assim, quando você adiciona uma imagem a um slide master, essa imagem aparece em todos os slides sob esse slide master. 

Este código de exemplo em Java mostra como adicionar uma imagem a um slide master:

```java
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
	if (pres != null) pres.dispose();
}
```

## **Adicionar Imagens como Fundo de Slides**

Você pode decidir usar uma imagem como fundo para um slide específico ou vários slides. Nesse caso, consulte *[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/pt/androidjava/presentation-background/#setting-images-as-background-for-slides)*.

## **Adicionar SVG a Apresentações**
Você pode adicionar ou inserir qualquer imagem em uma apresentação usando o método [addPictureFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) que pertence à interface [IShapeCollection](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IShapeCollection).

Para criar um objeto de imagem baseado em SVG, você pode fazer da seguinte maneira:

1. Criar objeto SvgImage para inseri‑lo na ImageShapeCollection
2. Criar objeto PPImage a partir de ISvgImage
3. Criar objeto PictureFrame usando a interface IPPImage

Este código de exemplo mostra como implementar as etapas acima para adicionar uma imagem SVG em uma apresentação:
```java 
// Instanciar a classe Presentation que representa o arquivo PPTX
Presentation pres = new Presentation();
try {
    String svgContent = new String(Files.readAllBytes(Paths.get("image.svg")));
    ISvgImage svgImage = new SvgImage(svgContent);
    IPPImage ppImage = pres.getImages().addImage(svgImage);
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 
			ppImage.getWidth(), ppImage.getHeight(), ppImage);
    pres.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Converter SVG em um Conjunto de Formas**
A conversão de SVG em um conjunto de formas do Aspose.Slides é semelhante à funcionalidade do PowerPoint usada para trabalhar com imagens SVG:

![PowerPoint Popup Menu](img_01_01.png)

A funcionalidade é fornecida por uma das sobrecargas do método [addGroupShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) da interface [IShapeCollection](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IShapeCollection) que recebe um objeto [ISvgImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ISvgImage) como primeiro argumento.

Este código de exemplo mostra como usar o método descrito para converter um arquivo SVG em um conjunto de formas:

```java 
// Criar nova apresentação
IPresentation presentation = new Presentation();
try {
    // Ler o conteúdo do arquivo SVG
    byte[] svgContent = Files.readAllBytes(Paths.get("image.svg"));

    // Criar objeto SvgImage
    ISvgImage svgImage = new SvgImage(svgContent);

    // Obter tamanho do slide
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // Converter a imagem SVG em um grupo de formas dimensionando-a ao tamanho do slide
    presentation.getSlides().get_Item(0).getShapes().
            addGroupShape(svgImage, 0f, 0f, (float)slideSize.getWidth(), (float)slideSize.getHeight());

    // Salvar a apresentação no formato PPTX
    presentation.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Adicionar Imagens como EMF aos Slides**
Aspose.Slides para Android via Java permite gerar imagens EMF a partir de planilhas Excel e adicionar as imagens como EMF em slides com Aspose.Cells.  

Este código de exemplo mostra como executar a tarefa descrita:

```java 
Workbook book = new Workbook("chart.xlsx");
Worksheet sheet = book.getWorksheets().get(0);
ImageOrPrintOptions options = new ImageOrPrintOptions();
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(ImageType.EMF);

//Salvar o Workbook no stream
SheetRender sr = new SheetRender(sheet, options);
Presentation pres = new Presentation();
try {
    pres.getSlides().removeAt(0);
    
    String EmfSheetName = "";
    for (int j = 0; j < sr.getPageCount(); j++)
    {
    
        EmfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, EmfSheetName);

        IPPImage picture;
        IImage image = Images.fromFile(EmfSheetName);
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
        ISlide slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().getByType(SlideLayoutType.Blank));
        IShape m = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0,
					(float)pres.getSlideSize().getSize().getWidth(), 
					(float)pres.getSlideSize().getSize().getHeight(), 
					picture);
    }
    
    pres.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Substituir Imagens na Coleção de Imagens**

Aspose.Slides permite substituir imagens armazenadas na coleção de imagens de uma apresentação (incluindo aquelas usadas por formas de slide). Esta seção mostra várias abordagens para atualizar imagens na coleção. A API fornece métodos simples para substituir uma imagem usando dados brutos em bytes, uma instância de [IImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iimage/), ou outra imagem que já exista na coleção.

1. Carregar o arquivo de apresentação que contém imagens usando a classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/).
2. Carregar uma nova imagem de um arquivo em um array de bytes.
3. Substituir a imagem alvo pela nova imagem usando o array de bytes.
4. Na segunda abordagem, carregar a imagem em um objeto [IImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iimage/) e substituir a imagem alvo por esse objeto.
5. Na terceira abordagem, substituir a imagem alvo por uma imagem que já exista na coleção de imagens da apresentação.
6. Gravar a apresentação modificada como um arquivo PPTX.

```java
// Instanciar a classe Presentation que representa um arquivo de apresentação.
Presentation presentation = new Presentation("sample.pptx");
try {
    // A primeira forma.
    IImage imageData = Images.fromStream(new FileInputStream("image0.jpeg"));
    IPPImage oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);
    
    // A segunda forma.
    IImage newImage = Images.fromFile("image1.png");
    oldImage = presentation.getImages().get_Item(1);
    oldImage.replaceImage(newImage);
    newImage.dispose();
    
    // A terceira forma.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));
    
    // Salvar a apresentação em um arquivo.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}

Usando o conversor GRATUITO Aspose [Text to GIF](https://products.aspose.app/slides/pt/text-to-gif), você pode facilmente animar textos, criar GIFs a partir de textos, etc. 

{{% /alert %}}

## **FAQ**

**A resolução original da imagem permanece intacta após a inserção?**

Sim. Os pixels originais são preservados, mas a aparência final depende de como a [picture](/slides/pt/androidjava/picture-frame/) é dimensionada no slide e de qualquer compressão aplicada ao salvar.

**Qual a melhor maneira de substituir o mesmo logotipo em dezenas de slides de uma só vez?**

Coloque o logotipo no slide mestre ou em um layout e substitua‑lo na coleção de imagens da apresentação — as atualizações serão propagadas para todos os elementos que utilizam esse recurso.

**É possível converter um SVG inserido em formas editáveis?**

Sim. Você pode converter um SVG em um grupo de formas, após o qual as partes individuais se tornam editáveis com propriedades padrão de forma.

**Como posso definir uma imagem como fundo para vários slides de uma vez?**

[Atribua a imagem como fundo](/slides/pt/androidjava/presentation-background/) no slide mestre ou no layout relevante — quaisquer slides que usam esse mestre/layout herdarão o fundo.

**Como evito que a apresentação aumente muito de tamanho por causa de muitas imagens?**

Reutilize um único recurso de imagem em vez de duplicados, escolha resoluções razoáveis, aplique compressão ao salvar e mantenha gráficos repetidos no mestre quando apropriado.