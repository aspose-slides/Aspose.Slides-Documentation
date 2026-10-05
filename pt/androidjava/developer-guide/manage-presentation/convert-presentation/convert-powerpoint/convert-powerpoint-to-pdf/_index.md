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
description: "Converter PowerPoint PPT/PPTX para PDFs de alta qualidade e pesquisáveis em Java usando Aspose.Slides para Android, com exemplos de código rápidos e opções avançadas de conversão."
---
## **Visão geral**

Converter apresentações PowerPoint (PPT, PPTX, ODP, etc.) para formato PDF no Android oferece várias vantagens, incluindo compatibilidade entre diferentes dispositivos e preservação do layout e formatação da sua apresentação. Este guia demonstra como converter apresentações para documentos PDF, usar várias opções para controlar a qualidade da imagem, incluir slides ocultos, proteger PDFs com senha, detectar substituições de fontes, selecionar slides específicos para conversão e aplicar padrões de conformidade aos documentos de saída.

## **Conversões de PowerPoint para PDF**

Usando Aspose.Slides, você pode converter apresentações nos seguintes formatos para PDF:

* **PPT**
* **PPTX**
* **ODP**

Para converter uma apresentação para PDF, passe o nome do arquivo como argumento para a classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) e então salve a apresentação como PDF usando o método [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-). A classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) expõe o método [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) que normalmente é usado para converter uma apresentação para PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Android via Java insere informações da API e número da versão nos documentos de saída. Por exemplo, ao converter uma apresentação para PDF, Aspose.Slides preenche o campo Application com "*Aspose.Slides*" e o campo PDF Producer com um valor no formato "*Aspose.Slides v XX.XX*". **Observação** que você não pode instruir o Aspose.Slides a alterar ou remover essas informações dos documentos de saída.
{{% /alert %}}

Aspose.Slides permite que você converta:

* Apresentações inteiras para PDF
* Slides específicos de uma apresentação para PDF

Aspose.Slides exporta apresentações para PDF, garantindo que os PDFs resultantes correspondam de perto às apresentações originais. Elementos e atributos são renderizados com precisão na conversão, incluindo:

* Imagens
* Caixas de texto e formas
* Formatação de texto
* Formatação de parágrafos
* Links
* Cabeçalhos e rodapés
* Marcadores
* Tabelas

## **Converter PowerPoint para PDF**

O processo padrão de conversão de PowerPoint para PDF usa opções padrão. Nesse caso, Aspose.Slides tenta converter a apresentação fornecida para PDF usando configurações ótimas nos níveis máximos de qualidade.

O exemplo a seguir carrega uma apresentação e salva todos os slides visíveis em PDF usando as configurações de exportação padrão.

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
Aspose oferece um conversor online gratuito de [**PowerPoint para PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) que demonstra o processo de conversão de apresentação para PDF. Você pode executar um teste com este conversor para uma implementação ao vivo do procedimento descrito aqui.
{{% /alert %}}

## **Converter PowerPoint para PDF com Opções**

Aspose.Slides fornece opções personalizadas — propriedades na classe [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) — que permitem personalizar o PDF resultante, bloquear o PDF com senha ou especificar como o processo de conversão deve prosseguir.

### **Converter PowerPoint para PDF com Opções Personalizadas**

Usando opções de conversão personalizadas, você pode definir sua configuração de qualidade preferida para imagens raster, especificar como metafiles devem ser tratados, definir um nível de compressão para texto, configurar DPI para imagens e mais.

O exemplo a seguir exporta uma apresentação para PDF 1.5 com qualidade JPEG definida como 90, resolução de imagem definida como 300 DPI, metafiles salvos como PNG e compressão de texto Flate.

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

### **Preservar arquivos OLE incorporados como anexos PDF**

Se uma apresentação contiver uma pasta de trabalho Excel incorporada, você pode desejar que os destinatários do PDF acessem os dados da planilha além de visualizar os slides. Chame [setIncludeOleData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) com `true` para preservar arquivos OLE incorporados como anexos no PDF resultante.

O valor padrão é `false`: a imagem de visualização ou ícone do objeto OLE é renderizado na página PDF, mas seu arquivo incorporado não é incluído como anexo. Definir a opção como `true` inclui adicionalmente os dados do arquivo. A visualização permanece uma representação visual; o anexo permite que os destinatários abram ou salvem o arquivo incorporado separadamente. O objeto OLE não se torna uma planilha Excel interativa na página PDF.

