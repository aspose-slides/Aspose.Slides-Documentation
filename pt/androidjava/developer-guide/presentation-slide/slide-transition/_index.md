---
title: Gerenciar Transições de Slide em Apresentações no Android
linktitle: Transição de Slide
type: docs
weight: 80
url: /pt/androidjava/slide-transition/
keywords:
- transição de slide
- adicionar transição de slide
- aplicar transição de slide
- transição avançada de slide
- transição morph
- tipo de transição
- efeito de transição
- PowerPoint
- OpenDocument
- apresentação
- Android
- Java
- Aspose.Slides
description: "Aplicar transições de slide, configurar avanço automático de slides e personalizar Morph e outros efeitos de transição com Aspose.Slides para Android via Java."
---
## **Visão Geral**

As transições de slide controlam como os slides aparecem durante uma apresentação. Com Aspose.Slides para Android via Java, você pode escolher um efeito de transição para cada slide, configurar o avanço por clique do mouse ou por temporizador, e ajustar opções específicas de um efeito. Este artigo usa exemplos em Java para aplicar transições, definir durações exatas de transição, gerenciar o tempo dos slides e criar uma transição Morph entre dois slides. Os exemplos também mostram como salvar as configurações em um arquivo PPTX.

## **Adicionar Transição de Slide**

Para aplicar uma transição, carregue uma apresentação com a classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/) e acesse as configurações de transição do slide através de [getSlideShowTransition](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--). Use [setType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) com um valor da enumeração [TransitionType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/transitiontype/), então salve a apresentação.

O exemplo a seguir aplica uma transição Circle ao primeiro slide e uma transição Comb ao segundo. Use um arquivo `input.pptx` com pelo menos dois slides.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);
        presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

        presentation.save("slide-transitions.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **Adicionar Transição de Slide Avançada**

Você pode configurar quanto tempo um slide permanece na tela e se um clique do mouse avança a apresentação. Os seguintes métodos controlam esse comportamento:

- [setAdvanceOnClick](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) permite que o visualizador avance clicando o mouse.
- [setAdvanceAfter](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) habilita o avanço automático.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) especifica o atraso antes do avanço automático, em milissegundos.

Habilite tanto o avanço por clique quanto por tempo para permitir que o visualizador avance com um clique ou espere o temporizador. Para usar apenas o temporizador, passe `false` para [setAdvanceOnClick](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-). O atraso controla quando a apresentação avança; não define a duração do efeito visual de transição.

