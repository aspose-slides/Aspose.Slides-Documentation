---
title: Раздел слайдов
type: docs
weight: 100
url: /net/slide-section/
keywords: "Создание раздела, Добавление раздела, Изменение имени раздела, Презентация PowerPoint, C#, Csharp, .NET, Aspose.Slides"
description: "Добавление и редактирование раздела в презентации PowerPoint на C# или .NET"
---

С помощью Aspose.Slides для .NET вы можете организовать презентацию PowerPoint на разделы. Вы можете создавать разделы, содержащие определенные слайды.

Вы можете захотеть создать разделы и использовать их для организации или разделения слайдов в презентации на логические части в следующих ситуациях:

- Когда вы работаете над большой презентацией с другими людьми или командой, и вам нужно назначить определенные слайды коллеге или некоторым членам команды.
- Когда вы имеете дело с презентацией, которая содержит много слайдов, и вам сложно управлять или редактировать ее содержимое сразу.

В идеале вам следует создать раздел, который объединяет похожие слайды — слайды имеют что-то общее или могут существовать в группе на основе определенного правила — и дать разделу имя, которое описывает слайды внутри него.

## Создание разделов в презентациях

Чтобы добавить раздел, который будет хранить слайды в презентации, Aspose.Slides для .NET предоставляет метод AddSection, который позволяет вам указать имя раздела, который вы собираетесь создать, и слайд, с которого начинается раздел.

Этот пример кода показывает, как создать раздел в презентации на C#:

```c#
using (Presentation pres = new Presentation())
{
    ISlide defaultSlide = pres.Slides[0];
    ISlide newSlide1 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide2 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide3 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide4 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

    ISection section1 = pres.Sections.AddSection("Раздел 1", newSlide1);
    ISection section2 = pres.Sections.AddSection("Раздел 2", newSlide3); // раздел 1 завершится на newSlide2, и после этого начнется раздел 2   
    
    pres.Save("pres-sections.pptx", SaveFormat.Pptx);
    
    pres.Sections.ReorderSectionWithSlides(section2, 0);
    pres.Save("pres-sections-moved.pptx", SaveFormat.Pptx);
    
    pres.Sections.RemoveSectionWithSlides(section2);
    
    pres.Sections.AppendEmptySection("Последний пустой раздел");
    
    pres.Save("pres-section-with-empty.pptx",SaveFormat.Pptx);
}
```

## Изменение имен разделов

После того как вы создадите раздел в презентации PowerPoint, вы можете решить изменить его имя.

Этот пример кода показывает, как изменить имя раздела в презентации на C# с использованием Aspose.Slides:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ISection section = pres.Sections[0];
   section.Name = "Мой раздел";
}
```