O exemplo a seguir carrega uma apresentação que já contém uma pasta de trabalho Excel incorporada e a exporta para PDF com a planilha anexada.

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
2. Abra o painel **Anexos** do visualizador e localize a pasta de trabalho incorporada.
3. Salve o anexo e abra-o no Excel para inspecionar seus dados, ou abra-o diretamente se o visualizador permitir. A visualização na página PDF é separada do anexo.

{{% alert color="info" title="Note" %}}
Os padrões PDF/A impõem restrições aos anexos: PDF/A-1 proíbe arquivos incorporados, PDF/A-2 permite apenas anexos PDF/A, e PDF/A-3 permite outros tipos de arquivo, incluindo pastas de trabalho Excel. Estas são exigências dos padrões, não restrições específicas ao Aspose.Slides. Este exemplo usa a configuração padrão de conformidade PDF e não demonstra exportação PDF/A.
{{% /alert %}}

### **Converter PowerPoint para PDF com Slides Ocultos**

Se uma apresentação contiver slides ocultos, você pode usar o método [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) da classe [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) para incluir os slides ocultos como páginas no PDF resultante.

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

### **Converter PowerPoint para um PDF protegido por senha**

O exemplo a seguir exporta uma apresentação para um PDF que requer a senha `password` para abrir. As permissões de acesso permitem impressão, incluindo impressão de alta qualidade.

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

Aspose.Slides fornece o método [setWarningCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) na classe [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/), permitindo detectar substituições de fontes durante o processo de conversão de apresentação para PDF.

O exemplo a seguir exporta uma apresentação para PDF e imprime avisos de substituição de fontes no console. Um aviso é impresso somente quando uma fonte indisponível é substituída durante a exportação.

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
Para mais informações sobre substituição de fontes, veja o artigo [Font Substitution](/slides/pt/androidjava/font-substitution/).
{{% /alert %}} 

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

    // Remover o slide vazio com o qual a nova apresentação foi criada.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Converter PowerPoint para PDF em Visualização de Slides de Notas**

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

## **Acessibilidade e Padrões de Conformidade para PDF**

Aspose.Slides permite que você use um procedimento de conversão que esteja em conformidade com as [Diretrizes de Acessibilidade de Conteúdo Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Você pode exportar um documento PowerPoint para PDF usando quaisquer destes padrões de conformidade: **PDF/A1a**, **PDF/A1b**, e **PDF/UA**.

Este código demonstra um processo de conversão de PowerPoint para PDF que produz múltiplos PDFs com base em diferentes padrões de conformidade:

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
Aspose.Slides suporta operações de conversão PDF, permitindo que você converta arquivos PDF para formatos de arquivo populares. Você pode realizar conversões de [PDF para HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF para imagem](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF para JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/), e [PDF para PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/). Outras operações de conversão de PDF para formatos especializados — [PDF para SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF para TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/), e [PDF para XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/) — também são suportadas.
{{% /alert %}}

> **Observação:** Ao exportar para PDF/UA, Aspose.Slides trata gráficos complexos como SmartArt, gráficos e fórmulas como uma única figura. Elementos de caminho individuais não são preservados como conteúdo separado e podem ser marcados como artefatos; texto alternativo é fornecido apenas para a figura inteira.

## **FAQ**

**Posso converter vários arquivos PowerPoint para PDF em lote?**

Sim, Aspose.Slides suporta conversão em lote de vários arquivos PPT ou PPTX para PDF. Você pode iterar pelos seus arquivos e aplicar o processo de conversão programaticamente.

**É possível proteger o PDF convertido com senha?**

Sim. Use a classe [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) para definir uma senha e definir permissões de acesso durante o processo de conversão.

**Como incluir slides ocultos no PDF?**

Chame [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) com `true` na classe [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) para incluir slides ocultos no PDF resultante.

**O Aspose.Slides pode manter alta qualidade de imagem no PDF?**

Sim, você pode controlar a qualidade da imagem usando métodos como [setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) e [setSufficientResolution](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) na classe [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) para garantir imagens de alta qualidade no seu PDF.

**O Aspose.Slides suporta os padrões de conformidade PDF/A?**

Sim, Aspose.Slides permite que você exporte PDFs que estejam em conformidade com [vários padrões](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfcompliance/), incluindo PDF/A1a, PDF/A1b e PDF/UA, garantindo que seus documentos atendam aos requisitos de acessibilidade e arquivamento.

## **Recursos adicionais**

- [Documentação do Aspose.Slides for Android via Java](/slides/pt/androidjava/)
- [Referência da API do Aspose.Slides for Android via Java](https://reference.aspose.com/slides/androidjava/)
- [Conversores Online Gratuitos da Aspose](https://products.aspose.app/slides/conversion)