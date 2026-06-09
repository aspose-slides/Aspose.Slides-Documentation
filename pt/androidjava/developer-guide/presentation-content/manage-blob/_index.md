---
title: Gerenciar BLOBs de Apresentação no Android para Uso Eficiente de Memória
linktitle: Gerenciar BLOB
type: docs
weight: 10
url: /pt/androidjava/manage-blob/
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
- Android
- Java
- Aspose.Slides
description: "Gerencie dados BLOB no Aspose.Slides para Android via Java para simplificar as operações de arquivos PowerPoint e OpenDocument e otimizar o manuseio de apresentações."
---
## **Visão geral**

Aspose.Slides oferece manipulação baseada em BLOB para grandes dados binários em apresentações, ajudando a reduzir o consumo de memória ao trabalhar com imagens, áudio, vídeo e arquivos de apresentação de grande tamanho.

Este artigo mostra como usar o processamento baseado em BLOB para adicionar mídia grande a uma apresentação, exportar mídia grande de uma apresentação e carregar apresentações grandes de forma mais eficiente. Também explica como arquivos temporários podem ser usados durante o processamento e como alterar a pasta usada para armazená‑los.

## **Sobre BLOB**

**BLOB** (**Binary Large Object**) é normalmente um item grande (foto, apresentação, documento ou mídia) salvo em formatos binários.

Aspose.Slides for Android via Java permite que você use BLOBs para objetos de forma a reduzir o consumo de memória quando arquivos grandes estão envolvidos.

{{% alert title="Info" color="info" %}}
Para contornar certas limitações ao interagir com streams, Aspose.Slides pode copiar o conteúdo do stream. Carregar uma grande apresentação por meio de seu stream resultará na cópia do conteúdo da apresentação e causará carregamento lento. Portanto, quando pretende carregar uma grande apresentação, recomendamos fortemente que use o caminho do arquivo da apresentação e não seu stream.
{{% /alert %}}

## **Usar BLOB para reduzir o consumo de memória**

### **Adicionar um arquivo grande via BLOB a uma apresentação**

[Aspose.Slides](/slides/pt/androidjava/) para Java permite que você adicione arquivos grandes (neste caso, um arquivo de vídeo grande) por meio de um processo que envolve BLOBs para reduzir o consumo de memória.

Este exemplo em Java mostra como adicionar um grande arquivo de vídeo pelo processo BLOB a uma apresentação:

```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// Cria uma nova apresentação à qual o vídeo será adicionado
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // Vamos adicionar o vídeo à apresentação - escolhemos o comportamento KeepLocked porque
        //não pretendemos acessar o arquivo "veryLargeVideo.avi".
        IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);

        // Salva a apresentação. Enquanto uma apresentação grande é gerada, o consumo de memória
        //permanece baixo ao longo do ciclo de vida do objeto pres 
        pres.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    } finally {
        if (fileStream != null) fileStream.close();
    }
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

### **Exportar um arquivo grande via BLOB de uma apresentação**

Aspose.Slides for Android via Java permite que você exporte arquivos grandes (neste caso, um arquivo de áudio ou vídeo) por meio de um processo que envolve BLOBs a partir de apresentações. Por exemplo, pode ser necessário extrair um grande arquivo de mídia de uma apresentação, mas sem carregá‑lo na memória do computador. Exportando o arquivo pelo processo BLOB, você mantém o consumo de memória baixo.

Este código em Java demonstra a operação descrita:

```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// Bloqueia o arquivo de origem e NÃO o carrega na memória
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// cria a instância da Presentation, bloqueia o arquivo "hugePresentationWithAudiosAndVideos.pptx".
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // Vamos salvar cada vídeo em um arquivo. Para evitar alto uso de memória, precisamos de um buffer que será usado
    // para transferir os dados do stream de vídeo da apresentação para um stream de um novo arquivo de vídeo criado.
    byte[] buffer = new byte[8 * 1024];

    // Itera pelos vídeos
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // Abre o stream de vídeo da apresentação. Observe que evitamos intencionalmente acessar propriedades
        // como video.BinaryData - porque essa propriedade retorna um array de bytes contendo um vídeo completo, o que então
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

