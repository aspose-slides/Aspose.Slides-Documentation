---
title: Converter PPT e PPTX para PDF em JavaScript [Recursos avançados incluídos]
linktitle: PowerPoint para PDF
type: docs
weight: 40
url: /pt/nodejs-java/convert-powerpoint-to-pdf/
keywords:
- converter PowerPoint
- converter apresentação
- PowerPoint para PDF
- apresentação para PDF
- PPT para PDF
- converter PPT para PDF
- PPTX para PDF
- converter PPTX para PDF
- salvar PowerPoint como PDF
- salvar PPT como PDF
- salvar PPTX como PDF
- exportar PPT para PDF
- exportar PPTX para PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- Node.js
- JavaScript
- Aspose.Slides
description: "Converter PowerPoint PPT/PPTX para PDFs de alta qualidade e pesquisáveis usando Aspose.Slides para Node.js, com exemplos de código rápidos e opções avançadas de conversão."
---
## **Visão geral**

Converter apresentações PowerPoint e OpenDocument (PPT, PPTX, ODP, etc.) para formato PDF em JavaScript oferece várias vantagens, incluindo compatibilidade entre diferentes dispositivos e preservação do layout e formatação da sua apresentação. Este guia demonstra como converter apresentações em documentos PDF, usar várias opções para controlar a qualidade da imagem, incluir slides ocultos, proteger PDFs com senha, detectar substituições de fontes, selecionar slides específicos para conversão e aplicar padrões de conformidade aos documentos de saída.

## **Conversões de PowerPoint para PDF**

Usando Aspose.Slides, você pode converter apresentações nos seguintes formatos para PDF:

* **PPT**
* **PPTX**
* **ODP**

Para converter uma apresentação em PDF, passe o nome do arquivo como argumento para a classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/) e então salve a apresentação como PDF usando um método `save`. A classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/) expõe o método `save` que normalmente é usado para converter uma apresentação em PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Node.js via Java insere suas informações de API e número de versão nos documentos de saída. Por exemplo, ao converter uma apresentação para PDF, Aspose.Slides preenche o campo Application com "*Aspose.Slides*" e o campo PDF Producer com um valor no formato "*Aspose.Slides v XX.XX*". **Nota** que você não pode instruir o Aspose.Slides a alterar ou remover estas informações dos documentos de saída.

{{% /alert %}}

Aspose.Slides permite que você converta:

* Apresentações completas para PDF
* Slides específicos de uma apresentação para PDF

Aspose.Slides exporta apresentações para PDF, garantindo que os PDFs resultantes correspondam de perto às apresentações originais. Elementos e atributos são renderizados com precisão na conversão, incluindo:

* Imagens
* Caixas de texto e formas
* Formatação de texto
* Formatação de parágrafo
* Hiperlinks
* Cabeçalhos e rodapés
* Marcadores
* Tabelas

## **Converter PowerPoint para PDF**

O processo padrão de conversão de PowerPoint para PDF usa opções padrão. Nesse caso, Aspose.Slides tenta converter a apresentação fornecida para PDF usando configurações ótimas nos níveis máximos de qualidade.

Este código mostra como converter uma apresentação (PPT, PPTX, ODP, etc.) para PDF:

```js
// Instancie a classe Presentation que representa um arquivo PowerPoint ou OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.ppt");
try {
    // Salve a apresentação como PDF.
    presentation.save("PPT-to-PDF.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{%  alert  color="primary"  %}} 

A Aspose oferece um **conversor gratuito online de PowerPoint para PDF** que demonstra o processo de conversão de apresentação para PDF. Você pode executar um teste com este conversor para uma implementação ao vivo do procedimento descrito aqui.

{{% /alert %}}

## **Converter PowerPoint para PDF com Opções**

Aspose.Slides fornece opções personalizadas — propriedades na classe [PdfOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/pdfoptions/) — que permitem personalizar o PDF resultante, bloquear o PDF com senha ou especificar como o processo de conversão deve prosseguir.

### **Converter PowerPoint para PDF com Opções Personalizadas**

Usando opções de conversão personalizadas, você pode definir sua configuração de qualidade preferida para imagens raster, especificar como metafiles devem ser tratados, definir um nível de compactação para texto, configurar DPI para imagens e muito mais.

O exemplo de código abaixo demonstra como converter uma apresentação PowerPoint para PDF com várias opções personalizadas.

```js
// Instancie a classe PdfOptions.
let pdfOptions = new aspose.slides.PdfOptions();

