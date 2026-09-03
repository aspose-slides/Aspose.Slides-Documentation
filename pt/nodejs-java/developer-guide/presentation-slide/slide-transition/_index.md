---
title: Gerenciar Transições de Slides em Apresentações Usando JavaScript
linktitle: Transição de Slide
type: docs
weight: 80
url: /pt/nodejs-java/slide-transition/
keywords:
- transição de slide
- adicionar transição de slide
- aplicar transição de slide
- transição de slide avançada
- transição morph
- tipo de transição
- efeito de transição
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Aplicar transições de slides, configurar o avanço automático dos slides e personalizar Morph e outros efeitos de transição com Aspose.Slides para Node.js via Java."
---
## **Visão geral**

As transições de slide controlam como os slides aparecem durante uma apresentação. Com Aspose.Slides para Node.js via Java, você pode escolher um efeito de transição para cada slide, configurar o avanço por clique do mouse ou por temporizador e ajustar opções específicas de um efeito. Este artigo usa exemplos em JavaScript para aplicar transições, definir durações exatas de transição, gerenciar o tempo dos slides e criar uma transição Morph entre dois slides. Os exemplos também mostram como salvar as configurações em um arquivo PPTX.

## **Adicionar transição ao slide**

Para aplicar uma transição, carregue uma apresentação com a classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/) e acesse as configurações de transição do slide através de [getSlideShowTransition](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition). Use [setType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slideshowtransition/#setType) com um valor da enumeração [TransitionType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/transitiontype/), depois salve a apresentação.

O exemplo a seguir aplica uma transição Circle ao primeiro slide e uma transição Comb ao segundo. Use um arquivo `input.pptx` com pelo menos dois slides.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        presentation.getSlides().get_Item(0).getSlideShowTransition().setType(slides.TransitionType.Circle);
        presentation.getSlides().get_Item(1).getSlideShowTransition().setType(slides.TransitionType.Comb);

        presentation.save("slide-transitions.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **Adicionar transição avançada ao slide**

Você pode configurar quanto tempo um slide permanece na tela e se um clique do mouse avança a apresentação. Os métodos a seguir controlam esse comportamento:

- [setAdvanceOnClick](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) permite que o visualizador avance clicando o mouse.
- [setAdvanceAfter](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) habilita o avanço automático.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) especifica o atraso antes do avanço automático, em milissegundos.

Habilite tanto o avanço por clique quanto por tempo para que o visualizador avance com um clique ou aguarde o temporizador. Para usar apenas o temporizador, passe `false` para [setAdvanceOnClick](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). O atraso controla quando a apresentação avança; ele não define a duração do efeito visual de transição.

Este exemplo atribui efeitos diferentes aos três primeiros slides e habilita o avanço automático após 3, 5 e 7 segundos, respectivamente. Cliques do mouse também podem avançar esses slides. Use um arquivo `input.pptx` com pelo menos três slides.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 3) {
        const firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(slides.TransitionType.Circle);
        firstTransition.setAdvanceOnClick(true);
        firstTransition.setAdvanceAfter(true);
        firstTransition.setAdvanceAfterTime(3000);

        const secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(slides.TransitionType.Comb);
        secondTransition.setAdvanceOnClick(true);
        secondTransition.setAdvanceAfter(true);
        secondTransition.setAdvanceAfterTime(5000);

        const thirdTransition = presentation.getSlides().get_Item(2).getSlideShowTransition();
        thirdTransition.setType(slides.TransitionType.Zoom);
        thirdTransition.setAdvanceOnClick(true);
        thirdTransition.setAdvanceAfter(true);
        thirdTransition.setAdvanceAfterTime(7000);

        presentation.save("advanced-transitions.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The input presentation must contain at least three slides.");
    }
} finally {
    presentation.dispose();
}
```

Para verificar se o avanço cronometrado está habilitado, chame [getAdvanceAfter](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slideshowtransition/#getAdvanceAfter). Um atraso armazenado não indica que o temporizador esteja ativo.

O próximo exemplo abre o arquivo salvo acima, relata cada temporizador habilitado e desabilita o avanço automático para slides com atraso maior que dois segundos. Ele habilita cliques do mouse para esses slides e salva as configurações atualizadas.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("advanced-transitions.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();

        if (transition.getAdvanceAfter()) {
            console.log("Slide " + slide.getSlideNumber() + ": advance after " + transition.getAdvanceAfterTime() + " ms.");

            if (transition.getAdvanceAfterTime() > 2000) {
                transition.setAdvanceAfter(false);
                transition.setAdvanceOnClick(true);
            }
        }
    }

    presentation.save("adjusted-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Controlar o tempo da transição com precisão**

Use [setDuration](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slideshowtransition/#setDuration) para especificar o comprimento exato de um efeito de transição em milissegundos. O método [getSlideShowTransition](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) do slide expõe essas configurações por meio de [SlideShowTransition](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slideshowtransition/) :

| Método | Propósito |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slideshowtransition/#setDuration) | Define a duração do efeito de transição em si, em milissegundos. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Define o atraso antes de o slide avançar automaticamente, em milissegundos. Passe `true` para [setAdvanceAfter](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) para ativar esse temporizador. |
| [setSpeed](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) | Seleciona uma categoria de velocidade predefinida da enumeração [TransitionSpeed](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/transitionspeed/): Slow, Medium ou Fast. É usada quando uma duração exata não é especificada. |

[setDuration](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slideshowtransition/#setDuration) controla apenas o efeito de transição; ele não determina quanto tempo o slide permanece visível. Configure o atraso de avanço automático separadamente. Quando nenhuma duração explícita é definida, Aspose.Slides determina a duração do efeito a partir do tipo de transição e do valor de [getSpeed](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slideshowtransition/#getSpeed).

### **Aplicar a mesma duração a todos os slides**

Para um ritmo consistente, aplique o mesmo efeito e a mesma duração exata a cada slide. Este exemplo carrega `input.pptx`, seleciona Fade da enumeração [TransitionType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/transitiontype/), e define a duração de cada transição em 750 milissegundos. Ele habilita separadamente o avanço automático após 5.000 milissegundos e desabilita o avanço por clique do mouse, então salva o resultado como PPTX.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();
        transition.setType(slides.TransitionType.Fade);
        transition.setDuration(750);

        // Configure o avanço automático independentemente da duração do efeito.
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Definir durações diferentes para slides individuais**

Slides diferentes podem usar durações de efeito diferentes. Por exemplo, use uma transição breve para um slide de título e uma transição mais longa para a introdução de uma seção. Este exemplo define 500 milissegundos para o primeiro slide e 1.200 milissegundos para o segundo. Use um arquivo `input.pptx` com pelo menos dois slides.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        const firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(slides.TransitionType.Fade);
        firstTransition.setDuration(500);

        const secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(slides.TransitionType.Push);
        secondTransition.setDuration(1200);

        presentation.save("individual-transition-durations.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

### **Sincronizar transições com saída animada**

Ao preparar um [animated GIF](/slides/pt/nodejs-java/convert-powerpoint-to-animated-gif/), uma [HTML5 presentation](/slides/pt/nodejs-java/export-to-html5/) ou um [video](/slides/pt/nodejs-java/convert-powerpoint-to-video/), defina durações de transição exatas antes da exportação para corresponder ao ritmo desejado. Por exemplo, use um fade de 600 milissegundos entre cenas e ajuste o atraso de avanço de cada slide separadamente para permitir tempo para narração ou conteúdo.

Para GIF e vídeo, coordene a taxa de quadros da saída com a duração do efeito: 600 milissegundos correspondem a 18 quadros a 30 quadros por segundo. Em HTML5, habilite transições animadas nas configurações de exportação. Verifique os efeitos e opções de tempo suportados pelo formato de exportação escolhido e pré-visualize a saída para confirmar a sincronização.

### **Ler a duração de uma transição existente**

Chame [getDuration](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slideshowtransition/#getDuration) antes de modificar a transição para determinar se um valor explícito está armazenado. Um valor de `-1` indica que nenhuma duração explícita foi definida; um valor não negativo especifica a duração armazenada em milissegundos. O valor não definido não é a duração de reprodução calculada: Aspose.Slides usa o tipo de transição e o valor de [getSpeed](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slideshowtransition/#getSpeed) para determinar essa duração. Definir um tipo de transição pode inicializar uma duração, portanto inspeccione as configurações originais primeiro.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();
        const duration = transition.getDuration();

        if (duration >= 0) {
            console.log("Slide " + slide.getSlideNumber() + ": stored transition duration is " + duration + " ms.");
        } else {
            console.log("Slide " + slide.getSlideNumber() + ": no explicit duration; timing depends on transition type " + transition.getType() + " and speed " + transition.getSpeed() + ".");
        }
    }
} finally {
    presentation.dispose();
}
```

