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
- encaixar divisor vertical
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
description: "Descubra as propriedades de visualização do Aspose.Slides para Android via Java para personalizar os formatos de slides PPT, PPTX e ODP — ajuste layouts, níveis de zoom e configurações de exibição."
---
## **Introdução**

A visualização normal consiste em três regiões de conteúdo: o próprio slide, uma região de conteúdo lateral e uma região de conteúdo inferior. Propriedades relacionadas ao posicionamento das diferentes regiões de conteúdo. Essas informações permitem que o aplicativo salve o estado da visualização no arquivo, de modo que, ao ser reaberto, a visualização esteja no mesmo estado em que a apresentação foi salva pela última vez.

O método[IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) foi adicionado para fornecer acesso às propriedades da visualização normal da apresentação.  

As interfaces[INormalViewProperties](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/INormalViewProperties),[INormalViewRestoredProperties](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/INormalViewRestoredProperties) e seus descendentes, o enum[SplitterBarStateType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/SplitterBarStateType) foram adicionados.

## **Sobre INormalViewProperties**

Representa as propriedades da visualização normal.

Os métodos[getShowOutlineIcons](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) e[setShowOutlineIcons](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) especificam se o aplicativo deve mostrar ícones ao exibir o conteúdo de contorno em qualquer das regiões de conteúdo do modo de visualização normal.

Os métodos[getSnapVerticalSplitter](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) e[setSnapVerticalSplitter](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) especificam se a divisória vertical deve ser reduzida a um estado minimizado quando a região lateral estiver suficientemente pequena.

A propriedade[getPreferSingleView](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) e[setPreferSingleView](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) especificam se o usuário prefere ver uma única região de conteúdo em tela cheia ao invés da visualização normal padrão com três regiões de conteúdo. Se ativado, o aplicativo pode escolher exibir uma das regiões de conteúdo em toda a janela.

Os métodos[getVerticalBarState](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) e[getHorizontalBarState](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) especificam o estado em que a barra divisória horizontal ou vertical deve ser exibida. Uma barra divisória horizontal separa o slide da região de conteúdo abaixo do slide, enquanto a barra divisória vertical separa o slide da região de conteúdo lateral. Os valores possíveis são:[SplitterBarStateType.Minimized](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/SplitterBarStateType#Minimized),[SplitterBarStateType.Maximized](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) e[SplitterBarStateType.Restored](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

Os métodos[getRestoredLeft](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) e[getRestoredTop](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) especificam o dimensionamento da região superior ou lateral do slide na visualização normal, quando o valor[SplitterBarStateType.Restored](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/SplitterBarStateType#Restored) for aplicado para[getVerticalBarState](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) e[getHorizontalBarState](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) respectivamente.

## **Sobre Restaurar INormalViewProperties**

Especifica o dimensionamento da região do slide (largura quando filho de[getRestoredTop](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--), altura quando filho de[getRestoredLeft](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) da visualização normal, quando a região tem um tamanho restaurado variável (nem minimizado nem maximizado).  

O método[getDimensionSize](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) especifica o tamanho da região do slide (largura quando filho de restoredTop, altura quando filho de restoredLeft).  

O método[getAutoAdjust](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) especifica se o tamanho da região de conteúdo lateral deve compensar o novo tamanho ao redimensionar a janela que contém a visualização dentro do aplicativo.  

Um exemplo abaixo mostra como acessar as propriedades[ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) para uma apresentação.

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

O Aspose.Slides para Android via Java agora suporta a definição do valor de zoom padrão para a apresentação, de modo que, ao abrir a apresentação, o zoom já esteja configurado. Isso pode ser feito definindo as[ViewProperties](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ViewProperties) de uma apresentação. Os métodos[getSlideViewProperties](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) e[getNotesViewProperties](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) podem ser configurados programaticamente. Neste tópico, veremos com um exemplo como definir as[View Properties](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ViewProperties) da[Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation) no[Aspose.Slides](/slides/pt/).

{{% /alert %}} 

Para definir as propriedades de visualização, siga os passos abaixo:

1. Crie uma instância da classe[Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation).
1. Defina as[View Properties](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ViewProperties) da[Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation).
1. Grave a apresentação como um arquivo[PPTX](https://docs.fileformat.com/presentation/pptx/).  
   No exemplo abaixo, definimos o valor de zoom para a visualização de slides assim como para a visualização de notas.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Definindo as propriedades de visualização da apresentação
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Valor de zoom em porcentagem para a visualização de slides
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Valor de zoom em porcentagem para a visualização de notas 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

### Posso definir diferentes configurações de visualização para diferentes seções de uma apresentação?

As[configurações de visualização](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/#getViewProperties--) são definidas no nível da apresentação ([Visualização Normal](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Visualização de Slide](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/viewproperties/#getSlideViewProperties--)), não por seção, portanto um único conjunto de parâmetros se aplica a todo o documento quando ele é aberto.

### Posso pré-definir diferentes estados de visualização para diferentes usuários?

Não. As configurações são armazenadas no arquivo e são compartilhadas. Aplicativos de visualização podem respeitar preferências do usuário, mas o próprio arquivo contém um único conjunto de propriedades de visualização.

### Posso preparar um modelo com Propriedades de Visualização predefinidas para que novas apresentações abram da mesma forma?

Sim. Como as[propriedades de visualização](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/#getViewProperties--) são armazenadas no nível da apresentação, você pode incorporá‑las em um modelo e criar novos documentos a partir dele com a mesma configuração de visualização inicial.