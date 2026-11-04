---
title: Aplicar efectos de forma en presentaciones usando C++
linktitle: Efecto de forma
type: docs
weight: 30
url: /es/cpp/shape-effect/
keywords:
- efecto de forma
- efecto de sombra
- efecto de reflejo
- efecto de resplandor
- efecto de bordes suaves
- formato de efecto
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Transforma tus archivos PPT y PPTX con efectos de forma avanzados usando Aspose.Slides para C++ — crea diapositivas impactantes y profesionales en segundos."
---
## **Introducción**

Mientras que los efectos en PowerPoint pueden usarse para que una forma destaque, difieren de los [rellenos](/slides/es/cpp/shape-formatting/#gradient-fill) o contornos. Con los efectos de PowerPoint, puedes crear reflejos convincentes en una forma, difundir el brillo de una forma, etc.

![Efecto de forma](shape-effect.png)

PowerPoint ofrece seis efectos que pueden aplicarse a las formas. Puedes aplicar uno o más efectos a una forma.

Algunas combinaciones de efectos se ven mejor que otras. Por esta razón, PowerPoint tiene opciones bajo **Preset**. Las opciones de Preset son esencialmente una combinación de dos o más efectos que se saben que lucen bien juntos. Así, al seleccionar un preset, no tendrás que perder tiempo probando o combinando diferentes efectos para encontrar una buena combinación.

Aspose.Slides proporciona propiedades y métodos bajo la clase [EffectFormat](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/) que permiten aplicar los mismos efectos a las formas en presentaciones de PowerPoint.

## **Aplicar un efecto de sombra**

Aspose.Slides para C++ admite sombras externas e internas para las formas. Puedes personalizar su color, dirección, distancia y radio de desenfoque para que coincidan con el diseño de tu presentación.

### **Aplicar una sombra externa**

Utiliza una sombra externa para que una tarjeta o panel destaque contra el fondo de la diapositiva. La sombra se extiende más allá de los bordes de la forma, creando la impresión de que la forma está elevada sobre la diapositiva. Ajusta su color, dirección, distancia y radio de desenfoque para que coincidan con la iluminación y el estilo de tu plantilla.

Este código C++ muestra cómo aplicar el [efecto de sombra externa](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_outershadoweffect/) a un rectángulo:

```cpp
#include <DOM/Effects/IOuterShadow.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 100.0f);
auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableOuterShadowEffect();
auto outerShadowEffect = effectFormat->get_OuterShadowEffect();
outerShadowEffect->get_ShadowColor()->set_Color(Color::get_DarkGray());
outerShadowEffect->set_Distance(10);
outerShadowEffect->set_Direction(45.0f);

presentation->Save(u"shadow_effect.pptx", SaveFormat::Pptx);
```

![Efecto de sombra](shadow_effect.png)

### **Aplicar una sombra interna**

Al reproducir el estilo visual de una plantilla, utiliza una sombra interna para dar a una tarjeta o panel una apariencia hundida. Una sombra externa se extiende fuera de la forma y la hace parecer elevada, mientras que una sombra interna sombrea el interior de sus bordes.

Llama a [EnableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/enableinnershadoweffect/), luego configura [InnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_innershadoweffect/). Los valores mayores del radio de desenfoque producen bordes más suaves.

Este ejemplo C++ crea una tarjeta azul clara con una sombra interna gris oscuro y la guarda como archivo PPTX:

```cpp
#include <DOM/Effects/IInnerShadow.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/FillType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 200.0f, 100.0f);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_LightBlue());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

shape->get_EffectFormat()->EnableInnerShadowEffect();
auto shadow = shape->get_EffectFormat()->get_InnerShadowEffect();
shadow->get_ShadowColor()->set_Color(Color::get_DimGray());
shadow->set_Direction(225);
shadow->set_Distance(7);
shadow->set_BlurRadius(6);

presentation->Save(u"inner_shadow_effect.pptx", SaveFormat::Pptx);
```

![Rectángulo azul claro con sombra interna](inner_shadow_effect.png)

Para eliminar la sombra interna, llama a [DisableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/disableinnershadoweffect/) en el formato de efectos de la forma.

## **Aplicar un efecto de reflejo**

Para aplicar un efecto de reflejo en Aspose.Slides para C++, puedes agregar una reflexión similar a un espejo a las formas, ajustando parámetros como distancia, transparencia y tamaño. Este efecto mejora la estética de tus presentaciones al dar a las formas un aspecto más pulido y sofisticado. Es fácil de implementar con código sencillo, permitiendo una aplicación rápida en múltiples elementos para un diseño coherente.

Este código C++ muestra cómo aplicar el [efecto de reflejo](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_reflectioneffect/) a una forma:

```cpp
#include <DOM/Effects/IReflection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 100.0f);
auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableReflectionEffect();
auto reflectionEffect = effectFormat->get_ReflectionEffect();
reflectionEffect->set_RectangleAlign(RectangleAlignment::Bottom);
reflectionEffect->set_Direction(90.0f);
reflectionEffect->set_Distance(40);
reflectionEffect->set_BlurRadius(2);

presentation->Save(u"reflection_effect.pptx", SaveFormat::Pptx);
```

![Efecto de reflejo](reflection_effect.png)

## **Aplicar un efecto de resplandor**

Para aplicar un efecto de resplandor a una forma en Aspose.Slides para C++, puedes agregar una aura suave y luminosa alrededor de las formas, ajustando propiedades como el color y el tamaño. Este efecto ayuda a que las formas destaquen y añade un elemento visual atractivo y llamativo a tu presentación. Es fácil de implementar con código mínimo, mejorando el aspecto general de tus diapositivas.

Este código C++ muestra cómo aplicar el [efecto de resplandor](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_gloweffect/) a una forma:

```cpp
#include <DOM/Effects/IGlow.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 100.0f);
auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableGlowEffect();
auto glowEffect = effectFormat->get_GlowEffect();
glowEffect->get_Color()->set_Color(Color::get_Magenta());
glowEffect->set_Radius(15);

presentation->Save(u"glow_effect.pptx", SaveFormat::Pptx);
```

![Efecto de resplandor](glow_effect.png)

## **Aplicar un efecto de bordes suaves**

Para aplicar un efecto de bordes suaves en Aspose.Slides para C++, puedes crear una transición lisa y difuminada alrededor de los bordes de una forma. Este efecto añade un aspecto más sutil y refinado, perfecto para diseños que requieren una apariencia suave y delicada. Puedes ajustar fácilmente parámetros como el radio para lograr el efecto deseado en diversas formas de tu presentación.

Este código C++ muestra cómo aplicar los [bordes suaves](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_softedgeeffect/) a una forma:

```cpp
#include <DOM/Effects/ISoftEdge.h>
#include <DOM/IAutoShape.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 150.0f);
auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableSoftEdgeEffect();
auto softEdgeEffect = effectFormat->get_SoftEdgeEffect();
softEdgeEffect->set_Radius(8);

presentation->Save(u"soft_edges_effect.pptx", SaveFormat::Pptx);
```

![Efecto de bordes suaves](soft_edges_effect.png)

## **Aplicar un efecto de desenfoque**

Utiliza el desenfoque de forma para suavizar el relleno y el contorno de una forma manteniéndola editable. Llama a [SetBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/setblureffect/) en el formato de efectos de la forma. El radio se mide en puntos (1/72 de pulgada): usa un valor no negativo, y los valores mayores producen un desenfoque más intenso. Un radio de cero deja la apariencia sin cambios.

La configuración [Grow](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iblur/get_grow/) controla los límites visibles del efecto. Con `false`, el desenfoque se recorta a los límites pintados originales, incluido el contorno. Con `true`, el desenfoque puede extenderse más allá de esos límites. Ninguna de las dos opciones modifica la posición o dimensiones de la forma.

La comparación a continuación utiliza el mismo relleno, contorno y dimensiones de forma en todo momento. La fila superior usa `grow = false`; la fila inferior usa `grow = true`.

![Rectángulo original comparado con radios de desenfoque de 5 y 15 puntos, con grow desactivado y activado](shape_blur_comparison.png)

Este ejemplo C++ crea un rectángulo naranja con un contorno azul oscuro, aplica un desenfoque de 5 puntos y luego lo actualiza a un desenfoque de 15 puntos llamando de nuevo a [SetBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/setblureffect/). Guarda ambos estados con desenfoque, luego llama a [DisableBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/disableblureffect/) y guarda la forma sin desenfoque.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/FillType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 80.0f, 160.0f, 100.0f);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkBlue());
shape->get_LineFormat()->set_Width(8);

