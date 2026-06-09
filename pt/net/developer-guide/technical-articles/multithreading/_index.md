---
title: Multithreading no Aspose.Slides para .NET
linktitle: Multithreading
type: docs
weight: 310
url: /pt/net/multithreading/
keywords:
- multithreading
- múltiplas threads
- trabalho paralelo
- converter slides
- slides para imagens
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "O multithreading do Aspose.Slides para .NET acelera o processamento de PowerPoint e OpenDocument. Descubra as melhores práticas para fluxos de trabalho de apresentações eficientes."
---
## **Introdução**

Embora o trabalho paralelo com apresentações seja possível (além de análise/carregamento/clonagem) e tudo funcione bem (na maioria das vezes), há uma pequena chance de obter resultados incorretos ao usar a biblioteca em múltiplas threads.

Recomendamos enfaticamente que **não** use uma única instância de [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation) em um ambiente de multithreading, pois isso pode resultar em erros ou falhas imprevisíveis que não são facilmente detectados. 

Não é **seguro** carregar, salvar e/ou clonar uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation) em múltiplas threads. Essas operações **não** são suportadas. Se precisar executar tais tarefas, você deve paralelizar as operações usando vários processos single-threaded — e cada um desses processos deve usar sua própria instância de apresentação. 

## **Converter Slides de Apresentação em Imagens em Paralelo**

Suponha que queiramos converter todos os slides de uma apresentação PowerPoint em imagens PNG em paralelo. Como não é seguro usar uma única instância `Presentation` em múltiplas threads, dividimos os slides da apresentação em apresentações separadas e convertemos os slides em imagens em paralelo, usando cada apresentação em uma thread distinta. O exemplo de código a seguir mostra como fazer isso.

```cs
var inputFilePath = "sample.pptx";
var outputFilePathTemplate = "slide_{0}.png";
var imageScale = 2;

using var presentation = new Presentation(inputFilePath);

var slideCount = presentation.Slides.Count;
var slideSize = presentation.SlideSize.Size;

var conversionTasks = new List<Task>(slideCount);

for (var slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    // Extrair o slide i em uma apresentação separada.
    var slidePresentation = new Presentation();
    slidePresentation.SlideSize.SetSize(slideSize.Width, slideSize.Height, SlideSizeScaleType.DoNotScale);
    slidePresentation.Slides.RemoveAt(0);
    slidePresentation.Slides.AddClone(presentation.Slides[slideIndex]);

    // Converter o slide em uma imagem em uma tarefa separada.
    var slideNumber = slideIndex + 1;
    conversionTasks.Add(Task.Run(() =>
    {
        try
        {
            var slide = slidePresentation.Slides[0];

            using var image = slide.GetImage(imageScale, imageScale);
            var imageFilePath = string.Format(outputFilePathTemplate, slideNumber);
            image.Save(imageFilePath, ImageFormat.Png);
        }
        finally
        {
            slidePresentation.Dispose();
        }
    }));
}

await Task.WhenAll(conversionTasks);
```

## **Perguntas Frequentes**

**Preciso chamar a configuração de licença em cada thread?**

Não. Basta fazê‑lo uma vez por processo/app domain antes de iniciar as threads. Se a [configuração de licença](/slides/pt/net/licensing/) puder ser invocada simultaneamente (por exemplo, durante a inicialização preguiçosa), sincronize essa chamada, pois o método de configuração de licença não é thread‑safe.

**Posso passar objetos `Presentation` ou `Slide` entre threads?**

Passar objetos de apresentação "ao vivo" entre threads não é recomendado: use instâncias independentes por thread ou pré‑crie apresentações/contêineres de slides separados para cada thread. Essa abordagem segue a recomendação geral de não compartilhar uma única instância de apresentação entre threads.

**É seguro paralelizar a exportação para diferentes formatos (PDF, HTML, imagens) desde que cada thread tenha sua própria instância `Presentation`?**

Sim. Com instâncias independentes e caminhos de saída separados, essas tarefas normalmente são paralelizadas corretamente; evite quaisquer objetos de apresentação compartilhados e fluxos de I/O compartilhados.

**O que devo fazer com as configurações globais de fontes (pastas, substituições) em multithreading?**

Inicialize todas as configurações globais de fontes antes de iniciar as threads e não as altere durante o trabalho paralelo. Isso elimina condições de corrida ao acessar recursos de fontes compartilhados.