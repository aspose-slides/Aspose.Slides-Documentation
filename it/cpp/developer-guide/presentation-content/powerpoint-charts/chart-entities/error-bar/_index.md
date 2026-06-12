---
title: Personalizza le barre di errore nei grafici delle presentazioni usando C++
linktitle: Barra di errore
type: docs
url: /it/cpp/error-bar/
keywords:
- barra di errore
- valore personalizzato
- PowerPoint
- presentazione
- С++
- Aspose.Slides
description: "Scopri come aggiungere e personalizzare le barre di errore nei grafici con Aspose.Slides per C++ — ottimizza le visualizzazioni dei dati nelle presentazioni PowerPoint."
---
## **Panoramica**

Questo articolo spiega come lavorare con le barre di errore nei grafici delle presentazioni utilizzando Aspose.Slides. Mostra come aggiungere barre di errore a una serie di grafico, configurare le impostazioni delle barre di errore X e Y e applicare diversi tipi di valore come fisso, percentuale e valori personalizzati.

Dimostra inoltre come assegnare valori di barra di errore personalizzati per punti dati individuali in una serie utilizzando la relativa collezione di punti dati. Inoltre, l'articolo include brevi note su come le barre di errore si comportano durante l'esportazione, la loro compatibilità con i marcatori e le etichette dati, e dove trovare le classi e le enum di riferimento dell'API correlate.

## **Aggiungi barre di errore**
Aspose.Slides per C++ fornisce un'API semplice per gestire i valori delle barre di errore. Il codice di esempio si applica quando si utilizza un tipo di valore personalizzato. Per specificare un valore, utilizzare la proprietà **ErrorBarCustomValues** di un punto dati specifico nella collezione **DataPoints** della serie:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
1. Aggiungere un grafico a bolle nella diapositiva desiderata.
1. Accedere alla prima serie del grafico e impostare il formato della barra di errore X.
1. Accedere alla prima serie del grafico e impostare il formato della barra di errore Y.
1. Impostare i valori e il formato delle barre.
1. Scrivere la presentazione modificata in un file PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddErrorBars-AddErrorBars.cpp" >}}

## **Aggiungi barre di errore personalizzate**
Aspose.Slides per C++ fornisce un'API semplice per gestire i valori delle barre di errore personalizzate. Il codice di esempio si applica quando la proprietà **IErrorBarsFormat.ValueType** è pari a **Custom**. Per specificare un valore, utilizzare la proprietà **ErrorBarCustomValues** di un punto dati specifico nella collezione **DataPoints** della serie:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
1. Aggiungere un grafico a bolle nella diapositiva desiderata.
1. Accedere alla prima serie del grafico e impostare il formato della barra di errore X.
1. Accedere alla prima serie del grafico e impostare il formato della barra di errore Y.
1. Accedere ai singoli punti dati della serie del grafico e impostare i valori della barra di errore per un punto dati individuale della serie.
1. Impostare i valori e il formato delle barre.
1. Scrivere la presentazione modificata in un file PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddCustomError-AddCustomError.cpp" >}}

## **FAQ**

**Cosa succede alle barre di errore quando si esporta una presentazione in PDF o immagini?**

Vengono renderizzate come parte del grafico e preservate durante la conversione insieme al resto della formattazione del grafico, a condizione di utilizzare una versione o un renderer compatibile.

**Le barre di errore possono essere combinate con i marcatori e le etichette dati?**

Sì. Le barre di errore sono un elemento separato e sono compatibili con i marcatori e le etichette dati; se gli elementi si sovrappongono, potrebbe essere necessario regolare la formattazione.

**Dove posso trovare l'elenco delle proprietà e delle enum per lavorare con le barre di errore nell'API?**

Nella documentazione dell'API: la classe [ErrorBarsFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/errorbarsformat/) e le enum correlate [ErrorBarType](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/errorbartype/) e [ErrorBarValueType](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/errorbarvaluetype/).