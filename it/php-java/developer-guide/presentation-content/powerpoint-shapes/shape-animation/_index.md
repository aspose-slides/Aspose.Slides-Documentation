---
title: Applicare animazioni di forma nelle presentazioni usando PHP
linktitle: Animazione di forma
type: docs
weight: 60
url: /it/php-java/shape-animation/
keywords:
- forma
- animazione
- effetto
- forma animata
- testo animato
- aggiungere animazione
- ottenere animazione
- estrarre animazione
- aggiungere effetto
- ottenere effetto
- estrarre effetto
- suono dell'effetto
- applicare animazione
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Scopri come creare e personalizzare animazioni di forma nelle presentazioni PowerPoint con Aspose.Slides per PHP via Java. Distinguersi!"
---
## **Introduzione**

Le animazioni sono effetti visivi che possono essere applicati a testi, immagini, forme o [grafici](https://docs.aspose.com/slides/it/php-java/animated-charts/). Danno vita alle presentazioni o ai loro componenti.

## **Perché usare le animazioni nelle presentazioni?**

* controllare il flusso di informazioni
* sottolineare i punti importanti
* aumentare l'interesse o la partecipazione del pubblico
* rendere il contenuto più facile da leggere, assimilare o elaborare
* attirare l'attenzione dei lettori o spettatori verso le parti importanti di una presentazione

PowerPoint offre molte opzioni e strumenti per le animazioni e gli effetti di animazione nelle categorie **entrata**, **uscita**, **enfasi** e **percorsi di movimento**.

## **Animazioni in Aspose.Slides**

* Aspose.Slides fornisce le classi e i tipi necessari per lavorare con le animazioni nello spazio dei nomi `Aspose.Slides.Animation`,
* Aspose.Slides fornisce oltre **150 effetti di animazione** nell'enumerazione [EffectType](https://reference.aspose.com/slides/it/php-java/aspose.slides/effecttype). Questi effetti sono essenzialmente gli stessi (o equivalenti) utilizzati in PowerPoint.

## **Applicare un'animazione a una TextBox**

Aspose.Slides per PHP via Java consente di applicare animazioni al testo in una forma.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation).
2. Ottenere un riferimento a una diapositiva tramite il suo indice.
3. Aggiungere un rettangolo [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/).
4. Aggiungere testo al [TextFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/#getTextFrame) di `AutoShape`.
5. Ottenere la sequenza principale di effetti.
6. Aggiungere un effetto di animazione a [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/).
7. Utilizzare il metodo `TextAnimation.setBuildType` e il valore dell'enumerazione `BuildType`.
8. Scrivere la presentazione su disco come file PPTX.

Questo codice PHP mostra come applicare l'effetto `Fade` a AutoShape e impostare l'animazione del testo al valore *By 1st Level Paragraphs*:

```php
  # Istanzia una classe Presentation che rappresenta un file di presentazione.
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    # Aggiunge una nuova AutoShape con testo
    $autoShape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 100);
    $textFrame = $autoShape->getTextFrame();
    $textFrame->setText("First paragraph \nSecond paragraph \n Third paragraph");
    # Ottiene la sequenza principale della diapositiva.
    $sequence = $sld->getTimeline()->getMainSequence();
    # Aggiunge l'effetto di animazione Fade alla forma
    $effect = $sequence->addEffect($autoShape, EffectType::Fade, EffectSubType::None, EffectTriggerType::OnClick);
    # Anima il testo della forma per paragrafi di primo livello
    $effect->getTextAnimation()->setBuildType(BuildType::ByLevelParagraphs1);
    # Salva il file PPTX su disco
    $pres->save($path . "AnimText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{%  alert color="primary"  %}} 

Oltre ad applicare animazioni al testo, è possibile applicare animazioni a un singolo [Paragraph](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraph/). Vedi [**Animated Text**](/slides/it/php-java/animated-text/).

{{% /alert %}} 

## **Applicare un'animazione a un PictureFrame**

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation).
2. Ottenere un riferimento a una diapositiva tramite il suo indice.
3. Aggiungere o ottenere un [PictureFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/pictureframe) sulla diapositiva.
4. Ottenere la sequenza principale di effetti.
5. Aggiungere un effetto di animazione a [PictureFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/pictureframe).
6. Scrivere la presentazione su disco come file PPTX.

Questo codice PHP mostra come applicare l'effetto `Fly` a un picture frame:

```php
  # Istanzia una classe Presentation che rappresenta un file di presentazione.
  $pres = new Presentation();
  try {
    # Carica l'immagine da aggiungere alla collezione di immagini della presentazione
    $picture;
    $image = Images->fromFile("aspose-logo.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Aggiunge un picture frame alla diapositiva
    $picFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, $picture);
    # Ottiene la sequenza principale della diapositiva.
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    # Aggiunge l'effetto di animazione Fly da sinistra al picture frame
    $effect = $sequence->addEffect($picFrame, EffectType::Fly, EffectSubType::Left, EffectTriggerType::OnClick);
    # Salva il file PPTX su disco
    $pres->save($path . "AnimImage_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Applicare un'animazione a una Shape**

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation).
2. Ottenere un riferimento a una diapositiva tramite il suo indice.
3. Aggiungere un rettangolo [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/).
4. Aggiungere un [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/) con smusso (quando questo oggetto viene cliccato, l'animazione viene riprodotta).
5. Creare una sequenza di effetti sulla forma smussata.
6. Creare un `UserPath` personalizzato.
7. Aggiungere comandi per spostarsi al `UserPath`.
8. Scrivere la presentazione su disco come file PPTX.

Questo codice PHP mostra come applicare l'effetto `PathFootball` (path football) a una shape:

```php
  # Istanzia una classe Presentation che rappresenta un file PPTX.
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    # Crea l'effetto PathFootball per una forma esistente da zero.
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);
    $ashp->addTextFrame("Animated TextBox");
    # Aggiunge l'effetto di animazione PathFootball
    $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->addEffect($ashp, EffectType::PathFootball, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # Crea una sorta di "pulsante".
    $shapeTrigger = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Bevel, 10, 10, 20, 20);
    # Crea una sequenza di effetti per questo pulsante.
    $seqInter = $pres->getSlides()->get_Item(0)->getTimeline()->getInteractiveSequences()->add($shapeTrigger);
    # Crea un percorso utente personalizzato. Il nostro oggetto verrà spostato solo dopo che il pulsante è stato cliccato.
    $fxUserPath = $seqInter->addEffect($ashp, EffectType::PathUser, EffectSubType::None, EffectTriggerType::OnClick);
    # Aggiunge comandi di movimento poiché il percorso creato è vuoto.
    $motionBhv = $fxUserPath->getBehaviors()->get_Item(0);
    $pts = new Point2DFloat[1];
    $pts[0] = new Point2DFloat(0.076, 0.59);
    $motionBhv->getPath()->add(MotionCommandPathType::LineTo, $pts, MotionPathPointsType::Auto, true);
    $pts[0] = new Point2DFloat(-0.076, -0.59);
    $motionBhv->getPath()->add(MotionCommandPathType::LineTo, $pts, MotionPathPointsType::Auto, false);
    $motionBhv->getPath()->add(MotionCommandPathType::End, null, MotionPathPointsType::Auto, false);
    # Scrive il file PPTX su disco
    $pres->save("AnimExample_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ottenere gli effetti di animazione applicati a una Shape**

Gli esempi seguenti mostrano come utilizzare il metodo `getEffectsByShape` della classe [Sequence](https://reference.aspose.com/slides/it/php-java/aspose.slides/sequence/) per ottenere tutti gli effetti di animazione applicati a una forma.

**Esempio 1: Ottenere gli effetti di animazione applicati a una forma su una diapositiva normale**

In precedenza, hai imparato come aggiungere effetti di animazione alle forme nelle presentazioni PowerPoint. Il seguente codice di esempio mostra come ottenere gli effetti applicati alla prima forma sulla prima diapositiva normale nella presentazione `AnimExample_out.pptx`.

```php
  $Array = new java_class("java.lang.reflect.Array");
  $presentation = new Presentation("AnimExample_out.pptx");

  try {
    $firstSlide = $presentation->getSlides()->get_Item(0);

    # Ottiene la sequenza principale di animazione della diapositiva.
    $sequence = $firstSlide->getTimeline()->getMainSequence();

    # Ottiene la prima forma sulla prima diapositiva.
    $shape = $firstSlide->getShapes()->get_Item(0);

    # Ottiene gli effetti di animazione applicati alla forma.
    $shapeEffects = $sequence->getEffectsByShape($shape);

    if (java_values($Array->getLength($shapeEffects)) > 0) {
      echo("The shape " . $shape->getName() . " has " . $Array->getLength($shapeEffects) . " animation effects.");
    }
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

**Esempio 2: Ottenere tutti gli effetti di animazione, inclusi quelli ereditati dai segnaposti**

Se una forma su una diapositiva normale ha segnaposti che si trovano nella diapositiva layout e/o master, e sono stati aggiunti effetti di animazione a questi segnaposti, tutti gli effetti della forma verranno riprodotti durante la presentazione, inclusi quelli ereditati dai segnaposti.

Supponiamo di avere un file di presentazione PowerPoint `sample.pptx` con una sola diapositiva contenente solo una forma di piè di pagina con il testo "Made with Aspose.Slides" e l'effetto **Random Bars** è applicato alla forma.

![Effetto di animazione della forma della diapositiva](slide-shape-animation.png)

Supponiamo inoltre che l'effetto **Split** sia applicato al segnaposto piè di pagina nella diapositiva **layout**.

![Effetto di animazione della forma del layout](layout-shape-animation.png)

Infine, l'effetto **Fly In** è applicato al segnaposto piè di pagina nella diapositiva **master**.

![Effetto di animazione della forma master](master-shape-animation.png)

Il seguente codice di esempio mostra come utilizzare il metodo `getBasePlaceholder` della classe [Shape](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/) per accedere ai segnaposti della forma e ottenere gli effetti di animazione applicati alla forma del piè di pagina, inclusi quelli ereditati dai segnaposti situati nelle diapositive layout e master.

```php
$presentation = new Presentation("sample.pptx");

$slide = $presentation->getSlides()->get_Item(0);

// Ottieni gli effetti di animazione della forma sulla diapositiva normale.
$shape = $slide->getShapes()->get_Item(0);
$shapeEffects = $slide->getTimeline()->getMainSequence()->getEffectsByShape($shape);

// Ottieni gli effetti di animazione del segnaposto sulla diapositiva layout.
$layoutShape = $shape->getBasePlaceholder();
$layoutShapeEffects = $slide->getLayoutSlide()->getTimeline()->getMainSequence()->getEffectsByShape($layoutShape);

// Ottieni gli effetti di animazione del segnaposto sulla diapositiva master.
$masterShape = $layoutShape->getBasePlaceholder();
$masterShapeEffects = $slide->getLayoutSlide()->getMasterSlide()->getTimeline()->getMainSequence()->getEffectsByShape($masterShape);

echo "Main sequence of shape effects:" . PHP_EOL;
printEffects($masterShapeEffects);
printEffects($layoutShapeEffects);
printEffects($shapeEffects);

$presentation->dispose();
```
```php
function printEffects($effects) {
    foreach ($effects as $effect) {
        echo "Type: " . $effect->getType() . ", subtype: " . $effect->getSubtype() . PHP_EOL;
    }
}
```

Output:
```text
Main sequence of shape effects:
Type: 47, subtype: 2              // Fly, Bottom
Type: 134, subtype: 45            // Split, VerticalIn
Type: 126, subtype: 22            // RandomBars, Horizontal
```

## **Modificare i metodi di temporizzazione degli effetti di animazione**

Aspose.Slides per PHP via Java consente di modificare le proprietà di Timing di un effetto di animazione.

This is the Animation Timing pane in Microsoft PowerPoint:

![Pannello di temporizzazione dell'animazione](shape-animation.png)

Queste sono le corrispondenze tra il Timing di PowerPoint e le proprietà di [Effect Timing](https://reference.aspose.com/slides/it/php-java/aspose.slides/effect/#getTiming):

- L'elenco a discesa **Start** del Timing di PowerPoint corrisponde al metodo [Timing::getTriggerType](https://reference.aspose.com/slides/it/php-java/aspose.slides/timing/#getTriggerType).
- **Duration** del Timing di PowerPoint corrisponde al metodo [Timing::getDuration](https://reference.aspose.com/slides/it/php-java/aspose.slides/timing/#getDuration). La durata di un'animazione (in secondi) è il tempo totale necessario perché l'animazione completi un ciclo.
- **Delay** del Timing di PowerPoint corrisponde al metodo [Timing::getTriggerDelayTime](https://reference.aspose.com/slides/it/php-java/aspose.slides/timing/#getTriggerDelayTime).

Ecco come modificare le proprietà di temporizzazione dell'effetto:

1. [Applicare](#apply-animation-to-shape) o ottenere l'effetto di animazione.
2. Impostare i nuovi valori necessari utilizzando il metodo [Effect::getTiming](https://reference.aspose.com/slides/it/php-java/aspose.slides/effect/#getTiming).
3. Salvare il file PPTX modificato.

```php
  # Istanzia una classe Presentation che rappresenta un file di presentazione.
  $pres = new Presentation("AnimExample_out.pptx");
  try {
    # Ottiene la sequenza principale della diapositiva.
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    # Ottiene il primo effetto della sequenza principale.
    $effect = $sequence->get_Item(0);
    # Modifica TriggerType dell'effetto per avviarlo al clic
    $effect->getTiming()->setTriggerType(EffectTriggerType::OnClick);
    # Modifica la durata dell'effetto
    $effect->getTiming()->setDuration(3.0);
    # Modifica TriggerDelayTime dell'effetto
    $effect->getTiming()->setTriggerDelayTime(0.5);
    # Salva il file PPTX su disco
    $pres->save("AnimExample_changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Suono dell'effetto di animazione**

Aspose.Slides fornisce questi metodi per consentire di lavorare con i suoni negli effetti di animazione: 

- [setSound(IAudio value)](https://reference.aspose.com/slides/it/php-java/aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/it/php-java/aspose.slides/effect/#setStopPreviousSound-boolean-)

### **Aggiungere un suono all'effetto di animazione**

Questo codice PHP mostra come aggiungere un suono a un effetto di animazione e fermarlo quando inizia l'effetto successivo:

```php
  $pres = new Presentation("AnimExample_out.pptx");
  try {
    # Aggiunge audio alla raccolta audio della presentazione
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "sampleaudio.wav"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $effectSound = $pres->getAudios()->addAudio($bytes);

    $firstSlide = $pres->getSlides()->get_Item(0);
    # Ottiene la sequenza principale della diapositiva.
    $sequence = $firstSlide->getTimeline()->getMainSequence();
    # Ottiene il primo effetto della sequenza principale
    $firstEffect = $sequence->get_Item(0);
    # Verifica l'effetto per "No Sound"
    if (java_is_null(!$firstEffect->getStopPreviousSound() && $firstEffect->getSound())) {
      # Aggiunge suono al primo effetto
      $firstEffect->setSound($effectSound);
    }
    # Ottiene la prima sequenza interattiva della diapositiva.
    $interactiveSequence = $firstSlide->getTimeline()->getInteractiveSequences()->get_Item(0);
    # Imposta il flag "Stop previous sound" dell'effetto
    $interactiveSequence->get_Item(0)->setStopPreviousSound(true);
    # Scrive il file PPTX su disco
    $pres->save("AnimExample_Sound_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Estrarre il suono di un effetto di animazione**

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/).
2. Ottenere un riferimento a una diapositiva tramite il suo indice. 
3. Ottenere la sequenza principale di effetti. 
4. Estrarre il [setSound(IAudio value)](https://reference.aspose.com/slides/it/php-java/aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) incorporato in ciascun effetto di animazione.

```php
  # Istanzia una classe Presentation che rappresenta un file di presentazione.
  $presentation = new Presentation("EffectSound.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # Ottiene la sequenza principale della diapositiva.
    $sequence = $slide->getTimeline()->getMainSequence();
    foreach($sequence as $effect) {
      if (java_is_null($effect->getSound())) {
        continue;
      }
      # Estrae il suono dell'effetto in un array di byte
      $audio = $effect->getSound()->getBinaryData();
    }
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Dopo l'animazione**

Aspose.Slides per PHP via Java consente di modificare la proprietà After animation di un effetto di animazione.

This is the Animation Effect pane and extended menu in Microsoft PowerPoint:

![Pannello dell'effetto di animazione e menu esteso](shape-after-animation.png)

L'elenco a discesa **After animation** di PowerPoint corrisponde a questi metodi: 

- Il metodo [setAfterAnimationType(int value)](https://reference.aspose.com/slides/it/php-java/aspose.slides/effect/#setAfterAnimationType) che descrive il tipo di After animation:
  * PowerPoint **More Colors** corrisponde al tipo [AfterAnimationType::Color](https://reference.aspose.com/slides/it/php-java/aspose.slides/afteranimationtype/#Color);
  * PowerPoint **Don't Dim** corrisponde al tipo [AfterAnimationType::DoNotDim](https://reference.aspose.com/slides/it/php-java/aspose.slides/afteranimationtype/#DoNotDim) (tipo predefinito di after animation);
  * PowerPoint **Hide After Animation** corrisponde al tipo [AfterAnimationType::HideAfterAnimation](https://reference.aspose.com/slides/it/php-java/aspose.slides/afteranimationtype/#HideAfterAnimation);
  * PowerPoint **Hide on Next Mouse Click** corrisponde al tipo [AfterAnimationType::HideOnNextMouseClick](https://reference.aspose.com/slides/it/php-java/aspose.slides/afteranimationtype/#HideOnNextMouseClick);
- Il metodo [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/it/php-java/aspose.slides/effect/#setAfterAnimationColor) che definisce un formato di colore per after animation. Questo metodo funziona in congiunzione con il tipo [AfterAnimationType::Color](https://reference.aspose.com/slides/it/php-java/aspose.slides/afteranimationtype/#Color). Se si cambia il tipo in un altro, il colore after animation verrà cancellato.

Questo codice PHP mostra come modificare un effetto after animation:

```php
  # Instanzia una classe Presentation che rappresenta un file di presentazione
  $pres = new Presentation("AnimImage_out.pptx");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # Ottiene il primo effetto della sequenza principale
    $firstEffect = $firstSlide->getTimeline()->getMainSequence()->get_Item(0);
    # Modifica il tipo di after animation in Color
    $firstEffect->setAfterAnimationType(AfterAnimationType::Color);
    # Imposta il colore di after animation
    $firstEffect->getAfterAnimationColor()->setColor(java("java.awt.Color")->BLUE);
    # Scrive il file PPTX su disco
    $pres->save("AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Animare il testo**

Aspose.Slides fornisce questi metodi per consentire di lavorare con il blocco *Animate text* di un effetto di animazione:

- Il metodo [setAnimateTextType(int value)](https://reference.aspose.com/slides/it/php-java/aspose.slides/effect/#setAnimateTextType) che descrive il tipo di animazione del testo dell'effetto. Il testo della forma può essere animato:
  - Tutto in una volta ([AnimateTextType::AllAtOnce](https://reference.aspose.com/slides/it/php-java/aspose.slides/animatetexttype/#AllAtOnce) tipo)
  - Per parola ([AnimateTextType::ByWord](https://reference.aspose.com/slides/it/php-java/aspose.slides/animatetexttype/#ByWord) tipo)
  - Per lettera ([AnimateTextType::ByLetter](https://reference.aspose.com/slides/it/php-java/aspose.slides/animatetexttype/#ByLetter) tipo)
- Il metodo [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/it/php-java/aspose.slides/effect/#setDelayBetweenTextParts) imposta un ritardo tra le parti del testo animate (parole o lettere). Un valore positivo specifica la percentuale della durata dell'effetto. Un valore negativo specifica il ritardo in secondi.

Ecco come è possibile modificare le proprietà *Animate text* dell'effetto:

1. [Applicare](#apply-animation-to-shape) o ottenere l'effetto di animazione.
2. Utilizzare il metodo [setBuildType(int value)](https://reference.aspose.com/slides/it/php-java/aspose.slides/textanimation/#setBuildType) e il valore [BuildType::AsOneObject](https://reference.aspose.com/slides/it/php-java/aspose.slides/buildtype/#AsOneObject) per disattivare la modalità di animazione *By Paragraphs*.
3. Impostare nuovi valori utilizzando i metodi [setAnimateTextType(int value)](https://reference.aspose.com/slides/it/php-java/aspose.slides/effect/#setAnimateTextType) e [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/it/php-java/aspose.slides/effect/#setDelayBetweenTextParts).
4. Salvare il file PPTX modificato.

```php
  # Istanzia una classe Presentation che rappresenta un file di presentazione.
  $pres = new Presentation("AnimTextBox_out.pptx");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # Ottiene il primo effetto della sequenza principale
    $firstEffect = $firstSlide->getTimeline()->getMainSequence()->get_Item(0);
    # Modifica il tipo di animazione del testo dell'effetto in "As One Object"
    $firstEffect->getTextAnimation()->setBuildType(BuildType::AsOneObject);
    # Modifica il tipo di animazione del testo dell'effetto in "By word"
    $firstEffect->setAnimateTextType(AnimateTextType::ByWord);
    # Imposta il ritardo tra le parole al 20% della durata dell'effetto
    $firstEffect->setDelayBetweenTextParts(20.0);
    # Scrive il file PPTX su disco
    $pres->save("AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Come posso garantire che le animazioni siano preservate quando pubblico la presentazione sul web?**

[Export to HTML5](/slides/it/php-java/export-to-html5/) e abilita le [options](https://reference.aspose.com/slides/it/php-java/aspose.slides/html5options/) responsabili per le animazioni di [shape](https://reference.aspose.com/slides/it/php-java/aspose.slides/html5options/setanimateshapes/) e di [transition](https://reference.aspose.com/slides/it/php-java/aspose.slides/html5options/setanimatetransitions/). L'HTML semplice non riproduce le animazioni delle diapositive, mentre l'HTML5 lo fa.

**Come influisce il cambiamento dell'ordine Z (ordine dei livelli) delle forme sull'animazione?**

L'ordine di animazione e l'ordine di disegno sono indipendenti: un effetto controlla il tempo e il tipo di apparizione/scomparsa, mentre lo [z-order](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/getzorderposition/) determina cosa copre cosa. Il risultato visibile è definito dalla loro combinazione. (Questo è il comportamento generale di PowerPoint; il modello effetti‑e‑forme di Aspose.Slides segue la stessa logica.)

**Ci sono limitazioni nella conversione delle animazioni in video per alcuni effetti?**

In generale, le [animazioni sono supportate](/slides/it/php-java/convert-powerpoint-to-video/), ma casi rari o effetti specifici potrebbero essere renderizzati in modo diverso. È consigliabile testare con gli effetti che utilizzi e con la versione della libreria.