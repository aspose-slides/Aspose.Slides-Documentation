---
title: Converter PPT e PPTX para PDF no Android [Recursos avançados incluídos]
linktitle: PowerPoint para PDF
type: docs
weight: 40
url: /pt/androidjava/convert-powerpoint-to-pdf/
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
- Android
- Java
- Aspose.Slides
description: "Converta PowerPoint PPT/PPTX em PDFs de alta qualidade e pesquisáveis em Java usando Aspose.Slides para Android, com exemplos de código rápidos e opções avançadas de conversão."
---
## **Visão geral**

Converter apresentações do PowerPoint (PPT, PPTX, ODP, etc.) para formato PDF no Android oferece várias vantagens, incluindo compatibilidade entre diferentes dispositivos e a preservação do layout e da formatação da sua apresentação. Este guia demonstra como converter apresentações para documentos PDF, usar várias opções para controlar a qualidade das imagens, incluir slides ocultos, proteger PDFs com senha, detectar substituições de fontes, selecionar slides específicos para conversão e aplicar padrões de conformidade aos documentos de saída.

## **Conversões de PowerPoint para PDF**

Usando Aspose.Slides, você pode converter apresentações nos seguintes formatos para PDF:

* **PPT**
* **PPTX**
* **ODP**

Para converter uma apresentação para PDF, passe o nome do arquivo como argumento para a [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) class e então salve a apresentação como PDF usando um método [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-). A [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) class expõe o método [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) que normalmente é usado para converter uma apresentação para PDF.

{{% alert color="info" title="Note" %}}

Aspose.Slides for Android via Java insere suas informações de API e número da versão nos documentos de saída. Por exemplo, ao converter uma apresentação para PDF, Aspose.Slides preenche o campo Application com "*Aspose.Slides*" e o campo PDF Producer com um valor no formato "*Aspose.Slides v XX.XX*". **Nota** que você não pode instruir o Aspose.Slides a alterar ou remover essas informações dos documentos de saída.

{{% /alert %}}

Aspose.Slides permite que você converta:

* Apresentações inteiras para PDF
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

O processo padrão de conversão de PowerPoint para PDF usa opções padrão. Nesse caso, Aspose.Slides tenta converter a apresentação fornecida para PDF usando configurações ideais nos níveis máximos de qualidade.

O exemplo a seguir carrega uma apresentação e salva todos os slides visíveis para PDF usando as configurações de exportação padrão.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}

Aspose oferece um conversor online gratuito de [**Conversor de PowerPoint para PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) que demonstra o processo de conversão de apresentação para PDF. Você pode executar um teste com este conversor para uma implementação ao vivo do procedimento descrito aqui.

{{% /alert %}}

## **Converter PowerPoint para PDF com Opções**

Aspose.Slides fornece opções personalizadas—propriedades na classe [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/)—que permitem personalizar o PDF resultante, bloquear o PDF com uma senha ou especificar como o processo de conversão deve prosseguir.

### **Converter PowerPoint para PDF com Opções Personalizadas**

Usando opções de conversão personalizadas, você pode definir sua configuração de qualidade preferida para imagens raster, especificar como os metafiles devem ser manipulados, definir um nível de compressão para texto, configurar DPI para imagens e muito mais.

O exemplo a seguir exporta uma apresentação para PDF 1.5 com qualidade JPEG definida em 90, resolução de imagem definida em 300 DPI, metafiles salvos como PNG e compressão de texto Flate.

```java
import com.aspose.slides.*;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setJpegQuality((byte)90);
pdfOptions.setSufficientResolution(300);
pdfOptions.setSaveMetafilesAsPng(true);
pdfOptions.setTextCompression(PdfTextCompression.Flate);
pdfOptions.setCompliance(PdfCompliance.Pdf15);

Presentation presentation = new Presentation("PowerPoint.pptx");

try {
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Selecionar Compressão de Imagem Automaticamente**

Quando uma apresentação contém muitas fotografias ou capturas de tela, reduzir o tamanho do PDF exportado pode facilitar o envio por e‑mail ou o download. Chame [PdfOptions.setBestImagesCompressionRatio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setBestImagesCompressionRatio-boolean-) com `true` para selecionar automaticamente o algoritmo de compressão mais adequado para cada imagem durante a exportação para PDF.

O exemplo a seguir carrega uma apresentação existente, habilita a seleção automática de compressão de imagem e a salva como documento PDF. Todas as demais configurações de exportação de PDF mantêm seus valores padrão.

```java
import com.aspose.slides.PdfOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setBestImagesCompressionRatio(true);

