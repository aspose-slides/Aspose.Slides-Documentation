---
title: API Pública e Alterações Incompatíveis Retroativas no Aspose.Slides para Java 14.9.0
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
description: "Revise as atualizações da API pública e as alterações incompatíveis no Aspose.Slides para Java para migrar suavemente suas soluções de apresentação PowerPoint PPT, PPTX e ODP."
---
{{% alert color="info" %}} 

Esta página lista todas as classes, métodos, propriedades e etc. [adicionadas](/slides/pt/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) , quaisquer novas restrições e outras [alterações](/slides/pt/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) introduzidas com a API Aspose.Slides for Java 14.9.0.

{{% /alert %}} 
## **Alterações da API Pública**
### **Métodos adicionados para substituir Image por PPImage, IPPImage**
Novos métodos adicionados:

- IPPImage.replaceImage(byte[] newImageData)
- IPPImage.replaceImage(IPPImage newImage)

``` java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("presentation.pptx");
try {
    // A primeira forma
    byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
    presentation.getImages().get_Item(0).replaceImage(imageData);

    // A segunda forma
    presentation.getImages().get_Item(1).replaceImage(presentation.getImages().get_Item(0));

    presentation.save("presentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```
### **Métodos adicionados para salvar slides mantendo números de página**
Os seguintes métodos foram adicionados:

- void IPresentation.save(string fname, int[] slides, SaveFormat format);
- void IPresentation.save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

Esses métodos permitem salvar slides de apresentação especificados em formatos PDF, XPS, TIFF, HTML. O array 'slides' permite especificar números de página, começando em 1.

``` java
// Sobrecargas adicionadas ao IPresentation (valores de SaveFormat são constantes int em Java):
//
// void save(String fname, int[] slides, int format);
// void save(String fname, int[] slides, int format, ISaveOptions options);
// void save(OutputStream stream, int[] slides, int format);
// void save(OutputStream stream, int[] slides, int format, ISaveOptions options);
```




``` java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    int[] slides = new int[] { 2, 3, 5 }; // Array de posições dos slides

    presentation.save("presentation_out.pdf", slides, SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();
}
```
### **Valor enum SmartArtLayoutType.Custom adicionado**
Este tipo de layout SmartArt representa um diagrama com modelo customizado. Diagramas customizados só podem ser carregados a partir de um arquivo de apresentação e não podem ser criados via método ShapeCollection.addSmartArt(x, y, width, height, SmartArtLayoutType.Custom)
### **Classe SmartArtShape e interface ISmartArtShape adicionadas**
A classe Aspose.Slides.SmartArt.SmartArtShape (e sua interface Aspose.Slides.SmartArt.ISmartArtShape) adicionam acesso a formas individuais dentro de um diagrama SmartArt. SmartArtShape pode ser usado para alterar FillFormat, LineFormat, adicionar Hyperlinks etc.

{{% alert color="info" %}} 

SmartArtShape não oferece suporte às propriedades IShape RawFrame, Frame, Rotation, X, Y, Width, Height e lança System.NotSupportedException ao tentar acessá‑las.

{{% /alert %}} 

Exemplo de uso:

``` java
import com.aspose.slides.*;
import java.awt.Color;


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
A classe Aspose.Slides.SmartArt.SmartArtShapeCollection (e sua interface Aspose.Slides.SmartArt.ISmartArtShapeCollection) adicionam acesso a formas individuais dentro de um diagrama SmartArt. A coleção contém formas associadas ao SmartArtNode. A propriedade SmartArtNode.Shapes retorna coleções de todas as formas associadas ao nó.

{{% alert color="info" %}} 

Dependendo do SmartArtLayoutType, um SmartArtShape pode ser compartilhado entre vários nós.

{{% /alert %}} 


``` java
import com.aspose.slides.*;
import java.awt.Color;


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