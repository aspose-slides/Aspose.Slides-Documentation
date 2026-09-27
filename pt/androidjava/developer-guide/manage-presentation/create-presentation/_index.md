---
title: Criar apresentações no Android
linktitle: Criar apresentação
type: docs
weight: 10
url: /pt/androidjava/create-presentation/
keywords:
- criar apresentação
- nova apresentação
- criar PPT
- novo PPT
- criar PPTX
- novo PPTX
- criar ODP
- novo ODP
- PowerPoint
- OpenDocument
- apresentação
- Android
- Java
- Aspose.Slides
description: "Crie apresentações em Java com Aspose.Slides para Android - produza arquivos PPT, PPTX e ODP, aproveite o suporte OpenDocument e salve-os programaticamente para resultados confiáveis."
---
## **Visão geral**

Este artigo mostra como criar uma apresentação no Aspose.Slides para Android via Java, adicionar uma caixa de texto ao seu primeiro slide e salvar o resultado como um arquivo no armazenamento do seu aplicativo. Para abrir uma apresentação existente ou salvá‑la em outro formato, veja [Abrir Apresentação](/slides/pt/androidjava/open-presentation/) e [Salvar Apresentação](/slides/pt/androidjava/save-presentation/). Um breve FAQ ao final cobre dúvidas comuns sobre formatos, modelos, tamanho de slide, unidades, uso de memória, thread, licenciamento, assinaturas digitais e suporte a VBA.

Antes de começar, adicione Aspose.Slides ao seu projeto Android a partir do repositório Maven da Aspose. Consulte [Instalação](/slides/pt/androidjava/install-aspose-slides-for-android-via-java/).

## **Criar uma Apresentação PowerPoint**

Para criar uma apresentação e colocar uma caixa de texto no seu primeiro slide, siga estas etapas:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/). Uma nova apresentação já contém um slide vazio.  
2. Obtenha esse slide da [slide collection](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/islidecollection/) pelo índice 0.  
3. Adicione um retângulo com o método [addAutoShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) da [shape collection](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ishapecollection/) e defina o texto do seu [text frame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itextframe/) usando o método [setText](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itextframe/#setText-java.lang.String-).  
4. Salve a apresentação como um arquivo PPTX com o método [save](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) no formato [SaveFormat.Pptx](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/saveformat/).

O código é executado dentro de uma `Activity`, por exemplo no método `onCreate`. Ele salva o arquivo no diretório retornado pelo método [getFilesDir](https://developer.android.com/reference/android/content/Context#getFilesDir()), o armazenamento privado do seu aplicativo, que pode ser gravado sem solicitar nenhuma permissão.

```java
import com.aspose.slides.*;
import java.io.File;

File outputFile = new File(getFilesDir(), "hello.pptx");

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O canto superior esquerdo do retângulo está a 50 pontos da borda esquerda e a 50 pontos da borda superior do slide, e o retângulo tem 400 pontos de largura e 100 pontos de altura. O arquivo salvo contém um slide com esse retângulo e seu texto. Sem uma licença, o Aspose.Slides também adiciona uma marca d’água de avaliação a cada slide salvo; veja [Licenciamento](/slides/pt/androidjava/licensing/).

Para visualizar o arquivo, abra o [Device Explorer](https://developer.android.com/studio/debug/device-file-explorer) do Android Studio e localize *hello.pptx* em *data/data/*, na pasta *files* do seu aplicativo. Em um aplicativo real, processe apresentações em uma thread em segundo plano para que a interface do usuário continue responsiva.

## **FAQ**

### Em quais formatos posso salvar uma nova apresentação?

Você pode salvar em [PPTX, PPT e ODP](/slides/pt/androidjava/save-presentation/), e exportar para [PDF](/slides/pt/androidjava/convert-powerpoint-to-pdf/), [XPS](/slides/pt/androidjava/convert-powerpoint-to-xps/), [HTML](/slides/pt/androidjava/convert-powerpoint-to-html/), [SVG](/slides/pt/androidjava/render-a-slide-as-an-svg-image/) e [imagens](/slides/pt/androidjava/convert-powerpoint-to-png/), entre outros.

### Posso iniciar a partir de um modelo (POTX/POTM) e salvar como PPTX normal?

Sim. Carregue o modelo e salve no formato desejado; formatos como POTX/POTM/PPTM e semelhantes [são suportados](/slides/pt/androidjava/supported-file-formats/).

### Como controlo o tamanho/ proporção do slide ao criar uma apresentação?

Defina o [tamanho do slide](/slides/pt/androidjava/slide-size/) (incluindo predefinições como 4:3 e 16:9 ou dimensões personalizadas) e escolha como o conteúdo deve ser dimensionado.

### Em que unidades são medidos tamanhos e coordenadas?

Em pontos: 1 polegada equivale a 72 unidades.

### Como lidar com apresentações muito grandes (com muitos arquivos de mídia) para reduzir o uso de memória?

Use [estratégias de gerenciamento de BLOB](/slides/pt/androidjava/manage-blob/), limite o armazenamento em memória aproveitando arquivos temporários e prefira fluxos baseados em arquivos em vez de streams puramente em memória.

### Posso criar/salvar apresentações em paralelo?

Você não pode operar na mesma instância de [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/) a partir de [múltiplas threads](/slides/pt/androidjava/multithreading/). Execute instâncias separadas e isoladas por thread ou processo.

### Como remover a marca d’água de avaliação e as limitações?

[Aplicar uma licença](/slides/pt/androidjava/licensing/) uma vez por processo. O XML da licença deve permanecer inalterado, e a configuração da licença deve ser sincronizada se houver múltiplas threads envolvidas.

### Posso assinar digitalmente o PPTX que crio?

Sim. [Assinaturas digitais](/slides/pt/androidjava/digital-signature-in-powerpoint/) (adição e verificação) são suportadas para apresentações.

### Macros (VBA) são suportadas em apresentações criadas?

Sim. Você pode [criar/editar projetos VBA](/slides/pt/androidjava/presentation-via-vba/) e salvar arquivos habilitados para macro, como PPTM/PPSM.