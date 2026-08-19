---
title: Mesclar apresentações de forma eficiente no Android
linktitle: Mesclar apresentações
type: docs
weight: 40
url: /pt/androidjava/merge-presentation/
keywords:
- mesclar PowerPoint
- mesclar apresentações
- mesclar slides
- mesclar PPT
- mesclar PPTX
- mesclar ODP
- combinar PowerPoint
- combinar apresentações
- combinar slides
- combinar PPT
- combinar PPTX
- combinar ODP
- Android
- Java
- Aspose.Slides
description: "Aprenda a mesclar apresentações PowerPoint e OpenDocument no Android clonando slides, controlando mestres e layouts, redimensionando o conteúdo dos slides, preservando seções e lidando com arquivos protegidos ou grandes."
---
## **Visão geral**

Aspose.Slides for Android via Java mescla apresentações clonando slides de uma [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/) para outra. A operação principal é [ISlideCollection.addClone](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-), que pode preservar a formatação do slide de origem ou anexar o slide clonado a um mestre ou layout na apresentação de destino.

Este artigo aborda os fluxos de trabalho de mesclagem mais comuns:

- mesclar todos os slides preservando a formatação de origem;
- mesclar slides selecionados;
- aplicar um mestre da apresentação de destino;
- aplicar um layout específico da apresentação de destino;
- normalizar diferentes tamanhos de slide antes da mesclagem;
- adicionar slides clonados a uma seção;
- mesclar várias apresentações em um fluxo de trabalho de ponta a ponta;
- lidar com mestres, recursos, notas, comentários, mídia, fontes, senhas, arquivos grandes e questões de multithreading.

## **Como a clonagem de slides afeta mestres e layouts**

Um slide herda grande parte de sua aparência do layout e do mestre. Por esse motivo, a sobrecarga de clonagem que você escolher determina como o slide mesclado é integrado à apresentação de destino.

Use [ISlideCollection.addClone](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/islidecollection/) de uma das seguintes maneiras:

- `addClone(sourceSlide)` — preserva o layout e a formatação do slide de origem. Quando necessário, o mestre de origem pode ser clonado automaticamente para a apresentação de destino. Aspose.Slides rastreia mestres clonados automaticamente para que slides repetidos que usam o mesmo mestre de origem não causem clonagem repetida desse mestre.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — anexa o slide clonado a um [IMasterSlide](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/imasterslide/) de destino específico. Aspose.Slides procura um layout correspondente sob esse mestre por tipo ou nome do layout.
- `addClone(sourceSlide, destinationLayout)` — anexa o slide clonado diretamente a um [ILayoutSlide](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ilayoutslide/) de destino específico.

O mestre ou layout passado para uma sobrecarga `addClone` deve pertencer à apresentação **destino**, não à apresentação de origem.

## **Mesclar apresentações inteiras e preservar a formatação de origem**

