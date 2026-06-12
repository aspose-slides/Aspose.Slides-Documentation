---
title: Animare i grafici PowerPoint in C++
linktitle: Grafici animati
type: docs
weight: 80
url: /it/cpp/animated-charts/
keywords:
- grafico
- grafico animato
- animazione del grafico
- serie del grafico
- categoria del grafico
- elemento della serie
- elemento della categoria
- aggiungi effetto
- tipo di effetto
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Crea grafici animati mozzafiato in C++ con Aspose.Slides. Potenzia le presentazioni con visual dinamici nei file PPT e PPTX — inizia subito."
---
## **Introduzione**

Aspose.Slides supporta l'animazione degli elementi del grafico. **Series**, **Categories**, **Series Elements**, **Categories Elements** possono essere animati con il metodo [ISequence::AddEffect](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/isequence/addeffect/) e due enumerazioni [EffectChartMajorGroupingType](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/effectchartmajorgroupingtype/) e [EffectChartMinorGroupingType](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/effectchartminorgroupingtype/).

## **Animazione della Serie del Grafico**
Se desideri animare una serie del grafico, scrivi il codice secondo i passaggi elencati di seguito:

1. Carica una presentazione.  
2. Ottieni il riferimento all'oggetto grafico.  
3. Anima la serie.  
4. Scrivi il file della presentazione su disco.

Nel esempio riportato di seguito, abbiamo animato le serie del grafico.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingSeries-AnimatingSeries.cpp" >}}

## **Animazione di un Elemento della Serie**
Se desideri animare gli elementi della serie, scrivi il codice secondo i passaggi elencati di seguito:

1. Carica una presentazione.  
2. Ottieni il riferimento all'oggetto grafico.  
3. Anima gli elementi della serie.  
4. Scrivi il file della presentazione su disco.

Nel esempio riportato di seguito, abbiamo animato gli elementi della serie.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingSeriesElements-AnimatingSeriesElements.cpp" >}}

## **Animazione della Categoria del Grafico**
Se desideri animare una categoria del grafico, scrivi il codice secondo i passaggi elencati di seguito:

1. Carica una presentazione.  
2. Ottieni il riferimento all'oggetto grafico.  
3. Anima la categoria.  
4. Scrivi il file della presentazione su disco.

Nel esempio riportato di seguito, abbiamo animato la categoria del grafico.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingSeries-AnimatingSeries.cpp" >}}

## **Animazione di un Elemento di Categoria**
Se desideri animare gli elementi delle categorie, scrivi il codice secondo i passaggi elencati di seguito:

1. Carica una presentazione.  
2. Ottieni il riferimento all'oggetto grafico.  
3. Anima gli elementi delle categorie.  
4. Scrivi il file della presentazione su disco.

Nel esempio riportato di seguito, abbiamo animato gli elementi delle categorie.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingCategoriesElements-AnimatingCategoriesElements.cpp" >}}

## **FAQ**

**Sono supportati diversi tipi di effetto (ad es., ingresso, enfasi, uscita) per i grafici come per le forme normali?**

Sì. Un grafico è trattato come una forma, quindi supporta i tipi standard di effetti di animazione, inclusi ingresso, enfasi e uscita, con pieno controllo tramite la timeline della diapositiva e le sequenze di animazione.

**Posso combinare l'animazione del grafico con le transizioni della diapositiva?**

Sì. [Transizioni](/slides/it/cpp/slide-transition/) si applicano alla diapositiva, mentre gli effetti di animazione si applicano agli oggetti sulla diapositiva. È possibile utilizzare entrambi nella stessa presentazione e controllarli in modo indipendente.

**Le animazioni del grafico vengono conservate quando si salva in PPTX?**

Sì. Quando [salvi in PPTX](/slides/it/cpp/save-presentation/), tutti gli effetti di animazione e il loro ordine vengono preservati perché fanno parte del modello di animazione nativo della presentazione.

**Posso leggere le animazioni del grafico esistenti da una presentazione e modificarle?**

Sì. L'[API](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/) fornisce l'accesso alla timeline della diapositiva, alle sequenze e agli effetti, consentendo di esaminare le animazioni del grafico esistenti e di regolarle senza ricreare tutto da zero.

**Posso produrre un video che includa le animazioni del grafico usando Aspose.Slides?**

Sì. È possibile [esportare una presentazione in video](/slides/it/cpp/convert-powerpoint-to-video/) mantenendo le animazioni, configurando i tempi e le altre impostazioni di esportazione in modo che il clip risultante rifletta la riproduzione animata.