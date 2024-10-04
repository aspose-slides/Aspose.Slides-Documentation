---
title: Fondo de Presentación
type: docs
weight: 20
url: /cpp/presentation-background/
keywords: "fondo de PowerPoint, establecer fondo"
description: "Establecer fondo en la presentación de PowerPoint en CPP"
---

Los colores sólidos, los colores degradados y las imágenes se utilizan a menudo como imágenes de fondo para las diapositivas. Puedes establecer el fondo ya sea para una **diapositiva normal** (diapositiva única) o **diapositiva maestra** (varias diapositivas a la vez).

<img src="powerpoint-background.png" alt="powerpoint-background"  />

## **Establecer Color Sólido como Fondo para Diapositiva Normal**

Aspose.Slides te permite establecer un color sólido como fondo de una diapositiva específica en una presentación (incluso si esa presentación contiene una diapositiva maestra). El cambio de fondo afecta solo a la diapositiva seleccionada.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Establece el enum [BackgroundType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a811de442ed9b0c175aa4dce66d0ba246) para la diapositiva en `OwnBackground`.
3. Establece el enum [FillType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a73f3a585b379b3df191d07931378e40a) para el fondo de la diapositiva en `Solid`.
4. Utiliza la propiedad [SolidFillColor](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format#a13c48eebf434d92f4c0058796ea15810) expuesta por [FillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format) para especificar un color sólido para el fondo.
5. Guarda la presentación modificada.

Este código C++ te muestra cómo establecer un color sólido (azul) como fondo para una diapositiva normal:

```c++
// La ruta al directorio de documentos.

	const String OutPath = L"../out/SetSlideBackgroundNormal_out.pptx";

	// Crea una instancia de la clase Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Establece el color de fondo para la primera ISlide en Azul
	pres->get_Slides()->idx_get(0)->get_Background()->set_Type(BackgroundType::OwnBackground);
	pres->get_Slides()->idx_get(0)->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
	pres->get_Slides()->idx_get(0)->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());

	// Escribe la presentación en disco
	pres->Save(OutPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **Establecer Color Sólido como Fondo para Diapositiva Maestra**

Aspose.Slides te permite establecer un color sólido como fondo para la diapositiva maestra en una presentación. La diapositiva maestra actúa como una plantilla que contiene y controla la configuración de formato para todas las diapositivas. Por lo tanto, cuando seleccionas un color sólido como fondo para la diapositiva maestra, ese nuevo fondo se utilizará para todas las diapositivas.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Establece el enum [BackgroundType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a811de442ed9b0c175aa4dce66d0ba246) para la diapositiva maestra (`Masters`) en `OwnBackground`.
3. Establece el enum [FillType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a73f3a585b379b3df191d07931378e40a) para el fondo de la diapositiva maestra en `Solid`.
4. Utiliza la propiedad [SolidFillColor](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format#a13c48eebf434d92f4c0058796ea15810) expuesta por [FillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format) para especificar un color sólido para el fondo.
5. Guarda la presentación modificada.

Este código C++ te muestra cómo establecer un color sólido (verde bosque) como fondo para una diapositiva maestra en una presentación:

```c++
// La ruta al directorio de documentos.

	const String OutPath = L"../out/SetSlideBackgroundMaster_out.pptx";

	// Crea una instancia de la clase Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Establece el color de fondo para la Master ISlide en Verde Bosque
	pres->get_Masters()->idx_get(0)->get_Background()->set_Type(BackgroundType::OwnBackground);
	pres->get_Masters()->idx_get(0)->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
	pres->get_Masters()->idx_get(0)->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_ForestGreen());

	// Escribe la presentación en disco
	pres->Save(OutPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **Establecer Color Degradado como Fondo para Diapositiva**

Un degradado es un efecto gráfico basado en un cambio gradual de color. Los colores degradados, cuando se utilizan como fondos para diapositivas, hacen que las presentaciones se vean artísticas y profesionales. Aspose.Slides te permite establecer un color degradado como fondo para las diapositivas en las presentaciones.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Establece el enum [BackgroundType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a811de442ed9b0c175aa4dce66d0ba246) para la diapositiva en `OwnBackground`.
3. Establece el enum [FillType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a73f3a585b379b3df191d07931378e40a) para el fondo de la diapositiva en `Gradient`.
4. Utiliza la propiedad [GradientFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format#aa686ab9c84e7e20e65dfe73458f1a823) expuesta por [FillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format) para especificar tu configuración de degradado preferida.
5. Guarda la presentación modificada.

Este código C++ te muestra cómo establecer un color degradado como fondo para una diapositiva:

```c++
// Crea una instancia de la clase Presentation
auto pres = System::MakeObject<Presentation>(u"SetBackgroundToGradient.pptx");

// Aplica efecto de degradado al fondo
pres->get_Slides()->idx_get(0)->get_Background()->set_Type(BackgroundType::OwnBackground);
pres->get_Slides()->idx_get(0)->get_Background()->get_FillFormat()->set_FillType(FillType::Gradient);
pres->get_Slides()->idx_get(0)->get_Background()->get_FillFormat()->get_GradientFormat()->set_TileFlip(TileFlip::FlipBoth);

// Escribe la presentación en disco
pres->Save(u"ContentBG_Grad_out.pptx", SaveFormat::Pptx);
```

## **Establecer Imagen como Fondo para Diapositiva**

Además de los colores sólidos y los colores degradados, Aspose.Slides también te permite establecer imágenes como fondo para las diapositivas en las presentaciones.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Establece el enum [BackgroundType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a811de442ed9b0c175aa4dce66d0ba246) para la diapositiva en `OwnBackground`.
3. Establece el enum [FillType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a73f3a585b379b3df191d07931378e40a) para el fondo de la diapositiva maestra en `Picture`.
4. Carga la imagen que deseas usar como fondo de la diapositiva.
5. Agrega la imagen a la colección de imágenes de la presentación.
6. Utiliza la propiedad [PictureFillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format#a7f2b7e6afce822667cecd3e80336bfae) expuesta por [FillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format) para establecer la imagen como el fondo.
7. Guarda la presentación modificada.

Este código C++ te muestra cómo establecer una imagen como fondo para una diapositiva:

```c++
// La ruta al directorio de documentos.

const String templatePath = L"../templates/SetImageAsBackground.pptx";
const String imagePath = L"../templates/Tulips.jpg";
const String outPath = L"../out/ContentBG_Img_out.pptx";

// Crea una instancia de la clase Presentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Establece condiciones para la imagen de fondo
pres->get_Slides()->idx_get(0)->get_Background()->set_Type(BackgroundType::OwnBackground);
pres->get_Slides()->idx_get(0)->get_Background()->get_FillFormat()->set_FillType(FillType::Picture);
pres->get_Slides()->idx_get(0)->get_Background()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

// Carga la imagen
auto image = Images::FromFile(imagePath);

// Agrega la imagen a la colección de imágenes de la presentación
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

pres->get_Slides()->idx_get(0)->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(imgx);

// Escribe la presentación en disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

### **Cambiar Transparencia de la Imagen de Fondo**

Es posible que desees ajustar la transparencia de la imagen de fondo de una diapositiva para que el contenido de la diapositiva se destaque. Este código C++ te muestra cómo cambiar la transparencia para una imagen de fondo de diapositiva:

```c++
int32_t transparencyValue = 30;
// por ejemplo
// Obtiene una colección de operaciones de transformación de imagen
auto imageTransform = slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->get_ImageTransform();
// Busca un efecto de transparencia con porcentaje fijo.
System::SharedPtr<AlphaModulateFixed> transparencyOperation;
for (auto&& operation : imageTransform)
{
    if (System::ObjectExt::Is<AlphaModulateFixed>(operation))
    {
        transparencyOperation = System::ExplicitCast<AlphaModulateFixed>(operation);
        break;
    }
}
// Establece el nuevo valor de transparencia.
if (transparencyOperation == nullptr)
{
    imageTransform->AddAlphaModulateFixedEffect(100.0f - transparencyValue);
}
else
{
    transparencyOperation->set_Amount(100.0f - transparencyValue);
}
```

## **Obtener Valor del Fondo de Diapositiva**

Aspose.Slides proporciona la interfaz [IBackgroundEffectiveData](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_background_effective_data/) para permitirte obtener los valores efectivos de los fondos de las diapositivas. Esta interfaz contiene información sobre el [FillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_background_effective_data#a097ba368423bf4a9ab7a6a61870bfc8e) efectivo y el [EffectFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_background_effective_data#a446676281ac4195cb7eb989e4a8110f8).

Utilizando la propiedad [Background](https://reference.aspose.com/slides/cpp/class/aspose.slides.base_slide#ac12d4a7683bf6fa20b3eef387219cf16) de la clase [BaseSlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.base_slide/), puedes obtener el valor efectivo para un fondo de diapositiva.

Este código C++ te muestra cómo obtener el valor efectivo del fondo de una diapositiva:

```c++
// Crea una instancia de la clase Presentation
const String templatePath = u"../templates/SamplePresentation.pptx";

	auto pres = System::MakeObject<Presentation>(templatePath);
	System::SharedPtr<IBackgroundEffectiveData> effBackground = pres->get_Slides()->idx_get(0)->CreateBackgroundEffective();
	if (effBackground->get_FillFormat()->get_FillType() == Aspose::Slides::FillType::Solid)
	{
		System::Console::WriteLine(System::String(u"Color de relleno: ") + effBackground->get_FillFormat()->get_SolidFillColor());
	}
	else
	{
		System::Console::WriteLine(System::String(u"Tipo de relleno: ") + System::ObjectExt::ToString(effBackground->get_FillFormat()->get_FillType()));
	}
```