---
title: WordArt
type: docs
weight: 110
url: /ru/net/wordart/
keywords: "WordArt, Word Art, Создать WordArt, шаблон WordArt, эффекты WordArt, эффекты теней, эффекты отображения, эффекты свечения, трансформации WordArt, 3D эффекты, эффекты внешней тени, эффекты внутренней тени, C#, Csharp, Aspose.Slides для .NET"
description: "Добавьте, изменяйте и управляйте WordArt и эффектами в презентациях PowerPoint на C# или Aspose.Slides для .NET"
---

## **Что такое WordArt?**
WordArt или Word Art — это функция, которая позволяет применять эффекты к текстам, чтобы они выделялись. С WordArt, например, вы можете обвести текст или заполнить его цветом (или градиентом), добавить к нему 3D эффекты и т. д. Вы также можете наклонять, гнуть и растягивать форму текста.

{{% alert color="primary" %}} 

WordArt позволяет вам обращаться с текстом так же, как с графическим объектом. WordArt состоит из эффектов или специальных модификаций, внесенных в тексты, чтобы сделать их более привлекательными или заметными.

{{% /alert %}} 

**WordArt в Microsoft PowerPoint**

Чтобы использовать WordArt в Microsoft PowerPoint, вам нужно выбрать один из предопределенных шаблонов WordArt. Шаблон WordArt — это набор эффектов, который применяется к тексту или его форме.

**WordArt в Aspose.Slides**

В Aspose.Slides для .NET 20.10 мы реализовали поддержку WordArt и внесли улучшения в эту функцию в последующих выпусках Aspose.Slides для .NET.

С Aspose.Slides для .NET вы можете легко создать свой собственный шаблон WordArt (один эффект или комбинация эффектов) на C# и применить его к текстам.

## Создание простого шаблона WordArt и применение его к тексту

**С использованием Aspose.Slides** 

Сначала мы создаем простой текст, используя этот код на C#: 

``` csharp 
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.TextFrame;

    Portion portion = (Portion)textFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
}
```
Теперь мы устанавливаем высоту шрифта текста на большее значение, чтобы сделать эффект более заметным, используя этот код:

``` csharp 
FontData fontData = new FontData("Arial Black");
portion.PortionFormat.LatinFont = fontData;
portion.PortionFormat.FontHeight = 36;
```

**С использованием Microsoft PowerPoint**

Перейдите в меню эффектов WordArt в Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

Из меню справа вы можете выбрать предопределенный эффект WordArt. Из меню слева вы можете указать настройки для нового WordArt.

Вот некоторые из доступных параметров или настроек:

![todo:image_alt_text](image-20200930114015-3.png)

**С использованием Aspose.Slides**

Здесь мы применяем цвет паттерна SmallGrid к тексту и добавляем черную рамку шириной 1 с помощью этого кода:

``` csharp 
portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.SmallGrid;
            
portion.PortionFormat.LineFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
```

Получившийся текст:

![todo:image_alt_text](image-20200930114108-4.png)

## Применение других эффектов WordArt

**С использованием Microsoft PowerPoint**

Из интерфейса программы вы можете применить эти эффекты к тексту, текстовому блоку, форме или аналогичному элементу:

![todo:image_alt_text](image-20200930114129-5.png)

Например, эффекты теней, отражения и свечения могут быть применены к тексту; 3D формат и 3D поворот могут быть применены к текстовому блоку; атрибут "Мягкие края" может быть применен к объекту формы (он все равно будет действовать, даже если у него не установлен атрибут 3D Формат).

### Применение эффектов теней

Здесь мы намерены установить свойства, относящиеся только к тексту. Мы применяем эффект тени к тексту с помощью этого кода на C#:

``` csharp 
portion.PortionFormat.EffectFormat.EnableOuterShadowEffect();
portion.PortionFormat.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.Black;
portion.PortionFormat.EffectFormat.OuterShadowEffect.ScaleHorizontal = 100;
portion.PortionFormat.EffectFormat.OuterShadowEffect.ScaleVertical = 65;
portion.PortionFormat.EffectFormat.OuterShadowEffect.BlurRadius = 4.73;
portion.PortionFormat.EffectFormat.OuterShadowEffect.Direction = 230;
portion.PortionFormat.EffectFormat.OuterShadowEffect.Distance = 2;
portion.PortionFormat.EffectFormat.OuterShadowEffect.SkewHorizontal = 30;
portion.PortionFormat.EffectFormat.OuterShadowEffect.SkewVertical = 0;
portion.PortionFormat.EffectFormat.OuterShadowEffect.ShadowColor.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.32f);
```

API Aspose.Slides поддерживает три типа теней: OuterShadow, InnerShadow и PresetShadow. 

 С помощью PresetShadow можно применять тень к тексту (используя предустановленные значения). 

**С использованием Microsoft PowerPoint**

В PowerPoint вы можете использовать один тип тени. Вот пример:

![todo:image_alt_text](image-20200930114225-6.png)

**С использованием Aspose.Slides**

Aspose.Slides на самом деле позволяет применять два типа теней одновременно: InnerShadow и PresetShadow.

