---
title: Restringir edições de apresentações com bloqueios de forma em PHP
linktitle: Restringir edições de apresentações
type: docs
weight: 60
url: /pt/php-java/applying-protection-to-presentation/
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
- PHP
- Aspose.Slides
description: "Saiba como bloquear e desbloquear formas em apresentações PPTX com Aspose.Slides for PHP via Java para restringir seleção, movimento, redimensionamento e agrupamento."
---
## **Visão geral**

Um uso comum do Aspose.Slides for PHP via Java é criar, atualizar e salvar apresentações PowerPoint (PPTX) como parte de um fluxo de trabalho automatizado. Quando os usuários recebem essas apresentações, restringir alterações nas formas pode ajudar a preservar o layout e o conteúdo pretendidos.

Este artigo explica como as formas são organizadas nos slides e como aplicar e remover bloqueios de forma em uma apresentação PPTX. Esses bloqueios permitem restringir operações de edição específicas em formas individuais.

## **Composição de um slide**

Um slide de apresentação é composto por componentes como autoshapes, tabelas, objetos OLE, formas agrupadas, picture frames, video frames, connectors e outros elementos usados para criar uma apresentação. No Aspose.Slides for PHP via Java, cada elemento em um slide é representado por um objeto que herda da classe [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) .

Tipos diferentes de forma expõem opções de bloqueio diferentes. A classe [BaseShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/) é a classe base para bloqueios de forma. Aspose.Slides for PHP via Java fornece as seguintes classes de bloqueio:

- [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/) bloqueia autoshapes.  
- [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) bloqueia connector shapes.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) bloqueia graphical objects.  
- [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/) bloqueia group shapes.  
- [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) bloqueia picture frames.  

Para aplicar bloqueios em toda a [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), itere pelos seus slides e defina os bloqueios apropriados em cada forma suportada.

## **Aplicar e remover proteção**

Os bloqueios de forma restringem operações como selecionar, mover e redimensionar formas. Eles não tornam toda a apresentação não editável.

### **Aplicar proteção a formas PPTX**

Aspose.Slides for PHP via Java fornece a classe [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) para trabalhar com formas em um slide.

O exemplo chama [setSelectLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setPositionLocked) e [setSizeLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSizeLocked) com `true` para autoshapes, com bloqueios equivalentes para group shapes, connectors e picture frames. Connectors usam [setPositionMove](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/#setPositionMove) para movimento; grupos também usam [setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) para restringir a agregação.

O exemplo carrega uma apresentação PPTX existente, verifica as formas na coleção de formas de cada slide e salva uma cópia com essas restrições aplicadas. Formas fora dos quatro tipos manipulados permanecem inalteradas. O loop não percorre as formas filhas dentro de um grupo.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    foreach ($presentation->getSlides()->toArray() as $slide) {
        foreach ($slide->getShapes()->toArray() as $shape) {
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setGroupingLocked(true);
                $shapeLock->setPositionLocked(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.Connector"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionMove(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            }
        }
    }

    $presentation->save("ProtectedSample.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Remover proteção**

Para remover um bloqueio de forma, defina seu valor como `false`. O exemplo a seguir carrega uma apresentação com bloqueios de forma e limpa as restrições de seleção, movimento e redimensionamento por meio de [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) e [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/). Ele também remove a restrição de agrupamento ao passar `false` para [GroupShapeLock::setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) e salva uma cópia da apresentação. Outras configurações de bloqueio permanecem inalteradas.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("ProtectedSample.pptx");
try {
    foreach ($presentation->getSlides()->toArray() as $slide) {
        foreach ($slide->getShapes()->toArray() as $shape) {
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setGroupingLocked(false);
                $shapeLock->setPositionLocked(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.Connector"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionMove(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            }
        }
    }

    $presentation->save("RemovedProtectionSample.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Conclusão**

Aspose.Slides for PHP via Java permite restringir operações de edição específicas em formas individuais ou aplicar as mesmas restrições em vários slides. Escolha os bloqueios suportados por cada tipo de forma e defina seus valores como `false` quando precisar remover essas restrições.

## **FAQ**

**Posso combinar bloqueios de forma e proteção por senha na mesma apresentação?**

Sim. Os bloqueios de forma restringem operações de edição específicas, enquanto [proteção por senha](/slides/pt/php-java/password-protected-presentation/) pode restringir a abertura ou a modificação da apresentação. Você pode usar ambos no mesmo arquivo.

**Posso restringir a edição em slides específicos sem afetar os demais?**

Sim. Aplique bloqueios apenas às formas nos slides selecionados. Isso não altera as configurações de bloqueio nos outros slides.

**Como posso aplicar bloqueios a formas individuais dentro de um grupo?**

Itere pela coleção retornada pelo método [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) do grupo e aplique os bloqueios adequados a cada forma filha. Repita isso para quaisquer grupos aninhados. Os exemplos acima processam apenas a coleção de formas do slide, portanto não definem bloqueios em membros individuais do grupo.