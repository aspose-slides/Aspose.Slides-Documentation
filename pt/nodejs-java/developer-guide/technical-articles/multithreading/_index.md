---
title: Multithreading no Aspose.Slides para Node.js via Java
linktitle: Multithreading
type: docs
weight: 310
url: /pt/nodejs-java/multithreading/
keywords:
- multithreading
- várias threads
- trabalho paralelo
- converter slides
- slides para imagens
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "O multithreading do Aspose.Slides para Node.js via Java aumenta o processamento de PowerPoint e OpenDocument. Descubra as melhores práticas para fluxos de trabalho de apresentações eficientes."
---
## **Introdução**

Embora o trabalho paralelo com apresentações seja possível (além de analisar/carregar/clonar) e tudo funcione bem (na maioria das vezes), há uma pequena chance de você obter resultados incorretos ao usar a biblioteca em múltiplas threads.

Recomendamos fortemente que você **não** use uma única instância de [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation) em um ambiente de multithreading, pois isso pode resultar em erros ou falhas imprevisíveis que não são facilmente detectados.

Não é **seguro** carregar, salvar e/ou clonar uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation) em múltiplas threads. Essas operações **não** são suportadas. Se você precisar executar tais tarefas, deve paralelizar as operações usando vários processos de thread única — e cada um desses processos deve usar sua própria instância de apresentação.

## **Converter Slides de Apresentação em Imagens em Paralelo**

Suponha que queiramos converter todos os slides de uma apresentação PowerPoint em imagens PNG em paralelo. Como não é seguro usar uma única instância de `Presentation` em múltiplas threads, dividimos os slides da apresentação em apresentações separadas e convertemos os slides em imagens em paralelo, usando cada apresentação em uma thread distinta. O exemplo de código a seguir mostra como fazer isso.

```javascript
const inputFilePath = "sample.pptx";
const outputFilePathTemplate = "slide_%d.png";
const imageScale = 2;

(async () => {
    const presentation = new aspose.slides.Presentation(inputFilePath);
    const slideCount = presentation.getSlides().size();
    const slideSize = presentation.getSlideSize().getSize();
    const slideWidth = slideSize.getWidth();
    const slideHeight = slideSize.getHeight();

    const conversionTasks = Array.from({ length: slideCount }, async (_, slideIndex) => {
        // Extrair o slide i em uma apresentação separada.
        const slidePresentation = new aspose.slides.Presentation();
        slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.DoNotScale);
        slidePresentation.getSlides().removeAt(0);
        slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

        try {
            const slide = slidePresentation.getSlides().get_Item(0);
            const image = slide.getImage(imageScale, imageScale);
            const imageFilePath = outputFilePathTemplate.replace("%d", slideIndex + 1);

            image.save(imageFilePath, aspose.slides.ImageFormat.Png);
            console.log(`Saved slide ${slideIndex + 1} to ${imageFilePath}`);
        } catch (error) {
            console.error(`Error processing slide ${slideIndex + 1}: ${error.message}`);
        } finally {
            slidePresentation.dispose();
        }
    });

    // Aguardar a conclusão de todas as tarefas.
    await Promise.all(conversionTasks);

    presentation.dispose();
})();
```

## **FAQ**

**Preciso chamar a configuração de licença em cada thread?**

Não. Basta fazê‑lo uma vez por **processo/domínio de aplicação** antes de as **threads** iniciarem. Se a [license setup](/slides/pt/nodejs-java/licensing/) puder ser invocada simultaneamente (por exemplo, durante a inicialização tardia), sincronize essa chamada, pois o método de configuração de licença não é thread‑safe.

**Posso passar objetos `Presentation` ou `Slide` entre threads?**

Passar objetos de apresentação "ao vivo" entre **threads** não é recomendado: use instâncias independentes por **thread** ou pré‑crie apresentações/contêineres de slides separados para cada **thread**. Essa abordagem segue a recomendação geral de não compartilhar uma única instância de apresentação entre **threads**.

**É seguro paralelizar a exportação para diferentes formatos (PDF, HTML, imagens) desde que cada thread tenha sua própria instância de `Presentation`?**

Sim. Com instâncias independentes e caminhos de saída separados, essas tarefas geralmente são paralelizadas corretamente; evite quaisquer objetos de apresentação compartilhados e fluxos de I/O compartilhados.

**O que devo fazer com as configurações globais de fontes (pastas, substituições) em multithreading?**

Inicialize todas as configurações globais de fontes antes de iniciar as threads e não as altere durante o trabalho paralelo. Isso elimina condições de corrida ao acessar recursos de fontes compartilhados.