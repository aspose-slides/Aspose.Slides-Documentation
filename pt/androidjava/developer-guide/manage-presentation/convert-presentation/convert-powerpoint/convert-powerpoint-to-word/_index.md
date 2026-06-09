---
title: Converter apresentações PowerPoint para documentos Word no Android
linktitle: PowerPoint para Word
type: docs
weight: 110
url: /pt/androidjava/convert-powerpoint-to-word/
keywords:
- converter PowerPoint
- converter apresentação
- converter slide
- converter PPT
- converter PPTX
- PowerPoint para Word
- apresentação para Word
- slide para Word
- PPT para Word
- PPTX para Word
- PowerPoint para DOCX
- apresentação para DOCX
- slide para DOCX
- PPT para DOCX
- PPTX para DOCX
- PowerPoint para DOC
- apresentação para DOC
- slide para DOC
- PPT para DOC
- PPTX para DOC
- salvar PPT como DOCX
- salvar PPTX como DOCX
- exportar PPT para DOCX
- exportar PPTX para DOCX
- Android
- Java
- Aspose.Slides
description: "Converter slides PowerPoint PPT e PPTX em documentos Word editáveis em Java usando Aspose.Slides para Android com layout preciso, imagens e formatação preservados."
---
## **Visão geral**

Este artigo fornece uma solução para desenvolvedores sobre a conversão de apresentações PowerPoint e OpenDocument para documentos Word usando Aspose.Slides e Aspose.Words. O guia passo a passo orienta você em cada etapa do processo de conversão.

## **Aspose.Slides e Aspose.Words**

Para converter um arquivo PowerPoint (PPTX ou PPT) para Word (DOCX ou DOCX), você precisa tanto do [Aspose.Slides for Android via Java](https://products.aspose.com/slides/pt/androidjava/) quanto do [Aspose.Words for Android via Java](https://products.aspose.com/words/android-java/).

Como uma API autônoma, o [Aspose.Slides](https://products.aspose.app/slides) para java fornece funções que permitem extrair textos de apresentações. 

[Aspose.Words](https://docs.aspose.com/words/androidjava/) é uma API avançada de processamento de documentos que permite que aplicativos gerem, modifiquem, convertam, renderizem, imprimam arquivos e executem outras tarefas com documentos sem utilizar o Microsoft Word.

## **Converter PowerPoint para Word**

1. Baixe as bibliotecas [Aspose.Slides for Android via Java](https://downloads.aspose.com/slides/pt/java) e [Aspose.Words for Java](https://downloads.aspose.com/words/java).
2. Adicione *aspose-slides-x.x-jdk16.jar* e *aspose-words-x.x-jdk16.jar* ao seu CLASSPATH.
3. Use este trecho de código para converter o PowerPoint em Word:

```java
Presentation pres = new Presentation("sample.pptx");

Document doc = new Document();
DocumentBuilder builder = new DocumentBuilder(doc);

for (ISlide slide : pres.getSlides()) {
    // gera uma imagem do slide como um fluxo de bytes
    IImage image = slide.getImage(1, 1);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();
    image.save(imageStream, ImageFormat.Png);
    image.dispose();

    builder.insertImage(imageStream.toByteArray());

    // insere os textos do slide
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof AutoShape) {
            builder.writeln(((AutoShape) shape).getTextFrame().getText());
        }
    }

    builder.insertBreak(BreakType.PAGE_BREAK);
}

doc.save("output.docx");
pres.dispose();
```

## **FAQ**

**Quais componentes precisam ser instalados para converter apresentações PowerPoint e OpenDocument em documentos Word?**

Você só precisa adicionar o respectivo pacote do [Aspose.Slides for Android via Java](https://releases.aspose.com/slides/pt/androidjava/) e do [Aspose.Words for Android via Java](https://releases.aspose.com/words/androidjava/) ao seu projeto. Ambas as bibliotecas funcionam como APIs autônomas, e não há necessidade de instalar o Microsoft Office.

**Todos os formatos de apresentações PowerPoint e OpenDocument são suportados?**

Aspose.Slides [suporta todos os formatos de apresentação](/slides/pt/androidjava/supported-file-formats/), incluindo PPT, PPTX, ODP e outros tipos de arquivo comuns. Isso garante que você possa trabalhar com apresentações criadas em várias versões do Microsoft PowerPoint.