---
title: Converter PPT e PPTX para PDF em C++ [Recursos avançados incluídos]
linktitle: PowerPoint para PDF
type: docs
weight: 40
url: /pt/cpp/convert-powerpoint-to-pdf/
keywords:
- converter PowerPoint
- converter apresentação
- PowerPoint para PDF
- apresentação para PDF
- PPT para PDF
- converter PPT para PDF
- PPTX para PDF
- converter PPTX para PDF
- salvar PowerPoint como PDF
- salvar PPT como PDF
- salvar PPTX como PDF
- exportar PPT para PDF
- exportar PPTX para PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- C++
- Aspose.Slides
description: "Converter PowerPoint PPT/PPTX para PDFs de alta qualidade e pesquisáveis em C++ usando Aspose.Slides, com exemplos de código rápidos e opções avançadas de conversão."
---
## **Visão geral**

Converter apresentações do PowerPoint (PPT, PPTX, ODP etc.) para formato PDF em C++ oferece diversas vantagens, incluindo compatibilidade entre diferentes dispositivos e preservação do layout e da formatação da sua apresentação. Este guia demonstra como converter apresentações para documentos PDF, usar várias opções para controlar a qualidade da imagem, incluir slides ocultos, proteger PDFs com senha, detectar substituições de fontes, selecionar slides específicos para conversão e aplicar padrões de conformidade nos documentos resultantes.

## **Conversões de PowerPoint para PDF**

Usando Aspose.Slides, você pode converter apresentações nos seguintes formatos para PDF:

* **PPT**
* **PPTX**
* **ODP**

Para converter uma apresentação para PDF, passe o nome do arquivo como argumento para a classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) e, em seguida, salve a apresentação como PDF usando o método `Save`. A classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) expõe o método `Save` que normalmente é usado para converter uma apresentação para PDF.

{{%  alert title="NOTE"  color="warning"   %}} 
Aspose.Slides for C++ insere informações da sua API e número da versão nos documentos de saída. Por exemplo, ao converter uma apresentação para PDF, Aspose.Slides preenche o campo Application com "*Aspose.Slides*" e o campo PDF Producer com um valor no formato "*Aspose.Slides v XX.XX*". **Nota** de que não é possível instruir o Aspose.Slides a alterar ou remover essas informações dos documentos de saída.
{{% /alert %}}

Aspose.Slides permite que você converta:

* Apresentações inteiras para PDF
* Slides específicos de uma apresentação para PDF

Aspose.Slides exporta apresentações para PDF, garantindo que os PDFs resultantes correspondam de perto às apresentações originais. Elementos e atributos são renderizados com precisão na conversão, incluindo:

* Imagens
* Caixas de texto e formas
* Formatação de texto
* Formatação de parágrafo
* Hiperlinks
* Cabeçalhos e rodapés
* Marcadores
* Tabelas

## **Converter PowerPoint para PDF**

O processo padrão de conversão de PowerPoint para PDF usa opções padrão. Nesse caso, Aspose.Slides tenta converter a apresentação fornecida para PDF usando configurações ideais nos níveis máximos de qualidade.

Este código C++ mostra como converter uma apresentação (PPT, PPTX, ODP etc.) para PDF:

```c++
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instantiate the Presentation class that represents a PowerPoint or OpenDocument file.
auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");

// Save the presentation as a PDF.
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);

presentation->Dispose();
```