## **Transição Morph**

A transição Morph anima alterações entre objetos em slides consecutivos. Para criar um efeito Morph simples, clone um slide, mova ou redimensione um objeto no clone e aplique a transição Morph ao segundo slide. Isso fornece aos objetos correspondentes a animação entre seus estados original e modificado.

O exemplo a seguir cria um slide com um retângulo de texto, clona o slide e altera a posição e o tamanho do retângulo no clone. Em seguida, seleciona Morph da enumeração [TransitionType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/transitiontype/) para o segundo slide. Abra o arquivo salvo em um visualizador de apresentações que suporte Morph para ver o efeito durante a apresentação.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const rectangle = firstSlide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 400, 100);
    rectangle.getTextFrame().setText("Morph transition");

    const secondSlide = presentation.getSlides().addClone(firstSlide);
    const movedRectangle = secondSlide.getShapes().get_Item(0);
    movedRectangle.setX(movedRectangle.getX() + 100);
    movedRectangle.setY(movedRectangle.getY() + 50);
    movedRectangle.setWidth(movedRectangle.getWidth() - 200);
    movedRectangle.setHeight(movedRectangle.getHeight() - 10);

    secondSlide.getSlideShowTransition().setType(slides.TransitionType.Morph);

    presentation.save("morph-transition.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tipos de transição Morph**

A enumeração [TransitionMorphType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/transitionmorphtype/) controla como o Morph corresponde e anima o conteúdo:

- [ByObject](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/transitionmorphtype/#ByObject) trata cada forma como um objeto completo.
- [ByWord](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/transitionmorphtype/#ByWord) anima o texto correspondendo palavras, quando possível.
- [ByChar](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/transitionmorphtype/#ByChar) anima o texto correspondendo caracteres, quando possível.

Use [setType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slideshowtransition/#setType) para selecionar Morph antes de acessar [getValue](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slideshowtransition/#getValue). O valor então fornece um objeto [MorphTransition](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/morphtransition/), cujo método [setMorphType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/morphtransition/#setMorphType) seleciona o modo de correspondência.

Este exemplo abre a apresentação criada na seção anterior e configura o segundo slide para usar animação Morph baseada em palavras.

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("morph-transition.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        const transition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        transition.setType(slides.TransitionType.Morph);
        const transitionValue = transition.getValue();

        if (java.instanceOf(transitionValue, "com.aspose.slides.IMorphTransition")) {
            transitionValue.setMorphType(slides.TransitionMorphType.ByWord);
            presentation.save("morph-by-word.pptx", slides.SaveFormat.Pptx);
        } else {
            console.log("Morph transition options are unavailable.");
        }
    } else {
        console.log("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **Definir efeitos de transição**

Algumas transições expõem opções adicionais, como direção ou se o efeito inicia a partir de uma tela preta. As opções disponíveis dependem da transição selecionada com [setType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slideshowtransition/#setType). Defina o tipo primeiro, então use o objeto de transição apropriado obtido por [getValue](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slideshowtransition/#getValue).

O exemplo a seguir aplica uma transição Cut ao primeiro slide de `input.pptx`. Ele chama [setFromBlack](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/optionalblacktransition/#setFromBlack) através de [OptionalBlackTransition](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/optionalblacktransition/) para que a transição inicie a partir de uma tela preta.

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const transition = presentation.getSlides().get_Item(0).getSlideShowTransition();
    transition.setType(slides.TransitionType.Cut);
    const transitionValue = transition.getValue();

    if (java.instanceOf(transitionValue, "com.aspose.slides.IOptionalBlackTransition")) {
        transitionValue.setFromBlack(true);
        presentation.save("cut-from-black.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("Cut transition options are unavailable.");
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Posso controlar a velocidade de reprodução de uma transição de slide?**

Sim. Prefira [setDuration](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slideshowtransition/#setDuration) quando precisar de uma duração exata do efeito em milissegundos. Use [setSpeed](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) quando uma categoria predefinida de [TransitionSpeed](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/transitionspeed/) — Slow, Medium ou Fast — for suficiente e nenhuma duração explícita for definida. Essas configurações controlam o efeito de transição independentemente do atraso de avanço automático.

**Posso anexar áudio a uma transição e fazê‑lo repetir?**

Sim. Defina áudio incorporado com [setSound](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slideshowtransition/#setSound), passe StartSound da enumeração [TransitionSoundMode](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/transitionsoundmode/) para [setSoundMode](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slideshowtransition/#setSoundMode) e habilite [setSoundLoop](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slideshowtransition/#setSoundLoop) com `true`. O áudio se repete até o próximo evento sonoro na apresentação.

**Qual é a maneira mais rápida de aplicar a mesma transição a todos os slides?**

Percorra a coleção [getSlides](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/#getSlides) da apresentação e chame [setType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slideshowtransition/#setType) com o mesmo valor para a transição de cada slide. Defina quaisquer opções de tempo e efeito no mesmo loop para manter o comportamento consistente em todos os slides.

**Como posso verificar qual transição está definida atualmente em um slide?**

Chame [getType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slideshowtransition/#getType) no resultado de [getSlideShowTransition](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) do slide. Ele retorna um valor da enumeração [TransitionType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/transitiontype/); None significa que nenhum efeito de transição foi aplicado.