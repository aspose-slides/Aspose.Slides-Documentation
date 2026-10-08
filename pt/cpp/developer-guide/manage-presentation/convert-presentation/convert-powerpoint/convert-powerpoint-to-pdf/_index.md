---
title: Converter PPT e PPTX para PDF em C++ [Recursos Avançados Incluídos]
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
- anexo
- PDF/A1a
- PDF/A1b
- PDF/UA
- C++
- Aspose.Slides
description: "Converter PowerPoint PPT/PPTX em PDFs de alta qualidade e pesquisáveis em C++ usando Aspose.Slides, com exemplos de código rápidos e opções avançadas de conversão."
---
## **Visão geral**

Converter apresentações do PowerPoint (PPT, PPTX, ODP, etc.) para o formato PDF em C++ oferece várias vantagens, incluindo compatibilidade entre diferentes dispositivos e preservação do layout e da formatação da sua apresentação. Este guia demonstra como converter apresentações para documentos PDF, usar várias opções para controlar a qualidade das imagens, incluir slides ocultos, proteger PDFs com senha, detectar substituições de fontes, selecionar slides específicos para conversão e aplicar padrões de conformidade aos documentos de saída.

## **Conversões de PowerPoint para PDF**

Usando Aspose.Slides, você pode converter apresentações dos seguintes formatos para PDF:

* **PPT**
* **PPTX**
* **ODP**

Para converter uma apresentação para PDF, passe o nome do arquivo como argumento para a classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) e, em seguida, salve a apresentação como PDF usando o método [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/). A classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) expõe o método [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) que normalmente é usado para converter uma apresentação para PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides for C++ insere suas informações de API e número de versão nos documentos de saída. Por exemplo, ao converter uma apresentação para PDF, Aspose.Slides preenche o campo Application com "*Aspose.Slides*" e o campo PDF Producer com um valor no formato "*Aspose.Slides v XX.XX*". **Note** que você não pode instruir o Aspose.Slides a alterar ou remover essas informações dos documentos de saída.
{{% /alert %}}

Aspose.Slides permite converter:

* Apresentações inteiras para PDF
* Slides específicos de uma apresentação para PDF

Aspose.Slides exporta apresentações para PDF, garantindo que os PDFs resultantes correspondam de perto às apresentações originais. Elementos e atributos são renderizados com precisão na conversão, incluindo:

* Imagens
* Caixas de texto e formas
* Formatação de texto
* Formatação de parágrafo
* Links
* Cabeçalhos e rodapés
* Marcadores
* Tabelas

## **Converter PowerPoint para PDF**

O processo padrão de conversão de PowerPoint para PDF usa opções padrão. Nesse caso, Aspose.Slides tenta converter a apresentação fornecida para PDF usando configurações otimizadas no nível máximo de qualidade.

O exemplo a seguir carrega uma apresentação e salva todos os slides visíveis em PDF usando as configurações de exportação padrão.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Aspose oferece um conversor online gratuito de **PowerPoint para PDF**[**Conversor de PowerPoint para PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) que demonstra o processo de conversão de apresentação para PDF. Você pode executar um teste com este conversor para uma implementação ao vivo do procedimento descrito aqui.
{{% /alert %}}

## **Converter PowerPoint para PDF com Opções**

Aspose.Slides fornece opções personalizadas — propriedades da classe [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) — que permitem personalizar o PDF resultante, proteger o PDF com senha ou especificar como o processo de conversão deve prosseguir.

### **Converter PowerPoint para PDF com Opções Personalizadas**

Usando opções de conversão personalizadas, você pode definir a configuração de qualidade preferida para imagens raster, especificar como os metafiles devem ser tratados, definir um nível de compactação para texto, configurar DPI para imagens e muito mais.

O exemplo a seguir exporta uma apresentação para PDF 1.5 com qualidade JPEG definida em 90, resolução de imagem definida em 300 DPI, metafiles salvos como PNG e compressão de texto Flate.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfCompliance.h>
#include <Export/PdfOptions.h>
#include <Export/PdfTextCompression.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_JpegQuality(90);
pdfOptions->set_SufficientResolution(300);
pdfOptions->set_SaveMetafilesAsPng(true);
pdfOptions->set_TextCompression(PdfTextCompression::Flate);
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **Preservar Arquivos OLE Incorporados como Anexos PDF**

Se uma apresentação contém uma pasta de trabalho do Excel incorporada, talvez você queira que os destinatários do PDF acessem os dados da pasta de trabalho além de visualizar os slides. Chame [PdfOptions::set_IncludeOleData](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_includeoledata/) com `true` para preservar arquivos OLE incorporados como anexos no PDF resultante.

O valor padrão é `false`: a imagem de pré‑visualização ou ícone do objeto OLE é renderizado na página PDF, mas seu arquivo incorporado não é incluído como anexo. Definir a opção como `true` inclui adicionalmente os dados do arquivo. A pré‑visualização permanece uma representação visual; o anexo permite que os destinatários abram ou salvem o arquivo incorporado separadamente. O objeto OLE não se torna uma planilha do Excel interativa na página PDF.

