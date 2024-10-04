---
title: WordArt
type: docs
weight: 110
url: /cpp/wordart/
---

## **¿Qué es WordArt?**
WordArt o Arte de Texto es una función que te permite aplicar efectos a los textos para hacer que se destaquen. Con WordArt, por ejemplo, puedes contornear un texto o llenarlo con un color (o degradado), agregarle efectos 3D, etc. También puedes inclinar, doblar y estirar la forma de un texto.

{{% alert color="primary" %}} 

WordArt te permite tratar un texto como si fuera un objeto gráfico. En general, WordArt consiste en efectos o modificaciones especiales realizadas a los textos para hacerlos más atractivos o notorios. 

{{% /alert %}} 

**WordArt en Microsoft PowerPoint**

Para usar WordArt en Microsoft PowerPoint, debes seleccionar una de las plantillas de WordArt predefinidas. Una plantilla de WordArt es un conjunto de efectos que se aplican a un texto o su forma.

**WordArt en Aspose.Slides**

En Aspose.Slides para C++ 20.10, implementamos soporte para WordArt y realizamos mejoras a la función en versiones subsiguientes de Aspose.Slides para C++.

Con Aspose.Slides para C++, puedes crear fácilmente tu propia plantilla de WordArt (un efecto o combinación de efectos) en C++ y aplicarla a textos.

## Creando una Plantilla de WordArt Simple y Aplicándola a un Texto

**Usando Aspose.Slides** 

Primero, creamos un texto simple usando este código C++:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");
```

Ahora, configuramos la altura de la fuente del texto a un valor más grande para hacer el efecto más notable a través de este código:

``` cpp 
auto fontData = System::MakeObject<FontData>(u"Arial Black");
portion->get_PortionFormat()->set_LatinFont(fontData);
portion->get_PortionFormat()->set_FontHeight(36.0f);
```

**Usando Microsoft PowerPoint**

Ve al menú de efectos de WordArt en Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

Desde el menú de la derecha, puedes elegir un efecto de WordArt predefinido. Desde el menú de la izquierda, puedes especificar la configuración para un nuevo WordArt.

Estos son algunos de los parámetros o opciones disponibles:

![todo:image_alt_text](image-20200930114015-3.png)

**Usando Aspose.Slides**

Aquí, aplicamos el color del patrón SmallGrid al texto y agregamos un borde de texto negro de 1 de ancho usando este código:

``` cpp 
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Pattern);
fillFormat->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_DarkOrange());
fillFormat->get_PatternFormat()->get_BackColor()->set_Color(Color::get_White());
fillFormat->get_PatternFormat()->set_PatternStyle(PatternStyle::SmallGrid);

auto lineFillFormat = portion->get_PortionFormat()->get_LineFormat()->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
```

El texto resultante:

![todo:image_alt_text](image-20200930114108-4.png)

## Aplicando Otros Efectos de WordArt

**Usando Microsoft PowerPoint**

Desde la interfaz del programa, puedes aplicar estos efectos a un texto, bloque de texto, forma o elemento similar:

![todo:image_alt_text](image-20200930114129-5.png)

Por ejemplo, se pueden aplicar efectos de Sombra, Reflexión y Resplandor a un texto; se pueden aplicar efectos de Formato 3D y Rotación 3D a un bloque de texto; la propiedad Bordes Suaves se puede aplicar a un Objeto Forma (aún tiene un efecto cuando no se establece ninguna propiedad de Formato 3D).

### Aplicando Efectos de Sombra

Aquí, pretendemos establecer las propiedades relacionadas solo con un texto. Aplicamos el efecto de sombra a un texto usando este código en C++:

``` cpp 
auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableOuterShadowEffect();

auto outerShadowEffect = effectFormat->get_OuterShadowEffect();
outerShadowEffect->get_ShadowColor()->set_Color(Color::get_Black());
outerShadowEffect->set_ScaleHorizontal(100);
outerShadowEffect->set_ScaleVertical(65);
outerShadowEffect->set_BlurRadius(4.73);
outerShadowEffect->set_Direction(230.0f);
outerShadowEffect->set_Distance(2);
outerShadowEffect->set_SkewHorizontal(30);
outerShadowEffect->set_SkewVertical(0);
outerShadowEffect->get_ShadowColor()->get_ColorTransform()->Add(ColorTransformOperation::SetAlpha, 0.32f);
```

La API de Aspose.Slides admite tres tipos de sombras: OuterShadow, InnerShadow y PresetShadow.

Con PresetShadow, puedes aplicar una sombra a un texto (usando valores predeterminados).

**Usando Microsoft PowerPoint**

En PowerPoint, puedes usar un tipo de sombra. Aquí hay un ejemplo:

![todo:image_alt_text](image-20200930114225-6.png)

**Usando Aspose.Slides**

Aspose.Slides realmente te permite aplicar dos tipos de sombras a la vez: InnerShadow y PresetShadow.

**Notas:**

- Cuando se usan junto las sombras OuterShadow y PresetShadow, solo se aplica el efecto OuterShadow.
- Si se usan simultáneamente OuterShadow e InnerShadow, el efecto resultante o aplicado depende de la versión de PowerPoint. Por ejemplo, en PowerPoint 2013, el efecto se duplica. Pero en PowerPoint 2007, se aplica el efecto OuterShadow.

### Aplicando Reflexión a los Textos

Añadimos reflexión al texto a través de este ejemplo de código en C++:

``` cpp 
auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableReflectionEffect();