**Примечания:**

- Когда используются OuterShadow и PresetShadow одновременно, применяется только эффект OuterShadow. 
- Если одновременно используются OuterShadow и InnerShadow, результирующий или применяемый эффект зависит от версии PowerPoint. Например, в PowerPoint 2013 эффект удваивается. Но в PowerPoint 2007 применяется эффект OuterShadow. 

### Применение отображения к текстам

Мы добавляем отображение к тексту с помощью этого образца кода на C#:

``` csharp 
portion.PortionFormat.EffectFormat.EnableReflectionEffect();
portion.PortionFormat.EffectFormat.ReflectionEffect.BlurRadius = 0.5; 
portion.PortionFormat.EffectFormat.ReflectionEffect.Distance = 4.72; 
portion.PortionFormat.EffectFormat.ReflectionEffect.StartPosAlpha = 0f; 
portion.PortionFormat.EffectFormat.ReflectionEffect.EndPosAlpha = 60f; 
portion.PortionFormat.EffectFormat.ReflectionEffect.Direction = 90; 
portion.PortionFormat.EffectFormat.ReflectionEffect.ScaleHorizontal = 100; 
portion.PortionFormat.EffectFormat.ReflectionEffect.ScaleVertical = -100;
portion.PortionFormat.EffectFormat.ReflectionEffect.StartReflectionOpacity = 60f;
portion.PortionFormat.EffectFormat.ReflectionEffect.EndReflectionOpacity = 0.9f;
portion.PortionFormat.EffectFormat.ReflectionEffect.RectangleAlign = RectangleAlignment.BottomLeft;   
```

### Применение эффекта свечения к текстам

Мы применяем эффект свечения к тексту, чтобы сделать его ярким или выделяющимся, используя этот код:

``` csharp 
portion.PortionFormat.EffectFormat.EnableGlowEffect();
portion.PortionFormat.EffectFormat.GlowEffect.Color.R = 255;
portion.PortionFormat.EffectFormat.GlowEffect.Color.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.54f);
portion.PortionFormat.EffectFormat.GlowEffect.Radius = 7;
```

Результат операции:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

Вы можете изменить параметры для тени, отображения и свечения. Свойства эффектов устанавливаются для каждого порционного текста отдельно.

{{% /alert %}} 

### Использование трансформаций в WordArt

Мы используем свойство Transform (присущее всему блоку текста) через следующий код:
``` csharp 
textFrame.TextFrameFormat.Transform = TextShapeType.ArchUpPour;
```

Результат:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Как Microsoft PowerPoint, так и Aspose.Slides для .NET предоставляют определенное количество предопределенных типов трансформаций. 

{{% /alert %}} 

**С использованием PowerPoint**

Чтобы получить доступ к предопределенным типам трансформаций, пройдите через: **Формат** -> **Текстовый эффект** -> **Трансформация**

**С использованием Aspose.Slides**

Чтобы выбрать тип трансформации, используйте перечисление TextShapeType. 

### Применение 3D эффектов к текстам и формам

Мы устанавливаем 3D эффект для текстовой формы с помощью этого образца кода:

``` csharp 
autoShape.ThreeDFormat.BevelBottom.BevelType = BevelPresetType.Circle;
autoShape.ThreeDFormat.BevelBottom.Height = 10.5;
autoShape.ThreeDFormat.BevelBottom.Width = 10.5;

autoShape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
autoShape.ThreeDFormat.BevelTop.Height = 12.5;
autoShape.ThreeDFormat.BevelTop.Width = 11;

autoShape.ThreeDFormat.ExtrusionColor.Color = Color.Orange;
autoShape.ThreeDFormat.ExtrusionHeight = 6;

autoShape.ThreeDFormat.ContourColor.Color = Color.DarkRed;
autoShape.ThreeDFormat.ContourWidth = 1.5;

autoShape.ThreeDFormat.Depth = 3;

autoShape.ThreeDFormat.Material = MaterialPresetType.Plastic;

autoShape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
autoShape.ThreeDFormat.LightRig.SetRotation(0, 0, 40);

autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;
```

Результирующий текст и его форма:

![todo:image_alt_text](image-20200930114816-9.png)

Мы применяем 3D эффект к тексту с помощью этого кода на C#:

``` csharp 
textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.BevelType = BevelPresetType.Circle;
textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.Height = 3.5;
textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.Width = 3.5;

textFrame.TextFrameFormat.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
textFrame.TextFrameFormat.ThreeDFormat.BevelTop.Height = 4;
textFrame.TextFrameFormat.ThreeDFormat.BevelTop.Width = 4;

textFrame.TextFrameFormat.ThreeDFormat.ExtrusionColor.Color = Color.Orange;
textFrame.TextFrameFormat.ThreeDFormat.ExtrusionHeight= 6;

textFrame.TextFrameFormat.ThreeDFormat.ContourColor.Color = Color.DarkRed;
textFrame.TextFrameFormat.ThreeDFormat.ContourWidth = 1.5;

textFrame.TextFrameFormat.ThreeDFormat.Depth= 3;

textFrame.TextFrameFormat.ThreeDFormat.Material = MaterialPresetType.Plastic;

textFrame.TextFrameFormat.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
textFrame.TextFrameFormat.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
textFrame.TextFrameFormat.ThreeDFormat.LightRig.SetRotation(0, 0, 40);

textFrame.TextFrameFormat.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;
```

