---
title: Forme di gruppo per presentazioni in C++
linktitle: Gruppo di forme
type: docs
weight: 40
url: /it/cpp/group/
keywords:
- forma di gruppo
- gruppo di forme
- aggiungere gruppo
- testo alternativo
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Impara a raggruppare e separare forme nei deck di PowerPoint usando Aspose.Slides per C++ — guida rapida, passo passo con codice C++ gratuito."
---
## **Panoramica**

Questo articolo spiega come lavorare con le forme di gruppo in Aspose.Slides. Mostra come aggiungere una forma di gruppo a una diapositiva, inserire forme al suo interno e salvare la presentazione aggiornata. Dimostra anche come accedere alle forme memorizzate all'interno di un gruppo e leggere i valori di `AlternativeText`. Inoltre, l'articolo copre brevemente le funzionalità correlate alle forme di gruppo, come i gruppi nidificati, l'ordine Z e le opzioni di blocco.

## **Aggiungere una Forma di Gruppo**
Aspose.Slides supporta il lavoro con le forme di gruppo nelle diapositive. Questa funzionalità aiuta gli sviluppatori a creare presentazioni più ricche. Aspose.Slides per C++ supporta l'aggiunta o l'accesso alle forme di gruppo. È possibile aggiungere forme a una forma di gruppo aggiunta per popolarla o accedere a qualsiasi proprietà della forma di gruppo. Per aggiungere una forma di gruppo a una diapositiva usando Aspose.Slides per C++:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
1. Ottieni il riferimento di una diapositiva usando il suo Index
1. Aggiungi una forma di gruppo alla diapositiva.
1. Aggiungi le forme alla forma di gruppo aggiunta.
1. Salva la presentazione modificata come file PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateGroupShape-CreateGroupShape.cpp" >}}

## **Accedere alla Proprietà AltText**
Questo argomento mostra passaggi semplici, con esempi di codice, per aggiungere una forma di gruppo e accedere alla proprietà AltText delle forme di gruppo nelle diapositive. Per accedere all'AltText di una forma di gruppo in una diapositiva usando Aspose.Slides per C++:

1. Istanzia la classe `Presentation` che rappresenta un file PPTX.
1. Ottieni il riferimento di una diapositiva usando il suo Index.
1. Accedi alla raccolta di forme delle diapositive.
1. Accedi alla forma di gruppo.
1. Accedi alla proprietà AltText.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessingAltTextinGroupshapes-AccessingAltTextinGroupshapes.cpp" >}}

## **FAQ**

**Is nested grouping (a group inside a group) supported?**

Sì. [GroupShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/groupshape/) ha un metodo [get_ParentGroup](https://reference.aspose.com/slides/it/cpp/aspose.slides/shape/get_parentgroup/) che indica direttamente il supporto della gerarchia (un gruppo può essere figlio di un altro gruppo).

**Come posso controllare l'ordine Z del gruppo rispetto agli altri oggetti nella diapositiva?**

Usa la [Z-Order position](https://reference.aspose.com/slides/it/cpp/aspose.slides/shape/get_zorderposition/) del [GroupShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/groupshape/) per ispezionare la sua posizione nello stack di visualizzazione.

**Posso impedire lo spostamento/modifica/sgruppamento?**

Sì. La sezione di blocco del gruppo è esposta tramite [get_GroupShapeLock](https://reference.aspose.com/slides/it/cpp/aspose.slides/groupshape/get_groupshapelock/), che consente di limitare le operazioni sull'oggetto.