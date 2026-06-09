---
title: Gerenciar BLOBs de Apresentação em PHP para Uso Eficiente de Memória
linktitle: Gerenciar BLOB
type: docs
weight: 10
url: /pt/php-java/manage-blob/
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
- PHP
- Aspose.Slides
description: "Gerencie dados BLOB no Aspose.Slides para PHP via Java para simplificar operações de arquivos PowerPoint e OpenDocument para um manuseio eficiente de apresentações."
---
## **Visão geral**

Aspose.Slides fornece tratamento baseado em BLOB para dados binários grandes em apresentações, ajudando a reduzir o consumo de memória ao trabalhar com imagens, áudio, vídeo e arquivos de apresentações de grande porte.

Este artigo mostra como usar o processamento baseado em BLOB para adicionar mídias grandes a uma apresentação, exportar mídias grandes de uma apresentação e carregar apresentações grandes de forma mais eficiente. Também explica como arquivos temporários podem ser usados durante o processamento e como alterar a pasta usada para armazená‑los.

## **Sobre o BLOB**

**BLOB** (**Binary Large Object**) costuma ser um item grande (foto, apresentação, documento ou mídia) salvo em formatos binários.  

Aspose.Slides for PHP via Java permite usar BLOBs para objetos de maneira que reduz o consumo de memória quando arquivos grandes estão envolvidos.

{{% alert title="Info" color="info" %}}
Para contornar certas limitações ao interagir com streams, Aspose.Slides pode copiar o conteúdo do stream. Carregar uma apresentação grande por meio de seu stream resultará na cópia do conteúdo da apresentação e causará carregamento lento. Portanto, quando você pretende carregar uma apresentação grande, recomendamos fortemente que use o caminho do arquivo da apresentação e não seu stream.
{{% /alert %}}

## **Usar BLOB para reduzir o consumo de memória**

### **Adicionar um arquivo grande via BLOB a uma apresentação**

[Aspose.Slides](/slides/pt/php-java/) for Java permite adicionar arquivos grandes (neste caso, um arquivo de vídeo grande) por meio de um processo envolvendo BLOBs para reduzir o consumo de memória.

Este Java mostra como adicionar um arquivo de vídeo grande através do processo BLOB a uma apresentação:

```php
  $pathToVeryLargeVideo = "veryLargeVideo.avi";
  # Cria uma nova apresentação à qual o vídeo será adicionado
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToVeryLargeVideo);
    try {
      # Vamos adicionar o vídeo à apresentação - escolhemos o comportamento KeepLocked porque nós
      # não pretendemos acessar o "veryLargeVideo.avi" file.
      $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(0, 0, 480, 270, $video);
      # Salva a apresentação. Enquanto uma apresentação grande é gerada, o consumo de memória
      # permanece baixo ao longo do ciclo de vida do objeto pres
      $pres->save("presentationWithLargeVideo.pptx", SaveFormat::Pptx);
    } finally {
      if (!java_is_null($fileStream)) {
        $fileStream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Exportar um arquivo grande via BLOB de uma apresentação**

Aspose.Slides for PHP via Java permite exportar arquivos grandes (neste caso, um arquivo de áudio ou vídeo) por meio de um processo envolvendo BLOBs de apresentações. Por exemplo, pode ser necessário extrair um arquivo de mídia grande de uma apresentação, mas você não quer que o arquivo seja carregado na memória do computador. Exportando o arquivo através do processo BLOB, você mantém o consumo de memória baixo.

Este código demonstra a operação descrita:

```php
  $hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
  $loadOptions = new LoadOptions();
  # Bloqueia o arquivo de origem e NÃO o carrega na memória
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  # cria a instância da Presentation, bloqueia o "hugePresentationWithAudiosAndVideos.pptx" file.
  $pres = new Presentation($hugePresentationWithAudiosAndVideosFile, $loadOptions);
  try {
    # Vamos salvar cada vídeo em um arquivo. Para evitar alto consumo de memória, precisamos de um buffer que será usado
    # para transferir os dados do stream de vídeo da apresentação para um stream de um novo arquivo de vídeo.
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    $buffer = $Array->newInstance($Byte, 8 * 1024);
    # Itera pelos vídeos
    for($index = 0; $index < java_values($pres->getVideos()->size()) ; $index++) {
      $video = $pres->getVideos()->get_Item($index);
      # Abre o stream de vídeo da apresentação. Por favor, observe que evitamos intencionalmente acessar propriedades
      # como video.BinaryData - porque essa propriedade retorna um array de bytes contendo um vídeo completo, o que então
      # faz com que os bytes sejam carregados na memória. Usamos video.GetStream, que retornará um Stream - e NÃO
      # requer que carreguemos todo o vídeo na memória.
      $presVideoStream = $video->getStream();
      try {
        $outputFileStream = new Java("java.io.FileOutputStream", "video" . $index . ".avi");
        try {
          $bytesRead;
          while ($bytesRead = $presVideoStream->read($buffer, 0, java_values($Array->getLength($buffer))) > 0) {
            $outputFileStream->write($buffer, 0, $bytesRead);
          } 
        } finally {
          $outputFileStream->close();
        }
      } finally {
        $presVideoStream->close();
      }
      # O consumo de memória permanecerá baixo independentemente do tamanho do vídeo ou da apresentação.
    }
    # Se necessário, você pode aplicar os mesmos passos para arquivos de áudio.
  } catch (JavaException $e) {
  } finally {
    $pres->dispose();
  }
