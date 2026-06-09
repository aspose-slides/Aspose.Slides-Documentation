---
title: Gerenciar Slides Masters de Apresentação em JavaScript
linktitle: Slide Master
type: docs
weight: 70
url: /pt/nodejs-java/slide-master/
keywords:
- slide master
- slide mestre
- slide mestre PPT
- múltiplos slides masters
- comparar slides masters
- plano de fundo
- placeholder
- clonar slide master
- copiar slide master
- duplicar slide master
- slide master não usado
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Gerencie slides masters no Aspose.Slides para Node.js via Java: acesse, edite, clone, compare e remova slides masters em apresentações PowerPoint e OpenDocument."
---
## **Visão geral**

Um **slide master** define configurações de design compartilhadas para um grupo de slides. Ele pode conter formas comuns, logotipos, fundos, estilos de texto, configurações de tema e de rodapé. No PowerPoint, editar um slide master é a maneira usual de manter uma apresentação consistente sem repetir a mesma formatação em cada slide.

Aspose.Slides for Node.js via Java suporta o mesmo modelo. Uma apresentação pode conter um ou mais slide masters, e cada slide master pode conter vários layout slides. Slides normais normalmente não referenciam um slide master diretamente. Em vez disso, um slide normal usa um layout slide, e esse layout slide pertence a um slide master.

A hierarquia é:

1. **Slide master** - define o design e o tema compartilhados.
1. **Layout slide** - define um arranjo específico de placeholders e formatação ao nível do layout.
1. **Normal slide** - contém o conteúdo real da apresentação e usa um layout slide.

![A hierarquia de slide masters, layout slides e slides normais](slide-master_2.jpg)

No Aspose.Slides, um slide master é representado pela classe [MasterSlide](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/masterslide/). Todos os slide masters em uma apresentação estão disponíveis através da coleção `Presentation.getMasters()`.

{{% alert color="info" title="Inheritance" %}}
Quando a mesma propriedade é definida em mais de um nível, o nível mais específico prevalece. Por exemplo, se um slide master e um layout slide ambos definirem um fundo, os slides baseados nesse layout usam o fundo do layout. Para mais informações sobre layout slides, veja [Apply or Change Slide Layouts](/nodejs-java/slide-layout/).
{{% /alert %}}

## **Acessar Slide Masters**

No PowerPoint, você pode abrir a visualização Slide Master em **View** > **Slide Master**.

![O comando Slide Master na guia View do PowerPoint](slide-master_3.jpg)

No Aspose.Slides, use a coleção `getMasters()` para acessar slide masters:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let firstMasterSlide = presentation.getMasters().get_Item(0);
    let masterSlideCount = presentation.getMasters().size();
    let firstMasterLayoutSlideCount = firstMasterSlide.getLayoutSlides().size();

    console.log("Master slides: " + masterSlideCount);
    console.log("Layouts in the first master: " + firstMasterLayoutSlideCount);
} finally {
    presentation.dispose();
}
```

Você também pode obter o slide master usado por um slide normal através de seu layout:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let layoutSlide = slide.getLayoutSlide();
    let masterSlide = layoutSlide.getMasterSlide();
    let masterSlideName = masterSlide.getName();

    console.log(masterSlideName);
} finally {
    presentation.dispose();
}
```

## **O que um Slide Master contém**

Um slide master é um objeto semelhante a um slide. Ele herda o comportamento comum de slide de [BaseSlide](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/baseslide/), portanto expõe muitas das mesmas propriedades de slide usadas por slides normais e de layout. Os membros específicos do master estão listados na página da API [MasterSlide](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/masterslide/).

Membros de slide master comumente usados incluem:

| Membro | Finalidade |
| --- | --- |
| `getBackground()` | Define o fundo do slide no nível master. |
| `getShapes()` | Armazena as formas colocadas no master, como logotipos, molduras de imagem e texto compartilhado. |
| `getLayoutSlides()` | Armazena os layout slides que pertencem ao master. |
| `getThemeManager()` | Fornece acesso às APIs de tema do master. |
| `getHeaderFooterManager()` | Controla cabeçalhos, rodapés, datas e números de slide para o master e seus layouts filhos. |
| `getDependingSlides()` | Retorna os slides normais que dependem do master através de seus layouts. |

## **Adicionar uma imagem a um Slide Master**

Quando você adiciona uma imagem a um slide master, ela aparece nos slides que usam layouts desse master. Isso é útil para logotipos, marcas d'água, faixas decorativas e outros elementos visuais repetidos.

