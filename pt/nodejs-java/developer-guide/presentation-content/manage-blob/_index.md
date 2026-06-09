---
title: Gerenciar BLOBs de Apresentação em JavaScript para Uso Eficiente de Memória
linktitle: Gerenciar BLOB
type: docs
weight: 10
url: /pt/nodejs-java/manage-blob/
keywords:
- objeto grande
- item grande
- arquivo grande
- adicionar BLOB
- exportar BLOB
- adicionar imagem como BLOB
- reduzir memória
- consumo de memória
- apresentação grande
- arquivo temporário
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Gerencie dados BLOB em JavaScript com Aspose.Slides para Node.js para simplificar as operações de arquivos PowerPoint e OpenDocument para um manuseio eficiente de apresentações."
---
## **Visão geral**

Aspose.Slides fornece manipulação baseada em BLOB para grandes dados binários em apresentações, ajudando a reduzir o consumo de memória ao trabalhar com imagens, áudio, vídeo e arquivos de apresentação grandes.

Este artigo mostra como usar o processamento baseado em BLOB para adicionar mídia grande a uma apresentação, exportar mídia grande de uma apresentação e carregar apresentações grandes de forma mais eficiente. Também explica como arquivos temporários podem ser usados durante o processamento e como alterar a pasta usada para armazená-los.

## **Sobre o BLOB**

**BLOB** (**Binary Large Object**) geralmente é um item grande (foto, apresentação, documento ou mídia) salvo em formatos binários. 

Aspose.Slides for Node.js via Java permite usar BLOBs para objetos de maneira que reduz o consumo de memória quando arquivos grandes estão envolvidos.

{{% alert title="Info" color="info" %}}
Para contornar certas limitações ao interagir com streams, o Aspose.Slides pode copiar o conteúdo do stream. Carregar uma apresentação grande por meio de seu stream resultará na cópia do conteúdo da apresentação e provocará carregamento lento. Portanto, quando você pretende carregar uma apresentação grande, recomendamos fortemente que use o caminho do arquivo da apresentação e não seu stream.
{{% /alert %}}

## **Usar BLOB para Reduzir o Consumo de Memória**

### **Adicionar Arquivo Grande via BLOB a uma Apresentação**

[Aspose.Slides](/slides/pt/nodejs-java/) for Node.js via Java permite adicionar arquivos grandes (neste caso, um arquivo de vídeo grande) por meio de um processo que envolve BLOBs para reduzir o consumo de memória.

Este JavaScript mostra como adicionar um arquivo de vídeo grande ao processo BLOB em uma apresentação:

