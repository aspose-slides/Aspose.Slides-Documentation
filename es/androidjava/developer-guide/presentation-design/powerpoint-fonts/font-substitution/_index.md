---
title: Configurar sustitución de fuentes en presentaciones en Android
linktitle: Sustitución de fuentes
type: docs
weight: 70
url: /es/androidjava/font-substitution/
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
- Android
- Java
- Aspose.Slides
description: "Configurar reglas de sustitución de fuentes e inspeccionar fuentes sustituidas en Aspose.Slides para Android mediante Java al renderizar o convertir presentaciones."
---
## **Descripción general**

La sustitución de fuentes permite a Aspose.Slides utilizar una fuente disponible en lugar de una fuente a la que no se puede acceder cuando se renderiza o convierte una presentación. La sustitución afecta a la salida renderizada; no modifica la fuente asignada al contenido de la presentación.

Puede definir la fuente que se usará cuando una fuente concreta no esté disponible, y puede inspeccionar las sustituciones que Aspose.Slides realizará durante la renderización. Esto ayuda a mantener la salida coherente en dispositivos Android y entornos con fuentes diferentes disponibles.

## **Obtener sustituciones de fuentes**

Utilice el método [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) para determinar qué fuentes se sustituirán cuando se renderice la presentación. El método devuelve objetos [FontSubstitutionInfo](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/fontsubstitutioninfo/) que identifican los nombres de fuente original y sustituida.

El siguiente ejemplo en Java enumera todas las sustituciones de fuentes para una presentación:

```java
import com.aspose.slides.FontSubstitutionInfo;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions()) {
        System.out.println(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }
} finally {
    presentation.dispose();
}
```

## **Obtener sustituciones de fuentes para diapositivas seleccionadas**

Utilice la sobrecarga del método [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) con un argumento `int[] slides` para inspeccionar solo las sustituciones necesarias para renderizar diapositivas concretas. Esto es útil cuando se renderiza o exporta una parte de la presentación, se verifica una presentación grande de forma incremental, se localizan diapositivas que dependen de fuentes no disponibles, se prepara un paquete de fuentes mínimo para una aplicación Android o se diagnostican diferencias de renderizado sin procesar diapositivas no relacionadas.

