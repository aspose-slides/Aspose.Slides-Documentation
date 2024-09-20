---
title: Управление узлом формы SmartArt
type: docs
weight: 30
url: /net/manage-smartart-shape-node/
keywords: "Узел SmartArt, дочерний узел SmartArt, презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "Умный узел и дочерний узел в презентациях PowerPoint на C# или .NET"
---


## **Добавить узел SmartArt**
Aspose.Slides для .NET предоставляет самый простой API для управления формами SmartArt самым простым образом. Следующий пример кода поможет добавить узел и дочерний узел внутри формы SmartArt.

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) и загрузите презентацию с формой SmartArt.
- Получите ссылку на первый слайд, используя его индекс.
- Пройдите через каждую форму внутри первого слайда.
- Проверьте, является ли форма типом SmartArt и выполните приведение выбранной формы к типу SmartArt, если это SmartArt.
- Добавьте новый узел в коллекцию узлов формы SmartArt и установите текст в TextFrame.
- Теперь добавьте дочерний узел в только что добавленный узел SmartArt и установите текст в TextFrame.
- Сохраните презентацию.

```c#
// Загрузите нужную презентацию
Presentation pres = new Presentation("AddNodes.pptx");

// Проходите через каждую форму внутри первого слайда
foreach (IShape shape in pres.Slides[0].Shapes)
{

    // Проверьте, является ли форма типом SmartArt
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {

        // Приведите форму к типу SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        // Добавление нового узла SmartArt
        Aspose.Slides.SmartArt.SmartArtNode TemNode = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes.AddNode();

        // Добавление текста
        TemNode.TextFrame.Text = "Тест";

        // Добавление нового дочернего узла в родительский узел. Он будет добавлен в конец коллекции
        Aspose.Slides.SmartArt.SmartArtNode newNode = (Aspose.Slides.SmartArt.SmartArtNode)TemNode.ChildNodes.AddNode();

        // Добавление текста
        newNode.TextFrame.Text = "Добавлен новый узел";

    }
}

// Сохранение презентации
pres.Save("AddSmartArtNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```



## **Добавить узел SmartArt в конкретной позиции**
В следующем примере кода объясняется, как добавить дочерние узлы, принадлежащие соответствующим узлам формы SmartArt, в определенной позиции.

- Создайте экземпляр класса `Presentation`.
- Получите ссылку на первый слайд, используя его индекс.
- Добавьте форму SmartArt типа StackedList на доступленный слайд.
- Получите доступ к первому узлу в добавленной форме SmartArt.
- Теперь добавьте дочерний узел для выбранного узла на позиции 2 и установите его текст.
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

// Добавление нового дочернего узла на позиции 2 в родительском узле
SmartArtNode chNode = (SmartArtNode)((SmartArtNodeCollection)node.ChildNodes).AddNodeByPosition(2);

// Добавьте текст
chNode.TextFrame.Text = "Добавленный пример текста";

// Сохранить презентацию
pres.Save("AddSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```




## **Доступ к узлу SmartArt**
Следующий пример кода поможет получить доступ к узлам внутри формы SmartArt. Пожалуйста, обратите внимание, что вы не можете изменить LayoutType SmartArt, так как он только для чтения и устанавливается только при добавлении формы SmartArt.

- Создайте экземпляр класса `Presentation` и загрузите презентацию с формой SmartArt.

- Получите ссылку на первый слайд, используя его индекс.

- Пройдите через каждую форму внутри первого слайда.

- Проверьте, является ли форма типом SmartArt и выполните приведение выбранной формы к типу SmartArt, если это SmartArt.

- Пройдите через все узлы внутри формы SmartArt.

- Получите доступ и отобразите информацию, такую как позиция узла SmartArt, уровень и текст.

  ```c#
  // Загрузите нужную презентацию
   Presentation pres = new Presentation("AccessSmartArt.pptx");
  
  // Пройдите через каждую форму внутри первого слайда
  foreach (IShape shape in pres.Slides[0].Shapes)
  {
      // Проверьте, является ли форма типом SmartArt
      if (shape is Aspose.Slides.SmartArt.SmartArt)
      {
  
          // Приведите форму к типу SmartArt
          Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
  
          // Пройдите через все узлы внутри SmartArt
          for (int i = 0; i < smart.AllNodes.Count; i++)
          {
              // Получение доступа к узлу SmartArt по индексу i
              Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];
  
              // Печать параметров узла SmartArt
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
- Пройдите через каждую форму внутри первого слайда.
- Проверьте, является ли форма типом SmartArt и выполните приведение выбранной формы к типу SmartArtEx, если это SmartArt.
- Пройдите через все узлы внутри формы SmartArt.
- Для каждого выбранного узла SmartArt пройдите через все дочерние узлы внутри конкретного узла.
- Получите доступ и отобразите информацию, такую как позиция дочернего узла, уровень и текст.

```c#
// Загрузите нужную презентацию
Presentation pres = new Presentation("AccessChildNodes.pptx");

// Пройдите через каждую форму внутри первого слайда
foreach (IShape shape in pres.Slides[0].Shapes)
{

    // Проверьте, является ли форма типом SmartArt
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {

        // Приведите форму к типу SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        // Пройдите через все узлы внутри SmartArt
        for (int i = 0; i < smart.AllNodes.Count; i++)
        {
            // Получение доступа к узлу SmartArt по индексу i
            Aspose.Slides.SmartArt.SmartArtNode node0 = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];

            // Пройдите через дочерние узлы в узле SmartArt с индексом i
            for (int j = 0; j < node0.ChildNodes.Count; j++)
            {
                // Получение доступа к дочернему узлу в узле SmartArt
                Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)node0.ChildNodes[j];

                // Печать параметров дочернего узла SmartArt
                string outString = string.Format("j = {0}, Text = {1},  Level = {2}, Position = {3}", j, node.TextFrame.Text, node.Level, node.Position);
                Console.WriteLine(outString);
            }
        }
    }
}
```



## **Доступ к дочернему узлу SmartArt в конкретной позиции**
В этом примере мы узнаем, как получить доступ к дочерним узлам в определенной позиции, принадлежащим соответствующим узлам формы SmartArt.

- Создайте экземпляр класса `Presentation`.
- Получите ссылку на первый слайд, используя его индекс.
- Добавьте форму SmartArt типа StackedList.
- Получите доступ к добавленной форме SmartArt.
- Получите доступ к узлу с индексом 0 для доступа к форме SmartArt.
- Теперь получите доступ к дочернему узлу на позиции 1 для доступа к узлу SmartArt с помощью метода GetNodeByPosition().
- Получите доступ и отобразите информацию, такую как позиция дочернего узла, уровень и текст.

```c#
// Создание экземпляра презентации
Presentation pres = new Presentation();

