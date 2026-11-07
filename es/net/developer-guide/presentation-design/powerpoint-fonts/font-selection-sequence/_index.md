---
title: Secuencia de selección de fuentes en Aspose.Slides para .NET
linktitle: Selección de fuentes
type: docs
weight: 80
url: /es/net/font-selection-sequence/
keywords:
- selección de fuentes
- sustitución de fuentes
- reemplazo de fuentes
- regla de sustitución
- fuente disponible
- fuente faltante
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Descubra cómo Aspose.Slides para .NET selecciona fuentes, garantizando una presentación nítida y coherente de archivos PPT, PPTX y ODP—mejore sus diapositivas ahora."
---
## **Visión general**

Cuando se carga, renderiza o convierte una presentación a otro formato, Aspose.Slides tiene en cuenta sus fuentes incrustadas y las fuentes disponibles para la aplicación. Si una fuente requerida no está disponible, Aspose.Slides selecciona una fuente de sustitución que sea lo más cercana posible a la que usaría PowerPoint.

Las fuentes disponibles pueden incluir fuentes del sistema, fuentes cargadas por la aplicación y fuentes incrustadas en la presentación. Para una fuente incrustada y registrada coincidente, la preferencia de .NET 26.11 descrita a continuación controla cuál tiene prioridad. Las reglas de sustitución de fuentes definidas a través de [FontSubstRule](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/) son un mecanismo separado.

También puede añadir fuentes en tiempo de ejecución de la aplicación, usar fuentes incrustadas de una presentación o cargar fuentes externas para documentos de salida como archivos PDF.

## **Selección de fuentes**

