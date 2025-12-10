---
title: Animar texto de PowerPoint en C++
linktitle: Texto animado
type: docs
weight: 60
url: /es/cpp/animated-text/
keywords:
- texto animado
- animación de texto
- párrafo animado
- animación de párrafo
- efecto de animación
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Cree texto animado dinámico en presentaciones PowerPoint y OpenDocument usando Aspose.Slides para C++, con ejemplos de código C++ fáciles de seguir y optimizados."
---

## **Agregar efectos de animación a párrafos**

Agregamos el método [**AddEffect()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.sequence#a255eb5aaf90861b01980047bc06ead4f) a las clases [**Sequence**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.sequence) y [**ISequence**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.i_sequence). Este método le permite agregar efectos de animación a un solo párrafo. El siguiente código de ejemplo muestra cómo agregar un efecto de animación a un solo párrafo:
``` cpp
String dataDir = GetDataPath();
auto presentation = System::MakeObject<Presentation>(dataDir + u"Presentation1.pptx");

// seleccionar párrafo para añadir efecto
auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraphs()->idx_get(0);

// añadir efecto de animación Fly al párrafo seleccionado
auto sequence = presentation->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();
auto effect = sequence->AddEffect(paragraph, EffectType::Fly, EffectSubtype::Left, EffectTriggerType::OnClick);

presentation->Save(dataDir + u"AnimationEffectinParagraph.pptx", SaveFormat::Pptx);
```


## **Obtener efectos de animación para párrafos**

Es posible que necesite averiguar los efectos de animación añadidos a un párrafo; por ejemplo, en un caso desea obtener los efectos de animación de un párrafo porque planea aplicar esos efectos a otro párrafo o forma.

Aspose.Slides for C++ le permite obtener todos los efectos de animación aplicados a los párrafos contenidos en un marco de texto (forma). El siguiente código de ejemplo muestra cómo obtener los efectos de animación en un párrafo:
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

**¿En qué se diferencian las animaciones de texto de las transiciones de diapositiva y pueden combinarse?**

Las animaciones de texto controlan el comportamiento de los objetos a lo largo del tiempo en una diapositiva, mientras que [transitions](/slides/es/cpp/slide-transition/) controlan cómo cambian las diapositivas. Son independientes y pueden usarse juntas; el orden de reproducción lo rige la línea de tiempo de la animación y la configuración de la transición.

**¿Se conservan las animaciones de texto al exportar a PDF o imágenes?**

No. Los PDF y las imágenes rasterizadas son estáticas, por lo que verá un único estado de la diapositiva sin movimiento. Para conservar el movimiento, use la exportación a [video](/slides/es/cpp/convert-powerpoint-to-video/) o a [HTML](/slides/es/cpp/export-to-html5/).

**¿Funcionan las animaciones de texto en los diseños y la diapositiva maestra?**

Los efectos aplicados a los objetos de diseño/maestra se heredan en las diapositivas, pero su sincronización e interacción con las animaciones a nivel de diapositiva dependen de la secuencia final en la diapositiva.