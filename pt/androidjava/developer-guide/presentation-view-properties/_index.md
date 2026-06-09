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
description: "Descubra as propriedades de visualização do Aspose.Slides for Android via Java para personalizar formatos de slides PPT, PPTX e ODP — ajuste layout, níveis de zoom e configurações de exibição."
---
## **Introdução**

A visualização normal consiste em três regiões de conteúdo: o próprio slide, uma região de conteúdo lateral e uma região de conteúdo inferior. As propriedades referentes ao posicionamento das diferentes regiões de conteúdo. Essas informações permitem que o aplicativo salve seu estado de visualização no arquivo, de modo que, ao ser reaberto, a visualização esteja no mesmo estado em que a apresentação foi salva pela última vez.

O método [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) foi adicionado para fornecer acesso às propriedades da visualização normal da apresentação.  

As interfaces [INormalViewProperties](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/INormalViewRestoredProperties) e seus descendentes, bem como o enum [SplitterBarStateType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/SplitterBarStateType) foram adicionados.

## **Sobre INormalViewProperties**

Representa as propriedades da visualização normal.

Os métodos [getShowOutlineIcons](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) e [setShowOutlineIcons](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) especificam se o aplicativo deve exibir ícones ao mostrar o conteúdo do contorno em qualquer uma das regiões de conteúdo do modo de visualização normal.

Os métodos [getSnapVerticalSplitter](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) e [setSnapVerticalSplitter](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) especificam se o divisor vertical deve travar em um estado minimizado quando a região lateral está suficientemente pequena.

A propriedade [getPreferSingleView](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) e [setPreferSingleView](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) especificam se o usuário prefere ver uma região de conteúdo única em tela cheia em vez da visualização normal padrão com três regiões de conteúdo. Se habilitado, o aplicativo pode optar por exibir uma das regiões de conteúdo em toda a janela.

Os métodos [getVerticalBarState](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) e [getHorizontalBarState](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) especificam o estado em que a barra divisor horizontal ou vertical deve ser exibida. Uma barra divisor horizontal separa o slide da região de conteúdo abaixo do slide, e a barra divisor vertical separa o slide da região de conteúdo lateral. Os valores possíveis são: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) e [SplitterBarStateType.Restored](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

Os métodos [getRestoredLeft](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) e [getRestoredTop](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) especificam o dimensionamento da região superior ou lateral do slide da visualização normal, quando o valor [SplitterBarStateType.Restored](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/SplitterBarStateType#Restored) for aplicado a [getVerticalBarState](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) e [getHorizontalBarState](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) respectivamente.

## **Sobre Restaurar INormalViewProperties**

Especifica o dimensionamento da região do slide (largura quando filho de [getRestoredTop](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/INormalViewRestoredProperties#getRestoredTop--), altura quando filho de [getRestoredLeft](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/INormalViewRestoredProperties#getRestoredLeft--)) da visualização normal, quando a região tem um tamanho restaurado variável (nem minimizado nem maximizado).  

O método [getDimensionSize](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) especifica o tamanho da região do slide (largura quando filho de restoredTop, altura quando filho de restoredLeft).  

O método [getAutoAdjust](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) especifica se o tamanho da região de conteúdo lateral deve compensar o novo tamanho ao redimensionar a janela que contém a visualização dentro do aplicativo.  

Um exemplo abaixo mostra como acessar as propriedades [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) de uma apresentação.

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

O Aspose.Slides for Android via Java agora suporta a definição do valor de zoom padrão para a apresentação, de modo que, quando a apresentação for aberta, o zoom já esteja definido. Isso pode ser feito configurando o [ViewProperties](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ViewProperties) de uma apresentação. Tanto [getSlideViewProperties](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) quanto [getNotesViewProperties](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) podem ser definidas programaticamente. Neste tópico, veremos com um exemplo como definir as [View Properties](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ViewProperties) de [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation) em [Aspose.Slides](/slides/pt/).

{{% /alert %}} 

Para definir as propriedades de visualização, siga os passos abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation).
1. Defina as [View Properties](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ViewProperties) de [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation).
1. Salve a apresentação como um arquivo [PPTX](https://docs.fileformat.com/presentation/pptx/). No exemplo abaixo, definimos o valor de zoom para a visualização de slides e também para a visualização de notas.

```java
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

## **Perguntas Frequentes**

**Posso definir configurações de visualização diferentes para diferentes seções de uma apresentação?**

As configurações de visualização são definidas no nível da apresentação ([Normal View](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/viewproperties/#getSlideViewProperties--)), não por seção, portanto um único conjunto de parâmetros se aplica a todo o documento quando ele é aberto.

**Posso pré-definir diferentes estados de visualização para diferentes usuários?**

Não. As configurações são armazenadas no arquivo e são compartilhadas. Aplicativos de visualização podem respeitar as preferências do usuário, mas o arquivo em si contém um único conjunto de propriedades de visualização.

**Posso preparar um modelo com View Properties pré-definidas para que novas apresentações abram da mesma forma?**

Sim. Como as propriedades de visualização são armazenadas no nível da apresentação, você pode incorporá‑las em um modelo e criar novos documentos a partir dele com a mesma configuração inicial de visualização.