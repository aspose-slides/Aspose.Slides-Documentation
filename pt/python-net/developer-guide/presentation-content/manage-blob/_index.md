---
title: Gerenciar BLOBs em Apresentações com Python para Uso Eficiente de Memória
linktitle: Gerenciar BLOB
type: docs
weight: 10
url: /pt/python-net/manage-blob/
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
- Python
- Aspose.Slides
description: "Gerencie dados BLOB no Aspose.Slides para Python via .NET para simplificar operações de arquivos PowerPoint e OpenDocument para manuseio eficiente de apresentações."
---
## **Visão geral**

Aspose.Slides oferece manipulação baseada em BLOB para grandes dados binários em apresentações, ajudando a reduzir o consumo de memória ao trabalhar com imagens, áudio, vídeo e arquivos de apresentação de grande tamanho.

Este artigo mostra como usar o processamento baseado em BLOB para adicionar mídia grande a uma apresentação, exportar mídia grande de uma apresentação e carregar apresentações grandes de forma mais eficiente. Também explica como arquivos temporários podem ser usados durante o processamento e como alterar a pasta usada para armazená‑los.

## **Sobre BLOB**

**BLOB** (**Binary Large Object**) é normalmente um item grande (foto, apresentação, documento ou mídia) salvo em formatos binários.  

Aspose.Slides for Python via .NET permite que você use BLOBs para objetos de maneira que reduza o consumo de memória quando arquivos grandes estão envolvidos.  

## **Use BLOB para Reduzir o Consumo de Memória**

### **Adicionar Arquivo Grande via BLOB a uma Apresentação**

[Aspose.Slides](/slides/pt/python-net/) para .NET permite que você adicione arquivos grandes (neste caso, um arquivo de vídeo grande) por meio de um processo que envolve BLOBs para reduzir o consumo de memória.

Este exemplo em Python mostra como adicionar um arquivo de vídeo grande ao processo BLOB em uma apresentação:

```py
import aspose.slides as slides

pathToVeryLargeVideo = "veryLargeVideo.avi"

# Cria uma nova apresentação à qual o vídeo será adicionado
with slides.Presentation() as pres:
    with open(pathToVeryLargeVideo, "br") as fileStream:
        # Vamos adicionar o vídeo à apresentação - escolhemos o comportamento KeepLocked porque nós
        # não pretendemos acessar o arquivo "veryLargeVideo.avi".
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_video_frame(0, 0, 480, 270, video)

        # Salva a apresentação. Enquanto uma apresentação grande é gerada, o consumo de memória
        # permanece baixo ao longo do ciclo de vida do objeto pres
        pres.save("presentationWithLargeVideo.pptx", slides.export.SaveFormat.PPTX)
```

### **Exportar Arquivo Grande via BLOB de uma Apresentação**
Aspose.Slides for Python via .NET permite que você exporte arquivos grandes (neste caso, um arquivo de áudio ou vídeo) por meio de um processo que envolve BLOBs de apresentações. Por exemplo, pode ser necessário extrair um arquivo de mídia grande de uma apresentação, mas sem carregá‑lo na memória do computador. Exportando o arquivo pelo processo BLOB, você mantém o consumo de memória baixo.  

Este código em Python demonstra a operação descrita:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation(path + "Video.pptx", loadOptions) as pres:
	# Vamos salvar cada vídeo em um arquivo. Para evitar alto consumo de memória, precisamos de um buffer que será usado
	# para transferir os dados do fluxo de vídeo da apresentação para um fluxo de um arquivo de vídeo recém‑criado.
	# byte[] buffer = new byte[8 * 1024];
    bufferSize = 8 * 1024

	# Itera pelos vídeos
    index = 0
    # Se necessário, você pode aplicar os mesmos passos para arquivos de áudio. 
    for video in pres.videos:
		# Abre o fluxo de vídeo da apresentação. Por favor, note que evitamos intencionalmente acessar propriedades
		# como video.BinaryData - porque essa propriedade retorna um array de bytes contendo um vídeo completo, que então
		# causa o carregamento de bytes na memória. Usamos video.GetStream, que retornará Stream - e NÃO
		#  requer que carreguemos o vídeo inteiro na memória.
        with video.get_stream() as presVideoStream:
            with open("video{index}.avi".format(index = index), "wb") as outputFileStream:
                buffer = presVideoStream.read(8 * 1024)
                bytesRead = len(buffer)
                while bytesRead > 0:
                    outputFileStream.write(buffer)
                    buffer = presVideoStream.read(8 * 1024)
                    bytesRead = len(buffer)
                    
        index += 1
```

### **Adicionar Imagem como BLOB na Apresentação**
Com os métodos da classe [**ImageCollection**](https://reference.aspose.com/slides/pt/python-net/aspose.slides/imagecollection/), você pode adicionar uma imagem grande como fluxo para que ela seja tratada como BLOB.  

Este código Python mostra como adicionar uma imagem grande pelo processo BLOB:

```py
import aspose.slides as slides

