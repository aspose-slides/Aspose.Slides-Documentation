---
title: Создание и применение эффектов WordArt в C++
linktitle: WordArt
type: docs
weight: 110
url: /ru/cpp/wordart/
keywords:
- WordArt
- создать WordArt
- шаблон WordArt
- эффект WordArt
- эффект тени
- эффект отображения
- эффект свечения
- трансформация WordArt
- 3D-эффект
- эффект внешней тени
- эффект внутренней тени
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Создавайте и настраивайте эффекты WordArt в Aspose.Slides для C++. Это пошаговое руководство помогает разработчикам улучшать презентации с профессиональным текстом на C++."
---

## **О WordArt?**
WordArt или Word Art — это возможность, позволяющая применять эффекты к тексту, чтобы он выделялся. С помощью WordArt, например, можно обвести текст контуром или заполнить его цветом (или градиентом), добавить 3D‑эффекты и т.д. Также можно наклонять, изгибать и растягивать форму текста. 

{{% alert color="primary" %}} 

WordArt позволяет работать с текстом так же, как с графическим объектом. Как правило, WordArt представляет собой набор эффектов или специальных модификаций, применяемых к тексту, чтобы сделать его более привлекательным или заметным. 

{{% /alert %}} 

**WordArt в Microsoft PowerPoint**

Чтобы использовать WordArt в Microsoft PowerPoint, необходимо выбрать один из предопределённых шаблонов WordArt. Шаблон WordArt — это набор эффектов, который применяется к тексту или его форме. 

**WordArt в Aspose.Slides**

В Aspose.Slides для C++ 20.10 мы внедрили поддержку WordArt и в последующих версиях Aspose.Slides для C++ улучшили эту функцию. 

С помощью Aspose.Slides для C++ вы можете легко создать собственный шаблон WordArt (один эффект или комбинацию эффектов) на C++ и применить его к текстам. 

## **Создание простого шаблона WordArt и применение его к тексту**

**Использование Aspose.Slides** 

