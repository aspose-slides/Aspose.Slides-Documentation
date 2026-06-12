---
title: Configura la sostituzione dei font nelle presentazioni in .NET
linktitle: Sostituzione dei font
type: docs
weight: 70
url: /it/net/font-substitution/
keywords:
- font
- sostituzione font
- sostituzione dei font
- sostituire font
- sostituzione del font
- regola di sostituzione
- regola di sostituzione
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Abilita una sostituzione ottimale dei font in Aspose.Slides per .NET durante la conversione di presentazioni PowerPoint e OpenDocument in altri formati di file."
---
## **Panoramica**

La sostituzione dei caratteri consente a Aspose.Slides di utilizzare un altro font quando il carattere originale della presentazione non è disponibile durante il rendering o la conversione. È possibile verificare quali caratteri sono stati sostituiti utilizzando il metodo `GetSubstitutions` dell’interfaccia `IFontsManager`.

Aspose.Slides consente inoltre di definire regole di sostituzione dei caratteri. Ad esempio, è possibile specificare che un carattere inaccessibile debba essere sostituito con un altro carattere disponibile e quindi applicare tali regole tramite il gestore dei caratteri della presentazione.

## **Ottieni le sostituzioni dei caratteri**

Per consentire di scoprire i caratteri della presentazione che vengono sostituiti durante il processo di rendering, Aspose.Slides fornisce il metodo [GetSubstitution](https://reference.aspose.com/slides/it/net/aspose.slides/fontsmanager/getsubstitutions/) dell’interfaccia [IFontsManager](https://reference.aspose.com/slides/it/net/aspose.slides/ifontsmanager/).

Il codice C# mostra come ottenere tutte le sostituzioni di caratteri eseguite quando una presentazione viene renderizzata:
```c#
using (Presentation pres = new Presentation(@"Presentation.pptx"))
{
    foreach (var fontSubstitution in pres.FontsManager.GetSubstitutions())
    {
        Console.WriteLine("{0} -> {1}", fontSubstitution.OriginalFontName, fontSubstitution.SubstitutedFontName);
    }
}
```

## **Definisci regole di sostituzione dei caratteri**

Aspose.Slides permette di impostare regole per i caratteri che determinano cosa fare in determinate condizioni (ad esempio, quando un carattere non può essere accesso) in questo modo:

1. Caricare la presentazione pertinente.  
2. Caricare il carattere che sarà sostituito.  
3. Caricare il nuovo carattere.  
4. Aggiungere una regola per la sostituzione.  
5. Aggiungere la regola alla raccolta di regole di sostituzione dei caratteri della presentazione.  
6. Generare l’immagine della diapositiva per osservare l’effetto.

Questo codice C# dimostra il processo di sostituzione dei caratteri:

```c#
// Carica una presentazione
Presentation presentation = new Presentation("Fonts.pptx");

// Carica il font sorgente che sarà sostituito
IFontData sourceFont = new FontData("SomeRareFont");

// Carica il nuovo font
IFontData destFont = new FontData("Arial");

// Aggiunge una regola di font per la sostituzione del font
IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);

// Aggiunge la regola alla collezione delle regole di sostituzione dei font
IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
fontSubstRuleCollection.Add(fontSubstRule);

// Aggiunge la collezione di regole di font all'elenco delle regole
presentation.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

using (IImage image = presentation.Slides[0].GetImage(1f, 1f))
{
    // Salva l'immagine su disco nel formato JPEG
    image.Save("Thumbnail_out.jpg", ImageFormat.Jpeg);
}
```

{{%  alert title="NOTE"  color="warning"   %}} 

Potrebbe interessarle [**Font Replacement**](/slides/it/net/font-replacement/). 

{{% /alert %}}

## **Limitazioni per i caratteri delle equazioni matematiche**

Le regole di sostituzione dei caratteri partecipano al normale processo di selezione dei caratteri utilizzato durante il rendering e la conversione. Sono adatte a scenari di testo normale in cui Aspose.Slides può sostituire un carattere inaccessibile con un altro carattere disponibile secondo la regola configurata.

Tuttavia, le equazioni matematiche di Office presentano una limitazione importante. Se un’equazione è stata creata con **Cambria Math**, Aspose.Slides potrebbe comunque richiedere il carattere originale **Cambria Math** per calcolare e renderizzare correttamente il layout dell’equazione. Per questo motivo, la sostituzione di **Cambria Math** con un altro carattere matematico, come **STIX Two Math**, non è supportata per il rendering delle equazioni e può ancora generare un’eccezione che indica la necessità di **Cambria Math**.

Per convertire correttamente tali presentazioni, assicurarsi che **Cambria Math** sia disponibile per Aspose.Slides a runtime. È possibile installare il carattere nel sistema operativo o fornirlo come [font esterno](/slides/it/net/custom-font/) in modo che partecipi al normale processo di selezione dei caratteri durante il rendering e la conversione.

Questa limitazione è specifica per il rendering delle equazioni. Le regole di sostituzione dei caratteri standard descritte sopra continuano a valere per il testo normale della presentazione quando il carattere originale è inaccessibile.

## **FAQ**

**Qual è la differenza tra sostituzione dei caratteri e sostituzione dei font?**

[Replacement](/slides/it/net/font-replacement/) è una sovrascrittura forzata di un carattere con un altro su tutta la presentazione. La sostituzione è una regola che si attiva in una condizione specifica, ad esempio quando il carattere originale non è disponibile, e quindi viene utilizzato un carattere di fallback designato.

**Quando vengono applicate esattamente le regole di sostituzione?**

Le regole partecipano alla normale sequenza di [selezione dei caratteri](/slides/it/net/font-selection-sequence/) valutata durante il caricamento, il rendering e la conversione; se il carattere scelto non è disponibile, viene applicata la sostituzione o la sostituzione forzata.

**Qual è il comportamento predefinito se né la sostituzione né la sostituzione forzata sono configurate e il carattere manca nel sistema?**

La libreria cercherà di scegliere il carattere di sistema più vicino disponibile, simile a quello che farebbe PowerPoint.

**Posso aggiungere font esterni personalizzati a runtime per evitare la sostituzione?**

Sì. È possibile [aggiungere font esterni](/slides/it/net/custom-font/) a runtime affinché la libreria li consideri per la selezione e il rendering, anche per le conversioni successive.

**Aspose distribuisce font con la libreria?**

No. Aspose non distribuisce font a pagamento o gratuiti; è responsabilità dell’utente aggiungere e utilizzare i font.

**Ci sono differenze nel comportamento della sostituzione su Windows, Linux e macOS?**

Sì. La scoperta dei font parte dalle directory dei font del sistema operativo. L’insieme di font disponibili per impostazione predefinita e i percorsi di ricerca differiscono tra le piattaforme, influenzando la disponibilità e la necessità di sostituzione.

**Come preparare l’ambiente per ridurre le sostituzioni inattese durante le conversioni batch?**

Sincronizzare il set di font tra macchine o contenitori, [aggiungere i font esterni](/slides/it/net/custom-font/) richiesti per i documenti di output e [incorporare i font](/slides/it/net/embedded-font/) nelle presentazioni quando possibile, in modo che i caratteri scelti siano disponibili durante il rendering.