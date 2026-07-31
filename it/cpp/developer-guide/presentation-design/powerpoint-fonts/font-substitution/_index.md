---
title: Configura la sostituzione dei font nelle presentazioni usando C++
linktitle: Sostituzione dei Font
type: docs
weight: 70
url: /it/cpp/font-substitution/
keywords:
- font
- font sostitutivo
- sostituzione del font
- sostituire il font
- sostituzione del font
- regola di sostituzione
- regola di sostituzione
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Abilita la sostituzione ottimale dei font in Aspose.Slides per C++ durante la conversione di presentazioni PowerPoint e OpenDocument in altri formati di file."
---
## **Panoramica**

La sostituzione dei font consente ad Aspose.Slides di utilizzare un altro font quando il font originale della presentazione non è disponibile durante il rendering o la conversione. È possibile verificare quali font sono stati sostituiti utilizzando il metodo `GetSubstitutions` dell'interfaccia `IFontsManager`.

Aspose.Slides consente inoltre di definire regole di sostituzione dei font. Ad esempio, è possibile specificare che un font non accessibile venga sostituito con un altro font disponibile e quindi applicare tali regole attraverso il gestore dei font della presentazione.

## **Imposta le regole di sostituzione dei font**

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

// Aggiunge la regola alla collezione delle regole di sostituzione dei font
SharedPtr<FontSubstRuleCollection> fontSubstRuleCollection = MakeObject<FontSubstRuleCollection>();
fontSubstRuleCollection->Add(fontSubstRule);

// Aggiunge la collezione di regole di font all'elenco delle regole
pres->get_FontsManager()->set_FontSubstRuleList ( fontSubstRuleCollection);


// Salva il PPTX su disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert title="NOTE"  color="warning"   %}} 
Potresti voler vedere [**Sostituzione dei Font**](/slides/it/cpp/font-replacement/). 
{{% /alert %}}

## **Limitazioni per i font delle equazioni matematiche**

Le regole di sostituzione dei font partecipano al processo standard di selezione dei font utilizzato durante il rendering e la conversione. Sono adatte a scenari di testo normale in cui Aspose.Slides può sostituire un font non accessibile con un altro font disponibile secondo la regola configurata.

Tuttavia, le equazioni matematiche di Office presentano una limitazione importante. Se un'equazione è stata creata con **Cambria Math**, Aspose.Slides potrebbe comunque richiedere il font originale **Cambria Math** per calcolare e renderizzare correttamente il layout dell'equazione. Per questo motivo, sostituire **Cambria Math** con un altro font matematico, come **STIX Two Math**, non è supportato per il rendering delle equazioni e potrebbe comunque generare un'eccezione che indica che **Cambria Math** è necessario.

Per convertire correttamente tali presentazioni, assicurati che **Cambria Math** sia disponibile per Aspose.Slides durante l'esecuzione. Puoi installare il font nel sistema operativo o fornirlo come [font esterno](/slides/it/cpp/custom-font/) in modo che possa partecipare al normale processo di selezione dei font durante il rendering e la conversione.

Questa limitazione è specifica per il rendering delle equazioni. Le regole standard di sostituzione dei font descritte sopra si applicano comunque al testo normale della presentazione quando il font originale non è accessibile.

## **FAQ**

**Qual è la differenza tra sostituzione dei font e sostituzione condizionale dei font?**

[Sostituzione](/slides/it/cpp/font-replacement/) è una sovrascrittura forzata di un font con un altro in tutta la presentazione. La sostituzione è una regola che si attiva in una condizione specifica, ad esempio quando il font originale non è disponibile, e utilizza un font di riserva designato.

**Quando vengono applicate esattamente le regole di sostituzione?**

Le regole partecipano alla sequenza standard di [selezione dei font](/slides/it/cpp/font-selection-sequence/) che viene valutata durante il caricamento, il rendering e la conversione; se il font selezionato non è disponibile, viene applicata la sostituzione o la sovrascrittura.

**Qual è il comportamento predefinito se né la sostituzione né la sostituzione condizionale sono configurate e il font manca nel sistema?**

La libreria cercherà di selezionare il font di sistema più simile disponibile, simile a quanto farebbe PowerPoint.

**Posso allegare font esterni personalizzati a runtime per evitare la sostituzione?**

Sì. È possibile [aggiungere font esterni](/slides/it/cpp/custom-font/) a runtime affinché la libreria li consideri per la selezione e il rendering, anche per le conversioni successive.

**Aspose distribuisce font con la libreria?**

No. Aspose non distribuisce font a pagamento o gratuiti; aggiungi e utilizzi i font a tua discrezione e responsabilità.

**Ci sono differenze nel comportamento di sostituzione su Windows, Linux e macOS?**

Sì. La scoperta dei font parte dalle directory dei font del sistema operativo. L'insieme dei font disponibili di default e i percorsi di ricerca differiscono tra le piattaforme, influenzando la disponibilità e la necessità di sostituzione.

**Come devo preparare l'ambiente per ridurre al minimo le sostituzioni inattese durante le conversioni batch?**

Sincronizza il set di font tra macchine o container, [aggiungi i font esterni](/slides/it/cpp/custom-font/) richiesti per i documenti di output e [incorpora i font](/slides/it/cpp/embedded-font/) nelle presentazioni, quando possibile, in modo che i font scelti siano disponibili durante il rendering.