Сначала мы создаём простой текст с помощью следующего кода C++: 
``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");
```


Затем мы устанавливаем высоту шрифта текста на большее значение, чтобы эффект был более заметен, с помощью следующего кода:
``` cpp 
auto fontData = System::MakeObject<FontData>(u"Arial Black");
portion->get_PortionFormat()->set_LatinFont(fontData);
portion->get_PortionFormat()->set_FontHeight(36.0f);
```


**Использование Microsoft PowerPoint**

Откройте меню эффектов WordArt в Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

В меню справа вы можете выбрать предопределённый эффект WordArt. В меню слева можно задать настройки нового WordArt. 

Ниже представлены некоторые доступные параметры или опции:

![todo:image_alt_text](image-20200930114015-3.png)

**Использование Aspose.Slides**

Здесь мы применяем цвет узора SmallGrid к тексту и добавляем чёрную границу шириной 1 с помощью следующего кода:
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

## **Применение остальных эффектов WordArt**

**Использование Microsoft PowerPoint**

В интерфейсе программы вы можете применять эти эффекты к тексту, текстовому блоку, фигуре или аналогичному элементу:

![todo:image_alt_text](image-20200930114129-5.png)

Например, к тексту можно применить эффекты Тень, Отражение и Сияние; к текстовому блоку — эффекты 3D‑формат и 3D‑поворот; к объекту Shape можно применить свойство Мягкие края (оно остаётся активным, даже если свойство 3D‑формат не задано). 

### **Применение теневых эффектов к тексту**

Здесь мы планируем задать свойства, относящиеся только к тексту. Мы применяем теневой эффект к тексту с помощью следующего кода на C++:
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


API Aspose.Slides поддерживает три типа теней: OuterShadow, InnerShadow и PresetShadow. 

С помощью PresetShadow можно применить тень к тексту (используя предустановленные значения). 

**Использование Microsoft PowerPoint**

В PowerPoint можно использовать один тип тени. Пример:

![todo:image_alt_text](image-20200930114225-6.png)

**Использование Aspose.Slides**

Aspose.Slides фактически позволяет одновременно применить два типа теней: InnerShadow и PresetShadow.

**Примечания:**

- При одновременном использовании OuterShadow и PresetShadow применяется только эффект OuterShadow. 
- Если одновременно использовать OuterShadow и InnerShadow, результирующий эффект зависит от версии PowerPoint. Например, в PowerPoint 2013 эффект удваивается, а в PowerPoint 2007 применяется OuterShadow. 

### **Применение отражающих эффектов**

Мы добавляем отражение к тексту с помощью следующего примера кода на C++:
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


### **Применение сияния**

Мы применяем эффект сияния к тексту, чтобы он блестел или выделялся, используя следующий код:
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

Вы можете изменять параметры тени, отображения и сияния. Свойства эффектов задаются отдельно для каждой части текста. 

{{% /alert %}} 

### **Использование трансформаций в WordArt**

Мы используем метод set_Transform (применяемый ко всему блоку текста) с помощью следующего кода:
``` cpp 
textFrame->get_TextFrameFormat()->set_Transform(TextShapeType::ArchUpPour);
```


Результат:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

И Microsoft PowerPoint, и Aspose.Slides для C++ предоставляют определённое количество предопределённых типов трансформаций. 

{{% /alert %}} 

**Использование PowerPoint**

Чтобы открыть предопределённые типы трансформаций, перейдите: **Format** → **TextEffect** → **Transform**

**Использование Aspose.Slides**

Чтобы выбрать тип трансформации, используйте перечисление TextShapeType. 

### **Применение 3D‑эффектов к тексту и фигурам**

Мы задаём 3D‑эффект для текстовой фигуры с помощью следующего примера кода:
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

Мы применяем 3D‑эффект к тексту с помощью следующего кода на C++:
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

Применение 3D‑эффектов к тексту или его фигурам и взаимодействие между эффектами основаны на определённых правилах.

Рассмотрим сцену для текста и фигуры, содержащей этот текст. 3D‑эффект включает представление 3D‑объекта и сцену, в которой объект размещён.

- Когда сцена задаётся как для фигуры, так и для текста, приоритет имеет сцена фигуры — сцена текста игнорируется. 
- Когда у фигуры нет собственной сцены, но есть 3D‑представление, используется сцена текста. 
- В остальных случаях — когда у фигуры изначально нет 3D‑эффекта — фигура остаётся плоской, и 3D‑эффект применяется только к тексту. 

Эти описания связаны с методами ThreeDFormat.getLightRig() и ThreeDFormat.getCamera(). 

{{% /alert %}} 

## **Применение внешних теней к фигурам**
Aspose.Slides для C++ предоставляет классы [**IOuterShadow**](https://reference.aspose.com/slides/cpp/class/aspose.slides.effects.i_outer_shadow) и [**IInnerShadow**](https://reference.aspose.com/slides/cpp/class/aspose.slides.effects.i_inner_shadow), позволяющие применять теневые эффекты к тексту, содержащемуся в TextFrame. Выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation). 
2. Получите ссылку на слайд, используя его индекс. 
3. Добавьте к слайду AutoShape типа Rectangle. 
4. Получите доступ к TextFrame, связанному с AutoShape. 
5. Установите свойство FillType AutoShape в значение NoFill. 
6. Создайте экземпляр класса OuterShadow. 
7. Установите BlurRadius тени. 
8. Установите Direction тени. 
9. Установите Distance тени. 
10. Установите RectanglelAlign в TopLeft. 
11. Установите PresetColor тени в Black. 
12. Сохраните презентацию в файл PPTX. 

Этот пример кода на C++ — реализация вышеописанных шагов — демонстрирует, как применить внешний теневой эффект к тексту:
``` cpp
auto pres = System::MakeObject<Presentation>();
// Получить ссылку на слайд
auto sld = pres->get_Slides()->idx_get(0);

// Добавить AutoShape типа Rectangle
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// Добавить TextFrame к прямоугольнику
ashp->AddTextFrame(u"Aspose TextBox");

