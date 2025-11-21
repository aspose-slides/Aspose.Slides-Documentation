---
title: Управление узлами формы SmartArt в презентациях на .NET
linktitle: Узел формы SmartArt
type: docs
weight: 30
url: /ru/net/manage-smartart-shape-node/
keywords:
- узел SmartArt
- дочерний узел
- добавить узел
- позиция узла
- доступ к узлу
- удалить узел
- пользовательская позиция
- узел‑ассистент
- формат заливки
- отрисовка узла
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Управляйте узлами формы SmartArt в PPT и PPTX с помощью Aspose.Slides для .NET. Получите понятные примеры кода и советы для оптимизации ваших презентаций."
---

## **Добавить узел SmartArt**
Aspose.Slides for .NET предоставил самый простой API для управления формами SmartArt самым простым способом. Следующий пример кода поможет добавить узел и дочерний узел внутри формы SmartArt.

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) и загрузите презентацию с формой SmartArt.
- Получите ссылку на первый слайд, используя его индекс.
- Пройдитесь по каждой форме внутри первого слайда.
- Проверьте, является ли форма типа SmartArt, и приведите выбранную форму к типу SmartArt, если это SmartArt.
- Добавьте новый узел в коллекцию NodeCollection формы SmartArt и задайте текст в TextFrame.
- Затем добавьте дочерний узел в только что добавленный узел SmartArt и задайте текст в TextFrame.
- Сохраните презентацию.
```c#
// Загрузить нужную презентацию
Presentation pres = new Presentation("AddNodes.pptx");

// Пройтись по каждой фигуре внутри первого слайда
foreach (IShape shape in pres.Slides[0].Shapes)
{
    // Проверить, является ли фигура типа SmartArt
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

// Сохранение презентации
pres.Save("AddSmartArtNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```




## **Добавить узел SmartArt в определённой позиции**
В следующем примере кода мы объяснили, как добавить дочерние узлы, принадлежащие соответствующим узлам формы SmartArt, в определённой позиции.

- Создайте экземпляр класса `Presentation`.
- Получите ссылку на первый слайд, используя его индекс.
- Добавьте форму SmartArt типа StackedList на выбранный слайд.
- Получите доступ к первому узлу в добавленной форме SmartArt.
- Затем добавьте дочерний узел для выбранного узла на позицию 2 и задайте его текст.
- Сохраните презентацию.
```c#
// Создание экземпляра презентации
Presentation pres = new Presentation();

// Доступ к слайду презентации
ISlide slide = pres.Slides[0];

// Добавление Smart Art IShape
ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

// Доступ к узлу SmartArt с индексом 0
ISmartArtNode node = smart.AllNodes[0];

// Добавление нового дочернего узла на позицию 2 в родительском узле
SmartArtNode chNode = (SmartArtNode)((SmartArtNodeCollection)node.ChildNodes).AddNodeByPosition(2);

// Добавить текст
chNode.TextFrame.Text = "Sample Text Added";

// Сохранить презентацию
pres.Save("AddSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```





## **Доступ к узлу SmartArt**
Следующий пример кода поможет получить доступ к узлам внутри формы SmartArt. Обратите внимание, что тип LayoutType SmartArt нельзя изменить, так как он только для чтения и устанавливается только при добавлении формы SmartArt.

- Создайте экземпляр класса `Presentation` и загрузите презентацию с формой SmartArt.
- Получите ссылку на первый слайд, используя его индекс.
- Пройдитесь по каждой форме внутри первого слайда.
- Проверьте, является ли форма типа SmartArt, и приведите выбранную форму к типу SmartArt, если это SmartArt.
- Пройдитесь по всем узлам внутри формы SmartArt.
- Получите доступ и отобразите информацию, такую как позиция узла SmartArt, уровень и текст.
  ```c#
  // Загрузить нужную презентацию
   Presentation pres = new Presentation("AccessSmartArt.pptx");
  
  // Пройтись по каждой фигуре внутри первого слайда
  foreach (IShape shape in pres.Slides[0].Shapes)
  {
      // Проверить, является ли объект типа SmartArt
      if (shape is Aspose.Slides.SmartArt.SmartArt)
      {
  
          // Привести тип объекта к SmartArt
          Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
  
          // Пройтись по всем узлам внутри SmartArt
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
Следующий пример кода поможет получить доступ к дочерним узлам, принадлежащим соответствующим узлам формы SmartArt.

- Создайте экземпляр класса PresentationEx и загрузите презентацию с формой SmartArt.
- Получите ссылку на первый слайд, используя его индекс.
- Пройдитесь по каждой форме внутри первого слайда.
- Проверьте, является ли форма типа SmartArt, и приведите выбранную форму к типу SmartArtEx, если это SmartArt.
- Пройдитесь по всем узлам внутри формы SmartArt.
- Для каждого выбранного узла формы SmartArt пройдитесь по всем дочерним узлам внутри конкретного узла.
- Получите доступ и отобразите информацию, такую как позиция дочернего узла, уровень и текст.
```c#
 // Загрузить нужную презентацию
 Presentation pres = new Presentation("AccessChildNodes.pptx");

 // Пройтись по каждой фигуре внутри первого слайда
 foreach (IShape shape in pres.Slides[0].Shapes)
 {

     // Проверить, является ли объект типа SmartArt
     if (shape is Aspose.Slides.SmartArt.SmartArt)
     {

         // Привести тип объекта к SmartArt
         Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

         // Пройтись по всем узлам внутри SmartArt
         for (int i = 0; i < smart.AllNodes.Count; i++)
         {
             // Доступ к узлу SmartArt с индексом i
             Aspose.Slides.SmartArt.SmartArtNode node0 = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];

             // Проход по дочерним узлам узла SmartArt с индексом i
             for (int j = 0; j < node0.ChildNodes.Count; j++)
             {
                 // Доступ к дочернему узлу в узле SmartArt
                 Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)node0.ChildNodes[j];

                 // Вывод параметров дочернего узла SmartArt
                 string outString = string.Format("j = {0}, Text = {1},  Level = {2}, Position = {3}", j, node.TextFrame.Text, node.Level, node.Position);
                 Console.WriteLine(outString);
             }
         }
     }
 }
