---
title: Formattare i grafici della presentazione in C++
linktitle: Formattazione del grafico
type: docs
weight: 60
url: /it/cpp/chart-formatting/
keywords:
- formattazione del grafico
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

Questo articolo spiega come formattare i grafici nelle presentazioni PowerPoint utilizzando Aspose.Slides. Mostra come personalizzare gli elementi chiave del grafico come assi, linee della griglia, titoli, legende, area del grafico e riempimenti delle pareti per migliorare l'aspetto e la leggibilità dei dati del grafico.

Dimostra inoltre come impostare le proprietà del carattere per il testo del grafico, applicare formati numerici predefiniti e personalizzati ai dati del grafico e abilitare gli angoli arrotondati per l'area del grafico. Insieme, questi esempi mostrano come controllare sia lo stile visivo sia la presentazione dei dati dei grafici in una presentazione.

## **Formattare le entità del grafico**
Aspose.Slides for C++ consente agli sviluppatori di aggiungere grafici personalizzati alle proprie diapositive da zero. Questo articolo spiega come formattare diverse entità del grafico, inclusi l'asse delle categorie e l'asse dei valori.

Aspose.Slides for C++ fornisce un'API semplice per gestire le varie entità del grafico e formattarle usando valori personalizzati:

1. Creare un'istanza della classe **Presentation**.
1. Ottenere un riferimento alla diapositiva tramite il suo indice.
1. Aggiungere un grafico con dati predefiniti insieme a uno dei tipi desiderati (in questo esempio useremo ChartType.LineWithMarkers).
1. Accedere all'asse dei valori del grafico e impostare le seguenti proprietà:
   1. Impostare **Line format** per le linee della griglia principale dell'asse dei valori
   1. Impostare **Line format** per le linee della griglia secondaria dell'asse dei valori
   1. Impostare **Number Format** per l'asse dei valori
   1. Impostare **Min, Max, Major and Minor units** per l'asse dei valori
   1. Impostare **Text Properties** per i dati dell'asse dei valori
   1. Impostare **Title** per l'asse dei valori
   1. Impostare **Line Format** per l'asse dei valori
1. Accedere all'asse delle categorie del grafico e impostare le seguenti proprietà:
   1. Impostare **Line format** per le linee della griglia principale dell'asse delle categorie
   1. Impostare **Line format** per le linee della griglia secondaria dell'asse delle categorie
   1. Impostare **Text Properties** per i dati dell'asse delle categorie
   1. Impostare **Title** per l'asse delle categorie
   1. Impostare **Label Positioning** per l'asse delle categorie
   1. Impostare **Rotation Angle** per le etichette dell'asse delle categorie
1. Accedere alla legenda del grafico e impostare le **Text Properties** per essa
1. Impostare la visualizzazione delle legende senza sovrapposizione al grafico
1. Accedere all'**Secondary Value Axis** del grafico e impostare le seguenti proprietà:
   1. Abilitare l'**Value Axis** secondario
   1. Impostare **Line Format** per l'asse dei valori secondario
   1. Impostare **Number Format** per l'asse dei valori secondario
   1. Impostare **Min, Max, Major and Minor units** per l'asse dei valori secondario
1. Ora tracciare la prima serie di grafico sull'asse dei valori secondario
1. Impostare il colore di riempimento del muro posteriore del grafico
1. Impostare il colore di riempimento dell'area del grafico
1. Scrivere la presentazione modificata in un file PPTX

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartEntities-ChartEntities.cpp" >}}

## **Impostare le proprietà del carattere per un grafico**
Aspose.Slides for C++ fornisce il supporto per impostare le proprietà relative al carattere per il grafico. Seguire i passaggi seguenti per impostare le proprietà del carattere per il grafico.

- Istanziare l'oggetto della classe Presentation.
- Aggiungere un grafico alla diapositiva.
- Impostare l'altezza del carattere.
- Salvare la presentazione modificata.

Di seguito è riportato un esempio di codice.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-FontPropertiesForChart-FontPropertiesForChart.cpp" >}}

## **Impostare le proprietà del carattere per una tabella dati del grafico**
Aspose.Slides for C++ fornisce il supporto per modificare il colore delle categorie in una serie di colori.

1. Istanziare l'oggetto della classe Presentation.
1. Aggiungere un grafico alla diapositiva.
1. Impostare la tabella del grafico.
1. Impostare l'altezza del carattere.
1. Salvare la presentazione modificata.

Di seguito è riportato un esempio di codice.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontPropertiesForChartDataTable-SettingFontPropertiesForChartDataTable.cpp" >}}

## **Impostare i bordi arrotondati dell'area del grafico**
Aspose.Slides for C++ fornisce il supporto per impostare l'area del grafico. Sono state aggiunte le proprietà **IChart.HasRoundedCorners** e **Chart.HasRoundedCorners** in Aspose.Slides.

1. Istanziare l'oggetto della classe Presentation.
1. Aggiungere un grafico alla diapositiva.
1. Impostare il tipo di riempimento e il colore di riempimento del grafico
1. Impostare la proprietà round corner su True.
1. Salvare la presentazione modificata.

Di seguito è riportato un esempio di codice.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingChartAreaRoundedBorders-SettingChartAreaRoundedBorders.cpp" >}}

## **Impostare il formato numerico**
Aspose.Slides for C++ fornisce un'API semplice per gestire il formato dei dati del grafico:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) .
1. Ottenere un riferimento alla diapositiva tramite il suo indice.
1. Aggiungere un grafico con dati predefiniti insieme a uno dei tipi desiderati (questo esempio utilizza **ChartType.ClusteredColumn**).
1. Impostare il formato numerico predefinito tra i valori predefiniti disponibili.
1. Scorrere le celle dei dati del grafico in ogni serie e impostare il formato numerico dei dati del grafico.
1. Salvare la presentazione.
1. Impostare il formato numerico personalizzato.
1. Scorrere le celle dei dati del grafico in ogni serie e impostare un formato numerico diverso per i dati del grafico.
1. Salvare la presentazione.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-NumberFormat-NumberFormat.cpp" >}}

| |**I possibili valori di formato numerico predefinito insieme al loro indice e che possono essere utilizzati sono elencati di seguito:**|
| :- | :- |

|**0**|General|
| :- | :- |
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

Sì. La trasparenza del riempimento e il contorno sono configurati separatamente. Questo è utile per migliorare la leggibilità della griglia e dei dati in visualizzazioni densamente popolate.

**Come posso gestire le etichette dei dati quando si sovrappongono?**

Ridurre la dimensione del carattere, disabilitare componenti di etichetta non essenziali (ad esempio, le categorie), impostare lo spostamento/posizione dell'etichetta, mostrare le etichette solo per i punti selezionati se necessario, oppure passare al formato “valore + legenda”.

**Posso applicare riempimenti a gradiente o motivo alle serie?**

Sì. Sono generalmente disponibili sia riempimenti a tinta unita sia a gradiente/motivo. In pratica, utilizzare i gradienti con parsimonia ed evitare combinazioni che riducono il contrasto con la griglia e il testo.