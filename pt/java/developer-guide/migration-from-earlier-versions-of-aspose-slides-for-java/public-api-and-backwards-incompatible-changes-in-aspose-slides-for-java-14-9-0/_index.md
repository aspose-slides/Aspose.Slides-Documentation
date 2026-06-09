---
title: API pública e alterações incompatíveis retroativas no Aspose.Slides para Java 14.9.0
linktitle: Aspose.Slides para Java 14.9.0
type: docs
weight: 80
url: /pt/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/
keywords:
- migração
- código legado
- código moderno
- abordagem legada
- abordagem moderna
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Revise as atualizações da API pública e as mudanças incompatíveis no Aspose.Slides para Java para migrar suavemente suas soluções de apresentação PowerPoint PPT, PPTX e ODP."
---
{{% alert color="primary" %}} 

Esta página lista todas as classes, métodos, propriedades e etc. [adicionadas](/slides/pt/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/), quaisquer novas restrições e outras [alterações](/slides/pt/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) introduzidas com a API do Aspose.Slides for Java 14.9.0.

{{% /alert %}} 
## **Alterações da API Pública**
### **Métodos adicionados para substituir imagem por PPImage, IPPImage**
Novos métodos adicionados:

- IPPImage.replaceImage(byte[] newImageData)
- IPPImage.replaceImage(IPPImage newImage)

``` java

 Presentation presentation = new Presentation("presentation.pptx");

// A primeira forma

byte[] imageData = // ...

presentation.getImages().get_Item(0).replaceImage(imageData);

// A segunda forma

presentation.getImages().get_Item(1).replaceImage(

    presentation.getImages().get_Item(0));

presentation.save("presentation_out.pptx", SaveFormat.Pptx);

```
### **Métodos adicionados para salvar slides mantendo números de página**
Os seguintes métodos foram adicionados:

- void IPresentation.save(string fname, int[] slides, SaveFormat format);
- void IPresentation.save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

Esses métodos permitem salvar os slides especificados da apresentação nos formatos PDF, XPS, TIFF, HTML. O array `slides` permite especificar os números das páginas, começando em 1.

``` java

 save(string fname, int\[\] slides, SaveFormat format);

```




``` java

 Presentation presentation = new Presentation(presentationFileName);

int[] slides = new int[] { 2, 3, 5 }; //Array de posições dos slides

presentation.save(outFileName, slides, SaveFormat.Pdf);

```
### **Valor Custom do enum SmartArtLayoutType adicionado**
Esse tipo de layout SmartArt representa um diagrama com modelo customizado. Diagramas customizados só podem ser carregados a partir de um arquivo de apresentação e não podem ser criados via método `ShapeCollection.addSmartArt(x, y, width, height, SmartArtLayoutType.Custom)`.

### **Classe SmartArtShape e interface ISmartArtShape adicionadas**
A classe `Aspose.Slides.SmartArt.SmartArtShape` (e sua interface `Aspose.Slides.SmartArt.ISmartArtShape`) dão acesso às formas individuais dentro de um diagrama SmartArt. `SmartArtShape` pode ser usado para alterar `FillFormat`, `LineFormat`, adicionar hyperlinks etc.

{{% alert color="primary" %}} 

`SmartArtShape` não oferece suporte às propriedades de `IShape` `RawFrame`, `Frame`, `Rotation`, `X`, `Y`, `Width`, `Height` e lança `System.NotSupportedException` ao tentar acessá‑las.

{{% /alert %}} 

Exemplo de uso:

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

ISmartArtNode node = smart.getAllNodes().get_Item(0);

for (ISmartArtShape shape : node.getShapes())

{

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setColor(Color.RED);

}

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Classe SmartArtShapeCollection, interface ISmartArtShapeCollection e método ISmartArtNode.getShapes() adicionados**
A classe `Aspose.Slides.SmartArt.SmartArtShapeCollection` (e sua interface `Aspose.Slides.SmartArt.ISmartArtShapeCollection`) dão acesso às formas individuais dentro de um diagrama SmartArt. A coleção contém as formas associadas a um `SmartArtNode`. A propriedade `SmartArtNode.Shapes` retorna coleções de todas as formas associadas ao nó.

{{% alert color="primary" %}} 

Dependendo do `SmartArtLayoutType`, um `SmartArtShape` pode ser compartilhado entre vários nós.

{{% /alert %}} 

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

ISmartArtNode node = smart.getAllNodes().get_Item(0);

for (ISmartArtShape shape : node.getShapes())

{

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setColor(Color.RED);

}

pres.save("out.pptx", SaveFormat.Pptx);

```