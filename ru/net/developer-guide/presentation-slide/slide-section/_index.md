---
title: Управление разделами слайдов в презентациях в .NET
linktitle: Раздел слайдов
type: docs
weight: 100
url: /ru/net/slide-section/
keywords:
- создать раздел
- добавить раздел
- редактировать раздел
- изменить раздел
- имя раздела
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Оптимизируйте разделы слайдов в PowerPoint и OpenDocument с помощью Aspose.Slides для .NET — разделяйте, переименовывайте и меняйте порядок, чтобы улучшить рабочие процессы PPTX и ODP."
---

С помощью Aspose.Slides для .NET вы можете организовать презентацию PowerPoint по разделам. Вы можете создавать разделы, содержащие определённые слайды.

Возможно, вам понадобится создавать разделы и использовать их для организации или разделения слайдов в презентации на логические части в следующих ситуациях:

- Когда вы работаете над большой презентацией совместно с другими людьми или командой - и нужно назначить определённые слайды коллеге или нескольким членам команды.
- Когда вы имеете дело с презентацией, содержащей множество слайдов - и вам сложно управлять или редактировать её содержимое одновременно.

Оптимально создавать раздел, в котором находятся схожие слайды - слайды имеют что-то общее или могут быть сгруппированы по правилу - и задавать разделу имя, описывающее содержащиеся в нём слайды.

## **Create Sections in Presentations**

Чтобы добавить раздел, содержащий слайды в презентации, Aspose.Slides для .NET предоставляет метод AddSection, который позволяет указать имя создаваемого раздела и слайд, с которого начинается раздел.

Этот пример кода показывает, как создать раздел в презентации на C#:
```c#
using (Presentation pres = new Presentation())
{
    ISlide defaultSlide = pres.Slides[0];
    ISlide newSlide1 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide2 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide3 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide4 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

    ISection section1 = pres.Sections.AddSection("Section 1", newSlide1);
    ISection section2 = pres.Sections.AddSection("Section 2", newSlide3); // section1 будет завершён на newSlide2, а после него начнётся section2   
    
    pres.Save("pres-sections.pptx", SaveFormat.Pptx);
    
    pres.Sections.ReorderSectionWithSlides(section2, 0);
    pres.Save("pres-sections-moved.pptx", SaveFormat.Pptx);
    
    pres.Sections.RemoveSectionWithSlides(section2);
    
    pres.Sections.AppendEmptySection("Last empty section");
    
    pres.Save("pres-section-with-empty.pptx",SaveFormat.Pptx);
}
```


## **Change the Names of Sections**

После создания раздела в презентации PowerPoint вы можете решить изменить его имя.

Этот пример кода показывает, как изменить имя раздела в презентации на C# с использованием Aspose.Slides:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ISection section = pres.Sections[0];
   section.Name = "My section";
}
```


## **FAQ**

**Сохраняются ли разделы при сохранении в формат PPT (PowerPoint 97–2003)?**

Нет. Формат PPT не поддерживает метаданные разделов, поэтому группировка разделов теряется при сохранении в .ppt.

**Можно ли полностью скрыть раздел?**

Нет. Скрывать можно только отдельные слайды. У раздела как объекта нет состояния «скрытый».

**Могу ли я быстро найти раздел по слайду и, наоборот, первый слайд раздела?**

Да. Раздел однозначно определяется своим начальным слайдом; имея слайд, можно определить, к какому разделу он относится, а для раздела можно получить его первый слайд.