Este exemplo atribui efeitos diferentes aos três primeiros slides e habilita o avanço automático após 3, 5 e 7 segundos, respectivamente. Cliques do mouse também podem avançar esses slides. Use um arquivo `input.pptx` com pelo menos três slides.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 3) {
        ISlideShowTransition firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(TransitionType.Circle);
        firstTransition.setAdvanceOnClick(true);
        firstTransition.setAdvanceAfter(true);
        firstTransition.setAdvanceAfterTime(3000);

        ISlideShowTransition secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(TransitionType.Comb);
        secondTransition.setAdvanceOnClick(true);
        secondTransition.setAdvanceAfter(true);
        secondTransition.setAdvanceAfterTime(5000);

        ISlideShowTransition thirdTransition = presentation.getSlides().get_Item(2).getSlideShowTransition();
        thirdTransition.setType(TransitionType.Zoom);
        thirdTransition.setAdvanceOnClick(true);
        thirdTransition.setAdvanceAfter(true);
        thirdTransition.setAdvanceAfterTime(7000);

        presentation.save("advanced-transitions.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The input presentation must contain at least three slides.");
    }
} finally {
    presentation.dispose();
}
```

Para verificar se o avanço cronometrado está habilitado, chame [getAdvanceAfter](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/islideshowtransition/#getAdvanceAfter-). Um atraso armazenado sozinho não indica que o temporizador está ativo.

O próximo exemplo abre o arquivo salvo acima, relata cada temporizador habilitado e desativa o avanço automático para slides com atraso maior que dois segundos. Ele habilita cliques do mouse para esses slides e salva as configurações atualizadas.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("advanced-transitions.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();

        if (transition.getAdvanceAfter()) {
            System.out.println("Slide " + slide.getSlideNumber() + ": advance after " + transition.getAdvanceAfterTime() + " ms.");

            if (transition.getAdvanceAfterTime() > 2000) {
                transition.setAdvanceAfter(false);
                transition.setAdvanceOnClick(true);
            }
        }
    }

    presentation.save("adjusted-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Controlar o Tempo da Transição com Precisão**

Use [setDuration](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) para especificar o comprimento exato de um efeito de transição em milissegundos. O método [getSlideShowTransition](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) do slide expõe essas configurações através de [ISlideShowTransition](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/islideshowtransition/):

| Método | Propósito |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) | Define a duração do próprio efeito de transição, em milissegundos. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | Define o atraso antes que o slide avance automaticamente, em milissegundos. Passe `true` para [setAdvanceAfter](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) para ativar esse temporizador. |
| [setSpeed](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-) | Seleciona uma categoria de velocidade predefinida da [TransitionSpeed](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/transitionspeed/): Slow, Medium ou Fast. É usada quando uma duração exata não é especificada. |

[setDuration](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) controla apenas o efeito de transição; não determina quanto tempo o slide permanece visível. Configure o atraso de avanço automático separadamente. Quando nenhuma duração explícita é definida, o Aspose.Slides determina a duração do efeito a partir do tipo de transição e do valor de [getSpeed](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/islideshowtransition/#getSpeed--).

### **Aplicar a Mesma Duração a Cada Slide**

Para um ritmo consistente, aplique o mesmo efeito e a mesma duração exata a cada slide. Este exemplo carrega `input.pptx`, seleciona Fade da [TransitionType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/transitiontype/), e atribui a cada transição uma duração de 750 milissegundos. Ele habilita separadamente o avanço automático após 5.000 milissegundos e desabilita o avanço por clique do mouse, então salva o resultado como PPTX.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Fade);
        transition.setDuration(750);

        // Configure o avanço automático independentemente da duração do efeito.
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Definir Durações Diferentes para Slides Individuais**

Slides diferentes podem usar durações de efeito diferentes. Por exemplo, use uma transição breve para um slide de título e uma transição mais longa para a introdução de uma seção. Este exemplo define 500 milissegundos para o primeiro slide e 1.200 milissegundos para o segundo. Use um arquivo `input.pptx` com pelo menos dois slides.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        ISlideShowTransition firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(TransitionType.Fade);
        firstTransition.setDuration(500);

        ISlideShowTransition secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(TransitionType.Push);
        secondTransition.setDuration(1200);

        presentation.save("individual-transition-durations.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

### **Coordenar Transições com Saída Animada**

Ao preparar um [animated GIF](/slides/pt/androidjava/convert-powerpoint-to-animated-gif/), uma [HTML5 presentation](/slides/pt/androidjava/export-to-html5/) ou um [video](/slides/pt/androidjava/convert-powerpoint-to-video/), defina durações exatas de transição antes da exportação para corresponder ao ritmo desejado. Por exemplo, use um fade de 600 milissegundos entre cenas e ajuste o atraso de avanço de cada slide separadamente para permitir tempo para sua narração ou conteúdo.

Para GIF e vídeo, coordene a taxa de quadros da saída com a duração do efeito: 600 milissegundos correspondem a 18 quadros a 30 quadros por segundo. No HTML5, habilite transições animadas nas configurações de exportação. Verifique os efeitos e opções de tempo suportados pelo formato de exportação escolhido e visualize a saída para confirmar a sincronização.

### **Ler a Duração de Transição Existente**

Chame [getDuration](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/islideshowtransition/#getDuration--) antes de modificar a transição para determinar se um valor explícito está armazenado. Um valor de `-1` significa que nenhuma duração explícita está definida; um valor não negativo especifica a duração armazenada em milissegundos. O valor não definido não é a duração de reprodução calculada: o Aspose.Slides usa o tipo de transição e o valor de [getSpeed](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/islideshowtransition/#getSpeed--) para determinar essa duração. Definir um tipo de transição pode inicializar uma duração, portanto, inspecione primeiro as configurações originais.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        int duration = transition.getDuration();

        if (duration >= 0) {
            System.out.println("Slide " + slide.getSlideNumber() + ": stored transition duration is " + duration + " ms.");
        } else {
            System.out.println("Slide " + slide.getSlideNumber() + ": no explicit duration; timing depends on transition type " + transition.getType() + " and speed " + transition.getSpeed() + ".");
        }
    }
} finally {
    presentation.dispose();
}
```

## **Transição Morph**

A transição Morph anima mudanças entre objetos em slides consecutivos. Para criar um efeito Morph simples, clone um slide, mova ou redimensione um objeto no clone e aplique a transição Morph ao segundo slide. Isso fornece à transição os objetos correspondentes para animar entre seus estados original e modificado.

