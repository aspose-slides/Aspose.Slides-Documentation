---
title: Obter Callbacks de Aviso para Substituição de Fonte
type: docs
weight: 70
url: /pt/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- callback de aviso
- substituição de fonte
- processo de renderização
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Aprenda a obter callbacks de aviso para substituição de fonte no Aspose.Slides para C++ e exiba apresentações PowerPoint e OpenDocument com precisão."
---
## **Introdução**

Aspose.Slides for C++ permite que você receba callbacks de aviso para substituição de fontes quando uma fonte necessária não está disponível na máquina durante a renderização. Esses callbacks ajudam a diagnosticar problemas com fontes ausentes ou inacessíveis.

## **Ativar Callbacks de Aviso**

Aspose.Slides for C++ oferece APIs simples para receber callbacks de aviso ao renderizar slides de apresentação. Siga estas etapas para configurar os callbacks de aviso:

1. Crie uma classe de callback personalizada que implemente a interface [IWarningCallback](https://reference.aspose.com/slides/pt/cpp/aspose.slides.warnings/iwarningcallback/) para tratar avisos.
1. Defina o callback de aviso usando classes de opções como [RenderingOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/renderingoptions/), [PdfOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/htmloptions/) e outras.
1. Carregue uma apresentação que utilize uma fonte não disponível na máquina de destino.
1. Gere uma miniatura de slide ou exporte a apresentação para observar o efeito.

**Classe de Callback de Aviso Personalizada:**

```cpp
#include <Warnings/IWarningCallback.h>

class FontWarningHandler : public IWarningCallback
{
public:
    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override;
};

ReturnAction FontWarningHandler::Warning(SharedPtr<IWarningInfo> warning)
{
    if (warning->get_WarningType() == WarningType::DataLoss)
    {
        Console::WriteLine(warning->get_Description());
    }

    return ReturnAction::Continue;
}

// Exemplo de saída:
//
// A fonte será substituída de XYZ para {Calibri,Cambria Math,MS Gothic,Gulim,Arial Unicode,SimSun,Segoe UI Symbol}}
```

**Gerar uma Miniatura de Slide:**

```cpp
// Configurar um callback de aviso para tratar avisos relacionados a fontes durante a renderização dos slides.
auto options = MakeObject<RenderingOptions>();
options->set_WarningCallback(MakeObject<FontWarningHandler>());

// Carregar a apresentação a partir do caminho de arquivo especificado.
auto presentation = MakeObject<Presentation>(u"sample.pptx");
    
// Gerar uma imagem miniatura para cada slide da apresentação.
for(auto&& slide : presentation->get_Slides())
{
    // Obter a imagem miniatura do slide usando as opções de renderização especificadas.
    auto image = slide->GetImage(options);
    // ...

    image->Dispose();
}

presentation->Dispose();
```

**Exportar para Formato PDF:**

```cpp
// Configurar um callback de aviso para tratar avisos relacionados a fontes durante a exportação para PDF.
auto options = MakeObject<PdfOptions>();
options->set_WarningCallback(MakeObject<FontWarningHandler>());

// Carregar a apresentação a partir do caminho de arquivo especificado.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Exportar a apresentação como PDF.
auto stream = MakeObject<MemoryStream>();
presentation->Save(stream, SaveFormat::Pdf, options);
// ...

stream->Dispose();
presentation->Dispose();
```

**Exportar para Formato HTML:**

```cpp
// Configurar um callback de aviso para tratar avisos relacionados a fontes durante a exportação para HTML.
auto options = MakeObject<HtmlOptions>();
options->set_WarningCallback(MakeObject<FontWarningHandler>());

// Carregar a apresentação a partir do caminho de arquivo especificado.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Exportar a apresentação no formato HTML.
auto stream = MakeObject<MemoryStream>();
presentation->Save(stream, SaveFormat::Html, options);
// ...

stream->Dispose();
presentation->Dispose();
```