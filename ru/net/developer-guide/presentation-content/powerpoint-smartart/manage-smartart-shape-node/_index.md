---
title: Управление узлами фигуры SmartArt
type: docs
weight: 30
url: /ru/net/manage-smartart-shape-node/
keywords:
- SmartArt
- Узел SmartArt
- Дочерний узел SmartArt
- PowerPoint
- презентация
- C#
- Csharp
- Aspose.Slides for .NET
description: "Управление узлами SmartArt и дочерними узлами в презентациях PowerPoint на C# или .NET"
---

## **Добавить узел SmartArt**
Aspose.Slides for .NET предоставляет самый простой API для управления фигурами SmartArt самым удобным способом. Приведённый пример кода поможет добавить узел и дочерний узел внутри фигуры SmartArt.

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) и загрузите презентацию с фигурой SmartArt.
- Получите ссылку на первый слайд, используя его индекс.
- Пройдитесь по всем фигурам на первом слайде.
- Проверьте, является ли фигура типом SmartArt, и выполните приведение типа выбранной фигуры к SmartArt, если это SmartArt.
- Добавьте новый узел в коллекцию NodeCollection фигуры SmartArt и задайте текст в TextFrame.
- Затем добавьте дочерний узел в только что добавленный узел SmartArt и задайте текст в TextFrame.
- Сохраните презентацию.
```c#
// Загрузить нужную презентацию
Presentation pres = new Presentation("AddNodes.pptx");

// Пройти по всем фигурам на первом слайде
foreach (IShape shape in pres.Slides[0].Shapes)
{

    // Проверить, является ли фигура типом SmartArt
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {

        // Привести тип фигуры к SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        // Добавление нового узла SmartArt
        Aspose.Slides.SmartArt.SmartArtNode TemNode = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes.AddNode();

        // Добавление текста
        TemNode.TextFrame.Text = "Test";

        // Добавление нового дочернего узла в родительский узел. Он будет добавлен в конец коллекции
        Aspose.Slides.SmartArt.SmartArtNode newNode = (Aspose.Slides.SmartArt.SmartArtNode)TemNode.ChildNodes.AddNode();

        // Добавление текста
        newNode.TextFrame.Text = "New Node Added";

    }
}

// Сохранить презентацию
pres.Save("AddSmartArtNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **Добавить узел SmartArt в определённую позицию**
В следующем примере кода объясняется, как добавить дочерние узлы, принадлежащие соответствующим узлам фигуры SmartArt, в конкретную позицию.

- Создайте экземпляр класса `Presentation`.
- Получите ссылку на первый слайд, используя его индекс.
- Добавьте фигуру SmartArt типа StackedList на выбранный слайд.
- Получите доступ к первому узлу в добавленной фигуре SmartArt.
- Затем добавьте дочерний узел для выбранного узла в позицию 2 и задайте его текст.
- Сохраните презентацию.
```c#
// Создание экземпляра презентации
Presentation pres = new Presentation();

// Получение слайда презентации
ISlide slide = pres.Slides[0];

// Добавление Smart Art IShape
ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

// Получение узла SmartArt с индексом 0
ISmartArtNode node = smart.AllNodes[0];

// Добавление нового дочернего узла в позицию 2 родительского узла
SmartArtNode chNode = (SmartArtNode)((SmartArtNodeCollection)node.ChildNodes).AddNodeByPosition(2);

// Добавление текста
chNode.TextFrame.Text = "Sample Text Added";

