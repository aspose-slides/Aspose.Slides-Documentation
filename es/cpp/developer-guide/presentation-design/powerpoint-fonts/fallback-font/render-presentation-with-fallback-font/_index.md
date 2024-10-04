---
title: Renderizar Presentación con Fuente Fallback
type: docs
weight: 30
url: /cpp/render-presentation-with-fallback-font/
keywords: 
- fuente fallback
- renderizar PowerPoint
- PowerPoint
- presentación
- C++
- Aspose.Slides para C++
description: "Renderizar PowerPoint con fuente fallback en C++"
---

El siguiente ejemplo incluye estos pasos:

1. [Creamos una colección de reglas de fuente fallback](/slides/cpp/create-fallback-fonts-collection/).
1. [Remove()](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule#aaf12e563d822f6e05e27732a837bcf33) una regla de fuente fallback y [AddFallBackFonts()](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule#a030268631ae616b775bdb6df8accf42c) a otra regla.
1. Establecemos la colección de reglas en [FontsManager::set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/cpp/class/aspose.slides.fonts_manager#a375fc71abd64891a39673751d127d924) propiedad.
1. Con el método [Presentation::Save()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) podemos guardar la presentación en el mismo formato, o guardarla en otro. Después de que la colección de reglas de fuentes fallback se establece en FontsManager, estas reglas se aplican durante cualquier operación sobre la presentación: guardar, renderizar, convertir, etc.

``` cpp
// Crear nueva instancia de una colección de reglas
auto rulesList = MakeObject<FontFallBackRulesCollection>();

// Crear un número de reglas
rulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x400), static_cast<uint32_t>(0x4FF), u"Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

for (const auto& fallBackRule : rulesList)
{
	// Intentando eliminar la fuente fallback "Tahoma" de las reglas cargadas
	fallBackRule->Remove(u"Tahoma");

	// Y actualizar reglas para el rango especificado
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
// Asignando una lista de reglas preparadas para usar
pres->get_FontsManager()->set_FontFallBackRulesCollection(rulesList);

// Renderizando miniatura utilizando la colección de reglas inicializada y guardando en PNG
auto image = pres->get_Slide(0)->GetImage(1.f, 1.f);
image->Save(u"Slide_0.png", ImageFormat::Png);
image->Dispose();

pres->Dispose();
```


{{% alert color="primary" %}} 
Lee más sobre [Guardar y Conversión en Presentación](/slides/cpp/creating-saving-and-converting-a-presentation/).
{{% /alert %}}