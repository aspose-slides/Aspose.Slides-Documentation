---
title: Animación de Formas
type: docs
weight: 60
url: /cpp/shape-animation/
keywords: "animación de PowerPoint, efecto de animación, aplicar animación, presentación de PowerPoint, C++, CPP, Aspose.Slides para C++"
description: "Aplica animación de PowerPoint en C++"
---

Las animaciones son efectos visuales que se pueden aplicar a textos, imágenes, formas o [gráficos](/slides/cpp/animated-charts/). Dan vida a las presentaciones o a sus constituyentes.

### **¿Por qué usar animaciones en presentaciones?**

Usando animaciones, puedes 

* controlar el flujo de información
* enfatizar puntos importantes
* aumentar el interés o la participación entre tu audiencia
* hacer el contenido más fácil de leer, asimilar o procesar
* llamar la atención de tus lectores o espectadores hacia partes importantes en una presentación

PowerPoint proporciona muchas opciones y herramientas para animaciones y efectos de animación en las categorías de **entrada**, **salida**, **énfasis** y **rutas de movimiento**.

### **Animaciones en Aspose.Slides**

* Aspose.Slides proporciona las clases y tipos que necesitas para trabajar con animaciones bajo el espacio de nombres [Aspose.Slides.Animation](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation),
* Aspose.Slides proporciona más de **150 efectos de animación** bajo la enumeración [EffectType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31). Estos efectos son esencialmente los mismos (o equivalentes) efectos utilizados en PowerPoint.

## **Aplicar animación a TextBox**

