---
title: Фон презентации
type: docs
weight: 20
url: /ru/cpp/presentation-background/
keywords: "фон PowerPoint, задать фон"
description: "Установите фон в презентации PowerPoint в CPP"
---

Сплошные цвета, градиентные цвета и изображения часто используются в качестве фоновых изображений для слайдов. Вы можете установить фон как для **нормального слайда** (один слайд), так и для **мастер-слайда** (несколько слайдов сразу).

<img src="powerpoint-background.png" alt="powerpoint-background"  />

## **Установить сплошной цвет в качестве фона для нормального слайда**

Aspose.Slides позволяет устанавливать сплошной цвет в качестве фона для конкретного слайда в презентации (даже если эта презентация содержит мастер-слайд). Изменение фона затрагивает только выбранный слайд.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Установите перечисление [BackgroundType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a811de442ed9b0c175aa4dce66d0ba246) для слайда в `OwnBackground`.
3. Установите перечисление [FillType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a73f3a585b379b3df191d07931378e40a) для фона слайда в `Solid`.
4. Используйте свойство [SolidFillColor](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format#a13c48eebf434d92f4c0058796ea15810), предоставляемое [FillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format), чтобы указать сплошной цвет для фона.
5. Сохраните изменённую презентацию.

Этот код на C++ показывает, как установить сплошной цвет (синий) в качестве фона для нормального слайда:

```c++
// Путь к директории документов.

	const String OutPath = L"../out/SetSlideBackgroundNormal_out.pptx";

	// Создает экземпляр класса Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Устанавливает цвет фона для первого ISlide в синий
	pres->get_Slides()->idx_get(0)->get_Background()->set_Type(BackgroundType::OwnBackground);
	pres->get_Slides()->idx_get(0)->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
	pres->get_Slides()->idx_get(0)->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());

	// Записывает презентацию на диск
	pres->Save(OutPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **Установить сплошной цвет в качестве фона для мастер-слайда**

Aspose.Slides позволяет установить сплошной цвет в качестве фона для мастер-слайда в презентации. Мастер-слайд действует как шаблон, который содержит и контролирует параметры форматирования для всех слайдов. Поэтому, когда вы выбираете сплошной цвет в качестве фона для мастер-слайда, этот новый фон будет использоваться для всех слайдов.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Установите перечисление [BackgroundType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a811de442ed9b0c175aa4dce66d0ba246) для мастер-слайда (`Masters`) в `OwnBackground`.
3. Установите перечисление [FillType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a73f3a585b379b3df191d07931378e40a) для фона мастер-слайда в `Solid`.
4. Используйте свойство [SolidFillColor](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format#a13c48eebf434d92f4c0058796ea15810), предоставляемое [FillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format), чтобы указать сплошной цвет для фона.
5. Сохраните изменённую презентацию.

Этот код на C++ показывает, как установить сплошной цвет (лесной зелёный) в качестве фона для мастер-слайда в презентации:

```c++
// Путь к директории документов.

	const String OutPath = L"../out/SetSlideBackgroundMaster_out.pptx";

	// Создает экземпляр класса Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Устанавливает цвет фона для мастер ISlide в лесной зелёный
	pres->get_Masters()->idx_get(0)->get_Background()->set_Type(BackgroundType::OwnBackground);
	pres->get_Masters()->idx_get(0)->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
	pres->get_Masters()->idx_get(0)->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_ForestGreen());

	// Записывает презентацию на диск
	pres->Save(OutPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **Установить градиентный цвет в качестве фона для слайда**

Градиент — это графический эффект, основанный на постепенном изменении цвета. Градиентные цвета, используемые в качестве фонов для слайдов, придают презентациям художественный и профессиональный вид. Aspose.Slides позволяет установить градиентный цвет в качестве фона для слайдов в презентациях.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Установите перечисление [BackgroundType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a811de442ed9b0c175aa4dce66d0ba246) для слайда в `OwnBackground`.
3. Установите.enumeration [FillType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a73f3a585b379b3df191d07931378e40a) для фона мастер-слайда в `Gradient`.
4. Используйте свойство [GradientFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format#aa686ab9c84e7e20e65dfe73458f1a823), предоставляемое [FillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format), чтобы указать ваши предпочтительные настройки градиента.
5. Сохраните изменённую презентацию.

Этот код на C++ показывает, как установить градиентный цвет в качестве фона для слайда:

```c++
// Создает экземпляр класса Presentation
auto pres = System::MakeObject<Presentation>(u"SetBackgroundToGradient.pptx");

// Применить эффект градиента к фону
pres->get_Slides()->idx_get(0)->get_Background()->set_Type(BackgroundType::OwnBackground);
pres->get_Slides()->idx_get(0)->get_Background()->get_FillFormat()->set_FillType(FillType::Gradient);
pres->get_Slides()->idx_get(0)->get_Background()->get_FillFormat()->get_GradientFormat()->set_TileFlip(TileFlip::FlipBoth);

// Записывает презентацию на диск
pres->Save(u"ContentBG_Grad_out.pptx", SaveFormat::Pptx);
```

## **Установить изображение в качестве фона для слайда**

Помимо сплошных и градиентных цветов, Aspose.Slides также позволяет устанавливать изображения в качестве фона для слайдов в презентациях.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Установите перечисление [BackgroundType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a811de442ed9b0c175aa4dce66d0ba246) для слайда в `OwnBackground`.
3. Установите перечисление [FillType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a73f3a585b379b3df191d07931378e40a) для фона мастер-слайда в `Picture`.
4. Загрузите изображение, которое вы хотите использовать в качестве фона слайда.
5. Добавьте изображение в коллекцию изображений презентации.
6. Используйте свойство [PictureFillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format#a7f2b7e6afce822667cecd3e80336bfae), предоставляемое [FillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format), чтобы установить изображение в качестве фона.
7. Сохраните изменённую презентацию.

Этот код на C++ показывает, как установить изображение в качестве фона для слайда:

```c++
// Путь к директории документов.

const String templatePath = L"../templates/SetImageAsBackground.pptx";
const String imagePath = L"../templates/Tulips.jpg";
const String outPath = L"../out/ContentBG_Img_out.pptx";

// Создает экземпляр класса Presentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Устанавливает условия для фонового изображения
pres->get_Slides()->idx_get(0)->get_Background()->set_Type(BackgroundType::OwnBackground);
pres->get_Slides()->idx_get(0)->get_Background()->get_FillFormat()->set_FillType(FillType::Picture);
pres->get_Slides()->idx_get(0)->get_Background()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

// Загружает изображение
auto image = Images::FromFile(imagePath);

// Добавляет изображение в коллекцию изображений презентации
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

pres->get_Slides()->idx_get(0)->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(imgx);

// Записывает презентацию на диск
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **Изменение прозрачности фонового изображения**

Вы можете захотеть изменить прозрачность фонового изображения слайда, чтобы содержимое слайда выделялось. Этот код на C++ показывает, как изменить прозрачность фонового изображения слайда:

```c++
int32_t transparencyValue = 30;
// например
// Получает коллекцию операций преобразования изображения
auto imageTransform = slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->get_ImageTransform();
// Находит эффект прозрачности с фиксированным процентом.
System::SharedPtr<AlphaModulateFixed> transparencyOperation;
for (auto&& operation : imageTransform)
{
    if (System::ObjectExt::Is<AlphaModulateFixed>(operation))
    {
        transparencyOperation = System::ExplicitCast<AlphaModulateFixed>(operation);
        break;
    }
}
// Устанавливает новое значение прозрачности.
if (transparencyOperation == nullptr)
{
    imageTransform->AddAlphaModulateFixedEffect(100.0f - transparencyValue);
}
else
{
    transparencyOperation->set_Amount(100.0f - transparencyValue);
}
```

## **Получить значение фона слайда**

Aspose.Slides предоставляет интерфейс [IBackgroundEffectiveData](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_background_effective_data/), который позволяет получить эффективные значения фонов слайдов. Этот интерфейс содержит информацию об эффективном [FillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_background_effective_data#a097ba368423bf4a9ab7a6a61870bfc8e) и эффективном [EffectFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_background_effective_data#a446676281ac4195cb7eb989e4a8110f8).

Используя свойство [Background](https://reference.aspose.com/slides/cpp/class/aspose.slides.base_slide#ac12d4a7683bf6fa20b3eef387219cf16) из класса [BaseSlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.base_slide/), вы можете получить эффективное значение фона слайда.

Этот код на C++ показывает, как получить эффективное значение фона слайда:

```c++
// Создает экземпляр класса Presentation
const String templatePath = u"../templates/SamplePresentation.pptx";
	

	auto pres = System::MakeObject<Presentation>(templatePath);
	System::SharedPtr<IBackgroundEffectiveData> effBackground = pres->get_Slides()->idx_get(0)->CreateBackgroundEffective();
	if (effBackground->get_FillFormat()->get_FillType() == Aspose::Slides::FillType::Solid)
	{
		System::Console::WriteLine(System::String(u"Цвет заливки: ") + effBackground->get_FillFormat()->get_SolidFillColor());
	}
	else
	{
		System::Console::WriteLine(System::String(u"Тип заливки: ") + System::ObjectExt::ToString(effBackground->get_FillFormat()->get_FillType()));
	}
```