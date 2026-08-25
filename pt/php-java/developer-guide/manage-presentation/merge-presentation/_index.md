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
- mesclar PPTX
- mesclar ODP
- combinar PowerPoint
- combinar apresentações
- combinar slides
- combinar PPT
- combinar PPTX
- combinar ODP
- PHP
- Aspose.Slides
description: "Aprenda como mesclar apresentações PowerPoint e OpenDocument em PHP clonando slides, controlando mestres e layouts, redimensionando o conteúdo dos slides, preservando seções e tratando arquivos protegidos ou grandes."
---
## **Visão geral**

Aspose.Slides for PHP via Java mescla apresentações clonando slides de uma [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/) para outra. A operação principal é [SlideCollection::addClone()](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slidecollection/addclone/), que pode preservar a formatação do slide de origem ou anexar o slide clonado a um mestre ou layout na apresentação de destino.

Este artigo cobre os fluxos de trabalho de mesclagem mais comuns:

- mesclar todos os slides preservando sua formatação de origem;
- mesclar slides selecionados;
- aplicar um mestre da apresentação de destino;
- aplicar um layout específico da apresentação de destino;
- normalizar diferentes tamanhos de slide antes da mesclagem;
- adicionar slides clonados a uma seção;
- mesclar várias apresentações em um fluxo de trabalho de ponta a ponta;
- tratar mestres, recursos, notas, comentários, mídia, fontes, senhas, arquivos grandes e questões de multithreading.

## **Como a clonagem de slides afeta mestres e layouts**

Um slide herda grande parte de sua aparência de seu layout e mestre. Por esse motivo, a sobrecarga de clonagem que você escolher determina como o slide mesclado é integrado na apresentação de destino.

Use [SlideCollection::addClone()](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slidecollection/addclone/) de uma das seguintes maneiras:

- `addClone(sourceSlide)` — preserva o layout e a formatação do slide de origem. Quando necessário, o mestre de origem pode ser clonado automaticamente para a apresentação de destino. Aspose.Slides rastreia mestres clonados automaticamente para que slides repetidos que utilizam o mesmo mestre de origem não causem a clonagem repetida desse mestre.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — anexa o slide clonado a um [MasterSlide](https://reference.aspose.com/slides/pt/php-java/aspose.slides/masterslide/) específico de destino. Aspose.Slides procura um layout correspondente sob esse mestre por tipo ou nome de layout.
- `addClone(sourceSlide, destinationLayout)` — anexa o slide clonado diretamente a um [LayoutSlide](https://reference.aspose.com/slides/pt/php-java/aspose.slides/layoutslide/) específico de destino.

O mestre ou layout passado para uma sobrecarga `addClone` deve pertencer à apresentação **de destino**, não à apresentação de origem.

## **Mesclar apresentações inteiras e preservar a formatação de origem**

A mesclagem mais simples copia cada slide da apresentação de origem para a apresentação de destino. Essa é a escolha apropriada quando os slides importados devem manter seu tema original, mestre e relacionamentos de layout.

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

A apresentação resultante pode conter múltiplos mestres quando a origem e o destino utilizam designs diferentes. Isso é esperado quando a formatação de origem é preservada intencionalmente.

## **Mesclar slides selecionados**

Você não precisa clonar todos os slides. O exemplo a seguir importa apenas índices de slides selecionados da apresentação de origem.

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

Valide os índices de slides antes de cloná‑los quando eles provêm de entrada do usuário ou de configuração externa.

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

Aspose.Slides seleciona um layout adequado sob o mestre especificado correspondendo ao tipo ou nome do layout de origem. Se nenhum layout adequado existir e `allowCloneMissingLayout` for `true`, o layout de origem é clonado para que o slide possa ser adicionado. Se for `false`, uma [PptxEditException](https://reference.aspose.com/slides/pt/php-java/aspose.slides/pptxeditexception/) é lançada.

Use `false` quando você quiser que a mesclagem falhe em vez de introduzir um layout adicional no mestre de destino.

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

Aplicar um layout de destino altera o relacionamento de layout herdado; não redesenha o conteúdo do slide de origem. Se os layouts de origem e destino possuem estruturas de placeholders diferentes, inspecione o resultado para confirmar que a formatação herdada e o comportamento dos placeholders estão adequados.

## **Mesclar apresentações com diferentes tamanhos de slide**

Apresentações com diferentes dimensões de slide podem ser mescladas, mas clonar um slide em uma apresentação com outro tamanho de slide não redesenha automaticamente seu conteúdo para a nova tela. Assim, formas podem aparecer deslocadas, dimensionadas inesperadamente ou fora da área visível do slide.

Uma abordagem prática é redimensionar a apresentação de origem antes de clonar. O método [SlideSize::setSize()](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slidesize/setsize/) pode dimensionar o conteúdo existente ao mudar as dimensões do slide. [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slidesizescaletype/) dimensiona o conteúdo para caber no tamanho solicitado.

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

Redimensionar altera o objeto da apresentação de origem na memória. Se precisar da apresentação de origem original inalterada para outras operações, abra uma instância separada para a mesclagem.

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

Os slides clonados são acrescentados à seção de destino especificada. Para preservar várias seções de origem, enumere [Presentation::getSections](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation/#getSections), recupere os slides atuais de cada seção de origem com [Section::getSlidesListOfSection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Section/#getSlidesListOfSection), recrie as seções no destino e clone cada slide retornado para sua respectiva seção de destino. Consulte [Manage Slide Sections](/slides/pt/php-java/slide-section/) para um exemplo completo de enumeração de seções, incluindo seções vazias e alterações estruturais.

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

Esta é uma base útil para preservar a formatação de origem dos slides importados. Se sua saída precisar usar um único tema de destino, substitua a chamada simples `addClone($slide)` pela sobrecarga de mestre de destino ou layout de destino apropriada mostrada anteriormente.

## **Considerações práticas**

### **Mestres, layouts e fidelidade de formatação**

A clonagem padrão de slides pode trazer automaticamente um mestre de origem necessário para a apresentação de destino. Aspose.Slides mantém um registro interno de mestres clonados automaticamente para evitar clonar o mesmo mestre repetidamente. Mestres clonados manualmente não são rastreados por esse registro, portanto evite pré-clonar mestres a menos que precise de controle explícito sobre a estrutura de mestres.

Não presuma que dois mestres ou layouts com o mesmo nome sejam visualmente equivalentes. Se um modelo corporativo deve controlar a aparência final, escolha explicitamente um mestre ou layout de destino e verifique o resultado após a mesclagem.

### **Notas e comentários**

As notas do apresentador e os comentários de slide estão associados ao conteúdo do slide e são copiados quando um slide é clonado. Aspose.Slides também expõe APIs dedicadas para [presentation notes](/slides/pt/php-java/presentation-notes/) e [presentation comments](/slides/pt/php-java/presentation-comments/).

Se a formatação da página de notas for importante, verifique a apresentação mesclada porque os mestres de notas são objetos ao nível da apresentação e podem diferir entre arquivos de origem. Para fluxos de revisão, também verifique os autores dos comentários e os comentários encadeados após combinar arquivos de diferentes autores ou modelos.

### **Imagens, áudio, vídeo, objetos OLE e links externos**

Slides podem referenciar recursos ao nível da apresentação, como imagens, áudio incorporado, vídeo incorporado e dados OLE. Clone o próprio slide ao invés de copiar apenas suas formas visíveis para que Aspose.Slides possa manter os relacionamentos do slide com seus recursos.

Recursos incorporados e vinculados devem ser tratados de forma diferente. Um áudio, vídeo, objeto OLE ou hyperlink vinculado continua dependente de seu alvo externo; clonar um slide não transforma um link externo em conteúdo incorporado. Teste os caminhos e URLs de recursos vinculados no ambiente onde a apresentação mesclada será aberta.

Aspose.Slides rastreia explicitamente mestres clonados automaticamente, mas isso não deve ser tratado como garantia geral de que recursos binários idênticos de apresentações de origem não relacionadas serão sempre deduplicados. Se o tamanho do arquivo de saída for importante, inspecione o pacote mesclado e meça o resultado ao invés de confiar na deduplicação implícita.

### **Fontes incorporadas e disponibilidade de fontes**

As fontes são gerenciadas ao nível da apresentação. Se a tipografia deve permanecer consistente entre máquinas, não presuma que clonar slides sozinho garante que todas as fontes necessárias estejam disponíveis no ambiente de destino. Você pode inspecionar fontes incorporadas com [FontsManager::getEmbeddedFonts()](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fontsmanager/getembeddedfonts/) e gerenciar a incorporação explicitamente como descrito em [Embed Fonts in Presentations](/slides/pt/php-java/embedded-font/).

Também verifique se você tem permissão para incorporar as fontes usadas pelos arquivos de origem. Licenças de fontes podem restringir a incorporação.

### **Apresentações protegidas por senha**

Uma origem protegida por senha deve ser aberta com sucesso antes que seus slides possam ser clonados. Forneça a senha através de [LoadOptions::setPassword()](https://reference.aspose.com/slides/pt/php-java/aspose.slides/loadoptions/setpassword/).

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

Abrir uma origem criptografada não aplica automaticamente a mesma proteção à apresentação de destino. Configure a proteção de saída separadamente quando necessário.

### **Apresentações grandes e uso de memória**

Apresentações grandes contendo imagens de alta resolução, áudio, vídeo ou outros objetos binários grandes podem consumir memória significativa. [LoadOptions::getBlobManagementOptions()](https://reference.aspose.com/slides/pt/php-java/aspose.slides/loadoptions/getblobmanagementoptions/) fornece controles para o manejo de BLOBs e uso de arquivos temporários. Veja [Open Presentations](/slides/pt/php-java/open-presentation/#open-large-presentations) para um exemplo de arquivo grande em PHP via Java.

Para arquivos grandes, prefira carregar a partir de caminhos de arquivo quando possível, descarte cada apresentação de origem assim que for mesclada e evite salvar repetidamente resultados intermediários a menos que o fluxo de trabalho exija pontos de verificação.

### **Segurança de thread**

Não carregue, modifique, salve ou clone instâncias de [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/) em múltiplas threads. Essas operações não são suportadas para uso multithread em PHP via Java. Se precisar de trabalhos de mesclagem paralelos, execute-os em processos separados monothread, com cada processo usando suas próprias instâncias de apresentação, e siga as diretrizes de multithreading do [Aspose.Slides](/slides/pt/php-java/multithreading/).

## **FAQ**

**Como mantenho o design original de cada apresentação de origem?**

Use [SlideCollection::addClone](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slidecollection/addclone/) sem fornecer um mestre ou layout de destino. Aspose.Slides pode clonar automaticamente o mestre de origem quando ele for necessário para o slide importado.

**Como faço os slides importados usarem o tema de destino?**

Use a sobrecarga que aceita um mestre de destino. Passe um mestre da apresentação de destino, não da origem. Aspose.Slides tentará mapear cada slide de origem para um layout adequado sob esse mestre.

**Quando devo usar um layout de destino específico ao invés de um mestre de destino?**

Use um layout específico quando cada slide importado deve usar um layout conhecido. Use um mestre quando quiser que Aspose.Slides selecione entre os layouts daquele mestre com base no tipo ou nome do layout de origem.

**Apresentações com tamanhos de slide diferentes podem ser mescladas?**

Sim, mas o conteúdo do slide não é automaticamente redesenhado para as dimensões de destino. Redimensione a apresentação de origem primeiro quando precisar de posicionamento previsível, por exemplo com [SlideSize::setSize()](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slidesize/setsize/) e [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slidesizescaletype/).

**Posso mesclar apresentações PPT, PPTX e ODP em um único arquivo?**

Sim. Carregue cada apresentação de origem, clone os slides necessários em um destino único e salve o destino em um formato de saída suportado. Como os formatos de apresentação não suportam exatamente o mesmo conjunto de recursos, verifique o conteúdo complexo após mesclagens entre formatos. Consulte [Supported File Formats](/slides/pt/php-java/supported-file-formats/).

**As seções de origem são preservadas automaticamente?**

Não por um loop básico que apenas clona slides. Recrie as seções necessárias no destino e use a sobrecarga de seção de [addClone](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slidecollection/addclone/) quando a estrutura de seções precisar ser preservada.

**As notas do apresentador e os comentários são preservados?**

Eles são copiados com o slide clonado. Para fluxos que dependem da estilização do mestre de notas, autores de comentários ou dados de revisão encadeados, verifique o resultado mesclado pois esses cenários envolvem estruturas ao nível da apresentação e também conteúdo ao nível do slide.

**O que acontece com áudio, vídeo, objetos OLE e hyperlinks?**

Conteúdo incorporado é mantido como parte dos relacionamentos de recursos do slide clonado. Links externos permanecem externos, portanto seus arquivos ou URLs de destino ainda devem estar disponíveis após a mesclagem.

**As fontes incorporadas de todas as fontes são garantidas como disponíveis na apresentação mesclada?**

Não dependa apenas da clonagem de slides para implantação de fontes. Inspecione as fontes incorporadas no destino e gerencie explicitamente a incorporação de fontes ou a disponibilidade de fontes externas quando a tipografia for importante.

**Como mesclo um arquivo protegido por senha?**

Abra-o com a [LoadOptions::setPassword()](https://reference.aspose.com/slides/pt/php-java/aspose.slides/loadoptions/setpassword/) correta, então clone seus slides normalmente. A proteção de saída é configurada separadamente.

**Como devo lidar com apresentações muito grandes?**

Use o gerenciamento de BLOB quando objetos binários grandes dominam o uso de memória, prefira carregamento por caminho de arquivo para arquivos muito grandes, descarte as apresentações de origem prontamente e salve o resultado final somente quando necessário.

**Posso mesclar slides de múltiplas threads?**

Carregar, salvar ou clonar apresentações em múltiplas threads não é suportado em PHP via Java. Para trabalho paralelo, use processos monothread separados e mantenha as instâncias de apresentações isoladas dentro de cada processo.