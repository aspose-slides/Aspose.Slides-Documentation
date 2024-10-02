---
title: Применение защиты к презентации
type: docs
weight: 70
url: /ru/net/applying-protection-to-presentation/
---

{{% alert color="primary" %}} 

Обычное использование Aspose.Slides заключается в создании, обновлении и сохранении презентаций Microsoft PowerPoint 2007 (PPTX) в рамках автоматизированного рабочего процесса. Пользователи приложения, использующего Aspose.Slides таким образом, получают доступ к выходным презентациям. Защита их от редактирования является общем обоснованным беспокойством. Важно, чтобы автоматически сгенерированные презентации сохраняли свое исходное форматирование и содержимое.

В этой статье объясняется, как [конструируются презентации и слайды](/slides/ru/net/applying-protection-to-presentation/) и как Aspose.Slides для .NET может [применить защиту к](/slides/ru/net/applying-protection-to-presentation/), а затем [удалить ее из](/slides/ru/net/applying-protection-to-presentation/) презентации. Эта функция уникальна для Aspose.Slides и, на момент написания, недоступна в Microsoft PowerPoint. Она дает разработчикам возможность контролировать, как используются презентации, созданные их приложениями.

{{% /alert %}} 
## **Состав слайда**
Слайд PPTX состоит из ряда компонентов, таких как автофигуры, таблицы, OLE-объекты, сгруппированные фигуры, рамки для изображений, видеокадры, соединители и различные другие элементы, доступные для создания презентации.

В Aspose.Slides для .NET каждый элемент на слайде представлен объектом Shape. Другими словами, каждый элемент на слайде является либо объектом Shape, либо объектом, производным от объекта Shape.

Структура PPTX сложна, поэтому, в отличие от PPT, где может использоваться общий замок для всех типов фигур, существуют различные типы замков для различных типов фигур. Класс BaseShapeLock является общим классом блокировки PPTX. В Aspose.Slides для .NET поддерживаются следующие типы замков для PPTX.

- AutoShapeLock блокирует автофигуры.
- ConnectorLock блокирует соединительные фигуры.
- GraphicalObjectLock блокирует графические объекты.
- GroupshapeLock блокирует групповые фигуры.
- PictureFrameLock блокирует рамки для изображений.

Все действия, выполняемые над всеми объектами Shape в объекте Presentation, применяются ко всей презентации.
## **Применение и удаление защиты**
Применение защиты гарантирует, что презентация не может быть отредактирована. Это полезная техника для защиты содержания презентации.
### **Применение защиты к фигурам PPTX**
Aspose.Slides для .NET предоставляет класс Shape для работы с фигурами на слайде.

Как было упомянуто ранее, у каждого класса фигуры есть соответствующий класс блокировки фигуры для защиты. Эта статья сосредоточена на блокировках NoSelect, NoMove и NoResize. Эти блокировки гарантируют, что фигуры не могут быть выбраны (через щелчки мышью или другие методы выбора), а также не могут быть перемещены или изменены в размере.

Приведенные ниже примеры кода применяют защиту ко всем типам фигур в презентации.

