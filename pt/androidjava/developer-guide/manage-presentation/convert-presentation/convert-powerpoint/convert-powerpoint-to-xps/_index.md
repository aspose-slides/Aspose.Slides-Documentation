---
title: Converter apresentações PowerPoint para XPS no Android
linktitle: PowerPoint para XPS
type: docs
weight: 70
url: /pt/androidjava/convert-powerpoint-to-xps/
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
- Android
- Java
- Aspose.Slides
description: "Converter PowerPoint PPT/PPTX para XPS de alta qualidade e independente de plataforma em Java usando Aspose.Slides para Android. Obtenha guia passo a passo e código de exemplo."
---
## **Visão geral**

Aspose.Slides permite converter apresentações do PowerPoint para XPS salvando um arquivo PPT ou PPTX no formato XPS. Este artigo explica quando o formato XPS pode ser útil e mostra como realizar a conversão com Aspose.Slides usando configurações padrão ou personalizadas [XpsOptions](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/xpsoptions/) .

## **Sobre o XPS**
A Microsoft desenvolveu [XPS](https://docs.fileformat.com/page-description-language/xps/) como uma alternativa ao [PDF](https://docs.fileformat.com/pdf/). Ele permite imprimir conteúdo gerando um arquivo muito semelhante a um PDF. O formato XPS é baseado em XML. O layout ou a estrutura de um arquivo XPS permanece o mesmo em todos os sistemas operacionais e impressoras. 

## **Quando usar o formato XPS da Microsoft**

{{% alert color="primary" %}} 

Para ver como o Aspose.Slides converte apresentações PPT ou PPTX para o formato XPS, você pode conferir [este aplicativo gratuito de conversão online](https://products.aspose.app/slides/pt/conversion). 

{{% /alert %}} 

Se você deseja reduzir custos de armazenamento, pode converter sua apresentação Microsoft PowerPoint para o formato XPS. Desta forma, será mais fácil salvar, compartilhar e imprimir seus documentos. 

Microsoft continua a oferecer forte suporte ao XPS no Windows (até mesmo no Windows 10), portanto você pode considerar salvar arquivos nesse formato. Se você está lidando com Windows 8.1, Windows 8, Windows 7 e Windows Vista, então o XPS pode realmente ser sua melhor opção para certas operações. 

- **Windows 8** usa o formato OXPS (Open XPS) para arquivos XPS. OXPS é uma versão padronizada do formato XPS original. O Windows 8 oferece melhor suporte para arquivos XPS do que para arquivos PDF. 
  - **XPS:** Visualizador/leitor XPS integrado e recurso de impressão para XPS disponível. 
  - **PDF**: Leitor PDF disponível, mas sem recurso de impressão para PDF. 

- **Windows 7 e Windows Vista** usam o formato XPS original. Esses sistemas operacionais também oferecem melhor suporte para arquivos XPS do que para PDFs. 
  - **XPS**: Visualizador XPS integrado e recurso de impressão para XPS disponível. 
  - **PDF**: Sem leitor PDF. Sem recurso de impressão para PDF. 

|<p>**Entrada PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Saída XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

A Microsoft acabou implementando suporte a operações de impressão em PDF através do recurso Imprimir em PDF no Windows 10. Anteriormente, os usuários eram instruídos a imprimir documentos através do formato XPS. 

## **Conversão XPS com Aspose.Slides**

No [**Aspose.Slides**](https://products.aspose.com/slides/pt/androidjava/) para Java, você pode usar o método [**Save**](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) exposto pela classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation) para converter toda a apresentação em um documento XPS.

Ao converter uma apresentação para XPS, você deve salvar a apresentação usando uma destas configurações:

- Configurações padrão (sem [**XPSOptions**](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/xpsoptions))
- Configurações personalizadas (com [**XPSOptions**](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/xpsoptions))

### **Converter apresentações para XPS usando configurações padrão**

Este código de exemplo em Java mostra como converter uma apresentação para um documento XPS usando configurações padrão:

```java
// Instanciar um objeto Presentation que representa um arquivo de apresentação
Presentation pres = new Presentation("Convert_XPS.pptx");
try {
    // Salvar a apresentação em documento XPS
    pres.save("XPS_Output_Without_XPSOption.xps", SaveFormat.Xps);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Converter apresentações para XPS usando configurações personalizadas**
Este código de exemplo mostra como converter uma apresentação para um documento XPS usando configurações personalizadas em Java:

```java
// Instanciar um objeto Presentation que representa um arquivo de apresentação
Presentation pres = new Presentation("Convert_XPS_Options.pptx");
try {
    // Instanciar a classe TiffOptions
    XpsOptions options = new XpsOptions();

    // Salvar Metafiles como PNG
    options.setSaveMetafilesAsPng(true);

    // Salvar a apresentação em documento XPS
    pres.save("XPS_Output_With_Options.xps", SaveFormat.Xps, options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Perguntas frequentes**

**Posso salvar em XPS em um fluxo em vez de um arquivo?**

Sim—Aspose.Slides permite exportar diretamente para um fluxo, o que é ideal para APIs web, pipelines do lado do servidor ou qualquer cenário em que você deseje enviar o XPS sem tocar no sistema de arquivos.

**Os slides ocultos são transferidos para o XPS e posso excluí‑los?**

Por padrão, somente os slides regulares (visíveis) são renderizados. Você pode [incluir ou excluir slides ocultos](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/xpsoptions/#setShowHiddenSlides-boolean-) através das [configurações de exportação](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/xpsoptions/) antes de salvar em XPS, garantindo que a saída contenha exatamente as páginas desejadas.