```

### **Adicionar uma imagem como BLOB a uma apresentação**

Com os métodos da classe [ImageCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/imagecollection/) você pode adicionar uma imagem grande como stream para que ela seja tratada como BLOB.

Este código PHP mostra como adicionar uma imagem grande através do processo BLOB:

```php
  $pathToLargeImage = "large_image.jpg";
  # cria uma nova apresentação à qual a imagem será adicionada.
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToLargeImage);
    try {
      # Vamos adicionar a imagem à apresentação - escolhemos o comportamento KeepLocked porque nós
      # NÃO pretendemos acessar o "largeImage.png" file.
      $img = $pres->getImages()->addImage($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, 300, 200, $img);
      # Salva a apresentação. Enquanto uma apresentação grande é gerada, o consumo de memória
      # permanece baixo ao longo do ciclo de vida do objeto pres
      $pres->save("presentationWithLargeImage.pptx", SaveFormat::Pptx);
    } finally {
      if (!java_is_null($fileStream)) {
        $fileStream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Memória e apresentações grandes**

Normalmente, para carregar uma apresentação grande, os computadores precisam de muita memória temporária. Todo o conteúdo da apresentação é carregado na memória e o arquivo (do qual a apresentação foi carregada) deixa de ser usado.

Considere uma apresentação PowerPoint grande (large.pptx) que contém um arquivo de vídeo de 1,5 GB. O método padrão para carregar a apresentação é descrito neste código PHP:

```php
  $pres = new Presentation("large.pptx");
  try {
    $pres->save("large.pdf", SaveFormat::Pdf);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Mas esse método consome cerca de 1,6 GB de memória temporária.

### **Carregar uma apresentação grande como BLOB**

Por meio do processo envolvendo BLOB, você pode carregar uma apresentação grande usando pouca memória. Este código PHP descreve a implementação onde o processo BLOB é usado para carregar um arquivo de apresentação grande (large.pptx):

```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $pres = new Presentation("large.pptx", $loadOptions);
  try {
    $pres->save("large.pdf", SaveFormat::Pdf);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Alterar a pasta para arquivos temporários**

Quando o processo BLOB é usado, seu computador cria arquivos temporários na pasta padrão para arquivos temporários. Se desejar que os arquivos temporários sejam mantidos em outra pasta, você pode alterar as configurações de armazenamento usando `setTempFilesRootPath`:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $loadOptions->getBlobManagementOptions()->setTempFilesRootPath("temp");

```

{{% alert title="Info" color="info" %}}
Ao usar `setTempFilesRootPath`, Aspose.Slides não cria automaticamente uma pasta para armazenar arquivos temporários. Você precisa criar a pasta manualmente.
{{% /alert %}}

### **Descartar objetos Presentation para liberar memória**

Ao processar apresentações grandes, certifique‑se de que a instância [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/) seja descartada corretamente para que a memória ocupada seja liberada. Chame `dispose()` depois de terminar de usar a apresentação para liberar recursos não gerenciados.

```php
$presentation = new Presentation("large.pptx");

# ...processar a apresentação...
$presentation->save("large.pdf", SaveFormat::Pdf);

# Libere recursos explicitamente.
$presentation->dispose();
```

## **FAQ**

**Que dados em uma apresentação Aspose.Slides são tratados como BLOB e controlados por opções de BLOB?**  

Objetos binários grandes como imagens, áudio e vídeo são tratados como BLOB. O próprio arquivo de apresentação também envolve o tratamento BLOB quando é carregado ou salvo. Esses objetos são regidos por políticas de BLOB que permitem gerenciar o uso de memória e a gravação em arquivos temporários quando necessário.

**Onde configuro as regras de tratamento BLOB durante o carregamento da apresentação?**  

Use [LoadOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/loadoptions/) com [BlobManagementOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/blobmanagementoptions/). Lá você define o limite em memória para BLOB, permite ou impede arquivos temporários, escolhe o caminho raiz para arquivos temporários e seleciona o comportamento de bloqueio da origem.

**As configurações de BLOB afetam o desempenho e como equilibrar velocidade vs. memória?**  

Sim. Manter BLOBs em memória maximiza a velocidade, mas aumenta o consumo de RAM; reduzir o limite de memória desloca mais trabalho para arquivos temporários, reduzindo a RAM ao custo de I/O adicional. Use o método [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/pt/php-java/aspose.slides/blobmanagementoptions/setmaxblobsbytesinmemory/) para encontrar o equilíbrio adequado para sua carga de trabalho e ambiente.

**As opções de BLOB ajudam ao abrir apresentações extremamente grandes (por exemplo, vários gigabytes)?**  

Sim. [BlobManagementOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/blobmanagementoptions/) foram projetadas para esses cenários: habilitar arquivos temporários e usar bloqueio de origem pode reduzir significativamente o pico de uso de RAM e estabilizar o processamento de decks muito grandes.

**Posso usar políticas de BLOB ao carregar a partir de streams em vez de arquivos de disco?**  

Sim. As mesmas regras se aplicam a streams: a instância da apresentação pode possuir e bloquear o stream de entrada (dependendo do modo de bloqueio escolhido), e arquivos temporários são usados quando permitidos, mantendo o uso de memória previsível durante o processamento.