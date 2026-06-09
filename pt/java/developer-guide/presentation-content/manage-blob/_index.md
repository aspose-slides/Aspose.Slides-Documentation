---
title: Gerenciar BLOBs de Apresentação em Java para Uso Eficiente de Memória
linktitle: Gerenciar BLOB
type: docs
weight: 10
url: /pt/java/manage-blob/
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
- Java
- Aspose.Slides
description: "Gerencie dados BLOB no Aspose.Slides for Java para simplificar as operações de arquivos PowerPoint e OpenDocument, proporcionando um manuseio eficiente de apresentações."
---
## **Visão geral**

Aspose.Slides fornece tratamento baseado em BLOB para grandes dados binários em apresentações, ajudando a reduzir o consumo de memória ao trabalhar com imagens, áudio, vídeo e arquivos de apresentação de grande tamanho.

Este artigo mostra como usar o processamento baseado em BLOB para adicionar mídia grande a uma apresentação, exportar mídia grande de uma apresentação e carregar apresentações grandes de forma mais eficiente. Também explica como arquivos temporários podem ser usados durante o processamento e como alterar a pasta utilizada para armazená‑los.

## **Sobre BLOB**

**BLOB** (**Binary Large Object**) é normalmente um item grande (foto, apresentação, documento ou mídia) salvo em formatos binários.

Aspose.Slides for Java permite usar BLOBs para objetos de modo que reduza o consumo de memória quando arquivos grandes estão envolvidos.

{{% alert title="Info" color="info" %}}
Para contornar certas limitações ao interagir com fluxos, Aspose.Slides pode copiar o conteúdo do fluxo. Carregar uma apresentação grande através de seu fluxo resultará na cópia do conteúdo da apresentação e causará carregamento lento. Portanto, quando você pretende carregar uma apresentação grande, recomendamos fortemente que use o caminho do arquivo da apresentação e não seu fluxo.
{{% /alert %}}

## **Usar BLOB para Reduzir o Consumo de Memória**

### **Adicionar um Arquivo Grande via BLOB a uma Apresentação**

[Aspose.Slides](/slides/pt/java/) for Java permite adicionar arquivos grandes (neste caso, um arquivo de vídeo grande) por meio de um processo que envolve BLOBs para reduzir o consumo de memória.

Este exemplo em Java mostra como adicionar um arquivo de vídeo grande ao processo BLOB em uma apresentação:

```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// Cria uma nova apresentação à qual o vídeo será adicionado
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // Vamos adicionar o vídeo à apresentação - escolhemos o comportamento KeepLocked porque nós
        // não pretendemos acessar o arquivo "veryLargeVideo.avi".
        IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);

        // Salva a apresentação. Enquanto uma apresentação grande é gerada, o consumo de memória
        // permanece baixo ao longo do ciclo de vida do objeto pres 
        pres.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    } finally {
        if (fileStream != null) fileStream.close();
    }
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

### **Exportar um Arquivo Grande via BLOB de uma Apresentação**
Aspose.Slides for Java permite exportar arquivos grandes (por exemplo, um arquivo de áudio ou vídeo) por meio de um processo que envolve BLOBs de apresentações. Por exemplo, pode ser necessário extrair um arquivo de mídia grande de uma apresentação, mas não deseja que o arquivo seja carregado na memória do computador. Exportando o arquivo pelo processo BLOB, você mantém o consumo de memória baixo.

Este código em Java demonstra a operação descrita:

```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// Bloqueia o arquivo de origem e NÃO o carrega na memória
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// cria a instância da Presentation, bloqueia o arquivo "hugePresentationWithAudiosAndVideos.pptx" file.
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // Vamos salvar cada vídeo em um arquivo. Para evitar alto uso de memória, precisamos de um buffer que será usado
    // para transferir os dados do fluxo de vídeo da apresentação para um fluxo de um novo arquivo de vídeo.
    byte[] buffer = new byte[8 * 1024];

    // Percorre os vídeos
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // Abre o fluxo de vídeo da apresentação. Observe que evitamos intencionalmente acessar propriedades
        // como video.BinaryData - porque esta propriedade devolve um array de bytes contendo o vídeo completo, que então
        // faz com que os bytes sejam carregados na memória. Usamos video.GetStream, que retornará um Stream - e NÃO
        //  requer que carreguemos o vídeo inteiro na memória.
        InputStream presVideoStream = video.getStream();
        try {
            OutputStream outputFileStream = new FileOutputStream("video" + index + ".avi");
            try {
                int bytesRead;
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
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

### **Adicionar uma Imagem como BLOB a uma Apresentação**
Com os métodos da interface [**IImageCollection**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IImageCollection) e da classe [**ImageCollection**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ImageCollection), você pode adicionar uma imagem grande como fluxo para que seja tratada como BLOB.

Este código Java mostra como adicionar uma imagem grande através do processo BLOB:

```java
String pathToLargeImage = "large_image.jpg";

// cria uma nova apresentação à qual a imagem será adicionada.
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// Vamos adicionar a imagem à apresentação - escolhemos o comportamento KeepLocked porque nós
		// NÃO pretendemos acessar o arquivo "largeImage.png" file.
		IPPImage img = pres.getImages().addImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// Salva a apresentação. Enquanto uma apresentação grande é gerada, o consumo de memória
		// permanece baixo ao longo do ciclo de vida do objeto pres
		pres.save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	} finally {
		if (fileStream != null) fileStream.close();
	}
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

## **Memória e Apresentações Grandes**

Normalmente, para carregar uma apresentação grande, os computadores exigem muita memória temporária. Todo o conteúdo da apresentação é carregado na memória e o arquivo (de onde a apresentação foi carregada) deixa de ser usado.

Considere uma apresentação PowerPoint grande (large.pptx) que contém um arquivo de vídeo de 1,5 GB. O método padrão para carregar a apresentação é descrito neste código Java:

```java
Presentation pres = new Presentation("large.pptx");
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

Mas esse método consome cerca de 1,6 GB de memória temporária.

### **Carregar uma Apresentação Grande como BLOB**

Através do processo que envolve um BLOB, você pode carregar uma apresentação grande usando pouca memória. Este código Java descreve a implementação onde o processo BLOB é usado para carregar um arquivo de apresentação grande (large.pptx):

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);

Presentation pres = new Presentation("large.pptx", loadOptions);
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Alterar a Pasta para Arquivos Temporários**

Quando o processo BLOB é usado, o computador cria arquivos temporários na pasta padrão para arquivos temporários. Se desejar que os arquivos temporários sejam mantidos em outra pasta, você pode alterar as configurações de armazenamento usando `TempFilesRootPath`:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="Info" color="info" %}}
Ao usar `TempFilesRootPath`, Aspose.Slides não cria automaticamente uma pasta para armazenar arquivos temporários. Você deve criar a pasta manualmente.
{{% /alert %}}

