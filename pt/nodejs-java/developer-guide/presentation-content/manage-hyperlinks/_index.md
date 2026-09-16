---
title: Gerenciar hiperlinks de apresentação em JavaScript
linktitle: Gerenciar hiperlinks
type: docs
weight: 20
url: /pt/nodejs-java/manage-hyperlinks/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Adicionar, formatar, atualizar e remover hyperlinks em apresentações PowerPoint e OpenDocument com Aspose.Slides para Node.js via Java, usando exemplos em JavaScript."
---
## **Introdução**

Um hyperlink conecta o conteúdo da apresentação a um site ou a um local dentro da apresentação. No PowerPoint, os hyperlinks normalmente servem a dois propósitos:

* Abrir um site a partir de texto, forma ou quadro de mídia.
* Navegar para outro slide, por exemplo, a partir de um índice.

Aspose.Slides for Node.js via Java permite que você adicione esses links, controle sua aparência e som, atualize suas propriedades e os remova. Os exemplos abaixo mostram como trabalhar com hyperlinks em elementos individuais e como acessar hyperlinks no nível da apresentação, slide ou quadro de texto.

{{% alert color="info" title="Note" %}}
Você também pode editar apresentações com o [editor gratuito online Aspose PowerPoint](https://products.aspose.app/slides/pt/editor).
{{% /alert %}} 

## **Adicionar hiperlinks de URL**

Você pode atribuir um URL de site a texto, forma ou quadro de mídia. O elemento ao qual você atribui o hyperlink determina a área clicável: uma parte do texto vincula o texto selecionado, enquanto uma forma ou quadro vincula o objeto do slide.

### **Adicionar hiperlinks de URL ao texto**

Para vincular texto a um site, passe um [Hyperlink](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Hyperlink) ao método [setHyperlinkClick](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/PortionFormat#setHyperlinkClick) da porção de texto, como mostrado abaixo. Apenas aquela porção de texto se torna clicável.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const textShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50, false);
    textShape.addTextFrame("Aspose: File Format APIs");
    const portionFormat = textShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");
    portionFormat.setFontHeight(32);

    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Adicionar hiperlinks de URL a formas e quadros de mídia**

Para tornar uma forma ou quadro clicável, chame seu método [setHyperlinkClick](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Shape#setHyperlinkClick). O hyperlink pertence ao próprio objeto, e não a uma porção de texto dentro dele.

A mesma abordagem se aplica a quadros de imagem, áudio e vídeo: atribua o hyperlink ao quadro e chame [setTooltip](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Hyperlink#setTooltip) se necessário.

O exemplo a seguir torna um retângulo clicável:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50);

    shape.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    shape.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");

    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Usar hiperlinks para criar um índice**

Hyperlinks internos permitem que os leitores saltem de um índice para um slide específico. O exemplo a seguir usa [setInternalHyperlinkClick](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/HyperlinkManager#setInternalHyperlinkClick) para vincular o texto “Page 2” no primeiro slide ao segundo slide.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    const tableOfContents = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 300, 100);
    tableOfContents.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    tableOfContents.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    tableOfContents.getTextFrame().getParagraphs().clear();

    const paragraph = new aspose.slides.Paragraph();
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    paragraph.setText("Title of slide 2 .......... ");

    const linkPortion = new aspose.slides.Portion();
    linkPortion.setText("Page 2");
    linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);

    paragraph.getPortions().add(linkPortion);
    tableOfContents.getTextFrame().getParagraphs().add(paragraph);

    presentation.save("link_to_slide.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Formatar hiperlinks**

### **Cor**

O método [setColorSource](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Hyperlink#setColorSource) de [Hyperlink](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Hyperlink) determina se um hyperlink usa a cor de hyperlink da apresentação ou a formatação da porção de texto. Para aplicar uma cor de texto personalizada, selecione [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/HyperlinkColorSource) e defina a cor de preenchimento da porção. Esse recurso foi introduzido no PowerPoint 2019; versões mais antigas não aplicam essa configuração.

O exemplo a seguir adiciona dois hyperlinks de texto ao mesmo slide. O primeiro usa preenchimento de texto vermelho, enquanto o segundo mantém a cor padrão de hyperlink.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const coloredShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 450, 50, false);
    coloredShape.addTextFrame("This hyperlink uses a custom color.");
    const coloredPortionFormat = coloredShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    coloredPortionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    coloredPortionFormat.getHyperlinkClick().setColorSource(aspose.slides.HyperlinkColorSource.PortionFormat);
    coloredPortionFormat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    coloredPortionFormat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));

    const defaultShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 450, 50, false);
    defaultShape.addTextFrame("This hyperlink uses the default color.");
    defaultShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));

    presentation.save("presentation-out-hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
### **Som**

Um hyperlink pode reproduzir um som quando ativado ou parar um som que já está sendo reproduzido. Use os métodos a seguir para configurar esses comportamentos:

- [Hyperlink.setSound](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Hyperlink#setSound) especifica o áudio associado ao hyperlink.
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Hyperlink#setStopSoundOnClick) controla se a ativação do hyperlink interrompe o som anterior.

#### **Adicionar um som de hyperlink**

O exemplo a seguir carrega `sampleaudio.wav` e o associa a um botão no primeiro slide. Clicar no botão reproduz o som e navega para o próximo slide. Uma segunda forma naquele slide interrompe o som anterior ao ser clicada, sem executar uma ação de navegação.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const audioStream = java.newInstanceSync("java.io.FileInputStream", "sampleaudio.wav");
    let hyperlinkSound;
    try {
        hyperlinkSound = presentation.getAudios().addAudio(audioStream);
    } finally {
        audioStream.close();
    }

    const firstSlide = presentation.getSlides().get_Item(0);

    const playButton = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.SoundButton, 100, 100, 100, 50);
    playButton.setHyperlinkClick(aspose.slides.Hyperlink.getNextSlide());

    if (!playButton.getHyperlinkClick().getStopSoundOnClick() && playButton.getHyperlinkClick().getSound() == null)
    {
        playButton.getHyperlinkClick().setSound(hyperlinkSound);
    }

    const secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    const stopButton = secondSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 100, 50);
    stopButton.setHyperlinkClick(aspose.slides.Hyperlink.getNoAction());

    stopButton.getHyperlinkClick().setStopSoundOnClick(true);

    presentation.save("hyperlink-sound.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

#### **Extrair um som de hyperlink**

O exemplo a seguir abre a apresentação criada acima e lê o áudio do hyperlink da primeira forma para a memória através de [getSound](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Hyperlink#getSound) e [getBinaryData](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Audio#getBinaryData).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("hyperlink-sound.pptx");
try {
    if (presentation.getSlides().size() > 0 && presentation.getSlides().get_Item(0).getShapes().size() > 0) {
        const hyperlink = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getHyperlinkClick();
        const sound = hyperlink == null ? null : hyperlink.getSound();
        if (sound != null) {
            const audioData = sound.getBinaryData();
            console.log("Extracted " + audioData.length + " bytes of hyperlink audio.");
        } else {
            console.log("The first shape has no hyperlink sound.");
        }
    } else {
        console.log("The presentation has no first slide or shape to inspect.");
    }
} finally {
    presentation.dispose();
}
```

### **Configurações de dica de ferramenta e interação**

Depois de atribuir um hyperlink a texto ou forma, você pode chamar os seguintes métodos de [Hyperlink](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Hyperlink):

- [setTooltip](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Hyperlink#setTooltip) define o texto que o visualizador pode exibir como dica para o link.
- [setTargetFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Hyperlink#setTargetFrame) especifica o quadro de destino dentro de um frameset HTML pai, quando aplicável.
- [setHistory](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Hyperlink#setHistory) controla se a ativação do link adiciona seu destino à lista de hyperlinks visualizados.
- [setHighlightClick](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Hyperlink#setHighlightClick) controla se o hyperlink é destacado ao ser clicado.

## **Remover hiperlinks de apresentações**

Use [getAnyHyperlinks](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) para coletar contêineres de hyperlinks, incluindo links de porções de texto, antes de alterá‑los. O exemplo a seguir remove ambos os tipos de ativação do primeiro slide. Para remover apenas um tipo, chame somente [removeHyperlinkClick](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick) ou [removeHyperlinkMouseOver](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver); remover a ação de clique não remove sua contraparte de mouse‑over.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    if (presentation.getSlides().size() > 0) {
        const found = presentation.getSlides().get_Item(0).getHyperlinkQueries().getAnyHyperlinks();
        const containers = [];
        for (let index = 0; index < found.size(); index++) {
            containers.push(found.get_Item(index));
        }
        for (const container of containers) {
            container.getHyperlinkManager().removeHyperlinkClick();
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
        presentation.save("pres-removed-hyperlinks.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("The presentation has no slides to process.");
    }
} finally {
    presentation.dispose();
}
```

Para remoção incondicional, [removeAllHyperlinks](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks) elimina ambos os tipos de ativação no escopo selecionado em uma única chamada. Para limpeza seletiva e cobertura de mestres, layouts e notas, veja [Relatar, limpar e verificar hiperlinks](#report-sanitize-and-verify-hyperlinks).

## **Criar um inventário completo de hiperlinks**

Antes de distribuir uma apresentação, faça o inventário de suas ações interativas assim como de seus links web. [getAnyHyperlinks](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) retorna contêineres de hyperlinks, não uma lista plana de strings URL. Examine tanto [getHyperlinkClick](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Shape#getHyperlinkClick) quanto [getHyperlinkMouseOver](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Shape#getHyperlinkMouseOver) em cada contêiner. Eles são independentes: o mesmo contêiner pode expor ambas as ações, portanto um relatório completo pode precisar de até duas linhas por contêiner.

Escanear apenas hyperlinks ao nível de forma pode deixar de fora links anexados a porções de texto. Consulte o escopo adequado e retenha os contêineres retornados para poder atualizar ou remover suas ações posteriormente.

### **Consultar escopos de apresentação, slide e quadro de texto**

A classe [HyperlinkQueries](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/HyperlinkQueries) está disponível através de [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation#getHyperlinkQueries), [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/BaseSlide#getHyperlinkQueries) e [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/TextFrame#getHyperlinkQueries). Cada escopo suporta as mesmas consultas:

- [getHyperlinkClicks](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkClicks) retorna contêineres com ação de clique.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkMouseOvers) retorna contêineres com ação de mouse‑over.
- [getAnyHyperlinks](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) retorna contêineres com uma ou ambas as ações.

O exemplo a seguir cria `hyperlink-audit-input.pptx` com um link externo de clique, um link de mouse‑over para arquivo, navegação interna de slide, um link de mouse‑over de texto e uma ação de macro. Ele não executa nenhuma dessas ações. As três consultas funcionam em todos os escopos; as contagens descrevem contêineres, não totais de ações. O escopo de quadro de texto exclui os links próprios da forma que o contém.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

function printQueryCounts(scope, queries) {
const clickCount = queries.getHyperlinkClicks().size();
const mouseOverCount = queries.getHyperlinkMouseOvers().size();
const anyCount = queries.getAnyHyperlinks().size();
console.log(scope + ": click=" + clickCount + ", mouse-over=" + mouseOverCount + ", any=" + anyCount);
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const destination = presentation.getSlides().addEmptySlide(slide.getLayoutSlide());
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Click the text to go to slide 2");
    shape.getHyperlinkManager().setExternalHyperlinkClick("https://example.com/");
    shape.getHyperlinkClick().setTooltip("Public website");
    shape.getHyperlinkManager().setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

    const portionFormat = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.getHyperlinkManager().setInternalHyperlinkClick(destination);
    portionFormat.getHyperlinkManager().setExternalHyperlinkMouseOver("https://example.com/help");
    const macroButton = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 120, 200, 60);
    macroButton.getHyperlinkManager().setMacroHyperlinkClick("ReviewPresentation");

    printQueryCounts("Presentation", presentation.getHyperlinkQueries());
    printQueryCounts("Slide 1", slide.getHyperlinkQueries());
    printQueryCounts("Text frame", shape.getTextFrame().getHyperlinkQueries());
    presentation.save("hyperlink-audit-input.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Para este exemplo, as consultas de apresentação e slide relatam três contêineres de clique, dois contêineres de mouse‑over e três contêineres com qualquer ação. A consulta de quadro de texto relata um contêiner em cada categoria.

### **Classificar ações e destinos**

Use [Hyperlink.getActionType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Hyperlink#getActionType) para interpretar uma ação antes de interpretar seu destino. Os valores de [HyperlinkActionType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/HyperlinkActionType) abrangem mais que navegação web:

| Valores | Significado para auditoria |
| --- | --- |
| `Hyperlink` | Hyperlink externo; inspecione a URL e seu esquema. |
| `JumpSpecificSlide` | Navegação interna para um slide específico. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Navegação interna de apresentação incorporada, resolvida no contexto da apresentação. |
| `JumpEndShow`, `StartCustomSlideShow` | Encerrar a apresentação atual ou iniciar uma apresentação personalizada. |
| `StartMacro` | Executar uma macro. |
| `StartProgram` | Iniciar um programa. |
| `OpenFile`, `OpenPresentation` | Abrir um arquivo ou outra apresentação; revisar separadamente de URLs web. |
| `StartStopMedia` | Iniciar ou parar a reprodução de mídia. |
| `NoAction`, `Unknown` | Nenhuma ação de navegação ou ação não reconhecida que requer revisão. |

Leia destinos externos com [getExternalUrl](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Hyperlink#getExternalUrl) e destinos internos específicos com [getTargetSlide](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Hyperlink#getTargetSlide). Ações internas e comandos incorporados podem não ter URL externa; uma URL vazia não significa que o contêiner não tem ação. Preserve o valor retornado por [getExternalUrlOriginal](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Hyperlink#getExternalUrlOriginal) quando ele difere da URL normalizada, e inclua a dica de ferramenta retornada por [getTooltip](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Hyperlink#getTooltip) quando disponível.

### **Relatar, limpar e verificar hiperlinks**

O exemplo JavaScript a seguir lê uma apresentação existente (use o arquivo criado acima), grava `hyperlink-audit.json`, aplica uma política, salva `hyperlink-sanitized.pptx` e a reabre para verificar novamente ambos os tipos de ativação. Ele coleta contêineres antes de alterá‑los e usa igualdade de referência para evitar processar o mesmo contêiner duas vezes. As consultas de apresentação cobrem slides ordinários; para um inventário em todo o pacote, ele também consulta explicitamente mestres, layouts, notas e os mestres de notas e folhetos quando presentes.

O relatório registra um índice de slide baseado em 1 e [getSlideId](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/BaseSlide#getSlideId) quando disponível. [getSlide](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Shape#getSlide) fornece o slide proprietário para contêineres suportados. Mestres, layouts e notas não possuem índice de slide ordinário e são identificados pelo seu escopo. Contêineres de forma e contêineres de formatação de porção de texto são rotulados separadamente; outros tipos de contêiner mantêm seu nome de tipo em tempo de execução. Cada contêiner recebe um ID local ao relatório para que suas duas ações possam ser correlacionadas. O relatório armazena tipos de ação como os inteiros definidos pela enumeração HyperlinkActionType.

Esta política de aplicação deliberadamente restritiva permite apenas URLs HTTPS absolutos e alvos internos de slide válidos. Ela rejeita macros, programas, ações de arquivo, outras ações de apresentação, ações desconhecidas e outros esquemas de URL. Essas rejeições são decisões de política, não um veredicto de segurança do Aspose.Slides. HTTPS por si só não estabelece confiança: adicione listas de permissões de hosts e outras verificações para sua aplicação. Tanto URLs externas originais quanto normalizadas são verificadas. O exemplo audita metadados sem seguir links ou executar ações.

Para remediação, o [getHyperlinkManager](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Shape#getHyperlinkManager) do contêiner suporta [setExternalHyperlinkClick](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/HyperlinkManager#setExternalHyperlinkClick), [removeHyperlinkClick](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick) e [removeHyperlinkMouseOver](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver). Aqui, links externos de clique proibidos são substituídos por uma página fixa HTTPS; outros cliques proibidos e ações de mouse‑over proibidas são removidos independentemente. Defina `replaceExternalClicks` como `false` para remover todas as violações de política. Escolha uma página de substituição controlada pela aplicação antes da implantação.

A flag de exportação do relatório usa uma política conservadora de revisão PDF: sinaliza ações de mouse‑over e tudo que não seja um link externo ou salto de slide específico como potencialmente não suportado. É uma dica de revisão, não um teste de capacidade ou garantia de que links não sinalizados sobreviverão à exportação. Exportações suportadas para [PDF](/slides/pt/nodejs-java/convert-powerpoint-to-pdf/) e [HTML](/slides/pt/nodejs-java/convert-powerpoint-to-html/) podem preservar hyperlinks, dependendo da ação, opções de exportação e visualizador. Imagens raster [images](/slides/pt/nodejs-java/convert-powerpoint-to-png/) e [video](/slides/pt/nodejs-java/convert-powerpoint-to-video/) não podem preservar hyperlinks interativos; sinalize toda ação ao auditar para esses tipos de saída.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

function slideIndex(presentation, slide) {
    if (slide == null) return null;
    for (let index = 0; index < presentation.getSlides().size(); index++) {
        if (presentation.getSlides().get_Item(index).equals(slide)) return index + 1;
    }
    return null;
}

function isHttps(value) {
    if (value == null || value.length === 0) return false;
    try {
        const uri = java.newInstanceSync("java.net.URI", value);
        const scheme = uri.getScheme();
        return uri.isAbsolute() && scheme != null && scheme.toLowerCase() === "https" && uri.getHost() != null;
    } catch (exception) {
        return false;
    }
}

function policyViolation(link) {
    if (link == null) return null;
    if (link.getActionType() === aspose.slides.HyperlinkActionType.JumpSpecificSlide) {
        return link.getTargetSlide() == null ? "Missing target slide" : null;
    }
    if (link.getActionType() !== aspose.slides.HyperlinkActionType.Hyperlink) return "Action is not allowed";
    if (!isHttps(link.getExternalUrl())) return "Normalized URL is not absolute HTTPS";
    const original = link.getExternalUrlOriginal();
    if (original != null && original.length > 0 && !isHttps(original)) return "Original URL is not absolute HTTPS";
    return null;
}

function collectContainers(presentation) {
    const found = [];
    function addQueries(queries) {
        const containers = queries.getAnyHyperlinks();
        for (let index = 0; index < containers.size(); index++) {
            found.push(containers.get_Item(index));
        }
    }
    function addScope(slide) {
        if (slide != null) addQueries(slide.getHyperlinkQueries());
    }
    addQueries(presentation.getHyperlinkQueries());
    for (let index = 0; index < presentation.getMasters().size(); index++) {
        addScope(presentation.getMasters().get_Item(index));
    }
    for (let index = 0; index < presentation.getLayoutSlides().size(); index++) {
        addScope(presentation.getLayoutSlides().get_Item(index));
    }
    for (let index = 0; index < presentation.getSlides().size(); index++) {
        addScope(presentation.getSlides().get_Item(index).getNotesSlideManager().getNotesSlide());
    }
    addScope(presentation.getMasterNotesSlideManager().getMasterNotesSlide());
    addScope(presentation.getMasterHandoutSlideManager().getMasterHandoutSlide());
    const seen = java.newInstanceSync("java.util.IdentityHashMap");
    const unique = [];
    for (const container of found) {
        if (!seen.containsKey(container)) {
            seen.put(container, true);
            unique.push(container);
        }
    }
    return unique;
}

function addRow(rows, presentation, link, activation, container, containerId) {
    if (link == null) return;
    const ownerSlide = java.instanceOf(container, "com.aspose.slides.ISlideComponent") ? container.getSlide() : null;
    const targetSlide = link.getTargetSlide();
    const violation = policyViolation(link);
    const ownerType = java.instanceOf(container, "com.aspose.slides.IShape") ? "Shape" : java.instanceOf(container, "com.aspose.slides.IPortionFormat") ? "Text portion" : container.getClass().getSimpleName();
    const ordinaryAction = link.getActionType() === aspose.slides.HyperlinkActionType.Hyperlink || link.getActionType() === aspose.slides.HyperlinkActionType.JumpSpecificSlide;
    rows.push({
        ContainerId: containerId,
        SlideIndex: slideIndex(presentation, ownerSlide),
        SlideId: ownerSlide == null ? null : ownerSlide.getSlideId(),
        Scope: ownerSlide == null ? null : ownerSlide.getClass().getSimpleName(),
        OwnerType: ownerType,
        Activation: activation,
        ActionType: link.getActionType(),
        ExternalUrl: link.getExternalUrl(),
        TargetSlideIndex: slideIndex(presentation, targetSlide),
        TargetSlideId: targetSlide == null ? null : targetSlide.getSlideId(),
        Tooltip: link.getTooltip(),
        OriginalExternalUrl: link.getExternalUrlOriginal() === link.getExternalUrl() ? null : link.getExternalUrlOriginal(),
        PotentiallyUnsafe: violation != null,
        PolicyViolation: violation,
        TargetExport: "PDF",
        PotentiallyUnsupportedByExport: activation === "mouse-over" || !ordinaryAction
    });
}

const replaceExternalClicks = true;
const replacementUrl = "https://example.com/blocked-link";
const presentation = new aspose.slides.Presentation("hyperlink-audit-input.pptx");
try {
    const containers = collectContainers(presentation);
    const rows = [];
    for (let index = 0; index < containers.length; index++) {
        const container = containers[index];
        addRow(rows, presentation, container.getHyperlinkClick(), "click", container, index + 1);
        addRow(rows, presentation, container.getHyperlinkMouseOver(), "mouse-over", container, index + 1);
    }
    const json = JSON.stringify(rows, null, 2);
    fs.writeFileSync("hyperlink-audit.json", json, "utf8");

    for (const container of containers) {
        const click = container.getHyperlinkClick();
        if (policyViolation(click) != null) {
            if (replaceExternalClicks && click.getActionType() === aspose.slides.HyperlinkActionType.Hyperlink) {
                container.getHyperlinkManager().setExternalHyperlinkClick(replacementUrl);
            } else {
                container.getHyperlinkManager().removeHyperlinkClick();
            }
        }
        if (policyViolation(container.getHyperlinkMouseOver()) != null) {
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
    }
    presentation.save("hyperlink-sanitized.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("hyperlink-sanitized.pptx");
    try {
        const remainingContainers = collectContainers(reopened);
        let violations = 0;
        for (const container of remainingContainers) {
            if (policyViolation(container.getHyperlinkClick()) != null) violations++;
            if (policyViolation(container.getHyperlinkMouseOver()) != null) violations++;
        }
        console.log("Audit rows: " + rows.length + "; prohibited actions after reopening: " + violations);
        if (violations !== 0) {
            console.log("Verification failed: do not distribute the saved presentation.");
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Com a entrada criada acima, o relatório contém cinco linhas de ação. O link de mouse‑over de arquivo e o clique de macro são removidos, enquanto os links HTTPS e a navegação interna de slide permanecem. A verificação imprime zero ações proibidas. Uma entrada contendo um URL de clique externo proibido também exerce o ramo de substituição. Um contêiner com um clique permitido e um mouse‑over proibido mantém sua ação de clique.

Essa limpeza seletiva difere de [removeAllHyperlinks](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks), que remove ambos os tipos de ativação em todo o escopo selecionado, independentemente da política. A verificação aqui verifica apenas ações de hyperlink; não remove projetos VBA incorporados, objetos OLE ou outro conteúdo ativo, e não valida um PDF ou arquivo HTML exportado.

## **Perguntas frequentes**

**Como posso vincular a uma seção ou ao seu primeiro slide?**

Seções no PowerPoint agrupam slides, mas um hyperlink interno aponta para um slide individual. Para criar navegação para uma seção, vincule ao primeiro slide dessa seção.

**Posso anexar um hyperlink a elementos de slide mestre para que funcione em todos os slides?**

Sim. Elementos de slide mestre e layout suportam hyperlinks. Links nesses elementos ficam disponíveis durante a apresentação nos slides que utilizam o mestre ou layout correspondente.

**Os hyperlinks serão preservados ao exportar para PDF, HTML, imagens ou vídeo?**

Exportações suportadas para PDF e HTML podem preservar hyperlinks; imagens raster e vídeos não podem. Consulte as considerações de exportação em [Relatar, limpar e verificar hiperlinks](#report-sanitize-and-verify-hyperlinks).