O exemplo a seguir carrega uma apresentação que já contém uma pasta de trabalho do Excel incorporada e a exporta para PDF com a pasta de trabalho anexada.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_IncludeOleData(true);

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
presentation->Save(u"presentation.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

Para verificar o resultado:

1. Abra o PDF exportado em um visualizador que suporte anexos de arquivos, como o Adobe Acrobat Reader.
2. Abra o painel **Attachments** do visualizador e localize a pasta de trabalho incorporada.
3. Salve o anexo e abra‑o no Excel para inspecionar seus dados, ou abra‑o diretamente se o visualizador permitir. A pré‑visualização na página PDF é separada do anexo.

{{% alert color="info" title="Note" %}}
Os padrões PDF/A impõem restrições aos anexos: PDF/A-1 proíbe arquivos incorporados, PDF/A-2 permite apenas anexos PDF/A, e PDF/A-3 permite outros tipos de arquivos, incluindo pastas de trabalho Excel. Estas são exigências dos padrões, não restrições específicas ao Aspose.Slides. Este exemplo usa a configuração padrão de conformidade PDF e não demonstra exportação PDF/A.
{{% /alert %}}

### **Converter PowerPoint para PDF com Slides Ocultos**

Se uma apresentação contém slides ocultos, você pode usar o método [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) da classe [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) para incluir os slides ocultos como páginas no PDF resultante.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_ShowHiddenSlides(true);

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **Converter PowerPoint para PDF Protegido por Senha**

O exemplo a seguir exporta uma apresentação para um PDF que requer a senha `password` para ser aberto. As permissões de acesso permitem impressão, incluindo impressão de alta qualidade.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfAccessPermissions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **Detectar Substituições de Fonte**

Aspose.Slides fornece o método [set_WarningCallback](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_warningcallback/) na classe [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/), permitindo detectar substituições de fontes durante o processo de conversão de apresentação para PDF.

O exemplo a seguir exporta uma apresentação para PDF e imprime avisos de substituição de fontes no console. Um aviso é impresso somente quando uma fonte indisponível é substituída durante a exportação.

```cpp
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

class FontSubstitutionHandler : public IWarningCallback
{
public:
    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override
    {
        if (warning->get_WarningType() == WarningType::DataLoss && warning->get_Description().StartsWith(u"Font will be substituted"))
        {
            Console::WriteLine(u"Font substitution warning: {0}", warning->get_Description());
        }

        return ReturnAction::Continue;
    }
};

auto pdfOptions = MakeObject<PdfOptions>();
auto warningHandler = MakeObject<FontSubstitutionHandler>();
pdfOptions->set_WarningCallback(warningHandler);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Para mais informações sobre substituição de fontes, consulte o artigo [Substituição de Fonte](/slides/pt/cpp/font-substitution/).
{{% /alert %}} 

### **Manipular Fontes Sem um Tipo de Letra Negrito Dedicado**

Uma apresentação pode aplicar formatação em negrito a um texto mesmo quando sua fonte não possui um tipo de letra negrito dedicado. O texto ainda pode aparecer em negrito por meio de negrito sintético, que espessa artificialmente os glifos regulares. Quando esse texto parece muito pesado ou difere da aparência pretendida no PDF, experimente chamar [PdfOptions::set_RasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_rasterizeunsupportedfontstyles/) com `true`. Esta opção renderiza o texto afetado como bitmap durante a exportação para PDF e pode melhorar sua aparência para certas fontes. Seu valor padrão é `false`.

A apresentação de exemplo contém duas caixas de texto: uma com texto regular e outra com formatação em negrito aplicada à mesma fonte, que não possui um tipo de letra negrito dedicado. O exemplo a seguir carrega a apresentação, habilita a rasterização de estilos de fonte não suportados e a exporta para PDF:

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_RasterizeUnsupportedFontStyles(true);

auto presentation = MakeObject<Presentation>(u"unsupported-bold.pptx");
presentation->Save(u"rasterized.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

As visualizações a seguir mostram a saída com a opção desativada e a saída com a opção ativada. Neste exemplo, o texto em negrito tem traços mais pesados com a opção desativada. Com a opção ativada, seus traços são mais leves; o texto regular permanece inalterado. Compare os resultados antes de escolher a configuração para sua apresentação.

| Opção desativada (`false`, padrão) | Opção ativada (`true`) |
|---|---|
| ![PDF com rasterização de estilo de fonte não suportado desativada](unsupported-bold-disabled.png) | ![PDF com rasterização de estilo de fonte não suportado ativada](unsupported-bold-enabled.png) |

Neste exemplo, ativar a opção transforma apenas o texto em negrito em bitmap: ele não pode ser selecionado, copiado ou pesquisado como texto sem OCR, e suas bordas aparecem mais suaves em 800% de zoom. O texto regular permanece pesquisável. Com a opção desativada, ambas as cadeias permanecem como texto.

Esta opção rasteriza texto formatado em negrito quando sua fonte não tem um tipo de letra negrito dedicado. [Substituição de Fonte](/slides/pt/cpp/font-substitution/) em vez disso seleciona outra fonte quando a original não está disponível.

## **Converter Slides Selecionados do PowerPoint para PDF**

O exemplo a seguir exporta os slides 1 e 3 de uma apresentação para PDF. Os números dos slides neste array são baseados em 1, e a apresentação de entrada deve conter pelo menos três slides.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
auto slides = MakeArray<int32_t>({ 1, 3 });
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);
presentation->Dispose();
```

## **Converter PowerPoint para PDF com Tamanho de Slide Personalizado**

O exemplo a seguir copia o primeiro slide de uma apresentação para uma nova apresentação com tamanho de slide de 612 × 792 pontos (8,5 × 11 polegadas). Ele escala o conteúdo do slide para caber e exporta o slide único para PDF.

```cpp
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

auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");
auto resizedPresentation = MakeObject<Presentation>();

resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// Remove the blank slide that the new presentation was created with.
resizedPresentation->get_Slides()->RemoveAt(1);

resizedPresentation->Save(u"PDF_with_custom_slide_size.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **Converter PowerPoint para PDF na Visualização de Slides de Notas**

O exemplo a seguir exporta uma apresentação para PDF, colocando as notas do apresentador de cada slide abaixo do slide. Use uma apresentação que contenha notas do apresentador para ver o resultado.

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

auto presentation = MakeObject<Presentation>(u"NotesFile.pptx");
presentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

## **Acessibilidade e Padrões de Conformidade para PDF**

Aspose.Slides permite usar um procedimento de conversão que esteja em conformidade com as [Diretrizes de Acessibilidade de Conteúdo Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Você pode exportar um documento PowerPoint para PDF usando qualquer um destes padrões de conformidade: **PDF/A1a**, **PDF/A1b** e **PDF/UA**.

Este código C++ demonstra um processo de conversão de PowerPoint para PDF que produz vários PDFs com base em diferentes padrões de conformidade:

```cpp
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

{{% alert color="info" title="Note" %}}
Aspose.Slides suporta operações de conversão de PDF, permitindo converter arquivos PDF para formatos de arquivo populares. Você pode realizar conversões de [PDF para HTML](https://products.aspose.com/slides/cpp/conversion/pdf-to-html/), [PDF para imagem](https://products.aspose.com/slides/cpp/conversion/pdf-to-image/), [PDF para JPG](https://products.aspose.com/slides/cpp/conversion/pdf-to-jpg/), e [PDF para PNG](https://products.aspose.com/slides/cpp/conversion/pdf-to-png/) . Outras operações de conversão de PDF para formatos especializados — [PDF para SVG](https://products.aspose.com/slides/cpp/conversion/pdf-to-svg/), [PDF para TIFF](https://products.aspose.com/slides/cpp/conversion/pdf-to-tiff/), e [PDF para XML](https://products.aspose.com/slides/cpp/conversion/pdf-to-xml/) — também são suportadas.
{{% /alert %}}

> **Nota:** Ao exportar para PDF/UA, Aspose.Slides trata gráficos complexos como SmartArt, diagramas e fórmulas como uma única figura. Elementos de caminho individuais não são preservados como conteúdo separado e podem ser marcados como artefatos; texto alternativo é fornecido apenas para a figura inteira.

## **Perguntas Frequentes**

**Posso converter vários arquivos PowerPoint para PDF em lote?**

Sim, o Aspose.Slides suporta a conversão em lote de vários arquivos PPT ou PPTX para PDF. Você pode percorrer seus arquivos e aplicar o processo de conversão programaticamente.

**É possível proteger o PDF convertido com senha?**

Sim. Use a classe [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) para definir uma senha e especificar permissões de acesso durante o processo de conversão.

**Como incluo slides ocultos no PDF?**

Use o método [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) na classe [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) para incluir slides ocultos no PDF resultante.

**O Aspose.Slides pode manter alta qualidade de imagem no PDF?**

Sim, você pode controlar a qualidade da imagem usando métodos como [set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_jpegquality/) e [set_SufficientResolution](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_sufficientresolution/) na classe [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) para garantir imagens de alta qualidade no seu PDF.

**O Aspose.Slides suporta padrões de conformidade PDF/A?**

Sim, o Aspose.Slides permite exportar PDFs que estejam em conformidade com vários padrões, incluindo PDF/A1a, PDF/A1b e PDF/UA, garantindo que seus documentos atendam aos requisitos de acessibilidade e arquivamento.

## **Recursos Adicionais**

- [Documentação do Aspose.Slides para C++](/slides/pt/cpp/)
- [Referência de API do Aspose.Slides para C++](https://reference.aspose.com/slides/cpp/)
- [Conversores Gratuitos Online da Aspose](https://products.aspose.app/slides/conversion)