auto reflectionEffect = effectFormat->get_ReflectionEffect();
reflectionEffect->set_BlurRadius(0.5);
reflectionEffect->set_Distance(4.72);
reflectionEffect->set_StartPosAlpha(0.f);
reflectionEffect->set_EndPosAlpha(60.f);
reflectionEffect->set_Direction(90.0f);
reflectionEffect->set_ScaleHorizontal(100);
reflectionEffect->set_ScaleVertical(-100);
reflectionEffect->set_StartReflectionOpacity(60.f);
reflectionEffect->set_EndReflectionOpacity(0.9f);
reflectionEffect->set_RectangleAlign(RectangleAlignment::BottomLeft);
```

### Aplicando Efecto de Resplandor a los Textos

Aplicamos el efecto de resplandor al texto para hacer que brille o se destaque usando este código:

``` cpp 
auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableGlowEffect();

auto glowEffect = effectFormat->get_GlowEffect();
glowEffect->get_Color()->set_R(255);
glowEffect->get_Color()->get_ColorTransform()->Add(ColorTransformOperation::SetAlpha, 0.54f);
glowEffect->set_Radius(7);
```

El resultado de la operación:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

Puedes cambiar los parámetros para sombra, reflexión y resplandor. Las propiedades de los efectos se establecen en cada porción del texto por separado. 

{{% /alert %}} 

### Usando Transformaciones en WordArt

Usamos el método set_Transform (inherente en todo el bloque de texto) a través de este código:

``` cpp 
textFrame->get_TextFrameFormat()->set_Transform(TextShapeType::ArchUpPour);
```

El resultado:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Tanto Microsoft PowerPoint como Aspose.Slides para C++ proporcionan una cierta cantidad de tipos de transformación predefinidos. 

{{% /alert %}} 

**Usando PowerPoint**

Para acceder a los tipos de transformación predefinidos, ve a: **Formato** -> **Efecto de Texto** -> **Transformar**

**Usando Aspose.Slides**

Para seleccionar un tipo de transformación, utiliza el enum TextShapeType. 

### Aplicando efectos 3D a Textos y Formas

Establecemos un efecto 3D a una forma de texto usando este código de muestra:

``` cpp 
auto threeDFormat = autoShape->get_ThreeDFormat();

threeDFormat->get_BevelBottom()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelBottom()->set_Height(10.5);
threeDFormat->get_BevelBottom()->set_Width(10.5);

threeDFormat->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelTop()->set_Height(12.5);
threeDFormat->get_BevelTop()->set_Width(11);

threeDFormat->get_ExtrusionColor()->set_Color(Color::get_Orange());
threeDFormat->set_ExtrusionHeight(6);

threeDFormat->get_ContourColor()->set_Color(Color::get_DarkRed());
threeDFormat->set_ContourWidth(1.5);

threeDFormat->set_Depth(3);

threeDFormat->set_Material(MaterialPresetType::Plastic);

threeDFormat->get_LightRig()->set_Direction(LightingDirection::Top);
threeDFormat->get_LightRig()->set_LightType(LightRigPresetType::Balanced);
threeDFormat->get_LightRig()->SetRotation(0.0f, 0.0f, 40.0f);

threeDFormat->get_Camera()->set_CameraType(CameraPresetType::PerspectiveContrastingRightFacing);
```

El texto resultante y su forma:

![todo:image_alt_text](image-20200930114816-9.png)

Aplicamos un efecto 3D al texto con este código C++:

``` cpp 
auto threeDFormat = textFrame->get_TextFrameFormat()->get_ThreeDFormat();

threeDFormat->get_BevelBottom()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelBottom()->set_Height(3.5);
threeDFormat->get_BevelBottom()->set_Width(3.5);

threeDFormat->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelTop()->set_Height(4);
threeDFormat->get_BevelTop()->set_Width(4);

threeDFormat->get_ExtrusionColor()->set_Color(Color::get_Orange());
threeDFormat->set_ExtrusionHeight(6);

threeDFormat->get_ContourColor()->set_Color(Color::get_DarkRed());
threeDFormat->set_ContourWidth(1.5);

threeDFormat->set_Depth(3);

threeDFormat->set_Material(MaterialPresetType::Plastic);

threeDFormat->get_LightRig()->set_Direction(LightingDirection::Top);
threeDFormat->get_LightRig()->set_LightType(LightRigPresetType::Balanced);
threeDFormat->get_LightRig()->SetRotation(0.0f, 0.0f, 40.0f);

