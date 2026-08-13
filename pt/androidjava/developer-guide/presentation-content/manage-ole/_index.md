---
title: Gerenciar OLE em Apresentações no Android
linktitle: Gerenciar OLE
type: docs
weight: 40
url: /pt/androidjava/manage-ole/
keywords:
- objeto OLE
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
- Android
- Java
- Aspose.Slides
description: "Otimize o gerenciamento de objetos OLE no PowerPoint e em arquivos OpenDocument com Aspose.Slides para Android via Java. Incorpore, atualize e exporte conteúdo OLE de forma contínua."
---
## **Introdução**

{{% alert color="info" %}} 

OLE (Object Linking & Embedding) é uma tecnologia da Microsoft que permite que dados e objetos criados em um aplicativo sejam colocados em outro aplicativo por meio de vinculação ou incorporação. 

{{% /alert %}} 

Considere um gráfico criado no MS Excel. O gráfico é então colocado dentro de um slide do PowerPoint. Esse gráfico do Excel é considerado um objeto OLE. 

- Um objeto OLE pode aparecer como um ícone. Nesse caso, ao clicar duas vezes no ícone, o gráfico é aberto em seu aplicativo associado (Excel), ou você é solicitado a selecionar um aplicativo para abrir ou editar o objeto. 
- Um objeto OLE pode exibir seu conteúdo real, como o conteúdo de um gráfico. Nesse caso, o gráfico é ativado no PowerPoint, a interface do gráfico é carregada e você pode modificar os dados do gráfico dentro do PowerPoint. 

[Aspose.Slides for Android via Java](https://products.aspose.com/slides/pt/androidjava/) permite inserir objetos OLE em slides como quadros de objeto OLE ([OleObjectFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/OleObjectFrame)).

## **Adicionar Quadros de Objeto OLE aos Slides**

Assumindo que você já criou um gráfico no Microsoft Excel e deseja incorporá‑lo em um slide como um quadro de objeto OLE usando Aspose.Slides for Android via Java, você pode fazer isso da seguinte forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation). 
2. Obtenha a referência de um slide por meio de seu índice. 
3. Leia o arquivo Excel como um array de bytes. 
4. Adicione o [OleObjectFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/OleObjectFrame) ao slide contendo o array de bytes e outras informações sobre o objeto OLE. 
5. Grave a apresentação modificada como um arquivo PPTX. 

No exemplo abaixo, adicionamos um gráfico de um arquivo Excel a um slide como um quadro de objeto OLE usando Aspose.Slides for Android via Java.  
**Nota** que o construtor [OleEmbeddedDataInfo](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/OleEmbeddedDataInfo) recebe uma extensão de objeto incorporável como segundo parâmetro. Essa extensão permite que o PowerPoint interprete corretamente o tipo de arquivo e escolha o aplicativo correto para abrir esse objeto OLE.