{{%  alert  color="info"  %}} 
A Aspose oferece um conversor online gratuito de [**PowerPoint para PDF**](https://products.aspose.app/slides/pt/conversion/ppt-to-pdf) que demonstra o processo de conversão de apresentação para PDF. Você pode executar um teste com esse conversor para obter uma implementação ao vivo do procedimento descrito aqui.
{{% /alert %}}

## **Converter PowerPoint para PDF com Opções**

Aspose.Slides fornece opções personalizadas—propriedades da classe [PdfOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/pdfoptions/)—que permitem personalizar o PDF resultante, bloquear o PDF com senha ou especificar como o processo de conversão deve prosseguir.

### **Converter PowerPoint para PDF com Opções Personalizadas**

Usando opções de conversão personalizadas, você pode definir sua configuração de qualidade preferida para imagens raster, especificar como metafiles devem ser tratados, definir um nível de compressão para texto, configurar DPI para imagens e muito mais.

O exemplo de código abaixo demonstra como converter uma apresentação do PowerPoint para PDF com várias opções personalizadas.

```c++
#include <DOM/Presentation.h>
#include <Export/PdfCompliance.h>
#include <Export/PdfOptions.h>
#include <Export/PdfTextCompression.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instanciar a classe PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// Definir a qualidade para imagens JPG.
pdfOptions->set_JpegQuality(90);

// Definir DPI para imagens.
pdfOptions->set_SufficientResolution(300);

// Definir o comportamento para metafiles.
pdfOptions->set_SaveMetafilesAsPng(true);

// Definir o nível de compressão de texto para conteúdo textual.
pdfOptions->set_TextCompression(PdfTextCompression::Flate);

// Definir o modo de conformidade PDF.
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

// Instanciar a classe Presentation que representa um arquivo PowerPoint ou OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Salvar a apresentação como um documento PDF.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Converter PowerPoint para PDF com Slides Ocultos**

Se uma apresentação contém slides ocultos, você pode usar o método [set_ShowHiddenSlides](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) da classe [PdfOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/pdfoptions/) para incluir os slides ocultos como páginas no PDF resultante.

Este código C++ mostra como converter uma apresentação do PowerPoint para PDF com slides ocultos incluídos:

```c++
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instanciar a classe Presentation que representa um arquivo PowerPoint ou OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Instanciar a classe PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// Adicionar slides ocultos.
pdfOptions->set_ShowHiddenSlides(true);

// Salvar a apresentação como PDF.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Converter PowerPoint para PDF Protegido por Senha**

Este código C++ demonstra como converter uma apresentação do PowerPoint em um PDF protegido por senha usando os parâmetros de proteção da classe [PdfOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/pdfoptions/):

```c++
#include <DOM/Presentation.h>
#include <Export/PdfAccessPermissions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instanciar a classe Presentation que representa um arquivo PowerPoint ou OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Instanciar a classe PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// Definir uma senha PDF e permissões de acesso.
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

// Salvar a apresentação como PDF.
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Detectar Substituição de Fontes**

Aspose.Slides fornece o método [set_WarningCallback](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/saveoptions/set_warningcallback/) na classe [PdfOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/pdfoptions/) que permite detectar substituições de fontes durante o processo de conversão de apresentação para PDF.

Este código C++ mostra como detectar substituições de fontes:

```c++
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <Warnings/IWarningCallback.h>
#include <Warnings/IWarningInfo.h>
#include <Warnings/ReturnAction.h>
#include <Warnings/WarningType.h>
#include <system/console.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Warnings;
using namespace System;

// Implementação do callback de aviso.
class FontSubstitutionHandler : public IWarningCallback
{
public:
    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override;
};

ReturnAction FontSubstitutionHandler::Warning(SharedPtr<IWarningInfo> warning)
{
    if (warning->get_WarningType() == WarningType::DataLoss &&
        warning->get_Description().StartsWith(u"Font will be substituted"))
    {
        Console::WriteLine(u"Font substitution warning: {0}", warning->get_Description());
    }

    return ReturnAction::Continue;
}

int main()
{
    // Instanciar a classe Presentation que representa um arquivo PowerPoint ou OpenDocument.
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // Definir o callback de aviso nas opções de PDF.
    auto pdfOptions = MakeObject<PdfOptions>();
    pdfOptions->set_WarningCallback(MakeObject<FontSubstitutionHandler>());

    // Salvar a apresentação como PDF.
    presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);

    presentation->Dispose();

    return 0;
}
```

{{%  alert color="info"  %}} 
Para mais informações sobre como receber callbacks de substituição de fontes durante o processo de renderização, consulte [Getting Warning Callbacks for Fonts Substitution](/slides/pt/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Para mais informações sobre substituição de fontes, consulte o artigo [Font Substitution](/slides/pt/cpp/font-substitution/).
{{% /alert %}} 

## **Converter Slides Selecionados do PowerPoint para PDF**

Este código C++ demonstra como converter apenas slides específicos de uma apresentação do PowerPoint para PDF:

```C++
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instanciar a classe Presentation que representa um arquivo PowerPoint ou OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Definir array de números de slide.
auto slides = MakeArray<int32_t>({ 1, 3 });

// Salvar a apresentação como PDF.
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);

presentation->Dispose();
```

## **Converter PowerPoint para PDF com Tamanho de Slide Personalizado**

Este código C++ demonstra como converter uma apresentação do PowerPoint para PDF com um tamanho de slide especificado:

```C++
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto slideWidth = 612;
auto slideHeight = 792;

// Instanciar a classe Presentation que representa um arquivo PowerPoint ou OpenDocument.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Criar uma nova apresentação com tamanho de slide ajustado.
auto resizedPresentation = MakeObject<Presentation>();

// Definir o tamanho de slide personalizado.
resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

// Clonar o primeiro slide da apresentação original.
auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// Salvar a apresentação redimensionada em um PDF com notas.
resizedPresentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **Converter PowerPoint para PDF no Modo de Visualização de Notas dos Slides**