threeDFormat->get_Camera()->set_CameraType(CameraPresetType::PerspectiveContrastingRightFacing);
```

El resultado de la operación:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

La aplicación de efectos 3D a textos o sus formas y las interacciones entre efectos se basan en ciertas reglas. 

Considera una escena para un texto y la forma que contiene ese texto. El efecto 3D contiene la representación del objeto 3D y la escena en la que se colocó el objeto. 

- Cuando la escena está establecida tanto para la figura como para el texto, la escena de la figura tiene una prioridad más alta: la escena del texto se ignora. 
- Cuando la figura no tiene su propia escena, pero tiene representación 3D, se utiliza la escena del texto. 
- De lo contrario, cuando la forma originalmente no tiene efecto 3D, la forma es plana y el efecto 3D solo se aplica al texto. 

Estas descripciones están conectadas a los métodos ThreeDFormat.getLightRig() y ThreeDFormat.getCamera().

{{% /alert %}} 

## **Aplicar Efectos de Sombra Exterior a los Textos**
Aspose.Slides para C++ proporciona las clases [**IOuterShadow**](https://reference.aspose.com/slides/cpp/class/aspose.slides.effects.i_outer_shadow) y [**IInnerShadow**](https://reference.aspose.com/slides/cpp/class/aspose.slides.effects.i_inner_shadow) que te permiten aplicar efectos de sombra a un texto llevado por TextFrame. Sigue estos pasos:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Obtén la referencia de una diapositiva usando su índice.
3. Agrega una AutoShape de tipo Rectángulo a la diapositiva.
4. Accede al TextFrame asociado con la AutoShape.
5. Establece el FillType de la AutoShape en NoFill.
6. Instancia la clase OuterShadow.
7. Establece el BlurRadius de la sombra.
8. Establece la Dirección de la sombra.
9. Establece la Distancia de la sombra.
10. Establece el RectangleAlign en ArribaIzquierda.
11. Establece el ColorPreset de la sombra en Negro.
12. Escribe la presentación como un archivo PPTX.

Este ejemplo de código en C++—una implementación de los pasos anteriores—te muestra cómo aplicar el efecto de sombra exterior a un texto:

``` cpp
auto pres = System::MakeObject<Presentation>();
// Obtener referencia de la diapositiva
auto sld = pres->get_Slides()->idx_get(0);

// Agregar una AutoShape de tipo Rectángulo
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// Agregar TextFrame al Rectángulo
ashp->AddTextFrame(u"Aspose TextBox");

// Desactivar el relleno de la forma en caso de que queramos obtener la sombra del texto
ashp->get_FillFormat()->set_FillType(FillType::NoFill);

// Agregar sombra exterior y establecer todos los parámetros necesarios
ashp->get_EffectFormat()->EnableOuterShadowEffect();
auto shadow = ashp->get_EffectFormat()->get_OuterShadowEffect();
shadow->set_BlurRadius(4.0);
shadow->set_Direction(45.0f);
shadow->set_Distance(3);
shadow->set_RectangleAlign(RectangleAlignment::TopLeft);
shadow->get_ShadowColor()->set_PresetColor(PresetColor::Black);

// Escribir la presentación en el disco
pres->Save(u"pres_out.pptx", SaveFormat::Pptx);
```


## **Aplicar Efecto de Sombra Interior a las Formas**
Sigue estos pasos:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Obtén una referencia de la diapositiva.
3. Agrega una AutoShape de tipo Rectángulo.
4. Activa InnerShadowEffect.
5. Establece todos los parámetros necesarios.
6. Establece el ColorType como Esquema.
7. Establece el Color del Esquema.
8. Escribe la presentación como un archivo [PPTX](https://docs.fileformat.com/presentation/pptx/).

Este código de muestra (basado en los pasos anteriores) te muestra cómo agregar un conector entre dos formas en C++:

``` cpp
auto presentation = System::MakeObject<Presentation>();
// Obtener referencia de una diapositiva
auto slide = presentation->get_Slides()->idx_get(0);

// Agregar una AutoShape de tipo Rectángulo
auto ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 400.0f, 300.0f);
ashp->get_FillFormat()->set_FillType(FillType::NoFill);

// Agregar TextFrame al Rectángulo
ashp->AddTextFrame(u"Aspose TextBox");
auto port = ashp->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
auto pf = port->get_PortionFormat();
pf->set_FontHeight(50.0f);

// Habilitar InnerShadowEffect    
auto ef = pf->get_EffectFormat();
ef->EnableInnerShadowEffect();

// Establecer todos los parámetros necesarios
auto shadow = ef->get_InnerShadowEffect();
shadow->set_BlurRadius(8.0);
shadow->set_Direction(90.0F);
shadow->set_Distance(6.0);
shadow->get_ShadowColor()->set_B(189);

// Establecer ColorType como Esquema
shadow->get_ShadowColor()->set_ColorType(ColorType::Scheme);

// Establecer Color del Esquema
shadow->get_ShadowColor()->set_SchemeColor(SchemeColor::Accent1);

// Guardar Presentación
presentation->Save(u"WordArt_out.pptx", SaveFormat::Pptx);
```