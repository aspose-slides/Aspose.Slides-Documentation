---
title: Limita le modifiche alla presentazione con i blocchi di forma in PHP
linktitle: Limita le modifiche alla presentazione
type: docs
weight: 60
url: /it/php-java/applying-protection-to-presentation/
keywords:
- impedire modifiche
- proteggere dalla modifica
- blocca forma
- blocca posizione
- blocca selezione
- blocca ridimensionamento
- blocca raggruppamento
- PowerPoint
- PPTX
- presentazione
- PHP
- Aspose.Slides
description: "Scopri come bloccare e sbloccare le forme nelle presentazioni PPTX con Aspose.Slides per PHP tramite Java per limitare selezione, spostamento, ridimensionamento e raggruppamento."
---
## **Panoramica**

Un uso comune di Aspose.Slides per PHP tramite Java è creare, aggiornare e salvare presentazioni PowerPoint (PPTX) all'interno di un flusso di lavoro automatizzato. Quando gli utenti ricevono queste presentazioni, limitare le modifiche alle forme può aiutare a preservare il layout e il contenuto previsti.

Questo articolo spiega come le forme sono organizzate nelle diapositive e come applicare e rimuovere i blocchi delle forme in una presentazione PPTX. Questi blocchi consentono di limitare operazioni di modifica specifiche su singole forme.

## **Composizione di una diapositiva**

Una diapositiva di una presentazione è composta da componenti come autoshapes, tabelle, oggetti OLE, forme raggruppate, cornici immagine, cornici video, connettori e altri elementi utilizzati per costruire una presentazione. In Aspose.Slides per PHP tramite Java, ogni elemento su una diapositiva è rappresentato da un oggetto che eredita dalla classe [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) .

I diversi tipi di forma espongono diverse opzioni di blocco. La classe [BaseShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/) è la classe base per i blocchi delle forme. Aspose.Slides per PHP tramite Java fornisce le seguenti classi di blocco:

- [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/) blocca gli autoshapes.  
- [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) blocca le forme connettore.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) blocca gli oggetti grafici.  
- [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/) blocca le forme raggruppate.  
- [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) blocca le cornici immagine.  

Per applicare i blocchi a una [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), iterare attraverso le sue diapositive e impostare i blocchi appropriati su ciascuna forma supportata.

## **Applicare e rimuovere la protezione**

Gli editor di presentazioni compatibili utilizzano i blocchi delle forme per limitare operazioni di modifica individuali. La crittografia dei file e la protezione in scrittura a livello di documento sono impostazioni di [impostazioni di protezione della presentazione](/slides/it/php-java/password-protected-presentation/) separate.

### **Applicare la protezione alle forme PPTX**

Aspose.Slides per PHP tramite Java fornisce la classe [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) per lavorare con le forme su una diapositiva.

L'esempio chiama [setSelectLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setPositionLocked) e [setSizeLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSizeLocked) con `true` per gli autoshapes, con blocchi equivalenti per le forme gruppo, i connettori e le cornici immagine. I connettori usano [setPositionMove](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/#setPositionMove) per lo spostamento; i gruppi usano anche [setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) per limitare il raggruppamento.

L'esempio carica una presentazione PPTX esistente, controlla le forme nella raccolta di forme di ogni diapositiva e salva una copia con queste restrizioni applicate. Le forme al di fuori dei quattro tipi gestiti rimangono invariate. Il ciclo non attraversa le forme figlie all'interno di un gruppo.

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

### **Rimuovere la protezione**

Per rimuovere un blocco di forma, impostare il suo valore su `false`. Il seguente esempio carica una presentazione con blocchi di forma e cancella le restrizioni di selezione, spostamento e ridimensionamento tramite [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) e [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/). Rimuove inoltre la restrizione di raggruppamento passando `false` a [GroupShapeLock::setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) e salva una copia della presentazione. Le altre impostazioni di blocco rimangono invariate.

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

### **Mantenere il ritaglio di un'immagine**

