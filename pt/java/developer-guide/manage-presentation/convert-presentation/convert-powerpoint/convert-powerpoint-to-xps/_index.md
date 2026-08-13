---
title: Converter apresentações do PowerPoint para XPS em Java
linktitle: PowerPoint para XPS
type: docs
weight: 70
url: /pt/java/convert-powerpoint-to-xps/
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
- Java
- Aspose.Slides
description: "Converter PowerPoint PPT/PPTX para XPS de alta qualidade e independente de plataforma em Java usando Aspose.Slides. Obtenha um guia passo a passo e código de exemplo."
---
## **Visão geral**

Aspose.Slides permite converter apresentações do PowerPoint para XPS salvando um arquivo PPT ou PPTX no formato XPS. Este artigo explica quando o formato XPS pode ser útil e mostra como realizar a conversão com Aspose.Slides usando as configurações padrão ou personalizadas [XpsOptions](https://reference.aspose.com/slides/pt/java/com.aspose.slides/xpsoptions/) .

## **Sobre XPS**
Microsoft desenvolveu [XPS](https://docs.fileformat.com/page-description-language/xps/) como uma alternativa ao [PDF](https://docs.fileformat.com/pdf/). Ele permite imprimir conteúdo gerando um arquivo muito semelhante a um PDF. O formato XPS é baseado em XML. O layout ou a estrutura de um arquivo XPS permanece o mesmo em todos os sistemas operacionais e impressoras. 

## **Quando usar o formato Microsoft XPS**

{{% alert color="info" %}} 

Para ver como o Aspose.Slides converte apresentações PPT ou PPTX para o formato XPS, você pode conferir [este aplicativo gratuito de conversão online](https://products.aspose.app/slides/pt/conversion). 

{{% /alert %}} 

Se você deseja reduzir custos de armazenamento, pode converter sua apresentação Microsoft PowerPoint para o formato XPS. Dessa forma, será mais fácil salvar, compartilhar e imprimir seus documentos. 

A Microsoft continua implementando suporte robusto para XPS no Windows (mesmo no Windows 10), portanto você pode considerar salvar arquivos nesse formato. Se você trabalha com Windows 8.1, Windows 8, Windows 7 e Windows Vista, o XPS pode ser sua melhor opção para determinadas operações. 

- **Windows 8** usa o formato OXPS (Open XPS) para arquivos XPS. OXPS é uma versão padronizada do formato XPS original. O Windows 8 oferece melhor suporte para arquivos XPS do que para arquivos PDF. 
  - **XPS:** Visualizador/leitor XPS embutido e recurso de impressão para XPS disponível. 
  - **PDF:** Leitor PDF disponível, mas sem recurso de impressão para PDF. 

- **Windows 7 e Windows Vista** usam o formato XPS original. Esses sistemas operacionais também fornecem melhor suporte para arquivos XPS do que para PDFs. 
  - **XPS:** Visualizador XPS embutido e recurso de impressão para XPS disponível. 
  - **PDF:** Nenhum leitor PDF. Nenhum recurso de impressão para PDF. 

|<p>**Entrada PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Saída XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

A Microsoft acabou implementando suporte para operações de impressão em PDF através do recurso Imprimir para PDF no Windows 10. Anteriormente, os usuários eram instruídos a imprimir documentos por meio do formato XPS. 

## **Conversão XPS com Aspose.Slides**

No [**Aspose.Slides**](https://products.aspose.com/slides/pt/java/) para Java, você pode usar o método [**Save**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) exposto pela classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation) para converter a apresentação inteira em um documento XPS. 

Ao converter uma apresentação para XPS, você deve salvá‑la usando uma destas configurações:

- Configurações padrão (sem [**XPSOptions**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/xpsoptions))
- Configurações personalizadas (com [**XPSOptions**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/xpsoptions))

### **Converter apresentações para XPS usando Configurações Padrão**

Este código de exemplo em Java mostra como converter uma apresentação em um documento XPS usando as configurações padrão:

```java
import com.aspose.slides.*;

// Instanciar um objeto Presentation que representa um arquivo de apresentação
Presentation pres = new Presentation("Convert_XPS.pptx");
try {
    // Salvando a apresentação em documento XPS
    pres.save("XPS_Output_Without_XPSOption.xps", SaveFormat.Xps);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Converter apresentações para XPS usando Configurações Personalizadas**
Este código de exemplo mostra como converter uma apresentação em um documento XPS usando configurações personalizadas em Java:

```java
import com.aspose.slides.*;

// Instanciar um objeto Presentation que representa um arquivo de apresentação
Presentation pres = new Presentation("Convert_XPS_Options.pptx");
try {
    // Instanciar a classe XpsOptions
    XpsOptions options = new XpsOptions();

    // Salvar MetaFiles como PNG
    options.setSaveMetafilesAsPng(true);

    // Salvar a apresentação em documento XPS
    pres.save("XPS_Output_With_Options.xps", SaveFormat.Xps, options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Perguntas frequentes**

### Posso salvar em XPS em um fluxo em vez de um arquivo?

Sim—Aspose.Slides permite exportar diretamente para um fluxo, o que é ideal para APIs web, pipelines do lado do servidor ou qualquer cenário em que você queira enviar o XPS sem tocar no sistema de arquivos.

### Slides ocultas são transferidas para XPS e posso excluí‑las?

Por padrão, apenas slides regulares (visíveis) são renderizados. Você pode [incluir ou excluir slides ocultas](https://reference.aspose.com/slides/pt/java/com.aspose.slides/xpsoptions/#setShowHiddenSlides-boolean-) através das [configurações de exportação](https://reference.aspose.com/slides/pt/java/com.aspose.slides/xpsoptions/) antes de salvar em XPS, garantindo que a saída contenha exatamente as páginas desejadas.