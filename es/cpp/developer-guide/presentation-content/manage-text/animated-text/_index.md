---
title: Texto Animado
type: docs
weight: 60
url: /es/cpp/animated-text/
keywords: "Texto animado en PowerPoint"
description: "Texto animado en la presentación de PowerPoint con Aspose.Slides"
---

## Agregar Efectos de Animación a Párrafos

Agregamos el [**AddEffect()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.sequence#a255eb5aaf90861b01980047bc06ead4f) método a las clases [**Sequence**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.sequence) y [**ISequence**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.i_sequence). Este método te permite agregar efectos de animación a un solo párrafo. Este código de ejemplo te muestra cómo agregar un efecto de animación a un solo párrafo:

``` cpp
String dataDir = GetDataPath();
auto presentation = System::MakeObject<Presentation>(dataDir + u"Presentation1.pptx");

// seleccionar párrafo para agregar efecto
auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraphs()->idx_get(0);

// agregar efecto de animación Fly al párrafo seleccionado
auto sequence = presentation->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();
auto effect = sequence->AddEffect(paragraph, EffectType::Fly, EffectSubtype::Left, EffectTriggerType::OnClick);

presentation->Save(dataDir + u"AnimationEffectinParagraph.pptx", SaveFormat::Pptx);
```


## Obtener los Efectos de Animación en Párrafos

Puedes decidir averiguar los efectos de animación agregados a un párrafo; por ejemplo, en un escenario, deseas obtener los efectos de animación en un párrafo porque planeas aplicar esos efectos a otro párrafo o forma.

Aspose.Slides para C++ te permite obtener todos los efectos de animación aplicados a los párrafos contenidos en un marco de texto (forma). Este código de ejemplo te muestra cómo obtener los efectos de animación en un párrafo:

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
		Console::WriteLine(String(u"Párrafo \"") + paragraph->get_Text() + u"\" tiene " + ObjectExt::ToString(effects[0]->get_Type()) + u" efecto.");
	}
}
```