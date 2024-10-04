---
title: Tamaño de Diapositiva
type: docs
weight: 70
url: /python-net/tamano-de-diapositiva/
keywords: "Establecer diapositiva, editar tamaño de diapositiva, Presentación de PowerPoint, tamaño de diapositiva personalizado, resolver problemas de diapositivas, Python, Aspose.Slides"
descriptions: "Establecer y editar el tamaño de la diapositiva o la relación de aspecto en PowerPoint en Python"
---

## Tamaños de Diapositiva en Presentaciones de PowerPoint

Aspose.Slides para Python a través de .NET te permite cambiar el tamaño de la diapositiva o la relación de aspecto en presentaciones de PowerPoint. Si planeas imprimir tu presentación o mostrar sus diapositivas en una pantalla, debes prestar atención al tamaño de la diapositiva o a la relación de aspecto.

Estos son los tamaños de diapositiva y relaciones de aspecto más comunes:

- **Estándar (relación de aspecto 4:3)**

  Si tu presentación se va a mostrar o ver en dispositivos o pantallas relativamente antiguos, es posible que desees utilizar esta configuración.

- **Pantalla Ancha (relación de aspecto 16:9)** 

  Si tu presentación se va a ver en proyectores o pantallas modernas, es posible que desees utilizar esta configuración. 

No puedes utilizar múltiples configuraciones de tamaño de diapositiva en una sola presentación. Cuando seleccionas un tamaño de diapositiva para una presentación, esa configuración de tamaño se aplica a todas las diapositivas de la presentación.

Si prefieres utilizar un tamaño de diapositiva especial para tus presentaciones, te recomendamos encarecidamente que lo hagas al principio. Idealmente, debes especificar tu tamaño de diapositiva preferido al comienzo, es decir, cuando estés configurando la presentación, antes de agregar cualquier contenido a la presentación. De esta manera, evitas complicaciones derivadas de cambios (futuros) realizados en el tamaño de las diapositivas.

{{% alert color="primary" %}} 

 Cuando utilizas Aspose.Slides para crear una presentación, todas las diapositivas en la presentación automáticamente obtienen el tamaño estándar o la relación de aspecto 4:3.

{{% /alert %}} 

## Cambiando el Tamaño de Diapositiva en Presentaciones 

 Este código de muestra muestra cómo cambiar el tamaño de la diapositiva en una presentación en Python utilizando Aspose.Slides:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(slides.SlideSizeType.ON_SCREEN16X9, slides.SlideSizeScaleType.DO_NOT_SCALE)
    pres.save("pres-4x3-aspect-ratio.pptx", slides.export.SaveFormat.PPTX)
```

## Especificando Tamaños de Diapositiva Personalizados en Presentaciones

Si encuentras que los tamaños de diapositiva comunes (4:3 y 16:9) no son adecuados para tu trabajo, puedes decidir utilizar un tamaño de diapositiva específico o único. Por ejemplo, si planeas imprimir diapositivas a tamaño completo de tu presentación en un diseño de página personalizado o si planeas mostrar tu presentación en ciertos tipos de pantalla, es probable que te beneficie usar una configuración de tamaño personalizado para tu presentación.

Este código de muestra muestra cómo usar Aspose.Slides para Python a través de .NET para especificar un tamaño de diapositiva personalizado para una presentación en Python:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(780, 540, slides.SlideSizeScaleType.DO_NOT_SCALE) # Tamaño de papel A4
    pres.save("pres-a4-slide-size.pptx", slides.export.SaveFormat.PPTX)
```

## Tratando Con Problemas Al Cambiar el Tamaño de las Diapositivas en Presentaciones

Después de cambiar el tamaño de la diapositiva para una presentación, el contenido de las diapositivas (imágenes u objetos, por ejemplo) puede distorsionarse. Por defecto, los objetos se ajustan automáticamente al nuevo tamaño de la diapositiva. Sin embargo, al cambiar el tamaño de la diapositiva de una presentación, puedes especificar una configuración que determina cómo Aspose.Slides maneja el contenido en las diapositivas.

Dependiendo de lo que pretendas hacer o lograr, puedes usar cualquiera de estas configuraciones:

- `DO_NOT_SCALE`

  Si NO deseas que los objetos en las diapositivas se redimensionen, utiliza esta configuración.

- `ENSURE_FIT`

  Si deseas escalar a un tamaño de diapositiva más pequeño y necesitas que Aspose.Slides reduzca los objetos de las diapositivas para asegurarte de que todos encajen en las diapositivas (de esta manera, evitas perder contenido), utiliza esta configuración. 

- `MAXIMIZE`

  Si deseas escalar a un tamaño de diapositiva más grande y necesitas que Aspose.Slides amplíe los objetos de las diapositivas para hacerlos proporcionales al nuevo tamaño de la diapositiva, utiliza esta configuración. 

Este código de muestra muestra cómo usar la configuración `MAXIMIZE` al cambiar el tamaño de la diapositiva de una presentación:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
   pres.slide_size.set_size(slides.SlideSizeType.LEDGER, slides.SlideSizeScaleType.MAXIMIZE)
```