Presentation presentation = new Presentation("image-heavy.pptx");
try {
    presentation.save("image-heavy.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Esta opção seleciona um algoritmo de compressão para cada imagem. Reduzir o valor passado para [setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) diminui a qualidade da imagem JPEG, enquanto reduzir o valor passado para [setSufficientResolution](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) permite que as imagens sejam reamostradas para uma resolução inferior, o que pode reduzir detalhes. Habilitar a seleção automática de compressão não diminui, por si só, nenhuma dessas configurações.

Selecionar algoritmos de compressão de imagem requer tempo de processamento e memória adicionais. A redução de tamanho depende das imagens da apresentação e das configurações de exportação; uma redução fixa não é garantida para todas as apresentações.

### **Preservar Arquivos OLE Incorporados como Anexos PDF**

Se uma apresentação contém uma pasta de trabalho do Excel incorporada, você pode querer que os destinatários do PDF acessem os dados da planilha além de visualizar os slides. Chame [setIncludeOleData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) com `true` para preservar os arquivos OLE incorporados como anexos no PDF resultante.

O valor padrão é `false`: a imagem de visualização ou o ícone do objeto OLE é renderizado na página PDF, mas o arquivo incorporado não é incluído como anexo. Definir a opção como `true` inclui adicionalmente os dados do arquivo. A visualização continua sendo uma representação visual; o anexo permite que os destinatários abram ou salvem o arquivo incorporado separadamente. O objeto OLE não se torna uma planilha interativa do Excel na página PDF.

O exemplo a seguir carrega uma apresentação que já contém uma pasta de trabalho do Excel incorporada e a exporta para PDF com a planilha anexada.

```java
import com.aspose.slides.*;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setIncludeOleData(true);

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Para verificar o resultado:

1. Abra o PDF exportado em um visualizador que suporte anexos de arquivo, como o Adobe Acrobat Reader.
2. Abra o painel **Attachments** do visualizador e localize a pasta de trabalho incorporada.
3. Salve o anexo e abra‑o no Excel para inspecionar seus dados, ou abra‑o diretamente se o visualizador permitir. A visualização na página PDF é separada do anexo.

{{% alert color="info" title="Note" %}}

Os padrões PDF/A impõem restrições a anexos: PDF/A‑1 proíbe arquivos incorporados, PDF/A‑2 permite apenas anexos PDF/A e PDF/A‑3 permite outros tipos de arquivo, incluindo pastas de trabalho do Excel. Estas são exigências dos padrões, não restrições específicas do Aspose.Slides. Este exemplo usa a configuração padrão de conformidade PDF e não demonstra exportação PDF/A.

{{% /alert %}}

### **Converter PowerPoint para PDF com Slides Ocultos**

Se uma apresentação contém slides ocultos, você pode usar o método [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) da classe [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) para incluir os slides ocultos como páginas no PDF resultante.

O exemplo a seguir exporta uma apresentação para PDF, incluindo quaisquer slides ocultos.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setShowHiddenSlides(true);

    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Converter PowerPoint para um PDF Protegido por Senha**

O exemplo a seguir exporta uma apresentação para um PDF que requer a senha `password` para ser aberto. As permissões de acesso permitem impressão, inclusive impressão de alta qualidade.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);

    presentation.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Detectar Substituições de Fonte**

Aspose.Slides fornece o método [setWarningCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) na classe [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/), permitindo detectar substituições de fonte durante o processo de conversão de apresentação para PDF.

O exemplo a seguir exporta uma apresentação para PDF e imprime avisos de substituição de fonte no console. Um aviso é impresso somente quando uma fonte indisponível é substituída durante a exportação.

```java
import com.aspose.slides.*;

class FontSubstitutionHandler implements IWarningCallback {
    public int warning(IWarningInfo warning) {
        if (warning.getWarningType() == WarningType.DataLoss && warning.getDescription().startsWith("Font will be substituted")) {
            System.out.println("Font substitution warning: " + warning.getDescription());
        }
        return ReturnAction.Continue;
    }
}

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setWarningCallback(new FontSubstitutionHandler());

Presentation presentation = new Presentation("sample.pptx");
try {
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}

Para mais informações sobre substituição de fontes, veja o artigo [Substituição de Fonte](/slides/pt/androidjava/font-substitution/).

{{% /alert %}} 

### **Manipular Fontes sem um Tipo de Letra Negrito Dedicado**

Uma apresentação pode aplicar formatação em negrito a um texto mesmo quando sua fonte não possui um tipo de letra negrito dedicado. O texto ainda pode aparecer em negrito por meio de negrito sintético, que espessa artificialmente os glifos regulares. Quando esse texto parece muito pesado ou diferente da aparência pretendida no PDF, tente chamar [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles-boolean-) com `true`. Esta opção renderiza o texto afetado como bitmap durante a exportação para PDF e pode melhorar sua aparência para certas fontes. Seu valor padrão é `false`.

A apresentação de exemplo contém duas caixas de texto: uma com texto normal e outra com formatação em negrito aplicada à mesma fonte, que não possui um tipo de letra negrito dedicado. O exemplo a seguir carrega a apresentação, habilita a rasterização de estilos de fonte não suportados e a exporta para PDF:

```java
import com.aspose.slides.PdfOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setRasterizeUnsupportedFontStyles(true);

Presentation presentation = new Presentation("unsupported-bold.pptx");
try {
    presentation.save("rasterized.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

A seguir são exibidas as visualizações do output desativado e do output ativado. Neste exemplo, o texto em negrito tem traços mais grossos com a opção desativada. Com a opção ativada, seus traços são mais leves; o texto normal permanece inalterado. Compare os resultados antes de escolher a configuração para sua apresentação.

| Opção desativada (`false`, o padrão) | Opção ativada (`true`) |
|---|---|
| ![PDF com rasterização de estilo de fonte não suportada desativada](unsupported-bold-disabled.png) | ![PDF com rasterização de estilo de fonte não suportada ativada](unsupported-bold-enabled.png) |

Neste exemplo, habilitar a opção transforma somente o texto em negrito em bitmap: ele não pode ser selecionado, copiado ou pesquisado como texto sem OCR, e suas bordas parecem mais suaves em zoom de 800 %. O texto normal continua pesquisável. Com a opção desativada, ambas as cadeias permanecem como texto.

Esta opção rasteriza texto formatado como negrito quando sua fonte não possui um tipo de letra negrito dedicado. A [Substituição de Fonte](/slides/pt/androidjava/font-substitution/) em vez disso seleciona outra fonte quando a original não está disponível.

## **Converter Slides Selecionados do PowerPoint para PDF**

O exemplo a seguir exporta os slides 1 e 3 de uma apresentação para PDF. Os números dos slides neste array são baseados em 1, e a apresentação de entrada deve conter ao menos três slides.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    int[] slides = { 1, 3 };
    presentation.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **Converter PowerPoint para PDF com Tamanho de Slide Personalizado**

O exemplo a seguir copia o primeiro slide de uma apresentação para uma nova apresentação com tamanho de slide de 612 × 792 pontos (8,5 × 11 polegadas). Ele dimensiona o conteúdo do slide para caber e exporta o slide único para PDF.

```java
import com.aspose.slides.*;

float slideWidth = 612;
float slideHeight = 792;

Presentation presentation = new Presentation("SelectedSlides.pptx");
Presentation resizedPresentation = new Presentation();

try {
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Remova o slide vazio com o qual a nova apresentação foi criada.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Converter PowerPoint para PDF em Vista de Slides de Notas**

O exemplo a seguir exporta uma apresentação para PDF, colocando as notas do apresentador de cada slide abaixo do slide. Use uma apresentação que contenha notas do apresentador para ver o resultado.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **Padrões de Acessibilidade e Conformidade para PDF**

Aspose.Slides permite que você use um procedimento de conversão que esteja em conformidade com as [Diretrizes de Acessibilidade de Conteúdo Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Você pode exportar um documento PowerPoint para PDF usando qualquer um desses padrões de conformidade: **PDF/A1a**, **PDF/A1b** e **PDF/UA**.

Este código demonstra um processo de conversão de PowerPoint para PDF que produz múltiplos PDFs baseados em diferentes padrões de conformidade:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();

    pdfOptions.setCompliance(PdfCompliance.PdfA1a);
    presentation.save("pres-a1a-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfA1b);
    presentation.save("pres-a1b-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfUa);
    presentation.save("pres-ua-compliance.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}

Aspose.Slides suporta operações de conversão de PDF, permitindo converter arquivos PDF para formatos de arquivo populares. Você pode executar conversões de [PDF para HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF para imagem](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF para JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/) e [PDF para PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/). Outras operações de conversão de PDF para formatos especializados—[PDF para SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF para TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/) e [PDF para XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/)—também são suportadas.

{{% /alert %}}

> **Observação:** Ao exportar para PDF/UA, o Aspose.Slides trata gráficos complexos como SmartArt, gráficos e fórmulas como uma única figura. Elementos de caminho individuais não são preservados como conteúdo separado e podem ser marcados como artefatos; texto alternativo é fornecido apenas para a figura completa.

## **Perguntas Frequentes**

**Posso converter vários arquivos PowerPoint para PDF em lote?**

Sim, o Aspose.Slides suporta conversão em lote de vários arquivos PPT ou PPTX para PDF. Você pode iterar pelos seus arquivos e aplicar o processo de conversão programaticamente.

**É possível proteger o PDF convertido com senha?**

Sim. Use a classe [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) para definir uma senha e definir permissões de acesso durante o processo de conversão.

**Como incluir slides ocultos no PDF?**

Chame [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) com `true` na classe [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) para incluir slides ocultos no PDF resultante.

**O Aspose.Slides pode manter alta qualidade de imagem no PDF?**

Sim, você pode controlar a qualidade da imagem usando métodos como [setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) e [setSufficientResolution](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) na classe [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) para garantir imagens de alta qualidade no seu PDF.

**O Aspose.Slides suporta padrões de conformidade PDF/A?**

Sim, o Aspose.Slides permite exportar PDFs que estejam em conformidade com [vários padrões](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfcompliance/), incluindo PDF/A1a, PDF/A1b e PDF/UA, garantindo que seus documentos atendam aos requisitos de acessibilidade e arquivamento.

## **Recursos Adicionais**

- [Documentação do Aspose.Slides para Android via Java](/slides/pt/androidjava/)
- [Referência de API do Aspose.Slides para Android via Java](https://reference.aspose.com/slides/androidjava/)
- [Conversores Online Gratuitos da Aspose](https://products.aspose.app/slides/conversion)