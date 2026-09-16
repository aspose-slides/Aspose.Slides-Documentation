---
title: Gerenciar Hyperlinks de Apresentação em PHP
linktitle: Gerenciar Hyperlinks
type: docs
weight: 20
url: /pt/php-java/manage-hyperlinks/
keywords:
- adicionar URL
- adicionar hyperlink
- criar hyperlink
- formatar hyperlink
- remover hyperlink
- atualizar hyperlink
- hyperlink de texto
- hyperlink de slide
- hyperlink de forma
- hyperlink de imagem
- hyperlink de vídeo
- hyperlink mutável
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Adicionar, formatar, atualizar e remover hyperlinks em apresentações PowerPoint e OpenDocument com Aspose.Slides para PHP via Java, usando exemplos em PHP."
---
## **Introdução**

Um hiperlink conecta o conteúdo da apresentação a um site ou a um local dentro da apresentação. No PowerPoint, os hiperlinks geralmente servem a dois propósitos:

* Abrir um site a partir de texto, de uma forma ou de um quadro de mídia.
* Navegar para outro slide, por exemplo, a partir de um índice.

Aspose.Slides for PHP via Java permite adicionar esses links, controlar sua aparência e som, atualizar suas propriedades e removê-los. Os exemplos abaixo mostram como trabalhar com hiperlinks em elementos individuais e como acessar hiperlinks no nível da apresentação, slide ou quadro de texto. Eles assumem que o PHP/Java Bridge e o wrapper Aspose.Slides PHP estão inicializados. Membros da API sem uma página de referência PHP vinculam à API Java subjacente.