La matriz `slides` contiene índices de diapositivas basados en uno: `1` identifica la primera diapositiva. En contraste, el accesor de colección [Presentation.getSlides](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/#getSlides--) utiliza indexado basado en cero, de modo que la misma diapositiva se accede como `presentation.getSlides().get_Item(0)`. Tenga presente esta diferencia al crear la matriz para evitar errores de desplazamiento.

Llame a la sobrecarga a través del método [Presentation.getFontsManager](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/#getFontsManager--). Éste devuelve solo las sustituciones determinadas al renderizar las diapositivas seleccionadas. Cada resultado es un objeto [FontSubstitutionInfo](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/fontsubstitutioninfo/) que contiene los nombres de fuente original y sustituida. El resultado refleja el entorno de fuentes actual, las reglas de reserva configuradas, las reglas de sustitución almacenadas en una [IFontSubstRuleCollection](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ifontsubstrulecollection/) y [fuentes cargadas externamente](/slides/es/androidjava/custom-font/).

La misma sustitución puede ser requerida por más de una diapositiva seleccionada. Elimine duplicados de los resultados cuando cree un inventario de fuentes o un informe de preflight. El siguiente ejemplo muestra cada sustitución devuelta y luego crea una lista ordenada de asignaciones de fuentes únicas:

```java
import com.aspose.slides.FontSubstitutionInfo;
import com.aspose.slides.Presentation;
import java.util.ArrayList;
import java.util.List;
import java.util.Set;
import java.util.TreeSet;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    int[] selectedSlides = { 1, 3, 5 };
    List<FontSubstitutionInfo> substitutions = new ArrayList<>();
    for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions(selectedSlides)) {
        substitutions.add(substitution);
    }

    System.out.println("Substitutions for the selected slides:");
    for (FontSubstitutionInfo substitution : substitutions) {
        System.out.println(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }

    Set<String> sortedPreflightEntries = new TreeSet<>(String.CASE_INSENSITIVE_ORDER);
    for (FontSubstitutionInfo substitution : substitutions) {
        String entry = substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName();
        sortedPreflightEntries.add(entry);
    }

    System.out.println("Deduplicated font preflight report:");
    for (String entry : sortedPreflightEntries) {
        System.out.println(entry);
    }
} finally {
    presentation.dispose();
}
```

La interfaz [IFontsManager](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ifontsmanager/) proporciona ambas sobrecargas. Elija una según el alcance de la operación de renderizado:

| Sobrecarga | Usar cuando |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) sin argumentos | Necesita sustituciones para toda la presentación. |
| [getSubstitutions](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) con `int[] slides` | Necesita sustituciones para un rango seleccionado, comprobación incremental o exportación parcial. |

## **Definir reglas de sustitución de fuentes**

Para especificar la fuente que Aspose.Slides debe usar cuando una fuente origen no esté disponible:

1. Cargue la presentación.  
2. Cree definiciones de fuentes para la fuente origen y la fuente sustituta.  
3. Cree una [FontSubstRule](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/fontsubstrule/) con la condición [WhenInaccessible](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/fontsubstcondition/).  
4. Añada la regla a una [FontSubstRuleCollection](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/fontsubstrulecollection/).  
5. Asigne la colección mediante el método [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-).  
6. Renderice o convierta la presentación.

El siguiente ejemplo en Java sustituye `Arial` por `SomeRareFont` cuando `SomeRareFont` no está disponible, y luego renderiza la primera diapositiva para verificar el resultado. La fuente sustituta debe estar disponible para Aspose.Slides.

```java
import com.aspose.slides.FontData;
import com.aspose.slides.FontSubstCondition;
import com.aspose.slides.FontSubstRule;
import com.aspose.slides.FontSubstRuleCollection;
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontSubstRule;
import com.aspose.slides.IFontSubstRuleCollection;
import com.aspose.slides.IImage;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Fonts.pptx");
try {
    IFontData sourceFont = new FontData("SomeRareFont");
    IFontData substituteFont = new FontData("Arial");
    IFontSubstRule substitutionRule = new FontSubstRule(sourceFont, substituteFont, FontSubstCondition.WhenInaccessible);

    IFontSubstRuleCollection substitutionRules = new FontSubstRuleCollection();
    substitutionRules.add(substitutionRule);
    presentation.getFontsManager().setFontSubstRuleList(substitutionRules);

    IImage image = presentation.getSlides().get_Item(0).getImage(1f, 1f);
    try {
        image.save("slide.jpg", ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Nota" %}}
Para un cambio incondicional de las fuentes utilizadas en toda la presentación, consulte la sección [Font Replacement](/slides/es/androidjava/font-replacement/).
{{% /alert %}}

## **Limitaciones para fuentes de ecuaciones matemáticas**

Las reglas de sustitución de fuentes forman parte del proceso estándar de selección de fuentes utilizado durante la renderización y conversión. Funcionan para texto normal cuando Aspose.Slides puede reemplazar una fuente inaccesible por la fuente disponible especificada en una regla.

Las ecuaciones de Office Math tienen un requisito adicional. Si una ecuación usa **Cambria Math**, Aspose.Slides puede necesitar esa fuente exacta para calcular y renderizar la disposición de la ecuación. Una regla que sustituya otra fuente matemática, como **STIX Two Math**, no puede reemplazar **Cambria Math** para este fin, y la renderización puede seguir indicando que **Cambria Math** es necesaria.

Para renderizar o convertir una presentación de este tipo, haga que **Cambria Math** esté disponible para Aspose.Slides. Cárguela como una [fuente externa](/slides/es/androidjava/custom-font/) para que la aplicación pueda usarla durante la renderización y conversión.

Esta limitación se aplica al diseño de ecuaciones. Las reglas de sustitución descritas anteriormente siguen aplicándose al texto normal de la presentación.

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre sustitución de fuentes y reemplazo de fuentes?**

El [Font Replacement](/slides/es/androidjava/font-replacement/) cambia intencionalmente una fuente por otra en toda la presentación. La sustitución de fuentes selecciona una fuente para la salida renderizada cuando se cumple la condición configurada, por ejemplo cuando la fuente original no está disponible.

**¿Cuándo se aplican las reglas de sustitución?**

Las reglas participan en la [secuencia de selección de fuentes](/slides/es/androidjava/font-selection-sequence/) durante la renderización y conversión. Con `WhenInaccessible`, una regla se utiliza solo cuando Aspose.Slides no puede acceder a la fuente origen.

**¿Qué ocurre cuando falta una fuente y no hay ninguna regla de sustitución configurada?**

Aspose.Slides selecciona la fuente disponible más cercana según su proceso de selección de fuentes. El resultado depende de las fuentes presentes en el entorno de ejecución.

**¿Puedo cargar fuentes externas para evitar la sustitución?**

Sí. Puede [cargar fuentes externas](/slides/es/androidjava/custom-font/) para que Aspose.Slides las utilice durante la renderización y conversión.

**¿Aspose distribuye fuentes con la biblioteca?**

No. Usted es responsable de proporcionar las fuentes y cumplir con sus licencias.

**¿Pueden los resultados de sustitución diferir entre dispositivos Android?**

Sí. Las fuentes del sistema disponibles pueden variar entre versiones de Android, dispositivos y fabricantes, por lo que una fuente disponible en un entorno puede requerir sustitución en otro.

**¿Cómo puedo lograr una selección de fuentes coherente en todos los dispositivos Android?**

Empaquete los mismos archivos de fuentes requeridos con la aplicación, [cárgelos como fuentes externas](/slides/es/androidjava/custom-font/) y [incorpore fuentes](/slides/es/androidjava/embedded-font/) cuando la licencia lo permita. También puede llamar a [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) antes de la exportación para identificar sustituciones inesperadas.