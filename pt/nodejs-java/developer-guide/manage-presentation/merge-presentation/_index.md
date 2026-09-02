---
title: Mesclar apresentações de forma eficiente em JavaScript
linktitle: Mesclar apresentações
type: docs
weight: 40
url: /pt/nodejs-java/merge-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Saiba como mesclar apresentações PowerPoint e OpenDocument em JavaScript clonando slides, controlando mestres e layouts, redimensionando o conteúdo dos slides, preservando seções e lidando com arquivos protegidos ou grandes."
---
## **Visão geral**

Aspose.Slides for Node.js via Java mescla apresentações clonando slides de uma [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/) em outra. A operação principal é [SlideCollection.addClone](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-), que pode preservar a formatação do slide de origem ou anexar o slide clonado a um mestre ou layout na apresentação de destino.

Este artigo abrange os fluxos de mesclagem mais comuns:

- mesclar todos os slides preservando a formatação da origem;
- mesclar slides selecionados;
- aplicar um mestre da apresentação de destino;
- aplicar um layout específico da apresentação de destino;
- normalizar diferentes tamanhos de slide antes da mesclagem;
- adicionar slides clonados a uma seção;
- mesclar várias apresentações em um fluxo de trabalho de ponta a ponta;
- lidar com mestres, recursos, notas, comentários, mídia, fontes, senhas, arquivos grandes e questões de multithreading.

## **Como a clonagem de slides afeta mestres e layouts**

Um slide herda grande parte de sua aparência do seu layout e mestre. Por esse motivo, a sobrecarga de clonagem escolhida determina como o slide mesclado é integrado à apresentação de destino.

Use [SlideCollection.addClone](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slidecollection/) de uma destas maneiras:

- `addClone(sourceSlide)` — preserva o layout e a formatação do slide de origem. Quando necessário, o mestre de origem pode ser clonado automaticamente para a apresentação de destino. Aspose.Slides rastreia mestres clonados automaticamente para que slides repetidos que usam o mesmo mestre de origem não causem clonagem repetida desse mestre.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — anexa o slide clonado a um [MasterSlide](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/masterslide/) de destino específico. Aspose.Slides procura um layout correspondente sob esse mestre por tipo ou nome de layout.
- `addClone(sourceSlide, destinationLayout)` — anexa o slide clonado diretamente a um [LayoutSlide](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/layoutslide/) de destino específico.

O mestre ou layout passado para uma sobrecarga `addClone` deve pertencer à **apresentação de destino**, não à apresentação de origem.

## **Mesclar apresentações inteiras e preservar a formatação da origem**

