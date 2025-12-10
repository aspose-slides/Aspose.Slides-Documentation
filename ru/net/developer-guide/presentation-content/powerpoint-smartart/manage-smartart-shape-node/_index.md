---
title: Управление узлами фигур SmartArt в презентациях на .NET
linktitle: Узел фигуры SmartArt
type: docs
weight: 30
url: /ru/net/manage-smartart-shape-node/
keywords:
- Узел SmartArt
- Дочерний узел
- Добавить узел
- Позиция узла
- Доступ к узлу
- Удалить узел
- Пользовательская позиция
- Узел‑ассистент
- Формат заливки
- Отрисовка узла
- PowerPoint
- Презентация
- .NET
- C#
- Aspose.Slides
description: "Управление узлами фигур SmartArt в PPT и PPTX с помощью Aspose.Slides for .NET. Получите понятные примеры кода и советы по оптимизации ваших презентаций."
---

## **Добавить узел SmartArt**
Aspose.Slides for .NET предоставляет самый простой API для управления фигурами SmartArt самым простым способом. Следующий пример кода поможет добавить узел и дочерний узел внутри фигуры SmartArt.

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) и загрузите презентацию с фигурой SmartArt.
- Получите ссылку на первый слайд, используя его индекс.
- Пройдите по всем фигурам внутри первого слайда.
- Проверьте, является ли фигура типом SmartArt, и выполните приведение типа выбранной фигуры к SmartArt, если это SmartArt.
- Добавьте новый узел в коллекцию NodeCollection фигуры SmartArt и задайте текст в TextFrame.
- Затем добавьте дочерний узел в только что добавленный узел SmartArt и задайте текст в TextFrame.
- Сохраните презентацию.
```c#
// Загрузить нужную презентацию
Presentation pres = new Presentation("AddNodes.pptx");

// Перебрать все фигуры на первом слайде
foreach (IShape shape in pres.Slides[0].Shapes)
{

    // Проверить, является ли фигура типом SmartArt
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {

        // Преобразовать тип фигуры к SmartArt
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
В приведённом ниже примере кода мы объяснили, как добавить дочерние узлы, принадлежащие соответствующим узлам фигуры SmartArt, в определённой позиции.

- Создайте экземпляр класса `Presentation`.
- Получите ссылку на первый слайд, используя его индекс.
- Добавьте фигуру SmartArt типа StackedList на доступный слайд.
- Получите доступ к первому узлу в добавленной фигуре SmartArt.
- Затем добавьте дочерний узел для выбранного узла в позиции 2 и задайте его текст.
- Сохраните презентацию.
```c#
// Создание экземпляра презентации
Presentation pres = new Presentation();

// Получить слайд презентации
ISlide slide = pres.Slides[0];

// Добавить Smart Art IShape
ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

// Доступ к узлу SmartArt с индексом 0
ISmartArtNode node = smart.AllNodes[0];

// Добавление нового дочернего узла в позицию 2 родительского узла
SmartArtNode chNode = (SmartArtNode)((SmartArtNodeCollection)node.ChildNodes).AddNodeByPosition(2);

// Добавить текст
chNode.TextFrame.Text = "Sample Text Added";