Posizionare una foto denominata `photo.jpg` nella directory di lavoro. L'esempio ritaglia il 12% a sinistra e l'8% a destra, quindi chiama [setCropLocked](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/#setCropLocked) sul blocco della cornice immagine. Passare `true` limita ulteriori ritagli e preserva il ritaglio esistente.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    $image = Images::fromFile("photo.jpg");
    try {
        $photo = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $pictureFrame = $shapes->addPictureFrame(ShapeType::Rectangle, 20, 30, 270, 160, $photo);
    $pictureFrame->getPictureFormat()->setCropLeft(12);
    $pictureFrame->getPictureFormat()->setCropRight(8);

    $pictureFrameLock = $pictureFrame->getPictureFrameLock();
    $pictureFrameLock->setAspectRatioLocked(false);
    $pictureFrameLock->setCropLocked(true);

    $presentation->save("PictureLocked.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`PictureLocked.pptx` memorizza il blocco del ritaglio come `true`. In PowerPoint, il comando **Crop** è disabilitato quando la foto è selezionata.

### **Mantenere un diagramma raggruppato**

L'esempio raggruppa un rettangolo e una freccia, quindi chiama [setUngroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setUngroupingLocked) sul blocco del gruppo per mantenere insieme i componenti del diagramma. Altre modifiche, come lo spostamento del gruppo o la modifica del riempimento di un componente, rimangono disponibili.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();
    
    $groupShape = $shapes->addGroupShape();
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 70, 90, 50);
    $groupShape->getShapes()->addAutoShape(ShapeType::RightArrow, 190, 80, 60, 30);
    $groupShape->getGroupShapeLock()->setUngroupingLocked(true);

    $presentation->save("DiagramLocked.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`DiagramLocked.pptx` memorizza il blocco di annullamento raggruppamento come `true`. In PowerPoint, il comando **Ungroup** è disabilitato quando l'intero diagramma è selezionato.

### **Segnalare i blocchi di forma esistenti**

Per revisionare un modello, aprirlo e leggere l'oggetto di blocco per ogni forma. Il metodo [getNoLocks](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/#getNoLocks) restituisce `true` quando tutte le flag su quell'oggetto sono disabilitate e `false` quando almeno una è abilitata. Un gruppo e i suoi figli hanno oggetti di blocco separati, quindi ispezionare i figli anche quando il gruppo non ha blocchi.

Questo esempio verifica lo spostamento per gli autoshapes, le cornici immagine e i gruppi. Controlla anche il ritaglio per le immagini e l'annullamento raggruppamento per i gruppi. Il report elenca le flag abilitate che riconosce e contrassegna i tipi di forma che non ispeziona.

```php
use aspose\slides\Presentation;

function reportShapeLocks($shapes, $slideNumber, $prefix = "") {
    foreach ($shapes->toArray() as $shape) {
        $path = $prefix . java_values($shape->getName());
        $type = java_values($shape->getClass()->getSimpleName());
        $label = "Slide $slideNumber | $path | $type";
        $flags = [];
        $isGroup = java_instanceof($shape, java("com.aspose.slides.IGroupShape"));

        if ($isGroup) {
            $lock = $shape->getGroupShapeLock();
            if (java_values($lock->getUngroupingLocked())) {
                $flags[] = "UngroupingLocked";
            }
        } elseif (java_instanceof($shape, java("com.aspose.slides.IPictureFrame"))) {
            $lock = $shape->getPictureFrameLock();
            if (java_values($lock->getCropLocked())) {
                $flags[] = "CropLocked";
            }
        } elseif (java_instanceof($shape, java("com.aspose.slides.IAutoShape"))) {
            $lock = $shape->getAutoShapeLock();
        } else {
            echo "$label | Uninspected", PHP_EOL;
            continue;
        }

        if (java_values($lock->getPositionLocked())) {
            $flags[] = "PositionLocked";
        }
        if (!java_values($lock->getNoLocks())) {
            $restrictions = $flags ? implode(", ", $flags) : "Active flag not identified";
            echo "$label | $restrictions", PHP_EOL;
        }

        if ($isGroup) {
            reportShapeLocks($shape->getShapes(), $slideNumber, $path . "/");
        }
    }
}

$presentation = new Presentation("Sample.pptx");
try {
    foreach ($presentation->getSlides()->toArray() as $slide) {
        reportShapeLocks($slide->getShapes(), java_values($slide->getSlideNumber()));
    }
} finally {
    $presentation->dispose();
}
```

Supponiamo che la diapositiva 1 di `Sample.pptx` contenga un gruppo denominato `Layout` con l'annullamento raggruppamento bloccato, un'immagine denominata `Photo` al suo interno con il ritaglio bloccato, e un rettangolo sbloccato denominato `Free`. Il report ignora `Free` e stampa queste due righe:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

Il report legge le flag di modifica a livello di forma memorizzate senza modificarle o salvare la presentazione. La protezione in scrittura a livello di documento è un'impostazione separata, e l'applicazione di ogni flag dipende dall'editor.

### **Conclusione**

Aspose.Slides per PHP tramite Java consente di limitare operazioni di modifica specifiche su forme individuali o di applicare le stesse restrizioni su più diapositive. Scegli i blocchi supportati da ciascun tipo di forma e imposta i loro valori su `false` quando è necessario rimuovere tali restrizioni.

## **FAQ**

**Posso combinare i blocchi di forma e la protezione con password nella stessa presentazione?**

Sì. I blocchi di forma limitano operazioni di modifica specifiche, mentre la [protezione con password](/slides/it/php-java/password-protected-presentation/) può limitare l'apertura o la modifica della presentazione. È possibile utilizzare entrambi nello stesso file.

**Posso limitare la modifica su diapositive specifiche senza influenzare le altre?**

Sì. Applicare i blocchi solo alle forme delle diapositive selezionate. Questo non cambia le impostazioni di blocco sulle altre diapositive.

**Come posso applicare blocchi a forme individuali all'interno di un gruppo?**

Iterare attraverso la collezione restituita dal metodo [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) del gruppo e applicare i blocchi appropriati a ciascuna forma figlia. Ripetere l'operazione per eventuali gruppi annidati, seguendo il percorso nell'esempio di report.