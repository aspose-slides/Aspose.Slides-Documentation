---
title: Converter apresentações do PowerPoint para XPS em Python
linktitle: PowerPoint para XPS
type: docs
weight: 70
url: /pt/python-net/convert-powerpoint-to-xps/
keywords:
- converter PowerPoint
- converter apresentação
- PowerPoint para XPS
- apresentação para XPS
- PPT para XPS
- PPTX para XPS
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Converter PPT/PPTX do PowerPoint em XPS de alta qualidade e independente de plataforma em Python usando Aspose.Slides. Obtenha um guia passo a passo e código de exemplo."
---
## **Visão geral**

Aspose.Slides permite converter apresentações do PowerPoint para XPS ao salvar um arquivo PPT ou PPTX no formato XPS. Este artigo explica quando o formato XPS pode ser útil e mostra como realizar a conversão com Aspose.Slides usando as configurações padrão ou configurações personalizadas do [XpsOptions](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/xpsoptions/) .

## **Sobre o XPS**
Microsoft desenvolveu o [XPS](https://docs.fileformat.com/page-description-language/xps/) como uma alternativa ao [PDF](https://docs.fileformat.com/pdf/). Ele permite imprimir conteúdo ao gerar um arquivo muito semelhante a um PDF. O formato XPS baseia‑se em XML. O layout ou a estrutura de um arquivo XPS permanece o mesmo em todos os sistemas operacionais e impressoras. 

## Quando usar o formato XPS da Microsoft

{{% alert color="primary" %}} 

Para ver como o Aspose.Slides converte apresentações PPT ou PPTX para o formato XPS, você pode conferir [este aplicativo de conversão online gratuito](https://products.aspose.app/slides/pt/conversion). 

{{% /alert %}} 

Se você deseja reduzir custos de armazenamento, pode converter sua apresentação do Microsoft PowerPoint para o formato XPS. Dessa forma, será mais fácil salvar, compartilhar e imprimir seus documentos. 

A Microsoft continua implementando forte suporte ao XPS no Windows (até mesmo no Windows 10), portanto você pode considerar salvar arquivos nesse formato. Se você estiver usando o Windows 8.1, Windows 8, Windows 7 e Windows Vista, o XPS pode realmente ser sua melhor opção para certas operações. 

- **Windows 8** usa o formato OXPS (Open XPS) para arquivos XPS. O OXPS é uma versão padronizada do formato XPS original. O Windows 8 oferece melhor suporte a arquivos XPS do que a arquivos PDF. 
  - **XPS:** Visualizador/leitor XPS integrado e recurso de impressão para XPS disponíveis. 
  - **PDF**: Leitor de PDF disponível, mas sem recurso de impressão para PDF. 

- **Windows 7 e Windows Vista** usam o formato XPS original. Esses sistemas operacionais também oferecem melhor suporte a arquivos XPS do que a PDFs. 
  - **XPS**: Visualizador XPS integrado e recurso de impressão para XPS disponíveis. 
  - **PDF**: Nenhum leitor de PDF. Nenhum recurso de impressão para PDF. 

|<p>**Entrada PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Saída XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

A Microsoft acabou implementando suporte a operações de impressão em PDF por meio do recurso Imprimir para PDF no Windows 10. Anteriormente, os usuários eram orientados a imprimir documentos através do formato XPS. 

## Conversão XPS com Aspose.Slides

No [**Aspose.Slides**](https://products.aspose.com/slides/pt/python-net/) para .NET, você pode usar o método [**Save**](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) exposto pela classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) para converter toda a apresentação em um documento XPS. 

Ao converter uma apresentação para XPS, você deve salvar a apresentação usando uma destas configurações:

- Configurações padrão (sem [**XPSOptions**](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/xpsoptions/))
- Configurações personalizadas (com [**XPSOptions**](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/xpsoptions/))

### **Convertendo apresentações para XPS usando configurações padrão**

Este código de exemplo em Python mostra como converter uma apresentação para um documento XPS usando as configurações padrão:

```py
import aspose.slides as slides

# Instanciar um objeto Presentation que representa um arquivo de apresentação
pres = slides.Presentation("Convert_XPS.pptx")

# Salvando a apresentação em documento XPS
pres.save("XPS_Output_Without_XPSOption_out.xps", slides.export.SaveFormat.XPS)
```

### **Convertendo apresentações para XPS usando configurações personalizadas**
Este código de exemplo mostra como converter uma apresentação para um documento XPS usando configurações personalizadas em Python:

```py
import aspose.slides as slides

# Instanciar um objeto Presentation que representa um arquivo de apresentação
pres = slides.Presentation("Convert_XPS_Options.pptx")

# Instanciar a classe TiffOptions
options = slides.export.XpsOptions()

# Salvar MetaFiles como PNG
options.save_metafiles_as_png = True

# Salvar a apresentação em documento XPS
pres.save("XPS_With_Options_out.xps", slides.export.SaveFormat.XPS, options)
```

## **FAQ**

**Posso salvar em XPS em um stream em vez de um arquivo?**

Sim—Aspose.Slides permite exportar diretamente para um stream, o que é ideal para APIs web, pipelines do lado do servidor ou qualquer cenário em que você queira enviar o XPS sem tocar no sistema de arquivos.

**Slides ocultos são incluídos no XPS e posso excluí‑los?**

Por padrão, apenas slides regulares (visíveis) são renderizados. Você pode [incluir ou excluir slides ocultos](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/xpsoptions/show_hidden_slides/) através das [configurações de exportação](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/xpsoptions/) antes de salvar em XPS, garantindo que a saída contenha exatamente as páginas que você pretende.