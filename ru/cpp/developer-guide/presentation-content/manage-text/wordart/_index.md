---
title: WordArt
type: docs
weight: 110
url: /ru/cpp/wordart/
---

## **Что такое WordArt?**
WordArt или Word Art — это функция, которая позволяет применять эффекты к тексту, чтобы выделить его. С помощью WordArt, например, вы можете обвести текст или заполнить его цветом (или градиентом), добавить 3D-эффекты и т. д. Вы также можете наклонять, изгибать и растягивать форму текста.

{{% alert color="primary" %}} 

WordArt позволяет вам рассматривать текст как графический объект. В общем, WordArt состоит из эффектов или специальных модификаций, внесенных в текст, чтобы сделать его более привлекательным или заметным.

{{% /alert %}} 

**WordArt в Microsoft PowerPoint**

Чтобы использовать WordArt в Microsoft PowerPoint, вам нужно выбрать один из предустановленных шаблонов WordArt. Шаблон WordArt — это набор эффектов, который применяется к тексту или его форме.

**WordArt в Aspose.Slides**

В Aspose.Slides для C++ 20.10 мы внедрили поддержку WordArt и улучшили эту функцию в последующих версиях Aspose.Slides для C++.

С помощью Aspose.Slides для C++ вы можете легко создать свой собственный шаблон WordArt (один эффект или комбинация эффектов) на C++ и применить его к тексту.

## Создание простого шаблона WordArt и применение его к тексту

**Используя Aspose.Slides** 

Сначала мы создаем простой текст, используя следующий код на C++: 

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");
```

Теперь мы устанавливаем высоту шрифта текста на большее значение, чтобы эффект был более заметным, с помощью следующего кода:

``` cpp 
auto fontData = System::MakeObject<FontData>(u"Arial Black");
portion->get_PortionFormat()->set_LatinFont(fontData);
portion->get_PortionFormat()->set_FontHeight(36.0f);
```

**Используя Microsoft PowerPoint**

Перейдите в меню эффектов WordArt в Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

Из меню справа вы можете выбрать предустановленный эффект WordArt. Из меню слева вы можете задать настройки для нового WordArt.

Вот некоторые из доступных параметров или опций:

![todo:image_alt_text](image-20200930114015-3.png)

**Используя Aspose.Slides**

Здесь мы применяем цвет паттерна SmallGrid к тексту и добавляем черную текстовую рамку шириной 1 с помощью следующего кода:

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

Получившийся текст:

![todo:image_alt_text](image-20200930114108-4.png)

## Применение других эффектов WordArt

**Используя Microsoft PowerPoint**

Из интерфейса программы вы можете применять эти эффекты к тексту, текстовому блоку, форме или аналогичному элементу:

![todo:image_alt_text](image-20200930114129-5.png)

Например, к тексту можно применить эффекты Тени, Отражения и Сияния; к текстовому блоку — эффекты 3D Формата и 3D Поворота; свойство Мягкие края можно применить к Объекту Фигуры (оно все равно будет действовать, когда никакое свойство 3D Формата не настроено).

### Применение эффектов тени

Здесь мы намерены установить свойства, относящиеся только к тексту. Мы применяем эффект тени к тексту, используя следующий код на C++:

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

API Aspose.Slides поддерживает три типа теней: ВнешниеТени, ВнутренниеТени и ПредустановленныеТени.

С помощью ПредустановленнойТени вы можете применить тень к тексту (используя предустановленные значения).

**Используя Microsoft PowerPoint**

В PowerPoint вы можете использовать один тип тени. Вот пример:

![todo:image_alt_text](image-20200930114225-6.png)

**Используя Aspose.Slides**

Aspose.Slides на самом деле позволяет вам применять два типа теней одновременно: ВнутреннююТень и ПредустановленнуюТень.

**Примечания:**

- Когда используются ВнешняяТень и ПредустановленнаяТень одновременно, применяется только эффект ВнешнейТени.
- Если ВнешняяТень и ВнутреняяТень используются одновременно, полученный или примененный эффект зависит от версии PowerPoint. Например, в PowerPoint 2013 эффект удваивается. Но в PowerPoint 2007 применяется эффект ВнешнейТени.

### Применение отображения к текстам

Мы добавляем отображение к тексту с помощью следующего примера кода на C++:

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

### Применение эффекта сияния к текстам

Мы применяем эффект сияния к тексту, чтобы сделать его более ярким или выделяющимся, с помощью следующего кода:

``` cpp 
auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableGlowEffect();

