---
title: Converter apresentações PowerPoint para XPS em C++
linktitle: PowerPoint para XPS
type: docs
weight: 70
url: /pt/cpp/convert-powerpoint-to-xps
keywords:
- converter PowerPoint
- converter apresentação
- converter slide
- converter PPT
- converter PPTX
- PowerPoint para XPS
- apresentação para XPS
- slide para XPS
- PPT para XPS
- PPTX para XPS
- salvar PPT como XPS
- salvar PPTX como XPS
- exportar PPT para XPS
- exportar PPTX para XPS
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Converter PowerPoint PPT/PPTX para XPS de alta qualidade e independente de plataforma em C++ usando Aspose.Slides. Obtenha guia passo a passo e código de exemplo."
---
## **Visão geral**

Aspose.Slides permite converter apresentações do PowerPoint para XPS salvando um arquivo PPT ou PPTX no formato XPS. Este artigo explica quando o formato XPS pode ser útil e mostra como realizar a conversão com Aspose.Slides usando configurações padrão ou personalizadas [XpsOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/xpsoptions/) .

## **Sobre o XPS**
A Microsoft desenvolveu [XPS](https://docs.fileformat.com/page-description-language/xps/) como uma alternativa ao [PDF](https://docs.fileformat.com/pdf/). Ele permite imprimir conteúdo gerando um arquivo muito semelhante a um PDF. O formato XPS é baseado em XML. O layout ou a estrutura de um arquivo XPS permanece o mesmo em todos os sistemas operacionais e impressoras. 

## **Quando usar o formato XPS da Microsoft**

{{% alert color="primary" %}} 

Para ver como o Aspose.Slides converte apresentações PPT ou PPTX para o formato XPS, você pode conferir [este aplicativo gratuito de conversão online](https://products.aspose.app/slides/pt/conversion). 

{{% /alert %}} 

Se você deseja reduzir custos de armazenamento, pode converter sua apresentação Microsoft PowerPoint para o formato XPS. Dessa forma, será mais fácil salvar, compartilhar e imprimir seus documentos. 

A Microsoft continua a oferecer forte suporte ao XPS no Windows (até mesmo no Windows 10), portanto você pode considerar salvar arquivos neste formato. Se você está lidando com Windows 8.1, Windows 8, Windows 7 e Windows Vista, o XPS pode ser realmente a melhor opção para certas operações. 

- **Windows 8** usa o formato OXPS (Open XPS) para arquivos XPS. OXPS é uma versão padronizada do formato XPS original. O Windows 8 oferece melhor suporte a arquivos XPS do que a arquivos PDF. 
  - **XPS:** Visualizador/leitor XPS interno e recurso de impressão para XPS disponível. 
  - **PDF**: Leitor de PDF disponível, mas sem recurso de impressão para PDF. 

- **Windows 7 e Windows Vista** usam o formato XPS original. Esses sistemas operacionais também oferecem melhor suporte a arquivos XPS do que a PDFs. 
  - **XPS**: Visualizador XPS interno e recurso de impressão para XPS disponível. 
  - **PDF**: Nenhum leitor de PDF. Nenhum recurso de impressão para PDF. 

|<p>**Entrada PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Saída XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |



A Microsoft acabou implementando suporte a operações de impressão em PDF por meio do recurso Imprimir em PDF no Windows 10. Anteriormente, os usuários eram direcionados a imprimir documentos pelo formato XPS. 

## **Conversão XPS com Aspose.Slides**

Em [**Aspose.Slides**](https://products.aspose.com/slides/pt/cpp/) para C++, você pode usar o método [**Save**](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) exposto pela classe [Presentation](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation) para converter toda a apresentação em um documento XPS. 

Ao converter uma apresentação para XPS, você deve salvar a apresentação usando uma destas configurações:

- Configurações padrão (sem [**XPSOptions**](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.export.xps_options))
- Configurações personalizadas (com [**XPSOptions**](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.export.xps_options))

### **Converter apresentações para XPS usando configurações padrão**

Este código de exemplo em C++ mostra como converter uma apresentação para um documento XPS usando configurações padrão:

``` cpp
// Instanciar um objeto Presentation que representa um arquivo de apresentação
auto pres = System::MakeObject<Presentation>(u"Convert_XPS.pptx");
// Salvando a apresentação em documento XPS
pres->Save(u"XPS_Output_Without_XPSOption_out.xps", SaveFormat::Xps);
```


### **Converter apresentações para XPS usando configurações personalizadas**
Este código de exemplo mostra como converter uma apresentação para um documento XPS usando configurações personalizadas em C++:

``` cpp
// Instanciar um objeto Presentation que representa um arquivo de apresentação
auto pres = System::MakeObject<Presentation>(u"Convert_XPS_Options.pptx");
// Instanciar a classe TiffOptions
auto options = System::MakeObject<XpsOptions>();

// Salvar arquivos MetaFiles como PNG
options->set_SaveMetafilesAsPng(true);

// Salvar a apresentação em documento XPS
pres->Save(u"XPS_With_Options_out.xps", SaveFormat::Xps, options);
```

## **Perguntas frequentes**

**Posso salvar em XPS em um fluxo ao invés de um arquivo?**

Sim—Aspose.Slides permite exportar diretamente para um fluxo, o que é ideal para APIs web, pipelines no servidor ou qualquer cenário em que você queira enviar o XPS sem tocar no sistema de arquivos.

**Slides ocultos são transferidos para XPS e posso excluí‑los?**

Por padrão, apenas slides regulares (visíveis) são renderizados. Você pode [incluir ou excluir slides ocultos](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/xpsoptions/set_showhiddenslides/) através das [configurações de exportação](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/xpsoptions/) antes de salvar em XPS, garantindo que a saída contenha exatamente as páginas desejadas.