Результат операции:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

Применение 3D эффектов к текстам или их формам и взаимодействие между эффектами основаны на определенных правилах. 

Рассмотрим сцену для текста и фигуры, содержащей этот текст. 3D эффект включает в себя представление 3D объекта и сцену, на которой объект был установлен. 

- Когда сцена установлена для обеих фигур и текста, приоритет отдается сцене фигуры — сцена текста игнорируется. 
- Когда у фигуры нет своей сцены, но есть 3D представление, используется сцена текста. 
- В противном случае — когда форма изначально не имеет 3D эффекта — форма плоская, и 3D эффект применяется только к тексту. 

Описание связано со свойствами [ThreeDFormat.LightRig](https://reference.aspose.com/slides/net/aspose.slides/threedformat/properties/lightrig) и [ThreeDFormat.Camera](https://reference.aspose.com/slides/net/aspose.slides/threedformat/properties/camera).

{{% /alert %}} 

## **Применение эффектов внешней тени к текстам**
Aspose.Slides для .NET предоставляет классы [**IOuterShadow**](https://reference.aspose.com/slides/net/aspose.slides.effects/ioutershadow) и [**IInnerShadow**](https://reference.aspose.com/slides/net/aspose.slides.effects/iinnershadow), которые позволяют применять эффекты теней к тексту, представленному TextFrame. Пройдите через следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Получите ссылку на слайд, используя его индекс.
3. Добавьте AutoShape типа Rectangle на слайд.
4. Получите доступ к TextFrame, связанному с AutoShape.
5. Установите FillType AutoShape в NoFill.
6. Создайте экземпляр класса OuterShadow.
7. Установите BlurRadius тени.
8. Установите Direction тени.
9. Установите Distance тени.
10. Установите RectanglelAlign в TopLeft.
11. Установите PresetColor тени на черный.
12. Запишите презентацию в файл PPTX.

Этот образец кода на C# — реализация вышеизложенных шагов — демонстрирует, как применить эффект внешней тени к тексту:

```c#
using (Presentation pres = new Presentation())
{

    // Получить ссылку на слайд
    ISlide sld = pres.Slides[0];

    // Добавить AutoShape типа Rectangle
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Добавить TextFrame в Rectangle
    ashp.AddTextFrame("Aspose TextBox");

    // Отключить заливку фигуры, если мы хотим получить тень текста
    ashp.FillFormat.FillType = FillType.NoFill;

    // Добавить внешнюю тень и установить все необходимые параметры
    ashp.EffectFormat.EnableOuterShadowEffect();
    IOuterShadow shadow = ashp.EffectFormat.OuterShadowEffect;
    shadow.BlurRadius = 4.0;
    shadow.Direction = 45;
    shadow.Distance = 3;
    shadow.RectangleAlign = RectangleAlignment.TopLeft;
    shadow.ShadowColor.PresetColor = PresetColor.Black;

    //Записать презентацию на диск
    pres.Save("pres_out.pptx", SaveFormat.Pptx);
}
```


## **Применение эффекта внутренней тени к формам**
Пройдите через следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Получите ссылку на слайд.
3. Добавьте AutoShape типа Rectangle.
4. Включите InnerShadowEffect.
5. Установите все необходимые параметры.
6. Установите ColorType как Scheme.
7. Установите цвет схемы.
8. Запишите презентацию как файл [PPTX](https://docs.fileformat.com/presentation/pptx/).

Этот образец кода (на основе вышеизложенных шагов) показывает, как добавить соединитель между двумя формами на C#:

```c#
using(Presentation presentation = new Presentation())
{
    // Получить ссылку на слайд
    ISlide slide = presentation.Slides[0];

    // Добавить AutoShape типа Rectangle
    IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.FillFormat.FillType = FillType.NoFill;

    // Добавить TextFrame в Rectangle
    ashp.AddTextFrame("Aspose TextBox");
    IPortion port = ashp.TextFrame.Paragraphs[0].Portions[0];
    IPortionFormat pf = port.PortionFormat;
    pf.FontHeight = 50;

    // Включить InnerShadowEffect    
    IEffectFormat ef = pf.EffectFormat;
    ef.EnableInnerShadowEffect();

    // Установить все необходимые параметры
    ef.InnerShadowEffect.BlurRadius = 8.0;
    ef.InnerShadowEffect.Direction = 90.0F;
    ef.InnerShadowEffect.Distance = 6.0;
    ef.InnerShadowEffect.ShadowColor.B = 189;

    // Установить ColorType как Scheme
    ef.InnerShadowEffect.ShadowColor.ColorType = ColorType.Scheme;

    // Установить цвет схемы
    ef.InnerShadowEffect.ShadowColor.SchemeColor = SchemeColor.Accent1;

    // Сохранить презентацию
    presentation.Save("WordArt_out.pptx", SaveFormat.Pptx);
}
```