// Сохранить презентацию
pres.Save("AddSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **Доступ к узлу SmartArt**
Приведённый пример кода поможет получить доступ к узлам внутри фигуры SmartArt. Обратите внимание, что изменить LayoutType SmartArt нельзя, так как он только для чтения и устанавливается только при добавлении фигуры SmartArt.

- Создайте экземпляр класса `Presentation` и загрузите презентацию с фигурой SmartArt.
- Получите ссылку на первый слайд, используя его индекс.
- Пройдитесь по всем фигурам на первом слайде.
- Проверьте, является ли фигура типом SmartArt, и выполните приведение типа выбранной фигуры к SmartArt, если это SmartArt.
- Пройдитесь по всем узлам внутри фигуры SmartArt.
- Получите и отобразите информацию, такую как позиция узла SmartArt, уровень и текст.
  ```c#
  // Загрузить нужную презентацию
   Presentation pres = new Presentation("AccessSmartArt.pptx");
  
  // Обойти все фигуры первого слайда
  foreach (IShape shape in pres.Slides[0].Shapes)
  {
      // Проверить, является ли фигура типом SmartArt
      if (shape is Aspose.Slides.SmartArt.SmartArt)
      {
  
          // Привести тип фигуры к SmartArt
          Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
  
          // Обойти все узлы внутри SmartArt
          for (int i = 0; i < smart.AllNodes.Count; i++)
          {
              // Доступ к узлу SmartArt с индексом i
              Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];
  
              // Вывод параметров узла SmartArt
              string outString = string.Format("i = {0}, Text = {1},  Level = {2}, Position = {3}", i, node.TextFrame.Text, node.Level, node.Position);
              Console.WriteLine(outString);
          }
      }
  }
  ```


## **Доступ к дочернему узлу SmartArt**
Приведённый пример кода поможет получить доступ к дочерним узлам, принадлежащим соответствующим узлам фигуры SmartArt.

- Создайте экземпляр класса PresentationEx и загрузите презентацию с фигурой SmartArt.
- Получите ссылку на первый слайд, используя его индекс.
- Пройдитесь по всем фигурам на первом слайде.
- Проверьте, является ли фигура типом SmartArt, и выполните приведение типа выбранной фигуры к SmartArtEx, если это SmartArt.
- Пройдитесь по всем узлам внутри фигуры SmartArt.
- Для каждого выбранного узла фигуры SmartArt пройдитесь по всем дочерним узлам внутри конкретного узла.
- Получите и отобразите информацию, такую как позиция дочернего узла, уровень и текст.
```c#
 // Load the desired the presentation
 Presentation pres = new Presentation("AccessChildNodes.pptx");

 // Traverse through every shape inside first slide
 foreach (IShape shape in pres.Slides[0].Shapes)
 {
 
     // Check if shape is of SmartArt type
     if (shape is Aspose.Slides.SmartArt.SmartArt)
     {
 
         // Typecast shape to SmartArt
         Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
 
         // Traverse through all nodes inside SmartArt
         for (int i = 0; i < smart.AllNodes.Count; i++)
         {
             // Accessing SmartArt node at index i
             Aspose.Slides.SmartArt.SmartArtNode node0 = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];
 
             // Traversing through the child nodes in SmartArt node at index i
             for (int j = 0; j < node0.ChildNodes.Count; j++)
             {
                 // Accessing the child node in SmartArt node
                 Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)node0.ChildNodes[j];
 
                 // Printing the SmartArt child node parameters
                 string outString = string.Format("j = {0}, Text = {1},  Level = {2}, Position = {3}", j, node.TextFrame.Text, node.Level, node.Position);
                 Console.WriteLine(outString);
             }
         }
     }
 }
```


## **Доступ к дочернему узлу SmartArt в определённой позиции**
В этом примере мы научимся получать доступ к дочерним узлам в определённой позиции, принадлежащим соответствующим узлам фигуры SmartArt.

- Создайте экземпляр класса `Presentation`.
- Получите ссылку на первый слайд, используя его индекс.
- Добавьте фигуру SmartArt типа StackedList.
- Получите доступ к добавленной фигуре SmartArt.
- Получите узел с индексом 0 для выбранной фигуры SmartArt.
- Затем получите дочерний узел в позиции 1 для выбранного узла SmartArt, используя метод GetNodeByPosition().
- Получите и отобразите информацию, такую как позиция дочернего узла, уровень и текст.
```c#
// Создать экземпляр презентации
Presentation pres = new Presentation();

// Получение первого слайда
ISlide slide = pres.Slides[0];

// Добавление фигуры SmartArt на первый слайд
ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

// Получение узла SmartArt с индексом 0
ISmartArtNode node = smart.AllNodes[0];

// Получение дочернего узла в позиции 1 у родительского узла
int position = 1;
SmartArtNode chNode = (SmartArtNode)node.ChildNodes[position]; 

// Вывод параметров дочернего узла SmartArt
string outString = string.Format("j = {0}, Text = {1},  Level = {2}, Position = {3}", position, chNode.TextFrame.Text, chNode.Level, chNode.Position);
Console.WriteLine(outString);
```


## **Удалить узел SmartArt**
В этом примере мы научимся удалять узлы внутри фигуры SmartArt.

- Создайте экземпляр класса `Presentation` и загрузите презентацию с фигурой SmartArt.
- Получите ссылку на первый слайд, используя его индекс.
- Пройдитесь по всем фигурам на первом слайде.
- Проверьте, является ли фигура типом SmartArt, и выполните приведение типа выбранной фигуры к SmartArt, если это SmartArt.
- Убедитесь, что в SmartArt больше 0 узлов.
- Выберите узел SmartArt, который нужно удалить.
- Затем удалите выбранный узел, используя метод RemoveNode(), и сохраните презентацию.
```c#
// Загрузить нужную презентацию
using (Presentation pres = new Presentation("RemoveNode.pptx"))
{
    // Пройти по всем фигурам первого слайда
    foreach (IShape shape in pres.Slides[0].Shapes)
    {
        // Проверить, является ли фигура типом SmartArt
        if (shape is ISmartArt)
        {
            // Привести тип фигуры к SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            if (smart.AllNodes.Count > 0)
            {
                // Доступ к узлу SmartArt с индексом 0
                ISmartArtNode node = smart.AllNodes[0];

                // Удаление выбранного узла
                smart.AllNodes.RemoveNode(node);
            }
        }
    }

    // Сохранить презентацию
    pres.Save("RemoveSmartArtNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Удалить узел SmartArt в определённой позиции**
В этом примере мы научимся удалять узлы внутри фигуры SmartArt в конкретной позиции.

- Создайте экземпляр класса `Presentation` и загрузите презентацию с фигурой SmartArt.
- Получите ссылку на первый слайд, используя его индекс.
- Пройдитесь по всем фигурам на первом слайде.
- Проверьте, является ли фигура типом SmartArt, и выполните приведение типа выбранной фигуры к SmartArt, если это SmartArt.
- Выберите узел фигуры SmartArt с индексом 0.
- Затем проверьте, имеет ли выбранный узел SmartArt более 2 дочерних узлов.
- Удалите узел в позиции 1, используя метод RemoveNodeByPosition().
- Сохраните презентацию.
```c#
// Загрузить нужную презентацию
Presentation pres = new Presentation("RemoveNodeSpecificPosition.pptx");

// Пройти по всем фигурам первого слайда
foreach (IShape shape in pres.Slides[0].Shapes)
{
    // Проверить, является ли фигура типом SmartArt
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {
        // Привести тип фигуры к SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        if (smart.AllNodes.Count > 0)
        {
            // Доступ к узлу SmartArt с индексом 0
            Aspose.Slides.SmartArt.ISmartArtNode node = smart.AllNodes[0];

            if (node.ChildNodes.Count >= 2)
            {
                // Удалить дочерний узел в позиции 1
                ((Aspose.Slides.SmartArt.SmartArtNodeCollection)node.ChildNodes).RemoveNode(1);
            }

        }
    }
}

// Сохранить презентацию
pres.Save("RemoveSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **Установить пользовательскую позицию для дочернего узла в SmartArt**
Теперь Aspose.Slides for .NET поддерживает установку свойств X и Y для SmartArtShape. Ниже приведён фрагмент кода, показывающий, как задать пользовательскую позицию, размер и поворот SmartArtShape; также обратите внимание, что добавление новых узлов вызывает перерасчёт позиций и размеров всех узлов.
```c#
// Загрузить нужную презентацию
Presentation pres = new Presentation("AccessChildNodes.pptx");

{
	ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

	// Переместить форму SmartArt в новую позицию
	ISmartArtNode node = smart.AllNodes[1];
	ISmartArtShape shape = node.Shapes[1];
	shape.X += (shape.Width * 2);
	shape.Y -= (shape.Height / 2);

	// Изменить ширину формы SmartArt
	node = smart.AllNodes[2];
	shape = node.Shapes[1];
	shape.Width += (shape.Width / 2);

	// Изменить высоту формы SmartArt
	node = smart.AllNodes[3];
	shape = node.Shapes[1];
	shape.Height += (shape.Height / 2);

	// Повернуть форму SmartArt
	node = smart.AllNodes[4];
	shape = node.Shapes[1];
	shape.Rotation = 90;

	pres.Save("SmartArt.pptx", SaveFormat.Pptx);
}
```


## **Проверка узла‑ассистента**
В следующем примере кода мы исследуем, как определить узлы‑ассистенты в коллекции узлов SmartArt и изменить их.

- Создайте экземпляр класса PresentationEx и загрузите презентацию с фигурой SmartArt.
- Получите ссылку на второй слайд, используя его индекс.
- Пройдитесь по всем фигурам на первом слайде.
- Проверьте, является ли фигура типом SmartArt, и выполните приведение типа выбранной фигуры к SmartArtEx, если это SmartArt.
- Пройдитесь по всем узлам внутри фигуры SmartArt и проверьте, являются ли они узлами‑ассистентами.
- Измените статус узла‑ассистента на обычный узел.
- Сохраните презентацию.
```c#
// Создание экземпляра презентации
using (Presentation pres = new Presentation("AssistantNode.pptx"))
{
    // Обход всех фигур первого слайда
    foreach (IShape shape in pres.Slides[0].Shapes)
    {
        // Проверить, является ли фигура типом SmartArt
        if (shape is Aspose.Slides.SmartArt.ISmartArt)
        {
            // Привести тип фигуры к SmartArtEx
            Aspose.Slides.SmartArt.ISmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
            // Перебор всех узлов SmartArt

            foreach (Aspose.Slides.SmartArt.ISmartArtNode node in smart.AllNodes)
            {
                String tc = node.TextFrame.Text;
                // Проверить, является ли узел узлом‑ассистентом
                if (node.IsAssistant)
                {
                    // Установить свойство Assitant узла в false и сделать его обычным узлом
                    node.IsAssistant = false;
                }
            }
        }
    }
    // Сохранить презентацию
    pres.Save("ChangeAssitantNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Установить формат заливки узла**
Aspose.Slides for .NET позволяет добавлять пользовательские фигуры SmartArt и задавать их форматы заливки. Эта статья объясняет, как создавать и получать доступ к фигурам SmartArt и задавать их формат заливки с помощью Aspose.Slides for .NET.

Пожалуйста, выполните следующие шаги:

- Создайте экземпляр класса `Presentation`.
- Получите ссылку на слайд, используя его индекс.
- Добавьте фигуру SmartArt, задав её LayoutType.
- Задайте FillFormat для узлов фигуры SmartArt.
- Запишите изменённую презентацию в файл PPTX.
```c#
using (Presentation presentation = new Presentation())
{
    // Доступ к слайду
    ISlide slide = presentation.Slides[0];

    // Добавление SmartArt фигуры и узлов
    var chevron = slide.Shapes.AddSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    var node = chevron.AllNodes.AddNode();
    node.TextFrame.Text = "Some text";

    // Установка цвета заливки узла
    foreach (var item in node.Shapes)
    {
        item.FillFormat.FillType = FillType.Solid;
        item.FillFormat.SolidFillColor.Color = Color.Red;
    }

    // Сохранение презентации
    presentation.Save("FillFormat_SmartArt_ShapeNode_out.pptx", SaveFormat.Pptx);
}
```


## **Создать миниатюру дочернего узла SmartArt**
Разработчики могут создать миниатюру дочернего узла SmartArt, выполнив следующие шаги:

1. Создайте экземпляр класса `Presentation`, представляющего файл PPTX.
2. Добавьте SmartArt.
3. Получите ссылку на узел, используя его индекс.
4. Получите изображение миниатюры.
5. Сохраните изображение миниатюры в любом нужном формате.

Ниже приведён пример создания миниатюры дочернего узла SmartArt.
```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    ISmartArt smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);
    ISmartArtNode node = smartArt.Nodes[1];

    using (IImage image = node.Shapes[0].GetImage())
    {
        image.Save("SmartArt_ChildNote_Thumbnail_out.jpeg", ImageFormat.Jpeg);
    }
}
```


## **FAQ**

**Поддерживается ли анимация SmartArt?**

Да. SmartArt рассматривается как обычная фигура, поэтому вы можете [применять стандартные анимации](/slides/ru/net/shape-animation/) (вход, выход, акцент, пути движения) и настраивать их тайминг. При необходимости можно анимировать фигуры внутри узлов SmartArt.

**Как надёжно найти конкретный SmartArt на слайде, если его внутренний ID неизвестен?**

Назначьте и ищите по [альтернативному тексту](https://reference.aspose.com/slides/net/aspose.slides/shape/alternativetext/). Установив отличительный AltText для SmartArt, вы сможете находить его программно без привязки к внутренним идентификаторам.

**Сохранится ли внешний вид SmartArt при конвертации презентации в PDF?**

Да. Aspose.Slides рендерит SmartArt с высокой визуальной точностью при [экспорте в PDF](/slides/ru/net/convert-powerpoint-to-pdf/), сохраняя макет, цвета и эффекты.

**Можно ли извлечь изображение всего SmartArt (для превью или отчётов)?**

Да. Вы можете отрисовать фигуру SmartArt в [растровые форматы](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) или в [SVG](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/) для масштабируемого векторного вывода, что удобно для миниатюр, отчетов или веб‑использования.