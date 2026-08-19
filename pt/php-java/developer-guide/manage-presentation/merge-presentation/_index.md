---
title: Mesclar apresentações de forma eficiente em PHP
linktitle: Mesclar apresentações
type: docs
weight: 40
url: /pt/php-java/merge-presentation/
keywords:
- mesclar PowerPoint
- mesclar apresentações
- mesclar slides
- mesclar PPT
- mescler PPTX
- mesclar ODP
- combinar PowerPoint
- combinar apresentações
- combinar slides
- combinar PPT
- combinar PPTX
- combinar ODP
- PHP
- Aspose.Slides
description: "Aprenda como mesclar apresentações PowerPoint e OpenDocument em PHP clonando slides, controlando mestres e layouts, redimensionando o conteúdo dos slides, preservando seções e lidando com arquivos protegidos ou grandes."
---
## **Visão geral**

Aspose.Slides for PHP via Java mescla apresentações clonando slides de uma [Apresentação](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/) para outra. A operação principal é [SlideCollection::addClone()](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slidecollection/addclone/), que pode preservar a formatação do slide de origem ou anexar o slide clonado a um mestre ou layout na apresentação de destino.

Este artigo cobre os fluxos de trabalho de mesclagem mais comuns:

- mesclar todos os slides preservando sua formatação de origem;
- mesclar slides selecionados;
- aplicar um mestre da apresentação de destino;
- aplicar um layout específico da apresentação de destino;
- normalizar tamanhos de slide diferentes antes da mesclagem;
- adicionar slides clonados a uma seção;
- mesclar várias apresentações em um fluxo de trabalho de ponta a ponta;
- lidar com mestres, recursos, anotações, comentários, mídia, fontes, senhas, arquivos grandes e questões de multithreading.

## **Como a clonagem de slides afeta mestres e layouts**

Um slide herda grande parte de sua aparência do layout e do mestre. Por esse motivo, a sobrecarga de clonagem que você escolher determina como o slide mesclado é integrado na apresentação de destino.

Use [SlideCollection::addClone()](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slidecollection/addclone/) de uma das seguintes maneiras:

