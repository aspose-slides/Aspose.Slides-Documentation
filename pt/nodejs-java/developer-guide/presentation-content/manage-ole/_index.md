---
title: Gerenciar OLE em Apresentações Usando JavaScript
linktitle: Gerenciar OLE
type: docs
weight: 40
url: /pt/nodejs-java/manage-ole/
keywords:
  - Objeto OLE
  - Vinculação e Incorporação de Objetos
  - adicionar OLE
  - incorporar OLE
  - adicionar objeto
  - incorporar objeto
  - adicionar arquivo
  - incorporar arquivo
  - objeto vinculado
  - arquivo vinculado
  - alterar OLE
  - ícone OLE
  - título OLE
  - extrair OLE
  - extrair objeto
  - extrair arquivo
  - PowerPoint
  - apresentação
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "Otimize o gerenciamento de objetos OLE no PowerPoint e em arquivos OpenDocument com Aspose.Slides para Node.js via Java. Incorpore, atualize e exporte o conteúdo OLE de forma contínua."
---
## **Introdução**

{{% alert color="primary" %}} 

OLE (Object Linking & Embedding) é uma tecnologia da Microsoft que permite que dados e objetos criados em um aplicativo sejam colocados em outro aplicativo por meio de vinculação ou incorporação. 

{{% /alert %}} 

Considere um gráfico criado no MS Excel. O gráfico é então inserido em um slide do PowerPoint. Esse gráfico do Excel é considerado um objeto OLE. 

- Um objeto OLE pode aparecer como um ícone. Nesse caso, ao clicar duas vezes no ícone, o gráfico é aberto em seu aplicativo associado (Excel), ou é solicitado que você selecione um aplicativo para abrir ou editar o objeto. 
- Um objeto OLE pode exibir seu conteúdo real, como o conteúdo de um gráfico. Nesse caso, o gráfico é ativado no PowerPoint, a interface do gráfico é carregada e você pode modificar os dados do gráfico dentro do PowerPoint.

[Aspose.Slides para Node.js via Java](https://products.aspose.com/slides/pt/nodejs-java/) permite inserir OLE Objects em slides como quadros de objeto OLE ([OleObjectFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/OleObjectFrame)).

## **Adicionando Quadros de Objeto OLE a Slides**

Supondo que você já tenha criado um gráfico no Microsoft Excel e queira incorporá‑lo em um slide como um quadro de objeto OLE usando Aspose.Slides para Node.js via Java, faça o seguinte:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation). 
1. Obtenha a referência de um slide através de seu índice. 
1. Leia o arquivo Excel como um array de bytes. 
1. Adicione o [OleObjectFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/OleObjectFrame) ao slide contendo o array de bytes e outras informações sobre o objeto OLE. 
1. Grave a apresentação modificada como um arquivo PPTX. 

No exemplo abaixo, adicionamos um gráfico de um arquivo Excel a um slide como um quadro de objeto OLE usando Aspose.Slides para Node.js via Java.  
**Nota** que o construtor [OleEmbeddedDataInfo](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/OleEmbeddedDataInfo) aceita uma extensão de objeto incorporável como segundo parâmetro. Essa extensão permite que o PowerPoint interprete corretamente o tipo de arquivo e escolha o aplicativo correto para abrir esse objeto OLE.

```javascript
var presentation = new asposeSlides.Presentation();
var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(0);

// Prepare os dados para o objeto OLE.
var oleStream = fs.readFileSync("book.xlsx");
var fileData = Array.from(oleStream);
var dataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", fileData), "xlsx");

// Adicione o quadro do objeto OLE ao slide.
slide.getShapes().addOleObjectFrame(0, 0, slideSize.getWidth(), slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

### **Adicionando Quadros de Objeto OLE Vinculados**

Aspose.Slides para Node.js via Java permite adicionar um [OleObjectFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/OleObjectFrame) sem incorporar dados, mas apenas com um vínculo para o arquivo.

Esse código JavaScript mostra como adicionar um [OleObjectFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/OleObjectFrame) com um arquivo Excel vinculado a um slide:

```javascript
var presentation = new asposeSlides.Presentation();
var slide = presentation.getSlides().get_Item(0);

// Adicione um quadro de objeto OLE com um arquivo Excel vinculado.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Acessando Quadros de Objeto OLE**

Se um objeto OLE já estiver incorporado em um slide, você pode encontrá‑lo ou acessá‑lo facilmente assim:

1. Carregue uma apresentação com o objeto OLE incorporado criando uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation). 
2. Obtenha a referência do slide usando seu índice. 
3. Acesse a forma [OleObjectFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/OleObjectFrame). No nosso exemplo, usamos o PPTX criado anteriormente que contém apenas uma forma no primeiro slide. 
4. Depois que o quadro de objeto OLE for acessado, você pode executar qualquer operação nele. 

No exemplo abaixo, um quadro de objeto OLE (um objeto de gráfico Excel incorporado em um slide) e seus dados de arquivo são acessados.

```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;
    
    // Obtenha os dados do arquivo incorporado.
    var fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // Obtenha a extensão do arquivo incorporado.
    var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```

### **Acessando Propriedades de Quadros de Objeto OLE Vinculados**

Aspose.Slides permite acessar as propriedades de quadros de objeto OLE vinculados.

Esse código JavaScript mostra como verificar se um objeto OLE está vinculado e, em seguida, obter o caminho do arquivo vinculado:

```javascript
var presentation = new asposeSlides.Presentation("sample.ppt");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    // Verifique se o objeto OLE está vinculado.
    if (oleFrame.isObjectLink()) {
        // Imprima o caminho completo do arquivo vinculado.
        console.log("OLE object frame is linked to:", oleFrame.getLinkPathLong());

        // Imprima o caminho relativo do arquivo vinculado, se presente.
        // Somente apresentações PPT podem conter o caminho relativo.
        if (oleFrame.getLinkPathRelative() != null && oleFrame.getLinkPathRelative() != "") {
            console.log("OLE object frame relative path:", oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **Alterando Dados de Objeto OLE**

{{% alert color="primary" %}} 

Nesta seção, o exemplo de código abaixo usa [Aspose.Cells for Java](/cells/java/). 

{{% /alert %}}

Se um objeto OLE já estiver incorporado em um slide, você pode facilmente acessar esse objeto e modificar seus dados da seguinte forma:

1. Carregue uma apresentação com o objeto OLE incorporado criando uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation). 
2. Obtenha a referência do slide através de seu índice. 
3. Acesse a forma do quadro de objeto OLE. No nosso exemplo, usamos o PPTX criado anteriormente que contém uma forma no primeiro slide. 
4. Depois que o quadro de objeto OLE for acessado, você pode executar qualquer operação nele. 
5. Crie um objeto `Workbook` e acesse os dados OLE. 
6. Acesse a `Worksheet` desejada e altere os dados. 
7. Salve o `Workbook` atualizado em um stream. 
8. Substitua os dados do objeto OLE a partir do stream. 

No exemplo abaixo, um quadro de objeto OLE (um objeto de gráfico Excel incorporado em um slide) é acessado e seus dados de arquivo são modificados para atualizar os dados do gráfico.

```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    var oleStream = java.newInstanceSync("java.io.ByteArrayInputStream", oleFrame.getEmbeddedData().getEmbeddedFileData());

    // Leia os dados do objeto OLE como um objeto Workbook.
    var workbook = java.newInstanceSync("Workbook", oleStream);

    var newOleStream = java.newInstanceSync("java.io.ByteArrayOutputStream");

    // Modifique os dados da workbook.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    var fileOptions = java.newInstanceSync("OoxmlSaveOptions", java.getStaticFieldValue("com.aspose.cells.SaveFormat", "XLSX"));
    workbook.save(newOleStream, fileOptions);

    // Altere os dados do objeto do quadro OLE.
    var newData = new asposeSlides.OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);

    newOleStream.close();
    oleStream.close();
}

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Incorporando Outros Tipos de Arquivo em Slides**

Além de gráficos Excel, Aspose.Slides para Node.js via Java permite incorporar outros tipos de arquivos em slides. Por exemplo, você pode inserir arquivos HTML, PDF e ZIP como objetos. Quando o usuário clica duas vezes no objeto inserido, ele é aberto automaticamente no programa relevante, ou o usuário é solicitado a selecionar um programa apropriado para abri‑lo.

Esse código JavaScript mostra como incorporar HTML e ZIP em um slide:

```javascript
var presentation = new asposeSlides.Presentation();
var slide = presentation.getSlides().get_Item(0);

var htmlBuffer = fs.readFileSync("sample.html");
var htmlData = Array.from(htmlBuffer);
var htmlDataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", htmlData), "html");
var htmlOleFrame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame.setObjectIcon(true);

var zipBuffer = fs.readFileSync("sample.zip");
var zipData = Array.from(zipBuffer);
var zipDataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", zipData), "zip");
var zipOleFrame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame.setObjectIcon(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Definindo Tipos de Arquivo para Objetos Incorporados**

Ao trabalhar com apresentações, pode ser necessário substituir objetos OLE antigos por novos ou substituir um objeto OLE não suportado por um suportado. Aspose.Slides para Node.js via Java permite definir o tipo de arquivo para um objeto incorporado, possibilitando atualizar os dados do quadro OLE ou sua extensão.

Esse código JavaScript mostra como definir o tipo de arquivo para um objeto OLE incorporado como `zip`:

```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
var oleFileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

console.log("Current embedded file extension is:", fileExtension);

// Change the file type to ZIP.
var fileData = java.newArray("byte", Array.from(oleFileData));
oleFrame.setEmbeddedData(new asposeSlides.OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Definindo Imagens de Ícone e Títulos para Objetos Incorporados**

Após incorporar um objeto OLE, uma pré‑visualização composta por uma imagem de ícone é adicionada automaticamente. Essa pré‑visualização é o que os usuários veem antes de acessar ou abrir o objeto OLE. Se desejar usar uma imagem e um texto específicos como elementos da pré‑visualização, você pode definir a imagem de ícone e o título usando Aspose.Slides para Node.js via Java.

Esse código JavaScript mostra como definir a imagem de ícone e o título para um objeto incorporado:

```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

// Adicione uma imagem aos recursos da apresentação.
var image = asposeSlides.Images.fromFile("image.png");
var oleImage = presentation.getImages().addImage(image);
image.dispose();

// Defina um título e a imagem para a pré-visualização OLE.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Impedir que um Quadro de Objeto OLE Seja Redimensionado e Reposicionado**

Depois de adicionar um objeto OLE vinculado a um slide da apresentação, ao abrir a apresentação no PowerPoint, pode aparecer uma mensagem solicitando a atualização dos vínculos. Clicar no botão “Update Links” pode mudar o tamanho e a posição do quadro de objeto OLE porque o PowerPoint atualiza os dados do objeto OLE vinculado e refresca a pré‑visualização do objeto. Para impedir que o PowerPoint solicite a atualização dos dados do objeto, use o método `setUpdateAutomatic` da classe [OleObjectFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/oleobjectframe/) com o valor `false`:

```javascript
oleFrame.setUpdateAutomatic(false);
```

## **Extraindo Arquivos Incorporados**

Aspose.Slides para Node.js via Java permite extrair os arquivos incorporados em slides como objetos OLE da seguinte forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation) contendo os objetos OLE que você pretende extrair. 
2. Percorra todas as formas da apresentação e acesse as formas [OLEObjectFrame]. 
3. Acesse os dados dos arquivos incorporados a partir dos quadros de objeto OLE e grave‑os no disco. 

Esse código JavaScript mostra como extrair arquivos incorporados em um slide como objetos OLE:

```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);

for (var index = 0; index < slide.getShapes().size(); index++) {
    var shape = slide.getShapes().get_Item(index);

    if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
        var oleFrame = shape;

        var fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();
        var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

        var filePath = "OLE_object_" + index + fileExtension;
        fs.writeFileSync(filePath, Buffer.from(fileData));
    }
}

presentation.dispose();
```

## **FAQ**

**O conteúdo OLE será renderizado ao exportar slides para PDF/imagens?**

O que está visível no slide é renderizado — o ícone/imagem substituta (pré‑visualização). O conteúdo OLE “ao vivo” não é executado durante a renderização. Se necessário, defina sua própria imagem de pré‑visualização para garantir a aparência esperada no PDF exportado.

**Como posso bloquear um objeto OLE em um slide para que os usuários não possam movê‑lo/editar‑lo no PowerPoint?**

Bloqueie a forma: Aspose.Slides fornece bloqueios em nível de forma. Não se trata de criptografia, mas impede efetivamente edições e movimentações acidentais.

**Os caminhos relativos para objetos OLE vinculados serão preservados no formato PPTX?**

No PPTX, a informação de “caminho relativo” não está disponível — apenas o caminho completo. Caminhos relativos são encontrados no formato mais antigo PPT. Para portabilidade, prefira caminhos absolutos confiáveis/URIs acessíveis ou incorporação.