// Отключить заливку фигуры, если требуется получить тень текста
ashp->get_FillFormat()->set_FillType(FillType::NoFill);

// Добавить внешнюю тень и установить все необходимые параметры
ashp->get_EffectFormat()->EnableOuterShadowEffect();
auto shadow = ashp->get_EffectFormat()->get_OuterShadowEffect();
shadow->set_BlurRadius(4.0);
shadow->set_Direction(45.0f);
shadow->set_Distance(3);
shadow->set_RectangleAlign(RectangleAlignment::TopLeft);
shadow->get_ShadowColor()->set_PresetColor(PresetColor::Black);

// Сохранить презентацию на диск
pres->Save(u"pres_out.pptx", SaveFormat::Pptx);
```


## **Применение внутренних теней к фигурам**
Выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation). 
2. Получите ссылку на слайд. 
3. Добавьте AutoShape типа Rectangle. 
4. Включите InnerShadowEffect. 
5. Установите все необходимые параметры. 
6. Установите ColorType в значение Scheme. 
7. Установите Scheme Color. 
8. Сохраните презентацию в файл [PPTX](https://docs.fileformat.com/presentation/pptx/). 

Этот пример кода (основанный на вышеуказанных шагах) показывает, как добавить соединитель между двумя фигурами на C++:
```cpp
auto presentation = System::MakeObject<Presentation>();
// Получить ссылку на слайд
auto slide = presentation->get_Slides()->idx_get(0);

// Add an AutoShape of Rectangle type
// Добавить AutoShape типа Rectangle
auto ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 400.0f, 300.0f);
ashp->get_FillFormat()->set_FillType(FillType::NoFill);

// Add TextFrame to the Rectangle
// Добавить TextFrame к прямоугольнику
ashp->AddTextFrame(u"Aspose TextBox");
auto port = ashp->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
auto pf = port->get_PortionFormat();
pf->set_FontHeight(50.0f);

// Enable InnerShadowEffect    
// Включить InnerShadowEffect
auto ef = pf->get_EffectFormat();
ef->EnableInnerShadowEffect();

// Set all necessary parameters
// Установить все необходимые параметры
auto shadow = ef->get_InnerShadowEffect();
shadow->set_BlurRadius(8.0);
shadow->set_Direction(90.0F);
shadow->set_Distance(6.0);
shadow->get_ShadowColor()->set_B(189);

// Set ColorType as Scheme
// Установить ColorType как Scheme
shadow->get_ShadowColor()->set_ColorType(ColorType::Scheme);

// Set Scheme Color
// Установить Scheme Color
shadow->get_ShadowColor()->set_SchemeColor(SchemeColor::Accent1);

// Save Presentation
// Сохранить презентацию
presentation->Save(u"WordArt_out.pptx", SaveFormat::Pptx);
```


## **FAQ**

**Можно ли использовать эффекты WordArt с разными шрифтами или скриптами (например, арабский, китайский)?**

Да, Aspose.Slides поддерживает Unicode и работает со всеми основными шрифтами и скриптами. Эффекты WordArt, такие как тень, заливка и контур, можно применять независимо от языка, хотя доступность шрифтов и их рендеринг могут зависеть от системных шрифтов.

**Можно ли применять эффекты WordArt к элементам шаблона слайда?**

Да, вы можете применять эффекты WordArt к фигурам на слайдах‑шаблонах, включая заполнители заголовков, колонтитулы или фоновые тексты. Изменения, внесённые в шаблон, отражаются во всех связанных слайдах.

**Влияют ли эффекты WordArt на размер файла презентации?**

Слегка. Эффекты WordArt, такие как тени, сияние и градиентные заливки, могут незначительно увеличить размер файла из‑за добавления метаданных форматирования, но разница обычно пренебрежимо мала.

**Можно ли просмотреть результат эффектов WordArt без сохранения презентации?**

Да, вы можете отрисовать слайды с WordArt в изображения (например, PNG, JPEG), используя метод `GetImage` из интерфейсов [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) или [ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/). Это позволяет предварительно просмотреть результат в памяти или на экране до сохранения или экспорта полной презентации.