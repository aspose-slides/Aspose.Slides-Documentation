---
title: Renderizar presentaciones con fuentes de reserva en C++
linktitle: Renderizar presentaciones
type: docs
weight: 30
url: /es/cpp/render-presentation-with-fallback-font/
keywords:
- fuente de reserva
- renderizar PowerPoint
- renderizar presentación
- renderizar diapositiva
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Renderizar presentaciones con fuentes de reserva en Aspose.Slides para C++ – mantenga el texto coherente en PPT, PPTX y ODP con ejemplos de código paso a paso en C++."
---

El siguiente ejemplo incluye estos pasos:

1. Creamos la [colección de reglas de fuentes de reserva](/slides/es/cpp/create-fallback-fonts-collection/).
1. [Remove()](https://reference.aspose.com/slides/cpp/aspose.slides/fontfallbackrule/remove/) una regla de fuente de reserva y [AddFallBackFonts()](https://reference.aspose.com/slides/cpp/aspose.slides/fontfallbackrule/addfallbackfonts/) a otra regla.
1. Pasa la colección de reglas al método [FontsManager::set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/).
1. Con el método [Presentation::Save()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) podemos guardar la presentación en el mismo formato, o guardarla en otro distinto. Después de que la colección de reglas de fuentes de reserva se asigna a FontsManager, estas reglas se aplican durante cualquier operación sobre la presentación: guardar, renderizar, convertir, etc.
```cpp
// Crear nueva instancia de una colección de reglas
auto rulesList = MakeObject<FontFallBackRulesCollection>();

// Crear un número de reglas
rulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x400), static_cast<uint32_t>(0x4FF), u"Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

for (const auto& fallBackRule : rulesList)
{
	// Intentar eliminar la fuente de reserva "Tahoma" de las reglas cargadas
	fallBackRule->Remove(u"Tahoma");

	// Y actualizar las reglas para el rango especificado
	if ((fallBackRule->get_RangeEndIndex() >= static_cast<uint32_t>(0x4000)) && 
		(fallBackRule->get_RangeStartIndex() < static_cast<uint32_t>(0x5000)))
	{
		fallBackRule->AddFallBackFonts(u"Verdana");
	}
}

// También podemos eliminar cualquier regla existente de la lista
if (rulesList->get_Count() > 0)
{
	rulesList->Remove(rulesList->idx_get(0));
}

auto pres = System::MakeObject<Presentation>(u"input.pptx");
// Assigning a prepared rules list for using
pres->get_FontsManager()->set_FontFallBackRulesCollection(rulesList);

// Rendering of thumbnail with using of initialized rules collection and saving to PNG
auto image = pres->get_Slide(0)->GetImage(1.f, 1.f);
image->Save(u"Slide_0.png", ImageFormat::Png);
image->Dispose();

pres->Dispose();
```



{{% alert color="primary" %}} 
Obtén más información sobre cómo [Convertir diapositivas de PowerPoint a PNG en C++](/slides/es/cpp/convert-powerpoint-to-png/).
{{% /alert %}}