```javascript
var pathToVeryLargeVideo = "veryLargeVideo.avi";
// Cria uma nova apresentação à qual o vídeo será adicionado
var pres = new aspose.slides.Presentation();
try {
    var fileStream = java.newInstanceSync("java.io.FileInputStream", pathToVeryLargeVideo);
    try {
        // Vamos adicionar o vídeo à apresentação - escolhemos o comportamento KeepLocked porque
        // não pretendemos acessar o arquivo "veryLargeVideo.avi".
        var video = pres.getVideos().addVideo(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);
        // Salva a apresentação. Enquanto uma apresentação grande é gerada, o consumo de memória
        // permanece baixo ao longo do ciclo de vida do objeto pres
        pres.save("presentationWithLargeVideo.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (fileStream != null) {
            fileStream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Exportar Arquivo Grande via BLOB de uma Apresentação**

Aspose.Slides for Node.js via Java permite exportar arquivos grandes (neste caso, um arquivo de áudio ou vídeo) por meio de um processo que envolve BLOBs a partir de apresentações. Por exemplo, pode ser necessário extrair um arquivo de mídia grande de uma apresentação, mas não quer que o arquivo seja carregado na memória do seu computador. Exportando o arquivo através do processo BLOB, você mantém o consumo de memória baixo.

Este código em JavaScript demonstra a operação descrita:

```javascript
var hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
var loadOptions = new aspose.slides.LoadOptions();
// Bloqueia o arquivo fonte e NÃO o carrega na memória
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
// cria a instância da Presentation, bloqueia o arquivo "hugePresentationWithAudiosAndVideos.pptx".
var pres = new aspose.slides.Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // Vamos salvar cada vídeo em um arquivo. Para evitar alto uso de memória, precisamos de um buffer que será usado
    // para transferir os dados do stream de vídeo da apresentação para um stream de um novo arquivo de vídeo.
    var buffer = new byte[8 * 1024];
    // Percorre os vídeos
    for (var index = 0; index < pres.getVideos().size(); index++) {
        var video = pres.getVideos().get_Item(index);
        // Abre o stream de vídeo da apresentação. Por favor, note que evitamos intencionalmente acessar propriedades
        // como video.BinaryData - porque essa propriedade retorna um array de bytes contendo o vídeo completo, o que então
        // faz com que bytes sejam carregados na memória. Usamos video.GetStream, que retornará um Stream - e NÃO
        // requer que carreguemos o vídeo inteiro na memória.
        var presVideoStream = video.getStream();
        try {
            var outputFileStream = java.newInstanceSync("java.io.FileOutputStream", ("video" + index) + ".avi");
            try {
                var bytesRead;
                while ((bytesRead = presVideoStream.read(buffer, 0, buffer.length)) > 0) {
                    outputFileStream.write(buffer, 0, bytesRead);
                }
            } finally {
                outputFileStream.close();
            }
        } finally {
            presVideoStream.close();
        }
        // O consumo de memória permanecerá baixo independentemente do tamanho do vídeo ou da apresentação.
    }
    // Se necessário, você pode aplicar os mesmos passos para arquivos de áudio.
} catch (e) {console.log(e);
} finally {
    pres.dispose();
}
```

### **Adicionar Imagem como BLOB em uma Apresentação**

Com métodos da classe [**ImageCollection**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ImageCollection) e da classe [**ImageCollection** ](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ImageCollection), você pode adicionar uma imagem grande como stream para que seja tratada como BLOB.

Este código JavaScript mostra como adicionar uma imagem grande através do processo BLOB:

```javascript
var pathToLargeImage = "large_image.jpg";
// cria uma nova apresentação à qual a imagem será adicionada.
var pres = new aspose.slides.Presentation();
try {
    var fileStream = java.newInstanceSync("java.io.FileInputStream", pathToLargeImage);
    try {
        // Vamos adicionar a imagem à apresentação - escolhemos o comportamento KeepLocked porque
        // NÃO pretendemos acessar o arquivo "largeImage.png" file.
        var img = pres.getImages().addImage(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, 300, 200, img);
        // Salva a apresentação. Enquanto uma apresentação grande é gerada, o consumo de memória
        // permanece baixo ao longo do ciclo de vida do objeto pres
        pres.save("presentationWithLargeImage.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (fileStream != null) {
            fileStream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Memória e Apresentações Grandes**

Normalmente, para carregar uma apresentação grande, os computadores requerem muita memória temporária. Todo o conteúdo da apresentação é carregado na memória e o arquivo (do qual a apresentação foi carregada) deixa de ser usado. 

Considere uma apresentação PowerPoint grande (large.pptx) que contém um arquivo de vídeo de 1,5 GB. O método padrão para carregar a apresentação é descrito neste código JavaScript:

```javascript
var pres = new aspose.slides.Presentation("large.pptx");
try {
    pres.save("large.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Mas este método consome cerca de 1,6 GB de memória temporária. 

### **Carregar uma Apresentação Grande como BLOB**

Ao usar o processo que envolve um BLOB, você pode carregar uma apresentação grande usando pouca memória. Este código JavaScript descreve a implementação onde o processo BLOB é usado para carregar um arquivo de apresentação grande (large.pptx):

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
var pres = new aspose.slides.Presentation("large.pptx", loadOptions);
try {
    pres.save("large.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Alterar a Pasta para Arquivos Temporários**

Quando o processo BLOB é usado, seu computador cria arquivos temporários na pasta padrão para arquivos temporários. Se desejar que os arquivos temporários sejam mantidos em outra pasta, você pode alterar as configurações de armazenamento usando `setTempFilesRootPath`:

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="Info" color="info" %}}
Ao usar `setTempFilesRootPath`, o Aspose.Slides não cria automaticamente uma pasta para armazenar arquivos temporários. Você deve criar a pasta manualmente. 
{{% /alert %}}

### **Descartar Objetos de Apresentação para Liberar Memória**

Ao processar apresentações grandes, assegure-se de que a instância [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/) seja descartada corretamente para que a memória que ocupava seja liberada. Chame `dispose()` após terminar de usar a apresentação para liberar recursos não gerenciados.

```js
let presentation = new aspose.slides.Presentation("large.pptx");

// ...processar a apresentação...
presentation.save("large.pdf", aspose.slides.SaveFormat.Pdf);

// Liberar recursos explicitamente.
presentation.dispose();
```

## **Perguntas Frequentes**

**Quais dados em uma apresentação Aspose.Slides são tratados como BLOB e controlados pelas opções de BLOB?**

Objetos binários grandes como imagens, áudio e vídeo são tratados como BLOB. Todo o arquivo de apresentação também envolve manipulação de BLOB quando é carregado ou salvo. Esses objetos são regidos por políticas de BLOB que permitem gerenciar o uso de memória e despejar em arquivos temporários quando necessário.

**Onde configuro as regras de manipulação de BLOB durante o carregamento da apresentação?**

Use [LoadOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/loadoptions/) com [BlobManagementOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/blobmanagementoptions/). Lá você define o limite de memória para BLOB, permite ou impede arquivos temporários, escolhe o caminho raiz para arquivos temporários e seleciona o comportamento de bloqueio da fonte.

**As configurações de BLOB afetam o desempenho, e como equilibrar velocidade vs memória?**

Sim. Manter BLOB na memória maximiza a velocidade, mas aumenta o consumo de RAM; reduzir o limite de memória transfere mais trabalho para arquivos temporários, reduzindo a RAM ao custo de I/O adicional. Use o método [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/blobmanagementoptions/setmaxblobsbytesinmemory/) para alcançar o equilíbrio adequado para sua carga de trabalho e ambiente.

**As opções de BLOB ajudam ao abrir apresentações extremamente grandes (por exemplo, gigabytes)?**

Sim. [BlobManagementOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/blobmanagementoptions/) foram projetadas para esses cenários: habilitar arquivos temporários e usar bloqueio de fonte pode reduzir significativamente o uso máximo de RAM e estabilizar o processamento de decks muito grandes.

**Posso usar políticas de BLOB ao carregar de streams em vez de arquivos de disco?**

Sim. As mesmas regras se aplicam a streams: a instância de apresentação pode possuir e bloquear o stream de entrada (dependendo do modo de bloqueio escolhido), e arquivos temporários são usados quando permitidos, mantendo o uso de memória previsível durante o processamento.