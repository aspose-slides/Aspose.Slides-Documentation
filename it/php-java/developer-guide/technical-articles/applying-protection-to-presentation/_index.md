---
title: Limita le modifiche alla presentazione con i blocchi delle forme in PHP
linktitle: Limita le modifiche alla presentazione
type: docs
weight: 60
url: /it/php-java/applying-protection-to-presentation/
keywords:
- impedire modifiche
- proteggere dalla modifica
- bloccare forma
- bloccare posizione
- bloccare selezione
- bloccare ridimensionamento
- bloccare raggruppamento
- PowerPoint
- PPTX
- presentazione
- PHP
- Aspose.Slides
description: "Scopri come bloccare e sbloccare le forme nelle presentazioni PPTX con Aspose.Slides per PHP via Java per limitare la selezione, lo spostamento, il ridimensionamento e il raggruppamento."
---
## **Panoramica**

Un uso comune di Aspose.Slides per PHP via Java è creare, aggiornare e salvare presentazioni PowerPoint (PPTX) come parte di un flusso di lavoro automatizzato. Quando gli utenti ricevono queste presentazioni, limitare le modifiche alle forme può aiutare a preservare il layout e il contenuto previsto.

Questo articolo spiega come le forme sono organizzate nelle diapositive e come applicare e rimuovere i blocchi delle forme in una presentazione PPTX. Questi blocchi consentono di limitare operazioni di modifica specifiche su singole forme.

## **Composizione di una diapositiva**

Una diapositiva di una presentazione è composta da componenti come autoshape, tabelle, oggetti OLE, forme raggruppate, cornici immagine, cornici video, connettori e altri elementi utilizzati per costruire una presentazione. In Aspose.Slides per PHP via Java, ogni elemento su una diapositiva è rappresentato da un oggetto che eredita dalla classe [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) .

Tipi diversi di forme espongono opzioni di blocco diverse. La classe [BaseShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/) è la classe base per i blocchi delle forme. Aspose.Slides per PHP via Java fornisce le seguenti classi di blocco:

- [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/) blocca gli autoshape.  
- [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) blocca i connettori.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) blocca gli oggetti grafici.  
- [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/) blocca le forme di gruppo.  
- [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) blocca le cornici immagine.  

Per applicare i blocchi su una [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), iterare attraverso le sue diapositive e impostare i blocchi appropriati su ciascuna forma supportata.

## **Applicare e rimuovere la protezione**

I blocchi delle forme limitano operazioni come selezionare, spostare e ridimensionare le forme. Non rendono l'intera presentazione non modificabile.

### **Applicare la protezione alle forme PPTX**

Aspose.Slides per PHP via Java fornisce la classe [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) per lavorare con le forme su una diapositiva.

L'esempio chiama [setSelectLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setPositionLocked) e [setSizeLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSizeLocked) con `true` per gli autoshape, con blocchi equivalenti per le forme di gruppo, i connettori e le cornici immagine. I connettori usano [setPositionMove](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/#setPositionMove) per lo spostamento; i gruppi usano anche [setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) per limitare il raggruppamento.

L'esempio carica una presentazione PPTX esistente, controlla le forme nella collezione di forme di ogni diapositiva e salva una copia con queste restrizioni applicate. Le forme al di fuori dei quattro tipi gestiti rimangono inalterate. Il ciclo non attraversa le forme figlio all'interno di un gruppo.

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

Per rimuovere un blocco di forma, impostare il suo valore su `false`. L'esempio seguente carica una presentazione con blocchi di forma e elimina le restrizioni di selezione, spostamento e ridimensionamento tramite [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) e [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/). Rimuove inoltre la restrizione di raggruppamento passando `false` a [GroupShapeLock::setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) e salva una copia della presentazione. Le altre impostazioni di blocco rimangono inalterate.

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

### **Conclusione**

Aspose.Slides per PHP via Java ti consente di limitare operazioni di modifica specifiche su singole forme o di applicare le stesse restrizioni su più diapositive. Scegli i blocchi supportati da ciascun tipo di forma e imposta i loro valori su `false` quando è necessario rimuovere tali restrizioni.

## **FAQ**

**Posso combinare i blocchi delle forme e la protezione con password nella stessa presentazione?**

Sì. I blocchi delle forme limitano operazioni di modifica specifiche, mentre [protezione con password](/slides/it/php-java/password-protected-presentation/) può limitare l'apertura o la modifica della presentazione. È possibile utilizzare entrambi nello stesso file.

**Posso limitare la modifica su diapositive specifiche senza influire su altre?**

Sì. Applica i blocchi solo alle forme delle diapositive selezionate. Questo non cambia le impostazioni di blocco delle altre diapositive.

**Come posso applicare blocchi a forme singole all'interno di un gruppo?**

Itera attraverso la collezione restituita dal metodo [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) del gruppo e applica i blocchi appropriati a ogni forma figlia. Ripeti l'operazione per eventuali gruppi annidati. Gli esempi sopra elaborano solo la collezione di forme della diapositiva, quindi non impostano blocchi sui singoli membri del gruppo.