---
title: Cambiar el tamaño de la diapositiva de la presentación en .NET
linktitle: Tamaño de diapositiva
type: docs
weight: 70
url: /es/net/slide-size/
keywords:
- tamaño de diapositiva
- relación de aspecto
- estándar
- pantalla ancha
- 4:3
- 16:9
- establecer tamaño de diapositiva
- cambiar tamaño de diapositiva
- tamaño de diapositiva personalizado
- tamaño de diapositiva especial
- tamaño de diapositiva único
- diapositiva de tamaño completo
- tipo de pantalla
- no escalar
- asegurar ajuste
- maximizar
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
descriptions: "Aprenda cómo redimensionar rápidamente diapositivas en archivos PPT, PPTX y ODP con .NET y Aspose.Slides, optimice presentaciones para cualquier pantalla sin perder calidad."
---

## **Personalizar tamaños de diapositivas y relaciones de aspecto en una presentación**

Aspose.Slides for .NET proporciona herramientas completas para ajustar el tamaño de la diapositiva y la relación de aspecto en presentaciones de PowerPoint, lo cual es fundamental tanto para la impresión como para la visualización en pantalla. 

### **Tamaños de diapositiva y relaciones populares**

- **Estándar (relación de aspecto 4:3)**: Ideal para pantallas y dispositivos más antiguos.
  
- **Pantalla ancha (relación de aspecto 16:9)**: Recomendado para proyectores y pantallas modernos.

Asegúrese de mantener la consistencia en toda su presentación, ya que un único tamaño de diapositiva y una sola relación de aspecto se aplican a todas las diapositivas. Para obtener resultados óptimos, establezca las dimensiones de sus diapositivas al comienzo del proceso de creación de la presentación para evitar complicaciones.

{{% alert color="primary" %}} 
Por defecto, las presentaciones creadas con Aspose.Slides utilizan la relación de aspecto estándar 4:3.
{{% /alert %}}

## **Cómo cambiar el tamaño de la diapositiva en una presentación**

Este ejemplo muestra cómo cambiar el tamaño de la diapositiva de una presentación con Aspose.Slides en C#:
```csharp
using (Presentation pres = new Presentation("presentation-4x3.pptx"))
{
    pres.SlideSize.SetSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.Save("presentation-16x9.pptx", SaveFormat.Pptx);
}
```


## **Especificar tamaños de diapositiva personalizados**

Adaptar el tamaño de la diapositiva a sus necesidades específicas, como diseños de papel únicos o especificaciones de pantalla, puede ser beneficioso. A continuación se muestra cómo establecer un tamaño de diapositiva personalizado con Aspose.Slides para .NET:
```csharp
using (Presentation pres = new Presentation("presentation.pptx"))
{
    pres.SlideSize.SetSize(780, 540, SlideSizeScaleType.DoNotScale); // tamaño de papel A4
    pres.Save("presentation-a4.pptx", SaveFormat.Pptx);
}
```


## **Gestionar el contenido de la diapositiva después de redimensionar**

Después de redimensionar, el contenido de la diapositiva puede distorsionarse. Puede controlar cómo Aspose.Slides gestiona este cambio de tamaño:

- **`DoNotScale`**: Mantener los objetos en sus tamaños originales para evitar el escalado.
- **`EnsureFit`**: Escalar los objetos para que encajen en diapositivas más pequeñas, evitando la pérdida de contenido.
- **`Maximize`**: Ampliar los objetos para que se adapten a diapositivas más grandes, manteniendo la consistencia estética.

Ejemplo de uso de la configuración `Maximize` para ajustar el tamaño de la diapositiva:
```csharp
using (Presentation pres = new Presentation("presentation.pptx"))
{
   pres.SlideSize.SetSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
}
```


## **Preguntas frecuentes**

**¿Puedo establecer un tamaño de diapositiva personalizado usando unidades distintas a pulgadas (por ejemplo, puntos o milímetros)?**

Sí. Aspose.Slides utiliza puntos internamente, donde 1 punto equivale a 1/72 de pulgada. Puede convertir cualquier unidad (como milímetros o centímetros) a puntos y usar los valores convertidos para definir el ancho y la altura de la diapositiva.

**¿Afectará un tamaño de diapositiva personalizado muy grande al rendimiento y al uso de memoria durante la renderización?**

Sí. Dimensiones de diapositiva mayores (en puntos) combinadas con una escala de renderizado más alta provocan un mayor consumo de memoria y tiempos de procesamiento más largos. Apunte a un tamaño de diapositiva práctico y ajuste la escala de renderizado solo cuando sea necesario para lograr la calidad de salida deseada.

**¿Puedo definir un tamaño de diapositiva no estándar y luego combinar diapositivas de presentaciones que tengan tamaños diferentes?**

No puede [combinar presentaciones](/slides/es/net/merge-presentation/) mientras tengan diferentes tamaños de diapositiva; primero, redimensione una presentación para que coincida con la otra. Al cambiar el tamaño de la diapositiva, puede elegir cómo se maneja el contenido existente mediante la opción [SlideSizeScaleType](https://reference.aspose.com/slides/net/aspose.slides/slidesizescaletype/). Después de alinear los tamaños, puede combinar diapositivas conservando el formato.

**¿Puedo generar miniaturas para formas individuales o regiones específicas de una diapositiva, y respetarán el nuevo tamaño de diapositiva?**

Sí. Aspose.Slides puede generar miniaturas para [diapositivas completas](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage/) así como para [formas seleccionadas](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/). Las imágenes resultantes reflejan el tamaño y la relación de aspecto actuales de la diapositiva, garantizando un encuadre y una geometría consistentes.