---
title: PowerPoint-Text in C++ animieren
linktitle: Animierter Text
type: docs
weight: 60
url: /de/cpp/animated-text/
keywords:
- animierter Text
- Textanimation
- animierter Absatz
- Absatzanimation
- Animationseffekt
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Erstellen Sie dynamischen, animierten Text in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für C++ und leicht nachvollziehbaren, optimierten C++-Beispielcode."
---

## **Animations‑Effekte zu Absätzen hinzufügen**

Wir haben die [**AddEffect()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.sequence#a255eb5aaf90861b01980047bc06ead4f) Methode zu den Klassen [**Sequence**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.sequence) und [**ISequence**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.i_sequence) hinzugefügt. Diese Methode ermöglicht es Ihnen, Animations‑Effekte zu einem einzelnen Absatz hinzuzufügen. Dieser Beispielcode zeigt, wie ein Animations‑Effekt zu einem einzelnen Absatz hinzugefügt wird:
```cpp
String dataDir = GetDataPath();
auto presentation = System::MakeObject<Presentation>(dataDir + u"Presentation1.pptx");

// Absatz auswählen, um Effekt hinzuzufügen
auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraphs()->idx_get(0);

// Fly-Animationseffekt zum ausgewählten Absatz hinzufügen
auto sequence = presentation->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();
auto effect = sequence->AddEffect(paragraph, EffectType::Fly, EffectSubtype::Left, EffectTriggerType::OnClick);

presentation->Save(dataDir + u"AnimationEffectinParagraph.pptx", SaveFormat::Pptx);
```


## **Animations‑Effekte für Absätze abrufen**

Sie möchten möglicherweise die zu einem Absatz hinzugefügten Animations‑Effekte ermitteln, zum Beispiel, wenn Sie die Effekte eines Absatzes erhalten wollen, um diese auf einen anderen Absatz oder ein Shape anzuwenden.  
Aspose.Slides für C++ ermöglicht es Ihnen, alle auf Absätze in einem Textfeld (Shape) angewendeten Animations‑Effekte abzurufen. Dieser Beispielcode zeigt, wie Sie die Animations‑Effekte in einem Absatz erhalten:
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

**Wie unterscheiden sich Textanimationen von Folienübergängen und können sie kombiniert werden?**

Textanimationen steuern das Verhalten von Objekten über die Zeit auf einer Folie, während [transitions](/slides/de/cpp/slide-transition/) festlegen, wie Folien wechseln. Sie sind unabhängig und können zusammen verwendet werden; die Wiedergabereihenfolge wird durch die Animations‑Zeitleiste und die Übergangseinstellungen bestimmt.

**Werden Textanimationen beim Exportieren in PDF oder Bilder beibehalten?**

Nein. PDF‑ und Rasterbilder sind statisch, sodass Sie nur einen einzelnen Zustand der Folie ohne Bewegung sehen. Um die Bewegung zu erhalten, verwenden Sie den Export als [video](/slides/de/cpp/convert-powerpoint-to-video/) oder [HTML](/slides/de/cpp/export-to-html5/).

**Funktionieren Textanimationen in Layouts und im Folienmaster?**

Auf Layout‑/Master‑Objekte angewendete Effekte werden von den Folien geerbt, jedoch hängen ihr Timing und ihre Interaktion mit Folien‑Animationen von der endgültigen Sequenz auf der Folie ab.