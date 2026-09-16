---
title: Gerenciar hiperlinks de apresentação em Java
linktitle: Gerenciar hiperlinks
type: docs
weight: 20
url: /pt/java/manage-hyperlinks/
keywords:
- adicionar URL
- adicionar hiperlink
- criar hiperlink
- formatar hiperlink
- remover hiperlink
- atualizar hiperlink
- hiperlink de texto
- hiperlink de slide
- hiperlink de forma
- hiperlink de imagem
- hiperlink de vídeo
- hiperlink mutável
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Adicionar, formatar, atualizar e remover hiperlinks em apresentações PowerPoint e OpenDocument com Aspose.Slides para Java, usando exemplos em Java."
---
## **Introdução**

Um hiperlink conecta o conteúdo da apresentação a um site ou a um local dentro da apresentação. No PowerPoint, os hiperlinks normalmente servem a dois propósitos:

* Abrir um site a partir de texto, forma ou quadro de mídia.
* Navegar para outro slide, por exemplo, a partir de um índice.

O Aspose.Slides for Java permite que você adicione esses links, controle sua aparência e som, atualize suas propriedades e os remova. Os exemplos abaixo mostram como trabalhar com hiperlinks em elementos individuais e como acessar hiperlinks no nível da apresentação, slide ou quadro de texto.

