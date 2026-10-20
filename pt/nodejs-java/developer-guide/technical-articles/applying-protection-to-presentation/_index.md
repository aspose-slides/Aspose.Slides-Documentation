---
title: Restringir Edições de Apresentação com Bloqueios de Forma no Node.js
linktitle: Restringir Edições de Apresentação
type: docs
weight: 60
url: /pt/nodejs-java/applying-protection-to-presentation/
keywords:
- impedir edições
- proteger contra edição
- bloquear forma
- bloquear posição
- bloquear seleção
- bloquear redimensionamento
- bloquear agrupamento
- PowerPoint
- PPTX
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda como bloquear e desbloquear formas em apresentações PPTX com Aspose.Slides para Node.js via Java para restringir seleção, movimentação, redimensionamento e agrupamento."
---
## **Visão Geral**

Um uso comum do Aspose.Slides for Node.js via Java é criar, atualizar e salvar apresentações PowerPoint (PPTX) como parte de um fluxo de trabalho automatizado. Quando os usuários recebem essas apresentações, restringir alterações nas formas pode ajudar a preservar o layout e o conteúdo pretendidos.

Este artigo explica como as formas são organizadas nos slides e como aplicar e remover bloqueios de forma em uma apresentação PPTX. Esses bloqueios permitem restringir operações específicas de edição em formas individuais.

## **Composição de um Slide**

Um slide de apresentação é composto por componentes como autoshapes, tabelas, objetos OLE, formas agrupadas, molduras de imagem, molduras de vídeo, conectores e outros elementos usados para criar uma apresentação. No Aspose.Slides for Node.js via Java, cada elemento em um slide é representado por um objeto que herda da classe [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) .

Tipos diferentes de forma expõem opções de bloqueio diferentes. A classe [BaseShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseshapelock/) é a classe base para bloqueios de forma. O Aspose.Slides for Node.js via Java fornece as seguintes classes de bloqueio:

- [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/) bloqueia autoshapes.  
- [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) bloqueia formas de conector.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/) bloqueia objetos gráficos.  
- [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/) bloqueia formas agrupadas.  
- [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/) bloqueia molduras de imagem.  

Para aplicar bloqueios em uma [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/), percorra seus slides e defina os bloqueios apropriados em cada forma suportada.

## **Aplicar e Remover Proteção**

Bloqueios de forma restringem operações como selecionar, mover e redimensionar formas. Eles não tornam toda a apresentação não editável.

### **Aplicar Proteção a Formas PPTX**

O Aspose.Slides for Node.js via Java fornece a classe [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) para trabalhar com formas em um slide.

O exemplo chama [setSelectLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setPositionLocked) e [setSizeLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSizeLocked) com `true` para autoshapes, com bloqueios equivalentes para formas agrupadas, conectores e molduras de imagem. Conectores usam [setPositionMove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/#setPositionMove) para movimentação; grupos também usam [setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) para restringir o agrupamento.

O exemplo carrega uma apresentação PPTX existente, verifica as formas na coleção de formas de cada slide e salva uma cópia com essas restrições aplicadas. Formas fora dos quatro tipos tratados permanecem inalteradas. O loop não percorre as formas filhas dentro de um grupo.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                const autoShapeLock = shape.getShapeLock();
                autoShapeLock.setPositionLocked(true);
                autoShapeLock.setSelectLocked(true);
                autoShapeLock.setSizeLocked(true);
            } else if (java.instanceOf(shape, "com.aspose.slides.IGroupShape")) {
                const groupShapeLock = shape.getShapeLock();
                groupShapeLock.setGroupingLocked(true);
                groupShapeLock.setPositionLocked(true);
                groupShapeLock.setSelectLocked(true);
                groupShapeLock.setSizeLocked(true);
            } else if (java.instanceOf(shape, "com.aspose.slides.IConnector")) {
                const connectorShapeLock = shape.getShapeLock();
                connectorShapeLock.setPositionMove(true);
                connectorShapeLock.setSelectLocked(true);
                connectorShapeLock.setSizeLocked(true);
            } else if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                const pictureFrameLock = shape.getShapeLock();
                pictureFrameLock.setPositionLocked(true);
                pictureFrameLock.setSelectLocked(true);
                pictureFrameLock.setSizeLocked(true);
            }
        }
    }

    presentation.save("ProtectedSample.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Remover Proteção**

Para remover um bloqueio de forma, defina seu valor como `false`. O exemplo a seguir carrega uma apresentação com bloqueios de forma e limpa as restrições de seleção, movimentação e redimensionamento através de [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) e [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/). Ele também remove a restrição de agrupamento passando `false` para [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) e salva uma cópia da apresentação. Outras configurações de bloqueio permanecem inalteradas.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("ProtectedSample.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                const autoShapeLock = shape.getShapeLock();
                autoShapeLock.setPositionLocked(false);
                autoShapeLock.setSelectLocked(false);
                autoShapeLock.setSizeLocked(false);
            } else if (java.instanceOf(shape, "com.aspose.slides.IGroupShape")) {
                const groupShapeLock = shape.getShapeLock();
                groupShapeLock.setGroupingLocked(false);
                groupShapeLock.setPositionLocked(false);
                groupShapeLock.setSelectLocked(false);
                groupShapeLock.setSizeLocked(false);
            } else if (java.instanceOf(shape, "com.aspose.slides.IConnector")) {
                const connectorShapeLock = shape.getShapeLock();
                connectorShapeLock.setPositionMove(false);
                connectorShapeLock.setSelectLocked(false);
                connectorShapeLock.setSizeLocked(false);
            } else if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                const pictureFrameLock = shape.getShapeLock();
                pictureFrameLock.setPositionLocked(false);
                pictureFrameLock.setSelectLocked(false);
                pictureFrameLock.setSizeLocked(false);
            }
        }
    }

    presentation.save("RemovedProtectionSample.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Conclusão**

O Aspose.Slides for Node.js via Java permite restringir operações específicas de edição em formas individuais ou aplicar as mesmas restrições em vários slides. Escolha os bloqueios suportados por cada tipo de forma e defina seus valores como `false` quando precisar remover essas restrições.

## **Perguntas Frequentes**

**Posso combinar bloqueios de forma e proteção por senha na mesma apresentação?**

Sim. Bloqueios de forma restringem operações específicas de edição, enquanto [proteção por senha](/slides/pt/nodejs-java/password-protected-presentation/) pode restringir a abertura ou modificação da apresentação. Você pode usar ambos no mesmo arquivo.

**Posso restringir a edição em slides específicos sem afetar os demais?**

Sim. Aplique bloqueios apenas às formas nos slides selecionados. Isso não altera as configurações de bloqueio nos outros slides.

**Como posso aplicar bloqueios a formas individuais dentro de um grupo?**

Percorra a coleção retornada pelo método [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/#getShapes) do grupo e aplique os bloqueios apropriados a cada forma filha. Repita isso para quaisquer grupos aninhados. Os exemplos acima processam apenas a coleção de formas do slide, portanto não definem bloqueios nos membros individuais do grupo.