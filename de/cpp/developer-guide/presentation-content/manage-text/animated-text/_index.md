---
title: Animierter Text
type: docs
weight: 60
url: /cpp/animierter-text/
keywords: "Animierter Text in PowerPoint"
description: "Animierter Text in PowerPoint-Präsentation mit Aspose.Slides"
---

## Hinzufügen von Animationseffekten zu Absätzen

Wir haben die [**AddEffect()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.sequence#a255eb5aaf90861b01980047bc06ead4f) Methode zu den [**Sequence**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.sequence) und [**ISequence**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.i_sequence) Klassen hinzugefügt. Mit dieser Methode können Sie Animationseffekte zu einem einzelnen Absatz hinzufügen. Dieser Beispielcode zeigt Ihnen, wie Sie einen Animationseffekt zu einem einzelnen Absatz hinzufügen:

``` cpp
String dataDir = GetDataPath();
auto presentation = System::MakeObject<Presentation>(dataDir + u"Präsentation1.pptx");

// Absatz auswählen, um Effekt hinzuzufügen
auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraphs()->idx_get(0);

// Fly-Animationseffekt zum ausgewählten Absatz hinzufügen
auto sequence = presentation->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();
auto effect = sequence->AddEffect(paragraph, EffectType::Fly, EffectSubtype::Left, EffectTriggerType::OnClick);

presentation->Save(dataDir + u"AnimationsEffektImAbsatz.pptx", SaveFormat::Pptx);
```


## Abrufen der Animationseffekte in Absätzen

Sie können entscheiden, die Animationseffekte, die einem Absatz hinzugefügt wurden, herauszufinden; zum Beispiel, in einem Szenario möchten Sie die Animationseffekte in einem Absatz abrufen, weil Sie planen, diese Effekte auf einen anderen Absatz oder eine Form anzuwenden.

Aspose.Slides für C++ ermöglicht Ihnen, alle Animationseffekte abzurufen, die auf Absätze angewendet wurden, die in einem Textfeld (Form) enthalten sind. Dieser Beispielcode zeigt Ihnen, wie Sie die Animationseffekte in einem Absatz abrufen:

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
		Console::WriteLine(String(u"Absatz \"") + paragraph->get_Text() + u"\" hat " + ObjectExt::ToString(effects[0]->get_Type()) + u" Effekt.");
	}
}
```