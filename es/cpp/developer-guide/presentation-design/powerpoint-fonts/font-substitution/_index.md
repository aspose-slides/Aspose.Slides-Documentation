---
title: Sustitución de fuentes
type: docs
weight: 70
url: /es/cpp/font-substitution/
keywords: "Fuente, fuente sustituta, presentación de PowerPoint, C++, CPP, Aspose.Slides para C++"
description: "Sustituir fuente en PowerPoint en C++"
---

Aspose.Slides te permite establecer reglas para las fuentes que determinan qué se debe hacer en ciertas condiciones (por ejemplo, cuando no se puede acceder a una fuente) de la siguiente manera:

1. Carga la presentación relevante.
2. Carga la fuente que será reemplazada.
3. Carga la nueva fuente.
4. Agrega una regla para el reemplazo.
5. Agrega la regla a la colección de reglas de sustitución de fuentes de la presentación.
6. Genera la imagen de la diapositiva para observar el efecto.

Este código en C++ demuestra el proceso de sustitución de fuentes:

```c++
// La ruta al directorio de documentos.
const String outPath = u"../out/RuleBasedFontsReplacement_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";


// Carga una presentación
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// Define la fuente que será reemplazada y la nueva fuente
SharedPtr<IFontData> sourceFont = MakeObject<FontData>(u"SomeRareFont");
SharedPtr<IFontData> destFont = MakeObject<FontData>(u"Arial");
	
// Agrega una regla de fuente para el reemplazo de fuentes
SharedPtr<FontSubstRule> fontSubstRule = MakeObject<FontSubstRule>(sourceFont, destFont, FontSubstCondition::WhenInaccessible);

// Agrega la regla a la colección de reglas de sustitución de fuentes
SharedPtr<FontSubstRuleCollection> fontSubstRuleCollection = MakeObject<FontSubstRuleCollection>();
fontSubstRuleCollection->Add(fontSubstRule);

// Agrega la colección de reglas de fuentes a la lista de reglas
pres->get_FontsManager()->set_FontSubstRuleList ( fontSubstRuleCollection);


// Guarda PPTX en disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert title="NOTA"  color="warning"   %}} 

Puede que quieras ver [**Reemplazo de Fuentes**](/slides/es/cpp/font-replacement/). 

{{% /alert %}}