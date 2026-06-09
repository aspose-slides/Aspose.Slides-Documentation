---
title: Converter Apresentações PowerPoint em PDF com Anotações no Android
linktitle: PowerPoint para PDF com Anotações
type: docs
weight: 50
url: /pt/androidjava/convert-powerpoint-to-pdf-with-notes/
keywords:
- converter PowerPoint
- converter apresentação
- converter slide
- converter PPT
- converter PPTX
- PowerPoint para PDF
- apresentação para PDF
- slide para PDF
- PPT para PDF
- PPTX para PDF
- salvar apresentação como PDF
- salvar PPT como PDF
- salvar PPTX como PDF
- exportar PPT para PDF
- exportar PPTX para PDF
- anotações do apresentador
- PDF com anotações
- Android
- Java
- Aspose.Slides
description: "Converta formatos PPT e PPTX para PDF com anotações usando Aspose.Slides para Android via Java. Preserve layouts e anotações do apresentador para apresentações profissionais."
---
## **Visão geral**

Neste artigo, você aprenderá como converter apresentações do PowerPoint para o formato PDF com anotações do apresentador usando o Aspose.Slides. Este guia abordará as etapas necessárias e fornecerá exemplos de código para ajudá‑lo a concluir esta tarefa de forma eficiente. Ao final deste artigo, você será capaz de:

- Implementar o processo de conversão para transformar slides do PowerPoint em documentos PDF preservando as anotações do apresentador.
- Personalizar o PDF de saída para garantir que as anotações do apresentador sejam incluídas e formatadas de acordo com seus requisitos.

## **Converter PowerPoint para PDF com Anotações**

O método `save` na classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/) pode ser usado para converter uma apresentação PPT ou PPTX em PDF com anotações do apresentador. Com o Aspose.Slides, você simplesmente carrega a apresentação, configura as opções de layout usando a classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/notescommentslayoutingoptions/) para incluir as anotações do apresentador e, em seguida, salva o arquivo como PDF. O trecho de código a seguir demonstra como converter uma apresentação de exemplo para PDF na visualização de Slides de Anotações.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
	// Configurar opções de PDF para renderizar anotações do apresentador.
	NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
	notesOptions.setNotesPosition(NotesPositions.BottomFull); // Renderizar anotações do apresentador abaixo do slide.

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(notesOptions);

	// Salvar a apresentação em PDF com anotações do apresentador.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="primary" %}} 
Você pode querer conferir o [Conversor Online de PowerPoint para PDF da Aspose](https://products.aspose.app/slides/pt/conversion). 
{{% /alert %}}