---
title: Criar Apresentações em Java
linktitle: Criar Apresentação
type: docs
weight: 10
url: /pt/java/create-presentation/
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
- Java
- Aspose.Slides
description: "Crie apresentações em Java com Aspose.Slides—produza arquivos PPT, PPTX e ODP, aproveite o suporte OpenDocument e salve-os programaticamente para resultados confiáveis."
---
## **Visão geral**

Este artigo mostra como criar uma apresentação no Aspose.Slides, adicionar uma forma com texto ao seu primeiro slide e salvar o resultado como um arquivo PPTX. Para abrir uma apresentação existente e salvá‑la em outro formato, veja [Open Presentations](/slides/pt/java/open-presentation/) e [Save Presentations](/slides/pt/java/save-presentation/). Um FAQ curto ao final cobre perguntas comuns sobre formatos, modelos, dimensionamento de slides, unidades, uso de memória, multithreading, licenciamento, assinaturas digitais e suporte a VBA.

Antes de começar, adicione o Aspose.Slides for Java ao seu projeto a partir do repositório Maven da Aspose. Consulte [Installation](/slides/pt/java/installation/) para a configuração Maven e para o que o Linux precisa além disso.

## **Criar uma apresentação**

Criar um arquivo PowerPoint do zero no Aspose.Slides for Java começa com uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/). O construtor fornece uma apresentação em branco com um único slide, pronto para formas, texto, gráficos ou qualquer outro conteúdo que sua aplicação necessite. Depois de modificar esse slide ou adicionar novos, você pode salvar o resultado em formatos PPTX, PPT (legado) ou OpenDocument.

Para criar uma apresentação e colocar uma forma com texto em seu primeiro slide, siga estas etapas:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/). Uma nova apresentação já contém um slide vazio.  
2. Obtenha esse slide pelo seu índice, 0, a partir da coleção que [getSlides](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/#getSlides--) retorna.  
3. Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iautoshape/) do tipo `Cloud` usando o método [addAutoShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) e defina seu texto com [setText](https://reference.aspose.com/slides/pt/java/com.aspose.slides/itextframe/#setText-java.lang.String-).  
4. Salve a apresentação como um arquivo PPTX usando o método [save](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/#save-java.lang.String-int-).

O exemplo abaixo é um programa completo. No projeto Maven de [Installation](/slides/pt/java/installation/), salve‑o como *src/main/java/HelloSlides.java* e execute `mvn compile exec:java`.

```java
import com.aspose.slides.*;

public class HelloSlides {
    public static void main(String[] args) {
        // Criar uma apresentação. Ela já contém um slide vazio.
        Presentation presentation = new Presentation();
        try {
            // Obter o primeiro slide.
            ISlide slide = presentation.getSlides().get_Item(0);

            // Adicionar uma forma de nuvem e colocar texto nela.
            IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80);
            autoShape.getTextFrame().setText("Hello, Aspose!");

            // Salvar a apresentação como um arquivo PPTX.
            presentation.save("new_presentation.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

O canto superior esquerdo da nuvem está a 20 pontos da borda esquerda e a 20 pontos da borda superior do slide, e a forma tem 200 pontos de largura e 80 pontos de altura. O programa salva *new_presentation.pptx* com um slide que contém a nuvem e seu texto. Sem uma licença, o Aspose.Slides também adiciona uma marca d'água de avaliação a cada slide salvo; veja [Licensing](/slides/pt/java/licensing/).

O resultado:

![The new presentation](new_presentation.png)

## **FAQ**

### Em quais formatos posso salvar uma nova apresentação?

Você pode salvar em [PPTX, PPT e ODP](/slides/pt/java/save-presentation/), e exportar para [PDF](/slides/pt/java/convert-powerpoint-to-pdf/), [XPS](/slides/pt/java/convert-powerpoint-to-xps/), [HTML](/slides/pt/java/convert-powerpoint-to-html/), [SVG](/slides/pt/java/render-a-slide-as-an-svg-image/) e [imagens](/slides/pt/java/convert-powerpoint-to-png/), entre outros.

### Posso iniciar a partir de um modelo (POTX/POTM) e salvar como um PPTX regular?

Sim. Carregue o modelo e salve no formato desejado; os formatos POTX/POTM/PPTM e similares [são suportados](/slides/pt/java/supported-file-formats/).

### Como controlo o tamanho/relação de aspecto do slide ao criar uma apresentação?

Defina o [slide size](/slides/pt/java/slide-size/) (incluindo predefinições como 4:3 e 16:9 ou dimensões personalizadas) e escolha como o conteúdo deve ser dimensionado.

### Em quais unidades são medidos o tamanho e as coordenadas?

Em pontos: 1 polegada equivale a 72 unidades.

### Como lidar com apresentações muito grandes (com muitos arquivos de mídia) para reduzir o uso de memória?

Use [BLOB management strategies](/slides/pt/java/manage-blob/), limite o armazenamento em memória aproveitando arquivos temporários e prefira fluxos baseados em arquivo em vez de streams puramente em memória.

### Posso criar/salvar apresentações em paralelo?

Você não pode operar na mesma instância de [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/) a partir de [multiple threads](/slides/pt/java/multithreading/). Execute instâncias separadas e isoladas por thread ou processo.

### Como remover a marca d'água da avaliação e as limitações?

[Apply a license](/slides/pt/java/licensing/) uma vez por processo. O XML da licença deve permanecer inalterado, e a configuração da licença deve ser sincronizada se múltiplas threads estiverem envolvidas.

### Posso assinar digitalmente o PPTX que crio?

Sim. [Digital signatures](/slides/pt/java/digital-signature-in-powerpoint/) (adição e verificação) são suportadas para apresentações.

### Macros (VBA) são suportadas em apresentações criadas?

Sim. Você pode [create/edit VBA projects](/slides/pt/java/presentation-via-vba/) e salvar arquivos habilitados a macro, como PPTM/PPSM.