O exemplo a seguir adiciona um logotipo ao primeiro slide master:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let logo = aspose.slides.Images.fromFile("logo.png");

    try {
        let logoImage = presentation.getImages().addImage(logo);

        masterSlide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle,
            20,
            20,
            80,
            80,
            logoImage);
    } finally {
        logo.dispose();
    }

    presentation.save("presentation-with-logo.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Para mais informações sobre molduras de imagem, veja [Picture Frame](/nodejs-java/picture-frame/).

## **Trabalhar com placeholders**

Placeholders são normalmente definidos em layout slides. O slide master fornece o estilo e o tema compartilhados que esses layouts herdaram, enquanto cada layout decide quais placeholders estão disponíveis e onde são posicionados.

No PowerPoint, comandos de placeholder estão disponíveis na visualização Slide Master.

![O comando Inserir Placeholder na visualização Slide Master do PowerPoint](slide-master_5.png)

Para adicionar novos placeholders com Aspose.Slides, trabalhe com o layout slide que pertence ao master:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let blankLayoutSlide = masterSlide.getLayoutSlides().getByType(blankLayoutType);

    if (blankLayoutSlide === null) {
        blankLayoutSlide = masterSlide.getLayoutSlides().add(blankLayoutType, "Blank");
    }

    blankLayoutSlide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80);

    presentation.getSlides().addEmptySlide(blankLayoutSlide);
    presentation.save("presentation-with-placeholder.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Você também pode formatar shapes de placeholder que já existem em um slide master. O exemplo a seguir encontra o placeholder de título e aplica um preenchimento gradiente linear:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let titlePlaceholder = null;
    let masterShapes = masterSlide.getShapes();
    let masterShapeCount = masterShapes.size();

    for (let masterShapeIndex = 0; masterShapeIndex < masterShapeCount; masterShapeIndex++) {
        let shape = masterShapes.get_Item(masterShapeIndex);

        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            let placeholder = shape.getPlaceholder();

            if (placeholder !== null && placeholder.getType() === aspose.slides.PlaceholderType.Title) {
                titlePlaceholder = shape;
                break;
            }
        }
    }

    if (titlePlaceholder !== null) {
        let gradientFillType = java.newByte(aspose.slides.FillType.Gradient);
        let linearGradientShape = java.newByte(aspose.slides.GradientShape.Linear);
        let redGradientColor = java.newInstanceSync("java.awt.Color", 255, 0, 0);
        let purpleGradientColor = java.newInstanceSync("java.awt.Color", 128, 0, 128);

        titlePlaceholder.getFillFormat().setFillType(gradientFillType);
        titlePlaceholder.getFillFormat().getGradientFormat().setGradientShape(linearGradientShape);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(0.0, redGradientColor);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(255.0, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Placeholder de título formatado herdado por slides normais](slide-master_8.png)

Para mais opções de placeholders e formatação de texto, veja [Set Prompt Text in Placeholder](/nodejs-java/manage-placeholder/) e [Text Formatting](/nodejs-java/text-formatting/).

## **Alterar o fundo de um Slide Master**

Um fundo de master é herdado por layouts e slides que não o sobrescrevem. O exemplo a seguir define uma cor de fundo sólida para o primeiro slide master:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let ownBackgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let masterBackgroundColor = java.getStaticFieldValue("java.awt.Color", "GREEN");

    masterSlide.getBackground().setType(ownBackgroundType);
    masterSlide.getBackground().getFillFormat().setFillType(solidFillType);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Para tópicos relacionados, veja [Presentation Background](/nodejs-java/presentation-background/) e [Presentation Theme](/nodejs-java/presentation-theme/).

## **Clonar um Slide Master para outra apresentação**

Use `MasterSlideCollection.addClone` para copiar um slide master para outra apresentação. O master copiado pode então ser usado por layouts e slides na apresentação de destino.

```javascript
let sourcePresentation = new aspose.slides.Presentation("source.pptx");
let destinationPresentation = new aspose.slides.Presentation("destination.pptx");
try {
    let sourceMasterSlide = sourcePresentation.getMasters().get_Item(0);
    let clonedMasterSlide = destinationPresentation.getMasters().addClone(sourceMasterSlide);

    destinationPresentation.save("destination-with-master.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
    destinationPresentation.dispose();
}
```

Se precisar clonar slides normais junto com seu master, veja [Clone Slides](/nodejs-java/clone-slides/).

## **Adicionar múltiplos Slide Masters**

Uma apresentação pode conter vários slide masters. Isso é útil quando diferentes seções exigem branding, estrutura de página ou configurações de tema diferentes.

![Comandos do PowerPoint para inserir e gerenciar slide masters](slide-master_9.jpg)

O exemplo a seguir clona o master padrão, dá ao clone um fundo diferente, cria um layout sob esse master clonado e adiciona um novo slide baseado nesse layout:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let defaultMasterSlide = presentation.getMasters().get_Item(0);
    let sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    let ownBackgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let sectionMasterBackgroundColor = java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY");

    sectionMasterSlide.getBackground().setType(ownBackgroundType);
    sectionMasterSlide.getBackground().getFillFormat().setFillType(solidFillType);
    sectionMasterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(sectionMasterBackgroundColor);

    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let sourceBlankLayout = defaultMasterSlide.getLayoutSlides().getByType(blankLayoutType);
    if (sourceBlankLayout === null) {
        sourceBlankLayout = defaultMasterSlide.getLayoutSlides().get_Item(0);
    }

    let sectionBlankLayout = sectionMasterSlide.getLayoutSlides().addClone(sourceBlankLayout);

    presentation.getSlides().addEmptySlide(sectionBlankLayout);
    presentation.save("presentation-with-multiple-masters.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Comparar Slide Masters**

Slide masters podem ser comparados com o método `equals` herdado de [BaseSlide](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/baseslide/). A comparação verifica a estrutura e o conteúdo estático, como shapes, texto, formatação, animações e outras configurações de slide. Não compara identificadores únicos, como IDs de slide, ou valores dinâmicos de placeholder, como a data atual.

```javascript
let firstPresentation = new aspose.slides.Presentation("first.pptx");
let secondPresentation = new aspose.slides.Presentation("second.pptx");
try {
    let firstPresentationMasterCount = firstPresentation.getMasters().size();
    let secondPresentationMasterCount = secondPresentation.getMasters().size();

    for (let firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++) {
        for (let secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++) {
            let firstMasterSlide = firstPresentation.getMasters().get_Item(firstMasterIndex);
            let secondMasterSlide = secondPresentation.getMasters().get_Item(secondMasterIndex);
            let areMasterSlidesEqual = firstMasterSlide.equals(secondMasterSlide);

            if (areMasterSlidesEqual) {
                console.log(
                    "first.pptx master #" + firstMasterIndex +
                    " equals second.pptx master #" + secondMasterIndex);
            }
        }
    }
} finally {
    firstPresentation.dispose();
    secondPresentation.dispose();
}
```

Para mais informações, veja [Compare Presentation Slides](/nodejs-java/compare-slides/).

## **Definir a visualização Slide Master como visualização padrão**

Use o método `setLastView` em [ViewProperties](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/viewproperties/) para controlar a visualização que o PowerPoint abre primeiro. O exemplo a seguir abre a apresentação na visualização Slide Master:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideMasterViewType = java.newByte(aspose.slides.ViewType.SlideMasterView);

    presentation.getViewProperties().setLastView(slideMasterViewType);
    presentation.save("presentation-master-view.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Para mais configurações de visualização, veja [Save Presentation](/nodejs-java/save-presentation/).

## **Remover Slide Masters não utilizados**

Apresentações às vezes contêm slide masters que já não são usados por nenhum slide normal. Remover masters não utilizados pode reduzir o tamanho do arquivo e simplificar a manutenção de modelos.

Use `removeUnused` para remover masters não utilizados da coleção `getMasters()`:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Você também pode usar o método de baixo código `Compress.removeUnusedMasterSlides`:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    aspose.slides.Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Qual é a diferença entre um slide master e um layout slide?**

Um slide master define configurações de design compartilhadas, como tema, fundo, formas comuns e estilos de texto. Um layout slide pertence a um slide master e define um arranjo específico de placeholders. Um slide normal usa um layout slide, herdando tanto do layout quanto do master.

**Uma apresentação pode conter vários slide masters?**

Sim. Uma apresentação pode conter vários slide masters. Use múltiplos masters quando diferentes seções precisam de sistemas visuais ou branding diferentes.

**Devo adicionar placeholders a um slide master ou a um layout slide?**

Na maioria dos casos, adicione placeholders a layout slides. Coloque elementos visuais compartilhados e formatação comum no slide master e, em seguida, coloque placeholders de conteúdo nos layouts que os slides normais usarão.

**Posso excluir um slide master que ainda está em uso?**

Não. Um slide master que tem slides dependentes não pode ser removido com segurança diretamente. Primeiro mova esses slides para layouts sob outro master, ou use um método de limpeza que remova apenas masters que não estejam em uso.