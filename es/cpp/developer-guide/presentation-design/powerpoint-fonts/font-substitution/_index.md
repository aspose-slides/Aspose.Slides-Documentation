---
title: Configurar la sustitución de fuentes en presentaciones usando C++
linktitle: Sustitución de fuentes
type: docs
weight: 70
url: /es/cpp/font-substitution/
keywords:
- fuente
- sustituir fuente
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
description: "Habilite una sustitución óptima de fuentes en Aspose.Slides para C++ al convertir presentaciones de PowerPoint y OpenDocument a otros formatos de archivo."
---
## **Visión general**

La sustitución de fuentes permite a Aspose.Slides usar otra fuente cuando la fuente original de la presentación no está disponible durante el renderizado o la conversión. Puede comprobar qué fuentes fueron sustituidas utilizando el método `GetSubstitutions` de la interfaz `IFontsManager`.

Aspose.Slides también permite definir reglas de sustitución de fuentes. Por ejemplo, puede especificar que una fuente inaccesible debe reemplazarse por otra fuente disponible y luego aplicar esas reglas mediante el gestor de fuentes de la presentación.

## **Establecer reglas de sustitución de fuentes**

Aspose.Slides permite establecer reglas para las fuentes que determinan qué debe hacerse en determinadas condiciones (por ejemplo, cuando una fuente no se puede acceder) de la siguiente manera:

1. Cargue la presentación correspondiente.
2. Cargue la fuente que será reemplazada.
3. Cargue la nueva fuente.
4. Añada una regla para el reemplazo.
5. Añada la regla a la colección de reglas de reemplazo de fuentes de la presentación.
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

// Añade la colección de reglas de fuentes a la lista de reglas
pres->get_FontsManager()->set_FontSubstRuleList ( fontSubstRuleCollection);


// Guarda el PPTX en disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert title="NOTE"  color="warning"   %}} 
Puede que desee ver [**Reemplazo de fuentes**](/slides/es/cpp/font-replacement/). 
{{% /alert %}}

## **Limitaciones de fuentes para ecuaciones matemáticas**

Las reglas de sustitución de fuentes participan en el proceso estándar de selección de fuentes utilizado durante el renderizado y la conversión. Son adecuadas para escenarios de texto normal donde Aspose.Slides puede reemplazar una fuente inaccesible por otra fuente disponible según la regla configurada.

Sin embargo, las ecuaciones matemáticas de Office tienen una limitación importante. Si una ecuación se creó con **Cambria Math**, Aspose.Slides todavía puede requerir la fuente original **Cambria Math** para calcular y renderizar correctamente la disposición de la ecuación. Por ello, sustituir **Cambria Math** por otra fuente matemática, como **STIX Two Math**, no está soportado para el renderizado de ecuaciones y puede seguir generando una excepción que indique que **Cambria Math** es necesaria.

Para convertir dichas presentaciones con éxito, asegúrese de que **Cambria Math** esté disponible para Aspose.Slides en tiempo de ejecución. Puede instalar la fuente en el sistema operativo o proporcionarla como una [fuente externa](/slides/es/cpp/custom-font/) para que participe en el proceso normal de selección de fuentes durante el renderizado y la conversión.

Esta limitación es específica del renderizado de ecuaciones. Las reglas estándar de sustitución de fuentes descritas arriba siguen aplicándose al texto normal de la presentación cuando la fuente original es inaccesible.

## **FAQ**

**¿Cuál es la diferencia entre reemplazo de fuentes y sustitución de fuentes?**

[Reemplazo](/slides/es/cpp/font-replacement/) es una sobrescritura forzada de una fuente por otra en toda la presentación. La sustitución es una regla que se activa bajo una condición específica, por ejemplo cuando la fuente original no está disponible, y entonces se usa una fuente de respaldo designada.

**¿Cuándo se aplican exactamente las reglas de sustitución?**

Las reglas participan en la secuencia estándar de [selección de fuentes](/slides/es/cpp/font-selection-sequence/) que se evalúa durante la carga, el renderizado y la conversión; si la fuente elegida no está disponible, se aplica el reemplazo o la sustitución.

**¿Cuál es el comportamiento predeterminado si ni el reemplazo ni la sustitución están configurados y la fuente falta en el sistema?**

La biblioteca intentará seleccionar la fuente del sistema más cercana disponible, similar a como lo haría PowerPoint.

**¿Puedo adjuntar fuentes externas personalizadas en tiempo de ejecución para evitar la sustitución?**

Sí. Puede [añadir fuentes externas](/slides/es/cpp/custom-font/) en tiempo de ejecución para que la biblioteca las tenga en cuenta en la selección y el renderizado, incluidas las conversiones posteriores.

**¿Aspose distribuye alguna fuente con la biblioteca?**

No. Aspose no distribuye fuentes gratuitas ni de pago; usted añade y utiliza las fuentes bajo su propia discreción y responsabilidad.

**¿Existen diferencias en el comportamiento de la sustitución en Windows, Linux y macOS?**

Sí. La detección de fuentes comienza en los directorios de fuentes del sistema operativo. El conjunto de fuentes predeterminadas disponibles y las rutas de búsqueda difieren entre plataformas, lo que afecta la disponibilidad y la necesidad de sustitución.

**¿Cómo debo preparar el entorno para minimizar sustituciones inesperadas durante conversiones por lotes?**

Sincronice el conjunto de fuentes entre máquinas o contenedores, [añada las fuentes externas](/slides/es/cpp/custom-font/) requeridas para los documentos de salida, y [incorpore fuentes](/slides/es/cpp/embedded-font/) en las presentaciones cuando sea posible, de modo que las fuentes elegidas estén disponibles durante el renderizado.