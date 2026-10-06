---
title: Converter apresentações do PowerPoint para PDF com notas no Android
linktitle: PowerPoint para PDF com notas
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
- PDF com notas
- Android
- Java
- Aspose.Slides
description: "Converter formatos PPT e PPTX para PDF com notas usando Aspose.Slides para Android via Java. Preservar layouts e anotações do apresentador para apresentações profissionais."
---
## **Visão geral**

Neste artigo, você aprenderá como converter apresentações do PowerPoint para o formato PDF com anotações do apresentador usando Aspose.Slides. Este guia abordará as etapas necessárias e fornecerá exemplos de código para ajudá-lo a concluir essa tarefa de forma eficiente. Ao final deste artigo, você será capaz de:

- Implementar o processo de conversão para transformar slides do PowerPoint em documentos PDF preservando as anotações do apresentador.
- Personalizar o PDF de saída para garantir que as anotações do apresentador sejam incluídas e formatadas de acordo com seus requisitos.

Para definir as dimensões e a orientação da página de notas antes da exportação, veja [Tamanho da página de notas](/slides/pt/androidjava/notes-size/).

## **Converter PowerPoint para PDF com notas**

O método `save` na classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/) pode ser usado para converter uma apresentação PPT ou PPTX em PDF com anotações do apresentador. Com Aspose.Slides, você simplesmente carrega a apresentação, configura as opções de layout usando a classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/notescommentslayoutingoptions/) para incluir as anotações do apresentador e, em seguida, salva o arquivo como PDF. O trecho de código a seguir demonstra como converter uma apresentação de exemplo para PDF na visualização de Slides de Notas.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
	// Configurar opções PDF para renderizar as notas do apresentador.
	NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
	notesOptions.setNotesPosition(NotesPositions.BottomFull); // Renderizar notas do apresentador abaixo do slide.

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(notesOptions);

	// Salvar a apresentação em PDF com notas do apresentador.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Você pode querer conferir o Aspose [Conversor online de PowerPoint para PDF](https://products.aspose.app/slides/pt/conversion).
{{% /alert %}}