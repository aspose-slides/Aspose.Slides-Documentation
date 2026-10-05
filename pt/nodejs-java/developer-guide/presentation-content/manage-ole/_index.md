---
title: Gerenciar OLE em Apresentações usando JavaScript
linktitle: Gerenciar OLE
type: docs
weight: 40
url: /pt/nodejs-java/manage-ole/
keywords:
- Objeto OLE
- Vinculação e Incorporação de Objetos
- Adicionar OLE
- Incorporar OLE
- Adicionar objeto
- Incorporar objeto
- Adicionar arquivo
- Incorporar arquivo
- Objeto vinculado
- Arquivo vinculado
- Alterar OLE
- Ícone OLE
- Título OLE
- Extrair OLE
- Extrair objeto
- Extrair arquivo
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Otimize o gerenciamento de objetos OLE no PowerPoint e em arquivos OpenDocument com Aspose.Slides para Node.js via Java. Incorpore, atualize e exporte conteúdo OLE de forma fluida."
---
## **Introdução**

{{% alert color="info" title="Nota" %}}

OLE (Object Linking & Embedding) é uma tecnologia da Microsoft que permite que dados e objetos criados em um aplicativo sejam inseridos em outro aplicativo por meio de vínculo ou incorporação. 

{{% /alert %}} 

Considere um gráfico criado no MS Excel. O gráfico é então colocado dentro de um slide do PowerPoint. Esse gráfico do Excel é considerado um objeto OLE. 

- Um objeto OLE pode aparecer como um ícone. Nesse caso, ao clicar duas vezes no ícone, o gráfico é aberto em seu aplicativo associado (Excel), ou é solicitado que você selecione um aplicativo para abrir ou editar o objeto.
- Um objeto OLE pode exibir seu conteúdo real, como o conteúdo de um gráfico. Nesse caso, o gráfico é ativado no PowerPoint, a interface do gráfico é carregada e você pode modificar os dados do gráfico dentro do PowerPoint.

