---
title: Personalizza le legende dei grafici nelle presentazioni usando C++
linktitle: Legenda del grafico
type: docs
url: /it/cpp/chart-legend/
keywords:
- legenda del grafico
- posizione della legenda
- dimensione del carattere
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Personalizza le legende dei grafici con Aspose.Slides per C++ per ottimizzare le presentazioni PowerPoint con una formattazione della legenda su misura."
---
## **Panoramica**

Aspose.Slides offre opzioni per personalizzare le legende dei grafici nelle presentazioni PowerPoint. Questo articolo mostra come posizionare e dimensionare una legenda, impostare la dimensione del carattere per l'intera legenda e applicare formattazioni a una voce della legenda individuale.

Copre inoltre diversi comportamenti correlati nella FAQ, tra cui l'uso della modalità non sovrapposta affinché l'area del grafico faccia spazio alla legenda, la possibilità di far andare a capo le etichette lunghe della legenda o utilizzare interruzioni di linea, e far ereditare alla formattazione della legenda lo schema del tema della presentazione quando non sono impostati esplicitamente testo e riempimento.

## **Posizionamento della Legenda**
Per impostare le proprietà della legenda, segui i passaggi seguenti:

- Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
- Ottieni il riferimento della diapositiva.
- Aggiungi un grafico alla diapositiva.
- Imposta le proprietà della legenda.
- Salva la presentazione in un file PPTX.

Nell'esempio riportato di seguito, abbiamo impostato la posizione e le dimensioni della legenda del grafico.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetlegendCustomOptions-SetlegendCustomOptions.cpp" >}}

## **Impostare la Dimensione del Carattere di una Legenda**
Aspose.Slides per C++ consente agli sviluppatori di impostare la dimensione del carattere della legenda. Segui i passaggi seguenti:

- Istanzia la classe Presentation.
- Crea il grafico predefinito.
- Imposta la dimensione del carattere.
- Imposta il valore minimo dell'asse.
- Imposta il valore massimo dell'asse.
- Scrivi la presentazione su disco.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontSizeOfLegend-SettingFontSizeOfLegend.cpp" >}}

## **Impostare la Dimensione del Carattere di una Voce di Legenda Individuale**
Aspose.Slides per C++ consente agli sviluppatori di impostare la dimensione del carattere delle singole voci della legenda. Segui i passaggi seguenti:

- Istanzia la classe Presentation.
- Crea il grafico predefinito.
- Accedi alla voce della legenda.
- Imposta la dimensione del carattere.
- Imposta il valore minimo dell'asse.
- Imposta il valore massimo dell'asse.
- Scrivi la presentazione su disco.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontSizeOfIndividualLegend-SettingFontSizeOfIndividualLegend.cpp" >}}

## **FAQ**

**Posso abilitare la legenda in modo che il grafico allochi automaticamente spazio per essa invece di sovrapporla?**

Sì. Usa la modalità non‑sovrapposta ([set_Overlay(false)](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/legend/set_overlay/)); in questo caso, l'area del grafico si ridurrà per fare spazio alla legenda.

**Posso creare etichette della legenda su più righe?**

Sì. Le etichette lunghe vanno a capo automaticamente quando lo spazio è insufficiente; le interruzioni di linea forzate sono supportate tramite caratteri di nuova riga nel nome della serie.

**Come posso fare in modo che la legenda segua lo schema di colori del tema della presentazione?**

Non impostare colori/riempimenti/font espliciti per la legenda o per il suo testo; erediterà quindi dal tema e si aggiornerà correttamente quando il design cambia.