// Сохранить презентацию
pres.Save("AddSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```





## **Доступ к узлу SmartArt**
Следующий пример кода поможет получить доступ к узлам внутри фигуры SmartArt. Обратите внимание, что вы не можете изменить LayoutType SmartArt, так как он доступен только для чтения и устанавливается только при добавлении фигуры SmartArt.

- Создайте экземпляр класса `Presentation` и загрузите презентацию с фигурой SmartArt.
- Получите ссылку на первый слайд, используя его индекс.
- Пройдите по всем фигурам внутри первого слайда.
- Проверьте, является ли фигура типом SmartArt, и выполните приведение типа выбранной фигуры к SmartArt, если это SmartArt.
- Пройдите по всем узлам внутри фигуры SmartArt.
- Получите и отобразите информацию, такую как позиция узла SmartArt, уровень и текст.
  ```c#
  // Загрузить нужную презентацию
   Presentation pres = new Presentation("AccessSmartArt.pptx");
  
  // Перебрать все фигуры на первом слайде
  foreach (IShape shape in pres.Slides[0].Shapes)
  {
      // Проверить, является ли фигура типом SmartArt
      if (shape is Aspose.Slides.SmartArt.SmartArt)
      {
  
          // Привести тип фигуры к SmartArt
          Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
  
          // Перебрать все узлы внутри SmartArt
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
Следующий пример кода поможет получить доступ к дочерним узлам, принадлежащим соответствующим узлам фигуры SmartArt.

- Создайте экземпляр класса PresentationEx и загрузите презентацию с фигурой SmartArt.
- Получите ссылку на первый слайд, используя его индекс.
- Пройдите по всем фигурам внутри первого слайда.
- Проверьте, является ли фигура типом SmartArt, и выполните приведение выбранной фигуры к SmartArtEx, если это SmartArt.
- Пройдите по всем узлам внутри фигуры SmartArt.
- Для каждого выбранного узла фигуры SmartArt пройдите по всем дочерним узлам внутри конкретного узла.
- Получите и отобразите информацию, такую как позиция дочернего узла, уровень и текст.
```c#
 // Загрузить нужную презентацию
 Presentation pres = new Presentation("AccessChildNodes.pptx");

 // Пройтись по всем фигурам первого слайда
 foreach (IShape shape in pres.Slides[0].Shapes)
 {

     // Проверить, является ли фигура типом SmartArt
     if (shape is Aspose.Slides.SmartArt.SmartArt)
     {

         // Преобразовать тип фигуры к SmartArt
         Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

         // Пройтись по всем узлам внутри SmartArt
         for (int i = 0; i < smart.AllNodes.Count; i++)
         {
             // Доступ к узлу SmartArt с индексом i
             Aspose.Slides.SmartArt.SmartArtNode node0 = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];

             // Пройтись по дочерним узлам узла SmartArt с индексом i
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
В этом примере мы научимся получать доступ к дочерним узлам в определённой позиции, принадлежащим соответствующим узлам фигуры SmartArt.

- Создайте экземпляр класса `Presentation`.
- Получите ссылку на первый слайд, используя его индекс.
- Добавьте фигуру SmartArt типа StackedList.
- Получите доступ к добавленной фигуре SmartArt.
- Получите узел с индексом 0 в полученной фигуре SmartArt.
- Затем получите дочерний узел в позиции 1 для выбранного узла SmartArt, используя метод GetNodeByPosition().
- Получите и отобразите информацию, такую как позиция дочернего узла, уровень и текст.
```c#
 // Создать экземпляр презентации
 Presentation pres = new Presentation();

 // Получение первого слайда
 ISlide slide = pres.Slides[0];

 // Добавление фигуры SmartArt на первый слайд
 ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

 // Доступ к узлу SmartArt  с индексом 0
 ISmartArtNode node = smart.AllNodes[0];

 // Доступ к дочернему узлу в позиции 1 родительского узла
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
- Пройдите по всем фигурам внутри первого слайда.
- Проверьте, является ли фигура типом SmartArt, и выполните приведение типа выбранной фигуры к SmartArt, если это SmartArt.
- Проверьте, содержит ли SmartArt более 0 узлов.
- Выберите узел SmartArt для удаления.
- Затем удалите выбранный узел с помощью метода RemoveNode() и сохраните презентацию.
```c#
// Загрузить нужную презентацию
using (Presentation pres = new Presentation("RemoveNode.pptx"))
{

    // Перебрать все фигуры на первом слайде
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
В этом примере мы научимся удалять узлы внутри фигуры SmartArt в определённой позиции.

- Создайте экземпляр класса `Presentation` и загрузите презентацию с фигурой SmartArt.
- Получите ссылку на первый слайд, используя его индекс.
- Пройдите по всем фигурам внутри первого слайда.
- Проверьте, является ли фигура типом SmartArt, и выполните приведение типа выбранной фигуры к SmartArt, если это SmartArt.
- Выберите узел фигуры SmartArt с индексом 0.
- Затем проверьте, содержит ли выбранный узел SmartArt более 2 дочерних узлов.
- Затем удалите узел в позиции 1 с помощью метода RemoveNodeByPosition().
- Сохраните презентацию.
```c#
// Загрузить нужную презентацию
Presentation pres = new Presentation("RemoveNodeSpecificPosition.pptx");

// Перебрать все фигуры на первом слайде
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
                // Удалить дочерний узел на позиции 1
                ((Aspose.Slides.SmartArt.SmartArtNodeCollection)node.ChildNodes).RemoveNode(1);
            }

        }
    }
}

// Сохранить презентацию
pres.Save("RemoveSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```




## **Установить пользовательскую позицию для дочернего узла в объекте SmartArt**
Теперь Aspose.Slides for .NET поддерживает установку свойств X и Y для SmartArtShape. Приведённый ниже фрагмент кода показывает, как задать пользовательскую позицию, размер и вращение SmartArtShape; также обратите внимание, что добавление новых узлов приводит к перерасчёту позиций и размеров всех узлов.
```c#
// Загрузить нужную презентацию
Presentation pres = new Presentation("AccessChildNodes.pptx");

{
    ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

    // Переместить фигуру SmartArt в новое положение
    ISmartArtNode node = smart.AllNodes[1];
    ISmartArtShape shape = node.Shapes[1];
    shape.X += (shape.Width * 2);
    shape.Y -= (shape.Height / 2);

    // Изменить ширину фигуры SmartArt
    node = smart.AllNodes[2];
    shape = node.Shapes[1];
    shape.Width += (shape.Width / 2);

    // Изменить высоту фигуры SmartArt
    node = smart.AllNodes[3];
    shape = node.Shapes[1];
    shape.Height += (shape.Height / 2);

    // Изменить вращение фигуры SmartArt
    node = smart.AllNodes[4];
    shape = node.Shapes[1];
    shape.Rotation = 90;

    pres.Save("SmartArt.pptx", SaveFormat.Pptx);
}
```




## **Проверить узел‑ассистент**
В следующем примере кода мы исследуем, как определить узлы‑ассистенты в коллекции узлов SmartArt и изменить их.

- Создайте экземпляр класса PresentationEx и загрузите презентацию с фигурой SmartArt.
- Получите ссылку на второй слайд, используя его индекс.
- Пройдите по всем фигурам внутри первого слайда.
- Проверьте, является ли фигура типом SmartArt, и выполните приведение выбранной фигуры к SmartArtEx, если это SmartArt.
- Пройдите по всем узлам внутри фигуры SmartArt и проверьте, являются ли они узлами‑ассистентами.
- Измените статус узла‑ассистента на обычный узел.
- Сохраните презентацию.
```c#
// Создание экземпляра презентации
using (Presentation pres = new Presentation("AssistantNode.pptx"))
{
    // Перебор всех фигур на первом слайде
    foreach (IShape shape in pres.Slides[0].Shapes)
    {
        // Проверка, является ли фигура типом SmartArt
        if (shape is Aspose.Slides.SmartArt.ISmartArt)
        {
            // Приведение типа фигуры к SmartArtEx
            Aspose.Slides.SmartArt.ISmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
            // Перебор всех узлов фигуры SmartArt

            foreach (Aspose.Slides.SmartArt.ISmartArtNode node in smart.AllNodes)
            {
                String tc = node.TextFrame.Text;
                // Проверка, является ли узел узлом‑ассистентом
                if (node.IsAssistant)
                {
                    // Установка свойства Assistant в false и преобразование в обычный узел
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
Aspose.Slides for .NET позволяет добавлять пользовательские фигуры SmartArt и задавать их форматы заливки. В этой статье объясняется, как создавать и получать доступ к фигурам SmartArt и задавать их формат заливки с помощью Aspose.Slides for .NET.

- Создайте экземпляр класса `Presentation`.
- Получите ссылку на слайд, используя его индекс.
- Добавьте фигуру SmartArt, задав её LayoutType.
- Задайте FillFormat для узлов фигуры SmartArt.
- Запишите изменённую презентацию в виде файла PPTX.
```c#
using (Presentation presentation = new Presentation())
{
    // Получение слайда
    ISlide slide = presentation.Slides[0];

    // Добавление фигуры SmartArt и узлов
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
Разработчики могут создать миниатюру дочернего узла SmartArt, следуя приведённым ниже шагам:

1. Создайте экземпляр класса `Presentation`, представляющего файл PPTX.
2. Добавьте SmartArt.
3. Получите ссылку на узел, используя его индекс.
4. Получите изображение миниатюры.
5. Сохраните изображение миниатюры в любом желаемом формате изображения.

Пример ниже генерирует миниатюру дочернего узла SmartArt
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

Да. SmartArt рассматривается как обычная фигура, поэтому вы можете [применять стандартные анимации](/slides/ru/net/shape-animation/) (вход, выход, акцент, траектории движения) и регулировать тайминг. При необходимости можно также анимировать фигуры внутри узлов SmartArt.

**Как надёжно найти конкретный SmartArt на слайде, если его внутренний идентификатор неизвестен?**

Назначьте и ищите по [альтернативному тексту](https://reference.aspose.com/slides/net/aspose.slides/shape/alternativetext/). Установка отличительного AltText для SmartArt позволяет находить его программно, не полагаясь на внутренние идентификаторы.

**Сохраняется ли внешний вид SmartArt при конвертации презентации в PDF?**

Да. Aspose.Slides отображает SmartArt с высокой визуальной точностью при [экспорте в PDF](/slides/ru/net/convert-powerpoint-to-pdf/), сохраняя макет, цвета и эффекты.

**Могу ли я извлечь изображение всего SmartArt (для превью или отчётов)?**

Да. Вы можете отрисовать фигуру SmartArt в [растровые форматы](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) или в [SVG](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/) для масштабируемого векторного вывода, что делает её подходящей для миниатюр, отчётов или веб‑использования.