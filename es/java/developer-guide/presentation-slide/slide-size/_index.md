---
title: Tamaño de Diapositiva
type: docs
weight: 70
url: /es/java/slide-size/

---

## Tamaños de Diapositivas en Presentaciones de PowerPoint

Aspose.Slides para Java te permite cambiar el tamaño de la diapositiva o la relación de aspecto en presentaciones de PowerPoint. Si planeas imprimir tu presentación o mostrar sus diapositivas en una pantalla, debes prestar atención a su tamaño de diapositiva o relación de aspecto.

Estos son los tamaños de diapositivas y relaciones de aspecto más comunes:

- **Estándar (relación de aspecto 4:3)**

  Si tu presentación se va a mostrar o visualizar en dispositivos o pantallas relativamente más antiguos, es posible que desees usar esta configuración.

- **Pantalla Ancha (relación de aspecto 16:9)** 

  Si tu presentación se va a ver en proyectores o pantallas modernas, es posible que desees usar esta configuración.

No puedes usar múltiples configuraciones de tamaño de diapositiva en una sola presentación. Cuando seleccionas un tamaño de diapositiva para una presentación, esa configuración de tamaño de diapositiva se aplica a todas las diapositivas de la presentación.

Si prefieres utilizar un tamaño de diapositiva especial para tus presentaciones, te recomendamos encarecidamente que lo hagas temprano. Idealmente, deberías especificar tu tamaño de diapositiva preferido al principio, es decir, cuando estás configurando la presentación, antes de agregar cualquier contenido a la presentación. De esta manera, evitarás complicaciones resultantes de cambios (futuros) realizados en el tamaño de las diapositivas.

{{% alert color="primary" %}} 

 Cuando utilizas Aspose.Slides para crear una presentación, todas las diapositivas de la presentación obtienen automáticamente el tamaño estándar o la relación de aspecto 4:3.

{{% /alert %}} 

## Cambiando el Tamaño de la Diapositiva en Presentaciones 

 Este código de ejemplo te muestra cómo cambiar el tamaño de la diapositiva en una presentación en Java utilizando Aspose.Slides:

```java
Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## Especificando Tamaños de Diapositivas Personalizados en Presentaciones

Si encuentras que los tamaños de diapositivas comunes (4:3 y 16:9) son inadecuados para tu trabajo, puedes decidir utilizar un tamaño de diapositiva específico o único. Por ejemplo, si planeas imprimir diapositivas a tamaño completo de tu presentación en un diseño de página personalizado o si tienes la intención de mostrar tu presentación en ciertos tipos de pantalla, es probable que te beneficies de usar una configuración de tamaño personalizado para tu presentación.

Este código de ejemplo te muestra cómo utilizar Aspose.Slides para Java para especificar un tamaño de diapositiva personalizado para una presentación en Java:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // Tamaño de papel A4
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## Tratando con Problemas al Cambiar el Tamaño de las Diapositivas en Presentaciones

Después de cambiar el tamaño de la diapositiva para una presentación, el contenido de las diapositivas (imágenes u objetos, por ejemplo) puede distorsionarse. Por defecto, los objetos se redimensionan automáticamente para ajustarse al nuevo tamaño de la diapositiva. Sin embargo, al cambiar el tamaño de la diapositiva de una presentación, puedes especificar una configuración que determina cómo Aspose.Slides trata el contenido en las diapositivas.

Dependiendo de lo que pretendas hacer o lograr, puedes utilizar cualquiera de estas configuraciones:

- `DoNotScale`

  Si NO deseas que los objetos en las diapositivas sean redimensionados, utiliza esta configuración.

- `EnsureFit`

  Si deseas escalar a un tamaño de diapositiva más pequeño y necesitas que Aspose.Slides reduzca el tamaño de los objetos de las diapositivas para asegurarte de que todos encajen en las diapositivas (de esta manera, evitas perder contenido), utiliza esta configuración.

- `Maximize`

  Si deseas escalar a un tamaño de diapositiva más grande y necesitas que Aspose.Slides amplíe los objetos de las diapositivas para que sean proporcionales al nuevo tamaño de diapositiva, utiliza esta configuración.

Este código de ejemplo te muestra cómo utilizar la configuración `Maximize` al cambiar el tamaño de la diapositiva de una presentación:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) pres.dispose();
}
```