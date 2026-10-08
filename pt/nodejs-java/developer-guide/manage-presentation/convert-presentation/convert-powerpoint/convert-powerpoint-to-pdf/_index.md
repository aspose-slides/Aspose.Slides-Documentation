---
title: Converter PPT e PPTX para PDF em JavaScript [Recursos Avançados Incluídos]
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
- anexo
- PDF/A1a
- PDF/A1b
- PDF/UA
- Node.js
- JavaScript
- Aspose.Slides
description: "Converter PowerPoint PPT/PPTX para PDFs de alta qualidade e pesquisáveis usando Aspose.Slides para Node.js, com exemplos de código rápidos e opções avançadas de conversão."
---
## **Visão geral**

Converter apresentações PowerPoint e OpenDocument (PPT, PPTX, ODP etc.) para PDF em JavaScript oferece diversas vantagens, incluindo compatibilidade em diferentes dispositivos e preservação do layout e da formatação da sua apresentação. Este guia demonstra como converter apresentações para documentos PDF, usar várias opções para controlar a qualidade de imagem, incluir slides ocultos, proteger PDFs com senha, detectar substituições de fontes, selecionar slides específicos para conversão e aplicar padrões de conformidade aos documentos de saída.

## **Conversões de PowerPoint para PDF**

Usando Aspose.Slides, você pode converter apresentações nos seguintes formatos para PDF:

* **PPT**
* **PPTX**
* **ODP**

Para converter uma apresentação para PDF, passe o nome do arquivo como argumento para a classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) e então salve a apresentação como PDF usando o método [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/). A classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) expõe o método [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/) que normalmente é usado para converter uma apresentação para PDF.

{{% alert color="info" title="Note" %}}

Aspose.Slides for Node.js via Java insere suas informações de API e número da versão em documentos de saída. Por exemplo, ao converter uma apresentação para PDF, Aspose.Slides preenche o campo Application com "*Aspose.Slides*" e o campo PDF Producer com um valor no formato "*Aspose.Slides v XX.XX*". **Note** que você não pode instruir o Aspose.Slides a alterar ou remover essas informações dos documentos de saída.

{{% /alert %}}

Aspose.Slides permite que você converta:

* Apresentações completas para PDF
* Slides específicos de uma apresentação para PDF

Aspose.Slides exporta apresentações para PDF, garantindo que os PDFs resultantes correspondam de perto às apresentações originais. Elementos e atributos são renderizados com precisão na conversão, incluindo:

* Imagens
* Caixas de texto e formas
* Formatação de texto
* Formatação de parágrafos
* Hiperlinks
* Cabeçalhos e rodapés
* Marcadores
* Tabelas

## **Converter PowerPoint para PDF**

O processo padrão de conversão PowerPoint‑para‑PDF usa opções padrão. Nesse caso, o Aspose.Slides tenta converter a apresentação fornecida para PDF usando configurações ótimas nos níveis máximos de qualidade.

