---
title: Formattare i grafici delle presentazioni in C++
linktitle: Formattazione del grafico
type: docs
weight: 60
url: /it/cpp/chart-formatting/
keywords:
- formattare grafico
- formattazione grafico
- entità del grafico
- proprietà del grafico
- impostazioni del grafico
- opzioni del grafico
- proprietà del carattere
- bordo arrotondato
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Impara a formattare i grafici in Aspose.Slides per C++ e migliora la tua presentazione PowerPoint con uno stile professionale e accattivante."
---
## **Panoramica**

Questo articolo spiega come formattare i grafici nelle presentazioni PowerPoint utilizzando Aspose.Slides. Mostra come personalizzare gli elementi chiave del grafico, come assi, linee della griglia, titoli, legende, area del tracciato e riempimenti delle pareti, per migliorare l'aspetto e la leggibilità dei dati del grafico.

Dimostra inoltre come impostare le proprietà del carattere per il testo del grafico, applicare formati numerici predefiniti e personalizzati ai dati del grafico e abilitare gli angoli arrotondati per l'area del grafico. Insieme, questi esempi mostrano come controllare sia lo stile visivo sia la presentazione dei dati dei grafici in una presentazione.

## **Formattare le entità del grafico**
Aspose.Slides for C++ consente agli sviluppatori di aggiungere grafici personalizzati alle proprie slide da zero. Questo articolo spiega come formattare diverse entità del grafico, inclusi l'asse di categoria e l'asse dei valori.

Aspose.Slides for C++ fornisce un'API semplice per gestire diverse entità del grafico e formattarle usando valori personalizzati:

1. Crea un'istanza della classe **Presentation**.
1. Ottieni il riferimento di una slide tramite il suo indice.
1. Aggiungi un grafico con dati predefiniti insieme a uno dei tipi desiderati (in questo esempio useremo ChartType.LineWithMarkers).
1. Accedi all'asse dei valori del grafico e imposta le seguenti proprietà:
   1. Impostare **Line format** per le linee della griglia principale dell'asse dei valori
   1. Impostare **Line format** per le linee della griglia secondaria dell'asse dei valori
   1. Impostare **Number Format** per l'asse dei valori
   1. Impostare **Min, Max, Major and Minor units** per l'asse dei valori
   1. Impostare **Text Properties** per i dati dell'asse dei valori
   1. Impostare **Title** per l'asse dei valori
   1. Impostare **Line Format** per l'asse dei valori
1. Accedi all'asse delle categorie del grafico e imposta le seguenti proprietà:
   1. Impostare **Line format** per le linee della griglia principale dell'asse delle categorie
   1. Impostare **Line format** per le linee della griglia secondaria dell'asse delle categorie
   1. Impostare **Text Properties** per i dati dell'asse delle categorie
   1. Impostare **Title** per l'asse delle categorie
   1. Impostare **Label Positioning** per l'asse delle categorie
   1. Impostare **Rotation Angle** per le etichette dell'asse delle categorie
1. Accedi alla legenda del grafico e imposta le **Text Properties** per essa
1. Imposta la visualizzazione delle legende del grafico senza sovrapporle al grafico
1. Accedi all'**Secondary Value Axis** del grafico e imposta le seguenti proprietà:
   1. Abilita l'**Value Axis** secondario
   1. Impostare **Line Format** per l'asse dei valori secondario
   1. Impostare **Number Format** per l'asse dei valori secondario
   1. Impostare **Min, Max, Major and Minor units** per l'asse dei valori secondario
1. Ora traccia la prima serie del grafico sull'asse dei valori secondario
1. Imposta il colore di riempimento della parete posteriore del grafico
1. Imposta il colore di riempimento dell'area del tracciato del grafico
1. Scrivi la presentazione modificata in un file PPTX

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartEntities-ChartEntities.cpp" >}}

## **Impostare le proprietà del carattere per un grafico**
Aspose.Slides for C++ fornisce il supporto per impostare le proprietà relative al carattere per il grafico. Segui i passaggi indicati di seguito per impostare le proprietà del carattere per il grafico.

- Istanzia un oggetto della classe Presentation.
- Aggiungi un grafico sulla slide.
- Imposta l'altezza del carattere.
- Salva la presentazione modificata.

Di seguito è riportato un esempio.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-FontPropertiesForChart-FontPropertiesForChart.cpp" >}}

## **Impostare le proprietà del carattere per la tabella dati di un grafico**
Aspose.Slides for C++ fornisce il supporto per cambiare il colore delle categorie in una serie di colori.

1. Istanzia un oggetto della classe Presentation.
1. Aggiungi un grafico sulla slide.
1. Imposta la tabella del grafico.
1. Imposta l'altezza del carattere.
1. Salva la presentazione modificata.

Di seguito è riportato un esempio.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontPropertiesForChartDataTable-SettingFontPropertiesForChartDataTable.cpp" >}}

## **Impostare i bordi arrotondati dell'area del grafico**
Aspose.Slides for C++ fornisce il supporto per impostare l'area del grafico. Sono state aggiunte le proprietà **IChart.HasRoundedCorners** e **Chart.HasRoundedCorners** in Aspose.Slides.

1. Istanzia un oggetto della classe Presentation.
1. Aggiungi un grafico sulla slide.
1. Imposta il tipo di riempimento e il colore di riempimento del grafico
1. Imposta la proprietà round corner a True.
1. Salva la presentazione modificata.

Di seguito è riportato un esempio.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingChartAreaRoundedBorders-SettingChartAreaRoundedBorders.cpp" >}}

## **Impostare il formato numerico**
Aspose.Slides for C++ fornisce un'API semplice per gestire il formato dei dati del grafico:

1. Crea un'istanza della classe[Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) .
1. Ottieni il riferimento di una slide tramite il suo indice.
1. Aggiungi un grafico con dati predefiniti insieme a uno dei tipi desiderati (questo esempio utilizza **ChartType.ClusteredColumn**).
1. Imposta il formato numerico predefinito tra i valori predefiniti disponibili.
1. Scorri le celle dei dati del grafico in ogni serie e imposta il formato numerico dei dati del grafico.
1. Salva la presentazione.
1. Imposta il formato numerico personalizzato.
1. Scorri le celle dei dati del grafico in ogni serie e imposta un formato numerico diverso per i dati del grafico.
1. Salva la presentazione.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-NumberFormat-NumberFormat.cpp" >}}

| |**I possibili valori di formato numerico predefiniti insieme al loro indice predefinito e che possono essere usati sono indicati di seguito:**|
| :- | :- |
|**0**|General|
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|
|||
| :- | :- |

## **FAQ**

**Posso impostare riempimenti semitrasparenti per colonne/aree mantenendo il bordo opaco?**

Sì. La trasparenza del riempimento e il contorno sono configurati separatamente. Questo è utile per migliorare la leggibilità della griglia e dei dati in visualizzazioni dense.

**Come posso gestire le etichette dei dati quando si sovrappongono?**

Riduci la dimensione del carattere, disabilita componenti dell'etichetta non essenziali (ad esempio, le categorie), imposta lo scostamento/posizione dell'etichetta, mostra le etichette solo per i punti selezionati se necessario, oppure passa al formato "valore + legenda".

**Posso applicare riempimenti a gradiente o a motivo alle serie?**

Sì. Sono generalmente disponibili sia riempimenti a tinta unita sia a gradiente/riempimento a motivo. In pratica, usa i gradienti con parsimonia ed evita combinazioni che riducono il contrasto con la griglia e il testo.