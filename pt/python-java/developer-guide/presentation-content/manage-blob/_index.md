---
title: Gerenciar BLOBs de Apresentação em Python via Java para Uso Eficiente de Memória
linktitle: Gerenciar BLOB
type: docs
weight: 10
url: /pt/python-java/manage-blob/
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
- Java
- Aspose.Slides
description: "Gerencie dados BLOB no Aspose.Slides para Python via Java para simplificar operações de arquivos PowerPoint e OpenDocument para um manuseio eficiente de apresentações."
---
## **Visão geral**

Aspose.Slides fornece tratamento baseado em BLOB para grandes dados binários em apresentações, ajudando a reduzir o consumo de memória ao trabalhar com imagens, áudio, vídeo e arquivos de apresentação grandes.

Este artigo mostra como usar o processamento baseado em BLOB para adicionar mídia grande a uma apresentação, exportar mídia grande de uma apresentação e carregar apresentações grandes de forma mais eficiente. Também explica como arquivos temporários podem ser usados durante o processamento e como alterar a pasta usada para armazená‑los.

{{% alert color="info" title="Note" %}}

Para contornar certas limitações ao interagir com fluxos, Aspose.Slides pode copiar o conteúdo do fluxo. Carregar uma apresentação grande por meio de seu fluxo resultará na cópia do conteúdo da apresentação e causará carregamento lento. Portanto, quando você pretende carregar uma apresentação grande, recomendamos fortemente que use o caminho do arquivo da apresentação e não seu fluxo.

{{% /alert %}}

## **Usar BLOB para Reduzir o Consumo de Memória**

### **Adicionar um Arquivo Grande via BLOB a uma Apresentação**

[Aspose.Slides](/slides/pt/python-java/) for Python via Java permite adicionar arquivos grandes (neste caso, um arquivo de vídeo grande) por meio de um processo envolvendo BLOBs para reduzir o consumo de memória.

Este código Python mostra como adicionar um arquivo de vídeo grande através do processo BLOB a uma apresentação:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadingStreamBehavior, Presentation, SaveFormat
from java.io import FileInputStream

path_to_very_large_video = "veryLargeVideo.avi"

# Crie uma nova apresentação à qual o vídeo será adicionado.
presentation = Presentation()
try:
    file_stream = FileInputStream(path_to_very_large_video)
    try:
        # Mantenha o fluxo bloqueado porque não pretendemos acessar o arquivo de vídeo.
        video = presentation.getVideos().addVideo(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video)

        # Salve a apresentação mantendo o consumo de memória baixo.
        presentation.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

### **Exportar um Arquivo Grande via BLOB de uma Apresentação**

Aspose.Slides for Python via Java permite exportar arquivos grandes (neste caso, um arquivo de áudio ou vídeo) por meio de um processo envolvendo BLOBs de apresentações. Por exemplo, pode ser necessário extrair um arquivo de mídia grande de uma apresentação, mas sem carregá‑lo na memória do computador. Ao exportar o arquivo através do processo BLOB, você mantém o consumo de memória baixo.

Este código Python demonstra a operação descrita:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior

huge_presentation_file = "LargeVideoFileTest.pptx"

load_options = LoadOptions()
# Bloqueie o arquivo de origem em vez de carregá-lo na memória.
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)

presentation = Presentation(huge_presentation_file, load_options)
try:
    # Transfira os dados de vídeo através de um buffer para manter o consumo de memória baixo.
    buffer = jpype.JArray(jpype.JByte)(8 * 1024)

    for index in range(presentation.getVideos().size()):
        video = presentation.getVideos().get_Item(index)

        # Use o stream em vez de carregar o vídeo inteiro em um array de bytes.
        video_stream = video.getStream()
        try:
            with open(f"video{index}.avi", "wb") as output_stream:
                bytes_read = video_stream.read(buffer, 0, len(buffer))
                while bytes_read > 0:
                    chunk = bytes(buffer[:bytes_read])
                    output_stream.write(chunk)
                    bytes_read = video_stream.read(buffer, 0, len(buffer))
        finally:
            video_stream.close()
    # Se necessário, aplique os mesmos passos aos arquivos de áudio.
finally:
    presentation.dispose()