shape->get_EffectFormat()->SetBlurEffect(5, false);
presentation->Save(u"shape_blur_5.pptx", SaveFormat::Pptx);

shape->get_EffectFormat()->SetBlurEffect(15, true);
presentation->Save(u"shape_blur_15.pptx", SaveFormat::Pptx);

shape->get_EffectFormat()->DisableBlurEffect();
presentation->Save(u"shape_blur_removed.pptx", SaveFormat::Pptx);
```

El desenfoque de forma afecta el relleno y el contorno conjuntamente. Un efecto de bordes suaves desvanece los bordes de la forma, mientras que el desenfoque de sombra suaviza solo la sombra. Los efectos de transformación de imagen actúan sobre el contenido de la imagen; este ejemplo aplica el desenfoque directamente al formato de efectos de la forma sin convertirla en una imagen.

## **Preguntas frecuentes**

**¿Puedo aplicar varios efectos a la misma forma?**

Sí, puedes combinar diferentes efectos, como sombra, reflejo y resplandor, en una sola forma para crear una apariencia más dinámica.

**¿A qué formas puedo aplicar efectos?**

Puedes aplicar efectos a diversas formas, incluidas autoshapes, gráficos, tablas, imágenes, objetos SmartArt, objetos OLE y más.

**¿Puedo aplicar efectos a grupos de formas?**

Sí, puedes aplicar efectos a grupos de formas. El efecto se aplicará a todo el grupo.