El texto puede hacer referencia a una fuente de tema, como `+mn-lt`, en lugar de un nombre de familia explícito. Consulte [Resolve Theme Font References](/slides/es/net/presentation-theme/#resolve-theme-font-references) para obtener la familia especificada por el tema correspondiente. Resolver esa referencia es independiente de comprobar la disponibilidad de fuentes y aplicar sustitución en tiempo de renderizado o fallback de glifos; no identifica el archivo de fuente que se utiliza finalmente para renderizar el texto.

Al renderizar diapositivas o convertir una presentación, verifique que las fuentes solicitadas estén incrustadas o disponibles en fuentes registradas. Las fuentes faltantes pueden requerir sustitución o reemplazo; consulte [**Reemplazo de fuentes**](/slides/es/net/font-replacement/) y [**Sustitución de fuentes**](/slides/es/net/font-substitution/).

Al investigar la selección de fuentes:

1. Resuelva la familia y el estilo solicitados, incluida cualquier referencia de tema.
2. Compruebe las fuentes incrustadas y las fuentes registradas, incluidas las fuentes del sistema y las fuentes cargadas por la aplicación. Utilice la preferencia a continuación cuando compitan versiones incrustadas y registradas coincidentes.
3. Revise [reglas de sustitución de fuentes](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/) y el fallback de glifos si la fuente o los caracteres solicitados no están disponibles.

Aspose.Slides le permite añadir fuentes en tiempo de ejecución de la aplicación y luego usar esas fuentes. Consulte [**Fuentes personalizadas**](/slides/es/net/custom-font/).

Cuando se colocan fuentes adicionales dentro de una presentación, se denominan [**Fuentes incrustadas**](/slides/es/net/embedded-font/).

Aspose.Slides le permite añadir fuentes que se aplican *solo* a documentos de salida. Por ejemplo, si una presentación que desea convertir a PDF contiene fuentes que faltan en su sistema y fuentes incrustadas, puede añadir o cargar las fuentes necesarias como **fuentes externas**.

{{% alert title="Note" color="info" %}} 
No distribuimos ninguna fuente, ya sea de pago o gratuita. Nuestra API le permite cargar fuentes externas e incrustarlas en documentos, pero lo hace con fuentes a su discreción y responsabilidad.
{{% /alert %}}

## **Preferir fuentes registradas sobre fuentes incrustadas**

A partir de .NET 26.11, [IFontsManager.PreferRegisteredFontsOverEmbedded](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/preferregisteredfontsoverembedded/) permite que una fuente registrada coincidente tenga prioridad sobre una fuente incrustada durante la exportación. El valor predeterminado es `false`. La coincidencia utiliza el nombre y el estilo de la fuente; un nombre de familia diferente no es una coincidencia de sustitución. Las fuentes registradas pueden provener del sistema o de [fuentes cargadas explícitamente](/slides/es/net/custom-font/).

El siguiente ejemplo usa el paquete **Aspose.Slides.NET6.CrossPlatform 26.11** en .NET 8. Siga la [guía de instalación](/slides/es/net/installation/) para su entorno. Proporcione `embedded-fonts.pptx` con una fuente incrustada y `preferred.ttf` con el mismo nombre de familia y estilo. Los dos archivos de fuente deberían diferir visiblemente si desea comparar el resultado.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var fontBytes = File.ReadAllBytes("preferred.ttf");
FontsLoader.LoadExternalFont(fontBytes);
using var presentation = new Presentation("embedded-fonts.pptx");

presentation.FontsManager.PreferRegisteredFontsOverEmbedded = false;
presentation.Save("embedded-preference.pdf", SaveFormat.Pdf);

presentation.FontsManager.PreferRegisteredFontsOverEmbedded = true;
presentation.Save("registered-preference.pdf", SaveFormat.Pdf);

presentation.FontsManager.PreferRegisteredFontsOverEmbedded = false;
presentation.Save("restored-preference.pdf", SaveFormat.Pdf);
```

Esta configuración cambia la precedencia de fuentes durante la exportación; no renombra la fuente del texto, no elimina datos de fuentes incrustadas ni vuelve a incrustar el archivo registrado. Es una configuración en tiempo de ejecución: vuelva a establecerla después de volver a abrir una presentación. Si no hay una fuente registrada coincidente disponible, habilitar la preferencia no proporciona una; verifique la fuente y el diseño resultantes en su entorno de destino.

Se verificó la salida PNG y PDF con fuentes regulares cargadas explícitamente para la configuración anterior. Compruebe sus propios archivos de fuentes, estilos, compilación del SDK y formatos de salida antes de depender de resultados idénticos. Las métricas de fuentes pueden cambiar los saltos de línea y la posición. Use [reemplazo de fuentes](/slides/es/net/font-replacement/) o [sustitución](/slides/es/net/font-substitution/) cuando necesite una familia diferente, y [operaciones de fuentes incrustadas](/slides/es/net/embedded-font/) cuando necesite cambiar las fuentes almacenadas en la presentación.

## **Preguntas frecuentes**

**¿Cómo puedo determinar qué fuentes se usan realmente en una presentación antes de la conversión?**

Aspose.Slides le permite inspeccionar las fuentes utilizadas mediante el [font manager](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/), para que pueda decidir si [incrustar](/slides/es/net/embedded-font/), [reemplazar](/slides/es/net/font-replacement/) o añadir [fuentes externas](/slides/es/net/custom-font/). Esto le ayuda a evitar sustituciones no deseadas durante el renderizado y la exportación.

**¿Puedo añadir directorios de fuentes adicionales sin instalarlos en el sistema operativo?**

Sí. Puede registrar [fuentes externas](/slides/es/net/custom-font/) como carpetas o flujos en memoria para el renderizado y la exportación. Esto elimina la dependencia de las fuentes del sistema host y mantiene el diseño predecible.

**¿Cómo evito un fallback silencioso a una fuente inadecuada cuando falta un glifo?**

Defina [reemplazo de fuentes](/slides/es/net/font-replacement/) y [reglas de fallback](/slides/es/net/fallback-font/) de fuentes explícitamente con antelación. Analizando las fuentes usadas y estableciendo una prioridad controlada para los sustitutos, garantiza tipografía coherente y evita resultados inesperados.