A mesclagem mais simples copia cada slide da apresentação de origem para a apresentação de destino. Esta é a escolha apropriada quando os slides importados devem manter seu tema, mestre e relações de layout originais.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide);
    }

    destination.save("merged.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

A apresentação resultante pode conter vários mestres quando a origem e o destino utilizam designs diferentes. Isso é esperado quando a formatação de origem é preservada intencionalmente.

## **Mesclar slides selecionados**

Você não precisa clonar todos os slides. O exemplo a seguir importa apenas índices de slides selecionados da apresentação de origem.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    int[] slideIndexes = { 0, 2, 4 };

    for (int index : slideIndexes) {
        destination.getSlides().addClone(source.getSlides().get_Item(index));
    }

    destination.save("merged-selected-slides.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Valide os índices de slides antes de clonar quando eles vêm de entrada do usuário ou de configuração externa.

## **Mesclar slides usando um mestre de destino**

Use a sobrecarga [addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) quando os slides importados devem seguir um mestre que já pertence à apresentação de destino.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    IMasterSlide destinationMaster = destination.getMasters().get_Item(0);

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, destinationMaster, true);
    }

    destination.save("merged-with-destination-master.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Aspose.Slides seleciona um layout apropriado sob o mestre especificado correspondendo ao tipo ou nome do layout de origem. Se nenhum layout adequado existir e `allowCloneMissingLayout` for `true`, o layout de origem é clonado para que o slide possa ser adicionado. Se for `false`, uma [PptxEditException](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/pptxeditexception/) é lançada.

Use `false` quando quiser que a mesclagem falhe em vez de introduzir um layout adicional no mestre de destino.

## **Mesclar slides usando um layout de destino específico**

Use a sobrecarga [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) quando você souber exatamente qual layout de destino os slides importados devem usar.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    ILayoutSlide destinationLayout = destination.getLayoutSlides().get_Item(0);

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, destinationLayout);
    }

    destination.save("merged-with-destination-layout.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Aplicar um layout de destino altera a relação de layout herdada; não redesenha o conteúdo do slide de origem. Se os layouts de origem e destino tiverem estruturas de marcadores diferentes, inspecione o resultado para confirmar que a formatação herdada e o comportamento dos marcadores estão adequados.

## **Mesclar apresentações com tamanhos de slide diferentes**

Apresentações com dimensões de slide diferentes podem ser mescladas, mas clonar um slide para uma apresentação com outro tamanho de slide não redesenha automaticamente seu conteúdo para a nova tela. As formas podem aparecer deslocadas, escaladas inesperadamente ou fora da área visível do slide.

Uma abordagem prática é redimensionar a apresentação de origem antes de clonar. O método [SlideSize.setSize](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) pode escalar o conteúdo existente ao mudar as dimensões do slide. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/slidesizescaletype/) escala o conteúdo para caber no tamanho solicitado.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    SizeF sourceSize = source.getSlideSize().getSize();
    SizeF destinationSize = destination.getSlideSize().getSize();

    if (sourceSize.getWidth() != destinationSize.getWidth() || 
        sourceSize.getHeight() != destinationSize.getHeight()) {
        source.getSlideSize().setSize(
            destinationSize.getWidth(), 
            destinationSize.getHeight(), 
            SlideSizeScaleType.EnsureFit);
    }

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide);
    }

    destination.save("merged-same-slide-size.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Redimensionar altera o objeto da apresentação de origem na memória. Se precisar da apresentação de origem original inalterada para outras operações, abra uma instância separada para a mesclagem.

## **Mesclar slides em uma seção da apresentação**

O loop básico de clonagem de slides não recria a hierarquia de seções da apresentação de origem. Se as seções forem importantes na saída, crie ou selecione seções na apresentação de destino e clone os slides nelas explicitamente com [addClone(ISlide, ISection)](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-).

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    ISection importedSection = destination.getSections().appendEmptySection("Imported slides");

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, importedSection);
    }

    destination.save("merged-with-section.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Os slides clonados são anexados à seção de destino especificada. Para preservar várias seções de origem, recrie essas seções no destino e mapeie cada slide de origem para a seção de destino correspondente.

## **Mesclar várias apresentações com segurança**

O exemplo de ponta a ponta a seguir usa a primeira apresentação como destino, normaliza o tamanho do slide de cada fonte adicional, mantém cada fonte aberta apenas enquanto está sendo copiada e salva o arquivo final uma única vez.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

String[] inputFiles = { "part1.pptx", "part2.pptx", "part3.pptx" };

Presentation merged = new Presentation(inputFiles[0]);
try {
    SizeF mergedSize = merged.getSlideSize().getSize();

    for (int fileIndex = 1; fileIndex < inputFiles.length; fileIndex++) {
        Presentation source = new Presentation(inputFiles[fileIndex]);
        try {
            SizeF sourceSize = source.getSlideSize().getSize();

            if (sourceSize.getWidth() != mergedSize.getWidth() || 
                sourceSize.getHeight() != mergedSize.getHeight()) {
                source.getSlideSize().setSize(
                    mergedSize.getWidth(), 
                    mergedSize.getHeight(), 
                    SlideSizeScaleType.EnsureFit);
            }

            for (ISlide slide : source.getSlides()) {
                merged.getSlides().addClone(slide);
            }
        } finally {
            source.dispose();
        }
    }

    merged.save("merged.pptx", SaveFormat.Pptx);
} finally {
    merged.dispose();
}
```

Esta é uma base útil para preservar a formatação de origem dos slides importados. Se sua saída precisar usar um único tema de destino, substitua a chamada simples `addClone(slide)` pela sobrecarga de mestre de destino ou layout de destino apropriada mostrada anteriormente.

## **Considerações práticas**

### **Mestres, layouts e fidelidade de formatação**

A clonagem padrão de slides pode trazer automaticamente um mestre de origem necessário para a apresentação de destino. Aspose.Slides mantém um registro interno para mestres clonados automaticamente a fim de evitar clonar o mesmo mestre repetidamente. Mestres clonados manualmente não são rastreados por esse registro, portanto evite pré-clonar mestres a menos que precise de controle explícito sobre a estrutura do mestre.

Não presuma que dois mestres ou layouts com o mesmo nome sejam visualmente equivalentes. Se um modelo corporativo precisar controlar a aparência final, escolha explicitamente um mestre ou layout de destino e verifique o resultado após a mesclagem.

### **Notas e comentários**

As notas do apresentador e os comentários dos slides estão associados ao conteúdo do slide e são copiados quando um slide é clonado. Aspose.Slides também expõe APIs dedicadas para [notas de apresentação](https://docs.aspose.com/slides/pt/androidjava/presentation-notes/) e [comentários de apresentação](https://docs.aspose.com/slides/pt/androidjava/presentation-comments/).

Se a formatação da página de notas for importante, verifique a apresentação mesclada porque os mestres de notas são objetos ao nível da apresentação e podem diferir entre arquivos de origem. Para fluxos de revisão, verifique também os autores dos comentários e os comentários encadeados após combinar arquivos de diferentes autores ou modelos.

### **Imagens, áudio, vídeo, objetos OLE e links externos**

Os slides podem referenciar recursos ao nível da apresentação, como imagens, áudio incorporado, vídeo incorporado e dados OLE. Clone o próprio slide em vez de copiar apenas suas formas visíveis para que Aspose.Slides possa manter os relacionamentos do slide com seus recursos.

Recursos incorporados e vinculados devem ser tratados de forma diferente. Um áudio, vídeo, objeto OLE ou hyperlink vinculado permanece dependente de seu destino externo; clonar um slide não transforma um link externo em conteúdo incorporado. Teste os caminhos e URLs de recursos vinculados no ambiente onde a apresentação mesclada será aberta.

Aspose.Slides rastreia explicitamente mestres clonados automaticamente, mas isso não deve ser considerado como garantia geral de que recursos binários idênticos de apresentações de origem não relacionadas serão sempre deduplicados. Se o tamanho do arquivo de saída for importante, inspecione o pacote mesclado e meça o resultado em vez de confiar na deduplicação implícita.

### **Fontes incorporadas e disponibilidade de fontes**

As fontes são gerenciadas ao nível da apresentação. Se a tipografia precisar permanecer consistente entre máquinas, não presuma que clonar slides sozinho garante que todas as fontes necessárias estejam disponíveis no ambiente de destino. Você pode inspecionar fontes incorporadas com [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) e gerenciar a incorporação explicitamente como descrito em [Incorporar fontes em apresentações](https://docs.aspose.com/slides/pt/androidjava/embedded-font/).

Verifique também se você tem permissão para incorporar as fontes usadas pelos arquivos de origem. Licenças de fontes podem restringir a incorporação.

### **Apresentações protegidas por senha**

Uma origem protegida por senha deve ser aberta com sucesso antes que seus slides possam ser clonados. Forneça a senha via [LoadOptions.setPassword](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-).

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation source = new Presentation("protected.pptx", loadOptions);
try {
    // Trabalhe com a apresentação descriptografada.
} finally {
    source.dispose();
}
```

Abrir uma origem criptografada não aplica automaticamente a mesma proteção à apresentação de destino. Configure a proteção de saída separadamente quando necessário.

### **Apresentações grandes e uso de memória**

Apresentações grandes contendo imagens de alta resolução, áudio, vídeo ou outros objetos binários grandes podem consumir memória significativa. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) fornece controles para o tratamento de BLOBs e uso de arquivos temporários. Veja [Gerenciar BLOBs de apresentação](https://docs.aspose.com/slides/pt/androidjava/manage-blob/) para estratégias de arquivos grandes.

Para arquivos grandes, prefira carregar a partir de caminhos de arquivo quando possível, descarte cada apresentação de origem assim que ela for mesclada e evite salvar repetidamente resultados intermediários a menos que o fluxo de trabalho exija pontos de verificação.

### **Segurança em threads**

Não carregue, modifique, salve ou clone a mesma [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/) simultaneamente a partir de múltiplas threads. Mantenha cada instância de apresentação confinada a uma operação de mesclagem. Se paralelizar trabalhos independentes, use instâncias de apresentação independentes e siga as [diretrizes de multithreading do Aspose.Slides](https://docs.aspose.com/slides/pt/androidjava/multithreading/).

## **FAQ**

**Como manter o design original de cada apresentação de origem?**

Use [`addClone(sourceSlide)`](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) sem fornecer um mestre ou layout de destino. Aspose.Slides pode clonar automaticamente o mestre de origem quando ele for necessário para o slide importado.

**Como fazer com que os slides importados usem o tema de destino?**

Use a sobrecarga que aceita um mestre de destino. Passe um mestre da apresentação de destino, não da origem. Aspose.Slides tentará mapear cada slide de origem para um layout adequado sob esse mestre.

**Quando devo usar um layout de destino específico em vez de um mestre de destino?**

Use um layout específico quando cada slide importado deve usar um layout conhecido. Use um mestre quando desejar que o Aspose.Slides selecione entre os layouts desse mestre com base no tipo ou nome do layout de origem.

**É possível mesclar apresentações com tamanhos de slide diferentes?**

Sim, mas o conteúdo do slide não é redesenhado automaticamente para as dimensões de destino. Redimensione a apresentação de origem primeiro quando precisar de posicionamento previsível, por exemplo com [SlideSize.setSize](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) e [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/slidesizescaletype/).

**Posso mesclar apresentações PPT, PPTX e ODP em um único arquivo?**

Sim. Carregue cada apresentação de origem, clone os slides necessários em um destino e salve o destino em um formato de saída compatível. Como os formatos de apresentação não suportam exatamente o mesmo conjunto de recursos, verifique o conteúdo complexo após mesclagens entre formatos. Consulte [Supported File Formats](https://docs.aspose.com/slides/pt/androidjava/supported-file-formats/).

**As seções de origem são preservadas automaticamente?**

Não por um loop básico que apenas clona slides. Recrie as seções necessárias no destino e use a sobrecarga de seção de [addClone](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) quando a estrutura de seções precisar ser preservada.

**As notas do apresentador e os comentários são preservados?**

Eles são copiados com o slide clonado. Para fluxos de trabalho que dependem da estilização do mestre de notas, autores de comentários ou dados de revisão encadeada, verifique o resultado mesclado porque esses cenários envolvem estruturas ao nível da apresentação assim como conteúdo ao nível do slide.

**O que acontece com áudio, vídeo, objetos OLE e hyperlinks?**

O conteúdo incorporado é transportado como parte dos relacionamentos de recursos do slide clonado. Links externos permanecem externos, portanto seus arquivos ou URLs de destino ainda devem estar disponíveis após a mesclagem.

**As fontes incorporadas de cada origem são garantidas como disponíveis na apresentação mesclada?**

Não confie apenas na clonagem de slides para implantação de fontes. Inspecione as fontes incorporadas no destino e gerencie explicitamente a incorporação de fontes ou a disponibilidade de fontes externas quando a tipografia for importante.

**Como mesclar um arquivo protegido por senha?**

Abra-o com a [LoadOptions.setPassword](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) correta, depois clone seus slides normalmente. A proteção de saída é configurada separadamente.

**Como devo lidar com apresentações muito grandes?**

Use o gerenciamento de BLOBs quando objetos binários grandes dominarem o uso de memória, prefira o carregamento por caminho de arquivo para arquivos muito grandes, descarte as apresentações de origem prontamente e salve o resultado final apenas quando necessário.

**Posso mesclar slides a partir de múltiplas threads?**

Não use a mesma instância de [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/) simultaneamente a partir de múltiplas threads. Mantenha cada operação de mesclagem isolada em suas próprias instâncias de apresentação.