O exemplo a seguir cria um slide com um retângulo de texto, clona o slide e altera a posição e o tamanho do retângulo no clone. Em seguida, seleciona Morph da enumeração [TransitionType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/transitiontype/) para o segundo slide. Abra o arquivo salvo em um visualizador de apresentações que suporte Morph para ver o efeito durante a apresentação.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    IAutoShape rectangle = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    rectangle.getTextFrame().setText("Morph transition");

    ISlide secondSlide = presentation.getSlides().addClone(firstSlide);
    IShape movedRectangle = secondSlide.getShapes().get_Item(0);
    movedRectangle.setX(movedRectangle.getX() + 100);
    movedRectangle.setY(movedRectangle.getY() + 50);
    movedRectangle.setWidth(movedRectangle.getWidth() - 200);
    movedRectangle.setHeight(movedRectangle.getHeight() - 10);

    secondSlide.getSlideShowTransition().setType(TransitionType.Morph);

    presentation.save("morph-transition.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tipos de Transição Morph**

A enumeração [TransitionMorphType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/transitionmorphtype/) controla como o Morph combina e anima o conteúdo:

- [ByObject](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/transitionmorphtype/#ByObject) trata cada forma como um objeto inteiro.
- [ByWord](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/transitionmorphtype/#ByWord) anima texto combinando palavras onde possível.
- [ByChar](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/transitionmorphtype/#ByChar) anima texto combinando caracteres onde possível.

Use [setType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) para selecionar Morph antes de acessar [getValue](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/islideshowtransition/#getValue--). O valor então fornece a interface [IMorphTransition](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/imorphtransition/), cujo método [setMorphType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/imorphtransition/#setMorphType-int-) seleciona o modo de correspondência.

Este exemplo abre a apresentação criada na seção anterior e configura o segundo slide para usar animação Morph baseada em palavras.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("morph-transition.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        ISlideShowTransition transition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        transition.setType(TransitionType.Morph);
        ITransitionValueBase transitionValue = transition.getValue();

        if (transitionValue instanceof IMorphTransition) {
            IMorphTransition morphTransition = (IMorphTransition) transitionValue;
            morphTransition.setMorphType(TransitionMorphType.ByWord);
            presentation.save("morph-by-word.pptx", SaveFormat.Pptx);
        } else {
            System.out.println("Morph transition options are unavailable.");
        }
    } else {
        System.out.println("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **Definir Efeitos de Transição**

Algumas transições expõem opções adicionais, como direção ou se o efeito começa a partir de uma tela preta. As opções disponíveis dependem da transição selecionada com [setType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/islideshowtransition/#setType-int-). Defina o tipo primeiro, então use a interface apropriada de [getValue](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/islideshowtransition/#getValue--).

O exemplo a seguir aplica uma transição Cut ao primeiro slide de `input.pptx`. Ele chama [setFromBlack](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-) através de [IOptionalBlackTransition](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ioptionalblacktransition/) para que a transição comece a partir de uma tela preta.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlideShowTransition transition = presentation.getSlides().get_Item(0).getSlideShowTransition();
    transition.setType(TransitionType.Cut);
    ITransitionValueBase transitionValue = transition.getValue();

    if (transitionValue instanceof IOptionalBlackTransition) {
        IOptionalBlackTransition cutTransition = (IOptionalBlackTransition) transitionValue;
        cutTransition.setFromBlack(true);
        presentation.save("cut-from-black.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("Cut transition options are unavailable.");
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Posso controlar a velocidade de reprodução de uma transição de slide?**

Sim. Prefira [setDuration](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) quando precisar de uma duração exata do efeito em milissegundos. Use [setSpeed](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-) quando uma categoria predefinida de [TransitionSpeed](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/transitionspeed/) — Slow, Medium ou Fast — for suficiente e nenhuma duração explícita estiver definida. Essas configurações controlam o efeito de transição independentemente do atraso de avanço automático.

**Posso anexar áudio a uma transição e fazê-lo repetir?**

Sim. Atribua áudio incorporado com [setSound](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/islideshowtransition/#setSound-com.aspose.slides.IAudio-), passe StartSound da enumeração [TransitionSoundMode](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/transitionsoundmode/) para [setSoundMode](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/islideshowtransition/#setSoundMode-int-), e habilite [setSoundLoop](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/islideshowtransition/#setSoundLoop-boolean-) com `true`. O áudio repete até o próximo evento de som na apresentação.

**Qual é a maneira mais rápida de aplicar a mesma transição a todos os slides?**

Percorra a coleção [getSlides](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/#getSlides--) da apresentação e chame [setType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) com o mesmo valor para a transição de cada slide. Defina quaisquer opções de tempo e efeito no mesmo loop para manter o comportamento consistente entre os slides.

**Como posso verificar qual transição está atualmente definida em um slide?**

Chame [getType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/islideshowtransition/#getType--) no resultado de [getSlideShowTransition](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) do slide. Ele retorna um valor da enumeração [TransitionType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/transitiontype/); None significa que nenhum efeito de transição foi aplicado.