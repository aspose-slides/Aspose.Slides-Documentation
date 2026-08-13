---
title: Esporta equazioni matematiche dalle presentazioni in C++
linktitle: Esporta equazioni
type: docs
weight: 30
url: /it/cpp/exporting-math-equations/
keywords:
- esporta equazioni matematiche
- esporta equazioni in LaTeX
- PowerPoint in LaTeX
- MathML
- LaTeX
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Esporta equazioni matematiche dalle presentazioni PowerPoint in LaTeX o MathML direttamente con Aspose.Slides per C++."
---
## **Introduzione**

Aspose.Slides per C++ consente di esportare equazioni matematiche dalle presentazioni. Ad esempio, potrebbe essere necessario estrarre le equazioni matematiche dalle diapositive (da una presentazione specifica) e usarle in un altro programma o piattaforma. 

{{% alert color="info" %}} 

È possibile esportare le equazioni direttamente in LaTeX o in MathML, un standard popolare per contenuti matematici utilizzato sul web e in molte applicazioni.

{{% /alert %}}

## **Esporta equazioni matematiche in LaTeX**

Aspose.Slides può convertire un’equazione matematica di PowerPoint direttamente in LaTeX; non è necessario un file MathML intermedio né un convertitore esterno. Un’equazione matematica è memorizzata in un riquadro di testo come un [IMathPortion](https://reference.aspose.com/slides/it/cpp/aspose.slides.mathtext/imathportion/). Utilizza [IMathPortion::get_MathParagraph](https://reference.aspose.com/slides/it/cpp/aspose.slides.mathtext/imathportion/get_mathparagraph/) per ottenere un [IMathParagraph](https://reference.aspose.com/slides/it/cpp/aspose.slides.mathtext/imathparagraph/), quindi chiama [IMathParagraph::ToLatex](https://reference.aspose.com/slides/it/cpp/aspose.slides.mathtext/imathparagraph/tolatex/). Il metodo restituisce una stringa che è possibile salvare, visualizzare, inviare a un’altra applicazione o elaborare ulteriormente.

L’esempio seguente analizza ogni riquadro di testo su ogni diapositiva, trova tutte le parti matematiche e scrive ciascuna equazione in un file `.tex` separato:

```cpp
auto presentation = MakeObject<Presentation>(u"equations.pptx");

auto slideCount = presentation->get_Slides()->get_Count();
for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);
    int slideNumber = slideIndex + 1;
    int equationNumber = 1;
    auto textFrames = SlideUtil::GetAllTextBoxes(slide);

    for (const auto&& textFrame : textFrames)
    {
        for (const auto&& paragraph : textFrame->get_Paragraphs())
        {
            for (const auto&& portion : paragraph->get_Portions())
            {
                auto mathPortion = System::AsCast<IMathPortion>(portion);
                if (mathPortion == nullptr)
                    continue;

                auto mathParagraph = mathPortion->get_MathParagraph();
                auto latexPath = String::Format(u"slide_{0}_equation_{1}.tex", slideNumber, equationNumber);

                auto latexText = mathParagraph->ToLatex();
                File::WriteAllText(latexPath, latexText);
                equationNumber++;
            }
        }
    }
}

presentation->Dispose();
```

[SlideUtil::GetAllTextBoxes](https://reference.aspose.com/slides/it/cpp/aspose.slides.util/slideutil/getalltextboxes/) restituisce tutti i riquadri di testo trovati su una diapositiva. Il controllo del tipo [IMathPortion](https://reference.aspose.com/slides/it/cpp/aspose.slides.mathtext/imathportion/) separa le vere equazioni modificabili dal testo ordinario e dalle immagini.

I motori LaTeX e i modelli di documento non supportano tutti gli stessi comandi, pacchetti o caratteri Unicode. Verifica la stringa restituita con il motore LaTeX usato dalla tua applicazione. Se un simbolo o un elemento Office Math non ha una rappresentazione adeguata in quell’ambiente, sostituiscilo nella stringa restituita con un comando specifico del progetto oppure ignora l’equazione e registra il problema per una revisione.

## **Salva equazioni matematiche come MathML**

Mentre gli esseri umani scrivono facilmente il codice per alcuni formati di equazioni come LaTeX, faticano a scrivere il codice per MathML perché quest’ultimo è pensato per essere generato automaticamente dalle applicazioni. I programmi leggono e analizzano MathML facilmente poiché il suo codice è in XML, quindi MathML è comunemente usato come formato di output e stampa in molti settori. 

Questo codice di esempio mostra come esportare un’equazione matematica da una presentazione in MathML:

``` cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/MathText/IMathBlock.h>
#include <DOM/MathText/IMathParagraph.h>
#include <DOM/MathText/IMathPortion.h>
#include <DOM/MathText/IMathSuperscriptElement.h>
#include <DOM/MathText/MathematicalText.h>
#include <DOM/Presentation.h>
#include <system/io/file_mode.h>
#include <system/io/file_stream.h>
#include <system/io/stream.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::MathText;
using namespace System;
using namespace System::IO;

SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

auto autoShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddMathShape(0.0f, 0.0f, 500.0f, 50.0f);
auto mathPortion = System::ExplicitCast<IMathPortion>(autoShape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0));
auto mathParagraph = mathPortion->get_MathParagraph();

mathParagraph->Add(System::MakeObject<MathematicalText>(u"a")
        - >SetSuperscript(u"2")
        - >Join(u"+")
        - >Join(System::MakeObject<MathematicalText>(u"b")
                - >SetSuperscript(u"2"))
        - >Join(u"=")
        - >Join(System::MakeObject<MathematicalText>(u"c")
                - >SetSuperscript(u"2")));

SharedPtr<Stream> stream = System::MakeObject<FileStream>(u"mathml.xml", FileMode::Create);

mathParagraph->WriteAsMathMl(stream);
```

## **FAQ**

**Cosa viene esportato esattamente in MathML—un paragrafo o un blocco di formula individuale?**

È possibile esportare sia un intero paragrafo matematico ([MathParagraph](https://reference.aspose.com/slides/it/cpp/aspose.slides.mathtext/mathparagraph/)) sia un blocco individuale ([MathBlock](https://reference.aspose.com/slides/it/cpp/aspose.slides.mathtext/mathblock/)) in MathML. Entrambi i tipi forniscono un metodo per scrivere in MathML.

**Come posso capire se un oggetto su una diapositiva è una formula matematica piuttosto che testo normale o un’immagine?**

Una formula risiede in un [MathPortion](https://reference.aspose.com/slides/it/cpp/aspose.slides.mathtext/mathportion/) e possiede un [MathParagraph](https://reference.aspose.com/slides/it/cpp/aspose.slides.mathtext/mathparagraph/). Le immagini e le porzioni di testo normali senza un [MathParagraph](https://reference.aspose.com/slides/it/cpp/aspose.slides.mathtext/mathparagraph/) non sono formule esportabili.

**Da dove proviene il MathML in una presentazione—è specifico di PowerPoint o è uno standard?**

L’esportazione restituisce MathML standard (XML). Aspose utilizza Presentation MathML—il sottoinsieme di presentazione dello standard—che è ampiamente usato in applicazioni e sul web.

**È supportata l’esportazione di formule all’interno di tabelle, SmartArt, gruppi, ecc.?**

Sì, se tali oggetti contengono porzioni di testo con un [MathParagraph](https://reference.aspose.com/slides/it/cpp/aspose.slides.mathtext/mathparagraph/) (cioè formule PowerPoint genuine), vengono esportati. Se una formula è incorporata come immagine, non lo è.

**L’esportazione in MathML modifica la presentazione originale?**

No. La scrittura di MathML è una serializzazione del contenuto della formula; non modifica il file della presentazione.