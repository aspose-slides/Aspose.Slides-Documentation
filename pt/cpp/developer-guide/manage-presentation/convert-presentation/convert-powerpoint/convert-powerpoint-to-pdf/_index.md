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
description: "Converta apresentações PowerPoint PPT/PPTX em PDFs de alta qualidade e pesquisáveis em C++ usando Aspose.Slides, com exemplos de código rápidos e opções avançadas de conversão."
---
## **Visão geral**

Converter apresentações PowerPoint (PPT, PPTX, ODP etc.) para formato PDF em C++ oferece diversas vantagens, incluindo compatibilidade entre diferentes dispositivos e preservação do layout e formatação da sua apresentação. Este guia demonstra como converter apresentações em documentos PDF, usar várias opções para controlar a qualidade de imagem, incluir slides ocultos, proteger arquivos PDF com senha, detectar substituições de fontes, selecionar slides específicos para conversão e aplicar padrões de conformidade aos documentos resultantes.

## **Conversões de PowerPoint para PDF**

Usando Aspose.Slides, você pode converter apresentações nos seguintes formatos para PDF:

* **PPT**
* **PPTX**
* **ODP**

Para converter uma apresentação para PDF, passe o nome do arquivo como argumento para a classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) e, em seguida, salve a apresentação como PDF usando o método `Save`. A classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) expõe o método `Save` que normalmente é usado para converter uma apresentação para PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for C++ insere suas informações de API e número da versão nos documentos de saída. Por exemplo, ao converter uma apresentação para PDF, Aspose.Slides preenche o campo Application com "*Aspose.Slides*" e o campo PDF Producer com um valor no formato "*Aspose.Slides v XX.XX*". **Observe** que não é possível instruir o Aspose.Slides a alterar ou remover essas informações dos documentos gerados.

{{% /alert %}}

Aspose.Slides permite que você converta:

* Apresentações inteiras para PDF
* Slides específicos de uma apresentação para PDF

Aspose.Slides exporta apresentações para PDF, garantindo que os PDFs resultantes correspondam de perto às apresentações originais. Elementos e atributos são renderizados com precisão na conversão, incluindo:

* Imagens
* Caixas de texto e formas
* Formatação de texto
* Formatação de parágrafos
* Hiperlinks
* Cabeçalhos e rodapés
* Marcadores
* Tabelas

## **Converter PowerPoint para PDF**

O processo padrão de conversão de PowerPoint para PDF usa opções padrão. Nesse caso, o Aspose.Slides tenta converter a apresentação fornecida para PDF usando configurações ótimas nos níveis máximos de qualidade.

Este código C++ mostra como converter uma apresentação (PPT, PPTX, ODP etc.) para PDF:

```c++
// Instancie a classe Presentation que representa um arquivo PowerPoint ou OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");

// Salve a apresentação como PDF.
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);

presentation->Dispose();
```

{{%  alert  color="primary"  %}} 

