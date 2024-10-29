---
title: Изменить цвет заливки фигуры в презентации
type: docs
weight: 40
url: /ru/net/change-the-fill-color-of-a-shape-in-a-presentation/
---

## **OpenXML Презентация**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Цвет заливки фигуры.pptx";

SetPPTShapeColor(FileName);

// Изменить цвет заливки фигуры.

// Тестовый файл должен содержать заполненную фигуру как первую фигуру на первом слайде.

public static void SetPPTShapeColor(string docName)

{

    using (PresentationDocument ppt = PresentationDocument.Open(docName, true))

    {

        // Получить ID связи первого слайда.

        PresentationPart part = ppt.PresentationPart;

        OpenXmlElementList slideIds = part.Presentation.SlideIdList.ChildElements;

        string relId = (slideIds[0] as SlideId).RelationshipId;

        // Получить часть слайда по ID связи.

        SlidePart slide = (SlidePart)part.GetPartById(relId);

        if (slide != null)

        {

            // Получить дерево фигур, содержащее изменяемую фигуру.

            ShapeTree tree = slide.Slide.CommonSlideData.ShapeTree;

            // Получить первую фигуру в дереве фигур.

            Shape shape = tree.GetFirstChild<Shape>();

            if (shape != null)

            {

                // Получить стиль фигуры.

                ShapeStyle style = shape.ShapeStyle;

                // Получить ссылку на заливку.

                Drawing.FillReference fillRef = style.FillReference;

                // Установить цвет заливки на SchemeColor Accent 6;

                fillRef.SchemeColor = new Drawing.SchemeColor();

                fillRef.SchemeColor.Val = Drawing.SchemeColorValues.Accent6;

                // Сохранить измененный слайд.

                slide.Slide.Save();

            }

        }

    }

}

``` 
## **Aspose.Slides**
Нам необходимо выполнить следующие шаги, чтобы заполнить фигуры в презентации:

- Создать экземпляр класса Presentation.
- Получить ссылку на слайд, используя его индекс.
- Добавить IShape на слайд.
- Установить тип заливки фигуры на Solid.
- Установить цвет фигуры.
- Записать измененную презентацию как файл PPTX.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Цвет заливки фигуры.pptx";

//Создать экземпляр класса PresentationEx, который представляет PPTX 

using (Presentation pres = new Presentation())

{

    //Получить первый слайд

    ISlide sld = pres.Slides[0];

    //Добавить автофигуру типа прямоугольник

    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    //Установить тип заливки на Solid

    shp.FillFormat.FillType = FillType.Solid;

    //Установить цвет прямоугольника

    shp.FillFormat.SolidFillColor.Color = Color.Yellow;

    //Записать файл PPTX на диск

    pres.Save(FileName, SaveFormat.Pptx);

}

``` 
## **Скачать пример работающего кода**
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **Пример кода**
- [CodePlex](https://asposeopenxml.codeplex.com/SourceControl/latest#Aspose.Slides VS OpenXML/Применить тему к презентации/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Цвет%20заливки%20фигуры)