```java 
import com.aspose.slides.*;
import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// Prepare data for the OLE object.
File file = new File("book.xlsx");
byte fileData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(fileData);

IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Add the OLE object frame to the slide.
slide.getShapes().addOleObjectFrame(0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **Adicionar Quadros de Objeto OLE Vinculados**

Aspose.Slides for Android via Java permite adicionar um [OleObjectFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/OleObjectFrame) sem incorporar dados, mas apenas com um link para o arquivo.

Este código Java mostra como adicionar um [OleObjectFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/OleObjectFrame) com um arquivo Excel vinculado a um slide:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Adicione um quadro de objeto OLE com um arquivo Excel vinculado.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Acessar Quadros de Objeto OLE**

Se um objeto OLE já estiver incorporado em um slide, você pode encontrá‑lo ou acessá‑lo facilmente desta forma:

1. Carregue uma apresentação com o objeto OLE incorporado criando uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation). 
2. Obtenha a referência do slide usando seu índice. 
3. Acesse a forma [OleObjectFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/OleObjectFrame).  
   No nosso exemplo, usamos o PPTX criado anteriormente que tem apenas uma forma no primeiro slide. Em seguida, *convertimos* esse objeto para um [IOleObjectFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ioleobjectframe/). Esse era o quadro de objeto OLE desejado para acesso. 
4. Depois que o quadro de objeto OLE for acessado, você pode realizar qualquer operação nele. 

No exemplo abaixo, um quadro de objeto OLE (um objeto de gráfico Excel incorporado em um slide) e seus dados de arquivo são acessados.

```java 
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;
    
    // Obtenha os dados do arquivo incorporado.
    byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // Obtenha a extensão do arquivo incorporado.
    String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```

### **Acessar Propriedades do Quadro de Objeto OLE Vinculado**

Aspose.Slides permite acessar propriedades de quadros de objeto OLE vinculados.

Este código Java mostra como verificar se um objeto OLE está vinculado e, em seguida, obter o caminho do arquivo vinculado:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // Verifique se o objeto OLE está vinculado.
    if (oleFrame.isObjectLink()) {
        // Imprima o caminho completo do arquivo vinculado.
        System.out.println("OLE object frame is linked to: " + oleFrame.getLinkPathLong());

        // Imprima o caminho relativo do arquivo vinculado, se presente.
        // Apenas as apresentações PPT podem conter o caminho relativo.
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **Alterar Dados do Objeto OLE**

{{% alert color="info" %}} 

Nesta seção, o exemplo de código abaixo usa [Aspose.Cells for Android via Java](/cells/androidjava/). 

{{% /alert %}}

Se um objeto OLE já estiver incorporado em um slide, você pode acessar esse objeto e modificar seus dados desta forma:

1. Carregue uma apresentação com o objeto OLE incorporado criando uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation). 
2. Obtenha a referência do slide por meio de seu índice. 
3. Acesse a forma do quadro de objeto OLE.  
   No nosso exemplo, usamos o PPTX criado anteriormente que tem uma forma no primeiro slide. Em seguida, *convertimos* esse objeto para um [IOleObjectFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ioleobjectframe/). Esse era o quadro de objeto OLE desejado para acesso. 
4. Depois que o quadro de objeto OLE for acessado, você pode realizar qualquer operação nele. 
5. Crie um objeto `Workbook` e acesse os dados OLE. 
6. Acesse a `Worksheet` desejada e altere os dados. 
7. Salve o `Workbook` atualizado em um fluxo. 
8. Altere os dados do objeto OLE a partir do fluxo. 

No exemplo abaixo, um quadro de objeto OLE (um objeto de gráfico Excel incorporado em um slide) é acessado e seus dados de arquivo são modificados para atualizar os dados do gráfico.

```java 
import com.aspose.slides.*;
import com.aspose.cells.Workbook;
import com.aspose.cells.OoxmlSaveOptions;
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    ByteArrayInputStream oleStream = new ByteArrayInputStream(oleFrame.getEmbeddedData().getEmbeddedFileData());

    // Leia os dados do objeto OLE como um objeto Workbook.
    Workbook workbook = new Workbook(oleStream);

    ByteArrayOutputStream newOleStream = new ByteArrayOutputStream();

    // Modifique os dados da planilha.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(com.aspose.cells.SaveFormat.XLSX);
    workbook.save(newOleStream, fileOptions);

    // Altere os dados do objeto do quadro OLE.
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Incorporar Outros Tipos de Arquivo em Slides**

Além de gráficos Excel, Aspose.Slides for Android via Java permite incorporar outros tipos de arquivos em slides. Por exemplo, você pode inserir arquivos HTML, PDF e ZIP como objetos. Quando o usuário clica duas vezes no objeto inserido, ele é aberto automaticamente no programa relevante, ou o usuário é solicitado a selecionar um programa apropriado para abri‑lo.

Este código Java mostra como incorporar HTML e ZIP em um slide:

