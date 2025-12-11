---
title: Configurar sustitución de fuentes en presentaciones usando C++
linktitle: Sustitución de fuentes
type: docs
weight: 70
url: /es/cpp/font-substitution/
keywords:
- fuente
- fuente sustituta
- sustitución de fuentes
- reemplazar fuente
- reemplazo de fuentes
- regla de sustitución
- regla de reemplazo
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Habilite la sustitución óptima de fuentes en Aspose.Slides para C++ al convertir presentaciones de PowerPoint y OpenDocument a otros formatos de archivo."
---

## **Establecer reglas de sustitución de fuentes**

Aspose.Slides le permite establecer reglas para fuentes que determinan qué debe hacerse en ciertas condiciones (por ejemplo, cuando una fuente no se puede acceder) de esta manera:

1. Cargue la presentación correspondiente.
2. Cargue la fuente que será reemplazada.
3. Cargue la nueva fuente.
4. Agregue una regla para el reemplazo.
5. Agregue la regla a la colección de reglas de reemplazo de fuentes de la presentación.
6. Genere la imagen de la diapositiva para observar el efecto.

Este código C++ demuestra el proceso de sustitución de fuentes:
```c++
// La ruta al directorio de documentos.
const String outPath = u"../out/RuleBasedFontsReplacement_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";


// Carga una presentación
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// Define la fuente que será reemplazada y la nueva fuente
SharedPtr<IFontData> sourceFont = MakeObject<FontData>(u"SomeRareFont");
SharedPtr<IFontData> destFont = MakeObject<FontData>(u"Arial");
	
// Añade una regla de fuente para el reemplazo de fuentes
SharedPtr<FontSubstRule> fontSubstRule = MakeObject<FontSubstRule>(sourceFont, destFont, FontSubstCondition::WhenInaccessible);

// Añade la regla a la colección de reglas de sustitución de fuentes
SharedPtr<FontSubstRuleCollection> fontSubstRuleCollection = MakeObject<FontSubstRuleCollection>();
fontSubstRuleCollection->Add(fontSubstRule);

// Añade la colección de reglas de fuente a la lista de reglas
pres->get_FontsManager()->set_FontSubstRuleList ( fontSubstRuleCollection);


// Guarda el PPTX en disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


{{%  alert title="NOTE"  color="warning"   %}} 

Puede que desee ver [**Reemplazo de fuentes**](/slides/es/cpp/font-replacement/). 

{{% /alert %}}

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre el reemplazo de fuentes y la sustitución de fuentes?**

[Replacement](/slides/es/cpp/font-replacement/) es una anulación forzada de una fuente por otra en toda la presentación. La sustitución es una regla que se activa bajo una condición específica, por ejemplo cuando la fuente original no está disponible, y entonces se usa una fuente de respaldo designada.

**¿Cuándo se aplican exactamente las reglas de sustitución?**

Las reglas participan en la secuencia estándar de [font selection](/slides/es/cpp/font-selection-sequence/) que se evalúa durante la carga, el renderizado y la conversión; si la fuente elegida no está disponible, se aplica el reemplazo o la sustitución.

**¿Cuál es el comportamiento predeterminado si ni el reemplazo ni la sustitución están configurados y la fuente falta en el sistema?**

La biblioteca intentará seleccionar la fuente del sistema disponible más cercana, similar a cómo se comportaría PowerPoint.

**¿Puedo adjuntar fuentes externas personalizadas en tiempo de ejecución para evitar la sustitución?**

Sí. Puede [add external fonts](/slides/es/cpp/custom-font/) en tiempo de ejecución para que la biblioteca las considere en la selección y el renderizado, incluidas las conversiones posteriores.

**¿Aspose distribuye alguna fuente con la biblioteca?**

No. Aspose no distribuye fuentes pagas ni gratuitas; usted agrega y usa fuentes bajo su propia discreción y responsabilidad.

**¿Existen diferencias en el comportamiento de sustitución en Windows, Linux y macOS?**

Sí. La detección de fuentes comienza desde los directorios de fuentes del sistema operativo. El conjunto de fuentes disponibles por defecto y las rutas de búsqueda difieren entre plataformas, lo que afecta la disponibilidad y la necesidad de sustitución.

**¿Cómo debo preparar el entorno para minimizar sustituciones inesperadas durante conversiones por lotes?**

Sincronice el conjunto de fuentes entre máquinas o contenedores, [add the external fonts](/slides/es/cpp/custom-font/) requeridas para los documentos de salida, y [embed fonts](/slides/es/cpp/embedded-font/) en las presentaciones cuando sea posible para que las fuentes elegidas estén disponibles durante el renderizado.