O exemplo a seguir carrega uma apresentação e salva todos os slides visíveis para PDF usando as configurações de exportação padrão.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("PowerPoint.ppt");
try {
    presentation.save("PPT-to-PDF.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}

A Aspose oferece um [**conversor gratuito online PowerPoint para PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) que demonstra o processo de conversão de apresentação para PDF. Você pode fazer um teste com esse conversor para ver a implementação ao vivo do procedimento descrito aqui.

{{% /alert %}}

## **Converter PowerPoint para PDF com Opções**

Aspose.Slides fornece opções personalizadas — propriedades da classe [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) — que permitem personalizar o PDF resultante, proteger o PDF com senha ou especificar como o processo de conversão deve prosseguir.

### **Converter PowerPoint para PDF com Opções Personalizadas**

Usando opções de conversão personalizadas, você pode definir sua configuração de qualidade preferida para imagens rasterizadas, especificar como metafiles devem ser tratados, definir um nível de compressão para texto, configurar DPI para imagens e muito mais.

O exemplo a seguir exporta uma apresentação para PDF 1.5 com qualidade JPEG definida em 90, resolução de imagem em 300 DPI, metafiles salvos como PNG e compressão de texto Flate.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setJpegQuality(java.newByte(90));
pdfOptions.setSufficientResolution(300);
pdfOptions.setSaveMetafilesAsPng(true);
pdfOptions.setTextCompression(aspose.slides.PdfTextCompression.Flate);
pdfOptions.setCompliance(aspose.slides.PdfCompliance.Pdf15);

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Preservar Arquivos OLE Incorporados como Anexos PDF**

Se uma apresentação contiver uma pasta de trabalho Excel incorporada, você pode querer que os destinatários do PDF acessem os dados da planilha além de visualizar os slides. Chame [setIncludeOleData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) com `true` para preservar arquivos OLE incorporados como anexos no PDF resultante.

O valor padrão é `false`: a imagem de visualização ou ícone do objeto OLE é renderizado na página PDF, mas seu arquivo incorporado não é incluído como anexo. Definir a opção como `true` inclui adicionalmente os dados do arquivo. A visualização continua sendo uma representação visual; o anexo permite que os destinatários abram ou salvem o arquivo incorporado separadamente. O objeto OLE não se torna uma planilha Excel interativa na página PDF.

O exemplo a seguir carrega uma apresentação que já contém uma pasta de trabalho Excel incorporada e a exporta para PDF com a planilha anexada.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setIncludeOleData(true);

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Para verificar o resultado:

1. Abra o PDF exportado em um visualizador que suporte anexos de arquivo, como o Adobe Acrobat Reader.
2. Abra o painel **Attachments** do visualizador e localize a pasta de trabalho incorporada.
3. Salve o anexo e abra‑o no Excel para inspecionar os dados, ou abra‑o diretamente se o visualizador permitir. A visualização na página PDF é separada do anexo.

{{% alert color="info" title="Note" %}}

Os padrões PDF/A impõem restrições a anexos: PDF/A‑1 proíbe arquivos incorporados, PDF/A‑2 permite apenas anexos PDF/A e PDF/A‑3 permite outros tipos de arquivo, inclusive pastas de trabalho Excel. Estas são exigências dos padrões, não restrições específicas do Aspose.Slides. Este exemplo usa a configuração padrão de conformidade PDF e não demonstra exportação PDF/A.

{{% /alert %}}

### **Converter PowerPoint para PDF com Slides Ocultos**

Se uma apresentação contiver slides ocultos, você pode usar o método [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/) da classe [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) para incluir os slides ocultos como páginas no PDF resultante.

O exemplo a seguir exporta uma apresentação para PDF, incluindo quaisquer slides ocultos.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setShowHiddenSlides(true);

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Converter PowerPoint para um PDF Protegido por Senha**

O exemplo a seguir exporta uma apresentação para um PDF que requer a senha `password` para ser aberto. As permissões de acesso permitem impressão, inclusive impressão em alta qualidade.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setPassword("password");
pdfOptions.setAccessPermissions(aspose.slides.PdfAccessPermissions.PrintDocument | aspose.slides.PdfAccessPermissions.HighQualityPrint);

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    presentation.save("PPTX-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Detectar Substituições de Fonte**

Aspose.Slides fornece o método [setWarningCallback](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/) da classe [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/), permitindo detectar substituições de fonte durante a conversão de apresentação para PDF.

O exemplo a seguir exporta uma apresentação para PDF e imprime avisos de substituição de fonte no console. Um aviso é impresso somente quando uma fonte indisponível é substituída durante a exportação.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const FontSubstitutionHandler = java.newProxy("com.aspose.slides.IWarningCallback", {
	warning: function (warning) {
		if (warning.getWarningType() === aspose.slides.WarningType.DataLoss && warning.getDescription().startsWith("Font will be substituted")) {
			console.warn("Font substitution warning: " + warning.getDescription());
		}
		return aspose.slides.ReturnAction.Continue;
	}
});

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setWarningCallback(FontSubstitutionHandler);

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}

Para mais informações sobre substituição de fonte, veja o artigo [Font Substitution](/slides/pt/nodejs-java/font-substitution/).

{{% /alert %}} 

### **Tratar Fontes sem Variante Negrito Dedicada**

Uma apresentação pode aplicar formatação negrito a um texto mesmo quando sua fonte não possui variante negrito dedicada. O texto ainda pode aparecer em negrito por meio de negrito sintético, que espessa artificialmente os glifos regulares. Quando esse texto parece muito pesado ou diferente da aparência esperada no PDF, tente chamar [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) com `true`. Esta opção renderiza o texto afetado como bitmap durante a exportação para PDF e pode melhorar sua aparência para certas fontes. Seu valor padrão é `false`.

A apresentação de exemplo contém duas caixas de texto: uma com texto normal e outra com formatação negrito aplicada à mesma fonte, que não possui variante negrito dedicada. O exemplo a seguir carrega a apresentação, habilita a rasterização de estilos de fonte não suportados e a exporta para PDF:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setRasterizeUnsupportedFontStyles(true);

let presentation = new aspose.slides.Presentation("unsupported-bold.pptx");
try {
    presentation.save("rasterized.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

As pré‑visualizações abaixo mostram a saída com a opção desativada e ativada. Neste exemplo, o texto em negrito tem traços mais grossos com a opção desativada. Com a opção ativada, seus traços ficam mais finos; o texto normal permanece inalterado. Compare os resultados antes de escolher a configuração para sua apresentação.

| Opção desativada (`false`, o padrão) | Opção ativada (`true`) |
|---|---|
| ![PDF com rasterização de estilo de fonte não suportado desativada](unsupported-bold-disabled.png) | ![PDF com rasterização de estilo de fonte não suportado ativada](unsupported-bold-enabled.png) |

Neste exemplo, habilitar a opção transforma apenas o texto em negrito em bitmap: ele não pode ser selecionado, copiado ou pesquisado como texto sem OCR, e suas bordas parecem mais suaves em 800 % de zoom. O texto normal continua pesquisável. Com a opção desativada, ambas as cadeias permanecem como texto.

Esta opção rasteriza texto formatado como negrito quando sua fonte não tem variante negrito dedicada. A [substituição de fonte](/slides/pt/nodejs-java/font-substitution/) em vez disso seleciona outra fonte quando a original está indisponível.

## **Converter Slides Selecionados de PowerPoint para PDF**

O exemplo a seguir exporta os slides 1 e 3 de uma apresentação para PDF. Os números dos slides neste array são baseados em 1, e a apresentação de entrada deve conter ao menos três slides.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    let slides = java.newArray("int", [1, 3]);
    presentation.save("PPTX-to-PDF.pdf", slides, aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **Converter PowerPoint para PDF com Tamanho de Slide Personalizado**

O exemplo a seguir copia o primeiro slide de uma apresentação para uma nova apresentação com tamanho de slide de 612 × 792 pontos (8,5 × 11 polegadas). Ele dimensiona o conteúdo do slide para caber e exporta o slide único para PDF.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const slideWidth = 612;
const slideHeight = 792;

let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
let resizedPresentation = new aspose.slides.Presentation();

try {
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.EnsureFit);
    let slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Remova o slide vazio com o qual a nova apresentação foi criada.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Converter PowerPoint para PDF no modo de Notas de Slides**

O exemplo a seguir exporta uma apresentação para PDF, colocando as notas do orador de cada slide abaixo do slide. Use uma apresentação que contenha notas do orador para ver o resultado.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
try {
    presentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **Acessibilidade e Padrões de Conformidade para PDF**

Aspose.Slides permite que você use um procedimento de conversão que esteja em conformidade com as [Diretrizes de Acessibilidade para Conteúdo Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Você pode exportar um documento PowerPoint para PDF usando qualquer um destes padrões de conformidade: **PDF/A1a**, **PDF/A1b** e **PDF/UA**.

Este código demonstra um processo de conversão PowerPoint‑para‑PDF que produz múltiplos PDFs baseados em diferentes padrões de conformidade:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

{{% alert color="info" title="Note" %}}

Aspose.Slides suporta operações de conversão de PDF, permitindo que você converta arquivos PDF para formatos populares. Você pode executar conversões de [PDF para HTML](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-html/), [PDF para JPG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-jpg/) e [PDF para PNG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-png/). Outras operações de conversão de PDF para formatos especializados — [PDF para SVG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-svg/), [PDF para TIFF](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-tiff/) — também são suportadas.

{{% /alert %}}

> **Note:** Ao exportar para PDF/UA, o Aspose.Slides trata gráficos complexos como SmartArt, diagramas e fórmulas como uma única figura. Elementos de caminho individuais não são preservados como conteúdo separado e podem ser marcados como artefatos; texto alternativo é fornecido apenas para a figura completa.

## **FAQ**

**Posso converter vários arquivos PowerPoint para PDF em lote?**

Sim, o Aspose.Slides suporta conversão em lote de vários arquivos PPT ou PPTX para PDF. Você pode iterar sobre seus arquivos e aplicar o processo de conversão programaticamente.

**É possível proteger o PDF convertido com senha?**

Sim. Use a classe [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) para definir uma senha e especificar permissões de acesso durante o processo de conversão.

**Como incluo slides ocultos no PDF?**

Chame [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/) com `true` na classe [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) para incluir slides ocultos no PDF resultante.

**O Aspose.Slides mantém alta qualidade de imagem no PDF?**

Sim, você pode controlar a qualidade da imagem usando métodos como [setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setjpegquality/) e [setSufficientResolution](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setsufficientresolution/) na classe [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) para garantir imagens de alta qualidade no seu PDF.

**O Aspose.Slides suporta padrões de conformidade PDF/A?**

Sim, o Aspose.Slides permite exportar PDFs que estejam em conformidade com [vários padrões](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfcompliance/), incluindo PDF/A1a, PDF/A1b e PDF/UA, garantindo que seus documentos atendam a requisitos de acessibilidade e arquivamento.

## **Recursos adicionais**

- [Documentação do Aspose.Slides for Node.js via Java](/slides/pt/nodejs-java/)
- [Referência da API do Aspose.Slides for Node.js via Java](https://reference.aspose.com/slides/nodejs-java/)
- [Conversores Online Gratuitos da Aspose](https://products.aspose.app/slides/conversion)