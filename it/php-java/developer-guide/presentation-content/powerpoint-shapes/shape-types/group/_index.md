---
title: Forme di presentazione di gruppo in PHP
linktitle: Gruppo di forme
type: docs
weight: 40
url: /it/php-java/group/
keywords:
- forma di gruppo
- gruppo di forme
- aggiungi gruppo
- testo alternativo
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Impara a raggruppare e separare le forme nei deck PowerPoint usando Aspose.Slides per PHP via Java — guida rapida, passo passo, con codice gratuito."
---
## **Panoramica**

Questo articolo spiega come lavorare con le forme di gruppo in Aspose.Slides. Mostra come aggiungere una forma di gruppo a una diapositiva, inserire forme al suo interno e salvare la presentazione aggiornata. Dimostra inoltre come accedere alle forme contenute in un gruppo e leggere i valori della loro proprietà `AlternativeText`. Inoltre, l’articolo tratta brevemente le funzionalità correlate alle forme di gruppo, come i gruppi nidificati, l’ordine Z e le opzioni di blocco.

## **Aggiungere una Forma di Gruppo**
Aspose.Slides supporta la gestione delle forme di gruppo nelle diapositive. Questa funzionalità consente agli sviluppatori di creare presentazioni più ricche. Aspose.Slides per PHP via Java supporta l’aggiunta o l’accesso alle forme di gruppo. È possibile aggiungere forme a una forma di gruppo creata per popolarla o accedere a qualsiasi proprietà della forma di gruppo. Per aggiungere una forma di gruppo a una diapositiva usando Aspose.Slides per PHP via Java:

1. Creare un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation).
1. Ottenere il riferimento a una diapositiva utilizzando il suo indice.
1. Aggiungere una forma di gruppo alla diapositiva.
1. Aggiungere le forme alla forma di gruppo aggiunta.
1. Salvare la presentazione modificata come file PPTX.

L’esempio seguente aggiunge una forma di gruppo a una diapositiva.

```php
  # Istanzia la classe Presentation
  $pres = new Presentation();
  try {
    # Ottieni la prima diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Accesso alla collezione di forme delle diapositive
    $slideShapes = $sld->getShapes();
    # Aggiunta di una forma di gruppo alla diapositiva
    $groupShape = $slideShapes->addGroupShape();
    # Aggiunta di forme all'interno della forma di gruppo aggiunta
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 100, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 300, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 300, 100, 100);
    # Aggiunta del frame della forma di gruppo
    $groupShape->setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool::False, NullableBool::False, 0));
    # Scrivi il file PPTX su disco
    $pres->save("GroupShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Accedere alla Proprietà AltText**
Questo argomento mostra passaggi semplici, completi di esempi di codice, per aggiungere una forma di gruppo e accedere alla proprietà AltText delle forme di gruppo nelle diapositive. Per accedere a AltText di una forma di gruppo in una diapositiva usando Aspose.Slides per PHP via Java:

1. Istanziare la classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation) che rappresenta il file PPTX.
1. Ottenere il riferimento a una diapositiva utilizzando il suo indice.
1. Accedere alla collection di forme della diapositiva.
1. Accedere alla forma di gruppo.
1. Accedere alla proprietà [Alternative Text](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/#getAlternativeText).

L’esempio seguente accede al testo alternativo della forma di gruppo.

```php
  # Istanzia la classe Presentation che rappresenta il file PPTX
  $pres = new Presentation("AltText.pptx");
  try {
    # Ottieni la prima diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    for($i = 0; $i < java_values($sld->getShapes()->size()) ; $i++) {
      # Accesso alla collezione di forme delle diapositive
      $shape = $sld->getShapes()->get_Item($i);
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
        # Accesso alla forma di gruppo.
        $grphShape = $shape;
        for($j = 0; $j < java_values($grphShape->getShapes()->size()) ; $j++) {
          $shape2 = $grphShape->getShapes()->get_Item($j);
          # Accesso alla proprietà AltText
          echo($shape2->getAlternativeText());
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Il raggruppamento nidificato (un gruppo all’interno di un altro gruppo) è supportato?**

Sì. [GroupShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/groupshape/) dispone del metodo [getParentGroup](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/getparentgroup/), che indica direttamente il supporto alla gerarchia (un gruppo può essere figlio di un altro gruppo).

**Come controllo l’ordine Z del gruppo rispetto ad altri oggetti nella diapositiva?**

Utilizzare il metodo [getZOrderPosition](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/getzorderposition/) di [GroupShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/groupshape/) per verificare la sua posizione nello stack di visualizzazione.

**Posso impedire lo spostamento/modifica/scomposizione?**

Sì. La sezione di blocco del gruppo è esposta tramite [GroupShapeLock](https://reference.aspose.com/slides/it/php-java/aspose.slides/groupshape/getgroupshapelock/), che consente di limitare le operazioni sull’oggetto.