---
title: Personalizza le legende dei grafici nelle presentazioni con Python
linktitle: Legenda del grafico
type: docs
url: /it/python-net/chart-legend/
keywords:
- legenda del grafico
- posizione della legenda
- dimensione del font
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Personalizza le legende dei grafici con Aspose.Slides per Python via .NET per ottimizzare le presentazioni PowerPoint e OpenDocument con una formattazione della legenda su misura."
---
## **Panoramica**

Aspose.Slides for Python offre il controllo completo sulle legende dei grafici, consentendoti di rendere le etichette dei dati chiare e pronte per la presentazione. Puoi mostrare o nascondere la legenda, scegliere la sua posizione nella diapositiva e regolare il layout per evitare sovrapposizioni con l’area del grafico. L’API permette di formattare testo e marcatori, perfezionare i margini e lo sfondo, e formattare bordi e riempimenti per corrispondere al tuo tema. Gli sviluppatori possono anche accedere a singole voci della legenda per rinominarle o filtrarle, garantendo che vengano visualizzate solo le serie più rilevanti. Con queste funzionalità, i tuoi grafici rimangono leggibili, coerenti e allineati agli standard di design della presentazione.

## **Posizionamento della Legenda**

Con Aspose.Slides, puoi controllare rapidamente dove appare la legenda del grafico e come si adatta al layout della diapositiva. Scopri come posizionare la legenda con precisione.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Ottieni un riferimento alla diapositiva.
1. Aggiungi un grafico alla diapositiva.
1. Imposta le proprietà della legenda.
1. Salva la presentazione come file PPTX.

Nell’esempio seguente, impostiamo la posizione e le dimensioni della legenda del grafico:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Crea un'istanza della classe Presentation.
with slides.Presentation() as presentation:

    # Ottieni un riferimento alla diapositiva.
    slide = presentation.slides[0]

    # Aggiungi un grafico a colonne raggruppate alla diapositiva.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 300)

    # Imposta le proprietà della legenda.
    chart.legend.x = 80 / chart.width
    chart.legend.y = 20 / chart.height
    chart.legend.width = 100 / chart.width
    chart.legend.height = 100 / chart.height

    # Salva la presentazione su disco.
    presentation.save("legend_positioning.pptx", slides.export.SaveFormat.PPTX)
```

## **Imposta la Dimensione del Font della Legenda**

La legenda di un grafico deve essere leggibile quanto i dati che spiega. Questa sezione mostra come regolare la dimensione del font della legenda per abbinare la tipografia della presentazione e migliorare l’accessibilità.

1. Instanzia la classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Crea un grafico.
1. Imposta la dimensione del font.
1. Salva la presentazione su disco.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.legend.text_format.portion_format.font_height = 20

    presentation.save("font_size.pptx", slides.export.SaveFormat.PPTX)
```

## **Imposta la Dimensione del Font per una Voce della Legenda**

Aspose.Slides consente di perfezionare l’aspetto delle legende dei grafici formattando voci individuali. L’esempio seguente mostra come selezionare una voce specifica della legenda e impostarne le proprietà senza modificare il resto della legenda.

1. Instanzia la classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Crea un grafico.
1. Accedi a una voce della legenda.
1. Imposta le proprietà della voce.
1. Salva la presentazione su disco.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    text_format = chart.legend.entries[1].text_format

    text_format.portion_format.font_bold = slides.NullableBool.TRUE
    text_format.portion_format.font_height = 20
    text_format.portion_format.font_italic = slides.NullableBool.TRUE
    text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.blue

    presentation.save("legend_entry.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Posso abilitare la legenda in modo che il grafico riservi automaticamente spazio per essa invece di sovrapporsi?**

Sì. Usa la modalità non sovrapposta ([overlay](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/legend/overlay/) = `false`); in questo caso, l’area del grafico si ridurrà per ospitare la legenda.

**Posso creare etichette della legenda su più righe?**

Sì. Le etichette lunghe vanno a capo automaticamente quando lo spazio è insufficiente; è possibile forzare interruzioni di riga tramite caratteri di newline nel nome della serie.

**Come faccio a far sì che la legenda segua lo schema di colori del tema della presentazione?**

Non impostare colori/riempimenti/font espliciti per la legenda o il suo testo. In questo modo erediterà dal tema e si aggiornerà correttamente quando il design cambierà.