A Aspose oferece um conversor online gratuito de [**PowerPoint para PDF**](https://products.aspose.app/slides/pt/conversion/ppt-to-pdf) que demonstra o processo de conversão de apresentação para PDF. Você pode testar este conversor para ver uma implementação prática do procedimento descrito aqui.

{{% /alert %}}

## **Converter PowerPoint para PDF com Opções**

Aspose.Slides fornece opções personalizadas — propriedades da classe [PdfOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/pdfoptions/) — que permitem personalizar o PDF resultante, proteger o PDF com senha ou especificar como o processo de conversão deve prosseguir.

### **Converter PowerPoint para PDF com Opções Personalizadas**

Usando opções de conversão personalizadas, você pode definir sua configuração preferida de qualidade para imagens raster, especificar como arquivos metafile devem ser tratados, definir um nível de compressão para texto, configurar DPI para imagens e muito mais.

O exemplo de código abaixo demonstra como converter uma apresentação PowerPoint para PDF com várias opções personalizadas.

```c++
// Instancie a classe PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// Defina a qualidade das imagens JPG.
pdfOptions->set_JpegQuality(90);

// Defina o DPI para as imagens.
pdfOptions->set_SufficientResolution(300);

// Defina o comportamento para metafiles.
pdfOptions->set_SaveMetafilesAsPng(true);

// Defina o nível de compressão de texto para o conteúdo textual.
pdfOptions->set_TextCompression(PdfTextCompression::Flate);

// Defina o modo de conformidade PDF.
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

// Instancie a classe Presentation que representa um arquivo PowerPoint ou OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Salve a apresentação como um documento PDF.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Converter PowerPoint para PDF com Slides Ocultos**

Se uma apresentação contiver slides ocultos, você pode usar o método [set_ShowHiddenSlides](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) da classe [PdfOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/pdfoptions/) para incluir os slides ocultos como páginas no PDF resultante.

Este código C++ mostra como converter uma apresentação PowerPoint para PDF incluindo slides ocultos:

```c++
// Instancie a classe Presentation que representa um arquivo PowerPoint ou OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Instancie a classe PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// Adicione slides ocultos.
pdfOptions->set_ShowHiddenSlides(true);

// Salve a apresentação como PDF.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Converter PowerPoint para PDF Protegido por Senha**

Este código C++ demonstra como converter uma apresentação PowerPoint em um PDF protegido por senha usando os parâmetros de proteção da classe [PdfOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/pdfoptions/):

```c++
// Instancie a classe Presentation que representa um arquivo PowerPoint ou OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Instancie a classe PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// Defina uma senha PDF e permissões de acesso.
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

// Salve a apresentação como PDF.
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Detectar Substituições de Fonte**

Aspose.Slides fornece o método [set_WarningCallback](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/saveoptions/set_warningcallback/) na classe [PdfOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/pdfoptions/), permitindo detectar substituições de fontes durante o processo de conversão de apresentação para PDF.

Este código C++ mostra como detectar substituições de fontes:

```c++
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
    // Instancie a classe Presentation que representa um arquivo PowerPoint ou OpenDocument.
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // Defina o callback de aviso nas opções PDF.
    auto pdfOptions = MakeObject<PdfOptions>();
    pdfOptions->set_WarningCallback(MakeObject<FontSubstitutionHandler>());

    // Salve a apresentação como PDF.
    presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
    
    presentation->Dispose();

    return 0;
}
```

{{%  alert color="primary"  %}} 

Para mais informações sobre como receber callbacks de aviso para substituição de fontes durante o processo de renderização, consulte [Getting Warning Callbacks for Fonts Substitution](/slides/pt/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Para mais detalhes sobre substituição de fontes, veja o artigo [Font Substitution](/slides/pt/cpp/font-substitution/).

{{% /alert %}} 

## **Converter Slides Selecionados do PowerPoint para PDF**

Este código C++ demonstra como converter apenas slides específicos de uma apresentação PowerPoint para PDF:

```C++
// Instancie a classe Presentation que representa um arquivo PowerPoint ou OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Defina o array de números de slides.
auto slides = MakeArray<int32_t>({ 1, 3 });

// Salve a apresentação como PDF.
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);

presentation->Dispose();
```

## **Converter PowerPoint para PDF com Tamanho de Slide Personalizado**

Este código C++ demonstra como converter uma apresentação PowerPoint para PDF com um tamanho de slide especificado:

```C++
auto slideWidth = 612;
auto slideHeight = 792;

// Instancie a classe Presentation que representa um arquivo PowerPoint ou OpenDocument.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Crie uma nova apresentação com um tamanho de slide ajustado.
auto resizedPresentation = MakeObject<Presentation>();

// Defina o tamanho de slide personalizado.
resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

// Clone o primeiro slide da apresentação original.
auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// Salve a apresentação redimensionada em PDF com notas.
resizedPresentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **Converter PowerPoint para PDF no Modo de Visualização de Notas**

