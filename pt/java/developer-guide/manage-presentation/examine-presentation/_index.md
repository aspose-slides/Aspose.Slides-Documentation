---
title: Recuperar e Atualizar Informações da Apresentação em Java
linktitle: Informações da Apresentação
type: docs
weight: 30
url: /pt/java/examine-presentation/
keywords:
- formato de apresentação
- propriedades da apresentação
- propriedades do documento
- obter propriedades
- ler propriedades
- alterar propriedades
- modificar propriedades
- atualizar propriedades
- examinar PPTX
- examinar PPT
- examinar ODP
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Explore slides, estrutura e metadados em apresentações PowerPoint e OpenDocument usando Java para obter insights mais rápidos e auditorias de conteúdo mais inteligentes."
---
## **Visão geral**

Aspose.Slides pode identificar o formato de uma apresentação e ler seus metadados de documento sem criar um modelo de objeto de apresentação completo. Isso é útil quando você precisa classificar arquivos, criar um inventário ou inspecionar propriedades antes de decidir se deve carregar e processar o conteúdo da apresentação.

Este artigo demonstra inspeção leve por meio de [PresentationFactory](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentationfactory/) e [IPresentationInfo](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ipresentationinfo/), bem como atualizações direcionadas por meio de [IDocumentProperties](https://reference.aspose.com/slides/pt/java/com.aspose.slides/idocumentproperties/).

## **Verificar o formato de uma apresentação**

Use [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) para inspecionar um arquivo sem criar uma [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/) instância. O método [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ipresentationinfo/#getLoadFormat--) relata o formato detectado, como PPTX, PPT ou ODP.

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadFormat;
import com.aspose.slides.PresentationFactory;

String[] fileNames = { "pres.pptx", "pres.ppt", "pres.odp" };

for (String fileName : fileNames) {
    IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(fileName);
    int loadFormat = presentationInfo.getLoadFormat();
    String formatName = "Other (" + loadFormat + ")";

    if (loadFormat == LoadFormat.Pptx) {
        formatName = "PPTX";
    } else if (loadFormat == LoadFormat.Ppt) {
        formatName = "PPT";
    } else if (loadFormat == LoadFormat.Odp) {
        formatName = "ODP";
    }

    System.out.println(fileName + ": " + formatName);
}
```

## **Criar um inventário de apresentação leve**

Ao processar muitos arquivos de apresentação, você pode precisar de um inventário compacto para validação, indexação ou um sistema de gerenciamento de documentos. Nesse cenário, use [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) para obter um objeto [IPresentationInfo](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ipresentationinfo/) e, em seguida, chame [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) para ler os metadados do documento. Essa abordagem não cria uma instância de [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/) nem exige que você percorra todo o modelo de objeto da apresentação.

As propriedades estendidas expostas por [IDocumentProperties](https://reference.aspose.com/slides/pt/java/com.aspose.slides/idocumentproperties/) fornecem os seguintes valores de inventário:

| Método | Valor do inventário |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/pt/java/com.aspose.slides/idocumentproperties/#getSlides--) | Número total de slides. |
| [getHiddenSlides](https://reference.aspose.com/slides/pt/java/com.aspose.slides/idocumentproperties/#getHiddenSlides--) | Número de slides ocultos. |
| [getNotes](https://reference.aspose.com/slides/pt/java/com.aspose.slides/idocumentproperties/#getNotes--) | Número de slides que contêm anotações. |
| [getParagraphs](https://reference.aspose.com/slides/pt/java/com.aspose.slides/idocumentproperties/#getParagraphs--) | Número total de parágrafos, quando disponível. |
| [getWords](https://reference.aspose.com/slides/pt/java/com.aspose.slides/idocumentproperties/#getWords--) | Número total de palavras. |
| [getMultimediaClips](https://reference.aspose.com/slides/pt/java/com.aspose.slides/idocumentproperties/#getMultimediaClips--) | Número total de clipes de áudio e vídeo. |

O exemplo a seguir lê esses valores sem criar um objeto [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/) e imprime um inventário compacto. Ele também combina [getHeadingPairs](https://reference.aspose.com/slides/pt/java/com.aspose.slides/idocumentproperties/#getHeadingPairs--) com [getTitlesOfParts](https://reference.aspose.com/slides/pt/java/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) para exibir grupos de conteúdo como fontes, temas e títulos de slides.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IHeadingPair;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadFormat;
import com.aspose.slides.PresentationFactory;
import java.nio.file.Paths;

String filePath = "sample.pptx";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(filePath);
IDocumentProperties documentProperties = presentationInfo.readDocumentProperties();

int loadFormat = presentationInfo.getLoadFormat();
String formatName = "Other (" + loadFormat + ")";

if (loadFormat == LoadFormat.Pptx) {
    formatName = "PPTX";
} else if (loadFormat == LoadFormat.Ppt) {
    formatName = "PPT";
} else if (loadFormat == LoadFormat.Odp) {
    formatName = "ODP";
}

System.out.println("File: " + Paths.get(filePath).getFileName());
System.out.println("Format: " + formatName);
System.out.println("Title: " + documentProperties.getTitle());
System.out.println("Author: " + documentProperties.getAuthor());
System.out.println("Statistics:");
System.out.println("  Slides: " + documentProperties.getSlides());
System.out.println("  Hidden slides: " + documentProperties.getHiddenSlides());
System.out.println("  Slides with notes: " + documentProperties.getNotes());
System.out.println("  Paragraphs: " + documentProperties.getParagraphs());
System.out.println("  Words: " + documentProperties.getWords());
System.out.println("  Multimedia clips: " + documentProperties.getMultimediaClips());

IHeadingPair[] headingPairs = documentProperties.getHeadingPairs();
String[] titlesOfParts = documentProperties.getTitlesOfParts();
headingPairs = headingPairs != null ? headingPairs : new IHeadingPair[0];
titlesOfParts = titlesOfParts != null ? titlesOfParts : new String[0];
int partIndex = 0;

if (headingPairs.length == 0 || titlesOfParts.length == 0) {
    System.out.println("Content groups: not available");
} else {
    System.out.println("Content groups:");

    for (IHeadingPair headingPair : headingPairs) {
        System.out.println("  " + headingPair.getName() + " (" + headingPair.getCount() + ")");

        for (int partOffset = 0; partOffset < headingPair.getCount() && partIndex < titlesOfParts.length; partOffset++) {
            System.out.println("    - " + titlesOfParts[partIndex]);
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.length) {
        System.out.println("  Other parts:");

        while (partIndex < titlesOfParts.length) {
            System.out.println("    - " + titlesOfParts[partIndex]);
            partIndex++;
        }
    }
}
```

Cada [IHeadingPair](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iheadingpair/) fornece um nome de grupo e o número de itens nesse grupo. [IDocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/pt/java/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) retorna um array plano e ordenado, portanto consuma o número de títulos consecutivos especificado por cada par de cabeçalho.

### **Metadados armazenados e limitações de formato**

As propriedades de inventário retornadas por [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) refletem os metadados disponíveis no documento de origem. Aspose.Slides não carrega e percorre o modelo de objeto da apresentação para recalcular esses valores nesta chamada. Propriedades ausentes são representadas por valores padrão, e valores armazenados podem estar desatualizados se o aplicativo que salvou o arquivo pela última vez não atualizou suas propriedades de documento.

- **PPTX:** O formato fornece propriedades de documento estendidas para contagens de slides, notas, slides ocultos, parágrafos, palavras e multimídia, além de pares de cabeçalhos e títulos de partes. A disponibilidade depende de quais propriedades foram gravadas pelo produtor do documento.
- **PPT:** O formato binário pode armazenar propriedades de resumo de documento correspondentes. Se uma propriedade estiver ausente ou não for atualizada pelo produtor do documento, Aspose.Slides retorna seu valor armazenado ou padrão em vez de calculá-lo a partir dos slides.
- **ODP:** Os metadados OpenDocument fornecem estatísticas gerais do documento, como contagens de páginas, parágrafos e palavras, mas esses valores não correspondem a todas as propriedades estendidas específicas do PowerPoint. Metadados de slide oculto, slide de notas, multimídia, pares de cabeçalhos e títulos de partes podem estar indisponíveis, e as propriedades de inventário podem retornar valores padrão. Não trate um valor zero ou um array vazio como prova autoritária de que o conteúdo correspondente está ausente.

Use a abordagem de metadados leves para inventários e verificações preliminares. Carregue a apresentação e inspecione seu modelo de objeto em tempo real quando o resultado precisar refletir alterações em memória ou quando for necessário verificar o conteúdo real da apresentação.

## **Atualizar propriedades da apresentação**

As propriedades retornadas por [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) também podem ser alteradas sem criar uma instância de [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/). Aplique as alterações com [IPresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ipresentationinfo/#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) e, em seguida, grave a apresentação vinculada com [IPresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ipresentationinfo/#writeBindedPresentation-java.io.OutputStream-).

A imagem a seguir mostra as propriedades originais do documento.

![Original document properties of the PowerPoint presentation](input_properties.png)

O exemplo a seguir altera o título e a data da última gravação e grava o resultado em um novo arquivo:

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.PresentationFactory;
import java.io.FileOutputStream;
import java.io.OutputStream;
import java.util.Date;

String sourceFile = "sample.pptx";
String outputFile = "sample_with_updated_properties.pptx";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(sourceFile);
IDocumentProperties documentProperties = presentationInfo.readDocumentProperties();

documentProperties.setTitle("Quarterly sales report");
documentProperties.setLastSavedTime(new Date());

presentationInfo.updateDocumentProperties(documentProperties);
try (OutputStream outputStream = new FileOutputStream(outputFile)) {
    presentationInfo.writeBindedPresentation(outputStream);
}
```

A imagem a seguir mostra as propriedades do documento atualizadas.

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **Links úteis**

Para verificações de segurança relacionadas e configurações de proteção, veja os artigos a seguir:

- [Proteger Apresentações com Senha](/slides/pt/java/password-protected-presentation/)
- [Proteger Apresentações contra Escrita](/slides/pt/java/write-protected-presentation/)

## **Perguntas frequentes**

**Como posso verificar se as fontes estão incorporadas e quais são?**

Carregue a apresentação e use [Presentation.getFontsManager](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/#getFontsManager--). Chame [IFontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) para obter as fontes incorporadas e [IFontsManager.getFonts](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ifontsmanager/#getFonts--) para obter as fontes usadas pela apresentação. Compare os dois resultados para encontrar fontes que são necessárias para renderização, mas não estão incorporadas.

**Como posso rapidamente saber se o arquivo tem slides ocultos e quantos?**

Quando os metadados do documento armazenados são suficientes, leia [IDocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/pt/java/com.aspose.slides/idocumentproperties/#getHiddenSlides--) através de [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) e [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--). Isso é adequado para um inventário leve. Se a apresentação foi modificada em memória, os metadados armazenados podem estar ausentes ou desatualizados, ou se precisar verificar valores em tempo real, itere por [Presentation.getSlides](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/#getSlides--) e inspecione o método [ISlide.getHidden](https://reference.aspose.com/slides/pt/java/com.aspose.slides/islide/#getHidden--) de cada slide em vez disso.

**Posso detectar se um tamanho e orientação de slide personalizados são usados e se eles diferem dos padrões?**

Sim. Carregue a apresentação e chame [Presentation.getSlideSize](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/#getSlideSize--). Use [ISlideSize.getType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/islidesize/#getType--), [ISlideSize.getSize](https://reference.aspose.com/slides/pt/java/com.aspose.slides/islidesize/#getSize--) e [ISlideSize.getOrientation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/islidesize/#getOrientation--) para comparar as configurações atuais com o preset esperado e as dimensões.

**Existe uma maneira rápida de ver se os gráficos referenciam fontes de dados externas?**

Sim. Localize cada [Chart](https://reference.aspose.com/slides/pt/java/com.aspose.slides/chart/) e chame [IChartData.getDataSourceType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichartdata/#getDataSourceType--). Para uma pasta de trabalho externa, chame [IChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichartdata/#getExternalWorkbookPath--). O tipo de fonte de dados e o caminho identificam uma referência externa, mas verificar se o destino está disponível requer uma verificação de recurso separada.

**Como posso avaliar slides 'pesados' que podem desacelerar a renderização ou exportação em PDF?**

Não existe uma única propriedade de complexidade. Percorra [Presentation.getSlides](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/#getSlides--) e a coleção [IBaseSlide.getShapes](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ibaseslide/#getShapes--) de cada slide. Use a contagem de formas e a presença de imagens grandes, efeitos, animações ou multimídia como sinais de triagem, e meça uma renderização ou exportação representativa antes de considerar um slide como um gargalo de desempenho confirmado.