```c#
//Создание экземпляра класса Presentation, представляющего файл PPTX
Presentation pTemplate = new Presentation("RectPicFrame.pptx");
           

//Объект ISlide для доступа к слайдам в презентации
ISlide slide = pTemplate.Slides[0];

//Объект IShape для хранения временных фигур
IShape shape;

//Перебор всех слайдов в презентации
for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)
{
    slide = pTemplate.Slides[slideCount];

    //Перебор всех фигур на слайдах
    for (int count = 0; count < slide.Shapes.Count; count++)
    {
        shape = slide.Shapes[count];

        //если фигура является автофигурой
        if (shape is IAutoShape)
        {
            //Приведение типа к автофигуре и получение замка автофигуры
            IAutoShape Ashp = shape as IAutoShape;
            IAutoShapeLock AutoShapeLock = Ashp.ShapeLock;

            //Применение блокировок фигур
            AutoShapeLock.PositionLocked = true;
            AutoShapeLock.SelectLocked = true;
            AutoShapeLock.SizeLocked = true;
        }

        //если фигура является групповой фигурой
        else if (shape is IGroupShape)
        {
            //Приведение типа к групповой фигуре и получение замка групповой фигуры
            IGroupShape Group = shape as IGroupShape;
            IGroupShapeLock groupShapeLock = Group.ShapeLock;

            //Применение блокировок фигур
            groupShapeLock.GroupingLocked = true;
            groupShapeLock.PositionLocked = true;
            groupShapeLock.SelectLocked = true;
            groupShapeLock.SizeLocked = true;
        }

        //если фигура является соединителем
        else if (shape is IConnector)
        {
            //Приведение типа к соединительной фигуре и получение замка соединителя
            IConnector Conn = shape as IConnector;
            IConnectorLock ConnLock = Conn.ShapeLock;

            //Применение блокировок фигур
            ConnLock.PositionMove = true;
            ConnLock.SelectLocked = true;
            ConnLock.SizeLocked = true;
        }

        //если фигура является рамкой для изображения
        else if (shape is IPictureFrame)
        {
            //Приведение типа к рамке для изображения и получение замка рамки для изображения
            IPictureFrame Pic = shape as IPictureFrame;
            IPictureFrameLock PicLock = Pic.ShapeLock;

            //Применение блокировок фигур
            PicLock.PositionLocked = true;
            PicLock.SelectLocked = true;
            PicLock.SizeLocked = true;
        }
    }


}
//Сохранение файла презентации
pTemplate.Save("ProtectedSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


### **Удаление защиты**
Защита, примененная с помощью Aspose.Slides для .NET, может быть удалена только с помощью Aspose.Slides для .NET. Чтобы разблокировать фигуру, установите значение примененной блокировки в false. Приведенный ниже пример кода показывает, как разблокировать фигуры в заблокированной презентации.

```c#
//Открытие нужной презентации
Presentation pTemplate = new Presentation("ProtectedSample.pptx");

//Объект ISlide для доступа к слайдам в презентации
ISlide slide = pTemplate.Slides[0];

//Объект IShape для хранения временных фигур
IShape shape;

//Перебор всех слайдов в презентации
for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)
{
    slide = pTemplate.Slides[slideCount];

    //Перебор всех фигур на слайдах
    for (int count = 0; count < slide.Shapes.Count; count++)
    {
        shape = slide.Shapes[count];

        //если фигура является автофигурой
        if (shape is IAutoShape)
        {
            //Приведение типа к автофигуре и получение замка автофигуры
            IAutoShape Ashp = shape as AutoShape;
            IAutoShapeLock AutoShapeLock = Ashp.ShapeLock;

            //Применение блокировок фигур
            AutoShapeLock.PositionLocked = false;
            AutoShapeLock.SelectLocked = false;
            AutoShapeLock.SizeLocked = false;
        }

        //если фигура является групповой фигурой
        else if (shape is IGroupShape)
        {
            //Приведение типа к групповой фигуре и получение замка групповой фигуры
            IGroupShape Group = shape as IGroupShape;
            IGroupShapeLock groupShapeLock = Group.ShapeLock;

            //Применение блокировок фигур
            groupShapeLock.GroupingLocked = false;
            groupShapeLock.PositionLocked = false;
            groupShapeLock.SelectLocked = false;
            groupShapeLock.SizeLocked = false;
        }

        //если фигура является соединительной фигурой
        else if (shape is IConnector)
        {
            //Приведение типа к соединительной фигуре и получение замка соединителя
            IConnector Conn = shape as IConnector;
            IConnectorLock ConnLock = Conn.ShapeLock;

            //Применение блокировок фигур
            ConnLock.PositionMove = false;
            ConnLock.SelectLocked = false;
            ConnLock.SizeLocked = false;
        }

        //если фигура является рамкой для изображения
        else if (shape is IPictureFrame)
        {
            //Приведение типа к рамке для изображения и получение замка рамки для изображения
            IPictureFrame Pic = shape as IPictureFrame;
            IPictureFrameLock PicLock = Pic.ShapeLock;

            //Применение блокировок фигур
            PicLock.PositionLocked = false;
            PicLock.SelectLocked = false;
            PicLock.SizeLocked = false;
        }
    }

}
//Сохранение файла презентации
pTemplate.Save("RemoveProtectionSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


### **Резюме**
{{% alert color="primary" %}} 

Aspose.Slides предоставляет несколько вариантов применения защиты к фигурам в презентации. Можно заблокировать конкретную фигуру или пройтись по всем фигурам в презентации и заблокировать их все, чтобы эффективно заблокировать презентацию.

Только Aspose.Slides для .NET может удалить защиту из презентации, которая была ранее защищена. Удалите защиту, установив значение блокировки в false.

{{% /alert %}} 