Este código C++ demonstra como converter uma apresentação PowerPoint para PDF que inclui notas:

```C++
// Instancie a classe Presentation que representa um arquivo PowerPoint ou OpenDocument.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Configure as opções PDF com layout de notas.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Salve a apresentação em PDF com notas.
presentation->Save(u"PDF_with_notes.tiff", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

## **Acessibilidade e Padrões de Conformidade para PDF**

Aspose.Slides permite que você use um procedimento de conversão que está em conformidade com as [Diretrizes de Acessibilidade de Conteúdo Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Você pode exportar um documento PowerPoint para PDF usando qualquer um desses padrões de conformidade: **PDF/A1a**, **PDF/A1b** e **PDF/UA**.

Este código C++ demonstra um processo de conversão de PowerPoint para PDF que produz múltiplos PDFs com base em diferentes padrões de conformidade:

```C++
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

Aspose.Slides suporta operações de conversão de PDF, permitindo que você converta arquivos PDF para formatos de arquivo populares. Você pode realizar conversões de [PDF para HTML](https://products.aspose.com/slides/pt/cpp/conversion/pdf-to-html/), [PDF para imagem](https://products.aspose.com/slides/pt/cpp/conversion/pdf-to-image/), [PDF para JPG](https://products.aspose.com/slides/pt/cpp/conversion/pdf-to-jpg/) e [PDF para PNG](https://products.aspose.com/slides/pt/cpp/conversion/pdf-to-png/). Outras operações de conversão de PDF para formatos especializados — [PDF para SVG](https://products.aspose.com/slides/pt/cpp/conversion/pdf-to-svg/), [PDF para TIFF](https://products.aspose.com/slides/pt/cpp/conversion/pdf-to-tiff/), e [PDF para XML](https://products.aspose.com/slides/pt/cpp/conversion/pdf-to-xml/) — também são suportadas.

{{% /alert %}}

> **Nota:** Ao exportar para PDF/UA, Aspose.Slides trata gráficos complexos como SmartArt, gráficos e fórmulas como uma única figura. Elementos de caminho individuais não são preservados como conteúdo separado e podem ser marcados como artefatos; o texto alternativo é fornecido apenas para a figura completa.

## **FAQ**

**Posso converter vários arquivos PowerPoint para PDF em lote?**

Sim, Aspose.Slides suporta conversão em lote de múltiplos arquivos PPT ou PPTX para PDF. Você pode percorrer seus arquivos e aplicar o processo de conversão programaticamente.

**É possível proteger o PDF convertido com senha?**

Com certeza. Use a classe [PdfOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/pdfoptions/) para definir uma senha e especificar permissões de acesso durante o processo de conversão.

**Como incluo slides ocultos no PDF?**

Utilize o método `set_ShowHiddenSlides` na classe [PdfOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/pdfoptions/) para incluir slides ocultos no PDF resultante.

**O Aspose.Slides pode manter alta qualidade de imagem no PDF?**

Sim, você pode controlar a qualidade das imagens usando métodos como `set_JpegQuality` e `set_SufficientResolution` na classe [PdfOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/pdfoptions/) para garantir imagens de alta qualidade no seu PDF.

**O Aspose.Slides oferece suporte a padrões de conformidade PDF/A?**

Sim, Aspose.Slides permite exportar PDFs que atendem a vários padrões, incluindo PDF/A1a, PDF/A1b e PDF/UA, garantindo que seus documentos cumpram requisitos de acessibilidade e arquivamento.

## **Recursos Adicionais**

- [Documentação Aspose.Slides for C++](/slides/pt/cpp/)
- [Referência da API Aspose.Slides for C++](https://reference.aspose.com/slides/pt/cpp/)
- [Conversores Online Gratuitos da Aspose](https://products.aspose.app/slides/pt/conversion)