---
title: Gestire i controlli ActiveX nelle presentazioni con PHP
linktitle: ActiveX
type: docs
weight: 80
url: /it/php-java/activex/
keywords:
- ActiveX
- controllo ActiveX
- gestire ActiveX
- aggiungere ActiveX
- modificare ActiveX
- lettore multimediale
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Scopri come Aspose.Slides per PHP via Java sfrutta ActiveX per automatizzare e migliorare le presentazioni PowerPoint, fornendo agli sviluppatori un controllo potente sulle diapositive."
---
## **Introduzione**

I controlli ActiveX sono usati nelle presentazioni. Aspose.Slides per PHP via Java consente di aggiungere e gestire i controlli ActiveX, ma sono un po' più difficili da gestire rispetto alle forme normali della presentazione. Abbiamo implementato il supporto per l'aggiunta del controllo Active Media Player in Aspose.Slides. Si noti che i controlli ActiveX non sono forme; non fanno parte della [ShapeCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/shapecollection/) della presentazione. Sono invece parte della separata [ControlCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/controlcollection/). In questo argomento ti mostreremo come lavorare con essi.

## **Aggiungere un controllo Media Player ActiveX a una diapositiva**
Per aggiungere un controllo Media Player ActiveX, procedi così:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation) e genera una presentazione vuota.
1. Accedi alla diapositiva di destinazione nella [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation).
1. Aggiungi il controllo Media Player ActiveX usando il metodo [addControl](https://reference.aspose.com/slides/it/php-java/aspose.slides/controlcollection/addcontrol/) esposto da [ControlCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/controlcollection/).
1. Accedi al controllo Media Player ActiveX e imposta il percorso del video usando le sue proprietà.
1. Salva la presentazione come file PPTX.

Questo esempio di codice, basato sui passaggi precedenti, mostra come aggiungere un controllo Media Player ActiveX a una diapositiva:

```php
  # Crea un'istanza di presentazione vuota
  $pres = new Presentation();
  try {
    # Aggiungere il controllo Media Player ActiveX
    $pres->getSlides()->get_Item(0)->getControls()->addControl(ControlType::WindowsMediaPlayer, 100, 100, 400, 400);
    # Accedi al controllo Media Player ActiveX e imposta il percorso del video
    $pres->getSlides()->get_Item(0)->getControls()->get_Item(0)->getProperties()->set_Item("URL", "Wildlife.wmv");
    # Salva la presentazione
    $pres->save("Output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Modificare un controllo ActiveX**
{{% alert color="primary" %}} 

Aspose.Slides per PHP via Java 7.1.0 e versioni successive sono dotati di componenti per la gestione dei controlli ActiveX. Puoi accedere al controllo ActiveX già aggiunto nella tua presentazione e modificarlo o eliminarlo tramite le sue proprietà.

{{% /alert %}} 

Per gestire un semplice controllo ActiveX come una casella di testo e un pulsante di comando su una diapositiva, procedi così:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation) e carica la presentazione contenente i controlli ActiveX.
1. Ottieni un riferimento alla diapositiva tramite il suo indice.
1. Accedi ai controlli ActiveX nella diapositiva accedendo alla [ControlCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/controlcollection/).
1. Accedi al controllo ActiveX TextBox1 usando l'oggetto [Control](https://reference.aspose.com/slides/it/php-java/aspose.slides/control/).
1. Modifica le proprietà del controllo ActiveX TextBox1, che includono testo, carattere, altezza del carattere e posizione del riquadro.
1. Accedi al secondo controllo chiamato CommandButton1.
1. Modifica la didascalia del pulsante, il carattere e la posizione.
1. Sposta la posizione dei riquadri dei controlli ActiveX.
1. Scrivi la presentazione modificata in un file PPTX.

Questo esempio di codice, basato sui passaggi precedenti, mostra come gestire un semplice controllo ActiveX:

```php
  # Accesso alla presentazione con controlli ActiveX
  $pres = new Presentation("ActiveX.pptm");
  try {
    # Accesso alla prima diapositiva nella presentazione
    $slide = $pres->getSlides()->get_Item(0);
    # Modifica del testo della TextBox
    $control = $slide->getControls()->get_Item(0);
    if (!java_is_null($control->getName()->equalsIgnoreCase("TextBox1") && $control->getProperties())) {
      $newText = "Changed text";
      $control->getProperties()->set_Item("Value", $newText);
      # Modifica dell'immagine sostitutiva. PowerPoint sostituirà questa immagine durante l'attivazione di ActiveX,
      # quindi a volte va bene lasciare l'immagine invariata.
      $image = new BufferedImage($control->getFrame()->getWidth(), $control->getFrame()->getHeight(), BufferedImage->TYPE_INT_ARGB);
      $graphics = $image->getGraphics();
      $graphics->setColor(SystemColor->window);
      $graphics->fillRect(0, 0, $image->getWidth(), $image->getHeight());
      $font = new Font($control->getProperties()->get_Item("FontName"), Font->PLAIN, 16);
      $graphics->setColor(SystemColor->windowText);
      $graphics->setFont($font);
      $graphics->drawString($newText, 10, 20);
      $graphics->setColor(SystemColor->controlShadow);
      $graphics->drawLine(0, $image->getHeight() - 1, 0, 0);
      $graphics->drawLine(0, 0, $image->getWidth() - 1, 0);
      $graphics->setColor(SystemColor->controlDkShadow);
      $graphics->drawLine(1, $image->getHeight() - 2, 1, 1);
      $graphics->drawLine(1, 1, $image->getWidth() - 2, 1);
      $graphics->setColor(SystemColor->controlHighlight);
      $graphics->drawLine(1, $image->getHeight() - 1, $image->getWidth() - 1, $image->getHeight() - 1);
      $graphics->drawLine($image->getWidth() - 1, $image->getHeight() - 1, $image->getWidth() - 1, 1);
      $graphics->setColor(SystemColor->controlLtHighlight);
      $graphics->drawLine(0, $image->getHeight(), $image->getWidth(), $image->getHeight());
      $graphics->drawLine($image->getWidth(), $image->getHeight(), $image->getWidth(), 0);
      $graphics->dispose();
      $baos = new Java("java.io.ByteArrayOutputStream");
      Java("javax.imageio.ImageIO")->write($image, "PNG", $baos);
      $control->getSubstitutePictureFormat()->getPicture()->setImage($pres->getImages()->addImage($baos->toByteArray()));
    }
    # Modifica della didascalia del pulsante
    $control = $pres->getSlides()->get_Item(0)->getControls()->get_Item(1);
    if (!java_is_null($control->getName()->equalsIgnoreCase("CommandButton1") && $control->getProperties())) {
      $newCaption = "Show MessageBox";
      $control->getProperties()->set_Item("Caption", $newCaption);
      # Modifica del sostituto
      $image = new BufferedImage($control->getFrame()->getWidth(), $control->getFrame()->getHeight(), BufferedImage->TYPE_INT_ARGB);
      $graphics = $image->getGraphics();
      $graphics->setColor(SystemColor->control);
      $graphics->fillRect(0, 0, $image->getWidth(), $image->getHeight());
      $font = new Font($control->getProperties()->get_Item("FontName"), Font->PLAIN, 16);
      $graphics->setColor(SystemColor->windowText);
      $graphics->setFont($font);
      $metrics = $graphics->getFontMetrics($font);
      $graphics->drawString($newCaption, $image->getWidth() - $metrics->stringWidth($newCaption) / 2, 20);
      $graphics->setColor(SystemColor->controlLtHighlight);
      $graphics->drawLine(0, $image->getHeight() - 1, 0, 0);
      $graphics->drawLine(0, 0, $image->getWidth() - 1, 0);
      $graphics->setColor(SystemColor->controlHighlight);
      $graphics->drawLine(1, $image->getHeight() - 2, 1, 1);
      $graphics->drawLine(1, 1, $image->getWidth() - 2, 1);
      $graphics->setColor(SystemColor->controlShadow);
      $graphics->drawLine(1, $image->getHeight() - 1, $image->getWidth() - 1, $image->getHeight() - 1);
      $graphics->drawLine($image->getWidth() - 1, $image->getHeight() - 1, $image->getWidth() - 1, 1);
      $graphics->setColor(SystemColor->controlDkShadow);
      $graphics->drawLine(0, $image->getHeight(), $image->getWidth(), $image->getHeight());
      $graphics->drawLine($image->getWidth(), $image->getHeight(), $image->getWidth(), 0);
      $graphics->dispose();
      $baos = new Java("java.io.ByteArrayOutputStream");
      Java("javax.imageio.ImageIO")->write($image, "PNG", $baos);
      $control->getSubstitutePictureFormat()->getPicture()->setImage($pres->getImages()->addImage($baos->toByteArray()));
    }
    # spostamento di 100 punti verso il basso
    foreach($pres->getSlides()->get_Item(0)->getControls() as $ctl) {
      $frame = $ctl->getFrame();
      $ctl->setFrame(new ShapeFrame($frame->getX(), $frame->getY() + 100, $frame->getWidth(), $frame->getHeight(), $frame->getFlipH(), $frame->getFlipV(), $frame->getRotation()));
    }
    $pres->save("withActiveX-edited_java.pptm", SaveFormat::Pptm);
    # rimozione dei controlli
    $pres->getSlides()->get_Item(0)->getControls()->clear();
    $pres->save("withActiveX-cleared_java.pptm", SaveFormat::Pptm);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Aspose.Slides preserva i controlli ActiveX durante la lettura e il risalvataggio se non possono essere eseguiti nell'ambiente Java?**

Sì. Aspose.Slides li tratta come parte della presentazione e può leggere/modificare le loro proprietà e i loro riquadri; non è necessario eseguire i controlli stessi per preservarli.

**In che modo i controlli ActiveX differiscono dagli oggetti OLE in una presentazione?**

I controlli ActiveX sono controlli interattivi gestiti (pulsanti, caselle di testo, lettore multimediale), mentre [OLE](/slides/it/php-java/manage-ole/) si riferisce a oggetti applicativi incorporati (ad esempio, un foglio di lavoro Excel). Sono archiviati e gestiti in modo diverso e hanno modelli di proprietà differenti.

**Gli eventi ActiveX e le macro VBA funzionano se il file è stato modificato da Aspose.Slides?**

Aspose.Slides preserva il markup e i metadati esistenti; tuttavia, eventi e macro vengono eseguiti solo all'interno di PowerPoint su Windows quando la sicurezza lo consente. La libreria non esegue VBA.