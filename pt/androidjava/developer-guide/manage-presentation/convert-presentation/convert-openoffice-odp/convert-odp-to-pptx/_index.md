---
title: Converter ODP para PPTX no Android
linktitle: ODP para PPTX
type: docs
weight: 10
url: /pt/androidjava/convert-odp-to-pptx/
keywords:
- converter OpenDocument
- converter apresentação
- converter slide
- converter ODP
- OpenDocument para PPTX
- ODP para PPTX
- salvar ODP como PPTX
- exportar ODP para PPTX
- PowerPoint
- OpenDocument
- apresentação
- Android
- Java
- Aspose.Slides
description: "Converta ODP para PPTX com Aspose.Slides para Android. Exemplos de código Java claros, dicas de processamento em lote e resultados de alta qualidade—não é necessário PowerPoint."
---
## **Visão geral**

Este artigo explica como converter uma apresentação ODP para o formato PPTX usando o Aspose.Slides.

## **Converter ODP para Apresentação PPTX/PPT**

O Aspose.Slides para Android via Java oferece a classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation) que representa um arquivo de apresentação. A classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation) agora também pode acessar ODP através do construtor [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation#Presentation-java.lang.String-) quando o objeto é instanciado. O exemplo a seguir mostra como converter uma apresentação ODP em uma apresentação PPTX.

```java
// Abrir o arquivo ODP
Presentation pres = new Presentation("AccessOpenDoc.odp");
try {}
// Salvando a apresentação ODP no formato PPTX
    pres.save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Exemplo ao vivo**

Você pode visitar o aplicativo web [**Aspose.Slides Conversion**](https://products.aspose.app/slides/pt/conversion/), que foi construído com a **Aspose.Slides API**. O aplicativo demonstra como a conversão de ODP para PPTX pode ser implementada com a Aspose.Slides API.

## **Perguntas frequentes**

**Preciso instalar o Microsoft PowerPoint ou o LibreOffice para converter ODP para PPTX?**

Não. O Aspose.Slides funciona de forma independente e não requer aplicativos de terceiros para ler ou gravar ODP/PPTX.

**Os slides mestres, layouts e temas são preservados durante a conversão?**

Sim. A biblioteca usa um modelo de objeto de apresentação completo e mantém a estrutura, incluindo slides mestres e layouts, de modo que o design permanece correto após a conversão.

**Posso converter arquivos ODP protegidos por senha?**

Sim. O Aspose.Slides suporta a detecção de proteção, a abertura e o trabalho com [protected presentations](/slides/pt/androidjava/password-protected-presentation/) (incluindo ODP) quando você fornece a senha, além de configurar criptografia e acesso às propriedades do documento.

**O Aspose.Slides é adequado para serviços de conversão em nuvem ou baseados em REST?**

Sim. Você pode usar a biblioteca local em seu próprio backend ou [Aspose.Slides Cloud](https://products.aspose.cloud/slides/pt/family/) (REST API); ambas as opções suportam a conversão ODP → PPTX.