- `addClone(sourceSlide)` — preserva o layout e a formatação do slide de origem. Quando necessário, o mestre de origem pode ser clonado automaticamente para a apresentação de destino. Aspose.Slides rastreia mestres clonados automaticamente para que slides repetidos que utilizem o mesmo mestre de origem não causem clonagem repetida desse mestre.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — anexa o slide clonado a um [MasterSlide](https://reference.aspose.com/slides/pt/php-java/aspose.slides/masterslide/) de destino específico. Aspose.Slides procura um layout correspondente sob esse mestre pelo tipo ou nome do layout.
- `addClone(sourceSlide, destinationLayout)` — anexa o slide clonado diretamente a um [LayoutSlide](https://reference.aspose.com/slides/pt/php-java/aspose.slides/layoutslide/) de destino específico.

O mestre ou layout passado para uma sobrecarga `addClone` deve pertencer à **apresentação de destino**, não à apresentação de origem.

## **Mesclar apresentações inteiras e preservar a formatação de origem**

A mesclagem mais simples copia cada slide da apresentação de origem para a apresentação de destino. Esta é a escolha apropriada quando os slides importados devem manter seu tema, mestre e relacionamentos de layout originais.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

A apresentação resultante pode conter múltiplos mestres quando a origem e o destino usam designs diferentes. Isso é esperado quando a formatação de origem é intencionalmente preservada.

## **Mesclar slides selecionados**

Você não precisa clonar todos os slides. O exemplo a seguir importa apenas os índices de slide selecionados da apresentação de origem.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $slideIndexes = [0, 2, 4];

        foreach ($slideIndexes as $index) {
            $destination->getSlides()->addClone($source->getSlides()->get_Item($index));
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-selected-slides.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Valide os índices de slide antes da clonagem quando eles vierem de entrada do usuário ou de configuração externa.

## **Mesclar slides usando um mestre de destino**

Use a sobrecarga [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slidecollection/addclone/) quando os slides importados devem seguir um mestre que já pertence à apresentação de destino.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $destinationMaster = $destination->getMasters()->get_Item(0);

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide, $destinationMaster, true);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-with-destination-master.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Aspose.Slides seleciona um layout apropriado sob o mestre especificado ao corresponder ao tipo ou nome do layout de origem. Se nenhum layout adequado existir e `allowCloneMissingLayout` for `true`, o layout de origem será clonado para que o slide possa ser adicionado. Se for `false`, uma [PptxEditException](https://reference.aspose.com/slides/pt/php-java/aspose.slides/pptxeditexception/) será lançada.

Use `false` quando desejar que a mesclagem falhe em vez de introduzir um layout adicional no mestre de destino.

## **Mesclar slides usando um layout de destino específico**

Use a sobrecarga [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slidecollection/addclone/) quando você souber exatamente qual layout de destino os slides importados devem usar.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $destinationLayout = $destination->getLayoutSlides()->get_Item(0);

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide, $destinationLayout);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-with-destination-layout.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Aplicar um layout de destino altera a relação de layout herdada; não redesenha o conteúdo do slide de origem. Se os layouts de origem e destino tiverem estruturas de marcadores diferentes, inspecione o resultado para confirmar que a formatação herdada e o comportamento dos marcadores são adequados.

## **Mesclar apresentações com tamanhos de slide diferentes**

Apresentações com dimensões de slide distintas podem ser mescladas, mas clonar um slide em uma apresentação com outro tamanho de slide não redesenha automaticamente seu conteúdo para a nova tela. As formas podem então aparecer deslocadas, escaladas de forma inesperada ou fora da área visível do slide.

Uma abordagem prática é redimensionar a apresentação de origem antes da clonagem. O método [SlideSize::setSize()](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slidesize/setsize/) pode escalar o conteúdo existente ao alterar as dimensões do slide. [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slidesizescaletype/) escala o conteúdo para caber no tamanho solicitado.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $sourceWidth = java_values($source->getSlideSize()->getSize()->getWidth());
        $sourceHeight = java_values($source->getSlideSize()->getSize()->getHeight());
        $destinationWidth = java_values($destination->getSlideSize()->getSize()->getWidth());
        $destinationHeight = java_values($destination->getSlideSize()->getSize()->getHeight());

        if ($sourceWidth != $destinationWidth || $sourceHeight != $destinationHeight) {
            $source->getSlideSize()->setSize($destinationWidth, $destinationHeight, SlideSizeScaleType::EnsureFit);
        }

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-same-slide-size.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Redimensionar altera o objeto da apresentação de origem na memória. Se precisar da apresentação de origem original intacta para outras operações, abra uma instância separada para a mesclagem.

## **Mesclar slides em uma seção de apresentação**

O loop básico de clonagem de slides não recria a hierarquia de seções da apresentação de origem. Se as seções forem importantes na saída, crie ou selecione seções na apresentação de destino e clone os slides nelas explicitamente com [addClone(Slide, Section)](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slidecollection/addclone/).

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $importedSection = $destination->getSections()->appendEmptySection("Imported slides");

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide, $importedSection);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-with-section.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Os slides clonados são acrescentados à seção de destino especificada. Para preservar várias seções de origem, recrie essas seções no destino e mapeie cada slide de origem para a seção de destino correspondente.

## **Mesclar várias apresentações com segurança**

O exemplo a seguir de ponta a ponta usa a primeira apresentação como destino, normaliza o tamanho de slide de cada fonte adicional, mantém cada fonte aberta apenas enquanto está sendo copiada e salva o arquivo final uma única vez.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$inputFiles = ["part1.pptx", "part2.pptx", "part3.pptx"];

$merged = new Presentation($inputFiles[0]);
try {
    $mergedWidth = java_values($merged->getSlideSize()->getSize()->getWidth());
    $mergedHeight = java_values($merged->getSlideSize()->getSize()->getHeight());

    for ($fileIndex = 1; $fileIndex < count($inputFiles); $fileIndex++) {
        $source = new Presentation($inputFiles[$fileIndex]);
        try {
            $sourceWidth = java_values($source->getSlideSize()->getSize()->getWidth());
            $sourceHeight = java_values($source->getSlideSize()->getSize()->getHeight());

            if ($sourceWidth != $mergedWidth || $sourceHeight != $mergedHeight) {
                $source->getSlideSize()->setSize($mergedWidth, $mergedHeight, SlideSizeScaleType::EnsureFit);
            }

            foreach ($source->getSlides() as $slide) {
                $merged->getSlides()->addClone($slide);
            }
        } finally {
            $source->dispose();
        }
    }

    $merged->save("merged.pptx", SaveFormat::Pptx);
} finally {
    $merged->dispose();
}
```

Este é um ponto de partida útil para preservar a formatação de origem dos slides importados. Se sua saída precisar usar um único tema de destino, substitua a chamada simples `addClone($slide)` pela sobrecarga de mestre ou layout de destino apropriada mostrada anteriormente.

## **Considerações práticas**

### **Mestres, layouts e fidelidade de formatação**

A clonagem padrão de slides pode trazer automaticamente um mestre de origem necessário para a apresentação de destino. Aspose.Slides mantém um registro interno de mestres clonados automaticamente para evitar a clonagem repetida do mesmo mestre. Mestres clonados manualmente não são rastreados por esse registro, portanto evite pré-clonar mestres a menos que precise de controle explícito sobre a estrutura do mestre.

Não presuma que dois mestres ou layouts com o mesmo nome sejam visualmente equivalentes. Se um modelo corporativo deve controlar a aparência final, escolha explicitamente um mestre ou layout de destino e verifique o resultado após a mesclagem.

### **Anotações e comentários**

Anotações de orador e comentários de slide estão associados ao conteúdo do slide e são copiados quando um slide é clonado. Aspose.Slides também expõe APIs dedicadas para [presentation notes](https://docs.aspose.com/slides/pt/php-java/presentation-notes/) e [presentation comments](https://docs.aspose.com/slides/pt/php-java/presentation-comments/).

Se a formatação da página de notas for importante, verifique a apresentação mesclada porque mestres de notas são objetos ao nível da apresentação e podem diferir entre arquivos de origem. Para fluxos de revisão, também verifique autores de comentários e comentários encadeados após combinar arquivos de diferentes autores ou modelos.

### **Imagens, áudio, vídeo, objetos OLE e links externos**

Slides podem referenciar recursos ao nível da apresentação, como imagens, áudio incorporado, vídeo incorporado e dados OLE. Clone o próprio slide em vez de copiar apenas suas formas visíveis para que Aspose.Slides mantenha os relacionamentos do slide com seus recursos.

Recursos incorporados e vinculados devem ser tratados de forma diferente. Um áudio, vídeo, objeto OLE ou hyperlink vinculado permanece dependente de seu destino externo; clonar um slide não transforma um link externo em conteúdo incorporado. Teste caminhos e URLs de recursos vinculados no ambiente onde a apresentação mesclada será aberta.

Aspose.Slides rastreia explicitamente mestres clonados automaticamente, mas isso não deve ser interpretado como garantia geral de que recursos binários idênticos de apresentações de origem não relacionadas serão sempre desduplicados. Se o tamanho do arquivo de saída for importante, inspecione o pacote mesclado e meça o resultado em vez de contar com desduplicação implícita.

### **Fontes incorporadas e disponibilidade de fontes**

Fontes são gerenciadas ao nível da apresentação. Se a tipografia precisar permanecer consistente entre máquinas, não presuma que clonar slides sozinho garante que todas as fontes necessárias estejam disponíveis no ambiente de destino. Você pode inspecionar fontes incorporadas com [FontsManager::getEmbeddedFonts()](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fontsmanager/getembeddedfonts/) e gerenciar a incorporação explicitamente conforme descrito em [Embed Fonts in Presentations](https://docs.aspose.com/slides/pt/php-java/embedded-font/).

Também verifique se você tem permissão para incorporar as fontes usadas pelos arquivos de origem. Licenças de fontes podem restringir a incorporação.

### **Apresentações protegidas por senha**

Uma fonte protegida por senha deve ser aberta com sucesso antes que seus slides possam ser clonados. Forneça a senha através de [LoadOptions::setPassword()](https://reference.aspose.com/slides/pt/php-java/aspose.slides/loadoptions/setpassword/).

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("YOUR_PASSWORD");

$source = new Presentation("protected.pptx", $loadOptions);
try {
    // Trabalhe com a apresentação descriptografada.
} finally {
    $source->dispose();
}
```

Abrir uma fonte criptografada não aplica automaticamente a mesma proteção à apresentação de destino. Configure a proteção de saída separadamente quando necessário.

### **Apresentações grandes e uso de memória**

Apresentações grandes contendo imagens de alta resolução, áudio, vídeo ou outros objetos binários grandes podem consumir memória significativa. [LoadOptions::getBlobManagementOptions()](https://reference.aspose.com/slides/pt/php-java/aspose.slides/loadoptions/getblobmanagementoptions/) fornece controles para o tratamento de BLOBs e uso de arquivos temporários. Consulte [Open Presentations](https://docs.aspose.com/slides/pt/php-java/open-presentation/#open-large-presentations) para um exemplo de arquivo grande em PHP via Java.

Para arquivos grandes, prefira carregar a partir de caminhos de arquivo quando possível, libere cada apresentação de origem assim que ela for mesclada e evite salvar resultados intermediários repetidamente, a menos que o fluxo de trabalho exija pontos de verificação.

### **Segurança em threads**

Não carregue, modifique, salve ou clone instâncias de [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/) em múltiplas threads. Essas operações não são suportadas para uso multithread em PHP via Java. Se precisar de trabalhos de mesclagem paralelos, execute-os em processos individuais de thread única, com cada processo usando suas próprias instâncias de apresentação, e siga as diretrizes de [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/pt/php-java/multithreading/).

## **FAQ**

**Como manter o design original de cada apresentação de origem?**

Use [`addClone(sourceSlide)`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slidecollection/addclone/) sem fornecer um mestre ou layout de destino. Aspose.Slides pode clonar automaticamente o mestre de origem quando ele for necessário para o slide importado.

**Como fazer os slides importados usarem o tema do destino?**

Use a sobrecarga que aceita um mestre de destino. Passe um mestre da apresentação de destino, não da origem. Aspose.Slides tentará mapear cada slide de origem para um layout adequado sob esse mestre.

**Quando devo usar um layout de destino específico em vez de um mestre de destino?**

Use um layout específico quando cada slide importado deve usar um layout conhecido. Use um mestre quando desejar que Aspose.Slides selecione entre os layouts desse mestre com base no tipo ou nome do layout de origem.

**Apresentações com tamanhos de slide diferentes podem ser mescladas?**

Sim, mas o conteúdo do slide não é redesenhado automaticamente para as dimensões de destino. Redimensione a apresentação de origem primeiro quando precisar de posicionamento previsível, por exemplo com [SlideSize::setSize()](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slidesize/setsize/) e [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slidesizescaletype/).

**Posso mesclar apresentações PPT, PPTX e ODP em um único arquivo?**

Sim. Carregue cada apresentação de origem, clone os slides necessários em um destino e salve o destino em um formato de saída suportado. Como os formatos de apresentação não suportam exatamente o mesmo conjunto de recursos, verifique o conteúdo complexo após mesclagens entre formatos diferentes. Consulte [Supported File Formats](https://docs.aspose.com/slides/pt/php-java/supported-file-formats/).

**As seções de origem são preservadas automaticamente?**

Não por um loop básico que apenas clona slides. Recrie as seções necessárias no destino e use a sobrecarga de seção de [addClone](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slidecollection/addclone/) quando a estrutura de seções precisar ser preservada.

**Anotações de orador e comentários são preservados?**

Eles são copiados com o slide clonado. Para fluxos que dependem da estilização do mestre de notas, autores de comentários ou dados de revisão encadeada, verifique o resultado mesclado, pois esses cenários envolvem estruturas ao nível da apresentação assim como conteúdo ao nível do slide.

**O que acontece com áudio, vídeo, objetos OLE e hyperlinks?**

Conteúdos incorporados são transportados como parte dos relacionamentos de recursos do slide clonado. Links externos permanecem externos, portanto seus arquivos ou URLs de destino ainda precisam estar disponíveis após a mesclagem.

**Fontes incorporadas de todas as origens são garantidas no arquivo mesclado?**

Não confie apenas na clonagem de slides para implantação de fontes. Inspecione as fontes incorporadas no destino e gerencie explicitamente a incorporação de fontes ou a disponibilidade de fontes externas quando a tipografia for importante.

**Como mesclar um arquivo protegido por senha?**

Abra-o com o [LoadOptions::setPassword()](https://reference.aspose.com/slides/pt/php-java/aspose.slides/loadoptions/setpassword/) correto e, em seguida, clone seus slides normalmente. A proteção de saída é configurada separadamente.

**Como devo lidar com apresentações muito grandes?**

Use o gerenciamento de BLOBs quando objetos binários grandes dominarem o uso de memória, prefira o carregamento por caminho de arquivo para arquivos muito grandes, libere rapidamente as apresentações de origem e salve o resultado final somente quando necessário.

**Posso mesclar slides a partir de múltiplas threads?**

Carregar, salvar ou clonar apresentações em múltiplas threads não é suportado em PHP via Java. Para trabalhos paralelos, use processos individuais de thread única e mantenha as instâncias de apresentação isoladas dentro de cada processo.