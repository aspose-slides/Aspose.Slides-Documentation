---
title: Migliora le tue presentazioni con AutoFit in PHP
linktitle: Impostazioni Autofit
type: docs
weight: 30
url: /it/php-java/manage-autofit-settings/
keywords:
- casella di testo
- adattamento automatico
- non adattare automaticamente
- adattare il testo
- ridurre il testo
- testo a capo
- ridimensionare forma
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Gestisci le impostazioni AutoFit in Aspose.Slides per PHP per ottimizzare la visualizzazione del testo nelle tue presentazioni PowerPoint e OpenDocument e migliorare la leggibilità dei contenuti."
---
## **Introduzione**

Per impostazione predefinita, quando aggiungi una casella di testo, Microsoft PowerPoint utilizza l'impostazione **Ridimensiona forma per fissare il testo** per la casella di testo—ridimensiona automaticamente la casella di testo per garantire che il suo testo vi si adatti sempre. 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Quando il testo nella casella di testo diventa più lungo o più grande, PowerPoint ingrandisce automaticamente la casella di testo (aumenta la sua altezza) per consentirgli di contenere più testo. 
* Quando il testo nella casella di testo diventa più corto o più piccolo, PowerPoint riduce automaticamente la casella di testo (diminuisce la sua altezza) per eliminare lo spazio ridondante. 

In PowerPoint, questi sono i 4 parametri o opzioni importanti che controllano il comportamento di adattamento automatico per una casella di testo: 

* **Non adattare automaticamente**
* **Riduci il testo in caso di overflow**
* **Ridimensiona forma per adattare il testo**
* **Testo a capo nella forma.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for PHP via Java fornisce opzioni simili—alcune proprietà della classe [TextFrameFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/TextFrameFormat) —che consentono di controllare il comportamento di adattamento automatico per le caselle di testo nelle presentazioni.

## **Ridimensiona una forma per adattare il testo**

Se desideri che il testo in una casella si adatti sempre a quella casella dopo le modifiche al testo, devi utilizzare l'opzione **Ridimensiona forma per fissare il testo**. Per specificare questa impostazione, imposta la proprietà [AutofitType](https://reference.aspose.com/slides/it/php-java/aspose.slides/TextFrameFormat#getAutofitType--) (dalla classe [TextFrameFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/TextFrameFormat)) su `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Questo codice PHP mostra come specificare che un testo deve sempre adattarsi alla sua casella in una presentazione PowerPoint:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setAutofitType(TextAutofitType::Shape);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Se il testo diventa più lungo o più grande, la casella di testo verrà automaticamente ridimensionata (aumento dell'altezza) per garantire che tutto il testo vi si adatti. Se il testo diventa più corto, accade l'opposto. 

## **Non adattare automaticamente**

Se desideri che una casella di testo o una forma mantenga le sue dimensioni indipendentemente dalle modifiche al testo contenuto, devi utilizzare l'opzione **Non adattare automaticamente**. Per specificare questa impostazione, imposta la proprietà [AutofitType](https://reference.aspose.com/slides/it/php-java/aspose.slides/TextFrameFormat#getAutofitType--) (dalla classe [TextFrameFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/TextFrameFormat)) su `None`.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Questo codice PHP mostra come specificare che una casella di testo deve sempre mantenere le sue dimensioni in una presentazione PowerPoint:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setAutofitType(TextAutofitType::None);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Quando il testo diventa troppo lungo per la sua casella, trabocca. 

## **Riduci il testo in caso di overflow**

Se un testo diventa troppo lungo per la sua casella, tramite l'opzione **Riduci il testo in caso di overflow** è possibile specificare che la dimensione e l'interlinea del testo devono essere ridotte per farlo adattare alla casella. Per specificare questa impostazione, imposta la proprietà [AutofitType](https://reference.aspose.com/slides/it/php-java/aspose.slides/TextFrameFormat#getAutofitType--) (dalla classe [TextFrameFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/TextFrameFormat)) su `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Questo codice PHP mostra come specificare che un testo deve essere ridotto in caso di overflow in una presentazione PowerPoint:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setAutofitType(TextAutofitType::Normal);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Info" color="info" %}}
Quando viene utilizzata l'opzione **Riduci il testo in caso di overflow**, l'impostazione viene applicata solo quando il testo diventa troppo lungo per la casella. 
{{% /alert %}}

## **Testo a capo**

Se desideri che il testo in una forma venga avvolto all'interno di quella forma quando il testo supera il bordo della forma (solo larghezza), devi utilizzare il parametro **Testo a capo nella forma**. Per specificare questa impostazione, devi impostare la proprietà [WrapText](https://reference.aspose.com/slides/it/php-java/aspose.slides/TextFrameFormat#getWrapText--) (dalla classe [TextFrameFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/TextFrameFormat)) su `true`.

Questo codice PHP mostra come utilizzare l'impostazione Testo a capo in una presentazione PowerPoint:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setWrapText(NullableBool::True);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Note" color="warning" %}} 
Se imposti la proprietà `WrapText` su `False` per una forma, quando il testo all'interno della forma supera la larghezza della forma, il testo si estende oltre i bordi della forma su un'unica riga. 
{{% /alert %}}

## **FAQ**

**I margini interni del riquadro di testo influenzano l'AutoFit?**  
Sì. Il padding (margini interni) riduce l'area utilizzabile per il testo, quindi l'AutoFit si attiva prima—riducendo il carattere o ridimensionando la forma più rapidamente. Controlla e regola i margini prima di sintonizzare l'AutoFit.

**Come interagisce AutoFit con interruzioni di riga manuali e morbide?**  
Le interruzioni forzate rimangono al loro posto, e AutoFit adatta la dimensione del carattere e l'interlinea attorno a esse. Rimuovere le interruzioni superflue riduce spesso l'aggressività con cui AutoFit deve ridurre il testo.

**Modificare il font del tema o attivare la sostituzione del font influisce sui risultati di AutoFit?**  
Sì. Sostituire con un font con metriche dei glifi diverse modifica la larghezza/altezza del testo, il che può alterare la dimensione finale del carattere e l'avvolgimento delle righe. Dopo qualsiasi cambio o sostituzione di font, ricontrolla le diapositive.