```




## **Доступ к дочернему узлу SmartArt в определённой позиции**
В этом примере мы узнаем, как получить доступ к дочерним узлам в определённой позиции, принадлежащим соответствующим узлам формы SmartArt.

- Создайте экземпляр класса `Presentation`.
- Получите ссылку на первый слайд, используя его индекс.
- Добавьте форму SmartArt типа StackedList.
- Получите доступ к добавленной форме SmartArt.
- Получите узел с индексом 0 для выбранной формы SmartArt.
- Затем получите дочерний узел на позиции 1 для выбранного узла SmartArt, используя метод GetNodeByPosition().
- Получите доступ и отобразите информацию, такую как позиция дочернего узла, уровень и текст.
```c#
// Создать экземпляр презентации
Presentation pres = new Presentation();

// Доступ к первому слайду
ISlide slide = pres.Slides[0];

// Добавление формы SmartArt на первый слайд
ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

// Доступ к узлу SmartArt с индексом 0
ISmartArtNode node = smart.AllNodes[0];

// Доступ к дочернему узлу на позиции 1 в родительском узле
int position = 1;
SmartArtNode chNode = (SmartArtNode)node.ChildNodes[position]; 

// Вывод параметров дочернего узла SmartArt
string outString = string.Format("j = {0}, Text = {1},  Level = {2}, Position = {3}", position, chNode.TextFrame.Text, chNode.Level, chNode.Position);
Console.WriteLine(outString);
```




## **Удалить узел SmartArt**
В этом примере мы узнаем, как удалить узлы внутри формы SmartArt.

- Создайте экземпляр класса `Presentation` и загрузите презентацию с формой SmartArt.
- Получите ссылку на первый слайд, используя его индекс.
- Пройдитесь по каждой форме внутри первого слайда.
- Проверьте, является ли форма типа SmartArt, и приведите выбранную форму к типу SmartArt, если это SmartArt.
- Проверьте, содержит ли SmartArt более 0 узлов.
- Выберите узел SmartArt, который нужно удалить.
- Затем удалите выбранный узел, используя метод RemoveNode(), и сохраните презентацию.
```c#
// Загрузить нужную презентацию
using (Presentation pres = new Presentation("RemoveNode.pptx"))
{

    // Пройтись по каждой фигуре внутри первого слайда
    foreach (IShape shape in pres.Slides[0].Shapes)
    {

        // Проверить, является ли объект типа SmartArt
        if (shape is ISmartArt)
        {
            // Привести тип объекта к SmartArtEx
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
В этом примере мы узнаем, как удалить узлы внутри формы SmartArt в определённой позиции.

- Создайте экземпляр класса `Presentation` и загрузите презентацию с формой SmartArt.
- Получите ссылку на первый слайд, используя его индекс.
- Пройдитесь по каждой форме внутри первого слайда.
- Проверьте, является ли форма типа SmartArt, и приведите выбранную форму к типу SmartArt, если это SmartArt.
- Выберите узел формы SmartArt с индексом 0.
- Затем проверьте, содержит ли выбранный узел SmartArt более 2 дочерних узлов.
- Затем удалите узел на позиции 1, используя метод RemoveNodeByPosition().
- Сохраните презентацию.
```c#
 // Загрузить нужную презентацию             
 Presentation pres = new Presentation("RemoveNodeSpecificPosition.pptx");

// Пройтись по каждой фигуре внутри первого слайда
foreach (IShape shape in pres.Slides[0].Shapes)
{
    // Проверить, является ли объект типа SmartArt
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {
        // Привести тип объекта к SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        if (smart.AllNodes.Count > 0)
        {
            // Доступ к узлу SmartArt с индексом 0
            Aspose.Slides.SmartArt.ISmartArtNode node = smart.AllNodes[0];

            if (node.ChildNodes.Count >= 2)
            {
                // Удаление дочернего узла на позиции 1
                ((Aspose.Slides.SmartArt.SmartArtNodeCollection)node.ChildNodes).RemoveNode(1);
            }

        }
    }
}

// Сохранить презентацию
pres.Save("RemoveSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```




## **Установить пользовательскую позицию для дочернего узла в SmartArt**
Теперь Aspose.Slides for .NET поддерживает установку свойств X и Y для SmartArtShape. Ниже приведён фрагмент кода, показывающий, как задать пользовательскую позицию, размер и вращение SmartArtShape; также обратите внимание, что добавление новых узлов вызывает перерасчёт позиций и размеров всех узлов.
```c#
// Загрузить нужную презентацию
Presentation pres = new Presentation("AccessChildNodes.pptx");

{
	ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

	// Переместить форму SmartArt в новое положение
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

	// Изменить вращение формы SmartArt
	node = smart.AllNodes[4];
	shape = node.Shapes[1];
	shape.Rotation = 90;

	pres.Save("SmartArt.pptx", SaveFormat.Pptx);
}
```




## **Проверить узел‑ассистент**
В следующем примере кода мы исследуем, как определить узлы‑ассистенты в коллекции узлов SmartArt и изменить их.

- Создайте экземпляр класса PresentationEx и загрузите презентацию с формой SmartArt.
- Получите ссылку на второй слайд, используя его индекс.
- Пройдитесь по каждой форме внутри первого слайда.
- Проверьте, является ли форма типа SmartArt, и приведите выбранную форму к типу SmartArtEx, если это SmartArt.
- Пройдитесь по всем узлам внутри формы SmartArt и проверьте, являются ли они узлами‑ассистентами.
- Измените статус узла‑ассистента на обычный узел.
- Сохраните презентацию.
```c#
// Создание экземпляра презентации
using (Presentation pres = new Presentation("AssistantNode.pptx"))
{
    // Пройтись по каждой фигуре внутри первого слайда
    foreach (IShape shape in pres.Slides[0].Shapes)
    {
        // Проверить, является ли объект типа SmartArt
        if (shape is Aspose.Slides.SmartArt.ISmartArt)
        {
            // Привести тип объекта к SmartArtEx
            Aspose.Slides.SmartArt.ISmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
            // Проход по всем узлам формы SmartArt

            foreach (Aspose.Slides.SmartArt.ISmartArtNode node in smart.AllNodes)
            {
                String tc = node.TextFrame.Text;
                // Проверить, является ли узел узлом‑ассистентом
                if (node.IsAssistant)
                {
                    // Установить свойство Assistant в false и сделать его обычным узлом
                    node.IsAssistant = false;
                }
            }
        }
    }
    // Сохранить презентацию
    pres.Save("ChangeAssitantNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```




## **Задать формат заливки узла**
Aspose.Slides for .NET позволяет добавлять пользовательские формы SmartArt и задавать их форматы заливки. Эта статья объясняет, как создавать и получать доступ к формам SmartArt и задавать их формат заливки с помощью Aspose.Slides for .NET.

Выполните следующие шаги:

- Создайте экземпляр класса `Presentation`.
- Получите ссылку на слайд, используя его индекс.
- Добавьте форму SmartArt, задав её LayoutType.
- Задайте FillFormat для узлов формы SmartArt.
- Запишите изменённую презентацию в файл PPTX.
```c#
using (Presentation presentation = new Presentation())
{
    // Доступ к слайду
    ISlide slide = presentation.Slides[0];

    // Добавление формы SmartArt и узлов
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
Разработчики могут создать миниатюру дочернего узла SmartArt, следуя нижеуказанным шагам:

1. Создайте экземпляр класса `Presentation`, представляющего файл PPTX.
2. Добавьте SmartArt.
3. Получите ссылку на узел, используя его индекс.
4. Получите изображение миниатюры.
5. Сохраните изображение миниатюры в любом нужном формате изображения.

Ниже приведён пример создания миниатюры дочернего узла SmartArt
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

Да. SmartArt рассматривается как обычная форма, поэтому вы можете [применять стандартные анимации](/slides/ru/net/shape-animation/) (вход, выход, акцент, траектории движения) и настраивать время. При необходимости можно анимировать формы внутри узлов SmartArt.

**Как надёжно найти определённый SmartArt на слайде, если его внутренний ID неизвестен?**

Назначьте и ищите по [альтернативному тексту](https://reference.aspose.com/slides/net/aspose.slides/shape/alternativetext/). Установка отличительного AltText для SmartArt позволяет находить его программно без зависимости от внутренних идентификаторов.

**Сохранится ли внешний вид SmartArt при конвертации презентации в PDF?**

Да. Aspose.Slides рендерит SmartArt с высокой визуальной точностью при [экспорте в PDF](/slides/ru/net/convert-powerpoint-to-pdf/), сохраняя макет, цвета и эффекты.

**Можно ли извлечь изображение всего SmartArt (для превью или отчетов)?**

Да. Вы можете отрисовать форму SmartArt в [растровые форматы](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) или в [SVG](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/) для масштабируемого векторного вывода, что делает его подходящим для миниатюр, отчетов или веб‑использования.