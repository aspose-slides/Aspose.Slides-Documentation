---
title: Tamaño de Diapositiva
type: docs
weight: 70
url: /net/slide-size/
keywords: "Establecer diapositiva, editar tamaño de diapositiva, Presentación de PowerPoint, tamaño de diapositiva personalizado, resolver problemas de diapositivas, C#, Csharp, .NET, Aspose.Slides"
descriptions: "Establecer y editar el tamaño de diapositiva o la relación de aspecto en PowerPoint en C# o .NET"
---

## Tamaños de Diapositivas en Presentaciones de PowerPoint

Aspose.Slides para .NET te permite cambiar el tamaño de la diapositiva o la relación de aspecto en las presentaciones de PowerPoint. Si planeas imprimir tu presentación o mostrar sus diapositivas en una pantalla, debes prestar atención a su tamaño de diapositiva o relación de aspecto.

Estos son los tamaños de diapositiva y relaciones de aspecto más comunes:

- **Estándar (relación de aspecto 4:3)**

  Si tu presentación se va a mostrar o ver en dispositivos o pantallas relativamente más antiguos, puede que desees utilizar esta configuración.

- **Pantalla Ancha (relación de aspecto 16:9)** 

  Si tu presentación va a ser vista en proyectores o pantallas modernas, puede que desees utilizar esta configuración.

No puedes usar múltiples configuraciones de tamaño de diapositiva en una sola presentación. Cuando seleccionas un tamaño de diapositiva para una presentación, esa configuración de tamaño de diapositiva se aplica a todas las diapositivas en la presentación.

Si prefieres usar un tamaño de diapositiva especial para tus presentaciones, te recomendamos encarecidamente que lo hagas temprano. Idealmente, deberías especificar tu tamaño de diapositiva preferido al principio, es decir, cuando solo estás configurando la presentación—antes de agregar cualquier contenido a la presentación. De esta manera, evitas complicaciones derivadas de cambios (futuros) realizados en el tamaño de las diapositivas.

{{% alert color="primary" %}} 

 Cuando utilizas Aspose.Slides para crear una presentación, todas las diapositivas en la presentación automáticamente obtienen el tamaño estándar o relación de aspecto 4:3.

{{% /alert %}} 

## Cambiando el Tamaño de Diapositivas en Presentaciones

 Este código de ejemplo te muestra cómo cambiar el tamaño de la diapositiva en una presentación en C# utilizando Aspose.Slides:

```c#
using (Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx"))
{
    pres.SlideSize.SetSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.Save("pres-4x3-aspect-ratio.pptx", SaveFormat.Pptx);
}
```

## Especificando Tamaños de Diapositivas Personalizadas en Presentaciones

Si encuentras que los tamaños de diapositiva comunes (4:3 y 16:9) no son adecuados para tu trabajo, puedes decidir usar un tamaño de diapositiva específico o único. Por ejemplo, si planeas imprimir diapositivas de tamaño completo desde tu presentación en un diseño de página personalizado o si tienes la intención de mostrar tu presentación en ciertos tipos de pantalla, es probable que te beneficie utilizar una configuración de tamaño personalizado para tu presentación.

Este código de ejemplo te muestra cómo usar Aspose.Slides para .NET para especificar un tamaño de diapositiva personalizado para una presentación en C#:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.SlideSize.SetSize(780, 540, SlideSizeScaleType.DoNotScale); // Tamaño de papel A4
    pres.Save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
}
```

## Tratando Con Problemas Al Cambiar el Tamaño de las Diapositivas en Presentaciones

Después de cambiar el tamaño de la diapositiva para una presentación, el contenido de las diapositivas (imágenes u objetos, por ejemplo) puede volverse distorsionado. Por defecto, los objetos se redimensionan automáticamente para ajustarse al nuevo tamaño de diapositiva. Sin embargo, al cambiar el tamaño de la diapositiva de una presentación, puedes especificar una configuración que determina cómo Aspose.Slides maneja el contenido en las diapositivas.

Dependiendo de lo que pretendas hacer o lograr, puedes usar cualquiera de estas configuraciones:

- `DoNotScale`

  Si NO deseas que los objetos en las diapositivas se redimensionen, usa esta configuración.

- `EnsureFit`

  Si deseas escalar a un tamaño de diapositiva más pequeño y necesitas que Aspose.Slides reduzca los objetos de las diapositivas para asegurarte de que todos quepan en las diapositivas (de esta forma, evitas perder contenido), usa esta configuración.

- `Maximize`

  Si deseas escalar a un tamaño de diapositiva más grande y necesitas que Aspose.Slides agrande los objetos de las diapositivas para que sean proporcionales al nuevo tamaño de diapositiva, usa esta configuración.

Este código de ejemplo te muestra cómo usar la configuración `Maximize` al cambiar el tamaño de la diapositiva de una presentación:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.SlideSize.SetSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
}
```