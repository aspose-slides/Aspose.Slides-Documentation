---
title: Configurare le collezioni di caratteri di fallback in PHP
linktitle: Collezione di caratteri di fallback
type: docs
weight: 20
url: /it/php-java/create-fallback-fonts-collection/
keywords:
- carattere di fallback
- regola di fallback
- collezione di caratteri
- configurare carattere
- impostare carattere
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Configura una collezione di caratteri di fallback in Aspose.Slides per PHP tramite Java per mantenere il testo coerente e nitido nelle presentazioni PowerPoint e OpenDocument."
---
## **Panoramica**

Aspose.Slides consente di configurare una raccolta di regole di caratteri di fallback per una presentazione. Ogni regola di fallback è rappresentata dalla classe `FontFallBackRule` e può essere aggiunta a una `FontFallBackRulesCollection`.

Dopo aver creato la raccolta, è possibile assegnarla usando il metodo `setFontFallBackRulesCollection` del `FontsManager` della presentazione. Il `FontsManager` controlla i caratteri in tutta la presentazione e ogni istanza di `Presentation` ha il proprio `FontsManager`.

Una volta che il `FontsManager` è stato inizializzato con la raccolta di caratteri di fallback, i caratteri di fallback specificati vengono applicati durante il rendering della presentazione.

## **Applicare le regole di fallback**

Le istanze della classe [FontFallBackRule](https://reference.aspose.com/slides/it/php-java/aspose.slides/FontFallBackRule) possono essere organizzate in una [FontFallBackRulesCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/FontFallBackRulesCollection). È possibile aggiungere o rimuovere regole dalla raccolta.

Questa raccolta può quindi essere assegnata al metodo [FontFallBackRulesCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/FontFallBackRulesCollection) della classe [FontsManager](https://reference.aspose.com/slides/it/php-java/aspose.slides/FontsManager). Il FontsManager controlla i caratteri in tutta la presentazione.

Ogni [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation) dispone di un metodo [getFontsManager](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation#getFontsManager) con la propria istanza della classe [FontsManager](https://reference.aspose.com/slides/it/php-java/aspose.slides/FontsManager).

Ecco un esempio su come creare una raccolta di regole di caratteri di fallback e assegnarla al [FontsManager](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation#getFontsManager) di una determinata presentazione:

```php
  $pres = new Presentation();
  try {
    $userRulesList = new FontFallBackRulesCollection();
    $userRulesList->add(new FontFallBackRule(0xb80, 0xbff, "Vijaya"));
    $userRulesList->add(new FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic"));
    $pres->getFontsManager()->setFontFallBackRulesCollection($userRulesList);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Dopo che il FontsManager è stato inizializzato con la raccolta di caratteri di fallback, i caratteri di fallback vengono applicati durante il rendering della presentazione.

{{% alert color="primary" %}} 
Leggi di più su come [Renderizzare la presentazione con carattere di fallback](/slides/it/php-java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

**Le mie regole di fallback saranno incorporate nel file PPTX e visibili in PowerPoint dopo il salvataggio?**

No. Le regole di fallback sono impostazioni di rendering in fase di esecuzione; non vengono serializzate nel PPTX e non appariranno nell'interfaccia di PowerPoint.

**Il fallback si applica al testo all'interno di SmartArt, WordArt, grafici e tabelle?**

Sì. Lo stesso meccanismo di sostituzione dei glifi è utilizzato per qualsiasi testo in questi oggetti.

**Aspose distribuisce qualche carattere con la libreria?**

No. Aggiungi e utilizzi i caratteri da parte tua, sotto la tua responsabilità.

**È possibile utilizzare contemporaneamente la sostituzione/sostituzione per caratteri mancanti e il fallback per glifi mancanti?**

Sì. Sono fasi indipendenti della stessa pipeline di risoluzione dei caratteri: prima il motore risolve la disponibilità dei caratteri ([replacement](/slides/it/php-java/font-replacement/)/[substitution](/slides/it/php-java/font-substitution/)), poi il fallback colma le lacune dei glifi mancanti nei caratteri disponibili.