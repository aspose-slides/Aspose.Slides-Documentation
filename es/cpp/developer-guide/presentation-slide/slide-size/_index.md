---
title: Tamaño de la Diapositiva
type: docs
weight: 70
url: /cpp/slide-size/

---

## Tamaños de Diapositivas en Presentaciones de PowerPoint

Aspose.Slides para C++ te permite cambiar el tamaño de la diapositiva o la relación de aspecto en presentaciones de PowerPoint. Si planeas imprimir tu presentación o mostrar sus diapositivas en una pantalla, debes prestar atención a su tamaño de diapositiva o relación de aspecto.

Estos son los tamaños de diapositiva y relaciones de aspecto más comunes:

- **Estándar (relación de aspecto 4:3)**

  Si tu presentación se va a mostrar o visualizar en dispositivos o pantallas relativamente más antiguos, es posible que desees usar esta configuración.

- **Pantalla Ancha (relación de aspecto 16:9)** 

  Si tu presentación se va a ver en proyectores o pantallas modernas, es posible que desees usar esta configuración.

No puedes usar múltiples configuraciones de tamaño de diapresiva en una sola presentación. Cuando seleccionas un tamaño de diapositiva para una presentación, esa configuración de tamaño de diapositiva se aplica a todas las diapositivas de la presentación.

Si prefieres usar un tamaño de diapositiva especial para tus presentaciones, te recomendamos hacerlo temprano. Idealmente, deberías especificar tu tamaño de diapositiva preferido al principio, es decir, cuando solo estás configurando la presentación—antes de agregar cualquier contenido a la presentación. De esta manera, evitas complicaciones resultantes de cambios (futuros) realizados en el tamaño de las diapositivas.

{{% alert color="primary" %}} 

 Cuando usas Aspose.Slides para crear una presentación, todas las diapositivas en la presentación obtienen automáticamente el tamaño estándar o la relación de aspecto 4:3.

{{% /alert %}} 

## Cambiando el Tamaño de la Diapositiva en Presentaciones 

 Este código de ejemplo te muestra cómo cambiar el tamaño de la diapositiva en una presentación en C++ usando Aspose.Slides:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres-4x3-aspect-ratio.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
```

## Especificando Tamaños de Diapositivas Personalizadas en Presentaciones

Si encuentras que los tamaños de diapositiva comunes (4:3 y 16:9) no son adecuados para tu trabajo, puedes decidir usar un tamaño de diapositiva específico o único. Por ejemplo, si planeas imprimir diapositivas de tamaño completo de tu presentación en un diseño de página personalizado o si tienes la intención de mostrar tu presentación en ciertos tipos de pantalla, es probable que te beneficie usar una configuración de tamaño personalizada para tu presentación.

Este código de ejemplo te muestra cómo usar Aspose.Slides para C++ para especificar un tamaño de diapositiva personalizado para una presentación en C++:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
// Tamaño de papel A4
pres->get_SlideSize()->SetSize(780.0f, 540.0f, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-a4-slide-size.pptx", SaveFormat::Pptx);
```

## Tratando Con Problemas Al Cambiar el Tamaño de las Diapositivas en Presentaciones

Después de cambiar el tamaño de la diapositiva para una presentación, el contenido de las diapositivas (imágenes u objetos, por ejemplo) puede volverse distorsionado. Por defecto, los objetos se redimensionan automáticamente para ajustarse al nuevo tamaño de la diapositiva. Sin embargo, al cambiar el tamaño de la diapositiva de una presentación, puedes especificar una configuración que determine cómo maneja Aspose.Slides el contenido en las diapositivas.

Dependiendo de lo que pretendes hacer o lograr, puedes usar cualquiera de estas configuraciones:

- `DoNotScale`

  Si NO deseas que los objetos en las diapositivas sean redimensionados, usa esta configuración.

- `EnsureFit`

  Si deseas escalar a un tamaño de diapositiva más pequeño y necesitas que Aspose.Slides reduzca el tamaño de los objetos de las diapositivas para asegurarte de que todos encajen en las diapositivas (de esta manera, evitas perder contenido), usa esta configuración.

- `Maximize`

  Si deseas escalar a un tamaño de diapositiva más grande y necesitas que Aspose.Slides amplíe los objetos de las diapositivas para hacerlos proporcionales al nuevo tamaño de la diapositiva, usa esta configuración.

Este código de ejemplo te muestra cómo usar la configuración `Maximize` al cambiar el tamaño de la diapositiva de una presentación:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
```