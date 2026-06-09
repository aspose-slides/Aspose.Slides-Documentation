---
title: Gerenciar BLOBs de Apresentação em C++ para Uso Eficiente de Memória
linktitle: Gerenciar BLOB
type: docs
weight: 10
url: /pt/cpp/manage-blob/
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
- C++
- Aspose.Slides
description: "Gerencie dados BLOB no Aspose.Slides para C++ para simplificar operações de arquivos PowerPoint e OpenDocument para manuseio eficiente de apresentações."
---
## **Visão geral**

Aspose.Slides fornece tratamento baseado em BLOB para grandes dados binários em apresentações, ajudando a reduzir o consumo de memória ao trabalhar com imagens, áudio, vídeo e arquivos de apresentação grandes.

Este artigo mostra como usar o processamento baseado em BLOB para adicionar mídia grande a uma apresentação, exportar mídia grande de uma apresentação e carregar apresentações grandes de forma mais eficiente. Também explica como arquivos temporários podem ser usados durante o processamento e como alterar a pasta usada para armazená‑los.

## **Sobre BLOB**

**BLOB** (**Binary Large Object**) geralmente é um item grande (foto, apresentação, documento ou mídia) salvo em formatos binários.

Aspose.Slides for C++ permite que você use BLOBs para objetos de maneira que reduz o consumo de memória quando arquivos grandes estão envolvidos.

## **Usar BLOB para reduzir o consumo de memória**

### **Adicionar um arquivo grande via BLOB a uma apresentação**

[Aspose.Slides](/slides/pt/cpp/) for C++ permite que você adicione arquivos grandes (neste caso, um arquivo de vídeo grande) por meio de um processo que envolve BLOBs para reduzir o consumo de memória.

Este código C++ mostra como adicionar um arquivo de vídeo grande através do processo BLOB a uma apresentação:

```cpp
const String pathToVeryLargeVideo = u"veryLargeVideo.avi";

// Cria uma nova apresentação à qual o vídeo será adicionado
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToVeryLargeVideo, FileMode::Open);
// Vamos adicionar o vídeo à apresentação - escolhemos o comportamento KeepLocked porque nós
// não pretendemos acessar o arquivo "veryLargeVideo.avi".
auto video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddVideoFrame(0.0f, 0.0f, 480.0f, 270.0f, video);

// Salva a apresentação. Enquanto uma apresentação grande é gerada,
// o consumo de memória permanece baixo ao longo do ciclo de vida do objeto pres
pres->Save(u"presentationWithLargeVideo.pptx", SaveFormat::Pptx);
```

### **Exportar um arquivo grande via BLOB de uma apresentação**
Aspose.Slides for C++ permite que você exporte arquivos grandes (neste caso, um arquivo de áudio ou vídeo) por meio de um processo que envolve BLOBs de apresentações. Por exemplo, pode ser necessário extrair um arquivo de mídia grande de uma apresentação, mas não deseja que o arquivo seja carregado na memória do computador. Exportando o arquivo através do processo BLOB, mantém‑se o consumo de memória baixo.

Este código em C++ demonstra a operação descrita:

```cpp
const String hugePresentationWithAudiosAndVideosFile = u"Large  Video File Test1.pptx";

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);

// Cria uma instância de Presentation, bloqueia o arquivo "hugePresentationWithAudiosAndVideos.pptx".

auto pres = System::MakeObject<Presentation>(hugePresentationWithAudiosAndVideosFile, loadOptions);
// Vamos salvar cada vídeo em um arquivo. Para evitar alto uso de memória, precisamos de um buffer que será usado
// para transferir os dados do fluxo de vídeo da apresentação para um fluxo de um novo arquivo de vídeo criado.
auto buffer = System::MakeArray<uint8_t>(8 * 1024, 0);

// Iterates through the videos
for (int32_t index = 0; index < pres->get_Videos()->get_Count(); ++index)
{
	auto video = pres->get_Videos()->idx_get(index);

	// Abre o fluxo de vídeo da apresentação. Por favor, note que evitamos intencionalmente acessar métodos
	// como video->get_BinaryData - porque este método retorna um array de bytes contendo o vídeo completo, o que então
	// faz com que os bytes sejam carregados na memória. Usamos video->GetStream, que retornará Stream - e NÃO
	// requer que carreguemos todo o vídeo na memória.
	
	auto presVideoStream = video->GetStream();

	auto outputFileStream = File::OpenWrite(String::Format(u"video{0}.avi", index));
	int32_t bytesRead;
	while ((bytesRead = presVideoStream->Read(buffer, 0, buffer->get_Length())) > 0)
	{
		outputFileStream->Write(buffer, 0, bytesRead);
	}
		
	// O consumo de memória permanecerá baixo independentemente do tamanho do vídeo ou da apresentação,
}

// Se necessário, você pode aplicar os mesmos passos para arquivos de áudio.
```

### **Adicionar uma imagem como BLOB a uma apresentação**
Com os métodos da interface [**IImageCollection**](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_image_collection) e da classe [**ImageCollection**](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.image_collection), você pode adicionar uma imagem grande como fluxo para que ela seja tratada como BLOB.

Este código C++ mostra como adicionar uma imagem grande através do processo BLOB:

```cpp
const String pathToLargeImage = u"large_image.jpg";

// cria uma nova apresentação à qual a imagem será adicionada.
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToLargeImage, FileMode::Open);
// Vamos adicionar a imagem à apresentação - escolhemos o comportamento KeepLocked porque nós
// NÃO pretendemos acessar o arquivo "largeImage.png".
auto img = pres->get_Images()->AddImage(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, 300.0f, 200.0f, img);

// Salva a apresentação. Enquanto uma apresentação grande é gerada, o consumo de memória
// permanece baixo ao longo do ciclo de vida do objeto pres
pres->Save(u"presentationWithLargeImage.pptx", SaveFormat::Pptx);
```

## **Memória e apresentações grandes**

Normalmente, para carregar uma apresentação grande, os computadores exigem muita memória temporária. Todo o conteúdo da apresentação é carregado na memória e o arquivo (do qual a apresentação foi carregada) deixa de ser usado.

Considere uma apresentação PowerPoint grande (large.pptx) que contém um arquivo de vídeo de 1,5 GB. O método padrão para carregar a apresentação está descrito neste código C++:

```cpp
auto pres = System::MakeObject<Presentation>(u"large.pptx");
pres->Save(u"large.pdf", SaveFormat::Pdf);
```

Mas esse método consome cerca de 1,6 GB de memória temporária.

### **Carregar uma apresentação grande como BLOB**

Através do processo que envolve um BLOB, você pode carregar uma apresentação grande usando pouca memória. Este código C++ descreve a implementação onde o processo BLOB é usado para carregar um arquivo de apresentação grande (large.pptx):

```cpp
auto blobManagementOptions = System::MakeObject<BlobManagementOptions>();
blobManagementOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobManagementOptions->set_IsTemporaryFilesAllowed(true);

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_BlobManagementOptions(blobManagementOptions);

auto pres = System::MakeObject<Presentation>(u"large.pptx", loadOptions);
pres->Save(u"large.pdf", SaveFormat::Pdf);
```

#### **Alterar a pasta para arquivos temporários**

Quando o processo BLOB é usado, o computador cria arquivos temporários na pasta padrão para arquivos temporários. Se quiser que os arquivos temporários sejam mantidos em outra pasta, você pode alterar as configurações de armazenamento usando `TempFilesRootPath`:

```cpp
auto blobManagementOptions = System::MakeObject<BlobManagementOptions>();
blobManagementOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobManagementOptions->set_IsTemporaryFilesAllowed(true);
blobManagementOptions->set_TempFilesRootPath(u"temp");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_BlobManagementOptions(blobManagementOptions);
```

{{% alert title="Info" color="info" %}}
Ao usar `TempFilesRootPath`, o Aspose.Slides não cria automaticamente uma pasta para armazenar arquivos temporários. Você deve criar a pasta manualmente. 
{{% /alert %}}

### **Liberar objetos de apresentação para liberar memória**

Ao processar apresentações grandes, assegure‑se de que a instância de [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) seja descartada corretamente para que a memória ocupada seja liberada. Chame `Dispose()` depois de terminar de usar a apresentação para liberar recursos não gerenciados.

```cpp
auto presentation = System::MakeObject<Presentation>(u"large.pptx");

// ...processar a apresentação...
presentation->Save(u"large.pdf", SaveFormat::Pdf);

// Liberar recursos explicitamente.
presentation->Dispose();
```

## **FAQ**

**Quais dados em uma apresentação Aspose.Slides são tratados como BLOB e controlados por opções de BLOB?**

Objetos binários grandes, como imagens, áudio e vídeo, são tratados como BLOB. O próprio arquivo de apresentação também envolve o tratamento BLOB quando é carregado ou salvo. Esses objetos são regidos por políticas de BLOB que permitem gerenciar o uso de memória e a transferência para arquivos temporários quando necessário.

**Onde configuro as regras de tratamento BLOB durante o carregamento da apresentação?**

Use [LoadOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides/loadoptions/) com [BlobManagementOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides/blobmanagementoptions/). Neles você define o limite em memória para BLOB, permite ou impede arquivos temporários, escolhe o caminho raiz para arquivos temporários e seleciona o comportamento de bloqueio da origem.

**As configurações de BLOB afetam o desempenho e como equilibrar velocidade vs. memória?**

Sim. Manter BLOBs na memória maximiza a velocidade, mas aumenta o consumo de RAM; reduzir o limite de memória transfere mais trabalho para arquivos temporários, diminuindo a RAM ao custo de I/O adicional. Use o método [set_MaxBlobsBytesInMemory](https://reference.aspose.com/slides/pt/cpp/aspose.slides/blobmanagementoptions/set_maxblobsbytesinmemory/) para encontrar o equilíbrio adequado ao seu workload e ambiente.

**As opções de BLOB ajudam ao abrir apresentações extremamente grandes (por exemplo, gigabytes)?**

Sim. [BlobManagementOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides/blobmanagementoptions/) foram projetadas para esses cenários: habilitar arquivos temporários e usar bloqueio da origem pode reduzir significativamente o pico de uso de RAM e estabilizar o processamento de decks muito grandes.

**Posso usar políticas de BLOB ao carregar a partir de streams em vez de arquivos de disco?**

Sim. As mesmas regras se aplicam a streams: a instância de apresentação pode ser proprietária e bloquear o stream de entrada (dependendo do modo de bloqueio escolhido), e arquivos temporários são usados quando permitidos, mantendo o uso de memória previsível durante o processamento.