[Aspose.Slides para Node.js via Java](https://products.aspose.com/slides/nodejs-java/) permite inserir objetos OLE em slides como quadros de objeto OLE ([OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame)).

## **Adicionando quadros de objeto OLE a slides**

Assumindo que você já criou um gráfico no Microsoft Excel e deseja incorporá‑lo em um slide como um quadro de objeto OLE usando Aspose.Slides para Node.js via Java, faça da seguinte forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Obtenha a referência de um slide por seu índice.
1. Leia o arquivo Excel como um array de bytes.
1. Adicione o [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) ao slide contendo o array de bytes e outras informações sobre o objeto OLE.
1. Grave a apresentação modificada como um arquivo PPTX.

No exemplo abaixo, adicionamos um gráfico de um arquivo Excel a um slide como um quadro de objeto OLE usando Aspose.Slides para Node.js via Java.  
**Nota** que o construtor [OleEmbeddedDataInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleEmbeddedDataInfo) recebe a extensão do objeto incorporável como segundo parâmetro. Essa extensão permite que o PowerPoint interprete corretamente o tipo de arquivo e escolha o aplicativo adequado para abrir esse objeto OLE.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

var presentation = new asposeSlides.Presentation();
var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(0);

// Prepare data for the OLE object.
var oleStream = fs.readFileSync("book.xlsx");
var fileData = Array.from(oleStream);
var dataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", fileData), "xlsx");

// Add the OLE object frame to the slide.
slide.getShapes().addOleObjectFrame(0, 0, slideSize.getWidth(), slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

### **Adicionando quadros de objeto OLE vinculados**

Aspose.Slides para Node.js via Java permite adicionar um [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) sem incorporar dados, mas apenas com um vínculo para o arquivo.

Este código JavaScript mostra como adicionar um [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) com um arquivo Excel vinculado a um slide:

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
var slide = presentation.getSlides().get_Item(0);

// Adicionar um quadro de objeto OLE com um arquivo Excel vinculado.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Acessando quadros de objeto OLE**

Se um objeto OLE já estiver incorporado em um slide, você pode encontrá‑lo ou acessá‑lo facilmente desta forma:

1. Carregue uma apresentação com o objeto OLE incorporado criando uma instância da classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Obtenha a referência do slide usando seu índice.
3. Acesse a forma [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame). No nosso exemplo, usamos o PPTX criado anteriormente que contém apenas uma forma no primeiro slide.
4. Depois que o quadro do objeto OLE for acessado, você pode executar qualquer operação nele.

No exemplo abaixo, um quadro de objeto OLE (um objeto de gráfico do Excel incorporado em um slide) e seus dados de arquivo são acessados.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;
    
    // Obter os dados do arquivo incorporado.
    var fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // Obter a extensão do arquivo incorporado.
    var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```

### **Acessando propriedades de quadros de objeto OLE vinculados**

Aspose.Slides permite acessar propriedades de quadros de objeto OLE vinculados.

Este código JavaScript mostra como verificar se um objeto OLE está vinculado e então obter o caminho do arquivo vinculado:

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.ppt");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    // Verificar se o objeto OLE está vinculado.
    if (oleFrame.isObjectLink()) {
        // Imprimir o caminho completo do arquivo vinculado.
        console.log("OLE object frame is linked to:", oleFrame.getLinkPathLong());

        // Imprimir o caminho relativo do arquivo vinculado, se presente.
        // Somente apresentações PPT podem conter o caminho relativo.
        if (oleFrame.getLinkPathRelative() != null && oleFrame.getLinkPathRelative() != "") {
            console.log("OLE object frame relative path:", oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **Alterando dados do objeto OLE**

{{% alert color="info" title="Nota" %}}

Nesta seção, o exemplo de código abaixo usa [Aspose.Cells for Java](https://docs.aspose.com/cells/java/).

{{% /alert %}}

Se um objeto OLE já estiver incorporado em um slide, você pode acessar esse objeto e modificar seus dados desta forma:

1. Carregue uma apresentação com o objeto OLE incorporado criando uma instância da classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Obtenha a referência do slide por seu índice. 
3. Acesse a forma do quadro do objeto OLE. No nosso exemplo, usamos o PPTX criado anteriormente que contém uma forma no primeiro slide.
4. Depois que o quadro do objeto OLE for acessado, você pode executar qualquer operação nele.
5. Crie um objeto `Workbook` e acesse os dados OLE.
6. Acesse a `Worksheet` desejada e ajuste os dados.
7. Salve o `Workbook` atualizado em um fluxo.
8. Substitua os dados do objeto OLE pelo fluxo.

No exemplo abaixo, um quadro de objeto OLE (um objeto de gráfico do Excel incorporado em um slide) é acessado e seus dados de arquivo são modificados para atualizar os dados do gráfico.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    var embeddedData = Array.from(oleFrame.getEmbeddedData().getEmbeddedFileData());
    var oleStream = java.newInstanceSync("java.io.ByteArrayInputStream", java.newArray("byte", embeddedData));

    // Ler os dados do objeto OLE como um objeto Workbook.
    var workbook = java.newInstanceSync("com.aspose.cells.Workbook", oleStream);

    var newOleStream = java.newInstanceSync("java.io.ByteArrayOutputStream");

    // Modificar os dados da pasta de trabalho.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    var fileOptions = java.newInstanceSync("com.aspose.cells.OoxmlSaveOptions", java.getStaticFieldValue("com.aspose.cells.SaveFormat", "XLSX"));
    workbook.save(newOleStream, fileOptions);

    // Alterar os dados do objeto do quadro OLE.
    var newFileData = java.newArray("byte", Array.from(newOleStream.toByteArray()));
    var newData = new asposeSlides.OleEmbeddedDataInfo(newFileData, oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);

    newOleStream.close();
    oleStream.close();
}

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Incorporando outros tipos de arquivos em slides**

Além de gráficos do Excel, Aspose.Slides para Node.js via Java permite incorporar outros tipos de arquivos em slides. Por exemplo, você pode inserir arquivos HTML, PDF e ZIP como objetos. Quando o usuário clica duas vezes no objeto inserido, ele abre automaticamente no programa relevante, ou o usuário é solicitado a selecionar um programa apropriado para abri‑lo.

Este código JavaScript mostra como incorporar HTML e ZIP em um slide:

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

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

## **Definindo tipos de arquivo para objetos incorporados**

Ao trabalhar com apresentações, pode ser necessário substituir objetos OLE antigos por novos ou substituir um objeto OLE não suportado por um suportado. Aspose.Slides para Node.js via Java permite definir o tipo de arquivo para um objeto incorporado, possibilitando atualizar os dados ou a extensão do quadro OLE.

Este código JavaScript mostra como definir o tipo de arquivo para um objeto OLE incorporado como `zip`:

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
var oleFileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

console.log("Current embedded file extension is:", fileExtension);

// Alterar o tipo de arquivo para ZIP.
var fileData = java.newArray("byte", Array.from(oleFileData));
oleFrame.setEmbeddedData(new asposeSlides.OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Definindo imagens de ícone e títulos para objetos incorporados**

Após incorporar um objeto OLE, uma pré‑visualização composta por uma imagem de ícone é adicionada automaticamente. Essa pré‑visualização é o que os usuários veem antes de acessar ou abrir o objeto OLE. Se você quiser usar uma imagem e um texto específicos como elementos da pré‑visualização, pode definir a imagem de ícone e o título usando Aspose.Slides para Node.js via Java.

Este código JavaScript mostra como definir a imagem de ícone e o título para um objeto incorporado:

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

// Adicionar uma imagem aos recursos da apresentação.
var image = asposeSlides.Images.fromFile("image.png");
var oleImage = presentation.getImages().addImage(image);
image.dispose();

// Set a title and the image for the OLE preview.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Impedindo que um quadro de objeto OLE seja redimensionado e reposicionado**

Depois de adicionar um objeto OLE vinculado a um slide de apresentação, ao abrir a apresentação no PowerPoint, pode aparecer uma mensagem solicitando a atualização dos vínculos. Ao clicar no botão “Update Links”, o tamanho e a posição do quadro do objeto OLE podem mudar porque o PowerPoint atualiza os dados do objeto OLE vinculado e refresh a pré‑visualização. Para impedir que o PowerPoint solicite a atualização dos dados do objeto, chame o método [setUpdateAutomatic](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) da classe [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/) com `false`:

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

oleFrame.setUpdateAutomatic(false);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Extraindo arquivos incorporados**

Aspose.Slides para Node.js via Java permite extrair os arquivos incorporados em slides como objetos OLE desta forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) que contém os objetos OLE que você pretende extrair.
2. Percorra todas as formas da apresentação e acesse as formas [OLEObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe).
3. Acesse os dados dos arquivos incorporados a partir dos quadros de objeto OLE e grave‑os no disco.

Este código JavaScript mostra como extrair arquivos incorporados em um slide como objetos OLE:

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

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

O que está visível no slide é renderizado — o ícone/imagem de substituição (pré‑visualização). O conteúdo OLE “ao vivo” não é executado durante a renderização. Se necessário, defina sua própria imagem de pré‑visualização para garantir a aparência esperada no PDF exportado.

Para também preservar o arquivo incorporado como anexo PDF, chame [setIncludeOleData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/#setIncludeOleData) com `true`. Essa opção está desativada por padrão. Para um exemplo e instruções sobre como verificar o anexo, veja [Preserve Embedded OLE Files as PDF Attachments](/slides/pt/nodejs-java/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**Como bloquear um objeto OLE em um slide para que os usuários não possam movê‑lo/editar‑lo no PowerPoint?**

Bloqueie a forma: Aspose.Slides fornece bloqueios ao nível da forma. Não se trata de criptografia, mas impede efetivamente edições e movimentações acidentais.

**Os caminhos relativos para objetos OLE vinculados são preservados no formato PPTX?**

No PPTX, a informação de “caminho relativo” não está disponível — apenas o caminho completo. Caminhos relativos são encontrados no formato PPT mais antigo. Para portabilidade, prefira caminhos absolutos confiáveis/URIs acessíveis ou incorporação.