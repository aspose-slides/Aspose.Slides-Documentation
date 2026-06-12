---
title: Animare il testo PowerPoint in C++
linktitle: Testo animato
type: docs
weight: 60
url: /it/cpp/animated-text/
keywords:
- testo animato
- animazione del testo
- paragrafo animato
- animazione del paragrafo
- effetto di animazione
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Crea testo animato dinamico in presentazioni PowerPoint e OpenDocument utilizzando Aspose.Slides per C++, con esempi di codice C++ facili da seguire e ottimizzati."
---
## **Panoramica**

Questo articolo spiega come lavorare con il testo animato in Aspose.Slides applicando effetti di animazione a singoli paragrafi e recuperando gli effetti già assegnati ai paragrafi in un riquadro di testo. Si concentra sui metodi API utilizzati per aggiungere animazioni a livello di paragrafo e per ispezionare gli effetti di animazione dei paragrafi esistenti in una presentazione.

## **Aggiungere effetti di animazione ai paragrafi**

Abbiamo aggiunto il metodo [**AddEffect()**](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.animation.sequence#a255eb5aaf90861b01980047bc06ead4f) alle classi [**Sequence**](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.animation.sequence) e [**ISequence**](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.animation.i_sequence). Questo metodo consente di aggiungere effetti di animazione a un singolo paragrafo. Questo esempio di codice mostra come aggiungere un effetto di animazione a un singolo paragrafo:

``` cpp
String dataDir = GetDataPath();
auto presentation = System::MakeObject<Presentation>(dataDir + u"Presentation1.pptx");

// seleziona il paragrafo a cui aggiungere l'effetto
auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraphs()->idx_get(0);

// aggiungi l'effetto di animazione Fly al paragrafo selezionato
auto sequence = presentation->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();
auto effect = sequence->AddEffect(paragraph, EffectType::Fly, EffectSubtype::Left, EffectTriggerType::OnClick);

presentation->Save(dataDir + u"AnimationEffectinParagraph.pptx", SaveFormat::Pptx);
```

## **Recuperare effetti di animazione per i paragrafi**

Potresti decidere di scoprire gli effetti di animazione aggiunti a un paragrafo; ad esempio, in uno scenario potresti voler ottenere gli effetti di animazione di un paragrafo perché intendi applicarli a un altro paragrafo o a una forma.

Aspose.Slides per C++ consente di recuperare tutti gli effetti di animazione applicati ai paragrafi contenuti in un riquadro di testo (forma). Questo esempio di codice mostra come ottenere gli effetti di animazione in un paragrafo:

``` cpp
String dataDir = GetDataPath();
auto pres = System::MakeObject<Presentation>(dataDir + u"Test.pptx");

auto sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();
auto autoShape = System::ExplicitCast<IAutoShape>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(1));

for (auto paragraph : autoShape->get_TextFrame()->get_Paragraphs())
{
	auto effects = sequence->GetEffectsByParagraph(paragraph);

	if (effects->get_Length() > 0)
	{
		Console::WriteLine(String(u"Paragraph \"") + paragraph->get_Text() + u"\" has " + ObjectExt::ToString(effects[0]->get_Type()) + u" effect.");
	}
}
```

## **FAQ**

**Come si differenziano le animazioni di testo dalle transizioni delle diapositive e possono essere combinate?**

Le animazioni di testo controllano il comportamento degli oggetti nel tempo su una diapositiva, mentre le [transizioni](/slides/it/cpp/slide-transition/) controllano come le diapositive cambiano. Sono indipendenti e possono essere usate insieme; l'ordine di riproduzione è determinato dalla timeline dell'animazione e dalle impostazioni di transizione.

**Le animazioni di testo vengono preservate durante l'esportazione in PDF o immagini?**

No. PDF e immagini raster sono statici, quindi vedrai un unico stato della diapositiva senza movimento. Per mantenere il movimento, usa l'esportazione in [video](/slides/it/cpp/convert-powerpoint-to-video/) o in [HTML](/slides/it/cpp/export-to-html5/).

**Le animazioni di testo funzionano nei layout e nel master della diapositiva?**

Gli effetti applicati a oggetti di layout/master sono ereditati dalle diapositive, ma la loro temporizzazione e interazione con le animazioni a livello di diapositiva dipendono dalla sequenza finale sulla diapositiva.