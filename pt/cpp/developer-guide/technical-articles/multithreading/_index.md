---
title: Multithreading em Aspose.Slides para C++
linktitle: Multithreading
type: docs
weight: 200
url: /pt/cpp/multithreading/
keywords:
- multithreading
- várias threads
- trabalho paralelo
- converter slides
- slides para imagens
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "O multithreading do Aspose.Slides para C++ aumenta o processamento de PowerPoint e OpenDocument. Descubra as melhores práticas para fluxos de trabalho de apresentações eficientes."
---
## **Introdução**

Embora o trabalho paralelo com apresentações seja possível (além de analisar/carregar/duplicar) e tudo ocorra bem (na maioria das vezes), há uma pequena chance de obter resultados incorretos ao usar a biblioteca em múltiplas threads.

Recomendamos fortemente que você **não** use uma única instância de [Presentation](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation) em um ambiente de multithreading, pois isso pode resultar em erros ou falhas imprevisíveis que não são facilmente detectados. 

Não é seguro carregar, salvar e/ou duplicar uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation) em múltiplas threads. Essas operações **não** são suportadas. Se precisar realizar essas tarefas, você deve paralelizar as operações usando vários processos de thread única — e cada um desses processos deve usar sua própria instância de apresentação. 

## **Converter Slides de Apresentação em Imagens em Paralelo**

Suponha que queiramos converter todos os slides de uma apresentação PowerPoint em imagens PNG em paralelo. Como é inseguro usar uma única instância `Presentation` em múltiplas threads, dividimos os slides da apresentação em apresentações separadas e convertemos os slides em imagens em paralelo, usando cada apresentação em uma thread distinta. O exemplo de código a seguir mostra como fazer isso.

```cpp
auto inputFilePath = u"sample.pptx";
auto outputFilePathTemplate = u"slide_{0}.png";
auto imageScale = 2;

auto presentation = MakeObject<Presentation>(inputFilePath);

auto slideCount = presentation->get_Slides()->get_Count();
auto slideSize = presentation->get_SlideSize()->get_Size();

std::vector<std::future<void>> conversionTasks;

for (auto slideIndex = 0; slideIndex < slideCount; slideIndex++) {
    // Extrair o slide i em uma apresentação separada.
    auto slidePresentation = MakeObject<Presentation>();
    slidePresentation->get_SlideSize()->SetSize(slideSize.get_Width(), slideSize.get_Height(), SlideSizeScaleType::DoNotScale);
    slidePresentation->get_Slides()->RemoveAt(0);
    slidePresentation->get_Slides()->AddClone(presentation->get_Slide(slideIndex));

    // Converter o slide em uma imagem em uma tarefa separada.
    auto slideNumber = slideIndex + 1;
    conversionTasks.push_back(std::async(std::launch::async, [slidePresentation = std::move(slidePresentation), slideNumber, outputFilePathTemplate, imageScale]() {
        SharedPtr<IImage> image = nullptr;
        try {
            auto slide = slidePresentation->get_Slide(0);

            auto image = slide->GetImage(imageScale, imageScale);
            auto imageFilePath = String::Format(outputFilePathTemplate, slideNumber);
            image->Save(imageFilePath, ImageFormat::Png);
        }
        catch (Exception e) {
            if(image != nullptr) image->Dispose();
            slidePresentation->Dispose();
        }
    }));
}

// Aguardar a conclusão de todas as tarefas.
for (auto& task : conversionTasks) {
    task.get();
}

presentation->Dispose();
```

## **FAQ**

**Preciso chamar a configuração de licença em cada thread?**

Não. Basta fazê‑la uma vez por processo/app domain antes das threads iniciarem. Se a [configuração de licença](/slides/pt/cpp/licensing/) puder ser invocada simultaneamente (por exemplo, durante inicialização tardia), sincronize essa chamada, pois o método de configuração de licença em si não é thread‑safe.

**Posso passar objetos `Presentation` ou `Slide` entre threads?**

Passar objetos de apresentação “vivos” entre threads não é recomendado: use instâncias independentes por thread ou pré‑crie apresentações/containers de slides separados para cada thread. Essa abordagem segue a recomendação geral de não compartilhar uma única instância de apresentação entre threads.

**É seguro paralelizar a exportação para diferentes formatos (PDF, HTML, imagens) desde que cada thread tenha sua própria instância `Presentation`?**

Sim. Com instâncias independentes e caminhos de saída separados, essas tarefas normalmente paralelizam corretamente; evite objetos de apresentação compartilhados e fluxos de I/O compartilhados.

**O que devo fazer com as configurações globais de fontes (pastas, substituições) em multithreading?**

Inicialize todas as configurações globais de fontes antes de iniciar as threads e não as altere durante o trabalho paralelo. Isso elimina condições de corrida ao acessar recursos de fontes compartilhados.