---
title: Converter apresentações PowerPoint para XPS em JavaScript
linktitle: PowerPoint para XPS
type: docs
weight: 70
url: /pt/nodejs-java/convert-powerpoint-to-xps/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Converter PowerPoint PPT/PPTX para XPS de alta qualidade e independente de plataforma em JavaScript usando Aspose.Slides para Node.js. Obtenha guia passo a passo e código de exemplo."
---
## **Visão Geral**

Aspose.Slides permite converter apresentações do PowerPoint para XPS salvando um arquivo PPT ou PPTX no formato XPS. Este artigo explica quando o formato XPS pode ser útil e mostra como realizar a conversão com Aspose.Slides usando as configurações padrão ou configurações personalizadas de [**XpsOptions**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/xpsoptions/).

## **Sobre XPS**

A Microsoft desenvolveu o [XPS](https://docs.fileformat.com/page-description-language/xps/) como alternativa ao [PDF](https://docs.fileformat.com/pdf/). Ele permite imprimir conteúdo gerando um arquivo muito semelhante a um PDF. O formato XPS é baseado em XML. O layout ou a estrutura de um arquivo XPS permanece o mesmo em todos os sistemas operacionais e impressoras. 

## **Quando usar o formato XPS da Microsoft**

{{% alert color="primary" %}} 

Para ver como o Aspose.Slides converte apresentações PPT ou PPTX para o formato XPS, você pode conferir [este aplicativo gratuito de conversão online](https://products.aspose.app/slides/pt/conversion). 

{{% /alert %}} 

Se você quiser reduzir os custos de armazenamento, pode converter sua apresentação Microsoft PowerPoint para o formato XPS. Dessa forma, será mais fácil salvar, compartilhar e imprimir seus documentos. 

A Microsoft continua a oferecer suporte robusto ao XPS no Windows (até mesmo no Windows 10), portanto você pode considerar salvar arquivos nesse formato. Se você trabalha com Windows 8.1, Windows 8, Windows 7 ou Windows Vista, o XPS pode ser a melhor opção para determinadas operações. 

- **Windows 8** usa o formato OXPS (Open XPS) para arquivos XPS. OXPS é uma versão padronizada do formato XPS original. O Windows 8 oferece melhor suporte para arquivos XPS do que para arquivos PDF. 
  - **XPS:** Visualizador/leitor XPS interno e recurso de impressão para XPS disponíveis. 
  - **PDF:** Leitor PDF disponível, mas sem recurso de impressão para PDF. 

- **Windows 7** e **Windows Vista** usam o formato XPS original. Esses sistemas operacionais também oferecem melhor suporte para arquivos XPS do que para PDFs. 
  - **XPS:** Visualizador XPS interno e recurso de impressão para XPS disponíveis. 
  - **PDF:** Nenhum leitor PDF. Nenhum recurso de impressão para PDF. 

|<p>**Entrada PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Saída XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

A Microsoft acabou implementando suporte para operações de impressão em PDF através do recurso Imprimir para PDF no Windows 10. Anteriormente, os usuários eram orientados a imprimir documentos pelo formato XPS. 

## **Conversão XPS com Aspose.Slides**

Em [**Aspose.Slides para Node.js via Java**](https://products.aspose.com/slides/pt/nodejs-java/), você pode usar o método [**save**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) exposto pela classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation) para converter toda a apresentação em um documento XPS.

Ao converter uma apresentação para XPS, você deve salvar a apresentação usando uma destas configurações:

- Configurações padrão (sem [**XPSOptions**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/xpsoptions))
- Configurações personalizadas (com [**XPSOptions**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/xpsoptions))

### **Convertendo apresentações para XPS usando configurações padrão**

Este código de exemplo em JavaScript mostra como converter uma apresentação para um documento XPS usando as configurações padrão:

```javascript
// Instanciar um objeto Presentation que representa um arquivo de apresentação
var pres = new aspose.slides.Presentation("Convert_XPS.pptx");
try {
    // Salvando a apresentação em documento XPS
    pres.save("XPS_Output_Without_XPSOption.xps", aspose.slides.SaveFormat.Xps);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Convertendo apresentações para XPS usando configurações personalizadas**

Este código de exemplo mostra como converter uma apresentação para um documento XPS usando configurações personalizadas em JavaScript:

```javascript
// Instanciar um objeto Presentation que representa um arquivo de apresentação
var pres = new aspose.slides.Presentation("Convert_XPS_Options.pptx");
try {
    // Instanciar a classe TiffOptions
    var options = new aspose.slides.XpsOptions();
    // Salvar MetaFiles como PNG
    options.setSaveMetafilesAsPng(true);
    // Salvar a apresentação em documento XPS
    pres.save("XPS_Output_With_Options.xps", aspose.slides.SaveFormat.Xps, options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Posso salvar em XPS em um stream em vez de um arquivo?**

Sim—Aspose.Slides permite exportar diretamente para um stream, o que é ideal para APIs web, pipelines server‑side ou qualquer cenário em que você deseje enviar o XPS sem tocar no sistema de arquivos.

**Slides ocultos são incluídos no XPS e posso excluí‑los?**

Por padrão, apenas slides regulares (visíveis) são renderizados. Você pode [incluir ou excluir slides ocultos](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/xpsoptions/setshowhiddenslides/) através das [configurações de exportação](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/xpsoptions/) antes de salvar em XPS, garantindo que a saída contenha exatamente as páginas desejadas.