{{% alert color="info" title="Note" %}}
Você também pode editar apresentações com o [editor online gratuito Aspose PowerPoint](https://products.aspose.app/slides/pt/editor).
{{% /alert %}} 

## **Adicionar hiperlinks de URL**

Você pode atribuir uma URL de site a texto, forma ou quadro de mídia. O elemento ao qual você atribui o hiperlink determina a área clicável: uma parte de texto vincula o texto selecionado, enquanto uma forma ou quadro vincula o objeto do slide.

### **Adicionar hiperlinks de URL a texto**

Para vincular texto a um site, passe um [Hyperlink](https://reference.aspose.com/slides/pt/java/com.aspose.slides/hyperlink/) ao método [setHyperlinkClick](https://reference.aspose.com/slides/pt/java/com.aspose.slides/portionformat/#setHyperlinkClick-com.aspose.slides.IHyperlink-) da parte de texto, como mostrado abaixo. Apenas essa parte do texto se torna clicável.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IAutoShape textShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
    textShape.addTextFrame("Aspose: File Format APIs");
    IPortionFormat portionFormat = textShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");
    portionFormat.setFontHeight(32);

    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Adicionar hiperlinks de URL a formas e quadros de mídia**

Para tornar uma forma ou quadro clicável, chame seu método [setHyperlinkClick](https://reference.aspose.com/slides/pt/java/com.aspose.slides/shape/#setHyperlinkClick-com.aspose.slides.IHyperlink-). O hiperlink pertence ao próprio objeto e não a uma parte de texto dentro dele.

A mesma abordagem se aplica a quadros de imagem, áudio e vídeo: atribua o hiperlink ao quadro e chame [setTooltip](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) se necessário.

O exemplo a seguir torna um retângulo clicável:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

    shape.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    shape.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");

    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Usar hiperlinks para criar um índice**

Hiperlinks internos permitem que os leitores saltem de um índice para um slide específico. O exemplo a seguir usa [setInternalHyperlinkClick](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ihyperlinkmanager/#setInternalHyperlinkClick-com.aspose.slides.ISlide-) para vincular o texto “Page 2” no primeiro slide ao segundo slide.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ISlide secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    IAutoShape tableOfContents = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100);
    tableOfContents.getFillFormat().setFillType(FillType.NoFill);
    tableOfContents.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    tableOfContents.getTextFrame().getParagraphs().clear();

    Paragraph paragraph = new Paragraph();
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    paragraph.setText("Title of slide 2 .......... ");

    Portion linkPortion = new Portion();
    linkPortion.setText("Page 2");
    linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);

    paragraph.getPortions().add(linkPortion);
    tableOfContents.getTextFrame().getParagraphs().add(paragraph);

    presentation.save("link_to_slide.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Formatar hiperlinks**

### **Cor**

O método [setColorSource](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ihyperlink/#setColorSource-int-) de [IHyperlink](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ihyperlink/) determina se um hiperlink usa a cor de hiperlink da apresentação ou a formatação da parte de texto. Para aplicar uma cor de texto personalizada, selecione [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/pt/java/com.aspose.slides/hyperlinkcolorsource/) e defina a cor de preenchimento da parte. Esse recurso foi introduzido no PowerPoint 2019; versões mais antigas não aplicam essa configuração.

O exemplo a seguir adiciona dois hiperlinks de texto ao mesmo slide. O primeiro usa preenchimento de texto vermelho, enquanto o segundo mantém a cor padrão do hiperlink.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    IAutoShape coloredShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
    coloredShape.addTextFrame("This hyperlink uses a custom color.");
    IPortionFormat coloredPortionFormat = coloredShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    coloredPortionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    coloredPortionFormat.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat);
    coloredPortionFormat.getFillFormat().setFillType(FillType.Solid);
    coloredPortionFormat.getFillFormat().getSolidFillColor().setColor(Color.RED);

    IAutoShape defaultShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
    defaultShape.addTextFrame("This hyperlink uses the default color.");
    defaultShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));

    presentation.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
### **Som**

Um hiperlink pode reproduzir um som quando ativado ou parar um som que já está sendo reproduzido. Use os seguintes métodos para configurar esses comportamentos:

- [IHyperlink.setSound](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ihyperlink/#setSound-com.aspose.slides.IAudio-) especifica o áudio associado ao hiperlink.
- [IHyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ihyperlink/#setStopSoundOnClick-boolean-) controla se a ativação do hiperlink interrompe o som anterior.

#### **Adicionar som ao hiperlink**

O exemplo a seguir carrega `sampleaudio.wav` e o associa a um botão no primeiro slide. Clicar no botão reproduz o som e navega para o próximo slide. Uma segunda forma naquele slide interrompe o som anterior ao ser clicada, sem executar uma ação de navegação.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] audioData = Files.readAllBytes(Paths.get("sampleaudio.wav"));
    IAudio hyperlinkSound = presentation.getAudios().addAudio(audioData);

    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IAutoShape playButton = firstSlide.getShapes().addAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
    playButton.setHyperlinkClick(Hyperlink.getNextSlide());

    if (!playButton.getHyperlinkClick().getStopSoundOnClick() && playButton.getHyperlinkClick().getSound() == null)
    {
        playButton.getHyperlinkClick().setSound(hyperlinkSound);
    }

    ISlide secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    IAutoShape stopButton = secondSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
    stopButton.setHyperlinkClick(Hyperlink.getNoAction());

    stopButton.getHyperlinkClick().setStopSoundOnClick(true);

    presentation.save("hyperlink-sound.pptx", SaveFormat.Pptx);
} catch (IOException exception) {
    System.out.println("Unable to read the audio file: " + exception.getMessage());
} finally {
    presentation.dispose();
}
```

#### **Extrair som de hiperlink**

O exemplo a seguir abre a apresentação criada acima e lê o áudio de hiperlink da primeira forma para a memória através de [getSound](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ihyperlink/#getSound--) e [getBinaryData](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iaudio/#getBinaryData--).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("hyperlink-sound.pptx");
try {
    if (presentation.getSlides().size() > 0 && presentation.getSlides().get_Item(0).getShapes().size() > 0) {
        IHyperlink hyperlink = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getHyperlinkClick();
        IAudio sound = hyperlink == null ? null : hyperlink.getSound();
        if (sound != null) {
            byte[] audioData = sound.getBinaryData();
            System.out.println("Extracted " + audioData.length + " bytes of hyperlink audio.");
        } else {
            System.out.println("The first shape has no hyperlink sound.");
        }
    } else {
        System.out.println("The presentation has no first slide or shape to inspect.");
    }
} finally {
    presentation.dispose();
}
```

### **Configurações de dica de ferramenta e interação**

Você pode chamar os seguintes métodos de [IHyperlink](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ihyperlink/) após atribuir um hiperlink a texto ou a uma forma:

- [setTooltip](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) define o texto que o visualizador pode exibir como dica para o link.
- [setTargetFrame](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ihyperlink/#setTargetFrame-java.lang.String-) especifica o quadro de destino dentro de um frameset HTML pai, quando aplicável.
- [setHistory](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ihyperlink/#setHistory-boolean-) controla se a ativação do link adiciona seu destino à lista de hiperlinks visualizados.
- [setHighlightClick](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ihyperlink/#setHighlightClick-boolean-) controla se o hiperlink é destacado quando clicado.

## **Remover hiperlinks de apresentações**

Use [getAnyHyperlinks](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) para coletar contêineres de hiperlink, incluindo links de partes de texto, antes de alterá-los. O exemplo a seguir remove ambos os tipos de ativação do primeiro slide. Para remover apenas um tipo, chame apenas [removeHyperlinkClick](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) ou [removeHyperlinkMouseOver](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--); remover a ação de clique não remove a ação de mouse-over correspondente.

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.List;

Presentation presentation = new Presentation("pres.pptx");
try {
    if (presentation.getSlides().size() > 0) {
        List<IHyperlinkContainer> containers = new ArrayList<>();
        for (IHyperlinkContainer container : presentation.getSlides().get_Item(0).getHyperlinkQueries().getAnyHyperlinks()) {
            containers.add(container);
        }
        for (IHyperlinkContainer container : containers) {
            container.getHyperlinkManager().removeHyperlinkClick();
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
        presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The presentation has no slides to process.");
    }
} finally {
    presentation.dispose();
}
```

Para remoção incondicional, [removeAllHyperlinks](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) remove ambos os tipos de ativação no escopo selecionado em uma única chamada. Para limpeza seletiva e cobertura de mestres, layouts e notas, veja [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Construir um inventário completo de hiperlinks**

Antes de distribuir uma apresentação, faça um inventário de suas ações interativas bem como seus links web. [getAnyHyperlinks](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) devolve objetos [IHyperlinkContainer](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ihyperlinkcontainer/), não uma lista plana de strings de URL. Inspecione tanto [getHyperlinkClick](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) quanto [getHyperlinkMouseOver](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) em cada contêiner. Eles são independentes: o mesmo contêiner pode expor ambas as ações, portanto um relatório completo precisa de até duas linhas por contêiner.

Escanear apenas hiperlinks a nível de forma pode perder links anexados a partes de texto. Consulte o escopo adequado em vez disso, e retenha os contêineres retornados para que você possa atualizar ou remover suas ações posteriormente.

### **Consultar escopos de apresentação, slide e quadro de texto**

A interface [IHyperlinkQueries](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ihyperlinkqueries/) está disponível através de [IPresentation.getHyperlinkQueries](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ipresentation/#getHyperlinkQueries--), [IBaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ibaseslide/#getHyperlinkQueries--), e [ITextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/pt/java/com.aspose.slides/itextframe/#getHyperlinkQueries--). Cada escopo suporta as mesmas consultas:

- [getHyperlinkClicks](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ihyperlinkqueries/#getHyperlinkClicks--) retorna contêineres com ação de clique.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ihyperlinkqueries/#getHyperlinkMouseOvers--) retorna contêineres com ação de mouse-over.
- [getAnyHyperlinks](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) retorna contêineres com uma ou ambas as ações.

O exemplo a seguir cria `hyperlink-audit-input.pptx` com um link de clique externo, um link de mouse-over de arquivo, navegação interna de slide, um link de mouse-over de texto e uma ação de macro. Ele não executa nenhuma dessas ações. As mesmas três consultas funcionam em todos os escopos; as contagens descrevem contêineres, não totais de ações. O escopo de quadro de texto exclui os próprios links da forma que o contém.

```java
import com.aspose.slides.*;

class QueryCounts {
    void print(String scope, IHyperlinkQueries queries) {
        int clickCount = queries.getHyperlinkClicks().size();
        int mouseOverCount = queries.getHyperlinkMouseOvers().size();
        int anyCount = queries.getAnyHyperlinks().size();
        System.out.println(scope + ": click=" + clickCount + ", mouse-over=" + mouseOverCount + ", any=" + anyCount);
    }
}

QueryCounts counts = new QueryCounts();
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ISlide destination = presentation.getSlides().addEmptySlide(slide.getLayoutSlide());
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Click the text to go to slide 2");
    shape.getHyperlinkManager().setExternalHyperlinkClick("https://example.com/");
    shape.getHyperlinkClick().setTooltip("Public website");
    shape.getHyperlinkManager().setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

    IPortionFormat portionFormat = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.getHyperlinkManager().setInternalHyperlinkClick(destination);
    portionFormat.getHyperlinkManager().setExternalHyperlinkMouseOver("https://example.com/help");
    IAutoShape macroButton = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 120, 200, 60);
    macroButton.getHyperlinkManager().setMacroHyperlinkClick("ReviewPresentation");

    counts.print("Presentation", presentation.getHyperlinkQueries());
    counts.print("Slide 1", slide.getHyperlinkQueries());
    counts.print("Text frame", shape.getTextFrame().getHyperlinkQueries());
    presentation.save("hyperlink-audit-input.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Para este exemplo, as consultas de apresentação e slide relatam três contêineres de clique, dois de mouse-over e três contêineres com qualquer ação. A consulta de quadro de texto relata um contêiner em cada categoria.

### **Classificar ações e destinos**

Use [IHyperlink.getActionType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ihyperlink/#getActionType--) para interpretar uma ação antes de interpretar seu destino. Os valores de [HyperlinkActionType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/hyperlinkactiontype/) cobrem mais que navegação web:

| Valores | Significado para auditoria |
| --- | --- |
| `Hyperlink` | Hiperlink externo; inspecione a URL e seu esquema. |
| `JumpSpecificSlide` | Navegação interna para um slide específico. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Navegação interna de apresentação, resolvida no contexto da apresentação de slides. |
| `JumpEndShow`, `StartCustomSlideShow` | Encerrar a apresentação atual ou iniciar uma apresentação personalizada. |
| `StartMacro` | Executar uma macro. |
| `StartProgram` | Iniciar um programa. |
| `OpenFile`, `OpenPresentation` | Abrir um arquivo ou outra apresentação; reveja separadamente das URLs web. |
| `StartStopMedia` | Iniciar ou parar a reprodução de mídia. |
| `NoAction`, `Unknown` | Nenhuma ação de navegação, ou uma ação não reconhecida que requer revisão. |

Leia destinos externos de [getExternalUrl](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ihyperlink/#getExternalUrl--) e destinos internos específicos de [getTargetSlide](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ihyperlink/#getTargetSlide--). Ações internas e comandos internos podem não ter URL externo; uma URL vazia não significa que o contêiner não tem ação. Preserve o valor retornado por [getExternalUrlOriginal](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) quando ele difere da URL normalizada, e inclua a dica de ferramenta retornada por [getTooltip](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ihyperlink/#getTooltip--) quando disponível.

### **Relatar, sanitizar e verificar hiperlinks**

O exemplo Java a seguir lê uma apresentação existente (use o arquivo criado acima), grava `hyperlink-audit.json`, aplica uma política, salva `hyperlink-sanitized.pptx` e a reabre para checar novamente ambos os tipos de ativação. Ele coleta contêineres antes de alterá‑los e usa igualdade de referência para evitar processar o mesmo contêiner duas vezes. As consultas de apresentação cobrem slides ordinários; para um inventário em todo o pacote, ele também consulta explicitamente mestres, layouts, notas e os mestres de notas e de folhetos quando presentes.

O relatório registra um índice de slide baseado em 1 e [getSlideId](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ibaseslide/#getSlideId--) quando disponível. [ISlideComponent.getSlide](https://reference.aspose.com/slides/pt/java/com.aspose.slides/islidecomponent/#getSlide--) fornece o slide proprietário para contêineres suportados. Mestres, layouts e notas não têm índice de slide ordinário e são identificados pelo seu escopo. Contêineres de forma e contêineres de formatação de parte de texto são rotulados separadamente; outros tipos de contêiner mantêm seu nome de tipo em tempo de execução. Cada contêiner recebe um ID local ao relatório para que suas duas ações possam ser correlacionadas. O relatório armazena tipos de ação como as constantes inteiras definidas pela enumeração Java.

Esta política de aplicação deliberadamente restritiva permite apenas URLs HTTPS absolutas e alvos internos de slide válidos. Ela rejeita macros, programas, ações de arquivo, outras ações de apresentação, ações desconhecidas e outros esquemas de URL. Essas rejeições são decisões de política, não um veredicto de segurança do Aspose.Slides. HTTPS sozinho não estabelece confiança: adicione listas de permitidos de hosts e outras verificações para sua aplicação. Tanto URLs externas originais quanto normalizadas são verificadas. O exemplo audita metadados sem seguir links ou executar ações.

Para remediação, o [getHyperlinkManager](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) do contêiner suporta [setExternalHyperlinkClick](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-), [removeHyperlinkClick](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) e [removeHyperlinkMouseOver](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--). Aqui, links de clique externo proibidos são substituídos por uma página fixa HTTPS; outros cliques proibidos e ações de mouse-over proibidas são removidos independentemente. Defina `replaceExternalClicks` como `false` para remover todas as violações de política. Escolha uma página de substituição controlada pela aplicação antes da implantação.

A bandeira de exportação do relatório usa uma política conservadora de revisão de PDF: sinalize ações de mouse-over e tudo que não seja um link externo ou salto específico de slide como potencialmente não suportado. É uma dica de revisão, não um teste de capacidade ou garantia de que links não sinalizados sobreviverão à exportação. Exportações de PDF e HTML suportadas podem preservar hiperlinks, dependendo da ação, opções de exportação e visualizador. Imagens raster e vídeos não podem preservar hiperlinks interativos; sinalize cada ação ao auditar para esses tipos de saída.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.net.URI;
import java.net.URISyntaxException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.ArrayList;
import java.util.Collections;
import java.util.IdentityHashMap;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;
import java.util.Objects;
import java.util.Set;

class HyperlinkAudit {
    Integer slideIndex(IPresentation presentation, IBaseSlide slide) {
        for (int index = 0; index < presentation.getSlides().size(); index++) {
            if (presentation.getSlides().get_Item(index) == slide) return index + 1;
        }
        return null;
    }

    boolean isHttps(String value) {
        if (value == null || value.isEmpty()) return false;
        try {
            URI uri = new URI(value);
            return uri.isAbsolute() && "https".equalsIgnoreCase(uri.getScheme()) && uri.getHost() != null;
        } catch (URISyntaxException exception) {
            return false;
        }
    }

    String policyViolation(IHyperlink link) {
        if (link == null) return null;
        if (link.getActionType() == HyperlinkActionType.JumpSpecificSlide) {
            return link.getTargetSlide() == null ? "Missing target slide" : null;
        }
        if (link.getActionType() != HyperlinkActionType.Hyperlink) return "Action is not allowed";
        if (!isHttps(link.getExternalUrl())) return "Normalized URL is not absolute HTTPS";
        String original = link.getExternalUrlOriginal();
        if (original != null && !original.isEmpty() && !isHttps(original)) return "Original URL is not absolute HTTPS";
        return null;
    }

    void addScope(List<IHyperlinkContainer> found, IBaseSlide slide) {
        if (slide != null) {
            for (IHyperlinkContainer container : slide.getHyperlinkQueries().getAnyHyperlinks()) {
                found.add(container);
            }
        }
    }

    List<IHyperlinkContainer> collectContainers(IPresentation presentation) {
        List<IHyperlinkContainer> found = new ArrayList<>();
        for (IHyperlinkContainer container : presentation.getHyperlinkQueries().getAnyHyperlinks()) {
            found.add(container);
        }
        for (IMasterSlide master : presentation.getMasters()) addScope(found, master);
        for (ILayoutSlide layout : presentation.getLayoutSlides()) addScope(found, layout);
        for (ISlide slide : presentation.getSlides()) addScope(found, slide.getNotesSlideManager().getNotesSlide());
        addScope(found, presentation.getMasterNotesSlideManager().getMasterNotesSlide());
        addScope(found, presentation.getMasterHandoutSlideManager().getMasterHandoutSlide());
        Set<IHyperlinkContainer> seen = Collections.newSetFromMap(new IdentityHashMap<IHyperlinkContainer, Boolean>());
        List<IHyperlinkContainer> unique = new ArrayList<>();
        for (IHyperlinkContainer container : found) {
            if (seen.add(container)) unique.add(container);
        }
        return unique;
    }

    void addRow(List<Map<String, Object>> rows, IPresentation presentation, IHyperlink link, String activation, IHyperlinkContainer container, int containerId) {
        if (link == null) return;
        IBaseSlide ownerSlide = container instanceof ISlideComponent ? ((ISlideComponent) container).getSlide() : null;
        ISlide targetSlide = link.getTargetSlide();
        String violation = policyViolation(link);
        String ownerType = container instanceof IShape ? "Shape" : container instanceof IPortionFormat ? "Text portion" : container.getClass().getSimpleName();
        boolean ordinaryAction = link.getActionType() == HyperlinkActionType.Hyperlink || link.getActionType() == HyperlinkActionType.JumpSpecificSlide;
        Map<String, Object> row = new LinkedHashMap<>();
        row.put("ContainerId", containerId);
        row.put("SlideIndex", slideIndex(presentation, ownerSlide));
        row.put("SlideId", ownerSlide == null ? null : ownerSlide.getSlideId());
        row.put("Scope", ownerSlide == null ? null : ownerSlide.getClass().getSimpleName());
        row.put("OwnerType", ownerType);
        row.put("Activation", activation);
        row.put("ActionType", link.getActionType());
        row.put("ExternalUrl", link.getExternalUrl());
        row.put("TargetSlideIndex", slideIndex(presentation, targetSlide));
        row.put("TargetSlideId", targetSlide == null ? null : targetSlide.getSlideId());
        row.put("Tooltip", link.getTooltip());
        row.put("OriginalExternalUrl", Objects.equals(link.getExternalUrlOriginal(), link.getExternalUrl()) ? null : link.getExternalUrlOriginal());
        row.put("PotentiallyUnsafe", violation != null);
        row.put("PolicyViolation", violation);
        row.put("TargetExport", "PDF");
        row.put("PotentiallyUnsupportedByExport", "mouse-over".equals(activation) || !ordinaryAction);
        rows.add(row);
    }

    // Serializar as linhas planas deste relatório sem uma dependência JSON adicional.
    String jsonValue(Object value) {
        if (value == null) return "null";
        if (value instanceof Number || value instanceof Boolean) return value.toString();
        StringBuilder escaped = new StringBuilder("\"");
        for (char character : value.toString().toCharArray()) {
            if (character == '"' || character == '\\') {
                escaped.append('\\').append(character);
            } else if (character < 0x20 || Character.isSurrogate(character)) {
                escaped.append(String.format("\\u%04x", (int) character));
            } else {
                escaped.append(character);
            }
        }
        return escaped.append('"').toString();
    }

    String toJson(List<Map<String, Object>> rows) {
        List<String> objects = new ArrayList<>();
        for (Map<String, Object> row : rows) {
            List<String> fields = new ArrayList<>();
            for (Map.Entry<String, Object> field : row.entrySet()) {
                fields.add("    " + jsonValue(field.getKey()) + ": " + jsonValue(field.getValue()));
            }
            objects.add("  {\n" + String.join(",\n", fields) + "\n  }");
        }
        return "[\n" + String.join(",\n", objects) + "\n]\n";
    }
}

boolean replaceExternalClicks = true;
String replacementUrl = "https://example.com/blocked-link";
HyperlinkAudit audit = new HyperlinkAudit();
Presentation presentation = new Presentation("hyperlink-audit-input.pptx");
try {
    List<IHyperlinkContainer> containers = audit.collectContainers(presentation);
    List<Map<String, Object>> rows = new ArrayList<>();
    for (int index = 0; index < containers.size(); index++) {
        IHyperlinkContainer container = containers.get(index);
        audit.addRow(rows, presentation, container.getHyperlinkClick(), "click", container, index + 1);
        audit.addRow(rows, presentation, container.getHyperlinkMouseOver(), "mouse-over", container, index + 1);
    }
    String json = audit.toJson(rows);
    byte[] jsonData = json.getBytes(StandardCharsets.UTF_8);
    Files.write(Paths.get("hyperlink-audit.json"), jsonData);

    for (IHyperlinkContainer container : containers) {
        IHyperlink click = container.getHyperlinkClick();
        if (audit.policyViolation(click) != null) {
            if (replaceExternalClicks && click.getActionType() == HyperlinkActionType.Hyperlink) {
                container.getHyperlinkManager().setExternalHyperlinkClick(replacementUrl);
            } else {
                container.getHyperlinkManager().removeHyperlinkClick();
            }
        }
        if (audit.policyViolation(container.getHyperlinkMouseOver()) != null) {
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
    }
    presentation.save("hyperlink-sanitized.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("hyperlink-sanitized.pptx");
    try {
        List<IHyperlinkContainer> remainingContainers = audit.collectContainers(reopened);
        int violations = 0;
        for (IHyperlinkContainer container : remainingContainers) {
            if (audit.policyViolation(container.getHyperlinkClick()) != null) violations++;
            if (audit.policyViolation(container.getHyperlinkMouseOver()) != null) violations++;
        }
        System.out.println("Audit rows: " + rows.size() + "; prohibited actions after reopening: " + violations);
        if (violations != 0) {
            System.out.println("Verification failed: do not distribute the saved presentation.");
        }
    } finally {
        reopened.dispose();
    }
} catch (IOException exception) {
    System.out.println("Unable to write the audit report: " + exception.getMessage());
} finally {
    presentation.dispose();
}
```

Com a entrada criada acima, o relatório contém cinco linhas de ação. O link de mouse-over de arquivo e o clique de macro são removidos, enquanto os links HTTPS e a navegação interna de slide permanecem. A verificação imprime zero ações proibidas. Uma entrada contendo uma URL de clique externo proibida também exercita o ramo de substituição. Um contêiner com clique permitido e mouse-over proibido mantém sua ação de clique.

Essa limpeza seletiva difere de [removeAllHyperlinks](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--), que remove ambos os tipos de ativação em todo o escopo selecionado independentemente da política. A verificação aqui checa apenas as ações de hiperlink; não remove projetos VBA incorporados, objetos OLE ou outro conteúdo ativo, e não valida um PDF ou HTML exportado.

## **FAQ**

**Como posso vincular a uma seção ou ao seu primeiro slide?**

Seções no PowerPoint agrupam slides, mas um hiperlink interno aponta para um slide individual. Para criar navegação para uma seção, vincule ao primeiro slide dessa seção.

**Posso anexar um hiperlink a elementos do slide mestre para que funcione em todos os slides?**

Sim. Elementos de slide mestre e layout suportam hiperlinks. Links nesses elementos estão disponíveis durante a apresentação nos slides que utilizam o mestre ou layout correspondente.

**Os hiperlinks serão preservados ao exportar para PDF, HTML, imagens ou vídeo?**

Exportações de PDF e HTML suportadas podem preservar hiperlinks; imagens raster e vídeos não podem. Veja as considerações de exportação em [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).