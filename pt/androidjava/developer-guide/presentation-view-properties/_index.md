---
title: Recuperar e Atualizar Propriedades de Visualização da Apresentação no Android
linktitle: Propriedades de Visualização
type: docs
weight: 80
url: /pt/androidjava/presentation-view-properties/
keywords:
- propriedades de visualização
- visualização normal
- conteúdo de contorno
- ícones de contorno
- encaixe do divisor vertical
- visualização única
- estado da barra
- tamanho da dimensão
- ajuste automático
- zoom padrão
- PowerPoint
- OpenDocument
- apresentação
- Android
- Java
- Aspose.Slides
description: "Descubra as propriedades de visualização do Aspose.Slides para Android via Java para personalizar formatos de slides PPT, PPTX e ODP — ajuste layouts, níveis de zoom e configurações de exibição."
---
## **Introdução**

A visualização normal consiste em três regiões de conteúdo: o próprio slide, uma região de conteúdo lateral e uma região de conteúdo inferior. Propriedades referentes ao posicionamento das diferentes regiões de conteúdo. Essas informações permitem que o aplicativo salve seu estado de visualização no arquivo, de modo que, ao ser reaberto, a visualização esteja no mesmo estado em que a apresentação foi salva pela última vez.

O método [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) foi adicionado para fornecer acesso às propriedades de visualização normal da apresentação. 

As interfaces [INormalViewProperties](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/INormalViewRestoredProperties) e seus descendentes, [SplitterBarStateType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/SplitterBarStateType) enum foram adicionados.

## **Sobre INormalViewProperties**

Representa as propriedades de visualização normal.

Os métodos [getShowOutlineIcons](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) e [setShowOutlineIcons](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) especificam se o aplicativo deve mostrar ícones ao exibir o conteúdo de contorno em qualquer uma das regiões de conteúdo do modo de visualização normal.

Os métodos [getSnapVerticalSplitter](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) e [setSnapVerticalSplitter](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) especificam se o divisor vertical deve encaixar em um estado minimizado quando a região lateral é suficientemente pequena.

A propriedade [getPreferSingleView](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) e [setPreferSingleView](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) especificam se o usuário prefere ver uma única região de conteúdo em tela cheia em vez da visualização normal padrão com três regiões de conteúdo. Se habilitado, o aplicativo pode optar por exibir uma das regiões de conteúdo em toda a janela.