Este código C++ demonstra como converter uma apresentação do PowerPoint para um PDF que inclui notas:

```C++
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instanciar a classe Presentation que representa um arquivo PowerPoint ou OpenDocument.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Configurar as opções de PDF com layout de notas.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Salvar a apresentação em um PDF com notas.
presentation->Save(u"PDF_with_notes.tiff", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

## **Acessibilidade e Padrões de Conformidade para PDF**

Aspose.Slides permite que você use um procedimento de conversão que está em conformidade com as [Diretrizes de Acessibilidade de Conteúdo Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Você pode exportar um documento PowerPoint para PDF usando qualquer um desses padrões de conformidade: **PDF/A1a**, **PDF/A1b** e **PDF/UA**.

Este código C++ demonstra um processo de conversão de PowerPoint para PDF que produz vários PDFs com base em diferentes padrões de conformidade:

```C++
#include <DOM/Presentation.h>
#include <Export/PdfCompliance.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"pres.pptx");

auto pdfOptionsA1a = MakeObject<PdfOptions>();

pdfOptionsA1a->set_Compliance(PdfCompliance::PdfA1a);
presentation->Save(u"pres-a1a-compliance.pdf", SaveFormat::Pdf, pdfOptionsA1a);

auto pdfOptionsA1b = MakeObject<PdfOptions>();
pdfOptionsA1b->set_Compliance(PdfCompliance::PdfA1b);
presentation->Save(u"pres-a1b-compliance.pdf", SaveFormat::Pdf, pdfOptionsA1b);

auto pdfOptionsUa = MakeObject<PdfOptions>();
pdfOptionsUa->set_Compliance(PdfCompliance::PdfUa);

presentation->Save(u"pres-ua-compliance.pdf", SaveFormat::Pdf, pdfOptionsUa);

presentation->Dispose();
```

{{% alert title="Note" color="warning" %}} 
Aspose.Slides suporta operações de conversão de PDF, permitindo converter arquivos PDF para formatos de arquivo populares. Você pode realizar conversões de [PDF para HTML](https://products.aspose.com/slides/pt/cpp/conversion/pdf-to-html/), [PDF para imagem](https://products.aspose.com/slides/pt/cpp/conversion/pdf-to-image/), [PDF para JPG](https://products.aspose.com/slides/pt/cpp/conversion/pdf-to-jpg/) e [PDF para PNG](https://products.aspose.com/slides/pt/cpp/conversion/pdf-to-png/). Outras operações de conversão de PDF para formatos especializados—[PDF para SVG](https://products.aspose.com/slides/pt/cpp/conversion/pdf-to-svg/), [PDF para TIFF](https://products.aspose.com/slides/pt/cpp/conversion/pdf-to-tiff/), e [PDF para XML](https://products.aspose.com/slides/pt/cpp/conversion/pdf-to-xml/)—também são suportadas.
{{% /alert %}}

> **Nota:** Ao exportar para PDF/UA, Aspose.Slides trata gráficos complexos como SmartArt, gráficos e fórmulas como uma única figura. Os elementos de caminho individuais não são preservados como conteúdo separado e podem ser marcados como artefatos; o texto alternativo é fornecido apenas para a figura inteira.

## **FAQ**

### Posso converter vários arquivos PowerPoint para PDF em lote?

Sim, Aspose.Slides suporta conversão em lote de vários arquivos PPT ou PPTX para PDF. Você pode iterar sobre seus arquivos e aplicar o processo de conversão programaticamente.

### É possível proteger o PDF convertido com senha?

Absolutamente. Use a classe [PdfOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/pdfoptions/) para definir uma senha e especificar permissões de acesso durante o processo de conversão.

### Como incluo slides ocultos no PDF?

Use o método `set_ShowHiddenSlides` na classe [PdfOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/pdfoptions/) para incluir slides ocultos no PDF resultante.

### O Aspose.Slides mantém alta qualidade de imagem no PDF?

Sim, você pode controlar a qualidade da imagem usando métodos como `set_JpegQuality` e `set_SufficientResolution` na classe [PdfOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/pdfoptions/) para garantir imagens de alta qualidade no seu PDF.

### O Aspose.Slides suporta padrões de conformidade PDF/A?

Sim, Aspose.Slides permite exportar PDFs que atendem a vários padrões, incluindo PDF/A1a, PDF/A1b e PDF/UA, garantindo que seus documentos cumpram requisitos de acessibilidade e arquivamento.

## **Recursos Adicionais**

- [Documentação do Aspose.Slides for C++](/slides/pt/cpp/)
- [Referência da API do Aspose.Slides for C++](https://reference.aspose.com/slides/pt/cpp/)
- [Conversores Online Gratuitos da Aspose](https://products.aspose.app/slides/pt/conversion)