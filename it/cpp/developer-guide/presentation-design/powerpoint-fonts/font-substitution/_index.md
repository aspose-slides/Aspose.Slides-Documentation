---
title: Configurare la sostituzione dei font nelle presentazioni usando C++
linktitle: Sostituzione dei font
type: docs
weight: 70
url: /it/cpp/font-substitution/
keywords:
- font
- sostituzione del font
- sostituzione dei font
- sostituzione del font
- sostituzione del font
- regola di sostituzione
- regola di sostituzione
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Abilita la sostituzione ottimale dei font in Aspose.Slides per C++ quando si convertono presentazioni PowerPoint e OpenDocument in altri formati di file."
---
## **Panoramica**

La sostituzione dei font consente ad Aspose.Slides di utilizzare un altro font quando il font originale della presentazione non è disponibile durante il rendering o la conversione. È possibile verificare quali font sono stati sostituiti utilizzando il metodo `GetSubstitutions` dell'interfaccia `IFontsManager`.

Aspose.Slides consente anche di definire regole di sostituzione dei font. Ad esempio, è possibile specificare che un font non accessibile debba essere sostituito con un altro font disponibile e quindi applicare tali regole tramite il gestore dei font della presentazione.

## **Imposta regole di sostituzione dei font**

Aspose.Slides consente di impostare regole per i font che determinano cosa fare in determinate condizioni (ad esempio, quando un font non può essere accessibile) in questo modo:

1. Carica la presentazione pertinente.
2. Carica il font che verrà sostituito.
3. Carica il nuovo font.
4. Aggiungi una regola per la sostituzione.
5. Aggiungi la regola alla collezione delle regole di sostituzione dei font della presentazione.
6. Genera l'immagine della diapositiva per osservare l'effetto.

Questo codice C++ dimostra il processo di sostituzione dei font:

```c++
// Il percorso della cartella dei documenti.
const String outPath = u"../out/RuleBasedFontsReplacement_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";


// Carica una presentazione
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// Definisce il font da sostituire e il nuovo font
SharedPtr<IFontData> sourceFont = MakeObject<FontData>(u"SomeRareFont");
SharedPtr<IFontData> destFont = MakeObject<FontData>(u"Arial");
	
// Aggiunge una regola di font per la sostituzione del font
SharedPtr<FontSubstRule> fontSubstRule = MakeObject<FontSubstRule>(sourceFont, destFont, FontSubstCondition::WhenInaccessible);

// Aggiunge la regola alla raccolta delle regole di sostituzione dei font
SharedPtr<FontSubstRuleCollection> fontSubstRuleCollection = MakeObject<FontSubstRuleCollection>();
fontSubstRuleCollection->Add(fontSubstRule);

// Aggiunge la raccolta delle regole di font all'elenco delle regole
pres->get_FontsManager()->set_FontSubstRuleList ( fontSubstRuleCollection);


// Salva il PPTX su disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert title="NOTE"  color="warning"   %}} 
Potresti voler vedere [**Sostituzione dei font**](/slides/it/cpp/font-replacement/). 
{{% /alert %}}

## **Limitazioni per i font delle equazioni matematiche**

Le regole di sostituzione dei font partecipano al normale processo di selezione dei font utilizzato durante il rendering e la conversione. Sono adatte per scenari di testo comune in cui Aspose.Slides può sostituire un font non accessibile con un altro font disponibile secondo la regola configurata.

Tuttavia, le equazioni matematiche di Office hanno una limitazione importante. Se un'equazione è stata creata con **Cambria Math**, Aspose.Slides potrebbe comunque richiedere il font originale **Cambria Math** per calcolare e renderizzare correttamente il layout dell'equazione. Per questo motivo, la sostituzione di **Cambria Math** con un altro font matematico, come **STIX Two Math**, non è supportata per il rendering delle equazioni e potrebbe comunque generare un'eccezione che indica che è necessario **Cambria Math**.

Per convertire correttamente queste presentazioni, assicurati che **Cambria Math** sia disponibile per Aspose.Slides a runtime. Puoi installare il font nel sistema operativo o fornirlo come [font esterno](/slides/it/cpp/custom-font/) in modo che possa partecipare al normale processo di selezione dei font durante il rendering e la conversione.

Questa limitazione è specifica per il rendering delle equazioni. Le regole standard di sostituzione dei font descritte sopra continuano a essere applicate al testo normale della presentazione quando il font originale non è accessibile.

## **FAQ**

**Qual è la differenza tra sostituzione forzata del font e sostituzione del font?**  
[Replacement](/slides/it/cpp/font-replacement/) è una sovrascrittura forzata di un font con un altro su tutta la presentazione. La sostituzione è una regola che si attiva in una condizione specifica, ad esempio quando il font originale non è disponibile, e quindi viene utilizzato un font di riserva designato.

**Quando vengono esattamente applicate le regole di sostituzione?**  
Le regole partecipano alla sequenza standard di [selezione del font](/slides/it/cpp/font-selection-sequence/) valutata durante il caricamento, il rendering e la conversione; se il font scelto non è disponibile, viene applicata la sostituzione o la sostituzione.

**Qual è il comportamento predefinito se né la sostituzione né la sostituzione sono configurate e il font non è presente nel sistema?**  
La libreria tenterà di scegliere il font di sistema più vicino disponibile, in modo simile a come si comporterebbe PowerPoint.

**Posso aggiungere font esterni personalizzati a runtime per evitare la sostituzione?**  
Sì. È possibile [aggiungere font esterni](/slides/it/cpp/custom-font/) a runtime in modo che la libreria li consideri per la selezione e il rendering, anche per le conversioni successive.

**Aspose distribuisce dei font con la libreria?**  
No. Aspose non distribuisce font a pagamento o gratuiti; aggiungi e utilizzi i font a tua discrezione e responsabilità.

**Ci sono differenze nel comportamento di sostituzione su Windows, Linux e macOS?**  
Sì. La scoperta dei font parte dalle directory dei font del sistema operativo. Il set di font disponibili di default e i percorsi di ricerca differiscono tra le piattaforme, influenzando la disponibilità e la necessità di sostituzione.

**Come devo preparare l'ambiente per ridurre al minimo le sostituzioni inattese durante le conversioni batch?**  
Sincronizza il set di font tra macchine o contenitori, [aggiungi i font esterni](/slides/it/cpp/custom-font/) necessari per i documenti di output e [incorpora i font](/slides/it/cpp/embedded-font/) nelle presentazioni quando possibile, così i font scelti saranno disponibili durante il rendering.