auto glowEffect = effectFormat->get_GlowEffect();
glowEffect->get_Color()->set_R(255);
glowEffect->get_Color()->get_ColorTransform()->Add(ColorTransformOperation::SetAlpha, 0.54f);
glowEffect->set_Radius(7);
```

Результат операции:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

Вы можете изменять параметры для тени, отображения и сияния. Свойства эффектов устанавливаются для каждой части текста отдельно.

{{% /alert %}} 

### Использование трансформаций в WordArt

Мы используем метод set_Transform (присущий всему блоку текста) с помощью следующего кода:

``` cpp 
textFrame->get_TextFrameFormat()->set_Transform(TextShapeType::ArchUpPour);
```

Результат:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Как Microsoft PowerPoint, так и Aspose.Slides для C++ предоставляют определенное количество предустановленных типов трансформаций.

{{% /alert %}} 

**Используя PowerPoint**

Чтобы получить доступ к предустановленным типам трансформаций, перейдите через: **Формат** -> **Эффект текста** -> **Трансформировать**

**Используя Aspose.Slides**

Чтобы выбрать тип трансформации, используйте перечисление TextShapeType.

### Применение 3D-эффектов к текстам и фигурам

Мы устанавливаем 3D-эффект для текстовой формы, используя следующий образец кода:

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

Получившийся текст и его форма:

![todo:image_alt_text](image-20200930114816-9.png)

Мы применяем 3D-эффект к тексту с помощью следующего кода на C++:

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

Результат операции:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

Применение 3D-эффектов к текстам или их формам и взаимодействие между эффектами основаны на определенных правилах.

Рассмотрим сцену для текста и фигуры, содержащей этот текст. 3D-эффект включает представление 3D-объекта и сцену, на которой был помещен объект.

- Когда сцена установлена и для фигуры, и для текста, сцена фигуры имеет более высокий приоритет — сцена текста игнорируется.
- Когда у фигуры нет своей сцены, но есть 3D-представление, используется сцена текста.
- В противном случае — когда у формы изначально нет 3D-эффекта — форма плоская, и 3D-эффект применяется только к тексту.

Эти описания связаны с методами ThreeDFormat.getLightRig() и ThreeDFormat.getCamera().

{{% /alert %}} 

## **Применение эффектов внешней тени к текстам**
Aspose.Slides для C++ предоставляет классы [**IOuterShadow**](https://reference.aspose.com/slides/cpp/class/aspose.slides.effects.i_outer_shadow) и [**IInnerShadow**](https://reference.aspose.com/slides/cpp/class/aspose.slides.effects.i_inner_shadow), которые позволяют применять эффекты тени к тексту, содержащемуся в TextFrame. Следуйте этим шагам:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Получите ссылку на слайд, используя его индекс.
3. Добавьте АвтоФигуру типа Прямоугольник на слайд.
4. Доступ к TextFrame, связанному с АвтоФигурой.
5. Установите FillType АвтоФигуры в NoFill.
6. Инстанцируйте класс OuterShadow.
7. Установите BlurRadius тени.
8. Установите Direction тени.
9. Установите Distance тени.
10. Установите RectangleAlign на TopLeft.
11. Установите PresetColor тени на Черный.
12. Запишите презентацию как файл PPTX.

Этот пример кода на C++ — реализация вышеуказанных шагов — показывает, как применить эффект внешней тени к тексту:

``` cpp
auto pres = System::MakeObject<Presentation>();
// Получить ссылку на слайд
auto sld = pres->get_Slides()->idx_get(0);

// Добавьте АвтоФигуру типа Прямоугольник
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// Добавьте TextFrame к Прямоугольнику
ashp->AddTextFrame(u"Aspose TextBox");

// Отключите заливку фигуры, если мы хотим получить тень текста
ashp->get_FillFormat()->set_FillType(FillType::NoFill);

// Добавьте внешнюю тень и установите все необходимые параметры
ashp->get_EffectFormat()->EnableOuterShadowEffect();
auto shadow = ashp->get_EffectFormat()->get_OuterShadowEffect();
shadow->set_BlurRadius(4.0);
shadow->set_Direction(45.0f);
shadow->set_Distance(3);
shadow->set_RectangleAlign(RectangleAlignment::TopLeft);
shadow->get_ShadowColor()->set_PresetColor(PresetColor::Black);

// Запишите презентацию на диск
pres->Save(u"pres_out.pptx", SaveFormat::Pptx);
```


## **Применение эффекта внутренней тени к фигурам**
Следуйте этим шагам:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Получите ссылку на слайд.
3. Добавьте АвтоФигуру типа Прямоугольник.
4. Включите эффект InnerShadowEffect.
5. Установите все необходимые параметры.
6. Установите ColorType как Scheme.
7. Установите цвет схемы.
8. Запишите презентацию как файл [PPTX](https://docs.fileformat.com/presentation/pptx/).

Этот пример кода (на основе вышеуказанных шагов) показывает, как добавить соединитель между двумя фигурами на C++:

``` cpp
auto presentation = System::MakeObject<Presentation>();
// Получить ссылку на слайд
auto slide = presentation->get_Slides()->idx_get(0);

// Добавьте АвтоФигуру типа Прямоугольник
auto ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 400.0f, 300.0f);
ashp->get_FillFormat()->set_FillType(FillType::NoFill);

// Добавьте TextFrame к Прямоугольнику
ashp->AddTextFrame(u"Aspose TextBox");
auto port = ashp->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
auto pf = port->get_PortionFormat();
pf->set_FontHeight(50.0f);

// Включите эффект InnerShadowEffect    
auto ef = pf->get_EffectFormat();
ef->EnableInnerShadowEffect();

// Установите все необходимые параметры
auto shadow = ef->get_InnerShadowEffect();
shadow->set_BlurRadius(8.0);
shadow->set_Direction(90.0F);
shadow->set_Distance(6.0);
shadow->get_ShadowColor()->set_B(189);

// Установите ColorType как Scheme
shadow->get_ShadowColor()->set_ColorType(ColorType::Scheme);

// Установите цвет схемы
shadow->get_ShadowColor()->set_SchemeColor(SchemeColor::Accent1);

// Сохраните презентацию
presentation->Save(u"WordArt_out.pptx", SaveFormat::Pptx);
```