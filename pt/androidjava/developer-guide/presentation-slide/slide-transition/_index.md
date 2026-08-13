---
title: Gerenciar Transições de Slides em Apresentações no Android
linktitle: Transição de Slide
type: docs
weight: 80
url: /pt/androidjava/slide-transition/
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
- Android
- Java
- Aspose.Slides
description: "Descubra como personalizar transições de slides no Aspose.Slides for Android via Java, com orientações passo a passo para apresentações PowerPoint e OpenDocument."
---
## **Visão geral**

Este artigo explica como gerenciar transições de slides em apresentações usando Aspose.Slides. Ele mostra como aplicar tipos de transição a slides, configurar o comportamento da transição, como avançar ao clicar ou após um período de tempo especificado, usar a transição Morph e seus tipos, e definir opções de efeito de transição. Os exemplos demonstram como carregar ou criar uma apresentação, modificar as configurações de transição para slides selecionados e salvar o resultado como um arquivo PPTX. O artigo também responde a perguntas comuns sobre velocidade da transição, sons de transição, aplicação da mesma transição a vários slides e como verificar a transição atualmente definida em um slide.

## **Adicionar Transição de Slide**
Para criar um efeito simples de transição de slide, siga as etapas abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation).
2. Aplique um Slide Transition Type no slide a partir de um dos efeitos de transição oferecidos por Aspose.Slides for Android via Java através do enum TransitionType.
3. Grave o arquivo de apresentação modificado.

```java
import com.aspose.slides.*;

// Instanciar a classe Presentation para carregar o arquivo de apresentação fonte
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Aplicar transição do tipo círculo no slide 1
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Aplicar transição do tipo pente no slide 2
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // Gravar a apresentação no disco
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Adicionar Transição de Slide Avançada**
Na seção anterior, aplicamos apenas um efeito de transição simples ao slide. Agora, para tornar esse efeito ainda melhor e controlado, siga as etapas abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation).
2. Aplique um Slide Transition Type no slide a partir de um dos efeitos de transição oferecidos por Aspose.Slides for Android via Java.
3. Você também pode definir a transição para Avançar ao Clicar, após um período de tempo específico ou ambos.
4. Se a transição do slide estiver habilitada para Avançar ao Clicar, a transição avançará apenas quando alguém clicar o mouse. Além disso, se a propriedade Advance After Time estiver definida, a transição avançará automaticamente após o tempo especificado.
5. Grave a apresentação modificada como um arquivo de apresentação.

```java
import com.aspose.slides.*;

// Instanciar a classe Presentation que representa um arquivo de apresentação
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // Aplicar transição do tipo círculo no slide 1
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Avançar ao clicar ou automaticamente após 3 segundos
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // Aplicar transição do tipo pente no slide 2
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // Avançar ao clicar ou automaticamente após 5 segundos
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // Aplicar transição do tipo zoom no slide 3
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // Avançar ao clicar ou automaticamente após 7 segundos
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);

    // Gravar a apresentação no disco
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Transição Morph**
{{% alert color="info" %}} 

Aspose.Slides for Android via Java agora suporta a [Morph Transition](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IMorphTransition). Ela representa a nova transição morph introduzida no PowerPoint 2019.

{{% /alert %}} 

A transição Morph permite animar um movimento suave de um slide para o próximo. Este artigo descreve o conceito e como usar a transição Morph. Para usar a transição Morph de forma eficaz, você precisará de dois slides com pelo menos um objeto em comum. A maneira mais fácil é duplicar o slide e então mover o objeto no segundo slide para outro local.

O trecho de código a seguir mostra como adicionar uma cópia do slide com algum texto à apresentação e definir uma transição do [morph type](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/TransitionType) no segundo slide.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    AutoShape autoshape = (AutoShape)presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.getTextFrame().setText("Morph Transition in PowerPoint Presentations");

    presentation.getSlides().addClone(presentation.getSlides().get_Item(0));

    IShape shape = presentation.getSlides().get_Item(1).getShapes().get_Item(0);
    shape.setX(shape.getX() + 100);
    shape.setY(shape.getY() + 50);
    shape.setWidth(shape.getWidth() - 200);
    shape.setHeight(shape.getHeight() - 10);

    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(com.aspose.slides.TransitionType.Morph);

    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **Tipos de Transição Morph**
Um novo enum [TransitionMorphType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/TransitionMorphType) foi adicionado. Ele representa diferentes tipos de transição de slide Morph.

O enum TransitionMorphType possui três membros:

- ByObject: a transição Morph será executada considerando as formas como objetos indivisíveis.
- ByWord: a transição Morph será executada transferindo o texto por palavras, quando possível.
- ByChar: a transição Morph será executada transferindo o texto por caracteres, quando possível.

O trecho de código a seguir mostra como definir a transição morph em um slide e alterar o tipo morph:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Morph);
    ((IMorphTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setMorphType(TransitionMorphType.ByWord);
    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Definir Efeitos de Transição**
Aspose.Slides for Android via Java suporta a definição de efeitos de transição como, de preto, da esquerda, da direita etc. Para definir o efeito de transição, siga as etapas abaixo:

- Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation).
- Obtenha a referência do slide.
- Defina o efeito de transição.
- Grave a apresentação como um [PPTX](https://docs.fileformat.com/presentation/pptx/) arquivo.

No exemplo abaixo, definimos os efeitos de transição.

```java
import com.aspose.slides.*;

// Criar uma instância da classe Presentation
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Definir efeito
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Cut);
    ((OptionalBlackTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setFromBlack(true);
    
    // Gravar a apresentação no disco
    presentation.save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

### Posso controlar a velocidade de reprodução de uma transição de slide?

Sim. Defina a [speed](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/slideshowtransition/#setSpeed-int-) da transição usando a configuração [TransitionSpeed](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/transitionspeed/) (por exemplo, lento/médio/rápido).

### Posso anexar áudio a uma transição e fazê-lo repetir?

Sim. Você pode incorporar um som à transição e controlar o comportamento através de configurações como modo de som e repetição (por exemplo, [setSound](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-), [setSoundMode](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/slideshowtransition/#setSoundMode-int-), [setSoundLoop](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-), além de metadados como [setSoundIsBuiltIn](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) e [setSoundName](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-)).

### Qual é a maneira mais rápida de aplicar a mesma transição a todos os slides?

Configure o tipo de transição desejado nas configurações de transição de cada slide; as transições são armazenadas por slide, portanto aplicar o mesmo tipo a todos os slides gera um resultado consistente.

### Como posso verificar qual transição está atualmente definida em um slide?

Consulte as [transition settings](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/baseslide/#getSlideShowTransition--) do slide e leia seu [transition type](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/slideshowtransition/#setType-int-); esse valor indica exatamente qual efeito está aplicado.