{{% alert color="info" title="Nota" %}}
Você também pode editar apresentações com o [editor online gratuito Aspose PowerPoint](https://products.aspose.app/slides/pt/editor).
{{% /alert %}} 

## **Adicionar Hyperlinks de URL**

Você pode atribuir um URL de site a texto, a uma forma ou a um quadro de mídia. O elemento ao qual você atribui o hiperlink determina a área clicável: uma parte de texto vincula o texto selecionado, enquanto uma forma ou quadro vincula o objeto do slide.

### **Adicionar Hyperlinks de URL ao Texto**

Para vincular texto a um site, passe um [Hyperlink](https://reference.aspose.com/slides/pt/php-java/aspose.slides/hyperlink/) para o método [setHyperlinkClick](https://reference.aspose.com/slides/pt/php-java/aspose.slides/portionformat/sethyperlinkclick/) da parte de texto, como mostrado abaixo. Apenas essa parte do texto se torna clicável.

```php
use aspose\slides\Hyperlink;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $textShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50, false);
    $textShape->addTextFrame("Aspose: File Format APIs");
    $portionFormat = $textShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $portionFormat->getHyperlinkClick()->setTooltip("Explore Aspose file format APIs");
    $portionFormat->setFontHeight(32);

    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Adicionar Hyperlinks de URL a Formas e Quadros de Mídia**

Para tornar uma forma ou quadro clicável, chame seu método [setHyperlinkClick](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/sethyperlinkclick/). O hiperlink pertence ao próprio objeto, e não a uma parte de texto dentro dele.

O mesmo procedimento se aplica a quadros de imagem, áudio e vídeo: atribua o hiperlink ao quadro e chame [setTooltip](https://reference.aspose.com/slides/pt/php-java/aspose.slides/hyperlink/settooltip/) se necessário.

O exemplo a seguir torna um retângulo clicável:

```php
use aspose\slides\Hyperlink;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50);

    $shape->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $shape->getHyperlinkClick()->setTooltip("Explore Aspose file format APIs");

    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Usar Hyperlinks para Criar um Índice**

Hiperlinks internos permitem que os leitores saltem de um índice para um slide específico. O exemplo a seguir usa [setInternalHyperlinkClick](https://reference.aspose.com/slides/pt/php-java/aspose.slides/hyperlinkmanager/setinternalhyperlinkclick/) para vincular o texto “Page 2” no primeiro slide ao segundo slide.

```php
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $secondSlide = $presentation->getSlides()->addEmptySlide($firstSlide->getLayoutSlide());

    $tableOfContents = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 300, 100);
    $tableOfContents->getFillFormat()->setFillType(FillType::NoFill);
    $tableOfContents->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    $tableOfContents->getTextFrame()->getParagraphs()->clear();

    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $paragraph->setText("Title of slide 2 .......... ");

    $linkPortion = new Portion();
    $linkPortion->setText("Page 2");
    $linkPortion->getPortionFormat()->getHyperlinkManager()->setInternalHyperlinkClick($secondSlide);

    $paragraph->getPortions()->add($linkPortion);
    $tableOfContents->getTextFrame()->getParagraphs()->add($paragraph);

    $presentation->save("link_to_slide.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Formatar Hyperlinks**

### **Cor**

O método [setColorSource](https://reference.aspose.com/slides/pt/php-java/aspose.slides/hyperlink/setcolorsource/) de [Hyperlink](https://reference.aspose.com/slides/pt/php-java/aspose.slides/hyperlink/) determina se um hiperlink usa a cor de hiperlink da apresentação ou a formatação da parte de texto. Para aplicar uma cor de texto personalizada, selecione [HyperlinkColorSource::PortionFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/hyperlinkcolorsource/) e defina a cor de preenchimento da parte. Esse recurso foi introduzido no PowerPoint 2019; versões mais antigas não aplicam essa configuração.

O exemplo a seguir adiciona dois hiperlinks de texto ao mesmo slide. O primeiro usa preenchimento de texto vermelho, enquanto o segundo mantém a cor padrão do hiperlink.

```php
use aspose\slides\FillType;
use aspose\slides\Hyperlink;
use aspose\slides\HyperlinkColorSource;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $coloredShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 450, 50, false);
    $coloredShape->addTextFrame("This hyperlink uses a custom color.");
    $coloredPortionFormat = $coloredShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $coloredPortionFormat->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $coloredPortionFormat->getHyperlinkClick()->setColorSource(HyperlinkColorSource::PortionFormat);
    $coloredPortionFormat->getFillFormat()->setFillType(FillType::Solid);
    $coloredPortionFormat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $defaultShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 450, 50, false);
    $defaultShape->addTextFrame("This hyperlink uses the default color.");
    $defaultShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));

    $presentation->save("presentation-out-hyperlink.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```
### **Som**

Um hiperlink pode reproduzir um som quando ativado ou interromper um som que já está sendo reproduzido. Use os métodos a seguir para configurar esses comportamentos:

- [Hyperlink::setSound](https://reference.aspose.com/slides/pt/php-java/aspose.slides/hyperlink/setsound/) especifica o áudio associado ao hyperlink.
- [Hyperlink::setStopSoundOnClick](https://reference.aspose.com/slides/pt/php-java/aspose.slides/hyperlink/setstopsoundonclick/) controla se a ativação do hyperlink interrompe o som anterior.

#### **Adicionar um Som ao Hyperlink**

O exemplo a seguir carrega `sampleaudio.wav` e o associa a um botão no primeiro slide. Clicar no botão reproduz o som e navega para o próximo slide. Uma segunda forma naquele slide interrompe o som anterior ao ser clicada, sem executar uma ação de navegação.

```php
use aspose\slides\Hyperlink;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $audioFile = new Java("java.io.File", "sampleaudio.wav");
    $audioPath = $audioFile->toPath();
    $audioData = java("java.nio.file.Files")->readAllBytes($audioPath);
    $hyperlinkSound = $presentation->getAudios()->addAudio($audioData);

    $firstSlide = $presentation->getSlides()->get_Item(0);

    $playButton = $firstSlide->getShapes()->addAutoShape(ShapeType::SoundButton, 100, 100, 100, 50);
    $playButton->setHyperlinkClick(Hyperlink::getNextSlide());

    if (!java_values($playButton->getHyperlinkClick()->getStopSoundOnClick()) && java_is_null($playButton->getHyperlinkClick()->getSound()))
    {
        $playButton->getHyperlinkClick()->setSound($hyperlinkSound);
    }

    $secondSlide = $presentation->getSlides()->addEmptySlide($firstSlide->getLayoutSlide());

    $stopButton = $secondSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 100, 50);
    $stopButton->setHyperlinkClick(Hyperlink::getNoAction());

    $stopButton->getHyperlinkClick()->setStopSoundOnClick(true);

    $presentation->save("hyperlink-sound.pptx", SaveFormat::Pptx);
} catch (JavaException $exception) {
    echo "Unable to read the audio file: " . $exception->getMessage() . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

#### **Extrair o Som de um Hyperlink**

O exemplo a seguir abre a apresentação criada acima e lê o áudio do hyperlink da primeira forma para a memória através de [getSound](https://reference.aspose.com/slides/pt/php-java/aspose.slides/hyperlink/getsound/) e [getBinaryData](https://reference.aspose.com/slides/pt/php-java/aspose.slides/audio/getbinarydata/).

```php
use aspose\slides\Presentation;

$presentation = new Presentation("hyperlink-sound.pptx");
try {
    if (java_values($presentation->getSlides()->size()) > 0 && java_values($presentation->getSlides()->get_Item(0)->getShapes()->size()) > 0) {
        $hyperlink = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getHyperlinkClick();
        $sound = java_is_null($hyperlink) ? null : $hyperlink->getSound();
        if (!java_is_null($sound)) {
            $audioData = $sound->getBinaryData();
            echo "Extracted " . strlen(java_values($audioData)) . " bytes of hyperlink audio." . PHP_EOL;
        } else {
            echo "The first shape has no hyperlink sound." . PHP_EOL;
        }
    } else {
        echo "The presentation has no first slide or shape to inspect." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **Configurações de Tooltip e Interação**

Você pode chamar os seguintes métodos de [Hyperlink](https://reference.aspose.com/slides/pt/php-java/aspose.slides/hyperlink/) após atribuir um hyperlink a texto ou a uma forma:

- [setTooltip](https://reference.aspose.com/slides/pt/php-java/aspose.slides/hyperlink/settooltip/) define o texto que um visualizador pode exibir como dica para o link.
- [setTargetFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/hyperlink/settargetframe/) especifica o frame de destino dentro de um frameset HTML pai, quando aplicável.
- [setHistory](https://reference.aspose.com/slides/pt/php-java/aspose.slides/hyperlink/sethistory/) controla se a ativação do link adiciona seu destino à lista de hyperlinks visualizados.
- [setHighlightClick](https://reference.aspose.com/slides/pt/php-java/aspose.slides/hyperlink/sethighlightclick/) controla se o hyperlink é destacado quando clicado.

## **Remover Hyperlinks de Apresentações**

Use [getAnyHyperlinks](https://reference.aspose.com/slides/pt/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) para coletar contêineres de hyperlink, incluindo links de partes de texto, antes de alterá‑los. O exemplo a seguir remove ambos os tipos de ativação do primeiro slide. Para remover apenas um tipo, chame somente [removeHyperlinkClick](https://reference.aspose.com/slides/pt/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/) ou [removeHyperlinkMouseOver](https://reference.aspose.com/slides/pt/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/); remover a ação de clique não remove sua contraparte de mouse‑over.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    if (java_values($presentation->getSlides()->size()) > 0) {
        $containers = [];
        foreach ($presentation->getSlides()->get_Item(0)->getHyperlinkQueries()->getAnyHyperlinks() as $container) {
            $containers[] = $container;
        }
        foreach ($containers as $container) {
            $container->getHyperlinkManager()->removeHyperlinkClick();
            $container->getHyperlinkManager()->removeHyperlinkMouseOver();
        }
        $presentation->save("pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
    } else {
        echo "The presentation has no slides to process." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Para remoção incondicional, [removeAllHyperlinks](https://reference.aspose.com/slides/pt/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/) remove ambos os tipos de ativação no escopo selecionado em uma única chamada. Para limpeza seletiva e cobertura de mestres, layouts e notas, veja [Relatório, Sanitização e Verificação de Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Criar um Inventário Completo de Hyperlinks**

Antes de distribuir uma apresentação, faça o inventário de suas ações interativas e de seus links da web. [getAnyHyperlinks](https://reference.aspose.com/slides/pt/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) retorna objetos [IHyperlinkContainer](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ihyperlinkcontainer/), não uma lista plana de strings de URL. Inspecione tanto [getHyperlinkClick](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) quanto [getHyperlinkMouseOver](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) em cada contêiner. Eles são independentes: o mesmo contêiner pode expor ambas as ações, portanto um relatório completo precisa de até duas linhas por contêiner.

A varredura apenas de hyperlinks em nível de forma pode perder links anexados a partes de texto. Consulte o escopo apropriado em vez disso e retenha os contêineres retornados para que você possa atualizar ou remover suas ações posteriormente.

### **Consultar Escopos de Apresentação, Slide e Quadro de Texto**

A classe [HyperlinkQueries](https://reference.aspose.com/slides/pt/php-java/aspose.slides/hyperlinkqueries/) está disponível através de [Presentation::getHyperlinkQueries](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/gethyperlinkqueries/), [IBaseSlide::getHyperlinkQueries](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ibaseslide/#getHyperlinkQueries--) e [TextFrame::getHyperlinkQueries](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/gethyperlinkqueries/). Cada escopo suporta as mesmas consultas:

- [getHyperlinkClicks](https://reference.aspose.com/slides/pt/php-java/aspose.slides/hyperlinkqueries/gethyperlinkclicks/) retorna contêineres com ação de clique.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/pt/php-java/aspose.slides/hyperlinkqueries/gethyperlinkmouseovers/) retorna contêineres com ação de mouse‑over.
- [getAnyHyperlinks](https://reference.aspose.com/slides/pt/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) retorna contêineres com uma ou ambas as ações.

O exemplo a seguir cria `hyperlink-audit-input.pptx` com um link de clique externo, um link de mouse‑over de arquivo, navegação interna de slide, um link de mouse‑over de texto e uma ação de macro. Ele não executa nenhuma dessas ações. As três consultas funcionam em todos os escopos; as contagens descrevem contêineres, não o total de ações. O escopo de quadro de texto exclui os links da própria forma que o contém.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

function printQueryCounts($scope, $queries) {
    $clickCount = java_values($queries->getHyperlinkClicks()->size());
    $mouseOverCount = java_values($queries->getHyperlinkMouseOvers()->size());
    $anyCount = java_values($queries->getAnyHyperlinks()->size());
    echo "$scope: click=$clickCount, mouse-over=$mouseOverCount, any=$anyCount" . PHP_EOL;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $destination = $presentation->getSlides()->addEmptySlide($slide->getLayoutSlide());
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 60);
    $shape->getTextFrame()->setText("Click the text to go to slide 2");
    $shape->getHyperlinkManager()->setExternalHyperlinkClick("https://example.com/");
    $shape->getHyperlinkClick()->setTooltip("Public website");
    $shape->getHyperlinkManager()->setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

    $portionFormat = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat->getHyperlinkManager()->setInternalHyperlinkClick($destination);
    $portionFormat->getHyperlinkManager()->setExternalHyperlinkMouseOver("https://example.com/help");
    $macroButton = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 120, 200, 60);
    $macroButton->getHyperlinkManager()->setMacroHyperlinkClick("ReviewPresentation");

    printQueryCounts("Presentation", $presentation->getHyperlinkQueries());
    printQueryCounts("Slide 1", $slide->getHyperlinkQueries());
    printQueryCounts("Text frame", $shape->getTextFrame()->getHyperlinkQueries());
    $presentation->save("hyperlink-audit-input.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Para este exemplo, as consultas de apresentação e slide relatam três contêineres de clique, dois de mouse‑over e três contêineres com qualquer ação. A consulta de quadro de texto relata um contêiner em cada categoria.

### **Classificar Ações e Destinos**

Use [Hyperlink::getActionType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/hyperlink/getactiontype/) para interpretar uma ação antes de interpretar seu destino. Os valores de [HyperlinkActionType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/hyperlinkactiontype/) abrangem mais que navegação web:

| Values | Meaning for an audit |
| --- | --- |
| `Hyperlink` | Hyperlink externo; inspecione a URL e seu esquema. |
| `JumpSpecificSlide` | Navegação interna para um slide específico. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Navegação interna de apresentação incorporada, resolvida no contexto da apresentação. |
| `JumpEndShow`, `StartCustomSlideShow` | Encerrar a apresentação atual ou iniciar uma apresentação personalizada. |
| `StartMacro` | Executar uma macro. |
| `StartProgram` | Iniciar um programa. |
| `OpenFile`, `OpenPresentation` | Abrir um arquivo ou outra apresentação; revise separadamente das URLs da web. |
| `StartStopMedia` | Iniciar ou interromper a reprodução de mídia. |
| `NoAction`, `Unknown` | Nenhuma ação de navegação ou ação desconhecida que requer revisão. |

Leia destinos externos de [getExternalUrl](https://reference.aspose.com/slides/pt/php-java/aspose.slides/hyperlink/getexternalurl/) e destinos internos específicos de [getTargetSlide](https://reference.aspose.com/slides/pt/php-java/aspose.slides/hyperlink/gettargetslide/). Ações internas e comandos incorporados podem não ter URL externa; uma URL vazia não significa que o contêiner não tenha ação. Preserve o valor retornado por [getExternalUrlOriginal](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) quando ele difere da URL normalizada e inclua o tooltip retornado por [getTooltip](https://reference.aspose.com/slides/pt/php-java/aspose.slides/hyperlink/gettooltip/) quando disponível.

### **Relatar, Sanitizar e Verificar Hyperlinks**

O exemplo PHP a seguir lê uma apresentação existente (use o arquivo criado acima), grava `hyperlink-audit.json`, aplica uma política, salva `hyperlink-sanitized.pptx` e reabre‑a para verificar novamente ambos os tipos de ativação. Ele coleta os contêineres antes de alterá‑los e usa igualdade de referência para evitar processar o mesmo contêiner duas vezes. As consultas de apresentação cobrem slides ordinários; para um inventário de todo o pacote, ele também consulta explicitamente mestres, layouts, notas e os mestres de notas e folhetos quando presentes.

O relatório registra um índice de slide baseado em 1 e [getSlideId](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ibaseslide/#getSlideId--) quando disponível. [ISlideComponent::getSlide](https://reference.aspose.com/slides/pt/java/com.aspose.slides/islidecomponent/#getSlide--) fornece o slide proprietário para contêineres suportados. Mestres, layouts e notas não têm índice de slide ordinário e são identificados pelo seu escopo. Contêineres de forma e de formatação de partes de texto são rotulados separadamente; outros tipos de contêiner mantêm seu nome de tipo em tempo de execução. Cada contêiner recebe um ID local ao relatório para que suas duas ações possam ser correlacionadas. O relatório armazena os tipos de ação como as constantes inteiras definidas pela enumeração PHP.

Esta política de aplicação deliberadamente restritiva permite apenas URLs HTTPS absolutas e destinos internos de slide válidos. Ela rejeita macros, programas, ações de arquivo, outras ações de apresentação, ações desconhecidas e outros esquemas de URL. Essas rejeições são decisões de política, não um veredicto de segurança da Aspose.Slides. HTTPS sozinho não estabelece confiança: adicione listas de permissões de hosts e outras verificações para sua aplicação. Tanto as URLs externas originais quanto as normalizadas são verificadas. O exemplo audita metadados sem seguir links ou executar ações.

Para remediação, o [getHyperlinkManager](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) do contêiner suporta [setExternalHyperlinkClick](https://reference.aspose.com/slides/pt/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/), [removeHyperlinkClick](https://reference.aspose.com/slides/pt/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/) e [removeHyperlinkMouseOver](https://reference.aspose.com/slides/pt/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/). Aqui, links externos de clique proibidos são substituídos por uma página fixa HTTPS; outros cliques proibidos e ações de mouse‑over proibidas são removidos independentemente. Defina `$replaceExternalClicks` como `false` para remover todas as violações de política. Escolha uma página de substituição de propriedade da aplicação antes da implantação.

A bandeira de exportação do relatório usa uma política conservadora de revisão de PDF: sinalize ações de mouse‑over e qualquer coisa que não seja um link externo ou um salto de slide específico como potencialmente não suportada. É uma dica de revisão, não um teste de capacidade ou garantia de que links não sinalizados sobreviverão à exportação. Exportações suportadas de [PDF](/slides/pt/php-java/convert-powerpoint-to-pdf/) e [HTML](/slides/pt/php-java/convert-powerpoint-to-html/) podem preservar hyperlinks, dependendo da ação, opções de exportação e visualizador. Imagens raster [images](/slides/pt/php-java/convert-powerpoint-to-png/) e [video](/slides/pt/php-java/convert-powerpoint-to-video/) não podem preservar hyperlinks interativos; sinalize todas as ações ao auditar para essas saídas.

```php
use aspose\slides\HyperlinkActionType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

class HyperlinkAudit {
    public function slideIndex($presentation, $slide) {
        if (java_is_null($slide)) return null;
        for ($index = 0; $index < java_values($presentation->getSlides()->size()); $index++) {
            if (java_values($presentation->getSlides()->get_Item($index)->equals($slide))) return $index + 1;
        }
        return null;
    }

    public function isHttps($value) {
        if ($value === null || $value === '') return false;
        $parts = parse_url($value);
        return $parts !== false && isset($parts['scheme'], $parts['host']) && strcasecmp($parts['scheme'], 'https') === 0 && $parts['host'] !== '';
    }

    public function policyViolation($link) {
        if (java_is_null($link)) return null;
        $action = java_values($link->getActionType());
        if ($action === HyperlinkActionType::JumpSpecificSlide) {
            return java_is_null($link->getTargetSlide()) ? 'Missing target slide' : null;
        }
        if ($action !== HyperlinkActionType::Hyperlink) return 'Action is not allowed';
        if (!$this->isHttps(java_values($link->getExternalUrl()))) return 'Normalized URL is not absolute HTTPS';
        $original = java_values($link->getExternalUrlOriginal());
        if ($original !== null && $original !== '' && !$this->isHttps($original)) return 'Original URL is not absolute HTTPS';
        return null;
    }

    public function addScope(&$found, $slide) {
        if (!java_is_null($slide)) {
            foreach ($slide->getHyperlinkQueries()->getAnyHyperlinks() as $container) {
                $found[] = $container;
            }
        }
    }

    public function collectContainers($presentation) {
        $found = [];
        foreach ($presentation->getHyperlinkQueries()->getAnyHyperlinks() as $container) {
            $found[] = $container;
        }
        $masters = $presentation->getMasters();
        for ($index = 0; $index < java_values($masters->size()); $index++) {
            $this->addScope($found, $masters->get_Item($index));
        }
        $layouts = $presentation->getLayoutSlides();
        for ($index = 0; $index < java_values($layouts->size()); $index++) {
            $this->addScope($found, $layouts->get_Item($index));
        }
        $slides = $presentation->getSlides();
        for ($index = 0; $index < java_values($slides->size()); $index++) {
            $this->addScope($found, $slides->get_Item($index)->getNotesSlideManager()->getNotesSlide());
        }
        $this->addScope($found, $presentation->getMasterNotesSlideManager()->getMasterNotesSlide());
        $this->addScope($found, $presentation->getMasterHandoutSlideManager()->getMasterHandoutSlide());
        $seen = new Java('java.util.IdentityHashMap');
        $unique = [];
        foreach ($found as $container) {
            if (!java_values($seen->containsKey($container))) {
                $seen->put($container, true);
                $unique[] = $container;
            }
        }
        return $unique;
    }

    public function addRow(&$rows, $presentation, $link, $activation, $container, $containerId) {
        if (java_is_null($link)) return;
        $ownerSlide = java_instanceof($container, java('com.aspose.slides.ISlideComponent')) ? $container->getSlide() : null;
        $targetSlide = $link->getTargetSlide();
        $violation = $this->policyViolation($link);
        $ownerType = java_instanceof($container, java('com.aspose.slides.IShape')) ? 'Shape' : (java_instanceof($container, java('com.aspose.slides.IPortionFormat')) ? 'Text portion' : java_values($container->getClass()->getSimpleName()));
        $action = java_values($link->getActionType());
        $ordinaryAction = $action === HyperlinkActionType::Hyperlink || $action === HyperlinkActionType::JumpSpecificSlide;
        $externalUrl = java_values($link->getExternalUrl());
        $originalUrl = java_values($link->getExternalUrlOriginal());
        $rows[] = [
            'ContainerId' => $containerId,
            'SlideIndex' => $this->slideIndex($presentation, $ownerSlide),
            'SlideId' => java_is_null($ownerSlide) ? null : java_values($ownerSlide->getSlideId()),
            'Scope' => java_is_null($ownerSlide) ? null : java_values($ownerSlide->getClass()->getSimpleName()),
            'OwnerType' => $ownerType,
            'Activation' => $activation,
            'ActionType' => $action,
            'ExternalUrl' => $externalUrl,
            'TargetSlideIndex' => $this->slideIndex($presentation, $targetSlide),
            'TargetSlideId' => java_is_null($targetSlide) ? null : java_values($targetSlide->getSlideId()),
            'Tooltip' => java_values($link->getTooltip()),
            'OriginalExternalUrl' => $originalUrl === $externalUrl ? null : $originalUrl,
            'PotentiallyUnsafe' => $violation !== null,
            'PolicyViolation' => $violation,
            'TargetExport' => 'PDF',
            'PotentiallyUnsupportedByExport' => $activation === 'mouse-over' || !$ordinaryAction
        ];
    }
}

$replaceExternalClicks = true;
$replacementUrl = 'https://example.com/blocked-link';
$audit = new HyperlinkAudit();
$presentation = new Presentation('hyperlink-audit-input.pptx');
try {
    $containers = $audit->collectContainers($presentation);
    $rows = [];
    foreach ($containers as $index => $container) {
        $audit->addRow($rows, $presentation, $container->getHyperlinkClick(), 'click', $container, $index + 1);
        $audit->addRow($rows, $presentation, $container->getHyperlinkMouseOver(), 'mouse-over', $container, $index + 1);
    }
    $json = json_encode($rows, JSON_PRETTY_PRINT | JSON_UNESCAPED_SLASHES);
    if ($json === false) {
        echo 'Unable to encode the audit report: ' . json_last_error_msg() . PHP_EOL;
    } elseif (file_put_contents('hyperlink-audit.json', $json . PHP_EOL) === false) {
        echo 'Unable to write the audit report.' . PHP_EOL;
    } else {
        foreach ($containers as $container) {
            $click = $container->getHyperlinkClick();
            if ($audit->policyViolation($click) !== null) {
                if ($replaceExternalClicks && java_values($click->getActionType()) === HyperlinkActionType::Hyperlink) {
                    $container->getHyperlinkManager()->setExternalHyperlinkClick($replacementUrl);
                } else {
                    $container->getHyperlinkManager()->removeHyperlinkClick();
                }
            }
            if ($audit->policyViolation($container->getHyperlinkMouseOver()) !== null) {
                $container->getHyperlinkManager()->removeHyperlinkMouseOver();
            }
        }
        $presentation->save('hyperlink-sanitized.pptx', SaveFormat::Pptx);

        $reopened = new Presentation('hyperlink-sanitized.pptx');
        try {
            $remainingContainers = $audit->collectContainers($reopened);
            $violations = 0;
            foreach ($remainingContainers as $container) {
                if ($audit->policyViolation($container->getHyperlinkClick()) !== null) $violations++;
                if ($audit->policyViolation($container->getHyperlinkMouseOver()) !== null) $violations++;
            }
            echo 'Audit rows: ' . count($rows) . '; prohibited actions after reopening: ' . $violations . PHP_EOL;
            if ($violations !== 0) {
                echo 'Verification failed: do not distribute the saved presentation.' . PHP_EOL;
            }
        } finally {
            $reopened->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

Com a entrada criada acima, o relatório contém cinco linhas de ação. O link de mouse‑over de arquivo e o clique de macro são removidos, enquanto os links HTTPS e a navegação interna de slide permanecem. A verificação exibe zero ações proibidas. Uma entrada contendo um URL externo de clique proibido também aciona o ramo de substituição. Um contêiner com clique permitido e mouse‑over proibido mantém sua ação de clique.

Essa limpeza seletiva difere de [removeAllHyperlinks](https://reference.aspose.com/slides/pt/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/), que remove ambos os tipos de ativação em todo o escopo selecionado, independentemente da política. A verificação aqui verifica apenas as ações de hyperlink; não remove projetos VBA incorporados, objetos OLE ou outro conteúdo ativo, e não valida um PDF ou arquivo HTML exportado.

## **FAQ**

**Como posso vincular a uma seção ou ao seu primeiro slide?**

Seções no PowerPoint agrupam slides, mas um hyperlink interno tem como alvo um slide individual. Para criar navegação para uma seção, vincule ao primeiro slide dessa seção.

**Posso anexar um hyperlink a elementos de slide mestre para que funcione em todos os slides?**

Sim. Elementos de slide mestre e de layout suportam hyperlinks. Links nesses elementos ficam disponíveis durante a apresentação nos slides que utilizam o mestre ou layout correspondentes.

**Os hyperlinks serão preservados ao exportar para PDF, HTML, imagens ou vídeo?**

Exportações suportadas de PDF e HTML podem preservar hyperlinks; imagens raster e vídeo não podem. Veja as considerações de exportação em [Relatório, Sanitização e Verificação de Hyperlinks](#report-sanitize-and-verify-hyperlinks).