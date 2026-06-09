---
title: Formatar Texto usando VSTO e Aspose.Slides para Java
linktitle: Formatar Texto
type: docs
weight: 30
url: /pt/java/format-text-using-vsto-and-aspose-slides-for-java/
keywords:
- formatar texto
- migração
- VSTO
- automação Office
- PowerPoint
- apresentação
- Java
- Aspose.Slides
description: "Migre da automação Microsoft Office para Aspose.Slides for Java e formate texto em apresentações PowerPoint (PPT, PPTX) com controle preciso."
---
{{% alert color="primary" %}} 

Às vezes, você precisa formatar o texto em slides programaticamente. Este artigo mostra como ler uma apresentação de exemplo com algum texto no primeiro slide usando [VSTO](/slides/pt/java/format-text-using-vsto-and-aspose-slides-for-java/) e [Aspose.Slides for Java](/slides/pt/java/format-text-using-vsto-and-aspose-slides-for-java/). O código formata o texto na terceira caixa de texto do slide para que fique igual ao texto na última caixa de texto.

{{% /alert %}} 
## **Formatando Texto**
Both the VSTO and Aspose.Slides methods take the following steps:

1. Abra a apresentação de origem.
1. Acesse o primeiro slide.
1. Acesse a terceira caixa de texto.
1. Altere a formatação do texto na terceira caixa de texto.
1. Salve a apresentação no disco.

As capturas de tela abaixo mostram o slide de exemplo antes e depois da execução do código VSTO e Aspose.Slides for Java.

**A apresentação de entrada** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_1.png)
### **Exemplo de Código VSTO**
O código abaixo mostra como reformatar o texto em um slide usando VSTO.

**O texto reformatado com VSTO** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_2.png)

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-FormatTextUsingVSTO-FormatTextUsingVSTO.cs" >}}


### **Exemplo de Aspose.Slides for Java**
Para formatar texto com Aspose.Slides, adicione a fonte antes de formatar o texto.

**A apresentação de saída criada com Aspose.Slides** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_3.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-FormatText-FormatText.java" >}}