```

### **Adicionar uma Imagem como BLOB a uma Apresentação**

Com os métodos da classe [ImageCollection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/imagecollection/) você pode adicionar uma imagem grande como fluxo para que seja tratada como BLOB.

Este código Python mostra como adicionar uma imagem grande através do processo BLOB:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadingStreamBehavior, Presentation, SaveFormat, ShapeType
from java.io import FileInputStream

path_to_large_image = "large_image.jpg"

# Crie uma nova apresentação à qual a imagem será adicionada.
presentation = Presentation()
try:
    file_stream = FileInputStream(path_to_large_image)
    try:
        # Mantenha o stream bloqueado porque não pretendemos acessar o arquivo de imagem.
        image = presentation.getImages().addImage(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, image)

        # Salve a apresentação mantendo o consumo de memória baixo.
        presentation.save("presentationWithLargeImage.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

## **Memória e Apresentações Grandes**

Normalmente, para carregar uma apresentação grande, os computadores exigem muita memória temporária. Todo o conteúdo da apresentação é carregado na memória e o arquivo (do qual a apresentação foi carregada) deixa de ser usado.

Considere uma apresentação PowerPoint grande (large.pptx) que contém um vídeo de 1,5 GB. O método padrão para carregar a apresentação está descrito neste código Python:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("large.pptx")
try:
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

Mas esse método consome cerca de 1,6 GB de memória temporária.

### **Carregar uma Apresentação Grande como BLOB**

Através do processo envolvendo um BLOB, você pode carregar uma apresentação grande usando pouca memória. Este código Python descreve a implementação onde o processo BLOB é usado para carregar um arquivo de apresentação grande (large.pptx):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior, SaveFormat

load_options = LoadOptions()
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)
load_options.getBlobManagementOptions().setTemporaryFilesAllowed(True)

presentation = Presentation("large.pptx", load_options)
try:
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

### **Alterar a Pasta para Arquivos Temporários**

Quando o processo BLOB é usado, o computador cria arquivos temporários na pasta padrão para arquivos temporários. Se desejar que os arquivos temporários sejam mantidos em outra pasta, pode alterar as configurações de armazenamento usando [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/pt/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, PresentationLockingBehavior

load_options = LoadOptions()
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)
load_options.getBlobManagementOptions().setTemporaryFilesAllowed(True)
load_options.getBlobManagementOptions().setTempFilesRootPath("temp")
```

{{% alert color="info" title="Note" %}}

Ao usar [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/pt/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath), Aspose.Slides não cria automaticamente uma pasta para armazenar arquivos temporários. Você deve criar a pasta manualmente.

{{% /alert %}}

### **Descartar Objetos da Apresentação para Liberar Memória**

Ao processar apresentações grandes, certifique‑se de que a instância [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) seja descartada adequadamente para que a memória que ocupava seja liberada. Chame [Presentation.dispose](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#dispose) após terminar de usar a apresentação para liberar recursos não gerenciados.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("large.pptx")
try:
    # ...processar a apresentação...
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    # Libere recursos explicitamente.
    presentation.dispose()
```

## **FAQ**

**Quais dados em uma apresentação Aspose.Slides são tratados como BLOB e controlados pelas opções de BLOB?**

Objetos binários grandes, como imagens, áudio e vídeo, são tratados como BLOB. O próprio arquivo da apresentação também envolve tratamento BLOB ao ser carregado ou salvo. Esses objetos são regidos por políticas de BLOB que permitem gerenciar o uso de memória e transferir dados para arquivos temporários quando necessário.

**Onde configuro as regras de tratamento BLOB durante o carregamento da apresentação?**

Use [LoadOptions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/loadoptions/) com [BlobManagementOptions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/blobmanagementoptions/). Lá você define o limite em memória para BLOB, permite ou impede arquivos temporários, escolhe o caminho raiz para arquivos temporários e seleciona o comportamento de bloqueio da fonte.

**As configurações de BLOB afetam o desempenho e como equilibrar velocidade versus memória?**

Sim. Manter BLOB em memória maximiza a velocidade, mas aumenta o consumo de RAM; reduzir o limite de memória transfere mais trabalho para arquivos temporários, diminuindo a RAM ao custo de I/O adicional. Use o método [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/pt/python-java/aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory) para encontrar o equilíbrio adequado ao seu workload e ambiente.

**As opções de BLOB ajudam ao abrir apresentações extremamente grandes (por exemplo, gigabytes)?**

Sim. [BlobManagementOptions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/blobmanagementoptions/) foram projetadas para esses cenários: habilitar arquivos temporários e usar bloqueio de fonte pode reduzir significativamente o uso máximo de RAM e estabilizar o processamento de decks muito grandes.

**Posso usar políticas de BLOB ao carregar a partir de streams em vez de arquivos de disco?**

Sim. As mesmas regras se aplicam a streams: a instância da apresentação pode possuir e bloquear o stream de entrada (dependendo do modo de bloqueio escolhido), e arquivos temporários são usados quando permitidos, mantendo o uso de memória previsível durante o processamento.