```java
import com.aspose.slides.*;
import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

File fileHtml = new File("sample.html");
byte htmlData[] = new byte[(int) fileHtml.length()];
BufferedInputStream bisHtml = new BufferedInputStream(new FileInputStream(fileHtml));
DataInputStream disHtml = new DataInputStream(bisHtml);
disHtml.readFully(htmlData);
IOleEmbeddedDataInfo htmlDataInfo = new OleEmbeddedDataInfo(htmlData, "html");
IOleObjectFrame htmlOleFrame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame.setObjectIcon(true);

File fileZip = new File("sample.zip");
byte zipData[] = new byte[(int) fileZip.length()];
BufferedInputStream bisZip = new BufferedInputStream(new FileInputStream(fileZip));
DataInputStream disZip = new DataInputStream(bisZip);
disZip.readFully(zipData);
IOleEmbeddedDataInfo zipDataInfo = new OleEmbeddedDataInfo(zipData, "zip");
IOleObjectFrame zipOleFrame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Definir Tipos de Arquivo para Objetos Incorporados**

Ao trabalhar com apresentações, pode ser necessário substituir objetos OLE antigos por novos ou substituir um objeto OLE não suportado por um suportado. Aspose.Slides for Android via Java permite definir o tipo de arquivo para um objeto incorporado, possibilitando atualizar os dados do quadro OLE ou sua extensão.

Este código Java mostra como definir o tipo de arquivo para um objeto OLE incorporado como `zip`:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

System.out.println("Current embedded file extension is: " + fileExtension);

// Alterar o tipo de arquivo para ZIP.
oleFrame.setEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Definir Imagens de Ícone e Títulos para Objetos Incorporados**

Depois de incorporar um objeto OLE, uma visualização composta por uma imagem de ícone é adicionada automaticamente. Essa visualização é o que os usuários veem antes de acessar ou abrir o objeto OLE. Se desejar usar uma imagem e um texto específicos como elementos da visualização, você pode definir a imagem de ícone e o título usando Aspose.Slides for Android via Java.

Este código Java mostra como definir a imagem de ícone e o título para um objeto incorporado:

```java
import com.aspose.slides.*;
import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// Adicionar uma imagem aos recursos da apresentação.
File file = new File("image.png");
byte imageData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(imageData);
IPPImage oleImage = presentation.getImages().addImage(imageData);

// Definir um título e a imagem para a visualização do OLE.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Impedir que um Quadro de Objeto OLE seja Redimensionado e Reposicionado**

Após adicionar um objeto OLE vinculado a um slide de apresentação, ao abrir a apresentação no PowerPoint, pode aparecer uma mensagem solicitando a atualização dos links. Clicar no botão “Update Links” pode alterar o tamanho e a posição do quadro de objeto OLE porque o PowerPoint atualiza os dados do objeto OLE vinculado e refresca a visualização do objeto. Para impedir que o PowerPoint solicite a atualização dos dados do objeto, defina o método `setUpdateAutomatic` da interface [IOleObjectFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ioleobjectframe/) para `false`:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    oleFrame.setUpdateAutomatic(false);

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Extrair Arquivos Incorporados**

Aspose.Slides for Android via Java permite extrair os arquivos incorporados em slides como objetos OLE da seguinte maneira:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation) que contenha os objetos OLE que você pretende extrair. 
2. Percorra todas as formas da apresentação e acesse as formas [OLEObjectFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/oleobjectframe). 
3. Acesse os dados dos arquivos incorporados a partir dos quadros de objeto OLE e grave‑os em disco. 

Este código Java mostra como extrair arquivos incorporados em um slide como objetos OLE:

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);

for (int index = 0; index < slide.getShapes().size(); index++) {
    IShape shape = slide.getShapes().get_Item(index);

    if (shape instanceof IOleObjectFrame) {
        IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

        byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();
        String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

        FileOutputStream fos = new FileOutputStream(new File("OLE_object_" + index + fileExtension));
        fos.write(fileData);
        fos.close();
    }
}

presentation.dispose();
```

## **FAQ**

### O conteúdo OLE será renderizado ao exportar slides para PDF/imagens?

O que está visível no slide é renderizado — o ícone/imagem substituta (visualização). O conteúdo OLE “ativo” não é executado durante a renderização. Se necessário, configure sua própria imagem de visualização para garantir a aparência esperada no PDF exportado.

### Como posso bloquear um objeto OLE em um slide para que os usuários não possam movê‑lo/editar no PowerPoint?

Bloqueie a forma: Aspose.Slides oferece bloqueios em nível de forma. Não se trata de criptografia, mas impede efetivamente edições e movimentações acidentais.

### Por que um objeto Excel vinculado “salta” ou muda de tamanho quando abro a apresentação?

O PowerPoint pode atualizar a visualização do OLE vinculado. Para uma aparência estável, siga as práticas da [Working Solution for Worksheet Resizing](/slides/pt/androidjava/working-solution-for-worksheet-resizing/) — ajuste o quadro ao intervalo ou escale o intervalo para um quadro fixo e defina uma imagem substituta adequada.

### Os caminhos relativos para objetos OLE vinculados serão preservados no formato PPTX?

No PPTX, as informações de “caminho relativo” não estão disponíveis — apenas o caminho completo. Caminhos relativos são encontrados no formato PPT mais antigo. Para portabilidade, prefira caminhos absolutos confiáveis/URIs acessíveis ou incorporação.