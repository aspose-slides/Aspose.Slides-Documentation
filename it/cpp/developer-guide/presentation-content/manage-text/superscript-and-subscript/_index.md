---
title: Gestire apice e pedice nelle presentazioni usando C++
linktitle: Apice e pedice
type: docs
weight: 80
url: /it/cpp/superscript-and-subscript/
keywords:
- apice
- pedice
- aggiungi apice
- aggiungi pedice
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Domina l'apice e il pedice in Aspose.Slides per C++ e migliora le tue presentazioni con una formattazione del testo professionale per il massimo impatto."
---
## **Panoramica**

Aspose.Slides fornisce funzionalità per integrare testo in apice e pedice nelle presentazioni PowerPoint (PPT, PPTX) e OpenDocument (ODP). Che tu debba evidenziare formule chimiche, equazioni matematiche o annotare contenuti con note a piè di pagina, queste opzioni di formattazione specializzate aiutano a mantenere chiarezza e precisione. In questo articolo imparerai come applicare senza problemi gli stili di apice e pedice e garantire risultati professionali in ogni diapositiva.

## **Gestire il testo in apice e pedice**

È possibile aggiungere testo in apice e pedice all'interno di qualsiasi porzione di paragrafo. Per aggiungere testo in apice o pedice nel riquadro di testo di Aspose.Slides è necessario utilizzare le proprietà **Escapement** della classe PortionFormat.

Questa proprietà restituisce o imposta il testo in apice o pedice (valore da -100% (pedice) a 100% (apice). Ad esempio :

- Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
- Ottenere il riferimento di una diapositiva utilizzando il suo indice.
- Aggiungere un IAutoShape di tipo Rettangolo alla diapositiva.
- Accedere al ITextFrame associato al IAutoShape.
- Cancellare i paragrafi esistenti
- Creare un nuovo oggetto paragrafo per contenere testo in apice e aggiungerlo alla raccolta IParagraphs del ITextFrame.
- Creare un nuovo oggetto porzione
- Impostare la proprietà Escapement per la porzione tra 0 e 100 per aggiungere apice. (0 significa nessun apice)
- Impostare del testo per la Porzione e poi aggiungerlo alla raccolta di porzioni del paragrafo.
- Creare un nuovo oggetto paragrafo per contenere testo in pedice e aggiungerlo alla raccolta IParagraphs del ITextFrame.
- Creare un nuovo oggetto porzione
- Impostare la proprietà Escapement per la porzione tra 0 e -100 per aggiungere pedice. (0 significa nessun pedice)
- Impostare del testo per la Porzione e poi aggiungerlo alla raccolta di porzioni del paragrafo.
- Salvare la presentazione come file PPTX.

L'implementazione dei passaggi precedenti è mostrata di seguito.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddingSuperscriptAndSubscriptTextInTextFrame-AddingSuperscriptAndSubscriptTextInTextFrame.cpp" >}}

## **FAQ**

**La formattazione di apice e pedice verrà preservata durante l'esportazione in PDF o altri formati?**

Sì, Aspose.Slides conserva correttamente la formattazione di apice e pedice quando esporta le presentazioni in PDF, PPT/PPTX, immagini e altri formati supportati. La formattazione specializzata rimane intatta in tutti i file di output.

**Apice e pedice possono essere combinati con altri stili di formattazione come grassetto o corsivo?**

Sì, Aspose.Slides consente di mescolare vari stili di testo all'interno di una singola porzione di testo. È possibile abilitare grassetto, corsivo, sottolineatura e applicare simultaneamente apice o pedice configurando le proprietà corrispondenti in [PortionFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/portionformat/).

**La formattazione di apice e pedice funziona per il testo all'interno di tabelle, grafici o SmartArt?**

Sì, Aspose.Slides supporta la formattazione nella maggior parte degli oggetti, incluse tabelle ed elementi di grafico. Quando si lavora con SmartArt, è necessario accedere agli elementi appropriati (come [SmartArtNode](https://reference.aspose.com/slides/it/cpp/aspose.slides.smartart/smartartnode/)) e ai loro contenitori di testo, quindi configurare le proprietà di [PortionFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/portionformat/) in modo simile.