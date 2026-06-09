---
title: Multithreading em Aspose.Slides para Java
linktitle: Multithreading
type: docs
weight: 310
url: /pt/java/multithreading/
keywords:
- multithreading
- múltiplas threads
- trabalho paralelo
- converter slides
- slides para imagens
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "O multithreading do Aspose.Slides para Java melhora o processamento de PowerPoint e OpenDocument. Descubra as melhores práticas para fluxos de trabalho de apresentações eficientes."
---
## **Introdução**

Embora o trabalho paralelo com apresentações seja possível (além de analisar/carregar/clonar) e tudo corra bem (na maioria das vezes), há uma pequena chance de você obter resultados incorretos ao usar a biblioteca em múltiplas threads.

Recomendamos enfaticamente que você **não** use uma única instância de [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation) em um ambiente de multithreading, pois isso pode resultar em erros ou falhas imprevisíveis que não são facilmente detectados.

Não é **seguro** carregar, salvar e/ou clonar uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation) em múltiplas threads. Essas operações **não** são suportadas. Se você precisar executar tais tarefas, deve paralelizar as operações usando vários processos monothread — e cada um desses processos deve usar sua própria instância de apresentação.

## **Converter Slides de Apresentação em Imagens em Paralelo**

Suponha que queiramos converter todos os slides de uma apresentação PowerPoint em imagens PNG em paralelo. Como não é seguro usar uma única instância `Presentation` em várias threads, dividimos os slides da apresentação em apresentações separadas e convertemos os slides em imagens em paralelo, usando cada apresentação em uma thread separada. O exemplo de código a seguir mostra como fazer isso.

```java
String inputFilePath = "sample.pptx";
String outputFilePathTemplate = "slide_%d.png";
final float imageScale = 2;

Presentation presentation = new Presentation(inputFilePath);

int slideCount = presentation.getSlides().size();
Dimension2D slideSize = presentation.getSlideSize().getSize();
float slideWidth = (float) slideSize.getWidth();
float slideHeight = (float) slideSize.getHeight();

List<CompletableFuture<Void>> conversionTasks = new ArrayList<>(slideCount);

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
    // Extrair o slide i em uma apresentação separada.
    Presentation slidePresentation = new Presentation();
    slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);
    slidePresentation.getSlides().removeAt(0);
    slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

    // Converter o slide em uma imagem em uma tarefa separada.
    final int slideNumber = slideIndex + 1;
    conversionTasks.add(CompletableFuture.runAsync(() -> {
        IImage image = null;
        try {
            ISlide slide = slidePresentation.getSlides().get_Item(0);

            image = slide.getImage(imageScale, imageScale);
            String imageFilePath = String.format(outputFilePathTemplate, slideNumber);
            image.save(imageFilePath, ImageFormat.Png);
        } finally {
            if (image != null) image.dispose();
            slidePresentation.dispose();
        }
    }));
}

// Aguardar a conclusão de todas as tarefas.
CompletableFuture.allOf(conversionTasks.toArray(new CompletableFuture[0])).join();

presentation.dispose();
```

## **Perguntas Frequentes**

**Preciso chamar a configuração de licença em cada thread?**

Não. Basta fazer isso uma única vez por processo/domínio de aplicação antes de iniciar as threads. Se a [license setup](/slides/pt/java/licensing/) puder ser invocada simultaneamente (por exemplo, durante a inicialização preguiçosa), sincronize essa chamada, pois o método de configuração de licença em si não é thread‑safe.

**Posso passar objetos `Presentation` ou `Slide` entre threads?**

Passar objetos de apresentação “vivos” entre threads não é recomendado: use instâncias independentes por thread ou pré‑crie apresentações/contêineres de slides separados para cada thread. Essa abordagem segue a recomendação geral de não compartilhar uma única instância de apresentação entre threads.

**É seguro paralelizar a exportação para diferentes formatos (PDF, HTML, imagens) desde que cada thread tenha sua própria instância `Presentation`?**

Sim. Com instâncias independentes e caminhos de saída separados, essas tarefas normalmente são paralelizadas corretamente; evite quaisquer objetos de apresentação compartilhados e streams de E/S compartilhados.

**O que devo fazer com as configurações globais de fontes (pastas, substituições) em multithreading?**

Inicialize todas as [font settings](/slides/pt/java/powerpoint-fonts/) globais antes de iniciar as threads e não as altere durante o trabalho paralelo. Isso elimina condições de corrida ao acessar recursos de fontes compartilhados.