# cria uma nova apresentação à qual a imagem será adicionada.
with slides.Presentation() as pres:
    with open("img.jpeg", "br") as fileStream:
        img = pres.images.add_image(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, 300, 200, img)
    pres.save("presentationWithLargeImage.pptx", slides.export.SaveFormat.PPTX)
```

## **Memória e Apresentações Grandes**

Normalmente, para carregar uma apresentação grande, os computadores necessitam de muita memória temporária. Todo o conteúdo da apresentação é carregado na memória e o arquivo (de onde a apresentação foi carregada) deixa de ser usado.  

Considere uma apresentação PowerPoint grande (large.pptx) que contém um arquivo de vídeo de 1,5 GB. O método padrão para carregar a apresentação está descrito neste código Python:

```py
import aspose.slides as slides

with slides.Presentation("large.pptx") as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

Mas esse método consome cerca de 1,6 GB de memória temporária.  

### **Carregar uma Apresentação Grande como BLOB**

Por meio do processo que envolve um BLOB, você pode carregar uma apresentação grande usando pouca memória. Este código Python descreve a implementação onde o processo BLOB é usado para carregar um arquivo de apresentação grande (large.pptx):

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation("large.pptx", loadOptions) as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

### **Alterar a Pasta para Arquivos Temporários**

Quando o processo BLOB é usado, o computador cria arquivos temporários na pasta padrão para arquivos temporários. Se desejar que os arquivos temporários sejam mantidos em outra pasta, você pode alterar as configurações de armazenamento usando `temp_files_root_path`:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True
loadOptions.blob_management_options.temp_files_root_path = "temp"
```

{{% alert title="Info" color="info" %}}
Ao usar `temp_files_root_path`, o Aspose.Slides não cria automaticamente uma pasta para armazenar arquivos temporários. Você deve criar a pasta manualmente.  
{{% /alert %}}

### **Descartar Objetos de Apresentação para Liberar Memória**

Ao processar apresentações grandes, garanta que a instância de [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) seja descartada corretamente para que a memória que ela ocupava seja liberada. A forma recomendada é usar o gerenciador de contexto (`with slides.Presentation(...) as presentation:`) conforme mostrado nos exemplos acima; ele fecha a apresentação automaticamente e libera recursos não gerenciados ao sair do bloco.

Se você criar uma apresentação sem um bloco `with`, chame explicitamente `presentation.dispose()` depois de terminar de usá‑la e remova quaisquer referências restantes para que o coletor de lixo do Python possa recuperar a memória.

```py
import aspose.slides as slides

presentation = slides.Presentation("large.pptx")

# ...processar a apresentação...
presentation.save("large.pdf", slides.export.SaveFormat.PDF)

# Liberar recursos explicitamente.
presentation.dispose()
```

## **FAQ**

**Quais dados em uma apresentação Aspose.Slides são tratados como BLOB e controlados pelas opções de BLOB?**

Objetos binários grandes, como imagens, áudio e vídeo, são tratados como BLOB. O arquivo completo da apresentação também envolve manipulação de BLOB quando é carregado ou salvo. Esses objetos são regidos por políticas de BLOB que permitem gerenciar o uso de memória e transferir para arquivos temporários quando necessário.

**Onde configuro as regras de manipulação de BLOB durante o carregamento da apresentação?**

Use [LoadOptions](https://reference.aspose.com/slides/pt/python-net/aspose.slides/loadoptions/) com [BlobManagementOptions](https://reference.aspose.com/slides/pt/python-net/aspose.slides/blobmanagementoptions/). Neles você define o limite de memória para BLOB, permite ou nega arquivos temporários, escolhe o caminho raiz para arquivos temporários e seleciona o comportamento de bloqueio da fonte.

**As configurações de BLOB afetam o desempenho e como equilibrar velocidade vs. memória?**

Sim. Manter BLOBs na memória maximiza a velocidade, mas aumenta o consumo de RAM; reduzir o limite de memória desloca mais trabalho para arquivos temporários, diminuindo a RAM ao custo de I/O adicional. Ajuste o limiar [max_blobs_bytes_in_memory](https://reference.aspose.com/slides/pt/python-net/aspose.slides/blobmanagementoptions/max_blobs_bytes_in_memory/) para encontrar o equilíbrio adequado ao seu carga de trabalho e ambiente.

**As opções de BLOB ajudam ao abrir apresentações extremamente grandes (por exemplo, gigabytes)?**

Sim. [BlobManagementOptions](https://reference.aspose.com/slides/pt/python-net/aspose.slides/blobmanagementoptions/) foram projetadas para esses cenários: habilitar arquivos temporários e usar bloqueio de fonte pode reduzir significativamente o pico de uso de RAM e estabilizar o processamento de decks muito grandes.

**Posso usar políticas de BLOB ao carregar a partir de streams em vez de arquivos de disco?**

Sim. As mesmas regras se aplicam a streams: a instância da apresentação pode possuir e bloquear o stream de entrada (dependendo do modo de bloqueio escolhido), e arquivos temporários são usados quando permitidos, mantendo o uso de memória previsível durante o processamento.