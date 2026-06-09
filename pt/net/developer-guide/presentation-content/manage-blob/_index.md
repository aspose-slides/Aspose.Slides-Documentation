---
title: Gerenciar BLOBs de Apresentação em .NET para Uso Eficiente de Memória
linktitle: Gerenciar BLOB
type: docs
weight: 10
url: /pt/net/manage-blob/
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
- .NET
- C#
- Aspose.Slides
description: "Gerenciar dados BLOB no Aspose.Slides para .NET para simplificar as operações de arquivos PowerPoint e OpenDocument, proporcionando um manuseio eficiente de apresentações."
---
## **Visão geral**

Aspose.Slides oferece manipulação baseada em BLOB para grandes dados binários em apresentações, ajudando a reduzir o consumo de memória ao trabalhar com imagens, áudio, vídeo e arquivos de apresentação de grande tamanho.

Este artigo mostra como usar o processamento baseado em BLOB para adicionar mídia grande a uma apresentação, exportar mídia grande de uma apresentação e carregar apresentações volumosas de forma mais eficiente. Também explica como arquivos temporários podem ser usados durante o processamento e como alterar a pasta usada para armazená‑los.

## **Sobre BLOB**

**BLOB** (**Binary Large Object**) geralmente é um item grande (foto, apresentação, documento ou mídia) salvo em formatos binários.

Aspose.Slides for .NET permite usar BLOBs para objetos de modo que o consumo de memória seja reduzido quando arquivos grandes estão envolvidos.

## **Usar BLOB para reduzir o consumo de memória**

### **Adicionar um arquivo grande via BLOB a uma apresentação**

[Aspose.Slides](/slides/pt/net/) for .NET permite adicionar arquivos grandes (neste caso, um grande arquivo de vídeo) por meio de um processo que envolve BLOBs para reduzir o consumo de memória.

Este C# mostra como adicionar um grande arquivo de vídeo ao processo BLOB em uma apresentação:

```c#
const string pathToVeryLargeVideo = "veryLargeVideo.avi";

// Cria uma nova apresentação à qual o vídeo será adicionado
using (Presentation pres = new Presentation())
{
    using (FileStream fileStream = new FileStream(pathToVeryLargeVideo, FileMode.Open))
    {
        // Vamos adicionar o vídeo à apresentação - escolhemos o comportamento KeepLocked porque nós
        // não pretendemos acessar o arquivo "veryLargeVideo.avi".
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.Slides[0].Shapes.AddVideoFrame(0, 0, 480, 270, video);

        // Salva a apresentação. Enquanto uma apresentação grande é gerada, o consumo de memória
        // permanece baixo durante o ciclo de vida do objeto pres
        pres.Save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    }
}
```

### **Exportar um arquivo grande via BLOB de uma apresentação**
Aspose.Slides for .NET permite exportar arquivos grandes (neste caso, um arquivo de áudio ou vídeo) por meio de um processo que envolve BLOBs a partir de apresentações. Por exemplo, você pode precisar extrair um grande arquivo de mídia de uma apresentação, mas não quer que o arquivo seja carregado na memória do seu computador. Exportando o arquivo pelo processo BLOB, você mantém o consumo de memória baixo.

Este código em C# demonstra a operação descrita:

```c#
const string hugePresentationWithAudiosAndVideosFile = @"Large  Video File Test1.pptx";

LoadOptions loadOptions = new LoadOptions
{
	BlobManagementOptions = {
		// Bloqueia o arquivo fonte e NÃO o carrega na memória
		PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
	}
};

// Cria uma instância de Presentation, bloqueia o arquivo "hugePresentationWithAudiosAndVideos.pptx".
using (Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions))
{
	// Vamos salvar cada vídeo em um arquivo. Para evitar alto consumo de memória, precisamos de um buffer que será usado
	// para transferir os dados do fluxo de vídeo da apresentação para um fluxo de um novo arquivo de vídeo.
	byte[] buffer = new byte[8 * 1024];

	// Iterates through the videos
	for (var index = 0; index < pres.Videos.Count; index++)
	{
		IVideo video = pres.Videos[index];

		// Abre o fluxo de vídeo da apresentação. Por favor, note que evitamos intencionalmente acessar propriedades
		// como video.BinaryData - porque essa propriedade retorna um array de bytes contendo o vídeo completo, o que então
		// faz com que bytes sejam carregados na memória. Usamos video.GetStream, que retornará um Stream - e NÃO
		//  requer que carreguemos todo o vídeo na memória.
		using (Stream presVideoStream = video.GetStream())
		{
			using (FileStream outputFileStream = File.OpenWrite($"video{index}.avi"))
			{
				int bytesRead;
				while ((bytesRead = presVideoStream.Read(buffer, 0, buffer.Length)) > 0)
				{
					outputFileStream.Write(buffer, 0, bytesRead);
				}
			}
		}

		// O consumo de memória permanecerá baixo independentemente do tamanho do vídeo ou da apresentação,
	}

	// Se necessário, você pode aplicar os mesmos passos para arquivos de áudio. 
}
```