A mesclagem mais simples copia cada slide da apresentação de origem para a apresentação de destino. Esta é a escolha adequada quando os slides importados devem manter seu tema, mestre e relacionamentos de layout originais.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i));
    }

    destination.save("merged.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

A apresentação resultante pode conter vários mestres quando a origem e o destino usam designs diferentes. Isso é esperado quando a formatação da origem é intencionalmente preservada.

## **Mesclar slides selecionados**

Você não precisa clonar todos os slides. O exemplo a seguir importa apenas os índices de slide selecionados da apresentação de origem.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const slideIndexes = [0, 2, 4];

    for (const index of slideIndexes) {
        destination.getSlides().addClone(source.getSlides().get_Item(index));
    }

    destination.save("merged-selected-slides.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Valide os índices de slide antes de clonar quando eles vierem de entrada do usuário ou de configuração externa.

## **Mesclar slides usando um mestre de destino**

Use a sobrecarga [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) quando os slides importados devem seguir um mestre que já pertence à apresentação de destino.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const destinationMaster = destination.getMasters().get_Item(0);

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i), destinationMaster, true);
    }

    destination.save("merged-with-destination-master.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Aspose.Slides seleciona um layout apropriado sob o mestre especificado correspondendo ao tipo ou nome do layout de origem. Se nenhum layout adequado existir e `allowCloneMissingLayout` for `true`, o layout de origem é clonado para que o slide possa ser adicionado. Se for `false`, uma [PptxEditException](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/pptxeditexception/) é lançada.

Use `false` quando quiser que a mesclagem falhe em vez de introduzir um layout adicional no mestre de destino.

## **Mesclar slides usando um layout de destino específico**

Use a sobrecarga [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ILayoutSlide-) quando você souber exatamente qual layout de destino os slides importados devem usar.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const destinationLayout = destination.getLayoutSlides().get_Item(0);

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i), destinationLayout);
    }

    destination.save("merged-with-destination-layout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Aplicar um layout de destino altera o relacionamento de layout herdado; não redesigna o conteúdo do slide de origem. Se os layouts de origem e destino tiverem estruturas de placeholders diferentes, verifique o resultado para confirmar que a formatação herdada e o comportamento dos placeholders são adequados.

## **Mesclar apresentações com diferentes tamanhos de slide**

Apresentações com dimensões de slide diferentes podem ser mescladas, mas clonar um slide em uma apresentação com outro tamanho de slide não redesigna automaticamente seu conteúdo para a nova área de desenho. Formas podem aparecer deslocadas, escaladas inesperadamente ou fora da área visível do slide.

Uma abordagem prática é redimensionar a apresentação de origem antes de clonar. O método [SlideSize.setSize](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-) pode escalar o conteúdo existente enquanto altera as dimensões do slide. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slidesizescaletype/) escala o conteúdo para caber no tamanho solicitado.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const sourceSize = source.getSlideSize().getSize();
    const destinationSize = destination.getSlideSize().getSize();
    const sizesDiffer = sourceSize.getWidth() !== destinationSize.getWidth() || 
                        sourceSize.getHeight() !== destinationSize.getHeight();

    if (sizesDiffer) {
        source.getSlideSize().setSize(
            destinationSize.getWidth(), 
            destinationSize.getHeight(), 
            aspose.slides.SlideSizeScaleType.EnsureFit);
    }

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i));
    }

    destination.save("merged-same-slide-size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Redimensionar altera o objeto de apresentação de origem na memória. Se precisar da apresentação de origem original inalterada para outras operações, abra uma instância separada para a mesclagem.

## **Mesclar slides em uma seção de apresentação**

O loop básico de clonagem de slides não recria a hierarquia de seções da apresentação de origem. Se as seções importam na saída, crie ou selecione seções na apresentação de destino e clone os slides nelas explicitamente com [addClone(Slide, Section)](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-).

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const importedSection = destination.getSections().appendEmptySection("Imported slides");

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i), importedSection);
    }

    destination.save("merged-with-section.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Os slides clonados são anexados à seção de destino especificada. Para preservar várias seções de origem, enumere [Presentation.getSections](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/#getSections), recupere os slides atuais de cada seção de origem com [Section.getSlidesListOfSection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/section/#getSlidesListOfSection), recrie as seções no destino e clone cada slide retornado em sua respectiva seção de destino. Veja [Manage Slide Sections](/slides/pt/nodejs-java/slide-section/) para um exemplo completo de enumeração de seções, incluindo seções vazias e alterações estruturais.

## **Mesclar múltiplas apresentações com segurança**

O exemplo de ponta a ponta a seguir usa a primeira apresentação como destino, normaliza o tamanho do slide de cada origem adicional, mantém cada origem aberta somente enquanto está sendo copiada e salva o arquivo final uma única vez.

```javascript
const aspose = require("aspose.slides.via.java");

const inputFiles = ["part1.pptx", "part2.pptx", "part3.pptx"];

const merged = new aspose.slides.Presentation(inputFiles[0]);
try {
    const mergedSize = merged.getSlideSize().getSize();

    for (let fileIndex = 1; fileIndex < inputFiles.length; fileIndex++) {
        const source = new aspose.slides.Presentation(inputFiles[fileIndex]);
        try {
            const sourceSize = source.getSlideSize().getSize();
            const sizesDiffer = sourceSize.getWidth() !== mergedSize.getWidth() || 
                                sourceSize.getHeight() !== mergedSize.getHeight();

            if (sizesDiffer) {
                source.getSlideSize().setSize(
                    mergedSize.getWidth(), 
                    mergedSize.getHeight(), 
                    aspose.slides.SlideSizeScaleType.EnsureFit);
            }

            for (let slideIndex = 0; slideIndex < source.getSlides().size(); slideIndex++) {
                merged.getSlides().addClone(source.getSlides().get_Item(slideIndex));
            }
        } finally {
            source.dispose();
        }
    }

    merged.save("merged.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    merged.dispose();
}
```

Esta é uma boa base para preservar a formatação de origem dos slides importados. Se sua saída precisar usar um único tema de destino, substitua a chamada simples `addClone(sourceSlide)` pela sobrecarga de mestre ou layout de destino apropriada mostrada anteriormente.

## **Considerações práticas**

### **Mestres, layouts e fidelidade de formatação**

A clonagem padrão de slides pode trazer automaticamente um mestre de origem necessário para a apresentação de destino. Aspose.Slides mantém um registro interno para mestres clonados automaticamente, a fim de evitar a clonagem repetida do mesmo mestre. Mestres clonados manualmente não são rastreados por esse registro, portanto evite pré-clonar mestres a menos que precise de controle explícito sobre a estrutura do mestre.

Não presuma que dois mestres ou layouts com o mesmo nome sejam visualmente equivalentes. Se um modelo corporativo deve controlar a aparência final, escolha explicitamente um mestre ou layout de destino e verifique o resultado após a mesclagem.

### **Notas e comentários**

Notas do apresentador e comentários de slide estão associados ao conteúdo do slide e são copiados quando um slide é clonado. Aspose.Slides também expõe APIs dedicadas para [presentation notes](/slides/pt/nodejs-java/presentation-notes/) e [presentation comments](/slides/pt/nodejs-java/presentation-comments/).

Se a formatação da página de notas for importante, verifique a apresentação mesclada porque mestres de notas são objetos ao nível da apresentação e podem diferir entre arquivos de origem. Para fluxos de revisão, também verifique os autores dos comentários e comentários encadeados após combinar arquivos de diferentes autores ou modelos.

### **Imagens, áudio, vídeo, objetos OLE e links externos**

Slides podem referenciar recursos ao nível da apresentação, como imagens, áudio embutido, vídeo embutido e dados OLE. Clone o slide inteiro em vez de copiar apenas suas formas visíveis para que Aspose.Slides possa manter os relacionamentos do slide com seus recursos.

Recursos incorporados e vinculados devem ser tratados de forma diferente. Um áudio, vídeo, objeto OLE ou hyperlink vinculado permanece dependente de seu alvo externo; clonar um slide não transforma um link externo em conteúdo incorporado. Teste os caminhos e URLs de recursos vinculados no ambiente onde a apresentação mesclada será aberta.

Aspose.Slides rastreia explicitamente mestres clonados automaticamente, mas isso não deve ser interpretado como garantia geral de que recursos binários idênticos de apresentações de origem não relacionadas serão sempre deduplicados. Se o tamanho do arquivo de saída for importante, inspecione o pacote mesclado e meça o resultado em vez de contar com deduplicação implícita.

### **Fontes incorporadas e disponibilidade de fontes**

As fontes são gerenciadas ao nível da apresentação. Se a tipografia deve permanecer consistente entre máquinas, não presuma que clonar slides por si só garante que todas as fontes necessárias estejam disponíveis no ambiente de destino. Você pode inspecionar fontes incorporadas com [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fontsmanager/#getEmbeddedFonts--) e gerenciar a incorporação explicitamente conforme descrito em [Embed Fonts in Presentations](/slides/pt/nodejs-java/embedded-font/).

Também verifique se você tem permissão para incorporar as fontes usadas pelos arquivos de origem. Licenças de fontes podem restringir a incorporação.

### **Apresentações protegidas por senha**

Uma origem protegida por senha deve ser aberta com sucesso antes que seus slides possam ser clonados. Forneça a senha através de [LoadOptions.setPassword](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/loadoptions/#setPassword-String-).

```javascript
const aspose = require("aspose.slides.via.java");

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

const source = new aspose.slides.Presentation("protected.pptx", loadOptions);
try {
    // Trabalhe com a apresentação descriptografada.
} finally {
    source.dispose();
}
```

Abrir uma origem criptografada não aplica automaticamente a mesma proteção à apresentação de destino. Configure a proteção de saída separadamente quando necessário.

### **Apresentações grandes e uso de memória**

Apresentações grandes contendo imagens de alta resolução, áudio, vídeo ou outros objetos binários grandes podem consumir memória significativa. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions--) fornece controles para gerenciamento de BLOBs e uso de arquivos temporários. Consulte [Manage Presentation BLOBs](/slides/pt/nodejs-java/manage-blob/) para estratégias de arquivos grandes.

Para arquivos grandes, prefira carregar a partir de caminhos de arquivo quando possível, descarte cada apresentação de origem assim que ela for mesclada e evite salvar resultados intermediários repetidamente, a menos que o fluxo de trabalho exija pontos de verificação.

### **Segurança de thread**

Não carregue, salve ou clone uma instância de [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/) em múltiplas threads. Essas operações não são suportadas para uso multithread. Se precisar paralelizar trabalhos de mesclagem independentes, use vários processos de thread única, cada um com suas próprias instâncias de apresentação, e siga as diretrizes de multithreading da [Aspose.Slides multithreading guidance](/slides/pt/nodejs-java/multithreading/).

## **FAQ**

**Como mantenho o design original de cada apresentação de origem?**

Use [addClone](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-) sem fornecer um mestre ou layout de destino. Aspose.Slides pode clonar automaticamente o mestre de origem quando ele é necessário para o slide importado.

**Como faço os slides importados usarem o tema de destino?**

Use a sobrecarga que aceita um mestre de destino. Passe um mestre da apresentação de destino, não da origem. Aspose.Slides tentará mapear cada slide de origem para um layout apropriado sob esse mestre.

**Quando devo usar um layout de destino específico em vez de um mestre de destino?**

Use um layout específico quando cada slide importado deve usar um layout conhecido. Use um mestre quando quiser que Aspose.Slides selecione entre os layouts desse mestre com base no tipo ou nome do layout de origem.

**É possível mesclar apresentações com diferentes tamanhos de slide?**

Sim, mas o conteúdo do slide não é redesignado automaticamente para as dimensões de destino. Redimensione a apresentação de origem primeiro quando precisar de posicionamento previsível, por exemplo com [SlideSize.setSize](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-) e [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slidesizescaletype/).

**Posso mesclar apresentações PPT, PPTX e ODP em um único arquivo?**

Sim. Carregue cada apresentação de origem, clone os slides necessários em um destino e salve o destino em um formato de saída suportado. Como os formatos de apresentação não suportam exatamente o mesmo conjunto de recursos, verifique o conteúdo complexo após mesclagens entre formatos. Veja [Supported File Formats](/slides/pt/nodejs-java/supported-file-formats/).

**As seções de origem são preservadas automaticamente?**

Não por um loop básico que apenas clona slides. Recrie as seções necessárias no destino e use a sobrecarga de seção de [addClone](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-) quando a estrutura de seções precisar ser preservada.

**As notas do apresentador e comentários são preservados?**

Eles são copiados com o slide clonado. Para fluxos que dependem da estilização do notes-master, autores de comentários ou dados de revisão encadeados, verifique o resultado mesclado, pois esses cenários envolvem estruturas ao nível da apresentação além do conteúdo ao nível do slide.

**O que acontece com áudio, vídeo, objetos OLE e hyperlinks?**

Conteúdos incorporados são transportados como parte dos relacionamentos de recursos do slide clonado. Links externos permanecem externos, portanto seus arquivos ou URLs de destino ainda precisam estar disponíveis após a mesclagem.

**As fontes incorporadas de todas as origens são garantidas na apresentação mesclada?**

Não confie apenas na clonagem de slides para implantação de fontes. Inspecione as fontes incorporadas no destino e gerencie explicitamente a incorporação de fontes ou a disponibilidade de fontes externas quando a tipografia for importante.

**Como mesclo um arquivo protegido por senha?**

Abra-o com o [LoadOptions.setPassword](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/loadoptions/#setPassword-String-) correto, depois clone seus slides normalmente. A proteção de saída é configurada separadamente.

**Como devo lidar com apresentações muito grandes?**

Use o gerenciamento de BLOB quando objetos binários grandes dominarem o uso de memória, prefira carregamento por caminho de arquivo para arquivos muito grandes, descarte apresentações de origem prontamente e salve o resultado final somente quando necessário.

**Posso mesclar slides de múltiplas threads?**

Não carregue, salve ou clone instâncias de apresentação em múltiplas threads. Para trabalhos de mesclagem paralelos, use processos de thread única separados e instâncias de apresentação independentes.