### **Descartar Objetos de Apresentação para Liberar Memória**

Ao processar apresentações grandes, certifique‑se de que a instância [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/) seja descartada adequadamente para que a memória que ocupava seja liberada. Chame `dispose()` após terminar de usar a apresentação para liberar recursos não gerenciados.

```java
Presentation presentation = new Presentation("large.pptx");

// ...processar a apresentação...
presentation.save("large.pdf", SaveFormat.Pdf);

// Liberar recursos explicitamente.
presentation.dispose();
```

## **FAQ**

**Quais dados em uma apresentação Aspose.Slides são tratados como BLOB e controlados por opções de BLOB?**

Objetos binários grandes, como imagens, áudio e vídeo, são tratados como BLOB. O próprio arquivo da apresentação também envolve tratamento BLOB quando é carregado ou salvo. Esses objetos são regidos por políticas de BLOB que permitem gerenciar o uso de memória e a transferência para arquivos temporários quando necessário.

**Onde configuro as regras de tratamento BLOB durante o carregamento da apresentação?**

Use [LoadOptions](https://reference.aspose.com/slides/pt/java/com.aspose.slides/loadoptions/) com [BlobManagementOptions](https://reference.aspose.com/slides/pt/java/com.aspose.slides/blobmanagementoptions/). Lá você define o limite de memória para BLOB, permite ou impede arquivos temporários, escolhe o caminho raiz para arquivos temporários e seleciona o comportamento de bloqueio da origem.

**As configurações de BLOB afetam o desempenho e como equilibrar velocidade versus memória?**

Sim. Manter BLOBs na memória maximiza a velocidade, mas aumenta o consumo de RAM; reduzir o limite de memória desloca mais trabalho para arquivos temporários, reduzindo a RAM ao custo de I/O adicional. Use o método [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/pt/java/com.aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory-long-) para encontrar o equilíbrio adequado ao seu workload e ambiente.

**As opções de BLOB ajudam ao abrir apresentações extremamente grandes (por exemplo, vários gigabytes)?**

Sim. [BlobManagementOptions](https://reference.aspose.com/slides/pt/java/com.aspose.slides/blobmanagementoptions/) foram projetadas para esses cenários: habilitar arquivos temporários e usar bloqueio da origem pode reduzir significativamente o pico de uso de RAM e estabilizar o processamento de decks muito grandes.

**Posso usar políticas de BLOB ao carregar a partir de fluxos em vez de arquivos de disco?**

Sim. As mesmas regras se aplicam a fluxos: a instância da apresentação pode possuir e bloquear o fluxo de entrada (dependendo do modo de bloqueio escolhido), e arquivos temporários são usados quando permitidos, mantendo o uso de memória previsível durante o processamento.