// Defina a qualidade para imagens JPG.
pdfOptions.setJpegQuality(java.newByte(90));

// Defina DPI para imagens.
pdfOptions.setSufficientResolution(300);

// Defina o comportamento para metafiles.
pdfOptions.setSaveMetafilesAsPng(true);

// Defina o nível de compressão de texto para conteúdo textual.
pdfOptions.setTextCompression(aspose.slides.PdfTextCompression.Flate);

// Defina o modo de conformidade PDF.
pdfOptions.setCompliance(aspose.slides.PdfCompliance.Pdf15);

// Instancie a classe Presentation que representa um arquivo PowerPoint ou OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Salve a apresentação como documento PDF.
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Converter PowerPoint para PDF com Slides Ocultos**

Se uma apresentação contém slides ocultos, você pode usar o método [setShowHiddenSlides](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/PdfOptions#setShowHiddenSlides) da classe [PdfOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/PdfOptions) para incluir os slides ocultos como páginas no PDF resultante.

Este código JavaScript mostra como converter uma apresentação PowerPoint para PDF com slides ocultos incluídos:

```js
// Instancie a classe Presentation que representa um arquivo PowerPoint ou OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Instancie a classe PdfOptions.
    let pdfOptions = new aspose.slides.PdfOptions();

    // Adicione slides ocultos.
    pdfOptions.setShowHiddenSlides(true);

    // Salve a apresentação como PDF.
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Converter PowerPoint para PDF Protegido por Senha**

Este código JavaScript demonstra como converter uma apresentação PowerPoint em um PDF protegido por senha usando os parâmetros de proteção da classe [PdfOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/PdfOptions):

```js
// Instancie a classe Presentation que representa um arquivo PowerPoint ou OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Instancie a classe PdfOptions.
    let pdfOptions = new aspose.slides.PdfOptions();

    // Defina uma senha PDF e permissões de acesso.
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(aspose.slides.PdfAccessPermissions.PrintDocument | aspose.slides.PdfAccessPermissions.HighQualityPrint);

    // Salve a apresentação como PDF.
    presentation.save("PPTX-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Detectar Substituições de Fonte**

Aspose.Slides fornece o método [setWarningCallback](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/saveoptions/#setWarningCallback) na classe [PdfOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/PdfOptions), permitindo detectar substituições de fontes durante o processo de conversão de apresentação para PDF.

Este código JavaScript mostra como detectar substituições de fontes:

```js
// Defina o callback de aviso nas opções PDF.
let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setWarningCallback(FontSubstitutionHandler);

// Instancie a classe Presentation que representa um arquivo PowerPoint ou OpenDocument.
let presentation = new aspose.slides.Presentation("sample.pptx");

// Salve a apresentação como PDF.
presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```
```js
const FontSubstitutionHandler = java.newProxy("com.aspose.slides.IWarningCallback", {
	warning: function (warning) {
		if (warning.getWarningType() === aspose.slides.WarningType.DataLoss) {
			console.warn("Font substitution warning: " + warning.getDescription());
		}
		return aspose.slides.ReturnAction.Continue;
	}
});
```

{{%  alert color="primary"  %}} 

Para mais informações sobre substituição de fontes, consulte o artigo [Substituição de fontes](/slides/pt/nodejs-java/font-substitution/).

{{% /alert %}} 

## **Converter Slides Selecionados de PowerPoint para PDF**

Este código JavaScript demonstra como converter apenas slides específicos de uma apresentação PowerPoint para PDF:

```js
// Instancie a classe Presentation que representa um arquivo PowerPoint ou OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Defina o array de números de slides.
    let slides = java.newArray("int", [1, 3]);

    // Salve a apresentação como PDF.
    presentation.save("PPTX-to-PDF.pdf", slides, aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **Converter PowerPoint para PDF com Tamanho de Slide Personalizado**

Este código JavaScript demonstra como converter uma apresentação PowerPoint para PDF com um tamanho de slide especificado:

```js
const slideWidth = 612;
const slideHeight = 792;

// Instancie a classe Presentation que representa um arquivo PowerPoint ou OpenDocument.
let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");

// Crie uma nova apresentação com tamanho de slide ajustado.
let resizedPresentation = new aspose.slides.Presentation();

try {
    // Defina o tamanho de slide personalizado.
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.EnsureFit);

    // Clone o primeiro slide da apresentação original.
    let slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Salve a apresentação redimensionada em um PDF com notas.
    resizedPresentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Converter PowerPoint para PDF na Visualização de Slides de Notas**

Este código JavaScript demonstra como converter uma apresentação PowerPoint para um PDF que inclui notas:

```js
// Instancie a classe Presentation que representa um arquivo PowerPoint ou OpenDocument.
let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
try {
    // Configure as opções PDF com layout de notas.
    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    let pdfOptions = new aspose.slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // Salve a apresentação em um PDF com notas.
    presentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **Acessibilidade e Padrões de Conformidade para PDF**

Aspose.Slides permite que você use um procedimento de conversão que cumpre as [Diretrizes de Acessibilidade de Conteúdo Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Você pode exportar um documento PowerPoint para PDF usando qualquer um destes padrões de conformidade: **PDF/A1a**, **PDF/A1b** e **PDF/UA**.

Este código JavaScript demonstra um processo de conversão de PowerPoint para PDF que produz múltiplos PDFs baseados em diferentes padrões de conformidade:

```js
let presentation = new aspose.slides.Presentation("pres.pptx");
try {
    let pdfOptions = new aspose.slides.PdfOptions();
    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfA1a);
    presentation.save("pres-a1a-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfA1b);
    presentation.save("pres-a1b-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfUa);
    presentation.save("pres-ua-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 

Aspose.Slides suporta operações de conversão de PDF, permitindo que você converta arquivos PDF para formatos de arquivo populares. Você pode realizar conversões de [PDF para HTML](https://products.aspose.com/slides/pt/nodejs-java/conversion/pdf-to-html/), [PDF para JPG](https://products.aspose.com/slides/pt/nodejs-java/conversion/pdf-to-jpg/), e [PDF para PNG](https://products.aspose.com/slides/pt/nodejs-java/conversion/pdf-to-png/). Outras operações de conversão de PDF para formatos especializados—[PDF para SVG](https://products.aspose.com/slides/pt/nodejs-java/conversion/pdf-to-svg/), [PDF para TIFF](https://products.aspose.com/slides/pt/nodejs-java/conversion/pdf-to-tiff/)—também são suportadas.

{{% /alert %}}

> **Nota:** Ao exportar para PDF/UA, Aspose.Slides trata gráficos complexos como SmartArt, gráficos e fórmulas como uma única figura. Elementos de caminho individuais não são preservados como conteúdo separado e podem ser marcados como artefatos; texto alternativo é fornecido apenas para a figura completa.

## **Perguntas Frequentes**

**Posso converter vários arquivos PowerPoint para PDF em lote?**

Sim, Aspose.Slides suporta conversão em lote de múltiplos arquivos PPT ou PPTX para PDF. Você pode iterar pelos seus arquivos e aplicar o processo de conversão programaticamente.

**É possível proteger o PDF convertido com senha?**

Absolutamente. Use a classe [PdfOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/PdfOptions) para definir uma senha e especificar permissões de acesso durante o processo de conversão.

**Como incluo slides ocultos no PDF?**

Use o método `setShowHiddenSlides` na classe [PdfOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/PdfOptions) para incluir slides ocultos no PDF resultante.

**O Aspose.Slides pode manter alta qualidade de imagem no PDF?**

Sim, você pode controlar a qualidade da imagem usando métodos como `setJpegQuality` e `setSufficientResolution` na classe [PdfOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/PdfOptions) para garantir imagens de alta qualidade no seu PDF.

**O Aspose.Slides suporta padrões de conformidade PDF/A?**

Sim, Aspose.Slides permite exportar PDFs que cumprem diversos padrões, incluindo PDF/A1a, PDF/A1b e PDF/UA, garantindo que seus documentos atendam aos requisitos de acessibilidade e arquivamento.

## **Recursos Adicionais**

- [Aspose.Slides para Node.js via Java Documentação](/slides/pt/nodejs-java/)
- [Aspose.Slides para Node.js via Java Referência de API](https://reference.aspose.com/slides/pt/nodejs-java/)
- [Conversores Online Gratuitos da Aspose](https://products.aspose.app/slides/pt/conversion)