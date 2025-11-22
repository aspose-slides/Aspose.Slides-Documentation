---
title: Раздел слайдов
type: docs
weight: 100
url: /ru/net/slide-section/
keywords: "Создать раздел, Добавить раздел, Изменить имя раздела, Презентация PowerPoint, C#, Csharp, .NET, Aspose.Slides"
description: "Добавить и изменить раздел в презентации PowerPoint на C# или .NET"
---

С помощью Aspose.Slides для .NET вы можете организовать презентацию PowerPoint по разделам. Вы можете создавать разделы, содержащие определённые слайды. 

Вы можете захотеть создать разделы и использовать их для организации или деления слайдов в презентации на логические части в следующих ситуациях:

- Когда вы работаете над большой презентацией совместно с другими людьми или командой — и необходимо назначить определённые слайды коллеге или нескольким членам команды. 
- Когда вы имеете дело с презентацией, содержащей множество слайдов — и у вас возникают трудности с управлением или редактированием её содержимого сразу.

Оптимально создавать раздел, в котором находятся схожие слайды — слайды имеют что‑то общее или могут быть сгруппированы по правилу — и давать разделу имя, описывающее содержащиеся в нём слайды. 

## **Создание разделов в презентациях**

Чтобы добавить раздел, где будут размещаться слайды презентации, Aspose.Slides для .NET предоставляет метод AddSection, позволяющий указать имя создаваемого раздела и слайд, с которого начинается раздел. 

В этом примере кода показано, как создать раздел в презентации на C#:
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


## **Изменение имён разделов**

После создания раздела в презентации PowerPoint вы можете решить изменить его имя. 

В этом примере кода показано, как изменить имя раздела в презентации на C# с использованием Aspose.Slides:
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

**Можно ли быстро найти раздел по слайду и, наоборот, первый слайд раздела?**

Да. Раздел однозначно определяется стартовым слайдом; зная слайд, можно определить, к какому разделу он принадлежит, а для раздела можно получить его первый слайд.