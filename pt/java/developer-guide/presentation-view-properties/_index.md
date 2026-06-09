---
title: Recuperar e Atualizar Propriedades de Visualização da Apresentação em Java
linktitle: Propriedades de Visualização
type: docs
weight: 80
url: /pt/java/presentation-view-properties/
keywords:
- propriedades de visualização
- visualização normal
- conteúdo de contorno
- ícones de contorno
- ajuste do divisor vertical
- visualização única
- estado da barra
- tamanho da dimensão
- ajuste automático
- zoom padrão
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Descubra as propriedades de visualização do Aspose.Slides para Java para personalizar os formatos de slides PPT, PPTX e ODP — ajuste layouts, níveis de zoom e configurações de exibição."
---
## **Introdução**

A visualização normal consiste em três regiões de conteúdo: o slide propriamente dito, uma região de conteúdo lateral e uma região de conteúdo inferior. Propriedades referentes ao posicionamento das diferentes regiões de conteúdo. Essas informações permitem que o aplicativo salve seu estado de visualização no arquivo, de modo que, ao ser reaberto, a visualização esteja no mesmo estado em que a apresentação foi salva pela última vez.

O método [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) foi adicionado para fornecer acesso às propriedades da visualização normal da apresentação.  

Foram adicionadas as interfaces [INormalViewProperties](https://reference.aspose.com/slides/pt/java/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/pt/java/com.aspose.slides/INormalViewRestoredProperties) e seus descendentes, bem como o enum [SplitterBarStateType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/SplitterBarStateType).

## **Sobre INormalViewProperties**

Representa as propriedades da visualização normal.

Os métodos [getShowOutlineIcons](https://reference.aspose.com/slides/pt/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) e [setShowOutlineIcons](https://reference.aspose.com/slides/pt/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) especificam se o aplicativo deve mostrar ícones ao exibir o contorno do conteúdo em qualquer das regiões de conteúdo do modo de visualização normal.

Os métodos [getSnapVerticalSplitter](https://reference.aspose.com/slides/pt/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) e [setSnapVerticalSplitter](https://reference.aspose.com/slides/pt/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) especificam se o divisor vertical deve “snapar” para um estado minimizado quando a região lateral está suficientemente pequena.

A propriedade [getPreferSingleView](https://reference.aspose.com/slides/pt/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) e [setPreferSingleView](https://reference.aspose.com/slides/pt/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) especificam se o usuário prefere ver uma única região de conteúdo em tela cheia em vez da visualização normal padrão com três regiões de conteúdo. Se ativado, o aplicativo pode optar por exibir uma das regiões de conteúdo em toda a janela.

Os métodos [getVerticalBarState](https://reference.aspose.com/slides/pt/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) e [getHorizontalBarState](https://reference.aspose.com/slides/pt/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) especificam o estado em que a barra divisor horizontal ou vertical deve ser exibida. Uma barra divisor horizontal separa o slide da região de conteúdo abaixo do slide; a barra divisor vertical separa o slide da região de conteúdo lateral. Os valores possíveis são: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/pt/java/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/pt/java/com.aspose.slides/SplitterBarStateType#Maximized) e [SplitterBarStateType.Restored](https://reference.aspose.com/slides/pt/java/com.aspose.slides/SplitterBarStateType#Restored).

Os métodos [getRestoredLeft](https://reference.aspose.com/slides/pt/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) e [getRestoredTop](https://reference.aspose.com/slides/pt/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) especificam o dimensionamento da região superior ou lateral do slide na visualização normal, quando o valor [SplitterBarStateType.Restored](https://reference.aspose.com/slides/pt/java/com.aspose.slides/SplitterBarStateType#Restored) é aplicado para [getVerticalBarState](https://reference.aspose.com/slides/pt/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) e [getHorizontalBarState](https://reference.aspose.com/slides/pt/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) respectivamente.

## **Sobre Restaurar INormalViewProperties** 

Especifica o dimensionamento da região do slide (largura quando filho de [getRestoredTop](https://reference.aspose.com/slides/pt/java/com.aspose.slides/INormalViewProperties#getRestoredTop--), altura quando filho de [getRestoredLeft](https://reference.aspose.com/slides/pt/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) da visualização normal, quando a região está em um tamanho restaurado variável (nem minimizado nem maximizado).  

O método [getDimensionSize](https://reference.aspose.com/slides/pt/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) especifica o tamanho da região do slide (largura quando filho de restoredTop, altura quando filho de restoredLeft).

O método [getAutoAdjust](https://reference.aspose.com/slides/pt/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) especifica se o tamanho da região de conteúdo lateral deve compensar o novo tamanho ao redimensionar a janela que contém a visualização dentro do aplicativo.

Um exemplo abaixo mostra como acessar as propriedades [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) de uma apresentação.

```java
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

{{% alert color="primary" %}} 

O Aspose.Slides for Java agora oferece suporte à definição do valor de zoom padrão para a apresentação, de modo que, ao abrir a apresentação, o zoom já esteja configurado. Isso pode ser feito definindo as [ViewProperties](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ViewProperties) de uma apresentação. Os métodos [getSlideViewProperties](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) e [getNotesViewProperties](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) podem ser configurados programaticamente. Neste tópico, veremos com um exemplo como definir as [View Properties](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ViewProperties) de uma [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation) em [Aspose.Slides](/slides/pt/).

{{% /alert %}} 

Para definir as propriedades de visualização, siga os passos abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation).  
1. Defina as [View Properties](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ViewProperties) da [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation).  
1. Grave a apresentação como um arquivo [PPTX](https://docs.fileformat.com/presentation/pptx/).  
   No exemplo abaixo, definimos o valor de zoom tanto para a visualização de slide quanto para a visualização de notas.

```java
Presentation presentation = new Presentation();
try {
    // Definindo as propriedades de visualização da apresentação
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Valor de zoom em porcentagem para visualização de slide
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Valor de zoom em porcentagem para visualização de notas 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Posso definir diferentes configurações de visualização para diferentes seções de uma apresentação?**

As [configurações de visualização](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/#getViewProperties--) são definidas ao nível da apresentação ([Normal View](https://reference.aspose.com/slides/pt/java/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/pt/java/com.aspose.slides/viewproperties/#getSlideViewProperties--)), não por seção, de modo que um único conjunto de parâmetros se aplica a todo o documento ao ser aberto.

**Posso pré‑definir diferentes estados de visualização para diferentes usuários?**

Não. As configurações são armazenadas no arquivo e são compartilhadas. Aplicativos de visualização podem respeitar as preferências do usuário, mas o próprio arquivo contém apenas um conjunto de propriedades de visualização.

**Posso criar um modelo com propriedades de visualização pré‑definidas para que novas apresentações sejam abertas da mesma forma?**

Sim. Como as [propriedades de visualização](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/#getViewProperties--) são armazenadas ao nível da apresentação, você pode incorporá‑las em um modelo e criar novos documentos a partir dele com a mesma configuração inicial de visualização.