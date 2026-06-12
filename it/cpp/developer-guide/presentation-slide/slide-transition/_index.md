---
title: Gestisci le transizioni delle diapositive nelle presentazioni usando C++
linktitle: Transizione diapositiva
type: docs
weight: 80
url: /it/cpp/slide-transition/
keywords:
- transizione diapositiva
- aggiungi transizione diapositiva
- applica transizione diapositiva
- transizione diapositiva avanzata
- transizione morph
- tipo di transizione
- effetto di transizione
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Scopri come personalizzare le transizioni delle diapositive in Aspose.Slides per C++, con guide passo passo per presentazioni PowerPoint e OpenDocument."
---
## **Panoramica**

Questo articolo spiega come gestire le transizioni delle diapositive nelle presentazioni utilizzando Aspose.Slides. Mostra come applicare i tipi di transizione alle diapositive, configurare il comportamento della transizione come avanzare al clic o dopo un tempo specificato, verificare e disabilitare l’avanzamento automatico, utilizzare la transizione Morph e i suoi tipi, e impostare le opzioni degli effetti di transizione. Gli esempi dimostrano come caricare o creare una presentazione, modificare le impostazioni di transizione per le diapositive selezionate e salvare il risultato in un file PPTX. L'articolo risponde inoltre a domande comuni sulla velocità della transizione, i suoni delle transizioni, l'applicazione della stessa transizione a più diapositive e il controllo della transizione attualmente impostata su una diapositiva.

## **Aggiungi transizione alla diapositiva**
Per rendere più semplice la comprensione, abbiamo mostrato l'uso di Aspose.Slides per C++ per gestire transizioni diapositive semplici. Gli sviluppatori possono non solo applicare diversi effetti di transizione alle diapositive, ma anche personalizzare il comportamento di tali effetti di transizione. Per creare un effetto di transizione diapositiva semplice, segui i passaggi seguenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation).
1. Applica un Tipo di transizione diapositiva alla diapositiva scegliendo uno dei effetti di transizione offerti da Aspose.Slides per C++ tramite l'enumerazione TransitionType.
1. Scrivi il file della presentazione modificata.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManageSimpleSlideTransitions-ManageSimpleSlideTransitions.cpp" >}}

## **Aggiungi transizione avanzata alla diapositiva**
Nella sezione precedente, abbiamo applicato un semplice effetto di transizione alla diapositiva. Ora, per rendere quell'effetto di transizione più sofisticato e controllato, segui i passaggi seguenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation).
1. Applica un Tipo di transizione diapositiva alla diapositiva scegliendo uno dei effetti di transizione offerti da Aspose.Slides per C++.
1. Puoi anche impostare la transizione per avanzare al clic, dopo un periodo di tempo specifico o entrambi.
1. Se la transizione della diapositiva è impostata su Avanzamento al clic, la transizione avanzerà solo quando qualcuno farà clic con il mouse. Inoltre, se la proprietà Advance After Time è impostata, la transizione avanzerà automaticamente dopo che il tempo specificato è trascorso.
1. Scrivi la presentazione modificata in un file di presentazione.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagingBetterSlideTransitions-ManagingBetterSlideTransitions.cpp" >}}

## **Transizione Morph**
Aspose.Slides per C++ ora supporta la Transizione Morph. Rappresentano la nuova transizione morph introdotta in PowerPoint 2019. La transizione Morph consente di animare un movimento fluido da una diapositiva all'altra. Questo articolo descrive il concetto e come utilizzare la transizione Morph. Per utilizzare efficacemente la transizione Morph, è necessario disporre di due diapositive con almeno un oggetto in comune. Il modo più semplice è duplicare la diapositiva e spostare l'oggetto nella seconda diapositiva in una posizione diversa.

Il seguente frammento di codice mostra come aggiungere un clone della diapositiva con del testo alla presentazione e impostare una transizione di tipo morph alla seconda diapositiva.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfMorphTransition-SupportOfMorphTransition.cpp" >}}

## **Tipi di transizione Morph**
È stata aggiunta la nuova enumerazione Aspose.Slides.SlideShow.TransitionMorphType. Rappresenta diversi tipi di transizione Morph per le diapositive.

L'enumerazione TransitionMorphType ha tre membri:

- ByObject: la transizione Morph verrà eseguita considerando le forme come oggetti indivisibili.
- ByWord: la transizione Morph verrà eseguita trasferendo il testo parola per parola dove possibile.
- ByChar: la transizione Morph verrà eseguita trasferendo il testo carattere per carattere dove possibile.

Il seguente frammento di codice mostra come impostare una transizione morph alla diapositiva e cambiare il tipo di morph:

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetTransitionMorphType-SetTransitionMorphType.cpp" >}}

## **Imposta effetti di transizione**
Aspose.Slides per C++ supporta l'impostazione degli effetti di transizione, ad esempio da nero, da sinistra, da destra, ecc. Per impostare l'effetto di transizione, segui i passaggi seguenti:

- Crea un'istanza della classe Presentation.
- Ottieni il riferimento della diapositiva.
- Imposta l'effetto di transizione.
- Scrivi la presentazione in un file PPTX.

Nell'esempio mostrato di seguito, abbiamo impostato gli effetti di transizione.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetTransitionEffects-SetTransitionEffects.cpp" >}}

## **FAQ**

**Posso controllare la velocità di riproduzione di una transizione diapositiva?**

Sì. Imposta la [speed](https://reference.aspose.com/slides/it/cpp/aspose.slides.slideshow/slideshowtransition/set_speed/) della transizione utilizzando l'impostazione [TransitionSpeed](https://reference.aspose.com/slides/it/cpp/aspose.slides.slideshow/transitionspeed/) (ad es., slow/medium/fast).

**Posso allegare un audio a una transizione e farlo ripetere in loop?**

Sì. È possibile incorporare un suono nella transizione e controllare il comportamento tramite impostazioni come la modalità suono e il loop (ad es., [set_Sound](https://reference.aspose.com/slides/it/cpp/aspose.slides.slideshow/slideshowtransition/set_sound/), [set_SoundMode](https://reference.aspose.com/slides/it/cpp/aspose.slides.slideshow/slideshowtransition/set_soundmode/), [set_SoundLoop](https://reference.aspose.com/slides/it/cpp/aspose.slides.slideshow/slideshowtransition/set_soundloop/), oltre a metadati come [set_SoundIsBuiltIn](https://reference.aspose.com/slides/it/cpp/aspose.slides.slideshow/slideshowtransition/set_soundisbuiltin/) e [set_SoundName](https://reference.aspose.com/slides/it/cpp/aspose.slides.slideshow/slideshowtransition/set_soundname/)).

**Qual è il modo più veloce per applicare la stessa transizione a ogni diapositiva?**

Configura il tipo di transizione desiderato nelle impostazioni di transizione di ogni diapositiva; le transizioni sono memorizzate per diapositiva, quindi applicare lo stesso tipo a tutte le diapositive produce un risultato coerente.

**Come posso verificare quale transizione è attualmente impostata su una diapositiva?**

Ispeziona le [transition settings](https://reference.aspose.com/slides/it/cpp/aspose.slides/baseslide/get_slideshowtransition/) della diapositiva e leggi il suo [transition type](https://reference.aspose.com/slides/it/cpp/aspose.slides.slideshow/slideshowtransition/get_type/); quel valore indica esattamente quale effetto è applicato.