Os métodos [getVerticalBarState](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) e [getHorizontalBarState](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) especificam o estado em que a barra divisor horizontal ou vertical deve ser mostrada. Uma barra divisor horizontal separa o slide da região de conteúdo abaixo do slide, enquanto a barra divisor vertical separa o slide da região de conteúdo lateral. Os valores possíveis são: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) e [SplitterBarStateType.Restored](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

Os métodos [getRestoredLeft](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) e [getRestoredTop](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) especificam o dimensionamento da região superior ou lateral do slide na visualização normal, quando o valor [SplitterBarStateType.Restored](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/SplitterBarStateType#Restored) é aplicado para [getVerticalBarState](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) e [getHorizontalBarState](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) respectivamente.

## **Sobre a Restauração de INormalViewProperties**

Especifica o dimensionamento da região do slide (largura quando filho de [getRestoredTop](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--), altura quando filho de [getRestoredLeft](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) da visualização normal, quando a região tem um tamanho restaurado variável (nem minimizado nem maximizado). 

O método [getDimensionSize](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) especifica o tamanho da região do slide (largura quando filho de restoredTop, altura quando filho de restoredLeft).

O método [getAutoAdjust](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) especifica se o tamanho da região de conteúdo lateral deve compensar o novo tamanho ao redimensionar a janela que contém a visualização dentro do aplicativo.

Um exemplo abaixo mostra como acessar as propriedades [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) para uma apresentação.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(SplitterBarStateType.Maximized);
    
    // Restaurar as propriedades de visualização da apresentação
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);

    pres.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Definir o Valor de Zoom Padrão**

{{% alert color="info" %}} 

Aspose.Slides for Android via Java agora suporta a definição do valor de zoom padrão para a apresentação, de modo que, ao abrir a apresentação, o zoom já esteja definido. Isso pode ser feito definindo as [ViewProperties](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ViewProperties) de uma apresentação. [getSlideViewProperties](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) assim como [getNotesViewProperties](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) podem ser configurados programaticamente. Neste tópico, veremos com um exemplo como definir as [View Properties](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ViewProperties) de [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation) no Aspose.Slides.

{{% /alert %}} 

Para definir as propriedades de visualização, siga os passos abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation).
1. Defina as [View Properties](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ViewProperties) de [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation).
1. Salve a apresentação como um arquivo [PPTX](https://docs.fileformat.com/presentation/pptx/).  
   No exemplo abaixo, definimos o valor de zoom tanto para a visualização de slide quanto para a visualização de notas.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Definindo as propriedades de visualização da apresentação
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Valor de zoom em porcentagem para a visualização de slide
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Valor de zoom em porcentagem para a visualização de notas 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Definir o Espaçamento da Grade**

Use [Presentation.getViewProperties](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/#getViewProperties--) para acessar as configurações de visualização de toda a apresentação. Os métodos [IViewProperties.getGridSpacing](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iviewproperties/#getGridSpacing--) e [IViewProperties.setGridSpacing](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iviewproperties/#setGridSpacing-float-) leem ou alteram o intervalo da grade de edição subjacente. Essa configuração se aplica a toda a apresentação, não a um slide individual. O espaçamento da grade é especificado em pontos, onde 72 pontos equivalem a uma polegada. Use um valor positivo, conforme exigido pela documentação da API.

O exemplo a seguir abre um `demo.pptx` existente, exibe o espaçamento de grade atual, define um intervalo de um quarto de polegada e salva o resultado.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("demo.pptx");
try {
    float gridSpacing = presentation.getViewProperties().getGridSpacing();
    System.out.println("Current grid spacing: " + gridSpacing + " points");

    presentation.getViewProperties().setGridSpacing(18f);
    presentation.save("grid-spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A grade difere dos [drawing guides](/slides/pt/androidjava/drawing-guides/). O espaçamento da grade controla um intervalo regular, enquanto os guias de desenho são linhas de alinhamento horizontais ou verticais posicionadas individualmente. Adicionar, mover ou limpar guias de desenho não altera o espaçamento da grade.

Tanto a grade quanto os guias de desenho são auxílios de edição. Eles não são renderizados como conteúdo de slide em PDF, imagens, SVG ou em uma apresentação de slides. Armazenar o espaçamento da grade não garante que um editor exibirá a grade: sua visibilidade também depende das preferências do visualizador ou editor.

## **Exibir ou Ocultar Comentários ao Abrir uma Apresentação**

Use [Presentation.getViewProperties](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/#getViewProperties--) para acessar as configurações de visualização de toda a apresentação. Use [IViewProperties.getShowComments](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iviewproperties/#getShowComments--) e [IViewProperties.setShowComments](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iviewproperties/#setShowComments-byte-) para ler ou alterar a preferência armazenada sobre se os comentários devem ser mostrados quando a apresentação for aberta no PowerPoint ou em outro editor compatível.

Essa configuração controla apenas a preferência de visualização armazenada. Ela não adiciona, remove, edita ou resolve comentários. Ocultar comentários preserva seu conteúdo, autores, posições, respostas e status. Consulte [Presentation Comments](/slides/pt/androidjava/presentation-comments/) para operações que alteram os próprios comentários.

O exemplo a seguir requer um `comments.pptx` existente contendo comentários. Ele exibe a configuração de visibilidade atual, solicita que os comentários sejam ocultados e salva um novo PPTX sem remover quaisquer comentários. Também usa [IViewProperties.setLastView](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iviewproperties/#setLastView-int-) com [ViewType.SlideView](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/viewtype/#SlideView) para configurar a visualização de edição inicial juntamente com a visibilidade dos comentários.

```java
import com.aspose.slides.NullableBool;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ViewType;

Presentation presentation = new Presentation("comments.pptx");
try {
    byte showComments = presentation.getViewProperties().getShowComments();
    System.out.println("Current comment visibility: " + showComments);

    presentation.getViewProperties().setShowComments(NullableBool.False);
    presentation.getViewProperties().setLastView(ViewType.SlideView);
    presentation.save("comments-hidden.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Essa configuração não determina se os comentários são incluídos nas exportações para PDF, HTML, imagem, notas ou folhetos. Configure as opções específicas de exportação separadamente.

## **Perguntas Frequentes**

**Por que a grade não está visível após eu reabrir a apresentação?**

O arquivo armazena o espaçamento da grade, mas o editor controla se a grade é exibida. Verifique as configurações de visibilidade da grade no editor.

**Limpar os guias de desenho altera o espaçamento da grade?**

Não. Guias de desenho e espaçamento da grade são configurações independentes. Limpar os guias deixa o intervalo da grade armazenado inalterado.

**Posso definir configurações de visualização diferentes para seções diferentes de uma apresentação?**

As [view settings](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/#getViewProperties--) são definidas ao nível da apresentação ([Normal View](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/viewproperties/#getSlideViewProperties--)), não por seção, de modo que um único conjunto de parâmetros se aplica a todo o documento quando ele é aberto.

**Posso pré-definir diferentes estados de visualização para usuários diferentes?**

Não. As configurações são armazenadas no arquivo e são compartilhadas. Aplicativos visualizadores podem respeitar preferências de usuário, mas o arquivo em si contém um único conjunto de propriedades de visualização.

**Posso preparar um modelo com propriedades de visualização pré-definidas para que novas apresentações abram da mesma forma?**

Sim. Como as [view properties](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/#getViewProperties--) são armazenadas ao nível da apresentação, você pode incorporá‑las em um modelo e criar novos documentos a partir dele com a mesma configuração de visualização inicial.