### **Adicionar uma imagem como BLOB a uma apresentação**
Com os métodos da interface [**IImageCollection**](https://reference.aspose.com/slides/pt/net/aspose.slides/iimagecollection) e da classe [**ImageCollection**](https://reference.aspose.com/slides/pt/net/aspose.slides/imagecollection), você pode adicionar uma imagem grande como fluxo para que ela seja tratada como BLOB.

Este código C# mostra como adicionar uma imagem grande através do processo BLOB:

```c#
string pathToLargeImage = "large_image.jpg";

// cria uma nova apresentação à qual a imagem será adicionada.
using (Presentation pres = new Presentation())
{
	using (FileStream fileStream = new FileStream(pathToLargeImage, FileMode.Open))
	{
		// Vamos adicionar a imagem à apresentação - escolhemos o comportamento KeepLocked porque nós
		// NÃO pretendemos acessar o arquivo "largeImage.png" file.
		IPPImage img = pres.Images.AddImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// Salva a apresentação. Enquanto uma apresentação grande é gerada, o consumo de memória 
		// permanece baixo durante o ciclo de vida do objeto pres
		pres.Save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	}
}
```

## **Memória e apresentações grandes**

Normalmente, para carregar uma apresentação grande, os computadores requerem muita memória temporária. Todo o conteúdo da apresentação é carregado na memória e o arquivo (de onde a apresentação foi carregada) deixa de ser usado.

Considere uma grande apresentação PowerPoint (large.pptx) que contém um arquivo de vídeo de 1,5 GB. O método padrão para carregar a apresentação é descrito neste código C#:

```c#
using (Presentation pres = new Presentation("large.pptx"))
{
   pres.Save("large.pdf", SaveFormat.Pdf);
}
```

Mas esse método consome cerca de 1,6 GB de memória temporária.

### **Carregar uma apresentação grande como BLOB**

Através do processo que envolve um BLOB, você pode carregar uma apresentação grande usando pouca memória. Este código C# descreve a implementação onde o processo BLOB é usado para carregar um grande arquivo de apresentação (large.pptx):

```c#
LoadOptions loadOptions = new LoadOptions
{
   BlobManagementOptions = new BlobManagementOptions
   {
       PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
       IsTemporaryFilesAllowed = true
   }
};
 
using (Presentation pres = new Presentation("large.pptx", loadOptions))
{
   pres.Save("large.pdf", SaveFormat.Pdf);
}
```

### **Alterar a pasta para arquivos temporários**

Quando o processo BLOB é usado, o computador cria arquivos temporários na pasta padrão para arquivos temporários. Se você quiser que os arquivos temporários sejam mantidos em outra pasta, pode alterar as configurações de armazenamento usando `TempFilesRootPath`:

```c#
LoadOptions loadOptions = new LoadOptions
{
   BlobManagementOptions = new BlobManagementOptions
   {
       PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
       IsTemporaryFilesAllowed = true,
       TempFilesRootPath = "temp"
   }
};
```

{{% alert title="Info" color="info" %}}
Ao usar `TempFilesRootPath`, o Aspose.Slides não cria automaticamente uma pasta para armazenar arquivos temporários. Você deve criar a pasta manualmente. 
{{% /alert %}}

### **Descartar objetos Presentation para liberar memória**

Ao processar apresentações grandes, certifique‑se de que a instância [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/) seja descartada corretamente, de modo que a memória ocupada seja liberada. A forma recomendada é usar uma instrução `using` ou declaração, como mostrado nos exemplos acima; ela descarta automaticamente a apresentação e libera recursos não gerenciados quando o bloco é finalizado.

Se você criar uma apresentação sem um bloco `using`, chame explicitamente `Dispose()` após terminar de usá‑la.

```cs
Presentation presentation = new Presentation("large.pptx");

// ...processar a apresentação...
presentation.Save("large.pdf", SaveFormat.Pdf);

// Liberar recursos explicitamente.
presentation.Dispose();
```

## **FAQ**

**Quais dados em uma apresentação Aspose.Slides são tratados como BLOB e controlados pelas opções de BLOB?**

Objetos binários grandes, como imagens, áudio e vídeo, são tratados como BLOB. O arquivo inteiro da apresentação também envolve manipulação de BLOB quando é carregado ou salvo. Esses objetos são regidos por políticas de BLOB que permitem gerenciar o uso de memória e o transbordamento para arquivos temporários quando necessário.

**Onde configuro as regras de manipulação de BLOB durante o carregamento da apresentação?**

Use [LoadOptions](https://reference.aspose.com/slides/pt/net/aspose.slides/loadoptions/) com [BlobManagementOptions](https://reference.aspose.com/slides/pt/net/aspose.slides/blobmanagementoptions/). Lá você define o limite em memória para BLOB, permite ou impede arquivos temporários, escolhe o caminho raiz para arquivos temporários e seleciona o comportamento de bloqueio da origem.

**As configurações de BLOB afetam o desempenho e como equilibrar velocidade vs. memória?**

Sim. Manter BLOBs na memória maximiza a velocidade, mas aumenta o consumo de RAM; reduzir o limite de memória desloca mais trabalho para arquivos temporários, diminuindo a RAM ao custo de I/O adicional. Ajuste o limite [MaxBlobsBytesInMemory](https://reference.aspose.com/slides/pt/net/aspose.slides/blobmanagementoptions/maxblobsbytesinmemory/) para encontrar o equilíbrio adequado ao seu cenário e ambiente.

**As opções de BLOB ajudam ao abrir apresentações extremamente grandes (por exemplo, gigabytes)?**

Sim. [BlobManagementOptions](https://reference.aspose.com/slides/pt/net/aspose.slides/blobmanagementoptions/) foram criadas para esses cenários: habilitar arquivos temporários e usar bloqueio de origem pode reduzir significativamente o pico de uso de RAM e estabilizar o processamento de decks muito grandes.

**Posso usar políticas de BLOB ao carregar a partir de streams em vez de arquivos de disco?**

Sim. As mesmas regras se aplicam a streams: a instância da apresentação pode possuir e bloquear o stream de entrada (dependendo do modo de bloqueio escolhido), e arquivos temporários são usados quando permitidos, mantendo o uso de memória previsível durante o processamento.