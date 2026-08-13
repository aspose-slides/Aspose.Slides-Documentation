---
title: API Pública e Alterações Incompatíveis Retroativas no Aspose.Slides para Java 15.4.0
linktitle: Aspose.Slides para Java 15.4.0
type: docs
weight: 120
url: /pt/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/
keywords:
- migração
- código legado
- código moderno
- abordagem legado
- abordagem moderna
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Reveja as atualizações da API pública e mudanças disruptivas no Aspose.Slides para Java para migrar suavemente suas soluções de apresentação PowerPoint PPT, PPTX e ODP."
---
{{% alert color="info" %}} 

Essa página lista todos os [adicionados](/slides/pt/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) classes, métodos, propriedades etc., quaisquer novas restrições e outras [alterações](/slides/pt/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) introduzidas com a API do Aspose.Slides for Java 15.4.0.

{{% /alert %}} 
## **Alterações da API Pública**
### **Enum OrganizationChartLayoutType foi adicionado**
O enum com.aspose.slides.OrganizationChartLayoutType representa o tipo de formatação dos nós filhos em um organograma.
### **Método IBulletFormat.applyDefaultParagraphIndentsShifts() foi adicionado**
O método com.aspose.slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts define deslocamentos padrão diferentes de zero para o recuo de parágrafo e MarginLeft efetivo quando as marcas são habilitadas (como o PowerPoint faz ao habilitar marcadores/numerção de parágrafo). Se as marcas estiverem desabilitadas, apenas redefinem o recuo de parágrafo e MarginLeft (como o PowerPoint faz ao desabilitar marcadores/numerção de parágrafo).
### **Método IConnector.reroute() foi adicionado**
O método com.aspose.slides.IConnector.reroute() redireciona o conector para que ele siga o caminho mais curto possível entre as formas que conecta. Para isso, o método reroute() pode alterar os índices StartShapeConnectionSiteIndex e EndShapeConnectionSiteIndex.

``` java
import com.aspose.slides.*;


 Presentation input = new Presentation();

IShapeCollection shapes = input.getSlides().get_Item(0).getShapes();

IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

connector.setStartShapeConnectedTo(ellipse);

connector.setEndShapeConnectedTo(rectangle);

connector.reroute();

input.save("output.pptx", SaveFormat.Pptx);

```
### **Método IPresentation.getSlideById(long) foi adicionado**
O método Aspose.Slides.IPresentation.getSlideById(long) retorna um Slide, MasterSlide ou LayoutSlide pelo Id do slide.

``` java
import com.aspose.slides.*;


 Presentation presentation = new Presentation();

long id = presentation.getSlides().get_Item(0).getSlideId();

IBaseSlide slide = presentation.getSlideById(id);

```
### **Método ISmartArt.getNodes() foi adicionado**
O método com.aspose.slides.ISmartArt.getNodes() retorna a coleção de nós raiz no objeto SmartArt.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

ISmartArtNode node = smart.getNodes().get_Item(1); // selecionar o segundo nó raiz

node.getTextFrame().setText("Second root node");

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Método ISmartArt.setLayout(int) foi adicionado**
O método para a propriedade com.aspose.slides.ISmartArt.setLayout(int) foi adicionado. Ele permite alterar o tipo de layout de um diagrama existente.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

smart.setLayout(SmartArtLayoutType.BasicProcess);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Método ISmartArtNode.isHidden() foi adicionado**
O método com.aspose.slides.ISmartArtNode.isHidden() retorna true se este nó for um nó oculto no modelo de dados.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

ISmartArtNode node = smart.getAllNodes().addNode();

boolean hidden = node.isHidden(); //retorna true

if(hidden) {

    //executar algumas ações ou notificações

}

pres.save("out.pptx", SaveFormat.Pptx);
```
### **Métodos ISmartArt.isReversed(), setReversed() foram adicionados**
A propriedade com.aspose.slides.ISmartArt.IsReversed permite obter ou definir o estado do diagrama SmartArt em relação ao (esquerda-para-direita) LTR ou (direita-para-esquerda) RTL, se o diagrama suportar reversão.

``` java
import com.aspose.slides.*;


 Presentation presentation = new Presentation();

ISmartArt smart = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

smart.setReversed(true);

presentation.save("out.pptx", SaveFormat.Pptx);

```
### **Métodos ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) foram adicionados**
Os métodos com.aspose.slides.ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) permitem obter ou definir o tipo de organograma associado ao nó atual.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Propriedade IShape.getConnectionSiteCount() foi adicionada**
A propriedade com.aspose.slides.getConnectionSiteCount() retorna o número de pontos de conexão na forma.

``` java
import com.aspose.slides.*;


 Presentation input = new Presentation();

IShapeCollection shapes = input.getSlides().get_Item(0).getShapes();

IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 200, 100, 100);

connector.setStartShapeConnectedTo(ellipse);

connector.setEndShapeConnectedTo(rectangle);

long wantedIndex = 6;

if (ellipse.getConnectionSiteCount() > wantedIndex) {

  connector.setStartShapeConnectionSiteIndex(wantedIndex);

}

input.save("output.pptx", SaveFormat.Pptx);

```
### **Alterações Menores**
Esta é a lista de alterações menores da API:

|Enum com.aspose.slides.BevelColorMode |excluído, enum não utilizado |
| :- | :- |
|Método ThreeDFormatEffectiveData.getBevelColorMode() |excluído, propriedade não utilizada |
|Método com.aspose.slides.ChartSeriesGroup.getChart() |adicionado |
|Herança de IParagraphFormatEffectiveData de ISlideComponent <br>Herança de IThreeDFormat de ISlideComponent |excluído |
|Método com.aspose.slides.ParagraphFormatEffectiveData.getBulletChar() <br>Método com.aspose.slides.ParagraphFormatEffectiveData.getBulletFont() <br>Método com.aspose.slides.ParagraphFormatEffectiveData.getBulletHeight() <br>Método com.aspose.slides.ParagraphFormatEffectiveData.getBulletType() <br>Método com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStartWith() <br>Método com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStyle() |excluído como obsoleto |