// Получение доступа к первому слайду
ISlide slide = pres.Slides[0];

// Добавление формы SmartArt на первый слайд
ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

// Получение доступа к узлу SmartArt с индексом 0
ISmartArtNode node = smart.AllNodes[0];

// Получение доступа к дочернему узлу на позиции 1 в родительском узле
int position = 1;
SmartArtNode chNode = (SmartArtNode)node.ChildNodes[position]; 

// Печать параметров дочернего узла SmartArt
string outString = string.Format("j = {0}, Text = {1},  Level = {2}, Position = {3}", position, chNode.TextFrame.Text, chNode.Level, chNode.Position);
Console.WriteLine(outString);
```



## **Удалить узел SmartArt**
В этом примере мы узнаем, как удалять узлы внутри формы SmartArt.

- Создайте экземпляр класса `Presentation` и загрузите презентацию с формой SmartArt.
- Получите ссылку на первый слайд, используя его индекс.
- Пройдите через каждую форму внутри первого слайда.
- Проверьте, является ли форма типом SmartArt и выполните приведение выбранной формы к типу SmartArt, если это SmartArt.
- Проверьте, есть ли у SmartArt более 0 узлов.
- Выберите узел SmartArt, который нужно удалить.
- Теперь удалите выбранный узел с помощью метода RemoveNode() * Сохраните презентацию.

```c#
// Загрузите нужную презентацию
using (Presentation pres = new Presentation("RemoveNode.pptx"))
{

    // Пройдите через каждую форму внутри первого слайда
    foreach (IShape shape in pres.Slides[0].Shapes)
    {

        // Проверьте, является ли форма типом SmartArt
        if (shape is ISmartArt)
        {
            // Приведите форму к типу SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            if (smart.AllNodes.Count > 0)
            {
                // Получение доступа к узлу SmartArt по индексу 0
                ISmartArtNode node = smart.AllNodes[0];

                // Удаление выбранного узла
                smart.AllNodes.RemoveNode(node);

            }
        }
    }

    // Сохраните презентацию
    pres.Save("RemoveSmartArtNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```



## **Удалить узел SmartArt в конкретной позиции**
В этом примере мы узнаем, как удалять узлы внутри формы SmartArt в определенной позиции.

- Создайте экземпляр класса `Presentation` и загрузите презентацию с формой SmartArt.
- Получите ссылку на первый слайд, используя его индекс.
- Пройдите через каждую форму внутри первого слайда.
- Проверьте, является ли форма типом SmartArt и выполните приведение выбранной формы к типу SmartArt, если это SmartArt.
- Выберите узел формы SmartArt с индексом 0.
- Теперь проверьте, имеет ли выбранный узел SmartArt более 2 дочерних узлов.
- Теперь удалите узел на позиции 1 с помощью метода RemoveNodeByPosition().
- Сохраните презентацию.

```c#
// Загрузите нужную презентацию             
Presentation pres = new Presentation("RemoveNodeSpecificPosition.pptx");

// Пройдите через каждую форму внутри первого слайда
foreach (IShape shape in pres.Slides[0].Shapes)
{
    // Проверьте, является ли форма типом SmartArt
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {
        // Приведите форму к типу SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        if (smart.AllNodes.Count > 0)
        {
            // Получение доступа к узлу SmartArt по индексу 0
            Aspose.Slides.SmartArt.ISmartArtNode node = smart.AllNodes[0];

            if (node.ChildNodes.Count >= 2)
            {
                // Удаление дочернего узла на позиции 1
                ((Aspose.Slides.SmartArt.SmartArtNodeCollection)node.ChildNodes).RemoveNode(1);
            }

        }
    }
}

// Сохраните презентацию
pres.Save("RemoveSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```



## **Установить пользовательскую позицию для дочернего узла в SmartArt**
Теперь Aspose.Slides для .NET поддерживает установку свойств X и Y SmartArtShape. Код ниже показывает, как установить пользовательскую позицию, размер и вращение SmartArtShape. Обратите внимание, что добавление новых узлов вызывает перерасчет позиций и размеров всех узлов.

```c#
// Загрузите нужную презентацию
Presentation pres = new Presentation("AccessChildNodes.pptx");

{
	ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

	// Переместите форму SmartArt в новую позицию
	ISmartArtNode node = smart.AllNodes[1];
	ISmartArtShape shape = node.Shapes[1];
	shape.X += (shape.Width * 2);
	shape.Y -= (shape.Height / 2);

	// Измените ширину форм SmartArt
	node = smart.AllNodes[2];
	shape = node.Shapes[1];
	shape.Width += (shape.Width / 2);

	// Измените высоту форм SmartArt
	node = smart.AllNodes[3];
	shape = node.Shapes[1];
	shape.Height += (shape.Height / 2);

	// Измените вращение формы SmartArt
	node = smart.AllNodes[4];
	shape = node.Shapes[1];
	shape.Rotation = 90;

	pres.Save("SmartArt.pptx", SaveFormat.Pptx);
}
```



## **Проверка узла помощника**
В следующем примере кода мы исследуем, как идентифицировать узлы помощника в коллекции узлов SmartArt и изменить их.

- Создайте экземпляр класса PresentationEx и загрузите презентацию с формой SmartArt.
- Получите ссылку на второй слайд, используя его индекс.
- Пройдите через каждую форму внутри первого слайда.
- Проверьте, является ли форма типом SmartArt и выполните приведение выбранной формы к типу SmartArtEx, если это SmartArt.
- Пройдите через все узлы внутри формы SmartArt и проверьте, являются ли они узлами помощника.
- Измените статус узла помощника на обычный узел.
- Сохраните презентацию.

```c#
// Создание экземпляра презентации
using (Presentation pres = new Presentation("AssistantNode.pptx"))
{
    // Пройдите через каждую форму внутри первого слайда
    foreach (IShape shape in pres.Slides[0].Shapes)
    {
        // Проверьте, является ли форма типом SmartArt
        if (shape is Aspose.Slides.SmartArt.ISmartArt)
        {
            // Приведите форму к типу SmartArtEx
            Aspose.Slides.SmartArt.ISmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
            // Пройдите через все узлы формы SmartArt

            foreach (Aspose.Slides.SmartArt.ISmartArtNode node in smart.AllNodes)
            {
                String tc = node.TextFrame.Text;
                // Проверьте, является ли узел узлом помощника
                if (node.IsAssistant)
                {
                    // Установите узел помощника на false и сделайте его обычным узлом
                    node.IsAssistant = false;
                }
            }
        }
    }
    // Сохраните презентацию
    pres.Save("ChangeAssitantNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```



## **Установить формат заливки узла**
Aspose.Slides для .NET позволяет добавлять пользовательские формы SmartArt и устанавливать их форматы заливки. Эта статья объясняет, как создавать и получать доступ к формам SmartArt и устанавливать их формат заливки с помощью Aspose.Slides для .NET.

Пожалуйста, выполните следующие шаги:

- Создайте экземпляр класса `Presentation`.
- Получите ссылку на слайд, используя его индекс.
- Добавьте форму SmartArt, установив его LayoutType.
- Установите формат заливки для узлов формы SmartArt.
- Запишите измененную презентацию в файл PPTX.

```c#
using (Presentation presentation = new Presentation())
{
    // Получение доступа к слайду
    ISlide slide = presentation.Slides[0];

    // Добавление формы SmartArt и узлов
    var chevron = slide.Shapes.AddSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    var node = chevron.AllNodes.AddNode();
    node.TextFrame.Text = "Некоторый текст";

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



## **Генерация миниатюры дочернего узла SmartArt**
Разработчики могут генерировать миниатюру дочернего узла SmartArt, следуя нижеуказанным шагам:

1. Создайте экземпляр класса `Presentation`, который представляет файл PPTX.
1. Добавьте SmartArt.
1. Получите ссылку на узел, используя его индекс.
1. Получите миниатюрное изображение.
1. Сохраните миниатюру в любом желаемом формате изображения.

Пример ниже генерирует миниатюру дочернего узла SmartArt.

```c#
// Создание экземпляра класса Presentation, который представляет файл PPTX 
Presentation pres = new Presentation();

// Добавление SmartArt 
ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

// Получение ссылки на узел, используя его индекс  
ISmartArtNode node = smart.Nodes[1];

// Получение миниатюры
Bitmap bmp = node.Shapes[0].GetThumbnail();

// Сохраните миниатюру
bmp.Save("SmartArt_ChildNote_Thumbnail_out.jpeg", ImageFormat.Jpeg);
```