### **Adicionar uma imagem como BLOB em uma apresentação**

Com os métodos da interface [**IImageCollection**](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IImageCollection) e da classe [**ImageCollection**](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ImageCollection), você pode adicionar uma imagem grande como stream para que ela seja tratada como BLOB.

Este código Java mostra como adicionar uma imagem grande pelo processo BLOB:

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

## **Memória e apresentações grandes**

Normalmente, para carregar uma apresentação grande, os computadores precisam de muita memória temporária. Todo o conteúdo da apresentação é carregado na memória e o arquivo (do qual a apresentação foi carregada) deixa de ser usado.

Considere uma grande apresentação PowerPoint (large.pptx) que contém um arquivo de vídeo de 1,5 GB. O método padrão para carregar a apresentação é descrito neste código Java:

```java
Presentation pres = new Presentation("large.pptx");
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

Mas esse método consome cerca de 1,6 GB de memória temporária.

### **Carregar uma apresentação grande como BLOB**

Por meio do processo que envolve um BLOB, você pode carregar uma apresentação grande usando pouca memória. Este código Java descreve a implementação onde o processo BLOB é usado para carregar um arquivo de apresentação grande (large.pptx):

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

### **Alterar a pasta para arquivos temporários**

Quando o processo BLOB é usado, o computador cria arquivos temporários na pasta padrão de arquivos temporários. Se desejar que os arquivos temporários sejam mantidos em outra pasta, pode alterar as configurações de armazenamento usando `TempFilesRootPath`:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="Info" color="info" %}}
Ao usar `TempFilesRootPath`, Aspose.Slides não cria automaticamente uma pasta para armazenar arquivos temporários. Você deve criar a pasta manualmente.
{{% /alert %}}

### **Descartar objetos Presentation para liberar memória**

Ao processar apresentações grandes, certifique‑se de que a instância de [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/) seja descartada corretamente para que a memória ocupada seja liberada. Chame `dispose()` após terminar de usar a apresentação para liberar recursos não gerenciados.

```java
Presentation presentation = new Presentation("large.pptx");

// ...processar a apresentação...
presentation.save("large.pdf", SaveFormat.Pdf);

// Libere recursos explicitamente.
presentation.dispose();
```

## **FAQ**

**Quais dados em uma apresentação Aspose.Slides são tratados como BLOB e controlados pelas opções de BLOB?**

Objetos binários grandes, como imagens, áudio e vídeo, são tratados como BLOB. O próprio arquivo de apresentação também envolve manipulação de BLOB quando é carregado ou salvo. Esses objetos são regidos por políticas de BLOB que permitem gerenciar o uso de memória e transferir para arquivos temporários quando necessário.

**Onde configuro as regras de manipulação de BLOB durante o carregamento da apresentação?**

Use [LoadOptions](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/loadoptions/) com [BlobManagementOptions](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/blobmanagementoptions/). Lá você define o limite em memória para BLOB, permite ou bloqueia arquivos temporários, escolhe o caminho raiz para arquivos temporários e seleciona o comportamento de bloqueio da origem.

**As configurações de BLOB afetam o desempenho e como equilibrar velocidade vs memória?**

Sim. Manter BLOB na memória maximiza a velocidade, mas aumenta o consumo de RAM; reduzir o limite de memória transfere mais trabalho para arquivos temporários, diminuindo a RAM ao custo de I/O adicional. Use o método [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory-long-) para alcançar o equilíbrio adequado para sua carga de trabalho e ambiente.

**As opções de BLOB ajudam ao abrir apresentações extremamente grandes (por exemplo, gigabytes)?**

Sim. [BlobManagementOptions](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/blobmanagementoptions/) foram projetadas para esses cenários: habilitar arquivos temporários e usar bloqueio de origem pode reduzir significativamente o pico de uso de RAM e estabilizar o processamento de decks muito grandes.

**Posso usar políticas de BLOB ao carregar a partir de streams em vez de arquivos de disco?**

Sim. As mesmas regras se aplicam a streams: a instância da apresentação pode possuir e bloquear o stream de entrada (dependendo do modo de bloqueio escolhido), e arquivos temporários são usados quando permitidos, mantendo o uso de memória previsível durante o processamento.