Aspose.Slides para C++ te permite aplicar animación al texto en una forma.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/).
2. Obtén la referencia de una diapositiva a través de su índice.
3. Agrega un `rectángulo` [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape).
4. Agrega texto a [IAutoShape.TextFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape#afb267108fea5ee5a213c162c004fcef3).
5. Obtén una secuencia principal de efectos.
6. Agrega un efecto de animación a [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape).
7. Establece la propiedad [TextAnimation.BuildType](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.text_animation#afa90da088213f947baf64f8cdddd18b8) al valor de [BuildType Enumeration](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation#a1b0f1615881ac05b1a72c670a125b8e7).
8. Escribe la presentación en el disco como un archivo PPTX.

Este código de C++ te muestra cómo aplicar el efecto `Desvanecer` a AutoShape y establecer la animación de texto al valor *Por párrafos de 1er nivel*:

```c++
// Instancia una clase de presentación que representa un archivo de presentación.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Agrega una nueva AutoShape con texto
System::SharedPtr<IAutoShape> autoShape =
    sld->get_Shapes()->AddAutoShape(Aspose::Slides::ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 100.0f);

System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"Primer párrafo \nSegundo párrafo \n Tercer párrafo");

// Obtiene la secuencia principal de la diapositiva.
System::SharedPtr<ISequence> sequence = sld->get_Timeline()->get_MainSequence();

// Agrega efecto de animación Desvanecer a la forma
System::SharedPtr<IEffect> effect = sequence->AddEffect(autoShape, Aspose::Slides::Animation::EffectType::Fade,
    Aspose::Slides::Animation::EffectSubtype::None, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Anima el texto de la forma por párrafos de 1er nivel
effect->get_TextAnimation()->set_BuildType(Aspose::Slides::Animation::BuildType::ByLevelParagraphs1);

// Guarda el archivo PPTX en disco
pres->Save(path + u"AnimText_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert color="primary"  %}} 

Además de aplicar animaciones al texto, también puedes aplicar animaciones a un solo [Párrafo](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_paragraph). Consulta [**Texto Animado**](/slides/cpp/animated-text/).

{{% /alert %}} 

## **Aplicar animación a PictureFrame**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/).
2. Obtén la referencia de una diapositiva a través de su índice.
3. Agrega o obtiene un [PictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_picture_frame) en la diapositiva. 
4. Obtén la secuencia principal de efectos.
5. Agrega un efecto de animación al [PictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_picture_frame).
6. Escribe la presentación en el disco como un archivo PPTX.

Este código de C++ te muestra cómo aplicar el efecto `Desplazar` a un marco de imagen:

```c++
// Instancia una clase de presentación que representa un archivo de presentación.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// Carga la imagen que se va a agregar a la colección de imágenes de la presentación
System::SharedPtr<IImage> img = Images::FromFile(u"aspose-logo.jpg");
System::SharedPtr<IPPImage> image = pres->get_Images()->AddImage(img);

// Agrega un marco de imagen a la diapositiva
System::SharedPtr<IPictureFrame> picFrame =
    pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 50.0f, 50.0f, 100.0f, 100.0f, image);

// Obtiene la secuencia principal de la diapositiva.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// Agrega efecto de animación Desplazar desde la izquierda al marco de imagen
System::SharedPtr<IEffect> effect = sequence->AddEffect(picFrame, Aspose::Slides::Animation::EffectType::Fly,
    Aspose::Slides::Animation::EffectSubtype::Left, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Guarda el archivo PPTX en disco
pres->Save(path + u"AnimImage_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Aplicar animación a Forma**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/).
2. Obtén la referencia de una diapositiva a través de su índice.
3. Agrega un `rectángulo` [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape). 
4. Agrega un `Bevel` [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) (cuando este objeto es clicado, la animación se reproduce).
5. Crea una secuencia de efectos en la forma de bisel.
6. Crea un `UserPath` personalizado.
7. Agrega comandos para mover al `UserPath`.
8. Escribe la presentación en el disco como un archivo PPTX.

Este código de C++ te muestra cómo aplicar el efecto `PathFootball` (camino de fútbol) a una forma:

```c++
	// La ruta al directorio del documento.
	const String outPath = u"../out/AnimationsOnShapes_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Carga la presentación
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Accede a la primera diapositiva
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Accede a la colección de formas para la diapositiva seleccionada
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// Crea el efecto PathFootball para una forma existente desde cero.
	SharedPtr<IAutoShape> ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);

	ashp->AddTextFrame(u"Cuadro de Texto Animado");

	// Agrega el efecto de animación PathFootBall
	slide->get_Timeline()->get_MainSequence()->AddEffect(ashp, EffectType::PathFootball,
		EffectSubtype::None, EffectTriggerType::AfterPrevious);

	// Crea algún tipo de "botón".
	SharedPtr<IAutoShape> shapeTrigger = slide->get_Shapes()->AddAutoShape(ShapeType::Bevel, 10, 10, 20, 20);

	// Crea una secuencia de efectos para este botón.
	SharedPtr<ISequence> seqInter = slide->get_Timeline()->get_InteractiveSequences()->Add(shapeTrigger);
	
	 // Crea un camino de usuario personalizado. Nuestro objeto solo se moverá después de que se haga clic en el botón.
	SharedPtr<IEffect> fxUserPath = seqInter->AddEffect(ashp, EffectType::PathUser, EffectSubtype::None, EffectTriggerType::OnClick);

	// Agrega comandos para moverse ya que el camino creado está vacío.
	 SharedPtr<MotionEffect> motionBhv = ExplicitCast<MotionEffect>(fxUserPath->get_Behaviors()->idx_get(0));

	// SharedPtr<PointF> point = MakeObject<PointF >(0.076, 0.59);
	 const PointF point = PointF (0.076, 0.59);
	 System::ArrayPtr<PointF> pts = System::MakeObject<System::Array<PointF>>(1, point);
	 motionBhv->get_Path()->Add(MotionCommandPathType::LineTo, pts, MotionPathPointsType::Auto, true);
	 
	 //PointF point2[1] = { -0.076, -0.59 };
	const  PointF point2 = PointF(-0.076, -0.59 );

	 System::ArrayPtr<PointF> pts2 = System::MakeObject<System::Array<PointF>>(1, point2);
	 motionBhv->get_Path()->Add(MotionCommandPathType::LineTo, pts2, MotionPathPointsType::Auto, false);
	 
	 motionBhv->get_Path()->Add(MotionCommandPathType::End, nullptr, MotionPathPointsType::Auto, false);
	 
	 //Escribe el archivo PPTX en disco
	 pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Obtener los efectos de animación aplicados a la forma**

Puedes decidir averiguar todos los efectos de animación aplicados a una sola forma.

Este código de C++ te muestra cómo obtener todos los efectos aplicados a una forma específica:

```c++
// Instancia una clase de presentación que representa un archivo de presentación.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

System::SharedPtr<ISlide> firstSlide = pres->get_Slides()->idx_get(0);

// Obtiene la secuencia principal de la diapositiva.
System::SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// Obtiene la primera forma en la diapositiva.
System::SharedPtr<IShape> shape = firstSlide->get_Shapes()->idx_get(0);

// Obtiene todos los efectos de animación aplicados a la forma.
System::ArrayPtr<System::SharedPtr<IEffect>> shapeEffects = sequence->GetEffectsByShape(shape);

if (shapeEffects->get_Length() > 0)
{
    System::Console::WriteLine(System::String(u"La forma ") + shape->get_Name() + u" tiene " + shapeEffects->get_Length() + u" efectos de animación.");
}
```

## **Cambiar las propiedades de tiempo del efecto de animación**

Aspose.Slides para C++ te permite cambiar las propiedades de tiempo de un efecto de animación.

Este es el panel de tiempo de animación en Microsoft PowerPoint:

![example1_image](shape-animation.png)

Estas son las correspondencias entre el tiempo de PowerPoint y las propiedades [Effect.Timing](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c):

- La lista desplegable de **Inicio** de tiempo de PowerPoint coincide con la propiedad [Effect.Timing.TriggerType](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.i_timing#a9cec24d555c39e33f0b71dc2210daab3). 
- **Duración** de tiempo de PowerPoint coincide con la propiedad [Effect.Timing.Duration](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.i_timing#a4f5eebdec3b0b2e6d57ee944b5a8a340). La duración de una animación (en segundos) es el tiempo total que tarda la animación en completar un ciclo. 
- **Retraso** de tiempo de PowerPoint coincide con la propiedad [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.i_timing#a947ac2f79c7310d0276ef17999b7214b).

Así es como cambias las propiedades de tiempo del efecto:

1. [Aplica](#apply-animation-to-shape) o obtiene el efecto de animación.
2. Establece nuevos valores para las propiedades [Effect.Timing](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c) que necesites. 
3. Guarda el archivo PPTX modificado.

Este código de C++ demuestra la operación:

```c++
// Instancia una clase de presentación que representa un archivo de presentación.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// Obtiene la secuencia principal de la diapositiva.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// Obtiene el primer efecto de la secuencia principal.
System::SharedPtr<IEffect> effect = sequence->idx_get(0);

// Cambia el TriggerType del efecto para iniciar al hacer clic
effect->get_Timing()->set_TriggerType(Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Cambia la duración del efecto
effect->get_Timing()->set_Duration(3.f);

// Cambia el TriggerDelayTime del efecto
effect->get_Timing()->set_TriggerDelayTime(0.5f);

// Guarda el archivo PPTX en disco
pres->Save(u"AnimExample_changed.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Sonido del efecto de animación**

Aspose.Slides proporciona estas propiedades para permitirte trabajar con sonidos en efectos de animación: 

- [set_Sound()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/effect/set_sound/) 
- [set_StopPreviousSound()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/effect/set_stopprevioussound/) 

### **Agregar sonido al efecto de animación**

Este código de C++ te muestra cómo agregar un sonido al efecto de animación y detenerlo cuando comienza el siguiente efecto:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// Agrega audio a la colección de audio de la presentación
System::SharedPtr<IAudio> effectSound = pres->get_Audios()->AddAudio(System::IO::File::ReadAllBytes(u"sampleaudio.wav"));
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Obtiene la secuencia principal de la diapositiva.
System::SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// Obtiene el primer efecto de la secuencia principal
System::SharedPtr<IEffect> firstEffect = sequence->idx_get(0);

// Verifica el efecto para "Sin Sonido"
if (!firstEffect->get_StopPreviousSound() && firstEffect->get_Sound() == nullptr)
{
    // Agrega sonido para el primer efecto
    firstEffect->set_Sound(effectSound);
}

// Obtiene la primera secuencia interactiva de la diapositiva.
System::SharedPtr<ISequence> interactiveSequence = firstSlide->get_Timeline()->get_InteractiveSequence(0);

// Establece la marca de "Detener sonido anterior" del efecto
interactiveSequence->idx_get(0)->set_StopPreviousSound(true);

// Escribe el archivo PPTX en disco
pres->Save(u"AnimExample_Sound_out.pptx", SaveFormat::Pptx);
```

### **Extraer sonido del efecto de animación**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Obtén la referencia de una diapositiva a través de su índice. 
3. Obtén la secuencia principal de efectos. 
4. Extrae el [set_Sound()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/effect/set_sound/) incrustado en cada efecto de animación. 

Este código de C++ te muestra cómo extraer el sonido incrustado en un efecto de animación:

```c++
// Instancia una clase de presentación que representa un archivo de presentación.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"EffectSound.pptx");
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// Obtiene la secuencia principal de la diapositiva.
System::SharedPtr<ISequence> sequence = slide->get_Timeline()->get_MainSequence();

for (auto&& effect : sequence)
{
    System::SharedPtr<IAudio> sound = effect->get_Sound();

    if (sound == nullptr)
        continue;

    auto audio = sound->get_BinaryData();
}
```

## **Después de la animación**

Aspose.Slides para C++ te permite cambiar la propiedad Después de la animación de un efecto de animación.

Este es el panel de Efecto de animación y el menú extendido en Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

La lista desplegable **Después de la animación** de PowerPoint coincide con estas propiedades:

- La propiedad [set_AfterAnimationType()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_afteranimationtype/) que describe el tipo de animación después:
  * **Más Colores** de PowerPoint coincide con el tipo [AfterAnimationType.Color](https://reference.aspose.com/slides/cpp/aspose.slides.animation/afteranimationtype/);
  * El ítem **No atenuar** de la lista coincide con el tipo [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/cpp/aspose.slides.animation/afteranimationtype/) (tipo de animación después por defecto);
  * El ítem **Ocultar después de la animación** coincide con el tipo [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/cpp/aspose.slides.animation/afteranimationtype/);
  * El ítem **Ocultar en el siguiente clic del mouse** coincide con el tipo [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/cpp/aspose.slides.animation/afteranimationtype/);
- La propiedad [set_AfterAnimationColor()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_afteranimationcolor/) que define un formato de color después de la animación. Esta propiedad funciona en conjunto con el tipo [AfterAnimationType.Color](https://reference.aspose.com/slides/cpp/aspose.slides.animation/afteranimationtype/). Si cambias el tipo a otro, el color de después de la animación se borrará.

Este código de C++ te muestra cómo cambiar un efecto después de la animación:

```c++
// Instancia una clase de presentación que representa un archivo de presentación
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimImage_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Obtiene el primer efecto de la secuencia principal
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// Cambia el tipo de animación posterior a Color
firstEffect->set_AfterAnimationType(AfterAnimationType::Color);

// Establece el color de atenuación después de la animación
firstEffect->get_AfterAnimationColor()->set_Color(System::Drawing::Color::get_AliceBlue());

// Escribe el archivo PPTX en disco
pres->Save(u"AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
```

## **Animar texto**

Aspose.Slides proporciona estas propiedades para permitirte trabajar con el bloque *Animar texto* de un efecto de animación:

- [set_AnimateTextType()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) que describe un tipo de animación de texto del efecto. El texto de la forma puede ser animado:
  - Todo a la vez ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/cpp/aspose.slides.animation/animatetexttype/) tipo)
  - Por palabra ([AnimateTextType.ByWord](https://reference.aspose.com/slides/cpp/aspose.slides.animation/animatetexttype/) tipo)
  - Por letra ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/cpp/aspose.slides.animation/animatetexttype/) tipo)
- [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) establece un retraso entre las partes de texto animadas (palabras o letras). Un valor positivo especifica el porcentaje de duración del efecto. Un valor negativo especifica el retraso en segundos.

Así es como puedes cambiar las propiedades del Efecto de animar texto:

1. [Aplica](#apply-animation-to-shape) o obtiene el efecto de animación.
2. Establece la propiedad [set_BuildType()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/itextanimation/set_buildtype/) al valor [BuildType.AsOneObject](https://reference.aspose.com/slides/cpp/aspose.slides.animation/buildtype/) para desactivar el modo de animación *Por párrafos*.
3. Establece nuevos valores para las propiedades [set_AnimateTextType()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) y [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/).
4. Guarda el archivo PPTX modificado.

Este código de C++ demuestra la operación:

```c++
// Instancia una clase de presentación que representa un archivo de presentación.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimTextBox_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Obtiene el primer efecto de la secuencia principal
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// Cambia el tipo de animación de texto del efecto a "Como un objeto"
firstEffect->get_TextAnimation()->set_BuildType(BuildType::AsOneObject);

// Cambia el tipo de animación de texto del efecto a "Por palabra"
firstEffect->set_AnimateTextType(AnimateTextType::ByWord);

// Establece el retraso entre palabras al 20% de la duración del efecto
firstEffect->set_DelayBetweenTextParts(20.0f);

// Escribe el archivo PPTX en disco
pres->Save(u"AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
```